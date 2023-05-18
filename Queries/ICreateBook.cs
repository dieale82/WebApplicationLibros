using Models;

namespace Queries
{
    public interface ICreateBook
    {
        Task<int> Handle(Libro bookData);
    }
}