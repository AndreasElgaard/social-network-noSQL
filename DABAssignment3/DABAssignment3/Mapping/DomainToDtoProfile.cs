using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DABAssignment3.Controllers;
using DABAssignment3.Controllers.Request;
using DABAssignment3.Controllers.Response;
using DABAssignment3.Models;

namespace DABAssignment3.Mapping
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Circle, CircleResponse>();

            CreateMap<Post, PostResponse>();

            CreateMap<User, UserResponse>();

            CreateMap<Comment, CommentResponse>();

            CreateMap<CircleRequest, Circle>();

            CreateMap<PostRequest, Post>();

            CreateMap<UserRequest, User>();

            CreateMap<CommentRequest, Comment>();
        }
    }
}
