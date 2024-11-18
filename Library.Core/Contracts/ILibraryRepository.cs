using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Contracts
{
    public interface ILibraryRepository
    {
        Task AddBook(Book book);
        Task AddMagazine(Magazine magazine);
        Task<Book> GetBookById(int id);
        Task<Magazine> GetMagazineById(int id);
        Task<LibraryItem> GetLibraryItem(int id);
        Task DeleteLibraryItem(int id);
        Task<List<Book>> GetAllBooks();
        Task<List<Magazine>> GetAllMagazines();

    }
}
