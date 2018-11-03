namespace UiButtons.Title.module
{
    public class ModuleDrumKit : ModuleBase
    {
        public ModuleDrumKit()
        {
            ModuleName = "Dram Kit";

            string[] name =
            {
                "Bass", "snare", "Tom", "Hi hat (A)", "Hi hat (B)", "Crash", "Ride (A)", "Ride (B)", "Ride (C)"
            };

            string[] path =
            {
                "100_Drum_Bass", "101_Drum_snare", "102_Drum_tom", "104_Drum_hihat", "105_Drum_hihat2",
                "106_Drum_crash", "107_Drum_ride", "108_Drum_ride2", "109_Drum_ride3"
            };

            Dates = new ModuleData[name.Length];

            for (var i = 0; i < Dates.Length; i++)
            {
                Dates[i] = new ModuleData(name[i], "drum/"+path[i]);
            }
        }
    }
}