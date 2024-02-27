using System.Text.Json.Serialization;

namespace Api_D01.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }

        public string image { get; set; }

        public int DeptId { get; set; }
        [JsonIgnore]
        public virtual Department? Dept { get; set; }
    }
}
