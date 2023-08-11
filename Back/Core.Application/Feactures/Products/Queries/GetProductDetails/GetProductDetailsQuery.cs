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
        
        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, IProduct_ImagesRepository product_ImagesRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _product_ImagesRepository = product_ImagesRepository;
        }

        public async Task<ProductResponseDTO> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var productDetail = await _productRepository.GetProductDetails(request.ID, request.commentsPage);
            var productDetailDTO = _mapper.Map<ProductResponseDTO>(productDetail);
            productDetailDTO.Product_Images = await _product_ImagesRepository.GetImgByProductID(productDetailDTO.ID);

            return productDetailDTO;
        }
    }
}
