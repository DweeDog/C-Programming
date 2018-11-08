using System;
using System.Collections.Generic;
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
            synth.Speak("Eugene is a Penis, Eugenis, EuPenis hahhahahha Bryan is a Penis Bryenis, BYPENIS");

            GradeBook book = new GradeBook();

            //have to make sure that floating point numbers have the f keyword at the end  
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            //cw with tab twice gives you a console write line
            WriteResult("Average", stats.AverageGrades);
            WriteResult("Highest", (int)stats.HighestGrades);

            //to generate a floating point number get {}
            Console.WriteLine(stats.LowestGrades);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

    }
}
