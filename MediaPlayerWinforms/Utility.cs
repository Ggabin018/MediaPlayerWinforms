﻿using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;

namespace MediaPlayerWinforms
{
    public static class Utility
    {
        public static byte[] Compress(string text)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(text);

            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gzipStream.Write(byteArray, 0, byteArray.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static string Decompress(byte[] compressedData)
        {
            using (var memoryStream = new MemoryStream(compressedData))
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzipStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static bool ControlIsHover(Control control)
        {
            Point cursorPosition = Cursor.Position;

            Point clientCursorPos = control.PointToClient(cursorPosition);

            return control.ClientRectangle.Contains(clientCursorPos);
        }

        public static async void SrtMake(string parentPath, string filePath, string model)
        {
            string command = $@"& '{parentPath}\.venv\Scripts\python.exe' '{parentPath}\main.py' --path '{filePath}' --model '{model}'";
            Console.WriteLine(command);

            await ExecutePowerShellCommandAsync(command);
        }
        static async Task ExecutePowerShellCommandAsync(string command)
        {
            // Configure the process to use PowerShell
            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                UseShellExecute = true,  // Required to show the window
                CreateNoWindow = false,  // Ensure the window is created
                WindowStyle = ProcessWindowStyle.Normal
            };

            // Start the process
            using (var process = new Process { StartInfo = processInfo })
            {
                try
                {
                    Console.WriteLine("Start Srt creation");
                    process.Start();

                    // Wait for the process to exit
                    await Task.Run(() => process.WaitForExit());

                    Console.WriteLine("End Srt creation");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public static T NextEnum<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Arggument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr,src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static void WriteLineColor<T>(T text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
