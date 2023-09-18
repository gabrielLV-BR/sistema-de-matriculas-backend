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

    [HttpGet(Name = "ListStudents")]
    public IEnumerable<StudentDTO> Get()
    {
        return StudentContext.Students
            .AsEnumerable()
            .Select(x => x.AsDTO());
    }

    [HttpGet("{id}", Name = "GetStudent")]
    public ActionResult<StudentDTO> GetStudent(int id)
    {
        var student = from s in StudentContext.Students
                      where s.Id == id
                      select s.AsDTO();

        return (student is not null) ? Ok(student) : new NotFoundResult();
    }

    [HttpPost(Name = "CreateStudent")]
    public ActionResult<CreateStudentDTO> Create([FromBody] CreateStudentDTO student)
    {
        var s = new Student
        {
            Name = student.Name
        };

        StudentContext.Students.Add(s);
        StudentContext.SaveChanges();

        return CreatedAtAction(nameof(Create), s);
    }

    [HttpPut("{id}", Name = "UpdateStudent")]
    public IActionResult Put(int id, [FromBody] UpdateStudentDTO student) {
        var foundStudent = StudentContext.Students.Find(id);

        if(foundStudent is not null) {
            foundStudent.Name = student.Name;
            StudentContext.SaveChanges();
        }

        return Ok(foundStudent);
    }

    [HttpDelete("{id}", Name = "DeleteStudent")]
    public IActionResult Delete(int id)
    {
        var student = StudentContext.Students.Find(id);

        if(student is not null) {
            StudentContext.Students.Remove(student);
            StudentContext.SaveChanges();
        }

        return NoContent();
    }
}
