using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class ConsoleInterface
    {
        private string WriteBuffer { get; set; }
        private string ReadBuffer { get; set; }
        private string WriteMemory { get; set; }
        private string ReadMemory { get; set; }
        public string Input
        {
            get { return ReadBuffer; }
        }

        public ConsoleInterface(string StartingText)
        {
            WriteToBuffer(StartingText);
            ReadMemory = "";
            ReadBuffer = "";
            Render();
        }

        public void WriteToBuffer(string value)
        {
            WriteBuffer = value;
        }

        public void Render()
        {
            WriteMemory = null;
            Console.WriteLine(WriteBuffer);
            WriteMemory = WriteBuffer;
        }

        public void ReadToBuffer()
        {
            ReadMemory = "";
            ReadMemory = ReadBuffer;
            ReadBuffer = "";
            ReadBuffer = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine("\r\n");
        }

        public void Clear()
        {
            Console.Clear();
            WriteBuffer = WriteMemory;
            Render();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
