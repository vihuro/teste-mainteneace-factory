﻿namespace TesteMainteneace.Application.UseCases.OrderService.CreateOrderService
{
    public sealed record CreateOrderServiceResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LocaleManinteace { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Priority { get; set; }
        public string TypeService { get; set; }
    }
}
