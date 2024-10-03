using CQRSPATTERN.CQRS.Result;
using CQRSPATTERN.DAL;

namespace CQRSPATTERN.CQRS.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _context.CQRSProducts.Select(x=> new GetProductQueryResult
            {
                ID = x.ProductID,
                Price = x.Price,
                ProductName = x.Name,
                Stock = x.Stock
            }).ToList();
            return values;
        }
    }
}
