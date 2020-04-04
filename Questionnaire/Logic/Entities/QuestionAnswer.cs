using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Logic.Entities
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public int? QuestionId { get; set; }
        public Answer Answer{ get; set; }
        public int? AnswerId { get; set; }
    }
}
