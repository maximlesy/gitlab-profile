﻿using MaxxFluent.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxxFluent.Interfaces
{
    public interface IStartBuildingStage
    {
        IFloorsStage StartBuild();
    }
}