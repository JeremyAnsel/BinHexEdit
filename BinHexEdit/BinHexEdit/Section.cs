using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BinHexEdit
{
    public sealed class Section
    {
        public Project Project { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BaseOffset { get; set; }

        public List<PatternItem> Patterns { get; } = new List<PatternItem>();

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}/{1}] {2} {3}", this.Id, this.Project.Sections.Count, this.BaseOffset, this.Name);
        }
    }
}
