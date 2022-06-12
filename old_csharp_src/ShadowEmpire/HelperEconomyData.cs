// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HelperEconomyData
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;

namespace WindowsApplication1
{
  public class HelperEconomyData
  {
    public int slotMilitiaUnits;
    public int slotZoneRegKeys;
    public int slotModels;
    public int slotMilitiaTroops;
    public int slotMilitiaNames;
    public int slotProdType;
    public int slotZones;
    public int slotZoneKeys;
    public int slotAssetTypes;
    public int slotAssets;
    public int slotNeighbours;
    public int slotRegimes;
    public int slotConstructionCost;
    public int slotUpkeepCost;
    public int slotProdCost;
    public int assetZoneId;
    public int city;
    public int phase;
    public int superphase;
    public int assetLackOfUpkeep;
    public int assetInConstr;
    public int assetConstrRoundsLeft;
    public int assetTypeId;
    public int level;
    public int ax;
    public int ay;
    public int assetProdId;
    public int costProdId;
    public int costAssetTypeId;
    public int costType;
    public int costItemType;
    public int costQty;
    public int prodItemType;
    public int prodQty;
    public int ProdTypeType;
    public int zoneValue;
    public int workerHapiness;
    public int popHapiness;
    public int popHunger;
    public int recruitPenalty;
    public int workerHunger;
    public int popLoyalty;
    public string zoneKey;
    public string zoneName;
    public int workerSalaryNeed;
    public int workerSalaryBuyFood;
    public int slotRegFeats;
    public int workerSalaryGiven;
    public int recruitBonus;
    public int colonistBonus;
    public int privateMetal;
    public int privateWater;
    public int privateOil;
    public int cas;
    public int worker;
    public int pop;
    public int recruits;
    public int colonists;
    public int food;
    public int workerPoints;
    public int popPoints;
    public int privateFood;
    public int rebelCredits;
    public int netPrivateIncome;
    public int emergencyFoodGiven;
    public int freeFolk;
    public int hiddenEconomyIncome;
    public int popCredits;
    public int workerCredits;
    public int occupationMode;
    public int rebelStrength;
    public int rebelManpower;
    public int rebelRegime;
    public int highestLoyalty;
    public int highestLoyaltyRegime;
    public int publicCredits;
    public int workerSpendingIncome;
    public int sellingFoodIncome;
    public int privateAssetIncome;
    public int buyingFoodExpenses;
    public int buyingLuxuriesExpenses;
    public int BuyingAssetsExpenses;
    public int BuyingPopExpenses;
    public int publicBudget;
    public int publicBudgetGiven;
    public int slotOrg;
    public int slotAssetPresentation;
    public int privateLuxury;
    public int garrisonFacility;
    public int culture;
    public int unrest;
    public int danger;
    public int fear;
    public int qol;
    public int health;
    public int entertainment;
    public int education;
    public int security;
    public int luxury;
    public int qol_health;
    public int qol_entertainment;
    public int qol_education;
    public int qol_security;
    public int qol_luxury;
    public int maxWater;
    public int maxEnergy;
    public int maxAmmo;
    public int maxFuel;
    public int maxFood;
    public int maxIP;
    public int orig_food;
    public int orig_privateFood;
    public int foodConsumed;
    public int privateFoodConsumed;
    public int zoneId;
    public int zoneNr;
    public int locNr;
    public int locId;
    public int reg;
    public int regid;
    public int regtype;
    public int regCulture;
    public int regCultureGroup;
    public int militiaManpower;
    public int militiaEquipment;
    public int militancy;
    public int origRegimeId;
    public int origRegimeNr;
    public int currentRegimeId;
    public int currentRegimeNr;
    public int water;
    public int oxygen;
    public int zoneCultureId;
    public AIMatrix zones;
    public AIMatrix hexFreeFolk;
    public AIMatrix temperatures;
    public AIMatrix rad;
    public int privateCreditsGrowth;
    public int governorCharId;
    public int regimeCredits;
    public int administrativeStrain;
    public int slotCulture;
    public int slotTradeLog;
    public int slotCultureKeys;
    public int slotCultureGroup;
    public int slotGfxSet;
    public int slotStats;
    public int slotCulturePlanet;
    public int slotBaseValues;
    public int slotZoneOrders;
    public int slotCharacter;
    public int slotRegReg;
    public int slotFlags;
    public int slotFlagInstructions;
    public int slotGameKeys;
    public int slotTraders;
    public int slotTraderZones;
    public int slotTraderItems;
    public int slotRegimeKeys;
    public int slotItemType;
    public int bioHazard;
    public int atmosHazard;
    public int tempExposureWorkerLoss;
    public int tempExposurePopLoss;
    public int tempExposureFreeFolkLoss;

