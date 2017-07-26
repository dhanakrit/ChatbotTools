using LogMessageClassifier.Models;
using LogMessageClassifier.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ChatLogContext;
using System.Text;

namespace LogMessageClassifier.Controllers
{
    public class ClassifierController : Controller
    {
        // GET: Classifier
        public ActionResult Index()
        {
            using (var db = new ChatLogDataContext())
            {
                var modes = new List<SelectListItem>()
                {
                    new SelectListItem{Text="All new items", Value = "0"},
                    new SelectListItem{Text="View Skipped items", Value = "2"}
                };

                

                //var doneMessages = db.ClassifiedMessages

                //PagedList<ClassifiedMessage> model = new PagedList<ClassifiedMessage>

                return View(this.GetClassifiedMessages(1, 10));
            }
        }

        [HttpPost]
        public ActionResult Index(int currentPage, int pageSize)
        {
            return View(this.GetClassifiedMessages(currentPage, pageSize));
        }

        private ClassifyIndexViewModel GetClassifiedMessages(int currentPage, int pageSize)
        {
            using (var db = new ChatLogDataContext())
            {
                var items = (from cm in db.ClassifiedMessages
                             join l in db.LogMessages on cm.MessageId equals l.Id                             
                             select new DetailedClassifiedMessage()
                             {
                                 MessageId = l.Id,
                                 Message = l.Message,                                 
                                 SecondCategoryId = cm.SecondCategoryId.GetValueOrDefault(0),
                                 SecondCategoryName = db.Categories.Single(x => x.Id == cm.SecondCategoryId).CategoryName,
                                 SelectedCategories = cm.SelectedCategories == null ? cm.CategoryId.GetValueOrDefault(0).ToString() : cm.SelectedCategories,
                                 SelectedCategoryNames = this.GenerateDisplayCategories(db, cm.SelectedCategories == null ? cm.CategoryId.GetValueOrDefault(0).ToString() : cm.SelectedCategories)
                             })
                             .OrderByDescending(m => m.MessageId)
                             .Skip((currentPage - 1) * pageSize)
                             .Take(pageSize).ToList();
                var maxCount = (double)((decimal)db.ClassifiedMessages.Count() / Convert.ToDecimal(pageSize));

                var modes = new List<SelectListItem>()
                {
                    new SelectListItem{Text="All new items", Value = "0"},
                    new SelectListItem{Text="View Skipped items", Value = "2"}
                };

                
                var CountNew = db.LogMessages.Count(m => m.Status == (short)MessageStatus.New);
                var CountSkipped = db.LogMessages.Count(m => m.Status == (short)MessageStatus.Skipped);
                var CountDone = db.LogMessages.Count(m => m.Status == (short)MessageStatus.Done);
                var CountDiscarded = db.LogMessages.Count(m => m.Status == (short)MessageStatus.Discarded);

                var model = new ClassifyIndexViewModel()
                {
                    CurrentPage = currentPage,
                    Messages = items,
                    TotalRecords = items.Count,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(maxCount),
                    Modes = modes,
                    CountDiscarded = CountDiscarded,
                    CountDone = CountDone,
                    CountNew = CountNew,
                    CountSkipped = CountSkipped
                };

                return model;
            }
        }

        private string GenerateDisplayCategories(ChatLogDataContext db, string listOfIds)
        {
            var result = new StringBuilder();
            int count = 0;

            foreach(var id in listOfIds.Split(new char[]{'|' }))
            {
                result.Append(db.Categories.Single(c => c.Id == Convert.ToInt32(id)).CategoryName);
                count++;

                if (count < listOfIds.Split(new char[] { '|' }).Length)
                {
                    result.Append(" | ");
                }
            }

            return result.ToString();
        }
        
        public ActionResult Classify(string MessageID, string CategoryID, string Mode, bool? isSecond)
        {
            var mode = (ClassificationMode)Enum.Parse(typeof(ClassificationMode), Mode);

            using (var db = new ChatLogDataContext())
            {
                if(MessageID != null)
                {
                    int mid = Convert.ToInt32(MessageID);
                    int cid = Convert.ToInt32(CategoryID);

                    var result = this.Classify(db, mid, cid, mode, isSecond.Value);

                    if (result)
                        return View("Classify", GetNextUnclassifiedItem(mode, db, mid));

                }

                return View("Classify", GetNextUnclassifiedItem(mode, db, 0));
            }
        }

        [HttpPost]
        public ActionResult Classify(FormCollection collection)
        {
            var mode = (ClassificationMode)Enum.Parse(typeof(ClassificationMode), collection["Mode"]);

            using (var db = new ChatLogDataContext())
            {
                if (!string.IsNullOrEmpty(collection["MessageID"]))
                {
                    int mid = Convert.ToInt32(collection["MessageID"]);

                    var result = this.Classify(db, mid, collection["selectedCategories"], mode, false);

                    if (result)
                        return View("Index", this.GetClassifiedMessages(1, 10));
                }

                return View("Index", this.GetClassifiedMessages(1, 10));
            }
        }

