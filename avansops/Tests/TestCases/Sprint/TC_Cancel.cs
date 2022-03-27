using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AvansOps
{
    public class TC_Cancel
    {
        [Fact]
        public void Test1()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            sprint.Cancel();

            Assert.True(sprint.SprintState == SprintState.Canceled);
        }

        [Fact]
        public void Test2()
        {
            User user = new User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            SprintReview sprint = (SprintReview)project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);
            sprint.UploadReviewDoc(new ReviewDoc("goodreview"));

            try
            {
                sprint.Cancel();
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
            Assert.True(sprint.ReviewDoc.Text == "goodreview");
            Assert.True(sprint.SprintState != SprintState.Canceled);
        }
    }
}
