using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps.Tests.TestCases
{
    public class TC_AddBackLogItemToSprintBackLog
    {
        [Fact]
        public void Test()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            project.AddBackLogItemToSprintBackLog(backLogItem, sprint);

            Assert.NotEmpty(project.Sprints[0].SprintBackLogItems);
        }
    }
}
