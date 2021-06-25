namespace OfiCondo.Management.Application.Profiles
{
    using AutoMapper;
    using OfiCondo.Management.Application.Features.Banks.Commands.Create;
    using OfiCondo.Management.Application.Features.Banks.Commands.Delete;
    using OfiCondo.Management.Application.Features.Banks.Commands.Update;
    using OfiCondo.Management.Application.Features.Banks.Queries.Detail;
    using OfiCondo.Management.Application.Features.Banks.Queries.List;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MappingProfile: Profile
    {                
        //CreateMap<Bank, BankListVm>().ReverseMap();
        //CreateMap<Bank, BankDetailVm>().ReverseMap();
        //CreateMap<Bank, CreateBankCommand>().ReverseMap();
        //CreateMap<Bank, UpdateBankCommand>().ReverseMap();
        //CreateMap<Bank, DeleteBankCommand>().ReverseMap();

        //CreateMap<Event, CategoryEventDTO>().ReverseMap();
        //CreateMap<Event, EventExportDTO>().ReverseMap();

        //CreateMap<Category, CategoryDTO>();
        //    CreateMap<Category, CategoryListVm>();
        //    CreateMap<Category, CategoryEventListVm>();
        //    CreateMap<Category, CreateCategoryCommand>();
        //    CreateMap<Category, CreateCategoryDTO>();

        //    CreateMap<Order, OrdersForMonthDto>();
    }
}
