using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace simpletool
{
    class Program
    {
        static void Main(string[] args)
        {
            using(BinaryWriter writer = new BinaryWriter(File.Open("output.bss", FileMode.OpenOrCreate)))
            {
                writer.Write("bss1");
                writer.Write(@"texture/test_kit.png");
                writer.Write((Int32)56);
                writer.Write((Int32)80);
                writer.Write((Int32)8);
                MakeFrame(writer, 0, "idle");
                MakeFrame(writer, 1, "lookdown");
                MakeFrame(writer, 2, "jump");
                MakeFrame(writer, 3, "hit");
                MakeFrame(writer, 4, "run");
                MakeFrame(writer, 5, "skid"); //stanky leg
                MakeFrame(writer, 6, "swim");
                MakeFrame(writer, 7, "hurt");
            }
        }

        static void MakeFrame(BinaryWriter writer, int n, string name)
        {
            //Frame header.
            writer.Write(name);
            writer.Write((Int32)4);

            //And three frames.
            writer.Write((Int32)0);
            writer.Write((Int32)80 * n);
            writer.Write((float)0.33f * 2);
            writer.Write((Int32)56);
            writer.Write((Int32)80 * n);
            writer.Write((float)0.33f * 2);
            writer.Write((Int32)112);
            writer.Write((Int32)80 * n);
            writer.Write((float)0.33f * 2);
            writer.Write((Int32)56);
            writer.Write((Int32)80 * n);
            writer.Write((float)0.33f * 2);
        }
    }
}
