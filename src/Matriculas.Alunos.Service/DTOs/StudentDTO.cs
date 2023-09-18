using System.ComponentModel.DataAnnotations;

public record StudentDTO(string Name);
public record CreateStudentDTO([Required] string Name);
public record UpdateStudentDTO([Required] string Name);