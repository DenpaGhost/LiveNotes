namespace game
{
    public class MultipleMinButton:SetParametersUiBaseButton
    {
        private void Start()
        {
            setText(UtilFunctions.PutComma(GameParameters.Min));
        }

        public override void OnClick()
        {
            base.OnClick();

            //Sliderの初期化処理
            SliderInstance.GetComponent<ValueSlider>().SetValue(
                GameParameters.Max,
                0,
                GameParameters.Min,
                gameObject
            );
        }

        public override void onReturnButton(float value)
        {
            GameParameters.Min = (byte) value;
            base.onReturnButton(value);
        }
    }
}