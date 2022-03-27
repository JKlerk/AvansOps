using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps.Tests
{
    public class TC_GenerateReport
    {
        [Fact]
        public void Test1()
        {
            User creator = new User("creatorFirst", "creatorLast", "creator@test.com");
            ProjectMember creatorMember = new ProjectMember(creator, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            User developer = new User("developerFirst", "developerLast", "developer@test.com");
            ProjectMember developerMember = new ProjectMember(developer, new List<Role>() { Role.Developer }, new NotificationEmailProxy());
            User tester = new User("testerFirst", "testerLast", "tester@test.com");
            ProjectMember testerMember = new ProjectMember(tester, new List<Role>() { Role.Tester }, new NotificationEmailProxy());

            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", creatorMember);

            BackLogItem backLogItemDev = new BackLogItem(0, "Develop someting", "Test");
            BackLogItem backLogItemTest = new BackLogItem(1, "Test someting", "Test");
            project.AddBackLogItem(backLogItemDev);
            project.AddBackLogItem(backLogItemTest);
            backLogItemDev.SetProjectMember(developerMember);
            backLogItemTest.SetProjectMember(testerMember);

            Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), creatorMember);

            project.AddBackLogItemToSprintBackLog(backLogItemDev, sprint);
            project.AddBackLogItemToSprintBackLog(backLogItemTest, sprint);

            TeamReport report = TeamReportGenerator.GenerateReport(project, sprint);

            Assert.NotNull(report);
            Assert.True(report.Elements.Count == 3);
        }
    }
}
