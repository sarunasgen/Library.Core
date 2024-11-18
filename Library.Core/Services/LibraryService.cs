using Library.Core.Contracts;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository library)
        {
            _libraryRepository = library;
        }

        public async Task AddLibraryItem(LibraryItem item)
        {
            if (item is Book)
                await _libraryRepository.AddBook((Book)item);
            else
                await _libraryRepository.AddMagazine((Magazine)item);
        }

        public async Task DeleteBook(int id)
        {
            var libItem = _libraryRepository.GetBookById(id);
            if (libItem == null)
                throw new Exception("Item is not a book or was not found by id");
            await _libraryRepository.DeleteLibraryItem(id);
        }

        public async Task DeleteMagazine(int id)
        {
            var libItem = _libraryRepository.GetMagazineById(id);
            if (libItem == null)
                throw new Exception("Item is not a magazine or was not found by id");
            await _libraryRepository.DeleteLibraryItem(id);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _libraryRepository.GetAllBooks();
        }

        public async Task<List<Magazine>> GetAllMagazines()
        {
            return await _libraryRepository.GetAllMagazines();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _libraryRepository.GetBookById(id);
        }

        public async Task<Magazine> GetMagazineById(int id)
        {
            return await _libraryRepository.GetMagazineById(id);
        }
    }
}
