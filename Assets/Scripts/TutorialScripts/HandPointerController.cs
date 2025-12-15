using UnityEngine;
using System.Collections.Generic;

public class HandPointerController : MonoBehaviour
{
    public RectTransform handRect;
    public List<HandStep> steps = new List<HandStep>();

    public void PlayStep(int index)
    {
        if (handRect == null)
            return;

        if (index < 0 || index >= steps.Count)
            return;

        HandStep step = steps[index];

        if (step.target == null)
            return;

        handRect.gameObject.SetActive(true);

        // ✅ Vector2 + Vector2 (FIX)
        handRect.anchoredPosition =
            step.target.anchoredPosition + (Vector2)step.offset;

        handRect.localRotation = Quaternion.Euler(step.rotation);
    }
}
