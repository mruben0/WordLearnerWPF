using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Services.Abstract
{
    public interface IDocumentService
    {
        bool IsValidFormat(string format, string path);
        List<string> AddToList(string path, int start, int end, string label = "A");
    }
}
