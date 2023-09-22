using System.ComponentModel;
using System;

namespace Pulsar4X.DataStructures
{
    public enum BodyType : byte
    {
        [Description("?")]
        Unknown,

        [Description("Terrestrial Planet")]
        Terrestrial,    // Like Earth/Mars/Venus/etc.

        [Description("Gas Giant")]
        GasGiant,       // Like Jupiter/Saturn

        [Description("Ice Giant")]
        IceGiant,       // Like Uranus/Neptune

        [Description("Dwarf Planet")]
        DwarfPlanet,    // Pluto!

        [Description("Gas Dwarf")]
        GasDwarf,       // What you'd get is Jupiter and Saturn ever had a baby.

        /// @TODO: Add more planet types like
        ///     Ice Planets (bigger Plutos),
        ///     carbon planet (http://en.wikipedia.org/wiki/Carbon_planet),
        ///     Iron SystemBody (http://en.wikipedia.org/wiki/Iron_planet) or
        ///     Lava Planets (http://en.wikipedia.org/wiki/Lava_planet).
        ///     (more: http://en.wikipedia.org/wiki/List_of_planet_types).

        [Description("Moon")]
        Moon,

        [Description("Asteroid")]
        Asteroid,

        [Description("Comet")]
        Comet
    }

    public enum TectonicActivity : byte
    {
        [Description("?")]
        Unknown,

        [Description("Dead")]
        Dead,

        [Description("Minor")]
        Minor,

        [Description("Earth-like")]
        EarthLike,

        [Description("Major")]
        Major,

        [Description("Not-Applicable")]
        NA
    }

    public enum SpectralType : byte
    {
        O,
        B,
        A,
        F,
        G,
        K,
        M,
        D,
        C
    }

    public enum LuminosityClass : byte
    {
        [Description("Hypergiant")]
        O,

        [Description("Luminous Supergiant")]
        Ia,

        [Description("Intermediate Supergiant")]
        Iab,

        [Description("Less Luminous Supergiant")]
        Ib,

        [Description("Bright Giant")]
        II,

        [Description("Giant")]
        III,

        [Description("Subgiant")]
        IV,

        [Description("Main-Sequence")]
        V,

        [Description("Sub-Dwarf")]
        sd,

        [Description("White Dwarf")]
        D,
    }

    public enum ResearchCategories
    {
        BiologyGenetics,
        ConstructionProduction,
        DefensiveSystems,
        EnergyWeapons,
        LogisticsGroundCombat,
        MissilesKineticWeapons,
        PowerAndPropulsion,
        SensorsAndFireControl,
        FromStaticData00,
        FromStaticData01,
        FromStaticData02,
        FromStaticData03,
        FromStaticData04,
        FromStaticData05,
        FromStaticData06,
        FromStaticData07,
        FromStaticData08,
        FromStaticData09,
    }

    public enum SystemBand
    {
        InnerBand,
        HabitableBand,
        OuterBand,
    }

    public enum ConstructableGuiHints
    {
        None,
        CanBeLaunched,
        CanBeInstalled,
        IsOrdinance
    }

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

    [Flags]
    public enum GuiHint
    {
        None = 1,
        GuiDisplayBool = 2,
        GuiTechSelectionList = 4,
        GuiSelectionMaxMin = 8,
        GuiTextDisplay = 16,
        GuiEnumSelectionList = 32,
        GuiOrdnanceSelectionList = 64,
        GuiTextSelectionFormula = 128,
        GuiSelectionMaxMinInt = 256,
        GuiFuelTypeSelection = 512,
    }

    public enum PulseActionEnum
    {
        JumpOutProcessor,
        JumpInProcessor,
        EconProcessor,
        OrbitProcessor,
        OrderProcessor,
        BalisticMoveProcessor,
        MoveOnlyProcessor,
        SomeOtherProcessor
    }

    public enum IndustryJobStatus
    {
        Queued,
        MissingResources,
        Processing,
        Completed,
    }
}