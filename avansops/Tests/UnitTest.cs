using System;
using System.Collections.Generic;
using AvansOps;
using AvansOps.Notification;
using Xunit;

namespace AvansOps.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test_CreateMember()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            Assert.True(member.User.FirstName == "Firstname");
            Assert.True(member.User.LastName == "Lastname");
            Assert.True(member.User.Email == "test@test.com");
        }
    
        [Fact]
        public void Test_NotifyMember()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            notificationStrategy.Notify(member, "testMessage");
            Assert.True(notificationStrategy.Messages[0] == "testMessage");
        
        }
    
        [Fact]
        public void Test_CreateProject()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);

            Assert.True(project.Name == "Project 1");
            Assert.True(project.Description == "description of project");
        }
    
        [Fact]
        public void Test_SeeIfProjectHasDefaultPhases()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            Assert.True(project.GetPhase("Todo") != null);
            Assert.True(project.GetPhase("Doing") != null);
            Assert.True(project.GetPhase("Ready for testing") != null);
            Assert.True(project.GetPhase("Testing") != null);
            Assert.True(project.GetPhase("Tested and done") != null);
            Assert.True(project.GetPhases().Count == 5);
        }

        [Fact]
        public void Test_SeeIfTodoPhaseHasNotifyRoleStrategy()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            Assert.True(project.GetPhase("Todo").GetStrategiesPlaceItem()[0].GetType() == typeof(NotifyRole));
        }

        [Fact]
        public void Test_AddBacklogItemToProjectBacklog()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
        
            Assert.True(project.GetBacklogItems().Count == 1);
            Assert.True(project.GetBacklogItems()[0].GetName() == backlogItem.GetName());
        }

        [Fact]
        public void Test_AddSprintToProject()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
        
            Assert.True(project.GetSprints().Count == 1);
            Assert.True(project.GetSprints()[0] == sprint);
        }

        [Fact]
        public void Test_MoveBacklogItemToSprintBacklog()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            Assert.True(project.GetPhases()[0].GetSprintBackLogItems()[0].BackLogItem.GetName() == backlogItem.GetName());
        }

        [Fact]
        public void Test_MoveSprintBacklogItemToOtherFase()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Testing"));
        
            Assert.True(project.GetPhase("Testing").GetSprintBackLogItems()[0].BackLogItem.GetName() == sprintBackLogItem.BackLogItem.GetName());
        }
    }
}