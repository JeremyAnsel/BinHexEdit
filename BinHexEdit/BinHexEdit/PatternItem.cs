using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class PatternItem
    {
        private string value;

        public Section Section { get; set; }

        public int GlobalOffset
        {
            get
            {
                return this.Section.BaseOffset + this.Offset;
            }
        }

        public int Offset { get; set; }

        public string Name { get; set; }

        public BheDataType DataType { get; set; }

        public int DataLength { get; set; }

        public string Comment { get; set; }

        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value != this.value)
                {
                    switch (this.DataType)
                    {
                        case BheDataType.Byte:
                            byte.Parse(value, CultureInfo.InvariantCulture);
                            break;

                        case BheDataType.Int16:
                            short.Parse(value, CultureInfo.InvariantCulture);
                            break;

                        case BheDataType.Int32:
                            int.Parse(value, CultureInfo.InvariantCulture);
                            break;

                        case BheDataType.String:
                            if (Encoding.ASCII.GetByteCount(value) >= this.DataLength)
                            {
                                throw new ArgumentOutOfRangeException("value");
                            }

                            break;

                        case BheDataType.Double:
                            double.Parse(value, CultureInfo.InvariantCulture);
                            break;

                        case BheDataType.Single:
                            float.Parse(value, CultureInfo.InvariantCulture);
                            break;

                        case BheDataType.UInt16:
                            ushort.Parse(value, CultureInfo.InvariantCulture);
                            break;
                    }

                    this.value = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4}", this.GlobalOffset, this.Offset, this.Name, this.DataType, this.DataLength);
        }
    }
}
