一
1.框架的入口在App类。
2.EventDispatcher提供消息中心。
3.LoadManager提供加载方法。
4.ResourcesManager提供资源加载，卸载。
5.SceneManager负责场景管理。
6.UIManager负责UI管理。
7.ProcedureManager负责流程管理。
8.AudioManager负责音乐管理.

二
Procedure流程层
1.Procedure的基类为BaseProcedre,每个Procedure有自己的生命周期函数,分别为:
	<1>OnLoad--在引擎刚启动的时候执行,具体的使用方法需要在AppMate的ProcedureMates配置,一般进行消息的注册
	<2>OnAwake--在初次进入本Procedure的时候执行,一般进行初始化操作
	<3>OnEnter--每次进入本Procedure的时候执行,如果是初次进入,会在执行完OnAwake之后执行,一般会打开本Procedure所持有的View
	<4>OnLeave--每次离开本Procedure的时候执行,一般会关闭本Procedure所持有的View
	<5>OnUnload--卸载本Procedure,一般取消消息注册
2.不同Procedure相互切换通过Msg类,Msg对象是一个字典,key是string类型,值是object类型.
  假如从登录流程进入到大厅流程,登录流程为LoginProcedure,大厅流程为HallProceduer,切换流程方法为ChangeProcedure,我们需要这样做:
  Msg msg = new Msg("HallProcedure");
  msg.intValue = 0;
  ChangeProcedure(msg);
  流程管理器就会执行HallProcedure的OnEnter方法,打开对应的View,相应的,也需要离开LoginProcedure

三
View视图层
1.View的基类为BaseView,每个View有自己的生命周期函数,分别为:
	<1>Show--打开本View的时候时候调用
	<2>Close--关闭本View的时候调用
	<3>OnEnter--打开本view的时候Show方法会调用OnEnter方法进入视图,一般做特殊的进场动画
	<4>OnExit--关闭本View的时时候Close方法会调用OnExit方法离开视图,一般做特殊的离场动画
	<5>OnPause--面板的暂停状态,取消面板的交互能力
	<6>OnResume--面板的还原状态,恢复面板的交互能力

四
1.点击菜单栏QFrameWork--GenUIViewCode可以一键生成对应UI面板的代码
2.需要给定一个UI的Prefab,可以查找控件,声明对应的变量,查找变量并且复制,绑定事件.