using Api_D01.Models;
using API_D01_D02.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api_D01.Service
{
    public class StudentRepo : IStudentRepo
    {
        ApiDbContext db;

        public StudentRepo(ApiDbContext db)
        {
            this.db = db;
        }

        public List<StudentWithHisDept> GetAll()
        {
            var stds =  db.Students.Include(s => s.Dept). ToList();
            List <StudentWithHisDept> stdDtos = new List<StudentWithHisDept>();

            foreach (var std in stds)
            {
                StudentWithHisDept stdDTO = new StudentWithHisDept();
                stdDTO.Std_No = std.id;
                stdDTO.Std_Name = std.name;
                stdDTO.Std_Age = std.age;
                stdDTO.Std_Address = std.address;
                stdDTO.Std_Image = std.image;
                
                DepartmentDTO departmentDTO = new DepartmentDTO();

                departmentDTO.depat_No = std.Dept.id;
                departmentDTO.depat_Name = std.Dept.name;
                departmentDTO.depat_Loaction = std.Dept.Loaction;

                stdDTO.department = departmentDTO;

                stdDtos.Add(stdDTO);
            }
            return stdDtos;

        }

        public StudentWithDeptname GetById(int id)
        {
            var std = db.Students.Include(s => s.Dept).FirstOrDefault(s=>s.id == id);
            StudentWithDeptname stdDTO = new StudentWithDeptname();
            stdDTO.Std_No = std.id;
            stdDTO.Std_Name = std.name;
            stdDTO.Std_Age = std.age;
            stdDTO.Std_Address = std.address;
            stdDTO.Std_Image = std.image;
            stdDTO.Department_Name = std.Dept.name;
            return stdDTO;
        }

        public Student GetByIdv2(int id)
        {
            return db.Students.Find(id);
        }

        public Student GetByName(string Name)
        {
            return db.Students.FirstOrDefault(s => s.name == Name);
        }

        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(int id, Student student)
        {
            var oldstd = GetByIdv2(id); ;
            if (oldstd != null)
            {
                oldstd.name = student.name;
                oldstd.image = student.image;
                oldstd.age = student.age;
                oldstd.address = student.address;
                db.SaveChanges();
            }


        }

        public void Delete(int id)
        {
            db.Students.Remove(GetByIdv2(id));
            db.SaveChanges();
        }

        

    }
}
