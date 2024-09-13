using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Interfaces
{
    public interface IPaeseRepository
    {
        ICollection<Paese> GetPaesi();
        Paese? GetPaese(int id);
        Paese? GetNome(string nome);

        bool CreatePaese (Paese paese);
        bool UpdatePaese(Paese paese);
        bool DeletePaese(Paese paese);


        bool Save();
    }
}
