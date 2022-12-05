using CsvHelper;
using IndianCensusAnalyzerPrgm.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyzerPrgm.UsingCode
{
    public class StateCodeAnalyzer
    {
        public int ReadStateCodeData(string filepath)
        {
            if (!File.Exists(filepath))
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            if (!filepath.EndsWith(".csv"))
                throw new StateCensusException(StateCensusException.ExceptionType.TYPE_INCORRECT, "Incorrect File Ttpe");
            var read = File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCensusException(StateCensusException.ExceptionType.Delemeter_INCORRECT, "Incorrect Delemeter"); using (var reader = new StreamReader(filepath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<StateCodeDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data.serialNumber);
                    Console.WriteLine(data.stateName);
                    Console.WriteLine(data.tin);
                    Console.WriteLine(data.stateCode);
                }
                return records.Count() - 1;
            }
        }
        public bool ReadStateCodeData(string filePath, string actualheader)
        {
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Equals(actualheader))
                return true;
            else
                throw new StateCensusException(StateCensusException.ExceptionType.HEADER_INCORRECT, "Incorrect Header");


        }
    }

}