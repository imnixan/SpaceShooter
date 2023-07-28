using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShip : GrayShip
{
    public override void InitializePlayer()
    {
        base.InitializePlayer();
    }

    protected override void InitializeGunStat()
    {
        gunStat = Resources.Load("PlayersGunStats/GreenShip") as PlayerGunStat;
    }
}
