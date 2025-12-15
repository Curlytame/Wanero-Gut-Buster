using UnityEngine;
using UnityEngine.SceneManagement;  // Para sa scene loading
using UnityEngine.UI;  // Para sa UI elements
using UnityEngine.Audio; // Para sa Audio Mixer
using TMPro;

public class almanac : MonoBehaviour
{
    public GameObject almanacPanel;
    public GameObject almanacPanel2;
    public GameObject Panelcard1;
    public GameObject Panelcard2;
    public GameObject Panelcard3;
    public GameObject Panelcard4;
    public GameObject Panelcard5;
    public GameObject Panelcard6;
    public GameObject Panelcard7;
    public GameObject Panelcard8;
    public GameObject Panelcard9;
    public GameObject Panelcard10;
    public GameObject Panelcard11;
    public GameObject Panelcard12;
    public GameObject Panelcard13;
    public GameObject Panelcard14;
    public GameObject Panelcard15;
    public GameObject Panelcard16;
    public GameObject Panelcard17;
    public GameObject Panelcard18;
    public GameObject Panelcard19;
    public GameObject Panelcard20;
    public GameObject Panelcard21;
    public GameObject Panelcard22;
    public GameObject Panelcard23;
    public GameObject Panelcard24;
    public GameObject Panelcard25;
    public GameObject Panelcard26;
    public GameObject Panelcard27;
    public GameObject Panelcard28;
    public GameObject Panelcard29;
    public GameObject Panelcard30;
    public GameObject imagecard1;
    public GameObject imagecard2;
    public GameObject imagecard3;
    public GameObject imagecard4;
    public GameObject imagecard5;
    public GameObject imagecard6;
    public GameObject imagecard7;
    public GameObject imagecard8;
    public GameObject imagecard9;
    public GameObject imagecard10;
    public GameObject imagecard11;
    public GameObject imagecard12;
    public GameObject imagecard13;
    public GameObject imagecard14;
    public GameObject imagecard15;
    public GameObject imagecard16;
    public GameObject imagecard17;
    public GameObject imagecard18;
    public GameObject imagecard19;
    public GameObject imagecard20;
    public GameObject imagecard21;
    public GameObject imagecard22;
    public GameObject imagecard23;
    public GameObject imagecard24;
    public GameObject imagecard25;
    public GameObject imagecard26;
    public GameObject imagecard27;
    public GameObject imagecard28;
    public GameObject imagecard29;
    public GameObject imagecard30;
    public GameObject viewdetails1;
    public GameObject viewdetails2;
    public GameObject viewdetails3;
    public GameObject viewdetails4;
    public GameObject viewdetails5;
    public GameObject viewdetails6;
    public GameObject viewdetails7;
    public GameObject viewdetails8;
    public GameObject viewdetails9;
    public GameObject viewdetails10;
    public GameObject viewdetails11;
    public GameObject viewdetails12;
    public GameObject viewdetails13;
    public GameObject viewdetails14;
    public GameObject viewdetails15;
    public GameObject viewdetails16;
    public GameObject viewdetails17;
    public GameObject viewdetails18;
    public GameObject viewdetails19;
    public GameObject viewdetails20;
    public GameObject viewdetails21;
    public GameObject viewdetails22;
    public GameObject viewdetails23;
    public GameObject viewdetails24;
    public GameObject viewdetails25;
    public GameObject viewdetails26;
    public GameObject viewdetails27;
    public GameObject viewdetails28;
    public GameObject viewdetails29;
    public GameObject viewdetails30;
    void Awake()
    {
        imagecard1.SetActive(false);
        imagecard2.SetActive(false);
        viewdetails1.SetActive(false);
        viewdetails2.SetActive(false);
    }

