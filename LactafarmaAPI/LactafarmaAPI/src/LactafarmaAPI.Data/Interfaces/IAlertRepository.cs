﻿using LactafarmaAPI.Core.Interfaces;
using LactafarmaAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LactafarmaAPI.Data.Interfaces
{
    public interface IAlertRepository : IDataRepository<Alert>
    {
        IEnumerable<Alert> GetAllAlerts();
        IEnumerable<Alert> GetAlertsByDrug(int drugId);

    }
}