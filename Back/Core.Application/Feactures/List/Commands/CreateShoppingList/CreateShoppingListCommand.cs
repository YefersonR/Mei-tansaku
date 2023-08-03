using AutoMapper;
using Core.Application.Dtos.Response;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.List.Commands.CreateList
{
    public class CreateShoppingListCommand : IRequest<GenericApiResponse<bool>>
    {
        public string UserID { get; set; }
        public string Title { get; set; }
    }

    public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand, GenericApiResponse<bool>>
    {
        private readonly IShopping_ListRepository _shopping_ListRepository;
        private readonly IMapper _mapper;

        public CreateShoppingListCommandHandler(IShopping_ListRepository shopping_ListRepository, IMapper mapper)
        {
            _shopping_ListRepository = shopping_ListRepository;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<bool>> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
        {
            

            GenericApiResponse<bool> response = new GenericApiResponse<bool>();


            var productList = _mapper.Map<Shopping_List>(request);
            var dataresponse = await _shopping_ListRepository.Add(productList);
            response.Statuscode = 200;

            if (dataresponse.ID == null || dataresponse.ID == 0)
            {
                response.Statuscode = 404;
                response.Success = false;
            }

            return response;
        }

    }
}