    void Start()
    {
        almanacPanel.SetActive(false);
        almanacPanel2.SetActive(false);
        Panelcard1.SetActive(false);
        Panelcard2.SetActive(false);
        Panelcard3.SetActive(false);
        Panelcard4.SetActive(false);
        Panelcard5.SetActive(false);
        Panelcard6.SetActive(false);
        Panelcard7.SetActive(false);
        Panelcard8.SetActive(false);
        Panelcard9.SetActive(false);
        Panelcard10.SetActive(false);
        Panelcard11.SetActive(false);
        Panelcard12.SetActive(false);
        Panelcard13.SetActive(false);
        Panelcard14.SetActive(false);
        Panelcard15.SetActive(false);
        Panelcard16.SetActive(false);
        Panelcard17.SetActive(false);
        Panelcard18.SetActive(false);
        Panelcard19.SetActive(false);
        Panelcard20.SetActive(false);
        Panelcard21.SetActive(false);
        Panelcard22.SetActive(false);
        Panelcard23.SetActive(false);
        Panelcard24.SetActive(false);
        Panelcard25.SetActive(false);
        Panelcard26.SetActive(false);
        Panelcard27.SetActive(false);
        Panelcard28.SetActive(false);
        Panelcard29.SetActive(false);
        Panelcard30.SetActive(false);
        imagecard1.SetActive(false);
        imagecard2.SetActive(false);
        imagecard3.SetActive(false);
        imagecard4.SetActive(false);
        imagecard5.SetActive(false);
        imagecard6.SetActive(false);
        imagecard7.SetActive(false);
        imagecard8.SetActive(false);
        imagecard9.SetActive(false);
        imagecard10.SetActive(false);
        imagecard11.SetActive(false);
        imagecard12.SetActive(false);
        imagecard13.SetActive(false);
        imagecard14.SetActive(false);
        imagecard15.SetActive(false);
        imagecard16.SetActive(false);
        imagecard17.SetActive(false);
        imagecard18.SetActive(false);
        imagecard19.SetActive(false);
        imagecard20.SetActive(false);
        imagecard21.SetActive(false);
        imagecard22.SetActive(false);
        imagecard23.SetActive(false);
        imagecard24.SetActive(false);
        imagecard25.SetActive(false);
        imagecard26.SetActive(false);
        imagecard27.SetActive(false);
        imagecard28.SetActive(false);
        imagecard29.SetActive(false);
        imagecard30.SetActive(false);
        viewdetails1.SetActive(false);
        viewdetails2.SetActive(false);
        viewdetails3.SetActive(false);
        viewdetails4.SetActive(false);
        viewdetails5.SetActive(false);
        viewdetails6.SetActive(false);
        viewdetails7.SetActive(false);
        viewdetails8.SetActive(false);
        viewdetails9.SetActive(false);
        viewdetails10.SetActive(false);
        viewdetails11.SetActive(false);
        viewdetails12.SetActive(false);
        viewdetails13.SetActive(false);
        viewdetails14.SetActive(false);
        viewdetails15.SetActive(false);
        viewdetails16.SetActive(false);
        viewdetails17.SetActive(false);
        viewdetails18.SetActive(false);
        viewdetails19.SetActive(false);
        viewdetails20.SetActive(false);
        viewdetails21.SetActive(false);
        viewdetails22.SetActive(false);
        viewdetails23.SetActive(false);
        viewdetails24.SetActive(false);
        viewdetails25.SetActive(false);
        viewdetails26.SetActive(false);
        viewdetails27.SetActive(false);
        viewdetails28.SetActive(false);
        viewdetails29.SetActive(false);
        viewdetails30.SetActive(false);

    }
    public void OpenAlmanac()
    {

        almanacPanel.SetActive(true);
        imagecard1.SetActive(false);
        imagecard2.SetActive(false);
        imagecard3.SetActive(false);
        imagecard4.SetActive(false);
        imagecard5.SetActive(false);
        imagecard6.SetActive(false);
        imagecard7.SetActive(false);
        imagecard8.SetActive(false);
        imagecard9.SetActive(false);
        imagecard10.SetActive(false);
        imagecard11.SetActive(false);
        imagecard12.SetActive(false);
        imagecard13.SetActive(false);
        imagecard14.SetActive(false);
        imagecard15.SetActive(false);
        imagecard16.SetActive(false);
        imagecard17.SetActive(false);
        imagecard18.SetActive(false);
        imagecard19.SetActive(false);
        imagecard20.SetActive(false);
        imagecard21.SetActive(false);
        imagecard22.SetActive(false);
        imagecard23.SetActive(false);
        imagecard24.SetActive(false);
        imagecard25.SetActive(false);
        imagecard26.SetActive(false);
        imagecard27.SetActive(false);
        imagecard28.SetActive(false);
        imagecard29.SetActive(false);
        imagecard30.SetActive(false);
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

        almanacPanel.SetActive(false);

    }
    public void OpenPanelcard1()
    {
        Panelcard1.SetActive(true);
    }

    public void ClosePanelcard1()
    {
        Panelcard1.SetActive(false);
    }
    public void OpenPanelcard2()
    {
        Panelcard2.SetActive(true);
    }

    public void ClosePanelcard2()
    {
        Panelcard2.SetActive(false);
    }
    public void OpenPanelcard3()
    {
        Panelcard3.SetActive(true);
    }

    public void ClosePanelcard3()
    {
        Panelcard3.SetActive(false);
    }
    public void OpenPanelcard4()
    {
        Panelcard4.SetActive(true);
    }

    public void ClosePanelcard4()
    {
        Panelcard4.SetActive(false);
    }
    public void OpenPanelcard5()
    {
        Panelcard5.SetActive(true);
    }

