using AutoMapper;
using Core.Application.Dtos.Response;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.List.Commands.CreateList
{
    public class AddProduct_ListCommand : IRequest<GenericApiResponse<bool>>
    {
        public int ShoppingListID { get; set; }
        public int ProductID { get; set; }
    }

    public class AddProduct_ListCommandHandler : IRequestHandler<AddProduct_ListCommand, GenericApiResponse<bool>>
    {
        private readonly IProduct_ListRepository _product_ListRepository;
        private readonly IMapper _mapper;

        public AddProduct_ListCommandHandler(IProduct_ListRepository product_ListRepository, IMapper mapper)
        {
            _product_ListRepository = product_ListRepository;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<bool>> Handle(AddProduct_ListCommand request, CancellationToken cancellationToken)
        {
            GenericApiResponse<bool> response = new GenericApiResponse<bool>();

            var productList = _mapper.Map<Product_List>(request);
            var dataresponse = await _product_ListRepository.Add(productList);
            response.Statuscode = 200;

            if (dataresponse.ID == null ||  dataresponse.ProductID == 0)
            {
                response.Statuscode = 404;
                response.Success = false;
            }

            return response;
        }
    }
}
