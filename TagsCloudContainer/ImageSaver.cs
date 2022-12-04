using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudContainer;

public class ImageSaver
{
    private readonly Settings settings;

    public ImageSaver(ISettingsProvider settingsProvider)
    {
        settings = settingsProvider.Settings;
    }

    public void Save(Bitmap bitmap)
    {
        if (!Directory.Exists(Path.GetDirectoryName(settings.SavePath)))
            Directory.CreateDirectory(Path.GetDirectoryName(settings.SavePath));
        bitmap.Save(settings.SavePath, ImageFormat.Jpeg);
    }
}