using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.BacklogItem
{
    public class TC_BacklogItem
    {
        [Fact]
        public void Test_CreateBacklogItem()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            Assert.True(backlogItem.GetName() == "Backlogitem 1");
            Assert.True(backlogItem.GetDescription() == "Description");
            
            backlogItem.SetName("Backlogitem Edited");
            backlogItem.SetDescription("Description edited");
            Assert.True(backlogItem.GetName() == "Backlogitem Edited");
            Assert.True(backlogItem.GetDescription() == "Description edited");
        }
        
        [Fact]
        public void Test_ProjectMembers()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            backlogItem.SetProjectMember(member);
            Assert.True(backlogItem.GetProjectMember() == member);
        }

        [Fact]
        public void Test_DoneStatus()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            backlogItem.SetToDone();
            Assert.True(backlogItem.IsDone());
        }

        [Fact]
        public void Test_CreateThread()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var thread = new ScrumProject.Thread(1, "Thread 1", "Description", member);
            backlogItem.AddThread(thread);
            Assert.True(backlogItem.GetThreads().Count == 1);
        }

        [Fact]
        public void Test_IsActivitiesDone()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            backlogItem.CreateActivity("New Activity", "Description", member);
            backlogItem.CreateActivity("New Activity2", "Description", member);

            Assert.False(backlogItem.IsActivitiesDone());
        }

        [Fact]
        public void Test_BoundToSprint()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            Assert.False(backlogItem.IsBoundToSprint());
            
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            
            Assert.True(backlogItem.IsBoundToSprint());
        }
    }
}