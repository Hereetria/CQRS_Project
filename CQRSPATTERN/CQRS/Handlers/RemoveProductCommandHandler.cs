using CQRSPATTERN.CQRS.Commands;
using CQRSPATTERN.DAL;

namespace CQRSPATTERN.CQRS.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveProductCommand command) 
        {
            var values = _context.CQRSProducts.Find(command.ID);
            _context.CQRSProducts.Remove(values);
            _context.SaveChanges();
        }
    }
}
