using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeERP.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? name { get; set; }

    }
}
