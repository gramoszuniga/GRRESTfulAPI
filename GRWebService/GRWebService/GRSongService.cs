/*
 * File name: GRSongService.cs
 * Description: Web service for song resource
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/13: Cleaned up and bug fixes
 *      2016/10/10: Switched from JavaScriptSerializer to Net.Json to avoid 
 *                  circular reference exception
 *      2016/10/09: Added association to song and exception handling
 *      2016/10/08: Created
 */

using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Web;

namespace GRWebService
{
    /// <summary>
    /// Class to manage song web service
    /// </summary>
    class GRSongService : IHttpHandler
    {
        /// <summary>
        /// Constant
        /// </summary>
        string RESOURCE_URL = "songs";
        string BASE_PATH = "public\\songs\\";

        /// <summary>
        /// Turns pooling off
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Handles http request according to its http method
        /// </summary>
        /// <param name="context">Context of incoming http request</param>
        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    GetHandler(context);
                    break;
                case "POST":
                    PostHandler(context);
                    break;
                case "PUT":
                    PutHandler(context);
                    break;
                case "DELETE":
                    DeleteHandler(context);
                    break;
                default:
                    context.Response.Write("Method not implemented.");
                    break;
            }
        }

        /// <summary>
        /// Handles GET http method
        /// </summary>
        /// <param name="context">Context of incoming http request</param>
        private void GetHandler(HttpContext context)
        {
            try
            {
                if (context.Request.RawUrl.Split('/').Last() == RESOURCE_URL)
                {
                    context.Response.Write(JsonConvert.SerializeObject(SongList.
                        ReadAll(), Formatting.Indented, new
                        JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
                }
                else
                {
                    context.Response.Write(JsonConvert.SerializeObject(SongList.
                        Read(Int32.Parse(context.Request.RawUrl.Split('/').
                        Last())), Formatting.Indented, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
                }
            }
            catch (ArgumentNullException)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Error: Input values are missing.");
            }
            catch (ArgumentException err)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Error: " + err.Message);
            }
            catch (FormatException err)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: " + err.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: Server had a problem. Please try "
                    + "again later.");
            }
        }

        /// <summary>
        /// Handles POST http method
        /// </summary>
        /// <param name="context">Context of incoming http request</param>
        private void PostHandler(HttpContext context)
        {
            try
            {
                string queryString = new StreamReader(context.Request.
                    InputStream).ReadToEnd();
                string name = HttpUtility.ParseQueryString(queryString).
                    Get("name");
                string artist = HttpUtility.ParseQueryString(queryString).
                    Get("artist");
                string duration = HttpUtility.ParseQueryString(queryString).
                    Get("duration");
                string genre = HttpUtility.ParseQueryString(queryString).
                    Get("genre");
                string path = HttpUtility.ParseQueryString(queryString).
                    Get("path");
                Song song = new Song(SongList.GenerateId(), name, artist, Int32.
                    Parse(duration), genre, BASE_PATH + path);
                SongList.Create(song);
                context.Response.Write("200: Song Created.");
            }
            catch (ArgumentNullException)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Error: Input values are missing.");
            }
            catch (ArgumentException err)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Error: " + err.Message);
            }
            catch (FormatException err)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: " + err.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: Server had a problem. Please try "
                    + "again later.");
            }
        }

        /// <summary>
        /// Handles PUT http method
        /// </summary>
        /// <param name="context">Context of incoming http request</param>
        private void PutHandler(HttpContext context)
        {
            try
            {
                string queryString = new StreamReader(context.Request.
                    InputStream).ReadToEnd();
                string name = HttpUtility.ParseQueryString(queryString).
                    Get("name");
                string artist = HttpUtility.ParseQueryString(queryString).
                    Get("artist");
                string duration = HttpUtility.ParseQueryString(queryString).
                    Get("duration");
                string genre = HttpUtility.ParseQueryString(queryString).
                    Get("genre");
                string path = HttpUtility.ParseQueryString(queryString).
                    Get("path");
                Song song = new Song(Int32.Parse(context.Request.RawUrl.
                    Split('/').Last()), name, artist, Int32.Parse(duration),
                    genre, BASE_PATH + path);
                SongList.Update(Int32.Parse(context.Request.RawUrl.Split('/').
                    Last()), song);
                context.Response.Write("200: Song Updated.");
            }
            catch (ArgumentNullException)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Error: Input values are missing.");
            }
            catch (ArgumentException err)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Error: " + err.Message);
            }
            catch (FormatException err)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: " + err.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: Server had a problem. Please try "
                    + "again later.");
            }
        }

        /// <summary>
        /// Handles DELETE http method
        /// </summary>
        /// <param name="context">Context of incoming http request</param>
        private void DeleteHandler(HttpContext context)
        {
            try
            {
                SongList.Delete(Int32.Parse(context.Request.RawUrl.Split('/').
                    Last()));
                context.Response.Write("Song Deleted.");
            }
            catch (ArgumentNullException)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Error: Input values are missing.");
            }
            catch (ArgumentException err)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Error: " + err.Message);
            }
            catch (FormatException err)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: " + err.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.Write("Error: Server had a problem. Please try "
                    + "again later.");
            }
        }
    }
}