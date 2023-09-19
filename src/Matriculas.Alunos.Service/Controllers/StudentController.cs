using Microsoft.AspNetCore.Mvc;

namespace Matriculas.Usuarios.Service.Controllers;

[ApiController]
[Route("aluno")]
public class StudentController : ControllerBase
{

    readonly StudentContext Context;

    public StudentController(StudentContext studentContext)
    {
        Context = studentContext;
    }

    [HttpGet(Name = "ListStudents")]
    public IEnumerable<StudentDTO> Get()
    {
        return Context.Students
            .AsEnumerable()
            .Select(x => x.AsDTO());
    }

    [HttpGet("{id}", Name = "GetStudent")]
    public ActionResult<StudentDTO> GetStudent(int id)
    {
        var student = Context.Students.Find(id);

        return (student is not null) ? Ok(student) : new NotFoundResult();
    }

    [HttpPost(Name = "CreateStudent")]
    public ActionResult<CreateStudentDTO> Create([FromBody] CreateStudentDTO student)
    {
        var s = new Student
        {
            Name = student.Name
        };

        Context.Students.Add(s);
        Context.SaveChanges();

        return CreatedAtAction(nameof(Create), s);
    }

    [HttpPut("{id}", Name = "UpdateStudent")]
    public IActionResult Put(int id, [FromBody] StudentDTO student)
    {
        var foundStudent = Context.Students.Find(id);

        if (foundStudent is null) return new NotFoundResult();

        foundStudent.Name = student.Name;
        Context.SaveChanges();

        return Ok(foundStudent);
    }

    [HttpDelete("{id}", Name = "DeleteStudent")]
    public IActionResult Delete(int id)
    {
        var student = Context.Students.Find(id);

        if (student is null) return new NotFoundResult();

        Context.Students.Remove(student);
        Context.SaveChanges();

        return NoContent();
    }
}
