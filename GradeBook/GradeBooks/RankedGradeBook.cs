using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("There are less then 5 students");
            }
            char grade = 'A';
            double betterStudents = 0;
            foreach (Student student in Students)
            {
                if (student.Grades.Average() > averageGrade)
                {
                    betterStudents++;
                }
            }
            while (betterStudents >= (Students.Count / 5))
            {
                grade++;
                betterStudents -= (Students.Count / 5);
            }
            return grade >= 'E' ? 'F' : grade;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
