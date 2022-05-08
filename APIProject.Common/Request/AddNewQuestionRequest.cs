using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Request
{
   public class AddNewQuestionRequest
    {
        public int IdSubject { get; set; }
        public string Cauhoi { get; set; }
        public string CauTraLoi { get; set; }
        public int UserId { get; set; }
    }
}
