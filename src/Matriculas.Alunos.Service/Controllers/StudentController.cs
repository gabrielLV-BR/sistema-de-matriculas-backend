using Microsoft.AspNetCore.Mvc;

namespace Matriculas.Usuarios.Service.Controllers;

[ApiController]
[Route("aluno")]
public class StudentController : ControllerBase
{

    readonly StudentContext StudentContext;

    public StudentController(StudentContext studentContext)
    {
        StudentContext = studentContext;
    }

    [HttpGet(Name = "GetStudents")]
    public IEnumerable<Student> Get()
    {
        return StudentContext.Students.AsEnumerable();
    }
}
