using UnityEngine;
[CreateAssetMenu(fileName = "PlayerGunStat", menuName = "ScriptableObjects/PlayerGunStat", order = 2)]
public class PlayerGunStat : ScriptableObject
{
    [SerializeField] private float _damage;
    
    [SerializeField] private float _fireRate;

    [SerializeField] private GameObject _bulletPrefab;

    public Vector2 leftGunLeftPos, leftGunRightPos, leftGunCentralPos;
    public Vector2 rightGunLeftPos, rightGunRightPos, rightGunCentralPos;

    public float BaseDamage
    {
        get
        {
            return _damage;
        }
    }

    public float FireRate
    {
        get
        {
            return _fireRate;
        }
    }

    public GameObject Bullet
    {
        get
        {
            return _bulletPrefab;
        }
    }







}
