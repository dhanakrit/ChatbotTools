using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogMessageClassifier.Models
{
    public enum MessageStatus
    {
        New,
        Done,
        Skipped,
        Discarded
    }

    public enum ClassificationMode
    {
        All_New_Items = 0,
        Skipped_Items = 2,
        Edit = 5
    }
    public class Classification
    {
        
    }
}