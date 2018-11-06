using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrades = 0;

            //maxvalue is the largest possible variable you can fit into that of a type
            //float variable
            LowestGrades = float.MaxValue;
        }

        public float AverageGrades;
        public float HighestGrades;
        public float LowestGrades;
    }
}
