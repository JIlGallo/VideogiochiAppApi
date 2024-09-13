using Microsoft.EntityFrameworkCore;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Interfaces
{
    public interface IVideogiocoRepository
    {
        ICollection<Videogioco> GetVideogiochi();
        Videogioco? GetVideogioco(int id);
        Videogioco? GetVideogiocoByNome(string nome);
        DateOnly? GetVideogiocoData(DateOnly dataId);
        bool CreateVideogioco(int proprietarioId, Videogioco videogioco);
        bool UpdateVideogioco(int proprietarioId, Videogioco videogioco);
        bool DeleteVideogioco(Videogioco videogioco);

        bool Save();
    }
}
