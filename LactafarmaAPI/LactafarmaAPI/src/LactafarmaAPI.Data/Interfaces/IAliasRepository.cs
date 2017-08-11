﻿using LactafarmaAPI.Core.Interfaces;
using LactafarmaAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LactafarmaAPI.Data.Interfaces
{
    public interface IAliasRepository : IDataRepository<Alias>
    {
        IEnumerable<AliasMultilingual> GetAliasesByDrug(int drugId);

        Drug GetDrugByAlias(int aliasId);

        Alias GetAlias(int aliasId);

    }
}
