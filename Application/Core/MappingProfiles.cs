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
                .ForMember(b => b.Name, o => o.MapFrom(s => s.Readers.FirstOrDefault().Book.Name));
            
            CreateMap<BookReader, ReaderDto>()
                .ForMember(r => r.Name, o => o.MapFrom(s => s.Reader.Name))
                .ForMember(r => r.DateAdded, o => o.MapFrom(s => s.Reader.DateAdded))
                .ForMember(r => r.DateOfChange, o => o.MapFrom(s => s.Reader.DateOfChange))
                .ForMember(r => r.DateOfBirth, o => o.MapFrom(s => s.Reader.DateOfBirth))
                .ForMember(r => r.Exist, o => o.MapFrom(s => s.Reader.Exist))
                .ForMember(r => r.Event, o => o.MapFrom(s => s.Event))
                .ForMember(r => r.CreatedAt, o => o.MapFrom(s => s.CreatedAt));

            CreateMap<BookReader, BookDtoForDetails>()
                .ForMember(r => r.Id, o => o.MapFrom(s => s.Book.Id))
                .ForMember(r => r.Name, o => o.MapFrom(s => s.Book.Name))
                .ForMember(r => r.DateAdded, o => o.MapFrom(s => s.Book.DateAdded))
                .ForMember(r => r.DateOfChange, o => o.MapFrom(s => s.Book.DateOfChange))
                .ForMember(r => r.Author, o => o.MapFrom(s => s.Book.Author))
                .ForMember(r => r.VendorCode, o => o.MapFrom(s => s.Book.VendorCode))
                .ForMember(r => r.YearOfPublishing, o => o.MapFrom(s => s.Book.YearOfPublishing))
                .ForMember(r => r.NumberOfCopies, o => o.MapFrom(s => s.Book.NumberOfCopies))
                .ForMember(r => r.Exist, o => o.MapFrom(s => s.Book.Exist))
                .ForMember(r => r.Event, o => o.MapFrom(s => s.Event))
                .ForMember(r => r.CreatedAt, o => o.MapFrom(s => s.CreatedAt));
        }
    }
}