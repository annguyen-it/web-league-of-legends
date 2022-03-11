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

        public Vertex TopLeft() { topLeft = true; return this; }
        public Vertex TopRight() { topRight = true; return this; }
        public Vertex BottomLeft() { bottomLeft = true; return this; }
        public Vertex BottomRight() { bottomRight = true; return this; }
    }

    public class Position
    {
        public int top;
        public int right;
        public int bottom;
        public int left;

        public Position() : this(0, 0) { }

        public Position(int x, int y) : this (y, x, y, x) { }

        public Position(int top, int right, int bottom, int left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }
    }

    public class CanvasRect
    {
        public Vertex border;
        public int size;
        public int width;
        public bool resizable;
        public string animateId;
        public string color;
        public Position position;

        public CanvasRect(int size = 0, Vertex border = null, int width = 2)
        {
            this.size = size;
            this.border = border;
            this.width = width;
            resizable = false;
            animateId = "";
            color = "#ABABAB";
            position = new Position();
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

        public CanvasRect Color(string color)
        {
            this.color = color;
            return this;
        }

        public CanvasRect Position(Position position)
        {
            this.position = position;
            return this;
        }
    }
}