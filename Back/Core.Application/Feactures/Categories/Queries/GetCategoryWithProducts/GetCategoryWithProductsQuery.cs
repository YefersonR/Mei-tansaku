using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Categories.Queries.GetCategoryById
{
    public class GetCategoryWithProductsQuery : IRequest<ProductsByCategoryDTO>
    {
        public int ID { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<int>? Values { get; set; }
    }
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryWithProductsQuery, ProductsByCategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValue_AttributeRepository _value_AttributeRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, IValue_AttributeRepository value_AttributeRepository) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _value_AttributeRepository = value_AttributeRepository;
        }

        public async Task<ProductsByCategoryDTO> Handle(GetCategoryWithProductsQuery request, CancellationToken cancellationToken)
        {
            var categoryWithProducts = await _categoryRepository.GetAllProductsByCategory(request.ID,request.Page,request.PageSize, request.Values);
            ProductsByCategoryDTO productsByCategory = new ();
            productsByCategory.NameCategory = categoryWithProducts.Name;
            productsByCategory.ProductsQuantity = categoryWithProducts.Products.Count();
            productsByCategory.PreviewProductItem = _mapper.Map<List<PreviewProductItemDTO>>(categoryWithProducts.Products);
            productsByCategory.Attribute_Categories = _mapper.Map<List<SearchAttribute_CategoryDTO>>(categoryWithProducts.Attribute_Categories);
            
            foreach (var i in productsByCategory.Attribute_Categories)
            {
                i.Value_Attributes = _mapper.Map<List<SearchValue_AttributeDTO>>(await _value_AttributeRepository.GetByAttributeCategoryID(i.Id));
            }
            
            return productsByCategory;
        }
    }
}
