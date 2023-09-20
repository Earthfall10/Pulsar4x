﻿using System;
using Pulsar4X.Modding;

namespace Pulsar4X.ECSLib
{
    [StaticData(true, IDPropertyName = "ID")]
    public class CargoTypeSD
    {
        public string Name;
        public string Description;
        public Guid ID;
    }

    public interface ICargoable
    {
        Guid ID { get; }
        string Name { get; }
        Guid CargoTypeID { get;  }

        /// <summary>
        /// The smallest unit mass. 1 for most minerals etc. 
        /// </summary>
        long MassPerUnit { get; }
        
        double VolumePerUnit { get; }
    }

    [StaticData(true, IDPropertyName = "ID")]
    public struct IndustryTypeSD
    {
        public string Name;
        public Guid ID;
    }
}


