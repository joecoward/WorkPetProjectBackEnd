using MediatR;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Subjects.Commands.CreateSubject;

public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Guid>
{
    private readonly ISubjectRepository _subjectRepository;

    public CreateSubjectCommandHandler(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = new Subject(
            Guid.NewGuid(),
            request.Name);

        await _subjectRepository.AddAsync(subject, cancellationToken);

        return subject.Id;
    }
}