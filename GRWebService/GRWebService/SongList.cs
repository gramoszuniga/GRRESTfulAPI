/*
 * File name: SongList.cs
 * Description: List of songs
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/13: Cleaned up and bug fixes
 *      2016/10/09: Added association to review and exception handling
 *      2016/10/08: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace GRWebService
{
    /// <summary>
    /// Class to manage list of songs
    /// </summary>
    class SongList
    {
        /// <summary>
        /// Class to manage list of songs
        /// </summary>
        private static List<Song> songs = new List<Song>() { new Song(1,
            "Hiraeth", "EF", 350, "Post Rock", "public\\songs\\song-1.mp3") };

        /// <summary>
        /// Creates a song
        /// </summary>
        /// <param name="song">Song to create</param>
        public static void Create(Song song)
        {
            songs.Add(song);
        }

        /// <summary>
        /// Updates an specific song
        /// </summary>
        /// <param name="songId">Id of specific song to update</param>
        /// <param name="uSong">Updated song</param>
        public static void Update(int songId, Song uSong)
        {
            Song song = songs.Find(s => s.SongId == songId);
            if (song != null)
            {
                song.Name = uSong.Name;
                song.Artist = uSong.Artist;
                song.Duration = uSong.Duration;
                song.Genre = uSong.Genre;
                song.Path = uSong.Path;
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Reads an specific song
        /// </summary>
        /// <param name="songId">Id of specific song to read</param>
        /// <returns>Specific song read</returns>
        public static Song Read(int songId)
        {
            Song song = songs.Find(s => s.SongId == songId);
            if (song != null)
            {
                return song;
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Reads all songs
        /// </summary>
        /// <returns>List of all songs read ordered by id</returns>
        public static List<Song> ReadAll()
        {
            if (songs.Any())
            {
                return songs;
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Deletes an specific song and all its reviews
        /// </summary>
        /// <param name="songId">Id of specific song to delete</param>
        public static void Delete(int songId)
        {
            Song song = songs.Find(s => s.SongId == songId);
            if (song != null)
            {
                foreach (Review review in song.Reviews)
                {
                    ReviewList.ReadAll().Remove(review);
                }
                songs.Remove(song);
            }
            else
            {
                throw new ArgumentException("Resource not found.");
            }
        }

        /// <summary>
        /// Generates id for song
        /// </summary>
        /// <returns>Id generated</returns>
        public static int GenerateId()
        {
            if (songs.Any())
            {
                return songs.Last().SongId + 1;
            }
            return 1;
        }
    }
}