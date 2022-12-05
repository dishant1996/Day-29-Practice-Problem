using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyzerPrgm.DTO
{
    public class CSVStateCensus
    {
        public int ReadStateCensusData(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<StateCensusDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data.State);
                    Console.WriteLine(data.Population);
                    Console.WriteLine(data.AreaInSqKm);
                    Console.WriteLine(data.DensityPerSqKm);
                }
                return records.Count() - 1;
            }
        }
        public int ReadStateCodeData(string filepath)
        {
            using (var reader = new StreamReader(filepath))
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
    }
}
