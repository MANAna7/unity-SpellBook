using UnityEngine;

namespace spellbook
{
    public class SpellBookController : MonoBehaviour
    {
        [SerializeField] private GameObject _backBox;

        private float boxI;
        private float boxJ;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            RightRenderer();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RightRenderer()
        {
            // ‚±‚ÌGameObject‚ÌˆÊ’u‚ðŽæ“¾
            Vector3 basePosition = transform.position;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    boxI = i / 2f; boxJ = j / 2f;
                    Vector3 spawnPosition = basePosition + new Vector3(boxI, boxJ, -0.3f);
                    Instantiate(_backBox, spawnPosition, Quaternion.identity);
                }
            }
        }

        void LeftRenderer()
        {

        }
    }
}