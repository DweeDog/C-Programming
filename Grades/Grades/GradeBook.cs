using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        //ctor tab twice basically generates a constructor block

        public GradeBook()
        {
            grades = new List<float>();
        }


        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            // make a new instance of the object
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrades = 0;

            float sum = 0;
            foreach(float grade in grades)
            {

                //can use the maths components 
                stats.HighestGrades = Math.Max(grade, stats.HighestGrades);
                stats.LowestGrades = Math.Min(grade, stats.LowestGrades);

                //foreach works similar to a loop and basically computes all the grades
                //within each of the gradebooks
                sum += grade;
            }

            //Count tells you how many items are in that list
            stats.AverageGrades = sum / grades.Count;
            return stats;
        }


        public string Name;

        private List<float> grades;
    }
}
