using System.Collections.Generic;

namespace QFrameWork
{
    public class Msg:Dictionary<string,object>
    {
        public int intValue
        {
            get;set;
        }

        public string stringValue
        {
            get;set;
        }

        public Msg():base()
        {

        }
    }
}
