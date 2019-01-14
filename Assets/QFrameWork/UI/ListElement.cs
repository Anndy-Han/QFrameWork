using System;
using System.Collections.Generic;
using UnityEngine;

namespace QFrameWork
{
    public abstract class ListElement<D>
    {
        internal protected RectTransform transform;

        public int index { get; internal set; }

        public abstract void OnEnable();

        public abstract void OnDataChanged(D data);
    }

    public class ListWidgetBridge<T, D> : BaseView where T : ListElement<D>, new()
    {

        ListWidget listWidget;
        Dictionary<RectTransform, T> items = new Dictionary<RectTransform, T>();

        List<D> m_sourceData;
        public List<D> sourceData
        {
            set
            {
                m_sourceData = value;
                Refresh();
            }
            get
            {
                return m_sourceData;
            }
        }

        public override void BindWidget(Widget widget)
        {
            base.BindWidget(widget);
            listWidget = this.widget as ListWidget;
            listWidget.Init(OnItemInstantiated, OnItemRefresh);
        }

        void OnItemInstantiated(RectTransform transform)
        {
            var temp = new T();
            temp.transform = transform;
            temp.OnEnable();

            items.Add(transform, temp);
        }

        void OnItemRefresh(RectTransform transform, int index)
        {
            var temp = items[transform];
            temp.index = index;
            if (m_sourceData != null)
            {
                var data = m_sourceData[index];
                temp.OnDataChanged(data);
            }
        }

        public void Refresh()
        {
            if (m_sourceData == null)
            {
                listWidget.totalCount = 0;
                return;
            }
            if (listWidget == null)
                return;
            listWidget.totalCount = m_sourceData.Count;
        }

        public void Repaint(int offset)
        {
            listWidget.RefillCells(offset);
        }

        public void RepaintFromReverse(int offset)
        {
            listWidget.RefillCellsFromEnd(offset);
        }

        public void Repaint()
        {
            listWidget.RefreshCells();
        }
    }
}
