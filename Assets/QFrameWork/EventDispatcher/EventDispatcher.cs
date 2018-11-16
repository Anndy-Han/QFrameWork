using System;
using System.Collections.Generic;

namespace QFrameWork
{
    public class EventDispatcher:IEventDispatcher,IPlugin
    {
        private static Dictionary<string,List<Action<object,object>>> messageCenterDic = new Dictionary<string, List<Action<object, object>>>();

        public static void Clear()
        {
            messageCenterDic.Clear();
        }

        public void Subscribe(string str, Action<object, object> handler)
        {
            if (messageCenterDic.ContainsKey(str))
            {
                messageCenterDic[str].Add(handler);
            }
            else
            {
                List<Action<object, object>> actionList = new List<Action<object, object>>();

                actionList.Add(handler);

                messageCenterDic.Add(str, actionList);
            }
        }

        public void UnSubscribe(string str, Action<object, object> handler)
        {
            if (!messageCenterDic.ContainsKey(str))
            {
                throw new ArgumentNullException(str);
            }
            for (int i = 0; i < messageCenterDic[str].Count; i++)
            {
                messageCenterDic[str].Remove(handler);
            }
        }

        public void Post(string str)
        {
            Post(str,null,null);
        }

        public void Post(string str, object sender, object args)
        {
            if (messageCenterDic.ContainsKey(str))
            {
                for (int i = 0; i < messageCenterDic[str].Count; i++)
                {
                    messageCenterDic[str][i](sender, args);
                }
            }
            else
            {
                throw new ArgumentNullException(str);
            }
        }

        public void Load()
        {
            UnityEngine.Debug.Log("Load");
        }
    }
}
