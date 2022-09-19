using System;

public class Class1
{
	public Class1()
	{
	}
}

//POst -> /api/Cursuri    -> Response DTO CURS {Id ,Curs name}
{
CursName: Matematica speciala
}

// POSt => /api/Students   {FirstName,Lastname,Email } =>{Id,FirstName,Lastname,Email }

//POST => /api/StudentCurst   {StudentId, CursId} => {StudentId, CursId}

DTO Student Caz 2

{
	FirstName: "Ion", LastName: "Gigel" , Email: "ion.gigel@stefanini.com",
	Cursuri: [1,5,6] -> Id uri de cursuri; ;
}


//POst /api/student primeste acest DTO Student DTO caz2


DAO->DAO.Student { Id,FIrstName,LastName,Email}
+Navigation Properties->DAO StudentCurs prop name StudentCursuri->HasSet<DAO.StudentCurs>
    -> DAO.StudentCurs {StudentId, CursId}

IStudentDataService->
public DTO.Student Insert(DTO.Student item)
{
	DAO Student student = _mapper.Map<DAO.Student>(item);
	foreach (int cursId in item.Cursuri)
	{
		DAO.StudentCurs sc = new DAO.StudentCurs
		{
			CursId = cursId;
	}
	student.StudentCursuri.add(sc);
}

_db.Students.Add(student);
_db.SaveChanges();

}


cazul 3 : Alt exemplu de DTO
StudentDTO {
 public string FirstName { get; set; }
public string LastName { }
public string Email { }
public IEnumerable<DTO.StudentCurs> Cursuri { get; set}
	
}

DTO.StudentCurs
{
 public int StudentId { get; set; }
public int CursId { get; set; }
}

FE -=>
{
firstName: "ion",lastName: "Gigel",email: "blabla email valid", cursuri: [{ CursId: 1},{ CursId: 2}]
}


Autommaper Profile pt Student
StudentProfile : Profile
{
	public StudentProfile()
	{
		CreateMap<DTO.Student, DAO.Student>()
			.ForMember(dst => dst.StudentCursuri(navigationProp), map => map.MapFrom(src => src.Cursuri)
					DAO.StudentCurs                                          DTO.StudentCurs
	}
}

StudentCursProfile: Profile{
	public StudentCursProfile()
	{
		CreateMap<DTO.StudentCurs, DAO.StudentCursuri>
	}
}


public DTO.Student Insert(DTO.Student item)
{
	DAO Student student = _mapper.Map<DAO.Student>(item);
	_db.Students.Add(student);
	_db.SaveChanges();
}



public DTO.Student Update(DTOStudent item)
{
	var student = _db.Students.Include(x => x.StudentCursuri).SingleOrDefault(x => x.Id == item.Id);
	var listaCursId = item.Cursuri.Select(x => x.CursId);
	var cursuriToBeRemoved = student.StudentCursuri.Where(x => !listaCursId.Contains(x.CursId));
	foreach (var curs in cursuriToBeRemoved)
	{
		student.StudentCursuri.Remove(curs);
	}
	_mapper.Map(item, student);
	_db.Students.Update(student);
	_db.saveChanges();
	ionUP,gigelUp,mailUP...
StudentCursuri->IEnumerable<DAO.StudentCurs>() => { 1,1}
	{ 1,2}
	{ 1,4}


}