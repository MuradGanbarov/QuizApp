using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizConsoleApp.Models
{
    public class Question
    {
        public int quiestionIdCounter = 1;
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Variants { get; set; } = new List<string>();
        public int CorrectVariant { get; set; }

        public Question()
        {
            Id = quiestionIdCounter++;
        }
    }
}
