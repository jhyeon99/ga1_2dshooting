using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    private float _coolTime = 10f;
    private float _coolTimer = 0f;

    private float _durationTime = 3f;
    [SerializeField] private GameObject _bombPrefab;

    private void Update()
    {
        _coolTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (_coolTimer >= _coolTime)
            {
                _coolTimer = 0f;
                GameObject gameObject = Instantiate(_bombPrefab, transform.position, Quaternion.identity);
                gameObject.GetComponentInChildren<Bomb>().SetDuration(_durationTime);
            }
        }
    }
}