using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Products.Queries.GetProductById
{
    public class GetProductDetailsQuery : IRequest<ProductResponseDTO>
    {
        public int ID { get; set; }
        public int commentsPage { get; set; } = 1;
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductResponseDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProduct_ImagesRepository _product_ImagesRepository;
        private readonly IProduct_RatingRepository _product_RatingRepository;
        private readonly IAttribute_CategoryRepository _attribute_CategoryRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, IProduct_ImagesRepository product_ImagesRepository, IProduct_RatingRepository product_RatingRepository, IAttribute_CategoryRepository attribute_CategoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _product_ImagesRepository = product_ImagesRepository;
            _product_RatingRepository = product_RatingRepository;
            _attribute_CategoryRepository = attribute_CategoryRepository;
        }

        public async Task<ProductResponseDTO> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var productDetail = await _productRepository.GetProductDetails(request.ID, request.commentsPage);
            var productDetailDTO = _mapper.Map<ProductResponseDTO>(productDetail);
            productDetailDTO.Product_Images = await _product_ImagesRepository.GetImgByProductID(productDetailDTO.ID);
            productDetailDTO.TotalRating = await _product_RatingRepository.Rating(request.ID);
            productDetailDTO.Category.Attribute_Categories = _mapper.Map<List<SearchAttribute_CategoryDTO>>(await _attribute_CategoryRepository.GetAttribute(productDetailDTO.Category.ID, productDetailDTO.ID));
            return productDetailDTO;
        }
    }
}
