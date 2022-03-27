﻿using System.Collections.Generic;
using AvansOps;
using AvansOps.Notification;
using Xunit;

namespace AvansOps.Tests.TestCases.Project
{
    public class TC_Notify
    {
        [Fact]
        public void Test_NotifyMemberSlack()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            NotificationManager.Notify(member, "testMessage");
            Assert.True(notificationStrategy.Messages[0] == "testMessage");
        }
        
        [Fact]
        public void Test_NotifyMemberEmail()
        {
            var notificationStrategy = new NotificationEmailProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            NotificationManager.Notify(member, "testMessage");
            Assert.True(notificationStrategy.Messages[0] == "testMessage");
        }
    }
}