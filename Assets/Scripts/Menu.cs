using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScores;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Start()
    {
        int best = PlayerPrefs.GetInt("Record");
        bestScores.text = string.Format("{0:d2}:{1:d2}", best/60, best%60);
    }

    public void StartGame(){
        SceneManager.LoadScene("SpaceShooter");
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
