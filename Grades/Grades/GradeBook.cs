using System;
using System.Collections.Generic;
using System.IO;
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
            //intialize a text for the name
            _name = "Empty";
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
            foreach (float grade in grades)
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

        internal void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }


                if (_name != value && NameChanged != null)
                {

                    //generating an instance of name changed event args
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

            }
        }

        //can now create a public field with the name type
        public event NameChangedDelegate NameChanged;

        private string _name;
        private List<float> grades;
    }
}
