using CQRSPATTERN.CQRS.Commands;
using CQRSPATTERN.CQRS.Handlers;
using CQRSPATTERN.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPATTERN.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductUpdateByIDQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, GetProductByIDQueryHandler getProductByIDQueryHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIDQueryHandler getProductUpdateByIDQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductUpdateByIDQueryHandler = getProductUpdateByIDQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command) 
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(int id)
        {
            var values = _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            _createProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction();
        }
    }
}
