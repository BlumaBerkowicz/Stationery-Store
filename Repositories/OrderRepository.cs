using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository
    {
        private readonly AdoNetContext _AdoNetContext;
        public OrderRepository(AdoNetContext AdoNetContext)
        {
            _AdoNetContext = AdoNetContext;
        }
    }
}
