using System;
using System.Collections.Generic;

namespace PZ_Event3
{
    [Serializable]
    public class Room
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Student> Students { get; set; }

        public Room(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Students = new List<Student>();
        }

        public bool AddStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return true;
            }
            return false;
        }
    }
}
