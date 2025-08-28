using Cysharp.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



// �e�I�u�W�F�N�g�Q�Ƃ��� - transform.parent

namespace spellbook
{
    public class WritingforClick : MonoBehaviour
    {
        // Ugui��prefab - �p���b�g
        public GameObject paretPrefab;
        private EventSystem _eventSystem;
        private Canvas canvas;
        private RectTransform _canvasRect;
        private bool _nowInvParet;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            _nowInvParet = false;

            canvas = this.GetComponent<Canvas>();
            _canvasRect = canvas.GetComponent<RectTransform>();


            //_eventSystem = FindObjectsByType(_eventSystem, FindObjectsSortMode.None);
            _eventSystem = GameObject.FindAnyObjectByType<EventSystem>();

        }

        // Update is called once per frame
        void Update()
        {
            // �E�N���b�N�Ńp���b�g�����A�y���������Ă���Ƃ��̂�
            if (Input.GetMouseButtonDown(1))
            {

                // �������� - �����p���b�g�ɃN���b�N������폜�A�p���b�g�ȊO�ɃN���b�N������Đ���
                // �p���b�g�ȊO���N���b�N�A����Ƀp���b�g������
                if (!_nowInvParet)
                {
                    _nowInvParet = true;
                    ShowParet();
                }
            }
        }

        // �p���b�g����
        void ShowParet()
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, canvas.worldCamera, out localPoint);
            var item = Instantiate(paretPrefab);
            item.transform.SetParent(this.transform);
            item.GetComponent<RectTransform>().anchoredPosition = localPoint;
        }

        //�O������p���b�g�폜���@�t���O���Z�b�g
        public void ClearParetState()
        {
            _nowInvParet = false;
            Debug.Log("_nowInvParet is false by ClearParetState()");
        }

        // How to using async and await!!
        // �ĂԂƂ��� onDestroy().Forget(); �����I�ɐ錾
        //public async void OnDestroy()
        //{
        //    Debug.Log("aaaaaaaa");
        //    await UniTask.Delay(100);
        //    // �������܂őҋ@ - bool�^�̂�Ȃ炢����
        //    await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        //    Debug.Log("nuoooooooooooooo");

        //    // �֐����I���܂őҋ@������ ���ɍs���Ȃ� Update�Ƃ����֐����I������܂Ŏ��s���Ȃ��Ƃ��ł���
        //    await Stoper();
        //}


        //public async UniTask Stoper()
        //{
        //    Debug.Log("await");
        //    await UniTask.Delay(100);
        //}

    }

}

