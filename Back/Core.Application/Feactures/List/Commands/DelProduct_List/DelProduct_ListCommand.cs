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
    public class DelProduct_ListCommand : IRequest<GenericApiResponse<bool>>
    {
        public int ProductID { get; set; }
    }

    public class DelProduct_ListCommandHandler : IRequestHandler<DelProduct_ListCommand, GenericApiResponse<bool>>
    {
        private readonly IProduct_ListRepository _product_ListRepository;

        public DelProduct_ListCommandHandler(IProduct_ListRepository product_ListRepository)
        {
            _product_ListRepository = product_ListRepository;
        }

        public async Task<GenericApiResponse<bool>> Handle(DelProduct_ListCommand request, CancellationToken cancellationToken)
        {
            GenericApiResponse<bool> response = new GenericApiResponse<bool>();
            await _product_ListRepository.Delete(request.ProductID);
            response.Statuscode = 200;
            return response;
        }
    }
}
