using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeMVCExam.Models.Injection
{
    public class Blue : IColor
    {
        public string getColor()
        {
            return "THIS IS THE COLOR BLUE! ITS AWESOME!";
        }
    }
}