using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
{
    public class SprintReview : Sprint
    {
        public ReviewDoc ReviewDoc { get; private set; }

        public SprintReview(int id, DateTime dateStart, DateTime dateEnd) : base(id, dateStart, dateEnd)
        { }

        protected override void TryFinish()
        {
            if (SprintState == SprintState.Finished)
            {
                return;
            }

            if (ReviewDoc != null)
            {
                SprintState = SprintState.Finished;
            }
            else
            {
                Console.WriteLine("No ReviewDoc uploaded yet!");
            }
        }

        public void UploadReviewDoc(ReviewDoc reviewDoc)
        {
            ReviewDoc = reviewDoc;
        }
    }
}
