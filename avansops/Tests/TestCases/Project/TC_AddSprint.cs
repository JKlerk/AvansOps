using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.Sprint;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Project
{
    public class TC_AddSprint
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            Assert.NotEmpty(project.Sprints);
        }

        [Fact]
        public void Test2()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            Assert.NotEmpty(project.Sprints);
        }
    }
}
