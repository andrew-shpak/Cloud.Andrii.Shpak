using Cloud.Andrii.Shpak.Application.Courses.Queries.FetchCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Andrii.Shpak.Controllers;

internal static class CoursesController
{
    
    public static void AddCourses(this WebApplication application)
    {
        application.MapGet("/courses", ([FromQuery] string? query, IMediator mediatr, CancellationToken cancellationToken) =>
            Results.Ok(mediatr.Send(new FetchCoursesQuery
        {
            Query = query
        }, cancellationToken)));
    }
}