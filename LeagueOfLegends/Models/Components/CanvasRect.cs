namespace LeagueOfLegends.Models.Components
{
    public class Border
    {
        public bool? topLeft;
        public bool? topRight;
        public bool? bottomLeft;
        public bool? bottomRight;
    }

    public class CanvasRect
    {
        public Border border;
        public int size;

        public CanvasRect(int size = 0, Border border = null)
        {
            this.size = size;
            this.border = border;
        }
    }
}