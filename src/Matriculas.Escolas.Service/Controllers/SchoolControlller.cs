using Microsoft.AspNetCore.Mvc;

namespace Matriculas.Escolas.Service.Controllers;

[ApiController]
[Route("escola")]
public class SchoolController : ControllerBase
{
    private readonly SchoolContext Context;

    SchoolController(SchoolContext schoolContext)
    {
        Context = schoolContext;
    }

    [HttpGet(Name = "ListSchools")]
    public IEnumerable<SchoolDTO> Get()
    {
        return Context.Schools.AsEnumerable().Select(x => x.AsDTO());
    }

    [HttpGet("{id}", Name = "GetSchool")]
    public ActionResult<SchoolDTO> GetSchool(int id)
    {
        var school = from s in Context.Schools
                     where s.Id == id
                     select s.AsDTO();

        return (school is not null) ? Ok(school) : new NotFoundResult();
    }

    [HttpPost(Name = "CreateSchool")]
    public IActionResult Post(CreateSchoolDTO school)
    {
        var createdSchool = Context.Add(school);
        Context.SaveChanges();
        return CreatedAtAction(nameof(Post), createdSchool);
    }

    [HttpPut("{id}", Name = "UpdateSchool")]
    public IActionResult Put(int id, [FromBody] SchoolDTO school)
    {
        var foundSchool = Context.Schools.Find(id);

        if (foundSchool is null) return new NotFoundObjectResult(school);

        foundSchool.Name = school.Name;
        Context.SaveChanges();

        return Ok(foundSchool);
    }

    [HttpDelete("{id}", Name = "DeleteSchool")]
    public IActionResult Delete(int id)
    {
        var school = Context.Schools.Find(id);

        if (school is null) return new NotFoundResult();

        Context.Schools.Remove(school);
        Context.SaveChanges();

        return NoContent();
    }
}
