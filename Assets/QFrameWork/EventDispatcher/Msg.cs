using System.Collections.Generic;

namespace QFrameWork
{
    [System.Serializable]
    public class Msg:Dictionary<string,object>
    {
        [UnityEngine.SerializeField]
        public int intValue
        {
            get;set;
        }
        [UnityEngine.SerializeField]
        public string stringValue
        {
            get;set;
        }

        public Msg():base()
        {

        }
    }
}
