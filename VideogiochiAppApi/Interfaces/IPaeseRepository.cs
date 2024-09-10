using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Interfaces
{
    public interface IPaeseRepository
    {
        ICollection<Paese> GetPaesi();
        Paese? GetPaese(int id);
        Paese? GetNome(string nome);
    }
}
