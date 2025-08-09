using AutoMapper;
using RightWay.Application.Dto;
using RightWay.Application.Extension;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;

namespace RightWay.Ioc.Configuration;

public static class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<Order, OrderDto>();

            config.CreateMap<Address, AddressDto>()
                .ConstructUsing(src => new AddressDto(
                    src.Id,
                    src.BaseAddress.ZipCode,
                    src.BaseAddress.PublicPlace,
                    src.BaseAddress.Neighborhood,
                    src.BaseAddress.Locality,
                    src.BaseAddress.Uf.GetDescription(),
                    src.BaseAddress.State,
                    src.BaseAddress.Region,
                    src.BaseAddress.MunicipalCode,
                    src.Number,
                    src.Complement))
                .ForAllNullMembersReturnNull();

            config.CreateMap<OrderStatusEnum, string>()
                .ConvertUsing(src => src.GetDescription());
            config.CreateMap<PriorityLevelEnum, string>()
                .ConvertUsing(src => src.GetDescription());
            config.CreateMap<StateEnum, string>()
                .ConvertUsing(src => src.GetDescription());
        });
    }

    private static void ForAllNullMembersReturnNull<T, TResult>(this IMappingExpression<T, TResult> member)
        => member.ForAllMembers(opt =>
        {
            opt.Condition((src, dest, srcMember) => srcMember != null);
        });
}