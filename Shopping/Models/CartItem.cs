﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class CartItem
    {
        public int CarId { get; set; }

        public string CarName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get { return Quantity * Price; } }

        public string Image { get; set; }

        public CartItem()
        {

        }

        public CartItem(Car car)
        {
            CarId = car.Id;
            CarName = car.Name;
            Price = car.Price;
            Quantity = 1;
            Image = car.Image;
        }
    }
}
