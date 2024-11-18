using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Contracts
{
    public interface ILibraryService
    {
        Task AddLibraryItem(LibraryItem item);
        Task<List<Book>> GetAllBooks();
        Task<List<Magazine>> GetAllMagazines();
        Task DeleteMagazine(int id);
        Task DeleteBook(int id);
        Task<Book> GetBookById(int id);
        Task<Magazine> GetMagazineById(int id);
    }
}
