namespace OfiCondo.Management.Application.Profiles
{
    using AutoMapper;
    // Banks
    using OfiCondo.Management.Application.Features.Banks.Commands.Create;
    using OfiCondo.Management.Application.Features.Banks.Commands.Delete;
    using OfiCondo.Management.Application.Features.Banks.Commands.Update;
    using OfiCondo.Management.Application.Features.Banks.Queries.Detail;
    using OfiCondo.Management.Application.Features.Banks.Queries.List;
    // Categories
    using OfiCondo.Management.Application.Features.Categories.Commands.Create;
    using OfiCondo.Management.Application.Features.Categories.Commands.Delete;
    using OfiCondo.Management.Application.Features.Categories.Commands.Update;
    using OfiCondo.Management.Application.Features.Categories.Queries.Detail;
    using OfiCondo.Management.Application.Features.Categories.Queries.List;
    using OfiCondo.Management.Application.Features.PaymentMethod.Queries.List;
    using OfiCondo.Management.Domain.Entities;
    
    public class MappingProfile: Profile
    {                
        public MappingProfile()
        {
            // Bank mapping
            CreateMap<Bank, BankListVm>().ReverseMap();
            CreateMap<Bank, BankDetailVm>().ReverseMap();
            CreateMap<Bank, CreateBankCommand>().ReverseMap();
            CreateMap<Bank, UpdateBankCommand>().ReverseMap();
            CreateMap<Bank, DeleteBankCommand>().ReverseMap();

            // Category mapping
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryDetailVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();

            // PaymentMethod mapping
            CreateMap<PaymentMethod, PaymentMethodListVm>();
        }

    }
}
