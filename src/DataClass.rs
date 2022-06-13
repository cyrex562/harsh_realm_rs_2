// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DataClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsApplication1
{
  [Serializable]
  pub class DataClass : ISerializable
  {
    pub const int CONSTVERSION = 424;
    pub const CONSTSUBVERSION: String = ".04b";
    pub const CONSTFILEEXTENSIONSLOAD: String = "SE1 Scenario file (*.se1)|*.se1";
    pub const CONSTFILEEXTENSIONSSAVE: String = "SE1 Scenario file (*.se1)|*.se1";
    pub const CONSTFILEEXTENSIONAUTOSAVE: String = ".se1";
    pub const int CONSTVERSIONDISPLAYMINUS = 314;
    pub const CONSTFILEEXTENSTIONLOADMAP: String = "SE1 Map file(*.se1map)|*.se1map";
    pub const CONSTFILEEXTENSIONEVENTLIB: String = "SE1 Event library(*.se1evlib)|*.se1evlib";
    pub const CONSTFILEEXTENSIONTROOPSLIB: String = "SE1 Troops&Equipment library(*.se1troops)|*.se1troops";
    pub const CONSTFILEEXTENSIONHISTORICALLIB: String = "SE1 Historical library(*.se1his)|*.se1his";
    pub const CONSTFILEEXTENSIONOFFICERLIB: String = "SE1 Officer library(*.se1off)|*.se1off";
    pub const CONSTFILEEXTENSIONOFFICERCARDLIB: String = "SE1 Officer Card Library(*.se1offcard)|*.se1offcard";
    pub const CONSTFILEEXTENSIONLOADANYLIB: String = "SE1 Scenario file (*.se1)|*.se1|SE1 Map file(*.se1map)|*.se1map|SE1 Master file(*.se1master)|*.se1master|SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off";
    pub const CONSTFILEEXTENSIONLOADLIB: String = "SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off";
    pub const CONSTFILEEXTENSIONLOADMASTER: String = "SE1 Master file(*.se1master)|*.se1master";
    pub const CONSTSHORTLOADMAP: String = ".se1map";
    pub const CONSTSHORTEVENTLIB: String = ".se1evlib";
    pub const CONSTSHORTTROOPSLIB: String = ".se1troops";
    pub const CONSTSHORTHISTORICALLIB: String = ".se1his";
    pub const CONSTSHORTOFFICERLIB: String = ".se1off";
    pub const CONSTSHORTOFFICERCARDLIB: String = ".se1offcard";
    pub const CONSTSHORTMASTER: String = ".se1master";
    pub const CONSTPREINSTALLEDGFXDIR: String = "shadow";
    pub Name: String;
    pub Product: i32;
    pub Description: String;
    pub Designer: String;
    pub Designer2: String;
    pub Round: i32;
    pub Version: i32;
    pub Turn: i32;
    pub InTurn: bool;
    pub StepNr: i32;
    pub int[] GameSlot;
    pub string[] GameSlotName;
    pub bool[] GameSlotShow;
    pub bool[] GameSlotShow2;
    pub string[] RegimeSlotName;
    pub bool[] RegimeSlotShow;
    pub int[] RegimeSlotShow2;
    pub int[] RegimeSlotNato;
    pub int[] RegimeSlotSmallGfx;
    pub string[] RealTempString;
    pub int[] GameSlotNato;
    pub int[] GameSlotSmallGfx;
    pub const int Slotcounter = 499;
    pub ShrowdOn: bool;
    pub FOWOn: bool;
    pub UncertaintyOn: bool;
    pub ASOn: bool;
    pub ResMod: i32;
    pub LoadPass: String;
    pub EditPass: String;
    pub MasterFile: String;
    pub Winner: i32;
    pub LastWinner: i32;
    pub VPWin: i32;
    pub PasswordsOn: bool;
    pub PBEM: bool;
    pub ScreenShotOn: bool;
    pub CreatedWithShrowd: bool;
    pub ShrowdPeek: bool;
    pub AutoSave: bool;
    pub Verify1: bool;
    pub Verify2: bool;
    pub MapCounter: i32;
    pub MapClass[] MapObj;
    pub LibraryCounter: i32;
    pub LibraryClass[] LibraryObj;
    pub LibVarCounter: i32;
    pub LibVarClass[] LibVarObj;
    pub MapWidth: i32;
    pub MapHeight: i32;
    pub HexClass[,] HexObj;
    pub LandscapeTypeCounter: i32;
    pub LandscapeTypeClass[] LandscapeTypeObj;
    pub RoadTypeCounter: i32;
    pub RoadTypeClass[] RoadTypeObj;
    pub RegimeCounter: i32;
    pub RegimeClass[] RegimeObj;
    pub RegimeIdCounter: i32;
    pub UnitCounter: i32;
    pub UnitClass[] UnitObj;
    pub SFCounter: i32;
    pub SFClass[] SFObj;
    pub SFTypeCounter: i32;
    pub SFTypeClass[] SFTypeObj;
    pub SFTypeIdCounter: i32;
    pub LocTypeCounter: i32;
    pub LocationTypeClass[] LocTypeObj;
    pub LocCounter: i32;
    pub LocationClass[] LocObj;
    pub object LocIdCounter;
    pub ItemTypeCounter: i32;
    pub ItemTypeClass[] ItemTypeObj;
    pub PeopleCounter: i32;
    pub PeopleClass[] PeopleObj;
    pub PeopleIdCounter: i32;
    pub StringCounter: i32;
    pub string[] TempString;
    pub float[] RuleVar;
    pub string[] RuleString;
    pub int[] RuleGroup;
    pub int[] RuleGroup2;
    pub RuleCounter: i32;
    pub RiverTypeCounter: i32;
    pub RiverTypeClass[] RiverTypeObj;
    pub AreaCounter: i32;
    pub AreaClass[] AreaObj;
    pub AreaIDCounter: i32;
    pub HistoricalUnitCounter: i32;
    pub HistoricalUnitClass[] HistoricalUnitObj;
    pub HistoricalIDCounter: i32;
    pub BridgeClass[] BridgeObj;
    pub ActionCardCounter: i32;
    pub ActionCardClass[] ActionCardObj;
    pub ResearchCounter: i32;
    pub ResearchClass[] ResearchObj;
    pub EventCounter: i32;
    pub EventClass[] EventObj;
    pub EventIdCounter: i32;
    pub EventPicCounter: i32;
    pub string[] EventPicName;
    pub int[] EventPicNr;
    pub LibIdClass[] eventPicLibId;
    pub SmallPicCounter: i32;
    pub string[] SmallPicName;
    pub int[] SmallPicNr;
    pub LibIdClass[] SmallLibId;
    pub reinfIdCounter: i32;
    pub ReinfCounter: i32;
    pub string[] ReinfName;
    pub LibIdClass[] ReinfLibId;
    pub int[] ReinfId;
    pub StringListCounter: i32;
    pub StringListClass[] StringListObj;
    pub StringIDCounter: i32;
    pub string[] CheckTypeNames;
    pub string[] ExecTypeNames;
    pub string[,] CheckTypeVarName;
    pub int[] CheckTypeVarCount;
    pub CheckTypeCount: i32;
    pub string[] CheckDesc;
    pub int[] CheckCategory;
    pub int[] CheckCategory2;
    pub int[] ExecCategory;
    pub int[] ExecCategory2;
    pub string[,] ExecTypeVarName;
    pub int[] ExecTypeVarCount;
    pub string[] ExecDesc;
    pub ExecTypeCount: i32;
    pub int[] ExecTypeString;
    pub int[] TempVar;
    pub string[] ExecCategoryName;
    pub string[] CheckCategoryName;
    pub AlternateRound: i32;
    pub AlternateRound2: i32;
    pub DateTime StartData;
    pub float PPMultiplier;
    pub float SupplyMultiplier;
    pub float ResCostMod;
    pub NoPlayChoice: bool;
    pub NoAIAdvice: bool;
    pub int[] Variants;
    pub int[] VariantEvent;
    pub const int MoveGroup1 = 0;
    pub const int MoveGroup2 = 99;
    pub const int LandscapeGroup1 = 100;
    pub const int LandscapeGroup2 = 199;
    pub const int PeopleGroup1 = 200;
    pub const int PeopleGroup2 = 299;
    pub const int ItemGroup1 = 300;
    pub const int ItemGroup2 = 399;
    pub const int SFTypeGroup1 = 400;
    pub const int SFTypeGroup2 = 499;
    pub const int LocTypeGroup1 = 500;
    pub const int LocTypeGroup2 = 599;
    pub int[] MoveTypePenalty;
    pub int[] UnitTypePenalty;
    pub int[] WheaterColor;
    pub MasterfileReadPeople: bool;
    pub MapLoop: bool;
    pub int[] ReinfRatio;
    pub GameID: i32;
    pub TerrorMode: bool;
    pub DontShowAIMove: bool;
    pub LoadGame: String;
    pub UseAI: i32;
    pub CampaignRoom: i32;
    pub SystemGfx: String;
    pub ScenarioDir: String;
    pub SoundDir: String;
    pub SFModelIDCounter: i32;
    pub TurnString: String;
    pub Loadable: bool;
    pub specialSaveMode: i32;
    pub RuleSetName: String;
    pub DoAllied: bool;
    pub PermanentOverlayUse: bool;
    pub PermanentOverlayName: String;
    pub PermanentOverlaySpriteID: i32;
    pub PbemGameID: i32;
    pub PbemPlayer1: String;
    pub PbemPlayer2: String;
    pub PbemGameOver: i32;
    pub PbemDrawGame: i32;
    pub AIUnitCounter: i32;
    pub SimpleEditor: bool;
    pub ExtraTabName: String;
    pub ExtraTabEvent: i32;
    pub ExtraTabName2: String;
    pub ExtraTabEvent2: i32;
    pub ExtraTabName3: String;
    pub ExtraTabEvent3: i32;
    pub ExtraTabName4: String;
    pub ExtraTabEvent4: i32;
    pub MapName: String;
    pub MapVersion: i32;
    pub MapDesigner: String;
    pub CombatLogId: i32;
    pub scenarioVersion: String;
    pub scenarioVersionMaster: String;
    pub int[] transportMovementType;
    pub se1_earlyCinematicsLogin: i32;

    pub int GetLibVarUseId(int libVarId, int slotId)
    {
      int index = slotId;
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.Hex || this.LibVarObj[libVarId].type == NewEnums.LibVarType.General)
        return libVarId;
      int num1 = -1;
      int num2 = -1;
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.HistoricalUnit)
      {
        num2 = this.HistoricalUnitObj[index].LibId.libSlot;
        num1 = this.HistoricalUnitObj[index].LibId.id;
        if (num1 == -1)
          num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.HistoricalUnitModel)
      {
        num2 = this.HistoricalUnitObj[index].LibId.libSlot;
        num1 = this.HistoricalUnitObj[index].LibId.id;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.Officer)
      {
        if (this.HistoricalUnitObj[index].OffLibId.id > -1)
        {
          num2 = this.HistoricalUnitObj[index].OffLibId.libSlot;
          num1 = this.HistoricalUnitObj[index].OffLibId.id;
        }
        else
        {
          num2 = this.HistoricalUnitObj[index].LibId.libSlot;
          num1 = this.HistoricalUnitObj[index].LibId.id;
        }
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.Landscape)
      {
        num2 = -1;
        num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.LocationType)
      {
        num2 = -1;
        num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.People)
      {
        num2 = this.PeopleObj[index].LibId.libSlot;
        num1 = this.PeopleObj[index].LibId.id;
        if (num1 == -1)
          num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.Regime)
      {
        num2 = this.RegimeObj[index].libId.libSlot;
        num1 = this.RegimeObj[index].libId.id;
        if (num1 == -1)
          num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.River)
      {
        num2 = -1;
        num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.Road)
      {
        num2 = -1;
        num1 = index;
      }
      if (this.LibVarObj[libVarId].type == NewEnums.LibVarType.SFtype)
      {
        num2 = this.SFTypeObj[index].LibId.libSlot;
        num1 = this.SFTypeObj[index].LibId.id;
        if (num1 == -1)
          num1 = index;
      }
      if (index > -1)
      {
        int libVarCounter = this.LibVarCounter;
        for (int libVarUseId = 0; libVarUseId <= libVarCounter; libVarUseId += 1)
        {
          if (this.LibVarObj[libVarId].libId.libSlot == this.LibVarObj[libVarUseId].libId.libSlot && Operators.CompareString(this.LibVarObj[libVarId].name, this.LibVarObj[libVarUseId].name, false) == 0 && num2 == this.LibVarObj[libVarUseId].instanceId.libSlot && num1 == this.LibVarObj[libVarUseId].instanceId.id)
            return libVarUseId;
        }
      }
      return libVarId;
    }

    pub DataClass(int twidth = 25, int theight = 25, bool DontLoadGraphics = false)
    {
      this.GameSlot = new int[500];
      this.GameSlotName = new string[500];
      this.GameSlotShow = new bool[500];
      this.GameSlotShow2 = new bool[500];
      this.RegimeSlotName = new string[500];
      this.RegimeSlotShow = new bool[500];
      this.RegimeSlotShow2 = new int[500];
      this.RegimeSlotNato = new int[500];
      this.RegimeSlotSmallGfx = new int[500];
      this.RealTempString = new string[1000];
      this.GameSlotNato = new int[500];
      this.GameSlotSmallGfx = new int[500];
      this.MapObj = new MapClass[1];
      this.LibraryObj = new LibraryClass[1];
      this.LibVarObj = new LibVarClass[1];
      this.HexObj = new HexClass[1, 1];
      this.LandscapeTypeObj = new LandscapeTypeClass[1];
      this.RoadTypeObj = new RoadTypeClass[1];
      this.RegimeObj = new RegimeClass[1];
      this.UnitObj = new UnitClass[1];
      this.SFObj = new SFClass[1];
      this.SFTypeObj = new SFTypeClass[1];
      this.LocTypeObj = new LocationTypeClass[1];
      this.LocObj = new LocationClass[1];
      this.ItemTypeObj = new ItemTypeClass[1];
      this.PeopleObj = new PeopleClass[1];
      this.StringCounter = 1500;
      this.TempString = new string[1501];
      this.RuleVar = new float[1001];
      this.RuleString = new string[1001];
      this.RuleGroup = new int[1001];
      this.RuleGroup2 = new int[1001];
      this.RuleCounter = 1000;
      this.RiverTypeObj = new RiverTypeClass[1];
      this.AreaObj = new AreaClass[1];
      this.HistoricalUnitObj = new HistoricalUnitClass[1];
      this.BridgeObj = new BridgeClass[1];
      this.ActionCardObj = new ActionCardClass[1];
      this.ResearchObj = new ResearchClass[1];
      this.EventObj = new EventClass[1];
      this.EventPicName = new string[1];
      this.EventPicNr = new int[1];
      this.eventPicLibId = new LibIdClass[1];
      this.SmallPicName = new string[1];
      this.SmallPicNr = new int[1];
      this.SmallLibId = new LibIdClass[1];
      this.ReinfName = new string[1];
      this.ReinfLibId = new LibIdClass[1];
      this.ReinfId = new int[1];
      this.StringListObj = new StringListClass[1];
      this.CheckTypeNames = new string[400];
      this.ExecTypeNames = new string[400];
      this.CheckTypeVarName = new string[300, 5];
      this.CheckTypeVarCount = new int[300];
      this.CheckDesc = new string[300];
      this.CheckCategory = new int[300];
      this.CheckCategory2 = new int[300];
      this.ExecCategory = new int[400];
      this.ExecCategory2 = new int[400];
      this.ExecTypeVarName = new string[400, 5];
      this.ExecTypeVarCount = new int[400];
      this.ExecDesc = new string[400];
      this.ExecTypeString = new int[400];
      this.TempVar = new int[1000];
      this.ExecCategoryName = new string[100];
      this.CheckCategoryName = new string[100];
      this.Variants = new int[12];
      this.VariantEvent = new int[12];
      this.MoveTypePenalty = new int[100];
      this.UnitTypePenalty = new int[100];
      this.WheaterColor = new int[3];
      this.ReinfRatio = new int[50];
      this.transportMovementType = new int[100];
      this.se1_earlyCinematicsLogin = 0;
      this.UncertaintyOn = false;
      this.Name = "New Scenario";
      this.Description = "This is a blank scenario.";
      this.Round = 0;
      this.Turn = 0;
      this.scenarioVersion = "";
      this.scenarioVersionMaster = "";
      this.MapDesigner = "Unknown";
      this.MapName = "Unnamed";
      this.MapVersion = 1;
      this.se1_earlyCinematicsLogin = 0;
      this.PermanentOverlayName = "systemgraphics/trans.bmp";
      this.PermanentOverlayUse = false;
      this.Version = 424;
      this.ExtraTabName = "";
      this.ExtraTabEvent = -1;
      this.ExtraTabName2 = "";
      this.ExtraTabEvent2 = -1;
      this.ExtraTabName3 = "";
      this.ExtraTabEvent3 = -1;
      this.ExtraTabName4 = "";
      this.ExtraTabEvent4 = -1;
      this.LandscapeTypeCounter = 0;
      this.LandscapeTypeObj = new LandscapeTypeClass[this.LandscapeTypeCounter + 1];
      this.LandscapeTypeObj[0] = new LandscapeTypeClass(0);
      this.MapObj = new MapClass[1];
      this.MapCounter = 0;
      this.MapObj[0] = new MapClass(0, 0, twidth, theight);
      this.MapObj[0].MapWidth = twidth;
      this.MapObj[0].MapHeight = theight;
      this.HexObj = new HexClass[this.MapWidth + 1, this.MapHeight + 1];
      int mapWidth = this.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; index1 += 1)
      {
        int mapHeight = this.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; index2 += 1)
          this.MapObj[0].HexObj[index1, index2] = new HexClass(0, 0, 0);
      }
      this.RoadTypeCounter = 0;
      this.RoadTypeObj[0] = new RoadTypeClass(0);
      this.LibraryCounter = -1;
      this.LibVarCounter = -1;
      this.RegimeCounter = -1;
      this.UnitCounter = -1;
      this.SFCounter = -1;
      this.SFTypeCounter = -1;
      this.LocTypeCounter = -1;
      this.LocCounter = -1;
      this.ItemTypeCounter = -1;
      this.PeopleCounter = -1;
      this.ActionCardCounter = -1;
      this.ActionCardObj[0] = (ActionCardClass) null;
      this.RiverTypeCounter = 0;
      this.RiverTypeObj[0] = new RiverTypeClass(0);
      this.BridgeObj[0] = new BridgeClass(0);
      this.StringListCounter = -1;
      int index3 = 0;
      do
      {
        this.GameSlot[index3] = -1;
        this.GameSlotName[index3] = "Empty";
        this.RegimeSlotName[index3] = "Empty";
        this.GameSlotSmallGfx[index3] = -1;
        this.RegimeSlotSmallGfx[index3] = -1;
        index3 += 1;
      }
      while (index3 <= 499);
      this.ResearchCounter = -1;
      this.EventCounter = -1;
      this.EventPicCounter = -1;
      this.SmallPicCounter = -1;
      this.ReinfCounter = -1;
      this.HistoricalUnitCounter = -1;
      this.AreaCounter = -1;
      this.Winner = -1;
      this.LastWinner = -1;
      this.VPWin = -1;
      this.ASOn = true;
      this.ResCostMod = 1f;
      this.SupplyMultiplier = 1f;
      this.PPMultiplier = 1f;
      this.AlternateRound = -1;
      this.AlternateRound2 = -1;
      this.Turn = -1;
      int index4 = 0;
      do
      {
        this.Variants[index4] = -1;
        this.VariantEvent[index4] = -1;
        index4 += 1;
      }
      while (index4 <= 11);
      int index5 = 0;
      do
      {
        this.MoveTypePenalty[index5] = 100;
        this.UnitTypePenalty[index5] = 100;
        index5 += 1;
      }
      while (index5 <= 99);
      this.Designer = "";
      this.Designer2 = "";
      this.CampaignRoom = -1;
      this.MasterfileReadPeople = false;
      this.MapLoop = false;
      this.SetDefaultTempStrings();
      this.SetDefaultRules();
      this.SetEventNames();
      if (!DontLoadGraphics)
        this.LoadGraphics((Form1) null);
      int index6 = 0;
      do
      {
        this.ReinfRatio[index6] = 1;
        index6 += 1;
      }
      while (index6 <= 49);
      int index7 = 0;
      do
      {
        this.transportMovementType[index7] = 0;
        index7 += 1;
      }
      while (index7 <= 99);
      this.RuleVar[839] = 1f;
      this.RuleVar[501] = 1f;
      this.RuleVar[503] = 1f;
      this.RuleVar[504] = 1f;
      this.RuleVar[506] = 1f;
      this.RuleVar[509] = 0.0f;
      this.RuleVar[510] = 1f;
      this.RuleVar[517] = 1f;
      this.RuleVar[513] = 1f;
      this.RuleVar[847] = 1f;
      this.RuleVar[518] = 1f;
      this.RuleVar[519] = 1f;
      this.RuleVar[524] = 0.0f;
      this.RuleVar[307] = 1f;
      this.RuleVar[530] = 0.0f;
      this.RuleVar[861] = 0.0f;
      this.RuleVar[862] = 0.0f;
      this.RuleVar[316] = 1f;
      this.RuleVar[317] = 1f;
      this.RuleVar[344] = 1f;
      this.RuleVar[843] = -1f;
      this.RuleVar[340] = -1f;
      this.RuleVar[337] = 1f;
      this.RuleVar[884] = 1f;
      this.RuleVar[143] = 10f;
      this.RuleVar[144] = 10f;
      this.RuleVar[145] = 10f;
      this.RuleVar[146] = 10f;
      this.RuleVar[339] = 250f;
      this.RuleVar[887] = 1f;
      this.UseAI = 1;
      this.MasterFile = "";
      this.EditPass = "";
      this.LoadPass = "";
      this.PbemGameID = 0;
      this.PbemPlayer1 = "";
      this.PbemPlayer2 = "";
      this.PbemGameOver = 0;
      this.Product = 7;
      this.HistoricalIDCounter = 0;
    }

    pub void SetEventNames()
    {
      this.CheckCategoryName[1] = "Game & Map globals";
      this.CheckCategoryName[2] = "Regimes";
      this.CheckCategoryName[3] = "Logic & Calculations";
      this.CheckCategoryName[4] = "Hex & Areaslots";
      this.CheckCategoryName[5] = "Unit";
      this.CheckCategoryName[6] = "Stringlist";
      this.CheckCategoryName[7] = "SFType/ItemTypes";
      this.CheckCategoryName[8] = "DC1 AI";
      this.CheckCategoryName[9] = "DC2 AI";
      this.CheckCategoryName[10] = "Library Checks";
      this.CheckCategoryName[11] = "UDS";
      this.CheckCategoryName[12] = "Random Related";
      this.CheckTypeNames[1] = "CheckTurn";
      this.CheckCategory[1] = 1;
      this.CheckTypeNames[2] = "CheckHexOwner";
      this.CheckTypeVarCount[2] = 2;
      this.CheckTypeVarName[2, 1] = "X";
      this.CheckTypeVarName[2, 2] = "Y";
      this.CheckCategory[2] = 4;
      this.CheckTypeNames[3] = "CheckRound";
      this.CheckCategory[3] = 1;
      this.CheckTypeNames[4] = "CheckRegimeMorale";
      this.CheckTypeVarCount[4] = 1;
      this.CheckTypeVarName[4, 1] = "RegimeNr";
      this.CheckCategory[4] = 2;
      this.CheckTypeNames[5] = "CheckWinner";
      this.CheckTypeVarCount[5] = 0;
      this.CheckCategory[5] = 1;
      this.CheckTypeNames[6] = "CheckWar";
      this.CheckTypeVarCount[6] = 2;
      this.CheckTypeVarName[6, 1] = "RegimeNr in Question";
      this.CheckTypeVarName[6, 2] = "Relation with RegimeNr";
      this.CheckCategory[6] = 2;
      this.CheckTypeNames[7] = "CheckPeace";
      this.CheckTypeVarCount[7] = 2;
      this.CheckTypeVarName[7, 1] = "RegimeNr in Question";
      this.CheckTypeVarName[7, 2] = "Relation with RegimeNr";
      this.CheckCategory[7] = 2;
      this.CheckTypeNames[8] = "CheckUnitsFrom";
      this.CheckTypeVarCount[8] = 4;
      this.CheckTypeVarName[8, 1] = "AreaSlot";
      this.CheckTypeVarName[8, 2] = "AreaCode";
      this.CheckTypeVarName[8, 3] = "RegimeNr";
      this.CheckTypeVarName[8, 4] = "Not From PeopleNr";
      this.CheckCategory[8] = 4;
      this.CheckTypeNames[10] = "CheckRandomPercent";
      this.CheckTypeVarCount[10] = 0;
      this.CheckCategory[10] = 3;
      this.CheckTypeNames[11] = "CheckLandscapeType";
      this.CheckTypeVarCount[11] = 2;
      this.CheckTypeVarName[11, 1] = "X";
      this.CheckTypeVarName[11, 2] = "Y";
      this.CheckCategory[11] = 4;
      this.CheckTypeNames[12] = "CheckLandscapeSprite";
      this.CheckTypeVarCount[12] = 2;
      this.CheckTypeVarName[12, 1] = "X";
      this.CheckTypeVarName[12, 2] = "Y";
      this.CheckCategory[12] = 4;
      this.CheckTypeNames[13] = "CheckSlot";
      this.CheckTypeVarCount[13] = 3;
      this.CheckTypeVarName[13, 1] = "X";
      this.CheckTypeVarName[13, 2] = "Y";
      this.CheckTypeVarName[13, 3] = "Slot#";
      this.CheckCategory[13] = 4;
      this.CheckTypeNames[14] = "CheckMapWidth";
      this.CheckTypeVarCount[14] = 0;
      this.CheckCategory[14] = 1;
      this.CheckTypeNames[15] = "CheckMapHeight";
      this.CheckTypeVarCount[15] = 0;
      this.CheckCategory[15] = 1;
      this.CheckTypeNames[16] = "CheckYear";
      this.CheckTypeVarCount[16] = 0;
      this.CheckCategory[16] = 1;
      this.CheckTypeNames[17] = "CheckMonth";
      this.CheckTypeVarCount[17] = 0;
      this.CheckCategory[17] = 1;
      this.CheckTypeNames[18] = "CheckDay";
      this.CheckTypeVarCount[18] = 0;
      this.CheckCategory[18] = 1;
      this.CheckTypeNames[19] = "CheckIfAI";
      this.CheckTypeVarCount[19] = 1;
      this.CheckTypeVarName[19, 1] = "Regime#";
      this.CheckCategory[19] = 2;
      this.CheckTypeNames[20] = "CheckPolPts";
      this.CheckTypeVarCount[20] = 1;
      this.CheckTypeVarName[20, 1] = "Regime#";
      this.CheckCategory[20] = 2;
      this.CheckTypeNames[21] = "CheckVP";
      this.CheckTypeVarCount[21] = 1;
      this.CheckTypeVarName[21, 1] = "Regime#";
      this.CheckCategory[21] = 2;
      this.CheckTypeNames[22] = "CheckDifferenceInDays";
      this.CheckTypeVarCount[22] = 3;
      this.CheckTypeVarName[22, 1] = "Year";
      this.CheckTypeVarName[22, 2] = "Month";
      this.CheckTypeVarName[22, 3] = "Day";
      this.CheckCategory[22] = 3;
      this.CheckTypeNames[23] = "CheckSupplyNeeded";
      this.CheckTypeVarCount[23] = 1;
      this.CheckTypeVarName[23, 1] = "Regime";
      this.CheckCategory[23] = 2;
      this.CheckTypeNames[24] = "CheckHQFor";
      this.CheckTypeVarCount[24] = 2;
      this.CheckTypeVarName[24, 1] = "X";
      this.CheckTypeVarName[24, 2] = "Y";
      this.CheckCategory[24] = 4;
      this.CheckTypeNames[27] = "CheckActionCard";
      this.CheckTypeVarCount[27] = 2;
      this.CheckTypeVarName[27, 1] = "Regime Owner";
      this.CheckTypeVarName[27, 2] = "Card Nr";
      this.CheckCategory[27] = 2;
      this.CheckTypeNames[28] = "CheckDipBlock";
      this.CheckTypeVarCount[28] = 1;
      this.CheckTypeVarName[28, 1] = "Regime#";
      this.CheckCategory[28] = 2;
      this.CheckTypeNames[29] = "CheckSleep";
      this.CheckTypeVarCount[29] = 1;
      this.CheckTypeVarName[29, 1] = "Regime#";
      this.CheckCategory[29] = 2;
      this.CheckTypeNames[30] = "CheckHistoricActionCard";
      this.CheckTypeVarCount[30] = 2;
      this.CheckTypeVarName[30, 1] = "Regime Owner";
      this.CheckTypeVarName[30, 2] = "Card Nr";
      this.CheckCategory[30] = 2;
      this.CheckTypeNames[31] = "CheckSFTypeInArea";
      this.CheckTypeVarCount[31] = 4;
      this.CheckTypeVarName[31, 1] = "AreaSlot";
      this.CheckTypeVarName[31, 2] = "AreaCode (-1=all hexes)";
      this.CheckTypeVarName[31, 3] = "SFType";
      this.CheckTypeVarName[31, 4] = "Regime";
      this.CheckCategory[31] = 4;
      this.CheckTypeNames[32] = "CheckPowerPointsInArea";
      this.CheckTypeVarCount[32] = 4;
      this.CheckTypeVarName[32, 1] = "AreaSlot";
      this.CheckTypeVarName[32, 2] = "AreaCode";
      this.CheckTypeVarName[32, 3] = "Regime";
      this.CheckTypeVarName[32, 4] = "Land only (0=no check, 1=land theater only)";
      this.CheckCategory[32] = 4;
      this.CheckTypeNames[33] = "CheckSFTypeInXY";
      this.CheckTypeVarCount[33] = 4;
      this.CheckTypeVarName[33, 1] = "X";
      this.CheckTypeVarName[33, 2] = "Y";
      this.CheckTypeVarName[33, 3] = "SFType (-1=all)";
      this.CheckTypeVarName[33, 4] = "Regime";
      this.CheckCategory[33] = 4;
      this.CheckTypeNames[34] = "CheckRegimeKills";
      this.CheckTypeVarCount[34] = 4;
      this.CheckTypeVarName[34, 1] = "Regime";
      this.CheckTypeVarName[34, 2] = "SFType (-1=all, 1000-10XX = SFTypeGroups 0-XX)";
      this.CheckTypeVarName[34, 3] = "Round (-1=all rounds)";
      this.CheckTypeVarName[34, 4] = "Report 0=qty, 1=power pts";
      this.CheckCategory[34] = 2;
      this.CheckTypeNames[35] = "CheckRegimeLosses";
      this.CheckTypeVarCount[35] = 4;
      this.CheckTypeVarName[35, 1] = "Regime";
      this.CheckTypeVarName[35, 2] = "SFType (-1=all, 1000-100X = SFTypeGroups 0-XX)";
      this.CheckTypeVarName[35, 3] = "Round (-1=all rounds)";
      this.CheckTypeVarName[35, 4] = "Report 0=qty, 1=power pts";
      this.CheckCategory[35] = 2;
      this.CheckTypeNames[36] = "CheckRegimeProduction";
      this.CheckTypeVarCount[36] = 4;
      this.CheckTypeVarName[36, 1] = "Regime";
      this.CheckTypeVarName[36, 2] = "SFType (-1=all)";
      this.CheckTypeVarName[36, 3] = "Round (-1=all rounds)";
      this.CheckTypeVarName[36, 4] = "Report 0=qty, 1=power pts";
      this.CheckCategory[36] = 2;
      this.CheckTypeNames[37] = "CheckRegimeCount";
      this.CheckTypeVarCount[37] = 0;
      this.CheckCategory[37] = 1;
      this.CheckTypeNames[38] = "CheckIfNeighbour";
      this.CheckTypeVarCount[38] = 4;
      this.CheckTypeVarName[38, 1] = "X";
      this.CheckTypeVarName[38, 2] = "Y";
      this.CheckTypeVarName[38, 3] = "X2";
      this.CheckTypeVarName[38, 4] = "Y2";
      this.CheckCategory[38] = 3;
      this.CheckTypeNames[39] = "CheckDistance";
      this.CheckTypeVarCount[39] = 4;
      this.CheckTypeVarName[39, 1] = "X";
      this.CheckTypeVarName[39, 2] = "Y";
      this.CheckTypeVarName[39, 3] = "X2";
      this.CheckTypeVarName[39, 4] = "Y2";
      this.CheckCategory[39] = 3;
      this.CheckTypeNames[40] = "CheckSFTypeGroupInXY";
      this.CheckTypeVarCount[40] = 4;
      this.CheckTypeVarName[40, 1] = "X";
      this.CheckTypeVarName[40, 2] = "Y";
      this.CheckTypeVarName[40, 3] = "SFType Group (-1=all)";
      this.CheckTypeVarName[40, 4] = "Regime";
      this.CheckCategory[40] = 4;
      this.CheckTypeNames[42] = "CheckAIThinkSpeed";
      this.CheckTypeVarCount[42] = 1;
      this.CheckTypeVarName[42, 1] = "Regime";
      this.CheckCategory[42] = 2;
      this.CheckDesc[42] = "Gives back the AI think speed level. 0=Normal, 100=Slow, 250=Very Slow. (in old AT this was the production bonus- if ever merge keep this in mind)";
      this.CheckTypeNames[43] = "CheckTotalUnits";
      this.CheckTypeVarCount[43] = 0;
      this.CheckCategory[43] = 5;
      this.CheckTypeNames[44] = "CheckUnitOwner";
      this.CheckTypeVarCount[44] = 1;
      this.CheckTypeVarName[44, 1] = "Unit Nr";
      this.CheckCategory[44] = 5;
      this.CheckTypeNames[45] = "CheckUnitHQ";
      this.CheckTypeVarCount[45] = 1;
      this.CheckTypeVarName[45, 1] = "Unit Nr";
      this.CheckCategory[45] = 5;
      this.CheckTypeNames[46] = "CheckUnitX";
      this.CheckTypeVarCount[46] = 1;
      this.CheckTypeVarName[46, 1] = "Unit Nr";
      this.CheckCategory[46] = 5;
      this.CheckTypeNames[47] = "CheckUnitY";
      this.CheckTypeVarCount[47] = 1;
      this.CheckTypeVarName[47, 1] = "Unit Nr";
      this.CheckCategory[47] = 5;
      this.CheckTypeNames[48] = "CheckUnitHistoricalID";
      this.CheckTypeVarCount[48] = 1;
      this.CheckTypeVarName[48, 1] = "Unit Nr";
      this.CheckCategory[48] = 5;
      this.CheckTypeNames[49] = "CheckUnitIsHQ";
      this.CheckTypeVarCount[49] = 1;
      this.CheckTypeVarName[49, 1] = "Unit Nr";
      this.CheckCategory[49] = 5;
      this.CheckTypeNames[50] = "CheckRegimeRelation";
      this.CheckTypeVarCount[50] = 2;
      this.CheckTypeVarName[50, 1] = "Reg1";
      this.CheckTypeVarName[50, 2] = "Reg2";
      this.CheckCategory[50] = 2;
      this.CheckDesc[50] = "Returns 0 for war, 1 for peace, 2 for alliance";
      this.CheckTypeNames[51] = "CheckUnitInHQChain";
      this.CheckTypeVarCount[51] = 2;
      this.CheckTypeVarName[51, 1] = "Unit Nr";
      this.CheckTypeVarName[51, 2] = "HQ Nr";
      this.CheckCategory[51] = 5;
      this.CheckTypeNames[52] = "CheckUnitCommanderStaffPercent";
      this.CheckTypeVarCount[52] = 1;
      this.CheckTypeVarName[52, 1] = "Unit Nr";
      this.CheckCategory[52] = 5;
      this.CheckTypeNames[53] = "CheckUnitHQPower";
      this.CheckTypeVarCount[53] = 1;
      this.CheckTypeVarName[53, 1] = "Unit Nr";
      this.CheckCategory[53] = 5;
      this.CheckTypeNames[54] = "CheckFirstUnitWithHistoricalID";
      this.CheckTypeVarCount[54] = 1;
      this.CheckTypeVarName[54, 1] = "Historical ID";
      this.CheckCategory[54] = 5;
      this.CheckTypeNames[55] = "CheckLocTypeXY";
      this.CheckTypeVarCount[55] = 2;
      this.CheckTypeVarName[55, 1] = "X";
      this.CheckTypeVarName[55, 2] = "Y";
      this.CheckCategory[55] = 4;
      this.CheckTypeNames[56] = "CheckStrucPtsXY";
      this.CheckTypeVarCount[56] = 2;
      this.CheckTypeVarName[56, 1] = "X";
      this.CheckTypeVarName[56, 2] = "Y";
      this.CheckCategory[56] = 4;
      this.CheckTypeNames[57] = "CheckClosestCommanderUnit";
      this.CheckTypeVarCount[57] = 3;
      this.CheckTypeVarName[57, 1] = "X";
      this.CheckTypeVarName[57, 2] = "Y";
      this.CheckTypeVarName[57, 3] = "Regime";
      this.CheckCategory[57] = 5;
      this.CheckTypeNames[58] = "CheckStringList";
      this.CheckTypeVarCount[58] = 3;
      this.CheckTypeVarName[58, 1] = "Stringlist ID";
      this.CheckTypeVarName[58, 2] = "Row";
      this.CheckTypeVarName[58, 3] = "Col";
      this.CheckCategory[58] = 6;
      this.CheckTypeNames[59] = "CheckStringReplace";
      this.CheckTypeVarCount[59] = 3;
      this.CheckTypeVarName[59, 1] = "From String";
      this.CheckTypeVarName[59, 2] = "Which substring";
      this.CheckTypeVarName[59, 3] = "Replace with what";
      this.CheckCategory[59] = 6;
      this.CheckTypeNames[60] = "CheckRegimeVar";
      this.CheckTypeVarCount[60] = 2;
      this.CheckTypeVarName[60, 1] = "Regime Nr";
      this.CheckTypeVarName[60, 2] = "Var Nr";
      this.CheckCategory[60] = 2;
      this.CheckTypeNames[61] = "CheckHistoricalUnitTempVar";
      this.CheckTypeVarCount[61] = 3;
      this.CheckTypeVarName[61, 1] = "Unit Nr (or -1 to use hist.)";
      this.CheckTypeVarName[61, 2] = "TempVar Nr (1-5), 6=AiZoneListNr";
      this.CheckTypeVarName[61, 3] = "Use Historical Unit ID";
      this.CheckCategory[61] = 5;
      this.CheckTypeNames[62] = "CheckCommanderDescript/Name";
      this.CheckTypeVarCount[62] = 3;
      this.CheckTypeVarName[62, 1] = "Unit Nr";
      this.CheckTypeVarName[62, 2] = "0=Descript, 1=Name";
      this.CheckTypeVarName[62, 3] = "HisUnit ID overrule (<=0 is no overrule)";
      this.CheckCategory[62] = 5;
      this.CheckTypeNames[63] = "CheckCommanderXP";
      this.CheckTypeVarCount[63] = 4;
      this.CheckTypeVarName[63, 1] = "Unit Nr (or -1)";
      this.CheckTypeVarName[63, 2] = "Overrule His Unit ID (or -1)";
      this.CheckTypeVarName[63, 3] = "0=Xp, 1=Total Cards, 2=Specific Card, 3=Total Ev, 4=Spec Ev";
      this.CheckTypeVarName[63, 4] = "Opt: card or ev#";
      this.CheckCategory[63] = 5;
      this.CheckTypeNames[64] = "CheckStringListRows";
      this.CheckTypeVarCount[64] = 1;
      this.CheckTypeVarName[64, 1] = "StringList ID";
      this.CheckCategory[64] = 6;
      this.CheckTypeNames[65] = "CheckStringListCols";
      this.CheckTypeVarCount[65] = 1;
      this.CheckTypeVarName[65, 1] = "StringList ID";
      this.CheckCategory[65] = 6;
      this.CheckTypeNames[66] = "CheckStringListLastID";
      this.CheckTypeVarCount[66] = 0;
      this.CheckCategory[66] = 6;
      this.CheckTypeNames[67] = "CheckUnitRdn";
      this.CheckTypeVarCount[67] = 1;
      this.CheckTypeVarName[67, 1] = "Unit#";
      this.CheckDesc[68] = "Keep in mind this is an average of the subformations.";
      this.CheckCategory[67] = 5;
      this.CheckTypeNames[68] = "CheckUnitSFType";
      this.CheckTypeVarCount[68] = 3;
      this.CheckTypeVarName[68, 1] = "Unit #";
      this.CheckTypeVarName[68, 2] = "SFType Group (-1 for none)";
      this.CheckTypeVarName[68, 3] = "Specific SFType (-1 for none)";
      this.CheckDesc[68] = "Returns the number of individuals in this unit";
      this.CheckCategory[68] = 5;
      this.CheckTypeNames[69] = "ReturnCRLF";
      this.CheckTypeVarCount[69] = 0;
      this.CheckCategory[69] = 3;
      this.CheckTypeNames[70] = "CheckUnitName";
      this.CheckTypeVarCount[70] = 1;
      this.CheckTypeVarName[70, 1] = "Unit#";
      this.CheckCategory[70] = 5;
      this.CheckTypeNames[71] = "CheckRegimeUnitsMorale";
      this.CheckTypeVarCount[71] = 1;
      this.CheckTypeVarName[71, 1] = "Reg";
      this.CheckCategory[71] = 2;
      this.CheckDesc[71] = "Returns the average morale of all units on map for this regime";
      this.CheckTypeNames[72] = "CheckRegimeUnitsExperience";
      this.CheckTypeVarCount[72] = 1;
      this.CheckTypeVarName[72, 1] = "Reg";
      this.CheckCategory[72] = 2;
      this.CheckDesc[72] = "Returns the average experience of all units on map for this regime";
      this.CheckTypeNames[73] = "CheckUnitTempOwner";
      this.CheckTypeVarCount[73] = 1;
      this.CheckTypeVarName[73, 1] = "Unit Nr";
      this.CheckCategory[73] = 5;
      this.CheckDesc[73] = "Returns the real owner. If this is a subregime it will actually give back the subregime regime # instead of the uberregime which the normal CheckUnitOwner will return.";
      this.ExecTypeNames[74] = "CheckPreDef";
      this.ExecTypeVarCount[74] = 1;
      this.ExecTypeVarName[74, 1] = "Predef#";
      this.ExecDesc[74] = "Returns unit# of this predef ID#.";
      this.ExecCategory[74] = 5;
      this.CheckTypeNames[75] = "CheckUnitPower";
      this.CheckTypeVarCount[75] = 1;
      this.CheckTypeVarName[75, 1] = "Unit Nr";
      this.CheckCategory[75] = 5;
      this.CheckDesc[75] = "Returns the real total power points in the unit.";
      this.CheckTypeNames[76] = "CheckSpecialType";
      this.CheckTypeVarCount[76] = 2;
      this.CheckTypeVarName[76, 1] = "X";
      this.CheckTypeVarName[76, 2] = "Y";
      this.CheckCategory[76] = 4;
      this.CheckTypeNames[77] = "CheckSpecialSprite";
      this.CheckTypeVarCount[77] = 2;
      this.CheckTypeVarName[77, 1] = "X";
      this.CheckTypeVarName[77, 2] = "Y";
      this.CheckCategory[77] = 4;
      this.CheckTypeNames[78] = "CheckUnitSelectable";
      this.CheckTypeVarCount[78] = 1;
      this.CheckTypeVarName[78, 1] = "Unit Nr";
      this.CheckCategory[78] = 5;
      this.CheckDesc[78] = "Returns 0 if not selectable. returns 1 if selectable.";
      this.CheckTypeNames[79] = "DistanceClosestEnemyHex";
      this.CheckTypeVarCount[79] = 4;
      this.CheckTypeVarName[79, 1] = "Minimum (AI)VP value? 0=any";
      this.CheckTypeVarName[79, 2] = "from X";
      this.CheckTypeVarName[79, 3] = "from Y";
      this.CheckTypeVarName[79, 4] = "Max distance (-1=no maximum)";
      this.CheckCategory[79] = 3;
      this.CheckDesc[79] = "Returns the distance. Max distance can be set to keep processing time down if necc.";
      this.CheckTypeNames[80] = "CheckEnemyTroopsCloseBy";
      this.CheckTypeVarCount[80] = 4;
      this.CheckTypeVarName[80, 1] = "Max Distance";
      this.CheckTypeVarName[80, 2] = "from X";
      this.CheckTypeVarName[80, 3] = "from Y";
      this.CheckTypeVarName[80, 4] = "Distance divider modifier (0=none)";
      this.CheckCategory[80] = 3;
      this.CheckDesc[80] = "Max distance sets circle in which too look. Distance divider modifier set by what the power points of a unit are divided. if 0 they are not divided. if 1 they are divided by distance. if 2 by double distance.. etc..";
      this.CheckTypeNames[81] = "CheckUnitMor";
      this.CheckTypeVarCount[81] = 1;
      this.CheckTypeVarName[81, 1] = "Unit#";
      this.CheckDesc[81] = "Keep in mind this is an average of the subformations.";
      this.CheckCategory[81] = 5;
      this.CheckTypeNames[82] = "OBSOLETE";
      this.CheckTypeVarCount[82] = 1;
      this.CheckTypeVarName[82, 1] = "SFType#";
      this.CheckCategory[82] = -1;
      this.CheckTypeNames[83] = "CheckSFTypePower";
      this.CheckTypeVarCount[83] = 3;
      this.CheckTypeVarName[83, 1] = "SFType#";
      this.CheckTypeVarName[83, 2] = "SFType Targetgroup";
      this.CheckTypeVarName[83, 3] = "1=attack score, 2=defend score";
      this.CheckCategory[83] = 7;
      this.CheckTypeNames[84] = "CheckSFTypeDescription";
      this.CheckTypeVarCount[84] = 1;
      this.CheckTypeVarName[84, 1] = "SFType#";
      this.CheckCategory[84] = 7;
      this.CheckTypeNames[85] = "CheckSFTypeHP";
      this.CheckTypeVarCount[85] = 3;
      this.CheckTypeVarName[85, 1] = "SFType#";
      this.CheckTypeVarName[85, 2] = "SFType Targetgroup";
      this.CheckTypeVarName[85, 3] = "1=attack hp, 2=defend hp";
      this.CheckCategory[85] = 7;
      this.CheckTypeNames[86] = "CheckSFTypeMoveType";
      this.CheckTypeVarCount[86] = 1;
      this.CheckTypeVarName[86, 1] = "SFType#";
      this.CheckCategory[86] = 7;
      this.CheckTypeNames[87] = "CheckSFTypeMoveRedux";
      this.CheckTypeVarCount[87] = 1;
      this.CheckTypeVarName[87, 1] = "SFType#";
      this.CheckCategory[87] = 7;
      this.CheckTypeNames[88] = "CheckSFTypeModelLastState";
      this.CheckTypeVarCount[88] = 2;
      this.CheckTypeVarName[88, 1] = "SFType#";
      this.CheckTypeVarName[88, 2] = "Research#";
      this.CheckCategory[88] = 7;
      this.CheckTypeNames[89] = "CheckSFTypeLogo";
      this.CheckTypeVarCount[89] = 2;
      this.CheckTypeVarName[89, 1] = "SFType#";
      this.CheckTypeVarName[89, 2] = "Logo#";
      this.CheckCategory[89] = 7;
      this.CheckTypeNames[92] = "CheckSFTypeFuelUse";
      this.CheckTypeVarCount[92] = 2;
      this.CheckTypeVarName[92, 1] = "SFtype#";
      this.CheckTypeVarName[92, 2] = "1=ForMovement, 2=ForCombat";
      this.CheckCategory[92] = 7;
      this.CheckTypeNames[93] = "CheckGameVar";
      this.CheckTypeVarCount[93] = 1;
      this.CheckTypeVarName[93, 1] = "Nr";
      this.CheckCategory[93] = 3;
      this.CheckTypeNames[94] = "CheckTempVar";
      this.CheckTypeVarCount[94] = 1;
      this.CheckTypeVarName[94, 1] = "Nr";
      this.CheckCategory[94] = 3;
      this.CheckTypeNames[95] = "CheckRegimePeople";
      this.CheckTypeVarCount[95] = 1;
      this.CheckTypeVarName[95, 1] = "Regime";
      this.CheckCategory[95] = 2;
      this.CheckTypeNames[96] = "CheckSFTypeVar";
      this.CheckTypeVarCount[96] = 2;
      this.CheckTypeVarName[96, 1] = "SFType";
      this.CheckTypeVarName[96, 2] = "Var#";
      this.CheckCategory[96] = 7;
      this.CheckTypeNames[97] = "CheckSFTypeItem";
      this.CheckTypeVarCount[97] = 1;
      this.CheckTypeVarName[97, 1] = "SFType#";
      this.CheckCategory[97] = 7;
      this.CheckTypeNames[98] = "CheckHexVP";
      this.CheckTypeVarCount[98] = 2;
      this.CheckTypeVarName[98, 1] = "X";
      this.CheckTypeVarName[98, 2] = "Y";
      this.CheckCategory[98] = 4;
      this.CheckTypeNames[99] = "CheckDipOffer";
      this.CheckTypeVarCount[99] = 2;
      this.CheckTypeVarName[99, 1] = "From Regime";
      this.CheckTypeVarName[99, 2] = "Too Regime";
      this.CheckCategory[99] = 2;
      this.CheckTypeNames[101] = "CheckDefinedAreaID";
      this.CheckTypeVarCount[101] = 2;
      this.CheckTypeVarName[101, 1] = "Slot#(0-9)";
      this.CheckTypeVarName[101, 2] = "Value#";
      this.CheckCategory[101] = 3;
      this.CheckDesc[101] = "Returns first Defined area with that slot&value coupled to it.";
      this.CheckTypeNames[102] = "CheckHexPeople";
      this.CheckTypeVarCount[102] = 2;
      this.CheckTypeVarName[102, 1] = "X";
      this.CheckTypeVarName[102, 2] = "Y";
      this.CheckCategory[102] = 4;
      this.CheckDesc[102] = "Returns people number of location here. if any. if not returns -1.";
      this.CheckTypeNames[104] = "CheckNonSleepingRegimesToCome";
      this.CheckTypeVarCount[104] = 0;
      this.CheckCategory[104] = 2;
      this.CheckDesc[104] = "Returns the number of regimes that are still to be played in this round that are not put to sleep.";
      this.CheckTypeNames[108] = "CheckCalcGetPercent";
      this.CheckTypeVarCount[108] = 2;
      this.CheckTypeVarName[108, 1] = "Var X";
      this.CheckTypeVarName[108, 2] = "of Var Y";
      this.CheckCategory[108] = 3;
      this.CheckDesc[108] = "Returns the percentage that var X makes up of var Y.";
      this.CheckTypeNames[109] = "CheckLocCounter";
      this.CheckTypeVarCount[109] = 0;
      this.CheckCategory[109] = 3;
      this.CheckDesc[109] = "Returns the number of locations. remember counting starts at 0.";
      this.CheckTypeNames[110] = "CheckLocX";
      this.CheckTypeVarCount[110] = 1;
      this.CheckTypeVarName[110, 1] = "Location#";
      this.CheckCategory[110] = 3;
      this.CheckDesc[110] = "Returns the number of locations. remember counting starts at 0.";
      this.CheckTypeNames[111] = "CheckLocY";
      this.CheckTypeVarCount[111] = 1;
      this.CheckTypeVarName[111, 1] = "Location#";
      this.CheckCategory[111] = 3;
      this.CheckDesc[111] = "Returns the number of locations. remember counting starts at 0.";
      this.CheckTypeNames[113] = "CheckMaxFuelUse";
      this.CheckTypeVarCount[113] = 2;
      this.CheckTypeVarName[113, 1] = "Regime (-1=all)";
      this.CheckTypeVarName[113, 2] = "Fuel Type (-1=all)";
      this.CheckCategory[113] = 8;
      this.CheckTypeNames[115] = "CheckHexName";
      this.CheckTypeVarCount[115] = 2;
      this.CheckTypeVarName[115, 1] = "X";
      this.CheckTypeVarName[115, 2] = "Y";
      this.CheckCategory[115] = 4;
      this.CheckDesc[115] = "";
      this.CheckTypeNames[116] = "CheckLocName";
      this.CheckTypeVarCount[116] = 1;
      this.CheckTypeVarName[116, 1] = "LocNr";
      this.CheckCategory[116] = 4;
      this.CheckDesc[116] = "";
      this.CheckTypeNames[117] = "CheckHexLocNr";
      this.CheckTypeVarCount[117] = 2;
      this.CheckTypeVarName[117, 1] = "X";
      this.CheckTypeVarName[117, 2] = "Y";
      this.CheckCategory[117] = 4;
      this.CheckDesc[117] = "Returns -1 if no Location in hex. 0 or higher if present.";
      this.CheckTypeNames[118] = "CheckHexUnitCounter";
      this.CheckTypeVarCount[118] = 2;
      this.CheckTypeVarName[118, 1] = "X";
      this.CheckTypeVarName[118, 2] = "Y";
      this.CheckCategory[118] = 5;
      this.CheckDesc[118] = "Returns -1 if no units. Returns 0 is one unit (in slot 0). Returns 1 if two units present (one in slot 0, one in slot1), etc..";
      this.CheckTypeNames[119] = "CheckHexUnit";
      this.CheckTypeVarCount[119] = 3;
      this.CheckTypeVarName[119, 1] = "X";
      this.CheckTypeVarName[119, 2] = "Y";
      this.CheckTypeVarName[119, 3] = "Unit Slot";
      this.CheckCategory[119] = 5;
      this.CheckDesc[119] = "You should use CheckHexUnitCounter to determine the number of units on the hex. Start with slot=0! ";
      this.CheckTypeNames[120] = "CheckStringLength";
      this.CheckTypeVarCount[120] = 1;
      this.CheckTypeVarName[120, 1] = "String";
      this.CheckCategory[120] = 3;
      this.CheckDesc[120] = "Return of 0 means an empty string has been tested.";
      this.CheckTypeNames[121] = "CheckUnitStaffPercent";
      this.CheckTypeVarCount[121] = 2;
      this.CheckTypeVarName[121, 1] = "Unit Nr";
      this.CheckTypeVarName[121, 2] = "CheckMode=0,1,2";
      this.CheckCategory[121] = 5;
      this.CheckDesc[121] = "Return the staff % of the unit... you might want to use this check in combination with CheckUnitHqPower since distance is not checked for in this event. Check Mode 0 returns staff%. Check Mode 1 returns combat mod%, Check Mode 2 returns morale mod%. ";
      this.CheckTypeNames[122] = "CheckSFTypeRatio";
      this.CheckTypeVarCount[122] = 1;
      this.CheckTypeVarName[122, 1] = "SFType#";
      this.CheckCategory[122] = 7;
      this.CheckTypeNames[123] = "CheckSFTypeName";
      this.CheckTypeVarCount[123] = 1;
      this.CheckTypeVarName[123, 1] = "SFType#";
      this.CheckCategory[123] = 7;
      this.CheckTypeNames[124] = "CheckRoadType";
      this.CheckTypeVarCount[124] = 3;
      this.CheckTypeVarName[124, 1] = "X";
      this.CheckTypeVarName[124, 2] = "Y";
      this.CheckTypeVarName[124, 3] = "Direction";
      this.CheckCategory[124] = 4;
      this.CheckDesc[124] = "Direction: 0=n, 1=ne, 2=se, 3=s, 4=sw, 5=nw. Use direction -1 to test for all directions: first type found is returned. -1 is returned if none.";
      this.CheckTypeNames[125] = "CheckRiverType";
      this.CheckTypeVarCount[125] = 3;
      this.CheckTypeVarName[125, 1] = "X";
      this.CheckTypeVarName[125, 2] = "Y";
      this.CheckTypeVarName[125, 3] = "Direction";
      this.CheckCategory[125] = 4;
      this.CheckDesc[125] = "Direction: 0=n, 1=ne, 2=se, 3=s, 4=sw, 5=nw. Use direction -1 to test for all directions: first type found is returned. -1 is returned if none.";
      this.CheckTypeNames[126] = "CheckBridge";
      this.CheckTypeVarCount[126] = 3;
      this.CheckTypeVarName[126, 1] = "X";
      this.CheckTypeVarName[126, 2] = "Y";
      this.CheckTypeVarName[126, 3] = "Direction";
      this.CheckCategory[126] = 4;
      this.CheckDesc[126] = "Direction: 0=n, 1=ne, 2=se, 3=s, 4=sw, 5=nw. Use direction -1 to test for all directions. Returns 0 for no bridge and 1 for yes bridge.";
      this.CheckTypeNames[ sbyte.MaxValue] = "CheckHisVar";
      this.CheckTypeVarCount[ sbyte.MaxValue] = 2;
      this.CheckTypeVarName[ sbyte.MaxValue, 1] = "His Unit ID#";
      this.CheckTypeVarName[ sbyte.MaxValue, 2] = "Type#";
      this.CheckCategory[ sbyte.MaxValue] = 5;
      this.CheckDesc[ sbyte.MaxValue] = "Returns value if type is present. If type is not present it returns 0.";
      this.CheckTypeNames[128] = "CheckUnitRecon";
      this.CheckTypeVarCount[128] = 4;
      this.CheckTypeVarName[128, 1] = "Unit#";
      this.CheckTypeVarName[128, 2] = "Include land theater 0=no, 1=yes";
      this.CheckTypeVarName[128, 3] = "Include sea theater 0=no, 1=yes";
      this.CheckTypeVarName[128, 4] = "Include air theater 0=no, 1=yes";
      this.CheckDesc[128] = "Returns total recon points in the unit.";
      this.CheckCategory[128] = 5;
      this.CheckTypeNames[129] = "CheckRoadTypeSpecific";
      this.CheckTypeVarCount[129] = 3;
      this.CheckTypeVarName[129, 1] = "X";
      this.CheckTypeVarName[129, 2] = "Y";
      this.CheckTypeVarName[129, 3] = "Specific Road Type";
      this.CheckCategory[129] = 4;
      this.CheckDesc[129] = "Check is specied roadtype is present in this hex. Returns 1 if is. Returns 0 if not.";
      this.CheckTypeNames[130] = "CheckHistoricalUnitAverageXP";
      this.CheckTypeVarCount[130] = 1;
      this.CheckTypeVarName[130, 1] = "Unit#";
      this.CheckCategory[130] = 5;
      this.CheckDesc[130] = "Will look up other units on map with the same historical unit and return average xp";
      this.CheckTypeNames[131] = "CheckRandomRowStringList";
      this.CheckTypeVarCount[131] = 2;
      this.CheckTypeVarName[131, 1] = "Stringlist ID";
      this.CheckTypeVarName[131, 2] = "Col used as weight (-1=none)";
      this.CheckCategory[131] = 6;
      this.CheckTypeNames[132] = "CheckFindInStringList";
      this.CheckTypeVarCount[132] = 3;
      this.CheckTypeVarName[132, 1] = "Stringlist ID";
      this.CheckTypeVarName[132, 2] = "In Col";
      this.CheckTypeVarName[132, 3] = "Find Value";
      this.CheckCategory[132] = 6;
      this.CheckDesc[132] = "Returns row# where value is found or -1 if not.";
      this.CheckTypeNames[133] = "CheckTotalHistoricalUnits";
      this.CheckTypeVarCount[133] = 0;
      this.CheckCategory[133] = 5;
      this.CheckTypeNames[134] = "CheckGetHistoricalUnitID";
      this.CheckTypeVarCount[134] = 1;
      this.CheckTypeVarName[134, 1] = "Slot#";
      this.CheckCategory[134] = 5;
      this.CheckDesc[134] = "Keep in mind that this function should be used to scroll through all historical units using a looper from 0 to CheckTotalHistoricalUnits. Use this function to get the actual ID to be used in other functions.";
      this.CheckTypeNames[135] = "CheckGetHistoricalUnitRegime";
      this.CheckTypeVarCount[135] = 1;
      this.CheckTypeVarName[135, 1] = "Historical Unit ID#";
      this.CheckCategory[135] = 5;
      this.CheckTypeNames[136] = "CheckPeopleUnderHQ";
      this.CheckTypeVarCount[136] = 4;
      this.CheckTypeVarName[136, 1] = "HQ level to check";
      this.CheckTypeVarName[136, 2] = "Troop people";
      this.CheckTypeVarName[136, 3] = "HQ people";
      this.CheckTypeVarName[136, 4] = "regime#";
      this.CheckCategory[136] = 5;
      this.CheckDesc[136] = "A complicated function. HQ level 1 is HQs with historical unit set to Corps. HQ level 2 is only HQs with historical HQ set to Army, 3=armygroup, 4=high command.. Function returns % of total power points of people on map is under a hq whose historical unit people is set to hqppl. This function could for example be used to check if axis minor are under wehrmacht HQs or under their own.";
      this.CheckTypeNames[137] = "CheckGetHistoricalUnitPeople";
      this.CheckTypeVarCount[137] = 1;
      this.CheckTypeVarName[137, 1] = "Historical Unit ID#";
      this.CheckCategory[137] = 5;
      this.CheckTypeNames[138] = "CheckGetHistoricalUnitType";
      this.CheckTypeVarCount[138] = 1;
      this.CheckTypeVarName[138, 1] = "Historical Unit ID#";
      this.CheckCategory[138] = 5;
      this.CheckDesc[138] = "Returns the type. 5=corps, 6=army, etc..";
      this.CheckTypeNames[139] = "CheckGetHistoricalUnitOfficer";
      this.CheckTypeVarCount[139] = 1;
      this.CheckTypeVarName[139, 1] = "Historical Unit ID#";
      this.CheckCategory[139] = 5;
      this.CheckDesc[139] = "returns 1 if officer, returns 0 if not. Basicly the length of officer name is checked.";
      this.CheckTypeNames[140] = "CheckCompareString";
      this.CheckTypeVarCount[140] = 3;
      this.CheckTypeVarName[140, 1] = "String1";
      this.CheckTypeVarName[140, 2] = "String2";
      this.CheckTypeVarName[140, 3] = "Mode";
      this.CheckCategory[140] = 3;
      this.CheckDesc[140] = "Case insensitive. Mode=1 means it looks if the strings are exactly alike. Mode=2 same but all spaces are removed. Mode=3 means it looks if part of string1 is equal to string 2. Function returns 1 if equal or 0 if not.";
      this.CheckTypeNames[141] = "CheckMin";
      this.CheckTypeVarCount[141] = 2;
      this.CheckTypeVarName[141, 1] = "Value1";
      this.CheckTypeVarName[141, 2] = "Value2";
      this.CheckTypeVarName[141, 3] = "Mode";
      this.CheckCategory[141] = 3;
      this.CheckDesc[141] = "Returns the lowest of the 2 values entered";
      this.CheckTypeNames[142] = "CheckMax";
      this.CheckTypeVarCount[142] = 2;
      this.CheckTypeVarName[142, 1] = "Value1";
      this.CheckTypeVarName[142, 2] = "Value2";
      this.CheckTypeVarName[142, 3] = "Mode";
      this.CheckCategory[142] = 3;
      this.CheckDesc[142] = "Returns the highest of the 2 values entered";
      this.CheckTypeNames[143] = "CheckGetHistoricalUnitName";
      this.CheckTypeVarCount[143] = 1;
      this.CheckTypeVarName[143, 1] = "Historical Unit ID#";
      this.CheckCategory[143] = 5;
      this.CheckTypeNames[144] = "CheckGetHistoricalSubparts";
      this.CheckTypeVarCount[144] = 1;
      this.CheckTypeVarName[144, 1] = "Historical Unit ID#";
      this.CheckCategory[144] = 5;
      this.CheckTypeNames[147] = "CheckPbemPlayer";
      this.CheckTypeVarCount[147] = 1;
      this.CheckTypeVarName[147, 1] = "Regime#";
      this.CheckCategory[147] = 2;
      this.CheckDesc[147] = "Expert use only! Returns either 1 for pbem player 1 (challenger), 2 for pbem player 2(opponent) or 0 if not set (not a started pbem++ game for example)";
      this.CheckTypeNames[148] = "CheckDrawGame";
      this.CheckTypeVarCount[148] = 0;
      this.CheckCategory[148] = 1;
      this.CheckDesc[148] = "Returns 0 if not. Returns 1 if this is a draw game.";
      this.CheckTypeNames[146] = "CheckUnitAP";
      this.CheckTypeVarCount[146] = 1;
      this.CheckTypeVarName[146, 1] = "Unit#";
      this.CheckDesc[146] = "Keep in mind this is the lowest AP subformations.";
      this.CheckCategory[146] = 5;
      this.CheckTypeNames[145] = "CheckTotalSupplyUse";
      this.CheckTypeVarCount[145] = 1;
      this.CheckTypeVarName[145, 1] = "Regime #";
      this.CheckCategory[145] = 2;
      this.CheckDesc[145] = "Returns the BasicSupplyUse of all troops on the map added up.";
      this.CheckTypeNames[149] = "CheckTotalActioncards";
      this.CheckTypeVarCount[149] = 3;
      this.CheckTypeVarName[149, 1] = "Regime #";
      this.CheckTypeVarName[149, 2] = "Category # (-1=all)";
      this.CheckTypeVarName[149, 3] = "Color # (-1=all)";
      this.CheckCategory[149] = 2;
      this.CheckDesc[149] = "Returns the total number of action cards the regime has in hand. However if you set regime=-1 it returns the top action card slot in the actioncard list. This is usefull if your manually adding actioncards through events.";
      this.CheckTypeNames[150] = "CheckAICombatMod";
      this.CheckTypeVarCount[150] = 1;
      this.CheckTypeVarName[150, 1] = "Regime";
      this.CheckCategory[150] = 2;
      this.CheckDesc[150] = "Gives back the AI combat modifier. 0=none, >0 is the percentual bonus. (This is the AI difficulty in the scenario setup screen)";
      this.CheckTypeNames[151] = "CheckIsUnitAPreDef";
      this.CheckTypeVarCount[151] = 1;
      this.CheckTypeVarName[151, 1] = "Unr#";
      this.CheckDesc[151] = "Returns -1 if not a predef. Returns the predef ID # if it is a predef.";
      this.CheckCategory[151] = 5;
      this.CheckTypeNames[152] = "CheckRuleVar";
      this.CheckTypeVarCount[152] = 2;
      this.CheckTypeVarName[152, 1] = "RuleVar#";
      this.CheckTypeVarName[152, 2] = "Mulitply by 100? 0=no 1=yes";
      this.CheckDesc[152] = "Multiply option is there because some rulevar have single values like 0.4 or 0.03. And the scripting sytem can only handle integers.";
      this.CheckCategory[152] = 1;
      this.CheckTypeNames[153] = "CheckUnitXP";
      this.CheckTypeVarCount[153] = 2;
      this.CheckTypeVarName[153, 1] = "Unit#";
      this.CheckTypeVarName[153, 2] = "Only if staff (0=no,1=yes)";
      this.CheckDesc[153] = "Keep in mind that it returns the highest XP found in any subformation.";
      this.CheckCategory[153] = 5;
      this.CheckTypeNames[154] = "CheckGetHistoricalUnitCommanderName";
      this.CheckTypeVarCount[154] = 1;
      this.CheckTypeVarName[154, 1] = "Historical Unit ID#";
      this.CheckCategory[154] = 5;
      this.CheckDesc[154] = "Returns the commandername (not the his.unit name!). If no commander empty string is returned.";
      this.CheckTypeNames[155] = "CheckFindHistoricalUnitWithCommanderName";
      this.CheckTypeVarCount[155] = 1;
      this.CheckTypeVarName[155, 1] = "Commander Name";
      this.CheckCategory[155] = 5;
      this.CheckDesc[155] = "Returns the first historical unit ID number of a unit ON the map with this commander name present. -1= none find. ";
      this.CheckTypeNames[156] = "CheckUnitHQChanged";
      this.CheckTypeVarCount[156] = 1;
      this.CheckTypeVarName[156, 1] = "Unit Nr";
      this.CheckCategory[156] = 5;
      this.CheckDesc[156] = "Returns 1 if the unit HQ has been changed in this turn. Returns 0 if not.";
      this.CheckTypeNames[157] = "CheckHistoricalUnitAirAndNavy";
      this.CheckTypeVarCount[157] = 3;
      this.CheckTypeVarName[157, 1] = "His Unit ID#";
      this.CheckTypeVarName[157, 2] = "Check for air theater troops? 0=no,1=yes";
      this.CheckTypeVarName[157, 3] = "Check for navy theater troops? 0=no,1=yes";
      this.CheckCategory[157] = 5;
      this.CheckDesc[157] = "Returns 1 if those troops are present. 0 if not.";
      this.CheckTypeNames[158] = "CheckForLocationProperty";
      this.CheckTypeVarCount[158] = 4;
      this.CheckTypeVarName[158, 1] = "X";
      this.CheckTypeVarName[158, 2] = "Y";
      this.CheckTypeVarName[158, 3] = "1=airbase, 2=port(and sea next door)";
      this.CheckCategory[158] = 3;
      this.CheckDesc[158] = "Returns 1 if property is available, Returns 0 if not.";
      this.CheckTypeNames[159] = "CheckGetStringlistID";
      this.CheckTypeVarCount[159] = 2;
      this.CheckTypeVarName[159, 1] = "Library Name";
      this.CheckTypeVarName[159, 2] = "Stringlist ID";
      this.CheckCategory[159] = 10;
      this.CheckDesc[159] = "Use when writing library events to get correct stringlist when library is used. This Check returns always the correct ID of the stringlist. ";
      this.CheckTypeNames[160] = "CheckLibVarGlobal";
      this.CheckTypeVarCount[160] = 2;
      this.CheckTypeVarName[160, 1] = "Library Name";
      this.CheckTypeVarName[160, 2] = "Variable Name";
      this.CheckCategory[160] = 10;
      this.CheckDesc[160] = "Returns the value of specified global libvar. ";
      this.CheckTypeNames[161] = "CheckGetEventPic";
      this.CheckTypeVarCount[161] = 2;
      this.CheckTypeVarName[161, 1] = "Library Name";
      this.CheckTypeVarName[161, 2] = "Orig eventPic SlotNr";
      this.CheckCategory[161] = 10;
      this.CheckDesc[161] = "Returns the current eventPic Nr. If you are writing library events that use eventpics you should always call this check first. ";
      this.CheckTypeNames[162] = "CheckGetSmallPic";
      this.CheckTypeVarCount[162] = 2;
      this.CheckTypeVarName[162, 1] = "Library Name";
      this.CheckTypeVarName[162, 2] = "Orig smallPic SlotNr";
      this.CheckCategory[162] = 10;
      this.CheckDesc[162] = "Returns the current smallPic Nr.  If you are writing library events that use small pics you should always call this check first.  ";
      this.CheckTypeNames[163] = "CheckGetCurrentDateString";
      this.CheckTypeVarCount[163] = 0;
      this.CheckCategory[163] = 3;
      this.CheckDesc[163] = "Returns a string thats date formatted. Keep in mind that strings when compared using <,>,=, etc.. are compared as if they were dates.";
      this.CheckTypeNames[164] = "CheckGetDateString";
      this.CheckTypeVarCount[164] = 0;
      this.CheckTypeVarCount[164] = 4;
      this.CheckTypeVarName[164, 1] = "Day";
      this.CheckTypeVarName[164, 2] = "Month";
      this.CheckTypeVarName[164, 3] = "Year";
      this.CheckTypeVarName[164, 4] = "Hour";
      this.CheckCategory[164] = 3;
      this.CheckDesc[164] = "Returns a string thats date formatted. Keep in mind that strings when compared using <,>,=, etc.. are compared as if they were dates.";
      this.CheckTypeNames[165] = "CheckGetHistoricalIDByLib";
      this.CheckTypeVarCount[165] = 2;
      this.CheckTypeVarName[165, 1] = "Library Name";
      this.CheckTypeVarName[165, 2] = "ID";
      this.CheckCategory[165] = 10;
      this.CheckDesc[165] = "Returns the ID of the historical unit/historical model in the current scenario.  ";
      this.CheckTypeNames[166] = "CheckGetHistoricalIDForCommanderByLib";
      this.CheckTypeVarCount[166] = 2;
      this.CheckTypeVarName[166, 1] = "Library Name";
      this.CheckTypeVarName[166, 2] = "ID";
      this.CheckCategory[166] = 10;
      this.CheckDesc[166] = "Returns the ID of the commander in the current scenario.  ";
      this.CheckTypeNames[167] = "CheckGetPeopleByLib";
      this.CheckTypeVarCount[167] = 2;
      this.CheckTypeVarName[167, 1] = "Library Name";
      this.CheckTypeVarName[167, 2] = "ID";
      this.CheckCategory[167] = 10;
      this.CheckDesc[167] = "Returns the slot of the people in the current scenario.  ";
      this.CheckTypeNames[168] = "CheckGetRegimeByLib";
      this.CheckTypeVarCount[168] = 2;
      this.CheckTypeVarName[168, 1] = "Library Name";
      this.CheckTypeVarName[168, 2] = "ID";
      this.CheckCategory[168] = 10;
      this.CheckDesc[168] = "Returns the slot of the regime in the current scenario.  ";
      this.CheckTypeNames[169] = "CheckGetSFTypeByLib";
      this.CheckTypeVarCount[169] = 2;
      this.CheckTypeVarName[169, 1] = "Library Name";
      this.CheckTypeVarName[169, 2] = "ID";
      this.CheckCategory[169] = 10;
      this.CheckDesc[169] = "Returns the slot of the SFType in the current scenario.  ";
      this.CheckTypeNames[170] = "CheckGetEventByLib";
      this.CheckTypeVarCount[170] = 2;
      this.CheckTypeVarName[170, 1] = "Library Name";
      this.CheckTypeVarName[170, 2] = "ID";
      this.CheckCategory[170] = 10;
      this.CheckDesc[170] = "Returns the slot of the event in the current scenario.  ";
      this.CheckTypeNames[171] = "CheckGetCardByLib";
      this.CheckTypeVarCount[171] = 2;
      this.CheckTypeVarName[171, 1] = "Library Name";
      this.CheckTypeVarName[171, 2] = "Library Slot";
      this.CheckCategory[171] = 10;
      this.CheckDesc[171] = "Returns the slot of the actioncard in the current scenario.  ";
      this.CheckTypeNames[172] = "CheckLibVarHistorical";
      this.CheckTypeVarCount[172] = 3;
      this.CheckTypeVarName[172, 1] = "Historical Unit Slot (in this scenario)";
      this.CheckTypeVarName[172, 2] = "Library Name";
      this.CheckTypeVarName[172, 3] = "LibVar Name";
      this.CheckCategory[172] = 10;
      this.CheckDesc[172] = "Returns the value of specified Libvar for historical unit or historical model. ";
      this.CheckTypeNames[173] = "CheckLibVarLandscape";
      this.CheckTypeVarCount[173] = 2;
      this.CheckTypeVarName[173, 1] = "Landscape Slot (in this scenario)";
      this.CheckTypeVarName[173, 2] = "Library Name";
      this.CheckTypeVarName[173, 3] = "LibVar Name";
      this.CheckCategory[173] = 10;
      this.CheckDesc[173] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[174] = "CheckLibVarPeople";
      this.CheckTypeVarCount[174] = 3;
      this.CheckTypeVarName[174, 1] = "People Slot (in this scenario)";
      this.CheckTypeVarName[174, 2] = "Library Name";
      this.CheckTypeVarName[174, 3] = "LibVar Name";
      this.CheckCategory[174] = 10;
      this.CheckDesc[174] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[175] = "CheckLibVarRegime";
      this.CheckTypeVarCount[175] = 3;
      this.CheckTypeVarName[175, 1] = "Regime Slot (in this scenario)";
      this.CheckTypeVarName[175, 2] = "Library Name";
      this.CheckTypeVarName[175, 3] = "LibVar Name";
      this.CheckCategory[175] = 10;
      this.CheckDesc[175] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[176] = "CheckLibVarRiver";
      this.CheckTypeVarCount[176] = 3;
      this.CheckTypeVarName[176, 1] = "River Slot (in this scenario)";
      this.CheckTypeVarName[176, 2] = "Library Name";
      this.CheckTypeVarName[176, 3] = "LibVar Name";
      this.CheckCategory[176] = 10;
      this.CheckDesc[176] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[177] = "CheckLibVarRoad";
      this.CheckTypeVarCount[177] = 2;
      this.CheckTypeVarName[177, 1] = "Road Slot (in this scenario)";
      this.CheckTypeVarName[177, 2] = "Library Name";
      this.CheckTypeVarName[177, 3] = "LibVar Name";
      this.CheckCategory[177] = 10;
      this.CheckDesc[177] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[178] = "CheckLibVarSFType";
      this.CheckTypeVarCount[178] = 3;
      this.CheckTypeVarName[178, 1] = "SFType Slot (in this scenario)";
      this.CheckTypeVarName[178, 2] = "Library Name";
      this.CheckTypeVarName[178, 3] = "LibVar Name";
      this.CheckCategory[178] = 10;
      this.CheckDesc[178] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[179] = "CheckLibVarLocType";
      this.CheckTypeVarCount[179] = 3;
      this.CheckTypeVarName[179, 1] = "LocType Slot (in this scenario)";
      this.CheckTypeVarName[179, 2] = "Library Name";
      this.CheckTypeVarName[179, 3] = "LibVar Name";
      this.CheckCategory[179] = 10;
      this.CheckDesc[179] = "Returns the value of specified Libvar. ";
      this.CheckTypeNames[180] = "CheckLibVarHex";
      this.CheckTypeVarCount[180] = 4;
      this.CheckTypeVarName[180, 1] = "X";
      this.CheckTypeVarName[180, 2] = "Y";
      this.CheckTypeVarName[180, 3] = "Library Name";
      this.CheckTypeVarName[180, 4] = "LibVar Name";
      this.CheckCategory[180] = 10;
      this.CheckDesc[180] = "Returns the value of specified libvar of that hex. No value set returns 0. ";
      this.CheckTypeNames[181] = "CheckLibVarCommander";
      this.CheckTypeVarCount[181] = 3;
      this.CheckTypeVarName[181, 1] = "Commanders Historical Unit Slot";
      this.CheckTypeVarName[181, 2] = "Library Name";
      this.CheckTypeVarName[181, 3] = "LibVar Name";
      this.CheckCategory[181] = 10;
      this.CheckDesc[181] = "Returns the value of specified Libvar for historical commander. ";
      this.CheckTypeNames[182] = "CheckVisible";
      this.CheckTypeVarCount[182] = 1;
      this.CheckTypeVarName[182, 1] = "SFType#";
      this.CheckCategory[182] = 7;
      this.CheckDesc[182] = "Returns 1 if visible (dont show in list=false), returns 0 if not (dont show in list=true). Invisible SFTypes are used as base models in the Intermediate TroopType editor.";
      this.CheckTypeNames[183] = "CheckSFTypeCounter";
      this.CheckTypeVarCount[183] = 0;
      this.CheckCategory[183] = 7;
      this.CheckDesc[183] = "Returns the highest SFType slot.";
      this.CheckTypeNames[184] = "CheckSFTypeTheaterOrGroup";
      this.CheckTypeVarCount[184] = 2;
      this.CheckTypeVarName[184, 1] = "SFType#";
      this.CheckTypeVarName[184, 2] = "1=Check Theater, 2=CheckUnitGroup";
      this.CheckCategory[184] = 7;
      this.CheckDesc[184] = "Theater codes are: 0=land, 1=sea, 2=air.";
      this.CheckTypeNames[185] = "CheckHistoricalUnitMaster";
      this.CheckTypeVarCount[185] = 1;
      this.CheckTypeVarName[185, 1] = "Historical Unit ID";
      this.CheckCategory[185] = 5;
      this.CheckDesc[185] = "Returns the historical unit model ID";
      this.CheckTypeNames[186] = "CheckRegimeName";
      this.CheckTypeVarCount[186] = 1;
      this.CheckTypeVarName[186, 1] = "RegimeNr";
      this.CheckCategory[186] = 2;
      this.CheckTypeNames[187] = "CheckUnitActivity";
      this.CheckTypeVarCount[187] = 2;
      this.CheckTypeVarName[187, 1] = "Unit Nr";
      this.CheckTypeVarName[187, 2] = "Activity Data Type";
      this.CheckCategory[187] = 5;
      this.CheckDesc[187] = "These stats are reset after lateTurn events are executed. Activity Data Types are 1=Offensive combat AP spent, 2=Defensive combat AP spent, 3=Move AP spent, 4=Off+Def AP spent, 5=Off+Def+Move AP spent. 6=Did unit spent move AP or moved (0=no, 1=yes) ";
      this.CheckTypeNames[188] = "CheckGetPreDefIDByLib";
      this.CheckTypeVarCount[188] = 2;
      this.CheckTypeVarName[188, 1] = "Library Name";
      this.CheckTypeVarName[188, 2] = "PreDefID";
      this.CheckCategory[188] = 10;
      this.CheckDesc[188] = "Returns the preDefID in the current scenario for a the PreDefID inside a specific library.  ";
      this.CheckTypeNames[189] = "CheckTempString";
      this.CheckTypeVarCount[189] = 1;
      this.CheckTypeVarName[189, 1] = "TempString #";
      this.CheckCategory[189] = 3;
      this.CheckTypeNames[190] = "CheckPopupSkipped";
      this.CheckTypeVarCount[190] = 0;
      this.CheckDesc[190] = "Returns 1 if popup skipped otherwise returns 0.";
      this.CheckCategory[190] = 3;
      this.CheckTypeNames[191] = "CheckForUnitVisibleToPlayer";
      this.CheckTypeVarCount[191] = 2;
      this.CheckTypeVarName[191, 1] = "Unit Number";
      this.CheckTypeVarName[191, 2] = "Player Number";
      this.CheckCategory[191] = 3;
      this.CheckDesc[191] = "Returns 1,2,3 if unit is visible. Returns 0 if it is not. 1=?mark counter, 2=fuzzy info, 3=exact strength known ";
      this.CheckTypeNames[192] = "CheckFOW";
      this.CheckTypeVarCount[192] = 0;
      this.CheckCategory[192] = 1;
      this.CheckDesc[192] = "Returns 1 if fow is on. 0 if off.";
      this.CheckTypeNames[193] = "CheckMoveOriginX";
      this.CheckTypeVarCount[193] = 2;
      this.CheckTypeVarName[193, 1] = "X";
      this.CheckTypeVarName[193, 2] = "Y";
      this.CheckCategory[193] = 4;
      this.CheckDesc[193] = "You should only call this function if ExecSetMoveMatrix or ExecSetSupplyMatrix has been called before it. Any hex that has a moveable score (<9999) and that is not the source hex of the matrix called will have an origin. These 2 functions (x and y) will return that origin coordinate. -1 is returned if no origin hex is available.";
      this.CheckTypeNames[194] = "CheckMoveOriginY";
      this.CheckTypeVarCount[194] = 2;
      this.CheckTypeVarName[194, 1] = "X";
      this.CheckTypeVarName[194, 2] = "Y";
      this.CheckCategory[194] = 4;
      this.CheckDesc[194] = "You should only call this function if ExecSetMoveMatrix or ExecSetSupplyMatrix has been called before it. Any hex that has a moveable score (<9999) and that is not the source hex of the matrix called will have an origin. These 2 functions (x and y) will return that origin coordinate. -1 is returned if no origin hex is available.";
      this.CheckTypeNames[195] = "CheckActionCardPPCost";
      this.CheckTypeVarCount[195] = 1;
      this.CheckTypeVarName[195, 1] = "Card slot #";
      this.CheckCategory[195] = 2;
      this.CheckDesc[195] = "Returns the PP cost of the action card specified.";
      this.CheckTypeNames[196] = "CheckGetHistoricalUnitSlot";
      this.CheckTypeVarCount[196] = 1;
      this.CheckTypeVarName[196, 1] = "ID#";
      this.CheckCategory[196] = 5;
      this.CheckDesc[196] = "Supply the historical unit ID# and get the slot# in return. If not found it will return -1.";
      this.CheckTypeNames[197] = "CheckActionCardTempVar";
      this.CheckTypeVarCount[197] = 2;
      this.CheckTypeVarName[197, 1] = "Card slot #";
      this.CheckTypeVarName[197, 2] = "Tempvar 0 or 1";
      this.CheckCategory[197] = 2;
      this.CheckDesc[197] = "Returns the tempvar number selected.";
      this.CheckTypeNames[198] = "CheckLibraryOfCard";
      this.CheckTypeVarCount[198] = 1;
      this.CheckTypeVarName[198, 1] = "Action Card Slot";
      this.CheckCategory[198] = 10;
      this.CheckDesc[198] = "Returns a string with the library name.  ";
      this.CheckTypeNames[199] = "CheckGetCommanderPoolValue";
      this.CheckTypeVarCount[199] = 1;
      this.CheckTypeVarName[199, 1] = "ID#";
      this.CheckCategory[199] = 5;
      this.CheckDesc[199] = "Returns 1 if in pool. Returns 0 if not. ";
      this.CheckTypeNames[200] = "CheckModulo";
      this.CheckTypeVarCount[200] = 2;
      this.CheckTypeVarName[200, 1] = "Number";
      this.CheckTypeVarName[200, 2] = "Divider";
      this.CheckCategory[200] = 3;
      this.CheckDesc[200] = "Return (number) modulo (divider)... For example 4 modulo 3 = 1";
      this.CheckTypeNames[201] = "CheckSlotOwnerPercentage";
      this.CheckTypeVarCount[201] = 4;
      this.CheckTypeVarName[201, 1] = "AreaSlot#";
      this.CheckTypeVarName[201, 2] = "Startval (>=)";
      this.CheckTypeVarName[201, 3] = "Endval (<=)";
      this.CheckTypeVarName[201, 4] = "Owner";
      this.CheckCategory[201] = 4;
      this.CheckDesc[201] = "Returns a percentage of the specified areaslots between start and endvalue occupied by owner regime slot#";
      this.CheckTypeNames[202] = "CheckSlotNotInAIList";
      this.CheckTypeVarCount[202] = 4;
      this.CheckTypeVarName[202, 1] = "AreaSlot#";
      this.CheckTypeVarName[202, 2] = "Startval (>=)";
      this.CheckTypeVarName[202, 3] = "Endval (<=)";
      this.CheckTypeVarName[202, 4] = "Max Dist";
      this.CheckCategory[202] = 4;
      this.CheckDesc[202] = "Within areaslot returns a value out of the range between start and endvalue occupied by current regime owner slot# closest to SetAreaXY specified. Returns -1 if nothing found. Function only looks within supply range of SetAreaXY and only within MaxDist.";
      this.CheckTypeNames[203] = "CheckSlotValueFirstXY";
      this.CheckTypeVarCount[203] = 3;
      this.CheckTypeVarName[203, 1] = "AreaSlot#";
      this.CheckTypeVarName[203, 2] = "Value";
      this.CheckTypeVarName[203, 3] = "What? 1=x,2=y,3=reg";
      this.CheckCategory[203] = 4;
      this.CheckDesc[203] = "Within areaslot returns the x,y coordinate first found with the value given (x or y). Only values >= 1 work.";
      this.CheckTypeNames[204] = "CheckAbs";
      this.CheckTypeVarCount[204] = 1;
      this.CheckTypeVarName[204, 1] = "Number";
      this.CheckCategory[204] = 3;
      this.CheckDesc[204] = "Return the absolute of the number passed";
      this.CheckTypeNames[205] = "CheckSubString";
      this.CheckTypeVarCount[205] = 3;
      this.CheckTypeVarName[205, 1] = "String";
      this.CheckTypeVarName[205, 2] = "Position";
      this.CheckTypeVarName[205, 3] = "Length";
      this.CheckCategory[205] = 3;
      this.CheckDesc[205] = "For example. If string='abcdef' then position 2, length 2 will return 'bc'";
      this.CheckTypeNames[206] = "CheckRandomRowStringList2";
      this.CheckTypeVarCount[206] = 3;
      this.CheckTypeVarName[206, 1] = "Stringlist ID";
      this.CheckTypeVarName[206, 2] = "Col used as weight (-1=none)";
      this.CheckTypeVarName[206, 3] = "Col used as block (-1=none)";
      this.CheckCategory[206] = 6;
      this.CheckDesc[206] = "Concerning the block column. <= 0 will be considered NOT blocked. >= 1 will be considered blocked. Returns -1 if no suitable row found. ";
      this.CheckTypeNames[207] = "CheckAppendString";
      this.CheckTypeVarCount[207] = 4;
      this.CheckTypeVarName[207, 1] = "String";
      this.CheckTypeVarName[207, 2] = "Position";
      this.CheckTypeVarName[207, 3] = "String to Insert";
      this.CheckTypeVarName[207, 4] = "Mode";
      this.CheckCategory[207] = 3;
      this.CheckDesc[207] = "Mode 0 = Insert, Mode 1 = Overwrite. Example: string 'abcdef', pos=2, stringToInsert='123', mode=0 results in 'a123bcdef'";
      this.CheckTypeNames[208] = "CheckCapitalise";
      this.CheckTypeVarCount[208] = 2;
      this.CheckTypeVarName[208, 1] = "String";
      this.CheckTypeVarName[208, 2] = "Mode";
      this.CheckCategory[208] = 3;
      this.CheckDesc[208] = "Mode 0 = Cap. 1st char of phrase, Mode 1 = Cap 1st char each word, Mode 2 = Cap all, Mode 3 = lowercase all";
      this.CheckTypeNames[209] = "CheckUnitEntrench";
      this.CheckTypeVarCount[209] = 1;
      this.CheckTypeVarName[209, 1] = "Unit#";
      this.CheckDesc[209] = "Keep in mind this is an average of the subformations.";
      this.CheckCategory[209] = 5;
      this.CheckTypeNames[210] = "CheckImportStringList";
      this.CheckTypeVarCount[210] = 2;
      this.CheckTypeVarName[210, 1] = "Stringlist ID";
      this.CheckTypeVarName[210, 2] = "Filename";
      this.CheckCategory[210] = 6;
      this.CheckDesc[210] = "Will replace said stringlist with the contents of the filename. This will be a full replacement and nothing of old contents will remain. Directory used is the 'metadata' directory. Please include a file extension in the filename like .txt. Returns 1 on succes. Returns -1 on file not found. Returns -2 on data corruption of file. ";
      this.CheckTypeNames[211] = "CheckUnitIntegrity";
      this.CheckTypeVarCount[211] = 1;
      this.CheckTypeVarName[211, 1] = "Unit#";
      this.CheckDesc[211] = "Returns a percentage between 0-100. ";
      this.CheckCategory[211] = 5;
      this.CheckTypeNames[212] = "CheckUnitSupplyConsumption";
      this.CheckTypeVarCount[212] = 2;
      this.CheckTypeVarName[212, 1] = "Unit#";
      this.CheckTypeVarName[212, 2] = "Mode";
      this.CheckDesc[212] = "Mode<=1 : Returns a percentage between 0-100. Mode 2: Returns missing supply, Mode 3: Returns missing fuel";
      this.CheckCategory[212] = 5;
      this.CheckTypeNames[213] = "CheckKey";
      this.CheckTypeVarCount[213] = 2;
      this.CheckTypeVarName[213, 1] = "Stringlist ID";
      this.CheckTypeVarName[213, 2] = "Key name";
      this.CheckCategory[213] = 6;
      this.CheckDesc[213] = "Presumes key names in column 0 and values in column 1 ";
      this.CheckTypeNames[256] = "CheckSuperAdmin";
      this.CheckTypeVarCount[256] = 0;
      this.CheckDesc[256] = "Returns 0 if normal player, Returns 1 is super admin ";
      this.CheckCategory[256] = 11;
      this.CheckTypeNames[214] = "CheckTextHeight";
      this.CheckTypeVarCount[214] = 1;
      this.CheckTypeVarName[214, 1] = "Full Element Text";
      this.CheckDesc[214] = "Returns the number of pixels ";
      this.CheckCategory[214] = 11;
      this.CheckTypeNames[ byte.MaxValue] = "CheckTextWidth";
      this.CheckTypeVarCount[ byte.MaxValue] = 1;
      this.CheckTypeVarName[ byte.MaxValue, 1] = "Full Element Text";
      this.CheckDesc[ byte.MaxValue] = "Returns the number of pixels ";
      this.CheckCategory[ byte.MaxValue] = 11;
      this.CheckTypeNames[215] = "CheckUDSInput";
      this.CheckTypeVarCount[215] = 1;
      this.CheckTypeVarName[215, 1] = "Key name";
      this.CheckCategory[215] = 11;
      this.CheckDesc[215] = "Returns value for key";
      this.CheckTypeNames[216] = "CheckAreaslotWaterLevel";
      this.CheckTypeVarCount[216] = 2;
      this.CheckTypeVarName[216, 1] = "Height Map Areaslot#";
      this.CheckTypeVarName[216, 2] = "Avg water points per hex";
      this.CheckCategory[216] = 12;
      this.CheckDesc[216] = "Expects an areaslot with height values that use the same scale as the avg water points. If you would use earth heigh map in meters and specify 2000 meters of water per hex you'll get the real earth seas as a result.";
      this.CheckTypeNames[217] = "CheckAreaslotSpecial";
      this.CheckTypeVarCount[217] = 4;
      this.CheckTypeVarName[217, 1] = "Areaslot#";
      this.CheckTypeVarName[217, 2] = "SpecialType";
      this.CheckTypeVarName[217, 3] = "Second Areaslot#";
      this.CheckTypeVarName[217, 4] = "Second Areaslot Value";
      this.CheckCategory[217] = 12;
      this.CheckDesc[217] = "SpecialType 1 is highest, 2 is lowest, 3 is average. You can specify -1 to not use optional second areaslot. If you do however you can limit the hexes being read to those with the specified value";
      this.CheckTypeNames[220] = "CheckStringListQuick";
      this.CheckTypeVarCount[220] = 3;
      this.CheckTypeVarName[220, 1] = "Stringlist ID";
      this.CheckTypeVarName[220, 2] = "Row where col0 has value..";
      this.CheckTypeVarName[220, 3] = "Col";
      this.CheckCategory[220] = 6;
      this.CheckTypeNames[221] = "CheckAreaCount";
      this.CheckTypeVarCount[221] = 3;
      this.CheckTypeVarName[221, 1] = "Areaslot#";
      this.CheckTypeVarName[221, 2] = "From";
      this.CheckTypeVarName[221, 3] = "Too";
      this.CheckCategory[221] = 12;
      this.CheckDesc[221] = "Returns the number of hex equal or between FROM and TOO.";
      this.CheckTypeNames[224] = "CheckStringPart";
      this.CheckTypeVarCount[224] = 2;
      this.CheckTypeVarName[224, 1] = "String";
      this.CheckTypeVarName[224, 2] = "Part #";
      this.CheckCategory[224] = 3;
      this.CheckDesc[224] = "Returns the stringpart specified. Remember @ is used as a seperator. ";
      this.CheckTypeNames[225] = "CheckStringPartCounter";
      this.CheckTypeVarCount[225] = 1;
      this.CheckTypeVarName[225, 1] = "String";
      this.CheckCategory[225] = 3;
      this.CheckDesc[225] = "Returns the number of string parts in the string. Remember @ is used as a seperator. ";
      this.CheckTypeNames[218] = "CheckSqrt";
      this.CheckTypeVarCount[218] = 1;
      this.CheckTypeVarName[218, 1] = "Number";
      this.CheckCategory[218] = 3;
      this.CheckDesc[218] = "Returns the square root of the number.";
      this.CheckTypeNames[219] = "CheckRandomNumber";
      this.CheckTypeVarCount[219] = 2;
      this.CheckTypeVarName[219, 1] = "Number1";
      this.CheckTypeVarName[219, 2] = "Number2";
      this.CheckCategory[219] = 3;
      this.CheckDesc[219] = "Returns a random number including and between number1 and number2 ";
      this.CheckTypeNames[222] = "CheckPercentage";
      this.CheckTypeVarCount[222] = 2;
      this.CheckTypeVarName[222, 1] = "Number 1 (part)";
      this.CheckTypeVarName[222, 2] = "Number 2 (total)";
      this.CheckCategory[222] = 3;
      this.CheckDesc[222] = "Returns how much percentage points number 1 if of number 2.";
      this.CheckTypeNames[223] = "CheckNeighbour";
      this.CheckTypeVarCount[223] = 4;
      this.CheckTypeVarName[223, 1] = "X";
      this.CheckTypeVarName[223, 2] = "Y";
      this.CheckTypeVarName[223, 3] = "Direction";
      this.CheckTypeVarName[223, 4] = "Mode";
      this.CheckCategory[223] = 4;
      this.CheckDesc[223] = "Direction=1-6. Mode=1 returns X. Mode=2 returns Y. Returns -1 if neighbour is off-map.";
      this.CheckTypeNames[226] = "CheckSqrt2";
      this.CheckTypeVarCount[226] = 3;
      this.CheckTypeVarName[226, 1] = "Number";
      this.CheckTypeVarName[226, 2] = "Number square roots";
      this.CheckTypeVarName[226, 3] = "Multiply result by";
      this.CheckCategory[226] = 3;
      this.CheckDesc[226] = "Returns the square root of the number. Allow for betting calculation of floating point numbers.";
      this.CheckTypeNames[227] = "CheckDecimal";
      this.CheckTypeVarCount[227] = 3;
      this.CheckTypeVarName[227, 1] = "Number";
      this.CheckTypeVarName[227, 2] = "Divided by number";
      this.CheckTypeVarName[227, 3] = "Maximum decimals";
      this.CheckCategory[227] = 3;
      this.CheckDesc[227] = "Returns a text string with the decimal number.";
      this.CheckTypeNames[228] = "CheckLogicPart";
      this.CheckTypeVarCount[228] = 2;
      this.CheckTypeVarName[228, 1] = "String";
      this.CheckTypeVarName[228, 2] = "Part # (1-3)";
      this.CheckCategory[228] = 3;
      this.CheckDesc[228] = "Returns the logicpart specified as string. Remember <,>,=,/,*,+,- is used as a seperator as well as logic part 2. ";
      this.CheckTypeNames[229] = "CheckKeyExists";
      this.CheckTypeVarCount[229] = 2;
      this.CheckTypeVarName[229, 1] = "Stringlist ID";
      this.CheckTypeVarName[229, 2] = "Key name";
      this.CheckCategory[229] = 6;
      this.CheckDesc[229] = "If key exists returns 1 otherwise 0 ";
      this.CheckTypeNames[230] = "CheckDynamicElementHeight";
      this.CheckTypeVarCount[230] = 1;
      this.CheckTypeVarName[230, 1] = "Full Element Text";
      this.CheckDesc[230] = "Returns the number of pixels of height ";
      this.CheckCategory[230] = 3;
      this.CheckTypeNames[231] = "CheckReplaceFlags";
      this.CheckTypeVarCount[231] = 2;
      this.CheckTypeVarName[231, 1] = "String";
      this.CheckTypeVarName[231, 2] = "Stringlist ID for Flags";
      this.CheckDesc[231] = "Returns a string equal to the string passed but with any [flags] removed. Flag name will be looked for in stringlist col0 and replaced by value in col1. ";
      this.CheckCategory[231] = 3;
      this.CheckTypeNames[232] = "CheckLookupValue";
      this.CheckTypeVarCount[232] = 1;
      this.CheckTypeVarName[232, 1] = "LookupString";
      this.CheckDesc[232] = "Returns string or number on a hardcoded basis. If hardcoded LookupString is not found original String is returned. See documentation.";
      this.CheckCategory[232] = 3;
      this.CheckTypeNames[233] = "CheckFirstActionCardWith";
      this.CheckTypeVarCount[233] = 4;
      this.CheckTypeVarName[233, 1] = "Regime # (or -1 for all actioncards)";
      this.CheckTypeVarName[233, 2] = "Tempvar0 (or -1 if ignore)";
      this.CheckTypeVarName[233, 3] = "Tempvar1 (or -1 if ignore)";
      this.CheckTypeVarName[233, 4] = "Library name (or empty for ignore)";
      this.CheckCategory[233] = 2;
      this.CheckDesc[233] = "Returns the actioncard slot# of the first card in the hand of specified regime with those exact tempvar values. If not found returns -1.";
      this.CheckTypeNames[234] = "CheckMultiplyByVerySmallNumber";
      this.CheckTypeVarCount[234] = 3;
      this.CheckTypeVarName[234, 1] = "Value as string";
      this.CheckTypeVarName[234, 2] = "Multiplier";
      this.CheckTypeVarName[234, 3] = "Number of comma shifts";
      this.CheckCategory[234] = 3;
      this.CheckDesc[234] = "Value as string allows you to work with long numbers. Number of comma shifts is applied to multiplier and then the value is multiplied by the multiplier. For exame value=1000, multiplier=5 and comma shift 2 results in 0.05*1000=50. Maximum 10 comma shifts.";
      this.CheckTypeNames[235] = "CheckSqrt3";
      this.CheckTypeVarCount[235] = 4;
      this.CheckTypeVarName[235, 1] = "Number a";
      this.CheckTypeVarName[235, 2] = "Divide by number b";
      this.CheckTypeVarName[235, 3] = "Number of square roots";
      this.CheckTypeVarName[235, 4] = "Multiply by number c";
      this.CheckCategory[235] = 3;
      this.CheckDesc[235] = "Returns (the square root of (the number a / number b)) multiplied by number c. Allow for betting calculation of floating point numbers.";
      this.CheckTypeNames[236] = "CheckPowerLong";
      this.CheckTypeVarCount[236] = 1;
      this.CheckTypeVarName[236, 1] = "Number";
      this.CheckCategory[236] = 3;
      this.CheckDesc[236] = "Returns the power of the number as as string, allowing you to work with long numbers.";
      this.CheckTypeNames[237] = "CheckStringListTotal";
      this.CheckTypeVarCount[237] = 4;
      this.CheckTypeVarName[237, 1] = "Stringlist ID";
      this.CheckTypeVarName[237, 2] = "Col# ";
      this.CheckTypeVarName[237, 3] = "Must have value";
      this.CheckTypeVarName[237, 4] = "Add up values in col2#";
      this.CheckCategory[237] = 6;
      this.CheckDesc[237] = "If you put -1 for Col# than all values will be added up.";
      this.CheckTypeNames[238] = "CheckRegimeID";
      this.CheckTypeVarCount[238] = 1;
      this.CheckTypeVarName[238, 1] = "RegimeSlot#";
      this.CheckCategory[238] = 2;
      this.CheckTypeNames[239] = "CheckLocationID";
      this.CheckTypeVarCount[239] = 1;
      this.CheckTypeVarName[239, 1] = "LocationSlot#";
      this.CheckCategory[239] = 4;
      this.CheckTypeNames[240] = "CheckLocationSlot";
      this.CheckTypeVarCount[240] = 1;
      this.CheckTypeVarName[240, 1] = "Location ID";
      this.CheckCategory[240] = 4;
      this.CheckTypeNames[241] = "CheckRegimeSlot";
      this.CheckTypeVarCount[241] = 1;
      this.CheckTypeVarName[241, 1] = "Regime ID";
      this.CheckCategory[241] = 2;
      this.CheckTypeNames[242] = "CheckFindInStringList2";
      this.CheckTypeVarCount[242] = 4;
      this.CheckTypeVarName[242, 1] = "Stringlist ID";
      this.CheckTypeVarName[242, 2] = "In Col";
      this.CheckTypeVarName[242, 3] = "Find Value";
      this.CheckTypeVarName[242, 4] = "Col # must have value >0";
      this.CheckCategory[242] = 6;
      this.CheckDesc[242] = "Returns row# where value is found or -1 if not.";
      this.CheckTypeNames[259] = "CheckTempUDSInput";
      this.CheckTypeVarCount[259] = 1;
      this.CheckTypeVarName[259, 1] = "TEMP Key name";
      this.CheckCategory[259] = 11;
      this.CheckDesc[259] = "Returns TEMP UdsKey value for key";
      this.CheckTypeNames[247] = "CheckLogicString";
      this.CheckTypeVarCount[247] = 3;
      this.CheckTypeVarName[247, 1] = "Stringlist ID for Flags";
      this.CheckTypeVarName[247, 2] = "Stringlist ID for Flag Instructions";
      this.CheckTypeVarName[247, 3] = "Logic String";
      this.CheckCategory[247] = 12;
      this.CheckTypeNames[243] = "CheckLocationLISitem";
      this.CheckTypeVarCount[243] = 2;
      this.CheckTypeVarName[243, 1] = "Location Slot#";
      this.CheckTypeVarName[243, 2] = "LIS Item ID#";
      this.CheckCategory[243] = 12;
      this.CheckTypeNames[244] = "CheckUnitLISitem";
      this.CheckTypeVarCount[244] = 2;
      this.CheckTypeVarName[244, 1] = "Unit Slot#";
      this.CheckTypeVarName[244, 2] = "LIS Item ID#";
      this.CheckCategory[244] = 12;
      this.CheckTypeNames[248] = "CheckLIS";
      this.CheckTypeVarCount[248] = 3;
      this.CheckTypeVarName[248, 1] = "Loc nr";
      this.CheckTypeVarName[248, 2] = "To X";
      this.CheckTypeVarName[248, 3] = "To Y";
      this.CheckCategory[248] = 12;
      this.CheckTypeNames[249] = "CheckHardcodedIF";
      this.CheckTypeVarCount[249] = 3;
      this.CheckTypeVarName[249, 1] = "Hardcoded Number";
      this.CheckTypeVarName[249, 2] = "Story Id";
      this.CheckTypeVarName[249, 3] = "Instance 1 Id";
      this.CheckTypeVarName[249, 4] = "Instance 2 Id";
      this.CheckCategory[249] = 12;
      this.CheckTypeNames[245] = "CheckDoubleKey";
      this.CheckTypeVarCount[245] = 3;
      this.CheckTypeVarName[245, 1] = "Stringlist ID";
      this.CheckTypeVarName[245, 2] = "Col 0 value";
      this.CheckTypeVarName[245, 3] = "Col 1 Key name";
      this.CheckCategory[245] = 6;
      this.CheckDesc[245] = "Presumes an ID value in col 0 and key names in column 1 and values to look up in column 2 ";
      this.CheckTypeNames[246] = "CheckDoubleKeyExists";
      this.CheckTypeVarCount[246] = 3;
      this.CheckTypeVarName[246, 1] = "Stringlist ID";
      this.CheckTypeVarName[246, 2] = "Col 0 value";
      this.CheckTypeVarName[246, 3] = "Col 1 Key name";
      this.CheckCategory[246] = 6;
      this.CheckDesc[246] = "If key exists returns 1 otherwise 0 ";
      this.CheckTypeNames[250] = "CheckGetReinfTypeByLib";
      this.CheckTypeVarCount[250] = 2;
      this.CheckTypeVarName[250, 1] = "Library Name";
      this.CheckTypeVarName[250, 2] = "ID";
      this.CheckCategory[250] = 10;
      this.CheckDesc[250] = "Returns the ID of the Reinf.Type in the current scenario.  ";
      this.CheckTypeNames[251] = "ChecSFTypeFav";
      this.CheckTypeVarCount[251] = 3;
      this.CheckTypeVarName[251, 1] = "SfType #";
      this.CheckTypeVarName[251, 2] = "Targetgroup#";
      this.CheckTypeVarName[251, 3] = "Type 1=favscore for regular attack, 2=for artillery attack";
      this.CheckCategory[251] = 7;
      this.CheckTypeNames[252] = "ChecSFTypeArtPower";
      this.CheckTypeVarCount[252] = 2;
      this.CheckTypeVarName[252, 1] = "SfType #";
      this.CheckTypeVarName[252, 2] = "Targetgroup#";
      this.CheckCategory[252] = 7;
      this.CheckTypeNames[253] = "ChecSFTypeStat";
      this.CheckTypeVarCount[253] = 2;
      this.CheckTypeVarName[253, 1] = "SfType #";
      this.CheckTypeVarName[253, 2] = "StatNumber";
      this.CheckCategory[253] = 7;
      this.CheckDesc[253] = "Stat Numbers: 1=weight, 2=carrycap, 3=canDoParadrop(0/1), 4=EP, 5=BlowBridgPts, 6=BasicSupNeed, 7=SupCarry, 8=ReconPts, 9=HidePts, 10=AntiSupplyPts, 11=AntiSupplyRange, 12=AnitSupplySea, 13=InitiativeAtt, 14=InitiativeDef, 15=Attacks, 16=StackPts, 17=RearArea(0/1), 18=ArtRange, 19=Fav.Target tries, 20=AA-range, 21=HitKill%, 22=HitRetreat%, 23=ArtilleryModSfTypeNr, 24=maxAttacked, 25=moveRedux";
      this.CheckTypeNames[254] = "ChecSFTypeLandscapeMod";
      this.CheckTypeVarCount[254] = 4;
      this.CheckTypeVarName[254, 1] = "SfType #";
      this.CheckTypeVarName[254, 2] = "LandscapeType#";
      this.CheckTypeVarName[254, 3] = "Type 1=offMod %, 2=defMod %.. 100=noMod, 50=half, 200=double";
      this.CheckCategory[254] = 7;
      this.CheckTypeNames[257] = "CheckHexLocNr2";
      this.CheckTypeVarCount[257] = 2;
      this.CheckTypeVarName[257, 1] = "X";
      this.CheckTypeVarName[257, 2] = "Y";
      this.CheckCategory[257] = 4;
      this.CheckDesc[257] = "Only use of Supply Bases and Sources. Returns -1 if no Location in hex. 0 or higher if present.";
      this.CheckTypeNames[258] = "CheckLocTypeXY2";
      this.CheckTypeVarCount[258] = 2;
      this.CheckTypeVarName[258, 1] = "X";
      this.CheckTypeVarName[258, 2] = "Y";
      this.CheckCategory[258] = 4;
      this.CheckTypeNames[260] = "CheckLibraryOfSFType";
      this.CheckTypeVarCount[260] = 1;
      this.CheckTypeVarName[260, 1] = "SFType Slot";
      this.CheckCategory[260] = 10;
      this.CheckDesc[260] = "Returns a string with the library name.  ";
      this.CheckTypeNames[261] = "CheckDLC";
      this.CheckTypeVarCount[261] = 1;
      this.CheckTypeVarName[261, 1] = "DLC ID Code";
      this.CheckCategory[261] = 10;
      this.CheckDesc[261] = "Not documented. Usage by other than Vic is not advised.";
      this.CheckTypeNames[262] = "CheckLibraryOfThisEvent";
      this.CheckTypeVarCount[262] = 0;
      this.CheckTypeVarName[262, 1] = "";
      this.CheckCategory[262] = 10;
      this.CheckDesc[262] = "Returns a string with the library name.  ";
      this.CheckTypeNames[263] = "CheckGetDateStringForRoundX";
      this.CheckTypeVarCount[263] = 0;
      this.CheckTypeVarCount[263] = 1;
      this.CheckTypeVarName[263, 1] = "Round";
      this.CheckCategory[263] = 3;
      this.CheckDesc[263] = "Returns a string thats date formatted.";
      this.CheckTypeCount = 263;
      this.ExecCategoryName[1] = "Regimes, People, Research";
      this.ExecCategoryName[2] = "Group Troop/Unit modifications";
      this.ExecCategoryName[3] = "Messanging, Campaign, Sound";
      this.ExecCategoryName[4] = "Hex & Areaslots";
      this.ExecCategoryName[5] = "Action Cards";
      this.ExecCategoryName[6] = "Logic & Vars";
      this.ExecCategoryName[7] = "AI in General";
      this.ExecCategoryName[8] = "Modifying Units";
      this.ExecCategoryName[9] = "SFtype & Itemtypes";
      this.ExecCategoryName[10] = "Game";
      this.ExecCategoryName[11] = "Landscapetypes";
      this.ExecCategoryName[12] = "Officerpool";
      this.ExecCategoryName[13] = "Historical Units";
      this.ExecCategoryName[14] = "Mods of movetype/unitgrouptype";
      this.ExecCategoryName[15] = "Location(types)";
      this.ExecCategoryName[16] = "Stringlists";
      this.ExecCategoryName[17] = "Miscellaneous";
      this.ExecCategoryName[18] = "DC1 AI";
      this.ExecCategoryName[19] = "DC2 AI";
      this.ExecCategoryName[20] = "Library Execs";
      this.ExecCategoryName[21] = "UDS";
      this.ExecCategoryName[22] = "Random Related";
      this.ExecTypeNames[1] = "ExecGiveRegimePP";
      this.ExecTypeVarCount[1] = 2;
      this.ExecTypeVarName[1, 1] = "RegimeNr";
      this.ExecTypeVarName[1, 2] = "PP";
      this.ExecCategory[1] = 1;
      this.ExecTypeNames[2] = "OldStyleMessage (DEPRECIATED)";
      this.ExecTypeVarCount[2] = 4;
      this.ExecTypeVarName[2, 1] = "Regime1";
      this.ExecTypeVarName[2, 2] = "Regime2";
      this.ExecTypeVarName[2, 3] = "BackPic#";
      this.ExecTypeVarName[2, 4] = "FrontPic#";
      this.ExecTypeString[2] = 1;
      this.ExecCategory[2] = 3;
      this.ExecDesc[2] = "Is depreciated. Avoid using it";
      this.ExecTypeNames[3] = "ExecChangeDip (DEPRECIATED)";
      this.ExecTypeVarCount[3] = 2;
      this.ExecTypeVarName[3, 1] = "RegimeNr1";
      this.ExecTypeVarName[3, 2] = "RegimeNr2";
      this.ExecCategory[3] = 1;
      this.ExecDesc[3] = "Reverses the diplomatic relation from war to peace. Or from peace to war. Use a check to see current relation. IS DEPRECIATED. USE EXECCHANGERELATION INSTEAD.";
      this.ExecTypeNames[4] = "ExecSetWinner";
      this.ExecTypeVarCount[4] = 1;
      this.ExecTypeVarName[4, 1] = "RegimeNr";
      this.ExecCategory[4] = 10;
      this.ExecTypeNames[5] = "ExecAddRegimeMorale";
      this.ExecTypeVarCount[5] = 2;
      this.ExecTypeVarName[5, 1] = "RegimeNr";
      this.ExecTypeVarName[5, 2] = "Mutation +/- pts";
      this.ExecCategory[5] = 1;
      this.ExecTypeNames[6] = "ExecAddUnit";
      this.ExecTypeVarCount[6] = 4;
      this.ExecTypeVarName[6, 1] = "UnitPreDef#";
      this.ExecTypeVarName[6, 2] = "X";
      this.ExecTypeVarName[6, 3] = "Y";
      this.ExecTypeVarName[6, 4] = "Regime#";
      this.ExecTypeString[6] = 2;
      this.ExecCategory[6] = 8;
      this.ExecTypeNames[7] = "ExecLoad";
      this.ExecTypeString[7] = 2;
      this.ExecCategory[7] = 3;
      this.ExecTypeNames[8] = "ExecSetSleep";
      this.ExecTypeVarCount[8] = 2;
      this.ExecTypeVarName[8, 1] = "Regime#";
      this.ExecTypeVarName[8, 2] = "Sleep=1, Awake=0";
      this.ExecCategory[8] = 1;
      this.ExecTypeNames[9] = "ExecJoinRegime";
      this.ExecTypeVarCount[9] = 3;
      this.ExecTypeVarName[9, 1] = "Losing Regime#";
      this.ExecTypeVarName[9, 2] = "Added to Regime#";
      this.ExecTypeVarName[9, 3] = "Including Units 1=yes,0=no";
      this.ExecCategory[9] = 1;
      this.ExecTypeNames[11] = "ExecMessage";
      this.ExecTypeVarCount[11] = 4;
      this.ExecTypeVarName[11, 1] = "Regime1";
      this.ExecTypeVarName[11, 2] = "Regime2";
      this.ExecTypeVarName[11, 3] = "Overwrite scndesc >0=yes";
      this.ExecTypeVarName[11, 4] = "Event Pic Nr (-1=none)";
      this.ExecTypeString[11] = 1;
      this.ExecCategory[11] = 3;
      this.ExecDesc[11] = "if reg1=-1 and reg2=-1 then message is send to all regimes. ";
      this.ExecTypeNames[12] = "BlockEvent";
      this.ExecTypeVarCount[12] = 0;
      this.ExecCategory[12] = 6;
      this.ExecTypeNames[13] = "ExecChangeRegimeName";
      this.ExecTypeVarCount[13] = 1;
      this.ExecTypeVarName[13, 1] = "Regime#";
      this.ExecTypeString[13] = 2;
      this.ExecCategory[13] = 1;
      this.ExecTypeNames[14] = "ExecJoinArea";
      this.ExecTypeVarCount[14] = 4;
      this.ExecTypeVarName[14, 1] = "Areaslot# (0-9)";
      this.ExecTypeVarName[14, 2] = "Areacode";
      this.ExecTypeVarName[14, 3] = "To Regime#";
      this.ExecTypeVarName[14, 4] = "Units flee too areacode (-1=destr,-2=keephex)";
      this.ExecDesc[14] = "All units not allied with the new owner will be either flee or be destroyed or removed or keep hex.";
      this.ExecCategory[14] = 4;
      this.ExecTypeNames[15] = "ExecDisbandUnits";
      this.ExecTypeVarCount[15] = 2;
      this.ExecTypeVarName[15, 1] = "Regime#";
      this.ExecTypeVarName[15, 2] = "People#";
      this.ExecCategory[15] = 2;
      this.ExecTypeNames[16] = "ExecChangeDipBlock";
      this.ExecTypeVarCount[16] = 1;
      this.ExecTypeVarName[16, 1] = "Regime#";
      this.ExecCategory[16] = 1;
      this.ExecTypeNames[17] = "ExecDoStructuralDamage";
      this.ExecTypeVarCount[17] = 3;
      this.ExecTypeVarName[17, 1] = "x";
      this.ExecTypeVarName[17, 2] = "y";
      this.ExecTypeVarName[17, 3] = "damage pts";
      this.ExecCategory[17] = 4;
      this.ExecDesc[17] = "If you give negative ammount of points it is handled as a repair";
      this.ExecTypeNames[18] = "ExecSetLandscape";
      this.ExecTypeVarCount[18] = 3;
      this.ExecTypeVarName[18, 1] = "X";
      this.ExecTypeVarName[18, 2] = "Y";
      this.ExecTypeVarName[18, 3] = "New LT#";
      this.ExecCategory[18] = 4;
      this.ExecTypeNames[19] = "ExecSetSprite";
      this.ExecTypeVarCount[19] = 3;
      this.ExecTypeVarName[19, 1] = "X";
      this.ExecTypeVarName[19, 2] = "Y";
      this.ExecTypeVarName[19, 3] = "New Sprite#";
      this.ExecCategory[19] = 4;
      this.ExecTypeNames[20] = "ExecSetSlot";
      this.ExecTypeVarCount[20] = 4;
      this.ExecTypeVarName[20, 1] = "X";
      this.ExecTypeVarName[20, 2] = "Y";
      this.ExecTypeVarName[20, 3] = "AreaSlot";
      this.ExecTypeVarName[20, 4] = "AreaCode";
      this.ExecCategory[20] = 4;
      this.ExecTypeNames[21] = "ExecChangePeopleCombatMod";
      this.ExecTypeVarCount[21] = 3;
      this.ExecTypeVarName[21, 1] = "People#";
      this.ExecTypeVarName[21, 2] = "PeopleGroupOwner#";
      this.ExecTypeVarName[21, 3] = "New Combat Mod in %";
      this.ExecCategory[21] = 1;
      this.ExecTypeNames[22] = "ExecMoveTypeModifier";
      this.ExecTypeVarCount[22] = 2;
      this.ExecTypeVarName[22, 1] = "MoveType#";
      this.ExecTypeVarName[22, 2] = "Percentage of normal movecost (100%=normal)";
      this.ExecCategory[22] = 14;
      this.ExecTypeNames[23] = "ExecUnitTypeModifier";
      this.ExecTypeVarCount[23] = 2;
      this.ExecTypeVarName[23, 1] = "UnitType#";
      this.ExecTypeVarName[23, 2] = "Percentage of normal combat att/def (100%=normal)";
      this.ExecCategory[23] = 14;
      this.ExecTypeNames[24] = "ExecWheaterColor";
      this.ExecTypeVarCount[24] = 3;
      this.ExecTypeVarName[24, 1] = "Red Component (0=no change, 255=full)";
      this.ExecTypeVarName[24, 2] = "Green Component (0=no change, 255=full)";
      this.ExecTypeVarName[24, 3] = "Blue Component (0=no change, 255=full)";
      this.ExecCategory[24] = 17;
      this.ExecDesc[24] = "Changes the colour of the prehex sprite. But only of its core sprite not if its optional 64 border sprites.";
      this.ExecTypeNames[25] = "ExecChangeRiver";
      this.ExecTypeVarCount[25] = 4;
      this.ExecTypeVarName[25, 1] = "X";
      this.ExecTypeVarName[25, 2] = "Y";
      this.ExecTypeVarName[25, 3] = "From River #";
      this.ExecTypeVarName[25, 4] = "Too River #";
      this.ExecCategory[25] = 4;
      this.ExecTypeNames[26] = "ExecChangeRoad";
      this.ExecTypeVarCount[26] = 4;
      this.ExecTypeVarName[26, 1] = "X";
      this.ExecTypeVarName[26, 2] = "Y";
      this.ExecTypeVarName[26, 3] = "From Road #";
      this.ExecTypeVarName[26, 4] = "Too Road #";
      this.ExecCategory[26] = 4;
      this.ExecTypeNames[27] = "ExecChangeBridge";
      this.ExecTypeVarCount[27] = 4;
      this.ExecTypeVarName[27, 1] = "X";
      this.ExecTypeVarName[27, 2] = "Y";
      this.ExecTypeVarName[27, 3] = "Direction = 0(North),1,2,3,4,5(NorthWest)";
      this.ExecTypeVarName[27, 4] = "-1=no bridge, >=0 = bridge";
      this.ExecCategory[27] = 4;
      this.ExecTypeNames[28] = "AI_SetAIVP";
      this.ExecTypeVarCount[28] = 4;
      this.ExecTypeVarName[28, 1] = "X";
      this.ExecTypeVarName[28, 2] = "Y";
      this.ExecTypeVarName[28, 3] = "Regime Nr#";
      this.ExecTypeVarName[28, 4] = "AIVP amount. 0(none) - 999";
      this.ExecCategory[28] = 18;
      this.ExecCategory[28] = 19;
      this.ExecTypeNames[29] = "ExecChangeLocationType";
      this.ExecTypeVarCount[29] = 4;
      this.ExecTypeVarName[29, 1] = "X";
      this.ExecTypeVarName[29, 2] = "Y";
      this.ExecTypeVarName[29, 3] = "Loctype (-1=remove any location)";
      this.ExecTypeVarName[29, 4] = "People #";
      this.ExecTypeString[29] = 2;
      this.ExecCategory[29] = 4;
      this.ExecTypeNames[30] = "ExecGiveSupply";
      this.ExecTypeVarCount[30] = 4;
      this.ExecTypeVarName[30, 1] = "X ";
      this.ExecTypeVarName[30, 2] = "Y";
      this.ExecTypeVarName[30, 3] = "Supply Points to the top hq of the closest hq to x,y";
      this.ExecTypeVarName[30, 4] = "Overrule recipient regime with regime #";
      this.ExecDesc[30] = "Overule recipient is inactive if put to 0. If no overrule the supplies are given to closest unit owned by regime that owns hex. But >0 is overrule 1=reg 0, 2=reg1 !!!! This +1 shift is inhere to keep backwards compatible with AdvTactics scenarios.";
      this.ExecCategory[30] = 4;
      this.ExecTypeNames[31] = "ExecSetRuleVar";
      this.ExecTypeVarCount[31] = 3;
      this.ExecTypeVarName[31, 1] = "Rulevar # ";
      this.ExecTypeVarName[31, 2] = "New Value";
      this.ExecTypeVarName[31, 3] = "Behind comma... 0=no action.. >0=divide new value by 100 to set a decimal.";
      this.ExecCategory[31] = 10;
      this.ExecTypeNames[32] = "ExecChangePeople";
      this.ExecTypeVarCount[32] = 3;
      this.ExecTypeVarName[32, 1] = "X";
      this.ExecTypeVarName[32, 2] = "Y";
      this.ExecTypeVarName[32, 3] = "Changes the people at location x,y";
      this.ExecCategory[32] = 4;
      this.ExecTypeNames[33] = "ExecGiveReinforcement";
      this.ExecTypeVarCount[33] = 4;
      this.ExecTypeVarName[33, 1] = "X";
      this.ExecTypeVarName[33, 2] = "Y";
      this.ExecTypeVarName[33, 3] = "Predef# to use";
      this.ExecTypeVarName[33, 4] = "Multiplier";
      this.ExecCategory[33] = 2;
      this.ExecTypeNames[34] = "ExecGiveActionCard";
      this.ExecTypeVarCount[34] = 2;
      this.ExecTypeVarName[34, 1] = "Card Nr";
      this.ExecTypeVarName[34, 2] = "Regime Nr";
      this.ExecCategory[34] = 5;
      this.ExecTypeNames[35] = "ExecReduceReadiness";
      this.ExecTypeVarCount[35] = 4;
      this.ExecTypeVarName[35, 1] = "Regime Nr (-1=all)";
      this.ExecTypeVarName[35, 2] = "People Nr (-1=all)";
      this.ExecTypeVarName[35, 3] = "%rdn loss";
      this.ExecTypeVarName[35, 4] = "%chance per unit";
      this.ExecCategory[35] = 2;
      this.ExecTypeNames[36] = "ExecAddHistoryActionCard";
      this.ExecTypeVarCount[36] = 2;
      this.ExecTypeVarName[36, 1] = "Card Nr";
      this.ExecTypeVarName[36, 2] = "Regime Nr";
      this.ExecCategory[36] = 5;
      this.ExecTypeNames[37] = "ExecRemoveHistoryActionCard";
      this.ExecTypeVarCount[37] = 2;
      this.ExecTypeVarName[37, 1] = "Card Nr";
      this.ExecTypeVarName[37, 2] = "Regime Nr";
      this.ExecCategory[37] = 5;
      this.ExecTypeNames[38] = "-Obsolete-";
      this.ExecTypeVarCount[38] = 4;
      this.ExecTypeVarName[38, 1] = "Regime Nr";
      this.ExecTypeVarName[38, 2] = "People Nr (-1=all)";
      this.ExecTypeVarName[38, 3] = "% morale loss";
      this.ExecTypeVarName[38, 4] = "%chance per unit";
      this.ExecCategory[38] = -1;
      this.ExecTypeNames[39] = "ExecLTReduceReadiness";
      this.ExecTypeVarCount[39] = 4;
      this.ExecTypeVarName[39, 1] = "Regime Nr";
      this.ExecTypeVarName[39, 2] = "People Nr (-1=all)";
      this.ExecTypeVarName[39, 3] = "%rdn loss";
      this.ExecTypeVarName[39, 4] = "LandscapeType Nr";
      this.ExecCategory[39] = 2;
      this.ExecTypeNames[40] = "ExecLTReduceMorale";
      this.ExecTypeVarCount[40] = 4;
      this.ExecTypeVarName[40, 1] = "Regime Nr";
      this.ExecTypeVarName[40, 2] = "People Nr (-1=all)";
      this.ExecTypeVarName[40, 3] = "%mor loss";
      this.ExecTypeVarName[40, 4] = "LandscapeType Nr";
      this.ExecCategory[40] = 2;
      this.ExecTypeNames[41] = "ExecSetItemCost";
      this.ExecTypeVarCount[41] = 2;
      this.ExecTypeVarName[41, 1] = "ItemType Nr";
      this.ExecTypeVarName[41, 2] = "Set Prod Cost";
      this.ExecCategory[41] = 9;
      this.ExecTypeNames[42] = "ExecSetBaseMorale";
      this.ExecTypeVarCount[42] = 2;
      this.ExecTypeVarName[42, 1] = "Regnr";
      this.ExecTypeVarName[42, 2] = "Basemorale";
      this.ExecCategory[42] = 1;
      this.ExecDesc[42] = "Not only sets base morale of regime, but also of unterregimes to the same as well as reducing all morale of all units with the same percentual ammount as the basemorale lost.";
      this.ExecTypeNames[43] = "ExecChangeVP";
      this.ExecTypeVarCount[43] = 3;
      this.ExecTypeVarName[43, 1] = "X";
      this.ExecTypeVarName[43, 2] = "Y";
      this.ExecTypeVarName[43, 3] = "new VP amount. 0(none) - 999";
      this.ExecCategory[43] = 4;
      this.ExecTypeNames[44] = "ExecRemoveActionCard";
      this.ExecTypeVarCount[44] = 2;
      this.ExecTypeVarName[44, 1] = "Card Nr";
      this.ExecTypeVarName[44, 2] = "Regime Nr";
      this.ExecCategory[44] = 5;
      this.ExecTypeNames[45] = "ExecAIConservative";
      this.ExecTypeVarCount[45] = 2;
      this.ExecTypeVarName[45, 1] = "Regime Nr";
      this.ExecTypeVarName[45, 2] = "Convervative.. 100% = normal >100% more defensive. <100 more aggressive";
      this.ExecCategory[45] = 18;
      this.ExecTypeNames[46] = "ExecPlayActionCard";
      this.ExecTypeVarCount[46] = 2;
      this.ExecTypeVarName[46, 1] = "Regime Nr";
      this.ExecTypeVarName[46, 2] = "Action Card Nr";
      this.ExecCategory[46] = 5;
      this.ExecTypeNames[47] = "ExecExecuteEvent";
      this.ExecTypeVarCount[47] = 1;
      this.ExecTypeVarName[47, 1] = "Event Nr";
      this.ExecCategory[47] = 6;
      this.ExecDesc[47] = "IS DEPRECIATED BY CallFunction. tempvar 0,1,4,5 are passed on (but not returned).";
      this.ExecTypeNames[48] = "ExecActionCardName";
      this.ExecTypeVarCount[48] = 1;
      this.ExecTypeVarName[48, 1] = "Actioncard Nr";
      this.ExecTypeString[48] = 2;
      this.ExecCategory[48] = 5;
      this.ExecTypeNames[49] = "ExecActionCardPPCost";
      this.ExecTypeVarCount[49] = 4;
      this.ExecTypeVarName[49, 1] = "Actioncard Nr";
      this.ExecTypeVarName[49, 2] = "New PPCost (-1 = keep same)";
      this.ExecTypeVarName[49, 3] = "PPCost absolute increase or decrease (0=no change)";
      this.ExecTypeVarName[49, 4] = "PPCost % increase or decrease (0=no % change)";
      this.ExecCategory[49] = 5;
      this.ExecTypeNames[50] = "ExecReplaceLandscapeSprite";
      this.ExecTypeVarCount[50] = 1;
      this.ExecTypeVarName[50, 1] = "Landscape nr";
      this.ExecTypeString[50] = 2;
      this.ExecCategory[50] = 11;
      this.ExecDesc[50] = "Actually loads a new PreHex graphic from the graphics directory.";
      this.ExecTypeNames[52] = "ExecMutateSFType";
      this.ExecTypeVarCount[52] = 4;
      this.ExecTypeVarName[52, 1] = "AreaSlot";
      this.ExecTypeVarName[52, 2] = "AreaCode";
      this.ExecTypeVarName[52, 3] = "From Sftype#";
      this.ExecTypeVarName[52, 4] = "Too Sftype# (-1=remove)";
      this.ExecCategory[52] = 2;
      this.ExecDesc[52] = "After completion sets # of changed individuals in tempvar[999].";
      this.ExecTypeNames[53] = "ExecSingleMutateSFType";
      this.ExecTypeVarCount[53] = 4;
      this.ExecTypeVarName[53, 1] = "AreaSlot";
      this.ExecTypeVarName[53, 2] = "AreaCode";
      this.ExecTypeVarName[53, 3] = "From Sftype#";
      this.ExecTypeVarName[53, 4] = "Too Sftype# (-1=remove)";
      this.ExecCategory[53] = 2;
      this.ExecDesc[53] = "Note: Currents turn units take precedence";
      this.ExecTypeNames[54] = "ExecSingleMutateSFTypeXY";
      this.ExecTypeVarCount[54] = 4;
      this.ExecTypeVarName[54, 1] = "X";
      this.ExecTypeVarName[54, 2] = "Y";
      this.ExecTypeVarName[54, 3] = "From Sftype#";
      this.ExecTypeVarName[54, 4] = "Too Sftype# (-1=remove)";
      this.ExecCategory[54] = 2;
      this.ExecDesc[54] = "Note: Currents turn units take precedence";
      this.ExecTypeNames[55] = "ExecAntiSupplyRangeMod";
      this.ExecTypeVarCount[55] = 2;
      this.ExecTypeVarName[55, 1] = "MoveType#";
      this.ExecTypeVarName[55, 2] = "Percentage of current AP (100%=normal)";
      this.ExecCategory[55] = 14;
      this.ExecTypeNames[56] = "ExecChangePeopleCombatModVS";
      this.ExecTypeVarCount[56] = 3;
      this.ExecTypeVarName[56, 1] = "People#";
      this.ExecTypeVarName[56, 2] = "Versus PeopleGroupOwner#";
      this.ExecTypeVarName[56, 3] = "New Combat Mod in %";
      this.ExecCategory[56] = 1;
      this.ExecTypeNames[57] = "ExecRemoveTroops";
      this.ExecTypeVarCount[57] = 4;
      this.ExecTypeVarName[57, 1] = "X";
      this.ExecTypeVarName[57, 2] = "Y";
      this.ExecTypeVarName[57, 3] = "SFType group";
      this.ExecTypeVarName[57, 4] = "Percentage to remove";
      this.ExecCategory[57] = 2;
      this.ExecTypeNames[58] = "ExecRemoveTroopsByPeople";
      this.ExecTypeVarCount[58] = 4;
      this.ExecTypeVarName[58, 1] = "X";
      this.ExecTypeVarName[58, 2] = "Y";
      this.ExecTypeVarName[58, 3] = "specific people #";
      this.ExecTypeVarName[58, 4] = "Percentage to remove";
      this.ExecCategory[58] = 2;
      this.ExecTypeNames[59] = "ExecRemoveTroopsByLowMorale";
      this.ExecTypeVarCount[59] = 4;
      this.ExecTypeVarName[59, 1] = "X";
      this.ExecTypeVarName[59, 2] = "Y";
      this.ExecTypeVarName[59, 3] = "Morale =< then";
      this.ExecTypeVarName[59, 4] = "Percentage to remove";
      this.ExecCategory[59] = 2;
      this.ExecTypeNames[60] = "ExecSetLabel [old]";
      this.ExecTypeVarCount[60] = 4;
      this.ExecTypeVarName[60, 1] = "X (tempvar999>0 overwrites datastring)";
      this.ExecTypeVarName[60, 2] = "Y";
      this.ExecTypeVarName[60, 3] = "Type (0-10)";
      this.ExecTypeVarName[60, 4] = "Slot (1-2)";
      this.ExecTypeString[60] = 2;
      this.ExecCategory[60] = 4;
      this.ExecDesc[60] = "If there is a value > 0 in tempvar999 it is ammended to the end of the string.";
      this.ExecTypeNames[61] = "ExecReadinessLossByArea";
      this.ExecTypeVarCount[61] = 4;
      this.ExecTypeVarName[61, 1] = "Areaslot";
      this.ExecTypeVarName[61, 2] = "Value of slot";
      this.ExecTypeVarName[61, 3] = "Readiness loss";
      this.ExecTypeVarName[61, 4] = "Chance to lose this (x%)";
      this.ExecCategory[61] = 2;
      this.ExecTypeNames[62] = "ExecOffensiveMod";
      this.ExecTypeVarCount[62] = 4;
      this.ExecTypeVarName[62, 1] = "X";
      this.ExecTypeVarName[62, 2] = "Y";
      this.ExecTypeVarName[62, 3] = "SfTypeGroup# (-1=all)";
      this.ExecTypeVarName[62, 4] = "Absolute Modifier (0=none, -50 = -50%, +50 = +50%)";
      this.ExecCategory[62] = 14;
      this.ExecTypeNames[63] = "ExecDefensiveMod";
      this.ExecTypeVarCount[63] = 4;
      this.ExecTypeVarName[63, 1] = "X";
      this.ExecTypeVarName[63, 2] = "Y";
      this.ExecTypeVarName[63, 3] = "SfTypeGroup# (-1=all)";
      this.ExecTypeVarName[63, 4] = "Absolute Modifier (0=none, -50 = -50%, +50 = +50%)";
      this.ExecCategory[63] = 14;
      this.ExecTypeNames[64] = "ExecOffensiveModByPeople";
      this.ExecTypeVarCount[64] = 4;
      this.ExecTypeVarName[64, 1] = "X";
      this.ExecTypeVarName[64, 2] = "Y";
      this.ExecTypeVarName[64, 3] = "People# (-1=all)";
      this.ExecTypeVarName[64, 4] = "Absolute Modifier (0=none, -50 = -50%, +50 = +50%)";
      this.ExecCategory[64] = 14;
      this.ExecTypeNames[65] = "ExecDefensiveModByPeople";
      this.ExecTypeVarCount[65] = 4;
      this.ExecTypeVarName[65, 1] = "X";
      this.ExecTypeVarName[65, 2] = "Y";
      this.ExecTypeVarName[65, 3] = "People# (-1=all)";
      this.ExecTypeVarName[65, 4] = "Absolute Modifier (0=none, -50 = -50%, +50 = +50%)";
      this.ExecCategory[65] = 14;
      this.ExecTypeNames[66] = "ExecOffensiveModByRegime";
      this.ExecTypeVarCount[66] = 4;
      this.ExecTypeVarName[66, 1] = "Regime # (-1=all)";
      this.ExecTypeVarName[66, 2] = "People # (-1=all)";
      this.ExecTypeVarName[66, 3] = "SfTypeGroup# (-1=all)";
      this.ExecTypeVarName[66, 4] = "Absolute Modifier (0=none, -50 = -50%, +50 = +50%)";
      this.ExecCategory[66] = 14;
      this.ExecTypeNames[67] = "ExecDefensiveModByRegime";
      this.ExecTypeVarCount[67] = 4;
      this.ExecTypeVarName[67, 1] = "Regime # (-1=all)";
      this.ExecTypeVarName[67, 2] = "People # (-1=all)";
      this.ExecTypeVarName[67, 3] = "SfTypeGroup# (-1=all)";
      this.ExecTypeVarName[67, 4] = "Absolute Modifier (0=none, -50 = -50%, +50 = +50%)";
      this.ExecCategory[67] = 14;
      this.ExecTypeNames[69] = "ExecLoad_UnitTransfer";
      this.ExecTypeVarCount[69] = 3;
      this.ExecTypeVarName[69, 1] = "Regime # ";
      this.ExecTypeVarName[69, 2] = "AreaSlot #";
      this.ExecTypeVarName[69, 3] = "Max Per Hex";
      this.ExecCategory[69] = 3;
      this.ExecTypeNames[72] = "ExecAreaSpreadOut";
      this.ExecTypeVarCount[72] = 2;
      this.ExecTypeVarName[72, 1] = "AreaSlot # ";
      this.ExecTypeVarName[72, 2] = "Divideby ";
      this.ExecCategory[72] = 4;
      this.ExecTypeNames[73] = "ExecSetLoctypeDestruct";
      this.ExecTypeVarCount[73] = 3;
      this.ExecTypeVarName[73, 1] = "LocType#";
      this.ExecTypeVarName[73, 2] = "LandscapeType#";
      this.ExecTypeVarName[73, 3] = "Sprite #";
      this.ExecCategory[73] = 15;
      this.ExecTypeNames[76] = "ExecCopyActionCard (+Set Name)";
      this.ExecTypeVarCount[76] = 2;
      this.ExecTypeVarName[76, 1] = "From#";
      this.ExecTypeVarName[76, 2] = "Too#";
      this.ExecTypeString[76] = 2;
      this.ExecCategory[76] = 5;
      this.ExecDesc[76] = "If the Too# specified is a slot higher then existing number of actioncards, the number of actioncards slots will be extended";
      this.ExecTypeNames[77] = "ExecSetActionCard (+Set Text)";
      this.ExecTypeVarCount[77] = 4;
      this.ExecTypeVarName[77, 1] = "Card#";
      this.ExecTypeVarName[77, 2] = "TempVar0";
      this.ExecTypeVarName[77, 3] = "TempVar1";
      this.ExecTypeVarName[77, 4] = "EventPic#";
      this.ExecTypeString[77] = 2;
      this.ExecCategory[77] = 5;
      this.ExecTypeNames[79] = "ExecGetReconFrom";
      this.ExecTypeVarCount[79] = 1;
      this.ExecTypeVarName[79, 1] = "From Regime#";
      this.ExecCategory[79] = 1;
      this.ExecTypeNames[80] = "ExecAddExperience";
      this.ExecTypeVarCount[80] = 4;
      this.ExecTypeVarName[80, 1] = "People# (-1=all)";
      this.ExecTypeVarName[80, 2] = "Points to add (+/-)";
      this.ExecTypeVarName[80, 3] = "Minimum XP";
      this.ExecTypeVarName[80, 4] = "Maximum XP";
      this.ExecTypeString[80] = 0;
      this.ExecCategory[80] = 2;
      this.ExecTypeNames[81] = "ExecMaxResearch";
      this.ExecTypeVarCount[81] = 0;
      this.ExecCategory[81] = 2;
      this.ExecDesc[81] = "Every Suformation thats not in a predef unit that can upgrade if its regime has the research will upgrade";
      this.ExecTypeNames[82] = "ExecHexActionCard";
      this.ExecTypeVarCount[82] = 3;
      this.ExecTypeVarName[82, 1] = "X";
      this.ExecTypeVarName[82, 2] = "Y";
      this.ExecTypeVarName[82, 3] = "ActionCard# (-1=no actioncard)";
      this.ExecTypeString[82] = 0;
      this.ExecCategory[82] = 5;
      this.ExecDesc[82] = "Will place an action card on the hex in question. The card is executed immediatly upon the player conquering the hex. And will cause a popup to appear immediatly (if message used) Only if hex is conquered by combat or direct move in. So always place on locations because they cannot be conquered by ZOC. If an AI regime takes the card it cannot load a new game, select a unit or a hex.";
      this.ExecTypeNames[83] = "ExecSetHistoricUnitMove";
      this.ExecTypeVarCount[83] = 4;
      this.ExecTypeVarName[83, 1] = "Historic HQ #";
      this.ExecTypeVarName[83, 2] = "Defend Defined Area #";
      this.ExecTypeVarName[83, 3] = "Attack Defined Area #";
      this.ExecTypeVarName[83, 4] = "Stance (1=def,2=norm,3=att)";
      this.ExecTypeString[83] = 0;
      this.ExecCategory[83] = 18;
      this.ExecTypeNames[84] = "ExecChangeAIPower";
      this.ExecTypeVarCount[84] = 4;
      this.ExecTypeVarName[84, 1] = "Regime";
      this.ExecTypeVarName[84, 2] = "X";
      this.ExecTypeVarName[84, 3] = "Y";
      this.ExecTypeVarName[84, 4] = "Power Points";
      this.ExecTypeString[84] = 0;
      this.ExecCategory[84] = 18;
      this.ExecDesc[84] = "If positive power points given it is meant to help influence the behaviour of the AI. This way you can set reinforcements to a certain regime in the area that hex x,y is in. But you can also use this function to set negative powerpoints versus a regime to simulate immediate pressure and force the AI to keep a certain reserve in the area.";
      this.ExecTypeNames[85] = "OBSOLETE";
      this.ExecTypeVarCount[85] = 2;
      this.ExecTypeVarName[85, 1] = "HQ";
      this.ExecTypeVarName[85, 2] = "Area";
      this.ExecTypeString[85] = 0;
      this.ExecTypeNames[86] = "OBSOLETE";
      this.ExecTypeVarCount[86] = 2;
      this.ExecTypeVarName[86, 1] = "HQ";
      this.ExecTypeVarName[86, 2] = "Area";
      this.ExecTypeString[86] = 0;
      this.ExecTypeNames[87] = "PNSOLETE";
      this.ExecTypeVarCount[87] = 2;
      this.ExecTypeVarName[87, 1] = "HQ";
      this.ExecTypeVarName[87, 2] = "HQ";
      this.ExecTypeString[87] = 0;
      this.ExecTypeNames[88] = "OBSOLETE";
      this.ExecTypeVarCount[88] = 2;
      this.ExecTypeVarName[88, 1] = "HQ";
      this.ExecTypeVarName[88, 2] = "HQ";
      this.ExecTypeString[88] = 0;
      this.ExecTypeNames[89] = "ExecPlayEventWav";
      this.ExecTypeVarCount[89] = 0;
      this.ExecTypeString[89] = 2;
      this.ExecCategory[89] = 3;
      this.ExecDesc[89] = "Adds a sound file from the sound directory to the next ExecMessage, it will be played when the message is actually shown. So the effect is synchronized.";
      this.ExecTypeNames[90] = "ExecLoadCampaignRoomBackground";
      this.ExecTypeVarCount[90] = 1;
      this.ExecTypeVarName[90, 1] = "Event Picture# to be used";
      this.ExecCategory[90] = 3;
      this.ExecTypeNames[91] = "ExecSetCampaignRoomTitle";
      this.ExecTypeVarCount[91] = 0;
      this.ExecTypeString[91] = 2;
      this.ExecCategory[91] = 3;
      this.ExecTypeNames[92] = "ExecPlayEventBackgroundWav";
      this.ExecTypeVarCount[92] = 0;
      this.ExecTypeString[92] = 2;
      this.ExecCategory[92] = 3;
      this.ExecDesc[92] = "Loads the sound file from the sound directory and plays it immediatly.";
      this.ExecTypeNames[93] = "-DEPRECIATED- ExecHistoricalUnitForAddUnit";
      this.ExecTypeVarCount[93] = 4;
      this.ExecTypeVarName[93, 1] = "Historical Unit#";
      this.ExecTypeVarName[93, 2] = "Copy? (1=yes,0=no)";
      this.ExecTypeVarName[93, 3] = "Number (only if copy)";
      this.ExecTypeVarName[93, 4] = "NATO counter # (only if copy, <1=keep same)";
      this.ExecTypeString[93] = 2;
      this.ExecCategory[93] = 2;
      this.ExecDesc[93] = "You should use ExecAddHistoricalUnit instead. Old description: If you want added units to be linked to a historical unit you have to call this exec before you call the addunit. If you make a copy, we'll use the given historical unit as a template but change its name to number + string. By putting a ',' in the string you can then specify the shortname. The shortname is always number+string. Once set it stays valid till changed or end of event in which it is declared.";
      this.ExecTypeNames[94] = "ExecSetAI";
      this.ExecTypeVarCount[94] = 3;
      this.ExecTypeVarName[94, 1] = "Regime #";
      this.ExecTypeVarName[94, 2] = "AI (1=yes,0=no)";
      this.ExecTypeVarName[94, 3] = "ProdBonus(0,100,250)";
      this.ExecCategory[94] = 7;
      this.ExecDesc[94] = "If you want to set a regime to AI player or make an AI a human player. ";
      this.ExecTypeNames[95] = "ExecUnitRdnModify";
      this.ExecTypeVarCount[95] = 4;
      this.ExecTypeVarName[95, 1] = "Unit #";
      this.ExecTypeVarName[95, 2] = "Absolute modifier pts +/-";
      this.ExecTypeVarName[95, 3] = "People (-1=all)";
      this.ExecTypeVarName[95, 4] = "SFTypeGroup (-1=all)";
      this.ExecCategory[95] = 8;
      this.ExecDesc[95] = "Change stats of subformations in a specified unit.";
      this.ExecTypeNames[96] = "ExecUnitMorModify";
      this.ExecTypeVarCount[96] = 4;
      this.ExecTypeVarName[96, 1] = "Unit #";
      this.ExecTypeVarName[96, 2] = "Absolute modifier pts +/-";
      this.ExecTypeVarName[96, 3] = "People (-1=all)";
      this.ExecTypeVarName[96, 4] = "SFTypeGroup (-1=all)";
      this.ExecCategory[96] = 8;
      this.ExecDesc[96] = "Change stats of subformations in a specified unit.";
      this.ExecTypeNames[97] = "ExecUnitXpModify";
      this.ExecTypeVarCount[97] = 4;
      this.ExecTypeVarName[97, 1] = "Unit #";
      this.ExecTypeVarName[97, 2] = "Absolute modifier pts +/-";
      this.ExecTypeVarName[97, 3] = "People (-1=all)";
      this.ExecTypeVarName[97, 4] = "SFTypeGroup (-1=all)";
      this.ExecCategory[97] = 8;
      this.ExecDesc[97] = "Change stats of subformations in a specified unit.";
      this.ExecTypeNames[98] = "ExecUnitApModify";
      this.ExecTypeVarCount[98] = 4;
      this.ExecTypeVarName[98, 1] = "Unit #";
      this.ExecTypeVarName[98, 2] = "Absolute modifier pts +/-";
      this.ExecTypeVarName[98, 3] = "MoveTypeGroup (-1=all)";
      this.ExecTypeVarName[98, 4] = "SFTypeGroup (-1=all)";
      this.ExecCategory[98] = 8;
      this.ExecDesc[98] = "Change stats of subformations in a specified unit.";
      this.ExecTypeNames[99] = "ExecUnitGiveTroops";
      this.ExecTypeVarCount[99] = 2;
      this.ExecTypeVarName[99, 1] = "Unit #";
      this.ExecTypeVarName[99, 2] = "Predef Unit#";
      this.ExecCategory[99] = 8;
      this.ExecDesc[99] = "Add all troops in PreDef unit to this Unit.";
      this.ExecTypeNames[100] = "ExecUnitOffensiveBonus";
      this.ExecTypeVarCount[100] = 4;
      this.ExecTypeVarName[100, 1] = "Unit #";
      this.ExecTypeVarName[100, 2] = "Absolute modifier pts +/-";
      this.ExecTypeVarName[100, 3] = "People (-1=all)";
      this.ExecTypeVarName[100, 4] = "SFTypeGroup (-1=all) (>=100 = specific sftype -100) (9001=only for artRange>0)";
      this.ExecCategory[100] = 8;
      this.ExecDesc[100] = "Change stats of subformations in a specified unit. If you set modifier to 0 it resets the offmod to 0. Each point is a percentage point. If you specify a sftypegroup >=100 then you are actually specifiying a specific SFType Nr.";
      this.ExecTypeNames[101] = "ExecUnitDefensiveBonus";
      this.ExecTypeVarCount[101] = 4;
      this.ExecTypeVarName[101, 1] = "Unit #";
      this.ExecTypeVarName[101, 2] = "Absolute modifier pts +/-";
      this.ExecTypeVarName[101, 3] = "People (-1=all)";
      this.ExecTypeVarName[101, 4] = "SFTypeGroup (-1=all)  (>=100 = specific sftype -100)";
      this.ExecCategory[101] = 8;
      this.ExecDesc[101] = "Change stats of subformations in a specified unit. If you set the modifier to 0 it resets the defmod to 0. Each point is a percentage point.  If you specify a sftypegroup >=100 then you are actually specifiying a specific SFType Nr.";
      this.ExecTypeNames[102] = "ExecUnitSelectable";
      this.ExecTypeVarCount[102] = 1;
      this.ExecTypeVarName[102, 1] = "Unit #";
      this.ExecCategory[102] = 8;
      this.ExecDesc[102] = "The specified unit will now be selectable in the 'select a unit' popup screen. Use this exec in a pre-event from an actioncard.";
      this.ExecTypeNames[103] = "ExecSetMessageStyle <DEPRECIACTED>";
      this.ExecTypeVarCount[103] = 1;
      this.ExecTypeVarName[103, 1] = "Message Style (0,1,2)";
      this.ExecCategory[103] = 3;
      this.ExecTypeString[103] = 2;
      this.ExecDesc[103] = "The specified style will be used for the remainder of this event. 0=normal. 1=black, 2=text cloud+black. It also allows you to set an optional footnote (messageNote1). only shown in style 1 + 2. Directly under the main message in italics. SetMessageStyle is used by DC1 and an earlier prototype, kept here for backwards compatibility. The variable it accesses will also be used by DC3's new ExecDynamicMessage which will put it to value 3.. ";
      this.ExecTypeNames[104] = "ExecSetMessageNote2";
      this.ExecTypeVarCount[104] = 0;
      this.ExecCategory[104] = 3;
      this.ExecTypeString[104] = 2;
      this.ExecDesc[104] = "Sets a string for underwriting of picture of character with text cloud. Shown in style 2.";
      this.ExecTypeNames[105] = "ExecChangeRelation";
      this.ExecTypeVarCount[105] = 4;
      this.ExecTypeVarName[105, 1] = "RegimeNr1";
      this.ExecTypeVarName[105, 2] = "RegimeNr2";
      this.ExecTypeVarName[105, 3] = "Diplomatic Relation #";
      this.ExecTypeVarName[105, 4] = "Hide Message (1=yes hide)";
      this.ExecCategory[105] = 1;
      this.ExecDesc[105] = "Sets the relation between regime 1 and 2 to relation 0-2. 0=war, 1=peace, 2=allied.";
      this.ExecTypeNames[106] = "ExecAddRegime";
      this.ExecTypeVarCount[106] = 2;
      this.ExecTypeVarName[106, 1] = "Copy From";
      this.ExecTypeVarName[106, 2] = "Set Uberregime";
      this.ExecCategory[106] = 1;
      this.ExecTypeString[106] = 2;
      this.ExecDesc[106] = "EXPERT USE ONLY!!!. Only use before start of game. Adds a regime and copies all settings from specified reigme. You can also set name of new regime. You can also set an uberregime here. Automaticly will ally with uberregime.";
      this.ExecTypeNames[107] = "ExecRemoveRegime";
      this.ExecTypeVarCount[107] = 2;
      this.ExecTypeVarName[107, 1] = "RegimeNr";
      this.ExecTypeVarName[107, 2] = "Add stuff too RegimerNr";
      this.ExecTypeString[107] = 2;
      this.ExecDesc[107] = "EXPERT USE ONLY!!!. Only use before start of game. You can set RegimeNr to -1 and then the exec will try to find a regime with the specified name to delete.";
      this.ExecCategory[107] = 1;
      this.ExecTypeNames[108] = "ExecAddOOB";
      this.ExecTypeVarCount[108] = 2;
      this.ExecTypeVarName[108, 1] = "Regime";
      this.ExecTypeVarName[108, 2] = "Historical Unit";
      this.ExecCategory[108] = 1;
      this.ExecDesc[108] = "Sets the historical unit to the regime and also everything in the OOB of the selected historical unit.";
      this.ExecTypeNames[109] = "ExecSetRegimeColor";
      this.ExecTypeVarCount[109] = 4;
      this.ExecTypeVarName[109, 1] = "Regime";
      this.ExecTypeVarName[109, 2] = "Red (0-255)";
      this.ExecTypeVarName[109, 3] = "Green (0-255)";
      this.ExecTypeVarName[109, 4] = "Blue (0-255)";
      this.ExecCategory[109] = 1;
      this.ExecDesc[109] = "Sets the color of the regime. And you can overwrite the Name if you want too. Leave string blank to keep name.";
      this.ExecTypeString[109] = 2;
      this.ExecTypeNames[110] = "ExecAddHistoricalUnit";
      this.ExecTypeVarCount[110] = 4;
      this.ExecTypeVarName[110, 1] = "X";
      this.ExecTypeVarName[110, 2] = "Y";
      this.ExecTypeVarName[110, 3] = "Historical Unit ID";
      this.ExecTypeVarName[110, 4] = "Dispersion in Hex";
      this.ExecCategory[110] = 13;
      this.ExecDesc[110] = "If Historical unit is a Model an instance of it will be created. If it is not it will be put on the map itself. If you set Dispersion to 0 all will go normal. Set dispersion>0 to simulate scatter effect on same sea/land type and regime type as selected for target hex. Set x=-1 to only create a new historical unit (based on specified model) and not place any unit on the map.";
      this.ExecTypeNames[111] = "ExecRemoveHistoricalUnit";
      this.ExecTypeVarCount[111] = 1;
      this.ExecTypeVarName[111, 1] = "Historical Unit";
      this.ExecCategory[111] = 13;
      this.ExecDesc[111] = "All units assigned to this exact Historical Unit will be removed.";
      this.ExecTypeNames[112] = "ExecSetGameVar";
      this.ExecTypeVarCount[112] = 2;
      this.ExecTypeVarName[112, 1] = "GameVar #";
      this.ExecTypeVarName[112, 2] = "New Value";
      this.ExecCategory[112] = 6;
      this.ExecTypeNames[113] = "ExecSetTempVar";
      this.ExecTypeVarCount[113] = 2;
      this.ExecTypeVarName[113, 1] = "TempVar #";
      this.ExecTypeVarName[113, 2] = "New Value";
      this.ExecCategory[113] = 6;
      this.ExecTypeNames[114] = "ExecSetRegimeVar";
      this.ExecTypeVarCount[114] = 3;
      this.ExecTypeVarName[114, 1] = "Regime #";
      this.ExecTypeVarName[114, 2] = "Variable #";
      this.ExecTypeVarName[114, 3] = "New Value";
      this.ExecCategory[114] = 6;
      this.ExecTypeNames[115] = "ExecSetTempString";
      this.ExecTypeVarCount[115] = 2;
      this.ExecTypeVarName[115, 1] = "Tempstring #";
      this.ExecTypeVarName[115, 2] = "New Value";
      this.ExecCategory[115] = 6;
      this.ExecTypeNames[116] = "ExecSetStringList";
      this.ExecTypeVarCount[116] = 4;
      this.ExecTypeVarName[116, 1] = "Stringlist ID #";
      this.ExecTypeVarName[116, 2] = "Row";
      this.ExecTypeVarName[116, 3] = "Col";
      this.ExecTypeVarName[116, 4] = "New Value";
      this.ExecCategory[116] = 16;
      this.ExecTypeNames[117] = "ExecMoveRegimeUp";
      this.ExecTypeVarCount[117] = 1;
      this.ExecTypeVarName[117, 1] = "RegNr";
      this.ExecCategory[117] = 1;
      this.ExecTypeString[117] = 2;
      this.ExecDesc[117] = "EXPERT USE ONLY!!!. You can overrule with using name and setting Regnr=-1. Moves this regime to the end of the list of regimes. Do only use in editor or startup screen for it might screw up things if used in game.";
      this.ExecTypeNames[118] = "ExecSetRecon";
      this.ExecTypeVarCount[118] = 4;
      this.ExecTypeVarName[118, 1] = "X";
      this.ExecTypeVarName[118, 2] = "Y";
      this.ExecTypeVarName[118, 3] = "RegNr";
      this.ExecTypeVarName[118, 4] = "Pts";
      this.ExecCategory[118] = 1;
      this.ExecDesc[118] = "Sets recon for this regime only on this hex only.";
      this.ExecTypeNames[119] = "ExecChangeCommanderSkill";
      this.ExecTypeVarCount[119] = 4;
      this.ExecTypeVarName[119, 1] = "Unit#";
      this.ExecTypeVarName[119, 2] = "CombatMod +/-";
      this.ExecTypeVarName[119, 3] = "MoraleMod +/-";
      this.ExecTypeVarName[119, 4] = "StaffPts +/-";
      this.ExecCategory[119] = 13;
      this.ExecDesc[119] = "Inrease or diminish the officers stats.";
      this.ExecTypeNames[120] = "ExecChangeHisTempValue";
      this.ExecTypeVarCount[120] = 4;
      this.ExecTypeVarName[120, 1] = "Unit# (-1= use hist.unit#)";
      this.ExecTypeVarName[120, 2] = "TempVar#(1-5), 6=aiZoneListNr";
      this.ExecTypeVarName[120, 3] = "New Value";
      this.ExecTypeVarName[120, 4] = "Use Historical Unit#";
      this.ExecCategory[120] = 13;
      this.ExecDesc[120] = "Keep in mind you can also use hisvars to store data. of which you have unlimited quantity. For aiZoneListNr only number above >0 are considered valid.";
      this.ExecTypeNames[121] = "ExecChangeCommanderDescript";
      this.ExecTypeVarCount[121] = 2;
      this.ExecTypeVarName[121, 1] = "His Unit ID#";
      this.ExecTypeVarName[121, 2] = "New Description";
      this.ExecCategory[121] = 13;
      this.ExecDesc[121] = "";
      this.ExecTypeNames[122] = "ExecChangeCommanderOverlay";
      this.ExecTypeVarCount[122] = 2;
      this.ExecTypeVarName[122, 1] = "Unit#";
      this.ExecTypeVarName[122, 2] = "New overlay filename";
      this.ExecCategory[122] = 13;
      this.ExecDesc[122] = "Reloads the overlay file for this commander. specifying an empty string '' will result in no overlay";
      this.ExecTypeNames[123] = "ExecCommanderAddDeckCardUsingStringList";
      this.ExecTypeVarCount[123] = 2;
      this.ExecTypeVarName[123, 1] = "Unit#";
      this.ExecTypeVarName[123, 2] = "StringList CardList ID#";
      this.ExecCategory[123] = 13;
      this.ExecDesc[123] = "Picks a weighted chance card from the stringlist in question. will not take doubles. will add text to description";
      this.ExecTypeNames[124] = "ExecCommanderAddAutoEventUsingStringList";
      this.ExecTypeVarCount[124] = 2;
      this.ExecTypeVarName[124, 1] = "Unit#";
      this.ExecTypeVarName[124, 2] = "StringList EventList ID#";
      this.ExecCategory[124] = 13;
      this.ExecDesc[124] = "Picks a weighted auto-event from the stringlist in question. will not take doubles. will add text to description";
      this.ExecTypeNames[125] = "ExecAddStringList";
      this.ExecTypeVarCount[125] = 2;
      this.ExecTypeVarName[125, 1] = "Rows";
      this.ExecTypeVarName[125, 2] = "Cols";
      this.ExecCategory[125] = 16;
      this.ExecDesc[125] = "Adds a whole new stringlist object to the game data. Use the CheckStringListLastID to get its ID, which you need to change or read anything from it.";
      this.ExecTypeNames[126] = "ExecAddStringListCells";
      this.ExecTypeVarCount[126] = 3;
      this.ExecTypeVarName[126, 1] = "StringList ID";
      this.ExecTypeVarName[126, 2] = "Extra Rows";
      this.ExecTypeVarName[126, 3] = "Extra Cols";
      this.ExecCategory[126] = 16;
      this.ExecDesc[126] = "If you specify 0 will NOT add anything. specify 1 for adding one row or col. You can add rows and cols at the same time. Rows are added at the bottom, Cols on the right.";
      this.ExecTypeNames[ sbyte.MaxValue] = "ExecRemoveStringListRow";
      this.ExecTypeVarCount[ sbyte.MaxValue] = 2;
      this.ExecTypeVarName[ sbyte.MaxValue, 1] = "StringList ID";
      this.ExecTypeVarName[ sbyte.MaxValue, 2] = "Row Number";
      this.ExecCategory[ sbyte.MaxValue] = 16;
      this.ExecTypeNames[128] = "ExecRemoveStringListCol";
      this.ExecTypeVarCount[128] = 2;
      this.ExecTypeVarName[128, 1] = "StringList ID";
      this.ExecTypeVarName[128, 2] = "Col Number";
      this.ExecCategory[128] = 16;
      this.ExecTypeNames[129] = "ExecChangeAIDefensive";
      this.ExecTypeVarCount[129] = 4;
      this.ExecTypeVarName[129, 1] = "Regime";
      this.ExecTypeVarName[129, 2] = "X";
      this.ExecTypeVarName[129, 3] = "Y";
      this.ExecTypeVarName[129, 4] = "Defensive Bonus %";
      this.ExecTypeString[129] = 0;
      this.ExecCategory[129] = 18;
      this.ExecDesc[129] = ">0 is a percentual defensive bonus for defending this area for this regime. NEW AI ONLY";
      this.ExecTypeNames[130] = "ExecGiveCommanderXP";
      this.ExecTypeVarCount[130] = 2;
      this.ExecTypeVarName[130, 1] = "Unit#";
      this.ExecTypeVarName[130, 2] = "XP to give or take +/-";
      this.ExecCategory[130] = 13;
      this.ExecTypeNames[131] = "ExecCreateCommander";
      this.ExecTypeVarCount[131] = 2;
      this.ExecTypeVarName[131, 1] = "Regime #";
      this.ExecTypeVarName[131, 2] = "Overrule Officer Pool StringList ID (-1=dont)";
      this.ExecCategory[131] = 13;
      this.ExecTypeNames[132] = "ExecMoveUnit";
      this.ExecTypeVarCount[132] = 3;
      this.ExecTypeVarName[132, 1] = "Unit #";
      this.ExecTypeVarName[132, 2] = "New X";
      this.ExecTypeVarName[132, 3] = "New Y";
      this.ExecDesc[132] = "Keep in mind combat can occur immediatly after the move. Rebel Battle Mode will be used.";
      this.ExecCategory[132] = 8;
      this.ExecTypeNames[133] = "ExecChangeUnitRegime";
      this.ExecTypeVarCount[133] = 2;
      this.ExecTypeVarName[133, 1] = "Unit #";
      this.ExecTypeVarName[133, 2] = "New Regime#";
      this.ExecDesc[133] = "Keep in mind combat can occur immediatly after the move. Rebel Battle Mode will be used.";
      this.ExecCategory[133] = 8;
      this.ExecTypeNames[134] = "ExecChangeLandscapeMoveCost";
      this.ExecTypeVarCount[134] = 3;
      this.ExecTypeVarName[134, 1] = "Landscape #";
      this.ExecTypeVarName[134, 2] = "MovementType #";
      this.ExecTypeVarName[134, 3] = "AP Cost";
      this.ExecDesc[134] = "";
      this.ExecCategory[134] = 11;
      this.ExecTypeNames[135] = "-DEPRECIATED- (execmodhitpoints)";
      this.ExecTypeVarCount[135] = 3;
      this.ExecTypeVarName[135, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[135, 2] = "SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[135, 3] = "Modifier (100=same, 50=half, 200=double) #";
      this.ExecDesc[135] = "";
      this.ExecCategory[135] = 9;
      this.ExecTypeNames[136] = "ExecModifyAirOverrule";
      this.ExecTypeVarCount[136] = 3;
      this.ExecTypeVarName[136, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[136, 2] = "SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[136, 3] = "Modifier (100=same, 50=half, 200=double) #";
      this.ExecDesc[136] = "";
      this.ExecCategory[136] = 9;
      this.ExecTypeNames[137] = "ExecModifyEntrenchmentSpeed";
      this.ExecTypeVarCount[137] = 3;
      this.ExecTypeVarName[137, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[137, 2] = "SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[137, 3] = "Modifier (100=same, 50=half, 200=double) #";
      this.ExecDesc[137] = "";
      this.ExecCategory[137] = 9;
      this.ExecTypeNames[138] = "ExecModifySupplyStock";
      this.ExecTypeVarCount[138] = 4;
      this.ExecTypeVarName[138, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[138, 2] = "SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[138, 3] = "Modifier (100=same, 50=half, 200=double) #";
      this.ExecTypeVarName[138, 4] = "For dc4+ only. Special Mode. <1=dont use. 1=Supply, 2=Fuel";
      this.ExecDesc[138] = "Modifies supply and stockpile stats";
      this.ExecCategory[138] = 9;
      this.ExecTypeNames[139] = "ExecModifyAttackScore";
      this.ExecTypeVarCount[139] = 3;
      this.ExecTypeVarName[139, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[139, 2] = "SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[139, 3] = "Versus SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[139, 4] = "Modifier (100=same, 50=half, 200=double) #";
      this.ExecDesc[139] = "Modifies AttackArt,AttackPower,AttackPowerDef all 3.";
      this.ExecCategory[139] = 9;
      this.ExecTypeNames[140] = "ExecModifyUnitSupply";
      this.ExecTypeVarCount[140] = 4;
      this.ExecTypeVarName[140, 1] = "Regime (-1=none)";
      this.ExecTypeVarName[140, 2] = "Specific Unit (-1=none)";
      this.ExecTypeVarName[140, 3] = "Modifier % (100=keep same, 50=half, 200=double)";
      this.ExecTypeVarName[140, 4] = "Modifier absolute (0=nill, -x , +x )";
      this.ExecCategory[140] = 8;
      this.ExecDesc[140] = "Increases or decreases supplies of the unit. cannot go over max supplystore.";
      this.ExecTypeNames[141] = "ExecRemoveUnits";
      this.ExecTypeVarCount[141] = 1;
      this.ExecTypeVarName[141, 1] = "Regime #";
      this.ExecCategory[141] = 8;
      this.ExecTypeNames[142] = "ExecLoad_HistoricalTransfer";
      this.ExecTypeVarCount[142] = 1;
      this.ExecTypeVarName[142, 1] = "Regime # ";
      this.ExecCategory[142] = 3;
      this.ExecTypeNames[143] = "ExecRemoveTroopsByReinforcementGroup";
      this.ExecTypeVarCount[143] = 4;
      this.ExecTypeVarName[143, 1] = "X (-1 = from unit)";
      this.ExecTypeVarName[143, 2] = "Y (or unit #)";
      this.ExecTypeVarName[143, 3] = "Reinforcement group";
      this.ExecTypeVarName[143, 4] = "Percentage to remove";
      this.ExecCategory[143] = 2;
      this.ExecTypeNames[144] = "ExecChangeCommander";
      this.ExecTypeVarCount[144] = 2;
      this.ExecTypeVarName[144, 1] = "Unit#";
      this.ExecTypeVarName[144, 2] = "Historical Unit#";
      this.ExecCategory[144] = 8;
      this.ExecDesc[144] = "Replace the commander with that from a historical unit. ";
      this.ExecTypeNames[145] = "ExecSetSupplyMatrix";
      this.ExecTypeVarCount[145] = 4;
      this.ExecTypeVarName[145, 1] = "Source X";
      this.ExecTypeVarName[145, 2] = "Source Y";
      this.ExecTypeVarName[145, 3] = "AreaSlot #";
      this.ExecTypeVarName[145, 4] = "Regime #";
      this.ExecCategory[145] = 6;
      this.ExecDesc[145] = "Sets movecost value on each hex. if not in supply value will be set to 9999. It will not overwrite a lower value with a higher value. So make sure you set the areaslot matrix to 9999 before you call. this is done to allow multiple sources for making the matrix.";
      this.ExecTypeNames[146] = "ExecClearMatrix";
      this.ExecTypeVarCount[146] = 2;
      this.ExecTypeVarName[146, 1] = "AreaSlot #";
      this.ExecTypeVarName[146, 2] = "Value";
      this.ExecCategory[146] = 6;
      this.ExecDesc[146] = "Sets the specified slot for all hexes to specified value";
      this.ExecTypeNames[147] = "SetUberRegime";
      this.ExecTypeVarCount[147] = 2;
      this.ExecTypeVarName[147, 1] = "ForRegime";
      this.ExecTypeVarName[147, 2] = "UberRegime (-1=none)";
      this.ExecCategory[147] = 1;
      this.ExecTypeNames[148] = "SetCardXY";
      this.ExecTypeVarCount[148] = 2;
      this.ExecTypeVarName[148, 1] = "X";
      this.ExecTypeVarName[148, 2] = "Y";
      this.ExecDesc[148] = "If you are calling a card who needs a hex input. set it with this exec.";
      this.ExecCategory[148] = 5;
      this.ExecTypeNames[149] = "ExecRemoveTroopsForNextHistorical";
      this.ExecTypeVarCount[149] = 2;
      this.ExecTypeVarName[149, 1] = "Reinforcement group";
      this.ExecTypeVarName[149, 2] = "Loss %";
      this.ExecCategory[149] = 13;
      this.ExecDesc[149] = "For each event you have to set the loss levels. These values are reset per event. If set any unit added with AddHistorical will suffer these losses.";
      this.ExecTypeNames[150] = "ExecSetHistoricalCounter";
      this.ExecTypeVarCount[150] = 2;
      this.ExecTypeVarName[150, 1] = "Historical Unit";
      this.ExecTypeVarName[150, 2] = "New Counter Value";
      this.ExecCategory[150] = 13;
      this.ExecTypeNames[151] = "ExecSetHistoricalUnitHQ";
      this.ExecTypeVarCount[151] = 3;
      this.ExecTypeVarName[151, 1] = "Historical Unit";
      this.ExecTypeVarName[151, 2] = "New unit # HQ";
      this.ExecTypeVarName[151, 3] = "Historical Unit # HQ";
      this.ExecCategory[151] = 13;
      this.ExecDesc[151] = "Sets all units that belong to this historical unit to the unit or historical unit HQ # specified.. Historical <= 0 means unit is used.";
      this.ExecTypeNames[152] = "ExecAddAntiSupply";
      this.ExecTypeVarCount[152] = 4;
      this.ExecTypeVarName[152, 1] = "X";
      this.ExecTypeVarName[152, 2] = "Y";
      this.ExecTypeVarName[152, 3] = "Regime";
      this.ExecTypeVarName[152, 4] = "Points";
      this.ExecCategory[152] = 4;
      this.ExecDesc[152] = "Must be used in early turn check in order to be used after regular setting of AS and before Supply system...";
      this.ExecTypeNames[153] = "ExecChangeDate";
      this.ExecTypeVarCount[153] = 3;
      this.ExecTypeVarName[153, 1] = "Day";
      this.ExecTypeVarName[153, 2] = "Month";
      this.ExecTypeVarName[153, 3] = "Year";
      this.ExecCategory[153] = 10;
      this.ExecTypeNames[154] = "ExecQuit";
      this.ExecTypeVarCount[154] = 0;
      this.ExecCategory[154] = 6;
      this.ExecDesc[154] = "Quits the player back to the main menu. Can only be played from the research hand cards screen!";
      this.ExecTypeNames[155] = "ExecAIStance";
      this.ExecTypeVarCount[155] = 2;
      this.ExecTypeVarName[155, 1] = "Regime";
      this.ExecTypeVarName[155, 2] = "Stance (0=no overrule, 1=att, 2=def, 3=meeting)";
      this.ExecTypeString[155] = 0;
      this.ExecCategory[155] = 18;
      this.ExecDesc[155] = "If 0 the regime with most powerpoints is considered the attacker. If 3 too, but if 3 then this regime also gets the meeting flag.";
      this.ExecTypeNames[156] = "ExecReduceLandInitialEntrench";
      this.ExecTypeVarCount[156] = 2;
      this.ExecTypeVarName[156, 1] = "LandscapeType (-1=all)";
      this.ExecTypeVarName[156, 2] = "Percentage (100=same. 50=less >100=more)";
      this.ExecTypeString[156] = 0;
      this.ExecCategory[156] = 11;
      this.ExecTypeNames[157] = "ExecSetSpecial";
      this.ExecTypeVarCount[157] = 4;
      this.ExecTypeVarName[157, 1] = "SpecialType";
      this.ExecTypeVarName[157, 2] = "SpecialSprite";
      this.ExecTypeVarName[157, 3] = "X";
      this.ExecTypeVarName[157, 4] = "Y";
      this.ExecTypeString[157] = 0;
      this.ExecCategory[157] = 4;
      this.ExecDesc[157] = "Either Type is a LanscapeType slot with corresponding Sprite or it is -1 and a smallgfx slot will be used.";
      this.ExecTypeNames[158] = "ExecReduceAntiStructural";
      this.ExecTypeVarCount[158] = 2;
      this.ExecTypeVarName[158, 1] = "SFType (-1=all)";
      this.ExecTypeVarName[158, 2] = "Percentage (100=same. 50=less >100=more)";
      this.ExecTypeString[158] = 0;
      this.ExecCategory[158] = 9;
      this.ExecTypeNames[159] = "ExecReduceTroops";
      this.ExecTypeVarCount[159] = 4;
      this.ExecTypeVarName[159, 1] = "SFType (-1=all)";
      this.ExecTypeVarName[159, 2] = "PeopleType (-1=all)";
      this.ExecTypeVarName[159, 3] = "Remove x%";
      this.ExecTypeVarName[159, 4] = "+ remove between 0-y% random";
      this.ExecTypeString[159] = 0;
      this.ExecCategory[159] = 2;
      this.ExecTypeNames[160] = "OBSOLETE";
      this.ExecTypeVarCount[160] = 2;
      this.ExecTypeVarName[160, 1] = "SFType";
      this.ExecTypeVarName[160, 2] = "Hitpoints";
      this.ExecTypeString[160] = 0;
      this.ExecCategory[160] = -1;
      this.ExecTypeNames[161] = "ExecSFTypePower";
      this.ExecTypeVarCount[161] = 4;
      this.ExecTypeVarName[161, 1] = "SFType";
      this.ExecTypeVarName[161, 2] = "Targetgroup# (-1=all)";
      this.ExecTypeVarName[161, 3] = "Attack score";
      this.ExecTypeVarName[161, 4] = "Defend score";
      this.ExecTypeString[161] = 0;
      this.ExecCategory[161] = 9;
      this.ExecTypeNames[162] = "CallFunction";
      this.ExecTypeVarCount[162] = 1;
      this.ExecTypeVarName[162, 1] = "Name of function to call";
      this.ExecTypeString[162] = 0;
      this.ExecCategory[162] = 6;
      this.ExecDesc[162] = "Case of name does not matter, but must be exact otherwise. The tempvar900-999 and tempstring900-999 will be copied to the receiving function and can be altered by it and will be returned back to the calling function. this way you dont have to use gamevars like in ExecExecute. (You can use these call by name feature to make functionlibs that can be loaded by import all). Tempvar 0,1,4,5 are copied to called function, but not back again.";
      this.ExecTypeNames[163] = "ExecSFTypeDescription";
      this.ExecTypeVarCount[163] = 2;
      this.ExecTypeVarName[163, 1] = "SFType#";
      this.ExecTypeVarName[163, 2] = "Description";
      this.ExecTypeString[163] = 0;
      this.ExecCategory[163] = 9;
      this.ExecDesc[163] = "";
      this.ExecTypeNames[164] = "ExecSFTypeHP";
      this.ExecTypeVarCount[164] = 4;
      this.ExecTypeVarName[164, 1] = "SFType";
      this.ExecTypeVarName[164, 2] = "Targetgroup# (-1=all)";
      this.ExecTypeVarName[164, 3] = "Attack HP";
      this.ExecTypeVarName[164, 4] = "Defend HP";
      this.ExecTypeString[164] = 0;
      this.ExecCategory[164] = 9;
      this.ExecTypeNames[165] = "ExecSFTypeMoveType";
      this.ExecTypeVarCount[165] = 2;
      this.ExecTypeVarName[165, 1] = "SFType#";
      this.ExecTypeVarName[165, 2] = "Type";
      this.ExecTypeString[165] = 0;
      this.ExecCategory[165] = 9;
      this.ExecDesc[165] = "";
      this.ExecTypeNames[166] = "ExecSFTypeMoveRedux";
      this.ExecTypeVarCount[166] = 2;
      this.ExecTypeVarName[166, 1] = "SFType#";
      this.ExecTypeVarName[166, 2] = "Redux";
      this.ExecTypeString[166] = 0;
      this.ExecCategory[166] = 9;
      this.ExecDesc[166] = "";
      this.ExecTypeNames[168] = "ExecSFTypeLogo";
      this.ExecTypeVarCount[168] = 3;
      this.ExecTypeVarName[168, 1] = "SFType#";
      this.ExecTypeVarName[168, 2] = "Logo#";
      this.ExecTypeVarName[168, 3] = "value";
      this.ExecTypeString[168] = 0;
      this.ExecCategory[168] = 9;
      this.ExecDesc[168] = "";
      this.ExecTypeNames[170] = "ExecSFTypeFuelUse";
      this.ExecTypeVarCount[170] = 3;
      this.ExecTypeVarName[170, 1] = "SFType#";
      this.ExecTypeVarName[170, 2] = "ForMove (10ap)";
      this.ExecTypeVarName[170, 3] = "ForAttack (combatround)";
      this.ExecTypeString[170] = 0;
      this.ExecCategory[170] = 9;
      this.ExecDesc[170] = "";
      this.ExecTypeNames[171] = "ExecSetRegimePeople";
      this.ExecTypeVarCount[171] = 3;
      this.ExecTypeVarName[171, 1] = "Regime# ";
      this.ExecTypeVarName[171, 2] = "People # (or -1=to leave as is) ";
      this.ExecTypeVarName[171, 3] = "officerpool # (or-1=to leave as is)";
      this.ExecCategory[171] = 1;
      this.ExecTypeNames[172] = "ExecSetHQ";
      this.ExecTypeVarCount[172] = 2;
      this.ExecTypeVarName[172, 1] = "Unit";
      this.ExecTypeVarName[172, 2] = "HQ";
      this.ExecCategory[172] = 8;
      this.ExecTypeNames[173] = "ExecSetMatrix";
      this.ExecTypeVarCount[173] = 3;
      this.ExecTypeVarName[173, 1] = "Slot";
      this.ExecTypeVarName[173, 2] = "Operation";
      this.ExecTypeVarName[173, 3] = "Disallow over sea (0=no, 1=yes)";
      this.ExecCategory[173] = 6;
      this.ExecDesc[173] = "You cannot set operation yet. For now it just subtracts 1 of the value and copies if higher then neighbour. Thus make sure to make a clearmatrix(0) and then set coordinates you want to spread out.";
      this.ExecTypeNames[174] = "ExecSetHexOwner";
      this.ExecTypeVarCount[174] = 3;
      this.ExecTypeVarName[174, 1] = "X";
      this.ExecTypeVarName[174, 2] = "Y";
      this.ExecTypeVarName[174, 3] = "Owner #";
      this.ExecCategory[174] = 4;
      this.ExecTypeNames[175] = "ExecRewardPowerOn";
      this.ExecTypeVarCount[175] = 4;
      this.ExecTypeVarName[175, 1] = "X";
      this.ExecTypeVarName[175, 2] = "Y";
      this.ExecTypeVarName[175, 3] = "Power Above";
      this.ExecTypeVarName[175, 4] = "Multi";
      this.ExecTypeString[175] = 0;
      this.ExecCategory[175] = 18;
      this.ExecDesc[175] = "If AI can get more then power above on X,Y coordinate. all pts above this treshold will be multiplied by multi and added to score. This gives AI incentive to get a certain build up here. so it must be able to hold it to get it.. This is only used in Init AI so if you use uberregime only the uberregime needs this setting. This setting is wiped clean after every AI has played. You thus need to set this in early turn event.";
      this.ExecTypeNames[176] = "ExecRemoveunit";
      this.ExecTypeVarCount[176] = 1;
      this.ExecTypeVarName[176, 1] = "Unit #";
      this.ExecCategory[176] = 8;
      this.ExecDesc[176] = "Removes specific Unit";
      this.ExecTypeNames[177] = "ExecSetTurnString";
      this.ExecTypeVarCount[177] = 1;
      this.ExecTypeVarName[177, 1] = "Short String";
      this.ExecTypeString[177] = 0;
      this.ExecCategory[177] = 10;
      this.ExecDesc[177] = "if you set it to '' then it will not overrule the date or round. Keep the string short to make it fit.";
      this.ExecTypeNames[178] = "ExecSetRound";
      this.ExecTypeVarCount[178] = 1;
      this.ExecTypeVarName[178, 1] = "Round";
      this.ExecTypeString[178] = 0;
      this.ExecCategory[178] = 10;
      this.ExecDesc[178] = "Do not use! It will screw with the statistics. Never set higher. You can only set lower then current round.";
      this.ExecTypeNames[179] = "ExecSortStringListID";
      this.ExecTypeVarCount[179] = 3;
      this.ExecTypeVarName[179, 1] = "StringListID#";
      this.ExecTypeVarName[179, 2] = "Column# to sort on";
      this.ExecTypeVarName[179, 3] = "0=asc, 1=desc";
      this.ExecTypeString[179] = 0;
      this.ExecCategory[179] = 16;
      this.ExecDesc[179] = "Remember first column is column 0. ASCENDING:  highest at top. DESCENDING: lowest at top.  ";
      this.ExecTypeNames[180] = "ExecChangeUnitEntrenchment";
      this.ExecTypeVarCount[180] = 2;
      this.ExecTypeVarName[180, 1] = "Unit#";
      this.ExecTypeVarName[180, 2] = "-/+ entrenchment pts";
      this.ExecTypeString[180] = 0;
      this.ExecCategory[180] = 8;
      this.ExecDesc[180] = "Will auto cut at 0 or maximum entrench for sftype in hex..";
      this.ExecTypeNames[181] = "ExecSetSFTypeVar";
      this.ExecTypeVarCount[181] = 3;
      this.ExecTypeVarName[181, 1] = "SFType";
      this.ExecTypeVarName[181, 2] = "Var#";
      this.ExecTypeVarName[181, 3] = "Value";
      this.ExecTypeString[181] = 0;
      this.ExecCategory[181] = 9;
      this.ExecDesc[181] = "";
      this.ExecTypeNames[182] = "ExecSetHistoricUnitToGroup";
      this.ExecTypeVarCount[182] = 2;
      this.ExecTypeVarName[182, 1] = "Historic HQ/Unit/Div #";
      this.ExecTypeVarName[182, 2] = "To Group with HQ/Unit/Div# in it";
      this.ExecTypeString[182] = 0;
      this.ExecCategory[182] = 18;
      this.ExecDesc[182] = "This should be called in an 'AI Init Check' since it re-orders strategic groups (after makegroups) and before going into strategic analysis (findbeststrategy). ";
      this.ExecTypeNames[183] = "ExecMoveHistoricalUnit";
      this.ExecTypeVarCount[183] = 4;
      this.ExecTypeVarName[183, 1] = "Historical Unit #";
      this.ExecTypeVarName[183, 2] = "New X";
      this.ExecTypeVarName[183, 3] = "New Y";
      this.ExecTypeVarName[183, 4] = "Optional Historical HQ #";
      this.ExecDesc[183] = "If you specify >0 for optional HQ all units attached to the HQ will be moved. you can specify -1 for historical unit if you specify hq.";
      this.ExecCategory[183] = 13;
      this.ExecTypeNames[185] = "ExecSetUnitName";
      this.ExecTypeVarCount[185] = 3;
      this.ExecTypeVarName[185, 1] = "Unit#";
      this.ExecTypeVarName[185, 2] = "New Name";
      this.ExecTypeVarName[186, 3] = "Shortname";
      this.ExecCategory[185] = 8;
      this.ExecDesc[185] = "Will set name of all belonging to units historical unit if using historical units. Shortname is only applied if historical unit is present.";
      this.ExecTypeNames[186] = "ExecDateMode";
      this.ExecTypeVarCount[186] = 2;
      this.ExecTypeVarName[186, 1] = "0=rounds, 1=dates";
      this.ExecTypeVarName[186, 2] = "days per round";
      this.ExecCategory[186] = 10;
      this.ExecTypeNames[187] = "ExecUnitPeopleModify";
      this.ExecTypeVarCount[187] = 3;
      this.ExecTypeVarName[187, 1] = "Unit #";
      this.ExecTypeVarName[187, 2] = "Change People# (-1=all)";
      this.ExecTypeVarName[187, 3] = "Too People#";
      this.ExecCategory[187] = 8;
      this.ExecDesc[187] = "Change the people in the unit.";
      this.ExecTypeNames[188] = "ExecSetUnitSelected *DEPRECIATED*";
      this.ExecTypeVarCount[188] = 1;
      this.ExecTypeVarName[188, 1] = "Unit #";
      this.ExecCategory[188] = 5;
      this.ExecDesc[188] = "Do not confuse this function with ExecUnitSelectable to make a unit choseable in popup. This function provides some backwards compatibility with ATG and otherwise sets the unitselected for the game display. -1= no unit selected.";
      this.ExecTypeNames[190] = "ExecAICombatMoveMod";
      this.ExecTypeVarCount[190] = 3;
      this.ExecTypeVarName[190, 1] = "Regime #";
      this.ExecTypeVarName[190, 2] = "Combat Bonus";
      this.ExecTypeVarName[190, 3] = "Movement Bonus";
      this.ExecCategory[190] = 18;
      this.ExecDesc[190] = "Combat bonus can be everything between 0-999%, movement bonus between 0-100%. If you set -1 for combat or move the bonus is not changed.";
      this.ExecTypeNames[191] = "ExecAIChangeRoleScore";
      this.ExecTypeVarCount[191] = 3;
      this.ExecTypeVarName[191, 1] = "SFType #";
      this.ExecTypeVarName[191, 2] = "AI Role # (0-49)";
      this.ExecTypeVarName[191, 3] = "New score";
      this.ExecCategory[191] = 18;
      this.ExecDesc[191] = "Allows you to change AI role scores ingame so to influence AI production";
      this.ExecTypeNames[192] = "ExecReloadGraphic";
      this.ExecTypeVarCount[192] = 2;
      this.ExecTypeVarName[192, 1] = "Current filename";
      this.ExecTypeVarName[192, 2] = "New filename";
      this.ExecCategory[192] = 17;
      this.ExecDesc[192] = "expert use only. part or whole of filename (current filename) is looked for in all loaded graphics and replaced by new filename. use only the filename itself like 'background2.png' for the file to be replaced. use only filename like 'background2b.png' for the string that replaces it. ";
      this.ExecTypeNames[193] = "ExecAIProductionResourceComplient";
      this.ExecTypeVarCount[193] = 0;
      this.ExecDesc[193] = "Will call the AI function that makes sure that production is research complient. If rulevar(875) is active this is called by AI after setting production. However if you script the production with events you might want to call this function add the end of that scripting in some scenarios or give the AI unlimited resources instead.";
      this.ExecCategory[193] = 18;
      this.ExecTypeNames[194] = "ExecChangeDipOffer";
      this.ExecTypeVarCount[194] = 3;
      this.ExecTypeVarName[194, 1] = "RegimeNr1";
      this.ExecTypeVarName[194, 2] = "RegimeNr2";
      this.ExecTypeVarName[194, 3] = "Diplomatic Offer # (0=none or 1=offer)";
      this.ExecCategory[194] = 1;
      this.ExecDesc[194] = "Does not give message. You have to that manually. Sets the offer mode to either 0= cancel offer or 1=give offer";
      this.ExecTypeNames[197] = "ExecSetLabel";
      this.ExecTypeVarCount[197] = 4;
      this.ExecTypeVarName[197, 1] = "X ";
      this.ExecTypeVarName[197, 2] = "Y";
      this.ExecTypeVarName[197, 3] = "Type (0-10)";
      this.ExecTypeVarName[197, 4] = "String";
      this.ExecCategory[197] = 4;
      this.ExecDesc[197] = "Slot 1 is always used. Auto complete is used and name can stretch several hexes.";
      this.ExecTypeNames[198] = "ExecClearAllLabels";
      this.ExecTypeVarCount[198] = 0;
      this.ExecCategory[198] = 4;
      this.ExecTypeNames[199] = "ExecMutateRandomSFType";
      this.ExecTypeVarCount[199] = 4;
      this.ExecTypeVarName[199, 1] = "People (-1=all)";
      this.ExecTypeVarName[199, 2] = "Random percentage";
      this.ExecTypeVarName[199, 3] = "From Sftype#";
      this.ExecTypeVarName[199, 4] = "Too Sftype# (-1=remove)";
      this.ExecCategory[199] = 2;
      this.ExecDesc[199] = "The random percentage determines ammount of sftype to mutate. After completion sets # of changed individuals in tempvar[999].";
      this.ExecTypeNames[200] = "ExecRemoveTroopsGlobal";
      this.ExecTypeVarCount[200] = 4;
      this.ExecTypeVarName[200, 1] = "SFType group (-1=all)";
      this.ExecTypeVarName[200, 2] = "People (-1=all)";
      this.ExecTypeVarName[200, 3] = "Reinforcement Type (-1=all)";
      this.ExecTypeVarName[200, 4] = "Percentage to remove";
      this.ExecCategory[200] = 2;
      this.ExecDesc[200] = "Remove percentage is not exact in this function... its the chance for each individual that it will be removed. If it is set to 999 empty HQ units will also be removed. If not only empty normal units will be removed.";
      this.ExecTypeNames[201] = "ExecGiveReinforcement2";
      this.ExecTypeVarCount[201] = 4;
      this.ExecTypeVarName[201, 1] = "SFType#";
      this.ExecTypeVarName[201, 2] = "People#";
      this.ExecTypeVarName[201, 3] = "Experience";
      this.ExecTypeVarName[201, 4] = "Multiplier";
      this.ExecCategory[201] = 2;
      this.ExecDesc[201] = "Uses SetCardXY for coordinate to drop troops input.";
      this.ExecTypeNames[202] = "ExecSetMoveMatrix";
      this.ExecTypeVarCount[202] = 4;
      this.ExecTypeVarName[202, 1] = "Source X";
      this.ExecTypeVarName[202, 2] = "Source Y";
      this.ExecTypeVarName[202, 3] = "AreaSlot #";
      this.ExecTypeVarName[202, 4] = "MoveType #";
      this.ExecCategory[202] = 6;
      this.ExecDesc[202] = "Sets movecost value on each hex for specified movetype. if not reachable will be set to 9999. It will not overwrite a lower value with a higher value. So make sure you set the areaslot matrix to 9999 before you call. this is done to allow multiple sources for making the matrix. The matrix is calculated for the regime that owns the hex.";
      this.ExecTypeNames[203] = "ExecSetHisVar (DEPRECIATED)";
      this.ExecTypeVarCount[203] = 4;
      this.ExecTypeVarName[203, 1] = "His.Unit ID#";
      this.ExecTypeVarName[203, 2] = "Type #";
      this.ExecTypeVarName[203, 3] = "Value";
      this.ExecTypeVarName[203, 4] = "Nato Counter (0= do not set)";
      this.ExecCategory[203] = 13;
      this.ExecTypeNames[204] = "ExecRemoveHisVar";
      this.ExecTypeVarCount[204] = 2;
      this.ExecTypeVarName[204, 1] = "His.Unit ID#";
      this.ExecTypeVarName[204, 2] = "Type #";
      this.ExecCategory[204] = 13;
      this.ExecTypeNames[205] = "ExecCommanderAddDeckCard2";
      this.ExecTypeVarCount[205] = 4;
      this.ExecTypeVarName[205, 1] = "Unit# (or -1)";
      this.ExecTypeVarName[205, 2] = "Historical Unit# (or -1)";
      this.ExecTypeVarName[205, 3] = "DeckCard#";
      this.ExecTypeVarName[205, 4] = "Percentage Chance % (or -1,-2,-3,-4,-5,-6)";
      this.ExecCategory[205] = 13;
      this.ExecDesc[205] = "Either specify a normal unit# or a historical unit#. If instead of percentage you specify -1 your remove specified card if present, if you specifify -2 you remove all deck cards. if you specify -3 you'll remove all hand cards and all deck cards. If you specify -4 you'll only remove the hand card and not the deck card. If specify -5 you will not add any card but if the card is present set its chance to 0%. If -6 then you will also not add a card but if card is present set its chance to 100%.";
      this.ExecTypeNames[206] = "ExecCommanderAddAutoEvent";
      this.ExecTypeVarCount[206] = 4;
      this.ExecTypeVarName[206, 1] = "Unit#";
      this.ExecTypeVarName[206, 2] = "AutoEvent#";
      this.ExecTypeVarName[206, 3] = "Percentage Chance % (-1=delete if present)";
      this.ExecTypeVarName[206, 4] = "His.Unit ID overrule#";
      this.ExecCategory[206] = 13;
      this.ExecDesc[206] = "";
      this.ExecTypeNames[207] = "ExecSetReconUnit";
      this.ExecTypeVarCount[207] = 4;
      this.ExecTypeVarName[207, 1] = "X";
      this.ExecTypeVarName[207, 2] = "Y";
      this.ExecTypeVarName[207, 3] = "RegNr";
      this.ExecTypeVarName[207, 4] = "Recon points";
      this.ExecCategory[207] = 1;
      this.ExecDesc[207] = "Sets recon for this regime only on this hex and all its neighbours up to range. Uses the ammount of recon points the specified unit# has.";
      this.ExecTypeNames[208] = "ExecCommanderPool";
      this.ExecTypeVarCount[208] = 2;
      this.ExecTypeVarName[208, 1] = "Historical unit ID#";
      this.ExecTypeVarName[208, 2] = "In Pool? 1=yes, 0=no";
      this.ExecTypeVarName[208, 3] = "new PP value (-1 = dont change)";
      this.ExecCategory[208] = 12;
      this.ExecTypeNames[209] = "ExecClearCommander";
      this.ExecTypeVarCount[209] = 4;
      this.ExecTypeVarName[209, 1] = "Historical Unit# (or -1)";
      this.ExecTypeVarName[209, 2] = "Clear HandCards (1=yes)";
      this.ExecTypeVarName[209, 3] = "Clear DeckCards (1=yes)";
      this.ExecTypeVarName[209, 4] = "Clr Events,StaffSiz,Mormod,combatmod (1=yes)";
      this.ExecCategory[209] = 13;
      this.ExecDesc[209] = "Allows you to clean all cards & events associated with a historical unit.";
      this.ExecTypeNames[210] = "ExecChangeCommanderSkill2";
      this.ExecTypeVarCount[210] = 4;
      this.ExecTypeVarName[210, 1] = "Historical Unit#";
      this.ExecTypeVarName[210, 2] = "CombatMod";
      this.ExecTypeVarName[210, 3] = "MoraleMod";
      this.ExecTypeVarName[210, 4] = "StaffPts";
      this.ExecCategory[210] = 13;
      this.ExecDesc[210] = "Same as other function. But here the historical unit# instead of the unit# is targeted. And the setting is absolute not +/-.";
      this.ExecTypeNames[211] = "ExecSwitchUnitModel";
      this.ExecTypeVarCount[211] = 3;
      this.ExecTypeVarName[211, 1] = "Unit#";
      this.ExecTypeVarName[211, 2] = "To Model ID#";
      this.ExecTypeVarName[211, 3] = "Change name as if new unit 0=no ,1=yes";
      this.ExecCategory[211] = 8;
      this.ExecDesc[211] = "This function will attempt to change the whole historical unit# of unit# to a new model and will implement the changes immediately. A new name will be also be given if specified so.";
      this.ExecTypeNames[212] = "ExecClearStringList";
      this.ExecTypeVarCount[212] = 1;
      this.ExecTypeVarName[212, 1] = "Stringlist ID #";
      this.ExecCategory[212] = 16;
      this.ExecDesc[212] = "Delets all rows of this stringlist.";
      this.ExecTypeNames[213] = "ExecSetPeopleMorale";
      this.ExecTypeVarCount[213] = 4;
      this.ExecTypeVarName[213, 1] = "People #";
      this.ExecTypeVarName[213, 2] = "Under People Group#";
      this.ExecTypeVarName[213, 3] = "New Morale";
      this.ExecTypeVarName[213, 4] = "Reset all troops 0=no,1=yes";
      this.ExecCategory[213] = 1;
      this.ExecDesc[213] = "Reset=1 sets all morale to regime base morale * people morale as if in start of scenario.";
      this.ExecTypeNames[214] = "AI_SetTacticalScript";
      this.ExecTypeVarCount[214] = 4;
      this.ExecTypeVarName[214, 1] = "Historical Unit ID#";
      this.ExecTypeVarName[214, 2] = "Hex Target X";
      this.ExecTypeVarName[214, 3] = "Hex Target Y";
      this.ExecTypeVarName[214, 4] = "Attack Towards (1-6) -1=no attack";
      this.ExecCategory[214] = 18;
      this.ExecTypeNames[215] = "ExecActionCardText";
      this.ExecTypeVarCount[215] = 3;
      this.ExecTypeVarName[215, 1] = "Actioncard Nr";
      this.ExecTypeVarName[215, 2] = "New Title";
      this.ExecTypeVarName[215, 3] = "New Text on card";
      this.ExecTypeString[215] = 0;
      this.ExecCategory[215] = 5;
      this.ExecDesc[215] = "The difference with ExecActionCardName is that you can here also set the text on the card + input can be done with tempstrings with this exec";
      this.ExecTypeNames[216] = "ExecSetUnitCapacityPoints";
      this.ExecTypeVarCount[216] = 4;
      this.ExecTypeVarName[216, 1] = "Unit#";
      this.ExecTypeVarName[216, 2] = "LandCap Pts +/-";
      this.ExecTypeVarName[216, 3] = "NavyCap Pts +/-";
      this.ExecTypeVarName[216, 3] = "RailCap Pts +/-";
      this.ExecCategory[216] = 8;
      this.ExecDesc[216] = "Allows you to remove or add capacity points to a unit. Use in late turn so the unit Cap point gain has already been processed before use of this exec.";
      this.ExecTypeNames[217] = "ExecRemoveTroopsUnderHistorical";
      this.ExecTypeVarCount[217] = 4;
      this.ExecTypeVarName[217, 1] = "SFType group (-1=all)";
      this.ExecTypeVarName[217, 2] = "Historical Unit";
      this.ExecTypeVarName[217, 3] = "Reinforcement Type (-1=all)";
      this.ExecTypeVarName[217, 4] = "Percentage to remove";
      this.ExecCategory[217] = 2;
      this.ExecDesc[217] = "Remove percentage is not exact in this function... its the chance for each individual that it will be removed. Compared to its namesake exec this one only affects units under command of the historical unit (HQ!) specified. Only units directly under the historical unit are affected and HQs are always excluded. (if you want to set the HQs you'll have to do it manually)";
      this.ExecTypeNames[218] = "ExecSetHistoricalUnitOwner *DEPRECIATED*";
      this.ExecTypeVarCount[218] = 2;
      this.ExecTypeVarName[218, 1] = "Old owner #";
      this.ExecTypeVarName[218, 2] = "New owner #";
      this.ExecCategory[218] = 2;
      this.ExecDesc[218] = "Function no longer does anything.";
      this.ExecTypeNames[219] = "ExecSetPbemPlayer";
      this.ExecTypeVarCount[219] = 2;
      this.ExecTypeVarName[219, 1] = "Regime #";
      this.ExecTypeVarName[219, 2] = "PBEM++ Player number #";
      this.ExecCategory[219] = 1;
      this.ExecDesc[219] = "Expert use only!. You can switch PBEM++ player here. only set to 1=player 1(challenger) or 2=player 2(opponent).";
      this.ExecTypeNames[220] = "ExecSetDrawGame";
      this.ExecTypeVarCount[220] = 0;
      this.ExecCategory[220] = 1;
      this.ExecDesc[220] = "When this is set the game will be considered game over by the PBEM++ server and a draw game at it. Same for non PBEM++ games by the way. ";
      this.ExecTypeNames[221] = "ExecRemoveSupplyUnderHistorical";
      this.ExecTypeVarCount[221] = 3;
      this.ExecTypeVarName[221, 1] = "Historical Unit";
      this.ExecTypeVarName[221, 2] = "Percentage of supply to leave";
      this.ExecTypeVarName[221, 3] = "New Supply Consumption % (normal is 100%)";
      this.ExecCategory[221] = 2;
      this.ExecDesc[221] = "this one only affects units under command of the historical unit (HQ!) specified. Only units directly under the historical unit are affected and HQs are always excluded. (if you want to set the HQs you'll have to do it manually)";
      this.ExecTypeNames[222] = "ExecSetInterceptRdnStop";
      this.ExecTypeVarCount[222] = 2;
      this.ExecTypeVarName[222, 1] = "For Regime (-1=all)";
      this.ExecTypeVarName[222, 2] = "Percentage for intercept";
      this.ExecCategory[222] = 2;
      this.ExecDesc[222] = "Only affects units with air units in them. percentage example: 75 means only at 75% rdn.";
      this.ExecTypeNames[223] = "ExecSetHistoricalUnitMaxRecruit";
      this.ExecTypeVarCount[223] = 2;
      this.ExecTypeVarName[223, 1] = "ID#";
      this.ExecTypeVarName[223, 2] = "MaxRecruit#(-1=unl,0=none)";
      this.ExecCategory[223] = 2;
      this.ExecDesc[223] = "A function that allows you to change the max recruit";
      this.ExecTypeNames[224] = "ExecSetHistoricalUnitType";
      this.ExecTypeVarCount[224] = 2;
      this.ExecTypeVarName[224, 1] = "ID#";
      this.ExecTypeVarName[224, 2] = "Type#(5=corps,6=a,7=ag,8=high)";
      this.ExecCategory[224] = 2;
      this.ExecDesc[224] = "A function that allows you to change the type. this is usefull to make 1st panzer army immobile and the sov front too. ";
      this.ExecTypeNames[225] = "ExecChangeDateAdd";
      this.ExecTypeVarCount[225] = 3;
      this.ExecTypeVarName[225, 1] = "add x Day";
      this.ExecTypeVarName[225, 2] = "add x Month";
      this.ExecTypeVarName[225, 3] = "add x Year";
      this.ExecCategory[225] = 10;
      this.ExecTypeNames[226] = "ExecSetAllUnitReady";
      this.ExecTypeVarCount[226] = 1;
      this.ExecTypeVarName[226, 1] = "regime. -1=all";
      this.ExecCategory[226] = 10;
      this.ExecDesc[226] = "Sets all units with max supply, ap and readiness.";
      this.ExecTypeNames[227] = "ExecRemoveActiveOfficersFromStringlist";
      this.ExecTypeVarCount[227] = 2;
      this.ExecTypeVarName[227, 1] = "regime#";
      this.ExecTypeVarName[227, 2] = "stringlist ID";
      this.ExecCategory[227] = 12;
      this.ExecDesc[227] = "Looks up the officer historical ID in column 0 and sets availability to 0 in column 1. Active officers are officers that are in the pool or on the map in a unit.";
      this.ExecTypeNames[228] = "ExecMutateRandomSFTypeUnderHis";
      this.ExecTypeVarCount[228] = 4;
      this.ExecTypeVarName[228, 1] = "HistoricalID";
      this.ExecTypeVarName[228, 2] = "Random percentage";
      this.ExecTypeVarName[228, 3] = "From Sftype#";
      this.ExecTypeVarName[228, 4] = "Too Sftype# (-1=remove)";
      this.ExecCategory[228] = 2;
      this.ExecDesc[228] = "The random percentage determines ammount of sftype to mutate. After completion sets # of changed individuals in tempvar[999]. ";
      this.ExecTypeNames[229] = "ExecRemovePeopleOfficersFromStringlist";
      this.ExecTypeVarCount[229] = 2;
      this.ExecTypeVarName[229, 1] = "people#";
      this.ExecTypeVarName[229, 2] = "stringlist ID";
      this.ExecCategory[229] = 12;
      this.ExecDesc[229] = "Looks up the officer historical ID in column 0 and sets availability to 0 in column 1 if  the officer has specified people#.";
      this.ExecTypeNames[230] = "ExecRemoveFromOfficerPool";
      this.ExecTypeVarCount[230] = 4;
      this.ExecTypeVarName[230, 1] = "regime# (-1=all)";
      this.ExecTypeVarName[230, 2] = "people# (-1=all)";
      this.ExecTypeVarName[230, 3] = "VarType (-1=ignore condition)";
      this.ExecTypeVarName[230, 4] = "=VarQty";
      this.ExecCategory[230] = 12;
      this.ExecDesc[230] = "Removes any officers from the officerpool of specified regime who has the specified characeristics. You can deted vartype = varqty to tailormake catch a specific officer.";
      this.ExecTypeNames[231] = "ExecModifyStockpiles";
      this.ExecTypeVarCount[231] = 2;
      this.ExecTypeVarName[231, 1] = "Under Historical Unit#";
      this.ExecTypeVarName[231, 2] = "Modifier (100=same, 50=half, 200=double) #";
      this.ExecDesc[231] = "The function will cap at maximum stockpiles. So you can specify 999 or more modifier to give unit max. and 0 to set stockpile to nothing.";
      this.ExecCategory[231] = 9;
      this.ExecTypeNames[232] = "ExecSetRegimeFerryEff";
      this.ExecTypeVarCount[232] = 2;
      this.ExecTypeVarName[232, 1] = "Regime nr";
      this.ExecTypeVarName[232, 2] = "Ferry eff (0=none, 100=full)";
      this.ExecCategory[232] = 1;
      this.ExecTypeNames[233] = "CallFunctionByLibrary";
      this.ExecTypeVarCount[233] = 2;
      this.ExecTypeVarName[233, 1] = "Name of library";
      this.ExecTypeVarName[233, 2] = "Name of function to call";
      this.ExecTypeString[233] = 0;
      this.ExecCategory[233] = 20;
      this.ExecDesc[233] = "Same as CallFunction, but only looks in specific library. This is to avoid double name issues.";
      this.ExecTypeNames[234] = "ExecModifyAttackScore2";
      this.ExecTypeVarCount[234] = 4;
      this.ExecTypeVarName[234, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[234, 2] = "1=offensive, 2=defensive";
      this.ExecTypeVarName[234, 3] = "Versus SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[234, 4] = "New value to be multiplicated with current value and divided by 100";
      this.ExecDesc[234] = "1=Modifies AttackArt,AttackPower 2=modifies: AttackPowerDef.";
      this.ExecCategory[234] = 9;
      this.ExecTypeNames[235] = "ExecModifyHitpoints2";
      this.ExecTypeVarCount[235] = 3;
      this.ExecTypeVarName[235, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[235, 2] = "Versus SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[235, 3] = "New value to be multiplicated with current value and divided by 100";
      this.ExecDesc[235] = "";
      this.ExecCategory[235] = 9;
      this.ExecTypeNames[236] = "ExecModifyAttackScore3";
      this.ExecTypeVarCount[236] = 4;
      this.ExecTypeVarName[236, 1] = "SFType # (-1=all)";
      this.ExecTypeVarName[236, 2] = "1=art attack score";
      this.ExecTypeVarName[236, 3] = "Versus SFTypeGroup # (-1=all)";
      this.ExecTypeVarName[236, 4] = "New value to be multiplicated with current value and divided by 100";
      this.ExecDesc[236] = "1=Modifies AttackArt";
      this.ExecCategory[236] = 9;
      this.ExecTypeNames[237] = "ExecSetGlobalLibVar";
      this.ExecTypeVarCount[237] = 3;
      this.ExecTypeVarName[237, 1] = "Name of library";
      this.ExecTypeVarName[237, 2] = "Name of libvar";
      this.ExecTypeVarName[237, 3] = "New value";
      this.ExecTypeString[237] = 0;
      this.ExecCategory[237] = 20;
      this.ExecDesc[237] = "Allows you to set a global text value-type libvar. This basically gives you unlimited alternative to gameslots that are excellent for modular design.";
      this.ExecTypeNames[238] = "ExecSetHexLibVar";
      this.ExecTypeVarCount[238] = 3;
      this.ExecTypeVarName[238, 1] = "Name of library";
      this.ExecTypeVarName[238, 2] = "Name of libvar";
      this.ExecTypeVarName[238, 3] = "New value";
      this.ExecTypeString[238] = 0;
      this.ExecCategory[238] = 20;
      this.ExecDesc[238] = "Uses ExecSetCardXY in the line before this call for specifiying the hex this operation is done on. You can only set numeric values to the map. This gives you basically unlimited data slots on map hexes.";
      this.ExecTypeNames[239] = "ExecDynamicMessage";
      this.ExecTypeVarCount[239] = 4;
      this.ExecTypeVarName[239, 1] = "Regime1";
      this.ExecTypeVarName[239, 2] = "Regime2";
      this.ExecTypeVarName[239, 3] = "Message String";
      this.ExecTypeVarName[239, 4] = "EventPicture (-1=none)";
      this.ExecCategory[239] = 3;
      this.ExecDesc[239] = "This is the  new DynamicMessage. It allows advanced scripting and utilises system graphics 3 background parts. if reg1=-1 and reg2=-1 then message is send to all regimes. (inside note: Dynamic Message sets a message to Style=3 to notify the engine it uses dynamic message mode and advanced scripting) ";
      this.ExecTypeNames[240] = "ExecSetMessageNameAndGroup";
      this.ExecTypeVarCount[240] = 4;
      this.ExecTypeVarName[240, 1] = "Name (string not value) Set empty string for no-name! ";
      this.ExecTypeVarName[240, 2] = "Group (0=none)";
      this.ExecTypeVarName[240, 3] = "HideFromTab (1=yes,0=no)";
      this.ExecTypeVarName[240, 4] = "HideFromStart (1=yes,0=no)";
      this.ExecCategory[240] = 3;
      this.ExecDesc[240] = "Will be applied to the next ExecMessage2 or ExecDynamicMessage. ";
      this.ExecTypeNames[241] = "ExecSetHisVar2";
      this.ExecTypeVarCount[241] = 4;
      this.ExecTypeVarName[241, 1] = "His.Unit ID#";
      this.ExecTypeVarName[241, 2] = "Type #";
      this.ExecTypeVarName[241, 3] = "Value";
      this.ExecTypeVarName[241, 4] = "SmallGfx (-1= no smallgfx)";
      this.ExecCategory[241] = 13;
      this.ExecDesc[241] = "If a smallGfx is specified the value and the smallgfx will be displayed for officers.";
      this.ExecTypeNames[242] = "ExecSetHistoricalLibVar";
      this.ExecTypeVarCount[242] = 4;
      this.ExecTypeVarName[242, 1] = "Name of library";
      this.ExecTypeVarName[242, 2] = "Slot# of historical unit";
      this.ExecTypeVarName[242, 3] = "Name of libvar";
      this.ExecTypeVarName[242, 4] = "New value";
      this.ExecTypeString[242] = 0;
      this.ExecCategory[242] = 20;
      this.ExecDesc[242] = "Set a historical unit LibVar. Keep in mind its NOT! the ID asked but the slot number in the array of historical units. You can use this to change the LibVar of a historical unit or historical model.  Since both use historical units data structure behind the scenes.";
      this.ExecTypeNames[243] = "ExecUnitOnTop";
      this.ExecTypeVarCount[243] = 1;
      this.ExecTypeVarName[243, 1] = "Unit nr#";
      this.ExecCategory[243] = 8;
      this.ExecDesc[243] = "Makes sure this unit nr is on top of the stack in its hex.";
      this.ExecTypeNames[244] = "ExecSetGroupName";
      this.ExecTypeVarCount[244] = 2;
      this.ExecTypeVarName[244, 1] = "GroupName #";
      this.ExecTypeVarName[244, 2] = "New Value";
      this.ExecCategory[244] = 6;
      this.ExecTypeNames[245] = "ExecAppendTempString";
      this.ExecTypeVarCount[245] = 2;
      this.ExecTypeVarName[245, 1] = "Tempstring #";
      this.ExecTypeVarName[245, 2] = "Value to be appended";
      this.ExecCategory[245] = 6;
      this.ExecTypeNames[246] = "ExecSetUnitStandingOrders";
      this.ExecTypeVarCount[246] = 4;
      this.ExecTypeVarName[246, 1] = "Unit#";
      this.ExecTypeVarName[246, 2] = "Retreat%";
      this.ExecTypeVarName[246, 3] = "Supply%";
      this.ExecTypeVarName[246, 4] = "Replacement%";
      this.ExecCategory[246] = 8;
      this.ExecDesc[246] = "Give unit slot number and percentages. Allows you to set a number of standing order % to a unit. If you specify -1 then the setting is not changed. Only 0-100 values are thus accepted. Retreat100% = fight till last Retreat0%=immediate retreat.";
      this.ExecTypeNames[247] = "ExecClearSpecialTypesOnMap";
      this.ExecTypeVarCount[247] = 2;
      this.ExecTypeVarName[247, 1] = "Which special type # (-1=all)";
      this.ExecTypeVarName[247, 2] = "Which sprite # (-1=all)";
      this.ExecCategory[247] = 4;
      this.ExecDesc[247] = "Remember that special types are just landscape types under another name.";
      this.ExecTypeNames[248] = "ExecSetExtraTab";
      this.ExecTypeVarCount[248] = 3;
      this.ExecTypeVarName[248, 1] = "Name of tab";
      this.ExecTypeVarName[248, 2] = "Event slot# generating message to be used";
      this.ExecTypeVarName[248, 3] = "tab# (1,2 or 3)";
      this.ExecDesc[28] = "Remember that setting the name to nothing '' disables the extra tab. Also remember that the event called is supposed to generate 1 message only: no more, no less. The message contents should fit in a 1000x200 pixel area. Not setting the third parameter or to 0 results in tab#=1.";
      this.ExecCategory[248] = 10;
      this.ExecTypeNames[249] = "ExecSetCardQuickButton";
      this.ExecTypeVarCount[249] = 3;
      this.ExecTypeVarName[249, 1] = "Card Slot#";
      this.ExecTypeVarName[249, 2] = "Quick Mode (0=no,1=yes,2=yes+hide)";
      this.ExecTypeVarName[249, 3] = "Small graphic on order button";
      this.ExecDesc[249] = "If mode>=1 then an order button will be generated if the player/ selected hex/ selected unit confirms to the (pre-event) conditions of playing a card in general/ on hex/ on unit. And enough PP must be available. You must specifiy a small graphic slot # as well for the order button.";
      this.ExecCategory[249] = 5;
      this.ExecTypeNames[250] = "ExecSetSmallLabel";
      this.ExecTypeVarCount[250] = 3;
      this.ExecTypeVarName[250, 1] = "X ";
      this.ExecTypeVarName[250, 2] = "Y";
      this.ExecTypeVarName[250, 3] = "Text";
      this.ExecCategory[250] = 4;
      this.ExecDesc[250] = "Set to empty string to reset a label to nothing. Max 9 letters will be displayed in 64x48 hex mode. but label texts can be bigger, they will just not be fully shown.";
      this.ExecTypeNames[251] = "ExecSetHistoricalUnitName";
      this.ExecTypeVarCount[251] = 3;
      this.ExecTypeVarName[251, 1] = "Historical Unit ID";
      this.ExecTypeVarName[251, 2] = "New name";
      this.ExecTypeVarName[251, 3] = "New short name";
      this.ExecCategory[251] = 13;
      this.ExecTypeNames[252] = "ExecPlayEventBackgroundWav2";
      this.ExecTypeVarCount[252] = 1;
      this.ExecTypeVarName[252, 1] = "Full file path relative to the game executable";
      this.ExecCategory[252] = 3;
      this.ExecDesc[252] = "Loads the sound file. ";
      this.ExecTypeNames[253] = "ExecActionCardCategory";
      this.ExecTypeVarCount[253] = 2;
      this.ExecTypeVarName[253, 1] = "Actioncard Nr";
      this.ExecTypeVarName[253, 2] = "New category number";
      this.ExecTypeString[253] = 0;
      this.ExecCategory[253] = 5;
      this.ExecDesc[253] = "For changing the category numner of the card";
      this.ExecTypeNames[254] = "ExecDeleteActionCard";
      this.ExecTypeVarCount[254] = 1;
      this.ExecTypeVarName[254, 1] = "Card Nr";
      this.ExecCategory[254] = 5;
      this.ExecDesc[254] = "*USE WITH CAUTION* This exec actually really deletes the card. Use ExecRemoveActionCard to keep the card but remove it from a regime hand. Deleting cards will change numbers it might cause events to break. *EXPERT USE ONLY*";
      this.ExecTypeCount = 254;
      this.ExecTypeNames[ byte.MaxValue] = "ExecSetActionCardEventPicture";
      this.ExecTypeVarCount[ byte.MaxValue] = 2;
      this.ExecTypeVarName[ byte.MaxValue, 1] = "Card Nr";
      this.ExecTypeVarName[ byte.MaxValue, 2] = "Event Picture Nr";
      this.ExecCategory[ byte.MaxValue] = 5;
      this.ExecDesc[ byte.MaxValue] = "A simple replace picture of the card. ";
      this.ExecTypeNames[256] = "ExecChanceOnDeathIfMakesHit";
      this.ExecTypeVarCount[256] = 2;
      this.ExecTypeVarName[256, 1] = "SFType#";
      this.ExecTypeVarName[256, 2] = "Percentage%";
      this.ExecTypeString[256] = 0;
      this.ExecCategory[256] = 9;
      this.ExecDesc[256] = "0% is will never die due to making a hit on enemy. 1=1% chance, etc... ";
      this.ExecTypeNames[257] = "ExecWritePDF";
      this.ExecTypeVarCount[257] = 3;
      this.ExecTypeVarName[257, 1] = "String";
      this.ExecTypeVarName[257, 2] = "Filename";
      this.ExecTypeVarName[257, 3] = "Title";
      this.ExecCategory[257] = 3;
      this.ExecDesc[257] = "The String should be coded like a dynamic message. Pagebreaks are not automatic. You need to use CheckDynamicTextHeight() to predict sizes. Pages are 595 x 842 points. Filename should be without file extension. for example 'doc' or 'oobfile'. Title is displayed as a watermarkish thing on each page on top and pagenumber in the bottom. ";
      this.ExecTypeNames[258] = "ExecGiveSupplyImmediateDisperse";
      this.ExecTypeVarCount[258] = 4;
      this.ExecTypeVarName[258, 1] = "X ";
      this.ExecTypeVarName[258, 2] = "Y";
      this.ExecTypeVarName[258, 3] = "Supply Points to be shared by all units";
      this.ExecTypeVarName[258, 4] = "AP modifier %. 100=normal. 50=only half range. 200=double range.";
      this.ExecDesc[258] = "This exec acts basically like an airdrop from ATG would work. All units in range, modified for distance immediately receive supplies. Stats are updated. It uses rulevar 99 for movement type. ap range is rulevar 3. penalties used from rulevar 51,52,53. You should call this in a late turn event.";
      this.ExecCategory[258] = 4;
      this.ExecTypeNames[259] = "ExecChangeRoadTypeMoveCost";
      this.ExecTypeVarCount[259] = 3;
      this.ExecTypeVarName[259, 1] = "RoadType #";
      this.ExecTypeVarName[259, 2] = "MovementType #";
      this.ExecTypeVarName[259, 3] = "AP Cost";
      this.ExecDesc[259] = "";
      this.ExecCategory[259] = 11;
      this.ExecTypeNames[260] = "ExecExportStringlist";
      this.ExecTypeVarCount[260] = 2;
      this.ExecTypeVarName[260, 1] = "StringListID#";
      this.ExecTypeVarName[260, 2] = "Filename";
      this.ExecCategory[260] = 16;
      this.ExecDesc[260] = "Will save the stringlist data inside specified filename. File contents will be completely overwritten. Please supply a file extenstion like .txt in the name. Will be saved in the 'metadata' directory. ";
      this.ExecTypeNames[261] = "ExecMetrics";
      this.ExecTypeVarCount[261] = 4;
      this.ExecTypeVarName[261, 1] = "Custom string/numeric data 1";
      this.ExecTypeVarName[261, 2] = "Custom string/numeric data 2";
      this.ExecTypeVarName[261, 3] = "Custom string/numeric data 3";
      this.ExecTypeVarName[261, 4] = "Custom string/numeric data 4";
      this.ExecCategory[261] = 16;
      this.ExecDesc[261] = "Will use the URL in 2nd string of the metrics.txt to pass on this data.";
      this.ExecTypeNames[262] = "ExecKey";
      this.ExecTypeVarCount[262] = 3;
      this.ExecTypeVarName[262, 1] = "StringListID#";
      this.ExecTypeVarName[262, 2] = "Key Name";
      this.ExecTypeVarName[262, 3] = "New Value";
      this.ExecCategory[262] = 16;
      this.ExecDesc[262] = "Presumes a stringlist with in column 0 the key names and in column 1 the text values. ";
      this.ExecTypeNames[263] = "ExecKeyAdd";
      this.ExecTypeVarCount[263] = 3;
      this.ExecTypeVarName[263, 1] = "StringListID#";
      this.ExecTypeVarName[263, 2] = "Key Name";
      this.ExecTypeVarName[263, 3] = "Value to be appended at end of string";
      this.ExecCategory[263] = 16;
      this.ExecDesc[263] = "Presumes a stringlist with in column 0 the key names and in column 1 the text values. Data is treated as STRINGS!! ";
      this.ExecTypeNames[264] = "ExecSetUDStabText";
      this.ExecTypeVarCount[264] = 1;
      this.ExecTypeVarName[264, 1] = "UDS Text";
      this.ExecCategory[264] = 21;
      this.ExecDesc[264] = "To set the UDS text to appear in a management tab that is selected by user. ";
      this.ExecTypeNames[265] = "ExecKeyAddNumeric";
      this.ExecTypeVarCount[265] = 3;
      this.ExecTypeVarName[265, 1] = "StringListID#";
      this.ExecTypeVarName[265, 2] = "Key Name";
      this.ExecTypeVarName[265, 3] = "Value to be appended at end of string";
      this.ExecCategory[265] = 16;
      this.ExecDesc[265] = "Presumes a stringlist with in column 0 the key names and in column 1 the text values. Data is treated as NUMERIC. ";
      this.ExecTypeNames[266] = "ExecSetUDSpopupText";
      this.ExecTypeVarCount[266] = 2;
      this.ExecTypeVarName[266, 1] = "UDS Text";
      this.ExecTypeVarName[266, 2] = "UDS Popuptype ";
      this.ExecCategory[266] = 21;
      this.ExecDesc[266] = "To set the UDS text to appear in a popup. Popup Type 0+1 = regular text popup ";
      this.ExecTypeNames[267] = "ExecSetInterfaceCue";
      this.ExecTypeVarCount[267] = 1;
      this.ExecTypeVarName[267, 1] = "Cue Type Number";
      this.ExecCategory[267] = 22;
      this.ExecDesc[267] = "Cue Type 1 = Exit Random Screen, go the scn. setup screen. 2 = Refresh everything ";
      this.ExecTypeNames[268] = "ExecNewMapSize";
      this.ExecTypeVarCount[268] = 3;
      this.ExecTypeVarName[268, 1] = "Width in hexes";
      this.ExecTypeVarName[268, 2] = "Height in hexes";
      this.ExecTypeVarName[268, 3] = "Maploop (0=no,1=yes)";
      this.ExecCategory[268] = 22;
      this.ExecDesc[268] = "Keep in mind first hex is 0,0. specifying width=1 and height=1 will result in a grand total of (1x1) 1 hex on map. width=4 an height=4 will give you 16 hexes. etc... Make sure to use even width for mapLoop enabled maps.";
      this.ExecTypeNames[269] = "ExecCopyHexToArea";
      this.ExecTypeVarCount[269] = 3;
      this.ExecTypeVarName[269, 1] = "From Library Name";
      this.ExecTypeVarName[269, 2] = "From Hex LibVar Name";
      this.ExecTypeVarName[269, 3] = "Too AreaSlot #";
      this.ExecCategory[269] = 22;
      this.ExecDesc[269] = "Copies numeric values from libvar to areaslot";
      this.ExecTypeNames[270] = "ExecCopyAreaToHex";
      this.ExecTypeVarCount[270] = 3;
      this.ExecTypeVarName[270, 1] = "From AreaSlot #";
      this.ExecTypeVarName[270, 2] = "Too Library Name";
      this.ExecTypeVarName[270, 3] = "Too Hex LibVar Name";
      this.ExecCategory[270] = 22;
      this.ExecDesc[270] = "Copies numeric values from libvar to areaslot";
      this.ExecTypeNames[271] = "ExecCopyAreaToArea";
      this.ExecTypeVarCount[271] = 2;
      this.ExecTypeVarName[271, 1] = "From AreaSlot #";
      this.ExecTypeVarName[271, 2] = "Too AreaSlot #";
      this.ExecCategory[271] = 22;
      this.ExecDesc[271] = "Copies numeric values from one areaslot to another areaslot";
      this.ExecTypeNames[272] = "ExecAreaSet";
      this.ExecTypeVarCount[272] = 4;
      this.ExecTypeVarName[272, 1] = "AreaSlot#";
      this.ExecTypeVarName[272, 2] = "New Value";
      this.ExecTypeVarName[272, 3] = "Optional Second AreaSlot#";
      this.ExecTypeVarName[272, 4] = "Second Slot Value";
      this.ExecCategory[272] = 22;
      this.ExecDesc[272] = "Set the values of all the hexes. If -1 is specified second areaslot is not used. If second areaslot is used only hexes with specified second slot value are changed. You can of course specify the same areaslot for the second to use this exec as a replace function.";
      this.ExecTypeNames[273] = "ExecAreaAdd";
      this.ExecTypeVarCount[273] = 4;
      this.ExecTypeVarName[273, 1] = "AreaSlot#";
      this.ExecTypeVarName[273, 2] = "Value Change +/-";
      this.ExecTypeVarName[273, 3] = "Optional Second AreaSlot#";
      this.ExecTypeVarName[273, 4] = "Second Slot Value";
      this.ExecCategory[273] = 22;
      this.ExecDesc[273] = "Modifies the values of all the hexes. If -1 is specified second areaslot is not used. If second areaslot is used only hexes with specified second slot value are changed.";
      this.ExecTypeNames[274] = "ExecAreaExpand";
      this.ExecTypeVarCount[274] = 4;
      this.ExecTypeVarName[274, 1] = "AreaSlot#";
      this.ExecTypeVarName[274, 2] = "Value increase";
      this.ExecTypeVarName[274, 3] = "Optional Second AreaSlot# (or -2 for random mode)";
      this.ExecTypeVarName[274, 4] = "Second Slot Value (or randomness 0-100)";
      this.ExecCategory[274] = 22;
      this.ExecDesc[274] = "Value increase must be >0, 0 or <0. Any value in the areaslot >0 will be expand to neighbouring hexes with lower values and the new value of that hex will be old value +/- value change. Allows you to create distance maps.  If -1 is specified second areaslot is not used. If second areaslot is used only hexes with specified second slot value are changed. If value change 0 is used the values are just copied into any neighbours with 0 value.";
      this.ExecTypeNames[275] = "ExecAreaRangeChange";
      this.ExecTypeVarCount[275] = 4;
      this.ExecTypeVarName[275, 1] = "AreaSlot#";
      this.ExecTypeVarName[275, 2] = "Minimum or equal value";
      this.ExecTypeVarName[275, 3] = "Maximum or equal value";
      this.ExecTypeVarName[275, 4] = "New value";
      this.ExecCategory[275] = 22;
      this.ExecDesc[275] = "If value is beween min or max or equal than its changed for a new value. Ideal for creating a mask to be used as a second areaslot for another areaslot modifying exec.";
      this.ExecTypeNames[276] = "ExecAreaToStringlist";
      this.ExecTypeVarCount[276] = 2;
      this.ExecTypeVarName[276, 1] = "AreaSlot #";
      this.ExecTypeVarName[276, 2] = "Stringlist ID#";
      this.ExecCategory[276] = 22;
      this.ExecDesc[276] = "Each UNIQUE value in the areaslots will be put in column 0 and the count of the number of hexes with that value in column 1.";
      this.ExecTypeNames[277] = "ExecFindBorders";
      this.ExecTypeVarCount[277] = 4;
      this.ExecTypeVarName[277, 1] = "AreaSlot#";
      this.ExecTypeVarName[277, 2] = "Value A";
      this.ExecTypeVarName[277, 3] = "Value B";
      this.ExecTypeVarName[277, 4] = "Border Mode";
      this.ExecCategory[277] = 22;
      this.ExecDesc[277] = "Will set all values to 0 except for some that are set to 1 and that are those that are value A with a neighbour hex with value B. Value A can be a specific value or -1 for all values. Value B the same. Even if both values are set to -1 a border will not be detected if hex value and its neighbour value are the same. Only hexes with a value higher >0 are taken into consideration. BorderMode 1 is flag both value A and value B, BorderMode 2 is just flag value A hexes.  ";
      this.ExecTypeNames[278] = "ExecScreenshot";
      this.ExecTypeVarCount[278] = 2;
      this.ExecTypeVarName[278, 1] = "AreaSlot#";
      this.ExecTypeVarName[278, 2] = "Filename";
      this.ExecCategory[278] = 10;
      this.ExecDesc[278] = "Please give the filename without extension. .jpg will be added automaticly. just 'test' will do. Or 'pic12'.  ";
      this.ExecTypeNames[280] = "ExecSetStringListQuick";
      this.ExecTypeVarCount[280] = 4;
      this.ExecTypeVarName[280, 1] = "Stringlist ID #";
      this.ExecTypeVarName[280, 2] = "Rows where Col0 is..";
      this.ExecTypeVarName[280, 3] = "Col";
      this.ExecTypeVarName[280, 4] = "New Value";
      this.ExecDesc[280] = "This Quick version of ExecSetStringList allows you to operate quickly if the col0 of the stringlist are ID numbers. Avoids you from having to loop through the whole thing. ";
      this.ExecCategory[280] = 16;
      this.ExecTypeNames[281] = "ExecAreaJoin";
      this.ExecTypeVarCount[281] = 4;
      this.ExecTypeVarName[281, 1] = "Target AreaSlot#";
      this.ExecTypeVarName[281, 2] = "Source AreaSlot#";
      this.ExecTypeVarName[281, 3] = "Mode";
      this.ExecTypeVarName[281, 4] = "Percentage (100=advise)";
      this.ExecCategory[281] = 22;
      this.ExecDesc[281] = "Mode = 1 is copy to target if higher. Mode = 2 is make average. The source value will be modified by percentage before applying mode and the operation.";
      this.ExecTypeNames[282] = "ExecAreaBlur";
      this.ExecTypeVarCount[282] = 4;
      this.ExecTypeVarName[282, 1] = "AreaSlot#";
      this.ExecTypeVarName[282, 2] = "Distance";
      this.ExecTypeVarName[282, 3] = "Percentage to blur";
      this.ExecTypeVarName[282, 4] = "Mode";
      this.ExecCategory[282] = 22;
      this.ExecDesc[282] = "Mode=1 is all blur results are accepteble. Mode=2 only higher resulting values are exceptable";
      this.ExecTypeNames[283] = "ExecPopup";
      this.ExecTypeVarCount[283] = 1;
      this.ExecTypeVarName[283, 1] = "Message";
      this.ExecCategory[283] = 10;
      this.ExecDesc[283] = "Causes a Windows Popup that halts all further event execution untill OK is pressed. Ideal for debugging.  ";
      this.ExecTypeNames[284] = "ExecAreaBlur2";
      this.ExecTypeVarCount[284] = 4;
      this.ExecTypeVarName[284, 1] = "AreaSlot#";
      this.ExecTypeVarName[284, 2] = "Percentage to Blur";
      this.ExecTypeVarName[284, 3] = "Optional Second Areaslot#";
      this.ExecTypeVarName[284, 4] = "Value required at minimum";
      this.ExecCategory[284] = 22;
      this.ExecDesc[284] = "Adaption of ExecAreaBlur. Uses Distance = 1 and mode that allows only lower results. It is meant to simulate erosion on land masses. ";
      this.ExecTypeNames[285] = "ExecAreaDivide";
      this.ExecTypeVarCount[285] = 4;
      this.ExecTypeVarName[285, 1] = "AreaSlot#";
      this.ExecTypeVarName[285, 2] = "Divide by value";
      this.ExecTypeVarName[285, 3] = "Optional Second AreaSlot#";
      this.ExecTypeVarName[285, 4] = "Second Slot Value";
      this.ExecCategory[285] = 22;
      this.ExecDesc[285] = "Modifies the values of all the hexes. If -1 is specified second areaslot is not used. If second areaslot is used only hexes with specified second slot value are changed.";
      this.ExecTypeNames[286] = "ExecSetStringPart";
      this.ExecTypeVarCount[286] = 3;
      this.ExecTypeVarName[286, 1] = "Tempstring #";
      this.ExecTypeVarName[286, 2] = "Part #";
      this.ExecTypeVarName[286, 3] = "String/Value";
      this.ExecCategory[286] = 16;
      this.ExecDesc[286] = "Sets specified part to the string/value specified.";
      this.ExecTypeNames[287] = "ExecStringPartAdd";
      this.ExecTypeVarCount[287] = 2;
      this.ExecTypeVarName[287, 1] = "Tempstring #";
      this.ExecTypeVarName[287, 2] = "String/Value";
      this.ExecCategory[287] = 16;
      this.ExecDesc[287] = "Adds a new subpart with string/value specified at the end of the tempstring#.";
      this.ExecTypeNames[288] = "ExecSetShrowd";
      this.ExecTypeVarCount[288] = 1;
      this.ExecTypeVarName[288, 1] = "On(1)/Off(0)";
      this.ExecCategory[288] = 22;
      this.ExecDesc[288] = "Switch shrowd on/off.";
      this.ExecTypeNames[289] = "ExecAreaMinMax";
      this.ExecTypeVarCount[289] = 3;
      this.ExecTypeVarName[289, 1] = "AreaSlot#";
      this.ExecTypeVarName[289, 2] = "Minimum value";
      this.ExecTypeVarName[289, 3] = "Maximum value";
      this.ExecCategory[289] = 22;
      this.ExecDesc[289] = "Assures no value in area is below minimum or above maximum.";
      this.ExecTypeNames[290] = "ExecAreaRandomize";
      this.ExecTypeVarCount[290] = 4;
      this.ExecTypeVarName[290, 1] = "AreaSlot#";
      this.ExecTypeVarName[290, 2] = "Maximum negative randomize";
      this.ExecTypeVarName[290, 3] = "Maximum positive randomize";
      this.ExecTypeVarName[290, 4] = "Only randomize values above or equal value";
      this.ExecCategory[290] = 22;
      this.ExecDesc[290] = "Changes the areaslot values based on random rolls.";
      this.ExecTypeNames[305] = "ExecSetUDSbottomText";
      this.ExecTypeVarCount[305] = 1;
      this.ExecTypeVarName[305, 1] = "UDS Text";
      this.ExecCategory[305] = 21;
      this.ExecDesc[305] = "To set the UDS text to appear in a bottom tab that is selected by user. ";
      this.ExecTypeNames[308] = "ExecChangeLocationLISitem";
      this.ExecTypeVarCount[308] = 4;
      this.ExecTypeVarName[308, 1] = "Location slot#";
      this.ExecTypeVarName[308, 2] = "LIS item ID";
      this.ExecTypeVarName[308, 3] = "Qty";
      this.ExecTypeVarName[308, 4] = "Extra instruction";
      this.ExecCategory[308] = 21;
      this.ExecDesc[308] = "Extra instruction<1 is ADD/SUBTRACT. Extra instruction 1 is OVERWRITE.";
      this.ExecTypeNames[309] = "ExecChangeUnitLISitem";
      this.ExecTypeVarCount[309] = 4;
      this.ExecTypeVarName[309, 1] = "Unit slot#";
      this.ExecTypeVarName[309, 2] = "LIS item ID";
      this.ExecTypeVarName[309, 3] = "Qty";
      this.ExecTypeVarName[309, 4] = "Extra instruction";
      this.ExecCategory[309] = 21;
      this.ExecDesc[309] = "Extra instruction<1 is ADD/SUBTRACT. Extra instruction 1 is OVERWRITE.";
      this.ExecTypeNames[312] = "ExecClearLISpoints";
      this.ExecTypeVarCount[312] = 0;
      this.ExecCategory[312] = 21;
      this.ExecDesc[312] = "Clear all temporary LIS points and free AP points. They are used by the hardcoded LIS_SetNetwork. ";
      this.ExecTypeNames[313] = "ExecSetLISpoints";
      this.ExecTypeVarCount[313] = 4;
      this.ExecTypeVarName[313, 1] = "Location slot#";
      this.ExecTypeVarName[313, 2] = "LIS Transport Mode ID";
      this.ExecTypeVarName[313, 3] = "(optional) Target ID";
      this.ExecTypeVarName[313, 4] = "Add Points";
      this.ExecCategory[313] = 21;
      this.ExecDesc[313] = "LIS Points are added to the ID+Target combination. Put -1 if no target. ";
      this.ExecTypeNames[314] = "ExecSetLISfreeAP";
      this.ExecTypeVarCount[314] = 4;
      this.ExecTypeVarName[314, 1] = "Location slot#";
      this.ExecTypeVarName[314, 2] = "LIS Transport Mode ID";
      this.ExecTypeVarName[314, 3] = "(optional) Target ID";
      this.ExecTypeVarName[314, 4] = "Add Free AP";
      this.ExecCategory[314] = 21;
      this.ExecDesc[314] = "LIS Free AP Points are added to the ID+Target combination. Put -1 if no target. ";
      this.ExecTypeNames[343] = "ExecSetLogic";
      this.ExecTypeVarCount[343] = 3;
      this.ExecCategory[343] = 22;
      this.ExecTypeVarName[343, 1] = "Flag Stringlist ID";
      this.ExecTypeVarName[343, 2] = "Flag Instructions Stringlist ID";
      this.ExecTypeVarName[343, 3] = "Logic String";
      this.ExecDesc[343] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[292] = "ExecMakeErosionAndRainMap";
      this.ExecTypeVarCount[292] = 1;
      this.ExecTypeVarName[292, 1] = "Stringlist ID for Planetary Data";
      this.ExecCategory[292] = 22;
      this.ExecDesc[292] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[293] = "ExecMakeHeightMapBasedOnTectonicPlates";
      this.ExecTypeVarCount[293] = 1;
      this.ExecTypeVarName[293, 1] = "Stringlist ID for Planetary Data";
      this.ExecCategory[293] = 22;
      this.ExecDesc[293] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[294] = "ExecMakeMountainsCorrectHeight";
      this.ExecTypeVarCount[294] = 1;
      this.ExecTypeVarName[294, 1] = "Stringlist ID for Planetary Data";
      this.ExecCategory[294] = 22;
      this.ExecDesc[294] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[295] = "ExecMakeVegetation";
      this.ExecTypeVarCount[295] = 4;
      this.ExecTypeVarName[295, 1] = "Stringlist ID for Planetary Data";
      this.ExecTypeVarName[295, 2] = "Stringlist ID for Helper Table";
      this.ExecTypeVarName[295, 3] = "Stringlist ID for Translation Table";
      this.ExecTypeVarName[295, 4] = "Last call 0=no, 1=yes";
      this.ExecCategory[295] = 22;
      this.ExecDesc[295] = "The last call sets the origLandscapes. and is the point were we should save the vegetation into them. ";
      this.ExecTypeNames[296] = "ExecMakeZones";
      this.ExecTypeVarCount[296] = 4;
      this.ExecTypeVarName[296, 1] = "Stringlist ID for Planetary Data";
      this.ExecTypeVarName[296, 2] = "Stringlist ID for Vegetation Similarity Table";
      this.ExecTypeVarName[296, 3] = "Library name Random";
      this.ExecTypeVarName[296, 4] = "Library name Data";
      this.ExecCategory[296] = 22;
      this.ExecDesc[296] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[297] = "ExecMakeBiosphereAndAtmosphere";
      this.ExecTypeVarCount[297] = 2;
      this.ExecTypeVarName[297, 1] = "Random Library Name";
      this.ExecTypeVarName[297, 2] = "Data Library Name";
      this.ExecCategory[297] = 22;
      this.ExecDesc[297] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[299] = "ExecMakeBiosphereDetail";
      this.ExecTypeVarCount[299] = 3;
      this.ExecTypeVarName[299, 1] = "Random Library Name";
      this.ExecTypeVarName[299, 2] = "Data Library Name";
      this.ExecTypeVarName[299, 3] = "Linguistic Library Name";
      this.ExecCategory[299] = 22;
      this.ExecDesc[299] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[300] = "ExecMakeBiosphereSimulation";
      this.ExecTypeVarCount[300] = 4;
      this.ExecTypeVarName[300, 1] = "Random Library Name";
      this.ExecTypeVarName[300, 2] = "Data Library Name";
      this.ExecTypeVarName[300, 3] = "Initial Call (0/1)";
      this.ExecTypeVarName[300, 4] = "Number of rounds to simulate";
      this.ExecCategory[300] = 22;
      this.ExecDesc[300] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[301] = "ExecMakeColonyLanding";
      this.ExecTypeVarCount[301] = 3;
      this.ExecTypeVarName[301, 1] = "Random Library Name";
      this.ExecTypeVarName[301, 2] = "Data Library Name";
      this.ExecTypeVarName[301, 3] = "Linguistics Library Name";
      this.ExecCategory[301] = 22;
      this.ExecDesc[301] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[302] = "ExecMakeColonyHistory";
      this.ExecTypeVarCount[302] = 3;
      this.ExecTypeVarName[302, 1] = "Random Library Name";
      this.ExecTypeVarName[302, 2] = "Data Library Name";
      this.ExecTypeVarName[302, 3] = "Linguistics Library Name";
      this.ExecCategory[302] = 22;
      this.ExecDesc[302] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[303] = "ExecMakeDissolutionHistory";
      this.ExecTypeVarCount[303] = 3;
      this.ExecTypeVarName[303, 1] = "Random Library Name";
      this.ExecTypeVarName[303, 2] = "Data Library Name";
      this.ExecTypeVarName[303, 3] = "Linguistics Library Name";
      this.ExecCategory[303] = 22;
      this.ExecDesc[303] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[304] = "ExecMakeSurvivors";
      this.ExecTypeVarCount[304] = 3;
      this.ExecTypeVarName[304, 1] = "Random Library Name";
      this.ExecTypeVarName[304, 2] = "Data Library Name";
      this.ExecTypeVarName[304, 3] = "Linguistics Library Name";
      this.ExecCategory[304] = 22;
      this.ExecDesc[304] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[315] = "ExecMakeListForLocationRequests";
      this.ExecTypeVarCount[315] = 2;
      this.ExecTypeVarName[315, 1] = "Data Library Name";
      this.ExecTypeVarName[315, 2] = "Zone ID or -1 for all";
      this.ExecCategory[315] = 22;
      this.ExecDesc[315] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[316] = "ExecMakeListForLocationReturns";
      this.ExecTypeVarCount[316] = 2;
      this.ExecTypeVarName[316, 1] = "Data Library Name";
      this.ExecTypeVarName[316, 2] = "Zone ID or -1 for all";
      this.ExecCategory[316] = 22;
      this.ExecDesc[316] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[317] = "ExecMakeFreeLocationReturns";
      this.ExecTypeVarCount[317] = 0;
      this.ExecCategory[317] = 22;
      this.ExecDesc[317] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[318] = "ExecMakeProduction";
      this.ExecTypeVarCount[318] = 3;
      this.ExecTypeVarName[318, 1] = "Data Library Name";
      this.ExecTypeVarName[318, 2] = "Zone ID or -1 for all";
      this.ExecTypeVarName[318, 3] = "Free of cost 0/1";
      this.ExecCategory[318] = 22;
      this.ExecDesc[318] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[319] = "ExecMakeZoneEconomy";
      this.ExecTypeVarCount[319] = 4;
      this.ExecTypeVarName[319, 1] = "Data Library Name";
      this.ExecTypeVarName[319, 2] = "Zone ID or -1 for all";
      this.ExecTypeVarName[319, 3] = "Free of cost 0/1";
      this.ExecTypeVarName[319, 4] = "Game Setup 0/1";
      this.ExecCategory[319] = 22;
      this.ExecDesc[319] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[320] = "ExecMakeAssetPresentation";
      this.ExecTypeVarCount[320] = 3;
      this.ExecTypeVarName[320, 1] = "Data Library Name";
      this.ExecTypeVarName[320, 2] = "Asset Row Number";
      this.ExecTypeVarName[320, 3] = "Mode";
      this.ExecCategory[320] = 22;
      this.ExecDesc[320] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc. Mode 0/1=normal, >1=all the ones above this count, -1=all";
      this.ExecTypeNames[321] = "ExecHardcodedScript";
      this.ExecTypeVarCount[321] = 2;
      this.ExecTypeVarName[321, 1] = "Hardcoded Number >0";
      this.ExecTypeVarName[321, 2] = "Create Feedback Message 0/1";
      this.ExecCategory[321] = 22;
      this.ExecDesc[321] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc. Mode 0/1=normal, >1=all the ones above this count, -1=all";
      this.ExecTypeNames[322] = "ExecMakeUnitUpkeepCheck";
      this.ExecTypeVarCount[322] = 1;
      this.ExecTypeVarName[322, 1] = "Data Library Name";
      this.ExecCategory[322] = 22;
      this.ExecDesc[322] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc. Mode 0/1=normal, >1=all the ones above this count, -1=all";
      this.ExecTypeNames[323] = "ExecMakeListForUnitRequests";
      this.ExecTypeVarCount[323] = 2;
      this.ExecTypeVarName[323, 1] = "Data Library Name";
      this.ExecTypeVarName[323, 2] = "historical unit ID or -1 for all";
      this.ExecCategory[323] = 22;
      this.ExecDesc[323] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[324] = "ExecMakeFreeUnitSupply";
      this.ExecTypeVarCount[324] = 0;
      this.ExecCategory[324] = 22;
      this.ExecDesc[324] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[325] = "ExecRemoveLIS";
      this.ExecTypeVarCount[325] = 4;
      this.ExecTypeVarName[325, 1] = "Loc nr";
      this.ExecTypeVarName[325, 2] = "To X";
      this.ExecTypeVarName[325, 3] = "To Y";
      this.ExecTypeVarName[325, 3] = "LIS points";
      this.ExecCategory[325] = 22;
      this.ExecDesc[325] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc. Mode 0/1=normal, >1=all the ones above this count, -1=all";
      this.ExecTypeNames[326] = "ExecResetForRandom";
      this.ExecTypeVarCount[326] = 3;
      this.ExecTypeVarName[326, 1] = "Random Library Name";
      this.ExecTypeVarName[326, 2] = "Data Library Name";
      this.ExecTypeVarName[326, 3] = "Reset Code";
      this.ExecCategory[326] = 22;
      this.ExecDesc[326] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[327] = "ExecMakeCustomRandomPage";
      this.ExecTypeVarCount[327] = 3;
      this.ExecTypeVarName[327, 1] = "Random Library Name";
      this.ExecTypeVarName[327, 2] = "Data Library Name";
      this.ExecTypeVarName[327, 3] = "Custom Page ID ";
      this.ExecCategory[327] = 22;
      this.ExecDesc[327] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[328] = "ExecMakeStoryGeneration";
      this.ExecTypeVarCount[328] = 1;
      this.ExecTypeVarName[328, 1] = "Mode.. 1<=early, 2=late";
      this.ExecTypeVarName[328, 2] = "";
      this.ExecTypeVarName[328, 3] = " ";
      this.ExecCategory[328] = 22;
      this.ExecDesc[328] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[329] = "ExecHardcodedStory";
      this.ExecTypeVarCount[329] = 4;
      this.ExecTypeVarName[329, 1] = "tv0";
      this.ExecTypeVarName[329, 2] = "tv1";
      this.ExecTypeVarName[329, 3] = "tv2 (tempvar4)";
      this.ExecTypeVarName[329, 4] = "tv3 (tempvar5)";
      this.ExecCategory[329] = 22;
      this.ExecDesc[329] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[330] = "ExecSetDssDominant";
      this.ExecTypeVarCount[330] = 1;
      this.ExecTypeVarName[330, 1] = "Dominant ID (or -1)";
      this.ExecCategory[330] = 22;
      this.ExecDesc[330] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[331] = "ExecHardcodedDecision";
      this.ExecTypeVarCount[331] = 0;
      this.ExecCategory[331] = 22;
      this.ExecDesc[331] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[332] = "ExecMakeStartOfRound";
      this.ExecTypeVarCount[332] = 0;
      this.ExecCategory[332] = 22;
      this.ExecDesc[332] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[333] = "ExecMakeCloseTurn";
      this.ExecTypeVarCount[333] = 0;
      this.ExecCategory[333] = 22;
      this.ExecDesc[333] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[334] = "ExecMakeStartTurn";
      this.ExecTypeVarCount[334] = 0;
      this.ExecCategory[334] = 22;
      this.ExecDesc[334] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[342] = "ExecCustomDataImport";
      this.ExecTypeVarCount[342] = 2;
      this.ExecCategory[342] = 22;
      this.ExecTypeVarName[342, 1] = "Stringlist ID";
      this.ExecTypeVarName[342, 2] = "Data Import Mode";
      this.ExecDesc[342] = "1 = Basic Story (Model Alpha).";
      this.ExecTypeNames[344] = "ExecSetWholeLIS";
      this.ExecTypeVarCount[344] = 0;
      this.ExecCategory[344] = 22;
      this.ExecDesc[344] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[345] = "ExecMakeLateStartTurn";
      this.ExecTypeVarCount[345] = 0;
      this.ExecCategory[345] = 22;
      this.ExecDesc[345] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[346] = "ExecHardcodedSet";
      this.ExecTypeVarCount[346] = 3;
      this.ExecCategory[346] = 22;
      this.ExecTypeVarName[346, 1] = "type";
      this.ExecTypeVarName[346, 2] = "custom 1";
      this.ExecTypeVarName[346, 3] = "custom 2";
      this.ExecTypeVarName[346, 4] = "custom 3";
      this.ExecDesc[346] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[347] = "ExecMakeEarlyCinematics";
      this.ExecTypeVarCount[347] = 0;
      this.ExecCategory[347] = 22;
      this.ExecDesc[347] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[348] = "ExecMakeLoadGameEarly";
      this.ExecTypeVarCount[348] = 0;
      this.ExecCategory[348] = 22;
      this.ExecDesc[348] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[349] = "ExecSuperImposeMessage";
      this.ExecTypeVarCount[349] = 2;
      this.ExecCategory[349] = 22;
      this.ExecTypeVarName[349, 1] = "text Heading";
      this.ExecTypeVarName[349, 2] = "text Small";
      this.ExecDesc[349] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[352] = "ExecMakeHardcodedSFTypeMods";
      this.ExecTypeVarCount[352] = 1;
      this.ExecCategory[352] = 22;
      this.ExecTypeVarName[352, 1] = "SFType Slot#";
      this.ExecDesc[352] = "This is a hardcoded random generation function. Please ask for documentation how to use if necc.";
      this.ExecTypeNames[357] = "ExecUdsFileOps";
      this.ExecTypeVarCount[357] = 2;
      this.ExecCategory[357] = 22;
      this.ExecTypeVarName[357, 1] = "1=Save, 2=Load";
      this.ExecTypeVarName[357, 2] = "Filename";
      this.ExecDesc[357] = "Saves the UDS keys. Loads the keys in TempUDS";
      this.ExecTypeNames[350] = "ExecHardcodedDC";
      this.ExecTypeVarCount[350] = 4;
      this.ExecCategory[350] = 10;
      this.ExecTypeVarName[350, 1] = "Data1";
      this.ExecTypeVarName[350, 2] = "Data2";
      this.ExecTypeVarName[350, 3] = "Data3";
      this.ExecTypeVarName[350, 4] = "Data4";
      this.ExecDesc[350] = "This is a hardcoded function. It is not meant for general use. And should be used by VR only. (For VR Weather Library => Data1=1,Data2=Lib Name,Data3=Mode(1=editor,2=new round))";
      this.ExecTypeNames[279] = "ExecSetHistoricalSmallGfx";
      this.ExecTypeVarCount[279] = 2;
      this.ExecTypeVarName[279, 1] = "Historical Unit ID";
      this.ExecTypeVarName[279, 2] = "New Small Gfx slot#";
      this.ExecCategory[279] = 13;
      this.ExecTypeNames[291] = "ExecSetHistoricalColor";
      this.ExecTypeVarCount[291] = 4;
      this.ExecTypeVarName[291, 1] = "Historical Unit ID";
      this.ExecTypeVarName[291, 2] = "Red modifier";
      this.ExecTypeVarName[291, 3] = "Green modifier";
      this.ExecTypeVarName[291, 4] = "Blue modifier";
      this.ExecCategory[291] = 13;
      this.ExecDesc[291] = "Remember you cannot set the color using Historical unit colors, only the modifier to the regime or people color of the counter. For example -50 or +100. ";
      this.ExecTypeNames[298] = "ExecCopyStringlist";
      this.ExecTypeVarCount[298] = 4;
      this.ExecTypeVarName[298, 1] = "From ID";
      this.ExecTypeVarName[298, 2] = "Too ID";
      this.ExecTypeVarName[298, 3] = "Number of columns";
      this.ExecTypeVarName[298, 4] = "Mode 1=clear&copy, 2=add. columns can be set to 99 or something very high to include all";
      this.ExecCategory[298] = 16;
      this.ExecTypeNames[306] = "ExecChangeLocationHQ";
      this.ExecTypeVarCount[306] = 2;
      this.ExecTypeVarName[306, 1] = "Location Slot#";
      this.ExecTypeVarName[306, 2] = "HQ Unit Slot#";
      this.ExecCategory[306] = 4;
      this.ExecTypeNames[307] = "ExecSetHistoricalRegime";
      this.ExecTypeVarCount[307] = 2;
      this.ExecTypeVarName[307, 1] = "Historical Unit ID";
      this.ExecTypeVarName[307, 2] = "Regime slot#";
      this.ExecCategory[307] = 13;
      this.ExecDesc[307] = "Sets the historical to the correct regime.";
      this.ExecTypeNames[310] = "ExecDoubleKey";
      this.ExecTypeVarCount[310] = 4;
      this.ExecTypeVarName[310, 1] = "StringListID#";
      this.ExecTypeVarName[310, 2] = "Col0 value";
      this.ExecTypeVarName[310, 3] = "Key Name";
      this.ExecTypeVarName[310, 4] = "New Value";
      this.ExecCategory[310] = 16;
      this.ExecDesc[310] = "Presumes a stringlist with in column 1 the key names and in column 2 the text values. ";
      this.ExecTypeNames[311] = "ExecDoubleKeyAppend";
      this.ExecTypeVarCount[311] = 4;
      this.ExecTypeVarName[311, 1] = "StringListID#";
      this.ExecTypeVarName[311, 2] = "Col0 value";
      this.ExecTypeVarName[311, 3] = "Key Name";
      this.ExecTypeVarName[311, 4] = "Value to append";
      this.ExecCategory[311] = 16;
      this.ExecDesc[311] = "Presumes a stringlist with in column 1 the key names and in column 2 the text values. ";
      this.ExecTypeNames[336] = "ExecSFTypeFavorite";
      this.ExecTypeVarCount[336] = 4;
      this.ExecTypeVarName[336, 1] = "SFType";
      this.ExecTypeVarName[336, 2] = "Targetgroup# (-1=all)";
      this.ExecTypeVarName[336, 3] = "Favorite score for regular attack";
      this.ExecTypeVarName[336, 4] = "Favorite score for art attack";
      this.ExecTypeString[336] = 0;
      this.ExecCategory[336] = 9;
      this.ExecTypeNames[337] = "ExecSFTypeArtPower";
      this.ExecTypeVarCount[337] = 3;
      this.ExecTypeVarName[337, 1] = "SFType";
      this.ExecTypeVarName[337, 2] = "Targetgroup# (-1=all)";
      this.ExecTypeVarName[337, 3] = "Art Power";
      this.ExecTypeString[337] = 0;
      this.ExecCategory[337] = 9;
      this.ExecTypeNames[338] = "ExecSFTypeStat";
      this.ExecTypeVarCount[338] = 3;
      this.ExecTypeVarName[338, 1] = "SFType";
      this.ExecTypeVarName[338, 2] = "Stat Number";
      this.ExecTypeVarName[338, 3] = "New Value";
      this.ExecTypeString[338] = 0;
      this.ExecCategory[338] = 9;
      this.ExecDesc[338] = "Stat Numbers: 1=weight, 2=carrycap, 3=canDoParadrop(0/1), 4=EP, 5=BlowBridgPts, 6=BasicSupNeed, 7=SupCarry, 8=ReconPts, 9=HidePts, 10=AntiSupplyPts, 11=AntiSupplyRange, 12=AnitSupplySea, 13=InitiativeAtt, 14=InitiativeDef, 15=Attacks, 16=StackPts, 17=RearArea(0/1), 18=ArtRange, 19=Fav.Target tries, 20=AA-range, 21=HitKill%, 22=HitRetreat%, 23=ArtilleryModSfTypeNr, 24=maxAttacked, 25=moveRedux";
      this.ExecTypeNames[339] = "ExecSFTypeLandscapeCombatMod";
      this.ExecTypeVarCount[339] = 4;
      this.ExecTypeVarName[339, 1] = "SFType#";
      this.ExecTypeVarName[339, 2] = "LandscapeType# (-1=all)";
      this.ExecTypeVarName[339, 3] = "Off Mod in percentage points. 100=noMod, 50=half, 200=double";
      this.ExecTypeVarName[339, 4] = "Def Mod in percentage points. 100=noMod, 50=half, 200=double";
      this.ExecTypeString[339] = 0;
      this.ExecCategory[339] = 9;
      this.ExecTypeNames[340] = "ExecSFTypeSetName";
      this.ExecTypeVarCount[340] = 3;
      this.ExecTypeVarName[340, 1] = "SFType#";
      this.ExecTypeVarName[340, 2] = "Name (if length>1) ";
      this.ExecTypeVarName[340, 3] = "ModelName (if length>1)";
      this.ExecTypeString[340] = 0;
      this.ExecCategory[340] = 9;
      this.ExecDesc[340] = "Warning: Highly experimental if used together with model creation. Name changes the name of the current SFType. ModelName changes the name of upgrades or improvements from this sfType. The hardcoded algorithms should still remember the version and mark numbers no matter if you change the modelName.";
      this.ExecTypeNames[341] = "ExecSFTypeReinforcementType";
      this.ExecTypeVarCount[341] = 2;
      this.ExecTypeVarName[341, 1] = "SFType";
      this.ExecTypeVarName[341, 2] = "ReinforcementType";
      this.ExecTypeString[341] = 0;
      this.ExecCategory[341] = 9;
      this.ExecTypeNames[351] = "ExecLocStats";
      this.ExecTypeVarCount[351] = 4;
      this.ExecTypeVarName[351, 1] = "Loc#";
      this.ExecTypeVarName[351, 2] = "Stat #";
      this.ExecTypeVarName[351, 3] = "Mode 0/1=%, 2=absolute new value";
      this.ExecTypeVarName[351, 4] = "Value";
      this.ExecCategory[351] = 4;
      this.ExecDesc[351] = "Stats: 1=supply points, 2=fuel points, 3=mode var, 4=fixed var";
      this.ExecTypeNames[353] = "ExecChangeUnitStats";
      this.ExecTypeVarCount[353] = 3;
      this.ExecTypeVarName[353, 1] = "Unit #";
      this.ExecTypeVarName[353, 2] = "Stat #";
      this.ExecTypeVarName[353, 3] = "Value";
      this.ExecCategory[353] = 4;
      this.ExecDesc[353] = "Stat # 1=Readiness, 2=Entrenchment, 3=Morale, 4=Experience";
      this.ExecTypeNames[354] = "ExecChangeLocationType2";
      this.ExecTypeVarCount[354] = 4;
      this.ExecTypeVarName[354, 1] = "X";
      this.ExecTypeVarName[354, 2] = "Y";
      this.ExecTypeVarName[354, 3] = "Loctype (-1=remove any location)";
      this.ExecTypeVarName[354, 4] = "People #";
      this.ExecTypeString[354] = 2;
      this.ExecCategory[354] = 4;
      this.ExecDesc[354] = "Only use this for Supply Base/Source location types.";
      this.ExecTypeNames[355] = "ExecGiveFuel";
      this.ExecTypeVarCount[355] = 4;
      this.ExecTypeVarName[355, 1] = "X ";
      this.ExecTypeVarName[355, 2] = "Y";
      this.ExecTypeVarName[355, 3] = "Fuel Points on x,y";
      this.ExecTypeVarName[355, 4] = "Overrule recipient regime with regime #";
      this.ExecDesc[355] = "Only works for Supply Sources active (471). Overule recipient is inactive if put to 0. If no overrule the supplies are given to closest unit owned by regime that owns hex. But >0 is overrule 1=reg 0, 2=reg1 !!!! This +1 shift is inhere to keep backwards compatible with AdvTactics scenarios.";
      this.ExecCategory[355] = 4;
      this.ExecTypeNames[356] = "ExecMoveTypeTransportType";
      this.ExecTypeVarCount[356] = 2;
      this.ExecTypeVarName[356, 1] = "MoveType#";
      this.ExecTypeVarName[356, 2] = "Transport Type (0=none, 1=Transporter, 2=Attachable)";
      this.ExecCategory[356] = 14;
      this.ExecTypeNames[358] = "ExecSetRegimeSetting";
      this.ExecTypeVarCount[358] = 3;
      this.ExecTypeVarName[358, 1] = "Regime Slot#";
      this.ExecTypeVarName[358, 2] = "Setting# 1=alternate card gfx";
      this.ExecTypeVarName[358, 3] = "Value";
      this.ExecCategory[358] = 14;
      this.ExecTypeNames[359] = "ExecModifyUnitFuel";
      this.ExecTypeVarCount[359] = 4;
      this.ExecTypeVarName[359, 1] = "Regime (-1=none)";
      this.ExecTypeVarName[359, 2] = "Specific Unit (-1=none)";
      this.ExecTypeVarName[359, 3] = "Modifier % (100=keep same, 50=half, 200=double)";
      this.ExecTypeVarName[359, 4] = "Modifier absolute (0=nill, -x , +x )";
      this.ExecCategory[359] = 8;
      this.ExecDesc[359] = "Increases or decreases Fuel of the unit. cannot go over max fuel reserves";
      this.ExecTypeNames[360] = "ExecAddUnitTextLog";
      this.ExecTypeVarCount[360] = 2;
      this.ExecTypeVarName[360, 1] = "Unit Slot#";
      this.ExecTypeVarName[360, 2] = "Text";
      this.ExecCategory[360] = 14;
      this.ExecTypeCount = 360;
    }

    pub void SetDefaultRules(bool namesonly = false)
    {
      int ruleCounter = this.RuleCounter;
      for (int index = 0; index <= ruleCounter; index += 1)
      {
        if (!namesonly)
          this.RuleVar[index] = 0.0f;
        this.RuleString[index] = "";
        if (!namesonly)
          this.RuleGroup[index] = 0;
      }
      this.RuleString[2] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[2] = 6f;
      this.RuleGroup[2] = 0;
      this.RuleString[34] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[34] = 0.25f;
      this.RuleGroup[34] = 0;
      this.RuleString[39] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[39] = 5f;
      this.RuleGroup[39] = 0;
      this.RuleString[45] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[45] = 0.25f;
      this.RuleGroup[45] = 0;
      this.RuleString[62] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[62] = 50f;
      this.RuleGroup[62] = 0;
      this.RuleString[71] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[71] = 0.5f;
      this.RuleGroup[71] = 0;
      this.RuleString[72] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[72] = 1f;
      this.RuleGroup[72] = 0;
      this.RuleString[76] = "";
      if (!namesonly)
        this.RuleVar[76] = 100f;
      this.RuleGroup[76] = 0;
      this.RuleString[6] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[6] = 0.2f;
      this.RuleGroup[6] = 0;
      this.RuleString[43] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[43] = 1f;
      this.RuleGroup[43] = 0;
      this.RuleString[0] = "Land Transfer Movement Type Nr used";
      if (!namesonly)
        this.RuleVar[0] = 2f;
      this.RuleGroup[0] = 1;
      this.RuleString[1] = "Sea Tranfer Movement Type Nr used";
      if (!namesonly)
        this.RuleVar[1] = 8f;
      this.RuleGroup[1] = 1;
      this.RuleString[2] = "Rail Transfer Movement Type Nr used";
      if (!namesonly)
        this.RuleVar[2] = 2f;
      this.RuleGroup[2] = 1;
      this.RuleString[3] = "Supply Action Point Range";
      if (!namesonly)
        this.RuleVar[3] = 250f;
      this.RuleGroup[3] = 1;
      this.RuleString[38] = "Use which landscapetype for unit movementtype logo prediction";
      if (!namesonly)
        this.RuleVar[38] = 0.0f;
      this.RuleGroup[38] = 1;
      this.RuleString[78] = "Transfer Action Point Range";
      if (!namesonly)
        this.RuleVar[78] = 1000f;
      this.RuleGroup[78] = 1;
      this.RuleString[99] = "Supply Movement Type Nr used";
      if (!namesonly)
        this.RuleVar[99] = 9f;
      this.RuleGroup[99] = 1;
      this.RuleString[148] = "Show Big VPs on Mini & Strategic Map (=>x vp)";
      if (!namesonly)
        this.RuleVar[148] = 5f;
      this.RuleGroup[148] = 14;
      this.RuleString[149] = "Show small VPs on Mini & Strategic Map (=>x vp)";
      if (!namesonly)
        this.RuleVar[149] = 1f;
      this.RuleGroup[149] = 14;
      this.RuleString[302] = "Highlighted hex color white (0) - black(1)";
      if (!namesonly)
        this.RuleVar[302] = 0.0f;
      this.RuleGroup[302] = 14;
      this.RuleString[306] = "Highlighted hex color alpha value (default 0.3 put higher for more color)";
      if (!namesonly)
        this.RuleVar[306] = 0.3f;
      this.RuleGroup[306] = 14;
      this.RuleString[857] = "Airsupply Supply MovementType";
      if (!namesonly)
        this.RuleVar[857] = 9f;
      this.RuleGroup[857] = 1;
      this.RuleString[858] = "Airsupply Supply Range in AP";
      if (!namesonly)
        this.RuleVar[858] = 9f;
      this.RuleGroup[858] = 1;
      this.RuleString[335] = "Which regimevar #(x to x+15) gives prediction of supply points (0=disabl)";
      if (!namesonly)
        this.RuleVar[335] = 0.0f;
      this.RuleGroup[335] = 1;
      this.RuleGroup2[335] = 19;
      this.RuleString[350] = "Use easy Strategic Transfer Mode? (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[350] = 0.0f;
      this.RuleGroup[350] = 1;
      this.RuleString[351] = "Startupcost for Strategic Transfer in AP";
      if (!namesonly)
        this.RuleVar[351] = 0.0f;
      this.RuleGroup[351] = 1;
      this.RuleString[851] = "LandCap use costs Regimevar #";
      if (!namesonly)
        this.RuleVar[851] = 0.0f;
      this.RuleGroup[851] = 1;
      this.RuleString[852] = "LandCap 1000 CAP pts use costs Regimevar Qty";
      if (!namesonly)
        this.RuleVar[852] = 0.0f;
      this.RuleGroup[852] = 1;
      this.RuleString[853] = "NavyCap use costs Regimevar #";
      if (!namesonly)
        this.RuleVar[853] = 0.0f;
      this.RuleGroup[853] = 1;
      this.RuleString[854] = "NavyCap 1000 CAP pts use costs Regimevar Qty";
      if (!namesonly)
        this.RuleVar[854] = 0.0f;
      this.RuleGroup[854] = 1;
      this.RuleString[855] = "RailCap use costs Regimevar #";
      if (!namesonly)
        this.RuleVar[855] = 0.0f;
      this.RuleGroup[855] = 1;
      this.RuleString[856] = "RailCap 1000 CAP pts use costs Regimevar Qty";
      if (!namesonly)
        this.RuleVar[856] = 0.0f;
      this.RuleGroup[856] = 1;
      this.RuleString[886] = "No fuel cost for own power transfer. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[886] = 0.0f;
      this.RuleGroup[886] = 1;
      this.RuleString[8] = "Minimum Recon Pts needed to see anything / Free recon points for owned hex";
      if (!namesonly)
        this.RuleVar[8] = 2f;
      this.RuleGroup[8] = 2;
      this.RuleString[9] = "Minimum Zoc Pts needed to capture an enemy hex";
      if (!namesonly)
        this.RuleVar[9] = 4f;
      this.RuleGroup[9] = 2;
      this.RuleString[10] = "Minimum Zoc Pts needed to capture a neutral hex";
      if (!namesonly)
        this.RuleVar[10] = 1f;
      this.RuleGroup[10] = 2;
      this.RuleString[11] = "Recon Dist 1 Modifier";
      if (!namesonly)
        this.RuleVar[11] = 1f;
      this.RuleGroup[11] = 2;
      this.RuleString[12] = "Recon Dist 2 Modifier";
      if (!namesonly)
        this.RuleVar[12] = 0.25f;
      this.RuleGroup[12] = 2;
      this.RuleString[13] = "Recon Dist 3 Modifier";
      if (!namesonly)
        this.RuleVar[13] = 0.05f;
      this.RuleGroup[13] = 2;
      this.RuleString[14] = "Recon Dist 4 Modifier";
      if (!namesonly)
        this.RuleVar[14] = 0.01f;
      this.RuleGroup[14] = 2;
      this.RuleString[21] = "Zoc Dist 1 Modifier";
      if (!namesonly)
        this.RuleVar[21] = 1f;
      this.RuleGroup[21] = 2;
      this.RuleString[22] = "Zoc Dist 2 Modifier";
      if (!namesonly)
        this.RuleVar[22] = 0.0f;
      this.RuleGroup[22] = 2;
      this.RuleString[23] = "Zoc Dist 3 Modifier";
      if (!namesonly)
        this.RuleVar[23] = 0.0f;
      this.RuleGroup[23] = 2;
      this.RuleString[24] = "Zoc Dist 4 Modifier";
      if (!namesonly)
        this.RuleVar[24] = 0.0f;
      this.RuleGroup[24] = 2;
      this.RuleString[40] = "X times more ZOC points needed than enemy ZOC pts to capture a hex";
      if (!namesonly)
        this.RuleVar[40] = 4f;
      this.RuleGroup[40] = 2;
      this.RuleString[55] = "Minimal Recon Pts needed for partial Info on Unit";
      if (!namesonly)
        this.RuleVar[55] = 30f;
      this.RuleGroup[55] = 2;
      this.RuleString[56] = "Recon Pts needed for full Info on Unit";
      if (!namesonly)
        this.RuleVar[56] = 250f;
      this.RuleGroup[56] = 2;
      this.RuleString[79] = "Auto Conquer neutral hex start of turn (1=yes)";
      if (!namesonly)
        this.RuleVar[79] = 1f;
      this.RuleGroup[79] = 2;
      this.RuleString[307] = "Minimum Power Points needed to capture enemy hex";
      if (!namesonly)
        this.RuleVar[307] = 10f;
      this.RuleGroup[307] = 2;
      this.RuleString[323] = "AP Penalty for entering enemy ZOC. Double value for crossing river into enemy ZOC.";
      if (!namesonly)
        this.RuleVar[323] = 1f;
      this.RuleGroup[323] = 2;
      this.RuleString[945] = "Ferry effectivity only for movement type #X";
      if (!namesonly)
        this.RuleVar[945] = 0.0f;
      this.RuleGroup[945] = 2;
      this.RuleString[840] = "Keep original owner for correct ally ownership returning with reconquest. 0=no 1=yes.";
      if (!namesonly)
        this.RuleVar[840] = 1f;
      this.RuleGroup[840] = 2;
      this.RuleString[843] = "Call event# after move,production or battle. 0=no. 1=event #.";
      if (!namesonly)
        this.RuleVar[843] = 1f;
      this.RuleGroup[843] = 2;
      this.RuleString[901] = "No ZOC capture of ANY locations. 0=off. 1=on. 2=also no roads capture";
      if (!namesonly)
        this.RuleVar[901] = 1f;
      this.RuleGroup[901] = 2;
      this.RuleString[902] = "Disable that engineers can repair locations. 0=normal. 1=disabled.";
      if (!namesonly)
        this.RuleVar[902] = 1f;
      this.RuleGroup[902] = 2;
      this.RuleString[874] = "Hide labels + loc.names on shrowded hexes with peek-info? 0=no. 1=yes.";
      if (!namesonly)
        this.RuleVar[874] = 1f;
      this.RuleGroup[874] = 2;
      this.RuleString[33] = "Supply Weight";
      if (!namesonly)
        this.RuleVar[33] = 0.1f;
      this.RuleGroup[33] = 3;
      this.RuleString[41] = "Excess Supply at HQ uses MovementType Nr";
      if (!namesonly)
        this.RuleVar[41] = 0.0f;
      this.RuleGroup[41] = 3;
      this.RuleString[51] = "only 75% supply at Action Point distance";
      if (!namesonly)
        this.RuleVar[51] = 100f;
      this.RuleGroup[51] = 3;
      this.RuleString[52] = "only 50% supply at Action Point distance";
      if (!namesonly)
        this.RuleVar[52] = 150f;
      this.RuleGroup[52] = 3;
      this.RuleString[53] = "only 25% supply at Action Point distance";
      if (!namesonly)
        this.RuleVar[53] = 200f;
      this.RuleGroup[53] = 3;
      this.RuleString[77] = "1 Supply Point Costs X Production Points (for calculation of upgrade cost)";
      if (!namesonly)
        this.RuleVar[77] = 3f;
      this.RuleGroup[77] = 3;
      this.RuleString[82] = "ActionPoint penalty for  from sea to land without port";
      if (!namesonly)
        this.RuleVar[82] = 100f;
      this.RuleGroup[82] = 3;
      this.RuleString[303] = "Anti Supply Point Multiplier if on sea hex next to enemy port.";
      if (!namesonly)
        this.RuleVar[302] = 20f;
      this.RuleGroup[303] = 3;
      this.RuleString[309] = "Enable transfer losses for Anti Supply on land transfers too (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[309] = 0.0f;
      this.RuleGroup[309] = 3;
      this.RuleString[324] = "Enable Hardcore Supply rules, only 250ap from High Hq (1=yes, 0=no)";
      if (!namesonly)
        this.RuleVar[324] = 0.0f;
      this.RuleGroup[324] = 3;
      this.RuleString[336] = "Remove excess supply HQs.(1=yes after give sup, 2=yes before give sup, >100 = yes after but remove only sup >x at highC, 0=no)";
      if (!namesonly)
        this.RuleVar[336] = 0.0f;
      this.RuleGroup[336] = 3;
      this.RuleString[801] = "Enforce Models when attempting to transfer (1=yes, 0=no)";
      if (!namesonly)
        this.RuleVar[801] = 0.0f;
      this.RuleGroup[801] = 3;
      this.RuleString[883] = "Maximum auto-reinf percentage (at 100% supply level)";
      if (!namesonly)
        this.RuleVar[883] = 0.0f;
      this.RuleGroup[883] = 3;
      this.RuleString[887] = "Enable High HQ Supply/AutoReinf EASY rules which means no HARDCORE chain of HQs just high and the others (1=yes, 0=no)";
      if (!namesonly)
        this.RuleVar[887] = 0.0f;
      this.RuleGroup[887] = 3;
      this.RuleString[7] = "Bridge Structural Pts";
      if (!namesonly)
        this.RuleVar[7] = 500f;
      this.RuleGroup[7] = 4;
      this.RuleString[32] = "RoadType your engineers can build. (-1 = no bridge/no road building)";
      if (!namesonly)
        this.RuleVar[32] = 0.0f;
      this.RuleGroup[32] = 4;
      this.RuleString[4] = "Enemy Territory entry extra AP cost";
      if (!namesonly)
        this.RuleVar[4] = 10f;
      this.RuleGroup[4] = 4;
      this.RuleString[44] = "Minimum Action Points for navy left if out of supply.";
      if (!namesonly)
        this.RuleVar[44] = 30f;
      this.RuleGroup[44] = 4;
      this.RuleString[305] = "Bridges cannot be destroyed by combat (see 505 for engineers). 0=no , 1=yes";
      if (!namesonly)
        this.RuleVar[305] = 0.0f;
      this.RuleGroup[305] = 4;
      this.RuleString[308] = "Dont show broken bridges sprites. 0=no show them , 1=yes hide broken bridge";
      if (!namesonly)
        this.RuleVar[308] = 0.0f;
      this.RuleGroup[308] = 4;
      this.RuleString[320] = "Only allow bridge building if road is already on both sides. 0=no , 1=yes";
      if (!namesonly)
        this.RuleVar[320] = 0.0f;
      this.RuleGroup[320] = 4;
      this.RuleString[452] = "Road over river acts as bridge (1=yes, 0=no)";
      if (!namesonly)
        this.RuleVar[452] = 0.0f;
      this.RuleGroup[452] = 14;
      this.RuleString[321] = "Lose EP on movement. 0=no , 1=yes";
      if (!namesonly)
        this.RuleVar[321] = 0.0f;
      this.RuleGroup[321] = 4;
      this.RuleString[322] = "Disallow supply transfer & setting reserve supply prefs for HQ. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[322] = 0.0f;
      this.RuleGroup[322] = 4;
      this.RuleString[814] = "Allow Free Movement (0=no/1=yes) (can be split in zones by setting groupnames 740,741)";
      if (!namesonly)
        this.RuleVar[814] = 0.0f;
      this.RuleGroup[814] = 4;
      this.RuleString[48] = "Readiness modifier for assigning new HQ";
      if (!namesonly)
        this.RuleVar[48] = 0.5f;
      this.RuleGroup[48] = 5;
      this.RuleString[49] = "Readiness modifier for transfer to same HQ unit";
      if (!namesonly)
        this.RuleVar[49] = 0.75f;
      this.RuleGroup[49] = 5;
      this.RuleString[50] = "Readiness modifier for transfer outside HQ";
      if (!namesonly)
        this.RuleVar[50] = 0.25f;
      this.RuleGroup[50] = 5;
      this.RuleString[59] = "Max Readiness increase compared to before autodrop";
      if (!namesonly)
        this.RuleVar[59] = 30f;
      this.RuleGroup[59] = 5;
      this.RuleString[60] = "Minimum readiness allowed";
      if (!namesonly)
        this.RuleVar[60] = 10f;
      this.RuleGroup[60] = 5;
      this.RuleString[61] = "Autodrop Readiness  in % , before supply";
      if (!namesonly)
        this.RuleVar[61] = 40f;
      this.RuleGroup[61] = 5;
      this.RuleString[131] = "Readiness modifier for strategic transfer";
      if (!namesonly)
        this.RuleVar[131] = 0.5f;
      this.RuleGroup[131] = 5;
      this.RuleString[36] = "staff Xp loss with transfers/ getting new troops";
      if (!namesonly)
        this.RuleVar[36] = 0.25f;
      this.RuleGroup[36] = 6;
      this.RuleString[42] = "Max turns Engineer Points can be saved up";
      if (!namesonly)
        this.RuleVar[42] = 5f;
      this.RuleGroup[42] = 6;
      this.RuleString[63] = "Free XP up to xp point limit";
      if (!namesonly)
        this.RuleVar[63] = 40f;
      this.RuleGroup[63] = 6;
      this.RuleString[64] = "Max Free XP a turn";
      if (!namesonly)
        this.RuleVar[64] = 10f;
      this.RuleGroup[64] = 6;
      this.RuleString[65] = "Max normal Morale recovery per turn of basemorale value";
      if (!namesonly)
        this.RuleVar[65] = 0.25f;
      this.RuleGroup[65] = 6;
      this.RuleString[75] = "XP modifier for staff of combat individual xp at 100% staff level";
      if (!namesonly)
        this.RuleVar[75] = 1f;
      this.RuleGroup[75] = 6;
      this.RuleString[80] = "Xp growth modifier (1-4). 1=50% at 50xp/40% at 60xp. 2=25% at 50xp/16% at 60xp, etc..";
      if (!namesonly)
        this.RuleVar[80] = 1.5f;
      this.RuleGroup[80] = 6;
      this.RuleString[81] = "Max XP allowed ";
      if (!namesonly)
        this.RuleVar[81] = 100f;
      this.RuleGroup[81] = 6;
      this.RuleString[926] = "XP Modifier for disbanding. 0=all. 0.5=half. 1=none.";
      if (!namesonly)
        this.RuleVar[926] = 0.0f;
      this.RuleGroup[926] = 6;
      this.RuleString[46] = "PP Cost for formation";
      if (!namesonly)
        this.RuleVar[46] = 1f;
      this.RuleGroup[46] = 7;
      this.RuleString[47] = "PP Cost for HQ";
      if (!namesonly)
        this.RuleVar[47] = 3f;
      this.RuleGroup[47] = 7;
      this.RuleString[894] = "High Command HQs (historical type) cannot move. And will be destroyed on retreat. 0=no rule 1=rule enabled. ";
      if (!namesonly)
        this.RuleVar[894] = 3f;
      this.RuleGroup[894] = 7;
      this.RuleString[904] = "Base PP Cost for officerpool switch. ";
      if (!namesonly)
        this.RuleVar[904] = 3f;
      this.RuleGroup[904] = 7;
      this.RuleString[896] = "High Command HQs (historical) cannot get officer changed by officerpool. 0=no dont use rule, 1=yes cannot get changed ";
      if (!namesonly)
        this.RuleVar[896] = 0.0f;
      this.RuleGroup[896] = 7;
      this.RuleString[897] = "HQs lose action cards when unit is assigned to them. 0=yes. 1=no cancel this losing cards rule. ";
      if (!namesonly)
        this.RuleVar[897] = 0.0f;
      this.RuleGroup[897] = 7;
      this.RuleString[944] = "HQs cannot play action cards on a unit whose HQ has been changed in this turn. 0=rule disabled. 1=enable rule. ";
      if (!namesonly)
        this.RuleVar[944] = 0.0f;
      this.RuleGroup[944] = 7;
      this.RuleString[907] = "hisvar type X to diminish when unit is assigned or to clear when moved out from officerpool. (0=dont use) hisvar Type X= ";
      if (!namesonly)
        this.RuleVar[907] = 0.0f;
      this.RuleGroup[907] = 7;
      this.RuleString[927] = "Only Corps level HQs (type=5) give combat and morale bonus. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[927] = 0.0f;
      this.RuleGroup[927] = 7;
      this.RuleString[314] = "DISABLEd";
      if (!namesonly)
        this.RuleVar[314] = 0.0f;
      this.RuleGroup[314] = 0;
      this.RuleString[73] = "Distance (in hex) at which hq pow mod stays 100%";
      if (!namesonly)
        this.RuleVar[73] = 2f;
      this.RuleGroup[73] = 8;
      this.RuleString[74] = "-X% for hq pow for every distance step beyond 100% distance ";
      if (!namesonly)
        this.RuleVar[74] = 20f;
      this.RuleGroup[74] = 8;
      this.RuleString[140] = "Basic staff 100%level and hqpow combat modifier in + 0.x ";
      if (!namesonly)
        this.RuleVar[140] = 0.5f;
      this.RuleGroup[140] = 8;
      this.RuleString[141] = "Basic staff at 100%level and hqpow morale modifier in 0.x ";
      if (!namesonly)
        this.RuleVar[141] = 0.25f;
      this.RuleGroup[141] = 8;
      this.RuleString[304] = "Max number of HQs in a chain of command. 0=no limit. >0=specified limit.";
      if (!namesonly)
        this.RuleVar[304] = 3f;
      this.RuleGroup[304] = 8;
      this.RuleString[5] = "Bridge attack river penalty modifier";
      if (!namesonly)
        this.RuleVar[5] = 0.5f;
      this.RuleGroup[5] = 9;
      this.RuleString[30] = "Hex minimum StackMax";
      if (!namesonly)
        this.RuleVar[30] = 100f;
      this.RuleGroup[30] = 9;
      this.RuleString[31] = "AttackMax Per Hexside in FrontagePts";
      if (!namesonly)
        this.RuleVar[31] = 50f;
      this.RuleGroup[31] = 9;
      this.RuleString[35] = "PowerPts Destroyed gives 1 officer XP";
      if (!namesonly)
        this.RuleVar[35] = 5f;
      this.RuleGroup[35] = 9;
      this.RuleString[37] = "Equal to this morale = capitulation chance rnd()>rdn/301 IF also Rdn < rulevar(301)";
      if (!namesonly)
        this.RuleVar[37] = 10f;
      this.RuleGroup[37] = 9;
      this.RuleString[70] = "Panic chance if more casualties than morale can cope";
      if (!namesonly)
        this.RuleVar[70] = 0.25f;
      this.RuleGroup[70] = 9;
      this.RuleString[100] = "Allow Air Move/Bombing/Recon/Paradrop missions into shroud? (1=yes)";
      if (!namesonly)
        this.RuleVar[100] = 1f;
      this.RuleGroup[100] = 9;
      this.RuleString[101] = "Counter Attack modifier for attacker on land";
      if (!namesonly)
        this.RuleVar[101] = 0.5f;
      this.RuleGroup[101] = 9;
      this.RuleString[102] = "Counter Attack modifier for defender on land";
      if (!namesonly)
        this.RuleVar[102] = 1f;
      this.RuleGroup[102] = 9;
      this.RuleString[103] = "Counter Attack modifier for attacker on sea/air";
      if (!namesonly)
        this.RuleVar[103] = 1f;
      this.RuleGroup[103] = 9;
      this.RuleString[104] = "Counter Attack modifier for defender on sea/air";
      if (!namesonly)
        this.RuleVar[104] = 1f;
      this.RuleGroup[104] = 9;
      this.RuleString[105] = "Flak assistance outside own hex modifier";
      if (!namesonly)
        this.RuleVar[105] = 0.5f;
      this.RuleGroup[105] = 9;
      this.RuleString[106] = "Attacker max readiness penalty if attacking";
      if (!namesonly)
        this.RuleVar[106] = 1f;
      this.RuleGroup[106] = 9;
      this.RuleString[107] = "Defender max readiness penalty if attacking";
      if (!namesonly)
        this.RuleVar[107] = 0.5f;
      this.RuleGroup[107] = 9;
      this.RuleString[108] = "Landsurprise defender modifier";
      if (!namesonly)
        this.RuleVar[108] = 2f;
      this.RuleGroup[108] = 9;
      this.RuleString[109] = "Paradrop defender modifier";
      if (!namesonly)
        this.RuleVar[109] = 3f;
      this.RuleGroup[109] = 9;
      this.RuleString[110] = "Amphibious asault defender modifier";
      if (!namesonly)
        this.RuleVar[110] = 3f;
      this.RuleGroup[110] = 9;
      this.RuleString[111] = "Rebel Advantage modifier";
      if (!namesonly)
        this.RuleVar[111] = 2f;
      this.RuleGroup[111] = 9;
      this.RuleString[112] = "Modifier if shooting at orderly retreating attacker";
      if (!namesonly)
        this.RuleVar[112] = 0.25f;
      this.RuleGroup[112] = 9;
      this.RuleString[113] = "Modifier if shooting at orderly retreating defender";
      if (!namesonly)
        this.RuleVar[113] = 1f;
      this.RuleGroup[113] = 9;
      this.RuleString[114] = "Modifier if shooting at panicking attacker";
      if (!namesonly)
        this.RuleVar[114] = 1f;
      this.RuleGroup[114] = 9;
      this.RuleString[115] = "Modifier if shooting at panicking defender";
      if (!namesonly)
        this.RuleVar[115] = 2f;
      this.RuleGroup[115] = 9;
      this.RuleString[116] = "Max readiness penalty on hitpoints for defending individual";
      if (!namesonly)
        this.RuleVar[116] = 0.25f;
      this.RuleGroup[116] = 9;
      this.RuleString[117] = "Minimal xp modifier due to powerpoint difference";
      if (!namesonly)
        this.RuleVar[117] = 0.1f;
      this.RuleGroup[117] = 9;
      this.RuleString[118] = "Maximal xp modifier due to powerpoint difference";
      if (!namesonly)
        this.RuleVar[118] = 3f;
      this.RuleGroup[118] = 9;
      this.RuleString[119] = "Score Kill gives XP pts";
      if (!namesonly)
        this.RuleVar[119] = 30f;
      this.RuleGroup[119] = 9;
      this.RuleString[120] = "Score Retreat gives XP pts";
      if (!namesonly)
        this.RuleVar[120] = 10f;
      this.RuleGroup[120] = 9;
      this.RuleString[121] = "Score Pinned gives XP pts";
      if (!namesonly)
        this.RuleVar[121] = 0.0f;
      this.RuleGroup[121] = 9;
      this.RuleString[122] = "Score Retreat Readiness loss %";
      if (!namesonly)
        this.RuleVar[122] = 50f;
      this.RuleGroup[122] = 9;
      this.RuleString[123] = "Score Pinned Readiness loss %";
      if (!namesonly)
        this.RuleVar[123] = 50f;
      this.RuleGroup[123] = 9;
      this.RuleString[124] = "Score Retreat Morale loss %";
      if (!namesonly)
        this.RuleVar[124] = 25f;
      this.RuleGroup[124] = 9;
      this.RuleString[125] = "Score Pinned Morale loss %";
      if (!namesonly)
        this.RuleVar[125] = 10f;
      this.RuleGroup[125] = 9;
      this.RuleString[126] = "Score Retreat Entrench loss %";
      if (!namesonly)
        this.RuleVar[126] = 100f;
      this.RuleGroup[126] = 9;
      this.RuleString[ sbyte.MaxValue] = "Score Pinned Entrench loss %";
      if (!namesonly)
        this.RuleVar[ sbyte.MaxValue] = 50f;
      this.RuleGroup[ sbyte.MaxValue] = 9;
      this.RuleString[996] = "Revised Panic Rules (always possible) (0=no, 1=yes) ";
      if (!namesonly)
        this.RuleVar[996] = 0.0f;
      this.RuleGroup[996] = 19;
      this.RuleString[128] = "If Air and not a bombing mission anti-struc pts damage done modifier";
      if (!namesonly)
        this.RuleVar[128] = 0.25f;
      this.RuleGroup[128] = 9;
      this.RuleString[129] = "Morale % penalty if individual panics";
      if (!namesonly)
        this.RuleVar[129] = 50f;
      this.RuleGroup[129] = 9;
      this.RuleString[130] = "Max Supply Consume modifier";
      if (!namesonly)
        this.RuleVar[130] = 0.75f;
      this.RuleGroup[130] = 9;
      this.RuleString[132] = "Concentric Attack Default 10% bonus";
      if (!namesonly)
        this.RuleVar[132] = 0.1f;
      this.RuleGroup[132] = 9;
      this.RuleString[133] = "Concentric Attack Default 25% bonus";
      if (!namesonly)
        this.RuleVar[133] = 0.25f;
      this.RuleGroup[133] = 9;
      this.RuleString[134] = "Concentric Attack Default 50% bonus";
      if (!namesonly)
        this.RuleVar[134] = 0.5f;
      this.RuleGroup[134] = 9;
      this.RuleString[135] = "Concentric Attack Default 75% bonus";
      if (!namesonly)
        this.RuleVar[135] = 0.75f;
      this.RuleGroup[135] = 9;
      this.RuleString[136] = "Concentric Attack Default 100% bonus";
      if (!namesonly)
        this.RuleVar[136] = 1f;
      this.RuleGroup[136] = 9;
      this.RuleString[137] = "Concentric Attack Default 150% bonus";
      if (!namesonly)
        this.RuleVar[137] = 1.5f;
      this.RuleGroup[137] = 9;
      this.RuleString[138] = "Concentric Attack Default 200% bonus";
      if (!namesonly)
        this.RuleVar[138] = 2f;
      this.RuleGroup[138] = 9;
      this.RuleString[139] = "Concentric Attack Default 250% bonus";
      if (!namesonly)
        this.RuleVar[139] = 2.5f;
      this.RuleGroup[139] = 9;
      this.RuleString[142] = "Allow artillery to fireback if artillery attack. (counter battery fire) 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[142] = 0.0f;
      this.RuleGroup[142] = 9;
      this.RuleString[925] = "Allow counter-attack when already beyond max-attacked. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[925] = 0.0f;
      this.RuleGroup[925] = 9;
      this.RuleString[143] = "Divisional Bonus Step 1";
      if (!namesonly)
        this.RuleVar[143] = -1f;
      this.RuleGroup[143] = 9;
      this.RuleString[144] = "Divisional Bonus Step 2";
      if (!namesonly)
        this.RuleVar[144] = 0.0f;
      this.RuleGroup[144] = 9;
      this.RuleString[145] = "Divisional Bonus Step 3";
      if (!namesonly)
        this.RuleVar[145] = 0.0f;
      this.RuleGroup[145] = 9;
      this.RuleString[146] = "Divisional Bonus Step 4";
      if (!namesonly)
        this.RuleVar[146] = 0.0f;
      this.RuleGroup[146] = 9;
      this.RuleString[147] = "Intercept range as 0.x of normal range";
      if (!namesonly)
        this.RuleVar[147] = 0.5f;
      this.RuleGroup[147] = 9;
      this.RuleString[300] = "Max division of attackval due to maxattacked";
      if (!namesonly)
        this.RuleVar[300] = 3f;
      this.RuleGroup[300] = 9;
      this.RuleString[301] = "If retreat with rdn <x chance for surrender (0=never)";
      if (!namesonly)
        this.RuleVar[301] = 25f;
      this.RuleGroup[301] = 9;
      this.RuleString[316] = "Non Artillery Land Attacks 1st round modifier. <1 is a penalty. 1=normal";
      if (!namesonly)
        this.RuleVar[316] = 0.0f;
      this.RuleGroup[316] = 9;
      this.RuleString[317] = "Non Artillery Land Attacks 2nd round modifier. <1 is a penalty. 1=normal";
      if (!namesonly)
        this.RuleVar[317] = 0.0f;
      this.RuleGroup[317] = 9;
      this.RuleString[318] = "Do airstrike on empty hex? 1=yes 0=no";
      if (!namesonly)
        this.RuleVar[318] = 0.0f;
      this.RuleGroup[318] = 9;
      this.RuleString[319] = "On startup lower Kill ratio to retreat hit. 1=no changes. 0.x = lower.";
      if (!namesonly)
        this.RuleVar[319] = 0.0f;
      this.RuleGroup[319] = 9;
      this.RuleString[325] = "Extra AP cost to move into hex (ap combat penalty) per combat round (fought with 100 stack points). Max 10 times this value.";
      if (!namesonly)
        this.RuleVar[325] = 0.0f;
      this.RuleGroup[325] = 9;
      this.RuleString[341] = "Airstrike always fights up all its action points like bombing attack (0=no 1=yes) ";
      if (!namesonly)
        this.RuleVar[341] = 0.0f;
      this.RuleGroup[341] = 9;
      this.RuleString[807] = "No counterattacks. 1=disable counter attacks. 0=keep counterattacks ";
      if (!namesonly)
        this.RuleVar[807] = 0.0f;
      this.RuleGroup[807] = 9;
      this.RuleString[833] = "AttackMax in FrontagePts for Air to Ground battle in hex. 0=not active";
      if (!namesonly)
        this.RuleVar[833] = 100f;
      this.RuleGroup[833] = 9;
      this.RuleString[834] = "AttackMax in FrontagePts for Artillery attack on hex. 0=not active";
      if (!namesonly)
        this.RuleVar[834] = 100f;
      this.RuleGroup[834] = 9;
      this.RuleString[835] = "Airfield suprise start reduce attackpower % in combat. 0=none/rule not active";
      if (!namesonly)
        this.RuleVar[835] = 0.0f;
      this.RuleGroup[835] = 9;
      this.RuleString[836] = "Airfield suprise reducement diminishment every round.";
      if (!namesonly)
        this.RuleVar[836] = 0.0f;
      this.RuleGroup[836] = 9;
      this.RuleString[837] = "Intercept Chance Rule. Percentage chance of fail to intercept at edge of radius. 0=dont use rule";
      if (!namesonly)
        this.RuleVar[837] = 0.0f;
      this.RuleGroup[837] = 9;
      this.RuleString[838] = "Intercept Chance Rule. Percentage chance of fail to intercept at theoretical 0 distance. 0=dont use rule";
      if (!namesonly)
        this.RuleVar[838] = 0.0f;
      this.RuleGroup[838] = 9;
      this.RuleString[841] = "Put combat kills/loss statistics in the round they happened (as opposed to round they get reported in). 1=yes.";
      if (!namesonly)
        this.RuleVar[841] = 0.0f;
      this.RuleGroup[841] = 9;
      this.RuleString[876] = "Dont Use only % of xp bonus on hp. 0=normal/default.. 50=50%.. max 100%=no xp bonus on hitpoints.";
      if (!namesonly)
        this.RuleVar[876] = 0.0f;
      this.RuleGroup[876] = 9;
      this.RuleString[877] = "Dont Use only % of xp bonus on att points. 0=normal/default.. 50=50%.. max 100%=no xp bonus on attack points.";
      if (!namesonly)
        this.RuleVar[877] = 0.0f;
      this.RuleGroup[877] = 9;
      this.RuleString[895] = "Artillery capable equipment gets retreat kill modifier in NON-artillery attack. 0=no modifier used!. >0 is modifier use: 0.5 = half, 2=double";
      if (!namesonly)
        this.RuleVar[895] = 0.0f;
      this.RuleGroup[895] = 9;
      this.RuleString[898] = "When location is taking from any side by another side structural points are set to 0. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[898] = 0.0f;
      this.RuleGroup[898] = 9;
      this.RuleString[326] = "Navy movement can get ambushed. 0=no 25 ap losee. 1=yes battle.";
      if (!namesonly)
        this.RuleVar[326] = 0.0f;
      this.RuleGroup[326] = 15;
      this.RuleString[328] = "Allies share recon. 0=no 1=yes.";
      if (!namesonly)
        this.RuleVar[328] = 0.0f;
      this.RuleGroup[328] = 15;
      this.RuleString[342] = "Allies support ally vs other ally. 0=no 1=yes.";
      if (!namesonly)
        this.RuleVar[342] = 0.0f;
      this.RuleGroup[342] = 15;
      this.RuleString[337] = "Use Auto Reinforce (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[337] = 0.0f;
      this.RuleGroup[337] = 16;
      this.RuleString[977] = "Forbid disbanding units by replacement% setting (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[977] = 0.0f;
      this.RuleGroup[977] = 16;
      this.RuleString[910] = "Auto Reinforce Mobility MoveType To Keep #1 (0=none)";
      if (!namesonly)
        this.RuleVar[910] = 0.0f;
      this.RuleGroup[910] = 16;
      this.RuleString[911] = "Auto Reinforce Mobility MoveType To Keep #2 (0=none)";
      if (!namesonly)
        this.RuleVar[911] = 0.0f;
      this.RuleGroup[911] = 16;
      this.RuleString[912] = "Auto Reinforce Mobility MoveType To Keep #3 (0=none)";
      if (!namesonly)
        this.RuleVar[912] = 0.0f;
      this.RuleGroup[912] = 16;
      this.RuleString[884] = "Unit Integrity based on: 0=start power, 1=hist.unit ideal";
      if (!namesonly)
        this.RuleVar[884] = 0.0f;
      this.RuleGroup[884] = 16;
      this.RuleString[949] = "HexLibVar-based oil use (0=dont, >0 is the X in the hexlibvar name 'oilX' thats used for looking up regimeslot#)";
      if (!namesonly)
        this.RuleVar[949] = 0.0f;
      this.RuleGroup[949] = 12;
      this.RuleString[885] = "";
      if (!namesonly)
        this.RuleVar[885] = 0.0f;
      this.RuleGroup[885] = 16;
      this.RuleString[338] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[338] = 0.0f;
      this.RuleGroup[338] = 0;
      this.RuleString[339] = "Auto Reinforce Max AP range";
      if (!namesonly)
        this.RuleVar[339] = 0.0f;
      this.RuleGroup[339] = 16;
      this.RuleString[340] = "Auto Reinforce Use CapTypes (-1=free, 0-2=only that cap type, 3=all)";
      if (!namesonly)
        this.RuleVar[340] = 0.0f;
      this.RuleGroup[340] = 16;
      this.RuleString[343] = "Use Officerpool (1=yes)";
      if (!namesonly)
        this.RuleVar[343] = 0.0f;
      this.RuleGroup[343] = 16;
      this.RuleString[344] = "Use Historical Units (1=yes)";
      if (!namesonly)
        this.RuleVar[344] = 0.0f;
      this.RuleGroup[344] = 12;
      this.RuleString[346] = "NOT USED";
      if (!namesonly)
        this.RuleVar[346] = 0.0f;
      this.RuleGroup[346] = 0;
      this.RuleString[347] = "-NOT USED-";
      if (!namesonly)
        this.RuleVar[347] = 0.0f;
      this.RuleGroup[347] = 0;
      this.RuleString[348] = "Enforce strict OOB rules for historical HQs (1=yes)";
      if (!namesonly)
        this.RuleVar[348] = 0.0f;
      this.RuleGroup[348] = 7;
      this.RuleString[354] = "Use unit integrity rules. 0=no. 1=yes";
      if (!namesonly)
        this.RuleVar[354] = 0.0f;
      this.RuleGroup[354] = 12;
      this.RuleString[355] = "Keep cards if change officer through officerpool. 0=no. 1=yes";
      if (!namesonly)
        this.RuleVar[355] = 0.0f;
      this.RuleGroup[355] = 16;
      this.RuleString[329] = "Dont show map looping even if it is looped 1=dont show. 0=show";
      if (!namesonly)
        this.RuleVar[329] = 0.0f;
      this.RuleGroup[329] = 14;
      this.RuleString[330] = "Show map border. 0=dont show. 1=show";
      if (!namesonly)
        this.RuleVar[330] = 0.0f;
      this.RuleGroup[330] = 14;
      this.RuleString[334] = "Dont show readyness + supplystatus on counter. 0=do show. 1=hide";
      if (!namesonly)
        this.RuleVar[334] = 0.0f;
      this.RuleGroup[334] = 14;
      this.RuleString[352] = "Dont show labels in zoomed in mode. 0=do show. 1=hide";
      if (!namesonly)
        this.RuleVar[352] = 0.0f;
      this.RuleGroup[352] = 14;
      this.RuleString[353] = "Allow setting of Shrowd. 0=yes allow. 1=disable";
      if (!namesonly)
        this.RuleVar[353] = 0.0f;
      this.RuleGroup[353] = 14;
      this.RuleString[908] = "Draw river last. 0=no , 1=yes ";
      if (!namesonly)
        this.RuleVar[908] = 0.0f;
      this.RuleGroup[908] = 14;
      this.RuleString[879] = "Officer description mode. 0=text, 1=hisvar stats.";
      if (!namesonly)
        this.RuleVar[879] = 0.0f;
      this.RuleGroup[879] = 14;
      this.RuleString[860] = "Show locations power point bar and HQ on map with color code. 1=yes, 0=no.";
      if (!namesonly)
        this.RuleVar[860] = 0.0f;
      this.RuleGroup[860] = 14;
      this.RuleString[265] = "NEW AI/DC2 AI: If falls below or equal this ammount of VP. It means (DEAD) end of game. 0=not used.";
      if (!namesonly)
        this.RuleVar[265] = 0.0f;
      this.RuleGroup[265] = 18;
      this.RuleGroup2[265] = 19;
      this.RuleString[266] = "NEW AI/DC2 AI: If get above or equal this ammount of VP. It means VICTORY. 0=not used.";
      if (!namesonly)
        this.RuleVar[266] = 0.0f;
      this.RuleGroup[266] = -1;
      this.RuleString[267] = "NEW AI: Areagroups are defined in slot# (1-9). 0=not used.";
      if (!namesonly)
        this.RuleVar[267] = 0.0f;
      this.RuleGroup[267] = 18;
      this.RuleString[268] = "NEW AI: ";
      if (!namesonly)
        this.RuleVar[268] = 0.0f;
      this.RuleGroup[268] = 0;
      this.RuleString[356] = "NEW AI. expect divisions / multi-united historical units. 0=do expect. 1=do not expect";
      if (!namesonly)
        this.RuleVar[356] = 0.0f;
      this.RuleGroup[356] = 18;
      this.RuleString[357] = "NEW AI. VP without locations are areacenters too. 0=no they are not 1=yes they are";
      if (!namesonly)
        this.RuleVar[357] = 0.0f;
      this.RuleGroup[357] = 18;
      this.RuleString[358] = "NEW AI. Attack from X points. 0=default. >0 overrule=> 20=aggressive very much. 80=cautious. ";
      if (!namesonly)
        this.RuleVar[358] = 0.0f;
      this.RuleGroup[358] = 18;
      this.RuleString[359] = "NEW AI. Hex occupation modifier for ATTacker. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[359] = 0.0f;
      this.RuleGroup[359] = 18;
      this.RuleString[360] = "NEW AI. Hex occupation modifier for DEFender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[360] = 0.0f;
      this.RuleGroup[360] = 18;
      this.RuleString[361] = "NEW AI. Air Penalty distance. 0=default. >0 is number of hexes equal below gives penalty. ";
      if (!namesonly)
        this.RuleVar[361] = 0.0f;
      this.RuleGroup[361] = 18;
      this.RuleString[362] = "NEW AI. Normal HQ Penalty distance. 0=default. >0 is number of hexes equal below gives penalty. ";
      if (!namesonly)
        this.RuleVar[362] = 0.0f;
      this.RuleGroup[362] = 18;
      this.RuleString[363] = "NEW AI. Penalties given to Air/HQ. 0=default. >0 is number of points. ";
      if (!namesonly)
        this.RuleVar[363] = 0.0f;
      this.RuleGroup[363] = 18;
      this.RuleString[364] = "NEW AI. Penalties given to Air/HQ in Port hex. 0=default. >0 is number of points. ";
      if (!namesonly)
        this.RuleVar[364] = 0.0f;
      this.RuleGroup[364] = 18;
      this.RuleString[365] = "NEW AI. Is HQ on supplyline/advancematrixline penalty mod. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[365] = 0.0f;
      this.RuleGroup[365] = 18;
      this.RuleString[366] = "NEW AI. Is average HQ power below 100% penalties. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[366] = 0.0f;
      this.RuleGroup[366] = 18;
      this.RuleString[367] = "NEW AI. Score modifier for Attacks for Attacker. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[367] = 0.0f;
      this.RuleGroup[367] = 18;
      this.RuleString[368] = "NEW AI. Score modifier for Attacks for Defender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[368] = 0.0f;
      this.RuleGroup[368] = 18;
      this.RuleString[369] = "NEW AI. Moving in modifier for Attacker. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[369] = 0.0f;
      this.RuleGroup[369] = 18;
      this.RuleString[370] = "NEW AI. Moving in modifier for Defender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[370] = 0.0f;
      this.RuleGroup[370] = 18;
      this.RuleString[371] = "NEW AI. Counterattack modifier for attacker. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[371] = 0.0f;
      this.RuleGroup[371] = 18;
      this.RuleString[372] = "NEW AI. Counterattack modifier for Defender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[372] = 0.0f;
      this.RuleGroup[372] = 18;
      this.RuleString[373] = "NEW AI. Countermove modifier for attacker. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[373] = 0.0f;
      this.RuleGroup[373] = 18;
      this.RuleString[374] = "NEW AI. Countermove modifier for Defender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[374] = 0.0f;
      this.RuleGroup[374] = 18;
      this.RuleString[375] = "NEW AI. Get ourselves encircled for attacker. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[375] = 0.0f;
      this.RuleGroup[375] = 18;
      this.RuleString[376] = "NEW AI. Get ourselves encircled for Defender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[376] = 0.0f;
      this.RuleGroup[376] = 18;
      this.RuleString[377] = "NEW AI. Entrenchment points modifier for Attacker. 0=default (def=low). 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[377] = 0.0f;
      this.RuleGroup[377] = 18;
      this.RuleString[378] = "NEW AI. Entrenchments points modifier for Defender. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[378] = 0.0f;
      this.RuleGroup[378] = 18;
      this.RuleString[379] = "NEW AI. Stacking penalty modifier. 0=default. 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[379] = 0.0f;
      this.RuleGroup[379] = 18;
      this.RuleString[380] = "NEW AI. Enemy encircled modifier for Attacker. 0=default (def=25%). 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[380] = 0.0f;
      this.RuleGroup[380] = 18;
      this.RuleString[381] = "NEW AI. Enemy encircled modifier for Defender. 0=default (def=25%). 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[381] = 0.0f;
      this.RuleGroup[381] = 18;
      this.RuleString[382] = "NEW AI. AdvanceMatrix for units for Attacker. 0=default (def=30%). 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[382] = 0.0f;
      this.RuleGroup[382] = 18;
      this.RuleString[383] = "NEW AI. AdvanceMatrix for hexes for Attacker. 0=default (def=15%). 100%. 50%=half. 200%=double. ";
      if (!namesonly)
        this.RuleVar[383] = 0.0f;
      this.RuleGroup[383] = 18;
      this.RuleString[384] = "NEW AI. Combat Target Size modifier Above X powpts. 0=default(def=80) >0 is X powpts";
      if (!namesonly)
        this.RuleVar[384] = 0.0f;
      this.RuleGroup[384] = 18;
      this.RuleString[385] = "NEW AI. Allow areas without road to be connected. 0=no. 1=yes";
      if (!namesonly)
        this.RuleVar[385] = 0.0f;
      this.RuleGroup[385] = 18;
      this.RuleString[386] = "NEW AI. Give defender full attacks in Strategy Simulation. 0=no. 1=yes";
      if (!namesonly)
        this.RuleVar[386] = 0.0f;
      this.RuleGroup[386] = 18;
      this.RuleString[387] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[387] = 0.0f;
      this.RuleGroup[387] = -1;
      this.RuleString[388] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[388] = 0.0f;
      this.RuleGroup[388] = -1;
      this.RuleString[389] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[389] = 0.0f;
      this.RuleGroup[389] = -1;
      this.RuleString[390] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[390] = 0.0f;
      this.RuleGroup[390] = -1;
      this.RuleString[391] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[391] = 0.0f;
      this.RuleGroup[391] = -1;
      this.RuleString[392] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[392] = 0.0f;
      this.RuleGroup[392] = -1;
      this.RuleString[393] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[393] = 0.0f;
      this.RuleGroup[393] = -1;
      this.RuleString[394] = "NEW AI. Modifier for strategy calcs for attack casualty rate. >1 less <1 more. 0=dont use";
      if (!namesonly)
        this.RuleVar[394] = 0.0f;
      this.RuleGroup[394] = 18;
      this.RuleString[395] = "NEW AI. Modifier for strategy calcs for counterattack casualty rate. >1 less <1 more. 0=dont use";
      if (!namesonly)
        this.RuleVar[395] = 0.0f;
      this.RuleGroup[395] = 18;
      this.RuleString[399] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[399] = 0.0f;
      this.RuleGroup[399] = 0;
      this.RuleString[800] = "NEW AI. Allow joining of non kampfgruppes. 0=dont. 1=do.";
      if (!namesonly)
        this.RuleVar[800] = 0.0f;
      this.RuleGroup[800] = 18;
      this.RuleString[802] = "NEW AI. Unlimited Strategic Transfer for AI. 0=dont. 1=do.";
      if (!namesonly)
        this.RuleVar[802] = 0.0f;
      this.RuleGroup[802] = 18;
      this.RuleString[803] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[803] = 0.0f;
      this.RuleGroup[803] = -1;
      this.RuleString[804] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[804] = 0.0f;
      this.RuleGroup[804] = -1;
      this.RuleString[805] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[805] = 0.0f;
      this.RuleGroup[805] = -1;
      this.RuleString[806] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[806] = 0.0f;
      this.RuleGroup[806] = -1;
      this.RuleString[809] = "NEW AI. Forbid AI to blow bridges. 1=forbid. 0=allow.";
      if (!namesonly)
        this.RuleVar[809] = 0.0f;
      this.RuleGroup[809] = 18;
      this.RuleString[810] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[810] = 0.0f;
      this.RuleGroup[810] = -1;
      this.RuleString[811] = "NEW AI. Friendly Strategic Corps Movement speed-up. 0=none.. 1=double... 2=triple";
      if (!namesonly)
        this.RuleVar[811] = 0.0f;
      this.RuleGroup[811] = 18;
      this.RuleString[812] = "NEW AI. LOG OPTION. Make screenshot of areas. 0=no. 1=yes";
      if (!namesonly)
        this.RuleVar[812] = 0.0f;
      this.RuleGroup[812] = 18;
      this.RuleString[813] = "NEW AI. AI CONSERVATIVE. 0=use always. 1=strategic only. 2=tactical only";
      if (!namesonly)
        this.RuleVar[813] = 0.0f;
      this.RuleGroup[813] = 18;
      this.RuleString[826] = "NEW AI. STRATEGIC CALCS. Prohibit enemy from moving fast. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[826] = 0.0f;
      this.RuleGroup[826] = 18;
      this.RuleString[827] = "NEW AI. STRATEGIC CALCS. Prohibit making alarm groups + offensive detachments. 0=no, 1=yes, 2=attacker only alarm";
      if (!namesonly)
        this.RuleVar[827] = 0.0f;
      this.RuleGroup[827] = 18;
      this.RuleString[828] = "NEW AI. STRATEGIC CALCS. Prohibit enemy transfer+relocate. 0=no, >1 is divided by that number. the more the less transfer";
      if (!namesonly)
        this.RuleVar[828] = 0.0f;
      this.RuleGroup[828] = 18;
      this.RuleString[829] = "NEW AI. STRATEGIC CALCS. STRATEGIC. Counter attack damage modifier. 0 is no. >1 is divided by that number ";
      if (!namesonly)
        this.RuleVar[829] = 0.0f;
      this.RuleGroup[829] = 18;
      this.RuleString[830] = "NEW AI. STRATEGIC CALCS. Allow aggressive relocate of enemy. (is std if enemy is attacker/meeting) 0=no 1=yes   ";
      if (!namesonly)
        this.RuleVar[830] = 0.0f;
      this.RuleGroup[830] = 18;
      this.RuleString[831] = "NEW AI. STRATEGIC CALCS. Extra (virtual) Hex Distance between areas to make counterattack slower. (4hex p.r)  ";
      if (!namesonly)
        this.RuleVar[831] = 0.0f;
      this.RuleGroup[831] = 18;
      this.RuleString[832] = "NEW AI. STRATEGIC CALCS IMPLEMENTATION. Add 1 round Inertia to changing attack plans. 0=no, 1=yes.  ";
      if (!namesonly)
        this.RuleVar[832] = 0.0f;
      this.RuleGroup[832] = 18;
      this.RuleString[842] = "NEW AI. Allow changing of SO Air intercept stance by AI. 0=no. >0 is the multiplication of own strenght in cosidering.  ";
      if (!namesonly)
        this.RuleVar[842] = 0.0f;
      this.RuleGroup[842] = 18;
      this.RuleString[844] = "NEW AI: Games last round. Used for predicting losing scn for attacker. 0=not used.";
      if (!namesonly)
        this.RuleVar[844] = 0.0f;
      this.RuleGroup[844] = 18;
      this.RuleString[888] = "NEW AI: All Corps(5) HQs act as if they are fixed";
      if (!namesonly)
        this.RuleVar[888] = 0.0f;
      this.RuleGroup[888] = 18;
      this.RuleString[889] = "NEW AI: Work with Sub-Corps groups. 0=no, 1=yes [not fully developed, only use in few round scenarios]";
      if (!namesonly)
        this.RuleVar[889] = 0.0f;
      this.RuleGroup[889] = 18;
      this.RuleString[890] = "NEW AI/DC2 AI: Enemy uses different supply movetype. 0=no, >0 = movetype used by enemy.";
      if (!namesonly)
        this.RuleVar[890] = 0.0f;
      this.RuleGroup[890] = 18;
      this.RuleGroup2[890] = 19;
      this.RuleString[913] = "DC2 AI: AI uses dynamic OOB+regime cards. 0=no, 1=yes, -1=no, but uses regime cards";
      if (!namesonly)
        this.RuleVar[913] = 0.0f;
      this.RuleGroup[913] = 19;
      this.RuleString[914] = "DC2 AI: AI gets free units, hq switches, officer assignments. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[914] = 0.0f;
      this.RuleGroup[914] = 19;
      this.RuleString[915] = "DC2 AI: General hisvar type best for officers in ANY command (0=dont use)";
      if (!namesonly)
        this.RuleVar[915] = 0.0f;
      this.RuleGroup[915] = 19;
      this.RuleString[916] = "DC2 AI: Officer hisvar type best for officers in NOT lowest HQ command (0=dont use)";
      if (!namesonly)
        this.RuleVar[916] = 0.0f;
      this.RuleGroup[916] = 19;
      this.RuleString[917] = "DC2 AI: Disable FULL RETREAT stance to avoid encirclement. 1=disable.";
      if (!namesonly)
        this.RuleVar[917] = 0.0f;
      this.RuleGroup[917] = 19;
      this.RuleString[918] = "DC2 AI: Disable normal RETREAT stance to keep line always. 1=disable";
      if (!namesonly)
        this.RuleVar[918] = 0.0f;
      this.RuleGroup[918] = 19;
      this.RuleString[919] = "DC2 AI: Garrison I only hex with X vp or more. 0=dont do";
      if (!namesonly)
        this.RuleVar[919] = 0.0f;
      this.RuleGroup[919] = 19;
      this.RuleString[920] = "DC2 AI: Garrison I only hex within X distance of enemy. 0=dont do";
      if (!namesonly)
        this.RuleVar[920] = 0.0f;
      this.RuleGroup[920] = 19;
      this.RuleString[921] = "DC2 AI: Always garrison port hexes irrespective of VP. 0=dont do, 1=yes do";
      if (!namesonly)
        this.RuleVar[921] = 0.0f;
      this.RuleGroup[921] = 19;
      this.RuleString[922] = "DC2 AI: Garrison hex with X vp or more always (irrespective enemy dist). 0=dont do";
      if (!namesonly)
        this.RuleVar[922] = 0.0f;
      this.RuleGroup[922] = 19;
      this.RuleString[923] = "DC2 AI: Garrison II only hex with X vp or more. 0=dont do";
      if (!namesonly)
        this.RuleVar[923] = 0.0f;
      this.RuleGroup[923] = 19;
      this.RuleString[924] = "DC2 AI: Garrison II only hex within X distance of enemy. 0=dont do";
      if (!namesonly)
        this.RuleVar[924] = 0.0f;
      this.RuleGroup[924] = 19;
      this.RuleString[928] = "DC2 AI: Top Operations (Panzer Focus). 0=dont do. 1=100% are, 2=50% are, 3=33.3% are..";
      if (!namesonly)
        this.RuleVar[928] = 0.0f;
      this.RuleGroup[928] = 19;
      this.RuleString[929] = "DC2 AI: Power Points in reinforcements expected for FRIENDLY.";
      if (!namesonly)
        this.RuleVar[929] = 0.0f;
      this.RuleGroup[929] = 19;
      this.RuleString[930] = "DC2 AI: Power Points in reinforcements expected for ENEMY.";
      if (!namesonly)
        this.RuleVar[930] = 0.0f;
      this.RuleGroup[930] = 19;
      this.RuleString[931] = "DC2 AI: Max iterations into the future for strategic (0=default, 4=normal).";
      if (!namesonly)
        this.RuleVar[931] = 0.0f;
      this.RuleGroup[931] = 19;
      this.RuleString[932] = "DC2 AI: Max frontline depth  (0=default value 3).";
      if (!namesonly)
        this.RuleVar[932] = 0.0f;
      this.RuleGroup[932] = 19;
      this.RuleString[933] = "DC2 AI: Max frontline length  (0=default value 12).";
      if (!namesonly)
        this.RuleVar[933] = 0.0f;
      this.RuleGroup[933] = 19;
      this.RuleString[934] = "DC2 AI: Also allow creation of new HQ if not officers in officerpool. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[934] = 0.0f;
      this.RuleGroup[934] = 19;
      this.RuleString[935] = "DC2 AI: Maximum units per corps (for new corps HQ calculations). 0=unlimited. ";
      if (!namesonly)
        this.RuleVar[935] = 0.0f;
      this.RuleGroup[935] = 19;
      this.RuleString[936] = "DC2 AI: Maximum corps per army (for new army HQ calculations). 0=unlimited. ";
      if (!namesonly)
        this.RuleVar[936] = 0.0f;
      this.RuleGroup[936] = 19;
      this.RuleString[937] = "DC2 AI: Howmany subparts must a 'armour' unit have to be considered a TOPunit. ";
      if (!namesonly)
        this.RuleVar[937] = 0.0f;
      this.RuleGroup[937] = 19;
      this.RuleString[938] = "DC2 AI: UberRegime gives all units except airTransport+Sea to unterRegime. 1=yes. ";
      if (!namesonly)
        this.RuleVar[938] = 0.0f;
      this.RuleGroup[938] = 19;
      this.RuleString[939] = "DC2 AI: Fortress Mode for encircled troops if >= then X VP. 0=never do. ";
      if (!namesonly)
        this.RuleVar[939] = 0.0f;
      this.RuleGroup[939] = 19;
      this.RuleString[940] = "DC2 AI: Always Protect VP in frontline fronts. 0=no, 1=yes, 2=yes even if retreat front (Delay action) ";
      if (!namesonly)
        this.RuleVar[940] = 0.0f;
      this.RuleGroup[940] = 19;
      this.RuleString[991] = "DC2 AI: AI Siege Artillery simulation. 0=not used. >0 is maximum entrenchment of enemy in that hex. example: 20 is max 20 entrenchment pts. ";
      if (!namesonly)
        this.RuleVar[991] = 0.0f;
      this.RuleGroup[991] = 19;
      this.RuleString[992] = "DC2 AI: AI suplementary combat bonus. 0=not used. >0 = extra combat bonus. ";
      if (!namesonly)
        this.RuleVar[992] = 0.0f;
      this.RuleGroup[992] = 19;
      this.RuleString[993] = "DC2 AI: AI never gets it concentric bonus reduced due to using units from different HQs. Plus extra emphasis on concentric. 0=no, 1=yes ";
      if (!namesonly)
        this.RuleVar[993] = 0.0f;
      this.RuleGroup[993] = 19;
      this.RuleString[994] = "DC2 AI: More emphasis on preventing enemy concentric attacks. 0=no, 1=yes ";
      if (!namesonly)
        this.RuleVar[994] = 0.0f;
      this.RuleGroup[994] = 19;
      this.RuleString[995] = "DC2 AI: AI never gets RdnLossPer100ap used. 0=no, 1=yes, 2=only half";
      if (!namesonly)
        this.RuleVar[995] = 0.0f;
      this.RuleGroup[995] = 19;
      this.RuleString[941] = "DC2 AI: Turn on debug screenshots and logs. 0=no, 1=yes. (can create lot of files, delete often) ";
      if (!namesonly)
        this.RuleVar[941] = 0.0f;
      this.RuleGroup[941] = 19;
      this.RuleString[942] = "DC2 AI: Modify minimum attack. 0=no mod. 1=no mod. <1 is less offensive power needed. >1 more offensive power needed.";
      if (!namesonly)
        this.RuleVar[942] = 0.0f;
      this.RuleGroup[942] = 19;
      this.RuleString[943] = "DC2 AI: Modify own strength perception. 0=no mod. 1=no mod. <1 is less strong. >1 stronger.";
      if (!namesonly)
        this.RuleVar[943] = 0.0f;
      this.RuleGroup[943] = 19;
      this.RuleString[745] = "DC2 AI: Do not assign strict front HQ to OTHER front if that front has origAverageStr > x : (0=dont use)";
      if (!namesonly)
        this.RuleVar[745] = 0.0f;
      this.RuleGroup[745] = 19;
      this.RuleString[746] = "DC2 AI: Do not assign strict front HQ from ORIGIN front if that front has origAverageStr < x : (0=dont use)";
      if (!namesonly)
        this.RuleVar[746] = 0.0f;
      this.RuleGroup[746] = 19;
      this.RuleString[747] = "DC2 AI: Multiplier for distance negative effect for front HQ change to another front (0=dont use)";
      if (!namesonly)
        this.RuleVar[747] = 0.0f;
      this.RuleGroup[747] = 19;
      this.RuleString[748] = "DC2 AI: Do not allow wiping of offensive zone assignments if other closer HQs are already assigned (0=dont use, 1=do not allow wipe)";
      if (!namesonly)
        this.RuleVar[748] = 0.0f;
      this.RuleGroup[748] = 19;
      this.RuleString[958] = "DC2 AI: Superfront use by looking at hex of HQ level at type X <=0 = disabled.  type=6=hq of lowest hq,7=hq of hq of lowest hq , etc.. ";
      if (!namesonly)
        this.RuleVar[958] = 0.0f;
      this.RuleGroup[958] = 19;
      this.RuleString[959] = "DC2 AI: if Superfront use. Uses event X to set superfront numbers to hexes. -1=do not call an event all values of 960 areaslot will be 0. ";
      if (!namesonly)
        this.RuleVar[959] = 0.0f;
      this.RuleGroup[959] = 19;
      this.RuleString[960] = "DC2 AI: if Superfront use. Uses areaslot X to read superfront numbers from hexes. (0-9)";
      if (!namesonly)
        this.RuleVar[960] = 0.0f;
      this.RuleGroup[960] = 19;
      this.RuleString[961] = "DC2 AI: Stricter HQ-Front assignments. Set to 1 to use. Usefull for scenarios where re-assigning HQs for units is not possible.";
      if (!namesonly)
        this.RuleVar[961] = 0.0f;
      this.RuleGroup[961] = 19;
      this.RuleString[962] = "DC2 AI: Long term prognosis enemy movement (ap) capacity. -1=increased, 0=default, 1=half, 2=none";
      if (!namesonly)
        this.RuleVar[962] = 0.0f;
      this.RuleGroup[962] = 19;
      this.RuleString[963] = "DC2 AI: Use offensive or defensive zones? 0=no, 1=offensive zones, 2=defensive zones";
      if (!namesonly)
        this.RuleVar[963] = 0.0f;
      this.RuleGroup[963] = 19;
      this.RuleString[964] = "DC2 AI: Offensive/defensive/retreat_mod zones. Use areaslot X to read zone numbers. (0-9) ";
      if (!namesonly)
        this.RuleVar[964] = 0.0f;
      this.RuleGroup[964] = 19;
      this.RuleString[965] = "DC2 AI: Use event X to set offensive/defensive zone numbers to hexes. -1=do not call an event all values of 964 areaslot will be 0.";
      if (!namesonly)
        this.RuleVar[965] = 0.0f;
      this.RuleGroup[965] = 19;
      this.RuleString[967] = "DC2 AI: Set >0 to enable Subgroups in Strict HQs (SSHQ). >=1 = max in subgroup.  ";
      if (!namesonly)
        this.RuleVar[967] = 0.0f;
      this.RuleGroup[967] = 19;
      this.RuleString[968] = "DC2 AI: Set >0 to enable different sized 2nd,3rd,etc.. groups in Strict HQs (SSHQ). >=1 = max in 2nd,3rd,etc.. subgroup. ";
      if (!namesonly)
        this.RuleVar[968] = 0.0f;
      this.RuleGroup[968] = 19;
      this.RuleString[969] = "DC2 AI: Use MLA >0 = yes. if >0 it specifies range of MLA average construction. ";
      if (!namesonly)
        this.RuleVar[969] = 0.0f;
      this.RuleGroup[969] = 19;
      this.RuleString[970] = "DC2 AI: Minimal HQ re-assignment for regular units. (works better with StrictHQs). 0=off/1=on ";
      if (!namesonly)
        this.RuleVar[970] = 0.0f;
      this.RuleGroup[970] = 19;
      this.RuleString[979] = "DC2 AI: At what hex size does a classic defensive zone becomes a broad defensive zone? 0=off/>0=hexes. ";
      if (!namesonly)
        this.RuleVar[979] = 0.0f;
      this.RuleGroup[979] = 19;
      this.RuleString[980] = "DC2 AI: Use event X to set retreat modifier. -1=do not call an event all values of 964 areaslot will be 100. ";
      if (!namesonly)
        this.RuleVar[980] = 0.0f;
      this.RuleGroup[980] = 19;
      this.RuleString[981] = "DC2 AI: Use event X to set strength modifier. -1=do not call an event all values of 964 areaslot will be 100. ";
      if (!namesonly)
        this.RuleVar[981] = 0.0f;
      this.RuleGroup[981] = 19;
      this.RuleString[985] = "DC2 AI: Strength modifier is also minimum combat advantage modifier. 0=no. 1=yes. ";
      if (!namesonly)
        this.RuleVar[985] = 0.0f;
      this.RuleGroup[985] = 19;
      this.RuleString[986] = "DC2 AI: Offensive zones go ALL-OUT for breakthrough and terrain gain. 0=no. 1=yes. 2=extremely so. ";
      if (!namesonly)
        this.RuleVar[986] = 0.0f;
      this.RuleGroup[986] = 19;
      this.RuleString[987] = "DC2 AI: AI uses different rulevar73 hexes of 100% hq power. 0=no >0 = the value used. ";
      if (!namesonly)
        this.RuleVar[987] = 0.0f;
      this.RuleGroup[987] = 19;
      this.RuleString[982] = "DC2 AI: Favorise top-unit attacks. 0=don't. >=1 is extra strength in % point + >=1 means unit favorised as attack choice. ";
      if (!namesonly)
        this.RuleVar[982] = 0.0f;
      this.RuleGroup[982] = 19;
      this.RuleString[891] = "NEW AI: Test method. 0=dont use. >0= ID of historical unit HQ who's group is only tactical test";
      if (!namesonly)
        this.RuleVar[891] = 0.0f;
      this.RuleGroup[891] = 18;
      this.RuleString[892] = "NEW AI: Test method. 0=dont use. >0= ID of historical unit HQ who's group is only tactical test";
      if (!namesonly)
        this.RuleVar[892] = 0.0f;
      this.RuleGroup[892] = 18;
      this.RuleString[893] = "NEW AI: Test method. 0=dont use. >0= ID of historical unit HQ who's group is only tactical test";
      if (!namesonly)
        this.RuleVar[893] = 0.0f;
      this.RuleGroup[893] = 18;
      this.RuleString[989] = "NEW AI: Offensive Zone Distance Agnosticity. 0=dont use. >0 = % of AP distance more allowed of top result. When active uses enemyPower as deciding ";
      if (!namesonly)
        this.RuleVar[989] = 0.0f;
      this.RuleGroup[989] = 18;
      this.RuleString[997] = "DC2 AI: Use Different Distance Importance Weights for StrictHQ reshuffles. 0=no, 1=dist less important, 2=much less  ";
      if (!namesonly)
        this.RuleVar[997] = 0.0f;
      this.RuleGroup[997] = 19;
      this.RuleString[465] = "DC2 AI: AI only change HQs if no HQ left... 0=no keep to default behaviour, 1=yes limit AI HQ changing ";
      if (!namesonly)
        this.RuleVar[465] = 0.0f;
      this.RuleGroup[465] = 19;
      this.RuleString[600] = "DC2 AI: Maximum number of Battlegroups created by the AI per round.";
      if (!namesonly)
        this.RuleVar[600] = 0.0f;
      this.RuleGroup[600] = 19;
      this.RuleString[601] = "DC2 AI: Prevent small low-mobility units to be seen as garrisons 0/1";
      if (!namesonly)
        this.RuleVar[601] = 0.0f;
      this.RuleGroup[601] = 19;
      this.RuleString[602] = "DC2 AI: Block Product6 overruling of garrison rules 0/1";
      if (!namesonly)
        this.RuleVar[602] = 0.0f;
      this.RuleGroup[602] = 19;
      this.RuleString[603] = "DC2 AI: Assume city level X will be able to receive air supply (0=no assumption here)";
      if (!namesonly)
        this.RuleVar[603] = 0.0f;
      this.RuleGroup[603] = 19;
      this.RuleString[604] = "DC2 AI: Play Cards that put Supply Bases on hexes (0=no, 1=yes rarely, 2=yes sometimes, 4=when needed,8=often) ";
      if (!namesonly)
        this.RuleVar[604] = 0.0f;
      this.RuleGroup[604] = 19;
      this.RuleString[706] = "DC2 AI: U meta relocations every X rounds ";
      if (!namesonly)
        this.RuleVar[706] = 0.0f;
      this.RuleGroup[706] = 19;
      this.RuleString[707] = "DC2 AI: Use meta relocations stringlist slot";
      if (!namesonly)
        this.RuleVar[707] = 0.0f;
      this.RuleGroup[707] = 19;
      this.RuleString[466] = "DC4 AI: Do not wait out enemy pockets... keep attacking.. 0=no/default, 1=yes hammer them out. ";
      if (!namesonly)
        this.RuleVar[466] = 0.0f;
      this.RuleGroup[466] = 19;
      this.RuleString[502] = "Disable Action Cards (0=no 1=yes)";
      if (!namesonly)
        this.RuleVar[502] = 0.0f;
      this.RuleGroup[502] = 12;
      this.RuleString[503] = "Disable Build Infra (0=no 1=yes)";
      if (!namesonly)
        this.RuleVar[503] = 0.0f;
      this.RuleGroup[503] = 12;
      this.RuleString[505] = "Disable Blow Bridge(0=no 1=yes)";
      if (!namesonly)
        this.RuleVar[505] = 0.0f;
      this.RuleGroup[505] = 12;
      this.RuleString[507] = "Disable Load & Unload (0=no 1=yes)";
      if (!namesonly)
        this.RuleVar[507] = 0.0f;
      this.RuleGroup[507] = 12;
      this.RuleString[508] = "Obsolete";
      if (!namesonly)
        this.RuleVar[508] = 0.0f;
      this.RuleGroup[508] = 0;
      this.RuleString[511] = "Disable Naval artillery and attacks";
      if (!namesonly)
        this.RuleVar[511] = 0.0f;
      this.RuleGroup[511] = 12;
      this.RuleString[512] = "Disable add unit";
      if (!namesonly)
        this.RuleVar[512] = 0.0f;
      this.RuleGroup[512] = 12;
      this.RuleString[514] = "OBSOLETE";
      if (!namesonly)
        this.RuleVar[514] = 0.0f;
      this.RuleGroup[514] = 0;
      this.RuleString[515] = "Disable paradrop & airlift button";
      if (!namesonly)
        this.RuleVar[515] = 0.0f;
      this.RuleGroup[515] = 12;
      this.RuleString[516] = "Disable air supply";
      if (!namesonly)
        this.RuleVar[516] = 0.0f;
      this.RuleGroup[516] = 12;
      this.RuleString[520] = "Disable strategic transfer";
      if (!namesonly)
        this.RuleVar[520] = 0.0f;
      this.RuleGroup[520] = 12;
      this.RuleString[521] = "Disable change HQ (2=allow if no HQ at moment)";
      if (!namesonly)
        this.RuleVar[521] = 0.0f;
      this.RuleGroup[521] = 12;
      this.RuleString[522] = "Disable Air Recon";
      if (!namesonly)
        this.RuleVar[522] = 0.0f;
      this.RuleGroup[522] = 12;
      this.RuleString[523] = "Disable Supply Layer button";
      if (!namesonly)
        this.RuleVar[523] = 0.0f;
      this.RuleGroup[523] = 12;
      this.RuleString[525] = "Enable Neutral Sea Hex Sharing";
      if (!namesonly)
        this.RuleVar[525] = 0.0f;
      this.RuleGroup[525] = 12;
      this.RuleString[526] = "New Unit through historical Units";
      if (!namesonly)
        this.RuleVar[526] = 0.0f;
      this.RuleGroup[526] = 12;
      this.RuleString[527] = "New Subunits order enabled";
      if (!namesonly)
        this.RuleVar[527] = 0.0f;
      this.RuleGroup[527] = 12;
      this.RuleString[528] = "Enable Giving of Unit to Ally";
      if (!namesonly)
        this.RuleVar[528] = 0.0f;
      this.RuleGroup[528] = 12;
      this.RuleString[529] = "Enable Giving of Hex to Ally";
      if (!namesonly)
        this.RuleVar[529] = 0.0f;
      this.RuleGroup[529] = 12;
      this.RuleString[859] = "Disable battlestack remember use for land/air/art (1=disabled)";
      if (!namesonly)
        this.RuleVar[859] = 0.0f;
      this.RuleGroup[859] = 12;
      this.RuleString[531] = "Enable Changing Model of Unit (1=yes)";
      if (!namesonly)
        this.RuleVar[531] = 0.0f;
      this.RuleGroup[531] = 12;
      this.RuleString[533] = "Disable Group Orders (move/strategic) (1=yes) ";
      if (!namesonly)
        this.RuleVar[533] = 0.0f;
      this.RuleGroup[533] = 12;
      this.RuleString[534] = "Enable SF Model Design (1=yes) ";
      if (!namesonly)
        this.RuleVar[534] = 0.0f;
      this.RuleGroup[534] = 12;
      this.RuleString[808] = "OBSOLETE ";
      if (!namesonly)
        this.RuleVar[808] = 0.0f;
      this.RuleGroup[808] = 12;
      this.RuleString[815] = "Only allow execution of events in eventgroup X (0=all events allowed) ";
      if (!namesonly)
        this.RuleVar[815] = 0.0f;
      this.RuleGroup[815] = 12;
      this.RuleString[816] = "Full Hide Enemy Option ";
      if (!namesonly)
        this.RuleVar[816] = 0.0f;
      this.RuleGroup[816] = 2;
      this.RuleString[817] = "Disable Getting Handcards";
      if (!namesonly)
        this.RuleVar[817] = 0.0f;
      this.RuleGroup[817] = 12;
      this.RuleString[899] = "Minimum artillery % to include unit in 'ALL' button of artillery attack.";
      if (!namesonly)
        this.RuleVar[899] = 0.0f;
      this.RuleGroup[899] = 14;
      this.RuleString[845] = "Enable Sideways Graphics for Landscapetypes (1=yes)";
      if (!namesonly)
        this.RuleVar[845] = 0.0f;
      this.RuleGroup[845] = 14;
      this.RuleString[846] = "People Graphic offset in pixels (0=no offset)";
      if (!namesonly)
        this.RuleVar[846] = 0.0f;
      this.RuleGroup[846] = 14;
      this.RuleString[847] = "New Counter mode (0=old AT, 1=yes)";
      if (!namesonly)
        this.RuleVar[847] = 0.0f;
      this.RuleGroup[847] = 14;
      this.RuleString[849] = "Equipment offset for people after equipment draw (0=no offset)";
      if (!namesonly)
        this.RuleVar[849] = 0.0f;
      this.RuleGroup[849] = 14;
      this.RuleString[909] = "Show his.var number on side of unit (0=no, >0 hisvar type to show)";
      if (!namesonly)
        this.RuleVar[909] = 0.0f;
      this.RuleGroup[909] = 14;
      this.RuleString[976] = "GUI: DC3 - Custom DC3 GUI changes (1=yes,0=no) ";
      if (!namesonly)
        this.RuleVar[976] = 0.0f;
      this.RuleGroup[976] = 14;
      this.RuleString[540] = "GUI: Move Arrows (1=yes,0=no) ";
      if (!namesonly)
        this.RuleVar[540] = 0.0f;
      this.RuleGroup[540] = 14;
      this.RuleString[990] = "GUI: Alternate music tracks (1=yes,0=no) (Alternate version uses '_alternate' in end of filename)";
      if (!namesonly)
        this.RuleVar[990] = 0.0f;
      this.RuleGroup[990] = 14;
      this.RuleString[988] = "GUI: Help tab active? 0=no, >=1 is the ID of the stringlist used. ";
      if (!namesonly)
        this.RuleVar[988] = 0.0f;
      this.RuleGroup[988] = 14;
      this.RuleString[998] = "GUI: DC3 - Hex Textures (1=yes,0=no) ";
      if (!namesonly)
        this.RuleVar[998] = 0.0f;
      this.RuleGroup[998] = 14;
      this.RuleString[999] = "GUI: Big Counters Bigger Siluet (1=yes, 0=no) ";
      if (!namesonly)
        this.RuleVar[999] = 0.0f;
      this.RuleGroup[999] = 14;
      this.RuleString[451] = "GUI: Recoloring allowed (>1 = stringlist ID, 0=no)";
      if (!namesonly)
        this.RuleVar[451] = 0.0f;
      this.RuleGroup[451] = 14;
      this.RuleString[708] = "GUI: Show Victory State using DC4 Libraries like 'VR Basic Lib'";
      if (!namesonly)
        this.RuleVar[708] = 0.0f;
      this.RuleGroup[708] = 14;
      this.RuleString[848] = "Use landscape from which LT for Air trooptype background overrule. (0=dont)";
      if (!namesonly)
        this.RuleVar[848] = 0.0f;
      this.RuleGroup[848] = 14;
      this.RuleString[872] = "Use landscape from which LT for Navy trooptype background overrule. (0=dont)";
      if (!namesonly)
        this.RuleVar[872] = 0.0f;
      this.RuleGroup[872] = 14;
      this.RuleString[850] = "Do screenshot in zoom mode. 0=32x24, 1=64x48, 2=128x96";
      if (!namesonly)
        this.RuleVar[850] = 0.0f;
      this.RuleGroup[850] = 14;
      this.RuleString[866] = "obsolete";
      if (!namesonly)
        this.RuleVar[866] = 0.0f;
      this.RuleGroup[866] = 14;
      this.RuleString[867] = "obsolete";
      if (!namesonly)
        this.RuleVar[867] = 0.0f;
      this.RuleGroup[867] = 14;
      this.RuleString[878] = "Do not enforce the width+height<400 mapsize screenshot limit protection. 0=do enforce. 1=do not enforce.";
      if (!namesonly)
        this.RuleVar[878] = 0.0f;
      this.RuleGroup[878] = 14;
      this.RuleString[650] = "Extra Statistic 1. (see string 700 for name) 0=no, >0 = regimevar #";
      if (!namesonly)
        this.RuleVar[650] = 0.0f;
      this.RuleGroup[650] = 13;
      this.RuleString[651] = "Extra Statistic 2. (see string 701 for name) 0=no, >0 = regimevar #";
      if (!namesonly)
        this.RuleVar[651] = 0.0f;
      this.RuleGroup[651] = 13;
      this.RuleString[652] = "Extra Statistic 3. (see string 702 for name) 0=no, >0 = regimevar #";
      if (!namesonly)
        this.RuleVar[652] = 0.0f;
      this.RuleGroup[652] = 13;
      this.RuleString[313] = "Always show all statistics no matter of FOW or Shrowd setting. 0=off, 1=rule in effect.";
      if (!namesonly)
        this.RuleVar[313] = 0.0f;
      this.RuleGroup[313] = 13;
      this.RuleString[905] = "GUI shows Category Card Category Names. 0=no, 1=1 cat, 2=2, etc.., max 5. (see tempstrings for names)";
      if (!namesonly)
        this.RuleVar[905] = 0.0f;
      this.RuleGroup[905] = 13;
      this.RuleString[906] = "GUI: Block messages at turn startup. (0=no, 1=yes) ";
      if (!namesonly)
        this.RuleVar[906] = 0.0f;
      this.RuleGroup[906] = 13;
      this.RuleString[946] = "TroopType Intermediate Editor. Use event ID for writing SFTypes.";
      if (!namesonly)
        this.RuleVar[946] = 0.0f;
      this.RuleGroup[946] = 20;
      this.RuleString[947] = "Use Small Graphics for logo pictures in groupname 1000-1099. 0=no, 1=yes";
      if (!namesonly)
        this.RuleVar[947] = 0.0f;
      this.RuleGroup[947] = 13;
      this.RuleString[948] = "DEBUG: Switch on event debugging? 0=no, 1=yes ";
      if (!namesonly)
        this.RuleVar[948] = 0.0f;
      this.RuleGroup[948] = 13;
      this.RuleString[971] = "GUI: Use Cinematics Stringlist (0=no, >0 = ID of stringlist) ";
      if (!namesonly)
        this.RuleVar[971] = 0.0f;
      this.RuleGroup[971] = 13;
      if (DrawMod.TGame.AllowHeightMap)
      {
        this.RuleString[415] = "Use LAND Height Map Feature? 0=no, >0 = stringlist ID  ";
        if (!namesonly)
          this.RuleVar[415] = 0.0f;
        this.RuleGroup[415] = 21;
        this.RuleString[416] = "Use SEA Height Map Feature? 0=no, >0 = stringlist ID  ";
        if (!namesonly)
          this.RuleVar[416] = 0.0f;
        this.RuleGroup[416] = 21;
        this.RuleString[417] = "Use Beach Coloring Feature? 0=no, >0 = stringlist ID ";
        if (!namesonly)
          this.RuleVar[417] = 0.0f;
        this.RuleGroup[417] = 21;
        this.RuleString[418] = "Use River Canyoning? 0=no, >0 = stringlist ID  ";
        if (!namesonly)
          this.RuleVar[418] = 0.0f;
        this.RuleGroup[418] = 21;
      }
      if (DrawMod.TGame.AllowHeightMap)
      {
        this.RuleString[419] = "Use Advanced Recon Rules (LOS) System 0/1. Also enables Direct Fire. ";
        if (!namesonly)
          this.RuleVar[419] = 0.0f;
        this.RuleGroup[419] = 21;
        this.RuleString[420] = "Advanced Recon Rules. 1st Hex Divider";
        if (!namesonly)
          this.RuleVar[420] = 0.0f;
        this.RuleGroup[420] = 21;
        this.RuleString[421] = "Advanced Recon Rules. 2nd+ Hex Divider";
        if (!namesonly)
          this.RuleVar[421] = 0.0f;
        this.RuleGroup[421] = 21;
        this.RuleString[422] = "Advanced Recon Rules. Maximum Range. 0=no range";
        if (!namesonly)
          this.RuleVar[422] = 0.0f;
        this.RuleGroup[422] = 21;
        this.RuleString[423] = "Advanced Recon Rules. XP Level switch point penalty and bonus on Recon/Hide Pts";
        if (!namesonly)
          this.RuleVar[423] = 0.0f;
        this.RuleGroup[423] = 21;
        this.RuleString[424] = "Height Map Rules. Base Height Level Defending Units Hitpoint Modifier for being lower";
        if (!namesonly)
          this.RuleVar[424] = 0.0f;
        this.RuleGroup[424] = 21;
        this.RuleString[425] = "Height Map Rules. Base Height Level Defending Units Hitpoint Modifier for being higher";
        if (!namesonly)
          this.RuleVar[425] = 0.0f;
        this.RuleGroup[425] = 21;
        this.RuleString[426] = "Height Map Rules. Base Height Level Modifier for Movement without Road";
        if (!namesonly)
          this.RuleVar[426] = 0.0f;
        this.RuleGroup[426] = 21;
        this.RuleString[427] = "Height Map Rules. Base Height Level Modifier for Movement with Road";
        if (!namesonly)
          this.RuleVar[427] = 0.0f;
        this.RuleGroup[427] = 21;
        this.RuleString[428] = "Intercept Fire: 0=off, >=1=on, 1=1 round, 2=2 rounds, etc...";
        if (!namesonly)
          this.RuleVar[428] = 0.0f;
        this.RuleGroup[428] = 21;
        this.RuleString[429] = "Direct Fire can Target Rear-Area Troops chance. 0=no, 1=yes";
        if (!namesonly)
          this.RuleVar[429] = 0.0f;
        this.RuleGroup[429] = 21;
        this.RuleString[430] = "Indirect Ranged Fire gets bonus if LOS% on hex. 0=no, 1.0=100% bonus, 0.5=50% bonus (modified for Los%)";
        if (!namesonly)
          this.RuleVar[430] = 0.0f;
        this.RuleGroup[430] = 21;
        this.RuleString[431] = "Combat Recon: 0=off, 1=on";
        if (!namesonly)
          this.RuleVar[431] = 0.0f;
        this.RuleGroup[431] = 21;
        this.RuleString[432] = "Combat Recon: Hitpoint Maximum Increase Factor (*X)";
        if (!namesonly)
          this.RuleVar[432] = 0.0f;
        this.RuleGroup[432] = 21;
        this.RuleString[433] = "Combat Recon: Markers: 0=off, 1=on";
        if (!namesonly)
          this.RuleVar[433] = 0.0f;
        this.RuleGroup[433] = 21;
        this.RuleString[434] = "Simple Supply Need Rules: 0=off, 1=on";
        if (!namesonly)
          this.RuleVar[434] = 0.0f;
        this.RuleGroup[434] = 21;
        this.RuleString[435] = "Unit-based Fuel: 0=off, 1=on";
        if (!namesonly)
          this.RuleVar[435] = 0.0f;
        this.RuleGroup[435] = 21;
        this.RuleString[436] = "Intercept Fire: Reduction in Consumption and Rdn loss 0.x (0=free. 0.5=half cost)";
        if (!namesonly)
          this.RuleVar[436] = 0.0f;
        this.RuleGroup[436] = 21;
        this.RuleString[437] = "Simple Supply Need Rules: Maximum Supply Consume % loss in absolute points";
        if (!namesonly)
          this.RuleVar[437] = 0.0f;
        this.RuleGroup[437] = 21;
        this.RuleString[438] = "Simple Supply Need Rules: Maximum extra Morale Hit if hit while on reduced consumption rations";
        if (!namesonly)
          this.RuleVar[438] = 0.0f;
        this.RuleGroup[438] = 21;
        this.RuleString[467] = "Morale Hit for 1st attacked per round if not received any supplies (even if enough reserves)";
        if (!namesonly)
          this.RuleVar[467] = 0.0f;
        this.RuleGroup[467] = 9;
        this.RuleString[468] = "Readiness Hit for 1st attacked per round if not received any supplies (even if enough reserves)";
        if (!namesonly)
          this.RuleVar[468] = 0.0f;
        this.RuleGroup[468] = 9;
        this.RuleString[469] = "Morale Hit at start of turn if out-of-supply (even if enough reserves)";
        if (!namesonly)
          this.RuleVar[469] = 0.0f;
        this.RuleGroup[469] = 21;
        this.RuleString[470] = "Night Mode 0=no, 1=yes (graphical and some combat and movement effects).";
        if (!namesonly)
          this.RuleVar[470] = 0.0f;
        this.RuleGroup[470] = 21;
        this.RuleString[471] = "Use Supply Source Rules 0=off / >0 = loctype slot used.";
        if (!namesonly)
          this.RuleVar[471] = 0.0f;
        this.RuleGroup[471] = 21;
        this.RuleString[472] = "Use AP Reserve rules 0=off / >0 = AP gained per turn";
        if (!namesonly)
          this.RuleVar[472] = 0.0f;
        this.RuleGroup[472] = 21;
        this.RuleString[473] = "Maximum AP Reserve.";
        if (!namesonly)
          this.RuleVar[473] = 0.0f;
        this.RuleGroup[473] = 21;
        this.RuleString[474] = "Transport Movement Mode. 0=off >0 = minimum percentage Transport Movement Type of Unit.";
        if (!namesonly)
          this.RuleVar[474] = 0.0f;
        this.RuleGroup[474] = 21;
        this.RuleString[475] = "Battelgroup and Limited Transfer rules. 0=off, 1=on. ";
        if (!namesonly)
          this.RuleVar[475] = 0.0f;
        this.RuleGroup[475] = 21;
        this.RuleString[476] = "Minimum Power Points for Battlegroup.";
        if (!namesonly)
          this.RuleVar[476] = 0.0f;
        this.RuleGroup[476] = 21;
        this.RuleString[477] = "Maximum Power Points for Battlegroup.";
        if (!namesonly)
          this.RuleVar[477] = 0.0f;
        this.RuleGroup[477] = 21;
        this.RuleString[478] = "Battlegroup Rulevar that is unused for now.";
        if (!namesonly)
          this.RuleVar[478] = 0.0f;
        this.RuleGroup[478] = 21;
        this.RuleString[479] = "Optional Stringlist ID for Battlegroup Names. 0=none, >=1 is ID. ";
        if (!namesonly)
          this.RuleVar[479] = 0.0f;
        this.RuleGroup[479] = 21;
        this.RuleString[480] = "Counter-Battery Fire Revised Rules (they become priority targets) 0=no,1=yes. ";
        if (!namesonly)
          this.RuleVar[480] = 0.0f;
        this.RuleGroup[480] = 21;
        this.RuleString[481] = "Modified Retreat/Panic percentages. 0=no,1=yes. ";
        if (!namesonly)
          this.RuleVar[481] = 0.0f;
        this.RuleGroup[481] = 21;
        this.RuleString[482] = "Attack Type Option Available. 0=no,1=yes. ";
        if (!namesonly)
          this.RuleVar[482] = 0.0f;
        this.RuleGroup[482] = 21;
        this.RuleString[483] = "Engineers can construct bridge even if enemy on other side. 0=no,1=yes. ";
        if (!namesonly)
          this.RuleVar[483] = 0.0f;
        this.RuleGroup[483] = 21;
        this.RuleString[484] = "Different Move Modes available. 0=no, 1=yes ";
        if (!namesonly)
          this.RuleVar[484] = 0.0f;
        this.RuleGroup[484] = 21;
        this.RuleString[485] = "Intercept+Ranged Fire List feature. 0=no, 1=yes ";
        if (!namesonly)
          this.RuleVar[485] = 0.0f;
        this.RuleGroup[485] = 21;
        this.RuleString[486] = "Scrapping Rules. 0=no, >=1 is the ID of the Stringlist for instructions ";
        if (!namesonly)
          this.RuleVar[486] = 0.0f;
        this.RuleGroup[486] = 21;
        this.RuleString[487] = "New turn resets x% of Traffic Points to 0 (0=all, 5=only 5%, 50=50%, 75=75, 100=all)";
        if (!namesonly)
          this.RuleVar[487] = 0.0f;
        this.RuleGroup[487] = 21;
        this.RuleString[488] = "Fuel Weight 0.x... ";
        if (!namesonly)
          this.RuleVar[488] = 0.0f;
        this.RuleGroup[488] = 21;
        this.RuleString[489] = "Binary Fuel deliveries.. 0=no, 1=yes ";
        if (!namesonly)
          this.RuleVar[489] = 0.0f;
        this.RuleGroup[489] = 21;
        this.RuleString[490] = "Linear Carry Capacity.. 0=no, >0 = maximum extra carry cap% (for example 33 for 33%) ";
        if (!namesonly)
          this.RuleVar[490] = 0.0f;
        this.RuleGroup[490] = 21;
        this.RuleString[491] = "New Landscape Type Graphics System 0=no, 1=yes ";
        if (!namesonly)
          this.RuleVar[491] = 0.0f;
        this.RuleGroup[491] = 21;
        this.RuleString[492] = "New Trooptype Graphics System 0=no, 1=yes";
        if (!namesonly)
          this.RuleVar[492] = 0.0f;
        this.RuleGroup[492] = 21;
        this.RuleString[493] = "Allow partial-troop attacks (who can move in) 0=no, 1=yes";
        if (!namesonly)
          this.RuleVar[493] = 0.0f;
        this.RuleGroup[493] = 21;
        this.RuleString[494] = "Snow entrenchment modifier  (0= dont use , 50=half, 100=norm, 200=double). default=50";
        if (!namesonly)
          this.RuleVar[494] = 0.0f;
        this.RuleGroup[494] = 21;
        this.RuleString[495] = "Icy + slippery. For offroad and road. Increase AP cost per height lvl (0=nothing,50=50%) default=100";
        if (!namesonly)
          this.RuleVar[495] = 0.0f;
        this.RuleGroup[495] = 21;
        this.RuleString[496] = "NOT YET USED. Snowy roads not yet cleaned (0=nothing, 25=+25% , 50=+50%) default=+100 ";
        if (!namesonly)
          this.RuleVar[496] = 0.0f;
        this.RuleGroup[496] = 21;
        this.RuleString[497] = "Extra Morale impact based on power point loss and kill ratio of Unit…. 1dX …. Base = 6";
        if (!namesonly)
          this.RuleVar[497] = 0.0f;
        this.RuleGroup[497] = 21;
        this.RuleString[498] = "NOT YET USED. If enemy opposite when constructing bridge.. how much % it fails (0=none) default=50";
        if (!namesonly)
          this.RuleVar[498] = 0.0f;
        this.RuleGroup[498] = 21;
        this.RuleString[499] = "Supply Log Stringlist ID";
        if (!namesonly)
          this.RuleVar[499] = 0.0f;
        this.RuleGroup[499] = 21;
        this.RuleString[399] = "Vigor rules. 0=off , >0 is the number of points recovered for no move/no attack (15)";
        if (!namesonly)
          this.RuleVar[399] = 0.0f;
        this.RuleGroup[399] = 21;
        this.RuleString[398] = "Vigor reduction in points if did move/attack (5)";
        if (!namesonly)
          this.RuleVar[398] = 0.0f;
        this.RuleGroup[398] = 21;
        this.RuleString[397] = "Vigor rules. Loss of 1/1000th vigor per casualty % point";
        if (!namesonly)
          this.RuleVar[397] = 0.0f;
        this.RuleGroup[397] = 21;
        this.RuleString[396] = "Vigor rules. Maximum vigor loss per power point. (to avoid very small units excessive vigor loss)";
        if (!namesonly)
          this.RuleVar[396] = 0.0f;
        this.RuleGroup[396] = 21;
        this.RuleString[393] = "The turn after the night turn? 1=yes, 0=no";
        if (!namesonly)
          this.RuleVar[393] = 0.0f;
        this.RuleGroup[393] = 21;
        this.RuleString[439] = "Simple Supply Need Rules: Lowest reduced consumption ration allowed in % (25=always triest at least 25% of full consumption)";
        if (!namesonly)
          this.RuleVar[439] = 0.0f;
        this.RuleGroup[439] = 21;
        this.RuleString[455] = "Fuzzy Ownership: Hide normal Hex owner, use alternative indication for others. 0=off, 1=on";
        if (!namesonly)
          this.RuleVar[455] = 0.0f;
        this.RuleGroup[455] = 21;
        this.RuleString[456] = "Fuzzy Ownership: Are Blocked Markers visible? 0=no never, 1=on road/bridge, 2=on all hexes ";
        if (!namesonly)
          this.RuleVar[456] = 0.0f;
        this.RuleGroup[456] = 21;
        this.RuleString[458] = "Wider order bar buttons. 0=no, >0 = extra width ";
        if (!namesonly)
          this.RuleVar[458] = 0.0f;
        this.RuleGroup[458] = 21;
        this.RuleString[459] = "Use Road Traffic Points Rules 0=no, 1=yes ";
        if (!namesonly)
          this.RuleVar[459] = 0.0f;
        this.RuleGroup[459] = 21;
        this.RuleString[460] = "Use Bigger Info Window for Trooptypes 0=no, 1=yes ";
        if (!namesonly)
          this.RuleVar[460] = 0.0f;
        this.RuleGroup[460] = 21;
        this.RuleString[461] = "High HQs are Static, also OOB-wise, 0=no, 1=yes";
        if (!namesonly)
          this.RuleVar[461] = 0.0f;
        this.RuleGroup[461] = 21;
        this.RuleString[462] = "Supply Base System Active, 0=no, 1=yes  ";
        if (!namesonly)
          this.RuleVar[462] = 0.0f;
        this.RuleGroup[462] = 21;
        this.RuleString[463] = "Supply Base Supply Capture Percentage, 0=none, 50=half, 100=all ";
        if (!namesonly)
          this.RuleVar[463] = 0.0f;
        this.RuleGroup[463] = 21;
        this.RuleString[464] = "Movement Type that uses towing rules. 0=none ... >= 100 uses these rules. 100=movement type 0, 101=movtype 1, etc..";
        if (!namesonly)
          this.RuleVar[464] = 0.0f;
        this.RuleGroup[464] = 21;
      }
      this.RuleString[950] = "GUI: Run event for extra message generation when surrender is triggered for current player. (0=no, >0 event nr) ";
      if (!namesonly)
        this.RuleVar[950] = 0.0f;
      this.RuleGroup[950] = 14;
      this.RuleString[701] = "New Left/Right Click movement 0/1. ";
      if (!namesonly)
        this.RuleVar[701] = 0.0f;
      this.RuleGroup[701] = 22;
      this.RuleString[702] = "LIS: Infra setup. 0=no, >0=event Nr ";
      if (!namesonly)
        this.RuleVar[702] = 0.0f;
      this.RuleGroup[702] = 22;
      this.RuleString[703] = "LIS: Infra feedback. 0=no, >0=event Nr ";
      if (!namesonly)
        this.RuleVar[703] = 0.0f;
      this.RuleGroup[703] = 22;
      this.RuleString[704] = "LIS: Infra execute. 0=no, >0=event Nr ";
      if (!namesonly)
        this.RuleVar[704] = 0.0f;
      this.RuleGroup[704] = 22;
      this.RuleString[705] = "LIS: Infra select order. 0=no, >0=event Nr ";
      if (!namesonly)
        this.RuleVar[705] = 0.0f;
      this.RuleGroup[705] = 22;
      this.RuleString[440] = "UDS: Bottom Page UDS active. 0/1. 1=it will use the extraTab system to call eventNr's and get name for tab. ";
      if (!namesonly)
        this.RuleVar[440] = 0.0f;
      this.RuleGroup[440] = 22;
      this.RuleString[441] = "UDS: Management Tab pages Stringlist ID ";
      if (!namesonly)
        this.RuleVar[441] = 0.0f;
      this.RuleGroup[441] = 22;
      this.RuleString[442] = "Random Screen Event# (0>0 means Random Screen will be activated) ";
      if (!namesonly)
        this.RuleVar[442] = 0.0f;
      this.RuleGroup[442] = 22;
      this.RuleString[443] = "Randomscreen Tab pages stringlist ID# ";
      if (!namesonly)
        this.RuleVar[443] = 0.0f;
      this.RuleGroup[443] = 22;
      this.RuleString[444] = "Randomscreen Map Tab (0=no map shown, 1=yes show the map)";
      if (!namesonly)
        this.RuleVar[444] = 0.0f;
      this.RuleGroup[444] = 22;
      this.RuleString[446] = "Dynamic Sound System turned on (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[446] = 0.0f;
      this.RuleGroup[446] = 22;
      this.RuleString[447] = "Dynamic Tracks stringlist ID (<=0 = none)";
      if (!namesonly)
        this.RuleVar[447] = 0.0f;
      this.RuleGroup[447] = 22;
      this.RuleString[448] = "Mix Points stringlist ID (<=0 = none)";
      if (!namesonly)
        this.RuleVar[448] = 0.0f;
      this.RuleGroup[448] = 22;
      this.RuleString[449] = "Highlights stringlist ID (<=0 = none)";
      if (!namesonly)
        this.RuleVar[449] = 0.0f;
      this.RuleGroup[449] = 22;
      this.RuleString[450] = "UDS: Small Right Bottom UDS window ";
      if (!namesonly)
        this.RuleVar[450] = 0.0f;
      this.RuleGroup[450] = 22;
      this.RuleString[401] = "GUI: Show Zone Boundaries on Map. (0=no, 1=yes), (needs setting of groupname 742,743 as well to read zone numbers) ";
      if (!namesonly)
        this.RuleVar[401] = 0.0f;
      this.RuleGroup[401] = 22;
      this.RuleString[402] = "Use event# for set units ready. 0=no, >0 = event slot called by each unit ";
      if (!namesonly)
        this.RuleVar[402] = 0.0f;
      this.RuleGroup[402] = 22;
      this.RuleString[403] = "Enable LIS systems 0/1. ";
      if (!namesonly)
        this.RuleVar[403] = 0.0f;
      this.RuleGroup[403] = 22;
      this.RuleString[404] = "LIS systems: Stringlist ID for items stringlist ";
      if (!namesonly)
        this.RuleVar[404] = 0.0f;
      this.RuleGroup[404] = 22;
      this.RuleString[405] = "LIS systems: Stringlist ID for transport mode stringlist ";
      if (!namesonly)
        this.RuleVar[405] = 0.0f;
      this.RuleGroup[405] = 22;
      this.RuleString[406] = "LIS systems: Stringlist ID for location points and free AP ";
      if (!namesonly)
        this.RuleVar[406] = 0.0f;
      this.RuleGroup[406] = 22;
      this.RuleString[407] = "LIS systems: Stringlist ID for SFType requests and uses ";
      if (!namesonly)
        this.RuleVar[407] = 0.0f;
      this.RuleGroup[407] = 22;
      this.RuleString[408] = "UDS Order Bar Active. 0=no, >0 = event number to call ";
      if (!namesonly)
        this.RuleVar[408] = 0.0f;
      this.RuleGroup[408] = 22;
      this.RuleString[412] = "LIS systems: Stringlist ID for SFType - RegimeId quality levels ";
      if (!namesonly)
        this.RuleVar[412] = 0.0f;
      this.RuleGroup[412] = 22;
      this.RuleString[413] = "Regime sprites: use composite sprite system? 1=yes, 0=no ";
      if (!namesonly)
        this.RuleVar[413] = 0.0f;
      this.RuleGroup[413] = 22;
      this.RuleString[414] = "SFType Illustrations: use composite SFType var sprite system? 0=no, >0 = stringlist ID ";
      if (!namesonly)
        this.RuleVar[414] = 0.0f;
      this.RuleGroup[414] = 22;
      this.RuleString[409] = "UDS Order Bar Stringlist ";
      if (!namesonly)
        this.RuleVar[409] = 0.0f;
      this.RuleGroup[409] = 22;
      this.RuleString[410] = "UDS Unit Tab. 0=no >0 = event number to call ";
      if (!namesonly)
        this.RuleVar[410] = 0.0f;
      this.RuleGroup[410] = 22;
      this.RuleString[411] = "Stringlist ID info to be shown in top bar. Col 0 = Regime Slot, Col 1= 'name specified in  ";
      if (!namesonly)
        this.RuleVar[411] = 0.0f;
      this.RuleGroup[411] = 22;
      this.RuleString[445] = "DEBUG: Turn on profiling of events, execs and checks (0=no, 1=yes) ";
      if (!namesonly)
        this.RuleVar[445] = 0.0f;
      this.RuleGroup[445] = 12;
      this.RuleString[978] = "GUI/Logic: On surrender make this the last round the player saw(0) or make the game continue (1)";
      if (!namesonly)
        this.RuleVar[978] = 0.0f;
      this.RuleGroup[978] = 14;
      this.RuleString[983] = "GUI/Logic: FRONT ZONES : Use 'front zones' matrix. 0=no, 1=use. ";
      if (!namesonly)
        this.RuleVar[983] = 0.0f;
      this.RuleGroup[983] = 14;
      this.RuleString[984] = "GUI/Logic: FRONT ZONES : Frontzone check is done with historical unit Type HQ (5-9): (set to <5 to use groupnames 723,724 and 725) ";
      if (!namesonly)
        this.RuleVar[984] = 0.0f;
      this.RuleGroup[984] = 14;
      this.RuleString[951] = "GUI: Use a stringlist ID for encyclopedia mouse over (col0=search txt,col1=title,col2=txt) (0=no) ";
      if (!namesonly)
        this.RuleVar[951] = 0.0f;
      this.RuleGroup[951] = 14;
      this.RuleString[952] = "Disable Air Attack Attack (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[952] = 0.0f;
      this.RuleGroup[952] = 12;
      this.RuleString[953] = "Disable Artilley (0=no, 1=yes)";
      if (!namesonly)
        this.RuleVar[953] = 0.0f;
      this.RuleGroup[953] = 12;
      this.RuleString[954] = "Group move type (0=default same his.unit, 1=same hex of origin)";
      if (!namesonly)
        this.RuleVar[954] = 0.0f;
      this.RuleGroup[954] = 12;
      this.RuleString[955] = "Combat Logging. Battles stringlist ID# (<=0 not enabled) ";
      if (!namesonly)
        this.RuleVar[955] = 0.0f;
      this.RuleGroup[955] = 9;
      this.RuleString[956] = "Combat Logging. Historical Units stringlist ID# (<=0 not enabled) ";
      if (!namesonly)
        this.RuleVar[956] = 0.0f;
      this.RuleGroup[956] = 9;
      this.RuleString[957] = "Stringlist statistics. Use stringlist ID# (<=0 not enabled) ";
      if (!namesonly)
        this.RuleVar[957] = 0.0f;
      this.RuleGroup[957] = 13;
      this.RuleString[966] = "DEBUG: Use event-per-event debugging mode (old style) ? 0=no, 1=yes ";
      if (!namesonly)
        this.RuleVar[966] = 0.0f;
      this.RuleGroup[966] = 12;
    }

    pub void SetDefaultTempStrings()
    {
      int stringCounter = this.StringCounter;
      for (int index = 0; index <= stringCounter; index += 1)
        this.TempString[index] = "";
    }

    pub DataClass Clone()
    {
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      MemoryStream serializationStream = MemoryStream::new();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (DataClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    pub int FindUnit(ref UnitClass uni, string libName)
    {
      int unitCounter = this.UnitCounter;
      for (int unit = 0; unit <= unitCounter; unit += 1)
      {
        if (this.UnitObj[unit].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.UnitObj[unit].LibId.libSlot].name, libName, false) == 0 && this.UnitObj[unit].LibId.id == uni.PreDef)
          return unit;
      }
      return -1;
    }

    pub int FindPredef(int id)
    {
      int unitCounter = this.UnitCounter;
      for (int predef = 0; predef <= unitCounter; predef += 1)
      {
        if (this.UnitObj[predef].PreDef == id)
          return predef;
      }
      return -1;
    }

    pub int AddUnit(int x, int y, int map)
    {
      this += 1.UnitCounter;
      this += 1.AIUnitCounter;
      this.UnitObj = (UnitClass[]) Utils.CopyArray((Array) this.UnitObj, (Array) new UnitClass[this.UnitCounter + 1]);
      this.UnitObj[this.UnitCounter] = new UnitClass(0);
      this.UnitObj[this.UnitCounter].AIid = this.AIUnitCounter;
      if (x > -1)
      {
        this.UnitObj[this.UnitCounter].X = x;
        this.UnitObj[this.UnitCounter].Y = y;
        this.UnitObj[this.UnitCounter].Map = map;
      }
      this.UnitObj[this.UnitCounter].LoadSprites();
      if (x > -1)
        this.MapObj[map].HexObj[x, y].AddUnitToList(this.UnitCounter);
      return this.UnitCounter;
    }

    pub void RemoveUnit(int nr, ref let mut tgame: GameClass = null, bool deleteRegimeMod = false)
    {
      if (this.UnitObj[nr].X > -1 & !Information.IsNothing((object) tgame))
        tgame.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(this.UnitObj[nr].X, this.UnitObj[nr].Y, this.UnitObj[nr].Map, -1, -1, -1, this.UnitObj[nr].Regime, nr);
      int x = this.UnitObj[nr].X;
      int y = this.UnitObj[nr].Y;
      int map = this.UnitObj[nr].Map;
      if (this.UnitObj[nr].Historical > -1 && !this.HistoricalUnitObj[this.UnitObj[nr].Historical].Pool && Strings.Len(this.HistoricalUnitObj[this.UnitObj[nr].Historical].CommanderName) > 0)
      {
        if (this.HistoricalUnitObj[this.UnitObj[nr].Historical].PP < 0)
        {
          if (this.RegimeObj[this.UnitObj[nr].Regime].UberRegime > -1)
          {
            RegimeClass[] regimeObj = this.RegimeObj;
            RegimeClass[] regimeClassArray = regimeObj;
            int uberRegime = this.RegimeObj[this.UnitObj[nr].Regime].UberRegime;
            int index = uberRegime;
            regimeClassArray[index].ResPts = regimeObj[uberRegime].ResPts + this.HistoricalUnitObj[this.UnitObj[nr].Historical].PP;
          }
          else
          {
            RegimeClass[] regimeObj = this.RegimeObj;
            RegimeClass[] regimeClassArray = regimeObj;
            int regime = this.UnitObj[nr].Regime;
            int index = regime;
            regimeClassArray[index].ResPts = regimeObj[regime].ResPts + this.HistoricalUnitObj[this.UnitObj[nr].Historical].PP;
          }
        }
        this.HistoricalUnitObj[this.UnitObj[nr].Historical].Pool = true;
        this.HistoricalUnitObj[this.UnitObj[nr].Historical].TempRegime = this.UnitObj[nr].Regime;
        if (this.RegimeObj[this.UnitObj[nr].Regime].UberRegime > -1)
          this.HistoricalUnitObj[this.UnitObj[nr].Historical].TempRegime = this.RegimeObj[this.UnitObj[nr].Regime].UberRegime;
      }
      if (this.UnitObj[nr].SFCount > -1)
      {
        for (int sfCount = this.UnitObj[nr].SFCount; sfCount >= 0; sfCount += -1)
          this.RemoveSF(this.UnitObj[nr].SFList[sfCount]);
      }
      this.UnitObj[nr].Kill();
      this.ChangeUnitNr(nr, -1, ref tgame, false, deleteRegimeMod);
      if (nr < this.UnitCounter)
      {
        int num1 = nr;
        int num2 = this.UnitCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.UnitObj[Newnr] = this.UnitObj[Newnr + 1];
          this.ChangeUnitNr(Newnr + 1, Newnr, ref tgame, false, deleteRegimeMod);
        }
      }
      --this.UnitCounter;
      if (this.UnitCounter < -1)
        this.UnitCounter = -1;
      if (this.UnitCounter == -1)
        return;
      this.UnitObj = (UnitClass[]) Utils.CopyArray((Array) this.UnitObj, (Array) new UnitClass[this.UnitCounter + 1]);
    }

    pub void ChangeUnitNr(
      int Oldnr,
      int Newnr,
      ref GameClass tgame,
      bool skipmap,
      bool DeleteRegimeMode = false)
    {
      if (!Information.IsNothing((object) tgame))
      {
        if (tgame.EditObj.UnitSelected > -1 && Oldnr == tgame.EditObj.UnitSelected)
          tgame.EditObj.UnitSelected = Newnr;
        if (tgame.EditObj.OrderUnit > -1 && Oldnr == tgame.EditObj.OrderUnit)
          tgame.EditObj.OrderUnit = Newnr;
        if (tgame.EditObj.OldUnit > -1 && Oldnr == tgame.EditObj.OldUnit)
          tgame.EditObj.OldUnit = Newnr;
        if (tgame.EditObj.se1_CardsCategory == 3 | tgame.EditObj.se1_CardsCategory == 5 && tgame.EditObj.se1_CardsTarget > -1 && Oldnr == tgame.EditObj.se1_CardsTarget)
          tgame.EditObj.se1_CardsTarget = Newnr;
      }
      if (this.UnitObj[Oldnr].PreDef > -1 & Newnr == -1)
      {
        int historicalUnitCounter = this.HistoricalUnitCounter;
        for (int index1 = 0; index1 <= historicalUnitCounter; index1 += 1)
        {
          int index2 = 0;
          do
          {
            if (this.HistoricalUnitObj[index1].SubParts[index2] == this.UnitObj[Oldnr].PreDef)
              this.HistoricalUnitObj[index1].SubParts[index2] = -1;
            index2 += 1;
          }
          while (index2 <= 9);
        }
      }
      if (!skipmap)
      {
        int mapCounter = this.MapCounter;
        for (int index3 = 0; index3 <= mapCounter; index3 += 1)
        {
          int mapWidth = this.MapObj[index3].MapWidth;
          for (int index4 = 0; index4 <= mapWidth; index4 += 1)
          {
            int mapHeight = this.MapObj[index3].MapHeight;
            for (int index5 = 0; index5 <= mapHeight; index5 += 1)
            {
              if (index4 > -1 & index5 > -1 & index3 > -1 && this.MapObj[index3].HexObj[index4, index5].UnitCounter > -1)
              {
                int unitCounter = this.MapObj[index3].HexObj[index4, index5].UnitCounter;
                for (int index6 = 0; index6 <= unitCounter; index6 += 1)
                {
                  if (this.MapObj[index3].HexObj[index4, index5].UnitList[index6] == Oldnr)
                  {
                    if (Newnr == -1)
                    {
                      this.MapObj[index3].HexObj[index4, index5].RemoveUnitFromList(Oldnr);
                      break;
                    }
                    this.MapObj[index3].HexObj[index4, index5].UnitList[index6] = Newnr;
                    break;
                  }
                }
              }
            }
          }
        }
      }
      int unitCounter1 = this.UnitCounter;
      for (int index7 = 0; index7 <= unitCounter1; index7 += 1)
      {
        if (this.UnitObj[index7].HQ == Oldnr)
          this.UnitObj[index7].HQ = Newnr;
        if (this.UnitObj[index7].TempCapHQ == Oldnr)
          this.UnitObj[index7].TempCapHQ = Newnr;
        if (this.UnitObj[index7].OnBoard == Oldnr)
          this.UnitObj[index7].OnBoard = Newnr;
        if (this.UnitObj[index7].PassengerCounter > -1)
        {
          int passengerCounter = this.UnitObj[index7].PassengerCounter;
          for (int index8 = 0; index8 <= passengerCounter; index8 += 1)
          {
            if (this.UnitObj[index7].PassengerList[index8] == Oldnr)
            {
              if (Newnr == -1)
                this.UnitObj[index7].RemovePassenger(Oldnr);
              else
                this.UnitObj[index7].PassengerList[index8] = Newnr;
            }
          }
        }
        if (this.UnitObj[index7].attachedTo == Oldnr)
          this.UnitObj[index7].attachedTo = Newnr;
        if (this.UnitObj[index7].TransportCounter > -1)
        {
          int transportCounter = this.UnitObj[index7].TransportCounter;
          for (int index9 = 0; index9 <= transportCounter; index9 += 1)
          {
            if (this.UnitObj[index7].TransportList[index9] == Oldnr)
            {
              if (Newnr == -1)
                this.UnitObj[index7].RemoveTransport(Oldnr);
              else
                this.UnitObj[index7].TransportList[index9] = Newnr;
            }
          }
        }
        if (!Information.IsNothing((object) this.UnitObj[index7].AIPlanRef) && this.UnitObj[index7].AIPlanRef.HQ == Oldnr)
          this.UnitObj[index7].AIPlanRef.HQ = Newnr;
      }
      if (!DeleteRegimeMode && !Information.IsNothing((object) tgame))
      {
        if (!Information.IsNothing((object) tgame.AIObj))
        {
          int tplanCount = tgame.AIObj.TPlanCount;
          for (int index = 0; index <= tplanCount; index += 1)
          {
            if (!Information.IsNothing((object) tgame.AIObj.TPlanObj[index]) && tgame.AIObj.TPlanObj[index].HQ == Oldnr)
              tgame.AIObj.TPlanObj[index].HQ = Newnr;
          }
        }
        if (tgame.Data.UseAI == 1)
        {
          int index = 1;
          do
          {
            if (tgame.NewAIObj.MoveMatrixUnit[index] == Oldnr)
              tgame.NewAIObj.MoveMatrixUnit[index] = Newnr;
            if (tgame.NewAIObj.EnemyMatrixUnit[index] == Oldnr)
              tgame.NewAIObj.EnemyMatrixUnit[index] = Newnr;
            index += 1;
          }
          while (index <= 90);
        }
      }
      int locCounter = this.LocCounter;
      for (int index = 0; index <= locCounter; index += 1)
      {
        if (this.LocObj[index].HQ == Oldnr)
          this.LocObj[index].HQ = Newnr;
      }
    }

    pub int AddSF(int unr)
    {
      this += 1.SFCounter;
      this.SFObj = (SFClass[]) Utils.CopyArray((Array) this.SFObj, (Array) new SFClass[this.SFCounter + 1]);
      this.SFObj[this.SFCounter] = new SFClass(0);
      this.SFObj[this.SFCounter].LoadSprites();
      this.UnitObj[unr].AddSF(this.SFCounter);
      return this.SFCounter;
    }

    pub void RemoveSF(int nr)
    {
      this.SFObj[nr].Kill();
      this.ChangeSFNr(nr, -1);
      if (nr < this.SFCounter)
      {
        int num1 = nr;
        int num2 = this.SFCounter - 1;
        for (int index = num1; index <= num2; index += 1)
          this.SFObj[index] = this.SFObj[index + 1];
        this.MassChangeSFNr(nr + 1);
      }
      --this.SFCounter;
      if (this.SFCounter == -1)
        return;
      this.SFObj = (SFClass[]) Utils.CopyArray((Array) this.SFObj, (Array) new SFClass[this.SFCounter + 1]);
    }

    pub void MassChangeSFNr(int FromNr)
    {
      if (this.UnitCounter <= -1)
        return;
      int unitCounter = this.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; index1 += 1)
      {
        if (this.UnitObj[index1].SFCount > -1)
        {
          int sfCount = this.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; index2 += 1)
          {
            if (this.UnitObj[index1].SFList[index2] >= FromNr)
              this.UnitObj[index1].SFList[index2] = this.UnitObj[index1].SFList[index2] - 1;
          }
        }
      }
    }

    pub void ChangeSFNr(int Oldnr, int Newnr)
    {
      if (this.UnitCounter <= -1)
        return;
      int unitCounter = this.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; index1 += 1)
      {
        if (this.UnitObj[index1].SFCount > -1)
        {
          int sfCount = this.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; index2 += 1)
          {
            if (this.UnitObj[index1].SFList[index2] == Oldnr)
            {
              if (Newnr == -1)
              {
                this.UnitObj[index1].RemoveSF(Oldnr);
                return;
              }
              this.UnitObj[index1].SFList[index2] = Newnr;
              return;
            }
          }
        }
      }
    }

    pub int FindSFType(ref SFTypeClass sft, string libName, bool thisIsHistoricalImport = false)
    {
      int sfTypeCounter = this.SFTypeCounter;
      for (int sfType = 0; sfType <= sfTypeCounter; sfType += 1)
      {
        if (this.SFTypeObj[sfType].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.SFTypeObj[sfType].LibId.libSlot].name, libName, false) == 0)
        {
          if (thisIsHistoricalImport)
          {
            if (this.SFTypeObj[sfType].LibId.id == sft.LibId.id)
              return sfType;
          }
          else if (this.SFTypeObj[sfType].LibId.id == sft.Id | this.SFTypeObj[sfType].LibId.id == sft.LibId.id)
            return sfType;
        }
      }
      return -1;
    }

    pub int FindSFType(string libName, int libId)
    {
      int sfTypeCounter = this.SFTypeCounter;
      for (int sfType = 0; sfType <= sfTypeCounter; sfType += 1)
      {
        if (this.SFTypeObj[sfType].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.SFTypeObj[sfType].LibId.libSlot].name, libName, false) == 0 && this.SFTypeObj[sfType].LibId.id == libId)
          return sfType;
      }
      return -1;
    }

    pub int FindSFTypeAlien(string libName, int libId, int buildGround)
    {
      int num = -1;
      SimpleList simpleList = SimpleList::new();
      int sfTypeCounter = this.SFTypeCounter;
      for (int tid = 0; tid <= sfTypeCounter; tid += 1)
      {
        if (this.SFTypeObj[tid].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.SFTypeObj[tid].LibId.libSlot].name, libName, false) == 0 && this.SFTypeObj[tid].LibId.id == libId)
        {
          num = tid;
          if (this.SFTypeObj[tid].SFTypeVar[7] == buildGround | buildGround < 1)
            simpleList.AddWeight(tid, 10000);
          else
            simpleList.AddWeight(tid, 10);
        }
      }
      if (simpleList.Counter > -1)
        return simpleList.GetRandomIdbasedOnWeight();
      return num > -1 ? num : -1;
    }

    pub void AddSFType(bool temporary = false)
    {
      this += 1.SFTypeCounter;
      this.SFTypeObj = (SFTypeClass[]) Utils.CopyArray((Array) this.SFTypeObj, (Array) new SFTypeClass[this.SFTypeCounter + 1]);
      this.SFTypeObj[this.SFTypeCounter] = new SFTypeClass(0, this.LandscapeTypeCounter, this.ResearchCounter);
      this.SFTypeObj[this.SFTypeCounter].LoadSprites();
      if (this.Round > 0 & !temporary)
      {
        object[,] objArray1 = new object[this.SFTypeCounter + 1, this.Round + 1 + 1];
        object[,] objArray2 = new object[this.SFTypeCounter + 1, this.Round + 1 + 1];
        object[,] objArray3 = new object[this.SFTypeCounter + 1, this.Round + 1 + 1];
        object[] objArray4 = new object[this.SFTypeCounter + 1];
        int regimeCounter = this.RegimeCounter;
        for (int index1 = 0; index1 <= regimeCounter; index1 += 1)
        {
          int upperBound = this.RegimeObj[index1].SKills.GetUpperBound(0);
          for (int index2 = 0; index2 <= upperBound; index2 += 1)
          {
            int num = this.Round + 1;
            for (int index3 = 0; index3 <= num; index3 += 1)
            {
              objArray1[index2, index3] = (object) this.RegimeObj[index1].SKills[index2, index3];
              objArray2[index2, index3] = (object) this.RegimeObj[index1].SLoss[index2, index3];
              objArray3[index2, index3] = (object) this.RegimeObj[index1].SPresent[index2, index3];
            }
            objArray4[index2] = (object) this.RegimeObj[index1].SASKilled[index2];
          }
          this.RegimeObj[index1].SKills = new int[this.SFTypeCounter + 1, this.Round + 1 + 1];
          this.RegimeObj[index1].SLoss = new int[this.SFTypeCounter + 1, this.Round + 1 + 1];
          this.RegimeObj[index1].SPresent = new int[this.SFTypeCounter + 1, this.Round + 1 + 1];
          this.RegimeObj[index1].SASKilled = new int[this.SFTypeCounter + 1];
          int num1 = this.SFTypeCounter - 1;
          for (int index4 = 0; index4 <= num1; index4 += 1)
          {
            int num2 = this.Round + 1;
            for (int index5 = 0; index5 <= num2; index5 += 1)
            {
              this.RegimeObj[index1].SKills[index4, index5] = Conversions.ToInteger(objArray1[index4, index5]);
              this.RegimeObj[index1].SLoss[index4, index5] = Conversions.ToInteger(objArray2[index4, index5]);
              this.RegimeObj[index1].SPresent[index4, index5] = Conversions.ToInteger(objArray3[index4, index5]);
            }
            this.RegimeObj[index1].SASKilled[index4] = Conversions.ToInteger(objArray4[index4]);
          }
        }
      }
      int sfTypeCounter = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; index += 1)
      {
        if (this.SFTypeObj[index].Id >= this.SFTypeIdCounter)
          this.SFTypeIdCounter = this.SFTypeObj[index].Id;
      }
      this += 1.SFTypeIdCounter;
      this.SFTypeObj[this.SFTypeCounter].Id = this.SFTypeIdCounter;
    }

    pub void RemoveSFType(int nr)
    {
      this.SFTypeObj[nr].Kill();
      this.ChangeSFTypeNr(nr, -1);
      if (nr < this.SFTypeCounter)
      {
        int num1 = nr;
        int num2 = this.SFTypeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.SFTypeObj[Newnr] = this.SFTypeObj[Newnr + 1];
          this.ChangeSFTypeNr(Newnr + 1, Newnr);
        }
      }
      --this.SFTypeCounter;
      if (this.SFTypeCounter == -1)
        return;
      this.SFTypeObj = (SFTypeClass[]) Utils.CopyArray((Array) this.SFTypeObj, (Array) new SFTypeClass[this.SFTypeCounter + 1]);
    }

    pub void ChangeSFTypeNr(int Oldnr, int Newnr)
    {
      int stringListCounter = this.StringListCounter;
      int nr;
      for (int index1 = 0; index1 <= stringListCounter; index1 += 1)
      {
        int width = this.StringListObj[index1].Width;
        for (int index2 = 0; index2 <= width; index2 += 1)
        {
          int length = this.StringListObj[index1].Length;
          for (int index3 = 0; index3 <= length; index3 += 1)
          {
            if (this.StringListObj[index1].ColValueType[index2] == NewEnums.LibVarValueType.SFTypeId && this.StringListObj[index1].Data[index3, index2].Length > 0)
            {
              nr =  Math.Round(Conversion.Val(this.StringListObj[index1].Data[index3, index2]));
              if (nr == Oldnr)
                nr = Newnr;
              this.StringListObj[index1].Data[index3, index2] = nr.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.SFtype & this.LibVarObj[libVarCounter].instanceId.id == this.SFTypeObj[Oldnr].LibId.id & this.LibVarObj[libVarCounter].instanceId.libSlot == this.SFTypeObj[Oldnr].LibId.libSlot)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.SFTypeId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      for (nr = this.SFCounter; nr >= 0; nr += -1)
      {
        if (this.SFObj[nr].Type == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveSF(nr);
          else
            this.SFObj[nr].Type = Newnr;
        }
      }
      for (nr = this.ResearchCounter; nr >= 0; nr += -1)
      {
        if (this.ResearchObj[nr].SFTypePic == Oldnr)
          this.ResearchObj[nr].SFTypePic = Newnr;
      }
      for (nr = this.ItemTypeCounter; nr >= 0; nr += -1)
      {
        if (this.ItemTypeObj[nr].IsSFType == Oldnr)
          this.ItemTypeObj[nr].IsSFType = Newnr;
      }
      for (nr = this.SFTypeCounter; nr >= 0; nr += -1)
      {
        if (this.SFTypeObj[nr].CopyDataFrom == Oldnr)
          this.SFTypeObj[nr].CopyDataFrom = Newnr;
      }
      for (nr = this.SFTypeCounter; nr >= 0; nr += -1)
      {
        if (this.SFTypeObj[nr].UpgradeToo == Oldnr)
          this.SFTypeObj[nr].UpgradeToo = Newnr;
        if (this.SFTypeObj[nr].ArtSFType == Oldnr)
          this.SFTypeObj[nr].ArtSFType = Newnr;
      }
    }

    pub void ThreadBlock()
    {
      if (!DrawMod.TGame.se1ThreadBlock)
        return;
      do
        ;
      while (DrawMod.TGame.se1ThreadBlock);
      DrawMod.TGame.se1ThreadBlock = true;
    }

    pub void ThreadRelease() => DrawMod.TGame.se1ThreadBlock = false;

    pub void AddLandscapeType()
    {
      this += 1.LandscapeTypeCounter;
      this.LandscapeTypeObj = (LandscapeTypeClass[]) Utils.CopyArray((Array) this.LandscapeTypeObj, (Array) new LandscapeTypeClass[this.LandscapeTypeCounter + 1]);
      this.LandscapeTypeObj[this.LandscapeTypeCounter] = new LandscapeTypeClass(0);
      this.LandscapeTypeObj[this.LandscapeTypeCounter].LoadSprites();
      int sfTypeCounter = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; index += 1)
      {
        this.SFTypeObj[index].CombatModAtt = (float[]) Utils.CopyArray((Array) this.SFTypeObj[index].CombatModAtt, (Array) new float[this.LandscapeTypeCounter + 1]);
        this.SFTypeObj[index].CombatModDef = (float[]) Utils.CopyArray((Array) this.SFTypeObj[index].CombatModDef, (Array) new float[this.LandscapeTypeCounter + 1]);
        this.SFTypeObj[index].ExtraRecon = (int[]) Utils.CopyArray((Array) this.SFTypeObj[index].ExtraRecon, (Array) new int[this.LandscapeTypeCounter + 1]);
        this.SFTypeObj[index].CombatModAtt[this.LandscapeTypeCounter] = 1f;
        this.SFTypeObj[index].CombatModDef[this.LandscapeTypeCounter] = 1f;
        this.SFTypeObj[index].ExtraRecon[this.LandscapeTypeCounter] = 0;
      }
    }

    pub void RemoveLandscapeType(int nr)
    {
      this.LandscapeTypeObj[nr].Kill();
      this.ChangeLandscapeNr(nr, -1);
      if (nr < this.LandscapeTypeCounter)
      {
        int num1 = nr;
        int num2 = this.LandscapeTypeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.LandscapeTypeObj[Newnr] = this.LandscapeTypeObj[Newnr + 1];
          this.ChangeLandscapeNr(Newnr + 1, Newnr);
        }
      }
      int sfTypeCounter1 = this.SFTypeCounter;
      for (int index1 = 0; index1 <= sfTypeCounter1; index1 += 1)
      {
        if (nr < this.LandscapeTypeCounter)
        {
          int num3 = nr;
          int num4 = this.LandscapeTypeCounter - 1;
          for (int index2 = num3; index2 <= num4; index2 += 1)
          {
            this.SFTypeObj[index1].CombatModAtt[index2] = this.SFTypeObj[index1].CombatModAtt[index2 + 1];
            this.SFTypeObj[index1].CombatModDef[index2] = this.SFTypeObj[index1].CombatModDef[index2 + 1];
            this.SFTypeObj[index1].ExtraRecon[index2] = this.SFTypeObj[index1].ExtraRecon[index2 + 1];
          }
        }
      }
      --this.LandscapeTypeCounter;
      int sfTypeCounter2 = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter2; index += 1)
      {
        if (this.LandscapeTypeCounter > -1)
        {
          this.SFTypeObj[index].CombatModAtt = (float[]) Utils.CopyArray((Array) this.SFTypeObj[index].CombatModAtt, (Array) new float[this.LandscapeTypeCounter + 1]);
          this.SFTypeObj[index].CombatModDef = (float[]) Utils.CopyArray((Array) this.SFTypeObj[index].CombatModDef, (Array) new float[this.LandscapeTypeCounter + 1]);
          this.SFTypeObj[index].ExtraRecon = (int[]) Utils.CopyArray((Array) this.SFTypeObj[index].ExtraRecon, (Array) new int[this.LandscapeTypeCounter + 1]);
        }
      }
      if (this.LandscapeTypeCounter != -1)
        this.LandscapeTypeObj = (LandscapeTypeClass[]) Utils.CopyArray((Array) this.LandscapeTypeObj, (Array) new LandscapeTypeClass[this.LandscapeTypeCounter + 1]);
      int mapCounter = this.MapCounter;
      for (int index3 = 0; index3 <= mapCounter; index3 += 1)
      {
        int mapWidth = this.MapObj[index3].MapWidth;
        for (int index4 = 0; index4 <= mapWidth; index4 += 1)
        {
          int mapHeight = this.MapObj[index3].MapHeight;
          for (int index5 = 0; index5 <= mapHeight; index5 += 1)
          {
            if (this.MapObj[index3].HexObj[index4, index5].LandscapeType == -1)
              this.MapObj[index3].HexObj[index4, index5].LandscapeType = 0;
          }
        }
      }
    }

    pub void ChangeLandscapeNr(int Oldnr, int Newnr)
    {
      int stringListCounter = this.StringListCounter;
      int index1;
      for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
      {
        int width = this.StringListObj[index2].Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int length = this.StringListObj[index2].Length;
          for (int index4 = 0; index4 <= length; index4 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.LandscapeId && this.StringListObj[index2].Data[index4, index3].Length > 0)
            {
              index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
              if (index1 == Oldnr)
                index1 = Newnr;
              this.StringListObj[index2].Data[index4, index3] = index1.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.Landscape & this.LibVarObj[libVarCounter].instanceId.id == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.LandscapeId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      int mapCounter = this.MapCounter;
      for (int index5 = 0; index5 <= mapCounter; index5 += 1)
      {
        int mapWidth = this.MapObj[index5].MapWidth;
        for (int index6 = 0; index6 <= mapWidth; index6 += 1)
        {
          int mapHeight = this.MapObj[index5].MapHeight;
          for (int index7 = 0; index7 <= mapHeight; index7 += 1)
          {
            if (this.MapObj[index5].HexObj[index6, index7].LandscapeType == Oldnr)
            {
              this.MapObj[index5].HexObj[index6, index7].LandscapeType = Newnr;
              if (Newnr == -1)
                this.MapObj[index5].HexObj[index6, index7].SpriteNr = 0;
            }
            if (this.MapObj[index5].HexObj[index6, index7].SpecialType == Oldnr)
            {
              this.MapObj[index5].HexObj[index6, index7].SpecialType = Newnr;
              if (Newnr == -1)
                this.MapObj[index5].HexObj[index6, index7].SpecialSprite = 0;
            }
          }
        }
      }
      int locTypeCounter = this.LocTypeCounter;
      for (index1 = 0; index1 <= locTypeCounter; index1 += 1)
      {
        if (this.LocTypeObj[index1].OverdrawLTNr == Oldnr)
        {
          this.LocTypeObj[index1].OverdrawLTNr = Newnr;
          if (Newnr == -1)
            this.LocTypeObj[index1].OverdrawSpriteNr = 0;
        }
      }
      int landscapeTypeCounter1 = this.LandscapeTypeCounter;
      for (index1 = 0; index1 <= landscapeTypeCounter1; index1 += 1)
      {
        for (int overridesCount = this.LandscapeTypeObj[index1].OverridesCount; overridesCount >= 0; overridesCount += -1)
        {
          if (this.LandscapeTypeObj[index1].OverridesType[overridesCount] == Oldnr)
          {
            if (Newnr == -1)
              this.LandscapeTypeObj[index1].RemoveOverride(overridesCount);
            else
              this.LandscapeTypeObj[index1].OverridesType[overridesCount] = Newnr;
          }
        }
        for (int overridesCount2 = this.LandscapeTypeObj[index1].OverridesCount2; overridesCount2 >= 0; overridesCount2 += -1)
        {
          if (this.LandscapeTypeObj[index1].OverridesType2[overridesCount2] == Oldnr)
          {
            if (Newnr == -1)
              this.LandscapeTypeObj[index1].RemoveOverride2(overridesCount2);
            else
              this.LandscapeTypeObj[index1].OverridesType2[overridesCount2] = Newnr;
          }
        }
      }
      int landscapeTypeCounter2 = this.LandscapeTypeCounter;
      for (index1 = 0; index1 <= landscapeTypeCounter2; index1 += 1)
      {
        if (this.LandscapeTypeObj[index1].ExtraExterior == Oldnr)
          this.LandscapeTypeObj[index1].ExtraExterior = Newnr;
        if (this.LandscapeTypeObj[index1].OverridesCount > -1)
        {
          for (int overridesCount = this.LandscapeTypeObj[index1].OverridesCount; overridesCount >= 0; overridesCount += -1)
          {
            if (this.LandscapeTypeObj[index1].OverridesType[overridesCount] == Oldnr)
            {
              if (Newnr == -1)
                this.LandscapeTypeObj[index1].RemoveOverride(overridesCount);
              else
                this.LandscapeTypeObj[index1].OverridesType[overridesCount] = Newnr;
            }
          }
        }
      }
    }

    pub void RemoveLandscapeBasicSprite(int ltnr, int nr)
    {
      this.LandscapeTypeObj[ltnr].BasicSpriteFileName[nr] = "";
      this.LandscapeTypeObj[ltnr].BasicSpriteFileName2[nr] = "";
      this.LandscapeTypeObj[ltnr].BasicPicFileName[nr] = "";
      BitmapStore.RemoveBitmapNr(this.LandscapeTypeObj[ltnr].BasicSpriteID[nr]);
      BitmapStore.RemoveBitmapNr(this.LandscapeTypeObj[ltnr].BasicSpriteID2[nr]);
      BitmapStore.RemoveBitmapNr(this.LandscapeTypeObj[ltnr].BasicPicID[nr]);
      this.LandscapeTypeObj[ltnr].BasicSpriteID[nr] = -1;
      this.LandscapeTypeObj[ltnr].BasicPicID[nr] = -1;
      this.LandscapeTypeObj[ltnr].PlotLast[nr] = false;
      this.ChangeLandscapeSpriteNr(ltnr, nr, -1);
      if (nr < this.LandscapeTypeObj[ltnr].BasicSpriteCounter)
      {
        int num1 = nr;
        int num2 = this.LandscapeTypeObj[ltnr].BasicSpriteCounter - 1;
        for (int NewNr = num1; NewNr <= num2; NewNr += 1)
        {
          this.LandscapeTypeObj[ltnr].BasicSpriteFileName[NewNr] = this.LandscapeTypeObj[ltnr].BasicSpriteFileName[NewNr + 1];
          this.LandscapeTypeObj[ltnr].BasicSpriteFileName2[NewNr] = this.LandscapeTypeObj[ltnr].BasicSpriteFileName2[NewNr + 1];
          this.LandscapeTypeObj[ltnr].BasicSpriteID[NewNr] = this.LandscapeTypeObj[ltnr].BasicSpriteID[NewNr + 1];
          this.LandscapeTypeObj[ltnr].BasicSpriteID2[NewNr] = this.LandscapeTypeObj[ltnr].BasicSpriteID2[NewNr + 1];
          this.LandscapeTypeObj[ltnr].BasicPicFileName[NewNr] = this.LandscapeTypeObj[ltnr].BasicPicFileName[NewNr + 1];
          this.LandscapeTypeObj[ltnr].BasicPicID[NewNr] = this.LandscapeTypeObj[ltnr].BasicPicID[NewNr + 1];
          this.LandscapeTypeObj[ltnr].PlotLast[NewNr] = this.LandscapeTypeObj[ltnr].PlotLast[NewNr + 1];
          this.ChangeLandscapeSpriteNr(ltnr, NewNr + 1, NewNr);
        }
      }
      --this.LandscapeTypeObj[ltnr].BasicSpriteCounter;
      this.LandscapeTypeObj[ltnr].BasicSpriteFileName = (string[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].BasicSpriteFileName, (Array) new string[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
      this.LandscapeTypeObj[ltnr].BasicSpriteFileName2 = (string[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].BasicSpriteFileName2, (Array) new string[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
      this.LandscapeTypeObj[ltnr].BasicSpriteID = (int[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].BasicSpriteID, (Array) new int[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
      this.LandscapeTypeObj[ltnr].BasicSpriteID2 = (int[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].BasicSpriteID2, (Array) new int[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
      this.LandscapeTypeObj[ltnr].BasicPicFileName = (string[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].BasicPicFileName, (Array) new string[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
      this.LandscapeTypeObj[ltnr].BasicPicID = (int[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].BasicPicID, (Array) new int[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
      this.LandscapeTypeObj[ltnr].PlotLast = (bool[]) Utils.CopyArray((Array) this.LandscapeTypeObj[ltnr].PlotLast, (Array) new bool[this.LandscapeTypeObj[ltnr].BasicSpriteCounter + 1]);
    }

    pub void ChangeLandscapeSpriteNr(int LTnr, int OldNr, int NewNr)
    {
      int mapCounter = this.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; index1 += 1)
      {
        int mapWidth = this.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; index2 += 1)
        {
          int mapHeight = this.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; index3 += 1)
          {
            if (this.MapObj[index1].HexObj[index2, index3].LandscapeType == LTnr && this.MapObj[index1].HexObj[index2, index3].SpriteNr == OldNr)
              this.MapObj[index1].HexObj[index2, index3].SpriteNr = NewNr != -1 ? NewNr : 0;
            if (this.MapObj[index1].HexObj[index2, index3].SpecialType == LTnr && this.MapObj[index1].HexObj[index2, index3].SpecialSprite == OldNr)
              this.MapObj[index1].HexObj[index2, index3].SpecialSprite = NewNr != -1 ? NewNr : 0;
          }
        }
      }
      int locTypeCounter = this.LocTypeCounter;
      for (int index = 0; index <= locTypeCounter; index += 1)
      {
        if (this.LocTypeObj[index].OverdrawLTNr == LTnr & this.LocTypeObj[index].OverdrawSpriteNr == OldNr)
          this.LocTypeObj[index].OverdrawSpriteNr = NewNr != -1 ? NewNr : 0;
      }
    }

    pub int FindLibrary(string libName)
    {
      int libraryCounter = this.LibraryCounter;
      for (int library = 0; library <= libraryCounter; library += 1)
      {
        if (Operators.CompareString(this.LibraryObj[library].name, libName, false) == 0)
          return library;
      }
      return -1;
    }

    pub int FindLibraryLowCase(string libName)
    {
      libName = Strings.LCase(libName);
      int libraryCounter = this.LibraryCounter;
      for (int libraryLowCase = 0; libraryLowCase <= libraryCounter; libraryLowCase += 1)
      {
        if (Operators.CompareString(Strings.LCase(this.LibraryObj[libraryLowCase].name), libName, false) == 0)
          return libraryLowCase;
      }
      return -1;
    }

    pub void AddLibrary()
    {
      this += 1.LibraryCounter;
      this.LibraryObj = (LibraryClass[]) Utils.CopyArray((Array) this.LibraryObj, (Array) new LibraryClass[this.LibraryCounter + 1]);
      this.LibraryObj[this.LibraryCounter] = LibraryClass::new();
    }

    pub void RemoveLibrary(int nr)
    {
      this.ChangeLibraryNr(nr, -1);
      if (nr < this.LibraryCounter)
      {
        int num1 = nr;
        int num2 = this.LibraryCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.LibraryObj[Newnr] = this.LibraryObj[Newnr + 1];
          this.ChangeLibraryNr(Newnr + 1, Newnr);
        }
      }
      --this.LibraryCounter;
      if (this.LibraryCounter == -1)
        return;
      this.LibraryObj = (LibraryClass[]) Utils.CopyArray((Array) this.LibraryObj, (Array) new LibraryClass[this.LibraryCounter + 1]);
    }

    pub void ChangeLibraryNr(int Oldnr, int Newnr)
    {
      for (int historicalUnitCounter = this.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == Oldnr && Newnr == -1 && this.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot > -1 & this.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot != Oldnr)
        {
          this.AddHistoricalUnit();
          DrawMod.TGame.ProcessingObj.SwapOfficer(this.HistoricalUnitObj[historicalUnitCounter].TempRegime, historicalUnitCounter, this.HistoricalUnitCounter, -1);
          this.HistoricalUnitObj[this.HistoricalUnitCounter].LibId = this.HistoricalUnitObj[historicalUnitCounter].OffLibId.Clone();
        }
      }
      for (int historicalUnitCounter = this.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.HistoricalUnitObj[historicalUnitCounter].ModelMaster > -1 && this.HistoricalUnitObj[this.HistoricalUnitObj[historicalUnitCounter].ModelMaster].LibId.libSlot == Oldnr && Newnr == -1 && this.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot > -1 & this.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot != Oldnr)
        {
          this.AddHistoricalUnit();
          DrawMod.TGame.ProcessingObj.SwapOfficer(this.HistoricalUnitObj[historicalUnitCounter].TempRegime, historicalUnitCounter, this.HistoricalUnitCounter, -1);
          this.HistoricalUnitObj[this.HistoricalUnitCounter].LibId = this.HistoricalUnitObj[historicalUnitCounter].OffLibId.Clone();
        }
      }
      for (int historicalUnitCounter = this.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveHistoricalUnit(historicalUnitCounter);
          else
            this.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot = Newnr;
        }
      }
      for (int historicalUnitCounter = this.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
          {
            DrawMod.TGame.Data.AddHistoricalUnit();
            DrawMod.TGame.ProcessingObj.SwapOfficer(this.HistoricalUnitObj[historicalUnitCounter].TempRegime, historicalUnitCounter, DrawMod.TGame.Data.HistoricalUnitCounter, -1);
            DrawMod.TGame.Data.RemoveHistoricalUnit(DrawMod.TGame.Data.HistoricalUnitCounter);
          }
          else
            this.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot = Newnr;
        }
      }
      int mapWidth = this.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; index1 += 1)
      {
        int mapHeight = this.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; index2 += 1)
        {
          for (int hexLibVarCounter = this.MapObj[0].HexObj[index1, index2].HexLibVarCounter; hexLibVarCounter >= 0; hexLibVarCounter += -1)
          {
            if (this.MapObj[0].HexObj[index1, index2].HexLibVarSlotNr[hexLibVarCounter] == Oldnr)
            {
              if (Newnr == -1)
                this.MapObj[0].HexObj[index1, index2].RemoveHexLibVar(hexLibVarCounter);
              else
                this.MapObj[0].HexObj[index1, index2].HexLibVarSlotNr[hexLibVarCounter] = Newnr;
            }
          }
        }
      }
      for (int sfTypeCounter = this.SFTypeCounter; sfTypeCounter >= 0; sfTypeCounter += -1)
      {
        if (this.SFTypeObj[sfTypeCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveSFType(sfTypeCounter);
          else
            this.SFTypeObj[sfTypeCounter].LibId.libSlot = Newnr;
        }
      }
      for (int peopleCounter = this.PeopleCounter; peopleCounter >= 0; peopleCounter += -1)
      {
        if (this.PeopleObj[peopleCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemovePeople(peopleCounter);
          else
            this.PeopleObj[peopleCounter].LibId.libSlot = Newnr;
        }
      }
      for (int regimeCounter = this.RegimeCounter; regimeCounter >= 0; regimeCounter += -1)
      {
        if (this.RegimeObj[regimeCounter].libId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveRegime(regimeCounter);
          else
            this.RegimeObj[regimeCounter].libId.libSlot = Newnr;
        }
      }
      for (int eventCounter = this.EventCounter; eventCounter >= 0; eventCounter += -1)
      {
        if (this.EventObj[eventCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveEvent(eventCounter);
          else
            this.EventObj[eventCounter].LibId.libSlot = Newnr;
        }
      }
      for (int stringListCounter = this.StringListCounter; stringListCounter >= 0; stringListCounter += -1)
      {
        if (this.StringListObj[stringListCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveStringList(stringListCounter);
          else
            this.StringListObj[stringListCounter].LibId.libSlot = Newnr;
        }
      }
      for (int eventPicCounter = this.EventPicCounter; eventPicCounter >= 0; eventPicCounter += -1)
      {
        if (this.eventPicLibId[eventPicCounter].libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveEventPic(eventPicCounter);
          else
            this.eventPicLibId[eventPicCounter].libSlot = Newnr;
        }
      }
      for (int smallPicCounter = this.SmallPicCounter; smallPicCounter >= 0; smallPicCounter += -1)
      {
        if (this.SmallLibId[smallPicCounter].libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveSmallPic(smallPicCounter);
          else
            this.SmallLibId[smallPicCounter].libSlot = Newnr;
        }
      }
      for (int reinfCounter = this.ReinfCounter; reinfCounter >= 0; reinfCounter += -1)
      {
        if (this.ReinfLibId[reinfCounter].libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveReinf(reinfCounter);
          else
            this.ReinfLibId[reinfCounter].libSlot = Newnr;
        }
      }
      for (int actionCardCounter = this.ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
      {
        if (this.ActionCardObj[actionCardCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveActionCard(actionCardCounter);
          else
            this.ActionCardObj[actionCardCounter].LibId.libSlot = Newnr;
        }
      }
      for (int unitCounter = this.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.UnitObj[unitCounter].PreDef > -1 && this.UnitObj[unitCounter].LibId.libSlot == Oldnr)
        {
          if (Newnr == -1)
          {
            int nr = unitCounter;
            let mut gameClass: GameClass = (GameClass) null;
            ref let mut local: GameClass = ref gameClass;
            this.RemoveUnit(nr, ref local);
          }
          else
            this.UnitObj[unitCounter].LibId.libSlot = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].libId.libSlot == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].libId.libSlot = Newnr;
        }
      }
    }

    pub int FindLibVar(ref LibVarClass tlv, string libName)
    {
      libName = Strings.LCase(libName);
      int libVarCounter = this.LibVarCounter;
      for (int libVar = 0; libVar <= libVarCounter; libVar += 1)
      {
        if (Operators.CompareString(Strings.LCase(this.LibraryObj[this.LibVarObj[libVar].libId.libSlot].name), libName, false) == 0 && Operators.CompareString(Strings.LCase(this.LibVarObj[libVar].name), Strings.LCase(tlv.name), false) == 0)
          return libVar;
      }
      return -1;
    }

    pub int FindLibVar(ref string libvarname, string libName)
    {
      libvarname = Strings.LCase(libvarname);
      libName = Strings.LCase(libName);
      int libVarCounter = this.LibVarCounter;
      for (int libVar = 0; libVar <= libVarCounter; libVar += 1)
      {
        if (Operators.CompareString(Strings.LCase(this.LibraryObj[this.LibVarObj[libVar].libId.libSlot].name), libName, false) == 0 | Operators.CompareString(libName, "", false) == 0 && Operators.CompareString(Strings.LCase(this.LibVarObj[libVar].name), libvarname, false) == 0)
          return libVar;
      }
      return -1;
    }

    pub void AddLibVar(int libSlot)
    {
      this += 1.LibVarCounter;
      this.LibVarObj = (LibVarClass[]) Utils.CopyArray((Array) this.LibVarObj, (Array) new LibVarClass[this.LibVarCounter + 1]);
      this.LibVarObj[this.LibVarCounter] = new LibVarClass(libSlot);
    }

    pub void RemoveLibVar(int nr)
    {
      this.ChangeLibVarNr(nr, -1);
      if (nr < this.LibVarCounter)
      {
        int num1 = nr;
        int num2 = this.LibVarCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.LibVarObj[Newnr] = this.LibVarObj[Newnr + 1];
          this.ChangeLibVarNr(Newnr + 1, Newnr);
        }
      }
      --this.LibVarCounter;
      if (this.LibVarCounter == -1)
        return;
      this.LibVarObj = (LibVarClass[]) Utils.CopyArray((Array) this.LibVarObj, (Array) new LibVarClass[this.LibVarCounter + 1]);
    }

    pub void ChangeLibVarNr(int Oldnr, int Newnr)
    {
      int mapWidth = this.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; index1 += 1)
      {
        int mapHeight = this.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; index2 += 1)
        {
          for (int hexLibVarCounter = this.MapObj[0].HexObj[index1, index2].HexLibVarCounter; hexLibVarCounter >= 0; hexLibVarCounter += -1)
          {
            if (this.MapObj[0].HexObj[index1, index2].HexLibVarSlotNr[hexLibVarCounter] == Oldnr)
            {
              if (Newnr == -1)
                this.MapObj[0].HexObj[index1, index2].RemoveHexLibVar(hexLibVarCounter);
              else
                this.MapObj[0].HexObj[index1, index2].HexLibVarSlotNr[hexLibVarCounter] = Newnr;
            }
          }
        }
      }
    }

    pub void AddRoadType()
    {
      this += 1.RoadTypeCounter;
      this.RoadTypeObj = (RoadTypeClass[]) Utils.CopyArray((Array) this.RoadTypeObj, (Array) new RoadTypeClass[this.RoadTypeCounter + 1]);
      this.RoadTypeObj[this.RoadTypeCounter] = new RoadTypeClass(0);
      this.RoadTypeObj[this.RoadTypeCounter].LoadSprites();
    }

    pub void RemoveRoadType(int nr)
    {
      this.RoadTypeObj[nr].Kill();
      this.ChangeRoadNr(nr, -1);
      if (nr < this.RoadTypeCounter)
      {
        int num1 = nr;
        int num2 = this.RoadTypeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.RoadTypeObj[Newnr] = this.RoadTypeObj[Newnr + 1];
          this.ChangeRoadNr(Newnr + 1, Newnr);
        }
      }
      --this.RoadTypeCounter;
      if (this.RoadTypeCounter == -1)
        return;
      this.RoadTypeObj = (RoadTypeClass[]) Utils.CopyArray((Array) this.RoadTypeObj, (Array) new RoadTypeClass[this.RoadTypeCounter + 1]);
    }

    pub void ChangeRoadNr(int Oldnr, int Newnr)
    {
      int stringListCounter = this.StringListCounter;
      int index1;
      for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
      {
        int width = this.StringListObj[index2].Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int length = this.StringListObj[index2].Length;
          for (int index4 = 0; index4 <= length; index4 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.RoadId && this.StringListObj[index2].Data[index4, index3].Length > 0)
            {
              index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
              if (index1 == Oldnr)
                index1 = Newnr;
              this.StringListObj[index2].Data[index4, index3] = index1.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.Road & this.LibVarObj[libVarCounter].instanceId.id == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.RoadId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      int mapCounter = this.MapCounter;
      for (int index5 = 0; index5 <= mapCounter; index5 += 1)
      {
        int mapWidth = this.MapObj[index5].MapWidth;
        for (int index6 = 0; index6 <= mapWidth; index6 += 1)
        {
          int mapHeight = this.MapObj[index5].MapHeight;
          for (int index7 = 0; index7 <= mapHeight; index7 += 1)
          {
            index1 = 0;
            do
            {
              if (this.MapObj[index5].HexObj[index6, index7].RoadType[index1] == Oldnr)
                this.MapObj[index5].HexObj[index6, index7].RoadType[index1] = Newnr;
              index1 += 1;
            }
            while (index1 <= 5);
          }
        }
      }
    }

    pub void AddRiverType()
    {
      this += 1.RiverTypeCounter;
      this.RiverTypeObj = (RiverTypeClass[]) Utils.CopyArray((Array) this.RiverTypeObj, (Array) new RiverTypeClass[this.RiverTypeCounter + 1]);
      this.RiverTypeObj[this.RiverTypeCounter] = new RiverTypeClass(0);
      this.RiverTypeObj[this.RiverTypeCounter].LoadSprites();
    }

    pub void RemoveRiverType(int nr)
    {
      this.RiverTypeObj[nr].Kill();
      this.ChangeRiverNr(nr, -1);
      if (nr < this.RiverTypeCounter)
      {
        int num1 = nr;
        int num2 = this.RiverTypeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.RiverTypeObj[Newnr] = this.RiverTypeObj[Newnr + 1];
          this.ChangeRiverNr(Newnr + 1, Newnr);
        }
      }
      --this.RiverTypeCounter;
      if (this.RiverTypeCounter == -1)
        return;
      this.RiverTypeObj = (RiverTypeClass[]) Utils.CopyArray((Array) this.RiverTypeObj, (Array) new RiverTypeClass[this.RiverTypeCounter + 1]);
    }

    pub void ChangeRiverNr(int Oldnr, int Newnr)
    {
      int stringListCounter = this.StringListCounter;
      int index1;
      for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
      {
        int width = this.StringListObj[index2].Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int length = this.StringListObj[index2].Length;
          for (int index4 = 0; index4 <= length; index4 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.RiverId && this.StringListObj[index2].Data[index4, index3].Length > 0)
            {
              index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
              if (index1 == Oldnr)
                index1 = Newnr;
              this.StringListObj[index2].Data[index4, index3] = index1.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.River & this.LibVarObj[libVarCounter].instanceId.id == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.RiverId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      int mapCounter = this.MapCounter;
      for (int index5 = 0; index5 <= mapCounter; index5 += 1)
      {
        int mapWidth = this.MapObj[index5].MapWidth;
        for (int index6 = 0; index6 <= mapWidth; index6 += 1)
        {
          int mapHeight = this.MapObj[index5].MapHeight;
          for (int index7 = 0; index7 <= mapHeight; index7 += 1)
          {
            index1 = 0;
            do
            {
              if (this.MapObj[index5].HexObj[index6, index7].RiverType[index1] == Oldnr)
                this.MapObj[index5].HexObj[index6, index7].RiverType[index1] = Newnr;
              index1 += 1;
            }
            while (index1 <= 5);
          }
        }
      }
    }

    pub void AddArea()
    {
      this += 1.AreaCounter;
      this.AreaObj = (AreaClass[]) Utils.CopyArray((Array) this.AreaObj, (Array) new AreaClass[this.AreaCounter + 1]);
      this.AreaObj[this.AreaCounter] = AreaClass::new();
      this += 1.AreaIDCounter;
      this.AreaObj[this.AreaCounter].ID = this.AreaIDCounter;
    }

    pub void RemoveArea(int nr)
    {
      if (nr < this.AreaCounter)
      {
        int num1 = nr;
        int num2 = this.AreaCounter - 1;
        for (int index = num1; index <= num2; index += 1)
          this.AreaObj[index] = this.AreaObj[index + 1];
      }
      --this.AreaCounter;
      if (this.AreaCounter == -1)
        return;
      this.AreaObj = (AreaClass[]) Utils.CopyArray((Array) this.AreaObj, (Array) new AreaClass[this.AreaCounter + 1]);
    }

    pub int FindHistorical(ref HistoricalUnitClass his, string libName)
    {
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int historical = 0; historical <= historicalUnitCounter; historical += 1)
      {
        if (this.HistoricalUnitObj[historical].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.HistoricalUnitObj[historical].LibId.libSlot].name, libName, false) == 0 && this.HistoricalUnitObj[historical].LibId.id == his.ID)
          return historical;
      }
      return -1;
    }

    pub int FindHistoricalFromSameLib(ref HistoricalUnitClass his, string libName)
    {
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int historicalFromSameLib = 0; historicalFromSameLib <= historicalUnitCounter; historicalFromSameLib += 1)
      {
        if (this.HistoricalUnitObj[historicalFromSameLib].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.HistoricalUnitObj[historicalFromSameLib].LibId.libSlot].name, libName, false) == 0 && this.HistoricalUnitObj[historicalFromSameLib].LibId.id == his.LibId.id)
          return historicalFromSameLib;
      }
      return -1;
    }

    pub int FindOffHistorical(ref HistoricalUnitClass his, string libName)
    {
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int offHistorical = 0; offHistorical <= historicalUnitCounter; offHistorical += 1)
      {
        if (this.HistoricalUnitObj[offHistorical].OffLibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.HistoricalUnitObj[offHistorical].OffLibId.libSlot].name, libName, false) == 0 && this.HistoricalUnitObj[offHistorical].OffLibId.id == his.ID)
          return offHistorical;
      }
      return -1;
    }

    pub int FindOffHistoricalBySameLib(ref HistoricalUnitClass his, string libName)
    {
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int historicalBySameLib = 0; historicalBySameLib <= historicalUnitCounter; historicalBySameLib += 1)
      {
        if (this.HistoricalUnitObj[historicalBySameLib].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.HistoricalUnitObj[historicalBySameLib].LibId.libSlot].name, libName, false) == 0 && this.HistoricalUnitObj[historicalBySameLib].LibId.id == his.OffLibId.id)
          return historicalBySameLib;
      }
      return -1;
    }

    pub void AddHistoricalUnit()
    {
      this += 1.HistoricalUnitCounter;
      this.HistoricalUnitObj = (HistoricalUnitClass[]) Utils.CopyArray((Array) this.HistoricalUnitObj, (Array) new HistoricalUnitClass[this.HistoricalUnitCounter + 1]);
      this.HistoricalUnitObj[this.HistoricalUnitCounter] = HistoricalUnitClass::new();
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter; index += 1)
      {
        if (this.HistoricalUnitObj[index].ID >= this.HistoricalIDCounter)
          this.HistoricalIDCounter = this.HistoricalUnitObj[index].ID;
      }
      this += 1.HistoricalIDCounter;
      this.HistoricalUnitObj[this.HistoricalUnitCounter].ID = this.HistoricalIDCounter;
    }

    pub void RemoveHistoricalUnit(int nr)
    {
      this.ThreadBlock();
      this.ChangeHistoricalUnitNr(nr, -1);
      if (nr < this.HistoricalUnitCounter)
      {
        int num1 = nr;
        int num2 = this.HistoricalUnitCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.HistoricalUnitObj[Newnr] = this.HistoricalUnitObj[Newnr + 1];
          this.ChangeHistoricalUnitNr(Newnr + 1, Newnr);
        }
      }
      --this.HistoricalUnitCounter;
      if (this.HistoricalUnitCounter != -1)
        this.HistoricalUnitObj = (HistoricalUnitClass[]) Utils.CopyArray((Array) this.HistoricalUnitObj, (Array) new HistoricalUnitClass[this.HistoricalUnitCounter + 1]);
      this.ThreadRelease();
    }

    pub void ChangeHistoricalUnitNr(int Oldnr, int Newnr, bool QuickMode = false)
    {
      QuickMode = true;
      int index1;
      if (!QuickMode)
      {
        int stringListCounter = this.StringListCounter;
        for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
        {
          int width = this.StringListObj[index2].Width;
          for (int index3 = 0; index3 <= width; index3 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.HistoricalUnitId | this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.HistoricalUnitModelId | this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.OfficerId)
            {
              int length = this.StringListObj[index2].Length;
              for (int index4 = 0; index4 <= length; index4 += 1)
              {
                if (this.StringListObj[index2].Data[index4, index3].Length > 0)
                {
                  index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
                  if (index1 == Oldnr)
                    index1 = Newnr;
                  this.StringListObj[index2].Data[index4, index3] = index1.ToString();
                  this.StringListObj[index2].Data[index4, index3] = index1.ToString();
                }
              }
            }
          }
        }
        for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
        {
          if (this.HistoricalUnitObj[Oldnr].LibId.libSlot > -1 & (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.HistoricalUnit | this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.HistoricalUnitModel | this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.Officer) & this.LibVarObj[libVarCounter].instanceId.id == this.HistoricalUnitObj[Oldnr].LibId.id & this.LibVarObj[libVarCounter].instanceId.libSlot == this.HistoricalUnitObj[Oldnr].LibId.libSlot && Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          if (this.HistoricalUnitObj[Oldnr].LibId.libSlot == -1 & (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.HistoricalUnit | this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.HistoricalUnitModel | this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.Officer) & this.LibVarObj[libVarCounter].instanceId.id == Oldnr & this.LibVarObj[libVarCounter].instanceId.libSlot == -1)
          {
            if (Newnr == -1)
              this.RemoveLibVar(libVarCounter);
            else
              this.LibVarObj[libVarCounter].instanceId.id = Newnr;
          }
        }
        for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
        {
          if (this.LibVarObj[libVarCounter].instanceId.id > -1 & (this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.HistoricalUnitId | this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.HistoricalUnitModelId | this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.OfficerId) & this.LibVarObj[libVarCounter].value == Oldnr)
          {
            if (Newnr == -1)
              this.RemoveLibVar(libVarCounter);
            else
              this.LibVarObj[libVarCounter].value = Newnr;
          }
        }
      }
      if (this.Product == 7)
      {
        int regimeCounter = this.RegimeCounter;
        for (int index5 = 0; index5 <= regimeCounter; index5 += 1)
        {
          if (!this.RegimeObj[index5].AI)
          {
            int mapWidth = this.MapObj[0].MapWidth;
            for (int index6 = 0; index6 <= mapWidth; index6 += 1)
            {
              int mapHeight = this.MapObj[0].MapHeight;
              for (int index7 = 0; index7 <= mapHeight; index7 += 1)
              {
                if (this.RegimeObj[0].HistoryHis[0].Value[index6, index7] == Oldnr)
                  this.RegimeObj[0].HistoryHis[0].Value[index6, index7] = Newnr;
              }
            }
          }
        }
      }
      for (index1 = this.UnitCounter; index1 >= 0; index1 += -1)
      {
        if (this.UnitObj[index1].Historical == Oldnr)
          this.UnitObj[index1].Historical = Newnr;
      }
      for (index1 = this.HistoricalUnitCounter; index1 >= 0; index1 += -1)
      {
        if (this.HistoricalUnitObj[index1].ModelMaster == Oldnr)
          this.HistoricalUnitObj[index1].ModelMaster = Newnr;
        if (this.HistoricalUnitObj[index1].UseModelCounter == Oldnr)
          this.HistoricalUnitObj[index1].UseModelCounter = Newnr;
      }
    }

    pub int FindRegime(ref RegimeClass reg, string libName)
    {
      int regimeCounter = this.RegimeCounter;
      for (int regime = 0; regime <= regimeCounter; regime += 1)
      {
        if (this.RegimeObj[regime].libId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.RegimeObj[regime].libId.libSlot].name, libName, false) == 0 && this.RegimeObj[regime].libId.id == reg.id)
          return regime;
      }
      return -1;
    }

    pub int FindRegimeFromSameLib(ref RegimeClass reg, string libName)
    {
      int regimeCounter = this.RegimeCounter;
      for (int regimeFromSameLib = 0; regimeFromSameLib <= regimeCounter; regimeFromSameLib += 1)
      {
        if (Operators.CompareString(this.RegimeObj[regimeFromSameLib].Name, reg.Name, false) == 0)
          return regimeFromSameLib;
      }
      return -1;
    }

    pub void AddRegime(bool noRedimNecc = false, bool tMinimumDataUsage = false)
    {
      this.ThreadBlock();
      this += 1.RegimeCounter;
      this.RegimeObj = (RegimeClass[]) Utils.CopyArray((Array) this.RegimeObj, (Array) new RegimeClass[this.RegimeCounter + 1]);
      this.RegimeObj[this.RegimeCounter] = new RegimeClass(0, this.RegimeCounter, this.ResearchCounter, this, tMinimumDataUsage);
      this.RegimeObj[this.RegimeCounter].LoadSprites();
      this += 1.RegimeIdCounter;
      this.RegimeObj[this.RegimeCounter].id = this.RegimeIdCounter;
      int num1 = -1;
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
      {
        if (!this.RegimeObj[index].minimumDataUsage)
          num1 = index;
      }
      int mapCounter1 = this.MapCounter;
      for (int index1 = 0; index1 <= mapCounter1; index1 += 1)
      {
        int mapWidth = this.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; index2 += 1)
        {
          int mapHeight = this.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; index3 += 1)
          {
            while (this.MapObj[index1].HexObj[index2, index3].RegimeCount < this.RegimeCounter)
              this.MapObj[index1].HexObj[index2, index3].UNUSED_addnewregime(this.MapObj[index1].HexObj[index2, index3].RegimeCount + 1, !this.RegimeObj[this.MapObj[index1].HexObj[index2, index3].RegimeCount + 1].minimumDataUsage, noRedimNecc);
            this.MapObj[index1].HexObj[index2, index3].set_LastLT(this.RegimeCounter, -1);
            this.MapObj[index1].HexObj[index2, index3].set_LastReg(this.RegimeCounter, -1);
            this.MapObj[index1].HexObj[index2, index3].set_LastSpr(this.RegimeCounter, -1);
          }
        }
      }
      if (this.RegimeCounter > 0)
      {
        int num2 = this.RegimeCounter - 1;
        for (int index = 0; index <= num2; index += 1)
          this.RegimeObj[index].AddRegime();
      }
      if (noRedimNecc)
      {
        int mapCounter2 = this.MapCounter;
        for (int index4 = 0; index4 <= mapCounter2; index4 += 1)
        {
          int mapWidth = this.MapObj[index4].MapWidth;
          for (int index5 = 0; index5 <= mapWidth; index5 += 1)
          {
            int mapHeight = this.MapObj[index4].MapHeight;
            for (int index6 = 0; index6 <= mapHeight; index6 += 1)
            {
              int regimeFullCount = this.MapObj[0].HexObj[index5, index6].RegimeFullCount;
              for (int Index = 0; Index <= regimeFullCount; Index += 1)
              {
                this.MapObj[index4].HexObj[index5, index6].set_LastLT(Index, -1);
                this.MapObj[index4].HexObj[index5, index6].set_LastReg(Index, -1);
                this.MapObj[index4].HexObj[index5, index6].set_LastSpr(Index, -1);
              }
            }
          }
        }
      }
      this.ThreadRelease();
    }

    pub void MoveRegimeHigher(int regnr)
    {
      this.AddRegime();
      if (regnr < this.RegimeCounter - 1)
      {
        this.RegimeObj[this.RegimeCounter] = this.RegimeObj[regnr + 1];
        this.ChangeRegimeNr(regnr + 1, this.RegimeCounter);
        this.ChangeRegimeNr(regnr, regnr + 1);
        this.RegimeObj[regnr + 1] = this.RegimeObj[regnr];
        this.ChangeRegimeNr(this.RegimeCounter, regnr);
        this.RegimeObj[regnr] = this.RegimeObj[this.RegimeCounter];
      }
      this.RemoveRegime(this.RegimeCounter);
      this.RegimeObj[regnr].LoadSprites();
      this.RegimeObj[regnr + 1].LoadSprites();
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
      {
        int num = this.RegimeObj[index].RegimeRel[regnr + 1];
        this.RegimeObj[index].RegimeRel[regnr + 1] = this.RegimeObj[index].RegimeRel[regnr];
        this.RegimeObj[index].RegimeRel[regnr] = num;
      }
    }

    pub void MoveRegimeLower(int regnr)
    {
      this.AddRegime();
      if (regnr > 0)
      {
        this.RegimeObj[this.RegimeCounter] = this.RegimeObj[regnr - 1];
        this.ChangeRegimeNr(regnr - 1, this.RegimeCounter);
        this.ChangeRegimeNr(regnr, regnr - 1);
        this.RegimeObj[regnr - 1] = this.RegimeObj[regnr];
        this.ChangeRegimeNr(this.RegimeCounter, regnr);
        this.RegimeObj[regnr] = this.RegimeObj[this.RegimeCounter];
      }
      this.RemoveRegime(this.RegimeCounter);
      this.RegimeObj[regnr].LoadSprites();
      this.RegimeObj[regnr - 1].LoadSprites();
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
      {
        int num = this.RegimeObj[index].RegimeRel[regnr - 1];
        this.RegimeObj[index].RegimeRel[regnr - 1] = this.RegimeObj[index].RegimeRel[regnr];
        this.RegimeObj[index].RegimeRel[regnr] = num;
      }
    }

    pub void RemoveRegime(int nr)
    {
      this.ThreadBlock();
      bool minimumDataUsage = this.RegimeObj[nr].minimumDataUsage;
      this.RegimeObj[nr].Kill();
      this.ChangeRegimeNr(nr, -1);
      if (nr < this.RegimeCounter)
      {
        int num1 = nr;
        int num2 = this.RegimeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.RegimeObj[Newnr] = this.RegimeObj[Newnr + 1];
          this.ChangeRegimeNr(Newnr + 1, Newnr);
        }
      }
      int mapCounter = this.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; index1 += 1)
      {
        int mapWidth = this.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; index2 += 1)
        {
          int mapHeight = this.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; index3 += 1)
            this.MapObj[index1].HexObj[index2, index3].removeregime(!minimumDataUsage, nr);
        }
      }
      int num = this.RegimeCounter - 1;
      for (int index = 0; index <= num; index += 1)
        this.RegimeObj[index].Removeregime(nr);
      --this.RegimeCounter;
      if (this.RegimeCounter != -1)
        this.RegimeObj = (RegimeClass[]) Utils.CopyArray((Array) this.RegimeObj, (Array) new RegimeClass[this.RegimeCounter + 1]);
      this.ThreadRelease();
    }

    pub void ChangeRegimeNr(int Oldnr, int Newnr, bool QuickMode = false)
    {
      QuickMode = true;
      int index1;
      if (!QuickMode)
      {
        int stringListCounter = this.StringListCounter;
        for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
        {
          int width = this.StringListObj[index2].Width;
          for (index1 = 0; index1 <= width; index1 += 1)
          {
            int length = this.StringListObj[index2].Length;
            for (int index3 = 0; index3 <= length; index3 += 1)
            {
              if (this.StringListObj[index2].ColValueType[index1] == NewEnums.LibVarValueType.RegimeId && this.StringListObj[index2].Data[index3, index1].Length > 0)
              {
                int num =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index3, index1]));
                if (num == Oldnr)
                  num = Newnr;
                this.StringListObj[index2].Data[index3, index1] = num.ToString();
              }
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.Regime & this.LibVarObj[libVarCounter].instanceId.id == this.RegimeObj[Oldnr].libId.id & this.LibVarObj[libVarCounter].instanceId.libSlot == this.RegimeObj[Oldnr].libId.libSlot)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.RegimeId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      int mapCounter1 = this.MapCounter;
      for (int index4 = 0; index4 <= mapCounter1; index4 += 1)
      {
        int mapWidth = this.MapObj[index4].MapWidth;
        for (index1 = 0; index1 <= mapWidth; index1 += 1)
        {
          int mapHeight = this.MapObj[index4].MapHeight;
          for (int index5 = 0; index5 <= mapHeight; index5 += 1)
          {
            if (this.MapObj[index4].HexObj[index1, index5].Regime == Oldnr & Newnr == -1 && this.MapObj[index4].HexObj[index1, index5].Location > -1)
              this.LocObj[this.MapObj[index4].HexObj[index1, index5].Location].HQ = -1;
            if (this.MapObj[index4].HexObj[index1, index5].Regime == Oldnr)
              this.MapObj[index4].HexObj[index1, index5].Regime = Newnr;
            if (this.Product >= 6 & this.Round > 0)
            {
              int num = this.MapObj[index4].HexObj[index1, index5].get_LastReg(Oldnr);
              if (Newnr != -1)
                this.MapObj[index4].HexObj[index1, index5].set_LastReg(Newnr, num);
              int regimeCounter = this.RegimeCounter;
              for (int Index = 0; Index <= regimeCounter; Index += 1)
              {
                if (this.MapObj[index4].HexObj[index1, index5].get_LastReg(Index) == Oldnr)
                  this.MapObj[index4].HexObj[index1, index5].set_LastReg(Index, Newnr);
              }
            }
          }
        }
      }
      if (this.Product >= 6 & this.Round > 0)
      {
        if (!Information.IsNothing((object) DrawMod.TGame.EditObj.HisOwner[0]))
        {
          try
          {
            int mapWidth = this.MapObj[0].MapWidth;
            for (index1 = 0; index1 <= mapWidth; index1 += 1)
            {
              int mapHeight = this.MapObj[0].MapHeight;
              for (int index6 = 0; index6 <= mapHeight; index6 += 1)
              {
                if (DrawMod.TGame.EditObj.HisOwner[0].Value[index1, index6] == Oldnr)
                  DrawMod.TGame.EditObj.HisOwner[0].Value[index1, index6] = Newnr;
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
      }
      if (this.Product >= 6 & this.Round > 0)
      {
        int tRegimeFullCount = -1;
        int regimeCounter = this.RegimeCounter;
        for (int index7 = 0; index7 <= regimeCounter; index7 += 1)
        {
          if (!this.RegimeObj[index7].minimumDataUsage)
            tRegimeFullCount = index7;
        }
        int mapCounter2 = this.MapCounter;
        for (int index8 = 0; index8 <= mapCounter2; index8 += 1)
        {
          int mapWidth = this.MapObj[index8].MapWidth;
          for (int index9 = 0; index9 <= mapWidth; index9 += 1)
          {
            int mapHeight = this.MapObj[index8].MapHeight;
            for (int index10 = 0; index10 <= mapHeight; index10 += 1)
              this.MapObj[index8].HexObj[index9, index10].redimRegime(this.RegimeCounter, tRegimeFullCount);
          }
        }
      }
      for (int index11 = this.RegimeCounter; index11 >= 0; index11 += -1)
      {
        if (this.Round > 0)
        {
          if (this.RegimeObj[index11].UberRegime == Oldnr)
            this.RegimeObj[index11].UberRegime = Newnr;
          try
          {
            if (!Information.IsNothing((object) this.RegimeObj[index11].HistoryOwner[0]))
            {
              int mapWidth = this.MapObj[0].MapWidth;
              for (int index12 = 0; index12 <= mapWidth; index12 += 1)
              {
                int mapHeight = this.MapObj[0].MapHeight;
                for (int index13 = 0; index13 <= mapHeight; index13 += 1)
                {
                  if (this.RegimeObj[index11].HistoryOwner[0].Value[index12, index13] == Oldnr)
                    this.RegimeObj[index11].HistoryOwner[0].Value[index12, index13] = Newnr;
                }
              }
            }
            int historyStepCounter = this.RegimeObj[index11].HistoryStepCounter;
            for (int index14 = 0; index14 <= historyStepCounter; index14 += 1)
            {
              if (this.RegimeObj[index11].HistoryStep[index14].Ownership == Oldnr)
                this.RegimeObj[index11].HistoryStep[index14].Ownership = Newnr;
              if (this.RegimeObj[index11].HistoryStep[index14].LossAttReg == Oldnr)
                this.RegimeObj[index11].HistoryStep[index14].LossAttReg = Newnr;
              if (this.RegimeObj[index11].HistoryStep[index14].LossDefReg == Oldnr)
                this.RegimeObj[index11].HistoryStep[index14].LossDefReg = Newnr;
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            index11 = index11;
            ProjectData.ClearProjectError();
          }
        }
      }
      for (int unitCounter = this.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.UnitObj[unitCounter].Regime == Oldnr)
        {
          if (Newnr == -1)
          {
            int nr = unitCounter;
            let mut gameClass: GameClass = (GameClass) null;
            ref let mut local: GameClass = ref gameClass;
            this.RemoveUnit(nr, ref local, true);
          }
          else
            this.UnitObj[unitCounter].Regime = Newnr;
        }
      }
      int itemTypeCounter = this.ItemTypeCounter;
      for (int index15 = 0; index15 <= itemTypeCounter; index15 += 1)
      {
        if (this.ItemTypeObj[index15].RegimeSpecific > -1 & this.ItemTypeObj[index15].RegimeSpecific == Oldnr)
          this.ItemTypeObj[index15].RegimeSpecific = Newnr;
      }
      for (int historicalUnitCounter = this.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.HistoricalUnitObj[historicalUnitCounter].TempRegime == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveHistoricalUnit(historicalUnitCounter);
          else
            this.HistoricalUnitObj[historicalUnitCounter].TempRegime = Newnr;
        }
      }
      int peopleCounter = this.PeopleCounter;
      for (int index16 = 0; index16 <= peopleCounter; index16 += 1)
      {
        if (this.PeopleObj[index16].RegCol == Oldnr)
          this.PeopleObj[index16].RegCol = Newnr;
      }
    }

    pub int FindStringList(ref StringListClass e, string libname)
    {
      int stringListCounter = this.StringListCounter;
      for (int stringList = 0; stringList <= stringListCounter; stringList += 1)
      {
        if (this.StringListObj[stringList].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.StringListObj[stringList].LibId.libSlot].name, libname, false) == 0 && Operators.CompareString(this.StringListObj[stringList].Name, e.Name, false) == 0 & this.StringListObj[stringList].LibId.id == e.ID)
          return stringList;
      }
      return -1;
    }

    pub void AddStringList()
    {
      this += 1.StringListCounter;
      this += 1.StringIDCounter;
      int num = this.StringListCounter - 1;
      for (int index = 0; index <= num; index += 1)
      {
        if (this.StringListObj[index].ID >= this.StringIDCounter)
          this.StringIDCounter = this.StringListObj[index].ID + 1;
      }
      this.StringListObj = (StringListClass[]) Utils.CopyArray((Array) this.StringListObj, (Array) new StringListClass[this.StringListCounter + 1]);
      this.StringListObj[this.StringListCounter] = new StringListClass(this.StringIDCounter);
    }

    pub void RemoveStringList(int nr)
    {
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
      {
        if (this.RegimeObj[index].OfficerPool == nr)
          this.RegimeObj[index].OfficerPool = -1;
      }
      if (nr < this.StringListCounter)
      {
        int num1 = nr;
        int num2 = this.StringListCounter - 1;
        for (int index = num1; index <= num2; index += 1)
          this.StringListObj[index] = this.StringListObj[index + 1];
      }
      --this.StringListCounter;
      if (this.StringListCounter == -1)
        return;
      this.StringListObj = (StringListClass[]) Utils.CopyArray((Array) this.StringListObj, (Array) new StringListClass[this.StringListCounter + 1]);
    }

    pub void AddResearch()
    {
      this += 1.ResearchCounter;
      this.ResearchObj = (ResearchClass[]) Utils.CopyArray((Array) this.ResearchObj, (Array) new ResearchClass[this.ResearchCounter + 1]);
      this.ResearchObj[this.ResearchCounter] = new ResearchClass(0);
      this.ResearchObj[this.ResearchCounter].LoadSprites();
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
        this.RegimeObj[index].AddResField();
      int sfTypeCounter = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; index += 1)
        this.SFTypeObj[index].AddResField();
    }

    pub void RemoveResearch(int nr)
    {
      this.ResearchObj[nr].Kill();
      this.ChangeResearchNr(nr, -1);
      if (nr < this.ResearchCounter)
      {
        int num1 = nr;
        int num2 = this.ResearchCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.ResearchObj[Newnr] = this.ResearchObj[Newnr + 1];
          this.ChangeResearchNr(Newnr + 1, Newnr);
        }
      }
      --this.ResearchCounter;
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
        this.RegimeObj[index].RemoveResField(nr);
      int sfTypeCounter = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; index += 1)
        this.SFTypeObj[index].RemoveResField(nr);
      if (this.ResearchCounter == -1)
        return;
      this.ResearchObj = (ResearchClass[]) Utils.CopyArray((Array) this.ResearchObj, (Array) new ResearchClass[this.ResearchCounter + 1]);
    }

    pub void ChangeResearchNr(int Oldnr, int Newnr)
    {
      int itemTypeCounter = this.ItemTypeCounter;
      for (int index1 = 0; index1 <= itemTypeCounter; index1 += 1)
      {
        int index2 = 0;
        do
        {
          if (this.ItemTypeObj[index1].ResFieldNeeded[index2] == Oldnr)
            this.ItemTypeObj[index1].ResFieldNeeded[index2] = Newnr;
          index2 += 1;
        }
        while (index2 <= 4);
      }
      int locTypeCounter = this.LocTypeCounter;
      for (int index3 = 0; index3 <= locTypeCounter; index3 += 1)
      {
        int index4 = 0;
        do
        {
          if (this.LocTypeObj[index3].Research[index4] == Oldnr)
            this.LocTypeObj[index3].Research[index4] = Newnr;
          index4 += 1;
        }
        while (index4 <= 4);
      }
      int researchCounter = this.ResearchCounter;
      for (int index = 0; index <= researchCounter; index += 1)
      {
        if (this.ResearchObj[index].PreReq == Oldnr)
          this.ResearchObj[index].PreReq = Newnr;
        if (this.ResearchObj[index].PreReq2 == Oldnr)
          this.ResearchObj[index].PreReq2 = Newnr;
      }
      int sfTypeCounter = this.SFTypeCounter;
      for (int index5 = 0; index5 <= sfTypeCounter; index5 += 1)
      {
        int index6 = 0;
        do
        {
          if (this.SFTypeObj[index5].ModelResearch[index6] == Oldnr)
            this.SFTypeObj[index5].ModelResearch[index6] = Newnr;
          index6 += 1;
        }
        while (index6 <= 9);
      }
    }

    pub void AddLocType()
    {
      this += 1.LocTypeCounter;
      this.LocTypeObj = (LocationTypeClass[]) Utils.CopyArray((Array) this.LocTypeObj, (Array) new LocationTypeClass[this.LocTypeCounter + 1]);
      this.LocTypeObj[this.LocTypeCounter] = new LocationTypeClass(0);
      this.LocTypeObj[this.LocTypeCounter].LoadSprites();
    }

    pub void RemoveLocType(int nr)
    {
      this.LocTypeObj[nr].Kill();
      this.ChangeLocTypeNr(nr, -1);
      if (nr < this.LocTypeCounter)
      {
        int num1 = nr;
        int num2 = this.LocTypeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.LocTypeObj[Newnr] = this.LocTypeObj[Newnr + 1];
          this.ChangeLocTypeNr(Newnr + 1, Newnr);
        }
      }
      --this.LocTypeCounter;
      if (this.LocTypeCounter == -1)
        return;
      this.LocTypeObj = (LocationTypeClass[]) Utils.CopyArray((Array) this.LocTypeObj, (Array) new LocationTypeClass[this.LocTypeCounter + 1]);
    }

    pub void ChangeLocTypeNr(int Oldnr, int Newnr)
    {
      int stringListCounter = this.StringListCounter;
      int nr;
      for (int index1 = 0; index1 <= stringListCounter; index1 += 1)
      {
        int width = this.StringListObj[index1].Width;
        for (int index2 = 0; index2 <= width; index2 += 1)
        {
          int length = this.StringListObj[index1].Length;
          for (int index3 = 0; index3 <= length; index3 += 1)
          {
            if (this.StringListObj[index1].ColValueType[index2] == NewEnums.LibVarValueType.LocationTypeId && this.StringListObj[index1].Data[index3, index2].Length > 0)
            {
              nr =  Math.Round(Conversion.Val(this.StringListObj[index1].Data[index3, index2]));
              if (nr == Oldnr)
                nr = Newnr;
              this.StringListObj[index1].Data[index3, index2] = nr.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.LocationType & this.LibVarObj[libVarCounter].instanceId.id == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.LocationTypeId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      for (nr = this.LocCounter; nr >= 0; nr += -1)
      {
        if (this.LocObj[nr].Type == Oldnr)
          this.LocObj[nr].Type = Newnr;
        if (this.LocObj[nr].Type == -1)
          this.RemoveLoc(nr);
      }
    }

    pub void AddLoc(int x, int y, int map)
    {
      this.ThreadBlock();
      this.LocIdCounter = Operators.AddObject(this.LocIdCounter, (object) 1);
      this += 1.LocCounter;
      this.LocObj = (LocationClass[]) Utils.CopyArray((Array) this.LocObj, (Array) new LocationClass[this.LocCounter + 1]);
      this.LocObj[this.LocCounter] = new LocationClass(0);
      this.LocObj[this.LocCounter].LoadSprites();
      this.LocObj[this.LocCounter].X = x;
      this.LocObj[this.LocCounter].Y = y;
      this.LocObj[this.LocCounter].Map = map;
      this.LocObj[this.LocCounter].ID = Conversions.ToInteger(this.LocIdCounter);
      this.LocObj[this.LocCounter].items = ItemList::new();
      this.ThreadRelease();
    }

    pub void AddLoc2(int x, int y, int map)
    {
      this.ThreadBlock();
      this.LocIdCounter = Operators.AddObject(this.LocIdCounter, (object) 1);
      this += 1.LocCounter;
      this.LocObj = (LocationClass[]) Utils.CopyArray((Array) this.LocObj, (Array) new LocationClass[this.LocCounter + 1]);
      this.LocObj[this.LocCounter] = new LocationClass(0);
      this.LocObj[this.LocCounter].LoadSprites();
      this.LocObj[this.LocCounter].X = x;
      this.LocObj[this.LocCounter].Y = y;
      this.LocObj[this.LocCounter].LocSlot = 2;
      this.LocObj[this.LocCounter].Map = map;
      this.LocObj[this.LocCounter].ID = Conversions.ToInteger(this.LocIdCounter);
      this.ThreadRelease();
    }

    pub void RemoveLoc(int nr)
    {
      this.ThreadBlock();
      this.LocObj[nr].Kill();
      this.ChangeLocNr(nr, -1);
      if (nr < this.LocCounter)
      {
        int num1 = nr;
        int num2 = this.LocCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.LocObj[Newnr] = this.LocObj[Newnr + 1];
          this.ChangeLocNr(Newnr + 1, Newnr);
        }
      }
      --this.LocCounter;
      if (this.LocCounter != -1)
        this.LocObj = (LocationClass[]) Utils.CopyArray((Array) this.LocObj, (Array) new LocationClass[this.LocCounter + 1]);
      this.ThreadRelease();
    }

    pub void ChangeLocNr(int Oldnr, int Newnr)
    {
      int mapCounter = this.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; index1 += 1)
      {
        int mapWidth = this.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; index2 += 1)
        {
          int mapHeight = this.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; index3 += 1)
          {
            if (this.MapObj[index1].HexObj[index2, index3].Location == Oldnr)
              this.MapObj[index1].HexObj[index2, index3].Location = Newnr;
            if (this.Product >= 6 && this.MapObj[index1].HexObj[index2, index3].Location2 == Oldnr)
              this.MapObj[index1].HexObj[index2, index3].Location2 = Newnr;
          }
        }
      }
    }

    pub int FindEvent(ref EventClass e, string libname)
    {
      int eventCounter = this.EventCounter;
      for (int index = 0; index <= eventCounter; index += 1)
      {
        if (this.EventObj[index].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.EventObj[index].LibId.libSlot].name, libname, false) == 0 && Operators.CompareString(this.EventObj[index].Name, e.Name, false) == 0 & this.EventObj[index].LibId.id == e.Id)
          return index;
      }
      return -1;
    }

    pub int FindEvent2(string libname, int id)
    {
      int eventCounter = this.EventCounter;
      for (int event2 = 0; event2 <= eventCounter; event2 += 1)
      {
        if (this.EventObj[event2].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.EventObj[event2].LibId.libSlot].name, libname, false) == 0 && this.EventObj[event2].LibId.id == id)
          return event2;
      }
      return -1;
    }

    pub void AddEvent(int insert = -1)
    {
      int eventCounter1 = this.EventCounter;
      for (int index = 0; index <= eventCounter1; index += 1)
      {
        if (this.EventObj[index].Id >= this.EventIdCounter)
          this.EventIdCounter = this.EventObj[index].Id;
      }
      this += 1.EventCounter;
      this.EventObj = (EventClass[]) Utils.CopyArray((Array) this.EventObj, (Array) new EventClass[this.EventCounter + 1]);
      this.EventObj[this.EventCounter] = new EventClass(0);
      this += 1.EventIdCounter;
      this.EventObj[this.EventCounter].Id = this.EventIdCounter;
      if (insert <= -1 || insert >= this.EventCounter - 1)
        return;
      int eventCounter2 = this.EventCounter;
      int num = insert + 2;
      for (int toonr = eventCounter2; toonr >= num; toonr += -1)
      {
        this.EventObj[toonr] = this.EventObj[toonr - 1];
        this.ChangeEventNr2(toonr - 1, toonr);
      }
      this.EventObj[insert + 1] = new EventClass(0);
      this.EventObj[insert + 1].Id = this.EventIdCounter;
    }

    pub void ChangeEventNr2(int fromnr, int toonr)
    {
      int actionCardCounter = this.ActionCardCounter;
      for (int index = 0; index <= actionCardCounter; index += 1)
      {
        if (this.ActionCardObj[index].ExecuteEvent == fromnr)
          this.ActionCardObj[index].ExecuteEvent = toonr;
        if (this.ActionCardObj[index].PreExecuteEvent == fromnr)
          this.ActionCardObj[index].PreExecuteEvent = toonr;
      }
      int index1 = 0;
      do
      {
        if (this.VariantEvent[index1] == fromnr)
          this.VariantEvent[index1] = toonr;
        index1 += 1;
      }
      while (index1 <= 9);
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int index2 = 0; index2 <= historicalUnitCounter; index2 += 1)
      {
        int autoEventCounter = this.HistoricalUnitObj[index2].AutoEventCounter;
        for (int index3 = 0; index3 <= autoEventCounter; index3 += 1)
        {
          if (this.HistoricalUnitObj[index2].AutoEvent[index3] == fromnr)
            this.HistoricalUnitObj[index2].AutoEvent[index3] = toonr;
        }
      }
      int sfTypeCounter = this.SFTypeCounter;
      for (int index4 = 0; index4 <= sfTypeCounter; index4 += 1)
      {
        if (this.SFTypeObj[index4].ModelNewEvent == fromnr)
          this.SFTypeObj[index4].ModelNewEvent = toonr;
        int upperBound = this.SFTypeObj[index4].ModelImproveEvent.GetUpperBound(0);
        for (int index5 = 0; index5 <= upperBound; index5 += 1)
        {
          if (this.SFTypeObj[index4].ModelImproveEvent[index5] == fromnr)
            this.SFTypeObj[index4].ModelImproveEvent[index5] = toonr;
        }
        if (this.SFTypeObj[index4].ModelInitialEvent == fromnr)
          this.SFTypeObj[index4].ModelInitialEvent = toonr;
        int modelVariantCounter = this.SFTypeObj[index4].ModelVariantCounter;
        for (int index6 = 0; index6 <= modelVariantCounter; index6 += 1)
        {
          if (this.SFTypeObj[index4].ModelVariantCheck[index6] == fromnr)
            this.SFTypeObj[index4].ModelVariantCheck[index6] = toonr;
          if (this.SFTypeObj[index4].ModelVariantExec[index6] == fromnr)
            this.SFTypeObj[index4].ModelVariantExec[index6] = toonr;
        }
      }
      int locTypeCounter = this.LocTypeCounter;
      for (int index7 = 0; index7 <= locTypeCounter; index7 += 1)
      {
        if (this.LocTypeObj[index7].AIEvent == fromnr)
          this.LocTypeObj[index7].AIEvent = toonr;
        if (this.LocTypeObj[index7].AILocEvent == fromnr)
          this.LocTypeObj[index7].AILocEvent = toonr;
        if (this.LocTypeObj[index7].AIAfterBuildEvent == fromnr)
          this.LocTypeObj[index7].AIAfterBuildEvent = toonr;
      }
    }

    pub void ChangeEventSwitchNr(int fromnr, int toonr)
    {
      int actionCardCounter = this.ActionCardCounter;
      for (int index = 0; index <= actionCardCounter; index += 1)
      {
        if (this.ActionCardObj[index].ExecuteEvent == fromnr)
          this.ActionCardObj[index].ExecuteEvent = toonr;
        else if (this.ActionCardObj[index].ExecuteEvent == toonr)
          this.ActionCardObj[index].ExecuteEvent = fromnr;
        if (this.ActionCardObj[index].PreExecuteEvent == fromnr)
          this.ActionCardObj[index].PreExecuteEvent = toonr;
        else if (this.ActionCardObj[index].PreExecuteEvent == toonr)
          this.ActionCardObj[index].PreExecuteEvent = fromnr;
      }
      int index1 = 0;
      do
      {
        if (this.VariantEvent[index1] == fromnr)
          this.VariantEvent[index1] = toonr;
        else if (this.VariantEvent[index1] == toonr)
          this.VariantEvent[index1] = fromnr;
        index1 += 1;
      }
      while (index1 <= 9);
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (int index2 = 0; index2 <= historicalUnitCounter; index2 += 1)
      {
        int autoEventCounter = this.HistoricalUnitObj[index2].AutoEventCounter;
        for (int index3 = 0; index3 <= autoEventCounter; index3 += 1)
        {
          if (this.HistoricalUnitObj[index2].AutoEvent[index3] == fromnr)
            this.HistoricalUnitObj[index2].AutoEvent[index3] = toonr;
          else if (this.HistoricalUnitObj[index2].AutoEvent[index3] == toonr)
            this.HistoricalUnitObj[index2].AutoEvent[index3] = fromnr;
        }
      }
      int sfTypeCounter = this.SFTypeCounter;
      for (int index4 = 0; index4 <= sfTypeCounter; index4 += 1)
      {
        if (this.SFTypeObj[index4].ModelNewEvent == fromnr)
          this.SFTypeObj[index4].ModelNewEvent = toonr;
        else if (this.SFTypeObj[index4].ModelNewEvent == toonr)
          this.SFTypeObj[index4].ModelNewEvent = fromnr;
        int researchCounter = this.ResearchCounter;
        for (int index5 = 0; index5 <= researchCounter; index5 += 1)
        {
          if (this.SFTypeObj[index4].ModelImproveEvent[index5] == fromnr)
            this.SFTypeObj[index4].ModelImproveEvent[index5] = toonr;
          else if (this.SFTypeObj[index4].ModelImproveEvent[index5] == toonr)
            this.SFTypeObj[index4].ModelImproveEvent[index5] = fromnr;
        }
        if (this.SFTypeObj[index4].ModelInitialEvent == fromnr)
          this.SFTypeObj[index4].ModelInitialEvent = toonr;
        else if (this.SFTypeObj[index4].ModelInitialEvent == toonr)
          this.SFTypeObj[index4].ModelInitialEvent = fromnr;
        int modelVariantCounter = this.SFTypeObj[index4].ModelVariantCounter;
        for (int index6 = 0; index6 <= modelVariantCounter; index6 += 1)
        {
          if (this.SFTypeObj[index4].ModelVariantCheck[index6] == fromnr)
            this.SFTypeObj[index4].ModelVariantCheck[index6] = toonr;
          else if (this.SFTypeObj[index4].ModelVariantCheck[index6] == toonr)
            this.SFTypeObj[index4].ModelVariantCheck[index6] = fromnr;
          if (this.SFTypeObj[index4].ModelVariantExec[index6] == fromnr)
            this.SFTypeObj[index4].ModelVariantExec[index6] = toonr;
          else if (this.SFTypeObj[index4].ModelVariantExec[index6] == toonr)
            this.SFTypeObj[index4].ModelVariantExec[index6] = fromnr;
        }
      }
    }

    pub void RemoveEvent(int nr)
    {
      if (nr < this.EventCounter)
      {
        int num1 = nr;
        int num2 = this.EventCounter - 1;
        for (int toonr = num1; toonr <= num2; toonr += 1)
        {
          this.EventObj[toonr] = this.EventObj[toonr + 1];
          this.ChangeEventNr2(toonr + 1, toonr);
        }
      }
      this.ChangeEventNr2(this.EventCounter, -1);
      --this.EventCounter;
      if (this.EventCounter == -1)
        return;
      this.EventObj = (EventClass[]) Utils.CopyArray((Array) this.EventObj, (Array) new EventClass[this.EventCounter + 1]);
    }

    pub void eventdown(int nr)
    {
      if (!(nr < this.EventCounter & nr > -1))
        return;
      EventClass eventClass = this.EventObj[nr].Clone();
      this.EventObj[nr] = this.EventObj[nr + 1].Clone();
      this.EventObj[nr + 1] = eventClass;
      this.ChangeEventSwitchNr(nr, nr + 1);
    }

    pub void eventup(int nr)
    {
      if (nr <= 0)
        return;
      EventClass eventClass = this.EventObj[nr].Clone();
      this.EventObj[nr] = this.EventObj[nr - 1].Clone();
      this.EventObj[nr - 1] = eventClass;
      this.ChangeEventSwitchNr(nr, nr - 1);
    }

    pub int FindPeople(ref PeopleClass ppl, string libName)
    {
      int peopleCounter = this.PeopleCounter;
      for (int people = 0; people <= peopleCounter; people += 1)
      {
        if (this.PeopleObj[people].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.PeopleObj[people].LibId.libSlot].name, libName, false) == 0 && this.PeopleObj[people].LibId.id == ppl.id)
          return people;
      }
      return -1;
    }

    pub void AddPeople()
    {
      this += 1.PeopleCounter;
      this.PeopleObj = (PeopleClass[]) Utils.CopyArray((Array) this.PeopleObj, (Array) new PeopleClass[this.PeopleCounter + 1]);
      this.PeopleObj[this.PeopleCounter] = new PeopleClass(0);
      this.PeopleObj[this.PeopleCounter].LoadSprites();
      this += 1.PeopleIdCounter;
      this.PeopleObj[this.PeopleCounter].id = this.PeopleIdCounter;
    }

    pub void RemovePeople(int nr)
    {
      this.PeopleObj[nr].Kill();
      this.ChangePeopleNr(nr, -1);
      if (nr < this.PeopleCounter)
      {
        int num1 = nr;
        int num2 = this.PeopleCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.PeopleObj[Newnr] = this.PeopleObj[Newnr + 1];
          this.ChangePeopleNr(Newnr + 1, Newnr);
        }
      }
      --this.PeopleCounter;
      if (this.PeopleCounter == -1)
        return;
      this.PeopleObj = (PeopleClass[]) Utils.CopyArray((Array) this.PeopleObj, (Array) new PeopleClass[this.PeopleCounter + 1]);
    }

    pub void ChangePeopleNr(int Oldnr, int Newnr)
    {
      int stringListCounter = this.StringListCounter;
      int index1;
      for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
      {
        int width = this.StringListObj[index2].Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int length = this.StringListObj[index2].Length;
          for (int index4 = 0; index4 <= length; index4 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.PeopleId && this.StringListObj[index2].Data[index4, index3].Length > 0)
            {
              index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
              if (index1 == Oldnr)
                index1 = Newnr;
              this.StringListObj[index2].Data[index4, index3] = index1.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].type == NewEnums.LibVarType.People & this.LibVarObj[libVarCounter].instanceId.id == this.PeopleObj[Oldnr].LibId.id & this.LibVarObj[libVarCounter].instanceId.libSlot == this.PeopleObj[Oldnr].LibId.libSlot)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].instanceId.id = Newnr;
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.PeopleId & this.LibVarObj[libVarCounter].value == Oldnr)
        {
          if (Newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = Newnr;
        }
      }
      if (Newnr == -1 & this.PeopleCounter > 0)
        Newnr = 0;
      int locCounter = this.LocCounter;
      for (index1 = 0; index1 <= locCounter; index1 += 1)
      {
        if (this.LocObj[index1].People == Oldnr)
          this.LocObj[index1].People = Newnr;
      }
      int sfCounter = this.SFCounter;
      for (index1 = 0; index1 <= sfCounter; index1 += 1)
      {
        if (this.SFObj[index1].People == Oldnr)
          this.SFObj[index1].People = Newnr;
      }
      int regimeCounter = this.RegimeCounter;
      for (index1 = 0; index1 <= regimeCounter; index1 += 1)
      {
        if (this.RegimeObj[index1].People == Oldnr)
          this.RegimeObj[index1].People = Newnr;
      }
      int itemTypeCounter = this.ItemTypeCounter;
      for (index1 = 0; index1 <= itemTypeCounter; index1 += 1)
      {
        if (this.ItemTypeObj[index1].PeopleMod == Oldnr)
          this.ItemTypeObj[index1].PeopleMod = Newnr;
      }
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (index1 = 0; index1 <= historicalUnitCounter; index1 += 1)
      {
        if (this.HistoricalUnitObj[index1].People == Oldnr)
          this.HistoricalUnitObj[index1].People = Newnr;
        if (this.HistoricalUnitObj[index1].UsePeopleGfx == Oldnr)
          this.HistoricalUnitObj[index1].UsePeopleGfx = Newnr;
      }
    }

    pub void MovePeopleHigher(int peopleNr)
    {
      this.AddPeople();
      if (peopleNr < this.PeopleCounter - 1)
      {
        this.PeopleObj[this.PeopleCounter] = this.PeopleObj[peopleNr + 1];
        this.ChangePeopleNr(peopleNr + 1, this.PeopleCounter);
        this.ChangePeopleNr(peopleNr, peopleNr + 1);
        this.PeopleObj[peopleNr + 1] = this.PeopleObj[peopleNr];
        this.ChangePeopleNr(this.PeopleCounter, peopleNr);
        this.PeopleObj[peopleNr] = this.PeopleObj[this.PeopleCounter];
      }
      this.RemovePeople(this.PeopleCounter);
      this.PeopleObj[peopleNr].LoadSprites();
      this.PeopleObj[peopleNr + 1].LoadSprites();
    }

    pub void MovePeopleLower(int PeopleNr)
    {
      this.AddPeople();
      if (PeopleNr > 0)
      {
        this.PeopleObj[this.PeopleCounter] = this.PeopleObj[PeopleNr - 1];
        this.ChangePeopleNr(PeopleNr - 1, this.PeopleCounter);
        this.ChangePeopleNr(PeopleNr, PeopleNr - 1);
        this.PeopleObj[PeopleNr - 1] = this.PeopleObj[PeopleNr];
        this.ChangePeopleNr(this.PeopleCounter, PeopleNr);
        this.PeopleObj[PeopleNr] = this.PeopleObj[this.PeopleCounter];
      }
      this.RemovePeople(this.PeopleCounter);
      this.PeopleObj[PeopleNr].LoadSprites();
      this.PeopleObj[PeopleNr - 1].LoadSprites();
    }

    pub void AddMap(int w, int h)
    {
      this += 1.MapCounter;
      this.MapObj = (MapClass[]) Utils.CopyArray((Array) this.MapObj, (Array) new MapClass[this.MapCounter + 1]);
      this.MapObj[this.MapCounter] = new MapClass(0, this.RegimeCounter, w, h);
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
        this.RegimeObj[index].AddMap(w, h);
    }

    pub void RemoveMap(int nr)
    {
      this.ChangeMapNr(nr, -1);
      if (nr < this.MapCounter)
      {
        int num1 = nr;
        int num2 = this.MapCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.MapObj[Newnr] = this.MapObj[Newnr + 1];
          this.ChangeMapNr(Newnr + 1, Newnr);
        }
      }
      --this.MapCounter;
      if (this.MapCounter != -1)
        this.MapObj = (MapClass[]) Utils.CopyArray((Array) this.MapObj, (Array) new MapClass[this.MapCounter + 1]);
      int regimeCounter = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter; index += 1)
        this.RegimeObj[index].RemoveMap(nr);
    }

    pub void ChangeMapNr(int Oldnr, int Newnr)
    {
      for (int unitCounter = this.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.UnitObj[unitCounter].Map == Oldnr & Newnr > -1)
          this.UnitObj[unitCounter].Map = Newnr;
        if (Newnr == -1)
        {
          int nr = unitCounter;
          let mut gameClass: GameClass = (GameClass) null;
          ref let mut local: GameClass = ref gameClass;
          this.RemoveUnit(nr, ref local);
        }
      }
      for (int locCounter = this.LocCounter; locCounter >= 0; locCounter += -1)
      {
        if (this.LocObj[locCounter].Map == Oldnr & Newnr > -1)
          this.LocObj[locCounter].Map = Newnr;
        if (Newnr == -1)
          this.RemoveLoc(locCounter);
      }
      int mapCounter = this.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; index1 += 1)
      {
        int mapWidth = this.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; index2 += 1)
        {
          int mapHeight = this.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; index3 += 1)
          {
            for (int connectionCount = this.MapObj[index1].HexObj[index2, index3].ConnectionCount; connectionCount >= 0; connectionCount += -1)
            {
              if (this.MapObj[index1].HexObj[index2, index3].ConnectionMap[connectionCount] == Oldnr)
              {
                if (Newnr > -1)
                  this.MapObj[index1].HexObj[index2, index3].ConnectionMap[connectionCount] = Newnr;
                else
                  this.MapObj[index1].HexObj[index2, index3].RemoveConnection(connectionCount);
              }
            }
          }
        }
      }
    }

    pub void AddItemType()
    {
      int regimeCounter1 = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter1; index += 1)
      {
        this.RegimeObj[index].SProd = new int[this.ItemTypeCounter + 1, this.Round + 1 + 1];
        this.RegimeObj[index].SASProdLost = (int[]) Utils.CopyArray((Array) this.RegimeObj[index].SASProdLost, (Array) new int[this.ItemTypeCounter + 1]);
      }
      this += 1.ItemTypeCounter;
      this.ItemTypeObj = (ItemTypeClass[]) Utils.CopyArray((Array) this.ItemTypeObj, (Array) new ItemTypeClass[this.ItemTypeCounter + 1]);
      this.ItemTypeObj[this.ItemTypeCounter] = new ItemTypeClass(0);
      this.ItemTypeObj[this.ItemTypeCounter].LoadSprites();
      object[,,] objArray = new object[this.RegimeCounter + 1, this.ItemTypeCounter + 1, this.Round + 1 + 1];
      int regimeCounter2 = this.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter2; index1 += 1)
      {
        int upperBound = this.RegimeObj[index1].SProd.GetUpperBound(0);
        for (int index2 = 0; index2 <= upperBound; index2 += 1)
        {
          int round = this.Round;
          for (int index3 = 0; index3 <= round; index3 += 1)
            objArray[index1, index2, index3] = (object) this.RegimeObj[index1].SProd[index2, index3];
        }
      }
      int regimeCounter3 = this.RegimeCounter;
      for (int index = 0; index <= regimeCounter3; index += 1)
      {
        this.RegimeObj[index].SProd = new int[this.ItemTypeCounter + 1, this.Round + 1 + 1];
        this.RegimeObj[index].SASProdLost = (int[]) Utils.CopyArray((Array) this.RegimeObj[index].SASProdLost, (Array) new int[this.ItemTypeCounter + 1]);
      }
      int regimeCounter4 = this.RegimeCounter;
      for (int index4 = 0; index4 <= regimeCounter4; index4 += 1)
      {
        int itemTypeCounter = this.ItemTypeCounter;
        for (int index5 = 0; index5 <= itemTypeCounter; index5 += 1)
        {
          int num = this.Round + 1;
          for (int index6 = 0; index6 <= num; index6 += 1)
            this.RegimeObj[index4].SProd[index5, index6] = Conversions.ToInteger(objArray[index4, index5, index6]);
        }
      }
    }

    pub void RemoveItemType(int nr)
    {
      this.ItemTypeObj[nr].Kill();
      this.ChangeItemTypeNr(nr, -1);
      if (nr < this.ItemTypeCounter)
      {
        int num1 = nr;
        int num2 = this.ItemTypeCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.ItemTypeObj[Newnr] = this.ItemTypeObj[Newnr + 1];
          this.ChangeItemTypeNr(Newnr + 1, Newnr);
        }
      }
      --this.ItemTypeCounter;
      if (this.ItemTypeCounter == -1)
        return;
      this.ItemTypeObj = (ItemTypeClass[]) Utils.CopyArray((Array) this.ItemTypeObj, (Array) new ItemTypeClass[this.ItemTypeCounter + 1]);
    }

    pub void ChangeItemTypeNr(int Oldnr, int Newnr)
    {
      int itemTypeCounter = this.ItemTypeCounter;
      for (int index = 0; index <= itemTypeCounter; index += 1)
      {
        if (this.ItemTypeObj[index].Blocks == Oldnr)
          this.ItemTypeObj[index].Blocks = Newnr;
      }
      int sfTypeCounter = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; index += 1)
      {
        if (this.SFTypeObj[index].ModelItemType == Oldnr)
          this.SFTypeObj[index].ModelItemType = Newnr;
      }
    }

    pub int FindActionCard(ref ActionCardClass e, int origCardSlot, string libname)
    {
      if (Information.IsNothing((object) e))
      {
        int actionCardCounter = this.ActionCardCounter;
        for (int actionCard = 0; actionCard <= actionCardCounter; actionCard += 1)
        {
          if (this.ActionCardObj[actionCard].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.ActionCardObj[actionCard].LibId.libSlot].name, libname, false) == 0 && this.ActionCardObj[actionCard].LibId.id == origCardSlot)
            return actionCard;
        }
      }
      else
      {
        int actionCardCounter = this.ActionCardCounter;
        for (int actionCard = 0; actionCard <= actionCardCounter; actionCard += 1)
        {
          if (this.ActionCardObj[actionCard].LibId.libSlot > -1 && Operators.CompareString(this.LibraryObj[this.ActionCardObj[actionCard].LibId.libSlot].name, libname, false) == 0 && Operators.CompareString(this.ActionCardObj[actionCard].Title, e.Title, false) == 0 & this.ActionCardObj[actionCard].LibId.id == origCardSlot)
            return actionCard;
        }
      }
      return -1;
    }

    pub void AddActionCard()
    {
      this += 1.ActionCardCounter;
      this.ActionCardObj = (ActionCardClass[]) Utils.CopyArray((Array) this.ActionCardObj, (Array) new ActionCardClass[this.ActionCardCounter + 1]);
      this.ActionCardObj[this.ActionCardCounter] = ActionCardClass::new();
    }

    pub void RemoveActionCard(int nr, bool QuickMode = false)
    {
      this.ChangeActionCardNr(nr, -1, QuickMode);
      if (nr < this.ActionCardCounter)
      {
        int num1 = nr;
        int num2 = this.ActionCardCounter - 1;
        for (int Newnr = num1; Newnr <= num2; Newnr += 1)
        {
          this.ActionCardObj[Newnr] = this.ActionCardObj[Newnr + 1];
          this.ChangeActionCardNr(Newnr + 1, Newnr, QuickMode);
        }
      }
      --this.ActionCardCounter;
      if (this.ActionCardCounter == -1)
        return;
      this.ActionCardObj = (ActionCardClass[]) Utils.CopyArray((Array) this.ActionCardObj, (Array) new ActionCardClass[this.ActionCardCounter + 1]);
    }

    pub void ChangeActionCardNr(int Oldnr, int Newnr, bool QuickMode = false)
    {
      int index1;
      if (!QuickMode)
      {
        int stringListCounter = this.StringListCounter;
        for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
        {
          int width = this.StringListObj[index2].Width;
          for (int index3 = 0; index3 <= width; index3 += 1)
          {
            int length = this.StringListObj[index2].Length;
            for (int index4 = 0; index4 <= length; index4 += 1)
            {
              if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.ActionCardId && this.StringListObj[index2].Data[index4, index3].Length > 0)
              {
                index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
                if (index1 == Oldnr)
                  index1 = Newnr;
                this.StringListObj[index2].Data[index4, index3] = index1.ToString();
              }
            }
          }
        }
        for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
        {
          if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.ActionCardId & this.LibVarObj[libVarCounter].value == Oldnr)
          {
            if (Newnr == -1)
              this.RemoveLibVar(libVarCounter);
            else
              this.LibVarObj[libVarCounter].value = Newnr;
          }
        }
      }
      int regimeCounter = this.RegimeCounter;
      for (index1 = 0; index1 <= regimeCounter; index1 += 1)
      {
        for (int actionCardCounter = this.RegimeObj[index1].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
        {
          if (Newnr > -1)
          {
            if (this.RegimeObj[index1].ActionCard[actionCardCounter] == Oldnr)
              this.RegimeObj[index1].ActionCard[actionCardCounter] = Newnr;
          }
          else if (this.RegimeObj[index1].ActionCard[actionCardCounter] == Oldnr)
            this.RegimeObj[index1].RemoveActionCard(actionCardCounter);
        }
      }
      if (QuickMode)
        return;
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (index1 = 0; index1 <= historicalUnitCounter; index1 += 1)
      {
        for (int deckCardCounter = this.HistoricalUnitObj[index1].DeckCardCounter; deckCardCounter >= 0; deckCardCounter += -1)
        {
          if (this.HistoricalUnitObj[index1].DeckCard[deckCardCounter] == Oldnr)
          {
            if (Newnr == -1)
            {
              int num1 = deckCardCounter;
              int index5 = index1;
              if (num1 < this.HistoricalUnitObj[index5].DeckCardCounter)
              {
                int num2 = num1;
                int num3 = this.HistoricalUnitObj[index5].DeckCardCounter - 1;
                for (int index6 = num2; index6 <= num3; index6 += 1)
                {
                  this.HistoricalUnitObj[index5].DeckCard[index6] = this.HistoricalUnitObj[index5].DeckCard[index6 + 1];
                  this.HistoricalUnitObj[index5].DeckChance[index6] = this.HistoricalUnitObj[index5].DeckChance[index6 + 1];
                }
              }
              int num4 = num1 - 1;
              HistoricalUnitClass[] historicalUnitObj = this.HistoricalUnitObj;
              HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
              int index7 = index5;
              int index8 = index7;
              historicalUnitClassArray[index8].DeckCardCounter = historicalUnitObj[index7].DeckCardCounter - 1;
              if (this.HistoricalUnitObj[index5].DeckCardCounter > -1 & num4 == -1)
                ;
              if (this.HistoricalUnitObj[index5].DeckCardCounter > -1)
              {
                this.HistoricalUnitObj[index5].DeckCard = (int[]) Utils.CopyArray((Array) this.HistoricalUnitObj[index5].DeckCard, (Array) new int[this.HistoricalUnitObj[index5].DeckCardCounter + 1]);
                this.HistoricalUnitObj[index5].DeckChance = (int[]) Utils.CopyArray((Array) this.HistoricalUnitObj[index5].DeckChance, (Array) new int[this.HistoricalUnitObj[index5].DeckCardCounter + 1]);
              }
            }
            else
              this.HistoricalUnitObj[index1].DeckCard[deckCardCounter] = Newnr;
          }
        }
      }
    }

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      this.Version = 424;
      info.AddValue("Name", (object) this.Name);
      info.AddValue("Description", (object) this.Description);
      info.AddValue("Turn", this.Turn);
      info.AddValue("StepNr", this.StepNr);
      info.AddValue("Round", this.Round);
      this.MapWidth = this.MapObj[0].MapWidth;
      this.MapHeight = this.MapObj[0].MapHeight;
      info.AddValue("MapWidth", this.MapWidth);
      info.AddValue("MapHeight", this.MapHeight);
      info.AddValue("ShrowdOn", this.ShrowdOn);
      info.AddValue("FOWOn", this.FOWOn);
      info.AddValue("UncertaintyOn", this.UncertaintyOn);
      info.AddValue("ResMod", this.ResMod);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("HexObj", (object) this.HexObj);
      info.AddValue("LandscapeTypeCounter", this.LandscapeTypeCounter);
      info.AddValue("LandscapeTypeObj", (object) this.LandscapeTypeObj);
      info.AddValue("RoadTypeCounter", this.RoadTypeCounter);
      info.AddValue("RoadTypeObj", (object) this.RoadTypeObj);
      info.AddValue("RegimeCounter", this.RegimeCounter);
      info.AddValue("RegimeObj", (object) this.RegimeObj);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("UnitCounter", this.UnitCounter);
      info.AddValue("UnitObj", (object) this.UnitObj);
      info.AddValue("SFCounter", this.SFCounter);
      info.AddValue("SFObj", (object) this.SFObj);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("SFTypeCounter", this.SFTypeCounter);
      info.AddValue("SFTypeObj", (object) this.SFTypeObj);
      info.AddValue("StringCounter", this.StringCounter);
      info.AddValue("TempString", (object) this.TempString);
      info.AddValue("LocTypeCounter", this.LocTypeCounter);
      info.AddValue("LocTypeObj", (object) this.LocTypeObj);
      info.AddValue("LocCounter", this.LocCounter);
      info.AddValue("LocObj", (object) this.LocObj);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("ItemTypeCounter", this.ItemTypeCounter);
      info.AddValue("ItemTypeObj", (object) this.ItemTypeObj);
      info.AddValue("PeopleCounter", this.PeopleCounter);
      info.AddValue("PeopleObj", (object) this.PeopleObj);
      info.AddValue("GameSlot", (object) this.GameSlot);
      info.AddValue("GameSlotName", (object) this.GameSlotName);
      info.AddValue("RegimeSlotName", (object) this.RegimeSlotName);
      info.AddValue("RuleCounter", this.RuleCounter);
      info.AddValue("RuleVar", (object) this.RuleVar);
      info.AddValue("RuleGroup", (object) this.RuleGroup);
      info.AddValue("RiverTypeCounter", this.RiverTypeCounter);
      info.AddValue("RiverTypeObj", (object) this.RiverTypeObj);
      info.AddValue("HistoricalUnitCounter", this.HistoricalUnitCounter);
      info.AddValue("HistoricalUnitObj", (object) this.HistoricalUnitObj);
      info.AddValue("HistoricalIDCounter", this.HistoricalIDCounter);
      info.AddValue("AreaCounter", this.AreaCounter);
      info.AddValue("AreaObj", (object) this.AreaObj);
      info.AddValue("AreaIDCounter", this.AreaIDCounter);
      info.AddValue("BridgeObj", (object) this.BridgeObj);
      info.AddValue("ActionCardCounter", this.ActionCardCounter);
      info.AddValue("ActionCardObj", (object) this.ActionCardObj);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("MapCounter", this.MapCounter);
      info.AddValue("MapObj", (object) this.MapObj);
      info.AddValue("ResearchCounter", this.ResearchCounter);
      info.AddValue("ResearchObj", (object) this.ResearchObj);
      info.AddValue("EventCounter", this.EventCounter);
      info.AddValue("EventObj", (object) this.EventObj);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("EventPicCounter", this.EventPicCounter);
      info.AddValue("EventPicName", (object) this.EventPicName);
      info.AddValue("EventPicNr", (object) this.EventPicNr);
      info.AddValue("EventPicLibId", (object) this.eventPicLibId);
      info.AddValue("SmallPicCounter", this.SmallPicCounter);
      info.AddValue("SmallPicName", (object) this.SmallPicName);
      info.AddValue("SmallPicNr", (object) this.SmallPicNr);
      info.AddValue("SmallLibId", (object) this.SmallLibId);
      info.AddValue("ReinfCounter", this.ReinfCounter);
      info.AddValue("ReinfName", (object) this.ReinfName);
      info.AddValue("ReinfId", (object) this.ReinfId);
      info.AddValue("ReinfLibId", (object) this.ReinfLibId);
      info.AddValue("ReinfIdCounter", this.reinfIdCounter);
      info.AddValue("ReinfRatio", (object) this.ReinfRatio);
      info.AddValue("LoadPass", (object) this.LoadPass);
      info.AddValue("EditPass", (object) this.EditPass);
      info.AddValue("MasterFile", (object) this.MasterFile);
      info.AddValue("VPWin", this.VPWin);
      info.AddValue("Winner", this.Winner);
      info.AddValue("LastWinner", this.LastWinner);
      info.AddValue("PasswordsOn", this.PasswordsOn);
      info.AddValue("InTurn", this.InTurn);
      info.AddValue("Version", this.Version);
      GC.Collect();
      Application.DoEvents();
      info.AddValue("AlternateRound", this.AlternateRound);
      info.AddValue("AlternateRound2", this.AlternateRound2);
      info.AddValue("StartData", this.StartData);
      info.AddValue("ResCostMod", this.ResCostMod);
      info.AddValue("SupplyMultiplier", this.SupplyMultiplier);
      info.AddValue("PPMultiplier", this.PPMultiplier);
      info.AddValue("AsOn", this.ASOn);
      info.AddValue("RegimeSlotShow", (object) this.RegimeSlotShow);
      info.AddValue("RegimeSlotShow2", (object) this.RegimeSlotShow2);
      info.AddValue("RegimeSlotnato", (object) this.RegimeSlotNato);
      info.AddValue("RegimeSlotSmallGfx", (object) this.RegimeSlotSmallGfx);
      info.AddValue("GameSlotShow", (object) this.GameSlotShow);
      info.AddValue("GameSlotShow2", (object) this.GameSlotShow2);
      info.AddValue("GameSlotNato", (object) this.GameSlotNato);
      info.AddValue("GameSlotSmallGfx", (object) this.GameSlotSmallGfx);
      info.AddValue("NoPlayChoice", this.NoPlayChoice);
      info.AddValue("NoAIAdvice", this.NoAIAdvice);
      info.AddValue("PBEM", this.PBEM);
      info.AddValue("ScreenShotOn", this.ScreenShotOn);
      info.AddValue("CreatedWithShrowd", this.CreatedWithShrowd);
      info.AddValue("ShrowdPeek", this.ShrowdPeek);
      info.AddValue("Variants", (object) this.Variants);
      info.AddValue("MoveTypePenalty", (object) this.MoveTypePenalty);
      info.AddValue("UnitTypePenalty", (object) this.UnitTypePenalty);
      info.AddValue("WheaterColor", (object) this.WheaterColor);
      info.AddValue("Designer", (object) this.Designer);
      info.AddValue("Designer2", (object) this.Designer2);
      info.AddValue("MasterfileReadPeople", this.MasterfileReadPeople);
      info.AddValue("GameID", this.GameID);
      info.AddValue("AutoSave", this.AutoSave);
      this.MapLoop = this.MapObj[0].MapLoop;
      info.AddValue("MapLoop", this.MapLoop);
      info.AddValue("LoadGame", (object) this.LoadGame);
      info.AddValue("UseAI", this.UseAI);
      info.AddValue("SystemGfx", (object) this.SystemGfx);
      info.AddValue("ScenarioDir", (object) this.ScenarioDir);
      info.AddValue("SoundDir", (object) this.SoundDir);
      info.AddValue("CampaignRoom", this.CampaignRoom);
      info.AddValue("DontShowAIMove", this.DontShowAIMove);
      info.AddValue("StringListCounter", this.StringListCounter);
      info.AddValue("StringIDCounter", this.StringIDCounter);
      info.AddValue("StringListObj", (object) this.StringListObj);
      info.AddValue("VariantEvent", (object) this.VariantEvent);
      int num = 7;
      this.Product = !DrawMod.TGame.SuperAdminRights ? num : this.Product;
      info.AddValue("Product", this.Product);
      info.AddValue("SFModelIDCounter", this.SFModelIDCounter);
      info.AddValue("TurnString", (object) this.TurnString);
      info.AddValue("Loadable", this.Loadable);
      info.AddValue("Verify1", this.Verify1);
      info.AddValue("Verify2", this.Verify2);
      info.AddValue("RuleSetName", (object) this.RuleSetName);
      info.AddValue("DoAllied", this.DoAllied);
      info.AddValue("PermanentOverlayUse", this.PermanentOverlayUse);
      info.AddValue("PermanentOverlayName", (object) this.PermanentOverlayName);
      info.AddValue("PbemGameID", this.PbemGameID);
      info.AddValue("PbemPlayer1", (object) this.PbemPlayer1);
      info.AddValue("PbemPlayer2", (object) this.PbemPlayer2);
      info.AddValue("PbemGameOver", this.PbemGameOver);
      info.AddValue("PbemDrawGame", this.PbemDrawGame);
      info.AddValue("LibraryCounter", this.LibraryCounter);
      info.AddValue("LibraryObj", (object) this.LibraryObj);
      info.AddValue("LibVarCounter", this.LibVarCounter);
      info.AddValue("LibVarObj", (object) this.LibVarObj);
      info.AddValue("SimpleEditor", this.SimpleEditor);
      info.AddValue("RegimeIdCounter", this.RegimeIdCounter);
      info.AddValue("SFTypeIdCounter", this.SFTypeIdCounter);
      info.AddValue("PeopleIdCounter", this.PeopleIdCounter);
      info.AddValue("EventIdCounter", this.EventIdCounter);
      info.AddValue("LocIdCounter", RuntimeHelpers.GetObjectValue(this.LocIdCounter));
      info.AddValue("ExtraTabName", (object) this.ExtraTabName);
      info.AddValue("ExtraTabEvent", this.ExtraTabEvent);
      info.AddValue("ExtraTabName2", (object) this.ExtraTabName2);
      info.AddValue("ExtraTabEvent2", this.ExtraTabEvent2);
      info.AddValue("ExtraTabName3", (object) this.ExtraTabName3);
      info.AddValue("ExtraTabEvent3", this.ExtraTabEvent3);
      info.AddValue("ExtraTabName4", (object) this.ExtraTabName4);
      info.AddValue("ExtraTabEvent4", this.ExtraTabEvent4);
      info.AddValue("MapName", (object) this.MapName);
      info.AddValue("MapDesigner", (object) this.MapDesigner);
      info.AddValue("MapVersion", this.MapVersion);
      info.AddValue("CombatLogId", this.CombatLogId);
      info.AddValue("scenarioVersion", (object) this.scenarioVersion);
      info.AddValue("scenarioVersionMaster", (object) this.scenarioVersionMaster);
      info.AddValue("transportMovementType", (object) this.transportMovementType);
      info.AddValue("se1_earlyCinematicsLogin", this.se1_earlyCinematicsLogin);
      info.AddValue("specialSaveMode", this.specialSaveMode);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    protected DataClass(SerializationInfo info, StreamingContext context)
    {
      this.GameSlot = new int[500];
      this.GameSlotName = new string[500];
      this.GameSlotShow = new bool[500];
      this.GameSlotShow2 = new bool[500];
      this.RegimeSlotName = new string[500];
      this.RegimeSlotShow = new bool[500];
      this.RegimeSlotShow2 = new int[500];
      this.RegimeSlotNato = new int[500];
      this.RegimeSlotSmallGfx = new int[500];
      this.RealTempString = new string[1000];
      this.GameSlotNato = new int[500];
      this.GameSlotSmallGfx = new int[500];
      this.MapObj = new MapClass[1];
      this.LibraryObj = new LibraryClass[1];
      this.LibVarObj = new LibVarClass[1];
      this.HexObj = new HexClass[1, 1];
      this.LandscapeTypeObj = new LandscapeTypeClass[1];
      this.RoadTypeObj = new RoadTypeClass[1];
      this.RegimeObj = new RegimeClass[1];
      this.UnitObj = new UnitClass[1];
      this.SFObj = new SFClass[1];
      this.SFTypeObj = new SFTypeClass[1];
      this.LocTypeObj = new LocationTypeClass[1];
      this.LocObj = new LocationClass[1];
      this.ItemTypeObj = new ItemTypeClass[1];
      this.PeopleObj = new PeopleClass[1];
      this.StringCounter = 1500;
      this.TempString = new string[1501];
      this.RuleVar = new float[1001];
      this.RuleString = new string[1001];
      this.RuleGroup = new int[1001];
      this.RuleGroup2 = new int[1001];
      this.RuleCounter = 1000;
      this.RiverTypeObj = new RiverTypeClass[1];
      this.AreaObj = new AreaClass[1];
      this.HistoricalUnitObj = new HistoricalUnitClass[1];
      this.BridgeObj = new BridgeClass[1];
      this.ActionCardObj = new ActionCardClass[1];
      this.ResearchObj = new ResearchClass[1];
      this.EventObj = new EventClass[1];
      this.EventPicName = new string[1];
      this.EventPicNr = new int[1];
      this.eventPicLibId = new LibIdClass[1];
      this.SmallPicName = new string[1];
      this.SmallPicNr = new int[1];
      this.SmallLibId = new LibIdClass[1];
      this.ReinfName = new string[1];
      this.ReinfLibId = new LibIdClass[1];
      this.ReinfId = new int[1];
      this.StringListObj = new StringListClass[1];
      this.CheckTypeNames = new string[400];
      this.ExecTypeNames = new string[400];
      this.CheckTypeVarName = new string[300, 5];
      this.CheckTypeVarCount = new int[300];
      this.CheckDesc = new string[300];
      this.CheckCategory = new int[300];
      this.CheckCategory2 = new int[300];
      this.ExecCategory = new int[400];
      this.ExecCategory2 = new int[400];
      this.ExecTypeVarName = new string[400, 5];
      this.ExecTypeVarCount = new int[400];
      this.ExecDesc = new string[400];
      this.ExecTypeString = new int[400];
      this.TempVar = new int[1000];
      this.ExecCategoryName = new string[100];
      this.CheckCategoryName = new string[100];
      this.Variants = new int[12];
      this.VariantEvent = new int[12];
      this.MoveTypePenalty = new int[100];
      this.UnitTypePenalty = new int[100];
      this.WheaterColor = new int[3];
      this.ReinfRatio = new int[50];
      this.transportMovementType = new int[100];
      this.se1_earlyCinematicsLogin = 0;
      this.Version = info.GetInt32(nameof (Version));
      try
      {
        this.Product = info.GetInt32(nameof (Product));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Product = -1;
        ProjectData.ClearProjectError();
      }
      int num1 = 7;
      if (!DrawMod.TGame.SuperAdminRights)
      {
        if (num1 != 0)
          ;
        if (num1 == 1 | num1 == 3 && this.Product != num1)
        {
          int num2 =  Interaction.MsgBox((object) "This file could not be loaded. We have to Quit the application due to this. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.EndApp();
        }
        if (num1 == 2 && this.Product == 1 | this.Product == 0)
        {
          if (this.Version >= 185)
          {
            int num3 =  Interaction.MsgBox((object) "This file could not be loaded. We have to Quit the application due to this. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
            ProjectData.EndApp();
          }
          else
            this.Product = 2;
        }
        if (num1 == 4 && this.Product != 4)
        {
          int num4 =  Interaction.MsgBox((object) "This file might have the propper file extension but is not a real DC3 file. This file could not be loaded. We have to Quit the application due to this. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.EndApp();
        }
        if (num1 == 5 && this.Product != 5)
        {
          int num5 =  Interaction.MsgBox((object) "This file have the propper file extension but is not a real DCX file. This file could not be loaded. We have to Quit the application due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.EndApp();
        }
        if (num1 == 6 && this.Product != 6)
        {
          int num6 =  Interaction.MsgBox((object) "This file have the propper file extension but is not a real DC4 file. This file could not be loaded. We have to Quit the application due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.EndApp();
        }
        if (num1 == 7 && this.Product != 7)
        {
          int num7 =  Interaction.MsgBox((object) "This file have the propper file extension but is not a real SE1 file. This file could not be loaded. We have to Quit the application due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
          ProjectData.EndApp();
        }
      }
      if (this.Version > 424)
      {
        int num8 =  Interaction.MsgBox((object) ("You are loading a scenario or saved game made with version " + Conversion.Str((object) (this.Version - 314)) + ". Your version is " + Conversion.Str((object) 110) + ". This could cause errors. You are advised to upgrade to the latest version of this Shadow Empire : Planetary Conquest."), Title: ((object) "You should upgrade to the latest version!"));
      }
      if (this.Version < 424)
      {
        int num9 =  Interaction.MsgBox((object) ("You are loading a scenario or saved game made with a previous version " + Conversion.Str((object) (this.Version - 314)) + ". This is probably incompatible with the current game version " + Conversion.Str((object) 110) + "."));
      }
      DrawMod.TGame.Data.Version = this.Version;
      this.Name = info.GetString(nameof (Name));
      this.Description = info.GetString(nameof (Description));
      this.Turn = info.GetInt32(nameof (Turn));
      this.StepNr = info.GetInt32(nameof (StepNr));
      this.Round = info.GetInt32(nameof (Round));
      if (DrawMod.TGame.Data.Version < 181)
      {
        try
        {
          this.MapCounter = info.GetInt32(nameof (MapCounter));
          this.MapObj = this.MapCounter <= -1 ? new MapClass[1] : new MapClass[this.MapCounter + 1];
          this.MapObj = (MapClass[]) info.GetValue(nameof (MapObj), this.MapObj.GetType());
          try
          {
            this.MapWidth = info.GetInt32(nameof (MapWidth));
            this.MapHeight = info.GetInt32(nameof (MapHeight));
            DrawMod.TGame.Data.MapWidth = this.MapWidth;
            DrawMod.TGame.Data.MapHeight = this.MapHeight;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.MapWidth = 0;
            this.MapHeight = 0;
            ProjectData.ClearProjectError();
          }
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          this.MapCounter = 0;
          this.MapObj = new MapClass[1];
          this.MapWidth = info.GetInt32(nameof (MapWidth));
          this.MapHeight = info.GetInt32(nameof (MapHeight));
          try
          {
            this.MapLoop = (uint) info.GetInt32(nameof (MapLoop)) > 0U;
          }
          catch (Exception ex2)
          {
            ProjectData.SetProjectError(ex2);
            this.MapLoop = false;
            ProjectData.ClearProjectError();
          }
          DrawMod.TGame.Data.MapWidth = this.MapWidth;
          DrawMod.TGame.Data.MapHeight = this.MapHeight;
          this.MapObj[0] = new MapClass(0, this.RegimeCounter, this.MapWidth, this.MapHeight);
          this.MapObj[0].HexObj = new HexClass[this.MapWidth + 1, this.MapHeight + 1];
          this.MapObj[0].HexObj = (HexClass[,]) info.GetValue(nameof (HexObj), this.HexObj.GetType());
          this.MapObj[0].Name = "Default Map";
          this.MapObj[0].MapLoop = this.MapLoop;
          this.MapObj[0].MapWidth = this.MapWidth;
          this.MapObj[0].MapHeight = this.MapHeight;
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.MapWidth = info.GetInt32(nameof (MapWidth));
        this.MapHeight = info.GetInt32(nameof (MapHeight));
        DrawMod.TGame.Data.MapWidth = this.MapWidth;
        DrawMod.TGame.Data.MapHeight = this.MapHeight;
        this.MapCounter = info.GetInt32(nameof (MapCounter));
        this.MapObj = this.MapCounter <= -1 ? new MapClass[1] : new MapClass[this.MapCounter + 1];
        this.MapObj = (MapClass[]) info.GetValue(nameof (MapObj), this.MapObj.GetType());
      }
      GC.Collect();
      Application.DoEvents();
      this.ShrowdOn = info.GetBoolean(nameof (ShrowdOn));
      this.FOWOn = info.GetBoolean(nameof (FOWOn));
      try
      {
        this.UncertaintyOn = info.GetBoolean(nameof (UncertaintyOn));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UncertaintyOn = false;
        ProjectData.ClearProjectError();
      }
      this.ResMod = info.GetInt32(nameof (ResMod));
      if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.StringListCounter = info.GetInt32(nameof (StringListCounter));
          this.StringIDCounter = info.GetInt32(nameof (StringIDCounter));
          this.StringListObj = new StringListClass[this.StringListCounter + 1];
          this.StringListObj = (StringListClass[]) info.GetValue(nameof (StringListObj), this.StringListObj.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.StringListCounter = -1;
          this.StringIDCounter = 0;
          this.StringListObj = new StringListClass[1];
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.StringListCounter = info.GetInt32(nameof (StringListCounter));
        this.StringIDCounter = info.GetInt32(nameof (StringIDCounter));
        this.StringListObj = new StringListClass[this.StringListCounter + 1];
        this.StringListObj = (StringListClass[]) info.GetValue(nameof (StringListObj), this.StringListObj.GetType());
      }
      GC.Collect();
      Application.DoEvents();
      this.LandscapeTypeCounter = info.GetInt32(nameof (LandscapeTypeCounter));
      this.LandscapeTypeObj = this.LandscapeTypeCounter <= -1 ? new LandscapeTypeClass[1] : new LandscapeTypeClass[this.LandscapeTypeCounter + 1];
      this.LandscapeTypeObj = (LandscapeTypeClass[]) info.GetValue(nameof (LandscapeTypeObj), this.LandscapeTypeObj.GetType());
      this.RoadTypeCounter = info.GetInt32(nameof (RoadTypeCounter));
      this.RoadTypeObj = this.RoadTypeCounter <= -1 ? new RoadTypeClass[1] : new RoadTypeClass[this.RoadTypeCounter + 1];
      this.RoadTypeObj = (RoadTypeClass[]) info.GetValue(nameof (RoadTypeObj), this.RoadTypeObj.GetType());
      this.RegimeCounter = info.GetInt32(nameof (RegimeCounter));
      this.RegimeObj = this.RegimeCounter <= -1 ? new RegimeClass[1] : new RegimeClass[this.RegimeCounter + 1];
      GC.Collect();
      Application.DoEvents();
      this.RegimeObj = (RegimeClass[]) info.GetValue(nameof (RegimeObj), this.RegimeObj.GetType());
      this.UnitCounter = info.GetInt32(nameof (UnitCounter));
      this.UnitObj = this.UnitCounter <= -1 ? new UnitClass[1] : new UnitClass[this.UnitCounter + 1];
      this.UnitObj = (UnitClass[]) info.GetValue(nameof (UnitObj), this.UnitObj.GetType());
      this.SFCounter = info.GetInt32(nameof (SFCounter));
      this.SFObj = this.SFCounter <= -1 ? new SFClass[1] : new SFClass[this.SFCounter + 1];
      GC.Collect();
      Application.DoEvents();
      this.SFObj = (SFClass[]) info.GetValue(nameof (SFObj), this.SFObj.GetType());
      this.SFTypeCounter = info.GetInt32(nameof (SFTypeCounter));
      this.SFTypeObj = this.SFTypeCounter <= -1 ? new SFTypeClass[1] : new SFTypeClass[this.SFTypeCounter + 1];
      this.SFTypeObj = (SFTypeClass[]) info.GetValue(nameof (SFTypeObj), this.SFTypeObj.GetType());
      try
      {
        this.MapLoop = info.GetBoolean(nameof (MapLoop));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.MapLoop = false;
        ProjectData.ClearProjectError();
      }
      GC.Collect();
      Application.DoEvents();
      this.StringCounter = info.GetInt32(nameof (StringCounter));
      this.TempString = new string[this.StringCounter + 1];
      this.TempString = (string[]) info.GetValue(nameof (TempString), this.TempString.GetType());
      if (this.StringCounter < 1500)
        this.StringCounter = 1500;
      this.TempString = (string[]) Utils.CopyArray((Array) this.TempString, (Array) new string[this.StringCounter + 1]);
      this.LocTypeCounter = info.GetInt32(nameof (LocTypeCounter));
      this.LocTypeObj = new LocationTypeClass[this.LocTypeCounter + 1];
      this.LocTypeObj = (LocationTypeClass[]) info.GetValue(nameof (LocTypeObj), this.LocTypeObj.GetType());
      this.LocCounter = info.GetInt32(nameof (LocCounter));
      this.LocObj = new LocationClass[this.LocCounter + 1];
      this.LocObj = (LocationClass[]) info.GetValue(nameof (LocObj), this.LocObj.GetType());
      this.ActionCardCounter = info.GetInt32(nameof (ActionCardCounter));
      if (this.ActionCardCounter > -1)
      {
        this.ActionCardObj = new ActionCardClass[this.ActionCardCounter + 1];
        this.ActionCardObj = (ActionCardClass[]) info.GetValue(nameof (ActionCardObj), this.ActionCardObj.GetType());
      }
      else
        this.ActionCardObj = new ActionCardClass[1];
      this.ItemTypeCounter = info.GetInt32(nameof (ItemTypeCounter));
      this.ItemTypeObj = new ItemTypeClass[this.ItemTypeCounter + 1];
      this.ItemTypeObj = (ItemTypeClass[]) info.GetValue(nameof (ItemTypeObj), this.ItemTypeObj.GetType());
      this.PeopleCounter = info.GetInt32(nameof (PeopleCounter));
      this.PeopleObj = new PeopleClass[this.PeopleCounter + 1];
      this.PeopleObj = (PeopleClass[]) info.GetValue(nameof (PeopleObj), this.PeopleObj.GetType());
      this.GameSlot = (int[]) info.GetValue(nameof (GameSlot), this.GameSlot.GetType());
      this.GameSlotName = (string[]) info.GetValue(nameof (GameSlotName), this.GameSlotName.GetType());
      this.RegimeSlotName = (string[]) info.GetValue(nameof (RegimeSlotName), this.RegimeSlotName.GetType());
      this.RiverTypeCounter = info.GetInt32(nameof (RiverTypeCounter));
      this.RiverTypeObj = new RiverTypeClass[this.RiverTypeCounter + 1];
      this.RiverTypeObj = (RiverTypeClass[]) info.GetValue(nameof (RiverTypeObj), this.RiverTypeObj.GetType());
      this.BridgeObj = new BridgeClass[1];
      this.BridgeObj = (BridgeClass[]) info.GetValue(nameof (BridgeObj), this.BridgeObj.GetType());
      GC.Collect();
      Application.DoEvents();
      this.ResearchCounter = info.GetInt32(nameof (ResearchCounter));
      this.ResearchObj = this.ResearchCounter <= -1 ? new ResearchClass[1] : new ResearchClass[this.ResearchCounter + 1];
      this.ResearchObj = (ResearchClass[]) info.GetValue(nameof (ResearchObj), this.ResearchObj.GetType());
      if (DrawMod.TGame.Data.Version < 182)
      {
        try
        {
          this.HistoricalUnitCounter = info.GetInt32(nameof (HistoricalUnitCounter));
          this.HistoricalUnitObj = this.HistoricalUnitCounter <= -1 ? new HistoricalUnitClass[1] : new HistoricalUnitClass[this.HistoricalUnitCounter + 1];
          this.HistoricalUnitObj = (HistoricalUnitClass[]) info.GetValue(nameof (HistoricalUnitObj), this.HistoricalUnitObj.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.HistoricalUnitCounter = -1;
          this.HistoricalUnitObj = new HistoricalUnitClass[1];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.HistoricalIDCounter = info.GetInt32(nameof (HistoricalIDCounter));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.HistoricalIDCounter = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.AreaCounter = info.GetInt32(nameof (AreaCounter));
          this.AreaObj = this.AreaCounter <= -1 ? new AreaClass[1] : new AreaClass[this.AreaCounter + 1];
          this.AreaIDCounter = info.GetInt32(nameof (AreaIDCounter));
          this.AreaObj = (AreaClass[]) info.GetValue(nameof (AreaObj), this.AreaObj.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AreaCounter = -1;
          this.AreaObj = new AreaClass[1];
          this.AreaIDCounter = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.RegimeSlotShow2 = (int[]) info.GetValue(nameof (RegimeSlotShow2), this.RegimeSlotShow2.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.RegimeSlotShow2 = new int[500];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.RegimeSlotNato = (int[]) info.GetValue("RegimeSlotnato", this.RegimeSlotNato.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.RegimeSlotNato = new int[500];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.GameSlotNato = (int[]) info.GetValue("RegimeSlotnato", this.GameSlotNato.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.GameSlotNato = new int[500];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.RegimeSlotSmallGfx = (int[]) info.GetValue(nameof (RegimeSlotSmallGfx), this.RegimeSlotSmallGfx.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.RegimeSlotSmallGfx = new int[500];
          int index = 0;
          do
          {
            this.RegimeSlotSmallGfx[index] = -1;
            index += 1;
          }
          while (index <= 499);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.GameSlotSmallGfx = (int[]) info.GetValue(nameof (RegimeSlotSmallGfx), this.GameSlotSmallGfx.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.GameSlotSmallGfx = new int[500];
          int index = 0;
          do
          {
            this.GameSlotSmallGfx[index] = -1;
            index += 1;
          }
          while (index <= 499);
          ProjectData.ClearProjectError();
        }
        this.GameSlotShow = (bool[]) info.GetValue(nameof (GameSlotShow), this.GameSlotShow.GetType());
        try
        {
          this.GameSlotShow2 = (bool[]) info.GetValue(nameof (GameSlotShow2), this.GameSlotShow2.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Variants = (int[]) info.GetValue(nameof (Variants), this.Variants.GetType());
          this.VariantEvent = (int[]) info.GetValue(nameof (VariantEvent), this.VariantEvent.GetType());
        }
        catch (Exception ex3)
        {
          ProjectData.SetProjectError(ex3);
          int[] numArray = new int[10];
          this.Variants = new int[10];
          this.VariantEvent = new int[10];
          this.Variants = (int[]) info.GetValue(nameof (Variants), numArray.GetType());
          try
          {
            this.VariantEvent = (int[]) info.GetValue(nameof (VariantEvent), numArray.GetType());
          }
          catch (Exception ex4)
          {
            ProjectData.SetProjectError(ex4);
            int index = 0;
            do
            {
              this.VariantEvent[index] = -1;
              index += 1;
            }
            while (index <= 9);
            ProjectData.ClearProjectError();
          }
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        GC.Collect();
        Application.DoEvents();
        this.HistoricalUnitCounter = info.GetInt32(nameof (HistoricalUnitCounter));
        this.HistoricalUnitObj = this.HistoricalUnitCounter <= -1 ? new HistoricalUnitClass[1] : new HistoricalUnitClass[this.HistoricalUnitCounter + 1];
        this.HistoricalUnitObj = (HistoricalUnitClass[]) info.GetValue(nameof (HistoricalUnitObj), this.HistoricalUnitObj.GetType());
        this.HistoricalIDCounter = info.GetInt32(nameof (HistoricalIDCounter));
        this.AreaCounter = info.GetInt32(nameof (AreaCounter));
        this.AreaObj = this.AreaCounter <= -1 ? new AreaClass[1] : new AreaClass[this.AreaCounter + 1];
        this.AreaIDCounter = info.GetInt32(nameof (AreaIDCounter));
        this.AreaObj = (AreaClass[]) info.GetValue(nameof (AreaObj), this.AreaObj.GetType());
        this.RegimeSlotShow2 = (int[]) info.GetValue(nameof (RegimeSlotShow2), this.RegimeSlotShow2.GetType());
        this.RegimeSlotNato = (int[]) info.GetValue("RegimeSlotnato", this.RegimeSlotNato.GetType());
        this.GameSlotNato = (int[]) info.GetValue("RegimeSlotnato", this.GameSlotNato.GetType());
        try
        {
          this.RegimeSlotSmallGfx = (int[]) info.GetValue(nameof (RegimeSlotSmallGfx), this.RegimeSlotSmallGfx.GetType());
          this.GameSlotSmallGfx = (int[]) info.GetValue(nameof (RegimeSlotSmallGfx), this.GameSlotSmallGfx.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.RegimeSlotSmallGfx = new int[500];
          this.GameSlotSmallGfx = new int[500];
          int index = 0;
          do
          {
            this.RegimeSlotSmallGfx[index] = -1;
            this.GameSlotSmallGfx[index] = -1;
            index += 1;
          }
          while (index <= 499);
          ProjectData.ClearProjectError();
        }
        this.GameSlotShow = (bool[]) info.GetValue(nameof (GameSlotShow), this.GameSlotShow.GetType());
        this.GameSlotShow2 = (bool[]) info.GetValue(nameof (GameSlotShow2), this.GameSlotShow2.GetType());
        this.Variants = (int[]) info.GetValue(nameof (Variants), this.Variants.GetType());
        this.VariantEvent = (int[]) info.GetValue(nameof (VariantEvent), this.VariantEvent.GetType());
      }
      this.EventCounter = info.GetInt32(nameof (EventCounter));
      this.EventObj = this.EventCounter <= -1 ? new EventClass[1] : new EventClass[this.EventCounter + 1];
      this.EventObj = (EventClass[]) info.GetValue(nameof (EventObj), this.EventObj.GetType());
      this.EventPicCounter = info.GetInt32(nameof (EventPicCounter));
      if (this.EventPicCounter > -1)
      {
        this.EventPicName = new string[this.EventPicCounter + 1];
        this.EventPicNr = new int[this.EventPicCounter + 1];
        this.eventPicLibId = new LibIdClass[this.EventPicCounter + 1];
      }
      else
      {
        this.EventPicName = new string[1];
        this.EventPicNr = new int[1];
        this.eventPicLibId = new LibIdClass[1];
      }
      this.EventPicName = (string[]) info.GetValue(nameof (EventPicName), this.EventPicName.GetType());
      try
      {
        this.eventPicLibId = (LibIdClass[]) info.GetValue("EventPicLibId", this.eventPicLibId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.eventPicLibId = this.EventPicCounter <= -1 ? new LibIdClass[1] : new LibIdClass[this.EventPicCounter + 1];
        int eventPicCounter = this.EventPicCounter;
        for (int index = 0; index <= eventPicCounter; index += 1)
          this.eventPicLibId[index] = LibIdClass::new();
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SmallPicCounter = info.GetInt32(nameof (SmallPicCounter));
        if (this.SmallPicCounter > -1)
        {
          this.SmallPicName = new string[this.SmallPicCounter + 1];
          this.SmallPicNr = new int[this.SmallPicCounter + 1];
          this.SmallLibId = new LibIdClass[this.SmallPicCounter + 1];
        }
        else
        {
          this.SmallPicName = new string[1];
          this.SmallPicNr = new int[1];
          this.SmallLibId = new LibIdClass[1];
        }
        this.SmallPicName = (string[]) info.GetValue(nameof (SmallPicName), this.SmallPicName.GetType());
        this.SmallLibId = (LibIdClass[]) info.GetValue(nameof (SmallLibId), this.SmallLibId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SmallPicCounter = -1;
        this.SmallPicName = new string[1];
        this.SmallPicNr = new int[1];
        this.SmallLibId = new LibIdClass[1];
        ProjectData.ClearProjectError();
      }
      try
      {
        this.ReinfCounter = info.GetInt32(nameof (ReinfCounter));
        this.reinfIdCounter = info.GetInt32("ReinfIdCounter");
        if (this.ReinfCounter > -1)
        {
          this.ReinfName = new string[this.ReinfCounter + 1];
          this.ReinfId = new int[this.ReinfCounter + 1];
          this.ReinfLibId = new LibIdClass[this.ReinfCounter + 1];
          this.ReinfRatio = new int[this.ReinfCounter + 1];
        }
        else
        {
          this.ReinfName = new string[1];
          this.ReinfId = new int[1];
          this.ReinfLibId = new LibIdClass[1];
          this.ReinfRatio = new int[1];
        }
        this.ReinfName = (string[]) info.GetValue(nameof (ReinfName), this.ReinfName.GetType());
        this.ReinfLibId = (LibIdClass[]) info.GetValue(nameof (ReinfLibId), this.ReinfLibId.GetType());
        this.ReinfId = (int[]) info.GetValue(nameof (ReinfId), this.ReinfId.GetType());
        try
        {
          this.ReinfRatio = (int[]) info.GetValue(nameof (ReinfRatio), this.ReinfRatio.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int reinfCounter = this.ReinfCounter;
          for (int index = 0; index <= reinfCounter; index += 1)
            this.ReinfRatio[index] = 1;
          ProjectData.ClearProjectError();
        }
        if (this.ReinfRatio.GetUpperBound(0) < this.ReinfName.GetUpperBound(0))
          this.ReinfRatio = (int[]) Utils.CopyArray((Array) this.ReinfRatio, (Array) new int[this.ReinfCounter + 1]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.ReinfCounter = -1;
        this.reinfIdCounter = -1;
        this.ReinfName = new string[1];
        this.ReinfId = new int[1];
        this.ReinfLibId = new LibIdClass[1];
        this.ReinfRatio = new int[1];
        ProjectData.ClearProjectError();
      }
      this.LoadPass = info.GetString(nameof (LoadPass));
      this.EditPass = info.GetString(nameof (EditPass));
      this.MasterFile = info.GetString(nameof (MasterFile));
      this.VPWin = info.GetInt32(nameof (VPWin));
      this.Winner = info.GetInt32(nameof (Winner));
      try
      {
        this.LastWinner = info.GetInt32(nameof (LastWinner));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LastWinner = -1;
        ProjectData.ClearProjectError();
      }
      this.RuleVar = (float[]) info.GetValue(nameof (RuleVar), this.RuleVar.GetType());
      this.RuleGroup = (int[]) info.GetValue(nameof (RuleGroup), this.RuleGroup.GetType());
      this.SetDefaultRules(true);
      this.PasswordsOn = info.GetBoolean(nameof (PasswordsOn));
      this.InTurn = info.GetBoolean(nameof (InTurn));
      this.AlternateRound = info.GetInt32(nameof (AlternateRound));
      try
      {
        this.AlternateRound2 = info.GetInt32(nameof (AlternateRound2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AlternateRound2 = -1;
        ProjectData.ClearProjectError();
      }
      this.StartData = info.GetDateTime(nameof (StartData));
      this.ResCostMod = info.GetSingle(nameof (ResCostMod));
      this.SupplyMultiplier = info.GetSingle(nameof (SupplyMultiplier));
      this.PPMultiplier = info.GetSingle(nameof (PPMultiplier));
      this.ASOn = info.GetBoolean("AsOn");
      this.RegimeSlotShow = (bool[]) info.GetValue(nameof (RegimeSlotShow), this.RegimeSlotShow.GetType());
      GC.Collect();
      Application.DoEvents();
      this.NoPlayChoice = info.GetBoolean(nameof (NoPlayChoice));
      this.NoAIAdvice = info.GetBoolean(nameof (NoAIAdvice));
      this.PBEM = info.GetBoolean(nameof (PBEM));
      this.ScreenShotOn = info.GetBoolean(nameof (ScreenShotOn));
      this.CreatedWithShrowd = info.GetBoolean(nameof (CreatedWithShrowd));
      this.ShrowdPeek = info.GetBoolean(nameof (ShrowdPeek));
      if (this.Version >= 405)
      {
        try
        {
          this.LibraryCounter = info.GetInt32(nameof (LibraryCounter));
          this.LibraryObj = this.LibraryCounter <= -1 ? new LibraryClass[1] : new LibraryClass[this.LibraryCounter + 1];
          this.LibraryObj = (LibraryClass[]) info.GetValue(nameof (LibraryObj), this.LibraryObj.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.LibraryCounter = -1;
          this.LibraryObj = new LibraryClass[1];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.LibVarCounter = info.GetInt32(nameof (LibVarCounter));
          this.LibVarObj = this.LibVarCounter <= -1 ? new LibVarClass[1] : new LibVarClass[this.LibVarCounter + 1];
          this.LibVarObj = (LibVarClass[]) info.GetValue(nameof (LibVarObj), this.LibVarObj.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.LibVarCounter = -1;
          this.LibVarObj = new LibVarClass[1];
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.LibraryCounter = -1;
        this.LibraryObj = new LibraryClass[1];
        this.LibVarCounter = -1;
        this.LibVarObj = new LibVarClass[1];
      }
      if (this.Variants.GetUpperBound(0) <= 9 | this.Version < 170)
      {
        this.Variants = (int[]) Utils.CopyArray((Array) this.Variants, (Array) new int[12]);
        this.VariantEvent = (int[]) Utils.CopyArray((Array) this.VariantEvent, (Array) new int[12]);
        this.VariantEvent[10] = -1;
        this.VariantEvent[11] = -1;
        this.Variants[10] = -1;
        this.Variants[11] = -1;
      }
      if (this.Version < 174)
      {
        this.RuleVar[820] = -1f;
        this.RuleVar[822] = -1f;
      }
      if (this.Version < 203)
      {
        if ((double) this.RuleVar[857] == 0.0)
          this.RuleVar[857] = this.RuleVar[99];
        if ((double) this.RuleVar[858] == 0.0)
          this.RuleVar[858] = this.RuleVar[3];
      }
      this.MoveTypePenalty = (int[]) info.GetValue(nameof (MoveTypePenalty), this.MoveTypePenalty.GetType());
      this.UnitTypePenalty = (int[]) info.GetValue(nameof (UnitTypePenalty), this.UnitTypePenalty.GetType());
      this.WheaterColor = (int[]) info.GetValue(nameof (WheaterColor), this.WheaterColor.GetType());
      this.Designer = info.GetString(nameof (Designer));
      this.Designer2 = info.GetString(nameof (Designer2));
      this.MasterfileReadPeople = info.GetBoolean(nameof (MasterfileReadPeople));
      try
      {
        this.SystemGfx = info.GetString(nameof (SystemGfx));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SystemGfx = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.ScenarioDir = info.GetString(nameof (ScenarioDir));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.ScenarioDir = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SoundDir = info.GetString(nameof (SoundDir));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SoundDir = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UseAI = info.GetInt32(nameof (UseAI));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UseAI = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.DontShowAIMove = info.GetBoolean(nameof (DontShowAIMove));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.DontShowAIMove = false;
        ProjectData.ClearProjectError();
      }
      this.SetEventNames();
      try
      {
        this.GameID = info.GetInt32(nameof (GameID));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.GameID = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LoadGame = info.GetString(nameof (LoadGame));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LoadGame = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.CampaignRoom = info.GetInt32(nameof (CampaignRoom));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.CampaignRoom = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SFModelIDCounter = info.GetInt32(nameof (SFModelIDCounter));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SFModelIDCounter = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.TurnString = info.GetString(nameof (TurnString));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.TurnString = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Loadable = info.GetBoolean(nameof (Loadable));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Loadable = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.RuleSetName = info.GetString(nameof (RuleSetName));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RuleSetName = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.DoAllied = info.GetBoolean(nameof (DoAllied));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.DoAllied = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PermanentOverlayUse = info.GetBoolean(nameof (PermanentOverlayUse));
        this.PermanentOverlayName = info.GetString(nameof (PermanentOverlayName));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PermanentOverlayName = "systemgraphics/trans.bmp";
        this.PermanentOverlayUse = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PbemGameID = info.GetInt32(nameof (PbemGameID));
        this.PbemPlayer1 = info.GetString(nameof (PbemPlayer1));
        this.PbemPlayer2 = info.GetString(nameof (PbemPlayer2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PbemGameID = 0;
        this.PbemPlayer1 = "";
        this.PbemPlayer2 = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PbemGameOver = info.GetInt32(nameof (PbemGameOver));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PbemGameOver = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PbemDrawGame = info.GetInt32(nameof (PbemDrawGame));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PbemDrawGame = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SimpleEditor = info.GetBoolean(nameof (SimpleEditor));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SimpleEditor = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.RegimeIdCounter = info.GetInt32(nameof (RegimeIdCounter));
        this.SFTypeIdCounter = info.GetInt32(nameof (SFTypeIdCounter));
        this.PeopleIdCounter = info.GetInt32(nameof (PeopleIdCounter));
        this.EventIdCounter = info.GetInt32(nameof (EventIdCounter));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RegimeIdCounter = -1;
        this.SFTypeIdCounter = -1;
        this.PeopleIdCounter = -1;
        this.EventIdCounter = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LocIdCounter = (object) info.GetInt32("locIdCounter");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LocIdCounter = (object) -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.ExtraTabName = info.GetString(nameof (ExtraTabName));
        this.ExtraTabEvent = info.GetInt32(nameof (ExtraTabEvent));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.ExtraTabEvent = -1;
        this.ExtraTabName = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.ExtraTabName2 = info.GetString(nameof (ExtraTabName2));
        this.ExtraTabEvent2 = info.GetInt32(nameof (ExtraTabEvent2));
        this.ExtraTabName3 = info.GetString(nameof (ExtraTabName3));
        this.ExtraTabEvent3 = info.GetInt32(nameof (ExtraTabEvent3));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.ExtraTabEvent2 = -1;
        this.ExtraTabName2 = "";
        this.ExtraTabEvent3 = -1;
        this.ExtraTabName3 = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.ExtraTabName4 = info.GetString(nameof (ExtraTabName4));
        this.ExtraTabEvent4 = info.GetInt32(nameof (ExtraTabEvent4));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.ExtraTabEvent4 = -1;
        this.ExtraTabName4 = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.MapName = info.GetString(nameof (MapName));
        this.MapDesigner = info.GetString(nameof (MapDesigner));
        this.MapVersion = info.GetInt32(nameof (MapVersion));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.MapName = "Unnamed";
        this.MapDesigner = "Unkown";
        this.MapVersion = 1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.CombatLogId = info.GetInt32(nameof (CombatLogId));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.CombatLogId = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.scenarioVersion = info.GetString(nameof (scenarioVersion));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.scenarioVersion = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.scenarioVersionMaster = info.GetString(nameof (scenarioVersionMaster));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.scenarioVersionMaster = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.transportMovementType = (int[]) info.GetValue(nameof (transportMovementType), this.transportMovementType.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int index = 0;
        do
        {
          this.transportMovementType[index] = 0;
          index += 1;
        }
        while (index <= 99);
        ProjectData.ClearProjectError();
      }
      try
      {
        this.se1_earlyCinematicsLogin = info.GetInt32(nameof (se1_earlyCinematicsLogin));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.se1_earlyCinematicsLogin = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.specialSaveMode = info.GetInt32(nameof (specialSaveMode));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.specialSaveMode = 0;
        ProjectData.ClearProjectError();
      }
      if ((double) this.RuleVar[316] == 0.0)
        this.RuleVar[316] = 1f;
      if ((double) this.RuleVar[317] == 0.0)
        this.RuleVar[317] = 1f;
      if ((double) this.RuleVar[319] == 0.0)
        this.RuleVar[319] = 1f;
      if ((double) DrawMod.TGame.Data.RuleVar[344] == 1.0 & DrawMod.TGame.EditObj.HideUnit == 0)
        DrawMod.TGame.EditObj.HideUnit = 2;
      int index1 = 440;
      do
      {
        if (Operators.CompareString(this.RuleString[index1], "", false) == 0)
          this.RuleVar[index1] = 0.0f;
        index1 += 1;
      }
      while (index1 <= 500);
      this.Version = 424;
    }

    pub void serialize(string fileloc)
    {
      FileStream serializationStream = new FileStream(fileloc, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
      GC.Collect();
      Application.DoEvents();
      BinaryFormatter::new().Serialize((Stream) serializationStream, (object) this);
      serializationStream.Close();
      GC.Collect();
      Application.DoEvents();
    }

    pub static DataClass deserialize(string fileloc)
    {
      FileStream serializationStream = new FileStream(fileloc, FileMode.Open, FileAccess.Read, FileShare.None);
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      GC.Collect();
      Application.DoEvents();
      dataClass1: DataClass = (DataClass) binaryFormatter.Deserialize((Stream) serializationStream);
      serializationStream.Flush();
      serializationStream.Close();
      if ((double) dataClass1.RuleVar[306] == 0.0)
        dataClass1.RuleVar[306] = 0.3f;
      if (Operators.CompareString(dataClass1.Designer, dataClass1.Designer2, false) == 0)
        dataClass1.Designer2 = "";
      int sfTypeCounter1 = dataClass1.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter1; index += 1)
      {
        if (dataClass1.SFTypeObj[index].ModelLastState.GetUpperBound(0) < dataClass1.ResearchCounter)
        {
          dataClass1.SFTypeObj[index].ModelLastState = (int[]) Utils.CopyArray((Array) dataClass1.SFTypeObj[index].ModelLastState, (Array) new int[dataClass1.ResearchCounter + 1]);
          dataClass1.SFTypeObj[index].ModelPossibleImp = (int[]) Utils.CopyArray((Array) dataClass1.SFTypeObj[index].ModelPossibleImp, (Array) new int[dataClass1.ResearchCounter + 1]);
          dataClass1.SFTypeObj[index].ModelImproveEvent = (int[]) Utils.CopyArray((Array) dataClass1.SFTypeObj[index].ModelImproveEvent, (Array) new int[dataClass1.ResearchCounter + 1]);
          dataClass1.SFTypeObj[index].ModelAutoImprovement = (bool[]) Utils.CopyArray((Array) dataClass1.SFTypeObj[index].ModelAutoImprovement, (Array) new bool[dataClass1.ResearchCounter + 1]);
        }
      }
      int locTypeCounter = dataClass1.LocTypeCounter;
      for (int index1 = 0; index1 <= locTypeCounter; index1 += 1)
      {
        int index2 = 0;
        do
        {
          if (dataClass1.LocTypeObj[index1].Research[index2] > dataClass1.ResearchCounter)
            dataClass1.LocTypeObj[index1].Research[index2] = -1;
          index2 += 1;
        }
        while (index2 <= 4);
      }
      if (dataClass1.RegimeIdCounter == -1)
      {
        dataClass1.RegimeIdCounter = 0;
        int regimeCounter = dataClass1.RegimeCounter;
        for (int index = 0; index <= regimeCounter; index += 1)
        {
          if (dataClass1.RegimeObj[index].id >= dataClass1.RegimeIdCounter)
            dataClass1.RegimeIdCounter = dataClass1.RegimeObj[index].id;
        }
      }
      int regimeCounter1 = dataClass1.RegimeCounter;
      for (int index = 0; index <= regimeCounter1; index += 1)
      {
        if (dataClass1.RegimeObj[index].id == -1)
        {
          dataClass1 += 1.RegimeIdCounter;
          dataClass1.RegimeObj[index].id = dataClass1.RegimeIdCounter;
        }
      }
      if (dataClass1.PeopleIdCounter == -1)
      {
        dataClass1.PeopleIdCounter = 0;
        int peopleCounter = dataClass1.PeopleCounter;
        for (int index = 0; index <= peopleCounter; index += 1)
        {
          if (dataClass1.PeopleObj[index].id >= dataClass1.PeopleIdCounter)
            dataClass1.PeopleIdCounter = dataClass1.PeopleObj[index].id;
        }
      }
      int peopleCounter1 = dataClass1.PeopleCounter;
      for (int index = 0; index <= peopleCounter1; index += 1)
      {
        if (dataClass1.PeopleObj[index].id == -1)
        {
          dataClass1 += 1.PeopleIdCounter;
          dataClass1.PeopleObj[index].id = dataClass1.PeopleIdCounter;
        }
      }
      if (dataClass1.EventIdCounter == -1)
      {
        dataClass1.EventIdCounter = 0;
        int eventCounter = dataClass1.EventCounter;
        for (int index = 0; index <= eventCounter; index += 1)
        {
          if (dataClass1.EventObj[index].Id >= dataClass1.EventIdCounter)
            dataClass1.EventIdCounter = dataClass1.EventObj[index].Id;
        }
      }
      int eventCounter1 = dataClass1.EventCounter;
      for (int index = 0; index <= eventCounter1; index += 1)
      {
        if (dataClass1.EventObj[index].Id == -1)
        {
          dataClass1 += 1.EventIdCounter;
          dataClass1.EventObj[index].Id = dataClass1.EventIdCounter;
        }
      }
      if (Operators.ConditionalCompareObjectEqual(dataClass1.LocIdCounter, (object) -1, false))
      {
        dataClass1.LocIdCounter = (object) 0;
        int locCounter = dataClass1.LocCounter;
        for (int index = 0; index <= locCounter; index += 1)
        {
          if (Operators.ConditionalCompareObjectGreaterEqual((object) dataClass1.LocObj[index].ID, dataClass1.LocIdCounter, false))
            dataClass1.LocIdCounter = (object) dataClass1.LocObj[index].ID;
        }
      }
      int locCounter1 = dataClass1.LocCounter;
      for (int index = 0; index <= locCounter1; index += 1)
      {
        if (dataClass1.LocObj[index].ID == -1)
        {
          dataClass2: DataClass = dataClass1;
          dataClass2.LocIdCounter = Operators.AddObject(dataClass2.LocIdCounter, (object) 1);
          dataClass1.LocObj[index].ID = Conversions.ToInteger(dataClass1.LocIdCounter);
        }
      }
      if (dataClass1.SFTypeIdCounter == -1)
      {
        dataClass1.SFTypeIdCounter = 0;
        int sfTypeCounter2 = dataClass1.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter2; index += 1)
        {
          if (dataClass1.SFTypeObj[index].Id >= dataClass1.SFTypeIdCounter)
            dataClass1.SFTypeIdCounter = dataClass1.SFTypeObj[index].Id;
        }
      }
      int sfTypeCounter3 = dataClass1.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter3; index += 1)
      {
        if (dataClass1.SFTypeObj[index].Id == -1)
        {
          dataClass1 += 1.SFTypeIdCounter;
          dataClass1.SFTypeObj[index].Id = dataClass1.SFTypeIdCounter;
        }
      }
      if (dataClass1.reinfIdCounter == -1)
        dataClass1.reinfIdCounter = 0;
      int reinfCounter1 = dataClass1.ReinfCounter;
      for (int index = 0; index <= reinfCounter1; index += 1)
      {
        if (dataClass1.ReinfId[index] > dataClass1.reinfIdCounter)
          dataClass1.reinfIdCounter = dataClass1.ReinfId[index];
      }
      if (dataClass1.ReinfCounter == -1)
      {
        int sfTypeCounter4 = dataClass1.SFTypeCounter;
        for (int index3 = 0; index3 <= sfTypeCounter4; index3 += 1)
        {
          if (dataClass1.SFTypeObj[index3].ReinforcementType > -1)
          {
            str: String = dataClass1.TempString[750 + dataClass1.SFTypeObj[index3].ReinforcementType];
            bool flag = false;
            int reinfCounter2 = dataClass1.ReinfCounter;
            for (int index4 = 0; index4 <= reinfCounter2; index4 += 1)
            {
              if (Operators.CompareString(dataClass1.ReinfName[index4], str, false) == 0)
              {
                flag = true;
                dataClass1.SFTypeObj[index3].ReinforcementType = index4;
                break;
              }
            }
            if (!flag)
            {
              dataClass1.AddReinf(str);
              dataClass1.SFTypeObj[index3].ReinforcementType = dataClass1.ReinfCounter;
            }
          }
          if (dataClass1.SFTypeObj[index3].ReinforcementType2 > -1)
          {
            str: String = dataClass1.TempString[750 + dataClass1.SFTypeObj[index3].ReinforcementType2];
            bool flag = false;
            int reinfCounter3 = dataClass1.ReinfCounter;
            for (int index5 = 0; index5 <= reinfCounter3; index5 += 1)
            {
              if (Operators.CompareString(dataClass1.ReinfName[index5], str, false) == 0)
              {
                flag = true;
                dataClass1.SFTypeObj[index3].ReinforcementType2 = index5;
                break;
              }
            }
            if (!flag)
            {
              dataClass1.AddReinf(str);
              dataClass1.SFTypeObj[index3].ReinforcementType2 = dataClass1.ReinfCounter;
            }
          }
          if (dataClass1.SFTypeObj[index3].ReinforcementType3 > -1)
          {
            str: String = dataClass1.TempString[750 + dataClass1.SFTypeObj[index3].ReinforcementType3];
            bool flag = false;
            int reinfCounter4 = dataClass1.ReinfCounter;
            for (int index6 = 0; index6 <= reinfCounter4; index6 += 1)
            {
              if (Operators.CompareString(dataClass1.ReinfName[index6], str, false) == 0)
              {
                flag = true;
                dataClass1.SFTypeObj[index3].ReinforcementType3 = index6;
                break;
              }
            }
            if (!flag)
            {
              dataClass1.AddReinf(str);
              dataClass1.SFTypeObj[index3].ReinforcementType3 = dataClass1.ReinfCounter;
            }
          }
        }
        int index = 750;
        do
        {
          dataClass1.TempString[index] = "";
          index += 1;
        }
        while (index <= 799);
      }
      if (dataClass1.Product == -1 & dataClass1.Version < 130)
        dataClass1.RuleSetName = "Imported old AT scenario";
      if (dataClass1.Product == 4 & Strings.InStr(dataClass1.Name.ToLower(), "barbarossa") > 0)
        dataClass1.RuleVar[999] = 1f;
      if (dataClass1.Product <= 5)
      {
        int index = 401;
        do
        {
          dataClass1.RuleVar[index] = 0.0f;
          index += 1;
        }
        while (index <= 499);
        dataClass1.RuleVar[540] = 0.0f;
      }
      return dataClass1;
    }

    pub void LoadGraphics(Form1 tformref)
    {
      BitmapStore.FlagForDelete();
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading Scn Gfx 4/6";
      Application.DoEvents();
      if (this.LandscapeTypeCounter > -1)
      {
        int landscapeTypeCounter = this.LandscapeTypeCounter;
        for (int Number = 0; Number <= landscapeTypeCounter; Number += 1)
        {
          this.LandscapeTypeObj[Number].LoadSprites();
          str: String = Strings.Trim(Conversion.Str((object) Number)) + " of " + Strings.Trim(Conversion.Str((object) this.LandscapeTypeCounter));
          if (!Information.IsNothing((object) tformref))
            tformref.Label1.Text = "Loading Scn Gfx 4/6, step " + str;
          Application.DoEvents();
        }
      }
      if (this.RoadTypeCounter > -1)
      {
        int roadTypeCounter = this.RoadTypeCounter;
        for (int index = 0; index <= roadTypeCounter; index += 1)
          this.RoadTypeObj[index].LoadSprites();
      }
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading Scn Gfx 5/6";
      Application.DoEvents();
      if (this.SFTypeCounter > -1)
      {
        int sfTypeCounter = this.SFTypeCounter;
        for (int Number = 0; Number <= sfTypeCounter; Number += 1)
        {
          str: String = Strings.Trim(Conversion.Str((object) Number)) + " of " + Strings.Trim(Conversion.Str((object) this.SFTypeCounter));
          if (!Information.IsNothing((object) tformref))
            tformref.Label1.Text = "Loading Scn Gfx 5/6, step " + str;
          Application.DoEvents();
          this.SFTypeObj[Number].LoadSprites();
        }
      }
      if (!Information.IsNothing((object) tformref))
        tformref.Label1.Text = "Loading Scn Gfx 6/6";
      Application.DoEvents();
      if (this.RegimeCounter > -1)
      {
        int regimeCounter = this.RegimeCounter;
        for (int index = 0; index <= regimeCounter; index += 1)
          this.RegimeObj[index].LoadSprites();
      }
      if (this.RiverTypeCounter > -1)
      {
        int riverTypeCounter = this.RiverTypeCounter;
        for (int index = 0; index <= riverTypeCounter; index += 1)
          this.RiverTypeObj[index].LoadSprites();
      }
      if (this.PeopleCounter > -1)
      {
        int peopleCounter = this.PeopleCounter;
        for (int index = 0; index <= peopleCounter; index += 1)
          this.PeopleObj[index].LoadSprites();
      }
      if (this.HistoricalUnitCounter > -1)
      {
        int historicalUnitCounter = this.HistoricalUnitCounter;
        for (int index = 0; index <= historicalUnitCounter; index += 1)
          this.HistoricalUnitObj[index].LoadSprites();
      }
      this.BridgeObj[0].LoadSprites();
      this.EventPicLoadSprites();
      this.SmallPicLoadSprites();
      this.LoadSprites();
      BitmapStore.DeleteFlaggedBitmaps();
    }

    pub void LoadSprites()
    {
      if (this.PermanentOverlayUse)
      {
        if (this.PermanentOverlaySpriteID > 0)
          BitmapStore.ReloadFile(this.PermanentOverlaySpriteID, this.PermanentOverlayName);
        else
          this.PermanentOverlaySpriteID = BitmapStore.AddFile(this.PermanentOverlayName, false);
      }
      else
        this.PermanentOverlaySpriteID = -1;
    }

    pub void EventPicKill()
    {
      int eventPicCounter = this.EventPicCounter;
      int num1;
      int num2 = num1;
      for (int index = eventPicCounter; index >= num2; index += -1)
        BitmapStore.RemoveBitmapNr(this.EventPicNr[index]);
    }

    pub void EventPicReplaceprite(int nr, string filename)
    {
      this.EventPicName[nr] = filename;
      this.EventPicNr[nr] = BitmapStore.ReloadFile(this.EventPicNr[nr], filename);
    }

    pub void EventPicLoadSprites()
    {
      if (this.EventPicCounter == -1)
        return;
      int eventPicCounter = this.EventPicCounter;
      for (int index = 0; index <= eventPicCounter; index += 1)
        this.EventPicNr[index] = BitmapStore.AddFile(this.EventPicName[index], false);
    }

    pub void RemoveEventPic(int nr)
    {
      this.EventChangeEventNr(nr, -1);
      if (nr < this.EventPicCounter)
      {
        int num1 = nr;
        int num2 = this.EventPicCounter - 1;
        for (int newnr = num1; newnr <= num2; newnr += 1)
        {
          this.EventPicName[newnr] = this.EventPicName[newnr + 1];
          this.EventPicNr[newnr] = this.EventPicNr[newnr + 1];
          this.eventPicLibId[newnr] = this.eventPicLibId[newnr + 1];
          this.EventChangeEventNr(newnr + 1, newnr);
        }
        --this.EventPicCounter;
        this.EventPicName = (string[]) Utils.CopyArray((Array) this.EventPicName, (Array) new string[this.EventPicCounter + 1]);
        this.EventPicNr = (int[]) Utils.CopyArray((Array) this.EventPicNr, (Array) new int[this.EventPicCounter + 1]);
      }
      else
      {
        this.EventPicName[nr] = "";
        this.EventPicNr[nr] = -1;
        --this.EventPicCounter;
      }
    }

    pub int FindEventPic(string teventpicName, int eventPicOrigSlot, string libname)
    {
      int eventPicCounter = this.EventPicCounter;
      for (int eventPic = 0; eventPic <= eventPicCounter; eventPic += 1)
      {
        if (this.eventPicLibId[eventPic].libSlot > -1 && Operators.CompareString(this.LibraryObj[this.eventPicLibId[eventPic].libSlot].name, libname, false) == 0 && (Operators.CompareString(this.EventPicName[eventPic], teventpicName, false) == 0 | Operators.CompareString(teventpicName, "", false) == 0) & this.eventPicLibId[eventPic].id == eventPicOrigSlot)
          return eventPic;
      }
      return -1;
    }

    pub int FindEventPic(int eventPicOrigSlot, string libname)
    {
      int eventPicCounter = this.EventPicCounter;
      for (int eventPic = 0; eventPic <= eventPicCounter; eventPic += 1)
      {
        if (this.eventPicLibId[eventPic].libSlot > -1 && Operators.CompareString(this.LibraryObj[this.eventPicLibId[eventPic].libSlot].name, libname, false) == 0 && this.eventPicLibId[eventPic].id == eventPicOrigSlot)
          return eventPic;
      }
      return -1;
    }

    pub void AddEventPic(string filename)
    {
      this += 1.EventPicCounter;
      this.EventPicName = (string[]) Utils.CopyArray((Array) this.EventPicName, (Array) new string[this.EventPicCounter + 1]);
      this.EventPicNr = (int[]) Utils.CopyArray((Array) this.EventPicNr, (Array) new int[this.EventPicCounter + 1]);
      this.eventPicLibId = (LibIdClass[]) Utils.CopyArray((Array) this.eventPicLibId, (Array) new LibIdClass[this.EventPicCounter + 1]);
      this.EventPicName[this.EventPicCounter] = filename;
      this.eventPicLibId[this.EventPicCounter] = LibIdClass::new();
      this.EventPicNr[this.EventPicCounter] = BitmapStore.AddFile(filename, false);
    }

    pub void EventChangeEventNr(int oldnr, int newnr)
    {
      int stringListCounter = this.StringListCounter;
      int index1;
      for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
      {
        int width = this.StringListObj[index2].Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int length = this.StringListObj[index2].Length;
          for (int index4 = 0; index4 <= length; index4 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.EventPicId && this.StringListObj[index2].Data[index4, index3].Length > 0)
            {
              index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
              if (index1 == oldnr)
                index1 = newnr;
              this.StringListObj[index2].Data[index4, index3] = index1.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.EventPicId & this.LibVarObj[libVarCounter].value == oldnr)
        {
          if (newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = newnr;
        }
      }
      int actionCardCounter = this.ActionCardCounter;
      for (index1 = 0; index1 <= actionCardCounter; index1 += 1)
      {
        if (this.ActionCardObj[index1].EventPicNr == oldnr)
          this.ActionCardObj[index1].EventPicNr = newnr;
        if (this.ActionCardObj[index1].AlternateEventPicNr == oldnr)
          this.ActionCardObj[index1].AlternateEventPicNr = newnr;
      }
    }

    pub void SmallPicKill()
    {
      int smallPicCounter = this.SmallPicCounter;
      int num1;
      int num2 = num1;
      for (int index = smallPicCounter; index >= num2; index += -1)
        BitmapStore.RemoveBitmapNr(this.SmallPicNr[index]);
    }

    pub void SmallPicReplaceprite(int nr, string filename)
    {
      this.SmallPicName[nr] = filename;
      this.SmallPicNr[nr] = BitmapStore.ReloadFile(this.SmallPicNr[nr], filename, IsBig: true);
    }

    pub void SmallPicLoadSprites()
    {
      if (this.SmallPicCounter == -1)
        return;
      int smallPicCounter = this.SmallPicCounter;
      for (int index = 0; index <= smallPicCounter; index += 1)
        this.SmallPicNr[index] = BitmapStore.AddFile(this.SmallPicName[index], false, true);
    }

    pub void RemoveSmallPic(int nr)
    {
      this.SmallChangeEventNr(nr, -1);
      if (nr < this.SmallPicCounter)
      {
        int num1 = nr;
        int num2 = this.SmallPicCounter - 1;
        for (int newnr = num1; newnr <= num2; newnr += 1)
        {
          this.SmallPicName[newnr] = this.SmallPicName[newnr + 1];
          this.SmallPicNr[newnr] = this.SmallPicNr[newnr + 1];
          this.SmallLibId[newnr] = this.SmallLibId[newnr + 1];
          this.SmallChangeEventNr(newnr + 1, newnr);
        }
        --this.SmallPicCounter;
        this.SmallPicName = (string[]) Utils.CopyArray((Array) this.SmallPicName, (Array) new string[this.SmallPicCounter + 1]);
        this.SmallPicNr = (int[]) Utils.CopyArray((Array) this.SmallPicNr, (Array) new int[this.SmallPicCounter + 1]);
        this.SmallLibId = (LibIdClass[]) Utils.CopyArray((Array) this.SmallLibId, (Array) new LibIdClass[this.SmallPicCounter + 1]);
      }
      else
      {
        this.SmallPicName[nr] = "";
        this.SmallPicNr[nr] = -1;
        --this.SmallPicCounter;
      }
    }

    pub void RemoveReinf(int nr)
    {
      this.ReinfChangeEventNr(nr, -1);
      if (nr < this.ReinfCounter)
      {
        int num1 = nr;
        int num2 = this.ReinfCounter - 1;
        for (int newnr = num1; newnr <= num2; newnr += 1)
        {
          this.ReinfName[newnr] = this.ReinfName[newnr + 1];
          this.ReinfId[newnr] = this.ReinfId[newnr + 1];
          this.ReinfLibId[newnr] = this.ReinfLibId[newnr + 1];
          this.ReinfRatio[newnr] = this.ReinfRatio[newnr + 1];
          this.ReinfChangeEventNr(newnr + 1, newnr);
        }
        --this.ReinfCounter;
        this.ReinfName = (string[]) Utils.CopyArray((Array) this.ReinfName, (Array) new string[this.ReinfCounter + 1]);
        this.ReinfId = (int[]) Utils.CopyArray((Array) this.ReinfId, (Array) new int[this.ReinfCounter + 1]);
        this.ReinfLibId = (LibIdClass[]) Utils.CopyArray((Array) this.ReinfLibId, (Array) new LibIdClass[this.ReinfCounter + 1]);
        this.ReinfRatio = (int[]) Utils.CopyArray((Array) this.ReinfRatio, (Array) new int[this.ReinfCounter + 1]);
      }
      else
      {
        this.ReinfName[nr] = "";
        this.ReinfId[nr] = -1;
        this.ReinfLibId[nr] = LibIdClass::new();
        --this.ReinfCounter;
        this.ReinfRatio[nr] = 1;
      }
    }

    pub int FindSmallPic(string tsmallpicName, int smallId, string libname)
    {
      int smallPicCounter = this.SmallPicCounter;
      for (int smallPic = 0; smallPic <= smallPicCounter; smallPic += 1)
      {
        if (this.SmallLibId[smallPic].libSlot > -1 && Operators.CompareString(this.LibraryObj[this.SmallLibId[smallPic].libSlot].name, libname, false) == 0 && Operators.CompareString(this.SmallPicName[smallPic], tsmallpicName, false) == 0 & this.SmallLibId[smallPic].id == smallId)
          return smallPic;
      }
      return -1;
    }

    pub int FindSmallPic(int smallId, string libname)
    {
      int smallPicCounter = this.SmallPicCounter;
      for (int smallPic = 0; smallPic <= smallPicCounter; smallPic += 1)
      {
        if (this.SmallLibId[smallPic].libSlot > -1 && Operators.CompareString(this.LibraryObj[this.SmallLibId[smallPic].libSlot].name, libname, false) == 0 && this.SmallLibId[smallPic].id == smallId)
          return smallPic;
      }
      return -1;
    }

    pub int FindReinf(string treinfName, int reinfId, string libname)
    {
      int reinfCounter = this.ReinfCounter;
      for (int reinf = 0; reinf <= reinfCounter; reinf += 1)
      {
        if (this.ReinfLibId[reinf].libSlot > -1 && Operators.CompareString(this.LibraryObj[this.ReinfLibId[reinf].libSlot].name, libname, false) == 0 && ((Operators.CompareString(treinfName, "", false) == 0 | Operators.CompareString(this.ReinfName[reinf], treinfName, false) == 0) & this.ReinfLibId[reinf].id == reinfId || Operators.CompareString(treinfName, "", false) == 0 & this.ReinfLibId[reinf].id == reinfId))
          return reinf;
      }
      return -1;
    }

    pub void AddSmallPic(string filename)
    {
      int num;
      num += 1;
      this += 1.SmallPicCounter;
      this.SmallPicName = (string[]) Utils.CopyArray((Array) this.SmallPicName, (Array) new string[this.SmallPicCounter + 1]);
      this.SmallPicNr = (int[]) Utils.CopyArray((Array) this.SmallPicNr, (Array) new int[this.SmallPicCounter + 1]);
      this.SmallLibId = (LibIdClass[]) Utils.CopyArray((Array) this.SmallLibId, (Array) new LibIdClass[this.SmallPicCounter + 1]);
      this.SmallLibId[this.SmallPicCounter] = LibIdClass::new();
      this.SmallPicName[this.SmallPicCounter] = filename;
      this.SmallPicNr[this.SmallPicCounter] = BitmapStore.AddFile(filename, false, true);
    }

    pub void AddReinf(string name)
    {
      int num;
      num += 1;
      this += 1.ReinfCounter;
      this.ReinfName = (string[]) Utils.CopyArray((Array) this.ReinfName, (Array) new string[this.ReinfCounter + 1]);
      this.ReinfId = (int[]) Utils.CopyArray((Array) this.ReinfId, (Array) new int[this.ReinfCounter + 1]);
      this.ReinfLibId = (LibIdClass[]) Utils.CopyArray((Array) this.ReinfLibId, (Array) new LibIdClass[this.ReinfCounter + 1]);
      this.ReinfRatio = (int[]) Utils.CopyArray((Array) this.ReinfRatio, (Array) new int[this.ReinfCounter + 1]);
      this.ReinfLibId[this.ReinfCounter] = LibIdClass::new();
      this += 1.reinfIdCounter;
      this.ReinfRatio[this.ReinfCounter] = 1;
      this.ReinfName[this.ReinfCounter] = name;
      this.ReinfId[this.ReinfCounter] = this.reinfIdCounter;
    }

    pub void SmallChangeEventNr(int oldnr, int newnr)
    {
      int stringListCounter = this.StringListCounter;
      int index1;
      for (int index2 = 0; index2 <= stringListCounter; index2 += 1)
      {
        int width = this.StringListObj[index2].Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int length = this.StringListObj[index2].Length;
          for (int index4 = 0; index4 <= length; index4 += 1)
          {
            if (this.StringListObj[index2].ColValueType[index3] == NewEnums.LibVarValueType.SmallGfxId && this.StringListObj[index2].Data[index4, index3].Length > 0)
            {
              index1 =  Math.Round(Conversion.Val(this.StringListObj[index2].Data[index4, index3]));
              if (index1 == oldnr)
                index1 = newnr;
              this.StringListObj[index2].Data[index4, index3] = index1.ToString();
            }
          }
        }
      }
      for (int libVarCounter = this.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
      {
        if (this.LibVarObj[libVarCounter].instanceId.id > -1 & this.LibVarObj[libVarCounter].valueType == NewEnums.LibVarValueType.SmallGfxId & this.LibVarObj[libVarCounter].value == oldnr)
        {
          if (newnr == -1)
            this.RemoveLibVar(libVarCounter);
          else
            this.LibVarObj[libVarCounter].value = newnr;
        }
      }
      int historicalUnitCounter = this.HistoricalUnitCounter;
      for (index1 = 0; index1 <= historicalUnitCounter; index1 += 1)
      {
        if (this.HistoricalUnitObj[index1].SmallGfx == oldnr)
          this.HistoricalUnitObj[index1].SmallGfx = newnr;
        int index5 = 0;
        do
        {
          if (this.HistoricalUnitObj[index1].DesignationSmall[index5] == oldnr)
            this.HistoricalUnitObj[index1].DesignationSmall[index5] = newnr;
          index5 += 1;
        }
        while (index5 <= 9);
        int hisVarCount = this.HistoricalUnitObj[index1].HisVarCount;
        for (int index6 = 0; index6 <= hisVarCount; index6 += 1)
        {
          if (this.HistoricalUnitObj[index1].HisVarSmall[index6] == oldnr)
            this.HistoricalUnitObj[index1].HisVarSmall[index6] = newnr;
        }
      }
      index1 = 0;
      do
      {
        if (this.RegimeSlotSmallGfx[index1] == oldnr)
          this.RegimeSlotSmallGfx[index1] = newnr;
        if (this.GameSlotSmallGfx[index1] == oldnr)
          this.GameSlotSmallGfx[index1] = newnr;
        index1 += 1;
      }
      while (index1 <= 499);
      int actionCardCounter = this.ActionCardCounter;
      for (index1 = 0; index1 <= actionCardCounter; index1 += 1)
      {
        if (this.ActionCardObj[index1].SmallGfx == oldnr)
          this.ActionCardObj[index1].SmallGfx = newnr;
      }
      int locTypeCounter = this.LocTypeCounter;
      for (index1 = 0; index1 <= locTypeCounter; index1 += 1)
      {
        if (this.LocTypeObj[index1].SmallGraphic == oldnr)
          this.LocTypeObj[index1].SmallGraphic = newnr;
      }
      if ((double) this.RuleVar[947] != 1.0)
        return;
      index1 = 1000;
      do
      {
        if (this.TempString[index1].Length > 0 && Conversion.Val(this.TempString[index1]) == (double) oldnr)
          this.TempString[index1] = newnr != -1 ? newnr.ToString() : "";
        index1 += 1;
      }
      while (index1 <= 1099);
    }

    pub void ReinfChangeEventNr(int oldnr, int newnr)
    {
      int sfTypeCounter = this.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; index += 1)
      {
        if (this.SFTypeObj[index].ReinforcementType == oldnr)
          this.SFTypeObj[index].ReinforcementType = newnr;
        if (this.SFTypeObj[index].ReinforcementType2 == oldnr)
          this.SFTypeObj[index].ReinforcementType2 = newnr;
        if (this.SFTypeObj[index].ReinforcementType3 == oldnr)
          this.SFTypeObj[index].ReinforcementType3 = newnr;
      }
    }
  }
}
