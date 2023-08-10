using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Feactures.Comments.Commands.CreateComments;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Comments.Commands.UpdateComments
{
    public class UpdateCommentCommand : IRequest<UpdateCommentCommand>
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public int FatherComment { get; set; }
        public string Description { get; set; }
        public int QuantityHelpful { get; set; }
    }
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper) 
        {
            _commentRepository = commentRepository;
            _mapper = mapper;   
        }
        public async Task<UpdateCommentCommand> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            await _commentRepository.Update(comment,request.ID);
            return request;
        }
    }
}
