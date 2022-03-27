using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Sprint
{
    public class TC_RemoveProjectMember
    {
        [Fact]
        public void Test2()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            User.User userDeveloper = new User.User("dev", "test", "test@test.com");
            ProjectMember developer = new ProjectMember(userDeveloper, new List<Role>() { Role.Developer }, new NotificationEmailProxy());

            sprint.AddProjectMember(developer);
            sprint.RemoveProjectMember(developer);

            Assert.DoesNotContain(developer, sprint.ProjectMembers);
        }

        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            User.User userDeveloper = new User.User("dev", "test", "test@test.com");
            ProjectMember developer = new ProjectMember(userDeveloper, new List<Role>() { Role.Developer }, new NotificationEmailProxy());

            try
            {
                sprint.RemoveProjectMember(developer);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Test3()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            try
            {
                sprint.RemoveProjectMember(projectMember);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
