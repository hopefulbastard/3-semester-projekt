using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library
{
    //Magnus + Milo

    public class SMSLogRepositoryDB : ISMSLogRepository
    {
        private readonly SMSLogDBContext _context;

        public SMSLogRepositoryDB(SMSLogDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }

        public IEnumerable<SMSLog> Get(int? idFørst = null,
                                              int? idSidst = null,
                                              string? orderBy = null,
                                              bool descending = false)
        {
            IQueryable<SMSLog> result = _context.SMSLog.AsQueryable();

            if (idFørst != null)
            {
                result = result.Where<SMSLog>(s => s.Id < idFørst);
            }

            if (idSidst != null)
            {
                result = result.Where<SMSLog>(s => s.Id > idSidst);
            }

            return result;
        }

        public SMSLog Add(SMSLog smsl)
        {
            smsl.Validate();
            smsl.Id = 0;
            _context.SMSLog.Add(smsl);
            _context.SaveChanges();
            return smsl;
        }

        public SMSLog? Delete(int id)
        {
            SMSLog foundSMSl = _context.SMSLog.ToList<SMSLog>().Find(x => x.Id == id);
            if (foundSMSl != null)
            {
                _context.SMSLog.Remove(foundSMSl);
                _context.SaveChanges();
            }

            return foundSMSl;
        }
    }
}
