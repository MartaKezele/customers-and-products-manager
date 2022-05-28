using AutoMapper;
using RWAProject.Models;
using RWAProject.Models.DatabaseModels;
using RWAProject.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAProject.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>()
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email ?? string.Empty))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City != default ? src.City.Name : string.Empty))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.City != default ? src.City.Country.Name : string.Empty));

                cfg.CreateMap<Category, CategoryDto>();

                cfg.CreateMap<Subcategory, SubcategoryDto>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

                cfg.CreateMap<SubcategoryDbm, SubcategoryDto>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Repo.RetrieveCategoryByID(src.CategoryID)));

                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Subcategory != default ? src.Subcategory.Name : string.Empty))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Subcategory != default ? src.Subcategory.Category.Name : string.Empty));

                cfg.CreateMap<ProductDbm, ProductDto>()
                    .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.SubcategoryID != default ? Repo.RetrieveSubcategoryByID(src.SubcategoryID).Name : string.Empty))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.SubcategoryID != default ? Repo.RetrieveSubcategoryByID(src.SubcategoryID).Category.Name : string.Empty));

                cfg.CreateMap<Receipt, ReceiptDto>()
                    .ForMember(dest => dest.DateOfPurchase, opt => opt.MapFrom(src => src.DateOfPurchase.Date.ToString("d")))
                    .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                    .ForMember(dest => dest.Commercialist, opt => opt.MapFrom(src => src.Commercialist != default ? src.Commercialist.FirstName + " " + src.Commercialist.LastName : string.Empty))
                    .ForMember(dest => dest.CreditCardType, opt => opt.MapFrom(src => src.CreditCard != default ? src.CreditCard.Type : string.Empty))
                    .ForMember(dest => dest.CreditCardNumber, opt => opt.MapFrom(src => src.CreditCard != default ? src.CreditCard.Number : string.Empty))
                    .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment ?? string.Empty));

                cfg.CreateMap<Item, ItemDto>()
                    .ForMember(dest => dest.ReceiptNumber, opt => opt.MapFrom(src => src.Receipt.ReceiptNumber))
                    .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Subcategory != default ? src.Product.Subcategory.Category.Name : string.Empty))
                    .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Product.Subcategory != default ? src.Product.Subcategory.Name : string.Empty));
            });

            Mapper = config.CreateMapper();
        }
    }
}