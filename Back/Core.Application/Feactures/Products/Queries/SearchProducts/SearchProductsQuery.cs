using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Products.Queries.SearchProducts
{
    public class SearchProductsQuery : IRequest<SearchProductDTO>
    {
        public string Name { get; set; }
        public int? CategoryID { get; set; }
    }

    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductDTO>
    {
        private readonly IProductRepository _productRepository;

        public SearchProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<SearchProductDTO> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
