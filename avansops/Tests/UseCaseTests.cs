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
            Assert.True(project.Id == 1);
        }
        
        [Fact]
        public void Test_US_3()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            Assert.True(project.GetCurrentSprint() == sprint);
            Assert.True(project.GetCurrentSprint().Id == sprint.Id);
        }
        
        [Fact]
        public void Test_US_4()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            sprint.Finish();
            Assert.True(sprint.SprintState == SprintState.Finished);
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
            Assert.Same(repo.GetPipelines()[0].Phases[0].GetType(), typeof(PipelinePhasePackage));
            Assert.Same(repo.GetPipelines()[0].Phases[1].GetType(), typeof(PipelinePhaseBuild));
            Assert.Same(repo.GetPipelines()[0].Phases[2].GetType(), typeof(PipelinePhaseTest));
            Assert.Same(repo.GetPipelines()[0].Phases[3].GetType(), typeof(PipelinePhaseAnalyse));
            Assert.Same(repo.GetPipelines()[0].Phases[4].GetType(), typeof(PipelinePhaseDeploy));
            Assert.Same(repo.GetPipelines()[0].Phases[5].GetType(), typeof(PipelinePhaseUtility));
        }

        [Fact]
        public void Test_US_8()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            sprint.Cancel();
            Assert.NotEmpty(notificationStrategy.Messages);
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
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.StartPipelineCurrentSprint();
            Assert.True(project.GetRepository().GetPipelines()[0].IsFinished);
            Assert.NotEmpty(notificationStrategy.Messages);
        }
        
        [Fact]
        public void Test_US_11_1()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.Sprints[0].Finish();
            Assert.Throws<Exception>(() =>  project.StartPipelineCurrentSprint());
        }
        
        [Fact]
        public void Test_US_11_2()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Tester}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddDays(2), member);
            Assert.Throws<Exception>(() =>  project.StartPipelineCurrentSprint());
        }

        [Fact]
        public void Test_US_12()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() { Role.ScrumMaster }, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            SprintRelease sprint = (SprintRelease)project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            Pipeline pipeline = project.GetRepository().GetPipeline(sprint);
            pipeline.AddPhase(new PipelinePhaseFail());
            
            project.StartPipelineCurrentSprint();

            Assert.False(pipeline.IsFinished);
            Assert.True(notificationStrategy.Messages[0] == "Pipeline has failed: Forced fail");
        }

        [Fact]
        public void Test_US_13()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() { Role.ScrumMaster }, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            SprintReview sprint = (SprintReview)project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddDays(2), member);

            sprint.UploadReviewDoc(new ReviewDoc("test"));

            Assert.True(sprint.SprintState == SprintState.Finished);
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
            backlogItem.CreateActivity("New activity", "Description", member);
            backlogItem.CreateActivity("New activity2", "Description", member);
            
            Assert.NotEmpty(backlogItem.GetBackLogItemActivities());
        }
        
        [Fact]
        public void Test_US_24()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            backlogItem.CreateActivity("New activity", "Description", member);
            Assert.Same(backlogItem.GetBackLogItemActivities()[0].GetProjectMember(), member);
        }
        
        [Fact]
        public void Test_US_25()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            backlogItem.AddThread(new Thread(1, "Thread name", "Description", member));
            Assert.NotEmpty(backlogItem.GetThreads());
        }
        
        [Fact]
        public void Test_US_26()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var thread = new Thread(1, "Thread name", "Description", member);
            backlogItem.AddThread(thread);
            thread.CreateMessage("Hello I need help", member);
            Assert.Same(backlogItem.GetThreads()[0].GetThreadMessages()[0].GetMessage(),"Hello I need help");
        }
        
        [Fact]
        public void Test_US_26_1()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItem(backlogItem);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("tested and done"));

            var thread = new Thread(1, "Thread name", "Description", member);
            Assert.Throws<Exception>(() => backlogItem.AddThread(thread));
        }
        
        [Fact]
        public void Test_US_27()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var owner = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var members = new List<ProjectMember>
            {
                new (new User("Firstname", "Lastname", "test@test.com"),
                    new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy),
                new (new User("Firstname1", "Lastname", "test@test.com"),
                    new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy),
                new (new User("Firstname2", "Lastname", "test@test.com"),
                    new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy),
            };
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", owner);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), owner);

            for (int i = members.Count; i <= 0; i++)
            {
                Assert.Same(sprint.ProjectMembers[i], members[i]);
            }
        }
        
        [Fact]
        public void Test_US_28()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            
            sprint.ProjectMembers[0].Roles = new List<Role>() {Role.Tester};
            Assert.True(sprint.ProjectMembers[0].Roles[0] == Role.Tester);
        }
        
        [Fact]
        public void Test_US_29()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            
            sprint.ProjectMembers[0].Roles = new List<Role>() {Role.ScrumMaster};
            Assert.True(sprint.ProjectMembers[0].Roles[0] == Role.ScrumMaster);
        }
        
        [Fact]
        public void Test_US_30()
        {
            // TODO: Generate report
        }
        
        [Fact]
        public void Test_US_31()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItem(backlogItem);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("tested and done"));
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("ready for testing"));
            
            Assert.Same(project.GetPhase("ready for testing").SprintBackLogItems[0], sprintBackLogItem);
        }
        
        [Fact]
        public void Test_US_32()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            project.AddBackLogItem(backlogItem);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            var thread = new Thread(1, "Thread name", "Description", member);
            backlogItem.AddThread(thread);
            project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, project.GetPhase("tested and done"));
            Assert.Throws<Exception>(() => thread.CreateMessage("Hello I need help", member));
        }

        [Fact]
        public void Test_US_33()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            backlogItem.CreateActivity("Activity 1", "Description", member);

            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            var sprintPhase = project.SprintPhases[project.SprintPhases.Count - 1];

            try
            {
                project.MoveSprintBackLogItemToPhase(member, sprintBackLogItem, sprintPhase);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);

            }
        }

        [Fact]
        public void Test_US_34()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            backlogItem.CreateActivity("Activity 1", "Description", member);

            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var sprint = project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            var sprintBackLogItem = project.AddBackLogItemToSprintBackLog(backlogItem, sprint);
            Assert.Throws<Exception>(() => sprintBackLogItem.BackLogItem.SetDescription("Hello I need help"));
            Assert.Throws<Exception>(() => sprintBackLogItem.BackLogItem.SetName("Hello I need help"));
        }
        
        [Fact]
        public void Test_US_35()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
            backlogItem.CreateActivity("Activity 1", "Description", member);

            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddDays(2), member);
            Assert.True(project.SprintPhases[0].Name == "Todo");
            Assert.True(project.SprintPhases[1].Name == "Doing");
            Assert.True(project.SprintPhases[2].Name == "Ready for testing");
            Assert.True(project.SprintPhases[3].Name == "Testing");
            Assert.True(project.SprintPhases[4].Name == "Tested and done");
        }

        [Fact]
        public void Test_US_36()
        {
            // TODO: Add notification on threadmessage post
        }

        [Fact]
        public void Test_US_37()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            var thread = new Thread(1, "Thread name", "Description", member);
            backlogItem.AddThread(thread);
            backlogItem.AddThread(thread);
            backlogItem.AddThread(thread);
            Assert.True(backlogItem.GetThreads().Count == 3);
        }
        
        [Fact]
        public void Test_US_38()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Doe deze stuff");
        
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            project.AddBackLogItem(backlogItem);
            backlogItem.SetToDone();
            var thread = new Thread(1, "Thread name", "Description", member);
            Assert.Throws<Exception>(() =>  backlogItem.AddThread(thread));
        }
        
        [Fact]
        public void Test_US_39()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);

            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var repo = project.GetRepository();
            repo.Commit(new Commit(DateTime.Now, "My new commit", member));
        }
    }
}