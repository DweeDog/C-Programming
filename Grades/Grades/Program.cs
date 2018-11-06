using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            GradeBook book = new GradeBook();

            //have to make sure that floating point numbers have the f keyword at the end  
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            //cw with tab twice gives you a console write line
            Console.WriteLine(stats.AverageGrades);
            Console.WriteLine(stats.HighestGrades);
            Console.WriteLine(stats.LowestGrades);
        }
    }
}
