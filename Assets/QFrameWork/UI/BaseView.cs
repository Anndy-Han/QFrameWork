using System;
using UnityEngine;

namespace QFrameWork
{
    public abstract class BaseView:Object
    {
        public Widget widget;

        private GameObject m_gameObject;

        private Transform m_transform;

        public BaseView()
        {

        }

        public BaseView(Widget widget)
        {
            this.widget = widget;

            Init();
        }

        public void BindWidget(Widget widget)
        {
            this.widget = widget;
        }

        public virtual void Init()
        {
            this.m_gameObject = widget.gameObject;

            this.m_transform = widget.transform;
        }

        public Widget GetChildWidget(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(path);
            }
            return this.transform.Find(path).GetComponent<Widget>();
        }

        public T GetChildView<T>(string path) where T: BaseView,new ()
        {
            BaseView baseView = null;

            Widget widget = GetChildWidget(path);

            baseView = new T();

            baseView.BindWidget(widget);

            return baseView as T;
        }

        public GameObject gameObject
        {
            get { return this.m_gameObject; }
        }

        public Transform transform
        {
            get { return this.m_transform; }
        }

        public virtual void Show()
        {
            this.uiManager.Show(this);
        }

        public virtual void Close()
        {
            this.uiManager.Close(this);
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void OnPause()
        {

        }

        public virtual void OnResume()
        {

        }
    }
}
