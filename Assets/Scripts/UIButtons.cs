using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameObject leftBtn, rightBtn, restartBtn, exitBtn;
    public void ShowControllers()
    {
        leftBtn.SetActive(true);
        rightBtn.SetActive(true);
    }

    public void HideControllers()
    {
        leftBtn.SetActive(false);
        rightBtn.SetActive(false);
    }

    public void ShowMenuButtons()
    {
        restartBtn.SetActive(true);
        exitBtn.SetActive(true);
    }

    public void HideMenuButtons()
    {
        restartBtn.SetActive(false);
        exitBtn.SetActive(false);
    }

    public void ExitBtnPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("SpaceShooter");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitBtnPressed();
        }
    }


}
