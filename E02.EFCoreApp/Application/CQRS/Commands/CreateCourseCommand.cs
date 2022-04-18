using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class CreateCourseCommand : IRequest
    {
        public string Title { get; set; } = string.Empty;
        public int TeacherId { get; set; }
    }
}
