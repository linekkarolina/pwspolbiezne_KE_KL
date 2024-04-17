using System;

namespace PW.Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi()
        {
            Data logic = new Data();
            return logic;
        }
    }
}
