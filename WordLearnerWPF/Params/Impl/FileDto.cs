using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Params.Impl
{
    public class FileDto
    {
        public FileDto(string name, string path)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Name { get; set; }
        public string Path { get; set; }
    }
}
