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

namespace Core.Application.Feactures.Comments.Commands.CreateComments
{
    public class CreateCommentCommand :IRequest<int>
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public int FatherComment { get; set; }
    }
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async  Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            var newComment = await _commentRepository.Add(comment);
            return newComment.ID;
        }

    }
}
