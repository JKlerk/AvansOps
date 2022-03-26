using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps.Tests.TestCases
{
    public class TC_MoveSprintBackLogItemToPhase
    {
        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            AvansOps.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            SprintPhase phase = new SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            SprintBackLogItem sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backLogItem, sprint);
            project.MoveSprintBackLogItemToPhase(projectMember, sprintBackLogItem, project.GetPhase("TestPhase"));

            Assert.NotEmpty(project.GetPhase("TestPhase").SprintBackLogItems);
        }

        [Fact]
        public void Test2()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.Tester }, new NotificationEmailProxy());
            AvansOps.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            SprintPhase phase = new SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            SprintBackLogItem sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backLogItem, sprint);
            project.MoveSprintBackLogItemToPhase(projectMember, sprintBackLogItem, project.GetPhase("TestPhase"));

            Assert.Empty(project.GetPhase("TestPhase").SprintBackLogItems);
        }
    }
}
