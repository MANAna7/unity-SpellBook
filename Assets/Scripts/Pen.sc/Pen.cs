using UnityEngine;
using UnityEngine.UI;

public class Pen : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private Color _color;
    [SerializeField] private bool _penModeFlg;

    public Button button;
    private bool _nowButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _penModeFlg = false;
        _nowButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_penModeFlg)
        {
            _rectTransform.position = Input.mousePosition + _offset;
        }


        if (Input.GetMouseButton(1))
        {
            Debug.Log("now" + _nowButton + "and now button is " + button);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "button")
        {
            button = null;
        }
    }

    public void PenMode()
    {
        _penModeFlg = !_penModeFlg;
        Debug.Log("now" + _penModeFlg + "");
    }
}
