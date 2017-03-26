/*
 * File name: Review.cs
 * Description: Review class
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/09: Added association to song
 *      2016/10/08: Created
 */

namespace GRWebService
{
    /// <summary>
    /// Class for review
    /// </summary>
    class Review
    {
        #region Review fields
        private int reviewId;
        private string text;
        private Song song;
        #endregion

        #region Review constructors
        public Review(int reviewId, string text)
        {
            this.reviewId = reviewId;
            this.text = text;
        }
        #endregion

        #region Review properties
        public int ReviewId
        {
            get
            {
                return reviewId;
            }

            set
            {
                reviewId = value;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public Song Song
        {
            get
            {
                return song;
            }

            set
            {
                song = value;
            }
        }
        #endregion
    }
}