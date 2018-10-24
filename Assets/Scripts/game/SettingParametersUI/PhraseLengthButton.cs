namespace game
{
    public class PhraseLengthButton : SetParametersUiBaseButton
    {
        private void Start()
        {
            setText(UtilFunctions.PutComma(GameParameters.PhraseLength));
        }

        public override void OnClick()
        {
            base.OnClick();

            //Sliderの初期化処理
            SliderInstance.GetComponent<ValueSlider>().SetValue(
                GameConstants.PHRASE_MAX,
                GameConstants.PHRASE_MIN,
                GameParameters.PhraseLength,
                gameObject
            );
        }

        public override void onReturnButton(float value)
        {
            GameParameters.PhraseLength = (ushort) value;
            base.onReturnButton(value);
        }
    }
}