using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogMessageClassifier.Models.ViewModels
{
    public class ClassifyViewModel
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public ClassificationMode Mode { get; set; }
        public List<Category> Categories { get; set; }
        public List<LogMessage> RelatedMessages { get; set; }
    }

    public class ClassifyIndexViewModel
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<DetailedClassifiedMessage> Messages { get; set; }

        public List<SelectListItem> Modes { get; set; }
        public int CountNew { get; set; }
        public int CountDiscarded { get; set; }
        public int CountSkipped { get; set; }
        public int CountDone { get; set; }
    }

    public class DetailedClassifiedMessage
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}