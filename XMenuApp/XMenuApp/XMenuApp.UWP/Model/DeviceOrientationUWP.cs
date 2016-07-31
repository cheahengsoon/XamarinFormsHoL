using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XMenuApp.Model;
using XMenuApp.UWP.Model;

[assembly: Dependency(typeof(DeviceOrientationUWP))]
namespace XMenuApp.UWP.Model
{
    public class DeviceOrientationUWP : IDeviceOrientation
    {
        DeviceOrientations IDeviceOrientation.GetOrientation()
        {
            var orientation = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Orientation;
            if (orientation == Windows.UI.ViewManagement.ApplicationViewOrientation.Landscape)
            {
                return DeviceOrientations.Landscape;
            }
            else
            {
                return DeviceOrientations.Portrait;
            }
        }
    }
}
