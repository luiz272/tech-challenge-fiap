﻿using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProductsTagsRepository : EfRepository<Product>, IProductRepository
    {
        public ProductsTagsRepository(TechContext context) : base(context)
        {

        }
    }
}