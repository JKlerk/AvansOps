using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.Sprint;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Pipeline
{
    public class TC_Run
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            SprintRelease sprint = (SprintRelease)project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            ScrumProject.Repository.Pipeline.Pipeline pipeline = project.GetRepository().GetPipeline(sprint);
            pipeline.Run();

            Assert.True(pipeline.IsFinished);
            Assert.False(pipeline.IsRunning);
        }
        
        [Fact]
        public void Test2()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            BackLogItem backLogItem = new BackLogItem(0, "Test", "Test");
            project.AddBackLogItem(backLogItem);

            SprintRelease sprint = (SprintRelease)project.AddSprint(SprintType.Release, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            ScrumProject.Repository.Pipeline.Pipeline pipeline = project.GetRepository().GetPipeline(sprint);
            pipeline.Run();

            Assert.True(pipeline.IsFinished);
        }
    }
}
