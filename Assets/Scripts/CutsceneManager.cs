using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] charectersAnim;

    [SerializeField]
    private string[] charactersSpeeches;

    [SerializeField]
    private string loseSpeech;

    [SerializeField]
    private string newRecordSpeech;

    [SerializeField]
    private TextMeshProUGUI characterText;

    [SerializeField]
    private Image characterAvatar;
    private GameManager gm;
    private int character;
    private int startSprite;
    private int lastSprite;
    private int currentSprite;
    private float speechSpeed = 0.1f;
    private AudioSource sound;
    private AudioClip click;
    private bool soundOn;

    public void StartSpeech(GameManager gm)
    {
        this.gm = gm;
        soundOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        sound = gameObject.AddComponent<AudioSource>();
        click = Resources.Load("SFX/showtext") as AudioClip;
        character = PlayerPrefs.GetInt("Char");
        StartCoroutine(Speech(charactersSpeeches[character]));
    }

    public void EndSpeech(bool newRecord)
    {
        if (newRecord)
        {
            StartCoroutine(Speech(newRecordSpeech));
        }
        StartCoroutine(Speech(loseSpeech));
    }

    private void Update()
    {
        if (gm && Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            gm.CutSceneEnd();
        }
    }

    IEnumerator Speech(string speech)
    {
        Debug.Log(speech);
        characterText.text = "";
        startSprite = character * 5;
        currentSprite = startSprite;
        lastSprite = startSprite + 5;
        for (int c = 0; c < speech.Length; c++)
        {
            PlaySound();
            characterText.text += speech[c];
            characterAvatar.sprite = charectersAnim[currentSprite];
            yield return new WaitForSeconds(speechSpeed);
            currentSprite++;
            if (currentSprite >= lastSprite)
            {
                currentSprite = startSprite;
            }
        }
    }

    public void PlaySound()
    {
        if (soundOn)
        {
            sound.PlayOneShot(click);
        }
    }
}
