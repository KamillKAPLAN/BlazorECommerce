﻿using eShop.CoreBusiness.Models;

namespace eShop.CoreBusiness.Services
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInformation(string name, string address, string city, string province, string county);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}