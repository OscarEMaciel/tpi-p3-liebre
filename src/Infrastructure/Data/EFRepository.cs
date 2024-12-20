﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        protected new readonly ApplicationContext _context;
        public EfRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
