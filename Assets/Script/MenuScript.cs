using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainMenu;
    public GameObject inGame;
    public GameObject controls;

    public void hideAll()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
        inGame.SetActive(false);
        controls.SetActive(false);
    }

    public void onClickBackToMenu()
    {
        hideAll();
        mainMenu.SetActive(true);
    }
    public void onClickBackToGame()
    {
        hideAll();
        inGame.SetActive(true);
    }
    public void onClickPlay()
    {
        hideAll();
        inGame.SetActive(true);
    }
    public void onClickCredits()
    {
        hideAll();
        credits.SetActive(true);
    }
    public void onClickControls()
    {
        hideAll();
        controls.SetActive(true);
    }
    public void onClickExit()
    {
        Application.Quit();
    }
}
