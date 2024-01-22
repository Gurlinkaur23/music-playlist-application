using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment_05
{
    internal class LabClass
    {
        // Creating a queue and a stack for the song playlist.
        public Stack<string> stackPlaylist = new Stack<string>();
        public Queue<string> queuePlaylist = new Queue<string>();

        /// <summary>
        /// This method checks the validity of the user input song ,i.e., if the song name is not empty or duplicate.
        /// </summary>
        /// <param name="songName"></param>
        /// <returns></returns>
        public bool IsSongNameValid(string songName)
        {
            // Check if the input song is not null or a white space
            if (string.IsNullOrWhiteSpace(songName))
            {
                Console.WriteLine("Please enter a valid song name.");
                return false;
            }

            // Check for duplicate songs
            if (queuePlaylist.Contains(songName))
            {
                Console.WriteLine($"{songName} already exists in your playlist.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method adds the song to the queuePlaylist and stackPlaylist if the song name is valid.
        /// </summary>
        /// <param name="inputSong"></param>
        public void AddSong(string inputSong)
        {
            if (IsSongNameValid(inputSong))
            {
                queuePlaylist.Enqueue(inputSong);
                stackPlaylist.Push(inputSong);
                string currentSong = queuePlaylist.Peek();

                Console.WriteLine($"{inputSong} added to your playlist.");
                Console.WriteLine($"Next song - {currentSong}");
            }
        }

        /// <summary>
        /// This method checks the length of the playlist and then plays the next song in the playlist.
        /// </summary>
        public void PlayNextSong()
        {
            if (queuePlaylist.Count > 1)
            {
                // Removing and getting the first song from the queue and adding it back to preserve the song.
                string currentSong = queuePlaylist.Dequeue();
                queuePlaylist.Enqueue(currentSong);

                Console.WriteLine($"Now playing: {currentSong}");
                Console.WriteLine($"Next song: {queuePlaylist.Peek()}");

            }
            else if (queuePlaylist.Count == 1)
            {
                Console.WriteLine($"Now playing: {queuePlaylist.Peek()}");
                Console.WriteLine("There is no next song to play.");
            }
            else
            {
                Console.WriteLine("There is no next song to play.");
            }
        }

        /// <summary>
        /// This method checks the length of the playlist and skips one song and plays the next one.
        /// </summary>
        public void SkipNextSong()
        {
            if (queuePlaylist.Count > 1)
            {
                // Removing and getting the first song from the queue and adding it back to preserve the song.
                string currentSong = queuePlaylist.Dequeue();
                queuePlaylist.Enqueue(currentSong);
                Console.WriteLine($"Now playing: {currentSong}");

                // Removing and getting the next song from the queue and adding it back to preserve the song.
                string skippedSong = queuePlaylist.Dequeue();
                queuePlaylist.Enqueue(skippedSong);
                Console.WriteLine($"Skipped song: {skippedSong}");

                Console.WriteLine($"Next song: {queuePlaylist.Peek()}");
            }
            else if (queuePlaylist.Count == 1)
            {
                Console.WriteLine($"Now playing: {queuePlaylist.Peek()}");
                Console.WriteLine("You have currently one song in your playlist.");
            }
            else
            {
                Console.WriteLine("Your playlist is empty!");
            }
        }

        private void UpdateStackFromQueue()
        {
            // Create a temporary stack to hold the reversed order of queue elements
            Stack<string> tempStack = new Stack<string>(queuePlaylist.Reverse());

            // Clear the original stack
            stackPlaylist.Clear();

            // Push elements from the temporary stack back to the original stack
            while (tempStack.Count > 0)
            {
                stackPlaylist.Push(tempStack.Pop());
            }
        }

        /// <summary>
        /// This method checks the length of the playlist and rewinds to the previous song.
        /// </summary>
        public void RewindOneSong()
        {
            if (stackPlaylist.Count > 1)
            {
                UpdateStackFromQueue();
                string currentSong = stackPlaylist.Pop();

                Console.WriteLine($"Now playing: {currentSong}");
                Console.WriteLine($"Rewinding to: {stackPlaylist.Peek()}");

                // Push the previous song back to the stack
                stackPlaylist.Push(currentSong);
            }
            else if (stackPlaylist.Count == 1)
            {
                Console.WriteLine($"Now playing: {stackPlaylist.Peek()}");
                Console.WriteLine("There is no previous song to rewind to.");
            }
            else
            {
                Console.WriteLine("There is no song to rewind to");
            }
        }
    }
}
