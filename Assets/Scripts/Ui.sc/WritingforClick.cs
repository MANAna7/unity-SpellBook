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
        private EventSystem eventSystem;
        private Canvas canvas;
        private RectTransform canvasRect;
        private GameObject clickedItem;
        private bool nowInvParet;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            nowInvParet = false;

            canvas = this.GetComponent<Canvas>();
            canvasRect = canvas.GetComponent<RectTransform>();


            //eventSystem = FindObjectsByType(EventSystem, FindObjectsSortMode.None);
            eventSystem = GameObject.FindAnyObjectByType<EventSystem>();

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedItem = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                // null����Ȃ��ꍇ
                if (hit2D)
                {
                    clickedItem = hit2D.transform.gameObject;
                }

                // �������� - �����p���b�g�ɃN���b�N������폜�A�p���b�g�ȊO�ɃN���b�N������Đ���
                // �p���b�g�ȊO���N���b�N�A����Ƀp���b�g������
                if (clickedItem.name != "Paret" && !nowInvParet)
                {
                    nowInvParet = true;
                    ShowParet();
                }
            }
        }

        void ShowParet()
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out localPoint);
            var item = Instantiate(paretPrefab);
            item.transform.SetParent(this.transform);
            item.GetComponent<RectTransform>().anchoredPosition = localPoint;
        }

        //�O������p���b�g�폜���@�t���O���Z�b�g
        void ClearParetState()
        {
            nowInvParet = false;
            Debug.Log("nowInvParet is false by ClearParetState()");
        }

        // How to using async and await!!
        // �ĂԂƂ��� onDestroy().Forget(); �����I�ɐ錾
        public async void OnDestroy()
        {
            Debug.Log("aaaaaaaa");
            await UniTask.Delay(100);
            // �������܂őҋ@ - bool�^�̂�Ȃ炢����
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
            Debug.Log("nuoooooooooooooo");

            // �֐����I���܂őҋ@������ ���ɍs���Ȃ� Update�Ƃ����֐����I������܂Ŏ��s���Ȃ��Ƃ��ł���
            await Stoper();
        }


        public async UniTask Stoper()
        {
            Debug.Log("await");
            await UniTask.Delay(100);
        }

    }

}

