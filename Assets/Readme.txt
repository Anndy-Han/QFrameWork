一
1.框架的入口在App类。
2.EventDispatcher提供消息中心。
3.LoadManager提供加载文件。
4.ResourcesManager提供资源加载，卸载。
5.SceneManager负责场景管理。
6.UIManager负责UI管理。
7.ProcedureManager负责流程管理。

二
1.所有类的基类是Object。
2.继承Monobehaviour的类改为继承QBehaviour。
3.所有View的基类为BaseView。
4.所有Procedure的基类为BaseProdecure。

三
1.通过流程控制游戏。
2.App启动的时候会通过读取配置加载所有配置好的流程的OnLoad。
3.流程切换通过ChangeProcedure，可以进入或者离开某个流程，分别执行这个流程的OnEnter和OnLeave。
4.所有的View通过绑定自己的Widget来作为本页面的处理器。

四
1.点击菜单栏QFrameWork--GenUIViewCode可以一键生成对应UI面板的代码
2.需要给定一个UI的Prefab,可以查找控件,声明对应的变量,查找变量并且复制,绑定事件.