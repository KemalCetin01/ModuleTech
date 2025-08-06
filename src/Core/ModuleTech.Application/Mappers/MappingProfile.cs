using ModuleTech.Application.DTOs.Product.Response;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Application.Handlers.Product.Queries;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Application.Handlers.User.Queries.Filters;
using ModuleTech.Application.Handlers.UserEmployees.DTOs;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Models.Token;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {


        CreateMap(typeof(ListResponse<>), typeof(PagedResponse<>));
        CreateMap(typeof(SearchListModel<>), typeof(PagedResponse<>));
        CreateMap(typeof(SearchListModel<>), typeof(SearchListModel<>));
        CreateMap(typeof(PagedResponse<>), typeof(PagedResponse<>));
        CreateMap<Sort, SortModel>();
        CreateMap<Pagination, PaginationModel>();
        CreateMap(typeof(SearchQuery<,>), typeof(SearchQueryModel<>));

        CreateMap(typeof(PagedResponse<>), typeof(SearchListModel<>));

        CreateMap<GetAllProductsResponseDto, ProductDTO>();
        CreateMap<ProductDTO, GetAllProductsResponseDto>();
        CreateMap<Product, ProductDTO>();
        CreateMap<EmployeeRole, EmployeeRoleDTO>();
        CreateMap<UserEmployee, UserEmployeeDTO>();
        CreateMap<BusinessUserGetByIdDTO, BusinessUser>().ReverseMap()
         .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
         .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
         .ForMember(dest => dest.IdentityRefId, opt => opt.MapFrom(src => src.User.IdentityRefId));
        CreateMap<SearchProductsQuery, SearchProductFilterModel>();
        CreateMap<BusinessUserListDTO, BusinessUser>().ReverseMap()
         .ForMember(dest => dest.Representative, opt => opt.MapFrom(src => src.UserEmployeeId))
         .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FirstName))
         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
         .ForMember(dest => dest.SiteStatus, opt => opt.MapFrom(src => src.SiteStatus))
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id));
        CreateMap<SearchProductFilterModel, SearchProductsQuery>();
        CreateMap<SearchProductsQuery, SearchQueryModel<SearchProductFilterModel>>();
        CreateMap<UserQueryFilter, BusinessUserQueryServiceFilter>().ReverseMap();

        CreateMap<SearchProcutFilter, SearchProductFilterModel>();
        CreateMap<TokenModel, AuthenticationDTO>()
         .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.access_token))
         .ForMember(dest => dest.ExpiresIn, opt => opt.MapFrom(src => src.expires_in))
         .ForMember(dest => dest.RefreshExpiresIn, opt => opt.MapFrom(src => src.refresh_expires_in))
         .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.refresh_token))
         .ForMember(dest => dest.TokenType, opt => opt.MapFrom(src => src.token_type))
         .ForMember(dest => dest.notbeforepolicy, opt => opt.MapFrom(src => src.notbeforepolicy))
         .ForMember(dest => dest.scope, opt => opt.MapFrom(src => src.scope))
            ;

        // Ana map tanımı, Filter manuel bağlanmalı
        CreateMap<SearchProductsQuery, SearchQueryModel<SearchProductFilterModel>>();

    }
}