        private bool Classify(ChatLogDataContext db, int MessageID, int CategoryID, ClassificationMode Mode, bool isSecond = false)
        {
            try
            {
                // Save or update to the classified
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == MessageID);
                var citem = db.Categories.SingleOrDefault(c => c.Id == CategoryID);

                if (mitem != null && citem != null)
                {
                    // Check if the item exists
                    var cl = db.ClassifiedMessages.SingleOrDefault(c => c.MessageId == MessageID);

                    if (cl != null)
                    {
                        // Already exists -- set to the new category
                        if (isSecond)
                        {
                            cl.SecondCategoryId = CategoryID;
                        }
                        else
                        {
                            cl.CategoryId = CategoryID;
                        }

                        cl.DateModified = DateTime.Now;
                    }
                    else
                    {
                        // Add a new one
                        db.ClassifiedMessages.InsertOnSubmit(new ClassifiedMessage
                        {
                            CategoryId = citem.Id,
                            MessageId = mitem.Id,
                            DateModified = DateTime.Now
                        });
                    }

                    //Update the message status
                    mitem.Status = (short)MessageStatus.Done;
                    mitem.DateModified = DateTime.Now;

                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Classify(ChatLogDataContext db, int MessageID, string CategoryIds, ClassificationMode Mode, bool isSecond = false)
        {
            try
            {
                // Save or update to the classified
                var originalMessage = db.LogMessages.SingleOrDefault(l => l.Id == MessageID);

                if (originalMessage != null)
                {
                    // Check if the item exists
                    var classified01 = db.ClassifiedMessages.SingleOrDefault(c => c.MessageId == MessageID);

                    if (classified01 != null)
                    {
                        // Already exists -- set to the new category
                        classified01.SelectedCategories = CategoryIds.Replace(',', '|');
                        classified01.DateModified = DateTime.Now;
                    }
                    else
                    {
                        // Add a new one
                        db.ClassifiedMessages.InsertOnSubmit(new ClassifiedMessage
                        {                            
                            MessageId = originalMessage.Id,
                            SelectedCategories = CategoryIds.Replace(',', '|'),
                            DateModified = DateTime.Now
                        });
                    }

                    //Update the message status
                    originalMessage.Status = (short)MessageStatus.Done;
                    originalMessage.DateModified = DateTime.Now;

                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // GET: Classifier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Classifier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classifier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Skip(string messageId, ClassificationMode mode)
        {
            int mid = Convert.ToInt32(messageId);

            using (var db = new ChatLogDataContext())
            {
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);

                if (mitem != null)
                {
                    // Update status and move next
                    mitem.Status = (short)MessageStatus.Skipped;
                    mitem.DateModified = DateTime.Now;
                }

                db.SubmitChanges();

                return View("Classify", GetNextUnclassifiedItem(mode, db, mid));
            }
        }

        public ActionResult Discard(string messageId, ClassificationMode mode)
        {
            int mid = Convert.ToInt32(messageId);

            using (var db = new ChatLogDataContext())
            {
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);

                if (mitem != null)
                {
                    // Update status and move next
                    mitem.Status = (short)MessageStatus.Discarded;
                    mitem.DateModified = DateTime.Now;
                }

                db.SubmitChanges();

                return View("Classify", GetNextUnclassifiedItem(mode, db, mid));
            }
        }

        public ActionResult Next(string messageId, ClassificationMode mode)
        {
            int mid = Convert.ToInt32(messageId);

            using (var db = new ChatLogDataContext())
            {
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);

                //if (mitem != null)
                //{
                //    // Update status and move next
                //    mitem.Status = (short)MessageStatus.Skipped;
                //    mitem.DateModified = DateTime.Now;
                //}

                //db.SubmitChanges();

                return View("Classify", GetNextUnclassifiedItem(mode, db, mid));
            }
        }

        // GET: Classifier/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new ChatLogDataContext())
            {
                // Get the item

                var item = db.ClassifiedMessages.SingleOrDefault(m => m.MessageId == id);

                if (item != null)
                {
                    var log = db.LogMessages.Single(m => m.Id == item.MessageId);

                    return View("Classify", new ClassifyViewModel()
                    {
                        Categories = db.Categories.ToList(),
                        Selectors = CategorySelector.GetCategorySelectors(db.Categories.ToList()),
                        IsEditMode = true,
                        CategoryId = item.CategoryId.GetValueOrDefault(),
                        MessageId = item.MessageId,
                        SecondCategoryId = item.SecondCategoryId.GetValueOrDefault(),
                        RelatedMessages = db.LogMessages.Where(m => m.SessionFileName == log.SessionFileName).OrderBy(m => m.Id).ToList(),
                        Message = log.Message,
                        Mode = ClassificationMode.Edit,
                        SelectedCategories = item.SelectedCategories == null ? item.CategoryId.Value.ToString("N0") : item.SelectedCategories
                    });
                }

                return View("Classify");
            }
        }

        // POST: Classifier/Edit/5
        [HttpPost]        
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classifier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Classifier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ClassifyViewModel GetNextUnclassifiedItem(ClassificationMode mode, ChatLogDataContext db, int currentId)
        {
            var firstitem = db.LogMessages.OrderBy(m => m.Id).FirstOrDefault(m => m.Status == (short)mode);

            try
            {
                if(firstitem != null)
                {
                    var newitem = db.LogMessages.OrderBy(m => m.Id).FirstOrDefault(m => m.Status == (short)mode && m.Id > currentId);

                    if(newitem != null)
                    {
                        firstitem = newitem;
                    }
                }

                if(firstitem == null)
                {
                    firstitem = new LogMessage() { Id = 0, Message = string.Empty };
                }

                // Get related messages
                var related = db.LogMessages.Where(m => m.SessionFileName == firstitem.SessionFileName).OrderBy(m => m.Id).ToList();
                
                return new ClassifyViewModel()
                {
                    MessageId = firstitem.Id,
                    Mode = mode,
                    Message = firstitem.Message,
                    Categories = db.Categories.ToList(),
                    RelatedMessages = related,
                    Selectors = CategorySelector.GetCategorySelectors(db.Categories.ToList()),
                    SelectedCategories = string.Empty
                };
            }
            finally
            {
                firstitem = null;
            }
        }
    }
}