    public void ClosePanelcard5()
    {
        Panelcard5.SetActive(false);
    }
    public void OpenPanelcard6()
    {
        Panelcard6.SetActive(true);
    }

    public void ClosePanelcard6()
    {
        Panelcard6.SetActive(false);
    }
    public void OpenPanelcard7()
    {
        Panelcard7.SetActive(true);
    }

    public void ClosePanelcard7()
    {
        Panelcard7.SetActive(false);
    }
    public void OpenPanelcard8()
    {
        Panelcard8.SetActive(true);
    }

    public void ClosePanelcard8()
    {
        Panelcard8.SetActive(false);
    }
    public void OpenPanelcard9()
    {
        Panelcard9.SetActive(true);
    }

    public void ClosePanelcard9()
    {
        Panelcard9.SetActive(false);
    }
    public void OpenPanelcard10()
    {
        Panelcard10.SetActive(true);
    }

    public void ClosePanelcard10()
    {
        Panelcard10.SetActive(false);
    }
    public void OpenPanelcard11()
    {
        Panelcard11.SetActive(true);
    }

    public void ClosePanelcard11()
    {
        Panelcard11.SetActive(false);
    }
    public void OpenPanelcard12()
    {
        Panelcard12.SetActive(true);
    }

    public void ClosePanelcard12()
    {
        Panelcard12.SetActive(false);
    }
    public void OpenPanelcard13()
    {
        Panelcard13.SetActive(true);
    }

    public void ClosePanelcard13()
    {
        Panelcard13.SetActive(false);
    }
    public void OpenPanelcard14()
    {
        Panelcard14.SetActive(true);
    }

    public void ClosePanelcard14()
    {
        Panelcard14.SetActive(false);
    }
    public void OpenPanelcard15()
    {
        Panelcard15.SetActive(true);
    }

    public void ClosePanelcard15()
    {
        Panelcard15.SetActive(false);
    }
    public void OpenPanelcard16()
    {
        Panelcard16.SetActive(true);
    }

    public void ClosePanelcard16()
    {
        Panelcard16.SetActive(false);
    }
    public void OpenPanelcard17()
    {
        Panelcard17.SetActive(true);
    }

    public void ClosePanelcard17()
    {
        Panelcard17.SetActive(false);
    }
    public void OpenPanelcard18()
    {
        Panelcard18.SetActive(true);
    }

    public void ClosePanelcard18()
    {
        Panelcard18.SetActive(false);
    }
    public void OpenPanelcard19()
    {
        Panelcard19.SetActive(true);
    }

    public void ClosePanelcard19()
    {
        Panelcard19.SetActive(false);
    }
    public void OpenPanelcard20()
    {
        Panelcard20.SetActive(true);
    }
    public void ClosePanelcard20()
    {
        Panelcard20.SetActive(false);
    }
    public void OpenPanelcard21()
    {
        Panelcard21.SetActive(true);
    }

    public void ClosePanelcard21()
    {
        Panelcard21.SetActive(false);
    }
    public void OpenPanelcard22()
    {
        Panelcard22.SetActive(true);
    }

    public void ClosePanelcard22()
    {
        Panelcard22.SetActive(false);
    }
    public void OpenPanelcard23()
    {
        Panelcard23.SetActive(true);
    }

    public void ClosePanelcard23()
    {
        Panelcard23.SetActive(false);
    }
    public void OpenPanelcard24()
    {
        Panelcard24.SetActive(true);
    }

    public void ClosePanelcard24()
    {
        Panelcard24.SetActive(false);
    }
    public void OpenPanelcard25()
    {
        Panelcard25.SetActive(true);
    }

    public void ClosePanelcard25()
    {
        Panelcard25.SetActive(false);
    }
    public void OpenPanelcard26()
    {
        Panelcard26.SetActive(true);
    }

    public void ClosePanelcard26()
    {
        Panelcard26.SetActive(false);
    }
    public void OpenPanelcard27()
    {
        Panelcard27.SetActive(true);
    }

    public void ClosePanelcard27()
    {
        Panelcard27.SetActive(false);
    }
    public void OpenPanelcard28()
    {
        Panelcard28.SetActive(true);
    }

    public void ClosePanelcard28()
    {
        Panelcard28.SetActive(false);
    }
    public void OpenPanelcard29()
    {
        Panelcard29.SetActive(true);
    }

    public void ClosePanelcard29()
    {
        Panelcard29.SetActive(false);
    }
    public void OpenPanelcard30()
    {
        Panelcard30.SetActive(true);
    }