    public HelperEconomyData(ref GameClass tgame, string dataLib)
    {
      string libName1 = "SE_Trade";
      this.zones = new AIMatrix(ref tgame.DC2AIObj);
      this.hexFreeFolk = new AIMatrix(ref tgame.DC2AIObj);
      this.temperatures = new AIMatrix(ref tgame.DC2AIObj);
      this.rad = new AIMatrix(ref tgame.DC2AIObj);
      int mapWidth = tgame.Data.MapObj[0].MapWidth;
      int mapHeight = tgame.Data.MapObj[0].MapHeight;
      this.atmosHazard = (int) Math.Round(Conversion.Val(tgame.Data.StringListObj[this.slotGameKeys].GetData(0, 1, 2)));
      this.bioHazard = (int) Math.Round(Conversion.Val(tgame.Data.StringListObj[this.slotGameKeys].GetData(0, 2, 2)));
      DataClass data1 = tgame.Data;
      string str1 = "Zones";
      ref string local1 = ref str1;
      string libName2 = dataLib;
      int libVar1 = data1.FindLibVar(ref local1, libName2);
      DataClass data2 = tgame.Data;
      string str2 = "Temperature";
      ref string local2 = ref str2;
      string libName3 = dataLib;
      int libVar2 = data2.FindLibVar(ref local2, libName3);
      DataClass data3 = tgame.Data;
      string str3 = nameof (rad);
      ref string local3 = ref str3;
      string libName4 = dataLib;
      int libVar3 = data3.FindLibVar(ref local3, libName4);
      DataClass data4 = tgame.Data;
      string str4 = "freefolk";
      ref string local4 = ref str4;
      string libName5 = dataLib;
      int libVar4 = data4.FindLibVar(ref local4, libName5);
      int num1 = mapWidth;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = mapHeight;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.zones.Value[index1, index2] = tgame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar1);
          this.temperatures.Value[index1, index2] = tgame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar2);
          this.rad.Value[index1, index2] = tgame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar3);
          this.hexFreeFolk.Value[index1, index2] = tgame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar4);
        }
      }
      this.slotModels = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 228, 0, 0));
      this.slotAssetPresentation = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 166, 0, 0));
      this.slotZones = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 123, 0, 0));
      this.slotOrg = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 184, 0, 0));
      this.slotZoneOrders = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 289, 0, 0));
      this.slotZoneKeys = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 160, 0, 0));
      this.slotGameKeys = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 156, 0, 0));
      this.slotNeighbours = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 157, 0, 0));
      this.slotRegimes = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 143, 0, 0));
      this.slotAssets = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 148, 0, 0));
      this.slotAssetTypes = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 144, 0, 0));
      this.slotConstructionCost = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 150, 0, 0));
      this.slotUpkeepCost = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 145, 0, 0));
      this.slotProdCost = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 146, 0, 0));
      this.slotProdType = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 147, 0, 0));
      this.slotMilitiaUnits = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 170, 0, 0));
      this.slotMilitiaTroops = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 171, 0, 0));
      this.slotMilitiaNames = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 172, 0, 0));
      this.slotBaseValues = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName1, 251, 0, 0));
      this.slotTraders = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName1, 252, 0, 0));
      this.slotTraderZones = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName1, 253, 0, 0));
      this.slotTraderItems = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName1, 254, 0, 0));
      this.slotRegimeKeys = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 210, 0, 0));
      this.slotItemType = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 149, 0, 0));
      this.slotFlagInstructions = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 169, 0, 0));
      this.slotFlags = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 168, 0, 0));
      this.slotRegReg = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 275, 0, 0));
      this.slotCharacter = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 196, 0, 0));
      this.slotCulture = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 306, 0, 0));
      this.slotCultureGroup = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 310, 0, 0));
      this.slotGfxSet = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 311, 0, 0));
      this.slotCulturePlanet = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 312, 0, 0));
      this.slotCultureKeys = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 308, 0, 0));
      this.slotStats = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 292, 0, 0));
      this.slotTradeLog = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 400, 0, 0));
      this.slotRegFeats = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 388, 0, 0));
      this.slotZoneRegKeys = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(dataLib, 288, 0, 0));
      if (tgame.Data.Turn <= -1)
        return;
      this.regid = tgame.Data.RegimeObj[tgame.Data.Turn].id;
      this.regtype = (int) Math.Round(Conversion.Val(tgame.Data.StringListObj[this.slotRegimes].GetData(0, this.regid, 1)));
    }

    public void Input(int useRegimeId = -1)
    {
      if (DrawMod.TGame.Data.Turn == 1)
        this.water = this.water;
      this.worker = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "worker", 2))));
      this.pop = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "pop", 2))));
      this.workerPoints = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerPoints", 2))));
      this.popPoints = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "popPoints", 2))));
      this.privateFood = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateFood", 2))));
      this.privateMetal = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateMetal", 2))));
      this.privateOil = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateOil", 2))));
      this.privateWater = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateWater", 2))));
      this.orig_privateFood = this.privateFood;
      this.popHunger = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "popHunger", 2))));
      this.popHapiness = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "popHapiness", 2))));
      this.popLoyalty = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "popLoyalty", 2))));
      this.workerHunger = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerHunger", 2))));
      this.workerHapiness = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerHapiness", 2))));
      this.militiaManpower = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "militiaManpower", 2))));
      this.militiaEquipment = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "militiaEquipment", 2))));
      this.militancy = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "militancy", 2))));
      this.cas = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "cas", 2))));
      this.regtype = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimes].GetData(0, this.regid, 1)));
      this.regCulture = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimes].GetData(0, this.regid, 2)));
      this.regCultureGroup = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotCulture].GetData(0, this.regCulture, 1)));
      this.privateCreditsGrowth = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateCreditsGrowth", 2))));
      this.zoneCultureId = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].GetData(0, this.zoneId, 9)));
      this.locNr = -1;
      this.locId = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].GetData(0, this.zoneId, 6)));
      if (this.locId > 0)
        this.locNr = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(this.locId);
      this.rebelCredits = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "rebelCredits", 2))));
      this.popCredits = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "popCredits", 2))));
      this.hiddenEconomyIncome = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "hiddenEconomyIncome", 2))));
      this.privateAssetIncome = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateAssetIncome", 2))));
      this.workerSpendingIncome = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerSpendingIncome", 2))));
      this.sellingFoodIncome = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "sellingFoodIncome", 2))));
      this.buyingFoodExpenses = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "buyingFoodExpenses", 2))));
      this.buyingLuxuriesExpenses = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "buyingLuxuriesExpenses", 2))));
      this.BuyingAssetsExpenses = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "BuyingAssetsExpenses", 2))));
      this.BuyingPopExpenses = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "BuyingPopExpenses", 2))));
      this.netPrivateIncome = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "netPrivateIncome", 2))));
      this.recruitPenalty = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "recruitPenalty", 2))));
      this.workerCredits = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerCredits", 2))));
      this.occupationMode = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "occupationMode", 2))));
      this.rebelStrength = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "rebelStrength", 2))));
      this.rebelManpower = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "rebelManpower", 2))));
      this.administrativeStrain = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "administrativeStrain", 2))));
      this.rebelRegime = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "rebelRegime", 2))));
      this.highestLoyalty = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "highestLoyalty", 2))));
      this.highestLoyaltyRegime = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "highestLoyaltyRegime", 2))));
      this.publicCredits = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "publicCredits", 2))));
      this.publicBudget = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "publicBudget", 2))));
      this.privateLuxury = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "privateLuxury", 2))));
      this.garrisonFacility = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "garrisonFacility", 2))));
      this.culture = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "culture", 2))));
      this.unrest = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "unrest", 2))));
      this.fear = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "fear", 2))));
      this.danger = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "danger", 2))));
      this.qol = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "qol", 2))));
      this.city = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "city", 2))));
      this.health = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "health", 2))));
      this.entertainment = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "entertainment", 2))));
      this.education = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "education", 2))));
      this.security = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "security", 2))));
      this.freeFolk = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "freeFolk", 2))));
      this.luxury = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "luxury", 2))));
      this.qol_health = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "qol_health", 2))));
      this.qol_entertainment = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "qol_entertainment", 2))));
      this.qol_education = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "qol_education", 2))));
      this.qol_security = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "qol_security", 2))));
      this.qol_luxury = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "qol_luxury", 2))));
      this.workerSalaryNeed = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerSalaryNeed", 2))));
      this.workerSalaryGiven = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerSalaryGiven", 2))));
      this.workerSalaryBuyFood = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "workerSalaryBuyFood", 2))));
      this.colonistBonus = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "colonistBonus", 2))));
      this.recruitBonus = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "recruitBonus", 2))));
      this.publicBudgetGiven = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "publicBudgetGiven", 2))));
      this.emergencyFoodGiven = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "emergencyFoodGiven", 2))));
      this.governorCharId = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotCharacter].GetData3(5, this.regid, 6, 10, 7, this.zoneId, 0)));
      if (DrawMod.TGame.Data.Turn > -1)
        this.regimeCredits = useRegimeId <= -1 ? Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].GetData2(0, this.currentRegimeId, 1, "credits", 2)))) : Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].GetData2(0, useRegimeId, 1, "credits", 2))));
      if (this.locNr > -1)
      {
        if (Information.IsNothing((object) DrawMod.TGame.Data.LocObj[this.locNr].items))
          DrawMod.TGame.Data.LocObj[this.locNr].items = new ItemList();
        int nr1 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(7);
        this.food = nr1 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr1];
        this.orig_food = this.food;
        int nr2 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(5);
        this.water = nr2 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr2];
        int nr3 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(6);
        this.oxygen = nr3 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr3];
        int nr4 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(12);
        this.colonists = nr4 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr4];
        int nr5 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(9);
        this.recruits = nr5 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr5];
        int nr6 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(16);
        this.maxEnergy = nr6 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr6];
        int nr7 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(17);
        this.maxAmmo = nr7 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr7];
        int nr8 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(18);
        this.maxFuel = nr8 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr8];
        int nr9 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(19);
        this.maxFood = nr9 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr9];
        int nr10 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(22);
        this.maxIP = nr10 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr10];
        int nr11 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(20);
        this.maxWater = nr11 <= -1 ? 0 : DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr11];
      }
      else
        this.food = 0;
      this.tempExposureFreeFolkLoss = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "tempExposureFreeFolkLoss", 2))));
      this.tempExposurePopLoss = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "tempExposurePopLoss", 2))));
      this.tempExposureWorkerLoss = Math.Max(0, (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].GetData2(0, this.zoneId, 1, "tempExposureWorkerLoss", 2))));
    }

    public void Output(int useRegimeId = -1)
    {
      if (this.locNr > -1)
      {
        int nr1 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(5);
        if (nr1 < 0)
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(5, this.water);
        else
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr1] = this.water;
        int nr2 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(6);
        if (nr2 < 0)
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(6, this.oxygen);
        else
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr2] = this.oxygen;
        int index = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(7);
        if (this.zoneId == 41)
          index = index;
        if (index < 0)
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(7, this.food);
        else
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[index] = this.food;
        int nr3 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(12);
        if (nr3 < 0)
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(12, this.colonists);
        else
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr3] = this.colonists;
        int nr4 = DrawMod.TGame.Data.LocObj[this.locNr].items.list.FindNr(9);
        if (nr4 < 0)
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(9, this.recruits);
        else
          DrawMod.TGame.Data.LocObj[this.locNr].items.list.Weight[nr4] = this.recruits;
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(16, this.maxEnergy);
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(17, this.maxAmmo);
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(18, this.maxFuel);
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(19, this.maxFood);
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(22, this.maxIP);
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.Add(20, this.maxWater);
        DrawMod.TGame.Data.LocObj[this.locNr].items.list.removeWeight0orLower();
      }
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerSalaryNeed", 2, this.workerSalaryNeed, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerSalaryGiven", 2, this.workerSalaryGiven, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerSalaryBuyFood", 2, this.workerSalaryBuyFood, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "recruitBonus", 2, this.recruitBonus, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "colonistBonus", 2, this.colonistBonus, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "occupationMode", 2, this.occupationMode, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "worker", 2, this.worker, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "pop", 2, this.pop, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerPoints", 2, this.workerPoints, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "popPoints", 2, this.popPoints, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateFood", 2, this.privateFood, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateMetal", 2, this.privateMetal, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateOil", 2, this.privateOil, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateWater", 2, this.privateWater, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "popHunger", 2, this.popHunger, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "popHapiness", 2, this.popHapiness, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "popLoyalty", 2, this.popLoyalty, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerHunger", 2, this.workerHunger, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerHapiness", 2, this.workerHapiness, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "militiaManpower", 2, this.militiaManpower, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "militiaEquipment", 2, this.militiaEquipment, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "militancy", 2, this.militancy, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "cas", 2, this.cas, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "recruitPenalty", 2, this.recruitPenalty, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "city", 2, this.city, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateCreditsGrowth", 2, this.privateCreditsGrowth, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "emergencyFoodGiven", 2, this.emergencyFoodGiven, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "rebelCredits", 2, this.rebelCredits, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "popCredits", 2, this.popCredits, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "hiddenEconomyIncome", 2, this.hiddenEconomyIncome, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateAssetIncome", 2, this.privateAssetIncome, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerSpendingIncome", 2, this.workerSpendingIncome, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "sellingFoodIncome", 2, this.sellingFoodIncome, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "buyingFoodExpenses", 2, this.buyingFoodExpenses, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "buyingLuxuriesExpenses", 2, this.buyingLuxuriesExpenses, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "BuyingAssetsExpenses", 2, this.BuyingAssetsExpenses, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "BuyingPopExpenses", 2, this.BuyingPopExpenses, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "netPrivateIncome", 2, this.netPrivateIncome, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "administrativeStrain", 2, this.administrativeStrain, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "workerCredits", 2, this.workerCredits, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "occupationMode", 2, this.occupationMode, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "rebelStrength", 2, this.rebelStrength, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "rebelManpower", 2, this.rebelManpower, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "rebelRegime", 2, this.rebelRegime, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "highestLoyalty", 2, this.highestLoyalty, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "highestLoyaltyRegime", 2, this.highestLoyaltyRegime, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "publicCredits", 2, this.publicCredits, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "publicBudget", 2, this.publicBudget, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "publicBudgetGiven", 2, this.publicBudgetGiven, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "privateLuxury", 2, this.privateLuxury, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "garrisonFacility", 2, this.garrisonFacility, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "culture", 2, this.culture, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "unrest", 2, this.unrest, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "danger", 2, this.danger, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "fear", 2, this.fear, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "qol", 2, this.qol, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "health", 2, this.health, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "entertainment", 2, this.entertainment, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "education", 2, this.education, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "security", 2, this.security, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "freeFolk", 2, this.freeFolk, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "luxury", 2, this.luxury, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "qol_health", 2, this.qol_health, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "qol_entertainment", 2, this.qol_entertainment, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "qol_education", 2, this.qol_education, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "qol_security", 2, this.qol_security, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "qol_luxury", 2, this.qol_luxury, true);
      if (DrawMod.TGame.Data.Turn > -1)
      {
        if (useRegimeId > -1)
          DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].SetData2(0, useRegimeId, 1, "credits", 2, this.regimeCredits, true);
        else
          DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].SetData2(0, this.currentRegimeId, 1, "credits", 2, this.regimeCredits, true);
      }
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "tempExposureFreeFolkLoss", 2, this.tempExposureFreeFolkLoss, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "tempExposurePopLoss", 2, this.tempExposurePopLoss, true);
      DrawMod.TGame.Data.StringListObj[this.slotZoneKeys].SetData2(0, this.zoneId, 1, "tempExposureWorkerLoss", 2, this.tempExposureWorkerLoss, true);
      DrawMod.TGame.Data.StringListObj[this.slotZones].SetData(0, this.zoneId, 9, this.zoneCultureId);
    }
  }
}
