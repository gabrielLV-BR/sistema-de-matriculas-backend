using System.ComponentModel.DataAnnotations;

public record SchoolDTO([Required] string Name);
public record CreateSchoolDTO([Required] string Name);