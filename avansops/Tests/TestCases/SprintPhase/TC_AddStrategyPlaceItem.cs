using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.SprintPhase
{
    public class TC_AddStrategyPlaceItem
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.SprintPhase phase = new ScrumProject.SprintScrum.SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            phase.AddStrategyPlaceItem(new NotifyRole(new List<Role>() { Role.ScrumMaster }, project, "test"));

            Assert.True(phase.StrategiesPlaceItem.Count == 1);
        }
    }
}
