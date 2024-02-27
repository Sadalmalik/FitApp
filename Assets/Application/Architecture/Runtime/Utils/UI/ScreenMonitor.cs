using UnityEngine;
using UnityEngine.Events;

namespace Sadalmelik.FitApp.Architecture
{
    public class ScreenMonitor : SingletonMonoBehaviour<ScreenMonitor>
    {
        public UnityEvent<Vector2Int> OnResolutionChange;
        public UnityEvent<DeviceOrientation> OnOrientationChange;

        private Vector2Int _lastResolution;
        private DeviceOrientation _lastOrientation;

        protected override void Init()
        {
            _lastResolution = new Vector2Int(Screen.width, Screen.height);
            _lastOrientation = Input.deviceOrientation;
        }
        
        private void Update()
        {
            if (_lastResolution.x != Screen.width ||
                _lastResolution.y != Screen.height )
            {
                _lastResolution = new Vector2Int(Screen.width, Screen.height);
                OnResolutionChange.Invoke(_lastResolution);
                Debug.Log($"Device model: {SystemInfo.deviceModel}");
            }
            
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.Unknown:
                case DeviceOrientation.FaceUp:
                case DeviceOrientation.FaceDown:
                    break;
                default:
                    if (_lastOrientation != Input.deviceOrientation)
                    {
                        _lastOrientation = Input.deviceOrientation;
                        OnOrientationChange.Invoke(_lastOrientation);
                        Debug.Log($"Device model: {SystemInfo.deviceModel}");
                    }
                    break;
            }
        }
    }
}