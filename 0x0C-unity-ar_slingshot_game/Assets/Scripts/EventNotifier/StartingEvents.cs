using System;

namespace EventNotifier
{
    public static class StartingEvents
    {
        public static Action OnPlaneSelection;

        public static Action OnConfirmPlaneSelection;
        
        public static Action OnCancelPlaneSelection;
        
        public static void OnPlaneSelectionEvent() => OnPlaneSelection?.Invoke();

        public static void OnConfirmPlaneSelectionEvent() => OnConfirmPlaneSelection?.Invoke();
        
        public static void OnCancelPlaneSelectionEvent() => OnCancelPlaneSelection?.Invoke();
    }
}