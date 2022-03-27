using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.Sprint;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.SprintPhase
{
    public class TC_PlaceItem
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.Sprint.SprintPhase phase = new ScrumProject.Sprint.SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            ScrumProject.Sprint.Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            SprintBackLogItem sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backLogItem, sprint);

            phase.PlaceItem(sprintBackLogItem, null);

            Assert.Contains(sprintBackLogItem, phase.SprintBackLogItems);
        }

        [Fact]
        public void Test2()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.Sprint.SprintPhase phase = new ScrumProject.Sprint.SprintPhase(999, "TestPhase", new List<Role>() { Role.ScrumMaster });
            project.AddPhase(phase);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            ScrumProject.Sprint.Sprint sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            SprintBackLogItem sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backLogItem, sprint);

            phase.PlaceItem(sprintBackLogItem, null);

            try
            {
                phase.PlaceItem(sprintBackLogItem, null);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
