using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public abstract class BaseListItem
    {
        protected string name;
        protected Text buttonText;
        protected KeySoundSelectDialog listView;

        public string Name => name;

        public abstract void onClick();
    }
}