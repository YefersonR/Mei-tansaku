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

namespace Core.Application.Feactures.Rating.Commads.AddRating
{
    public class AddRatingCommand : IRequest<GenericApiResponse<bool>>
    {
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public int Rating { get; set; }
    }

    public class AddRatingCommandHandler : IRequestHandler<AddRatingCommand, GenericApiResponse<bool>>
    {

        private readonly IProduct_RatingRepository _product_RatingRepository;
        private readonly IMapper _mapper;

        public AddRatingCommandHandler(IProduct_RatingRepository product_RatingRepository, IMapper mapper)
        {
            _product_RatingRepository = product_RatingRepository;
            _mapper = mapper;
        }


        public async Task<GenericApiResponse<bool>> Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            GenericApiResponse<bool> response = new();
            int validate = await _product_RatingRepository.IsRated(request.ProductID, request.UserID);
            if (validate == 0)
            {
                var data = await _product_RatingRepository.Add(_mapper.Map<Product_Rating>(request));
                if (data.ID == null)
                {
                    response.Message = "Error";
                    response.Statuscode = 404;
                    response.Success = false;
                    return response;
                }
                response.Message = "Created";
                response.Statuscode = 200;
                response.Success = true;
            }
            else
            {
                var data = _mapper.Map<Product_Rating>(request);
                data.ID = validate;
                data.LastUpdatedBy = request.UserID;
                data.CreatedBy = "System";
                await _product_RatingRepository.Update(data, validate);
                response.Message = "Updated";
                response.Statuscode = 200;
                response.Success = true;
            }
            return response;

        }
    }
}
