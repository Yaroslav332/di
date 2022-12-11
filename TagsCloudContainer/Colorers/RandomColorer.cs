using System.Drawing;

namespace TagsCloudContainer.Colorers;

public class RandomColorer : IColorer
{
    public Color ProvideColorForWord(string word, int frequency)
    {
        var r = new Random();
        return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
    }
}