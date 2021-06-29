using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFrameWork;
using System;

namespace QFrameWork.Demo
{
    public class LoginProcedure : BaseProcedure
    {
        private LoginView view;

        public override void OnLoad()
        {
            base.OnLoad();
        }

        public override void OnAwake()
        {
            base.OnAwake();

            view = new LoginView(LoadWidget("LoginView"));

            view.onClickLogin += OnClickLogin;

            Debug.Log("LoginProcedure-OnAwake");
        }

        private void OnClickLogin(string arg1, string arg2)
        {
            Msg msg = CreateProcedureEnter("QFrameWork.Demo.HallProcedure");

            msg.Add("account", arg1);

            msg.Add("password", arg2);

            ChangeProcedure(msg);

            ChangeProcedure(CreateProcedureLeave("QFrameWork.Demo.LoginProcedure"));
        }

        public override void OnEnter(Msg msg)
        {
            base.OnEnter(msg);

            view.Show();

            Debug.Log("LoginProcedure-OnEnter");
        }

        public override void OnLeave(Msg msg)
        {
            base.OnLeave(msg);

            view.Close();

            Debug.Log("LoginProcedure-OnLeave");
        }
    }
}