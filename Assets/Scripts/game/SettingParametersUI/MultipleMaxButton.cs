namespace game
{
    public class MultipleMaxButton:SetParametersUiBaseButton
    {
        private void Start()
        {
            setText(UtilFunctions.PutComma(GameParameters.Max));
        }

        public override void OnClick()
        {
            base.OnClick();

            //Sliderの初期化処理
            SliderInstance.GetComponent<ValueSlider>().SetValue(
                7,
                GameParameters.Min,
                GameParameters.Max,
                gameObject
            );
        }

        public override void onReturnButton(float value)
        {
            GameParameters.Max = (byte) value;
            base.onReturnButton(value);
        }
    }
}