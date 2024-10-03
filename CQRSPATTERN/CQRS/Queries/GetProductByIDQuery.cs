namespace CQRSPATTERN.CQRS.Queries
{
    public class GetProductByIDQuery
    {
        public GetProductByIDQuery(int iD)
        {
            ID = iD;
        }

        public int ID { get; set; }
    }
}
