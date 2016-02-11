﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar4X.ECSLib;

namespace Pulsar4X.ViewModel
{
   public class ComponentAbilityTemplateVM : IViewModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        //public DictionaryVM<GuiHint, string> GuiHint { get; set; }
        public GuiHint SelectedGuiHint{ get; set; }
        public DictionaryVM<Type,string> AbilityDataBlobType { get; set; }
        public string AbilityFormula { get; set; }
        public string MinFormula { get; set; }
        public string MaxFormula { get; set; }

        public ComponentAbilityTemplateVM()
        {
            //GuiHint = Enum.GetNames(typeof(ECSLib.GuiHint)).ToList<string>();
            //GuiHint = new DictionaryVM<ECSLib.GuiHint, string>(DisplayMode.Value);
            //GuiHint = typeof(GuiHint);
            AbilityDataBlobType = GetTypeDict(AbilityTypes());
        }


        private static List<Type> AbilityTypes()
        {
            List<Type> typelist = new List<Type>();
            typelist.Add(typeof(ConstructInstationsAbilityDB));
            typelist.Add(typeof(ConstructShipComponentsAbilityDB));
            typelist.Add(typeof(ConstructAmmoAbilityDB));
            typelist.Add(typeof(ConstructFightersAbilityDB));
            typelist.Add(typeof(EnginePowerDB));
            typelist.Add(typeof(FuelStorageDB));
            typelist.Add(typeof(FuelUseDB));
            typelist.Add(typeof(MineResourcesDB));
            typelist.Add(typeof(MissileLauncherSizeDB));
            typelist.Add(typeof(RefineResourcesDB));
            typelist.Add(typeof(ResearchPointsAbilityDB));
            typelist.Add(typeof(SensorSignatureDB));
            typelist.Add(typeof(ActiveSensorDB));

            return typelist;
        }

        private static DictionaryVM<Type, string> GetTypeDict(List<Type> abilityTypes)
        {
            DictionaryVM<Type, string> dict = new DictionaryVM<Type, string>(DisplayMode.Key);
            foreach (var type in abilityTypes)
            {
                dict.Add(type, type.Name);
            }

            return dict;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void Refresh(bool partialRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
