using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Group(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
