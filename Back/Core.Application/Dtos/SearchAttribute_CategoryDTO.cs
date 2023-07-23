using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class SearchAttribute_CategoryDTO
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<SearchValue_AttributeDTO> Value_Attributes { get; set; }
    }
}
