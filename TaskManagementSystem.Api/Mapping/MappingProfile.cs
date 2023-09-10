using AutoMapper;
using TaskManagementSystem.Api.Resources;
using TaskManagementSystem.Core.Models;
using TaskManagementSystem.Core.Models.Auth;

namespace TaskManagementSystem.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to Resource
        CreateMap<Quote, QuoteResource>();
          

        // Resource to Domain
        CreateMap<SaveQuoteResource, Quote>()
            .ForMember(dest => dest.QuoteType, opt =>
            {
                opt.MapFrom(src => char.ToUpper(src.QuoteType[0]) + src.QuoteType.Substring(1).ToLower());
            });
        CreateMap<UserSignUpResource, User>();
    }

    private string TransformQuoteType(string quoteType)
    {

        // Convert the QuoteType property to lowercase with the first character capitalized.
        return char.ToUpper(quoteType[0]) + quoteType.Substring(1).ToLower();
    }
}