using System;
using System.Collections.Generic;
using System.IO;
using WordLearnerWPF.Params.Abstract;

namespace WordLearnerWPF.Params.Impl
{
    public class StaticParams : IStaticParams
    {
        private string WLFolder = "WordLearner";
        
        public StaticParams()
        {
            AppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WLFolder);
            DocumentFolderPath = Path.Combine(AppFolderPath, "Documents");
            SettingsDirectory = Path.Combine(AppFolderPath, "Params");
            SettingsFile = Path.Combine(SettingsDirectory, "Settings");
            FoldersToCreate = new List<string>()
            {
                AppFolderPath,
                DocumentFolderPath,
                SettingsDirectory,
            };
            FilesToCeate = new List<string>()
            {
                SettingsFile
            };

        }

        public string AppFolderPath { get; set; }
        public string DocumentFolderPath { get; set; }
        public string SettingsDirectory { get; set; }
        public string SettingsFile { get; set; }
        public IList<string> FoldersToCreate { get; set; }
        public IList<string> FilesToCeate { get; set; }
    }
}
