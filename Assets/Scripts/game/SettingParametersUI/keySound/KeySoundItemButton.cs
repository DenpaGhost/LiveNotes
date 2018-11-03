using System;
using UnityEngine.UI;

namespace game
{
    public class KeySoundItemButton:BaseListItem
    {
        private readonly string 
            ModuleName,
            Path;

        private readonly int 
            targetKey;

        public KeySoundItemButton(
            Text buttonText, 
            KeySoundSelectDialog listView,
            string moduleName, 
            string clipName, 
            string path,
            int targetKey
            )
        {
            this.buttonText = buttonText;
            this.listView = listView;
            name = clipName;
            ModuleName = moduleName;
            Path = path;
            this.targetKey = targetKey;
        }

        public override void onClick()
        {
            buttonText.text = ModuleName + "\n" + Name;
            listView.close();
        }
    }
}