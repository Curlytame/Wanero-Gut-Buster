using UnityEngine;
using UnityEngine.SceneManagement;  // Para sa scene loading
using UnityEngine.UI;  // Para sa UI elements
using UnityEngine.Audio; // Para sa Audio Mixer
using TMPro;

public class almanac : MonoBehaviour
{
    public GameObject almanacPanel;
    public GameObject almanacPanel2;

    void Start()
    {
        almanacPanel.SetActive(false);
        almanacPanel2.SetActive(false);

    }
    public void OpenAlmanac()
    {

        almanacPanel.SetActive(true);
    }
    public void CloseAlmanac()
    {

        almanacPanel.SetActive(false);

    }
    public void OpenAlmanac2()
    {

        almanacPanel2.SetActive(true);
    }
    public void CloseAlmanac2()
    {

        almanacPanel2.SetActive(false);

    }
}

