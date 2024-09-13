using VideogiochiAppApi.Data;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Repository
{
    public class VideogiocoRepository : IVideogiocoRepository
    {
        private readonly DataContext dataContext;

        public VideogiocoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool CreateVideogioco(int proprietarioId, Videogioco videogioco)
        {
            var Proprietario = dataContext.Proprietari.FirstOrDefault(p => p.IdProprietario == proprietarioId);
            var videogiocoProprietario = new VideogiocoProprietario()
            {
                Proprietario = Proprietario,
                Videogioco = videogioco
            };
            dataContext.Add(videogiocoProprietario);
            return Save();
           
        }

        public ICollection<Videogioco> GetVideogiochi()
        {
            return dataContext.Videogiochi.OrderBy(v => v.IdVideogioco).ToList();
        }

        public Videogioco GetVideogioco(int id)
        {
          var idVid = dataContext.Videogiochi.FirstOrDefault(v => v.IdVideogioco == id);
            if(idVid == null)
            {
                return null;
            }
            return idVid;
        }

        public Videogioco GetVideogiocoByNome(string nome)
        {
            return dataContext.Videogiochi.FirstOrDefault(v => v.Nome == nome);
        }

        public DateOnly? GetVideogiocoData(DateOnly dataId)
        {
            var videogioco = dataContext.Videogiochi.FirstOrDefault(v => v.DataDiRilascio == dataId);

            if (videogioco == null)
            {
                return null;
            }

            return videogioco.DataDiRilascio;
        }

        public bool UpdateVideogioco(int proprietarioId, Videogioco videogioco)
        {
            dataContext.Update(videogioco);
            return Save();
        }
        public bool Save()
        {
            var saveX = dataContext.SaveChanges();
            return saveX > 0 ? true : false;
        }

        public bool DeleteVideogioco(Videogioco videogioco)
        {
            dataContext.Remove(videogioco);
            return Save();
        }
    }
}
