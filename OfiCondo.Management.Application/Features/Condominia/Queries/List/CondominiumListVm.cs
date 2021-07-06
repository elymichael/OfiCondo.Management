using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Condominia.Queries.List
{
    public class CondominiumListVm
    {
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
    }
}
