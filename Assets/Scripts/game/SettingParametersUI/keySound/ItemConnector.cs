using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class ItemConnector : MonoBehaviour
    {
        private BaseListItem item;
        public Text textView;

        private void Start()
        {
            textView.text = item.Name;
        }

        public void setItem(BaseListItem item)
        {
            this.item = item;
        }
        
        public void delete()
        {
            Destroy(gameObject);
        }

        public void onClick()
        {
            item.onClick();
        }
    }
}