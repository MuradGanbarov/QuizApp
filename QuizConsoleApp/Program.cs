using QuizConsoleApp;
using QuizConsoleApp.Models;
using System;
using System.Collections.Generic;
class Program
{
    static List<Quiz> quizzes = new List<Quiz>();
    static void Main(string[] args)
    {

        

        string choice = "";

        while (choice != "0")
        {
            Console.WriteLine("[1] Create new quiz\n[2] Solve a quiz\n[3] Show quizzes\n[0] Quit");
            choice = Console.ReadLine();
            switch (choice)
            {
                
                case "1":
                    try
                    {
                        CreateQuiz(); ;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Wrong input. Please try again. {ex.Message}");
                    }
                    
                    break;

                case "2":
                    try
                    {   
                        SolveQuiz();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Wrong input. Please try again. {ex.Message}");
                    }
                    
                    break;

                case "3":
                    ShowQuizzes();
                    break;

                default:
                    Console.WriteLine("Wrong input. Please try again.");
                    break;
            }
        }

        static void CreateQuiz()
        {
            Quiz quiz = new Quiz();
            Console.WriteLine("Enter the name of the quiz:");
            quiz.Name = Console.ReadLine();
            Console.WriteLine("Enter the number of questions: ");
            int numQuestions = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numQuestions; i++)
            {
                Question question = new Question();
                Console.WriteLine("Enter the question: ");
                question.Text = Console.ReadLine();
                //question.Variants  = new List<string>();
                for (int j = 1; j <= 4; j++)
                {
                    Console.WriteLine($"Enter the option {j}");
                    question.Variants.Add(Console.ReadLine());
                }

                Console.WriteLine("Enter the correct option (1-4)");
                question.CorrectVariant = int.Parse(Console.ReadLine());
                quiz.Questions.Add(question);
            }
            quizzes.Add(quiz);
            quiz.Id = quizzes.Count + 1;
            Console.WriteLine("Quiz created successfully");
            
        }



        static void ShowQuizzes()
        {
            Quiz quiz = new Quiz();

            if (quizzes.Count == 0)
            {
                Console.WriteLine("No quizzes available");
            }

            else
            {
                Console.WriteLine("Available quizzes:");
                foreach (var item in quizzes)
                {
                    Console.WriteLine($"ID:{item.Id}, Name:{item.Name}");
                }
            }
        }



        void SolveQuiz()
        {
            Console.WriteLine("Solve a quiz:");
            ShowQuizzes();
            Console.WriteLine("Enter the ID of the quiz you want to solve: ");
            int quizId = int.Parse(Console.ReadLine());

            Quiz choosenQuiz = quizzes.Find(quiz => quiz.Id == quizId);

            if (choosenQuiz != null)
            {
                int score = 0;
                foreach (var question in choosenQuiz.Questions)
                {
                    Console.WriteLine(question.Text);
                    for (int i = 0; i < question.Variants.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Variants[i]}");
                    }

                    Console.WriteLine("Your answer (1-4): ");

                    int selectedanswer = int.Parse(Console.ReadLine());

                    if (selectedanswer == question.CorrectVariant)
                    {
                        score++;
                    }
                }

                Console.WriteLine($"Your score: {score}/{choosenQuiz.Questions.Count}");
            }


            else
            {
                Console.WriteLine("Quiz has not found with this ID");
            }

        }



    }
}
