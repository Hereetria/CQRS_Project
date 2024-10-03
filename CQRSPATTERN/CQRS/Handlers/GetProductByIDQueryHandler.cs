using CQRSPATTERN.CQRS.Queries;
using CQRSPATTERN.CQRS.Result;
using CQRSPATTERN.DAL;

namespace CQRSPATTERN.CQRS.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDQueryResult Handle(GetProductByIDQuery query)
        {
            var values = _context.Set<Product>().Find(query.ID);
            return new GetProductByIDQueryResult
            {
                Name = values.Name,
                Price = values.Price,
                ProductID = values.ProductID,
                Stock = values.Stock
            };
        }
    }
}
