using UnityEngine;

public class Background : MonoBehaviour
{
    private Material _material;
    [SerializeField] private float _scrollSpeed = 0.2f;

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        Vector2 direction = Vector2.up;


        // ToDo: MaterialPropertyBlock을 활용한 최적화
        _material.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}