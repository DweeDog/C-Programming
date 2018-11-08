using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrade(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrade(float[] grades)
        {
            grades[1] = 89.1f;
        }

        //how to uppercase a string
        [TestMethod]
        public void UpperCaseString()
        {

            string name = "Dweep";

            //value types are immutable and always remember to pass the values back
            //to the value types so that you make them equal the current value
            name = name.ToUpper();

            Assert.AreEqual("DWEEP", name);

        }



        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);


            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(ref  x);

            Assert.AreEqual(x, 46);
        }

        private void IncrementNumber(ref int number)
        {
            number = number + 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookName(ref book2);
            Assert.AreEqual("A GradeBook", book2);


        }

        private void GiveBookName( ref GradeBook book)
        {
            book.Name = "A Gradebook";
        }

        [TestMethod]
        public void StringEnumeration()
        {
            string name1 = "Dweep";
            string name2 = "Dweep";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);  
        }


        //testm code snippet and tap tab twice
        [TestMethod]
        public void IntVariablesGoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreEqual(x1, x2);
        }

        public void GradeBookVariableHoldAReferece()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Dweep's Grade Book";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }

    }
}
