using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class SearchProductDTO
    {
        public List<PreviewProductItemDTO> PreviewProductItemDTO { get; set; }
        public List<PreviewCategoryDTO> PreviewCategoryDTO { get; set; }
    }
}
