using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPAngular.Models
{
    public class Employee
    {
        [Key]
        public int? Empid { get; set; }
        public string Empname { get; set; }
        public string EmpContact { get; set; }
        public string EmpMail { get; set; }
        public string EmpAddress { get; set; }

    }
}
