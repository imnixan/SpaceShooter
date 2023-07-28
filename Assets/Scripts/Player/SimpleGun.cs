using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : Gun
{
    
    public override void Initialize(PlayerGunStat gunStat, Transform ship)
    {
        damageBonus = 0;
        base.Initialize(gunStat, ship);
    }

    protected override void Fire(float damage)
    {
        Instantiate(gunStat.Bullet, rt).GetComponent<Bullet>().Shoot(0, damage);
    }
}
