using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Logic.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
