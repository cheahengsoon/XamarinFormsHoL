using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XMenuApp.Model;
using XMenuApp.Droid.Model;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationAndroid))]
namespace XMenuApp.Droid.Model
{
    public class DeviceOrientationAndroid : IDeviceOrientation
    {
        DeviceOrientations IDeviceOrientation.GetOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            var rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
        }
    }
}