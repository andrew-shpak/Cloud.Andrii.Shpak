using Cloud.Andrii.Shpak.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cloud.Andrii.Shpak.Application.Courses.Queries.FetchCourses;

public class FetchCoursesQueryHandler : IRequestHandler<FetchCoursesQuery,IEnumerable<Record>>
{
    private readonly DBContext _context;

    public FetchCoursesQueryHandler(DBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Record>> Handle(FetchCoursesQuery request, CancellationToken cancellationToken)
    {
        
        var entities = await _context.Find<Course>()
            .ExecuteAsync(cancellationToken);

        return entities.Select(f => new Record(f.Name));
    }
}
public record Record(string Name);