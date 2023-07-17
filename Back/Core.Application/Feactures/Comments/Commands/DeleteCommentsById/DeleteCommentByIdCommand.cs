using AutoMapper;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Comments.Commands.DeleteCommentsById
{
    public class DeleteCommentByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteCommentByIdCommandHandler : IRequestHandler<DeleteCommentByIdCommand,int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public DeleteCommentByIdCommandHandler(ICommentRepository commentRepository, IMapper mapper) 
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteCommentByIdCommand command, CancellationToken cancellationToken)
        {
            await _commentRepository.Delete(command.Id);
            return command.Id;
        }
    }
}
