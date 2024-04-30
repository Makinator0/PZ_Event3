using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_Event3
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public int RoomNumber { get; set; }

        public Student(string name, int grade, int roomNumber)
        {
            Name = name;
            Grade = grade;
            RoomNumber = roomNumber;
        }
    }
}
