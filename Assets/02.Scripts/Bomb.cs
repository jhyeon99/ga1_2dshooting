using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _durationTime = 10f;
    private float _durationTimer = 0;

    public void SetDuration(float duration)
    {
        _durationTime = duration;
    }

    private void Update()
    {
        _durationTimer += Time.deltaTime;
        if (_durationTimer >= _durationTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}