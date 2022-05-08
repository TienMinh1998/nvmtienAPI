using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Response
{
   public class QuestionResponse
    {
        public int Id { get; set; }
        public int Subject_Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int CountIt { get; set; }
    }
}
