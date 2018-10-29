using UnityEngine;

namespace UiButtons.Title.module
{
    public class ModulePiano : ModuleBase
    {
        public ModulePiano()
        {
            ModuleName = "Piano";

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
                "00_piano_C0", "01_piano_Cs0", "02_piano_D0", "03_piano_Ds0", "04_piano_E0", "05_piano_F0",
                "06_piano_Fs0", "07_piano_G0", "08_pianoGs0", "09_piano_A1", "10_piano_As1", "11_piano_B1",

                "12_piano_C1", "13_piano_Cs1", "14_piano_D1", "15_piano_Ds1", "16_piano_E1", "17_piano_F1",
                "18_piano_Fs1", "19_piano_G1", "21_pianoGs1", "21_piano_A2", "22_piano_As2", "23_piano_B2",

                "24_piano_C2", "25_piano_Cs2", "26_piano_D2", "27_piano_Ds2", "28_piano_E2", "29_piano_F2",
                "30_piano_Fs2", "31_piano_G2", "32_pianoGs2", "33_piano_A3", "34_piano_As3", "35_piano_B3",

                "36_piano_C3", "37_piano_Cs3", "38_piano_D3", "39_piano_Ds3", "40_piano_E3", "41_piano_F3",
                "42_piano_Fs3", "43_piano_G3", "44_pianoGs3", "45_piano_A4", "46_piano_As4", "47_piano_B4",

                "48_piano_C4", "49_piano_Cs4", "50_piano_D4", "51_piano_Ds4", "52_piano_E4", "53_piano_F4",
                "54_piano_Fs4", "55_piano_G4", "56_pianoGs4", "57_piano_A5", "58_piano_As5", "59_piano_B5"
            };

            Dates = new ModuleData[name.Length];

            for (var i = 0; i < Dates.Length; i++)
            {
                Dates[i] = new ModuleData(name[i], path[i]);
            }
        }
    }
}