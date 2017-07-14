using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogMessageClassifier.Models.ViewModels
{
    public class ClassifyViewModel
    {
        public int MessageID { get; set; }
        public string Message { get; set; }
        public ClassificationMode Mode { get; set; }
        public List<Category> Categories { get; set; }
    }
}