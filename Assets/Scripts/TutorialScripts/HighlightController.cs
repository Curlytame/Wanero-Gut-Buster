using UnityEngine;
using System.Collections.Generic;

public class HighlightController : MonoBehaviour
{
    [Header("Parent & Arrows")]
    public Transform highlightParent;
    public Transform topArrow;
    public Transform bottomArrow;
    public Transform leftArrow;
    public Transform rightArrow;

    public List<HighlightStep> steps = new List<HighlightStep>();

    public void PlayStep(int index)
    {
        if (index < 0 || index >= steps.Count) return;

        HighlightStep step = steps[index];

        if (highlightParent == null) return;

        // Activate highlight
        highlightParent.gameObject.SetActive(true);

        // Move parent to step target
        if (step.parentTarget != null)
            highlightParent.position = step.parentTarget.position;

        float halfWidth = step.width / 2f;
        float halfHeight = step.height / 2f;

        // Position arrows based on width/height
        if (topArrow != null) topArrow.localPosition = new Vector3(0f, halfHeight, 0f);
        if (bottomArrow != null) bottomArrow.localPosition = new Vector3(0f, -halfHeight, 0f);
        if (leftArrow != null) leftArrow.localPosition = new Vector3(-halfWidth, 0f, 0f);
        if (rightArrow != null) rightArrow.localPosition = new Vector3(halfWidth, 0f, 0f);
    }
}
