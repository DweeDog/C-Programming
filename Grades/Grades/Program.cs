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
            IGradeTracker book = CreateThrowAwayGradeBook();
            //GetBookName(book);

            //have to make sure that floating point numbers have the f keyword at the end  
            AddGrades(book);
            WriteResults(book);

            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //streams tend to buffer what you may have written previously so if you do not buffer the stream or close the stream there is a chance
                //that the buffer may overflow and be full thus that what you have chosen to written to the sream might not write into the file
                outputFile.Close();
            }


        }

        private static GradeBook CreateThrowAwayGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker stats)
        {
            GradeStatistics book = stats.ComputeStatistics();

            foreach (float grade in stats)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", book.AverageGrades);
            WriteResult("Highest", book.HighestGrades);
            WriteResult("Lowest", book.LowestGrades);
            WriteResult(book.Description, book.LetterGrade);

        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
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

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result: F2}");
        }

    }
}
