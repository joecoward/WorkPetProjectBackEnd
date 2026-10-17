using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Domain.Aggregates
{
    public record TimeSlot
    {
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }

        public TimeSlot(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Start time must be earlier than end time.");

            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
