using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VermessungsBüroApp
{
    public class ZeileReinigen
    {
        public string CleaneLine(string line)
        {

            return line;
        }

    }
    //        string cleanedFullLine = string.Empty;
    //        List<string> cleanedLineItems = CleanLine(rawLines[i]);
    //                if (cleanedLineItems.Count() < 3) continue;
    //                if (cleanedLineItems.Count() == 3)
    //                {
    //                    cleanedLineItems.Insert(1, "205");
    //                    cleanedLineItems.Insert(4, "     0");
    //                }
    //                if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length == 2)
    //                {
    //                    cleanedLineItems[1] = " " + cleanedLineItems[1];
    //                    cleanedLineItems.Insert(4, "     0");
    //                }
    //                else if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length == 3)
    //{
    //    cleanedLineItems.Insert(4, "     0");
    //}
    //else if (cleanedLineItems.Count() == 4 && cleanedLineItems[1].Length > 3) cleanedLineItems.Insert(1, "205");
    //if (cleanedLineItems[0].Contains("STKE"))
    //{
    //    cleanedLineItems[0] = cleanedLineItems[0].Replace("STKE", "");
    //}
    //if (cleanedLineItems[0].Length < 8) cleanedLineItems[0] = CorrectLength(cleanedLineItems[0], 8);
    //if (cleanedLineItems[1].Length < 3) cleanedLineItems[1] = CorrectLength(cleanedLineItems[1], 3);
    //if (cleanedLineItems[2].Length < 8) cleanedLineItems[2] = CorrectLength(cleanedLineItems[2], 8);
    //if (cleanedLineItems[3].Length < 8) cleanedLineItems[3] = CorrectLength(cleanedLineItems[3], 8);
    //if (cleanedLineItems[4].Length < 8) cleanedLineItems[3] = CorrectLength(cleanedLineItems[3], 8);
    //cleanedFullLine = CleanLinesToPrint(cleanedFullLine, cleanedLineItems);
    //cleanedLines.Add(cleanedFullLine);
    //                //Console.WriteLine(cleanedFullLine);
    //            }



    //            foreach (var item in cleanedLines)
    //{
    //    Console.WriteLine(item);
    //    cleanedErgebnisLines.Add(item);
    //}

    //Console.WriteLine("\nWollen Sie die Datei speichern? j / n");
    //string userDecisionWhichRawFile = Console.ReadLine().ToLower();
    //if (userDecisionWhichRawFile == "n")
    //{
    //    Environment.Exit(0);
    //}
    //            //Console.ReadLine();

    //        }
    //        newFile1 += Path.GetFileName(rawFile);
    //newFile2 += Path.GetFileName(rawFile);

    //using (StreamWriter writer = new StreamWriter(newFile1))
    //{
    //    foreach (var line in cleanedErgebnisLines) writer.WriteLine(line);
    //}
    //using (StreamWriter writer = new StreamWriter(newFile2))
    //{
    //    foreach (var line in cleanedErgebnisLines) writer.WriteLine(line);
    //}
    //                }

    //        static string CleanLinesToPrint(string cleanedFullLine, List<string> cleanedLineItems)
    //        {
    //            foreach (var item in cleanedLineItems)
    //            {
    //                cleanedFullLine += item + " ";
    //            }
    //            cleanedFullLine.TrimEnd();
    //            cleanedFullLine = AdjustLineIfAnschlussOderAbschlusspunktLine(cleanedLineItems, cleanedFullLine);
    //            return cleanedFullLine;
    //        }

    //        static string AdjustLineIfAnschlussOderAbschlusspunktLine(List<string> cleanedLineItems, string cleandFullLine)
    //        {
    //            string dz = "1";
    //            string ds = "3";
    //            if (cleanedLineItems[1].Contains("96") || cleanedLineItems[1].Contains("98"))
    //            {
    //                cleandFullLine += $"dz = {dz}mm  ds = {ds}mm";
    //            }

    //            return cleandFullLine;
    //        }

    //        static List<string> CleanLine(string line)
    //        {
    //            string[] numbersInLine = line.Split(' ');
    //            List<string> numbersResultLine = new List<string>();
    //            foreach (var number in numbersInLine)
    //            {
    //                //if (number.Contains("STKE")) number = number.Replace("STKE", "");
    //                if (string.IsNullOrWhiteSpace(number) || number.Contains('"') || !number.Any(char.IsDigit)) continue;
    //                if (number.All(char.IsDigit) || number.Contains(".") || number.Contains("STKE")) numbersResultLine.Add(number);

    //            }
    //            return numbersResultLine;
    //        }
    //        static string CorrectLength(string item, int itemLength)
    //        {
    //            string result = item;
    //            if (item.Length < itemLength)
    //            {
    //                int whiteSpace = itemLength - item.Length;
    //                for (int j = 0; j < whiteSpace; j++)
    //                {
    //                    result = " " + result;
    //                }
    //            }
    //            return result;
    //        }

    
}

    

