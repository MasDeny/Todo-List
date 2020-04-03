using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Domain.Models.Enum
{
    // enumeration data
    public enum EStatus : byte
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Done")]
        Done = 2,
    }
}
