using AutoMapper;
using BooksAndAuthors.Classes;
using BooksAndAuthors.Models;

namespace BooksAndAuthors.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
        }
    }
}
