using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PensStateSlider : MonoBehaviour
{
    Slider _incSlider;

    [SerializeField] float _maxInc = 200f;
    [SerializeField] float _nowInc = 100f;
    [SerializeField] float _usingInc = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _incSlider = GetComponent<Slider>();



        //�X���C�_�[�̍ő�l�̐ݒ�
        _incSlider.maxValue = _maxInc;

    }

    // Update is called once per frame
    void Update()
    {

        //�X���C�_�[�̌��ݒl�̐ݒ�
        _incSlider.value = _nowInc;
    }

    public void DrawForInc()
    {
        if (_incSlider != null)
        {
            _nowInc -= _usingInc;
        }
    }
    public bool NoIncCheck()
    {
        if (_nowInc <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetInc()
    {
        _nowInc = _maxInc;
    }

}
