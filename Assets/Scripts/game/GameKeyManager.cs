using game;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class GameKeyManager : MonoBehaviour
    {
        public GameObject keyA, keyAs, keyB, keyBs, keyC, keyCs, keyD;
        private bool _canChangeSpeed = true;

        // Update is called once per frame
        private void Update()
        {
            KeyDownEvents();
            KeyUpEvent();
            ChangeSpeed();
        }
        
        private void ChangeSpeed()
        {
            if (Input.GetButtonDown("Vertical"))
            {
                if (Input.GetAxisRaw("Vertical") > 0 && _canChangeSpeed)
                {
                    GameParameters.Speed += 1;
                    _canChangeSpeed = false;
                    ViewOperator.RefreshSpeedView();
                }
                else if (Input.GetAxisRaw("Vertical") < 0 && _canChangeSpeed)
                {
                    GameParameters.Speed -= 1;
                    _canChangeSpeed = false;
                    ViewOperator.RefreshSpeedView();
                }
            }
            else
            {
                _canChangeSpeed = true;
            }
        }

        private void KeyDownEvents()
        {
            //A鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[0]))
            {
                keyA.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
            }

            //A#鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[1]))
            {
                keyAs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK_PUSH;
            }

            //B鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[2]))
            {
                keyB.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
            }

            //B#鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[3]))
            {
                keyBs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK_PUSH;
            }

            //C鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[4]))
            {
                keyC.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
            }

            //C#鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[5]))
            {
                keyCs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK_PUSH;
            }

            //D鍵
            if (Input.GetButtonDown(GameConstants.KEY_NAME[6]))
            {
                keyD.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE_PUSH;
            }
        }

        private void KeyUpEvent()
        {
            //A鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[0]))
            {
                keyA.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
            }

            //A#鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[1]))
            {
                keyAs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK;
            }

            //B鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[2]))
            {
                keyB.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
            }

            //B#鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[3]))
            {
                keyBs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK;
            }

            //C鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[4]))
            {
                keyC.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
            }

            //C#鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[5]))
            {
                keyCs.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_BLACK;
            }

            //D鍵
            if (Input.GetButtonUp(GameConstants.KEY_NAME[6]))
            {
                keyD.GetComponent<Image>().color = ConstantsColors.KEY_COLOR_WHITE;
            }
        }
    }
}