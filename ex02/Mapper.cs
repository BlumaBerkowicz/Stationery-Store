﻿using AutoMapper;
using Dto;
using Repository;
using Entities;

namespace ex02
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ForMember(dest => dest.CategoryName,
                opts => opts.MapFrom(src => src.Category.CategoryName));
        }
    }
}
