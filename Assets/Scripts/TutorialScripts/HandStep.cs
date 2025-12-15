using UnityEngine;

[System.Serializable]
public class HandStep
{
    public RectTransform target;
    public Vector3 offset;    // UI offset (pixels)
    public Vector3 rotation;  // Local rotation
}
