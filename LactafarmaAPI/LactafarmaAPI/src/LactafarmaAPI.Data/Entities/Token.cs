﻿using LactafarmaAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LactafarmaAPI.Data.Entities
{
    public class Token : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Hash { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid UserId { get; set; }

        //Navigation Properties
        public User User { get; set; }

        public Guid EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
