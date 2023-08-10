using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class ProductResponseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public string Availability { get; set; }
        public int Stock { get; set; }
        public double Weight { get; set; }
        public string Address { get; set; }
        public int TotalRating { get; set; }
        public string ImageUrl { get; set; }
        public List<CommentsDTO> Comments { get; set; }
        public List<string> Product_Images { get; set; }

    }
}
