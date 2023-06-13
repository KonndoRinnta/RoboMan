using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField, Header("�̗͂̃X���C�_�[")]
    private Slider _hPSlider;

    [SerializeField, Header("�L���J�E���g�̃e�L�X�g")]
    private Text _killCountText;

    [SerializeField,Header("PlayerController")]
    PlayerController _pC;

    [SerializeField]
    private GameManager _gM;

    private void Start()
    {
        _hPSlider.value = 1;
    }
    void Update()
    {
        _killCountText.text = _gM.EnemyKillCount.ToString();
        _hPSlider.value = _pC.HP / _pC.HPMaxValue;
    }
}