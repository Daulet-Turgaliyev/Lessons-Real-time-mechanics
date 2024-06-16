using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Example.Security
{
    public static class ServerTimeManager
    {
        private static DateTime serverBaseTime;
        private static DateTime localBaseTime;
        public static bool isActualTimeReceived;

        private const string SERVER_TIME_URL = "https://worldtimeapi.org/api/timezone/Etc/UTC";
        

        public static async UniTask Initialize()
        {
            await FetchServerTime();
        }

        public static DateTime GetCurrentTime()
        {
            if (isActualTimeReceived == false) throw new Exception("Actual Time Not Recived");
            
            TimeSpan elapsed = DateTime.Now - localBaseTime;
            return serverBaseTime.Add(elapsed);
        }

        private static async UniTask FetchServerTime()
        {
            var webRequest = UnityWebRequest.Get(SERVER_TIME_URL);
            await webRequest.SendWebRequest().ToUniTask();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error fetching time: " + webRequest.error);
            }
            else
            {
                ServerTimeResponse timeInfo = JsonUtility.FromJson<ServerTimeResponse>(webRequest.downloadHandler.text);

                serverBaseTime = DateTime.Parse(timeInfo.datetime);
                localBaseTime = DateTime.Now;
                isActualTimeReceived = true;
            }
        }
    }
}

[Serializable]
public class ServerTimeResponse
{
    public string datetime;
}