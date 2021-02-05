using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VermessungsBüroApp
{
    public class StationierungReinigen
    {
        private ZeileReinigen zeileReinigen;
        public string[] RawList { get; set; }
        private bool keepAddingLines;
        public string CleanedFile { get; set; }
        public bool KeepAddingLines
        {
            get { return keepAddingLines; }
            set { keepAddingLines = value; }
        }

        public ZeileReinigen ZeileReinigen
        {
            get { return zeileReinigen; }
            set { zeileReinigen = value; }
        }

        public StationierungReinigen()
        {
            
        }

        public string Reinige(string rohText)
        {
            var zeileReinigen = new ZeileReinigen();
            RawList = zeileReinigen.GenerateRawList(rohText);
            List<string> cleanedList = new List<string>();
            for (int i = 0; i < RawList.Length; i++)
            {
                if (i < 16) keepAddingLines = true;

                if (RawList[i].Contains("=======") && RawList[i + 1] == string.Empty && RawList[i + 2].StartsWith("Ma")) keepAddingLines = true;

                if (RawList[i].Contains("=======") && RawList[i + 1].Contains("Neue Stationierung nach der Methode Freie Station")) keepAddingLines = true;

                if (RawList[i].Contains("m.F. Ost") && RawList[i + 1].Contains("m.F. Nord") && !RawList[i].Any(char.IsDigit))
                    {
                        for (int j = i; j >= 0; j--)
                        {
                            if (RawList[j].StartsWith("Ma") && RawList[j].Contains("ZM") || RawList[j].StartsWith("==")) break;
                            cleanedList.RemoveAt(cleanedList.Count - 1);

                        }
                    i += 8;
                    }

                if (RawList[i].Contains("=======") && RawList[i + 2].Contains("alle TPS-Messungen")) keepAddingLines = false;
               
                if(keepAddingLines) cleanedList.Add(RawList[i]);
            }
            string newLine = "";
            for (int i = 0; i < cleanedList.Count; i++)
            {
                CleanedFile += newLine + cleanedList[i];
                newLine = "\n";
            }
            return CleanedFile;
        }
    }
}
