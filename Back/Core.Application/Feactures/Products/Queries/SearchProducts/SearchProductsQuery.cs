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
        public List<int>? values { get; set; }
    }

    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductDTO>
    {
        private readonly IValue_AttributeRepository _value_AttributeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProduct_ImagesRepository _product_ImagesRepository;
        private readonly IMapper _mapper;

        public SearchProductsQueryHandler(IProductRepository productRepository, IMapper mapper, IValue_AttributeRepository value_AttributeRepository, IProduct_ImagesRepository product_ImagesRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _value_AttributeRepository = value_AttributeRepository;
            _product_ImagesRepository = product_ImagesRepository;
        }

        public async Task<SearchProductDTO> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            SearchProductDTO data = new SearchProductDTO();
            List<SearchPreviewCategoryDTO> completeCategory = new List<SearchPreviewCategoryDTO>();

            var product = await _productRepository.SearchProduct(request.Name, request.values);

            data.SearchPreviewProductItemDTO = _mapper.Map<List<SearchPreviewProductItemDTO>>(product.Item1);
            data.SearchPreviewCategoryDTO = _mapper.Map<List<SearchPreviewCategoryDTO>>(product.Item2);

            foreach(var x in data.SearchPreviewCategoryDTO)
            {
                foreach(var i in x.Attribute_Categories)
                {
                    i.Value_Attributes = _mapper.Map<List<SearchValue_AttributeDTO>>(await _value_AttributeRepository.GetByAttributeCategoryID(i.Id));
                }
            }

            foreach(var i in data.SearchPreviewProductItemDTO)
            {
                i.ImageUrl = await _product_ImagesRepository.GetFirtImg(i.ID);
            }
            return data;
        }
    }
}
