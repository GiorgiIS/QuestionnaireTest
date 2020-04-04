using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionnaire.Logic.Database;
using Questionnaire.Logic.Entities;
using Questionnaire.Logic.Models;
using Questionnaire.Models;

namespace Questionnaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuestionnaireDbContext _context;

        public HomeController(ILogger<HomeController> logger, QuestionnaireDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var questions = _context.Questions.ToList();
            var answers = _context.Answers.ToList();

            return View(new Tuple<List<Question>, List<Answer>>(questions, answers));
        }

        [HttpPost]
        public IActionResult Index([FromBody]List<QuestionAnswerModel> model)
        {
            var questions = _context.Questions.ToList();
            var answers = _context.Answers.ToList();

            var questionAnswers = model
                    .Select(c => new QuestionAnswer { QuestionId = int.Parse(c.QuestionId), AnswerId = answers.First(x => x.Text == c.Answer).Id })
                    .ToList();

            var questionnaire = new Logic.Entities.Questionnaire()
            {
                QuestionAnswers = questionAnswers
            };

            _context.Questionnaires.Add(questionnaire);
            _context.SaveChanges();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
