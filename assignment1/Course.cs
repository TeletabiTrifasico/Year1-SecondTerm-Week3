using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Course
    {
        public string Name;
        public int TheoryGrade;
        public PracticalGrade PracticalGrade;

        public bool Passed()
        {
            if (TheoryGrade >= 55 && (int)PracticalGrade >= 3)
            {
                return true;
            }
            return false;
        }

        public bool CumLaude()
        {
            if (TheoryGrade >= 80 && (int)PracticalGrade == 4)
            {
                return true;
            }
            return false;
        }
    }
}
