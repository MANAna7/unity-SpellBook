using UnityEngine;

namespace spellbook
{
    public class SpellBookController : MonoBehaviour
    {
        [SerializeField] private GameObject _backBox;
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

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Vector3 spawnPosition = basePosition + new Vector3(i, j, -0.3f);
                    Instantiate(_backBox, spawnPosition, Quaternion.identity);
                }
            }
        }

        void LeftRenderer()
        {

        }
    }
}