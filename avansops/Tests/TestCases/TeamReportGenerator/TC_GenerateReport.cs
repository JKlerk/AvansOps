using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.Sprint;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.TeamReportGenerator
{
    public class TC_GenerateReport
    {
        [Fact]
        public void Test1()
        {
            User.User creator = new User.User("creatorFirst", "creatorLast", "creator@test.com");
            ProjectMember creatorMember = new ProjectMember(creator, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            User.User developer = new User.User("developerFirst", "developerLast", "developer@test.com");
            ProjectMember developerMember = new ProjectMember(developer, new List<Role>() { Role.Developer }, new NotificationEmailProxy());
            User.User tester = new User.User("testerFirst", "testerLast", "tester@test.com");
            ProjectMember testerMember = new ProjectMember(tester, new List<Role>() { Role.Tester }, new NotificationEmailProxy());

            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", creatorMember);

            BackLogItem backLogItemDev = new BackLogItem(0, "Develop someting", "Test");
            BackLogItem backLogItemTest = new BackLogItem(1, "Test someting", "Test");
            project.AddBackLogItem(backLogItemDev);
            project.AddBackLogItem(backLogItemTest);
            backLogItemDev.SetProjectMember(developerMember);
            backLogItemTest.SetProjectMember(testerMember);

            ScrumProject.Sprint.Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), creatorMember);

            project.AddBackLogItemToSprintBackLog(backLogItemDev, sprint);
            project.AddBackLogItemToSprintBackLog(backLogItemTest, sprint);

            TeamReport.TeamReport report = TeamReport.TeamReportGenerator.GenerateReport(project, sprint);

            Assert.NotNull(report);
            Assert.True(report.Elements.Count == 3);
            Assert.True(report.Elements[0].ImageUrls != null);
            Assert.True(report.Lines != null);
        }
    }
}
