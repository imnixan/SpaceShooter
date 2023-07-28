using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : Gun
{
    protected RectTransform leftGun, rightGun;
    protected  Vector2 leftGunLeftPos, leftGunRightPos, leftGunCentralPos;
    protected Vector2 rightGunLeftPos, rightGunRightPos, rightGunCentralPos;

    public override void Initialize(PlayerGunStat gunStat, Transform ship)
    {
        leftGun = transform.Find("LeftGun").GetComponent<RectTransform>();
        rightGun = transform.Find("RightGun").GetComponent<RectTransform>();

        base.Initialize(gunStat, ship);
        CentralizeGun();

    }

    protected override void Fire(float damage)
    {
        Instantiate(gunStat.Bullet, leftGun).GetComponent<Bullet>().Shoot(0, damage);
        Instantiate(gunStat.Bullet, rightGun).GetComponent<Bullet>().Shoot(0, damage);
    }

    public override void LeftTurnGun()
    {
        leftGun.anchoredPosition = gunStat.leftGunLeftPos;
        rightGun.anchoredPosition = gunStat.rightGunLeftPos;
    }

    public override void CentralizeGun()
    {
        leftGun.anchoredPosition = gunStat.leftGunCentralPos;
        rightGun.anchoredPosition = gunStat.rightGunCentralPos;
    }

    public override void RightTurnGun()
    {
        leftGun.anchoredPosition = gunStat.leftGunRightPos;
        rightGun.anchoredPosition = gunStat.rightGunRightPos;
    }
}
