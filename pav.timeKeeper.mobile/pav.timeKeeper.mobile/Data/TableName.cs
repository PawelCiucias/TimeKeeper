using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace pav.timeKeeper.mobile.Data
{
    [DebuggerDisplay("{DebuggerDisplay()}")]
    class TableName
    {
        public string name { get; set; }

        private string DebuggerDisplay() => name;
    }
}
