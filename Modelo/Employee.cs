using System.ComponentModel.DataAnnotations.Schema;

namespace tp_final.Modelo
{

    [Table("Employees")]
    public class Employee
    {
        public int EmployeeID { get; set; } 
        public string LastName { get; set; } = string.Empty;    
        public string FirstName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string TitleOfCourtesy { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

    }
}
