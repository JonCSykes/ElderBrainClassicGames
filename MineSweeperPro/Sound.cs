using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
 
    public class Sound
    {
        public static readonly string FlagOnSound = "switch_006.wav";
        public static readonly string FlagOffSound = "switch_002.wav";
        public static readonly string ExplodeSound = "explosion.wav";
        public static readonly string CellRevealSound = "bong_001.wav";
        public static readonly string ClusterRevealSound = "confirmation_004.wav";
        public static readonly string WinSound = "jingles_SAX10.wav";
        public static readonly string GameOverSound = "boom_gameover.wav"; 

        private Queue<string> soundQueue = new Queue<string>();
        private SoundPlayer soundPlayer = new SoundPlayer();
        private CancellationTokenSource cancellationTokenSource;
        private Task playbackTask;

        public void AddToQueue(string soundName) {

            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(exePath, "Assets", soundName);

            soundQueue.Enqueue(filePath);

            if (playbackTask == null || playbackTask.IsCompleted)
            {
                cancellationTokenSource = new CancellationTokenSource();
                playbackTask = Task.Run(() => PlaySoundsFromQueue(cancellationTokenSource.Token, 200));
            }
        }

        public void AddToQueue(string soundName, int delay) 
        {
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(exePath, "Assets", soundName);

            soundQueue.Enqueue(filePath);
            
            if (playbackTask == null || playbackTask.IsCompleted)
            {
                cancellationTokenSource = new CancellationTokenSource();
                playbackTask = Task.Run(() => PlaySoundsFromQueue(cancellationTokenSource.Token, delay));
            }
        }
        
        public void Play(string soundName) 
        {
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(exePath, "Assets", soundName);

            soundPlayer.SoundLocation = filePath;
            soundPlayer.Play();
        }

        public void Stop()
        {
            cancellationTokenSource?.Cancel();
            soundPlayer?.Stop();
        }

        private async Task PlaySoundsFromQueue(CancellationToken cancellationToken, int delay)
        {
            while (soundQueue.Count > 0)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                string nextSoundFile = soundQueue.Peek();
                soundPlayer.SoundLocation = nextSoundFile;

                soundPlayer.Play();

                TaskCompletionSource<object> completionSource = new TaskCompletionSource<object>();
                var delayTask = Task.Delay(delay); // Adjust the delay as needed

                await Task.WhenAny(delayTask, completionSource.Task);

                if (delayTask.IsCompleted)
                {
                    // Delay task completed before sound playback finished
                    completionSource.TrySetResult(null);
                    await completionSource.Task;
                }


                soundQueue.Dequeue();
            }
        }



    }
}
