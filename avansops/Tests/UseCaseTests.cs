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
        public void Test_US_1_5()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Testing"));
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Todo"));
        
            Assert.Empty(notificationStrategy.Messages);
        }

        [Fact]
        public void Test_US_2()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            Assert.True(project.Name == "Project 1");
        }
        
        [Fact]
        public void Test_US_3()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            Assert.True(project.GetCurrentSprint() == sprint);
        }
        
        [Fact]
        public void Test_US_4()
        {
            // TODO: Auto mark as finished
        }

        [Fact]
        public void Test_US_5()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            Assert.True(project.GetCurrentSprint().GetType() == typeof(SprintRelease));
        }
        
        [Fact]
        public void Test_US_5_1()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddDays(2), member);
            Assert.True(project.GetCurrentSprint().GetType() == typeof(SprintReview));
        }
        
        [Fact]
        public void Test_US_6()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            Assert.NotNull(project.GetRepository());
        }
        
        [Fact]
        public void Test_US_7()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var repo = project.GetRepository();
            // TODO: Check pipelines
        }

        [Fact]
        public void Test_US_8()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            sprint.Cancel();

            // TODO: Verify notification
        }

        [Fact]
        public void Test_US_9()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            var backlogItem1 = new BackLogItem(2, "Backlogitem 1", "Doe deze stuff");
            var backlogItem2 = new BackLogItem(3, "Backlogitem 1", "Doe deze stuff");
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            project.AddBackLogItem(backlogItem1);
            project.AddBackLogItem(backlogItem2);
            Assert.Same(project.BackLogItems[0], backlogItem);
            Assert.Same(project.BackLogItems[1], backlogItem1);
            Assert.Same(project.BackLogItems[2], backlogItem2);
        }
        
        [Fact]
        public void Test_US_9_1()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            Assert.Throws<Exception>(() => project.AddBackLogItem(backlogItem));
        }

        [Fact]
        public void Test_US_10()
        {
            // TODO: 
        }

        [Fact]
        public void Test_US_11()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.StartPipelineCurrentSprint();
            Assert.True(project.GetRepository().GetPipelines()[0].IsFinished);
        }
        
        [Fact]
        public void Test_US_12()
        {
            // TODO: Test if pipeline fail
        }

        [Fact]
        public void Test_US_13()
        {
            // TODO: Upload
        }
        
        [Fact]
        public void Test_US_14()
        {
            // TODO: ?????
        }
        
        [Fact]
        public void Test_US_15()
        {
            // TODO: Not testable
        }
        
        [Fact]
        public void Test_US_16()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            Assert.NotEmpty(sprint.SprintBackLogItems);
        }
        
        [Fact]
        public void Test_US_16_1()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            Assert.NotEmpty(sprint.SprintBackLogItems);
            Assert.Throws<Exception>(() => project.AddBackLogItemToSprintBackLog(backlogItem, sprint));
        }
        
        [Fact]
        public void Test_US_17()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            var backlogItem1 = new BackLogItem(2, "Backlogitem 2", "Doe deze stuff");
            var backlogItem2 = new BackLogItem(3, "Backlogitem 3", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            project.AddBackLogItem(backlogItem1);
            project.AddBackLogItem(backlogItem2);
            Assert.NotEmpty(project.BackLogItems);
        }
        
        [Fact]
        public void Test_US_18()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var phase = new SprintPhase(8, "New phase", new List<Role>() {Role.Developer});
            project.AddPhase(phase);
            Assert.Same(project.SprintPhases[^1], phase);
        }
        
        [Fact]
        public void Test_US_19()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Testing"));
            Assert.Same(project.GetPhase("Testing").SprintBackLogItems[0], sprintBackLogItem);
        }
        
        [Fact]
        public void Test_US_20()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            Assert.Same(project.GetPhase("Todo").SprintBackLogItems[0], sprintBackLogItem);
        }
        
        [Fact]
        public void Test_US_21()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("Ready for testing"));
            Assert.NotEmpty(notificationStrategy.Messages);
        }
        
        [Fact]
        public void Test_US_22()
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
        public void Test_US_23()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            backlogItem.CreateActivity("New acitvity", "Description", member);
        
            Assert.NotEmpty(notificationStrategy.Messages);
        }
    }
}