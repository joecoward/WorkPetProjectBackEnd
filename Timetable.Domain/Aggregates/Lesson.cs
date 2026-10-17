using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Domain.Aggregates
{
    public class Lesson
    {
        public Guid Id { get; private set; }
        public Guid SubjectId { get; private set; }
        public Guid TeacherId { get; private set; }
        public Guid GroupId { get; private set; }
        public Guid ClassroomId { get; private set; }

        public DateOnly Date { get; private set; }
        public TimeSlot Time { get; private set; }

        protected Lesson() { }

        public Lesson(Guid id, Guid subjectId, Guid teacherId, Guid groupId, Guid classroomId, DateOnly date, TimeSlot time)
        {
            Id = id;
            SubjectId = subjectId;
            TeacherId = teacherId;
            GroupId = groupId;
            ClassroomId = classroomId;
            Date = date;
            Time = time;
        }

        public void Reschedule(DateOnly newDate, TimeSlot newTime)
        {
            if (newDate < DateOnly.FromDateTime(DateTime.UtcNow))
                throw new InvalidOperationException("You can't change lesson to the previous date.");

            Date = newDate;
            Time = newTime;
        }
    }
}
