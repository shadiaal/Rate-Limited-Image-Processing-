using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;

namespace ImageProcessingApi.Services
{
    public interface IImageProcessingService
    {
        byte[] ApplyFilter(byte[] imageData, string filter);
    }

    public class ImageProcessingService : IImageProcessingService
    {
	
		public byte[] ApplyFilter(byte[] imageData, string filter)
		{
			using var image = Image.Load(imageData);

			if (filter.Equals("grayscale", StringComparison.OrdinalIgnoreCase))
			{
				image.Mutate(x => x.Grayscale());
			}
			else if (filter.Equals("sepia", StringComparison.OrdinalIgnoreCase))
			{
				image.Mutate(x => x.Sepia());
			}

			using var ms = new MemoryStream();
			image.Save(ms, new PngEncoder());
			return ms.ToArray();
		}

	}
}