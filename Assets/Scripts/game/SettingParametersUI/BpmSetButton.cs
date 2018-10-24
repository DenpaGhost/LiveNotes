namespace game
{
    public class BpmSetButton : SetParametersUiBaseButton
    {
        private void Start()
        {
            setText(UtilFunctions.PutComma(GameParameters.Bpm));
        }

        public override void OnClick()
        {
            base.OnClick();

            //Sliderの初期化処理
            SliderInstance.GetComponent<ValueSlider>().SetValue(
                GameConstants.BPM_MAX,
                GameConstants.BPM_MIN,
                GameParameters.Bpm,
                gameObject
            );
        }

        public override void onReturnButton(float value)
        {
            GameParameters.Bpm = (ushort) value;
            base.onReturnButton(value);
        }
    }
}