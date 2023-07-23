using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Application.Feactures.Products.Queries.SearchProducts
{
    public class SearchProductsQuery : IRequest<SearchProductDTO>
    {
        public string Name { get; set; }
        public int? CategoryID { get; set; }
    }

    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductDTO>
    {
        private readonly IValue_AttributeRepository _value_AttributeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SearchProductsQueryHandler(IProductRepository productRepository, IMapper mapper, IValue_AttributeRepository value_AttributeRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _value_AttributeRepository = value_AttributeRepository;
        }

        public async Task<SearchProductDTO> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            SearchProductDTO data = new SearchProductDTO();
            List<SearchPreviewCategoryDTO> completeCategory = new List<SearchPreviewCategoryDTO>();
            var product = await _productRepository.SearchProduct(request.Name);
            data.SearchPreviewProductItemDTO = _mapper.Map<List<SearchPreviewProductItemDTO>>(product.Item1);
            data.SearchPreviewCategoryDTO = _mapper.Map<List<SearchPreviewCategoryDTO>>(product.Item2);
            foreach(var x in data.SearchPreviewCategoryDTO)
            {
                foreach(var i in x.Attribute_Categories)
                {
                    i.Value_Attributes = _mapper.Map<List<SearchValue_AttributeDTO>>(await _value_AttributeRepository.GetByAttributeCategoryID(i.Id));
                }
            }
            return data;
        }
    }
}
