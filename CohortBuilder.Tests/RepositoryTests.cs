using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CohortBuilder.DAL;
using System.Data.Entity;
using CohortBuilder.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CohortBuilder.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        public Mock<CohortContext> MockContext { get; set; }
        public Mock<DbSet<Cohort>> MockCohorts { get; set; }
        public Mock<DbSet<Student>> MockStudents { get; set; }
        public Mock<DbSet<Instructor>> MockInstructors { get; set; }

        List<Cohort> CohortList { get; set; }
        List<Student> StudentList { get; set; }
        List<Instructor> InstructorList { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            MockContext = new Mock<CohortContext>();

            MockCohorts = new Mock<DbSet<Cohort>>();
            MockStudents = new Mock<DbSet<Student>>();
            MockInstructors = new Mock<DbSet<Instructor>>();

            CohortList = new List<Cohort> { new Cohort { Name = "Evening 4" } };
            StudentList = new List<Student> { new Student { FirstName = "John", LastName = "Smith" } };
            InstructorList = new List<Instructor> { new Instructor { FirstName = "Steve", LastName = "Brownlee" } };

            MockContext.Setup(x => x.Cohorts).Returns(MockCohorts.Object);
            MockContext.Setup(x => x.Students).Returns(MockStudents.Object);
            MockContext.Setup(x => x.Instructors).Returns(MockInstructors.Object);
        }

        public void SetUpMocks()
        {
            var cohortQueryable = CohortList.AsQueryable();
            var studentQueryable = StudentList.AsQueryable();
            var instructorQueryable = InstructorList.AsQueryable();

            MockCohorts.As<IQueryable<Cohort>>().Setup(c => c.Provider).Returns(cohortQueryable.Provider);
            MockCohorts.As<IQueryable<Cohort>>().Setup(c => c.Expression).Returns(cohortQueryable.Expression);
            MockCohorts.As<IQueryable<Cohort>>().Setup(c => c.ElementType).Returns(cohortQueryable.ElementType);
            MockCohorts.As<IQueryable<Cohort>>().Setup(c => c.GetEnumerator()).Returns(() => cohortQueryable.GetEnumerator());

            MockStudents.As<IQueryable<Student>>().Setup(s => s.Provider).Returns(studentQueryable.Provider);
            MockStudents.As<IQueryable<Student>>().Setup(s => s.Expression).Returns(studentQueryable.Expression);
            MockStudents.As<IQueryable<Student>>().Setup(s => s.ElementType).Returns(studentQueryable.ElementType);
            MockStudents.As<IQueryable<Student>>().Setup(s => s.GetEnumerator()).Returns(() => studentQueryable.GetEnumerator());

            MockInstructors.As<IQueryable<Instructor>>().Setup(i => i.Provider).Returns(instructorQueryable.Provider);
            MockInstructors.As<IQueryable<Instructor>>().Setup(i => i.Expression).Returns(instructorQueryable.Expression);
            MockInstructors.As<IQueryable<Instructor>>().Setup(i => i.ElementType).Returns(instructorQueryable.ElementType);
            MockInstructors.As<IQueryable<Instructor>>().Setup(i => i.GetEnumerator()).Returns(() => instructorQueryable.GetEnumerator());
        }

        [TestMethod]
        public void EnsureICanCreateInstanceOfRepo()
        {
            Repository repo = new Repository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureContextIsNotNull()
        {
            Repository repo = new Repository();

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanInjectContextInstance()
        {
            CohortContext context = new CohortContext();

            Repository repo = new Repository(context);

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanCreateCohort()
        {
            Repository repo = new Repository();
            SetUpMocks();

            bool expected_result = true;
            bool actual_result = repo.AddCohort("Evening Cohort 4");

            Assert.AreEqual(expected_result, actual_result);
        }
    }
}
