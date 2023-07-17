using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<PreviewCategoryDTO>>
    {
    }
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery,List<PreviewCategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<PreviewCategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAll();
            List<PreviewCategoryDTO> categoriesDTO = _mapper.Map<List<PreviewCategoryDTO>>(categories);
            return categoriesDTO;
        }
    }
}
