﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LactafarmaAPI.Controllers.Api.Interfaces
{
    interface IGroupsController
    {
        JsonResult GetGroupsByName(string startsWith);
        JsonResult GetGroup(int groupId);

    }
}
