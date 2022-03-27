using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.NotificationManager
{
    public class TC_Notify
    {
        [Fact]
        public void Test_NotifyMemberSlack()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            Notification.NotificationManager.Notify(member, "testMessage");
            Assert.True(notificationStrategy.Messages[0] == "testMessage");
        }
        
        [Fact]
        public void Test_NotifyMemberEmail()
        {
            var notificationStrategy = new NotificationEmailProxy();
            var member = new ProjectMember(new User.User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            Notification.NotificationManager.Notify(member, "testMessage");
            Assert.True(notificationStrategy.Messages[0] == "testMessage");
        }
    }
}