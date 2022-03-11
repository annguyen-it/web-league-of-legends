namespace LeagueOfLegends.Models.Components
{
    public class Vertex
    {
        public bool topLeft;
        public bool topRight;
        public bool bottomLeft;
        public bool bottomRight;

        public Vertex()
        {
            topLeft = topRight = bottomLeft = bottomRight = false;
        }

        public Vertex WithTopLeft() { topLeft = true; return this; }
        public Vertex WithTopRight() { topRight = true; return this; }
        public Vertex WithBottomLeft() { bottomLeft = true; return this; }
        public Vertex WithBottomRight() { bottomRight = true; return this; }
    }

    public class CanvasRect
    {
        public Vertex border;
        public int size;
        public int width;
        public bool resizable;
        public string animateId;
        public string color;

        public CanvasRect(int size = 0, Vertex border = null, int width = 2)
        {
            this.size = size;
            this.border = border;
            this.width = width;
            resizable = false;
            animateId = "";
            color = "#ABABAB";
        }

        public CanvasRect Resizable()
        {
            resizable = true;
            return this;
        }

        public CanvasRect Animate(string id)
        {
            animateId = id;
            return this;
        }

        public CanvasRect WithColor(string color)
        {
            this.color = color;
            return this;
        }
    }
}