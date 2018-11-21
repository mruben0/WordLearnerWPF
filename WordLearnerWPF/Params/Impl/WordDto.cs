using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Params.Impl
{
    public class WordDto
    {
        public WordDto(string key, string value, string letter, string number, string fileName = null)
        {
            Key = key;
            Value = value;
            Letter = letter;
            Number = number;
            FileName = fileName;
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Letter { get; set; }

        public string Number { get; set; }

        public string FileName { get; set; }
    }
}
