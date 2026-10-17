```text
TimetableSolution/
└── src/
    ├── Timetable.Domain/
    │   ├── Entities/           # Teacher, Group, Classroom, Subject
    │   ├── Aggregates/         # Lesson, TimeSlot
    │   └── IRepositories/      # ILessonRepository, IGroupRepository
    ├── Timetable.Application/
    │   ├── Common/             # Interfaces, Mappings, Mediator
    │   ├── Lessons/
    │   │   ├── Commands/CreateLesson/ # Creat, Update, Delete
    │   │   └── Queries/GetGroupSchedule/ # Read
    │   └── DependencyInjection.cs
    ├── Timetable.Infrastructure/
    │   ├── Database/           # SqliteConnectionContext, Migrations
    │   ├── Repositories/       # LessonRepository
    │   └── DependencyInjection.cs
    └── Timetable.Web.Api/
        ├── Controllers/        # SchedulesController, LessonsController
        ├── Middlewares/        # ExceptionHandlingMiddleware
        ├── appsettings.json    # ConnectionStrings
        └── Program.cs

```

BaseEntity example:

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAtUtc { get; protected set; } = DateTime.UtcNow;

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity other) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}

ValueObject example:

//Value Object зазвичай достатньо використати record:

    public record TimeSlot(int LessonNumber, TimeSpan StartTime, TimeSpan EndTime);

Схема руху даних

1. Клік користувача на сторінці «Зберегти пару»

2. Angular: API-сервіс летить HTTP-запит

3. Web API Контролер хендлить 

4. MediatR та валідатор

5. (Domain) перевіряються головні правила університету: чи вільна ця аудиторія, чи немає у викладача іншої пари в цей час ...

6. Запис в базу повертає id або статус і він летить на верх 

