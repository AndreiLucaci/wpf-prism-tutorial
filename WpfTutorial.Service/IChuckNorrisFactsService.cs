using System.Threading.Tasks;
using WpfTutorial.Models;

namespace WpfTutorial.Service
{
    public interface IChuckNorrisFactsService
    {
        Task<ChuckNorrisFact> GetOneFactAsync();
    }
}