using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTech.Application.DTOs.Product.Response
{
    public class GetAllProductsResponseDto
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
