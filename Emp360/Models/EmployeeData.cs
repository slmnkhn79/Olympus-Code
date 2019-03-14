using System;
using System.Collections.Generic;

namespace Emp360.Models
{
    public partial class EmployeeData
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
