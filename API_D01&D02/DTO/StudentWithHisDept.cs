namespace API_D01_D02.DTO
{
    public class StudentWithHisDept
    {
        public int Std_No { get; set; }
        public string Std_Name { get; set; }
        public int Std_Age { get; set; }
        public string Std_Address { get; set; }
        public string Std_Image { get; set; }

        public DepartmentDTO department { get; set; }
    }
}
