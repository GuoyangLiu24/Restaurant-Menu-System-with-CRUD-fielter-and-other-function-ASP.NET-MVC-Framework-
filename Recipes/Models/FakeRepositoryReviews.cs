using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class FakeRepositoryReviews
    {
        private static List<Review> reviews = new List<Review>();
        public static IEnumerable<Review> Reviews
        {
            get
            {
                return reviews;
            }
        }
        public static void AddReview(Review review)
        {
            reviews.Add(review);
        }
    }
}
