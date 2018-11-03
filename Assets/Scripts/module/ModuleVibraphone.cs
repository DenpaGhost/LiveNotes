namespace UiButtons.Title.module
{
    public class ModuleVibraphone : ModuleBase
    {
        public ModuleVibraphone()
        {
            ModuleName = "Vibraphone";

            string[] name =
            {
                "C0", "C#0", "D0", "D#0", "E0", "F0", "F#0", "G0", "G#0", "A0", "A#0", "B0",
                "C1", "C#1", "D1", "D#1", "E1", "F1", "F#1", "G1", "G#1", "A1", "A#1", "B1",
                "C2", "C#2", "D2", "D#2", "E2", "F2", "F#2", "G2", "G#2", "A2", "A#2", "B2",
                "C3", "C#3", "D3", "D#3", "E3", "F3", "F#3", "G3", "G#3", "A3", "A#3", "B3",
                "C4", "C#4", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4", "A4", "A#4", "B4"
            };

            string[] path =
            {
                "00_vibraphone_C0", "01_vibraphone_Cs0", "02_vibraphone_D0", "03_vibraphone_Ds0", "04_vibraphone_E0", "05_vibraphone_F0",
                "06_vibraphone_Fs0", "07_vibraphone_G0", "08_vibraphoneGs0", "09_vibraphone_A0", "10_vibraphone_As0", "11_vibraphone_B0",

                "12_vibraphone_C1", "13_vibraphone_Cs1", "14_vibraphone_D1", "15_vibraphone_Ds1", "16_vibraphone_E1", "17_vibraphone_F1",
                "18_vibraphone_Fs1", "19_vibraphone_G1", "21_vibraphoneGs1", "21_vibraphone_A1", "22_vibraphone_As1", "23_vibraphone_B1",

                "24_vibraphone_C2", "25_vibraphone_Cs2", "26_vibraphone_D2", "27_vibraphone_Ds2", "28_vibraphone_E2", "29_vibraphone_F2",
                "30_vibraphone_Fs2", "31_vibraphone_G2", "32_vibraphoneGs2", "33_vibraphone_A2", "34_vibraphone_As2", "35_vibraphone_B2",

                "36_vibraphone_C3", "37_vibraphone_Cs3", "38_vibraphone_D3", "39_vibraphone_Ds3", "40_vibraphone_E3", "41_vibraphone_F3",
                "42_vibraphone_Fs3", "43_vibraphone_G3", "44_vibraphoneGs3", "45_vibraphone_A3", "46_vibraphone_As3", "47_vibraphone_B3",

                "48_vibraphone_C4", "49_vibraphone_Cs4", "50_vibraphone_D4", "51_vibraphone_Ds4", "52_vibraphone_E4", "53_vibraphone_F4",
                "54_vibraphone_Fs4", "55_vibraphone_G4", "56_vibraphoneGs4", "57_vibraphone_A4", "58_vibraphone_As4", "59_vibraphone_B4"
            };

            Dates = new ModuleData[name.Length];

            for (var i = 0; i < Dates.Length; i++)
            {
                Dates[i] = new ModuleData(name[i], "vibraphone/"+path[i]);
            }
        }
    }
}