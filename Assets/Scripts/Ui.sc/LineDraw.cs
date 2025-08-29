using Unity.VisualScripting;
using UnityEngine;

namespace spellbook
{
    public class LineDraw : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRend;
        [SerializeField] private PensStateSlider _pensStateSlider;
        [SerializeField] private Camera _camera;

        [SerializeField] private int _posCount = 0;
        [SerializeField] private float _interval = 0.1f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //_pensStateSlider = GetComponent<PensStateSlider>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0) && !_pensStateSlider.NoIncCheck())
            {

                SetPosition(mousePos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _posCount = 0;
                _pensStateSlider.ResetInc();
            }


        }

        private void SetPosition(Vector2 pos)
        {
            if (!PosCheck(pos)) return;
            _posCount++;
            _lineRend.positionCount = _posCount;
            _lineRend.SetPosition(_posCount - 1, pos);

            _pensStateSlider.DrawForInc();
        }

        private bool PosCheck(Vector2 pos)
        {
            if (_posCount == 0) return true;

            float distance = Vector2.Distance(_lineRend.GetPosition(_posCount - 1), pos);
            if (distance > _interval)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}