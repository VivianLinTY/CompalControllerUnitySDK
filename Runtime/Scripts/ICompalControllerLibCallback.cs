using UnityEngine;

namespace CompalControllerSdk.Client
{
    abstract public class ICompalControllerLibCallback : AndroidJavaProxy
    {
        public ICompalControllerLibCallback() : base("com.compal.controllerlib.ICompalControllerLibCallback")
        {
        }

        abstract public void onGetDevices(AndroidJavaObject devices);  //List<DeviceInfoSimple>

        abstract public void onDeviceStateChange(AndroidJavaObject device);  //DeviceInfoSimple
    }
}