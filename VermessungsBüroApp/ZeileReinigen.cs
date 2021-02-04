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
            string newLine = string.Empty;
            for (int i = 0; i < rawList.Length; i++)
            {
                string cleanedLine = CleanLine(rawList[i], false);
                if (!string.IsNullOrWhiteSpace(cleanedFile)) newLine = "\n";
                if (!string.IsNullOrWhiteSpace(cleanedLine)) cleanedFile += newLine + cleanedLine;
            }
            return cleanedFile;
        }

        private string[] GenerateRawList(string rawText)
        {
            string[] rawList = rawText.Split('\n');
            return rawList;
        }

        private string CleanLine(string rawLine, bool isFinal)
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
                cleanedLineItems.Insert(4, "0");
            }
            if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length < 4)
            {
                cleanedLineItems.Insert(4, "0");
            }
            else if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length > 3) cleanedLineItems.Insert(1, "205");
            if (cleanedLineItems[0].Contains("STKE"))
            {
                cleanedLineItems[0] = cleanedLineItems[0].Replace("STKE", string.Empty);
            }
            if (cleanedLineItems[0].Length < 8) cleanedLineItems[0] = CorrectLength(cleanedLineItems[0], 8, isFinal);
            if (cleanedLineItems[1].Length < 4) cleanedLineItems[1] = CorrectLength(cleanedLineItems[1], 4, isFinal);
            if (cleanedLineItems[2].Length < 8) cleanedLineItems[2] = CorrectLength(cleanedLineItems[2], 8, isFinal);
            if (cleanedLineItems[3].Length < 8) cleanedLineItems[3] = CorrectLength(cleanedLineItems[3], 8, isFinal);
            if (cleanedLineItems[4].Length < 8) cleanedLineItems[4] = CorrectLength(cleanedLineItems[4], 7, isFinal);
            cleanedFullLine = CleanLinesToPrint(cleanedFullLine, cleanedLineItems);
            return cleanedFullLine;

        }
        static string CorrectLength(string item, int itemLength, bool isFinal)
        {
            string result = item;
            if (item.Length < itemLength && isFinal == false)
            {
                int whiteSpace = itemLength - item.Length;
                int counter = whiteSpace*2;
                if (itemLength == 7 && item == "0") counter = whiteSpace * 2 - 1;
                for (int j = 0; j < counter; j++)
                {
                    result = " " + result;
                }
            }
            if (item.Length < itemLength && isFinal == true)
            {
                int whiteSpace = itemLength - item.Length;
               // if (itemLength == 7 && item == "0") whiteSpace += 1;
                if (itemLength == 4) whiteSpace -= 1;
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
                //cleandFullLine += $" dz = {dz}mm  ds = {ds}mm";
            }

            return cleandFullLine;
        }

        internal string FinalClean(string cleanedText)
        {
            string cleanedFile = string.Empty;
            string[] rawList = GenerateRawList(cleanedText);
            List<string> cleanedList = new List<string>();
            string newLine = string.Empty;
            for (int i = 0; i < rawList.Length; i++)
            {
                string cleanedLine = CleanLine(rawList[i], true);
                if (!string.IsNullOrWhiteSpace(cleanedFile)) newLine = "\n";
                if (!string.IsNullOrWhiteSpace(cleanedLine)) cleanedFile += newLine + cleanedLine;
            }
            return cleanedFile;
        }


    }

}



