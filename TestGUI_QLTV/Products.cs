namespace TestGUI_QLTV
{
    public class Products
    {
        public string bName { get; set; }
        public string bImage { get; set; }
        public string bActor { get; set; }

        public Products(string name, string image, string actor)
        {
            bName = name;
            bImage = image;
            bActor = actor;

        }
    }
}
