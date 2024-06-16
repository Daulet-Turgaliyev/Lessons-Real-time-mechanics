using UnityEngine;

namespace Example.Chests
{
    public class ChestAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _openChestObject;
        [SerializeField] private GameObject _closeChestObject;


        public void Open()
        {
            _openChestObject.SetActive(true);
            _closeChestObject.SetActive(false);
        }
    }
}