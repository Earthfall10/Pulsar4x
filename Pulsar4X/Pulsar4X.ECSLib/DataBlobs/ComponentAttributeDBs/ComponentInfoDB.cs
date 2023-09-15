﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Pulsar4X.ECSLib.Industry;
using System.ComponentModel;

namespace Pulsar4X.ECSLib
{
    [Flags]
    public enum ComponentMountType
    {
        [Description("None")]
        None                = 0,
        [Description("Ship")]
        ShipComponent       = 1 << 0,
        [Description("Cargo Hold")]
        ShipCargo           = 1 << 1,
        [Description("Colony")]
        PlanetInstallation  = 1 << 2,
        [Description("PDC")]
        PDC                 = 1 << 3,
        [Description("Fighter")]
        Fighter             = 1 << 4,
        [Description("Missle")]
        Missile             = 1 << 5,
    }

    public class ComponentInfoDB : BaseDataBlob
    {
        [JsonProperty]
        public Guid DesignGuid { get; internal set; }

        [JsonProperty]
        public float SizeInTons { get; internal set; }

        [JsonProperty]
        public int HTK { get; internal set; }

        [JsonProperty]
        public Dictionary<Guid, int> MinerialCosts { get; internal set; }

        [JsonProperty]
        public Dictionary<Guid, int> MaterialCosts { get; internal set; }

        [JsonProperty]
        public Dictionary<Guid, int> ComponentCosts { get; internal set; }

        [JsonProperty]
        public int BuildPointCost { get; internal set; }

        [JsonProperty]
        public Guid TechRequirementToBuild { get; internal set; }

        [JsonProperty]
        public int CrewRequrements { get; internal set; }

        [JsonProperty]
        public ComponentMountType ComponentMountType { get; internal set; }

        public ConstructionType ConstructionType { get; internal set; }

        public List<IComponentDesignAttribute> DesignAttributes = new List<IComponentDesignAttribute>();

        public ComponentInfoDB()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="designGuid">this is the design GUID, NOT the SD GUID</param>
        /// <param name="size"></param>
        /// <param name="htk"></param>
        /// <param name="materialCosts"></param>
        /// <param name="techRequrement"></param>
        /// <param name="crewReqirement"></param>
        public ComponentInfoDB(Guid designGuid, int size, int htk, int buildPointCost, Dictionary<Guid, int> minerialCosts, Dictionary<Guid, int> materialCosts, Dictionary<Guid, int> componentCosts, Guid techRequrement, int crewReqirement)
        {
            DesignGuid = designGuid;
            SizeInTons = size;
            HTK = htk;
            BuildPointCost = buildPointCost;
            MinerialCosts = minerialCosts;
            MaterialCosts = materialCosts;
            ComponentCosts = componentCosts;
            TechRequirementToBuild = techRequrement;
            CrewRequrements = crewReqirement;
        }

        public ComponentInfoDB(ComponentInfoDB db)
        {
            SizeInTons = db.SizeInTons;
            HTK = db.HTK;
            MaterialCosts = db.MaterialCosts;
            TechRequirementToBuild = db.TechRequirementToBuild;
        }

        public override object Clone()
        {
            return new ComponentInfoDB(this);
        }
    }
}