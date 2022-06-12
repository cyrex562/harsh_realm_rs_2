// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Shadow_Strategic_AI
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class Shadow_Strategic_AI
  {
    public DC2AIClass ai;
    public SimpleList ShqList;
    public DataClass data;
    public int RegimeId;
    public int slotMilitiaUnits;
    public int slotCultureKey;
    public int slotCards;
    public int slotModelTypeTech;
    public int slotModelHistoryTech;
    public int slotToeTypes;
    public int slotFactions;
    public int slotCulture;
    public int slotCultureGroup;
    public int slotsftypequality;
    public int slotOobTypes;
    public int slotModelTypes;
    public int slotModelTypeChoices;
    public int slotAssetPresentation;
    public int slotRegimeOobs;
    public int slotAiCards;
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
    public int slotBaseValues;
    public int slotModelHistory;
    public int slotModelTypeStats;
    public int slotDipCardsIf;
    public int slotProfileDoc;
    public int slotPersFile;
    public int slotRegimeTech;
    public int slotChar;
    public int slotTechType;
    public int slotRegimeModels;
    public int slotRegimeType;
    public int slotAiTech;
    public int slotDipCards;
    public int slotRegRegKeys;
    public int slotFlags;
    public int slotFlagInstructions;
    public int slotGameKeys;
    public int slotTraders;
    public int slotTraderZones;
    public int slotTraderItems;
    public int slotRegimeKeys;
    public int slotItemType;
    public int slotImod;
    public int shqHisId;
    public int shqUnitNr;
    public int shqHisNr;
    public string shqName;
    public int aiHawk;
    public int aiFear;
    private int aiLoyal;
    public int pathTech_Military;
    public int pathTech_Economy;
    public int pathTech_Artillery;
    public int pathEco_German;
    public int pathEco_American;
    public int pathEco_Soviet;
    public int pathWar_Offensive;
    public int pathWar_Defensive;
    public float[,] combatMatrixAtt;
    public float[,] combatMatrixDef;
    public int[] friendlyEconomicValue;
    public int[] friendlyMilitaryValue;
    public int[] friendlyMilitaryValueUnMod;
    public int[] friendlyAir;
    public int[,] enemyAir;
    public int[] enemyHexes;
    public int[] enemyTotalValueWeAtt;
    public int[] enemyTotalValueWeDef;
    public int[,] enemyEconomicValue;
    public int[] enemyAllEco;
    public int[,] enemyMilitaryValueWeAtt;
    public int[,] enemyMilitaryValueWeDef;
    public int[] shqEmptyZones;
    public SimpleList[] regimeZoneList;
    public SimpleList OobRatingList;
    public int Air_Economical_AirBased;
    public int Air_Economical_RocketBased;
    public int Air_Economical_ThopterBased;
    public bool Air_Yes;
    public bool Air_JustFlak;
    public bool Air_None;
    public int Air_Aircraft_AsPercentage_Of_Land;
    public int Air_Flak_AsPercentage_Of_Land;
    public int Air_Support;
    public int Air_Cover;
    public int OurLossDueToAir;
    public int OurLossDueToTank;
    public int OurKillDueToAir;
    public int OurKillDueToTank;

    public Shadow_Strategic_AI(ref DC2AIClass tai)
    {
      this.combatMatrixAtt = new float[1, 1];
      this.combatMatrixDef = new float[1, 1];
      this.friendlyEconomicValue = new int[1];
      this.friendlyMilitaryValue = new int[1];
      this.friendlyMilitaryValueUnMod = new int[1];
      this.friendlyAir = new int[1];
      this.enemyAir = new int[1, 1];
      this.enemyHexes = new int[1];
      this.enemyTotalValueWeAtt = new int[1];
      this.enemyTotalValueWeDef = new int[1];
      this.enemyEconomicValue = new int[1, 1];
      this.enemyAllEco = new int[1];
      this.enemyMilitaryValueWeAtt = new int[1, 1];
      this.enemyMilitaryValueWeDef = new int[1, 1];
      this.shqEmptyZones = new int[1];
      this.regimeZoneList = new SimpleList[1];
      this.ai = tai;
      this.data = tai.game.Data;
      this.RegimeId = tai.game.Data.RegimeObj[tai.game.Data.Turn].id;
      string libName1 = "SE_Data";
      string libName2 = "SE_Trade";
      this.slotRegimes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 143, 0, 0));
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 1)));
      this.slotCards = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 277, 0, 0));
      this.slotChar = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 196, 0, 0));
      this.slotCulture = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 306, 0, 0));
      this.slotCultureKey = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 308, 0, 0));
      this.slotCultureGroup = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 310, 0, 0));
      this.slotZones = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
      this.slotZoneKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 160, 0, 0));
      this.slotGameKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 156, 0, 0));
      this.slotNeighbours = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 157, 0, 0));
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
      this.slotItemType = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 149, 0, 0));
      this.slotFlagInstructions = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 169, 0, 0));
      this.slotFlags = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 168, 0, 0));
      this.slotRegRegKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 275, 0, 0));
      this.slotAiCards = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 303, 0, 0));
      this.slotDipCards = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 277, 0, 0));
      this.slotDipCardsIf = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 345, 0, 0));
      this.slotAssetPresentation = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 166, 0, 0));
      this.slotAiTech = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 305, 0, 0));
      this.slotRegimeTech = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 187, 0, 0));
      this.slotRegimeModels = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 228, 0, 0));
      this.slotRegimeOobs = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 238, 0, 0));
      this.slotModelTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 225, 0, 0));
      this.slotModelTypeChoices = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 232, 0, 0));
      this.slotModelTypeStats = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 231, 0, 0));
      this.slotOobTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 236, 0, 0));
      this.slotToeTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 237, 0, 0));
      this.slotTechType = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 190, 0, 0));
      this.slotsftypequality = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 299, 0, 0));
      this.slotPersFile = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 198, 0, 0));
      this.slotImod = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 408, 0, 0));
      this.slotProfileDoc = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 258, 0, 0));
      this.slotFactions = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 200, 0, 0));
      this.slotModelHistory = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 229, 0, 0));
      this.slotModelTypeTech = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 227, 0, 0));
      this.slotModelHistoryTech = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 230, 0, 0));
      this.aiHawk = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (aiHawk), 2)));
      this.aiFear = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (aiFear), 2)));
      this.pathTech_Artillery = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathTech_Artillery), 2)));
      this.pathTech_Economy = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathTech_Economy), 2)));
      this.pathTech_Military = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathTech_Military), 2)));
      this.pathEco_American = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathEco_American), 2)));
      this.pathEco_Soviet = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathEco_Soviet), 2)));
      this.pathEco_German = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathEco_German), 2)));
      this.pathWar_Offensive = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathWar_Offensive), 2)));
      this.pathWar_Defensive = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, nameof (pathWar_Defensive), 2)));
      if (this.pathTech_Artillery == 0 & this.pathTech_Economy == 0 & this.pathTech_Military == 0)
      {
        this.pathTech_Artillery = 33;
        this.pathTech_Economy = 33;
        this.pathTech_Military = 33;
        this.pathEco_American = 33;
        this.pathEco_Soviet = 33;
        this.pathEco_German = 33;
        this.pathWar_Offensive = 50;
        this.pathWar_Defensive = 50;
      }
      this.aiLoyal = 50;
      if (this.data.StringListObj[this.slotRegimes].Width < 13)
        return;
      int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 13)));
      if (idValue > 0)
      {
        int setValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotImod].GetData(0, idValue, 8)));
        this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, nameof (aiHawk), 2, setValue);
        this.aiHawk = setValue;
      }
      if (this.data.StringListObj[this.slotImod].Width >= 12)
      {
        if (idValue <= 0)
          return;
        int setValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotImod].GetData(0, idValue, 12)));
        this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, nameof (aiLoyal), 2, setValue);
        this.aiLoyal = setValue;
        int num2 = new Random(this.data.GameID + 10230 * this.data.RegimeObj[this.data.Turn].id + 444 * idValue).Next(0, 100);
        if (num2 <= 10)
          this.aiLoyal -= 40;
        else if (num2 <= 33)
          this.aiLoyal -= 20;
        else if (num2 >= 90)
          this.aiLoyal += 40;
        else if (num2 >= 66)
          this.aiLoyal += 20;
        if (this.aiLoyal >= 10)
          return;
        this.aiLoyal = 10;
      }
      else
      {
        if (idValue <= 0)
          return;
        int setValue = 50;
        if (this.aiHawk >= 100)
          setValue = 30;
        else if (this.aiHawk <= 66)
          setValue = 70;
        this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, nameof (aiLoyal), 2, setValue);
        this.aiLoyal = setValue;
      }
    }

    public int Run()
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 1)));
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
      int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 56, 2)));
      int idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 2)));
      int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotCulture].GetData(0, idValue1, 1)));
      int num5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotCultureKey].GetData2(0, idValue1, 1, "ZeroPop", 2)));
      this.data.RuleVar[995] = 0.0f;
      this.data.RuleVar[993] = 0.0f;
      int regimeCounter = this.data.RegimeCounter;
      for (int index = 1; index <= regimeCounter; ++index)
      {
        this.data.RegimeObj[index].AIHelpMove = 0;
        this.data.RegimeObj[index].AIHelpCombat = 0;
        if (this.data.RegimeObj[index].AI)
        {
          if (num2 == 0)
          {
            this.data.RegimeObj[index].AIHelpMove = 0;
            this.data.RegimeObj[index].AIHelpCombat = 0;
          }
          else if (num2 == 10)
          {
            this.data.RegimeObj[index].AIHelpMove = 0;
            this.data.RegimeObj[index].AIHelpCombat = 0;
            this.data.RuleVar[995] = 2f;
          }
          else if (num2 == 20)
          {
            this.data.RegimeObj[index].AIHelpMove = 10;
            this.data.RegimeObj[index].AIHelpCombat = 10;
            this.data.RuleVar[995] = 2f;
            this.data.RuleVar[993] = 1f;
          }
          else if (num2 >= 30)
          {
            this.data.RegimeObj[index].AIHelpMove = 20;
            this.data.RegimeObj[index].AIHelpCombat = 20;
            this.data.RuleVar[995] = 1f;
            this.data.RuleVar[993] = 1f;
          }
        }
      }
      int landscapeTypeCounter = this.data.LandscapeTypeCounter;
      for (int index = 0; index <= landscapeTypeCounter; ++index)
      {
        this.data.LandscapeTypeObj[index].MoveCost[50] = 1;
        if (this.data.LandscapeTypeObj[index].MoveCost[8] > 1)
          this.data.LandscapeTypeObj[index].MoveCost[50] = this.data.LandscapeTypeObj[index].MoveCost[8];
        if (num5 > 0)
          this.data.LandscapeTypeObj[index].MoveCost[50] = 1;
      }
      int roadTypeCounter = this.data.RoadTypeCounter;
      for (int index = 0; index <= roadTypeCounter; ++index)
      {
        this.data.RoadTypeObj[index].MoveCostOverrule[50] = 1;
        if (this.data.RoadTypeObj[index].MoveCostOverrule[8] > 1)
          this.data.RoadTypeObj[index].MoveCostOverrule[50] = this.data.RoadTypeObj[index].MoveCostOverrule[8];
        if (num5 > 0)
          this.data.RoadTypeObj[index].MoveCostOverrule[50] = 1;
      }
      int riverTypeCounter = this.data.RiverTypeCounter;
      for (int index = 0; index <= riverTypeCounter; ++index)
      {
        this.data.RiverTypeObj[index].MovePenalty[50] = 0;
        if (this.data.RiverTypeObj[index].MovePenalty[8] > 0)
          this.data.RiverTypeObj[index].MovePenalty[50] = this.data.RiverTypeObj[index].MovePenalty[8];
        if (num5 > 0)
          this.data.RiverTypeObj[index].MovePenalty[50] = 0;
      }
      this.data.RuleVar[913] = 0.0f;
      this.data.RuleVar[521] = 1f;
      this.data.RuleVar[343] = 0.0f;
      this.data.RuleVar[520] = 1f;
      this.data.RuleVar[512] = 1f;
      this.data.RuleVar[335] = 10f;
      this.data.RuleVar[961] = 1f;
      this.data.RuleVar[962] = 0.0f;
      this.data.RuleVar[931] = 4f;
      this.data.RuleVar[99] = 50f;
      this.data.RuleVar[967] = 3f;
      this.data.RuleVar[968] = 4f;
      this.data.RuleVar[940] = 1f;
      this.data.RuleVar[963] = 0.0f;
      this.data.RuleVar[941] = 0.0f;
      this.data.RuleVar[948] = 0.0f;
      this.ai.VAR_DEBUG_ON = false;
      if (this.data.Turn == 4 & DrawMod.TGame.EventRelatedObj.Helper_IsDebug() && DrawMod.TGame.EditObj.debugAiOnlyTillRound < this.data.Round)
        this.data.DontShowAIMove = true;
      this.data.RuleVar[919] = 0.0f;
      this.data.RuleVar[920] = 0.0f;
      this.data.RuleVar[923] = 0.0f;
      this.data.RuleVar[924] = 0.0f;
      this.data.RuleVar[922] = 0.0f;
      this.data.RuleVar[969] = 0.0f;
      this.data.RegimeObj[this.data.Turn].ProdBonus = 0;
      if (num1 == 1)
      {
        if (num3 == 1)
          this.data.RegimeObj[this.data.Turn].ProdBonus = 100;
        if (num3 == 2)
          this.data.RegimeObj[this.data.Turn].ProdBonus = 250;
        this.data.RuleVar[969] = 8f;
        if (DrawMod.TGame.Data.Round <= 5)
        {
          this.data.RuleVar[919] = 0.0f;
          this.data.RuleVar[920] = 0.0f;
          this.data.RuleVar[922] = 20f;
          this.data.RuleVar[923] = 0.0f;
          this.data.RuleVar[924] = 0.0f;
        }
        else if (DrawMod.TGame.Data.Round < 13)
        {
          this.data.RuleVar[919] = 4f;
          this.data.RuleVar[920] = 2f;
          this.data.RuleVar[922] = 20f;
        }
        else if (DrawMod.TGame.Data.Round < 22)
        {
          this.data.RuleVar[919] = 4f;
          this.data.RuleVar[920] = 3f;
          this.data.RuleVar[922] = 20f;
          this.data.RuleVar[923] = 15f;
          this.data.RuleVar[924] = 2f;
        }
        else if (DrawMod.TGame.Data.Round < 35)
        {
          this.data.RuleVar[919] = 4f;
          this.data.RuleVar[920] = 3f;
          this.data.RuleVar[922] = 20f;
          this.data.RuleVar[923] = 15f;
          this.data.RuleVar[924] = 3f;
        }
        else if (DrawMod.TGame.Data.Round < 50)
        {
          this.data.RuleVar[919] = 3f;
          this.data.RuleVar[920] = 3f;
          this.data.RuleVar[922] = 20f;
          this.data.RuleVar[923] = 15f;
          this.data.RuleVar[924] = 4f;
        }
        else
        {
          this.data.RuleVar[919] = 2f;
          this.data.RuleVar[920] = 3f;
          this.data.RuleVar[922] = 20f;
          this.data.RuleVar[923] = 15f;
          this.data.RuleVar[924] = 5f;
        }
      }
      else if (num1 != 2)
        ;
      this.data.RuleVar[921] = 0.0f;
      this.data.RuleVar[993] = 1f;
      this.data.RuleVar[939] = 9f;
      this.data.RuleVar[932] = 4f;
      this.data.RuleVar[933] = 11f;
      this.data.RuleVar[917] = 0.0f;
      this.data.RuleVar[918] = 0.0f;
      this.data.RuleVar[962] = 1f;
      this.data.RuleVar[943] = 1.25f;
      this.data.RuleVar[942] = 0.8f;
      this.data.RuleVar[917] = 0.0f;
      this.data.RuleVar[918] = 0.0f;
      this.data.RuleVar[3] = 250f;
      this.data.RuleVar[51] = 150f;
      this.data.RuleVar[52] = 180f;
      this.data.RuleVar[53] = 210f;
      this.data.RuleVar[748] = 1f;
      this.data.RuleVar[958] = 0.0f;
      this.data.RuleVar[980] = 0.0f;
      this.data.RuleVar[981] = 0.0f;
      if (this.data.Turn == 6)
        num1 = num1;
      switch (num1)
      {
        case 1:
          if (num1 == 1)
          {
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "victoryScore", 2))) < 1)
              return 1;
          }
          float num6 = this.data.RuleVar[941];
          this.data.RuleVar[941] = 1f;
          bool varDebugOn = this.ai.VAR_DEBUG_ON;
          this.ai.MakeCombatMatrix(true);
          this.SetRegimeCombatMatrix();
          this.GetSHQgroupsAndStagesAndOobAndSHQchanges();
          this.SetStrategicAnalysis();
          this.DisbandExcessTroops();
          this.SetModelQualities();
          this.InitializeAir();
          this.SetOOBratingList();
          this.LeaderStuff();
          this.PlayCards();
          ref DC2AIClass local1 = ref this.ai;
          Shadow_Strategic_AI shadowStrategicAi = this;
          ref Shadow_Strategic_AI local2 = ref shadowStrategicAi;
          Shadow_Economic_AI aiEconomic = new Shadow_Economic_AI(ref local1, ref local2);
          aiEconomic.Run1();
          this.SetPaths(ref aiEconomic);
          this.BuyTechModelsOobs(ref aiEconomic);
          this.SetModelQualities();
          this.SetHQs();
          aiEconomic.Run2();
          this.FireICBMs();
          this.SpecialDebugLogs();
          this.data.RuleVar[941] = num6;
          this.ai.VAR_DEBUG_ON = varDebugOn;
          this.data.RuleVar[943] = 1f;
          this.data.RuleVar[943] = this.pathWar_Offensive <= 80 ? (this.pathWar_Offensive <= 65 ? (this.pathWar_Offensive <= 50 ? (this.pathWar_Offensive <= 30 ? (this.pathWar_Offensive <= 10 ? 0.9f : 1f) : 1.15f) : 1.3f) : 1.5f) : 1.6f;
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathEco_American", 2, this.pathEco_American, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathEco_Soviet", 2, this.pathEco_Soviet, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathEco_German", 2, this.pathEco_German, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathTech_Artillery", 2, this.pathTech_Artillery, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathTech_Economy", 2, this.pathTech_Economy, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathTech_Military", 2, this.pathTech_Military, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathWar_Defensive", 2, this.pathWar_Defensive, true);
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "pathWar_Offensive", 2, this.pathWar_Offensive, true);
          if (num2 >= 40)
          {
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "incomeTax", 2, 50, true);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "salesTax", 2, 50, true);
          }
          else if (num2 >= 30)
          {
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "incomeTax", 2, 40, true);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "salesTax", 2, 40, true);
          }
          else if (num2 >= 20)
          {
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "incomeTax", 2, 40, true);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "salesTax", 2, 40, true);
          }
          else if (num2 >= 10)
          {
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "incomeTax", 2, 30, true);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "salesTax", 2, 30, true);
          }
          else
          {
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "incomeTax", 2, 20, true);
            this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "salesTax", 2, 20, true);
          }
          return 0;
        case 2:
          if (num3 == 1)
          {
            this.data.RegimeObj[this.data.Turn].ProdBonus = 100;
            break;
          }
          break;
      }
      this.data.RuleVar[943] = 1.33f;
      this.data.RuleVar[942] = 0.66f;
      this.data.RuleVar[917] = 1f;
      this.data.RuleVar[918] = 1f;
      this.data.RuleVar[939] = 2f;
      this.data.RuleVar[993] = 0.0f;
      this.data.RuleVar[962] = 2f;
      this.data.RuleVar[932] = 6f;
      this.data.RuleVar[933] = 24f;
      this.data.RuleVar[917] = 1f;
      this.data.RuleVar[918] = 1f;
      this.data.RuleVar[919] = 3f;
      this.data.RuleVar[920] = 3f;
      this.data.RuleVar[922] = 9f;
      this.data.RuleVar[923] = 9f;
      this.data.RuleVar[924] = 4f;
      this.data.RuleVar[921] = 0.0f;
      this.data.RuleVar[3] = 400f;
      this.data.RuleVar[51] = 300f;
      this.data.RuleVar[52] = 333f;
      this.data.RuleVar[53] = 366f;
      int length = this.data.StringListObj[this.slotZones].Length;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        int idValue2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 0]));
        int num7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 8]));
        int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index1, 6]));
        if (num7 == this.RegimeId)
        {
          if (id > 0)
          {
            int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1)
            {
              int num8 = 10 + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue2, 1, "city", 2))) * 3;
              int tfacing = 1;
              do
              {
                Coordinate coordinate = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, 0, tfacing);
                if (coordinate.onmap)
                {
                  this.data.RegimeObj[this.data.Turn].AIVP[0].Value[coordinate.x, coordinate.y] = 2;
                  HexClass[,] hexObj = this.data.MapObj[0].HexObj;
                  HexClass[,] hexClassArray = hexObj;
                  int x = coordinate.x;
                  int index2 = x;
                  int y = coordinate.y;
                  int index3 = y;
                  hexClassArray[index2, index3].VP = hexObj[x, y].VP + 2;
                }
                ++tfacing;
              }
              while (tfacing <= 6);
              int num9 = num8 * 2;
              int[,] numArray1 = this.data.RegimeObj[this.data.Turn].AIVP[0].Value;
              int[,] numArray2 = numArray1;
              int x1 = this.data.LocObj[locationById].X;
              int index4 = x1;
              int y1 = this.data.LocObj[locationById].Y;
              int index5 = y1;
              int num10 = numArray1[x1, y1] + num9;
              numArray2[index4, index5] = num10;
              HexClass[,] hexObj1 = this.data.MapObj[0].HexObj;
              HexClass[,] hexClassArray1 = hexObj1;
              int x2 = this.data.LocObj[locationById].X;
              int index6 = x2;
              int y2 = this.data.LocObj[locationById].Y;
              int index7 = y2;
              hexClassArray1[index6, index7].VP = hexObj1[x2, y2].VP + (int) Math.Round((double) num9 / 4.0);
            }
          }
        }
        else if (id > 0)
        {
          int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1)
          {
            int num11 = 5 + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue2, 1, "city", 2))) * 2;
            this.data.RegimeObj[this.data.Turn].AIVP[0].Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y] = num11;
          }
        }
      }
      if (num1 == 4)
      {
        new Shadow_MinorAntAI(ref this.ai).Run();
        return 1;
      }
      if (num1 == 2 | num1 == 3)
        new Shadow_Minor(ref this.ai).Run();
      return 0;
    }

    public void InitializeAir()
    {
      string str1 = "8602_AI_InitializeAir";
      bool flag1 = false;
      if ((int) Math.Round(Conversion.Val(this.data.Designer)) >= 90 && new Random((int) Math.Round((double) this.data.GameID / 1000.0) * this.data.RegimeObj[this.data.Turn].id).Next(0, 100) < 40)
        flag1 = true;
      this.Air_Yes = false;
      this.Air_JustFlak = false;
      this.Air_None = true;
      this.Air_Economical_AirBased = 0;
      this.Air_Economical_RocketBased = 0;
      this.Air_Economical_ThopterBased = 0;
      this.Air_Aircraft_AsPercentage_Of_Land = 0;
      this.Air_Flak_AsPercentage_Of_Land = 0;
      this.OurLossDueToAir = 0;
      this.OurLossDueToTank = 0;
      this.OurKillDueToAir = 0;
      this.OurKillDueToTank = 0;
      this.ai.SE1_USEFLAK = false;
      if (!DrawMod.TGame.EventRelatedObj.Helper_AirEnabled())
        return;
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      if (this.ai.game.Data.Round <= 1)
      {
        int stringListById = this.ai.game.HandyFunctionsObj.GetStringListByID(this.ai.game.EventRelatedObj.CheckStringlistID("SE_Random", 86, 0, 0));
        int num1 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[stringListById].GetData(0, 17, 2)));
        int num2 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[stringListById].GetData(0, 21, 2)));
        bool flag2 = true;
        bool flag3 = true;
        if (this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(102, this.RegimeId, 282, 303, 405, 427, 501, minimumRange: 4).Weight[0] < 1)
        {
          flag2 = false;
          this.Air_Economical_AirBased = 0;
        }
        else if (this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(102, this.RegimeId, 282, 303, 405, 427, 501).Weight[0] < 1)
        {
          flag2 = true;
          this.Air_Economical_AirBased = 50;
        }
        else if (this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(102, this.RegimeId, 282, 303, 405, 427, 501, minimumRange: 12).Weight[0] < 1)
        {
          flag2 = true;
          this.Air_Economical_AirBased = 100;
        }
        else
        {
          flag2 = true;
          this.Air_Economical_AirBased = 150;
        }
        if (this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(102, this.RegimeId, 282, 373, 401, 429, 501, minimumRange: 4).Weight[0] < 1)
        {
          flag3 = false;
          this.Air_Economical_RocketBased = 0;
        }
        else if (this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(102, this.RegimeId, 282, 373, 401, 429, 501).Weight[0] < 1)
        {
          flag3 = true;
          this.Air_Economical_RocketBased = 50;
        }
        else if (this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(102, this.RegimeId, 282, 373, 401, 429, 501, minimumRange: 12).Weight[0] < 1)
        {
          flag3 = true;
          this.Air_Economical_RocketBased = 100;
        }
        else
        {
          flag3 = true;
          this.Air_Economical_RocketBased = 150;
        }
        this.Air_Economical_ThopterBased = this.Air_Economical_AirBased < 100 ? 0 : ((double) num1 * 1.3 >= (double) num2 / 10.0 ? ((double) num1 * 1.15 >= (double) num2 / 10.0 ? 100 : 150) : 200);
        this.ai.game.Data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "AI_Economical_Air", 2, this.Air_Economical_AirBased, true);
        this.ai.game.Data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "AI_Economical_Rocket", 2, this.Air_Economical_RocketBased, true);
        this.ai.game.Data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "AI_Economical_Thopter", 2, this.Air_Economical_ThopterBased, true);
      }
      else
      {
        this.Air_Economical_AirBased = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "AI_Economical_Air", 2)));
        this.Air_Economical_RocketBased = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "AI_Economical_Rocket", 2)));
        this.Air_Economical_ThopterBased = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "AI_Economical_Thopter", 2)));
      }
      this.ai.AddLog("");
      this.ai.AddLog("ECONOMICAL RATINGS:");
      this.ai.AddLog("Air-based (propellor/heli) : " + this.Air_Economical_AirBased.ToString());
      this.ai.AddLog("Rocket-based: " + this.Air_Economical_RocketBased.ToString());
      this.ai.AddLog("Thopter-based : " + this.Air_Economical_ThopterBased.ToString());
      this.ai.AddLog("");
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      int num7 = 0;
      int counter1 = this.ShqList.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        num3 += this.friendlyAir[index];
        num5 += this.friendlyEconomicValue[index];
      }
      int num8 = num3 + 5;
      int num9 = 0;
      int regimeCounter1 = this.data.RegimeCounter;
      for (int index = 2; index <= regimeCounter1; ++index)
      {
        if (index != this.data.Turn && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index].id, 1))) == 1 && this.enemyHexes[index] > num9)
          num9 = this.enemyHexes[index];
      }
      int num10 = num9 + 3;
      int regimeCounter2 = this.data.RegimeCounter;
      int num11;
      for (int index1 = 2; index1 <= regimeCounter2; ++index1)
      {
        if (index1 != this.data.Turn)
        {
          int num12 = 0;
          int num13 = 0;
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index1].id, 1))) == 1)
          {
            int counter2 = this.ShqList.Counter;
            for (int index2 = 0; index2 <= counter2; ++index2)
            {
              num12 += this.enemyAir[index2, index1];
              num13 += this.enemyAllEco[index1];
            }
            num11 = 100;
            int num14 = (int) Math.Round((double) ((this.data.RegimeObj[index1].RegimeRel[this.data.Turn] != 0 ? (this.data.RegimeObj[index1].AI ? 10 : 50) : (this.data.RegimeObj[index1].AI ? 50 : 100)) * (this.enemyHexes[index1] + 3)) / (double) num10);
            if (num14 > 0)
            {
              num4 += num12 * num14;
              num6 += num13 * num14;
              num7 += num14;
            }
          }
        }
      }
      if (num7 > 0)
      {
        num4 = (int) Math.Round((double) num4 / (double) num7);
        num6 = (int) Math.Round((double) num6 / (double) num7);
      }
      int num15 = 0;
      int num16 = 0;
      int num17 = 0;
      int num18 = 0;
      float num19 = 0.0f;
      float num20 = 0.0f;
      DataClass data1 = this.data;
      string str2 = "miningType";
      ref string local1 = ref str2;
      int libVar1 = data1.FindLibVar(ref local1, "SE_Data");
      DataClass data2 = this.data;
      string str3 = "miningReserve";
      ref string local2 = ref str3;
      int libVar2 = data2.FindLibVar(ref local2, "SE_Data");
      int mapWidth1 = this.data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth1; ++index3)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          if (this.data.MapObj[0].HexObj[index3, index4].Regime > -1)
            ++num18;
          if (this.data.MapObj[0].HexObj[index3, index4].Regime == this.data.Turn)
            ++num17;
          int hexLibVarValue = this.data.MapObj[0].HexObj[index3, index4].GetHexLibVarValue(libVar1);
          num11 = this.data.MapObj[0].HexObj[index3, index4].GetHexLibVarValue(libVar2);
          if (hexLibVarValue == 1)
          {
            ++num15;
            if (this.data.MapObj[0].HexObj[index3, index4].Regime == this.data.Turn)
              ++num16;
          }
        }
      }
      if (num18 > 0)
        num19 = (float) (100 * num15) / (float) num18;
      if (num17 > 0)
        num20 = (float) (100 * num16) / (float) num17;
      int num21 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 350, 1, this.RegimeId, 2)));
      int num22 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 356, 1, this.RegimeId, 2)));
      if (this.Air_Economical_AirBased > 0 & num21 >= 100)
      {
        this.Air_Yes = true;
        this.Air_JustFlak = false;
        this.Air_None = false;
        this.Air_Aircraft_AsPercentage_Of_Land = 12;
        this.Air_Flak_AsPercentage_Of_Land = 4;
      }
      else if (this.Air_Economical_RocketBased > 0 & num22 >= 100)
      {
        this.Air_Yes = true;
        this.Air_JustFlak = false;
        this.Air_None = false;
        this.Air_Aircraft_AsPercentage_Of_Land = 9;
        this.Air_Flak_AsPercentage_Of_Land = 4;
      }
      else if (this.Air_Economical_RocketBased > 0 | this.Air_Economical_AirBased > 0)
      {
        this.Air_Yes = false;
        this.Air_JustFlak = true;
        this.Air_None = false;
        this.Air_Aircraft_AsPercentage_Of_Land = 0;
        this.Air_Flak_AsPercentage_Of_Land = 2 + (int) Math.Round((double) Math.Max(this.Air_Economical_AirBased, this.Air_Economical_RocketBased) / 15.0);
      }
      else
      {
        this.Air_Yes = false;
        this.Air_JustFlak = false;
        this.Air_None = true;
        this.Air_Aircraft_AsPercentage_Of_Land = 0;
        this.Air_Flak_AsPercentage_Of_Land = 0;
      }
      if (this.data.Round < 10)
      {
        num6 = (int) Math.Round((double) num6 * 0.5);
        num4 = (int) Math.Round((double) num4 * 0.2);
      }
      else if (this.data.Round < 20)
      {
        num6 = (int) Math.Round((double) num6 * 0.65);
        num4 = (int) Math.Round((double) num4 * 0.4);
      }
      else if (this.data.Round < 30)
      {
        num6 = (int) Math.Round((double) num6 * 0.8);
        num4 = (int) Math.Round((double) num4 * 0.6);
      }
      else if (this.data.Round < 40)
      {
        num6 = (int) Math.Round((double) num6 * 0.9);
        num4 = (int) Math.Round((double) num4 * 0.8);
      }
      if (!flag1)
      {
        if (num4 > num8 * 4 & num6 > num5 * 3)
        {
          this.Air_Yes = false;
          this.Air_JustFlak = false;
          this.Air_None = true;
        }
        else if ((double) num4 > (double) num8 * 1.5 & (double) num6 > (double) num5 * 1.66)
        {
          this.Air_Yes = false;
          this.Air_JustFlak = true;
          this.Air_Flak_AsPercentage_Of_Land = 12;
          this.Air_Aircraft_AsPercentage_Of_Land = 0;
        }
        else if ((double) num4 > (double) num8 * 1.5 & (double) num6 > (double) num5 * 1.25)
        {
          this.Air_JustFlak = false;
          this.Air_Flak_AsPercentage_Of_Land = 6;
        }
        else if (!((double) num4 > (double) num8 * 0.9 & (double) num6 > (double) num5 * 0.9))
        {
          if ((double) num4 > (double) num8 * 0.5)
            this.Air_Flak_AsPercentage_Of_Land = 3;
          else if (num4 == 0)
            ;
        }
      }
      if ((double) num20 > (double) num19)
        num19 = num20;
      if ((double) num19 > 0.8)
        this.Air_Aircraft_AsPercentage_Of_Land = (int) Math.Round((double) this.Air_Aircraft_AsPercentage_Of_Land * 1.8);
      else if ((double) num19 > 0.5)
        this.Air_Aircraft_AsPercentage_Of_Land = (int) Math.Round((double) this.Air_Aircraft_AsPercentage_Of_Land * 1.5);
      else if ((double) num19 > 0.3)
        this.Air_Aircraft_AsPercentage_Of_Land = (int) Math.Round((double) this.Air_Aircraft_AsPercentage_Of_Land * 1.2);
      else if ((double) num19 > 0.1)
        this.Air_Aircraft_AsPercentage_Of_Land *= 1;
      else
        this.Air_Aircraft_AsPercentage_Of_Land = (int) Math.Round((double) this.Air_Aircraft_AsPercentage_Of_Land * 0.8);
      this.ai.AddLog("Air Yes : " + this.Air_Yes.ToString());
      this.ai.AddLog("Air FlakOnly : " + this.Air_JustFlak.ToString());
      this.ai.AddLog("Air % of Land : " + this.Air_Aircraft_AsPercentage_Of_Land.ToString());
      this.ai.AddLog("Flak % of Land : " + this.Air_Flak_AsPercentage_Of_Land.ToString());
      int num23 = 0;
      int num24 = 0;
      int unitCounter1 = this.data.UnitCounter;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn && this.data.UnitObj[unr].PreDef == -1 && DrawMod.TGame.HandyFunctionsObj.HasUnitAirSF(unr))
        {
          if (this.data.UnitObj[unr].TempCategory == 3)
            ++num23;
          else if (this.data.UnitObj[unr].TempCategory == 13)
            ++num24;
        }
      }
      this.Air_Cover = 50;
      this.Air_Support = 50;
      if (num24 > 0 | num23 > 0)
      {
        this.Air_Cover = (int) Math.Round((double) (num24 * 100) / (double) (num23 + num24));
        this.Air_Support = 100 - this.Air_Cover;
        int num25 = (int) Math.Round((double) (100 * num8) / (double) (num4 + 1));
        if (num25 < 50)
          this.Air_Cover = (int) Math.Round((double) (200 + this.Air_Cover) / 3.0);
        else if (num25 < 75)
          this.Air_Cover = (int) Math.Round((double) (100 + this.Air_Cover) / 2.0);
      }
      if (this.Air_Cover < 20)
        this.Air_Cover = 20;
      if (this.Air_Support < 20)
        this.Air_Support = 20;
      if (this.ai.game.Data.Turn == 6)
        num23 = num23;
      int num26 = 0;
      int num27 = 0;
      int sfTypeCounter1 = this.ai.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter1; ++index)
      {
        int idValue = this.ai.game.Data.SFTypeObj[index].SFTypeVar[81];
        if (idValue > 0)
        {
          num23 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeModels].GetData(0, idValue, 2)));
          if (num23 == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
          {
            num26 += this.ai.game.Data.SFTypeObj[index].SFTypeVar[1];
            this.OurLossDueToTank += this.ai.game.Data.SFTypeObj[index].SFTypeVar[2];
            this.OurLossDueToAir += this.ai.game.Data.SFTypeObj[index].SFTypeVar[3];
            num27 += this.ai.game.Data.SFTypeObj[index].SFTypeVar[4];
            if (this.ai.game.Data.SFTypeObj[index].UnitGroup == 3 | this.ai.game.Data.SFTypeObj[index].UnitGroup == 4)
              this.OurKillDueToTank += this.ai.game.Data.SFTypeObj[index].SFTypeVar[4];
            else if (this.ai.game.Data.SFTypeObj[index].UnitGroup == 8 | this.ai.game.Data.SFTypeObj[index].UnitGroup == 9)
              this.OurKillDueToAir += this.ai.game.Data.SFTypeObj[index].SFTypeVar[4];
          }
        }
      }
      if (num26 > 0)
        this.OurLossDueToTank = (int) Math.Round((double) (this.OurLossDueToTank * 100) / (double) num26);
      if (num26 > 0)
        this.OurLossDueToAir = (int) Math.Round((double) (this.OurLossDueToAir * 100) / (double) num26);
      if (num27 > 0)
        this.OurKillDueToTank = (int) Math.Round((double) (this.OurKillDueToTank * 100) / (double) num27);
      if (num27 > 0)
        this.OurKillDueToAir = (int) Math.Round((double) (this.OurKillDueToAir * 100) / (double) num27);
      int num28 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].GetData2(0, DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].id, 1, "Ai_IdealFlakCity", 2)));
      int num29 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].GetData2(0, DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].id, 1, "Ai_CurrentFlakCity", 2)));
      int num30 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].GetData2(0, DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].id, 1, "Ai_IdealFlakUnit", 2)));
      int num31 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimeKeys].GetData2(0, DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].id, 1, "Ai_CurrentFlakUnit", 2)));
      if (this.Air_JustFlak | this.Air_Yes && num28 > 0 | num30 > 0)
      {
        num23 = 0;
        int num32 = 0;
        int num33 = 0;
        int num34 = 0;
        if (num28 > 0)
          num23 = (int) Math.Round((double) (num28 - num29) / (double) num28 * (double) num28);
        if (num30 > 0)
          num32 = (int) Math.Round((double) (num30 - num31) / (double) num30 * (double) num30);
        int unitCounter2 = this.data.UnitCounter;
        for (int index = 0; index <= unitCounter2; ++index)
        {
          if (this.data.UnitObj[index].Regime == this.data.Turn & this.data.UnitObj[index].PreDef == -1)
            ++num33;
        }
        int length = DrawMod.TGame.Data.StringListObj[this.slotZones].Length;
        for (int index = 0; index <= length; ++index)
        {
          int num35 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].Data[index, 0]));
          if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].Data[index, 8])) == this.RegimeId)
          {
            int id = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].Data[index, 6]));
            if (DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id) > -1)
              ++num34;
          }
        }
        int num36 = (int) Math.Round((double) (num23 * 100) / (double) (5 * (num34 + 1)));
        int num37 = (int) Math.Round((double) (num32 * 100) / (double) (5 * (num33 + 1)));
        int num38 = (int) Math.Round((double) (100 * num4) / (double) (num8 + 1));
        if (num38 < 33)
          num38 = 33;
        if (num38 > 500)
          num38 = 500;
        if (num38 > 150)
          num38 = 150 + (int) Math.Round((double) (num38 - 150) * 0.8);
        if (num38 > 200)
          num38 = 200 + (int) Math.Round((double) (num38 - 200) * 0.6);
        if (num38 > 250)
          num38 = 250 + (int) Math.Round((double) (num38 - 250) * 0.4);
        if (num38 > 300)
          num38 = 300 + (int) Math.Round((double) (num38 - 300) * 0.2);
        if (num38 > 350)
          num38 = 350;
        int num39 = (int) Math.Round((double) (num36 * num38) / 100.0);
        int num40 = (int) Math.Round((double) (num37 * num38) / 100.0);
        if (num39 < 5 & num40 < 5 | num39 + num40 < 10)
          this.Air_Flak_AsPercentage_Of_Land += 0;
        else if (num39 < 10 & num40 < 10 | num39 + num40 < 20)
          this.Air_Flak_AsPercentage_Of_Land += 3;
        else if (num39 < 25 & num40 < 25 | num39 + num40 < 50)
          this.Air_Flak_AsPercentage_Of_Land += 7;
        else if (num39 < 40 & num40 < 40 | num39 + num40 < 80)
          this.Air_Flak_AsPercentage_Of_Land += 12;
        else if (num39 < 60 & num40 < 60 | num39 + num40 < 120)
          this.Air_Flak_AsPercentage_Of_Land += 18;
        else if (num39 < 80 & num40 < 80 | num39 + num40 < 160)
          this.Air_Flak_AsPercentage_Of_Land += 25;
        else if (num39 < 100 & num40 < 100 | num39 + num40 < 240)
          this.Air_Flak_AsPercentage_Of_Land += 35;
        else
          this.Air_Flak_AsPercentage_Of_Land += 45;
        this.ai.AddLog("ADJUSTED Flak % of Land : " + this.Air_Flak_AsPercentage_Of_Land.ToString());
      }
      if ((this.ai.game.Data.Round + 10) % 10 == 0)
      {
        int sfTypeCounter2 = this.ai.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter2; ++index)
        {
          int idValue = this.ai.game.Data.SFTypeObj[index].SFTypeVar[81];
          if (idValue > 0)
          {
            num23 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeModels].GetData(0, idValue, 2)));
            if (num23 == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
            {
              this.ai.game.Data.SFTypeObj[index].SFTypeVar[1] = (int) Math.Round(Math.Floor((double) this.ai.game.Data.SFTypeObj[index].SFTypeVar[1] / 2.0));
              this.ai.game.Data.SFTypeObj[index].SFTypeVar[2] = (int) Math.Round(Math.Floor((double) this.ai.game.Data.SFTypeObj[index].SFTypeVar[2] / 2.0));
              this.ai.game.Data.SFTypeObj[index].SFTypeVar[3] = (int) Math.Round(Math.Floor((double) this.ai.game.Data.SFTypeObj[index].SFTypeVar[3] / 2.0));
              this.ai.game.Data.SFTypeObj[index].SFTypeVar[4] = (int) Math.Round(Math.Floor((double) this.ai.game.Data.SFTypeObj[index].SFTypeVar[4] / 2.0));
              this.ai.game.Data.SFTypeObj[index].SFTypeVar[5] = (int) Math.Round(Math.Floor((double) this.ai.game.Data.SFTypeObj[index].SFTypeVar[5] / 2.0));
              this.ai.game.Data.SFTypeObj[index].SFTypeVar[6] = (int) Math.Round(Math.Floor((double) this.ai.game.Data.SFTypeObj[index].SFTypeVar[6] / 2.0));
            }
          }
        }
      }
      int index5;
      if (this.Air_Yes)
      {
        int length1 = DrawMod.TGame.Data.StringListObj[this.slotZones].Length;
        for (int index6 = 0; index6 <= length1; ++index6)
        {
          int zoneId = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].Data[index6, 0]));
          if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].Data[index6, 8])) == this.RegimeId)
          {
            int id = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].Data[index6, 6]));
            int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1 && DrawMod.TGame.EventRelatedObj.CheckHardcoded_AssetFamilyLevel(zoneId, 551, DrawMod.TGame.Data.LocObj[locationById].X, DrawMod.TGame.Data.LocObj[locationById].Y) < 1)
            {
              EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
              string val1 = 18.ToString();
              string val2 = zoneId.ToString();
              index5 = 551;
              string val3 = index5.ToString();
              eventRelatedObj.DoExec(-1, 346, val1, val2, val3, "0", "");
            }
          }
        }
        DataClass data3 = DrawMod.TGame.Data;
        string str4 = "airbasePoints";
        ref string local3 = ref str4;
        int libVar3 = data3.FindLibVar(ref local3, "SE_Data");
        DataClass data4 = DrawMod.TGame.Data;
        str4 = "prevAirbasePoints";
        ref string local4 = ref str4;
        int libVar4 = data4.FindLibVar(ref local4, "SE_Data");
        DataClass data5 = DrawMod.TGame.Data;
        str4 = "zones";
        ref string local5 = ref str4;
        int libVar5 = data5.FindLibVar(ref local5, "SE_Data");
        bool[,] flagArray = new bool[this.data.MapObj[0].MapWidth + 1, this.data.MapObj[0].MapHeight + 1];
        bool flag4 = false;
        bool flag5 = false;
        int unitCounter3 = this.data.UnitCounter;
        for (int unr = 0; unr <= unitCounter3; ++unr)
        {
          int index7 = unr;
          if (this.data.UnitObj[unr].Regime == this.data.Turn && this.data.UnitObj[unr].PreDef == -1 && !flagArray[this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y] && DrawMod.TGame.HandyFunctionsObj.HasUnitAirSF(unr))
          {
            int num41 = 0;
            flagArray[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y] = true;
            int unitCounter4 = this.data.MapObj[0].HexObj[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y].UnitCounter;
            for (int index8 = 0; index8 <= unitCounter4; ++index8)
            {
              int unit = this.data.MapObj[0].HexObj[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y].UnitList[index8];
              int sfCount = this.data.UnitObj[unit].SFCount;
              for (int index9 = 0; index9 <= sfCount; ++index9)
              {
                int sf = this.data.UnitObj[unit].SFList[index9];
                int type = this.data.SFObj[sf].Type;
                if (this.data.SFTypeObj[type].Theater == 2 && this.data.SFTypeObj[type].SFTypeVar[18] > 0)
                {
                  int d = this.data.SFTypeObj[type].SFTypeVar[22];
                  num41 += (int) Math.Round(Math.Floor(Math.Sqrt((double) d)) * (double) this.data.SFObj[sf].Qty);
                }
              }
            }
            if (num41 > 0)
            {
              int num42 = Math.Max(this.data.MapObj[0].HexObj[this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y].GetHexLibVarValue(libVar4), this.data.MapObj[0].HexObj[this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y].GetHexLibVarValue(libVar3));
              num23 = this.data.MapObj[0].HexObj[this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y].GetHexLibVarValue(libVar5);
              if (num23 > 0)
              {
                if (num42 > num41)
                {
                  if (DrawMod.TGame.EventRelatedObj.CheckHardcoded_AssetFamilyLevel(num23, 551, this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y) > 2 & !flag5 & (int) Math.Round((double) num42 / 5.0) > num41)
                  {
                    flag5 = true;
                    DrawMod.TGame.EventRelatedObj.ExecHardcoded_AssetDecreaseLevel(num23, 551, 1, useX: this.data.UnitObj[index7].X, useY: this.data.UnitObj[index7].Y);
                  }
                }
                else
                {
                  int num43 = DrawMod.TGame.EventRelatedObj.CheckHardcoded_AssetFamilyLevel(num23, 551, this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y);
                  if (num43 < 1)
                    DrawMod.TGame.EventRelatedObj.Helper_AddAsset(num23, this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y, 551);
                  else if (num43 < 5 & !flag4 & num43 * 40 < num41)
                  {
                    flag4 = true;
                    DrawMod.TGame.EventRelatedObj.ExecHardcoded_AssetIncreaseLevel(num23, 551, this.data.UnitObj[index7].X, this.data.UnitObj[index7].Y);
                  }
                }
              }
            }
          }
        }
        AIMatrix aiMatrix1 = new AIMatrix(ref this.ai);
        AIMatrix aiMatrix2 = new AIMatrix(ref this.ai);
        int mapWidth2 = this.data.MapObj[0].MapWidth;
        for (int index10 = 0; index10 <= mapWidth2; ++index10)
        {
          int mapHeight = this.data.MapObj[0].MapHeight;
          for (int index11 = 0; index11 <= mapHeight; ++index11)
          {
            if (this.data.MapObj[0].HexObj[index10, index11].Regime != this.data.Turn && this.data.MapObj[0].HexObj[index10, index11].Regime != -1)
              aiMatrix2.Value[index10, index11] = 1;
          }
        }
        aiMatrix2.ExpandValueWithoutConditions(2);
        int counter3 = this.ShqList.Counter;
        for (int index12 = 0; index12 <= counter3; ++index12)
        {
          this.shqHisId = this.ShqList.Id[index12];
          this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
          this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
          this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
          aiMatrix1.Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y] = 1;
        }
        aiMatrix1.ExpandValueForAnyRegimeOverRoadOnly();
        if (this.data.Turn == 6)
          ;
        AIMatrix aiMatrix3 = new AIMatrix(ref this.ai);
        AIMatrix aiMatrix4 = new AIMatrix(ref this.ai);
        int range = 0;
        int num44 = 0;
        int unitCounter5 = this.data.UnitCounter;
        int num45;
        for (int unr = 0; unr <= unitCounter5; ++unr)
        {
          if (this.data.UnitObj[unr].Regime == this.data.Turn && this.data.UnitObj[unr].PreDef == -1)
          {
            if (DrawMod.TGame.HandyFunctionsObj.HasUnitAirSF(unr))
            {
              int num46 = (int) Math.Round(Math.Floor((double) DrawMod.TGame.HandyFunctionsObj.GetMaxAirRange(unr) * 0.6));
              if (num46 < 5)
                num46 = 5;
              range += num46;
              ++num44;
              ++num45;
              if (num46 > aiMatrix3.Value[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y])
                aiMatrix3.Value[this.data.UnitObj[unr].X, this.data.UnitObj[unr].Y] = num46;
            }
            else
            {
              int[,] numArray1 = aiMatrix4.Value;
              int[,] numArray2 = numArray1;
              index5 = this.data.UnitObj[unr].X;
              int index13 = index5;
              int y = this.data.UnitObj[unr].Y;
              int index14 = y;
              int num47 = numArray1[index5, y] + 100;
              numArray2[index13, index14] = num47;
            }
          }
        }
        if (num44 > 0)
        {
          range = (int) Math.Round((double) range / (double) num44);
          if (range > 10)
            range = 10;
        }
        int num48 = 0;
        if (range > 2)
        {
          int length2 = this.data.StringListObj[this.slotAssets].Length;
          for (int index15 = 0; index15 <= length2; ++index15)
          {
            int num49 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index15, 1]));
            if (num49 >= 551 & num49 <= 559)
            {
              int index16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index15, 3]));
              int index17 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index15, 4]));
              if (index16 > -1 && this.data.MapObj[0].HexObj[index16, index17].Regime == this.data.Turn)
              {
                ++num48;
                if (range > aiMatrix3.Value[index16, index17])
                  aiMatrix3.Value[index16, index17] = range;
              }
            }
          }
        }
        aiMatrix3.ExpandValueWithoutConditionsDimishWithOne(99);
        if (num45 * 3 < num48)
          num44 = 0;
        if (num44 > 0 && range > 3)
        {
          int mapWidth3 = this.data.MapObj[0].MapWidth;
          for (int index18 = 0; index18 <= mapWidth3; ++index18)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index19 = 0; index19 <= mapHeight; ++index19)
            {
              if (aiMatrix3.Value[index18, index19] > 0)
                aiMatrix4.Value[index18, index19] = 0;
            }
          }
          AIMatrix aiMatrix5 = aiMatrix4.AverageValuesForAnyRegime(range);
          int mapWidth4 = this.data.MapObj[0].MapWidth;
          for (int index20 = 0; index20 <= mapWidth4; ++index20)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index21 = 0; index21 <= mapHeight; ++index21)
            {
              if (aiMatrix1.Value[index20, index21] < 1)
                aiMatrix5.Value[index20, index21] = 0;
            }
          }
          int num50 = 0;
          int index22 = -1;
          int mapWidth5 = this.data.MapObj[0].MapWidth;
          int index23;
          for (int index24 = 0; index24 <= mapWidth5; ++index24)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index25 = 0; index25 <= mapHeight; ++index25)
            {
              if (aiMatrix5.Value[index24, index25] > num50 && aiMatrix5.Value[index24, index25] >= 10 && aiMatrix2.Value[index24, index25] < 1)
              {
                num50 = aiMatrix5.Value[index24, index25];
                index22 = index24;
                index23 = index25;
              }
            }
          }
          if (num50 > 0 & index22 > -1)
          {
            int hexLibVarValue = this.data.MapObj[0].HexObj[index22, index23].GetHexLibVarValue(libVar5);
            if (DrawMod.TGame.EventRelatedObj.CheckHardcoded_AssetFamilyLevel(hexLibVarValue, 551, index22, index23) < 1)
              DrawMod.TGame.EventRelatedObj.Helper_AddAsset(hexLibVarValue, index22, index23, 551);
          }
        }
      }
      bool flag6 = true;
      int num51 = 0;
      while (flag6)
      {
        bool flag7 = false;
        flag6 = false;
        ++num51;
        int counter4 = this.ShqList.Counter;
        for (int index26 = 0; index26 <= counter4; ++index26)
        {
          this.shqHisId = this.ShqList.Id[index26];
          this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
          this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
          this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
          int num52 = 0;
          int num53 = 0;
          SimpleList simpleList1 = new SimpleList();
          SimpleList simpleList2 = new SimpleList();
          int unitCounter6 = this.data.UnitCounter;
          for (int index27 = 0; index27 <= unitCounter6; ++index27)
          {
            if (this.data.UnitObj[index27].HQ == this.shqUnitNr & this.data.UnitObj[index27].PreDef == -1)
            {
              int historical = this.data.UnitObj[index27].Historical;
              if (historical > -1 && this.data.HistoricalUnitObj[historical].TempVar1 == 1 & this.data.UnitObj[index27].IsHQ & this.data.HistoricalUnitObj[historical].Type == 5)
              {
                ++num53;
                simpleList2.Add(index27, 0);
              }
            }
            if (this.ai.game.HandyFunctionsObj.IsUnitInHQChain(index27, this.shqUnitNr) & this.data.UnitObj[index27].PreDef == -1 && !this.data.UnitObj[index27].IsHQ & this.data.UnitObj[index27].PreDef == -1 & this.data.UnitObj[index27].SFCount > -1 && this.ai.game.HandyFunctionsObj.HasUnitAirSF(index27))
            {
              ++num52;
              int num54 = 0;
              if (this.data.UnitObj[index27].HQ > -1)
              {
                int hq = this.data.UnitObj[index27].HQ;
                int historical = this.data.UnitObj[hq].Historical;
                if (this.data.UnitObj[hq].IsHQ & this.data.HistoricalUnitObj[historical].TempVar1 == 1 & this.data.HistoricalUnitObj[historical].Type == 5)
                {
                  num54 = 1;
                  simpleList2.AddWeight(hq, 1);
                }
              }
              if (num54 == 0)
                simpleList1.Add(index27, 1);
            }
          }
          if (num53 * 7 > num52 + 7 + 2 & simpleList2.Counter > -1)
          {
            simpleList2.Sort();
            int index28 = simpleList2.Id[0];
            int unitCounter7 = this.data.UnitCounter;
            for (int tid = 0; tid <= unitCounter7; ++tid)
            {
              if (this.data.UnitObj[tid].HQ == index28 & this.data.UnitObj[index28].HQ > -1)
              {
                this.data.UnitObj[tid].HQ = this.data.UnitObj[index28].HQ;
                simpleList1.Add(tid, 1);
              }
            }
            int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].GetData2(6, 3, 7, this.data.HistoricalUnitObj[this.data.UnitObj[index28].Historical].ID, 0)));
            if (idValue > 0)
            {
              this.data.StringListObj[this.slotChar].SetData(0, idValue, 6, 1);
              this.data.StringListObj[this.slotChar].SetData(0, idValue, 7, 0);
            }
            DataClass data6 = this.data;
            int nr = index28;
            GameClass gameClass = (GameClass) null;
            ref GameClass local6 = ref gameClass;
            data6.RemoveUnit(nr, ref local6);
            simpleList2.RemoveNr(0);
            flag7 = true;
          }
          if (!flag7)
          {
            if (num53 * 7 < num52)
            {
              this.ai.game.EventRelatedObj.Helper_AddAirOHQ(this.data.Turn, this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y);
              this.ai.game.Data.UnitObj[this.ai.game.Data.UnitCounter].HQ = this.shqUnitNr;
              simpleList2.Add(this.ai.game.Data.UnitCounter, 0);
            }
            int counter5 = simpleList2.Counter;
            for (int index29 = 0; index29 <= counter5; ++index29)
            {
              int num55 = simpleList2.Id[index29];
              if (simpleList2.Weight[index29] < 7)
              {
                for (int counter6 = simpleList1.Counter; counter6 >= 0; counter6 += -1)
                {
                  if (simpleList2.Weight[index29] < 7)
                  {
                    this.data.UnitObj[simpleList1.Id[counter6]].HQ = num55;
                    int[] weight = simpleList2.Weight;
                    int[] numArray = weight;
                    index5 = index29;
                    int index30 = index5;
                    int num56 = weight[index5] + 1;
                    numArray[index30] = num56;
                    simpleList1.RemoveNr(counter6);
                  }
                }
              }
            }
          }
          else
            break;
        }
        if (flag7)
          flag6 = true;
        if (num51 > 4)
          flag6 = false;
      }
      if (this.Air_JustFlak | this.Air_Yes)
        this.ai.SE1_USEFLAK = true;
      this.ai.WriteLog(str1);
    }

    public void FireICBMs()
    {
      string str = "9901_AI_FireICBMs";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str);
      this.ai.AddLog("");
      bool flag1 = true;
      int num1 = 0;
      while (flag1 & num1 < 9)
      {
        SimpleList simpleList1 = new SimpleList();
        SimpleList simpleList2 = new SimpleList();
        float[] numArray = new float[this.data.RegimeCounter + 1];
        flag1 = false;
        ++num1;
        int unitCounter = this.data.UnitCounter;
        int tweight;
        for (int index1 = 0; index1 <= unitCounter; ++index1)
        {
          if (this.data.UnitObj[index1].PreDef == -1 & this.data.UnitObj[index1].Regime == this.data.Turn && !this.data.UnitObj[index1].IsHQ)
          {
            bool flag2 = false;
            int num2 = 0;
            int sfCount = this.data.UnitObj[index1].SFCount;
            for (int index2 = 0; index2 <= sfCount; ++index2)
            {
              tweight = this.data.UnitObj[index1].SFList[index2];
              int type = this.data.SFObj[tweight].Type;
              if (this.data.SFTypeObj[type].SFTypeVar[41] >= 190 && this.data.SFTypeObj[type].SFTypeVar[41] <= 199)
              {
                flag2 = true;
                num2 += (int) Math.Round((double) this.data.SFTypeObj[type].SFTypeVar[48] / 10.0 * (double) this.data.SFObj[tweight].Qty);
              }
            }
            if (flag2)
            {
              if (DrawMod.TGame.HandyFunctionsObj.GetLowestAp(index1) >= 30 & DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(index1) >= 50 & this.data.UnitObj[index1].SupplyConsume >= 90)
              {
                if ((double) this.data.UnitObj[index1].items.list.FindWeight(4) >= (double) num2 * 0.9)
                {
                  simpleList1.Add(index1, 100);
                  this.ai.AddLog(this.data.UnitObj[index1].Name + " is qualified as an ICBM thats ready to fire.");
                }
                else
                  this.ai.AddLog(this.data.UnitObj[index1].Name + " is an ICBM but does not have enough Radioactives items.");
              }
              else
                this.ai.AddLog(this.data.UnitObj[index1].Name + " is an ICBM but has AP,RDN or SUPPLY problem.");
            }
          }
        }
        if (simpleList1.Counter > -1)
        {
          int regimeCounter = this.data.RegimeCounter;
          for (int index3 = 1; index3 <= regimeCounter; ++index3)
          {
            if (index3 != this.data.Turn && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index3].id, 1))) == 1 && this.data.RegimeObj[this.data.Turn].RegimeRel[index3] == 0)
            {
              tweight = 0;
              int num3 = 0;
              int counter = this.ShqList.Counter;
              for (int index4 = 0; index4 <= counter; ++index4)
              {
                num3 += this.friendlyMilitaryValue[index4];
                tweight += this.enemyMilitaryValueWeAtt[index4, index3];
              }
              if (num3 > 0)
              {
                float num4 = (float) tweight / (float) num3;
                if (!this.data.RegimeObj[index3].AI)
                  num4 *= 2f;
                numArray[index3] = num4;
                if ((double) numArray[index3] > 8.0)
                  numArray[index3] = 8f;
                this.ai.AddLog(this.data.RegimeObj[index3].Name + " gets mod: " + numArray[index3].ToString());
              }
            }
          }
          AIMatrix aiMatrix = new AIMatrix(ref this.ai);
          int mapWidth1 = this.data.MapObj[0].MapWidth;
          int tdata1;
          int tdata2;
          for (tdata1 = 0; tdata1 <= mapWidth1; ++tdata1)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
              aiMatrix.Value[tdata1, tdata2] = this.data.MapObj[0].HexObj[tdata1, tdata2].Regime != this.data.Turn ? 0 : 1;
          }
          aiMatrix.ExpandAndAddValueForAnyRegime(99);
          int mapWidth2 = this.data.MapObj[0].MapWidth;
          for (tdata1 = 0; tdata1 <= mapWidth2; ++tdata1)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
            {
              int regime = this.data.MapObj[0].HexObj[tdata1, tdata2].Regime;
              if (regime > -1 && (double) numArray[regime] > 0.33)
              {
                int location = this.data.MapObj[0].HexObj[tdata1, tdata2].Location;
                if (location > -1)
                {
                  tweight = 0;
                  int length = this.data.StringListObj[this.slotAssets].Length;
                  for (int index = 0; index <= length; ++index)
                  {
                    if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 3])) == tdata1 && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 4])) == tdata2)
                    {
                      int num5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1])), 2)));
                      tweight += num5 * 100;
                    }
                  }
                  if (tweight > 0)
                  {
                    tweight = (int) Math.Round((double) ((float) tweight * numArray[regime]));
                    tweight = aiMatrix.Value[tdata1, tdata2] <= 50 ? (aiMatrix.Value[tdata1, tdata2] <= 40 ? (aiMatrix.Value[tdata1, tdata2] <= 30 ? (aiMatrix.Value[tdata1, tdata2] <= 20 ? (aiMatrix.Value[tdata1, tdata2] <= 10 ? (aiMatrix.Value[tdata1, tdata2] <= 5 ? 0 : (int) Math.Round((double) tweight / 20.0)) : (int) Math.Round((double) tweight / 10.0)) : (int) Math.Round((double) tweight / 5.0)) : (int) Math.Round((double) tweight / 4.0)) : (int) Math.Round((double) tweight / 7.0)) : (int) Math.Round((double) tweight / 10.0);
                    if (tweight > 0)
                    {
                      tweight *= tweight;
                      simpleList2.Add(location, tweight, tdata1, tdata2);
                      this.ai.AddLog(this.data.LocObj[location].Name + "(" + tdata1.ToString() + "," + tdata2.ToString() + ") gets value: " + tweight.ToString());
                    }
                  }
                }
              }
            }
          }
          int counter1 = simpleList1.Counter;
          for (int index = 0; index <= counter1; ++index)
          {
            int tunr = simpleList1.Id[index];
            tweight = simpleList2.GetRandomSlotbasedOnWeightWithSeed((object) (this.data.Round * this.data.Turn + this.data.GameID));
            if (tweight > -1)
            {
              tdata1 = simpleList2.Data1[tweight];
              tdata2 = simpleList2.Data2[tweight];
              DrawMod.TGame.EditObj.TempUnitList = new UnitList();
              Coordinate Target;
              Target.x = tdata1;
              Target.y = tdata2;
              this.ai.AddLog("---------------------------------------------------------------------");
              this.ai.AddLog(this.data.UnitObj[tunr].Name + " doesICBM STRIKE on " + tdata1.ToString() + "," + tdata2.ToString() + ".");
              this.ai.AddLog("---------------------------------------------------------------------");
              DrawMod.TGame.EditObj.TempUnitList.add(tunr);
              DrawMod.TGame.TempCombat = new CombatClass(DrawMod.TGame);
              DrawMod.TGame.TempCombat.Init(Target, 1, DrawMod.TGame.EditObj.TempUnitList, 11);
              DrawMod.TGame.TempCombat.DoBattle();
              DrawMod.TGame.TempCombat.EndBattle();
              DrawMod.TGame.EditObj.TempUnitList = (UnitList) null;
              if (index < simpleList1.Counter)
              {
                flag1 = true;
                break;
              }
              break;
            }
          }
        }
      }
      this.ai.WriteLog(str);
    }

    public void SetRegimeCombatMatrix()
    {
      string name = "8000_RegimeCombatMatrixLog_Garrison_VP_Log";
      this.ai.ClearLog();
      SimpleList[] simpleListArray = new SimpleList[this.data.RegimeCounter + 1];
      this.combatMatrixAtt = new float[this.data.RegimeCounter + 1, this.data.RegimeCounter + 1];
      this.combatMatrixDef = new float[this.data.RegimeCounter + 1, this.data.RegimeCounter + 1];
      int regimeCounter1 = this.data.RegimeCounter;
      for (int index1 = 1; index1 <= regimeCounter1; ++index1)
      {
        simpleListArray[index1] = new SimpleList();
        int unitCounter = this.data.UnitCounter;
        for (int index2 = 0; index2 <= unitCounter; ++index2)
        {
          if (this.data.UnitObj[index2].PreDef == -1 && this.data.UnitObj[index2].Regime == index1)
          {
            int sfCount = this.data.UnitObj[index2].SFCount;
            for (int index3 = 0; index3 <= sfCount; ++index3)
            {
              int type = this.data.SFObj[this.data.UnitObj[index2].SFList[index3]].Type;
              int qty = this.data.SFObj[this.data.UnitObj[index2].SFList[index3]].Qty;
              simpleListArray[index1].AddWeight(type, qty);
              if (index1 == this.data.Turn)
                this.ai.AddLog("TROOPS " + qty.ToString() + "x " + this.data.SFTypeObj[type].Name);
            }
          }
        }
      }
      int regimeCounter2 = this.data.RegimeCounter;
      int num1;
      for (int index4 = 1; index4 <= regimeCounter2; ++index4)
      {
        int[] numArray1 = new int[this.data.SFTypeCounter + 1];
        int[] numArray2 = new int[this.data.SFTypeCounter + 1];
        int[] numArray3 = new int[this.data.SFTypeCounter + 1];
        int[] numArray4 = new int[this.data.SFTypeCounter + 1];
        int regimeCounter3 = this.data.RegimeCounter;
        for (int index5 = 1; index5 <= regimeCounter3; ++index5)
        {
          this.combatMatrixAtt[index4, index5] = 0.0f;
          this.combatMatrixDef[index4, index5] = 0.0f;
          if (index4 == this.data.Turn)
            this.ai.AddLog("VERSUS " + this.data.RegimeObj[index5].Name);
          if (index4 != index5)
          {
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int counter1 = simpleListArray[index4].Counter;
            for (int index6 = 0; index6 <= counter1; ++index6)
            {
              int counter2 = simpleListArray[index5].Counter;
              for (int index7 = 0; index7 <= counter2; ++index7)
              {
                num1 = 100;
                num1 = (int) Math.Round((double) ((float) num1 * this.ai.combatMatrix[simpleListArray[index4].Id[index6], simpleListArray[index5].Id[index7]]));
                if (num1 < 10)
                  num1 = 10;
                if (num1 > 300)
                  num1 = 300;
                int num6 = simpleListArray[index4].Id[index6] * simpleListArray[index5].Id[index7];
                num2 += num1 * num6;
                num3 += num6;
                int num7 = 100;
                float num8 = this.ai.combatMatrix[simpleListArray[index5].Id[index7], simpleListArray[index4].Id[index6]];
                if ((double) num8 < 0.1)
                  num8 = 0.1f;
                int num9 = (int) Math.Round((double) ((float) num7 * (1f / num8)));
                if (num9 < 10)
                  num9 = 10;
                if (num9 > 300)
                  num9 = 300;
                int num10 = simpleListArray[index4].Id[index6] * simpleListArray[index5].Id[index7];
                num4 += num9 * num10;
                num5 += num10;
                if (index4 == this.data.Turn)
                  this.ai.AddLog(this.data.SFTypeObj[simpleListArray[index4].Id[index6]].Name + " vs " + this.data.SFTypeObj[simpleListArray[index5].Id[index7]].Name + " => ATT MOD = " + num1.ToString() + ", DEF MOD = " + num9.ToString());
              }
            }
            if (num3 < 1)
            {
              num2 = 100;
              num3 = 1;
            }
            if (num5 < 1)
            {
              num4 = 100;
              num5 = 1;
            }
            int num11 = (int) Math.Round((double) num2 / (double) num3);
            int num12 = (int) Math.Round((double) num4 / (double) num5);
            if (num11 < 10)
              num11 = 10;
            if (num12 < 10)
              num12 = 10;
            if (num11 > 300)
              num11 = 300;
            if (num12 > 300)
              num12 = 300;
            this.combatMatrixAtt[index4, index5] = (float) num11 / 100f;
            this.combatMatrixDef[index4, index5] = (float) num12 / 100f;
            if (index4 == this.data.Turn)
              this.ai.AddLog(this.data.RegimeObj[index4].Name + " ==> " + this.data.RegimeObj[index5].Name + " OFF = " + this.combatMatrixAtt[index4, index5].ToString() + ", DEF = " + this.combatMatrixDef[index4, index5].ToString());
          }
        }
      }
      int mapWidth = this.data.MapObj[0].MapWidth;
      for (int index8 = 0; index8 <= mapWidth; ++index8)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index9 = 0; index9 <= mapHeight; ++index9)
          this.data.RegimeObj[this.data.Turn].AIVP[0].Value[index8, index9] = 0;
      }
      int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 12)));
      int length1 = this.data.StringListObj[this.slotZones].Length;
      for (int index = 0; index <= length1; ++index)
      {
        int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
        int num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8]));
        int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 6]));
        if (num14 == this.RegimeId)
        {
          if (id > 0)
          {
            int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1)
            {
              int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "city", 2)));
              num1 = this.data.LocObj[locationById].ID != num13 ? 10 + num15 * 3 : 20 + num15 * 4;
              this.data.RegimeObj[this.data.Turn].AIVP[0].Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y] = num1;
            }
          }
        }
        else if (id > 0)
        {
          int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1)
          {
            num1 = 20 + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "city", 2))) * 3;
            this.data.RegimeObj[this.data.Turn].AIVP[0].Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y] = num1;
          }
        }
      }
      int length2 = this.data.StringListObj[this.slotAssets].Length;
      for (int index10 = 0; index10 <= length2; ++index10)
      {
        int num16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index10, 0]));
        int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index10, 1]));
        int num17 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index10, 3]));
        int num18 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index10, 4]));
        int num19 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
        int num20 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 5)));
        if (idValue >= 551 & idValue <= 559)
        {
          int[,] numArray5 = this.data.RegimeObj[this.data.Turn].AIVP[0].Value;
          int[,] numArray6 = numArray5;
          int index11 = num17;
          int index12 = index11;
          int index13 = num18;
          int index14 = index13;
          int num21 = numArray5[index11, index13] + (10 + (idValue - 550) * 2);
          numArray6[index12, index14] = num21;
        }
        if (num17 > -1 & num18 > -1 & num16 > 0 & num20 > 0)
        {
          num1 = num19 * 3;
          if (num1 < 2)
            num1 = 2;
          if (num1 > 6)
            num1 = 6;
          int[,] numArray7 = this.data.RegimeObj[this.data.Turn].AIVP[0].Value;
          int[,] numArray8 = numArray7;
          int index15 = num17;
          int index16 = index15;
          int index17 = num18;
          int index18 = index17;
          int num22 = numArray7[index15, index17] + num1;
          numArray8[index16, index18] = num22;
        }
      }
      this.ai.WriteLog(name);
    }

    public void SpecialDebugLogs()
    {
      int num1 = -1;
      SimpleList simpleList = new SimpleList();
      int regimeCounter1 = this.data.RegimeCounter;
      for (int tid = 0; tid <= regimeCounter1; ++tid)
      {
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid].id, 1))) == 1 && this.data.RegimeObj[tid].AI)
        {
          if (num1 == -1)
            num1 = tid;
          simpleList.Add(tid, 1);
        }
      }
      if (!this.ai.game.EventRelatedObj.Helper_IsDebug() || this.data.Turn != num1)
        return;
      bool fowOn = this.data.FOWOn;
      bool shrowdOn = this.data.ShrowdOn;
      bool varDebugOn = this.ai.VAR_DEBUG_ON;
      this.ai.VAR_DEBUG_ON = true;
      this.data.FOWOn = false;
      this.data.ShrowdOn = false;
      DrawMod.TGame.ProcessingObj.SetInitialReconAndZOC(this.data.Turn);
      int mapWidth1 = this.data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          this.data.MapObj[0].HexObj[index1, index2].MaxRecon = 9999;
      }
      float num2 = this.data.RuleVar[941];
      this.data.RuleVar[941] = 1f;
      string str1 = (this.data.Round >= 10 ? (this.data.Round >= 100 ? "0" + this.data.Round.ToString() : "00" + this.data.Round.ToString()) : "000" + this.data.Round.ToString()) + "_SpecialDebugLog";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      int[,] numArray = new int[this.data.MapObj[0].MapWidth + 1, this.data.MapObj[0].MapHeight + 1];
      int mapWidth2 = this.data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth2; ++index3)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
          numArray[index3, index4] = this.data.MapObj[0].HexObj[index3, index4].Regime;
      }
      if (this.data.Round % 5 == 0 & this.data.Turn == num1)
      {
        bool[] flagArray = new bool[this.data.RegimeCounter + 1];
        int regimeCounter2 = this.data.RegimeCounter;
        for (int index = 0; index <= regimeCounter2; ++index)
        {
          flagArray[index] = this.data.RegimeObj[index].AI;
          this.data.RegimeObj[index].AI = false;
        }
        string str2 = DrawMod.TGame.AppPath_SAVEGAMES + str1 + ".se1";
        int regimeCounter3 = this.data.RegimeCounter;
        for (int index = 0; index <= regimeCounter3; ++index)
          this.data.RegimeObj[index].AI = flagArray[index];
      }
      this.ai.AddLog("--------------------------------- REGIME LEVEL STATS ----------------------------------------------------------");
      int counter1 = simpleList.Counter;
      int index5;
      for (int index6 = 0; index6 <= counter1; ++index6)
      {
        int index7 = simpleList.Id[index6];
        int id = this.data.RegimeObj[index7].id;
        this.ai.AddLog(this.data.RegimeObj[index7].Name + " (slot " + index7.ToString() + ") ---------------------------");
        index5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, id, 1, "victoryScore", 2)));
        this.ai.AddLog("Victory Score = " + index5.ToString());
        index5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, id, 1, "credits", 2)));
        this.ai.AddLog("Credits = " + index5.ToString());
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        int num7 = 0;
        int length1 = this.data.StringListObj[this.slotZones].Length;
        for (int index8 = 1; index8 <= length1; ++index8)
        {
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index8, 8])) == id)
          {
            int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index8, 0]));
            num3 += (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "pop", 2)));
            num4 += (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "worker", 2)));
            num5 += (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "freeFolk", 2)));
          }
        }
        int unitCounter = this.data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.data.UnitObj[unr].PreDef == -1 & this.data.UnitObj[unr].Regime == index7 & this.data.UnitObj[unr].Historical > -1)
          {
            if (this.data.HistoricalUnitObj[this.data.UnitObj[unr].Historical].Type == 8)
              num6 += this.data.UnitObj[unr].items.list.FindWeight(9);
            num7 += DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
          }
        }
        this.ai.AddLog("Pop = " + num3.ToString() + ", Worker = " + num4.ToString() + ", FreeFolk= " + num5.ToString());
        this.ai.AddLog("Soldiers = " + num7.ToString() + ", Recruits = " + num6.ToString());
        this.ai.AddLog("Total Manpower = " + (num3 + num4 + num5 + num7).ToString());
        int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 292, 0, 0));
        int num8 = 0;
        int length2 = DrawMod.TGame.Data.StringListObj[stringListById].Length;
        for (int index9 = 0; index9 <= length2; ++index9)
        {
          if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index9, 1])) == index7 && Operators.CompareString(DrawMod.TGame.Data.StringListObj[stringListById].Data[index9, 0], "Key", false) == 0 && Operators.CompareString(DrawMod.TGame.Data.StringListObj[stringListById].Data[index9, 2], "Casualties", false) == 0)
          {
            int num9 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index9, 3]));
            int num10 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index9, 4]));
            num8 += num10;
          }
        }
        num8 = (int) Math.Round((double) num8 / 100.0);
        this.ai.AddLog("Total Casualties = " + num8.ToString());
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- REGIME LEVEL STATS ----------------------------------------------------------");
      int counter2 = simpleList.Counter;
      int num11;
      for (int index10 = 0; index10 <= counter2; ++index10)
      {
        int index11 = simpleList.Id[index10];
        int id = this.data.RegimeObj[index11].id;
        this.ai.AddLog(this.data.RegimeObj[index11].Name + " (slot " + index11.ToString() + ") ---------------------------");
        int regimeCounter4 = this.data.RegimeCounter;
        for (int index12 = 1; index12 <= regimeCounter4; ++index12)
        {
          if (index11 != index12)
          {
            index5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, this.data.RegimeObj[index12].id, 2, "aiIntention", 3)));
            int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, this.data.RegimeObj[index12].id, 2, "relation", 3)));
            int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, this.data.RegimeObj[index12].id, 2, "dipRel", 3)));
            num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, this.data.RegimeObj[index12].id, 2, "dipPact", 3)));
            this.ai.AddLog("Relation with " + this.data.RegimeObj[index12].Name + " = " + num12.ToString() + ". Intention = " + index5.ToString() + ". dipRel = " + num13.ToString() + ", dipPact = " + num11.ToString() + ", Peace = " + this.data.RegimeObj[index11].RegimeRel[index12].ToString());
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- ZONE LEVEL STATS ----------------------------------------------------------");
      int counter3 = simpleList.Counter;
      int idValue1;
      int num14;
      for (int index13 = 0; index13 <= counter3; ++index13)
      {
        int index14 = simpleList.Id[index13];
        int id1 = this.data.RegimeObj[index14].id;
        bool flag = false;
        int length = this.data.StringListObj[this.slotZones].Length;
        for (int index15 = 0; index15 <= length; ++index15)
        {
          int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index15, 8]));
          int id2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index15, 6]));
          if (num15 == id1)
          {
            if (!flag)
            {
              this.ai.AddLog(this.data.RegimeObj[index14].Name + " ---------------------------");
              flag = true;
            }
            string str3 = "No loc";
            if (id2 > 0)
            {
              int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id2);
              if (locationById > -1)
              {
                index5 = this.data.LocObj[locationById].HQ;
                str3 = index5 <= -1 ? "No Hq" : this.data.UnitObj[index5].Name;
              }
              else
                str3 = "No loc";
            }
            idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index15, 0]));
            string str4 = this.data.StringListObj[this.slotZones].Data[index15, 7];
            index5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "pop", 2)));
            int num16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "worker", 2)));
            num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "popHapiness", 2)));
            num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "workerHapiness", 2)));
            int num17 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "popHunger", 2)));
            int num18 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "workerHunger", 2)));
            int num19 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "qol", 2)));
            int num20 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "privateCreditsGrowth", 2)));
            int num21 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "city", 2)));
            this.ai.AddLog("Zone #" + idValue1.ToString() + ", " + str4 + ". SHQ = " + str3 + ". City = " + num21.ToString() + ". Pop = " + index5.ToString() + ". Worker = " + num16.ToString() + ".  PopHapiness = " + num14.ToString() + ". WorkerHapiness = " + num11.ToString() + ".  PopHunger = " + num17.ToString() + ". WorkerHunger = " + num18.ToString() + ". Qol = " + num19.ToString() + ". PrivateCreditsGrowth = " + num20.ToString());
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- ZONE ASSETS ----------------------------------------------------------");
      int counter4 = simpleList.Counter;
      for (int index16 = 0; index16 <= counter4; ++index16)
      {
        int index17 = simpleList.Id[index16];
        int id = this.data.RegimeObj[index17].id;
        bool flag = false;
        int length3 = this.data.StringListObj[this.slotZones].Length;
        for (int index18 = 0; index18 <= length3; ++index18)
        {
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index18, 8])) == id)
          {
            if (!flag)
            {
              this.ai.AddLog(this.data.RegimeObj[index17].Name + " ---------------------------");
              flag = true;
            }
            idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index18, 0]));
            string str5 = this.data.StringListObj[this.slotZones].Data[index18, 7];
            this.ai.AddLog("-------- Zone #" + idValue1.ToString() + ", " + str5 + " -------");
            int length4 = this.data.StringListObj[this.slotAssets].Length;
            for (int index19 = 0; index19 <= length4; ++index19)
            {
              if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index19, 0])) == idValue1)
              {
                int idValue2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index19, 1]));
                int num22 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 2)));
                int num23 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index19, 5]));
                int num24 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index19, 6]));
                int num25 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index19, 11]));
                int num26 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index19, 7]));
                string str6 = this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 1) + " [lvl" + num22.ToString() + "] ";
                if (num26 > 0)
                  str6 = "CONSTR ROUNDS " + num26.ToString() + " : " + str6;
                if (num23 == -1)
                  str6 += " MOTBALLED";
                if (num23 == -2)
                  str6 += " CLOSED";
                string s = str6 + ", last PROD% = " + num25.ToString() + "%";
                if (num24 > 0)
                  s = s + ", dam: " + num24.ToString();
                this.ai.AddLog(s);
              }
            }
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- ZONE KEYS : FREEFOLK ----------------------------------------------------------");
      int length5 = this.data.StringListObj[this.slotZones].Length;
      for (int index20 = 0; index20 <= length5; ++index20)
      {
        int num27 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index20, 8]));
        idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index20, 0]));
        string str7 = this.data.StringListObj[this.slotZones].Data[index20, 7];
        index5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue1, 1, "freeFolk", 2)));
        this.ai.AddLog("Zone #" + idValue1.ToString() + ", " + str7 + ". FreeFolk = " + index5.ToString());
      }
      this.ai.AddLog("");
      int num28 = 1;
      do
      {
        if (num28 == 1)
          this.ai.AddLog("--------------------------------- ZONE TRADERS ----------------------------------------------------------");
        if (num28 == 2)
          this.ai.AddLog("--------------------------------- OTHER TRADERS ----------------------------------------------------------");
        int counter5 = simpleList.Counter;
        for (int index21 = 0; index21 <= counter5; ++index21)
        {
          int index22 = simpleList.Id[index21];
          int id = this.data.RegimeObj[index22].id;
          bool flag = false;
          int length6 = this.data.StringListObj[this.slotZones].Length;
          for (int index23 = 0; index23 <= length6; ++index23)
          {
            int num29 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index23, 8]));
            if (num28 == 1 & num29 == id | num28 == 2 & num29 != id)
            {
              if (!flag)
              {
                this.ai.AddLog(this.data.RegimeObj[index22].Name + " ---------------------------");
                flag = true;
              }
              idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index23, 0]));
              string str8 = this.data.StringListObj[this.slotZones].Data[index23, 7];
              index5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderZones].GetData(0, idValue1, 1)));
              int num30 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraders].GetData(0, index5, 1)));
              num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 7, 2)));
              num14 += (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 7, 3)));
              num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 2, 2)));
              num11 += (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 2, 3)));
              int num31 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 1, 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 1, 3)));
              int num32 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 5, 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTraderItems].GetData2(0, index5, 1, 5, 3)));
              this.ai.AddLog("Zone #" + idValue1.ToString() + ", " + str8 + ". TraderID = " + index5.ToString() + ". Credits= " + num30.ToString() + ". Food = " + num14.ToString() + ".  Metal = " + num11.ToString() + ".Oil = " + num31.ToString() + ".  Water = " + num32.ToString());
            }
          }
        }
        this.ai.AddLog("");
        ++num28;
      }
      while (num28 <= 2);
      this.ai.AddLog("--------------------------------- MODEL STATS ----------------------------------------------------------");
      int counter6 = simpleList.Counter;
      for (int index24 = 0; index24 <= counter6; ++index24)
      {
        int regime = simpleList.Id[index24];
        int id3 = this.data.RegimeObj[regime].id;
        bool flag = false;
        int length7 = this.data.StringListObj[this.slotRegimeModels].Length;
        for (int index25 = 0; index25 <= length7; ++index25)
        {
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 2])) == id3)
          {
            if (!flag)
            {
              this.ai.AddLog(this.data.RegimeObj[regime].Name + " ---------------------------");
              flag = true;
            }
            idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 0]));
            int idValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 1]));
            int num33 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 4]));
            int num34 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 7]));
            int num35 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 8]));
            string str9 = this.data.StringListObj[this.slotRegimeModels].Data[index25, 3];
            string data = this.data.StringListObj[this.slotModelTypes].GetData(0, idValue3, 1);
            int id4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 5]));
            int sfTypeById = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id4);
            int num36 = DrawMod.TGame.EventRelatedObj.Checksftypeinarea(-1, -1, sfTypeById, regime);
            this.ai.AddLog("Model #" + idValue1.ToString() + ", " + str9 + " (" + data + "). Version = " + num33.ToString() + ". Res = " + num34.ToString() + "/" + num35.ToString() + ".  Qty = " + num36.ToString());
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- OOB STATS ----------------------------------------------------------");
      int counter7 = simpleList.Counter;
      for (int index26 = 0; index26 <= counter7; ++index26)
      {
        int index27 = simpleList.Id[index26];
        int id = this.data.RegimeObj[index27].id;
        bool flag = false;
        int length8 = this.data.StringListObj[this.slotRegimeOobs].Length;
        for (int index28 = 0; index28 <= length8; ++index28)
        {
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index28, 1])) == id)
          {
            if (!flag)
            {
              this.ai.AddLog(this.data.RegimeObj[index27].Name + " ---------------------------");
              flag = true;
            }
            idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index28, 0]));
            int num37 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index28, 5]));
            int num38 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index28, 6]));
            string data = this.data.StringListObj[this.slotOobTypes].GetData(0, idValue1, 1);
            this.ai.AddLog("OobType #" + idValue1.ToString() + ", " + data + ". Res = " + num37.ToString() + "/" + num38.ToString());
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- TECH STATS ----------------------------------------------------------");
      int counter8 = simpleList.Counter;
      for (int index29 = 0; index29 <= counter8; ++index29)
      {
        int index30 = simpleList.Id[index29];
        int id = this.data.RegimeObj[index30].id;
        bool flag = false;
        int length9 = this.data.StringListObj[this.slotRegimeTech].Length;
        for (int index31 = 0; index31 <= length9; ++index31)
        {
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].Data[index31, 1])) == id)
          {
            if (!flag)
            {
              this.ai.AddLog(this.data.RegimeObj[index30].Name + " ---------------------------");
              flag = true;
            }
            idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].Data[index31, 0]));
            int num39 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].Data[index31, 2]));
            if (num39 > 0)
            {
              string data = this.data.StringListObj[this.slotTechType].GetData(0, idValue1, 1);
              this.ai.AddLog("Tech #" + idValue1.ToString() + ", " + data + ". Level = " + num39.ToString());
            }
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("--------------------------------- UNITS ----------------------------------------------------------");
      int counter9 = simpleList.Counter;
      int id5;
      int num40;
      for (int index32 = 0; index32 <= counter9; ++index32)
      {
        int index33 = simpleList.Id[index32];
        id5 = this.data.RegimeObj[index33].id;
        bool flag = false;
        int unitCounter1 = this.data.UnitCounter;
        for (int unr1 = 0; unr1 <= unitCounter1; ++unr1)
        {
          if (this.data.UnitObj[unr1].PreDef == -1 & this.data.UnitObj[unr1].Regime == index33 & this.data.UnitObj[unr1].Historical > -1)
          {
            index5 = this.data.UnitObj[unr1].Historical;
            if (this.data.HistoricalUnitObj[index5].Type == 8)
            {
              if (!flag)
              {
                this.ai.AddLog(this.data.RegimeObj[index33].Name + " ---------------------------");
                flag = true;
              }
              DC2AIClass ai1 = this.ai;
              string[] strArray1 = new string[6]
              {
                "SHQ: ",
                this.data.UnitObj[unr1].Name,
                ". Rdn = ",
                null,
                null,
                null
              };
              string[] strArray2 = strArray1;
              int num41 = DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(unr1);
              string str10 = num41.ToString();
              strArray2[3] = str10;
              strArray1[4] = ". Power = ";
              strArray1[5] = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr1).ToString();
              string s1 = string.Concat(strArray1);
              ai1.AddLog(s1);
              int unitCounter2 = this.data.UnitCounter;
              for (int unr2 = 0; unr2 <= unitCounter2; ++unr2)
              {
                if (this.data.UnitObj[unr2].PreDef == -1 & this.data.UnitObj[unr2].Regime == index33 & this.data.UnitObj[unr2].Historical > -1)
                {
                  index5 = this.data.UnitObj[unr2].Historical;
                  int idValue4 = this.data.HistoricalUnitObj[index5].GiveHisVarValue(1);
                  num40 = this.data.HistoricalUnitObj[index5].GiveHisVarValue(81);
                  string data1 = this.data.StringListObj[this.slotOobTypes].GetData(0, idValue4, 1);
                  if (this.data.UnitObj[unr2].HQ == unr1)
                  {
                    if (this.data.UnitObj[unr2].IsHQ)
                    {
                      DC2AIClass ai2 = this.ai;
                      string[] strArray3 = new string[8]
                      {
                        ".... HQ: ",
                        this.data.UnitObj[unr2].Name,
                        ". OobType = ",
                        data1,
                        ". Rdn = ",
                        DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(unr2).ToString(),
                        ". Power = ",
                        null
                      };
                      string[] strArray4 = strArray3;
                      num41 = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr2);
                      string str11 = num41.ToString();
                      strArray4[7] = str11;
                      string s2 = string.Concat(strArray3);
                      ai2.AddLog(s2);
                      int unitCounter3 = this.data.UnitCounter;
                      for (int unr3 = 0; unr3 <= unitCounter3; ++unr3)
                      {
                        if (this.data.UnitObj[unr3].PreDef == -1 & this.data.UnitObj[unr3].Regime == index33 & this.data.UnitObj[unr3].Historical > -1)
                        {
                          index5 = this.data.UnitObj[unr3].Historical;
                          string data2 = this.data.StringListObj[this.slotOobTypes].GetData(0, this.data.HistoricalUnitObj[index5].GiveHisVarValue(1), 1);
                          if (this.data.UnitObj[unr3].HQ == unr2)
                          {
                            DC2AIClass ai3 = this.ai;
                            string[] strArray5 = new string[10]
                            {
                              "............ Unit: ",
                              this.data.UnitObj[unr3].Name,
                              ". OobType = ",
                              data2,
                              ". Rdn = ",
                              DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(unr3).ToString(),
                              ". Power = ",
                              null,
                              null,
                              null
                            };
                            string[] strArray6 = strArray5;
                            num41 = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr3);
                            string str12 = num41.ToString();
                            strArray6[7] = str12;
                            strArray5[8] = ", hunger = ";
                            strArray5[9] = num40.ToString();
                            string s3 = string.Concat(strArray5);
                            ai3.AddLog(s3);
                          }
                        }
                      }
                    }
                    else
                    {
                      DC2AIClass ai4 = this.ai;
                      string[] strArray7 = new string[10]
                      {
                        ".... Unit: ",
                        this.data.UnitObj[unr2].Name,
                        ". OobType = ",
                        data1,
                        ". Rdn = ",
                        DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(unr2).ToString(),
                        ". Power = ",
                        null,
                        null,
                        null
                      };
                      string[] strArray8 = strArray7;
                      num41 = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unr2);
                      string str13 = num41.ToString();
                      strArray8[7] = str13;
                      strArray7[8] = ", hunger = ";
                      strArray7[9] = num40.ToString();
                      string s4 = string.Concat(strArray7);
                      ai4.AddLog(s4);
                    }
                  }
                }
              }
            }
          }
        }
      }
      this.ai.AddLog("");
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 273, 0, 0));
      this.ai.AddLog("--------------------------------- SHQ ITEMS ----------------------------------------------------------");
      int counter10 = simpleList.Counter;
      for (int index34 = 0; index34 <= counter10; ++index34)
      {
        int index35 = simpleList.Id[index34];
        id5 = this.data.RegimeObj[index35].id;
        bool flag = false;
        int unitCounter = this.data.UnitCounter;
        for (int index36 = 0; index36 <= unitCounter; ++index36)
        {
          if (this.data.UnitObj[index36].PreDef == -1 & this.data.UnitObj[index36].Regime == index35 & this.data.UnitObj[index36].Historical > -1)
          {
            index5 = this.data.UnitObj[index36].Historical;
            if (this.data.HistoricalUnitObj[index5].Type == 8)
            {
              if (!flag)
              {
                this.ai.AddLog(this.data.RegimeObj[index35].Name + " ---------------------------");
                flag = true;
              }
              this.ai.AddLog("SHQ: " + this.data.UnitObj[index36].Name);
              int counter11 = this.data.UnitObj[index36].items.list.Counter;
              for (int index37 = 0; index37 <= counter11; ++index37)
              {
                index5 = this.data.UnitObj[index36].items.list.Id[index37];
                int num42 = this.data.UnitObj[index36].items.list.Weight[index37];
                if (num42 > 0)
                {
                  string data = this.data.StringListObj[this.slotItemType].GetData(0, index5, 1);
                  string str14 = "";
                  if (this.data.Round > 1 & index35 == num1)
                  {
                    num40 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData2(0, this.data.HistoricalUnitObj[this.data.UnitObj[index36].Historical].ID, 2, index5, 3)));
                    num40 = num42 - num40;
                    str14 = " (" + (num40 <= 0 ? num40.ToString() : "+" + num40.ToString()) + ")";
                  }
                  this.ai.AddLog(num42.ToString() + " " + data + str14);
                }
              }
            }
          }
        }
      }
      this.ai.AddLog("");
      this.ai.WriteLog(str1);
      this.data.RuleVar[941] = num2;
      this.data.FOWOn = fowOn;
      this.data.ShrowdOn = shrowdOn;
      this.ai.VAR_DEBUG_ON = varDebugOn;
    }

    public void LeaderStuff()
    {
      int id1 = this.data.RegimeObj[this.data.Turn].id;
      int turn = this.data.Turn;
      string dataLib = "SE_Data";
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, id1, 2)));
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotCulture].GetData(0, num1, 1)));
      string str1 = "8000_Leader_And_UnitFeatStuff";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("");
      this.ai.AddLog("CURRENT FACTIONS");
      this.ai.AddLog("");
      int length1 = this.data.StringListObj[this.slotFactions].Length;
      for (int index = 0; index <= length1; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotFactions].Data[index, 3])) == id1)
        {
          string str2 = this.data.StringListObj[this.slotFactions].Data[index, 4];
          string str3 = this.data.StringListObj[this.slotFactions].Data[index, 10];
          int charId = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotFactions].Data[index, 6]));
          int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotFactions].Data[index, 13]));
          string str4 = "none";
          if (charId > 0)
            str4 = DrawMod.TGame.EventRelatedObj.Helper_GetCharacterName(charId);
          int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotFactions].Data[index, 12]));
          this.ai.AddLog(str2 + " (" + str3 + "), Leader: " + str4 + ", Ai-id: " + num4.ToString() + ", supportPts: " + num3.ToString());
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("CURRENT LEADERS");
      this.ai.AddLog("");
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      SimpleList simpleList3 = new SimpleList();
      int length2 = this.data.StringListObj[this.slotChar].Length;
      for (int index = 0; index <= length2; ++index)
      {
        int num5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 5]));
        int num6 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 26]));
        if (num5 == id1 | num6 == id1)
        {
          int num7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 25]));
          int num8 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 27]));
          int num9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 6]));
          int num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 0]));
          int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 13]));
          int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 16]));
          int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotChar].Data[index, 20]));
          string str5 = DrawMod.TGame.EventRelatedObj.Helper_GetCharacterName(num10);
          string characterJobTitle = DrawMod.TGame.EventRelatedObj.Helper_GetCharacterJobTitle(num10, true);
          string str6 = ((int) Math.Round((double) Math.Abs(this.data.Round - num11) / 6.0)).ToString();
          string str7 = "-";
          if (idValue > 0)
            str7 = this.data.StringListObj[this.slotFactions].GetData(0, idValue, 10);
          if (num6 > 0)
            str5 = "[LEFT REG AT R#" + num7.ToString() + "] " + str5;
          if (num8 > 0)
            str5 = "[3RD PARTY] " + str5;
          string str8 = "";
          int suitabilityRating1 = DrawMod.TGame.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num10, 10, -1);
          string str9 = str8 + ", GovSuit: " + suitabilityRating1.ToString();
          int suitabilityRating2 = DrawMod.TGame.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num10, 4, -1);
          string str10 = str9 + ",SHQSuit: " + suitabilityRating2.ToString();
          int suitabilityRating3 = DrawMod.TGame.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num10, 3, -1);
          string str11 = str10 + ", OHQSuit: " + suitabilityRating3.ToString();
          if (num9 == 1)
          {
            if (suitabilityRating1 > 10)
              simpleList1.Add(num10, suitabilityRating1);
            if (suitabilityRating2 > 20)
              simpleList2.Add(num10, suitabilityRating2);
            if (suitabilityRating3 > 10)
              simpleList3.Add(num10, suitabilityRating3);
          }
          this.ai.AddLog(num10.ToString() + "] " + str5 + " : " + characterJobTitle + " , age: " + str6 + ", fac: " + str7 + ", rel: " + num12.ToString() + str11);
        }
      }
      simpleList1.ReverseSortHighSpeed();
      simpleList2.ReverseSortHighSpeed();
      simpleList3.ReverseSortHighSpeed();
      this.ai.AddLog("");
      this.ai.AddLog("ASSIGN LEADERS TO POSTS");
      this.ai.AddLog("");
      int length3 = this.data.StringListObj[this.slotZones].Length;
      for (int index = 1; index <= length3; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8])) == id1)
        {
          int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
          if (DrawMod.TGame.EventRelatedObj.Helper_GetCharacterId(id1, 10, num13, -1) < 1)
          {
            string str12 = this.data.StringListObj[this.slotZones].Data[index, 7];
            this.ai.AddLog("ZONE #" + num13.ToString() + ", " + str12 + " does not have a Governour assigned.");
            int idValue = simpleList1.Counter <= -1 ? DrawMod.TGame.EventRelatedObj.Helper_RollCharacter(num1, turn, dataLib, finalAge: DrawMod.RandyNumber.Next(30, 60), finalCapCategory: DrawMod.RandyNumber.Next(2, 4), finalCareerId: 12) : simpleList1.Id[0];
            this.data.StringListObj[this.slotChar].SetData(0, idValue, 6, 10);
            this.data.StringListObj[this.slotChar].SetData(0, idValue, 7, num13);
            this.data.StringListObj[this.slotChar].SetData(0, idValue, 34, 30);
            string s4 = "Then became governor of the " + this.data.RegimeObj[turn].Name + ".";
            this.data.StringListObj[this.slotPersFile].AddRowWithData(idValue.ToString(), this.data.Round.ToString(), 1.ToString(), 1.ToString(), s4);
            this.ai.AddLog(" => CHARID #" + idValue.ToString() + " has been assigned..");
          }
        }
      }
      int unitCounter1 = this.data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.data.UnitObj[index].PreDef == -1 & this.data.UnitObj[index].Regime == turn & this.data.UnitObj[index].Historical > -1 && this.data.UnitObj[index].IsHQ)
        {
          int historical = this.data.UnitObj[index].Historical;
          int id2 = this.data.HistoricalUnitObj[historical].ID;
          if (this.data.HistoricalUnitObj[historical].Type >= 8)
          {
            if (DrawMod.TGame.EventRelatedObj.Helper_GetCharacterId(id1, 4, id2, -1) == -1)
            {
              string name = this.data.UnitObj[index].Name;
              this.ai.AddLog("Strategic HQ HIS_ID#" + id2.ToString() + ", " + name + " does not have a Commander assigned.");
              int idValue = simpleList2.Counter <= -1 ? DrawMod.TGame.EventRelatedObj.Helper_RollCharacter(num1, turn, dataLib, finalAge: DrawMod.RandyNumber.Next(40, 60), finalCapCategory: DrawMod.RandyNumber.Next(3, 4), finalCareerId: 13) : simpleList2.Id[0];
              this.data.StringListObj[this.slotChar].SetData(0, idValue, 6, 4);
              this.data.StringListObj[this.slotChar].SetData(0, idValue, 7, id2);
              this.data.StringListObj[this.slotChar].SetData(0, idValue, 34, 30);
              this.data.HistoricalUnitObj[historical].SetHisVarValue(61, idValue);
              string s4 = "Became a strategic HQ commander for " + this.data.RegimeObj[turn].Name + ".";
              this.data.StringListObj[this.slotPersFile].AddRowWithData(idValue.ToString(), this.data.Round.ToString(), 1.ToString(), 1.ToString(), s4);
              this.ai.AddLog(" => CHARID #" + idValue.ToString() + " has been assigned..");
            }
          }
          else if (DrawMod.TGame.EventRelatedObj.Helper_GetCharacterId(id1, 3, id2, -1) == -1)
          {
            string name = this.data.UnitObj[index].Name;
            this.ai.AddLog("Operational HQ HIS_ID#" + id2.ToString() + ", " + name + " does not have a Commander assigned.");
            int idValue = simpleList3.Counter <= -1 ? DrawMod.TGame.EventRelatedObj.Helper_RollCharacter(num1, turn, dataLib, finalAge: DrawMod.RandyNumber.Next(25, 50), finalCapCategory: DrawMod.RandyNumber.Next(2, 4), finalCareerId: 5) : simpleList3.Id[0];
            this.data.StringListObj[this.slotChar].SetData(0, idValue, 6, 3);
            this.data.StringListObj[this.slotChar].SetData(0, idValue, 7, id2);
            this.data.StringListObj[this.slotChar].SetData(0, idValue, 34, 30);
            this.data.HistoricalUnitObj[historical].SetHisVarValue(61, idValue);
            string s4 = "Became a military commander for " + this.data.RegimeObj[turn].Name + ".";
            this.data.StringListObj[this.slotPersFile].AddRowWithData(idValue.ToString(), this.data.Round.ToString(), 1.ToString(), 1.ToString(), s4);
            this.ai.AddLog(" => CHARID #" + idValue.ToString() + " has been assigned..");
          }
        }
      }
      int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 402, 0, 0));
      int unitCounter2 = this.data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter2; ++index1)
      {
        if (this.data.UnitObj[index1].PreDef == -1 & this.data.UnitObj[index1].Regime == this.data.Turn)
        {
          if (index1 == 53)
            index1 = index1;
          if (!this.data.UnitObj[index1].IsHQ)
          {
            int historical = this.data.UnitObj[index1].Historical;
            int num14 = 0;
            int length4 = this.data.StringListObj[stringListById].Length;
            for (int index2 = 0; index2 <= length4; ++index2)
            {
              int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById].Data[index2, 0]));
              int num16 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(num15 + 100);
              num14 += num16;
            }
            int num17 = 0;
            int sfCount = this.data.UnitObj[index1].SFCount;
            for (int index3 = 0; index3 <= sfCount; ++index3)
            {
              int sf = this.data.UnitObj[index1].SFList[index3];
              num17 += this.data.SFObj[sf].Qty;
            }
            if (historical > -1)
            {
              int num18 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(139);
              if (num18 > 0 & this.data.Round > 50 & DrawMod.RandyNumber.Next(0, 1000) < 15)
              {
                int num19 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(140);
                if ((num19 + 1) * 10 <= num17)
                {
                  int num20 = num19 + 1;
                  this.data.HistoricalUnitObj[historical].SetHisVarValue(140, num20);
                  int num21 = num18 - 1;
                  this.data.HistoricalUnitObj[historical].SetHisVarValue(139, num21);
                }
              }
              int num22 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(138);
              if (num22 > 0 & this.data.Round > 30 & DrawMod.RandyNumber.Next(0, 1000) < 20)
              {
                int num23 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(139);
                if ((num23 + 1) * 10 <= num17)
                {
                  int num24 = num23 + 1;
                  this.data.HistoricalUnitObj[historical].SetHisVarValue(139, num24);
                  int num25 = num22 - 1;
                  this.data.HistoricalUnitObj[historical].SetHisVarValue(138, num25);
                }
              }
              if (num17 > num14 && this.data.Round > 0 & DrawMod.RandyNumber.Next(0, 1000) < 25)
              {
                int num26 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(138);
                if ((num26 + 1) * 10 <= num17)
                {
                  int num27 = num26 + 1;
                  this.data.HistoricalUnitObj[historical].SetHisVarValue(138, num27);
                }
              }
            }
          }
        }
      }
      this.ai.AddLog("");
      this.ai.WriteLog(str1);
    }

    public void SetHQs()
    {
      string str = "8601_AI_SetHQs";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str);
      this.ai.AddLog("");
      int unitCounter1 = this.data.UnitCounter;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].Historical > -1 && this.data.UnitObj[unr].PreDef == -1 & !this.data.UnitObj[unr].IsHQ && DrawMod.TGame.HandyFunctionsObj.HasUnitAirSF(unr))
        {
          int hq1 = this.data.UnitObj[unr].HQ;
          if (hq1 > -1)
          {
            int historical = this.data.UnitObj[hq1].Historical;
            if (historical > -1 && this.ai.game.Data.HistoricalUnitObj[historical].Type < 8 & this.ai.game.Data.HistoricalUnitObj[historical].TempVar1 < 1)
            {
              int hq2 = this.data.UnitObj[hq1].HQ;
              if (hq2 > -1)
                this.data.UnitObj[unr].HQ = hq2;
            }
          }
        }
      }
      SimpleList simpleList1 = new SimpleList();
      int unitCounter2 = this.data.UnitCounter;
      for (int tid = 0; tid <= unitCounter2; ++tid)
      {
        if (this.data.UnitObj[tid].Regime == this.data.Turn & this.data.UnitObj[tid].Historical > -1 && this.data.UnitObj[tid].PreDef == -1 && this.data.UnitObj[tid].IsHQ)
        {
          int historical = this.data.UnitObj[tid].Historical;
          if (historical > -1 && this.data.HistoricalUnitObj[historical].Type < 7)
          {
            int idValue = this.data.HistoricalUnitObj[historical].GiveHisVarValue(1);
            if (idValue > -1 && this.data.HistoricalUnitObj[historical].Type != 8)
            {
              int tdata1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, idValue, 28)));
              int nr = simpleList1.FindNr(tid);
              if (nr == -1)
                simpleList1.Add(tid, 0, tdata1);
              else
                simpleList1.Data1[nr] = tdata1;
            }
          }
        }
      }
      int unitCounter3 = this.data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter3; ++index1)
      {
        if (this.data.UnitObj[index1].Regime == this.data.Turn & this.data.UnitObj[index1].Historical > -1 && this.data.UnitObj[index1].PreDef == -1 && !this.data.UnitObj[index1].IsHQ)
        {
          int historical = this.data.UnitObj[index1].Historical;
          if (historical > -1 & this.data.UnitObj[index1].HQ > -1)
          {
            int idValue = this.data.HistoricalUnitObj[historical].GiveHisVarValue(1);
            if (idValue > 0 && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, idValue, 4))) == 1)
            {
              int nr = simpleList1.FindNr(this.data.UnitObj[index1].HQ);
              if (nr != -1)
              {
                int[] weight = simpleList1.Weight;
                int[] numArray = weight;
                int index2 = nr;
                int index3 = index2;
                int num = weight[index2] + 1;
                numArray[index3] = num;
              }
            }
          }
        }
      }
      for (int counter = simpleList1.Counter; counter >= 0; counter += -1)
      {
        int num = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, this.data.HistoricalUnitObj[this.data.UnitObj[simpleList1.Id[counter]].Historical].GiveHisVarValue(1), 2)));
        simpleList1.Data2[counter] = num;
      }
      int counter1 = simpleList1.Counter;
      for (int index4 = 0; index4 <= counter1; ++index4)
      {
        int index5 = simpleList1.Id[index4];
        int num1 = simpleList1.Data2[index4];
        SimpleList simpleList2 = new SimpleList();
        SimpleList simpleList3 = new SimpleList();
        int unitCounter4 = this.data.UnitCounter;
        for (int index6 = 0; index6 <= unitCounter4; ++index6)
        {
          if (this.data.UnitObj[index6].Regime == this.data.Turn & this.data.UnitObj[index6].PreDef == -1 & !this.data.UnitObj[index6].IsHQ)
          {
            int hq = this.data.UnitObj[index6].HQ;
            if (hq > -1)
            {
              int historical1 = this.data.UnitObj[hq].Historical;
              int historical2 = this.data.UnitObj[index6].Historical;
              if (historical2 > -1)
              {
                bool flag = true;
                if (this.data.HistoricalUnitObj[historical2].GiveHisVarValue(11) > 0)
                  flag = false;
                if (DrawMod.TGame.HandyFunctionsObj.HasUnitSFTypeVar(index6, 37, 6, 6) & DrawMod.TGame.HandyFunctionsObj.HasUnitSFTypeVar(index6, 44, 12))
                  flag = false;
                if (DrawMod.TGame.HandyFunctionsObj.HasUnitAirSF(index6))
                  flag = false;
                if (DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(index6) < 1)
                  flag = false;
                if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.Designer)) >= 71 && DrawMod.TGame.Data.UnitObj[index6].TempCategory == 5)
                  flag = false;
                if (flag)
                {
                  int idValue = this.data.HistoricalUnitObj[historical2].GiveHisVarValue(1);
                  int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, idValue, 2)));
                  int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, idValue, 4)));
                  if (num2 <= num1 & num3 > 0)
                  {
                    int num4 = DrawMod.TGame.HandyFunctionsObj.Distance(this.data.UnitObj[index5].X, this.data.UnitObj[index5].Y, 0, this.data.UnitObj[index6].X, this.data.UnitObj[index6].Y, 0, 99);
                    if (num4 < 99)
                    {
                      if (hq == simpleList1.Id[index4])
                        num4 = (int) Math.Round((double) num4 / 3.0);
                      int tweight = num4 * 10 + 10;
                      if (num2 == num1 - 2)
                        tweight *= 9;
                      if (num2 == num1 - 1)
                        tweight *= 3;
                      if (this.ai.GetAIRolePercent(index6, 8) > 60)
                        tweight = (int) Math.Round((double) tweight / 6.0);
                      else if (this.ai.GetAIRolePercent(index6, 10) > 60)
                        tweight = (int) Math.Round((double) tweight / 6.0);
                      else if (this.ai.GetAIRolePercent(index6, 8) > 30)
                        tweight = (int) Math.Round((double) tweight / 3.0);
                      else if (this.ai.GetAIRolePercent(index6, 10) > 30)
                        tweight = (int) Math.Round((double) tweight / 3.0);
                      simpleList2.Add(index6, tweight);
                      simpleList3.Add(index6, tweight, hq);
                    }
                  }
                }
              }
            }
          }
        }
        if (simpleList2.Counter > -1)
        {
          simpleList2.SortHighSpeed();
          int num5 = 0;
          int counter2 = simpleList2.Counter;
          for (int index7 = 0; index7 <= counter2; ++index7)
          {
            int tid = simpleList2.Id[index7];
            int hq = this.data.UnitObj[tid].HQ;
            bool flag = false;
            if (hq > -1 && this.data.HistoricalUnitObj[this.data.UnitObj[hq].Historical].Type < 7)
              flag = true;
            if (simpleList1.Data1[index4] > simpleList1.Weight[index4] & this.data.UnitObj[tid].HQ != index5 & !flag)
            {
              ++num5;
              int[] weight = simpleList1.Weight;
              int[] numArray = weight;
              int index8 = index4;
              int index9 = index8;
              int num6 = weight[index8] + 1;
              numArray[index9] = num6;
              this.data.UnitObj[tid].HQ = index5;
              this.ai.AddLog("-Assigned aux unit '" + this.data.UnitObj[tid].Name + "' to '" + this.data.UnitObj[index5].Name + "'.");
            }
            else if (simpleList1.Weight[index4] > simpleList1.Data1[index4])
            {
              int num7 = 0;
              int index10 = -1;
              int counter3 = simpleList3.Counter;
              for (int index11 = 0; index11 <= counter3; ++index11)
              {
                if (simpleList3.Data1[index11] == simpleList1.Id[index4] && simpleList3.Weight[index11] > num7)
                {
                  num7 = simpleList3.Weight[index11];
                  index10 = simpleList3.Id[index11];
                }
              }
              if (index10 > -1)
              {
                this.data.UnitObj[index10].HQ = this.data.UnitObj[index5].HQ;
                this.ai.AddLog("-REMOVED aux unit '" + this.data.UnitObj[index10].Name + "' from '" + this.data.UnitObj[index5].Name + "'.");
                int[] weight = simpleList1.Weight;
                int[] numArray = weight;
                int index12 = index4;
                int index13 = index12;
                int num8 = weight[index12] - 1;
                numArray[index13] = num8;
              }
            }
            else if (this.data.UnitObj[tid].HQ != index5 & !flag)
            {
              ++num5;
              int num9 = 0;
              int index14 = -1;
              int counter4 = simpleList3.Counter;
              for (int index15 = 0; index15 <= counter4; ++index15)
              {
                if (this.data.UnitObj[simpleList3.Id[index15]].HQ == simpleList1.Id[index4] && simpleList3.Weight[index15] > num9)
                {
                  num9 = simpleList3.Weight[index15];
                  index14 = simpleList3.Id[index15];
                }
              }
              int weight = simpleList3.FindWeight(tid);
              if (index14 > -1 && num9 * 3 < weight | this.data.UnitObj[tid].TempUnitPowerAbs * 2 < this.data.UnitObj[index14].TempUnitPowerAbs)
              {
                this.data.UnitObj[index14].HQ = this.data.UnitObj[index5].HQ;
                this.data.UnitObj[tid].HQ = index5;
                this.ai.AddLog("-REMOVED aux unit '" + this.data.UnitObj[index14].Name + "' from '" + this.data.UnitObj[index5].Name + "'.");
                this.ai.AddLog("-Assigned aux unit '" + this.data.UnitObj[tid].Name + "' to '" + this.data.UnitObj[index5].Name + "'.");
              }
            }
            else if (this.data.UnitObj[tid].HQ == index5)
              ++num5;
            if (num5 >= simpleList1.Data1[index4])
              break;
          }
        }
      }
      this.ai.WriteLog(str);
    }

    public void DisbandExcessTroops()
    {
      string str = "8600a_AI_DisbandExcessTroops";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str);
      this.ai.AddLog("");
      int counter = this.ShqList.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        this.shqHisId = this.ShqList.Id[index];
        this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
        this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
        this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
        this.ai.AddLog("Checking " + this.shqName);
        for (int sfCount = this.data.UnitObj[this.shqUnitNr].SFCount; sfCount >= 0; sfCount += -1)
        {
          int sf = this.data.UnitObj[this.shqUnitNr].SFList[sfCount];
          int type = this.data.SFObj[sf].Type;
          int qty = this.data.SFObj[sf].Qty;
          int people = this.data.SFObj[sf].People;
          int tvalue1 = this.data.SFTypeObj[type].SFTypeVar[81];
          if (this.data.PeopleObj[people].tv1 < 10 & tvalue1 > 0 & qty > 0)
          {
            this.ai.AddLog("We have " + qty.ToString() + "x " + this.data.SFTypeObj[type].Name + " present. Lets half that!");
            DrawMod.TGame.EditObj.UDSClearInput();
            DrawMod.TGame.EditObj.UDSAddInput("SFNR", sf);
            DrawMod.TGame.EditObj.UDSAddInput("UNR", this.shqUnitNr);
            DrawMod.TGame.EditObj.UDSAddInput("CHOICE", tvalue1);
            int tvalue2 = Math.Max(1, (int) Math.Round(Math.Ceiling((double) qty / 2.0)));
            DrawMod.TGame.EditObj.UDSAddInput("QTY", tvalue2);
            DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_Scrap_Commence(0);
            DrawMod.TGame.EventRelatedObj.IO_AddClear();
          }
        }
      }
      this.ai.WriteLog(str);
    }

    public void SetModelQualities()
    {
      string str1 = "8600b_AI_SetModelQuality";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      int reinfCounter = this.data.ReinfCounter;
      for (int index1 = 0; index1 <= reinfCounter; ++index1)
      {
        SimpleList simpleList = new SimpleList();
        bool flag = false;
        int length = this.data.StringListObj[this.slotRegimeModels].Length;
        for (int tid = 0; tid <= length; ++tid)
        {
          int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 0]));
          int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 1]));
          int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 2]));
          string str2 = this.data.StringListObj[this.slotRegimeModels].Data[tid, 3];
          int tweight1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 4]));
          int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 5]));
          int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 6]));
          int num5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 7]));
          int num6 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 8]));
          int tdata1 = this.data.StringListObj[this.slotRegimeModels].Width < 11 ? 0 : (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[tid, 11]));
          if (num3 == this.RegimeId)
          {
            int sfTypeById = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id);
            if (sfTypeById > -1 && this.data.SFTypeObj[sfTypeById].ReinforcementType == index1)
            {
              if (index1 == 32)
                index1 = index1;
              if (tdata1 > 0)
                flag = true;
              if (DrawMod.TGame.Data.SFTypeObj[sfTypeById].Theater == 2)
              {
                int tweight2;
                if (this.data.ReinfId[this.data.SFTypeObj[sfTypeById].ReinforcementType] == 59 | this.data.ReinfId[this.data.SFTypeObj[sfTypeById].ReinforcementType] == 60 | this.data.ReinfId[this.data.SFTypeObj[sfTypeById].ReinforcementType] == 61)
                {
                  int val1 = 0;
                  int val2 = 0;
                  int sfTypeCounter = this.ai.game.Data.SFTypeCounter;
                  for (int index2 = 0; index2 <= sfTypeCounter; ++index2)
                  {
                    if (this.data.SFTypeObj[index2].Theater == 2)
                    {
                      int idValue = this.ai.game.Data.SFTypeObj[index2].SFTypeVar[81];
                      if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, idValue, 6))) == num4 | num1 == idValue)
                      {
                        val1 += this.data.SFTypeObj[index2].SFTypeVar[3] + 1;
                        val2 = val2 + (this.data.SFTypeObj[index2].SFTypeVar[6] + 1) + (int) Math.Round((double) this.data.SFTypeObj[index2].SFTypeVar[4] / 10.0);
                      }
                    }
                  }
                  if (val1 < 1)
                    val1 = 1;
                  if (val2 < 1)
                    val2 = 1;
                  int num7 = (int) Math.Round((double) (int) Math.Round((double) (val2 * 10) / (double) val1) * Math.Sqrt((double) (Math.Max(val1, val2) + 1)));
                  tweight2 = num7 + (int) Math.Round((double) (num7 * tweight1) / 2.0);
                }
                else
                {
                  int val1 = 0;
                  int val2 = 0;
                  int sfTypeCounter = this.ai.game.Data.SFTypeCounter;
                  for (int index3 = 0; index3 <= sfTypeCounter; ++index3)
                  {
                    if (this.data.SFTypeObj[index3].Theater == 2)
                    {
                      int idValue = this.ai.game.Data.SFTypeObj[index3].SFTypeVar[81];
                      if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, idValue, 6))) == num4 | num1 == idValue)
                      {
                        val1 += this.data.SFTypeObj[sfTypeById].SFTypeVar[3] + 1;
                        val2 += this.data.SFTypeObj[sfTypeById].SFTypeVar[4] + 1;
                      }
                    }
                  }
                  if (val1 < 1)
                    val1 = 1;
                  if (val2 < 1)
                    val2 = 1;
                  int num8 = (int) Math.Round((double) (int) Math.Round((double) (val2 * 10) / (double) val1) * Math.Sqrt((double) (Math.Max(val1, val2) + 1)));
                  tweight2 = num8 + (int) Math.Round((double) (num8 * tweight1) / 2.0);
                }
                simpleList.Add(tid, tweight2, tdata1);
              }
              else
                simpleList.Add(tid, tweight1, tdata1);
            }
          }
        }
        if (simpleList.Counter > -1)
        {
          this.ai.AddLog("Reinforcement Type " + index1.ToString() + " : " + this.data.ReinfName[index1]);
          simpleList.ReverseSort();
          int num9 = 0;
          int counter = simpleList.Counter;
          for (int index4 = 0; index4 <= counter; ++index4)
          {
            int index5 = simpleList.Id[index4];
            int setValue;
            switch (index4)
            {
              case 0:
                setValue = 4;
                break;
              case 1:
                setValue = 3;
                break;
              default:
                setValue = 2;
                break;
            }
            int num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index5, 0]));
            int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index5, 4]));
            int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index5, 5]));
            int sfTypeById = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(num12);
            if (this.data.SFTypeObj[sfTypeById].Theater != 2)
            {
              switch (num11)
              {
                case 1:
                  setValue = 2;
                  break;
                case 2:
                  if (setValue > 3)
                  {
                    setValue = 3;
                    break;
                  }
                  break;
                case 3:
                  if (setValue > 4)
                  {
                    setValue = 4;
                    break;
                  }
                  break;
              }
              if (flag & simpleList.Data1[index4] < 1 && setValue < 5)
              {
                ++setValue;
                if (setValue > 5)
                  setValue = 5;
              }
              if (flag & simpleList.Data1[index4] > 0)
                setValue = 2;
              if (this.data.SFTypeObj[sfTypeById].SFTypeVar[65] > 0 | this.data.SFTypeObj[sfTypeById].SFTypeVar[66] > 0)
              {
                if (setValue < 5)
                  setValue = 5;
              }
              else if (this.data.SFTypeObj[sfTypeById].SFTypeVar[64] > 0 | this.data.SFTypeObj[sfTypeById].SFTypeVar[65] > 0)
              {
                if (setValue < 4)
                  setValue = 4;
              }
              else if (this.data.SFTypeObj[sfTypeById].SFTypeVar[64] > 0 | this.data.SFTypeObj[sfTypeById].SFTypeVar[67] > 0 | this.data.SFTypeObj[sfTypeById].SFTypeVar[47] == 15)
              {
                if (setValue < 3)
                  setValue = 3;
              }
              else if (setValue < 2)
                setValue = 2;
            }
            if (this.data.SFTypeObj[sfTypeById].Theater == 2)
            {
              if (this.data.ReinfId[this.data.SFTypeObj[sfTypeById].ReinforcementType] == 59 | this.data.ReinfId[this.data.SFTypeObj[sfTypeById].ReinforcementType] == 60 | this.data.ReinfId[this.data.SFTypeObj[sfTypeById].ReinforcementType] == 61)
              {
                if (this.data.SFTypeObj[sfTypeById].SFTypeVar[18] > 0 && setValue < 5)
                  ++setValue;
              }
              else if (this.data.SFTypeObj[sfTypeById].SFTypeVar[18] < 1 && setValue < 5)
                ++setValue;
              if (this.data.SFTypeObj[sfTypeById].AirAPRule > 20)
                setValue = 1;
            }
            if (setValue > num9)
              num9 = setValue;
            this.ai.AddLog("Model ID " + num10.ToString() + ", version " + num11.ToString() + ", SFType " + this.data.SFTypeObj[sfTypeById].Name + " gets Quality Level = " + setValue.ToString());
            this.data.StringListObj[this.slotRegimeModels].Data[index5, 9] = setValue.ToString();
            this.data.StringListObj[this.slotsftypequality].SetData2(0, num12, 1, this.RegimeId, 2, setValue, true);
          }
          if (num9 < 5)
          {
            int index6 = simpleList.Id[0];
            int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index6, 0]));
            int num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index6, 4]));
            int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index6, 5]));
            int sfTypeById = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(num15);
            if (this.data.SFTypeObj[sfTypeById].Theater == 2)
            {
              int setValue = 5;
              this.data.StringListObj[this.slotRegimeModels].Data[index6, 9] = setValue.ToString();
              this.data.StringListObj[this.slotsftypequality].SetData2(0, num15, 1, this.RegimeId, 2, setValue, true);
              this.ai.AddLog("PUSHED HIGHER => Model ID " + num13.ToString() + ", version " + num14.ToString() + ", SFType " + this.data.SFTypeObj[sfTypeById].Name + " gets Quality Level = " + setValue.ToString());
            }
          }
        }
      }
      this.ai.WriteLog(str1);
    }

    public void SetPaths(ref Shadow_Economic_AI aiEconomic)
    {
      string str = "8500_AI_SetPaths";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str);
      this.ai.AddLog("");
      SimpleList simpleList = new SimpleList();
      int num1 = 0;
      int counter1 = this.ShqList.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.ShqList.Data1[index] > num1)
          num1 = this.ShqList.Data1[index];
      }
      int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 13)));
      int num2;
      int num3;
      int num4;
      if (idValue > 0)
      {
        num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotImod].GetData(0, idValue, 9)));
        num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotImod].GetData(0, idValue, 10)));
        num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotImod].GetData(0, idValue, 11)));
      }
      int num5 = 0;
      int num6 = 0;
      int num7 = 0;
      int num8 = 0;
      int regimeCounter1 = this.data.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter1; ++index1)
      {
        if (Information.IsNothing((object) this.regimeZoneList[index1]))
          this.regimeZoneList[index1] = new SimpleList();
        if (index1 == this.data.Turn)
        {
          this.regimeZoneList[index1] = new SimpleList();
          int length = this.data.StringListObj[this.slotZones].Length;
          for (int index2 = 0; index2 <= length; ++index2)
          {
            int num9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 8]));
            int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 0]));
            if (num9 == this.RegimeId)
              this.regimeZoneList[index1].Add(tid, 1);
          }
        }
      }
      int counter2 = this.ShqList.Counter;
      for (int index3 = 0; index3 <= counter2; ++index3)
      {
        num5 += this.friendlyEconomicValue[index3];
        num7 += this.friendlyMilitaryValue[index3];
        int regimeCounter2 = this.data.RegimeCounter;
        for (int index4 = 0; index4 <= regimeCounter2; ++index4)
        {
          if (index4 != this.data.Turn)
          {
            bool flag1 = false;
            bool flag2 = false;
            int num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index4].id, 1)));
            int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[index4].id, 2, "aiIntention", 3)));
            int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[index4].id, 2, "relation", 3)));
            int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[index4].id, 2, "dipClear", 3)));
            int counter3 = this.regimeZoneList[this.data.Turn].Counter;
            for (int index5 = 0; index5 <= counter3; ++index5)
            {
              int counter4 = this.regimeZoneList[index4].Counter;
              for (int index6 = 0; index6 <= counter4; ++index6)
              {
                int zoneId = this.regimeZoneList[this.data.Turn].Id[index5];
                int zone2id = this.regimeZoneList[index4].Id[index6];
                if (DrawMod.TGame.EventRelatedObj.Helper_AreZonesNeighbour("SE_Data", zoneId, zone2id))
                {
                  flag2 = true;
                  this.ai.AddLog("* Has border with " + this.data.RegimeObj[index4].Name);
                }
              }
            }
            if (num10 == 1 | num10 == 2 & num13 == 1 | num10 == 3 && this.data.RegimeObj[this.data.Turn].RegimeRel[index4] == 0)
              flag1 = true;
            if (!flag1 & num10 < 4 && num11 < 30 | num12 < 20)
              flag1 = true;
            if (flag1 & flag2)
            {
              num6 += this.enemyEconomicValue[index3, index4];
              num8 += (int) Math.Round((double) (this.enemyMilitaryValueWeAtt[index3, index4] + this.enemyMilitaryValueWeDef[index3, index4]) / 2.0);
            }
            else if (flag2 & num10 < 4)
            {
              int num14 = num12 < 66 ? (num12 < 50 ? (num12 < 35 ? (num12 < 26 ? 2 : 3) : 5) : 7) : 9;
              num6 += (int) Math.Round((double) this.enemyEconomicValue[index3, index4] / (double) num14);
              num8 += (int) Math.Round((double) (this.enemyMilitaryValueWeAtt[index3, index4] + this.enemyMilitaryValueWeDef[index3, index4]) / (double) (2 * num14));
            }
          }
        }
      }
      int num15 = Math.Max(1, this.ShqList.Counter + 1);
      int num16 = (int) Math.Round((double) num5 / (double) num15);
      int num17 = (int) Math.Round((double) num6 / (double) num15);
      int num18 = (int) Math.Round((double) num7 / (double) num15);
      int num19 = (int) Math.Round((double) num8 / (double) num15);
      this.ai.AddLog("");
      this.ai.AddLog("Best SHQ Stage = " + num1.ToString());
      this.ai.AddLog("AI Faction ID = " + idValue.ToString());
      this.ai.AddLog("Tech Path Overrule = " + num2.ToString());
      this.ai.AddLog("Eco Path Overrule = " + num3.ToString());
      this.ai.AddLog("War Path Overrule = " + num4.ToString());
      this.ai.AddLog("Total Friendly Eco = " + num16.ToString());
      this.ai.AddLog("Total Enemy Eco = " + num17.ToString());
      this.ai.AddLog("Total Friendly Mil = " + num18.ToString());
      this.ai.AddLog("Total Enemy Mil = " + num19.ToString());
      this.ai.AddLog("");
      int num20;
      int num21;
      if (num18 > num19 * 4)
      {
        num20 = 90;
        num21 = 10;
      }
      else if (num18 > num19 * 3)
      {
        num20 = 80;
        num21 = 20;
      }
      else if (num18 > num19 * 2)
      {
        num20 = 70;
        num21 = 30;
      }
      else if ((double) num18 > (double) num19 * 1.5)
      {
        num20 = 60;
        num21 = 40;
      }
      else if (num18 > num19)
      {
        num20 = 40;
        num21 = 60;
      }
      else if ((double) num18 > (double) num19 * 0.5)
      {
        num20 = 30;
        num21 = 70;
      }
      else
      {
        num20 = 10;
        num21 = 90;
      }
      if (num4 > 0)
      {
        if (num4 == 1)
        {
          num20 = Math.Min(100, (int) Math.Round((double) num20 * 1.5));
          num21 = 100 - num20;
        }
        if (num4 == 2)
        {
          num21 = Math.Min(100, (int) Math.Round((double) num21 * 1.5));
          num20 = 100 - num20;
        }
      }
      int num22;
      int num23;
      int num24;
      if (num16 > 2 * num17)
      {
        if (num18 >= 3 * num19)
        {
          num22 = 25;
          num23 = 25;
          num24 = 50;
          num20 = Math.Min(100, num20 * 2);
          num21 = 100 - num20;
        }
        else if (num18 >= 3 * num19)
        {
          num22 = 50;
          num23 = 50;
          num24 = 0;
          num20 = Math.Min(100, (int) Math.Round((double) num20 * 1.5));
          num21 = 100 - num20;
        }
        else if (num18 >= num19)
        {
          num22 = 75;
          num23 = 25;
          num24 = 0;
          num21 = Math.Min(100, (int) Math.Round((double) num21 * 1.5));
          num20 = 100 - num20;
        }
      }
      else if ((double) num16 < 0.66 * (double) num17)
      {
        if ((double) num18 >= 1.5 * (double) num19)
        {
          num22 = 100;
          num23 = 0;
          num24 = 0;
          num20 = Math.Min(100, 30 + num20 * 3);
          num21 = 100 - num20;
        }
        else if (num18 >= num19)
        {
          num22 = 70;
          num23 = 30;
          num24 = 0;
          num20 = num20;
          num21 = num21;
        }
        else
        {
          num22 = 50;
          num23 = 50;
          num24 = 0;
          num21 = Math.Min(100, (int) Math.Round((double) num21 * 1.5));
          num20 = 100 - num20;
        }
      }
      else
      {
        num22 = 33;
        num23 = 33;
        num24 = 33;
      }
      if (num3 > 0)
      {
        if (num3 == 1)
          num23 = Math.Min(100, 20 + (int) Math.Round((double) num23 * 1.5));
        if (num3 == 2)
          num24 = Math.Min(100, 20 + (int) Math.Round((double) num24 * 1.5));
        if (num3 == 3)
          num22 = Math.Min(100, 20 + (int) Math.Round((double) num23 * 1.5));
      }
      int num25 = 33;
      int num26 = 33;
      int num27 = 33;
      if (num2 > 0)
      {
        if (num2 == 1)
          num27 = Math.Min(100, num27 * 2);
        if (num2 == 2)
          num26 = Math.Min(100, num26 * 2);
        if (num2 == 3)
          num25 = Math.Min(100, num25 * 2);
      }
      if (num23 < 20)
        num23 = 20;
      if (num24 < 20)
        num24 = 20;
      if (num22 < 20)
        num22 = 20;
      if (this.pathEco_American == 0 & this.pathEco_Soviet == 0 & this.pathEco_German == 0)
      {
        this.pathEco_American = 33;
        this.pathEco_Soviet = 33;
        this.pathEco_German = 33;
        this.pathTech_Military = 33;
        this.pathTech_Economy = 33;
        this.pathTech_Artillery = 33;
        this.pathWar_Offensive = 50;
        this.pathWar_Defensive = 50;
      }
      this.ai.AddLog("PathEco_American = " + this.pathEco_American.ToString());
      this.ai.AddLog("PathEco_German = " + this.pathEco_German.ToString());
      this.ai.AddLog("PathEco_Soviet = " + this.pathEco_Soviet.ToString());
      this.ai.AddLog("PathTech_Military = " + this.pathTech_Military.ToString());
      this.ai.AddLog("PathTech_Economy = " + this.pathTech_Economy.ToString());
      this.ai.AddLog("PathTech_Artillery = " + this.pathTech_Artillery.ToString());
      this.ai.AddLog("PathWar_Offensive = " + this.pathWar_Offensive.ToString());
      this.ai.AddLog("PathWar_Defensive = " + this.pathWar_Defensive.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("NEW PathEco_American = " + num23.ToString());
      this.ai.AddLog("NEW PathEco_German = " + num24.ToString());
      this.ai.AddLog("NEW PathEco_Soviet = " + num22.ToString());
      this.ai.AddLog("NEW PathTech_Military = " + num27.ToString());
      this.ai.AddLog("NEW PathTech_Economy = " + num26.ToString());
      this.ai.AddLog("NEW PathTech_Artillery = " + num25.ToString());
      this.ai.AddLog("NEW PathWar_Offensive = " + num20.ToString());
      this.ai.AddLog("NEW PathWar_Defensive = " + num21.ToString());
      this.ai.AddLog("");
      this.pathEco_American = (int) Math.Round((double) (this.pathEco_American * 5 + num23) / 6.0);
      this.pathEco_Soviet = (int) Math.Round((double) (this.pathEco_Soviet * 5 + num22) / 6.0);
      this.pathEco_German = (int) Math.Round((double) (this.pathEco_German * 5 + num24) / 6.0);
      this.pathTech_Military = (int) Math.Round((double) (this.pathTech_Military * 5 + num27) / 6.0);
      this.pathTech_Economy = (int) Math.Round((double) (this.pathTech_Economy * 5 + num26) / 6.0);
      this.pathTech_Artillery = (int) Math.Round((double) (this.pathTech_Artillery * 5 + num25) / 6.0);
      this.pathWar_Offensive = (int) Math.Round((double) (this.pathWar_Offensive * 5 + num20) / 6.0);
      this.pathWar_Defensive = (int) Math.Round((double) (this.pathWar_Defensive * 5 + num21) / 6.0);
      this.ai.AddLog("ADJUSTED PathEco_American = " + this.pathEco_American.ToString());
      this.ai.AddLog("ADJUSTED PathEco_German = " + this.pathEco_German.ToString());
      this.ai.AddLog("ADJUSTED PathEco_Soviet = " + this.pathEco_Soviet.ToString());
      this.ai.AddLog("ADJUSTED PathTech_Military = " + this.pathTech_Military.ToString());
      this.ai.AddLog("ADJUSTED PathTech_Economy = " + this.pathTech_Economy.ToString());
      this.ai.AddLog("ADJUSTED PathTech_Artillery = " + this.pathTech_Artillery.ToString());
      this.ai.AddLog("ADJUSTED PathWar_Offensive = " + this.pathWar_Offensive.ToString());
      this.ai.AddLog("ADJUSTED PathWar_Defensive = " + this.pathWar_Defensive.ToString());
      this.ai.AddLog("");
      this.ai.WriteLog(str);
    }

    public SimpleList GetWeightedReinfLists(bool forEnemy, bool actuallyNonWeighted = false)
    {
      SimpleList weightedReinfLists = new SimpleList();
      SimpleList simpleList = new SimpleList();
      if (forEnemy)
      {
        int regimeCounter1 = this.data.RegimeCounter;
        for (int index1 = 0; index1 <= regimeCounter1; ++index1)
        {
          if (Information.IsNothing((object) this.regimeZoneList[index1]))
            this.regimeZoneList[index1] = new SimpleList();
          if (index1 == this.data.Turn)
          {
            this.regimeZoneList[index1] = new SimpleList();
            int length = this.data.StringListObj[this.slotZones].Length;
            for (int index2 = 0; index2 <= length; ++index2)
            {
              int num = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 8]));
              int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 0]));
              if (num == this.RegimeId)
                this.regimeZoneList[index1].Add(tid, 1);
            }
          }
        }
        int counter1 = this.ShqList.Counter;
        for (int index3 = 0; index3 <= counter1; ++index3)
        {
          int regimeCounter2 = this.data.RegimeCounter;
          for (int tid = 0; tid <= regimeCounter2; ++tid)
          {
            if (tid != this.data.Turn)
            {
              bool flag1 = false;
              bool flag2 = false;
              int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid].id, 1)));
              int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[tid].id, 2, "aiIntention", 3)));
              int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[tid].id, 2, "relation", 3)));
              int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[tid].id, 2, "dipClear", 3)));
              int counter2 = this.regimeZoneList[this.data.Turn].Counter;
              for (int index4 = 0; index4 <= counter2; ++index4)
              {
                int counter3 = this.regimeZoneList[tid].Counter;
                for (int index5 = 0; index5 <= counter3; ++index5)
                {
                  int zoneId = this.regimeZoneList[this.data.Turn].Id[index4];
                  int zone2id = this.regimeZoneList[tid].Id[index5];
                  if (DrawMod.TGame.EventRelatedObj.Helper_AreZonesNeighbour("SE_Data", zoneId, zone2id))
                    flag2 = true;
                }
              }
              if (num1 == 1 | num1 == 2 & num4 == 1 | num1 == 3 && this.data.RegimeObj[this.data.Turn].RegimeRel[tid] == 0)
                flag1 = true;
              if (!flag1 & num1 < 4 && num2 < 30 | num3 < 20)
                flag1 = true;
              if (flag1 & flag2)
                simpleList.Add(tid, 1000);
              else if (flag2 & num1 < 4)
              {
                int tweight = num3 < 66 ? (num3 < 50 ? (num3 < 35 ? (num3 < 26 ? 800 : 600) : 400) : 200) : 100;
                simpleList.Add(tid, tweight);
              }
            }
          }
        }
      }
      if (!forEnemy)
        simpleList.Add(this.data.Turn, 1000);
      int[] numArray1 = new int[1000];
      int counter = simpleList.Counter;
      for (int index6 = 0; index6 <= counter; ++index6)
      {
        int num5 = simpleList.Id[index6];
        int unitCounter = this.data.UnitCounter;
        for (int index7 = 0; index7 <= unitCounter; ++index7)
        {
          if (this.data.UnitObj[index7].PreDef == -1 & this.data.UnitObj[index7].Regime == num5)
          {
            bool flag = true;
            if (this.data.HistoricalUnitObj[this.data.UnitObj[index7].Historical].BattleGroup > 0)
              flag = false;
            if (flag)
            {
              int sfCount = this.data.UnitObj[index7].SFCount;
              for (int index8 = 0; index8 <= sfCount; ++index8)
              {
                int sf = this.data.UnitObj[index7].SFList[index8];
                int type = this.data.SFObj[sf].Type;
                int qty = this.data.SFObj[sf].Qty;
                int num6;
                if (actuallyNonWeighted)
                {
                  num6 = 1000;
                  if (this.data.SFTypeObj[type].ReinforcementType > -1)
                  {
                    int id = this.data.ReinfLibId[this.data.SFTypeObj[type].ReinforcementType].id;
                    if (id > -1)
                    {
                      int[] numArray2 = numArray1;
                      int[] numArray3 = numArray2;
                      int index9 = id;
                      int index10 = index9;
                      int num7 = numArray2[index9] + qty * num6;
                      numArray3[index10] = num7;
                    }
                  }
                }
                else
                {
                  int num8 = this.data.SFTypeObj[type].ArtRange <= 0 ? (this.data.SFTypeObj[type].AARange <= 0 ? (this.data.SFTypeObj[type].Theater != 2 ? num6 + (int) Math.Round((double) (this.data.SFTypeObj[type].SFTypeVar[30] + this.data.SFTypeObj[type].SFTypeVar[31]) / 2.0) * (int) Math.Round(Math.Sqrt((double) this.data.SFTypeObj[type].SFTypeVar[34])) + (int) Math.Round((double) (this.data.SFTypeObj[type].SFTypeVar[32] + this.data.SFTypeObj[type].SFTypeVar[33]) / 2.0) * (int) Math.Round(Math.Sqrt((double) this.data.SFTypeObj[type].SFTypeVar[34])) : this.data.SFTypeObj[type].SFTypeVar[34] * 10 + (int) Math.Round((double) (this.data.SFTypeObj[type].SFTypeVar[30] + this.data.SFTypeObj[type].SFTypeVar[32]) / 2.0) * (int) Math.Round(Math.Sqrt((double) this.data.SFTypeObj[type].SFTypeVar[34])) + (int) Math.Round((double) (this.data.SFTypeObj[type].SFTypeVar[14] + this.data.SFTypeObj[type].SFTypeVar[21]) / 2.0) * (int) Math.Round(Math.Sqrt((double) this.data.SFTypeObj[type].SFTypeVar[34]))) : this.data.SFTypeObj[type].SFTypeVar[34] * 10 + this.data.SFTypeObj[type].SFTypeVar[14] * 80 + this.data.SFTypeObj[type].SFTypeVar[21] * 80) : this.data.SFTypeObj[type].SFTypeVar[30] * 160 * this.data.SFTypeObj[type].Attacks;
                  if (this.data.SFTypeObj[type].EndCombatRound > 0)
                    num8 = (int) Math.Round((double) num8 * ((double) this.data.SFTypeObj[type].EndCombatRound / 10.0));
                  num6 = (int) Math.Round((double) (num8 * this.data.SFTypeObj[type].KillPercent) / 100.0) + (int) Math.Round((double) (num8 * this.data.SFTypeObj[type].RetreatPercent) / 200.0);
                  if (this.data.SFTypeObj[type].ReinforcementType > -1)
                  {
                    int id = this.data.ReinfLibId[this.data.SFTypeObj[type].ReinforcementType].id;
                    if (id > -1)
                    {
                      int[] numArray4 = numArray1;
                      int[] numArray5 = numArray4;
                      int index11 = id;
                      int index12 = index11;
                      int num9 = numArray4[index11] + (int) Math.Round((double) (qty * num6 * simpleList.Weight[index6]) / 1000.0);
                      numArray5[index12] = num9;
                    }
                  }
                }
              }
            }
          }
        }
      }
      int tid1 = 0;
      do
      {
        if (numArray1[tid1] > 0)
          weightedReinfLists.Add(tid1, numArray1[tid1]);
        ++tid1;
      }
      while (tid1 <= 999);
      return weightedReinfLists;
    }

    public void SetOOBratingList()
    {
      string str = "0002b_AI_SetOOBratingList";
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str);
      this.ai.AddLog("");
      this.OobRatingList = new SimpleList();
      int[,] numArray1 = new int[this.data.SFTypeCounter + 1, 3];
      int unitCounter = this.data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.data.UnitObj[index1].PreDef == -1)
        {
          int sfCount = this.data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.data.UnitObj[index1].SFList[index2];
            int type = this.data.SFObj[sf].Type;
            int qty = this.data.SFObj[sf].Qty;
            if (this.data.UnitObj[index1].Regime == this.data.Turn & this.data.UnitObj[index1].PreDef == -1)
            {
              int[,] numArray2 = numArray1;
              int[,] numArray3 = numArray2;
              int index3 = type;
              int index4 = index3;
              int index5 = 0;
              int index6 = index5;
              int num = numArray2[index3, index5] + qty;
              numArray3[index4, index6] = num;
            }
            else if (this.data.UnitObj[index1].PreDef == -1)
            {
              int regime = this.data.UnitObj[index1].Regime;
              int[,] numArray4 = numArray1;
              int[,] numArray5 = numArray4;
              int index7 = type;
              int index8 = index7;
              int index9 = 1;
              int index10 = index9;
              int num = numArray4[index7, index9] + qty;
              numArray5[index8, index10] = num;
            }
          }
        }
      }
      float[,] numArray6 = new float[this.data.SFTypeCounter + 1, 3];
      float[] numArray7 = new float[this.data.SFTypeCounter + 1];
      float[] numArray8 = new float[this.data.SFTypeCounter + 1];
      int sfTypeCounter1 = this.data.SFTypeCounter;
      for (int index11 = 0; index11 <= sfTypeCounter1; ++index11)
      {
        if (this.data.SFTypeObj[index11].SFTypeVar[81] > 0)
        {
          long num1 = 0;
          int sfTypeCounter2 = this.data.SFTypeCounter;
          for (int index12 = 0; index12 <= sfTypeCounter2; ++index12)
          {
            if (numArray1[index12, 1] > 0)
            {
              if (this.data.SFTypeObj[index11].AttackPower[this.data.SFTypeObj[index12].UnitGroup] > 0)
              {
                num1 += (long) numArray1[index12, 1];
                if (this.data.SFTypeObj[index11].BackBench & this.data.SFTypeObj[index11].ArtRange > 0)
                {
                  float[,] numArray9 = numArray6;
                  float[,] numArray10 = numArray9;
                  int index13 = index11;
                  int index14 = index13;
                  int index15 = 0;
                  int index16 = index15;
                  double num2 = (double) numArray9[index13, index15] + (double) this.ai.combatMatrix[index11, index12] * (double) numArray1[index12, 1];
                  numArray10[index14, index16] = (float) num2;
                }
                else
                {
                  float[,] numArray11 = numArray6;
                  float[,] numArray12 = numArray11;
                  int index17 = index11;
                  int index18 = index17;
                  int index19 = 0;
                  int index20 = index19;
                  double num3 = (double) numArray11[index17, index19] + ((double) this.ai.combatMatrix[index11, index12] + 1.0 / (double) this.ai.combatMatrix[index12, index11]) / 2.0 * (double) numArray1[index12, 1];
                  numArray12[index18, index20] = (float) num3;
                }
                float[] numArray13 = numArray7;
                float[] numArray14 = numArray13;
                int index21 = index11;
                int index22 = index21;
                double num4 = (double) numArray13[index21] + 1.0 / (double) this.ai.combatMatrix[index12, index11] * (double) numArray1[index12, 1];
                numArray14[index22] = (float) num4;
              }
              else
                index12 = index12;
            }
          }
          if (num1 > 0L)
          {
            numArray6[index11, 0] = numArray6[index11, 0] / (float) num1;
            numArray7[index11] = numArray7[index11] / (float) num1;
          }
          else
          {
            numArray6[index11, 0] = 0.25f;
            numArray7[index11] = 0.25f;
          }
          if (this.data.SFTypeObj[index11].BackBench)
          {
            float[,] numArray15 = numArray6;
            float[,] numArray16 = numArray15;
            int index23 = index11;
            int index24 = index23;
            int index25 = 0;
            int index26 = index25;
            double num5 = (double) numArray15[index23, index25] * 2.0;
            numArray16[index24, index26] = (float) num5;
          }
        }
      }
      int[] numArray17 = new int[this.data.SFTypeCounter + 10 + 1];
      int sfTypeCounter3 = this.data.SFTypeCounter;
      for (int typ = 0; typ <= sfTypeCounter3; ++typ)
      {
        if (this.data.SFTypeObj[typ].SFTypeVar[81] > 0 && this.data.StringListObj[this.slotRegimeModels].FindRow2(0, this.data.SFTypeObj[typ].SFTypeVar[81], 2, this.RegimeId) > -1)
        {
          int typeProdCostScore = DrawMod.TGame.HandyFunctionsObj.GetSFTypeProdCostScore(typ);
          numArray17[typ] = typeProdCostScore;
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("WEIGHTED PROD COSTS FOR SFTYPES:");
      int reinfCounter = this.data.ReinfCounter;
      for (int index27 = 0; index27 <= reinfCounter; ++index27)
      {
        int num6 = 0;
        int num7 = 0;
        int sfTypeCounter4 = this.data.SFTypeCounter;
        for (int index28 = 0; index28 <= sfTypeCounter4; ++index28)
        {
          if (numArray17[index28] > 0 && this.data.SFTypeObj[index28].ReinforcementType == index27)
          {
            num6 += numArray17[index28];
            ++num7;
          }
        }
        if (num7 > 0)
        {
          this.ai.AddLog("");
          this.ai.AddLog("ReinfType " + this.data.ReinfName[index27] + " weighted prod costs:");
          float num8 = 1000f / (float) (int) Math.Round((double) num6 / (double) num7);
          int sfTypeCounter5 = this.data.SFTypeCounter;
          for (int index29 = 0; index29 <= sfTypeCounter5; ++index29)
          {
            if (numArray17[index29] > 0 && this.data.SFTypeObj[index29].ReinforcementType == index27)
            {
              numArray17[index29] = (int) Math.Round((double) ((float) numArray17[index29] * num8));
              if (numArray17[index29] > 1000)
                numArray17[index29] = 1000 + (int) Math.Round((double) (numArray17[index29] - 1000) / 1.4);
              if (numArray17[index29] > 1500)
                numArray17[index29] = 1500 + (int) Math.Round((double) (numArray17[index29] - 1500) / 1.7);
              if (numArray17[index29] > 2000)
                numArray17[index29] = 2000 + (int) Math.Round((double) (numArray17[index29] - 2000) / 2.0);
              if (numArray17[index29] > 2500)
                numArray17[index29] = 2500 + (int) Math.Round((double) (numArray17[index29] - 2500) / 2.5);
              if (numArray17[index29] > 3000)
                numArray17[index29] = 3000 + (int) Math.Round((double) (numArray17[index29] - 3000) / 3.0);
              if (numArray17[index29] > 4000)
                numArray17[index29] = 4000 + (int) Math.Round((double) (numArray17[index29] - 4000) / 4.0);
              if (numArray17[index29] > 5000)
                numArray17[index29] = 5000 + (int) Math.Round((double) (numArray17[index29] - 5000) / 6.0);
              int num9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData2(0, this.data.SFTypeObj[index29].SFTypeVar[81], 2, this.RegimeId, 9)));
              this.ai.AddLog("* " + this.data.SFTypeObj[index29].Name + "(Quality=" + num9.ToString() + ", Combat=" + numArray6[index29, 0].ToString() + ") = " + numArray17[index29].ToString());
            }
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("OOB RATINGS:");
      this.ai.AddLog("");
      SimpleList simpleList1 = new SimpleList();
      int length = this.data.StringListObj[this.slotRegimeOobs].Length;
      for (int index30 = 0; index30 <= length; ++index30)
      {
        int num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index30, 0]));
        string data = this.data.StringListObj[this.slotOobTypes].GetData(0, num10, 1);
        int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index30, 1]));
        int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index30, 4]));
        if (num11 == this.RegimeId && num12 >= 1)
        {
          int tdata1 = 5;
          do
          {
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            if (tdata1 == 5)
            {
              flag1 = true;
              flag2 = true;
              flag3 = true;
              flag4 = true;
            }
            if (tdata1 == 4)
            {
              flag1 = true;
              flag2 = true;
              flag3 = true;
              flag4 = false;
            }
            if (tdata1 == 3)
            {
              flag1 = true;
              flag2 = true;
              flag3 = false;
              flag4 = false;
            }
            if (tdata1 == 2)
            {
              flag1 = true;
              flag2 = false;
              flag3 = false;
              flag4 = false;
            }
            SimpleList reinfListForOob = DrawMod.TGame.EventRelatedObj.Helper_GetReinfListForOob(num10);
            EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
            SimpleList RL = reinfListForOob;
            int num13 = flag1 ? 1 : 0;
            int num14 = flag2 ? 1 : 0;
            int num15 = flag3 ? 1 : 0;
            int num16 = flag4 ? 1 : 0;
            int regimeId = this.RegimeId;
            SimpleList simpleList2 = (SimpleList) null;
            ref SimpleList local = ref simpleList2;
            SimpleList sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, num13 != 0, num14 != 0, num15 != 0, num16 != 0, regimeId, allowedSfTypeList: (ref local));
            if (sftypesForReinfList.Counter > -1)
            {
              int num17 = 0;
              int num18 = 0;
              int num19 = 0;
              int num20 = 0;
              int counter = sftypesForReinfList.Counter;
              for (int index31 = 0; index31 <= counter; ++index31)
              {
                num17 += sftypesForReinfList.Weight[index31];
                num18 += (int) Math.Round((double) sftypesForReinfList.Weight[index31] * (double) numArray6[sftypesForReinfList.Id[index31], 0] * 1000.0);
                num19 += sftypesForReinfList.Weight[index31];
                num20 += (int) Math.Round((double) (sftypesForReinfList.Weight[index31] * 1000000) / (double) numArray17[sftypesForReinfList.Id[index31]]);
              }
              if (num17 > 0 & num19 > 0)
              {
                int tweight = (int) Math.Round((double) num18 / (double) num17);
                int num21 = (int) Math.Round((double) num20 / (double) num19);
                int num22 = (int) Math.Round((double) (tweight * num21) / 1000.0);
                this.OobRatingList.Add(num10, tweight, tdata1, CheckExistence: false);
                this.ai.AddLog("#" + num10.ToString() + " : " + data + ", Qual=" + tdata1.ToString() + ". CombatRatio = " + tweight.ToString() + " ProdCost = " + num21.ToString() + ". SCORE = " + num22.ToString());
              }
            }
            tdata1 += -1;
          }
          while (tdata1 >= 2);
        }
      }
      this.ai.WriteLog(str);
    }

    public void BuyTechModelsOobs(ref Shadow_Economic_AI aiEconomic)
    {
      string str1 = "8502_AI_BuyTechModelsOobs";
      SimpleStringList simpleStringList = new SimpleStringList();
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
      SimpleList simpleList1 = new SimpleList();
      int tStage = 0;
      int counter1 = this.ShqList.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.ShqList.Data1[index] > tStage)
          tStage = this.ShqList.Data1[index];
      }
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "aiPoints", 2)));
      int length1 = this.data.StringListObj[this.slotZones].Length;
      int num3;
      int d1;
      for (int index = 0; index <= length1; ++index)
      {
        num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
        int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 6]));
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8])) == this.RegimeId && num4 > 0)
        {
          int num5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num3, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num3, 1, "worker", 2)));
          d1 += num5;
        }
      }
      int tweight1 = (int) Math.Round(Math.Sqrt((double) d1));
      int num6 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, "bp", 2)));
      int num7;
      if (num1 < 10)
      {
        tweight1 = (int) Math.Round((double) tweight1 / 4.0);
        num7 = (int) Math.Round((double) num6 / 2.0);
      }
      else if (num1 < 20)
      {
        tweight1 = (int) Math.Round((double) tweight1 / 2.0);
        num7 = num6;
      }
      else
        num7 = num6 + (int) Math.Round((double) (num6 * num1) / 40.0);
      int num8 = num2 + num7 + tweight1;
      this.ai.AddLog("totalPop= " + d1.ToString());
      this.ai.AddLog("aiPoints increase = " + tweight1.ToString());
      this.ai.AddLog("aiPoints = " + num8.ToString());
      this.ai.AddLog("Best SHQ stage = " + tStage.ToString());
      bool flag1 = false;
      if (((int) Math.Round((double) this.data.GameID / 1000.0 * (double) this.data.Turn) + this.data.Round) % 4 > 0)
        flag1 = true;
      if (DrawMod.TGame.SuperAdminRights)
        flag1 = false;
      if (flag1)
      {
        this.ai.AddLog(" ");
        this.ai.AddLog("---- Not this turn to save time! ---- saving aiPoints for next turn ----");
        this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "aiPoints", 2, num8, true);
        this.ai.WriteLog(str1);
      }
      else
      {
        this.data.StringListObj[this.slotFlagInstructions].SetData(0, "REGIMEID", 1, this.RegimeId, true);
        this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SOURCEREGIMEID", 1, this.RegimeId, true);
        this.data.StringListObj[this.slotFlagInstructions].SetData(0, "ROUND", 1, this.data.Round, true);
        bool flag2 = true;
        SimpleList weightedReinfLists = this.GetWeightedReinfLists(true);
        while (num8 > 0 & flag2)
        {
          this.ai.AddLog("");
          this.ai.AddLog("Assign weights...");
          flag2 = false;
          SimpleList simpleList2 = new SimpleList();
          int length2 = this.data.StringListObj[this.slotTechType].Length;
          int idValue1;
          int index1;
          for (int index2 = 0; index2 <= length2; ++index2)
          {
            int num9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].Data[index2, 0]));
            int num10 = 100;
            if (num9 == 4)
              index2 = index2;
            int num11 = 1;
            if (num9 > 0)
            {
              tweight1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].GetData2(0, num9, 1, this.RegimeId, 2)));
              if (tweight1 >= 100)
              {
                num11 = 0;
              }
              else
              {
                num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].GetData2(0, num9, 1, this.RegimeId, 2)));
                idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 6)));
                index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 2)));
                if (num9 == 20)
                  num3 = num3;
                if (index1 == 2)
                  index1 = index1;
                if (index1 == 3)
                  num11 = 0;
                else if (index1 < 3)
                {
                  int idValue2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 10)));
                  string data = this.data.StringListObj[this.slotTechType].GetData(0, num9, 7);
                  int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 16)));
                  tweight1 = 1;
                  if (idValue2 > 0)
                  {
                    int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].GetData2(0, idValue2, 1, this.RegimeId, 2)));
                    if (num13 < 1)
                    {
                      tweight1 = 0;
                    }
                    else
                    {
                      switch (num13)
                      {
                        case 1:
                          tweight1 = tweight1;
                          break;
                        case 2:
                          tweight1 = tweight1;
                          num10 = (int) Math.Round((double) num10 / 2.0);
                          break;
                      }
                    }
                  }
                  if (tweight1 > 0)
                  {
                    if (data.Length > 0)
                    {
                      int nr = simpleStringList.FindNr(data);
                      if (nr > -1)
                      {
                        tweight1 = simpleStringList.Weight[nr];
                      }
                      else
                      {
                        EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                        int id1 = this.data.StringListObj[this.slotFlags].ID;
                        int id2 = this.data.StringListObj[this.slotFlagInstructions].ID;
                        string logicString = data;
                        Random random = (Random) null;
                        ref Random local = ref random;
                        tweight1 = eventRelatedObj.CheckLogicStringStart(id1, id2, logicString, 0, ref local);
                        simpleStringList.Add(data, tweight1);
                      }
                    }
                    if (num12 > 0)
                    {
                      if (num12 > tStage + 2)
                        tweight1 = 0;
                      else if (num12 > tStage + 1)
                        num10 = (int) Math.Round((double) num10 / 9.0);
                      else if (num12 > tStage + 0)
                        num10 = (int) Math.Round((double) num10 / 3.0);
                    }
                    else if (index1 == 1)
                      tweight1 = 0;
                  }
                  if (tweight1 == 0)
                  {
                    num11 = 0;
                    num9 = 0;
                  }
                  else
                  {
                    if (index1 == 1 & idValue1 > 0)
                      num10 += (int) Math.Round((double) (num10 * num3) / (double) idValue1);
                    int num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 11)));
                    int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 12)));
                    int num16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 13)));
                    int num17 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 14)));
                    int num18 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 15)));
                    int itemNr1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 17)));
                    int itemNr2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 18)));
                    int num19 = 0;
                    if (this.data.StringListObj[this.slotTechType].Width >= 21)
                      num19 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, num9, 21)));
                    string tid = "";
                    if (this.data.StringListObj[this.slotTechType].Width >= 19)
                      tid = this.data.StringListObj[this.slotTechType].GetData(0, num9, 19);
                    if (num14 > 0)
                      num10 += (int) Math.Round((double) (num10 * 10) * ((double) this.pathTech_Military / 100.0) * ((double) num14 / 100.0));
                    if (num15 > 0)
                      num10 += (int) Math.Round((double) (num10 * 10) * ((double) this.pathTech_Economy / 100.0) * ((double) num15 / 100.0));
                    if (num16 > 0)
                      num10 += (int) Math.Round((double) (num10 * 10) * ((double) this.pathTech_Artillery / 100.0) * ((double) num16 / 100.0));
                    if (num17 > 0)
                      num10 += (int) Math.Round((double) (num10 * 10) * ((double) this.pathWar_Offensive / 100.0) * ((double) num17 / 100.0));
                    if (num18 > 0)
                      num10 += (int) Math.Round((double) (num10 * 10) * ((double) this.pathWar_Defensive / 100.0) * ((double) num18 / 100.0));
                    if (num14 < 1 & num15 < 1 & num16 < 1 & num17 < 1 & num18 < 1)
                      num10 *= 4;
                    if (itemNr1 > 0)
                    {
                      if ((double) (aiEconomic.itemNeed[itemNr1] + aiEconomic.GetMinimumProdForShortageCalcs(itemNr1)) <= 0.9 * (double) aiEconomic.itemProduction[itemNr1])
                        num10 = (int) Math.Round((double) num10 / 10.0);
                      else if ((double) (aiEconomic.itemNeed[itemNr1] + aiEconomic.GetMinimumProdForShortageCalcs(itemNr1)) > 1.3 * (double) aiEconomic.itemProduction[itemNr1])
                        num10 *= 5;
                    }
                    if (itemNr2 > 0)
                    {
                      if ((double) (aiEconomic.itemNeed[itemNr2] + aiEconomic.GetMinimumProdForShortageCalcs(itemNr2)) >= 0.85 * (double) aiEconomic.itemProduction[itemNr2])
                        num10 = (int) Math.Round((double) num10 / 10.0);
                      else if ((double) (aiEconomic.itemNeed[itemNr2] + aiEconomic.GetMinimumProdForShortageCalcs(itemNr2)) < 0.62 * (double) aiEconomic.itemProduction[itemNr2])
                        num10 *= 5;
                    }
                    if (tid.Length > 0)
                    {
                      int nr = simpleStringList.FindNr(tid);
                      int tweight2;
                      if (nr > -1)
                      {
                        tweight2 = simpleStringList.Weight[nr];
                      }
                      else
                      {
                        EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                        int id3 = this.data.StringListObj[this.slotFlags].ID;
                        int id4 = this.data.StringListObj[this.slotFlagInstructions].ID;
                        string logicString = tid;
                        Random random = (Random) null;
                        ref Random local = ref random;
                        tweight2 = eventRelatedObj.CheckLogicStringStart(id3, id4, logicString, 0, ref local);
                        simpleStringList.Add(tid, tweight2);
                      }
                      if (tweight2 > 0)
                        num10 *= 5;
                    }
                    if (this.ai.game.EventRelatedObj.Helper_AirEnabled())
                    {
                      switch (num19)
                      {
                        case 1:
                          num10 = (int) Math.Round((double) (num10 * this.Air_Economical_AirBased) / 100.0);
                          break;
                        case 2:
                          num10 = (int) Math.Round((double) (num10 * this.Air_Economical_RocketBased) / 100.0);
                          break;
                        case 3:
                          num10 = (int) Math.Round((double) (num10 * this.Air_Economical_ThopterBased) / 100.0);
                          break;
                        case 4:
                          num10 = (int) Math.Round((double) (num10 * Math.Max(this.Air_Economical_AirBased, this.Air_Economical_RocketBased)) / 100.0);
                          break;
                      }
                      if (num19 > 0 & !this.Air_Yes)
                        num10 = 0;
                    }
                  }
                }
              }
            }
            if (num11 == 1)
            {
              int num20 = (int) Math.Round((double) num10 * 0.33) + (int) Math.Round((double) num10 * 0.66 * (double) this.pathEco_American / 100.0);
              int tweight3;
              if (index1 == 1 & idValue1 > 0)
              {
                tweight3 = (int) Math.Round((double) num20 * 0.1) + (int) Math.Round((double) num20 * 0.9 * (double) num3 / (double) idValue1);
                if ((double) num3 > (double) idValue1 / 3.0)
                  tweight3 *= 2;
                if ((double) num3 > (double) idValue1 / 2.0)
                  tweight3 *= 2;
                if ((double) num3 > (double) idValue1 / 1.5)
                  tweight3 *= 2;
                if (num3 > 0)
                  tweight3 *= 2;
                if (num3 == 0)
                  tweight3 = (int) Math.Round((double) tweight3 / 2.0);
              }
              else
              {
                int num21 = (int) Math.Round((double) num20 * 0.01) + (int) Math.Round((double) num20 * 0.99 * (double) (100 - num3) / 100.0);
                int num22 = (int) Math.Round((double) num21 * 0.01) + (int) Math.Round((double) num21 * 0.99 * (double) (100 - num3) / 100.0);
                int num23 = (int) Math.Round((double) num22 * 0.01) + (int) Math.Round((double) num22 * 0.99 * (double) (100 - num3) / 100.0);
                tweight3 = (int) Math.Round((double) ((int) Math.Round((double) num23 * 0.01) + (int) Math.Round((double) num23 * 0.99 * (double) (100 - num3) / 100.0)) / 4.0);
                if (tStage <= 3)
                  tweight3 = (int) Math.Round((double) tweight3 / 8.0);
                else if (tStage <= 4)
                  tweight3 = (int) Math.Round((double) tweight3 / 4.0);
                else if (tStage <= 5)
                  tweight3 = (int) Math.Round((double) tweight3 / 2.0);
              }
              this.ai.AddLog("TECH " + this.data.StringListObj[this.slotTechType].GetData(0, num9, 1) + "' (id " + num9.ToString() + ") gets weight: " + tweight3.ToString());
              simpleList2.Add(num9, tweight3, 1, CheckExistence: false);
            }
          }
          SimpleList simpleList3 = new SimpleList();
          int num24 = 0;
          int unitCounter = this.data.UnitCounter;
          for (int index3 = 0; index3 <= unitCounter; ++index3)
          {
            if (this.data.UnitObj[index3].Regime == this.data.Turn & this.data.UnitObj[index3].PreDef == -1)
            {
              int sfCount = this.data.UnitObj[index3].SFCount;
              for (int index4 = 0; index4 <= sfCount; ++index4)
              {
                int sf = this.data.UnitObj[index3].SFList[index4];
                tweight1 = this.data.SFObj[sf].Type;
                int qty = this.data.SFObj[sf].Qty;
                int tid = this.data.SFTypeObj[tweight1].SFTypeVar[81];
                if (tid > 0)
                {
                  simpleList3.AddWeight(tid, qty);
                  num24 += qty;
                }
              }
            }
          }
          if (num24 > 0)
          {
            int counter2 = simpleList3.Counter;
            for (int index5 = 0; index5 <= counter2; ++index5)
              simpleList3.Weight[index5] = (int) Math.Round((double) (100 * simpleList3.Weight[index5]) / (double) num24);
          }
          int length3 = this.data.StringListObj[this.slotModelTypes].Length;
          int num25;
          for (int index6 = 0; index6 <= length3; ++index6)
          {
            string str2 = this.data.StringListObj[this.slotModelTypes].Data[index6, 1];
            num25 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].Data[index6, 0]));
            int num26 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].Data[index6, 18]));
            int num27 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].Data[index6, 19]));
            int num28 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].Data[index6, 20]));
            if (num25 >= 132 & num25 <= 133)
              num25 = num25;
            int num29 = -1;
            int num30 = -1;
            bool flag3 = false;
            int num31 = 1000;
            bool flag4 = false;
            if (num28 > 0)
            {
              int length4 = this.data.StringListObj[this.slotRegimeModels].Length;
              for (int index7 = 0; index7 <= length4; ++index7)
              {
                index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index7, 2]));
                if (index1 == this.RegimeId)
                {
                  idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index7, 1]));
                  if (idValue1 == num25)
                  {
                    num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index7, 0]));
                    int num32 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index7, 4]));
                    if (num32 > num29)
                    {
                      num29 = num32;
                      num30 = num3;
                    }
                  }
                }
              }
              if (num30 > -1)
              {
                flag4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num30, 7))) < (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num30, 8)));
              }
              else
              {
                int tweight4 = 1;
                string tid = this.data.StringListObj[this.slotModelTypes].Data[index6, 6];
                if (tid.Length > 0)
                {
                  int nr = simpleStringList.FindNr(tid);
                  if (nr > -1)
                  {
                    tweight4 = simpleStringList.Weight[nr];
                  }
                  else
                  {
                    EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                    int id5 = this.data.StringListObj[this.slotFlags].ID;
                    int id6 = this.data.StringListObj[this.slotFlagInstructions].ID;
                    string logicString = tid;
                    Random random = (Random) null;
                    ref Random local = ref random;
                    tweight4 = eventRelatedObj.CheckLogicStringStart(id5, id6, logicString, 0, ref local);
                    simpleStringList.Add(tid, tweight4);
                  }
                }
                flag3 = tweight4 == 1;
                int num33 = flag3 ? 1 : 0;
              }
            }
            if (num28 <= tStage & num28 > 0)
            {
              if (num26 > 0)
                num31 += (int) Math.Round((double) num31 * 0.1) + (int) Math.Round((double) num31 * 0.9 * 5.0 * ((double) num26 / 100.0) * ((double) this.pathWar_Offensive / 100.0));
              if (num27 > 0)
                num31 += (int) Math.Round((double) num31 * 0.1) + (int) Math.Round((double) num31 * 0.9 * 5.0 * ((double) num27 / 100.0) * ((double) this.pathWar_Defensive / 100.0));
              int tweight5 = (int) Math.Round((double) num31 * 0.33) + (int) Math.Round((double) num31 * 0.66 * ((double) (this.pathEco_Soviet + this.pathEco_American) / 2.0) / 100.0);
              if (!flag3 & num30 < 1)
              {
                tweight5 = 0;
              }
              else
              {
                if (flag3)
                  tweight5 = tweight5 * 4 * num28;
                else if (flag4)
                  tweight5 = tweight5 * 20 * num28;
                else if (num30 > 0)
                {
                  int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num30, 5)));
                  int num34 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num30, 10)));
                  DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id);
                  int num35 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelHistory].GetData2(0, num30, 1, 7, 2)));
                  tweight1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelHistory].GetData2(0, num30, 1, 8, 2)));
                  int num36 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num30, 4)));
                  if (num36 > 1)
                    tweight1 += 10 * (num36 - 1);
                  int num37 = 120 + num36 * 10;
                  if (num36 > 1)
                    ;
                  int val1 = 100 - (int) Math.Round((double) (100 * (num37 - num35)) / (double) (num37 - tweight1));
                  int num38 = this.data.Round - num34;
                  int weight = simpleList3.FindWeight(num30);
                  int val2 = weight <= 40 ? (weight <= 25 ? (weight <= 17 ? (weight <= 10 ? (weight <= 5 ? (weight <= 2 ? 0 : num38) : num38 * 2) : num38 * 3) : num38 * 4) : num38 * 5) : num38 * 6;
                  if (val1 < (int) Math.Round((double) val2 * 0.66))
                    val1 = (int) Math.Round((double) val2 * 0.66);
                  int num39 = Math.Min(val1, val2);
                  if (num39 > 100)
                    num39 = 100;
                  if (num39 >= 100)
                    tweight5 *= 2;
                  if (num39 <= 20)
                    tweight5 = (int) Math.Round((double) tweight5 / 24.0);
                  if (num39 <= 40)
                    tweight5 = (int) Math.Round((double) tweight5 / 14.0);
                  if (num39 <= 60)
                    tweight5 = (int) Math.Round((double) tweight5 / 9.0);
                  if (num39 <= 80)
                    tweight5 = (int) Math.Round((double) tweight5 / 5.0);
                  if (num39 <= 90)
                    tweight5 = (int) Math.Round((double) tweight5 / 2.0);
                  if (num39 <= 100)
                    tweight5 = (int) Math.Round((double) tweight5 / 1.5);
                  if (num39 > 20 & tweight5 > 0)
                    num39 = num39;
                  tweight5 = (int) Math.Round((double) (tweight5 * num39) / 100.0);
                }
                if (this.ai.game.EventRelatedObj.Helper_AirEnabled())
                {
                  if (num25 == 107 | num25 == 108)
                    tweight5 = 0;
                  if (num25 >= 101 & num25 <= 129)
                  {
                    int num40 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 350, 1, this.RegimeId, 2)));
                    int num41 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 355, 1, this.RegimeId, 2)));
                    int num42 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 359, 1, this.RegimeId, 2)));
                    if (num25 >= 101 & num25 <= 109 & num40 < 100)
                      tweight5 = 0;
                    if (num25 >= 111 & num25 <= 119 & num41 < 100)
                      tweight5 = 0;
                    if (num25 >= 121 & num25 <= 129 & num42 < 100)
                      tweight5 = 0;
                  }
                  if (num25 >= 101 & num25 <= 129 && !this.Air_Yes)
                    tweight5 = 0;
                  if (num25 == 111 | num25 == 121 && (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeModels].GetData2(1, 103, 2, this.RegimeId, 5))) < 1 & (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeModels].GetData2(1, 104, 2, this.RegimeId, 5))) < 1)
                    tweight5 = (int) Math.Round((double) tweight5 / 10.0);
                  if (num25 >= 111 & num25 <= 119 && (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeModels].GetData2(1, 121, 2, this.RegimeId, 5))) > 0 | (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeModels].GetData2(1, 122, 2, this.RegimeId, 5))) > 0)
                    tweight5 = (int) Math.Round((double) tweight5 / 10.0);
                  if (this.Air_Economical_ThopterBased < 50 & num25 >= 111 & num25 <= 129)
                    tweight5 = 0;
                }
              }
              if (tweight5 > 0)
              {
                this.ai.AddLog("MODELTYPE " + this.data.StringListObj[this.slotModelTypes].GetData(0, num25, 1) + "' (id " + num25.ToString() + "), bestVersion=" + num29.ToString() + ", in Progress=" + flag4.ToString() + " gets weight: " + tweight5.ToString());
                if (this.ai.game.EventRelatedObj.Helper_AirEnabled() && num25 == 102 & simpleList2.FindNr(101, 2) > -1)
                  simpleList2.RemoveNr(simpleList2.FindNr(101, 2));
                simpleList2.Add(num25, tweight5, 2, CheckExistence: false);
              }
            }
          }
          SimpleList SL1 = weightedReinfLists.Clone();
          if (SL1.Counter > -1)
          {
            int[,] numArray = new int[6000, 21];
            int length5 = this.data.StringListObj[this.slotToeTypes].Length;
            for (int index8 = 0; index8 <= length5; ++index8)
            {
              int index9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotToeTypes].Data[index8, 0]));
              int index10 = 7;
              do
              {
                num25 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotToeTypes].Data[index8, index10]));
                numArray[index9, index10] = num25;
                index10 += 2;
              }
              while (index10 <= 17);
            }
            int num43 = 0;
            SL1 = this.Helper_PercentifySL(ref SL1);
            SimpleList simpleList4 = new SimpleList();
            SimpleList simpleList5 = new SimpleList();
            int length6 = this.data.StringListObj[this.slotRegimeModels].Length;
            for (int index11 = 0; index11 <= length6; ++index11)
            {
              index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index11, 2]));
              if (index1 == this.RegimeId)
              {
                idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index11, 1]));
                if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index11, 7])) >= (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index11, 8])))
                {
                  int id = this.data.ReinfLibId[(int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, idValue1, 9)))].id;
                  if (id > -1)
                    simpleList4.Add(id, 1);
                }
              }
            }
            int length7 = this.data.StringListObj[this.slotOobTypes].Length;
            for (int index12 = 0; index12 <= length7; ++index12)
            {
              num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index12, 0]));
              int num44 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index12, 3]));
              int num45 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index12, 4]));
              if (num3 < 100)
                num3 = num3;
              if (num45 < 1 & num44 == num3)
              {
                if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num3, 1, this.RegimeId, 4))) < 1)
                {
                  int num46 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num3, 1, this.RegimeId, 5)));
                  int num47 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num3, 1, this.RegimeId, 6)));
                  if (num46 < num47 & num46 > 0)
                  {
                    int tweight6 = 400;
                    if ((double) num46 > (double) num47 * 0.3)
                      tweight6 *= 2;
                    if ((double) num46 > (double) num47 * 0.6)
                      tweight6 *= 2;
                    if ((double) num46 > (double) num47 * 0.8)
                      tweight6 *= 2;
                    simpleList5.Add(num3, tweight6);
                  }
                  else
                    simpleList5.Add(num3, 30);
                }
                else
                  ++num43;
              }
            }
            int counter3 = simpleList4.Counter;
            for (int index13 = 0; index13 <= counter3; ++index13)
            {
              SimpleList simpleList6 = new SimpleList();
              int length8 = this.data.StringListObj[this.slotOobTypes].Length;
              for (int index14 = 0; index14 <= length8; ++index14)
              {
                num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index14, 0]));
                int num48 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index14, 3]));
                if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index14, 4])) < 1 & num48 == num3)
                {
                  SimpleList simpleList7 = new SimpleList();
                  int index15 = 12;
                  do
                  {
                    idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index14, index15]));
                    if (idValue1 > 0)
                    {
                      int index16 = 7;
                      do
                      {
                        num25 = numArray[idValue1, index16];
                        if (num25 > 0)
                          simpleList7.AddWeight(num25, 1);
                        index16 += 2;
                      }
                      while (index16 <= 17);
                    }
                    ++index15;
                  }
                  while (index15 <= 21);
                  if (simpleList7.FindNr(simpleList4.Id[index13]) > -1)
                    simpleList6.Add(num3, simpleList7.Counter);
                }
              }
              if (simpleList6.Counter > -1)
              {
                simpleList6.SortHighSpeed();
                int num49 = simpleList6.Id[0];
                if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num49, 1, this.RegimeId, 4))) < 1)
                {
                  simpleList5.AddWeight(num49, 200);
                  this.ai.AddLog("Doesn't have simpelest OOB#" + num49.ToString() + " yet.");
                }
              }
            }
            for (int counter4 = simpleList5.Counter; counter4 >= 0; counter4 += -1)
            {
              string data = this.data.StringListObj[this.slotOobTypes].GetData(0, simpleList5.Id[counter4], 5);
              int tweight7 = 1;
              if (data.Length > 0)
              {
                int nr = simpleStringList.FindNr(data);
                if (nr > -1)
                {
                  tweight7 = simpleStringList.Weight[nr];
                }
                else
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  int id7 = this.data.StringListObj[this.slotFlags].ID;
                  int id8 = this.data.StringListObj[this.slotFlagInstructions].ID;
                  string logicString = data;
                  Random random = (Random) null;
                  ref Random local = ref random;
                  tweight7 = eventRelatedObj.CheckLogicStringStart(id7, id8, logicString, 0, ref local);
                  simpleStringList.Add(data, tweight7);
                }
              }
              if (tweight7 < 1)
                simpleList5.RemoveNr(counter4);
            }
            int num50 = SL1.FindWeight(26) + SL1.FindWeight(37) + SL1.FindWeight(38) + SL1.FindWeight(55);
            int num51 = SL1.FindWeight(29) + SL1.FindWeight(30) + SL1.FindWeight(44) + SL1.FindWeight(46) + SL1.FindWeight(45) + (SL1.FindWeight(39) + SL1.FindWeight(48));
            int num52 = SL1.FindWeight(28) + SL1.FindWeight(47) + SL1.FindWeight(49) + SL1.FindWeight(50) + SL1.FindWeight(56) + SL1.FindWeight(57);
            if (num50 < 1)
              num50 = 1;
            if (num51 < 1)
              num51 = 1;
            if (num52 < 1)
              num52 = 1;
            float num53 = 100f / (float) (num51 + num52 + num50);
            int num54 = (int) Math.Round((double) ((float) num51 * num53));
            int num55 = (int) Math.Round((double) ((float) num50 * num53));
            int num56 = (int) Math.Round((double) ((float) num52 * num53));
            int counter5 = simpleList5.Counter;
            for (int index17 = 0; index17 <= counter5; ++index17)
            {
              num3 = simpleList5.Id[index17];
              SimpleList SL2 = new SimpleList();
              index1 = (int) Math.Round(Conversion.Val((object) this.data.StringListObj[this.slotOobTypes].FindRow(0, num3)));
              if (index1 > -1)
              {
                int index18 = 12;
                do
                {
                  idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index1, index18]));
                  if (idValue1 > 0)
                  {
                    int index19 = 7;
                    do
                    {
                      num25 = numArray[idValue1, index19];
                      if (num25 > 0)
                        SL2.AddWeight(num25, 1);
                      index19 += 2;
                    }
                    while (index19 <= 17);
                  }
                  ++index18;
                }
                while (index18 <= 21);
              }
              SL2 = this.Helper_PercentifySL_Real(ref SL2);
              int num57 = 1000;
              if (SL2.FindWeight(26) > 0)
              {
                int num58 = (int) Math.Round((double) ((int) Math.Round((double) (1000 * this.pathWar_Defensive) / 50.0) * this.pathWar_Defensive) / 50.0);
                num57 = (int) Math.Round((double) (num57 * num58 * SL2.FindWeight(26)) / 100000.0);
              }
              if (SL2.FindWeight(37) > 0)
              {
                int num59 = (int) Math.Round((double) (1000 * num55) / 40.0);
                num57 = (int) Math.Round((double) (num57 * num59 * SL2.FindWeight(37)) / 100000.0);
              }
              if (SL2.FindWeight(38) > 0)
              {
                int num60 = (int) Math.Round((double) (1000 * num54) / 20.0);
                num57 = (int) Math.Round((double) (num57 * num60 * SL2.FindWeight(38)) / 100000.0);
              }
              if (SL2.FindWeight(28) > 0)
              {
                int num61 = (int) Math.Round((double) (1000 * num55) / 50.0);
                num57 = (int) Math.Round((double) (num57 * num61 * SL2.FindWeight(28)) / 100000.0);
              }
              if (SL2.FindWeight(27) > 0)
              {
                int num62 = (int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round(1000.0 * Math.Min(2.0, 10.0 / (double) num56)) * this.pathWar_Offensive) / 50.0) * 30) / (double) this.pathWar_Defensive);
                num57 = (int) Math.Round((double) (num57 * num62 * SL2.FindWeight(27)) / 100000.0);
              }
              if (SL2.FindWeight(34) > 0)
              {
                int num63 = (int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round(1000.0 * Math.Min(3.0, (double) num56 / 10.0)) * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * 30) / (double) this.pathWar_Defensive) * 30) / (double) this.pathWar_Defensive);
                num57 = (int) Math.Round((double) (num57 * num63 * SL2.FindWeight(34)) / 100000.0);
              }
              if (SL2.FindWeight(29) > 0)
              {
                int num64 = (int) Math.Round((double) (int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round((double) (1000 * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * Math.Min(1.0, 10.0 / (double) num54));
                num57 = (int) Math.Round((double) (num57 * num64 * SL2.FindWeight(29)) / 100000.0);
              }
              if (SL2.FindWeight(30) > 0)
              {
                int num65 = (int) Math.Round((double) (int) Math.Round(1000.0 * Math.Min(2.0, (double) num56 / 10.0)) * Math.Min(1.0, (double) num54 / 20.0));
                num57 = (int) Math.Round((double) (num57 * num65 * SL2.FindWeight(30)) / 100000.0);
              }
              if (SL2.FindWeight(44) > 0)
              {
                int num66 = (int) Math.Round((double) (int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round((double) ((int) Math.Round((double) (1000 * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * this.pathWar_Offensive) / 50.0) * Math.Min(1.0, (double) num54 / 20.0));
                num57 = (int) Math.Round((double) (num57 * num66 * SL2.FindWeight(44)) / 100000.0);
              }
              if (SL2.FindWeight(30) > 0)
              {
                int num67 = (int) Math.Round((double) ((int) Math.Round((double) (int) Math.Round(1000.0 * Math.Min(2.0, 10.0 / (double) num56)) * Math.Min(1.0, 40.0 / (double) num54)) * this.pathWar_Defensive) / 50.0);
                num57 = (int) Math.Round((double) (num57 * num67 * SL2.FindWeight(30)) / 100000.0);
              }
              if (simpleList5.Weight[index17] > 0)
                simpleList5.Weight[index17] = (int) Math.Round((double) (simpleList5.Weight[index17] * num57) / 1000.0);
            }
            int num68 = 0;
            tweight1 = 0;
            int counter6 = simpleList5.Counter;
            for (int index20 = 0; index20 <= counter6; ++index20)
            {
              if (simpleList5.Weight[index20] > num68)
                num68 = simpleList5.Weight[index20];
            }
            int counter7 = simpleList5.Counter;
            for (int index21 = 0; index21 <= counter7; ++index21)
              simpleList5.Weight[index21] = (int) Math.Round((double) (100 * simpleList5.Weight[index21]) / (double) num68);
            int counter8 = simpleList5.Counter;
            for (int index22 = 0; index22 <= counter8; ++index22)
            {
              string data = this.data.StringListObj[this.slotOobTypes].GetData(0, simpleList5.Id[index22], 1);
              if (simpleList5.Weight[index22] > 0 & simpleList5.Data1[index22] < 1)
              {
                int tweight8 = simpleList5.Weight[index22];
                tweight1 = 2;
                int round = this.data.Round;
                tweight1 += (int) Math.Round((double) Math.Min(30, round) / 8.0);
                int val2 = round - 30;
                if (val2 > 0)
                  tweight1 += (int) Math.Round((double) Math.Min(100, val2) / 12.0);
                int num69 = val2 - 100;
                if (num69 > 0)
                  tweight1 += (int) Math.Round((double) num69 / 20.0);
                if (num43 > tweight1)
                  tweight8 = 0;
                if (tweight8 < 10)
                  tweight8 = 0;
                if (tweight8 > 0)
                {
                  this.ai.AddLog("OOB Candidate = OOB#" + simpleList5.Id[index22].ToString() + ": " + data + " gets weight=" + tweight8.ToString() + ".");
                  simpleList2.Add(simpleList5.Id[index22], tweight8, 3, CheckExistence: false);
                }
              }
            }
          }
          if (simpleList2.Counter > -1)
            flag2 = true;
          simpleList2.removeWeight0orLower();
          if (simpleList2.Counter == -1)
            flag2 = false;
          if (simpleList2.Counter > -1)
          {
            this.ai.AddLog("");
            this.ai.AddLog("PICK RANDOM ITEM based on weight...");
            int onWeightWithSeed = simpleList2.GetRandomSlotbasedOnWeightWithSeed((object) (3882 * this.data.Round * this.data.Turn));
            int idValue3;
            string logicString;
            int num70;
            int num71;
            int num72;
            int num73;
            int num74;
            int num75;
            int num76;
            int num77;
            int num78;
            if (onWeightWithSeed == -1)
            {
              idValue3 = 0;
              logicString = "";
              num70 = 0;
              num71 = 0;
              num72 = 0;
              num73 = 0;
              num74 = 0;
              num75 = 0;
              num76 = 0;
              num77 = 0;
              num78 = 0;
            }
            else if (simpleList2.Data1[onWeightWithSeed] == 1)
            {
              idValue3 = simpleList2.Id[onWeightWithSeed];
              logicString = "";
              num70 = 0;
              num71 = 0;
              num72 = 0;
              num73 = 0;
              num74 = 0;
              num75 = 0;
              num76 = 0;
              num77 = 0;
              num78 = 0;
            }
            else if (simpleList2.Data1[onWeightWithSeed] == 2)
            {
              idValue3 = 0;
              logicString = "";
              num70 = simpleList2.Id[onWeightWithSeed];
              num71 = 0;
              num72 = 0;
              num73 = 0;
              num74 = 0;
              num75 = 0;
              num76 = 0;
              num77 = 0;
              num78 = 0;
            }
            else if (simpleList2.Data1[onWeightWithSeed] == 3)
            {
              idValue3 = 0;
              logicString = "";
              num70 = 0;
              num71 = simpleList2.Id[onWeightWithSeed];
              num72 = 0;
              num73 = 0;
              num74 = 0;
              num75 = 0;
              num76 = 0;
              num77 = 0;
              num78 = 0;
            }
            else
            {
              int index23 = simpleList2.Id[onWeightWithSeed];
              idValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiTech].Data[index23, 1]));
              num70 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiTech].Data[index23, 2]));
              num71 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiTech].Data[index23, 3]));
              num72 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiTech].Data[index23, 4]));
              num73 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiTech].Data[index23, 5]));
              num74 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiTech].Data[index23, 9]));
              num75 = 0;
              num76 = 0;
              num77 = 0;
              num78 = 0;
              logicString = this.data.StringListObj[this.slotAiTech].Data[index23, 7];
            }
            int num79 = Math.Min(10, num8);
            int setValue1;
            if (idValue3 > 0)
            {
              setValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeTech].GetData2(0, idValue3, 1, this.RegimeId, 2)));
              int val2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, idValue3, 6)));
              index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotTechType].GetData(0, idValue3, 2)));
              int num80 = 0;
              if (index1 == 1)
              {
                num80 = (int) Math.Round(100.0 * ((double) num79 / (double) val2));
                if (num80 == 0 & DrawMod.RandyNumber.Next(0, Math.Max(1, (int) Math.Round((double) val2 / 100.0))) < num79)
                  num80 = 1;
              }
              else
              {
                int num81 = setValue1;
                int num82 = num79;
                for (int index24 = 1; index24 <= num82; ++index24)
                {
                  if (DrawMod.RandyNumber.Next(1, Math.Max(1, val2)) == 1 && DrawMod.RandyNumber.Next(0, 101) > num81 && DrawMod.RandyNumber.Next(0, 101) > num81)
                  {
                    ++num80;
                    ++num81;
                  }
                }
              }
              setValue1 += num80;
              this.ai.AddLog("Gained " + num80.ToString() + " pts on tech '" + this.data.StringListObj[this.slotTechType].GetData(0, idValue3, 1) + "' (id " + idValue3.ToString() + ") , now has: " + setValue1.ToString());
              if (setValue1 >= 100)
              {
                setValue1 = 100;
                if (logicString.Length > 0)
                  DrawMod.TGame.EventRelatedObj.ExecSetLogic(this.data.StringListObj[this.slotFlags].ID, this.data.StringListObj[this.slotFlagInstructions].ID, logicString, 0, "");
                this.ai.AddLog("Research finished on tech id " + idValue3.ToString());
              }
              this.data.StringListObj[this.slotRegimeTech].SetData2(0, idValue3, 1, this.RegimeId, 2, setValue1, true);
            }
            int num83;
            int num84;
            if (num70 > 0)
            {
              if (this.data.StringListObj[this.slotRegimeModels].Width <= 10)
                this.data.StringListObj[this.slotRegimeModels].AddCol(this.data.StringListObj[this.slotRegimeModels].Width, "AI notes");
              int num85 = 0;
              int IfUpgradeModelId = 0;
              int num86 = 0;
              int num87 = 0;
              int num88 = -1;
              int num89 = 0;
              int num90 = 0;
              int num91 = -1;
              int length9 = this.data.StringListObj[this.slotRegimeModels].Length;
              for (int index25 = 0; index25 <= length9; ++index25)
              {
                num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 0]));
                idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 1]));
                index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 2]));
                int num92 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 4]));
                int num93 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 6]));
                int num94 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 7]));
                int num95 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 8]));
                int num96 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index25, 11]));
                if (index1 == this.RegimeId)
                {
                  if (num92 == 1 & idValue1 == num70)
                    ++num86;
                  if (num96 > 0)
                  {
                    if (num92 > num89 & idValue1 == num70)
                    {
                      if (num92 == 1)
                        num91 = num3;
                      num89 = num92;
                      num90 = num3;
                    }
                    if (num94 < num95 & idValue1 == num70)
                      num87 = num3;
                  }
                  else
                  {
                    if (num92 > num85 & idValue1 == num70)
                    {
                      if (num92 == 1)
                        num88 = num3;
                      num85 = num92;
                      IfUpgradeModelId = num3;
                    }
                    if (num94 < num95 & idValue1 == num70)
                      num87 = num3;
                  }
                }
              }
              int num97 = -1;
              if (num87 < 1)
              {
                num97 = this.data.StringListObj[this.slotRegimeModels].GetHighestValue(0);
                if (num97 < 0)
                  num97 = 0;
                int modelCost = DrawMod.TGame.EventRelatedObj.Helper_GetModelCost(num70, num85 > 0, IfUpgradeModelId, DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].id);
                ++num97;
                int num98 = 1;
                if (num85 > num89)
                {
                  if (num89 > 0)
                    num98 = num89 + 1;
                  StringListClass stringListClass = this.data.StringListObj[this.slotRegimeModels];
                  string s0 = num97.ToString();
                  string s1 = num70.ToString();
                  string s2 = this.RegimeId.ToString();
                  num83 = num89 + 1;
                  string s4 = num83.ToString();
                  string s5 = 0.ToString();
                  string s6 = num91.ToString();
                  num84 = 0;
                  string s7 = num84.ToString();
                  string s8 = modelCost.ToString();
                  stringListClass.AddRowWithData(s0, s1, s2, s4: s4, s5: s5, s6: s6, s7: s7, s8: s8, s9: "0", s10: "0", s11: "1");
                  this.ai.AddLog("Added a new CHEAP model project of modelType id " + num70.ToString());
                }
                else
                {
                  if (num85 > 0)
                    num98 = num85 + 1;
                  StringListClass stringListClass = this.data.StringListObj[this.slotRegimeModels];
                  string s0 = num97.ToString();
                  string s1 = num70.ToString();
                  string s2 = this.RegimeId.ToString();
                  num84 = num85 + 1;
                  string s4 = num84.ToString();
                  string s5 = 0.ToString();
                  string s6 = num88.ToString();
                  num83 = 0;
                  string s7 = num83.ToString();
                  string s8 = modelCost.ToString();
                  stringListClass.AddRowWithData(s0, s1, s2, s4: s4, s5: s5, s6: s6, s7: s7, s8: s8, s9: "0", s10: "0", s11: "0");
                  this.ai.AddLog("Added a new CUTTING-EDGE model project of modelType id " + num70.ToString());
                }
                num87 = num97;
              }
              if (num87 > 0)
              {
                int num99 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num87, 4)));
                int num100 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num87, 7)));
                int num101 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num87, 8)));
                int num102 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].GetData(0, num87, 11)));
                int setValue2 = num100 + num79 * 2;
                if (setValue2 >= num101)
                  setValue2 = num101;
                this.ai.AddLog("Added pts to new model project of modelType id " + num70.ToString() + ".. now " + setValue2.ToString() + " of " + num101.ToString() + ".");
                this.data.StringListObj[this.slotRegimeModels].SetData(0, num87, 7, setValue2);
                if (setValue2 >= num101)
                {
                  bool lowBudgetVersion = false;
                  if (num102 > 0)
                    lowBudgetVersion = true;
                  int num103 = 0;
                  int num104 = 0;
                  int num105 = 0;
                  int choice4 = 0;
                  int choice5 = 0;
                  int choice6 = 0;
                  int choice7 = 0;
                  SimpleList simpleList8 = !(num70 >= 101 & num70 <= 129) ? this.ModelsChoicesForAI(num70, ref aiEconomic, lowBudgetVersion, tStage) : this.ModelsChoicesForAI_Air(num70, ref aiEconomic, lowBudgetVersion, tStage);
                  int counter9 = simpleList8.Counter;
                  for (int index26 = 0; index26 <= counter9; ++index26)
                  {
                    if (simpleList8.Id[index26] == 1)
                      num103 = simpleList8.Weight[index26];
                    if (simpleList8.Id[index26] == 2)
                      num104 = simpleList8.Weight[index26];
                    if (simpleList8.Id[index26] == 3)
                      num105 = simpleList8.Weight[index26];
                    if (simpleList8.Id[index26] == 4)
                      choice4 = simpleList8.Weight[index26];
                    if (simpleList8.Id[index26] == 5)
                      choice5 = simpleList8.Weight[index26];
                    if (simpleList8.Id[index26] == 6)
                      choice6 = simpleList8.Weight[index26];
                    if (simpleList8.Id[index26] == 7)
                      choice7 = simpleList8.Weight[index26];
                  }
                  if (num70 >= 101 & num70 <= 129)
                  {
                    SimpleList viableNewAirModel = this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(num70, this.RegimeId, num103, num104, num105, choice4, choice5, choice6, choice7, 16, true, true);
                    if (viableNewAirModel.Weight[0] < 1)
                      viableNewAirModel = this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(num70, this.RegimeId, num103, num104, num105, choice4, choice5, choice6, choice7, 12, true, true);
                    if (viableNewAirModel.Weight[0] < 1)
                      viableNewAirModel = this.ai.game.EventRelatedObj.Helper_GetViableNewAirModel(num70, this.RegimeId, num103, num104, num105, choice4, choice5, choice6, choice7, checkChoiceAllowed: true, bestFighterNudge: true);
                    if (viableNewAirModel.Weight[0] >= 1)
                    {
                      int choice1id = viableNewAirModel.Weight[0];
                      int choice2id = viableNewAirModel.Weight[1];
                      int choice3id = viableNewAirModel.Weight[2];
                      int choice4id = viableNewAirModel.Weight[3];
                      int choice5id = viableNewAirModel.Weight[4];
                      int choice6id = viableNewAirModel.Weight[5];
                      int choice7id = viableNewAirModel.Weight[6];
                      DrawMod.TGame.EventRelatedObj.Helper_NewModel(num87, choice1id, choice2id, choice3id, this.RegimeId, choice4id, choice5id, choice6id, choice7id);
                    }
                  }
                  else
                    DrawMod.TGame.EventRelatedObj.Helper_NewModel(num87, num103, num104, num105, this.RegimeId);
                  if (logicString.Length > 0)
                    DrawMod.TGame.EventRelatedObj.ExecSetLogic(this.data.StringListObj[this.slotFlags].ID, this.data.StringListObj[this.slotFlagInstructions].ID, logicString, 0, "");
                  this.ai.AddLog("Finished modelType id " + num70.ToString());
                }
              }
            }
            if (num71 > 0)
            {
              int num106 = -1;
              int length10 = this.data.StringListObj[this.slotRegimeOobs].Length;
              for (int index27 = 0; index27 <= length10; ++index27)
              {
                num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index27, 0]));
                idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index27, 1]));
                if (num3 == num71 & idValue1 == this.RegimeId)
                {
                  index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index27, 2]));
                  int num107 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].Data[index27, 4]));
                  if (index1 == 1 & num107 < 1)
                  {
                    num106 = index27;
                    break;
                  }
                }
              }
              if (num106 == -1)
              {
                int num108 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, num71, 11)));
                int d2 = (int) Math.Round((double) this.data.StringListObj[this.slotRegimeOobs].GetData2Count(1, this.RegimeId, 4, 1) / 10.0);
                if (d2 < 1)
                  d2 = 1;
                int setValue3 = (int) Math.Round((double) num108 * Math.Sqrt((double) d2));
                this.data.StringListObj[this.slotRegimeOobs].SetData2(0, num71, 1, this.RegimeId, 5, 0, true);
                this.data.StringListObj[this.slotRegimeOobs].SetData2(0, num71, 1, this.RegimeId, 2, 1, true);
                this.data.StringListObj[this.slotRegimeOobs].SetData2(0, num71, 1, this.RegimeId, 6, setValue3, true);
                num106 = this.data.StringListObj[this.slotRegimeOobs].FindRow2(0, num71, 1, this.RegimeId);
                this.ai.AddLog("Started research on OobType id " + num71.ToString());
              }
              if (num106 > -1)
              {
                if (logicString.Length > 0)
                  DrawMod.TGame.EventRelatedObj.ExecSetLogic(this.data.StringListObj[this.slotFlags].ID, this.data.StringListObj[this.slotFlagInstructions].ID, logicString, 0, "");
                setValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num71, 1, this.RegimeId, 5)));
                int num109 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeOobs].GetData2(0, num71, 1, this.RegimeId, 6)));
                setValue1 += num79 * 4;
                if (setValue1 > num109)
                  setValue1 = num109;
                this.ai.AddLog("oobType id " + num71.ToString() + " research now at " + setValue1.ToString() + " of " + num109.ToString());
                this.data.StringListObj[this.slotRegimeOobs].SetData2(0, num71, 1, this.RegimeId, 5, setValue1);
                if (setValue1 >= num109)
                {
                  this.ai.AddLog("Finished OobType research for id " + num71.ToString());
                  this.data.StringListObj[this.slotRegimeOobs].SetData2(0, num71, 1, this.RegimeId, 4, 1);
                  int num110 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, num71, 3)));
                  string str3 = "";
                  int length11 = this.data.StringListObj[this.slotOobTypes].Length;
                  for (int index28 = 0; index28 <= length11; ++index28)
                  {
                    num25 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index28, 0]));
                    string str4 = this.data.StringListObj[this.slotOobTypes].Data[index28, 1];
                    if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index28, 3])) == num110 & num25 != num71 && !this.data.StringListObj[this.slotRegimeOobs].FindValue2(0, num25.ToString(), 1, this.RegimeId.ToString()))
                    {
                      this.ai.AddLog("Gives free oobType id " + num25.ToString());
                      StringListClass stringListClass = this.data.StringListObj[this.slotRegimeOobs];
                      string s0 = num25.ToString();
                      string s1 = this.RegimeId.ToString();
                      num84 = 1;
                      string s2 = num84.ToString();
                      string s3 = 0.ToString();
                      num83 = 0;
                      string s4 = num83.ToString();
                      string s5 = 0.ToString();
                      stringListClass.AddRowWithData(s0, s1, s2, s3, s4, s5);
                      if (str3.Length > 0)
                        str3 += ", ";
                      str3 += str4;
                    }
                  }
                }
              }
            }
            num8 -= num79;
          }
          if (num8 < 0)
            num8 = 0;
          this.ai.AddLog("Ai Points left = " + num8.ToString());
          this.data.StringListObj[this.slotRegimeKeys].SetData2(0, this.RegimeId, 1, "aiPoints", 2, num8, true);
        }
        this.ai.WriteLog(str1);
      }
    }

    public SimpleList ModelsChoicesForAI(
      int modelTypeId,
      ref Shadow_Economic_AI ecoAi,
      bool lowBudgetVersion,
      int tStage)
    {
      SimpleList simpleList1 = new SimpleList();
      bool flag1 = true;
      bool flag2 = true;
      bool flag3 = true;
      bool flag4 = true;
      bool flag5 = true;
      if (lowBudgetVersion)
      {
        if (tStage <= 4)
        {
          flag1 = false;
          flag2 = false;
          flag3 = false;
          flag4 = false;
          flag5 = false;
        }
        else if (tStage <= 5)
        {
          flag1 = false;
          flag3 = false;
          flag4 = false;
          flag5 = false;
        }
        else if (tStage <= 6)
        {
          flag1 = false;
          flag3 = false;
          flag4 = false;
        }
        else
        {
          flag1 = false;
          flag3 = false;
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("------------------CHOICE DETERMINATION ---------------------------------------");
      this.ai.AddLog("");
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 2, 2)));
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 1, 2)));
      if (num1 > 5)
        num1 = 0;
      if (num2 > 5)
        num2 = 0;
      int minimumTemperature = DrawMod.TGame.EventRelatedObj.Helper_GetMinimumTemperature();
      int num3 = 0;
      if (num2 >= 2 | num1 >= 2 | minimumTemperature < -55)
        num3 = 24;
      else if (num2 >= 1 | num1 >= 1)
        num3 = minimumTemperature >= -35 ? 21 : 23;
      else if (minimumTemperature < -20)
        num3 = 22;
      int id1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 2)));
      int unitGroup = this.data.SFTypeObj[DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id1)].UnitGroup;
      int num4 = num4;
      int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 446, 0, 0));
      int num5 = 0;
      int num6 = 0;
      int length1 = this.data.StringListObj[this.slotRegimeModels].Length;
      int num7;
      for (int index = 0; index <= length1; ++index)
      {
        num7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index, 1]));
        int id2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index, 2]));
        if (id2 != this.RegimeId)
        {
          int id3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeModels].Data[index, 5]));
          int sfTypeById = DrawMod.TGame.HandyFunctionsObj.GetSFTypeByID(id3);
          int regimeById = DrawMod.TGame.HandyFunctionsObj.GetRegimeByID(id2);
          if (regimeById > -1 && sfTypeById > -1 & !this.data.RegimeObj[regimeById].AI && this.data.SFTypeObj[sfTypeById].UnitGroup == unitGroup | unitGroup == 1 & this.data.SFTypeObj[sfTypeById].UnitGroup == 0)
          {
            int idValue1 = this.data.SFTypeObj[sfTypeById].SFTypeVar[41];
            int num8 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData(0, idValue1, 1)));
            if (num8 > 0 & num8 < 999 && num8 > num5)
              num5 = num8;
            int idValue2 = this.data.SFTypeObj[sfTypeById].SFTypeVar[42];
            int num9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData(0, idValue2, 1)));
            if (num9 > 0 & num9 < 999 && num9 > num6)
              num6 = num9;
          }
        }
      }
      if (this.data.Round <= 20)
      {
        if (num5 < 50)
          num5 = 50;
        if (num6 < 50)
          num6 = 50;
      }
      else if (this.data.Round <= 40)
      {
        if (num5 < 70)
          num5 = 70;
        if (num6 < 100)
          num6 = 100;
      }
      else if (this.data.Round <= 90)
      {
        if (num5 < 110)
          num5 = 110;
        if (num6 < 150)
          num6 = 150;
      }
      else if (this.data.Round <= 150)
      {
        if (num5 < 140)
          num5 = 140;
        if (num6 < 200)
          num6 = 200;
      }
      else
      {
        if (num5 < 180)
          num5 = 180;
        if (num6 < 200)
          num6 = 200;
      }
      int[] numArray1 = new int[4]
      {
        0,
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 4))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 5))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 15)))
      };
      int num10 = 0;
      int counter = this.ShqList.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.ShqList.Data1[index] > num10)
          num10 = this.ShqList.Data1[index];
      }
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "MODELTYPE", 1, modelTypeId, true);
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "MODELTYPEID", 1, modelTypeId, true);
      bool flag6 = false;
      bool flag7 = false;
      string String2_1 = "[all]";
      int id4 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 2)));
      if (id4 > 0)
      {
        int sfTypeById = this.ai.game.HandyFunctionsObj.GetSFTypeByID(id4);
        if (sfTypeById > 0)
        {
          if (this.ai.game.Data.SFTypeObj[sfTypeById].Theater == 1)
            flag7 = true;
          if (this.ai.game.Data.SFTypeObj[sfTypeById].Theater == 2)
            flag6 = true;
        }
      }
      if (flag6)
        String2_1 = "[air]";
      if (flag7)
        String2_1 = "[navy]";
      int num11 = 0;
      int num12 = 0;
      int num13 = 0;
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SIZE", 1, 0, true);
      int num14 = 0;
      do
      {
        int tid = 1;
        do
        {
          if (numArray1[tid] > 0 & num14 == 0)
            ++num12;
          if (numArray1[tid] > 0 & num14 == 1 & numArray1[tid] != 24 | (num14 == 2 | num14 == 0) & numArray1[tid] == 24)
          {
            this.ai.AddLog("***** ChoiceType: " + numArray1[tid].ToString());
            SimpleList simpleList2 = new SimpleList();
            int length2 = this.data.StringListObj[this.slotModelTypeChoices].Length;
            for (int index1 = 0; index1 <= length2; ++index1)
            {
              int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 0]));
              int num16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 12]));
              if (num15 == numArray1[tid] & num16 <= num10)
              {
                string str1 = this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 4];
                int num17 = 1;
                Random random;
                if (str1.Length > 0)
                {
                  EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                  int id5 = this.data.StringListObj[this.slotFlags].ID;
                  int id6 = this.data.StringListObj[this.slotFlagInstructions].ID;
                  string logicString = str1;
                  random = (Random) null;
                  ref Random local = ref random;
                  num17 = eventRelatedObj.CheckLogicStringStart(id5, id6, logicString, 0, ref local);
                }
                if (num17 > 0)
                {
                  int num18 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 1]));
                  int num19 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 2]));
                  int num20 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 9]));
                  int num21 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 10]));
                  string str2 = this.data.StringListObj[this.slotModelTypeChoices].Data[index1, 3];
                  int num22 = 1000;
                  string String2_2 = "[" + modelTypeId.ToString() + "]";
                  int[] numArray2 = new int[1000];
                  int length3 = this.data.StringListObj[this.slotModelTypeStats].Length;
                  for (int index2 = 0; index2 <= length3; ++index2)
                  {
                    if (Strings.InStr(this.data.StringListObj[this.slotModelTypeStats].Data[index2, 0], String2_2) > 0 | Strings.InStr(this.data.StringListObj[this.slotModelTypeStats].Data[index2, 0], String2_1) > 0)
                    {
                      int index3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeStats].Data[index2, 1]));
                      int num23 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeStats].Data[index2, 7]));
                      int num24 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeStats].Data[index2, 8]));
                      if (!(num18 == num23 & num19 == num24) && num23 == 0 & num24 == 0 && index3 == 6 | index3 == 5 & tid == 3)
                      {
                        string str3 = this.data.StringListObj[this.slotModelTypeStats].Data[index2, 2];
                        EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                        int id7 = this.data.StringListObj[this.slotFlags].ID;
                        int id8 = this.data.StringListObj[this.slotFlagInstructions].ID;
                        string logicString = str3;
                        random = (Random) null;
                        ref Random local = ref random;
                        int num25 = eventRelatedObj.CheckLogicStringStart(id7, id8, logicString, 0, ref local);
                        int[] numArray3 = numArray2;
                        int[] numArray4 = numArray3;
                        int index4 = index3;
                        int index5 = index4;
                        int num26 = numArray3[index4] + num25;
                        numArray4[index5] = num26;
                        this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SIZE", 1, numArray2[index3], true);
                      }
                    }
                  }
                  int length4 = this.data.StringListObj[this.slotModelTypeStats].Length;
                  for (int index6 = 0; index6 <= length4; ++index6)
                  {
                    if (Strings.InStr(this.data.StringListObj[this.slotModelTypeStats].Data[index6, 0], String2_2) > 0 | Strings.InStr(this.data.StringListObj[this.slotModelTypeStats].Data[index6, 0], String2_1) > 0)
                    {
                      int index7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeStats].Data[index6, 1]));
                      int num27 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeStats].Data[index6, 7]));
                      int num28 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypeStats].Data[index6, 8]));
                      if (num18 == num27 & num19 == num28)
                      {
                        string str4 = this.data.StringListObj[this.slotModelTypeStats].Data[index6, 2];
                        EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                        int id9 = this.data.StringListObj[this.slotFlags].ID;
                        int id10 = this.data.StringListObj[this.slotFlagInstructions].ID;
                        string logicString = str4;
                        random = (Random) null;
                        ref Random local = ref random;
                        int num29 = eventRelatedObj.CheckLogicStringStart(id9, id10, logicString, 0, ref local);
                        numArray2[index7] = num29;
                        if (num20 > 0)
                        {
                          int[] numArray5 = numArray2;
                          int[] numArray6 = numArray5;
                          int index8 = num20;
                          int index9 = index8;
                          int num30 = numArray5[index8] + num21;
                          numArray6[index9] = num30;
                        }
                      }
                      else
                      {
                        int num31 = num27 == 0 & num28 == 0 ? 1 : 0;
                      }
                    }
                  }
                  if (numArray2[2] > 0)
                  {
                    num22 = (int) Math.Round((double) ((float) (int) Math.Round((double) (num22 * numArray2[2]) / 100.0) * this.GetWeaponArmourScore(numArray2[37])));
                    if (!lowBudgetVersion && modelTypeId >= 31 & modelTypeId <= 39 & modelTypeId != 34 && num19 >= 81 & num19 <= 89)
                      num22 = (int) Math.Round((double) num22 * 0.5);
                  }
                  if (numArray2[4] > 0)
                    num22 = (int) Math.Round((double) ((float) (int) Math.Round((double) (num22 * numArray2[4]) / 100.0) * this.GetWeaponArmourScore(armourTypeId: numArray2[38])));
                  if (unitGroup == 1 | unitGroup == 3 | unitGroup == 4 && numArray2[3] > 0)
                  {
                    int num32 = (int) Math.Round((double) (num6 * numArray2[6]) / 2.0) + num5 * 2;
                    num22 = num32 <= numArray2[3] ? (int) Math.Round((double) (int) Math.Round((double) num22 * ((double) num32 / (double) numArray2[3])) * ((double) num32 / (double) numArray2[3])) : (int) Math.Round((double) (int) Math.Round((double) num22 * ((double) numArray2[3] / (double) num32)) * ((double) numArray2[3] / (double) num32));
                  }
                  if (numArray2[5] > 0 & num14 > 0 & numArray2[3] <= 0 && num12 > 1 & num11 > 0)
                  {
                    int num33 = (int) Math.Round((double) (int) Math.Round((double) num11 / (double) (num12 - 1)) * 0.8);
                    num22 = numArray2[5] <= num33 * 4 ? (numArray2[5] <= num33 * 3 ? ((double) numArray2[5] <= (double) num33 * 2.5 ? (numArray2[5] <= num33 * 2 ? ((double) numArray2[5] <= (double) num33 * 1.5 ? ((double) numArray2[5] <= (double) num33 * 1.3 ? ((double) numArray2[5] <= (double) num33 * 1.1 ? ((double) numArray2[5] <= (double) num33 * 0.9 ? ((double) numArray2[5] <= (double) num33 * 0.7 ? ((double) numArray2[5] <= (double) num33 * 0.5 ? (int) Math.Round((double) num22 * 0.8) : (int) Math.Round((double) num22 * 0.95)) : (int) Math.Round((double) num22 * 0.9)) : (int) Math.Round((double) num22 * 0.85)) : (int) Math.Round((double) num22 * 0.76)) : (int) Math.Round((double) num22 * 0.62)) : (int) Math.Round((double) num22 * 0.5)) : (int) Math.Round((double) num22 * 0.2)) : (int) Math.Round((double) num22 * 0.075)) : (int) Math.Round((double) num22 * 0.01)) : (int) Math.Round((double) num22 * 0.001);
                  }
                  if (num14 == 0)
                    num22 = numArray2[3];
                  int num34 = num22;
                  int num35 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData(0, num19, 1)));
                  if (num35 > 0 & (unitGroup == 1 | unitGroup == 3 | unitGroup == 4))
                  {
                    if (numArray2[2] > numArray2[4])
                    {
                      if (num6 < 20)
                        num6 = 20;
                      if (num6 > 0)
                      {
                        if (num35 > num6)
                        {
                          num22 = (int) Math.Round((double) ((int) Math.Round((double) (num22 * num6) / (double) num35) * num6) / (double) num35);
                        }
                        else
                        {
                          if (num35 < (int) Math.Round((double) num6 / 10.0))
                            num35 = (int) Math.Round((double) num6 / 10.0);
                          num22 = (int) Math.Round((double) num22 * ((double) num35 / (double) num6) * ((double) num35 / (double) num6));
                        }
                      }
                    }
                    else if (numArray2[4] > numArray2[2])
                    {
                      if (num5 < 20)
                        num5 = 20;
                      if (num5 > 0)
                      {
                        if (num35 > num5)
                        {
                          num22 = (int) Math.Round((double) ((int) Math.Round((double) (num22 * num5) / (double) num35) * num5) / (double) num35);
                        }
                        else
                        {
                          if (num35 < (int) Math.Round((double) num5 / 10.0))
                            num35 = (int) Math.Round((double) num5 / 10.0);
                          num22 = (int) Math.Round((double) num22 * ((double) num35 / (double) num5) * ((double) num35 / (double) num5));
                        }
                      }
                    }
                  }
                  if (num22 > num34 * 3)
                    num22 = num34 * 3;
                  if ((double) num22 < (double) num34 / 5.0)
                    num22 = (int) Math.Round((double) num34 / 5.0);
                  int tweight = (int) Math.Round((double) (num22 + num22 + num22 + num34) / 4.0);
                  if (numArray1[tid] == 2 && num3 > num19)
                    tweight = 0;
                  if (numArray2[402] > 0)
                  {
                    float num36 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[2] / (double) (2 + ecoAi.itemNeed[2])))) / 2f;
                    if ((double) num36 > 3.0)
                      num36 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num36));
                  }
                  if (numArray2[403] > 0)
                  {
                    float num37 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[8] / (double) (2 + ecoAi.itemNeed[8])))) / 2f;
                    if ((double) num37 > 3.0)
                      num37 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num37));
                  }
                  if (numArray2[404] > 0)
                  {
                    float num38 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[13] / (double) (2 + ecoAi.itemNeed[13])))) / 2f;
                    if ((double) num38 > 3.0)
                      num38 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num38));
                    if (!flag4)
                      tweight = 0;
                  }
                  if (numArray2[405] > 0)
                  {
                    float num39 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[14] / (double) (2 + ecoAi.itemNeed[14])))) / 2f;
                    if ((double) num39 > 3.0)
                      num39 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num39));
                    if (!flag3)
                      tweight = 0;
                  }
                  if (numArray2[406] > 0)
                  {
                    float num40 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[4] / (double) (2 + ecoAi.itemNeed[4])))) / 2f;
                    if ((double) num40 > 3.0)
                      num40 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num40));
                    if (!flag1)
                      tweight = 0;
                  }
                  if (numArray2[407] > 0)
                  {
                    float num41 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[3] / (double) (2 + ecoAi.itemNeed[3])))) / 2f;
                    if ((double) num41 > 3.0)
                      num41 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num41));
                    if (!flag2)
                      tweight = 0;
                  }
                  if (numArray2[101] > 0)
                  {
                    float num42 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[1] / (double) (2 + ecoAi.itemNeed[1])))) / 2f;
                    if ((double) num42 > 3.0)
                      num42 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num42));
                  }
                  if (numArray2[102] > 0 | numArray2[202] > 0)
                  {
                    float num43 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[15] / (double) (2 + ecoAi.itemNeed[15])))) / 2f;
                    if ((double) num43 > 3.0)
                      num43 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num43));
                    if (!flag5)
                      tweight = 0;
                  }
                  if (numArray2[103] > 0 | numArray2[203] > 0)
                  {
                    float num44 = 0.25f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[4] / (double) (2 + ecoAi.itemNeed[4])))) / 2f;
                    if ((double) num44 > 3.0)
                      num44 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num44));
                    if (!flag1)
                      tweight = 0;
                  }
                  if (numArray2[301] > 0)
                  {
                    float num45 = 0.66f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[7] / (double) (2 + ecoAi.itemNeed[7])))) / 3f;
                    if ((double) num45 > 1.0)
                      num45 = 1f;
                    tweight = (int) Math.Round((double) ((float) tweight * num45));
                  }
                  if (numArray2[302] > 0)
                  {
                    float num46 = 0.5f + (float) (int) Math.Round(Conversion.Val((object) ((double) ecoAi.itemProduction[15] / (double) (2 + ecoAi.itemNeed[15])))) / 2f;
                    if ((double) num46 > 3.0)
                      num46 = 3f;
                    tweight = (int) Math.Round((double) ((float) tweight * num46));
                    if (!flag5)
                      tweight = 0;
                  }
                  int num47 = num14 == 1 & numArray2[5] > 0 ? 1 : 0;
                  if (num14 == 2 & numArray2[3] > 0)
                  {
                    int num48 = (int) Math.Round((double) num13 * 1.15) + numArray2[6] * 10;
                    float num49 = (float) (1 + numArray2[3]) / (float) (num48 + 1);
                    if ((double) num49 > 2.0)
                      num49 *= 0.05f;
                    else if ((double) num49 > 1.75)
                      num49 *= 0.1f;
                    else if ((double) num49 > 1.5)
                      num49 *= 0.25f;
                    else if ((double) num49 > 1.25)
                      num49 *= 0.6f;
                    else if ((double) num49 > 1.1)
                      num49 *= 0.8f;
                    else if ((double) num49 < 1.0)
                      num49 = num49;
                    else if ((double) num49 < 0.7)
                      num49 *= num49;
                    else if ((double) num49 < 0.5)
                      num49 = num49 * num49 * num49;
                    if ((double) num49 > 1.0)
                      num49 = 1f;
                    tweight = (int) Math.Round((double) ((float) tweight * num49));
                  }
                  if (num14 > 0)
                  {
                    if (tweight > 0)
                    {
                      this.ai.AddLog("-Choice: " + str2 + " (#" + num19.ToString() + ") , weight: " + tweight.ToString());
                      simpleList2.Add(num19, tweight, numArray2[5]);
                    }
                  }
                  else if (num14 == 0)
                    simpleList2.Add(num19, numArray2[3]);
                }
              }
            }
            if (num14 > 0 && simpleList2.Counter > -1)
            {
              simpleList2.ReverseSortHighSpeed();
              int tweight = simpleList2.Id[0];
              num13 += simpleList2.Data1[0];
              simpleList1.Add(tid, tweight);
              this.ai.AddLog("=> choice was made for #" + tweight.ToString() + ".");
              this.ai.AddLog("");
            }
            if (num14 == 0 && simpleList2.Counter > -1)
            {
              simpleList2.ReverseSortHighSpeed();
              num7 = simpleList2.Id[0];
              num11 = simpleList2.Weight[0];
            }
          }
          ++tid;
        }
        while (tid <= 3);
        ++num14;
      }
      while (num14 <= 2);
      this.ai.AddLog(" ------------------------------------------------------- ");
      return simpleList1;
    }

    public SimpleList ModelsChoicesForAI_Air(
      int modelTypeId,
      ref Shadow_Economic_AI ecoAi,
      bool lowBudgetVersion,
      int tStage)
    {
      SimpleList simpleList = new SimpleList();
      bool flag1 = true;
      bool flag2 = true;
      bool flag3 = true;
      bool flag4 = true;
      bool flag5 = true;
      if (lowBudgetVersion)
      {
        if (tStage <= 4)
        {
          flag1 = false;
          flag2 = false;
          flag3 = false;
          flag4 = false;
          flag5 = false;
        }
        else if (tStage <= 5)
        {
          flag1 = false;
          flag3 = false;
          flag4 = false;
          flag5 = false;
        }
        else if (tStage <= 6)
        {
          flag1 = false;
          flag3 = false;
          flag4 = false;
        }
        else
        {
          flag1 = false;
          flag3 = false;
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("------------------CHOICE DETERMINATION ---------------------------------------");
      this.ai.AddLog("");
      int[] numArray = new int[8]
      {
        0,
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 4))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 5))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 15))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 21))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 22))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 23))),
        (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 24)))
      };
      int num1 = 0;
      int counter = this.ShqList.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.ShqList.Data1[index] > num1)
          num1 = this.ShqList.Data1[index];
      }
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "MODELTYPE", 1, modelTypeId, true);
      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "MODELTYPEID", 1, modelTypeId, true);
      bool flag6 = false;
      bool flag7 = false;
      string str = "[all]";
      int id = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotModelTypes].GetData(0, modelTypeId, 2)));
      if (id > 0)
      {
        int sfTypeById = this.ai.game.HandyFunctionsObj.GetSFTypeByID(id);
        if (sfTypeById > 0)
        {
          if (this.ai.game.Data.SFTypeObj[sfTypeById].Theater == 1)
            flag7 = true;
          if (this.ai.game.Data.SFTypeObj[sfTypeById].Theater == 2)
            flag6 = true;
        }
      }
      if (flag6)
        str = "[air]";
      if (flag7)
        str = "[navy]";
      int num2 = 0;
      int num3 = 1;
      int num4 = 0;
      if (numArray[1] == 28)
      {
        int tweight;
        if (modelTypeId == 101)
          tweight = 282;
        if (modelTypeId == 102)
        {
          tweight = 282;
          num4 = 1;
        }
        if (modelTypeId == 103)
        {
          tweight = 284;
          num4 = 0;
        }
        if (modelTypeId == 104)
        {
          tweight = 284;
          num3 = 2;
          num4 = 1;
        }
        if (modelTypeId == 105)
        {
          tweight = 285;
          num3 = 2;
          num4 = 1;
        }
        if (modelTypeId == 106)
        {
          tweight = 285;
          num3 = 4;
          num4 = 1;
        }
        if (modelTypeId == 107)
        {
          tweight = 285;
          num3 = 6;
          num4 = 1;
        }
        if (modelTypeId == 108)
        {
          tweight = 285;
          num3 = 6;
          num4 = 1;
        }
        if (modelTypeId == 111)
          tweight = 282;
        if (modelTypeId == 112)
        {
          tweight = 284;
          num3 = 1;
          num4 = 1;
        }
        if (modelTypeId == 113)
        {
          tweight = 285;
          num3 = 2;
          num4 = 1;
        }
        if (modelTypeId == 121)
          tweight = 282;
        if (modelTypeId == 122)
        {
          tweight = 284;
          num3 = 2;
          num4 = 1;
        }
        if (modelTypeId == 123)
        {
          tweight = 285;
          num3 = 4;
          num4 = 1;
        }
        num2 = tweight;
        simpleList.Add(1, tweight);
      }
      int num5 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 350, 1, this.RegimeId, 2)));
      int num6 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 351, 1, this.RegimeId, 2)));
      int num7 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 352, 1, this.RegimeId, 2)));
      int num8 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 353, 1, this.RegimeId, 2)));
      int num9 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 354, 1, this.RegimeId, 2)));
      int num10 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 355, 1, this.RegimeId, 2)));
      int num11 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 356, 1, this.RegimeId, 2)));
      int num12 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 357, 1, this.RegimeId, 2)));
      int num13 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 358, 1, this.RegimeId, 2)));
      int num14 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 359, 1, this.RegimeId, 2)));
      int num15 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 360, 1, this.RegimeId, 2)));
      int tweight1 = -1;
      if (num5 >= 100)
        tweight1 = 3 + num4;
      if (num6 >= 100)
        tweight1 = 13 + num4;
      if (num7 >= 100)
        tweight1 = 23 + num4;
      if (num8 >= 100)
        tweight1 = 33 + num4;
      if (num15 >= 100)
        tweight1 = 43 + num4;
      if (num9 >= 100)
        tweight1 = 53 + num4;
      if (this.Air_Economical_RocketBased > this.Air_Economical_AirBased & num11 >= 50)
        tweight1 = 73 + num4;
      if (modelTypeId >= 111 & modelTypeId <= 119)
        tweight1 = 62 + num4;
      switch (num2)
      {
        case 284:
          ++tweight1;
          break;
        case 285:
          tweight1 += 2;
          break;
      }
      if (this.Air_Economical_RocketBased > this.Air_Economical_AirBased & num11 >= 100)
      {
        if (tweight1 >= 75 & num13 < 100)
          tweight1 = 74;
        if (tweight1 >= 73 & num12 < 100)
          tweight1 = 72;
      }
      if (num3 == 1)
        tweight1 += 300;
      if (num3 == 2)
        tweight1 += 800;
      if (num3 == 4)
        tweight1 += 900;
      if (num3 == 6)
        tweight1 += 1000;
      simpleList.Add(2, tweight1);
      int tid1 = 3;
      if (modelTypeId >= 101 & modelTypeId <= 109)
      {
        int tweight2 = -1;
        switch (num2)
        {
          case 282:
            tweight2 = 404;
            break;
          case 284:
            tweight2 = 405;
            break;
          case 285:
            tweight2 = 406;
            break;
        }
        simpleList.Add(tid1, tweight2);
        ++tid1;
      }
      int tweight3 = -1;
      switch (num2)
      {
        case 282:
          tweight3 = 427;
          break;
        case 284:
          tweight3 = 429;
          break;
        case 285:
          tweight3 = 431;
          break;
      }
      simpleList.Add(tid1, tweight3);
      int tid2 = tid1 + 1;
      int num16 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 43, 1, this.RegimeId, 2)));
      int num17 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 307, 1, this.RegimeId, 2)));
      int num18 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 212, 1, this.RegimeId, 2)));
      int num19 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 46, 1, this.RegimeId, 2)));
      int num20 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 102, 1, this.RegimeId, 2)));
      int num21 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimeTech].GetData2(0, 103, 1, this.RegimeId, 2)));
      int tweight4 = 0;
      int tweight5 = 0;
      if (num2 == 282)
      {
        tweight5 = 501;
        if (num16 >= 100)
          tweight5 = 502;
        if (num17 >= 100)
          tweight5 = 503;
        if (num18 >= 100)
          tweight5 = 504;
        if (num19 >= 100)
          tweight5 = 505;
        if (num21 >= 100 & modelTypeId >= 102 & modelTypeId <= 109)
          tweight5 = 531;
        if (num21 >= 100 & modelTypeId >= 121 & modelTypeId <= 129)
          tweight5 = 531;
        if (num21 >= 100 & modelTypeId >= 112 & modelTypeId <= 119)
          tweight5 = 531;
      }
      else if (num2 == 284)
      {
        tweight5 = 501;
        if (num16 >= 100)
          tweight5 = 502;
        if (num17 >= 100)
          tweight5 = 503;
        if (num18 >= 100)
          tweight5 = 504;
        if (num19 >= 100)
          tweight5 = 505;
        if (num21 >= 100 & modelTypeId >= 103 & modelTypeId <= 109)
          tweight5 = 532;
        if (num21 >= 100 & modelTypeId >= 121 & modelTypeId <= 129)
          tweight5 = 532;
        if (num21 >= 100 & modelTypeId >= 113 & modelTypeId <= 119)
          tweight5 = 532;
        tweight4 = 634;
        if (modelTypeId >= 111 & modelTypeId <= 119)
          tweight4 = 621;
        if (num20 >= 100 & modelTypeId >= 102 & modelTypeId <= 104)
          tweight4 = 602;
        if (num20 >= 100 & modelTypeId >= 121 & modelTypeId <= 129)
          tweight4 = 602;
        if (num20 >= 100 & modelTypeId >= 112 & modelTypeId <= 119)
          tweight4 = 602;
        if (num20 >= 100 & modelTypeId >= 102 & modelTypeId <= 104)
          tweight4 = 603;
        if (num20 >= 100 & modelTypeId >= 122 & modelTypeId <= 129)
          tweight4 = 603;
        if (num20 >= 100 & modelTypeId >= 112 & modelTypeId <= 119)
          tweight4 = 603;
        if (num20 >= 100 & modelTypeId >= 103 & modelTypeId <= 104)
          tweight4 = 604;
        if (num20 >= 100 & modelTypeId >= 123 & modelTypeId <= 129)
          tweight4 = 604;
        if (num20 >= 100 & modelTypeId >= 113 & modelTypeId <= 119)
          tweight4 = 604;
      }
      else if (num2 == 285)
      {
        if (modelTypeId == 105)
        {
          tweight5 = 521;
          if (num16 >= 100)
            tweight5 = 522;
          if (num17 >= 100)
            tweight5 = 523;
          if (num18 >= 100)
            tweight5 = 524;
          if (num19 >= 100)
            tweight5 = 525;
        }
        else
        {
          tweight5 = 511;
          if (num16 >= 100)
            tweight5 = 512;
          if (num17 >= 100)
            tweight5 = 513;
          if (num18 >= 100)
            tweight5 = 514;
          if (num19 >= 100)
            tweight5 = 515;
        }
        if (num21 >= 100 & modelTypeId >= 103 & modelTypeId <= 109)
          tweight5 = 533;
        if (num21 >= 100 & modelTypeId >= 122 & modelTypeId <= 129)
          tweight5 = 533;
        tweight4 = 621;
      }
      simpleList.Add(tid2, tweight5);
      int tid3 = tid2 + 1;
      simpleList.Add(tid3, tweight4);
      int tid4 = tid3 + 1;
      simpleList.Add(tid4, 0);
      int num22 = tid4 + 1;
      this.ai.AddLog(" ------------------------------------------------------- ");
      return simpleList;
    }

    public float GetWeaponArmourScore(int weaponTypeId = -1, int armourTypeId = -1)
    {
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int unitCounter = this.data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.data.UnitObj[index1].PreDef == -1 & this.data.UnitObj[index1].Regime != this.data.Turn & this.data.UnitObj[index1].Regime >= 2)
        {
          int sfCount = this.data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.data.UnitObj[index1].SFList[index2];
            int type = this.data.SFObj[sf].Type;
            int qty = this.data.SFObj[sf].Qty;
            int tid1 = this.data.SFTypeObj[type].SFTypeVar[37];
            int tid2 = this.data.SFTypeObj[type].SFTypeVar[38];
            int num1 = this.data.SFTypeObj[type].SFTypeVar[30] + this.data.SFTypeObj[type].SFTypeVar[32];
            int num2 = this.data.SFTypeObj[type].SFTypeVar[34];
            if (this.data.RegimeObj[this.data.Turn].RegimeRel[this.data.UnitObj[index1].Regime] == 1)
            {
              num1 = (int) Math.Round((double) num1 / 2.0);
              num2 = (int) Math.Round((double) num2 / 2.0);
            }
            simpleList1.AddWeight(tid1, num1 * qty);
            simpleList2.AddWeight(tid2, num2 * qty);
          }
        }
      }
      float num3;
      if (weaponTypeId > -1)
      {
        num3 = 1f;
        int tid = 1;
        int num4;
        int num5;
        do
        {
          if (weaponTypeId == 1 & tid == 3)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 1.5);
          }
          else if (weaponTypeId == 1 & tid == 4)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.5);
          }
          else if (weaponTypeId == 2 & tid == 3)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.5);
          }
          else if (weaponTypeId == 2 & tid == 4)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.33);
          }
          else if (weaponTypeId == 3 & tid == 4)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.25);
          }
          else if (weaponTypeId == 3 & tid == 4)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.5);
          }
          else if (weaponTypeId == 4 & tid == 3)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.66);
          }
          else if (weaponTypeId == 4 & tid == 4)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.75);
          }
          else if (weaponTypeId == 5 & tid == 1)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.5);
          }
          else if (weaponTypeId == 5 & tid == 2)
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += (int) Math.Round((double) simpleList2.FindWeight(tid) * 0.75);
          }
          else
          {
            num4 += simpleList2.FindWeight(tid);
            num5 += simpleList2.FindWeight(tid);
          }
          ++tid;
        }
        while (tid <= 6);
        return num5 <= 0 ? 1f : (float) num5 / (float) num4;
      }
      if (armourTypeId <= -1)
      {
        float weaponArmourScore;
        return weaponArmourScore;
      }
      num3 = 1f;
      int tid3 = 1;
      int num6;
      int num7;
      do
      {
        if (tid3 == 1 & armourTypeId == 3)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 1.5);
        }
        else if (tid3 == 1 & armourTypeId == 4)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.5);
        }
        else if (tid3 == 2 & armourTypeId == 3)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.5);
        }
        else if (tid3 == 2 & armourTypeId == 4)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.33);
        }
        else if (tid3 == 3 & armourTypeId == 4)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.25);
        }
        else if (tid3 == 3 & armourTypeId == 4)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.5);
        }
        else if (tid3 == 4 & armourTypeId == 3)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.66);
        }
        else if (tid3 == 4 & armourTypeId == 4)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.75);
        }
        else if (tid3 == 5 & armourTypeId == 1)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.5);
        }
        else if (tid3 == 5 & armourTypeId == 2)
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += (int) Math.Round((double) simpleList1.FindWeight(tid3) / 0.75);
        }
        else
        {
          num6 += simpleList1.FindWeight(tid3);
          num7 += simpleList1.FindWeight(tid3);
        }
        ++tid3;
      }
      while (tid3 <= 6);
      return num7 <= 0 ? 1f : (float) num7 / (float) num6;
    }

    public void PlayCards()
    {
      string str1 = "8100_AI_Play_Cards";
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 157, 0, 0));
      SimpleList simpleList1 = new SimpleList();
      bool flag1 = true;
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      bool flag2 = false;
      if (((int) Math.Round((double) this.data.GameID / 1000.0 * (double) this.data.Turn) + this.data.Round) % 3 > 0)
        flag2 = true;
      if (DrawMod.TGame.SuperAdminRights)
        flag2 = false;
      if (flag2)
      {
        this.ai.AddLog(" ");
        this.ai.AddLog("---- Not this turn to save time! -----");
        this.ai.WriteLog(str1);
      }
      else
      {
        int regimeCounter1 = this.data.RegimeCounter;
        for (int index1 = 2; index1 <= regimeCounter1; ++index1)
        {
          int id1 = this.data.RegimeObj[index1].id;
          int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, id1, 1)));
          int regimeCounter2 = this.data.RegimeCounter;
          for (int index2 = 2; index2 <= regimeCounter2; ++index2)
          {
            if (index1 != index2 & index1 >= 2 & index2 >= 2)
            {
              int id2 = this.data.RegimeObj[index2].id;
              int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, id2, 1)));
              int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id1, 1, id2, 2, "relation", 3)));
              int val2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id2, 1, id1, 2, "relation", 3)));
              if (num3 != val2)
              {
                num3 = Math.Min(num3, val2);
                this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "relation", 3, num3);
                this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "relation", 3, num3);
              }
              if (num1 == 1 & num2 == 1)
              {
                if (id1 == this.data.Turn)
                {
                  int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id1, 1, id2, 2, "aiNegativeDip", 3)));
                  if (num4 > 0)
                  {
                    int setValue = num4 - 5;
                    if (0 > setValue)
                      setValue = 0;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiNegativeDip", 3, setValue);
                  }
                }
                int num5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id1, 1, id2, 2, "aiIntention", 3)));
                int num6 = num3;
                if (this.data.RegimeObj[index1].AI & this.data.RegimeObj[index2].AI)
                {
                  int setValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id1, 1, id2, 2, "aiStoryMode", 3)));
                  int num7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id2, 1, id1, 2, "aiStoryMode", 3)));
                  if (setValue1 < 3 & (num6 < 30 | num5 < 30))
                  {
                    setValue1 = 3;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (setValue1 < 5 & (num6 < 15 | num5 < 15))
                  {
                    setValue1 = 5;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (setValue1 == 3 & num5 >= 50 & num6 >= 40)
                  {
                    setValue1 = 2;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (setValue1 < 2 & (num6 < 60 | num5 < 50))
                  {
                    setValue1 = 2;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (setValue1 == 2 & num5 > 80 & num6 >= 50)
                  {
                    setValue1 = 1;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (setValue1 > 3 & num6 >= 30 & num5 >= 25)
                  {
                    setValue1 = 3;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (this.data.RegimeObj[index1].RegimeRel[index2] == 0)
                  {
                    if (setValue1 < 3)
                    {
                      setValue1 = 3;
                      this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                      this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                    }
                    if (setValue1 == 3 & num6 < 20 & num5 < 30)
                    {
                      setValue1 = 5;
                      this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                      this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                    }
                    if (setValue1 == 5 & num5 > 35)
                    {
                      setValue1 = 3;
                      this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                      this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                    }
                  }
                  int num8 = DrawMod.TGame.EventRelatedObj.CheckHardcoded_DiplomaticModifier(id1, id2) + new Random((int) Math.Round((double) this.data.GameID / (double) (id1 + 1))).Next(0, 20);
                  if (num8 >= 125 & setValue1 == 1)
                  {
                    setValue1 = 2;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue1, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue1, true);
                  }
                  if (num8 >= 140 & setValue1 == 2)
                  {
                    int setValue2 = 3;
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id1, 1, id2, 2, "aiStoryMode", 3, setValue2, true);
                    this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id2, 1, id1, 2, "aiStoryMode", 3, setValue2, true);
                  }
                }
              }
              int num9 = 0;
              int length = this.data.StringListObj[this.slotRegRegKeys].Length;
              for (int row = 0; row <= length; ++row)
              {
                if (row <= this.data.StringListObj[this.slotRegRegKeys].Length && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].Data[row, 0])) == id1 && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].Data[row, 1])) == id2 && Operators.CompareString(this.data.StringListObj[this.slotRegRegKeys].Data[row, 2], "relation", false) == 0)
                {
                  ++num9;
                  if (num9 > 1)
                  {
                    this.data.StringListObj[this.slotRegRegKeys].RemoveRow(row);
                    --row;
                  }
                }
              }
            }
          }
        }
        int length1 = this.data.StringListObj[this.slotZones].Length;
        int num10;
        int d;
        for (int index = 0; index <= length1; ++index)
        {
          num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
          int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 6]));
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 8])) == this.RegimeId && num11 > 0)
          {
            int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num10, 1, "worker", 2)));
            d += num12;
          }
        }
        int setValue3 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) d))) + 1;
        this.ai.AddLog("AI received " + setValue3.ToString() + " extra PP.");
        RegimeClass[] regimeObj1 = this.data.RegimeObj;
        RegimeClass[] regimeClassArray1 = regimeObj1;
        int turn1 = this.data.Turn;
        int index3 = turn1;
        regimeClassArray1[index3].ResPts = regimeObj1[turn1].ResPts + setValue3;
        this.ai.AddLog("Now has: " + this.data.RegimeObj[this.data.Turn].ResPts.ToString() + " PP");
        this.ai.AddLog("");
        int num13 = (int) Math.Round((double) new Random(this.data.GameID * (this.data.Round + this.data.Turn)).Next(40, 100) / 10.0);
        bool flag3 = false;
        while (flag1)
        {
          flag1 = false;
          SimpleList simpleList2 = new SimpleList();
          int length2 = this.data.StringListObj[this.slotAiCards].Length;
          for (int index4 = 0; index4 <= length2; ++index4)
          {
            num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiCards].Data[index4, 0]));
            int tdata2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAiCards].Data[index4, 1]));
            string str2 = this.data.StringListObj[this.slotAiCards].Data[index4, 2];
            string str3 = this.data.StringListObj[this.slotAiCards].Data[index4, 3];
            int num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotDipCards].GetData(0, num10, 7)));
            string data = this.data.StringListObj[this.slotDipCards].GetData(0, num10, 1);
            if (num14 == 1 & this.data.RegimeObj[this.data.Turn].ResPts * num13 >= tdata2)
            {
              DrawMod.TGame.EditObj.DoCardSlot = -1;
              int row = this.data.StringListObj[this.slotDipCards].FindRow(0, num10);
              int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotDipCards].Data[row, 7]));
              string str4 = this.data.StringListObj[this.slotDipCards].Data[row, 6];
              this.data.AddActionCard();
              int actionCardCounter = this.data.ActionCardCounter;
              this.data.ActionCardObj[actionCardCounter].TempVar0 = num10;
              int num16 = -1;
              if (num15 == 1 | num15 == 2)
              {
                num16 = DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Data", 540, 0, 0);
                this.data.ActionCardObj[actionCardCounter].AreaSlot = 0;
                this.data.ActionCardObj[actionCardCounter].AreaValue = 1;
              }
              this.data.RegimeObj[this.data.Turn].AddActionCard(this.data.ActionCardCounter);
              DrawMod.TGame.EditObj.DoCardSlot = this.data.RegimeObj[this.data.Turn].ActionCardCounter;
              this.data.ActionCardObj[actionCardCounter].PreExecuteEvent = num16;
              int eventByLib = DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Data", 541, 0, 0);
              this.data.ActionCardObj[actionCardCounter].ExecuteEvent = eventByLib;
              if (DrawMod.TGame.EditObj.DoCardSlot > -1)
              {
                DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_CardMapSelect(this.data.RegimeObj[this.data.Turn].ActionCardCounter);
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "REGID", 1, this.RegimeId, true);
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "REGIMEID", 1, this.RegimeId, true);
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SOURCEREGIMEID", 1, this.RegimeId, true);
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "ROUND", 1, this.data.Round, true);
                int num17 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 2)));
                setValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotCulture].GetData(0, num17, 1)));
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "CULTURE", 1, setValue3, true);
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "CULTUREID", 1, num17, true);
                this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SOURCEREGIMESLOT", 1, this.data.Turn, true);
                int regimeCounter3 = this.data.RegimeCounter;
                for (int index5 = 0; index5 <= regimeCounter3; ++index5)
                {
                  if (index5 != this.data.Turn && this.data.RegimeObj[index5].TempSelectable)
                  {
                    int setValue4 = 0;
                    SimpleList simpleList3 = new SimpleList();
                    int length3 = this.data.StringListObj[this.slotZones].Length;
                    for (int index6 = 0; index6 <= length3; ++index6)
                    {
                      setValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index6, 0]));
                      if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index6, 8])) == this.data.RegimeObj[index5].id)
                      {
                        int length4 = this.data.StringListObj[stringListById1].Length;
                        for (int index7 = 0; index7 <= length4; ++index7)
                        {
                          int tdata1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index7, 0]));
                          int num18 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index7, 1]));
                          if (setValue3 == tdata1)
                          {
                            int num19 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index7, 1]));
                            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num19, 8))) == this.RegimeId)
                            {
                              if (simpleList3.FindNr(num19) == -1)
                                simpleList3.Add(num19, 1, tdata1);
                              else
                                simpleList3.AddWeight(num19, 1);
                              ++setValue4;
                            }
                          }
                          else if (setValue3 == num18 && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index7, 0])), 8))) == this.RegimeId)
                            ++setValue4;
                        }
                      }
                    }
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETLANDBORDER", 1, setValue4, true);
                    int num20 = setValue4;
                    int num21;
                    if (simpleList3.Counter > -1)
                    {
                      int onWeightWithSeed = simpleList3.GetRandomSlotbasedOnWeightWithSeed((object) 9999);
                      int setValue5 = simpleList3.Id[onWeightWithSeed];
                      num21 = setValue5;
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SOURCEZONEID", 1, setValue5, true);
                    }
                    else
                    {
                      int setValue6 = -1;
                      num21 = -1;
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "SOURCEZONEID", 1, setValue6, true);
                    }
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETREGIMEID", 1, this.data.RegimeObj[index5].id, true);
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETMAJOR", 1, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index5].id, 1))), true);
                    if (this.data.StringListObj[this.slotRegimes].Width >= 13)
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETREGIMEAIID", 1, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index5].id, 13))), true);
                    int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
                    int num22 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index5].id, 2)));
                    setValue3 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById2].GetData(0, num22, 1)));
                    DrawMod.TGame.Data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETCULTURE", 1, setValue3, true);
                    DrawMod.TGame.Data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETCULTUREID", 1, num22, true);
                    int num23 = this.data.RegimeObj[this.data.Turn].RegimeRel[index5];
                    setValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index5].id, 1)));
                    if (num23 == 0 & setValue3 == 2 & (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[index5].id, 2, "dipClear", 3))) < 1)
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETWAR", 1, 0, true);
                    else if (num23 == 0)
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETWAR", 1, 1, true);
                    else
                      this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETWAR", 1, 0, true);
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETMAJOR", 1, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index5].id, 1))), true);
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETREGIMESLOT", 1, index5, true);
                    int num24;
                    if (str3.Length > 0)
                    {
                      EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                      int id3 = this.data.StringListObj[this.slotFlags].ID;
                      int id4 = this.data.StringListObj[this.slotFlagInstructions].ID;
                      string logicString = str3;
                      Random random = (Random) null;
                      ref Random local = ref random;
                      num24 = eventRelatedObj.CheckLogicStringStart(id3, id4, logicString, 0, ref local);
                    }
                    else
                      num24 = 1;
                    if (flag3 && num10 == 27 | num10 == 101)
                      num24 = 0;
                    if (num10 >= 1 & num10 <= 16 && !(num10 == 4 | num10 == 8 | num10 == 12 | num10 == 16) && new Random(this.data.Round * this.data.Turn * (int) Math.Round((double) this.data.GameID / 50000.0)).Next(0, 100) > 30)
                      num24 = 0;
                    if (num24 > 0)
                    {
                      EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
                      int id5 = this.data.StringListObj[this.slotFlags].ID;
                      int id6 = this.data.StringListObj[this.slotFlagInstructions].ID;
                      string logicString = str2;
                      Random random = (Random) null;
                      ref Random local = ref random;
                      int num25 = eventRelatedObj.CheckLogicStringStart(id5, id6, logicString, 0, ref local);
                      int tweight = num20 >= 1 ? num25 : (int) Math.Round((double) num25 / 15.0);
                      this.ai.AddLog("Could play " + data + " on " + this.data.RegimeObj[index5].Name + ".");
                      simpleList2.Add(DrawMod.TGame.EditObj.DoCardSlot, tweight, index5, tdata2, num10, CheckData1Existence: true);
                    }
                  }
                }
              }
              DrawMod.TGame.EditObj.DoCardSlot = -1;
              this.data.RemoveActionCard(this.data.ActionCardCounter);
            }
          }
          if (this.data.RegimeObj[this.data.Turn].id == 38)
            ;
          simpleList2.ReverseSort();
          if (simpleList2.Counter > -1 && this.data.RegimeObj[this.data.Turn].ResPts >= simpleList2.Data2[0])
          {
            DrawMod.TGame.EditObj.AreaX = -1;
            int mapWidth = this.data.MapObj[0].MapWidth;
            for (int index8 = 0; index8 <= mapWidth; ++index8)
            {
              int mapHeight = this.data.MapObj[0].MapHeight;
              for (int index9 = 0; index9 <= mapHeight; ++index9)
              {
                if (this.data.MapObj[0].HexObj[index8, index9].Regime == simpleList2.Data1[0])
                {
                  DrawMod.TGame.EditObj.AreaX = index8;
                  DrawMod.TGame.EditObj.AreaY = index9;
                  DrawMod.TGame.SelectX = index8;
                  DrawMod.TGame.SelectY = index9;
                  break;
                }
              }
            }
            if (DrawMod.TGame.EditObj.AreaX > -1)
            {
              flag1 = true;
              int eventByLib = DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Data", 541, 0, 0);
              this.data.AddActionCard();
              int actionCardCounter = this.data.ActionCardCounter;
              this.data.ActionCardObj[actionCardCounter].TempVar0 = simpleList2.Data3[0];
              this.data.ActionCardObj[actionCardCounter].ExecuteEvent = eventByLib;
              int num26 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotDipCards].Data[this.data.StringListObj[this.slotDipCards].FindRow(0, simpleList2.Data3[0]), 7]));
              if (num26 == 1 | num26 == 2)
              {
                this.data.ActionCardObj[actionCardCounter].AreaSlot = 0;
                this.data.ActionCardObj[actionCardCounter].AreaValue = 1;
              }
              this.data.RegimeObj[this.data.Turn].AddActionCard(this.data.ActionCardCounter);
              DrawMod.TGame.EditObj.DoCardSlot = this.data.RegimeObj[this.data.Turn].ActionCardCounter;
              RegimeClass[] regimeObj2 = this.data.RegimeObj;
              RegimeClass[] regimeClassArray2 = regimeObj2;
              int turn2 = this.data.Turn;
              int index10 = turn2;
              regimeClassArray2[index10].ResPts = regimeObj2[turn2].ResPts - simpleList2.Data2[0];
              int regimeCounter4 = this.data.RegimeCounter;
              for (int setValue7 = 0; setValue7 <= regimeCounter4; ++setValue7)
              {
                if (setValue7 != this.data.Turn && setValue7 == simpleList2.Data1[0])
                {
                  this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETREGIMEID", 1, this.data.RegimeObj[setValue7].id, true);
                  this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETMAJOR", 1, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[setValue7].id, 1))), true);
                  if (this.data.StringListObj[this.slotRegimes].Width >= 13)
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETREGIMEAIID", 1, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[setValue7].id, 13))), true);
                  int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
                  int num27 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[setValue7].id, 2)));
                  setValue3 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById3].GetData(0, num27, 1)));
                  DrawMod.TGame.Data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETCULTURE", 1, setValue3, true);
                  DrawMod.TGame.Data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETCULTUREID", 1, num27, true);
                  int num28 = this.data.RegimeObj[this.data.Turn].RegimeRel[setValue7];
                  setValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[setValue7].id, 1)));
                  if (num28 == 0 & setValue3 == 2 & (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[setValue7].id, 2, "dipClear", 3))) < 1)
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETWAR", 1, 0, true);
                  else if (num28 == 0)
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETWAR", 1, 1, true);
                  else
                    this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETWAR", 1, 0, true);
                  this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETMAJOR", 1, (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[setValue7].id, 1))), true);
                  this.data.StringListObj[this.slotFlagInstructions].SetData(0, "TARGETREGIMESLOT", 1, setValue7, true);
                }
              }
              DrawMod.TGame.EventRelatedObj.DoCheckSpecificEvent(eventByLib, num10, -1, -1, -1);
              DrawMod.TGame.EventRelatedObj.IO_AddClear();
              if (simpleList2.Data3[0] == 101 | simpleList2.Data3[0] == 27)
                flag3 = true;
              this.ai.AddLog("Played card: ID#" + simpleList2.Data3[0].ToString() + " : " + this.data.StringListObj[this.slotDipCards].GetData(0, simpleList2.Data3[0], 1) + " on: " + this.data.RegimeObj[simpleList2.Data1[0]].Name);
              if (DrawMod.TGame.SuperAdminRights)
              {
                int num29 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[simpleList2.Data1[0]].id, 1)));
                int num30 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[simpleList2.Data1[0]].id, 2, "relation", 3)));
                int num31 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[simpleList2.Data1[0]].id, 2, "aiIntention", 3)));
                int num32 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[simpleList2.Data1[0]].id, 2, "aiStoryMode", 3)));
                this.ai.AppendLog("CardsPlayedDuringGame", "Round#" + this.data.Round.ToString() + " .... " + this.data.RegimeObj[this.data.Turn].Name + " [#" + this.data.Turn.ToString() + "] played '" + this.data.StringListObj[this.slotDipCards].GetData(0, simpleList2.Data3[0], 1) + "' [#" + simpleList2.Data3[0].ToString() + "] on: " + this.data.RegimeObj[simpleList2.Data1[0]].Name + " [#" + simpleList2.Data1[0].ToString() + "] ..... Relation=" + num30.ToString() + " .... Intention=" + num31.ToString() + " .... RegType=" + num29.ToString() + " .... StoryMode=" + num32.ToString());
              }
              this.data.RemoveActionCard(this.data.ActionCardCounter);
            }
            DrawMod.TGame.SelectX = -1;
            DrawMod.TGame.EditObj.AreaX = -1;
          }
        }
        if ((int) Math.Round(Conversion.Val(this.data.Designer)) >= 97)
        {
          this.ai.AddLog(" ");
          this.ai.AddLog("--- now look at Artifact Cards ---");
          this.ai.AddLog(" ");
          for (int actionCardCounter = this.data.RegimeObj[this.data.Turn].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
          {
            int tempVar0 = this.data.ActionCardObj[this.data.RegimeObj[this.data.Turn].ActionCard[actionCardCounter]].TempVar0;
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotCards].GetData(0, tempVar0, 12))) == 999 && this.data.RegimeObj[this.data.Turn].ResPts >= this.data.ActionCardObj[this.data.RegimeObj[this.data.Turn].ActionCard[actionCardCounter]].PPCost)
            {
              int num33 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotCards].GetData(0, tempVar0, 7)));
              if (num33 == 2)
              {
                DrawMod.TGame.EditObj.DoCardSlot = actionCardCounter;
                DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_CardMapSelect(actionCardCounter);
                SimpleList simpleList4 = new SimpleList();
                int length5 = this.data.StringListObj[this.slotZones].Length;
                for (int index11 = 0; index11 <= length5; ++index11)
                {
                  int num34 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index11, 0]));
                  int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index11, 6]));
                  if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index11, 8])) == this.RegimeId && id > 0)
                  {
                    int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id);
                    if (locationById > -1 && this.data.MapObj[0].HexObj[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y].AreaCode[0] == 1)
                    {
                      setValue3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num34, 1, "popLoyalty", 2)));
                      int tweight = (int) Math.Round((double) ((int) Math.Round((double) (((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num34, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num34, 1, "worker", 2))) * 5) * setValue3) / 100.0) * setValue3) / 100.0);
                      simpleList4.Add(num34, tweight, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y);
                    }
                  }
                }
                simpleList4.ReverseSortHighSpeed();
                if (simpleList4.Counter > -1)
                {
                  this.data.StringListObj[this.slotFlagInstructions].SetData(0, "ZONEID", 1, simpleList4.Id[0], true);
                  DrawMod.TGame.SelectX = simpleList4.Data1[0];
                  DrawMod.TGame.SelectY = simpleList4.Data2[0];
                  int eventByLib = DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Data", 541, 0, 0);
                  this.data.ActionCardObj[this.data.RegimeObj[this.data.Turn].ActionCard[actionCardCounter]].ExecuteEvent = eventByLib;
                  this.ai.AddLog("Played card: ID#" + tempVar0.ToString() + ", " + this.data.ActionCardObj[this.data.RegimeObj[this.data.Turn].ActionCard[actionCardCounter]].Title + ", on zone " + this.data.StringListObj[this.slotZones].GetData(0, simpleList4.Id[0], 7));
                  DrawMod.TGame.ProcessingObj.PlayCard(this.data.Turn, actionCardCounter);
                  DrawMod.TGame.EventRelatedObj.IO_AddClear();
                }
              }
              if (num33 == 5)
              {
                DrawMod.TGame.EditObj.DoCardSlot = actionCardCounter;
                DrawMod.TGame.EventRelatedObj.Hardcoded_Gui_CardMapSelect(actionCardCounter);
                SimpleList simpleList5 = new SimpleList();
                int unitCounter = this.data.UnitCounter;
                for (int index12 = 0; index12 <= unitCounter; ++index12)
                {
                  if (this.data.UnitObj[index12].TempUnitSelectable)
                  {
                    int num35 = 1;
                    int historical = this.data.UnitObj[index12].Historical;
                    if (historical > -1)
                    {
                      int hisVarCount = this.data.HistoricalUnitObj[historical].HisVarCount;
                      for (int index13 = 0; index13 <= hisVarCount; ++index13)
                      {
                        if (this.data.HistoricalUnitObj[historical].HisVarType[index13] > 100 & this.data.HistoricalUnitObj[historical].HisVarType[index13] <= 999999 && this.data.HistoricalUnitObj[historical].HisVarValue[index13] > 0)
                          ++num35;
                      }
                      int tweight = (int) Math.Round((double) DrawMod.TGame.HandyFunctionsObj.GetPower(index12, this.data.Turn) / (double) num35);
                      if (DrawMod.TGame.HandyFunctionsObj.GetArtPercent(actionCardCounter, false) > 20)
                        tweight = (int) Math.Round((double) tweight / 10.0);
                      simpleList5.Add(index12, tweight);
                    }
                  }
                }
                simpleList5.ReverseSortHighSpeed();
                if (simpleList5.Counter > -1)
                {
                  setValue3 = this.data.HistoricalUnitObj[this.data.UnitObj[simpleList5.Id[0]].Historical].ID;
                  DrawMod.TGame.EditObj.UnitSelected = simpleList5.Id[0];
                  this.data.StringListObj[this.slotFlagInstructions].SetData(0, "HISID", 1, setValue3, true);
                  DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Data", 541, 0, 0);
                  this.ai.AddLog("Played card: ID#" + tempVar0.ToString() + ", " + this.data.ActionCardObj[this.data.RegimeObj[this.data.Turn].ActionCard[actionCardCounter]].Title + ", on unit " + this.data.UnitObj[simpleList5.Id[0]].Name);
                  DrawMod.TGame.ProcessingObj.PlayCard(this.data.Turn, actionCardCounter);
                  DrawMod.TGame.EventRelatedObj.IO_AddClear();
                }
              }
            }
          }
        }
        this.ai.WriteLog(str1);
      }
    }

    public SimpleList GetZoneFoodRankingList()
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 3, 2)));
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 2, 2)));
      int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 4, 2)));
      int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 8, 2)));
      SimpleList SL = new SimpleList();
      int mapWidth = this.data.MapObj[0].MapWidth;
      int mapHeight = this.data.MapObj[0].MapHeight;
      DataClass data1 = this.data;
      string str1 = "Zones";
      ref string local1 = ref str1;
      int num5 = data1.FindLibVar(ref local1, "SE_Data");
      DataClass data2 = this.data;
      string str2 = "Vegetation";
      ref string local2 = ref str2;
      int libVar = data2.FindLibVar(ref local2, "SE_Data");
      int num6 = mapWidth;
      for (int index1 = 0; index1 <= num6; ++index1)
      {
        int num7 = mapHeight;
        for (int index2 = 0; index2 <= num7; ++index2)
        {
          int hexLibVarValue1 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(num5);
          if (hexLibVarValue1 > 0)
          {
            int hexLibVarValue2 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar);
            num5 = 10;
            if (hexLibVarValue2 == 4)
              num5 = 100;
            if (hexLibVarValue2 == 5)
              num5 = 200;
            if (hexLibVarValue2 == 6)
              num5 = 200;
            if (hexLibVarValue2 == 7)
              num5 = 300;
            if (hexLibVarValue2 == 8)
              num5 = 300;
            if (num4 == 1)
            {
              if (num2 == 4)
                num5 = 0;
              if (num2 == 3)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.3)));
              if (num2 == 2)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.6)));
              if (num2 == 1)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.9)));
              if (num1 == 4)
                num5 = 0;
              if (num1 == 3)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.3)));
              if (num1 == 2)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.6)));
              if (num1 == 1)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.9)));
            }
            if (num4 == 3)
            {
              if (num3 == 4)
                num5 = 0;
              if (num3 == 3)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.3)));
              if (num3 == 2)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.6)));
              if (num3 == 1)
                num5 = (int) Math.Round(Conversion.Val((object) ((double) num5 * 0.9)));
            }
            int nr = SL.FindNr(hexLibVarValue1);
            if (nr == -1)
            {
              SL.Add(hexLibVarValue1, num5, 1);
            }
            else
            {
              int[] weight = SL.Weight;
              int[] numArray1 = weight;
              int index3 = nr;
              int index4 = index3;
              int num8 = weight[index3] + num5;
              numArray1[index4] = num8;
              int[] data1_1 = SL.Data1;
              int[] numArray2 = data1_1;
              int index5 = nr;
              int index6 = index5;
              int num9 = data1_1[index5] + 1;
              numArray2[index6] = num9;
            }
          }
        }
      }
      int counter = SL.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (SL.Data1[index] > 0)
          SL.Weight[index] = (int) Math.Round((double) SL.Weight[index] / (double) SL.Data1[index] * Math.Sqrt((double) SL.Data1[index]));
      }
      int length = this.data.StringListObj[this.slotAssets].Length;
      for (int index = 0; index <= length; ++index)
      {
        int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 0]));
        int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 4))) == 1 | (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 7))) == 1)
          SL.AddWeight(tid, 100);
      }
      SL = this.Helper_PercentifySL(ref SL);
      return SL;
    }

    public SimpleList Helper_PercentifySL(ref SimpleList SL)
    {
      SL.Sort();
      int num1 = 0;
      int num2 = 100;
      int counter1 = SL.Counter;
      for (int index = 0; index <= counter1; ++index)
        SL.Data1[index] = SL.Counter <= 0 ? (int) Math.Round((double) (num1 + num2) / 2.0) : (index != 0 ? (index != SL.Counter ? num1 + (int) Math.Round((double) ((num2 - num1) * (index + 1)) / (double) (SL.Counter + 2)) : num2) : num1);
      int counter2 = SL.Counter;
      for (int index = 0; index <= counter2; ++index)
        SL.Weight[index] = SL.Data1[index];
      return SL;
    }

    public SimpleList Helper_PercentifySL_Real(ref SimpleList SL)
    {
      int num1 = 0;
      int num2 = 0;
      int counter1 = SL.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (SL.Weight[index] > num1)
          num1 = SL.Weight[index];
        num2 += SL.Weight[index];
      }
      int counter2 = SL.Counter;
      for (int index = 0; index <= counter2; ++index)
        SL.Weight[index] = (int) Math.Round((double) (SL.Weight[index] * 100) / (double) num2);
      return SL;
    }

    public SimpleList GetZoneMineRankingList(int subSubType, bool allowScavenge)
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 3, 2)));
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 2, 2)));
      int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 4, 2)));
      int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 8, 2)));
      int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 362, 0, 0));
      SimpleList SL = new SimpleList();
      int mapWidth = this.data.MapObj[0].MapWidth;
      int mapHeight = this.data.MapObj[0].MapHeight;
      DataClass data1 = this.data;
      string str1 = "Zones";
      ref string local1 = ref str1;
      int num5 = data1.FindLibVar(ref local1, "SE_Data");
      DataClass data2 = this.data;
      string str2 = "MiningType";
      ref string local2 = ref str2;
      int tSlotNr = data2.FindLibVar(ref local2, "SE_Data");
      DataClass data3 = this.data;
      string str3 = "MiningEase";
      ref string local3 = ref str3;
      int libVar1 = data3.FindLibVar(ref local3, "SE_Data");
      DataClass data4 = this.data;
      string str4 = "MiningReserve";
      ref string local4 = ref str4;
      int libVar2 = data4.FindLibVar(ref local4, "SE_Data");
      DataClass data5 = this.data;
      string str5 = "Scavenge";
      ref string local5 = ref str5;
      int libVar3 = data5.FindLibVar(ref local5, "SE_Data");
      int num6 = mapWidth;
      for (int index1 = 0; index1 <= num6; ++index1)
      {
        int num7 = mapHeight;
        for (int index2 = 0; index2 <= num7; ++index2)
        {
          if (index1 == 48 & index2 == 6)
            index1 = index1;
          int hexLibVarValue1 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(num5);
          int hexLibVarValue2 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(tSlotNr);
          int hexLibVarValue3 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar1);
          int hexLibVarValue4 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar2);
          int hexLibVarValue5 = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar3);
          num5 = 0;
          if (hexLibVarValue2 == subSubType)
          {
            num5 = (int) Math.Round((double) (100 * hexLibVarValue3) / 10.0 * (double) Math.Min(10000, hexLibVarValue4) / 10000.0);
            if (num5 > 0)
            {
              int nr = SL.FindNr(hexLibVarValue1);
              if (nr == -1)
              {
                SL.Add(hexLibVarValue1, num5 * 10, 10);
              }
              else
              {
                int[] weight = SL.Weight;
                int[] numArray1 = weight;
                int index3 = nr;
                int index4 = index3;
                int num8 = weight[index3] + num5 * 10;
                numArray1[index4] = num8;
                int[] data1_1 = SL.Data1;
                int[] numArray2 = data1_1;
                int index5 = nr;
                int index6 = index5;
                int num9 = data1_1[index5] + 10;
                numArray2[index6] = num9;
              }
            }
          }
          else if (hexLibVarValue5 > 0 & allowScavenge)
          {
            num5 = (int) Math.Round((double) (10 * Math.Min(5000, hexLibVarValue5)) / 5000.0);
            if (num5 > 0)
            {
              int nr = SL.FindNr(hexLibVarValue1);
              if (nr == -1)
              {
                SL.Add(hexLibVarValue1, num5, 10);
              }
              else
              {
                int[] weight = SL.Weight;
                int[] numArray3 = weight;
                int index7 = nr;
                int index8 = index7;
                int num10 = weight[index7] + num5;
                numArray3[index8] = num10;
                int[] data1_2 = SL.Data1;
                int[] numArray4 = data1_2;
                int index9 = nr;
                int index10 = index9;
                int num11 = data1_2[index9] + 10;
                numArray4[index10] = num11;
              }
            }
          }
          if (subSubType == 5)
          {
            tSlotNr = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById].GetData2(0, this.data.MapObj[0].HexObj[index1, index2].LandscapeType, 1, 5, 2)));
            if (tSlotNr > 0)
            {
              num5 = (int) Math.Round((double) (100 * tSlotNr) / 10.0);
              if (num5 > 0)
              {
                int nr = SL.FindNr(hexLibVarValue1);
                if (nr == -1)
                {
                  SL.Add(hexLibVarValue1, num5 * 10, 10);
                }
                else
                {
                  int[] weight = SL.Weight;
                  int[] numArray5 = weight;
                  int index11 = nr;
                  int index12 = index11;
                  int num12 = weight[index11] + num5 * 10;
                  numArray5[index12] = num12;
                  int[] data1_3 = SL.Data1;
                  int[] numArray6 = data1_3;
                  int index13 = nr;
                  int index14 = index13;
                  int num13 = data1_3[index13] + 10;
                  numArray6[index14] = num13;
                }
              }
            }
          }
        }
      }
      int length = this.data.StringListObj[this.slotAssets].Length;
      for (int index = 0; index <= length; ++index)
      {
        int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 0]));
        int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssets].Data[index, 1]));
        int num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 4)));
        int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 7)));
        int num16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 9)));
        if (num14 == 2 | num15 == 2 && num16 == subSubType)
          SL.AddWeight(tid, 300);
      }
      int counter = SL.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (SL.Data1[index] > 0)
          SL.Weight[index] = (int) Math.Round(Math.Sqrt((double) SL.Weight[index]));
      }
      SL = this.Helper_PercentifySL(ref SL);
      return SL;
    }

    public SimpleList GetZonePopRankingList(int fuzzyPopSteps)
    {
      SimpleList SL = new SimpleList();
      int length = this.data.StringListObj[this.slotZones].Length;
      for (int index = 0; index <= length; ++index)
      {
        int num = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 1])) == 1)
        {
          int tweight = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num, 1, "worker", 2)));
          SL.Add(num, tweight);
        }
      }
      if (fuzzyPopSteps > 0)
      {
        int num1 = fuzzyPopSteps;
        for (int index1 = 1; index1 <= num1; ++index1)
        {
          SimpleList simpleList = SL.Clone();
          int counter1 = simpleList.Counter;
          for (int index2 = 0; index2 <= counter1; ++index2)
          {
            SimpleList zoneNeighbourSlots = DrawMod.TGame.EventRelatedObj.helper_GetZoneNeighbourSlots(simpleList.Id[index2]);
            int num2 = simpleList.Weight[index2] * (index1 * index1);
            int num3 = index1 * index1;
            int counter2 = zoneNeighbourSlots.Counter;
            for (int index3 = 0; index3 <= counter2; ++index3)
            {
              int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[zoneNeighbourSlots.Id[index3], 0]));
              int num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, idValue, 1, "worker", 2)));
              num2 += num4;
              ++num3;
            }
            int num5 = (int) Math.Round((double) num2 / (double) num3);
            simpleList.Weight[index2] = num5;
          }
          SL = simpleList.Clone();
        }
      }
      SL = this.Helper_PercentifySL(ref SL);
      return SL;
    }

    public void SetStrategicAnalysis()
    {
      string str1 = "8000_SetStrategicAnalysis";
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
      SimpleList zoneFoodRankingList = this.GetZoneFoodRankingList();
      SimpleList zoneMineRankingList1 = this.GetZoneMineRankingList(2, true);
      SimpleList zoneMineRankingList2 = this.GetZoneMineRankingList(1, false);
      SimpleList zoneMineRankingList3 = this.GetZoneMineRankingList(3, false);
      SimpleList zoneMineRankingList4 = this.GetZoneMineRankingList(4, false);
      SimpleList zoneMineRankingList5 = this.GetZoneMineRankingList(5, false);
      SimpleList zonePopRankingList1 = this.GetZonePopRankingList(0);
      SimpleList zonePopRankingList2 = this.GetZonePopRankingList(3);
      int id1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 12)));
      int[] numArray1 = new int[this.data.RegimeCounter + 1];
      bool[] flagArray1 = new bool[this.data.RegimeCounter + 1];
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog("Zone Rankings on Resources & Other Analysis");
      this.ai.AddLog("");
      int length1 = this.data.StringListObj[this.slotZones].Length;
      int num2;
      for (int index = 0; index <= length1; ++index)
      {
        int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index, 0]));
        if (tid == 6)
          tid = tid;
        string str2 = this.data.StringListObj[this.slotZones].Data[index, 7];
        int weight1 = zoneFoodRankingList.FindWeight(tid);
        int weight2 = zoneMineRankingList1.FindWeight(tid);
        int weight3 = zoneMineRankingList2.FindWeight(tid);
        num2 = zoneMineRankingList5.FindWeight(tid);
        int weight4 = zonePopRankingList1.FindWeight(tid);
        int weight5 = zonePopRankingList2.FindWeight(tid);
        int weight6 = zoneMineRankingList3.FindWeight(tid);
        int weight7 = zoneMineRankingList4.FindWeight(tid);
        this.ai.AddLog(str2 + " ............... Food: " + weight1.ToString() + ", Metal: " + weight2.ToString() + ", Oil: " + weight3.ToString() + ", Water: " + num2.ToString() + ", Pop: " + weight4.ToString() + ", Close Pop: " + weight5.ToString() + ", Rare: " + weight6.ToString() + ", Radioactive: " + weight7.ToString());
      }
      this.ai.AddLog("");
      this.ai.AddLog("Distance from Capital");
      this.ai.AddLog("");
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai);
      aiMatrix1.SetAllValuesTo(0);
      if (id1 > 0)
      {
        int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id1);
        if (locationById > -1)
        {
          aiMatrix1.Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y] = 1;
          aiMatrix1.ExpandAndAddValueForAnyRegime(999, true);
          int regimeCounter = this.data.RegimeCounter;
          for (int index = 0; index <= regimeCounter; ++index)
            numArray1[index] = 9999;
          int mapWidth = this.data.MapObj[0].MapWidth;
          for (int index1 = 0; index1 <= mapWidth; ++index1)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index2 = 0; index2 <= mapHeight; ++index2)
            {
              int regime = this.data.MapObj[0].HexObj[index1, index2].Regime;
              if (regime > 0 && numArray1[regime] > aiMatrix1.Value[index1, index2])
                numArray1[regime] = aiMatrix1.Value[index1, index2];
            }
          }
        }
      }
      int regimeCounter1 = this.data.RegimeCounter;
      for (int index = 1; index <= regimeCounter1; ++index)
      {
        this.ai.AddLog(this.data.RegimeObj[index].Name + ".... dist=" + numArray1[index].ToString());
        if (this.data.RegimeObj[this.data.Turn].RegimeRel[index] == 0)
        {
          int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.RegimeId, 1, this.data.RegimeObj[index].id, 2, "dipClear", 3)));
          flagArray1[index] = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index].id, 1))) != 2 || num3 > 0;
        }
        else
          flagArray1[index] = false;
      }
      this.ai.WriteLog(str1 + "_ZoneResources_AndOthers");
      this.ai.ClearLog();
      this.ai.AddLog(str1);
      this.friendlyEconomicValue = new int[this.ShqList.Counter + 1];
      this.friendlyMilitaryValue = new int[this.ShqList.Counter + 1];
      this.friendlyMilitaryValueUnMod = new int[this.ShqList.Counter + 1];
      this.enemyTotalValueWeAtt = new int[this.ShqList.Counter + 1];
      this.enemyTotalValueWeDef = new int[this.ShqList.Counter + 1];
      this.enemyEconomicValue = new int[this.ShqList.Counter + 1, this.data.RegimeCounter + 1];
      this.enemyMilitaryValueWeAtt = new int[this.ShqList.Counter + 1, this.data.RegimeCounter + 1];
      this.enemyMilitaryValueWeDef = new int[this.ShqList.Counter + 1, this.data.RegimeCounter + 1];
      this.shqEmptyZones = new int[this.ShqList.Counter + 1];
      this.friendlyAir = new int[this.ShqList.Counter + 1];
      this.enemyAir = new int[this.ShqList.Counter + 1, this.data.RegimeCounter + 1];
      this.enemyHexes = new int[this.data.RegimeCounter + 1];
      this.enemyAllEco = new int[this.data.RegimeCounter + 1];
      AIMatrix aiMatrix2 = new AIMatrix(ref this.ai);
      int mapWidth1 = this.data.MapObj[0].MapWidth;
      int mapHeight1 = this.data.MapObj[0].MapHeight;
      DataClass data = this.data;
      string str3 = "Zones";
      ref string local = ref str3;
      int tSlotNr = data.FindLibVar(ref local, "SE_Data");
      int num4 = mapWidth1;
      for (int index3 = 0; index3 <= num4; ++index3)
      {
        int num5 = mapHeight1;
        for (int index4 = 0; index4 <= num5; ++index4)
          aiMatrix2.Value[index3, index4] = this.data.MapObj[0].HexObj[index3, index4].GetHexLibVarValue(tSlotNr);
      }
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int[] numArray2 = new int[this.ShqList.Counter + 1];
      int[] numArray3 = new int[this.ShqList.Counter + 1];
      int[] numArray4 = new int[this.ShqList.Counter + 1];
      int[] numArray5 = new int[this.ShqList.Counter + 1];
      int[] numArray6 = new int[this.ShqList.Counter + 1];
      int[] numArray7 = new int[this.ShqList.Counter + 1];
      this.regimeZoneList = new SimpleList[this.data.RegimeCounter + 1];
      int counter1 = this.ShqList.Counter;
      for (int index5 = 0; index5 <= counter1; ++index5)
      {
        this.shqHisId = this.ShqList.Id[index5];
        this.shqHisNr = this.ai.game.HandyFunctionsObj.GetHistoricalUnitByID(this.shqHisId);
        this.shqUnitNr = this.ai.game.HandyFunctionsObj.GetUnitByHistorical(this.shqHisNr);
        this.shqName = this.data.HistoricalUnitObj[this.shqHisNr].Name;
        string str4 = "aiShq" + this.shqHisId.ToString() + "_";
        int num6 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, str4 + "food", 2)));
        numArray2[index5] = num6;
        int num7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, str4 + "metal", 2)));
        numArray4[index5] = num7;
        int num8 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, str4 + "oil", 2)));
        numArray5[index5] = num8;
        int num9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, str4 + "water", 2)));
        numArray3[index5] = num9;
        int num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, str4 + "rare", 2)));
        numArray6[index5] = num10;
        int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.RegimeId, 1, str4 + "radio", 2)));
        numArray7[index5] = num11;
        this.ai.AddLog("");
        this.ai.AddLog("SHQ: " + this.shqName);
        this.ai.AddLog("Food need = " + numArray2[index5].ToString());
        this.ai.AddLog("Metal need = " + numArray4[index5].ToString());
        this.ai.AddLog("Oil need = " + numArray5[index5].ToString());
        this.ai.AddLog("Water need = " + numArray3[index5].ToString());
        this.ai.AddLog("");
        SimpleList simpleList3 = new SimpleList();
        int length2 = this.data.StringListObj[this.slotZones].Length;
        for (int index6 = 0; index6 <= length2; ++index6)
        {
          int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index6, 0]));
          int id2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index6, 6]));
          string str5 = this.data.StringListObj[this.slotZones].Data[index6, 6];
          int id3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index6, 8]));
          if (id3 == this.RegimeId)
          {
            if (id2 > 0)
            {
              int locationById = this.ai.game.HandyFunctionsObj.GetLocationByID(id2);
              if (locationById > -1 && this.data.LocObj[locationById].HQ == this.shqUnitNr)
              {
                int x = this.data.LocObj[locationById].X;
                int y = this.data.LocObj[locationById].Y;
                simpleList3.Add(num12, 1);
                int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num12, 1, "pop", 2)));
                int[] friendlyEconomicValue = this.friendlyEconomicValue;
                int[] numArray8 = friendlyEconomicValue;
                int index7 = index5;
                int index8 = index7;
                int num14 = friendlyEconomicValue[index7] + num13;
                numArray8[index8] = num14;
              }
            }
          }
          else
          {
            int regimeById = this.ai.game.HandyFunctionsObj.GetRegimeByID(id3);
            if (regimeById > -1)
            {
              int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num12, 1, "pop", 2)));
              int[] enemyAllEco = this.enemyAllEco;
              int[] numArray9 = enemyAllEco;
              int index9 = regimeById;
              int index10 = index9;
              int num16 = enemyAllEco[index9] + (10 + num15);
              numArray9[index10] = num16;
            }
          }
        }
        int num17 = 0;
        int num18 = 0;
        int num19 = mapWidth1;
        for (int cx = 0; cx <= num19; ++cx)
        {
          int num20 = mapHeight1;
          for (int cy = 0; cy <= num20; ++cy)
          {
            if (this.data.MapObj[0].HexObj[cx, cy].UnitCounter > -1 && aiMatrix2.Value[cx, cy] > 0 && simpleList3.FindNr(aiMatrix2.Value[cx, cy]) > -1)
            {
              int unitCounter = this.data.MapObj[0].HexObj[cx, cy].UnitCounter;
              for (int index11 = 0; index11 <= unitCounter; ++index11)
              {
                int unit = this.data.MapObj[0].HexObj[cx, cy].UnitList[index11];
                int powerPtsAbsolute = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unit, stafftoo: false);
                if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unit))
                {
                  int[] friendlyAir = this.friendlyAir;
                  int[] numArray10 = friendlyAir;
                  int index12 = index5;
                  int index13 = index12;
                  int num21 = friendlyAir[index12] + powerPtsAbsolute;
                  numArray10[index13] = num21;
                }
                int num22 = (int) Math.Round((double) ((int) Math.Round((double) (powerPtsAbsolute * DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(unit)) / 100.0) * DrawMod.TGame.HandyFunctionsObj.GetAverageXp(unit)) / 30.0);
                int[] militaryValueUnMod = this.friendlyMilitaryValueUnMod;
                int[] numArray11 = militaryValueUnMod;
                int index14 = index5;
                int index15 = index14;
                int num23 = militaryValueUnMod[index14] + num22;
                numArray11[index15] = num23;
                if (index11 < 2 & (this.data.MapObj[0].HexObj[cx, cy].VP > 5 | this.data.RegimeObj[this.data.Turn].AIVP[0].Value[cx, cy] > 5))
                  num22 = (int) Math.Round((double) num22 / 5.0);
                else if (index11 < 1 & (this.data.MapObj[0].HexObj[cx, cy].VP > 0 | this.data.RegimeObj[this.data.Turn].AIVP[0].Value[cx, cy] > 0))
                  num22 = (int) Math.Round((double) num22 / 2.0);
                else
                  ++num18;
                float num24 = 0.0f;
                int regimeCounter2 = this.data.RegimeCounter;
                for (int index16 = 1; index16 <= regimeCounter2; ++index16)
                {
                  if ((double) this.combatMatrixDef[index16, this.data.Turn] > (double) num24)
                    num24 = this.combatMatrixDef[index16, this.data.Turn];
                  if ((double) this.combatMatrixDef[this.data.Turn, index16] > (double) num24)
                    num24 = this.combatMatrixDef[this.data.Turn, index16];
                }
                int num25 = (int) Math.Round((double) ((float) num22 * num24));
                int[] friendlyMilitaryValue = this.friendlyMilitaryValue;
                int[] numArray12 = friendlyMilitaryValue;
                int index17 = index5;
                int index18 = index17;
                int num26 = friendlyMilitaryValue[index17] + num25;
                numArray12[index18] = num26;
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap)
                  {
                    int regime = DrawMod.TGame.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime;
                    if (regime > -1)
                    {
                      if (regime != this.data.Turn)
                      {
                        int[] enemyHexes = this.enemyHexes;
                        int[] numArray13 = enemyHexes;
                        int index19 = regime;
                        int index20 = index19;
                        int num27 = enemyHexes[index19] + 1;
                        numArray13[index20] = num27;
                      }
                      if (this.data.RegimeObj[this.data.Turn].RegimeRel[regime] == 0)
                        ++num17;
                    }
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
        }
        int counter2 = simpleList3.Counter;
        for (int index21 = 0; index21 <= counter2; ++index21)
        {
          int num28 = simpleList3.Id[index21];
          int length3 = this.data.StringListObj[this.slotNeighbours].Length;
          for (int index22 = 0; index22 <= length3; ++index22)
          {
            tSlotNr = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index22, 0]));
            int num29 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index22, 1]));
            num2 = -1;
            if (tSlotNr == num28)
              num2 = num29;
            if (num29 == num28)
              num2 = tSlotNr;
            if (num2 > -1 & simpleList2.FindNr(num2) < 0)
            {
              int num30 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num2, 6)));
              if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num2, 8))) == this.RegimeId & num30 < 1)
              {
                int[] shqEmptyZones = this.shqEmptyZones;
                int[] numArray14 = shqEmptyZones;
                int index23 = index5;
                int index24 = index23;
                int num31 = shqEmptyZones[index23] + 1;
                numArray14[index24] = num31;
                simpleList2.Add(num2, 1);
              }
            }
          }
        }
        int counter3 = simpleList3.Counter;
        for (int index25 = 0; index25 <= counter3; ++index25)
        {
          int num32 = simpleList3.Id[index25];
          int length4 = this.data.StringListObj[this.slotNeighbours].Length;
          for (int index26 = 0; index26 <= length4; ++index26)
          {
            tSlotNr = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index26, 0]));
            int num33 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index26, 1]));
            num2 = -1;
            if (tSlotNr == num32)
              num2 = num33;
            if (num33 == num32)
              num2 = tSlotNr;
            if (num2 > -1)
            {
              int id4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num2, 8)));
              if (id4 != this.RegimeId & id4 > 0)
              {
                int regimeById = DrawMod.TGame.HandyFunctionsObj.GetRegimeByID(id4);
                if (regimeById > -1)
                {
                  if (Information.IsNothing((object) this.regimeZoneList[regimeById]))
                    this.regimeZoneList[regimeById] = new SimpleList();
                  this.regimeZoneList[regimeById].Add(num2, 1);
                  simpleList1.Add(num2, 1);
                }
              }
            }
          }
        }
        int regimeCounter3 = this.data.RegimeCounter;
        for (int index27 = 0; index27 <= regimeCounter3; ++index27)
        {
          if (!Information.IsNothing((object) this.regimeZoneList[index27]))
          {
            bool flag = true;
            int id5 = this.data.RegimeObj[index27].id;
            while (flag)
            {
              flag = false;
              int counter4 = this.regimeZoneList[index27].Counter;
              for (int index28 = 0; index28 <= counter4; ++index28)
              {
                int num34 = this.regimeZoneList[index27].Id[index28];
                int length5 = this.data.StringListObj[this.slotNeighbours].Length;
                for (int index29 = 0; index29 <= length5; ++index29)
                {
                  tSlotNr = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index29, 0]));
                  int num35 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotNeighbours].Data[index29, 1]));
                  num2 = -1;
                  if (tSlotNr == num34)
                    num2 = num35;
                  if (num35 == num34)
                    num2 = tSlotNr;
                  if (num2 > -1 & simpleList1.FindNr(num2) == -1)
                  {
                    int num36 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num2, 8)));
                    if (id5 == num36 && this.regimeZoneList[index27].FindNr(num2) == -1)
                    {
                      flag = true;
                      this.regimeZoneList[index27].AddWeight(num2, 1);
                      simpleList1.Add(num2, 1);
                    }
                  }
                }
              }
            }
          }
        }
        int num37 = mapWidth1;
        for (int index30 = 0; index30 <= num37; ++index30)
        {
          int num38 = mapHeight1;
          for (int index31 = 0; index31 <= num38; ++index31)
          {
            if (this.data.MapObj[0].HexObj[index30, index31].UnitCounter > -1)
            {
              int unitCounter = this.data.MapObj[0].HexObj[index30, index31].UnitCounter;
              for (int index32 = 0; index32 <= unitCounter; ++index32)
              {
                int unit = this.data.MapObj[0].HexObj[index30, index31].UnitList[index32];
                int powerPtsAbsolute = DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unit, stafftoo: false);
                if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unit))
                {
                  int[,] enemyAir = this.enemyAir;
                  int[,] numArray15 = enemyAir;
                  int index33 = index5;
                  int index34 = index33;
                  int regime = this.ai.game.Data.UnitObj[unit].Regime;
                  int index35 = regime;
                  int num39 = enemyAir[index33, regime] + powerPtsAbsolute;
                  numArray15[index34, index35] = num39;
                }
              }
            }
          }
        }
        int regimeCounter4 = this.data.RegimeCounter;
        for (int index36 = 0; index36 <= regimeCounter4; ++index36)
        {
          if (!Information.IsNothing((object) this.regimeZoneList[index36]))
          {
            int counter5 = this.regimeZoneList[index36].Counter;
            for (int index37 = 0; index37 <= counter5; ++index37)
            {
              int num40 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, this.regimeZoneList[index36].Id[index37], 1, "pop", 2)));
              tSlotNr = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index36].id, 1)));
              int[,] enemyEconomicValue = this.enemyEconomicValue;
              int[,] numArray16 = enemyEconomicValue;
              int index38 = index5;
              int index39 = index38;
              int index40 = index36;
              int index41 = index40;
              int num41 = enemyEconomicValue[index38, index40] + (10 + num40);
              numArray16[index39, index41] = num41;
            }
            int num42 = mapWidth1;
            for (int index42 = 0; index42 <= num42; ++index42)
            {
              int num43 = mapHeight1;
              for (int index43 = 0; index43 <= num43; ++index43)
              {
                if (this.data.MapObj[0].HexObj[index42, index43].UnitCounter > -1 && aiMatrix2.Value[index42, index43] > 0 && this.regimeZoneList[index36].FindNr(aiMatrix2.Value[index42, index43]) > -1)
                {
                  int unitCounter = this.data.MapObj[0].HexObj[index42, index43].UnitCounter;
                  for (int index44 = 0; index44 <= unitCounter; ++index44)
                  {
                    int unit = this.data.MapObj[0].HexObj[index42, index43].UnitList[index44];
                    int num44 = (int) Math.Round((double) ((int) Math.Round((double) (DrawMod.TGame.HandyFunctionsObj.GetPowerPtsAbsolute(unit, stafftoo: false) * DrawMod.TGame.HandyFunctionsObj.GetAverageRdn(unit)) / 100.0) * DrawMod.TGame.HandyFunctionsObj.GetAverageXp(unit)) / 30.0);
                    int num45 = (int) Math.Round((double) ((float) num44 * this.combatMatrixDef[index36, this.data.Turn]));
                    if (tSlotNr > 1)
                      num45 = (int) Math.Round((double) num45 * 0.4);
                    if (this.data.RegimeObj[this.data.Turn].RegimeRel[index36] == 0)
                    {
                      if ((double) num17 < (double) num18 / 5.0)
                        num45 = (int) Math.Round((double) num45 * 0.5);
                      else if ((double) num17 < (double) num18 / 3.0)
                        num45 = (int) Math.Round((double) num45 * 0.65);
                      else if (num17 < num18)
                        num45 = (int) Math.Round((double) num45 * 0.85);
                    }
                    int[,] militaryValueWeAtt = this.enemyMilitaryValueWeAtt;
                    int[,] numArray17 = militaryValueWeAtt;
                    int index45 = index5;
                    int index46 = index45;
                    int index47 = index36;
                    int index48 = index47;
                    int num46 = militaryValueWeAtt[index45, index47] + num45;
                    numArray17[index46, index48] = num46;
                    int[] enemyTotalValueWeAtt = this.enemyTotalValueWeAtt;
                    int[] numArray18 = enemyTotalValueWeAtt;
                    int index49 = index5;
                    int index50 = index49;
                    int num47 = enemyTotalValueWeAtt[index49] + num45;
                    numArray18[index50] = num47;
                    int num48 = (int) Math.Round((double) ((float) num44 * this.combatMatrixDef[this.data.Turn, index36]));
                    if (tSlotNr > 1)
                      num48 = (int) Math.Round((double) num48 * 0.5);
                    int[,] militaryValueWeDef = this.enemyMilitaryValueWeDef;
                    int[,] numArray19 = militaryValueWeDef;
                    int index51 = index5;
                    int index52 = index51;
                    int index53 = index36;
                    int index54 = index53;
                    int num49 = militaryValueWeDef[index51, index53] + num48;
                    numArray19[index52, index54] = num49;
                    int[] enemyTotalValueWeDef = this.enemyTotalValueWeDef;
                    int[] numArray20 = enemyTotalValueWeDef;
                    int index55 = index5;
                    int index56 = index55;
                    int num50 = enemyTotalValueWeDef[index55] + num48;
                    numArray20[index56] = num50;
                  }
                }
              }
            }
          }
        }
      }
      this.ai.AddLog("");
      int num51 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "victoryScore", 2)));
      bool[] flagArray2 = new bool[this.data.RegimeIdCounter + 999 + 1];
      int num52 = (int) Math.Round((double) num51 / 10.0);
      this.ai.AddLog("AI Loyal Effects for " + this.data.RegimeObj[this.data.Turn].Name + " ... vicScore=" + num52.ToString() + " ... aifear = " + this.aiFear.ToString() + " .... baseAiLoyal = " + this.aiLoyal.ToString());
      flagArray2[0] = true;
      flagArray2[1] = true;
      int regimeCounter5 = this.data.RegimeCounter;
      for (int index = 2; index <= regimeCounter5; ++index)
      {
        if (index != this.data.Turn)
        {
          int num53 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.data.RegimeObj[index].id, 1, "victoryScore", 2)));
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index].id, 1))) == 1)
          {
            num53 = (int) Math.Round((double) num53 / 10.0);
            int num54 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[index].id, 2, "relation", 3)));
            num2 = num53 - num52;
            int num55 = this.aiLoyal + num2;
            if (num1 >= 10 & this.data.Round > 50)
              num55 -= 5;
            if (num1 >= 10 & this.data.Round > 100)
              num55 -= 5;
            if (num1 >= 10 & this.data.Round > 150)
              num55 -= 5;
            if (num1 >= 20 & this.data.Round > 20)
              num55 -= 5;
            if (num1 >= 20 & this.data.Round > 80)
              num55 -= 5;
            if (num1 >= 20 & this.data.Round > 140)
              num55 -= 5;
            if (num1 >= 30 & this.data.Round > 60)
              num55 -= 5;
            if (num1 >= 30 & this.data.Round > 120)
              num55 -= 5;
            if (num1 >= 30 & this.data.Round > 180)
              num55 -= 5;
            bool flag = true;
            if (num55 >= 110 & num54 >= 30)
              flag = false;
            if (num55 >= 100 & num54 >= 40)
              flag = false;
            if (num55 >= 90 & num54 >= 50)
              flag = false;
            if (num55 >= 80 & num54 >= 60)
              flag = false;
            if (num55 >= 70 & num54 >= 70)
              flag = false;
            if (num55 >= 60 & num54 >= 80)
              flag = false;
            if (num55 >= 50 & num54 >= 90)
              flag = false;
            if (num55 >= 40 & num54 >= 100)
              flag = false;
            flagArray2[index] = flag;
            this.ai.AddLog(this.data.RegimeObj[index].Name + " ... rel=" + num54.ToString() + "... vicScore= " + num53.ToString() + " ... modAIloyal=" + num55.ToString() + " .... canAttack = " + flag.ToString());
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[index].id, 2, "lastLookForPeace", 3))) < 100 & !flag)
            {
              int setValue = 100;
              this.data.StringListObj[this.slotRegRegKeys].SetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[index].id, 2, "lastLookForPeace", 3, setValue, true);
            }
          }
          else
            flagArray2[index] = true;
        }
      }
      this.ai.AddLog("");
      SimpleList simpleList4 = new SimpleList();
      int counter6 = this.ShqList.Counter;
      for (int index = 0; index <= counter6; ++index)
      {
        int regimeCounter6 = this.data.RegimeCounter;
        for (int tid = 2; tid <= regimeCounter6; ++tid)
        {
          if (this.enemyMilitaryValueWeAtt[index, tid] > 0 | this.enemyEconomicValue[index, tid] > 0)
            simpleList4.Add(tid, 1);
        }
      }
      int num56 = -99999;
      simpleList4.Clone();
      SimpleList simpleList5 = simpleList4.Clone();
      int[] numArray21 = new int[simpleList5.Counter + 1];
      int counter7 = simpleList5.Counter;
      for (int index = 0; index <= counter7; ++index)
      {
        int num57 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[simpleList5.Id[index]].id, 2, "aiPrevIntentionChanger", 3)));
        simpleList5.Data1[index] = num57;
        numArray21[index] = num57;
        if (this.data.RegimeObj[simpleList5.Id[index]].RegimeRel[this.data.Turn] == 0)
          ;
      }
      int num58 = 100;
      int num59 = num58;
      int index57;
      int tid1;
      int index58;
      for (int index59 = 1; index59 <= num59; ++index59)
      {
        int num60 = 0;
        int counter8 = this.ShqList.Counter;
        string s;
        for (index57 = 0; index57 <= counter8; ++index57)
        {
          string str6 = "STEP " + index59.ToString() + "." + index57.ToString() + " : ";
          int val2_1 = 0;
          int val2_2 = 0;
          int num61 = 0;
          int num62 = 0;
          int num63 = 0;
          int shqEmptyZone = this.shqEmptyZones[index57];
          int regimeCounter7 = this.data.RegimeCounter;
          for (int tid2 = 2; tid2 <= regimeCounter7; ++tid2)
          {
            tid1 = simpleList5.FindNr(tid2);
            int index60 = tid1;
            bool flag1 = false;
            bool flag2 = false;
            int num64 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid2].id, 1)));
            if (tid1 > -1)
            {
              index58 = simpleList5.Data1[tid1];
              if (flagArray1[tid2])
                flag2 = true;
              if (index58 == 2)
                flag2 = true;
              if (index58 == 1)
                flag2 = false;
              flag1 = true;
            }
            else if (tid2 == this.data.Turn)
              flag1 = true;
            if (flag1)
            {
              string str7 = str6 + this.data.RegimeObj[tid2].Name + " => StartModdy=100, ";
              bool flag3 = false;
              float num65 = 100f;
              float[] numArray22 = new float[10];
              int index61 = 0;
              do
              {
                numArray22[index61] = 0.0f;
                ++index61;
              }
              while (index61 <= 9);
              int length6 = this.data.StringListObj[this.slotZones].Length;
              for (int index62 = 0; index62 <= length6; ++index62)
              {
                if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index62, 8])) == this.data.RegimeObj[tid2].id)
                {
                  int num66 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index62, 0]));
                  int num67 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index62, 6]));
                  int val1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num66, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num66, 1, "worker", 2)));
                  if (num67 > 0)
                    flag3 = true;
                  if (tid2 != this.data.Turn)
                  {
                    if (numArray2[index57] > 0)
                    {
                      float num68 = (float) (100.0 * Math.Sqrt((double) numArray2[index57] / 10.0) * ((double) zoneFoodRankingList.FindWeight(num66) / 100.0));
                      if ((double) num68 > (double) numArray22[0])
                        numArray22[0] = num68;
                    }
                    if (numArray4[index57] > 0)
                    {
                      float num69 = (float) (100.0 * Math.Sqrt((double) numArray4[index57] / 10.0) * ((double) zoneMineRankingList1.FindWeight(num66) / 100.0));
                      if ((double) num69 > (double) numArray22[1])
                        numArray22[1] = num69;
                    }
                    if (numArray5[index57] > 0)
                    {
                      float num70 = (float) (100.0 * Math.Sqrt((double) numArray5[index57] / 10.0) * ((double) zoneMineRankingList2.FindWeight(num66) / 100.0));
                      if ((double) num70 > (double) numArray22[2])
                        numArray22[2] = num70;
                    }
                    if (numArray6[index57] > 0)
                    {
                      float num71 = (float) (100.0 * Math.Sqrt((double) numArray6[index57] / 10.0) * ((double) zoneMineRankingList3.FindWeight(num66) / 100.0));
                      if ((double) num71 > (double) numArray22[3])
                        numArray22[3] = num71;
                    }
                    if (numArray7[index57] > 0)
                    {
                      float num72 = (float) (100.0 * Math.Sqrt((double) numArray7[index57] / 10.0) * ((double) zoneMineRankingList4.FindWeight(num66) / 100.0));
                      if ((double) num72 > (double) numArray22[4])
                        numArray22[4] = num72;
                    }
                    if (numArray3[index57] > 0)
                    {
                      float num73 = (float) (100.0 * Math.Sqrt((double) numArray3[index57] / 10.0) * ((double) zoneMineRankingList5.FindWeight(num66) / 100.0));
                      if ((double) num73 > (double) numArray22[5])
                        numArray22[5] = num73;
                    }
                  }
                  if (val1 > 10)
                  {
                    float num74 = 25f + (float) (75.0 * ((double) Math.Min(val1, zonePopRankingList1.FindWeight(num66)) / 100.0));
                    if ((double) num74 > (double) numArray22[6])
                      numArray22[6] = num74;
                  }
                  if (zonePopRankingList2.FindWeight(num66) > 0)
                  {
                    float num75 = (float) (100.0 * ((double) zonePopRankingList2.FindWeight(num66) / 100.0));
                    if ((double) num75 > (double) numArray22[7])
                      numArray22[7] = num75;
                  }
                }
              }
              if (numArray2[index57] > 0 && (double) numArray22[0] > 0.0)
              {
                num65 = (float) ((double) num65 * (double) numArray22[0] / 100.0);
                str7 = str7 + "After FoodMod=" + num65.ToString() + ",";
              }
              if (numArray4[index57] > 0 && (double) numArray22[0] > 0.0)
              {
                num65 = (float) ((double) num65 * (double) numArray22[1] / 100.0);
                str7 = str7 + "After MetalMod=" + num65.ToString() + ",";
              }
              if (numArray5[index57] > 0 && (double) numArray22[0] > 0.0)
              {
                num65 = (float) ((double) num65 * (double) numArray22[2] / 100.0);
                str7 = str7 + "After OilMod=" + num65.ToString() + ",";
              }
              if (numArray6[index57] > 0 && (double) numArray22[0] > 0.0)
              {
                num65 = (float) ((double) num65 * (double) numArray22[3] / 100.0);
                str7 = str7 + "After RareMod=" + num65.ToString() + ",";
              }
              if (numArray7[index57] > 0 && (double) numArray22[0] > 0.0)
              {
                num65 = (float) ((double) num65 * (double) numArray22[4] / 100.0);
                str7 = str7 + "After RadioMod=" + num65.ToString() + ",";
              }
              if (numArray3[index57] > 0 && (double) numArray22[0] > 0.0)
              {
                num65 = (float) ((double) num65 * (double) numArray22[5] / 100.0);
                str7 = str7 + "After WaterMod=" + num65.ToString() + ",";
              }
              float num76 = (float) ((double) num65 * (double) numArray22[6] / 100.0);
              string str8 = str7 + "After PopMod=" + num76.ToString() + ",";
              float num77 = (float) ((double) num76 * (double) numArray22[7] / 100.0);
              string str9 = str8 + "After ClosePopMod=" + num77.ToString() + ". ";
              if (flag2)
              {
                if (!flag3 & num64 <= 2)
                  ++shqEmptyZone;
                tid1 = 1 + (int) Math.Round((double) this.friendlyMilitaryValue[index57] / 10.0) + this.enemyMilitaryValueWeAtt[index57, tid2];
                int num78 = 1 + (int) Math.Round((double) this.friendlyMilitaryValue[index57] / 10.0) + this.enemyMilitaryValueWeDef[index57, tid2];
                index58 = (int) Math.Round((double) this.enemyEconomicValue[index57, tid2] * (double) num77 / 100.0);
                if (index58 < 4)
                  index58 = 4;
                if (num64 == 1 & num1 <= 10)
                {
                  if (this.ai.game.Data.RegimeObj[tid2].AI)
                  {
                    if (this.data.Round < 10)
                    {
                      tid1 = (int) Math.Round((double) tid1 / 0.33);
                      num78 = (int) Math.Round((double) num78 / 0.33);
                    }
                    else if (this.data.Round < 20)
                    {
                      tid1 = (int) Math.Round((double) tid1 / 0.5);
                      num78 = (int) Math.Round((double) num78 / 0.5);
                    }
                    else if (this.data.Round < 30)
                    {
                      tid1 = (int) Math.Round((double) tid1 / 0.66);
                      num78 = (int) Math.Round((double) num78 / 0.66);
                    }
                    else if (this.data.Round >= 50)
                    {
                      if (this.data.Round < 70)
                      {
                        tid1 = (int) Math.Round((double) tid1 / 1.2);
                        num78 = (int) Math.Round((double) num78 / 1.2);
                      }
                      else if (this.data.Round < 120)
                      {
                        tid1 = (int) Math.Round((double) tid1 / 1.4);
                        num78 = (int) Math.Round((double) num78 / 1.4);
                      }
                      else if (this.data.Round < 200)
                      {
                        tid1 = (int) Math.Round((double) tid1 / 1.6);
                        num78 = (int) Math.Round((double) num78 / 1.6);
                      }
                      else
                      {
                        tid1 = (int) Math.Round((double) tid1 / 2.0);
                        num78 = (int) Math.Round((double) num78 / 2.0);
                      }
                    }
                  }
                  else if (this.data.Round < 10)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.2);
                    num78 = (int) Math.Round((double) num78 / 0.2);
                  }
                  else if (this.data.Round < 20)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.3);
                    num78 = (int) Math.Round((double) num78 / 0.3);
                  }
                  else if (this.data.Round < 30)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.4);
                    num78 = (int) Math.Round((double) num78 / 0.4);
                  }
                  else if (this.data.Round < 40)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.5);
                    num78 = (int) Math.Round((double) num78 / 0.5);
                  }
                  else if (this.data.Round < 50)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.6);
                    num78 = (int) Math.Round((double) num78 / 0.6);
                  }
                  else if (this.data.Round < 60)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.7);
                    num78 = (int) Math.Round((double) num78 / 0.7);
                  }
                  else if (this.data.Round < 70)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.8);
                    num78 = (int) Math.Round((double) num78 / 0.8);
                  }
                  else if (this.data.Round < 80)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 0.9);
                    num78 = (int) Math.Round((double) num78 / 0.9);
                  }
                  else if (this.data.Round >= 120)
                  {
                    if (this.data.Round < 170)
                    {
                      tid1 = (int) Math.Round((double) tid1 / 1.2);
                      num78 = (int) Math.Round((double) num78 / 1.2);
                    }
                    else if (this.data.Round < 230)
                    {
                      tid1 = (int) Math.Round((double) tid1 / 1.4);
                      num78 = (int) Math.Round((double) num78 / 1.4);
                    }
                    else
                    {
                      tid1 = (int) Math.Round((double) tid1 / 1.6);
                      num78 = (int) Math.Round((double) num78 / 1.6);
                    }
                  }
                }
                else if (num64 == 1 & num1 > 10 && this.data.Round >= 50)
                {
                  if (this.data.Round < 100)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 1.2);
                    num78 = (int) Math.Round((double) num78 / 1.2);
                  }
                  else if (this.data.Round < 150)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 1.4);
                    num78 = (int) Math.Round((double) num78 / 1.4);
                  }
                  else if (this.data.Round < 200)
                  {
                    tid1 = (int) Math.Round((double) tid1 / 1.6);
                    num78 = (int) Math.Round((double) num78 / 1.6);
                  }
                  else
                  {
                    tid1 = (int) Math.Round((double) tid1 / 1.8);
                    num78 = (int) Math.Round((double) num78 / 1.8);
                  }
                }
                if (numArray21[index60] == 2 & flag2)
                {
                  tid1 = (int) Math.Round((double) tid1 * 0.75);
                  num78 = (int) Math.Round((double) num78 * 0.75);
                }
                if (num64 == 1)
                {
                  tid1 = (int) Math.Round((double) (tid1 * 100) / (double) this.aiHawk);
                  num78 = (int) Math.Round((double) (tid1 * 100) / (double) this.aiHawk);
                }
                if (num64 == 1 && num1 == 0)
                {
                  tid1 = (int) Math.Round((double) tid1 * 1.33);
                  num78 = (int) Math.Round((double) num78 * 1.33);
                }
                if (num64 == 1 & this.data.Round > 3 & !flagArray2[tid2])
                {
                  int num79 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.data.RegimeObj[this.data.Turn].id, 1, "victoryScore", 2)));
                  int num80 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.data.RegimeObj[tid2].id, 1, "victoryScore", 2)));
                  int num81 = (int) Math.Round((double) num79 / 10.0);
                  int num82 = (int) Math.Round((double) num80 / 10.0);
                  int num83 = new Random((int) Math.Round((double) this.data.GameID / 4.0) + this.data.RegimeObj[tid2].id * 20).Next(0, 20) - 10;
                  if (this.aiLoyal > 100)
                    num83 += 10;
                  if (this.aiLoyal > 66)
                    num83 += 10;
                  int num84 = num81 - num82;
                  if (num82 > 50 + num83)
                  {
                    if (num84 < -10)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.25);
                      num78 = (int) Math.Round((double) num78 * 0.25);
                    }
                    else if (num84 < 0)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.6);
                      num78 = (int) Math.Round((double) num78 * 0.6);
                    }
                    else if (num81 + num82 > 85)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.4);
                      num78 = (int) Math.Round((double) num78 * 0.4);
                    }
                    else if (num81 + num82 > 70)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.6);
                      num78 = (int) Math.Round((double) num78 * 0.6);
                    }
                    else if (num81 + num82 > 50)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.8);
                      num78 = (int) Math.Round((double) num78 * 0.8);
                    }
                  }
                  else if (num82 > 40 + num83)
                  {
                    if (num84 < -10)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.5);
                      num78 = (int) Math.Round((double) num78 * 0.5);
                    }
                    else if (num84 < 0)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.75);
                      num78 = (int) Math.Round((double) num78 * 0.75);
                    }
                    else if (num81 + num82 > 85)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.6);
                      num78 = (int) Math.Round((double) num78 * 0.6);
                    }
                    else if (num81 + num82 > 70)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.75);
                      num78 = (int) Math.Round((double) num78 * 0.75);
                    }
                    else if (num81 + num82 > 50)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.9);
                      num78 = (int) Math.Round((double) num78 * 0.9);
                    }
                  }
                  else if (num82 > 30 + num83)
                  {
                    if (num84 < -10)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.7);
                      num78 = (int) Math.Round((double) num78 * 0.7);
                    }
                    else if (num84 < 0)
                    {
                      tid1 = (int) Math.Round((double) tid1 * 0.85);
                      num78 = (int) Math.Round((double) num78 * 0.85);
                    }
                  }
                }
                val2_2 += tid1;
                val2_1 += num78;
                num2 = tid1;
                str9 = str9 + "... enemyWeAtt = " + tid1.ToString() + ", enemyWeDef = " + num78.ToString() + ", economic value = " + this.enemyEconomicValue[index57, tid2].ToString() + ", prize = " + index58.ToString();
                if (num64 > 1)
                {
                  if (numArray1[tid2] <= 2)
                  {
                    index58 *= 4;
                    index58 += 100;
                  }
                  else if (numArray1[tid2] <= 4)
                  {
                    index58 *= 3;
                    index58 += 50;
                  }
                  else if (numArray1[tid2] <= 8)
                  {
                    index58 *= 2;
                    index58 += 25;
                  }
                }
                else if (num64 == 1)
                {
                  if (numArray1[tid2] <= 2)
                  {
                    index58 *= 2;
                    index58 += 50;
                  }
                  else if (numArray1[tid2] <= 4)
                  {
                    index58 = (int) Math.Round((double) index58 * 1.5);
                    index58 += 25;
                  }
                  else if (numArray1[tid2] <= 8)
                  {
                    index58 = (int) Math.Round((double) index58 * 1.25);
                    index58 += 10;
                  }
                }
                num61 += index58;
                int num85 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid2].id, 2, "aiIntention", 3)));
                num62 += 1 + num2 * num85;
              }
              else if (tid2 == this.data.Turn)
              {
                tid1 = (int) Math.Round((double) this.friendlyEconomicValue[index57] * (double) num77 / 100.0);
                tid1 = (int) Math.Round((double) (tid1 * this.aiFear) / 100.0);
                num63 += tid1;
                str9 = str9 + "...  friendly economic value = " + this.friendlyEconomicValue[index57].ToString() + ", prize = " + ((int) Math.Round((double) this.friendlyEconomicValue[index57] * (double) num77 / 100.0)).ToString();
              }
              str6 = str9 + "\r\n";
            }
          }
          int num86 = 0;
          string str10 = str6 + "totalEnemyWeAtt = " + val2_2.ToString() + ", totalEnemyWeDef = " + val2_1.ToString();
          if (val2_2 > 0)
          {
            int num87 = (int) Math.Round((double) num62 / (double) val2_2);
            string str11 = str10 + ", totalAIintention = " + num87.ToString() + " ";
            int num88 = this.friendlyMilitaryValue[index57];
            str10 = str11 + ", forcePresent = " + num88.ToString() + ", " + "\r\n";
            int num89;
            if (num88 > val2_2 & num61 > 0)
            {
              string str12 = str10 + "Friendlies win." + "ModScore = ";
              float num90 = (float) Math.Min(3.0, (double) num88 / (double) Math.Max(1, val2_2));
              num89 = num61;
              string str13 = str12 + num89.ToString() + " ";
              num89 = (int) Math.Round((double) ((float) num89 * num90));
              string str14 = str13 + ", " + num89.ToString() + " ";
              num86 += num89;
              num86 += 5;
              str10 = str14 + "... Score = " + num86.ToString();
            }
            else if (val2_1 > 0)
            {
              string str15 = str10 + "Enemies win." + "ModScore = ";
              float num91 = (float) Math.Min(3.0, (double) Math.Max(1, val2_1) / (double) num88);
              num89 = num63;
              string str16 = str15 + num89.ToString() + " ";
              num89 = (int) Math.Round((double) ((float) num89 * num91));
              string str17 = str16 + ", " + num89.ToString() + " ";
              num86 -= num89;
              num86 -= 5;
              str10 = str17 + "... Score = " + num86.ToString();
            }
            num89 = Math.Abs(num86);
            if (shqEmptyZone > 1)
            {
              num89 = (int) Math.Round((double) num86 * ((double) (shqEmptyZone - 0) / 3.0));
              num86 -= Math.Abs(num89);
              str10 = str10 + ", (withoutcities) " + num86.ToString() + " ";
            }
          }
          num60 += num86;
          s = str10 + "... SCORE = " + num86.ToString() + "... ALLSCORE = " + num60.ToString() + "\r\n";
        }
        if (num60 > num56)
        {
          num56 = num60;
          simpleList4 = simpleList5.Clone();
          this.ai.AddLog("********NEW BEST SCORE (see below for details ) STEP " + index59.ToString() + ", SCORE: " + num60.ToString());
          this.ai.AddLog(s);
          this.ai.AddLog("******* NEW BEST SCORE (see below for resulting plan) STEP " + index59.ToString() + ", SCORE: " + num60.ToString() + " *****************");
          int regimeCounter8 = this.data.RegimeCounter;
          for (int tid3 = 0; tid3 <= regimeCounter8; ++tid3)
          {
            tid1 = simpleList5.FindNr(tid3);
            if (tid1 > -1)
            {
              index58 = simpleList5.Data1[tid1];
              bool flag4 = false;
              bool flag5 = false;
              bool flag6 = false;
              if (this.data.RegimeObj[this.data.Turn].RegimeRel[tid3] == 0)
                flag4 = true;
              if (index58 == 2)
                flag5 = true;
              if (index58 == 1)
                flag6 = true;
              if (!flag4)
              {
                if (flag5)
                  this.ai.AddLog(this.data.RegimeObj[tid3].Name + " CURRENT REL: PEACE, DESIRE: WAR");
                else if (flag6)
                  this.ai.AddLog(this.data.RegimeObj[tid3].Name + " CURRENT REL: PEACE, DESIRE: PEACE");
                else
                  this.ai.AddLog(this.data.RegimeObj[tid3].Name + " CURRENT REL: PEACE, DESIRE: -");
              }
              else if (flag5)
                this.ai.AddLog(this.data.RegimeObj[tid3].Name + " CURRENT REL: WAR, DESIRE: WAR");
              else if (flag6)
                this.ai.AddLog(this.data.RegimeObj[tid3].Name + " CURRENT REL: WAR, DESIRE: PEACE");
              else
                this.ai.AddLog(this.data.RegimeObj[tid3].Name + " CURRENT REL: WAR, DESIRE: -");
            }
          }
          this.ai.AddLog("**************************");
        }
        else if (index59 <= 10)
        {
          this.ai.AddLog("");
          this.ai.AddLog("******** not new best score (see below for details ) STEP " + index59.ToString() + ", SCORE: " + num60.ToString());
          this.ai.AddLog(s);
          this.ai.AddLog("*******  not new best score, BUT SHOW LOGS... STEP " + index59.ToString() + ", SCORE: " + num60.ToString());
          this.ai.AddLog("");
          this.ai.AddLog(s);
          this.ai.AddLog("");
          int regimeCounter9 = this.data.RegimeCounter;
          for (int tid4 = 0; tid4 <= regimeCounter9; ++tid4)
          {
            tid1 = simpleList5.FindNr(tid4);
            if (tid1 > -1)
            {
              index58 = simpleList5.Data1[tid1];
              bool flag7 = false;
              bool flag8 = false;
              bool flag9 = false;
              if (this.data.RegimeObj[this.data.Turn].RegimeRel[tid4] == 0)
                flag7 = true;
              if (index58 == 2)
                flag8 = true;
              if (index58 == 1)
                flag9 = true;
              if (!flag7)
              {
                if (flag8)
                  this.ai.AddLog(this.data.RegimeObj[tid4].Name + " CURRENT REL: PEACE, DESIRE: WAR");
                else if (flag9)
                  this.ai.AddLog(this.data.RegimeObj[tid4].Name + " CURRENT REL: PEACE, DESIRE: PEACE");
                else
                  this.ai.AddLog(this.data.RegimeObj[tid4].Name + " CURRENT REL: PEACE, DESIRE: -");
              }
              else if (flag8)
                this.ai.AddLog(this.data.RegimeObj[tid4].Name + " CURRENT REL: WAR, DESIRE: WAR");
              else if (flag9)
                this.ai.AddLog(this.data.RegimeObj[tid4].Name + " CURRENT REL: WAR, DESIRE: PEACE");
              else
                this.ai.AddLog(this.data.RegimeObj[tid4].Name + " CURRENT REL: WAR, DESIRE: -");
            }
          }
        }
        else
          this.ai.AddLog("not new best score, loop=" + index59.ToString() + ", SCORE: " + num60.ToString());
        simpleList5 = simpleList4.Clone();
        int num92 = Math.Min(1 + (int) Math.Round((double) simpleList5.Counter / 2.0), 3);
        int num93 = DrawMod.RandyNumber.Next(1, num92 + 1);
        if ((double) index59 < (double) num58 * 0.25)
        {
          num93 = 1;
          int counter9 = simpleList5.Counter;
          for (int index63 = 0; index63 <= counter9; ++index63)
            simpleList5.Data1[index63] = 0;
        }
        int num94 = (double) index59 >= (double) num58 * 0.5 ? ((double) index59 >= (double) num58 * 0.66 ? ((double) index59 >= (double) num58 * 0.8 ? 6 : 4) : 2) : 1;
        for (int index64 = 1; index64 <= num94; ++index64)
        {
          tid1 = simpleList5.GetRandomIdbasedOnWeight();
          index58 = simpleList5.FindNr(tid1);
          if (index58 > -1)
          {
            simpleList5.Data1[index58] = !flagArray1[tid1] ? 2 : 1;
            if (!flagArray1[tid1] & !flagArray2[tid1])
              simpleList5.Data1[index58] = 0;
          }
        }
      }
      bool flag10 = false;
      int num95 = 0;
      int num96 = -1;
      int num97 = 100 - this.aiHawk;
      int num98 = 0;
      int num99 = 0;
      int num100 = 0;
      int num101 = 0;
      int num102 = 0;
      int counter10 = this.ShqList.Counter;
      for (index57 = 0; index57 <= counter10; ++index57)
        num98 += this.friendlyMilitaryValue[index57];
      int counter11 = simpleList5.Counter;
      for (int index65 = 0; index65 <= counter11; ++index65)
      {
        tid1 = simpleList5.Id[index65];
        if (tid1 > -1)
        {
          int num103 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1)));
          if (num103 == 1 && flagArray1[tid1])
            ++num102;
          if (num103 == 2)
          {
            if (flagArray1[tid1])
            {
              flag10 = true;
              index58 = 0;
              int counter12 = this.ShqList.Counter;
              for (index57 = 0; index57 <= counter12; ++index57)
                index58 += this.enemyMilitaryValueWeAtt[index57, tid1];
              num95 += index58;
              if ((double) index58 > (double) num98 / 40.0 | this.data.Round < 20)
                ++num101;
            }
            index58 = 0;
            int counter13 = this.ShqList.Counter;
            for (index57 = 0; index57 <= counter13; ++index57)
              index58 += this.enemyEconomicValue[index57, tid1];
            if (!flagArray1[tid1] && index58 > num97)
            {
              num97 = index58;
              num96 = tid1;
            }
          }
          if (simpleList4.FindData(tid1, 1) == 2)
          {
            switch (num103)
            {
              case 1:
                ++num100;
                continue;
              case 2:
                ++num99;
                continue;
              default:
                continue;
            }
          }
        }
      }
      if (num101 * 2 >= num99)
      {
        int counter14 = simpleList4.Counter;
        for (int index66 = 0; index66 <= counter14; ++index66)
        {
          if (simpleList4.Data1[index66] == 2)
          {
            tid1 = simpleList5.Id[index66];
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1))) == 2)
              simpleList4.Data1[index66] = 0;
          }
        }
      }
      else
      {
        int num104 = 1;
        SimpleList simpleList6 = new SimpleList();
        int counter15 = simpleList4.Counter;
        for (int index67 = 0; index67 <= counter15; ++index67)
        {
          if (simpleList4.Data1[index67] == 2)
          {
            tid1 = simpleList4.Id[index67];
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1))) == 2)
            {
              index58 = 0;
              int counter16 = this.ShqList.Counter;
              for (index57 = 0; index57 <= counter16; ++index57)
                index58 += this.enemyEconomicValue[index57, tid1];
              simpleList6.AddWeight(tid1, index58);
            }
          }
        }
        if (simpleList6.Counter >= num104)
        {
          simpleList6.ReverseSort();
          int num105 = num104;
          int counter17 = simpleList6.Counter;
          for (index57 = num105; index57 <= counter17; ++index57)
          {
            if (simpleList6.Id[index57] == num96)
              num96 = simpleList6.Id[0];
            int nr = simpleList4.FindNr(simpleList6.Id[index57]);
            if (nr > -1)
              simpleList4.Data1[nr] = 0;
          }
        }
      }
      if (flag10 & num95 > (int) Math.Round((double) num98 / (double) (2 * (simpleList5.Counter + 2))))
        num96 = -1;
      int counter18 = simpleList4.Counter;
      for (int index68 = 0; index68 <= counter18; ++index68)
      {
        tid1 = simpleList4.Id[index68];
        int num106 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1)));
        index58 = simpleList4.Data1[index68];
        int num107 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiIntention", 3)));
        int num108 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiHatred", 3)));
        int num109 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiLove", 3)));
        num2 = num107;
        bool flag11 = false;
        bool flag12 = false;
        bool flag13 = false;
        if (this.data.RegimeObj[this.data.Turn].RegimeRel[tid1] == 0)
          flag11 = true;
        if (index58 == 2)
          flag12 = true;
        if (index58 == 1)
          flag13 = true;
        if (flag11)
        {
          if (flag12)
          {
            if (num107 > 20)
              num107 -= (int) Math.Round((double) (10 * this.aiHawk) / 100.0);
            if (num107 > 50)
              num107 -= 3;
            if (num107 > 40)
              num107 -= 2;
            if (num107 > 20)
              --num107;
          }
          else if (flag13)
          {
            if (num107 < 50)
              num107 += (int) Math.Round((double) (10 * this.aiFear) / 100.0);
          }
          else if (num107 > 20)
            num107 -= (int) Math.Round((double) (10 * this.aiHawk) / 100.0);
        }
        else if (flag12)
        {
          if (num107 > 20)
            num107 -= (int) Math.Round((double) (10 * this.aiHawk) / 100.0);
          if (num107 > 50)
            num107 -= 3;
          if (num107 > 40)
            num107 -= 2;
          if (num107 > 20)
            --num107;
        }
        else if (flag13)
        {
          if (num107 < 80)
            num107 += (int) Math.Round((double) (10 * this.aiFear) / 100.0);
        }
        else if (num107 < 80)
          num107 += (int) Math.Round((double) (10 * this.aiFear) / 100.0);
        this.data.StringListObj[this.slotRegRegKeys].SetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiPrevIntentionChanger", 3, index58, true);
        if (num107 < num109)
          num107 = num109;
        if (num107 > 100 - num108)
          num107 = 100 - num108;
        if (num107 < 0)
          num107 = 0;
        if (num107 > 100)
          num107 = 100;
        int num110 = 0;
        int num111 = 0;
        int counter19 = this.ShqList.Counter;
        for (index57 = 0; index57 <= counter19; ++index57)
        {
          num110 += (int) Math.Round((double) (this.enemyMilitaryValueWeDef[index57, tid1] + this.enemyMilitaryValueWeAtt[index57, tid1]) / 2.0);
          num111 += this.friendlyMilitaryValueUnMod[index57];
        }
        if (num111 < 1)
          num111 = 1;
        int num112 = (int) Math.Round((double) (100 * num110) / (double) num111);
        int num113 = num112 > 50 ? (num112 > 100 ? (num112 > 150 ? (num112 > 200 ? (num112 > 300 ? (num112 > 400 ? 100 : 90) : 80) : 70) : 60) : 50) : 40;
        if (num107 > num113)
          num107 = num113;
        if (num106 == 1 & !flag11 & !flag12)
        {
          int num114 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "relation", 3)));
          if (!flagArray2[tid1])
            num107 = num114;
        }
        int setValue1 = num107;
        if (this.data.StringListObj[this.slotRegimes].Width >= 13)
        {
          int idValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 13)));
          if (idValue > 0)
          {
            int d = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotImod].GetData(0, idValue, 7)));
            int factionId = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotFactions].GetData2(12, idValue, 3, this.data.RegimeObj[this.data.Turn].id, 0)));
            num106 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1)));
            if (num106 == 1)
              setValue1 += d;
            else if (d < 1)
              setValue1 -= (int) Math.Round(Math.Sqrt((double) Math.Abs(d)));
            else if (d > 0)
              setValue1 += (int) Math.Round(Math.Sqrt((double) d));
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1))) == 1)
            {
              SimpleStringList ProfL = new SimpleStringList();
              int length7 = this.data.StringListObj[this.slotProfileDoc].Length;
              for (index57 = 0; index57 <= length7; ++index57)
              {
                if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotProfileDoc].Data[index57, 2])) == 1)
                {
                  string str18 = this.data.StringListObj[this.slotProfileDoc].Data[index57, 0];
                  int tweight = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, this.data.RegimeObj[tid1].id, 1, str18, 2)));
                  ProfL.Add(str18, tweight);
                }
              }
              int num115 = 100 + this.ai.game.EventRelatedObj.Helper_GetSimilarityWithFaction(ProfL, factionId) * 10;
              if (num115 < 0)
                num115 = 0;
              if (num115 > 100)
                num115 = 100;
              setValue1 = (int) Math.Round((double) setValue1 * ((double) num115 / 100.0));
            }
          }
        }
        if (num106 == 1)
        {
          if (!flag11 & !flag12 && setValue1 < 40)
            setValue1 = 40;
          if (!flag11 & flag12 && setValue1 > 20)
            setValue1 = 20;
          if (flag11 & (flag13 | !flag12) && setValue1 < 30)
            setValue1 = 30;
          if (flag11 & !flag13 & flag12 && setValue1 > 10)
            setValue1 = 10;
        }
        if (num96 == tid1 & flag12)
          setValue1 = 0;
        if (setValue1 < 0)
          setValue1 = 0;
        if (setValue1 > 100)
          setValue1 = 100;
        this.data.StringListObj[this.slotRegRegKeys].SetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiIntention", 3, setValue1);
        int num116 = setValue1 - num2;
        this.ai.AddLog("AI Relation Objective with " + this.data.RegimeObj[tid1].Name + " changed with " + num116.ToString() + " to = " + setValue1.ToString());
        if (this.data.RegimeObj[this.data.Turn].AI && this.data.RegimeObj[tid1].AI && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1))) == 1)
        {
          int num117 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "relation", 3)));
          if (num117 > setValue1)
          {
            int setValue2 = num117 - 10;
            if (setValue2 < 0)
              setValue2 = 0;
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "relation", 3, setValue2);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, this.data.RegimeObj[tid1].id, 1, this.data.RegimeObj[this.data.Turn].id, 2, "relation", 3, setValue2);
          }
        }
      }
      this.ai.WriteLog(str1);
    }

    public void GetSHQgroupsAndStagesAndOobAndSHQchanges()
    {
      bool flag1 = true;
      DrawMod.TGame.ProcessingObj.LIS_SetNetwork(false, true);
      int num1 = 0;
      while (flag1)
      {
        flag1 = false;
        ++num1;
        this.ShqList = new SimpleList();
        int length1 = this.data.StringListObj[this.slotZones].Length;
        int index1;
        for (int index2 = 0; index2 <= length1; ++index2)
        {
          int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 6]));
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index2, 8])) == this.RegimeId && id > 0)
          {
            index1 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
            if (index1 > -1 && this.data.MapObj[0].HexObj[this.data.LocObj[index1].X, this.data.LocObj[index1].Y].Regime == this.data.Turn)
            {
              int hq = this.data.LocObj[index1].HQ;
              if (hq > -1)
              {
                int historical = this.data.UnitObj[hq].Historical;
                if (historical > -1)
                  this.ShqList.AddWeight(this.data.HistoricalUnitObj[historical].ID, 1);
              }
            }
          }
        }
        int counter1 = this.ShqList.Counter;
        int num2;
        for (int index3 = 0; index3 <= counter1; ++index3)
        {
          int[] numArray1 = new int[100];
          int length2 = this.data.StringListObj[this.slotZones].Length;
          for (int index4 = 0; index4 <= length2; ++index4)
          {
            num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index4, 0]));
            int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index4, 6]));
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index4, 8])) == this.RegimeId && id > 0)
            {
              this.ai.game.HandyFunctionsObj.GetLocationByID(id);
              EventRelatedClass eventRelatedObj = this.ai.game.EventRelatedObj;
              int onlyZoneId = num2;
              SimpleList simpleList1 = (SimpleList) null;
              ref SimpleList local1 = ref simpleList1;
              SimpleList simpleList2 = (SimpleList) null;
              ref SimpleList local2 = ref simpleList2;
              eventRelatedObj.ExecMakeAssetPresentation("SE_Data", 0, -1, onlyZoneId, "", itemsProdModList: (ref local1), itemsUpkeepModList: (ref local2));
              int length3 = this.data.StringListObj[this.slotAssetPresentation].Length;
              for (int index5 = 0; index5 <= length3; ++index5)
              {
                int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index5, 0]));
                if (num3 > 0)
                {
                  index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotAssetPresentation].Data[index5, 4]));
                  int[] numArray2 = numArray1;
                  int[] numArray3 = numArray2;
                  int index6 = num3;
                  int index7 = index6;
                  int num4 = numArray2[index6] + index1;
                  numArray3[index7] = num4;
                }
              }
            }
          }
          int num5 = 2;
          if (num5 == 2 & numArray1[2] >= 150 & numArray1[1] >= 100 & numArray1[8] >= 40)
            num5 = 3;
          if (num5 == 3 & numArray1[15] >= 100 & numArray1[3] > 30 & numArray1[8] >= 150)
            num5 = 4;
          if (num5 == 4 & numArray1[13] > 0)
            num5 = 5;
          if (num5 == 5 & numArray1[14] > 0)
            num5 = 6;
          if (num5 == 6 & numArray1[4] > 0)
            num5 = 7;
          this.ShqList.Data1[index3] = num5;
        }
        if (!DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].AI)
          return;
        SimpleList simpleList3 = new SimpleList();
        int length4 = this.data.StringListObj[this.slotZones].Length;
        for (int index8 = 0; index8 <= length4; ++index8)
        {
          num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index8, 0]));
          int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index8, 6]));
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[index8, 8])) == this.RegimeId && id > 0)
          {
            int locationById = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1)
            {
              int x = this.data.LocObj[locationById].X;
              int y = this.data.LocObj[locationById].Y;
              index1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZoneKeys].GetData2(0, num2, 1, "pop", 2)));
              if (index1 > 0)
                simpleList3.Add(num2, index1);
            }
          }
        }
        for (int counter2 = this.ShqList.Counter; counter2 >= 0; counter2 += -1)
        {
          int id = this.ShqList.Id[counter2];
          index1 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(id);
          int unitByHistorical1 = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(index1);
          if (unitByHistorical1 > -1)
          {
            DrawMod.TGame.HandyFunctionsObj.MakeMovePredictionLIS_Preview(this.data.UnitObj[unitByHistorical1].X, this.data.UnitObj[unitByHistorical1].Y, 0);
            for (int counter3 = this.ShqList.Counter; counter3 >= 0; counter3 += -1)
            {
              if (counter3 != counter2)
              {
                int num6 = this.ShqList.Id[counter3];
                int historicalUnitById = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(num6);
                int unitByHistorical2 = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
                if (unitByHistorical2 > -1 && DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[unitByHistorical2].X, this.data.UnitObj[unitByHistorical2].Y] > 0)
                {
                  this.ai.AddLog("Removing SHQ " + this.data.UnitObj[unitByHistorical2].Name + ", because it is in the same LIS area as " + this.data.UnitObj[unitByHistorical1].Name);
                  this.data.UnitObj[unitByHistorical1].items.list.AddWeight(ref this.data.UnitObj[unitByHistorical2].items.list);
                  int unitCounter = this.data.UnitCounter;
                  for (int index9 = 0; index9 <= unitCounter; ++index9)
                  {
                    if (this.data.UnitObj[index9].HQ == unitByHistorical2)
                      this.data.UnitObj[index9].HQ = unitByHistorical1;
                  }
                  int locCounter = this.data.LocCounter;
                  for (int index10 = 0; index10 <= locCounter; ++index10)
                  {
                    if (this.data.LocObj[index10].HQ == unitByHistorical2)
                      this.data.UnitObj[index10].HQ = unitByHistorical1;
                  }
                  DataClass data = this.data;
                  int nr = unitByHistorical2;
                  GameClass gameClass = (GameClass) null;
                  ref GameClass local = ref gameClass;
                  data.RemoveUnit(nr, ref local);
                  this.ShqList.Remove(num6);
                  flag1 = true;
                  break;
                }
              }
            }
          }
        }
        int counter4 = simpleList3.Counter;
        for (int index11 = 0; index11 <= counter4; ++index11)
        {
          num2 = simpleList3.Id[index11];
          int locationById1 = this.ai.game.HandyFunctionsObj.GetLocationByID((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num2, 6))));
          if (locationById1 > -1)
          {
            if (this.data.LocObj[locationById1].X == 54 & this.data.LocObj[locationById1].Y == 25)
              index1 = index1;
            SimpleList zoneNeighbourSlots = DrawMod.TGame.EventRelatedObj.helper_GetZoneNeighbourSlots(num2);
            int counter5 = zoneNeighbourSlots.Counter;
            for (int index12 = 0; index12 <= counter5; ++index12)
            {
              int num7 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].Data[zoneNeighbourSlots.Id[index12], 0]));
              int id = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num7, 6)));
              if (this.data.RegimeObj[this.data.Turn].id == (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num7, 8))))
              {
                int locationById2 = this.ai.game.HandyFunctionsObj.GetLocationByID(id);
                if (locationById2 > -1)
                {
                  if (this.data.LocObj[locationById2].X == 54 & this.data.LocObj[locationById2].Y == 25)
                    index1 = index1;
                  if (this.Helper_MakeRoad(locationById1, locationById2, num2, num7))
                  {
                    flag1 = true;
                    DrawMod.TGame.ProcessingObj.LIS_SetNetwork(false, true);
                  }
                }
              }
            }
          }
        }
        if (DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].AI)
        {
          int counter6 = simpleList3.Counter;
          for (int index13 = 0; index13 <= counter6; ++index13)
          {
            num2 = simpleList3.Id[index13];
            int locationById = this.ai.game.HandyFunctionsObj.GetLocationByID((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotZones].GetData(0, num2, 6))));
            this.shqUnitNr = this.data.LocObj[locationById].HQ;
            if (locationById > -1 & this.shqUnitNr > -1)
            {
              DrawMod.TGame.HandyFunctionsObj.MakeMovePredictionLIS_Preview(this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, this.data.LocObj[locationById].Map);
              if (DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[this.shqUnitNr].X, this.data.UnitObj[this.shqUnitNr].Y] > 0)
              {
                index1 = index1;
              }
              else
              {
                this.data.LocObj[locationById].HQ = -1;
                int counter7 = this.ShqList.Counter;
                for (int index14 = 0; index14 <= counter7; ++index14)
                {
                  int id = this.ShqList.Id[index14];
                  index1 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(id);
                  int unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(index1);
                  if (unitByHistorical > -1 && DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[unitByHistorical].X, this.data.UnitObj[unitByHistorical].Y] > 0)
                  {
                    this.ai.AddLog("Changed HQ of " + this.data.LocObj[locationById].Name + " to " + this.data.UnitObj[unitByHistorical].Name);
                    this.data.LocObj[locationById].HQ = unitByHistorical;
                    flag1 = true;
                    break;
                  }
                }
              }
            }
            else if (this.shqUnitNr == -1 & locationById > -1)
            {
              DrawMod.TGame.HandyFunctionsObj.MakeMovePredictionLIS_Preview(this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y, this.data.LocObj[locationById].Map);
              int counter8 = this.ShqList.Counter;
              for (int index15 = 0; index15 <= counter8; ++index15)
              {
                int id = this.ShqList.Id[index15];
                index1 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(id);
                int unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(index1);
                if (unitByHistorical > -1 && DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[unitByHistorical].X, this.data.UnitObj[unitByHistorical].Y] > 0)
                {
                  this.ai.AddLog("Changed HQ of " + this.data.LocObj[locationById].Name + " to " + this.data.UnitObj[unitByHistorical].Name);
                  this.data.LocObj[locationById].HQ = unitByHistorical;
                  flag1 = true;
                  break;
                }
              }
            }
            if (this.data.LocObj[locationById].HQ == -1)
            {
              DrawMod.TGame.EventRelatedObj.Helper_AddShq(this.data.Turn, this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y);
              this.ai.AddLog("Added SHQ for " + this.data.LocObj[locationById].Name + ".");
              this.data.LocObj[locationById].HQ = this.data.UnitCounter;
              flag1 = true;
            }
          }
        }
        int[,] numArray = new int[DrawMod.TGame.Data.MapObj[0].MapWidth + 1, DrawMod.TGame.Data.MapObj[0].MapHeight + 1];
        DataClass data1 = this.data;
        string str = "zones";
        ref string local3 = ref str;
        int libVar = data1.FindLibVar(ref local3, "SE_Data");
        int mapWidth = DrawMod.TGame.Data.MapObj[0].MapWidth;
        for (int index16 = 0; index16 <= mapWidth; ++index16)
        {
          int mapHeight = DrawMod.TGame.Data.MapObj[0].MapHeight;
          for (int index17 = 0; index17 <= mapHeight; ++index17)
            numArray[index16, index17] = this.data.MapObj[0].HexObj[index16, index17].GetHexLibVarValue(libVar);
        }
        index1 = 0;
        int num8 = 1;
        do
        {
          int counter9 = this.ShqList.Counter;
          for (int index18 = 0; index18 <= counter9; ++index18)
          {
            int id1 = this.ShqList.Id[index18];
            index1 = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(id1);
            int unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(index1);
            DrawMod.TGame.HandyFunctionsObj.MakeMovePredictionLIS(this.data.UnitObj[unitByHistorical].X, this.data.UnitObj[unitByHistorical].Y, this.data.UnitObj[unitByHistorical].Map);
            SimpleList simpleList4 = new SimpleList();
            int unitCounter1 = this.data.UnitCounter;
            for (int tweight = 0; tweight <= unitCounter1; ++tweight)
            {
              int historical1 = this.data.UnitObj[tweight].Historical;
              if (historical1 > -1 & this.data.UnitObj[tweight].PreDef == -1 & this.data.UnitObj[tweight].Regime == this.data.Turn && this.data.HistoricalUnitObj[historical1].Type < 8 & this.data.UnitObj[tweight].HQ == unitByHistorical)
              {
                int num9 = this.data.HistoricalUnitObj[historical1].GiveHisVarValue(11);
                int tval = this.data.HistoricalUnitObj[historical1].GiveHisVarValue(1);
                int num10 = this.data.HistoricalUnitObj[historical1].GiveHisVarValue(3);
                if (num9 < 1 & tval > 0)
                {
                  SimpleList simpleList5 = new SimpleList();
                  SimpleList SL = new SimpleList();
                  index1 = this.data.StringListObj[this.slotOobTypes].FindRow(0, tval);
                  int tdata1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index1, 8]));
                  int num11 = 0;
                  if (index1 > -1)
                  {
                    int num12;
                    if (num8 == 1)
                    {
                      num2 = 12;
                      num12 = 12;
                    }
                    if (num8 == 2)
                    {
                      num2 = 13;
                      num12 = 21;
                    }
                    int num13 = num2;
                    int num14 = num12;
                    for (int index19 = num13; index19 <= num14; ++index19)
                    {
                      int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].Data[index1, index19]));
                      if (tid > 0)
                      {
                        simpleList5.AddWeight(tid, 1);
                        ++num11;
                      }
                    }
                    int unitCounter2 = this.data.UnitCounter;
                    for (int index20 = 0; index20 <= unitCounter2; ++index20)
                    {
                      int historical2 = this.data.UnitObj[index20].Historical;
                      if (historical2 > -1 & this.data.UnitObj[index20].PreDef == -1 & this.data.UnitObj[index20].Regime == this.data.Turn)
                      {
                        int num15 = this.data.HistoricalUnitObj[historical2].GiveHisVarValue(1);
                        int tid = this.data.HistoricalUnitObj[historical2].GiveHisVarValue(2);
                        int num16 = this.data.HistoricalUnitObj[historical2].GiveHisVarValue(3);
                        if (num10 == num16 & num15 == tval)
                          SL.AddWeight(tid, 1);
                      }
                    }
                    simpleList5.RemoveWeight(ref SL);
                    simpleList5.removeWeight0orLower();
                    if (num11 > 0)
                      tdata1 = (int) Math.Round(Math.Ceiling((double) tdata1 / (double) num11));
                    if (simpleList5.Counter > -1)
                    {
                      int counter10 = simpleList5.Counter;
                      for (int index21 = 0; index21 <= counter10; ++index21)
                        simpleList4.Add(simpleList5.Id[index21], tweight, tdata1, CheckExistence: false);
                    }
                  }
                }
              }
            }
            int counter11 = simpleList4.Counter;
            for (int index22 = 0; index22 <= counter11; ++index22)
            {
              int ToeTypeId = simpleList4.Id[index22];
              int num17 = simpleList4.Data1[index22];
              int index23 = simpleList4.Weight[index22];
              this.data.HistoricalUnitObj[this.data.UnitObj[index23].Historical].GiveHisVarValue(1);
              SimpleList reinfListForToe = DrawMod.TGame.EventRelatedObj.Helper_GetReinfListForToe(ToeTypeId);
              EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
              SimpleList RL = reinfListForToe;
              int regimeId = this.RegimeId;
              SimpleList simpleList6 = (SimpleList) null;
              ref SimpleList local4 = ref simpleList6;
              SimpleList sftypesForReinfList = eventRelatedObj.Helper_GetSFtypes_ForReinfList(RL, true, true, true, true, regimeId, allowedSfTypeList: (ref local4));
              SimpleList simpleList7 = DrawMod.TGame.EventRelatedObj.Helper_ItemList_ForSFTypeList(sftypesForReinfList);
              int num18 = 0;
              int num19 = 0;
              int num20 = 99999999;
              int num21 = 0;
              int counter12 = simpleList7.Counter;
              for (int index24 = 0; index24 <= counter12; ++index24)
              {
                index1 = this.data.UnitObj[unitByHistorical].items.list.FindWeight(simpleList7.Id[index24]);
                if (index1 > simpleList7.Weight[index24])
                  index1 = simpleList7.Weight[index24];
                num18 += index1;
                num19 += simpleList7.Weight[index24];
                if (num20 > index1)
                {
                  num20 = index1;
                  num21 = simpleList7.Weight[index24];
                }
              }
              int counter13 = sftypesForReinfList.Counter;
              for (int index25 = 0; index25 <= counter13; ++index25)
              {
                int num22;
                num22 += this.data.SFTypeObj[sftypesForReinfList.Id[index25]].Weight * sftypesForReinfList.Weight[index25];
              }
              int num23 = 100;
              if (num21 > 0)
                num23 = (int) Math.Round((double) (num20 * 100) / (double) num21);
              if (num23 > 100)
                num23 = 100;
              int tvalue = index23 * 10000 + ToeTypeId;
              if (num23 >= 66)
              {
                int x = this.data.UnitObj[unitByHistorical].X;
                int y = this.data.UnitObj[unitByHistorical].Y;
                if (numArray[x, y] > 0)
                {
                  int id2 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotZones].GetData(0, numArray[x, y], 6)));
                  if (DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id2) > -1)
                  {
                    int num24 = DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0);
                    DrawMod.TGame.HandyFunctionsObj.GetStringListByID(num24);
                    DrawMod.TGame.EventRelatedObj.IO_AddClear();
                    DrawMod.TGame.EventRelatedObj.ExecKey(num24, "X", x.ToString(), "", "");
                    DrawMod.TGame.EventRelatedObj.ExecKey(num24, "Y", y.ToString(), "", "");
                    DrawMod.TGame.SelectX = x;
                    DrawMod.TGame.SelectY = y;
                    DrawMod.TGame.EventRelatedObj.ExecKey(num24, "ZONE", numArray[x, y].ToString(), "", "");
                    DrawMod.TGame.EditObj.UDSAddInput("CHOICE", 0);
                    DrawMod.TGame.EditObj.UDSAddInput("CHOICE2", 0);
                    if (num8 == 2)
                      DrawMod.TGame.EditObj.UDSAddInput("CHOICE3", tvalue);
                    if (num8 == 1)
                      DrawMod.TGame.EditObj.UDSAddInput("CHOICE4", tvalue);
                    int eventByLib = DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Present", 522, 0, 0);
                    DrawMod.TGame.EventRelatedObj.DoCheckSpecificEvent(eventByLib, tv1: -1, tv2: -1, tv3: -1);
                    flag1 = true;
                  }
                  else
                    flag1 = flag1;
                }
              }
            }
          }
          ++num8;
        }
        while (num8 <= 2);
        if (num1 > 9)
          break;
      }
      int num25 = 0;
      bool flag2 = true;
      while (flag2)
      {
        flag2 = false;
        for (int counter = this.ShqList.Counter; counter >= 0; counter += -1)
        {
          int id3 = this.ShqList.Id[counter];
          int his = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(id3);
          int unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(his);
          if (unitByHistorical > -1)
          {
            DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.data.Turn, 9, 0, 999, this.data.UnitObj[unitByHistorical].X, this.data.UnitObj[unitByHistorical].Y, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, EnemyPenalty: true, NoBridgePenalty: true, MaxDistance: 199);
            int unitCounter = this.data.UnitCounter;
            for (int index = 0; index <= unitCounter; ++index)
            {
              if (this.data.UnitObj[index].X == 7 & this.data.UnitObj[index].Y == 13)
                his = his;
              int historical3 = this.data.UnitObj[index].Historical;
              if (historical3 > -1 & this.data.UnitObj[index].PreDef == -1 & this.data.UnitObj[index].Regime == this.data.Turn && this.data.HistoricalUnitObj[historical3].Type < 8)
              {
                if (this.data.UnitObj[index].HQ == unitByHistorical && DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[index].X, this.data.UnitObj[index].Y] > 999)
                {
                  this.data.UnitObj[index].HQ = -1;
                  flag2 = true;
                }
                if (this.data.UnitObj[index].HQ > -1)
                {
                  int historical4 = this.data.UnitObj[this.data.UnitObj[index].HQ].Historical;
                  int hq = this.data.UnitObj[index].HQ;
                  if (historical4 > -1 && this.data.HistoricalUnitObj[historical4].Type <= 5 && DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[hq].X, this.data.UnitObj[hq].Y] > 999 && DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[index].X, this.data.UnitObj[index].Y] < 999)
                  {
                    bool flag3 = false;
                    if (this.data.HistoricalUnitObj[historical3].GiveHisVarValue(11) > 0)
                      flag3 = true;
                    int idValue = this.data.HistoricalUnitObj[historical3].GiveHisVarValue(1);
                    if (idValue > 0)
                    {
                      if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobTypes].GetData(0, idValue, 4))) > 0)
                        flag3 = true;
                    }
                    else
                      flag3 = true;
                    if (flag3)
                    {
                      this.data.UnitObj[index].HQ = -1;
                    }
                    else
                    {
                      this.data.HistoricalUnitObj[historical3].Name = "BG " + this.data.HistoricalUnitObj[historical3].Name;
                      this.data.UnitObj[index].Name = this.data.HistoricalUnitObj[historical3].Name;
                      this.data.HistoricalUnitObj[historical3].SetHisVarValue(1, 0);
                      this.data.HistoricalUnitObj[historical3].SetHisVarValue(2, 0);
                      this.data.HistoricalUnitObj[historical3].BattleGroup = 1;
                      int battlegroupTemplate = DrawMod.TGame.HandyFunctionsObj.GetBattlegroupTemplate(this.data.Turn);
                      this.data.UnitObj[index].HQ = -1;
                      this.data.HistoricalUnitObj[historical3].SmallGfx = this.data.HistoricalUnitObj[battlegroupTemplate].SmallGfx;
                    }
                    flag2 = true;
                  }
                }
                if (this.data.UnitObj[index].HQ == -1)
                {
                  int id4 = this.ShqList.Id[counter];
                  his = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(id4);
                  unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(his);
                  if (DrawMod.TGame.EditObj.TempValue[0].Value[this.data.UnitObj[index].X, this.data.UnitObj[index].Y] < 999)
                  {
                    this.data.UnitObj[index].HQ = unitByHistorical;
                    flag2 = true;
                  }
                }
              }
            }
          }
        }
        ++num25;
        if (num25 > 9)
          break;
      }
      DrawMod.TGame.Data.RuleVar[521] = 1f;
      int unitCounter3 = this.data.UnitCounter;
      for (int index = 0; index <= unitCounter3; ++index)
      {
        int historical = this.data.UnitObj[index].Historical;
        if (historical > -1 & this.data.UnitObj[index].PreDef == -1 & this.data.UnitObj[index].Regime == this.data.Turn)
        {
          this.data.HistoricalUnitObj[historical].SetHisVarValue(71, 100);
          this.data.HistoricalUnitObj[historical].SetHisVarValue(72, 10);
        }
      }
      int mapWidth1 = DrawMod.TGame.Data.MapObj[0].MapWidth;
      for (int index26 = 0; index26 <= mapWidth1; ++index26)
      {
        int mapHeight = DrawMod.TGame.Data.MapObj[0].MapHeight;
        for (int index27 = 0; index27 <= mapHeight; ++index27)
        {
          int index28 = 0;
          do
          {
            DrawMod.TGame.Data.MapObj[0].HexObj[index26, index27].tempPreviewLIS[index28] = 0;
            DrawMod.TGame.Data.MapObj[0].HexObj[index26, index27].tempPreviewAssetLIS[index28] = 0;
            ++index28;
          }
          while (index28 <= 8);
        }
      }
    }

    public bool Helper_MakeRoad(int locnr1, int locnr2, int zoneNr1, int zoneNr2)
    {
      int turn = this.data.Turn;
      DrawMod.TGame.EditObj.tempZoneTest = new int[DrawMod.TGame.Data.MapObj[0].MapWidth + 1, DrawMod.TGame.Data.MapObj[0].MapHeight + 1];
      DataClass data = this.data;
      string str = "zones";
      ref string local = ref str;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      int mapWidth = DrawMod.TGame.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = DrawMod.TGame.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          DrawMod.TGame.EditObj.tempZoneTest[index1, index2] = 0;
          int hexLibVarValue = this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar);
          if (hexLibVarValue == zoneNr1 | hexLibVarValue == zoneNr2)
            DrawMod.TGame.EditObj.tempZoneTest[index1, index2] = 1;
        }
      }
      int x1 = this.data.LocObj[locnr1].X;
      int y1 = this.data.LocObj[locnr1].Y;
      int x2 = this.data.LocObj[locnr2].X;
      int y2 = this.data.LocObj[locnr2].Y;
      int num1 = 0;
      int regime = this.data.MapObj[0].HexObj[x1, y1].Regime;
      DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(regime, 9, 0, 999, x1, y1, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, MaxDistance: 39, tempZoneTest: true, roadsOnly: true);
      if (DrawMod.TGame.EditObj.TempValue[0].Value[this.data.LocObj[locnr2].X, this.data.LocObj[locnr2].Y] <= 999)
        return false;
      bool flag = false;
      DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(regime, 9, 0, 999, x1, y1, 0, false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, EnemyPenalty: true, NoBridgePenalty: true, MaxDistance: 39, tempZoneTest: true);
      Coordinate coordinate1;
      coordinate1.x = x2;
      coordinate1.y = y2;
      coordinate1.onmap = true;
      if (DrawMod.TGame.EditObj.TempValue[0].Value[x2, y2] <= 999)
      {
        while (coordinate1.onmap)
        {
          Coordinate coordinate2 = coordinate1;
          coordinate1 = DrawMod.TGame.EditObj.TempCameFrom[0].Value[coordinate2.x, coordinate2.y];
          if (coordinate1.onmap)
          {
            int num2 = DrawMod.TGame.HandyFunctionsObj.HexFacing(coordinate2.x, coordinate2.y, 0, coordinate1.x, coordinate1.y, 0);
            int num3 = num2 + 3;
            if (num3 > 6)
              num3 -= 6;
            if (this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num2 - 1] != num1)
            {
              this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[num2 - 1] = num1;
              flag = true;
            }
            if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num3 - 1] != num1)
            {
              this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num3 - 1] = num1;
              flag = true;
            }
          }
        }
      }
      return flag;
    }
  }
}
