using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassroomResource.Data.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public int QuestionId { get; set; }
        public int SubjectId { get; set; }
    }
}