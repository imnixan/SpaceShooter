using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefs;
    [SerializeField] private GameObject shield;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private CutsceneManager cm;
    [SerializeField] private GameObject es;
    [SerializeField] private UIButtons uiButtons;
    private int playerNum;
    private Player player;
    private GameState gameState;
    private enum GameState
    {
        StartGame,
        EndGame
    }
    private void Start()
    {
        uiButtons.HideControllers();
        uiButtons.HideMenuButtons();
        es.SetActive(false);
        gameState = GameState.StartGame;
        playerNum = PlayerPrefs.GetInt("Char");
        player = Instantiate(playerPrefs[playerNum], transform).GetComponent<Player>();
        Instantiate(shield, player.transform);
        cm.StartSpeech(this);
    }

    public void EndGame()
    {
        gameState = GameState.EndGame;
        int currentResult = uiManager.StopTimer();
        Debug.Log($"Current score {currentResult} and best is {PlayerPrefs.GetInt("Record")}");
        bool newRecord = currentResult > PlayerPrefs.GetInt("Record");
        if(newRecord)
        {
            PlayerPrefs.SetInt("Record", currentResult);
            PlayerPrefs.Save();
        }
        
        uiButtons.HideControllers();
        uiButtons.ShowMenuButtons();
        cm.gameObject.SetActive(true);
        cm.EndSpeech(newRecord);
    }

    public void CutSceneEnd()
    {
        cm.gameObject.SetActive(false);
        if(gameState == GameState.StartGame)
        {
            player.InitializePlayer();
            uiManager.StartTimer();   
            es.SetActive(true);
            uiButtons.ShowControllers();
        }
    }

    public void MoveLeft()
    {
        player.MoveLeft();
    }
    public void StopMovingLeft()
    {
        player.StopMovingLeft();
    }
    public void MoveRight()
    {
        player.MoveRight();
    }

    public void StopMovingRight()
    {
        player.StopMovingRight();
    }



}
