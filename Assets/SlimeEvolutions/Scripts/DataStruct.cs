using System.Collections.Generic;
using System;

public struct DataStruct 
{
    public List<Slime> slimeArray;
    public DateTime date;

    public DataStruct(List<Slime> slimes, DateTime date)
    {
        slimeArray = slimes;
        this.date = date;
    }
}
