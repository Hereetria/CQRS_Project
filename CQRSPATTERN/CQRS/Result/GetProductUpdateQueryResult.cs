﻿namespace CQRSPATTERN.CQRS.Result
{
    public class GetProductUpdateQueryResult
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
