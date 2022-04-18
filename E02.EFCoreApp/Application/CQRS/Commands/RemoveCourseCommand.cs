using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class RemoveCourseCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCourseCommand(int id)
        {
            Id = id;
        }
    }
}
