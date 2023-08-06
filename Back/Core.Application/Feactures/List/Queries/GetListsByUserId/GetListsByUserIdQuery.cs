using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Dtos.Response;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Comments.Queries.GetListsByUserId
{
    public class GetListsByUserIdQuery : IRequest<GenericApiResponse<List<Shopping_ListDTO>>>
    {
        public string UserID { get; set; }
    }

    public class GetListsByUserIdQueryHandler : IRequestHandler<GetListsByUserIdQuery, GenericApiResponse<List<Shopping_ListDTO>>>
    {
        private readonly IShopping_ListRepository _shopping_ListRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListsByUserIdQueryHandler(IShopping_ListRepository shopping_ListRepository, IMapper mapper, IProductRepository productRepository) 
        {
            _shopping_ListRepository = shopping_ListRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GenericApiResponse<List<Shopping_ListDTO>>> Handle(GetListsByUserIdQuery request, CancellationToken cancellationToken)
        {
            GenericApiResponse<List<Shopping_ListDTO>> response = new GenericApiResponse<List<Shopping_ListDTO>>();
            
            List<SearchPreviewProductItemDTO> previewProduct = new List<SearchPreviewProductItemDTO>();
            List<Shopping_ListDTO> shopping_Lists = _mapper.Map<List<Shopping_ListDTO>>(await _shopping_ListRepository.GetAllByUserID(request.UserID));
            response.Payload = shopping_Lists;

            if (response.Payload == null)
            {
                response.Message = "You dont have List";
                response.Statuscode = 404;
                response.Success = true;
                return response;
            }
            response.Statuscode = 202;
            response.Success = true;


            return response;
        }
    }
}
