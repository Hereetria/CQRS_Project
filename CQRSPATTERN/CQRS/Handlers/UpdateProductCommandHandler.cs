using CQRSPATTERN.CQRS.Commands;
using CQRSPATTERN.DAL;

namespace CQRSPATTERN.CQRS.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
            var values = _context.CQRSProducts.Find(command.ProductID);
            values.Name = command.Name;
            values.Price = command.Price;
            values.Description = command.Description;
            values.Status = true;
            values.Stock = command.Stock;
            _context.SaveChanges();
        }
    }
}
