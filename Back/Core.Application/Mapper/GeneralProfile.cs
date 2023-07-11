using AutoMapper;
using Core.Application.Dtos;
using Core.Application.DTOS.Account;
using Core.Application.ViewModels.User;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<PreviewCategoryDTO, Category>()
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedDate, opt => opt.Ignore())
                .ForMember(x => x.Products, opt => opt.Ignore())
                .ForMember(x => x.Attribute_Categories, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<AuthenticationResponse, UserSaveViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AuthenticationRequest, LoginViewModel>()
               .ReverseMap();

            CreateMap<RegisterRequest, UserSaveViewModel>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
              .ForMember(x => x.HasError, opt => opt.Ignore())
              .ForMember(x => x.Error, opt => opt.Ignore())
              .ReverseMap();

        }

    }
}
