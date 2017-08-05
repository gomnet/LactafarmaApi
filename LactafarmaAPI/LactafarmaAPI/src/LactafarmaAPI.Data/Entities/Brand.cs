﻿using LactafarmaAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LactafarmaAPI.Data.Entities
{
    public class Brand : IIdentifiableEntity
    {
        public int Id { get; set; }

        //Navigation Properties
        public virtual ICollection<DrugBrand> DrugBrands { get; set; }
        public virtual ICollection<BrandMultilingual> BrandsMultilingual { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
