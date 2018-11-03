using System.Net.Mime;
using UiButtons.Title.module;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class BaseMusicalInstButton:BaseListItem
    {
        private readonly GameObject listItem;
        
        private readonly ModuleBase module;
        private readonly int targetKeyID;


        public BaseMusicalInstButton(
            GameObject itemObject,
            Text buttonText,
            KeySoundSelectDialog listView,
            ModuleBase module,
            int targetKeyId
            )
        {
            listItem = itemObject;
            this.buttonText = buttonText;
            this.listView = listView;
            this.module = module;
            targetKeyID = targetKeyId;

            name = module.Name;
        }

        public override void onClick()
        {
            listView.clear();

            foreach (var VARIABLE in module.ClipDates)
            {
                var obj = Object.Instantiate(listItem);
                obj.GetComponent<ItemConnector>().setItem(new KeySoundItemButton(buttonText, listView, module.Name, VARIABLE.ClipName, VARIABLE.ClipPath, targetKeyID));
                listView.add(obj);
            }
        }
    }
}