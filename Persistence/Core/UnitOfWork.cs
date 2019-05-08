using Application.Interfaces;

namespace Persistence.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecruiterContext _context;

        public UnitOfWork(RecruiterContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}