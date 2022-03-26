using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps
{
    public class TC_AddProjectMember
    {
        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            User userDeveloper = new User("dev", "test", "test@test.com");
            ProjectMember developer = new ProjectMember(userDeveloper, new List<Role>() { Role.Developer }, new NotificationEmailProxy());

            sprint.AddProjectMember(developer);

            Assert.Contains(developer, sprint.ProjectMembers);
        }

        [Fact]
        public void Test2()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            try
            {
                sprint.AddProjectMember(projectMember);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
