using TemperatureRecord.Types;
using System.IO;

Console.WriteLine("---MENU---");
Console.WriteLine("---1) JSON---");
Console.WriteLine("---2) XML---");
Console.WriteLine("---3) CSV---");
Console.WriteLine("---4) EXIT---");
string option = Console.ReadLine();
string path = "../../../SamplesFiles/OutPut.txt";
switch (option)
{
    case "1":
        JsonFile json = new JsonFile();
        json.OpenDirectory("../../Data.json");
        var ResultJson = json.Analyze();
        
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(ResultJson);
            }
        }

        break;

    case "2":
        XmlFile xml = new ();
        xml.OpenDirectory(@"..\..\..\SamplesFiles\Data.xml");
        var ResultXml = xml.Analyze();

        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(ResultXml);
            }
        }
        break;
    case "3":
            CsvFile csv = new CsvFile();
            csv.ReadFile(@"..\..\..\SamplesFiles\Data.csv");
            var ResultCsv = csv.Analyze();
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(ResultCsv);
            }
        }
        break;

    default:
        Environment.Exit(1);
        break;
}    


