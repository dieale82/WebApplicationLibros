using Models;

namespace Queries
{
    public interface IGetBookList
    {
        Task<IEnumerable<Libro>> Handle();
    }
}