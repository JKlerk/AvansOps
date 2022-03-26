using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps
{
    public class TC_RemoveProjectMember
    {
        [Fact]
        public void Test2()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            User userDeveloper = new User("dev", "test", "test@test.com");
            ProjectMember developer = new ProjectMember(userDeveloper, new List<Role>() { Role.Developer }, new NotificationEmailProxy());

            sprint.AddProjectMember(developer);
            sprint.RemoveProjectMember(developer);

            Assert.DoesNotContain(developer, sprint.ProjectMembers);
        }

        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            User userDeveloper = new User("dev", "test", "test@test.com");
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
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

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
