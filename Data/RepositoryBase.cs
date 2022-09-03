using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class RepositoryBase
    {
        protected readonly CCCDBContext _context;

        public RepositoryBase(CCCDBContext context)
        {
            _context = context;
        }
    }
}
