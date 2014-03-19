using System;
using System.Reflection;
using System.Runtime.InteropServices;
using FubuCore.CommandLine;

namespace Core
{
    public class ConsoleApp
    {
        protected static ICommandFactory Bootstrap(Assembly assembly)
        {
            var commandFactory = new CommandFactory();
            commandFactory.RegisterCommands(assembly);
            return commandFactory;
        }

        protected static void MoveWindow(int left, int top)
        {
            var handle = GetConsoleWindow();
            RECT rect = new RECT();
            GetWindowRect(handle, ref rect);
            MoveWindow(handle, left, top, rect.right - rect.left, rect.bottom - rect.top, true);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll")]
        private extern static bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        } 
    }
}