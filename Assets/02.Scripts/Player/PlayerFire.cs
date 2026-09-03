using System.Collections;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab = null;

    public GameObject SubBulletPrefab = null;

    // - 생성 위치(총구)
    public Transform FirePoint = null;
    public int NumOfBulletFireOnce = 0;
    public float DistanceBetweenFiredBullets = 0;

    private bool _isCooltime = false;
    private float _cooldowntimer = 0;
    public float CooldownDelay = 0;

    private bool _isAutoFireMode = false;

    public bool IsFireSubBullet = false;
    public Transform[] SubBulletFirePoint = null;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isAutoFireMode = !_isAutoFireMode;
        }

        // 1. 스페이스 바를 누른다면
        if (!_isCooltime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || _isAutoFireMode)
            {
                _isCooltime = true;
                _cooldowntimer = CooldownDelay;
                // 2. 총알 프리팹을 생성한다.
                // Instantiate는 프리팹을 복사해서 (Monobehaviour를 상속받는) 게임 오브젝트를 생성하고 씬에 넣어주는 기능
                float lengthOfBullets = (NumOfBulletFireOnce - 1) * DistanceBetweenFiredBullets;
                for (int i = 0; i < NumOfBulletFireOnce; i++)
                {
                    float offsetX = -lengthOfBullets / 2 + i * DistanceBetweenFiredBullets;
                    GameObject bullet = Instantiate(BulletPrefab);
                    bullet.transform.position = FirePoint.position;
                    bullet.transform.position = (Vector2)bullet.transform.position + new Vector2(offsetX, 0);
                }

                if (IsFireSubBullet)
                {
                    foreach (Transform subBulletTransform in SubBulletFirePoint)
                    {
                        GameObject subBullet = Instantiate(SubBulletPrefab);
                        subBullet.transform.position = subBulletTransform.position;
                    }
                }
            }
        }
        else
        {
            _cooldowntimer -= Time.deltaTime;
            if (_cooldowntimer <= 0)
            {
                _isCooltime = false;
            }
        }
    }
}