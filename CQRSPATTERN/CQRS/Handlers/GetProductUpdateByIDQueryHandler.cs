using CQRSPATTERN.CQRS.Queries;
using CQRSPATTERN.CQRS.Result;
using CQRSPATTERN.DAL;

namespace CQRSPATTERN.CQRS.Handlers
{
    public class GetProductUpdateByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductUpdateByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateQueryResult Handle(GetProductUpdateByIDQuery query)
        {
            var values = _context.CQRSProducts.Find(query.ID);
            return new GetProductUpdateQueryResult
            {
                Description = values.Description,
                ProductID = values.ProductID,
                Price = values.Price,
                Stock = values.Stock,
                Name = values.Name
            };
        }
    }
}
