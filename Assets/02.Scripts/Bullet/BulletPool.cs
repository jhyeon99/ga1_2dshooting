using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;

    // 오브젝트 풀링이란: 오브젝트의 Pool(웅덩이;창고)안에
    // 게임 오브젝트를 미리 필요한만큼 만들어두고,
    // 필요할 때마다 꺼내서 사용하고 필요가 없어지면 반환하는 식으로 (활성화/비활성화)
    // 메모리 할당과(객체의 생성) 해제(파괴)를 최소화해서 성능을 높임

    // 필요 속성
    [Header("총알 프리팹")]
    [SerializeField] private Bullet _bulletPrefab;

    [Header("풀 사이즈")]
    [SerializeField] private int _poolSize;

    // 생성한 총알을 담아둘 풀
    private Bullet[] _pool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 창고를 창고 크기만큼 만든다.
        _pool = new Bullet[_poolSize];

        // 창고 크기 만큼 총알을 미리 만들어서 집어 넣는다.
        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform);
            bullet.gameObject.SetActive(false); // 당장 사용하지 않으므로 비활성화
            _pool[i] = bullet;
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in _pool)
        {
            // 비활성화 되어있는 (즉, 사용하지 않는 총알 반환) 
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                bullet.OnSpawn();
                return bullet;
            }
        }

        return null;
    }
}