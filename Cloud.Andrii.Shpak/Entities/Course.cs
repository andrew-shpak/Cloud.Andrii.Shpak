using System.Text.Json;
using MongoDB.Entities;

namespace Cloud.Andrii.Shpak.Entities;

[Collection("courses")]
public class Course : Entity, ICreatedOn, IModifiedOn
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Code { get; set; }
    public IEnumerable<string> Teachers { get; set; }
    public Dictionary<string,string> Teacher { get; set; }
    public JsonElement Element { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
// .....
// teacher: {
// "name:"1",
// "lastName:"2"
// }