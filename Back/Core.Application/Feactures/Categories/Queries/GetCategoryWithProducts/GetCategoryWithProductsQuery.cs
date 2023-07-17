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
    }
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryWithProductsQuery, ProductsByCategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductsByCategoryDTO> Handle(GetCategoryWithProductsQuery request, CancellationToken cancellationToken)
        {
            var categoryWithProducts = await _categoryRepository.GetAllProductsByCategory(request.ID,request.Page,request.PageSize);
            ProductsByCategoryDTO productsByCategory = new ();
            productsByCategory.NameCategory = categoryWithProducts.Name;
            productsByCategory.ProductsQuantity = categoryWithProducts.Products.Count();
            productsByCategory.PreviewProductItem = _mapper.Map<List<PreviewProductItemDTO>>(categoryWithProducts.Products);
            
            return productsByCategory;
        }
    }
}
