using MediatR;

namespace Cloud.Andrii.Shpak.Application.Courses.Queries.FetchCourses;

public class FetchCoursesQuery : IRequest<IEnumerable<Record>>
{
    public string Query { get; set; }
}