using System;
using System.Collections.Generic;
using AvansOps.Notification;
using Xunit;

namespace AvansOps.Tests.TestCases.Project
{
    public class TC_Thread
    {
        [Fact]
        public void Test_CreateThread()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var thread = new Thread(1, "Thread 1", "Description", member);
            Assert.True(thread.GetName() == "Thread 1");
            Assert.True(thread.GetDescription() == "Description");
            Assert.True(thread.GetThreadMessages().Count == 0);
        }
        
        [Fact]
        public void Test_CreateMessage()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            var thread = new Thread(1, "Thread 1", "Description", member);
            thread.CreateMessage("My new message", member);
            Assert.True(thread.GetThreadMessages().Count == 1);
            Assert.True(thread.GetThreadMessages()[0].Id == 1);
            Assert.True(thread.GetThreadMessages()[0].GetMessage() == "My new message");
            Assert.True(thread.GetThreadMessages()[0].GetDateTime() is DateTime);
        }
    }
}