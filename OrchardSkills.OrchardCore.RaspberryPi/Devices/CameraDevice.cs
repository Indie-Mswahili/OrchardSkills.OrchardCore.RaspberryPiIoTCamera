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
                var pictureBytes = Pi.Camera.CaptureImageJpeg(640, 480);
                var targetPath = "/home/pi/picture.jpg";
                if (File.Exists(targetPath))
                    File.Delete(targetPath);
                File.WriteAllBytes(targetPath, pictureBytes);
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
