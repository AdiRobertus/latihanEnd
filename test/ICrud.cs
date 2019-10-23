using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    interface ICrud<T>
    {
        T Data { get; set; }
        bool IsInserting { get; set; }
        void NormalMode();
        void SaveMode();
        void SaveData();
        bool IsValid();
        void LoadData();
    }
}
