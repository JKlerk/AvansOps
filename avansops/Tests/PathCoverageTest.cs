using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps
{
    public class PathCoverageTest
    {
        [Fact]
        public void Test_NotifyMember()
        {
            var notificationStrategy = new NotificationSlackProxy();
            var member = new ProjectMember(new User("Firstname", "Lastname", "test@test.com"), new List<Role>() { Role.Developer, Role.ScrumMaster }, notificationStrategy);
            notificationStrategy.Notify(member, "testMessage");
            Assert.True(notificationStrategy.Messages[0] == "testMessage");
        }
    }
}
