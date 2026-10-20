using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Application.Lessons.Commands.CreateLesson;
using Timetable.Domain.Aggregates;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Groups.Commands.CreateGroup
{

    public record CreateGroupCommand( string Name) : IRequest<Guid>;

    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
    {
        private readonly IGroupRepository _groupRepository;

        public CreateGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group(
                Guid.NewGuid(),
                request.Name);

            await _groupRepository.AddAsync(group, cancellationToken);

            return group.Id;
        }
    }



}
