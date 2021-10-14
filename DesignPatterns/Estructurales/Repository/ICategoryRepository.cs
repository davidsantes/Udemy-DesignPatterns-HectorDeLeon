using DesignPatterns.Estructurales.Repository.Models;
using System.Collections.Generic;

namespace DesignPatterns.Estructurales.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(string id);
        void Add(Category data);
        void Delete(string id);
        void Update(Category data);
        void Save();
    }
}
