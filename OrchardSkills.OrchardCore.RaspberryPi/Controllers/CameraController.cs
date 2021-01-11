using Microsoft.AspNetCore.Mvc;
using OrchardSkills.OrchardCore.RaspberryPi.Devices;

namespace OrchardSkills.OrchardCore.RaspberryPi.Controllers
{

    public class CameraController  : Controller
    {
        private readonly CameraDevice _cameraDevice;

        public CameraController (CameraDevice cameraDevice)
        {
            _cameraDevice = cameraDevice;
        }

        public IActionResult Index()
        {
            ViewBag.WasImageCaptured = _cameraDevice.WasImageCaptured ? "Yes" : "No";
            return View();
        }

        public IActionResult CaptureImage()
        {
            _cameraDevice.CaptureImage();

            return RedirectToAction(nameof(Index));
        }
    }
}
