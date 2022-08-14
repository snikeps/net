using System.Text;

namespace Patterns.Builder
{
    public class Burger
    {
        public string Top { get; set; }
        public string Filling { get; set; }
        public string Bottom { get; set; }

        public override string ToString() =>
            new StringBuilder()
                .Append(Top)
                .Append(Filling)
                .Append(Bottom)
                .ToString();

    }
}
