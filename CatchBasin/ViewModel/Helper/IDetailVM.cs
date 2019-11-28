using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel.Helper
{
    interface IDetailVM
    {
        void Save();
        void Cancel();
        void Clear();
        void Update();
    }
}
