using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class SearchProductDTO
    {
        public List<SearchPreviewProductItemDTO> SearchPreviewProductItemDTO { get; set; }
        public List<SearchPreviewCategoryDTO> SearchPreviewCategoryDTO { get; set; }
    }
}
