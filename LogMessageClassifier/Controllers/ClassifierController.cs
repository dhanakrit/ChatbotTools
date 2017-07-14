using LogMessageClassifier.Models;
using LogMessageClassifier.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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

                ViewBag.Modes = modes;
                ViewBag.CountNew = db.LogMessages.Count(m => m.Status == (short)MessageStatus.New).ToString("N0");
                ViewBag.CountSkipped = db.LogMessages.Count(m => m.Status == (short)MessageStatus.Skipped).ToString("N0");
                ViewBag.CountDone = db.LogMessages.Count(m => m.Status == (short)MessageStatus.Done).ToString("N0");
                ViewBag.CountDiscarded = db.LogMessages.Count(m => m.Status == (short)MessageStatus.Discarded).ToString("N0");

                return View();
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
                var mitem = db.LogMessages.SingleOrDefault(l => l.ID == mid);
                var citem = db.Categories.SingleOrDefault(c => c.ID == cid);

                if (mitem != null && citem != null)
                {
                    // Check if the item exists
                    var cl = db.ClassifiedMessages.SingleOrDefault(c => c.MessageID == mid);

                    if (cl != null)
                    {
                        // Already exists -- set to the new category                        
                        cl.CategoryID = cid;
                        cl.DateModified = DateTime.Now;
                    }
                    else
                    {
                        // Add a new one
                        db.ClassifiedMessages.InsertOnSubmit(new ClassifiedMessage { CategoryID = citem.ID, MessageID = mitem.ID, DateModified = DateTime.Now });
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
                var mitem = db.LogMessages.SingleOrDefault(l => l.ID == mid);

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
                var mitem = db.LogMessages.SingleOrDefault(l => l.ID == mid);

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
                var mitem = db.LogMessages.SingleOrDefault(l => l.ID == mid);

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

        private ClassifyViewModel GetNextItem(ClassificationMode mode, ChatbotDatabaseDataContext context, int currentId)
        {
            var firstitem = context.LogMessages.OrderBy(m => m.ID).FirstOrDefault(m => m.Status == (short)mode);

            try
            {
                if(firstitem != null)
                {
                    var newitem = context.LogMessages.OrderBy(m => m.ID).FirstOrDefault(m => m.Status == (short)mode && m.ID > currentId);

                    if(newitem != null)
                    {
                        firstitem = newitem;
                    }
                }

                if(firstitem == null)
                {
                    firstitem = new LogMessage() { ID = 0, Message = string.Empty };
                }

                return new ClassifyViewModel() { MessageID = firstitem.ID, Mode = mode, Message = firstitem.Message, Categories = context.Categories.ToList() };
            }
            finally
            {
                firstitem = null;
            }
        }
    }
}
