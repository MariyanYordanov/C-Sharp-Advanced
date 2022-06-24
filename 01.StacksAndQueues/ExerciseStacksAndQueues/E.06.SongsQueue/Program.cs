using System;
using System.Collections.Generic;

namespace E._06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);
            string command = Console.ReadLine();
            while (songs.Count > 0)
            {
                
                if (command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string currentSong = command.Remove(0,4);
                    if (!songs.Contains(currentSong))
                    {
                        songs.Enqueue(currentSong);
                    }
                    else
                    {
                        Console.WriteLine($"{currentSong} is already contained!");
                    }
                }
                else if (command.Contains("Show")) 
                {
                    Console.WriteLine(string.Join(", ",songs));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
