using UnityEngine;

[System.Serializable]
public class TextStep
{
    [TextArea(3, 5)]
    public string message;

    public RectTransform target;   // Empty UI object
}
