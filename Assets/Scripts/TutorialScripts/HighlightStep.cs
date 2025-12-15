using UnityEngine;

[System.Serializable]
public class HighlightStep
{
    [Header("Parent Target (Empty GameObject)")]
    public Transform parentTarget;

    [Header("Highlight Size")]
    public float width = 200f;
    public float height = 100f;
}
