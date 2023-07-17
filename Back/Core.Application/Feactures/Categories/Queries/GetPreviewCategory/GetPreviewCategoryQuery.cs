using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Feactures.Categories.Queries.GetPreviewCategory
{
    public class GetPreviewCategoryQuery : IRequest<List<PreviewCategoryDTO>>
    {
       public int quantity { get; set; }
    }
    public class GetPreviewCategoryQueryHandler : IRequestHandler<GetPreviewCategoryQuery, List<PreviewCategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetPreviewCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<PreviewCategoryDTO>> Handle(GetPreviewCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoriesPreview =  await _categoryRepository.GetPreviewCategories(request.quantity);
            var categoriesPreviewDTO = _mapper.Map<List<PreviewCategoryDTO>>(categoriesPreview);
            return categoriesPreviewDTO;
        }
    }
}
