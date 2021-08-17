using UnityEngine;

namespace CompalControllerSdk.Client
{
    public class CompalControllerSdkUtils
    {
        private readonly static string TAG = "[CompalControllerSdkUtils]";

        public static void registerControllerCallback(ICompalControllerLibCallback callback)
        {
            if (null == Log.Instance)
            {
                Log.CreateInstance(true);
            }

            Log.Instance.V(TAG, "registerControllerCallback");
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass proxyClass = new AndroidJavaClass("com.compal.controllerlib.CompalControllerUnityProxy");
            proxyClass.CallStatic("registerCompalControllerCallback", activity, callback);
        }

        public static void unRegisterControllerCallback()
        {
            Log.Instance.V(TAG, "unRegisterControllerCallback");
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass proxyClass = new AndroidJavaClass("com.compal.controllerlib.CompalControllerUnityProxy");
            proxyClass.CallStatic("unRegisterCompalControllerCallback", activity);
        }

        public static void getDevices()
        {
            Log.Instance.V(TAG, "getDevices");
            AndroidJavaClass proxyClass = new AndroidJavaClass("com.compal.controllerlib.CompalControllerUnityProxy");
            proxyClass.CallStatic("getDevices");
        }

        public static void bindDevice(AndroidJavaObject device)  //DeviceInfoSimple
        {
            Log.Instance.V(TAG, "bindDevice");
            AndroidJavaClass proxyClass = new AndroidJavaClass("com.compal.controllerlib.CompalControllerUnityProxy");
            proxyClass.CallStatic("bindDevice", device);
        }

        public static void unBindDevice(AndroidJavaObject device)  //DeviceInfoSimple
        {
            Log.Instance.V(TAG, "unBindDevice");
            AndroidJavaClass proxyClass = new AndroidJavaClass("com.compal.controllerlib.CompalControllerUnityProxy");
            proxyClass.CallStatic("unBindDevice", device);
        }

        public static ControllerDeviceInfo convertAndroidObjectToDeviceInfo(AndroidJavaObject device)
        {
            Log.Instance.V(TAG, "convertAndroidObjectToDeviceInfo");
            ControllerDeviceInfo deviceInfo = new ControllerDeviceInfo();
            deviceInfo.index = device.Call<int>("getIndex");
            deviceInfo.deviceAddress = device.Call<string>("getDeviceAddress");
            deviceInfo.deviceName = device.Call<string>("getDeviceName");
            deviceInfo.displayName = device.Call<string>("getDisplayName");
            deviceInfo.streamState = device.Call<int>("getStreamState");
            deviceInfo.streamTypeName = device.Call<string>("getStreamTypeName");
            deviceInfo.xCobraName = device.Call<string>("getXCobraName");
            return deviceInfo;
        }

        public static AndroidJavaObject convertDeviceInfoToAndroidObject(ControllerDeviceInfo device)
        {
            Log.Instance.V(TAG, "convertDeviceInfoToAndroidObject");
            AndroidJavaObject deviceInfo = new AndroidJavaObject("com.ximmerse.xtools.DeviceInfoSimple",
                device.index, device.deviceAddress, device.deviceName, device.displayName, device.streamState,
                device.streamTypeName, device.xCobraName);
            return deviceInfo;
        }
    }
}