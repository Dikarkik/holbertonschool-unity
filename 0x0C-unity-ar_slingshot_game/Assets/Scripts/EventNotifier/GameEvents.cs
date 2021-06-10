using System;

namespace EventNotifier
{
    public static class GameEvents
    {
        public static Action OnPlaneSelection;

        public static Action OnConfirmPlaneSelection;
        
        public static Action OnCancelPlaneSelection;

        public static Action OnPrepareGame;

        public static Action OnStartGame;
        
        public static Action OnAmmoFired;
        
        public static Action OnTargetDestroyed;
        
        public static Action OnUpdateScore;

        public static Action OnFinishGame;
        
        public static void OnPlaneSelectionEvent() => OnPlaneSelection?.Invoke();

        public static void OnConfirmPlaneSelectionEvent() => OnConfirmPlaneSelection?.Invoke();
        
        public static void OnCancelPlaneSelectionEvent() => OnCancelPlaneSelection?.Invoke();
        
        public static void OnPrepareGameEvent() => OnPrepareGame?.Invoke();

        public static void OnStartGameEvent() => OnStartGame?.Invoke();
        
        public static void OnAmmoFiredEvent() => OnAmmoFired?.Invoke();
        
        public static void OnTargetDestroyedEvent() => OnTargetDestroyed?.Invoke();
        public static void OnUpdateScoreEvent() => OnUpdateScore?.Invoke();

        public static void OnFinishGameEvent() => OnFinishGame?.Invoke();
    }
}