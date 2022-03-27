using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.Repository;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Repository
{
    public class TC_Repository
    {
        [Fact]
        public void Test_CreateRepository()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var repo = project.GetRepository();
            Assert.Same(repo.Project, project);
        }

        [Fact]
        public void Test_AddCommit()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var project = ProjectFactory.CreateProject(1, "Project 1", "description of project", member);
            var repo = project.GetRepository();
            var now = DateTime.Now;
            var commit = new Commit(now, "My new commit", member);
            repo.Commit(commit);
            Assert.True(commit.Message == "My new commit");
            Assert.True(commit.DateTime == now);
            Assert.Same(commit.ProjectMember, member);
            Assert.True(repo.GetCommits().Count == 1);
        }
    }
}