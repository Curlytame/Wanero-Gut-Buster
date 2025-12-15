using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        // ▶ Load Level Pick scene instead of hiding UI
        SceneManager.LoadScene("LevelPick");
    }
}
