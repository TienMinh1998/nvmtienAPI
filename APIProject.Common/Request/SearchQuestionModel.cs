using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Request
{
   public class SearchQuestionModel
    {
        public int SubjectId { get; set; }
        public string SearchText { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int UserId { get; set; }
    }
}
