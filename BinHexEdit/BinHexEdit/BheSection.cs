using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class BheSection
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PatternId { get; set; }

        public int BaseOffset { get; set; }

        public static List<BheSection> ListFromFile(string fileName)
        {
            var sections = new List<BheSection>();

            using (var file = new StreamReader(fileName))
            {
                int count = int.Parse(file.ReadLine().Split(',')[0], CultureInfo.InvariantCulture);

                for (int i = 0; i < count; i++)
                {
                    var section = new BheSection();
                    string[] parts = file.ReadLine().Split(',');

                    section.Id = i + 1;
                    section.Name = parts[0];
                    section.PatternId = int.Parse(parts[1], CultureInfo.InvariantCulture);
                    section.BaseOffset = int.Parse(parts[2], CultureInfo.InvariantCulture);

                    sections.Add(section);
                }
            }

            return sections;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3}", this.Id, this.Name, this.PatternId, this.BaseOffset);
        }
    }
}
