using MongoDB.Entities;

namespace Cloud.Andrii.Shpak.Entities;

[Collection("grades")]
public class Grade : Entity, ICreatedOn, IModifiedOn
{
    public double Value { get; set; }
    public string CourseId { get; set; } = default!;
    public string StudentId { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}