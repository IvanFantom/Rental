﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Models
{
    public class AddressDomainModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

        public long AdvertId { get; set; }
        public virtual AdvertDomainModel Advert { get; set; }
    }
}