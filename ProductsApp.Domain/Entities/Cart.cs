﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
