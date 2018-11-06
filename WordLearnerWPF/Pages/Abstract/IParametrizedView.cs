using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WordLearnerWPF.Pages.Abstract
{
    public interface IParametrizedView<Tparam> where Tparam : class
    {
       Tparam Parameter { get; set; }
    }
}
