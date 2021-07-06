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
    // Condominia
    using OfiCondo.Management.Application.Features.Condominia.Commands.Create;
    using OfiCondo.Management.Application.Features.Condominia.Commands.Delete;
    using OfiCondo.Management.Application.Features.Condominia.Commands.Update;
    using OfiCondo.Management.Application.Features.Condominia.Queries.Detail;
    using OfiCondo.Management.Application.Features.Condominia.Queries.List;
    // Message
    using OfiCondo.Management.Application.Features.Messages.Commands.Create;
    using OfiCondo.Management.Application.Features.Messages.Commands.Delete;
    using OfiCondo.Management.Application.Features.Messages.Commands.Update;
    using OfiCondo.Management.Application.Features.Messages.Queries.Detail;
    using OfiCondo.Management.Application.Features.Messages.Queries.List;
    // Minute
    using OfiCondo.Management.Application.Features.Minutes.Commands.Create;
    using OfiCondo.Management.Application.Features.Minutes.Commands.Delete;
    using OfiCondo.Management.Application.Features.Minutes.Commands.Update;
    using OfiCondo.Management.Application.Features.Minutes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Minutes.Queries.List;
    using OfiCondo.Management.Application.Features.PaymentMethod.Queries.Detail;
    // Payment Method
    using OfiCondo.Management.Application.Features.PaymentMethod.Queries.List;
    // Units
    using OfiCondo.Management.Application.Features.Units.Commands.Create;
    using OfiCondo.Management.Application.Features.Units.Commands.Delete;
    using OfiCondo.Management.Application.Features.Units.Commands.Update;
    using OfiCondo.Management.Application.Features.Units.Queries.Detail;
    using OfiCondo.Management.Application.Features.Units.Queries.List;
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

            // Condominium mapping
            CreateMap<Condominium, CondominiumListVm>().ReverseMap();
            CreateMap<Condominium, CondominiumDetailVm>().ReverseMap();
            CreateMap<Condominium, CreateCondominiumCommand>().ReverseMap();
            CreateMap<Condominium, UpdateCondominiumCommand>().ReverseMap();
            CreateMap<Condominium, DeleteCondominiumCommand>().ReverseMap();

            // Message mapping
            CreateMap<Message, MessageListVm>().ReverseMap();
            CreateMap<Message, MessageDetailVm>().ReverseMap();
            CreateMap<Message, CreateMessageCommand>().ReverseMap();
            CreateMap<Message, UpdateMessageCommand>().ReverseMap();
            CreateMap<Message, DeleteMessageCommand>().ReverseMap();

            // Minute mapping
            CreateMap<Minute, MinuteListVm>().ReverseMap();
            CreateMap<Minute, MinuteDetailVm>().ReverseMap();
            CreateMap<Minute, CreateMinuteCommand>().ReverseMap();
            CreateMap<Minute, UpdateMinuteCommand>().ReverseMap();
            CreateMap<Minute, DeleteMinuteCommand>().ReverseMap();

            // PaymentMethod mapping
            CreateMap<PaymentMethod, PaymentMethodListVm>();
            CreateMap<PaymentMethod, PaymentMethodDetailVm>();

            // Unit mapping
            CreateMap<Unit, UnitListVm>().ReverseMap();
            CreateMap<Unit, UnitDetailVm>().ReverseMap();
            CreateMap<Unit, CreateUnitCommand>().ReverseMap();
            CreateMap<Unit, UpdateUnitCommand>().ReverseMap();
            CreateMap<Unit, DeleteUnitCommand>().ReverseMap();
        }

    }
}
