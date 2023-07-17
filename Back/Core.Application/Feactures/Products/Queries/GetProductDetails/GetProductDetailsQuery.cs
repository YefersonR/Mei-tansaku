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
        public int commentsPage { get; set; }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductResponseDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var productDetail = await _productRepository.GetProductDetails(request.ID, request.commentsPage);
            var productDetailDTO = _mapper.Map<ProductResponseDTO>(productDetail);
            
            return productDetailDTO;
        }
    }
}
