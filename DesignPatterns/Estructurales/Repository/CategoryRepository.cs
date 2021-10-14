using DesignPatterns.Estructurales.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Estructurales.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryDbContext _context;

        public CategoryRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public void Add(Category data)
        {
            _context.Categories.Add(data);
        }

        public void Delete(string id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        public Category Get(string id)
        {
            return _context.Categories.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category data)
        {
            _context.Entry(data).State = EntityState.Modified;
            throw new NotImplementedException();
        }
    }
}