using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayShip : Player
{
    protected float flameBias = 12.5f;
    protected RectTransform flame;

    public override void InitializePlayer()
    {
        base.InitializePlayer();
        flame = shipTransform.Find("Flame").GetComponent<RectTransform>();
    }

    protected override void MoveFlame(int dir)
    {
        flame.anchoredPosition = new Vector2(flameBias * dir, flame.anchoredPosition.y);
    }

    protected override void InitializeGunStat()
    {
        gunStat = Resources.Load("PlayersGunStats/GrayShip") as PlayerGunStat;
    }


   
}
