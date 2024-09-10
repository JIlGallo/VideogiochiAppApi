using VideogiochiAppApi.Data;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Repository
{
    public class PaeseRepository : IPaeseRepository
    {
        private readonly DataContext dataContext;

        public PaeseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Paese? GetNome(string nome)
        {
            return dataContext.Paesi.FirstOrDefault(p => p.Name == nome);
        }

        public Paese? GetPaese(int id)
        {
            return dataContext.Paesi.FirstOrDefault(p => p.IdPaese == id);
        }

        public ICollection<Paese> GetPaesi()
        {
            return dataContext.Paesi.OrderBy(p => p.IdPaese).ToList();
        }
    }
}
