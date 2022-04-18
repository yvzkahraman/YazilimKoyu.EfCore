using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Commands
{
    public class UpdateCourseCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int TeacherId { get; set; }
    }
}
