using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrades = 0;

            //maxvalue is the largest possible variable you can fit into that of a type
            //float variable
            LowestGrades = float.MaxValue;
        }

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Work Harder";
                        break;
                    case "D":
                        result = "you need to work even harder";
                        break;
                    default:
                        result = "Come On I know you have more in you";
                        break;
                    
                }
                return result;
            }
        }

        public string LetterGrade
        {
            get
            {
                string result;
                if (AverageGrades >= 90)
                {
                    result = "A";
                }
                else if (AverageGrades >= 80)
                {
                    result =  "B";
                }
                else if (AverageGrades >= 70)
                {
                    result = "C";
                }
                else if (AverageGrades >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }

        public float AverageGrades;
        public float HighestGrades;
        public float LowestGrades;
    }
}
