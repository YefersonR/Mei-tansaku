using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class Shopping_ListDTO
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public bool Default { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public List<Product_ListDTO> Product_Lists { get; set; }
        public List<SearchPreviewProductItemDTO> Products { get; set; }
    }
}
