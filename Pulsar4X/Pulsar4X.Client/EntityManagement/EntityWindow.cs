using System;
using System.Numerics;
using ImGuiNET;
using Pulsar4X.Engine;
using Pulsar4X.Datablobs;
using Pulsar4X.Extensions;
using Pulsar4X.ImGuiNetUI;
using Pulsar4X.ImGuiNetUI.EntityManagement;

namespace Pulsar4X.SDL2UI
{
    public class EntityWindow : NonUniquePulsarGuiWindow
    {
        public Entity Entity { get; private set; }
        public EntityState EntityState { get; private set; }
        public String Title { get; private set; }

        private Vector2 ButtonSize = new Vector2(32, 32);

        public EntityWindow(EntityState entityState)
        {
            Entity = entityState.Entity;
            EntityState = entityState;

            if(Entity.HasDataBlob<NameDB>())
            {
                Title = Entity.GetDataBlob<NameDB>().GetName(_uiState.Faction);
            }
            else
            {
                Title = "Unknown";
            }
        }

        internal override void Display()
        {
            if(!IsActive) return;

            ImGui.SetNextWindowSize(new System.Numerics.Vector2(512, 325), ImGuiCond.Once);
            if (ImGui.Begin(Title + " (" + EntityState.BodyType.ToDescription() + ")###" + Entity.Id, ref IsActive, _flags))
            {
                DisplayActions();

                ImGui.BeginTabBar("Tab bar!###Tabs" + Entity.Id);

                DisplayInfoTab();
                DisplayConditionalTabs();

                ImGui.EndTabBar();
                ImGui.End();
            }
        }

        private void DisplayActions()
        {
            // Pin Camera
            ImGui.PushID(0);
            if(ImGui.ImageButton(_uiState.Img_Pin(), ButtonSize))
            {
                _uiState.Camera.PinToEntity(Entity);
            }
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip(GlobalUIState.NamesForMenus[typeof(PinCameraBlankMenuHelper)]);
            ImGui.PopID();

            if(Entity.HasDataBlob<VolumeStorageDB>())
            {
                // Cargo Transfer
                ImGui.PushID(1);
                ImGui.SameLine();
                if(ImGui.ImageButton(_uiState.Img_Cargo(), ButtonSize))
                {
                    var instance = CargoTransfer.GetInstance(_uiState.Faction.GetDataBlob<FactionInfoDB>().Data, EntityState);
                    instance.ToggleActive();
                    _uiState.ActiveWindow = instance;
                }
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip(GlobalUIState.NamesForMenus[typeof(CargoTransfer)]);
                ImGui.PopID();
            }

            if(Entity.HasDataBlob<FireControlAbilityDB>())
            {
                // Fire Control
                ImGui.PushID(2);
                ImGui.SameLine();
                if(ImGui.ImageButton(_uiState.Img_Firecon(), ButtonSize))
                {
                    var instance = FireControl.GetInstance(EntityState);
                    instance.SetActive(true);
                    _uiState.ActiveWindow = instance;
                }
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip(GlobalUIState.NamesForMenus[typeof(FireControl)]);
                ImGui.PopID();
            }

            if(Entity.HasDataBlob<ColonyInfoDB>())
            {
                // Colony
                ImGui.PushID(3);
                ImGui.SameLine();
                if(ImGui.ImageButton(_uiState.Img_Industry(), ButtonSize))
                {
                    var instance = ColonyPanel.GetInstance(_uiState.Faction.GetDataBlob<FactionInfoDB>().Data, EntityState);
                    instance.SetActive(true);
                    _uiState.ActiveWindow = instance;
                }
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip("Open Industry");
                ImGui.PopID();
            }

            if(Entity.HasDataBlob<WarpAbilityDB>())
            {
                ImGui.SameLine();
                bool buttonresult = ImGui.SmallButton(GlobalUIState.NamesForMenus[typeof(WarpOrderWindow)]);
                EntityUIWindows.OpenUIWindow(typeof(WarpOrderWindow), EntityState, _uiState, buttonresult);
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip("Open warp menu");
            }

            if(Entity.HasDataBlob<NewtonThrustAbilityDB>())
            {
                ImGui.SameLine();
                bool buttonresult = ImGui.SmallButton(GlobalUIState.NamesForMenus[typeof(ChangeCurrentOrbitWindow)]);
                EntityUIWindows.OpenUIWindow(typeof(ChangeCurrentOrbitWindow), EntityState, _uiState, buttonresult);
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip("Change current orbit");

                ImGui.SameLine();
                buttonresult = ImGui.SmallButton(GlobalUIState.NamesForMenus[typeof(NavWindow)]);
                EntityUIWindows.OpenUIWindow(typeof(NavWindow), EntityState, _uiState, buttonresult);
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip("Open nav window");
            }

            if(EntityState.BodyType != UserOrbitSettings.OrbitBodyType.Ship)
            {
                ImGui.SameLine();
                bool buttonresult = ImGui.SmallButton(GlobalUIState.NamesForMenus[typeof(PlanetaryWindow)]);
                EntityUIWindows.OpenUIWindow(typeof(PlanetaryWindow), EntityState, _uiState, buttonresult);
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip("Open planetary window");
            }

            if(Entity.HasDataBlob<VolumeStorageDB>() && Entity.HasDataBlob<NewtonThrustAbilityDB>())
            {
                ImGui.SameLine();
                bool buttonresult = ImGui.SmallButton(GlobalUIState.NamesForMenus[typeof(LogiShipWindow)]);
                EntityUIWindows.OpenUIWindow(typeof(LogiShipWindow), EntityState, _uiState, buttonresult);
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip("Open logistics window");
            }
        }

