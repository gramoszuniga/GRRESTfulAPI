/*
 * File name: ReviewList.cs
 * Description: List of reviews
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/13: Cleaned up and bug fixes
 *      2016/10/09: Added association to song and exception handling
 *      2016/10/08: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace GRWebService
{
    /// <summary>
    /// Class to manage list of reviews
    /// </summary>
    class ReviewList
    {
        /// <summary>
        /// Constants and fields
        /// </summary>
        private static List<Review> reviews = new List<Review>();

        /// <summary>
        /// Creates a review for an specific song
        /// </summary>
        /// <param name="review">Review to create</param>
        /// <param name="songId">Id of the specific song</param>
        public static void Create(Review review, int songId)
        {
            Song song = SongList.ReadAll().Find(s => s.SongId == songId);
            if (song != null)
            {
                review.Song = song;
                song.Reviews.Add(review);
                reviews.Add(review);
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Updates an specific review of an specific song
        /// </summary>
        /// <param name="reviewId">Id of specific review to update</param>
        /// <param name="uReview">Updated review</param>
        public static void Update(int reviewId, Review uReview)
        {
            Review review = reviews.Find(r => r.ReviewId == reviewId);
            if (review != null)
            {
                review.Text = uReview.Text;
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Reads an specific review
        /// </summary>
        /// <param name="reviewId">Id of specific review to read</param>
        /// <returns>Specific review read</returns>
        public static Review Read(int reviewId)
        {
            Review review = reviews.Find(r => r.ReviewId == reviewId);
            if (review != null)
            {
                return review;
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Reads all reviews
        /// </summary>
        /// <returns>List of all reviews read ordered by id</returns>
        public static List<Review> ReadAll()
        {
            if (reviews.Any())
            {
                return reviews;
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Deletes an specific review
        /// </summary>
        /// <param name="reviewId">Id of review to delete</param>
        public static void Delete(int reviewId)
        {
            Review review = reviews.Find(r => r.ReviewId == reviewId);
            if (review != null)
            {
                review.Song.Reviews.Remove(review);
                reviews.Remove(review);
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Generates id for review
        /// </summary>
        /// <returns>Id generated</returns>
        public static int GenerateId()
        {
            if (reviews.Any())
            {
                return reviews.Last().ReviewId + 1;
            }
            return 1;
        }
    }
}