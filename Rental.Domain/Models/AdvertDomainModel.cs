﻿namespace Rental.Domain.Models
{
    public class AdvertDomainModel
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int Footage { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }

        public string UserId { get; set; }
        public UserDomainModel User { get; set; }
        public AdvertTypeDomainModel Type { get; set; }
        public AddressDomainModel Address { get; set; }
    }
}
