using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class BhePatternItem
    {
        public int Offset { get; set; }

        public string Name { get; set; }

        public BheDataType DataType { get; set; }

        public int DataLength { get; set; }

        public int CommentId { get; set; }

        public static List<BhePatternItem> ListFromFile(string fileName)
        {
            var items = new List<BhePatternItem>();

            using (var file = new StreamReader(fileName))
            {
                int count = int.Parse(file.ReadLine().Split(',')[0], CultureInfo.InvariantCulture);

                for (int i = 0; i < count; i++)
                {
                    var item = new BhePatternItem();
                    string[] parts = file.ReadLine().Split(',');

                    item.Offset = int.Parse(parts[0], CultureInfo.InvariantCulture);
                    item.Name = parts[1];
                    item.DataType = (BheDataType)int.Parse(parts[2], CultureInfo.InvariantCulture);

                    if (!string.IsNullOrEmpty(parts[3]))
                    {
                        item.DataLength = int.Parse(parts[3], CultureInfo.InvariantCulture);
                    }

                    item.CommentId = int.Parse(parts[4], CultureInfo.InvariantCulture);

                    items.Add(item);
                }
            }

            return items;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4}", this.Offset, this.Name, this.DataType, this.DataLength, this.CommentId);
        }
    }
}
