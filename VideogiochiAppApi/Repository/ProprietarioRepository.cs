using Azure;
using VideogiochiAppApi.Data;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Repository
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly DataContext dataContext;

        public ProprietarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Proprietario GetEta(int eta)
        {
            return dataContext.Proprietari.FirstOrDefault(p => p.Età == eta);
        }

        public Proprietario? GetNome(string nome)
        {
            return dataContext.Proprietari.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<Proprietario> GetProprietari()
        {
        return dataContext.Proprietari.OrderBy(p => p.IdProprietario).ToList();
        }

        public Proprietario? GetProprietario(int id)
        {
            return dataContext.Proprietari.FirstOrDefault(p => p.IdProprietario == id);
        }

        public ICollection<Videogioco> GetVideogiocoByOwner(int propId)
        {
            return dataContext.VideogiocoProprietari.Where(i => i.Proprietario.IdProprietario == propId).Select(p => p.Videogioco).ToList();
        }
    }
}
