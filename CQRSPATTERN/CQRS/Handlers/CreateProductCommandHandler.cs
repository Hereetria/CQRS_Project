using CQRSPATTERN.CQRS.Commands;
using CQRSPATTERN.DAL;

namespace CQRSPATTERN.CQRS.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand command)
        {
            _context.CQRSProducts.Add(new Product
            {
                Description = command.Description,
                Name = command.Name,
                Price = command.Price,
                Status = true,
                Stock = command.Stock
            });
            _context.SaveChanges();
        }

        internal void Handle(RemoveProductCommand removeProductCommand)
        {
            throw new NotImplementedException();
        }
    }
}
