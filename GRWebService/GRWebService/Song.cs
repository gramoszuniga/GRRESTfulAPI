/*
 * File name: Song.cs
 * Description: Song class
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/09: Added association to review
 *      2016/10/08: Created
 */

using System.Collections.Generic;

namespace GRWebService
{
    /// <summary>
    /// Class for song
    /// </summary>
    class Song
    {
        #region Song fields
        private int songId;
        private string name;
        private string artist;
        private int duration;
        private string genre;
        private string path;
        private List<Review> reviews;
        #endregion

        #region Song constructors
        public Song(int songId, string name, string artist, int duration,
            string genre, string path)
        {
            this.songId = songId;
            this.name = name;
            this.artist = artist;
            this.duration = duration;
            this.genre = genre;
            this.path = path;
            this.reviews = new List<Review>();
        }
        #endregion

        #region Song properties        
        public int SongId
        {
            get
            {
                return songId;
            }

            set
            {
                songId = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Artist
        {
            get
            {
                return artist;
            }

            set
            {
                artist = value;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public List<Review> Reviews
        {
            get
            {
                return reviews;
            }

            set
            {
                reviews = value;
            }
        }
        #endregion
    }
}