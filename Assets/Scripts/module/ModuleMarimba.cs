namespace UiButtons.Title.module
{
    public class ModuleMarimba : ModuleBase
    {
        public ModuleMarimba()
        {
            ModuleName = "Marimba";

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
                "00_marimba_C0", "01_marimba_Cs0", "02_marimba_D0", "03_marimba_Ds0", "04_marimba_E0", "05_marimba_F0",
                "06_marimba_Fs0", "07_marimba_G0", "08_marimbaGs0", "09_marimba_A0", "10_marimba_As0", "11_marimba_B0",

                "12_marimba_C1", "13_marimba_Cs1", "14_marimba_D1", "15_marimba_Ds1", "16_marimba_E1", "17_marimba_F1",
                "18_marimba_Fs1", "19_marimba_G1", "21_marimbaGs1", "21_marimba_A1", "22_marimba_As1", "23_marimba_B1",

                "24_marimba_C2", "25_marimba_Cs2", "26_marimba_D2", "27_marimba_Ds2", "28_marimba_E2", "29_marimba_F2",
                "30_marimba_Fs2", "31_marimba_G2", "32_marimbaGs2", "33_marimba_A2", "34_marimba_As2", "35_marimba_B2",

                "36_marimba_C3", "37_marimba_Cs3", "38_marimba_D3", "39_marimba_Ds3", "40_marimba_E3", "41_marimba_F3",
                "42_marimba_Fs3", "43_marimba_G3", "44_marimbaGs3", "45_marimba_A3", "46_marimba_As3", "47_marimba_B3",

                "48_marimba_C4", "49_marimba_Cs4", "50_marimba_D4", "51_marimba_Ds4", "52_marimba_E4", "53_marimba_F4",
                "54_marimba_Fs4", "55_marimba_G4", "56_marimbaGs4", "57_marimba_A4", "58_marimba_As4", "59_marimba_B4"
            };

            Dates = new ModuleData[name.Length];

            for (var i = 0; i < Dates.Length; i++)
            {
                Dates[i] = new ModuleData(name[i], path[i]);
            }
        }
    }
}