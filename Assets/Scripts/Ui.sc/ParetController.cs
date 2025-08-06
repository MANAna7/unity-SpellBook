using UnityEngine;

namespace spellbook
{
    public class ParetController : MonoBehaviour
    {

        public GameObject meParet;
        private GameObject _obj;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _obj = this.gameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void onClickClose()
        {
            Destroy(this.gameObject);
            _obj.GetComponentInParent<WritingforClick>().ClearParetState();

        }
    }
}
