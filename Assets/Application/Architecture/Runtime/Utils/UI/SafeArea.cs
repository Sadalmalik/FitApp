using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sadalmelik.FitApp.Architecture
{
    //[ExecuteInEditMode]
    public class SafeArea : MonoBehaviour
    {
        private Canvas _canvas;
        private RectTransform _rectTransform;
        private ScreenMonitor _screenMonitor;

        public bool ApplyInUpdate = false;
        
        void Start()
        {
            _canvas = GetComponentInParent<Canvas>();
            _rectTransform = transform as RectTransform;
            _screenMonitor = ScreenMonitor.Instance;

            Apply();
            
            _screenMonitor.OnResolutionChange.AddListener(HandleResolutionChanged);
            _screenMonitor.OnOrientationChange.AddListener(HandleOrientationChanged);
        }

        private void HandleResolutionChanged(Vector2Int rsolution)
        {
            Apply();
        }

        private void HandleOrientationChanged(DeviceOrientation orientation)
        {
            Apply();
        }

        private void Update()
        {
            if (ApplyInUpdate)
                Apply();
        }

        private void Apply()
        {
            var safeArea = Screen.safeArea;

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            var pixelRect = _canvas.pixelRect;
            anchorMin.x /= pixelRect.width;
            anchorMin.y /= pixelRect.height;
            anchorMax.x /= pixelRect.width;
            anchorMax.y /= pixelRect.height;

            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
    }
}