using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? OrderSum { get; set; }

        public int? UserId { get; set; }
        public virtual ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
}