public class School
{
    public int Id { get; set; }
    public string Name { get; set; }

    public SchoolDTO AsDTO() => new(Name);
}