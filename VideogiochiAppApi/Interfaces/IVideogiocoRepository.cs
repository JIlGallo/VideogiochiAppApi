using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Interfaces
{
    public interface IVideogiocoRepository
    {
        ICollection<Videogioco> GetVideogiochi();
        Videogioco? GetVideogioco(int id);
        Videogioco? GetVideogiocoByNome(string nome);

        DateOnly? GetVideogiocoData(DateOnly dataId);

    }
}
