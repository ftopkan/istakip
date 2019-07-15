﻿using Project.DAL.Context;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class ResultDemandRepository : Repository<ResultDemand>
    {
        public ResultDemandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
