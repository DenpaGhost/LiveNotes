namespace UiButtons.Title.module
{
    public class ModuleSynthSound : ModuleBase
    {
        public ModuleSynthSound()
        {
            ModuleName = "Synth Sound";

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
                "00_synth_b_C0", "01_synth_b_Cs0", "02_synth_b_D0", "03_synth_b_Ds0", "04_synth_b_E0", "05_synth_b_F0",
                "06_synth_b_Fs0", "07_synth_b_G0", "08_synth_bGs0", "09_synth_b_A0", "10_synth_b_As0", "11_synth_b_B0",

                "12_synth_b_C1", "13_synth_b_Cs1", "14_synth_b_D1", "15_synth_b_Ds1", "16_synth_b_E1", "17_synth_b_F1",
                "18_synth_b_Fs1", "19_synth_b_G1", "21_synth_bGs1", "21_synth_b_A1", "22_synth_b_As1", "23_synth_b_B1",

                "24_synth_b_C2", "25_synth_b_Cs2", "26_synth_b_D2", "27_synth_b_Ds2", "28_synth_b_E2", "29_synth_b_F2",
                "30_synth_b_Fs2", "31_synth_b_G2", "32_synth_bGs2", "33_synth_b_A2", "34_synth_b_As2", "35_synth_b_B2",

                "36_synth_b_C3", "37_synth_b_Cs3", "38_synth_b_D3", "39_synth_b_Ds3", "40_synth_b_E3", "41_synth_b_F3",
                "42_synth_b_Fs3", "43_synth_b_G3", "44_synth_bGs3", "45_synth_b_A3", "46_synth_b_As3", "47_synth_b_B3",

                "48_synth_b_C4", "49_synth_b_Cs4", "50_synth_b_D4", "51_synth_b_Ds4", "52_synth_b_E4", "53_synth_b_F4",
                "54_synth_b_Fs4", "55_synth_b_G4", "56_synth_bGs4", "57_synth_b_A4", "58_synth_b_As4", "59_synth_b_B4"
            };

            Dates = new ModuleData[name.Length];

            for (var i = 0; i < Dates.Length; i++)
            {
                Dates[i] = new ModuleData(name[i], path[i]);
            }
        }
    }
}