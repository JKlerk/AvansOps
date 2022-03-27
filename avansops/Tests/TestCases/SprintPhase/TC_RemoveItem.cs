using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.SprintPhase
{
    public class TC_RemoveItem
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.SprintPhase phase = new ScrumProject.SprintScrum.SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            ScrumProject.SprintScrum.Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            SprintBackLogItem sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backLogItem, sprint);

            phase.PlaceItem(sprintBackLogItem, null);
            phase.RemoveItem(sprintBackLogItem);

            Assert.DoesNotContain(sprintBackLogItem, phase.SprintBackLogItems);
        }

        [Fact]
        public void Test2()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.SprintPhase phase = new ScrumProject.SprintScrum.SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            ScrumProject.SprintScrum.Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            SprintBackLogItem sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backLogItem, sprint);

            try
            {
                phase.RemoveItem(sprintBackLogItem);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
