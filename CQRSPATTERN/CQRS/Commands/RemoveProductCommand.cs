namespace CQRSPATTERN.CQRS.Commands
{
    public class RemoveProductCommand
    {
        public RemoveProductCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
