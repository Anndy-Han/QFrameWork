using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFrameWork;

public class LoginProcedure : BaseProcedure
{
    public override void OnLoad()
    {
        base.OnLoad();
        Debug.Log("OnLoad");
    }

    public override void OnAwake()
    {
        base.OnAwake();
        Debug.Log("OnAwake");
    }

    public override void OnEnter(Msg msg)
    {
        base.OnEnter(msg);
        Debug.Log("OnEnter");
    }
}
