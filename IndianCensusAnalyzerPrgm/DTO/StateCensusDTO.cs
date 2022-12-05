using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyzerPrgm.DTO
{
    public class StateCensusDAO
    {
        public string State;
        public long Population;
        public long AreaInSqKm;
        public long DensityPerSqKm;

        public StateCensusDAO(string State, string Population, string AreaInSqKm, string DensityPerSqKm)
        {
            this.State = State;
            this.Population = Convert.ToInt32(Population);
            this.AreaInSqKm = Convert.ToInt32(AreaInSqKm);
            this.DensityPerSqKm = Convert.ToInt32(DensityPerSqKm);
        }
    }
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}