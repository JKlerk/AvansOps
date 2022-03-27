using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Project
{
    public class TC_AddBackLogItem
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);
            project.AddBackLogItem(new BackLogItem(0, "TestBackLog", "TestDescription"));

            Assert.NotEmpty(project.BackLogItems);
        }
    }
}
