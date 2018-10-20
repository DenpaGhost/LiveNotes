namespace game
{
    public class RefreshRateSetButton : SetParametersUiBaseButton
    {
        private void Start()
        {
            setText(UtilFunctions.PutComma(GameParameters.RefreshRate));
        }

        public override void OnClick()
        {
            base.OnClick();

            //Sliderの初期化処理
            SliderInstance.GetComponent<ValueSlider>().SetValue(
                GameConstants.REFRESH_RATE_MAX,
                GameConstants.REFRESH_RATE_MIN,
                GameParameters.RefreshRate,
                this
            );
        }

        public override void onReturnButton(float value)
        {
            GameParameters.RefreshRate = (ushort) value;
            base.onReturnButton(value);
        }
    }
}