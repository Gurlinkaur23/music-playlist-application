using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LabClass lc = new LabClass();

                Console.WriteLine("- * - * - * - * - * - * - * - * - ");
                Console.WriteLine("PLAYLIST APP");

                while (true)
                {
                    Console.WriteLine("- * - * - * - * - * - * - * - * - ");
                    Console.WriteLine();
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add a song to your playlist");
                    Console.WriteLine("2. Play the next song in your playlist");
                    Console.WriteLine("3. Skip the next song");
                    Console.WriteLine("4. Rewind one song");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine();

                    Console.Write("Select option: ");
                    string userChoice = Console.ReadLine();
                    Console.WriteLine();

                    if (int.TryParse(userChoice, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter song name: ");
                                string inputUserSong = Console.ReadLine();
                                lc.AddSong(inputUserSong);
                                break;
                            case 2:
                                lc.PlayNextSong();
                                break;
                            case 3:
                                lc.SkipNextSong();
                                break;
                            case 4:
                                lc.RewindOneSong();
                                break;
                            case 5:
                                Console.WriteLine("Exiting the application.");
                                return;
                            default:
                                Console.WriteLine("Invalid option. Please choose a valid number for the options.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please choose a valid number for the options.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
