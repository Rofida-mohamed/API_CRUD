using Api_D01.Models;
using API_D01_D02.DTO;

namespace Api_D01.Service
{
    public interface IDepartmentRepo
    {
        public List<deptWithStudents> GetAll();


        public DeptWithStdName GetById(int id);



        public void Add(Department student);

        public void Update(int id, Department student);


        public void Delete(int id);
    }
}
