using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Params.Abstract
{
    public interface IStaticParams
    {
       string AppFolderPath { get; set; }
       string DocumentFolderPath { get; set; }
       string SettingsDirectory { get; set; }
       IList<string> FoldersToCreate { get; set; }
    }
}
