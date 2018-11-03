using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearnerWPF.Params.Abstract;
using WordLearnerWPF.Services.Abstract;

namespace WordLearnerWPF.Services.Impl
{
    public class IOService : IIOService
    {
        private IStaticParams _staticParams;

        public IOService(IStaticParams staticParams)
        {
            _staticParams = staticParams ?? throw new ArgumentNullException(nameof(staticParams));
        }

        public string AddFile()
        {
            string FileName;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() ?? false)
            {
                FileName = Path.GetFileName(dlg.FileName);
                var dest = Path.Combine(_staticParams.DocumentFolderPath, FileName);
                File.Copy(dlg.FileName, dest, true);
                return dest;
            }
            else return null;
        }
    }
}
