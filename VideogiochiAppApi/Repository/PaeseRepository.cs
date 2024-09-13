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

        public bool CreatePaese(Paese paese)
        {
           dataContext.Add(paese);
           return Save();
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

        public bool Save()
        {
            var saveP = dataContext.SaveChanges();
            return saveP > 0 ? true : false;
        }

        public bool UpdatePaese(Paese paese)
        {
            dataContext.Update(paese);
            return Save();
        }
        public bool DeletePaese(Paese paese)
        {
            
            dataContext.Remove(paese);
            return Save();
        }

    }
}
