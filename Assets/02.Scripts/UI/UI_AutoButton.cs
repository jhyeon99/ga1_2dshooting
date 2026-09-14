using UnityEngine;
using UnityEngine.UI;

public class UI_AutoButton : MonoBehaviour
{
    // 버튼을 클릭하면 토글하고 싶다.
    // - 플레이어의 자동 이동
    // - 플레이어의 자동 공격
    [Header("On/Off 스프라이트")]
    [SerializeField] private Sprite _onSprite;

    [SerializeField] private Sprite _offSprite;

    private Image _myImage;
    private AudioSource _audioSource;
    private Player _player;
    private bool _autoMode = true;


    private void Start()
    {
        _myImage = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
        _player = FindAnyObjectByType<Player>();
    }

    public void AutoToggle()
    {
        _autoMode = !_autoMode;

        _player.GetComponent<PlayerFire>().SetAuto(_autoMode);
        _player.GetComponent<PlayerMove>().enabled = !_autoMode;
        _player.GetComponent<PlayerAutoMove>().enabled = _autoMode;

        _myImage.sprite = _autoMode ? _onSprite : _offSprite;
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    // Todo: 버튼 클릭할 때 애니메이션 + 사운드 추가
    // 애니메이션: 코드로 구현 약간 커졌다가 원래대로..
    // 사운드: 일레븐랩스에서 버튼 클릭 공용 사운드 만들어서 적용
}