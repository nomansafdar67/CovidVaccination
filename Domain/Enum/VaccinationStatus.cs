using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enum
{
    [Flags]
    public enum VacinationStatus : short
    {
        NotVaccinated = 0,
        PartiallyVaccinated = 1,
        FullyVaccinated = 2
    }
}
