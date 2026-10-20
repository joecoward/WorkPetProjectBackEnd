using MediatR;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Groups.Commands.DeleteLesson
{
    public record DeleteGroupCommand(Guid GroupId) : IRequest;

    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
    {
        private readonly IGroupRepository _groupRepository;

        public DeleteGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetByIdAsync(request.GroupId, cancellationToken);

            if (group == null)
                throw new Exception($"Id {request.GroupId} not found.");

            await _groupRepository.DeleteAsync(group, cancellationToken);
        }
    }


}
