using AutoMapper;
using Core.Application.Dtos;
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
    public class GetAllCommentsByProductQuery : IRequest<List<CommentsDTO>>
    {
        public int ProductID { get; set; }
    }

    public class GetAllCommentsByProductQueryHandler : IRequestHandler<GetAllCommentsByProductQuery, List<CommentsDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetAllCommentsByProductQueryHandler(ICommentRepository commentRepository, IMapper mapper) 
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentsDTO>> Handle(GetAllCommentsByProductQuery request, CancellationToken cancellationToken)
        {
            List<Comment> comments = await _commentRepository.GetAllCommentByProduct(request.ProductID);
            List<CommentsDTO> commentsDTO = _mapper.Map<List<CommentsDTO>>(comments);
            return commentsDTO;
        }
    }
}
