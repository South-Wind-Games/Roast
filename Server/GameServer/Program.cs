using System;
using System.Threading;

namespace GameServer
{
    class Program
    {
        private static bool isRunning = false;
        static void Main(string[] args)
        {
            isRunning = true;
            Console.Title = "Roast Game Server";

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.Start(6, 26950);

        }

        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TICS_PER_SEC} ticks per second.");
            DateTime nextLoop = DateTime.Now;

            while (isRunning)
            {
                while (nextLoop < DateTime.Now)
                {
                    GameLogic.Update();

                    nextLoop = nextLoop.AddMilliseconds(Constants.MS_PER_TIC);

                    if (nextLoop > DateTime.Now)
                        Thread.Sleep(nextLoop - DateTime.Now);
                }
            }
        }
    }
}
