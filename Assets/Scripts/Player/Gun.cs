using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected float damageBonus;
    protected RectTransform rt;
    protected PlayerGunStat gunStat;
    protected AudioSource sound;
    protected AudioClip shot;
    protected bool soundOn;
    public void UpgradeDamage(float upgrade)
    {
        damageBonus += upgrade;
    }

    public float GetDamage()
    {
        return damageBonus;
    }

    protected void PlaySound()
    {
        if(soundOn)
        {
            sound.PlayOneShot(shot);
        }
    }
   public virtual void Initialize(PlayerGunStat gunStat, Transform ship)
   {
        this.gunStat = gunStat;
        rt = GetComponent<RectTransform>();
        rt.SetParent(ship);
        SetGunPosition();
        StartFire();
        soundOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        sound = gameObject.AddComponent<AudioSource>();
        shot = Resources.Load("SFX/laser4") as AudioClip;


   }

   protected virtual void SetGunPosition(){
        rt.anchoredPosition = Vector2.zero;
   }

    protected void StartFire()
    {
        StartCoroutine(IEFire());
    }

    protected IEnumerator IEFire()
    {
        while(true)
        {
            yield return new WaitForSeconds(gunStat.FireRate);
            Fire(gunStat.BaseDamage + damageBonus);
            PlaySound();

        }
    }

    protected abstract void Fire(float damage);

    public virtual void LeftTurnGun()
    {

    }

    public virtual void CentralizeGun()
    {

    }

    public virtual void RightTurnGun()
    {

    }
}
