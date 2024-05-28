namespace APIApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string Position { get; set; }

        public int Salary { get; set; }
        public DateOnly HireDate { get; set; }
        public string IDProofTypeId { get; set; }
    }
}
