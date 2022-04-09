namespace OroClient.Models
{
    public class Data
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Prop
    {
        public Data data { get; set; }
    }

    public class Props
    {
        public Data[] data { get; set; }
    }
}
