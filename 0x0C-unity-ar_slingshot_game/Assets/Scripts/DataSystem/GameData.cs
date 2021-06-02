using UnityEngine.XR.ARFoundation;

namespace DataSystem
{
    public static class GameData
    {
        public static ARPlane Plane { get; private set; }

        public static void SetPlane(ARPlane plane)
        {
            Plane = plane;
        }
    }
}
