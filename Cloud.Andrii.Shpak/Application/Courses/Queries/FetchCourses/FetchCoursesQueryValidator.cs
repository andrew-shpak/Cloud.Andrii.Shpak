using FluentValidation;

namespace Cloud.Andrii.Shpak.Application.Courses.Queries.FetchCourses;

public class FetchCoursesQueryValidator : AbstractValidator<FetchCoursesQuery>
{
    public FetchCoursesQueryValidator()
    {
    }
}