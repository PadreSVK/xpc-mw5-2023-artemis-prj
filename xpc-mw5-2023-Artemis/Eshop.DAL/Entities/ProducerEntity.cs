﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAL.Entities
{
    internal class ProducerEntity
    {
        //TODO implementaion of IEntity = ID

        public string Name { get; set; }

        public string Image { get; set; }

        public string Country { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
