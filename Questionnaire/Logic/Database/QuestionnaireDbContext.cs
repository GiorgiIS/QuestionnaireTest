using Microsoft.EntityFrameworkCore;
using Questionnaire.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Logic.Database
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Questionnaire.Logic.Entities.Questionnaire> Questionnaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData(
             new List<Answer> {
               new Answer{Id = 1, Text = "Yes", Score = 2},
               new Answer{Id = 2, Text = "Sometimes", Score = 1},
               new Answer{Id = 3, Text = "No", Score = 0}
             });

            modelBuilder.Entity<Question>().HasData(
                new List<Question> {
                    new Question {
                   Id = 2,
                   Text = "If you see this question you have answered fist question yes",
                   IsMainQuestion = false,
               },
                    new Question {
                   Id = 1,
                   Text = "If you answer this question yes, you will get question 2",
                   NextQuestionConditionId = 1,
                   NextQuestionId = 2,
                   IsMainQuestion = true,
               },
                    new Question {
                   Id = 3,
                   Text = "This is just 3th question",
                   IsMainQuestion = true,
               }

                });
        }
    }
}