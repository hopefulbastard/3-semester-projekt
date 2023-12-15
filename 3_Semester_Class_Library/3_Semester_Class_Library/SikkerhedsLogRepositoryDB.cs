using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace _3_Semester_Class_Library
{
    public class SikkerhedsLogRepositoryDB : ISikkerhedsLogRepository
    {
        private readonly SikkerhedsLogDBContext _context;

        public SikkerhedsLogRepositoryDB(SikkerhedsLogDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }

        public IEnumerable<SikkerhedsLog> Get(int? idFørst = null,
                                              int? idSidst = null,
                                              string? orderBy = null,
                                              bool descending = false)
        {
            IQueryable<SikkerhedsLog> result = _context.SikkerhedsLog.AsQueryable();

            if (idFørst != null)
            {
                result = result.Where<SikkerhedsLog>(s => s.Id < idFørst);
            }

            if (idSidst != null)
            {
                result = result.Where<SikkerhedsLog>(s => s.Id > idSidst);
            }

            return result;
        }

        public SikkerhedsLog Add(SikkerhedsLog sl)
        {
            sl.Validate();
            sl.Id = 0;
            _context.SikkerhedsLog.Add(sl);
            _context.SaveChanges();
            return sl;
        }

        public SikkerhedsLog? Delete(int id)
        {
            SikkerhedsLog foundSl = _context.SikkerhedsLog.ToList<SikkerhedsLog>().Find(x => x.Id == id);
            if (foundSl != null)
            {
                _context.SikkerhedsLog.Remove(foundSl);
                _context.SaveChanges();
            }

            return foundSl;
        }
    }
}