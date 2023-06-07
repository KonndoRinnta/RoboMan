using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField, Header("�̗͂̃X���C�_�[")]
    private Slider _hPSlider;

    [SerializeField,Header("PlayerController")]
    PlayerController _pC;

    private void Start()
    {
        _hPSlider.value = 1;
    }
    void Update()
    {
        _hPSlider.value = _pC.HP / _pC.HPMaxValue;
    }
}