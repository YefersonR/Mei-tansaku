using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Dtos.Response;
using Core.Application.Helpers.UploadImg;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<GenericApiResponse<bool>>
    {
        public int CategoryID { get; set; }
        public int StateID { get; set; }
        public string? SellerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Availability { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public bool Private { get; set; }
        public List<IFormFile> Images { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, GenericApiResponse<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProduct_ImagesRepository _product_ImagesRepository;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IProduct_ImagesRepository product_ImagesRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _product_ImagesRepository = product_ImagesRepository;
        }

        public async Task<GenericApiResponse<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            GenericApiResponse<bool> response = new GenericApiResponse<bool>();
            var data = await _productRepository.Add(_mapper.Map<Product>(request));
            if(data !=  null)
            {
                ImageUp imageUp = new ImageUp();
                response.Message = "Product Added";
                response.Payload = true;
                response.Success = true;
                response.Statuscode = 200;

                foreach(var img in request.Images)
                {
                    var uri = imageUp.UploadFile(img, data.ID);
                    Product_Images imgU = new Product_Images();
                    imgU.ProductID = data.ID;
                    imgU.ImgUri = uri;
                    await _product_ImagesRepository.Add(imgU);
                }

                return response;
            }
            response.Message = "A Error ocurred";
            response.Payload = false;
            response.Success = false;
            response.Statuscode = 400;

            return response;
        }
    }
}
