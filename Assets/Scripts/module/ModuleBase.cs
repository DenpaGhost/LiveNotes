namespace UiButtons.Title.module
{
    public class ModuleBase
    {
        protected string ModuleName;

        public string Name => ModuleName;

        public ModuleData[] ClipDates => Dates;

        protected ModuleData[] Dates;
        
        
    }
}