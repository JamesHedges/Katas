namespace Order
{
    public class ItemLine : IItemLine
    {
        public string Description { get; set; }
        public ItemLineType Type { get; set; }
    }
}
