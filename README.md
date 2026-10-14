sequenceDiagram
    autonumber
    actor User as Студент / Диспетчер
    participant FE as Frontend (SPA)
    participant API as Web API (Controllers / Endpoints)
    participant Med as MediatR (Pipeline & Handlers)
    participant Repo as Dapper / SQLite
    participant DB as SQLite Database

    Note over User, FE: Сценарій 1: Перегляд розкладу (Query)
    User->>FE: Обирає групу "КН-21" та тиждень
    FE->>API: GET /api/v1/schedules/group/КН-21?week=2
    API->>Med: Send(new GetGroupScheduleQuery(groupId, week))
    Med->>Repo: Виконання оптимізованого SQL SELECT через Dapper
    Repo->>DB: Query<ScheduleItemDto>(SQL)
    DB-->>Repo: Результат рядків
    Repo-->>Med: Список DTO
    Med-->>API: 200 OK (ScheduleResponse)
    API-->>FE: JSON з розкладом
    FE-->>User: Рендеринг сітки розкладу

    Note over User, FE: Сценарій 2: Створення пари (Command)
    User->>FE: Заповнює форму "Додати пару"
    FE->>API: POST /api/v1/lessons (CreateLessonDto)
    API->>Med: Send(new CreateLessonCommand(...))
    activate Med
    Med->>Med: ValidationBehavior (FluentValidation)
    Med->>Repo: Перевірка колізій (чи вільний викладач і аудиторія?)
    Repo->>DB: SELECT COUNT(1) WHERE ...
    DB-->>Repo: 0 (вільно)
    Med->>Repo: ILessonRepository.AddAsync(lessonAggregate)
    Repo->>DB: INSERT INTO Lessons (...)
    DB-->>Repo: Id створеного запису
    Med-->>API: Result.Success(lessonId)
    deactivate Med
    API-->>FE: 201 Created { id: "guid" }
    FE-->>User: Повідомлення про успіх та оновлення сітки
