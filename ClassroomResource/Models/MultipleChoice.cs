﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassroomResource.Models
{
    public class MultipleChoice: Answer
    {
        public Dictionary<bool,string> Answers { get; set; }
    }
}