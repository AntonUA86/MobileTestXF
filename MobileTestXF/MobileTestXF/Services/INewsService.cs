using System.Collections.Generic;
using System.Threading.Tasks;
using MobileTestXF.Model;

namespace MobileTestXF.Services
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAllNewsAsync();

        Task<IEnumerable<News>> GetNewsBySearchAsync(string request);
    }
}