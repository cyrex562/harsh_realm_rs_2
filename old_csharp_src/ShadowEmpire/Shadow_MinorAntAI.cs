// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Shadow_MinorAntAI
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;

namespace WindowsApplication1
{
  public class Shadow_MinorAntAI
  {
    public DC2AIClass ai;
    public DataClass data;
    public MapClass map;
    public int RegimeId;
    public int slotMilitiaUnits;
    public int slotZoneOrders;
    public int slotResult;
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
    public int slotSHQitems;
    public int slotPoolItems;
    public int slotOldRegimeKeys;
    public int slotAssetPresentation;
    public int slotRegimeRes;
    public int slotResearchTypes;
    public int slotFlags;
    public int slotFlagInstructions;
    public int slotGameKeys;
    public int slotTraders;
    public int slotTraderZones;
    public int slotTraderItems;
    public int slotRegimeKeys;
    public int slotItemType;
    public int slotToeTypes;
    public int slotOldShqItems;
    public int slotZoneSeasons;
    public int slotRegimeOobs;
    public int slotOobTypes;
    public int slotModelTypes;
    public int slotRegimeModels;
    public AIMatrix areas;
    public SimpleList GroupList;
    public SimpleList UnitList;
    public int VAR_AGRESSION;
    public int VAR_ORGANISATION;
    public int VAR_CALCULATION;
    public SimpleList faunaAreaList;
    public SimpleList faunaTypeList;
    public SimpleList faunaAreaNeighbourList;
    public SimpleList faunaTypeListMigrateHistory;
    public SimpleList faunaTypeListCrusaderHistory;

    public Shadow_MinorAntAI(ref DC2AIClass tai)
    {
      this.ai = tai;
      this.data = tai.game.Data;
      this.map = tai.game.Data.MapObj[0];
      this.RegimeId = tai.game.Data.RegimeObj[tai.game.Data.Turn].id;
    }

