using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps
{
    public class TC_AddStrategyPlaceItem
    {
        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            SprintPhase phase = new SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            phase.AddStrategyPlaceItem(new NotifyRole(new List<Role>() { Role.ScrumMaster }, project, "test"));

            Assert.True(phase.StrategiesPlaceItem.Count == 1);
        }
    }
}
