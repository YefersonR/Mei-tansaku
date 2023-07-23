using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class SearchPreviewCategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SearchAttribute_CategoryDTO> Attribute_Categories { get; set; }
    }
}
