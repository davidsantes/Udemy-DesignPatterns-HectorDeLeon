using System.Collections.Generic;

namespace DesignPatternsInAsp.Repository
{
    /// <summary>
    /// Interface que permita trabajar el patrón repositorio con genéricos
    /// </summary>
    /// <typeparam name="TEntity">Tipo de la entidad en la que vamos a operar</typeparam>
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(string id);
        void Add(TEntity data);
        void Delete(string id);
        void Update(TEntity data);
        void Save();
    }
}
