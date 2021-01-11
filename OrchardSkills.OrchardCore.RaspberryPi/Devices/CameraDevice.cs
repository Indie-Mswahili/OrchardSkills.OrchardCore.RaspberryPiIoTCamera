using System;
using System.IO;
using Unosquare.RaspberryIO;

namespace OrchardSkills.OrchardCore.RaspberryPi.Devices
{
    public class CameraDevice : IDisposable
    {
        private bool disposedValue = false;

        public void CaptureImage()
        {
            try
            {
                var currentPath = Directory.GetCurrentDirectory();
                var pos = currentPath.LastIndexOf(Path.DirectorySeparatorChar);
                if (pos > 0)
                {
                    var imagePath = currentPath.Substring(0, pos);
                    var targetPath = imagePath;
                    targetPath += Path.DirectorySeparatorChar;
                    targetPath += "OrchardSkills.OrchardCore.RaspberryPi";
                    targetPath += Path.DirectorySeparatorChar;
                    targetPath += "wwwroot";
                    targetPath += Path.DirectorySeparatorChar;
                    targetPath += "img";
                    targetPath += Path.DirectorySeparatorChar;
                    targetPath += "capture.jpg";

                    var pictureBytes = Pi.Camera.CaptureImageJpeg(640, 480);

                    if (File.Exists(targetPath))
                        File.Delete(targetPath);
                    File.WriteAllBytes(targetPath, pictureBytes);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
