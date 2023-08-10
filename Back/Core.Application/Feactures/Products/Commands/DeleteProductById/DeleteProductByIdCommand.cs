using AutoMapper;
using Core.Application.Dtos.Response;
using Core.Application.Feactures.Products.Commands.CreateProduct;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Products.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<GenericApiResponse<bool>>
    {
        public int ID { get; set; }
    }
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, GenericApiResponse<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public DeleteProductByIdCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<bool>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            GenericApiResponse<bool> response = new GenericApiResponse<bool>();
            await _productRepository.Delete(request.ID);
            response.Message = "Product Deleted";
            response.Payload = true;
            response.Success = true;
            response.Statuscode = 200;
            return response;
            
        }
    }
}
