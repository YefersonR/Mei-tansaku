using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Comments.Commands.UpdateComments
{
    public class UpdateCommentCommand
    {
        public string Description { get; set; }
        public int QuantityHelpful { get; set; }
    }
    public class UpdateCommentCommandHandler
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper) 
        {
            _commentRepository = commentRepository;
            _mapper = mapper;   
        }
    }
}
