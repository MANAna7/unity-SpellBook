using Cysharp.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



// 親オブジェクト参照する - transform.parent

namespace spellbook
{
    public class WritingforClick : MonoBehaviour
    {
        // Uguiのprefab - パレット
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
            // 右クリックでパレット生成、ペンを持っているときのみ
            if (Input.GetMouseButtonDown(1))
            {

                // 条件分岐 - もしパレットにクリックしたら削除、パレット以外にクリックしたら再生成
                // パレット以外をクリック、さらにパレット未生成
                if (!_nowInvParet)
                {
                    _nowInvParet = true;
                    ShowParet();
                }
            }
        }

        // パレット生成
        void ShowParet()
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, canvas.worldCamera, out localPoint);
            var item = Instantiate(paretPrefab);
            item.transform.SetParent(this.transform);
            item.GetComponent<RectTransform>().anchoredPosition = localPoint;
        }

        //外部からパレット削除時　フラグリセット
        public void ClearParetState()
        {
            _nowInvParet = false;
            Debug.Log("_nowInvParet is false by ClearParetState()");
        }

        // How to using async and await!!
        // 呼ぶときは onDestroy().Forget(); 明示的に宣言
        //public async void OnDestroy()
        //{
        //    Debug.Log("aaaaaaaa");
        //    await UniTask.Delay(100);
        //    // 押されるまで待機 - bool型のやつならいける
        //    await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        //    Debug.Log("nuoooooooooooooo");

        //    // 関数が終わるまで待機させる 下に行かない Updateとかを関数が終了するまで実行しないとかできる
        //    await Stoper();
        //}


        //public async UniTask Stoper()
        //{
        //    Debug.Log("await");
        //    await UniTask.Delay(100);
        //}

    }

}

