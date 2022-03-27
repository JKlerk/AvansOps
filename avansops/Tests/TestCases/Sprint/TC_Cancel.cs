using System;
using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;
using AvansOps.User;
using Xunit;

namespace AvansOps.Tests.TestCases.Sprint
{
    public class TC_Cancel
    {
        [Fact]
        public void Test1()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

            ScrumProject.SprintScrum.Sprint sprint = project.AddSprint(SprintType.Review, DateTime.Now, DateTime.Now.AddMonths(1), projectMember);

            sprint.Cancel();

            Assert.True(sprint.SprintState == SprintState.Canceled);
        }

        [Fact]
        public void Test2()
        {
            User.User user = new User.User("testFirst", "testLast", "test@test.com");
            ProjectMember projectMember = new ProjectMember(user, new List<Role>() { Role.ScrumMaster }, new NotificationEmailProxy());
            ScrumProject.Project project = ProjectFactory.CreateProject(0, "TestProject", "TestDescription", projectMember);

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
