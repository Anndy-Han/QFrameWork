using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace QFrameWork
{
    public class UIPointerDownBrige : MonoBehaviour,IPointerDownHandler
    {
        public Action<PointerEventData> onPointerDown;
        public Action onDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (onPointerDown != null) onPointerDown(eventData);
            if (onDown != null)        onDown();
        }
    }
    
}