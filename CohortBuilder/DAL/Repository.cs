using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CohortBuilder.DAL
{
    public class Repository
    {
        public CohortContext Context { get; set; }

        public Repository()
        {
            Context = new CohortContext();
        }

        public Repository(CohortContext context)
        {
            Context = context;
        }

        // Add a Cohort
        // Add a Student to a Cohort
        // Add an Instructor to a Cohort
    }
}