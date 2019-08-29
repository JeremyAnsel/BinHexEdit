using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class Project
    {
        public string FileName { get; private set; }

        public string FileNameShort
        {
            get
            {
                return Path.GetFileName(this.FileName);
            }
        }

        public string DirectoryName { get; private set; }

        public string ProjectText { get; private set; }

        public string ProjectName { get; private set; }

        public string IconPath { get; private set; }

        public string BinFilePath { get; set; }

        public string BinFileName
        {
            get
            {
                return Path.GetFileName(this.BinFilePath);
            }
        }

        public List<Section> Sections { get; } = new List<Section>();

        private BheSummary Summary { get; set; }

        public static Project FromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            var bhe = BheProject.FromFile(fileName);
            var project = new Project();

            project.FileName = bhe.FileName;
            project.DirectoryName = bhe.DirectoryName;
            project.ProjectText = bhe.ProjectText;
            project.ProjectName = bhe.Summary.ProjectName;
            project.IconPath = bhe.Summary.IconPath;
            project.BinFilePath = bhe.Summary.BinFilePath;

            for (int sectionIndex = 0; sectionIndex < bhe.Sections.Count; sectionIndex++)
            {
                var bheSection = bhe.Sections[sectionIndex];
                var section = new Section();

                section.Project = project;
                section.Id = bheSection.Id;
                section.Name = bheSection.Name;
                section.BaseOffset = bheSection.BaseOffset;

                var bhePatterns = bhe.Patterns[bheSection.PatternId - 1];

                foreach (BhePatternItem bheItem in bhePatterns)
                {
                    var item = new PatternItem();

                    item.Section = section;
                    item.Offset = bheItem.Offset;
                    item.Name = bheItem.Name;
                    item.DataType = bheItem.DataType;
                    item.DataLength = bheItem.DataLength;
                    item.Comment = bhe.Comments[bheItem.CommentId - 1];

                    section.Patterns.Add(item);
                }

                project.Sections.Add(section);
            }

            project.Summary = bhe.Summary;

            return project;
        }

        public void SaveSummary()
        {
            this.Summary.BinFilePath = this.BinFilePath;

            this.Summary.Save(Path.Combine(this.DirectoryName, "Summary.txt"));
        }

        public void LoadValues()
        {
            if (!File.Exists(this.BinFilePath))
            {
                throw new FileNotFoundException(null, this.BinFilePath);
            }

            using (var file = File.OpenRead(this.BinFilePath))
            {
                foreach (var section in this.Sections)
                {
                    foreach (var pattern in section.Patterns)
                    {
                        file.Seek(pattern.GlobalOffset, SeekOrigin.Begin);
                        var reader = new BinaryReader(file, Encoding.ASCII);
                        string data;

                        switch (pattern.DataType)
                        {
                            case BheDataType.Byte:
                                data = reader.ReadByte().ToString(CultureInfo.InvariantCulture);
                                break;

                            case BheDataType.Int16:
                                data = reader.ReadInt16().ToString(CultureInfo.InvariantCulture);
                                break;

                            case BheDataType.Int32:
                                data = reader.ReadInt32().ToString(CultureInfo.InvariantCulture);
                                break;

                            case BheDataType.String:
                                data = new string(reader.ReadChars(pattern.DataLength - 1).TakeWhile(t => t != '\0').ToArray());
                                break;

                            case BheDataType.Double:
                                data = reader.ReadDouble().ToString(CultureInfo.InvariantCulture);
                                break;

                            case BheDataType.Single:
                                data = reader.ReadSingle().ToString(CultureInfo.InvariantCulture);
                                break;

                            case BheDataType.UInt16:
                                data = reader.ReadUInt16().ToString(CultureInfo.InvariantCulture);
                                break;

                            default:
                                throw new InvalidDataException();
                        }

                        pattern.Value = data;
                    }
                }
            }
        }

        public void WriteValues()
        {
            if (!File.Exists(this.BinFilePath))
            {
                throw new FileNotFoundException(null, this.BinFilePath);
            }

            using (var file = File.OpenWrite(this.BinFilePath))
            {
                foreach (var section in this.Sections)
                {
                    foreach (var pattern in section.Patterns)
                    {
                        file.Seek(pattern.GlobalOffset, SeekOrigin.Begin);
                        var writer = new BinaryWriter(file, Encoding.ASCII);

                        switch (pattern.DataType)
                        {
                            case BheDataType.Byte:
                                writer.Write(byte.Parse(pattern.Value, CultureInfo.InvariantCulture));
                                break;

                            case BheDataType.Int16:
                                writer.Write(short.Parse(pattern.Value, CultureInfo.InvariantCulture));
                                break;

                            case BheDataType.Int32:
                                writer.Write(int.Parse(pattern.Value, CultureInfo.InvariantCulture));
                                break;

                            case BheDataType.String:
                                if (Encoding.ASCII.GetByteCount(pattern.Value) >= pattern.DataLength)
                                {
                                    throw new InvalidDataException();
                                }
                                else
                                {
                                    var buffer = new byte[pattern.DataLength];
                                    Encoding.ASCII.GetBytes(pattern.Value).CopyTo(buffer, 0);
                                    writer.Write(buffer);
                                }

                                break;

                            case BheDataType.Double:
                                writer.Write(double.Parse(pattern.Value, CultureInfo.InvariantCulture));
                                break;

                            case BheDataType.Single:
                                writer.Write(float.Parse(pattern.Value, CultureInfo.InvariantCulture));
                                break;

                            case BheDataType.UInt16:
                                writer.Write(ushort.Parse(pattern.Value, CultureInfo.InvariantCulture));
                                break;

                            default:
                                throw new InvalidDataException();
                        }
                    }
                }
            }
        }
    }
}
