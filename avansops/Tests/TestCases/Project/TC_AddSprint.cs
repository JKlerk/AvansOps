using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps.Tests.TestCases
{
    public class TC_AddSprint
    {
        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            Assert.NotEmpty(project.Sprints);
        }
    }
}
