using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFrameWork;

namespace QFrameWork.Demo
{
    public class HallProcedure : BaseProcedure
    {
        private HallView view;

        public override void OnAwake()
        {
            base.OnAwake();

            Debug.Log("HallProcedure-OnEnter");

            view = new HallView(LoadWidget("HallView"));
        }

        public override void OnEnter(Msg msg)
        {
            base.OnEnter(msg);

            view.Show();

            if (msg.ContainsKey("account"))
            {
                Debug.Log(msg["account"]);
            }
            if (msg.ContainsKey("password"))
            {
                Debug.Log(msg["password"]);
            }

            Debug.Log("HallProcedure-OnEnter");
        }

        public override void OnLeave(Msg msg)
        {
            base.OnLeave(msg);

            view.Close();

            Debug.Log("HallProcedure-OnEnter");
        }
    }
}