using System;

namespace SoftwareCatalog.Core
{
    public class SoftInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Path { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
