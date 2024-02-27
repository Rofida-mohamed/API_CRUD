using Api_D01.Models;
using API_D01_D02.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api_D01.Service
{
    public class DepartmentRepo : IDepartmentRepo
    {
        ApiDbContext db;



        public DepartmentRepo(ApiDbContext db)
        {
            this.db = db;
        }

        public List<deptWithStudents> GetAll()
        {

            var depts = db.Departments.Include(d => d.Students).ToList();

            List<deptWithStudents> deptWithStudents = new List<deptWithStudents>();

            foreach (var dept in depts)
            {
                var dtoDept = new deptWithStudents();

                dtoDept.depat_No = dept.id;
                dtoDept.depat_Name = dept.name;
                dtoDept.depat_Loaction = dept.Loaction;
                dtoDept.depat_Manger = dept.manger;

                foreach ( var s in dept.Students)
                {
                    StudentDTO studentDTO = new StudentDTO();
                    studentDTO.Id = s.id;
                    studentDTO.Name = s.name;
                    studentDTO.Age = s.age;
                    studentDTO.Address = s.address;
                    studentDTO.Image = s.image;

                    dtoDept.Students.Add(studentDTO);
                }

                deptWithStudents.Add(dtoDept); 
            }

            return deptWithStudents;
        }

        public DeptWithStdName GetById(int id)
        {
            var dept = db.Departments.Include(d => d.Students).FirstOrDefault(d => d.id == id);
            DeptWithStdName dtoDept = new DeptWithStdName();
            dtoDept.depat_No = dept.id;
            dtoDept.depat_Name = dept.name;
            dtoDept.depat_Loaction = dept.Loaction;
            foreach (var std in dept.Students)
            {
                dtoDept.Students_Name.Add(std.name);
            }
            return dtoDept;
        }
        public Department GetByIdv2(int id)
        {
            return db.Departments.Find(id);
        }


        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(int id, Department department)
        {
            var oldDept = GetByIdv2(id); ;
            if (oldDept != null)
            {
                oldDept.name = department.name;
                oldDept.Loaction = department.Loaction;
                oldDept.manger = department.manger;
                db.SaveChanges();
            }


        }

        public void Delete(int id)
        {
            db.Departments.Remove(GetByIdv2(id));
            db.SaveChanges();
        }

        
    }
}
