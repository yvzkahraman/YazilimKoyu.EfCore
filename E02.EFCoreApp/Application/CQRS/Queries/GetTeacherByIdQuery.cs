using E02.EFCoreApp.Application.Dtos;
using MediatR;

namespace E02.EFCoreApp.Application.CQRS.Queries
{
    public class GetTeacherByIdQuery : IRequest<TeacherDto?>
    {
        public int Id { get; set; }

        public GetTeacherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
