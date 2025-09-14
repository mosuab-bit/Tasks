using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static Task7.Program;
using System.Runtime.Remoting.Contexts;

namespace Task7
{
    internal class Program
    {
        //        Implement a function that calculates how many mistakes a student made in an
        //exam.
        //You will receive:
        //• A List<StudentAnswerDto> containing QuestionId and AnswerId
        //submitted by the student.
        //• EF Core ExamQuestion entity with the correct answers.
        //• The AppDbContext that contains ExamQuestions.
        //Your task:
        //• Compare each student’s answer with the correct answer stored in DB.
        //• Count how many are wrong.
        //• Return the total mistakes as an int.
        //Provided Code
        //1. DTO for Student Answers
        //public class StudentAnswerDto
        //        {
        //            public int QuestionId { get; set; }
        //            public int AnswerId { get; set; }
        //        }
        //2. Exam Question Entity
        //public class ExamQuestion
        //        {
        //            public int Id { get; set; }
        //            public string QuestionText { get; set; }
        //            public int CorrectAnswerId { get; set; }
        //        }
        //3. AppDbContext
        //public class AppDbContext : DbContext
        //        {
        //            public DbSet<ExamQuestion> ExamQuestions { get; set; }

        
        public class StudentAnswerDto
        {
            public int QuestionId { get; set; }
            public int AnswerId { get; set; }
        }

        public class ExamQuestion
        {
            public int Id { get; set; }
            public string QuestionText { get; set; }
            public int CorrectAnswerId { get; set; }
        }

        public async Task<int> CalculateMistakesAsync(List<StudentAnswerDto> answers)
        {
            if (answers == null || !answers.Any())
                return 0;

            var questionIds = answers.Select(a => a.QuestionId).ToList();

            
            var examQuestions = await _context.ExamQuestions
                .Where(q => questionIds.Contains(q.Id))
                .ToListAsync();

            
            int mistakes = answers.Count(a =>
            {
                var question = examQuestions.FirstOrDefault(q => q.Id == a.QuestionId);
                return question != null && question.CorrectAnswerId != a.AnswerId;
            });

            return mistakes;
        }


        static void Main(string[] args)
        {
        }
    }
}
