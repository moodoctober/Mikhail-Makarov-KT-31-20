namespace Makarov_Mikhail_Kt_31_20_Lab1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set;}
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
