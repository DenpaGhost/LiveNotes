using System;
using UiButtons.Title.module;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.Experimental.UIElements.Button;

namespace game
{   
    public class KeySoundSelectDialog : MonoBehaviour
    {
        public GameObject
            ScrollViewContent,
            listItem;

        private int targetKeyID;
        private Text buttonText;

        private bool doesExitPointer;

        public void setParameters(int targetID, Text buttonText)
        {
            targetKeyID = targetID;
            this.buttonText = buttonText;
            
            setMusicalInstItem();
        }

        public void add(GameObject item)
        {
            item.SetActive(true);
            item.transform.SetParent(ScrollViewContent.transform);
            item.transform.localScale=new Vector3(1,1,1);
        }

        public void clear()
        {
            foreach (var VARIABLE in ScrollViewContent.GetComponentsInChildren<ItemConnector>())
            {
                VARIABLE.delete();
            }
        }

        public void setMusicalInstItem()
        {
            ModuleBase[] moduleArray =
            {
                new ModulePiano(), new ModuleMarimba(), new ModuleVibraphone(), new ModuleSynthSound(),
                new ModuleDrumKit()
            };

            foreach (var VARIABLE in moduleArray)
            {
                var obj = Instantiate(listItem);
                obj.transform.SetParent(ScrollViewContent.transform);   
                obj.transform.localScale=new Vector3(1,1,1);
                obj.GetComponent<ItemConnector>().setItem(new BaseMusicalInstButton(listItem, buttonText, this, VARIABLE, targetKeyID));
                obj.SetActive(true);
            }
        }

        public void close()
        {
            Destroy(gameObject);
        }
        
        public void PointerExit()
        {
            doesExitPointer = true;
        }

        public void PointerEnter()
        {
            doesExitPointer = false;
        }

        public void Update()
        {
            if (doesExitPointer && Input.GetMouseButtonDown(0))
            {
                close();
            }
        }
    }
}