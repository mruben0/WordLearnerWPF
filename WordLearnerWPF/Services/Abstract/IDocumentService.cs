using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Services.Abstract
{
    public interface IDocumentService
    {
        Dictionary<string, string> GetDictionaryFromXls(string path, int start, int end, string askLabel = "A", string answLabel = "B");

    }
}