    public void Run()
    {
      HelperEconomyData hed = new HelperEconomyData(ref this.ai.game, "SE_Data");
      if (this.ai.game.Data.Round == 1)
        this.ai.game.EventRelatedObj.ExecMakeProduction("SE_Data", -1, 1, 0, "");
      hed.reg = this.ai.game.Data.Turn;
      hed.regid = this.ai.game.Data.RegimeObj[hed.reg].id;
      hed.currentRegimeNr = hed.reg;
      hed.currentRegimeId = hed.regid;
      int length1 = this.ai.game.Data.StringListObj[hed.slotZones].Length;
      for (int index = 0; index <= length1; ++index)
      {
        int num = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 0]));
        if ((int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 8])) == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
        {
          hed.zoneId = num;
          hed.Input();
          this.ai.game.EventRelatedObj.ZoneEconomy_EarlyPrivateEconomy(ref hed, "Se_Data");
          hed.Output();
        }
      }
      this.ai.game.EventRelatedObj.ExecMakeProduction("SE_Data", -1, 0, 0, "");
      hed.reg = this.ai.game.Data.Turn;
      hed.regid = this.ai.game.Data.RegimeObj[hed.reg].id;
      hed.currentRegimeNr = hed.reg;
      hed.currentRegimeId = hed.regid;
      int length2 = this.ai.game.Data.StringListObj[hed.slotZones].Length;
      for (int index = 0; index <= length2; ++index)
      {
        int num = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 0]));
        if ((int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 8])) == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
        {
          hed.zoneId = num;
          hed.Input();
          this.ai.game.EventRelatedObj.ZoneEconomy_PrivateEconomy(ref hed, "SE_Data");
          this.ai.game.EventRelatedObj.ZoneEconomy_Militia_and_Minors(ref hed, "SE_Data");
          hed.Output();
        }
      }
      this.ai.game.EventRelatedObj.ExecMakeMaximization(false);
      if (this.ai.game.Data.Round <= 1)
        return;
      float num1 = this.data.RuleVar[941];
      this.data.RuleVar[941] = 1f;
      bool varDebugOn = this.ai.VAR_DEBUG_ON;
      if (this.ai.game.EventRelatedObj.Helper_IsDebug())
        this.ai.VAR_DEBUG_ON = true;
      this.VAR_AGRESSION = 50;
      this.VAR_ORGANISATION = 50;
      this.VAR_CALCULATION = 50;
      this.ai.SetTempHexNeighbours();
      this.ai.MakeCombatMatrix(false);
      this.ai.SetTempUnitPowerAndVarDefensiveMod();
      if ((int) Math.Round(Conversion.Val(this.ai.game.Data.Designer)) >= 66)
        this.Global_ReproductionAndStuff();
      for (int unitCounter = this.data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        int x = this.data.UnitObj[unitCounter].X;
        int y = this.data.UnitObj[unitCounter].Y;
        if (this.data.UnitObj[unitCounter].PreDef == -1 & x > -1 & this.data.UnitObj[unitCounter].Regime == this.data.Turn)
        {
          this.data.UnitObj[unitCounter].HQ = -1;
          switch (this.data.HistoricalUnitObj[this.data.UnitObj[unitCounter].Historical].GiveHisVarValue(91))
          {
            case 100:
              this.ExecuteAnts_AttackRandomly(unitCounter);
              this.ExecuteAnts_MoveRandomly_FreeFolk(unitCounter);
              continue;
            case 200:
              this.ExecuteAnts_Animal_SpecialRules(unitCounter);
              this.ExecuteAnts_AttackRandomly(unitCounter);
              this.ExecuteAnts_MoveRandomly_Animal(unitCounter);
              continue;
            case 300:
              this.ExecuteAnts_Animal_SpecialRules(unitCounter);
              this.ExecuteAnts_AdvancedAnimal_Behaviour(unitCounter);
              this.ExecuteAnts_Advanced_AttackRandomly(unitCounter);
              continue;
            default:
              continue;
          }
        }
      }
      this.data.RuleVar[941] = num1;
      this.ai.VAR_DEBUG_ON = varDebugOn;
      DrawMod.TGame.EditObj.TargetX = -1;
      DrawMod.TGame.EditObj.TargetY = -1;
    }

    public void Global_ReproductionAndStuff()
    {
      DataClass data = this.data;
      string str = "hexName";
      ref string local = ref str;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      int stringListById1 = this.ai.game.HandyFunctionsObj.GetStringListByID(this.ai.game.EventRelatedObj.CheckStringlistID("SE_Data", 242, 0, 0));
      int stringListById2 = this.ai.game.HandyFunctionsObj.GetStringListByID(this.ai.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      int stringListById4 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 382, 0, 0));
      int num1 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[stringListById2].GetData(0, 42, 2)));
      int[] numArray1 = new int[200];
      int length = this.data.StringListObj[stringListById1].Length;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        int index2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index1, 0]));
        int num2 = this.data.StringListObj[stringListById1].Width < 4 ? 20 : (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index1, 4]));
        numArray1[index2] = num2;
      }
      int[] numArray2 = new int[99 + this.ai.game.Data.RegimeCounter + 1];
      int regimeCounter = this.ai.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter; ++index)
        numArray2[index] = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById3].GetData(0, this.data.RegimeObj[index].id, 1)));
      this.faunaAreaNeighbourList = new SimpleList();
      this.faunaAreaList = new SimpleList();
      SimpleList simpleList1 = new SimpleList();
      this.faunaTypeList = new SimpleList();
      this.faunaTypeListMigrateHistory = new SimpleList();
      this.faunaTypeListCrusaderHistory = new SimpleList();
      int mapWidth1 = this.data.MapObj[0].MapWidth;
      for (int cx = 0; cx <= mapWidth1; ++cx)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          int hexLibVarValue1 = this.data.MapObj[0].HexObj[cx, cy].GetHexLibVarValue(libVar);
          if (hexLibVarValue1 > 0 && (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById4].GetData(0, hexLibVarValue1, 2))) == 5)
          {
            int landscapeType = this.data.MapObj[0].HexObj[cx, cy].LandscapeType;
            if (!this.data.LandscapeTypeObj[landscapeType].IsSea)
            {
              int tweight1 = numArray1[landscapeType];
              if (num1 < 10)
                tweight1 = (int) Math.Round(Math.Ceiling((double) tweight1 / 15.0));
              else if (num1 == 10)
                tweight1 = (int) Math.Round(Math.Ceiling((double) tweight1 / 10.0));
              else if (num1 > 10)
                tweight1 = (int) Math.Round(Math.Ceiling((double) tweight1 / 6.0));
              this.faunaAreaList.AddWeight(hexLibVarValue1, tweight1);
              if (this.data.MapObj[0].HexObj[cx, cy].Regime > -1 && numArray2[this.data.MapObj[0].HexObj[cx, cy].Regime] == 1)
                simpleList1.AddWeight(hexLibVarValue1, 1);
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  int hexLibVarValue2 = this.data.MapObj[0].HexObj[coordinate.x, coordinate.y].GetHexLibVarValue(libVar);
                  if (hexLibVarValue2 > 0 & hexLibVarValue1 != hexLibVarValue2 && (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById4].GetData(0, hexLibVarValue2, 2))) == 5 && !this.data.LandscapeTypeObj[this.data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                    this.faunaAreaNeighbourList.AddWeight(hexLibVarValue1, 1, hexLibVarValue2, CheckData1Existence: true);
                }
                ++tfacing;
              }
              while (tfacing <= 6);
              if (this.data.MapObj[0].HexObj[cx, cy].Regime == this.data.Turn)
              {
                int unitCounter = this.data.MapObj[0].HexObj[cx, cy].UnitCounter;
                for (int index = 0; index <= unitCounter; ++index)
                {
                  int unit = this.data.MapObj[0].HexObj[cx, cy].UnitList[index];
                  int historical = this.data.UnitObj[unit].Historical;
                  if (historical > -1)
                  {
                    if (this.data.HistoricalUnitObj[historical].GiveHisVarValue(91) == 300 && this.data.HistoricalUnitObj[historical].GiveHisVarValue(92) < 1 && this.data.UnitObj[unit].SFCount > -1)
                    {
                      int sf = this.data.UnitObj[unit].SFList[0];
                      int type = this.data.SFObj[sf].Type;
                      int qty = this.data.SFObj[sf].Qty;
                      this.faunaTypeList.AddWeight(hexLibVarValue1, qty, type, CheckData1Existence: true);
                      int tweight2 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(95);
                      this.faunaTypeListMigrateHistory.AddWeight(hexLibVarValue1, tweight2, type, CheckData1Existence: true);
                      int tweight3 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(96);
                      this.faunaTypeListCrusaderHistory.AddWeight(hexLibVarValue1, tweight3, type, CheckData1Existence: true);
                    }
                    int num3 = (int) Math.Round(Math.Ceiling((double) this.data.HistoricalUnitObj[historical].GiveHisVarValue(95) * 0.9)) - 1;
                    this.data.HistoricalUnitObj[historical].SetHisVarValue(95, num3);
                    int num4 = (int) Math.Round(Math.Ceiling((double) this.data.HistoricalUnitObj[historical].GiveHisVarValue(96) * 0.9)) - 1;
                    this.data.HistoricalUnitObj[historical].SetHisVarValue(96, num4);
                  }
                }
              }
            }
          }
        }
      }
      int counter1 = this.faunaAreaList.Counter;
      for (int index3 = 0; index3 <= counter1; ++index3)
      {
        int tid = this.faunaAreaList.Id[index3];
        int num5 = Convert.ToInt32(Math.Ceiling(new Decimal(this.faunaAreaList.Weight[index3])));
        if (num1 < 10 && DrawMod.RandyNumber.Next(0, 100) < 50)
          num5 = 0;
        if (num5 > 0)
        {
          int num6 = 0;
          SimpleList simpleList2 = new SimpleList();
          int sfTypeCounter1 = this.data.SFTypeCounter;
          for (int index4 = 0; index4 <= sfTypeCounter1; ++index4)
          {
            if (this.data.SFTypeObj[index4].SFTypeVar[82] > 0)
            {
              int weight = this.faunaTypeList.FindWeight(tid, index4);
              if (weight > 0)
              {
                num6 += weight * this.data.SFTypeObj[index4].Weight;
                simpleList2.AddWeight(index4, weight * this.data.SFTypeObj[index4].Weight);
              }
            }
          }
          if (num6 > 0)
          {
            simpleList2.Percentify();
            int num7 = num5 - num6;
            if (num7 > 0)
            {
              int sfTypeCounter2 = this.data.SFTypeCounter;
              for (int index5 = 0; index5 <= sfTypeCounter2; ++index5)
              {
                if (this.data.SFTypeObj[index5].SFTypeVar[82] > 0)
                {
                  int weight = this.faunaTypeList.FindWeight(tid, index5);
                  if (weight > 0)
                  {
                    SimpleList behaviourStats = this.ai.game.EventRelatedObj.AlienFauna_GetBehaviourStats(index5);
                    if ((int) Math.Round((double) (num7 * simpleList2.FindWeight(index5)) / 100.0) > this.data.SFTypeObj[index5].Weight)
                    {
                      float d = (float) (weight * behaviourStats.Weight[1]) / 100f;
                      int num8 = (int) Math.Round(Math.Floor((double) d));
                      float num9 = d - Convert.ToSingle(Math.Floor(new Decimal(num8)));
                      if ((double) num9 > 0.0 && (int) Math.Round((double) (num9 * 100f)) >= DrawMod.RandyNumber.Next(0, 100))
                        num8 = 1;
                      if (num8 > 0)
                      {
                        SimpleList simpleList3 = new SimpleList();
                        int mapWidth2 = this.data.MapObj[0].MapWidth;
                        for (int index6 = 0; index6 <= mapWidth2; ++index6)
                        {
                          int mapHeight = this.data.MapObj[0].MapHeight;
                          for (int index7 = 0; index7 <= mapHeight; ++index7)
                          {
                            if (this.data.MapObj[0].HexObj[index6, index7].GetHexLibVarValue(libVar) == tid)
                            {
                              int unitCounter = this.data.MapObj[0].HexObj[index6, index7].UnitCounter;
                              for (int index8 = 0; index8 <= unitCounter; ++index8)
                              {
                                int unit = this.data.MapObj[0].HexObj[index6, index7].UnitList[index8];
                                if (this.ai.game.HandyFunctionsObj.HasUnitSFType(unit, index5))
                                {
                                  int qty = this.data.SFObj[this.data.UnitObj[unit].SFList[0]].Qty;
                                  simpleList3.AddWeight(unit, qty);
                                }
                              }
                            }
                          }
                        }
                        if (simpleList3.Counter > -1)
                        {
                          int num10 = 0;
                          while (num8 > 0 & num10 < 99)
                          {
                            ++num10;
                            int sf = this.data.UnitObj[simpleList3.GetRandomIdbasedOnWeight()].SFList[0];
                            int qty = this.data.SFObj[sf].Qty;
                            SFClass[] sfObj = this.data.SFObj;
                            SFClass[] sfClassArray = sfObj;
                            int index9 = sf;
                            int index10 = index9;
                            sfClassArray[index10].Xp = sfObj[index9].Xp - (int) Math.Round(Math.Ceiling((double) (this.data.SFObj[sf].Xp * 1) / (double) qty));
                            int num11 = qty + 1;
                            --num8;
                            this.data.SFObj[sf].Qty = num11;
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      int sfTypeCounter3 = this.data.SFTypeCounter;
      for (int index11 = 0; index11 <= sfTypeCounter3; ++index11)
      {
        if (this.data.SFTypeObj[index11].SFTypeVar[82] > 0)
        {
          int counter2 = this.faunaAreaList.Counter;
          for (int index12 = 0; index12 <= counter2; ++index12)
          {
            int tid1 = this.faunaAreaList.Id[index12];
            int num12 = this.faunaTypeList.FindWeight(tid1, index11) - this.faunaTypeListMigrateHistory.FindWeight(tid1, index11);
            SimpleList simpleList4 = new SimpleList();
            if (num12 > 0)
            {
              SimpleList behaviourStats = this.ai.game.EventRelatedObj.AlienFauna_GetBehaviourStats(index11);
              if (behaviourStats.Weight[2] > DrawMod.RandyNumber.Next(0, 100))
              {
                if (num12 > behaviourStats.Weight[0])
                {
                  int counter3 = this.faunaAreaNeighbourList.Counter;
                  for (int index13 = 0; index13 <= counter3; ++index13)
                  {
                    if (this.faunaAreaNeighbourList.Id[index13] == tid1)
                    {
                      int tid2 = this.faunaAreaNeighbourList.Data1[index13];
                      int weight1 = this.faunaTypeList.FindWeight(tid2, index11);
                      int weight2 = this.faunaAreaList.FindWeight(tid2);
                      if (num12 > weight1 && (double) (num12 + weight1) < (double) weight2 / (double) (1 + this.data.SFTypeObj[index11].Weight) && (int) Math.Round((double) (num12 * behaviourStats.Weight[2]) / 100.0) > weight1)
                        simpleList4.AddWeight(tid2, weight1);
                    }
                  }
                }
                if (simpleList4.Counter > -1)
                {
                  simpleList4.ReverseSortHighSpeed();
                  int num13 = simpleList4.Weight[0];
                  int counter4 = simpleList4.Counter;
                  for (int index14 = 0; index14 <= counter4; ++index14)
                  {
                    simpleList4.Weight[index14] = num13 - simpleList4.Weight[index14];
                    if (simpleList4.Weight[index14] < 1)
                      simpleList4.Weight[index14] = 1;
                    int[] weight = simpleList4.Weight;
                    int[] numArray3 = weight;
                    int index15 = index14;
                    int index16 = index15;
                    int num14 = weight[index15] + 1;
                    numArray3[index16] = num14;
                  }
                  int randomIdbasedOnWeight1 = simpleList4.GetRandomIdbasedOnWeight();
                  SimpleList simpleList5 = new SimpleList();
                  int mapWidth3 = this.data.MapObj[0].MapWidth;
                  for (int index17 = 0; index17 <= mapWidth3; ++index17)
                  {
                    int mapHeight = this.data.MapObj[0].MapHeight;
                    for (int index18 = 0; index18 <= mapHeight; ++index18)
                    {
                      if (this.data.MapObj[0].HexObj[index17, index18].GetHexLibVarValue(libVar) == tid1)
                      {
                        int unitCounter = this.data.MapObj[0].HexObj[index17, index18].UnitCounter;
                        for (int index19 = 0; index19 <= unitCounter; ++index19)
                        {
                          int unit = this.data.MapObj[0].HexObj[index17, index18].UnitList[index19];
                          if (this.ai.game.HandyFunctionsObj.HasUnitSFType(unit, index11))
                          {
                            int qty = this.data.SFObj[this.data.UnitObj[unit].SFList[0]].Qty;
                            if (qty > (int) Math.Round((double) behaviourStats.Weight[0] * 0.8) & qty >= 2)
                              simpleList5.AddWeight(unit, qty);
                          }
                        }
                      }
                    }
                  }
                  if (simpleList5.Counter > -1)
                  {
                    int randomIdbasedOnWeight2 = simpleList5.GetRandomIdbasedOnWeight();
                    int x = this.ai.game.Data.UnitObj[randomIdbasedOnWeight2].X;
                    int y = this.ai.game.Data.UnitObj[randomIdbasedOnWeight2].Y;
                    int sf = this.data.UnitObj[randomIdbasedOnWeight2].SFList[0];
                    int num15 = (int) Math.Round((double) this.data.SFObj[sf].Qty / 2.0);
                    this.ai.game.EventRelatedObj.Helper_AddSpecificUnit(this.data.UnitObj[randomIdbasedOnWeight2].Name, x, y, 0, 1, index11, num15, this.data.SFObj[sf].Xp, this.data.SFObj[sf].Mor);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(91, 300);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].Counter = -1;
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].CounterString = Strings.Left(this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].Name, 3);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(92, tid1);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(93, randomIdbasedOnWeight1);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(94, 2);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(95, 0);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(96, 0);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(95, num15);
                    SFClass[] sfObj = this.data.SFObj;
                    SFClass[] sfClassArray = sfObj;
                    int index20 = sf;
                    int index21 = index20;
                    sfClassArray[index21].Qty = sfObj[index20].Qty - num15;
                    this.data.SFObj[this.ai.game.Data.UnitObj[this.ai.game.Data.UnitCounter].SFList[0]].Rdn = this.data.SFObj[sf].Rdn;
                    this.faunaTypeListMigrateHistory.AddWeight(tid1, num15);
                  }
                }
              }
            }
          }
        }
      }
      int sfTypeCounter4 = this.data.SFTypeCounter;
      for (int index22 = 0; index22 <= sfTypeCounter4; ++index22)
      {
        if (this.data.SFTypeObj[index22].SFTypeVar[82] > 0)
        {
          int counter5 = this.faunaAreaList.Counter;
          for (int index23 = 0; index23 <= counter5; ++index23)
          {
            int tid3 = this.faunaAreaList.Id[index23];
            int num16 = this.faunaTypeList.FindWeight(tid3, index22) - this.faunaTypeListCrusaderHistory.FindWeight(tid3, index22);
            int weight3 = simpleList1.FindWeight(tid3, index22);
            SimpleList simpleList6 = new SimpleList();
            if (num16 > 0)
            {
              SimpleList behaviourStats = this.ai.game.EventRelatedObj.AlienFauna_GetBehaviourStats(index22);
              if (behaviourStats.Weight[4] > DrawMod.RandyNumber.Next(0, 100))
              {
                if (num16 > (int) Math.Round((double) behaviourStats.Weight[0] * 0.5))
                {
                  int counter6 = this.faunaAreaNeighbourList.Counter;
                  for (int index24 = 0; index24 <= counter6; ++index24)
                  {
                    if (this.faunaAreaNeighbourList.Id[index24] == tid3)
                    {
                      int tid4 = this.faunaAreaNeighbourList.Data1[index24];
                      int weight4 = this.faunaTypeList.FindWeight(tid4, index22);
                      int weight5 = simpleList1.FindWeight(tid4, index22);
                      if (num16 > weight4 & weight5 > 0 && (int) Math.Round((double) (num16 * behaviourStats.Weight[4]) / 100.0) > weight4 & (double) (weight5 * behaviourStats.Weight[4]) / 100.0 > (double) weight3)
                        simpleList6.AddWeight(tid4, weight5);
                    }
                  }
                }
                if (simpleList6.Counter > -1)
                {
                  int randomIdbasedOnWeight3 = simpleList6.GetRandomIdbasedOnWeight();
                  SimpleList simpleList7 = new SimpleList();
                  int mapWidth4 = this.data.MapObj[0].MapWidth;
                  for (int index25 = 0; index25 <= mapWidth4; ++index25)
                  {
                    int mapHeight = this.data.MapObj[0].MapHeight;
                    for (int index26 = 0; index26 <= mapHeight; ++index26)
                    {
                      if (this.data.MapObj[0].HexObj[index25, index26].GetHexLibVarValue(libVar) == tid3)
                      {
                        int unitCounter = this.data.MapObj[0].HexObj[index25, index26].UnitCounter;
                        for (int index27 = 0; index27 <= unitCounter; ++index27)
                        {
                          int unit = this.data.MapObj[0].HexObj[index25, index26].UnitList[index27];
                          if (this.ai.game.HandyFunctionsObj.HasUnitSFType(unit, index22))
                          {
                            int qty = this.data.SFObj[this.data.UnitObj[unit].SFList[0]].Qty;
                            if (qty > (int) Math.Round((double) behaviourStats.Weight[0] * 0.8) & qty >= 2)
                              simpleList7.AddWeight(unit, qty);
                          }
                        }
                      }
                    }
                  }
                  if (simpleList7.Counter > -1)
                  {
                    int randomIdbasedOnWeight4 = simpleList7.GetRandomIdbasedOnWeight();
                    int x = this.ai.game.Data.UnitObj[randomIdbasedOnWeight4].X;
                    int y = this.ai.game.Data.UnitObj[randomIdbasedOnWeight4].Y;
                    int sf = this.data.UnitObj[randomIdbasedOnWeight4].SFList[0];
                    int num17 = (int) Math.Round((double) this.data.SFObj[sf].Qty / 2.0);
                    this.ai.game.EventRelatedObj.Helper_AddSpecificUnit(this.data.UnitObj[randomIdbasedOnWeight4].Name, x, y, 0, 1, index22, num17, this.data.SFObj[sf].Xp, this.data.SFObj[sf].Mor);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(91, 300);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].Counter = -1;
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].CounterString = Strings.Left(this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].Name, 3);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(92, tid3);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(93, randomIdbasedOnWeight3);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(94, 1);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(95, 0);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(96, 0);
                    this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(95, num17);
                    SFClass[] sfObj = this.data.SFObj;
                    SFClass[] sfClassArray = sfObj;
                    int index28 = sf;
                    int index29 = index28;
                    sfClassArray[index29].Qty = sfObj[index28].Qty - num17;
                    this.data.SFObj[this.ai.game.Data.UnitObj[this.ai.game.Data.UnitCounter].SFList[0]].Rdn = this.data.SFObj[sf].Rdn;
                    this.faunaTypeListMigrateHistory.AddWeight(tid3, num17);
                  }
                }
              }
            }
          }
        }
      }
      int unitCounter1 = this.ai.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        int historical = this.data.UnitObj[index].Historical;
        if (historical > -1 && this.data.UnitObj[index].Regime == 1 && this.data.UnitObj[index].SFCount > -1 && this.data.SFTypeObj[this.data.SFObj[this.data.UnitObj[index].SFList[0]].Type].SFTypeVar[82] > 0)
        {
          int num18 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(93);
          if (this.data.HistoricalUnitObj[historical].GiveHisVarValue(94) == 2 && this.data.MapObj[0].HexObj[this.ai.game.Data.UnitObj[index].X, this.ai.game.Data.UnitObj[index].Y].GetHexLibVarValue(libVar) == num18)
          {
            this.data.HistoricalUnitObj[historical].SetHisVarValue(92, num18);
            this.data.HistoricalUnitObj[historical].SetHisVarValue(93, 0);
            this.data.HistoricalUnitObj[historical].SetHisVarValue(94, 0);
          }
        }
      }
      int unitCounter2 = this.ai.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter2; ++index)
      {
        int historical = this.data.UnitObj[index].Historical;
        if (historical > -1 && this.data.UnitObj[index].Regime == 1 && this.data.UnitObj[index].SFCount > -1 && this.data.SFTypeObj[this.data.SFObj[this.data.UnitObj[index].SFList[0]].Type].SFTypeVar[82] > 0)
        {
          int tid = this.data.HistoricalUnitObj[historical].GiveHisVarValue(93);
          if (this.data.HistoricalUnitObj[historical].GiveHisVarValue(94) == 1 && simpleList1.FindWeight(tid) < 1)
          {
            int hexLibVarValue = this.data.MapObj[0].HexObj[this.ai.game.Data.UnitObj[index].X, this.ai.game.Data.UnitObj[index].Y].GetHexLibVarValue(libVar);
            if (hexLibVarValue > 0)
            {
              this.data.HistoricalUnitObj[historical].SetHisVarValue(92, hexLibVarValue);
              this.data.HistoricalUnitObj[historical].SetHisVarValue(93, 0);
              this.data.HistoricalUnitObj[historical].SetHisVarValue(94, 0);
            }
          }
        }
      }
      int unitCounter3 = this.ai.game.Data.UnitCounter;
      for (int index30 = 0; index30 <= unitCounter3; ++index30)
      {
        int historical = this.data.UnitObj[index30].Historical;
        if (historical > -1 && this.data.UnitObj[index30].Regime == 1 && this.data.UnitObj[index30].SFCount > -1)
        {
          int sf1 = this.data.UnitObj[index30].SFList[0];
          int type = this.data.SFObj[sf1].Type;
          int qty = this.data.SFObj[sf1].Qty;
          int tid = this.data.HistoricalUnitObj[historical].GiveHisVarValue(92);
          int num19 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(93);
          int num20 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(94);
          if (this.data.SFTypeObj[type].SFTypeVar[82] > 0 && this.ai.game.EventRelatedObj.AlienFauna_GetBehaviourStats(type).Weight[0] < (int) Math.Round((double) qty * 0.66))
          {
            int x = this.ai.game.Data.UnitObj[index30].X;
            int y = this.ai.game.Data.UnitObj[index30].Y;
            int sf2 = this.data.UnitObj[index30].SFList[0];
            int num21 = (int) Math.Round((double) this.data.SFObj[sf2].Qty / 2.0);
            this.ai.game.EventRelatedObj.Helper_AddSpecificUnit(this.data.UnitObj[index30].Name, x, y, 0, 1, type, num21, this.data.SFObj[sf2].Xp, this.data.SFObj[sf2].Mor);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(91, 300);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].Counter = -1;
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].CounterString = Strings.Left(this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].Name, 3);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(92, tid);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(93, num19);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(94, num20);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(95, 0);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(96, 0);
            this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.HistoricalUnitCounter].SetHisVarValue(95, num21);
            SFClass[] sfObj = this.data.SFObj;
            SFClass[] sfClassArray = sfObj;
            int index31 = sf2;
            int index32 = index31;
            sfClassArray[index32].Qty = sfObj[index31].Qty - num21;
            this.data.SFObj[this.ai.game.Data.UnitObj[this.ai.game.Data.UnitCounter].SFList[0]].Rdn = this.data.SFObj[sf2].Rdn;
            this.faunaTypeListMigrateHistory.AddWeight(tid, num21);
          }
        }
      }
    }

    public void ExecuteAnts_AdvancedAnimal_Behaviour(int unr)
    {
      int historical = this.data.UnitObj[unr].Historical;
      if (historical == -1)
        return;
      int sfCount = this.data.UnitObj[unr].SFCount;
      int type;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.data.UnitObj[unr].SFList[index];
        type = this.data.SFObj[sf].Type;
        int qty = this.data.SFObj[sf].Qty;
      }
      if (type < 0)
        return;
      DataClass data = this.data;
      string str = "hexName";
      ref string local1 = ref str;
      int libVar = data.FindLibVar(ref local1, "SE_Data");
      SimpleList behaviourStats = this.ai.game.EventRelatedObj.AlienFauna_GetBehaviourStats(type);
      int num1 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(92);
      int num2 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(93);
      int num3 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(94);
      int num4 = num1;
      if (num3 == 1 | num3 == 2 && num2 > 0)
        num4 = num2;
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai);
      AIMatrix aiMatrix2 = new AIMatrix(ref this.ai);
      AIMatrix aiMatrix3 = new AIMatrix(ref this.ai);
      int mapWidth1 = this.data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar) == num4)
            aiMatrix1.Value[index1, index2] = 1;
          if (this.data.MapObj[0].HexObj[index1, index2].Regime > -1 && this.ai.game.Data.RegimeObj[this.data.Turn].RegimeRel[this.data.MapObj[0].HexObj[index1, index2].Regime] == 0)
          {
            aiMatrix3.Value[index1, index2] = 1;
            if (this.data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 | this.data.MapObj[0].HexObj[index1, index2].Location > -1)
              aiMatrix2.Value[index1, index2] = 1;
          }
        }
      }
      aiMatrix1.ExpandAndAddValueForAnyRegime(20);
      aiMatrix1.SetValueXToValueY(0, 21);
      aiMatrix2.ExpandAndAddValueForAnyRegime(behaviourStats.Weight[3]);
      aiMatrix2.SetValueXToValueY(0, behaviourStats.Weight[3] + 1);
      int tempUnitPower = this.data.UnitObj[unr].TempUnitPower;
      int x1 = this.data.UnitObj[unr].X;
      int y1 = this.data.UnitObj[unr].Y;
      if (!(this.data.UnitObj[unr].PreDef == -1 & x1 > -1 & this.data.UnitObj[unr].Regime == this.data.Turn))
        return;
      HandyFunctionsclass handyFunctionsObj = DrawMod.TGame.HandyFunctionsObj;
      int unr1 = unr;
      int x2 = x1;
      int y2 = y1;
      CustomDC2AICalls customDc2AiCalls = (CustomDC2AICalls) null;
      ref CustomDC2AICalls local2 = ref customDc2AiCalls;
      handyFunctionsObj.MakeMovePrediction3(unr1, x2, y2, 0, ismove: true, tcustomAi: (ref local2));
      int lowestAp = this.ai.game.HandyFunctionsObj.GetLowestAp(unr);
      int x2_1 = -1;
      int num5 = 0;
      int mapWidth2 = this.map.MapWidth;
      int y2_1;
      for (int cx = 0; cx <= mapWidth2; ++cx)
      {
        int mapHeight = this.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (DrawMod.TGame.EditObj.TempValue[0].Value[cx, cy] <= lowestAp)
          {
            int num6 = DrawMod.RandyNumber.Next(0, 30);
            if (!(DrawMod.RandyNumber.Next(0, 100) < behaviourStats.Weight[12] | DrawMod.RandyNumber.Next(0, 100) < 25))
            {
              if (behaviourStats.Weight[12] < 30)
                num6 += DrawMod.RandyNumber.Next(160, 320);
              else if (behaviourStats.Weight[12] < 50)
                num6 += DrawMod.RandyNumber.Next(80, 160);
              else if (behaviourStats.Weight[12] < 70)
                num6 += DrawMod.RandyNumber.Next(40, 80);
              else if (behaviourStats.Weight[12] < 90)
                num6 += DrawMod.RandyNumber.Next(20, 40);
              else
                num6 += DrawMod.RandyNumber.Next(0, 30);
            }
            int hexLibVarValue = this.data.MapObj[0].HexObj[cx, cy].GetHexLibVarValue(libVar);
            int num7 = DrawMod.TGame.EditObj.TempValue[0].Value[cx, cy] != 0 ? num6 + (int) Math.Round((double) Math.Max(0, 100 - DrawMod.TGame.EditObj.TempValue[0].Value[cx, cy]) / 5.0) : num6 + 20;
            if (num3 > 0)
            {
              int num8 = aiMatrix1.Value[cx, cy];
              int num9 = aiMatrix1.Value[x1, y1] - num8;
              num7 += num9 * 50;
            }
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int tfacing1 = 1;
            do
            {
              Coordinate coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing1);
              if (coordinate1.onmap && this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime >= 2)
              {
                if (this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Location > -1)
                  ++num13;
                int unitCounter = this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].UnitCounter;
                for (int index = 0; index <= unitCounter; ++index)
                {
                  int unit = this.data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].UnitList[index];
                  num10 += this.data.UnitObj[unit].TempUnitPower;
                  ++num11;
                  int num14 = 0;
                  int tfacing2 = 1;
                  do
                  {
                    Coordinate coordinate2 = this.ai.game.HandyFunctionsObj.HexNeighbour(coordinate1.x, coordinate1.y, 0, tfacing2);
                    if (coordinate2.onmap && this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].Regime == 1 & !(coordinate1.x == cx & coordinate1.x == cy) && this.data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].UnitCounter > -1)
                      ++num14;
                    ++tfacing2;
                  }
                  while (tfacing2 <= 6);
                  if (num14 > num12)
                    num12 = num14;
                }
              }
              ++tfacing1;
            }
            while (tfacing1 <= 6);
            int num15 = num12;
            int num16 = num10;
            int num17 = num11;
            int num18 = num13;
            if (num17 > 0)
              num7 += (int) Math.Round(100.0 * ((double) behaviourStats.Weight[9] / 100.0));
            else if (aiMatrix2.Value[x1, y1] > aiMatrix2.Value[cx, cy])
            {
              int num19 = aiMatrix2.Value[cx, cy];
              int num20 = aiMatrix2.Value[x1, y1] - num19;
              num7 += Math.Min(70, (int) Math.Round((double) (num20 * 30) * ((double) behaviourStats.Weight[9] / 100.0)));
            }
            else if (aiMatrix3.Value[cx, cy] > 0)
              num7 += (int) Math.Round((double) (25 * behaviourStats.Weight[9]) / 100.0);
            if (behaviourStats.Weight[6] > 0 && this.data.MapObj[0].HexObj[cx, cy].UnitCounter == -1 && num12 > 0)
              num7 += num15 * 50;
            if (behaviourStats.Weight[11] > 0)
            {
              if (num16 > tempUnitPower * 4)
                num7 = (int) Math.Round((double) num7 * 0.1);
              else if (num16 > tempUnitPower * 3)
                num7 = (int) Math.Round((double) num7 * 0.3);
              else if (num16 > tempUnitPower * 2)
                num7 = (int) Math.Round((double) num7 * 0.5);
              else if (num16 > tempUnitPower * 1)
                num7 = (int) Math.Round((double) num7 * 0.8);
            }
            if (behaviourStats.Weight[2] > DrawMod.RandyNumber.Next(0, 100) | behaviourStats.Weight[1] > DrawMod.RandyNumber.Next(0, 100) && x1 == cx & y1 == cy & num17 > 0)
              num7 += (int) Math.Round((double) (40f * Math.Min(1f, (float) tempUnitPower / (float) (num16 + 1))));
            if (behaviourStats.Weight[7] > 0)
            {
              if (num18 > 0)
                num7 += Math.Min(70, 30 * num18);
              if (this.data.MapObj[0].HexObj[cx, cy].Location > -1)
                num7 += 50;
            }
            else
            {
              if (num18 > 0)
                num7 += Math.Min(30, 10 * num18);
              if (this.data.MapObj[0].HexObj[cx, cy].Location > -1)
                num7 += 15;
            }
            if (behaviourStats.Weight[8] > 0)
            {
              int val2 = this.data.LandscapeTypeObj[this.data.MapObj[0].HexObj[cx, cy].LandscapeType].HidePts - this.data.LandscapeTypeObj[this.data.MapObj[0].HexObj[x1, y1].LandscapeType].HidePts;
              if (val2 > 0 | num3 < 1)
                num7 += Math.Min(45, val2);
            }
            int index3;
            if (behaviourStats.Weight[10] > 0 && this.data.MapObj[index3].HexObj[x1, y1].UnitCounter < 2 && this.data.MapObj[index3].HexObj[cx, cy].UnitCounter < 1)
            {
              if (!(cx == x1 & cy == y1))
              {
                if (this.data.MapObj[index3].HexObj[cx, cy].UnitCounter > -1)
                  num7 += 25;
              }
              else if (this.data.MapObj[index3].HexObj[cx, cy].UnitCounter > 0)
                num7 += 25;
            }
            if (num3 > 0)
            {
              if (hexLibVarValue != num2)
                num7 = (int) Math.Round((double) num7 / 2.0);
            }
            else if (hexLibVarValue != num1)
              num7 = (int) Math.Round((double) num7 / 5.0);
            if (num7 > num5)
            {
              num5 = num7;
              x2_1 = cx;
              y2_1 = cy;
            }
          }
        }
      }
      if (x2_1 <= -1)
        return;
      DrawMod.TGame.ProcessingObj.ExecuteMovement(unr, x1, y1, 0, x2_1, y2_1, 0);
    }

    public void ExecuteAnts_Animal_SpecialRules(int unr)
    {
      int sfCount = this.data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.data.UnitObj[unr].SFList[index];
        int type = this.data.SFObj[sf].Type;
        if (this.data.SFTypeObj[type].SFTypeVar[8] > 0)
        {
          int num = (int) Math.Round(Conversion.Val(Strings.Mid(this.data.SFTypeObj[type].SFTypeVar[8].ToString(), 2, 1)));
          if (num > 0 && this.data.SFObj[sf].Mor > 50 - num * 8)
            this.data.SFObj[sf].Mor = 50 - num * 8;
        }
      }
    }

    public void ExecuteAnts_MoveRandomly_FreeFolk(int unr)
    {
      string name = "ANT_120_Ant_AI";
      this.ai.ClearLog();
      DataClass data = this.data;
      string str = "freefolk";
      ref string local1 = ref str;
      int libVar = data.FindLibVar(ref local1, "SE_Data");
      int x1 = this.data.UnitObj[unr].X;
      int y1 = this.data.UnitObj[unr].Y;
      if (this.data.UnitObj[unr].PreDef == -1 & x1 > -1 & this.data.UnitObj[unr].Regime == this.data.Turn)
      {
        HandyFunctionsclass handyFunctionsObj = DrawMod.TGame.HandyFunctionsObj;
        int unr1 = unr;
        int x2 = x1;
        int y2 = y1;
        CustomDC2AICalls customDc2AiCalls = (CustomDC2AICalls) null;
        ref CustomDC2AICalls local2 = ref customDc2AiCalls;
        handyFunctionsObj.MakeMovePrediction3(unr1, x2, y2, 0, ismove: true, tcustomAi: (ref local2));
        int x2_1 = -1;
        int num1 = 50;
        if (this.map.HexObj[x1, y1].GetHexLibVarValue(libVar) > 0)
          num1 = 999999;
        if (DrawMod.RandyNumber.Next(0, 100) < 33)
          num1 = 0;
        int mapWidth = this.map.MapWidth;
        int y2_1;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.map.MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            if (DrawMod.TGame.EditObj.TempValue[0].Value[index1, index2] < 999)
            {
              if (this.map.HexObj[index1, index2].Regime > 5)
                index1 = index1;
              int hexLibVarValue = this.map.HexObj[index1, index2].GetHexLibVarValue(libVar);
              int num2 = DrawMod.RandyNumber.Next(0, 100);
              if (DrawMod.RandyNumber.Next(0, 100) > 50 & hexLibVarValue > 0)
                num2 += hexLibVarValue;
              if (num2 > num1)
              {
                num1 = num2;
                x2_1 = index1;
                y2_1 = index2;
              }
            }
          }
        }
        if (x2_1 > -1)
          DrawMod.TGame.ProcessingObj.ExecuteMovement(unr, x1, y1, 0, x2_1, y2_1, 0);
      }
      this.ai.WriteLog(name);
    }

    public void ExecuteAnts_MoveRandomly_Animal(int unr)
    {
      string name = "ANT_120_Ant_AI";
      this.ai.ClearLog();
      int x1 = this.data.UnitObj[unr].X;
      int y1 = this.data.UnitObj[unr].Y;
      if (this.data.UnitObj[unr].PreDef == -1 & x1 > -1 & this.data.UnitObj[unr].Regime == this.data.Turn)
      {
        HandyFunctionsclass handyFunctionsObj = DrawMod.TGame.HandyFunctionsObj;
        int unr1 = unr;
        int x2 = x1;
        int y2 = y1;
        CustomDC2AICalls customDc2AiCalls = (CustomDC2AICalls) null;
        ref CustomDC2AICalls local = ref customDc2AiCalls;
        handyFunctionsObj.MakeMovePrediction3(unr1, x2, y2, 0, ismove: true, tcustomAi: (ref local));
        int x2_1 = -1;
        int num1 = 50;
        int mapWidth = this.map.MapWidth;
        int y2_1;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.map.MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            if (DrawMod.TGame.EditObj.TempValue[0].Value[index1, index2] < 999)
            {
              if (this.map.HexObj[index1, index2].Regime > 5)
                index1 = index1;
              int num2 = DrawMod.RandyNumber.Next(0, 100);
              if (num2 > num1)
              {
                num1 = num2;
                x2_1 = index1;
                y2_1 = index2;
              }
            }
          }
        }
        if (x2_1 > -1)
          DrawMod.TGame.ProcessingObj.ExecuteMovement(unr, x1, y1, 0, x2_1, y2_1, 0);
      }
      this.ai.WriteLog(name);
    }

    public void ExecuteAnts_Advanced_AttackRandomly(int unr)
    {
      int sfCount = this.data.UnitObj[unr].SFCount;
      int type;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.data.UnitObj[unr].SFList[index];
        type = this.data.SFObj[sf].Type;
        int qty = this.data.SFObj[sf].Qty;
      }
      SimpleList behaviourStats = this.ai.game.EventRelatedObj.AlienFauna_GetBehaviourStats(type);
      int x1 = this.data.UnitObj[unr].X;
      int y1 = this.data.UnitObj[unr].Y;
      if (!(this.data.UnitObj[unr].PreDef == -1 & x1 > -1 & this.data.UnitObj[unr].Regime == this.data.Turn))
        return;
      HandyFunctionsclass handyFunctionsObj = DrawMod.TGame.HandyFunctionsObj;
      int unr1 = unr;
      int x2 = x1;
      int y2 = y1;
      CustomDC2AICalls customDc2AiCalls = (CustomDC2AICalls) null;
      ref CustomDC2AICalls local = ref customDc2AiCalls;
      handyFunctionsObj.MakeMovePrediction3(unr1, x2, y2, 0, attack: true, ismove: true, tcustomAi: (ref local));
      int num1 = -1;
      int num2 = 105 - behaviourStats.Weight[5];
      if (behaviourStats.Weight[5] < 1)
        num2 = 60;
      int tfacing = 1;
      int num3;
      do
      {
        Coordinate coordinate = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(x1, y1, 0, tfacing);
        if (coordinate.onmap)
        {
          int x3 = coordinate.x;
          int y3 = coordinate.y;
          if (DrawMod.TGame.EditObj.TempValue[0].Value[x3, y3] < 999 && DrawMod.TGame.HandyFunctionsObj.VisibleEnemyUnitsInHex(x3, y3, 0, this.data.Turn, true))
          {
            int num4 = DrawMod.RandyNumber.Next(0, 100);
            if (num4 > num2)
            {
              num2 = num4;
              num1 = x3;
              num3 = y3;
            }
          }
        }
        ++tfacing;
      }
      while (tfacing <= 6);
      if (num1 <= -1)
        return;
      DrawMod.TGame.EditObj.TempUnitList = new WindowsApplication1.UnitList();
      DrawMod.TGame.EditObj.TempUnitList.add(unr);
      Coordinate Target = new Coordinate();
      Target.onmap = true;
      Target.x = num1;
      Target.y = num3;
      DrawMod.TGame.TempCombat = new CombatClass(DrawMod.TGame);
      if (DrawMod.TGame.Data.LandscapeTypeObj[this.map.HexObj[Target.x, Target.y].LandscapeType].IsSea)
        DrawMod.TGame.TempCombat.Init(Target, 1, DrawMod.TGame.EditObj.TempUnitList, 12);
      else
        DrawMod.TGame.TempCombat.Init(Target, 1, DrawMod.TGame.EditObj.TempUnitList, 2);
      DrawMod.TGame.TempCombat.DoBattle();
      DrawMod.TGame.TempCombat.EndBattle();
    }

    public void ExecuteAnts_AttackRandomly(int unr)
    {
      int x1 = this.data.UnitObj[unr].X;
      int y1 = this.data.UnitObj[unr].Y;
      if (!(this.data.UnitObj[unr].PreDef == -1 & x1 > -1 & this.data.UnitObj[unr].Regime == this.data.Turn))
        return;
      HandyFunctionsclass handyFunctionsObj = DrawMod.TGame.HandyFunctionsObj;
      int unr1 = unr;
      int x2 = x1;
      int y2 = y1;
      CustomDC2AICalls customDc2AiCalls = (CustomDC2AICalls) null;
      ref CustomDC2AICalls local = ref customDc2AiCalls;
      handyFunctionsObj.MakeMovePrediction3(unr1, x2, y2, 0, attack: true, ismove: true, tcustomAi: (ref local));
      int num1 = -1;
      int num2 = 60;
      int tfacing = 1;
      int num3;
      do
      {
        Coordinate coordinate = DrawMod.TGame.HandyFunctionsObj.HexNeighbour(x1, y1, 0, tfacing);
        if (coordinate.onmap)
        {
          int x3 = coordinate.x;
          int y3 = coordinate.y;
          if (DrawMod.TGame.EditObj.TempValue[0].Value[x3, y3] < 999 && DrawMod.TGame.HandyFunctionsObj.VisibleEnemyUnitsInHex(x3, y3, 0, this.data.Turn, true))
          {
            int num4 = DrawMod.RandyNumber.Next(0, 100);
            if (num4 > num2)
            {
              num2 = num4;
              num1 = x3;
              num3 = y3;
            }
          }
        }
        ++tfacing;
      }
      while (tfacing <= 6);
      if (num1 <= -1)
        return;
      DrawMod.TGame.EditObj.TempUnitList = new WindowsApplication1.UnitList();
      DrawMod.TGame.EditObj.TempUnitList.add(unr);
      Coordinate Target = new Coordinate();
      Target.onmap = true;
      Target.x = num1;
      Target.y = num3;
      DrawMod.TGame.TempCombat = new CombatClass(DrawMod.TGame);
      if (DrawMod.TGame.Data.LandscapeTypeObj[this.map.HexObj[Target.x, Target.y].LandscapeType].IsSea)
        DrawMod.TGame.TempCombat.Init(Target, 1, DrawMod.TGame.EditObj.TempUnitList, 12);
      else
        DrawMod.TGame.TempCombat.Init(Target, 1, DrawMod.TGame.EditObj.TempUnitList, 2);
      DrawMod.TGame.TempCombat.DoBattle();
      DrawMod.TGame.TempCombat.EndBattle();
    }

    public void ExecuteSubGroup_AreaDefense(int groupId)
    {
      string name = "ANT_120_Ant_Group_" + groupId.ToString() + "_Execute_SubGroup_AreaDefense";
      this.ai.ClearLog();
      int counter1 = this.UnitList.Counter;
      int num1;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.UnitList.Data1[index] == groupId && this.UnitList.Data2[index] == 2)
          ++num1;
      }
      if (num1 < 1)
        return;
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai);
      bool[] flagArray = new bool[this.data.UnitCounter + 1];
      bool flag = true;
      while (flag)
      {
        flag = false;
        int counter2 = this.UnitList.Counter;
        for (int index1 = 0; index1 <= counter2; ++index1)
        {
          if (this.UnitList.Data1[index1] == groupId && this.UnitList.Data2[index1] == 2)
          {
            int historicalUnitById = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(this.UnitList.Id[index1]);
            int unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
            int x = this.data.UnitObj[unitByHistorical].X;
            int y = this.data.UnitObj[unitByHistorical].Y;
            if (!flagArray[unitByHistorical])
            {
              AIMatrix aiMatrix2 = new AIMatrix(ref this.ai);
              AIMatrix aiMatrix3 = new AIMatrix(ref this.ai);
              AIMatrix aiMatrix4 = new AIMatrix(ref this.ai);
              int mapWidth1 = this.map.MapWidth;
              for (int index2 = 0; index2 <= mapWidth1; ++index2)
              {
                int mapHeight = this.map.MapHeight;
                for (int index3 = 0; index3 <= mapHeight; ++index3)
                {
                  if (this.areas.Value[index2, index3] == groupId)
                  {
                    int unitCounter = this.map.HexObj[index2, index3].UnitCounter;
                    for (int index4 = 0; index4 <= unitCounter; ++index4)
                    {
                      index1 = this.map.HexObj[index2, index3].UnitList[index4];
                      if (index1 != unitByHistorical)
                      {
                        int regime = this.map.HexObj[index2, index3].Regime;
                        if (regime == this.data.Turn)
                        {
                          int[,] numArray1 = aiMatrix2.Value;
                          int[,] numArray2 = numArray1;
                          int index5 = index2;
                          int index6 = index5;
                          int index7 = index3;
                          int index8 = index7;
                          int num2 = numArray1[index5, index7] + this.data.UnitObj[index1].TempUnitPower;
                          numArray2[index6, index8] = num2;
                        }
                        else if (regime > -1 && !this.data.RegimeObj[regime].Sleep & this.data.RegimeObj[regime].RegimeRel[this.data.Turn] == 0)
                        {
                          int[,] numArray3 = aiMatrix3.Value;
                          int[,] numArray4 = numArray3;
                          int index9 = index2;
                          int index10 = index9;
                          int index11 = index3;
                          int index12 = index11;
                          int num3 = numArray3[index9, index11] + this.data.UnitObj[index1].TempUnitPower;
                          numArray4[index10, index12] = num3;
                        }
                      }
                    }
                  }
                }
              }
              aiMatrix3.ExpandAndRemovePercentageForAnyRegime(10, 0.8f);
              aiMatrix2.ExpandAndRemovePercentageForAnyRegime(10, 0.8f);
              int num4 = 0;
              int mapWidth2 = this.map.MapWidth;
              for (int index13 = 0; index13 <= mapWidth2; ++index13)
              {
                int mapHeight = this.map.MapHeight;
                for (int index14 = 0; index14 <= mapHeight; ++index14)
                {
                  if (this.areas.Value[index13, index14] != groupId)
                  {
                    aiMatrix2.Value[index13, index14] = 0;
                    aiMatrix3.Value[index13, index14] = 0;
                    aiMatrix4.Value[index13, index14] = 0;
                  }
                  else
                  {
                    aiMatrix4.Value[index13, index14] = aiMatrix3.Value[index13, index14] * 3 - aiMatrix2.Value[index13, index14];
                    if (aiMatrix4.Value[index13, index14] < num4)
                      num4 = aiMatrix4.Value[index13, index14];
                  }
                }
              }
              if (num4 < 0)
                aiMatrix4.AddValue(Math.Abs(num4));
              aiMatrix4.Percentify();
              int mapWidth3 = this.map.MapWidth;
              for (int index15 = 0; index15 <= mapWidth3; ++index15)
              {
                int mapHeight = this.map.MapHeight;
                for (int index16 = 0; index16 <= mapHeight; ++index16)
                {
                  if (this.areas.Value[index15, index16] != groupId)
                    aiMatrix4.Value[index15, index16] = 0;
                }
              }
              DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction(unitByHistorical, x, y, 0, ismove: true);
              int x2 = -1;
              int num5 = -999999;
              int num6 = aiMatrix4.Value[x, y];
              int mapWidth4 = this.map.MapWidth;
              int y2;
              for (int index17 = 0; index17 <= mapWidth4; ++index17)
              {
                int mapHeight = this.map.MapHeight;
                for (int index18 = 0; index18 <= mapHeight; ++index18)
                {
                  if (DrawMod.TGame.EditObj.TempValue[0].Value[index17, index18] < 9999 & this.areas.Value[index17, index18] == groupId)
                  {
                    int num7 = aiMatrix4.Value[index17, index18];
                    if (num7 > num5)
                    {
                      num5 = num7;
                      x2 = index17;
                      y2 = index18;
                    }
                  }
                }
              }
              if ((double) num5 > (double) num6 * 1.1)
              {
                DrawMod.TGame.ProcessingObj.ExecuteMovement(unitByHistorical, x, y, 0, x2, y2, 0);
                flag = true;
                break;
              }
              flagArray[unitByHistorical] = true;
            }
          }
        }
      }
      this.ai.WriteLog(name);
    }

    public void SetGroups()
    {
      string name = "ANT_100_Ant_Groups";
      this.ai.ClearLog();
      DataClass data = this.data;
      string str1 = "freeFolk";
      ref string local = ref str1;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      this.areas = new AIMatrix(ref this.ai);
      this.GroupList = new SimpleList();
      this.UnitList = new SimpleList();
      int locCounter = this.data.LocCounter;
      for (int index = 0; index <= locCounter; ++index)
      {
        int x = this.data.LocObj[index].X;
        int y = this.data.LocObj[index].Y;
        if (this.map.HexObj[x, y].Regime == this.data.Turn)
        {
          this.GroupList.Add(x * 1000 + y, 1, x, y);
          this.areas.Value[x, y] = x * 1000 + y;
        }
      }
      this.areas.ExpandUniquesValuesForSameRegime(10);
      int mapWidth = this.map.MapWidth;
      for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
      {
        int mapHeight = this.map.MapHeight;
        for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
        {
          if (this.map.HexObj[tdata1, tdata2].Regime == this.data.Turn && this.areas.Value[tdata1, tdata2] == 0 && this.map.HexObj[tdata1, tdata2].GetHexLibVarValue(libVar) > 0)
          {
            this.GroupList.Add(tdata1 * 1000 + tdata2, 1, tdata1, tdata2);
            this.areas.Value[tdata1, tdata2] = tdata1 * 1000 + tdata2;
          }
        }
      }
      this.areas.ExpandUniquesValuesForSameRegime(10);
      this.areas.ExpandValueForAnyRegime(5);
      int unitCounter1 = this.data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.data.UnitObj[index].Regime == this.data.Turn & this.data.UnitObj[index].X > -1)
        {
          int x = this.data.UnitObj[index].X;
          int y = this.data.UnitObj[index].Y;
          if (this.areas.Value[x, y] == 0)
          {
            this.GroupList.Add(x * 1000 + y, 1, x, y);
            this.areas.Value[x, y] = x * 1000 + y;
            this.areas.ExpandSpecificValueForSameRegime(x * 1000 + y, 10);
          }
        }
      }
      this.areas.ExpandValueForAnyRegime(10);
      int unitCounter2 = this.data.UnitCounter;
      for (int index = 0; index <= unitCounter2; ++index)
      {
        if (this.data.UnitObj[index].Regime == this.data.Turn & this.data.UnitObj[index].Historical > -1)
        {
          int x = this.data.UnitObj[index].X;
          int y = this.data.UnitObj[index].Y;
          if (x > -1 && this.areas.Value[x, y] > 0 && this.GroupList.FindNr(this.areas.Value[x, y]) > -1)
            this.UnitList.Add(this.data.HistoricalUnitObj[this.data.UnitObj[index].Historical].ID, 1, this.areas.Value[x, y]);
        }
      }
      int counter1 = this.GroupList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int num1 = this.GroupList.Data1[index1];
        int num2 = this.GroupList.Data2[index1];
        int num3 = 0;
        int counter2 = this.UnitList.Counter;
        for (int index2 = 0; index2 <= counter2; ++index2)
        {
          if (this.UnitList.Data1[index2] == this.GroupList.Id[index1] && DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(this.UnitList.Id[index2]) > -1)
            ++num3;
        }
        int num4 = 0;
        int counter3 = this.UnitList.Counter;
        for (int index3 = 0; index3 <= counter3; ++index3)
        {
          if (this.UnitList.Data1[index3] == this.GroupList.Id[index1] && DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(this.UnitList.Id[index3]) > -1)
          {
            ++num4;
            this.UnitList.Data2[index3] = (double) num4 > Math.Ceiling((double) num3 / 2.0) ? 1 : 2;
          }
        }
      }
      int counter4 = this.GroupList.Counter;
      for (int index4 = 0; index4 <= counter4; ++index4)
      {
        int x = this.GroupList.Data1[index4];
        int y = this.GroupList.Data2[index4];
        string str2 = DrawMod.TGame.HandyFunctionsObj.GetHexName(x, y, 0) + " (" + x.ToString() + "," + y.ToString() + ")";
        this.ai.AddLog("Group #" + this.GroupList.Id[index4].ToString() + " : " + str2);
        int counter5 = this.UnitList.Counter;
        for (int index5 = 0; index5 <= counter5; ++index5)
        {
          if (this.UnitList.Data1[index5] == this.GroupList.Id[index4])
          {
            int historicalUnitById = DrawMod.TGame.HandyFunctionsObj.GetHistoricalUnitByID(this.UnitList.Id[index5]);
            if (historicalUnitById > -1)
            {
              int unitByHistorical = DrawMod.TGame.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
              string str3 = "";
              if (this.UnitList.Data2[index5] == 0)
                str3 = "WANDER";
              if (this.UnitList.Data2[index5] == 1)
                str3 = "DEFEND_AREA";
              if (this.UnitList.Data2[index5] == 2)
                str3 = "DEFEND_CITY";
              if (this.UnitList.Data2[index5] == 3)
                str3 = "HELP";
              if (this.UnitList.Data2[index5] == 4)
                str3 = "ATTACK";
              this.ai.AddLog("-" + this.data.UnitObj[unitByHistorical].Name + ", " + str3);
            }
          }
        }
      }
      this.ai.WriteLog(name);
    }
  }
}
