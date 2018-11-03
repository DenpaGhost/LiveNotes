using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class KeySoundSetButton : MonoBehaviour
    {
        public GameObject 
            canvas,
            buttonLabel,
            dialog;

        public int targetID;

        public void onClick()
        {
            var obj = Instantiate(dialog);
            obj.transform.SetParent(canvas.transform);
            obj.transform.localScale = new Vector3(1,1,1);
            obj.transform.position = gameObject.transform.position;
            obj.GetComponent<KeySoundSelectDialog>().setParameters(targetID, buttonLabel.GetComponent<Text>());
        }
    }
}