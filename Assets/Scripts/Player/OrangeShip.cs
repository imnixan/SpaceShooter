using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeShip : Player
{
    private RectTransform leftFlame, rightFlame;
    private Vector2 leftFlameLeftPos, leftFlameRightPos, leftFlameCentralPos;
    private Vector2 rightFlameLeftPos, rightFlameRightPos, rightFlameCentralPos;
    private float flameYPos;
    protected override void MoveFlame(int dir)
    {
        switch(dir)
        {
            case 0:
                leftFlame.anchoredPosition = leftFlameCentralPos;
                rightFlame.anchoredPosition = rightFlameCentralPos;
                gun.CentralizeGun();
                break;
            case 1:
                leftFlame.anchoredPosition = leftFlameRightPos;
                rightFlame.anchoredPosition = rightFlameRightPos;
                gun.RightTurnGun();
                break;
            case -1:
                leftFlame.anchoredPosition = leftFlameLeftPos;
                rightFlame.anchoredPosition = rightFlameLeftPos;
                gun.LeftTurnGun();
                break;
        }
    }

    public override void InitializePlayer()
    {
        base.InitializePlayer();
        
        leftFlame = shipTransform.Find("leftFlame").GetComponent<RectTransform>();
        rightFlame = shipTransform.Find("rightFlame").GetComponent<RectTransform>();
        
        flameYPos = leftFlame.anchoredPosition.y;

        leftFlameCentralPos = new Vector2(-31.28f, flameYPos);
        leftFlameLeftPos = new Vector2(-43.7f, flameYPos);
        leftFlameRightPos = new Vector2(-6.25f, flameYPos);

        rightFlameCentralPos = new Vector2(31.28f, flameYPos);
        rightFlameLeftPos = new Vector2(6.25f, flameYPos);
        rightFlameRightPos = new Vector2(43.7f, flameYPos);
    }

    protected override void InitializeGunStat()
    {
        gunStat = Resources.Load("PlayersGunStats/OrangeShip") as PlayerGunStat;
    }
}
