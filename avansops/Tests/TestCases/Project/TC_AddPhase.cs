using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Project
{
    public class TC_AddPhase
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            project.AddPhase(new ScrumProject.Sprint.SprintPhase(999, "TestPhase", new List<Role>() { Role.Developer, Role.ScrumMaster, Role.Tester }));

            var phase = project.GetPhase("TestPhase");
            Assert.NotNull(phase);
            Assert.True(project.GetPhase("TestPhase") == project.GetPhase(phase.Id));
        }
    }
}
