using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    private GameObject shieldExplosion, shipExplosion;
    private Shield shield;
    protected const float Speed = 2;
    protected Gun gun;
    protected Image ship; 
    protected RectTransform shipTransform;
    protected Rigidbody2D rb;
    protected float yPos;
    protected int leftDirection, rightDirection, direction;
    protected MoveAnimation moveAnimation;
    protected float xBorder;
    protected Collider2D playerCollider;
    protected UiManager uiManager;

    protected PlayerGunStat gunStat;
    protected float damageBonuses;
    protected bool gameStarted;
    protected AudioSource sound;
    protected AudioClip hideShield, showShield, bonus;

    public virtual void InitializePlayer()
    {
        InitializeGunStat();
        shield = GetComponentInChildren<Shield>();
        playerCollider = GetComponent<Collider2D>();
        ship = GetComponent<Image>();
        shipTransform = GetComponent<RectTransform>();
        xBorder = shipTransform.parent.GetComponent<RectTransform>().rect.width/2;
        rb = GetComponent<Rigidbody2D>();
        yPos = shipTransform.anchoredPosition.y;
        gun = GetComponentInChildren<Gun>();
        gun.Initialize(gunStat, shipTransform);
        moveAnimation = GetComponent<MoveAnimation>();
        moveAnimation.Initialize();
        uiManager = GameObject.FindWithTag("UiManager").GetComponent<UiManager>();
        shieldExplosion = Resources.Load("ExplosionPrefabs/ShieldExplosion") as GameObject;
        shipExplosion = Resources.Load("ExplosionPrefabs/ShipExplosion") as GameObject;
        uiManager.TurnOnShield();
        gameStarted = true;
        uiManager.UpdateDamageCount(gunStat.BaseDamage + gun.GetDamage());
        sound = gameObject.AddComponent<AudioSource>();
        hideShield = Resources.Load("SFX/turnoffshield") as AudioClip;
        showShield = Resources.Load("SFX/TurnOnShield") as AudioClip;
        bonus = Resources.Load("SFX/bonus") as AudioClip;
    }

    public void PlaySound(AudioClip aclip)
    {
        if(PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            sound.PlayOneShot(aclip);
        }
    }
    
    protected abstract void InitializeGunStat();

    private void RestoreShield()
    {
        uiManager.TurnOnShield();
        shield.gameObject.SetActive(true);
        PlaySound(showShield);
    }

    public void MoveLeft()
    {
        leftDirection = -1;
    }
    public void StopMovingLeft()
    {
        leftDirection = 0;
    }

    public void MoveRight()
    {
        rightDirection = 1;
    }

    public void StopMovingRight()
    {
        rightDirection = 0;
    }

    protected void LateUpdate()
    {
        if(gameStarted){
            if(shipTransform.anchoredPosition.x > xBorder - shipTransform.sizeDelta.x/2)
            {
                shipTransform.anchoredPosition = new Vector2(xBorder - shipTransform.sizeDelta.x/2, shipTransform.anchoredPosition.y);
            }
            if(shipTransform.anchoredPosition.x < -xBorder + shipTransform.sizeDelta.x/2)
            {
                shipTransform.anchoredPosition = new Vector2(-xBorder + shipTransform.sizeDelta.x/2, shipTransform.anchoredPosition.y);
            }
            direction = leftDirection + rightDirection;
            rb.velocity = new Vector2(Speed * direction, 0);
            MoveFlame(direction);
        }
    }

    protected void SetGun(GameObject newGun)
    {
        Destroy(gun.gameObject);
        Debug.Log("Got new gun");
        gun = Instantiate(newGun, shipTransform).GetComponent<Gun>();
        gun.Initialize(gunStat, shipTransform);
        damageBonuses += gun.GetDamage();
        gun.UpgradeDamage(damageBonuses);
        uiManager.UpdateDamageCount(gunStat.BaseDamage + gun.GetDamage());
    }


    private void GetHit(Vector2 hitPos)
    {
        if(shield.gameObject.activeSelf)
        {
            Instantiate(shieldExplosion, hitPos, new Quaternion(), shipTransform.parent);
            uiManager.TurnOffShield();
            shield.DestroyShield();
            PlaySound(hideShield);
        }
        else
        {
            Instantiate(shipExplosion, shipTransform.position, new Quaternion(), shipTransform.parent);
            gameObject.SetActive(false);
        }
    }
    protected abstract void MoveFlame(int dir);

    protected void  OnParticleCollision(){
        GetHit(shipTransform.position);   
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            return;
        }
        switch(other.tag)
        {
            case "GunBonus":
                SetGun(other.GetComponent<Bonus>().gun);
                Destroy(other.gameObject);
                PlaySound(bonus);
                break;
            case "Enemy":
                GetHit(other.transform.position);
                break;
            case "ShieldBonus":
                RestoreShield();
                Destroy(other.gameObject);
                PlaySound(bonus);
                break;
        }
    }
    
    protected void OnDisable()
    {
        shipTransform.parent.GetComponent<GameManager>().EndGame();
    }
}