        private void DisplayInfoTab()
        {
            if(ImGui.BeginTabItem("Info"))
            {
                if(Entity.HasDataBlob<ShipInfoDB>() && Entity.HasDataBlob<VolumeStorageDB>())
                {
                    var cargoLibrary = Entity.GetFactionOwner.GetDataBlob<FactionInfoDB>().Data.CargoGoods;
                    var (fuelType, fuelPercent) = Entity.GetFuelInfo(cargoLibrary);
                    var size = ImGui.GetContentRegionAvail();
                    ImGui.PushStyleColor(ImGuiCol.PlotHistogram, Styles.SelectedColor);
                    ImGui.ProgressBar((float)fuelPercent, new Vector2(size.X, 24), "Fuel (" + (fuelPercent * 100) + "%)");
                    ImGui.PopStyleColor();
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.SetTooltip(fuelType?.Name ?? "Unknown");
                    }
                }

                if(Entity.HasDataBlob<SystemBodyInfoDB>())
                {
                    ImGui.Text("Body Type: " + Entity.GetDataBlob<SystemBodyInfoDB>().BodyType.ToDescription());
                }

                if(Entity.HasDataBlob<MassVolumeDB>())
                {
                    MassVolumeDB mvDb = Entity.GetDataBlob<MassVolumeDB>();
                    ImGui.Text("Radius: " + Stringify.Distance(mvDb.RadiusInM));
                    ImGui.Text("Mass: " + Stringify.Mass(mvDb.MassTotal));
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.SetTooltip("Dry: " + Stringify.Mass(mvDb.MassDry));
                    }
                    ImGui.Text("Volume: " + Stringify.Volume(mvDb.Volume_m3));
                    ImGui.Text("Density: " + mvDb.DensityDry_gcm.ToString("##0.000") + " kg/m^3");
                }

                if(Entity.TryGetDatablob<PositionDB>(out var positionDB))
                {
                    Entity? parent = positionDB.Parent;
                    if(parent != null)
                    {
                        if (Entity.TryGetDatablob<WarpMovingDB>(out var movedb))
                        {
                            ImGui.Text("Warping " + Stringify.Velocity(movedb.CurrentNonNewtonionVectorMS.Length()));

                        }
                        else
                            ImGui.Text("Orbiting: ");
                        ImGui.SameLine();
                        if(ImGui.SmallButton(parent.GetName(_uiState.Faction.Id)))
                        {
                            _uiState.EntityClicked(parent.Id, _uiState.SelectedStarSysGuid, MouseButtons.Primary);
                        }
                    }
                    // if(positionDB.Children.Count > 0)
                    // {
                    //     ImGui.Text("Children:");
                    //     foreach(var child in positionDB.Children.ToArray())
                    //     {
                    //         if(ImGui.SmallButton(child.GetName(_uiState.Faction.Id)))
                    //         {
                    //             _uiState.EntityClicked(child.Id, _uiState.SelectedStarSysGuid, MouseButtons.Primary);
                    //         }
                    //     }
                    // }
                }

                if(Entity.HasDataBlob<ColonyInfoDB>())
                {
                    Entity.GetDataBlob<ColonyInfoDB>().Display(EntityState, _uiState);
                }

                ImGui.EndTabItem();
            }
        }

        private void DisplayConditionalTabs()
        {
            if(Entity.Manager == null) return;

            bool isGeoSurveyed = Entity.HasDataBlob<GeoSurveyableDB>() ? Entity.GetDataBlob<GeoSurveyableDB>().IsSurveyComplete(_uiState.Faction.Id) : false;

            foreach(var db in Entity.Manager.GetAllDataBlobsForEntity(Entity.Id))
            {
                if(isGeoSurveyed && db is AtmosphereDB && ImGui.BeginTabItem("Atmosphere"))
                {
                    ((AtmosphereDB)db).Display(EntityState, _uiState);
                    ImGui.EndTabItem();
                }
                else if(isGeoSurveyed && db is MineralsDB && ImGui.BeginTabItem("Minerals"))
                {
                    ((MineralsDB)db).Display(EntityState, _uiState);
                    ImGui.EndTabItem();
                }
                else if(db is StarInfoDB && ImGui.BeginTabItem("Star Info"))
                {
                    ((StarInfoDB)db).Display(EntityState, _uiState);
                    ImGui.EndTabItem();
                }
                else if(db is ComponentInstancesDB && ImGui.BeginTabItem("Components"))
                {
                    ((ComponentInstancesDB)db).Display(EntityState, _uiState);
                    ImGui.EndTabItem();
                }
                else if(db is VolumeStorageDB && ImGui.BeginTabItem("Storage"))
                {
                    ((VolumeStorageDB)db).Display(EntityState, _uiState);
                    ImGui.EndTabItem();
                }
                else if(db is EnergyGenAbilityDB && ImGui.BeginTabItem("Power"))
                {
                    ((EnergyGenAbilityDB)db).Display(EntityState, _uiState);
                    ImGui.EndTabItem();
                }
                else if(db is FleetDB && ImGui.BeginTabItem("Ships"))
                {
                    ImGui.EndTabItem();
                }
            }

            // Mining tab
            if(Entity.CanShowMiningTab())
            {
                if(ImGui.BeginTabItem("Mining"))
                {
                    Entity.DisplayMining(_uiState);
                    ImGui.EndTabItem();
                }
            }
        }
    }
}