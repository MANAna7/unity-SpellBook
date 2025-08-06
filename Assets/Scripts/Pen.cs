using UnityEngine;

public class Pen : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private Color _color;
    [SerializeField] private bool _penModeFlg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _penModeFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_penModeFlg)
        {
            _rectTransform.position = Input.mousePosition + _offset;
        }
    }

    public void PenMode()
    {
        _penModeFlg = !_penModeFlg;
        Debug.Log("now" + _penModeFlg + "");
    }
}
