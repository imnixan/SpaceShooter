using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class UiManager : MonoBehaviour
{
    public static event UnityAction TimeToDropBonus; 
    [SerializeField] private TextMeshProUGUI minutesCounter, secondsCounter, damageCount;
    [SerializeField] private GameObject shieldIcon;
 
    private void Awake()
    {
        Application.targetFrameRate = 120;
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private int time;
    private bool timerOn;
    
    public void StartTimer()
    {
        timerOn = true;
        StartCoroutine(Timer());
    }

    public int StopTimer()
    {
        timerOn = false;
        return time;
    }

    public void UpdateDamageCount(float newDamage)
    {
        damageCount.text = newDamage.ToString();
    }


    IEnumerator Timer()
    {
        while(timerOn)
        {
            yield return new WaitForSeconds(1);
            time ++;
            minutesCounter.text = string.Format("{0:d2}", time/60);
            secondsCounter.text = string.Format("{0:d2}", time%60);
            if(time%60 == 30 || time%60 == 0)
            {
                TimeToDropBonus?.Invoke();
            }
        }
    }




    public void TurnOnShield()
    {
        shieldIcon.SetActive(true);
    }

    public void TurnOffShield()
    {
        shieldIcon.SetActive(false);
    }

}
