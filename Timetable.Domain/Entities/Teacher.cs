using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Teacher(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
