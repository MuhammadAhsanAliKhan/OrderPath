namespace OrderPathBackend
{
    public class Order
    {
        public DateTime Date { get; set; }

        public string? PlacedBy {  get; set; }

        public string? Item { get; set; }
    }
}
