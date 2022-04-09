using MongoDB.Entities;

namespace Cloud.Andrii.Shpak.Entities;

public class Student : Entity, ICreatedOn, IModifiedOn
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string UserFullName => $"{LastName} {Name} {MiddleName}";
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}