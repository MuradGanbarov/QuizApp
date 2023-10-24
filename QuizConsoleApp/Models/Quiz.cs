using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizConsoleApp.Models
{
    public class Quiz
    {
        public int quizIdCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        
        public Quiz()
        {
            Id = quizIdCounter++;
            Questions = new List<Question>();
        }

    }

}





























