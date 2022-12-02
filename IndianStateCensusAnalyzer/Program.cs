using IndianStateCensusAnalyzer.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
    public class CensusAnalyser
    {

        public static int a = 10;
        public enum Country
        {
            INDIA, US, BRAZIL
        }


        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            //CensusAnalyser obj = new CensusAnalyser();
            //Console.WriteLine(obj.a);
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

    }
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_FILE_TYPE,
            INCORRECT_DELIMITER,
            INCORRECT_HEADER,
            NO_SUCH_COUNTRY
        }

        public ExceptionType eType;
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }

    }
    class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                //case (CensusAnalyser.Country.US):
                //    return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
    class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File contains wrong delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);

                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new POCO.StateCodeDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new POCO.CensusDataDAO(column[0], column[1], column[2], column[3])));

            }

            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }
}
