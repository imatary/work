using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HondaLookSupports
{
    public sealed class MyClassMap : CsvClassMap<MyClass>
    {
        public MyClassMap()
        {
            Map(ex => ex.ColA).Index(0);
            Map(ex => ex.ColB).Index(1);
            Map(ex => ex.ColC).Index(2);
            Map(ex => ex.ColD).Index(3);
            Map(ex => ex.ColE).Index(4);
            Map(ex => ex.ColF).Index(5);
            Map(ex => ex.ColG).Index(6);
            Map(ex => ex.ColH).Index(7);
        }
    }
}
