using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public HighlightController highlightController;
    public TutorialTextController textController;
    public HandPointerController handController;

    public Button nextButton;

    private int currentStep = 0;
    private int maxSteps;

    void Start()
    {
        currentStep = 0;

        if (nextButton != null)
            nextButton.onClick.AddListener(NextStep);

        // 🔒 Safety: prevent null crash
        maxSteps = Mathf.Min(
            highlightController.steps.Count,
            textController.steps.Count,
            handController.steps.Count
        );

        PlayStep();
    }

    void NextStep()
    {
        currentStep++;

        if (currentStep >= maxSteps)
        {
            EndTutorial();
            return;
        }

        PlayStep();
    }

    void PlayStep()
    {
        Debug.Log("Tutorial Step: " + currentStep);

        highlightController.PlayStep(currentStep);
        textController.PlayStep(currentStep);
        handController.PlayStep(currentStep);
    }

    void EndTutorial()
    {
        highlightController.gameObject.SetActive(false);
        textController.gameObject.SetActive(false);
        handController.gameObject.SetActive(false);

        if (nextButton != null)
            nextButton.gameObject.SetActive(false);
    }
}
