using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace DataAccessLayer.Repositories
{
    public class WriterRepository : IWriterDal
    {
        public void Insert(Writer p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Writer p)
        {
            throw new NotImplementedException();
        }

        public List<Writer> List()
        {
            throw new NotImplementedException();
        }

        public List<Writer> List(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Writer p)
        {
            throw new NotImplementedException();
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Writer> ListOrderByDesc(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
