using Api_D01.Models;
using API_D01_D02.DTO;

namespace Api_D01.Service
{
    public interface IStudentRepo
    {
        public List<StudentWithHisDept> GetAll();


        public StudentWithDeptname GetById(int id);

        public Student GetByName(string Name);


        public void Add(Student student);

        public void Update(int id,Student student);


        public void Delete(int id);
    }
}
