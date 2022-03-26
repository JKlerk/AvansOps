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

        public void UploadReviewDoc(ReviewDoc reviewDoc)
        {
            ReviewDoc = reviewDoc;

            if (ReviewDoc != null)
            {
                Finish();
            }
        }
    }
}
