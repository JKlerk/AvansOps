using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.BacklogItem
{
    public class TC_SprintBacklogItem
    {
        [Fact]
        public void Test_CreateSprintBacklogItem()
        {
            var user = new User.User("testFirst", "testLast", "test@test.com");
            var projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            var project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            
            var sprintItem = new SprintBackLogItem(1, project.GetCurrentSprint(), backlogItem);
            Assert.True(sprintItem.Id == backlogItem.Id);
            Assert.True(sprintItem.BackLogItem.GetName() == backlogItem.GetName());
            Assert.True(sprintItem.Sprint.SprintState == project.GetCurrentSprint().SprintState);
        }

        [Fact]
        public void Test_TestSprintItemToDone()
        {
            var user = new User.User("testFirst", "testLast", "test@test.com");
            var projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            var project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            
            var sprintItem = new SprintBackLogItem(1, project.GetCurrentSprint(), backlogItem);
            sprintItem.SetToDone();
            Assert.True(sprintItem.BackLogItem.IsDone());
        }
    }
}