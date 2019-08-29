using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class BheProject
    {
        public string FileName { get; private set; }

        public string DirectoryName { get; private set; }

        public string ProjectText { get; private set; }

        public BheSummary Summary { get; private set; }

        public List<BheSection> Sections { get; } = new List<BheSection>();

        public List<List<BhePatternItem>> Patterns { get; } = new List<List<BhePatternItem>>();

        public List<string> Comments { get; } = new List<string>();

        public static BheProject FromFile(string fileName)
        {
            string directory = Path.GetDirectoryName(fileName);

            var project = new BheProject();
            project.FileName = fileName;
            project.DirectoryName = directory;

            project.ProjectText = File.ReadAllText(Path.Combine(directory, "Project.txt"), Encoding.Default);
            project.Summary = BheSummary.FromFile(Path.Combine(directory, "Summary.txt"));
            project.Sections.AddRange(BheSection.ListFromFile(Path.Combine(directory, "Sections.csv")));

            foreach (string pattern in project.Summary.Patterns)
            {
                string path = Path.Combine(directory, "pat_" + pattern + ".csv");
                project.Patterns.Add(BhePatternItem.ListFromFile(path));
            }

            project.Comments.Add(string.Empty);

            foreach (string comment in project.Summary.Comments.Skip(1))
            {
                string path = Path.Combine(directory, "com_" + comment + ".txt");
                project.Comments.Add(File.ReadAllText(path, Encoding.Default));
            }

            return project;
        }
    }
}
