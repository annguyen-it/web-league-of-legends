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

        public Position() : this(0) { }

        public Position(int size) : this(size, size) { }

        public Position(int x, int y) : this(y, x, y, x) { }

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
        public string hoverExtends;
        public string color;
        public Position position;
        public string avoidId;
        public string asyncId;
        public string fill;

        public CanvasRect(int size, Vertex border, int width = 2)
        {
            this.size = size;
            this.border = border;
            this.width = width;
            resizable = false;
            animateId = hoverExtends = "";
            color = "#ABABAB";
            position = new Position();
        }

        public CanvasRect(int size = 0) : this(size, new Vertex())
        { }

        public CanvasRect Resizable()
        {
            resizable = true;
            return this;
        }

        public CanvasRect Animate(string id, string hoverExtends = "")
        {
            animateId = id;
            this.hoverExtends = hoverExtends;
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

        public CanvasRect Avoid(string avoidId)
        {
            this.avoidId = avoidId;
            return this;
        }

        public CanvasRect Async(string asyncId)
        {
            this.asyncId = asyncId;
            return this;
        }

        public CanvasRect Fill(string fill)
        {
            this.fill = fill;
            return this;
        }
    }
}