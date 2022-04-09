using MongoDB.Entities;

namespace Cloud.Andrii.Shpak.Entities;

public class Course : Entity, ICreatedOn, IModifiedOn
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Code { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}