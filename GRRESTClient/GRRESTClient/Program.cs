/*
 * File name: Program.cs
 * Description: REST client that interacts with the API for songs and reviews
 * Name: Gonzalo Ramos Zúñiga
 * Revision History:
 *      2016/10/13: Cleaned up and bug fixes
 *      2016/10/10: Created
 */

using System;

namespace GRRESTClient
{
    /// <summary>
    /// Main entry point for the REST client
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Local variables
            /// </summary>
            int option;
            string BASE_URL = "http://localhost:8080";
            RESTService RESTService = new RESTService(BASE_URL);

            do
            {
                Console.WriteLine("REST Client");
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Songs");
                    Console.WriteLine("2. Reviews");
                    Console.WriteLine("3. Exit");
                    Console.Write("Please enter option: ");

                    if (!Int32.TryParse(Console.ReadLine(), out option) ||
                        option < 1 || option > 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Option not valid. Please try again.");
                        Console.WriteLine();
                    }
                } while (option < 1 || option > 3);

                Console.Clear();

                switch (option)
                {
                    case 1:

                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("Menu:");
                            Console.WriteLine("1. Get All Songs");
                            Console.WriteLine("2. Get an Specific Song");
                            Console.WriteLine("3. Post a Song");
                            Console.WriteLine("4. Put an Specific Song");
                            Console.WriteLine("5. Delete an Specific Song");
                            Console.WriteLine("6. Cancel");
                            Console.Write("Please enter option: ");

                            if (!Int32.TryParse(Console.ReadLine(), out option)
                                || option < 1 || option > 6)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Option not valid. Please try "
                                    + "again.");
                                Console.WriteLine();
                            }
                        } while (option < 1 || option > 6);

                        Console.Clear();

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine(RESTService.GET("songs"));
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.Write("Please enter id of song: ");
                                string id = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.GET("songs/"
                                    + id));
                                break;
                            case 3:
                                Console.WriteLine();
                                Console.Write("Please enter name of song: ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter artist of song: ");
                                string artist = Console.ReadLine();
                                Console.Write("Please enter duration of song in "
                                    + "seconds: ");
                                string duration = Console.ReadLine();
                                Console.Write("Please enter genre of song: ");
                                string genre = Console.ReadLine();
                                Console.Write("Please enter filename of song: ");
                                string filename = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.POST("songs",
                                    "name=" + name + "&artist=" + artist
                                    + "&duration=" + duration + "&genre="
                                    + genre + "&path="
                                    + filename));
                                break;
                            case 4:
                                Console.WriteLine();
                                Console.Write("Please enter id of song: ");
                                id = Console.ReadLine();
                                Console.Write("Please enter name of song: ");
                                name = Console.ReadLine();
                                Console.Write("Please enter artist of song: ");
                                artist = Console.ReadLine();
                                Console.Write("Please enter duration of song in "
                                    + "seconds: ");
                                duration = Console.ReadLine();
                                Console.Write("Please enter genre of song: ");
                                genre = Console.ReadLine();
                                Console.Write("Please enter filename of song: ");
                                filename = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.PUT("songs/" + id,
                                    "name=" + name + "&artist=" + artist
                                    + "&duration=" + duration + "&genre="
                                    + genre + "&path="
                                    + filename));
                                break;
                            case 5:
                                Console.WriteLine();
                                Console.Write("Please enter id of song: ");
                                id = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.DELETE("songs/"
                                    + id));
                                break;
                        }

                        if (option != 6)
                        {
                            Console.WriteLine();
                            Console.Write("Please press any key to continue...");
                            Console.ReadLine();
                        }
                        option = 0;
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Menu:");
                            Console.WriteLine("1. Get All Reviews");
                            Console.WriteLine("2. Get an Specific Review");
                            Console.WriteLine("3. Post a Review");
                            Console.WriteLine("4. Put an Specific Review");
                            Console.WriteLine("5. Delete an Specific Review");
                            Console.WriteLine("6. Cancel");
                            Console.Write("Please enter option: ");

                            if (!Int32.TryParse(Console.ReadLine(), out option)
                                || option < 1 || option > 6)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Option not valid. Please try "
                                    + "again.");
                                Console.WriteLine("");
                            }
                        } while (option < 1 || option > 6);

                        Console.Clear();

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine(RESTService.GET("reviews"));
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.Write("Please enter id of review: ");
                                string id = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.GET("reviews/"
                                    + id));
                                break;
                            case 3:
                                Console.WriteLine();
                                Console.Write("Please enter id of song: ");
                                string songId = Console.ReadLine();
                                Console.Write("Please enter text of review: ");
                                string text = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.POST("reviews",
                                    "songId=" + songId + "&text=" + text));
                                break;
                            case 4:
                                Console.WriteLine();
                                Console.Write("Please enter id of review: ");
                                id = Console.ReadLine();
                                Console.Write("Please enter text of review: ");
                                text = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.PUT("reviews/"
                                    + id, "text=" + text));
                                break;
                            case 5:
                                Console.WriteLine();
                                Console.Write("Please enter id of review: ");
                                id = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine(RESTService.DELETE("reviews/"
                                    + id));
                                break;
                        }

                        if (option != 6)
                        {
                            Console.WriteLine();
                            Console.Write("Please press any key to continue...");
                            Console.ReadLine();
                        }
                        option = 0;
                        break;
                }

                Console.Clear();
            } while (option != 3);
        }
    }
}           