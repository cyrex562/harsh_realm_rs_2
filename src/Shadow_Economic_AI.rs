// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Shadow_Economic_AI
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  pub class Shadow_Economic_AI
  {
    pub DC2AIClass ai;
    pub SimpleList ShqList;
    pub DataClass data;
    pub RegimeId: i32;
    pub slotMilitiaUnits: i32;
    pub slotZoneOrders: i32;
    pub slotResult: i32;
    pub slotMilitiaTroops: i32;
    pub slotMilitiaNames: i32;
    pub slotProdType: i32;
    pub slotZones: i32;
    pub slotZoneKeys: i32;
    pub slotAssetTypes: i32;
    pub slotAssets: i32;
    pub slotNeighbours: i32;
    pub slotRegimes: i32;
    pub slotConstructionCost: i32;
    pub slotUpkeepCost: i32;
    pub slotProdCost: i32;
    pub slotBaseValues: i32;
    pub slotSHQitems: i32;
    pub slotPoolItems: i32;
    pub slotOldRegimeKeys: i32;
    pub slotAssetPresentation: i32;
    pub slotRegimeRes: i32;
    pub slotResearchTypes: i32;
    pub slotFlags: i32;
    pub slotFlagInstructions: i32;
    pub slotGameKeys: i32;
    pub slotTraders: i32;
    pub slotTraderZones: i32;
    pub slotTraderItems: i32;
    pub slotRegimeKeys: i32;
    pub slotItemType: i32;
    pub slotToeTypes: i32;
    pub slotTradeLog: i32;
    pub slotOldShqItems: i32;
    pub slotZoneSeasons: i32;
    pub slotRegimeOobs: i32;
    pub slotOobTypes: i32;
    pub slotModelTypes: i32;
    pub slotRegimeModels: i32;
    pub AIMatrix zones;
    pub shqStage: i32;
    pub shqHisId: i32;
    pub shqZoneId: i32;
    pub shqUnitNr: i32;
    pub shqHisNr: i32;
    pub shqName: String;
    pub SimpleList zoneList;
    pub shqConstructionBlock: bool;
    pub string[] poolName;
    pub int[] poolPreferedAssetType;
    pub int[] poolPreferedOob;
    pub int[] poolPreferedToe;
    pub int[] poolPreferedOobUpgradeHisId;
    pub int[] poolPreferedQuality;
    pub int[] poolImportance;
    pub int[] poolOrigImportance;
    pub int[] poolMinimumStage;
    pub poolCounter: i32;
    pub bool[] poolConstrBlocked;
    pub SimpleList[] poolRequest;
    pub SimpleList[] poolItems;
    pub int[] itemProduction;
    pub int[] itemProductionPublic;
    pub int[] itemNeed;
    pub int[] itemMiningReserve;
    pub string[] itemName;
    pub int[] itemQty;
    pub itemcounter: i32;
    pub SimpleStringList itemRegimeKeyProdList;
    pub SimpleList newItems;
    pub SimpleList decreasedItems;
    pub VAR_FreeWorkerReserve: i32;
    pub VAR_FreePopReserve: i32;
    pub VAR_FreeWorkerReservePlus: i32;
    pub VAR_CurrentPop: i32;
    pub VAR_CurrentWorker: i32;
    pub VAR_CurrentSoldier: i32;
    pub VAR_WorkerShortage: i32;
    pub VAR_WorkerHunger: i32;
    pub VAR_PopHunger: i32;
    pub VAR_SoldierHunger: i32;
    pub VAR_IdealWorker: i32;
    pub VAR_WorkerExcess: i32;
    pub VAR_WorkerJobsMax: i32;
    pub VAR_WorkerJobsCurrent: i32;
    pub VAR_IdealSoldier: i32;
    pub VAR_IdealSoldier_BeforeMaxRecruit: i32;
    pub VAR_CurrentRecruits: i32;
    pub VAR_RecruitGrowth: i32;
    pub VAR_SoldierMissing: i32;
    pub VAR_UnitsIdealAmmo: i32;
    pub VAR_UnitsCurrentAmmo: i32;
    pub VAR_UnitsIdealEnergy: i32;
    pub VAR_UnitsCurrentEnergy: i32;
    pub VAR_UnitsIdealAtomics: i32;
    pub VAR_UnitsCurrentAtomics: i32;
    pub VAR_UnitsIdealFuel: i32;
    pub VAR_UnitsFutureFuel: i32;
    pub VAR_UnitsCurrentFuel: i32;
    pub VAR_UnitsIdealFood: i32;
    pub VAR_UnitsCurrentFood: i32;
    pub VAR_PopShortage: i32;
    pub float VAR_UnitsPerFrontHex;
    pub AIMatrix supplyMatrix;
    pub AIMatrix ownerMatrix;
    pub AIMatrix frontlinesMatrix;
    pub AIMatrix borderMatrix;
    pub AICoordinateMatrix supplyCameFromMatrix;
    pub AIMatrix tempSummerMatrix;
    pub AIMatrix tempWinterMatrix;
    pub AIMatrix tempRainCurrentMatrix;
    pub AIMatrix tempRainSummerMatrix;
    pub AIMatrix tempRainWinterMatrix;
    pub SimpleList LISTVAR_ZonePopJob;
    pub SimpleList LISTVAR_ZoneWorkerJobs;
    pub Shadow_Strategic_AI strategicAi;

    pub Shadow_Economic_AI( DC2AIClass tai,  Shadow_Strategic_AI tStrategicAi)
    {
      this.poolName = new string[100];
      this.poolPreferedAssetType = new int[100];
      this.poolPreferedOob = new int[100];
      this.poolPreferedToe = new int[100];
      this.poolPreferedOobUpgradeHisId = new int[100];
      this.poolPreferedQuality = new int[100];
      this.poolImportance = new int[100];
      this.poolOrigImportance = new int[100];
      this.poolMinimumStage = new int[100];
      this.poolConstrBlocked = new bool[100];
      this.poolRequest = new SimpleList[100];
      this.poolItems = new SimpleList[100];
      this.itemProduction = new int[100];
      this.itemProductionPublic = new int[100];
      this.itemNeed = new int[100];
      this.itemMiningReserve = new int[100];
      this.itemName = new string[100];
      this.itemQty = new int[100];
      this.itemcounter = 16;
      this.newItems = SimpleList::new();
      this.decreasedItems = SimpleList::new();
      this.LISTVAR_ZonePopJob = SimpleList::new();
      this.LISTVAR_ZoneWorkerJobs = SimpleList::new();
      this.ai = tai;
      this.data = tai.game.Data;
      this.RegimeId = tai.game.Data.RegimeObj[tai.game.Data.Turn].id;
      this.strategicAi = tStrategicAi;
      libName1: String = "SE_Data";
      libName2: String = "SE_Trade";
      this.slotOldShqItems = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 284, 0, 0));
      this.slotZones = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
      this.slotTradeLog = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 400, 0, 0));
      this.slotZoneOrders = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 289, 0, 0));
      this.slotZoneKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 160, 0, 0));
      this.slotGameKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 156, 0, 0));
      this.slotNeighbours = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 157, 0, 0));
      this.slotRegimes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 143, 0, 0));
      this.slotAssets = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 148, 0, 0));
      this.slotAssetTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 144, 0, 0));
      this.slotConstructionCost = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 150, 0, 0));
      this.slotUpkeepCost = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 145, 0, 0));
      this.slotProdCost = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 146, 0, 0));
      this.slotProdType = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 147, 0, 0));
      this.slotMilitiaUnits = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 170, 0, 0));
      this.slotMilitiaTroops = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 171, 0, 0));
      this.slotMilitiaNames = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 172, 0, 0));
      this.slotBaseValues = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName2, 251, 0, 0));
      this.slotTraders = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName2, 252, 0, 0));
      this.slotTraderZones = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName2, 253, 0, 0));
      this.slotTraderItems = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName2, 254, 0, 0));
      this.slotRegimeKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 210, 0, 0));
      this.slotOldRegimeKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1,  byte.MaxValue, 0, 0));
      this.slotItemType = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 149, 0, 0));
      this.slotFlagInstructions = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 169, 0, 0));
      this.slotFlags = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 168, 0, 0));
      this.slotAssetPresentation = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 166, 0, 0));
      this.slotZoneSeasons = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 124, 0, 0));
      this.slotRegimeRes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 187, 0, 0));
      this.slotResearchTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 190, 0, 0));
      this.slotResult = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 166, 0, 0));
      this.slotSHQitems = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 273, 0, 0));
      this.slotPoolItems = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 274, 0, 0));
      this.slotModelTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 225, 0, 0));
      this.slotRegimeModels = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 228, 0, 0));
      this.slotOobTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 236, 0, 0));
      this.slotRegimeOobs = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 238, 0, 0));
      this.slotToeTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 237, 0, 0));
      this.zones = new AIMatrix( this.ai);
      let mut mapWidth: i32 = this.data.MapObj[0].MapWidth;
      let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
      data1: DataClass = this.data;
      str1: String = "Zones";
       local1: String =  str1;
      libName3: String = libName1;
      let mut libVar1: i32 = data1.FindLibVar( local1, libName3);
      data2: DataClass = this.data;
      str2: String = "temperatureMapWinter";
       local2: String =  str2;
      let mut libVar2: i32 = data2.FindLibVar( local2, "SE_Random");
      data3: DataClass = this.data;
      str3: String = "temperatureMapSummer";
       local3: String =  str3;
      let mut libVar3: i32 = data3.FindLibVar( local3, "SE_Random");
      data4: DataClass = this.data;
      str4: String = "rain";
       local4: String =  str4;
      libName4: String = libName1;
      let mut libVar4: i32 = data4.FindLibVar( local4, libName4);
      data5: DataClass = this.data;
      str5: String = "rainMapWinter";
       local5: String =  str5;
      let mut libVar5: i32 = data5.FindLibVar( local5, "SE_Random");
      data6: DataClass = this.data;
      str6: String = "rainMapSummer";
       local6: String =  str6;
      let mut libVar6: i32 = data6.FindLibVar( local6, "SE_Random");
      this.tempWinterMatrix = new AIMatrix( this.ai);
      this.tempRainCurrentMatrix = new AIMatrix( this.ai);
      this.tempRainWinterMatrix = new AIMatrix( this.ai);
      this.tempRainSummerMatrix = new AIMatrix( this.ai);
      this.tempSummerMatrix = new AIMatrix( this.ai);
      let mut num1: i32 = mapWidth;
      for (let mut index1: i32 = 0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 = mapHeight;
        for (let mut index2: i32 = 0; index2 <= num2; index2 += 1)
        {
          this.zones.Value[index1, index2] = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar1);
          this.tempWinterMatrix.Value[index1, index2] = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar2);
          this.tempSummerMatrix.Value[index1, index2] = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar3);
          this.tempRainCurrentMatrix.Value[index1, index2] = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar4);
          this.tempRainWinterMatrix.Value[index1, index2] = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar5);
          this.tempRainSummerMatrix.Value[index1, index2] = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar6);
        }
      }
      this.poolCounter = 14;
      this.poolName[1] = "Food Pool";
      this.poolName[2] = "Metal Pool";
      this.poolName[3] = "IP Pool";
      this.poolName[4] = "Oil Pool";
      this.poolName[5] = "BP Pool";
      this.poolName[6] = "Water Pool";
      this.poolName[7] = "OOB Pool";
      this.poolName[8] = "Ammo Pool";
      this.poolName[9] = "Replacements Pool";
      this.poolName[10] = "Energy Pool";
      this.poolName[11] = "Rare Pool";
      this.poolName[12] = "Machines Pool";
      this.poolName[13] = "Hi-Tech Pool";
      this.poolName[14] = "Atomics Pool";
    }

    pub void Run1()
    {
      this.GetSHQgroupsAndStages();
      this.LISTVAR_ZoneWorkerJobs = SimpleList::new();
      this.LISTVAR_ZonePopJob = SimpleList::new();
      let mut counter: i32 = this.ShqList.Counter;
      for (let mut i: i32 = 0; i <= counter; i += 1)
      {
        this.ConfigureSHQarea(i);
        this.SetKeyEconomicAIVariables(this.shqName);
      }
    }

    pub void Run2()
    {
      this.GetSHQgroupsAndStages();
      this.LISTVAR_ZoneWorkerJobs = SimpleList::new();
      this.LISTVAR_ZonePopJob = SimpleList::new();
      let mut counter: i32 = this.ShqList.Counter;
      for (let mut i: i32 = 0; i <= counter; i += 1)
      {
        this.SplitZones(i);
        this.ConfigureSHQarea(i);
        this.SetKeyEconomicAIVariables(this.shqName);
        this.DoFreeRoads(this.shqName);
        this.GetPoolPreference(this.shqName);
        this.GetPoolImportance(this.shqName);
        this.UpdatePoolItems(this.shqName);
        this.ExecuteTrade(this.shqName);
        this.ExecutePools(this.shqName);
        this.ManualZoneManagement(this.shqName);
        this.MotballOrCloseAssets(this.shqName);
        this.MakeLogs(this.shqName);
      }
      if ((this.data.Round + this.data.Turn + 4) % 4 != 0)
        return;
      this.CleanUpRoads("ForAllSHQ");
    }

    pub void MakeLogs(string logAddition)
    {
      let mut num1: i32 = -1;
      libName: String = "SE_Data";
      if (!this.ai.game.EventRelatedObj.Helper_IsDebug())
        return;
      str: String = "AI_" + this.data.RegimeObj[this.data.Turn].Name + "_" + logAddition;
      let mut stringListById1: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 292, 0, 0));
      let mut stringListById2: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      let mut regimeCounter: i32 = this.data.RegimeCounter;
      for (let mut index: i32 = 1; index <= regimeCounter; index += 1)
      {
        if (!this.data.RegimeObj[index].AI & !this.data.RegimeObj[index].Sleep)
          num1 = index;
      }
      if (num1 <= -1)
        return;
      s0_1: String = str + " Regime";
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_1, num1.ToString(), "PP", this.data.Round.ToString(), this.data.RegimeObj[this.data.Turn].ResPts.ToString());
      let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "bp", 2)));
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_1, num1.ToString(), "BP", this.data.Round.ToString(), num2.ToString());
      let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "techLevel", 2)));
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_1, num1.ToString(), "techLevel", this.data.Round.ToString(), num3.ToString());
      let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "cultureLevel", 2)));
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_1, num1.ToString(), "cultureLevel", this.data.Round.ToString(), num4.ToString());
      let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "popularity", 2)));
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_1, num1.ToString(), "popularity", this.data.Round.ToString(), num5.ToString());
      s0_2: String = str + " Current";
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_2, num1.ToString(), "CurrentPop", this.data.Round.ToString(), this.VAR_CurrentPop.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_2, num1.ToString(), "CurrentRecruits", this.data.Round.ToString(), this.VAR_CurrentRecruits.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_2, num1.ToString(), "CurrentSoldier", this.data.Round.ToString(), this.VAR_CurrentSoldier.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_2, num1.ToString(), "CurrentWorker", this.data.Round.ToString(), this.VAR_CurrentWorker.ToString());
      s0_3: String = str + " Free";
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_3, num1.ToString(), "FreePopReserve", this.data.Round.ToString(), this.VAR_FreePopReserve.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_3, num1.ToString(), "FreeWorkerReserve", this.data.Round.ToString(), this.VAR_FreeWorkerReserve.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_3, num1.ToString(), "FreeWorkerReservePlus", this.data.Round.ToString(), this.VAR_FreeWorkerReservePlus.ToString());
      s0_4: String = str + " Ideal";
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_4, num1.ToString(), "IdealSoldier", this.data.Round.ToString(), this.VAR_IdealSoldier.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_4, num1.ToString(), "IdealWorker", this.data.Round.ToString(), this.VAR_IdealWorker.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_4, num1.ToString(), "WorkerExcess", this.data.Round.ToString(), this.VAR_WorkerExcess.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_4, num1.ToString(), "RecruitGrowth", this.data.Round.ToString(), this.VAR_RecruitGrowth.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_4, num1.ToString(), "SoldierMissing", this.data.Round.ToString(), this.VAR_SoldierMissing.ToString());
      s0_5: String = str + " Unit Items";
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsCurrentAmmo", this.data.Round.ToString(), this.VAR_UnitsCurrentAmmo.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsCurrentFood", this.data.Round.ToString(), this.VAR_UnitsCurrentFood.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsCurrentFuel", this.data.Round.ToString(), this.VAR_UnitsCurrentFuel.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsCurrentEnergy", this.data.Round.ToString(), this.VAR_UnitsCurrentEnergy.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsCurrentAtomics", this.data.Round.ToString(), this.VAR_UnitsCurrentAtomics.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsIdealAmmo", this.data.Round.ToString(), this.VAR_UnitsIdealAmmo.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsIdealFood", this.data.Round.ToString(), this.VAR_UnitsIdealFood.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsIdealFuel", this.data.Round.ToString(), this.VAR_UnitsIdealFuel.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsIdealEnergy", this.data.Round.ToString(), this.VAR_UnitsIdealEnergy.ToString());
      this.data.StringListObj[stringListById1].AddRowWithDataFast(s0_5, num1.ToString(), "UnitsIdealAtomics", this.data.Round.ToString(), this.VAR_UnitsIdealAtomics.ToString());
    }

    pub void ManualZoneManagement(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      str: String = "9200_" + logAddition + "_ManualZoneManagement";
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      this.ManualZoneManagement_MoveRecruitWorkers();
      this.ManualZoneManagement_FoundNewCity();
      this.ManualZoneManagement_IncorporationAndHappiness();
      this.ai.WriteLog(str);
    }

    pub void ManualZoneManagement_MoveRecruitWorkers()
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      let mut val1: i32 = this.VAR_IdealWorker - this.VAR_CurrentWorker;
      let mut val2: i32 = this.VAR_WorkerJobsCurrent - (this.VAR_CurrentWorker + this.VAR_FreeWorkerReservePlus);
      if (val1 < 0)
        val1 = 0;
      if (val2 < 0)
        val2 = 0;
      let mut num1: i32 = Math.Max(val1, val2);
      let mut num2: i32 = this.VAR_WorkerExcess;
      if (num1 > this.VAR_WorkerShortage)
        num1 = this.VAR_WorkerShortage;
      if (num1 > 0)
        num2 = 0;
      let mut weight1: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(9);
      if (weight1 > this.VAR_IdealSoldier - this.VAR_CurrentSoldier & weight1 > 0 & this.shqZoneId > 0)
      {
        let mut tweight: i32 =  Math.Round((double) (weight1 - Math.Max(0, this.VAR_IdealSoldier - this.VAR_CurrentSoldier)) / 2.0);
        if (tweight > 0)
        {
          this.ai.AddLog("Zone #" + this.shqZoneId.ToString() + " has gotten " + tweight.ToString() + " recruits from SHQ to act as workers.");
          let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, this.shqZoneId, 1, "worker", 2))) + tweight;
          this.VAR_WorkerShortage -= tweight;
          this.data.StringListObj[this.slotZoneKeys].SetData2(0, this.shqZoneId, 1, "worker", 2, setValue);
          this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight(9, tweight);
        }
      }
      SimpleList simpleList1 = SimpleList::new();
      bool flag = true;
      let mut num3: i32 = (this.zoneList.Counter + 1) * 2;
      int num4;
      while (flag)
      {
        SimpleList simpleList2 = SimpleList::new();
        let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
        for (let mut index1: i32 = 0; index1 <= length1; index1 += 1)
        {
          let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 0]));
          let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 1]));
          let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 6]));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 8])) == this.RegimeId && id > 0)
          {
            let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1)
            {
              let mut x: i32 = this.data.LocObj[locationById].X;
              let mut y: i32 = this.data.LocObj[locationById].Y;
              EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
              let mut onlyZoneId: i32 = num5;
              SimpleList simpleList3 = (SimpleList) null;
               SimpleList local1 =  simpleList3;
              SimpleList simpleList4 = (SimpleList) null;
               SimpleList local2 =  simpleList4;
              eventRelatedObj.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId, "", itemsProdModList: ( local1), itemsUpkeepModList: ( local2));
              num4 = 0;
              let mut num7: i32 = 0;
              let mut tweight1: i32 = 0;
              let mut length2: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
              for (let mut index2: i32 = 0; index2 <= length2; index2 += 1)
              {
                if (Operators.CompareString(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 1], "workerPoints", false) == 0)
                  num4 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 3]));
              }
              tweight1 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num5, 1, "pop", 2)));
              simpleList1.AddWeight(num5, tweight1);
              let mut tdata3: i32 = num7 +  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num5, 1, "worker", 2)));
              let mut tdata1: i32 = tdata3 - num4;
              tweight1 =  Math.Round((double) tweight1 / 8.0);
              let mut num8: i32 = num1;
              this.LISTVAR_ZoneWorkerJobs.FindWeight(num5);
              if (num8 > tweight1)
                num8 = tweight1;
              if (num8 > 0)
              {
                let mut setValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num5, 1, "pop", 2))) - num8;
                this.data.StringListObj[this.slotZoneKeys].SetData2(0, num5, 1, "pop", 2, setValue1);
                let mut setValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num5, 1, "worker", 2))) + num8;
                tdata1 += num8;
                this.VAR_WorkerShortage -= num8;
                num1 -= num8;
                this.data.StringListObj[this.slotZoneKeys].SetData2(0, num5, 1, "worker", 2, setValue2);
                this.ai.AddLog("Zone #" + num5.ToString() + " has recruited " + num8.ToString() + " workers.");
              }
              else if (this.VAR_CurrentWorker > 0)
              {
                tweight1 =  Math.Round((double) num2 * ((double) tdata3 / (double) this.VAR_CurrentWorker));
                if (tweight1 > num2)
                  tweight1 = num2;
                if (tweight1 > tdata3)
                  tweight1 = tdata3;
                let mut setValue3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num5, 1, "pop", 2))) + tweight1;
                this.data.StringListObj[this.slotZoneKeys].SetData2(0, num5, 1, "pop", 2, setValue3);
                let mut setValue4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num5, 1, "worker", 2))) - tweight1;
                tdata1 -= tweight1;
                num2 -= tweight1;
                this.data.StringListObj[this.slotZoneKeys].SetData2(0, num5, 1, "worker", 2, setValue4);
                this.ai.AddLog("Zone #" + num5.ToString() + " has fired " + tweight1.ToString() + " workers.");
              }
              this.ai.AddLog("Zone #" + num5.ToString() + " has a workerExcess score of " + tdata1.ToString());
              int tweight2;
              if (num4 > 0)
              {
                tweight2 =  Math.Round((double) (100 * tdata3) / (double) num4);
              }
              else
              {
                tweight2 = 0;
                num4 = 1;
              }
              simpleList2.Add(num5, tweight2, tdata1, num4, tdata3, num4 - tdata3);
            }
          }
        }
        flag = false;
        let mut counter1: i32 = simpleList2.Counter;
        for (let mut index3: i32 = 0; index3 <= counter1; index3 += 1)
        {
          if (simpleList2.Weight[index3] < 100)
          {
            let mut counter2: i32 = simpleList2.Counter;
            for (let mut index4: i32 = 0; index4 <= counter2; index4 += 1)
            {
              if (simpleList2.Weight[index4] > simpleList2.Weight[index3])
              {
                num4 =  Math.Round((double) simpleList2.Data2[index3] * ((double) (simpleList2.Weight[index4] - simpleList2.Weight[index3]) / 100.0));
                let mut num9: i32 =  Math.Round((double) simpleList2.Data3[index4] * ((double) (simpleList2.Weight[index4] - simpleList2.Weight[index3]) / 100.0));
                if (num4 > num9)
                  num4 = num9;
                if (num4 > simpleList2.Data4[index3])
                  num4 = simpleList2.Data4[index3];
                if (num4 > simpleList2.Data3[index3])
                  num4 = simpleList2.Data3[index3];
                if ((double) num4 > (double) num9 * 0.9)
                  num4 = Math.Min( Math.Round((double) num9 * 0.1),  Math.Round((double) num4 / 2.0));
                if (num4 > 0)
                {
                  let mut setValue5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, simpleList2.Id[index3], 1, "worker", 2))) + num4;
                  this.data.StringListObj[this.slotZoneKeys].SetData2(0, simpleList2.Id[index3], 1, "worker", 2, setValue5, true);
                  let mut setValue6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, simpleList2.Id[index4], 1, "worker", 2))) - num4;
                  if (0 > setValue6)
                    setValue6 = 0;
                  this.data.StringListObj[this.slotZoneKeys].SetData2(0, simpleList2.Id[index4], 1, "worker", 2, setValue6, true);
                  --num3;
                  flag = true;
                  this.ai.AddLog("Moved " + num4.ToString() + " workers from zone#" + simpleList2.Id[index4].ToString() + " to zone#" + simpleList2.Id[index3].ToString() + ".");
                }
              }
              if (flag)
                break;
            }
            if (flag)
              break;
          }
        }
        if (num3 < 1)
          break;
      }
      let mut length: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8])) == this.RegimeId)
        {
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 2, 0);
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 3, 0);
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 4, 0);
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 5, 1);
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 6, 0);
          let mut weight2: i32 = this.LISTVAR_ZonePopJob.FindWeight(num10);
          let mut num11: i32 = this.VAR_IdealSoldier;
          if (weight2 < 50)
            num11 =  Math.Round((double) this.VAR_IdealSoldier * 0.2 + (double) this.VAR_CurrentSoldier * 0.8);
          else if (weight2 < 65)
            num11 =  Math.Round((double) this.VAR_IdealSoldier * 0.4 + (double) this.VAR_CurrentSoldier * 0.6);
          else if (weight2 < 80)
            num11 =  Math.Round((double) this.VAR_IdealSoldier * 0.6 + (double) this.VAR_CurrentSoldier * 0.4);
          else if (weight2 < 105)
            num11 =  Math.Round((double) this.VAR_IdealSoldier * 0.75 + (double) this.VAR_CurrentSoldier * 0.25);
          let mut num12: i32 = this.VAR_CurrentRecruits + this.VAR_CurrentSoldier;
          if (num11 > num12)
          {
            if ((double) this.VAR_WorkerShortage <= (double) (this.VAR_CurrentPop + this.VAR_CurrentWorker) * 0.1)
            {
              if (num12 < num11)
              {
                num4 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2))) +  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2)));
                num4 =  Math.Round((double) num4 / 20.0);
                if (num4 < 1)
                  num4 = 1;
                if (num4 > num11 - num12)
                  num4 = num11 - num12;
                this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 7, num4);
              }
              else if ((double) num12 < (double) num11 * 1.25)
              {
                num4 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2))) +  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2)));
                num4 =  Math.Round((double) num4 / 40.0);
                if (num4 < 1)
                  num4 = 1;
                if (num4 > num11 - num12)
                  num4 = num11 - num12;
                this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 7, num4);
              }
              else
                this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 7, 0);
            }
            else if (num12 < num11)
            {
              num4 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2))) +  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2)));
              num4 =  Math.Round((double) num4 / 30.0);
              if (num4 < 1)
                num4 = 1;
              if (num4 > num11 - num12)
                num4 = num11 - num12;
              this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 7, num4);
            }
            else
              this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 7, 0);
          }
          else
            this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 7, 0);
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 8, 0);
          this.data.StringListObj[this.slotZoneOrders].SetData(0, num10, 9, 1);
        }
      }
    }

    pub void ManualZoneManagement_IncorporationAndHappiness()
    {
      let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 308, 0, 0));
      let mut setValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "credits", 2)));
      if (setValue1 < 0)
        setValue1 = 0;
      let mut num1: i32 =  Math.Round((double)  Math.Round((double) setValue1 / (double) Math.Max(1, this.ShqList.Counter + 1)) / (double) Math.Max(this.zoneList.Counter + 1, 1));
      if (num1 < 0)
        num1 = 0;
      let mut num2: i32 =  Math.Round((double) num1 / 8.0);
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        let mut idValue1: i32 = this.zoneList.Id[index1];
        let mut setValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "occupationMode", 2)));
        let mut currentScore1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "popHapiness", 2)));
        let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "popLoyalty", 2)));
        let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "pop", 2)));
        let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "unrest", 2)));
        let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "danger", 2)));
        let mut currentScore2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "workerHapiness", 2)));
        let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "popCredits", 2)));
        let mut setValue3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "publicCredits", 2)));
        let mut num8: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
        data2: String = this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "pop", 2);
        EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
        let mut onlyZoneId: i32 = idValue1;
        SimpleList simpleList1 = (SimpleList) null;
         SimpleList local1 =  simpleList1;
        SimpleList simpleList2 = (SimpleList) null;
         SimpleList local2 =  simpleList2;
        eventRelatedObj.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId, "", itemsProdModList: ( local1), itemsUpkeepModList: ( local2));
        let mut num9: i32 = 0;
        let mut length: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
        for (let mut index2: i32 = 0; index2 <= length; index2 += 1)
        {
          if (Operators.CompareString(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 1], "privateFood", false) == 0)
            num9 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 2]));
        }
        let mut num10: i32 = num9;
        if (num9 < num4 + 40 && setValue3 <= 3000)
        {
          setValue3 = setValue3 + num2 + num2;
          setValue1 = setValue1 - num2 - num2;
          if (this.data.Round <= 1)
            setValue3 += 2000;
          this.ai.AddLog(data2 + " has received an amount of pub credits of investment due to food shortage.");
        }
        if (setValue3 <= 3000)
        {
          setValue3 += num2;
          setValue1 -= num2;
          this.ai.AddLog(data2 + " has received an amount of pub credits of investment as general policy.");
        }
        int percent1;
        int percent2;
        if (setValue2 > 0)
        {
          percent1 =  Math.Round((double) num8 / 2.0) + 2;
          percent2 =  Math.Round((double) num8 / 2.0) + 2;
        }
        else
        {
          percent1 =  Math.Round((double) num8 / 5.0) + 1;
          percent2 =  Math.Round((double) num8 / 5.0) + 1;
        }
        let mut setValue4: i32 = currentScore1 + DrawMod.TGame.EventRelatedObj.GetInversePercentage(currentScore1, percent1);
        let mut setValue5: i32 = currentScore2 + DrawMod.TGame.EventRelatedObj.GetInversePercentage(currentScore2, percent2);
        let mut setValue6: i32 = num5 -  Math.Round(2.0 + (double) num8 / 3.0);
        let mut setValue7: i32 = num6 -  Math.Round(2.0 + (double) num8 / 3.0);
        if (setValue6 < 0)
          setValue6 = 0;
        if (setValue7 < 0)
          setValue7 = 0;
        if (setValue4 > 100)
          setValue4 = 100;
        if (setValue5 > 100)
          setValue5 = 100;
        let mut num11: i32 =  Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 2)));
        let mut idValue2: i32 =  Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].GetData(0, idValue1, 9)));
        let mut num12: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData2(0, idValue2, 1, "tradition", 2)));
        if (setValue2 > 0 & (num10 > num4 & num3 > 50 | setValue4 > 80 & num3 > 60) && num12 < 66 + num8 && setValue4 > 66)
        {
          setValue2 = 0;
          this.ai.AddLog(data2 + " has been integrated. Occupation mode has ended.");
        }
        if (setValue2 > 0 & num11 == idValue2)
        {
          setValue2 = 0;
          this.ai.AddLog(data2 + " has been integrated. Occupation mode has ended.");
        }
        this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue1, 1, "popHapiness", 2, setValue4);
        this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue1, 1, "workerHapiness", 2, setValue5);
        this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue1, 1, "occupationMode", 2, setValue2);
        this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue1, 1, "publicCredits", 2, setValue3);
        this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue1, 1, "unrest", 2, setValue6);
        this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue1, 1, "danger", 2, setValue7);
      }
      this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "credits", 2, setValue1);
    }

    pub void ManualZoneManagement_FoundNewCity()
    {
      let mut num1: i32 = this.VAR_FreePopReserve;
      if (0 > num1)
        num1 = 0;
      let mut tweight: i32 = 50;
      let mut num2: i32 = 0;
      if (num1 < tweight)
      {
        let mut num3: i32 = DrawMod.RandyNumber.Next(0, 100);
        if (num3 > 95)
          num1 +=  Math.Round((double) this.VAR_CurrentPop / 3.0);
        else if (num3 > 80)
          num1 +=  Math.Round((double) this.VAR_CurrentPop / 5.0);
        else if (num3 > 50)
          num1 +=  Math.Round((double) this.VAR_CurrentPop / 10.0);
        else
          num1 +=  Math.Round((double) this.VAR_CurrentPop / 20.0);
      }
      bool flag = false;
      if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) < 250)
      {
        flag = true;
        this.ai.AddLog("Block new city due low food");
      }
      if ((double) this.itemNeed[7] * 1.2 + 50.0 < (double) this.itemProduction[7])
      {
        flag = true;
        this.ai.AddLog("Block new city due low food");
      }
      if (!flag)
      {
        this.ai.AddLog("");
        this.ai.AddLog("Colonist needed = " + tweight.ToString() + ", Colonist available = " + num1.ToString());
        SimpleList simpleList = SimpleList::new();
        let mut counter1: i32 = this.zoneList.Counter;
        int num4;
        for (let mut index1: i32 = 0; index1 <= counter1; index1 += 1)
        {
          let mut num5: i32 = this.zoneList.Id[index1];
          let mut length: i32 = this.data.StringListObj[this.slotNeighbours].Length;
          for (let mut index2: i32 = 0; index2 <= length; index2 += 1)
          {
            let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index2, 0]));
            let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index2, 1]));
            num4 = -1;
            if (num6 == num5)
              num4 = num7;
            if (num7 == num5)
              num4 = num6;
            if (num4 > -1)
            {
              let mut num8: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num4, 6)));
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num4, 8))) == this.RegimeId & num8 < 1)
                simpleList.Add(num4, DrawMod.RandyNumber.Next(0, 100));
            }
          }
        }
        this.ai.AddLog("");
        this.ai.AddLog("Colonist needed = " + tweight.ToString() + ", Colonist available = " + num1.ToString() + ", Possible new colony towns: " + (simpleList.Counter + 1).ToString());
        this.ai.AddLog("");
        if (simpleList.Counter > -1)
        {
          simpleList.Sort();
          let mut counter2: i32 = simpleList.Counter;
          for (let mut index3: i32 = 0; index3 <= counter2; index3 += 1)
          {
            let mut zoneId: i32 = simpleList.Id[index3];
            Coordinate bestTownCoord = DrawMod.TGame.EventRelatedObj.Helper_GetBestTownCoord(zoneId, "SE_Random", "SE_Data");
            let mut movetype: i32 = 8;
            DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, movetype, 0, 200, bestTownCoord.x, bestTownCoord.y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
            let mut num9: i32 = DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y];
            if (Information.IsNothing((object) this.data.UnitObj[this.shqUnitNr].items))
              this.data.UnitObj[this.shqUnitNr].items = ItemList::new();
            let mut nr: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindNr(2);
            if (nr > -1)
              num4 = this.data.UnitObj[this.shqUnitNr].items.list.Weight[nr];
            if (num9 < 999 & num4 >= num2 && num1 >= tweight)
            {
              this.data.UnitObj[this.shqUnitNr].items.list.Add(12, tweight);
              let mut stringlistid: i32 = DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0);
              DrawMod.TGame.EventRelatedObj.ExecKey(stringlistid, "ZONE", zoneId.ToString(), "", "");
              DrawMod.TGame.EventRelatedObj.ExecKey(stringlistid, "X", bestTownCoord.x.ToString(), "", "");
              DrawMod.TGame.EventRelatedObj.ExecKey(stringlistid, "Y", bestTownCoord.y.ToString(), "", "");
              DrawMod.TGame.EditObj.UDSClearInput();
              DrawMod.TGame.EditObj.UDSAddInput("CHOICE", this.shqUnitNr);
              DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_FoundCity_Commence(0);
              DrawMod.TGame.EventRelatedObj.IO_AddClear();
              this.ai.AddLog("Placed new town at " + bestTownCoord.x.ToString() + ", " + bestTownCoord.y.ToString() + ".");
              float num10 = (float) tweight / (float) this.VAR_CurrentPop;
              let mut counter3: i32 = this.zoneList.Counter;
              for (let mut index4: i32 = 0; index4 <= counter3; index4 += 1)
              {
                let mut num11: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneList.Id[index4], 1, "pop", 2)));
                let mut setValue: i32 = num11 -  Math.Round((double) ((float) num11 * num10));
                this.data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneList.Id[index4], 1, "pop", 2, setValue);
                this.data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneList.Id[index4], 1, "city", 2, 1);
              }
            }
          }
        }
      }
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter; index += 1)
      {
        let mut idValue: i32 = this.zoneList.Id[index];
        let mut num12: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 6)));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 8))) == this.RegimeId & num12 > 0)
        {
          let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneList.Id[index], 1, "city", 2)));
          let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneList.Id[index], 1, "pop", 2))) +  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneList.Id[index], 1, "worker", 2)));
          if (setValue <= 1 & num13 > 250)
            setValue = 2;
          if (setValue <= 2 & num13 > 500)
            setValue = 3;
          if (setValue <= 3 & num13 > 1000)
            setValue = 4;
          if (setValue <= 4 & num13 > 2000)
            setValue = 5;
          if (setValue <= 5 & num13 > 3250)
            setValue = 6;
          if (setValue <= 6 & num13 > 5500)
            setValue = 7;
          this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue, 1, "city", 2, setValue);
        }
      }
    }

    pub void DoFreeRoads(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      str: String = "9006_" + logAddition + "_DoFreeRoads";
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      if (DrawMod.RandyNumber.Next(0, 100) < 66)
      {
        this.ai.AddLog("");
        this.ai.AddLog("Skipped this round. Only 1 in 3 rounds we give free roads. ");
        this.ai.WriteLog(str);
      }
      else
      {
        bool flag1 = true;
        bool[] flagArray = new bool[this.data.UnitCounter + 1];
        while (flag1)
        {
          flag1 = false;
          let mut num1: i32 = 8;
          DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, num1, 0, 400, this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
          let mut unitCounter: i32 = this.data.UnitCounter;
          for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
          {
            if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1 & !flagArray[unr] && DrawMod.TGame.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr))
            {
              let mut num2: i32 = DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y];
              if (num2 > 50 & num2 <= 300)
              {
                let mut num3: i32 = 0;
                let mut num4: i32 = 0;
                for (Coordinate coordinate = DrawMod.TGame.EditObj.TempCameFrom[0].Value[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y]; coordinate.onmap & num3 < 99; coordinate = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y])
                {
                  num3 += 1;
                  if (DrawMod.TGame.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] <= num4)
                    ;
                }
                bool flag2 = true;
                let mut num5: i32 = 0;
                if (this.data.RegimeObj[this.data.Turn].AIHelpCombat == 10)
                  num5 += 10;
                if (this.data.RegimeObj[this.data.Turn].AIHelpCombat >= 20)
                  num5 += 20;
                if (num4 >= 60)
                {
                  if (DrawMod.RandyNumber.Next(0, 100) > 10 + num5)
                    flag2 = false;
                }
                else if (num4 >= 50)
                {
                  if (DrawMod.RandyNumber.Next(0, 100) > 20 + num5)
                    flag2 = false;
                }
                else if (num4 >= 40)
                {
                  if (DrawMod.RandyNumber.Next(0, 100) > 30 + num5)
                    flag2 = false;
                }
                else if (num4 >= 30 && DrawMod.RandyNumber.Next(0, 100) > 50 + num5)
                  flag2 = false;
                if (flag2)
                {
                  this.ai.AddLog("*** " + this.data.UnitObj[unr].Name + " is at supply distance " + num2.ToString());
                  flagArray[unr] = true;
                  Coordinate coordinate;
                  coordinate.x = this.data.UnitObj[unr].X;
                  coordinate.y = this.data.UnitObj[unr].Y;
                  coordinate.onmap = true;
                  bool flag3 = false;
                  let mut x2: i32 = -1;
                  int y;
                  while (coordinate.onmap & !flag3)
                  {
                    coordinate = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                    if (coordinate.onmap && DrawMod.TGame.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] <= 100)
                    {
                      x2 = coordinate.x;
                      y = coordinate.y;
                      flag3 = true;
                    }
                  }
                  if (x2 > -1)
                  {
                    this.ai.AddLog("Make road to " + x2.ToString() + "," + y.ToString());
                    DrawMod.TGame.EventRelatedObj.Helper_MakeRoad(num1, 400, this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y, x2, y, 0);
                    flag1 = true;
                    break;
                  }
                  this.ai.AddLog("Could not find road destination");
                }
              }
            }
          }
        }
        SimpleList simpleList = SimpleList::new();
        let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
        for (let mut tdata3: i32 = 0; tdata3 <= length1; tdata3 += 1)
        {
          let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 0]));
          let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 6]));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 8])) == this.RegimeId && id > 0)
          {
            let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1 && this.data.LocObj[locationById].HQ > -1)
            {
              let mut x: i32 = this.data.LocObj[locationById].X;
              let mut y: i32 = this.data.LocObj[locationById].Y;
              simpleList.Add(tid, 1, x, y, tdata3, this.data.LocObj[locationById].HQ);
            }
          }
        }
        bool flag4 = true;
        while (flag4)
        {
          flag4 = false;
          let mut counter: i32 = simpleList.Counter;
          for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
          {
            if (simpleList.Data4[index1] == this.shqUnitNr)
            {
              let mut num6: i32 = simpleList.Data1[index1];
              let mut num7: i32 = simpleList.Data2[index1];
              DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, 8, 0, 400, num6, num7, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
              let mut length2: i32 = this.data.StringListObj[this.slotAssets].Length;
              for (let mut index2: i32 = 0; index2 <= length2; index2 += 1)
              {
                if (simpleList.Id[index1] ==  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 0])))
                {
                  let mut x2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 3]));
                  let mut y2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 4]));
                  if (DrawMod.TGame.EditObj.TempValue[0].Value[x2, y2] > 0 & DrawMod.TGame.EditObj.TempValue[0].Value[x2, y2] < 999)
                  {
                    this.ai.AddLog("Make road from " + x2.ToString() + "," + y2.ToString() + " to " + num6.ToString() + "," + num7.ToString() + ".");
                    DrawMod.TGame.EventRelatedObj.Helper_MakeRoad(8, 400, num6, num7, x2, y2, 0);
                    flag4 = true;
                    break;
                  }
                }
              }
              if (flag4)
                break;
            }
          }
        }
        this.ai.WriteLog(str);
      }
    }

    pub void CleanUpRoads(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      str: String = "9006b_" + logAddition + "_CleanUpRoads";
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.ai.AddLog("ROAD CLEANUP OPERATION");
      int[,,] numArray1 = new int[this.data.MapObj[0].MapWidth + 1, this.data.MapObj[0].MapHeight + 1, 6];
      int[,] numArray2 = new int[this.data.MapObj[0].MapWidth + 1, this.data.MapObj[0].MapHeight + 1];
      SimpleList simpleList1 = SimpleList::new();
      let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut tdata3: i32 = 0; tdata3 <= length1; tdata3 += 1)
      {
        let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 0]));
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 6]));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 8])) == this.RegimeId && id > 0)
        {
          let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1 && this.data.LocObj[locationById].HQ > -1)
          {
            let mut x: i32 = this.data.LocObj[locationById].X;
            let mut y: i32 = this.data.LocObj[locationById].Y;
            simpleList1.Add(tid, 1, x, y, tdata3, this.data.LocObj[locationById].HQ);
          }
        }
      }
      AIMatrix aiMatrix1 = new AIMatrix( this.ai);
      AIMatrix aiMatrix2 = this.ai.SetOwnerMatrix(0, 0, this.data.MapObj[0].MapWidth, this.data.MapObj[0].MapHeight);
      aiMatrix2.SetValueXToValueY(0, 2);
      let mut mapWidth1: i32 = this.data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth1; index1 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (DrawMod.TGame.Data.LandscapeTypeObj[this.data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea)
            aiMatrix2.Value[index1, index2] = 0;
        }
      }
      aiMatrix2.SetValueXToValueY(1, 0);
      aiMatrix2.ExpandValueWithoutConditionsDimishWithOne(1);
      AIMatrix aiMatrix3 = new AIMatrix( this.ai);
      let mut mapWidth2: i32 = this.data.MapObj[0].MapWidth;
      for (let mut index3: i32 = 0; index3 <= mapWidth2; index3 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index4: i32 = 0; index4 <= mapHeight; index4 += 1)
        {
          if (this.data.MapObj[0].HexObj[index3, index4].Regime != this.data.Turn)
            aiMatrix2.Value[index3, index4] = 0;
          else if (this.data.MapObj[0].HexObj[index3, index4].UnitCounter > -1)
            aiMatrix3.Value[index3, index4] = 1;
        }
      }
      aiMatrix3.ExpandAndAddValueForAnyRegime(4);
      let mut counter1: i32 = this.ShqList.Counter;
      Coordinate coordinate1;
      Coordinate coordinate2;
      for (let mut index5: i32 = 0; index5 <= counter1; index5 += 1)
      {
        this.shqHisId = this.ShqList.Id[index5];
        this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
        this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
        this.shqStage = this.ShqList.Data1[index5];
        this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
        this.shqZoneId = this.zones.Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y];
        SimpleList simpleList2 = SimpleList::new();
        let mut mapWidth3: i32 = this.data.MapObj[0].MapWidth;
        int num1;
        for (let mut index6: i32 = 0; index6 <= mapWidth3; index6 += 1)
        {
          let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
          for (let mut index7: i32 = 0; index7 <= mapHeight; index7 += 1)
          {
            if (aiMatrix2.Value[index6, index7] >= 1)
            {
              if (aiMatrix3.Value[index6, index7] <= 0 && simpleList1.FindNr(this.zones.Value[index6, index7]) > -1 && simpleList1.Data4[simpleList1.FindNr(this.zones.Value[index6, index7])] == this.shqUnitNr)
              {
                num1 = 0;
                let mut num2: i32 = 0;
                let mut counter2: i32 = simpleList2.Counter;
                for (let mut index8: i32 = 0; index8 <= counter2; index8 += 1)
                {
                  num1 = DrawMod.TGame.HandyFunctionsObj.Distance(simpleList2.Data1[index8], simpleList2.Data2[index8], 0, index6, index7, 0, 5);
                  if (num1 < 5)
                  {
                    num2 += 1;
                    break;
                  }
                }
                if (num2 == 0)
                  simpleList2.Add(index6 * 1000 + index7, 1, index6, index7, CheckExistence: false);
              }
              if (DrawMod.TGame.HandyFunctionsObj.HasHexRoad(index6, index7, 0))
                simpleList2.Add(index6 * 1000 + index7, 1, index6, index7, CheckExistence: false);
            }
          }
        }
        let mut movetype: i32 = 8;
        let mut num3: i32 = 1;
        do
        {
          if (num3 == 1)
            DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, movetype, 0, 400, this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
          if (num3 == 2)
            DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, 11, 0, 900, this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
          let mut unitCounter: i32 = this.data.UnitCounter;
          for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
          {
            if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1 && DrawMod.TGame.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr))
            {
              let mut index9: i32 = this.data.UnitObj[unr].X;
              let mut y: i32 = this.data.UnitObj[unr].Y;
              if (index9 == 18 & y == 39)
                index9 = index9;
              if (DrawMod.TGame.EditObj.TempValue[0].Value[index9, y] < 999)
              {
                coordinate1.x = index9;
                coordinate1.y = y;
                coordinate1.onmap = true;
                num1 = 0;
                let mut num4: i32 = 0;
                while (coordinate1.onmap)
                {
                  num1 += 1;
                  coordinate1.onmap = false;
                  coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                  if (coordinate2.onmap)
                  {
                    let mut num5: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                    if (num5 > 0)
                    {
                      if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num5 - 1] > -1)
                      {
                        coordinate1 = coordinate2;
                        num4 = 1;
                      }
                      else if (num4 < 1)
                        coordinate1 = coordinate2;
                      else if (num4 != 1)
                        ;
                    }
                  }
                  if (num1 > 199)
                    break;
                }
                if (coordinate1.x == this.data.UnitObj[this.shqUnitNr].X & coordinate1.y == this.data.UnitObj[this.shqUnitNr].Y)
                {
                  coordinate1.x = index9;
                  coordinate1.y = y;
                  coordinate1.onmap = true;
                  num1 = 0;
                  while (coordinate1.onmap)
                  {
                    num1 += 1;
                    coordinate1.onmap = false;
                    coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                    if (coordinate2.onmap)
                    {
                      let mut num6: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                      if (num6 > 0)
                      {
                        if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num6 - 1] > -1)
                        {
                          numArray1[coordinate1.x, coordinate1.y, num6 - 1] = 1;
                          numArray2[coordinate1.x, coordinate1.y] = 1;
                          let mut num7: i32 = num6 + 3;
                          if (num7 > 6)
                            num7 -= 6;
                          numArray1[coordinate2.x, coordinate2.y, num7 - 1] = 1;
                          numArray2[coordinate2.x, coordinate2.y] = 1;
                          coordinate1 = coordinate2;
                        }
                        else
                          coordinate1 = coordinate2;
                      }
                    }
                    if (num1 > 199)
                      break;
                  }
                }
              }
            }
          }
          let mut counter3: i32 = simpleList2.Counter;
          for (let mut index10: i32 = 0; index10 <= counter3; index10 += 1)
          {
            let mut index11: i32 = simpleList2.Data1[index10];
            let mut index12: i32 = simpleList2.Data2[index10];
            if (DrawMod.TGame.EditObj.TempValue[0].Value[index11, index12] < 999)
            {
              coordinate1.x = index11;
              coordinate1.y = index12;
              coordinate1.onmap = true;
              num1 = 0;
              let mut num8: i32 = 0;
              while (coordinate1.onmap)
              {
                num1 += 1;
                coordinate1.onmap = false;
                coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                if (coordinate2.onmap)
                {
                  let mut num9: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                  if (num9 > 0)
                  {
                    if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num9 - 1] > -1)
                    {
                      coordinate1 = coordinate2;
                      num8 = 1;
                    }
                    else if (num8 < 1)
                      coordinate1 = coordinate2;
                    else if (num8 != 1)
                      ;
                  }
                }
                if (num1 > 199)
                  break;
              }
              if (coordinate1.x == this.data.UnitObj[this.shqUnitNr].X & coordinate1.y == this.data.UnitObj[this.shqUnitNr].Y)
              {
                coordinate1.x = index11;
                coordinate1.y = index12;
                coordinate1.onmap = true;
                num1 = 0;
                while (coordinate1.onmap)
                {
                  num1 += 1;
                  coordinate1.onmap = false;
                  coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                  if (coordinate2.onmap)
                  {
                    let mut num10: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                    if (num10 > 0)
                    {
                      if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num10 - 1] > -1)
                      {
                        numArray1[coordinate1.x, coordinate1.y, num10 - 1] = 1;
                        numArray2[coordinate1.x, coordinate1.y] = 1;
                        let mut num11: i32 = num10 + 3;
                        if (num11 > 6)
                          num11 -= 6;
                        numArray1[coordinate2.x, coordinate2.y, num11 - 1] = 1;
                        numArray2[coordinate2.x, coordinate2.y] = 1;
                        coordinate1 = coordinate2;
                      }
                      else
                        coordinate1 = coordinate2;
                    }
                  }
                  if (num1 > 199)
                    break;
                }
              }
            }
          }
          let mut counter4: i32 = simpleList1.Counter;
          for (let mut index13: i32 = 0; index13 <= counter4; index13 += 1)
          {
            if (simpleList1.Data4[index13] == this.shqUnitNr)
            {
              let mut index14: i32 = simpleList1.Data1[index13];
              let mut index15: i32 = simpleList1.Data2[index13];
              if (DrawMod.TGame.EditObj.TempValue[0].Value[index14, index15] < 999)
              {
                coordinate1.x = index14;
                coordinate1.y = index15;
                coordinate1.onmap = true;
                num1 = 0;
                let mut num12: i32 = 0;
                while (coordinate1.onmap)
                {
                  num1 += 1;
                  coordinate1.onmap = false;
                  coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                  if (coordinate2.onmap)
                  {
                    let mut num13: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                    if (num13 > 0)
                    {
                      if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num13 - 1] > -1)
                      {
                        coordinate1 = coordinate2;
                        num12 = 1;
                      }
                      else if (num12 < 1)
                        coordinate1 = coordinate2;
                      else if (num12 != 1)
                        ;
                    }
                  }
                  if (num1 > 199)
                    break;
                }
                if (coordinate1.x == this.data.UnitObj[this.shqUnitNr].X & coordinate1.y == this.data.UnitObj[this.shqUnitNr].Y)
                {
                  coordinate1.x = index14;
                  coordinate1.y = index15;
                  coordinate1.onmap = true;
                  num1 = 0;
                  while (coordinate1.onmap)
                  {
                    num1 += 1;
                    coordinate1.onmap = false;
                    coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                    if (coordinate2.onmap)
                    {
                      let mut num14: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                      if (num14 > 0)
                      {
                        if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num14 - 1] > -1)
                        {
                          numArray1[coordinate1.x, coordinate1.y, num14 - 1] = 1;
                          numArray2[coordinate1.x, coordinate1.y] = 1;
                          let mut num15: i32 = num14 + 3;
                          if (num15 > 6)
                            num15 -= 6;
                          numArray1[coordinate2.x, coordinate2.y, num15 - 1] = 1;
                          numArray2[coordinate2.x, coordinate2.y] = 1;
                          coordinate1 = coordinate2;
                        }
                        else
                          coordinate1 = coordinate2;
                      }
                    }
                    if (num1 > 199)
                      break;
                  }
                }
              }
            }
          }
          num3 += 1;
        }
        while (num3 <= 2);
        let mut counter5: i32 = simpleList1.Counter;
        for (let mut index16: i32 = 0; index16 <= counter5; index16 += 1)
        {
          if (simpleList1.Data4[index16] == this.shqUnitNr)
          {
            let mut x: i32 = simpleList1.Data1[index16];
            let mut y: i32 = simpleList1.Data2[index16];
            DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, movetype, 0, 240, x, y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
            let mut length2: i32 = this.data.StringListObj[this.slotAssets].Length;
            for (let mut index17: i32 = 0; index17 <= length2; index17 += 1)
            {
              if (simpleList1.Id[index16] ==  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index17, 0])))
              {
                let mut index18: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index17, 3]));
                let mut index19: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index17, 4]));
                if (DrawMod.TGame.EditObj.TempValue[0].Value[index18, index19] < 999)
                {
                  coordinate1.x = index18;
                  coordinate1.y = index19;
                  coordinate1.onmap = false;
                  if (coordinate1.x >= 0 & coordinate1.y >= 0 & !(coordinate1.x == x & coordinate1.y == y))
                    coordinate1.onmap = true;
                  num1 = 0;
                  let mut num16: i32 = 0;
                  while (coordinate1.onmap)
                  {
                    num1 += 1;
                    coordinate1.onmap = false;
                    coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                    if (coordinate2.onmap)
                    {
                      let mut num17: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                      if (num17 > 0)
                      {
                        if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num17 - 1] > -1)
                        {
                          coordinate1 = coordinate2;
                          num16 = 1;
                        }
                        else if (num16 < 1)
                          coordinate1 = coordinate2;
                        else if (num16 != 1)
                          ;
                      }
                    }
                    if (num1 > 199)
                      break;
                  }
                  if (coordinate1.x == x & coordinate1.y == y)
                  {
                    coordinate1.x = index18;
                    coordinate1.y = index19;
                    coordinate1.onmap = true;
                    num1 = 0;
                    while (coordinate1.onmap)
                    {
                      num1 += 1;
                      coordinate1.onmap = false;
                      coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                      if (coordinate2.onmap)
                      {
                        let mut num18: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                        if (num18 > 0)
                        {
                          if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num18 - 1] > -1)
                          {
                            numArray1[coordinate1.x, coordinate1.y, num18 - 1] = 1;
                            numArray2[coordinate1.x, coordinate1.y] = 1;
                            let mut num19: i32 = num18 + 3;
                            if (num19 > 6)
                              num19 -= 6;
                            numArray1[coordinate2.x, coordinate2.y, num19 - 1] = 1;
                            numArray2[coordinate2.x, coordinate2.y] = 1;
                            coordinate1 = coordinate2;
                          }
                          else
                            coordinate1 = coordinate2;
                        }
                      }
                      if (num1 > 199)
                        break;
                    }
                  }
                }
              }
            }
          }
        }
      }
      let mut counter6: i32 = this.ShqList.Counter;
      for (let mut index20: i32 = 0; index20 <= counter6; index20 += 1)
      {
        this.shqHisId = this.ShqList.Id[index20];
        this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
        this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
        this.shqStage = this.ShqList.Data1[index20];
        this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
        this.shqZoneId = this.zones.Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y];
        if (this.shqZoneId > 0)
        {
          let mut movetype: i32 = 11;
          DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, movetype, 0, 400, this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
          let mut counter7: i32 = simpleList1.Counter;
          for (let mut index21: i32 = 0; index21 <= counter7; index21 += 1)
          {
            if (simpleList1.Data4[index21] == this.shqUnitNr)
            {
              let mut index22: i32 = simpleList1.Data1[index21];
              let mut index23: i32 = simpleList1.Data2[index21];
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, simpleList1.Id[index21], 1, "city", 2))) >= 3 && DrawMod.TGame.EditObj.TempValue[0].Value[index22, index23] < 999)
              {
                coordinate1.x = index22;
                coordinate1.y = index23;
                coordinate1.onmap = true;
                let mut num20: i32 = 0;
                let mut num21: i32 = 0;
                while (coordinate1.onmap)
                {
                  num20 += 1;
                  coordinate1.onmap = false;
                  coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                  if (coordinate2.onmap)
                  {
                    let mut num22: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                    if (num22 > 0 && this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num22 - 1] > -1)
                    {
                      coordinate1 = coordinate2;
                      num21 = 1;
                    }
                  }
                  if (num20 > 199)
                    break;
                }
                if (coordinate1.x == this.data.UnitObj[this.shqUnitNr].X & coordinate1.y == this.data.UnitObj[this.shqUnitNr].Y & num20 < 199)
                {
                  coordinate1.x = index22;
                  coordinate1.y = index23;
                  coordinate1.onmap = true;
                  let mut num23: i32 = 0;
                  while (coordinate1.onmap)
                  {
                    num23 += 1;
                    coordinate1.onmap = false;
                    coordinate2 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                    if (coordinate2.onmap)
                    {
                      let mut num24: i32 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0);
                      if (num24 > 0)
                      {
                        let mut num25: i32 = num24 + 3;
                        if (num25 > 6)
                          num25 -= 6;
                        if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num24 - 1] == 0)
                          this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num24 - 1] = 1;
                        else if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num24 - 1] == 2)
                          this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num24 - 1] = 4;
                        else if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num24 - 1] == 3)
                          this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num24 - 1] = 4;
                        if (this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num25 - 1] == 0)
                          this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num25 - 1] = 1;
                        else if (this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num25 - 1] == 2)
                          this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num25 - 1] = 4;
                        else if (this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num25 - 1] == 3)
                          this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num25 - 1] = 4;
                        coordinate1 = coordinate2;
                      }
                    }
                    if (num23 > 199)
                      break;
                  }
                }
              }
            }
          }
        }
      }
      let mut mapWidth4: i32 = this.data.MapObj[0].MapWidth;
      for (let mut cx: i32 = 0; cx <= mapWidth4; cx += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
        {
          if (this.data.MapObj[0].HexObj[cx, cy].Regime == this.data.Turn)
          {
            let mut index24: i32 = 0;
            do
            {
              coordinate1 = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index24 + 1);
              if (coordinate1.onmap)
              {
                let mut index25: i32 = index24 + 3;
                if (index25 > 5)
                  index25 -= 6;
                if (numArray1[cx, cy, index24] < 1 && this.data.MapObj[0].HexObj[cx, cy].RoadType[index24] == 0 && DrawMod.TGame.Data.MapObj[0].HexObj[cx, cy].Regime == this.data.Turn && DrawMod.TGame.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime == this.data.Turn)
                {
                  if (cx == 19 & cy == 35)
                    cx = cx;
                  if (cx == 20 & cy == 35)
                    cx = cx;
                  if (cx == 22 & cy == 34)
                    cx = cx;
                  if (cx == 11 & cy == 27)
                    cx = cx;
                  this.data.MapObj[0].HexObj[cx, cy].RoadType[index24] = -1;
                }
                if (numArray1[coordinate1.x, coordinate1.y, index25] < 1 && DrawMod.TGame.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime == this.data.Turn && this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[index25] == 0 && DrawMod.TGame.Data.MapObj[0].HexObj[cx, cy].Regime == this.data.Turn)
                {
                  if (coordinate1.x == 19 & coordinate1.y == 35)
                    cx = cx;
                  if (coordinate1.x == 20 & coordinate1.y == 35)
                    cx = cx;
                  if (coordinate1.x == 22 & coordinate1.y == 34)
                    cx = cx;
                  if (coordinate1.x == 11 & coordinate1.y == 27)
                    cx = cx;
                  this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[index25] = -1;
                }
              }
              index24 += 1;
            }
            while (index24 <= 5);
          }
        }
      }
      this.ai.WriteLog(str);
    }

    pub void SetKeyEconomicAIVariables(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      str: String = "9005_" + logAddition + "_SetKeyEconomicVariables";
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      let mut num1: i32 = 0;
      let mut num2: i32 = 0;
      this.VAR_WorkerJobsMax = 0;
      this.VAR_WorkerJobsCurrent = 0;
      let mut num3: i32 = 1;
      do
      {
        let mut num4: i32 = 0;
        let mut num5: i32 = 0;
        let mut num6: i32 = 0;
        let mut num7: i32 = 0;
        let mut num8: i32 = 0;
        let mut num9: i32 = 0;
        let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
        for (let mut index1: i32 = 0; index1 <= length1; index1 += 1)
        {
          let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 0]));
          let mut num11: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 1]));
          let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 6]));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 8])) == this.RegimeId && id > 0)
          {
            let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1)
            {
              let mut x: i32 = this.data.LocObj[locationById].X;
              let mut y: i32 = this.data.LocObj[locationById].Y;
              SimpleList simpleList1;
              SimpleList simpleList2;
              if (num3 == 1)
              {
                EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
                let mut onlyZoneId: i32 = num10;
                simpleList1 = (SimpleList) null;
                 SimpleList local1 =  simpleList1;
                simpleList2 = (SimpleList) null;
                 SimpleList local2 =  simpleList2;
                eventRelatedObj.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId, "", true, presumeAllActive: true, itemsProdModList: ( local1), itemsUpkeepModList: ( local2));
              }
              if (num3 == 2)
              {
                EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
                let mut onlyZoneId: i32 = num10;
                simpleList2 = (SimpleList) null;
                 SimpleList local3 =  simpleList2;
                simpleList1 = (SimpleList) null;
                 SimpleList local4 =  simpleList1;
                eventRelatedObj.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId, "", true, itemsProdModList: ( local3), itemsUpkeepModList: ( local4));
              }
              num6 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2)));
              let mut tdata2_1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2)));
              num7 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2)));
              let mut tdata2_2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2)));
              let mut num12: i32 = 0;
              let mut tdata1: i32 = 0;
              let mut length2: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
              for (let mut index2: i32 = 0; index2 <= length2; index2 += 1)
              {
                if (Operators.CompareString(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 1], "popPoints", false) == 0)
                {
                  num5 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 3]));
                  num12 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index2, 3]));
                }
              }
              let mut length3: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
              for (let mut index3: i32 = 0; index3 <= length3; index3 += 1)
              {
                if (Operators.CompareString(this.data.StringListObj[this.slotAssetPresentation].Data[index3, 1], "workerPoints", false) == 0)
                  tdata1 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index3, 3]));
              }
              num4 += tdata1;
              if (num3 == 1)
                this.LISTVAR_ZonePopJob.Add(num10,  Math.Round((double) (tdata2_2 * 100) / (double) Math.Max(1, num12)), num12, tdata2_2);
              if (num3 == 2)
                this.LISTVAR_ZoneWorkerJobs.Add(num10,  Math.Round((double) (tdata2_2 * 100) / (double) Math.Max(1, num12)), tdata1, tdata2_1);
              num8 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2))) *  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "workerHunger", 2)));
              num9 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2))) *  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "popHunger", 2)));
              let mut length4: i32 = this.data.StringListObj[this.slotAssets].Length;
              for (let mut index4: i32 = 0; index4 <= length4; index4 += 1)
              {
                let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index4, 0]));
                let mut num14: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index4, 7]));
                if (num13 == num10 & num14 > 0)
                  num1 += 1;
                if (num13 == num10)
                  num2 += 1;
              }
              if (num3 == 1)
                this.VAR_WorkerJobsMax += tdata1;
              if (num3 == 2)
                this.VAR_WorkerJobsCurrent += tdata1;
            }
          }
        }
        num1 =  Math.Round((double) num1 / 2.0);
        if (this.zoneList.Counter > -1)
          num1 =  Math.Round((double) num1 / (double) (this.zoneList.Counter + 1));
        if (num3 == 1)
        {
          this.VAR_CurrentPop = num7;
          this.VAR_CurrentWorker = num6;
          this.VAR_WorkerHunger =  Math.Round((double) num8 / (double) (num7 + 1));
          this.VAR_PopHunger =  Math.Round((double) num9 / (double) (num7 + 1));
          this.VAR_WorkerShortage = Math.Max(0, num4 - num6);
          this.VAR_WorkerExcess = 0;
          this.VAR_PopShortage = Math.Max(0, num5 - num7);
          this.VAR_FreePopReserve = Math.Max(0, num7 - num5);
          this.VAR_FreeWorkerReserve = Math.Max(0, num6 - num4);
          this.VAR_CurrentRecruits = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(9);
          this.VAR_RecruitGrowth = this.newItems.FindWeight(9);
        }
        num3 += 1;
      }
      while (num3 <= 2);
      let mut num15: i32 = 0;
      let mut index5: i32 =  Math.Round((double) this.ai.game.Data.RuleVar[407]) + 5;
      let mut index6: i32 =  Math.Round((double) this.ai.game.Data.RuleVar[407]) + 2;
      let mut index7: i32 =  Math.Round((double) this.ai.game.Data.RuleVar[407]) + 0;
      let mut index8: i32 =  Math.Round((double) this.ai.game.Data.RuleVar[407]) + 9;
      let mut index9: i32 =  Math.Round((double) this.ai.game.Data.RuleVar[407]) + 8;
      let mut index10: i32 =  Math.Round((double) this.ai.game.Data.RuleVar[407]) + 7;
      this.VAR_UnitsCurrentAmmo = 0;
      this.VAR_UnitsIdealAmmo = 0;
      this.VAR_UnitsCurrentFuel = 0;
      this.VAR_UnitsIdealFuel = 0;
      this.VAR_UnitsFutureFuel = 0;
      this.VAR_UnitsCurrentEnergy = 0;
      this.VAR_UnitsIdealEnergy = 0;
      this.VAR_UnitsCurrentAtomics = 0;
      this.VAR_UnitsIdealAtomics = 0;
      let mut num16: i32 = 0;
      if (this.ai.game.EventRelatedObj.Helper_AirEnabled() & this.strategicAi.Air_Yes)
      {
        let mut num17: i32 = 0;
        let mut num18: i32 = 0;
        let mut num19: i32 = 0;
        let mut num20: i32 = 0;
        let mut num21: i32 = 0;
        let mut num22: i32 = 0;
        let mut num23: i32 = 0;
        let mut num24: i32 = 0;
        let mut num25: i32 = 0;
        let mut num26: i32 = 0;
        let mut unitCounter: i32 = this.data.UnitCounter;
        for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
        {
          if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1 && this.ai.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr))
          {
            if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unr))
            {
              if (this.ai.GetAIRolePercent(unr, 13) > 50)
              {
                num22 += 1;
                num23 += 1;
              }
              else if (this.ai.GetAIRolePercent(unr, 14) > 50)
              {
                num22 += 1;
                num24 += 1;
              }
              else if (this.ai.GetAIRolePercent(unr, 15) > 50)
              {
                num22 += 1;
                num25 += 1;
              }
            }
            else if (this.data.UnitObj[unr].AIAttack != 1)
            {
              let mut historical: i32 = this.data.UnitObj[unr].Historical;
              if (historical > -1 && this.data.HistoricalUnitObj[historical].GiveHisVarValue(11) < 1)
              {
                num17 += 1;
                if (this.ai.GetAIRolePercent(unr, 8) > 33)
                  num18 += 1;
                else if (this.ai.GetAIRolePercent(unr, 10) > 33)
                  num20 += 1;
                else if (this.ai.GetAIRolePercent(unr, 6) > 33)
                  num19 += 1;
                else
                  num21 += 1;
                num15 = -1;
                if (!this.data.UnitObj[unr].AIReserve)
                  num26 += 1;
                else
                  num26 = num26;
              }
            }
            else
              num15 = num15;
          }
        }
        if ((double) (num22 + 1) < (double) (num17 * this.strategicAi.Air_Aircraft_AsPercentage_Of_Land) / 100.0)
        {
          let mut num27: i32 =  Math.Round((double) (num17 * this.strategicAi.Air_Aircraft_AsPercentage_Of_Land) / 100.0 - (double) (num22 + 1));
          if (num27 < 0)
            num27 = 0;
          if (num27 > 2)
            num27 = 2;
          this.VAR_UnitsFutureFuel += num27 * 100;
        }
      }
      let mut num28: i32 = 0;
      let mut unitCounter1: i32 = this.data.UnitCounter;
      for (let mut unr: i32 = 0; unr <= unitCounter1; unr += 1)
      {
        if (this.data.UnitObj[unr].PreDef == -1 & this.data.UnitObj[unr].Regime == this.data.Turn && this.ai.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr) && this.data.HistoricalUnitObj[this.data.UnitObj[unr].Historical].GiveHisVarValue(11) < 1)
        {
          let mut num29: i32 = 0;
          let mut sfCount1: i32 = this.data.UnitObj[unr].SFCount;
          for (let mut index11: i32 = 0; index11 <= sfCount1; index11 += 1)
            num29 += this.data.SFObj[this.data.UnitObj[unr].SFList[index11]].Qty;
          num28 += num29;
          let mut num30: i32 = 0;
          let mut historical: i32 = this.data.UnitObj[unr].Historical;
          if (historical > -1)
          {
            let mut index12: i32 = 0;
            do
            {
              let mut subPart: i32 = this.data.HistoricalUnitObj[historical].SubParts[index12];
              if (subPart > -1)
              {
                let mut preDef: i32 = this.ai.game.HandyFunctionsObj.GetPreDef(subPart);
                let mut sfCount2: i32 = this.data.UnitObj[preDef].SFCount;
                for (let mut index13: i32 = 0; index13 <= sfCount2; index13 += 1)
                  num30 += this.data.SFObj[this.data.UnitObj[preDef].SFList[index13]].Qty;
              }
              index12 += 1;
            }
            while (index12 <= 9);
          }
          if (num30 > num29)
            num15 += num30 - num29;
          let mut sfCount3: i32 = this.ai.game.Data.UnitObj[unr].SFCount;
          for (let mut index14: i32 = 0; index14 <= sfCount3; index14 += 1)
          {
            let mut sf: i32 = this.ai.game.Data.UnitObj[unr].SFList[index14];
            let mut type: i32 = this.ai.game.Data.SFObj[sf].Type;
            let mut qty: i32 = this.ai.game.Data.SFObj[sf].Qty;
            let mut num31: i32 = this.ai.game.Data.SFTypeObj[type].SFTypeVar[index5];
            let mut num32: i32 = this.ai.game.Data.SFTypeObj[type].SFTypeVar[index8] * qty;
            if (num31 > 0 & num32 > 0)
            {
              if (num31 == 7)
                this.VAR_UnitsIdealFood +=  Math.Round((double) num32 / 2.0);
              if (num31 == 15)
                this.VAR_UnitsIdealEnergy +=  Math.Round((double) num32 / 2.0);
            }
            let mut num33: i32 = this.ai.game.Data.SFTypeObj[type].SFTypeVar[index6];
            let mut num34: i32 = this.ai.game.Data.SFTypeObj[type].SFTypeVar[index9] * qty;
            if (num33 > 0 & num34 > 0)
            {
              if (num33 == 10)
                this.VAR_UnitsIdealAmmo +=  Math.Round((double) num34 * 0.66);
              if (num33 == 15)
                this.VAR_UnitsIdealEnergy +=  Math.Round((double) num34 * 0.66);
              if (num33 == 4)
                this.VAR_UnitsIdealAtomics +=  Math.Round((double) num34 * 0.66);
            }
            let mut num35: i32 = this.ai.game.Data.SFTypeObj[type].SFTypeVar[index7];
            let mut num36: i32 = this.ai.game.Data.SFTypeObj[type].SFTypeVar[index10] * qty;
            if (num35 > 0 & num36 > 0)
            {
              if (num35 == 1)
                this.VAR_UnitsIdealFuel += num36;
              if (num35 == 15)
                this.VAR_UnitsIdealEnergy += num36;
              if (num35 == 4)
                this.VAR_UnitsIdealAtomics += num36;
            }
          }
          this.VAR_UnitsCurrentFood += this.ai.game.Data.UnitObj[unr].items.list.FindWeight(7);
          this.VAR_UnitsCurrentAmmo += this.ai.game.Data.UnitObj[unr].items.list.FindWeight(10);
          this.VAR_UnitsCurrentFuel += this.ai.game.Data.UnitObj[unr].items.list.FindWeight(1);
          this.VAR_UnitsCurrentEnergy += this.ai.game.Data.UnitObj[unr].items.list.FindWeight(15);
          this.VAR_UnitsCurrentAtomics += this.ai.game.Data.UnitObj[unr].items.list.FindWeight(4);
          num16 += this.data.HistoricalUnitObj[historical].GiveHisVarValue(81) * num29;
        }
      }
      this.VAR_CurrentSoldier = num28;
      this.VAR_SoldierMissing = num15;
      this.VAR_SoldierHunger =  Math.Round((double) num16 / (double) (num28 + 1));
      let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 292, 0, 0));
      let mut num37: i32 = 0;
      let mut num38: i32 = 0;
      let mut num39: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData4(0, "National", 1, this.data.Turn.ToString(), 2, "SizeHex", 3, this.data.Round.ToString(), 4)));
      let mut num40: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData4(0, "National", 1, this.data.Turn.ToString(), 2, "SizeHex", 3, (this.data.Round - 2).ToString(), 4)));
      let mut num41: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData4(0, "National", 1, this.data.Turn.ToString(), 2, "SizeHex", 3, (this.data.Round - 5).ToString(), 4)));
      let mut num42: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData4(0, "National", 1, this.data.Turn.ToString(), 2, "SizeHex", 3, (this.data.Round - 10).ToString(), 4)));
      let mut num43: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData4(0, "National", 1, this.data.Turn.ToString(), 2, "SizeHex", 3, (this.data.Round - 20).ToString(), 4)));
      let mut num44: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData4(0, "National", 1, this.data.Turn.ToString(), 2, "SizeHex", 3, (this.data.Round - 100).ToString(), 4)));
      let mut regimeCounter1: i32 = this.data.RegimeCounter;
      for (let mut index15: i32 = 2; index15 <= regimeCounter1; index15 += 1)
      {
        let mut num45: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.data.RegimeObj[index15].id, 1, "victoryScore", 2)));
        if (index15 == this.data.Turn)
          num38 = num45;
        else if (num45 > num37)
          num37 = num45;
      }
      let mut num46: i32 =  Math.Round((double) num38 / 10.0);
      let mut num47: i32 =  Math.Round((double) num37 / 10.0);
      bool flag1 = false;
      bool flag2 = false;
      if (num47 != num46)
      {
        if (num47 > 50 & num46 < num47 - 10)
          flag1 = true;
        else if (num47 > 30 & num46 < num47 - 15)
          flag2 = true;
      }
      let mut num48: i32 = 0;
      let mut num49: i32 = 0;
      let mut num50: i32 = 0;
      let mut num51: i32 = 0;
      if (num40 > 0)
        num48 =  Math.Round((double) ((num39 - num40) * 100) / (double) num39);
      if (num41 > 0)
        num49 =  Math.Round((double) ((num39 - num41) * 100) / (double) num39);
      if (num42 > 0)
        num50 =  Math.Round((double) ((num39 - num42) * 100) / (double) num39);
      if (num43 > 0)
        num51 =  Math.Round((double) ((num39 - num43) * 100) / (double) num39);
      let mut num52: i32 = this.VAR_CurrentPop + this.VAR_CurrentRecruits + this.VAR_CurrentSoldier + this.VAR_CurrentWorker;
      let mut num53: i32 =  Math.Round((double) num52 * 0.35);
      let mut num54: i32 =  Math.Round((double) num52 * 0.2);
      if (num51 < -50 & num50 < -50)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.6);
      }
      else if (num51 < -40 | num50 < -40)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.5);
      }
      else if (num51 < -30 | num50 < -30)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.45);
      }
      else if (num50 < -20 | num51 < -20)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.4);
      }
      else if (num50 < -10 | num49 < -10)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.4);
      }
      else if (num49 < -10)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.4);
      }
      else if (num49 < -5)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.35);
      }
      else if (num48 < -12)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.3);
      }
      else if (num48 < -5)
      {
        num53 =  Math.Round((double) num52 * 0.35);
        num54 =  Math.Round((double) num52 * 0.25);
      }
      if (this.shqStage <= 1)
        num54 =  Math.Round((double) num54 * 0.5);
      else if (this.shqStage <= 2)
        num54 =  Math.Round((double) num54 * 0.6);
      else if (this.shqStage <= 3)
        num54 =  Math.Round((double) num54 * 0.7);
      else if (this.shqStage <= 4)
        num54 =  Math.Round((double) num54 * 0.8);
      else if (this.shqStage <= 5)
        num54 =  Math.Round((double) num54 * 0.9);
      let mut regimeCounter2: i32 = this.ai.game.Data.RegimeCounter;
      for (let mut index16: i32 = 2; index16 <= regimeCounter2; index16 += 1)
      {
        if (!this.ai.game.Data.RegimeObj[index16].AI && this.ai.game.Data.RegimeObj[index16].RegimeRel[this.ai.game.Data.Turn] == 0)
          num54 +=  Math.Round((double) this.VAR_FreePopReserve * 0.1);
      }
      if (flag1)
      {
        let mut num55: i32 = num52 - (num53 + num54);
        if (num55 > 0)
          num54 += num55;
      }
      if (flag2)
      {
        let mut num56: i32 = num52 - (num53 + num54);
        if (num56 > 0)
          num54 +=  Math.Round((double) num56 / 2.0);
      }
      if (this.data.Round > 10)
        num54 +=  Math.Round((double) num52 * 0.05);
      if (this.data.Round > 30)
        num54 +=  Math.Round((double) num52 * 0.04);
      if (this.data.Round > 60)
        num54 +=  Math.Round((double) num52 * 0.03);
      if (this.data.Round > 100)
        num54 +=  Math.Round((double) num52 * 0.02);
      if (num46 > 33)
        num54 +=  Math.Round((double) num52 * 0.05);
      if (num46 > 42)
        num54 +=  Math.Round((double) num52 * 0.05);
      if (num46 > 55)
        num54 +=  Math.Round((double) num52 * 0.05);
      let mut num57: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
      if (num57 >= 30)
        num54 +=  Math.Round((double) this.VAR_FreePopReserve * 0.4);
      else if (num57 >= 20)
        num54 +=  Math.Round((double) this.VAR_FreePopReserve * 0.3);
      else if (num57 >= 10)
      {
        num54 +=  Math.Round((double) this.VAR_FreePopReserve * 0.2);
      }
      else
      {
        if (num54 >= 200)
          num54 = 200 +  Math.Round((double) (num54 - 200) / 2.0);
        if (num53 >= 500)
          num53 = 500 +  Math.Round((double) (num53 - 500) / 2.0);
      }
      if (num52 < num53 + num54 & num52 > 0)
      {
        num53 =  Math.Round((double) num53 * ((double) num52 / (double) (num53 + num54)));
        num54 =  Math.Round((double) num54 * ((double) num52 / (double) (num53 + num54)));
      }
      this.VAR_IdealWorker = num53;
      this.VAR_IdealSoldier = num54;
      if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double) this.itemProduction[7])
      {
        if (this.VAR_IdealSoldier > this.VAR_CurrentSoldier)
          this.VAR_IdealSoldier = this.VAR_CurrentSoldier;
      }
      else if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double)  Math.Round(0.9 * (double) this.itemProduction[7]))
      {
        if (this.VAR_IdealSoldier > this.VAR_CurrentSoldier)
          this.VAR_IdealSoldier =  Math.Round(0.66 * (double) this.VAR_CurrentSoldier) +  Math.Round(0.33 * (double) this.VAR_IdealSoldier);
      }
      else if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double)  Math.Round(0.8 * (double) this.itemProduction[7]))
      {
        if (this.VAR_IdealSoldier > this.VAR_CurrentSoldier)
          this.VAR_IdealSoldier =  Math.Round(0.5 * (double) this.VAR_CurrentSoldier) +  Math.Round(0.5 * (double) this.VAR_IdealSoldier);
      }
      else if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double)  Math.Round(0.7 * (double) this.itemProduction[7]) && this.VAR_IdealSoldier > this.VAR_CurrentSoldier)
        this.VAR_IdealSoldier =  Math.Round(0.33 * (double) this.VAR_CurrentSoldier) +  Math.Round(0.66 * (double) this.VAR_IdealSoldier);
      if (this.VAR_IdealSoldier > Math.Max(65 + this.VAR_CurrentSoldier, this.VAR_CurrentSoldier * 3))
        this.VAR_IdealSoldier = Math.Max(65 + this.VAR_CurrentSoldier, 10 + this.VAR_CurrentSoldier * 3);
      let mut num58: i32 = Math.Min(100,  Math.Round((double) this.VAR_CurrentPop / 2.0));
      let mut num59: i32 = this.VAR_CurrentPop * 1 >= num58 ? ((double) this.VAR_CurrentPop * 0.75 >= (double) num58 ? ((double) this.VAR_CurrentPop * 0.66 >= (double) num58 ? ((double) this.VAR_CurrentPop * 0.5 >= (double) num58 ? num58 :  Math.Round((double) num58 / 2.0)) :  Math.Round((double) num58 / 4.0)) :  Math.Round((double) num58 / 10.0)) : 0;
      if (this.VAR_PopShortage > 0)
      {
        let mut varPopShortage: i32 = this.VAR_PopShortage;
        num59 = (double) varPopShortage <= (double) this.VAR_CurrentPop / 2.0 ? ((double) varPopShortage <= (double) this.VAR_CurrentPop / 3.0 ? ((double) varPopShortage <= (double) this.VAR_CurrentPop / 5.0 ? ((double) varPopShortage <= (double) this.VAR_CurrentPop / 10.0 ? num59 : num59) :  Math.Round((double) num59 / 1.5)) :  Math.Round((double) num59 / 3.0)) : 0;
      }
      if ((double) this.VAR_CurrentWorker > (double) this.VAR_IdealWorker * 1.3)
        num59 = 0;
      else if ((double) this.VAR_CurrentWorker > (double) this.VAR_IdealWorker * 1.2)
        num59 =  Math.Round((double) num59 / 9.0);
      else if ((double) this.VAR_CurrentWorker > (double) this.VAR_IdealWorker * 1.1)
        num59 =  Math.Round((double) num59 / 6.0);
      else if (this.VAR_CurrentWorker > this.VAR_IdealWorker * 1)
        num59 =  Math.Round((double) num59 / 3.0);
      let mut num60: i32 = (double) this.VAR_FreePopReserve <= (double) this.VAR_CurrentPop * 0.5 ? ((double) this.VAR_FreePopReserve <= (double) this.VAR_CurrentPop * 0.4 ? ((double) this.VAR_FreePopReserve <= (double) this.VAR_CurrentPop * 0.3 ? ((double) this.VAR_FreePopReserve <= (double) this.VAR_CurrentPop * 0.2 ? ((double) this.VAR_FreePopReserve <= (double) this.VAR_CurrentPop * 0.1 ? num59 +  Math.Round((double) this.VAR_FreePopReserve * 0.2) : num59 +  Math.Round((double) this.VAR_FreePopReserve * 0.35)) : num59 +  Math.Round((double) this.VAR_FreePopReserve * 0.5)) : num59 +  Math.Round((double) this.VAR_FreePopReserve * 0.65)) : num59 +  Math.Round((double) this.VAR_FreePopReserve * 0.8)) : num59 +  Math.Round((double) this.VAR_FreePopReserve * 0.9);
      let mut weight: i32 = this.newItems.FindWeight(7);
      if (weight <= 0)
      {
        this.VAR_IdealWorker = Math.Min(this.VAR_IdealWorker, this.VAR_CurrentWorker - this.VAR_FreeWorkerReserve);
        this.VAR_FreeWorkerReserve = 0;
      }
      else if (weight > 0)
      {
        this.VAR_IdealWorker = Math.Min(this.VAR_IdealWorker, this.VAR_CurrentWorker - this.VAR_FreeWorkerReserve +  Math.Round((double) weight / 2.0));
        if (this.VAR_IdealWorker - this.VAR_CurrentWorker > this.VAR_FreeWorkerReserve)
          this.VAR_FreeWorkerReserve = this.VAR_IdealWorker - this.VAR_CurrentWorker;
      }
      this.VAR_WorkerExcess = this.VAR_CurrentWorker - this.VAR_WorkerJobsMax;
      if (this.VAR_WorkerExcess < 0)
        this.VAR_WorkerExcess = 0;
      this.VAR_WorkerShortage = this.VAR_WorkerJobsMax - this.VAR_CurrentWorker;
      if (this.VAR_WorkerShortage < 0)
        this.VAR_WorkerShortage = 0;
      if (this.VAR_FreeWorkerReserve < this.VAR_CurrentWorker - this.VAR_CurrentWorker)
        this.VAR_FreeWorkerReserve = this.VAR_CurrentWorker - this.VAR_CurrentWorker;
      this.VAR_FreeWorkerReservePlus = this.VAR_FreeWorkerReserve;
      let mut num61: i32 =  Math.Round((double) num1 / (double) Math.Max(1,  Math.Round((double) num2 / 15.0)));
      if (num1 > 0)
        num60 =  Math.Round((double) num60 / (double) (num61 + 1));
      this.VAR_FreeWorkerReservePlus += num60;
      if ((double) this.VAR_UnitsIdealFood > (double) this.VAR_UnitsCurrentFood * 3.3)
      {
        this.VAR_IdealSoldier = Math.Min(this.VAR_IdealSoldier,  Math.Round((double) this.VAR_CurrentSoldier * 0.75));
        this.VAR_SoldierMissing = 0;
      }
      else if ((double) this.VAR_UnitsIdealFood > (double) this.VAR_UnitsCurrentFood * 2.4)
      {
        this.VAR_IdealSoldier = Math.Min(this.VAR_IdealSoldier,  Math.Round((double) ((float) this.VAR_CurrentSoldier * 1f)));
        this.VAR_SoldierMissing =  Math.Round((double) this.VAR_SoldierMissing / 3.0);
      }
      let mut num62: i32 = this.VAR_CurrentSoldier >= 30 ? (this.VAR_CurrentSoldier >= 100 ? (this.VAR_CurrentSoldier >= 200 ? (this.VAR_CurrentSoldier >= 300 ? (this.VAR_CurrentSoldier >= 500 ? (this.VAR_CurrentSoldier >= 700 ? (this.VAR_CurrentSoldier >= 900 ? (this.VAR_CurrentSoldier >= 1200 ? (this.VAR_CurrentSoldier >= 1600 ? (this.VAR_CurrentSoldier >= 2000 ? (this.VAR_CurrentSoldier >= 3000 ? (this.VAR_CurrentSoldier >= 4000 ? 700 : 600) : 500) : 450) : 400) : 350) : 300) : 250) : 210) : 170) : 130) : 90) : 60;
      this.VAR_IdealSoldier_BeforeMaxRecruit = this.VAR_IdealSoldier;
      if (this.VAR_CurrentRecruits > num62)
        this.VAR_IdealSoldier = this.VAR_CurrentRecruits + this.VAR_CurrentSoldier;
      if (this.shqConstructionBlock)
      {
        if (this.VAR_FreeWorkerReserve > 0 | this.VAR_WorkerShortage < 5)
          this.shqConstructionBlock = false;
        else
          this.ai.AddLog("NO MORE CONSTRUCTION STARTS IN ZONE!");
      }
      let mut num63: i32 =  Math.Round((double) (100 * this.VAR_CurrentSoldier) / (double) Math.Max(1, this.VAR_IdealSoldier));
      let mut num64: i32 = 0;
      if (num63 < 5)
        num64 = 3;
      else if (num63 < 11)
        num64 = 2;
      else if (num63 < 22)
        num64 = 1;
      if (num64 > 0)
      {
        let mut num65: i32 = this.shqStage - num64;
        if (num65 < 1)
          num65 = 1;
        this.ai.AddLog("REDUCED STAGE MODIFIED FROM " + this.shqStage.ToString() + " to " + num65.ToString() + "!");
        this.shqStage = num65;
      }
      this.ai.AddLog("");
      this.ai.AddLog("VAR_CurrentPop = " + this.VAR_CurrentPop.ToString());
      this.ai.AddLog("VAR_FreePopReserve = " + this.VAR_FreePopReserve.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_CurrentRecruits = " + this.VAR_CurrentRecruits.ToString());
      this.ai.AddLog("maxRecruits = " + num62.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_CurrentSoldier = " + this.VAR_CurrentSoldier.ToString());
      this.ai.AddLog("VAR_IdealSoldier_BeforeMaxRecruit = " + this.VAR_IdealSoldier_BeforeMaxRecruit.ToString());
      this.ai.AddLog("VAR_IdealSoldier = " + this.VAR_IdealSoldier.ToString());
      this.ai.AddLog("VAR_SoldierMissing= " + this.VAR_SoldierMissing.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_WorkerJobsMax (all assets active) = " + this.VAR_WorkerJobsMax.ToString());
      this.ai.AddLog("VAR_WorkerJobsCurrent = " + this.VAR_WorkerJobsCurrent.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_CurrentWorker = " + this.VAR_CurrentWorker.ToString());
      this.ai.AddLog("VAR_IdealWorker= " + this.VAR_IdealWorker.ToString());
      this.ai.AddLog("VAR_WorkerShortage " + this.VAR_WorkerShortage.ToString());
      this.ai.AddLog("VAR_WorkerExcess " + this.VAR_WorkerExcess.ToString());
      this.ai.AddLog("VAR_FreeWorkerReserve = " + this.VAR_FreeWorkerReserve.ToString());
      this.ai.AddLog("VAR_FreeWorkerReservePlus = " + this.VAR_FreeWorkerReservePlus.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_UnitCurrentFuel= " + this.VAR_UnitsCurrentFuel.ToString());
      this.ai.AddLog("VAR_UnitsIdealFuel= " + this.VAR_UnitsIdealFuel.ToString());
      this.ai.AddLog("VAR_UnitsFutureFuel= " + this.VAR_UnitsFutureFuel.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_UnitsCurrentAmmo= " + this.VAR_UnitsCurrentAmmo.ToString());
      this.ai.AddLog("VAR_UnitsIdealAmmo= " + this.VAR_UnitsIdealAmmo.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_UnitsCurrentFood= " + this.VAR_UnitsCurrentFood.ToString());
      this.ai.AddLog("VAR_UnitsIdealFood= " + this.VAR_UnitsIdealFood.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_UnitsCurrentEnergy= " + this.VAR_UnitsCurrentEnergy.ToString());
      this.ai.AddLog("VAR_UnitsIdealEnergy= " + this.VAR_UnitsIdealEnergy.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_UnitsCurrentAtomics= " + this.VAR_UnitsCurrentAtomics.ToString());
      this.ai.AddLog("VAR_UnitsIdealAtomics= " + this.VAR_UnitsIdealAtomics.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("VAR_WorkerHunger= " + this.VAR_WorkerHunger.ToString());
      this.ai.AddLog("VAR_PopHunger= " + this.VAR_PopHunger.ToString());
      this.ai.WriteLog(str);
    }

    pub void ConfigureSHQarea(int i)
    {
      DrawMod.TGame.EventRelatedObj.cacheAssetPresUsage = false;
      DrawMod.TGame.EventRelatedObj.cacheAssetPresList = SimpleStringList::new();
      this.shqHisId = this.ShqList.Id[i];
      this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
      this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
      this.shqStage = this.ShqList.Data1[i];
      this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
      this.shqZoneId = this.zones.Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y];
      if (this.shqZoneId > 0)
      {
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, this.shqZoneId, 6)));
        if (id > 0)
        {
          let mut locationById: i32 = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1 && this.data.LocObj[locationById].HQ == -1)
            this.data.LocObj[locationById].HQ = this.shqUnitNr;
        }
      }
      if (this.shqUnitNr > -1)
        this.data.UnitObj[this.shqUnitNr].items.list.removeWeight0orLower();
      name1: String = "9002_" + this.shqName + "_ConfigureSHQarea";
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      this.ai.AddLog("");
      this.itemRegimeKeyProdList = SimpleStringList::new();
      let mut poolCounter: i32 = this.poolCounter;
      for (let mut index: i32 = 1; index <= poolCounter; index += 1)
      {
        this.poolPreferedAssetType[index] = 0;
        this.poolMinimumStage[index] = 1;
        this.poolConstrBlocked[index] = false;
        this.poolRequest[index] = SimpleList::new();
        this.poolItems[index] = SimpleList::new();
      }
      let mut itemcounter1: i32 = this.itemcounter;
      for (let mut index1: i32 = 1; index1 <= itemcounter1; index1 += 1)
      {
        this.itemProduction[index1] = 0;
        this.itemProductionPublic[index1] = 0;
        this.itemNeed[index1] = 0;
        this.itemMiningReserve[index1] = 0;
        this.itemQty[index1] = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(index1);
        this.itemName[index1] = this.data.StringListObj[this.slotItemType].GetData(0, index1, 1);
        int[] itemNeed = this.itemNeed;
        int[] numArray = itemNeed;
        let mut index2: i32 = index1;
        let mut index3: i32 = index2;
        let mut num: i32 = itemNeed[index2] + this.ai.game.Data.UnitObj[this.shqUnitNr].CheckLogReturnData3(103, index1);
        numArray[index3] = num;
      }
      let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut index4: i32 = 0; index4 <= length1; index4 += 1)
      {
        let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index4, 0]));
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index4, 6]));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index4, 8])) == this.RegimeId && id > 0)
        {
          this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          EventRelatedClass eventRelatedObj1 = this.ai.game.EventRelatedObj;
          let mut onlyZoneId1: i32 = idValue;
          SimpleList simpleList1 = (SimpleList) null;
           SimpleList local1 =  simpleList1;
          SimpleList simpleList2 = (SimpleList) null;
           SimpleList local2 =  simpleList2;
          eventRelatedObj1.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId1, "", dontDoGovReserves: true, itemsProdModList: ( local1), itemsUpkeepModList: ( local2));
          let mut length2: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
          for (let mut index5: i32 = 0; index5 <= length2; index5 += 1)
          {
            let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index5, 0]));
            if (num1 > 0)
            {
              let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index5, 3]));
              int[] itemNeed = this.itemNeed;
              int[] numArray = itemNeed;
              let mut index6: i32 = num1;
              let mut index7: i32 = index6;
              let mut num3: i32 = itemNeed[index6] + num2;
              numArray[index7] = num3;
            }
          }
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "emergencyFoodGiven", 2)));
          if (num4 > 0)
          {
            int[] itemNeed = this.itemNeed;
            int[] numArray = itemNeed;
            let mut index8: i32 = 7;
            let mut index9: i32 = index8;
            let mut num5: i32 = itemNeed[index8] +  Math.Round((double) num4 * 1.5);
            numArray[index9] = num5;
          }
          EventRelatedClass eventRelatedObj2 = this.ai.game.EventRelatedObj;
          let mut onlyZoneId2: i32 = idValue;
          SimpleList simpleList3 = (SimpleList) null;
           SimpleList local3 =  simpleList3;
          SimpleList simpleList4 = (SimpleList) null;
           SimpleList local4 =  simpleList4;
          eventRelatedObj2.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId2, "", true, dontDoGovReserves: true, modifyForFutureDepletion: true, itemsProdModList: ( local3), itemsUpkeepModList: ( local4));
          let mut length3: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
          for (let mut index10: i32 = 0; index10 <= length3; index10 += 1)
          {
            let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index10, 0]));
            if (num6 > 0)
            {
              let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index10, 4]));
              int[] itemProduction = this.itemProduction;
              int[] numArray = itemProduction;
              let mut index11: i32 = num6;
              let mut index12: i32 = index11;
              let mut num8: i32 = itemProduction[index11] + num7;
              numArray[index12] = num8;
            }
          }
          EventRelatedClass eventRelatedObj3 = this.ai.game.EventRelatedObj;
          let mut onlyZoneId3: i32 = idValue;
          SimpleList simpleList5 = (SimpleList) null;
           SimpleList local5 =  simpleList5;
          SimpleList simpleList6 = (SimpleList) null;
           SimpleList local6 =  simpleList6;
          eventRelatedObj3.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId3, "", true, dontDoGovReserves: true, modifyForFutureDepletion: true, onlyPublic: true, itemsProdModList: ( local5), itemsUpkeepModList: ( local6));
          let mut length4: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
          for (let mut index13: i32 = 0; index13 <= length4; index13 += 1)
          {
            let mut num9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index13, 0]));
            if (num9 > 0)
            {
              let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index13, 4]));
              int[] productionPublic = this.itemProductionPublic;
              int[] numArray = productionPublic;
              let mut index14: i32 = num9;
              let mut index15: i32 = index14;
              let mut num11: i32 = productionPublic[index14] + num10;
              numArray[index15] = num11;
            }
          }
        }
      }
      data1: DataClass = this.data;
      str1: String = "perk";
       local7: String =  str1;
      let mut libVar1: i32 = data1.FindLibVar( local7, "SE_Data");
      data2: DataClass = this.data;
      str2: String = "zones";
       local8: String =  str2;
      let mut libVar2: i32 = data2.FindLibVar( local8, "SE_Data");
      let mut stringListById1: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 381, 0, 0));
      let mut mapWidth1: i32 = this.data.MapObj[0].MapWidth;
      int num12;
      for (let mut index16: i32 = 0; index16 <= mapWidth1; index16 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index17: i32 = 0; index17 <= mapHeight; index17 += 1)
        {
          let mut hexLibVarValue1: i32 = this.data.MapObj[0].HexObj[index16, index17].GetHexLibVarValue(libVar1);
          if (hexLibVarValue1 > 0 && this.data.MapObj[0].HexObj[index16, index17].Regime == this.data.Turn)
          {
            let mut hexLibVarValue2: i32 = this.data.MapObj[0].HexObj[index16, index17].GetHexLibVarValue(libVar2);
            if (hexLibVarValue2 > 0)
            {
              let mut id1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, hexLibVarValue2, 6)));
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, hexLibVarValue2, 8))) == this.RegimeId && id1 > 0)
              {
                let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id1);
                if (locationById > -1 && this.data.LocObj[locationById].HQ == this.shqUnitNr)
                {
                  let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData(0, hexLibVarValue1, 2)));
                  data3: String = this.data.StringListObj[stringListById1].GetData(0, hexLibVarValue1, 3);
                  num12 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData(0, hexLibVarValue1, 4)));
                  data4: String = this.data.StringListObj[stringListById1].GetData(0, hexLibVarValue1, 5);
                  let mut num14: i32 = 0;
                  if (num13 == 3)
                  {
                    if (data4.Length > 0)
                    {
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "ZONEID", 1, hexLibVarValue2, true);
                      EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                      let mut id2: i32 = this.data.StringListObj[this.slotFlags].ID;
                      let mut id3: i32 = this.data.StringListObj[this.slotFlagInstructions].ID;
                      logicString: String = data4;
                      Random random = (Random) null;
                       Random local9 =  random;
                      num14 = eventRelatedObj.CheckLogicStringStart(id2, id3, logicString, 0,  local9);
                    }
                    if (num14 > 0)
                    {
                      let mut num15: i32 =  Math.Round(Conversion.Val(data3));
                      int[] itemProduction = this.itemProduction;
                      int[] numArray = itemProduction;
                      let mut index18: i32 = num15;
                      let mut index19: i32 = index18;
                      let mut num16: i32 = itemProduction[index18] + num14;
                      numArray[index19] = num16;
                    }
                  }
                }
              }
            }
          }
        }
      }
      let mut num17: i32 = 0;
      let mut length5: i32 = this.data.StringListObj[this.slotZones].Length;
      for (i = 0; i <= length5; i += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[i, 8])) == this.RegimeId)
        {
          let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[i, 0]));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "popHunger", 2))) > 0)
          {
            let mut num18: i32 = Math.Max(0,  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "pop", 2))) -  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "privateFood", 2))));
            num17 += num18;
          }
          num17 += Math.Max(0,  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "worker", 2))));
        }
      }
      let mut unitCounter: i32 = this.data.UnitCounter;
      for (i = 0; i <= unitCounter; i += 1)
      {
        if (this.data.UnitObj[i].Regime == this.data.Turn & this.data.UnitObj[i].PreDef == -1)
        {
          let mut num19: i32 = 0;
          if (this.data.UnitObj[i].IsHQ | this.data.HistoricalUnitObj[this.data.UnitObj[i].Historical].GiveHisVarValue(11) < 1)
          {
            let mut sfCount: i32 = this.data.UnitObj[i].SFCount;
            for (let mut index: i32 = 0; index <= sfCount; index += 1)
              num19 += this.data.SFObj[this.data.UnitObj[i].SFList[index]].Qty;
          }
          if (this.data.HistoricalUnitObj[this.data.UnitObj[i].Historical].Type == 8)
            num19 += this.data.UnitObj[i].items.list.FindWeight(9);
          num17 += num19;
        }
      }
      int[] itemNeed1 = this.itemNeed;
      int[] numArray1 = itemNeed1;
      let mut index20: i32 = 7;
      let mut index21: i32 = index20;
      let mut num20: i32 = itemNeed1[index20] + num17;
      numArray1[index21] = num20;
      this.newItems = SimpleList::new();
      this.decreasedItems = SimpleList::new();
      let mut itemcounter2: i32 = this.itemcounter;
      int num21;
      for (i = 1; i <= itemcounter2; i += 1)
      {
        num21 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(i) -  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOldShqItems].GetData2(0, this.shqHisId, 2, i, 3)));
        let mut logCounter: i32 = this.data.UnitObj[this.shqUnitNr].LogCounter;
        for (let mut index22: i32 = 0; index22 <= logCounter; index22 += 1)
        {
          if (this.data.UnitObj[this.shqUnitNr].LogType[index22] == 301 && this.data.UnitObj[this.shqUnitNr].LogData1[index22] == i)
            num21 += this.data.UnitObj[this.shqUnitNr].LogData3[index22];
        }
        if (num21 > 0)
        {
          this.newItems.AddWeight(i, num21);
          this.ai.AddLog("New + " + this.itemName[i] + " : " + num21.ToString());
        }
        else if (num21 < 0)
        {
          num21 = Math.Abs(num21);
          this.decreasedItems.AddWeight(i, num21);
          this.ai.AddLog("Decreased Stocks with -" + this.itemName[i] + " : " + num21.ToString());
        }
        this.ai.AddLog("Current " + this.itemName[i] + ": " + this.itemQty[i].ToString());
      }
      this.ownerMatrix = new AIMatrix( this.ai.game.DC2AIObj);
      let mut mapWidth2: i32 = this.data.MapObj[0].MapWidth;
      for (let mut index23: i32 = 0; index23 <= mapWidth2; index23 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index24: i32 = 0; index24 <= mapHeight; index24 += 1)
          this.ownerMatrix.Value[index23, index24] = this.data.MapObj[0].HexObj[index23, index24].Regime != this.data.Turn ? (this.data.MapObj[0].HexObj[index23, index24].Regime != -1 ? 2 : 0) : 1;
      }
      this.supplyMatrix = new AIMatrix( this.ai.game.DC2AIObj);
      this.supplyCameFromMatrix = new AICoordinateMatrix( this.ai.game.DC2AIObj);
      this.supplyMatrix.SetAllValuesTo(9999);
      this.supplyMatrix.Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y] = 0;
      this.supplyMatrix.ExpandAsSimplifiedSupplyMatrix(this.ai.VAR_SUPPLY_ENEMY_MOVETYPE,  this.ownerMatrix, 2, this.supplyCameFromMatrix);
      AIMatrix aiMatrix = this.ai.SetMatrixEnemyUnitsAndRoadHexes();
      aiMatrix.ExpandValueForSameRegime();
      this.frontlinesMatrix = aiMatrix.DetectAndMakeEdgeMatrix(false);
      this.frontlinesMatrix.RemoveValuesByMask(this.ownerMatrix, 0);
      this.frontlinesMatrix.RemoveValuesByMask(this.ownerMatrix, 3);
      this.frontlinesMatrix.RemoveValuesByLandscapeAIBlock(0);
      this.frontlinesMatrix.ExpandSpecificValueForAnyRegime(1, 1);
      this.borderMatrix = new AIMatrix( this.ai.game.DC2AIObj);
      this.borderMatrix.SetAllValuesToWithMask(1,  this.ownerMatrix, 1);
      this.borderMatrix = this.borderMatrix.DetectAndMakeEdgeMatrix(false);
      this.borderMatrix.RemoveValuesByLandscapeAIBlock(0);
      this.borderMatrix.ExpandSpecificValueForAnyRegime(1, 1);
      this.zoneList = SimpleList::new();
      let mut num22: i32 = 0;
      let mut length6: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut tdata3: i32 = 0; tdata3 <= length6; tdata3 += 1)
      {
        let mut num23: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 0]));
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 6]));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 8])) == this.RegimeId && id > 0)
        {
          EventRelatedClass eventRelatedObj4 = this.ai.game.EventRelatedObj;
          let mut onlyZoneId4: i32 = num23;
          SimpleList simpleList7 = (SimpleList) null;
           SimpleList local10 =  simpleList7;
          SimpleList simpleList8 = (SimpleList) null;
           SimpleList local11 =  simpleList8;
          eventRelatedObj4.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId4, "", itemsProdModList: ( local10), itemsUpkeepModList: ( local11));
          this.itemRegimeKeyProdList.AddWeight("bp",  Math.Round(Conversion.Val(this.data.StringListObj[this.slotResult].GetData(1, "bp", 4))));
          let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1 && this.data.LocObj[locationById].HQ == this.shqUnitNr)
          {
            let mut x: i32 = this.data.LocObj[locationById].X;
            let mut y: i32 = this.data.LocObj[locationById].Y;
            EventRelatedClass eventRelatedObj5 = this.ai.game.EventRelatedObj;
            let mut onlyZoneId5: i32 = num23;
            simpleList7 = (SimpleList) null;
             SimpleList local12 =  simpleList7;
            SimpleList simpleList9 = (SimpleList) null;
             SimpleList local13 =  simpleList9;
            eventRelatedObj5.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId5, "", itemsProdModList: ( local12), itemsUpkeepModList: ( local13));
            let mut num24: i32 = 0;
            let mut num25: i32 = 0;
            let mut length7: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
            for (let mut index25: i32 = 0; index25 <= length7; index25 += 1)
            {
              if (Operators.CompareString(this.data.StringListObj[this.slotAssetPresentation].Data[index25, 1], "workerPoints", false) == 0)
                num24 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index25, 3]));
              if (Operators.CompareString(this.data.StringListObj[this.slotAssetPresentation].Data[index25, 1], "popPoints", false) == 0)
                num25 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index25, 3]));
            }
            num21 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num23, 1, "worker", 2)));
            let mut num26: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num23, 1, "pop", 2)));
            let mut tweight: i32 = (num24 - num21) * 4 + (num25 - num26);
            if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].GetData2(0, num23, 8, 1, 1))) > 0)
              num22 = 1;
            this.zoneList.Add(num23, tweight, x, y, tdata3);
          }
        }
      }
      if (num22 == 1)
        this.shqConstructionBlock = true;
      let mut mapWidth3: i32 = this.data.MapObj[0].MapWidth;
      for (let mut index26: i32 = 0; index26 <= mapWidth3; index26 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index27: i32 = 0; index27 <= mapHeight; index27 += 1)
        {
          if (this.zoneList.FindNr(this.zones.Value[index26, index27]) > -1)
          {
            index26 = index26;
          }
          else
          {
            this.frontlinesMatrix.Value[index26, index27] = 0;
            this.borderMatrix.Value[index26, index27] = 0;
          }
        }
      }
      let mut stringListById2: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 362, 0, 0));
      let mut mapWidth4: i32 = this.data.MapObj[0].MapWidth;
      let mut mapHeight1: i32 = this.data.MapObj[0].MapHeight;
      data5: DataClass = this.data;
      str3: String = "Zones";
       local14: String =  str3;
      let mut libVar3: i32 = data5.FindLibVar( local14, "SE_Data");
      data6: DataClass = this.data;
      str4: String = "MiningType";
       local15: String =  str4;
      num21 = data6.FindLibVar( local15, "SE_Data");
      data7: DataClass = this.data;
      str5: String = "MiningEase";
       local16: String =  str5;
      let mut libVar4: i32 = data7.FindLibVar( local16, "SE_Data");
      data8: DataClass = this.data;
      str6: String = "MiningReserve";
       local17: String =  str6;
      let mut libVar5: i32 = data8.FindLibVar( local17, "SE_Data");
      data9: DataClass = this.data;
      str6 = "Scavenge";
       local18: String =  str6;
      let mut libVar6: i32 = data9.FindLibVar( local18, "SE_Data");
      let mut num27: i32 = mapWidth4;
      for (let mut index28: i32 = 0; index28 <= num27; index28 += 1)
      {
        let mut num28: i32 = mapHeight1;
        for (let mut index29: i32 = 0; index29 <= num28; index29 += 1)
        {
          if (this.data.MapObj[0].HexObj[index28, index29].Regime == this.data.Turn && this.zoneList.FindNr(this.data.MapObj[0].HexObj[index28, index29].GetHexLibVarValue(libVar3)) > -1)
          {
            let mut hexLibVarValue3: i32 = this.data.MapObj[0].HexObj[index28, index29].GetHexLibVarValue(num21);
            num12 = this.data.MapObj[0].HexObj[index28, index29].GetHexLibVarValue(libVar4);
            let mut hexLibVarValue4: i32 = this.data.MapObj[0].HexObj[index28, index29].GetHexLibVarValue(libVar5);
            let mut hexLibVarValue5: i32 = this.data.MapObj[0].HexObj[index28, index29].GetHexLibVarValue(libVar6);
            if (hexLibVarValue3 > 0 & hexLibVarValue4 > 0)
            {
              let mut num29: i32 = 0;
              if (hexLibVarValue3 == 1)
                num29 = 1;
              if (hexLibVarValue3 == 2)
                num29 = 2;
              if (hexLibVarValue3 == 3)
                num29 = 3;
              if (hexLibVarValue3 == 4)
                num29 = 4;
              if (hexLibVarValue3 == 5)
                num29 = 5;
              if (num29 > 0)
              {
                int[] itemMiningReserve = this.itemMiningReserve;
                int[] numArray2 = itemMiningReserve;
                let mut index30: i32 = num29;
                let mut index31: i32 = index30;
                let mut num30: i32 = itemMiningReserve[index30] + hexLibVarValue4;
                numArray2[index31] = num30;
              }
            }
            if (hexLibVarValue5 > 0)
            {
              int[] itemMiningReserve = this.itemMiningReserve;
              int[] numArray3 = itemMiningReserve;
              let mut index32: i32 = 2;
              let mut index33: i32 = index32;
              let mut num31: i32 = itemMiningReserve[index32] +  Math.Round((double) hexLibVarValue5 / 20.0);
              numArray3[index33] = num31;
            }
            let mut num32: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, this.data.MapObj[0].HexObj[index28, index29].LandscapeType, 1, 5, 2)));
            if (num32 > 0)
            {
              int[] itemMiningReserve = this.itemMiningReserve;
              int[] numArray4 = itemMiningReserve;
              let mut index34: i32 = 5;
              let mut index35: i32 = index34;
              let mut num33: i32 = itemMiningReserve[index34] +  Math.Round((double) (30000 * num32) / 10.0);
              numArray4[index35] = num33;
            }
          }
        }
      }
      let mut counter: i32 = this.zoneList.Counter;
      for (i = 0; i <= counter; i += 1)
      {
        HelperEconomyData hed = new HelperEconomyData( DrawMod.TGame, "SE_Data");
        hed.zoneId = this.zoneList.Id[i];
        hed.Input();
        let mut freeWaterProduction: i32 = DrawMod.TGame.EventRelatedObj.Helper_GetZoneFreeWaterProduction( hed, "SE_Data", hed.zoneId);
        int[] itemMiningReserve = this.itemMiningReserve;
        int[] numArray5 = itemMiningReserve;
        let mut index36: i32 = 5;
        let mut index37: i32 = index36;
        let mut num34: i32 = itemMiningReserve[index36] + freeWaterProduction * 30;
        numArray5[index37] = num34;
        int[] itemProduction = this.itemProduction;
        int[] numArray6 = itemProduction;
        let mut index38: i32 = 5;
        let mut index39: i32 = index38;
        let mut num35: i32 = itemProduction[index38] + freeWaterProduction;
        numArray6[index39] = num35;
      }
      DrawMod.TGame.EventRelatedObj.cacheAssetPresUsage = false;
      DrawMod.TGame.EventRelatedObj.cacheAssetPresList = SimpleStringList::new();
      this.ai.WriteLog(name1);
      this.ai.ClearLog();
      name2: String = "9002_" + this.shqName + "_ItemNeed_ItemProd_MiningRes";
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      this.ai.AddLog("");
      this.ai.AddLog("NEED:");
      let mut itemcounter3: i32 = this.itemcounter;
      for (i = 0; i <= itemcounter3; i += 1)
      {
        if (this.itemNeed[i] > 0)
          this.ai.AddLog(this.itemName[i] + " Need: " + this.itemNeed[i].ToString());
      }
      this.ai.AddLog("");
      this.ai.AddLog("PROD:");
      let mut itemcounter4: i32 = this.itemcounter;
      for (i = 0; i <= itemcounter4; i += 1)
      {
        if (this.itemProduction[i] > 0)
          this.ai.AddLog(this.itemName[i] + " Prod: " + this.itemProduction[i].ToString());
      }
      this.ai.AddLog("");
      this.ai.AddLog("RESV:");
      let mut itemcounter5: i32 = this.itemcounter;
      for (i = 0; i <= itemcounter5; i += 1)
      {
        if (this.itemMiningReserve[i] > 0)
          this.ai.AddLog(this.itemName[i] + " MiningReserve: " + this.itemMiningReserve[i].ToString());
      }
      this.ai.WriteLog(name2);
    }

    pub void SplitZones(int i)
    {
      if ( Math.Round(Conversion.Val(this.data.Designer)) < 98 & !DrawMod.TGame.SuperAdminRights)
        return;
      this.shqHisId = this.ShqList.Id[i];
      this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
      this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
      this.shqStage = this.ShqList.Data1[i];
      this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
      this.shqZoneId = this.zones.Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y];
      name: String = "9002a_" + this.shqName + "_SplitZones";
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      this.ai.AddLog("");
      AIMatrix aiMatrix1 = new AIMatrix( DrawMod.TGame.DC2AIObj);
      let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
      int locationById;
      for (let mut index: i32 = 0; index <= length1; index += 1)
      {
        let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 6]));
        let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8]));
        if (id > 0)
        {
          locationById = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1)
          {
            let mut x: i32 = this.data.LocObj[locationById].X;
            let mut y: i32 = this.data.LocObj[locationById].Y;
            aiMatrix1.Value[x, y] = 1;
          }
        }
      }
      aiMatrix1.ExpandAndAddValueForAnyRegime(5, true);
      this.zoneList = SimpleList::new();
      data1: DataClass = this.data;
      str: String = "Zones";
       local: String =  str;
      let mut libVar: i32 = data1.FindLibVar( local, "SE_Data");
      let mut length2: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut tdata3: i32 = 0; tdata3 <= length2; tdata3 += 1)
      {
        let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 0]));
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 6]));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[tdata3, 8])) == this.RegimeId && id > 0)
        {
          locationById = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1 && this.data.LocObj[locationById].HQ == this.shqUnitNr)
          {
            let mut x: i32 = this.data.LocObj[locationById].X;
            let mut y: i32 = this.data.LocObj[locationById].Y;
            let mut tdata1: i32 = x;
            let mut tdata2: i32 = y;
            let mut num4: i32 = 0;
            let mut num5: i32 = 0;
            let mut num6: i32 = 0;
            let mut num7: i32 = 0;
            if (locationById > -1)
            {
              let mut length3: i32 = this.data.StringListObj[this.slotAssets].Length;
              for (i = 0; i <= length3; i += 1)
              {
                bool flag = false;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 0])) == num3)
                {
                  if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 14])) == num3 |  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 14])) < 1)
                    flag = true;
                }
                else if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 14])) == num3)
                  flag = true;
                if (flag)
                {
                  let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 1]));
                  let mut val1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                  let mut num8: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
                  let mut num9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 11]));
                  let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 8]));
                  let mut x1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 3]));
                  let mut y1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 4]));
                  let mut num11: i32 = DrawMod.TGame.HandyFunctionsObj.Distance(x1, y1, 0, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, 0, 99);
                  if (num10 < 1)
                  {
                    if (num11 > 6)
                    {
                      num4 +=  Math.Round((double) Math.Max(num11 - 6, 0) / 6.0 * 100.0 * (double) Math.Max(val1, 1) * (double) num9 / 100.0);
                      num5 += Math.Max(val1, 1);
                    }
                    else
                    {
                      num6 +=  Math.Round((double) (100 * Math.Max(val1, 1) * num9) / 100.0);
                      num7 += Math.Max(val1, 1);
                    }
                  }
                }
              }
            }
            int num12;
            if (num7 > 0)
            {
              num12 =  Math.Round((double) (num4 * 200) / (double) num6);
              if (num12 > 100)
                num12 = 100;
            }
            else
              num12 = num5 <= 0 ? 0 : 100;
            let mut tdata4: i32 = 0;
            let mut mapWidth: i32 = this.data.MapObj[0].MapWidth;
            for (let mut index1: i32 = 0; index1 <= mapWidth; index1 += 1)
            {
              let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
              for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
              {
                if (this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar) == num3)
                  tdata4 += 1;
              }
            }
            let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num3, 1, "worker", 2))) +  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num3, 1, "pop", 2)));
            let mut num14: i32 = 0;
            if (num13 > 500)
              num13 = 500 +  Math.Round(Math.Pow((double) (num13 - 500), 0.85));
            if (tdata4 > 1000)
            {
              num13 =  Math.Round((double) num13 * 2.5);
              num12 += 3;
            }
            else if (tdata4 > 800)
            {
              num13 =  Math.Round((double) num13 * 1.7);
              num12 += 2;
            }
            else if (tdata4 > 600)
            {
              num13 =  Math.Round((double) num13 * 1.3);
              num12 += 1;
            }
            else if (tdata4 > 400)
              num13 =  Math.Round((double) num13 * 1.1);
            else if (tdata4 <= 200)
              ;
            data2: String = this.data.StringListObj[this.slotZones].GetData(0, num3, 7);
            let mut tweight: i32 =  Math.Round((double) (num13 * num12) / 100.0);
            this.ai.AddLog(data2 + " has admin strain " + num12.ToString() + " ... workers+pop=" + (num13 + num14).ToString() + " .... index = " + tweight.ToString());
            this.zoneList.Add(num3, tweight, tdata1, tdata2, tdata3, tdata4);
          }
        }
      }
      this.ai.AddLog("------------------------------------------------ ");
      this.zoneList.ReverseSortHighSpeed();
      bool flag1 = false;
      let mut counter1: i32 = this.zoneList.Counter;
      for (let mut index3: i32 = 0; index3 <= counter1; index3 += 1)
      {
        if (!flag1 && this.zoneList.Counter > -1 && this.zoneList.Weight[index3] > 10)
        {
          let mut idValue: i32 = this.zoneList.Id[index3];
          this.ai.AddLog("Attempting splitting " + this.data.StringListObj[this.slotZones].GetData(0, idValue, 7));
          let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 6)));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 8))) == this.RegimeId && id > 0)
            locationById = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          AIMatrix aiMatrix2 = new AIMatrix( DrawMod.TGame.DC2AIObj);
          let mut mapWidth1: i32 = this.data.MapObj[0].MapWidth;
          for (let mut index4: i32 = 0; index4 <= mapWidth1; index4 += 1)
          {
            let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
            for (let mut index5: i32 = 0; index5 <= mapHeight; index5 += 1)
            {
              aiMatrix2.Value[index4, index5] = 0;
              if (this.data.MapObj[0].HexObj[index4, index5].Regime > 0 && this.data.MapObj[0].HexObj[index4, index5].Regime != this.data.Turn)
                aiMatrix2.Value[index4, index5] = 1;
            }
          }
          aiMatrix2.ExpandAndAddValueForAnyRegime(6, true);
          SimpleList simpleList = SimpleList::new();
          let mut length4: i32 = this.data.StringListObj[this.slotAssets].Length;
          for (i = 0; i <= length4; i += 1)
          {
            bool flag2 = false;
            if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 0])) == idValue)
            {
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 14])) == idValue |  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 14])) < 1)
                flag2 = true;
            }
            else if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 14])) == idValue)
              flag2 = true;
            if (flag2)
            {
              let mut num: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 8]));
              let mut index6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 3]));
              let mut index7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[i, 4]));
              let mut tweight: i32 = DrawMod.TGame.HandyFunctionsObj.Distance(index6, index7, 0, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, 0, 99);
              if (aiMatrix2.Value[index6, index7] == 2)
                tweight =  Math.Round((double) tweight * 0.3);
              else if (aiMatrix2.Value[index6, index7] == 3)
                tweight =  Math.Round((double) tweight * 0.5);
              else if (aiMatrix2.Value[index6, index7] == 4)
                tweight =  Math.Round((double) tweight * 0.7);
              else if (aiMatrix2.Value[index6, index7] == 5)
                tweight =  Math.Round((double) tweight * 0.8);
              else if (aiMatrix2.Value[index6, index7] == 6)
                tweight =  Math.Round((double) tweight * 0.92);
              if (this.zoneList.Data4[index3] > 800)
                tweight *= 2;
              else if (this.zoneList.Data4[index3] > 600)
                tweight =  Math.Round((double) tweight * 1.7);
              else if (this.zoneList.Data4[index3] > 400)
                tweight =  Math.Round((double) tweight * 1.4);
              else if (this.zoneList.Data4[index3] > 200)
                tweight =  Math.Round((double) tweight * 1.25);
              if (aiMatrix1.Value[index6, index7] > 0)
                tweight = 0;
              if (num < 1 & tweight > 0)
                simpleList.Add(i, tweight, index6, index7);
            }
          }
          if (simpleList.Counter > -1)
          {
            simpleList.ReverseSortHighSpeed();
            if (simpleList.Weight[0] > 6)
            {
              let mut index8: i32 = simpleList.Data1[0];
              let mut index9: i32 = simpleList.Data2[0];
              let mut num15: i32 = DrawMod.TGame.HandyFunctionsObj.Distance(index8, index9, 0, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, 0, 99);
              if (this.data.MapObj[0].HexObj[index8, index9].Location > -1 & num15 >= 5)
              {
                this.ai.AddLog("Going to use asset at " + index8.ToString() + "," + index9.ToString() + " to found a new Zone.");
                DrawMod.TGame.EventRelatedObj.Helper_NewZone(index8, index9);
                this.data.LocObj[DrawMod.TGame.Data.MapObj[0].HexObj[index8, index9].Location].HQ = this.shqUnitNr;
                flag1 = true;
                let mut hexLibVarValue: i32 = this.data.MapObj[0].HexObj[index8, index9].GetHexLibVarValue(libVar);
                let mut num16: i32 = idValue;
                let mut num17: i32 =  Math.Round(Math.Floor((double) (num15 + 4) / 2.0));
                bool[,] flagArray = new bool[this.data.MapObj[0].MapWidth + 1, this.data.MapObj[0].MapHeight + 1];
                bool flag3 = true;
                while (flag3)
                {
                  flag3 = false;
                  let mut mapWidth2: i32 = this.data.MapObj[0].MapWidth;
                  for (let mut index10: i32 = 0; index10 <= mapWidth2; index10 += 1)
                  {
                    let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
                    for (let mut index11: i32 = 0; index11 <= mapHeight; index11 += 1)
                    {
                      if (!flagArray[index10, index11] && this.data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar) == hexLibVarValue)
                      {
                        let mut tfacing: i32 = 1;
                        do
                        {
                          Coordinate coordinate = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(index10, index11, 0, tfacing);
                          if (coordinate.onmap && this.data.MapObj[0].HexObj[coordinate.x, coordinate.y].GetHexLibVarValue(libVar) == num16)
                          {
                            let mut num18: i32 = DrawMod.TGame.HandyFunctionsObj.Distance(coordinate.x, coordinate.y, 0, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, 0, 99);
                            let mut num19: i32 = DrawMod.TGame.HandyFunctionsObj.Distance(coordinate.x, coordinate.y, 0, index8, index9, 0, 99);
                            if (num18 > num19 && num18 >= num17)
                            {
                              DrawMod.TGame.HandyFunctionsObj.UnitCausesHexOwnershipChange(this.data.Turn, coordinate.x, coordinate.y, index10, index11, true);
                              flag3 = true;
                            }
                          }
                          tfacing += 1;
                        }
                        while (tfacing <= 6);
                        flagArray[index10, index11] = true;
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      this.ai.AddLog(" ");
      this.ai.AddLog(" ---- increase zones ? ----");
      this.ai.AddLog(" ");
      if (!flag1 & this.zoneList.Counter > 0)
      {
        let mut counter2: i32 = this.zoneList.Counter;
        for (let mut index12: i32 = 0; index12 <= counter2; index12 += 1)
        {
          bool[,] flagArray = new bool[this.data.MapObj[0].MapWidth + 1, this.data.MapObj[0].MapHeight + 1];
          let mut idValue: i32 = this.zoneList.Id[index12];
          this.ai.AddLog("Attempting increasing territory for " + this.data.StringListObj[this.slotZones].GetData(0, idValue, 7));
          let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 6)));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 8))) == this.RegimeId && id > 0)
            locationById = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          let mut mapWidth: i32 = this.data.MapObj[0].MapWidth;
          for (let mut index13: i32 = 0; index13 <= mapWidth; index13 += 1)
          {
            let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
            for (let mut index14: i32 = 0; index14 <= mapHeight; index14 += 1)
            {
              if (!flagArray[index13, index14])
              {
                let mut hexLibVarValue1: i32 = this.data.MapObj[0].HexObj[index13, index14].GetHexLibVarValue(libVar);
                if (hexLibVarValue1 == this.zoneList.Id[index12] & hexLibVarValue1 > 0 & this.data.MapObj[0].HexObj[index13, index14].Regime == this.data.Turn)
                {
                  if (index13 == 22 & index14 == 9)
                    index13 = index13;
                  let mut tfacing: i32 = 1;
                  do
                  {
                    Coordinate coordinate = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(index13, index14, 0, tfacing);
                    if (coordinate.onmap)
                    {
                      let mut hexLibVarValue2: i32 = this.data.MapObj[0].HexObj[coordinate.x, coordinate.y].GetHexLibVarValue(libVar);
                      if (hexLibVarValue2 != this.zoneList.Id[index12] && this.data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == this.data.Turn & hexLibVarValue2 > 0)
                      {
                        let mut nr: i32 = this.zoneList.FindNr(hexLibVarValue2);
                        if (nr > -1)
                        {
                          let mut x2: i32 = this.zoneList.Data1[nr];
                          let mut y2: i32 = this.zoneList.Data2[nr];
                          let mut num: i32 = DrawMod.TGame.HandyFunctionsObj.Distance(coordinate.x, coordinate.y, 0, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, 0, 99);
                          if ((double) DrawMod.TGame.HandyFunctionsObj.Distance(coordinate.x, coordinate.y, 0, x2, y2, 0, 99) > Math.Ceiling((double) num * 1.33) + 1.0)
                          {
                            DrawMod.TGame.HandyFunctionsObj.UnitCausesHexOwnershipChange(this.data.Turn, coordinate.x, coordinate.y, index13, index14, true);
                            flagArray[coordinate.x, coordinate.y] = true;
                            this.ai.AddLog(" - Added " + coordinate.x.ToString() + "," + coordinate.y.ToString() + " to Zone.");
                          }
                        }
                      }
                    }
                    tfacing += 1;
                  }
                  while (tfacing <= 6);
                  flagArray[index13, index14] = true;
                }
              }
            }
          }
        }
      }
      this.ai.WriteLog(name);
      this.ai.ClearLog();
    }

    pub void ExecuteTrade(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      str: String = "9045_" + logAddition + "_ExecuteTrade";
      bool[] flagArray = new bool[100];
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      let mut setValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "credits", 2)));
      this.ai.AddLog("Credit available = " + setValue1.ToString());
      let mut num1: i32 = 0;
      let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut index: i32 = 0; index <= length1; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8])) == this.RegimeId)
        {
          let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
          let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "worker", 2)));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "popHunger", 2))) > 0)
            num2 += Math.Max(0,  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "pop", 2))) -  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "privateFood", 2))));
          num1 += num2;
        }
      }
      let mut unitCounter: i32 = this.data.UnitCounter;
      for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1)
        {
          let mut num3: i32 = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
          if (this.data.UnitObj[unr].Historical > -1 && this.data.HistoricalUnitObj[this.data.UnitObj[unr].Historical].Type == 8)
            num3 = num3 + this.data.UnitObj[unr].items.list.FindWeight(9) + this.data.UnitObj[unr].items.list.FindWeight(12);
          num1 += num3;
        }
      }
      if (num1 < this.itemNeed[7])
        num1 = this.itemNeed[7];
      float num4 = 1f;
      let mut idValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, this.zoneList.Id[0], 1)));
      if (idValue1 > 0)
      {
        let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue1, 1, 7, 4)));
        if (num5 < 25)
          num4 = 2f;
        else if (num5 < 50)
          num4 = 1.5f;
        else if (num5 > 500)
          num4 = 0.2f;
        else if (num5 > 250)
          num4 = 0.5f;
        else if (num5 > 100)
          num4 = 0.75f;
      }
      let mut num6: i32 =  Math.Round((double) ((float) num1 * num4)) - this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7);
      let mut idValue2: i32 = this.zoneList.Id[0];
      Item index1 = Item.Food;
      let mut num7: i32 = 0;
      string data;
      if (num6 > 0)
      {
        let mut tweight: i32 = num6;
        let mut idValue3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, idValue2, 1)));
        let mut num8: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue3, 1,  index1, 3)));
        if (num8 < tweight)
          tweight = num8;
        if (tweight > 0)
        {
          let mut num9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue3, 1,  index1, 4)));
          data = this.data.StringListObj[this.slotItemType].GetData(0,  index1, 1);
          let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraders].GetData(0, idValue3, 1)));
          let mut num11: i32 =  Math.Round(Math.Ceiling((double) (num9 * tweight) / 100.0));
          this.ai.AddLog("Is missing" + tweight.ToString() + "x " + this.itemName[ index1] + ". Price is at " + num9.ToString() + " => total cost: " + num11.ToString() + " credits.");
          flagArray[ index1] = true;
          if (num11 > setValue1)
          {
            tweight =  Math.Round(Math.Floor((double) tweight * ((double) setValue1 / (double) num11))) - 1;
            num11 =  Math.Round(Math.Ceiling((double) (num9 * tweight) / 100.0));
          }
          if (num11 <= setValue1 & tweight > 0)
          {
            let mut setValue2: i32 = num8 - tweight;
            this.data.StringListObj[this.slotTraderItems].SetData2(0, idValue3, 1,  index1, 3, setValue2);
            this.data.UnitObj[this.shqUnitNr].items.list.AddWeight( index1, tweight);
            setValue1 -= num11;
            let mut setValue3: i32 = num10 + num11;
            this.data.StringListObj[this.slotTraders].SetData(0, idValue3, 1, setValue3);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "credits", 2, setValue1);
            this.ai.AddLog("Just bought " + tweight.ToString() + "x " + this.itemName[ index1] + " for " + num11.ToString() + " credits.");
            flagArray[ index1] = true;
            if (this.slotTradeLog > 0)
              this.ai.game.Data.StringListObj[this.slotTradeLog].AddRowWithData(idValue3.ToString(), this.ai.game.Data.Round.ToString(), this.ai.game.Data.Turn.ToString(), "24", s5: "7", s6: tweight.ToString(), s7: num11.ToString(), s8: idValue2.ToString(), s9: this.RegimeId.ToString(), s10: "-1");
          }
        }
      }
      let mut num12: i32 = this.itemNeed[5] - this.itemProduction[5];
      Item index2 = Item.Water;
      num7 = 0;
      float num13 = 1f;
      if (idValue1 > 0)
      {
        let mut num14: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue1, 1, 5, 4)));
        num13 = num14 >= 15 ? (num14 >= 30 ? (num14 >= 60 ? (num14 <= 90 ? (num14 <= 150 ? (num14 <= 300 ? (num14 <= 500 ? 0.1f : 0.25f) : 0.4f) : 0.6f) : 0.8f) : 1f) : 1.5f) : 2f;
      }
      let mut num15: i32 =  Math.Round((double) ((float) num12 * num13)) -  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(5) / 2.0);
      if (num15 > 0)
      {
        let mut tweight: i32 = num15;
        let mut idValue4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, idValue2, 1)));
        let mut num16: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue4, 1,  index2, 3)));
        if (num16 < tweight)
          tweight = num16;
        if (tweight > 0)
        {
          let mut num17: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue4, 1,  index2, 4)));
          data = this.data.StringListObj[this.slotItemType].GetData(0,  index2, 1);
          let mut num18: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraders].GetData(0, idValue4, 1)));
          let mut num19: i32 =  Math.Round(Math.Ceiling((double) (num17 * tweight) / 100.0));
          this.ai.AddLog("Is missing" + tweight.ToString() + "x " + this.itemName[ index2] + ". Price is at " + num17.ToString() + " => total cost: " + num19.ToString() + " credits.");
          flagArray[ index2] = true;
          if (num19 > setValue1)
          {
            tweight =  Math.Round(Math.Floor((double) tweight * ((double) setValue1 / (double) num19))) - 1;
            num19 =  Math.Round(Math.Ceiling((double) (num17 * tweight) / 100.0));
          }
          if (num19 <= setValue1 & tweight > 0)
          {
            let mut setValue4: i32 = num16 - tweight;
            this.data.StringListObj[this.slotTraderItems].SetData2(0, idValue4, 1,  index2, 3, setValue4);
            this.data.UnitObj[this.shqUnitNr].items.list.AddWeight( index2, tweight);
            setValue1 -= num19;
            let mut setValue5: i32 = num18 + num19;
            this.data.StringListObj[this.slotTraders].SetData(0, idValue4, 1, setValue5);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "credits", 2, setValue1);
            this.ai.AddLog("Just bought " + tweight.ToString() + "x " + this.itemName[ index2] + " for " + num19.ToString() + " credits.");
            flagArray[ index2] = true;
            if (this.slotTradeLog > 0)
              this.ai.game.Data.StringListObj[this.slotTradeLog].AddRowWithData(idValue4.ToString(), this.ai.game.Data.Round.ToString(), this.ai.game.Data.Turn.ToString(), "24", s5: "7", s6: tweight.ToString(), s7: num19.ToString(), s8: idValue2.ToString(), s9: this.RegimeId.ToString(), s10: "-1");
          }
        }
      }
      let mut num20: i32 = this.itemNeed[1] - this.itemProduction[1] + (this.VAR_UnitsIdealFuel - this.VAR_UnitsCurrentFuel);
      Item index3 = Item.Oil;
      num7 = 0;
      float num21 = 1f;
      if (idValue1 > 0)
      {
        let mut num22: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue1, 1, 1, 4)));
        num21 = num22 >= 15 ? (num22 >= 30 ? (num22 >= 60 ? (num22 <= 90 ? (num22 <= 150 ? (num22 <= 300 ? (num22 <= 500 ? 0.02f : 0.1f) : 0.2f) : 0.4f) : 0.6f) : 1f) : 1.5f) : 2f;
      }
      let mut num23: i32 =  Math.Round((double) ((float) num20 * num21)) -  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(1) / 2.0);
      if (num23 > 0)
      {
        let mut tweight: i32 = num23;
        let mut idValue5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, idValue2, 1)));
        let mut num24: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue5, 1,  index3, 3)));
        if (num24 < tweight)
          tweight = num24;
        if (tweight > 0)
        {
          let mut num25: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue5, 1,  index3, 4)));
          data = this.data.StringListObj[this.slotItemType].GetData(0,  index3, 1);
          let mut num26: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraders].GetData(0, idValue5, 1)));
          let mut num27: i32 =  Math.Round(Math.Ceiling((double) (num25 * tweight) / 100.0));
          this.ai.AddLog("Is missing" + tweight.ToString() + "x " + this.itemName[ index3] + ". Price is at " + num25.ToString() + " => total cost: " + num27.ToString() + " credits.");
          flagArray[ index3] = true;
          if (num27 > setValue1)
          {
            tweight =  Math.Round(Math.Floor((double) tweight * ((double) setValue1 / (double) num27))) - 1;
            num27 =  Math.Round(Math.Ceiling((double) (num25 * tweight) / 100.0));
          }
          if (num27 <= setValue1 & tweight > 0)
          {
            let mut setValue6: i32 = num24 - tweight;
            this.data.StringListObj[this.slotTraderItems].SetData2(0, idValue5, 1,  index3, 3, setValue6);
            this.data.UnitObj[this.shqUnitNr].items.list.AddWeight( index3, tweight);
            setValue1 -= num27;
            let mut setValue7: i32 = num26 + num27;
            this.data.StringListObj[this.slotTraders].SetData(0, idValue5, 1, setValue7);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "credits", 2, setValue1);
            this.ai.AddLog("Just bought " + tweight.ToString() + "x " + this.itemName[ index3] + " for " + num27.ToString() + " credits.");
            flagArray[ index3] = true;
            if (this.slotTradeLog > 0)
              this.ai.game.Data.StringListObj[this.slotTradeLog].AddRowWithData(idValue5.ToString(), this.ai.game.Data.Round.ToString(), this.ai.game.Data.Turn.ToString(), "24", s5: "7", s6: tweight.ToString(), s7: num27.ToString(), s8: idValue2.ToString(), s9: this.RegimeId.ToString(), s10: "-1");
          }
        }
      }
      let mut num28: i32 = -1;
      let mut num29: i32 = 0;
      let mut num30: i32 = 0;
      let mut poolCounter1: i32 = this.poolCounter;
      for (let mut index4: i32 = 1; index4 <= poolCounter1; index4 += 1)
      {
        if ((this.poolPreferedAssetType[index4] > 0 | this.poolPreferedOob[index4] > 0) & this.poolImportance[index4] > 0)
        {
          num30 += this.poolImportance[index4];
          if (this.poolImportance[index4] > num29)
          {
            num29 = this.poolImportance[index4];
            num28 = index4;
          }
        }
      }
      let mut num31: i32 = 1;
      int num32;
      int num33;
      int num34;
      int num35;
      do
      {
        let mut poolCounter2: i32 = this.poolCounter;
        for (let mut index5: i32 = 1; index5 <= poolCounter2; index5 += 1)
        {
          if (num31 == 1 & index5 == num28 | num31 == 2 & index5 != num28 && num28 > 0)
          {
            let mut index6: i32 = index5;
            let mut counter: i32 = this.poolRequest[index6].Counter;
            for (let mut index7: i32 = 0; index7 <= counter; index7 += 1)
            {
              bool flag = false;
              if (this.poolPreferedAssetType[index6] > 0)
              {
                let mut num36: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, this.poolPreferedAssetType[index6], 13)));
                if (num36 > 0)
                {
                  num29 =  Math.Round((double)  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(this.poolRequest[index6].Id[index7]) * ((double) this.poolImportance[index6] / (double) num30)) / (double) num36);
                  if (this.poolRequest[index6].Weight[index7] > num29)
                    flag = true;
                }
              }
              else if (this.poolPreferedOob[index6] > 0)
              {
                num29 =  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(this.poolRequest[index6].Id[index7]) * ((double) this.poolImportance[index6] / (double) num30));
                if (this.poolRequest[index6].Weight[index7] > num29)
                  flag = true;
              }
              if (flag)
              {
                let mut num37: i32 = this.poolRequest[index6].Weight[index7] - num29;
                num32 = 0;
                num33 = 0;
                num34 = 0;
                num35 = 0;
                let mut idValue6: i32 = this.zoneList.Id[0];
                Item index8 = (Item) this.poolRequest[index6].Id[index7];
                let mut tweight1: i32 = num37;
                let mut idValue7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, idValue6, 1)));
                let mut num38: i32 =  Math.Round((double)  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue7, 1,  index8, 3))) * 0.25);
                let mut val1: i32 = tweight1;
                if (num38 < tweight1)
                  tweight1 = num38;
                if (tweight1 > 0)
                {
                  let mut num39: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue7, 1,  index8, 4)));
                  data = this.data.StringListObj[this.slotItemType].GetData(0,  index8, 1);
                  let mut num40: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraders].GetData(0, idValue7, 1)));
                  let mut num41: i32 =  Math.Round(Math.Ceiling((double) (num39 * tweight1) / 100.0));
                  this.ai.AddLog("Is missing" + tweight1.ToString() + "x " + this.itemName[ index8] + ". Price is at " + num39.ToString() + " => total cost: " + num41.ToString() + " credits.");
                  if (num41 <= setValue1)
                  {
                    let mut setValue8: i32 = num38 - tweight1;
                    this.data.StringListObj[this.slotTraderItems].SetData2(0, idValue7, 1,  index8, 3, setValue8);
                    this.data.UnitObj[this.shqUnitNr].items.list.AddWeight( index8, tweight1);
                    setValue1 -= num41;
                    let mut setValue9: i32 = num40 + num41;
                    this.data.StringListObj[this.slotTraders].SetData(0, idValue7, 1, setValue9);
                    this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "credits", 2, setValue1);
                    flagArray[ index8] = true;
                    this.ai.AddLog("Just bought " + tweight1.ToString() + "x " + this.itemName[ index8] + " for " + num41.ToString() + " credits.");
                    if (this.slotTradeLog > 0)
                      this.ai.game.Data.StringListObj[this.slotTradeLog].AddRowWithData(idValue7.ToString(), this.ai.game.Data.Round.ToString(), this.ai.game.Data.Turn.ToString(), "24", s5: ( index8).ToString(), s6: tweight1.ToString(), s7: num41.ToString(), s8: idValue6.ToString(), s9: this.RegimeId.ToString(), s10: "-1");
                    val1 -= setValue8;
                  }
                  else
                  {
                    flagArray[ index8] = true;
                    this.ai.AddLog("Did not have enough credits (" + setValue1.ToString() + " to buy..");
                  }
                }
                if (val1 > 0 && this.poolRequest[index6].Id[index7] == 13 && this.shqStage < 5)
                {
                  let mut num42: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(3);
                  let mut num43: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8);
                  if (num42 < 0)
                    num42 = 0;
                  if (num43 < 0)
                    num43 = 0;
                  let mut num44: i32 =  Math.Round((double) num42 / 2.0);
                  let mut num45: i32 =  Math.Round((double) num43 / 2.0);
                  let mut val2: i32 =  Math.Round(Math.Floor((double) Math.Min( Math.Round((double) num44 * ((double) this.poolImportance[index6] / (double) num30)),  Math.Round((double) num45 * ((double) this.poolImportance[index6] / (double) num30))) / 20.0));
                  let mut tweight2: i32 = Math.Min(val1, val2);
                  if (tweight2 > 0)
                  {
                    flagArray[13] = true;
                    this.ai.AddLog("Workshopped " + tweight2.ToString() + " of " + val1.ToString() + " Machinery.");
                    this.data.UnitObj[this.shqUnitNr].items.list.AddWeight(13, tweight2);
                    this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight(3, tweight2 * 20);
                    this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight(8, tweight2 * 20);
                  }
                  else
                  {
                    this.ai.AddLog("Not enough items to workshop Machinery.");
                    flagArray[13] = true;
                  }
                }
              }
            }
          }
        }
        num31 += 1;
      }
      while (num31 <= 2);
      SimpleList simpleList = SimpleList::new();
      let mut length2: i32 = this.data.StringListObj[this.slotAssets].Length;
      for (let mut index9: i32 = 0; index9 <= length2; index9 += 1)
      {
        let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index9, 0]));
        let mut num46: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index9, 1]));
        if (this.zoneList.FindNr(tid) > -1)
        {
          let mut num47: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index9, 7]));
          let mut num48: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index9, 12]));
          if (num47 > 0)
          {
            let mut num49: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, num46, 13)));
            let mut num50: i32 = num47 * 100 - num48;
            SimpleList assetConstruction = this.GetItemsForAssetConstruction(num46);
            let mut counter: i32 = assetConstruction.Counter;
            for (let mut index10: i32 = 0; index10 <= counter; index10 += 1)
              assetConstruction.Weight[index10] =  Math.Round(Math.Ceiling((double) (assetConstruction.Weight[index10] * num50) / 100.0));
            simpleList.AddWeight( assetConstruction);
          }
        }
      }
      let mut num51: i32 = this.itemNeed[5];
      let mut num52: i32 = this.itemNeed[1];
      let mut num53: i32 =  Math.Round((double) this.itemNeed[7] * 1.5);
      let mut itemcounter: i32 = this.itemcounter;
      for (let mut tid: i32 = 1; tid <= itemcounter; tid += 1)
      {
        let mut weight: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(tid);
        let mut num54: i32 = 0;
        let mut poolCounter3: i32 = this.poolCounter;
        for (let mut index11: i32 = 1; index11 <= poolCounter3; index11 += 1)
          num54 = num54 +  Math.Round((double) this.poolItems[index11].FindWeight(tid) * 1.25) +  Math.Round((double) this.poolRequest[index11].FindWeight(tid) * 1.25);
        Item index12 = (Item) tid;
        let mut num55: i32 = weight - num54 - simpleList.FindWeight(tid);
        if (index12 == Item.Food & num53 > 0)
          num55 -= num53;
        if (index12 == Item.Water & num51 > 0)
          num55 -= num51;
        if (index12 == Item.Oil & num52 > 0)
          num55 -= num52;
        if (flagArray[ index12])
          num55 = 0;
        if (num55 > 0)
        {
          let mut tweight: i32 =  Math.Round((double) num55 / 2.0);
          num32 = 0;
          num33 = 0;
          num34 = 0;
          num35 = 0;
          let mut idValue8: i32 = this.zoneList.Id[0];
          Item index13 = (Item) tid;
          let mut idValue9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, idValue8, 1)));
          let mut num56: i32 =  Math.Round(0.75 * Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue9, 1,  index13, 7)));
          data = this.data.StringListObj[this.slotItemType].GetData(0,  index13, 1);
          let mut num57: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraders].GetData(0, idValue9, 1)));
          let mut num58: i32 = ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue9, 1,  index13, 5))) -  Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, idValue9, 1,  index13, 3)))) * 1;
          let mut num59: i32 =  Math.Round(Math.Floor((double) num57 / 4.0 / ((double) num56 / 100.0)));
          if (num59 < num58)
            num58 = num59;
          if (tweight > num58)
            tweight = num58;
          if (tweight > 0 & num56 >= 10)
          {
            let mut setValue10: i32 = num58 + tweight;
            this.data.StringListObj[this.slotTraderItems].SetData2(0, idValue9, 1,  index13, 3, setValue10);
            this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight( index13, tweight);
            let mut num60: i32 =  Math.Round(Math.Ceiling((double) (num56 * tweight) / 100.0));
            setValue1 += num60;
            let mut setValue11: i32 = num57 - num60;
            this.data.StringListObj[this.slotTraders].SetData(0, idValue9, 1, setValue11);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "credits", 2, setValue1);
            this.ai.AddLog("Just sold " + tweight.ToString() + "x " + this.itemName[ index13] + " and gained " + num60.ToString() + " credits.");
            if (this.slotTradeLog > 0)
              this.ai.game.Data.StringListObj[this.slotTradeLog].AddRowWithData(idValue9.ToString(), this.ai.game.Data.Round.ToString(), this.ai.game.Data.Turn.ToString(), "23", s5: ( index13).ToString(), s6: tweight.ToString(), s7: num60.ToString(), s8: idValue8.ToString(), s9: this.RegimeId.ToString(), s10: "-1");
          }
        }
      }
      this.ai.AddLog("Credit available = " + setValue1.ToString());
      this.ai.WriteLog(str);
    }

    pub void MotballOrCloseAssets(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      str: String = "9055_" + logAddition + "_MotballOrCloseAssets";
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      this.ai.AddLog("");
      bool flag1 = false;
      let mut poolCounter: i32 = this.poolCounter;
      int num1;
      int num2;
      int num3;
      for (let mut index: i32 = 1; index <= poolCounter; index += 1)
      {
        if (this.poolConstrBlocked[index])
          flag1 = true;
        if (this.poolImportance[index] > 0)
          num1 += 1;
        int num4;
        if (this.poolImportance[index] > num4)
        {
          num2 = num4;
          num4 = this.poolImportance[index];
        }
        else if (this.poolImportance[index] > num2)
          num2 = this.poolImportance[index];
        num3 += this.poolImportance[index];
      }
      let mut num5: i32 =  Math.Round((double) num3 / (double) num1);
      bool[] flagArray1 = new bool[100];
      bool[] flagArray2 = new bool[100];
      if (this.poolConstrBlocked[1])
      {
        flagArray1[7] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[6])
      {
        flagArray1[5] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[3])
      {
        flagArray1[8] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[2])
      {
        flagArray1[2] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[4])
      {
        flagArray1[1] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[6])
      {
        flagArray1[5] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[10])
      {
        flagArray1[15] = true;
        flag1 = true;
      }
      if (this.poolConstrBlocked[11])
      {
        flagArray1[3] = true;
        flag1 = true;
      }
      if (this.poolImportance[1] < num5)
        flagArray2[7] = true;
      if (this.poolImportance[6] < num5)
        flagArray2[5] = true;
      if (this.poolImportance[3] < num5)
        flagArray2[8] = true;
      if (this.poolImportance[2] < num5)
        flagArray2[2] = true;
      if (this.poolImportance[4] < num5)
        flagArray2[1] = true;
      if (this.poolImportance[11] < num5)
        flagArray2[3] = true;
      if (this.poolImportance[10] < num5)
        flagArray2[15] = true;
      if (this.poolImportance[1] >= num2)
        flagArray1[7] = true;
      if (this.poolImportance[6] >= num2)
        flagArray1[5] = true;
      if (this.poolImportance[3] >= num2)
        flagArray1[8] = true;
      if (this.poolImportance[2] >= num2)
        flagArray1[2] = true;
      if (this.poolImportance[4] >= num2)
        flagArray1[1] = true;
      if (this.poolImportance[10] >= num2)
        flagArray1[15] = true;
      if (this.poolImportance[11] >= num2)
        flagArray1[3] = true;
      if (this.VAR_WorkerShortage < 10)
        flag1 = false;
      if (this.VAR_IdealWorker > this.VAR_CurrentWorker + 50)
        flag1 = false;
      if (this.VAR_FreeWorkerReservePlus >= 50 | this.VAR_FreeWorkerReserve >= 50)
        flag1 = false;
      if (this.VAR_FreeWorkerReservePlus > 0)
        flag1 = false;
      bool[] flagArray3 = new bool[100];
      bool flag2 = false;
      int[] numArray1 = new int[100];
      let mut itemcounter: i32 = this.itemcounter;
      for (let mut tid: i32 = 0; tid <= itemcounter; tid += 1)
      {
        if (flagArray1[tid] | (double) (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(tid) * 3) < Math.Min((double) (this.itemNeed[tid] + 200), (double) this.itemNeed[tid] * 1.1) | Math.Min((double) (this.itemNeed[tid] + 200), (double) this.itemNeed[tid] * 1.1) > (double) this.itemProduction[tid] && tid == 7)
        {
          flag2 = true;
          flagArray3[tid] = true;
          numArray1[tid] = this.itemNeed[tid] - this.itemProduction[tid];
        }
      }
      int[] numArray2 = new int[100];
      let mut num6: i32 = 0;
      let mut num7: i32 = 0;
      let mut counter1: i32 = this.zoneList.Counter;
      int num8;
      int num9;
      for (let mut index1: i32 = 0; index1 <= counter1; index1 += 1)
      {
        num8 = this.zoneList.Id[index1];
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index1], 8])) == this.RegimeId)
        {
          for (let mut length1: i32 = this.data.StringListObj[this.slotAssets].Length; length1 >= 0; length1 += -1)
          {
            let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 0]));
            let mut num11: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 5]));
            let mut num12: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 8]));
            if (num10 == num8 & num12 < 1)
            {
              let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 1]));
              let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 11]));
              let mut num14: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
              num9 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
              if (num11 > 0 & num9 == 1)
              {
                num6 += num13;
                num7 += 1;
                let mut length2: i32 = this.data.StringListObj[this.slotProdType].Length;
                for (let mut index2: i32 = 0; index2 <= length2; index2 += 1)
                {
                  let mut num15: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 0]));
                  if (num14 == num15)
                  {
                    let mut num16: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 2]));
                    let mut num17: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 3]));
                    if (num16 == 2)
                    {
                      int[] numArray3 = numArray2;
                      int[] numArray4 = numArray3;
                      let mut index3: i32 = num17;
                      let mut index4: i32 = index3;
                      let mut num18: i32 = numArray3[index3] + 1;
                      numArray4[index4] = num18;
                    }
                  }
                }
              }
            }
          }
        }
      }
      if (num7 > 0)
      {
        num6 =  Math.Round((double) num6 / (double) num7);
        if (num6 >= 80)
          ;
      }
      if (flag2)
      {
        this.ai.AddLog("0. Motball 1 Asset that is using Item in Big Shortage.");
        SimpleList simpleList = SimpleList::new();
        let mut counter2: i32 = this.zoneList.Counter;
        for (let mut index5: i32 = 0; index5 <= counter2; index5 += 1)
        {
          num8 = this.zoneList.Id[index5];
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index5], 8])) == this.RegimeId)
          {
            for (let mut length3: i32 = this.data.StringListObj[this.slotAssets].Length; length3 >= 0; length3 += -1)
            {
              let mut num19: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length3, 0]));
              let mut num20: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length3, 5]));
              let mut num21: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length3, 8]));
              if (num20 > 0 & num19 == num8 & num21 == 0)
              {
                let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length3, 1]));
                let mut num22: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
                num9 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
                if (num9 == 1)
                {
                  bool flag3 = false;
                  bool flag4 = false;
                  let mut length4: i32 = this.data.StringListObj[this.slotProdType].Length;
                  for (let mut index6: i32 = 0; index6 <= length4; index6 += 1)
                  {
                    let mut num23: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index6, 0]));
                    if (num22 == num23)
                    {
                      let mut num24: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index6, 2]));
                      let mut index7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index6, 3]));
                      if (num24 == 2)
                      {
                        if (flagArray1[index7] | flagArray3[index7])
                          flag3 = true;
                        if (flagArray2[index7])
                          flag4 = true;
                      }
                    }
                  }
                  if (!flag3)
                  {
                    bool flag5 = false;
                    flag4 = false;
                    let mut num25: i32 = -1;
                    let mut num26: i32 = -1;
                    let mut length5: i32 = this.data.StringListObj[this.slotProdCost].Length;
                    for (let mut index8: i32 = 0; index8 <= length5; index8 += 1)
                    {
                      let mut num27: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index8, 0]));
                      if (num22 == num27)
                      {
                        let mut num28: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index8, 2]));
                        let mut index9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index8, 3]));
                        if (num28 == 2)
                        {
                          if (flagArray1[index9] | flagArray3[index9])
                          {
                            flag5 = true;
                            num25 = index9;
                            num26 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index8, 4]));
                          }
                          if (flagArray2[index9])
                            flag4 = true;
                        }
                      }
                    }
                    if (flag5 & num25 > 0)
                    {
                      let mut num29: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                      int[] numArray5 = numArray1;
                      int[] numArray6 = numArray5;
                      let mut index10: i32 = num25;
                      let mut index11: i32 = index10;
                      let mut num30: i32 = numArray5[index10] - num26;
                      numArray6[index11] = num30;
                      let mut tweight: i32 = num29 * 100;
                      simpleList.Add(length3, tweight);
                    }
                  }
                }
              }
            }
          }
        }
        simpleList.Sort();
        if (simpleList.Counter > -1)
        {
          let mut index: i32 = simpleList.Id[0];
          let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
          this.data.StringListObj[this.slotAssets].Data[index, 5] = -1.ToString();
          data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
          this.ai.AddLog("MOTBALLED a less or non-vital construction in zone  " + num8.ToString() + ". Concerns Asset Type: " + data);
        }
      }
      if (!flag1 & !flag2)
      {
        let mut num31: i32 = this.VAR_CurrentWorker - this.VAR_WorkerJobsCurrent;
        SimpleList simpleList = SimpleList::new();
        let mut counter3: i32 = this.zoneList.Counter;
        int num32;
        for (let mut index12: i32 = 0; index12 <= counter3; index12 += 1)
        {
          num8 = this.zoneList.Id[index12];
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index12], 8])) == this.RegimeId)
          {
            for (let mut length6: i32 = this.data.StringListObj[this.slotAssets].Length; length6 >= 0; length6 += -1)
            {
              let mut num33: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length6, 0]));
              num32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length6, 1]));
              let mut num34: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length6, 5]));
              let mut num35: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length6, 8]));
              if (num33 == num8 && num34 < 0 & num35 == 0 & num33 == num8)
              {
                let mut num36: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length6, 1]));
                let mut num37: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, num36, 11)));
                let mut num38: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, num36, 14)));
                let mut tweight: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, num36, 2)));
                if (num34 == -1)
                  tweight += 100;
                if (this.GetWorkerForAssetProduction(num36) <= num31)
                {
                  bool flag6 = true;
                  let mut length7: i32 = this.data.StringListObj[this.slotProdCost].Length;
                  for (let mut index13: i32 = 0; index13 <= length7; index13 += 1)
                  {
                    let mut num39: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index13, 0]));
                    if (num37 == num39)
                    {
                      let mut num40: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index13, 2]));
                      let mut index14: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index13, 3]));
                      let mut num41: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index13, 4]));
                      if (num40 == 2 && index14 > 0 && this.itemNeed[index14] +  Math.Round(Math.Min((double) (num41 + 200), (double) num41 * 1.1)) > this.itemProduction[index14])
                        flag6 = false;
                    }
                  }
                  if (flag6)
                    simpleList.Add(length6, tweight);
                }
              }
            }
          }
        }
        simpleList.ReverseSort();
        if (simpleList.Counter > -1)
        {
          let mut index: i32 = simpleList.Id[0];
          num32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
          this.data.StringListObj[this.slotAssets].Data[index, 5] = 0.ToString();
          this.ai.AddLog("Reoppened an Asset that was mothballed/closed.");
        }
      }
      if (flag1)
      {
        this.ai.AddLog("Problems constructing a VITAL asset.");
        let mut num42: i32 = 1;
        if (this.VAR_WorkerShortage > 400)
          num42 =  Math.Round((double) (100 - num6) / 10.0) + 1;
        else if (this.VAR_WorkerShortage > 200)
          num42 =  Math.Round((double) (100 - num6) / 20.0) + 1;
        else if (this.VAR_WorkerShortage > 100)
          num42 =  Math.Round((double) (100 - num6) / 30.0) + 1;
        else if (this.VAR_WorkerShortage > 50)
          num42 = 1;
        bool flag7 = false;
        let mut num43: i32 = num42;
        for (let mut index15: i32 = 1; index15 <= num43; index15 += 1)
        {
          bool flag8 = false;
          this.ai.AddLog("1. Shut down double construction.");
          let mut counter4: i32 = this.zoneList.Counter;
          for (let mut index16: i32 = 0; index16 <= counter4; index16 += 1)
          {
            num8 = this.zoneList.Id[index16];
            if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index16], 8])) == this.RegimeId)
            {
              for (let mut length8: i32 = this.data.StringListObj[this.slotAssets].Length; length8 >= 0; length8 += -1)
              {
                let mut num44: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length8, 0]));
                let mut idValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length8, 1]));
                let mut num45: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length8, 3]));
                let mut num46: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length8, 4]));
                let mut num47: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length8, 8]));
                if (num44 == num8 & num47 > 0)
                {
                  let mut length9: i32 = this.data.StringListObj[this.slotAssets].Length;
                  let mut num48: i32 = length8 + 1;
                  for (let mut row: i32 = length9; row >= num48; row += -1)
                  {
                    if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[row, 0])) == num44)
                    {
                      let mut num49: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[row, 8]));
                      num9 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 5)));
                      if (num9 == 1 && num49 > 0)
                      {
                        let mut idValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[row, 1]));
                        let mut num50: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[row, 3]));
                        let mut num51: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[row, 4]));
                        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 14))) ==  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 14))))
                        {
                          this.data.StringListObj[this.slotAssets].RemoveRow(row);
                          data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 1);
                          this.ai.AddLog("Found double construction in zone " + num8.ToString() + ". Removed Asset Type: " + data);
                        }
                      }
                    }
                  }
                }
              }
            }
          }
          this.ai.AddLog("2. Cancel non-vital construction.");
          SimpleList simpleList1 = SimpleList::new();
          let mut counter5: i32 = this.zoneList.Counter;
          for (let mut index17: i32 = 0; index17 <= counter5; index17 += 1)
          {
            num8 = this.zoneList.Id[index17];
            if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index17], 8])) == this.RegimeId)
            {
              for (let mut length10: i32 = this.data.StringListObj[this.slotAssets].Length; length10 >= 0; length10 += -1)
              {
                let mut num52: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length10, 0]));
                let mut num53: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length10, 8]));
                if (num52 == num8 & num53 > 0)
                {
                  let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length10, 1]));
                  let mut num54: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
                  num9 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
                  if (num9 == 1)
                  {
                    bool flag9 = false;
                    bool flag10 = false;
                    let mut num55: i32 = 0;
                    let mut length11: i32 = this.data.StringListObj[this.slotProdType].Length;
                    for (let mut index18: i32 = 0; index18 <= length11; index18 += 1)
                    {
                      let mut num56: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index18, 0]));
                      if (num54 == num56)
                      {
                        let mut num57: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index18, 2]));
                        let mut index19: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index18, 3]));
                        if (num57 == 2)
                        {
                          if (flagArray1[index19])
                            flag9 = true;
                          if (flagArray2[index19])
                            flag10 = true;
                          num55 += numArray2[index19];
                        }
                      }
                    }
                    if (!flag9)
                    {
                      let mut num58: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                      if (!flag10)
                        num58 *= 10;
                      let mut tweight: i32 =  Math.Round((double) (num58 * 100) / (double) num55);
                      simpleList1.Add(length10, tweight);
                    }
                  }
                }
              }
            }
          }
          simpleList1.Sort();
          if (simpleList1.Counter > -1)
          {
            let mut row: i32 = simpleList1.Id[0];
            let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[row, 1]));
            this.data.StringListObj[this.slotAssets].RemoveRow(row);
            data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
            this.ai.AddLog("Found non-vital construction in zone " + num8.ToString() + ". Removed Asset Type: " + data);
          }
          this.ai.AddLog("3. Motball 1 non-vital construction.");
          SimpleList simpleList2 = SimpleList::new();
          let mut counter6: i32 = this.zoneList.Counter;
          for (let mut index20: i32 = 0; index20 <= counter6; index20 += 1)
          {
            num8 = this.zoneList.Id[index20];
            if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index20], 8])) == this.RegimeId)
            {
              for (let mut length12: i32 = this.data.StringListObj[this.slotAssets].Length; length12 >= 0; length12 += -1)
              {
                let mut num59: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length12, 0]));
                let mut num60: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length12, 5]));
                let mut num61: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length12, 8]));
                if (num60 > 0 & num59 == num8 & num61 == 0)
                {
                  let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length12, 1]));
                  let mut num62: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
                  num9 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
                  if (num9 == 1)
                  {
                    bool flag11 = false;
                    bool flag12 = false;
                    let mut num63: i32 = 0;
                    let mut length13: i32 = this.data.StringListObj[this.slotProdType].Length;
                    for (let mut index21: i32 = 0; index21 <= length13; index21 += 1)
                    {
                      let mut num64: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index21, 0]));
                      if (num62 == num64)
                      {
                        let mut num65: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index21, 2]));
                        let mut index22: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index21, 3]));
                        if (num65 == 2)
                        {
                          if (flagArray1[index22])
                            flag11 = true;
                          if (flagArray2[index22])
                            flag12 = true;
                          num63 += numArray2[index22];
                        }
                      }
                    }
                    if (!flag11 | num63 > 1)
                    {
                      let mut num66: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2))) * 100;
                      if (flag12)
                        num66 =  Math.Round((double) num66 / 3.0);
                      let mut tweight: i32 =  Math.Round((double) num66 / (double) num63);
                      if (flag11)
                        tweight *= 2;
                      simpleList2.Add(length12, tweight);
                    }
                  }
                }
              }
            }
          }
          simpleList2.Sort();
          if (simpleList2.Counter > -1)
          {
            let mut index23: i32 = simpleList2.Id[0];
            let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index23, 1]));
            this.data.StringListObj[this.slotAssets].Data[index23, 5] = -1.ToString();
            data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
            this.ai.AddLog("MOTBALLED a less or non-vital construction in zone  " + num8.ToString() + ". Concerns Asset Type: " + data);
            flag8 = true;
          }
          if (!flag8)
          {
            this.ai.AddLog("4. Close 1 non-vital construction that is currently motballed.");
            SimpleList simpleList3 = SimpleList::new();
            let mut counter7: i32 = this.zoneList.Counter;
            for (let mut index24: i32 = 0; index24 <= counter7; index24 += 1)
            {
              num8 = this.zoneList.Id[index24];
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index24], 8])) == this.RegimeId)
              {
                for (let mut length14: i32 = this.data.StringListObj[this.slotAssets].Length; length14 >= 0; length14 += -1)
                {
                  let mut num67: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length14, 0]));
                  let mut num68: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length14, 5]));
                  let mut num69: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length14, 8]));
                  if (num68 == -1 & num67 == num8 & num69 == 0)
                  {
                    let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length14, 1]));
                    let mut num70: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
                    num9 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
                    if (num9 == 1)
                    {
                      bool flag13 = false;
                      bool flag14 = false;
                      let mut num71: i32 = 0;
                      let mut length15: i32 = this.data.StringListObj[this.slotProdType].Length;
                      for (let mut index25: i32 = 0; index25 <= length15; index25 += 1)
                      {
                        let mut num72: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index25, 0]));
                        if (num70 == num72)
                        {
                          let mut num73: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index25, 2]));
                          let mut index26: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index25, 3]));
                          if (num73 == 2)
                          {
                            if (flagArray1[index26])
                              flag13 = true;
                            if (flagArray2[index26])
                              flag14 = true;
                            num71 += numArray2[index26];
                          }
                        }
                      }
                      if (!flag13 | num71 > 1)
                      {
                        let mut num74: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2))) * 100;
                        if (flag14)
                          num74 =  Math.Round((double) num74 / 3.0);
                        let mut tweight: i32 =  Math.Round((double) num74 / (double) num71);
                        if (flag13)
                          tweight *= 2;
                        simpleList3.Add(length14, tweight);
                      }
                    }
                  }
                }
              }
            }
            simpleList3.Sort();
            if (simpleList3.Counter > -1)
            {
              let mut index27: i32 = simpleList3.Id[0];
              let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index27, 1]));
              this.data.StringListObj[this.slotAssets].Data[index27, 5] = -2.ToString();
              data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
              this.ai.AddLog("CLOSED a less or non-vital construction in zone  " + num8.ToString() + ". Concerns Asset Type: " + data);
              flag7 = true;
            }
          }
        }
      }
      bool[] flagArray4 = new bool[100];
      let mut logCounter: i32 = this.data.UnitObj[this.shqUnitNr].LogCounter;
      for (let mut index: i32 = 0; index <= logCounter; index += 1)
      {
        if (this.data.UnitObj[this.shqUnitNr].LogData1[index] > 0 && this.data.UnitObj[this.shqUnitNr].LogType[index] == 301 & this.data.UnitObj[this.shqUnitNr].LogData3[index] > 0)
          flagArray4[this.data.UnitObj[this.shqUnitNr].LogData1[index]] = true;
      }
      SimpleList simpleList4 = SimpleList::new();
      SimpleList simpleList5 = SimpleList::new();
      let mut counter8: i32 = this.zoneList.Counter;
      for (let mut index28: i32 = 0; index28 <= counter8; index28 += 1)
      {
        let mut num75: i32 = this.zoneList.Id[index28];
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index28], 8])) == this.RegimeId)
        {
          for (let mut length16: i32 = this.data.StringListObj[this.slotAssets].Length; length16 >= 0; length16 += -1)
          {
            let mut num76: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 0]));
            let mut num77: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 5]));
            let mut num78: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 8]));
            if (num77 == -1 & num76 == num75 & num78 == 0)
            {
              let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 1]));
              let mut num79: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
              let mut num80: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 15)));
              let mut num81: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 15]));
              let mut num82: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
              if (num9 == 1)
              {
                bool flag15 = false;
                bool flag16 = false;
                let mut length17: i32 = this.data.StringListObj[this.slotProdType].Length;
                for (let mut index29: i32 = 0; index29 <= length17; index29 += 1)
                {
                  let mut num83: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index29, 0]));
                  if (num79 == num83)
                  {
                    let mut num84: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index29, 2]));
                    let mut index30: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index29, 3]));
                    if (num84 == 2)
                    {
                      if (flagArray4[index30])
                        flag15 = true;
                      else if (num81 > 0 & num81 < 100)
                        flag16 = true;
                    }
                  }
                }
                if (flag16)
                {
                  let mut num85: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 15]));
                  let mut tdata1: i32 = num85 > 25 ? (num85 > 50 ? (num85 > 75 ? 100 : 100) : 75) : 50;
                  simpleList5.Add(length16, num82 * 1000 - tdata1, tdata1);
                }
                if (flag15)
                {
                  let mut num86: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length16, 15]));
                  let mut tdata1: i32 = !(num86 >= 100 | num86 == 0) ? (num86 < 75 ? (num86 < 50 ? 0 : 25) : 50) : 75;
                  if (tdata1 > 0 & tdata1 < 100)
                    simpleList4.Add(length16, num82 * 1000 - tdata1, tdata1);
                }
              }
            }
          }
        }
      }
      let mut counter9: i32 = simpleList5.Counter;
      for (let mut index: i32 = 0; index <= counter9; index += 1)
      {
        let mut nr: i32 = simpleList4.FindNr(simpleList5.Id[index]);
        if (nr > -1)
          simpleList4.RemoveNr(nr);
      }
      simpleList4.Sort();
      simpleList5.Sort();
      if (simpleList4.Counter > -1)
      {
        let mut index: i32 = simpleList4.Id[0];
        let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
        let mut num87: i32 = simpleList4.Data1[0];
        if (num87 == 100)
          num87 = 0;
        this.data.StringListObj[this.slotAssets].Data[index, 15] = num87.ToString();
        data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
        this.ai.AddLog("REDUCED production to  " + num87.ToString() + ". Concerns Asset Type: " + data);
      }
      let mut counter10: i32 = simpleList5.Counter;
      for (let mut index31: i32 = 0; index31 <= counter10; index31 += 1)
      {
        if (index31 <= 1)
        {
          let mut index32: i32 = simpleList4.Id[index31];
          let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index32, 1]));
          let mut num88: i32 = simpleList4.Data1[index31];
          this.data.StringListObj[this.slotAssets].Data[index32, 15] = num88.ToString();
          data: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
          this.ai.AddLog("INCREASED production to  " + num88.ToString() + ". Concerns Asset Type: " + data);
        }
      }
      this.ai.WriteLog(str);
    }

    pub ReOpenMotballOrCloseAssets: bool(int assetTypeFamilyId, bool resetProd, int tpoolNr)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      bool[] flagArray = new bool[100];
      bool flag1 = false;
      int[] numArray = new int[100];
      let mut itemcounter: i32 = this.itemcounter;
      for (let mut tid: i32 = 0; tid <= itemcounter; tid += 1)
      {
        if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(tid) < this.itemNeed[tid] &&  Math.Round((double) this.itemNeed[tid] * 1.5) > this.itemProduction[tid] && tid == 7)
        {
          flag1 = true;
          flagArray[tid] = true;
          numArray[tid] = this.itemNeed[tid] - this.itemProduction[tid];
        }
      }
      bool flag2 = false;
      SimpleList simpleList = SimpleList::new();
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        let mut num1: i32 = this.zoneList.Id[index1];
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[this.zoneList.Data3[index1], 8])) == this.RegimeId)
        {
          for (let mut length1: i32 = this.data.StringListObj[this.slotAssets].Length; length1 >= 0; length1 += -1)
          {
            let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 0]));
            let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 5]));
            let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 8]));
            if (num3 < 0 & num2 == num1 & num4 == 0)
            {
              let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[length1, 1]));
              let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 11)));
              let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 14)));
              bool flag3 = false;
              let mut length2: i32 = this.data.StringListObj[this.slotProdType].Length;
              for (let mut index2: i32 = 0; index2 <= length2; index2 += 1)
              {
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 0])) == num6)
                {
                  if (tpoolNr == 5 &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 2])) == 1 && Operators.CompareString(this.data.StringListObj[this.slotProdType].Data[index2, 3].ToLower(), "bp", false) == 0)
                    flag3 = true;
                  if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 2])) == 2)
                  {
                    let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdType].Data[index2, 3].ToLower()));
                    if (tpoolNr == 6 & num7 == 5)
                      flag3 = true;
                    if (tpoolNr == 11 & num7 == 3)
                      flag3 = true;
                    if (tpoolNr == 4 & num7 == 1)
                      flag3 = true;
                    if (tpoolNr == 2 & num7 == 2)
                      flag3 = true;
                    if (tpoolNr == 12 & num7 == 13)
                      flag3 = true;
                    if (tpoolNr == 3 & num7 == 8)
                      flag3 = true;
                    if (tpoolNr == 13 & num7 == 14)
                      flag3 = true;
                    if (tpoolNr == 1 & num7 == 7)
                      flag3 = true;
                    if (tpoolNr == 10 & num7 == 15)
                      flag3 = true;
                    if (tpoolNr == 14 & num7 == 4)
                      flag3 = true;
                  }
                }
              }
              if (num6 == assetTypeFamilyId | flag3)
              {
                let mut tweight: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                if (num3 == -1)
                  tweight += 100;
                simpleList.Add(length1, tweight);
              }
            }
          }
        }
      }
      simpleList.ReverseSort();
      if (simpleList.Counter > -1)
      {
        let mut index: i32 = simpleList.Id[0];
        let mut num: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
        if (resetProd)
          this.data.StringListObj[this.slotAssets].Data[index, 5] = 0.ToString();
        flag2 = true;
      }
      return flag2;
    }

    pub int GetWorkerForAssetConstruction(int assetTypeId)
    {
      SimpleList simpleList = SimpleList::new();
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 13)));
      let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 14)));
      let mut assetConstruction: i32 = 0;
      let mut length: i32 = this.data.StringListObj[this.slotConstructionCost].Length;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 0])) == assetTypeId)
        {
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 1]));
          Left: String = this.data.StringListObj[this.slotConstructionCost].Data[index, 2];
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 3]));
          if (num3 == 3 & Operators.CompareString(Left, "workerPoints", false) == 0 & num4 > 0)
            assetConstruction += num4;
        }
      }
      return assetConstruction;
    }

    pub int GetWorkerForAssetProduction(int assetTypeId)
    {
      SimpleList simpleList = SimpleList::new();
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 13)));
      let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 14)));
      let mut forAssetProduction: i32 = 0;
      let mut length: i32 = this.data.StringListObj[this.slotProdCost].Length;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index, 0])) == assetTypeId)
        {
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index, 1]));
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index, 2]));
          let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotProdCost].Data[index, 4]));
          Left: String = this.data.StringListObj[this.slotProdCost].Data[index, 3];
          if (num4 == 3 & Operators.CompareString(Left, "workerPoints", false) == 0 & num5 > 0)
            forAssetProduction += num5;
        }
      }
      return forAssetProduction;
    }

    pub SimpleList GetItemsForAssetConstruction(int assetTypeId)
    {
      SimpleList assetConstruction = SimpleList::new();
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 13)));
      let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 14)));
      let mut length: i32 = this.data.StringListObj[this.slotConstructionCost].Length;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 0])) == assetTypeId)
        {
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 1]));
          let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 2]));
          let mut tweight: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 3]));
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 3]));
          if (num3 == 2 & tid > 0 & tweight > 0)
            assetConstruction.AddWeight(tid, tweight);
        }
      }
      return assetConstruction;
    }

    pub int GetEstimatedTurnsForAssetConstruction(int assetTypeId, Pool usePoolNr)
    {
      SimpleList simpleList = SimpleList::new();
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 13)));
      let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, assetTypeId, 14)));
      let mut length1: i32 = this.data.StringListObj[this.slotConstructionCost].Length;
      for (let mut index: i32 = 0; index <= length1; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 0])) == assetTypeId)
        {
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 1]));
          let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 2]));
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 3]));
          if (num3 == 2 & tid > 0 & num4 > 0)
            simpleList.AddWeight(tid, num4 * num1);
        }
      }
      let mut assetConstruction: i32 = 0;
      let mut num5: i32 = 1;
      let mut length2: i32 = this.data.StringListObj[this.slotPoolItems].Length;
      for (let mut index: i32 = 0; index <= length2; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index, 0])) == this.shqHisId && (Pool) Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index, 1])) == usePoolNr)
        {
          let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index, 2]));
          let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index, 3]));
          let mut tweight: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index, 4]));
          if (num6 == 1)
            simpleList.RemoveWeight(tid, tweight);
        }
      }
      while (num5 == 1)
      {
        simpleList.removeWeight0orLower();
        if (simpleList.Counter == -1)
          break;
        num5 = 1;
        assetConstruction += 1;
        let mut counter: i32 = simpleList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          let mut tweight: i32 =  Math.Round((double) this.newItems.FindWeight(simpleList.Id[index]) / 2.0) + 1;
          simpleList.RemoveWeight(simpleList.Id[index], tweight);
        }
        if (assetConstruction > 20)
          break;
      }
      return assetConstruction;
    }

    pub SimpleList GetUpgradeableSFTypes()
    {
      SimpleList upgradeableSfTypes = SimpleList::new();
      let mut unitCounter: i32 = this.data.UnitCounter;
      for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1)
        {
          let mut historical: i32 = this.data.UnitObj[unr].Historical;
          if (historical > -1 & DrawMod.TGame.HandyFunctionsObj.HasUnitHQSomewhereUp(unr, this.shqUnitNr) && this.data.HistoricalUnitObj[historical].GiveHisVarValue(11) < 1)
          {
            let mut sfCount: i32 = this.data.UnitObj[unr].SFCount;
            for (let mut index1: i32 = 0; index1 <= sfCount; index1 += 1)
            {
              let mut sf: i32 = this.data.UnitObj[unr].SFList[index1];
              let mut type: i32 = this.data.SFObj[sf].Type;
              let mut idValue: i32 = this.data.SFTypeObj[type].SFTypeVar[81];
              let mut num1: i32 = 0;
              if (idValue > 0)
              {
                let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, idValue, 1)));
                let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, idValue, 4)));
                let mut tdata1: i32 = -1;
                let mut length: i32 = this.data.StringListObj[this.slotRegimeModels].Length;
                for (let mut index2: i32 = 0; index2 <= length; index2 += 1)
                {
                  if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 2])) == this.RegimeId &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 1])) == num2 &  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 5])) > 0 &  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 5])) != this.data.SFTypeObj[type].Id)
                  {
                    let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 5]));
                    let mut sfTypeById: i32 = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id);
                    let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 4]));
                    if (num4 > num3)
                    {
                      num3 = num4;
                      tdata1 = sfTypeById;
                    }
                  }
                }
                if (tdata1 > -1)
                {
                  num1 = 1;
                  upgradeableSfTypes.AddWeight(type, this.data.SFObj[sf].Qty, tdata1);
                }
              }
            }
          }
        }
      }
      return upgradeableSfTypes;
    }

    pub SimpleList GetReplaceableSFTypes()
    {
      SimpleList replaceableSfTypes = SimpleList::new();
      let mut unitCounter: i32 = this.data.UnitCounter;
      for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1)
        {
          let mut historical: i32 = this.data.UnitObj[unr].Historical;
          if (historical > -1 & DrawMod.TGame.HandyFunctionsObj.HasUnitHQSomewhereUp(unr, this.shqUnitNr) && this.data.HistoricalUnitObj[historical].GiveHisVarValue(11) < 1)
          {
            let mut sfCount: i32 = this.data.UnitObj[unr].SFCount;
            for (let mut index1: i32 = 0; index1 <= sfCount; index1 += 1)
            {
              let mut sf: i32 = this.data.UnitObj[unr].SFList[index1];
              let mut type: i32 = this.data.SFObj[sf].Type;
              let mut idValue1: i32 = this.data.SFTypeObj[type].SFTypeVar[81];
              let mut num1: i32 = 0;
              if (idValue1 > 0)
              {
                let mut idValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, idValue1, 1)));
                let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, idValue2, 14)));
                let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, idValue2, 13)));
                let mut num4: i32 = 0;
                let mut tdata1: i32 = -1;
                if (num2 > 0 & num3 < 1)
                {
                  let mut length: i32 = this.data.StringListObj[this.slotRegimeModels].Length;
                  for (let mut index2: i32 = 0; index2 <= length; index2 += 1)
                  {
                    if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 2])) == this.RegimeId &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 5])) > 0 &  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 5])) != this.data.SFTypeObj[type].Id &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0,  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 1])), 14))) == num2)
                    {
                      let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 5]));
                      let mut sfTypeById: i32 = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id);
                      let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index2, 4]));
                      if (num5 > num4)
                      {
                        num4 = num5;
                        tdata1 = sfTypeById;
                      }
                    }
                  }
                }
                if (tdata1 > -1)
                {
                  num1 = 1;
                  replaceableSfTypes.AddWeight(type, this.data.SFObj[sf].Qty, tdata1);
                }
              }
            }
          }
        }
      }
      return replaceableSfTypes;
    }

    pub void ExecutePools(string logAddition)
    {
      SimpleList[] simpleListArray = new SimpleList[100];
      let mut num1: i32 = 0;
      str1: String = "9050_" + logAddition + "_ExecutePools";
      this.ai.ClearLog();
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      bool flag1 = true;
      SimpleList upgradeableSfTypes = this.GetUpgradeableSFTypes();
      let mut num2: i32 = 0;
      let mut num3: i32 = 0;
      let mut num4: i32 = 0;
      let mut poolCounter1: i32 = this.poolCounter;
      for (let mut index: i32 = 1; index <= poolCounter1; index += 1)
      {
        num2 += this.poolImportance[index];
        if (this.poolPreferedAssetType[index] > 0 & this.poolImportance[index] > num3)
          num3 = this.poolImportance[index];
        if (this.poolImportance[index] > num4)
          num4 = this.poolImportance[index];
      }
      let mut num5: i32 = 0;
      let mut num6: i32 = 0;
      let mut num7: i32 = 0;
      SimpleList simpleList1 = SimpleList::new();
      let mut poolCounter2: i32 = this.poolCounter;
      for (let mut tid: i32 = 1; tid <= poolCounter2; tid += 1)
      {
        if (this.poolImportance[tid] > 0)
          simpleList1.AddWeight(tid, this.poolImportance[tid]);
        if (this.poolImportance[tid] > num5)
        {
          num6 = num5;
          num5 = this.poolImportance[tid];
        }
        else if (this.poolImportance[tid] > num6)
          num6 = this.poolImportance[tid];
        num2 += this.poolImportance[tid];
      }
      if (simpleList1.Counter > 1)
      {
        simpleList1.Sort();
        num7 = simpleList1.Weight[ Math.Round(Math.Floor((double) simpleList1.Counter / 2.0))];
      }
      let mut num8: i32 = 0;
      SimpleList simpleList2 = SimpleList::new();
      let mut poolCounter3: i32 = this.poolCounter;
      for (let mut tid: i32 = 1; tid <= poolCounter3; tid += 1)
      {
        let mut num9: i32 = 999999;
        let mut counter: i32 = this.poolRequest[tid].Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          let mut num10: i32 =  Math.Round((double) (this.poolItems[tid].FindWeight(this.poolRequest[tid].Id[index]) * 100) / (double) this.poolRequest[tid].Weight[index]);
          if (num9 > num10)
            num9 = num10;
        }
        if (this.poolImportance[tid] > 0)
          num8 += 1;
        simpleList2.Add(tid, this.poolImportance[tid]);
      }
      simpleList2.ReverseSort();
      let mut num11: i32 =  Math.Round((double) num2 / (double) num8);
      bool[] flagArray = new bool[this.poolCounter + 1];
      SimpleList simpleList3 = SimpleList::new();
      let mut unitCounter1: i32 = this.data.UnitCounter;
      for (let mut unr: i32 = 0; unr <= unitCounter1; unr += 1)
      {
        if (this.data.UnitObj[unr].PreDef == -1 & this.data.UnitObj[unr].Regime == this.data.Turn && this.ai.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr))
        {
          SimpleList simpleList4 = simpleList3;
          SimpleList reinfListForUnit = this.ai.game.EventRelatedObj.Helper_GetReinfListForUnit(unr);
           SimpleList local =  reinfListForUnit;
          simpleList4.AddWeight( local);
        }
      }
      let mut sfCount1: i32 = this.data.UnitObj[this.shqUnitNr].SFCount;
      for (let mut index: i32 = 0; index <= sfCount1; index += 1)
      {
        let mut sf: i32 = this.data.UnitObj[this.shqUnitNr].SFList[index];
        let mut reinforcementType: i32 = this.data.SFTypeObj[this.data.SFObj[sf].Type].ReinforcementType;
        if (reinforcementType > -1)
        {
          let mut id: i32 = this.data.ReinfLibId[reinforcementType].id;
          if (id > 0)
            simpleList3.RemoveWeight(id, this.data.SFObj[sf].Qty);
        }
      }
      simpleList3.removeWeight0orLower();
      SimpleList simpleList5;
      if (simpleList3.Counter > -1)
      {
        EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
        SimpleList RL = simpleList3;
        let mut regimeId: i32 = this.RegimeId;
        SimpleList simpleList6 = (SimpleList) null;
         SimpleList local =  simpleList6;
        simpleList5 = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local), airAIqualityRules: true);
        for (let mut counter: i32 = simpleList5.Counter; counter >= 0; counter += -1)
        {
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData2(2, this.RegimeId, 5, this.data.SFTypeObj[simpleList5.Id[counter]].Id, 0))) < 1)
            simpleList5.RemoveNr(counter);
        }
      }
      if (Information.IsNothing((object) simpleList5))
        simpleList5 = SimpleList::new();
      if (simpleList5.Counter > -1)
      {
        SimpleList simpleList7 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(simpleList5);
        EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
        SimpleList RL = simpleList3;
        let mut regimeId: i32 = this.RegimeId;
        SimpleList simpleList8 = (SimpleList) null;
         SimpleList local =  simpleList8;
        SimpleList sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, false, false, false, regimeId, allowedSfTypeList: ( local), airAIqualityRules: true);
        for (let mut counter: i32 = sftypesForReinfList.Counter; counter >= 0; counter += -1)
        {
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData2(2, this.RegimeId, 5, this.data.SFTypeObj[sftypesForReinfList.Id[counter]].Id, 0))) < 1)
            sftypesForReinfList.RemoveNr(counter);
        }
        if (sftypesForReinfList.Counter > -1)
        {
          SimpleList simpleList9 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList);
          let mut num12: i32 = 0;
          let mut num13: i32 = 0;
          let mut num14: i32 = 0;
          let mut num15: i32 = 0;
          let mut counter: i32 = this.poolItems[9].Counter;
          for (let mut index: i32 = 0; index <= counter; index += 1)
          {
            let mut tid: i32 = this.poolItems[9].Id[index];
            let mut num16: i32 = this.poolItems[9].Weight[index];
            let mut weight1: i32 = simpleList7.FindWeight(tid);
            let mut weight2: i32 = simpleList9.FindWeight(tid);
            num14 += weight1;
            num15 += weight2;
            if (weight1 > num16)
              num12 += weight1 - num16;
            if (weight2 > num16)
              num13 += weight2 - num16;
          }
          if ( Math.Round((double) (num12 * 100) / (double) (num14 + 1)) >  Math.Round((double) (num13 * 133) / (double) (num15 + 1)))
            simpleList5 = sftypesForReinfList.Clone();
        }
      }
      let mut num17: i32 = Math.Max(1, simpleList5.Counter);
      bool flag2 = false;
      int num18;
      int num19;
      while (flag1)
      {
        flag1 = false;
        SimpleList simpleList10 = SimpleList::new();
        let mut counter1: i32 = simpleList2.Counter;
        int num20;
        for (let mut index1: i32 = 0; index1 <= counter1; index1 += 1)
        {
          let mut index2: i32 = simpleList2.Id[index1];
          simpleListArray[index2] = (SimpleList) null;
          if (this.poolPreferedAssetType[index2] > 0 & this.poolImportance[index2] > 0 & !flagArray[index2])
          {
            SimpleList simpleList11 = SimpleList::new();
            let mut num21: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, this.poolPreferedAssetType[index2], 13)));
            bool flag3 = this.ReOpenMotballOrCloseAssets( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, this.poolPreferedAssetType[index2], 14))), true, index2);
            if (!flag3)
            {
              let mut length: i32 = this.data.StringListObj[this.slotConstructionCost].Length;
              int tdata1;
              for (let mut index3: i32 = 0; index3 <= length; index3 += 1)
              {
                num20 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index3, 0]));
                if (num20 == this.poolPreferedAssetType[index2])
                {
                  let mut num22: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index3, 1]));
                  let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index3, 2]));
                  let mut tweight: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index3, 3]));
                  if (num22 == 2 & tid > 0 & tweight > 0)
                    simpleList11.AddWeight(tid, tweight);
                  else if (num22 == 3 & Operators.CompareString(this.data.StringListObj[this.slotConstructionCost].Data[index3, 2], "workerPoints", false) == 0)
                    tdata1 = tweight;
                }
              }
              bool flag4 = true;
              simpleListArray[index2] = simpleList11.Clone();
              let mut counter2: i32 = simpleListArray[index2].Counter;
              for (let mut index4: i32 = 0; index4 <= counter2; index4 += 1)
                simpleListArray[index2].Weight[index4] = simpleListArray[index2].Weight[index4] * num21;
              if (!flag3)
              {
                let mut counter3: i32 = simpleList11.Counter;
                for (let mut index5: i32 = 0; index5 <= counter3; index5 += 1)
                {
                  bool flag5 = false;
                  bool flag6 = false;
                  num18 = this.newItems.FindWeight(simpleList11.Id[index5]);
                  num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList11.Id[index5]);
                  num19 -= this.poolItems[7].FindWeight(simpleList11.Id[index5]);
                  num19 -= this.poolItems[9].FindWeight(simpleList11.Id[index5]);
                  num19 -= this.poolItems[8].FindWeight(simpleList11.Id[index5]);
                  num19 =  Math.Round((double) num19 / (double) Math.Max(1, num21 * 1));
                  let mut num23: i32 = num18 + num19;
                  this.ai.AddLog(this.poolName[index2] + " current new + stock " + this.itemName[simpleList11.Id[index5]] + ": new." + num18.ToString() + "+ shq/t." + num19.ToString() + " = " + num23.ToString() + " >= constr cost per turn: " + simpleList11.Weight[index5].ToString());
                  if (num23 < simpleList11.Weight[index5])
                  {
                    flag4 = false;
                    if (simpleList11.Id[index5] == 2)
                      flag5 = true;
                    if (simpleList11.Id[index5] == 8)
                      flag6 = true;
                  }
                  num18 = this.poolItems[index2].FindWeight(simpleList11.Id[index5]);
                  let mut num24: i32 = num19;
                  num19 =  Math.Round((double) num18 / (double) num21);
                  if (simpleList11.Id[index5] == 2)
                    num19 = num24 * 2;
                  if (simpleList11.Id[index5] == 8)
                    num19 = num24 * 2;
                  if (simpleList11.Id[index5] == 13)
                    num19 = num24 * 2;
                  if (simpleList11.Id[index5] == 14)
                    num19 = num24 * 2;
                  if (flag4 & this.poolImportance[index2] >= num6)
                  {
                    if (index2 == 1 | index2 == 6)
                      num19 +=  Math.Round((double) (num19 * num8) / 3.0);
                    else
                      num19 +=  Math.Round((double) (num19 * num8) / 6.0);
                  }
                  this.ai.AddLog(this.poolName[index2] + " pool reserve " + this.itemName[simpleList11.Id[index5]] + ":  res/t." + num19.ToString() + " >= constr cost per turn: " + simpleList11.Weight[index5].ToString());
                  if (num19 < simpleList11.Weight[index5])
                  {
                    flag4 = false;
                    if (this.poolImportance[index2] > num7)
                    {
                      if (index2 == 1 & (double) this.poolImportance[index2] * 0.66 > (double) this.poolImportance[2] & !flag5)
                      {
                        this.poolImportance[2] = 0;
                        this.ai.AddLog("Food is VITAL. Set METAL pool to 0 importance.");
                      }
                      if (index2 == 1 & (double) this.poolImportance[index2] * 0.5 > (double) this.poolImportance[6])
                      {
                        this.poolImportance[6] = 0;
                        this.ai.AddLog("Food is VITAL. Set WATER pool to 0 importance.");
                      }
                      if (index2 == 1 & (double) this.poolImportance[index2] * 0.75 > (double) this.poolImportance[3] & !flag6)
                      {
                        this.poolImportance[3] = 0;
                        this.ai.AddLog("Food is VITAL. Set IP pool to 0 importance.");
                      }
                      if (index2 == 1 & (double) this.poolImportance[index2] * 0.85 > (double) this.poolImportance[4])
                      {
                        this.poolImportance[4] = 0;
                        this.ai.AddLog("Food is VITAL. Set OIL pool to 0 importance.");
                      }
                      if (index2 == 1 & (double) this.poolImportance[index2] * 0.55 > (double) this.poolImportance[7])
                      {
                        this.poolImportance[7] = 0;
                        this.ai.AddLog("Food is VITAL. Set OOB pool to 0 importance.");
                      }
                      if (index2 == 1 & (double) this.poolImportance[index2] * 0.45 > (double) this.poolImportance[9])
                      {
                        this.poolImportance[9] = 0;
                        this.ai.AddLog("Food is VITAL. Set REPL pool to 0 importance.");
                      }
                    }
                  }
                }
              }
              if (tdata1 > 0)
              {
                if (this.poolImportance[index2] > num7 & (index2 == 1 | index2 == 6 | index2 == 10 | index2 == 11))
                {
                  this.ai.AddLog(this.poolName[index2] + " VITAL... Is... worker reserve PLUS points: " + this.VAR_FreeWorkerReservePlus.ToString() + "  >= " + tdata1.ToString() + " work pts req.");
                  if (index2 == 6 | index2 == 1 | index2 == 10 | index2 == 11)
                  {
                    if (this.VAR_FreeWorkerReservePlus < tdata1)
                    {
                      flag4 = false;
                      this.poolConstrBlocked[index2] = true;
                      if ((double) this.poolImportance[index2] > (double) num3 * 0.66)
                        flag2 = true;
                    }
                  }
                  else if (this.VAR_FreeWorkerReserve + Math.Max(0,  Math.Round((double) (this.VAR_IdealWorker - this.VAR_CurrentWorker) / 2.0)) < tdata1)
                  {
                    flag4 = false;
                    this.poolConstrBlocked[index2] = true;
                    if ((double) this.poolImportance[index2] > (double) num3 * 0.9)
                      flag2 = true;
                  }
                }
                else
                {
                  this.ai.AddLog(this.poolName[index2] + " Non-Vital... Is...  worker reserve points: " + this.VAR_FreeWorkerReserve.ToString() + "  >= " + tdata1.ToString() + " work pts req.");
                  if (this.VAR_FreeWorkerReserve < tdata1)
                    flag4 = false;
                }
              }
              if (flag4)
              {
                this.ai.AddLog(this.poolName[index2] + " can execute.");
                simpleList10.Add(index2, this.poolImportance[index2], tdata1);
              }
              else
                this.ai.AddLog(this.poolName[index2] + " can not execute.");
            }
            else
              flagArray[index2] = true;
          }
          else if (this.poolPreferedOob[index2] > 0 & this.poolPreferedOobUpgradeHisId[index2] > 0 & this.poolPreferedToe[index2] > 0)
          {
            SimpleList reinfListForOob = DrawMod.TGame.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[index2], this.poolPreferedToe[index2]);
            EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
            SimpleList RL = reinfListForOob;
            let mut regimeId: i32 = this.RegimeId;
            SimpleList simpleList12 = (SimpleList) null;
             SimpleList local =  simpleList12;
            SimpleList sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local));
            SimpleList simpleList13 = DrawMod.TGame.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList);
            bool flag7 = true;
            simpleListArray[index2] = simpleList13.Clone();
            let mut counter4: i32 = simpleList13.Counter;
            for (let mut index6: i32 = 0; index6 <= counter4; index6 += 1)
            {
              num18 = this.poolItems[index2].FindWeight(simpleList13.Id[index6]);
              num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList13.Id[index6]);
              this.ai.AddLog(this.poolName[index2] + " has " + this.itemName[simpleList13.Id[index6]] + ": pool." + num18.ToString() + " and shq." + num19.ToString() + " >=? restore Unit cost " + simpleList13.Weight[index6].ToString());
              if (this.poolImportance[index2] >= num4)
              {
                if (num18 <  Math.Round((double) simpleList13.Weight[index6] * 0.66) | num19 < simpleList13.Weight[index6])
                  flag7 = false;
              }
              else if (num18 < simpleList13.Weight[index6] | num19 < simpleList13.Weight[index6])
                flag7 = false;
            }
            if (flag7)
            {
              this.ai.AddLog(this.poolName[index2] + " can execute.");
              simpleList10.Add(index2, this.poolImportance[index2]);
            }
            else
              this.ai.AddLog(this.poolName[index2] + " can not execute.");
          }
          else if (this.poolPreferedOob[index2] > 0 & this.poolPreferedOobUpgradeHisId[index2] <= 0)
          {
            SimpleList reinfListForOob = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[index2]);
            EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
            SimpleList RL = reinfListForOob;
            let mut regimeId: i32 = this.RegimeId;
            SimpleList simpleList14 = (SimpleList) null;
             SimpleList local =  simpleList14;
            SimpleList simpleList15 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local)));
            bool flag8 = true;
            simpleListArray[index2] = simpleList15.Clone();
            let mut counter5: i32 = simpleList15.Counter;
            for (let mut index7: i32 = 0; index7 <= counter5; index7 += 1)
            {
              num18 = this.poolItems[index2].FindWeight(simpleList15.Id[index7]);
              num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList15.Id[index7]);
              this.ai.AddLog(this.poolName[index2] + " has " + this.itemName[simpleList15.Id[index7]] + ": pool." + num18.ToString() + " and shq." + num19.ToString() + " >=? raise OOB cost " + simpleList15.Weight[index7].ToString());
              if (this.poolImportance[index2] >= num4)
              {
                if (num18 <  Math.Round((double) simpleList15.Weight[index7] * 0.66) | num19 < simpleList15.Weight[index7])
                  flag8 = false;
              }
              else if (num18 < simpleList15.Weight[index7] | num19 < simpleList15.Weight[index7])
                flag8 = false;
            }
            if (flag8)
            {
              this.ai.AddLog(this.poolName[index2] + " can execute.");
              simpleList10.Add(index2, this.poolImportance[index2]);
            }
            else
              this.ai.AddLog(this.poolName[index2] + " can not execute.");
          }
          else if (this.poolPreferedOob[index2] > 0 & this.poolPreferedOobUpgradeHisId[index2] > 0)
          {
            let mut historicalUnitById: i32 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(this.poolPreferedOobUpgradeHisId[index2]);
            if (historicalUnitById > -1)
            {
              let mut OobTypeId: i32 = this.data.HistoricalUnitObj[historicalUnitById].GiveHisVarValue(1);
              if (OobTypeId > 0 & OobTypeId != this.poolPreferedOob[index2])
              {
                SimpleList reinfListForOob1 = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[index2]);
                SimpleList reinfListForOob2 = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(OobTypeId);
                reinfListForOob1.RemoveWeight( reinfListForOob2);
                reinfListForOob1.removeWeight0orLower();
                EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
                SimpleList RL = reinfListForOob1;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList16 = (SimpleList) null;
                 SimpleList local =  simpleList16;
                SimpleList simpleList17 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local)));
                bool flag9 = true;
                simpleListArray[index2] = simpleList17.Clone();
                let mut counter6: i32 = simpleList17.Counter;
                for (let mut index8: i32 = 0; index8 <= counter6; index8 += 1)
                {
                  num18 = this.poolItems[index2].FindWeight(simpleList17.Id[index8]);
                  num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList17.Id[index8]);
                  this.ai.AddLog(this.poolName[index2] + " has " + this.itemName[simpleList17.Id[index8]] + ": pool." + num18.ToString() + " and shq." + num19.ToString() + " >=? raise OOB cost " + simpleList17.Weight[index8].ToString());
                  if (this.poolImportance[index2] >= num4)
                  {
                    if (num18 <  Math.Round((double) simpleList17.Weight[index8] / 2.0) | num19 < simpleList17.Weight[index8])
                      flag9 = false;
                  }
                  else if (num18 < simpleList17.Weight[index8] | num19 < simpleList17.Weight[index8])
                    flag9 = false;
                }
                if (flag9)
                {
                  this.ai.AddLog(this.poolName[index2] + " can execute.");
                  simpleList10.Add(index2, this.poolImportance[index2]);
                }
                else
                  this.ai.AddLog(this.poolName[index2] + " can not execute.");
              }
            }
            else
              this.poolPreferedOobUpgradeHisId[index2] = -1;
          }
          else if (8 == index2 & !flagArray[8])
          {
            num18 = this.poolItems[index2].FindWeight(8);
            num19 = this.poolItems[index2].FindWeight(2);
            let mut tweight: i32 = Math.Min(num18, num19);
            if (tweight > 0)
            {
              SimpleList simpleList18 = SimpleList::new();
              simpleList18.AddWeight(8, tweight);
              simpleList18.AddWeight(2, tweight);
              simpleListArray[index2] = simpleList18.Clone();
              let mut counter7: i32 = simpleList18.Counter;
              for (let mut index9: i32 = 0; index9 <= counter7; index9 += 1)
              {
                num18 = this.newItems.FindWeight(simpleList18.Id[index9]);
                num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList18.Id[index9]);
                num19 =  Math.Round((double) (num19 * this.poolImportance[index2]) / (double) num2);
                let mut num25: i32 = num18 + num19;
                this.ai.AddLog(this.poolName[index2] + " current new + stock " + this.itemName[simpleList18.Id[index9]] + ": " + num18.ToString() + "+" + num19.ToString() + " = " + num25.ToString() + " >=? Get " + tweight.ToString() + " Ammo Cost: " + simpleList18.Weight[index9].ToString());
              }
              this.ai.AddLog(this.poolName[index2] + " can execute.");
              simpleList10.Add(index2, this.poolImportance[index2]);
            }
            else
              this.ai.AddLog(this.poolName[index2] + " can not execute.");
          }
          else if (9 == index2)
          {
            SimpleList SL1 = simpleList5.Clone();
            SL1.removeWeight0orLower();
            SL1.ReverseSortHighSpeed();
            while (SL1.Counter > 0)
              SL1.RemoveNr(1);
            let mut num26: i32 = SL1.Weight[0];
            SL1.Weight[0] = 1;
            SimpleList simpleList19 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(SL1);
            SimpleList simpleList20 = simpleList19.Clone();
            let mut multi: i32 = 1;
            let mut num27: i32 = 0;
            bool flag10 = true;
            SimpleList simpleList21;
            while (flag10 & simpleList19.Counter > -1)
            {
              let mut counter8: i32 = simpleList19.Counter;
              for (let mut index10: i32 = 0; index10 <= counter8; index10 += 1)
              {
                num18 = this.newItems.FindWeight(simpleList19.Id[index10]);
                num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList19.Id[index10]);
                num19 = this.poolItems[index2].FindWeight(simpleList19.Id[index10]);
                let mut num28: i32 = num19;
                this.ai.AddLog(this.poolName[index2] + " current new + stock " + this.itemName[simpleList19.Id[index10]] + ": " + num18.ToString() + "+" + num19.ToString() + " = " + num28.ToString() + " >=? raise " + multi.ToString() + "x SFType cost " + simpleList19.Weight[index10].ToString());
                if (num28 < simpleList19.Weight[index10])
                  flag10 = false;
              }
              if (flag10)
              {
                num27 = multi;
                simpleList21 = simpleList19.Clone();
              }
              if (multi < num26 & flag10)
              {
                multi += 1;
                simpleList19 = simpleList20.Clone();
                simpleList19.MultiplyWeight(multi);
              }
              else
                flag10 = false;
            }
            simpleListArray[index2] = simpleList19.Clone();
            if (num27 > 0)
            {
              this.ai.AddLog(this.poolName[index2] + " can execute.");
              simpleList10.Add(index2, this.poolImportance[index2]);
            }
            else
            {
              this.ai.AddLog(this.poolName[index2] + " can not execute.");
              simpleList5.RemoveNr(0);
            }
            if (num27 < 1)
            {
              SimpleList simpleList22 = upgradeableSfTypes;
              if (simpleList22.Counter > -1)
              {
                simpleList22.ReverseSort();
                SimpleList SL2 = SimpleList::new();
                SL2.Add(simpleList22.Data1[0], simpleList22.Weight[0], simpleList22.Id[0]);
                let mut num29: i32 = SL2.Weight[0];
                SL2.Weight[0] = 1;
                SimpleList simpleList23 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(SL2, subtractSFtype: simpleList22.Id[0]);
                simpleList21 = SimpleList::new();
                SimpleList simpleList24 = simpleList23.Clone();
                multi = 1;
                num27 = 0;
                bool flag11 = true;
                while (flag11 & simpleList23.Counter > -1)
                {
                  let mut counter9: i32 = simpleList23.Counter;
                  for (let mut index11: i32 = 0; index11 <= counter9; index11 += 1)
                  {
                    num18 = this.newItems.FindWeight(simpleList23.Id[index11]);
                    num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList23.Id[index11]);
                    num19 = this.poolItems[index2].FindWeight(simpleList23.Id[index11]);
                    let mut num30: i32 = num19;
                    this.ai.AddLog(this.poolName[index2] + " current new + stock " + this.itemName[simpleList23.Id[index11]] + ": " + num18.ToString() + "+" + num19.ToString() + " = " + num30.ToString() + " >=? upgrade " + multi.ToString() + "x SFType cost " + simpleList23.Weight[index11].ToString());
                    if (num30 < simpleList23.Weight[index11])
                      flag11 = false;
                  }
                  if (flag11)
                  {
                    num27 = multi;
                    simpleList21 = simpleList23.Clone();
                  }
                  if (multi < num29 & flag11)
                  {
                    multi += 1;
                    simpleList23 = simpleList24.Clone();
                    simpleList23.MultiplyWeight(multi);
                  }
                  else
                    flag11 = false;
                }
                simpleListArray[index2] = simpleList23.Clone();
                if (num27 > 0)
                {
                  this.ai.AddLog(this.poolName[index2] + " can execute upgrade.");
                  simpleList10.Add(index2, this.poolImportance[index2], 1);
                }
                else
                {
                  this.ai.AddLog(this.poolName[index2] + " can not execute upgrade.");
                  simpleList5.RemoveNr(0);
                }
              }
            }
            if (num27 < 1)
            {
              SimpleList replaceableSfTypes = this.GetReplaceableSFTypes();
              if (replaceableSfTypes.Counter > -1)
              {
                replaceableSfTypes.ReverseSort();
                SimpleList SL3 = SimpleList::new();
                SL3.Add(replaceableSfTypes.Data1[0], replaceableSfTypes.Weight[0], replaceableSfTypes.Id[0]);
                let mut num31: i32 = SL3.Weight[0];
                SL3.Weight[0] = 1;
                SimpleList simpleList25 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(SL3);
                simpleList21 = SimpleList::new();
                SimpleList simpleList26 = simpleList25.Clone();
                multi = 1;
                let mut num32: i32 = 0;
                bool flag12 = true;
                while (flag12 & simpleList25.Counter > -1)
                {
                  let mut counter10: i32 = simpleList25.Counter;
                  for (let mut index12: i32 = 0; index12 <= counter10; index12 += 1)
                  {
                    num18 = this.newItems.FindWeight(simpleList25.Id[index12]);
                    num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList25.Id[index12]);
                    num19 = this.poolItems[index2].FindWeight(simpleList25.Id[index12]);
                    let mut num33: i32 = num19;
                    this.ai.AddLog(this.poolName[index2] + " current new + stock " + this.itemName[simpleList25.Id[index12]] + ": " + num18.ToString() + "+" + num19.ToString() + " = " + num33.ToString() + " >=? replace " + multi.ToString() + "x SFType cost " + simpleList25.Weight[index12].ToString());
                    if (num33 < simpleList25.Weight[index12])
                      flag12 = false;
                  }
                  if (flag12)
                  {
                    num32 = multi;
                    simpleList21 = simpleList25.Clone();
                  }
                  if (multi < num31 & flag12)
                  {
                    multi += 1;
                    simpleList25 = simpleList26.Clone();
                    simpleList25.MultiplyWeight(multi);
                  }
                  else
                    flag12 = false;
                }
                simpleListArray[index2] = simpleList25.Clone();
                if (num32 > 0)
                {
                  this.ai.AddLog(this.poolName[index2] + " can execute replace.");
                  simpleList10.Add(index2, this.poolImportance[index2], 2);
                }
                else
                {
                  this.ai.AddLog(this.poolName[index2] + " can not execute replace.");
                  simpleList5.RemoveNr(0);
                }
              }
            }
          }
        }
        if (simpleList10.Counter > -1)
        {
          simpleList10.ReverseSort();
          let mut index13: i32 = simpleList10.Id[0];
          let mut num34: i32 = this.poolPreferedAssetType[index13];
          num1 += 1;
          let mut num35: i32 = this.poolPreferedOob[index13];
          data1: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, this.poolPreferedAssetType[index13], 1);
          this.data.StringListObj[this.slotAssetTypes].GetData(0, this.poolPreferedOob[index13], 1);
          SimpleList simpleList27 = SimpleList::new();
          SimpleList simpleList28 = SimpleList::new();
          if (index13 == 1)
            simpleList27 = this.GetPoolAssetPreference_FoodPool();
          if (index13 == 3)
            simpleList27 = this.GetPoolAssetPreference_IndustryPointsPool();
          if (index13 == 4)
            simpleList27 = this.GetPoolAssetPreference_OilPool();
          if (index13 == 6)
            simpleList27 = this.GetPoolAssetPreference_WaterPool();
          if (index13 == 2)
            simpleList27 = this.GetPoolAssetPreference_MetalPool();
          if (index13 == 7)
            simpleList28 = this.GetPoolAssetPreference_oobPool("Step" + num1.ToString());
          if (index13 == 5)
            simpleList27 = this.GetPoolAssetPreference_BPPool();
          if (index13 == 10)
            simpleList27 = this.GetPoolAssetPreference_EnergyPool();
          if (index13 == 11)
            simpleList27 = this.GetPoolAssetPreference_RarePool();
          if (index13 == 12)
            simpleList27 = this.GetPoolAssetPreference_MachinePool();
          if (index13 == 13)
            simpleList27 = this.GetPoolAssetPreference_HiTechPool();
          if (index13 == 14)
            simpleList27 = this.GetPoolAssetPreference_AtomicsPool();
          simpleList27.ReverseSort();
          let mut num36: i32 = simpleList27.Counter <= -1 ? -1 : simpleList27.Id[0];
          num35 = simpleList28.Counter <= -1 ? -1 : simpleList28.Id[0];
          if (num36 > -1 & simpleList27.Counter > -1)
          {
            num18 = this.zones.Value[simpleList27.Data1[0], simpleList27.Data2[0]];
            let mut counter11: i32 = this.zoneList.Counter;
            for (let mut index14: i32 = 0; index14 <= counter11; index14 += 1)
            {
              num19 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].GetData2(0, num36, 0, this.zoneList.Id[index14], 8)));
              if (num19 > 0)
              {
                simpleList27 = SimpleList::new();
                this.ai.AddLog("!!xxxx-----------------xxxx!!");
                data1 = this.data.StringListObj[this.slotAssetTypes].GetData(0, num36, 1);
                this.ai.AddLog(this.poolName[index13] + " ABORTED construction of " + data1 + " in zone#" + this.zoneList.Id[index14].ToString() + ". DUE TO EXACTLY THE SAME CONSTRUCTION still in progress.");
                this.ai.AddLog("!!xxxx-----------------xxxx!!");
                this.poolPreferedAssetType[index13] = -1;
                simpleList27.Counter = -1;
                flag1 = true;
              }
            }
          }
          let mut num37: i32 = num36 > -1 & simpleList27.Counter > -1 ? 1 : 0;
          int index15;
          if (simpleList27.Counter > -1)
          {
            let mut x: i32 = simpleList27.Data1[0];
            let mut y: i32 = simpleList27.Data2[0];
            num18 = this.zones.Value[x, y];
            num19 = this.zoneList.FindNr(num18);
            SimpleList simpleList29;
            if (!this.ReOpenMotballOrCloseAssets( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, num36, 14))), true, index13))
            {
              bool flag13 = false;
              if (this.GetWorkerForAssetConstruction(num36) <= this.VAR_FreeWorkerReservePlus)
                flag13 = true;
              if (!this.shqConstructionBlock | flag13)
              {
                data2: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, num36, 1);
                this.ai.AddLog("-------------------");
                this.ai.AddLog(this.poolName[index13] + " executed construction of " + data2 + " on " + x.ToString() + "," + y.ToString() + " in zone#" + num18.ToString() + ".");
                this.ai.AddLog("-------------------");
                this.ai.game.EventRelatedObj.Helper_StartAssetConstruction(num18, x, y, num36);
                this.newItems.RemoveWeight( simpleListArray[index13]);
                this.VAR_FreeWorkerReservePlus -= simpleList10.Data1[0];
                this.VAR_FreeWorkerReserve -= simpleList10.Data1[0];
                flagArray[index13] = true;
                let mut counter12: i32 = simpleListArray[index13].Counter;
                for (let mut index16: i32 = 0; index16 <= counter12; index16 += 1)
                {
                  let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index16], 4))) - simpleListArray[index13].Weight[index16];
                  this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index16], simpleListArray[index13].Weight[index16]);
                  if (0 > setValue)
                    setValue = 0;
                  this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index16], 4, setValue, true);
                }
                flag1 = true;
                this.shqConstructionBlock = true;
              }
              else
              {
                this.ai.AddLog("!!xxxx-----------------xxxx!!");
                this.ai.AddLog(this.poolName[index13] + " CUED construction of " + data1 + " on " + x.ToString() + "," + y.ToString() + " in zone#" + num18.ToString() + ". DUE TO OTHER CONSTRUCTION still in progress.");
                this.ai.AddLog("!!xxxx-----------------xxxx!!");
                simpleList29 = SimpleList::new();
                this.poolPreferedAssetType[index13] = -1;
                flag1 = true;
              }
            }
            else
            {
              this.ai.AddLog("!!xxxx-----------------xxxx!!");
              this.ai.AddLog(this.poolName[index13] + " ABORTED construction of " + data1 + " on " + x.ToString() + "," + y.ToString() + " in zone#" + num18.ToString() + ". DUE TO POSSIBILITY TO RE-OPEN ASSET OF SAME FAMILY");
              this.ai.AddLog("!!xxxx-----------------xxxx!!");
              simpleList29 = SimpleList::new();
              this.poolPreferedAssetType[index13] = -1;
              flag1 = true;
            }
          }
          else if (simpleList28.Counter > -1)
          {
            if (simpleList28.Data3[0] > 0 & simpleList28.Data4[0] > 0)
            {
              this.poolPreferedOob[index13] = simpleList28.Id[0];
              this.poolPreferedOobUpgradeHisId[index13] = simpleList28.Data3[0];
              this.poolPreferedToe[index13] = simpleList28.Data4[0];
              this.poolPreferedQuality[index13] = simpleList28.Data5[0];
              let mut historicalUnitById: i32 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(simpleList28.Data3[0]);
              if (historicalUnitById > -1 && this.data.HistoricalUnitObj[historicalUnitById].GiveHisVarValue(1) > 0)
              {
                let mut unitByHistorical: i32 = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
                SimpleList reinfListForOob = DrawMod.TGame.EventRelatedObj.Helper_GetReinfListForOob(simpleList28.Id[0], simpleList28.Data4[0]);
                SimpleList sftypesForReinfList;
                if (simpleList28.Data5[0] == 5)
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  SimpleList RL = reinfListForOob;
                  let mut regimeId: i32 = this.RegimeId;
                  SimpleList simpleList30 = (SimpleList) null;
                   SimpleList local =  simpleList30;
                  sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, false, false, false, true, regimeId, allowedSfTypeList: ( local));
                }
                else if (simpleList28.Data5[0] == 4)
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  SimpleList RL = reinfListForOob;
                  let mut regimeId: i32 = this.RegimeId;
                  SimpleList simpleList31 = (SimpleList) null;
                   SimpleList local =  simpleList31;
                  sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, false, regimeId, allowedSfTypeList: ( local));
                }
                else if (simpleList28.Data5[0] == 3)
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  SimpleList RL = reinfListForOob;
                  let mut regimeId: i32 = this.RegimeId;
                  SimpleList simpleList32 = (SimpleList) null;
                   SimpleList local =  simpleList32;
                  sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, false, false, regimeId, allowedSfTypeList: ( local));
                }
                else if (simpleList28.Data5[0] == 2)
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  SimpleList RL = reinfListForOob;
                  let mut regimeId: i32 = this.RegimeId;
                  SimpleList simpleList33 = (SimpleList) null;
                   SimpleList local =  simpleList33;
                  sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, false, false, false, regimeId, allowedSfTypeList: ( local));
                }
                else
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  SimpleList RL = reinfListForOob;
                  let mut regimeId: i32 = this.RegimeId;
                  SimpleList simpleList34 = (SimpleList) null;
                   SimpleList local =  simpleList34;
                  sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local));
                }
                SimpleList SL = DrawMod.TGame.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList);
                let mut tvalue: i32 = unitByHistorical * 10000 + simpleList28.Data4[0];
                let mut stringlistid: i32 = DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0);
                DrawMod.TGame.EventRelatedObj.ExecKey(stringlistid, "SHQNR", this.shqUnitNr.ToString(), "", "");
                DrawMod.TGame.EditObj.UDSClearInput();
                DrawMod.TGame.EditObj.UDSAddInput("SHQNR", this.shqUnitNr);
                DrawMod.TGame.EditObj.UDSAddInput("UNR", -1);
                DrawMod.TGame.EditObj.UDSAddInput("CHOICE", 0);
                DrawMod.TGame.EditObj.UDSAddInput("CHOICE2", 0);
                DrawMod.TGame.EditObj.UDSAddInput("CHOICE4", 0);
                DrawMod.TGame.EditObj.UDSAddInput("CHOICE3", tvalue);
                if (simpleList28.Data5[0] == 4)
                {
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY2", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY3", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY4", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY5", 0);
                }
                else if (simpleList28.Data5[0] == 3)
                {
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY2", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY3", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY4", 0);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY5", 0);
                }
                else if (simpleList28.Data5[0] == 2)
                {
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY2", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY3", 0);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY4", 0);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY5", 0);
                }
                else if (simpleList28.Data5[0] == 5)
                {
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY2", 0);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY3", 0);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY4", 0);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY5", 1);
                }
                else
                {
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY2", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY3", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY4", 1);
                  DrawMod.TGame.EditObj.UDSAddInput("TABQUALITY5", 1);
                }
                DrawMod.TGame.SelectX = this.data.UnitObj[unitByHistorical].X;
                DrawMod.TGame.SelectY = this.data.UnitObj[unitByHistorical].Y;
                let mut idValue: i32 = this.zones.Value[DrawMod.TGame.SelectX, DrawMod.TGame.SelectY];
                if (idValue > 0)
                {
                  let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, idValue, 6)));
                  let mut locationById: i32 = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
                  let mut num38: i32 = -1;
                  if (locationById > -1)
                    num38 = this.data.LocObj[locationById].HQ;
                  if (num38 != this.shqUnitNr)
                  {
                    DrawMod.TGame.SelectX = this.data.UnitObj[this.shqUnitNr].X;
                    DrawMod.TGame.SelectY = this.data.UnitObj[this.shqUnitNr].Y;
                    idValue = this.zones.Value[DrawMod.TGame.SelectX, DrawMod.TGame.SelectY];
                  }
                }
                DrawMod.TGame.EventRelatedObj.ExecKey(stringlistid, "ZONE", idValue.ToString(), "", "");
                DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_ProduceOob_Commence(0, simpleList28.Data5[0]);
                DrawMod.TGame.EventRelatedObj.IO_AddClear();
                this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight( SL);
                this.newItems.RemoveWeight( simpleListArray[index13]);
                let mut counter13: i32 = simpleListArray[index13].Counter;
                for (let mut index17: i32 = 0; index17 <= counter13; index17 += 1)
                {
                  let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index17], 4))) - simpleListArray[index13].Weight[index17];
                  this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index17], simpleListArray[index13].Weight[index17]);
                  if (0 > setValue)
                    setValue = 0;
                  this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index17], 4, setValue, true);
                }
                flag1 = true;
                this.ai.AddLog("-------------------");
                this.ai.AddLog(this.poolName[index13] + " executed ADDING NEW UNIT to " + this.data.HistoricalUnitObj[historicalUnitById].Name);
                this.ai.AddLog("-------------------");
              }
            }
            else if (simpleList28.Data3[0] > 0)
            {
              this.poolPreferedOob[index13] = simpleList28.Id[0];
              this.poolPreferedToe[index13] = 0;
              this.poolPreferedOobUpgradeHisId[index13] = simpleList28.Data3[0];
              this.poolPreferedQuality[index13] = simpleList28.Data5[0];
              let mut historicalUnitById: i32 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(simpleList28.Data3[0]);
              if (historicalUnitById > -1)
              {
                let mut num39: i32 = this.data.HistoricalUnitObj[historicalUnitById].GiveHisVarValue(1);
                let mut origOobId: i32 = this.data.HistoricalUnitObj[historicalUnitById].GiveHisVarValue(3);
                if (num39 > 0)
                {
                  DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
                  DrawMod.TGame.EventRelatedObj.Helper_UpgradeOrDowngradeOOB(origOobId, num39, this.RegimeId, this.poolPreferedOob[index13]);
                  SimpleList reinfListForOob3 = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[index13]);
                  SimpleList reinfListForOob4 = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(num39);
                  reinfListForOob3.RemoveWeight( reinfListForOob4);
                  reinfListForOob3.removeWeight0orLower();
                  data3: String = this.data.StringListObj[this.slotOobTypes].GetData(0, this.poolPreferedOob[index13], 1);
                  this.ai.AddLog("-------------------");
                  this.ai.AddLog(this.poolName[index13] + " executed OOB UPGRADING to " + data3 + " on " + this.data.HistoricalUnitObj[historicalUnitById].Name);
                  this.ai.AddLog("-------------------");
                  this.newItems.RemoveWeight( simpleListArray[index13]);
                  let mut counter14: i32 = simpleListArray[index13].Counter;
                  for (let mut index18: i32 = 0; index18 <= counter14; index18 += 1)
                  {
                    let mut val1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index18], 4)));
                    let mut tweight: i32 = Math.Min(val1, simpleListArray[index13].Weight[index18]);
                    let mut setValue1: i32 = val1 - simpleListArray[index13].Weight[index18];
                    this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index18], simpleListArray[index13].Weight[index18]);
                    if (0 > setValue1)
                      setValue1 = 0;
                    this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index18], 4, setValue1, true);
                    let mut setValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, 9, 2, 1, 3, simpleListArray[index13].Id[index18], 4))) + tweight;
                    this.poolItems[9].AddWeight(simpleListArray[index13].Id[index18], tweight);
                    this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, 9, 2, 1, 3, simpleListArray[index13].Id[index18], 4, setValue2, true);
                  }
                  flag1 = true;
                }
              }
            }
            else
            {
              this.poolPreferedOob[index13] = simpleList28.Id[0];
              this.poolPreferedQuality[index13] = simpleList28.Data5[0];
              this.poolPreferedToe[index13] = 0;
              let mut x: i32 = simpleList28.Data1[0];
              let mut y: i32 = simpleList28.Data2[0];
              num18 = this.zones.Value[x, y];
              data4: String = this.data.StringListObj[this.slotOobTypes].GetData(0, this.poolPreferedOob[index13], 1);
              this.ai.AddLog("-------------------");
              this.ai.AddLog(this.poolName[index13] + " executed OOB raising of " + data4 + " on " + x.ToString() + "," + y.ToString() + " in zone#" + num18.ToString() + ".");
              this.ai.AddLog("-------------------");
              this.ai.game.EventRelatedObj.Helper_RaiseOOB(this.poolPreferedOob[index13], this.RegimeId, num18, x, y, true, highestQualityLevel: simpleList28.Data5[0]);
              SimpleList reinfListForOob = DrawMod.TGame.EventRelatedObj.Helper_GetReinfListForOob(simpleList28.Id[0]);
              SimpleList sftypesForReinfList;
              if (simpleList28.Data5[0] == 5)
              {
                EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                SimpleList RL = reinfListForOob;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList35 = (SimpleList) null;
                 SimpleList local =  simpleList35;
                sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, false, false, false, true, regimeId, allowedSfTypeList: ( local));
              }
              else if (simpleList28.Data5[0] == 4)
              {
                EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                SimpleList RL = reinfListForOob;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList36 = (SimpleList) null;
                 SimpleList local =  simpleList36;
                sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, false, regimeId, allowedSfTypeList: ( local));
              }
              else if (simpleList28.Data5[0] == 3)
              {
                EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                SimpleList RL = reinfListForOob;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList37 = (SimpleList) null;
                 SimpleList local =  simpleList37;
                sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, false, false, regimeId, allowedSfTypeList: ( local));
              }
              else if (simpleList28.Data5[0] == 2)
              {
                EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                SimpleList RL = reinfListForOob;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList38 = (SimpleList) null;
                 SimpleList local =  simpleList38;
                sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, false, false, false, regimeId, allowedSfTypeList: ( local));
              }
              else
              {
                EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                SimpleList RL = reinfListForOob;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList39 = (SimpleList) null;
                 SimpleList local =  simpleList39;
                sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local));
              }
              SimpleList SL = DrawMod.TGame.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList);
              this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight( SL);
              this.data.UnitObj[this.shqUnitNr].items.list.removeWeight0orLower();
              SimpleList simpleList40 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList, true);
              if (num20 == 34)
                num20 = num20;
              let mut weight3: i32 = simpleList40.FindWeight(15);
              let mut weight4: i32 = simpleList40.FindWeight(1);
              if (weight4 > 0)
              {
                int[] itemNeed = this.itemNeed;
                int[] numArray = itemNeed;
                index15 = 1;
                let mut index19: i32 = index15;
                let mut num40: i32 = itemNeed[index15] + weight4;
                numArray[index19] = num40;
              }
              if (weight3 > 0)
              {
                int[] itemNeed = this.itemNeed;
                int[] numArray = itemNeed;
                index15 = 15;
                let mut index20: i32 = index15;
                let mut num41: i32 = itemNeed[index15] + weight3;
                numArray[index20] = num41;
              }
              this.newItems.RemoveWeight( simpleListArray[index13]);
              this.newItems.removeWeight0orLower();
              let mut counter15: i32 = simpleListArray[index13].Counter;
              for (let mut index21: i32 = 0; index21 <= counter15; index21 += 1)
              {
                let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index21], 4))) - simpleListArray[index13].Weight[index21];
                this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index21], simpleListArray[index13].Weight[index21]);
                if (0 > setValue)
                  setValue = 0;
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index21], 4, setValue, true);
              }
              flag1 = true;
            }
          }
          else if (index13 == 8)
          {
            num18 = this.poolItems[index13].FindWeight(8);
            num19 = this.poolItems[index13].FindWeight(2);
            let mut tweight: i32 = Math.Min(num18, num19);
            this.ai.AddLog("-------------------");
            DC2AIClass ai = this.ai;
            str2: String = this.poolName[index13];
            index15 = tweight * 10;
            str3: String = index15.ToString();
            s: String = str2 + " produced " + str3 + " ammo.";
            ai.AddLog(s);
            this.ai.AddLog("-------------------");
            this.data.UnitObj[this.shqUnitNr].items.list.AddWeight(10, tweight * 10);
            this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight(2, tweight);
            this.data.UnitObj[this.shqUnitNr].items.list.RemoveWeight(8, tweight);
            this.newItems.RemoveWeight( simpleListArray[index13]);
            this.poolItems[index13].RemoveWeight(8, tweight);
            this.poolItems[index13].RemoveWeight(2, tweight);
            let mut counter16: i32 = simpleListArray[index13].Counter;
            for (let mut index22: i32 = 0; index22 <= counter16; index22 += 1)
            {
              let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index22], 4))) - simpleListArray[index13].Weight[index22];
              if (0 > setValue)
                setValue = 0;
              this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index22], 4, setValue, true);
            }
            flag1 = true;
            flagArray[index13] = true;
          }
          else if (index13 == 9 & simpleList10.Data1[0] == 0)
          {
            SimpleList SL = simpleList5.Clone();
            SL.removeWeight0orLower();
            SL.ReverseSortHighSpeed();
            while (SL.Counter > 0)
              SL.RemoveNr(1);
            let mut num42: i32 = SL.Weight[0];
            SL.Weight[0] = 1;
            SimpleList simpleList41 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(SL);
            SimpleList simpleList42 = simpleList41.Clone();
            let mut multi: i32 = 1;
            let mut tvalue: i32 = 0;
            bool flag14 = true;
            while (flag14)
            {
              let mut counter17: i32 = simpleList41.Counter;
              for (let mut index23: i32 = 0; index23 <= counter17; index23 += 1)
              {
                num18 = this.newItems.FindWeight(simpleList41.Id[index23]);
                num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList41.Id[index23]);
                num19 = this.poolItems[index13].FindWeight(simpleList41.Id[index23]);
                if (num19 < simpleList41.Weight[index23])
                  flag14 = false;
              }
              if (flag14)
              {
                tvalue = multi;
                simpleList41.Clone();
              }
              if (multi < num42 & flag14)
              {
                multi += 1;
                simpleList41 = simpleList42.Clone();
                simpleList41.MultiplyWeight(multi);
              }
              else
                flag14 = false;
            }
            if (tvalue > 0)
            {
              this.ai.AddLog("-------------------");
              this.ai.AddLog(this.poolName[index13] + " executed raising of " + tvalue.ToString() + "x " + this.data.SFTypeObj[SL.Id[0]].Name + ".");
              this.ai.AddLog("-------------------");
              num19 = this.data.SFTypeObj[SL.Id[0]].Id;
              num18 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData2(2, this.RegimeId, 5, num19, 0)));
              let mut stringlistid: i32 = DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0);
              DrawMod.TGame.EventRelatedObj.ExecKey(stringlistid, "SHQNR", this.shqUnitNr.ToString(), "", "");
              DrawMod.TGame.EditObj.UDSClearInput();
              DrawMod.TGame.EditObj.UDSAddInput("SHQNR", this.shqUnitNr);
              DrawMod.TGame.EditObj.UDSAddInput("UNR", -1);
              DrawMod.TGame.EditObj.UDSAddInput("CHOICE", num18);
              DrawMod.TGame.EditObj.UDSAddInput("SLIDER1", tvalue);
              DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_ReplacementTroops_Commence(0);
              DrawMod.TGame.EventRelatedObj.IO_AddClear();
              simpleList5.RemoveNr(0);
              this.newItems.RemoveWeight( simpleListArray[index13]);
              let mut counter18: i32 = simpleListArray[index13].Counter;
              for (let mut index24: i32 = 0; index24 <= counter18; index24 += 1)
              {
                let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index24], 4))) - simpleListArray[index13].Weight[index24];
                this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index24], simpleListArray[index13].Weight[index24]);
                if (0 > setValue)
                  setValue = 0;
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index24], 4, setValue, true);
              }
              flag1 = true;
            }
          }
          else if (index13 == 9 & simpleList10.Data1[0] == 1)
          {
            SimpleList simpleList43 = upgradeableSfTypes;
            simpleList43.ReverseSortHighSpeed();
            SimpleList SL = SimpleList::new();
            SL.AddWeight(simpleList43.Data1[0], simpleList43.Weight[0]);
            let mut num43: i32 = SL.Weight[0];
            SL.Weight[0] = 1;
            SimpleList simpleList44 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(SL, subtractSFtype: simpleList43.Id[0]);
            SimpleList simpleList45 = simpleList44.Clone();
            let mut multi: i32 = 1;
            let mut val1: i32 = 0;
            bool flag15 = true;
            while (flag15)
            {
              let mut counter19: i32 = simpleList44.Counter;
              for (let mut index25: i32 = 0; index25 <= counter19; index25 += 1)
              {
                num18 = this.newItems.FindWeight(simpleList44.Id[index25]);
                num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList44.Id[index25]);
                num19 = this.poolItems[index13].FindWeight(simpleList44.Id[index25]);
                if (num19 < simpleList44.Weight[index25])
                  flag15 = false;
              }
              if (flag15)
              {
                val1 = multi;
                simpleList44.Clone();
              }
              if (multi < num43 & flag15)
              {
                multi += 1;
                simpleList44 = simpleList45.Clone();
                simpleList44.MultiplyWeight(multi);
              }
              else
                flag15 = false;
            }
            if (val1 > 0)
            {
              this.ai.AddLog("-------------------");
              this.ai.AddLog(this.poolName[index13] + " executed upgrading total of " + val1.ToString() + "x " + this.data.SFTypeObj[simpleList43.Id[0]].Name + " to " + this.data.SFTypeObj[SL.Id[0]].Name + ".");
              num19 = this.data.SFTypeObj[SL.Id[0]].Id;
              num18 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData2(2, this.RegimeId, 5, num19, 0)));
              DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0);
              SimpleList simpleList46 = SimpleList::new();
              for (let mut unitCounter2: i32 = this.data.UnitCounter; unitCounter2 >= 0; unitCounter2 += -1)
              {
                if (this.data.UnitObj[unitCounter2].Regime == this.data.Turn & this.data.UnitObj[unitCounter2].PreDef == -1)
                {
                  for (let mut sfCount2: i32 = this.data.UnitObj[unitCounter2].SFCount; sfCount2 >= 0; sfCount2 += -1)
                  {
                    let mut sf: i32 = this.data.UnitObj[unitCounter2].SFList[sfCount2];
                    if (val1 > 0 && this.data.SFObj[sf].Type == simpleList43.Id[0])
                    {
                      num18 = this.data.SFObj[sf].Xp * this.data.SFObj[sf].Rdn + this.data.SFObj[sf].Xp * 100;
                      simpleList46.Add(sf, num18, unitCounter2);
                    }
                  }
                }
              }
              simpleList46.ReverseSortHighSpeed();
              let mut counter20: i32 = simpleList46.Counter;
              for (let mut index26: i32 = 0; index26 <= counter20; index26 += 1)
              {
                let mut tvalue1: i32 = simpleList46.Id[index26];
                let mut tvalue2: i32 = simpleList46.Data1[index26];
                if (val1 > 0 && this.data.SFObj[tvalue1].Type == simpleList43.Id[0])
                {
                  let mut tvalue3: i32 = Math.Min(val1, this.data.SFObj[tvalue1].Qty);
                  val1 -= tvalue3;
                  this.ai.AddLog("-" + tvalue3.ToString() + "x in " + this.data.UnitObj[tvalue2].Name);
                  DrawMod.TGame.EditObj.UDSClearInput();
                  DrawMod.TGame.EditObj.UDSAddInput("SFNR", tvalue1);
                  DrawMod.TGame.EditObj.UDSAddInput("UNR", tvalue2);
                  DrawMod.TGame.EditObj.UDSAddInput("CHOICE", simpleList43.Data1[0]);
                  DrawMod.TGame.EditObj.UDSAddInput("QTY", tvalue3);
                  DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_Upgrade_Commence(0);
                  DrawMod.TGame.EventRelatedObj.IO_AddClear();
                  if (tvalue3 > 0)
                    upgradeableSfTypes = this.GetUpgradeableSFTypes();
                }
              }
              this.newItems.RemoveWeight( simpleListArray[index13]);
              let mut counter21: i32 = simpleListArray[index13].Counter;
              for (let mut index27: i32 = 0; index27 <= counter21; index27 += 1)
              {
                let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index27], 4))) - simpleListArray[index13].Weight[index27];
                this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index27], simpleListArray[index13].Weight[index27]);
                if (0 > setValue)
                  setValue = 0;
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index27], 4, setValue, true);
              }
              flag1 = true;
              this.ai.AddLog("-------------------");
            }
          }
          else if (index13 == 9 & simpleList10.Data1[0] == 2)
          {
            SimpleList replaceableSfTypes = this.GetReplaceableSFTypes();
            replaceableSfTypes.ReverseSortHighSpeed();
            SimpleList SL = SimpleList::new();
            SL.AddWeight(replaceableSfTypes.Data1[0], replaceableSfTypes.Weight[0]);
            let mut num44: i32 = SL.Weight[0];
            SL.Weight[0] = 1;
            SimpleList simpleList47 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(SL);
            SimpleList simpleList48 = simpleList47.Clone();
            let mut multi: i32 = 1;
            let mut val1: i32 = 0;
            bool flag16 = true;
            while (flag16)
            {
              let mut counter22: i32 = simpleList47.Counter;
              for (let mut index28: i32 = 0; index28 <= counter22; index28 += 1)
              {
                num18 = this.newItems.FindWeight(simpleList47.Id[index28]);
                num19 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList47.Id[index28]);
                num19 = this.poolItems[index13].FindWeight(simpleList47.Id[index28]);
                if (num19 < simpleList47.Weight[index28])
                  flag16 = false;
              }
              if (flag16)
              {
                val1 = multi;
                simpleList47.Clone();
              }
              if (multi < num44 & flag16)
              {
                multi += 1;
                simpleList47 = simpleList48.Clone();
                simpleList47.MultiplyWeight(multi);
              }
              else
                flag16 = false;
            }
            if (val1 > 0)
            {
              this.ai.AddLog("-------------------");
              this.ai.AddLog(this.poolName[index13] + " executed replacing total of " + val1.ToString() + "x " + this.data.SFTypeObj[replaceableSfTypes.Id[0]].Name + " to " + this.data.SFTypeObj[SL.Id[0]].Name + ".");
              num19 = this.data.SFTypeObj[SL.Id[0]].Id;
              num18 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData2(2, this.RegimeId, 5, num19, 0)));
              DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0);
              SimpleList simpleList49 = SimpleList::new();
              for (let mut unitCounter3: i32 = this.data.UnitCounter; unitCounter3 >= 0; unitCounter3 += -1)
              {
                if (this.data.UnitObj[unitCounter3].Regime == this.data.Turn & this.data.UnitObj[unitCounter3].PreDef == -1)
                {
                  for (let mut sfCount3: i32 = this.data.UnitObj[unitCounter3].SFCount; sfCount3 >= 0; sfCount3 += -1)
                  {
                    let mut sf: i32 = this.data.UnitObj[unitCounter3].SFList[sfCount3];
                    if (val1 > 0 && this.data.SFObj[sf].Type == replaceableSfTypes.Id[0] && DrawMod.TGame.HandyFunctionsObj.IsUnitInHQChain(unitCounter3, this.shqUnitNr))
                    {
                      num18 = this.data.SFObj[sf].Xp * this.data.SFObj[sf].Rdn + this.data.SFObj[sf].Xp * 100;
                      simpleList49.Add(sf, num18, unitCounter3);
                    }
                  }
                }
              }
              simpleList49.ReverseSortHighSpeed();
              let mut counter23: i32 = simpleList49.Counter;
              for (let mut index29: i32 = 0; index29 <= counter23; index29 += 1)
              {
                let mut tvalue4: i32 = simpleList49.Id[index29];
                let mut tvalue5: i32 = simpleList49.Data1[index29];
                if (DrawMod.TGame.Data.UnitObj[tvalue5].HQ > -1 && val1 > 0 && this.data.SFObj[tvalue4].Type == replaceableSfTypes.Id[0])
                {
                  let mut tvalue6: i32 = Math.Min(val1, this.data.SFObj[tvalue4].Qty);
                  val1 -= tvalue6;
                  this.ai.AddLog("-replaced " + tvalue6.ToString() + "x in " + this.data.UnitObj[tvalue5].Name);
                  DrawMod.TGame.EditObj.UDSClearInput();
                  DrawMod.TGame.EditObj.UDSAddInput("SFNR", tvalue4);
                  DrawMod.TGame.EditObj.UDSAddInput("UNR", tvalue5);
                  DrawMod.TGame.EditObj.UDSAddInput("CHOICE", replaceableSfTypes.Data1[0]);
                  DrawMod.TGame.EditObj.UDSAddInput("QTY", tvalue6);
                  DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_Replace_Commence(0);
                  DrawMod.TGame.EventRelatedObj.IO_AddClear();
                }
              }
              this.newItems.RemoveWeight( simpleListArray[index13]);
              let mut counter24: i32 = simpleListArray[index13].Counter;
              for (let mut index30: i32 = 0; index30 <= counter24; index30 += 1)
              {
                let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index30], 4))) - simpleListArray[index13].Weight[index30];
                this.poolItems[index13].RemoveWeight(simpleListArray[index13].Id[index30], simpleListArray[index13].Weight[index30]);
                if (0 > setValue)
                  setValue = 0;
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index13, 2, 1, 3, simpleListArray[index13].Id[index30], 4, setValue, true);
              }
              flag1 = true;
              this.ai.AddLog("-------------------");
            }
          }
        }
        int num45;
        num45 += 1;
        if (num45 < num17)
          flag1 = true;
      }
      if (flag2)
      {
        let mut counter: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          let mut idValue: i32 = this.zoneList.Id[index];
          num18 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "pop", 2)));
          num19 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "worker", 2)));
          let mut num46: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "freefolk", 2)));
          let mut num47: i32 =  Math.Round((double) num46 / 15.0);
          let mut setValue: i32 = num46 - num47;
          num19 += Math.Min( Math.Round((double) num18 / 10.0), 10);
          num19 += num47;
          this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue, 1, "worker", 2, num19);
          this.data.StringListObj[this.slotZoneKeys].SetData2(0, idValue, 1, "freefolk", 2, setValue);
        }
      }
      this.ai.WriteLog(str1);
    }

    pub void UpdatePoolItems(string logAddition)
    {
      str1: String = "9040_" + logAddition + "_UpdatePoolItems";
      this.ai.ClearLog();
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      this.ai.AddLog("");
      let mut length1: i32 = this.data.StringListObj[this.slotPoolItems].Length;
      for (let mut index1: i32 = 0; index1 <= length1; index1 += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index1, 0])) == this.shqHisId)
        {
          let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index1, 4]));
          let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index1, 5]));
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index1, 7]));
          int num4;
          if (num1 < 0)
          {
            string[,] data = this.data.StringListObj[this.slotPoolItems].Data;
            let mut index2: i32 = index1;
            num4 = 0;
            str2: String = num4.ToString();
            data[index2, 4] = str2;
          }
          string[,] data1 = this.data.StringListObj[this.slotPoolItems].Data;
          let mut index3: i32 = index1;
          num4 = 0;
          str3: String = num4.ToString();
          data1[index3, 5] = str3;
          this.data.StringListObj[this.slotPoolItems].Data[index1, 6] = num2.ToString();
          string[,] data2 = this.data.StringListObj[this.slotPoolItems].Data;
          let mut index4: i32 = index1;
          num4 = 0;
          str4: String = num4.ToString();
          data2[index4, 7] = str4;
          this.data.StringListObj[this.slotPoolItems].Data[index1, 8] = num3.ToString();
        }
      }
      let mut poolCounter1: i32 = this.poolCounter;
      int tweight1;
      for (let mut idValue2: i32 = 1; idValue2 <= poolCounter1; idValue2 += 1)
      {
        this.poolRequest[idValue2] = SimpleList::new();
        SimpleList simpleList1 = SimpleList::new();
        SimpleList simpleList2;
        if (this.poolPreferedAssetType[idValue2] > 0)
        {
          let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, this.poolPreferedAssetType[idValue2], 13)));
          let mut length2: i32 = this.data.StringListObj[this.slotConstructionCost].Length;
          for (let mut index: i32 = 0; index <= length2; index += 1)
          {
            if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 0])) == this.poolPreferedAssetType[idValue2])
            {
              let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 1]));
              let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 2]));
              let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotConstructionCost].Data[index, 3]));
              if (num6 == 2 & tid > 0 & num7 > 0)
                simpleList1.AddWeight(tid, num7 * num5);
            }
          }
        }
        else if (this.poolPreferedOob[idValue2] > 0 & this.poolPreferedToe[idValue2] > 0)
        {
          SimpleList reinfListForOob = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[idValue2], this.poolPreferedToe[idValue2]);
          bool flag1 = true;
          bool flag2 = true;
          bool flag3 = true;
          bool flag4 = true;
          if (this.poolPreferedQuality[idValue2] == 2)
          {
            flag2 = false;
            flag3 = false;
            flag4 = false;
          }
          if (this.poolPreferedQuality[idValue2] == 3)
          {
            flag3 = false;
            flag4 = false;
          }
          if (this.poolPreferedQuality[idValue2] == 4)
            flag4 = false;
          EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
          SimpleList RL = reinfListForOob;
          let mut num8: i32 = flag1 ? 1 : 0;
          let mut num9: i32 = flag2 ? 1 : 0;
          let mut num10: i32 = flag3 ? 1 : 0;
          let mut num11: i32 = flag4 ? 1 : 0;
          let mut regimeId: i32 = this.RegimeId;
          simpleList2 = (SimpleList) null;
           SimpleList local =  simpleList2;
          simpleList1 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, num8 != 0, num9 != 0, num10 != 0, num11 != 0, regimeId, allowedSfTypeList: ( local)));
          simpleList1.MultiplyWeight(4);
        }
        else if (this.poolPreferedOob[idValue2] > 0)
        {
          SimpleList reinfListForOob = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[idValue2]);
          bool flag5 = true;
          bool flag6 = true;
          bool flag7 = true;
          bool flag8 = true;
          if (this.poolPreferedQuality[idValue2] == 2)
          {
            flag6 = false;
            flag7 = false;
            flag8 = false;
          }
          if (this.poolPreferedQuality[idValue2] == 3)
          {
            flag7 = false;
            flag8 = false;
          }
          if (this.poolPreferedQuality[idValue2] == 4)
            flag8 = false;
          EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
          SimpleList RL = reinfListForOob;
          let mut num12: i32 = flag5 ? 1 : 0;
          let mut num13: i32 = flag6 ? 1 : 0;
          let mut num14: i32 = flag7 ? 1 : 0;
          let mut num15: i32 = flag8 ? 1 : 0;
          let mut regimeId: i32 = this.RegimeId;
          simpleList2 = (SimpleList) null;
           SimpleList local =  simpleList2;
          simpleList1 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, num12 != 0, num13 != 0, num14 != 0, num15 != 0, regimeId, allowedSfTypeList: ( local)));
        }
        else
        {
          switch (idValue2)
          {
            case 8:
              tweight1 = this.VAR_UnitsIdealAmmo * 2 - this.VAR_UnitsCurrentAmmo;
              if (tweight1 > 0)
              {
                tweight1 =  Math.Round((double) tweight1 / 10.0);
                simpleList1.AddWeight(2, tweight1);
                simpleList1.AddWeight(8, tweight1);
                break;
              }
              break;
            case 9:
              SimpleList simpleList3 = SimpleList::new();
              let mut unitCounter: i32 = this.data.UnitCounter;
              for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
              {
                if (this.data.UnitObj[unr].PreDef == -1 & this.data.UnitObj[unr].Regime == this.data.Turn && this.ai.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr))
                {
                  SimpleList simpleList4 = simpleList3;
                  simpleList2 = this.ai.game.EventRelatedObj.Helper_GetReinfListForUnit(unr);
                   SimpleList local =  simpleList2;
                  simpleList4.AddWeight( local);
                }
              }
              if (simpleList3.Counter > -1)
              {
                EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
                SimpleList RL = simpleList3;
                let mut regimeId: i32 = this.RegimeId;
                simpleList2 = (SimpleList) null;
                 SimpleList local =  simpleList2;
                simpleList1 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local)));
                break;
              }
              break;
          }
        }
        let mut counter: i32 = simpleList1.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, simpleList1.Id[index], 7, simpleList1.Weight[index], true);
          this.poolRequest[idValue2].AddWeight(simpleList1.Id[index], simpleList1.Weight[index]);
        }
      }
      SimpleList simpleList5 = SimpleList::new();
      SimpleList simpleList6 = this.data.UnitObj[this.shqUnitNr].items.list.Clone();
      let mut poolCounter2: i32 = this.poolCounter;
      for (let mut index: i32 = 1; index <= poolCounter2; index += 1)
      {
        if (this.poolRequest[index].Counter > -1)
          simpleList6.RemoveWeight( this.poolRequest[index]);
      }
      let mut counter1: i32 = simpleList6.Counter;
      for (let mut index: i32 = 0; index <= counter1; index += 1)
      {
        let mut tid: i32 = simpleList6.Id[index];
        if (tid == 2 | tid == 3 | tid == 4)
        {
          let mut weight: i32 = simpleList6.FindWeight(tid);
          let mut num: i32 = 0;
          if (tid == 2)
          {
            num = 5000;
            tweight1 = 2;
          }
          if (tid == 3)
          {
            num = 1500;
            tweight1 = 11;
          }
          if (tid == 4)
          {
            num = 400;
            tweight1 = 14;
          }
          if (weight > 0)
          {
            if ((double) this.itemNeed[tid] < (double) weight / 8.0 & weight >= num)
            {
              this.poolImportance[tweight1] = 0;
              this.ai.AddLog(this.poolName[tweight1] + " set to 0 importance due to excess storage ");
            }
            else if ((double) this.itemNeed[2] < (double) weight / 4.0 & weight >= num)
            {
              this.poolImportance[tweight1] =  Math.Round((double) this.poolImportance[tweight1] / 4.0);
              this.ai.AddLog(this.poolName[tweight1] + " divided by 4 importance due to excess storage ");
            }
          }
        }
      }
      let mut poolCounter3: i32 = this.poolCounter;
      int tweight2;
      for (let mut index5: i32 = 1; index5 <= poolCounter3; index5 += 1)
      {
        this.poolItems[index5] = SimpleList::new();
        this.ai.AddLog("");
        this.ai.AddLog(this.poolName[index5] + " items: ");
        let mut length3: i32 = this.data.StringListObj[this.slotPoolItems].Length;
        for (let mut index6: i32 = 0; index6 <= length3; index6 += 1)
        {
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index6, 0])) == this.shqHisId &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index6, 1])) == index5)
          {
            let mut num: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index6, 2]));
            let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index6, 3]));
            tweight2 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index6, 4]));
            let mut weight1: i32 = this.poolRequest[index5].FindWeight(tid);
            let mut weight2: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(tid);
            if (num == 1)
            {
              this.ai.AddLog("   -" + this.itemName[tid] + ": " + tweight2.ToString() + " (poolRequest: " + weight1.ToString() + ") .... SHQ Actual Reserv = " + weight2.ToString());
              this.poolItems[index5].AddWeight(tid, tweight2);
            }
          }
        }
      }
      this.ai.AddLog("");
      let mut itemcounter1: i32 = this.itemcounter;
      for (let mut index7: i32 = 1; index7 <= itemcounter1; index7 += 1)
      {
        SimpleList simpleList7 = SimpleList::new();
        let mut poolCounter4: i32 = this.poolCounter;
        for (let mut tid: i32 = 1; tid <= poolCounter4; tid += 1)
        {
          let mut counter2: i32 = this.poolRequest[tid].Counter;
          for (let mut index8: i32 = 0; index8 <= counter2; index8 += 1)
          {
            if (this.poolRequest[tid].Id[index8] == index7)
            {
              let mut num: i32 = this.poolRequest[tid].Weight[index8] - this.poolItems[tid].FindWeight(index7);
              if (num <= 0)
                num = 0;
              let mut tweight3: i32 = num * this.poolImportance[tid];
              simpleList7.AddWeight(tid, tweight3);
            }
          }
        }
        if (simpleList7.Counter > -1)
        {
          let mut num: i32 = 0;
          let mut counter3: i32 = simpleList7.Counter;
          for (let mut index9: i32 = 0; index9 <= counter3; index9 += 1)
            num += simpleList7.Weight[index9];
          let mut weight3: i32 = this.newItems.FindWeight(index7);
          if (weight3 > 0)
          {
            let mut poolCounter5: i32 = this.poolCounter;
            for (let mut index10: i32 = 1; index10 <= poolCounter5; index10 += 1)
            {
              let mut weight4: i32 = simpleList7.FindWeight(index10);
              if (weight4 > 0)
              {
                let mut setValue1: i32 =  Math.Round(Math.Floor((double) weight3 * ((double) weight4 / (double) num)));
                this.ai.AddLog(this.poolName[index10] + " received new items " + setValue1.ToString() + " " + this.itemName[index7] + ".");
                let mut setValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, index10, 2, 1, 3, index7, 4))) + setValue1;
                let mut weight5: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(index7);
                if (setValue2 > weight5)
                {
                  setValue2 = weight5;
                  this.ai.AddLog(this.poolName[index10] + " due to real SHQ item count... has been diminished to " + setValue2.ToString() + " " + this.itemName[index7] + ".");
                }
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index10, 2, 1, 3, index7, 4, setValue2, true);
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, index10, 2, 1, 3, index7, 6, setValue1, true);
              }
            }
          }
        }
      }
      SimpleList SL1 = SimpleList::new();
      let mut length4: i32 = this.data.StringListObj[this.slotAssets].Length;
      for (let mut index11: i32 = 0; index11 <= length4; index11 += 1)
      {
        let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index11, 0]));
        let mut num16: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index11, 1]));
        if (this.zoneList.FindNr(tid) > -1)
        {
          let mut num17: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index11, 7]));
          let mut num18: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index11, 12]));
          if (num17 > 0)
          {
            let mut num19: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, num16, 13)));
            let mut num20: i32 = num17 * 100 - num18;
            SimpleList assetConstruction = this.GetItemsForAssetConstruction(num16);
            let mut counter4: i32 = assetConstruction.Counter;
            for (let mut index12: i32 = 0; index12 <= counter4; index12 += 1)
              assetConstruction.Weight[index12] =  Math.Round(Math.Ceiling((double) (assetConstruction.Weight[index12] * num20) / 100.0));
            SL1.AddWeight( assetConstruction);
          }
        }
      }
      let mut itemcounter2: i32 = this.itemcounter;
      for (let mut idValue4: i32 = 1; idValue4 <= itemcounter2; idValue4 += 1)
      {
        let mut poolCounter6: i32 = this.poolCounter;
        for (let mut idValue2: i32 = 1; idValue2 <= poolCounter6; idValue2 += 1)
        {
          if (this.poolImportance[idValue2] < 20)
          {
            let mut num21: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, idValue4, 4)));
            let mut num22: i32 = num21;
            if (num22 > 0)
            {
              let mut num23: i32 = Math.Max(1,  Math.Round((double)  Math.Round((double) num22 * ((double) (20 - this.poolImportance[idValue2]) / 20.0)) / 3.0));
              if (num23 > 0)
              {
                this.ai.AddLog(this.poolName[idValue2] + " gave back " + num23.ToString() + " " + this.itemName[idValue4] + " due to LOW IMPORTANCE.");
                let mut setValue: i32 = num21 - num23;
                if (setValue < 0)
                  setValue = 0;
                this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, idValue4, 4, setValue, true);
              }
            }
          }
        }
      }
      let mut counter5: i32 = SL1.Counter;
      for (let mut index: i32 = 0; index <= counter5; index += 1)
      {
        if (index == 0)
        {
          this.ai.AddLog("");
          this.ai.AddLog("Construction Reserve:");
        }
        this.ai.AddLog(this.itemName[SL1.Id[index]] + ": " + SL1.Weight[index].ToString());
      }
      this.ai.AddLog("");
      SimpleList SL2 = SimpleList::new();
      let mut poolCounter7: i32 = this.poolCounter;
      for (let mut index13: i32 = 1; index13 <= poolCounter7; index13 += 1)
      {
        this.poolItems[index13] = SimpleList::new();
        this.ai.AddLog("");
        this.ai.AddLog(this.poolName[index13] + " items AFTER Adjustments: ");
        let mut length5: i32 = this.data.StringListObj[this.slotPoolItems].Length;
        for (let mut index14: i32 = 0; index14 <= length5; index14 += 1)
        {
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index14, 0])) == this.shqHisId &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index14, 1])) == index13)
          {
            let mut num: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index14, 2]));
            let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index14, 3]));
            tweight2 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index14, 4]));
            let mut weight6: i32 = this.poolRequest[index13].FindWeight(tid);
            let mut weight7: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(tid);
            if (num == 1)
            {
              this.ai.AddLog("   -" + this.itemName[tid] + ": " + tweight2.ToString() + " (poolRequest: " + weight6.ToString() + ") .... SHQ Actual Reserv = " + weight7.ToString());
              this.poolItems[index13].AddWeight(tid, tweight2);
              SL2.AddWeight(tid, tweight2);
            }
          }
        }
      }
      this.ai.AddLog("");
      let mut num24: i32 = 0;
      SimpleList simpleList8 = this.data.UnitObj[this.shqUnitNr].items.list.Clone();
      simpleList8.RemoveWeight( SL1);
      simpleList8.RemoveWeight( SL2);
      simpleList8.removeWeight0orLower();
      let mut num25: i32 = 0;
      let mut poolCounter8: i32 = this.poolCounter;
      int index15;
      for (index15 = 1; index15 <= poolCounter8; index15 += 1)
      {
        if (this.poolImportance[index15] > 0)
        {
          if (this.poolImportance[index15] > num25)
            num25 = this.poolImportance[index15];
          num24 += this.poolImportance[index15];
        }
      }
      if (this.data.Turn == 5)
        index15 = index15;
      let mut num26: i32 = 1;
      do
      {
        let mut itemcounter3: i32 = this.itemcounter;
        for (let mut index16: i32 = 1; index16 <= itemcounter3; index16 += 1)
        {
          let mut weight: i32 = simpleList8.FindWeight(index16);
          let mut num27: i32 = 0;
          if (index16 == 13)
            index15 = index15;
          let mut num28: i32 = 0;
          let mut num29: i32 = 0;
          let mut num30: i32 = 0;
          let mut poolCounter9: i32 = this.poolCounter;
          for (let mut idValue2: i32 = 1; idValue2 <= poolCounter9; idValue2 += 1)
          {
            num27 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index16, 4)));
            if (this.poolRequest[idValue2].FindWeight(index16) > 0)
            {
              let mut num31: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index16, 4)));
              let mut num32: i32 =  Math.Round((double) (this.poolImportance[idValue2] * (num31 + 1)) / (double) this.poolRequest[idValue2].FindWeight(index16));
              num28 += num32;
              if (this.poolImportance[idValue2] > 0)
              {
                num29 += this.poolImportance[idValue2];
                num30 += 1;
              }
            }
          }
          let mut num33: i32 = 0;
          if (num30 > 0)
            num33 =  Math.Round((double) num29 / (double) num30);
          if (num28 > 0)
          {
            let mut num34: i32 = weight;
            let mut num35: i32 = 0;
            SimpleList simpleList9 = SimpleList::new();
            let mut poolCounter10: i32 = this.poolCounter;
            for (let mut tid: i32 = 1; tid <= poolCounter10; tid += 1)
            {
              if (this.poolRequest[tid].FindWeight(index16) > 0)
              {
                simpleList9.Add(tid, this.poolImportance[tid]);
                num35 += this.poolImportance[tid];
              }
            }
            simpleList9.ReverseSort();
            let mut counter6: i32 = simpleList9.Counter;
            for (let mut index17: i32 = 0; index17 <= counter6; index17 += 1)
            {
              let mut idValue2: i32 = simpleList9.Id[index17];
              if (this.poolRequest[idValue2].FindWeight(index16) > 0 & this.poolImportance[idValue2] >= 10)
              {
                let mut num36: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index16, 4)));
                let mut num37: i32 =  Math.Round((double) (this.poolImportance[idValue2] * (num36 + 1)) / (double) this.poolRequest[idValue2].FindWeight(index16));
                let mut tweight4: i32 =  Math.Round((double) (num34 * num37) / (double) num35);
                if (tweight4 == 0 & num34 > 0)
                  tweight4 = 1;
                if (num36 + tweight4 > this.poolRequest[idValue2].FindWeight(index16) & !(idValue2 == 7 | idValue2 == 9))
                  tweight4 = this.poolRequest[idValue2].FindWeight(index16) - num36;
                else if (idValue2 == 7 & index16 != 9)
                {
                  if ((double) (num36 + tweight4) > (double) (this.poolRequest[idValue2].FindWeight(index16) * 2) + (double) weight / 5.0)
                    tweight4 =  Math.Round((double) (this.poolRequest[idValue2].FindWeight(index16) * 2) + (double) weight / 5.0) - num36;
                }
                else if (idValue2 == 9 & index16 != 9 && (double) (num36 + tweight4) > (double) (this.poolRequest[idValue2].FindWeight(index16) * 2) + (double) weight / 10.0)
                  tweight4 =  Math.Round((double) (this.poolRequest[idValue2].FindWeight(index16) * 2) + (double) weight / 10.0) - num36;
                if (tweight4 > num34)
                  tweight4 = num34;
                if (tweight4 > 0)
                {
                  this.ai.AddLog(this.poolName[idValue2] + " received from unassigned reserves " + tweight4.ToString() + " " + this.itemName[index16] + ".");
                  let mut setValue: i32 = num36 + tweight4;
                  num34 -= tweight4;
                  simpleList8.RemoveWeight(index16, tweight4);
                  if (0 > num34)
                    num34 = 0;
                  this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index16, 4, setValue, true);
                }
              }
            }
          }
        }
        num26 += 1;
      }
      while (num26 <= 5);
      let mut num38: i32 = 0;
      SimpleList simpleList10 = this.data.UnitObj[this.shqUnitNr].items.list.Clone();
      simpleList10.RemoveWeight( SL1);
      simpleList10.removeWeight0orLower();
      let mut itemcounter4: i32 = this.itemcounter;
      for (let mut index18: i32 = 1; index18 <= itemcounter4; index18 += 1)
      {
        let mut weight: i32 = simpleList10.FindWeight(index18);
        let mut num39: i32 = 0;
        let mut poolCounter11: i32 = this.poolCounter;
        for (let mut idValue2: i32 = 1; idValue2 <= poolCounter11; idValue2 += 1)
          num39 +=  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index18, 4)));
        if (num39 > weight)
        {
          let mut num40: i32 = num39 - weight;
          int[] numArray = new int[this.poolCounter + 1];
          let mut poolCounter12: i32 = this.poolCounter;
          for (let mut idValue2: i32 = 1; idValue2 <= poolCounter12; idValue2 += 1)
          {
            let mut num41: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index18, 4)));
            if (num41 > 0)
            {
              numArray[idValue2] =  Math.Round(((double) (num25 - this.poolImportance[idValue2]) + (double) num25 / 10.0) * (double) num41 / (double) num40);
              if (numArray[idValue2] > 0)
                num38 += numArray[idValue2];
            }
          }
          let mut poolCounter13: i32 = this.poolCounter;
          for (let mut idValue2: i32 = 1; idValue2 <= poolCounter13; idValue2 += 1)
          {
            if (this.poolRequest[idValue2].FindWeight(index18) > 0 && num25 != this.poolImportance[idValue2])
            {
              let mut num42: i32 =  Math.Round((double) (num40 * numArray[idValue2]) / (double) num38);
              let mut num43: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].GetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index18, 4)));
              if (num42 > 0)
              {
                if (num42 > num40)
                  num42 = num40;
                if (num42 > num43)
                  num42 = num43;
                if (num42 > 0)
                {
                  this.ai.AddLog(this.poolName[idValue2] + " lost " + num42.ToString() + " " + this.itemName[index18] + " due to ADMINSTRATIVE RECALCULATION.");
                  let mut setValue: i32 = num43 - num42;
                  num40 -= num42;
                  this.data.StringListObj[this.slotPoolItems].SetData4(0, this.shqHisId, 1, idValue2, 2, 1, 3, index18, 4, setValue, true);
                }
              }
            }
          }
        }
      }
      let mut poolCounter14: i32 = this.poolCounter;
      for (let mut index19: i32 = 1; index19 <= poolCounter14; index19 += 1)
      {
        this.poolItems[index19] = SimpleList::new();
        this.ai.AddLog("");
        this.ai.AddLog(this.poolName[index19] + " items: ");
        let mut length6: i32 = this.data.StringListObj[this.slotPoolItems].Length;
        for (let mut index20: i32 = 0; index20 <= length6; index20 += 1)
        {
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index20, 0])) == this.shqHisId &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index20, 1])) == index19)
          {
            let mut num44: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index20, 2]));
            let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index20, 3]));
            tweight2 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotPoolItems].Data[index20, 4]));
            let mut weight8: i32 = this.poolRequest[index19].FindWeight(tid);
            let mut weight9: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(tid);
            if (num44 == 1)
            {
              this.ai.AddLog("   -" + this.itemName[tid] + ": " + tweight2.ToString() + " (poolRequest: " + weight8.ToString() + ") .... SHQ Actual Reserv = " + weight9.ToString());
              this.poolItems[index19].AddWeight(tid, tweight2);
            }
          }
        }
      }
      this.ai.WriteLog(str1);
    }

    pub int GetWarSuccesPercentage()
    {
      let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 292, 0, 0));
      let mut num1: i32 = 100;
      let mut length: i32 = this.data.StringListObj[stringListById].Length;
      int num2;
      int num3;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[stringListById].Data[index, 1])) == this.data.Turn && Operators.CompareString(this.data.StringListObj[stringListById].Data[index, 0], "National", false) == 0 && Operators.CompareString(this.data.StringListObj[stringListById].Data[index, 2], "SizeHex", false) == 0)
        {
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].Data[index, 3]));
          let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[stringListById].Data[index, 4]));
          if (num4 == this.data.Round - 1)
            num1 = num5;
          if (num4 < this.data.Round - 1 & num4 >= this.data.Round - 10)
          {
            num2 += num5;
            num3 += 1;
          }
        }
      }
      let mut num6: i32 = num3 <= 0 ? 100 :  Math.Round((double) num2 / (double) num3);
      if (num1 < 1)
        return 100;
      let mut num7: i32 =  Math.Round((double) (100 * num6) / (double) num1);
      return 100;
    }

    pub void GetPoolImportance(string logAddition)
    {
      str1: String = "9030_" + logAddition + "_PoolsImportance";
      this.ai.ClearLog();
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      bool[] flagArray = new bool[100];
      let mut logCounter: i32 = this.data.UnitObj[this.shqUnitNr].LogCounter;
      for (let mut index: i32 = 0; index <= logCounter; index += 1)
      {
        if (this.data.UnitObj[this.shqUnitNr].LogData1[index] > 0 && this.data.UnitObj[this.shqUnitNr].LogType[index] == 301 & this.data.UnitObj[this.shqUnitNr].LogData3[index] > 0)
          flagArray[this.data.UnitObj[this.shqUnitNr].LogData1[index]] = true;
      }
      let mut poolCounter: i32 = this.poolCounter;
      for (let mut tid: i32 = 1; tid <= poolCounter; tid += 1)
      {
        SimpleList simpleList1 = SimpleList::new();
        int index1;
        if (tid == 1 & this.shqStage >= 1)
        {
          let mut num1: i32 = 0;
          let mut num2: i32 = (this.itemProduction[7] - this.itemNeed[7]) * 1;
          let mut num3: i32 = num2 >= 0 ? 50 : Math.Abs(num2) + 50;
          let mut num4: i32 = Math.Min( Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) / (double) num3),  Math.Round((double) this.data.Round / 3.0));
          if (this.data.Round < 10)
            num4 =  Math.Round((double) num4 / 2.0);
          if (this.data.Round < 20)
            num4 =  Math.Round((double) num4 / 2.0);
          if (num2 <  Math.Round((double) this.VAR_CurrentPop / 10.0))
            num1 += 200;
          if (num2 <  Math.Round((double) this.VAR_CurrentPop / 8.0))
            num1 += 100;
          if (num2 <  Math.Round((double) this.VAR_CurrentPop / 6.0))
            num1 += 50;
          if (num2 <  Math.Round((double) this.VAR_CurrentPop / 4.0))
            num1 += 25;
          if (num2 <  Math.Round((double) this.VAR_CurrentPop / 2.0))
            num1 += 10;
          if ((double) (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) + num2) <= Math.Min(0.2 * (double) (this.VAR_CurrentWorker + this.VAR_CurrentSoldier + this.VAR_CurrentRecruits), 25.0))
            num1 += 1600;
          if ((double) (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) + num2) <= Math.Min(0.5 * (double) (this.VAR_CurrentWorker + this.VAR_CurrentSoldier + this.VAR_CurrentRecruits), 75.0))
            num1 += 1200;
          if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) + num2 <= Math.Min(1 * (this.VAR_CurrentWorker + this.VAR_CurrentSoldier + this.VAR_CurrentRecruits), 100))
            num1 += 600;
          if ((double) (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) + num2) <= Math.Min(1.33 * (double) (this.VAR_CurrentWorker + this.VAR_CurrentSoldier + this.VAR_CurrentRecruits), 150.0))
            num1 += 200;
          if ((double) (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) + num2) <= Math.Min(1.66 * (double) (this.VAR_CurrentWorker + this.VAR_CurrentSoldier + this.VAR_CurrentRecruits), 200.0))
            num1 += 100;
          if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(7) + num2 <= Math.Min(2 * (this.VAR_CurrentWorker + this.VAR_CurrentSoldier + this.VAR_CurrentRecruits), 250))
            num1 += 50;
          if (this.itemProduction[7] <  Math.Round((double) this.itemNeed[7] * 1.5) & num4 < 5)
            num1 += 30;
          if (this.itemProduction[7] <=  Math.Round((double) this.itemNeed[7] * 1.3) & num4 < 8)
            num1 += 70;
          if (this.itemProduction[7] <=  Math.Round((double) this.itemNeed[7] * 1.1) & num4 < 11)
            num1 += 200;
          if (this.itemProduction[7] <= this.itemNeed[7] * 1 & num4 < 14)
            num1 += 400;
          if (this.itemProduction[7] <  Math.Round((double) this.itemNeed[7] * 0.75) & num4 < 20)
            num1 += 500;
          if (this.itemProduction[7] <  Math.Round((double) this.itemNeed[7] * 0.5) & num4 < 40)
            num1 += 700;
          if (this.itemProduction[7] <= this.itemNeed[7] + 100 & num4 < 14)
            num1 += 100;
          if (this.itemProduction[7] <= this.itemNeed[7] + 75 & num4 < 14)
            num1 += 200;
          if (this.itemProduction[7] <= this.itemNeed[7] + 50 & num4 < 14)
            num1 += 400;
          if (this.itemProduction[7] <= this.itemNeed[7] + 25 & num4 < 14)
            num1 += 600;
          if (this.data.Turn == 6)
            index1 = index1;
          if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double) this.itemProduction[7])
            num1 += 1000;
          else if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double)  Math.Round(0.9 * (double) this.itemProduction[7]))
            num1 += 750;
          else if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double)  Math.Round(0.8 * (double) this.itemProduction[7]))
            num1 += 500;
          else if ((double) this.itemNeed[7] > (double) this.itemQty[7] / 10.0 + (double)  Math.Round(0.7 * (double) this.itemProduction[7]))
            num1 += 250;
          let mut tweight: i32 =  Math.Round((double) (num1 * this.strategicAi.pathEco_American) / 33.0);
          if (flagArray[7])
            tweight = 0;
          simpleList1.Add(1, tweight);
        }
        if (tid == 2 & this.shqStage >= 2)
        {
          let mut num5: i32 = 0;
          if (this.itemProduction[2] < 160)
            num5 += 50;
          if (this.itemProduction[2] < 120)
            num5 += 100;
          if (this.itemProduction[2] < 80)
            num5 += 150;
          if (this.itemProduction[2] < 40)
            num5 += 200;
          if (this.itemProduction[2] <  Math.Round((double) this.itemProduction[7] / 4.0))
            num5 += 100;
          if (this.itemProduction[2] < 4 * this.itemProduction[8])
            num5 += 100;
          if ((double) this.itemProduction[2] < 2.5 * (double) this.itemProduction[8])
            num5 += 200;
          if ((double) this.itemProduction[2] < 0.75 * (double) this.itemProduction[8])
            num5 += 300;
          if (this.itemProduction[2] < 50 && !this.IsFamilyAssetTypePresentInZoneList(205, true))
            num5 += 200;
          if (this.shqStage <= 2)
          {
            if (this.itemProduction[2] < 200)
              num5 = (num5 + 50) * 2;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier & this.VAR_IdealSoldier > 0)
              num5 =  Math.Round((double) num5 * 0.8 * (double) this.VAR_CurrentSoldier / (double) this.VAR_IdealSoldier) +  Math.Round((double) num5 * 0.2);
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier & this.VAR_IdealSoldier > 0)
              num5 =  Math.Round((double) num5 * 0.5 * (double) this.VAR_CurrentSoldier / (double) this.VAR_IdealSoldier) +  Math.Round((double) num5 * 0.5);
          }
          else if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier & this.VAR_IdealSoldier > 0)
            num5 =  Math.Round((double) num5 * 0.5 * (double) this.VAR_CurrentSoldier / (double) this.VAR_IdealSoldier) +  Math.Round((double) num5 * 0.5);
          let mut num6: i32 =  Math.Round((double) (num5 * this.strategicAi.pathEco_American) / 33.0);
          let mut tweight: i32 =  Math.Round((double) num6 * 0.5) +  Math.Round((double) num6 * 0.5 * Math.Min(3.0, (double) this.itemNeed[2] / (double) Math.Max(1, this.itemProduction[2])));
          simpleList1.Add(2, tweight);
        }
        if (tid == 5 & this.shqStage >= 2)
        {
          let mut num7: i32 = 0;
          let mut num8: i32 =  Math.Round((double) (this.itemProduction[2] + this.itemProduction[8]) / 2.0);
          if ((double) this.itemRegimeKeyProdList.FindWeightById("bp") < (double) num8 / 10.0)
            num7 += 400;
          if ((double) this.itemRegimeKeyProdList.FindWeightById("bp") < (double) num8 / 5.0)
            num7 += 200;
          if ((double) this.itemRegimeKeyProdList.FindWeightById("bp") < (double) num8 / 2.0)
            num7 += 50;
          let mut tweight: i32 =  Math.Round((double) (num7 * this.strategicAi.pathEco_German) / 33.0);
          simpleList1.Add(5, tweight);
        }
        if (tid == 3 & this.shqStage >= 2)
        {
          let mut num: i32 = 0;
          if (this.itemProduction[8] < 50)
            num += 300;
          if (this.itemProduction[8] < this.itemRegimeKeyProdList.FindWeightById("bp"))
            num += 100;
          if (this.itemProduction[8] < this.itemProduction[2])
            num += 100;
          if (!this.IsFamilyAssetTypePresentInZoneList(401, true))
            num += 500;
          let mut tweight: i32 =  Math.Round((double) (( Math.Round((double) num * 0.5) +  Math.Round((double) num * 0.5 * Math.Min(3.0, (double) this.itemNeed[8] / (double) Math.Max(1, this.itemProduction[8])))) * this.strategicAi.pathEco_American) / 33.0);
          if (this.poolOrigImportance[1] > 2000)
            tweight =  Math.Round((double) tweight / 20.0);
          else if (this.poolOrigImportance[1] > 1000)
            tweight =  Math.Round((double) tweight / 6.0);
          else if (this.poolOrigImportance[1] > 500)
            tweight =  Math.Round((double) tweight / 2.0);
          if (this.shqStage <= 2)
          {
            if (this.itemProduction[2] < 150)
              tweight =  Math.Round((double) tweight / 10.0);
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier & this.VAR_IdealSoldier > 0)
              tweight =  Math.Round((double) tweight * 0.8 * (double) this.VAR_CurrentSoldier / (double) this.VAR_IdealSoldier) +  Math.Round((double) tweight * 0.2);
          }
          else if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier & this.VAR_IdealSoldier > 0)
            tweight =  Math.Round((double) tweight * 0.5 * (double) this.VAR_CurrentSoldier / (double) this.VAR_IdealSoldier) +  Math.Round((double) tweight * 0.5);
          if (flagArray[8])
            tweight = 0;
          simpleList1.Add(3, tweight);
        }
        if (tid == 4 & this.shqStage >= 2)
        {
          let mut num9: i32 = 0;
          if (this.itemProduction[1] <  Math.Round((double) this.itemNeed[1] * 1.5))
            num9 += 25;
          if (this.itemProduction[1] < this.itemNeed[1] * 1)
            num9 += 50;
          if (this.itemProduction[1] <  Math.Round((double) this.itemNeed[1] * 0.5))
            num9 += 100;
          let mut num10: i32 = this.itemProduction[1] - this.itemNeed[1] +  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(1) / 8.0);
          if ((double) num10 < (double) this.VAR_UnitsIdealFuel / 10.0)
            num9 += 800;
          else if ((double) num10 < (double) this.VAR_UnitsIdealFuel / 7.0)
            num9 += 600;
          else if ((double) num10 < (double) this.VAR_UnitsIdealFuel / 4.0)
            num9 += 400;
          else if ((double) num10 < (double) this.VAR_UnitsIdealFuel / 3.0)
            num9 += 200;
          else if ((double) num10 < (double) this.VAR_UnitsIdealFuel / 2.0)
            num9 += 100;
          else if (num10 < this.VAR_UnitsIdealFuel)
            num9 += 50;
          if ((double) num10 < (double) (this.VAR_UnitsIdealFuel + this.VAR_UnitsFutureFuel) / 10.0)
            num9 += 800;
          else if ((double) num10 < (double) (this.VAR_UnitsIdealFuel + this.VAR_UnitsFutureFuel) / 7.0)
            num9 += 600;
          else if ((double) num10 < (double) (this.VAR_UnitsIdealFuel + this.VAR_UnitsFutureFuel) / 4.0)
            num9 += 400;
          else if ((double) num10 < (double) (this.VAR_UnitsIdealFuel + this.VAR_UnitsFutureFuel) / 3.0)
            num9 += 200;
          else if ((double) num10 < (double) (this.VAR_UnitsIdealFuel + this.VAR_UnitsFutureFuel) / 2.0)
            num9 += 100;
          else if (num10 < this.VAR_UnitsIdealFuel + this.VAR_UnitsFutureFuel)
            num9 += 50;
          if ((double) this.itemNeed[1] + (double) this.VAR_UnitsFutureFuel / 2.0 < 30.0)
            num9 =  Math.Round((double) num9 / 10.0);
          else if ((double) this.itemNeed[1] + (double) this.VAR_UnitsFutureFuel / 2.0 < 60.0)
            num9 =  Math.Round((double) num9 / 7.0);
          else if ((double) this.itemNeed[1] + (double) this.VAR_UnitsFutureFuel / 2.0 < 120.0)
            num9 =  Math.Round((double) num9 / 4.0);
          else if ((double) this.itemNeed[1] + (double) this.VAR_UnitsFutureFuel / 2.0 < 240.0)
            num9 =  Math.Round((double) num9 / 2.0);
          if (this.shqStage <= 2)
          {
            if (this.itemProduction[8] < 40)
              num9 =  Math.Round((double) num9 / 10.0);
            if (this.itemProduction[2] < 150)
              num9 =  Math.Round((double) num9 / 10.0);
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier & this.VAR_IdealSoldier > 0)
              num9 =  Math.Round((double) num9 * 0.8 * (double) this.VAR_CurrentSoldier / (double) this.VAR_IdealSoldier) +  Math.Round((double) num9 * 0.2);
          }
          let mut tweight: i32 =  Math.Round((double) ( Math.Round((double) (num9 * this.strategicAi.pathEco_American) / 33.0) * this.strategicAi.pathWar_Offensive) / 33.0);
          if (flagArray[1])
            tweight = 0;
          simpleList1.Add(4, tweight);
        }
        if (tid == 6 & this.shqStage >= 1)
        {
          let mut tweight: i32 = 0;
          if (this.itemProduction[5] < 600)
            tweight += 50;
          if (this.itemProduction[5] < 400)
            tweight += 200;
          if (this.itemProduction[5] < 200)
            tweight += 600;
          if (this.itemProduction[5] <  Math.Round((double) this.itemNeed[5] * 1.15))
            tweight += 50;
          if (this.itemProduction[5] < this.itemNeed[5] * 1)
            tweight += 200;
          if (this.itemProduction[5] <  Math.Round((double) this.itemNeed[5] * 0.5))
            tweight += 600;
          if (this.poolOrigImportance[1] > 3000)
          {
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 2.0 < (double) (this.itemNeed[5] + 200))
              tweight += 600;
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 2.0 < (double) (this.itemNeed[5] + 400))
              tweight += 400;
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 2.0 < (double) (this.itemNeed[5] + 600))
              tweight += 200;
          }
          if (this.poolOrigImportance[1] > 2000)
          {
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 1.0 < (double) (this.itemNeed[5] + 200))
              tweight += 500;
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 1.0 < (double) (this.itemNeed[5] + 400))
              tweight += 400;
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 1.0 < (double) (this.itemNeed[5] + 600))
              tweight += 300;
          }
          if (this.poolOrigImportance[1] > 1000)
          {
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 0.5 < (double) (this.itemNeed[5] + 200))
              tweight += 250;
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 0.5 < (double) (this.itemNeed[5] + 400))
              tweight += 200;
            if ((double) this.itemProduction[5] + (double) this.newItems.FindWeight(5) / 0.5 < (double) (this.itemNeed[5] + 600))
              tweight += 150;
          }
          if (this.itemNeed[5] - this.itemProduction[5] > 3200)
            tweight *= 6;
          else if (this.itemNeed[5] - this.itemProduction[5] > 1600)
            tweight *= 5;
          else if (this.itemNeed[5] - this.itemProduction[5] > 800)
            tweight *= 4;
          else if (this.itemNeed[5] - this.itemProduction[5] > 400)
            tweight *= 3;
          else if (this.itemNeed[5] - this.itemProduction[5] > 200)
            tweight *= 2;
          simpleList1.Add(6, tweight);
          if (flagArray[5])
            tweight = 0;
          let mut num: i32 =  Math.Round((double) (tweight * this.strategicAi.pathEco_American) / 33.0);
        }
        int num11;
        if (tid == 6 & this.shqStage >= 1 & !flagArray[5] && simpleList1.FindWeight(6) > 999)
        {
          let mut counter: i32 = this.zoneList.Counter;
          for (index1 = 0; index1 <= counter; index1 += 1)
          {
            let mut num12: i32 = this.zoneList.Id[index1];
            let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
            for (let mut index2: i32 = 0; index2 <= length; index2 += 1)
            {
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 0])) == num12)
              {
                let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 8]));
                let mut idValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 1]));
                let mut assetId: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 9]));
                if (idValue1 >= 781 & idValue1 <= 783 & num13 < 1 && !DrawMod.TGame.EventRelatedObj.Helper_IsAssetUnderConstructionOrUpgrade(assetId))
                {
                  let mut idValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 25)));
                  num11 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 11)));
                  this.data.StringListObj[this.slotAssets].Data[index2, 1] = idValue2.ToString();
                  this.data.StringListObj[this.slotAssets].Data[index2, 5] = num11.ToString();
                }
              }
            }
          }
        }
        if (tid == 4 & this.shqStage >= 2 & !flagArray[1] && simpleList1.FindWeight(4) > 999)
        {
          let mut counter: i32 = this.zoneList.Counter;
          for (index1 = 0; index1 <= counter; index1 += 1)
          {
            let mut num14: i32 = this.zoneList.Id[index1];
            let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
            for (let mut index3: i32 = 0; index3 <= length; index3 += 1)
            {
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index3, 0])) == num14)
              {
                let mut num15: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index3, 8]));
                let mut idValue3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index3, 1]));
                let mut assetId: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index3, 9]));
                if (idValue3 >= 771 & idValue3 <= 773 & num15 < 1 && !DrawMod.TGame.EventRelatedObj.Helper_IsAssetUnderConstructionOrUpgrade(assetId))
                {
                  let mut idValue4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue3, 25)));
                  num11 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue4, 11)));
                  this.data.StringListObj[this.slotAssets].Data[index3, 1] = idValue4.ToString();
                  this.data.StringListObj[this.slotAssets].Data[index3, 5] = num11.ToString();
                }
              }
            }
          }
        }
        if (tid == 2 & this.shqStage >= 3 && simpleList1.FindWeight(2) > 999)
        {
          let mut counter: i32 = this.zoneList.Counter;
          for (index1 = 0; index1 <= counter; index1 += 1)
          {
            let mut num16: i32 = this.zoneList.Id[index1];
            let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
            for (let mut index4: i32 = 0; index4 <= length; index4 += 1)
            {
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index4, 0])) == num16)
              {
                let mut idValue5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index4, 1]));
                let mut num17: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index4, 8]));
                let mut assetId: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index4, 9]));
                if (num17 < 1 && idValue5 == 102 | idValue5 == 1022 | idValue5 == 1023 && !DrawMod.TGame.EventRelatedObj.Helper_IsAssetUnderConstructionOrUpgrade(assetId))
                {
                  let mut idValue6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue5, 25)));
                  num11 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue6, 11)));
                  this.data.StringListObj[this.slotAssets].Data[index4, 1] = idValue6.ToString();
                  this.data.StringListObj[this.slotAssets].Data[index4, 5] = num11.ToString();
                }
              }
            }
          }
        }
        if (tid == 7)
        {
          let mut tweight: i32 = 0;
          if (this.poolPreferedOob[tid] > 0)
          {
            SimpleList simpleList2 = this.poolPreferedToe[tid] <= 0 ? this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[tid]) : this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(this.poolPreferedOob[tid], this.poolPreferedToe[tid]);
            EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
            SimpleList RL = simpleList2;
            let mut regimeId: i32 = this.RegimeId;
            SimpleList simpleList3 = (SimpleList) null;
             SimpleList local =  simpleList3;
            let mut num18: i32 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: ( local))).FindWeight(9);
            if (num18 < 33)
              num18 = 33;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 0.1)
              tweight += 10;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 0.5)
              tweight += 20;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 0.7)
              tweight += 30;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 0.9)
              tweight += 40;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 1.1)
              tweight += 50;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 1.3)
              tweight += 60;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 1.5)
              tweight += 70;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 1.8)
              tweight += 80;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 2.2)
              tweight += 90;
            if ((double) this.VAR_CurrentRecruits > (double) num18 * 2.7)
              tweight += 100;
            if (this.VAR_CurrentRecruits > num18 * 4)
              tweight += 120;
            if (this.VAR_CurrentRecruits > num18 * 7)
              tweight += 150;
            if (this.VAR_CurrentRecruits > num18 * 12)
              tweight += 190;
            if (this.VAR_CurrentRecruits > num18 * 20)
              tweight += 240;
            if (this.VAR_CurrentSoldier > 1 * this.VAR_IdealSoldier)
              tweight =  Math.Round((double) tweight / 12.0);
            else if ((double) this.VAR_CurrentSoldier > 0.8 * (double) this.VAR_IdealSoldier)
              tweight =  Math.Round((double) tweight / 8.0);
            else if ((double) this.VAR_CurrentSoldier > 0.6 * (double) this.VAR_IdealSoldier)
              tweight =  Math.Round((double) tweight / 4.0);
            else if ((double) this.VAR_CurrentSoldier > 0.4 * (double) this.VAR_IdealSoldier)
              tweight =  Math.Round((double) tweight / 2.0);
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier)
              tweight += 25;
            if ((double) this.VAR_CurrentSoldier < 0.8 * (double) this.VAR_IdealSoldier)
              tweight += 50;
            if ((double) this.VAR_CurrentSoldier < 0.6 * (double) this.VAR_IdealSoldier)
              tweight += 100;
            if ((double) this.VAR_CurrentSoldier < 0.4 * (double) this.VAR_IdealSoldier)
              tweight += 150;
            if ((double) this.VAR_CurrentSoldier < 0.3 * (double) this.VAR_IdealSoldier)
              tweight += 200;
            if ((double) this.VAR_CurrentSoldier < 0.2 * (double) this.VAR_IdealSoldier)
              tweight += 300;
            if ((double) this.VAR_CurrentSoldier < 0.1 * (double) this.VAR_IdealSoldier)
              tweight += 500;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier)
              tweight += 25;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier - 20)
              tweight += 50;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier - 60)
              tweight += 100;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier - 120)
              tweight += 150;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier - 200)
              tweight += 200;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier - 300)
              tweight += 300;
            if (this.VAR_CurrentSoldier < this.VAR_IdealSoldier - 450)
              tweight += 500;
            if ((double) this.VAR_UnitsPerFrontHex < 0.05)
              tweight = tweight * 2 + 1000;
            else if ((double) this.VAR_UnitsPerFrontHex < 0.1)
              tweight =  Math.Round((double) tweight * 1.66) + 500;
            else if ((double) this.VAR_UnitsPerFrontHex < 0.2)
              tweight =  Math.Round((double) tweight * 1.4) + 200;
            else if ((double) this.VAR_UnitsPerFrontHex < 0.3)
              tweight =  Math.Round((double) tweight * 1.2) + 100;
            if (this.poolOrigImportance[1] > 2500 | this.poolOrigImportance[6] > 2500)
              tweight =  Math.Round((double) tweight / 6.0);
            else if (this.poolOrigImportance[1] > 900 | this.poolOrigImportance[6] > 900)
              tweight =  Math.Round((double) tweight / 3.0);
            else if (this.poolOrigImportance[1] > 500 | this.poolImportance[6] > 500)
              tweight =  Math.Round((double) tweight * 0.66);
            else if (this.poolOrigImportance[1] > 200 | this.poolOrigImportance[6] > 200)
              tweight =  Math.Round((double) tweight * 0.8);
            let mut num19: i32 =  Math.Round((double) ( Math.Round((double) tweight * Math.Min(1.0, (double) this.VAR_IdealSoldier / (double) Math.Max(1, this.VAR_CurrentSoldier))) * this.strategicAi.pathEco_Soviet) / 33.0);
            if (this.VAR_CurrentSoldier + 2 >= this.VAR_IdealSoldier)
              num19 =  Math.Round((double) num19 * 0.1);
            else if (this.VAR_CurrentSoldier + 8 >= this.VAR_IdealSoldier)
              num19 =  Math.Round((double) num19 * 0.2);
            else if (this.VAR_CurrentSoldier + 15 >= this.VAR_IdealSoldier)
              num19 =  Math.Round((double) num19 * 0.3);
            let mut num20: i32 = this.GetWarSuccesPercentage();
            if (num20 < 100)
              num20 =  Math.Round((double) (100 - num20) / 3.0) + num20;
            if (num20 > 100)
              num20 = 100 +  Math.Round((double) (num20 - 100) / 2.0);
            if (num20 > 200)
              num20 = 200 +  Math.Round((double) (num20 - 200) / 3.0);
            if (num20 > 300)
              num20 = 300;
            tweight =  Math.Round((double) (num19 * 100) / (double) num20);
          }
          let mut num21: i32 = 0;
          let mut num22: i32 = this.itemProduction[1] - this.itemNeed[1] +  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(1) / 8.0);
          if ((double) num22 < (double) this.VAR_UnitsIdealFuel / 10.0)
            num21 += Math.Min(1600, this.itemNeed[1]);
          else if ((double) num22 < (double) this.VAR_UnitsIdealFuel / 7.0)
            num21 += Math.Min(800, this.itemNeed[1]);
          else if ((double) num22 < (double) this.VAR_UnitsIdealFuel / 4.0)
            num21 += Math.Min(400, this.itemNeed[1]);
          else if ((double) num22 < (double) this.VAR_UnitsIdealFuel / 3.0)
            num21 += Math.Min(200, this.itemNeed[1]);
          else if ((double) num22 < (double) this.VAR_UnitsIdealFuel / 2.0)
            num21 += Math.Min(100, this.itemNeed[1]);
          else if (num22 < this.VAR_UnitsIdealFuel)
            num21 += Math.Min(50, this.itemNeed[1]);
          let mut num23: i32 = num21 > 300 & this.shqStage >= 2 ? 1 : 0;
          simpleList1.Add(7, tweight);
        }
        if (tid == 9)
        {
          let mut num24: i32 = 50;
          if (this.VAR_CurrentSoldier > 0)
            num24 +=  Math.Round(200.0 * Math.Min(1.0, (double) this.VAR_SoldierMissing / (double) this.VAR_CurrentSoldier));
          let mut num25: i32 = 0;
          if (this.VAR_SoldierMissing > 0)
            num24 += 25;
          if ((double) this.VAR_SoldierMissing > (double) this.VAR_CurrentSoldier * 0.05)
          {
            num24 += 50;
            num25 += 5;
          }
          if ((double) this.VAR_SoldierMissing > (double) this.VAR_CurrentSoldier * 0.1)
          {
            num24 += 100;
            num25 += 8;
          }
          if ((double) this.VAR_SoldierMissing > (double) this.VAR_CurrentSoldier * 0.15)
          {
            num24 += 200;
            num25 += 12;
          }
          if ((double) this.VAR_SoldierMissing > (double) this.VAR_CurrentSoldier * 0.25)
          {
            num24 += 500;
            num25 += 15;
          }
          if ((double) this.VAR_SoldierMissing > (double) this.VAR_CurrentSoldier * 0.4)
          {
            num24 += 1000;
            num25 += 18;
          }
          if ((double) this.VAR_SoldierMissing > (double) this.VAR_CurrentSoldier * 0.6)
          {
            num24 += 2500;
            num25 += 21;
          }
          if ((double) this.VAR_CurrentSoldier > (double) this.VAR_IdealSoldier * 1.4)
            num24 =  Math.Round((double) num24 / 10.0);
          if ((double) this.VAR_CurrentSoldier > (double) this.VAR_IdealSoldier * 1.2)
            num24 =  Math.Round((double) num24 / 10.0);
          if ((double) this.VAR_CurrentSoldier > (double) this.VAR_IdealSoldier * 1.1)
            num24 =  Math.Round((double) num24 / 10.0);
          if (this.VAR_CurrentSoldier > this.VAR_IdealSoldier * 1)
            num24 =  Math.Round((double) num24 / 10.0);
          let mut num26: i32 =  Math.Round((double) (num24 * this.strategicAi.pathEco_Soviet) / 33.0);
          let mut num27: i32 = this.GetWarSuccesPercentage();
          if (num27 < 100)
            num27 =  Math.Round((double) (100 - num27) / 3.0) + num27;
          if (num27 > 100)
            num27 = 100 +  Math.Round((double) (num27 - 100) / 2.0);
          if (num27 > 200)
            num27 = 200 +  Math.Round((double) (num27 - 200) / 3.0);
          if (num27 > 300)
            num27 = 300;
          let mut tweight: i32 =  Math.Round((double) (num26 * 100) / (double) num27);
          if (num25 > 66)
            num25 = 66;
          if (num25 > 0)
          {
            let mut num28: i32 =  Math.Round((double) (this.poolImportance[7] * num25) / 100.0);
            tweight += num28;
            int[] poolImportance = this.poolImportance;
            int[] numArray = poolImportance;
            let mut index5: i32 = 7;
            let mut index6: i32 = index5;
            let mut num29: i32 = poolImportance[index5] - num28;
            numArray[index6] = num29;
          }
          simpleList1.Add(9, tweight);
        }
        if (tid == 8)
        {
          let mut tweight: i32 = 5;
          let mut weight: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(10);
          if (weight < this.VAR_UnitsIdealAmmo * 6)
            tweight += 5;
          if (weight < this.VAR_UnitsIdealAmmo * 3)
            tweight += 10;
          if (weight < this.VAR_UnitsIdealAmmo * 2)
            tweight += 20;
          if (weight < this.VAR_UnitsIdealAmmo * 1)
            tweight += 50;
          if ((double) weight < (double) this.VAR_UnitsIdealAmmo * 0.75)
            tweight += 100;
          if ((double) weight < (double) this.VAR_UnitsIdealAmmo * 0.5)
            tweight += 300;
          if ((double) weight < (double) this.VAR_UnitsIdealAmmo * 0.25)
            tweight += 500;
          if ((double) weight < (double) this.VAR_UnitsIdealAmmo * 0.1)
            tweight += 1200;
          simpleList1.Add(8, tweight);
        }
        if (tid == 10 & (this.shqStage >= 3 | (double) this.itemProduction[15] * 0.66 < (double) this.itemNeed[15]))
        {
          let mut num30: i32 = 5;
          if (this.itemProduction[15] < 10)
            num30 += 50;
          if (this.itemNeed[15] > this.itemProduction[15])
            num30 += 100;
          let mut weight: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(15);
          if (weight < this.VAR_UnitsIdealEnergy * 2)
            num30 += 25;
          if ((double) weight < (double) this.VAR_UnitsIdealEnergy * 1.5)
            num30 += 100;
          if (weight < this.VAR_UnitsIdealEnergy * 1)
            num30 += 200;
          if ((double) weight < (double) this.VAR_UnitsIdealEnergy * 0.75)
            num30 += 600;
          if ((double) weight < (double) this.VAR_UnitsIdealEnergy * 0.32)
            num30 += 1800;
          if (!this.IsFamilyAssetTypePresentInZoneList(271, true) && !this.IsFamilyAssetTypePresentInZoneList(361, true) && !this.IsFamilyAssetTypePresentInZoneList(3011, true))
            num30 += this.shqStage * 125;
          let mut tweight: i32 =  Math.Round((double) num30 * 0.8) +  Math.Round((double) num30 * 0.8 * Math.Min(3.0, (double) this.itemNeed[15] / (double) Math.Max(1, this.itemProduction[15])));
          if (flagArray[15])
            tweight = 0;
          simpleList1.Add(10, tweight);
        }
        if (tid == 11 & (this.shqStage >= 3 | (double) this.itemProduction[15] * 0.66 < (double) this.itemNeed[15]))
        {
          let mut num31: i32 = 10;
          if (this.itemProduction[3] <  Math.Round((double) this.itemProduction[2] / 6.0))
            num31 += 100;
          if (this.itemProduction[3] <  Math.Round((double) this.itemProduction[2] / 3.0))
            num31 += 50;
          if (!this.IsFamilyAssetTypePresentInZoneList(211, true))
            num31 += 300;
          if (this.itemProduction[15] * 4 < this.itemNeed[15])
            num31 += 800;
          else if (this.itemProduction[15] * 3 < this.itemNeed[15])
            num31 += 400;
          else if (this.itemProduction[15] * 2 < this.itemNeed[15])
            num31 += 200;
          else if ((double) this.itemProduction[15] * 1.5 < (double) this.itemNeed[15])
            num31 += 100;
          else if (this.itemProduction[15] < this.itemNeed[15])
            num31 += 50;
          let mut tweight: i32 =  Math.Round((double) (( Math.Round((double) num31 * 0.5) +  Math.Round((double) num31 * 0.5 * Math.Min(3.0, (double) this.itemNeed[3] / (double) Math.Max(1, this.itemProduction[3])))) * this.strategicAi.pathEco_American) / 33.0);
          simpleList1.Add(11, tweight);
        }
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 4, 1, this.RegimeId, 2))) >= 100 && tid == 12 & this.shqStage >= 4)
        {
          let mut num32: i32 = 4;
          if (this.itemProduction[13] <  Math.Round((double) this.itemProduction[8] / 6.0))
            num32 += 80;
          if (this.itemProduction[13] <  Math.Round((double) this.itemProduction[8] / 3.0))
            num32 += 40;
          if (!this.IsFamilyAssetTypePresentInZoneList(251, true))
            num32 += 300;
          let mut tweight: i32 =  Math.Round((double) (( Math.Round((double) num32 * 0.5) +  Math.Round((double) num32 * 0.5 * Math.Min(3.0, (double) this.itemNeed[13] / (double) Math.Max(1, this.itemProduction[13])))) * this.strategicAi.pathEco_American) / 33.0);
          simpleList1.Add(12, tweight);
        }
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 324, 1, this.RegimeId, 2))) >= 100 && tid == 13 & this.shqStage >= 5)
        {
          let mut num33: i32 = 2;
          if (this.itemProduction[14] <  Math.Round((double) this.itemProduction[13] / 6.0))
            num33 += 60;
          if (this.itemProduction[14] <  Math.Round((double) this.itemProduction[13] / 3.0))
            num33 += 30;
          let mut tweight: i32 =  Math.Round((double) (( Math.Round((double) num33 * 0.5) +  Math.Round((double) num33 * 0.5 * Math.Min(3.0, (double) this.itemNeed[14] / (double) Math.Max(1, this.itemProduction[14])))) * this.strategicAi.pathEco_American) / 33.0);
          simpleList1.Add(13, tweight);
        }
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 318, 1, this.RegimeId, 2))) >= 100 && tid == 14 & this.shqStage >= 6)
        {
          let mut num34: i32 = 0;
          if (this.itemProduction[4] <  Math.Round((double) (this.itemProduction[13] + this.itemProduction[14]) / 10.0))
            num34 += 40;
          if (this.itemProduction[4] <  Math.Round((double) (this.itemProduction[13] + this.itemProduction[14]) / 4.0))
            num34 += 20;
          let mut tweight: i32 =  Math.Round((double) ( Math.Round((double) (( Math.Round((double) num34 * 0.5) +  Math.Round((double) num34 * 0.5 * Math.Min(3.0, (double) this.itemNeed[4] / (double) Math.Max(1, this.itemProduction[4])))) * this.strategicAi.pathEco_American) / 33.0) * this.strategicAi.pathTech_Artillery) / 33.0);
          simpleList1.Add(14, tweight);
        }
        if (tid == 4 && this.poolPreferedAssetType[4] < 1 & simpleList1.FindWeight(4) > 0)
        {
          this.ai.AddLog("Transferred Oil Importance to Food Pool: +" + simpleList1.FindWeight(4).ToString() + ".");
          int[] poolImportance = this.poolImportance;
          int[] numArray = poolImportance;
          let mut index7: i32 = 1;
          let mut index8: i32 = index7;
          let mut num35: i32 = poolImportance[index7] + simpleList1.FindWeight(4);
          numArray[index8] = num35;
        }
        simpleList1.Sort();
        if (simpleList1.Counter > -1)
        {
          this.poolImportance[tid] = simpleList1.FindWeight(tid);
          if (this.poolImportance[tid] < 0)
            this.poolImportance[tid] = 0;
          this.poolOrigImportance[tid] = this.poolImportance[tid];
          str2: String = this.poolImportance[tid].ToString();
          let mut num36: i32 = this.poolImportance[tid];
          if (this.poolPreferedAssetType[tid] < 1 & this.poolPreferedOob[tid] < 1 & tid != 9 & tid != 8)
            this.poolImportance[tid] = 0;
          str3: String = this.poolImportance[tid].ToString();
          this.ai.AddLog("Pool: " + this.poolName[tid] + "[" + tid.ToString() + "], Raw Importance: " + str2 + ", After Target Asset Mod: " + str3);
          idValue2: String = "aiShq" + this.shqHisId.ToString() + "_";
          bool flag = false;
          if (tid == 1)
          {
            idValue2 += "food";
            flag = true;
          }
          if (tid == 2)
          {
            idValue2 += "metal";
            flag = true;
          }
          if (tid == 4)
          {
            idValue2 += "oil";
            flag = true;
          }
          if (tid == 6)
          {
            idValue2 += "water";
            flag = true;
          }
          if (tid == 11)
          {
            idValue2 += "rare";
            flag = true;
          }
          if (tid == 14)
          {
            idValue2 += "radio";
            flag = true;
          }
          let mut index9: i32 = 0;
          if (tid == 4)
            index9 = 1;
          if (tid == 2)
            index9 = 2;
          if (tid == 11)
            index9 = 3;
          if (tid == 14)
            index9 = 4;
          if (tid == 6)
            index9 = 5;
          let mut num37: i32 = 0;
          if (index9 > 0 & this.itemNeed[index9] > 0)
          {
            let mut num38: i32 =  Math.Round((double) this.itemMiningReserve[index9] / (double) (this.itemNeed[index9] + 1));
            num37 = num38 > 5 ? (num38 > 10 ? (num38 > 17 ? (num38 > 25 ? (num38 > 35 ? 0 : 200) : 600) : 1500) : 3000) : 5000;
            if (tid == 4)
              num37 =  Math.Round((double) num37 / 4.0);
          }
          if (flag)
          {
            let mut setValue: i32 = num36 - this.poolImportance[tid] + num37;
            if (setValue < 0)
              setValue = 0;
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, idValue2, 2, setValue, true);
          }
        }
      }
      let mut mapWidth1: i32 = this.data.MapObj[0].MapWidth;
      int num39;
      for (let mut index10: i32 = 0; index10 <= mapWidth1; index10 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index11: i32 = 0; index11 <= mapHeight; index11 += 1)
        {
          if (this.frontlinesMatrix.Value[index10, index11] > 0)
            num39 += 1;
        }
      }
      let mut mapWidth2: i32 = this.data.MapObj[0].MapWidth;
      int num40;
      for (let mut index12: i32 = 0; index12 <= mapWidth2; index12 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index13: i32 = 0; index13 <= mapHeight; index13 += 1)
        {
          if (this.borderMatrix.Value[index12, index13] > 0)
            num40 += 1;
        }
      }
      if ((double) num40 / 3.0 > (double) num39)
        num39 =  Math.Round((double) num40 / 3.0);
      if (3 > num39)
        num39 = 3;
      let mut unitCounter: i32 = this.data.UnitCounter;
      int num41;
      for (let mut unr: i32 = 0; unr <= unitCounter; unr += 1)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1 && this.ai.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr) && this.data.UnitObj[unr].AIAttack != 1)
          num41 += 1;
      }
      float num42 = (float) num41 / (float) num39;
      let mut num43: i32 = 0;
      let mut num44: i32 = 0;
      if ((double) num42 < 0.07)
      {
        num43 =  Math.Round((double) this.poolImportance[9] * 0.5);
        num44 = 0;
      }
      else if ((double) num42 >= 0.18)
      {
        if ((double) num42 < 0.32)
        {
          num43 = 0;
          num44 =  Math.Round((double) this.poolImportance[7] * 0.32);
        }
        else if ((double) num42 < 0.45)
        {
          num43 = 0;
          num44 =  Math.Round((double) this.poolImportance[7] * 0.42);
        }
        else if ((double) num42 < 0.800000011920929)
        {
          num43 = 0;
          num44 =  Math.Round((double) this.poolImportance[7] * 0.54);
        }
        else if ((double) num42 < 1.5)
        {
          num43 = 0;
          num44 =  Math.Round((double) this.poolImportance[7] * 0.66);
        }
        else
        {
          num43 = 0;
          num44 =  Math.Round((double) this.poolImportance[7] * 0.8);
        }
      }
      if (num43 > 0)
      {
        int[] poolImportance1 = this.poolImportance;
        int[] numArray1 = poolImportance1;
        let mut index14: i32 = 9;
        let mut index15: i32 = index14;
        let mut num45: i32 = poolImportance1[index14] - num43;
        numArray1[index15] = num45;
        int[] poolImportance2 = this.poolImportance;
        int[] numArray2 = poolImportance2;
        let mut index16: i32 = 7;
        let mut index17: i32 = index16;
        let mut num46: i32 = poolImportance2[index16] + num43;
        numArray2[index17] = num46;
        this.ai.AddLog("Moved " + num43.ToString() + " Importance from REPLACEMENTS to OOB.");
      }
      if (num44 > 0 && this.poolPreferedToe[7] < 1)
      {
        int[] poolImportance3 = this.poolImportance;
        int[] numArray3 = poolImportance3;
        let mut index18: i32 = 9;
        let mut index19: i32 = index18;
        let mut num47: i32 = poolImportance3[index18] + num44;
        numArray3[index19] = num47;
        int[] poolImportance4 = this.poolImportance;
        int[] numArray4 = poolImportance4;
        let mut index20: i32 = 7;
        let mut index21: i32 = index20;
        let mut num48: i32 = poolImportance4[index20] - num44;
        numArray4[index21] = num48;
        this.ai.AddLog("Moved " + num44.ToString() + " Importance from OOB to REPLACEMENTS.");
      }
      this.ai.WriteLog(str1);
    }

    pub void GetPoolPreference(string logAddition)
    {
      str1: String = "9020_" + logAddition + "_PoolAssetPreference";
      this.ai.ClearLog();
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      let mut poolCounter: i32 = this.poolCounter;
      for (let mut index: i32 = 1; index <= poolCounter; index += 1)
      {
        SimpleList simpleList1 = SimpleList::new();
        SimpleList simpleList2 = SimpleList::new();
        if (index == 1)
          simpleList1 = this.GetPoolAssetPreference_FoodPool();
        if (index == 2)
          simpleList1 = this.GetPoolAssetPreference_MetalPool();
        if (index == 3)
          simpleList1 = this.GetPoolAssetPreference_IndustryPointsPool();
        if (index == 6)
          simpleList1 = this.GetPoolAssetPreference_WaterPool();
        if (index == 7)
          simpleList2 = this.GetPoolAssetPreference_oobPool(logAddition);
        if (index == 4)
          simpleList1 = this.GetPoolAssetPreference_OilPool();
        if (index == 5)
          simpleList1 = this.GetPoolAssetPreference_BPPool();
        if (index == 10)
          simpleList1 = this.GetPoolAssetPreference_EnergyPool();
        if (index == 11)
          simpleList1 = this.GetPoolAssetPreference_RarePool();
        if (index == 12)
          simpleList1 = this.GetPoolAssetPreference_MachinePool();
        if (index == 13)
          simpleList1 = this.GetPoolAssetPreference_HiTechPool();
        if (index == 14)
          simpleList1 = this.GetPoolAssetPreference_AtomicsPool();
        simpleList1.ReverseSort();
        string str2;
        if (simpleList1.Counter > -1)
        {
          this.poolPreferedAssetType[index] = simpleList1.Id[0];
          str2 = this.data.StringListObj[this.slotAssetTypes].GetData(0, simpleList1.Id[0], 1);
          let mut num: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, simpleList1.Id[0], 2)));
          if (num > 0)
            str2 = str2 + " level " + num.ToString();
        }
        else if (simpleList2.Counter > -1)
        {
          this.poolPreferedOob[index] = simpleList2.Id[0];
          this.poolPreferedToe[index] = simpleList2.Data4[0];
          this.poolPreferedQuality[index] = simpleList2.Data5[0];
          this.poolPreferedOobUpgradeHisId[index] = -1;
          str2 = this.data.StringListObj[this.slotOobTypes].GetData(0, simpleList2.Id[0], 1);
          if (simpleList2.Data3[0] > 0)
          {
            let mut historicalUnitById: i32 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(simpleList2.Data3[0]);
            if (historicalUnitById > -1)
            {
              str2 = simpleList2.Data4[0] <= 0 ? str2 + " (upgrade: " + this.data.HistoricalUnitObj[historicalUnitById].Name + ")" : str2 + " (add missing unit to: " + this.data.HistoricalUnitObj[historicalUnitById].Name + ")";
              this.poolPreferedOobUpgradeHisId[index] = simpleList2.Data3[0];
            }
          }
          if (simpleList2.Data5[0] > 0)
            str2 = str2 + " <Max Quality=" + simpleList2.Data5[0].ToString() + ">";
        }
        else
          str2 = "None";
        this.ai.AddLog("Pool: " + this.poolName[index] + ", Target: " + str2);
      }
      this.ai.WriteLog(str1);
    }

    pub SimpleList GetPoolAssetPreference_oobPool(string logaddition)
    {
      str1: String = "9020b_" + logaddition + "_OOBpreference";
      string[] strArray = new string[this.ai.LogCounter + 10 + 1];
      let mut logCounter1: i32 = this.ai.LogCounter;
      let mut logCounter2: i32 = this.ai.LogCounter;
      for (let mut index: i32 = 0; index <= logCounter2; index += 1)
        strArray[index] = this.ai.LogTxt[index];
      this.ai.ClearLog();
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("SHQ: " + this.shqName);
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList = CoordList::new();
      SimpleList preferenceOobPool = SimpleList::new();
      SimpleStringList simpleStringList = SimpleStringList::new();
      let mut num1: i32 =  Math.Round((double) (100 * this.VAR_CurrentSoldier) / (double) this.VAR_IdealSoldier);
      let mut unitCounter1: i32 = this.data.UnitCounter;
      int num2;
      int num3;
      int num4;
      int num5;
      int num6;
      int num7;
      for (let mut unr: i32 = 0; unr <= unitCounter1; unr += 1)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn && this.data.UnitObj[unr].PreDef == -1 && !this.data.UnitObj[unr].IsHQ && this.data.UnitObj[unr].Historical > -1 && this.data.HistoricalUnitObj[this.data.UnitObj[unr].Historical].GiveHisVarValue(11) < 1)
        {
          num2 = -1;
          let mut hq: i32 = this.data.UnitObj[unr].HQ;
          if (hq > -1)
            num2 = this.data.UnitObj[hq].HQ;
          if (num2 > -1)
          {
            num3 += DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
            num4 += 1;
          }
          else
          {
            num5 += DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
            num6 += 1;
          }
          let mut idValue: i32 = this.data.HistoricalUnitObj[this.data.UnitObj[unr].Historical].GiveHisVarValue(1);
          if (idValue > 0)
          {
            num2 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, idValue, 4)));
            if (num2 == 1)
              num7 += 1;
          }
        }
      }
      let mut num8: i32 = 0;
      let mut num9: i32 = 0;
      let mut mapWidth1: i32 = this.data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth1; index1 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.frontlinesMatrix.Value[index1, index2] > 0)
            num9 += 1;
        }
      }
      let mut mapWidth2: i32 = this.data.MapObj[0].MapWidth;
      for (let mut index3: i32 = 0; index3 <= mapWidth2; index3 += 1)
      {
        let mut mapHeight: i32 = this.data.MapObj[0].MapHeight;
        for (let mut index4: i32 = 0; index4 <= mapHeight; index4 += 1)
        {
          if (this.borderMatrix.Value[index3, index4] > 0)
            num8 += 1;
        }
      }
      if ((double) num9 / 3.0 > (double) num8)
        num8 =  Math.Round((double) num9 / 3.0);
      let mut num10: i32 =  Math.Round((double) num8 * 0.8);
      if (3 > num10)
        num10 = 3;
      let mut num11: i32 = 0;
      let mut num12: i32 = 0;
      let mut num13: i32 = 0;
      let mut num14: i32 = 0;
      let mut num15: i32 = 0;
      let mut num16: i32 = 0;
      let mut num17: i32 = 0;
      let mut num18: i32 = 0;
      let mut num19: i32 = 0;
      let mut num20: i32 = 0;
      let mut unitCounter2: i32 = this.data.UnitCounter;
      int num21;
      int num22;
      for (let mut unr: i32 = 0; unr <= unitCounter2; unr += 1)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1 && this.ai.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.shqUnitNr))
        {
          if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unr))
          {
            if (this.ai.GetAIRolePercent(unr, 13) > 50)
            {
              num16 += 1;
              num17 += 1;
            }
            else if (this.ai.GetAIRolePercent(unr, 14) > 50)
            {
              num16 += 1;
              num18 += 1;
            }
            else if (this.ai.GetAIRolePercent(unr, 15) > 50)
            {
              num16 += 1;
              num19 += 1;
            }
          }
          else if (this.data.UnitObj[unr].AIAttack != 1)
          {
            let mut historical: i32 = this.data.UnitObj[unr].Historical;
            if (historical > -1 && this.data.HistoricalUnitObj[historical].GiveHisVarValue(11) < 1)
            {
              num11 += 1;
              if (this.ai.GetAIRolePercent(unr, 8) > 33)
              {
                num12 += 1;
                if (DrawMod.TGame.HandyFunctionsObj.GetMaxArtRange(unr, 0) > 1)
                  num21 += 1;
              }
              else if (this.ai.GetAIRolePercent(unr, 12) > 50)
                num22 += 1;
              else if (this.ai.GetAIRolePercent(unr, 10) > 33)
                num14 += 1;
              else if (this.ai.GetAIRolePercent(unr, 6) > 33)
                num13 += 1;
              else
                num15 += 1;
              num2 = -1;
              if (!this.data.UnitObj[unr].AIReserve)
                num20 += 1;
              else
                num20 = num20;
            }
          }
          else
            num2 = num2;
        }
      }
      float num23 = (float) num20 / (float) num10;
      this.VAR_UnitsPerFrontHex = num23;
      SimpleList weightedReinfLists = this.strategicAi.GetWeightedReinfLists(false);
      let mut num24: i32 = weightedReinfLists.FindWeight(26) + weightedReinfLists.FindWeight(37) + weightedReinfLists.FindWeight(38) + weightedReinfLists.FindWeight(55);
      let mut num25: i32 = weightedReinfLists.FindWeight(29) + weightedReinfLists.FindWeight(30) + weightedReinfLists.FindWeight(44) + weightedReinfLists.FindWeight(46) + weightedReinfLists.FindWeight(45) + (weightedReinfLists.FindWeight(39) + weightedReinfLists.FindWeight(48));
      let mut num26: i32 = weightedReinfLists.FindWeight(28) + weightedReinfLists.FindWeight(47) + weightedReinfLists.FindWeight(49) + weightedReinfLists.FindWeight(50) + weightedReinfLists.FindWeight(56) + weightedReinfLists.FindWeight(57);
      let mut weight1: i32 = weightedReinfLists.FindWeight(27);
      let mut weight2: i32 = weightedReinfLists.FindWeight(34);
      let mut num27: i32 = num24;
      let mut num28: i32 = weightedReinfLists.FindWeight(59) + weightedReinfLists.FindWeight(60) + weightedReinfLists.FindWeight(61) + weightedReinfLists.FindWeight(62) + weightedReinfLists.FindWeight(63) + weightedReinfLists.FindWeight(64);
      let mut num29: i32 = weightedReinfLists.FindWeight(66) + weightedReinfLists.FindWeight(67) + weightedReinfLists.FindWeight(68);
      let mut num30: i32 = num26 + num24 + num25;
      if (num30 < 1)
        num30 = 1;
      let mut num31: i32 =  Math.Round((double) (100 * num28) / (double) num30);
      let mut num32: i32 =  Math.Round((double) (100 * num29) / (double) num30);
      let mut num33: i32 = 0;
      if (this.strategicAi.Air_Economical_AirBased > 0 | this.strategicAi.Air_Economical_RocketBased > 0 && this.strategicAi.Air_Yes)
        num33 =  Math.Round((double) (this.strategicAi.Air_Aircraft_AsPercentage_Of_Land * Math.Max(this.strategicAi.Air_Economical_AirBased, this.strategicAi.Air_Economical_RocketBased)) / 100.0);
      let mut num34: i32 = 0;
      if (this.strategicAi.Air_Yes | this.strategicAi.Air_JustFlak)
        num34 = this.strategicAi.Air_Flak_AsPercentage_Of_Land;
      let mut num35: i32 = num26 + num24 + num25;
      if (num35 > 0)
      {
        num26 =  Math.Round((double) (100 * num26) / (double) num35);
        num25 =  Math.Round((double) (100 * num25) / (double) num35);
        num24 =  Math.Round((double) (100 * num24) / (double) num35);
      }
      let mut num36: i32 = num12 + num13 + num14;
      if (num36 > 0)
      {
        let mut num37: i32 =  Math.Round((double) (100 * num12) / (double) num36);
        let mut num38: i32 =  Math.Round((double) (100 * num14) / (double) num36);
        let mut num39: i32 =  Math.Round((double) (100 * num13) / (double) num36);
        if (num37 > num26)
          num26 = num37;
      }
      let mut num40: i32 = this.strategicAi.pathWar_Offensive + 10;
      let mut num41: i32 =  Math.Round((double) this.strategicAi.pathTech_Artillery / 4.0);
      let mut num42: i32 =  Math.Round((double) (50 + this.strategicAi.pathWar_Defensive) / 2.0);
      let mut num43: i32 =  Math.Round((double) num40 / 2.0);
      let mut num44: i32 = num40 - num43;
      let mut num45: i32 = num42 + num43;
      let mut num46: i32 = num44;
      let mut num47: i32 = num33;
      let mut num48: i32 = num34;
      this.ai.AddLog("General:");
      this.ai.AddLog("----------------------------------------------------");
      if (num1 < 20)
      {
        num44 =  Math.Round((double) num44 / 10.0);
        num41 =  Math.Round((double) num41 / 10.0);
        num33 =  Math.Round((double) num33 / 10.0);
        num34 =  Math.Round((double) num34 / 10.0);
        this.ai.AddLog("Soldier Percentage < 20 => Tank-Art DIVIDED /10 ");
      }
      else if (num1 < 30)
      {
        num44 =  Math.Round((double) num44 / 5.0);
        num41 =  Math.Round((double) num41 / 5.0);
        num33 =  Math.Round((double) num33 / 5.0);
        num34 =  Math.Round((double) num34 / 5.0);
        this.ai.AddLog("Soldier Percentage < 30 => Tank-Art DIVIDED /5");
      }
      else if (num1 < 40)
      {
        num44 =  Math.Round((double) num44 / 3.0);
        num41 =  Math.Round((double) num41 / 3.0);
        num33 =  Math.Round((double) num33 / 3.0);
        num34 =  Math.Round((double) num34 / 3.0);
        this.ai.AddLog("Soldier Percentage < 40 => Tank-Art DIVIDED /3");
      }
      else if (num1 < 50)
      {
        num44 =  Math.Round((double) num44 / 2.0);
        num41 =  Math.Round((double) num41 / 2.0);
        num33 =  Math.Round((double) num33 / 2.0);
        num34 =  Math.Round((double) num34 / 2.0);
        this.ai.AddLog("Soldier Percentage < 50 => Tank-Art DIVIDED /2");
      }
      if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 0.5)
      {
        num44 =  Math.Round((double) num44 / 10.0);
        num41 =  Math.Round((double) num41 / 10.0);
        num33 =  Math.Round((double) num33 / 10.0);
        num34 =  Math.Round((double) num34 / 10.0);
        this.ai.AddLog("Soldiers needed > IP / 0.5 => Tank-Art DIVIDED /10 ");
      }
      else if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 0.75)
      {
        num44 =  Math.Round((double) num44 / 7.0);
        num41 =  Math.Round((double) num41 / 7.0);
        num33 =  Math.Round((double) num33 / 7.0);
        num34 =  Math.Round((double) num34 / 7.0);
        this.ai.AddLog("Soldiers needed > IP / 0.75=> Tank-Art DIVIDED /7");
      }
      else if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 1.0)
      {
        num44 =  Math.Round((double) num44 / 4.0);
        num41 =  Math.Round((double) num41 / 4.0);
        num33 =  Math.Round((double) num33 / 4.0);
        num34 =  Math.Round((double) num34 / 4.0);
        this.ai.AddLog("Soldiers needed > IP /1 => Tank-Art DIVIDED /4");
      }
      else if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 1.5)
      {
        num44 =  Math.Round((double) num44 / 3.0);
        num41 =  Math.Round((double) num41 / 3.0);
        num33 =  Math.Round((double) num33 / 3.0);
        num34 =  Math.Round((double) num34 / 3.0);
        this.ai.AddLog("Soldiers needed > IP / 1.5 => Tank-Art DIVIDED /3");
      }
      else if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 2.0)
      {
        num44 =  Math.Round((double) num44 / 2.5);
        num41 =  Math.Round((double) num41 / 2.5);
        num33 =  Math.Round((double) num33 / 2.0);
        num34 =  Math.Round((double) num34 / 2.0);
        this.ai.AddLog("Soldiers needed > IP / 2 => Tank-Art DIVIDED /2.5");
      }
      else if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 3.0)
      {
        num44 =  Math.Round((double) num44 / 2.0);
        num41 =  Math.Round((double) num41 / 2.0);
        num33 =  Math.Round((double) num33 / 1.5);
        num34 =  Math.Round((double) num34 / 1.5);
        this.ai.AddLog("Soldiers needed > IP / 3 => Tank-Art DIVIDED /2");
      }
      else if ((double) (this.VAR_IdealSoldier - this.VAR_CurrentSoldier) > (double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(8) / 5.0)
      {
        num44 =  Math.Round((double) num44 / 1.5);
        num41 =  Math.Round((double) num41 / 1.5);
        this.ai.AddLog("Soldiers needed > IP / 5 => Tank-Art DIVIDED /1.5");
      }
      if ((double) this.VAR_CurrentSoldier < (double) this.VAR_IdealSoldier_BeforeMaxRecruit * 0.1)
      {
        num44 =  Math.Round((double) num44 / 6.0);
        num41 =  Math.Round((double) num41 / 6.0);
        num33 =  Math.Round((double) num33 / 4.0);
        num34 =  Math.Round((double) num34 / 4.0);
        this.ai.AddLog("Current Soldier < Ideal Soldier => Tank-Art DIVIDED /6");
      }
      else if ((double) this.VAR_CurrentSoldier < (double) this.VAR_IdealSoldier_BeforeMaxRecruit * 0.2)
      {
        num44 =  Math.Round((double) num44 / 4.0);
        num41 =  Math.Round((double) num41 / 4.0);
        num33 =  Math.Round((double) num33 / 2.0);
        num34 =  Math.Round((double) num34 / 2.0);
        this.ai.AddLog("Current Soldier < Ideal Soldier => Tank-Art DIVIDED /4");
      }
      else if ((double) this.VAR_CurrentSoldier < (double) this.VAR_IdealSoldier_BeforeMaxRecruit * 0.3)
      {
        num44 =  Math.Round((double) num44 / 2.0);
        num41 =  Math.Round((double) num41 / 2.0);
        this.ai.AddLog("Current Soldier < Ideal Soldier => Tank-Art DIVIDED /2");
      }
      if (this.VAR_CurrentRecruits > 800 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 10.0)
      {
        num44 =  Math.Round((double) num44 / 32.0);
        num41 =  Math.Round((double) num41 / 45.0);
        num33 =  Math.Round((double) num33 / 30.0);
        num34 =  Math.Round((double) num34 / 30.0);
        this.ai.AddLog("Current Recruits is HIGH => Tank-Art DIVIDED /32");
      }
      else if (this.VAR_CurrentRecruits > 600 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 8.0)
      {
        num44 =  Math.Round((double) num44 / 9.0);
        num41 =  Math.Round((double) num41 / 16.0);
        num33 =  Math.Round((double) num33 / 10.0);
        num34 =  Math.Round((double) num34 / 10.0);
        this.ai.AddLog("Current Recruits is HIGH => Tank-Art DIVIDED /9");
      }
      else if (this.VAR_CurrentRecruits > 400 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 6.0)
      {
        num44 =  Math.Round((double) num44 / 6.0);
        num41 =  Math.Round((double) num41 / 8.0);
        num33 =  Math.Round((double) num33 / 5.0);
        num34 =  Math.Round((double) num34 / 5.0);
        this.ai.AddLog("Current Recruits is HIGH => Tank-Art DIVIDED /6");
      }
      else if (this.VAR_CurrentRecruits > 300 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 5.0)
      {
        num44 =  Math.Round((double) num44 / 4.5);
        num41 =  Math.Round((double) num41 / 6.0);
        num33 =  Math.Round((double) num33 / 3.0);
        num34 =  Math.Round((double) num34 / 3.0);
        this.ai.AddLog("Current Recruits is HIGH => Tank-Art DIVIDED /4.5");
      }
      else if (this.VAR_CurrentRecruits > 200 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 4.0)
      {
        num44 =  Math.Round((double) num44 / 3.0);
        num41 =  Math.Round((double) num41 / 4.0);
        num33 =  Math.Round((double) num33 / 2.0);
        num34 =  Math.Round((double) num34 / 2.0);
        this.ai.AddLog("Current Recruits is HIGH => Tank-Art DIVIDED /3");
      }
      else if (this.VAR_CurrentRecruits > 100 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 3.0)
      {
        num44 =  Math.Round((double) num44 / 1.5);
        num41 =  Math.Round((double) num41 / 2.0);
        this.ai.AddLog("Current Recruits is HIGH => Tank-Art DIVIDED /1.5");
      }
      if ((double) num23 < 0.05)
      {
        num44 =  Math.Round((double) num44 / 16.0);
        num41 =  Math.Round((double) num41 / 32.0);
        num33 =  Math.Round((double) num33 / 10.0);
        num34 =  Math.Round((double) num34 / 20.0);
      }
      else if ((double) num23 < 0.1)
      {
        num44 =  Math.Round((double) num44 / 4.0);
        num41 =  Math.Round((double) num41 / 16.0);
        num33 =  Math.Round((double) num33 / 5.0);
        num34 =  Math.Round((double) num34 / 10.0);
      }
      else if ((double) num23 < 0.15)
      {
        num44 =  Math.Round((double) num44 / 3.0);
        num41 =  Math.Round((double) num41 / 8.0);
        num33 =  Math.Round((double) num33 / 4.0);
        num34 =  Math.Round((double) num34 / 8.0);
      }
      else if ((double) num23 < 0.2)
      {
        num44 =  Math.Round((double) num44 / 2.0);
        num41 =  Math.Round((double) num41 / 4.0);
        num33 =  Math.Round((double) num33 / 2.0);
        num34 =  Math.Round((double) num34 / 4.0);
      }
      else if ((double) num23 < 0.3)
      {
        num44 =  Math.Round((double) num44 / 1.0);
        num41 =  Math.Round((double) num41 / 2.0);
      }
      else if ((double) num23 >= 0.4)
      {
        if ((double) num23 < 0.5)
          num44 =  Math.Round((double) num44 * 1.3);
        else if ((double) num23 < 0.7)
        {
          num44 =  Math.Round((double) num44 * 1.5);
          num41 =  Math.Round((double) num41 * 1.2);
        }
        else if ((double) num23 < 0.9)
        {
          num44 =  Math.Round((double) num44 * 1.7);
          num41 =  Math.Round((double) num41 * 1.35);
        }
        else
        {
          num44 *= 2;
          num41 =  Math.Round((double) num41 * 1.5);
        }
      }
      if (this.strategicAi.OurLossDueToAir > this.strategicAi.OurLossDueToTank & this.strategicAi.OurLossDueToAir > 20)
      {
        num33 =  Math.Round((double) (num47 + num33 + num33) / 3.0);
        num34 =  Math.Round((double) (num48 + num34 + num34) / 3.0);
      }
      else if (this.strategicAi.OurLossDueToTank > this.strategicAi.OurLossDueToAir & this.strategicAi.OurLossDueToTank > 20)
        num44 =  Math.Round((double) (num46 + num44 + num44) / 3.0);
      if (this.strategicAi.OurLossDueToAir > 35)
      {
        num33 =  Math.Round((double) (num47 + num33) / 2.0);
        num34 =  Math.Round((double) (num48 + num34) / 2.0);
      }
      if (this.strategicAi.OurLossDueToTank > 35)
        num44 =  Math.Round((double) (num46 + num44) / 2.0);
      if (this.strategicAi.OurKillDueToAir > 50)
        num33 =  Math.Round((double) num47 * 1.5);
      else if (this.strategicAi.OurKillDueToAir > 30)
        num33 =  Math.Round(((double) num47 * 1.5 + (double) num33) / 2.0);
      else if (this.strategicAi.OurKillDueToAir > 15)
        num33 =  Math.Round((double) (num47 + num33 + num33) / 3.0);
      if (this.strategicAi.OurKillDueToTank > 50)
        num44 =  Math.Round((double) num46 * 1.5);
      else if (this.strategicAi.OurKillDueToTank > 30)
        num44 =  Math.Round(((double) num46 * 1.5 + (double) num44) / 2.0);
      else if (this.strategicAi.OurKillDueToTank > 15)
        num44 =  Math.Round((double) (num46 + num44 + num44) / 3.0);
      float num49 = 100f / (float) (num44 + num41 + num45);
      let mut num50: i32 =  Math.Round((double) ((float) num44 * num49));
      let mut num51: i32 =  Math.Round((double) ((float) num45 * num49));
      let mut num52: i32 =  Math.Round((double) ((float) num41 * num49));
      float num53 = 100f / (float) (num50 + num52 + num51);
      let mut num54: i32 =  Math.Round((double) ((float) num50 * num53));
      let mut num55: i32 =  Math.Round((double) ((float) num51 * num53));
      let mut num56: i32 =  Math.Round((double) ((float) num52 * num53));
      if (this.data.Round < 10)
      {
        num54 -= 3;
        num56 -= 5;
        num33 -= 5;
        num34 -= 9;
      }
      else if (this.data.Round < 20)
      {
        num54 -= 2;
        num56 -= 3;
        num33 -= 2;
        num34 -= 5;
      }
      else if (this.data.Round < 30)
      {
        --num54;
        num56 -= 2;
        num34 -= 3;
      }
      if (num22 > 0)
      {
        let mut num57: i32 =  Math.Round((double) (num22 * 100) / (double) Math.Max(1, num13 + num14 + num12));
        if (num57 > num32)
          num32 = num57;
      }
      if (num16 > 0)
      {
        let mut num58: i32 =  Math.Round((double) (num16 * 100) / (double) Math.Max(1, num13 + num14 + num12));
        if (num58 > num31)
          num31 = num58;
      }
      if (num12 > 0)
      {
        let mut num59: i32 =  Math.Round((double) ((num12 + num21) * 100) / (double) Math.Max(1, num13 + num14 + num12));
        if (num59 > num26)
          num26 = num59;
      }
      let mut num60: i32 = num26 + num24 + num25;
      if (num60 > 0)
      {
        num26 =  Math.Round((double) (100 * num26) / (double) num60);
        num25 =  Math.Round((double) (100 * num25) / (double) num60);
        num24 =  Math.Round((double) (100 * num24) / (double) num60);
      }
      if (num34 < 1)
        num34 = 1;
      if (num33 < 1)
        num33 = 1;
      if (num56 < 1)
        num56 = 0;
      if (num55 < 1)
        num55 = 1;
      if (num54 < 1)
        num54 = 0;
      if (num24 < 1)
        num24 = 1;
      if (num25 < 1)
        num25 = 1;
      if (num26 < 1)
        num26 = 1;
      if (num25 > num54)
        num54 =  Math.Round((double) num54 / 2.0);
      if (num26 > num56)
        num56 =  Math.Round((double) num56 / 2.0);
      float[] numArray1 = new float[1000];
      let mut index5: i32 = 0;
      do
      {
        numArray1[index5] = 1f;
        index5 += 1;
      }
      while (index5 <= 999);
      if (num31 < 1)
        num31 = 1;
      float num61 = (float) num33 / (float) num31;
      if (!this.strategicAi.Air_Yes)
        num61 = 0.0f;
      numArray1[59] = (float) ((double) num61 * 0.33 * (double) this.strategicAi.Air_Cover / 50.0);
      numArray1[60] = (float) ((double) num61 * (double) this.strategicAi.Air_Cover / 50.0);
      numArray1[61] = (float) ((double) num61 * 0.5 * (double) this.strategicAi.Air_Support / 50.0);
      numArray1[62] = (float) ((double) num61 * 1.0 * (double) this.strategicAi.Air_Support / 50.0);
      numArray1[63] = (float) ((double) num61 * 1.0 * (double) this.strategicAi.Air_Support / 50.0);
      numArray1[64] = 0.0f;
      if (num32 < 1)
        num32 = 1;
      float num62 = (float) num34 / (float) num32;
      if (!this.strategicAi.Air_Yes & !this.strategicAi.Air_JustFlak)
        num62 = 0.0f;
      numArray1[65] = num62 * 1.66f;
      numArray1[66] = num62 * 1f;
      numArray1[67] = num62 * 1f;
      let mut num63: i32 = weightedReinfLists.FindWeight(26);
      let mut num64: i32 = (weightedReinfLists.FindWeight(37) + weightedReinfLists.FindWeight(38) + weightedReinfLists.FindWeight(55) + weightedReinfLists.FindWeight(40)) * 2;
      if (num64 < 1)
        num64 = 1;
      if (num63 < 1)
        num63 = 1;
      float num65 = (float) num63 / (float) num64;
      if ((double) num65 > 1.0)
        num65 = 1f;
      if ((double) num65 < 0.05)
        num65 = 0.05f;
      float num66 = (float) num55 / (float) num24;
      if ((double) num66 > 0.0)
        num66 = num66 * num66 * num66;
      if ((double) num66 > 4.0)
        num66 = (float) (4.0 + ((double) num66 - 4.0) * 0.699999988079071);
      if ((double) num66 > 7.0)
        num66 = (float) (7.0 + ((double) num66 - 7.0) * 0.5);
      if ((double) num66 > 10.0)
        num66 = (float) (10.0 + ((double) num66 - 10.0) * 0.300000011920929);
      if ((double) num66 > 13.0)
        num66 = (float) (13.0 + ((double) num66 - 13.0) * 0.200000002980232);
      if ((double) num66 > 15.0)
        num66 = (float) (15.0 + ((double) num66 - 15.0) * 0.100000001490116);
      numArray1[26] = num66;
      numArray1[37] = num66 * num65;
      numArray1[38] = num66 * num65;
      numArray1[55] = num66 * num65;
      if (num13 <= num15 * 5)
      {
        if (num13 > num15 * 4)
          num66 /= 2f;
        else if (num13 > num15 * 3)
          num66 /= 4f;
        else if (num13 > num15 * 2)
          num66 /= 8f;
        else
          num66 = 0.0f;
      }
      numArray1[40] = num66 * num65;
      float num67 = (float) num54 / (float) num25;
      if ((double) num67 > 0.0)
        num67 = num67 * num67 * num67;
      if ((double) num67 > 4.0)
        num67 = (float) (4.0 + ((double) num67 - 4.0) * 0.699999988079071);
      if ((double) num67 > 7.0)
        num67 = (float) (7.0 + ((double) num67 - 7.0) * 0.5);
      if ((double) num67 > 10.0)
        num67 = (float) (10.0 + ((double) num67 - 10.0) * 0.300000011920929);
      if ((double) num67 > 13.0)
        num67 = (float) (13.0 + ((double) num67 - 13.0) * 0.200000002980232);
      if ((double) num67 > 15.0)
        num67 = (float) (15.0 + ((double) num67 - 15.0) * 0.100000001490116);
      numArray1[29] = num67;
      numArray1[30] = num67;
      numArray1[44] = num67;
      numArray1[46] = num67;
      numArray1[45] = num67;
      numArray1[39] = num67;
      numArray1[48] = num67;
      float num68 = (float) num56 / (float) num26;
      if ((double) num68 < 1.0)
        num68 = num68 * num68 * num68;
      if ((double) num68 > 4.0)
        num68 = (float) (4.0 + ((double) num68 - 4.0) * 0.699999988079071);
      if ((double) num68 > 7.0)
        num68 = (float) (7.0 + ((double) num68 - 7.0) * 0.5);
      if ((double) num68 > 10.0)
        num68 = (float) (10.0 + ((double) num68 - 10.0) * 0.300000011920929);
      if ((double) num68 > 13.0)
        num68 = (float) (13.0 + ((double) num68 - 13.0) * 0.200000002980232);
      if ((double) num68 > 15.0)
        num68 = (float) (15.0 + ((double) num68 - 15.0) * 0.100000001490116);
      numArray1[28] = num68;
      numArray1[47] = num68;
      numArray1[49] = num68;
      numArray1[50] = num68;
      numArray1[56] = num68;
      numArray1[57] = num68;
      float num69 = (float) num54 / (float) num25;
      if ((double) num69 > 0.0)
        num69 *= num69;
      if ((double) num69 > 4.0)
        num69 = (float) (4.0 + ((double) num69 - 4.0) * 0.699999988079071);
      if ((double) num69 > 7.0)
        num69 = (float) (7.0 + ((double) num69 - 7.0) * 0.5);
      if ((double) num69 > 10.0)
        num69 = (float) (10.0 + ((double) num69 - 10.0) * 0.300000011920929);
      if ((double) num69 > 13.0)
        num69 = (float) (13.0 + ((double) num69 - 13.0) * 0.200000002980232);
      if ((double) num69 > 15.0)
        num69 = (float) (15.0 + ((double) num69 - 15.0) * 0.100000001490116);
      if ((double) num69 > 1.0)
        num69 = 1f;
      float num70 = (float) (weight1 + weight2) / (float) (num27 + 2);
      float num71 = (double) num70 >= 0.05 ? ((double) num70 >= 0.12 ? ((double) num70 >= 0.2 ? ((double) num70 >= 0.3 ? num69 * 0.05f : num69 * 0.15f) : num69 * 0.4f) : num69 * 0.7f) : num69;
      numArray1[27] = num71;
      float num72 = (float) num54 / (float) num25;
      if ((double) num72 > 0.0)
        num72 = num72 * num72 * num72;
      if ((double) num72 > 4.0)
        num72 = (float) (4.0 + ((double) num72 - 4.0) * 0.699999988079071);
      if ((double) num72 > 7.0)
        num72 = (float) (7.0 + ((double) num72 - 7.0) * 0.5);
      if ((double) num72 > 10.0)
        num72 = (float) (10.0 + ((double) num72 - 10.0) * 0.300000011920929);
      if ((double) num72 > 13.0)
        num72 = (float) (13.0 + ((double) num72 - 13.0) * 0.200000002980232);
      if ((double) num72 > 15.0)
        num72 = (float) (15.0 + ((double) num72 - 15.0) * 0.100000001490116);
      if ((double) num72 > 1.0)
        num72 = 1f;
      float num73 = (double) num70 >= 0.05 ? ((double) num70 >= 0.12 ? ((double) num70 >= 0.2 ? ((double) num70 >= 0.3 ? num72 * 0.05f : num72 * 0.15f) : num72 * 0.4f) : num72 * 0.7f) : num72;
      numArray1[34] = num73;
      Random random = new Random( Math.Round((double) this.data.GameID / 1000.0 * (double) this.data.RegimeObj[this.data.Turn].id));
      let mut upperBound: i32 = numArray1.GetUpperBound(0);
      for (let mut index6: i32 = 0; index6 <= upperBound; index6 += 1)
      {
        let mut num74: i32 = random.Next(50, 150);
        numArray1[index6] = (float) ((double) numArray1[index6] * (double) num74 / 100.0);
      }
      this.ai.AddLog("");
      this.ai.AddLog("Str.Offensive: " + this.strategicAi.pathWar_Offensive.ToString());
      this.ai.AddLog("Str.Defensive: " + this.strategicAi.pathWar_Defensive.ToString());
      this.ai.AddLog("Units Per FrontHex: " + num23.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("Friendly Inf = " + num24.ToString());
      this.ai.AddLog("Friendly Art = " + num26.ToString());
      this.ai.AddLog("Friendly Tank = " + num25.ToString());
      this.ai.AddLog("Friendly Air = " + num31.ToString());
      this.ai.AddLog("Friendly Flak = " + num32.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("Ideal Inf = " + num55.ToString());
      this.ai.AddLog("Ideal Art = " + num56.ToString());
      this.ai.AddLog("Ideal Tank = " + num54.ToString());
      this.ai.AddLog("Ideal Air = " + num33.ToString());
      this.ai.AddLog("Ideal Flak = " + num34.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("SHQ Units = " + num6.ToString());
      this.ai.AddLog("OHQ Units = " + num4.ToString());
      this.ai.AddLog("Ind Units = " + num7.ToString());
      this.ai.AddLog("Air Units = " + num16.ToString());
      this.ai.AddLog("Flak Units = " + num22.ToString());
      this.ai.AddLog("Flak Units = " + num12.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("");
      this.ai.AddLog("ReinfType Modifiers:");
      this.ai.AddLog("----------------------------------------------------");
      let mut reinfCounter: i32 = this.data.ReinfCounter;
      for (let mut index7: i32 = 0; index7 <= reinfCounter; index7 += 1)
      {
        let mut id: i32 = this.data.ReinfLibId[index7].id;
        if (id > 0)
          this.ai.AddLog(this.data.ReinfName[index7] + " = " + numArray1[id].ToString());
      }
      this.ai.AddLog("");
      this.ai.AddLog("Formation Type Scores:");
      this.ai.AddLog("----------------------------------------------------");
      this.ai.AddLog("");
      if (this.data.Turn == 5)
        ;
      SimpleList simpleList3 = SimpleList::new();
      let mut num75: i32 = 1;
      do
      {
        bool flag1;
        bool flag2;
        bool flag3;
        bool flag4;
        if (num75 == 1)
        {
          flag1 = true;
          flag2 = true;
          flag3 = true;
          flag4 = true;
        }
        else if (this.VAR_CurrentRecruits > 500 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 16.0)
        {
          flag1 = true;
          flag2 = false;
          flag3 = false;
          flag4 = false;
        }
        else if (this.VAR_CurrentRecruits > 300 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 10.0)
        {
          flag1 = true;
          flag2 = true;
          flag3 = false;
          flag4 = false;
          if (this.data.Round % 2 == 1)
            flag2 = false;
        }
        else if (this.VAR_CurrentRecruits > 120 & (double) this.VAR_CurrentRecruits > (double) this.VAR_CurrentSoldier / 6.0)
        {
          flag1 = true;
          flag2 = true;
          flag3 = true;
          flag4 = false;
          if (this.data.Round % 2 == 1)
            flag3 = false;
        }
        else
        {
          flag1 = true;
          flag2 = true;
          flag3 = true;
          flag4 = true;
        }
        if (num75 == 1 | !flag1 | !flag2 | !flag3 | !flag4)
        {
          let mut length: i32 = this.ai.game.Data.StringListObj[this.slotOobTypes].Length;
          for (let mut index8: i32 = 0; index8 <= length; index8 += 1)
          {
            str2: String = "";
            let mut num76: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index8, 0]));
            if (num76 == 1533)
              num76 = num76;
            if (this.data.Turn == 6)
            {
              if (num76 == 304)
                num76 = num76;
              if (num76 == 38)
                num76 = num76;
              if (num76 == 62)
                num76 = num76;
              if (num76 == 804)
                num76 = num76;
            }
            let mut num77: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index8, 3]));
            let mut num78: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num77, 1, this.RegimeId, 4)));
            if (num76 >= 1500 & num76 <= 1599)
            {
              if (num75 == 1)
              {
                num78 = 0;
              }
              else
              {
                flag1 = false;
                flag2 = false;
                flag3 = false;
                flag4 = true;
              }
            }
            if (num78 > 0)
            {
              SimpleList reinfListForOob = this.ai.game.EventRelatedObj.Helper_GetReinfListForOob(num76);
              if (reinfListForOob.Counter > -1)
              {
                let mut num79: i32 = 0;
                let mut num80: i32 = 0;
                let mut counter1: i32 = reinfListForOob.Counter;
                for (let mut index9: i32 = 0; index9 <= counter1; index9 += 1)
                {
                  let mut index10: i32 = reinfListForOob.Id[index9];
                  if (index10 > 0 && (double) numArray1[index10] != 1.0)
                  {
                    num79 += reinfListForOob.Weight[index9];
                    str3: String = this.data.ReinfName[DrawMod.TGame.HandyFunctionsObj.GetReinfTypeByID(reinfListForOob.Id[index9])];
                    str2 = str2 + "REINF_" + str3 + "=" + numArray1[index10].ToString() + ". ";
                    num80 +=  Math.Round((double) ((float) (reinfListForOob.Weight[index9] * 1000) * numArray1[index10]));
                  }
                }
                let mut num81: i32 = 1000;
                if (num79 > 0)
                  num81 =  Math.Round((double) num80 / (double) num79);
                EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
                SimpleList RL = reinfListForOob;
                let mut num82: i32 = flag1 ? 1 : 0;
                let mut num83: i32 = flag2 ? 1 : 0;
                let mut num84: i32 = flag3 ? 1 : 0;
                let mut num85: i32 = flag4 ? 1 : 0;
                let mut regimeId: i32 = this.RegimeId;
                SimpleList simpleList4 = (SimpleList) null;
                 SimpleList local =  simpleList4;
                SimpleList sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, num82 != 0, num83 != 0, num84 != 0, num85 != 0, regimeId, allowedSfTypeList: ( local));
                SimpleList simpleList5 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList, true);
                if (num76 == 34)
                  num76 = num76;
                let mut weight3: i32 = simpleList5.FindWeight(10);
                let mut weight4: i32 = simpleList5.FindWeight(1);
                if (weight4 > 0)
                {
                  let mut num86: i32 =  Math.Round((double) weight4 / 2.0);
                  if (num86 < 1)
                    num86 = 1;
                  let mut num87: i32 = Math.Min(this.itemProduction[1] - this.itemNeed[1], this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(1));
                  if (num87 < 0)
                    num87 = 0;
                  if ((double) this.itemProduction[1] * 0.33 > (double) this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 1.5) + 150;
                  else if ((double) this.itemProduction[1] * 0.5 > (double) this.itemNeed[1])
                    num87 += this.itemProduction[1] * 1 + 100;
                  else if ((double) this.itemProduction[1] * 0.7 > (double) this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 0.85) + 80;
                  else if ((double) this.itemProduction[1] * 0.85 > (double) this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 0.7) + 60;
                  else if (this.itemProduction[1] * 1 > this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 0.5) + 45;
                  else if ((double) this.itemProduction[1] * 1.1 > (double) this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 0.3) + 30;
                  else if ((double) this.itemProduction[1] * 1.2 > (double) this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 0.2) + 20;
                  else if ((double) this.itemProduction[1] * 1.3 > (double) this.itemNeed[1])
                    num87 +=  Math.Round((double) this.itemProduction[1] * 0.1) + 10;
                  let mut num88: i32 = 1;
                  if (reinfListForOob.FindWeight(27) > 0 | reinfListForOob.FindWeight(34) > 0)
                  {
                    num88 = 3;
                    str2 += "Truck or APC present. ";
                  }
                  let mut num89: i32 = num88;
                  for (let mut index11: i32 = 1; index11 <= num89; index11 += 1)
                  {
                    if ((double) num86 * 0.4 > (double) num87)
                    {
                      num81 = 0;
                      str2 += "OilConsume = 0. ";
                    }
                    else if ( Math.Round((double) num86 * 0.6) > num87)
                    {
                      num81 =  Math.Round((double) num81 * 0.25);
                      str2 += "OilConsume = 0.25. ";
                    }
                    else if ( Math.Round((double) num86 * 0.8) > num87)
                    {
                      num81 =  Math.Round((double) num81 * 0.5);
                      str2 += "OilConsume = 0.5. ";
                    }
                    else if ( Math.Round((double) num86 * 0.9) > num87)
                    {
                      num81 =  Math.Round((double) num81 * 0.65);
                      str2 += "OilConsume = 0.65. ";
                    }
                    else if (num86 * 1 > num87)
                    {
                      num81 =  Math.Round((double) num81 * 0.8);
                      str2 += "OilConsume = 0.8. ";
                    }
                    else if ( Math.Round((double) num86 * 1.25) > num87)
                    {
                      num81 =  Math.Round((double) num81 * 0.9);
                      str2 += "OilConsume = 0.9. ";
                    }
                  }
                }
                let mut weight5: i32 = simpleList5.FindWeight(15);
                if (weight5 > 0)
                {
                  let mut num90: i32 = weight5 * 3;
                  let mut num91: i32 = Math.Min(this.itemProduction[15] - this.itemNeed[15], this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(15));
                  if (num90 > num91)
                  {
                    num81 = 0;
                    str2 += "EnergyConsume = 0. ";
                  }
                  else if (num90 * 2 > num91)
                  {
                    num81 =  Math.Round((double) num81 / 4.0);
                    str2 += "EnergyConsume = 0.25. ";
                  }
                  else if (num90 * 4 > num91)
                  {
                    num81 =  Math.Round((double) num81 / 2.0);
                    str2 += "EnergyConsume = 0.5. ";
                  }
                }
                tid: String = str2 + "FINAL_REINFMOD =" + num81.ToString() + ". ";
                let mut tweight1: i32 =  Math.Round(Math.Ceiling((double) weight3 / 10.0));
                simpleList5.RemoveNr(10);
                SimpleList simpleList6 = this.ai.game.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList, supplyReserveMod: ((float) this.strategicAi.pathWar_Offensive / 400f));
                if (tweight1 > 0)
                {
                  simpleList6.AddWeight(8, tweight1);
                  simpleList6.AddWeight(2, tweight1);
                }
                simpleList6.removeWeight0orLower();
                if (simpleList6.Counter > -1)
                {
                  let mut tweight2: i32 =  Math.Round((double) (1000 * num81) / 1000.0);
                  if (!Information.IsNothing((object) this.strategicAi.OobRatingList))
                  {
                    let mut num92: i32 = !flag4 ? (!flag3 ? (!flag2 ? this.strategicAi.OobRatingList.FindWeight(num77, 2) : this.strategicAi.OobRatingList.FindWeight(num77, 3)) : this.strategicAi.OobRatingList.FindWeight(num77, 4)) : this.strategicAi.OobRatingList.FindWeight(num77, 5);
                    if (num92 > 0)
                    {
                      if (num92 > 1000)
                        num92 = 1000 +  Math.Round((double) (num92 - 1000) * 0.9);
                      if (num92 > 2000)
                        num92 = 2000 +  Math.Round((double) (num92 - 2000) * 0.8);
                      if (num92 > 3000)
                        num92 = 3000 +  Math.Round((double) (num92 - 3000) * 0.65);
                      if (num92 > 4000)
                        num92 = 4000 +  Math.Round((double) (num92 - 4000) * 0.5);
                      if (num92 > 5000)
                        num92 = 5000 +  Math.Round((double) (num92 - 5000) * 0.3);
                      if (num92 > 6000)
                        num92 = 6000 +  Math.Round((double) (num92 - 6000) * 0.1);
                      if (num92 > 7000)
                        num92 = 7000;
                      tid = tid + "OOB_RATING_MOD = " + num92.ToString() + ". ";
                    }
                    else
                      num92 = 0;
                    tweight2 =  Math.Round((double) (tweight2 * num92) / 1000.0);
                    tid = tid + "**** SCORE = " + tweight2.ToString() + " ****. ";
                  }
                  tweight2 =  Math.Round((double) tweight2 / 10.0);
                  let mut num93: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index8, 4]));
                  let mut num94: i32 = 1;
                  do
                  {
                    let mut counter2: i32 = simpleList6.Counter;
                    for (let mut index12: i32 = 0; index12 <= counter2; index12 += 1)
                    {
                      let mut num95: i32 = 0;
                      float num96;
                      if (simpleList6.Id[index12] != 9 & num94 == 2)
                      {
                        let mut num97: i32 = this.itemProduction[simpleList6.Id[index12]] - this.itemNeed[simpleList6.Id[index12]];
                        if (num97 < 5)
                          num97 = 5;
                        let mut weight6: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(simpleList6.Id[index12]);
                        let mut num98: i32 = num97 +  Math.Round((double) weight6 / 2.0);
                        let mut num99: i32 = (double) num23 >= 0.1 ? ((double) num23 >= 0.2 ? ((double) num23 >= 0.4 ? ((double) num23 >= 0.6 ? ((double) num23 >= 1.0 ?  Math.Round((double) num98 * 2.0) :  Math.Round((double) num98 * 1.7)) :  Math.Round((double) num98 * 1.4)) :  Math.Round((double) num98 * 1.25)) :  Math.Round((double) num98 * 1.1)) : num98 * 1;
                        float num100 = 1f;
                        if (simpleList6.Weight[index12] > 0)
                          num100 = (float) num99 / (float) simpleList6.Weight[index12];
                        if ((double) num100 > 1.0)
                          num100 = 1f;
                        float num101 = simpleList6.Weight[index12] <= num99 ? ((double) simpleList6.Weight[index12] * 1.2 <= (double) num99 ? ((double) simpleList6.Weight[index12] * 1.5 <= (double) num99 ? (simpleList6.Weight[index12] * 2 <= num99 ? ((double) simpleList6.Weight[index12] * 2.75 <= (double) num99 ? (simpleList6.Weight[index12] * 4 <= num99 ? (simpleList6.Weight[index12] * 6 <= num99 ? (simpleList6.Weight[index12] * 12 <= num99 ? (simpleList6.Weight[index12] * 24 <= num99 ? (simpleList6.Weight[index12] * 48 <= num99 ? (simpleList6.Weight[index12] * 96 <= num99 ? (simpleList6.Weight[index12] * 128 <= num99 ? (simpleList6.Weight[index12] * 256 <= num99 ? num100 * 0.4f : num100 * 0.48f) : num100 * 0.55f) : num100 * 0.61f) : num100 * 0.67f) : num100 * 0.73f) : num100 * 0.78f) : num100 * 0.82f) : num100 * 0.86f) : num100 * 0.9f) : num100 * 0.94f) : num100 * 0.98f) : num100 * 1f) : num100;
                        if ((double) num96 < 0.5)
                          num101 = num100;
                        else if ((double) num96 < 0.75)
                          num101 = (float) (((double) num101 + 3.0 * (double) num100) / 4.0);
                        else if ((double) num96 < 1.0)
                          num101 = (float) (((double) num101 + (double) num100) / 2.0);
                        tweight2 =  Math.Round((double) tweight2 * 0.1 + (double)  Math.Round((double) ((float) tweight2 * num101)));
                        tid = tid + this.itemName[simpleList6.Id[index12]] + "=" + num100.ToString() + " (after mod for to cheap: " + num101.ToString() + "). ";
                      }
                      else if (simpleList6.Id[index12] == 9 & num94 == 1)
                      {
                        let mut num102: i32 = Math.Max(this.VAR_RecruitGrowth +  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(9) / 3.0), this.newItems.FindWeight(9));
                        if (num102 < 10)
                          num102 = 10;
                        float num103 = (float) Math.Max(0.0500000007450581, (double) num102 / (double) Math.Max(1, simpleList6.Weight[index12]));
                        if ((double) num103 > 0.1)
                          num103 = (float) ((1.0 + (double) num103) / 2.0);
                        if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(9) >= simpleList6.Weight[index12])
                          num103 = 1f;
                        if ((double) num103 > 1.0)
                          num103 = 1f;
                        num96 = 0.5f + (float) Math.Max(0.0500000007450581, (double) simpleList6.Weight[index12] / (double) (1 + this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(9))) / 2f;
                        if ((double) num96 > 1.0)
                          num96 = 1f;
                        tid = tid + "ModForToLittleRecrAv =" + num103.ToString() + ". " + "ModForToMuchRecrAv =" + num96.ToString() + ". ";
                        tweight2 =  Math.Round((double) ((float) tweight2 * num103 * num96));
                        let mut num104: i32 = this.VAR_IdealSoldier - this.VAR_CurrentSoldier;
                        if (num93 == 0)
                        {
                          if (num3 <  Math.Round((double) num5 / 2.0) & num80 >= 4)
                            num104 += 70;
                          else if (num3 < num5 * 1 & num80 >= 3)
                            num104 += 50;
                          else if (num3 <  Math.Round((double) num5 * 1.5) & num80 >= 2)
                            num104 += 25;
                          else if (!(num3 < num5 * 2 & num80 >= 1))
                            ;
                        }
                        if (simpleList6.Weight[index12] > num104)
                          tweight2 = 0;
                        num95 = num102;
                      }
                    }
                    num94 += 1;
                  }
                  while (num94 <= 2);
                  let mut num105: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index8, 2]));
                  if (num93 == 0)
                  {
                    tweight2 *= 2;
                    let mut num106: i32 =  Math.Round(Math.Sqrt((double) (num6 + 1)));
                    if (tweight2 > 0)
                      tweight2 = tweight2;
                    if (num106 >= 1)
                    {
                      if (num3 <  Math.Round((double) num5 / 2.0) & num106 >= 4)
                      {
                        tweight2 *= 9;
                        tid += "OhqPower<ShqPower = 9. ";
                      }
                      else if (num3 < num5 * 1 & num106 >= 3)
                      {
                        tweight2 *= 5;
                        tid += "OhqPower<ShqPower = 5. ";
                      }
                      else if (num3 <  Math.Round((double) num5 * 1.5) & num106 >= 2)
                      {
                        tweight2 *= 2;
                        tid += "OhqPower<ShqPower = 2. ";
                      }
                      else if (num3 < num5 * 2 & num106 >= 1)
                      {
                        tweight2 *= 1;
                        tid += "OhqPower<ShqPower = 1. ";
                      }
                    }
                  }
                  else
                  {
                    let mut num107: i32 = num7;
                    if (num76 >= 1600 & num76 <= 1639)
                    {
                      let mut num108: i32 = num34 * 2;
                      if (num108 > 66)
                        num108 = 66;
                      if (num108 < 0)
                        num108 = 0;
                      num107 =  Math.Round((double) (num7 * (100 - num108) + num22 * num108) / 100.0);
                    }
                    if ((double) num107 < (double) num4 / 20.0)
                    {
                      tweight2 *= 10;
                      tid += "IndUnit < OhqUnit = 10. ";
                    }
                    else if ((double) num107 < (double) num4 / 15.0)
                    {
                      tweight2 *= 7;
                      tid += "IndUnit < OhqUnit = 7. ";
                    }
                    else if ((double) num107 < (double) num4 / 10.0)
                    {
                      tweight2 *= 4;
                      tid += "IndUnit < OhqUnit = 4. ";
                    }
                    else if ((double) num107 < (double) num4 / 8.0)
                    {
                      tweight2 =  Math.Round((double) tweight2 * 3.5);
                      tid += "IndUnit < OhqUnit = 3.5. ";
                    }
                    else if ((double) num107 < (double) num4 / 6.0)
                    {
                      tweight2 =  Math.Round((double) tweight2 * 2.75);
                      tid += "IndUnit < OhqUnit = 2.75. ";
                    }
                    else if ((double) num107 < (double) num4 / 5.0)
                    {
                      tweight2 *= 2;
                      tid += "IndUnit < OhqUnit = 2. ";
                    }
                    else if ((double) num107 < (double) num4 / 4.0)
                    {
                      tweight2 =  Math.Round((double) tweight2 * 1.4);
                      tid += "IndUnit < OhqUnit = 1.4. ";
                    }
                    else if ((double) num107 < (double) num4 / 3.0)
                    {
                      tweight2 =  Math.Round((double) tweight2 * 1.1);
                      tid += "IndUnit < OhqUnit = 1.1. ";
                    }
                  }
                  let mut num109: i32 = tweight2;
                  if (num76 >= 1600 & num76 <= 1639)
                  {
                    if ((double) num23 < 1.6599999666214)
                    {
                      if (num105 == 1)
                        tweight2 *= 1;
                      if (num105 == 2)
                        tweight2 *= 1;
                      if (num105 == 3)
                        tweight2 =  Math.Round((double) tweight2 * 0.5);
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.05);
                    }
                    else if ((double) num23 < 3.20000004768372)
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.5);
                      if (num105 == 2)
                        tweight2 =  Math.Round((double) tweight2 * 0.75);
                      if (num105 == 3)
                        tweight2 *= 1;
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.05);
                    }
                    else
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.1);
                      if (num105 == 2)
                        tweight2 =  Math.Round((double) tweight2 * 0.1);
                      if (num105 == 3)
                        tweight2 =  Math.Round((double) tweight2 * 0.75);
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 1.33);
                    }
                  }
                  else if (num93 > 0)
                  {
                    if ((double) num23 < 1.6599999666214)
                    {
                      if (num105 == 1)
                        tweight2 *= 1;
                      if (num105 == 2)
                        tweight2 *= 1;
                      if (num105 == 3)
                        tweight2 =  Math.Round((double) tweight2 * 0.5);
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.05);
                    }
                    else if ((double) num23 < 2.20000004768372)
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.5);
                      if (num105 == 2)
                        tweight2 *= 1;
                      if (num105 == 3)
                        tweight2 =  Math.Round((double) tweight2 * 0.75);
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.05);
                    }
                    else if ((double) num23 < 2.40000009536743)
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.5);
                      if (num105 == 2)
                        tweight2 =  Math.Round((double) tweight2 * 0.9);
                      if (num105 == 3)
                        tweight2 =  Math.Round((double) tweight2 * 0.85);
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.05);
                    }
                    else if ((double) num23 < 2.79999995231628)
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.5);
                      if (num105 == 2)
                        tweight2 =  Math.Round((double) tweight2 * 0.75);
                      if (num105 == 3)
                        tweight2 *= 1;
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.05);
                    }
                    else if ((double) num23 < 4.40000009536743)
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.1);
                      if (num105 == 2)
                        tweight2 =  Math.Round((double) tweight2 * 0.1);
                      if (num105 == 3)
                        tweight2 *= 1;
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 0.75);
                    }
                    else
                    {
                      if (num105 == 1)
                        tweight2 =  Math.Round((double) tweight2 * 0.01);
                      if (num105 == 2)
                        tweight2 =  Math.Round((double) tweight2 * 0.01);
                      if (num105 == 3)
                        tweight2 =  Math.Round((double) tweight2 * 0.3);
                      if (num105 == 4)
                        tweight2 =  Math.Round((double) tweight2 * 1.5);
                    }
                  }
                  else if ((double) num23 < 0.25)
                  {
                    if (num105 == 1)
                      tweight2 *= 1;
                    if (num105 == 2)
                      tweight2 *= 5;
                    if (num105 == 3)
                      tweight2 =  Math.Round((double) tweight2 * 0.25);
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 0.05);
                  }
                  else if ((double) num23 < 0.5)
                  {
                    if (num105 == 1)
                      tweight2 *= 1;
                    if (num105 == 2)
                      tweight2 *= 3;
                    if (num105 == 3)
                      tweight2 =  Math.Round((double) tweight2 * 0.5);
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 0.1);
                  }
                  else if ((double) num23 < 0.75)
                  {
                    if (num105 == 1)
                      tweight2 *= 1;
                    if (num105 == 2)
                      tweight2 *= 2;
                    if (num105 == 3)
                      tweight2 =  Math.Round((double) tweight2 * 0.75);
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 0.2);
                  }
                  else if ((double) num23 < 1.0)
                  {
                    if (num105 == 1)
                      tweight2 =  Math.Round((double) tweight2 * 0.3);
                    if (num105 == 2)
                      tweight2 *= 1;
                    if (num105 == 3)
                      tweight2 *= 1;
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 0.5);
                  }
                  else if ((double) num23 < 1.5)
                  {
                    if (num105 == 1)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 2)
                      tweight2 =  Math.Round((double) tweight2 * 0.5);
                    if (num105 == 3)
                      tweight2 *= 1;
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 0.9);
                  }
                  else if ((double) num23 < 2.0)
                  {
                    if (num105 == 1)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 2)
                      tweight2 =  Math.Round((double) tweight2 * 0.3);
                    if (num105 == 3)
                      tweight2 =  Math.Round((double) tweight2 * 1.1);
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 1.5);
                  }
                  else if ((double) num23 < 3.0)
                  {
                    if (num105 == 1)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 2)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 3)
                      tweight2 =  Math.Round((double) tweight2 * 0.3);
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 1.5);
                  }
                  else
                  {
                    if (num105 == 1)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 2)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 3)
                      tweight2 =  Math.Round((double) tweight2 * 0.01);
                    if (num105 == 4)
                      tweight2 =  Math.Round((double) tweight2 * 1.5);
                  }
                  if (num109 > 0)
                  {
                    float num110 = (float) tweight2 / (float) num109;
                    tid = tid + "UnitsPerFrontHex(" + num23.ToString() + ") = " + num110.ToString() + ". ";
                  }
                  if (tweight2 >= 0)
                  {
                    let mut num111: i32 = 0;
                    if (num75 == 2)
                    {
                      if (!flag4)
                        num111 = 4;
                      if (!flag3)
                        num111 = 3;
                      if (!flag2)
                        num111 = 2;
                      if (flag4 & !flag3 & !flag2 & !flag1)
                        num111 = 5;
                    }
                    simpleList3.Add(num76, tweight2, num111, CheckExistence: false);
                    simpleStringList.Add(tid, 1, num76, num111, CheckExistence: false);
                  }
                }
              }
            }
          }
        }
        num75 += 1;
      }
      while (num75 <= 2);
      SimpleList[] simpleListArray = new SimpleList[DrawMod.TGame.Data.StringListObj[this.slotOobTypes].GetHighestValue(0) + 10 + 1];
      let mut unitCounter3: i32 = this.data.UnitCounter;
      for (let mut index13: i32 = 0; index13 <= unitCounter3; index13 += 1)
      {
        if (this.data.UnitObj[index13].Regime == this.data.Turn & this.data.UnitObj[index13].PreDef == -1 & this.data.UnitObj[index13].HQ > -1)
        {
          let mut index14: i32 = this.data.UnitObj[index13].HQ;
          if (this.data.UnitObj[index13].IsHQ)
            index14 = index13;
          bool flag5 = false;
          bool isIndependent = false;
          bool flag6 = false;
          let mut historical1: i32 = this.data.UnitObj[index13].Historical;
          let mut index15: i32 = this.data.HistoricalUnitObj[historical1].GiveHisVarValue(1);
          let mut num112: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, index15, 3)));
          if (num112 > -1)
          {
            let mut counter: i32 = simpleList3.Counter;
            for (let mut index16: i32 = 0; index16 <= counter; index16 += 1)
            {
              if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, simpleList3.Id[index16], 3))) == num112)
              {
                int[] data4 = simpleList3.Data4;
                int[] numArray2 = data4;
                let mut index17: i32 = index16;
                let mut index18: i32 = index17;
                let mut num113: i32 = data4[index17] + 1;
                numArray2[index18] = num113;
              }
            }
          }
          if (this.data.HistoricalUnitObj[historical1].GiveHisVarValue(11) > 0)
            flag5 = true;
          let mut num114: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, index15, 4)));
          if (num114 > 0)
            isIndependent = true;
          if (num114 < 1)
            flag6 = true;
          let mut hqHisNr: i32 = -1;
          if (index14 > -1)
            hqHisNr = this.data.UnitObj[index14].Historical;
          let mut num115: i32 = -1;
          bool isArmy = false;
          bool isshq = false;
          if (hqHisNr > -1)
            num115 = this.data.HistoricalUnitObj[hqHisNr].Type != 8 ? this.data.UnitObj[index14].HQ : index14;
          if (index14 > -1)
          {
            if (this.data.UnitObj[index14].IsHQ)
              isArmy = true;
            if (hqHisNr > -1 && this.data.HistoricalUnitObj[hqHisNr].Type == 8)
              isArmy = false;
          }
          if (this.data.HistoricalUnitObj[historical1].Type == 8)
            isshq = true;
          if (flag5)
            isArmy = false;
          if (!flag5)
          {
            bool flag7 = true;
            if (isArmy & !isIndependent & this.data.UnitObj[index13].IsHQ)
            {
              flag7 = false;
              let mut row: i32 = this.data.StringListObj[this.slotOobTypes].FindRow(0, index15);
              if (row > -1)
              {
                let mut num116: i32 = 0;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 13])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 14])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 15])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 16])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 17])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 18])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 19])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 20])) > 0)
                  num116 += 1;
                if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, 21])) > 0)
                  num116 += 1;
                let mut num117: i32 = 0;
                let mut unitCounter4: i32 = this.data.UnitCounter;
                for (let mut index19: i32 = 0; index19 <= unitCounter4; index19 += 1)
                {
                  if (this.data.UnitObj[index19].HQ == index14 & this.data.UnitObj[index19].Historical > -1 &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, this.data.HistoricalUnitObj[this.data.UnitObj[index19].Historical].GiveHisVarValue(1), 4))) < 1)
                    num117 += 1;
                }
                if (num117 >= num116)
                  flag7 = true;
                else if (this.data.UnitObj[index14].SupplyIn > 0)
                {
                  SimpleList simpleList7 = SimpleList::new();
                  SimpleList SL = SimpleList::new();
                  if (row > -1)
                  {
                    let mut index20: i32 = 13;
                    do
                    {
                      let mut tid: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[row, index20]));
                      if (tid > 0)
                        simpleList7.AddWeight(tid, 1);
                      index20 += 1;
                    }
                    while (index20 <= 21);
                    let mut unitCounter5: i32 = this.data.UnitCounter;
                    for (let mut index21: i32 = 0; index21 <= unitCounter5; index21 += 1)
                    {
                      if (this.data.UnitObj[index21].HQ == index14)
                      {
                        let mut historical2: i32 = this.data.UnitObj[index21].Historical;
                        if (historical2 > -1 & this.data.UnitObj[index21].PreDef == -1 & this.data.UnitObj[index21].Regime == this.data.Turn)
                        {
                          let mut tid: i32 = this.data.HistoricalUnitObj[historical2].GiveHisVarValue(2);
                          if (tid == 215)
                            tid = tid;
                          let mut num118: i32 = this.data.HistoricalUnitObj[historical2].GiveHisVarValue(1);
                          if (index15 == num118)
                            SL.AddWeight(tid, 1);
                        }
                      }
                    }
                    simpleList7.RemoveWeight( SL);
                    simpleList7.removeWeight0orLower();
                    if (simpleList7.Counter > -1)
                    {
                      let mut nr: i32 = simpleList3.FindNr(index15);
                      if (nr > -1 && simpleList3.Data5[nr] < 1)
                      {
                        simpleList3.Add(simpleList3.Id[nr], simpleList3.Weight[nr], simpleList3.Data1[nr], simpleList3.Data2[nr], simpleList3.Data3[nr], simpleList3.Data4[nr], simpleList3.Data5[nr], false);
                        let mut counter: i32 = simpleList3.Counter;
                        simpleList3.Weight[counter] = simpleList3.Weight[counter] * 10;
                        simpleStringList.Add("Copy of earlier OOB #" + simpleList3.Id[nr].ToString() + " => MissingUnitMod= *10", 1, simpleList3.Id[counter], simpleList3.Data1[counter], 2, CheckExistence: false);
                        simpleList3.Data3[counter] = this.data.HistoricalUnitObj[hqHisNr].ID;
                        simpleList3.Data5[counter] = simpleList7.Id[0];
                      }
                    }
                  }
                }
              }
            }
            SimpleList upgradeOrDowngradeList;
            if (Information.IsNothing((object) simpleListArray[index15]))
            {
              upgradeOrDowngradeList = DrawMod.TGame.EventRelatedObj.GetUpgradeOrDowngradeList(index15, true, false, isIndependent, hqHisNr, isArmy, isshq);
              simpleListArray[index15] = upgradeOrDowngradeList;
            }
            else
              upgradeOrDowngradeList = simpleListArray[index15];
            if (upgradeOrDowngradeList.Counter > -1 && flag7)
            {
              let mut counter3: i32 = upgradeOrDowngradeList.Counter;
              for (let mut index22: i32 = 0; index22 <= counter3; index22 += 1)
              {
                let mut counter4: i32 = simpleList3.Counter;
                for (let mut index23: i32 = 0; index23 <= counter4; index23 += 1)
                {
                  if (simpleList3.Id[index23] == upgradeOrDowngradeList.Id[index22] & simpleList3.Data3[index23] < 1)
                  {
                    let mut index24: i32 = index23;
                    if (index24 > -1 && simpleList3.Weight[index24] > 0 & simpleList3.Data3[index24] < 1)
                    {
                      simpleList3.Add(simpleList3.Id[index24], simpleList3.Weight[index24], simpleList3.Data1[index24], simpleList3.Data2[index24], simpleList3.Data3[index24], simpleList3.Data4[index24], simpleList3.Data5[index24], false);
                      let mut counter5: i32 = simpleList3.Counter;
                      if (hqHisNr > -1)
                        simpleList3.Data3[counter5] = this.data.HistoricalUnitObj[historical1].ID;
                      else if (hqHisNr > -1)
                        simpleList3.Data3[counter5] = this.data.HistoricalUnitObj[hqHisNr].ID;
                      float num119 = 0.0f;
                      if (isIndependent)
                        num119 = 0.2f;
                      if ((double) num23 < 0.150000005960464 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) ((float) simpleList3.Weight[counter5] * 0.2f));
                        simpleStringList.Add("UpgradeMod=0.2", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 0.300000011920929 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) ((float) simpleList3.Weight[counter5] * 0.4f));
                        simpleStringList.Add("UpgradeMod=0.4", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 0.449999988079071 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) simpleList3.Weight[counter5] * 0.6);
                        simpleStringList.Add("UpgradeMod=0.6", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 0.600000023841858 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) simpleList3.Weight[counter5] * 0.8);
                        simpleStringList.Add("UpgradeMod=0.8", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 0.800000011920929 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) simpleList3.Weight[counter5] * 0.9);
                        simpleStringList.Add("UpgradeMod=0.9", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 1.0 + (double) num119)
                      {
                        simpleList3.Weight[counter5] = simpleList3.Weight[counter5] * 1;
                        simpleStringList.Add("UpgradeMod=1", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 1.25 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) simpleList3.Weight[counter5] * 1.3);
                        simpleStringList.Add("UpgradeMod=1.3", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else if ((double) num23 < 1.5 + (double) num119)
                      {
                        simpleList3.Weight[counter5] =  Math.Round((double) simpleList3.Weight[counter5] * 1.6);
                        simpleStringList.Add("UpgradeMod=1.6", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                      else
                      {
                        simpleList3.Weight[counter5] = simpleList3.Weight[counter5] * 2;
                        simpleStringList.Add("UpgradeMod=2", 1, simpleList3.Id[counter5], simpleList3.Data1[counter5], 1, CheckExistence: false);
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      let mut counter6: i32 = simpleList3.Counter;
      for (let mut index25: i32 = 0; index25 <= counter6; index25 += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, simpleList3.Id[index25], 4))) == 1)
        {
          if (simpleList3.Data4[index25] > 2)
            simpleList3.Weight[index25] = simpleList3.Weight[index25] * 1;
          else if (simpleList3.Data4[index25] > 1)
          {
            simpleList3.Weight[index25] =  Math.Round((double) simpleList3.Weight[index25] * 1.2);
            simpleStringList.Add("Indep. already more than 1 = x1.2", 1, simpleList3.Id[index25], simpleList3.Data1[index25], CheckExistence: false);
          }
          else if (simpleList3.Data4[index25] > 0)
          {
            simpleList3.Weight[index25] =  Math.Round((double) simpleList3.Weight[index25] * 1.4);
            simpleStringList.Add("Indep. already more than 0 = x1.4", 1, simpleList3.Id[index25], simpleList3.Data1[index25], CheckExistence: false);
          }
          else
          {
            simpleList3.Weight[index25] =  Math.Round((double) simpleList3.Weight[index25] * 1.6);
            simpleStringList.Add("Indep. not yet any 0 = x1.6", 1, simpleList3.Id[index25], simpleList3.Data1[index25], CheckExistence: false);
          }
        }
        else if (simpleList3.Data4[index25] < 1)
        {
          simpleList3.Weight[index25] =  Math.Round((double) simpleList3.Weight[index25] * 1.3);
          simpleStringList.Add("Multi-unit not present yet = x1.3", 1, simpleList3.Id[index25], simpleList3.Data1[index25], CheckExistence: false);
        }
      }
      simpleList3.ReverseSort();
      let mut counter7: i32 = simpleList3.Counter;
      for (let mut index26: i32 = 0; index26 <= counter7; index26 += 1)
      {
        s: String = "Wgt = " + simpleList3.Weight[index26].ToString() + " for #" + simpleList3.Id[index26].ToString() + ": " + this.data.StringListObj[this.slotOobTypes].GetData(0, simpleList3.Id[index26], 1) + " .. data1(0=norm,1=cheap)=" + simpleList3.Data1[index26].ToString() + "  data3(upg existing OHQ)=" + simpleList3.Data3[index26].ToString() + ", data5(missing ToeID)=" + simpleList3.Data5[index26].ToString();
        let mut counter8: i32 = simpleStringList.Counter;
        for (let mut index27: i32 = 0; index27 <= counter8; index27 += 1)
        {
          if (simpleStringList.Data1[index27] == simpleList3.Id[index26] && simpleStringList.Data2[index27] == simpleList3.Data1[index26])
          {
            if (simpleStringList.Data3[index27] < 1 & simpleList3.Data3[index26] < 1 & simpleList3.Data5[index26] < 1)
              s = s + ". " + simpleStringList.Id[index27];
            else if (simpleStringList.Data3[index27] == 1 & simpleList3.Data3[index26] > 0 & simpleList3.Data5[index26] < 1)
              s = s + ". " + simpleStringList.Id[index27];
            else if (simpleStringList.Data3[index27] == 2 & simpleList3.Data3[index26] > 0 & simpleList3.Data5[index26] > 0)
              s = s + ". " + simpleStringList.Id[index27];
          }
        }
        this.ai.AddLog(s);
        this.ai.AddLog("");
        if (simpleList3.Weight[index26] > 0)
          preferenceOobPool.Add(simpleList3.Id[index26], 0, this.zoneList.Data1[0], this.zoneList.Data2[0], simpleList3.Data3[index26], simpleList3.Data5[index26], simpleList3.Data1[index26], false);
      }
      if (logaddition.Length > 1)
        this.ai.WriteLog(str1);
      this.ai.LogCounter = logCounter1;
      this.ai.LogTxt = new string[this.ai.LogCounter + 10 + 1];
      let mut logCounter3: i32 = this.ai.LogCounter;
      for (let mut index28: i32 = 0; index28 <= logCounter3; index28 += 1)
        this.ai.LogTxt[index28] = strArray[index28];
      return preferenceOobPool;
    }

    pub SimpleList GetPoolAssetPreference_IndustryPointsPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList simpleList3 = SimpleList::new();
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter; index += 1)
      {
        if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 401))
          simpleList3.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
      }
      simpleList3.ReverseSort();
      if (simpleList3.Counter > -1)
      {
        let mut tweight: i32 = 100;
        RL.Add(401, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
      }
      SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(401);
      if (thatCanUpgradeToo.Counter > -1)
      {
        let mut tweight: i32 = 150;
        RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_OilPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList simpleList3 = SimpleList::new();
      let mut counter1: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter1; index += 1)
      {
        let mut num: i32 = this.zoneList.Id[index];
        CoordList coordList2 = this.MakeCoordListFamilyAssetPresent(num, 231);
        Coordinate bestMine = this.ai.game.EventRelatedObj.Helper_GetBestMine("SE_Data", "SE_Random", num, 1, CL: ( coordList2));
        if (bestMine.onmap)
          simpleList3.Add(num, bestMine.data1, bestMine.x, bestMine.y);
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(200, simpleList3.Data1[0], simpleList3.Data2[0], 231);
          RL.Add(231, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo1 = this.GetPublicAssetsThatCanUpgradeToo(231);
      if (thatCanUpgradeToo1.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(300, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0], thatCanUpgradeToo1.Id[0]);
        RL.Add(thatCanUpgradeToo1.Id[0], tweight, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0]);
      }
      SimpleList simpleList4 = SimpleList::new();
      let mut counter2: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter2; index += 1)
      {
        if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 341))
          simpleList4.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
      }
      simpleList4.ReverseSort();
      if (simpleList4.Counter > -1)
      {
        let mut num: i32 = 100;
        let mut tweight: i32 = !(this.itemProduction[7] > this.itemNeed[7] * 4 | this.itemProduction[7] - this.itemNeed[7] > 700) ? (!(this.itemProduction[7] > this.itemNeed[7] * 3 | this.itemProduction[7] - this.itemNeed[7] > 500) ? (!(this.itemProduction[7] > this.itemNeed[7] * 2 | this.itemProduction[7] - this.itemNeed[7] > 300) ? (!(this.itemProduction[7] >  Math.Round((double) this.itemNeed[7] * 1.5) | this.itemProduction[7] - this.itemNeed[7] > 200) ? 0 :  Math.Round((double) num / 20.0)) :  Math.Round((double) num / 2.0)) : num * 1) : num * 2;
        if (this.itemProduction[7] < this.itemNeed[7] + 300)
          tweight = 0;
        if (tweight > 0)
          RL.Add(341, tweight, simpleList4.Data1[0], simpleList4.Data2[0]);
      }
      SimpleList thatCanUpgradeToo2 = this.GetPublicAssetsThatCanUpgradeToo(341);
      if (thatCanUpgradeToo2.Counter > -1)
      {
        let mut num: i32 = 150;
        let mut tweight: i32 = !(this.itemProduction[7] > this.itemNeed[7] * 4 | this.itemProduction[7] - this.itemNeed[7] > 1000) ? (!(this.itemProduction[7] > this.itemNeed[7] * 3 | this.itemProduction[7] - this.itemNeed[7] > 600) ? (!(this.itemProduction[7] > this.itemNeed[7] * 2 | this.itemProduction[7] - this.itemNeed[7] > 350) ? (!(this.itemProduction[7] >  Math.Round((double) this.itemNeed[7] * 1.5) | this.itemProduction[7] - this.itemNeed[7] > 200) ? 0 :  Math.Round((double) num / 20.0)) :  Math.Round((double) num / 2.0)) : num * 1) : num * 2;
        if (this.itemProduction[7] < this.itemNeed[7] + 500 * thatCanUpgradeToo2.Weight[0])
          tweight = 0;
        if (tweight > 0)
          RL.Add(thatCanUpgradeToo2.Id[0], tweight, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0]);
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub void RemoveImpossibleConstructionFromList( SimpleList RL)
    {
      let mut index1: i32 = -1;
      for (let mut counter1: i32 = RL.Counter; counter1 >= 0; counter1 += -1)
      {
        let mut x: i32 = RL.Data1[counter1];
        let mut y: i32 = RL.Data2[counter1];
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, this.zones.Value[x, y], 6)));
        if (id > 0)
          index1 = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
        if (index1 > -1)
        {
          SimpleStringList simpleStringList = !(this.data.LocObj[index1].X == x & this.data.LocObj[index1].Y == y) ? DrawMod.TGame.EventRelatedObj.Helper_GetConstructList(this.RegimeId, x, y, RL.Id[counter1], true, false, false) : DrawMod.TGame.EventRelatedObj.Helper_GetConstructList(this.RegimeId, x, y, RL.Id[counter1], true, false, true);
          bool flag = true;
          let mut counter2: i32 = simpleStringList.Counter;
          for (let mut index2: i32 = 0; index2 <= counter2; index2 += 1)
          {
            if (simpleStringList.Data1[index2] == RL.Id[counter1] && simpleStringList.Data2[index2] > 0)
              flag = false;
          }
          if (flag)
            RL.RemoveNr(counter1);
        }
        else
          RL.RemoveNr(counter1);
      }
    }

    pub SimpleList GetPoolAssetPreference_BPPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList thatCanUpgradeToo1 = this.GetPublicAssetsThatCanUpgradeToo(601);
      if (thatCanUpgradeToo1.Counter > -1)
      {
        let mut tweight: i32 =  Math.Round((double) (5 * this.data.Round) / (double) Math.Max(1, thatCanUpgradeToo1.Weight[0]));
        RL.Add(thatCanUpgradeToo1.Id[0], tweight, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0]);
      }
      SimpleList simpleList3 = SimpleList::new();
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter; index += 1)
      {
        if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3241))
          simpleList3.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
      }
      simpleList3.ReverseSort();
      if (simpleList3.Counter > -1)
      {
        let mut tweight: i32 = 100;
        RL.Add(3241, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
      }
      SimpleList thatCanUpgradeToo2 = this.GetPublicAssetsThatCanUpgradeToo(3241);
      if (thatCanUpgradeToo2.Counter > -1)
      {
        let mut tweight: i32 = 200;
        RL.Add(thatCanUpgradeToo2.Id[0], tweight, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0]);
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_WaterPool()
    {
      let mut num1: i32 =  Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotGameKeys].GetData(0, 6, 2)));
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList simpleList3 = SimpleList::new();
      let mut counter1: i32 = this.zoneList.Counter;
      int index;
      Coordinate coordinate;
      for (index = 0; index <= counter1; index += 1)
      {
        let mut num2: i32 = this.zoneList.Id[index];
        CoordList coordList2 = this.MakeCoordListFamilyAssetPresent(num2, 241);
        coordinate = this.ai.game.EventRelatedObj.Helper_GetBestMine("SE_Data", "SE_Random", num2, 5, CL: ( coordList2));
        if (coordinate.onmap)
          simpleList3.Add(num2, coordinate.data1, coordinate.x, coordinate.y);
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(700, simpleList3.Data1[0], simpleList3.Data2[0], 241);
          RL.Add(241, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo1 = this.GetPublicAssetsThatCanUpgradeToo(241);
      if (thatCanUpgradeToo1.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(900, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0], thatCanUpgradeToo1.Id[0]);
        RL.Add(thatCanUpgradeToo1.Id[0], tweight, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0]);
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 47, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList4 = SimpleList::new();
        let mut counter2: i32 = this.zoneList.Counter;
        for (index = 0; index <= counter2; index += 1)
        {
          let mut num3: i32 = this.zoneList.Id[index];
          CoordList coordList3 = this.MakeCoordListFamilyAssetPresent(num3, 331);
          coordinate = this.ai.game.EventRelatedObj.Helper_GetBestWaterPurification("SE_Data", "SE_Random", num3, CL: ( coordList3));
          if (coordinate.onmap)
            simpleList4.Add(num3, coordinate.data1, coordinate.x, coordinate.y);
          simpleList4.ReverseSort();
          if (simpleList4.Counter > -1)
          {
            let mut tweight: i32 = 1200;
            RL.Add(331, tweight, simpleList4.Data1[0], simpleList4.Data2[0]);
          }
        }
        SimpleList thatCanUpgradeToo2 = this.GetPublicAssetsThatCanUpgradeToo(331);
        if (thatCanUpgradeToo2.Counter > -1)
        {
          let mut tweight: i32 = 1600;
          RL.Add(thatCanUpgradeToo2.Id[0], tweight, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0]);
        }
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 20, 1, this.RegimeId, 2))) >= 100 && num1 < 4)
      {
        SimpleList simpleList5 = SimpleList::new();
        let mut counter3: i32 = this.zoneList.Counter;
        for (index = 0; index <= counter3; index += 1)
        {
          let mut num4: i32 = this.zoneList.Id[index];
          CoordList coordList4 = this.MakeCoordListFamilyAssetPresent(num4, 321);
          coordinate = this.ai.game.EventRelatedObj.Helper_GetBestMountain("SE_Data", "SE_Random", num4, CL: ( coordList4));
          if (coordinate.onmap)
            simpleList5.Add(num4, coordinate.data1, coordinate.x, coordinate.y);
          simpleList5.ReverseSort();
          if (simpleList5.Counter > -1)
          {
            let mut tweight: i32 = 200;
            RL.Add(321, tweight, simpleList5.Data1[0], simpleList5.Data2[0]);
          }
        }
        SimpleList thatCanUpgradeToo3 = this.GetPublicAssetsThatCanUpgradeToo(321);
        if (thatCanUpgradeToo3.Counter > -1)
        {
          let mut tweight: i32 = 300;
          RL.Add(thatCanUpgradeToo3.Id[0], tweight, thatCanUpgradeToo3.Data2[0], thatCanUpgradeToo3.Data3[0]);
        }
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 47, 1, this.RegimeId, 2))) >= 100 && this.shqStage >= 4)
      {
        SimpleList simpleList6 = SimpleList::new();
        let mut counter4: i32 = this.zoneList.Counter;
        for (index = 0; index <= counter4; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3051))
            simpleList6.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList6.ReverseSort();
        if (simpleList6.Counter > -1)
        {
          let mut num5: i32 = 100;
          let mut tweight: i32 = this.itemProduction[15] <= this.itemNeed[15] + 1750 ? (this.itemProduction[15] <= this.itemNeed[15] + 900 ? (this.itemProduction[15] <= this.itemNeed[15] + 450 ? (this.itemProduction[15] <= this.itemNeed[15] + 250 ? 0 :  Math.Round((double) num5 / 20.0)) :  Math.Round((double) num5 / 2.0)) : num5) : num5 * 2;
          RL.Add(3051, tweight, simpleList6.Data1[0], simpleList6.Data2[0]);
        }
        SimpleList thatCanUpgradeToo4 = this.GetPublicAssetsThatCanUpgradeToo(3051);
        if (thatCanUpgradeToo4.Counter > -1)
        {
          let mut num6: i32 = 150;
          let mut tweight: i32 = this.itemProduction[15] <= this.itemNeed[15] + 1750 ? (this.itemProduction[15] <= this.itemNeed[15] + 900 ? (this.itemProduction[15] <= this.itemNeed[15] + 450 ? (this.itemProduction[15] <= this.itemNeed[15] + 250 ? 0 :  Math.Round((double) num6 / 20.0)) :  Math.Round((double) num6 / 2.0)) : num6) : num6 * 2;
          RL.Add(thatCanUpgradeToo4.Id[0], tweight, thatCanUpgradeToo4.Data2[0], thatCanUpgradeToo4.Data3[0]);
        }
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 114, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList7 = SimpleList::new();
        let mut counter5: i32 = this.zoneList.Counter;
        for (index = 0; index <= counter5; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3061))
            simpleList7.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList7.ReverseSort();
        if (simpleList7.Counter > -1)
        {
          let mut tweight: i32 = 50;
          RL.Add(3061, tweight, simpleList7.Data1[0], simpleList7.Data2[0]);
        }
        SimpleList thatCanUpgradeToo5 = this.GetPublicAssetsThatCanUpgradeToo(3061);
        if (thatCanUpgradeToo5.Counter > -1)
        {
          let mut tweight: i32 = 80;
          RL.Add(thatCanUpgradeToo5.Id[0], tweight, thatCanUpgradeToo5.Data2[0], thatCanUpgradeToo5.Data3[0]);
        }
      }
      if (this.data.Turn == 6)
        ;
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub CoordList MakeCoordListFamilyAssetPresent(int ZoneId, int forFamilyId)
    {
      CoordList coordList = CoordList::new();
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, forFamilyId, 3)));
      let mut num2: i32 = -1;
      if (num1 == 1)
        num2 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, forFamilyId, 4)));
      let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 0])) == ZoneId)
        {
          let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 14)));
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 4)));
          if (num3 == forFamilyId)
          {
            let mut x: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 3]));
            let mut y: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 4]));
            coordList.AddCoord(x, y, 0);
          }
          else if (num4 == num2 & num2 > 0)
          {
            let mut x: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 3]));
            let mut y: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 4]));
            coordList.AddCoord(x, y, 0);
          }
        }
      }
      return coordList;
    }

    pub SimpleList GetPoolAssetPreference_MetalPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList simpleList3 = SimpleList::new();
      let mut counter1: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter1; index += 1)
      {
        let mut num: i32 = this.zoneList.Id[index];
        CoordList coordList2 = this.MakeCoordListFamilyAssetPresent(num, 205);
        Coordinate bestMine = this.ai.game.EventRelatedObj.Helper_GetBestMine("SE_Data", "SE_Random", num, 2, CL: ( coordList2));
        if (bestMine.onmap)
          simpleList3.Add(num, bestMine.data1, bestMine.x, bestMine.y);
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(800, simpleList3.Data1[0], simpleList3.Data2[0], 205);
          RL.Add(205, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo1 = this.GetPublicAssetsThatCanUpgradeToo(205);
      if (thatCanUpgradeToo1.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(1200, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0], thatCanUpgradeToo1.Id[0]);
        RL.Add(thatCanUpgradeToo1.Id[0], tweight, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0]);
      }
      SimpleList simpleList4 = SimpleList::new();
      let mut counter2: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter2; index += 1)
      {
        let mut num: i32 = this.zoneList.Id[index];
        CoordList coordList3 = this.MakeCoordListFamilyAssetPresent(num, 206);
        Coordinate bestScavenge = this.ai.game.EventRelatedObj.Helper_GetBestScavenge("SE_Data", "SE_Random", num, CL: ( coordList3));
        if (bestScavenge.onmap)
        {
          if ( Math.Round(Conversion.Val(this.data.Designer)) >= 97)
          {
            data: DataClass = this.data;
            str: String = "artifactType";
             local: String =  str;
            let mut libVar: i32 = data.FindLibVar( local, "SE_Data");
            if (this.data.MapObj[0].HexObj[bestScavenge.x, bestScavenge.y].GetHexLibVarValue(libVar) > 0)
              bestScavenge.data1 *= 9;
          }
          simpleList4.Add(num, bestScavenge.data1, bestScavenge.x, bestScavenge.y);
        }
        simpleList4.ReverseSort();
        if (simpleList4.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfScavengeLeft(400, simpleList4.Data1[0], simpleList4.Data2[0], 206);
          if ( Math.Round(Conversion.Val(this.data.Designer)) >= 97)
          {
            data: DataClass = this.data;
            str: String = "artifactType";
             local: String =  str;
            let mut libVar: i32 = data.FindLibVar( local, "SE_Data");
            if (this.data.MapObj[0].HexObj[simpleList4.Data1[0], simpleList4.Data2[0]].GetHexLibVarValue(libVar) > 0)
              tweight *= 4;
          }
          RL.Add(206, tweight, simpleList4.Data1[0], simpleList4.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo2 = this.GetPublicAssetsThatCanUpgradeToo(206);
      if (thatCanUpgradeToo2.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfScavengeLeft(600, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0], thatCanUpgradeToo2.Id[0]);
        RL.Add(thatCanUpgradeToo2.Id[0], tweight, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0]);
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 115, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList5 = SimpleList::new();
        let mut counter3: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter3; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3071))
            simpleList5.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList5.ReverseSort();
        if (simpleList5.Counter > -1)
        {
          let mut tweight: i32 = 50;
          RL.Add(3071, tweight, simpleList5.Data1[0], simpleList5.Data2[0]);
        }
        SimpleList thatCanUpgradeToo3 = this.GetPublicAssetsThatCanUpgradeToo(3071);
        if (thatCanUpgradeToo3.Counter > -1)
        {
          let mut tweight: i32 = 100;
          RL.Add(thatCanUpgradeToo3.Id[0], tweight, thatCanUpgradeToo3.Data2[0], thatCanUpgradeToo3.Data3[0]);
        }
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_RarePool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList simpleList3 = SimpleList::new();
      let mut counter1: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter1; index += 1)
      {
        let mut num: i32 = this.zoneList.Id[index];
        CoordList coordList2 = this.MakeCoordListFamilyAssetPresent(num, 211);
        Coordinate bestMine = this.ai.game.EventRelatedObj.Helper_GetBestMine("SE_Data", "SE_Random", num, 3, CL: ( coordList2));
        if (bestMine.onmap)
          simpleList3.Add(num, bestMine.data1, bestMine.x, bestMine.y);
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(300, simpleList3.Data1[0], simpleList3.Data2[0], 211);
          RL.Add(211, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo1 = this.GetPublicAssetsThatCanUpgradeToo(211);
      if (thatCanUpgradeToo1.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(400, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0], thatCanUpgradeToo1.Id[0]);
        RL.Add(thatCanUpgradeToo1.Id[0], tweight, thatCanUpgradeToo1.Data2[0], thatCanUpgradeToo1.Data3[0]);
      }
      SimpleList simpleList4 = SimpleList::new();
      let mut counter2: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter2; index += 1)
      {
        let mut num: i32 = this.zoneList.Id[index];
        CoordList coordList3 = this.MakeCoordListFamilyAssetPresent(num, 206);
        Coordinate bestScavenge = this.ai.game.EventRelatedObj.Helper_GetBestScavenge("SE_Data", "SE_Random", num, CL: ( coordList3));
        if (bestScavenge.onmap)
          simpleList4.Add(num, bestScavenge.data1, bestScavenge.x, bestScavenge.y);
        simpleList4.ReverseSort();
        if (simpleList4.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfScavengeLeft(100, simpleList4.Data2[0], simpleList4.Data3[0], 206);
          RL.Add(206, tweight, simpleList4.Data1[0], simpleList4.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo2 = this.GetPublicAssetsThatCanUpgradeToo(206);
      if (thatCanUpgradeToo2.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfScavengeLeft(125, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0], thatCanUpgradeToo2.Id[0]);
        RL.Add(thatCanUpgradeToo2.Id[0], tweight, thatCanUpgradeToo2.Data2[0], thatCanUpgradeToo2.Data3[0]);
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 115, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList5 = SimpleList::new();
        let mut counter3: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter3; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3071))
            simpleList5.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList5.ReverseSort();
        if (simpleList5.Counter > -1)
        {
          let mut tweight: i32 = 50;
          RL.Add(3071, tweight, simpleList5.Data1[0], simpleList5.Data2[0]);
        }
        SimpleList thatCanUpgradeToo3 = this.GetPublicAssetsThatCanUpgradeToo(3071);
        if (thatCanUpgradeToo3.Counter > -1)
        {
          let mut tweight: i32 = 100;
          RL.Add(thatCanUpgradeToo3.Id[0], tweight, thatCanUpgradeToo3.Data2[0], thatCanUpgradeToo3.Data3[0]);
        }
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_AtomicsPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList RL = SimpleList::new();
      SimpleList simpleList3 = SimpleList::new();
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter; index += 1)
      {
        let mut num: i32 = this.zoneList.Id[index];
        CoordList coordList2 = this.MakeCoordListFamilyAssetPresent(num, 3251);
        Coordinate bestMine = this.ai.game.EventRelatedObj.Helper_GetBestMine("SE_Data", "SE_Random", num, 4, CL: ( coordList2));
        if (bestMine.onmap)
          simpleList3.Add(num, bestMine.data1, bestMine.x, bestMine.y);
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(300, simpleList3.Data1[0], simpleList3.Data2[0], 3251);
          RL.Add(3251, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
      }
      SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(3251);
      if (thatCanUpgradeToo.Counter > -1)
      {
        let mut tweight: i32 = this.ai.game.EventRelatedObj.Helper_ModifyWeightForNumberOfTurnOfReservesLeft(400, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0], thatCanUpgradeToo.Id[0]);
        RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_EnergyPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList RL = SimpleList::new();
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 21, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList3 = SimpleList::new();
        let mut counter: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          let mut num: i32 = this.zoneList.Id[index];
          CoordList coordList2 = this.MakeCoordListFamilyAssetPresent(num, 361);
          Coordinate bestFarm = this.ai.game.EventRelatedObj.Helper_GetBestFarm("SE_Data", num, true, CL: ( coordList2), useCache: true);
          if (bestFarm.onmap)
            simpleList3.Add(num, bestFarm.data1, bestFarm.x, bestFarm.y);
          simpleList3.ReverseSort();
          if (simpleList3.Counter > -1)
          {
            let mut tweight: i32 = 200;
            RL.Add(361, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
          }
        }
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(361);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 = 250;
          RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 7, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList4 = SimpleList::new();
        let mut counter: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 271))
            simpleList4.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList4.ReverseSort();
        if (simpleList4.Counter > -1)
        {
          let mut num: i32 = 400;
          let mut tweight: i32 = this.itemProduction[1] <= this.itemNeed[1] + 750 ? (this.itemProduction[1] <= this.itemNeed[1] + 500 ? (this.itemProduction[1] <= this.itemNeed[1] + 250 ? (this.itemProduction[1] <= this.itemNeed[1] + 150 ? 0 :  Math.Round((double) num / 20.0)) :  Math.Round((double) num / 2.0)) : num) : num * 2;
          RL.Add(271, tweight, simpleList4.Data1[0], simpleList4.Data2[0]);
        }
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(271);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut num: i32 = 500;
          let mut tweight: i32 = this.itemProduction[1] <= this.itemNeed[1] + 750 ? (this.itemProduction[1] <= this.itemNeed[1] + 500 ? (this.itemProduction[1] <= this.itemNeed[1] + 250 ? (this.itemProduction[1] <= this.itemNeed[1] + 150 ? 0 :  Math.Round((double) num / 20.0)) :  Math.Round((double) num / 2.0)) : num) : num * 2;
          RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 109, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList5 = SimpleList::new();
        let mut counter: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3021))
            simpleList5.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList5.ReverseSort();
        if (simpleList5.Counter > -1)
        {
          let mut tweight: i32 = 300;
          if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 2)
            tweight = 0;
          else if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 10)
            tweight =  Math.Round((double) tweight / 10.0);
          else if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 20)
            tweight =  Math.Round((double) tweight / 2.0);
          RL.Add(3021, tweight, simpleList5.Data1[0], simpleList5.Data2[0]);
        }
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(3021);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 = 350;
          if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 10)
            tweight = 0;
          else if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 20)
            tweight =  Math.Round((double) tweight / 10.0);
          else if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 40)
            tweight =  Math.Round((double) tweight / 2.0);
          else if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 80)
            tweight =  Math.Round((double) tweight * 0.9);
          RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_MachinePool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList = CoordList::new();
      SimpleList RL = SimpleList::new();
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 4, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList3 = SimpleList::new();
        let mut counter: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 251))
            simpleList3.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = 400;
          RL.Add(251, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(251);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 = 600;
          RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_HiTechPool()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList = CoordList::new();
      SimpleList RL = SimpleList::new();
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 324, 1, this.RegimeId, 2))) >= 100)
      {
        SimpleList simpleList3 = SimpleList::new();
        let mut counter: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 3231))
            simpleList3.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList3.ReverseSort();
        if (simpleList3.Counter > -1)
        {
          let mut tweight: i32 = 400;
          RL.Add(3231, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
        }
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(3231);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 = 600;
          RL.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      this.RemoveImpossibleConstructionFromList( RL);
      return RL;
    }

    pub SimpleList GetPoolAssetPreference_FoodPool()
    {
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 8, 2)));
      let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0));
      let mut num2: i32 = DrawMod.TGame.Data.StringListObj[stringListById].Length + 1;
      bool[] flagArray = new bool[100];
      let mut logCounter: i32 = this.data.UnitObj[this.shqUnitNr].LogCounter;
      for (let mut index: i32 = 0; index <= logCounter; index += 1)
      {
        if (this.data.UnitObj[this.shqUnitNr].LogData1[index] > 0 && this.data.UnitObj[this.shqUnitNr].LogType[index] == 301 & this.data.UnitObj[this.shqUnitNr].LogData3[index] > 0)
          flagArray[this.data.UnitObj[this.shqUnitNr].LogData1[index]] = true;
      }
      let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 20, 2)));
      let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 21, 2)));
      let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 22, 2)));
      let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 23, 2)));
      let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 24, 2)));
      let mut num8: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 25, 2)));
      let mut num9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 26, 2)));
      let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 30, 2)));
      let mut num11: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 31, 2)));
      let mut num12: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 32, 2)));
      let mut num13: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 33, 2)));
      let mut num14: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 34, 2)));
      let mut num15: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 35, 2)));
      let mut num16: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 36, 2)));
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      CoordList coordList1 = CoordList::new();
      SimpleList preferenceFoodPool = SimpleList::new();
      let mut num17: i32 = 30;
      let mut num18: i32 = 0;
      let mut num19: i32 = 30;
      let mut num20: i32 = 999;
      let mut num21: i32 = 999;
      let mut num22: i32 = 999;
      Coordinate bestFarm;
      bestFarm.onmap = false;
      bestFarm.data1 = 0;
      let mut counter1: i32 = this.zoneList.Counter;
      for (let mut index: i32 = 0; index <= counter1; index += 1)
      {
        let mut tid: i32 = this.zoneList.Id[index];
        EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
        let mut zoneId: i32 = tid;
        CoordList coordList2 = (CoordList) null;
         CoordList local =  coordList2;
        bestFarm = eventRelatedObj.Helper_GetBestFarm("SE_Data", zoneId, CL: ( local), useCache: true);
        Coordinate coordinate;
        if (bestFarm.onmap & bestFarm.data1 > coordinate.data1)
          simpleList1.Add(tid, bestFarm.data1, bestFarm.x, bestFarm.y);
        simpleList1.ReverseSort();
        if (simpleList1.Counter > -1 & simpleList1.Weight[0] > coordinate.data1)
        {
          coordinate.onmap = true;
          coordinate.data1 = simpleList1.Weight[0];
          coordinate.x = simpleList1.Data1[0];
          coordinate.y = simpleList1.Data1[0];
        }
      }
      let mut mapWidth: i32 = this.ai.game.Data.MapObj[0].MapWidth;
      int num23;
      for (let mut index1: i32 = 0; index1 <= mapWidth; index1 += 1)
      {
        let mut mapHeight: i32 = this.ai.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.zones.Value[index1, index2] > 0 && this.zoneList.FindNr(this.zones.Value[index1, index2]) > -1)
          {
            if (this.tempSummerMatrix.Value[index1, index2] > num18)
              num18 = this.tempSummerMatrix.Value[index1, index2];
            if (this.tempWinterMatrix.Value[index1, index2] > num18)
              num18 = this.tempWinterMatrix.Value[index1, index2];
            if (this.tempSummerMatrix.Value[index1, index2] < num17)
              num17 = this.tempSummerMatrix.Value[index1, index2];
            if (this.tempWinterMatrix.Value[index1, index2] < num17)
              num17 = this.tempWinterMatrix.Value[index1, index2];
            int num24;
            if (this.tempRainSummerMatrix.Value[index1, index2] > num24)
              num24 = this.tempRainSummerMatrix.Value[index1, index2];
            if (this.tempRainWinterMatrix.Value[index1, index2] > num24)
              num24 = this.tempRainWinterMatrix.Value[index1, index2];
            if (this.tempRainSummerMatrix.Value[index1, index2] < num20)
              num20 = this.tempRainSummerMatrix.Value[index1, index2];
            if (this.tempRainWinterMatrix.Value[index1, index2] < num20)
              num20 = this.tempRainWinterMatrix.Value[index1, index2];
            int num25;
            if (this.tempRainCurrentMatrix.Value[index1, index2] > num25)
              num25 = this.tempRainCurrentMatrix.Value[index1, index2];
            if (this.tempRainCurrentMatrix.Value[index1, index2] < num21)
              num21 = this.tempRainCurrentMatrix.Value[index1, index2];
            if (bestFarm.onmap && bestFarm.x == index1 & bestFarm.y == index2)
            {
              int num26;
              if (this.tempRainSummerMatrix.Value[index1, index2] > num26)
                num26 = this.tempRainSummerMatrix.Value[index1, index2];
              if (this.tempRainWinterMatrix.Value[index1, index2] > num26)
                num26 = this.tempRainWinterMatrix.Value[index1, index2];
              if (this.tempRainSummerMatrix.Value[index1, index2] < num22)
                num22 = this.tempRainSummerMatrix.Value[index1, index2];
              if (this.tempRainWinterMatrix.Value[index1, index2] < num22)
                num22 = this.tempRainWinterMatrix.Value[index1, index2];
              if (this.tempSummerMatrix.Value[index1, index2] > num23)
                num23 = this.tempSummerMatrix.Value[index1, index2];
              if (this.tempWinterMatrix.Value[index1, index2] > num23)
                num23 = this.tempWinterMatrix.Value[index1, index2];
              if (this.tempSummerMatrix.Value[index1, index2] < num19)
                num19 = this.tempSummerMatrix.Value[index1, index2];
              if (this.tempWinterMatrix.Value[index1, index2] < num19)
                num19 = this.tempWinterMatrix.Value[index1, index2];
            }
          }
        }
      }
      if (num1 == 1)
      {
        if (num19 < num4 - 4 & num23 < num4 + 10)
          num1 = 2;
        if (num19 < num4 - 2 & num23 < num4 + 5)
          num1 = 2;
        if (num23 > num6 & num19 > num6 - 5)
          num1 = 2;
        if ((double) num23 > (double) num6 + (double) (num7 - num6) / 2.0)
          num1 = 2;
        if (num19 < num4 - 3 & num2 <= 2)
          num1 = 2;
        if (num19 < num4 - 6 & num2 <= 3)
          num1 = 2;
        if (num23 > num6 + 5 & num2 <= 2)
          num1 = 2;
        if (num23 > num6 + 10 & num2 <= 3)
          num1 = 2;
      }
      if (num1 == 3)
      {
        if (num19 < num11 - 4 & num23 < num11 + 10)
          num1 = 2;
        if (num19 < num11 - 2 & num23 < num11 + 5)
          num1 = 2;
        if (num23 > num13 & num19 > num13 - 5)
          num1 = 2;
        if ((double) num23 > (double) num13 + (double) (num14 - num13) / 2.0)
          num1 = 2;
        if (num19 < num11 - 3 & num2 <= 2)
          num1 = 2;
        if (num19 < num11 - 6 & num2 <= 3)
          num1 = 2;
        if (num23 > num13 + 5 & num2 <= 2)
          num1 = 2;
        if (num23 > num13 + 10 & num2 <= 3)
          num1 = 2;
      }
      let mut num27: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 1, 2)));
      let mut num28: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 2, 2)));
      let mut num29: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 3, 2)));
      let mut num30: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 4, 2)));
      if (this.data.Turn == 6)
        ;
      let mut num31: i32 = 0;
      if (num1 == 3)
      {
        if (num30 > 0)
          num31 -= num30 * 3;
      }
      else if (num1 == 1)
      {
        if (num28 > 0 & num28 < 9)
          num31 -= num28 * 3;
        if (num29 > 0 & num29 < 9)
          num31 -= num29 * 3;
      }
      if (num1 == 3)
      {
        if ((double) (num19 + num23 + num31) / 2.0 < (double) (num10 - 2))
          num1 = 2;
      }
      else if ((double) (num19 + num23 + num31) / 2.0 < (double) (num3 - 2))
        num1 = 2;
      let mut num32: i32 = this.itemProduction[5] - (this.itemNeed[5] + 200);
      let mut weight: i32 = this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(5);
      if (weight > 2000)
        num32 += 400;
      else if (weight > 1000)
        num32 += 200;
      else if (weight > 600)
        num32 += 150;
      else if (weight > 300)
        num32 += 75;
      float num33;
      float num34;
      float num35;
      if (num32 < 50)
      {
        num33 = 0.0f;
        num34 = 0.0f;
        num35 = 0.0f;
      }
      else if (num32 < 100)
      {
        num33 = 0.1f;
        num34 = 0.2f;
        num35 = 0.4f;
      }
      else if (num32 < 200)
      {
        num33 = 0.2f;
        num34 = 0.5f;
        num35 = 0.6f;
      }
      else if (num32 < 400)
      {
        num33 = 0.5f;
        num34 = 0.6f;
        num35 = 0.7f;
      }
      else if (num32 < 600)
      {
        num33 = 0.8f;
        num34 = 0.7f;
        num35 = 0.7f;
      }
      else
      {
        num33 = 1f;
        num34 = 0.9f;
        num35 = 0.8f;
      }
      float num36 = num22 >= 2 ? (num22 >= 10 ? (num22 >= 30 ? (num22 >= 60 ? (num22 >= 90 ? (num22 >= 140 ? (num22 >= 200 ? (num22 >= 300 ? num33 * 2f : (num33 + 0.6f) * 1.7f) : (num33 + 0.5f) * 1.5f) : (num33 + 0.4f) * 1.3f) : (num33 + 0.3f) * 1.1f) : (num33 + 0.2f) * 1f) : (num33 + 0.1f) * 0.8f) : num33 * 0.66f) : num33 * 0.5f;
      if (flagArray[5])
      {
        num36 += 0.5f;
        num34 += 0.5f;
        num35 += 0.0f;
      }
      if ((double) num36 > 1.0)
        num36 = 1f;
      if ((double) num34 > 1.0)
        num34 = 1f;
      if ((double) num35 > 1.0)
        num35 = 1f;
      let mut num37: i32 = this.itemProduction[15] - this.itemNeed[15] + this.newItems.FindWeight(15) +  Math.Round((double) this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(15) / 20.0);
      float num38 = num37 >= 60 ? (num37 >= 120 ? (num37 >= 240 ? (num37 >= 360 ? (num37 >= 500 ? 1.2f : 1f) : 0.7f) : 0.5f) : 0.3f) : 0.1f;
      if (num1 == 3)
      {
        SimpleList simpleList3 = SimpleList::new();
        let mut counter2: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter2; index += 1)
        {
          let mut num39: i32 = this.zoneList.Id[index];
          CoordList coordList3 = this.MakeCoordListFamilyAssetPresent(num39, 203);
          bestFarm = this.ai.game.EventRelatedObj.Helper_GetBestFarm("SE_Data", num39, CL: ( coordList3), useCache: true);
          if (bestFarm.onmap)
            simpleList3.Add(num39, bestFarm.data1, bestFarm.x, bestFarm.y);
          simpleList3.ReverseSort();
          if (simpleList3.Counter > -1)
          {
            let mut tweight: i32 =  Math.Round((double) (300f * num36));
            preferenceFoodPool.Add(203, tweight, simpleList3.Data1[0], simpleList3.Data2[0]);
          }
        }
      }
      if (num1 == 3)
      {
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(203);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 =  Math.Round((double) (400f * num36));
          preferenceFoodPool.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      if (num1 > 0)
      {
        SimpleList simpleList4 = SimpleList::new();
        let mut counter3: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter3; index += 1)
        {
          let mut tid: i32 = this.zoneList.Id[index];
          EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
          let mut zoneId: i32 = tid;
          CoordList coordList4 = (CoordList) null;
           CoordList local =  coordList4;
          bestFarm = eventRelatedObj.Helper_GetBestFarm("SE_Data", zoneId, true, CL: ( local), useCache: true);
          if (bestFarm.onmap)
            simpleList4.Add(tid, bestFarm.data1, bestFarm.x, bestFarm.y);
          simpleList4.ReverseSort();
          if (simpleList4.Counter > -1)
          {
            let mut tweight: i32 =  Math.Round((double) (150f * num34));
            preferenceFoodPool.Add(204, tweight, simpleList4.Data1[0], simpleList4.Data2[0]);
          }
        }
      }
      if (num1 > 0)
      {
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(204);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 =  Math.Round((double) (250f * num34));
          preferenceFoodPool.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      if (num1 == 1)
      {
        SimpleList simpleList5 = SimpleList::new();
        let mut counter4: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter4; index += 1)
        {
          let mut tid: i32 = this.zoneList.Id[index];
          EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
          let mut zoneId: i32 = tid;
          CoordList coordList5 = (CoordList) null;
           CoordList local =  coordList5;
          bestFarm = eventRelatedObj.Helper_GetBestFarm("SE_Data", zoneId, CL: ( local), useCache: true);
          if (bestFarm.onmap)
            simpleList5.Add(tid, bestFarm.data1, bestFarm.x, bestFarm.y);
          simpleList5.ReverseSort();
          if (simpleList5.Counter > -1)
          {
            let mut tweight: i32 =  Math.Round((double) (300f * num36));
            preferenceFoodPool.Add(202, tweight, simpleList5.Data1[0], simpleList5.Data2[0]);
          }
        }
      }
      if (num1 == 1)
      {
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(202);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 =  Math.Round((double) (500f * num36));
          preferenceFoodPool.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeRes].GetData2(0, 42, 1, this.RegimeId, 2))) >= 42)
      {
        SimpleList simpleList6 = SimpleList::new();
        let mut counter5: i32 = this.zoneList.Counter;
        for (let mut index: i32 = 0; index <= counter5; index += 1)
        {
          if (!this.IsFamilyAssetTypePresentInZone(this.zoneList.Id[index], 291))
            simpleList6.Add(this.zoneList.Id[index], this.zoneList.Weight[index], this.zoneList.Data1[index], this.zoneList.Data2[index]);
        }
        simpleList6.ReverseSort();
        if (simpleList6.Counter > -1)
        {
          let mut tweight: i32 =  Math.Round((double) ((float)  Math.Round((double) (80f * num35)) * num38));
          if (this.itemProduction[14] < 1)
            tweight =  Math.Round((double) tweight * 0.2);
          if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 5)
            tweight = 0;
          preferenceFoodPool.Add(291, tweight, simpleList6.Data1[0], simpleList6.Data2[0]);
        }
        SimpleList thatCanUpgradeToo = this.GetPublicAssetsThatCanUpgradeToo(291);
        if (thatCanUpgradeToo.Counter > -1)
        {
          let mut tweight: i32 =  Math.Round((double) ((float)  Math.Round((double) (130f * num35)) * num38));
          if (this.itemProduction[14] < 1)
            tweight =  Math.Round((double) tweight * 0.1);
          if (this.data.UnitObj[this.shqUnitNr].items.list.FindWeight(14) < 10)
            tweight = 0;
          preferenceFoodPool.Add(thatCanUpgradeToo.Id[0], tweight, thatCanUpgradeToo.Data2[0], thatCanUpgradeToo.Data3[0]);
        }
      }
      for (let mut counter6: i32 = preferenceFoodPool.Counter; counter6 >= 0; counter6 += -1)
      {
        if (preferenceFoodPool.Id[counter6] > 0)
        {
          let mut assetConstruction: i32 = this.GetEstimatedTurnsForAssetConstruction(preferenceFoodPool.Id[counter6], Pool.Food);
          if (assetConstruction > 1)
            preferenceFoodPool.Weight[counter6] =  Math.Round((double) preferenceFoodPool.Weight[counter6] * 0.5 / (double) assetConstruction) +  Math.Round((double) preferenceFoodPool.Weight[counter6] * 0.5);
        }
        if (preferenceFoodPool.Weight[counter6] == 0)
          preferenceFoodPool.RemoveNr(counter6);
      }
      preferenceFoodPool.ReverseSort();
      return preferenceFoodPool;
    }

    pub IsFamilyAssetTypePresentInZone: bool(int zoneId, int familyId)
    {
      SimpleList simpleList = SimpleList::new();
      let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
      for (let mut index: i32 = 0; index <= length; index += 1)
      {
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 0])) == zoneId &&  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0,  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1])), 14))) == familyId)
          return true;
      }
      return false;
    }

    pub IsFamilyAssetTypePresentInZoneList: bool(int familyId, bool countInConstr)
    {
      SimpleList simpleList = SimpleList::new();
      let mut counter: i32 = this.zoneList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        let mut num1: i32 = this.zoneList.Id[index1];
        let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
        for (let mut index2: i32 = 0; index2 <= length; index2 += 1)
        {
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 0])) == num1)
          {
            let mut idValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index2, 1]));
            let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 14)));
            let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 8)));
            if (countInConstr | num3 < 1 && num2 == familyId)
              return true;
          }
        }
      }
      return false;
    }

    pub SimpleList GetPublicAssetsThatCanUpgradeToo(int familyId)
    {
      SimpleList thatCanUpgradeToo = SimpleList::new();
      bool flag1 = false;
      SimpleStringList simpleStringList = SimpleStringList::new();
      data1: DataClass = this.data;
      str1: String = "MiningReserve";
       local1: String =  str1;
      let mut libVar1: i32 = data1.FindLibVar( local1, "SE_Data");
      data2: DataClass = this.data;
      str2: String = "Scavenge";
       local2: String =  str2;
      let mut libVar2: i32 = data2.FindLibVar( local2, "SE_Data");
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "REGIMEID", 1, this.RegimeId);
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "ROUND", 1, this.data.Round);
      let mut length: i32 = this.data.StringListObj[this.slotAssets].Length;
      for (let mut index1: i32 = 0; index1 <= length; index1 += 1)
      {
        let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 0]));
        if (this.zoneList.FindNr(num1) > -1)
        {
          this.data.StringListObj[this.slotFlagInstructions].SetData(0, "ZONEID", 1, num1);
          let mut idValue1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 1]));
          let mut index2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 3]));
          let mut index3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 4]));
          let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 5]));
          let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 8]));
          let mut tdata1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 9]));
          let mut num4: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index1, 11]));
          let mut tweight: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 2)));
          let mut num5: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 4)));
          let mut num6: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 9)));
          let mut num7: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 5)));
          let mut num8: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 7)));
          let mut idValue2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 14)));
          let mut id1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num1, 6)));
          if (id1 > 0)
          {
            let mut locationById: i32 = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id1);
            if (index2 == -1)
            {
              index2 = this.data.LocObj[locationById].X;
              index3 = this.data.LocObj[locationById].Y;
            }
          }
          let mut num9: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num1, 1, "city", 2)));
          if (idValue2 == familyId && num7 == 1 & tweight > 0 & tweight < num9)
          {
            let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData2(14, idValue2, 2, tweight + 1, 0)));
            if (num10 > 0)
            {
              bool flag2 = true;
              data3: String = this.data.StringListObj[this.slotAssetTypes].GetData(0, num10, 6);
              if (data3.Length > 1)
              {
                EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
                let mut id2: i32 = this.data.StringListObj[this.slotFlags].ID;
                let mut id3: i32 = this.data.StringListObj[this.slotFlagInstructions].ID;
                logicString: String = data3;
                Random random = (Random) null;
                 Random local3 =  random;
                if (eventRelatedObj.CheckLogicStringStart(id2, id3, logicString, 0,  local3) < 1)
                  flag2 = false;
              }
              if (index2 >= 0 & index3 >= 0 && this.data.MapObj[0].HexObj[index2, index3].Regime != this.data.Turn)
                flag2 = false;
              if (num3 > 0)
              {
                flag1 = true;
                flag2 = false;
              }
              if (flag2)
              {
                let mut num11: i32 =  Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotZones].GetData(0, num1, 10)));
                let mut num12: i32 =  Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotZones].GetData(0, num1, 11)));
                bool isCity = false;
                if (num11 == index2 & num12 == index3)
                  isCity = true;
                if (DrawMod.TGame.EventRelatedObj.Helper_GetConstructList(this.RegimeId, index2, index3, num10, true, false, isCity).Data2[0] == 0)
                  flag2 = false;
              }
              if (flag2)
              {
                if (index2 == -1 | index3 == -1)
                {
                  let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num1, 6))));
                  index2 = this.data.LocObj[locationById].X;
                  index3 = this.data.LocObj[locationById].Y;
                }
                if (num5 == 2)
                {
                  let mut hexLibVarValue: i32 = this.data.MapObj[0].HexObj[index2, index3].GetHexLibVarValue(libVar1);
                  let mut num13: i32 = hexLibVarValue;
                  if (num6 == 1)
                    num13 = 5000 * tweight;
                  if (num6 == 2)
                    num13 = 2500 * tweight;
                  if (num6 == 3)
                    num13 = 1200 * tweight;
                  if (num6 == 4)
                    num13 = 500 * tweight;
                  if (num6 == 5)
                    num13 = 10000 * tweight;
                  if (num13 > hexLibVarValue)
                    flag2 = false;
                }
                if (num5 == 3)
                {
                  let mut hexLibVarValue: i32 = this.data.MapObj[0].HexObj[index2, index3].GetHexLibVarValue(libVar2);
                  if (2000 * tweight > hexLibVarValue)
                    flag2 = false;
                }
                if (flag2)
                  thatCanUpgradeToo.Add(num10, tweight, tdata1, index2, index3);
              }
            }
          }
        }
      }
      if (flag1)
        thatCanUpgradeToo = SimpleList::new();
      if (thatCanUpgradeToo.Counter > 0)
        thatCanUpgradeToo = thatCanUpgradeToo;
      thatCanUpgradeToo.ReverseSort();
      return thatCanUpgradeToo;
    }

    pub int GetMinimumProdForShortageCalcs(int itemNr) => 1 == itemNr || 7 == itemNr || 5 == itemNr ? 100 : 2;

    pub void GetSHQgroupsAndStages()
    {
      str: String = "9000_SHQgroupsAndStages";
      this.ai.ClearLog();
      this.ai.AddLog(str);
      this.ShqList = SimpleList::new();
      let mut length1: i32 = this.data.StringListObj[this.slotZones].Length;
      for (let mut index: i32 = 0; index <= length1; index += 1)
      {
        let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 6]));
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8])) == this.RegimeId && id > 0)
        {
          let mut locationById: i32 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1 && this.data.MapObj[0].HexObj[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y].Regime == this.data.Turn)
          {
            let mut hq: i32 = this.data.LocObj[locationById].HQ;
            if (hq > -1)
            {
              let mut historical: i32 = this.data.UnitObj[hq].Historical;
              if (historical > -1)
                this.ShqList.AddWeight(this.data.HistoricalUnitObj[historical].ID, 1);
            }
          }
        }
      }
      let mut counter: i32 = this.ShqList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        int[] numArray1 = new int[100];
        let mut length2: i32 = this.data.StringListObj[this.slotZones].Length;
        for (let mut index2: i32 = 0; index2 <= length2; index2 += 1)
        {
          let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 0]));
          let mut id: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 6]));
          if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 8])) == this.RegimeId && id > 0)
          {
            this.ai.game.HandyFunctionsObj.GetLocationByID(id);
            EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
            let mut onlyZoneId: i32 = num1;
            SimpleList simpleList1 = (SimpleList) null;
             SimpleList local1 =  simpleList1;
            SimpleList simpleList2 = (SimpleList) null;
             SimpleList local2 =  simpleList2;
            eventRelatedObj.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId, "", itemsProdModList: ( local1), itemsUpkeepModList: ( local2));
            let mut length3: i32 = this.data.StringListObj[this.slotAssetPresentation].Length;
            for (let mut index3: i32 = 0; index3 <= length3; index3 += 1)
            {
              let mut num2: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index3, 0]));
              if (num2 > 0)
              {
                let mut num3: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index3, 4]));
                int[] numArray2 = numArray1;
                int[] numArray3 = numArray2;
                let mut index4: i32 = num2;
                let mut index5: i32 = index4;
                let mut num4: i32 = numArray2[index4] + num3;
                numArray3[index5] = num4;
              }
            }
          }
        }
        let mut num: i32 = 2;
        if (num == 2 & numArray1[2] >= 150 & numArray1[1] >= 100 & numArray1[8] >= 40)
          num = 3;
        if (num == 3 & numArray1[15] >= 100 & numArray1[3] > 30 & numArray1[8] >= 150)
          num = 4;
        if (num == 4 & numArray1[13] > 0)
          num = 5;
        if (num == 5 & numArray1[14] > 0)
          num = 6;
        if (num == 6 & numArray1[4] > 0)
          num = 7;
        this.ShqList.Data1[index1] = num;
        let mut historicalUnitById: i32 = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.ShqList.Id[index1]);
        this.ai.AddLog("SHQ HisID = " + this.ShqList.Id[index1].ToString() + ": " + this.data.HistoricalUnitObj[historicalUnitById].Name + " , #zones=" + this.ShqList.Weight[index1].ToString() + ", stage=" + this.ShqList.Data1[index1].ToString() + ".");
      }
      this.ai.WriteLog(str);
    }
  }
}
