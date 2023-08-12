using System.Linq;
using Application.LibrarianWorkplace.DTO;
using Domain;
using Profile = AutoMapper.Profile;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, Book>();
            CreateMap<Book, BookDto>()
                .ForMember(b => b.Name, o => o.MapFrom(s => s.Readers.FirstOrDefault().Reader.Name));
            
            CreateMap<BookReader, ReaderDto>()
                .ForMember(r => r.Name, o => o.MapFrom(s => s.Reader.Name))
                .ForMember(r => r.DateAdded, o => o.MapFrom(s => s.Reader.DateAdded))
                .ForMember(r => r.DateOfChange, o => o.MapFrom(s => s.Reader.DateOfChange))
                .ForMember(r => r.DateOfBirth, o => o.MapFrom(s => s.Reader.DateOfBirth))
                .ForMember(r => r.Exist, o => o.MapFrom(s => s.Reader.Exist));
        }
    }
}