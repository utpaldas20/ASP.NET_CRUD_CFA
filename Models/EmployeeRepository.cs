using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD_CODE_FIRST.Models
{
    public class EmployeeRepository : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}