using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class RemoveTeacherCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTeacherCommand(int id)
        {
            Id = id;
        }
    }
}
