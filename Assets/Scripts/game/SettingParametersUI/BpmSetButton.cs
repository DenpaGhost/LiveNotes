using System;

namespace game
{
    public class BpmSetButton : SetParametersUiBaseButton
    {
        public override void OnClick()
        {
            base.OnClick();

            //Sliderの初期化処理
            SliderInstance.GetComponent<ValueSlider>().SetValue(
                GameConstants.BPM_MAX,
                GameConstants.BPM_MIN,
                GameParameters.Bpm,
                this
            );
        }

        public override void onReturnButton(float value)
        {
            GameParameters.Bpm = (ushort) value;
            LiveNotesFunctions.SetParametersToView();
        }
    }
}