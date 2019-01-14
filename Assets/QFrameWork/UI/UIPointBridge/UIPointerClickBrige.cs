using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace QFrameWork
{
    public class UIPointerClickBrige : MonoBehaviour,IPointerClickHandler
    {
        public Action<PointerEventData> onPointerClick;
        public Action onClick;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (onPointerClick != null) onPointerClick(eventData);
            if (onClick != null)        onClick();
        }
    }
}