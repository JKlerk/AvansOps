using System.Collections.Generic;
using AvansOps.Notification;
using Xunit;

namespace AvansOps.Tests.TestCases.BacklogItem
{
    public class TC_BacklogItemActivity
    {
        [Fact]
        public void Test_CreateActivity()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            backlogItem.CreateActivity("New Activity", "Description", member);
            Assert.True(backlogItem.GetBackLogItemActivities().Count == 1);
            var activity = backlogItem.GetBackLogItemActivities()[0];
            Assert.True(activity.GetName() == "New Activity");
            Assert.True(activity.GetDescription() == "Description");
            Assert.True(activity.GetProjectMember().User.FirstName == "Firstname");
        }

        [Fact]
        public void Test_SetActivityDone()
        {
            var backlogItem = new BackLogItem(1, "Backlogitem 1", "Description");
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() {Role.Developer, Role.ScrumMaster}, notificationStrategy);
            backlogItem.CreateActivity("New Activity", "Description", member);
            var activity = backlogItem.GetBackLogItemActivities()[0];
            activity.SetActivityDone();
            Assert.True(activity.IsAcitvityDone());
        }
    }
}