    public void ClosePanelcard30()
    {
        Panelcard30.SetActive(false);
    }

    
    public void ShowCardImage1()
    {
        imagecard1.SetActive(true);
        viewdetails1.SetActive(true);
        
        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);
        
        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);
       
        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);
       
        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);
        
        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);
       
        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);
       
        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);
        
        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);
        
        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);
        
        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);
        
        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);
        
        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);
        
        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);
        
        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);
        
        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);
        
        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);
        
        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);
        
        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);
        
        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);
        
        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);
        
        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);
        
        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);
        
        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);
        
        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);
        
        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);
        
        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);
        
        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);
        
        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);
        
        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);

    }
    public void ShowCardImage2()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(true);
        viewdetails2.SetActive(true);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage3()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(true);
        viewdetails3.SetActive(true);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage4()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(true);
        viewdetails4.SetActive(true);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage5()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(true);
        viewdetails5.SetActive(true);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage6()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(true);
        viewdetails6.SetActive(true);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage7()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(true);
        viewdetails7.SetActive(true);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage8()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(true);
        viewdetails8.SetActive(true);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage9()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(true);
        viewdetails9.SetActive(true);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage10()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(true);
        viewdetails10.SetActive(true);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage11()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(true);
        viewdetails11.SetActive(true);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage12()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(true);
        viewdetails12.SetActive(true);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage13()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(true);
        viewdetails13.SetActive(true);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage14()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(true);
        viewdetails14.SetActive(true);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage15()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(true);
        viewdetails15.SetActive(true);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage16()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(true);
        viewdetails16.SetActive(true);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage17()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(true);
        viewdetails17.SetActive(true);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage18()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(true);
        viewdetails18.SetActive(true);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage19()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(true);
        viewdetails19.SetActive(true);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage20()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(true);
        viewdetails20.SetActive(true);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage21()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(true);
        viewdetails21.SetActive(true);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage22()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(true);
        viewdetails22.SetActive(true);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage23()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(true);
        viewdetails23.SetActive(true);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage24()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(true);
        viewdetails24.SetActive(true);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage25()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(true);
        viewdetails25.SetActive(true);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage26()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(true);
        viewdetails26.SetActive(true);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage27()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(true);
        viewdetails27.SetActive(true);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage28()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(true);
        viewdetails28.SetActive(true);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage29()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(true);
        viewdetails29.SetActive(true);

        imagecard30.SetActive(false);
        viewdetails30.SetActive(false);
    }
    public void ShowCardImage30()
    {
        imagecard1.SetActive(false);
        viewdetails1.SetActive(false);

        imagecard2.SetActive(false);
        viewdetails2.SetActive(false);

        imagecard3.SetActive(false);
        viewdetails3.SetActive(false);

        imagecard4.SetActive(false);
        viewdetails4.SetActive(false);

        imagecard5.SetActive(false);
        viewdetails5.SetActive(false);

        imagecard6.SetActive(false);
        viewdetails6.SetActive(false);

        imagecard7.SetActive(false);
        viewdetails7.SetActive(false);

        imagecard8.SetActive(false);
        viewdetails8.SetActive(false);

        imagecard9.SetActive(false);
        viewdetails9.SetActive(false);

        imagecard10.SetActive(false);
        viewdetails10.SetActive(false);

        imagecard11.SetActive(false);
        viewdetails11.SetActive(false);

        imagecard12.SetActive(false);
        viewdetails12.SetActive(false);

        imagecard13.SetActive(false);
        viewdetails13.SetActive(false);

        imagecard14.SetActive(false);
        viewdetails14.SetActive(false);

        imagecard15.SetActive(false);
        viewdetails15.SetActive(false);

        imagecard16.SetActive(false);
        viewdetails16.SetActive(false);

        imagecard17.SetActive(false);
        viewdetails17.SetActive(false);

        imagecard18.SetActive(false);
        viewdetails18.SetActive(false);

        imagecard19.SetActive(false);
        viewdetails19.SetActive(false);

        imagecard20.SetActive(false);
        viewdetails20.SetActive(false);

        imagecard21.SetActive(false);
        viewdetails21.SetActive(false);

        imagecard22.SetActive(false);
        viewdetails22.SetActive(false);

        imagecard23.SetActive(false);
        viewdetails23.SetActive(false);

        imagecard24.SetActive(false);
        viewdetails24.SetActive(false);

        imagecard25.SetActive(false);
        viewdetails25.SetActive(false);

        imagecard26.SetActive(false);
        viewdetails26.SetActive(false);

        imagecard27.SetActive(false);
        viewdetails27.SetActive(false);

        imagecard28.SetActive(false);
        viewdetails28.SetActive(false);

        imagecard29.SetActive(false);
        viewdetails29.SetActive(false);

        imagecard30.SetActive(true);
        viewdetails30.SetActive(true);
    }
}

