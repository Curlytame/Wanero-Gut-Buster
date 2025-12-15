using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TutorialTextController : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public RectTransform textBox;
    public List<TextStep> steps = new List<TextStep>();

    public void PlayStep(int index)
    {
        if (index < 0 || index >= steps.Count)
            return;

        TextStep step = steps[index];

        // Set text
        tutorialText.text = step.message;

        // Move box
        textBox.position = step.target.position;

        // 🔧 FORCE text to follow box (FIX)
        tutorialText.rectTransform.position = textBox.position;
    }
}
