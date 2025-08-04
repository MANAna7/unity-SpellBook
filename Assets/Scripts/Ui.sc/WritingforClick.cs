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

                // nullじゃない場合
                if (hit2D)
                {
                    clickedItem = hit2D.transform.gameObject;
                }

                // 条件分岐 - もしパレットにクリックしたら削除、パレット以外にクリックしたら再生成
                // パレット以外をクリック、さらにパレット未生成
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

        //外部からパレット削除時　フラグリセット
        void ClearParetState()
        {
            nowInvParet = false;
            Debug.Log("nowInvParet is false by ClearParetState()");
        }

        // How to using async and await!!
        // 呼ぶときは onDestroy().Forget(); 明示的に宣言
        public async void OnDestroy()
        {
            Debug.Log("aaaaaaaa");
            await UniTask.Delay(100);
            // 押されるまで待機 - bool型のやつならいける
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
            Debug.Log("nuoooooooooooooo");

            // 関数が終わるまで待機させる 下に行かない Updateとかを関数が終了するまで実行しないとかできる
            await Stoper();
        }


        public async UniTask Stoper()
        {
            Debug.Log("await");
            await UniTask.Delay(100);
        }

    }

}

