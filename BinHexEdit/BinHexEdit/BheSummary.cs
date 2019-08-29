using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class BheSummary
    {
        public string ProjectName { get; set; }

        public string IconPath { get; set; }

        public string BinFilePath { get; set; }

        public List<string> Patterns { get; } = new List<string>();

        public List<string> Comments { get; } = new List<string>();

        public static BheSummary FromFile(string fileName)
        {
            var sum = new BheSummary();

            using (var file = new StreamReader(fileName, Encoding.Default))
            {
                sum.ProjectName = BheSummary.ReadString(file, "[Project]");
                sum.IconPath = BheSummary.ReadString(file, "[Icon]");
                sum.BinFilePath = BheSummary.ReadString(file, "[File]");
                sum.Patterns.AddRange(BheSummary.ReadStringList(file, "[Patterns]"));
                sum.Comments.AddRange(BheSummary.ReadStringList(file, "[Comments]"));
            }

            return sum;
        }

        public void Save(string fileName)
        {
            using (var file = new StreamWriter(fileName, false, Encoding.Default))
            {
                file.WriteLine("[Project]");
                file.WriteLine("1");
                file.WriteLine(this.ProjectName);
                file.WriteLine();

                file.WriteLine("[Icon]");
                file.WriteLine("1");
                file.WriteLine(this.IconPath);
                file.WriteLine();

                file.WriteLine("[File]");
                file.WriteLine("1");
                file.WriteLine(this.BinFilePath);
                file.WriteLine();

                file.WriteLine("[Patterns]");
                file.WriteLine(this.Patterns.Count);

                foreach (string pattern in this.Patterns)
                {
                    file.WriteLine(pattern);
                }

                file.WriteLine();

                file.WriteLine("[Comments]");
                file.WriteLine(this.Comments.Count);

                foreach (string comment in this.Comments)
                {
                    file.WriteLine(comment);
                }

                file.WriteLine();
            }
        }

        private static string ReadString(StreamReader file, string sectionName)
        {
            while (!file.EndOfStream && (file.ReadLine()) != sectionName)
            {
            }

            int count = int.Parse(file.ReadLine(), CultureInfo.InvariantCulture);

            if (count != 1)
            {
                throw new InvalidDataException(sectionName + " count != 1");
            }

            return file.ReadLine();
        }

        private static List<string> ReadStringList(StreamReader file, string sectionName)
        {
            while (!file.EndOfStream && (file.ReadLine()) != sectionName)
            {
            }

            int count = int.Parse(file.ReadLine(), CultureInfo.InvariantCulture);

            var list = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                list.Add(file.ReadLine());
            }

            return list;
        }
    }
}
