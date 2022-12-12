using System.Drawing;

namespace TagsCloudContainer.Colorers;

public class TransparencyOverFrequencyColorProvider : IColorProvider
{
    private readonly Color Color;

    public TransparencyOverFrequencyColorProvider(ISettingsProvider settingsProvider)
    {
        Color = settingsProvider.Settings.FontColor;
    }

    public Color ProvideColorForWord(string word, int frequency)
    {
        return Color.FromArgb(HTan(frequency), Color);
    }

    private int HTan(int x)
    {
        return (int) ((2 / (1 + Math.Exp(-0.8 * x)) - 1) * 255);
    }
}