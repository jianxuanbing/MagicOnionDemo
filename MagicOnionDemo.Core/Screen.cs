using System;

namespace MagicOnionDemo.Core
{
    public static class Screen
    {
        public static void Log(
            string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff")}]"
                              + text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info(string text)
        {
            Log(text, ConsoleColor.White);
        }

        public static void Success(string text)
        {
            Log(text, ConsoleColor.DarkGreen);
        }

        public static void Error(string text)
        {
            Log(text, ConsoleColor.DarkRed);
        }

        public static void Warn(string text)
        {
            Log(text, ConsoleColor.DarkYellow);
        }
    }
}
