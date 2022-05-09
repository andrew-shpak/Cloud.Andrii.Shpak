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
        
        application.MapPost("/courses", ( FetchCoursesQuery command , IMediator mediatr, 
                CancellationToken cancellationToken) =>
            Results.Ok(mediatr.Send(command, cancellationToken)));
        
        
         application.MapPut("/courses/", (string id, IMediator mediatr, CancellationToken cancellationToken) =>
            Results.Ok( cancellationToken));
         
         application.MapDelete("/courses/{{id:guid}}", (Guid id, IMediator mediatr, CancellationToken cancellationToken) =>
         {
             if (id == Guid.Empty) return Results.NotFound();
             return Results.Ok(cancellationToken);
         });
    }
}
