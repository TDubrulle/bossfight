using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainMenu;
    
    public void hideAll()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void onClickBack()
    {
        hideAll();
        mainMenu.SetActive(false);
    }
    public void onClickPlay()
    {
        hideAll();
    }
    public void onClickCredits()
    {
        hideAll();
        credits.SetActive(false);
    }
    public void onClickExit()
    {
        Application.Quit();
    }
}
