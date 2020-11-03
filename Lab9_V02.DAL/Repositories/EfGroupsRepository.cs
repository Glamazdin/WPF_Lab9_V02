using Lab9_V02.DAL.Data;
using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab9_V02.DAL.Repositories
{
    class EfGroupsRepository : IRepository<Group>
    {
        //private readonly CourcesContext courcesContext;
        private readonly DbSet<Group> groups;

        public EfGroupsRepository(CourcesContext courcesContext)
        {
            //this.courcesContext = courcesContext;
            groups = courcesContext.Groups;
        }
        public void Create(Group entity)
        {
            groups.Add(entity);
        }
        
        public bool Delete(int id)
        {
            var group = groups.Find(id);
            if (group == null) return false;
            groups.Remove(group);
            return true;
        }

        public IQueryable<Group> Find(Expression<Func<Group, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> FindAsync(Expression<Func<Group, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Group Get(int id, params string[] includes)
        {
            IQueryable<Group> query = groups;
            
            foreach (var include in includes)
                query = query.Include(include);      
                  
            return query.First(g=>g.GroupId==id);
        }

        public IQueryable<Group> GetAll()
        {
            return  groups.AsQueryable();
        }

        public void Update(Group entity)
        {            
            groups.Update(entity);            
        }       
    }
}
