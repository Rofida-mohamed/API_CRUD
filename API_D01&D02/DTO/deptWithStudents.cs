using Api_D01.Models;

namespace API_D01_D02.DTO
{
    public class deptWithStudents
    {
        public int depat_No { get; set; }

        public string depat_Name { get; set; }

        public string depat_Loaction { get; set; }

        public string depat_Manger { get; set; }
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
