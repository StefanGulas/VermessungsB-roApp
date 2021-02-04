using System.Collections.Generic;
using System.Linq;

namespace VermessungsBüroApp
{
    public class ZeileReinigen
    {
        public string CleaneText(string rawText)
        {
            string cleanedFile = string.Empty;
            string[] rawList = GenerateRawList(rawText);
            List<string> cleanedList = new List<string>();
            for (int i = 0; i < rawList.Length; i++)
            {
                string cleanedLine = CleanLine(rawList[i]);
                cleanedFile += "\n" + cleanedLine;
            }
            return cleanedFile;


            //if (line.Count() < 3) continue;
            //    if (line.Count() == 3)
            //    {
            //        line.Insert(1, "205");
            //        line.Insert(4, "     0");
            //    }
            //    if (line.Count() == 4 && line[1].Length == 2)
            //    {
            //        cleanedLineItems[1] = " " + cleanedLineItems[1];
            //        cleanedLineItems.Insert(4, "     0");
            //    }
            return rawText;
        }

        private string[] GenerateRawList(string rawText)
        {
            string[] rawList = rawText.Split('\n');
            return rawList;
        }

        private string CleanLine(string rawLine)
        {
            string cleanedFullLine = string.Empty;
            string[] numbersInLine = rawLine.Split(' ');
            List<string> cleanedLineItems = new List<string>();
            foreach (var number in numbersInLine)
            {
                //if (number.Contains("STKE")) number = number.Replace("STKE", "");
                if (string.IsNullOrWhiteSpace(number) || number.Contains('"') || !number.Any(char.IsDigit)) continue;
                if (number.All(char.IsDigit) || number.Contains(".") || number.Contains("STKE")) cleanedLineItems.Add(number);
            }


            if (cleanedLineItems.Count() < 3) return string.Empty;
            if (cleanedLineItems.Count() == 3)
            {
                cleanedLineItems.Insert(1, "205");
                cleanedLineItems.Insert(4, "     0");
            }
            if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length == 2)
            {
                cleanedLineItems[1] = " " + cleanedLineItems[1];
                cleanedLineItems.Insert(4, "     0");
            }
            else if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length == 3)
            {
                cleanedLineItems.Insert(4, "     0");
            }
            else if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length > 3) cleanedLineItems.Insert(1, "205");
            if (cleanedLineItems[0].Contains("STKE"))
            {
                cleanedLineItems[0] = cleanedLineItems[0].Replace("STKE", "");
            }
            if (cleanedLineItems[0].Length < 8) cleanedLineItems[0] = CorrectLength(cleanedLineItems[0], 8);
            if (cleanedLineItems[1].Length < 3) cleanedLineItems[1] = CorrectLength(cleanedLineItems[1], 3);
            if (cleanedLineItems[2].Length < 8) cleanedLineItems[2] = CorrectLength(cleanedLineItems[2], 8);
            if (cleanedLineItems[3].Length < 8) cleanedLineItems[3] = CorrectLength(cleanedLineItems[3], 8);
            if (cleanedLineItems[4].Length < 8) cleanedLineItems[3] = CorrectLength(cleanedLineItems[3], 8);
            cleanedFullLine = CleanLinesToPrint(cleanedFullLine, cleanedLineItems);
            return cleanedFullLine;

        }
        static string CorrectLength(string item, int itemLength)
        {
            string result = item;
            if (item.Length < itemLength)
            {
                int whiteSpace = itemLength - item.Length;
                for (int j = 0; j < whiteSpace; j++)
                {
                    result = " " + result;
                }
            }
            return result;
        }
        static string CleanLinesToPrint(string cleanedFullLine, List<string> cleanedLineItems)
        {
            foreach (var item in cleanedLineItems)
            {
                cleanedFullLine += item + " ";
            }
            cleanedFullLine.TrimEnd();
            cleanedFullLine = AdjustLineIfAnschlussOderAbschlusspunktLine(cleanedLineItems, cleanedFullLine);
            return cleanedFullLine;
        }
        static string AdjustLineIfAnschlussOderAbschlusspunktLine(List<string> cleanedLineItems, string cleandFullLine)
        {
            string dz = "1";
            string ds = "3";
            if (cleanedLineItems[1].Contains("96") || cleanedLineItems[1].Contains("98"))
            {
                cleandFullLine += $"dz = {dz}mm  ds = {ds}mm";
            }

            return cleandFullLine;
        }
    }

}



