using LogMessageClassifier.Models;
using LogMessageClassifier.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace LogMessageClassifier.Controllers
{
    public class ClassifierController : Controller
    {
        // GET: Classifier
        public ActionResult Index()
        {
            using (var db = new ChatbotDatabaseDataContext())
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
            using (var db = new ChatbotDatabaseDataContext())
            {
                var items = (from cm in db.ClassifiedMessages
                             join l in db.LogMessages on cm.MessageId equals l.Id
                             join c in db.Categories on cm.CategoryId equals c.Id
                             select new DetailedClassifiedMessage()
                             {
                                 MessageId = l.Id,
                                 Message = l.Message,
                                 CategoryId = c.Id,
                                 CategoryName = c.CategoryName
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
        
        public ActionResult Classify(string MessageID, string CategoryID, string Mode)
        {
            int mid = Convert.ToInt32(MessageID);
            int cid = Convert.ToInt32(CategoryID);
            var mode = (ClassificationMode)Enum.Parse(typeof(ClassificationMode), Mode);

            using (var db = new ChatbotDatabaseDataContext())
            {
                // Save or update to the classified
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);
                var citem = db.Categories.SingleOrDefault(c => c.Id == cid);

                if (mitem != null && citem != null)
                {
                    // Check if the item exists
                    var cl = db.ClassifiedMessages.SingleOrDefault(c => c.MessageId == mid);

                    if (cl != null)
                    {
                        // Already exists -- set to the new category                        
                        cl.CategoryId = cid;
                        cl.DateModified = DateTime.Now;
                    }
                    else
                    {
                        // Add a new one
                        db.ClassifiedMessages.InsertOnSubmit(new ClassifiedMessage { CategoryId = citem.Id, MessageId = mitem.Id, DateModified = DateTime.Now });
                    }

                    //Update the message status
                    mitem.Status = (short)MessageStatus.Done;
                    mitem.DateModified = DateTime.Now;

                    db.SubmitChanges();
                }
                
                return View("Classify", GetNextItem(mode, db, mid));
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

            using (var db = new ChatbotDatabaseDataContext())
            {
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);

                if (mitem != null)
                {
                    // Update status and move next
                    mitem.Status = (short)MessageStatus.Skipped;
                    mitem.DateModified = DateTime.Now;
                }

                db.SubmitChanges();

                return View("Classify", GetNextItem(mode, db, mid));
            }
        }

        public ActionResult Discard(string messageId, ClassificationMode mode)
        {
            int mid = Convert.ToInt32(messageId);

            using (var db = new ChatbotDatabaseDataContext())
            {
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);

                if (mitem != null)
                {
                    // Update status and move next
                    mitem.Status = (short)MessageStatus.Discarded;
                    mitem.DateModified = DateTime.Now;
                }

                db.SubmitChanges();

                return View("Classify", GetNextItem(mode, db, mid));
            }
        }

        public ActionResult Next(string messageId, ClassificationMode mode)
        {
            int mid = Convert.ToInt32(messageId);

            using (var db = new ChatbotDatabaseDataContext())
            {
                var mitem = db.LogMessages.SingleOrDefault(l => l.Id == mid);

                //if (mitem != null)
                //{
                //    // Update status and move next
                //    mitem.Status = (short)MessageStatus.Skipped;
                //    mitem.DateModified = DateTime.Now;
                //}

                //db.SubmitChanges();

                return View("Classify", GetNextItem(mode, db, mid));
            }
        }

        // GET: Classifier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        private ClassifyViewModel GetNextItem(ClassificationMode mode, ChatbotDatabaseDataContext db, int currentId)
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

                return new ClassifyViewModel() { MessageId = firstitem.Id, Mode = mode, Message = firstitem.Message, Categories = db.Categories.ToList(), RelatedMessages = related };
            }
            finally
            {
                firstitem = null;
            }
        }
    }
}
