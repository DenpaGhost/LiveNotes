using UnityEngine;

namespace game
{
    public class GameOrder : MonoBehaviour
    {
        public GameObject EventSystem;

        public bool getLiveNotesEnabled()
        {
            return EventSystem.GetComponent<NotesManager>().enabled;
        }

        public void PowerOnLiveNotes()
        {
            
        }
    }
}