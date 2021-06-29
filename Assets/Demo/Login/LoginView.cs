using System;
using System.Collections.Generic;
using UnityEngine;
using QFrameWork;
using UnityEngine.UI;

namespace QFrameWork.Demo
{
    public class LoginView : BaseView
    {
        public LoginView(Widget widget) : base(widget)
        {

        }

        public Action<string, string> onClickLogin;

        private InputField mAccountInput;

        private InputField mPassword;

        public override void Init()
        {
            base.Init();

            mAccountInput = transform.Find("Bg/Account").GetComponent<InputField>();

            mPassword = transform.Find("Bg/Password").GetComponent<InputField>();

            SetButtonListener("Bg/Login", () =>
            {
                if (onClickLogin != null)
                {
                    onClickLogin(mAccountInput.text, mPassword.text);
                }
            });
        }
    }
}