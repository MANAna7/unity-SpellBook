using UnityEngine;

namespace spellbook
{
    public class ParetController : MonoBehaviour
    {
        public GameObject meParet;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void onClickClose()
        {
            Destroy(this.gameObject);
        }
    }
}
