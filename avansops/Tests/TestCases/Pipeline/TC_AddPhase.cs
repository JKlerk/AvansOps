using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps.Tests
{
    public class TC_AddPhase
    {
        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            SprintRelease sprint = (SprintRelease)project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            Pipeline pipeline = project.GetRepository().GetPipeline(sprint);
            int phaseCount = pipeline.Phases.Count;

            pipeline.AddPhase(new PipelinePhaseFail());

            Assert.True(pipeline.Phases.Count == phaseCount + 1);
        }
    }
}
