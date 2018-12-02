using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {

        //ctor tab twice basically generates a constructor block

        public GradeBook()
        {
            //intialize a text for the name
            _name = "Empty";
            Grades = new List<float>();
        }

        public bool ThrowAwayLowest { get; set; }


        public override void AddGrade(float grade)
        {
            Grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {

            Console.WriteLine("GradeBook::ComputeStatistics");

            // make a new instance of the object
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrades = 0;

            float sum = 0;
            foreach (float grade in Grades)
            {

                //can use the maths components 
                stats.HighestGrades = Math.Max(grade, stats.HighestGrades);
                stats.LowestGrades = Math.Min(grade, stats.LowestGrades);

                //foreach works similar to a loop and basically computes all the grades
                //within each of the gradebooks
                sum += grade;
            }

            //Count tells you how many items are in that list
            stats.AverageGrades = sum / Grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = Grades.Count; i > 0; i--)
            {
                destination.WriteLine(Grades[i]);
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return Grades.GetEnumerator();
        }

        protected List<float> Grades;
    }
}
