using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Interfaces
{
    public interface IProprietarioRepository
    {
      ICollection<Proprietario> GetProprietari();
    
      Proprietario? GetProprietario(int id);
      Proprietario? GetNome(string nome);

      Proprietario GetEta(int eta);

      ICollection<Videogioco> GetVideogiocoByOwner(int propId);

        bool CreateProprietario(Proprietario proprietario);
        bool UpdateProprietario(Proprietario proprietario);
        bool DeleteProprietario(Proprietario proprietario);


        bool Save();
    }
}
