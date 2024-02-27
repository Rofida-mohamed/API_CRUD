namespace API_D01_D02.DTO
{
    public class DeptWithStdName
    {
        public int depat_No { get; set; }

        public string depat_Name { get; set; }

        public string depat_Loaction { get; set; }

        public List<String> Students_Name { get; set; } = new List<string>();
    }
}
