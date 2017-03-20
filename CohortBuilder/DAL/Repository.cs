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
        public bool AddCohort(string name)
        {
            throw new NotImplementedException();
        }

        // Add a Student to a Cohort
        // Add an Instructor to a Cohort
    }
}