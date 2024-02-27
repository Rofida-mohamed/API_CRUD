using Api_D01.Service;
using API_D01_D02.Validators;

namespace Api_D01.Models
{
    public class Department
    {
       

        public int id { get; set; }

        [UniqueName]
        public string name { get; set; }

        [FilterLocat(ErrorMessage ="Loaction must be in ['EG'' , 'USA' ]")]
        public string Loaction { get; set; }

        public string manger { get; set; }

        public virtual ICollection<Student>? Students { get; } 
    }
}
