namespace StockCommerce.Transversal.Common
{
    public class Response<T>
    {
        public bool success { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public dynamic result { get; set; }
    }
}
