using System;
using System.Collections.Generic;
using AvansOps;
using AvansOps.Notification;
using Xunit;

namespace AvansOps.Tests
{
    public class UseCaseTests
    {
        [Fact]
        public void Test_US_1()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Testing"));
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Todo"));
        
            Assert.NotEmpty(notificationStrategy.Messages);
        }

        [Fact]
        public void Test_US_2()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            Assert.True(project.Name == "Project 1");
        }
    }
}