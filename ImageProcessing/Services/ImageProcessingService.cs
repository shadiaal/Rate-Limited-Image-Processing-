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
        // Defines a method that accepts raw image bytes and a filter name, and returns the processed image as bytes.
        public byte[] ApplyFilter(byte[] imageData, string filter)
        {
            // Loads the image from the input byte array into an Image object.
           

            // If the requested filter is "grayscale" (case-insensitive), apply grayscale transformation.
            
             //example   image.Mutate(x => x.Grayscale());

            // If the requested filter is "sepia" (case-insensitive), apply sepia transformation.
           

            // Create a memory stream to store the output (processed image).
          

            // Save the processed image into the memory stream in PNG format.
          

            // Return the processed image as a byte array.
         
        }

    }
}