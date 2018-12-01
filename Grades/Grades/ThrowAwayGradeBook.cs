using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {

        public GradeStatistics ComputeStatistics()
        {

            Console.WriteLine("ThrowAwayGradeBook:ComputeStatistics");

            float lowest = float.MaxValue;

            foreach(float grade in Grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            Grades.Remove(lowest);

            //this allows you to reference the object that you are currently inside of therefore allowing you to access those particular methods
            //base allows you to reach specific methods from a class that has been inherited from
            return base.ComputeStatistics();
        }
    }
}
