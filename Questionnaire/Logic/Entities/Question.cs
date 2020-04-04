using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Logic.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        public Answer NextQuestionCondition { get; set; }
        public int? NextQuestionConditionId { get; set; }
        
        public Question NextQuestion { get; set; }
        public int? NextQuestionId { get; set; }

        public bool IsMainQuestion { get; set; }
    }
}
