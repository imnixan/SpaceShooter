using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    [SerializeField] Sprite[] explosionSprites;
    [SerializeField] private AudioClip boom;
    private Image image;

    private AudioSource sound;
    private void Start()
    {
        image = GetComponent<Image>();
        sound = gameObject.AddComponent<AudioSource>();
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        if(PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            sound.PlayOneShot(boom);
        }
        if(PlayerPrefs.GetInt("Vibro", 1)== 1)
        {
            Handheld.Vibrate();
        }
        for(int i = 0; i < explosionSprites.Length; i++)
        {
            image.sprite = explosionSprites[i];
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}
