using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Subject(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
