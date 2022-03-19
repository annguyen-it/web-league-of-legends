using LeagueOfLegends.Models.Core;

namespace LeagueOfLegends.Models.Components
{
    public class Transition
    {
        public readonly int property;
        public readonly int duration;
        public readonly string easing;

        public Transition(int property, int duration = 200, string easing = "linear")
        {
            this.property = property;
            this.duration = duration;
            this.easing = easing;
        }
    }

    public class SvgAttr
    {
        public readonly string color;
        public Transition transition { get; private set; }
        public Size size;

        public SvgAttr(Size size, string color = "#ffffff")
        {
            this.color = color;
            this.size = size;
            transition = null;
        }

        public SvgAttr(string size, string color = "#ffffff") : this(new Size(size), color)
        { }

        public SvgAttr(int size, string color = "#ffffff") : this(new Size(size), color)
        { }

        public SvgAttr Transition(Transition transition)
        {
            this.transition = transition;
            return this;
        }
    }

    public class Svg
    {
        public readonly string html;
        public SvgAttr attr { get; private set; }

        public Svg(string html, SvgAttr attr)
        {
            this.html = html;
            this.attr = attr;
        }

        public Svg(string html, Size size, string color = "#ffffff") : this(html, new SvgAttr(size, color))
        { }
    }
}