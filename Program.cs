using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace FisCool
{
    class Program
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private static readonly Random _random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                int random_location1 = _random.Next(0, 10000);
                int random_location2 = _random.Next(0, 10000);
                Console.WriteLine(random_location1 + " " + random_location2);
                MoveTo(random_location1, random_location2);
                Thread.Sleep(1000 * 60 * 5);//wait for 10 min
            }
        }

        public static void MoveTo(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
    }
}
