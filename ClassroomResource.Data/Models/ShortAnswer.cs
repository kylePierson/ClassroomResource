using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassroomResource.Data.Models
{
    public class ShortAnswer: Answer
    {
        public bool CaseSensitive { get; set; }
        public string Answer { get; set; }
    }
}