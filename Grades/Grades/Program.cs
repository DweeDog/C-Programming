using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //GradeBook g1 = new GradeBook();
            //GradeBook g2 = g1;

            //g1.Name = "Dweep's Grade Book";
            //Console.WriteLine(g1.Name);


            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("");

            GradeBook book = new GradeBook();
            GetBookName(book);

            //have to make sure that floating point numbers have the f keyword at the end  
            AddGrades(book);

            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //streams tend to buffer what you may have written previously so if you do not buffer the stream or close the stream there is a chance
                //that the buffer may overflow and be full thus that what you have chosen to written to the sream might not write into the file
                outputFile.Close();
            }

            GradeStatistics stats = book.ComputeStatistics();
            WriteResults(stats);
        }

        private static void WriteResults(GradeStatistics stats)
        {
            //cw with tab twice gives you a console write line
            WriteResult("Highest", (int)stats.HighestGrades);
            WriteResult("Grade", stats.LetterGrade);

            //to generate a floating point number get {}
            Console.WriteLine(stats.LowestGrades);
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{description}: {result: F2}");
        }

    }
}
