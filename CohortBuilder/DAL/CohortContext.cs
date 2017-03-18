using CohortBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CohortBuilder.DAL
{
    public class CohortContext : DbContext
    {
        public virtual DbSet<Cohort> Cohorts { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}