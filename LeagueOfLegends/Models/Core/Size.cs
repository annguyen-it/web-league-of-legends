namespace LeagueOfLegends.Models.Core
{
    public class Size
    {
        public string width;
        public string height;

        public Size(string width, string height)
        {
            this.width = width;
            this.height = height;
        }

        public Size(string size) : this(size, size) { }

        public Size(int size) : this(size.ToString() + "px") { }

        public Size(int width, int height) : this(width.ToString() + "px", height.ToString() + "px") { }
    }
}