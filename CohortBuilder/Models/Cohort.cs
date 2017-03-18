using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CohortBuilder.Models
{
    public class Cohort
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Instructor> Instructors { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}