﻿using System;
using ImGuiNET;
using System.Numerics;
using Pulsar4X.Engine;
using Vector2 = System.Numerics.Vector2;

namespace Pulsar4X.SDL2UI
{
    public class MainMenuItems : PulsarGuiWindow
    {

        bool _saveGame = false;
        System.Numerics.Vector2 buttonSize = new System.Numerics.Vector2(184, 24);
        new ImGuiWindowFlags _flags = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoTitleBar;
        private MainMenuItems(){}
        internal static MainMenuItems GetInstance()
        {
            if (!_uiState.LoadedWindows.ContainsKey(typeof(MainMenuItems)))
            {
                return new MainMenuItems();
            }
            return (MainMenuItems)_uiState.LoadedWindows[typeof(MainMenuItems)];
        }


        internal override void Display()
        {
            if (IsActive)
            {
                System.Numerics.Vector2 size = new System.Numerics.Vector2(200, 100);
                System.Numerics.Vector2 pos = new System.Numerics.Vector2(_uiState.MainWinSize.X / 2 - size.X / 2, _uiState.MainWinSize.Y / 2 - size.Y / 2);
                ImGui.SetNextWindowSize(size, ImGuiCond.FirstUseEver);
                ImGui.SetNextWindowPos(pos, ImGuiCond.Always);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(10, 10));
                if (ImGui.Begin("Pulsar4X Main Menu", ref IsActive, _flags))
                {

                    if (ImGui.Button("Start a New Game", buttonSize) || _uiState.debugnewgame)
                    {
                        //_uiState.NewGameOptions.IsActive = true;
                        var newgameoptions = NewGameOptions.GetInstance();
                        newgameoptions.SetActive(true);
                        this.IsActive = false;
                    }
                    if (_uiState.IsGameLoaded)
                    {
                        ImGui.BeginDisabled();
                        if (ImGui.Button("Save Current Game", buttonSize))
                        {
                            _saveGame = !_saveGame;

                            // FIXME:
                            //SerializationManager.Export(_uiState.Game, "SaveGame");
                        }
                        ImGui.EndDisabled();
                        if (ImGui.Button("Options", buttonSize))
                        {
                            SettingsWindow.GetInstance().ToggleActive();
                            this.SetActive(false);
                        }
                    }
                    ImGui.Button("Resume a Current Game", buttonSize);
                    ImGui.Button("Connect to a Network Game", buttonSize);
                }

                if (ImGui.Button("SM Mode", buttonSize))
                {
                    var pannel = SMPannel.GetInstance();
                    _uiState.ActiveWindow = pannel;
                    pannel.SetActive();
                    _uiState.ToggleGameMaster();
                    this.IsActive = false;
                }

                if(ImGui.Button("Exit to Desktop", buttonSize))
                {
                    _uiState.ViewPort.IsAlive = false;
                }

                ImGui.End();
                ImGui.PopStyleVar();
            }
        }

        public override void OnGameTickChange(DateTime newDate)
        {
        }

        public override void OnSystemTickChange(DateTime newDate)
        {
        }

        public override void OnSelectedSystemChange(StarSystem newStarSys)
        {
            throw new NotImplementedException();
        }
    }
}
