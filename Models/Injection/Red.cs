using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeMVCExam.Models.Injection
{
    public class Red : IColor
    {
        public string getColor()
        {
            return "THIS IS THE COLOR RED ITS BURNING HOT. LOOOOOK OUT!";
        }
    }
}