using System.IO;
using UnityEngine;
using System.Collections.Generic;
using LitJson;
using System;

namespace QFrameWork
{
    /// <summary>
    /// 加载类
    /// </summary>
    public class LoadManager:ILoadManager,IPlugin
    {
        /// <summary>
        /// 模拟应用的沙盒路径
        /// </summary>
        public static bool simulationMobile = false;

        public T LoadJson<T>(string path)
        {
            string str = LoadText(path);

            T t = JsonMapper.ToObject<T>(str);

            return t;
        }

        /// <summary>
        /// 加载Text类型的文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public string LoadText(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError(path+"路径不存在");
                return null;
            }
            return File.ReadAllText(path);
        }

        /// <summary>
        /// 加载Csv类型的文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Dictionary<string,string> LoadCsv(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError(path + "路径不存在");
                return null;
            }
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            
            StreamReader streamReader = null;

            try
            {
                streamReader = File.OpenText(path);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }

            string line = string.Empty ;
            while ((line= streamReader.ReadLine())!=null)
            {
                keyValues.Add(line.Split(',')[0], line.Split(',')[1]);
            }   
            streamReader.Close();

            streamReader.Dispose();

            return keyValues;
        }

        public string DataPath()
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (simulationMobile)//模拟移动平台的沙盒路径
                return Application.dataPath + "/persistentDataPath";
            return Application.streamingAssetsPath;
#elif UNITY_ANDROID
            return Application.persistentDataPath;
#elif UNITY_IPHONE
            return Application.persistentDataPath;
#endif
        }

        public string StreamingAssetsPath()
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            return "file://" + Application.streamingAssetsPath;
#elif UNITY_ANDROID
            return "jar:file://" + Application.dataPath + "!/assets";
#elif UNITY_IPHONE
            return "file://"+Application.streamingAssetsPath;
#endif
        }

        public void Load()
        {
            
        }
    }
}
