namespace Order
{
    public interface IItemLine
    {
        string Description { get; set; }
        ItemLineType Type { get; set; }
    }
}
