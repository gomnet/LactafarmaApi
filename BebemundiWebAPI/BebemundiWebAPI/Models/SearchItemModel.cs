﻿using BebemundiWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BebemundiWebAPI.Models
{
    public class SearchItemModel
    {        
        public string Url { get; set; }
        public SearchItem SearchItem { get; set; }
    }
}