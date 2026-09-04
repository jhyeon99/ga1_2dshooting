using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    // 목적: 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.

    // 필요 필드:
    public PlayerMoveCommandInvoker PlayerMoveCommandInvoker;

    public float Speed = 0;
    public float SpeedFluctuation = 0;
    public float MaxPlayerY = 0;
    public float MinPlayerY = 0;
    public bool PlayerXWarpAble = false;
    public float MaxPlayerXAbs = 0;
    public float WarpPlayerXAbs = 0;

    private float _inputHorizontal;
    private float _inputVertical;

    [SerializeField] private float _health = 100f;

    private void GetInput()
    {
        // 1. 키보드 입력을 받는다.
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽 방향키를 누르는 중");

            // 2. 키보드 입력에 따라 방향을 구한다.
            // 게임에는 벡터라는 타입이 있다. 벡터는 크기와 방향을 의미한다.
            Vector2 direction = new Vector2(-1, 0); // 왼쪽 방향
            //Vector2 direction = Vector2.left;

            // 3. 방향과 속력에 따라 이동한다.
            // 속도 = 방향 * 속력
            // 매직 넘버: 보는 사람에 따라 의미가 달라질 수 있는 헷갈리는 숫자
            transform.Translate(direction * Speed * Time.deltaTime);
            // deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS로 반환
        }*/

        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed += SpeedFluctuation;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed -= SpeedFluctuation;
        }

        if (Input.GetKeyDown(KeyCode.R) && !PlayerMoveCommandInvoker.IsReplaying())
        {
            StartCoroutine(PlayerMoveCommandInvoker.ReplayCorutine());
        }

        // 1. 키보드 입력을 받는다.
        _inputHorizontal = Input.GetAxisRaw("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f or 0 or 1f
        _inputVertical = Input.GetAxisRaw("Vertical"); // 키보드 위/아래쪽 입력 상태에 따라 -1f or 0 or 1f
    }

    private void Move()
    {
        // 2. 키보드 입력에 따라 방향을 구한다.
        // 게임에는 벡터라는 타입이 있다. 벡터는 크기와 방향을 의미한다.
        Vector2 direction = new Vector2(_inputHorizontal, _inputVertical);

        // 3. 방향과 속력에 따라 이동한다.
        // 속도 = 방향 * 속력
        // 매직 넘버: 보는 사람에 따라 의미가 달라질 수 있는 헷갈리는 숫자
        Vector2 normalizedDirection = Vector2.Normalize(direction);
        Vector2 nextPlayerPosition = (Vector2)transform.position + normalizedDirection * Speed * Time.deltaTime;
        // deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS로 반환

        nextPlayerPosition.y = Math.Clamp(nextPlayerPosition.y, MinPlayerY, MaxPlayerY);

        if (!PlayerXWarpAble)
        {
            nextPlayerPosition.x = Math.Clamp(nextPlayerPosition.x, -MaxPlayerXAbs, MaxPlayerXAbs);
        }
        else
        {
            if (nextPlayerPosition.x > WarpPlayerXAbs)
            {
                nextPlayerPosition = new Vector2(-WarpPlayerXAbs, nextPlayerPosition.y);
            }
            else if (nextPlayerPosition.x < -WarpPlayerXAbs)
            {
                nextPlayerPosition = new Vector2(WarpPlayerXAbs, nextPlayerPosition.y);
            }
        }

        PlayerMoveCommand moveCommand = new PlayerMoveCommand(transform, nextPlayerPosition);
        PlayerMoveCommandInvoker.ExcuteCommand(moveCommand);
    }

    // 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는 별다른 설정이 없는 한 가능한 많이 실행한다.
    private void Update()
    {
        GetInput();
        Move();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}