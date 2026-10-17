using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Domain.Entities
{
    public class Classroom
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public Classroom(Guid id, string name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
