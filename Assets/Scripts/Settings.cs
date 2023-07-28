using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{

    [SerializeField] private Sprite[] charAnimList;
    [SerializeField] private Image soundImage, vibroImage;
    [SerializeField] private Image characterImage;
    private int firstSprite;
    private int lastSprite;
    private int currentSprite;
    private int characterNum;
    private void Awake()
    {
        Application.targetFrameRate = 120;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Start()
    {
        UpdateAnimCharInts();
        UpdateSettingsColor();
        StartCoroutine(AnimateCharacter());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void ChooseChar()
    {
        characterNum ++;
        if(characterNum >= (charAnimList.Length / 5))
        {
            characterNum = 0;
        }
        PlayerPrefs.SetInt("Char", characterNum);
        PlayerPrefs.Save();

        UpdateAnimCharInts();
    }

    private void UpdateAnimCharInts()
    {
        characterNum =  PlayerPrefs.GetInt("Char");
        firstSprite = characterNum * 5;
        currentSprite = firstSprite;
        lastSprite = firstSprite + 5;
    }

    private void UpdateSettingsColor()
    {
        Debug.Log($"sound {PlayerPrefs.GetInt("SFX", 1) == 1} vibro {PlayerPrefs.GetInt("Vibro", 1) == 1}");
        soundImage.color = PlayerPrefs.GetInt("SFX", 1) == 1? Color.green : Color.red;
        vibroImage.color = PlayerPrefs.GetInt("Vibro", 1) == 1? Color.green : Color.red;
    }

    IEnumerator AnimateCharacter()
    {
        
        while(true)
        {
            currentSprite++;
            if(currentSprite >= lastSprite)
            {
                currentSprite = firstSprite;
            }
            characterImage.sprite = charAnimList[currentSprite];
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ChangeSound()
    {
        PlayerPrefs.SetInt("SFX", PlayerPrefs.GetInt("SFX", 1) == 1? 0 : 1);
        PlayerPrefs.Save();
        UpdateSettingsColor();
    }

    public void ChangeVibro()
    {
        PlayerPrefs.SetInt("Vibro", PlayerPrefs.GetInt("Vibro", 1) == 1? 0 : 1);
        PlayerPrefs.Save();
        UpdateSettingsColor();
    }
}
