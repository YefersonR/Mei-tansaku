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

namespace Core.Application.Feactures.Comments.Queries.GetAllCommentsByProduct
{
    public class GetListByIdQuery : IRequest<GenericApiResponse<Shopping_ListDTO>>
    {
        public int ListId { get; set; }
    }

    public class GetListByIdQueryHandler : IRequestHandler<GetListByIdQuery, GenericApiResponse<Shopping_ListDTO>>
    {
        private readonly IShopping_ListRepository _shopping_ListRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListByIdQueryHandler(IShopping_ListRepository shopping_ListRepository, IMapper mapper, IProductRepository productRepository) 
        {
            _shopping_ListRepository = shopping_ListRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GenericApiResponse<Shopping_ListDTO>> Handle(GetListByIdQuery request, CancellationToken cancellationToken)
        {
            GenericApiResponse<Shopping_ListDTO> response = new GenericApiResponse<Shopping_ListDTO>();
            response.Payload = new Shopping_ListDTO();
            List<SearchPreviewProductItemDTO> previewProduct = new List<SearchPreviewProductItemDTO>();
            Shopping_ListDTO shopping_List = _mapper.Map<Shopping_ListDTO>(await _shopping_ListRepository.GetAll(request.ListId));
            
            foreach(var data in shopping_List.Product_Lists)
            {
                previewProduct.Add(_mapper.Map<SearchPreviewProductItemDTO>(await _productRepository.GetProductInfo(data.ProductID)));
            }

            if(shopping_List != null)
            {
                shopping_List.Products = previewProduct;
                response.Payload = shopping_List;
            }

            
            return response;
        }
    }
}
