﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DC2AIClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class DC2AIClass
  {
    public GameClass game;
    public MapClass map;
    public Coordinate[,,] TempHexNeighbour;
    public AIFrontList frontList;
    public AIFrontList masterPlan;
    public AIMatrix frontMatrix;
    public AIMatrix extendedMatrix;
    public AIMatrix frontlinesMatrix;
    public AIMatrix strengthMatrix;
    public AIMatrix friendlySupplyMatrix;
    public AIMatrix friendlyTroopsMatrix;
    public AIMatrix enemySupplyMatrix;
    public AICoordinateMatrix enemySupplyMatrixCameFrom;
    public AICoordinateMatrix friendlySupplyMatrixCameFrom;
    public AIMatrix MLAMatrix;
    public AIMatrix ProbablyOutOfSupply;
    public AIMatrix probableEnemyPenetration;
    public AIMatrix enemyBoostMatrix;
    public AIMatrix probableOwner;
    public int LogCounter;
    public string[] LogTxt;
    public bool VAR_DC4_MINIMIZE_ORG_UNITS;
    public bool VAR_DC4_ATTACKUNIT_IS_IMPORTANT;
    public bool VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE;
    public int VAR_FRONTLINE_DEPTH;
    public int VAR_FRONTLINE_MAX_LENGTH;
    public int VAR_SUPPLY_FRIENDLY_MOVETYPE;
    public int VAR_SUPPLY_ENEMY_MOVETYPE;
    public int VAR_RAIL_TRANSFER_MOVETYPE;
    public int VAR_SUPPLY_MAXIMUM_RANGE;
    public int VAR_TRANSFER_MAXIMUM_RANGE;
    public int VAR_STRATEGIC_TRANSFER_STARTUP_COST;
    public int VAR_SUPPLY_75PERCENT_RANGE;
    public int VAR_SUPPLY_50PERCENT_RANGE;
    public int VAR_SUPPLY_25PERCENT_RANGE;
    public int VAR_HQ_100PERCENT_RANGE;
    public int VAR_HQ_PERCENTDROP_PERHEX;
    public int VAR_HEX_STACK_REGULAR;
    public int VAR_HEX_STACK_AIR;
    public int VAR_MOVE_MAXIMUM_RANGE;
    public int VAR_REINFORCEMENTS_FRIENDLY;
    public int VAR_REINFORCEMENTS_ENEMY;
    public bool VAR_DEBUG_ON;
    public int VAR_CELLULAR_AUTOMATON_ITERATIONS;
    public bool VAR_DISABLE_RETREAT_STANCE;
    public bool VAR_DISABLE_FULLRETREAT_STANCE;
    public int VAR_GARRISON_RULE1_MIN_VP;
    public int VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE;
    public int VAR_GARRISON_RULE2_MIN_VP;
    public int VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE;
    public bool VAR_GARRISON_PORT_ALWAYS;
    public int VAR_GARRISON_MIN_VP_ALWAYS;
    public int VAR_VP_AT_DEFEAT;
    public int VAR_VP_AT_VICTORY;
    public int VAR_FORTRESSMODE_MIN_VP;
    public bool VAR_ALWAYS_PROTECT_FRONTLINE_CITIES;
    public bool VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT;
    public float VAR_MODIFY_OWN_STRENGTH_PERCEPTION;
    public float VAR_MODIFY_MINIMUM_ATTACK;
    public int VAR_TOP_UNIT_MINIMUM_ARMOR_SUBUNITS;
    public int VAR_SUPPLY_COUNTER;
    public int[,] VAR_SUPPLY_X;
    public int[,] VAR_SUPPLY_Y;
    public bool[,] VAR_SUPPLY_ACTIVE;
    public float VAR_SUPPLY_WEIGHT;
    public bool VAR_USE_DYNAMIC_OOB;
    public bool VAR_USE_TOP_OPERATIONS;
    public int VAR_TOP_OPERATIONS_PERCENTAGE;
    public bool VAR_USE_CHANGE_HQ;
    public bool VAR_USE_CHANGE_HQ_IF_NONE;
    public bool VAR_USE_OFFICERPOOL;
    public bool VAR_USE_STRATEGIC_TRANSFERS;
    public bool VAR_USE_ADD_UNIT;
    public bool VAR_USE_UBER_UNTER_RULES;
    public bool VAR_USE_REGIME_CARDS;
    public bool VAR_USE_STRICT_HQFRONT;
    public bool VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT;
    public bool VAR_USE_SSHQ;
    public int VAR_SSHQ_SIZE1;
    public int VAR_SSHQ_SIZE2;
    public bool VAR_USE_MLA;
    public int VAR_MLA_RANGE;
    public int VAR_BEST_HISVARTYPE_ANYLEVELHQ;
    public int VAR_BEST_HISVARTYPE_HIGHERLEVELHQ;
    public bool VAR_USE_SUPERFRONTS;
    public int VAR_SUPERFRONT_EVENT;
    public int VAR_SUPERFRONT_AREASLOT;
    public int VAR_SUPERFRONT_HQLEVEL;
    public int VAR_ZONES_TYPE;
    public int VAR_ZONES_AREASLOT;
    public int VAR_ZONES_EVENT;
    public int VAR_RETREAT_EVENT;
    public int VAR_STRENGTH_EVENT;
    public float VAR_DEFENSIVE_WORLD_MODIFIER_FRIENDLY;
    public float VAR_DEFENSIVE_WORLD_MODIFIER_ENEMY;
    public AIMatrix VAR_MATRIX_STRENGTH;
    public AIMatrix VAR_MATRIX_SUPERFRONT;
    public AIMatrix VAR_MATRIX_ZONES;
    public AIMatrix VAR_MATRIX_RETREAT;
    public bool VAR_USE_BROAD_DEFENSIVE_ZONES;
    public int VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM;
    public int VAR_ENEMYMOVE_PROGNOSIS_MODE;
    public int VAR_STRICTHQ_DIST_IMPORTANCE;
    public int VAR_TOPUNIT_STIMULUS;
    public bool VAR_HAMMER_OUT_POCKETS;
    public int VAR_MOST_USED_MOVEMENTYPE;
    public bool VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD;
    public int VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE;
    public int SYSTEM_VAR_RUN_NUMBER;
    public bool VAR_SIEGE_SIMULATION;
    public int VAR_SIEGE_SIMULATION_MAX_ENTR;
    public bool VAR_EMPHASIS_AGAINST_CONCENTRIC;
    public bool VAR_EMPHASIS_FOR_CONCENTRIC;
    public bool VAR_STRATEGIC_WEAKNESS_AT_BOTTLENECK;
    public bool VAR_ALLOW_OFFENSIVEGROUP_TO_OPPORTUNITY;
    public bool VAR_ALLOW_OPPORTUNITY_ENCIRCLE;
    public bool VAR_ALLOW_THREAT_ENCIRCLE;
    public bool SE1_USEFLAK;
    public const int STANCE_FULLRETREAT = 4;
    public const int STANCE_RETREAT = 1;
    public const int STANCE_HOLD = 2;
    public const int STANCE_ATTACK = 3;
    public const int STANCE_RETROGRADE = 5;
    public const int DIRECTION_NORTH = 1;
    public const int DIRECTION_NORTHEAST = 2;
    public const int DIRECTION_SOUTHEAST = 3;
    public const int DIRECTION_SOUTH = 4;
    public const int DIRECTION_SOUTHWEST = 5;
    public const int DIRECTION_NORTHWEST = 6;
    public const int DIRECTION_ALL = 7;
    public const int DIRECTION_COUNT = 7;
    public const int WEIGHT_VERYIMPORTANT = 4000;
    public const int WEIGHT_IMPORTANT = 1000;
    public const int WEIGHT_REGULAR = 300;
    public const int WEIGHT_UNIMPORTANT = 50;
    public const int WEIGHT_VERYUNIMPORTANT = 10;
    public const int RESERVE_ASSIGN_COUNT = 4;
    public const int RESERVE_ASSIGN_ALL = 4;
    public const int RESERVE_ASSIGN_WEAK = 1;
    public const int RESERVE_ASSIGN_AVERAGE = 2;
    public const int RESERVE_ASSIGN_STRONG = 3;
    public const int RESERVE_ASSIGN_VERYSTRONG = 4;
    public const int RESERVE_ASSIGN_EXTREMELYSTRONG = 5;
    public const int ACTION_GETENCIRCLED = 1;
    public const int ACTION_MAKEENCIRCLEMENT = 2;
    public const int ACTION_LOSETOWN = 3;
    public const int ACTION_CONQUERTOWN = 4;
    public const int CATEGORY_NORMAL = 1;
    public const int CATEGORY_ARTILLERY = 2;
    public const int CATEGORY_AIRCOVER = 3;
    public const int CATEGORY_ENGINEER = 4;
    public const int CATEGORY_FLAK = 5;
    public const int CATEGORY_CARGO = 6;
    public const int CATEGORY_NAVAL = 7;
    public const int CATEGORY_AIRTRANSPORT = 8;
    public const int CATEGORY_UNKNOWN = 9;
    public const int CATEGORY_CORPS = 10;
    public const int CATEGORY_ARMY = 11;
    public const int CATEGORY_HIGHCOMMAND = 12;
    public const int CATEGORY_AIRSUPPORT = 13;
    public const int CATEGORY_VULNERABLE = 14;
    public const int CATEGORY_TRANSPORT = 15;
    public const int ROLESTAFF = 1;
    public const int ROLELANDCAP = 2;
    public const int ROLESEACAP = 3;
    public const int ROLEAIRCAP = 4;
    public const int ROLEENGINEER = 5;
    public const int ROLEINFANTRY = 6;
    public const int ROLEINFANTRYSUPPORT = 7;
    public const int ROLEARTILLERY = 8;
    public const int ROLEMOBILIZER = 9;
    public const int ROLEARMOUR = 10;
    public const int ROLEPARATROOP = 11;
    public const int ROLEAA = 12;
    public const int ROLEFIGHTER = 13;
    public const int ROLETACTICALBOMBER = 14;
    public const int ROLESTRATEGICBOMBER = 15;
    public const int ROLETRANSPORTER = 16;
    public const int ROLECARGOSHIP = 17;
    public const int ROLESEASUPRIORITY = 18;
    public const int ROLERAIDER = 19;
    public const int FRONTLINE_WEAK = 1;
    public const int FRONTLINE_AVERAGE = 2;
    public const int FRONTLINE_STRONG = 3;
    public const int FRONTLINE_VERYSTRONG = 4;
    public const int FRONTLINE_EXTREMELYSTRONG = 5;
    public const int FRONTTYPE_FRONTLINE = 1;
    public const int FRONTTYPE_RESERVE = 2;
    public const int FRONTTYPE_RESERVE_ARTILLERY = 3;
    public const int FRONTTYPE_AIR_SUPPORT = 4;
    public const int FRONTTYPE_AIR_COVER = 5;
    public const int FRONTTYPE_ENGINEER = 6;
    public const int FRONTTYPE_AIR_TRANSPORT = 7;
    public const int FRONTTYPE_NAVY = 8;
    public const int FRONTTYPE_CARGO = 9;
    public const int FRONTTYPE_STRATEGIC_RESERVE = 10;
    public const int FRONTTYPE_ENCIRCLED = 11;
    public const int FRONTTYPE_ESCAPE = 12;
    public const int FRONTTYPE_FLAK = 13;
    public const int OWNER_NEUTRAL = 0;
    public const int OWNER_FRIENDLY = 1;
    public const int OWNER_ENEMY = 2;
    public const int OWNER_ALLY = 3;
    public const int THEATER_MOVETYPE_ATTACK = 1;
    public const int THEATER_MOVETYPE_DEFEND = 2;
    public const int THEATER_MOVETYPE_FALLBACK = 3;
    public float[,] combatMatrix;
    public CustomDC2AICalls CustomCalls;
    public int initExitCode;
    private bool TempHexNeighboursSet;

    public DC2AIClass(GameClass tgame)
    {
      this.TempHexNeighbour = new Coordinate[1, 1, 6];
      this.LogTxt = new string[1];
      this.VAR_DC4_MINIMIZE_ORG_UNITS = false;
      this.VAR_DC4_ATTACKUNIT_IS_IMPORTANT = false;
      this.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE = false;
      this.VAR_FRONTLINE_DEPTH = 3;
      this.VAR_FRONTLINE_MAX_LENGTH = 12;
      this.VAR_MOVE_MAXIMUM_RANGE = 10;
      this.VAR_REINFORCEMENTS_FRIENDLY = 0;
      this.VAR_REINFORCEMENTS_ENEMY = 0;
      this.VAR_DEBUG_ON = false;
      this.VAR_CELLULAR_AUTOMATON_ITERATIONS = 4;
      this.VAR_DISABLE_RETREAT_STANCE = false;
      this.VAR_DISABLE_FULLRETREAT_STANCE = false;
      this.VAR_GARRISON_PORT_ALWAYS = false;
      this.VAR_SUPPLY_COUNTER = 3;
      this.VAR_SUPPLY_X = new int[1, 1];
      this.VAR_SUPPLY_Y = new int[1, 1];
      this.VAR_SUPPLY_ACTIVE = new bool[1, 1];
      this.VAR_STRATEGIC_WEAKNESS_AT_BOTTLENECK = true;
      this.VAR_ALLOW_OFFENSIVEGROUP_TO_OPPORTUNITY = true;
      this.VAR_ALLOW_OPPORTUNITY_ENCIRCLE = true;
      this.VAR_ALLOW_THREAT_ENCIRCLE = true;
      this.SE1_USEFLAK = false;
      this.combatMatrix = new float[2, 2];
      this.game = tgame;
      this.map = this.game.Data.MapObj[0];
    }

    public void CloseAI()
    {
      if (this.game.Data.Product >= 7)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          if (!Information.IsNothing((object) this.game.Data.UnitObj[index].tempComplexCoords))
            this.game.Data.UnitObj[index].tempComplexCoords = (ComplexCoordList) null;
        }
      }
      if (this.game.Data.Product != 6)
        return;
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter; ++index)
        this.game.Data.HistoricalUnitObj[index].AIlist = 0;
      GC.Collect();
      Application.DoEvents();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (!Information.IsNothing((object) this.game.Data.UnitObj[index].tempComplexCoords))
          this.game.Data.UnitObj[index].tempComplexCoords = (ComplexCoordList) null;
      }
    }

    public void DynamicOob(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if (!this.VAR_USE_DYNAMIC_OOB)
        return;
      this.AddLog("DYNAMIC OOB");
      if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
      {
        this.DynamicOobNewArmy(ref TempList, ref frontlines);
        this.DynamicOobNewCorps(ref TempList, ref frontlines);
      }
      this.DynamicOobmissingUnits(ref TempList, ref frontlines);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
        this.DynamicOobnewUnits(ref TempList, ref frontlines);
      this.DynamicOobremoveUnits(ref TempList, ref frontlines);
      this.WriteLog("dynamic_oob");
    }

    public void DynamicOobnewUnits(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if (!this.VAR_USE_DYNAMIC_OOB || !this.VAR_USE_ADD_UNIT)
        return;
      this.AddLog("DYNAMIC OOB : NEW UNITS");
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
      tai2 = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai2);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix3.Left, aiMatrix3.Top, aiMatrix3.Width, aiMatrix3.Height);
      AIMatrix enemyDist = mask.Clone();
      enemyDist.RemoveValuesByMask(mask, 1);
      enemyDist.ExpandAndAddValueForAnyRegime(24);
      enemyDist.SetAllValuesSubtractWith(2);
      SimpleList simpleList1 = this.CreatableModels();
      int index1 = this.game.HandyFunctionsObj.GetSingleCapHQ();
      if (index1 <= -1)
      {
        int num1 = 5;
        int num2 = -1;
        int num3 = 0;
        int unitCounter = this.game.Data.UnitCounter;
        for (int index2 = 0; index2 <= unitCounter; ++index2)
        {
          if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index2].IsHQ & this.game.Data.UnitObj[index2].PreDef == -1 & this.game.Data.UnitObj[index2].X > -1)
          {
            int historical = this.game.Data.UnitObj[index2].Historical;
            if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type >= num1 & this.game.Data.UnitObj[index2].SupplyIn > num3)
            {
              num1 = this.game.Data.HistoricalUnitObj[historical].Type;
              num2 = index2;
              num3 = this.game.Data.UnitObj[index2].SupplyIn;
            }
          }
        }
        if (num2 > -1)
          index1 = num2;
      }
      if (index1 <= -1)
        return;
      int underhighhq = index1;
      int historical1 = this.game.Data.UnitObj[index1].Historical;
      bool flag = true;
      int num4 = 0;
      while (flag & num4 < 20)
      {
        flag = false;
        ++num4;
        SimpleList SameArmyL = new SimpleList();
        int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
        for (int index3 = 0; index3 <= historicalUnitCounter1; ++index3)
        {
          if (this.game.Data.HistoricalUnitObj[index3].Type < 5 && !this.game.Data.HistoricalUnitObj[index3].Model)
          {
            int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(index3);
            if (unitByHistorical > -1 && this.game.Data.UnitObj[unitByHistorical].Regime == this.game.Data.Turn)
              SameArmyL.Add(index3, 0);
          }
        }
        SimpleList simpleList2 = new SimpleList();
        int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
        for (int index4 = 0; index4 <= historicalUnitCounter2; ++index4)
        {
          if (index4 == 747)
            index4 = index4;
          if (this.game.Data.HistoricalUnitObj[index4].Model & this.game.Data.HistoricalUnitObj[index4].Type < 5 && this.game.Data.HistoricalUnitObj[index4].TempRegime == this.game.Data.Turn | this.game.Data.HistoricalUnitObj[index4].TempRegime == -1 && simpleList1.FindNr(index4) > -1)
          {
            int num5 = 0;
            int val2_1 = 0;
            int num6 = 0;
            int val2_2 = 0;
            int num7 = 0;
            int addneedsforHisSubpart = 0;
            do
            {
              int subPart = this.game.Data.HistoricalUnitObj[index4].SubParts[addneedsforHisSubpart];
              if (subPart > -1)
              {
                int preDef = this.game.HandyFunctionsObj.GetPreDef(subPart);
                if (preDef > -1)
                {
                  int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                  for (int index5 = 0; index5 <= sfCount; ++index5)
                  {
                    int sf = this.game.Data.UnitObj[preDef].SFList[index5];
                    int type = this.game.Data.SFObj[sf].Type;
                    if (!(this.GetAIRolePercent(preDef, 6) <= 40 & this.game.Data.SFTypeObj[type].AIRoleScore[6] > 0))
                    {
                      int num8 = this.GetPercentageOfModelRequiredForASingleUnit(historical1, -1, index4, addneedsforHisSubpart, this.game.Data.SFObj[sf].People, this.game.Data.SFTypeObj[type].ReinforcementType);
                      if (num8 > 100)
                        num8 = 100;
                      num5 += num8 * this.game.Data.SFObj[sf].Qty;
                      val2_1 += this.game.Data.SFObj[sf].Qty;
                      int num9 = this.GetPercentageOfModelRequiredForAllUnits(-1, this.game.Data.SFObj[sf].People, -1, -1, this.game.Data.SFTypeObj[type].ReinforcementType, 9999, underhighhq);
                      if (num9 > 100)
                        num9 = 100;
                      num6 += num9 * this.game.Data.SFObj[sf].Qty;
                      if (num9 > 0)
                        ++num7;
                      val2_2 += this.game.Data.SFObj[sf].Qty;
                    }
                    else
                      num5 = num5;
                  }
                }
              }
              ++addneedsforHisSubpart;
            }
            while (addneedsforHisSubpart <= 9);
            int num10 = (int) Math.Round((double) num5 / (double) Math.Max(1, val2_1));
            int num11 = (int) Math.Round((double) num6 / (double) Math.Max(1, val2_2));
            if (num10 > 60 && num11 > 85 | num7 == 0)
              simpleList2.Add(index4, 0);
          }
        }
        int counter = simpleList2.Counter;
        for (int index6 = 0; index6 <= counter; ++index6)
        {
          int his = simpleList2.Id[index6];
          tai2 = this;
          AIMatrix bmatrix1 = new AIMatrix(ref tai2);
          bmatrix1.SetAllValuesTo(9999);
          AIMatrix bmatrix2 = this.AddScores(ref bmatrix1, ref SameArmyL, -12f, 12);
          AIMatrix bmatrix3 = this.AddPenaltyScoreForEnemyDistance(ref bmatrix2, ref enemyDist, 16, -99f);
          bmatrix3.RemoveValuesByNotMask(mask, 1);
          bmatrix3.RemoveValuesByMask(enemyDist, -2);
          bmatrix3.RemoveValuesByMask(mask, 2);
          bmatrix3.RemoveValuesByMask(mask, 0);
          bmatrix3.SetValueXToValueY(0, -999999);
          int mapWidth = this.map.MapWidth;
          for (int index7 = 0; index7 <= mapWidth; ++index7)
          {
            int mapHeight = this.map.MapHeight;
            for (int index8 = 0; index8 <= mapHeight; ++index8)
            {
              if (this.game.Data.LandscapeTypeObj[this.map.HexObj[index7, index8].LandscapeType].AIBlock > 0)
                bmatrix3.Value[index7, index8] = -999999;
              if (bmatrix3.Value[index7, index8] > 0)
              {
                int[,] numArray1 = bmatrix3.Value;
                int[,] numArray2 = numArray1;
                int index9 = index7;
                int index10 = index9;
                int index11 = index8;
                int index12 = index11;
                int num12 = numArray1[index9, index11] + (int) Math.Round((double) (VBMath.Rnd() * 500f));
                numArray2[index10, index12] = num12;
                if (this.map.HexObj[index7, index8].Location == -1 | this.map.HexObj[index7, index8].VP < 1)
                  bmatrix3.Value[index7, index8] = 0;
              }
            }
          }
          Coordinate coordinate = this.ReturnHighestHex(ref bmatrix3);
          if (coordinate.onmap)
          {
            this.game.ProcessingObj.AddNewUnitBasedOnHistorical(coordinate.x, coordinate.y, 0, this.game.Data.Turn, his);
            this.AddLog("Added " + this.game.Data.HistoricalUnitObj[his].Name + " NEW UNIT on " + coordinate.x.ToString() + "," + coordinate.y.ToString());
            flag = true;
            ++num4;
          }
        }
      }
    }

    public void DynamicOobmissingUnits(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if ((double) this.game.Data.RuleVar[913] < 1.0 || (double) this.game.Data.RuleVar[527] < 1.0)
        return;
      this.AddLog("DYNAMIC OOB : MISSING UNITS");
      SimpleList simpleList1 = new SimpleList();
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix3.Left, aiMatrix3.Top, aiMatrix3.Width, aiMatrix3.Height);
      AIMatrix enemyDist = mask.Clone();
      enemyDist.RemoveValuesByMask(mask, 1);
      enemyDist.ExpandAndAddValueForAnyRegime(19);
      enemyDist.SetAllValuesSubtractWith(2);
      int[] numArray1 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[,] numArray3 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[,] numArray4 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[] numArray5 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical > -1 & this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn)
        {
          int[] numArray6 = numArray1;
          int[] numArray7 = numArray6;
          int historical1 = this.game.Data.UnitObj[index1].Historical;
          int index2 = historical1;
          int num1 = numArray6[historical1] + 1;
          numArray7[index2] = num1;
          if (this.game.Data.UnitObj[index1].HistoricalSubPart > -1)
          {
            int[,] numArray8 = numArray3;
            int[,] numArray9 = numArray8;
            int historical2 = this.game.Data.UnitObj[index1].Historical;
            int index3 = historical2;
            int historicalSubPart = this.game.Data.UnitObj[index1].HistoricalSubPart;
            int index4 = historicalSubPart;
            int num2 = numArray8[historical2, historicalSubPart] + 1;
            numArray9[index3, index4] = num2;
          }
        }
      }
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter1; ++index5)
      {
        if (numArray1[index5] > 0 && this.game.Data.HistoricalUnitObj[index5].ModelMaster > -1)
        {
          int[] numArray10 = numArray5;
          int[] numArray11 = numArray10;
          int modelMaster = this.game.Data.HistoricalUnitObj[index5].ModelMaster;
          int index6 = modelMaster;
          int num = numArray10[modelMaster] + 1;
          numArray11[index6] = num;
        }
      }
      int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
      for (int index7 = 0; index7 <= historicalUnitCounter2; ++index7)
      {
        int index8 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[index7].SubParts[index8] > -1)
          {
            int[] numArray12 = numArray2;
            int[] numArray13 = numArray12;
            int index9 = index7;
            int index10 = index9;
            int num = numArray12[index9] + 1;
            numArray13[index10] = num;
          }
          int[,] numArray14 = numArray4;
          int[,] numArray15 = numArray14;
          int index11 = index7;
          int index12 = index11;
          int index13 = index8;
          int index14 = index13;
          int num3 = numArray14[index11, index13] + 1;
          numArray15[index12, index14] = num3;
          ++index8;
        }
        while (index8 <= 9);
      }
      SimpleList simpleList2 = new SimpleList();
      int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
      for (int tdata1 = 0; tdata1 <= historicalUnitCounter3; ++tdata1)
      {
        if (this.game.Data.HistoricalUnitObj[tdata1].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata1].ModelMaster > -1 && numArray1[tdata1] < numArray2[tdata1] & numArray1[tdata1] > 0)
        {
          int tdata2 = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[tdata1].SubParts[tdata2] > -1 && numArray3[tdata1, tdata2] == 0 & numArray4[tdata1, tdata2] > 0)
              simpleList2.Add(tdata1 * 100 + tdata2, 0, tdata1, tdata2);
            ++tdata2;
          }
          while (tdata2 <= 9);
        }
      }
      int counter = simpleList2.Counter;
      for (int index15 = 0; index15 <= counter; ++index15)
      {
        int index16 = simpleList2.Data1[index15];
        int index17 = simpleList2.Data2[index15];
        int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(this.game.Data.HistoricalUnitObj[index16].ID);
        if (unitByHistorical > -1)
        {
          SimpleList SameArmyL = new SimpleList();
          SameArmyL.Add(index16, 0);
          int val2 = 0;
          int num4 = 0;
          int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index16].SubParts[index17]);
          int topHq;
          if (preDef > -1)
          {
            int sfCount = this.game.Data.UnitObj[preDef].SFCount;
            for (int index18 = 0; index18 <= sfCount; ++index18)
            {
              int sf = this.game.Data.UnitObj[preDef].SFList[index18];
              int type = this.game.Data.SFObj[sf].Type;
              topHq = this.game.HandyFunctionsObj.GetTopHQ(unitByHistorical);
              int requiredForAllUnits = this.GetPercentageOfModelRequiredForAllUnits(-1, this.game.Data.SFObj[sf].People, index16, index17, this.game.Data.SFTypeObj[type].ReinforcementType, 9999, topHq);
              num4 += requiredForAllUnits * this.game.Data.SFObj[sf].Qty;
              val2 += this.game.Data.SFObj[sf].Qty;
            }
          }
          int num5 = (int) Math.Round((double) num4 / (double) Math.Max(1, val2));
          if (topHq > -1 && Strings.InStr(this.game.Data.UnitObj[topHq].Name, "Tiblisi") <= 0)
            num5 = num5;
          if (num5 > 70)
          {
            tai = this;
            AIMatrix bmatrix = new AIMatrix(ref tai);
            bmatrix = this.AddScores(ref bmatrix, ref SameArmyL, 100f, 13);
            bmatrix = this.AddPenaltyScoreForEnemyDistance(ref bmatrix, ref enemyDist, 16, -99f);
            bmatrix.RemoveValuesByMask(mask, 2);
            bmatrix.RemoveValuesByMask(mask, 0);
            bmatrix.SetValueXToValueY(0, -999999);
            int mapWidth = this.map.MapWidth;
            for (int index19 = 0; index19 <= mapWidth; ++index19)
            {
              int mapHeight = this.map.MapHeight;
              for (int index20 = 0; index20 <= mapHeight; ++index20)
              {
                if (this.game.Data.LandscapeTypeObj[this.map.HexObj[index19, index20].LandscapeType].AIBlock > 0)
                  bmatrix.Value[index19, index20] = -999999;
              }
            }
            Coordinate coordinate = this.ReturnHighestHex(ref bmatrix);
            if (coordinate.onmap)
            {
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(coordinate.x, coordinate.y, 0, this.game.Data.Turn, index16, index17);
              this.AddLog("Added " + this.game.Data.HistoricalUnitObj[index16].Name + " PART OF UNIT on " + coordinate.x.ToString() + "," + coordinate.y.ToString());
            }
          }
        }
      }
    }

    public void DynamicOobremoveUnits(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if ((double) this.game.Data.RuleVar[913] < 1.0 || (double) this.game.Data.RuleVar[337] < 1.0)
        return;
      this.AddLog("DYNAMIC OOB : MISSING UNITS");
      SimpleList simpleList1 = new SimpleList();
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix3.Left, aiMatrix3.Top, aiMatrix3.Width, aiMatrix3.Height);
      AIMatrix aiMatrix4 = mask.Clone();
      aiMatrix4.RemoveValuesByMask(mask, 1);
      aiMatrix4.ExpandAndAddValueForAnyRegime(9);
      aiMatrix4.SetAllValuesSubtractWith(2);
      int[] numArray1 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[,] numArray3 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[,] numArray4 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[] numArray5 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical > -1 & this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn)
        {
          int[] numArray6 = numArray1;
          int[] numArray7 = numArray6;
          int historical1 = this.game.Data.UnitObj[index1].Historical;
          int index2 = historical1;
          int num1 = numArray6[historical1] + 1;
          numArray7[index2] = num1;
          if (this.game.Data.UnitObj[index1].HistoricalSubPart > -1)
          {
            int[,] numArray8 = numArray3;
            int[,] numArray9 = numArray8;
            int historical2 = this.game.Data.UnitObj[index1].Historical;
            int index3 = historical2;
            int historicalSubPart = this.game.Data.UnitObj[index1].HistoricalSubPart;
            int index4 = historicalSubPart;
            int num2 = numArray8[historical2, historicalSubPart] + 1;
            numArray9[index3, index4] = num2;
          }
        }
      }
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter1; ++index5)
      {
        if (numArray1[index5] > 0 && this.game.Data.HistoricalUnitObj[index5].ModelMaster > -1)
        {
          int[] numArray10 = numArray5;
          int[] numArray11 = numArray10;
          int modelMaster = this.game.Data.HistoricalUnitObj[index5].ModelMaster;
          int index6 = modelMaster;
          int num = numArray10[modelMaster] + 1;
          numArray11[index6] = num;
        }
      }
      int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
      for (int index7 = 0; index7 <= historicalUnitCounter2; ++index7)
      {
        int index8 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[index7].SubParts[index8] > -1)
          {
            int[] numArray12 = numArray2;
            int[] numArray13 = numArray12;
            int index9 = index7;
            int index10 = index9;
            int num = numArray12[index9] + 1;
            numArray13[index10] = num;
          }
          int[,] numArray14 = numArray4;
          int[,] numArray15 = numArray14;
          int index11 = index7;
          int index12 = index11;
          int index13 = index8;
          int index14 = index13;
          int num3 = numArray14[index11, index13] + 1;
          numArray15[index12, index14] = num3;
          ++index8;
        }
        while (index8 <= 9);
      }
      SimpleList simpleList2 = new SimpleList();
      int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
      for (int tdata1 = 0; tdata1 <= historicalUnitCounter3; ++tdata1)
      {
        if (this.game.Data.HistoricalUnitObj[tdata1].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata1].ModelMaster > -1 && numArray1[tdata1] < numArray2[tdata1] & numArray1[tdata1] > 0)
        {
          int tdata2 = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[tdata1].SubParts[tdata2] > -1 && numArray3[tdata1, tdata2] == 0 & numArray4[tdata1, tdata2] > 0)
              simpleList2.Add(tdata1 * 100 + tdata2, 0, tdata1, tdata2);
            ++tdata2;
          }
          while (tdata2 <= 9);
        }
      }
      SimpleList simpleList3 = new SimpleList();
      int historicalUnitCounter4 = this.game.Data.HistoricalUnitCounter;
      for (int index15 = 0; index15 <= historicalUnitCounter4; ++index15)
      {
        if (this.game.Data.HistoricalUnitObj[index15].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[index15].Type < 5 & this.game.Data.HistoricalUnitObj[index15].ModelMaster > -1 && numArray5[this.game.Data.HistoricalUnitObj[index15].ModelMaster] > 1)
        {
          int num4 = 0;
          int num5 = 0;
          int num6 = 0;
          int num7 = 0;
          int index16 = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[index15].SubParts[index16] > -1)
            {
              int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(index15, index16);
              if (unitByHistorical > -1)
              {
                if (this.game.Data.UnitObj[unitByHistorical].SOReplacementPercent > 0)
                {
                  int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(unitByHistorical);
                  int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unitByHistorical);
                  int startPower = this.game.HandyFunctionsObj.GetStartPower(unitByHistorical);
                  int num8 = (int) Math.Round((double) startPower * ((double) breakPercent / 100.0));
                  int num9 = startPower != 0 ? Math.Min(100, (int) Math.Round((double) powerPtsAbsolute / (double) startPower * 100.0)) : 100;
                  ++num5;
                  num4 += num9;
                }
                else if (simpleList2.FindNr(0, index15, index16) > -1)
                {
                  ++num5;
                  num4 += 0;
                }
                int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index15].SubParts[index16]);
                if (preDef > -1)
                {
                  int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                  for (int index17 = 0; index17 <= sfCount; ++index17)
                  {
                    int sf = this.game.Data.UnitObj[preDef].SFList[index17];
                    int type = this.game.Data.SFObj[sf].Type;
                    int requiredForAllUnits = this.GetPercentageOfModelRequiredForAllUnits(-1, this.game.Data.SFObj[sf].People, index15, index16, this.game.Data.SFTypeObj[type].ReinforcementType, 9999, -1);
                    num6 += requiredForAllUnits * this.game.Data.SFObj[sf].Qty;
                    num7 += this.game.Data.SFObj[sf].Qty;
                  }
                }
              }
            }
            ++index16;
          }
          while (index16 <= 9);
          if (num5 > 0)
          {
            int num10 = (int) Math.Round((double) num4 / (double) num5);
            int num11 = (int) Math.Round((double) num6 / (double) num7);
            if (num10 < 40 && num11 < 50)
            {
              int subp = 0;
              do
              {
                if (this.game.Data.HistoricalUnitObj[index15].SubParts[subp] > -1)
                {
                  int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(index15, subp);
                  if (unitByHistorical > -1)
                  {
                    this.AddLog("Remove " + this.game.Data.UnitObj[unitByHistorical].Name + " by setting it to disband");
                    this.game.Data.UnitObj[unitByHistorical].SOReplacementPercent = 0;
                  }
                }
                ++subp;
              }
              while (subp <= 9);
            }
          }
        }
      }
    }

    public void DynamicOobNewCorps(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if (!this.VAR_USE_DYNAMIC_OOB || !this.VAR_USE_ADD_UNIT)
        return;
      this.AddLog("DYNAMIC OOB : NEW CORPS");
      SimpleList simpleList1 = new SimpleList();
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix3.Left, aiMatrix3.Top, aiMatrix3.Width, aiMatrix3.Height);
      AIMatrix enemyDist = mask.Clone();
      enemyDist.RemoveValuesByMask(mask, 1);
      enemyDist.ExpandAndAddValueForAnyRegime(9);
      enemyDist.SetAllValuesSubtractWith(2);
      AIMatrix aiMatrix4 = this.strengthMatrix.Clone();
      aiMatrix4.ExpandUniquesValuesForSameRegime(39);
      SimpleList simpleList2 = this.CreatableModels();
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int tid = 0; tid <= historicalUnitCounter1; ++tid)
      {
        if (this.game.Data.HistoricalUnitObj[tid].Type == 5 && this.game.Data.HistoricalUnitObj[tid].Model && this.game.Data.HistoricalUnitObj[tid].TempRegime == this.game.Data.Turn)
          simpleList1.Add(tid, 0, this.game.Data.HistoricalUnitObj[tid].People);
      }
      SimpleList simpleList3 = new SimpleList();
      int counter = simpleList1.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        if (simpleList2.FindNr(simpleList1.Id[index1]) > -1)
        {
          int index2 = simpleList1.Id[index1];
          SimpleList SameArmyL1 = new SimpleList();
          int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
          for (int index3 = 0; index3 <= historicalUnitCounter2; ++index3)
          {
            if (this.game.Data.HistoricalUnitObj[index3].Type == 5 && !this.game.Data.HistoricalUnitObj[index3].Model && this.game.HandyFunctionsObj.GetUnitByHistorical(index3) > -1 && this.game.Data.HistoricalUnitObj[index3].TempRegime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[index3].People == this.game.Data.HistoricalUnitObj[index2].People)
              SameArmyL1.Add(index3, 0);
          }
          SimpleList SameArmyL2 = new SimpleList();
          int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
          for (int index4 = 0; index4 <= historicalUnitCounter3; ++index4)
          {
            if (this.game.Data.HistoricalUnitObj[index4].Type < 5 && !this.game.Data.HistoricalUnitObj[index4].Model && this.game.HandyFunctionsObj.GetUnitByHistorical(index4) > -1 && this.game.Data.HistoricalUnitObj[index4].TempRegime == this.game.Data.Turn | this.game.Data.HistoricalUnitObj[index4].TempRegime == -1 && this.game.Data.HistoricalUnitObj[index4].People == this.game.Data.HistoricalUnitObj[index2].People)
              SameArmyL2.Add(index4, 0);
          }
          if (this.GetOfficerFromOfficerPool(this.game.Data.HistoricalUnitObj[index2].People) > -1 | (double) this.game.Data.RuleVar[934] > 0.0)
          {
            int requiredForAllUnits = this.GetPercentageOfModelRequiredForAllUnits(1, this.game.Data.HistoricalUnitObj[index2].People, index2, 0, -1, 9999, -1);
            int averageHqPower = this.GetAverageHQPower(-1, -1, -1);
            if (requiredForAllUnits > 60 & averageHqPower < 66 | requiredForAllUnits > 120 & this.NeedCorps() | requiredForAllUnits > 60 & this.NeedCorps(2))
            {
              tai = this;
              AIMatrix bmatrix = new AIMatrix(ref tai);
              bmatrix = this.AddScores(ref bmatrix, ref SameArmyL1, -500f, 10);
              bmatrix = this.AddScores(ref bmatrix, ref SameArmyL2, 13f, 12);
              bmatrix = this.AddPenaltyScoreForEnemyDistance(ref bmatrix, ref enemyDist, 10, -500f);
              int mapWidth1 = this.map.MapWidth;
              for (int index5 = 0; index5 <= mapWidth1; ++index5)
              {
                int mapHeight = this.map.MapHeight;
                for (int index6 = 0; index6 <= mapHeight; ++index6)
                {
                  if (aiMatrix4.Value[index5, index6] == 2)
                    bmatrix.Value[index5, index6] = (int) Math.Round((double) bmatrix.Value[index5, index6] * 0.9);
                  if (aiMatrix4.Value[index5, index6] == 3)
                    bmatrix.Value[index5, index6] = (int) Math.Round((double) bmatrix.Value[index5, index6] * 0.7);
                }
              }
              int mapWidth2 = this.map.MapWidth;
              for (int index7 = 0; index7 <= mapWidth2; ++index7)
              {
                int mapHeight = this.map.MapHeight;
                for (int index8 = 0; index8 <= mapHeight; ++index8)
                {
                  if (this.game.Data.LandscapeTypeObj[this.map.HexObj[index7, index8].LandscapeType].AIBlock > 0)
                    bmatrix.Value[index7, index8] = -999999;
                }
              }
              Coordinate coordinate = this.ReturnHighestHex(ref bmatrix);
              if (coordinate.onmap)
              {
                this.game.ProcessingObj.AddNewUnitBasedOnHistorical(coordinate.x, coordinate.y, 0, this.game.Data.Turn, index2);
                this.AddLog("Added " + this.game.Data.HistoricalUnitObj[index2].Name + " CORPS HQ on " + coordinate.x.ToString() + "," + coordinate.y.ToString());
              }
            }
          }
        }
      }
    }

    public bool NeedCorps(int corpsmulti = 1)
    {
      int unitCounter1 = this.game.Data.UnitCounter;
      int num1;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 && !this.game.Data.UnitObj[unr].IsHQ && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
          ++num1;
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      int num2;
      for (int unr = 0; unr <= unitCounter2; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].Type == 5 && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
          ++num2;
      }
      int num3 = num2 * corpsmulti;
      return (double) this.game.Data.RuleVar[935] > 0.0 && (int) Math.Round((double) ((float) num3 * this.game.Data.RuleVar[935])) < num1;
    }

    public bool NeedArmy(int armymulti = 1)
    {
      int unitCounter1 = this.game.Data.UnitCounter;
      int num1;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].Type == 5 && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
          ++num1;
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      int num2;
      for (int unr = 0; unr <= unitCounter2; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].Type == 6 && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
          ++num2;
      }
      int num3 = num2 * armymulti;
      return (double) this.game.Data.RuleVar[936] > 0.0 && (int) Math.Round((double) ((float) num3 * this.game.Data.RuleVar[936])) < num1;
    }

    public void DynamicOobNewArmy(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if (!this.VAR_USE_DYNAMIC_OOB || !this.VAR_USE_ADD_UNIT)
        return;
      this.AddLog("DYNAMIC OOB : NEW ARMY");
      SimpleList simpleList1 = new SimpleList();
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix3.Left, aiMatrix3.Top, aiMatrix3.Width, aiMatrix3.Height);
      AIMatrix enemyDist = mask.Clone();
      enemyDist.RemoveValuesByMask(mask, 1);
      enemyDist.ExpandAndAddValueForAnyRegime(9);
      enemyDist.SetAllValuesSubtractWith(2);
      SimpleList simpleList2 = this.CreatableModels();
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int tid = 0; tid <= historicalUnitCounter1; ++tid)
      {
        if (this.game.Data.HistoricalUnitObj[tid].Type == 6 && this.game.Data.HistoricalUnitObj[tid].Model && this.game.Data.HistoricalUnitObj[tid].TempRegime == this.game.Data.Turn)
          simpleList1.Add(tid, 0, this.game.Data.HistoricalUnitObj[tid].People);
      }
      SimpleList simpleList3 = new SimpleList();
      int counter = simpleList1.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        if (simpleList2.FindNr(simpleList1.Id[index1]) > -1)
        {
          int index2 = simpleList1.Id[index1];
          SimpleList SameArmyL1 = new SimpleList();
          SimpleList SameArmyL2 = new SimpleList();
          int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
          for (int index3 = 0; index3 <= historicalUnitCounter2; ++index3)
          {
            if (this.game.Data.HistoricalUnitObj[index3].Type == 5 && !this.game.Data.HistoricalUnitObj[index3].Model && this.game.HandyFunctionsObj.GetUnitByHistorical(index3) > -1 && this.game.Data.HistoricalUnitObj[index3].TempRegime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[index3].People == this.game.Data.HistoricalUnitObj[index2].People)
              SameArmyL1.Add(index3, 0);
          }
          int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
          for (int index4 = 0; index4 <= historicalUnitCounter3; ++index4)
          {
            if (this.game.Data.HistoricalUnitObj[index4].Type == 6 && !this.game.Data.HistoricalUnitObj[index4].Model && this.game.HandyFunctionsObj.GetUnitByHistorical(index4) > -1 && this.game.Data.HistoricalUnitObj[index4].TempRegime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[index4].People == this.game.Data.HistoricalUnitObj[index2].People)
              SameArmyL2.Add(index4, 0);
          }
          if (SameArmyL2.Counter + 1 < (int) Math.Round(Conversion.Int((double) (SameArmyL1.Counter + 1) / 3.0)) | SameArmyL2.Counter == -1 & SameArmyL1.Counter > -1 && this.GetOfficerFromOfficerPool(this.game.Data.HistoricalUnitObj[index2].People) > -1)
          {
            int requiredForAllUnits = this.GetPercentageOfModelRequiredForAllUnits(1, this.game.Data.HistoricalUnitObj[index2].People, index2, 0, -1, 9999, -1);
            if (requiredForAllUnits > 100 & this.NeedArmy() | requiredForAllUnits > 50 & this.NeedArmy(2))
            {
              tai = this;
              AIMatrix bmatrix = new AIMatrix(ref tai);
              bmatrix = this.AddScores(ref bmatrix, ref SameArmyL2, -50f, 50);
              bmatrix = this.AddScores(ref bmatrix, ref SameArmyL1, 35f, 35);
              bmatrix = this.AddPenaltyScoreForEnemyDistance(ref bmatrix, ref enemyDist, 10, -20f);
              int mapWidth = this.map.MapWidth;
              for (int index5 = 0; index5 <= mapWidth; ++index5)
              {
                int mapHeight = this.map.MapHeight;
                for (int index6 = 0; index6 <= mapHeight; ++index6)
                {
                  if (this.game.Data.LandscapeTypeObj[this.map.HexObj[index5, index6].LandscapeType].AIBlock > 0)
                    bmatrix.Value[index5, index6] = -999999;
                }
              }
              Coordinate coordinate = this.ReturnHighestHex(ref bmatrix);
              if (coordinate.onmap)
              {
                this.game.ProcessingObj.AddNewUnitBasedOnHistorical(coordinate.x, coordinate.y, 0, this.game.Data.Turn, index2);
                this.AddLog("Added " + this.game.Data.HistoricalUnitObj[index2].Name + " ARMY HQ on " + coordinate.x.ToString() + "," + coordinate.y.ToString());
              }
            }
          }
        }
      }
    }

    public Coordinate ReturnHighestHex(ref AIMatrix bmatrix)
    {
      int num1 = -1;
      int num2 = -999999;
      int mapWidth = this.map.MapWidth;
      int num3;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (bmatrix.Value[index1, index2] > num2)
          {
            num2 = bmatrix.Value[index1, index2];
            num1 = index1;
            num3 = index2;
          }
        }
      }
      Coordinate coordinate = new Coordinate();
      coordinate.x = num1;
      coordinate.y = num3;
      if (num1 > -1)
        coordinate.onmap = true;
      return coordinate;
    }

    public AIMatrix AddScores(
      ref AIMatrix bmatrix,
      ref SimpleList SameArmyL,
      float modifier,
      int spreadRange)
    {
      int counter = SameArmyL.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        int his = SameArmyL.Id[index1];
        int subp = 0;
        do
        {
          int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(his, subp);
          if (unitByHistorical > -1)
          {
            DC2AIClass tai = this;
            AIMatrix aiMatrix = new AIMatrix(ref tai);
            aiMatrix.SetAllValuesTo(0);
            int x = this.game.Data.UnitObj[unitByHistorical].X;
            int y = this.game.Data.UnitObj[unitByHistorical].Y;
            if (x > -1)
              aiMatrix.Value[x, y] = Math.Abs(10);
            aiMatrix.ExpandAndRemoveValueForAnyRegime(spreadRange);
            int mapWidth = this.map.MapWidth;
            for (int index2 = 0; index2 <= mapWidth; ++index2)
            {
              int mapHeight = this.map.MapHeight;
              for (int index3 = 0; index3 <= mapHeight; ++index3)
              {
                if ((double) modifier >= 0.0)
                {
                  int[,] numArray1 = bmatrix.Value;
                  int[,] numArray2 = numArray1;
                  int index4 = index2;
                  int index5 = index4;
                  int index6 = index3;
                  int index7 = index6;
                  int num = numArray1[index4, index6] + (int) Math.Round((double) ((float) aiMatrix.Value[index2, index3] * modifier));
                  numArray2[index5, index7] = num;
                }
                else
                {
                  int[,] numArray3 = bmatrix.Value;
                  int[,] numArray4 = numArray3;
                  int index8 = index2;
                  int index9 = index8;
                  int index10 = index3;
                  int index11 = index10;
                  int num = numArray3[index8, index10] + (int) Math.Round((double) ((float) aiMatrix.Value[index2, index3] * modifier));
                  numArray4[index9, index11] = num;
                }
              }
            }
          }
          ++subp;
        }
        while (subp <= 9);
      }
      return bmatrix;
    }

    public AIMatrix AddPenaltyScoreForEnemyDistance(
      ref AIMatrix bmatrix,
      ref AIMatrix enemyDist,
      int maxDist,
      float modifier)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          int num1 = enemyDist.Value[index1, index2] <= 0 ? -9999 : (int) Math.Round((double) ((float) Math.Max(0, maxDist + 1 - enemyDist.Value[index1, index2]) * modifier));
          int[,] numArray1 = bmatrix.Value;
          int[,] numArray2 = numArray1;
          int index3 = index1;
          int index4 = index3;
          int index5 = index2;
          int index6 = index5;
          int num2 = numArray1[index3, index5] + num1;
          numArray2[index4, index6] = num2;
        }
      }
      return bmatrix;
    }

    public int GetOfficerFromOfficerPool(int ppl)
    {
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int officerFromOfficerPool = 0; officerFromOfficerPool <= historicalUnitCounter; ++officerFromOfficerPool)
      {
        if (this.game.Data.HistoricalUnitObj[officerFromOfficerPool].TempRegime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[officerFromOfficerPool].Pool && this.game.Data.HistoricalUnitObj[officerFromOfficerPool].People == ppl)
          return officerFromOfficerPool;
      }
      return -1;
    }

    public int GetPercentageOfModelRequiredForAllUnits(
      int aiRoleType,
      int ppl,
      int addNeedsForHis,
      int addneedsforHisSubpart,
      int reinfType,
      int maximumInd,
      int underhighhq)
    {
      int num1 = 0;
      int num2 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
        {
          int historical = this.game.Data.UnitObj[unr].Historical;
          int historicalSubPart = this.game.Data.UnitObj[unr].HistoricalSubPart;
          if (historical > -1 & historicalSubPart > -1)
          {
            if (this.game.Data.UnitObj[unr].SOReplacementPercent > 0 & this.game.Data.UnitObj[unr].SupplyConsume > 0 & this.game.HandyFunctionsObj.IsUnitInHQChain(unr, underhighhq))
            {
              int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[historical].SubParts[historicalSubPart]);
              if (historical == 466)
                ;
              if (preDef > -1)
              {
                int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                for (int index = 0; index <= sfCount; ++index)
                {
                  int sf = this.game.Data.UnitObj[preDef].SFList[index];
                  int type = this.game.Data.SFObj[sf].Type;
                  if (aiRoleType > -1)
                  {
                    if (this.game.Data.SFTypeObj[type].AIRoleScore[aiRoleType] > 0 | aiRoleType == 1 & this.game.Data.SFTypeObj[type].StaffPts > 0 && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                    {
                      if (maximumInd < this.game.Data.SFObj[sf].Qty)
                        num1 += maximumInd;
                      else
                        num1 += this.game.Data.SFObj[sf].Qty;
                    }
                  }
                  else if (reinfType > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfType | this.game.Data.SFTypeObj[type].ReinforcementType2 == reinfType && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                  {
                    if (maximumInd < this.game.Data.SFObj[sf].Qty)
                      num1 += maximumInd;
                    else
                      num1 += this.game.Data.SFObj[sf].Qty;
                  }
                }
              }
            }
            int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
            for (int index = 0; index <= sfCount1; ++index)
            {
              if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, underhighhq))
              {
                int sf = this.game.Data.UnitObj[unr].SFList[index];
                int type = this.game.Data.SFObj[sf].Type;
                if (aiRoleType > -1)
                {
                  if (this.game.Data.SFTypeObj[type].AIRoleScore[aiRoleType] > 0 | aiRoleType == 1 & this.game.Data.SFTypeObj[type].StaffPts > 0 && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                    num2 += this.game.Data.SFObj[sf].Qty;
                }
                else if (reinfType > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfType | this.game.Data.SFTypeObj[type].ReinforcementType2 == reinfType && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                  num2 += this.game.Data.SFObj[sf].Qty;
              }
            }
          }
        }
      }
      if (addNeedsForHis > -1 & addneedsforHisSubpart > -1)
      {
        int index1 = addNeedsForHis;
        int index2 = addneedsforHisSubpart;
        if (index1 > -1 & index2 > -1)
        {
          int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index1].SubParts[index2]);
          if (preDef > -1)
          {
            int sfCount = this.game.Data.UnitObj[preDef].SFCount;
            for (int index3 = 0; index3 <= sfCount; ++index3)
            {
              int sf = this.game.Data.UnitObj[preDef].SFList[index3];
              int type = this.game.Data.SFObj[sf].Type;
              if (aiRoleType > -1)
              {
                if (this.game.Data.SFTypeObj[type].AIRoleScore[aiRoleType] > 0 | aiRoleType == 1 & this.game.Data.SFTypeObj[type].StaffPts > 0 && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                  num1 += this.game.Data.SFObj[sf].Qty;
              }
              else if (reinfType > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfType | this.game.Data.SFTypeObj[type].ReinforcementType2 == reinfType && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                num1 += this.game.Data.SFObj[sf].Qty;
            }
          }
        }
      }
      return num1 > 0 ? (int) Math.Round((double) (100 * num2) / (double) num1) : 100;
    }

    public int GetPercentageOfModelRequiredForAllUnits2(
      int reinfGroup,
      int ppl,
      int maximumInd = 99999,
      int multHQ = 1)
    {
      int num1 = 0;
      int num2 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
        {
          int historical = this.game.Data.UnitObj[unr].Historical;
          int historicalSubPart = this.game.Data.UnitObj[unr].HistoricalSubPart;
          if (historical > -1 & historicalSubPart > -1)
          {
            if (this.game.Data.UnitObj[unr].SOReplacementPercent > 0)
            {
              int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[historical].SubParts[historicalSubPart]);
              if (historical == 466)
                ;
              if (preDef > -1)
              {
                int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                for (int index = 0; index <= sfCount; ++index)
                {
                  int sf = this.game.Data.UnitObj[preDef].SFList[index];
                  int type = this.game.Data.SFObj[sf].Type;
                  if (reinfGroup > -1 & ppl > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfGroup & ppl == this.game.Data.SFObj[sf].People)
                  {
                    if (this.game.Data.SFObj[sf].Qty > maximumInd)
                      num1 += maximumInd;
                    else
                      num1 += this.game.Data.SFObj[sf].Qty;
                    if (this.game.Data.UnitObj[preDef].IsHQ & this.game.Data.SFTypeObj[type].StaffPts > 0)
                    {
                      num1 *= multHQ;
                      int staffPercent = this.game.HandyFunctionsObj.GetStaffPercent(unr);
                      if (staffPercent < 100)
                      {
                        num1 = (int) Math.Round((double) num1 * (100.0 / (double) staffPercent));
                        if (multHQ > 1)
                          num1 = (int) Math.Round((double) num1 * (100.0 / (double) staffPercent));
                      }
                    }
                  }
                }
              }
            }
            int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
            for (int index = 0; index <= sfCount1; ++index)
            {
              int sf = this.game.Data.UnitObj[unr].SFList[index];
              int type = this.game.Data.SFObj[sf].Type;
              if (reinfGroup > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfGroup & ppl == this.game.Data.SFObj[sf].People)
              {
                num2 += this.game.Data.SFObj[sf].Qty;
                if (this.game.Data.UnitObj[unr].IsHQ & this.game.Data.SFTypeObj[type].StaffPts > 0)
                  num2 *= multHQ;
              }
            }
          }
        }
      }
      if (num1 <= 0)
        return 100;
      return num2 == 0 ? 125 + num1 : (int) Math.Round((double) (100 * num1) / (double) num2);
    }

    public int GetPercentageOfModelRequiredForASingleUnit(
      int ForThisHisUnit,
      int aiRoleType,
      int addNeedsForHis,
      int addneedsforHisSubpart,
      int ppl,
      int reinfType)
    {
      int num1 = 0;
      int num2 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical == ForThisHisUnit && this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn)
        {
          int historical = this.game.Data.UnitObj[index1].Historical;
          int historicalSubPart = this.game.Data.UnitObj[index1].HistoricalSubPart;
          if (historical > -1 & historicalSubPart > -1)
          {
            if (this.game.Data.UnitObj[index1].SOReplacementPercent > 0)
            {
              int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[historical].SubParts[historicalSubPart]);
              if (historical == 466)
                ;
              if (preDef > -1)
              {
                int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                for (int index2 = 0; index2 <= sfCount; ++index2)
                {
                  int sf = this.game.Data.UnitObj[preDef].SFList[index2];
                  int type = this.game.Data.SFObj[sf].Type;
                  if (aiRoleType > -1)
                  {
                    if (this.game.Data.SFTypeObj[type].AIRoleScore[aiRoleType] > 0 | aiRoleType == 1 & this.game.Data.SFTypeObj[type].StaffPts > 0 && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                      num1 += this.game.Data.SFObj[sf].Qty;
                  }
                  else if (reinfType > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfType | this.game.Data.SFTypeObj[type].ReinforcementType2 == reinfType && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                    num1 += this.game.Data.SFObj[sf].Qty;
                }
              }
            }
            int sfCount1 = this.game.Data.UnitObj[index1].SFCount;
            for (int index3 = 0; index3 <= sfCount1; ++index3)
            {
              int sf = this.game.Data.UnitObj[index1].SFList[index3];
              int type = this.game.Data.SFObj[sf].Type;
              if (aiRoleType > -1)
              {
                if (this.game.Data.SFTypeObj[type].AIRoleScore[aiRoleType] > 0 | aiRoleType == 1 & this.game.Data.SFTypeObj[type].StaffPts > 0 && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                  num2 += this.game.Data.SFObj[sf].Qty;
              }
              else if (reinfType > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfType | this.game.Data.SFTypeObj[type].ReinforcementType2 == reinfType && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                num2 += this.game.Data.SFObj[sf].Qty;
            }
          }
        }
      }
      if (addNeedsForHis > -1 & addneedsforHisSubpart > -1)
      {
        int index4 = addNeedsForHis;
        int index5 = addneedsforHisSubpart;
        if (index4 > -1 & index5 > -1)
        {
          int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index4].SubParts[index5]);
          if (preDef > -1)
          {
            int sfCount = this.game.Data.UnitObj[preDef].SFCount;
            for (int index6 = 0; index6 <= sfCount; ++index6)
            {
              int sf = this.game.Data.UnitObj[preDef].SFList[index6];
              int type = this.game.Data.SFObj[sf].Type;
              if (aiRoleType > -1)
              {
                if (this.game.Data.SFTypeObj[type].AIRoleScore[aiRoleType] > 0 | aiRoleType == 1 & this.game.Data.SFTypeObj[type].StaffPts > 0 && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                  num1 += this.game.Data.SFObj[sf].Qty;
              }
              else if (reinfType > -1 && this.game.Data.SFTypeObj[type].ReinforcementType == reinfType | this.game.Data.SFTypeObj[type].ReinforcementType2 == reinfType && ppl == -1 | this.game.Data.SFObj[sf].People == ppl)
                num1 += this.game.Data.SFObj[sf].Qty;
            }
          }
        }
      }
      return num1 > 0 ? (int) Math.Round((double) (100 * num2) / (double) num1) : 100;
    }

    public SimpleList CreatableModels()
    {
      SimpleList simpleList = new SimpleList();
      int[] numArray1 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[,] numArray3 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[,] numArray4 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[] numArray5 = new int[this.game.Data.HistoricalUnitCounter + 1];
      bool[] flagArray = new bool[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical > -1 & this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn)
        {
          int[] numArray6 = numArray1;
          int[] numArray7 = numArray6;
          int historical1 = this.game.Data.UnitObj[index1].Historical;
          int index2 = historical1;
          int num1 = numArray6[historical1] + 1;
          numArray7[index2] = num1;
          if (this.game.Data.UnitObj[index1].HistoricalSubPart > -1)
          {
            int[,] numArray8 = numArray3;
            int[,] numArray9 = numArray8;
            int historical2 = this.game.Data.UnitObj[index1].Historical;
            int index3 = historical2;
            int historicalSubPart = this.game.Data.UnitObj[index1].HistoricalSubPart;
            int index4 = historicalSubPart;
            int num2 = numArray8[historical2, historicalSubPart] + 1;
            numArray9[index3, index4] = num2;
          }
        }
      }
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter1; ++index5)
      {
        if (this.game.Data.HistoricalUnitObj[index5].ModelMaster > -1 && numArray1[index5] > 0)
        {
          int[] numArray10 = numArray5;
          int[] numArray11 = numArray10;
          int modelMaster = this.game.Data.HistoricalUnitObj[index5].ModelMaster;
          int index6 = modelMaster;
          int num = numArray10[modelMaster] + 1;
          numArray11[index6] = num;
        }
      }
      int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter2; ++index)
      {
        if (this.game.Data.HistoricalUnitObj[index].Model)
        {
          flagArray[index] = false;
          if (index == 747)
            index = index;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.HistoricalUnitObj[index].PP && !(numArray5[index] >= this.game.Data.HistoricalUnitObj[index].MaxPresent & this.game.Data.HistoricalUnitObj[index].MaxPresent != -1))
            flagArray[index] = true;
        }
      }
      int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
      for (int tid = 0; tid <= historicalUnitCounter3; ++tid)
      {
        int index7 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[tid].SubParts[index7] > -1)
          {
            int[] numArray12 = numArray2;
            int[] numArray13 = numArray12;
            int index8 = tid;
            int index9 = index8;
            int num = numArray12[index8] + 1;
            numArray13[index9] = num;
          }
          int[,] numArray14 = numArray4;
          int[,] numArray15 = numArray14;
          int index10 = tid;
          int index11 = index10;
          int index12 = index7;
          int index13 = index12;
          int num3 = numArray14[index10, index12] + 1;
          numArray15[index11, index13] = num3;
          ++index7;
        }
        while (index7 <= 9);
        if (flagArray[tid])
          simpleList.Add(tid, 0);
      }
      return simpleList;
    }

    public void ExecuteAI()
    {
      this.game.EditObj.TempAIString = "Exec AI";
      this.game.EditObj.TempAIString = "Executing AI Moves";
      this.game.EditObj.AIProgressNow = 0;
      this.game.EditObj.AIProgressMax = 100;
      this.ExecuteUberUnter();
      this.ExecuteStrategicTransfers(true, true);
      this.game.EditObj.AIProgressNow = 10;
      if (this.game.Data.Turn == 6)
      {
        int num = num;
      }
      this.ExecuteFrontlines(this.VAR_DEBUG_ON);
      this.game.EditObj.AIProgressNow = 70;
      this.ExecuteStrategicTransfers(false, false);
      this.game.EditObj.AIProgressNow = 80;
      this.ExecuteChangeHQ(false, false);
      this.game.EditObj.AIProgressNow = 90;
      this.ExecuteOfficerPool(false);
      this.game.EditObj.AIProgressNow = 100;
      if (this.game.Data.Product < 6 && this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 100 && this.SYSTEM_VAR_RUN_NUMBER < 2)
      {
        this.InitAI(false);
        if (this.initExitCode == 1)
        {
          this.game.EditObj.TargetX = -1;
          this.game.EditObj.TargetY = -1;
          this.game.AIRunning = false;
          return;
        }
        this.ExecuteAI();
      }
      this.game.EditObj.TargetX = -1;
      this.game.EditObj.TargetY = -1;
      this.game.EditObj.OrderType = 0;
      if (this.game.Data.Product == 6)
        Thread.Sleep(500);
      this.game.AIRunning = false;
      this.game.EditObj.TempAIString = "Finished AI";
      if (this.game.Data.Product != 6)
        return;
      Thread.Sleep(50);
    }

    public void ExecuteChangeHQ(bool doLog, bool Early)
    {
      this.ExecuteMoveCorps(doLog, Early);
      if (this.VAR_USE_CHANGE_HQ | this.VAR_USE_CHANGE_HQ_IF_NONE)
        this.ExecuteChangeNormalUnitHQ(doLog, Early);
      this.ExecuteMoveArmy(doLog, Early);
      if (this.VAR_USE_CHANGE_HQ | this.VAR_USE_CHANGE_HQ_IF_NONE)
        this.ExecuteChangeCorpsUnitHQ(doLog, Early);
      if (!(this.VAR_USE_CHANGE_HQ | this.VAR_USE_CHANGE_HQ_IF_NONE))
        return;
      this.ExecuteChangeArmyUnitHQ(doLog, Early);
    }

    public void ExecuteMoveArmy(bool doLog, bool Early)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      AIMatrix mask = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      AIMatrix aiMatrix1 = mask.Clone();
      aiMatrix1.RemoveValuesByMask(mask, 1);
      aiMatrix1.ExpandAndAddValueForAnyRegime(40);
      aiMatrix1.SetAllValuesSubtractWith(2);
      int mapWidth1 = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (mask.Value[index1, index2] == 2)
            aiMatrix1.Value[index1, index2] = 1;
        }
      }
      DC2AIClass tai = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai);
      int mapWidth2 = this.map.MapWidth;
      for (int index3 = 0; index3 <= mapWidth2; ++index3)
      {
        int mapHeight = this.map.MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          if (mask.Value[index3, index4] == 1 & (aiMatrix1.Value[index3, index4] == 0 | aiMatrix1.Value[index3, index4] > 5) && this.map.HexObj[index3, index4].VP > 0)
          {
            aiMatrix2.Value[index3, index4] = 20;
            int[,] numArray1 = aiMatrix2.Value;
            int[,] numArray2 = numArray1;
            int index5 = index3;
            int index6 = index5;
            int index7 = index4;
            int index8 = index7;
            int num = numArray1[index5, index7] + this.map.HexObj[index3, index4].VP * 10;
            numArray2[index6, index8] = num;
          }
        }
      }
      this.ClearLog();
      string s = "Execute Move Army HQ" + "\r\n" + "\r\n";
      SimpleList simpleList1 = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
        {
          int historical = this.game.Data.UnitObj[index].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 6 | this.game.Data.Product == 6 & this.game.Data.HistoricalUnitObj[historical].Type >= 6)
            simpleList1.Add(historical, 1);
        }
      }
      if (simpleList1.Counter > -1)
      {
        int counter = simpleList1.Counter;
        for (int index9 = 0; index9 <= counter; ++index9)
        {
          SimpleList simpleList2 = new SimpleList();
          int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(simpleList1.Id[index9]);
          if (unitByHistorical > -1)
          {
            int unr = unitByHistorical;
            int x = this.game.Data.UnitObj[unr].X;
            int y = this.game.Data.UnitObj[unr].Y;
            int lowestAp = this.game.HandyFunctionsObj.GetLowestAp(unr);
            this.game.HandyFunctionsObj.MakeMovePrediction(unr, x, y, 0, ismove: true);
            int mapWidth3 = this.map.MapWidth;
            int index10;
            for (int tdata1 = 0; tdata1 <= mapWidth3; ++tdata1)
            {
              int mapHeight = this.map.MapHeight;
              for (index10 = 0; index10 <= mapHeight; ++index10)
              {
                if (this.game.EditObj.TempValue[0].Value[tdata1, index10] <= lowestAp)
                {
                  int num1 = !(aiMatrix1.Value[tdata1, index10] >= 1 & aiMatrix1.Value[tdata1, index10] <= 15) ? (!(aiMatrix1.Value[tdata1, index10] > 16 & aiMatrix1.Value[tdata1, index10] <= 32) ? 0 : 150 + (aiMatrix1.Value[tdata1, index10] - 24) * 5) : aiMatrix1.Value[tdata1, index10] * 5;
                  int num2 = aiMatrix2.Value[tdata1, index10];
                  int num3 = 0;
                  int num4 = 0;
                  int unitCounter2 = this.game.Data.UnitCounter;
                  for (int index11 = 0; index11 <= unitCounter2; ++index11)
                  {
                    if (this.game.Data.UnitObj[index11].Regime == this.game.Data.Turn & index11 != unr && this.game.Data.UnitObj[index11].IsHQ & this.game.Data.UnitObj[index11].PreDef == -1 & this.game.Data.UnitObj[index11].X > -1)
                    {
                      int historical = this.game.Data.UnitObj[index11].Historical;
                      if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 6)
                      {
                        int num5 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y, 0, x, y, 0);
                        num4 += num5;
                        ++num3;
                      }
                    }
                  }
                  int num6 = (int) Math.Round((double) num4 / (double) num3);
                  int tweight = num1;
                  tweight += num2;
                  tweight += num6;
                  if (!this.game.HandyFunctionsObj.HasHexRoad(x, y, 0) & this.game.Data.Product >= 6)
                  {
                    int num7;
                    tweight = (int) Math.Round((double) num7 / 25.0);
                  }
                  int tid;
                  ++tid;
                  s = s + "\r\n" + this.game.Data.UnitObj[unr].Name + " => " + tdata1.ToString() + "," + index10.ToString() + " = " + num1.ToString() + ", " + num2.ToString() + " = " + tweight.ToString();
                  simpleList2.Add(tid, tweight, tdata1, index10);
                }
              }
            }
            simpleList2.ReverseSort();
            if (simpleList2.Counter > -1)
            {
              int x2 = simpleList2.Data1[0];
              index10 = simpleList2.Data2[0];
              if (!(x == x2 & y == index10))
              {
                s = s + "\r\nMOVE " + this.game.Data.UnitObj[unr].Name + " to " + x2.ToString() + "," + index10.ToString();
                this.game.ProcessingObj.ExecuteMovement(unr, x, y, 0, x2, index10, 0);
              }
              else
                s = s + "\r\n" + this.game.Data.UnitObj[unr].Name + " is fine where it is.";
            }
          }
        }
      }
      this.AddLog(s);
      if (!doLog)
        return;
      if (Early)
        this.WriteLog("change_hq_move_army_early");
      else
        this.WriteLog("change_hq_move_army_late");
    }

    public void ExecuteMoveCorps(bool doLog, bool Early)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      AIMatrix ownerMatrix = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai);
      aiMatrix1.SetAllValuesTo(9999);
      int index1 = 0;
      do
      {
        if (this.VAR_SUPPLY_ACTIVE[this.GetGameDataTurn(), index1])
        {
          int index2 = this.VAR_SUPPLY_X[this.GetGameDataTurn(), index1];
          int index3 = this.VAR_SUPPLY_Y[this.GetGameDataTurn(), index1];
          aiMatrix1.Value[index2, index3] = 0;
        }
        ++index1;
      }
      while (index1 <= 3);
      aiMatrix1.ExpandAsSimplifiedSupplyMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1, (AICoordinateMatrix) null);
      AIMatrix aiMatrix2 = ownerMatrix.Clone();
      aiMatrix2.SetValueXToValueY(0, 2);
      aiMatrix2.RemoveValuesByMask(ownerMatrix, 1);
      aiMatrix2.ExpandAndAddValueForAnyRegime(19);
      aiMatrix2.SetAllValuesSubtractWith(2);
      int mapWidth1 = this.map.MapWidth;
      for (int index4 = 0; index4 <= mapWidth1; ++index4)
      {
        int mapHeight = this.map.MapHeight;
        for (int index5 = 0; index5 <= mapHeight; ++index5)
        {
          if (ownerMatrix.Value[index4, index5] == 2)
            aiMatrix2.Value[index4, index5] = 1;
          if (ownerMatrix.Value[index4, index5] == 0)
            aiMatrix2.Value[index4, index5] = 1;
          if (ownerMatrix.Value[index4, index5] == 1 & aiMatrix2.Value[index4, index5] < 1)
            aiMatrix2.Value[index4, index5] = 20;
        }
      }
      this.ClearLog();
      string s = "Execute Move Corps HQ" + "\r\n" + "\r\n";
      SimpleList simpleList1 = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index6 = 0; index6 <= unitCounter1; ++index6)
      {
        if (this.game.Data.UnitObj[index6].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index6].IsHQ & this.game.Data.UnitObj[index6].PreDef == -1 & this.game.Data.UnitObj[index6].X > -1)
        {
          int historical = this.game.Data.UnitObj[index6].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 5)
            simpleList1.Add(historical, 1);
        }
      }
      if (simpleList1.Counter > -1)
      {
        int counter = simpleList1.Counter;
        for (int index7 = 0; index7 <= counter; ++index7)
        {
          SimpleList simpleList2 = new SimpleList();
          int unr = this.game.HandyFunctionsObj.GetUnitByHistorical(simpleList1.Id[index7]);
          if (unr > -1)
          {
            if (Strings.InStr(this.game.Data.UnitObj[unr].Name, "1st") > 0)
              unr = unr;
            int index8 = unr;
            int x = this.game.Data.UnitObj[index8].X;
            int y = this.game.Data.UnitObj[index8].Y;
            int num1 = this.game.HandyFunctionsObj.GetLowestAp(index8);
            bool flag1 = false;
            bool flag2 = false;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int index9 = 0; index9 <= unitCounter2; ++index9)
            {
              if (this.game.Data.UnitObj[index9].AIGroup > 0 & this.game.Data.UnitObj[index9].HQ == unr)
              {
                ++num6;
                num5 += this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y, 0);
                AIFront front = this.frontList.FindFront(this.game.Data.UnitObj[index9].AIGroup);
                if (!Information.IsNothing((object) front))
                {
                  if (front.Stance == 4 & front.FrontType == 1)
                    ++num2;
                  else if (front.FrontType == 12)
                    ++num4;
                  ++num3;
                }
              }
            }
            if ((double) num2 > (double) num3 / 3.0)
              flag1 = true;
            if ((double) num4 > (double) num3 / 3.0)
              flag2 = true;
            if (Early && num6 > 0 & !flag2 & !flag1)
            {
              num5 = (int) Math.Round((double) num5 / (double) num6);
              if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.UnitObj[unr].moveMode < 1 && num5 >= 11)
                this.game.ProcessingObj.GoToMarchMode(unr);
            }
            if (Early)
              num1 = (int) Math.Round((double) num1 / 2.0);
            this.game.HandyFunctionsObj.MakeMovePrediction(index8, x, y, 0, ismove: true);
            int mapWidth2 = this.map.MapWidth;
            for (int index10 = 0; index10 <= mapWidth2; ++index10)
            {
              int mapHeight = this.map.MapHeight;
              for (int index11 = 0; index11 <= mapHeight; ++index11)
              {
                if (this.game.EditObj.TempValue[0].Value[index10, index11] <= num1)
                {
                  if (index10 == 28 & index11 == 26)
                    index10 = index10;
                  int num7;
                  if (!flag1)
                    num7 = aiMatrix2.Value[index10, index11] != 1 ? (aiMatrix2.Value[index10, index11] != 2 ? (aiMatrix2.Value[index10, index11] != 3 ? (aiMatrix2.Value[index10, index11] != 4 ? (aiMatrix2.Value[index10, index11] != 5 ? 90 : 85) : 70) : 50) : 30) : 15;
                  int num8 = !flag1 ? (!flag2 ? this.GetAverageHQPower(index10, index11, index8, true) * 4 : this.GetAverageHQPower(index10, index11, index8, true) * 2) : this.GetAverageHQPower(index10, index11, index8, true) * 10;
                  if (this.game.Data.Product >= 7)
                  {
                    if ((double) this.GetAverageHQDistance(index10, index11, index8) > (double) this.VAR_HQ_100PERCENT_RANGE + 100.0 / (double) this.VAR_HQ_PERCENTDROP_PERHEX)
                    {
                      if (flag1)
                        num8 -= this.GetAverageHQDistance(index10, index11, index8) * 5;
                      else if (!flag2)
                        num8 -= this.GetAverageHQDistance(index10, index11, index8) * 2;
                    }
                  }
                  else if ((double) this.GetAverageHQDistance(index10, index11, index8) > (double) this.VAR_HQ_100PERCENT_RANGE + 100.0 / (double) this.VAR_HQ_PERCENTDROP_PERHEX)
                  {
                    if (flag1)
                      num8 -= this.GetAverageHQDistance(index10, index11, index8) * 50;
                    else if (!flag2)
                      num8 -= this.GetAverageHQDistance(index10, index11, index8) * 20;
                  }
                  int num9 = 0;
                  if (aiMatrix1.Value[x, y] > this.VAR_SUPPLY_75PERCENT_RANGE && aiMatrix1.Value[index10, index11] > aiMatrix1.Value[x, y])
                  {
                    num9 = (aiMatrix1.Value[x, y] - aiMatrix1.Value[index10, index11]) * 2;
                    if (flag2)
                      num9 *= 4;
                  }
                  if (this.game.HandyFunctionsObj.HasHexRoad(index10, index11, 0))
                    num9 += 15;
                  if (this.game.Data.MapObj[0].HexObj[index10, index11].Location > -1)
                    num9 += 40;
                  if (!flag1 & this.game.Data.Product != 6 && !Information.IsNothing((object) this.probableEnemyPenetration) && this.probableEnemyPenetration.Value[index10, index11] > 0)
                  {
                    if (this.probableEnemyPenetration.Value[index10, index11] == 1)
                      num8 = (int) Math.Round((double) num8 * 0.1);
                    else if (this.probableEnemyPenetration.Value[index10, index11] == 2)
                      num8 = (int) Math.Round((double) num8 * 0.2);
                    else if (this.probableEnemyPenetration.Value[index10, index11] == 3)
                      num8 = (int) Math.Round((double) num8 * 0.5);
                    else if (this.probableEnemyPenetration.Value[index10, index11] == 4)
                      num8 = (int) Math.Round((double) num8 * 0.75);
                  }
                  int num10 = 0;
                  int num11 = 0;
                  int unitCounter3 = this.game.Data.MapObj[0].HexObj[index10, index11].UnitCounter;
                  for (int index12 = 0; index12 <= unitCounter3; ++index12)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[index10, index11].UnitList[index12];
                    if (this.game.Data.UnitObj[unit].IsHQ)
                      ++num11;
                    else
                      num10 += this.game.HandyFunctionsObj.GetUnitStackPts(unit);
                  }
                  if ((double) num10 > (double) this.VAR_HEX_STACK_REGULAR / 2.0)
                    num10 = (int) Math.Round((double) this.VAR_HEX_STACK_REGULAR / 2.0);
                  if (num11 > 1 & !flag1)
                    num10 -= num11 * num11 * 3;
                  int tweight = num7 + num8 + num9 + num10;
                  if (this.game.Data.Product == 7 && tweight < 1)
                    tweight = tweight;
                  if (this.game.Data.Product >= 6)
                  {
                    if (!this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
                      tweight = (int) Math.Round((double) tweight / 7.0);
                    int num12 = this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[x, y] + this.game.Data.MapObj[0].HexObj[x, y].VP;
                    if (num12 > 0)
                    {
                      if (num12 < 2)
                        tweight = (int) Math.Round((double) tweight * 1.25);
                      else if (num12 < 5)
                        tweight = (int) Math.Round((double) tweight * 1.5);
                      else if (num12 < 10)
                        tweight = (int) Math.Round((double) tweight * 1.75);
                      else if (num12 < 25)
                        tweight *= 2;
                      else if (num12 < 50)
                        tweight = (int) Math.Round((double) tweight * 2.5);
                      else if (num12 < 100)
                        tweight *= 3;
                      else
                        tweight *= 4;
                    }
                  }
                  if (!flag1)
                  {
                    if (aiMatrix2.Value[index10, index11] == 1)
                      tweight -= Math.Abs((int) Math.Round((double) tweight * 0.4));
                    else if (aiMatrix2.Value[index10, index11] == 2)
                      tweight -= Math.Abs((int) Math.Round((double) tweight * 0.25));
                    else if (aiMatrix2.Value[index10, index11] == 3)
                      tweight -= Math.Abs((int) Math.Round((double) tweight * 0.1));
                    else if (aiMatrix2.Value[index10, index11] == 4)
                      tweight -= Math.Abs((int) Math.Round((double) tweight * 0.03));
                    else if (aiMatrix2.Value[index10, index11] == 5)
                      tweight -= Math.Abs((int) Math.Round((double) tweight * 0.01));
                  }
                  if (!flag1 && !Information.IsNothing((object) this.probableEnemyPenetration) & this.game.Data.Product != 6)
                  {
                    if (this.ProbablyOutOfSupply.Value[index10, index11] >= 3)
                      tweight = tweight - 200 + (aiMatrix1.Value[x, y] - aiMatrix1.Value[index10, index11]) * 4;
                    else if (this.ProbablyOutOfSupply.Value[index10, index11] >= 2)
                      tweight = tweight - 150 + (aiMatrix1.Value[x, y] - aiMatrix1.Value[index10, index11]) * 2;
                    else if (this.ProbablyOutOfSupply.Value[index10, index11] >= 1)
                      tweight = tweight - 100 + (aiMatrix1.Value[x, y] - aiMatrix1.Value[index10, index11]) * 1;
                  }
                  int tid;
                  ++tid;
                  s = "";
                  simpleList2.Add(tid, tweight, index10, index11);
                }
              }
            }
            simpleList2.ReverseSort();
            if (simpleList2.Counter > -1)
            {
              int x2 = simpleList2.Data1[0];
              int y2 = simpleList2.Data2[0];
              if (x2 == 43 & y2 == 18)
                x2 = x2;
              if (!(x == x2 & y == y2))
              {
                s = s + "\r\nMOVE " + this.game.Data.UnitObj[index8].Name + " to " + x2.ToString() + "," + y2.ToString();
                this.game.ProcessingObj.ExecuteMovement(index8, x, y, 0, x2, y2, 0);
              }
              else
                s = s + "\r\n" + this.game.Data.UnitObj[index8].Name + " is fine where it is.";
            }
            if (!Early && flag1 | flag2)
            {
              int num13 = num6 <= 0 ? -1 : (int) Math.Round((double) num5 / (double) num6);
              if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.UnitObj[unr].moveMode == 1 && num13 < 10)
                this.game.Data.UnitObj[unr].moveMode = 0;
            }
          }
        }
      }
      this.AddLog(s);
      if (!doLog)
        return;
      if (Early)
        this.WriteLog("change_hq_move_corps_early");
      else
        this.WriteLog("change_hq_move_corps_late");
    }

    public int GetAverageHQDistance(int x, int y, int forhq)
    {
      int val2 = 0;
      int num1 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].HQ > -1 & this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].HQ == forhq)
        {
          ++val2;
          int num2 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y, 0, x, y, 0);
          num1 += num2;
        }
      }
      return (int) Math.Round((double) num1 / (double) Math.Max(1, val2));
    }

    public int GetAverageHQPower(int x, int y, int forhq, bool aiTest = false)
    {
      if (x == -1)
      {
        int val2 = 0;
        int num1 = 0;
        int unitCounter = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          if (this.game.Data.UnitObj[index].HQ > -1 & this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1)
          {
            int hq = this.game.Data.UnitObj[index].HQ;
            if (this.game.Data.UnitObj[hq].Historical > -1 & (!this.VAR_USE_STRICT_HQFRONT | hq == forhq | forhq == -1) && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq].Historical].Type == 5)
            {
              ++val2;
              int x1 = this.game.Data.UnitObj[this.game.Data.UnitObj[index].HQ].X;
              int y1 = this.game.Data.UnitObj[this.game.Data.UnitObj[index].HQ].Y;
              int num2 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y, 0, x1, y1, 0);
              int num3;
              if (num2 <= this.VAR_HQ_100PERCENT_RANGE)
              {
                num3 = 100;
              }
              else
              {
                num3 = 100 - this.VAR_HQ_PERCENTDROP_PERHEX * (num2 - this.VAR_HQ_100PERCENT_RANGE);
                if (0 > num3)
                  num3 = 0;
              }
              if (this.game.Data.UnitObj[index].AISubStrictGroup > 1)
                num3 = (int) Math.Round((double) num3 * 0.33) + 66;
              num1 += num3;
            }
          }
        }
        return (int) Math.Round((double) num1 / (double) Math.Max(1, val2));
      }
      int unitCounter1 = this.game.Data.UnitCounter;
      int num4;
      int num5;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].HQ == forhq & this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1)
        {
          ++num4;
          int num6 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y, this.game.Data.UnitObj[index].Map, x, y, 0);
          int num7;
          if (num6 <= this.VAR_HQ_100PERCENT_RANGE)
          {
            num7 = 100;
          }
          else
          {
            num7 = 100 - this.VAR_HQ_PERCENTDROP_PERHEX * (num6 - this.VAR_HQ_100PERCENT_RANGE);
            if (0 > num7)
              num7 = 0;
          }
          if (this.game.Data.UnitObj[index].AISubStrictGroup > 1)
            num7 = (int) Math.Round((double) num7 * 0.33) + 66;
          num5 += num7;
        }
      }
      return (int) Math.Round((double) num5 / (double) num4);
    }

    public int GetAverageSameHQFrontlineUnits(int forunr, int forhq, ref AIMatrix enemyDistance)
    {
      int unitCounter1 = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical == this.game.Data.UnitObj[forunr].Historical)
        {
          int x = this.game.Data.UnitObj[index1].X;
          int y = this.game.Data.UnitObj[index1].Y;
          if (enemyDistance.Value[x, y] == 1)
          {
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int index2 = 0; index2 <= unitCounter2; ++index2)
            {
              if (this.game.Data.UnitObj[index2].X > -1 & this.game.Data.UnitObj[index2].PreDef == -1 && this.game.Data.UnitObj[index2].AIGroup == this.game.Data.UnitObj[forunr].AIGroup & this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn && enemyDistance.Value[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y] == 1 && this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, 0, x, y, 0, 1) <= 1 && this.game.Data.UnitObj[index2].Historical != this.game.Data.UnitObj[forunr].Historical)
              {
                if (this.game.Data.UnitObj[index2].HQ == forhq)
                {
                  ++num1;
                }
                else
                {
                  int num3;
                  ++num3;
                }
                ++num2;
              }
            }
          }
        }
      }
      return num2 == 0 ? 100 : (int) Math.Round((double) num1 / (double) num2 * 100.0);
    }

    public void ExecuteChangeNormalUnitHQ(bool doLog, bool Early)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      AIMatrix mask = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      AIMatrix enemyDistance = mask.Clone();
      enemyDistance.RemoveValuesByMask(mask, 1);
      enemyDistance.ExpandAndAddValueForAnyRegime(19);
      enemyDistance.SetAllValuesSubtractWith(2);
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (mask.Value[index1, index2] == 2)
            enemyDistance.Value[index1, index2] = 1;
        }
      }
      this.ClearLog();
      string str1 = "Execute Change Normal Unit HQ";
      SimpleList simpleList1 = new SimpleList();
      string str2 = str1 + "\r\n" + "\r\n" + "HQs available to normal units:";
      int unitCounter1 = this.game.Data.UnitCounter;
      int tdata2;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index].Regime) == this.GetGameDataTurn() && this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
        {
          int historical = this.game.Data.UnitObj[index].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 5 & (this.game.Data.UnitObj[index].DidMove | this.game.Data.UnitObj[index].DidAttack | this.game.HandyFunctionsObj.GetLowestAp(index) > 0) && !(this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime > -1 & this.game.Data.Turn != this.game.Data.UnitObj[index].Regime))
          {
            int tdata1 = this.game.HandyFunctionsObj.GetStaffPercent(index);
            if (tdata1 > 200)
              tdata1 = 200;
            tdata2 = (int) Math.Round((double) (100 * this.game.Data.HistoricalUnitObj[historical].StaffSize) / (double) Math.Max(1, this.game.HandyFunctionsObj.GetStaffNeeded(index)));
            if (tdata2 > 200)
              tdata2 = 200;
            simpleList1.Add(index, 1, tdata1, tdata2);
            str2 = str2 + "\r\n" + this.game.Data.UnitObj[index].Name + ", staff_troopsRatio%= " + tdata1.ToString() + ", staff_vs_need%=" + tdata2.ToString();
          }
        }
      }
      int num1 = this.game.HandyFunctionsObj.GetSingleCapHQ();
      if (num1 <= -1)
      {
        int num2 = 5;
        tdata2 = -1;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter2; ++index)
        {
          if (this.GetRegime(this.game.Data.UnitObj[index].Regime) == this.GetGameDataTurn() && this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
          {
            int historical = this.game.Data.UnitObj[index].Historical;
            if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type >= num2)
            {
              num2 = this.game.Data.HistoricalUnitObj[historical].Type;
              tdata2 = index;
            }
          }
        }
        if (tdata2 > -1)
          num1 = tdata2;
      }
      string s = str2 + "\r\n" + "\r\n" + "Units:";
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int index3 = 0; index3 <= unitCounter3; ++index3)
      {
        int hq1 = this.game.Data.UnitObj[index3].HQ;
        bool flag = false;
        if (hq1 > -1 && this.game.Data.UnitObj[hq1].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq1].Historical].Type > 5)
          flag = true;
        if (this.VAR_USE_CHANGE_HQ | this.VAR_USE_CHANGE_HQ_IF_NONE & (this.game.Data.UnitObj[index3].HQ == -1 | flag) && this.game.Data.UnitObj[index3].Regime == this.game.Data.Turn & !flagArray[index3] && !this.game.Data.UnitObj[index3].IsHQ & this.game.Data.UnitObj[index3].PreDef == -1 & this.game.Data.UnitObj[index3].X > -1)
        {
          if (this.game.Data.UnitObj[index3].HQ == -1)
            index3 = index3;
          int num3 = 1;
          if (this.game.HandyFunctionsObj.HasUnitAirSF(index3))
            num3 = 0;
          if (this.game.HandyFunctionsObj.HasUnitNavySF(index3))
            num3 = 0;
          if (num3 == 0)
          {
            flagArray[index3] = true;
            this.game.Data.UnitObj[index3].HQ = num1;
          }
          else
          {
            int historical = this.game.Data.UnitObj[index3].Historical;
            if (historical > -1 & (this.game.Data.UnitObj[index3].DidMove | this.game.Data.UnitObj[index3].DidAttack | this.game.HandyFunctionsObj.GetLowestAp(index3) > 0) && this.game.Data.HistoricalUnitObj[historical].Type < 5)
            {
              flagArray[index3] = true;
              string str3 = s + "\r\n" + this.game.Data.UnitObj[index3].Name;
              int hq2 = this.game.Data.UnitObj[index3].HQ;
              int num4;
              int hqFrontlineUnits;
              if (hq2 == -1)
              {
                num4 = 9999;
              }
              else
              {
                int num5 = 0;
                int num6 = 0;
                int unitCounter4 = this.game.Data.UnitCounter;
                for (int index4 = 0; index4 <= unitCounter4; ++index4)
                {
                  if (this.game.Data.UnitObj[index4].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index4].Historical == this.game.Data.UnitObj[index3].Historical & this.game.Data.UnitObj[index4].PreDef == -1 & this.game.Data.UnitObj[index4].X > -1)
                  {
                    ++num5;
                    num6 += this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index4].X, this.game.Data.UnitObj[index4].Y, 0, this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y, 0);
                    flagArray[index4] = true;
                  }
                }
                num4 = (int) Math.Round((double) num6 / (double) num5);
                hqFrontlineUnits = this.GetAverageSameHQFrontlineUnits(index3, hq2, ref enemyDistance);
              }
              s = str3 + "\r\n" + this.game.Data.UnitObj[index3].Name + " ... dist1=" + num4.ToString();
              if (this.game.Data.UnitObj[index3].HQ > -1)
                s = s + ".. currentHQ: " + this.game.Data.UnitObj[this.game.Data.UnitObj[index3].HQ].Name;
              SimpleList simpleList2 = new SimpleList();
              int counter = simpleList1.Counter;
              for (int index5 = 0; index5 <= counter; ++index5)
              {
                int index6 = simpleList1.Id[index5];
                string str4 = s + "\r\n" + "***" + this.game.Data.UnitObj[index6].Name.ToString();
                int num7 = 0;
                int num8 = 0;
                int unitCounter5 = this.game.Data.UnitCounter;
                for (int index7 = 0; index7 <= unitCounter5; ++index7)
                {
                  if (this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index7].Historical == this.game.Data.UnitObj[index3].Historical & this.game.Data.UnitObj[index7].PreDef == -1 & this.game.Data.UnitObj[index7].X > -1)
                  {
                    ++num7;
                    num8 += this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, 0, this.game.Data.UnitObj[index6].X, this.game.Data.UnitObj[index6].Y, 0);
                  }
                }
                int num9 = (int) Math.Round((double) num8 / (double) num7);
                int num10 = (num4 - num9) * 20;
                string str5 = str4 + ", " + num10.ToString();
                int num11 = 0;
                if (simpleList1.Data1[index5] < 110)
                  num11 -= 10;
                if (simpleList1.Data1[index5] < 100)
                  num11 -= (100 - simpleList1.Data1[index5]) * 5;
                if (simpleList1.Data2[index5] < 110)
                  num11 -= 10;
                if (simpleList1.Data2[index5] < 100)
                  num11 -= (100 - simpleList1.Data2[index5]) * 5;
                if (this.game.Data.UnitObj[index3].HQ > -1 & num10 >= -40 && simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ) > -1)
                {
                  if (simpleList1.Data1[index5] - 25 > simpleList1.Data1[simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ)])
                    num11 += 25;
                  if (simpleList1.Data2[index5] - 50 > simpleList1.Data2[simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ)])
                    num11 += 25;
                  if (simpleList1.Data1[index5] - 50 > simpleList1.Data1[simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ)])
                    num11 += 50;
                  if (simpleList1.Data2[index5] - 75 > simpleList1.Data2[simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ)])
                    num11 += 50;
                  if (simpleList1.Data1[index5] - 100 > simpleList1.Data1[simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ)])
                    num11 += 50;
                  if (simpleList1.Data1[index5] - 150 > simpleList1.Data1[simpleList1.FindNr(this.game.Data.UnitObj[index3].HQ)])
                    num11 += 50;
                }
                string str6 = str5 + ", " + num11.ToString();
                int num12 = 0 + Math.Max(-20, (int) Math.Round((double) (this.GetAverageSameHQFrontlineUnits(index3, index6, ref enemyDistance) - hqFrontlineUnits) / 3.0));
                int tweight = num10 + num11 + num12;
                if ((double) this.game.Data.RuleVar[970] > 0.0)
                {
                  if (this.game.Data.UnitObj[index3].HQ == index6)
                    tweight += 200;
                  if (simpleList1.Data1[index5] < 100)
                    tweight -= 25;
                  if (simpleList1.Data1[index5] < 90)
                    tweight -= 35;
                  if (simpleList1.Data1[index5] < 80)
                    tweight -= 55;
                  if (simpleList1.Data1[index5] < 70)
                    tweight -= 75;
                  if (simpleList1.Data1[index5] < 60)
                    tweight -= 95;
                }
                s = str6 + " = " + tweight.ToString();
                simpleList2.Add(index6, tweight);
              }
              simpleList2.ReverseSort();
              if (simpleList2.Counter > -1 && simpleList2.Id[0] != this.game.Data.UnitObj[index3].HQ)
              {
                int hq3 = this.game.Data.UnitObj[index3].HQ;
                int index8 = simpleList2.Id[0];
                s = s + "\r\n" + "**** => " + this.game.Data.UnitObj[index3].Name + " RE-ASSIGNED to: " + this.game.Data.UnitObj[index8].Name;
                this.game.Data.UnitObj[index3].HQ = index8;
                int unitCounter6 = this.game.Data.UnitCounter;
                for (int index9 = 0; index9 <= unitCounter6; ++index9)
                {
                  if (this.game.Data.UnitObj[index9].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index9].Historical == historical & this.game.Data.UnitObj[index9].PreDef == -1 & this.game.Data.UnitObj[index9].X > -1)
                    this.game.Data.UnitObj[index9].HQ = index8;
                }
                int num13 = this.game.HandyFunctionsObj.GetStaffPercent(index8);
                if (num13 > 200)
                  num13 = 200;
                tdata2 = (int) Math.Round((double) (100 * this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index8].Historical].StaffSize) / (double) Math.Max(1, this.game.HandyFunctionsObj.GetStaffNeeded(index8)));
                if (tdata2 > 200)
                  tdata2 = 200;
                int nr1 = simpleList1.FindNr(index8);
                if (nr1 > -1)
                {
                  simpleList1.Data1[nr1] = num13;
                  simpleList1.Data2[nr1] = tdata2;
                }
                if (hq3 > -1)
                {
                  int num14 = this.game.HandyFunctionsObj.GetStaffPercent(hq3);
                  if (num14 > 200)
                    num14 = 200;
                  tdata2 = (int) Math.Round((double) (100 * this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq3].Historical].StaffSize) / (double) Math.Max(1, this.game.HandyFunctionsObj.GetStaffNeeded(hq3)));
                  if (tdata2 > 200)
                    tdata2 = 200;
                  int nr2 = simpleList1.FindNr(hq3);
                  if (nr2 > -1)
                  {
                    simpleList1.Data1[nr2] = num14;
                    simpleList1.Data2[nr2] = tdata2;
                  }
                }
              }
            }
          }
        }
      }
      int unitCounter7 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter7; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & !flagArray[index] && !this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1 && this.game.Data.UnitObj[index].HQ == -1)
        {
          this.game.Data.UnitObj[index].HQ = num1;
          s = s + "\r\n" + this.game.Data.UnitObj[index].Name + " emergency assign to highhq.";
        }
      }
      this.AddLog(s);
      if (!this.VAR_DEBUG_ON)
        return;
      if (Early)
        this.WriteLog("change_hq_of_normal_units_early");
      else
        this.WriteLog("change_hq_of_normal_units_late");
    }

    public void ExecuteChangeCorpsUnitHQ(bool doLog, bool Early)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      this.ClearLog();
      string str1 = "Execute Change Corps Unit HQ";
      SimpleList simpleList1 = new SimpleList();
      string str2 = str1 + "\r\n" + "\r\n" + "HQs available to corps units:";
      int unitCounter1 = this.game.Data.UnitCounter;
      int num1;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index].Regime) == this.GetGameDataTurn() && this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
        {
          int historical = this.game.Data.UnitObj[index].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 6 & (this.game.Data.UnitObj[index].DidMove | this.game.Data.UnitObj[index].DidAttack | this.game.HandyFunctionsObj.GetLowestAp(index) > 0) && !(this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime > -1 & this.game.Data.Turn != this.game.Data.UnitObj[index].Regime))
          {
            simpleList1.Add(index, 1);
            int num2;
            str2 = str2 + "\r\n" + this.game.Data.UnitObj[index].Name + ", staff%= " + num2.ToString() + ", comm%=" + num1.ToString();
          }
        }
      }
      int tid = this.game.HandyFunctionsObj.GetSingleCapHQ();
      if (tid <= -1)
      {
        int num3 = 5;
        num1 = -1;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter2; ++index)
        {
          if (this.GetRegime(this.game.Data.UnitObj[index].Regime) == this.GetGameDataTurn() && this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
          {
            int historical = this.game.Data.UnitObj[index].Historical;
            if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type >= num3)
            {
              num3 = this.game.Data.HistoricalUnitObj[historical].Type;
              num1 = index;
            }
          }
        }
        tid = num1;
      }
      if (simpleList1.Counter == -1 & tid > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tid].Historical].Type > 5)
        simpleList1.Add(tid, 1);
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai);
      tai = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai);
      AIMatrix ownerMatrix = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      string s = str2 + "\r\n" + "\r\n" + "Units:";
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int unr1 = 0; unr1 <= unitCounter3; ++unr1)
      {
        if (this.VAR_USE_CHANGE_HQ | this.VAR_USE_CHANGE_HQ_IF_NONE & (this.game.Data.UnitObj[unr1].HQ == -1 | (int) Math.Round((double) this.game.Data.UnitObj[unr1].SupplyInReq / 4.0) > this.game.Data.UnitObj[unr1].SupplyIn) && this.game.Data.UnitObj[unr1].Regime == this.game.Data.Turn & !flagArray[unr1] && this.game.Data.UnitObj[unr1].IsHQ & this.game.Data.UnitObj[unr1].PreDef == -1 & this.game.Data.UnitObj[unr1].X > -1 & this.game.Data.UnitObj[unr1].Historical > -1)
        {
          int historical = this.game.Data.UnitObj[unr1].Historical;
          if (historical > -1 & (this.game.Data.UnitObj[unr1].DidMove | this.game.Data.UnitObj[unr1].DidAttack | this.game.HandyFunctionsObj.GetLowestAp(unr1) > 0) && this.game.Data.HistoricalUnitObj[historical].Type == 5)
          {
            aiMatrix2.SetAllValuesTo(9999);
            aiMatrix2.Value[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y] = 0;
            aiMatrix2.ExpandAsSimplifiedSupplyRouteMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1);
            flagArray[unr1] = true;
            string str3 = s + "\r\n" + this.game.Data.UnitObj[unr1].Name;
            int unr2 = this.game.Data.UnitObj[unr1].HQ;
            if (unr2 > -1 && this.game.Data.UnitObj[unr2].X == -1)
              unr2 = -1;
            int index1 = this.game.HandyFunctionsObj.GetTopHQ(unr2);
            if (index1 > -1 && this.game.Data.UnitObj[index1].X == -1)
              index1 = -1;
            int num4;
            if (unr2 == -1)
            {
              num4 = 9999;
            }
            else
            {
              int num5 = 0;
              num4 = 0;
              int unitCounter4 = this.game.Data.UnitCounter;
              for (int index2 = 0; index2 <= unitCounter4; ++index2)
              {
                if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index2].Historical == this.game.Data.UnitObj[unr1].Historical & this.game.Data.UnitObj[index2].PreDef == -1 & this.game.Data.UnitObj[index2].X > -1)
                {
                  ++num5;
                  num4 += aiMatrix2.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y];
                  if (index1 > -1)
                    num4 += aiMatrix2.Value[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y] * 2;
                  flagArray[index2] = true;
                }
              }
              num4 = (int) Math.Round((double) num4 / (double) num5);
            }
            s = str3 + "\r\n" + this.game.Data.UnitObj[unr1].Name + " ... dist1=" + num4.ToString();
            SimpleList simpleList2 = new SimpleList();
            int counter = simpleList1.Counter;
            for (int index3 = 0; index3 <= counter; ++index3)
            {
              int index4 = simpleList1.Id[index3];
              int topHq = this.game.HandyFunctionsObj.GetTopHQ(index4);
              string str4 = s + "\r\n" + "***" + this.game.Data.UnitObj[index4].Name.ToString();
              int num6 = 0;
              int num7 = 0;
              int unitCounter5 = this.game.Data.UnitCounter;
              for (int index5 = 0; index5 <= unitCounter5; ++index5)
              {
                if (this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index5].Historical == this.game.Data.UnitObj[unr1].Historical & this.game.Data.UnitObj[index5].PreDef == -1 & this.game.Data.UnitObj[index5].X > -1)
                {
                  ++num6;
                  num7 += aiMatrix2.Value[this.game.Data.UnitObj[index4].X, this.game.Data.UnitObj[index4].Y];
                  if (topHq > -1)
                    num7 += aiMatrix2.Value[this.game.Data.UnitObj[topHq].X, this.game.Data.UnitObj[topHq].Y] * 2;
                }
              }
              int num8 = (int) Math.Round((double) num7 / (double) num6);
              int num9 = (num4 - num8) * 20;
              string str5 = str4 + ", " + num9.ToString();
              int tweight = num9;
              if (this.game.Data.UnitObj[unr1].HQ == index4)
                tweight += 250;
              s = str5 + " = " + tweight.ToString();
              simpleList2.Add(index4, tweight);
            }
            simpleList2.ReverseSort();
            if (simpleList2.Counter > -1 && simpleList2.Id[0] != this.game.Data.UnitObj[unr1].HQ)
            {
              int index6 = simpleList2.Id[0];
              s = s + "\r\n" + this.game.Data.UnitObj[unr1].Name + "re-assigned to " + this.game.Data.UnitObj[index6].Name;
              this.game.Data.UnitObj[unr1].HQ = index6;
              int unitCounter6 = this.game.Data.UnitCounter;
              for (int index7 = 0; index7 <= unitCounter6; ++index7)
              {
                if (this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index7].Historical == historical & this.game.Data.UnitObj[index7].PreDef == -1 & this.game.Data.UnitObj[index7].X > -1)
                  this.game.Data.UnitObj[index7].HQ = index6;
              }
            }
          }
        }
      }
      this.AddLog(s);
      if (!doLog)
        return;
      if (Early)
        this.WriteLog("change_hq_of_corps_HQ_early");
      else
        this.WriteLog("change_hq_of_corps_HQ_late");
    }

    public void ExecuteChangeArmyUnitHQ(bool doLog, bool Early)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      this.ClearLog();
      string str1 = "Execute Change Army Unit HQ";
      SimpleList simpleList1 = new SimpleList();
      string str2 = str1 + "\r\n" + "\r\n" + "HQs available to corps units:";
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
        {
          int historical = this.game.Data.UnitObj[index].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type >= 7 & (this.game.Data.UnitObj[index].DidMove | this.game.Data.UnitObj[index].DidAttack | this.game.HandyFunctionsObj.GetLowestAp(index) > 0) && !(this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime > -1 & this.game.Data.Turn != this.game.Data.UnitObj[index].Regime))
          {
            simpleList1.Add(index, 1);
            str2 = str2 + "\r\n" + this.game.Data.UnitObj[index].Name;
          }
        }
      }
      int singleCapHq = this.game.HandyFunctionsObj.GetSingleCapHQ();
      if (singleCapHq <= -1)
      {
        int num1 = 5;
        int num2 = -1;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int tid = 0; tid <= unitCounter2; ++tid)
        {
          if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].IsHQ & this.game.Data.UnitObj[tid].PreDef == -1 & this.game.Data.UnitObj[tid].X > -1)
          {
            int historical = this.game.Data.UnitObj[tid].Historical;
            if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type >= 7)
            {
              num1 = this.game.Data.HistoricalUnitObj[historical].Type;
              num2 = tid;
              simpleList1.Add(tid, 0, this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y);
            }
          }
        }
      }
      else
        simpleList1.Add(singleCapHq, 0, this.game.Data.UnitObj[singleCapHq].X, this.game.Data.UnitObj[singleCapHq].Y);
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      AIMatrix ownerMatrix = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      string str3 = str2 + "\r\n" + "\r\n" + "Units:";
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter3; ++unr)
      {
        if (this.VAR_USE_CHANGE_HQ | this.VAR_USE_CHANGE_HQ_IF_NONE & this.game.Data.UnitObj[unr].HQ == -1 && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & !flagArray[unr] && this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].Historical > -1)
        {
          int historical = this.game.Data.UnitObj[unr].Historical;
          if (historical > -1 & (this.game.Data.UnitObj[unr].DidMove | this.game.Data.UnitObj[unr].DidAttack | this.game.HandyFunctionsObj.GetLowestAp(unr) > 0) && this.game.Data.HistoricalUnitObj[historical].Type == 6 | this.game.Data.HistoricalUnitObj[historical].Type == 7)
          {
            aiMatrix1.SetAllValuesTo(9999);
            aiMatrix1.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] = 0;
            aiMatrix1.ExpandAsSimplifiedSupplyRouteMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1);
            flagArray[unr] = true;
            string str4 = str3 + "\r\n" + this.game.Data.UnitObj[unr].Name;
            int hq = this.game.Data.UnitObj[unr].HQ;
            int num3;
            if (hq == -1)
            {
              num3 = 9999;
            }
            else
            {
              int num4 = 0;
              num3 = 0;
              int unitCounter4 = this.game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter4; ++index)
              {
                if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].Historical == this.game.Data.UnitObj[unr].Historical & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
                {
                  ++num4;
                  num3 += aiMatrix1.Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y];
                  flagArray[index] = true;
                }
              }
              num3 = (int) Math.Round((double) num3 / (double) num4);
            }
            str3 = str4 + "\r\n" + this.game.Data.UnitObj[unr].Name + " ... dist1=" + num3.ToString();
            SimpleList simpleList2 = new SimpleList();
            int counter = simpleList1.Counter;
            for (int index1 = 0; index1 <= counter; ++index1)
            {
              int tid = simpleList1.Id[index1];
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tid].Historical].Type > this.game.Data.HistoricalUnitObj[historical].Type)
              {
                string str5 = str3 + "\r\n" + "***" + this.game.Data.UnitObj[tid].Name.ToString();
                int num5 = 0;
                int num6 = 0;
                int unitCounter5 = this.game.Data.UnitCounter;
                for (int index2 = 0; index2 <= unitCounter5; ++index2)
                {
                  if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index2].Historical == this.game.Data.UnitObj[unr].Historical & this.game.Data.UnitObj[index2].PreDef == -1 & this.game.Data.UnitObj[index2].X > -1)
                  {
                    ++num5;
                    num6 += aiMatrix1.Value[this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y];
                  }
                }
                int num7 = (int) Math.Round((double) num6 / (double) num5);
                int num8 = (num3 - num7) * 20;
                string str6 = str5 + ", " + num8.ToString();
                int tweight = num8;
                if (this.game.Data.UnitObj[unr].HQ == tid)
                  tweight += 800;
                if (this.game.Data.UnitObj[unr].SupplyIn < (int) Math.Round((double) this.game.Data.UnitObj[unr].SupplyInReq * 0.25))
                  tweight -= 2000;
                str3 = str6 + " = " + tweight.ToString();
                simpleList2.Add(tid, tweight);
              }
            }
            simpleList2.ReverseSort();
            if (simpleList2.Counter > -1 && simpleList2.Id[0] != this.game.Data.UnitObj[unr].HQ)
            {
              int index3 = simpleList2.Id[0];
              str3 = str3 + "\r\n" + this.game.Data.UnitObj[unr].Name + "re-assigned to " + this.game.Data.UnitObj[index3].Name;
              this.game.Data.UnitObj[unr].HQ = index3;
              int unitCounter6 = this.game.Data.UnitCounter;
              for (int index4 = 0; index4 <= unitCounter6; ++index4)
              {
                if (this.game.Data.UnitObj[index4].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index4].Historical == historical & this.game.Data.UnitObj[index4].PreDef == -1 & this.game.Data.UnitObj[index4].X > -1)
                  this.game.Data.UnitObj[index4].HQ = index3;
              }
            }
          }
        }
      }
      string s = str3 + "\r\n" + "\r\n" + "High Command nesting:";
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
      int index5 = 0;
      do
      {
        if (this.VAR_SUPPLY_ACTIVE[this.GetGameDataTurn(), index5])
        {
          int index6 = this.VAR_SUPPLY_X[this.GetGameDataTurn(), index5];
          int index7 = this.VAR_SUPPLY_Y[this.GetGameDataTurn(), index5];
          if (this.GetRegime(this.game.Data.MapObj[0].HexObj[index6, index7].Regime) == this.GetGameDataTurn())
            aiMatrix2.Value[index6, index7] = 9999;
        }
        ++index5;
      }
      while (index5 <= 3);
      int unitCounter7 = this.game.Data.UnitCounter;
      for (int index8 = 0; index8 <= unitCounter7; ++index8)
      {
        if (this.game.Data.UnitObj[index8].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index8].IsHQ & this.game.Data.UnitObj[index8].PreDef == -1 & this.game.Data.UnitObj[index8].X > -1)
        {
          int historical1 = this.game.Data.UnitObj[index8].Historical;
          if (historical1 > -1 && this.game.Data.HistoricalUnitObj[historical1].Type >= 8 && !(this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index8].Regime].UberRegime > -1 & this.game.Data.Turn != this.game.Data.UnitObj[index8].Regime))
          {
            aiMatrix1.SetAllValuesTo(9999);
            aiMatrix1.Value[this.game.Data.UnitObj[index8].X, this.game.Data.UnitObj[index8].Y] = 0;
            aiMatrix1.ExpandAsSimplifiedSupplyMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1, (AICoordinateMatrix) null);
            int unitCounter8 = this.game.Data.UnitCounter;
            for (int index9 = 0; index9 <= unitCounter8; ++index9)
            {
              if (this.game.Data.UnitObj[index9].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index9].IsHQ & this.game.Data.UnitObj[index9].PreDef == -1 & this.game.Data.UnitObj[index9].X > -1)
              {
                int historical2 = this.game.Data.UnitObj[index9].Historical;
                if (historical2 > -1 & index8 != index9 && this.game.Data.HistoricalUnitObj[historical2].Type == this.game.Data.HistoricalUnitObj[historical1].Type && aiMatrix1.Value[this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y] <= (int) Math.Round((double) (this.VAR_SUPPLY_75PERCENT_RANGE + this.VAR_SUPPLY_50PERCENT_RANGE) / 2.0) && aiMatrix2.Value[this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y] > aiMatrix2.Value[this.game.Data.UnitObj[index8].X, this.game.Data.UnitObj[index8].Y])
                {
                  s = s + "\r\n" + this.game.Data.UnitObj[index8].Name + "re-assigned to " + this.game.Data.UnitObj[index9].Name;
                  this.game.Data.UnitObj[index8].HQ = index9;
                  if (this.game.Data.UnitObj[index9].HQ == index8)
                    this.game.Data.UnitObj[index9].HQ = -1;
                }
              }
            }
            if (this.game.Data.UnitObj[index8].HQ > -1)
            {
              int hq = this.game.Data.UnitObj[index8].HQ;
              if (aiMatrix1.Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] > (int) Math.Round((double) (this.VAR_SUPPLY_75PERCENT_RANGE + this.VAR_SUPPLY_50PERCENT_RANGE) / 2.0))
              {
                s = s + "\r\n" + this.game.Data.UnitObj[index8].Name + " due to supply problems taken out of chain of " + this.game.Data.UnitObj[hq].Name;
                this.game.Data.UnitObj[index8].HQ = -1;
              }
              else if (aiMatrix2.Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] < aiMatrix2.Value[this.game.Data.UnitObj[index8].X, this.game.Data.UnitObj[index8].Y])
              {
                s = s + "\r\n" + this.game.Data.UnitObj[index8].Name + " due to having better supply source taken out of chain of " + this.game.Data.UnitObj[hq].Name;
                this.game.Data.UnitObj[index8].HQ = -1;
              }
            }
          }
        }
      }
      this.AddLog(s);
      if (!doLog)
        return;
      if (Early)
        this.WriteLog("change_hq_of_army_HQ_early");
      else
        this.WriteLog("change_hq_of_army_HQ_late");
    }

    public void ExecuteOfficerPool(bool doLog)
    {
      if (!this.VAR_USE_OFFICERPOOL)
        return;
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime > -1)
        return;
      this.ClearLog();
      this.AddLog("Officer Pool");
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].IsHQ & this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == this.GetGameDataTurn())
        {
          int historical = this.game.Data.UnitObj[unr].Historical;
          int num1 = 0;
          if (this.game.Data.HistoricalUnitObj[historical].Type == 5)
          {
            if (this.VAR_BEST_HISVARTYPE_ANYLEVELHQ > 0)
              num1 += this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.VAR_BEST_HISVARTYPE_ANYLEVELHQ) * 10;
          }
          else
          {
            if (this.VAR_BEST_HISVARTYPE_ANYLEVELHQ > 0)
              num1 += this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.VAR_BEST_HISVARTYPE_ANYLEVELHQ) * 10;
            if (this.VAR_BEST_HISVARTYPE_HIGHERLEVELHQ > 0)
              num1 += this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.VAR_BEST_HISVARTYPE_HIGHERLEVELHQ);
          }
          int num2 = num1;
          int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
          int num3;
          for (int his = 0; his <= historicalUnitCounter; ++his)
          {
            if (this.game.Data.HistoricalUnitObj[his].Pool & this.game.Data.HistoricalUnitObj[his].TempRegime == this.game.Data.Turn && this.game.HandyFunctionsObj.GetUnitByHistorical(his) == -1)
            {
              int num4 = 0;
              if (this.game.Data.HistoricalUnitObj[historical].Type == 5)
              {
                if (this.VAR_BEST_HISVARTYPE_ANYLEVELHQ > 0)
                  num4 += this.game.Data.HistoricalUnitObj[his].GiveHisVarValue(this.VAR_BEST_HISVARTYPE_ANYLEVELHQ) * 10;
              }
              else
              {
                if (this.VAR_BEST_HISVARTYPE_ANYLEVELHQ > 0)
                  num4 += this.game.Data.HistoricalUnitObj[his].GiveHisVarValue(this.VAR_BEST_HISVARTYPE_ANYLEVELHQ) * 10;
                if (this.VAR_BEST_HISVARTYPE_HIGHERLEVELHQ > 0)
                  num4 += this.game.Data.HistoricalUnitObj[his].GiveHisVarValue(this.VAR_BEST_HISVARTYPE_HIGHERLEVELHQ);
              }
              if (num4 > num1 && num4 > num2)
              {
                num2 = num4;
                num3 = his;
              }
            }
          }
          if (num2 > num1)
          {
            int his2 = num3;
            if (historical > -1 & his2 > -1 && this.game.Data.HistoricalUnitObj[his2].People == this.game.Data.HistoricalUnitObj[historical].People | this.game.Data.HistoricalUnitObj[his2].People == -1 | this.game.Data.HistoricalUnitObj[historical].People == -1)
            {
              if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[historical].CommanderName))
                this.game.Data.HistoricalUnitObj[historical].CommanderName = "";
              this.AddLog("Changing " + this.game.Data.HistoricalUnitObj[historical].CommanderName + " to " + this.game.Data.HistoricalUnitObj[his2].CommanderName + " to command: " + this.game.Data.HistoricalUnitObj[historical].Name);
              this.game.ProcessingObj.SwapOfficer(this.game.Data.Turn, historical, his2, unr);
            }
          }
        }
      }
      if (!doLog)
        return;
      this.WriteLog("officer_pool");
    }

    public int GetAIRolePercent(int unr, int rolenr)
    {
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      int num1;
      int num2;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        num1 += this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].PowerPts;
        if (this.game.Data.SFTypeObj[type].AIRoleScore[rolenr] > 0)
          num2 += (int) Math.Round((double) (this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].PowerPts) * ((double) this.game.Data.SFTypeObj[type].AIRoleScore[rolenr] / 100.0));
      }
      return num1 == 0 ? 0 : (int) Math.Round(Conversion.Int((double) (100 * num2) / (double) num1));
    }

    public int GetGameDataTurn() => this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime > -1 ? this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime : this.game.Data.Turn;

    public int GetRegime(int nr)
    {
      if (nr == -1 || nr > this.game.Data.RegimeCounter)
        return -1;
      return this.game.Data.RegimeObj[nr].UberRegime > -1 ? this.game.Data.RegimeObj[nr].UberRegime : nr;
    }

    public float GetCombatMatrixModifierVersusHex(int unr, int x, int y)
    {
      int num1 = this.game.HandyFunctionsObj.HexFacing(x, y, 0, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0);
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      float num2;
      int num3;
      for (int index1 = 0; index1 <= sfCount1; ++index1)
      {
        int sf1 = this.game.Data.UnitObj[unr].SFList[index1];
        int num4 = this.game.Data.SFObj[sf1].Qty * 100;
        int type1 = this.game.Data.SFObj[sf1].Type;
        int unitGroup = this.game.Data.SFTypeObj[type1].UnitGroup;
        float num5 = 1f * this.game.Data.SFTypeObj[type1].CombatModAtt[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType];
        if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].PictureLT > -1)
        {
          int pictureLt = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].PictureLT;
          num5 *= this.game.Data.SFTypeObj[type1].CombatModAtt[pictureLt];
        }
        if (num1 > 0 && this.game.Data.MapObj[0].HexObj[x, y].RiverType[num1 - 1] > -1)
          num5 *= this.game.Data.RiverTypeObj[this.game.Data.MapObj[0].HexObj[x, y].RiverType[num1 - 1]].AttackPenalty[unitGroup];
        if (this.game.AllowHeightMap)
        {
          int num6 = this.game.Data.MapObj[0].HexObj[x, y].HeightLevel - this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].HeightLevel;
          float num7 = 1f;
          if (num6 > 0)
            num7 = (float) ((double) num6 * (double) this.game.Data.RuleVar[425] / 100.0);
          else if (num6 < 0)
            num7 = (float) (1.0 + (double) Math.Abs(num6) * (double) this.game.Data.RuleVar[424] / 100.0);
          num5 *= num7;
        }
        int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
        for (int index2 = 0; index2 <= unitCounter; ++index2)
        {
          int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index2];
          int sfCount2 = this.game.Data.UnitObj[unit].SFCount;
          for (int index3 = 0; index3 <= sfCount2; ++index3)
          {
            int sf2 = this.game.Data.UnitObj[unit].SFList[index3];
            int num8 = this.game.Data.SFObj[sf2].Qty * 100;
            int type2;
            float num9 = 1f * this.game.Data.SFTypeObj[type2].CombatModDef[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType];
            if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].PictureLT > -1)
            {
              int pictureLt = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].PictureLT;
              num9 *= this.game.Data.SFTypeObj[type2].CombatModAtt[pictureLt];
            }
            type2 = this.game.Data.SFObj[sf2].Type;
            float num10 = this.combatMatrix[type1, type2] / ((float) (this.game.Data.SFObj[sf2].CurrentEntrench + 100) / 100f);
            if (this.game.Data.SFTypeObj[type2].BackBench)
            {
              if ((double) num10 > 1.5)
                num10 = 0.5f + (float) Math.Sqrt((double) num10 - 0.5);
              if ((double) num10 > 2.5)
                num10 = 1.5f + (float) Math.Sqrt((double) num10 - 1.5);
            }
            float num11 = (double) num5 <= 0.0 ? 0.1f : num10 * (num5 / num9);
            num2 += num11 * (float) (num4 * num8);
            num3 += num4 * num8;
          }
        }
      }
      if ((double) num2 == 0.0)
        num2 = 1f;
      if (num3 == 0)
        num3 = 1;
      return num2 / (float) num3;
    }

    public void InitAI(bool initialCall)
    {
      this.initExitCode = 0;
      DC2AIClass tai1 = this;
      this.CustomCalls = new CustomDC2AICalls(ref tai1);
      if (initialCall)
      {
        DC2AIClass tai2 = this;
        if (new Shadow_Strategic_AI(ref tai2).Run() == 1)
        {
          this.initExitCode = 1;
          this.game.AIRunning = false;
          return;
        }
      }
      if (initialCall)
      {
        this.SYSTEM_VAR_RUN_NUMBER = 1;
        this.SetVars();
      }
      else
        ++this.SYSTEM_VAR_RUN_NUMBER;
      this.game.EditObj.TempAIString = "Initializing DC2 AI";
      this.game.EditObj.TempAIString = "Preparing AI Initialization";
      this.game.EditObj.AIProgressNow = 0;
      this.game.EditObj.AIProgressMax = 100;
      this.map = this.game.Data.MapObj[0];
      this.SetTemp();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].PreDef > 0)
        {
          this.game.Data.UnitObj[index].X = -1;
          this.game.Data.UnitObj[index].Y = -1;
        }
      }
      if (!this.VAR_USE_STRICT_HQFRONT)
        this.ExecuteChangeHQ(false, true);
      this.game.EditObj.AIProgressNow = 25;
      this.InitFrontlines(true);
      this.game.EditObj.AIProgressNow = 70;
      this.InitStrategicPlan(true);
      if (this.VAR_USE_STRICT_HQFRONT)
        this.ExecuteChangeHQ(false, true);
      this.game.EditObj.AIProgressNow = 90;
      this.InitRegimeCards(false);
      this.SetSomeAIUnitVars();
      this.CustomCalls.CustomAfterInitialization();
      if (this.game.Data.Product == 6)
        Thread.Sleep(1);
      this.game.AIRunning = false;
      this.initExitCode = 0;
      if (this.game.Data.Product != 6)
        return;
      Thread.Sleep(1);
    }

    public void SetSomeAIUnitVars()
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          this.game.Data.UnitObj[index].AIDefend = -1;
          this.game.Data.UnitObj[index].AIAttack = -1;
          this.game.Data.UnitObj[index].AILeftFlank = -1;
          this.game.Data.UnitObj[index].AIRightFlank = -1;
        }
      }
      int counter1 = this.frontList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        if (this.frontList.Front[index1].FrontType == 10)
        {
          int counter2 = this.frontList.Front[index1].units.counter;
          for (int index2 = 0; index2 <= counter2; ++index2)
          {
            int index3 = this.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index1].units.AIid[index2]);
            if (Operators.CompareString(this.game.Data.UnitObj[index3].Name.ToLower(), "2nd light infantry battalion", false) == 0)
              index3 = index3;
            if (index3 > -1)
            {
              this.game.Data.UnitObj[index3].AIAttack = 1;
              this.game.Data.UnitObj[index3].AILeftFlank = this.frontList.Front[index1].targetX;
              this.game.Data.UnitObj[index3].AIRightFlank = this.frontList.Front[index1].targetY;
            }
          }
        }
      }
    }

    public void SetVars()
    {
      this.ClearLog();
      this.AddLog("SETUP AND CONFIG AI CLASSES FOR " + this.game.Data.RegimeObj[this.game.Data.Turn].Name + "\r\n--------------------------------------\r\n");
      this.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE = false;
      this.VAR_DC4_ATTACKUNIT_IS_IMPORTANT = false;
      this.VAR_DC4_MINIMIZE_ORG_UNITS = false;
      if (this.game.Data.Product == 6)
      {
        this.VAR_DC4_MINIMIZE_ORG_UNITS = true;
        this.VAR_DC4_ATTACKUNIT_IS_IMPORTANT = true;
        this.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE = true;
      }
      this.VAR_DEBUG_ON = false;
      if ((double) this.game.Data.RuleVar[941] > 0.0)
        this.VAR_DEBUG_ON = true;
      this.AddLog("VAR_DEBUG_ON = " + this.VAR_DEBUG_ON.ToString() + " (rulevar 941)");
      this.VAR_FRONTLINE_DEPTH = 3;
      if ((double) this.game.Data.RuleVar[932] > 0.0)
        this.VAR_FRONTLINE_DEPTH = (int) Math.Round((double) this.game.Data.RuleVar[932]);
      this.AddLog("VAR_FRONTLINE_DEPTH = " + this.VAR_FRONTLINE_DEPTH.ToString() + " (rulevar 932)");
      this.VAR_FRONTLINE_MAX_LENGTH = 12;
      if ((double) this.game.Data.RuleVar[933] > 0.0)
        this.VAR_FRONTLINE_MAX_LENGTH = (int) Math.Round((double) this.game.Data.RuleVar[933]);
      this.AddLog("VAR_FRONTLINE_MAX_LENGTH = " + this.VAR_FRONTLINE_MAX_LENGTH.ToString() + " (rulevar 933)");
      if (this.game.Data.Product != 6)
        ;
      this.VAR_REINFORCEMENTS_FRIENDLY = 0;
      if ((double) this.game.Data.RuleVar[929] > 0.0)
        this.VAR_REINFORCEMENTS_FRIENDLY = (int) Math.Round((double) this.game.Data.RuleVar[929]) * 10;
      this.AddLog("VAR_REINFORCEMENTS_FRIENDLY = " + this.VAR_REINFORCEMENTS_FRIENDLY.ToString() + " (rulevar 929)");
      this.VAR_REINFORCEMENTS_ENEMY = 0;
      if ((double) this.game.Data.RuleVar[930] > 0.0)
        this.VAR_REINFORCEMENTS_ENEMY = (int) Math.Round((double) this.game.Data.RuleVar[930]) * 10;
      this.AddLog("VAR_REINFORCEMENTS_ENEMY = " + this.VAR_REINFORCEMENTS_ENEMY.ToString() + " (rulevar 930)");
      int num = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && !this.game.HandyFunctionsObj.HasUnitAirSF(unr))
        {
          int lowestAp = this.game.HandyFunctionsObj.GetLowestAp(unr, true);
          if (lowestAp > num & lowestAp < 9999)
            num = lowestAp;
        }
      }
      this.VAR_MOVE_MAXIMUM_RANGE = 10;
      if (num > 100)
        this.VAR_MOVE_MAXIMUM_RANGE = (int) Math.Round((double) (this.VAR_MOVE_MAXIMUM_RANGE * num) / 100.0) + 1;
      if (this.game.Data.Product == 7)
        this.VAR_MOVE_MAXIMUM_RANGE -= 2;
      if (this.game.Data.RegimeObj[this.game.Data.Turn].AIHelpMove > 0)
        this.VAR_MOVE_MAXIMUM_RANGE = (int) Math.Round((double) (this.VAR_MOVE_MAXIMUM_RANGE * (100 + this.game.Data.RegimeObj[this.game.Data.Turn].AIHelpMove)) / 100.0);
      this.AddLog("VAR_MOVE_MAXIMUM_RANGE = " + this.VAR_MOVE_MAXIMUM_RANGE.ToString());
      this.VAR_SUPPLY_FRIENDLY_MOVETYPE = (int) Math.Round((double) this.game.Data.RuleVar[99]);
      this.AddLog("VAR_SUPPLY_FRIENDLY_MOVETYPE = " + this.VAR_SUPPLY_FRIENDLY_MOVETYPE.ToString() + " (rulevar 99)");
      this.VAR_SUPPLY_ENEMY_MOVETYPE = (double) this.game.Data.RuleVar[890] <= 0.0 ? (int) Math.Round((double) this.game.Data.RuleVar[99]) : (int) Math.Round((double) this.game.Data.RuleVar[890]);
      this.AddLog("VAR_SUPPLY_ENEMY_MOVETYPE = " + this.VAR_SUPPLY_ENEMY_MOVETYPE.ToString() + " (rulevar 890 or 99)");
      this.VAR_RAIL_TRANSFER_MOVETYPE = (int) Math.Round((double) this.game.Data.RuleVar[2]);
      this.AddLog("VAR_RAIL_TRANSFER_MOVETYPE = " + this.VAR_RAIL_TRANSFER_MOVETYPE.ToString() + " (rulevar 2)");
      this.VAR_TRANSFER_MAXIMUM_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[78]);
      this.AddLog("VAR_TRANSFER_MAXIMUM_RANGE = " + this.VAR_TRANSFER_MAXIMUM_RANGE.ToString() + " (rulevar 78)");
      this.VAR_STRATEGIC_TRANSFER_STARTUP_COST = (int) Math.Round((double) this.game.Data.RuleVar[351]);
      this.AddLog("VAR_STRATEGIC_TRANSFER_STARTUP_COST = " + this.VAR_STRATEGIC_TRANSFER_STARTUP_COST.ToString() + " (rulevar 351)");
      this.VAR_SUPPLY_MAXIMUM_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[3]);
      this.AddLog("VAR_SUPPLY_MAXIMUM_RANGE = " + this.VAR_SUPPLY_MAXIMUM_RANGE.ToString() + " (rulevar 3)");
      this.VAR_SUPPLY_75PERCENT_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[51]);
      this.AddLog("VAR_SUPPLY_75PERCENT_RANGE = " + this.VAR_SUPPLY_75PERCENT_RANGE.ToString() + " (rulevar 51)");
      this.VAR_SUPPLY_50PERCENT_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[52]);
      this.AddLog("VAR_SUPPLY_50PERCENT_RANGE = " + this.VAR_SUPPLY_50PERCENT_RANGE.ToString() + " (rulevar 52)");
      this.VAR_SUPPLY_25PERCENT_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[53]);
      this.AddLog("VAR_SUPPLY_25PERCENT_RANGE = " + this.VAR_SUPPLY_25PERCENT_RANGE.ToString() + " (rulevar 53)");
      this.VAR_HQ_100PERCENT_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[73]);
      this.AddLog("VAR_HQ_100PERCENT_RANGE = " + this.VAR_HQ_100PERCENT_RANGE.ToString() + " (rulevar 73)");
      if ((double) this.game.Data.RuleVar[987] > (double) this.game.Data.RuleVar[73])
        this.VAR_HQ_100PERCENT_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[987]);
      this.VAR_HQ_PERCENTDROP_PERHEX = (int) Math.Round((double) this.game.Data.RuleVar[74]);
      this.AddLog("VAR_HQ_PERCENTDROP_PERHEX = " + this.VAR_HQ_PERCENTDROP_PERHEX.ToString() + " (rulevar 74)");
      this.VAR_SUPPLY_WEIGHT = this.game.Data.RuleVar[33];
      this.AddLog("VAR_SUPPLY_WEIGHT = " + this.VAR_SUPPLY_WEIGHT.ToString() + " (rulevar 33)");
      this.VAR_HEX_STACK_REGULAR = (int) Math.Round((double) this.game.Data.RuleVar[30]);
      this.AddLog("VAR_HEX_STACK_REGULAR = " + this.VAR_HEX_STACK_REGULAR.ToString() + " (rulevar 30)");
      this.VAR_HEX_STACK_AIR = (int) Math.Round((double) this.game.Data.RuleVar[833]);
      this.AddLog("VAR_HEX_STACK_AIR = " + this.VAR_HEX_STACK_AIR.ToString() + " (rulevar 833)");
      this.VAR_CELLULAR_AUTOMATON_ITERATIONS = 4;
      if ((int) Math.Round((double) this.game.Data.RuleVar[931]) > 0)
        this.VAR_CELLULAR_AUTOMATON_ITERATIONS = (int) Math.Round((double) this.game.Data.RuleVar[931]);
      this.AddLog("VAR_CELLULAR_AUTOMATON_ITERATIONS = " + this.VAR_CELLULAR_AUTOMATON_ITERATIONS.ToString() + " (rulevar 931)");
      this.VAR_DISABLE_RETREAT_STANCE = false;
      if ((double) this.game.Data.RuleVar[918] == 1.0)
        this.VAR_DISABLE_RETREAT_STANCE = true;
      this.AddLog("VAR_DISABLE_RETREAT_STANCE = " + this.VAR_DISABLE_RETREAT_STANCE.ToString() + " (rulevar 918)");
      this.VAR_DISABLE_FULLRETREAT_STANCE = false;
      if ((double) this.game.Data.RuleVar[917] == 1.0)
        this.VAR_DISABLE_FULLRETREAT_STANCE = true;
      this.AddLog("VAR_DISABLE_FULLRETREAT_STANCE = " + this.VAR_DISABLE_FULLRETREAT_STANCE.ToString() + " (rulevar 917)");
      this.VAR_GARRISON_RULE1_MIN_VP = (int) Math.Round((double) this.game.Data.RuleVar[919]);
      this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE = (int) Math.Round((double) this.game.Data.RuleVar[920]);
      this.VAR_GARRISON_RULE2_MIN_VP = (int) Math.Round((double) this.game.Data.RuleVar[923]);
      this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE = (int) Math.Round((double) this.game.Data.RuleVar[924]);
      this.VAR_GARRISON_MIN_VP_ALWAYS = (int) Math.Round((double) this.game.Data.RuleVar[922]);
      this.VAR_GARRISON_PORT_ALWAYS = false;
      if ((double) this.game.Data.RuleVar[921] > 0.0)
        this.VAR_GARRISON_PORT_ALWAYS = true;
      this.AddLog("VAR_GARRISON_RULE1_MIN_VP = " + this.VAR_GARRISON_RULE1_MIN_VP.ToString() + " (rulevar 919)");
      this.AddLog("VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE = " + this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE.ToString() + " (rulevar 920)");
      this.AddLog("VAR_GARRISON_RULE2_MIN_VP  = " + this.VAR_GARRISON_RULE2_MIN_VP.ToString() + " (rulevar 923)");
      this.AddLog("VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE = " + this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE.ToString() + " (rulevar 924)");
      this.AddLog("VAR_GARRISON_MIN_VP_ALWAYS = " + this.VAR_GARRISON_MIN_VP_ALWAYS.ToString() + " (rulevar 922)");
      this.AddLog("VAR_GARRISON_PORT_ALWAYS= " + this.VAR_GARRISON_PORT_ALWAYS.ToString() + " (rulevar 921)");
      this.VAR_VP_AT_DEFEAT = (int) Math.Round((double) this.game.Data.RuleVar[265]);
      this.VAR_VP_AT_VICTORY = (int) Math.Round((double) this.game.Data.RuleVar[266]);
      this.AddLog("VAR_VP_AT_DEFEAT = " + this.VAR_VP_AT_DEFEAT.ToString() + " (rulevar 265)");
      this.AddLog("VAR_VP_AT_VICTORY = " + this.VAR_VP_AT_VICTORY.ToString() + " (rulevar 266)");
      this.VAR_FORTRESSMODE_MIN_VP = (int) Math.Round((double) this.game.Data.RuleVar[939]);
      this.AddLog("VAR_FORTRESSMODE_MIN_VP = " + this.VAR_FORTRESSMODE_MIN_VP.ToString() + " (rulevar 939)");
      this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES = false;
      this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT = false;
      if ((double) this.game.Data.RuleVar[940] > 0.0)
        this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES = true;
      this.AddLog("VAR_ALWAYS_PROTECT_FRONTLINE_CITIES = " + this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES.ToString() + " (rulevar 940)");
      if ((double) this.game.Data.RuleVar[940] == 2.0)
        this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT = true;
      this.AddLog("VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT = " + this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT.ToString() + " (rulevar 940)");
      this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION = 1f;
      if ((double) this.game.Data.RuleVar[943] > 0.0)
        this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION = this.game.Data.RuleVar[943];
      this.AddLog("VAR_MODIFY_OWN_STRENGTH_PERCEPTION = " + this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION.ToString() + " (rulevar 943)");
      this.VAR_MODIFY_MINIMUM_ATTACK = 1f;
      if ((double) this.game.Data.RuleVar[942] > 0.0)
        this.VAR_MODIFY_MINIMUM_ATTACK = this.game.Data.RuleVar[942];
      this.AddLog("VAR_MODIFY_MINIMUM_ATTACK = " + this.VAR_MODIFY_MINIMUM_ATTACK.ToString() + " (rulevar 942)");
      this.VAR_TOP_UNIT_MINIMUM_ARMOR_SUBUNITS = (int) Math.Round((double) this.game.Data.RuleVar[937]);
      this.AddLog("VAR_TOP_UNIT_MINIMUM_ARMOR_SUBUNITS = " + this.VAR_TOP_UNIT_MINIMUM_ARMOR_SUBUNITS.ToString() + " (rulevar 937)");
      this.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE = (int) Math.Round((double) this.game.Data.RuleVar[986]);
      this.AddLog("VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE = " + this.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE.ToString() + " (rulevar 986)");
      this.VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD = false;
      if ((int) Math.Round((double) this.game.Data.RuleVar[985]) == 1)
        this.VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD = true;
      this.AddLog(" VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD = " + this.VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD.ToString() + " (rulevar 985)");
      this.AddLog("SUPPLY COORDS FOR ALL REGIMES (rulevar 335)");
      this.VAR_SUPPLY_COUNTER = 4;
      this.VAR_SUPPLY_ACTIVE = new bool[this.game.Data.RegimeCounter + 1, this.VAR_SUPPLY_COUNTER + 1];
      this.VAR_SUPPLY_X = new int[this.game.Data.RegimeCounter + 1, this.VAR_SUPPLY_COUNTER + 1];
      this.VAR_SUPPLY_Y = new int[this.game.Data.RegimeCounter + 1, this.VAR_SUPPLY_COUNTER + 1];
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter; ++index1)
      {
        if ((double) this.game.Data.RuleVar[335] > 0.0)
        {
          int index2 = 0;
          do
          {
            if (this.game.Data.RegimeObj[index1].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 3f + (float) (index2 * 4)))] > 0 && this.game.Data.RegimeObj[index1].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 0.0f + (float) (index2 * 4)))] > -1 && this.game.Data.RegimeObj[index1].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 1f + (float) (index2 * 4)))] > -1)
            {
              this.VAR_SUPPLY_ACTIVE[index1, index2] = true;
              this.VAR_SUPPLY_X[index1, index2] = this.game.Data.RegimeObj[index1].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 0.0f + (float) (index2 * 4)))];
              this.VAR_SUPPLY_Y[index1, index2] = this.game.Data.RegimeObj[index1].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 1f + (float) (index2 * 4)))];
              this.AddLog("SUPPLY COORD FOR " + this.game.Data.RegimeObj[index1].Name + " : " + this.VAR_SUPPLY_X[index1, index2].ToString() + ", " + this.VAR_SUPPLY_Y[index1, index2].ToString());
            }
            ++index2;
          }
          while (index2 <= 3);
        }
      }
      this.VAR_USE_DYNAMIC_OOB = false;
      this.VAR_USE_REGIME_CARDS = false;
      if ((double) this.game.Data.RuleVar[913] > 0.0)
        this.VAR_USE_DYNAMIC_OOB = true;
      if ((double) this.game.Data.RuleVar[913] > 0.0)
        this.VAR_USE_REGIME_CARDS = true;
      if ((double) this.game.Data.RuleVar[913] == -1.0)
        this.VAR_USE_REGIME_CARDS = true;
      this.AddLog("VAR_USE_DYNAMIC_OOB = " + this.VAR_USE_DYNAMIC_OOB.ToString() + " (rulevar 913; means creating new units)");
      this.AddLog("VAR_USE_REGIME_CARDS = " + this.VAR_USE_REGIME_CARDS.ToString() + " (rulevar 913)");
      this.VAR_TOP_OPERATIONS_PERCENTAGE = 0;
      this.VAR_USE_TOP_OPERATIONS = false;
      if ((double) this.game.Data.RuleVar[928] > 0.0)
      {
        this.VAR_USE_TOP_OPERATIONS = true;
        this.VAR_TOP_OPERATIONS_PERCENTAGE = (int) Math.Round((double) this.game.Data.RuleVar[928]);
      }
      this.AddLog("VAR_USE_TOP_OPERATIONS = " + this.VAR_USE_TOP_OPERATIONS.ToString() + " (rulevar 928)");
      this.AddLog("VAR_TOP_OPERATIONS_PERCENTAGE = " + this.VAR_TOP_OPERATIONS_PERCENTAGE.ToString() + " (rulevar 928)");
      this.VAR_USE_CHANGE_HQ = true;
      this.VAR_USE_CHANGE_HQ_IF_NONE = false;
      if ((double) this.game.Data.RuleVar[521] > 0.0)
        this.VAR_USE_CHANGE_HQ = false;
      if ((double) this.game.Data.RuleVar[521] == 2.0)
        this.VAR_USE_CHANGE_HQ_IF_NONE = true;
      if (this.VAR_USE_CHANGE_HQ && (double) this.game.Data.RuleVar[465] > 0.0)
      {
        this.VAR_USE_CHANGE_HQ = false;
        this.VAR_USE_CHANGE_HQ_IF_NONE = true;
      }
      this.AddLog("VAR_USE_CHANGE_HQ = " + this.VAR_USE_CHANGE_HQ.ToString() + " (rulevar 521)");
      this.AddLog("VAR_USE_CHANGE_HQ_IF_NONE = " + this.VAR_USE_CHANGE_HQ_IF_NONE.ToString() + " (rulevar 521)");
      this.VAR_USE_OFFICERPOOL = false;
      if ((double) this.game.Data.RuleVar[343] > 0.0)
        this.VAR_USE_OFFICERPOOL = true;
      this.AddLog("VAR_USE_OFFICERPOOL  = " + this.VAR_USE_OFFICERPOOL.ToString() + " (rulevar 343)");
      this.VAR_USE_STRATEGIC_TRANSFERS = true;
      if ((double) this.game.Data.RuleVar[520] > 0.0)
        this.VAR_USE_STRATEGIC_TRANSFERS = false;
      this.AddLog("VAR_USE_STRATEGIC_TRANSFERS  = " + this.VAR_USE_STRATEGIC_TRANSFERS.ToString() + " (rulevar 520)");
      this.VAR_HAMMER_OUT_POCKETS = false;
      if ((double) this.game.Data.RuleVar[466] > 0.0)
        this.VAR_HAMMER_OUT_POCKETS = true;
      this.VAR_USE_ADD_UNIT = true;
      if ((double) this.game.Data.RuleVar[512] > 0.0)
        this.VAR_USE_ADD_UNIT = false;
      this.AddLog("VAR_USE_ADD_UNIT  = " + this.VAR_USE_ADD_UNIT.ToString() + " (rulevar 512)");
      this.VAR_USE_UBER_UNTER_RULES = false;
      if ((double) this.game.Data.RuleVar[938] > 0.0)
        this.VAR_USE_UBER_UNTER_RULES = true;
      this.AddLog("VAR_USE_UBER_UNTER_RULES   = " + this.VAR_USE_UBER_UNTER_RULES.ToString() + " (rulevar 938)");
      if ((double) this.game.Data.RuleVar[997] != 0.0)
        this.VAR_STRICTHQ_DIST_IMPORTANCE = (int) Math.Round((double) this.game.Data.RuleVar[997]);
      this.AddLog("VAR_STRICTHQ_DIST_IMPORTANCE   = " + this.VAR_STRICTHQ_DIST_IMPORTANCE.ToString() + " (rulevar 997)");
      this.VAR_USE_SSHQ = false;
      if ((double) this.game.Data.RuleVar[967] > 0.0)
        this.VAR_USE_SSHQ = true;
      this.VAR_SSHQ_SIZE1 = (int) Math.Round((double) this.game.Data.RuleVar[967]);
      this.VAR_SSHQ_SIZE2 = (int) Math.Round((double) this.game.Data.RuleVar[968]);
      this.AddLog("VAR_USE_SSHQ = " + this.VAR_USE_SSHQ.ToString() + " (rulevar 967)");
      this.AddLog("VAR_SSHQ_SIZE1 = " + this.VAR_SSHQ_SIZE1.ToString() + " (rulevar 967)");
      this.AddLog("VAR_SSHQ_SIZE2 = " + this.VAR_SSHQ_SIZE2.ToString() + " (rulevar 968)");
      this.VAR_USE_MLA = false;
      if ((double) this.game.Data.RuleVar[969] > 0.0)
        this.VAR_USE_MLA = true;
      this.AddLog("VAR_USE_MLA = " + this.VAR_USE_MLA.ToString() + " (rulevar 969)");
      this.VAR_MLA_RANGE = (int) Math.Round((double) this.game.Data.RuleVar[969]);
      this.AddLog("VAR_MLA_RANGE = " + this.VAR_MLA_RANGE.ToString() + " (rulevar 969)");
      this.VAR_USE_SUPERFRONTS = false;
      if ((double) this.game.Data.RuleVar[958] > 0.0)
        this.VAR_USE_SUPERFRONTS = true;
      this.AddLog("VAR_USE_SUPERFRONTS = " + this.VAR_USE_SUPERFRONTS.ToString() + " (rulevar 958)");
      this.VAR_SUPERFRONT_EVENT = (int) Math.Round((double) this.game.Data.RuleVar[959]);
      this.AddLog("VAR_SUPERFRONT_EVENT = " + this.VAR_SUPERFRONT_EVENT.ToString() + " (rulevar 959)");
      this.VAR_SUPERFRONT_AREASLOT = (int) Math.Round((double) this.game.Data.RuleVar[960]);
      this.AddLog("VAR_SUPERFRONT_AREASLOT = " + this.VAR_SUPERFRONT_AREASLOT.ToString() + " (rulevar 960)");
      this.VAR_SUPERFRONT_HQLEVEL = 0;
      if ((double) this.game.Data.RuleVar[958] > 0.0)
        this.VAR_SUPERFRONT_HQLEVEL = (int) Math.Round((double) this.game.Data.RuleVar[958]);
      this.AddLog("VAR_SUPERFRONT_HQLEVEL   = " + this.VAR_SUPERFRONT_HQLEVEL.ToString() + " (rulevar 958)");
      this.VAR_ZONES_TYPE = (int) Math.Round((double) this.game.Data.RuleVar[963]);
      this.AddLog("VAR_ZONES_TYPE   = " + this.VAR_ZONES_TYPE.ToString() + " (rulevar 963)");
      this.VAR_ZONES_EVENT = (int) Math.Round((double) this.game.Data.RuleVar[965]);
      this.AddLog("VAR_ZONES_EVENT = " + this.VAR_ZONES_EVENT.ToString() + " (rulevar 965)");
      this.VAR_RETREAT_EVENT = (int) Math.Round((double) this.game.Data.RuleVar[980]);
      this.AddLog("VAR_RETREAT_EVENT = " + this.VAR_RETREAT_EVENT.ToString() + " (rulevar 980)");
      this.VAR_STRENGTH_EVENT = (int) Math.Round((double) this.game.Data.RuleVar[981]);
      this.AddLog("VAR_STRENGTH_EVENT = " + this.VAR_STRENGTH_EVENT.ToString() + " (rulevar 981)");
      this.VAR_ZONES_AREASLOT = (int) Math.Round((double) this.game.Data.RuleVar[964]);
      this.AddLog("VAR_ZONES_AREASLOT = " + this.VAR_ZONES_AREASLOT.ToString() + " (rulevar 964)");
      this.VAR_USE_BROAD_DEFENSIVE_ZONES = false;
      if ((double) this.game.Data.RuleVar[979] > 0.0)
      {
        this.VAR_USE_BROAD_DEFENSIVE_ZONES = true;
        this.VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM = (int) Math.Round((double) this.game.Data.RuleVar[979]);
      }
      this.AddLog("VAR_USE_BROAD_DEFENSIVE_ZONES   = " + this.VAR_USE_BROAD_DEFENSIVE_ZONES.ToString() + " (rulevar 979)");
      this.AddLog("VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM   = " + this.VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM.ToString() + " (rulevar 979)");
      this.VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT = false;
      this.VAR_USE_STRICT_HQFRONT = false;
      if ((double) this.game.Data.RuleVar[961] == 1.0)
        this.VAR_USE_STRICT_HQFRONT = true;
      if (this.game.Data.Product == 6)
      {
        int library = this.game.Data.FindLibrary("vr_ai_lib");
        if (library > -1 && this.game.Data.LibraryObj[library].version < 11)
        {
          this.VAR_USE_STRICT_HQFRONT = true;
          this.game.Data.RuleVar[961] = 1f;
        }
      }
      this.AddLog("VAR_USE_STRICT_HQFRONT = " + this.VAR_USE_STRICT_HQFRONT.ToString() + " (rulevar 961)");
      this.VAR_BEST_HISVARTYPE_ANYLEVELHQ = (int) Math.Round((double) this.game.Data.RuleVar[915]);
      this.AddLog("VAR_BEST_HISVARTYPE_ANYLEVELHQ = " + this.VAR_BEST_HISVARTYPE_ANYLEVELHQ.ToString() + " (rulevar 915)");
      this.VAR_TOPUNIT_STIMULUS = (int) Math.Round((double) this.game.Data.RuleVar[982]);
      this.AddLog(" VAR_TOPUNIT_STIMULUS = " + this.VAR_TOPUNIT_STIMULUS.ToString() + " (rulevar 982)");
      this.VAR_BEST_HISVARTYPE_HIGHERLEVELHQ = (int) Math.Round((double) this.game.Data.RuleVar[916]);
      this.AddLog("VAR_BEST_HISVARTYPE_HIGHERLEVELHQ = " + this.VAR_BEST_HISVARTYPE_HIGHERLEVELHQ.ToString() + " (rulevar 916)");
      this.VAR_ENEMYMOVE_PROGNOSIS_MODE = (int) Math.Round((double) this.game.Data.RuleVar[962]);
      this.AddLog("VAR_ENEMYMOVE_PROGNOSIS_MODE = " + this.VAR_ENEMYMOVE_PROGNOSIS_MODE.ToString() + " (rulevar 962)");
      this.VAR_EMPHASIS_AGAINST_CONCENTRIC = false;
      if ((double) this.game.Data.RuleVar[994] > 0.0)
        this.VAR_EMPHASIS_AGAINST_CONCENTRIC = true;
      this.AddLog("VAR_EMPHASIS_AGAINST_CONCENTRIC = " + this.VAR_EMPHASIS_AGAINST_CONCENTRIC.ToString() + " (rulevar 994)");
      this.VAR_EMPHASIS_FOR_CONCENTRIC = false;
      if ((double) this.game.Data.RuleVar[993] > 0.0)
        this.VAR_EMPHASIS_FOR_CONCENTRIC = true;
      this.AddLog("VAR_EMPHASIS_FOR_CONCENTRIC = " + this.VAR_EMPHASIS_FOR_CONCENTRIC.ToString() + " (rulevar 993)");
      this.VAR_SIEGE_SIMULATION = false;
      if ((double) this.game.Data.RuleVar[991] > 0.0)
      {
        this.VAR_SIEGE_SIMULATION = true;
        this.VAR_SIEGE_SIMULATION_MAX_ENTR = (int) Math.Round((double) this.game.Data.RuleVar[991]);
      }
      this.AddLog("VAR_SIEGE_SIMULATION = " + this.VAR_SIEGE_SIMULATION.ToString() + " (rulevar 991)");
      this.AddLog("VAR_SIEGE_SIMULATION_MAX_ENTR = " + this.VAR_SIEGE_SIMULATION_MAX_ENTR.ToString() + " (rulevar 991)");
      this.AddLog("\r\nAI CONSIDERS ARMOUR SF-TYPES: (used for top-unit determination)");
      int sfTypeCounter = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; ++index)
      {
        if (this.game.Data.SFTypeObj[index].AIRoleScore[10] > 33)
          this.AddLog("-" + this.game.Data.SFTypeObj[index].Name + " (" + this.game.Data.SFTypeObj[index].AIRoleScore[10].ToString() + ")");
      }
      this.AddLog("\r\n");
      if (Information.IsNothing((object) this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0]))
        this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      this.AddLog("\r\nAIVP points on map:");
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth; ++index3)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          if (this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index3, index4] > 0)
            this.AddLog("\r\n" + index3.ToString() + "," + index4.ToString() + " = " + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index3, index4].ToString());
        }
      }
      this.AddLog("\r\n");
      if (this.game.Data.Product == 7 && !this.game.Data.DontShowAIMove & this.VAR_DEBUG_ON)
        this.VAR_DEBUG_ON = false;
      if (this.CustomCalls.HasCustumCalls())
        this.CustomCalls.CustomRuleInitVars();
      this.WriteLog("0000_Setup_AI");
      this.combatMatrix = new float[this.game.Data.SFTypeCounter + 1, this.game.Data.SFTypeCounter + 1];
    }

    public void InitRegimeCards(bool debugOverrule, bool earlyCall = false)
    {
      bool flag = false;
      if (debugOverrule)
        flag = true;
      AIMatrix aiMatrix1 = this.extendedMatrix.Clone();
      aiMatrix1.ExpandAllNonZeroValuesForAnyRegime(6);
      if (!this.VAR_USE_REGIME_CARDS)
        return;
      string s = "Regime Cards\r\n";
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai1);
      AIMatrix aiMatrix3 = this.SetOwnerMatrix(aiMatrix2.Left, aiMatrix2.Top, aiMatrix2.Width, aiMatrix2.Height);
      AIMatrix aiMatrix4 = this.strengthMatrix.Clone();
      aiMatrix4.MultiplyAllValues(10);
      int mapWidth1 = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (aiMatrix4.Value[index1, index2] > 0)
          {
            if (this.VAR_MATRIX_STRENGTH.Value[index1, index2] >= 300)
            {
              int[,] numArray1 = aiMatrix4.Value;
              int[,] numArray2 = numArray1;
              int index3 = index1;
              int index4 = index3;
              int index5 = index2;
              int index6 = index5;
              int num = numArray1[index3, index5] + 5;
              numArray2[index4, index6] = num;
            }
            else if (this.VAR_MATRIX_STRENGTH.Value[index1, index2] >= 200)
            {
              int[,] numArray3 = aiMatrix4.Value;
              int[,] numArray4 = numArray3;
              int index7 = index1;
              int index8 = index7;
              int index9 = index2;
              int index10 = index9;
              int num = numArray3[index7, index9] + 3;
              numArray4[index8, index10] = num;
            }
            else if (this.VAR_MATRIX_STRENGTH.Value[index1, index2] >= 150)
            {
              int[,] numArray5 = aiMatrix4.Value;
              int[,] numArray6 = numArray5;
              int index11 = index1;
              int index12 = index11;
              int index13 = index2;
              int index14 = index13;
              int num = numArray5[index11, index13] + 1;
              numArray6[index12, index14] = num;
            }
            else if (this.VAR_MATRIX_STRENGTH.Value[index1, index2] < 50)
            {
              int[,] numArray7 = aiMatrix4.Value;
              int[,] numArray8 = numArray7;
              int index15 = index1;
              int index16 = index15;
              int index17 = index2;
              int index18 = index17;
              int num = numArray7[index15, index17] - 7;
              numArray8[index16, index18] = num;
            }
            else if (this.VAR_MATRIX_STRENGTH.Value[index1, index2] < 100)
            {
              int[,] numArray9 = aiMatrix4.Value;
              int[,] numArray10 = numArray9;
              int index19 = index1;
              int index20 = index19;
              int index21 = index2;
              int index22 = index21;
              int num = numArray9[index19, index21] - 3;
              numArray10[index20, index22] = num;
            }
            if (this.VAR_MATRIX_RETREAT.Value[index1, index2] >= 400)
            {
              int[,] numArray11 = aiMatrix4.Value;
              int[,] numArray12 = numArray11;
              int index23 = index1;
              int index24 = index23;
              int index25 = index2;
              int index26 = index25;
              int num = numArray11[index23, index25] + 4;
              numArray12[index24, index26] = num;
            }
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] >= 250)
            {
              int[,] numArray13 = aiMatrix4.Value;
              int[,] numArray14 = numArray13;
              int index27 = index1;
              int index28 = index27;
              int index29 = index2;
              int index30 = index29;
              int num = numArray13[index27, index29] + 2;
              numArray14[index28, index30] = num;
            }
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] >= 150)
            {
              int[,] numArray15 = aiMatrix4.Value;
              int[,] numArray16 = numArray15;
              int index31 = index1;
              int index32 = index31;
              int index33 = index2;
              int index34 = index33;
              int num = numArray15[index31, index33] + 1;
              numArray16[index32, index34] = num;
            }
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] <= 75)
            {
              int[,] numArray17 = aiMatrix4.Value;
              int[,] numArray18 = numArray17;
              int index35 = index1;
              int index36 = index35;
              int index37 = index2;
              int index38 = index37;
              int num = numArray17[index35, index37] - 1;
              numArray18[index36, index38] = num;
            }
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] <= 50)
            {
              int[,] numArray19 = aiMatrix4.Value;
              int[,] numArray20 = numArray19;
              int index39 = index1;
              int index40 = index39;
              int index41 = index2;
              int index42 = index41;
              int num = numArray19[index39, index41] - 4;
              numArray20[index40, index42] = num;
            }
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] <= 25)
            {
              int[,] numArray21 = aiMatrix4.Value;
              int[,] numArray22 = numArray21;
              int index43 = index1;
              int index44 = index43;
              int index45 = index2;
              int index46 = index45;
              int num = numArray21[index43, index45] - 8;
              numArray22[index44, index46] = num;
            }
          }
        }
      }
      AIMatrix aiMatrix5 = aiMatrix4.AverageValuesForSameRegime(4, aiMatrix3, true, 1);
      aiMatrix5.ExpandUniquesValuesForSameRegime();
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix6 = new AIMatrix(ref tai2);
      AIMatrix aiMatrix7 = aiMatrix3.Clone();
      aiMatrix7.RemoveValuesByMask(aiMatrix3, 1);
      aiMatrix7.ExpandAndAddValueForAnyRegime(29);
      int mapWidth2 = this.map.MapWidth;
      for (int index47 = 0; index47 <= mapWidth2; ++index47)
      {
        int mapHeight = this.map.MapHeight;
        for (int index48 = 0; index48 <= mapHeight; ++index48)
        {
          if (this.probableEnemyPenetration.Value[index47, index48] > 0)
          {
            aiMatrix5.Value[index47, index48] = (int) Math.Round(0.66 * (double) aiMatrix5.Value[index47, index48]) + (int) Math.Round(0.33 * (double) aiMatrix5.Value[index47, index48] / (double) this.probableEnemyPenetration.Value[index47, index48]);
            if (aiMatrix7.Value[index47, index48] > 3 && this.map.HexObj[index47, index48].UnitCounter > -1 && this.map.HexObj[index47, index48].Regime == this.game.Data.Turn)
            {
              int[,] numArray23 = aiMatrix5.Value;
              int[,] numArray24 = numArray23;
              int index49 = index47;
              int index50 = index49;
              int index51 = index48;
              int index52 = index51;
              int num = numArray23[index49, index51] + (1 + this.map.HexObj[index47, index48].UnitCounter) * 20;
              numArray24[index50, index52] = num;
            }
          }
        }
      }
      int mapWidth3 = this.map.MapWidth;
      for (int index53 = 0; index53 <= mapWidth3; ++index53)
      {
        int mapHeight = this.map.MapHeight;
        for (int index54 = 0; index54 <= mapHeight; ++index54)
        {
          if (this.probableEnemyPenetration.Value[index53, index54] > 0)
            aiMatrix5.Value[index53, index54] = (int) Math.Round(0.66 * (double) aiMatrix5.Value[index53, index54]) + (int) Math.Round(0.33 * (double) aiMatrix5.Value[index53, index54] / (double) this.probableEnemyPenetration.Value[index53, index54]);
        }
      }
      AIMatrix aiMatrix8 = aiMatrix5.AverageValuesForSameRegime(6, aiMatrix3);
      int mapWidth4 = this.map.MapWidth;
      for (int x1 = 0; x1 <= mapWidth4; ++x1)
      {
        int mapHeight = this.map.MapHeight;
        for (int y1 = 0; y1 <= mapHeight; ++y1)
        {
          if (aiMatrix7.Value[x1, y1] > this.VAR_FRONTLINE_DEPTH && this.map.HexObj[x1, y1].UnitCounter > -1 && this.map.HexObj[x1, y1].Regime == this.game.Data.Turn)
          {
            int num1 = (1 + this.map.HexObj[x1, y1].UnitCounter) * 1;
            if (num1 > 4)
              num1 = 4 + (int) Math.Round(Math.Sqrt((double) (num1 - 4)));
            int num2 = x1 - 6;
            int num3 = x1 + 6;
            for (int x2 = num2; x2 <= num3; ++x2)
            {
              int num4 = y1 - 6;
              int num5 = y1 + 6;
              for (int y2 = num4; y2 <= num5; ++y2)
              {
                if (x2 >= 0 & y2 >= 0 & x2 <= this.map.MapWidth & y2 <= this.map.MapHeight && this.map.HexObj[x2, y2].Regime == this.game.Data.Turn)
                {
                  int num6 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, 99);
                  if (num6 <= 6)
                  {
                    int[,] numArray25 = aiMatrix8.Value;
                    int[,] numArray26 = numArray25;
                    int index55 = x2;
                    int index56 = index55;
                    int index57 = y2;
                    int index58 = index57;
                    int num7 = numArray25[index55, index57] + (int) Math.Round((double) (2 * num1) / (double) (num6 + 1));
                    numArray26[index56, index58] = num7;
                  }
                }
              }
            }
          }
        }
      }
      AIMatrix aiMatrix9 = aiMatrix8.Clone();
      int x2_1;
      int y2_1;
      for (int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
      {
        int cardnr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[actionCardCounter];
        int num8 = 0;
        if (this.game.Data.ActionCardObj[cardnr].AILabel == 1 && this.game.Data.ActionCardObj[cardnr].PreExecuteEvent > -1 & this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[cardnr].PPCost && this.game.Data.ActionCardObj[cardnr].AreaSlot > -1 & this.game.Data.ActionCardObj[cardnr].AreaValue > -1)
        {
          this.game.ProcessingObj.PlayCardPreEvent(cardnr);
          int mapWidth5 = this.map.MapWidth;
          for (int x = 0; x <= mapWidth5; ++x)
          {
            int mapHeight = this.map.MapHeight;
            for (int y = 0; y <= mapHeight; ++y)
            {
              if (this.map.HexObj[x, y].AreaCode[this.game.Data.ActionCardObj[cardnr].AreaSlot] == this.game.Data.ActionCardObj[cardnr].AreaValue)
              {
                int num9 = 100 - aiMatrix8.Value[x, y];
                if (num9 < 1)
                  num9 = 1;
                int num10 = num9 * 10;
                if (aiMatrix7.Value[x, y] >= 1 & aiMatrix7.Value[x, y] <= 4)
                  num10 = (int) Math.Round((double) num10 / (double) aiMatrix7.Value[x, y]);
                else if (aiMatrix7.Value[x, y] >= 5 & aiMatrix7.Value[x, y] <= 9)
                  num10 = (int) Math.Round((double) (num10 * aiMatrix7.Value[x, y]) / 5.0);
                else if (aiMatrix7.Value[x, y] >= 10)
                  num10 = !(aiMatrix7.Value[x, y] < 1 | aiMatrix7.Value[x, y] > 19) ? (int) Math.Round((double) ((int) Math.Round((double) (num10 * 9) / 5.0) * 9) / (double) aiMatrix7.Value[x, y]) : -999;
                if (this.friendlySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_75PERCENT_RANGE)
                  num10 = (int) Math.Round((double) num10 / 2.0);
                if (this.friendlySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_50PERCENT_RANGE)
                  num10 = (int) Math.Round((double) num10 / 2.0);
                if (this.friendlySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_25PERCENT_RANGE)
                  num10 = (int) Math.Round((double) num10 / 2.0);
                if (this.friendlySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_MAXIMUM_RANGE)
                  num10 = -9999;
                if (num10 > 0)
                {
                  if (this.map.HexObj[x, y].UnitCounter > 3)
                    num10 = (int) Math.Round((double) num10 * 0.8);
                  if (this.map.HexObj[x, y].UnitCounter > 6)
                    num10 = (int) Math.Round((double) num10 * 0.5);
                  if (this.map.HexObj[x, y].UnitCounter > 9)
                    num10 = (int) Math.Round((double) num10 * 0.25);
                  if (this.map.HexObj[x, y].UnitCounter > 12)
                    num10 = (int) Math.Round((double) num10 * 0.05);
                  if (this.map.HexObj[x, y].Location > -1)
                    num10 = (int) Math.Round((double) num10 * 1.15);
                  else if (this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
                    num10 = (int) Math.Round((double) num10 * 1.07);
                  if (this.VAR_MATRIX_STRENGTH.Value[x, y] > 0)
                  {
                    if (this.VAR_MATRIX_STRENGTH.Value[x, y] <= 25)
                      num10 = (int) Math.Round((double) num10 * 1.1);
                    else if (this.VAR_MATRIX_STRENGTH.Value[x, y] <= 50)
                      num10 = (int) Math.Round((double) num10 * 1.066);
                    else if (this.VAR_MATRIX_STRENGTH.Value[x, y] <= 75)
                      num10 = (int) Math.Round((double) num10 * 1.033);
                  }
                }
                if (num10 > num8)
                {
                  num8 = num10;
                  x2_1 = x;
                  y2_1 = y;
                }
              }
            }
          }
        }
        if (num8 > 0)
        {
          this.game.EditObj.AreaX = x2_1;
          this.game.EditObj.AreaY = y2_1;
          s = s + "\r\n" + "PLAYED CARD!!!  target hex selected = " + this.game.EditObj.AreaX.ToString() + "," + this.game.EditObj.AreaY.ToString();
          this.game.ProcessingObj.PlayCard(this.game.Data.Turn, actionCardCounter);
          aiMatrix8 = aiMatrix9.Clone();
          int num11 = x2_1 - 6;
          int num12 = x2_1 + 6;
          for (int x1 = num11; x1 <= num12; ++x1)
          {
            int num13 = y2_1 - 6;
            int num14 = y2_1 + 6;
            for (int y1 = num13; y1 <= num14; ++y1)
            {
              if (x1 >= 0 & y1 >= 0 & x1 <= this.map.MapWidth & y1 <= this.map.MapHeight)
              {
                int num15 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2_1, y2_1, 0, 99);
                if (num15 <= 6)
                {
                  int[,] numArray27 = aiMatrix8.Value;
                  int[,] numArray28 = numArray27;
                  int index59 = x1;
                  int index60 = index59;
                  int index61 = y1;
                  int index62 = index61;
                  int num16 = numArray27[index59, index61] + (int) Math.Round((double) (7 - num15) * Math.Max(1.0, (double) (7 - num15) * 1.5));
                  numArray28[index60, index62] = num16;
                }
              }
            }
          }
          aiMatrix9 = aiMatrix8.Clone();
        }
      }
      for (int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
      {
        int cardnr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[actionCardCounter];
        int num17 = 0;
        if (this.game.Data.ActionCardObj[cardnr].AILabel == 3 & this.game.Data.ActionCardObj[cardnr].AILabel2 == 1 && this.game.Data.ActionCardObj[cardnr].PreExecuteEvent > -1 & this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[cardnr].PPCost && this.game.Data.ActionCardObj[cardnr].AreaSlot > -1 & this.game.Data.ActionCardObj[cardnr].AreaValue > -1)
        {
          this.game.ProcessingObj.PlayCardPreEvent(cardnr);
          int mapWidth6 = this.map.MapWidth;
          for (int x = 0; x <= mapWidth6; ++x)
          {
            int mapHeight = this.map.MapHeight;
            for (int y = 0; y <= mapHeight; ++y)
            {
              if (this.map.HexObj[x, y].AreaCode[this.game.Data.ActionCardObj[cardnr].AreaSlot] == this.game.Data.ActionCardObj[cardnr].AreaValue)
              {
                int num18 = 1000;
                if (num18 < 1)
                  num18 = 1;
                int num19 = num18 * 10;
                if (aiMatrix7.Value[x, y] >= 1)
                  num19 = (int) Math.Round((double) num19 * 0.3) + (int) Math.Round((double) num19 * 0.7 / (double) aiMatrix7.Value[x, y]);
                if (this.enemySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_MAXIMUM_RANGE)
                  num19 = (int) Math.Round((double) num19 * 1.75);
                else if (this.enemySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_75PERCENT_RANGE)
                  num19 = (int) Math.Round((double) num19 * 1.5);
                else if (this.enemySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_50PERCENT_RANGE)
                  num19 = (int) Math.Round((double) num19 * 1.25);
                else if (this.enemySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_25PERCENT_RANGE)
                  num19 = num19;
                int initialFrontID = aiMatrix1.Value[x, y];
                if (initialFrontID > 0)
                {
                  AIFront front = this.frontList.FindFront(initialFrontID);
                  if (!Information.IsNothing((object) front))
                  {
                    if (front.Stance == 1)
                      num19 *= 2;
                    else if (front.Stance == 4)
                      num19 = (int) Math.Round((double) num19 * 1.5);
                    else if (front.Stance == 3)
                      num19 *= 3;
                  }
                }
                int num20 = 0;
                int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
                for (int index = 0; index <= unitCounter; ++index)
                {
                  int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index];
                  if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.UnitObj[unit].Regime, this.game.Data.Turn))
                  {
                    int num21 = this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn);
                    if ((double) num21 >= (double) this.game.Data.RuleVar[55])
                    {
                      int num22 = 100 + this.GetAIRolePercent(unit, 10) * 6 + this.GetAIRolePercent(unit, 8) * 3 + (int) Math.Round((double) this.GetAIRolePercent(unit, 9) / 2.0);
                      ++num20;
                      num19 = (int) Math.Round((double) (num19 * num22) / 100.0);
                    }
                    else if (num21 >= 1)
                    {
                      int aiRolePercent1 = this.GetAIRolePercent(unit, 10);
                      int aiRolePercent2 = this.GetAIRolePercent(unit, 8);
                      int num23 = 100 + (int) Math.Round((double) aiRolePercent1 / 2.0) + (int) Math.Round((double) aiRolePercent2 / 2.0);
                      num19 = (int) Math.Round((double) (num19 * num23) / 100.0);
                      ++num20;
                    }
                  }
                }
                int num24;
                if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter == -1 | num20 == 0)
                {
                  num24 = 0;
                }
                else
                {
                  int hexStackPts = this.game.HandyFunctionsObj.GetHexStackPts(x, y, 0);
                  num24 = (int) Math.Round((double) num19 * 0.5) + (int) Math.Round((double) num19 * 0.5 * (double) hexStackPts / (double) this.game.Data.RuleVar[30]);
                }
                int hidePts = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].HidePts;
                if (hidePts > 0 & num24 > 0)
                {
                  int num25 = (int) Math.Round((double) hidePts * 1.33);
                  if (num25 > 100)
                    num25 = 100;
                  num24 = (int) Math.Round((double) num24 * 0.15) + (int) Math.Round((double) num24 * 0.85 * (double) (100 - num25) / 100.0);
                }
                int num26 = (int) Math.Round((double) num24 * 0.25) + (int) Math.Round((double) num24 * 0.75 * (double) DrawMod.RandyNumber.Next(0, 100) / 100.0);
                if (num26 > num17)
                {
                  num17 = num26;
                  x2_1 = x;
                  y2_1 = y;
                }
              }
            }
          }
        }
        if (num17 > 0)
        {
          this.game.EditObj.AreaX = x2_1;
          this.game.EditObj.AreaY = y2_1;
          s = s + "\r\n" + "PLAYED CARD!!!  target hex selected = " + this.game.EditObj.AreaX.ToString() + "," + this.game.EditObj.AreaY.ToString();
          this.game.ProcessingObj.PlayCard(this.game.Data.Turn, actionCardCounter);
          AIMatrix aiMatrix10 = aiMatrix9.Clone();
          int num27 = x2_1 - 6;
          int num28 = x2_1 + 6;
          for (int x1 = num27; x1 <= num28; ++x1)
          {
            int num29 = y2_1 - 6;
            int num30 = y2_1 + 6;
            for (int y1 = num29; y1 <= num30; ++y1)
            {
              if (x1 >= 0 & y1 >= 0 & x1 <= this.map.MapWidth & y1 <= this.map.MapHeight)
              {
                int num31 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2_1, y2_1, 0, 99);
                if (num31 <= 6)
                {
                  int[,] numArray29 = aiMatrix10.Value;
                  int[,] numArray30 = numArray29;
                  int index63 = x1;
                  int index64 = index63;
                  int index65 = y1;
                  int index66 = index65;
                  int num32 = numArray29[index63, index65] + (int) Math.Round((double) (7 - num31) * Math.Max(1.0, (double) (7 - num31) * 1.5));
                  numArray30[index64, index66] = num32;
                }
              }
            }
          }
          aiMatrix9 = aiMatrix10.Clone();
        }
      }
      int num33 = 9999;
      while (num33 > 0)
      {
        num33 = 0;
        int num34 = 0;
        int num35 = 0;
        SimpleList simpleList = new SimpleList();
        for (int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
        {
          int index = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[actionCardCounter];
          if (this.game.Data.ActionCardObj[index].AILabel == 2 & this.game.Data.ActionCardObj[index].AILabel2 >= 0 & this.game.Data.ActionCardObj[index].aILabel3 >= 0)
          {
            num35 += this.game.Data.ActionCardObj[index].PPCost;
            ++num34;
          }
        }
        if (num34 == 0)
          num34 = 1;
        int num36 = (int) Math.Round((double) num35 / (double) num34);
        for (int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
        {
          int tdata1 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[actionCardCounter];
          if (this.game.Data.ActionCardObj[tdata1].AILabel == 2 & this.game.Data.ActionCardObj[tdata1].AILabel2 >= 0 & this.game.Data.ActionCardObj[tdata1].aILabel3 >= 0)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[tdata1].PPCost)
            {
              int num37 = (int) Math.Round((double) (100 + this.GetPercentageOfModelRequiredForAllUnits2(this.game.Data.ActionCardObj[tdata1].AILabel2, this.game.Data.ActionCardObj[tdata1].aILabel3, 9999, 3)) * ((double) this.game.Data.ActionCardObj[tdata1].PPCost / (double) num36));
              int tweight = (double) VBMath.Rnd() <= 0.5 ? (int) Math.Round((double) num37 * 0.75) + (int) Math.Round((double) num37 * 0.25 * (double) VBMath.Rnd()) : (int) Math.Round((double) num37 * 0.2) + (int) Math.Round((double) num37 * 0.8 * (double) VBMath.Rnd());
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              int index = 0;
              while (index <= sfTypeCounter && (this.game.Data.SFTypeObj[index].ReinforcementType != this.game.Data.ActionCardObj[tdata1].AILabel2 || !(this.game.Data.SFTypeObj[index].CarryCap > 0 & this.game.Data.SFTypeObj[index].AIRoleScore[9] > 0)))
                ++index;
              if (index > -1 & index <= this.game.Data.SFTypeCounter)
                tweight = (int) Math.Round((double) tweight * 2.5);
              simpleList.Add(actionCardCounter, tweight, tdata1);
            }
          }
          else if (this.game.Data.ActionCardObj[tdata1].AILabel == 2 & this.game.Data.ActionCardObj[tdata1].AILabel2 <= 0 & this.game.Data.ActionCardObj[tdata1].aILabel3 <= 0 && this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[tdata1].PPCost)
          {
            int tweight = (int) Math.Round(100.0 * ((double) this.game.Data.ActionCardObj[tdata1].PPCost / (double) num36));
            simpleList.Add(actionCardCounter, tweight, tdata1);
          }
        }
        simpleList.Sort();
        if (simpleList.Counter > -1)
        {
          int cardinhandnr = simpleList.Id[simpleList.Counter];
          int index = simpleList.Data1[simpleList.Counter];
          num33 = 9999;
          s = s + "\r\n" + "PLAYED REPLACEMENT TROOPS CARD!!! : " + this.game.Data.ActionCardObj[index].Title;
          this.game.ProcessingObj.PlayCard(this.game.Data.Turn, cardinhandnr);
        }
      }
      this.ClearLog();
      this.AddLog(s);
      if (!flag)
        return;
      this.WriteLog("0150_regime_cards");
    }

    public void InitStrategicPlan(bool debugOverrule)
    {
      bool flag1 = false;
      if (debugOverrule)
        flag1 = true;
      AIMatrix owner = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      this.InitFrontlineSetUnitRatio(ref this.frontList, this.frontMatrix.Clone(), ref owner);
      AIMatrix aiMatrix1 = owner.Clone();
      aiMatrix1.RemoveValuesByMask(owner, 1);
      aiMatrix1.ExpandAndAddValueForAnyRegime(29);
      aiMatrix1.SetAllValuesSubtractWith(2);
      string strS = "0100a_Strategic Decisions\r\n" + "EMEGENCY MERGERS CHECK\r\n";
      if (true)
      {
        for (int counter1 = this.frontList.Counter; counter1 >= 0; counter1 += -1)
        {
          if (this.frontList.Front[counter1].FrontType == 1 & this.frontList.Front[counter1].FrontID < 1000000 & !this.frontList.Front[counter1].hasSupplySource && (double) this.frontList.Front[counter1].UnitCountRatio <= 0.27 & this.frontList.Front[counter1].retreatAverageScore <= 150)
          {
            SimpleList simpleList = new SimpleList();
            int counter2 = this.frontList.Counter;
            for (int tid = 0; tid <= counter2; ++tid)
            {
              if (this.frontList.Front[tid].FrontID == 1)
                tid = tid;
              if (this.frontList.Front[tid].FrontType == 1 & this.frontList.Front[tid].FrontID < 1000000 && counter1 != tid)
              {
                SimpleList neighbourFrontList = this.frontList.Front[tid].GetNeighbourFrontList();
                int counter3 = neighbourFrontList.Counter;
                for (int index1 = 0; index1 <= counter3; ++index1)
                {
                  if (neighbourFrontList.Id[index1] == this.frontList.Front[counter1].FrontID)
                  {
                    bool flag2 = false;
                    int num1 = 0;
                    int counter4 = this.frontList.Counter;
                    for (int index2 = 0; index2 <= counter4; ++index2)
                    {
                      if (this.frontList.Front[index2].FrontType == 2 && this.frontList.Front[index2].TargetFrontID == this.frontList.Front[tid].FrontID)
                        num1 += this.frontList.Front[index2].units.counter + 1;
                    }
                    if ((double) this.frontList.Front[counter1].UnitCountRatio <= 0.05 & (double) this.frontList.Front[tid].UnitCountRatio >= 0.2 & this.frontList.Front[tid].units.counter + num1 > 2)
                      flag2 = true;
                    if ((double) this.frontList.Front[counter1].UnitCountRatio <= 0.12 & (double) this.frontList.Front[tid].UnitCountRatio >= 0.35 & this.frontList.Front[tid].units.counter + num1 > 4)
                      flag2 = true;
                    if ((double) this.frontList.Front[counter1].UnitCountRatio <= 0.2 & (double) this.frontList.Front[tid].UnitCountRatio >= 0.7 & this.frontList.Front[tid].units.counter + num1 > 7)
                      flag2 = true;
                    if ((double) this.frontList.Front[counter1].UnitCountRatio <= 0.27 & (double) this.frontList.Front[tid].UnitCountRatio >= 1.5 & this.frontList.Front[tid].units.counter + num1 > 12)
                      flag2 = true;
                    if (this.game.Data.Product >= 7)
                    {
                      if (flag2 & this.frontList.Front[counter1].tempEnemyRegime != this.frontList.Front[tid].tempEnemyRegime)
                        flag2 = false;
                      else if (flag2 & this.frontList.Front[counter1].tempEnemyRegime2 != this.frontList.Front[tid].tempEnemyRegime2)
                        flag2 = false;
                    }
                    if (flag2)
                    {
                      int num2 = this.VAR_FRONTLINE_MAX_LENGTH;
                      if (this.game.Data.Product == 6)
                        num2 = (int) Math.Round((double) num2 * 1.33);
                      if (this.frontList.Front[counter1].FrontHexes + this.frontList.Front[counter1].FrontHexes <= 2 * num2)
                      {
                        int tweight = (int) Math.Round((double) ((float) (100 * this.frontList.Front[tid].FrontHexes) / this.frontList.Front[tid].UnitCountRatio));
                        simpleList.Add(tid, tweight);
                      }
                    }
                  }
                }
              }
            }
            if (simpleList.Counter > -1)
            {
              simpleList.Sort();
              int index3 = simpleList.Id[0];
              strS = strS + "*** Merging front " + this.frontList.Front[counter1].FrontID.ToString() + " into => " + this.frontList.Front[index3].FrontID.ToString() + "\r\n";
              int counter5 = this.frontList.Counter;
              for (int index4 = 0; index4 <= counter5; ++index4)
              {
                if (this.frontList.Front[index4].TargetFrontID == this.frontList.Front[counter1].FrontID)
                {
                  this.frontList.Front[index4].TargetFrontID = this.frontList.Front[index3].FrontID;
                  strS = strS + "*** Changing reserve" + this.frontList.Front[index4].FrontID.ToString() + " to new target => " + this.frontList.Front[index3].FrontID.ToString() + "\r\n";
                }
              }
              int unitCounter = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter; ++unr)
              {
                if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIGroup == this.frontList.Front[counter1].FrontID)
                {
                  this.game.Data.UnitObj[unr].AIGroup = this.frontList.Front[index3].FrontID;
                  this.frontList.Front[counter1].RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
                  this.frontList.Front[index3].AddUnit(unr);
                  strS = strS + "*** Changing unit " + this.game.Data.UnitObj[unr].Name + " to new AIGroup=> " + this.frontList.Front[index3].FrontID.ToString() + "\r\n";
                }
              }
              this.frontMatrix.SetValueXToValueY(this.frontList.Front[counter1].FrontID, this.frontList.Front[index3].FrontID);
              this.extendedMatrix.SetValueXToValueY(this.frontList.Front[counter1].FrontID, this.frontList.Front[index3].FrontID);
              this.frontList.Front[index3].retreatAverageScore = (int) Math.Round((double) (this.frontList.Front[counter1].retreatAverageScore + this.frontList.Front[index3].retreatAverageScore) / 2.0);
              AIFront[] front1 = this.frontList.Front;
              AIFront[] aiFrontArray1 = front1;
              int index5 = index3;
              int index6 = index5;
              aiFrontArray1[index6].bridgeCount = front1[index5].bridgeCount + this.frontList.Front[counter1].bridgeCount;
              AIFront[] front2 = this.frontList.Front;
              AIFront[] aiFrontArray2 = front2;
              int index7 = index3;
              int index8 = index7;
              aiFrontArray2[index8].enemyPower = front2[index7].enemyPower + this.frontList.Front[counter1].enemyPower;
              AIFront[] front3 = this.frontList.Front;
              AIFront[] aiFrontArray3 = front3;
              int index9 = index3;
              int index10 = index9;
              aiFrontArray3[index10].FrontHexes = front3[index9].FrontHexes + this.frontList.Front[counter1].FrontHexes;
              this.frontList.Front[index3].ThreatPercentage = Math.Max(this.frontList.Front[index3].ThreatPercentage, this.frontList.Front[counter1].ThreatPercentage);
              this.frontList.Front[index3].OpportunityPercentage = Math.Max(this.frontList.Front[index3].OpportunityPercentage, this.frontList.Front[counter1].OpportunityPercentage);
              this.frontList.Front[index3].vpScoreAveragePercent = (int) Math.Round((double) (this.frontList.Front[counter1].vpScoreAveragePercent + this.frontList.Front[index3].vpScoreAveragePercent) / 2.0);
              this.frontList.RemoveFront(this.frontList.Front[counter1].FrontID);
            }
          }
        }
        strS = strS + "\r\n" + "\r\n";
      }
      if (this.frontList.Counter == -1)
      {
        this.masterPlan = this.frontList.Clone();
      }
      else
      {
        this.InitFrontlineSetUnitRatio(ref this.frontList, this.frontMatrix.Clone(), ref owner);
        int counter6 = this.frontList.Counter;
        for (int index11 = 0; index11 <= counter6; ++index11)
        {
          if (this.frontList.Front[index11].FrontType == 1)
          {
            if (this.frontList.Front[index11].Strength == 1)
            {
              if (this.VAR_DISABLE_RETREAT_STANCE)
                this.frontList.Front[index11].Stance = 2;
              else if (this.frontList.Front[index11].retreatAverageScore <= 75)
              {
                this.frontList.Front[index11].Stance = 2;
              }
              else
              {
                this.frontList.Front[index11].Stance = 1;
                if (this.frontList.Front[index11].retreatAverageScore >= 200)
                  this.frontList.Front[index11].Stance = 4;
              }
            }
            else if (this.frontList.Front[index11].Strength == 2)
              this.frontList.Front[index11].Stance = this.frontList.Front[index11].retreatAverageScore < 250 ? 2 : 1;
            else if (this.frontList.Front[index11].Strength == 3)
              this.frontList.Front[index11].Stance = 3;
            else if (this.frontList.Front[index11].Strength == 4)
              this.frontList.Front[index11].Stance = 3;
            else if (this.frontList.Front[index11].Strength == 5)
              this.frontList.Front[index11].Stance = 3;
            this.frontList.Front[index11].StartStance = this.frontList.Front[index11].Stance;
          }
          this.frontList.Front[index11].OrigAverageStrength = this.frontList.Front[index11].AverageStrength;
          this.frontList.Front[index11].OrigPower = this.frontList.Front[index11].GetPowerUnderFront();
          this.frontList.Front[index11].PowerToReserve = 0;
          if (this.game.Data.Product < 6)
          {
            if (this.VAR_GARRISON_MIN_VP_ALWAYS > 0)
            {
              int mapWidth = this.map.MapWidth;
              for (int index12 = 0; index12 <= mapWidth; ++index12)
              {
                int mapHeight = this.map.MapHeight;
                for (int index13 = 0; index13 <= mapHeight; ++index13)
                {
                  if (this.GetRegime(this.map.HexObj[index12, index13].Regime) == this.GetGameDataTurn() & this.frontMatrix.Value[index12, index13] == this.frontList.Front[index11].FrontID && this.map.HexObj[index12, index13].VP >= this.VAR_GARRISON_MIN_VP_ALWAYS & (double) this.frontList.Front[index11].UnitCountRatio < 1.0 | this.map.HexObj[index12, index13].VP >= this.VAR_GARRISON_RULE2_MIN_VP & (double) this.frontList.Front[index11].UnitCountRatio < 0.66 & this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE > 0 | this.map.HexObj[index12, index13].VP >= this.VAR_GARRISON_RULE1_MIN_VP & (double) this.frontList.Front[index11].UnitCountRatio < 0.66 & this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE > 0 && this.frontList.Front[index11].Stance == 3)
                    this.frontList.Front[index11].Stance = 2;
                }
              }
            }
          }
          else if (this.game.Data.Product >= 6 && this.VAR_GARRISON_MIN_VP_ALWAYS > 0)
          {
            int mapWidth = this.map.MapWidth;
            for (int index14 = 0; index14 <= mapWidth; ++index14)
            {
              int mapHeight = this.map.MapHeight;
              for (int index15 = 0; index15 <= mapHeight; ++index15)
              {
                if (this.GetRegime(this.map.HexObj[index14, index15].Regime) == this.GetGameDataTurn() & this.frontMatrix.Value[index14, index15] == this.frontList.Front[index11].FrontID && this.map.HexObj[index14, index15].VP >= this.VAR_GARRISON_MIN_VP_ALWAYS & (double) this.frontList.Front[index11].UnitCountRatio < 0.6 | this.map.HexObj[index14, index15].VP >= this.VAR_GARRISON_RULE2_MIN_VP & (double) this.frontList.Front[index11].UnitCountRatio < 0.25 & this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE > 0 | this.map.HexObj[index14, index15].VP >= this.VAR_GARRISON_RULE1_MIN_VP & (double) this.frontList.Front[index11].UnitCountRatio < 0.1 & this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE > 0 && this.frontList.Front[index11].Stance == 3)
                {
                  this.frontList.Front[index11].Stance = 2;
                  strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio AND Important VP in Front\r\n";
                }
              }
            }
          }
          if (this.frontList.Front[index11].hasSupplySource)
          {
            if (this.frontList.Front[index11].Stance == 2)
            {
              this.frontList.Front[index11].Stance = 3;
              strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to ATTACK due to Supply Source Front\r\n";
            }
            else if (this.frontList.Front[index11].Stance != 2 & this.frontList.Front[index11].Stance != 3)
            {
              this.frontList.Front[index11].Stance = 2;
              strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to Supply Source Front\r\n";
            }
          }
          if (this.game.Data.Product >= 6)
          {
            if ((double) this.frontList.Front[index11].UnitCountRatio < 0.1)
            {
              if ((double) this.frontList.Front[index11].AverageStrength < 4.6 & this.frontList.Front[index11].Stance == 3)
              {
                this.frontList.Front[index11].Stance = 2;
                strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio.\r\n";
              }
            }
            else if ((double) this.frontList.Front[index11].UnitCountRatio < 0.2)
            {
              if ((double) this.frontList.Front[index11].AverageStrength < 4.3 & this.frontList.Front[index11].Stance == 3)
              {
                this.frontList.Front[index11].Stance = 2;
                strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio.\r\n";
              }
            }
            else if ((double) this.frontList.Front[index11].UnitCountRatio < 0.3)
            {
              if ((double) this.frontList.Front[index11].AverageStrength < 4.0 & this.frontList.Front[index11].Stance == 3)
              {
                this.frontList.Front[index11].Stance = 2;
                strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio.\r\n";
              }
            }
            else if ((double) this.frontList.Front[index11].UnitCountRatio < 0.4)
            {
              if ((double) this.frontList.Front[index11].AverageStrength < 3.5 & this.frontList.Front[index11].Stance == 3)
              {
                this.frontList.Front[index11].Stance = 2;
                strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio.\r\n";
              }
            }
            else if ((double) this.frontList.Front[index11].UnitCountRatio < 0.5)
            {
              if ((double) this.frontList.Front[index11].AverageStrength < 3.1 & this.frontList.Front[index11].Stance == 3)
              {
                this.frontList.Front[index11].Stance = 2;
                strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio.\r\n";
              }
            }
            else if ((double) this.frontList.Front[index11].UnitCountRatio < 0.75 && (double) this.frontList.Front[index11].AverageStrength < 2.66 & this.frontList.Front[index11].Stance == 3)
            {
              this.frontList.Front[index11].Stance = 2;
              strS = strS + this.frontList.Front[index11].FrontID.ToString() + " to HOLD due to low Unit Count Ratio.\r\n";
            }
          }
        }
        this.LogFronts("0160_finallll_before_strategic_sim");
        this.InitFrontlinesSetTopFrontlines(ref this.frontList, this.frontMatrix.Clone(), ref owner);
        AIMatrix aiMatrix2;
        if (this.game.Data.Product < 6)
        {
          ref AIFrontList local1 = ref this.frontList;
          aiMatrix2 = this.frontMatrix.Clone();
          ref AIMatrix local2 = ref aiMatrix2;
          this.ChangePanzersToTopFronts(ref local1, ref local2);
        }
        this.frontList.ResetStats();
        DC2AIClass tai = this;
        AIWorld aiWorld1 = new AIWorld(ref tai, this.frontList);
        this.SetEncircledFronts(ref this.frontList, ref aiWorld1, ref strS);
        SimpleList simpleList1;
        SimpleList tactionList;
        SimpleList simpleList2;
        if ((!this.VAR_USE_STRICT_HQFRONT | this.VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT) & this.CustomCalls.CustomDoStrategicIterations())
        {
          aiWorld1.CellularAutomatonStartXIterations(1);
          if (this.game.Data.Product < 6)
            aiWorld1.CellularAutomatonStartXIterations(Math.Max(this.VAR_CELLULAR_AUTOMATON_ITERATIONS - 1, 1));
          else
            aiWorld1.CellularAutomatonStartXIterations(Math.Max(this.VAR_CELLULAR_AUTOMATON_ITERATIONS, 1));
          if (this.VAR_DEBUG_ON)
            this.ScreenshotSpecial("0100b_FuturePredictions", ref aiWorld1.troops.Value, ref aiWorld1.owner.Value);
          bool flag3 = true;
          bool allowSSHQshuffle = true;
          while (flag3)
          {
            flag3 = false;
            simpleList1 = new SimpleList();
            int counter7 = this.frontList.Counter;
            for (int index = 0; index <= counter7; ++index)
            {
              if ((this.frontList.Front[index].StatAvgPercentageOutOfSupply >= 25 | this.frontList.Front[index].StatLastPercentageOutOfSupply > 40) & this.frontList.Front[index].FrontType == 1)
              {
                simpleList1.Add(this.frontList.Front[index].FrontID, this.frontList.Front[index].StatAvgPercentageOutOfSupply);
                strS = strS + this.frontList.Front[index].FrontID.ToString() + " is on encircled list.\r\n";
              }
            }
            tactionList = new SimpleList();
            int counter8 = simpleList1.Counter;
            for (int index16 = 0; index16 <= counter8; ++index16)
            {
              int frontNr1 = this.frontList.GetFrontNr(simpleList1.Id[index16]);
              if (!this.frontList.Front[frontNr1].hasSupplySource | !this.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE)
              {
                SimpleList neighbourFrontList = this.frontList.Front[frontNr1].GetNeighbourFrontList();
                if (neighbourFrontList.Counter > -1)
                {
                  int counter9 = neighbourFrontList.Counter;
                  for (int index17 = 0; index17 <= counter9; ++index17)
                  {
                    int frontNr2 = this.frontList.GetFrontNr(neighbourFrontList.Id[index17]);
                    if (simpleList1.FindNr(neighbourFrontList.Id[index17]) == -1 & this.frontList.Front[frontNr2].units.counter > -1)
                    {
                      if (this.frontList.Front[frontNr2].Stance == 1)
                        this.frontList.Front[frontNr2].Stance = 2;
                      if ((double) this.frontList.Front[frontNr2].AverageStrength < 2.25)
                      {
                        int nr = tactionList.FindNr(this.frontList.Front[frontNr2].FrontID);
                        strS = strS + this.frontList.Front[frontNr2].FrontID.ToString() + " is on action list for strengthening flank of encricleds\r\n";
                        if (nr == -1)
                        {
                          tactionList.Add(this.frontList.Front[frontNr2].FrontID, this.frontList.Front[frontNr1].StatAvgPercentageOutOfSupply, 1);
                        }
                        else
                        {
                          int[] weight = tactionList.Weight;
                          int[] numArray = weight;
                          int index18 = nr;
                          int index19 = index18;
                          int num = weight[index18] + this.frontList.Front[frontNr1].StatAvgPercentageOutOfSupply;
                          numArray[index19] = num;
                        }
                      }
                    }
                  }
                }
              }
            }
            if (this.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE)
            {
              int counter10 = simpleList1.Counter;
              for (int index20 = 0; index20 <= counter10; ++index20)
              {
                int frontNr = this.frontList.GetFrontNr(simpleList1.Id[index20]);
                if (this.frontList.Front[frontNr].hasSupplySource)
                {
                  int nr = tactionList.FindNr(this.frontList.Front[frontNr].FrontID);
                  strS = strS + this.frontList.Front[frontNr].FrontID.ToString() + " is on action list as a supply source in danger of overrun due to ENCIRCLE\r\n";
                  if (nr == -1)
                  {
                    tactionList.Add(this.frontList.Front[frontNr].FrontID, 300, 1);
                  }
                  else
                  {
                    int[] weight = tactionList.Weight;
                    int[] numArray = weight;
                    int index21 = nr;
                    int index22 = index21;
                    int num = weight[index21] + 300;
                    numArray[index22] = num;
                  }
                }
              }
              int counter11 = this.frontList.Counter;
              for (int index23 = 0; index23 <= counter11; ++index23)
              {
                if (this.frontList.Front[index23].hasSupplySource && simpleList1.FindNr(this.frontList.Front[index23].FrontID) == -1)
                {
                  int tweight = 0;
                  if (this.frontList.Front[index23].statsHexLeftPercentage < 50 & this.frontList.Front[index23].FrontType == 1)
                    tweight = 400;
                  else if (this.frontList.Front[index23].statsHexLeftPercentage < 65 & this.frontList.Front[index23].FrontType == 1)
                    tweight = 300;
                  else if (this.frontList.Front[index23].statsHexLeftPercentage < 74 & this.frontList.Front[index23].FrontType == 1)
                    tweight = 210;
                  else if (this.frontList.Front[index23].statsHexLeftPercentage < 83 & this.frontList.Front[index23].FrontType == 1)
                    tweight = 150;
                  else if (this.frontList.Front[index23].statsHexLeftPercentage < 92 & this.frontList.Front[index23].FrontType == 1)
                    tweight = 100;
                  else if (this.frontList.Front[index23].statsHexLeftPercentage < 98 & this.frontList.Front[index23].FrontType == 1)
                    tweight = 50;
                  if (tweight > 0)
                  {
                    int nr = tactionList.FindNr(this.frontList.Front[index23].FrontID);
                    strS = strS + this.frontList.Front[index23].FrontID.ToString() + " is on action list as a supply source in danger of overrun due to HEX LOSS (" + this.frontList.Front[index23].statsHexLeftPercentage.ToString() + ")\r\n";
                    if (nr == -1)
                    {
                      tactionList.Add(this.frontList.Front[index23].FrontID, tweight, 1);
                    }
                    else
                    {
                      int[] weight = tactionList.Weight;
                      int[] numArray = weight;
                      int index24 = nr;
                      int index25 = index24;
                      int num = weight[index24] + 300;
                      numArray[index25] = num;
                    }
                  }
                }
              }
            }
            int counter12 = tactionList.Counter;
            for (int index = 0; index <= counter12; ++index)
            {
              int frontNr = this.frontList.GetFrontNr(tactionList.Id[index]);
              tactionList.Weight[index] = (int) Math.Round((double) ((float) tactionList.Weight[index] / this.frontList.Front[frontNr].AverageStrength));
            }
            tactionList.ReverseSort();
            simpleList2 = tactionList.Clone();
            if (tactionList.Counter > -1)
            {
              SimpleList treservelist = new SimpleList();
              int counter13 = this.frontList.Counter;
              for (int index = 0; index <= counter13; ++index)
              {
                if ((this.frontList.Front[index].FrontType == 2 | this.frontList.Front[index].FrontType == 3) & this.frontList.Front[index].TargetFrontID == 0)
                {
                  strS = strS + this.frontList.Front[index].FrontID.ToString() + " is Reserve-Front and can thus be used for bringing up reserves.\r\n";
                  treservelist.Add(this.frontList.Front[index].FrontID, 100);
                }
                else if (this.frontList.Front[index].FrontType == 1 && tactionList.FindNr(this.frontList.Front[index].FrontID) == -1 && this.game.Data.Product < 6 | this.frontList.Front[index].OffensiveZone < 1 && (double) this.frontList.Front[index].OrigPower * 0.2 > (double) this.frontList.Front[index].PowerToReserve && this.frontList.Front[index].GetTransferableHisUnitsInUnitList() >= 2 && (double) this.frontList.Front[index].GetUnitAIIDToSplitOff(this.frontMatrix, this.frontList.Front[index].FrontID, this.frontList.Front[index], true) < (double) this.frontList.Front[index].GetPowerUnderFront(true) * 0.5 && (double) this.frontList.Front[index].OrigAverageStrength > 1.8)
                {
                  strS = strS + this.frontList.Front[index].FrontID.ToString() + " can be used to transfer reserves from.\r\n";
                  treservelist.Add(this.frontList.Front[index].FrontID, this.frontList.Front[index].GetTransferableHisUnitsInUnitList() * 10);
                }
              }
              if (treservelist.Counter > -1)
              {
                SimpleList actionList = this.AssignReservesToActionList(ref this.frontList, ref tactionList, ref treservelist, ref strS, allowSSHQshuffle);
                allowSSHQshuffle = false;
                int counter14 = actionList.Counter;
                for (int index = 0; index <= counter14; ++index)
                {
                  int initialFrontID = actionList.Id[index];
                  int num = actionList.Data1[index];
                  AIFront front4 = this.frontList.FindFront(initialFrontID);
                  if (front4.FrontType == 2 | front4.FrontType == 3)
                  {
                    AIFront front5 = this.frontList.FindFront(num);
                    int powerUnderFront = front4.GetPowerUnderFront();
                    int reservesAssignedToIt = this.frontList.GetPowerUnderFrontAndReservesAssignedToIt(num);
                    front5.AverageStrength = (float) ((double) (Math.Max(powerUnderFront, 1) + Math.Max(1, reservesAssignedToIt)) / (double) front5.enemyPower + 1.0);
                    front4.TargetFrontID = num;
                    front4.Importance = tactionList.Weight[tactionList.FindNr(num)];
                    strS = strS + "(avoid encircle) Reserve front " + front4.tempCreatedFromFrontID.ToString() + " is being delegated to " + front5.FrontID.ToString() + "\r\n";
                    flag3 = true;
                    break;
                  }
                  if (front4.FrontType == 1)
                  {
                    AIFront front6 = this.frontList.FindFront(num);
                    int reservesAssignedToIt = this.frontList.GetPowerUnderFrontAndReservesAssignedToIt(num);
                    ref AIFrontList local3 = ref this.frontList;
                    ref int local4 = ref initialFrontID;
                    ref int local5 = ref num;
                    aiMatrix2 = this.frontMatrix.Clone();
                    ref AIMatrix local6 = ref aiMatrix2;
                    int reserveFront = this.CreateReserveFront(ref local3, ref local4, ref local5, ref local6);
                    if (reserveFront > -1)
                    {
                      AIFront front7 = this.frontList.FindFront(reserveFront);
                      strS = strS + "(avoid encircle)" + front7.tempCreatedFromFrontID.ToString() + " is sending reserves to " + front6.FrontID.ToString() + "\r\n";
                      int powerUnderFront = front7.GetPowerUnderFront();
                      front6.AverageStrength = (float) ((double) (Math.Max(powerUnderFront, 1) + Math.Max(1, reservesAssignedToIt)) / (double) front6.enemyPower + 1.0);
                      front7.TargetFrontID = num;
                      front7.Importance = tactionList.Weight[tactionList.FindNr(num)];
                      flag3 = true;
                      break;
                    }
                  }
                }
              }
            }
          }
        }
        else
          simpleList1 = new SimpleList();
        tai = this;
        this.ProbablyOutOfSupply = new AIMatrix(ref tai);
        this.frontList.ResetStats();
        if (this.CustomCalls.CustomDoStrategicIterations())
        {
          tai = this;
          aiWorld1 = new AIWorld(ref tai, this.frontList, this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION);
          aiWorld1.CellularAutomatonStartXIterations(1);
          this.ScreenshotSpecial("0110_after_1st_iteration", ref aiWorld1.troops.Value, ref aiWorld1.owner.Value);
          tai = this;
          this.probableOwner = new AIMatrix(ref tai);
          int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
          for (int index26 = 0; index26 <= mapWidth1; ++index26)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index27 = 0; index27 <= mapHeight; ++index27)
            {
              this.ProbablyOutOfSupply.Value[index26, index27] = 0;
              this.probableOwner.Value[index26, index27] = 0;
            }
          }
          int counter15 = this.frontList.Counter;
          for (int index = 0; index <= counter15; ++index)
          {
            float num = (float) this.frontList.Front[index].enemyPower / (float) (1 + Math.Max(0, this.frontList.Front[index].OrigPower));
            if (this.frontList.Front[index].StatLastPercentageOutOfSupply >= 50 & !this.VAR_DISABLE_FULLRETREAT_STANCE && this.VAR_USE_STRICT_HQFRONT | simpleList1.FindNr(this.frontList.Front[index].FrontID) > -1 && this.frontList.Front[index].FrontID < 100000 & !this.frontList.Front[index].hasSupplySource)
            {
              this.frontList.Front[index].Stance = 4;
              this.frontList.Front[index].RealRetreat = true;
              strS = strS + this.frontList.Front[index].FrontID.ToString() + " is being put on FULL RETREAT (for 1 iteration predict)\r\n";
            }
            if (this.frontList.Front[index].StatLastPowerPercentageFullRun <= 70 & !this.VAR_DISABLE_FULLRETREAT_STANCE && (double) num > 0.5 | this.game.Data.Product < 6 && this.VAR_USE_STRICT_HQFRONT & this.frontList.Front[index].FrontType == 1 & this.frontList.Front[index].Stance != 4 && this.frontList.Front[index].FrontID < 100000 & !this.frontList.Front[index].hasSupplySource)
            {
              this.frontList.Front[index].Stance = 1;
              if (this.frontList.Front[index].StatLastPowerPercentageFullRun <= 60)
                this.frontList.Front[index].Stance = 4;
              strS = strS + this.frontList.Front[index].FrontID.ToString() + " is being put on (FULL)RETREAT (for 1 iteration predict and HIGH LOSSES based on RETR-modified)\r\n";
            }
            if (this.frontList.Front[index].statLastPowerPercentageRun1 <= 50 & !this.VAR_DISABLE_FULLRETREAT_STANCE && (double) num > 0.5 | this.game.Data.Product < 6 && this.VAR_USE_STRICT_HQFRONT & this.frontList.Front[index].FrontType == 1 && this.frontList.Front[index].FrontID < 100000 & !this.frontList.Front[index].hasSupplySource)
            {
              if (this.frontList.Front[index].Stance != 4)
                this.frontList.Front[index].Stance = 1;
              this.frontList.Front[index].RealRetreat = true;
              if (this.frontList.Front[index].statLastPowerPercentageRun1 <= 40)
                this.frontList.Front[index].Stance = 4;
              strS = strS + this.frontList.Front[index].FrontID.ToString() + " is being put on (FULL)RETREAT (for 1 iteration REAL LOSSES predict and HIGH LOSSES for RealRetreat)\r\n";
            }
          }
          if (flag1)
            this.LogFronts("0110_after_avoid_encircle_1iteration");
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index28 = 0; index28 <= mapWidth2; ++index28)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index29 = 0; index29 <= mapHeight; ++index29)
            {
              if (aiWorld1.friendlySupply.Value[index28, index29] > this.VAR_SUPPLY_MAXIMUM_RANGE)
              {
                int[,] numArray1 = this.ProbablyOutOfSupply.Value;
                int[,] numArray2 = numArray1;
                int index30 = index28;
                int index31 = index30;
                int index32 = index29;
                int index33 = index32;
                int num = numArray1[index30, index32] + 3;
                numArray2[index31, index33] = num;
              }
            }
          }
          aiWorld1.CellularAutomatonStartXIterations(1);
          this.ScreenshotSpecial("0110_after_2nd_iteration", ref aiWorld1.troops.Value, ref aiWorld1.owner.Value);
          int counter16 = this.frontList.Counter;
          for (int index = 0; index <= counter16; ++index)
          {
            float num = (float) this.frontList.Front[index].enemyPower / (float) (1 + Math.Max(0, this.frontList.Front[index].OrigPower));
            if (this.frontList.Front[index].StatLastPercentageOutOfSupply >= 65 & !this.VAR_DISABLE_FULLRETREAT_STANCE && (this.VAR_USE_STRICT_HQFRONT | simpleList1.FindNr(this.frontList.Front[index].FrontID) > -1) & this.frontList.Front[index].Stance != 4 && (double) num > 0.6 | this.game.Data.Product < 6 && this.frontList.Front[index].FrontID < 100000 & !this.frontList.Front[index].hasSupplySource && this.frontList.Front[index].retreatAverageScore >= 50)
            {
              this.frontList.Front[index].Stance = 4;
              this.frontList.Front[index].RealRetreat = true;
              strS = strS + this.frontList.Front[index].FrontID.ToString() + " is being put on FULL RETREAT (for 2 iteration predict)\r\n";
            }
          }
          if (flag1)
            this.LogFronts("0120_after_2iteration");
          int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
          for (int index34 = 0; index34 <= mapWidth3; ++index34)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index35 = 0; index35 <= mapHeight; ++index35)
            {
              if (aiWorld1.friendlySupply.Value[index34, index35] > this.VAR_SUPPLY_MAXIMUM_RANGE)
              {
                int[,] numArray3 = this.ProbablyOutOfSupply.Value;
                int[,] numArray4 = numArray3;
                int index36 = index34;
                int index37 = index36;
                int index38 = index35;
                int index39 = index38;
                int num = numArray3[index36, index38] + 2;
                numArray4[index37, index39] = num;
              }
              this.probableOwner.Value[index34, index35] = aiWorld1.owner.Value[index34, index35];
            }
          }
          aiWorld1.CellularAutomatonStartXIterations(Math.Max(this.VAR_CELLULAR_AUTOMATON_ITERATIONS - 2, 2));
          if (this.VAR_DEBUG_ON)
            this.ScreenshotSpecial("0120b_FuturePredictionsAfterAvoidEncircle", ref aiWorld1.troops.Value, ref aiWorld1.owner.Value);
          int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
          for (int index40 = 0; index40 <= mapWidth4; ++index40)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index41 = 0; index41 <= mapHeight; ++index41)
            {
              if (aiWorld1.friendlySupply.Value[index40, index41] > this.VAR_SUPPLY_MAXIMUM_RANGE)
              {
                int[,] numArray5 = this.ProbablyOutOfSupply.Value;
                int[,] numArray6 = numArray5;
                int index42 = index40;
                int index43 = index42;
                int index44 = index41;
                int index45 = index44;
                int num = numArray5[index42, index44] + 1;
                numArray6[index43, index45] = num;
              }
            }
          }
          int counter17 = this.frontList.Counter;
          for (int index = 0; index <= counter17; ++index)
          {
            float num = (float) this.frontList.Front[index].enemyPower / (float) (1 + Math.Max(0, this.frontList.Front[index].OrigPower));
            if (this.frontList.Front[index].StatLastPercentageOutOfSupply >= 80 & !this.VAR_DISABLE_FULLRETREAT_STANCE && (this.VAR_USE_STRICT_HQFRONT | simpleList1.FindNr(this.frontList.Front[index].FrontID) > -1) & this.frontList.Front[index].Stance != 4 && this.frontList.Front[index].FrontID < 100000 & !this.frontList.Front[index].hasSupplySource && (double) num > 0.7 & this.frontList.Front[index].statsHexLeftPercentage > 80 | this.game.Data.Product < 6 && this.frontList.Front[index].retreatAverageScore >= 50)
            {
              this.frontList.Front[index].Stance = 4;
              this.frontList.Front[index].RealRetreat = true;
              strS = strS + this.frontList.Front[index].FrontID.ToString() + " is being put on FULL RETREAT (for 4 iteration predict)\r\n";
            }
          }
          if (flag1)
            this.LogFronts("0130_after_avoid_encircle_4iteration");
        }
        int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
        for (int index46 = 0; index46 <= mapWidth5; ++index46)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index47 = 0; index47 <= mapHeight; ++index47)
          {
            if (aiWorld1.owner.Value[index46, index47] == 1)
              aiMatrix1.Value[index46, index47] = 0;
          }
        }
        this.probableEnemyPenetration = aiMatrix1.Clone();
        if ((!this.VAR_USE_STRICT_HQFRONT | this.VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT) & this.CustomCalls.CustomDoStrategicIterations())
        {
          int counter18 = this.frontList.Counter;
          int num3;
          for (int index = 0; index <= counter18; ++index)
            num3 += this.frontList.Front[index].GetPowerUnderFront();
          int num4 = (int) Math.Round((double) num3 / (double) this.frontList.Counter);
          this.frontList.ResetStats();
          tai = this;
          aiWorld1 = new AIWorld(ref tai, this.frontList);
          aiWorld1.frontline.ExpandValueForAnyRegime();
          SimpleList simpleList3 = new SimpleList();
          SimpleList simpleList4 = new SimpleList();
          SimpleList simpleList5 = new SimpleList();
          this.frontList.ResetStats();
          tai = this;
          AIWorld world2_1 = new AIWorld(ref tai, this.frontList);
          world2_1.frontline.ExpandValueForAnyRegime();
          world2_1.CellularAutomatonStartXIterations(1);
          AIWorld aiWorld2 = world2_1.Clone();
          world2_1.CellularAutomatonStartXIterations(Math.Max(1, this.VAR_CELLULAR_AUTOMATON_ITERATIONS - 1));
          world2_1.frontline.ExpandValueForAnyRegime();
          SimpleList listOfVpChanges1 = this.GetListOfVPChanges(ref this.frontList, ref aiWorld1, ref world2_1, worldFirstRound: (ref aiWorld2));
          listOfVpChanges1.ReverseSort();
          for (int counter19 = listOfVpChanges1.Counter; counter19 >= 0; counter19 += -1)
          {
            if (listOfVpChanges1.Weight[counter19] < 1)
              listOfVpChanges1.RemoveNr(counter19);
          }
          int num5 = 0;
          int num6 = 0;
          int num7 = 0;
          int num8 = 0;
          int val2 = 0;
          int mapWidth6 = this.map.MapWidth;
          for (int index48 = 0; index48 <= mapWidth6; ++index48)
          {
            int mapHeight = this.map.MapHeight;
            for (int index49 = 0; index49 <= mapHeight; ++index49)
            {
              if (world2_1.owner.Value[index48, index49] == 1)
                num5 += this.map.HexObj[index48, index49].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index48, index49];
              if (aiWorld1.owner.Value[index48, index49] == 1 && this.map.HexObj[index48, index49].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index48, index49] > 0)
              {
                num7 += this.map.HexObj[index48, index49].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index48, index49];
                ++val2;
                num6 += this.map.HexObj[index48, index49].VP;
                if (this.map.HexObj[index48, index49].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index48, index49] > num8)
                  num8 = this.map.HexObj[index48, index49].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index48, index49];
              }
            }
          }
          int tweight = (int) Math.Round((double) num7 / (double) Math.Max(1, val2));
          this.frontList.ResetStats();
          tai = this;
          AIWorld world2_2 = new AIWorld(ref tai, this.frontList, ModifyForUnitRatio: true);
          world2_2.frontline.ExpandValueForAnyRegime();
          world2_2.CellularAutomatonStartXIterations(1);
          AIWorld aiWorld3 = world2_2.Clone();
          world2_2.CellularAutomatonStartXIterations(Math.Max(this.VAR_CELLULAR_AUTOMATON_ITERATIONS - 1, 1));
          world2_2.frontline.ExpandValueForAnyRegime();
          SimpleList listOfVpChanges2 = this.GetListOfVPChanges(ref this.frontList, ref aiWorld1, ref world2_2, worldFirstRound: (ref aiWorld3));
          listOfVpChanges2.Sort();
          for (int counter20 = listOfVpChanges2.Counter; counter20 >= 0; counter20 += -1)
          {
            if (listOfVpChanges2.Data3[counter20] < 0)
            {
              int[] weight = listOfVpChanges2.Weight;
              int[] numArray = weight;
              int index50 = counter20;
              int index51 = index50;
              int num9 = weight[index50] + 2 * listOfVpChanges2.Data3[counter20];
              numArray[index51] = num9;
            }
            if (listOfVpChanges2.Weight[counter20] >= 0)
              listOfVpChanges2.RemoveNr(counter20);
          }
          tactionList = new SimpleList();
          int counter21 = listOfVpChanges1.Counter;
          for (int index = 0; index <= counter21; ++index)
          {
            if (this.frontList.GetFrontNr(listOfVpChanges1.Id[index]) > -1)
              tactionList.Add(listOfVpChanges1.Id[index], Math.Abs(listOfVpChanges1.Weight[index]));
          }
          int counter22 = listOfVpChanges2.Counter;
          for (int index52 = 0; index52 <= counter22; ++index52)
          {
            int nr = tactionList.FindNr(listOfVpChanges2.Id[index52]);
            if (nr == -1)
            {
              if (this.frontList.GetFrontNr(listOfVpChanges2.Id[index52]) > -1)
                tactionList.Add(listOfVpChanges2.Id[index52], Math.Abs(listOfVpChanges2.Weight[index52]));
            }
            else
            {
              int[] weight = tactionList.Weight;
              int[] numArray = weight;
              int index53 = nr;
              int index54 = index53;
              int num10 = weight[index53] + Math.Abs(listOfVpChanges2.Weight[index52]);
              numArray[index54] = num10;
            }
          }
          int counter23 = this.frontList.Counter;
          for (int index55 = 0; index55 <= counter23; ++index55)
          {
            if (this.frontList.Front[index55].FrontType == 1 & this.frontList.Front[index55].units.counter == -1)
            {
              int nr = tactionList.FindNr(this.frontList.Front[index55].FrontID);
              if (nr == -1)
              {
                if (this.frontList.GetFrontNr(this.frontList.Front[index55].FrontID) > -1)
                  tactionList.Add(this.frontList.Front[index55].FrontID, tweight);
              }
              else
              {
                int[] weight = tactionList.Weight;
                int[] numArray = weight;
                int index56 = nr;
                int index57 = index56;
                int num11 = weight[index56] + tweight;
                numArray[index57] = num11;
              }
            }
          }
          int counter24 = tactionList.Counter;
          for (int index58 = 0; index58 <= counter24; ++index58)
          {
            int frontNr = this.frontList.GetFrontNr(tactionList.Id[index58]);
            int[] weight1 = tactionList.Weight;
            int[] numArray7 = weight1;
            int index59 = index58;
            int index60 = index59;
            int num12 = weight1[index59] * 10;
            numArray7[index60] = num12;
            tactionList.Weight[index58] = (int) Math.Round((double) ((float) tactionList.Weight[index58] / this.frontList.Front[frontNr].AverageStrength));
            if (this.frontList.Front[frontNr].units.counter == -1)
            {
              int[] weight2 = tactionList.Weight;
              int[] numArray8 = weight2;
              int index61 = index58;
              int index62 = index61;
              int num13 = weight2[index61] * 2;
              numArray8[index62] = num13;
            }
          }
          tactionList.ReverseSort();
          bool flag4 = true;
          bool allowSSHQshuffle = true;
          while (flag4)
          {
            flag4 = false;
            SimpleList treservelist = new SimpleList();
            int counter25 = this.frontList.Counter;
            for (int index = 0; index <= counter25; ++index)
            {
              if ((this.frontList.Front[index].FrontType == 2 | this.frontList.Front[index].FrontType == 3) & this.frontList.Front[index].TargetFrontID == 0)
                treservelist.Add(this.frontList.Front[index].FrontID, 100);
              else if (this.frontList.Front[index].FrontType == 1 & this.frontList.Front[index].DefensiveZone < 1 && simpleList2.FindNr(this.frontList.Front[index].FrontID) == -1 && this.game.Data.Product < 6 | this.frontList.Front[index].OffensiveZone < 1 && (double) this.frontList.Front[index].OrigPower * 0.2 > (double) this.frontList.Front[index].PowerToReserve && (double) this.frontList.Front[index].GetTransferableHisUnitsInUnitList() >= 1.5 && (double) this.frontList.Front[index].GetUnitAIIDToSplitOff(this.frontMatrix, this.frontList.Front[index].FrontID, this.frontList.Front[index], true) < (double) this.frontList.Front[index].GetPowerUnderFront(true) * 0.5 && (double) this.frontList.Front[index].OrigAverageStrength >= 1.0)
              {
                strS = strS + this.frontList.Front[index].FrontID.ToString() + " is eligeble for sending reserves for (take/hold) operations.\r\n";
                treservelist.Add(this.frontList.Front[index].FrontID, this.frontList.Front[index].GetTransferableHisUnitsInUnitList() * 10);
              }
            }
            if (treservelist.Counter > -1)
            {
              SimpleList actionList = this.AssignReservesToActionList(ref this.frontList, ref tactionList, ref treservelist, ref strS, allowSSHQshuffle);
              allowSSHQshuffle = false;
              int counter26 = actionList.Counter;
              for (int index = 0; index <= counter26; ++index)
              {
                int initialFrontID = actionList.Id[index];
                int num14 = actionList.Data1[index];
                AIFront front8 = this.frontList.FindFront(initialFrontID);
                if (front8.FrontType == 2 | front8.FrontType == 3)
                {
                  AIFront front9 = this.frontList.FindFront(num14);
                  int powerUnderFront = front8.GetPowerUnderFront();
                  int reservesAssignedToIt = this.frontList.GetPowerUnderFrontAndReservesAssignedToIt(num14);
                  front9.AverageStrength = (float) ((double) (Math.Max(powerUnderFront, 1) + Math.Max(1, reservesAssignedToIt)) / (double) front9.enemyPower + 1.0);
                  front8.TargetFrontID = num14;
                  strS = strS + "(Take/Hold action) Reserve front " + front8.tempCreatedFromFrontID.ToString() + " is being delegated to " + front9.FrontID.ToString() + "\r\n";
                  front8.Importance = tactionList.Weight[tactionList.FindNr(num14)];
                  flag4 = true;
                  break;
                }
                if (front8.FrontType == 1)
                {
                  AIFront front10 = this.frontList.FindFront(num14);
                  int reservesAssignedToIt = this.frontList.GetPowerUnderFrontAndReservesAssignedToIt(num14);
                  ref AIFrontList local7 = ref this.frontList;
                  ref int local8 = ref initialFrontID;
                  ref int local9 = ref num14;
                  aiMatrix2 = this.frontMatrix.Clone();
                  ref AIMatrix local10 = ref aiMatrix2;
                  int reserveFront = this.CreateReserveFront(ref local7, ref local8, ref local9, ref local10);
                  if (reserveFront > -1)
                  {
                    AIFront front11 = this.frontList.FindFront(reserveFront);
                    int powerUnderFront = front11.GetPowerUnderFront();
                    front10.AverageStrength = (float) ((double) (Math.Max(powerUnderFront, 1) + Math.Max(1, reservesAssignedToIt)) / (double) front10.enemyPower + 1.0);
                    front11.TargetFrontID = num14;
                    strS = strS + "(Take/Hold action) " + front11.tempCreatedFromFrontID.ToString() + " is sending reserves to " + front10.FrontID.ToString() + "\r\n";
                    front11.Importance = tactionList.Weight[tactionList.FindNr(num14)];
                    flag4 = true;
                    break;
                  }
                }
              }
            }
          }
          if (flag1)
            this.LogFronts("0150_before_allresassign");
          if (num6 <= this.VAR_VP_AT_DEFEAT & this.VAR_VP_AT_DEFEAT > 0)
          {
            int counter27 = this.frontList.Counter;
            for (int index63 = 0; index63 <= counter27; ++index63)
            {
              int num15 = 0;
              int mapWidth7 = this.map.MapWidth;
              for (int index64 = 0; index64 <= mapWidth7; ++index64)
              {
                int mapHeight = this.map.MapHeight;
                for (int index65 = 0; index65 <= mapHeight; ++index65)
                {
                  if (aiWorld1.owner.Value[index64, index65] == 1 && this.map.HexObj[index64, index65].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index64, index65] > num15 & this.frontMatrix.Value[index64, index65] == this.frontList.Front[index63].FrontID)
                    num15 = this.map.HexObj[index64, index65].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index64, index65];
                }
              }
              if (num15 > 0 & this.frontList.Front[index63].Stance == 4 | this.frontList.Front[index63].Stance == 1)
              {
                this.frontList.Front[index63].Stance = 2;
                strS = strS + this.frontList.Front[index63].FrontID.ToString() + " is being put on HOLD since retreat on verge of defeat is not an option.\r\n";
              }
            }
          }
          int counter28 = this.frontList.Counter;
          for (int index66 = 0; index66 <= counter28; ++index66)
          {
            int num16 = 0;
            int mapWidth8 = this.map.MapWidth;
            for (int index67 = 0; index67 <= mapWidth8; ++index67)
            {
              int mapHeight = this.map.MapHeight;
              for (int index68 = 0; index68 <= mapHeight; ++index68)
              {
                if (aiWorld1.owner.Value[index67, index68] == 1 && this.map.HexObj[index67, index68].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index67, index68] > num16 & this.frontMatrix.Value[index67, index68] == this.frontList.Front[index66].FrontID)
                  num16 = this.map.HexObj[index67, index68].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index67, index68];
              }
            }
            if (this.frontList.Front[index66].Stance == 4 | this.frontList.Front[index66].Stance == 1 && num16 >= (int) Math.Round((double) (tweight + num8) / 3.0))
            {
              this.frontList.Front[index66].Stance = 2;
              strS = strS + this.frontList.Front[index66].FrontID.ToString() + " is being put on HOLD since its a really big and important place this front is defending.\r\n";
            }
          }
        }
        int counter29 = this.frontList.Counter;
        for (int index69 = 0; index69 <= counter29; ++index69)
        {
          if (this.frontList.Front[index69].Stance != 4 && this.frontList.Front[index69].FrontID < 100000 & this.frontList.Front[index69].FrontType == 1)
          {
            SimpleList neighbourFrontList = this.frontList.Front[index69].GetNeighbourFrontList();
            int num17 = 0;
            int num18 = 0;
            int counter30 = neighbourFrontList.Counter;
            for (int index70 = 0; index70 <= counter30; ++index70)
            {
              int frontNr = this.frontList.GetFrontNr(neighbourFrontList.Id[index70]);
              if (index69 != frontNr)
              {
                ++num17;
                if (this.frontList.Front[frontNr].Stance == 4 | this.frontList.Front[frontNr].statLastPowerPercentageRun1 <= 10)
                  ++num18;
              }
            }
            bool flag5 = this.frontList.Front[index69].HasFriendlyZeroBorder();
            if (this.frontList.Front[index69].vpScoreAveragePercent < 33 & (double) this.frontList.Front[index69].UnitCountRatio < 1.66 && this.frontList.Front[index69].Stance != 4 && (num17 > 0 & !flag5 | num17 > 1 & flag5) & num17 == num18)
            {
              this.frontList.Front[index69].Stance = 4;
              this.frontList.Front[index69].RealRetreat = true;
              strS = strS + "Due to no solid neighbours left... Set to FULL RETREAT: front #" + this.frontList.Front[index69].FrontID.ToString() + "\r\n";
            }
            if (num17 == 0 && this.frontList.Front[index69].Stance == 1 & !flag5)
            {
              this.frontList.Front[index69].Stance = 2;
              strS = strS + "Due to being an isolated front (like Riga).. Set to HOLD instead of RETREAT: front #" + this.frontList.Front[index69].FrontID.ToString() + "\r\n";
            }
          }
        }
        int counter31 = this.frontList.Counter;
        for (int index = 0; index <= counter31; ++index)
        {
          if (this.frontList.Front[index].TargetFrontID > 0)
          {
            int frontNr = this.frontList.GetFrontNr(this.frontList.Front[index].TargetFrontID);
            if (frontNr > -1 && this.frontList.Front[frontNr].FrontType == 12)
            {
              Coordinate averageFrontCoordinate1 = this.frontList.Front[frontNr].GetAverageFrontCoordinate();
              Coordinate averageFrontCoordinate2 = this.frontList.Front[index].GetAverageFrontCoordinate();
              if (averageFrontCoordinate1.onmap & averageFrontCoordinate2.onmap && this.game.HandyFunctionsObj.Distance(averageFrontCoordinate1.x, averageFrontCoordinate1.y, 0, averageFrontCoordinate2.x, averageFrontCoordinate2.y, 0) < 8)
              {
                this.frontList.Front[index].TargetFrontID = -1;
                strS = strS + "(Reserve freed from assignment to escape front # " + this.frontList.Front[frontNr].FrontID.ToString() + ") Freed up: reservere front #" + this.frontList.Front[index].FrontID.ToString() + "\r\n";
              }
            }
          }
        }
        this.AssignReserveFronts(ref this.frontList, 4, 2);
        this.AssignReserveFronts(ref this.frontList, 4, 13);
        this.AssignReserveFronts(ref this.frontList, 3, 3, 18);
        this.AssignReserveFronts(ref this.frontList, 2, 3, 13);
        this.AssignReserveFronts(ref this.frontList, 4, 3, 11);
        this.AssignReserveFronts(ref this.frontList, 5, 3, 8);
        this.AssignReserveFronts(ref this.frontList, 4, 3, 9999);
        this.AssignReserveFronts(ref this.frontList, 4, 3);
        this.AssignAirCoverFronts(ref this.frontList);
        this.AssignAirSupportFronts(ref this.frontList);
        this.AssignAirTransportFronts(ref this.frontList);
        this.AssignNavyAndCargoFronts(ref this.frontList);
        this.frontList.ResetStats();
        this.InitFrontlinesOffensiveModifier(ref this.frontList);
        this.masterPlan = this.frontList.Clone();
        this.CheckIfEncircledFrontsWantToEscape(ref strS);
        if (this.game.Data.Product == 6)
          this.RejoinEncircled(ref this.masterPlan, ref aiWorld1, ref strS);
        this.frontList = this.masterPlan;
        if (flag1)
          this.LogFronts("0160_finallll");
        this.ClearLog();
        this.AddLog(strS);
        if (!flag1)
          return;
        this.WriteLog("0170_strategic_decisions_made");
      }
    }

    public void RejoinEncircled(ref AIFrontList masterplan, ref AIWorld world, ref string strS)
    {
      for (int counter1 = masterplan.Counter; counter1 >= 0; counter1 += -1)
      {
        AIFront aiFront = masterplan.Front[counter1];
        if (aiFront.FrontType == 12 & aiFront.units.counter > -1)
        {
          DC2AIClass tai = this;
          AIMatrix aiMatrix = new AIMatrix(ref tai);
          int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
          for (int index1 = 0; index1 <= mapWidth1; ++index1)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index2 = 0; index2 <= mapHeight; ++index2)
            {
              aiMatrix.Value[index1, index2] = 0;
              if (this.frontMatrix.Value[index1, index2] == aiFront.FrontID)
                aiMatrix.Value[index1, index2] = 1;
            }
          }
          aiMatrix.ExpandAndAddValueForAnyRegime(5, true);
          SimpleList simpleList = new SimpleList();
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index3 = 0; index3 <= mapWidth2; ++index3)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index4 = 0; index4 <= mapHeight; ++index4)
            {
              if (aiMatrix.Value[index3, index4] > 1)
              {
                int tdata1 = aiMatrix.Value[index3, index4];
                if (this.frontMatrix.Value[index3, index4] > 0 && this.frontMatrix.Value[index3, index4] != aiFront.FrontID)
                {
                  if (simpleList.FindNr(this.frontMatrix.Value[index3, index4]) == -1)
                  {
                    AIFront front = masterplan.FindFront(this.frontMatrix.Value[index3, index4]);
                    if (!Information.IsNothing((object) front))
                    {
                      int tweight = 0;
                      if (front.Stance == 3 & tdata1 <= 5 | front.Stance == 2 & tdata1 <= 2 & (double) front.OrigAverageStrength >= 2.75)
                      {
                        int counter2 = aiFront.units.counter;
                        for (int index5 = 0; index5 <= counter2; ++index5)
                        {
                          int index6 = aiFront.units.unr[index5];
                          int counter3 = front.units.counter;
                          for (int index7 = 0; index7 <= counter3; ++index7)
                          {
                            int index8 = front.units.unr[index7];
                            if (this.game.Data.UnitObj[index6].HQ == this.game.Data.UnitObj[index8].HQ)
                            {
                              tweight += 10;
                              if (this.game.Data.UnitObj[index6].AISubStrictGroup == this.game.Data.UnitObj[index8].AISubStrictGroup)
                                tweight += 20;
                            }
                          }
                        }
                        if (front.Stance == 3)
                          tweight *= 2;
                      }
                      simpleList.Add(front.FrontID, tweight, tdata1);
                    }
                  }
                  else
                  {
                    int nr = simpleList.FindNr(this.frontMatrix.Value[index3, index4]);
                    if (nr > -1 && simpleList.Data1[nr] > tdata1)
                      simpleList.Data1[nr] = tdata1;
                  }
                }
              }
            }
          }
          if (simpleList.Counter > -1)
          {
            int counter4 = simpleList.Counter;
            for (int index = 0; index <= counter4; ++index)
              simpleList.Weight[index] = (int) Math.Round((double) (simpleList.Weight[index] * 10) / (double) simpleList.Data1[index]);
            simpleList.ReverseSort();
            if (simpleList.Weight[0] > 0)
            {
              AIFront front = masterplan.FindFront(simpleList.Id[0]);
              if (!Information.IsNothing((object) front))
              {
                strS = strS + "== Joining encircled front " + aiFront.FrontID.ToString() + " to hold/attack front " + simpleList.Id[0].ToString() + "\r\n";
                int counter5 = aiFront.units.counter;
                for (int index = 0; index <= counter5; ++index)
                {
                  int tunr = aiFront.units.unr[index];
                  this.game.Data.UnitObj[tunr].AIGroup = simpleList.Id[0];
                  front.units.add(tunr, aiFront.units.AIid[index]);
                  aiFront.units.removeAiId(aiFront.units.AIid[index]);
                  this.frontMatrix.SetValueXToValueY(aiFront.FrontID, front.FrontID);
                  this.extendedMatrix.SetValueXToValueY(aiFront.FrontID, front.FrontID);
                  this.frontlinesMatrix.SetValueXToValueY(aiFront.FrontID, front.FrontID);
                }
                masterplan.RemoveFront(aiFront.FrontID);
              }
            }
          }
        }
      }
    }

    public void SetEncircledFronts(ref AIFrontList masterPlan, ref AIWorld world, ref string strS)
    {
      int counter1 = masterPlan.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront = masterPlan.Front[index1];
        int num1 = 0;
        int num2 = 0;
        int counter2 = aiFront.units.counter;
        for (int index2 = 0; index2 <= counter2; ++index2)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index2]);
          if (unitByAiid > -1)
          {
            int x = this.game.Data.UnitObj[unitByAiid].X;
            int y = this.game.Data.UnitObj[unitByAiid].Y;
            if (world.friendlySupply.Value[x, y] <= this.VAR_SUPPLY_MAXIMUM_RANGE)
              num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
            num2 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
          }
        }
        int counter3 = aiFront.artUnits.counter;
        for (int index3 = 0; index3 <= counter3; ++index3)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.artUnits.AIid[index3]);
          if (unitByAiid > -1)
          {
            int x = this.game.Data.UnitObj[unitByAiid].X;
            int y = this.game.Data.UnitObj[unitByAiid].Y;
            if (world.friendlySupply.Value[x, y] <= this.VAR_SUPPLY_MAXIMUM_RANGE)
              num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
            num2 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
          }
        }
        int counter4 = aiFront.orgUnits.counter;
        for (int index4 = 0; index4 <= counter4; ++index4)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.orgUnits.AIid[index4]);
          if (unitByAiid > -1)
          {
            int x = this.game.Data.UnitObj[unitByAiid].X;
            int y = this.game.Data.UnitObj[unitByAiid].Y;
            if (world.friendlySupply.Value[x, y] <= this.VAR_SUPPLY_MAXIMUM_RANGE)
              num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
            num2 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
          }
        }
        if (num2 > 0 && (int) Math.Round((double) (num1 * 100) / (double) num2) < 40)
        {
          aiFront.FrontType = 11;
          strS = strS + aiFront.FrontID.ToString() + " to ENCIRCLED due to SetEncircledFronts() <40% not in supply.\r\n";
          aiFront.TopOperation = false;
          int counter5 = aiFront.artUnits.counter;
          for (int index5 = 0; index5 <= counter5; ++index5)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.artUnits.AIid[index5]);
            if (unitByAiid > -1)
            {
              aiFront.artUnits.removeUnr(unitByAiid);
              aiFront.units.add(unitByAiid, this.game.Data.UnitObj[unitByAiid].AIid);
            }
          }
          int counter6 = aiFront.orgUnits.counter;
          for (int index6 = 0; index6 <= counter6; ++index6)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.orgUnits.AIid[index6]);
            if (unitByAiid > -1)
            {
              aiFront.orgUnits.removeUnr(unitByAiid);
              aiFront.units.add(unitByAiid, this.game.Data.UnitObj[unitByAiid].AIid);
            }
          }
        }
      }
    }

    public void CheckIfEncircledFrontsWantToEscape(ref string strS)
    {
      AIMatrix aiMatrix1 = this.frontlinesMatrix.Clone();
      aiMatrix1.ExpandAndAddValueForSameRegime(19);
      int counter = this.masterPlan.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        AIFront aiFront = this.masterPlan.Front[index1];
        int num = -1;
        if (aiFront.FrontType == 11 & aiFront.units.counter > -1)
        {
          DC2AIClass tai = this;
          AIMatrix aiMatrix2 = new AIMatrix(ref tai, this.map.MapWidth, this.map.MapHeight, 0, 0);
          aiMatrix2.SetAllValuesTo(0);
          int mapWidth1 = this.map.MapWidth;
          for (int index2 = 0; index2 <= mapWidth1; ++index2)
          {
            int mapHeight = this.map.MapHeight;
            for (int index3 = 0; index3 <= mapHeight; ++index3)
            {
              if (aiMatrix1.Value[index2, index3] == aiFront.FrontID)
                aiMatrix2.Value[index2, index3] = 1;
            }
          }
          aiMatrix2.ExpandAndAddValueForSameRegime(19);
          int mapWidth2 = this.map.MapWidth;
          for (int index4 = 0; index4 <= mapWidth2; ++index4)
          {
            int mapHeight = this.map.MapHeight;
            for (int index5 = 0; index5 <= mapHeight; ++index5)
            {
              if (aiMatrix2.Value[index4, index5] > 0 && this.map.HexObj[index4, index5].VP > num)
                num = this.map.HexObj[index4, index5].VP;
            }
          }
          if (num > -1)
          {
            if (!(num >= this.VAR_FORTRESSMODE_MIN_VP & this.VAR_FORTRESSMODE_MIN_VP > 0))
            {
              aiFront.FrontType = 12;
              strS = strS + aiFront.FrontID.ToString() + " to ESCAPE in CheckIfEncircledFrontsWantToEscape() .\r\n";
            }
          }
          else
          {
            aiFront.FrontType = 12;
            strS = strS + aiFront.FrontID.ToString() + " to ESCAPE in CheckIfEncircledFrontsWantToEscape() .\r\n";
          }
        }
      }
    }

    public void ChangePanzersToTopFronts(ref AIFrontList tfrontList, ref AIMatrix fronts)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].TempTopUnit)
        {
          int frontNr = tfrontList.GetFrontNr(this.game.Data.UnitObj[unr].AIGroup);
          if (frontNr > 0 && !tfrontList.Front[frontNr].TopOperation && flagArray[unr] | (double) tfrontList.Front[frontNr].AverageStrength > 2.0 & (double) tfrontList.Front[frontNr].UnitCountRatio > 0.66)
          {
            SimpleList simpleList = new SimpleList();
            int counter = tfrontList.Counter;
            for (int tid = 0; tid <= counter; ++tid)
            {
              if (tfrontList.Front[tid].TopOperation)
              {
                Coordinate averageFrontCoordinate = tfrontList.Front[tid].GetAverageFrontCoordinate();
                Coordinate historicalAverageHex = this.game.HandyFunctionsObj.GetHistoricalAverageHex(this.game.Data.UnitObj[unr].Historical);
                if (averageFrontCoordinate.onmap & historicalAverageHex.onmap)
                {
                  int tweight = this.game.HandyFunctionsObj.Distance(averageFrontCoordinate.x, averageFrontCoordinate.y, 0, historicalAverageHex.x, historicalAverageHex.y, 0, 999);
                  simpleList.Add(tid, tweight);
                }
              }
            }
            simpleList.Sort();
            if (simpleList.Counter > -1 && simpleList.Id[0] != frontNr)
            {
              if (tfrontList.Front[frontNr].units.CheckIfPresentAIid(this.game.Data.UnitObj[unr].AIid))
              {
                int powerUnderFront = tfrontList.Front[frontNr].GetPowerUnderFront();
                tfrontList.Front[frontNr].RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
                tfrontList.Front[simpleList.Id[0]].AddUnit(unr);
                tfrontList.Front[frontNr].UnitCountRatio *= (float) tfrontList.Front[frontNr].units.counter / (float) (tfrontList.Front[frontNr].units.counter + 1);
                tfrontList.Front[frontNr].AverageStrength *= (float) tfrontList.Front[frontNr].GetPowerUnderFront() / (float) powerUnderFront;
              }
              if (tfrontList.Front[frontNr].artUnits.CheckIfPresentAIid(this.game.Data.UnitObj[unr].AIid))
              {
                tfrontList.Front[frontNr].RemoveArtUnitAIid(this.game.Data.UnitObj[unr].AIid);
                tfrontList.Front[simpleList.Id[0]].AddArtUnit(unr);
              }
              if (tfrontList.Front[frontNr].orgUnits.CheckIfPresentAIid(this.game.Data.UnitObj[unr].AIid))
              {
                tfrontList.Front[frontNr].RemoveOrgUnitAIid(this.game.Data.UnitObj[unr].AIid);
                tfrontList.Front[simpleList.Id[0]].AddOrgUnit(unr);
              }
              this.game.Data.UnitObj[unr].AIGroup = tfrontList.Front[simpleList.Id[0]].FrontID;
              int unitCounter2 = this.game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter2; ++index)
              {
                if (this.game.Data.UnitObj[unr].Historical == this.game.Data.UnitObj[index].Historical)
                  flagArray[index] = true;
              }
            }
          }
        }
      }
    }

    public SimpleList GetListOfVPChanges(
      ref AIFrontList tfrontList,
      ref AIWorld world1,
      ref AIWorld world2,
      bool WithAIVP = true,
      ref AIWorld worldFirstRound = null)
    {
      SimpleList listOfVpChanges = new SimpleList();
      int width1 = world1.owner.Width;
      int num1;
      for (int index1 = 0; index1 <= width1; ++index1)
      {
        int height = world1.owner.Height;
        for (int index2 = 0; index2 <= height; ++index2)
        {
          int index3 = index1 + world1.owner.Left;
          int index4 = index2 + world1.owner.Top;
          if (this.game.Data.MapObj[0].HexObj[index3, index4].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index3, index4] > 0)
          {
            if (world1.owner.Value[index1, index2] == 1)
            {
              int num2;
              num2 += this.game.Data.MapObj[0].HexObj[index3, index4].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index3, index4];
            }
            if (world2.owner.Value[index1, index2] == 1)
              num1 += this.game.Data.MapObj[0].HexObj[index3, index4].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index3, index4];
            if (worldFirstRound.owner.Value[index1, index2] == 1)
            {
              int num3;
              num3 += this.game.Data.MapObj[0].HexObj[index3, index4].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index3, index4];
            }
          }
        }
      }
      int width2 = world1.owner.Width;
      for (int index5 = 0; index5 <= width2; ++index5)
      {
        int height = world1.owner.Height;
        for (int index6 = 0; index6 <= height; ++index6)
        {
          int index7 = index5 + world1.owner.Left;
          int index8 = index6 + world1.owner.Top;
          int tid;
          if (this.game.Data.MapObj[0].HexObj[index7, index8].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index7, index8] > 0)
          {
            if (world1.owner.Value[index5, index6] == 1)
            {
              tid = world1.frontline.Value[index5, index6];
              if (tid > 0)
              {
                int vp = this.game.Data.MapObj[0].HexObj[index7, index8].VP;
                if (WithAIVP)
                  vp += this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index7, index8];
                int nr = listOfVpChanges.FindNr(tid);
                if (nr == -1)
                {
                  listOfVpChanges.Add(tid, 0, vp);
                }
                else
                {
                  int[] data1 = listOfVpChanges.Data1;
                  int[] numArray = data1;
                  int index9 = nr;
                  int index10 = index9;
                  int num4 = data1[index9] + vp;
                  numArray[index10] = num4;
                }
              }
            }
            if (world2.owner.Value[index5, index6] == 1)
            {
              tid = world2.frontline.Value[index5, index6];
              if (tid > 0)
              {
                int vp = this.game.Data.MapObj[0].HexObj[index7, index8].VP;
                if (WithAIVP)
                  vp += this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index7, index8];
                int nr = listOfVpChanges.FindNr(tid);
                if (nr == -1)
                {
                  listOfVpChanges.Add(tid, 0, tdata2: vp);
                }
                else
                {
                  int[] data2 = listOfVpChanges.Data2;
                  int[] numArray = data2;
                  int index11 = nr;
                  int index12 = index11;
                  int num5 = data2[index11] + vp;
                  numArray[index12] = num5;
                }
              }
            }
            if (worldFirstRound.owner.Value[index5, index6] == 1 && tid > 0)
            {
              int vp = this.game.Data.MapObj[0].HexObj[index7, index8].VP;
              if (WithAIVP)
                vp += this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index7, index8];
              int nr = listOfVpChanges.FindNr(tid);
              if (nr == -1)
              {
                listOfVpChanges.Add(tid, 0, tdata3: vp);
              }
              else
              {
                int[] data3 = listOfVpChanges.Data3;
                int[] numArray = data3;
                int index13 = nr;
                int index14 = index13;
                int num6 = data3[index13] + vp;
                numArray[index14] = num6;
              }
            }
          }
          if ((this.VAR_VP_AT_DEFEAT == 0 | this.VAR_VP_AT_DEFEAT < num1) & num1 > 0)
          {
            int index15 = 0;
            do
            {
              if (this.VAR_SUPPLY_ACTIVE[this.GetGameDataTurn(), index15])
              {
                int num7 = this.VAR_SUPPLY_X[this.GetGameDataTurn(), index15];
                int num8 = this.VAR_SUPPLY_Y[this.GetGameDataTurn(), index15];
                if (num7 == index7 & num8 == index8)
                {
                  if (world1.owner.Value[index5, index6] == 1)
                  {
                    tid = world1.frontline.Value[index5, index6];
                    if (tid > 0)
                    {
                      int tdata1 = 1000;
                      int nr = listOfVpChanges.FindNr(tid);
                      if (nr == -1)
                      {
                        listOfVpChanges.Add(tid, 0, tdata1);
                      }
                      else
                      {
                        int[] data1 = listOfVpChanges.Data1;
                        int[] numArray = data1;
                        int index16 = nr;
                        int index17 = index16;
                        int num9 = data1[index16] + tdata1;
                        numArray[index17] = num9;
                      }
                    }
                  }
                  if (world2.owner.Value[index5, index6] == 1)
                  {
                    tid = world2.frontline.Value[index5, index6];
                    if (tid > 0)
                    {
                      int tdata2 = 1000;
                      int nr = listOfVpChanges.FindNr(tid);
                      if (nr == -1)
                      {
                        listOfVpChanges.Add(tid, 0, tdata2: tdata2);
                      }
                      else
                      {
                        int[] data2 = listOfVpChanges.Data2;
                        int[] numArray = data2;
                        int index18 = nr;
                        int index19 = index18;
                        int num10 = data2[index18] + tdata2;
                        numArray[index19] = num10;
                      }
                    }
                  }
                }
              }
              ++index15;
            }
            while (index15 <= 3);
          }
        }
      }
      int counter = listOfVpChanges.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        listOfVpChanges.Weight[index] = listOfVpChanges.Data2[index] - listOfVpChanges.Data1[index];
        listOfVpChanges.Data3[index] = listOfVpChanges.Data3[index] - listOfVpChanges.Data1[index];
      }
      return listOfVpChanges;
    }

    public int CreateReserveFront(
      ref AIFrontList tfrontList,
      ref int idToSplit,
      ref int targetFrontID,
      ref AIMatrix frontMatrix)
    {
      AIFront front = tfrontList.FindFront(idToSplit);
      int powerUnderFront1 = front.GetPowerUnderFront();
      int unitAiidToSplitOff = front.GetUnitAIIDToSplitOff(frontMatrix, targetFrontID, tfrontList.Front[tfrontList.GetFrontNr(targetFrontID)]);
      if (unitAiidToSplitOff == -1)
        return -1;
      int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(unitAiidToSplitOff);
      DC2AIClass tai = this;
      AIFront tFront = new AIFront(ref tai, 2);
      tFront.AddUnit(unitByAiid);
      front.RemoveUnitAIid(this.game.Data.UnitObj[unitByAiid].AIid);
      tfrontList.AddFront(tFront, true);
      tFront.FrontID = this.game.Data.UnitObj[unitByAiid].Historical;
      tFront.tempCreatedFromFrontID = front.FrontID;
      this.game.Data.UnitObj[unitByAiid].AIGroup = tFront.FrontID;
      if (this.VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT & this.VAR_USE_STRICT_HQFRONT)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 & !this.game.Data.UnitObj[unr].AIReserve && this.game.Data.UnitObj[unr].HQ == this.game.Data.UnitObj[unitByAiid].HQ & this.game.Data.UnitObj[unr].AISubStrictGroup == this.game.Data.UnitObj[unitByAiid].AISubStrictGroup && unr != unitByAiid)
          {
            tFront.AddUnit(unr);
            front.RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
            this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
          }
        }
      }
      else
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].Historical == this.game.Data.UnitObj[unitByAiid].Historical && unr != unitByAiid)
          {
            tFront.AddUnit(unr);
            front.RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
            this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
          }
        }
      }
      int powerUnderFront2 = front.GetPowerUnderFront();
      front.PowerToReserve += powerUnderFront1 - powerUnderFront2;
      float num = front.AverageStrength * (float) powerUnderFront2 / (float) powerUnderFront1;
      front.AverageStrength = num;
      return tFront.FrontID;
    }

    public SimpleList AssignReservesToActionList(
      ref AIFrontList tfrontList,
      ref SimpleList tactionList,
      ref SimpleList treservelist,
      ref string strS,
      bool allowSSHQshuffle)
    {
      SimpleList actionList = new SimpleList();
      SimpleList simpleList1 = tactionList.Clone();
      treservelist.Clone();
      if (allowSSHQshuffle && this.CustomCalls.HasCustumCalls() & this.VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT & this.VAR_USE_STRICT_HQFRONT)
      {
        SimpleList simpleList2 = tactionList.Clone();
        SimpleList simpleList3 = treservelist.Clone();
        int counter1 = simpleList2.Counter;
        for (int index = 0; index <= counter1; ++index)
          simpleList2.Data1[index] = 0;
        simpleList3.ReverseSort();
        int counter2 = simpleList3.Counter;
        for (int index1 = 0; index1 <= counter2; ++index1)
        {
          int initialFrontID = simpleList3.Id[index1];
          AIFront front1 = tfrontList.FindFront(initialFrontID);
          Coordinate averageFrontCoordinate = front1.GetAverageFrontCoordinate();
          if (averageFrontCoordinate.onmap)
          {
            int num1 = front1.strictHQs.counter + 1;
            int num2 = (double) front1.OrigAverageStrength >= 2.5 ? ((double) front1.OrigAverageStrength >= 3.0 ? ((double) front1.OrigAverageStrength >= 3.5 ? ((double) front1.OrigAverageStrength >= 4.0 ? ((double) front1.OrigAverageStrength >= 4.5 ? (int) Math.Round(Math.Ceiling((double) num1 * 0.7)) : (int) Math.Round(Math.Ceiling((double) num1 * 0.6))) : (int) Math.Round(Math.Ceiling((double) num1 * 0.5))) : (int) Math.Round(Math.Ceiling((double) num1 * 0.4))) : (int) Math.Round(Math.Ceiling((double) num1 * 0.3))) : (int) Math.Round(Math.Ceiling((double) num1 * 0.2));
            SimpleList simpleList4 = new SimpleList();
            int counter3 = simpleList2.Counter;
            for (int index2 = 0; index2 <= counter3; ++index2)
            {
              int num3 = simpleList2.Id[index2];
              if (tfrontList.FindFront(num3).FrontID != front1.FrontID)
              {
                int counter4 = front1.strictHQs.counter;
                for (int index3 = 0; index3 <= counter4; ++index3)
                {
                  int num4 = front1.strictHQs.unr[index3];
                  int num5 = front1.strictHQs.AIid[index3];
                  bool flag = true;
                  if (this.game.Data.Product >= 6 & num4 > -1 && this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(num4))
                    flag = false;
                  if (flag)
                  {
                    Coordinate averageUnitsCoordinate = front1.GetAverageUnitsCoordinate(num4, num5);
                    if (averageUnitsCoordinate.onmap)
                    {
                      int num6 = this.game.HandyFunctionsObj.Distance(averageFrontCoordinate.x, averageFrontCoordinate.y, 0, averageUnitsCoordinate.x, averageUnitsCoordinate.y, 0, 32);
                      if (num6 < 32)
                      {
                        int num7 = (int) Math.Round((double) (simpleList2.Weight[index2] * 1000) / (double) num6);
                        if (front1.units.counter > -1)
                        {
                          int tweight = (int) Math.Round((double) num7 / Math.Sqrt((double) (front1.units.counter + 1)));
                          if (simpleList2.Data1[index2] > 0)
                            tweight = (int) Math.Round(1.0 / (double) (simpleList2.Data1[index2] * 10));
                          if (tweight > 500)
                            simpleList4.AddWeight(num3, tweight, num4, num5, CheckData1Existence: true, CheckData2Existence: true);
                        }
                      }
                    }
                  }
                }
              }
            }
            int num8 = num2;
            for (int index4 = 1; index4 <= num8; ++index4)
            {
              simpleList4.ReverseSort();
              if (simpleList4.Counter > -1)
              {
                int num9 = simpleList4.Id[0];
                AIFront front2 = tfrontList.FindFront(num9);
                int tunr = simpleList4.Data1[0];
                int tAIid = simpleList4.Data2[0];
                int num10 = -1;
                int counter5 = front2.strictHQs.counter;
                for (int index5 = 0; index5 <= counter5; ++index5)
                {
                  if (front2.strictHQs.unr[index5] == tunr & front2.strictHQs.AIid[index5] == tAIid)
                    num10 = index5;
                }
                if (num10 == -1)
                {
                  simpleList4.Weight[0] = (int) Math.Round((double) simpleList4.Weight[0] / 10.0);
                  int nr = simpleList2.FindNr(num9);
                  int[] data1 = simpleList2.Data1;
                  int[] numArray = data1;
                  int index6 = nr;
                  int index7 = index6;
                  int num11 = data1[index6] + 1;
                  numArray[index7] = num11;
                  front2.strictHQs.add(tunr, tAIid);
                  strS = strS + "Added " + this.game.Data.UnitObj[tunr].Name + " (SSHQ-" + tAIid.ToString() + ") from frontID#" + front1.FrontID.ToString() + " to frontID#" + front2.FrontID.ToString() + ".\r\n";
                }
              }
            }
          }
        }
      }
      bool flag1;
      do
      {
        flag1 = false;
        int counter6 = simpleList1.Counter;
        for (int index8 = 0; index8 <= counter6; ++index8)
        {
          AIFront front3 = tfrontList.FindFront(simpleList1.Id[index8]);
          Coordinate averageFrontCoordinate1 = front3.GetAverageFrontCoordinate();
          Coordinate averageFrontCoordinate2 = front3.GetAverageFrontCoordinate();
          int num12 = (int) Math.Round(1.0 + Conversion.Int((double) simpleList1.Weight[index8] / 33.0));
          SimpleList simpleList5 = treservelist.Clone();
          int num13 = 1;
          int counter7 = tfrontList.Counter;
          for (int index9 = 0; index9 <= counter7; ++index9)
          {
            if (simpleList1.Id[index8] == tfrontList.Front[index9].tempCreatedFromFrontID)
              num13 = 0;
            int frontNr = tfrontList.GetFrontNr(simpleList1.Id[index8]);
            if ((double) tfrontList.Front[frontNr].AverageStrength >= (double) tfrontList.Front[frontNr].OrigAverageStrength * 2.0)
              num13 = 0;
          }
          for (int counter8 = simpleList5.Counter; counter8 >= 0; counter8 += -1)
          {
            if (simpleList5.Id[counter8] != simpleList1.Id[index8])
            {
              int nr = simpleList1.FindNr(simpleList5.Id[counter8]);
              if (nr > -1 && simpleList1.Weight[nr] > simpleList1.Weight[index8])
                simpleList5.RemoveNr(counter8);
            }
          }
          if (num13 == 1)
          {
            for (int counter9 = simpleList5.Counter; counter9 >= 0; counter9 += -1)
            {
              int frontNr1 = tfrontList.GetFrontNr(simpleList1.Id[index8]);
              int frontNr2 = tfrontList.GetFrontNr(simpleList5.Id[counter9]);
              bool flag2;
              if (this.VAR_USE_STRICT_HQFRONT)
              {
                flag2 = false;
                int counter10 = tfrontList.Front[frontNr1].strictHQs.counter;
                for (int index10 = 0; index10 <= counter10; ++index10)
                {
                  int counter11 = tfrontList.Front[frontNr2].strictHQs.counter;
                  for (int index11 = 0; index11 <= counter11; ++index11)
                  {
                    if (tfrontList.Front[frontNr1].strictHQs.unr[index10] == tfrontList.Front[frontNr2].strictHQs.unr[index11])
                      flag2 = true;
                  }
                }
              }
              else
                flag2 = true;
              if (frontNr1 == frontNr2)
                flag2 = false;
              if (flag2)
              {
                if (actionList.FindNr(simpleList5.Id[counter9]) == -1)
                {
                  AIFront front4 = tfrontList.FindFront(simpleList5.Id[counter9]);
                  if (front4.FrontType == 10)
                    simpleList5.Remove(simpleList5.Id[counter9]);
                  else if ((double) front4.OrigAverageStrength - 0.4 > (double) front3.AverageStrength & (double) front4.OrigAverageStrength > 1.5 | front4.FrontType == 2 | front3.units.counter == -1)
                  {
                    Coordinate averageFrontCoordinate3 = front4.GetAverageFrontCoordinate();
                    if (this.game.HandyFunctionsObj.Distance(averageFrontCoordinate1.x, averageFrontCoordinate1.y, 0, averageFrontCoordinate3.x, averageFrontCoordinate3.y, 0, 32) < 29)
                    {
                      Coordinate averageFrontCoordinate4 = front4.GetAverageFrontCoordinate();
                      int num14 = this.game.HandyFunctionsObj.Distance(averageFrontCoordinate2.x, averageFrontCoordinate2.y, 0, averageFrontCoordinate4.x, averageFrontCoordinate4.y, 0, 99);
                      if (num14 <= 99)
                      {
                        simpleList5.Weight[counter9] = (int) Math.Round((double) simpleList5.Weight[counter9] / (double) num14);
                        if (front4.GetUnitsInTargetFrontIDTerritory(this.frontMatrix, front3.FrontID) > 0)
                        {
                          int[] weight = simpleList5.Weight;
                          int[] numArray = weight;
                          int index12 = counter9;
                          int index13 = index12;
                          int num15 = weight[index12] * 4;
                          numArray[index13] = num15;
                        }
                      }
                      else
                        simpleList5.Remove(simpleList5.Id[counter9]);
                    }
                    else
                      simpleList5.Remove(simpleList5.Id[counter9]);
                  }
                  else
                    simpleList5.Remove(simpleList5.Id[counter9]);
                }
                else
                  simpleList5.Remove(simpleList5.Id[counter9]);
              }
              else
                simpleList5.Remove(simpleList5.Id[counter9]);
            }
            simpleList5.ReverseSort();
            int num16 = 0;
            int counter12 = simpleList5.Counter;
            for (int index14 = 0; index14 <= counter12; ++index14)
            {
              ++num16;
              if (num16 <= num12)
              {
                int tid = simpleList5.Id[index14];
                flag1 = true;
                actionList.Add(tid, 0, front3.FrontID);
              }
            }
          }
        }
      }
      while (flag1);
      return actionList;
    }

    public void AssignReserveFronts(
      ref AIFrontList tempFrontList,
      int reserveAssign,
      int useFRONTTYPE,
      int maxDist = 999)
    {
      int counter1 = tempFrontList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront = tempFrontList.Front[index1];
        if (aiFront.FrontType == useFRONTTYPE & !(useFRONTTYPE == 3 & aiFront.FrontID > 1000000 & this.VAR_ZONES_TYPE == 2) && aiFront.TargetFrontID < 1 & (aiFront.units.counter > -1 | aiFront.artUnits.counter > -1))
        {
          DC2AIClass tai = this;
          AIMatrix aiMatrix = new AIMatrix(ref tai);
          int counter2 = aiFront.units.counter;
          for (int index2 = 0; index2 <= counter2; ++index2)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index2]);
            if (unitByAiid > -1)
              aiMatrix.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] = 1;
          }
          int counter3 = aiFront.artUnits.counter;
          for (int index3 = 0; index3 <= counter3; ++index3)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.artUnits.AIid[index3]);
            if (unitByAiid > -1)
              aiMatrix.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] = 1;
          }
          aiMatrix.ExpandAndAddValueForSameRegime(9999);
          int[] numArray = new int[tempFrontList.Counter + 1];
          int counter4 = tempFrontList.Counter;
          for (int index4 = 0; index4 <= counter4; ++index4)
            numArray[index4] = 9999;
          int mapWidth = this.map.MapWidth;
          for (int index5 = 0; index5 <= mapWidth; ++index5)
          {
            int mapHeight = this.map.MapHeight;
            for (int index6 = 0; index6 <= mapHeight; ++index6)
            {
              int initialFrontID = this.frontMatrix.Value[index5, index6];
              if (initialFrontID > 0 & this.GetRegime(this.map.HexObj[index5, index6].Regime) == this.GetGameDataTurn())
              {
                int frontNr = tempFrontList.GetFrontNr(initialFrontID);
                if (frontNr > -1)
                {
                  int num = aiMatrix.Value[index5, index6];
                  if (num < numArray[frontNr] && num <= maxDist)
                    numArray[frontNr] = num;
                }
              }
            }
          }
          int num1 = 9999;
          int index7 = -1;
          int counter5 = tempFrontList.Counter;
          for (int index8 = 0; index8 <= counter5; ++index8)
          {
            if (tempFrontList.Front[index8].FrontType == 1 && tempFrontList.Front[index8].Stance != 1 & tempFrontList.Front[index8].Stance != 4 && tempFrontList.Front[index8].Strength == reserveAssign | reserveAssign == 4)
            {
              numArray[index8] = (int) Math.Round((double) ((float) numArray[index8] * tempFrontList.Front[index8].AverageStrength));
              if (numArray[index8] < num1 & numArray[index8] <= maxDist)
              {
                bool flag = false;
                if (this.VAR_USE_STRICT_HQFRONT)
                {
                  int counter6 = aiFront.units.counter;
                  for (int index9 = 0; index9 <= counter6; ++index9)
                  {
                    int hq = this.game.Data.UnitObj[aiFront.units.unr[index9]].HQ;
                    if (hq > -1 && tempFrontList.Front[index8].strictHQs.CheckIfPresentUnr(hq))
                      flag = true;
                  }
                  int counter7 = aiFront.artUnits.counter;
                  for (int index10 = 0; index10 <= counter7; ++index10)
                  {
                    int hq = this.game.Data.UnitObj[aiFront.artUnits.unr[index10]].HQ;
                    if (hq > -1 && tempFrontList.Front[index8].strictHQs.CheckIfPresentUnr(hq))
                      flag = true;
                  }
                }
                else
                  flag = true;
                if (flag)
                {
                  num1 = numArray[index8];
                  index7 = index8;
                }
              }
            }
          }
          if (index7 > -1)
          {
            aiFront.TargetFrontID = tempFrontList.Front[index7].FrontID;
            aiFront.Distance = num1;
          }
        }
      }
    }

    public void AssignNavyAndCargoFronts(ref AIFrontList tempFrontList)
    {
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix2.Left, aiMatrix2.Top, aiMatrix2.Width, aiMatrix2.Height);
      AIMatrix aiMatrix3 = mask.Clone();
      aiMatrix3.RemoveValuesByMask(mask, 1);
      aiMatrix3.ExpandAndAddValueForAnyRegime(29);
      aiMatrix3.SetAllValuesSubtractWith(2);
      AIMatrix aiMatrix4 = this.SetSeaIDMatrix();
      int num1 = aiMatrix4.ReturnHighestValueInMatrix();
      for (int index1 = 1; index1 <= num1; ++index1)
      {
        int num2 = 0;
        int num3 = 0;
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter1; ++unr)
        {
          if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.game.HandyFunctionsObj.HasUnitNavySF(unr) & aiMatrix4.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] == index1 && this.game.Data.UnitObj[unr].TempCategory == 7)
          {
            if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
              num2 = num2 + this.game.Data.UnitObj[unr].TempUnitPowerAbs + 1;
            else
              num3 = num3 + this.game.Data.UnitObj[unr].TempUnitPowerAbs + 1;
          }
        }
        int num4 = (double) num2 <= (double) num3 * 1.5 ? ((double) num2 <= (double) num3 * 0.6 ? 1 : 2) : 3;
        SimpleList simpleList1 = new SimpleList();
        if (num2 > 0)
        {
          if (num4 >= 1)
          {
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int index2 = 0; index2 <= unitCounter2; ++index2)
            {
              if (this.game.Data.UnitObj[index2].X > -1 & this.game.Data.UnitObj[index2].PreDef == -1 && this.game.HandyFunctionsObj.HasUnitNavySF(index2) & aiMatrix4.Value[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y] == index1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LandscapeType].IsSea && this.game.Data.UnitObj[index2].TempCategory == 6 & this.game.Data.UnitObj[index2].Regime != this.game.Data.Turn)
                simpleList1.Add(index2, this.game.Data.UnitObj[index2].TempUnitPowerAbs * 1000, this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y);
            }
          }
          if (num4 >= 3)
          {
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int index3 = 0; index3 <= unitCounter3; ++index3)
            {
              if (this.game.Data.UnitObj[index3].X > -1 & this.game.Data.UnitObj[index3].PreDef == -1 && this.game.HandyFunctionsObj.HasUnitNavySF(index3) & aiMatrix4.Value[this.game.Data.UnitObj[index3].X, this.game.Data.UnitObj[index3].Y] == index1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index3].X, this.game.Data.UnitObj[index3].Y].LandscapeType].IsSea && this.game.Data.UnitObj[index3].TempCategory == 7 & this.game.Data.UnitObj[index3].Regime != this.game.Data.Turn)
                simpleList1.Add(index3, this.game.Data.UnitObj[index3].TempUnitPowerAbs * 100, this.game.Data.UnitObj[index3].X, this.game.Data.UnitObj[index3].Y);
            }
          }
          DC2AIClass tai3 = this;
          AIMatrix aiMatrix5 = new AIMatrix(ref tai3);
          int counter1 = tempFrontList.Counter;
          for (int index4 = 0; index4 <= counter1; ++index4)
          {
            AIFront aiFront = tempFrontList.Front[index4];
            if (aiFront.FrontType == 8 && aiFront.targetX == -1)
            {
              int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[0]);
              if (unitByAiid > -1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y].LandscapeType].IsSea | (double) VBMath.Rnd() > 0.5 && aiMatrix4.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] == index1 && this.game.Data.UnitObj[unitByAiid].Supply > this.game.HandyFunctionsObj.UnitSupplyUse(unitByAiid) * 2 & aiMatrix5.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] < this.map.HexObj[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y].UnitCounter * 4)
              {
                SimpleList simpleList2 = new SimpleList();
                int counter2 = simpleList1.Counter;
                for (int tdata3 = 0; tdata3 <= counter2; ++tdata3)
                {
                  int tweight = (int) Math.Round((double) simpleList1.Weight[tdata3] / (double) this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y, 0, simpleList1.Data1[tdata3], simpleList1.Data2[tdata3], 0, 49));
                  simpleList2.Add(simpleList1.Id[tdata3], tweight, simpleList1.Data1[tdata3], simpleList1.Data2[tdata3], tdata3);
                }
                if (simpleList2.Counter > -1)
                {
                  simpleList2.ReverseSort();
                  aiFront.targetX = simpleList2.Data1[0];
                  aiFront.targetY = simpleList2.Data2[0];
                  simpleList1.Weight[simpleList2.Data3[0]] = (int) Math.Round((double) simpleList1.Weight[simpleList2.Data3[0]] / 2.0);
                  int[,] numArray1 = aiMatrix5.Value;
                  int[,] numArray2 = numArray1;
                  int targetX = aiFront.targetX;
                  int index5 = targetX;
                  int targetY = aiFront.targetY;
                  int index6 = targetY;
                  int num5 = numArray1[targetX, targetY] + 1;
                  numArray2[index5, index6] = num5;
                }
              }
            }
            if (aiFront.FrontType == 8 | aiFront.FrontType == 9 && aiFront.targetX == -1)
            {
              int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[0]);
              if (unitByAiid > -1 && aiMatrix4.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] == index1)
              {
                SimpleList simpleList3 = new SimpleList();
                int mapWidth = this.map.MapWidth;
                for (int index7 = 0; index7 <= mapWidth; ++index7)
                {
                  int mapHeight = this.map.MapHeight;
                  for (int index8 = 0; index8 <= mapHeight; ++index8)
                  {
                    if (aiMatrix4.Value[index7, index8] == index1 & this.map.HexObj[index7, index8].Regime == this.game.Data.Turn && this.game.HandyFunctionsObj.IsHexPort(index7, index8, 0) & this.map.HexObj[index7, index8].UnitCounter + aiMatrix5.Value[index7, index8] < 13)
                    {
                      int tweight = Math.Max(1, this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y, 0, index7, index8, 0, 49));
                      if (aiMatrix3.Value[index7, index8] >= 0 & aiMatrix3.Value[index7, index8] <= 14)
                        tweight += (14 - aiMatrix3.Value[index7, index8]) * 100;
                      simpleList3.Add(index7 * 1000 + index8, tweight, index7, index8);
                    }
                  }
                }
                simpleList3.Sort();
                if (simpleList3.Counter > -1)
                {
                  aiFront.targetX = simpleList3.Data1[0];
                  aiFront.targetY = simpleList3.Data2[0];
                  int[,] numArray3 = aiMatrix5.Value;
                  int[,] numArray4 = numArray3;
                  int targetX = aiFront.targetX;
                  int index9 = targetX;
                  int targetY = aiFront.targetY;
                  int index10 = targetY;
                  int num6 = numArray3[targetX, targetY] + 1;
                  numArray4[index9, index10] = num6;
                }
              }
            }
          }
        }
      }
    }

    public void AssignAirCoverFronts(ref AIFrontList tempFrontList)
    {
      int counter1 = tempFrontList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront1 = tempFrontList.Front[index1];
        if (aiFront1.FrontType == 5 && aiFront1.TargetFrontID < 1)
        {
          DC2AIClass tai1 = this;
          AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
          int counter2 = tempFrontList.Counter;
          for (int index2 = 0; index2 <= counter2; ++index2)
          {
            AIFront aiFront2 = tempFrontList.Front[index2];
            if (index2 != index1 && aiFront2.FrontType == 5 && aiFront2.units.counter > -1)
            {
              int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront2.units.AIid[0]);
              int x = this.game.Data.UnitObj[unitByAiid].X;
              int y = this.game.Data.UnitObj[unitByAiid].Y;
              if (aiFront2.TargetFrontID > 0)
              {
                Coordinate averageFrontCoordinate = this.frontList.FindFront(aiFront2.TargetFrontID).GetAverageFrontCoordinate();
                if (averageFrontCoordinate.onmap)
                {
                  x = averageFrontCoordinate.x;
                  y = averageFrontCoordinate.y;
                }
              }
              DC2AIClass tai2 = this;
              AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
              aiMatrix2.Value[x, y] = 20;
              aiMatrix2.ExpandAndRemoveValueForAnyRegime(20);
              int mapWidth = this.map.MapWidth;
              for (int index3 = 0; index3 <= mapWidth; ++index3)
              {
                int mapHeight = this.map.MapHeight;
                for (int index4 = 0; index4 <= mapHeight; ++index4)
                {
                  int[,] numArray1 = aiMatrix1.Value;
                  int[,] numArray2 = numArray1;
                  int index5 = index3;
                  int index6 = index5;
                  int index7 = index4;
                  int index8 = index7;
                  int num = numArray1[index5, index7] + aiMatrix2.Value[index3, index4];
                  numArray2[index6, index8] = num;
                }
              }
            }
          }
          DC2AIClass tai3 = this;
          AIMatrix aiMatrix3 = new AIMatrix(ref tai3);
          int counter3 = aiFront1.units.counter;
          for (int index9 = 0; index9 <= counter3; ++index9)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront1.units.AIid[index9]);
            if (unitByAiid > -1)
              aiMatrix3.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] = 1;
          }
          aiMatrix3.ExpandAndAddValueForSameRegime(9999);
          int[] numArray3 = new int[tempFrontList.Counter + 1];
          int[] numArray4 = new int[tempFrontList.Counter + 1];
          int counter4 = tempFrontList.Counter;
          for (int index10 = 0; index10 <= counter4; ++index10)
            numArray3[index10] = 9999;
          int mapWidth1 = this.map.MapWidth;
          for (int index11 = 0; index11 <= mapWidth1; ++index11)
          {
            int mapHeight = this.map.MapHeight;
            for (int index12 = 0; index12 <= mapHeight; ++index12)
            {
              int initialFrontID = this.frontMatrix.Value[index11, index12];
              if (initialFrontID > 0)
              {
                int frontNr = tempFrontList.GetFrontNr(initialFrontID);
                if (frontNr > -1)
                {
                  int num1 = aiMatrix3.Value[index11, index12] * (1 + (int) Math.Round((double) aiMatrix1.Value[index11, index12] / 10.0));
                  if (num1 < numArray3[frontNr])
                  {
                    numArray3[frontNr] = num1 * (1 + (int) Math.Round((double) aiMatrix1.Value[index11, index12] / 10.0));
                    int[] numArray5 = numArray4;
                    int[] numArray6 = numArray5;
                    int index13 = frontNr;
                    int index14 = index13;
                    int num2 = numArray5[index13] + 1;
                    numArray6[index14] = num2;
                  }
                }
              }
            }
          }
          int num3 = 9999;
          int index15 = -1;
          int counter5 = tempFrontList.Counter;
          for (int index16 = 0; index16 <= counter5; ++index16)
          {
            if (tempFrontList.Front[index16].FrontType == 1 & tempFrontList.Front[index16].units.counter > -1 & numArray4[index16] > 0)
            {
              int d = (int) Math.Round((double) numArray3[index16] / (double) numArray4[index16]) + Math.Max(8000 - 200 * tempFrontList.Front[index16].units.counter, 0);
              if (tempFrontList.Front[index16].Stance == 3)
                d = (int) Math.Round((double) d / 4.0);
              if (tempFrontList.Front[index16].Stance == 2)
                d = (int) Math.Round((double) d / 2.0);
              if (tempFrontList.Front[index16].units.counter > 0)
                d = (int) Math.Round((double) d / Math.Sqrt((double) d));
              if (d < num3)
              {
                num3 = d;
                index15 = index16;
              }
            }
          }
          if (index15 > -1)
          {
            aiFront1.TargetFrontID = tempFrontList.Front[index15].FrontID;
            aiFront1.Distance = num3;
          }
        }
      }
    }

    public void AssignAirTransportFronts(ref AIFrontList tempFrontList)
    {
      int counter1 = tempFrontList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront1 = tempFrontList.Front[index1];
        if (aiFront1.FrontType == 7 && aiFront1.TargetFrontID < 1)
        {
          SimpleList simpleList = new SimpleList();
          int counter2 = tempFrontList.Counter;
          for (int index2 = 0; index2 <= counter2; ++index2)
          {
            AIFront aiFront2 = tempFrontList.Front[index2];
            if (index2 != index1 && aiFront2.FrontType == 1 | aiFront2.FrontType == 2 | aiFront2.FrontType == 3)
            {
              int tweight = 0;
              int x;
              int y;
              if (aiFront2.units.counter > -1)
              {
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront2.units.AIid[0]);
                x = this.game.Data.UnitObj[unitByAiid].X;
                y = this.game.Data.UnitObj[unitByAiid].Y;
                int num1 = (int) Math.Round((double) (this.game.Data.UnitObj[unitByAiid].SupplyIn * 100) / (double) Math.Max(this.game.Data.UnitObj[unitByAiid].SupplyInReq, 1));
                if (num1 < 50)
                {
                  int num2 = (int) Math.Round((double) num1 * ((double) this.game.Data.UnitObj[unitByAiid].SupplyConsume / 100.0));
                  tweight += 100 - num2;
                }
              }
              if (aiFront2.artUnits.counter > -1)
              {
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront2.artUnits.AIid[0]);
                x = this.game.Data.UnitObj[unitByAiid].X;
                y = this.game.Data.UnitObj[unitByAiid].Y;
                int num3 = (int) Math.Round((double) (this.game.Data.UnitObj[unitByAiid].SupplyIn * 100) / (double) Math.Max(this.game.Data.UnitObj[unitByAiid].SupplyInReq, 1));
                if (num3 < 50)
                {
                  int num4 = (int) Math.Round((double) num3 * ((double) this.game.Data.UnitObj[unitByAiid].SupplyConsume / 100.0));
                  tweight += 100 - num4;
                }
              }
              int num = 0;
              int counter3 = tempFrontList.Counter;
              for (int index3 = 0; index3 <= counter3; ++index3)
              {
                AIFront aiFront3 = tempFrontList.Front[index3];
                if (aiFront3.FrontType == 7 && aiFront3.TargetFrontID == aiFront2.FrontID)
                  ++num;
              }
              if (num > 0)
                tweight = (int) Math.Round((double) tweight / (double) num);
              simpleList.Add(aiFront2.FrontID, tweight);
            }
          }
          simpleList.ReverseSort();
          if (simpleList.Id[0] > 0 && simpleList.Weight[0] > 0)
            aiFront1.TargetFrontID = simpleList.Id[0];
        }
      }
    }

    public void AssignAirSupportFronts(ref AIFrontList tempFrontList)
    {
      int counter1 = tempFrontList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront1 = tempFrontList.Front[index1];
        if (aiFront1.FrontType == 4 && aiFront1.TargetFrontID < 1)
        {
          DC2AIClass tai1 = this;
          AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
          int counter2 = tempFrontList.Counter;
          for (int index2 = 0; index2 <= counter2; ++index2)
          {
            AIFront aiFront2 = tempFrontList.Front[index2];
            if (index2 != index1 && aiFront2.FrontType == 4 && aiFront2.units.counter > -1)
            {
              int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront2.units.AIid[0]);
              int x = this.game.Data.UnitObj[unitByAiid].X;
              int y = this.game.Data.UnitObj[unitByAiid].Y;
              if (aiFront2.TargetFrontID > 0)
              {
                Coordinate averageFrontCoordinate = this.frontList.FindFront(aiFront2.TargetFrontID).GetAverageFrontCoordinate();
                if (averageFrontCoordinate.onmap)
                {
                  x = averageFrontCoordinate.x;
                  y = averageFrontCoordinate.y;
                }
              }
              DC2AIClass tai2 = this;
              AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
              aiMatrix2.Value[x, y] = 20;
              aiMatrix2.ExpandAndRemoveValueForAnyRegime(20);
              int mapWidth = this.map.MapWidth;
              for (int index3 = 0; index3 <= mapWidth; ++index3)
              {
                int mapHeight = this.map.MapHeight;
                for (int index4 = 0; index4 <= mapHeight; ++index4)
                {
                  int[,] numArray1 = aiMatrix1.Value;
                  int[,] numArray2 = numArray1;
                  int index5 = index3;
                  int index6 = index5;
                  int index7 = index4;
                  int index8 = index7;
                  int num = numArray1[index5, index7] + aiMatrix2.Value[index3, index4];
                  numArray2[index6, index8] = num;
                }
              }
            }
          }
          DC2AIClass tai3 = this;
          AIMatrix aiMatrix3 = new AIMatrix(ref tai3);
          int counter3 = aiFront1.units.counter;
          for (int index9 = 0; index9 <= counter3; ++index9)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront1.units.AIid[index9]);
            if (unitByAiid > -1)
              aiMatrix3.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] = 1;
          }
          aiMatrix3.ExpandAndAddValueForSameRegime(9999);
          int[] numArray3 = new int[tempFrontList.Counter + 1];
          int[] numArray4 = new int[tempFrontList.Counter + 1];
          int counter4 = tempFrontList.Counter;
          for (int index10 = 0; index10 <= counter4; ++index10)
            numArray3[index10] = 9999;
          int mapWidth1 = this.map.MapWidth;
          for (int index11 = 0; index11 <= mapWidth1; ++index11)
          {
            int mapHeight = this.map.MapHeight;
            for (int index12 = 0; index12 <= mapHeight; ++index12)
            {
              int initialFrontID = this.frontMatrix.Value[index11, index12];
              if (initialFrontID > 0)
              {
                int frontNr = tempFrontList.GetFrontNr(initialFrontID);
                if (frontNr > -1)
                {
                  int num1 = aiMatrix3.Value[index11, index12] * (1 + (int) Math.Round((double) aiMatrix1.Value[index11, index12] / 10.0));
                  if (num1 < numArray3[frontNr])
                  {
                    numArray3[frontNr] = num1 * (1 + aiMatrix1.Value[index11, index12]);
                    int[] numArray5 = numArray4;
                    int[] numArray6 = numArray5;
                    int index13 = frontNr;
                    int index14 = index13;
                    int num2 = numArray5[index13] + 1;
                    numArray6[index14] = num2;
                  }
                }
              }
            }
          }
          int num3 = 999999;
          int index15 = -1;
          int counter5 = tempFrontList.Counter;
          for (int index16 = 0; index16 <= counter5; ++index16)
          {
            if (tempFrontList.Front[index16].FrontType == 1 & numArray4[index16] > 0 & tempFrontList.Front[index16].units.counter > -1)
            {
              int num4 = (int) Math.Round((double) numArray3[index16] / (double) numArray4[index16]) + Math.Max(8000 - tempFrontList.Front[index16].units.counter * 200, 0);
              int num5 = tempFrontList.Front[index16].Stance != 3 ? num4 : (int) Math.Round((double) num4 * 0.25);
              int num6 = numArray3[index16];
              if (tempFrontList.Front[index16].Stance == 2)
                num6 = (int) Math.Round((double) num6 * 0.5);
              if (num6 < num3)
              {
                num3 = num6;
                index15 = index16;
              }
            }
          }
          if (index15 > -1)
          {
            aiFront1.TargetFrontID = tempFrontList.Front[index15].FrontID;
            aiFront1.Distance = num3;
          }
        }
      }
    }

    public void LogFronts(string extraInfo = "")
    {
      if (!this.VAR_DEBUG_ON)
        return;
      int unitByAiid;
      if (this.VAR_USE_STRICT_HQFRONT)
      {
        this.AddLog("---------------------------------QUICK STRICT HQ LOG----");
        int counter1 = this.frontList.Counter;
        for (int index1 = 0; index1 <= counter1; ++index1)
        {
          if (this.frontList.Front[index1].FrontType == 1 | this.frontList.Front[index1].FrontType == 11)
          {
            string str = "FRONT " + this.frontList.Front[index1].FrontID.ToString() + ") : ";
            if (this.frontList.Front[index1].strictHQs.counter >= -1)
            {
              int counter2 = this.frontList.Front[index1].strictHQs.counter;
              for (int index2 = 0; index2 <= counter2; ++index2)
              {
                unitByAiid = this.frontList.Front[index1].strictHQs.unr[index2];
                int num = this.frontList.Front[index1].strictHQs.AIid[index2];
                str = str + this.game.Data.UnitObj[unitByAiid].Name + "(SSHQ-" + num.ToString() + "), ";
              }
              string s = str + " - ";
              if (this.frontList.Front[index1].FrontType == 1)
                s += " , type: FRONTLINE";
              if (this.frontList.Front[index1].FrontType == 2)
                s += " , type: RESERVE";
              if (this.frontList.Front[index1].FrontType == 3)
                s += " , type: RESERVE ARTILLERY";
              if (this.frontList.Front[index1].FrontType == 5)
                s += " , type: AIR COVER";
              if (this.frontList.Front[index1].FrontType == 4)
                s += " , type: AIR SUPPORT";
              if (this.frontList.Front[index1].FrontType == 7)
                s += " , type: AIR TRANSPORT";
              if (this.frontList.Front[index1].FrontType == 6)
                s += " , type: ENGINEER";
              if (this.frontList.Front[index1].FrontType == 8)
                s += " , type: NAVY";
              if (this.frontList.Front[index1].FrontType == 13)
                s += " , type: FLAK FRONT";
              if (this.frontList.Front[index1].FrontType == 9)
                s += " , type: CARGO";
              if (this.frontList.Front[index1].FrontType == 11)
                s += " , type: ENCIRCLED";
              if (this.frontList.Front[index1].FrontType == 12)
                s += " , type: ESCAPE";
              if (this.frontList.Front[index1].FrontType == 10)
                s += " , type: STRATEGIC RESERVE";
              if (this.frontList.Front[index1].TopOperation)
                s += " <<< TOP FRONT (FOR PZ DRIVE) !!! >>>";
              if (this.frontList.Front[index1].FrontType == 1)
              {
                s += " - ";
                if (this.frontList.Front[index1].Stance == 3)
                  s += "ATTACK";
                if (this.frontList.Front[index1].Stance == 2)
                  s += "HOLD";
                if (this.frontList.Front[index1].Stance == 1)
                  s += "RETREAT";
                if (this.frontList.Front[index1].Stance == 4)
                  s += "FULL RETREAT";
                if (this.frontList.Front[index1].RealRetreat)
                  s += " --> REAL RETREAT";
              }
              this.AddLog(s);
            }
          }
        }
      }
      this.AddLog("");
      this.AddLog("---------------------------------DETAIL LOG----");
      int counter3 = this.frontList.Counter;
      for (int index = 0; index <= counter3; ++index)
      {
        for (int counter4 = this.frontList.Front[index].units.counter; counter4 >= 0; counter4 += -1)
        {
          int tunr = this.frontList.Front[index].units.unr[counter4];
          unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index].units.AIid[counter4]);
          if (unitByAiid == -1)
            this.frontList.Front[index].units.removeUnr(tunr);
        }
        for (int counter5 = this.frontList.Front[index].artUnits.counter; counter5 >= 0; counter5 += -1)
        {
          int tunr = this.frontList.Front[index].artUnits.unr[counter5];
          unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index].artUnits.AIid[counter5]);
          if (unitByAiid == -1)
            this.frontList.Front[index].artUnits.removeUnr(tunr);
        }
        for (int counter6 = this.frontList.Front[index].orgUnits.counter; counter6 >= 0; counter6 += -1)
        {
          int tunr = this.frontList.Front[index].orgUnits.unr[counter6];
          unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index].orgUnits.AIid[counter6]);
          if (unitByAiid == -1)
            this.frontList.Front[index].orgUnits.removeUnr(tunr);
        }
      }
      int counter7 = this.frontList.Counter;
      for (int index3 = 0; index3 <= counter7; ++index3)
      {
        string str1 = "";
        string str2 = "";
        string str3 = str1 + "\r\n";
        if (this.frontList.Front[index3].FrontType == 1)
          str3 = " , type: FRONTLINE";
        if (this.frontList.Front[index3].FrontType == 2)
          str3 = " , type: RESERVE";
        if (this.frontList.Front[index3].FrontType == 3)
          str3 = " , type: RESERVE ARTILLERY";
        if (this.frontList.Front[index3].FrontType == 5)
          str3 = " , type: AIR COVER";
        if (this.frontList.Front[index3].FrontType == 4)
          str3 = " , type: AIR SUPPORT";
        if (this.frontList.Front[index3].FrontType == 7)
          str3 = " , type: AIR TRANSPORT";
        if (this.frontList.Front[index3].FrontType == 6)
          str3 = " , type: ENGINEER";
        if (this.frontList.Front[index3].FrontType == 8)
          str3 = " , type: NAVY";
        if (this.frontList.Front[index3].FrontType == 9)
          str3 = " , type: CARGO";
        if (this.frontList.Front[index3].FrontType == 11)
          str3 = " , type: ENCIRCLED";
        if (this.frontList.Front[index3].FrontType == 13)
          str3 = " , type: FLAK FRONT";
        if (this.frontList.Front[index3].FrontType == 12)
          str3 = " , type: ESCAPE";
        if (this.frontList.Front[index3].FrontType == 10)
          str3 = " , type: STRATEGIC RESERVE";
        if (this.frontList.Front[index3].TopOperation)
          str3 += " <<< TOP FRONT (FOR PZ DRIVE) !!! >>>";
        if (this.frontList.Front[index3].FrontType == 1)
        {
          string str4 = str3 + "\r\n" + "(START) STANCE: ";
          if (this.frontList.Front[index3].StartStance == 3)
            str4 += "ATTACK";
          if (this.frontList.Front[index3].StartStance == 2)
            str4 += "HOLD";
          if (this.frontList.Front[index3].StartStance == 1)
            str4 += "RETREAT";
          if (this.frontList.Front[index3].StartStance == 4)
            str4 += "FULL RETREAT";
          str3 = str4 + "\r\n" + "(AFTER STRATEGY) STANCE: ";
          if (this.frontList.Front[index3].Stance == 3)
          {
            str3 += "ATTACK";
            str2 = "ATTACK";
          }
          if (this.frontList.Front[index3].Stance == 2)
          {
            str3 += "HOLD";
            str2 = "HOLD";
          }
          if (this.frontList.Front[index3].Stance == 1)
          {
            str3 += "RETREAT";
            str2 = "RETREAT";
          }
          if (this.frontList.Front[index3].Stance == 4)
          {
            str3 += "FULL RETREAT";
            str2 = "FULL RETREAT";
          }
          if (this.frontList.Front[index3].RealRetreat)
            str3 += " --> REAL RETREAT";
        }
        string str5 = str3 + ", AVG.STRENGTH: " + this.frontList.Front[index3].OrigAverageStrength.ToString() + " , (AFTER STRATEGY: " + this.frontList.Front[index3].AverageStrength.ToString().ToString() + ")";
        if (this.frontList.Front[index3].FrontType == 2 | this.frontList.Front[index3].FrontType == 3 | this.frontList.Front[index3].FrontType == 5 | this.frontList.Front[index3].FrontType == 4)
          str5 = str5 + "\r\n" + "CREATED FROM: " + this.frontList.Front[index3].tempCreatedFromFrontID.ToString() + "\r\n" + "TARGET-FRONT: " + this.frontList.Front[index3].TargetFrontID.ToString() + ", DISTANCE: " + this.frontList.Front[index3].Distance.ToString();
        if (this.frontList.Front[index3].FrontType == 9 | this.frontList.Front[index3].FrontType == 8 | this.frontList.Front[index3].FrontType == 10)
          str5 = str5 + "TARGET-XY: " + this.frontList.Front[index3].targetX.ToString() + "," + this.frontList.Front[index3].targetY.ToString();
        string str6 = str5 + "\r\n" + "OPPORTUNITY: " + this.frontList.Front[index3].OpportunityPercentage.ToString() + " , THREAT: " + this.frontList.Front[index3].ThreatPercentage.ToString() + "\r\n" + "OFFENSIVE.MOD: " + this.frontList.Front[index3].OffensiveModifier.ToString() + "\r\n" + "UNITCOUNT RATIO " + this.frontList.Front[index3].UnitCountRatio.ToString() + "\r\n" + "ENEMY POWER: " + this.frontList.Front[index3].enemyPower.ToString() + "\r\n" + "FrontHexes: " + this.frontList.Front[index3].FrontHexes.ToString() + "\r\n" + "Bridgecount: " + this.frontList.Front[index3].bridgeCount.ToString() + "\r\n" + "VPScoreAveragePercent: " + this.frontList.Front[index3].vpScoreAveragePercent.ToString() + "\r\n" + "HasSupplySource: " + this.frontList.Front[index3].hasSupplySource.ToString() + "\r\n" + "RetreatModAverage: " + this.frontList.Front[index3].retreatAverageScore.ToString() + "\r\n" + "POWER-TO-RESERVE: " + this.frontList.Front[index3].PowerToReserve.ToString() + "\r\n" + "(ORIG)POWER: " + this.frontList.Front[index3].OrigPower.ToString() + "\r\n" + "AVG.PERCENT.OUT.OF.SUPPLY: " + this.frontList.Front[index3].StatAvgPercentageOutOfSupply.ToString() + "\r\n" + "LAST.PERCENT.OUT.OF.SUPPLY: " + this.frontList.Front[index3].StatLastPercentageOutOfSupply.ToString();
        this.AddLog("FRONT " + this.frontList.Front[index3].FrontID.ToString() + str6);
        if (this.frontList.Front[index3].coordCount > -1)
        {
          this.AddLog("---------------------------------bridges-");
          int coordCount = this.frontList.Front[index3].coordCount;
          for (int index4 = 0; index4 <= coordCount; ++index4)
            this.AddLog("Bridge: " + this.frontList.Front[index3].Coords[index4].x.ToString() + ", " + this.frontList.Front[index3].Coords[index4].y.ToString());
        }
        if (this.frontList.Front[index3].units.counter > -1)
        {
          this.AddLog("---------------------------------units-");
          int counter8 = this.frontList.Front[index3].units.counter;
          for (int index5 = 0; index5 <= counter8; ++index5)
          {
            string str7 = "";
            unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index3].units.AIid[index5]);
            this.game.Data.UnitObj[unitByAiid].TempAIString = "(NORM) FRONT: " + this.frontList.Front[index3].FrontID.ToString() + "\r\nSTANCE: " + str2 + "\r\nFROM FRONT: " + this.frontList.Front[index3].tempCreatedFromFrontID.ToString() + "\r\nTO FRONT: " + this.frontList.Front[index3].TargetFrontID.ToString();
            if (this.game.Data.UnitObj[unitByAiid].HQ > -1)
              str7 = this.game.Data.UnitObj[this.game.Data.UnitObj[unitByAiid].HQ].Name + "(SSHQ-" + this.game.Data.UnitObj[unitByAiid].AISubStrictGroup.ToString() + ")" + " - ";
            if (this.game.Data.UnitObj[unitByAiid].TempTopUnit)
              this.AddLog(str7 + this.game.Data.UnitObj[unitByAiid].Name + " (x=" + this.game.Data.UnitObj[unitByAiid].X.ToString() + ",y=" + this.game.Data.UnitObj[unitByAiid].Y.ToString() + "  <<<  TOP UNIT   >>>");
            else
              this.AddLog(str7 + this.game.Data.UnitObj[unitByAiid].Name + " (x=" + this.game.Data.UnitObj[unitByAiid].X.ToString() + ",y=" + this.game.Data.UnitObj[unitByAiid].Y.ToString());
          }
        }
        if (this.frontList.Front[index3].artUnits.counter > -1)
        {
          this.AddLog("---------------------------------art-");
          int counter9 = this.frontList.Front[index3].artUnits.counter;
          for (int index6 = 0; index6 <= counter9; ++index6)
          {
            unitByAiid = this.frontList.Front[index3].artUnits.unr[index6];
            this.game.Data.UnitObj[unitByAiid].TempAIString = "(ART) FRONT: " + this.frontList.Front[index3].FrontID.ToString() + "\r\nSTANCE: " + str2 + "\r\nFROM FRONT: " + this.frontList.Front[index3].tempCreatedFromFrontID.ToString() + "\r\nTO FRONT: " + this.frontList.Front[index3].TargetFrontID.ToString();
            this.AddLog(this.game.Data.UnitObj[unitByAiid].Name + " (x=" + this.game.Data.UnitObj[unitByAiid].X.ToString() + ",y=" + this.game.Data.UnitObj[unitByAiid].Y.ToString());
          }
        }
        if (this.frontList.Front[index3].orgUnits.counter > -1)
        {
          this.AddLog("---------------------------------org-");
          int counter10 = this.frontList.Front[index3].orgUnits.counter;
          for (int index7 = 0; index7 <= counter10; ++index7)
          {
            unitByAiid = this.frontList.Front[index3].orgUnits.unr[index7];
            this.game.Data.UnitObj[unitByAiid].TempAIString = "(ORG) FRONT: " + this.frontList.Front[index3].FrontID.ToString() + "\r\nSTANCE: " + str2 + "\r\nFROM FRONT: " + this.frontList.Front[index3].tempCreatedFromFrontID.ToString() + "\r\nTO FRONT: " + this.frontList.Front[index3].TargetFrontID.ToString();
            this.AddLog(this.game.Data.UnitObj[unitByAiid].Name + " (x=" + this.game.Data.UnitObj[unitByAiid].X.ToString() + ",y=" + this.game.Data.UnitObj[unitByAiid].Y.ToString());
          }
        }
        if (this.frontList.Front[index3].strictHQs.counter > -1)
        {
          this.AddLog("---------------------------------strict HQs-");
          int counter11 = this.frontList.Front[index3].strictHQs.counter;
          for (int index8 = 0; index8 <= counter11; ++index8)
          {
            unitByAiid = this.frontList.Front[index3].strictHQs.unr[index8];
            this.AddLog(this.game.Data.UnitObj[unitByAiid].Name + " (x=" + this.game.Data.UnitObj[unitByAiid].X.ToString() + ",y=" + this.game.Data.UnitObj[unitByAiid].Y.ToString());
          }
        }
        this.AddLog("---------------------------------reserves moving towards front-");
        int counter12 = this.frontList.Counter;
        for (int index9 = 0; index9 <= counter12; ++index9)
        {
          if (this.frontList.Front[index9].TargetFrontID > 0 & this.frontList.Front[index9].TargetFrontID == this.frontList.Front[index3].FrontID)
          {
            int counter13 = this.frontList.Front[index9].units.counter;
            for (int index10 = 0; index10 <= counter13; ++index10)
            {
              string str8 = "";
              if (this.game.Data.UnitObj[unitByAiid].HQ > -1)
                str8 = this.game.Data.UnitObj[this.game.Data.UnitObj[unitByAiid].HQ].Name + "(SSHQ-" + this.game.Data.UnitObj[unitByAiid].AISubStrictGroup.ToString() + ")" + " - ";
              unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index9].units.AIid[index10]);
              if (unitByAiid > -1)
              {
                this.frontList.Front[index9].units.unr[index10] = unitByAiid;
                this.AddLog(str8 + this.game.Data.UnitObj[unitByAiid].Name + " (x=" + this.game.Data.UnitObj[unitByAiid].X.ToString() + ",y=" + this.game.Data.UnitObj[unitByAiid].Y.ToString() + " reserveFront = " + this.frontList.Front[index9].FrontID.ToString());
              }
            }
          }
        }
        this.AddLog("-------------------------------------------------------");
      }
      this.WriteLog(extraInfo);
      this.ClearLog();
    }

    public void AddLog(string s)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      ++this.LogCounter;
      if (this.LogTxt.GetUpperBound(0) < this.LogCounter)
        this.LogTxt = (string[]) Utils.CopyArray((Array) this.LogTxt, (Array) new string[this.LogCounter + 1000 + 1]);
      this.LogTxt[this.LogCounter] = s;
    }

    public void ClearLog()
    {
      this.LogCounter = -1;
      this.LogTxt = new string[1];
    }

    public void WriteLog(string name)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      StreamWriter text;
      if (DrawMod.TGame.Data.Product > 6)
        text = File.CreateText(this.game.AppPath + "logs/ai_" + Conversion.Str((object) this.game.Data.Turn) + "_" + name + ".txt");
      else
        text = File.CreateText(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_ai_" + Conversion.Str((object) this.game.Data.Turn) + "_" + name + ".txt");
      int logCounter = this.LogCounter;
      for (int index = 0; index <= logCounter; ++index)
        text.WriteLine(this.LogTxt[index]);
      text.Close();
    }

    public void AppendLog(string filename, string texty)
    {
      if (!this.game.SuperAdminRights)
        return;
      filename += this.game.Data.GameID.ToString();
      StreamWriter streamWriter = File.Exists(this.game.AppPath + "logs/" + filename + ".txt") ? File.AppendText(this.game.AppPath + "logs/" + filename + ".txt") : File.CreateText(this.game.AppPath + "logs/" + filename + ".txt");
      streamWriter.WriteLine(texty);
      streamWriter.Close();
    }

    public void Screenshot(
      string fileextension,
      ref int[,] tObj,
      bool useFullMapGfx = true,
      int left = 0,
      int top = 0)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      FileStream fileStream;
      try
      {
        fileStream = new FileStream(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_screenshot_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + "_" + fileextension + ".jpg", FileMode.Create);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        fileextension = "name error";
        fileStream = new FileStream(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_screenshot_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + "_" + fileextension + ".jpg", FileMode.Create);
        ProjectData.ClearProjectError();
      }
      try
      {
        Bitmap bitmap;
        if (useFullMapGfx)
        {
          bitmap = new Bitmap(this.game.Data.MapObj[0].MapWidth * 40 + 80, this.game.Data.MapObj[0].MapHeight * 32 + 68, PixelFormat.Format24bppRgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        else
        {
          bitmap = new Bitmap(tObj.GetUpperBound(0) * 40 + 80, tObj.GetUpperBound(1) * 32 + 68, PixelFormat.Format24bppRgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        Graphics Expression = Graphics.FromImage((Image) bitmap);
        DrawMod.DrawText(ref Expression, "Matrix", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        if (useFullMapGfx)
        {
          this.Screenshotgrid(ref Expression, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
          this.Screenshot1(ref Expression, ref tObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
        }
        else
        {
          this.Screenshotgrid(ref Expression, tObj.GetUpperBound(0), tObj.GetUpperBound(1), left, top);
          this.Screenshot1(ref Expression, ref tObj, tObj.GetUpperBound(0), tObj.GetUpperBound(1));
        }
        if (!Information.IsNothing((object) Expression))
        {
          Expression.Dispose();
          Expression = (Graphics) null;
        }
        bitmap.Save((Stream) fileStream, ImageFormat.Jpeg);
        fileStream.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        fileStream.Close();
        ProjectData.ClearProjectError();
      }
    }

    public void ScreenshotSpecial(
      string fileextension,
      ref int[,] tTroops,
      ref int[,] tOwn,
      bool useFullMapGfx = true,
      int left = 0,
      int top = 0)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      FileStream fileStream;
      try
      {
        fileStream = new FileStream(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_screenshot_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + "_" + fileextension + ".jpg", FileMode.Create);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        fileextension = "name error";
        fileStream = new FileStream(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_screenshot_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + "_" + fileextension + ".jpg", FileMode.Create);
        ProjectData.ClearProjectError();
      }
      try
      {
        Bitmap bitmap;
        if (useFullMapGfx)
        {
          bitmap = new Bitmap(this.game.Data.MapObj[0].MapWidth * 40 + 80, this.game.Data.MapObj[0].MapHeight * 32 + 68, PixelFormat.Format24bppRgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        else
        {
          bitmap = new Bitmap(tOwn.GetUpperBound(0) * 40 + 80, tOwn.GetUpperBound(1) * 32 + 68, PixelFormat.Format24bppRgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        Graphics Expression = Graphics.FromImage((Image) bitmap);
        DrawMod.DrawText(ref Expression, "Matrix", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        if (useFullMapGfx)
        {
          this.Screenshotgrid(ref Expression, tOwn.GetUpperBound(0), tOwn.GetUpperBound(1), left, top);
          this.ScreenshotSpecialDetail(ref Expression, ref tTroops, ref tOwn, tOwn.GetUpperBound(0), tOwn.GetUpperBound(1));
        }
        else
        {
          this.Screenshotgrid(ref Expression, tOwn.GetUpperBound(0), tOwn.GetUpperBound(1), left, top);
          this.ScreenshotSpecialDetail(ref Expression, ref tTroops, ref tOwn, tOwn.GetUpperBound(0), tOwn.GetUpperBound(1));
        }
        if (!Information.IsNothing((object) Expression))
        {
          Expression.Dispose();
          Expression = (Graphics) null;
        }
        bitmap.Save((Stream) fileStream, ImageFormat.Jpeg);
        fileStream.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        fileStream.Close();
        ProjectData.ClearProjectError();
      }
    }

    public void ScreenshotSpecial2(
      string fileextension,
      ref int[,] tTroops,
      ref int[,] tOwn,
      ref int[,] tFronts)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      bool flag = true;
      FileStream fileStream;
      try
      {
        fileStream = new FileStream(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_screenshot_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + "_" + fileextension + ".jpg", FileMode.Create);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        fileextension = "name error";
        fileStream = new FileStream(this.game.AppPath + "logs/" + this.SYSTEM_VAR_RUN_NUMBER.ToString() + "_screenshot_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + "_" + fileextension + ".jpg", FileMode.Create);
        ProjectData.ClearProjectError();
      }
      try
      {
        Bitmap bitmap;
        if (flag)
        {
          bitmap = new Bitmap(this.game.Data.MapObj[0].MapWidth * 40 + 80, this.game.Data.MapObj[0].MapHeight * 32 + 68, PixelFormat.Format24bppRgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        else
        {
          bitmap = new Bitmap(tOwn.GetUpperBound(0) * 40 + 80, tOwn.GetUpperBound(1) * 32 + 68, PixelFormat.Format24bppRgb);
          bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        }
        Graphics Expression = Graphics.FromImage((Image) bitmap);
        DrawMod.DrawText(ref Expression, "Matrix", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        if (flag)
        {
          this.Screenshotgrid(ref Expression, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
          this.ScreenshotSpecialDetail2(ref Expression, ref tTroops, ref tOwn, tFronts, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
        }
        if (!Information.IsNothing((object) Expression))
        {
          Expression.Dispose();
          Expression = (Graphics) null;
        }
        bitmap.Save((Stream) fileStream, ImageFormat.Jpeg);
        fileStream.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        fileStream.Close();
        ProjectData.ClearProjectError();
      }
    }

    public void Screenshotgrid(ref Graphics g, int width, int height, int left, int top)
    {
      int num1 = width;
      for (int tx = 0; tx <= num1; ++tx)
      {
        int num2 = height;
        for (int index = 0; index <= num2; ++index)
        {
          CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
          int realX = this.GetRealX(tx, left);
          int cy = index + top;
          Bitmap bitmap = (Bitmap) null;
          ref Bitmap local1 = ref bitmap;
          bool flag = false;
          ref bool local2 = ref flag;
          Bitmap objBitmap = customBitmapObj.DrawHex(realX, cy, 0, neverusehistory: true, gBitmap: (ref local1), tFromMapPopup: (ref local2));
          if (tx == 0 | tx % 2 == 0)
          {
            DrawMod.DrawScaled(ref g, ref objBitmap, tx * 40, index * 32, 40, 32);
            DrawMod.DrawRectangle(ref g, tx * 40, index * 32, 40, 32, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          }
          else
          {
            DrawMod.DrawScaled(ref g, ref objBitmap, tx * 40, index * 32 + 16, 40, 32);
            DrawMod.DrawRectangle(ref g, tx * 40, index * 32 + 16, 40, 32, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          }
        }
      }
    }

    public void Screenshot1(ref Graphics g, ref int[,] tObj, int width, int height)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int num1 = width;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = height;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          string tstring = Conversion.Str((object) tObj[index1, index2]);
          if (tObj[index1, index2] > 1000000)
            tstring = "Z-" + Strings.Trim(Conversion.Str((object) (tObj[index1, index2] - 1000000)));
          if (index1 == 0 | index1 % 2 == 0)
            DrawMod.DrawTextOutline(ref g, tstring, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
          else
            DrawMod.DrawTextOutline(ref g, tstring, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
        }
      }
    }

    public void ScreenshotSpecialDetail(
      ref Graphics g,
      ref int[,] ttroops,
      ref int[,] tOwn,
      int width,
      int height)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      g.SmoothingMode = SmoothingMode.None;
      int num1 = width;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = height;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          if (index1 == 0 | index1 % 2 == 0)
          {
            if (ttroops[index1, index2] > 0)
            {
              if (tOwn[index1, index2] == 1)
                DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.White);
              else
                DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.Yellow);
            }
            else if (tOwn[index1, index2] == 1)
              DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.White);
            else
              DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.Yellow);
          }
          else if (ttroops[index1, index2] > 0)
          {
            if (tOwn[index1, index2] == 1)
              DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.White);
            else
              DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.Yellow);
          }
          else if (tOwn[index1, index2] == 1)
            DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.White);
          else
            DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.Yellow);
        }
      }
    }

    public void ScreenshotSpecialDetail2(
      ref Graphics g,
      ref int[,] ttroops,
      ref int[,] tOwn,
      int[,] tFronts,
      int width,
      int height)
    {
      if (!this.VAR_DEBUG_ON)
        return;
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      g.SmoothingMode = SmoothingMode.None;
      int num1 = width;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = height;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          if (index1 == 0 | index1 % 2 == 0)
          {
            if (ttroops[index1, index2] > 0)
            {
              if (tOwn[index1, index2] == 1)
                DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.White);
              else
                DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.Yellow);
            }
            else if (tOwn[index1, index2] == 1)
              DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.White);
            else
              DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2, Color.Yellow);
            if (tFronts[index1, index2] > 0)
              DrawMod.DrawTextColoured(ref g, tFronts[index1, index2].ToString(), new Font(this.game.FontCol.Families[1], 12f, FontStyle.Regular, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 18, Color.Black);
          }
          else
          {
            if (ttroops[index1, index2] > 0)
            {
              if (tOwn[index1, index2] == 1)
                DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.White);
              else
                DrawMod.DrawTextColouredOutline(ref g, Conversion.Str((object) ttroops[index1, index2]), new Font(this.game.FontCol.Families[1], 18f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.Yellow);
            }
            else if (tOwn[index1, index2] == 1)
              DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.White);
            else
              DrawMod.DrawTextColouredOutline(ref g, "*", new Font(this.game.FontCol.Families[1], 24f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16, Color.Yellow);
            if (tFronts[index1, index2] > 0)
              DrawMod.DrawTextColoured(ref g, tFronts[index1, index2].ToString(), new Font(this.game.FontCol.Families[1], 12f, FontStyle.Regular, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 18 + 16, Color.Black);
          }
        }
      }
    }

    public AIMatrix SetSeaIDMatrix(bool needsPort = true)
    {
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      int num1 = 0;
      bool flag1 = true;
      while (flag1)
      {
        flag1 = false;
        int mapWidth1 = this.map.MapWidth;
        for (int x = 0; x <= mapWidth1; ++x)
        {
          int mapHeight1 = this.map.MapHeight;
          for (int y = 0; y <= mapHeight1; ++y)
          {
            if (aiMatrix1.Value[x, y] == 0 && this.game.HandyFunctionsObj.IsHexPort(x, y, 0) | !needsPort && this.game.HandyFunctionsObj.IsHexHarbourOrSea(x, y, 0) & (this.game.HandyFunctionsObj.IsHexNextToSea(x, y, 0) | !needsPort))
            {
              ++num1;
              aiMatrix1.Value[x, y] = num1;
              int num2 = 0;
              flag1 = true;
              DC2AIClass tai2 = this;
              AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
              while (num2 >= 0)
              {
                bool flag2 = false;
                int mapWidth2 = this.map.MapWidth;
                for (int cx = 0; cx <= mapWidth2; ++cx)
                {
                  int mapHeight2 = this.map.MapHeight;
                  for (int cy = 0; cy <= mapHeight2; ++cy)
                  {
                    if (aiMatrix1.Value[cx, cy] == num1 & aiMatrix2.Value[cx, cy] == num2)
                    {
                      int tfacing = 1;
                      do
                      {
                        Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                        if (coordinate.onmap && aiMatrix1.Value[coordinate.x, coordinate.y] == 0 && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, 0) & (this.game.HandyFunctionsObj.IsHexNextToSea(coordinate.x, coordinate.y, 0) | !needsPort))
                        {
                          aiMatrix1.Value[coordinate.x, coordinate.y] = num1;
                          aiMatrix2.Value[coordinate.x, coordinate.y] = num2 + 1;
                          flag2 = true;
                        }
                        ++tfacing;
                      }
                      while (tfacing <= 6);
                    }
                  }
                }
                ++num2;
                if (!flag2)
                  num2 = -99;
              }
            }
          }
        }
      }
      return aiMatrix1;
    }

    public AIMatrix SetLandIDMatrix()
    {
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      int num1 = 0;
      bool flag1 = true;
      while (flag1)
      {
        flag1 = false;
        int mapWidth1 = this.map.MapWidth;
        for (int x = 0; x <= mapWidth1; ++x)
        {
          int mapHeight1 = this.map.MapHeight;
          for (int y = 0; y <= mapHeight1; ++y)
          {
            if (aiMatrix1.Value[x, y] == 0 && !this.game.HandyFunctionsObj.IsHexHarbourOrSea(x, y, 0))
            {
              ++num1;
              aiMatrix1.Value[x, y] = num1;
              int num2 = 0;
              flag1 = true;
              DC2AIClass tai2 = this;
              AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
              while (num2 >= 0)
              {
                bool flag2 = false;
                int mapWidth2 = this.map.MapWidth;
                for (int cx = 0; cx <= mapWidth2; ++cx)
                {
                  int mapHeight2 = this.map.MapHeight;
                  for (int cy = 0; cy <= mapHeight2; ++cy)
                  {
                    if (aiMatrix1.Value[cx, cy] == num1 & aiMatrix2.Value[cx, cy] == num2)
                    {
                      int tfacing = 1;
                      do
                      {
                        Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                        if (coordinate.onmap && aiMatrix1.Value[coordinate.x, coordinate.y] == 0 && !this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, 0))
                        {
                          aiMatrix1.Value[coordinate.x, coordinate.y] = num1;
                          aiMatrix2.Value[coordinate.x, coordinate.y] = num2 + 1;
                          flag2 = true;
                        }
                        ++tfacing;
                      }
                      while (tfacing <= 6);
                    }
                  }
                }
                ++num2;
                if (!flag2)
                  num2 = -99;
              }
            }
          }
        }
      }
      return aiMatrix1;
    }

    public void SetTroopsAndAPMatrix(
      ref AIMatrix troops,
      ref AIMatrix move,
      int width,
      int height,
      int left,
      int top,
      ref AIFrontList tfrontList,
      int onlyUnitsWithFrontID = -1,
      bool absPower = false,
      bool onlyUnitsInCorrectFrontArea = false,
      AIMatrix tfrontArea = null,
      int allowFrontIDoutsideCorrectFrontArea = -1)
    {
      ref AIMatrix local1 = ref troops;
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1, width, height, top, left);
      local1 = aiMatrix1;
      ref AIMatrix local2 = ref move;
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2, width, height, top, left);
      local2 = aiMatrix2;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1)
        {
          int index1 = this.GetMatrixX(this.game.Data.UnitObj[unr].X, left);
          int y1 = this.game.Data.UnitObj[unr].Y - top;
          float num1 = 1f;
          if (index1 == 22 & y1 == 42)
            index1 = index1;
          if (index1 >= 0 & y1 >= 0 & index1 <= width & y1 <= height)
          {
            int num2 = 1;
            if (!Information.IsNothing((object) tfrontList) && this.game.Data.UnitObj[unr].AIGroup > 0)
            {
              if (tfrontList.FindFront(this.game.Data.UnitObj[unr].AIGroup).FrontType == 2 & tfrontList.FindFront(this.game.Data.UnitObj[unr].AIGroup).TargetFrontID > 0)
              {
                Coordinate averageFrontCoordinate = tfrontList.Front[tfrontList.GetFrontNr(tfrontList.FindFront(this.game.Data.UnitObj[unr].AIGroup).TargetFrontID)].GetAverageFrontCoordinate();
                averageFrontCoordinate.x = this.GetMatrixX(averageFrontCoordinate.x, left);
                averageFrontCoordinate.y -= top;
                if (averageFrontCoordinate.onmap)
                {
                  if (this.game.HandyFunctionsObj.Distance(index1, y1, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0, 19) <= 4)
                    num1 /= 2f;
                  else if (this.game.HandyFunctionsObj.Distance(index1, y1, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0, 19) <= 10)
                    num1 /= 5f;
                  else if (this.game.HandyFunctionsObj.Distance(index1, y1, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0, 19) <= 16)
                    num1 /= 10f;
                  else
                    num2 = 0;
                }
                else
                  num2 = 0;
              }
              if (tfrontList.FindFront(this.game.Data.UnitObj[unr].AIGroup).FrontType == 10)
                num1 /= 3f;
            }
            if (onlyUnitsWithFrontID > -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIGroup != onlyUnitsWithFrontID)
              num1 /= 3f;
            if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
            {
              if (onlyUnitsInCorrectFrontArea & allowFrontIDoutsideCorrectFrontArea > -1)
              {
                if (num2 == 1 & this.frontMatrix.Value[this.GetRealX(index1, left), y1 + top] != this.game.Data.UnitObj[unr].AIGroup & tfrontArea.Value[index1, y1] != this.game.Data.UnitObj[unr].AIGroup && allowFrontIDoutsideCorrectFrontArea == tfrontArea.Value[index1, y1])
                {
                  if (this.game.Data.UnitObj[unr].AIGroup != allowFrontIDoutsideCorrectFrontArea)
                  {
                    if (this.game.Data.UnitObj[unr].DidMove | this.game.Data.UnitObj[unr].DidAttack)
                      num1 /= 3f;
                    else
                      num1 /= 10f;
                  }
                  else
                    num2 = num2;
                }
              }
              else if (onlyUnitsInCorrectFrontArea && num2 == 1 & tfrontArea.Value[index1, y1] != this.game.Data.UnitObj[unr].AIGroup)
                num1 /= 4f;
            }
            if (this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn)
              num2 = 1;
            if (this.game.Data.Product != 6)
            {
              if (this.game.Data.UnitObj[unr].TempCategory != 1 && this.game.Data.UnitObj[unr].TempCategory != 2 && this.game.Data.UnitObj[unr].TempCategory != 5)
                num2 = 0;
              if (this.game.Data.Product == 7 && this.game.Data.UnitObj[unr].IsHQ)
                num2 = 0;
            }
            else if (this.game.Data.UnitObj[unr].IsHQ)
              num2 = 0;
            if (num2 == 1)
            {
              int num3;
              if (absPower)
              {
                num3 = this.game.Data.UnitObj[unr].TempUnitPowerAbs;
              }
              else
              {
                int num4 = (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPowerAbs * ((double) this.game.Data.UnitObj[unr].SupplyConsume / 100.0));
                int num5 = num4 + (int) Math.Round((double) num4 * ((double) this.game.HandyFunctionsObj.GetAverageDefensiveMod(unr) / 100.0));
                num3 = num5 + (int) Math.Round((double) num5 * ((double) this.game.HandyFunctionsObj.GetAverageOffensiveMod(unr) / 100.0));
                if (this.game.Data.UnitObj[unr].TempTopUnit)
                  num3 = (int) Math.Round((double) num3 * 1.25);
              }
              int num6 = (int) Math.Round((double) ((float) num3 * num1)) + 10;
              int[,] numArray1 = troops.Value;
              int[,] numArray2 = numArray1;
              int index2 = index1;
              int index3 = index2;
              int index4 = y1;
              int index5 = index4;
              int num7 = numArray1[index2, index4] + num6;
              numArray2[index3, index5] = num7;
              if (this.game.Data.Product == 6)
              {
                int num8 = this.game.Data.UnitObj[unr].TempUnitAP;
                if (this.game.Data.UnitObj[unr].DidMove | num8 < 50)
                  num8 = 0;
                int[,] numArray3 = move.Value;
                int[,] numArray4 = numArray3;
                int index6 = index1;
                int index7 = index6;
                int index8 = y1;
                int index9 = index8;
                int num9 = numArray3[index6, index8] + num6 * num8;
                numArray4[index7, index9] = num9;
              }
            }
          }
        }
      }
    }

    public void SetTroopsWithOwnTempPower(
      ref AIMatrix troops,
      int width,
      int height,
      int left,
      int top,
      bool absPower)
    {
      ref AIMatrix local = ref troops;
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, width, height, top, left);
      local = aiMatrix;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].X > -1)
        {
          int num1 = this.GetMatrixX(this.game.Data.UnitObj[index1].X, left);
          int num2 = this.game.Data.UnitObj[index1].Y - top;
          if (num1 == 22 & num2 == 42)
            num1 = num1;
          if (num1 >= 0 & num2 >= 0 & num1 <= width & num2 <= height)
          {
            int num3 = 1;
            if (this.game.Data.UnitObj[index1].Regime != this.game.Data.Turn)
              num3 = 1;
            if (this.game.Data.UnitObj[index1].TempCategory != 1 && this.game.Data.UnitObj[index1].TempCategory != 2)
              num3 = 0;
            if (num3 == 1)
            {
              int num4 = (!absPower ? this.game.Data.UnitObj[index1].TempUnitPower : this.game.Data.UnitObj[index1].TempUnitPowerAbs) + 5;
              int[,] numArray1 = troops.Value;
              int[,] numArray2 = numArray1;
              int index2 = num1;
              int index3 = index2;
              int index4 = num2;
              int index5 = index4;
              int num5 = numArray1[index2, index4] + num4;
              numArray2[index3, index5] = num5;
            }
          }
        }
      }
    }

    public AIMatrix SetEnemyPressureMatrix(
      AIMatrix owner,
      AIMatrix troops,
      AIMatrix front,
      int frontID)
    {
      MapClass mapClass = this.game.Data.MapObj[0];
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, owner.Width, owner.Height, owner.Top, owner.Left);
      int width = owner.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = owner.Height;
        for (int index2 = 0; index2 <= height; ++index2)
        {
          bool flag = false;
          if (frontID > 0)
          {
            if (front.Value[index1, index2] == frontID)
              flag = true;
          }
          else
            flag = true;
          if (flag & owner.Value[index1, index2] == 1 && this.game.Data.LandscapeTypeObj[mapClass.HexObj[index1, index2].LandscapeType].AIBlock < 1)
          {
            int num1 = 0;
            int index3 = 0;
            do
            {
              if (this.TempHexNeighbour[index1, index2, index3].onmap)
              {
                Coordinate coordinate1 = this.TempHexNeighbour[index1, index2, index3];
                if (coordinate1.x <= owner.Width & coordinate1.y <= owner.Height && owner.Value[coordinate1.x, coordinate1.y] == 2 | owner.Value[coordinate1.x, coordinate1.y] == 0 && this.game.Data.LandscapeTypeObj[mapClass.HexObj[this.GetRealX(coordinate1.x, owner.Left), coordinate1.y + owner.Top].LandscapeType].AIBlock < 1 && !this.game.Data.LandscapeTypeObj[mapClass.HexObj[this.GetRealX(coordinate1.x, owner.Left), coordinate1.y + owner.Top].LandscapeType].IsSea)
                {
                  int num2 = 0;
                  int index4 = 0;
                  do
                  {
                    if (this.TempHexNeighbour[coordinate1.x, coordinate1.y, index4].onmap)
                    {
                      Coordinate coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index4];
                      if (coordinate2.x <= owner.Width & coordinate2.y < owner.Height && owner.Value[coordinate2.x, coordinate2.y] == 1)
                        ++num2;
                    }
                    ++index4;
                  }
                  while (index4 <= 5);
                  int num3 = (int) Math.Round((double) troops.Value[coordinate1.x, coordinate1.y] / (double) num2);
                  if (num3 > 0)
                    ++num1;
                  if (troops.Value[coordinate1.x, coordinate1.y] > 0 & num3 == 0)
                    num3 = 1;
                  int[,] numArray1 = aiMatrix.Value;
                  int[,] numArray2 = numArray1;
                  int index5 = index1;
                  int index6 = index5;
                  int index7 = index2;
                  int index8 = index7;
                  int num4 = numArray1[index5, index7] + num3;
                  numArray2[index6, index8] = num4;
                }
              }
              ++index3;
            }
            while (index3 <= 5);
            if (num1 > 5)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.25);
            else if (num1 > 4)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.34);
            else if (num1 > 3)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.5);
            else if (num1 > 2)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.64);
            else if (num1 > 1)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.8);
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetEnemyPressureMatrixIncludingThroughOwn(
      AIMatrix owner,
      AIMatrix troops,
      AIMatrix front,
      int frontID)
    {
      MapClass mapClass = this.game.Data.MapObj[0];
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, owner.Width, owner.Height, owner.Top, owner.Left);
      int width = owner.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = owner.Height;
        for (int index2 = 0; index2 <= height; ++index2)
        {
          if (front.Value[index1, index2] == frontID && this.game.Data.LandscapeTypeObj[mapClass.HexObj[index1, index2].LandscapeType].AIBlock < 1)
          {
            int num1 = 0;
            int index3 = 0;
            do
            {
              if (this.TempHexNeighbour[index1, index2, index3].onmap)
              {
                Coordinate coordinate1 = this.TempHexNeighbour[index1, index2, index3];
                if (coordinate1.x <= owner.Width & coordinate1.y <= owner.Height && owner.Value[coordinate1.x, coordinate1.y] == 2 | owner.Value[coordinate1.x, coordinate1.y] == 0 && this.game.Data.LandscapeTypeObj[mapClass.HexObj[this.GetRealX(coordinate1.x, owner.Left), coordinate1.y + owner.Top].LandscapeType].AIBlock < 1 && !this.game.Data.LandscapeTypeObj[mapClass.HexObj[this.GetRealX(coordinate1.x, owner.Left), coordinate1.y + owner.Top].LandscapeType].IsSea)
                {
                  int num2 = 6;
                  int index4 = 0;
                  do
                  {
                    if (this.TempHexNeighbour[coordinate1.x, coordinate1.y, index4].onmap)
                    {
                      Coordinate coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index4];
                      if (coordinate2.x <= owner.Width & coordinate2.y < owner.Height)
                        ++num2;
                    }
                    ++index4;
                  }
                  while (index4 <= 5);
                  int num3 = (int) Math.Round((double) troops.Value[coordinate1.x, coordinate1.y] / (double) num2);
                  if (num3 > 0)
                    ++num1;
                  if (troops.Value[coordinate1.x, coordinate1.y] > 0 & num3 == 0)
                    num3 = 1;
                  int[,] numArray1 = aiMatrix.Value;
                  int[,] numArray2 = numArray1;
                  int index5 = index1;
                  int index6 = index5;
                  int index7 = index2;
                  int index8 = index7;
                  int num4 = numArray1[index5, index7] + num3;
                  numArray2[index6, index8] = num4;
                  int num5 = owner.Value[index1, index2] == 2 & troops.Value[index1, index2] > aiMatrix.Value[index1, index2] ? 1 : 0;
                }
              }
              ++index3;
            }
            while (index3 <= 5);
            if (num1 > 5)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.25);
            else if (num1 > 4)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.34);
            else if (num1 > 3)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.5);
            else if (num1 > 2)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.64);
            else if (num1 > 1)
              aiMatrix.Value[index1, index2] = (int) Math.Round((double) aiMatrix.Value[index1, index2] * 0.8);
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetVPMatrix()
    {
      MapClass mapClass = this.game.Data.MapObj[0];
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int width = aiMatrix.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = aiMatrix.Height;
        for (int index2 = 0; index2 <= height; ++index2)
          aiMatrix.Value[index1, index2] = Math.Min(15, mapClass.HexObj[index1, index2].VP);
      }
      aiMatrix.ExpandAndRemoveValueForAnyRegime(15);
      return aiMatrix;
    }

    public AIMatrix SetEnemyPressureFullMatrix(
      AIMatrix owner,
      AIMatrix troops,
      AIMatrix front,
      int frontID)
    {
      MapClass mapClass = this.game.Data.MapObj[0];
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai, owner.Width, owner.Height, owner.Top, owner.Left);
      AIMatrix aiMatrix2 = this.SetEnemyPressureMatrix(owner, troops, front, frontID);
      aiMatrix2.ExpandValueForSameRegime();
      return aiMatrix2;
    }

    public AIMatrix SetEnemyPressureFullMatrixThroughOwn(
      AIMatrix owner,
      AIMatrix troops,
      AIMatrix front,
      int frontID)
    {
      MapClass mapClass = this.game.Data.MapObj[0];
      DC2AIClass tai = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai, owner.Width, owner.Height, owner.Top, owner.Left);
      AIMatrix aiMatrix2 = this.SetEnemyPressureMatrixIncludingThroughOwn(owner, troops, front, frontID);
      aiMatrix2.ExpandValueForSameRegime();
      return aiMatrix2;
    }

    public AIMatrix SetFriendlyPressureMatrix(AIMatrix owner, AIMatrix troops)
    {
      MapClass mapClass = this.game.Data.MapObj[0];
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = mapClass.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = mapClass.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (owner.Value[index1, index2] == 2 | owner.Value[index1, index2] == 1)
          {
            int index3 = 0;
            do
            {
              if (this.TempHexNeighbour[index1, index2, index3].onmap)
              {
                Coordinate coordinate1 = this.TempHexNeighbour[index1, index2, index3];
                if (owner.Value[coordinate1.x, coordinate1.y] == 1 | owner.Value[coordinate1.x, coordinate1.y] == 3 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.GetRealX(coordinate1.x, owner.Left), coordinate1.y + owner.Top].LandscapeType].AIBlock < 1)
                {
                  int num1 = 0;
                  int index4 = 0;
                  do
                  {
                    if (this.TempHexNeighbour[coordinate1.x, coordinate1.y, index4].onmap)
                    {
                      Coordinate coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index4];
                      if (owner.Value[coordinate2.x, coordinate2.y] == 2)
                        ++num1;
                    }
                    ++index4;
                  }
                  while (index4 <= 5);
                  if (num1 < 1)
                    num1 = 1;
                  int num2 = (int) Math.Round((double) troops.Value[coordinate1.x, coordinate1.y] / (double) num1) + num1;
                  if (owner.Value[index1, index2] == 1)
                    num2 = (int) Math.Round((double) num2 / 2.0);
                  int[,] numArray1 = aiMatrix.Value;
                  int[,] numArray2 = numArray1;
                  int index5 = index1;
                  int index6 = index5;
                  int index7 = index2;
                  int index8 = index7;
                  int num3 = numArray1[index5, index7] + num2;
                  numArray2[index6, index8] = num3;
                }
              }
              ++index3;
            }
            while (index3 <= 5);
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetFriendlyBottleNeckMatrix(
      AIFront front,
      AIMatrix tSupply,
      AIMatrix tOwner,
      bool ownFrontUnitsOnly,
      int FuzzyHexRange)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, tSupply.Width, tSupply.Height, tSupply.Top, tSupply.Left);
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        int index2 = index1;
        if (index2 > -1)
        {
          int num1 = 0;
          if (Information.IsNothing((object) front))
          {
            if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index2].X >= tSupply.Left & this.game.Data.UnitObj[index2].Y >= tSupply.Top && this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left) <= tSupply.Width & this.game.Data.UnitObj[index2].Y <= tSupply.Top + tSupply.Height)
              num1 = 1;
          }
          else if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index2].AIGroup > 0 && this.game.Data.UnitObj[index2].X >= tSupply.Left & this.game.Data.UnitObj[index2].Y >= tSupply.Top && this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left) <= tSupply.Width & this.game.Data.UnitObj[index2].Y <= tSupply.Top + tSupply.Height && !ownFrontUnitsOnly | this.game.Data.UnitObj[index2].AIGroup == front.FrontID)
            num1 = 1;
          if (num1 == 1)
          {
            Coordinate coordinate1 = new Coordinate();
            coordinate1.x = this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left);
            coordinate1.y = this.game.Data.UnitObj[index2].Y - tSupply.Top;
            coordinate1.onmap = true;
            while (coordinate1.onmap)
            {
              int num2 = tSupply.Value[coordinate1.x, coordinate1.y];
              int index3 = 0;
              int x;
              int y;
              do
              {
                Coordinate coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index3];
                if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tSupply.Value[coordinate2.x, coordinate2.y] < num2)
                {
                  num2 = tSupply.Value[coordinate2.x, coordinate2.y];
                  x = coordinate2.x;
                  y = coordinate2.y;
                }
                ++index3;
              }
              while (index3 <= 5);
              if (num2 < tSupply.Value[coordinate1.x, coordinate1.y])
              {
                int[,] numArray1 = aiMatrix.Value;
                int[,] numArray2 = numArray1;
                int index4 = x;
                int index5 = index4;
                int index6 = y;
                int index7 = index6;
                int num3 = numArray1[index4, index6] + this.game.Data.UnitObj[index2].TempUnitPowerAbs;
                numArray2[index5, index7] = num3;
                coordinate1.x = x;
                coordinate1.y = y;
                coordinate1.onmap = true;
              }
              else
                coordinate1.onmap = false;
            }
          }
        }
      }
      if (FuzzyHexRange > 0)
        aiMatrix = aiMatrix.AverageValuesForAnyRegime(FuzzyHexRange);
      aiMatrix.Percentify();
      return aiMatrix;
    }

    public AIMatrix SetEnemyBottleNeckMatrix(
      AIFront front,
      AIMatrix frontArea,
      AIMatrix tSupply,
      AIMatrix tOwner,
      bool ownFrontUnitsOnly,
      int FuzzyHexRange)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, tSupply.Width, tSupply.Height, tSupply.Top, tSupply.Left);
      int d = 0;
      int num1 = 0;
      int counter = front.units.counter;
      for (int index = 0; index <= counter; ++index)
      {
        ++d;
        int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index]);
        if (unitByAiid > -1)
        {
          num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
          ++d;
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      Coordinate coordinate1;
      Coordinate coordinate2;
      int x1;
      int y1;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        int index2 = index1;
        if (index2 > -1 && this.game.Data.UnitObj[index2].Regime != this.game.Data.Turn && this.game.Data.UnitObj[index2].X >= tSupply.Left & this.game.Data.UnitObj[index2].Y >= tSupply.Top && this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left) <= tSupply.Width & this.game.Data.UnitObj[index2].Y <= tSupply.Top + tSupply.Height)
        {
          coordinate1 = new Coordinate();
          coordinate1.x = this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left);
          coordinate1.y = this.game.Data.UnitObj[index2].Y - tSupply.Top;
          coordinate1.onmap = true;
          num1 += this.game.Data.UnitObj[index2].TempUnitPowerAbs;
          ++d;
          if (!ownFrontUnitsOnly | frontArea.Value[coordinate1.x, coordinate1.y] == front.FrontID)
          {
            while (coordinate1.onmap)
            {
              int num2 = tSupply.Value[coordinate1.x, coordinate1.y];
              int index3 = 0;
              do
              {
                coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index3];
                if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tSupply.Value[coordinate2.x, coordinate2.y] < num2)
                {
                  num2 = tSupply.Value[coordinate2.x, coordinate2.y];
                  x1 = coordinate2.x;
                  y1 = coordinate2.y;
                }
                ++index3;
              }
              while (index3 <= 5);
              if (num2 < tSupply.Value[coordinate1.x, coordinate1.y])
              {
                int[,] numArray1 = aiMatrix.Value;
                int[,] numArray2 = numArray1;
                int index4 = x1;
                int index5 = index4;
                int index6 = y1;
                int index7 = index6;
                int num3 = numArray1[index4, index6] + this.game.Data.UnitObj[index2].TempUnitPowerAbs;
                numArray2[index5, index7] = num3;
                coordinate1.x = x1;
                coordinate1.y = y1;
                coordinate1.onmap = true;
              }
              else
                coordinate1.onmap = false;
            }
          }
        }
      }
      if (this.game.Data.Product == 6)
      {
        int num4 = d <= 0 ? 6000 : (int) Math.Round((double) num1 / (double) d * Math.Sqrt((double) d));
        int num5 = 0;
        int width = tSupply.Width;
        for (int index8 = 0; index8 <= width; ++index8)
        {
          int height = tSupply.Height;
          for (int index9 = 0; index9 <= height; ++index9)
          {
            bool flag = false;
            if (!ownFrontUnitsOnly | frontArea.Value[index8, index9] == front.FrontID && tOwner.Value[index8, index9] == 2)
            {
              int index10 = index8 + tSupply.Left;
              int index11 = index9 + tSupply.Top;
              if (this.game.Data.MapObj[0].HexObj[index10, index11].Location > -1)
              {
                int cityLevel = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index10, index11].Location].Type].cityLevel;
                if (cityLevel > 0)
                {
                  int[,] numArray3 = aiMatrix.Value;
                  int[,] numArray4 = numArray3;
                  int index12 = index8;
                  int index13 = index12;
                  int index14 = index9;
                  int index15 = index14;
                  int num6 = numArray3[index12, index14] + (int) Math.Round((double) (num4 * cityLevel) / 2.0);
                  numArray4[index13, index15] = num6;
                  flag = true;
                  num5 = (int) Math.Round((double) (num4 * cityLevel) / 2.0);
                }
              }
              if (this.game.Data.MapObj[0].HexObj[index10, index11].Location2 > -1)
              {
                int[,] numArray5 = aiMatrix.Value;
                int[,] numArray6 = numArray5;
                int index16 = index8;
                int index17 = index16;
                int index18 = index9;
                int index19 = index18;
                int num7 = numArray5[index16, index18] + num4;
                numArray6[index17, index19] = num7;
                flag = true;
                num5 = num4;
              }
            }
            if (!ownFrontUnitsOnly | frontArea.Value[index8, index9] == front.FrontID && tOwner.Value[index8, index9] == 2)
            {
              int x2 = index8 + tSupply.Left;
              int y2 = index9 + tSupply.Top;
              if (this.game.HandyFunctionsObj.HasHexRoad(x2, y2, 0))
              {
                int index20 = 0;
                do
                {
                  coordinate2 = this.TempHexNeighbour[index8, index9, index20];
                  if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tOwner.Value[coordinate2.x, coordinate2.y] == 1)
                  {
                    int num8 = this.game.HandyFunctionsObj.HexLowestRulevar99moveCost(x2, y2, 0);
                    flag = true;
                    if (num8 <= 1)
                    {
                      int[,] numArray7 = aiMatrix.Value;
                      int[,] numArray8 = numArray7;
                      int index21 = index8;
                      int index22 = index21;
                      int index23 = index9;
                      int index24 = index23;
                      int num9 = numArray7[index21, index23] + num4 * 3;
                      numArray8[index22, index24] = num9;
                      num5 = num4 * 3;
                    }
                    else if (num8 <= 2)
                    {
                      int[,] numArray9 = aiMatrix.Value;
                      int[,] numArray10 = numArray9;
                      int index25 = index8;
                      int index26 = index25;
                      int index27 = index9;
                      int index28 = index27;
                      int num10 = numArray9[index25, index27] + num4 * 2;
                      numArray10[index26, index28] = num10;
                      num5 = num4 * 2;
                    }
                    else if (num8 <= 5)
                    {
                      int[,] numArray11 = aiMatrix.Value;
                      int[,] numArray12 = numArray11;
                      int index29 = index8;
                      int index30 = index29;
                      int index31 = index9;
                      int index32 = index31;
                      int num11 = numArray11[index29, index31] + (int) Math.Round((double) num4 * 1.5);
                      numArray12[index30, index32] = num11;
                      num5 = (int) Math.Round((double) num4 * 1.5);
                    }
                    else
                    {
                      int[,] numArray13 = aiMatrix.Value;
                      int[,] numArray14 = numArray13;
                      int index33 = index8;
                      int index34 = index33;
                      int index35 = index9;
                      int index36 = index35;
                      int num12 = numArray13[index33, index35] + num4;
                      numArray14[index34, index36] = num12;
                      num5 = num4;
                    }
                  }
                  ++index20;
                }
                while (index20 <= 5);
              }
            }
            if (flag)
            {
              coordinate1 = new Coordinate();
              coordinate1.x = index8;
              coordinate1.y = index9;
              coordinate1.onmap = true;
              if (!ownFrontUnitsOnly | frontArea.Value[coordinate1.x, coordinate1.y] == front.FrontID)
              {
                while (coordinate1.onmap)
                {
                  int num13 = tSupply.Value[coordinate1.x, coordinate1.y];
                  int index37 = 0;
                  do
                  {
                    coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index37];
                    if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tSupply.Value[coordinate2.x, coordinate2.y] < num13)
                    {
                      num13 = tSupply.Value[coordinate2.x, coordinate2.y];
                      x1 = coordinate2.x;
                      y1 = coordinate2.y;
                    }
                    ++index37;
                  }
                  while (index37 <= 5);
                  if (num13 < tSupply.Value[coordinate1.x, coordinate1.y])
                  {
                    int[,] numArray15 = aiMatrix.Value;
                    int[,] numArray16 = numArray15;
                    int index38 = x1;
                    int index39 = index38;
                    int index40 = y1;
                    int index41 = index40;
                    int num14 = numArray15[index38, index40] + num5;
                    numArray16[index39, index41] = num14;
                    coordinate1.x = x1;
                    coordinate1.y = y1;
                    coordinate1.onmap = true;
                  }
                  else
                    coordinate1.onmap = false;
                }
              }
            }
          }
        }
      }
      if (FuzzyHexRange > 0)
        aiMatrix = aiMatrix.AverageValuesForSameRegime(FuzzyHexRange, tOwner);
      aiMatrix.Percentify();
      return aiMatrix;
    }

    public AIMatrix SetEnemyBottleNeckMatrix_DC4version(
      AIFront front,
      AIMatrix frontArea,
      AIMatrix tSupply,
      AIMatrix tOwner,
      bool ownFrontUnitsOnly,
      int FuzzyHexRange,
      AIMatrix tIdealSupply)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, tSupply.Width, tSupply.Height, tSupply.Top, tSupply.Left);
      int d = 0;
      int num1 = 0;
      int counter = front.units.counter;
      for (int index = 0; index <= counter; ++index)
      {
        ++d;
        int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index]);
        if (unitByAiid > -1)
        {
          num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
          ++d;
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      Coordinate coordinate1;
      Coordinate coordinate2;
      int x1;
      int y1;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        int index2 = index1;
        if (index2 > -1 && this.game.Data.UnitObj[index2].Regime != this.game.Data.Turn && this.game.Data.UnitObj[index2].X >= tSupply.Left & this.game.Data.UnitObj[index2].Y >= tSupply.Top && this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left) <= tSupply.Width & this.game.Data.UnitObj[index2].Y <= tSupply.Top + tSupply.Height)
        {
          coordinate1 = new Coordinate();
          coordinate1.x = this.GetMatrixX(this.game.Data.UnitObj[index2].X, tSupply.Left);
          coordinate1.y = this.game.Data.UnitObj[index2].Y - tSupply.Top;
          coordinate1.onmap = true;
          num1 += this.game.Data.UnitObj[index2].TempUnitPowerAbs;
          ++d;
          if (!ownFrontUnitsOnly | frontArea.Value[coordinate1.x, coordinate1.y] == front.FrontID)
          {
            while (coordinate1.onmap)
            {
              int num2 = tSupply.Value[coordinate1.x, coordinate1.y];
              int index3 = 0;
              do
              {
                coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index3];
                if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tSupply.Value[coordinate2.x, coordinate2.y] < num2)
                {
                  num2 = tSupply.Value[coordinate2.x, coordinate2.y];
                  x1 = coordinate2.x;
                  y1 = coordinate2.y;
                }
                ++index3;
              }
              while (index3 <= 5);
              if (num2 < tSupply.Value[coordinate1.x, coordinate1.y])
              {
                int[,] numArray1 = aiMatrix.Value;
                int[,] numArray2 = numArray1;
                int index4 = x1;
                int index5 = index4;
                int index6 = y1;
                int index7 = index6;
                int num3 = numArray1[index4, index6] + this.game.Data.UnitObj[index2].TempUnitPowerAbs;
                numArray2[index5, index7] = num3;
                coordinate1.x = x1;
                coordinate1.y = y1;
                coordinate1.onmap = true;
              }
              else
                coordinate1.onmap = false;
            }
          }
        }
      }
      if (this.game.Data.Product == 6)
      {
        int num4 = d <= 0 ? 6000 : (int) Math.Round((double) num1 / (double) d * Math.Sqrt((double) d));
        int num5 = 0;
        int width = tSupply.Width;
        for (int index8 = 0; index8 <= width; ++index8)
        {
          int height = tSupply.Height;
          for (int index9 = 0; index9 <= height; ++index9)
          {
            bool flag = false;
            if (!ownFrontUnitsOnly | frontArea.Value[index8, index9] == front.FrontID && tOwner.Value[index8, index9] == 2 | tIdealSupply.Value[index8, index9] < 999)
            {
              int index10 = index8 + tSupply.Left;
              int index11 = index9 + tSupply.Top;
              if (this.game.Data.MapObj[0].HexObj[index10, index11].Location > -1)
              {
                int type = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index10, index11].Location].Type;
                int num6 = this.game.Data.LocTypeObj[type].cityLevel * this.game.Data.LocTypeObj[type].cityLevel;
                if (num6 > 0)
                {
                  if (tOwner.Value[index8, index9] == 2)
                  {
                    int[,] numArray3 = aiMatrix.Value;
                    int[,] numArray4 = numArray3;
                    int index12 = index8;
                    int index13 = index12;
                    int index14 = index9;
                    int index15 = index14;
                    int num7 = numArray3[index12, index14] + (int) Math.Round((double) (num4 * num6) / 16.0);
                    numArray4[index13, index15] = num7;
                    flag = true;
                    num5 = (int) Math.Round((double) (num4 * num6) / 16.0);
                  }
                  else
                  {
                    int[,] numArray5 = aiMatrix.Value;
                    int[,] numArray6 = numArray5;
                    int index16 = index8;
                    int index17 = index16;
                    int index18 = index9;
                    int index19 = index18;
                    int num8 = numArray5[index16, index18] + (int) Math.Round((double) (num4 * num6) / 8.0);
                    numArray6[index17, index19] = num8;
                    flag = true;
                    num5 = (int) Math.Round((double) (num4 * num6) / 8.0);
                  }
                }
              }
              if (this.game.Data.MapObj[0].HexObj[index10, index11].Location2 > -1)
              {
                int[,] numArray7 = aiMatrix.Value;
                int[,] numArray8 = numArray7;
                int index20 = index8;
                int index21 = index20;
                int index22 = index9;
                int index23 = index22;
                int num9 = numArray7[index20, index22] + num4;
                numArray8[index21, index23] = num9;
                flag = true;
                num5 = num4;
              }
            }
            if (!ownFrontUnitsOnly | frontArea.Value[index8, index9] == front.FrontID && tOwner.Value[index8, index9] == 2)
            {
              int x2 = index8 + tSupply.Left;
              int y2 = index9 + tSupply.Top;
              int index24 = 0;
              do
              {
                if (this.game.Data.MapObj[0].HexObj[x2, y2].RoadType[index24] > -1)
                {
                  coordinate2 = this.TempHexNeighbour[index8, index9, index24];
                  if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tOwner.Value[coordinate2.x, coordinate2.y] == 1)
                  {
                    int num10 = this.game.HandyFunctionsObj.HexLowestRulevar99moveCost(x2, y2, 0);
                    flag = true;
                    if (num10 <= 1)
                    {
                      int[,] numArray9 = aiMatrix.Value;
                      int[,] numArray10 = numArray9;
                      int index25 = index8;
                      int index26 = index25;
                      int index27 = index9;
                      int index28 = index27;
                      int num11 = numArray9[index25, index27] + num4 * 1;
                      numArray10[index26, index28] = num11;
                      num5 = num4 * 1;
                      flag = true;
                    }
                    else if (num10 <= 2)
                    {
                      int[,] numArray11 = aiMatrix.Value;
                      int[,] numArray12 = numArray11;
                      int index29 = index8;
                      int index30 = index29;
                      int index31 = index9;
                      int index32 = index31;
                      int num12 = numArray11[index29, index31] + (int) Math.Round((double) num4 * 0.2);
                      numArray12[index30, index32] = num12;
                      num5 = (int) Math.Round((double) num4 * 0.2);
                      flag = true;
                    }
                    else if (num10 <= 5)
                    {
                      int[,] numArray13 = aiMatrix.Value;
                      int[,] numArray14 = numArray13;
                      int index33 = index8;
                      int index34 = index33;
                      int index35 = index9;
                      int index36 = index35;
                      int num13 = numArray13[index33, index35] + (int) Math.Round((double) num4 * 0.05);
                      numArray14[index34, index36] = num13;
                      num5 = (int) Math.Round((double) num4 * 0.05);
                      flag = true;
                    }
                  }
                }
                ++index24;
              }
              while (index24 <= 5);
            }
            if (flag)
            {
              coordinate1 = new Coordinate();
              coordinate1.x = index8;
              coordinate1.y = index9;
              coordinate1.onmap = true;
              if (!ownFrontUnitsOnly | frontArea.Value[coordinate1.x, coordinate1.y] == front.FrontID)
              {
                while (coordinate1.onmap)
                {
                  int num14 = tSupply.Value[coordinate1.x, coordinate1.y];
                  int index37 = 0;
                  do
                  {
                    coordinate2 = this.TempHexNeighbour[coordinate1.x, coordinate1.y, index37];
                    if (coordinate2.onmap & coordinate2.x <= tSupply.Width & coordinate2.y <= tSupply.Height && tSupply.Value[coordinate2.x, coordinate2.y] < num14)
                    {
                      num14 = tSupply.Value[coordinate2.x, coordinate2.y];
                      x1 = coordinate2.x;
                      y1 = coordinate2.y;
                    }
                    ++index37;
                  }
                  while (index37 <= 5);
                  if (num14 < tSupply.Value[coordinate1.x, coordinate1.y])
                  {
                    int[,] numArray15 = aiMatrix.Value;
                    int[,] numArray16 = numArray15;
                    int index38 = x1;
                    int index39 = index38;
                    int index40 = y1;
                    int index41 = index40;
                    int num15 = numArray15[index38, index40] + num5;
                    numArray16[index39, index41] = num15;
                    coordinate1.x = x1;
                    coordinate1.y = y1;
                    coordinate1.onmap = true;
                  }
                  else
                    coordinate1.onmap = false;
                }
              }
            }
          }
        }
      }
      if (FuzzyHexRange > 0)
        aiMatrix = aiMatrix.AverageValuesForSameRegime(FuzzyHexRange, tOwner);
      aiMatrix.Percentify();
      return aiMatrix;
    }

    public AIMatrix SetAveragedVPMatrix(AIMatrix frontmatrix, int id)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, frontmatrix.Width, frontmatrix.Height, frontmatrix.Top, frontmatrix.Left);
      int num1 = 999;
      int num2 = 0;
      int width1 = frontmatrix.Width;
      for (int tx = 0; tx <= width1; ++tx)
      {
        int height = frontmatrix.Height;
        for (int index = 0; index <= height; ++index)
        {
          if (frontmatrix.Value[tx, index] == id)
          {
            aiMatrix.Value[tx, index] = 10 * this.game.Data.MapObj[0].HexObj[this.GetRealX(tx, frontmatrix.Left), index + frontmatrix.Top].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[this.GetRealX(tx, frontmatrix.Left), index + frontmatrix.Top];
            if (aiMatrix.Value[tx, index] > num2)
              num2 = aiMatrix.Value[tx, index];
            else if (aiMatrix.Value[tx, index] > 0 && num1 > aiMatrix.Value[tx, index])
              num1 = aiMatrix.Value[tx, index];
          }
        }
      }
      if (num1 < 999 & num2 > 0 & this.game.Data.Product == 6)
      {
        int num3 = num2 - num1;
        int width2 = frontmatrix.Width;
        for (int index1 = 0; index1 <= width2; ++index1)
        {
          int height = frontmatrix.Height;
          for (int index2 = 0; index2 <= height; ++index2)
          {
            if (frontmatrix.Value[index1, index2] == id && this.game.Data.MapObj[0].HexObj[index1 + frontmatrix.Left, index2 + frontmatrix.Top].Location2 > -1)
            {
              if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index1 + frontmatrix.Left, index2 + frontmatrix.Top].Location2].Type].isSupplySource)
              {
                int[,] numArray1 = aiMatrix.Value;
                int[,] numArray2 = numArray1;
                int index3 = index1;
                int index4 = index3;
                int index5 = index2;
                int index6 = index5;
                int num4 = numArray1[index3, index5] + (num3 + num2 * 2);
                numArray2[index4, index6] = num4;
              }
              if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index1 + frontmatrix.Left, index2 + frontmatrix.Top].Location2].Type].isSupplyBase)
              {
                int[,] numArray3 = aiMatrix.Value;
                int[,] numArray4 = numArray3;
                int index7 = index1;
                int index8 = index7;
                int index9 = index2;
                int index10 = index9;
                int num5 = numArray3[index7, index9] + ((int) Math.Round((double) num3 / 2.0) + num2);
                numArray4[index8, index10] = num5;
              }
            }
          }
        }
      }
      int num6 = 0;
      do
      {
        int width3 = frontmatrix.Width;
        for (int cx = 0; cx <= width3; ++cx)
        {
          int height = frontmatrix.Height;
          for (int cy = 0; cy <= height; ++cy)
          {
            if (frontmatrix.Value[cx, cy] == id && aiMatrix.Value[cx, cy] > 0)
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && coordinate.x <= frontmatrix.Width & coordinate.y <= frontmatrix.Height && frontmatrix.Value[coordinate.x, coordinate.y] == id)
                {
                  int num7 = (int) Math.Round(Conversion.Int((double) aiMatrix.Value[cx, cy] / 2.0));
                  if (num7 > aiMatrix.Value[coordinate.x, coordinate.y])
                    aiMatrix.Value[coordinate.x, coordinate.y] = num7;
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
        ++num6;
      }
      while (num6 <= 3);
      return aiMatrix;
    }

    public void InitFrontlinesAddEmptyFrontlines(
      AIMatrix frontmatrix,
      AIMatrix strength,
      ref AIFrontList tempList)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int maxdistance = (int) Math.Round((double) this.VAR_FRONTLINE_MAX_LENGTH / 2.0) - 1;
      if (maxdistance < 1)
        maxdistance = 1;
      int mapWidth = this.map.MapWidth;
      for (int x1 = 0; x1 <= mapWidth; ++x1)
      {
        int mapHeight = this.map.MapHeight;
        for (int y1 = 0; y1 <= mapHeight; ++y1)
        {
          if (frontmatrix.Value[x1, y1] == 0 & strength.Value[x1, y1] > 0 && this.game.Data.MapObj[0].HexObj[x1, y1].UnitCounter > -1 | this.game.Data.Product >= 6)
          {
            AIFront aiFront = tempList.AddFront(1);
            frontmatrix.Value[x1, y1] = aiFront.FrontID;
            int num1 = x1 - (maxdistance + 1);
            int num2 = x1 + (maxdistance + 1);
            for (int x2 = num1; x2 <= num2; ++x2)
            {
              int num3 = y1 - (maxdistance + 1);
              int num4 = y1 + (maxdistance + 1);
              for (int y2 = num3; y2 <= num4; ++y2)
              {
                if (x2 <= this.map.MapWidth & x2 >= 0 && y2 <= this.map.MapHeight & y2 > 0 && frontmatrix.Value[x2, y2] == 0 & strength.Value[x2, y2] == strength.Value[x1, y1] && this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, maxdistance) <= maxdistance)
                  frontmatrix.Value[x2, y2] = aiFront.FrontID;
              }
            }
          }
        }
      }
    }

    public AIMatrix SetProminantCorpsAddBroadDefZonesAsPointDef(ref AIMatrix tcorps)
    {
      AIMatrix aiMatrix = tcorps;
      int[] numArray1 = new int[100];
      int[] numArray2 = new int[100];
      SimpleList simpleList = new SimpleList();
      if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
          {
            if ((this.VAR_ZONES_TYPE == 2 & this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 | this.VAR_ZONES_TYPE == 3 & this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 200000) & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.map.HexObj[tdata1, tdata2].Regime, this.game.Data.Turn))
            {
              bool flag = false;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter; ++index)
              {
                if (this.game.Data.UnitObj[index].HQ > -1 & !this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[index].HQ].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitObj[index].HQ].Historical].AIlist == this.VAR_MATRIX_ZONES.Value[tdata1, tdata2])
                {
                  flag = true;
                  if (this.VAR_USE_SUPERFRONTS && this.VAR_MATRIX_SUPERFRONT.Value[tdata1, tdata2] != this.VAR_MATRIX_SUPERFRONT.Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y])
                    flag = false;
                }
              }
              if (flag)
              {
                if (simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
                {
                  simpleList.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 1, tdata1, tdata2, tdata4: 1);
                }
                else
                {
                  int[] weight = simpleList.Weight;
                  int[] numArray3 = weight;
                  int nr1 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                  int index1 = nr1;
                  int num1 = weight[nr1] + 1;
                  numArray3[index1] = num1;
                  int[] data4 = simpleList.Data4;
                  int[] numArray4 = data4;
                  int nr2 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                  int index2 = nr2;
                  int num2 = data4[nr2] + 1;
                  numArray4[index2] = num2;
                }
                if (aiMatrix.Value[tdata1, tdata2] > 0 & aiMatrix.Value[tdata1, tdata2] < 600000)
                {
                  int[] data5 = simpleList.Data5;
                  int[] numArray5 = data5;
                  int nr = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                  int index = nr;
                  int num = data5[nr] + 1;
                  numArray5[index] = num;
                }
              }
            }
            else if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0)
            {
              if (simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
              {
                simpleList.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 0, tdata1, tdata2, 1, 1);
              }
              else
              {
                int[] data3 = simpleList.Data3;
                int[] numArray6 = data3;
                int nr3 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                int index3 = nr3;
                int num3 = data3[nr3] + 1;
                numArray6[index3] = num3;
                int[] data4 = simpleList.Data4;
                int[] numArray7 = data4;
                int nr4 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                int index4 = nr4;
                int num4 = data4[nr4] + 1;
                numArray7[index4] = num4;
              }
              if (aiMatrix.Value[tdata1, tdata2] > 0 & aiMatrix.Value[tdata1, tdata2] < 600000)
              {
                int[] data5 = simpleList.Data5;
                int[] numArray8 = data5;
                int nr = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                int index = nr;
                int num = data5[nr] + 1;
                numArray8[index] = num;
              }
            }
          }
        }
        for (int counter = simpleList.Counter; counter >= 0; counter += -1)
        {
          bool flag = false;
          if (this.VAR_USE_BROAD_DEFENSIVE_ZONES && simpleList.Data4[counter] >= this.VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM)
            flag = true;
          if (!flag | simpleList.Data5[counter] > 0)
            simpleList.RemoveNr(counter);
        }
      }
      if (simpleList.Counter > -1)
      {
        int mapWidth = this.map.MapWidth;
        for (int index5 = 0; index5 <= mapWidth; ++index5)
        {
          int mapHeight = this.map.MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
          {
            int index7 = -1;
            if (aiMatrix.Value[index5, index6] == 0 && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.map.HexObj[index5, index6].Regime, this.game.Data.Turn) && this.VAR_MATRIX_ZONES.Value[index5, index6] > 0 && simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[index5, index6]) > -1)
            {
              ++index7;
              numArray2[index7] = 999999;
              numArray1[index7] = this.VAR_MATRIX_ZONES.Value[index5, index6] + 1000000;
            }
            if (index7 > -1)
            {
              int num5 = -1;
              int num6 = 0;
              int num7 = index7;
              for (int index8 = 0; index8 <= num7; ++index8)
              {
                if (numArray2[index8] > num6)
                {
                  num5 = numArray1[index8];
                  num6 = numArray2[index8];
                }
              }
              if (num5 > -1)
                aiMatrix.Value[index5, index6] = num5;
            }
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetProminantCorpsOfHexesAndDefZones()
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int[] numArray1 = new int[500];
      int[] numArray2 = new int[500];
      SimpleList simpleList = new SimpleList();
      if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3)
      {
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int tdata1 = 0; tdata1 <= mapWidth1; ++tdata1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
          {
            if ((this.VAR_ZONES_TYPE == 2 & this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 | this.VAR_ZONES_TYPE == 3 & this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 200000) & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.map.HexObj[tdata1, tdata2].Regime, this.game.Data.Turn))
            {
              bool flag = false;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter; ++index)
              {
                if (this.game.Data.UnitObj[index].HQ > -1 & !this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[index].HQ].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitObj[index].HQ].Historical].AIlist == this.VAR_MATRIX_ZONES.Value[tdata1, tdata2])
                {
                  flag = true;
                  if (this.VAR_USE_SUPERFRONTS && this.VAR_MATRIX_SUPERFRONT.Value[tdata1, tdata2] != this.VAR_MATRIX_SUPERFRONT.Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y])
                    flag = false;
                }
              }
              if (this.CustomCalls.HasCustumCalls() && this.CustomCalls.CustomRule_MakeFrontsFromDefensiveZones_NoUnitsAssignedNeeded())
                flag = true;
              if (flag)
              {
                if (simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
                {
                  simpleList.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 1, tdata1, tdata2, tdata4: 1);
                }
                else
                {
                  int[] weight = simpleList.Weight;
                  int[] numArray3 = weight;
                  int nr1 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                  int index1 = nr1;
                  int num1 = weight[nr1] + 1;
                  numArray3[index1] = num1;
                  int[] data4 = simpleList.Data4;
                  int[] numArray4 = data4;
                  int nr2 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                  int index2 = nr2;
                  int num2 = data4[nr2] + 1;
                  numArray4[index2] = num2;
                }
              }
            }
            else if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0)
            {
              if (simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
              {
                simpleList.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 0, tdata1, tdata2, 1, 1);
              }
              else
              {
                int[] data3 = simpleList.Data3;
                int[] numArray5 = data3;
                int nr3 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                int index3 = nr3;
                int num3 = data3[nr3] + 1;
                numArray5[index3] = num3;
                int[] data4 = simpleList.Data4;
                int[] numArray6 = data4;
                int nr4 = simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                int index4 = nr4;
                int num4 = data4[nr4] + 1;
                numArray6[index4] = num4;
              }
            }
          }
        }
        for (int counter = simpleList.Counter; counter >= 0; counter += -1)
        {
          if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 & simpleList.Id[counter] > 200000)
          {
            bool flag = false;
            if (this.VAR_USE_BROAD_DEFENSIVE_ZONES && simpleList.Data4[counter] >= this.VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM)
              flag = true;
            if (!flag & simpleList.Data3[counter] * 2 >= simpleList.Weight[counter] | flag & (double) simpleList.Data3[counter] / 3.0 >= (double) simpleList.Weight[counter])
            {
              int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
              for (int index5 = 0; index5 <= mapWidth2; ++index5)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (int index6 = 0; index6 <= mapHeight; ++index6)
                {
                  if (this.VAR_MATRIX_ZONES.Value[index5, index6] == simpleList.Id[counter])
                    this.VAR_MATRIX_ZONES.Value[index5, index6] = 0;
                }
              }
              simpleList.RemoveNr(counter);
            }
            else if (flag)
              simpleList.RemoveNr(counter);
          }
        }
      }
      int mapWidth = this.map.MapWidth;
      for (int index7 = 0; index7 <= mapWidth; ++index7)
      {
        int mapHeight = this.map.MapHeight;
        for (int index8 = 0; index8 <= mapHeight; ++index8)
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.map.HexObj[index7, index8].Regime, this.game.Data.Turn))
          {
            int index9 = -1;
            int unitCounter1 = this.map.HexObj[index7, index8].UnitCounter;
            for (int index10 = 0; index10 <= unitCounter1; ++index10)
            {
              int unit = this.map.HexObj[index7, index8].UnitList[index10];
              if (this.game.Data.UnitObj[unit].TempCategory == 1)
              {
                int hq = this.game.Data.UnitObj[unit].HQ;
                if (hq > -1)
                {
                  int historical = this.game.Data.UnitObj[hq].Historical;
                  if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 5)
                  {
                    int num5 = -1;
                    int num6 = index9;
                    for (int index11 = 0; index11 <= num6; ++index11)
                    {
                      if (numArray1[index11] == hq)
                        num5 = index11;
                    }
                    if (num5 == -1)
                    {
                      ++index9;
                      int num7 = index9;
                      numArray1[index9] = hq * 10;
                      int[] numArray7 = numArray1;
                      int[] numArray8 = numArray7;
                      int index12 = index9;
                      int index13 = index12;
                      int num8 = numArray7[index12] + Math.Min(9, this.game.Data.UnitObj[unit].AISubStrictGroup);
                      numArray8[index13] = num8;
                      numArray2[index9] = 0;
                      int[] numArray9 = numArray2;
                      int[] numArray10 = numArray9;
                      int index14 = num7;
                      int index15 = index14;
                      int num9 = numArray9[index14] + this.game.Data.UnitObj[unit].TempUnitPower;
                      numArray10[index15] = num9;
                      if (this.game.Data.UnitObj[unit].AISubStrictGroup == 1)
                      {
                        int[] numArray11 = numArray2;
                        int[] numArray12 = numArray11;
                        int index16 = num7;
                        int index17 = index16;
                        int num10 = numArray11[index16] + this.game.Data.UnitObj[unit].TempUnitPower * 3;
                        numArray12[index17] = num10;
                      }
                    }
                  }
                }
              }
            }
            if (index9 == -1 & this.game.Data.Product >= 6)
            {
              int unitCounter2 = this.map.HexObj[index7, index8].UnitCounter;
              for (int index18 = 0; index18 <= unitCounter2; ++index18)
              {
                int unit = this.map.HexObj[index7, index8].UnitList[index18];
                if (this.game.Data.UnitObj[unit].TempCategory > 0)
                {
                  int hq = this.game.Data.UnitObj[unit].HQ;
                  if (hq > -1)
                  {
                    int historical = this.game.Data.UnitObj[hq].Historical;
                    if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type > 5)
                    {
                      int num11 = -1;
                      int num12 = index9;
                      for (int index19 = 0; index19 <= num12; ++index19)
                      {
                        if (numArray1[index19] == hq)
                          num11 = index19;
                      }
                      if (num11 == -1)
                      {
                        ++index9;
                        int num13 = index9;
                        numArray1[index9] = hq * 10;
                        int[] numArray13 = numArray1;
                        int[] numArray14 = numArray13;
                        int index20 = index9;
                        int index21 = index20;
                        int num14 = numArray13[index20] + Math.Min(9, this.game.Data.UnitObj[unit].AISubStrictGroup);
                        numArray14[index21] = num14;
                        numArray2[index9] = 0;
                        int[] numArray15 = numArray2;
                        int[] numArray16 = numArray15;
                        int index22 = num13;
                        int index23 = index22;
                        int num15 = numArray15[index22] + this.game.Data.UnitObj[unit].TempUnitPower;
                        numArray16[index23] = num15;
                      }
                    }
                  }
                  else
                  {
                    ++index9;
                    int num16 = index9;
                    numArray1[index9] = unit * 10;
                    int[] numArray17 = numArray1;
                    int[] numArray18 = numArray17;
                    int index24 = index9;
                    int index25 = index24;
                    int num17 = numArray17[index24] + Math.Min(9, this.game.Data.UnitObj[unit].AISubStrictGroup);
                    numArray18[index25] = num17;
                    numArray2[index9] = 0;
                    int[] numArray19 = numArray2;
                    int[] numArray20 = numArray19;
                    int index26 = num16;
                    int index27 = index26;
                    int num18 = numArray19[index26] + (int) Math.Round(1.0 + (double) (this.game.Data.UnitObj[unit].TempUnitPower + this.game.Data.UnitObj[unit].TempUnitPowerAbs) / 2.0);
                    numArray20[index27] = num18;
                  }
                }
              }
            }
            if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 && this.VAR_MATRIX_ZONES.Value[index7, index8] > 0 & this.VAR_ZONES_TYPE == 2 | this.VAR_MATRIX_ZONES.Value[index7, index8] > 200000 & this.VAR_ZONES_TYPE == 3 && simpleList.FindNr(this.VAR_MATRIX_ZONES.Value[index7, index8]) > -1)
            {
              ++index9;
              numArray2[index9] = 999999;
              numArray1[index9] = this.VAR_MATRIX_ZONES.Value[index7, index8] + 1000000;
            }
            if (index9 > -1)
            {
              int num19 = -1;
              int num20 = 0;
              int num21 = index9;
              for (int index28 = 0; index28 <= num21; ++index28)
              {
                if (numArray2[index28] > num20)
                {
                  num19 = numArray1[index28];
                  num20 = numArray2[index28];
                }
              }
              if (num19 > -1)
                aiMatrix.Value[index7, index8] = num19;
            }
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetMatrixUnitPower(bool Friendly, bool OnlyWithSupplyConsume = false)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          bool flag1 = false;
          bool flag2 = false;
          bool flag3 = false;
          if (this.game.HandyFunctionsObj.GetRegime(this.map.HexObj[index1, index2].Regime) == this.GetGameDataTurn())
          {
            if (Friendly)
              flag1 = true;
          }
          else
          {
            if (!Friendly)
              flag1 = true;
            if (this.map.HexObj[index1, index2].Regime > -1)
            {
              if (this.game.Data.RegimeObj[this.map.HexObj[index1, index2].Regime].RegimeRel[this.game.Data.Turn] == 2)
                flag2 = true;
              if (this.game.Data.RegimeObj[this.map.HexObj[index1, index2].Regime].RegimeRel[this.game.Data.Turn] == 1)
                flag3 = true;
            }
          }
          if (flag1)
          {
            int num = 0;
            int unitCounter = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].TempCategory == 1 | this.game.Data.Product >= 6)
              {
                if (!OnlyWithSupplyConsume | this.game.Data.UnitObj[unit].SupplyConsume > 25)
                {
                  num = num + (int) Math.Round((double) this.game.Data.UnitObj[unit].TempUnitPower * 0.33) + (int) Math.Round((double) this.game.Data.UnitObj[unit].TempUnitPowerAbs * 0.66);
                  if (flag2)
                    num = 0;
                  else if (flag3)
                    num = (int) Math.Round((double) num / 3.0);
                }
                else if (this.game.Data.Product == 6)
                  num = num + (int) Math.Round((double) this.game.Data.UnitObj[unit].TempUnitPower * 0.25) + (int) Math.Round((double) this.game.Data.UnitObj[unit].TempUnitPowerAbs * 0.5);
              }
              else if (this.game.Data.Product == 6)
                num = num + (int) Math.Round((double) this.game.Data.UnitObj[unit].TempUnitPower * 0.2) + (int) Math.Round((double) this.game.Data.UnitObj[unit].TempUnitPowerAbs * 0.4);
            }
            aiMatrix.Value[index1, index2] = num;
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetMatrixEnemyUnitsAndRoadHexes()
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = this.map.MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.map.MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.map.HexObj[x, y].Regime, this.game.Data.Turn) && this.map.HexObj[x, y].Regime != -1 && !this.game.Data.RegimeObj[this.map.HexObj[x, y].Regime].Sleep)
          {
            if (this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
              aiMatrix.Value[x, y] = 1;
            else if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter > -1)
              aiMatrix.Value[x, y] = 1;
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetMatrixNonFriendlyUnitsAndRoadHexes()
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = this.map.MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.map.MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.game.HandyFunctionsObj.GetRegime(this.map.HexObj[x, y].Regime) != this.GetGameDataTurn() && this.map.HexObj[x, y].Regime != -1 && !this.game.Data.RegimeObj[this.map.HexObj[x, y].Regime].Sleep)
          {
            if (this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
              aiMatrix.Value[x, y] = 1;
            else if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter > -1)
              aiMatrix.Value[x, y] = 1;
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetRatioInPercentage(
      ref AIMatrix friendly,
      ref AIMatrix enemy,
      AIMatrix frontline,
      int frontID)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, friendly.Width, friendly.Height, friendly.Top, friendly.Left);
      int width = friendly.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = friendly.Height;
        for (int index2 = 0; index2 <= height; ++index2)
        {
          bool flag = false;
          if (frontID > -1)
          {
            if (frontline.Value[index1, index2] == frontID)
              flag = true;
          }
          else
            flag = true;
          if (flag)
          {
            int num = !(enemy.Value[index1, index2] > 0 & friendly.Value[index1, index2] == 0) ? (!(friendly.Value[index1, index2] > 0 & enemy.Value[index1, index2] == 0) ? (!(friendly.Value[index1, index2] == 0 & enemy.Value[index1, index2] == 0) ? Math.Min(998, Math.Max(1, (int) Math.Round(100.0 * ((double) friendly.Value[index1, index2] / (double) enemy.Value[index1, index2])))) : 999) : 999) : 1;
            if (num == 450)
              num = num;
            aiMatrix.Value[index1, index2] = num;
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetRatioForEnemyInPercentage(
      ref AIMatrix enemy,
      ref AIMatrix friendly,
      ref AIMatrix owner)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (owner.Value[index1, index2] == 2)
          {
            int num = !(friendly.Value[index1, index2] > 0 & enemy.Value[index1, index2] == 0) ? (!(enemy.Value[index1, index2] > 0 & friendly.Value[index1, index2] == 0) ? (!(enemy.Value[index1, index2] == 0 & friendly.Value[index1, index2] == 0) ? Math.Min(999, Math.Max(1, (int) Math.Round(100.0 * ((double) enemy.Value[index1, index2] / (double) friendly.Value[index1, index2])))) : 0) : 999) : 1;
            aiMatrix.Value[index1, index2] = num;
          }
        }
      }
      return aiMatrix;
    }

    public int GetRealX(int tx, int tleft)
    {
      if (!this.map.MapLoop)
        tx += tleft;
      else if (this.map.MapLoop)
      {
        tx += tleft;
        if (tx > this.map.MapWidth)
        {
          tx -= this.map.MapWidth + 1;
          if (tx > this.map.MapWidth)
            tx -= this.map.MapWidth + 1;
        }
      }
      return tx;
    }

    public int GetMatrixX(int tx, int tleft)
    {
      if (!this.map.MapLoop)
        tx -= tleft;
      else if (this.map.MapLoop)
      {
        if (tx < tleft)
          tx += this.map.MapWidth + 1;
        tx -= tleft;
      }
      return tx;
    }

    public AIMatrix SetOwnerMatrix(int left, int top, int Width, int height)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, Width, height, top, left);
      bool flag1 = false;
      bool flag2 = false;
      if (this.game.Data.Product == 7)
      {
        flag1 = false;
        flag2 = false;
      }
      int num1 = Width;
      for (int tx = 0; tx <= num1; ++tx)
      {
        int num2 = height;
        for (int index = 0; index <= num2; ++index)
        {
          int regime = this.game.Data.MapObj[0].HexObj[this.GetRealX(tx, left), index + top].Regime;
          int num3;
          if (this.GetRegime(regime) == this.GetGameDataTurn())
            num3 = 1;
          else if (regime > -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regime] == 2)
              num3 = 3;
            else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regime] == 1 & !flag1)
            {
              num3 = this.game.Data.RegimeObj[regime].AI ? 0 : 2;
            }
            else
            {
              int num4 = 2;
              if (this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[this.GetRealX(tx, left), index + top].Regime].Sleep)
                num4 = 0;
              if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.GetRealX(tx, left), index + top].LandscapeType].AIBlock > 0)
                num4 = 0;
              num3 = !this.CustomCalls.TargetRegimeRelationIsActuallyNotWar(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[this.GetRealX(tx, left), index + top].Regime, true) ? num4 : 0;
            }
          }
          else
            num3 = 0;
          aiMatrix.Value[tx, index] = num3;
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetFrontAreaMatrix(
      ref AITheater th,
      ref AIMatrix owner,
      int frontIDfirstStep = -1,
      bool limitedExpand = false,
      bool useExtended = false,
      bool useWellSpread = false)
    {
      AIMatrix aiMatrix = new AIMatrix(ref th.ai, th.Width, th.Height, th.Top, th.Left);
      if (!useWellSpread)
      {
        if (useExtended)
          aiMatrix.CopyValuesFrom(th.ai.extendedMatrix);
        else
          aiMatrix.CopyValuesFrom(th.ai.frontMatrix);
      }
      if (frontIDfirstStep > 0 & !limitedExpand)
        aiMatrix.ExpandSpecificValueForAnyRegime(frontIDfirstStep, 1);
      if (limitedExpand)
        aiMatrix.ExpandValueForAnyRegime(0);
      else
        aiMatrix.ExpandValueForAnyRegime();
      if (th.ai.VAR_USE_MLA)
      {
        int width = aiMatrix.Width;
        for (int tx = 0; tx <= width; ++tx)
        {
          int height = aiMatrix.Height;
          for (int index = 0; index <= height; ++index)
          {
            if (aiMatrix.Value[tx, index] == 33)
              tx = tx;
            if (th.ai.MLAMatrix.Value[this.GetRealX(tx, aiMatrix.Left), index + aiMatrix.Top] == 0)
              aiMatrix.Value[tx, index] = 0;
          }
        }
      }
      return aiMatrix;
    }

    public AIMatrix SetFrontAreaMatrix2(ref AITheater th, ref AIMatrix owner)
    {
      AIMatrix aiMatrix = new AIMatrix(ref th.ai, th.Width, th.Height, th.Top, th.Left);
      aiMatrix.CopyValuesFrom(th.ai.frontMatrix);
      return aiMatrix;
    }

    public AIMatrix SetAdvanceMatrix(
      ref AITheater th,
      ref AIMatrix frontArea,
      ref AIMatrix ownerMatrix)
    {
      AIMatrix useMatrix = new AIMatrix(ref th.ai, th.Width, th.Height, th.Top, th.Left);
      if (this.game.Data.Product == 6)
        useMatrix.CopyValuesFrom(this.extendedMatrix);
      else
        useMatrix.CopyValuesFrom(frontArea);
      useMatrix.SetValueXToValueY(0, th.front.FrontID);
      useMatrix.RemoveValuesByMask(ownerMatrix, 0);
      AIMatrix aiMatrix1 = this.SetCenterOfValueAreaMatrix(useMatrix, th.front.FrontID);
      if (this.game.Data.Product == 6)
      {
        AIMatrix aiMatrix2 = ownerMatrix.Clone();
        aiMatrix2.RemoveValuesByMask(ownerMatrix, 2);
        aiMatrix2.ExpandAndAddValueForAnyRegime(99, true);
        int width = th.Width;
        for (int index1 = 0; index1 <= width; ++index1)
        {
          int height = th.Height;
          for (int index2 = 0; index2 <= height; ++index2)
          {
            if (ownerMatrix.Value[index1, index2] != 2)
              aiMatrix1.Value[index1, index2] = 1;
            aiMatrix1.Value[index1, index2] = aiMatrix1.Value[index1, index2] * aiMatrix2.Value[index1, index2] * aiMatrix2.Value[index1, index2] * aiMatrix2.Value[index1, index2];
            if (ownerMatrix.Value[index1, index2] == 2)
            {
              if (this.game.Data.MapObj[0].HexObj[index1 + aiMatrix1.Left, index2 + aiMatrix1.Top].VP > 0)
              {
                int[,] numArray1 = aiMatrix1.Value;
                int[,] numArray2 = numArray1;
                int index3 = index1;
                int index4 = index3;
                int index5 = index2;
                int index6 = index5;
                int num = numArray1[index3, index5] + (int) Math.Round((double) aiMatrix1.Value[index1, index2] * (1.0 + Math.Sqrt((double) this.game.Data.MapObj[0].HexObj[index1 + aiMatrix1.Left, index2 + aiMatrix1.Top].VP)));
                numArray2[index4, index6] = num;
              }
              if (this.game.Data.MapObj[0].HexObj[index1 + aiMatrix1.Left, index2 + aiMatrix1.Top].UnitCounter > 0)
              {
                int[,] numArray3 = aiMatrix1.Value;
                int[,] numArray4 = numArray3;
                int index7 = index1;
                int index8 = index7;
                int index9 = index2;
                int index10 = index9;
                int num = numArray3[index7, index9] + (int) Math.Round((double) aiMatrix1.Value[index1, index2] * (1.0 + 0.3 * Math.Sqrt((double) this.game.Data.MapObj[0].HexObj[index1 + aiMatrix1.Left, index2 + aiMatrix1.Top].UnitCounter)));
                numArray4[index8, index10] = num;
              }
            }
          }
        }
      }
      aiMatrix1.RemoveValuesByNotMask(ownerMatrix, 2);
      if (this.game.Data.Product >= 7)
        aiMatrix1.ExpandAndRemoveValueForAnyRegime(99);
      else if (this.game.Data.Product == 6)
        aiMatrix1.ExpandAndRemovePercentageForAnyRegime(9999, 0.5f);
      else
        aiMatrix1.ExpandValueToSpecificRegime(1, ref ownerMatrix);
      if (this.game.Data.Product != 6)
      {
        int width = th.Width;
        for (int tx = 0; tx <= width; ++tx)
        {
          int height = th.Height;
          for (int index = 0; index <= height; ++index)
          {
            if (this.game.Data.LandscapeTypeObj[this.map.HexObj[this.GetRealX(tx, th.Left), index + th.Top].LandscapeType].TempDefenseBonus > 100 & aiMatrix1.Value[tx, index] > 0)
            {
              aiMatrix1.Value[tx, index] = (int) Math.Round((double) aiMatrix1.Value[tx, index] / 3.0);
              if (aiMatrix1.Value[tx, index] == 0)
                aiMatrix1.Value[tx, index] = 1;
            }
          }
        }
      }
      if (this.game.Data.Product == 6)
      {
        aiMatrix1 = aiMatrix1.AverageValuesForAnyRegime(3, true);
        int width = th.Width;
        for (int index11 = 0; index11 <= width; ++index11)
        {
          int height = th.Height;
          for (int index12 = 0; index12 <= height; ++index12)
          {
            if (ownerMatrix.Value[index11, index12] == 2)
            {
              int num = this.game.HandyFunctionsObj.HexRoadCount(index11 + aiMatrix1.Left, index12 + aiMatrix1.Top, 0);
              if (num > 1 & aiMatrix1.Value[index11, index12] > 0)
              {
                aiMatrix1.Value[index11, index12] = aiMatrix1.Value[index11, index12] * num;
                if (aiMatrix1.Value[index11, index12] == 0)
                  aiMatrix1.Value[index11, index12] = 1;
              }
              else if (num == 0)
                aiMatrix1.Value[index11, index12] = (int) Math.Round((double) aiMatrix1.Value[index11, index12] * 0.5);
            }
            else if (this.game.HandyFunctionsObj.HexRoadCount(index11 + aiMatrix1.Left, index12 + aiMatrix1.Top, 0) == 0)
              aiMatrix1.Value[index11, index12] = (int) Math.Round((double) aiMatrix1.Value[index11, index12] * 0.5);
            if (aiMatrix1.Value[index11, index12] > 30)
              aiMatrix1.Value[index11, index12] = 30 + (int) Math.Round((double) (aiMatrix1.Value[index11, index12] - 30) * 0.75);
            if (aiMatrix1.Value[index11, index12] > 50)
              aiMatrix1.Value[index11, index12] = 50 + (int) Math.Round((double) (aiMatrix1.Value[index11, index12] - 50) * 0.6);
            if (aiMatrix1.Value[index11, index12] > 90)
              aiMatrix1.Value[index11, index12] = 90 + (int) Math.Round((double) (aiMatrix1.Value[index11, index12] - 90) * 0.45);
            if (aiMatrix1.Value[index11, index12] > 130)
              aiMatrix1.Value[index11, index12] = 130 + (int) Math.Round((double) (aiMatrix1.Value[index11, index12] - 130) * 0.33);
            if (aiMatrix1.Value[index11, index12] > 180)
              aiMatrix1.Value[index11, index12] = 180 + (int) Math.Round((double) (aiMatrix1.Value[index11, index12] - 180) * 0.25);
            if (aiMatrix1.Value[index11, index12] > 200)
              aiMatrix1.Value[index11, index12] = 200;
            if (aiMatrix1.Value[index11, index12] == 0)
              aiMatrix1.Value[index11, index12] = 1;
            if (frontArea.Value[index11, index12] != th.front.FrontID)
              aiMatrix1.Value[index11, index12] = (int) Math.Round((double) aiMatrix1.Value[index11, index12] / 3.0);
          }
        }
      }
      return aiMatrix1;
    }

    public AIMatrix SetCenterOfValueAreaMatrix(AIMatrix useMatrix, int useNumber)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai, useMatrix.Width, useMatrix.Height, useMatrix.Top, useMatrix.Left);
      MapClass mapClass = this.game.Data.MapObj[0];
      int num1 = 0;
      do
      {
        int num2 = 0;
        int width = useMatrix.Width;
        for (int index1 = 0; index1 <= width; ++index1)
        {
          int height = useMatrix.Height;
          for (int index2 = 0; index2 <= height; ++index2)
          {
            if (aiMatrix.Value[index1, index2] == 0)
            {
              bool flag = false;
              if (useMatrix.Value[index1, index2] == useNumber)
              {
                int index3 = 0;
                do
                {
                  Coordinate coordinate = this.TempHexNeighbour[index1, index2, index3];
                  if (coordinate.onmap)
                  {
                    if (coordinate.x <= useMatrix.Width & coordinate.y <= useMatrix.Height)
                    {
                      if (useMatrix.Value[coordinate.x, coordinate.y] != useNumber)
                        flag = true;
                      else if (aiMatrix.Value[coordinate.x, coordinate.y] == num1 & num1 != 0)
                        flag = true;
                    }
                    else
                      flag = true;
                  }
                  else
                    flag = true;
                  ++index3;
                }
                while (index3 <= 5);
              }
              if (flag)
              {
                aiMatrix.Value[index1, index2] = num1 + 1;
                num2 = 1;
              }
            }
          }
        }
        if (num2 != 0)
          ++num1;
        else
          break;
      }
      while (num1 <= 99);
      return aiMatrix;
    }

    public AIMatrix SetTroopReach(ref AITheater theater)
    {
      AIMatrix aiMatrix = new AIMatrix(ref theater.ai, theater.Width, theater.Height, theater.Top, theater.Left);
      int counter = theater.front.units.counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(theater.front.units.AIid[index1]);
        if (unitByAiid > -1)
        {
          int lowestAp = this.game.HandyFunctionsObj.GetLowestAp(unitByAiid);
          if (unitByAiid > -1)
          {
            int width = theater.Width;
            for (int index2 = 0; index2 <= width; ++index2)
            {
              int height = theater.Height;
label_10:
              for (int index3 = 0; index3 <= height; ++index3)
              {
                int index4 = 0;
                while (!(theater.MoveCostAttack[index1, index4].Value[index2, index3] <= lowestAp | theater.MoveCostMove[index1].Value[index2, index3] <= lowestAp))
                {
                  ++index4;
                  if (index4 > 5)
                    goto label_10;
                }
                int num1 = theater.MoveCostAttack[index1, index4].Value[index2, index3] - lowestAp;
                int tempUnitPowerAbs = this.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
                int num2 = !(theater.MoveCostMove[index1].Value[index2, index3] == 0 & this.GetMatrixX(this.game.Data.UnitObj[unitByAiid].FreeCombatX, theater.Left) == index2 & this.game.Data.UnitObj[unitByAiid].FreeCombatY == index3 + theater.Top) ? (int) Math.Round((double) (tempUnitPowerAbs * lowestAp) / 100.0) : (int) Math.Round((double) (tempUnitPowerAbs * (lowestAp + 20)) / 100.0);
                int[,] numArray1 = aiMatrix.Value;
                int[,] numArray2 = numArray1;
                int index5 = index2;
                int index6 = index5;
                int index7 = index3;
                int index8 = index7;
                int num3 = numArray1[index5, index7] + num2;
                numArray2[index6, index8] = num3;
              }
            }
          }
        }
      }
      return aiMatrix;
    }

    public void SetTempHexNeighbours()
    {
      this.map = DrawMod.TGame.Data.MapObj[0];
      if (this.TempHexNeighboursSet && !Information.IsNothing((object) this.TempHexNeighbour) && this.TempHexNeighbour.GetUpperBound(0) == this.map.MapWidth & this.TempHexNeighbour.GetUpperBound(1) == this.map.MapHeight)
        return;
      this.TempHexNeighbour = new Coordinate[this.map.MapWidth + 1, this.map.MapHeight + 1, 6];
      int mapWidth = this.map.MapWidth;
      for (int cx = 0; cx <= mapWidth; ++cx)
      {
        int mapHeight = this.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          int index = 0;
          do
          {
            Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index + 1);
            this.TempHexNeighbour[cx, cy, index] = coordinate;
            ++index;
          }
          while (index <= 5);
        }
      }
      this.TempHexNeighboursSet = true;
    }

    public void SetTempUnitPowerAndVarDefensiveMod()
    {
      this.ClearLog();
      int[,] numArray1 = new int[this.game.Data.SFTypeCounter + 1, 3];
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int type = this.game.Data.SFObj[sf].Type;
            int qty = this.game.Data.SFObj[sf].Qty;
            if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index1].PreDef == -1)
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
            else if (this.game.Data.UnitObj[index1].PreDef == -1)
            {
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
      float[,] numArray6 = new float[this.game.Data.SFTypeCounter + 1, 3];
      float[] numArray7 = new float[this.game.Data.SFTypeCounter + 1];
      float[] numArray8 = new float[this.game.Data.SFTypeCounter + 1];
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index11 = 0; index11 <= sfTypeCounter1; ++index11)
      {
        if (numArray1[index11, 0] > 0)
        {
          long num1 = 0;
          int sfTypeCounter2 = this.game.Data.SFTypeCounter;
          for (int index12 = 0; index12 <= sfTypeCounter2; ++index12)
          {
            if (numArray1[index12, 1] > 0)
            {
              if (this.game.Data.SFTypeObj[index11].AttackPower[this.game.Data.SFTypeObj[index12].UnitGroup] > 0)
              {
                num1 += (long) numArray1[index12, 1];
                float[,] numArray9 = numArray6;
                float[,] numArray10 = numArray9;
                int index13 = index11;
                int index14 = index13;
                int index15 = 0;
                int index16 = index15;
                double num2 = (double) numArray9[index13, index15] + ((double) this.combatMatrix[index11, index12] + 1.0 / (double) this.combatMatrix[index12, index11]) / 2.0 * (double) numArray1[index12, 1];
                numArray10[index14, index16] = (float) num2;
                float[] numArray11 = numArray7;
                float[] numArray12 = numArray11;
                int index17 = index11;
                int index18 = index17;
                double num3 = (double) numArray11[index17] + 1.0 / (double) this.combatMatrix[index12, index11] * (double) numArray1[index12, 1];
                numArray12[index18] = (float) num3;
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
        }
        if (numArray1[index11, 1] > 0)
        {
          long num4 = 0;
          int sfTypeCounter3 = this.game.Data.SFTypeCounter;
          for (int index19 = 0; index19 <= sfTypeCounter3; ++index19)
          {
            if (numArray1[index19, 0] > 0 && this.game.Data.SFTypeObj[index11].AttackPower[this.game.Data.SFTypeObj[index19].UnitGroup] > 0)
            {
              num4 += (long) numArray1[index19, 0];
              float[,] numArray13 = numArray6;
              float[,] numArray14 = numArray13;
              int index20 = index11;
              int index21 = index20;
              int index22 = 1;
              int index23 = index22;
              double num5 = (double) numArray13[index20, index22] + ((double) this.combatMatrix[index11, index19] + (double) this.combatMatrix[index19, index11]) / 2.0 * (double) numArray1[index19, 0];
              numArray14[index21, index23] = (float) num5;
              float[] numArray15 = numArray8;
              float[] numArray16 = numArray15;
              int index24 = index11;
              int index25 = index24;
              double num6 = (double) numArray15[index24] + 1.0 / (double) this.combatMatrix[index19, index11] * (double) numArray1[index19, 0];
              numArray16[index25] = (float) num6;
            }
          }
          if (num4 > 0L)
          {
            numArray6[index11, 1] = numArray6[index11, 1] / (float) num4;
            numArray8[index11] = numArray8[index11] / (float) num4;
          }
          else
          {
            numArray6[index11, 1] = 0.25f;
            numArray8[index11] = 0.25f;
          }
        }
      }
      long num7 = 0;
      long num8 = 0;
      int sfTypeCounter4 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter4; ++index)
      {
        if ((double) numArray7[index] > 0.0)
        {
          num7 += (long) numArray1[index, 0];
          num8 += (long) (int) Math.Round((double) (numArray7[index] * (float) numArray1[index, 0]));
        }
      }
      if (num7 > 0L)
        this.VAR_DEFENSIVE_WORLD_MODIFIER_FRIENDLY = (float) num8 / (float) num7;
      long num9 = 0;
      long num10 = 0;
      int sfTypeCounter5 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter5; ++index)
      {
        if ((double) numArray8[index] > 0.0)
        {
          num9 += (long) numArray1[index, 1];
          num10 += (long) (int) Math.Round((double) (numArray8[index] * (float) numArray1[index, 1]));
        }
      }
      if (num9 > 0L)
        this.VAR_DEFENSIVE_WORLD_MODIFIER_ENEMY = (float) num10 / (float) num9;
      this.AddLog("ENEMY FORCES");
      int sfTypeCounter6 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter6; ++index)
      {
        this.game.Data.SFTypeObj[index].TempAvgCombatMatrixAtt = 1f;
        this.game.Data.SFTypeObj[index].TempAvgCombatMatrixDef = 1f;
        if (numArray1[index, 1] > 0)
        {
          this.AddLog(numArray1[index, 1].ToString() + "x " + this.game.Data.SFTypeObj[index].Name + "  ....... " + numArray6[index, 1].ToString());
          this.game.Data.SFTypeObj[index].TempAvgCombatMatrixAtt = numArray6[index, 1];
          this.game.Data.SFTypeObj[index].TempAvgCombatMatrixDef = numArray6[index, 1];
        }
      }
      this.AddLog("");
      this.AddLog("FRIENDLY FORCES");
      int sfTypeCounter7 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter7; ++index)
      {
        if (numArray1[index, 0] > 0)
        {
          this.AddLog(numArray1[index, 0].ToString() + "x " + this.game.Data.SFTypeObj[index].Name + "  ....... " + numArray6[index, 0].ToString());
          this.game.Data.SFTypeObj[index].TempAvgCombatMatrixAtt = numArray6[index, 0];
          this.game.Data.SFTypeObj[index].TempAvgCombatMatrixDef = numArray6[index, 0];
        }
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter2; ++unr)
      {
        int num11 = 0;
        int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
        for (int index = 0; index <= sfCount1; ++index)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index];
          if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
            num11 += this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts * 10 * this.game.Data.SFObj[sf].Qty;
          else if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
            num11 += (int) Math.Round((double) ((float) (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts * 10 * this.game.Data.SFObj[sf].Qty) * numArray6[this.game.Data.SFObj[sf].Type, 0]));
          else
            num11 += (int) Math.Round((double) ((float) (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts * 10 * this.game.Data.SFObj[sf].Qty) * numArray6[this.game.Data.SFObj[sf].Type, 1]));
        }
        this.game.Data.UnitObj[unr].TempUnitPower = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true);
        this.game.Data.UnitObj[unr].TempUnitPower = num11;
        if (this.game.Data.UnitObj[unr].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].AIHelpCombat > 0)
        {
          this.CustomCalls.CustomHelpCombatModifier(this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].AIHelpCombat, this.game.Data.UnitObj[unr].Regime);
          UnitClass[] unitObj = this.game.Data.UnitObj;
          UnitClass[] unitClassArray = unitObj;
          int index26 = unr;
          int index27 = index26;
          unitClassArray[index27].TempUnitPower = unitObj[index26].TempUnitPower + (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * ((double) this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].AIHelpCombat / 100.0));
        }
        this.game.Data.UnitObj[unr].TempUnitPowerAbs = this.game.Data.UnitObj[unr].TempUnitPower;
        this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) (this.game.Data.UnitObj[unr].TempUnitPower * this.game.Data.UnitObj[unr].SupplyConsume) / 100.0);
        if (this.game.Data.UnitObj[unr].HQ > -1 & !this.game.Data.UnitObj[unr].IsHQ)
          this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) (this.game.Data.UnitObj[unr].TempUnitPower * 1) + (double) (this.game.Data.UnitObj[unr].TempUnitPower * 1) * ((double) this.game.HandyFunctionsObj.GetStaffPercent(this.game.Data.UnitObj[unr].HQ, true) / 100.0));
        this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * 0.1 + (double) this.game.Data.UnitObj[unr].TempUnitPower * 0.9 * (double) this.game.HandyFunctionsObj.GetAverageXp(unr) / 100.0);
        this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * 0.25 + (double) this.game.Data.UnitObj[unr].TempUnitPower * 0.75 * (double) this.game.HandyFunctionsObj.GetAverageRdn(unr) / 100.0);
        if ((double) this.game.Data.RuleVar[434] > 0.0 & this.game.Data.Product >= 6)
          this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * 0.1 + (double) this.game.Data.UnitObj[unr].TempUnitPower * 0.6 * (double) (100 + this.game.HandyFunctionsObj.GetAverageOffensiveMod(unr)) / 100.0 + (double) this.game.Data.UnitObj[unr].TempUnitPower * 0.3 * (double) (100 + this.game.HandyFunctionsObj.GetAverageDefensiveMod(unr)) / 100.0);
        if (this.game.Data.UnitObj[unr].TempUnitPower < 0)
          this.game.Data.UnitObj[unr].TempUnitPower = 0;
        float unitPowerModifier = this.CustomCalls.GetUnitPowerModifier(unr);
        this.game.Data.UnitObj[unr].TempUnitPowerAbs = (int) Math.Round((double) ((float) this.game.Data.UnitObj[unr].TempUnitPowerAbs * unitPowerModifier));
        this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) ((float) this.game.Data.UnitObj[unr].TempUnitPower * unitPowerModifier));
        if (this.game.Data.UnitObj[unr].Regime == 4 && this.game.Data.UnitObj[unr].Historical > -1)
          unr = unr;
        if ((double) this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION > 0.0 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[unr].Regime, this.game.Data.Turn))
        {
          this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) ((float) this.game.Data.UnitObj[unr].TempUnitPower * this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION));
          this.game.Data.UnitObj[unr].TempUnitPowerAbs = (int) Math.Round((double) ((float) this.game.Data.UnitObj[unr].TempUnitPowerAbs * this.VAR_MODIFY_OWN_STRENGTH_PERCEPTION));
        }
        this.game.Data.UnitObj[unr].TempAIString = "";
        this.game.Data.UnitObj[unr].TempUnitAP = this.game.HandyFunctionsObj.GetLowestAp(unr);
        this.game.Data.UnitObj[unr].TempLisItemPercentage = 100;
        if ((double) this.game.Data.RuleVar[407] > 0.0 & this.game.Data.Product > 6 & this.game.Data.UnitObj[unr].PreDef == -1)
        {
          SimpleList simpleList = new SimpleList();
          int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
          for (int index = 0; index <= sfCount2; ++index)
          {
            int sf = this.game.Data.UnitObj[unr].SFList[index];
            int type = this.game.Data.SFObj[sf].Type;
            if (this.game.Data.SFTypeObj[type].SFTypeVar[47] > 0)
            {
              int num12 = 0;
              int tweight = this.game.Data.SFTypeObj[type].EndCombatRound <= 0 ? num12 + this.game.Data.SFTypeObj[type].SFTypeVar[48] * this.game.Data.SFObj[sf].Qty : num12 + (int) Math.Round((double) this.game.Data.SFTypeObj[type].SFTypeVar[48] * ((double) this.game.Data.SFTypeObj[type].EndCombatRound / 10.0) * (double) this.game.Data.SFObj[sf].Qty);
              if (tweight > 0)
                simpleList.AddWeight(this.game.Data.SFTypeObj[type].SFTypeVar[47], tweight);
            }
            if (this.game.Data.SFTypeObj[type].SFTypeVar[45] > 0 & this.game.Data.SFTypeObj[type].ArtRange < 1)
            {
              int num13 = 0;
              int tweight = this.game.Data.SFTypeObj[type].EndCombatRound <= 0 ? num13 + this.game.Data.SFTypeObj[type].SFTypeVar[46] * this.game.Data.SFObj[sf].Qty : num13 + (int) Math.Round((double) this.game.Data.SFTypeObj[type].SFTypeVar[46] * ((double) this.game.Data.SFTypeObj[type].EndCombatRound / 10.0) * (double) this.game.Data.SFObj[sf].Qty);
              if (tweight > 0)
                simpleList.AddWeight(this.game.Data.SFTypeObj[type].SFTypeVar[45], tweight);
            }
          }
          if (simpleList.Counter > -1)
          {
            int counter = simpleList.Counter;
            for (int index = 0; index <= counter; ++index)
            {
              int num14 = simpleList.Weight[index];
              int num15 = this.game.Data.UnitObj[unr].items.list.FindWeight(simpleList.Id[index]);
              if (this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn)
                num15 *= 2;
              if (num14 > num15)
                num15 = num15;
              if (num14 > 0)
              {
                this.game.Data.UnitObj[unr].TempUnitPower = (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * 0.66 * (double) Math.Min(1f, (float) num15 / (float) num14)) + (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * 0.33);
                this.game.Data.UnitObj[unr].TempLisItemPercentage = (int) Math.Round((double) (100f * Math.Min(1f, (float) num15 / (float) num14)));
              }
            }
          }
        }
        this.AddLog(this.game.Data.UnitObj[unr].Name + ". PowerAbs = " + this.game.Data.UnitObj[unr].TempUnitPowerAbs.ToString() + ", Power = " + this.game.Data.UnitObj[unr].TempUnitPower.ToString());
      }
      this.WriteLog("0003_tempUnitPower");
    }

    public void SetTempLandscapeDefenseBonus()
    {
      this.ClearLog();
      this.AddLog("TEMP LANDSCAPE DEFENSE BONUSES");
      int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
      for (int index1 = 0; index1 <= landscapeTypeCounter; ++index1)
      {
        this.game.Data.LandscapeTypeObj[index1].TempDefenseBonus = 0;
        int num1 = 0;
        int index2 = 0;
        do
        {
          int num2 = 0;
          int sfTypeCounter = this.game.Data.SFTypeCounter;
          for (int index3 = 0; index3 <= sfTypeCounter; ++index3)
          {
            if (this.game.Data.SFTypeObj[index3].Theater == 0 && this.game.Data.SFTypeObj[index3].UnitGroup == index2)
            {
              num2 = 1;
              break;
            }
          }
          if (num2 == 1)
          {
            int num3 = (int) Math.Round((double) ((int) Math.Round((double) this.game.Data.LandscapeTypeObj[index1].DefBonusMax[index2]) + (int) Math.Round((double) this.game.Data.LandscapeTypeObj[index1].DefBonus[index2])) / 2.0);
            if (num3 > num1)
              num1 = num3;
          }
          ++index2;
        }
        while (index2 <= 99);
        if (num1 > 0)
        {
          int num4 = num1;
          this.game.Data.LandscapeTypeObj[index1].TempDefenseBonus = num4;
          this.AddLog(this.game.Data.LandscapeTypeObj[index1].Name + " = " + num4.ToString());
        }
      }
      this.WriteLog("0004_tempLandscapeDefenseBonus");
    }

    public void SetTempRiverDefenseBonus()
    {
      this.ClearLog();
      this.AddLog("RIVER DEFENSE BONUSES");
      int riverTypeCounter = this.game.Data.RiverTypeCounter;
      for (int index1 = 0; index1 <= riverTypeCounter; ++index1)
      {
        this.game.Data.RiverTypeObj[index1].TempDefenseBonus = 0;
        int num1 = 0;
        int num2 = 0;
        int index2 = 0;
        do
        {
          int num3 = 0;
          int sfTypeCounter = this.game.Data.SFTypeCounter;
          for (int index3 = 0; index3 <= sfTypeCounter; ++index3)
          {
            if (this.game.Data.SFTypeObj[index3].Theater == 0 && this.game.Data.SFTypeObj[index3].UnitGroup == index2)
            {
              num3 = 1;
              break;
            }
          }
          if (num3 == 1)
          {
            int num4 = (int) Math.Round(100.0 * (1.0 / (1.0 - (double) this.game.Data.RiverTypeObj[index1].AttackPenalty[index2]))) - 100;
            if (num4 < 0)
              num4 = 0;
            num1 += num4;
            ++num2;
          }
          ++index2;
        }
        while (index2 <= 99);
        if (num1 > 0)
        {
          int num5 = (int) Math.Round((double) num1 / (double) num2);
          this.game.Data.RiverTypeObj[index1].TempDefenseBonus = num5;
          this.AddLog(this.game.Data.RiverTypeObj[index1].Name + " = " + num5.ToString());
        }
      }
      this.WriteLog("0005_tempRiverDefenseBonus");
    }

    public void SetTempUnitCategories()
    {
      this.ClearLog();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        this.game.Data.UnitObj[index1].TempCategory2 = 0;
        this.game.Data.UnitObj[index1].TempAIForbidsMove = false;
        int unr1 = index1;
        int unr2 = index1;
        if (this.game.Data.UnitObj[unr1].Historical > -1 & this.game.Data.UnitObj[unr1].HistoricalSubPart > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr1].Historical].SubParts[this.game.Data.UnitObj[unr1].HistoricalSubPart] > -1)
          unr2 = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr1].Historical].SubParts[this.game.Data.UnitObj[unr1].HistoricalSubPart]);
        if (unr1 == 886)
          unr1 = unr1;
        if (this.game.Data.UnitObj[unr1].PreDef == -1)
        {
          if (this.game.Data.UnitObj[unr1].IsHQ)
          {
            if (this.game.Data.UnitObj[unr1].Historical > -1)
            {
              int historical = this.game.Data.UnitObj[unr1].Historical;
              this.game.Data.UnitObj[unr1].TempCategory = this.game.Data.HistoricalUnitObj[historical].Type > 5 ? (this.game.Data.HistoricalUnitObj[historical].Type != 6 ? 12 : 11) : 10;
            }
            else
              this.game.Data.UnitObj[unr1].TempCategory = 10;
          }
          else if (this.GetAIRolePercent(unr2, 17) > 20)
            this.game.Data.UnitObj[unr1].TempCategory = 6;
          else if (this.GetAIRolePercent(unr2, 18) > 20)
            this.game.Data.UnitObj[unr1].TempCategory = 7;
          else if (this.GetAIRolePercent(unr2, 19) > 20)
            this.game.Data.UnitObj[unr1].TempCategory = 7;
          else if (this.game.HandyFunctionsObj.HasUnitNavySF(unr2))
            this.game.Data.UnitObj[unr1].TempCategory = this.game.HandyFunctionsObj.GetUnitCarryCap(unr1, 1) <= 0 ? 7 : 6;
          else if (this.GetAIRolePercent(unr2, 8) > 20 & this.game.Data.Product < 7)
            this.game.Data.UnitObj[unr1].TempCategory = 2;
          else if (this.GetAIRolePercent(unr2, 8) > 50 & this.game.Data.Product >= 7)
            this.game.Data.UnitObj[unr1].TempCategory = 2;
          else if (this.GetAIRolePercent(unr2, 12) > 20)
          {
            this.game.Data.UnitObj[unr1].TempCategory = 5;
            this.game.Data.UnitObj[unr1].TempCategory2 = 14;
          }
          else if (this.GetAIRolePercent(unr2, 16) > 20)
            this.game.Data.UnitObj[unr1].TempCategory = 8;
          else if (this.GetAIRolePercent(unr2, 13) > 20)
            this.game.Data.UnitObj[unr1].TempCategory = 3;
          else if (this.GetAIRolePercent(unr2, 14) + this.GetAIRolePercent(unr1, 15) > 20)
            this.game.Data.UnitObj[unr1].TempCategory = 13;
          else if (this.GetAIRolePercent(unr2, 5) > 20)
          {
            this.game.Data.UnitObj[unr1].TempCategory = 4;
            if (this.game.Data.Product >= 5 & (double) this.game.Data.RuleVar[503] == 1.0)
              this.game.Data.UnitObj[unr1].TempCategory = 1;
          }
          else if (this.GetAIRolePercent(unr2, 7) > 50 & this.game.Data.Product >= 6)
          {
            if (this.game.HandyFunctionsObj.GetMaxArtRange(unr1, 0) >= 1)
            {
              this.game.Data.UnitObj[unr1].TempCategory = 2;
            }
            else
            {
              this.game.Data.UnitObj[unr1].TempCategory = 1;
              this.game.Data.UnitObj[unr1].TempCategory2 = 14;
            }
          }
          else
            this.game.Data.UnitObj[unr1].TempCategory = 1;
          if (this.game.Data.Product == 6 && this.game.Data.UnitObj[unr1].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[unr1].IsHQ)
          {
            int num1 = 0;
            int num2 = 0;
            int sfCount = this.game.Data.UnitObj[unr1].SFCount;
            for (int index2 = 0; index2 <= sfCount; ++index2)
            {
              int sf = this.game.Data.UnitObj[unr1].SFList[index2];
              int type = this.game.Data.SFObj[sf].Type;
              num1 += this.game.Data.SFTypeObj[type].Attacks;
              if (this.game.Data.SFTypeObj[type].CarryCap > 0 && this.game.Data.SFTypeObj[type].manpowerCarry > 0)
                num2 += this.game.Data.SFObj[sf].Qty;
            }
            if (num2 > 0 & num1 == 0)
            {
              this.game.Data.UnitObj[unr1].TempCategory = 2;
              this.game.Data.UnitObj[unr1].TempCategory2 = 14;
              this.game.Data.UnitObj[unr1].SOReplacementPercent = 0;
            }
          }
          if (this.game.Data.UnitObj[unr1].TempCategory2 > 0)
            this.AddLog(this.game.Data.UnitObj[unr1].Name + " = " + this.game.Data.UnitObj[unr1].TempCategory.ToString() + " *** Cat2 = " + this.game.Data.UnitObj[unr1].TempCategory2.ToString() + " ***");
          else
            this.AddLog(this.game.Data.UnitObj[unr1].Name + " = " + this.game.Data.UnitObj[unr1].TempCategory.ToString());
        }
      }
      this.WriteLog("0007_tempUnitCategories");
    }

    public void SetTempTopUnits()
    {
      this.ClearLog();
      int num1 = 33;
      int num2 = 101;
      int num3 = 20;
      int num4 = 100;
      if (this.game.Data.Product == 6)
      {
        num2 = 33;
        num1 = 20;
        num3 = 30;
        num4 = 30;
      }
      this.AddLog("TEMP TOP UNITS");
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        int index2;
        this.game.Data.UnitObj[index2].TempTopUnit = false;
        this.game.Data.UnitObj[index1].TempProtector = false;
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter2; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1)
        {
          if (this.GetAIRolePercent(unr, 6) > 30)
            unr = unr;
          if (this.GetAIRolePercent(unr, 10) > num1 && this.GetAIRolePercent(unr, 6) < num2)
          {
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int index = 0; index <= unitCounter3; ++index)
            {
              if (this.game.Data.UnitObj[index].Historical == this.game.Data.UnitObj[unr].Historical && this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.game.Data.UnitObj[unr].Historical) >= this.VAR_TOP_UNIT_MINIMUM_ARMOR_SUBUNITS)
              {
                this.game.Data.UnitObj[index].TempTopUnit = true;
                this.AddLog("* " + this.game.Data.UnitObj[unr].Name);
              }
            }
          }
        }
      }
      this.WriteLog("0006_tempTopUnits");
    }

    public void SetTempUnitGroupCleared()
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].AIGroup = -1;
    }

    public void SetUnitAIid()
    {
      this.game.Data.AIUnitCounter = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        ++this.game.Data.AIUnitCounter;
        this.game.Data.UnitObj[index].AIid = this.game.Data.AIUnitCounter;
      }
    }

    public void MakeTempMovementTypes()
    {
      bool flag = true;
      this.ClearLog();
      if (flag)
        this.AddLog("MAKETEMPMOVEMENTTYPES");
      if (flag)
        this.AddLog("");
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].PreDef == -1)
        {
          this.MakeTempMovementType(index);
          if (flag)
          {
            string str1 = Strings.Trim(Conversion.Str((object) index)) + ", " + this.game.Data.UnitObj[index].Name;
            string str2 = this.game.Data.UnitObj[index].TempType <= -1 ? str1 + ", TempType = -1 " : str1 + ", TempType = " + this.game.Data.SFTypeObj[this.game.Data.UnitObj[index].TempType].Name;
            this.AddLog((this.game.Data.UnitObj[index].TempTypeRoad <= -1 ? str2 + ", TempTypeRoad = -1 " : str2 + ", TempTypeRoad = " + this.game.Data.SFTypeObj[this.game.Data.UnitObj[index].TempTypeRoad].Name) + ", TempTheater = " + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[index].TempTheater)));
          }
        }
      }
      this.WriteLog("0001_tempmovementtypes");
    }

    public void MakeTempMovementType(int unr)
    {
      if (this.game.Data.UnitObj[unr].PreDef > -1)
        return;
      int num1 = !this.game.HandyFunctionsObj.HasUnitNavySF(unr) ? (!this.game.HandyFunctionsObj.HasUnitAirSF(unr) ? (!this.game.HandyFunctionsObj.HasUnitlandSF(unr) ? -1 : 0) : 2) : 1;
      if (this.game.Data.UnitObj[unr].IsHQ)
        num1 = num1;
      if (num1 == -1)
        num1 = 0;
      int num2 = this.game.HandyFunctionsObj.GetLowestSpeed(unr, -1);
      if (num2 == -1)
        num2 = 0;
      this.game.Data.UnitObj[unr].TempType = num2;
      if (unr == 109)
        unr = unr;
      int num3 = this.game.HandyFunctionsObj.GetLowestSpeedOnRoad(unr, -1);
      if (num3 == -1)
        num3 = 0;
      this.game.Data.UnitObj[unr].TempTypeRoad = num3;
      this.game.Data.UnitObj[unr].TempTheater = num1;
    }

    public void SetTemp()
    {
      this.SetTempMostUsedMovementType();
      this.MakeCombatMatrix(true);
      this.SetTempHexNeighbours();
      this.SetTempUnitPowerAndVarDefensiveMod();
      this.SetTempUnitCategories();
      this.SetTempUnitGroupCleared();
      this.SetTempLandscapeDefenseBonus();
      this.SetTempRiverDefenseBonus();
      this.SetUnitAIid();
      this.MakeTempMovementTypes();
      this.SetTempTopUnits();
    }

    public void SetTempMostUsedMovementType()
    {
      SimpleList simpleList = new SimpleList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].X > -1)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int type = this.game.Data.SFObj[sf].Type;
            int moveType = this.game.Data.SFTypeObj[type].MoveType;
            int tweight = this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
            int nr = simpleList.FindNr(moveType);
            if (nr > -1)
            {
              int[] weight = simpleList.Weight;
              int[] numArray = weight;
              int index3 = nr;
              int index4 = index3;
              int num = weight[index3] + tweight;
              numArray[index4] = num;
            }
            else
              simpleList.Add(moveType, tweight);
          }
        }
      }
      simpleList.ReverseSort();
      this.VAR_MOST_USED_MOVEMENTYPE = simpleList.Id[0];
    }

    public void SetTempCombatMatrix()
    {
    }

    public void MakeCombatMatrix(bool tlog)
    {
      this.ClearLog();
      this.combatMatrix = new float[this.game.Data.SFTypeCounter + 1, this.game.Data.SFTypeCounter + 1];
      if (tlog)
        this.AddLog("COMBATMATRIX");
      if (tlog)
        this.AddLog("");
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index1 = 0; index1 <= sfTypeCounter1; ++index1)
      {
        if (tlog)
          this.AddLog("********* " + this.game.Data.SFTypeObj[index1].Name + " VERSUS: ");
        int sfTypeCounter2 = this.game.Data.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter2; ++index2)
        {
          int num1 = this.game.Data.SFTypeObj[index1].AttackPower[this.game.Data.SFTypeObj[index2].UnitGroup] * this.game.Data.SFTypeObj[index1].Attacks;
          int num2 = this.game.Data.SFTypeObj[index2].AttackPowerDef[this.game.Data.SFTypeObj[index1].UnitGroup] * this.game.Data.SFTypeObj[index2].Attacks;
          int num3 = this.game.Data.SFTypeObj[index1].HitPoints[this.game.Data.SFTypeObj[index2].UnitGroup];
          int num4 = this.game.Data.SFTypeObj[index2].HitPointsDef[this.game.Data.SFTypeObj[index1].UnitGroup];
          if (num4 == 0)
            num4 = num3;
          if (num3 == 0)
            num3 = num4;
          int num5 = this.game.Data.SFTypeObj[index1].PowerPts;
          int num6 = this.game.Data.SFTypeObj[index2].PowerPts;
          if (num6 == 0)
            num6 = 1;
          if (num5 == 0)
            num5 = 1;
          float num7 = 1f;
          float num8 = 1f;
          if (num5 > num6)
          {
            num2 = (int) Math.Round((double) num2 * ((double) num5 / (double) num6));
            num4 = (int) Math.Round((double) num4 * ((double) num5 / (double) num6));
            num8 *= (float) num5 / (float) num6;
          }
          else if (num6 > num5)
          {
            num1 = (int) Math.Round((double) num1 * ((double) num6 / (double) num5));
            num3 = (int) Math.Round((double) num3 * ((double) num6 / (double) num5));
            num7 *= (float) num6 / (float) num5;
          }
          if ((double) num7 * (double) this.game.Data.SFTypeObj[index1].Attacks > (double) num8 * (double) this.game.Data.SFTypeObj[index2].MaxAttacked)
            num1 = (int) Math.Round((double) ((float) num1 * (float) ((double) num8 * (double) this.game.Data.SFTypeObj[index2].MaxAttacked / ((double) num7 * (double) this.game.Data.SFTypeObj[index1].Attacks))));
          if ((double) num8 * (double) this.game.Data.SFTypeObj[index2].Attacks > (double) num7 * (double) this.game.Data.SFTypeObj[index1].MaxAttacked)
            num2 = (int) Math.Round((double) ((float) num2 * (float) ((double) num7 * (double) this.game.Data.SFTypeObj[index1].MaxAttacked / ((double) num8 * (double) this.game.Data.SFTypeObj[index2].Attacks))));
          float num9 = (float) num1 / (float) num4;
          float num10 = (float) num2 / (float) num3;
          float Number = (double) num10 <= 0.0 ? (!((double) num9 == 0.0 & this.game.Data.Product >= 5) ? (!((double) num10 == 0.0 & this.game.Data.Product >= 5) ? 25f : 10f) : 1f) : num9 / num10;
          if ((double) Number > 5.0)
            Number = 5f + (float) Math.Sqrt((double) Number - 4.0);
          if ((double) Number < 0.125)
            Number = 0.125f;
          int theater1 = this.game.Data.SFTypeObj[index1].Theater;
          int theater2 = this.game.Data.SFTypeObj[index2].Theater;
          if (theater1 == 0 & theater2 == 2)
            Number = 10f;
          if (index1 == 81 & index2 == 81)
            index1 = index1;
          this.combatMatrix[index1, index2] = Number;
          if (theater1 == theater2 | (double) num9 > 0.0 && tlog)
            this.AddLog(this.game.Data.SFTypeObj[index2].Name + " = " + Conversion.Str((object) Number));
        }
      }
      this.WriteLog("0002_combatmatrix");
    }

    public void ExecuteUberUnter()
    {
      if (!this.VAR_USE_UBER_UNTER_RULES)
        return;
      this.AddLog("UBER-UNTER... GIVE UNIT");
      SimpleList simpleList1 = new SimpleList();
      int num1 = 8;
      do
      {
        SimpleList simpleList2 = new SimpleList();
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index1 = 0; index1 <= unitCounter1; ++index1)
        {
          int historical = this.game.Data.UnitObj[index1].Historical;
          if (historical > -1 & this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].X > -1 && this.game.Data.HistoricalUnitObj[historical].Type == num1)
          {
            int regime = this.game.Data.UnitObj[index1].Regime;
            int unr = 1;
            if (this.game.HandyFunctionsObj.HasUnitNavySF(unr))
              unr = 0;
            if (this.game.Data.UnitObj[index1].TempCategory == 8)
              unr = 0;
            if (unr == 1 && this.GetRegime(regime) == this.GetGameDataTurn() && this.game.Data.RegimeObj[regime].UberRegime > -1)
            {
              if (simpleList2.FindNr(regime) > -1)
              {
                int[] weight = simpleList2.Weight;
                int[] numArray = weight;
                int nr = simpleList2.FindNr(regime);
                int index2 = nr;
                int num2 = weight[nr] + 1;
                numArray[index2] = num2;
              }
              else
                simpleList2.Add(regime, 1);
            }
          }
        }
        if (simpleList2.Counter > -1)
        {
          simpleList2.Sort();
          int num3 = simpleList2.Id[0];
          if (num3 > -1)
          {
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int unr1 = 0; unr1 <= unitCounter2; ++unr1)
            {
              int historical = this.game.Data.UnitObj[unr1].Historical;
              if (historical > -1 & this.game.Data.UnitObj[unr1].PreDef == -1 & this.game.Data.UnitObj[unr1].X > -1 && this.game.Data.HistoricalUnitObj[historical].Type == num1)
              {
                int regime = this.game.Data.UnitObj[unr1].Regime;
                int unr2 = 1;
                if (this.game.HandyFunctionsObj.HasUnitNavySF(unr2))
                  unr2 = 0;
                if (this.game.Data.UnitObj[unr1].TempCategory == 8)
                  unr2 = 0;
                if (unr2 == 1 && this.GetRegime(regime) == this.GetGameDataTurn() && this.game.Data.RegimeObj[regime].UberRegime <= -1)
                {
                  this.GiveAUnit(unr1, num3);
                  int[] weight = simpleList2.Weight;
                  int[] numArray = weight;
                  int nr = simpleList2.FindNr(num3);
                  int index = nr;
                  int num4 = weight[nr] + 1;
                  numArray[index] = num4;
                  simpleList2.Sort();
                  num3 = simpleList2.Id[0];
                }
              }
            }
          }
        }
        num1 += -1;
      }
      while (num1 >= 1);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
      {
        int counter1 = this.masterPlan.Counter;
        for (int index3 = 0; index3 <= counter1; ++index3)
        {
          AIFront aiFront = this.masterPlan.Front[index3];
          SimpleList simpleList3 = new SimpleList();
          int counter2 = aiFront.units.counter;
          for (int index4 = 0; index4 <= counter2; ++index4)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index4]);
            if (unitByAiid > -1)
            {
              int regime = this.game.Data.UnitObj[unitByAiid].Regime;
              if (this.game.Data.RegimeObj[regime].UberRegime > -1)
              {
                if (simpleList3.FindNr(regime) > -1)
                {
                  int[] weight = simpleList3.Weight;
                  int[] numArray = weight;
                  int nr = simpleList3.FindNr(regime);
                  int index5 = nr;
                  int num5 = weight[nr] + 1;
                  numArray[index5] = num5;
                }
                else
                  simpleList3.Add(regime, 1);
              }
            }
          }
          int counter3 = aiFront.artUnits.counter;
          for (int index6 = 0; index6 <= counter3; ++index6)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.artUnits.AIid[index6]);
            if (unitByAiid > -1)
            {
              int regime = this.game.Data.UnitObj[unitByAiid].Regime;
              if (this.game.Data.RegimeObj[regime].UberRegime > -1)
              {
                if (simpleList3.FindNr(regime) > -1)
                {
                  int[] weight = simpleList3.Weight;
                  int[] numArray = weight;
                  int nr = simpleList3.FindNr(regime);
                  int index7 = nr;
                  int num6 = weight[nr] + 1;
                  numArray[index7] = num6;
                }
                else
                  simpleList3.Add(regime, 1);
              }
            }
          }
          int counter4 = aiFront.orgUnits.counter;
          for (int index8 = 0; index8 <= counter4; ++index8)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.orgUnits.AIid[index8]);
            if (unitByAiid > -1)
            {
              int regime = this.game.Data.UnitObj[unitByAiid].Regime;
              if (this.game.Data.RegimeObj[regime].UberRegime > -1)
              {
                if (simpleList3.FindNr(regime) > -1)
                {
                  int[] weight = simpleList3.Weight;
                  int[] numArray = weight;
                  int nr = simpleList3.FindNr(regime);
                  int index9 = nr;
                  int num7 = weight[nr] + 1;
                  numArray[index9] = num7;
                }
                else
                  simpleList3.Add(regime, 1);
              }
            }
          }
          if (simpleList3.Counter > 0)
          {
            simpleList3.ReverseSort();
            int toreg = simpleList3.Id[0];
            if (toreg > -1)
            {
              int counter5 = aiFront.units.counter;
              for (int index10 = 0; index10 <= counter5; ++index10)
              {
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index10]);
                if (unitByAiid > -1)
                {
                  int regime = this.game.Data.UnitObj[unitByAiid].Regime;
                  if (toreg != regime)
                    this.GiveAUnit(unitByAiid, toreg);
                }
              }
              int counter6 = aiFront.artUnits.counter;
              for (int index11 = 0; index11 <= counter6; ++index11)
              {
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.artUnits.AIid[index11]);
                if (unitByAiid > -1)
                {
                  int regime = this.game.Data.UnitObj[unitByAiid].Regime;
                  if (toreg != regime)
                    this.GiveAUnit(unitByAiid, toreg);
                }
              }
              int counter7 = aiFront.orgUnits.counter;
              for (int index12 = 0; index12 <= counter7; ++index12)
              {
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.orgUnits.AIid[index12]);
                if (unitByAiid > -1)
                {
                  int regime = this.game.Data.UnitObj[unitByAiid].Regime;
                  if (toreg != regime)
                    this.GiveAUnit(unitByAiid, toreg);
                }
              }
            }
          }
        }
      }
      this.WriteLog("021_uberunter");
    }

    public void GiveAUnit(int unr, int toreg)
    {
      if (!this.game.Data.UnitObj[unr].IsHQ)
      {
        int num = 0;
        if (this.game.Data.UnitObj[unr].Historical > -1)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.game.Data.UnitObj[index].Historical == this.game.Data.UnitObj[unr].Historical && this.game.Data.UnitObj[index].HQ == this.game.Data.UnitObj[unr].HQ && index != unr)
            {
              if (this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime != this.game.Data.Turn && this.game.Data.RegimeObj[toreg].UberRegime != this.game.Data.Turn)
                this.game.Data.UnitObj[index].HQ = -1;
              this.game.Data.UnitObj[index].Regime = toreg;
              this.game.Data.UnitObj[index].UnitIsGiven = true;
              ++num;
            }
          }
        }
        if (this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn)
          this.game.HandyFunctionsObj.AddMessageForOne(this.game.Data.RegimeObj[this.game.Data.Turn].Name + " has taken over command of " + this.game.Data.UnitObj[unr].Name, this.game.Data.UnitObj[unr].Regime, -1, 1);
        if (this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].UberRegime != this.game.Data.Turn && this.game.Data.RegimeObj[toreg].UberRegime != this.game.Data.Turn)
          this.game.Data.UnitObj[unr].HQ = -1;
        this.game.Data.UnitObj[unr].Regime = toreg;
        this.game.Data.UnitObj[unr].UnitIsGiven = true;
        this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.Turn, infostring: "Giving unit");
        this.game.HandyFunctionsObj.AddMessageForOne(this.game.Data.RegimeObj[this.game.Data.Turn].Name + " has given command of " + this.game.Data.UnitObj[unr].Name + " to you.", toreg, -1, 1);
      }
      else
      {
        int Number = 0;
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr1 = 0; unr1 <= unitCounter; ++unr1)
        {
          if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr1, unr))
          {
            ++Number;
            this.game.Data.UnitObj[unr1].Regime = toreg;
            this.game.Data.UnitObj[unr1].UnitIsGiven = true;
            this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y, this.game.Data.UnitObj[unr1].Map, this.game.Data.Turn, infostring: "Giving unit");
          }
        }
        if (this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn)
          this.game.HandyFunctionsObj.AddMessageForOne(this.game.Data.RegimeObj[this.game.Data.Turn].Name + " has taken over command of " + this.game.Data.UnitObj[unr].Name + " and " + Conversion.Str((object) Number) + " subordinate units..", this.game.Data.UnitObj[unr].Regime, -1, 1);
        if (this.game.Data.RegimeObj[toreg].UberRegime != this.game.Data.Turn && this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].UberRegime != this.game.Data.Turn)
          this.game.Data.UnitObj[unr].HQ = -1;
        this.game.Data.UnitObj[unr].Regime = toreg;
        this.game.Data.UnitObj[unr].UnitIsGiven = true;
        this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.Turn, infostring: "Giving unit");
        this.game.HandyFunctionsObj.AddMessageForOne(this.game.Data.RegimeObj[this.game.Data.Turn].Name + " has given command of " + this.game.Data.UnitObj[unr].Name + " and " + Conversion.Str((object) Number) + " subordinate units to you.", toreg, -1, 1);
      }
    }

    public void ExecuteFrontlines(bool doLog)
    {
      if (Information.IsNothing((object) this.masterPlan) || this.masterPlan.Counter == -1)
        return;
      this.MakeFriendlySupplyMatrix();
      this.MakeEnemySupplyMatrix();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].tempCoords = new CoordList();
      int counter1 = this.masterPlan.Counter;
      int unitByAiid1;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront = this.masterPlan.Front[index1];
        if (aiFront.units.counter > -1)
        {
          int counter2 = aiFront.units.counter;
          for (int index2 = 0; index2 <= counter2; ++index2)
          {
            unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index2]);
            if (unitByAiid1 > -1)
            {
              if (aiFront.FrontType == 12)
                this.game.Data.UnitObj[unitByAiid1].SODefendPercent = 25;
              else if (aiFront.FrontType == 1 & aiFront.Stance == 3)
              {
                this.game.Data.UnitObj[unitByAiid1].SODefendPercent = 100 - this.game.HandyFunctionsObj.GetAverageMor(unitByAiid1);
                this.game.Data.UnitObj[unitByAiid1].SODefendPercent = 25 <= this.game.Data.UnitObj[unitByAiid1].SODefendPercent ? (62 <= this.game.Data.UnitObj[unitByAiid1].SODefendPercent ? (200 <= this.game.Data.UnitObj[unitByAiid1].SODefendPercent ? 50 : 75) : 50) : 25;
              }
              else
                this.game.Data.UnitObj[unitByAiid1].SODefendPercent = 50;
            }
          }
        }
      }
      int counter3 = this.masterPlan.Counter;
      for (int index3 = 0; index3 <= counter3; ++index3)
      {
        int num1 = 0;
        int num2 = 0;
        this.masterPlan.Front[index3].temp1 = 0;
        if (this.masterPlan.Front[index3].FrontType == 1)
        {
          int counter4 = this.masterPlan.Front[index3].units.counter;
          for (int index4 = 0; index4 <= counter4; ++index4)
          {
            unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(this.masterPlan.Front[index3].units.AIid[index4]);
            if (unitByAiid1 > -1)
            {
              int x = this.game.Data.UnitObj[unitByAiid1].X;
              int y = this.game.Data.UnitObj[unitByAiid1].Y;
              if (this.frontMatrix.Value[x, y] > 0 && this.frontMatrix.Value[x, y] == this.masterPlan.Front[index3].FrontID)
              {
                Coordinate averageFrontCoordinate = this.masterPlan.Front[index3].GetAverageFrontCoordinate();
                if (averageFrontCoordinate.onmap)
                {
                  int num3 = this.game.HandyFunctionsObj.Distance(x, y, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0);
                  num1 += num3 * 10;
                  ++num2;
                }
              }
            }
          }
        }
        else
        {
          num1 = 9999;
          num2 = 1;
        }
        if (num2 > 0)
        {
          int num4 = (int) Math.Round((double) num1 / (double) num2);
          this.masterPlan.Front[index3].temp1 = num4;
        }
      }
      bool flag1 = true;
      while (flag1)
      {
        flag1 = false;
        int counter5 = this.masterPlan.Counter;
        for (int index5 = 0; index5 <= counter5; ++index5)
        {
          if (this.masterPlan.Front[index5].FrontType == 1)
          {
            int num = index5 + 1;
            int counter6 = this.masterPlan.Counter;
            for (int index6 = num; index6 <= counter6; ++index6)
            {
              if (this.masterPlan.Front[index6].FrontType == 1 && this.masterPlan.Front[index5].temp1 < this.masterPlan.Front[index6].temp1)
              {
                AIFront aiFront = this.masterPlan.Front[index5];
                this.masterPlan.Front[index5] = this.masterPlan.Front[index6];
                this.masterPlan.Front[index6] = aiFront;
                flag1 = true;
              }
            }
          }
        }
      }
      this.frontList = this.masterPlan.Clone();
      this.LogFronts("2000_fronts_afterReshuffleOrder");
      int counter7 = this.masterPlan.Counter;
      for (int index = 0; index <= counter7; ++index)
      {
        AIFront aiFront = this.masterPlan.Front[index];
        if (aiFront.FrontType == 1)
        {
          for (int counter8 = aiFront.units.counter; counter8 >= 0; counter8 += -1)
          {
            unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[counter8]);
            if (unitByAiid1 > -1 && this.game.Data.UnitObj[unitByAiid1].TempCategory == 2 | this.game.Data.UnitObj[unitByAiid1].TempCategory == 5)
            {
              aiFront.artUnits.add(this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[counter8]), this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[counter8])].AIid);
              aiFront.units.removeUnr(unitByAiid1);
            }
          }
        }
      }
      int counter9 = this.masterPlan.Counter;
      for (int index7 = 0; index7 <= counter9; ++index7)
      {
        AIFront aiFront1 = this.masterPlan.Front[index7];
        if (aiFront1.FrontType == 8 | aiFront1.FrontType == 9 && aiFront1.units.counter > -1)
        {
          int counter10 = this.masterPlan.Counter;
          for (int index8 = 0; index8 <= counter10; ++index8)
          {
            AIFront aiFront2 = this.masterPlan.Front[index8];
            if (index7 != index8 & aiFront1.targetX == aiFront2.targetX & aiFront1.targetY == aiFront2.targetY & aiFront1.targetX > -1)
            {
              AIFront aiFront3 = this.masterPlan.Front[index8];
              if (aiFront3.FrontType == 8 | aiFront3.FrontType == 9 && aiFront3.units.counter > -1)
              {
                aiFront1.AddUnit(this.game.HandyFunctionsObj.GetUnitByAIid(aiFront3.units.AIid[0]));
                aiFront3.RemoveUnitAIid(aiFront3.units.AIid[0]);
              }
            }
          }
        }
      }
      int counter11 = this.masterPlan.Counter;
      AIFront front;
      for (int index = 0; index <= counter11; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.FrontType == 8 | front.FrontType == 9 && front.units.counter > -1)
        {
          this.game.EditObj.TempAIString = "Executing Navy Units for Front " + front.FrontID.ToString();
          this.ExecuteNavyFront(ref front, doLog);
          this.game.EditObj.AIProgressNow = 10 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
        }
      }
      int counter12 = this.masterPlan.Counter;
      for (int index = 0; index <= counter12; ++index)
      {
        front = this.masterPlan.Front[index];
        if (!(front.FrontType == 5 | front.FrontType == 4) && front.orgUnits.counter > -1)
        {
          this.game.EditObj.TempAIString = "Executing Organisational Units for Front " + front.FrontID.ToString();
          this.ExecuteOrgFront(ref front, doLog);
          this.game.EditObj.AIProgressNow = 15 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
        }
      }
      int counter13 = this.masterPlan.Counter;
      for (int index = 0; index <= counter13; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 | front.artUnits.counter > -1 && (front.FrontType == 5 | front.FrontType == 4) & front.TargetFrontID > 0)
        {
          this.game.EditObj.TempAIString = "Moving for Air Fronts " + front.FrontID.ToString();
          this.ExecuteAirFront(ref front, doLog);
          this.game.EditObj.AIProgressNow = 20 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
        }
      }
      int counter14 = this.masterPlan.Counter;
      for (int index = 0; index <= counter14; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 && front.FrontType == 6 & front.coordCount > -1)
        {
          this.game.EditObj.TempAIString = "Moving for Engineer Front " + front.FrontID.ToString();
          this.ExecuteEngineerFront(ref front, doLog);
          this.game.EditObj.AIProgressNow = 25 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
        }
      }
      int counter15 = this.masterPlan.Counter;
      for (int index9 = 0; index9 <= counter15; ++index9)
      {
        front = this.masterPlan.Front[index9];
        if (front.FrontType == 1 && (double) front.UnitCountRatio < 0.1)
        {
          int counter16 = front.artUnits.counter;
          for (int index10 = 0; index10 <= counter16; ++index10)
            front.units.add(this.game.HandyFunctionsObj.GetUnitByAIid(front.artUnits.AIid[index10]), this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetUnitByAIid(front.artUnits.AIid[index10])].AIid);
          front.artUnits = new AIUnitList();
          int counter17 = front.orgUnits.counter;
          for (int index11 = 0; index11 <= counter17; ++index11)
            front.units.add(this.game.HandyFunctionsObj.GetUnitByAIid(front.orgUnits.AIid[index11]), this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetUnitByAIid(front.orgUnits.AIid[index11])].AIid);
          front.orgUnits = new AIUnitList();
        }
      }
      if (this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES & (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus < 100 | this.CustomCalls.CustomIsMinor()))
      {
        int counter18 = this.masterPlan.Counter;
        for (int index = 0; index <= counter18; ++index)
        {
          front = this.masterPlan.Front[index];
          if (front.units.counter > -1)
          {
            if (front.FrontType == 1 & front.Stance == 2)
            {
              this.game.EditObj.TempAIString = "Executing Protection Front " + front.FrontID.ToString();
              this.ExecuteProtection(ref front, doLog);
            }
            else if (front.FrontType == 1 & front.Stance == 3 & this.game.Data.Product >= 6)
            {
              this.game.EditObj.TempAIString = "Executing Protection Front " + front.FrontID.ToString();
              this.ExecuteProtection(ref front, doLog);
            }
            else if (front.FrontType == 1 & this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT & front.Stance != 3)
            {
              this.game.EditObj.TempAIString = "Executing Protection Front (retreat) " + front.FrontID.ToString();
              this.ExecuteProtection(ref front, doLog);
            }
            else if (front.FrontType == 12 & this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT)
            {
              this.game.EditObj.TempAIString = "Executing Protection Front (escape) " + front.FrontID.ToString();
              this.ExecuteProtection(ref front, doLog);
            }
          }
        }
      }
      int counter19 = this.masterPlan.Counter;
      for (int index = 0; index <= counter19; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 | front.artUnits.counter > -1 && (front.FrontType == 2 | front.FrontType == 3) & front.TargetFrontID > 0)
        {
          this.game.EditObj.TempAIString = "Executing Reserve Front " + front.FrontID.ToString();
          this.ExecuteReserveFront(ref front, doLog);
          this.game.EditObj.AIProgressNow = 30 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
        }
      }
      int counter20 = this.masterPlan.Counter;
      for (int index12 = 0; index12 <= counter20; ++index12)
      {
        front = this.masterPlan.Front[index12];
        if (front.units.counter > -1 && front.FrontType == 2 & front.TargetFrontID > 0)
        {
          int counter21 = front.units.counter;
          for (int index13 = 0; index13 <= counter21; ++index13)
          {
            unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index13]);
            if (unitByAiid1 > -1)
            {
              int x = this.game.Data.UnitObj[unitByAiid1].X;
              int y = this.game.Data.UnitObj[unitByAiid1].Y;
              bool flag2 = false;
              if (this.frontMatrix.Value[x, y] == front.TargetFrontID)
                flag2 = true;
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, tfacing);
                if (coordinate.onmap && this.frontMatrix.Value[coordinate.x, coordinate.y] == front.TargetFrontID)
                  flag2 = true;
                ++tfacing;
              }
              while (tfacing <= 6);
              if (flag2)
              {
                this.masterPlan.FindFront(front.TargetFrontID).units.add(unitByAiid1, front.units.AIid[index13]);
                front.units.removeAiId(front.units.AIid[index13]);
                this.game.Data.UnitObj[unitByAiid1].DidMove = false;
                this.game.Data.UnitObj[unitByAiid1].DidAttack = false;
                this.game.Data.UnitObj[unitByAiid1].AIGroup = front.TargetFrontID;
              }
            }
          }
        }
        if (front.artUnits.counter > -1 && front.FrontType == 3 & front.TargetFrontID > 0)
        {
          int counter22 = front.artUnits.counter;
          for (int index14 = 0; index14 <= counter22; ++index14)
          {
            unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(front.artUnits.AIid[index14]);
            if (unitByAiid1 > -1 && this.frontMatrix.Value[this.game.Data.UnitObj[unitByAiid1].X, this.game.Data.UnitObj[unitByAiid1].Y] == front.TargetFrontID)
            {
              this.masterPlan.FindFront(front.TargetFrontID).artUnits.add(unitByAiid1, front.artUnits.AIid[index14]);
              front.artUnits.removeAiId(front.artUnits.AIid[index14]);
              this.game.Data.UnitObj[unitByAiid1].DidMove = false;
              this.game.Data.UnitObj[unitByAiid1].DidAttack = false;
              this.game.Data.UnitObj[unitByAiid1].AIGroup = front.TargetFrontID;
            }
          }
        }
      }
      int counter23 = this.masterPlan.Counter;
      for (int index = 0; index <= counter23; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 && front.FrontType == 12)
        {
          this.game.EditObj.TempAIString = "Executing Escape Front " + front.FrontID.ToString();
          this.ExecuteEscapeFront(ref front, doLog);
        }
        this.game.EditObj.AIProgressNow = 35 + (int) Math.Round(3.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter24 = this.masterPlan.Counter;
      for (int index15 = 0; index15 <= counter24; ++index15)
      {
        front = this.masterPlan.Front[index15];
        if (front.FrontType == 1 && front.Stance == 1 | front.Stance == 4)
        {
          int counter25 = front.artUnits.counter;
          for (int index16 = 0; index16 <= counter25; ++index16)
            front.units.add(this.game.HandyFunctionsObj.GetUnitByAIid(front.artUnits.AIid[index16]), this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetUnitByAIid(front.artUnits.AIid[index16])].AIid);
          front.artUnits = new AIUnitList();
          if (front.units.counter > -1)
          {
            this.game.EditObj.TempAIString = "Executing Retreat Front " + front.FrontID.ToString();
            this.ExecuteRetreatFront(ref front, doLog);
            this.game.EditObj.AIProgressNow = 38 + (int) Math.Round(3.0 * ((double) index15 / (double) Math.Max(1, this.masterPlan.Counter)));
          }
          if (front.units.counter > -1)
          {
            int counter26 = front.units.counter;
            for (int index17 = 0; index17 <= counter26; ++index17)
            {
              unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index17]);
              if (unitByAiid1 > -1)
              {
                int x = this.game.Data.UnitObj[unitByAiid1].X;
                int y = this.game.Data.UnitObj[unitByAiid1].Y;
                if (this.frontMatrix.Value[x, y] != front.FrontID & this.frontMatrix.Value[x, y] > 0)
                {
                  this.masterPlan.FindFront(this.frontMatrix.Value[x, y]).units.add(unitByAiid1, front.units.AIid[index17]);
                  front.units.removeAiId(front.units.AIid[index17]);
                  this.game.Data.UnitObj[unitByAiid1].DidMove = false;
                  this.game.Data.UnitObj[unitByAiid1].DidAttack = false;
                  this.game.Data.UnitObj[unitByAiid1].AIGroup = this.frontMatrix.Value[x, y];
                }
              }
            }
          }
        }
      }
      this.frontList = this.masterPlan.Clone();
      this.LogFronts("2000_fronts_afterReserveAndRetreatMove");
      if (this.game.Data.Turn == 6)
        ;
      int counter27 = this.masterPlan.Counter;
      for (int index = 0; index <= counter27; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 && front.FrontType == 1 & front.TopOperation && !(front.Stance == 1 | front.Stance == 4) && this.AllowFrontExecution(front))
        {
          this.game.EditObj.TempAIString = "Executing Front " + front.FrontID.ToString();
          this.ExecuteFront(ref front, doLog);
        }
        if (front.artUnits.counter > -1 && front.FrontType == 1 & front.TopOperation && !(front.Stance == 1 | front.Stance == 4) && this.AllowFrontExecution(front))
        {
          this.game.EditObj.TempAIString = "Executing Front For Art Units " + front.FrontID.ToString();
          this.ExecuteFrontArtUnits(ref front, doLog);
          this.ExecuteFrontFlakUnits(ref front, doLog);
        }
        this.game.EditObj.AIProgressNow = 40 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter28 = this.masterPlan.Counter;
      for (int index = 0; index <= counter28; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 && (front.FrontType == 1 | front.FrontType == 11) & !front.TopOperation && !(front.Stance == 1 | front.Stance == 4) && this.AllowFrontExecution(front))
        {
          this.game.EditObj.TempAIString = "Executing Front " + front.FrontID.ToString();
          this.ExecuteFront(ref front, doLog);
        }
        if (front.artUnits.counter > -1 && front.FrontType == 1 & !front.TopOperation && !(front.Stance == 1 | front.Stance == 4) && this.AllowFrontExecution(front))
        {
          this.game.EditObj.TempAIString = "Executing Front For Art Units " + front.FrontID.ToString();
          this.ExecuteFrontArtUnits(ref front, doLog);
          this.ExecuteFrontFlakUnits(ref front, doLog);
        }
        this.game.EditObj.AIProgressNow = 40 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter29 = this.masterPlan.Counter;
      for (int index = 0; index <= counter29; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.FrontType == 1 && !(front.Stance == 4 & front.Stance != 1) && front.units.counter > -1)
        {
          this.game.EditObj.TempAIString = "Executing Front II " + front.FrontID.ToString();
          this.ExecuteFront2(ref front, doLog);
        }
        this.game.EditObj.AIProgressNow = 55 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter30 = this.masterPlan.Counter;
      for (int index = 0; index <= counter30; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.FrontType == 10 && front.Stance != 4 && front.units.counter > -1)
        {
          this.game.EditObj.TempAIString = "Executing Strategic Front " + front.FrontID.ToString();
          this.ExecuteStrategicFront(ref front, doLog);
        }
        this.game.EditObj.AIProgressNow = 60 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter31 = this.masterPlan.Counter;
      for (int index18 = 0; index18 <= counter31; ++index18)
      {
        front = this.masterPlan.Front[index18];
        if (front.FrontType == 13 && !(front.Stance == 1 | front.Stance == 4))
        {
          if (front.TargetFrontID > 0)
          {
            this.game.EditObj.TempAIString = "Executing Reserve Front " + front.FrontID.ToString();
            this.ExecuteReserveFront(ref front, doLog);
            this.game.EditObj.AIProgressNow = 30 + (int) Math.Round(5.0 * ((double) index18 / (double) Math.Max(1, this.masterPlan.Counter)));
          }
          bool flag3 = false;
          int counter32 = front.units.counter;
          for (int index19 = 0; index19 <= counter32; ++index19)
          {
            unitByAiid1 = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index19]);
            if (unitByAiid1 > -1)
            {
              int x = this.game.Data.UnitObj[unitByAiid1].X;
              int y = this.game.Data.UnitObj[unitByAiid1].Y;
              if (this.frontMatrix.Value[x, y] == front.TargetFrontID)
                flag3 = true;
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, tfacing);
                if (coordinate.onmap && this.frontMatrix.Value[coordinate.x, coordinate.y] == front.TargetFrontID)
                  flag3 = true;
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
          if (flag3)
          {
            this.game.Data.UnitObj[unitByAiid1].DidMove = false;
            this.game.Data.UnitObj[unitByAiid1].DidAttack = false;
            this.game.Data.UnitObj[unitByAiid1].AIGroup = front.TargetFrontID;
            this.game.EditObj.TempAIString = "Executing Flak Front " + front.FrontID.ToString();
            this.ExecuteFront(ref front, doLog);
          }
        }
        this.game.EditObj.AIProgressNow = 61 + (int) Math.Round(5.0 * ((double) index18 / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter33 = this.masterPlan.Counter;
      for (int index = 0; index <= counter33; ++index)
      {
        front = this.masterPlan.Front[index];
        if (front.units.counter > -1 | front.artUnits.counter > -1 && front.FrontType == 7 & front.TargetFrontID > 0)
        {
          this.game.EditObj.TempAIString = "Moving for Air Transport Fronts " + front.FrontID.ToString();
          this.ExecuteAirTransportFront(ref front, doLog);
        }
        this.game.EditObj.AIProgressNow = 62 + (int) Math.Round(5.0 * ((double) index / (double) Math.Max(1, this.masterPlan.Counter)));
      }
      int counter34 = this.masterPlan.Counter;
      for (int index20 = 0; index20 <= counter34; ++index20)
      {
        front = this.masterPlan.Front[index20];
        if (front.units.counter > -1)
        {
          int counter35 = front.units.counter;
          for (int index21 = 0; index21 <= counter35; ++index21)
          {
            int unitByAiid2 = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index21]);
            if (unitByAiid2 > -1)
            {
              int x = this.game.Data.UnitObj[unitByAiid2].X;
              int y = this.game.Data.UnitObj[unitByAiid2].Y;
              this.game.Data.UnitObj[unitByAiid2].SODefendPercent = x <= -1 ? 50 : (!(front.FrontType == 1 & front.Stance == 2 & this.game.Data.MapObj[0].HexObj[x, y].Location > -1) ? (!(front.FrontType == 1 & front.Stance == 2 & this.VAR_MATRIX_RETREAT.Value[x, y] <= 25) ? (!(front.FrontType == 1 & front.Stance == 2 & this.VAR_MATRIX_RETREAT.Value[x, y] >= 200) ? 50 : 75) : 25) : 25);
            }
          }
        }
      }
      this.game.EditObj.TargetX = -1;
      this.game.EditObj.TargetY = -1;
    }

    public bool AllowFrontExecution(AIFront front)
    {
      bool flag = false;
      if (front.DefensiveZone > 0)
        return true;
      int mapWidth = this.map.MapWidth;
      for (int cx = 0; cx <= mapWidth; ++cx)
      {
        int mapHeight = this.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.frontMatrix.Value[cx, cy] == front.FrontID)
          {
            int tfacing = 1;
            do
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.GetRegime(this.map.HexObj[coordinate.x, coordinate.y].Regime) != this.GetGameDataTurn() && this.map.HexObj[coordinate.x, coordinate.y].Regime != -1)
                flag = true;
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      return flag;
    }

    public void MakeEnemySupplyMatrix()
    {
      DC2AIClass tai1 = this;
      AIMatrix ownerMatrix = new AIMatrix(ref tai1);
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          ownerMatrix.Value[index1, index2] = this.GetRegime(this.map.HexObj[index1, index2].Regime) != this.GetGameDataTurn() ? (this.map.HexObj[index1, index2].Regime != -1 ? 2 : 0) : 1;
      }
      DC2AIClass tai2 = this;
      this.enemySupplyMatrix = new AIMatrix(ref tai2);
      DC2AIClass tai3 = this;
      this.enemySupplyMatrixCameFrom = new AICoordinateMatrix(ref tai3);
      this.enemySupplyMatrix.SetAllValuesTo(9999);
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int reg1 = 0; reg1 <= regimeCounter; ++reg1)
      {
        if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(reg1, this.game.Data.Turn))
        {
          int index3 = 0;
          do
          {
            if (this.VAR_SUPPLY_ACTIVE[reg1, index3])
            {
              int index4 = this.VAR_SUPPLY_X[reg1, index3];
              int index5 = this.VAR_SUPPLY_Y[reg1, index3];
              if (this.GetRegime(this.game.Data.MapObj[0].HexObj[index4, index5].Regime) != this.GetGameDataTurn())
                this.enemySupplyMatrix.Value[index4, index5] = 0;
            }
            ++index3;
          }
          while (index3 <= 3);
        }
      }
      this.enemySupplyMatrix.ExpandAsSimplifiedSupplyMatrix(this.VAR_SUPPLY_ENEMY_MOVETYPE, ref ownerMatrix, 2, this.enemySupplyMatrixCameFrom);
    }

    public void MakeFriendlySupplyMatrix()
    {
      DC2AIClass tai1 = this;
      AIMatrix ownerMatrix = new AIMatrix(ref tai1);
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          ownerMatrix.Value[index1, index2] = this.GetRegime(this.map.HexObj[index1, index2].Regime) != this.GetGameDataTurn() ? (this.map.HexObj[index1, index2].Regime != -1 ? 2 : 0) : 1;
      }
      DC2AIClass tai2 = this;
      this.friendlySupplyMatrix = new AIMatrix(ref tai2);
      DC2AIClass tai3 = this;
      this.friendlySupplyMatrixCameFrom = new AICoordinateMatrix(ref tai3);
      this.friendlySupplyMatrix.SetAllValuesTo(9999);
      int index3 = 0;
      do
      {
        if (this.VAR_SUPPLY_ACTIVE[this.GetGameDataTurn(), index3])
        {
          int index4 = this.VAR_SUPPLY_X[this.GetGameDataTurn(), index3];
          int index5 = this.VAR_SUPPLY_Y[this.GetGameDataTurn(), index3];
          if (this.GetRegime(this.game.Data.MapObj[0].HexObj[index4, index5].Regime) == this.GetGameDataTurn())
            this.friendlySupplyMatrix.Value[index4, index5] = 0;
        }
        ++index3;
      }
      while (index3 <= 3);
      this.friendlySupplyMatrix.ExpandAsSimplifiedSupplyMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1, this.friendlySupplyMatrixCameFrom);
    }

    public void ExecuteReserveFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Reserve Front #" + front.FrontID.ToString();
      if (front.FrontID == 119 | front.FrontID == 220)
        s = s;
      AITheater theaterUse = new AITheater(this, front, this.masterPlan);
      theaterUse.InitializeReserve();
      theaterUse.SetReserveMove();
      bool flag;
      if (theaterUse.MoveList.Counter > -1)
        flag = this.ExecuteMoveList(ref theaterUse, ref s);
      if (!flag)
        s += "\r\nNO MOVE MADE. ";
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("reserve_front_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteAirFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Air Front #" + front.FrontID.ToString();
      AITheater theaterUse = new AITheater(this, front, this.masterPlan);
      theaterUse.InitializeAir();
      theaterUse.SetAirMove();
      bool flag;
      if (theaterUse.MoveList.Counter > -1)
        flag = this.ExecuteMoveList(ref theaterUse, ref s);
      if (!flag)
        s += "\r\nNO MOVE MADE. ";
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("air_front_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteAirTransportFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Air Transport Front #" + front.FrontID.ToString();
      AITheater theaterUse = new AITheater(this, front, this.masterPlan);
      theaterUse.InitializeAirTransport();
      theaterUse.SetAirTransportMove();
      bool flag;
      if (theaterUse.MoveList.Counter > -1)
        flag = this.ExecuteMoveList(ref theaterUse, ref s);
      if (!flag)
        s += "\r\nNO MOVE MADE. ";
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("airTrans_front_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteEngineerFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Engineer Front #" + front.FrontID.ToString();
      AITheater theaterUse = new AITheater(this, front, this.masterPlan);
      theaterUse.InitializeEngineer();
      theaterUse.SetEngineerMove();
      bool flag;
      if (theaterUse.MoveList.Counter > -1)
        flag = this.ExecuteMoveList(ref theaterUse, ref s);
      if (!flag)
        s += "\r\nNO MOVE MADE. ";
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("engineer_front_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteOrgFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Org Front #" + front.FrontID.ToString();
      AITheater theaterUse = new AITheater(this, front, this.masterPlan);
      theaterUse.InitializeOrg();
      theaterUse.SetOrgMove();
      bool flag;
      if (theaterUse.MoveList.Counter > -1)
        flag = this.ExecuteMoveList(ref theaterUse, ref s);
      if (!flag)
        s += "\r\nNO MOVE MADE. ";
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("org_front_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void SpecialCaseAddExtraOutsideFrontUnits(
      ref AIFront front,
      ref string s,
      ref AIMoveList moveList,
      ref AITheater theater,
      int attackX,
      int attackY)
    {
      if (attackX == -1 | attackY == -1 || this.game.Data.MapObj[0].HexObj[attackX, attackY].UnitCounter == -1)
        return;
      int tfacing = 1;
      do
      {
        Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(attackX, attackY, 0, tfacing);
        if (coordinate.onmap)
        {
          int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            int unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index];
            if (this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn)
            {
              AIFront front1 = this.frontList.FindFront(this.game.Data.UnitObj[unit].AIGroup);
              if (!Information.IsNothing((object) front1) && front1.FrontID != front.FrontID && !(this.game.Data.UnitObj[unit].TempCategory == 5 | this.game.Data.UnitObj[unit].TempCategory == 2) && this.game.HandyFunctionsObj.GetLowestAp(unit) >= this.game.HandyFunctionsObj.MoveApCostPreview(unit, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, 0, attackX, attackY, 0, true).x)
              {
                s = s + "***Special Case: Adding unit " + this.game.Data.UnitObj[unit].Name + " of FRONT " + front1.FrontID.ToString() + "\r\n";
                moveList.AddMove(ref new AIMove()
                {
                  UnitAIid = this.game.Data.UnitObj[unit].AIid,
                  AttackOn = {
                    x = attackX,
                    y = attackY,
                    onmap = true
                  }
                });
              }
            }
          }
        }
        ++tfacing;
      }
      while (tfacing <= 6);
    }

    public void SpecialCaseAddExtraOutsideFrontUnitsIfGoodFacing(
      ref AIFront front,
      ref string s,
      ref AIMoveList moveList,
      ref AITheater theater,
      int attackX,
      int attackY)
    {
      if (attackX == -1 | attackY == -1 || this.game.Data.MapObj[0].HexObj[attackX, attackY].UnitCounter == -1)
        return;
      bool[] flagArray = new bool[8];
      int counter = moveList.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        if (moveList.Move[index1].AttackOn.onmap)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(moveList.Move[index1].UnitAIid);
          int x = this.game.Data.UnitObj[unitByAiid].X;
          int y = this.game.Data.UnitObj[unitByAiid].Y;
          int num = index1;
          for (int index2 = 0; index2 <= num; ++index2)
          {
            if (moveList.Move[index1].UnitAIid == moveList.Move[index2].UnitAIid && moveList.Move[index2].MoveTo.onmap)
            {
              x = moveList.Move[index2].MoveTo.x;
              y = moveList.Move[index2].MoveTo.y;
            }
          }
          if (x > -1)
          {
            int index3 = this.game.HandyFunctionsObj.HexFacing(x, y, 0, attackX, attackY, 0);
            if (index3 > 0 & index3 <= 6)
              flagArray[index3] = true;
          }
        }
      }
      int tfacing = 1;
      do
      {
        if (!flagArray[tfacing])
        {
          Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(attackX, attackY, 0, tfacing);
          if (coordinate.onmap)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
            for (int index = 0; index <= unitCounter; ++index)
            {
              int unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index];
              if (this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn)
              {
                AIFront front1 = this.frontList.FindFront(this.game.Data.UnitObj[unit].AIGroup);
                if (!Information.IsNothing((object) front1) && front1.FrontID != front.FrontID & !(this.game.Data.Product >= 5 & front1.FrontType == 10) && !(this.game.Data.UnitObj[unit].TempCategory == 5 | this.game.Data.UnitObj[unit].TempCategory == 2) && this.game.HandyFunctionsObj.GetLowestAp(unit) >= this.game.HandyFunctionsObj.MoveApCostPreview(unit, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, 0, attackX, attackY, 0, true).x)
                {
                  s = s + "***Special Case: Adding unit " + this.game.Data.UnitObj[unit].Name + " of FRONT " + front1.FrontID.ToString() + "\r\n";
                  moveList.AddMove(ref new AIMove()
                  {
                    UnitAIid = this.game.Data.UnitObj[unit].AIid,
                    AttackOn = {
                      x = attackX,
                      y = attackY,
                      onmap = true
                    }
                  });
                  flagArray[tfacing] = true;
                  break;
                }
              }
            }
          }
        }
        ++tfacing;
      }
      while (tfacing <= 6);
    }

    public void ExecuteEscapeFront(ref AIFront front, bool doLog)
    {
      PassHexList passList = new PassHexList();
      PassHexList passHexList = new PassHexList();
      PassHexList tryPassList = new PassHexList();
      int Iteration = 0;
      this.map = this.game.Data.MapObj[0];
      string str;
      if (front.FrontID == 538)
        str = str;
      this.ClearLog();
      string s = "Moves For Escape Front #" + front.FrontID.ToString();
      PassHexList tempPassList = new PassHexList();
      bool flag = true;
      AITheater aiTheater;
      while (flag)
      {
        flag = false;
        aiTheater = new AITheater(this, front, this.masterPlan);
        if (this.game.Data.Product >= 6)
          aiTheater.Initialize(Iteration, 100);
        else
          aiTheater.Initialize(Iteration);
        int num;
        switch (num)
        {
          case 0:
            if (Iteration <= 26)
            {
              aiTheater.SetAttackMove(ref passList, ref tempPassList, ref tryPassList, 0, true);
              break;
            }
            aiTheater.SetAttackMove(ref passList, ref tempPassList, ref tryPassList, 1, true);
            break;
          case 1:
            aiTheater.SetEscapeMove();
            break;
        }
        num = num;
        if (aiTheater.MoveList.Counter > -1)
        {
          if (num == 0)
            this.SpecialCaseAddExtraOutsideFrontUnits(ref front, ref s, ref aiTheater.MoveList, ref aiTheater, aiTheater.GetRealX(aiTheater.triedX), aiTheater.triedY + aiTheater.Top);
          flag = this.ExecuteMoveList(ref aiTheater, ref s);
          passList = new PassHexList();
          tempPassList = new PassHexList();
          tryPassList = new PassHexList();
          num = num != 0 ? 0 : 1;
          ++Iteration;
        }
        else if (num == 0 & aiTheater.triedX > -1 & aiTheater.triedY > -1 & tempPassList.counter <= 10 & Iteration > 5 & Iteration < 13)
        {
          s += "\r\nNO MOVE MADE. GIVING IT ANOTHER GO WITH DIFFERENT COORDINATE ";
          tempPassList.AddCoord(aiTheater.triedX, aiTheater.triedY, 1);
          flag = true;
          ++Iteration;
        }
        else if (num == 0 & aiTheater.triedX > -1 & aiTheater.triedY > -1 & tempPassList.counter <= 10 & Iteration > 20 & Iteration < 30)
        {
          s += "\r\nNO MOVE MADE. GIVING IT ANOTHER GO WITH DIFFERENT COORDINATE ";
          tempPassList.AddCoord(aiTheater.triedX, aiTheater.triedY, 1);
          flag = true;
          ++Iteration;
        }
        else
        {
          ++Iteration;
          if (this.game.Data.Product < 6)
            flag = true;
          num = num != 0 ? 0 : 1;
          if (Iteration % 5 == 1)
          {
            passList = new PassHexList();
            tempPassList = new PassHexList();
            tryPassList = new PassHexList();
          }
        }
        if (!flag)
        {
          s += "\r\nNO MOVE MADE.";
          ++Iteration;
          if (this.game.Data.Product < 6)
            flag = true;
        }
        if ((double) Iteration > 33.0 + Math.Sqrt((double) front.units.counter))
          flag = false;
      }
      this.AddLog(s);
      str = "";
      if (doLog)
        this.WriteLog("escape_front_" + front.FrontID.ToString());
      aiTheater = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteProtection(ref AIFront front, bool doLog)
    {
      PassHexList passHexList1 = new PassHexList();
      PassHexList passHexList2 = new PassHexList();
      PassHexList passHexList3 = new PassHexList();
      this.map = this.game.Data.MapObj[0];
      int num1;
      int num2;
      if (front.FrontID > 100000)
        num2 = num1;
      if (front.Stance == 3)
        num1 = num2;
      string str;
      if (front.FrontID == 2181)
        str = str;
      this.ClearLog();
      string s = "Moves For Protection Front #" + front.FrontID.ToString();
      int num3 = 1;
      AITheater theaterUse;
      do
      {
        int mapWidth = this.map.MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.map.MapHeight;
          for (int y2 = 0; y2 <= mapHeight; ++y2)
          {
            if (this.frontMatrix.Value[index1, y2] == front.FrontID & this.GetGameDataTurn() == this.GetRegime(this.map.HexObj[index1, y2].Regime) && this.map.HexObj[index1, y2].Location > -1 && front.Stance != 3 & (this.map.HexObj[index1, y2].VP >= 5 & num3 == 1 | this.map.HexObj[index1, y2].VP > 0 & num3 == 2) | front.Stance == 3 & (this.map.HexObj[index1, y2].VP >= 30 & num3 == 1 | this.map.HexObj[index1, y2].VP > 14 & num3 == 2))
            {
              int Iteration = 0;
              bool flag1 = false;
              while (!flag1 & Iteration < 9)
              {
                SimpleList simpleList = new SimpleList();
                bool flag2 = false;
                theaterUse = new AITheater(this, front, this.masterPlan);
                ++Iteration;
                theaterUse.Initialize(Iteration, 250);
                if (theaterUse.FriendlySupply.Value[theaterUse.GetMatrixX(index1), y2 - theaterUse.Top] <= this.VAR_SUPPLY_MAXIMUM_RANGE | this.VAR_ALWAYS_PROTECT_FRONTLINE_CITIES_EVEN_IF_RETREAT)
                {
                  int counter = front.units.counter;
                  for (int tdata1 = 0; tdata1 <= counter; ++tdata1)
                  {
                    int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[tdata1]);
                    if (unitByAiid > -1)
                    {
                      int x = this.game.Data.UnitObj[unitByAiid].X;
                      int y = this.game.Data.UnitObj[unitByAiid].Y;
                      if (!this.game.Data.UnitObj[unitByAiid].TempProtector && this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(unitByAiid) | theaterUse.enemyDistance.Value[theaterUse.GetMatrixX(x), y - theaterUse.Top] > 1 | theaterUse.enemyDistance.Value[theaterUse.GetMatrixX(index1), y2 - theaterUse.Top] == 1 | theaterUse.enemyDistance.Value[theaterUse.GetMatrixX(x), y - theaterUse.Top] == 1 & !theaterUse.IsLastUnit(unitByAiid, front) && theaterUse.MoveCostMove[tdata1].Value[theaterUse.GetMatrixX(index1), y2 - theaterUse.Top] <= 250 && this.GetAIRolePercent(unitByAiid, 6) > 40)
                      {
                        if (theaterUse.MoveCostMove[tdata1].Value[theaterUse.GetMatrixX(index1), y2 - theaterUse.Top] <= this.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                          flag2 = true;
                        int tweight = this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.game.Data.UnitObj[unitByAiid].Historical) * 50000 + this.game.HandyFunctionsObj.Distance(x, y, 0, index1, y2, 0) * 1000 + this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitByAiid].Historical].ID;
                        simpleList.Add(unitByAiid, tweight, tdata1);
                      }
                    }
                  }
                }
                if (simpleList.Counter > -1)
                {
                  simpleList.Sort();
                  int counter = simpleList.Counter;
                  for (int index2 = 0; index2 <= counter; ++index2)
                  {
                    int unr = simpleList.Id[index2];
                    if (this.game.Data.UnitObj[unr].X == index1 & this.game.Data.UnitObj[unr].Y == y2)
                    {
                      flag1 = true;
                      this.game.Data.UnitObj[unr].TempProtector = true;
                      break;
                    }
                    theaterUse.SetProtectorMove(unr, simpleList.Data1[0], theaterUse.GetMatrixX(index1), y2 - theaterUse.Top);
                    flag1 = false;
                    if (theaterUse.MoveList.Counter > -1)
                    {
                      flag1 = this.ExecuteMoveList(ref theaterUse, ref s);
                      if (flag1)
                      {
                        this.game.Data.UnitObj[unr].TempProtector = true;
                        break;
                      }
                    }
                  }
                }
              }
            }
          }
        }
        ++num3;
      }
      while (num3 <= 2);
      this.AddLog(s);
      str = "";
      if (doLog)
        this.WriteLog("front_protection_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteNavyFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Navy Front #" + front.FrontID.ToString();
      bool flag = true;
      AITheater theaterUse;
      while (flag)
      {
        flag = false;
        theaterUse = new AITheater(this, front, this.masterPlan);
        theaterUse.InitializeNavy();
        theaterUse.SetNavyMove();
        if (theaterUse.MoveList.Counter > -1)
          flag = this.ExecuteMoveList(ref theaterUse, ref s);
      }
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("navalfront_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteStrategicFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Strategic Front #" + front.FrontID.ToString();
      if (front.units.counter > -1 && this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[0]) > -1 && this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[0])].X == 0)
        s = s;
      AITheater theaterUse = new AITheater(this, front, this.masterPlan);
      theaterUse.InitializeStrategic();
      theaterUse.SetStrategicMove();
      bool flag;
      if (theaterUse.MoveList.Counter > -1)
        flag = this.ExecuteMoveList(ref theaterUse, ref s);
      if (!flag)
        s += "\r\nNO MOVE MADE. ";
      this.AddLog(s);
      s = "";
      if (doLog)
        this.WriteLog("strategic_front_" + front.FrontID.ToString());
      theaterUse = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteFront2(ref AIFront front, bool doLog)
    {
      if (front.DefensiveZone > 0)
        return;
      this.map = this.game.Data.MapObj[0];
      if (front.FrontID == 2181)
      {
        string str1 = str1;
      }
      this.ClearLog();
      string s = "Moves For Front II #" + front.FrontID.ToString();
      if (front.FrontID == 3729)
        s = s;
      PassHexList passHexList1 = new PassHexList();
      PassHexList passHexList2 = new PassHexList();
      PassHexList passHexList3 = new PassHexList();
      int num1 = 5 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 30.0) + (int) Math.Round((double) front.units.counter * 1.5);
      int num2 = 2 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 80.0);
      int num3 = 10 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 30.0) + (int) Math.Round(Math.Sqrt((double) front.units.counter));
      int num4 = 0;
      if (!this.CustomCalls.CustomDoStrategicIterations())
        num3 = (int) Math.Round((double) num3 / 4.0) + 1;
      if (!this.CustomCalls.CustomDoStrategicIterations())
        num2 = 1;
      int counter1 = front.units.counter;
      int index1;
      for (index1 = 0; index1 <= counter1; ++index1)
      {
        int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index1]);
        if (unitByAiid > -1)
          this.game.Data.UnitObj[unitByAiid].TempAIForbidsMove = false;
      }
      int num5 = num1;
      for (int Iteration = 1; Iteration <= num5; ++Iteration)
      {
        s = s + "\r\n\r\nIteration #" + Iteration.ToString();
        AITheater aiTheater1 = new AITheater(this, front, this.masterPlan);
        aiTheater1.Initialize(Iteration, 250);
        aiTheater1.SetScore(doLog, AttackX: -2);
        s = s + "\r\nScore for NoMove = " + aiTheater1.Score.ToString();
        if (front.FrontID == 2592)
          index1 = index1;
        int num6 = -9999999;
        int num7 = 0;
        AITheater aiTheater2 = aiTheater1;
        PassHexList passHexList4 = new PassHexList();
        int num8 = num3;
        for (int index2 = 1; index2 <= num8; ++index2)
        {
          AITheater aiTheater3 = aiTheater1.Clone();
          AITheater aiTheater4 = aiTheater3;
          ref PassHexList local1 = ref passHexList1;
          ref PassHexList local2 = ref passHexList2;
          ref PassHexList local3 = ref passHexList4;
          int stimulateDefend = num7;
          SimpleList simpleList = (SimpleList) null;
          ref SimpleList local4 = ref simpleList;
          aiTheater4.SetDefendMove(ref local1, ref local2, ref local3, stimulateDefend, true, ref local4);
          aiTheater3.ImplementMoveList();
          aiTheater3.SetScore(false);
          s += "\r\n";
          if (aiTheater3.Score > num6)
          {
            num6 = aiTheater3.Score;
            aiTheater2 = aiTheater3;
          }
          int num9;
          int num10;
          if (aiTheater3.triedX > -1)
          {
            if (aiTheater3.Score == 0)
            {
              string[] strArray1 = new string[6]
              {
                s,
                "too (",
                null,
                null,
                null,
                null
              };
              string[] strArray2 = strArray1;
              num9 = aiTheater3.GetRealX(aiTheater3.triedX);
              string str2 = num9.ToString();
              strArray2[2] = str2;
              strArray1[3] = ",";
              string[] strArray3 = strArray1;
              num10 = aiTheater3.triedY + aiTheater3.Top;
              string str3 = num10.ToString();
              strArray3[4] = str3;
              strArray1[5] = ") could not find units enough.";
              s = string.Concat(strArray1);
              num7 = 0;
              s = s + "new stimulate defend= " + num7.ToString();
              passHexList4.AddCoord(aiTheater3.triedX, aiTheater3.triedY, 2);
              passHexList2.AddCoord(aiTheater3.triedX, aiTheater3.triedY, 2);
            }
            else
            {
              string[] strArray4 = new string[7];
              strArray4[0] = s;
              strArray4[1] = "too (";
              string[] strArray5 = strArray4;
              num10 = aiTheater3.GetRealX(aiTheater3.triedX);
              string str4 = num10.ToString();
              strArray5[2] = str4;
              strArray4[3] = ",";
              string[] strArray6 = strArray4;
              num9 = aiTheater3.triedY + aiTheater3.Top;
              string str5 = num9.ToString();
              strArray6[4] = str5;
              strArray4[5] = ") with ";
              strArray4[6] = aiTheater3.MoveList.Counter.ToString();
              s = string.Concat(strArray4);
              passHexList4.AddCoord(aiTheater3.triedX, aiTheater3.triedY, 2);
            }
          }
          s = s + " => try sore for defend = " + aiTheater3.Score.ToString();
        }
        AITheater Expression = aiTheater2;
        if (Information.IsNothing((object) Expression))
          Expression = aiTheater1.Clone();
        s = s + "\r\nScore for Defend = " + Expression.Score.ToString();
        int num11 = -99999999;
        string str6;
        AITheater theaterUse;
        if (Expression.Score > num11)
        {
          str6 = "\r\nDefend has better score.";
          num11 = Expression.Score;
          theaterUse = Expression;
        }
        else if (Expression.MoveList.Counter > -1 && Expression.MoveList.Move[0].MoveTo.onmap)
        {
          int matrixX = Expression.GetMatrixX(Expression.MoveList.Move[0].MoveTo.x);
          int y = Expression.MoveList.Move[0].MoveTo.y - Expression.Top;
          passHexList2.AddCoord(matrixX, y, 2);
        }
        if (aiTheater1.Score > num11)
        {
          str6 = "\r\nNoMove has better score.";
          int score = aiTheater1.Score;
          theaterUse = aiTheater1;
        }
        s += str6;
        bool flag1 = false;
        if (!Information.IsNothing((object) theaterUse) && theaterUse.MoveList.Counter > -1)
        {
          passHexList2 = new PassHexList();
          flag1 = this.ExecuteMoveList(ref theaterUse, ref s, 250);
        }
        if (!flag1)
        {
          if (!Information.IsNothing((object) theaterUse))
          {
            bool flag2 = true;
            if (theaterUse.MoveList.Counter > -1)
            {
              int counter2 = theaterUse.MoveList.Counter;
              for (index1 = 0; index1 <= counter2; ++index1)
              {
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(theaterUse.MoveList.Move[index1].UnitAIid);
                if (unitByAiid > -1 && this.game.Data.UnitObj[unitByAiid].TempAIForbidsMove)
                  flag2 = false;
              }
            }
            if (flag2)
              ++num4;
            s = s + "\r\nNO MOVE MADE. PassListCounter=" + passHexList1.counter.ToString() + ", NoMoveCounter=" + num4.ToString();
          }
          else
            ++num4;
        }
        if (num4 > num2)
          break;
      }
      this.AddLog(s);
      s = "";
      Application.DoEvents();
      if (!doLog)
        return;
      this.WriteLog("front_II_" + front.FrontID.ToString());
    }

    public void ExecuteRetreatFront(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string str1 = "Moves For Retreating Front #" + front.FrontID.ToString();
      PassHexList passList1 = new PassHexList();
      PassHexList tempPassList1 = new PassHexList();
      PassHexList passHexList = new PassHexList();
      int num1 = 18 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 7.0) + front.units.counter * 6;
      int num2 = 4 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 80.0);
      int num3 = 10 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 15.0) + (int) Math.Round(Math.Sqrt((double) front.units.counter));
      if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 250)
        num3 += 5;
      int num4 = 0;
      bool flag1;
      int num5;
      int num6;
      int num7;
      AITheater theaterUse;
      if (front.Stance != 1)
      {
        int num8 = num1;
        for (int Iteration = 1; Iteration <= num8; ++Iteration)
        {
          string str2 = str1 + "\r\n\r\nIteration #" + Iteration.ToString();
          flag1 = false;
          AITheater aiTheater1 = new AITheater(this, front, this.masterPlan);
          aiTheater1.Initialize(Iteration, 100);
          aiTheater1.SetScore(doLog, AttackX: -2);
          string str3 = str2 + "\r\nScore for NoMove = " + aiTheater1.Score.ToString();
          int num9 = -99999999;
          PassHexList tryPassList = new PassHexList();
          int num10 = num3;
          AITheater aiTheater2;
          for (int index = 1; index <= num10; ++index)
          {
            AITheater aiTheater3 = aiTheater1.Clone();
            if (aiTheater3.front.Stance == 4)
              aiTheater3.SetRetreatDefendMove(ref passList1, ref tempPassList1, ref tryPassList, 0, MaxDist: 6);
            else
              aiTheater3.SetRetreatDefendMove(ref passList1, ref tempPassList1, ref tryPassList, 0, MaxDist: 4, blockAlreadyMoved: true);
            aiTheater3.SetScore(false);
            string str4 = str3 + "\r\n";
            if (aiTheater3.Score > num9)
            {
              num9 = aiTheater3.Score;
              aiTheater2 = aiTheater3;
            }
            if (aiTheater3.triedX > -1)
            {
              if (aiTheater3.MoveList.Counter == -1)
              {
                string[] strArray1 = new string[6]
                {
                  str4,
                  "from (",
                  null,
                  null,
                  null,
                  null
                };
                string[] strArray2 = strArray1;
                num5 = aiTheater3.GetRealX(aiTheater3.triedX);
                string str5 = num5.ToString();
                strArray2[2] = str5;
                strArray1[3] = ",";
                string[] strArray3 = strArray1;
                num6 = aiTheater3.triedY + aiTheater3.Top;
                string str6 = num6.ToString();
                strArray3[4] = str6;
                strArray1[5] = ") could not find units enough.";
                str4 = string.Concat(strArray1);
                tryPassList.AddCoord(aiTheater3.triedX, aiTheater3.triedY, 2);
              }
              else
              {
                string[] strArray4 = new string[7];
                strArray4[0] = str4;
                strArray4[1] = "from (";
                string[] strArray5 = strArray4;
                num6 = aiTheater3.GetRealX(aiTheater3.triedX);
                string str7 = num6.ToString();
                strArray5[2] = str7;
                strArray4[3] = ",";
                string[] strArray6 = strArray4;
                num5 = aiTheater3.triedY + aiTheater3.Top;
                string str8 = num5.ToString();
                strArray6[4] = str8;
                strArray4[5] = ") with ";
                strArray4[6] = aiTheater3.MoveList.Counter.ToString();
                str4 = string.Concat(strArray4);
                tryPassList.AddCoord(aiTheater3.triedX, aiTheater3.triedY, 2);
              }
            }
            str3 = str4 + " => try sore for defend = " + aiTheater3.Score.ToString();
          }
          AITheater aiTheater4 = aiTheater2;
          string str9 = str3 + "\r\nScore for Defend = " + aiTheater4.Score.ToString();
          num7 = -99999999;
          string str10;
          if (aiTheater4.Score > num7)
          {
            str10 = "\r\nDefend has better score.";
            num7 = aiTheater4.Score;
            theaterUse = aiTheater4;
          }
          else if (aiTheater4.MoveList.Counter > -1 && aiTheater4.MoveList.Move[0].MoveTo.onmap)
          {
            int matrixX = aiTheater4.GetMatrixX(aiTheater4.MoveList.Move[0].MoveTo.x);
            int y = aiTheater4.MoveList.Move[0].MoveTo.y - aiTheater4.Top;
            tempPassList1.AddCoord(matrixX, y, 2);
          }
          if (aiTheater1.Score > num7)
          {
            str10 = "\r\nNoMove has better score.";
            num7 = aiTheater1.Score;
            theaterUse = aiTheater1;
          }
          string s1 = str9 + str10;
          bool flag2 = false;
          if (theaterUse.MoveList.Counter > -1)
          {
            tempPassList1 = new PassHexList();
            flag2 = this.ExecuteMoveList(ref theaterUse, ref s1);
            if (flag2)
            {
              passList1 = new PassHexList();
              num4 = 0;
            }
          }
          else
            s1 = s1;
          passHexList = new PassHexList();
          if (!flag2)
          {
            ++num4;
            if (front.FrontID == 362)
              ;
            s1 = s1 + "\r\nNO MOVE MADE. PassListCounter=" + passList1.counter.ToString() + ", NoMoveCounter=" + num4.ToString();
            tempPassList1.AddCoord(theaterUse.triedX, theaterUse.triedY, 2);
          }
          string str11 = s1 + "\r\nPassList-DEFEND: ";
          int counter1 = passList1.counter;
          for (int index = 0; index <= counter1; ++index)
          {
            if (passList1.moveType[index] == 2)
            {
              string[] strArray7 = new string[6]
              {
                str11,
                "(",
                null,
                null,
                null,
                null
              };
              string[] strArray8 = strArray7;
              num6 = aiTheater4.GetRealX(passList1.coord[index].x);
              string str12 = num6.ToString();
              strArray8[2] = str12;
              strArray7[3] = ",";
              string[] strArray9 = strArray7;
              num5 = passList1.coord[index].y + aiTheater4.Top;
              string str13 = num5.ToString();
              strArray9[4] = str13;
              strArray7[5] = ") ";
              str11 = string.Concat(strArray7);
            }
          }
          string s2 = str11 + "\r\nTempPassList-DEFEND: ";
          int counter2 = tempPassList1.counter;
          for (int index = 0; index <= counter2; ++index)
          {
            if (tempPassList1.moveType[index] == 2)
            {
              string[] strArray10 = new string[6]
              {
                s2,
                "(",
                null,
                null,
                null,
                null
              };
              string[] strArray11 = strArray10;
              num6 = aiTheater4.GetRealX(tempPassList1.coord[index].x);
              string str14 = num6.ToString();
              strArray11[2] = str14;
              strArray10[3] = ",";
              string[] strArray12 = strArray10;
              num5 = tempPassList1.coord[index].y + aiTheater4.Top;
              string str15 = num5.ToString();
              strArray12[4] = str15;
              strArray10[5] = ") ";
              s2 = string.Concat(strArray10);
            }
          }
          this.AddLog(s2);
          str1 = "";
          if (num4 > num2)
            break;
        }
      }
      PassHexList passList2 = new PassHexList();
      PassHexList tempPassList2 = new PassHexList();
      num4 = 0;
      if (front.Stance == 1)
      {
        int num11 = num1;
        for (int Iteration = 1; Iteration <= num11; ++Iteration)
        {
          string str16 = str1 + "\r\n\r\nIteration #" + Iteration.ToString();
          flag1 = false;
          AITheater aiTheater5 = new AITheater(this, front, this.masterPlan);
          aiTheater5.Initialize(Iteration);
          aiTheater5.SetScore(doLog, AttackX: -2);
          string str17 = str16 + "\r\nScore for NoMove = " + aiTheater5.Score.ToString();
          int num12 = -99999999;
          PassHexList tryPassList = new PassHexList();
          int num13 = num3;
          AITheater aiTheater6;
          for (int index = 1; index <= num13; ++index)
          {
            AITheater aiTheater7 = aiTheater5.Clone();
            aiTheater7.SetScore(false, AttackX: -2);
            aiTheater7.SetFallbackMove(ref passList2, ref tempPassList2, ref tryPassList, 9);
            if (aiTheater7.MoveList.Counter > -1)
            {
              AIMoveList aiMoveList = aiTheater7.MoveList.Clone();
              int score = aiTheater7.Score;
              int triedX = aiTheater7.triedX;
              int triedY = aiTheater7.triedY;
              aiTheater7 = aiTheater5.Clone();
              aiTheater7.MoveList = aiMoveList;
              aiTheater7.Score = score;
              aiTheater7.triedX = triedX;
              aiTheater7.triedY = triedY;
              aiTheater7.SetScore(false);
              str17 += "\r\n";
              if (aiTheater7.Score > num12)
              {
                num12 = aiTheater7.Score;
                aiTheater6 = aiTheater7;
              }
            }
            if (aiTheater7.triedX > -1)
            {
              if (aiTheater7.Score == 0)
              {
                string[] strArray13 = new string[6]
                {
                  str17,
                  "too (",
                  null,
                  null,
                  null,
                  null
                };
                string[] strArray14 = strArray13;
                num6 = aiTheater7.GetRealX(aiTheater7.triedX);
                string str18 = num6.ToString();
                strArray14[2] = str18;
                strArray13[3] = ",";
                string[] strArray15 = strArray13;
                num5 = aiTheater7.triedY + aiTheater7.Top;
                string str19 = num5.ToString();
                strArray15[4] = str19;
                strArray13[5] = ") could not find units enough.";
                str17 = string.Concat(strArray13);
                tryPassList.AddCoord(aiTheater7.triedX, aiTheater7.triedY, 3);
              }
              else
              {
                string[] strArray16 = new string[7];
                strArray16[0] = str17;
                strArray16[1] = "too (";
                string[] strArray17 = strArray16;
                num6 = aiTheater7.GetRealX(aiTheater7.triedX);
                string str20 = num6.ToString();
                strArray17[2] = str20;
                strArray16[3] = ",";
                string[] strArray18 = strArray16;
                num5 = aiTheater7.triedY + aiTheater7.Top;
                string str21 = num5.ToString();
                strArray18[4] = str21;
                strArray16[5] = ") with ";
                strArray16[6] = aiTheater7.MoveList.Counter.ToString();
                str17 = string.Concat(strArray16);
                tryPassList.AddCoord(aiTheater7.triedX, aiTheater7.triedY, 3);
              }
            }
            str17 = str17 + " => try sore for fallback = " + aiTheater7.Score.ToString();
          }
          AITheater Expression = aiTheater6;
          string str22;
          if (!Information.IsNothing((object) Expression))
          {
            str17 = str17 + "\r\nScore for fallback = " + Expression.Score.ToString();
            num7 = -99999999;
            if (aiTheater6.Score > num7)
            {
              str22 = "\r\nfallback has better score.";
              num7 = aiTheater6.Score;
              theaterUse = aiTheater6;
            }
            else if (Expression.MoveList.Counter > -1 && Expression.MoveList.Move[0].MoveTo.onmap)
            {
              int matrixX = Expression.GetMatrixX(Expression.MoveList.Move[0].MoveTo.x);
              int y = Expression.MoveList.Move[0].MoveTo.y - Expression.Top;
              tempPassList2.AddCoord(matrixX, y, 3);
            }
          }
          if (aiTheater5.Score > num7)
          {
            str22 = "\r\nNoMove has better score.";
            num7 = aiTheater5.Score;
            theaterUse = aiTheater5;
          }
          string s = str17 + str22;
          bool flag3 = false;
          if (!Information.IsNothing((object) theaterUse) && theaterUse.MoveList.Counter > -1)
          {
            flag3 = this.ExecuteMoveList(ref theaterUse, ref s);
            if (flag3)
            {
              passList2 = new PassHexList();
              tempPassList2 = new PassHexList();
              num4 = 0;
            }
          }
          if (!flag3)
          {
            ++num4;
            s = s + "\r\nNO MOVE MADE. PassListCounter=" + passList2.counter.ToString() + ", NoMoveCounter=" + num4.ToString();
          }
          this.AddLog(s);
          str1 = "";
          if (num4 > num2)
            break;
        }
      }
      if (doLog)
        this.WriteLog("retreat_front_" + front.FrontID.ToString());
      Application.DoEvents();
    }

    public void ExecuteFront(ref AIFront front, bool doLog)
    {
      SimpleList simpleList1 = new SimpleList();
      if (front.FrontID == 1489)
      {
        string str1 = str1;
      }
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      int frontId = front.FrontID;
      string s;
      if (front.FrontType == 13)
      {
        s = "Moves For FLAK Front #" + front.FrontID.ToString();
        front.FrontID = front.TargetFrontID;
      }
      else
        s = "Moves For Front #" + front.FrontID.ToString();
      PassHexList passList = new PassHexList();
      PassHexList tempPassList = new PassHexList();
      PassHexList passHexList = new PassHexList();
      int num1 = 6 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 15.0) + (int) Math.Round((double) front.units.counter * 1.5);
      int num2 = 4 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 70.0);
      int num3 = 10 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 15.0) + (int) Math.Round(Math.Sqrt((double) front.units.counter));
      if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 250)
        num3 += 5;
      int num4 = 0;
      if (!this.CustomCalls.CustomDoStrategicIterations())
      {
        num2 = 1;
        int num5 = (int) Math.Round((double) num3 / 4.0) + 1;
      }
      if (front.DefensiveZone == 1)
        s = s;
      bool flag1 = false;
      int counter1 = front.units.counter;
      int index1;
      for (int index2 = 0; index2 <= counter1; ++index2)
      {
        index1 = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index2]);
        if (index1 > -1)
          this.game.Data.UnitObj[index1].TempAIForbidsMove = false;
      }
      int num6 = num1;
      AITheater aiTheater1;
      for (int Iteration = 1; Iteration <= num6; ++Iteration)
      {
        if (!this.VAR_DEBUG_ON)
          s = "";
        string str2 = s + "\r\n\r\nIteration #" + Iteration.ToString();
        AITheater aiTheater2;
        string str3;
        string str4;
        bool flag2;
        if (Iteration <= 1 | flag1)
        {
          aiTheater2 = new AITheater(this, front, this.masterPlan);
          AIMatrix aiMatrix;
          int left;
          int top;
          int bottom;
          int right;
          if (Iteration == 1)
          {
            aiTheater2.Initialize(Iteration);
            aiMatrix = aiTheater2.Advance.Clone();
            left = aiTheater2.Left;
            top = aiTheater2.Top;
            bottom = aiTheater2.Bottom;
            right = aiTheater2.Right;
          }
          else
          {
            aiTheater2.Initialize(Iteration, tleft: left, ttop: top, tright: right, tbottom: bottom);
            aiTheater2.origAdvance = aiMatrix.Clone();
          }
          str3 = aiTheater2.SetScore(doLog, AttackX: -2);
          passList = new PassHexList();
          str4 = str2 + "\r\nScore for NoMove = " + aiTheater2.Score.ToString() + "(" + str3 + ")";
          flag2 = false;
        }
        else
        {
          str4 = str2 + "\r\n(COPY) Score for NoMove = " + aiTheater2.Score.ToString() + "(" + str3 + ")";
          flag2 = false;
        }
        int num7 = -999999;
        PassHexList tryPassList = new PassHexList();
        int stimulateAttack = 0;
        AITheater aiTheater3 = aiTheater2;
        int num8 = 5 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 15.0) + (int) Math.Round(Math.Sqrt((double) front.units.counter));
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 250)
          num8 += 5;
        if (!this.CustomCalls.CustomDoStrategicIterations())
          num8 = (int) Math.Round((double) num8 / 4.0) + 1;
        if (front.DefensiveZone > 0)
          num8 = 0;
        if (front.FrontType == 13)
          num8 = (int) Math.Round((double) num8 / 4.0) + 1;
        if (num8 > 99)
          num8 = 99;
        int num9 = num8;
        int num10;
        int num11;
        for (int index3 = 1; index3 <= num9; ++index3)
        {
          AITheater aiTheater4 = aiTheater2.Clone();
          aiTheater4.SetAttackMove(ref passList, ref tempPassList, ref tryPassList, stimulateAttack);
          aiTheater4.ImplementMoveList();
          str3 = !(aiTheater4.triedX > -1 & aiTheater4.MoveList.Counter > -1) ? aiTheater4.SetScore(false) : aiTheater4.SetScore(false, true, aiTheater4.triedX, aiTheater4.triedY);
          string str5 = str4 + "\r\n";
          if (aiTheater4.Score > num7 & aiTheater4.MoveList.Counter > -1)
          {
            num7 = aiTheater4.Score;
            aiTheater3 = aiTheater4;
          }
          if (aiTheater4.triedX > -1)
          {
            if (aiTheater4.MoveList.Counter < 0)
            {
              string[] strArray1 = new string[6]
              {
                str5,
                "on (",
                null,
                null,
                null,
                null
              };
              string[] strArray2 = strArray1;
              num10 = aiTheater4.GetRealX(aiTheater4.triedX);
              string str6 = num10.ToString();
              strArray2[2] = str6;
              strArray1[3] = ",";
              string[] strArray3 = strArray1;
              num11 = aiTheater4.triedY + aiTheater4.Top;
              string str7 = num11.ToString();
              strArray3[4] = str7;
              strArray1[5] = ") could not find units enough.";
              str5 = string.Concat(strArray1) + " with stimulate attack= " + stimulateAttack.ToString() + "set stimulate back to 0 + add to passList";
              tempPassList.AddCoord(aiTheater4.triedX, aiTheater4.triedY, 1);
              stimulateAttack = 0;
            }
            else
            {
              stimulateAttack = 0;
              string[] strArray4 = new string[7];
              strArray4[0] = str5;
              strArray4[1] = "on (";
              string[] strArray5 = strArray4;
              num11 = aiTheater4.GetRealX(aiTheater4.triedX);
              string str8 = num11.ToString();
              strArray5[2] = str8;
              strArray4[3] = ",";
              string[] strArray6 = strArray4;
              num10 = aiTheater4.triedY + aiTheater4.Top;
              string str9 = num10.ToString();
              strArray6[4] = str9;
              strArray4[5] = ") with ";
              strArray4[6] = aiTheater4.MoveList.Counter.ToString();
              str5 = string.Concat(strArray4) + " with stimulate attack= " + stimulateAttack.ToString();
              tryPassList.AddCoord(aiTheater4.triedX, aiTheater4.triedY, 1);
            }
          }
          str4 = str5 + " => try sore for attack = " + aiTheater4.Score.ToString() + "(" + str3 + ")";
          if (str4.Length > 1000000)
            str4 = "***TO MUCH TEXT***";
        }
        AITheater Expression1 = aiTheater3;
        if (Information.IsNothing((object) Expression1))
          Expression1 = aiTheater2.Clone();
        string str10 = str4 + "\r\nBest Score for Attack = " + Expression1.Score.ToString();
        int num12 = -999999;
        int stimulateDefend1 = 0;
        tryPassList = new PassHexList();
        aiTheater1 = aiTheater2.Clone();
        AITheater aiTheater5 = aiTheater2;
        int num13 = 10 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 15.0) + front.units.counter;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 250)
          num13 += 8;
        bool flag3 = false;
        if (!this.CustomCalls.CustomDoStrategicIterations())
        {
          num13 = (int) Math.Round((double) num13 / 3.0) + 1;
          flag3 = true;
        }
        if (this.CustomCalls.CustomIsMinor())
        {
          num13 *= 2;
          flag3 = false;
        }
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus < 100)
          flag3 = true;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus == 100)
          num13 = Math.Max(1, (int) Math.Round((double) num13 / 2.0));
        if (front.DefensiveZone > 0)
          num13 = 0;
        if (front.FrontType == 13)
          flag3 = true;
        if (front.units.counter > 50)
          flag3 = true;
        if (front.units.counter < 1 | flag3)
        {
          int tickCount = Environment.TickCount;
          int num14 = num13;
          for (int index4 = 1; index4 <= num14; ++index4)
          {
            AITheater aiTheater6 = aiTheater2.Clone();
            SimpleList simpleList2;
            if (front.FrontType == 13)
            {
              AITheater aiTheater7 = aiTheater6;
              ref PassHexList local1 = ref passList;
              ref PassHexList local2 = ref tempPassList;
              ref PassHexList local3 = ref tryPassList;
              int stimulateDefend2 = stimulateDefend1;
              simpleList2 = (SimpleList) null;
              ref SimpleList local4 = ref simpleList2;
              aiTheater7.SetDefendMove(ref local1, ref local2, ref local3, stimulateDefend2, excludeUnitAiId: (ref local4), extraMoveIncentive: 1000);
            }
            else
            {
              AITheater aiTheater8 = aiTheater6;
              ref PassHexList local5 = ref passList;
              ref PassHexList local6 = ref tempPassList;
              ref PassHexList local7 = ref tryPassList;
              int stimulateDefend3 = stimulateDefend1;
              simpleList2 = (SimpleList) null;
              ref SimpleList local8 = ref simpleList2;
              aiTheater8.SetDefendMove(ref local5, ref local6, ref local7, stimulateDefend3, excludeUnitAiId: (ref local8));
            }
            aiTheater6.ImplementMoveList();
            str3 = aiTheater6.SetScore(false);
            string str11 = str10 + "\r\n";
            if (aiTheater6.Score > num12 & aiTheater6.MoveList.Counter > -1)
            {
              num12 = aiTheater6.Score;
              aiTheater5 = aiTheater6;
            }
            if (aiTheater6.triedX > -1)
            {
              if (aiTheater6.MoveList.Counter < 0)
              {
                stimulateDefend1 = 0;
                string[] strArray7 = new string[7];
                strArray7[0] = str11;
                strArray7[1] = "too (";
                string[] strArray8 = strArray7;
                num11 = aiTheater6.GetRealX(aiTheater6.triedX);
                string str12 = num11.ToString();
                strArray8[2] = str12;
                strArray7[3] = ",";
                string[] strArray9 = strArray7;
                num10 = aiTheater6.triedY + aiTheater6.Top;
                string str13 = num10.ToString();
                strArray9[4] = str13;
                strArray7[5] = ") with ";
                strArray7[6] = aiTheater6.MoveList.Counter.ToString();
                str11 = string.Concat(strArray7);
                tempPassList.AddCoord(aiTheater6.triedX, aiTheater6.triedY, 2);
              }
              else
              {
                stimulateDefend1 = 0;
                string[] strArray10 = new string[7];
                strArray10[0] = str11;
                strArray10[1] = "too (";
                string[] strArray11 = strArray10;
                num11 = aiTheater6.GetRealX(aiTheater6.triedX);
                string str14 = num11.ToString();
                strArray11[2] = str14;
                strArray10[3] = ",";
                string[] strArray12 = strArray10;
                num10 = aiTheater6.triedY + aiTheater6.Top;
                string str15 = num10.ToString();
                strArray12[4] = str15;
                strArray10[5] = ") with ";
                strArray10[6] = aiTheater6.MoveList.Counter.ToString();
                str11 = string.Concat(strArray10);
                tryPassList.AddCoord(aiTheater6.triedX, aiTheater6.triedY, 2);
              }
            }
            str10 = str11 + " => try sore for defend = " + aiTheater6.Score.ToString() + "(" + str3 + ")";
            if (str10.Length > 1000000)
              str10 = "***TO MUCH TEXT***";
          }
          int num15 = Environment.TickCount - tickCount;
        }
        if (front.units.counter > 0 & !flag3)
        {
          int num16 = 1 + (int) Math.Round(Math.Floor(Math.Sqrt((double) (1 + front.units.counter))));
          if (num16 > 5)
            num16 = 5;
          if (front.units.counter <= 0)
            num16 = 1;
          AITheater[] aiTheaterArray = new AITheater[1000];
          int[] numArray1 = new int[1000];
          int index5 = -1;
          SimpleList simpleList3 = new SimpleList();
          int num17 = num13;
          int num18 = num16;
          for (int index6 = 1; index6 <= num18; ++index6)
          {
            tryPassList = new PassHexList();
            passList = new PassHexList();
            tempPassList = new PassHexList();
            int num19 = index5;
            string str16 = str10;
            num10 = simpleList3.Counter + 1;
            string str17 = num10.ToString();
            str10 = str16 + "\r\nEXCLUDED UNITS: " + str17 + "\r\n";
            int num20 = num17;
            if (num20 > 30)
              num20 = 30;
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 100)
              num20 = (int) Math.Round((double) num20 / (double) index6);
            int num21 = num20 * 2;
            for (int index7 = 1; index7 <= num21; ++index7)
            {
              AITheater aiTheater9 = aiTheater2.Clone();
              if (index7 <= num20)
              {
                aiTheater9.SetDefendMove(ref passList, ref tempPassList, ref tryPassList, stimulateDefend1, excludeUnitAiId: (ref simpleList3));
              }
              else
              {
                if (index7 == num20 + 1)
                {
                  tempPassList = new PassHexList();
                  tryPassList = new PassHexList();
                  passList = new PassHexList();
                }
                aiTheater9.SetDefendMove(ref passList, ref tempPassList, ref tryPassList, stimulateDefend1, excludeUnitAiId: (ref simpleList3), extraMoveIncentive: 1000);
              }
              aiTheater9.ImplementMoveList();
              str3 = aiTheater9.SetScore(false);
              string str18 = str10 + "\r\n";
              if (aiTheater9.Score > num12 & aiTheater9.MoveList.Counter > -1)
              {
                str18 += "***BEST*** ";
                num12 = aiTheater9.Score;
                aiTheater5 = aiTheater9;
              }
              if (aiTheater9.triedX > -1)
              {
                if (aiTheater9.MoveList.Counter < 0)
                {
                  stimulateDefend1 = 0;
                  string[] strArray13 = new string[6]
                  {
                    str18,
                    "IMPOSSIBLE to move to (",
                    null,
                    null,
                    null,
                    null
                  };
                  string[] strArray14 = strArray13;
                  num11 = aiTheater9.GetRealX(aiTheater9.triedX);
                  string str19 = num11.ToString();
                  strArray14[2] = str19;
                  strArray13[3] = ",";
                  string[] strArray15 = strArray13;
                  num10 = aiTheater9.triedY + aiTheater9.Top;
                  string str20 = num10.ToString();
                  strArray15[4] = str20;
                  strArray13[5] = ") ";
                  str18 = string.Concat(strArray13);
                  tempPassList.AddCoord(aiTheater9.triedX, aiTheater9.triedY, 2);
                }
                else
                {
                  ++index5;
                  aiTheaterArray[index5] = aiTheater9;
                  numArray1[index5] = aiTheater9.MoveList.Move[0].UnitAIid;
                  stimulateDefend1 = 0;
                  string[] strArray16 = new string[8]
                  {
                    str18,
                    "move to (",
                    aiTheater9.GetRealX(aiTheater9.triedX).ToString(),
                    ",",
                    null,
                    null,
                    null,
                    null
                  };
                  string[] strArray17 = strArray16;
                  num11 = aiTheater9.triedY + aiTheater9.Top;
                  string str21 = num11.ToString();
                  strArray17[4] = str21;
                  strArray16[5] = ") with ";
                  string[] strArray18 = strArray16;
                  num10 = aiTheater9.MoveList.Counter + 1;
                  string str22 = num10.ToString();
                  strArray18[6] = str22;
                  strArray16[7] = " unit(s).";
                  str18 = string.Concat(strArray16);
                  tryPassList.AddCoord(aiTheater9.triedX, aiTheater9.triedY, 2);
                }
              }
              str10 = str18 + " => try sore for defend = " + aiTheater9.Score.ToString() + "(" + str3 + ")";
              if (str10.Length > 1000000)
                str10 = "***TO MUCH TEXT***";
              if (index5 > 800)
                break;
            }
            SimpleList simpleList4 = new SimpleList();
            int num22 = num19 + 1;
            int num23 = index5;
            for (int index8 = num22; index8 <= num23; ++index8)
            {
              int counter2 = aiTheaterArray[index8].MoveList.Counter;
              for (int index9 = 0; index9 <= counter2; ++index9)
              {
                index1 = aiTheaterArray[index8].MoveList.Move[index9].UnitAIid;
                simpleList4.AddWeight(index1, 1);
              }
            }
            if (simpleList4.Counter > -1)
            {
              int num24 = (int) Math.Round(Math.Floor((double) (front.units.counter + 1) / (double) num16));
              if (num24 < 1)
                num24 = 1;
              if (index6 == num16 - 1 && front.units.counter - (simpleList3.Counter + num24) > 2)
                ++num24;
              simpleList4.ReverseSortHighSpeed();
              int num25 = num24 - 1;
              for (int index10 = 0; index10 <= num25; ++index10)
              {
                if (index10 <= simpleList4.Counter)
                  simpleList3.Add(simpleList4.Id[index10], 1);
              }
            }
            else
              index6 = 999;
            if (index5 > 800)
              break;
          }
          if (!this.CustomCalls.CustomIsMinor())
          {
            SimpleList[] simpleListArray = new SimpleList[front.units.counter + 1 + 1];
            int counter3 = front.units.counter;
            for (int index11 = 0; index11 <= counter3; ++index11)
            {
              simpleListArray[index11] = new SimpleList();
              int num26 = 999999;
              int num27 = index5;
              for (int tid = 0; tid <= num27; ++tid)
              {
                if (numArray1[tid] == front.units.AIid[index11])
                {
                  simpleListArray[index11].Add(tid, aiTheaterArray[tid].Score);
                  if (aiTheaterArray[tid].Score < num26)
                    num26 = aiTheaterArray[tid].Score;
                }
              }
              if (num26 < 1)
              {
                int counter4 = simpleListArray[index11].Counter;
                for (int index12 = 0; index12 <= counter4; ++index12)
                {
                  int[] weight = simpleListArray[index11].Weight;
                  int[] numArray2 = weight;
                  int index13 = index12;
                  int index14 = index13;
                  int num28 = weight[index13] + (1 + Math.Abs(num26));
                  numArray2[index14] = num28;
                }
              }
              simpleListArray[index11].ReverseSortHighSpeed();
            }
            int num29 = 2;
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 100)
              num29 = 1;
            SimpleList simpleList5 = new SimpleList();
            int counter5 = front.units.counter;
            for (int tid = 0; tid <= counter5; ++tid)
            {
              if (simpleListArray[tid].Counter > -1)
              {
                index1 = -99999;
                int counter6 = simpleListArray[tid].Counter;
                for (int index15 = 0; index15 <= counter6; ++index15)
                {
                  if (simpleListArray[tid].Weight[index15] > index1)
                    index1 = simpleListArray[tid].Weight[index15];
                }
                simpleList5.Add(tid, index1);
              }
            }
            simpleList5.ReverseSortHighSpeed();
            int num30 = 2 + (int) Math.Round(Math.Sqrt((double) (front.units.counter + 1)));
            if (num30 > simpleList5.Counter)
              num30 = simpleList5.Counter;
            int num31 = num29;
            for (int index16 = 1; index16 <= num31; ++index16)
            {
              int num32 = num30;
              for (int index17 = 0; index17 <= num32; ++index17)
              {
                int index18 = simpleList5.Id[index17];
                if (simpleListArray[index18].Counter > -1)
                {
                  int num33 = num30;
                  for (int index19 = 0; index19 <= num33; ++index19)
                  {
                    int index20 = simpleList5.Id[index19];
                    if (simpleListArray[index20].Counter > -1 & index18 != index20)
                    {
                      index1 = index18;
                      int index21 = index20;
                      if (simpleListArray[index1].Counter > -1 && simpleListArray[index21].Counter > -1)
                      {
                        int randomIdbasedOnWeight1 = simpleListArray[index1].GetRandomIdbasedOnWeight();
                        int randomIdbasedOnWeight2 = simpleListArray[index21].GetRandomIdbasedOnWeight();
                        AITheater aiTheater10 = aiTheater2.Clone();
                        aiTheater10.MoveList.AddMove(ref aiTheaterArray[randomIdbasedOnWeight1].MoveList.Move[0]);
                        aiTheater10.MoveList.AddMove(ref aiTheaterArray[randomIdbasedOnWeight2].MoveList.Move[0]);
                        aiTheater10.ImplementMoveList();
                        str3 = aiTheater10.SetScore(false);
                        string str23 = str10 + "\r\n";
                        if (aiTheater10.Score > num12 & aiTheater10.MoveList.Counter > -1)
                        {
                          str23 += "***BEST*** ";
                          num12 = aiTheater10.Score;
                          aiTheater5 = aiTheater10;
                        }
                        str10 = str23 + " Move to " + aiTheaterArray[randomIdbasedOnWeight1].MoveList.Move[0].MoveTo.x.ToString() + "," + aiTheaterArray[randomIdbasedOnWeight1].MoveList.Move[0].MoveTo.y.ToString() + " AND " + aiTheaterArray[randomIdbasedOnWeight2].MoveList.Move[0].MoveTo.x.ToString() + "," + aiTheaterArray[randomIdbasedOnWeight2].MoveList.Move[0].MoveTo.y.ToString() + " => try sore for defend = " + aiTheater10.Score.ToString() + "(" + str3 + ")";
                      }
                    }
                  }
                }
              }
            }
          }
        }
        AITheater Expression2 = aiTheater5;
        if (Information.IsNothing((object) Expression2))
          Expression2 = aiTheater2.Clone();
        string str24 = str10 + "\r\nScore for Defend = " + Expression2.Score.ToString();
        bool flag4 = true;
        if (this.game.Data.Product >= 6)
        {
          if (front.Stance == 3)
            flag4 = false;
          else if (front.Stance == 2 && front.Strength >= 3)
            flag4 = false;
        }
        if (front.DefensiveZone > 0)
          flag4 = true;
        AITheater Expression3;
        if (flag4)
        {
          int num34 = -999999;
          tryPassList = new PassHexList();
          AITheater aiTheater11 = aiTheater2;
          int num35 = 5 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 15.0) + (int) Math.Round(Math.Sqrt((double) front.units.counter));
          if (front.DefensiveZone < 1 & this.game.Data.Product < 6)
            num35 = 0;
          if (!this.CustomCalls.CustomDoStrategicIterations())
            num35 = (int) Math.Round((double) num35 / 4.0) + 1;
          if (front.FrontType == 13)
            num35 = (int) Math.Round((double) num35 / 4.0) + 1;
          int num36 = num35;
          for (int index22 = 1; index22 <= num36; ++index22)
          {
            AITheater aiTheater12 = aiTheater2.Clone();
            if (front.DefensiveZone > 0)
            {
              aiTheater12.SetDefensiveZoneMove(ref passList, ref tempPassList, ref tryPassList);
              if (aiTheater12.MoveList.Counter == -1)
                index1 = index1;
            }
            else
              aiTheater12.SetFallbackMove(ref passList, ref tempPassList, ref tryPassList, 2);
            if (front.FrontID == 1000001)
              str24 = str24;
            aiTheater12.ImplementMoveList();
            str3 = aiTheater12.SetScore(false);
            aiTheater12.Score = front.DefensiveZone >= 1 ? aiTheater12.Score : (int) Math.Round((double) aiTheater12.Score / Math.Max(0.2, (double) front.UnitCountRatio));
            str24 += "\r\n";
            if (aiTheater12.Score > num34 & aiTheater12.MoveList.Counter > -1)
            {
              num34 = aiTheater12.Score;
              aiTheater11 = aiTheater12;
            }
            if (aiTheater12.triedX > -1)
            {
              string[] strArray19 = new string[7];
              strArray19[0] = str24;
              strArray19[1] = "too (";
              string[] strArray20 = strArray19;
              num10 = aiTheater12.GetRealX(aiTheater12.triedX);
              string str25 = num10.ToString();
              strArray20[2] = str25;
              strArray19[3] = ",";
              strArray19[4] = (aiTheater12.triedY + aiTheater12.Top).ToString();
              strArray19[5] = ") with ";
              strArray19[6] = aiTheater12.MoveList.Counter.ToString();
              str24 = string.Concat(strArray19);
              tryPassList.AddCoord(aiTheater12.triedX, aiTheater12.triedY, 3);
            }
            if (!this.VAR_DEBUG_ON)
              str24 = "";
            if (front.DefensiveZone < 1)
              str24 = str24 + " => try sore for Fallback = " + aiTheater12.Score.ToString() + "(" + str3 + ")";
            if (front.DefensiveZone >= 1)
              str24 = str24 + " => try sore for Defensive Zone-Fallback = " + aiTheater12.Score.ToString() + "(" + str3 + ")";
            if (str24.Length > 1000000)
              str24 = "***TO MUCH TEXT***";
          }
          Expression3 = aiTheater11;
          if (Information.IsNothing((object) Expression3))
            Expression3 = aiTheater2.Clone();
          if (front.DefensiveZone < 1)
            str24 = str24 + "\r\nScore for Fallback = " + Expression3.Score.ToString();
          if (front.DefensiveZone >= 1)
            str24 = str24 + "\r\nScore for Defensive Zone-Fallback = " + Expression3.Score.ToString();
        }
        else
          Expression3 = aiTheater2;
        if (front.DefensiveZone >= 1)
        {
          Expression2.Score -= 500;
          Expression1.Score -= 800;
        }
        int num37 = -9999999;
        string str26;
        AITheater Expression4;
        bool flag5;
        if (Expression1.Score > num37)
        {
          str26 = "\r\nAttack has better score.";
          num37 = Expression1.Score;
          Expression4 = Expression1;
          flag5 = true;
        }
        else if (Expression1.MoveList.Counter > -1 && Expression1.MoveList.Move[0].AttackOn.onmap)
        {
          int matrixX = Expression1.GetMatrixX(Expression1.MoveList.Move[0].AttackOn.x);
          int y = Expression1.MoveList.Move[0].AttackOn.y - Expression1.Top;
          tempPassList.AddCoord(matrixX, y, 1);
        }
        if (Expression2.Score > num37)
        {
          str26 = "\r\nDefend has better score.";
          num37 = Expression2.Score;
          Expression4 = Expression2;
          flag5 = false;
        }
        else if (Expression2.MoveList.Counter > -1 && Expression2.MoveList.Move[0].MoveTo.onmap)
        {
          int matrixX = Expression2.GetMatrixX(Expression2.MoveList.Move[0].MoveTo.x);
          int y = Expression2.MoveList.Move[0].MoveTo.y - Expression2.Top;
          tempPassList.AddCoord(matrixX, y, 2);
        }
        if (Expression3.Score > num37)
        {
          str26 = "\r\nFallBack has better score.";
          num37 = Expression3.Score;
          Expression4 = Expression3;
          flag5 = false;
        }
        else if (Expression3.MoveList.Counter > -1)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(Expression3.MoveList.Move[0].UnitAIid);
          if (unitByAiid > -1)
          {
            int matrixX = Expression3.GetMatrixX(this.game.Data.UnitObj[unitByAiid].X);
            int y = this.game.Data.UnitObj[unitByAiid].Y - Expression3.Top;
            tempPassList.AddCoord(matrixX, y, 3);
          }
        }
        if (aiTheater2.Score >= num37)
        {
          str26 = "\r\nNoMove has better score.";
          int score = aiTheater2.Score;
          Expression4 = aiTheater2;
          passList = new PassHexList();
          flag5 = false;
        }
        string str27 = str24 + str26 + "\r\nPassList-DEFEND: ";
        int counter7 = passList.counter;
        for (int index23 = 0; index23 <= counter7; ++index23)
        {
          if (passList.moveType[index23] == 2)
          {
            string[] strArray21 = new string[6]
            {
              str27,
              "(",
              null,
              null,
              null,
              null
            };
            string[] strArray22 = strArray21;
            num10 = Expression2.GetRealX(passList.coord[index23].x);
            string str28 = num10.ToString();
            strArray22[2] = str28;
            strArray21[3] = ",";
            strArray21[4] = (passList.coord[index23].y + Expression2.Top).ToString();
            strArray21[5] = ") ";
            str27 = string.Concat(strArray21);
          }
        }
        string str29 = str27 + "\r\nPassList-ATTACK: ";
        int counter8 = passList.counter;
        for (int index24 = 0; index24 <= counter8; ++index24)
        {
          if (passList.moveType[index24] == 1)
          {
            string[] strArray23 = new string[6]
            {
              str29,
              "(",
              null,
              null,
              null,
              null
            };
            string[] strArray24 = strArray23;
            num10 = Expression1.GetRealX(passList.coord[index24].x);
            string str30 = num10.ToString();
            strArray24[2] = str30;
            strArray23[3] = ",";
            strArray23[4] = (passList.coord[index24].y + Expression1.Top).ToString();
            strArray23[5] = ") ";
            str29 = string.Concat(strArray23);
          }
        }
        string str31 = str29 + "\r\nPassList-FALLBACK: ";
        int counter9 = passList.counter;
        for (int index25 = 0; index25 <= counter9; ++index25)
        {
          if (passList.moveType[index25] == 3)
          {
            string[] strArray25 = new string[6]
            {
              str31,
              "(",
              null,
              null,
              null,
              null
            };
            string[] strArray26 = strArray25;
            num10 = Expression3.GetRealX(passList.coord[index25].x);
            string str32 = num10.ToString();
            strArray26[2] = str32;
            strArray25[3] = ",";
            strArray25[4] = (passList.coord[index25].y + Expression3.Top).ToString();
            strArray25[5] = ") ";
            str31 = string.Concat(strArray25);
          }
        }
        string str33 = str31 + "\r\nTempPassList-DEFEND: ";
        int counter10 = tempPassList.counter;
        for (int index26 = 0; index26 <= counter10; ++index26)
        {
          if (tempPassList.moveType[index26] == 2)
          {
            string[] strArray27 = new string[6]
            {
              str33,
              "(",
              null,
              null,
              null,
              null
            };
            string[] strArray28 = strArray27;
            num10 = Expression2.GetRealX(tempPassList.coord[index26].x);
            string str34 = num10.ToString();
            strArray28[2] = str34;
            strArray27[3] = ",";
            strArray27[4] = (tempPassList.coord[index26].y + Expression2.Top).ToString();
            strArray27[5] = ") ";
            str33 = string.Concat(strArray27);
          }
        }
        string str35 = str33 + "\r\nTempPassList-ATTACK: ";
        int counter11 = tempPassList.counter;
        for (int index27 = 0; index27 <= counter11; ++index27)
        {
          if (tempPassList.moveType[index27] == 1)
          {
            string[] strArray29 = new string[6]
            {
              str35,
              "(",
              null,
              null,
              null,
              null
            };
            string[] strArray30 = strArray29;
            num10 = Expression1.GetRealX(tempPassList.coord[index27].x);
            string str36 = num10.ToString();
            strArray30[2] = str36;
            strArray29[3] = ",";
            strArray29[4] = (tempPassList.coord[index27].y + Expression1.Top).ToString();
            strArray29[5] = ") ";
            str35 = string.Concat(strArray29);
          }
        }
        s = str35 + "\r\nTempPassList-FALLBACK: ";
        int counter12 = tempPassList.counter;
        for (int index28 = 0; index28 <= counter12; ++index28)
        {
          if (tempPassList.moveType[index28] == 3)
          {
            string[] strArray31 = new string[6]
            {
              s,
              "(",
              null,
              null,
              null,
              null
            };
            string[] strArray32 = strArray31;
            num10 = Expression3.GetRealX(tempPassList.coord[index28].x);
            string str37 = num10.ToString();
            strArray32[2] = str37;
            strArray31[3] = ",";
            strArray31[4] = (tempPassList.coord[index28].y + Expression3.Top).ToString();
            strArray31[5] = ") ";
            s = string.Concat(strArray31);
          }
        }
        flag1 = false;
        if (!Information.IsNothing((object) Expression4))
        {
          if (Expression4.MoveList.Counter > -1)
          {
            if (this.game.Data.Turn == 7)
              ;
            if (flag5)
              this.SpecialCaseAddExtraOutsideFrontUnitsIfGoodFacing(ref front, ref s, ref Expression4.MoveList, ref Expression4, Expression4.GetRealX(Expression4.triedX), Expression4.triedY + Expression4.Top);
            if (!this.ExecuteMoveList(ref Expression4, ref s))
            {
              if (Expression4.MoveList.Move[0].AttackOn.onmap)
              {
                tempPassList.AddCoord(Expression4.GetMatrixX(Expression4.MoveList.Move[0].AttackOn.x), Expression4.MoveList.Move[0].AttackOn.y - Expression4.Top, 1);
                if (simpleList1.FindNr(Expression4.MoveList.Move[0].UnitAIid) > -1)
                  passList.AddCoord(Expression4.GetMatrixX(Expression4.MoveList.Move[0].AttackOn.x), Expression4.MoveList.Move[0].AttackOn.y - Expression4.Top, 1);
                else
                  simpleList1.Add(Expression4.MoveList.Move[0].UnitAIid, 1);
              }
              else if (Expression4.MoveList.Move[0].MoveTo.onmap)
              {
                tempPassList.AddCoord(Expression4.GetMatrixX(Expression4.MoveList.Move[0].MoveTo.x), Expression4.MoveList.Move[0].AttackOn.y - Expression4.Top, 2);
                tempPassList.AddCoord(Expression4.GetMatrixX(Expression4.MoveList.Move[0].MoveTo.x), Expression4.MoveList.Move[0].AttackOn.y - Expression4.Top, 3);
                if (simpleList1.FindNr(Expression4.MoveList.Move[0].UnitAIid) > -1)
                {
                  passList.AddCoord(Expression4.GetMatrixX(Expression4.MoveList.Move[0].MoveTo.x), Expression4.MoveList.Move[0].AttackOn.y - Expression4.Top, 2);
                  passList.AddCoord(Expression4.GetMatrixX(Expression4.MoveList.Move[0].MoveTo.x), Expression4.MoveList.Move[0].AttackOn.y - Expression4.Top, 3);
                }
                else
                  simpleList1.Add(Expression4.MoveList.Move[0].UnitAIid, 1);
              }
              flag1 = true;
            }
            else
            {
              num4 = 0;
              tempPassList = new PassHexList();
              passList = new PassHexList();
              flag1 = true;
            }
          }
          if (!flag1)
          {
            bool flag6 = true;
            if (Expression4.MoveList.Counter > -1)
            {
              int counter13 = Expression4.MoveList.Counter;
              for (int index29 = 0; index29 <= counter13; ++index29)
              {
                index1 = Expression4.MoveList.Move[index29].UnitAIid;
                int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(index1);
                if (unitByAiid > -1 && this.game.Data.UnitObj[unitByAiid].TempAIForbidsMove)
                  flag6 = false;
              }
            }
            if (flag6)
              ++num4;
            s = s + "\r\nNO MOVE MADE. PassListCounter=" + passList.counter.ToString() + ", NoMoveCounter=" + num4.ToString();
          }
          else
            num4 = 0;
        }
        else
          ++num4;
        if (num4 > num2)
          break;
      }
      if (front.FrontType == 13)
        front.FrontID = frontId;
      AITheater aiTheater13 = (AITheater) null;
      AITheater aiTheater14 = (AITheater) null;
      aiTheater1 = (AITheater) null;
      AITheater aiTheater15 = (AITheater) null;
      this.AddLog(s);
      if (front.FrontType == 13)
      {
        if (doLog)
          this.WriteLog("FLAK_front_" + front.FrontID.ToString());
      }
      else if (doLog)
        this.WriteLog("front_" + front.FrontID.ToString());
      aiTheater15 = (AITheater) null;
      aiTheater14 = (AITheater) null;
      aiTheater1 = (AITheater) null;
      aiTheater13 = (AITheater) null;
      Application.DoEvents();
    }

    public void ExecuteFrontArtUnits(ref AIFront front, bool doLog)
    {
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Art Units For Front #" + front.FrontID.ToString();
      PassHexList passList = new PassHexList();
      PassHexList tempPassList = new PassHexList();
      PassHexList passHexList = new PassHexList();
      int num1 = 50;
      int num2 = 3;
      int num3 = 2 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 8.0);
      if (this.game.Data.Product >= 6)
        num3 += 7;
      int num4 = 0;
      int num5 = num1;
      for (int Iteration = 1; Iteration <= num5; ++Iteration)
      {
        string str1 = s + "\r\n\r\nIteration #" + Iteration.ToString();
        int num6 = -9999;
        AITheater aiTheater1 = new AITheater(this, front, this.masterPlan);
        aiTheater1.Initialize(Iteration);
        aiTheater1.SetScore(doLog);
        string str2 = str1 + "\r\nScore for NoMove = " + aiTheater1.Score.ToString();
        int num7 = -999999;
        int stimulateDefend = 0;
        PassHexList tryPassList = new PassHexList();
        int num8 = num3;
        AITheater aiTheater2;
        AITheater Expression;
        for (int index = 1; index <= num8; ++index)
        {
          aiTheater2 = aiTheater1.Clone();
          aiTheater2.SetDefendArtMove(ref passList, ref tempPassList, ref tryPassList, stimulateDefend);
          aiTheater2.ImplementMoveList();
          aiTheater2.SetScore(false);
          string str3 = str2 + "\r\n";
          if (aiTheater2.Score > num7)
          {
            num7 = aiTheater2.Score;
            Expression = aiTheater2;
          }
          if (aiTheater2.triedX > -1)
          {
            stimulateDefend = 0;
            str3 = str3 + "too (" + aiTheater2.GetRealX(aiTheater2.triedX).ToString() + "," + (aiTheater2.triedY + aiTheater2.Top).ToString() + ") with " + aiTheater2.MoveList.Counter.ToString();
            tryPassList.AddCoord(aiTheater2.triedX, aiTheater2.triedY, 2);
          }
          str2 = str3 + " => try score for defend = " + aiTheater2.Score.ToString();
        }
        if (!Information.IsNothing((object) Expression))
          aiTheater2 = Expression;
        string str4 = str2 + "\r\nScore for Defend = " + aiTheater2.Score.ToString();
        string str5;
        AITheater theaterUse;
        if (aiTheater2.Score > num6)
        {
          str5 = "\r\nDefend has better score.";
          num6 = aiTheater2.Score;
          theaterUse = aiTheater2;
        }
        else if (aiTheater2.MoveList.Counter > -1 && aiTheater2.MoveList.Move[0].MoveTo.onmap)
        {
          int matrixX = aiTheater2.GetMatrixX(aiTheater2.MoveList.Move[0].MoveTo.x);
          int y = aiTheater2.MoveList.Move[0].MoveTo.y - aiTheater2.Top;
          tempPassList.AddCoord(matrixX, y, 2);
        }
        if (aiTheater1.Score > num6)
        {
          str5 = "\r\nNoMove has better score.";
          int score = aiTheater1.Score;
          theaterUse = aiTheater1;
        }
        s = str4 + str5;
        bool flag = false;
        if (!Information.IsNothing((object) theaterUse) && theaterUse.MoveList.Counter > -1)
        {
          tempPassList = new PassHexList();
          flag = this.ExecuteMoveList(ref theaterUse, ref s);
        }
        if (!flag)
        {
          ++num4;
          s = s + "\r\nNO MOVE MADE. PassListCounter=" + passList.counter.ToString() + ", NoMoveCounter=" + num4.ToString();
        }
        if (num4 > num2)
          break;
      }
      AITheater aiTheater3 = (AITheater) null;
      AITheater aiTheater4 = (AITheater) null;
      AITheater aiTheater5 = (AITheater) null;
      AITheater aiTheater6 = (AITheater) null;
      this.AddLog(s);
      if (doLog)
        this.WriteLog("frontArt_" + front.FrontID.ToString());
      aiTheater6 = (AITheater) null;
      aiTheater4 = (AITheater) null;
      aiTheater5 = (AITheater) null;
      aiTheater3 = (AITheater) null;
      Application.DoEvents();
    }

    public void ResetUnrToAIid(ref AIFront front)
    {
      int counter1 = front.units.counter;
      for (int index = 0; index <= counter1; ++index)
      {
        int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index]);
        front.units.unr[index] = unitByAiid;
      }
      int counter2 = front.artUnits.counter;
      for (int index = 0; index <= counter2; ++index)
      {
        int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(front.artUnits.AIid[index]);
        front.artUnits.unr[index] = unitByAiid;
      }
    }

    public void ExecuteFrontFlakUnits(ref AIFront front, bool doLog)
    {
      this.ResetUnrToAIid(ref front);
      this.map = this.game.Data.MapObj[0];
      this.ClearLog();
      string s = "Moves For Flak Units For Front #" + front.FrontID.ToString();
      PassHexList passList = new PassHexList();
      PassHexList tempPassList = new PassHexList();
      PassHexList passHexList = new PassHexList();
      int num1 = 50;
      int num2 = 3;
      int num3 = 2 + (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus / 7.0);
      if (this.game.Data.Product >= 6)
        num3 += 6;
      int num4 = 0;
      int num5 = num1;
      for (int Iteration = 1; Iteration <= num5; ++Iteration)
      {
        s = s + "\r\n\r\nIteration #" + Iteration.ToString();
        int num6 = -9999;
        AITheater aiTheater1 = new AITheater(this, front, this.masterPlan);
        aiTheater1.Initialize(Iteration);
        aiTheater1.SetScore(doLog);
        s = s + "\r\nScore for NoMove = " + aiTheater1.Score.ToString();
        int num7 = -999999;
        int stimulateDefend = 0;
        PassHexList tryPassList = new PassHexList();
        int num8 = num3;
        AITheater aiTheater2;
        AITheater Expression;
        for (int index = 1; index <= num8; ++index)
        {
          aiTheater2 = aiTheater1.Clone();
          aiTheater2.SetDefendFlakMove(ref passList, ref tempPassList, ref tryPassList, stimulateDefend);
          aiTheater2.ImplementMoveList();
          aiTheater2.SetScore(false);
          s += "\r\n";
          if (aiTheater2.Score > num7)
          {
            num7 = aiTheater2.Score;
            Expression = aiTheater2;
          }
          if (aiTheater2.triedX > -1)
          {
            stimulateDefend = 0;
            s = s + "too (" + aiTheater2.GetRealX(aiTheater2.triedX).ToString() + "," + (aiTheater2.triedY + aiTheater2.Top).ToString() + ") with " + aiTheater2.MoveList.Counter.ToString();
            tryPassList.AddCoord(aiTheater2.triedX, aiTheater2.triedY, 2);
          }
          s = s + " => try score for defend = " + aiTheater2.Score.ToString();
        }
        if (!Information.IsNothing((object) Expression))
          aiTheater2 = Expression;
        s = s + "\r\nScore for Defend = " + aiTheater2.Score.ToString();
        string str;
        AITheater theaterUse;
        if (aiTheater2.Score > num6)
        {
          str = "\r\nDefend has better score.";
          num6 = aiTheater2.Score;
          theaterUse = aiTheater2;
        }
        else if (aiTheater2.MoveList.Counter > -1 && aiTheater2.MoveList.Move[0].MoveTo.onmap)
        {
          int matrixX = aiTheater2.GetMatrixX(aiTheater2.MoveList.Move[0].MoveTo.x);
          int y = aiTheater2.MoveList.Move[0].MoveTo.y - aiTheater2.Top;
          tempPassList.AddCoord(matrixX, y, 2);
        }
        if (aiTheater1.Score > num6)
        {
          str = "\r\nNoMove has better score.";
          int score = aiTheater1.Score;
          theaterUse = aiTheater1;
        }
        s += str;
        bool flag = false;
        if (!Information.IsNothing((object) theaterUse) && theaterUse.MoveList.Counter > -1)
        {
          tempPassList = new PassHexList();
          flag = this.ExecuteMoveList(ref theaterUse, ref s);
        }
        if (!flag)
        {
          ++num4;
          s = s + "\r\nNO MOVE MADE. PassListCounter=" + passList.counter.ToString() + ", NoMoveCounter=" + num4.ToString();
        }
        else
          this.ResetUnrToAIid(ref front);
        if (num4 > num2)
          break;
      }
      AITheater aiTheater3 = (AITheater) null;
      AITheater aiTheater4 = (AITheater) null;
      AITheater aiTheater5 = (AITheater) null;
      AITheater aiTheater6 = (AITheater) null;
      this.AddLog(s);
      if (doLog)
        this.WriteLog("frontFlak_" + front.FrontID.ToString());
      aiTheater6 = (AITheater) null;
      aiTheater4 = (AITheater) null;
      aiTheater5 = (AITheater) null;
      aiTheater3 = (AITheater) null;
      Application.DoEvents();
    }

    public bool ExecuteMoveList(ref AITheater theaterUse, ref string s, int ExtraAp = 0)
    {
      int num1 = 0;
      Coordinate coordinate1;
      for (int counter = theaterUse.MoveList.Counter; counter >= 0; counter += -1)
      {
        if (!Information.IsNothing((object) theaterUse.MoveList.Move[counter].MoveTo))
        {
          if (theaterUse.MoveList.Move[counter].UnitAIid == 2751)
          {
            int num2 = num2;
          }
          coordinate1.x = theaterUse.MoveList.Move[counter].MoveTo.x;
          coordinate1.y = theaterUse.MoveList.Move[counter].MoveTo.y;
          if (theaterUse.MoveList.Move[counter].MoveTo.onmap && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime > -1 && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime != this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Location > -1 | this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].UnitCounter > -1 && this.CustomCalls.TargetRegimeRelationIsActuallyNotWar(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime, true))
          {
            theaterUse.MoveList.Move[counter].MoveTo.onmap = false;
            ++num1;
          }
        }
      }
      if (num1 > theaterUse.MoveList.Counter)
        return false;
      int counter1 = theaterUse.MoveList.Counter;
      bool flag1;
      for (int index = 0; index <= counter1; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (aiMove.MoveTo.x == 0 & aiMove.MoveTo.y == 0 & aiMove.MoveTo.onmap)
          index = index;
        if (!Information.IsNothing((object) aiMove.MoveTo) & aiMove.IsArt && aiMove.MoveTo.onmap)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (unitByAiid > -1)
          {
            int x = this.game.Data.UnitObj[unitByAiid].X;
            int y = this.game.Data.UnitObj[unitByAiid].Y;
            if (unitByAiid > -1)
            {
              if (ExtraAp == 0)
              {
                this.game.HandyFunctionsObj.MakeMovePrediction(unitByAiid, x, y, 0, ismove: true);
                if (this.game.HandyFunctionsObj.GetLowestAp(unitByAiid) >= this.game.EditObj.TempValue[0].Value[aiMove.MoveTo.x, aiMove.MoveTo.y])
                {
                  s = s + "\r\nMOVE " + this.game.Data.UnitObj[unitByAiid].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
                  this.game.ProcessingObj.ExecuteMovement(unitByAiid, x, y, 0, aiMove.MoveTo.x, aiMove.MoveTo.y, 0);
                  flag1 = true;
                }
                else
                  s = s + "\r\nERROR - Not enough AP to MOVE " + this.game.Data.UnitObj[unitByAiid].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
              }
              else
              {
                this.game.HandyFunctionsObj.MakeMovePrediction(unitByAiid, x, y, 0, increaseap: ExtraAp, ismove: true);
                coordinate1.x = aiMove.MoveTo.x;
                coordinate1.y = aiMove.MoveTo.y;
                coordinate1.onmap = true;
                while (coordinate1.onmap & !flag1)
                {
                  if (this.game.HandyFunctionsObj.GetLowestAp(unitByAiid) >= this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y])
                  {
                    s = s + "\r\nMOVE " + this.game.Data.UnitObj[unitByAiid].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
                    this.game.ProcessingObj.ExecuteMovement(unitByAiid, x, y, 0, aiMove.MoveTo.x, aiMove.MoveTo.y, 0);
                    flag1 = true;
                  }
                  else
                    coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                  if (coordinate1.x == x & coordinate1.y == y)
                    coordinate1.onmap = false;
                }
                if (!flag1)
                  s = s + "\r\nERROR - Not enough AP to MOVE towards " + this.game.Data.UnitObj[unitByAiid].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
              }
            }
          }
        }
      }
      this.game.EditObj.TempUnitList = new UnitList();
      int counter2 = theaterUse.MoveList.Counter;
      int x1;
      int y1;
      Coordinate coordinate2;
      for (int index = 0; index <= counter2; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (!Information.IsNothing((object) aiMove.AttackOn) & aiMove.IsArt && aiMove.AttackOn.onmap)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (unitByAiid > -1)
          {
            x1 = this.game.Data.UnitObj[unitByAiid].X;
            y1 = this.game.Data.UnitObj[unitByAiid].Y;
            coordinate2.x = aiMove.AttackOn.x;
            coordinate2.y = aiMove.AttackOn.y;
            if (this.game.HandyFunctionsObj.GetLowestAp(unitByAiid) >= 10 & this.game.HandyFunctionsObj.CanDoArtAttack(unitByAiid, coordinate2, false))
              this.game.EditObj.TempUnitList.add(unitByAiid);
            else
              s = s + "\r\nERROR - " + this.game.Data.UnitObj[unitByAiid].Name + " could not be added to artillery attack.";
          }
        }
      }
      if (this.game.EditObj.TempUnitList.counter > -1 & coordinate2.x > -1)
      {
        if (this.GetRegime(this.map.HexObj[coordinate2.x, coordinate2.y].Regime) == this.GetGameDataTurn())
        {
          s += "\r\n CANCEL ARTILLERY ATTACK ON OWN HEX!!!";
        }
        else
        {
          s = s + "\r\nARTILLERY ATTACK ON " + Conversion.Str((object) coordinate2.x) + "," + Conversion.Str((object) coordinate2.y);
          s += " ; PARTICIPANTS: ";
          int counter3 = this.game.EditObj.TempUnitList.counter;
          for (int index = 0; index <= counter3; ++index)
          {
            if (index > 0)
              s += ", ";
            s = s + "\r\n" + this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index]].Name;
          }
          this.game.TempCombat = new CombatClass(this.game);
          this.game.TempCombat.Init(coordinate2, 1, this.game.EditObj.TempUnitList, 11);
          this.game.TempCombat.DoBattle();
          this.game.TempCombat.EndBattle();
          flag1 = true;
        }
      }
      this.game.EditObj.TempUnitList = new UnitList();
      int counter4 = theaterUse.MoveList.Counter;
      for (int index = 0; index <= counter4; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (!Information.IsNothing((object) aiMove.AttackOn) & aiMove.IsAir & !aiMove.IsTransportAir && aiMove.AttackOn.onmap)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (unitByAiid > -1)
          {
            x1 = this.game.Data.UnitObj[unitByAiid].X;
            y1 = this.game.Data.UnitObj[unitByAiid].Y;
            coordinate2.x = aiMove.AttackOn.x;
            coordinate2.y = aiMove.AttackOn.y;
            if (this.game.HandyFunctionsObj.GetLowestAp(unitByAiid) >= 10 & this.game.HandyFunctionsObj.CanDoAirStrike(unitByAiid, coordinate2))
              this.game.EditObj.TempUnitList.add(unitByAiid);
            else
              s = s + "\r\nERROR - " + this.game.Data.UnitObj[unitByAiid].Name + " could not be added to air attack.";
          }
        }
      }
      if (this.game.EditObj.TempUnitList.counter > -1 & coordinate2.x > -1)
      {
        if (this.GetRegime(this.map.HexObj[coordinate2.x, coordinate2.y].Regime) == this.GetGameDataTurn())
        {
          s += "\r\n CANCEL AIR ATTACK ON OWN HEX!!!";
        }
        else
        {
          s = s + "\r\nAIR ATTACK ON " + Conversion.Str((object) coordinate2.x) + "," + Conversion.Str((object) coordinate2.y);
          s += " ; PARTICIPANTS: ";
          int counter5 = this.game.EditObj.TempUnitList.counter;
          for (int index = 0; index <= counter5; ++index)
          {
            if (index > 0)
              s += ", ";
            s = s + "\r\n" + this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index]].Name;
          }
          this.game.TempCombat = new CombatClass(this.game);
          this.game.TempCombat.Init(coordinate2, 1, this.game.EditObj.TempUnitList, 14);
          this.game.TempCombat.DoBattle();
          this.game.TempCombat.EndBattle();
          flag1 = true;
        }
      }
      int counter6 = theaterUse.MoveList.Counter;
      for (int index = 0; index <= counter6; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (!Information.IsNothing((object) aiMove.MoveTo) & !aiMove.IsArt && aiMove.MoveTo.onmap)
        {
          if (aiMove.MoveTo.x == 0 & aiMove.MoveTo.y == 0)
            aiMove = aiMove;
          int unr = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (Operators.CompareString(this.game.Data.UnitObj[unr].Name, "2nd Buranfrost Rebel Unit", false) == 0)
            unr = unr;
          if (unr > -1)
          {
            int x2 = this.game.Data.UnitObj[unr].X;
            int y2 = this.game.Data.UnitObj[unr].Y;
            if (unr > -1)
            {
              if (this.game.Data.UnitObj[unr].X == aiMove.MoveTo.x & this.game.Data.UnitObj[unr].Y == aiMove.MoveTo.y)
                unr = unr;
              if (ExtraAp == 0 & !(this.game.Data.UnitObj[unr].X == aiMove.MoveTo.x & this.game.Data.UnitObj[unr].Y == aiMove.MoveTo.y))
              {
                this.game.HandyFunctionsObj.MakeMovePrediction(unr, x2, y2, 0, increaseap: 20, ismove: true);
                int num3 = 0;
                while (num3 >= 0 & num3 < 9)
                {
                  if (this.game.HandyFunctionsObj.GetLowestAp(unr) >= this.game.EditObj.TempValue[0].Value[aiMove.MoveTo.x, aiMove.MoveTo.y])
                  {
                    s = s + "\r\nMOVE " + this.game.Data.UnitObj[unr].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
                    if (x2 == aiMove.MoveTo.x & y2 == aiMove.MoveTo.y)
                    {
                      flag1 = true;
                      this.game.HandyFunctionsObj.SetUnitAPToZero(unr);
                    }
                    else
                    {
                      flag1 = true;
                      this.game.ProcessingObj.ExecuteMovement(unr, x2, y2, 0, aiMove.MoveTo.x, aiMove.MoveTo.y, 0);
                    }
                    num3 = -1;
                  }
                  else
                  {
                    s = s + "\r\nTEMP ERROR - Not enough AP to MOVE " + this.game.Data.UnitObj[unr].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
                    ++num3;
                    int x3 = this.game.EditObj.TempCameFrom[0].Value[aiMove.MoveTo.x, aiMove.MoveTo.y].x;
                    int y3 = this.game.EditObj.TempCameFrom[0].Value[aiMove.MoveTo.x, aiMove.MoveTo.y].y;
                    bool onmap = this.game.EditObj.TempCameFrom[0].Value[aiMove.MoveTo.x, aiMove.MoveTo.y].onmap;
                    aiMove.MoveTo.x = x3;
                    aiMove.MoveTo.y = y3;
                    aiMove.MoveTo.onmap = onmap;
                    if (num3 >= 9)
                      s = s + "\r\nFINAL ERROR - Not enough AP to MOVE " + this.game.Data.UnitObj[unr].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
                  }
                }
              }
              else if (!(this.game.Data.UnitObj[unr].X == aiMove.MoveTo.x & this.game.Data.UnitObj[unr].Y == aiMove.MoveTo.y))
              {
                this.game.HandyFunctionsObj.MakeMovePrediction(unr, x2, y2, 0, increaseap: ExtraAp, ismove: true);
                coordinate1.x = aiMove.MoveTo.x;
                coordinate1.y = aiMove.MoveTo.y;
                coordinate1.onmap = true;
                while (coordinate1.onmap & !flag1)
                {
                  if (this.game.HandyFunctionsObj.GetLowestAp(unr) >= this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y])
                  {
                    s = s + "\r\nMOVE " + this.game.Data.UnitObj[unr].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
                    this.game.ProcessingObj.ExecuteMovement(unr, x2, y2, 0, aiMove.MoveTo.x, aiMove.MoveTo.y, 0);
                    flag1 = true;
                  }
                  else
                    coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                  if (coordinate1.x == x2 & coordinate1.y == y2)
                    coordinate1.onmap = false;
                }
                if (!flag1)
                  s = s + "\r\nERROR - Not enough AP to MOVE towards " + this.game.Data.UnitObj[unr].Name + " to " + aiMove.MoveTo.x.ToString() + "," + aiMove.MoveTo.y.ToString();
              }
            }
          }
        }
      }
      bool flag2 = false;
      this.game.EditObj.TempUnitList = new UnitList();
      int counter7 = theaterUse.MoveList.Counter;
      for (int index = 0; index <= counter7; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (!Information.IsNothing((object) aiMove.AttackOn) & !aiMove.IsArt & !aiMove.IsAir && aiMove.AttackOn.onmap)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (unitByAiid > -1)
          {
            int x4 = this.game.Data.UnitObj[unitByAiid].X;
            int y4 = this.game.Data.UnitObj[unitByAiid].Y;
            coordinate2.x = aiMove.AttackOn.x;
            coordinate2.y = aiMove.AttackOn.y;
            if (this.game.HandyFunctionsObj.GetLowestAp(unitByAiid) >= this.game.HandyFunctionsObj.MoveApCostPreview(unitByAiid, x4, y4, x4, y4, 0, aiMove.AttackOn.x, aiMove.AttackOn.y, 0, true).x)
            {
              this.game.EditObj.TempUnitList.add(unitByAiid);
              if (this.game.HandyFunctionsObj.HasUnitNavySF(unitByAiid))
                flag2 = true;
            }
            else
              s = s + "\r\nERROR - " + this.game.Data.UnitObj[unitByAiid].Name + " could not be added to attack.";
          }
        }
      }
      if (this.game.EditObj.TempUnitList.counter > -1 & coordinate2.x > -1)
      {
        if (this.GetRegime(this.map.HexObj[coordinate2.x, coordinate2.y].Regime) == this.GetGameDataTurn())
        {
          s += "\r\n CANCEL ATTACK ON OWN HEX!!!";
        }
        else
        {
          UnitList unitList = new UnitList();
          int counter8 = this.game.EditObj.TempUnitList.counter;
          for (int index = 0; index <= counter8; ++index)
            unitList.add(this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index]].AIid);
          s += this.BeforeAttackPlayOfficerHandCard(ref this.game.EditObj.TempUnitList);
          this.game.EditObj.TempUnitList = new UnitList();
          int counter9 = unitList.counter;
          for (int index = 0; index <= counter9; ++index)
            this.game.EditObj.TempUnitList.add(this.game.HandyFunctionsObj.GetUnitByAIid(unitList.unr[index]));
          s = s + "\r\nATTACK ON " + Conversion.Str((object) coordinate2.x) + "," + Conversion.Str((object) coordinate2.y);
          s += " ; PARTICIPANTS: ";
          int counter10 = this.game.EditObj.TempUnitList.counter;
          for (int index = 0; index <= counter10; ++index)
          {
            if (index > 0)
              s += ", ";
            s = s + "\r\n" + this.game.Data.UnitObj[this.game.EditObj.TempUnitList.unr[index]].Name;
          }
          this.game.TempCombat = new CombatClass(this.game);
          if (this.game.Data.LandscapeTypeObj[this.map.HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea)
            this.game.TempCombat.Init(coordinate2, 1, this.game.EditObj.TempUnitList, 12);
          else if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea & flag2)
            this.game.TempCombat.Init(coordinate2, 1, this.game.EditObj.TempUnitList, 12);
          else
            this.game.TempCombat.Init(coordinate2, 1, this.game.EditObj.TempUnitList, 2);
          this.game.TempCombat.DoBattle();
          this.game.TempCombat.EndBattle();
          flag1 = true;
        }
      }
      int counter11 = theaterUse.MoveList.Counter;
      for (int index = 0; index <= counter11; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (!Information.IsNothing((object) aiMove.AttackOn) & aiMove.IsAir & aiMove.IsTransportAir && aiMove.AttackOn.onmap)
        {
          this.game.EditObj.TempUnitList = new UnitList();
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (unitByAiid > -1 && this.game.Data.UnitObj[unitByAiid].HQ > -1)
          {
            x1 = this.game.Data.UnitObj[unitByAiid].X;
            y1 = this.game.Data.UnitObj[unitByAiid].Y;
            this.game.EditObj.OrderType = 40;
            coordinate2.x = aiMove.AttackOn.x;
            coordinate2.y = aiMove.AttackOn.y;
            this.game.EditObj.TempUnitList.add(unitByAiid);
            int supply = this.game.Data.UnitObj[this.game.Data.UnitObj[unitByAiid].HQ].Supply;
            int num4 = (int) Math.Round((double) ((float) this.game.HandyFunctionsObj.GetCarryCapPts(unitByAiid, 2) / this.VAR_SUPPLY_WEIGHT));
            if (num4 > supply)
              num4 = supply;
            if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].UnitCounter > -1)
            {
              int unit = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].UnitList[0];
              int num5 = this.game.HandyFunctionsObj.AirSupplyNeeded(this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, 0);
              int val1 = num4;
              int val2 = num5;
              int unitSelected = this.game.EditObj.UnitSelected;
              this.game.EditObj.AirSupplyPts = Math.Min(val1, val2);
              this.game.EditObj.AirSupplyHq = this.game.Data.UnitObj[unitByAiid].HQ;
              this.game.EditObj.TargetX = coordinate2.x;
              this.game.EditObj.TargetY = coordinate2.y;
              this.game.EditObj.AirSupplyCarry = this.game.HandyFunctionsObj.GetCarryCapPts(unitByAiid, 2);
              coordinate2.onmap = true;
              this.game.TempCombat = new CombatClass(this.game);
              this.game.TempCombat.Init(coordinate2, 1, this.game.EditObj.TempUnitList, this.game.EditObj.OrderType);
              this.game.TempCombat.DoBattle();
              this.game.TempCombat.EndBattle();
              flag1 = true;
              this.game.EditObj.OrderType = 0;
            }
          }
        }
      }
      this.game.EditObj.TempUnitList = new UnitList();
      int counter12 = theaterUse.MoveList.Counter;
      for (int index = 0; index <= counter12; ++index)
      {
        AIMove aiMove = theaterUse.MoveList.Move[index];
        if (aiMove.BridgeToo > -1)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          if (unitByAiid > -1)
          {
            int x5 = this.game.Data.UnitObj[unitByAiid].X;
            int y5 = this.game.Data.UnitObj[unitByAiid].Y;
            coordinate2 = this.game.HandyFunctionsObj.HexNeighbour(x5, y5, 0, aiMove.BridgeToo + 1);
            if (coordinate2.onmap)
            {
              this.game.HandyFunctionsObj.InfraHexHighlight(x5, y5, 0, unitByAiid);
              if (this.game.EditObj.TempValue[0].Value[coordinate2.x, coordinate2.y] <= this.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
              {
                this.game.ProcessingObj.BuildInfra(unitByAiid, x5, y5, 0, aiMove.BridgeToo);
                s = s + "\r\nBuild bridge from " + x5.ToString() + "," + y5.ToString() + " towards direction " + aiMove.BridgeToo.ToString();
              }
              else
                s += "\r\nNo AP enough or other problem to actually build bridge.";
            }
          }
        }
      }
      return flag1;
    }

    public string BeforeAttackPlayOfficerHandCard(ref UnitList tempUnitList)
    {
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int counter1 = tempUnitList.counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int unr = tempUnitList.unr[index1];
        int historical = this.game.Data.UnitObj[unr].Historical;
        if (simpleList1.FindNr(historical) > -1)
        {
          int[] weight = simpleList1.Weight;
          int[] numArray = weight;
          int nr = simpleList1.FindNr(historical);
          int index2 = nr;
          int num = weight[nr] + (int) Math.Round((double) this.game.Data.UnitObj[unr].TempUnitPower * ((double) this.game.HandyFunctionsObj.Gethqpow(unr) / 100.0));
          numArray[index2] = num;
        }
        else
          simpleList1.Add(historical, this.game.Data.UnitObj[unr].TempUnitPower);
      }
      simpleList1.ReverseSort();
      string str;
      if (simpleList1.Counter > -1)
      {
        int counter2 = simpleList1.Counter;
        for (int index3 = 0; index3 <= counter2; ++index3)
        {
          bool flag;
          if (!flag)
          {
            int num = simpleList1.Id[index3];
            int unr = -1;
            int counter3 = tempUnitList.counter;
            for (int index4 = 0; index4 <= counter3; ++index4)
            {
              if (this.game.Data.UnitObj[tempUnitList.unr[index4]].Historical == num)
              {
                unr = tempUnitList.unr[index4];
                break;
              }
            }
            if (unr > -1)
            {
              int hq1 = this.game.Data.UnitObj[unr].HQ;
              if (hq1 > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq1].Historical].Type == 5)
              {
                int handCardCounter = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq1].Historical].HandCardCounter;
                for (int index5 = 0; index5 <= handCardCounter; ++index5)
                {
                  int cardnr = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq1].Historical].HandCard[index5];
                  int historical = this.game.Data.UnitObj[hq1].Historical;
                  if ((this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[cardnr].PPCost | this.game.Data.ActionCardObj[cardnr].PPCost == 0) & (this.game.Data.ActionCardObj[cardnr].HisVarCostType == -1 | this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.game.Data.ActionCardObj[cardnr].HisVarCostType) >= this.game.Data.ActionCardObj[cardnr].HisVarCostQty) && this.game.HandyFunctionsObj.Gethqpow(unr) >= 75 && this.game.Data.ActionCardObj[cardnr].AILabel >= 1 & !flag)
                  {
                    if (this.game.Data.ActionCardObj[cardnr].PreExecuteEvent > -1)
                    {
                      this.game.EditObj.UnitSelected = hq1;
                      this.game.ProcessingObj.PlayCardPreEvent(cardnr);
                    }
                    if (this.game.Data.UnitObj[unr].TempUnitSelectable)
                    {
                      str = str + "\r\n" + "PLAYED CORPS HQ CARD!!! " + this.game.Data.ActionCardObj[cardnr].Title + "  target hex selected = " + this.game.Data.UnitObj[unr].Name;
                      this.game.EditObj.UnitSelected = unr;
                      this.game.ProcessingObj.PlayCardByUnit(hq1, cardnr);
                      flag = true;
                      break;
                    }
                  }
                }
              }
              if (!flag)
              {
                int hq2 = this.game.Data.UnitObj[unr].HQ;
                if (hq2 > -1)
                {
                  int hq3 = this.game.Data.UnitObj[hq2].HQ;
                  if (hq3 > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq3].Historical].Type == 6)
                  {
                    int handCardCounter = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq3].Historical].HandCardCounter;
                    for (int index6 = 0; index6 <= handCardCounter; ++index6)
                    {
                      int cardnr = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq3].Historical].HandCard[index6];
                      int historical = this.game.Data.UnitObj[hq3].Historical;
                      if ((this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[cardnr].PPCost | this.game.Data.ActionCardObj[cardnr].PPCost == 0) & (this.game.Data.ActionCardObj[cardnr].HisVarCostType == -1 | this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.game.Data.ActionCardObj[cardnr].HisVarCostType) >= this.game.Data.ActionCardObj[cardnr].HisVarCostQty) && this.game.Data.ActionCardObj[cardnr].AILabel == 1 & !flag)
                      {
                        if (this.game.Data.ActionCardObj[cardnr].PreExecuteEvent > -1)
                        {
                          this.game.EditObj.UnitSelected = hq3;
                          this.game.ProcessingObj.PlayCardPreEvent(cardnr);
                        }
                        if (this.game.Data.UnitObj[unr].TempUnitSelectable)
                        {
                          str = str + "\r\n" + "PLAYED ARMY HQ CARD!!! " + this.game.Data.ActionCardObj[cardnr].Title + "  target hex selected = " + this.game.Data.UnitObj[unr].Name;
                          this.game.EditObj.UnitSelected = unr;
                          this.game.ProcessingObj.PlayCardByUnit(hq3, cardnr);
                          flag = true;
                          break;
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
      return str;
    }

    public void ExecuteStrategicTransfers(bool doLog, bool Early)
    {
      if (!this.game.DC2AIObj.CustomCalls.CustomIsMajor())
        return;
      AIMatrix ownerMatrix = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      AIMatrix aiMatrix1 = this.frontMatrix.Clone();
      aiMatrix1.ExpandValueForSameRegime();
      AIMatrix aiMatrix2 = ownerMatrix.Clone();
      aiMatrix2.RemoveValuesByMask(ownerMatrix, 1);
      aiMatrix2.ExpandAndAddValueForAnyRegime(19);
      aiMatrix2.SetAllValuesSubtractWith(2);
      this.ClearLog();
      string s = ".. SE .. Moves For Strategic Transfer";
      SimpleList simpleList = new SimpleList();
      int counter1 = this.masterPlan.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront = this.masterPlan.Front[index1];
        if (Early)
        {
          if (aiFront.FrontType == 1)
          {
            s = s + "\r\nfrontline " + aiFront.FrontID.ToString() + " is being considered.";
            int counter2 = aiFront.units.counter;
            for (int index2 = 0; index2 <= counter2; ++index2)
            {
              int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index2]);
              if (aiMatrix1.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] != aiFront.FrontID && this.game.HandyFunctionsObj.HasHexRoad(this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y, 0))
              {
                DC2AIClass tai = this;
                AIMatrix aiMatrix3 = new AIMatrix(ref tai);
                aiMatrix3.SetAllValuesTo(9999);
                aiMatrix3.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] = 0;
                aiMatrix3.ExpandAsSimplifiedSupplyRouteMatrix(9, ref ownerMatrix, 1, nonRoadCostMod: 9999f);
                int tdata1 = -1;
                int tdata2 = -1;
                int num = 900;
                int mapWidth = this.map.MapWidth;
                for (int x1 = 0; x1 <= mapWidth; ++x1)
                {
                  int mapHeight = this.map.MapHeight;
                  for (int y1 = 0; y1 <= mapHeight; ++y1)
                  {
                    if (aiMatrix3.Value[x1, y1] < 900 && aiMatrix1.Value[x1, y1] == aiFront.FrontID && this.game.HandyFunctionsObj.Distance(x1, y1, 0, this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y, 0) > 8)
                    {
                      if (aiMatrix2.Value[x1, y1] < num & aiMatrix2.Value[x1, y1] > 1)
                      {
                        tdata1 = x1;
                        tdata2 = y1;
                        num = aiMatrix2.Value[x1, y1];
                      }
                      else if (aiMatrix3.Value[x1, y1] < num)
                      {
                        tdata1 = x1;
                        tdata2 = y1;
                        num = aiMatrix3.Value[x1, y1];
                      }
                    }
                  }
                }
                if (tdata1 > -1)
                {
                  int tweight = (int) Math.Round((double) (20 + aiFront.Importance * 100) / (double) Math.Max(1, (int) Math.Round((double) aiMatrix3.Value[tdata1, tdata2] / 30.0)));
                  s = s + "\r\nunit '" + this.game.Data.UnitObj[unitByAiid].Name + "' gets score = " + tweight.ToString() + " to = " + tdata1.ToString() + "," + tdata2.ToString() + " for destination ";
                  simpleList.Add(unitByAiid, tweight, tdata1, tdata2);
                }
              }
            }
          }
        }
        else if (aiFront.FrontType == 2 && aiFront.TargetFrontID > 0)
        {
          s = s + "\r\nfront reserve " + aiFront.FrontID.ToString() + " is being considered.";
          int counter3 = aiFront.units.counter;
          for (int index3 = 0; index3 <= counter3; ++index3)
          {
            int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index3]);
            if (unitByAiid > -1 && aiMatrix1.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] != aiFront.TargetFrontID && this.game.HandyFunctionsObj.HasHexRoad(this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y, 0))
            {
              DC2AIClass tai = this;
              AIMatrix aiMatrix4 = new AIMatrix(ref tai);
              aiMatrix4.SetAllValuesTo(9999);
              aiMatrix4.Value[this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y] = 0;
              aiMatrix4.ExpandAsSimplifiedSupplyRouteMatrix(9, ref ownerMatrix, 1, nonRoadCostMod: 9999f);
              int tdata1 = -1;
              int tdata2 = -1;
              int num = 900;
              int mapWidth = this.map.MapWidth;
              for (int x1 = 0; x1 <= mapWidth; ++x1)
              {
                int mapHeight = this.map.MapHeight;
                for (int y1 = 0; y1 <= mapHeight; ++y1)
                {
                  if (aiMatrix4.Value[x1, y1] < 900 && aiMatrix1.Value[x1, y1] == aiFront.TargetFrontID && this.game.HandyFunctionsObj.Distance(x1, y1, 0, this.game.Data.UnitObj[unitByAiid].X, this.game.Data.UnitObj[unitByAiid].Y, 0) > 8)
                  {
                    if (aiMatrix2.Value[x1, y1] < num & aiMatrix2.Value[x1, y1] > 1)
                    {
                      tdata1 = x1;
                      tdata2 = y1;
                      num = aiMatrix2.Value[x1, y1];
                    }
                    else if (aiMatrix4.Value[x1, y1] < num)
                    {
                      tdata1 = x1;
                      tdata2 = y1;
                      num = aiMatrix4.Value[x1, y1];
                    }
                  }
                }
              }
              if (tdata1 > -1)
              {
                int tweight = (int) Math.Round(20.0 + (double) (aiFront.Importance * 100) / (double) Math.Max(1, (int) Math.Round((double) aiMatrix4.Value[tdata1, tdata2] / 30.0)));
                s = s + "\r\nunit '" + this.game.Data.UnitObj[unitByAiid].Name + "' gets score = " + tweight.ToString() + " to = " + tdata1.ToString() + "," + tdata2.ToString() + " for destination ";
                simpleList.Add(unitByAiid, tweight, tdata1, tdata2);
              }
            }
          }
        }
      }
      simpleList.ReverseSort();
      int num1 = 1;
      int num2 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].X > -1)
          ++num2;
      }
      num1 = this.game.Data.RegimeObj[this.game.Data.Turn].AIHelpCombat > 0 ? (this.game.Data.RegimeObj[this.game.Data.Turn].AIHelpCombat > 10 ? (this.game.Data.RegimeObj[this.game.Data.Turn].AIHelpCombat > 20 ? Math.Max(8, (int) Math.Round((double) num2 * 0.2)) : Math.Max(6, (int) Math.Round((double) num2 * 0.15))) : Math.Max(4, (int) Math.Round((double) num2 * 0.1))) : Math.Max(2, (int) Math.Round((double) num2 * 0.05));
      simpleList.Sort();
      if (simpleList.Counter > -1)
      {
        s += "\r\n";
        int num3 = 0;
        for (int counter4 = simpleList.Counter; counter4 >= 0; counter4 += -1)
        {
          if (simpleList.Data5[counter4] == 0)
          {
            int num4 = simpleList.Id[counter4];
            int counter5 = simpleList.Counter;
            for (int index = 0; index <= counter5; ++index)
            {
              int unrS = simpleList.Id[index];
              int tarx = simpleList.Data1[index];
              int tary = simpleList.Data2[index];
              s = s + "\r\nSTR.TRANSFERRING unit '" + this.game.Data.UnitObj[unrS].Name + "' to = " + tarx.ToString() + "," + tary.ToString() + ".";
              this.game.ProcessingObj.LIS_DoStrategicTransfer(unrS, tarx, tary, 0);
              simpleList.Data5[index] = 1;
            }
          }
          if (num3 > 9)
            break;
        }
      }
      this.AddLog(s);
      if (!doLog)
        return;
      if (Early)
        this.WriteLog("022_EARLY_strategic_transfer_early");
      else
        this.WriteLog("022_LATE_strategic_transfer_late");
    }

    private int product { get; set; }

    public void InitFrontlines(bool DebugOverrule)
    {
      bool flag1 = false;
      if (DebugOverrule)
        flag1 = true;
      bool flag2 = false;
      if (this.VAR_DEBUG_ON)
        flag2 = true;
      if ((double) this.game.Data.RuleVar[455] > 0.0 & this.game.Data.Product >= 6)
        this.game.HandyFunctionsObj.MakeFuzzyOwner(true, false, this.game.Data.Turn);
      DC2AIClass tai = this;
      this.VAR_MATRIX_SUPERFRONT = new AIMatrix(ref tai, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      tai = this;
      this.VAR_MATRIX_ZONES = new AIMatrix(ref tai, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      if (this.VAR_USE_SUPERFRONTS)
      {
        this.game.EventRelatedObj.ExecClearMatrix(this.VAR_SUPERFRONT_AREASLOT, 0, 0, 0, "");
        if (this.VAR_SUPERFRONT_EVENT > 0)
          this.game.EventRelatedObj.DoCheckSpecificEvent(this.VAR_SUPERFRONT_EVENT);
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
            this.VAR_MATRIX_SUPERFRONT.Value[index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index2].AreaCode[this.VAR_SUPERFRONT_AREASLOT];
        }
      }
      tai = this;
      this.VAR_MATRIX_RETREAT = new AIMatrix(ref tai, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      this.game.EventRelatedObj.ExecClearMatrix(this.VAR_ZONES_AREASLOT, 0, 0, 0, "");
      if (this.VAR_RETREAT_EVENT > 0)
      {
        this.game.EventRelatedObj.DoCheckSpecificEvent(this.VAR_RETREAT_EVENT);
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
            this.VAR_MATRIX_RETREAT.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].AreaCode[this.VAR_ZONES_AREASLOT];
        }
      }
      else
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index5 = 0; index5 <= mapWidth; ++index5)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
            this.VAR_MATRIX_RETREAT.Value[index5, index6] = 100;
        }
      }
      tai = this;
      this.VAR_MATRIX_STRENGTH = new AIMatrix(ref tai, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      this.game.EventRelatedObj.ExecClearMatrix(this.VAR_ZONES_AREASLOT, 0, 0, 0, "");
      if (this.VAR_STRENGTH_EVENT > 0)
      {
        this.game.EventRelatedObj.DoCheckSpecificEvent(this.VAR_STRENGTH_EVENT);
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index7 = 0; index7 <= mapWidth; ++index7)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index8 = 0; index8 <= mapHeight; ++index8)
            this.VAR_MATRIX_STRENGTH.Value[index7, index8] = this.game.Data.MapObj[0].HexObj[index7, index8].AreaCode[this.VAR_ZONES_AREASLOT];
        }
      }
      else
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index9 = 0; index9 <= mapWidth; ++index9)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index10 = 0; index10 <= mapHeight; ++index10)
            this.VAR_MATRIX_STRENGTH.Value[index9, index10] = 100;
        }
      }
      if (this.VAR_ZONES_TYPE > 0)
      {
        this.game.EventRelatedObj.ExecClearMatrix(this.VAR_ZONES_AREASLOT, 0, 0, 0, "");
        if (this.VAR_ZONES_EVENT > 0)
          this.game.EventRelatedObj.DoCheckSpecificEvent(this.VAR_ZONES_EVENT);
        this.VAR_ZONES_TYPE = (int) Math.Round((double) this.game.Data.RuleVar[963]);
        this.AddLog("VAR_ZONES_TYPE is reset by event too " + this.VAR_ZONES_TYPE.ToString());
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index11 = 0; index11 <= mapWidth; ++index11)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index12 = 0; index12 <= mapHeight; ++index12)
          {
            if (this.game.Data.MapObj[0].HexObj[index11, index12].AreaCode[this.VAR_ZONES_AREASLOT] > 0)
              this.VAR_MATRIX_ZONES.Value[index11, index12] = this.game.Data.MapObj[0].HexObj[index11, index12].AreaCode[this.VAR_ZONES_AREASLOT];
          }
        }
      }
      this.ClearLog();
      if (this.CustomCalls.HasCustumCalls())
        this.CustomCalls.CustomRuleInitFrontlines_ResetMatrixes();
      this.ClearLog();
      this.MakeFriendlySupplyMatrix();
      this.map = this.game.Data.MapObj[0];
      AIMatrix ownerMatrix = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      AIMatrix aiMatrix1 = this.SetMatrixEnemyUnitsAndRoadHexes();
      aiMatrix1.ExpandValueForSameRegime();
      this.MakeEnemySupplyMatrix();
      AIMatrix mask1 = this.enemySupplyMatrix.Clone();
      mask1.SetAllValuesHigherThenXTo(this.VAR_SUPPLY_50PERCENT_RANGE, 9999);
      mask1.SetAllValuesNotValueXTo(1, 9999);
      mask1.SetValueXToValueY(9999, 0);
      mask1.ExpandValueForAnyRegime(2);
      AIMatrix mask2 = this.SetMatrixUnitPower(false, true);
      mask2.SetAllValuesHigherThenXTo(0, 1);
      mask2.ExpandValueForAnyRegime(3);
      mask2.SetAllValuesHigherThenXTo(0, 1);
      tai = this;
      AIMatrix mask3 = new AIMatrix(ref tai);
      int mapWidth1 = this.map.MapWidth;
      for (int index13 = 0; index13 <= mapWidth1; ++index13)
      {
        int mapHeight = this.map.MapHeight;
        for (int index14 = 0; index14 <= mapHeight; ++index14)
        {
          mask3.Value[index13, index14] = 0;
          if (this.game.Data.Product == 4 & this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index13, index14] > 0 | this.map.HexObj[index13, index14].VP > 0 && ownerMatrix.Value[index13, index14] == 2)
            mask3.Value[index13, index14] = 1;
        }
      }
      mask3.ExpandValueForAnyRegime(3);
      mask1.AddValueByMask(mask2, 1, 1);
      mask1.AddValueByMask(mask3, 1, 1);
      tai = this;
      AIMatrix tminstrength = new AIMatrix(ref tai);
      int num1;
      if (this.game.Data.Product >= 6)
      {
        int mapWidth2 = this.map.MapWidth;
        for (int index15 = 0; index15 <= mapWidth2; ++index15)
        {
          int mapHeight = this.map.MapHeight;
          for (int index16 = 0; index16 <= mapHeight; ++index16)
          {
            tminstrength.Value[index15, index16] = 0;
            if (this.game.Data.MapObj[0].HexObj[index15, index16].Regime == this.game.Data.Turn)
            {
              int index17 = 0;
              do
              {
                Coordinate coordinate = this.TempHexNeighbour[index15, index16, index17];
                if (coordinate.onmap)
                {
                  num1 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime;
                  if (num1 > -1 & num1 != this.game.Data.Turn)
                    tminstrength.Value[index15, index16] = 2;
                }
                ++index17;
              }
              while (index17 <= 5);
            }
            else if (this.game.Data.MapObj[0].HexObj[index15, index16].Regime > -1 && aiMatrix1.Value[index15, index16] < 1)
              aiMatrix1.Value[index15, index16] = 1;
          }
        }
      }
      int mapWidth3 = this.map.MapWidth;
      for (int x = 0; x <= mapWidth3; ++x)
      {
        int mapHeight = this.map.MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
            mask1.Value[x, y] = 1;
        }
      }
      this.SetMatrixUnitPower(false);
      AIMatrix aiMatrix2 = aiMatrix1.DetectAndMakeEdgeMatrix(false);
      aiMatrix2.RemoveValuesByMask(ownerMatrix, 0);
      aiMatrix2.RemoveValuesByMask(ownerMatrix, 3);
      aiMatrix2.RemoveValuesByLandscapeAIBlock(0);
      aiMatrix2.RemoveValuesByMask(mask1, 0);
      AIMatrix friendlyPower = this.SetMatrixUnitPower(true);
      if (this.CustomCalls.CustomDoStrategicIterations())
        friendlyPower = friendlyPower.AverageValuesForAnyRegime(this.VAR_FRONTLINE_DEPTH);
      AIMatrix enemyPower = this.SetMatrixUnitPower(false);
      if (this.CustomCalls.CustomDoStrategicIterations())
        enemyPower = enemyPower.AverageValuesForAnyRegime(this.VAR_FRONTLINE_DEPTH);
      AIMatrix aiMatrix3 = this.SetMatrixUnitPower(false);
      AIMatrix mask4 = aiMatrix2.Clone();
      mask4.ExpandSpecificValueForAnyRegime(1, 2);
      aiMatrix3.RemoveValuesByMask(mask4, 1);
      AIMatrix addvalue1 = aiMatrix3.AverageValuesForSameRegime(4, ownerMatrix);
      enemyPower.AddValue(addvalue1, 1);
      AIMatrix addvalue2 = this.SetMatrixUnitPower(false);
      addvalue2.RemoveValuesByMask(mask4, 1);
      if (this.CustomCalls.CustomDoStrategicIterations())
        addvalue2 = addvalue2.AverageValuesForAnyRegime(6);
      enemyPower.AddValue(addvalue2, 1);
      AIMatrix aiMatrix4 = this.InitFrontlinesStrength(aiMatrix2, friendlyPower, enemyPower, ownerMatrix, tminstrength);
      if (this.game.Data.Turn == 7)
        num1 = num1;
      AIMatrix tstrength = aiMatrix4.AverageValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, ownerMatrix, true).AverageValuesForSameRegime(1, ownerMatrix, true);
      tstrength.RemoveValuesByMask(aiMatrix2, 0, 1000000);
      AIMatrix strength = this.InitFrontlinesStrength(aiMatrix2, friendlyPower, enemyPower, ownerMatrix, tminstrength);
      AIMatrix tcorps = this.SetProminantCorpsOfHexesAndDefZones();
      if (this.CustomCalls.CustomIsMinor())
      {
        DataClass data = DrawMod.TGame.Data;
        string str = "zones";
        ref string local = ref str;
        int libVar = data.FindLibVar(ref local, "SE_Data");
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int index18 = 0; index18 <= mapWidth4; ++index18)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index19 = 0; index19 <= mapHeight; ++index19)
          {
            if (this.game.Data.MapObj[0].HexObj[index18, index19].Regime == this.game.Data.Turn)
            {
              num1 = this.game.Data.MapObj[0].HexObj[index18, index19].GetHexLibVarValue(libVar);
              tcorps.Value[index18, index19] = num1 >= 1 ? num1 : 18001;
            }
          }
        }
      }
      tcorps.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, valueMustBeBelow: 1000000);
      tcorps.RemoveValuesByMask(aiMatrix2, 0, 1000000);
      tcorps.RemoveUnconnectedHex(aiMatrix2);
      tcorps.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, valueMustBeBelow: 1000000);
      tcorps = this.SetProminantCorpsAddBroadDefZonesAsPointDef(ref tcorps);
      tcorps.RemoveValuesByMask(aiMatrix2, 0, 1000000);
      AIMatrix aiMatrix5 = this.InitFrontlinesSetFronts(tstrength, tcorps, strength);
      this.game.EditObj.AIProgressNow = 35;
      int areaSlotMustBeSame2 = -1;
      if (this.VAR_USE_SUPERFRONTS)
      {
        areaSlotMustBeSame2 = 1;
        aiMatrix5.RemoveValuesBySuperFrontRule();
      }
      this.InitFrontlinesSplitLargeFronts(ref aiMatrix5, ref aiMatrix5);
      aiMatrix5.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, areaSlotMustBeSame2, 1000000);
      AIMatrix deepFronts = aiMatrix5.Clone();
      aiMatrix5.RemoveSmallestEnclaves();
      aiMatrix5.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, areaSlotMustBeSame2, 1000000);
      aiMatrix5.RemoveValuesByMask(aiMatrix2, 0, 1000000);
      if (this.game.Data.Turn == 13)
        ;
      tai = this;
      this.frontList = new AIFrontList(ref tai);
      this.InitFrontlinesAddEmptyFrontlines(aiMatrix5, tstrength, ref this.frontList);
      this.InitFrontlinesSplitLargeFronts(ref aiMatrix5, ref deepFronts);
      deepFronts = aiMatrix5.Clone();
      deepFronts.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, areaSlotMustBeSame2, 1000000);
      this.InitFrontlinesSplitLargeFronts(ref aiMatrix5, ref deepFronts);
      this.game.EditObj.AIProgressNow = 40;
      aiMatrix5.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, areaSlotMustBeSame2, 1000000);
      aiMatrix5.RemoveSmallestEnclaves();
      aiMatrix5.RemoveSmallestRegularFronts();
      aiMatrix5.RemoveValuesByMask(aiMatrix2, 0, 1000000);
      if (this.game.Data.Product == 7)
      {
        aiMatrix5.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH * 2, areaSlotMustBeSame2, 1000000);
        aiMatrix5.RemoveValuesByMask(aiMatrix2, 0, 1000000);
        aiMatrix5.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, areaSlotMustBeSame2, 1000000);
      }
      else
        aiMatrix5.ExpandUniquesValuesForSameRegime(this.VAR_FRONTLINE_DEPTH, areaSlotMustBeSame2, 1000000);
      tai = this;
      this.frontList = new AIFrontList(ref tai);
      this.frontlinesMatrix = aiMatrix2;
      if (this.VAR_ZONES_TYPE == 2)
        aiMatrix5.RemoveExposedNonNeccFronts();
      if (this.game.Data.Product == 7 && this.CustomCalls.CustomDoStrategicIterations())
      {
        if (this.VAR_DEBUG_ON)
          this.Screenshot("before_blend", ref aiMatrix5.Value);
        int num2 = 0;
        string libvarname = "oldFronts" + this.game.Data.RegimeObj[this.game.Data.Turn].id.ToString();
        int libVar = this.game.Data.FindLibVar(ref libvarname, "SE_Data");
        if (libVar > -1)
        {
          int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
          for (int index20 = 0; index20 <= mapWidth5; ++index20)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index21 = 0; index21 <= mapHeight; ++index21)
            {
              if (this.game.Data.MapObj[0].HexObj[index20, index21].GetHexLibVarValue(libVar) > 0)
                ++num2;
            }
          }
        }
        bool flag3 = false;
        if (num2 > 4)
          flag3 = true;
        if (flag3)
        {
          tai = this;
          AIMatrix oldFronts = new AIMatrix(ref tai);
          int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
          for (int index22 = 0; index22 <= mapWidth6; ++index22)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index23 = 0; index23 <= mapHeight; ++index23)
              oldFronts.Value[index22, index23] = this.game.Data.MapObj[0].HexObj[index22, index23].GetHexLibVarValue(libVar);
          }
          this.BlendFronts(ref aiMatrix5, ref oldFronts);
        }
        if (libVar > -1)
        {
          int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
          for (int index24 = 0; index24 <= mapWidth7; ++index24)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index25 = 0; index25 <= mapHeight; ++index25)
              this.game.Data.MapObj[0].HexObj[index24, index25].RemoveHexLibVarSlotNr(libVar);
          }
        }
        if (libVar < 0)
        {
          int library = this.game.Data.FindLibrary("SE_Data");
          this.game.Data.AddLibVar(library);
          int libVarCounter = this.game.Data.LibVarCounter;
          this.game.Data.LibVarObj[libVarCounter].valueType = NewEnums.LibVarValueType.Text;
          this.game.Data.LibVarObj[libVarCounter].value = -1;
          this.game.Data.LibVarObj[libVarCounter].name = libvarname;
          this.game.Data.LibVarObj[libVarCounter].type = NewEnums.LibVarType.Hex;
          this.game.Data.LibVarObj[libVarCounter].instanceId.libSlot = -1;
          this.game.Data.LibVarObj[libVarCounter].instanceId.id = -1;
          this.game.Data.LibVarObj[libVarCounter].libId.libSlot = library;
          this.game.Data.LibVarObj[libVarCounter].libId.id = -1;
          libVar = this.game.Data.FindLibVar(ref libvarname, "SE_Data");
        }
        if (libVar > 0)
        {
          int mapWidth8 = this.game.Data.MapObj[0].MapWidth;
          for (int index26 = 0; index26 <= mapWidth8; ++index26)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index27 = 0; index27 <= mapHeight; ++index27)
            {
              if (aiMatrix5.Value[index26, index27] > 0)
                this.game.Data.MapObj[0].HexObj[index26, index27].SetHexLibVarValue(libVar, aiMatrix5.Value[index26, index27]);
            }
          }
        }
      }
      if (!this.CustomCalls.CustomRuleInitFrontlines_MLAalreadySet())
      {
        tai = this;
        this.MLAMatrix = new AIMatrix(ref tai);
        if (this.game.Data.Product > 6 | !this.VAR_USE_MLA | this.game.Data.MapObj[0].MapWidth < this.VAR_MLA_RANGE * 4 | this.game.Data.MapObj[0].MapHeight < this.VAR_MLA_RANGE * 4)
        {
          this.MLAMatrix.SetAllValuesTo(1);
        }
        else
        {
          this.SetTempHexNeighbours();
          tai = this;
          AIMatrix aiMatrix6 = new AIMatrix(ref tai, this.VAR_MLA_RANGE * 4, this.VAR_MLA_RANGE * 4, 0, 0);
          int num3 = this.VAR_MLA_RANGE * 4;
          for (int index28 = 0; index28 <= num3; ++index28)
          {
            int num4 = this.VAR_MLA_RANGE * 4;
            for (int index29 = 0; index29 <= num4; ++index29)
              aiMatrix6.Value[index28, index29] = index28 > this.VAR_MLA_RANGE * 2 ? 2 : 1;
          }
          AIMatrix mask5 = aiMatrix6.Clone();
          aiMatrix6.SetAllValuesNotValueXTo(0, 1);
          aiMatrix6.ExpandValueWithoutConditions();
          aiMatrix6.RemoveValuesByMask(mask5, 1);
          aiMatrix6.RemoveValuesByMask(mask5, 0);
          aiMatrix6.DiminishAllPositiveValues(1);
          int num5 = this.VAR_MLA_RANGE * 4;
          for (int index30 = 0; index30 <= num5; ++index30)
          {
            int num6 = this.VAR_MLA_RANGE * 4;
            for (int index31 = 0; index31 <= num6; ++index31)
            {
              if (mask5.Value[index30, index31] == 2)
              {
                int[,] numArray1 = aiMatrix6.Value;
                int[,] numArray2 = numArray1;
                int index32 = index30;
                int index33 = index32;
                int index34 = index31;
                int index35 = index34;
                int num7 = numArray1[index32, index34] + 100;
                numArray2[index33, index35] = num7;
              }
            }
          }
          aiMatrix6.MultiplyAllValues(10);
          int num8 = aiMatrix6.AverageValuesForAnyRegime(this.VAR_MLA_RANGE + 4).Value[this.VAR_MLA_RANGE * 2 + 6, this.VAR_MLA_RANGE * 2];
          ownerMatrix = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
          AIMatrix aiMatrix7 = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
          aiMatrix7.SetAllValuesNotValueXTo(0, 1);
          aiMatrix7.ExpandValueWithoutConditions();
          aiMatrix7.RemoveValuesByMask(ownerMatrix, 1);
          aiMatrix7.DiminishAllPositiveValues(1);
          int mapWidth9 = this.map.MapWidth;
          for (int index36 = 0; index36 <= mapWidth9; ++index36)
          {
            int mapHeight = this.map.MapHeight;
            for (int index37 = 0; index37 <= mapHeight; ++index37)
            {
              if (ownerMatrix.Value[index36, index37] == 2)
              {
                int[,] numArray3 = aiMatrix7.Value;
                int[,] numArray4 = numArray3;
                int index38 = index36;
                int index39 = index38;
                int index40 = index37;
                int index41 = index40;
                int num9 = numArray3[index38, index40] + 100;
                numArray4[index39, index41] = num9;
              }
            }
          }
          aiMatrix7.MultiplyAllValues(10);
          aiMatrix7.AddValueByMask(ownerMatrix, 0, -1);
          this.MLAMatrix = aiMatrix7.AverageValuesForAnyRegime(this.VAR_MLA_RANGE + 4).Clone();
          int mapWidth10 = this.map.MapWidth;
          for (int index42 = 0; index42 <= mapWidth10; ++index42)
          {
            int mapHeight = this.map.MapHeight;
            for (int index43 = 0; index43 <= mapHeight; ++index43)
              this.MLAMatrix.Value[index42, index43] = !(this.MLAMatrix.Value[index42, index43] < num8 | ownerMatrix.Value[index42, index43] == 1) ? 0 : 1;
          }
          if (this.VAR_DEBUG_ON)
            this.Screenshot("MLA", ref this.MLAMatrix.Value);
        }
      }
      else if (this.VAR_DEBUG_ON)
        this.Screenshot("MLA", ref this.MLAMatrix.Value);
      tai = this;
      this.enemyBoostMatrix = new AIMatrix(ref tai);
      if (this.VAR_STRATEGIC_WEAKNESS_AT_BOTTLENECK)
      {
        this.enemyBoostMatrix = this.SetFriendlyBottleNeckMatrix((AIFront) null, this.friendlySupplyMatrix, ownerMatrix, true, 0);
        this.enemyBoostMatrix.ExpandValueWithoutConditionsHighest(3, 66);
      }
      this.InitFrontlinesAssignUnitsToFronts(aiMatrix5, ref this.frontList, ref ownerMatrix, ref enemyPower, ref tstrength, ref aiMatrix2);
      this.MLAMatrix.ExpandSpecificValueForSameRegime(1, 1);
      this.InitFrontlinesKeepDivTogether(ref this.frontList, ref aiMatrix5);
      this.LogFronts("0010_fronts_initial");
      this.InitFrontlinesAddStrategicReserveFrontlines(ref this.frontList, ref aiMatrix5);
      this.InitFrontlinesAddFlakFrontlines(ref this.frontList, ref aiMatrix5);
      this.InitFrontlinesAddReserveFrontlines(ref this.frontList, ref aiMatrix5);
      this.InitFrontlinesAddReserveArtilleryFrontlines(ref this.frontList, ref aiMatrix5);
      AIMatrix fronts = aiMatrix5.Clone();
      fronts.RemoveValuesByMask(aiMatrix2, 0, 1000000);
      AIMatrix frontsForEnemy = fronts.Clone();
      frontsForEnemy.ExpandValueForAnyRegime(this.VAR_FRONTLINE_DEPTH, 1000000);
      this.InitFrontlinesAverageStrength(ref this.frontList, ref strength, ref fronts, ref enemyPower, ref friendlyPower, ref frontsForEnemy);
      this.InitFrontlinesOffensiveModifier(ref this.frontList);
      this.InitFrontlinesAddAirFrontlines(ref this.frontList, ref aiMatrix5);
      this.InitFrontlinesAddEngineerFrontlines(ref this.frontList, ref aiMatrix2);
      this.InitFrontlinesAddNavyFrontlines(ref this.frontList, ref aiMatrix2);
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
          this.game.Data.UnitObj[index].prevTurnAiFrontHexes = (CoordList) null;
      }
      int counter1 = this.frontList.Counter;
      for (int index44 = 0; index44 <= counter1; ++index44)
      {
        AIFront aiFront = this.frontList.Front[index44];
        int counter2 = aiFront.units.counter;
        for (int index45 = 0; index45 <= counter2; ++index45)
        {
          int index46 = aiFront.units.unr[index45];
          this.game.Data.UnitObj[index46].prevTurnAiFrontHexes = new CoordList();
          int num10 = aiFront.FrontID;
          if (aiFront.TargetFrontID > 0)
            num10 = aiFront.TargetFrontID;
          int mapWidth11 = this.game.Data.MapObj[0].MapWidth;
          for (int x = 0; x <= mapWidth11; ++x)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int y = 0; y <= mapHeight; ++y)
            {
              if (this.frontlinesMatrix.Value[x, y] > 0 && this.frontMatrix.Value[x, y] == num10)
                this.game.Data.UnitObj[index46].prevTurnAiFrontHexes.AddCoord(x, y, 0);
            }
          }
        }
      }
      this.game.EditObj.AIProgressNow = 50;
      this.strengthMatrix = strength;
      this.DynamicOob(ref this.frontList, ref aiMatrix2);
      this.InitfrontlinesOutOfSupplyFrontsGetAllUnits(ref this.friendlySupplyMatrix, ref this.frontList, ref aiMatrix5);
      this.InitFrontlinesSetOrganisingUnits(ref this.frontList, aiMatrix5);
      if (flag2)
        this.WriteLog("0020_InitFrontlines_InclAirStrategicFlakEtc");
      this.frontMatrix = aiMatrix5;
      this.frontlinesMatrix = aiMatrix2;
      this.friendlyTroopsMatrix = this.SetMatrixUnitPower(true);
      this.extendedMatrix = this.frontMatrix.Clone();
      AIMatrix aiMatrix8 = aiMatrix2.Clone();
      if (this.game.Data.Product < 6)
      {
        int num11 = this.VAR_FRONTLINE_DEPTH * 2;
        for (int index47 = 1; index47 <= num11; ++index47)
        {
          tai = this;
          AIMatrix aiMatrix9 = new AIMatrix(ref tai);
          int mapWidth12 = this.map.MapWidth;
          for (int x1 = 0; x1 <= mapWidth12; ++x1)
          {
            int mapHeight = this.map.MapHeight;
            for (int y1 = 0; y1 <= mapHeight; ++y1)
            {
              if (this.extendedMatrix.Value[x1, y1] == 0)
              {
                SimpleList simpleList = new SimpleList();
                int num12 = x1 - this.VAR_FRONTLINE_DEPTH;
                int num13 = this.map.MapWidth + this.VAR_FRONTLINE_DEPTH;
                for (int x2 = num12; x2 <= num13; ++x2)
                {
                  int num14 = y1 - this.VAR_FRONTLINE_DEPTH;
                  int num15 = this.map.MapHeight + this.VAR_FRONTLINE_DEPTH;
                  for (int y2 = num14; y2 <= num15; ++y2)
                  {
                    if (x2 >= 0 & y2 >= 0 & x2 <= this.map.MapWidth & y2 <= this.map.MapHeight && this.extendedMatrix.Value[x2, y2] > 0 & aiMatrix8.Value[x2, y2] > 0)
                    {
                      int num16 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0);
                      int nr = simpleList.FindNr(this.extendedMatrix.Value[x2, y2]);
                      if (num16 <= 1)
                      {
                        if (nr > -1)
                        {
                          int[] weight = simpleList.Weight;
                          int[] numArray5 = weight;
                          int index48 = nr;
                          int index49 = index48;
                          int num17 = weight[index48] + num16 * 10;
                          numArray5[index49] = num17;
                          int[] data1 = simpleList.Data1;
                          int[] numArray6 = data1;
                          int index50 = nr;
                          int index51 = index50;
                          int num18 = data1[index50] + 1;
                          numArray6[index51] = num18;
                        }
                        else
                          simpleList.Add(this.extendedMatrix.Value[x2, y2], num16 * 10, 1);
                      }
                    }
                  }
                }
                int counter3 = simpleList.Counter;
                for (int index52 = 0; index52 <= counter3; ++index52)
                  simpleList.Weight[index52] = (int) Math.Round((double) simpleList.Weight[index52] / (double) simpleList.Data1[index52]);
                if (simpleList.Counter > -1)
                {
                  simpleList.Sort();
                  aiMatrix9.Value[x1, y1] = simpleList.Id[0];
                }
              }
            }
          }
          int mapWidth13 = this.map.MapWidth;
          for (int index53 = 0; index53 <= mapWidth13; ++index53)
          {
            int mapHeight = this.map.MapHeight;
            for (int index54 = 0; index54 <= mapHeight; ++index54)
            {
              if (this.extendedMatrix.Value[index53, index54] == 0)
                this.extendedMatrix.Value[index53, index54] = aiMatrix9.Value[index53, index54];
            }
          }
          aiMatrix8 = aiMatrix9.Clone();
        }
      }
      if (flag2)
        this.Screenshot("0030_strategic_fronts", ref this.frontMatrix.Value);
      int counter4 = this.frontList.Counter;
      for (int index = 0; index <= counter4; ++index)
      {
        this.frontList.Front[index].OrigAverageStrength = this.frontList.Front[index].AverageStrength;
        this.frontList.Front[index].OrigPower = this.frontList.Front[index].GetPowerUnderFront();
        this.frontList.Front[index].PowerToReserve = 0;
      }
      if (!flag2)
        return;
      this.LogFronts("0040_fronts_initial");
    }

    public void InitfrontlinesOutOfSupplyFrontsGetAllUnits(
      ref AIMatrix sup,
      ref AIFrontList flist,
      ref AIMatrix frontmat)
    {
      if (this.VAR_USE_STRICT_HQFRONT)
        return;
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (frontmat.Value[index1, index2] > 0 & sup.Value[index1, index2] > this.VAR_SUPPLY_MAXIMUM_RANGE & this.GetRegime(this.map.HexObj[index1, index2].Regime) == this.GetGameDataTurn())
          {
            int unitCounter = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              int initialFrontID1 = this.game.Data.UnitObj[unit].AIGroup;
              if (unit == 34)
                initialFrontID1 = initialFrontID1;
              int initialFrontID2 = frontmat.Value[index1, index2];
              if (flist.GetFrontNr(initialFrontID1) > -1)
              {
                int frontNr1 = flist.GetFrontNr(initialFrontID1);
                int frontNr2 = flist.GetFrontNr(initialFrontID2);
                if (frontNr1 != frontNr2 & frontNr1 > -1 & frontNr2 > -1)
                {
                  flist.Front[frontNr1].RemoveUnitAIid(this.game.Data.UnitObj[unit].AIid);
                  flist.Front[frontNr1].RemoveArtUnitAIid(this.game.Data.UnitObj[unit].AIid);
                  flist.Front[frontNr1].RemoveOrgUnitAIid(this.game.Data.UnitObj[unit].AIid);
                  flist.Front[frontNr2].units.add(unit, this.game.Data.UnitObj[unit].AIid);
                }
              }
            }
          }
        }
      }
    }

    public void BlendFronts(ref AIMatrix curfronts, ref AIMatrix oldFronts)
    {
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      int num1 = -1;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].IsHQ)
        {
          int historical = this.game.Data.UnitObj[index].Historical;
          if (historical > -1)
          {
            int id = this.game.Data.HistoricalUnitObj[historical].ID;
            if (id > num1)
              num1 = id;
          }
        }
      }
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      if (num1 < 1)
        return;
      int mapWidth1 = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          int tid1 = curfronts.Value[index1, index2];
          if (tid1 > 0)
            simpleList2.AddWeight(tid1, 1);
          if (tid1 >= num1)
          {
            int nr = simpleList1.FindNr(tid1);
            if (nr > -1)
            {
              int[] weight = simpleList1.Weight;
              int[] numArray = weight;
              int index3 = nr;
              int index4 = index3;
              int num2 = weight[index3] + 1;
              numArray[index4] = num2;
            }
            else
              simpleList1.AddWeight(tid1, 1);
          }
          int tid2 = oldFronts.Value[index1, index2];
          if (tid2 >= num1)
          {
            int nr = simpleList1.FindNr(tid2);
            if (nr > -1)
            {
              int[] data1 = simpleList1.Data1;
              int[] numArray = data1;
              int index5 = nr;
              int index6 = index5;
              int num3 = data1[index5] + 1;
              numArray[index6] = num3;
            }
            else
              simpleList1.AddWeight(tid2, 0, 1);
          }
        }
      }
      for (int counter = simpleList1.Counter; counter >= 0; counter += -1)
      {
        if (simpleList1.Weight[counter] < 1 | simpleList1.Data1[counter] < 1)
          simpleList1.RemoveNr(counter);
        else if (simpleList1.Id[counter] > 199000)
          simpleList1.RemoveNr(counter);
      }
      if (simpleList1.Counter < 0)
        return;
      oldFronts.ExpandUniquesValuesForSameRegime(9, valueMustBeBelow: 199000);
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
      aiMatrix2.SetAllValuesTo(0);
      int counter1 = simpleList2.Counter;
      for (int index7 = 0; index7 <= counter1; ++index7)
      {
        DC2AIClass tai3 = this;
        AIMatrix aiMatrix3 = new AIMatrix(ref tai3);
        int mapWidth2 = this.map.MapWidth;
        for (int index8 = 0; index8 <= mapWidth2; ++index8)
        {
          int mapHeight = this.map.MapHeight;
          for (int index9 = 0; index9 <= mapHeight; ++index9)
          {
            if (curfronts.Value[index8, index9] != simpleList2.Id[index7])
              aiMatrix3.Value[index8, index9] = 1;
          }
        }
        aiMatrix3.ExpandAndAddValueForSameRegime(7);
        aiMatrix3.SetValueXToValueY(0, 99);
        int num4 = 0;
        int mapWidth3 = this.map.MapWidth;
        for (int index10 = 0; index10 <= mapWidth3; ++index10)
        {
          int mapHeight = this.map.MapHeight;
          for (int index11 = 0; index11 <= mapHeight; ++index11)
          {
            int num5 = curfronts.Value[index10, index11];
            if (aiMatrix3.Value[index10, index11] > 1 && aiMatrix3.Value[index10, index11] < 7 && aiMatrix3.Value[index10, index11] > num4)
              num4 = aiMatrix3.Value[index10, index11];
          }
        }
        int num6 = (int) Math.Round(Math.Ceiling((double) (num4 + 1) * 0.66));
        if (num4 <= num6)
          num6 = num4;
        int mapWidth4 = this.map.MapWidth;
        for (int index12 = 0; index12 <= mapWidth4; ++index12)
        {
          int mapHeight = this.map.MapHeight;
          for (int index13 = 0; index13 <= mapHeight; ++index13)
          {
            if (curfronts.Value[index12, index13] == simpleList2.Id[index7] && aiMatrix3.Value[index12, index13] > 1 && aiMatrix3.Value[index12, index13] < 99 && aiMatrix3.Value[index12, index13] >= num6)
              aiMatrix2.Value[index12, index13] = 1;
          }
        }
      }
      int num7 = 4;
      float num8 = 0.66f;
      int counter2 = simpleList1.Counter;
      for (int index14 = 0; index14 <= counter2; ++index14)
      {
        DC2AIClass tai4 = this;
        AIMatrix aiMatrix4 = new AIMatrix(ref tai4);
        int mapWidth5 = this.map.MapWidth;
        for (int index15 = 0; index15 <= mapWidth5; ++index15)
        {
          int mapHeight = this.map.MapHeight;
          for (int index16 = 0; index16 <= mapHeight; ++index16)
          {
            if (curfronts.Value[index15, index16] == simpleList1.Id[index14])
              aiMatrix4.Value[index15, index16] = 1;
          }
        }
        aiMatrix4.ExpandAndAddValueForSameRegime(num7 + 1);
        int num9 = 0;
        int mapWidth6 = this.map.MapWidth;
        for (int index17 = 0; index17 <= mapWidth6; ++index17)
        {
          int mapHeight = this.map.MapHeight;
          for (int index18 = 0; index18 <= mapHeight; ++index18)
          {
            if (aiMatrix4.Value[index17, index18] > num9)
              num9 = aiMatrix4.Value[index17, index18];
          }
        }
        if (num9 >= 2)
        {
          int num10 = num9 - 1;
          int num11 = (int) Math.Round(Math.Ceiling((double) num10 * (double) num8));
          if (num11 == num10)
            num11 = num10 - 1;
          if (num10 > 0)
          {
            int mapWidth7 = this.map.MapWidth;
            for (int index19 = 0; index19 <= mapWidth7; ++index19)
            {
              int mapHeight = this.map.MapHeight;
              for (int index20 = 0; index20 <= mapHeight; ++index20)
              {
                if (oldFronts.Value[index19, index20] == simpleList1.Id[index14] && aiMatrix4.Value[index19, index20] > 0 && aiMatrix4.Value[index19, index20] <= num11 && aiMatrix2.Value[index19, index20] < 1 && curfronts.Value[index19, index20] < 100000)
                  curfronts.Value[index19, index20] = simpleList1.Id[index14];
              }
            }
          }
        }
      }
    }

    public void InitFrontlinesSplitLargeFronts(ref AIMatrix fronts, ref AIMatrix deepFronts)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int[] numArray1 = new int[1000];
      int[] numArray2 = new int[1000];
      int[] numArray3 = new int[1000];
      int[] numArray4 = new int[1000];
      int[] numArray5 = new int[1000];
      int[] numArray6 = new int[1000];
      int[] numArray7 = new int[1000];
      int[] numArray8 = new int[1000];
      int[] numArray9 = new int[1000];
      int[] numArray10 = new int[1000];
      int[] numArray11 = new int[1000];
      int[] numArray12 = new int[1000];
      int[] numArray13 = new int[1000];
      int[] numArray14 = new int[1000];
      int[] numArray15 = new int[1000];
      int[] numArray16 = new int[1000];
      int[] numArray17 = new int[1000];
      int[,] numArray18 = new int[1000, 20];
      int index1 = -1;
      int index2 = 0;
      do
      {
        numArray3[index2] = 999;
        numArray5[index2] = 999;
        ++index2;
      }
      while (index2 <= 999);
      int mapWidth1 = this.map.MapWidth;
      for (int index3 = 0; index3 <= mapWidth1; ++index3)
      {
        int mapHeight = this.map.MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          if (deepFronts.Value[index3, index4] > 0 & deepFronts.Value[index3, index4] < 1000000)
          {
            int num1 = -1;
            int num2 = index1;
            for (int index5 = 0; index5 <= num2; ++index5)
            {
              if (numArray13[index5] == deepFronts.Value[index3, index4])
                num1 = index5;
            }
            if (num1 > -1)
            {
              int[] numArray19 = numArray2;
              int[] numArray20 = numArray19;
              int index6 = num1;
              int index7 = index6;
              int num3 = numArray19[index6] + 1;
              numArray20[index7] = num3;
              if (this.game.Data.MapObj[0].HexObj[index3, index4].UnitCounter > -1)
              {
                int[] numArray21 = numArray9;
                int[] numArray22 = numArray21;
                int index8 = num1;
                int index9 = index8;
                int num4 = numArray21[index8] + (this.game.Data.MapObj[0].HexObj[index3, index4].UnitCounter + 1);
                numArray22[index9] = num4;
              }
            }
          }
          if (fronts.Value[index3, index4] > 0 & fronts.Value[index3, index4] < 1000000)
          {
            int index10 = -1;
            int num5 = index1;
            for (int index11 = 0; index11 <= num5; ++index11)
            {
              if (numArray13[index11] == fronts.Value[index3, index4])
                index10 = index11;
            }
            if (index10 == -1)
            {
              ++index1;
              numArray13[index1] = fronts.Value[index3, index4];
              numArray17[index1] = -1;
              index10 = index1;
            }
            if (index3 < numArray3[index10])
              numArray3[index10] = index3;
            if (index4 < numArray5[index10])
              numArray5[index10] = index4;
            if (index3 > numArray7[index10])
              numArray7[index10] = index3;
            if (index4 > numArray6[index10])
              numArray6[index10] = index4;
            int[] numArray23 = numArray1;
            int[] numArray24 = numArray23;
            int index12 = index10;
            int index13 = index12;
            int num6 = numArray23[index12] + 1;
            numArray24[index13] = num6;
            int[] numArray25 = numArray8;
            int[] numArray26 = numArray25;
            int index14 = index10;
            int index15 = index14;
            int num7 = numArray25[index14] + index3;
            numArray26[index15] = num7;
            int[] numArray27 = numArray10;
            int[] numArray28 = numArray27;
            int index16 = index10;
            int index17 = index16;
            int num8 = numArray27[index16] + index4;
            numArray28[index17] = num8;
            int index18 = 0;
            do
            {
              if (this.TempHexNeighbour[index3, index4, index18].onmap)
              {
                if (fronts.Value[this.TempHexNeighbour[index3, index4, index18].x, this.TempHexNeighbour[index3, index4, index18].y] > 0)
                {
                  if (fronts.Value[this.TempHexNeighbour[index3, index4, index18].x, this.TempHexNeighbour[index3, index4, index18].y] != fronts.Value[index3, index4] && numArray17[index10] < 9)
                  {
                    int[] numArray29 = numArray17;
                    int[] numArray30 = numArray29;
                    int index19 = index10;
                    int index20 = index19;
                    int num9 = numArray29[index19] + 1;
                    numArray30[index20] = num9;
                    numArray18[index10, numArray17[index10]] = fronts.Value[this.TempHexNeighbour[index3, index4, index18].x, this.TempHexNeighbour[index3, index4, index18].y];
                  }
                }
                else if (this.map.HexObj[this.TempHexNeighbour[index3, index4, index18].x, this.TempHexNeighbour[index3, index4, index18].y].Regime != this.GetGameDataTurn() && this.map.HexObj[this.TempHexNeighbour[index3, index4, index18].x, this.TempHexNeighbour[index3, index4, index18].y].Regime != -1)
                {
                  if (index18 == 1 | index18 == 2 | index18 == 4 | index18 == 5)
                  {
                    int[] numArray31 = numArray11;
                    int[] numArray32 = numArray31;
                    int index21 = index10;
                    int index22 = index21;
                    int num10 = numArray31[index21] + 1;
                    numArray32[index22] = num10;
                  }
                  else
                  {
                    int[] numArray33 = numArray12;
                    int[] numArray34 = numArray33;
                    int index23 = index10;
                    int index24 = index23;
                    int num11 = numArray33[index23] + 1;
                    numArray34[index24] = num11;
                  }
                }
              }
              ++index18;
            }
            while (index18 <= 5);
          }
        }
      }
      int num12 = index1;
      for (int index25 = 0; index25 <= num12; ++index25)
      {
        bool flag1 = false;
        bool flag2 = false;
        if (numArray1[index25] > 0 && Math.Max(Math.Abs(numArray7[index25] - numArray3[index25]), Math.Abs(numArray6[index25] - numArray5[index25])) >= (int) Math.Round((double) this.VAR_FRONTLINE_MAX_LENGTH * 0.8))
        {
          flag1 = true;
          flag2 = true;
        }
        if (numArray1[index25] > this.VAR_FRONTLINE_MAX_LENGTH)
          flag1 = true;
        bool flag3 = false;
        if (numArray2[index25] > 0)
        {
          if ((double) numArray9[index25] / (double) numArray1[index25] > 4.0 & numArray1[index25] > 4)
          {
            flag1 = true;
            flag3 = true;
          }
          if (!flag1 & this.game.Data.Product >= 6 && (double) numArray9[index25] / (double) numArray1[index25] > 4.0 & numArray1[index25] > 2)
          {
            flag1 = true;
            flag3 = true;
          }
        }
        if (flag1)
        {
          int num13 = 0;
          numArray8[index25] = (int) Math.Round((double) numArray8[index25] / (double) numArray1[index25]);
          numArray10[index25] = (int) Math.Round((double) numArray10[index25] / (double) numArray1[index25]);
          int mapWidth2 = this.map.MapWidth;
          for (int index26 = 0; index26 <= mapWidth2; ++index26)
          {
            int mapHeight = this.map.MapHeight;
            for (int index27 = 0; index27 <= mapHeight; ++index27)
            {
              if (fronts.Value[index26, index27] == numArray13[index25])
              {
                if (numArray11[index25] > numArray12[index25] * 2)
                {
                  if (numArray10[index25] > index27)
                    ++num13;
                }
                else if (numArray8[index25] > index26)
                  ++num13;
              }
            }
          }
          if (flag3 | (double) num13 > (double) this.VAR_FRONTLINE_MAX_LENGTH / 2.0 + 1.0 | flag2)
          {
            int num14 = 1;
            do
            {
              bool flag4 = true;
              int num15 = index1;
              int index28;
              for (index28 = 0; index28 <= num15; ++index28)
              {
                if (numArray13[index28] == num14)
                  flag4 = false;
              }
              if (flag4)
              {
                ++index1;
                numArray13[index28] = num14;
                break;
              }
              ++num14;
            }
            while (num14 <= 999);
            if (num14 > 0 & num14 < 999)
            {
              int mapWidth3 = this.map.MapWidth;
              for (int index29 = 0; index29 <= mapWidth3; ++index29)
              {
                int mapHeight = this.map.MapHeight;
                for (int index30 = 0; index30 <= mapHeight; ++index30)
                {
                  if (fronts.Value[index29, index30] == numArray13[index25])
                  {
                    if (numArray11[index25] > numArray12[index25] * 2)
                    {
                      if (numArray10[index25] > index30)
                        fronts.Value[index29, index30] = num14;
                    }
                    else if (numArray8[index25] > index29)
                      fronts.Value[index29, index30] = num14;
                  }
                }
              }
            }
          }
        }
      }
    }

    public AIMatrix InitFrontlinesSetFronts(
      AIMatrix strength,
      AIMatrix corps,
      AIMatrix exactStrength)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int[] numArray1 = new int[1000];
      int[] numArray2 = new int[1000];
      int[] numArray3 = new int[1000];
      int[] numArray4 = new int[1000];
      int[] numArray5 = new int[1000];
      int[] numArray6 = new int[1000];
      int[,] numArray7 = new int[1000, 20];
      int index1 = -1;
      int mapWidth1 = this.map.MapWidth;
      for (int index2 = 0; index2 <= mapWidth1; ++index2)
      {
        int mapHeight = this.map.MapHeight;
        for (int index3 = 0; index3 <= mapHeight; ++index3)
        {
          if (corps.Value[index2, index3] > 0)
          {
            int index4 = -1;
            int num1 = index1;
            for (int index5 = 0; index5 <= num1; ++index5)
            {
              if (numArray2[index5] == corps.Value[index2, index3])
                index4 = index5;
            }
            if (index4 == -1)
            {
              ++index1;
              numArray2[index1] = corps.Value[index2, index3];
              numArray6[index1] = -1;
              index4 = index1;
            }
            int[] numArray8 = numArray1;
            int[] numArray9 = numArray8;
            int index6 = index4;
            int index7 = index6;
            int num2 = numArray8[index6] + 1;
            numArray9[index7] = num2;
            int[] numArray10 = numArray5;
            int[] numArray11 = numArray10;
            int index8 = index4;
            int index9 = index8;
            int num3 = numArray10[index8] + strength.Value[index2, index3];
            numArray11[index9] = num3;
            int index10 = 0;
            do
            {
              if (this.TempHexNeighbour[index2, index3, index10].onmap && corps.Value[this.TempHexNeighbour[index2, index3, index10].x, this.TempHexNeighbour[index2, index3, index10].y] > 0 && corps.Value[this.TempHexNeighbour[index2, index3, index10].x, this.TempHexNeighbour[index2, index3, index10].y] != corps.Value[index2, index3] && numArray6[index4] < 9)
              {
                int[] numArray12 = numArray6;
                int[] numArray13 = numArray12;
                int index11 = index4;
                int index12 = index11;
                int num4 = numArray12[index11] + 1;
                numArray13[index12] = num4;
                numArray7[index4, numArray6[index4]] = corps.Value[this.TempHexNeighbour[index2, index3, index10].x, this.TempHexNeighbour[index2, index3, index10].y];
              }
              ++index10;
            }
            while (index10 <= 5);
          }
        }
      }
      int num5 = index1;
      for (int index13 = 0; index13 <= num5; ++index13)
      {
        numArray4[index13] = (int) Math.Round((double) numArray5[index13] / (double) numArray1[index13]);
        if (numArray4[index13] > 3)
          numArray4[index13] = 3;
        numArray3[index13] = numArray2[index13];
      }
      bool flag1;
      do
      {
        flag1 = false;
        int num6 = index1;
        for (int index14 = 0; index14 <= num6; ++index14)
        {
          if (numArray2[index14] == numArray3[index14] & numArray2[index14] < 1000000 && numArray1[index14] < this.VAR_FRONTLINE_MAX_LENGTH)
          {
            int num7 = index1;
            for (int index15 = 0; index15 <= num7; ++index15)
            {
              if (numArray2[index15] == numArray3[index15] & numArray2[index15] < 1000000 && numArray3[index14] != numArray3[index15] && numArray1[index14] + numArray1[index15] <= this.VAR_FRONTLINE_MAX_LENGTH && numArray4[index14] == numArray4[index15])
              {
                bool flag2 = false;
                int num8 = numArray6[index14];
                for (int index16 = 0; index16 <= num8; ++index16)
                {
                  if (numArray7[index14, index16] == numArray2[index15])
                    flag2 = true;
                }
                if (flag2)
                {
                  numArray3[index15] = numArray3[index14];
                  int[] numArray14 = numArray1;
                  int[] numArray15 = numArray14;
                  int index17 = index14;
                  int index18 = index17;
                  int num9 = numArray14[index17] + numArray1[index15];
                  numArray15[index18] = num9;
                  int num10 = numArray6[index15];
                  for (int index19 = 0; index19 <= num10; ++index19)
                  {
                    if (numArray6[index14] < 19)
                    {
                      int[] numArray16 = numArray6;
                      int[] numArray17 = numArray16;
                      int index20 = index14;
                      int index21 = index20;
                      int num11 = numArray16[index20] + 1;
                      numArray17[index21] = num11;
                      numArray7[index14, numArray6[index14]] = numArray7[index15, index19];
                    }
                  }
                  flag1 = true;
                }
              }
            }
          }
        }
      }
      while (flag1);
      int mapWidth2 = this.map.MapWidth;
      for (int index22 = 0; index22 <= mapWidth2; ++index22)
      {
        int mapHeight = this.map.MapHeight;
        for (int index23 = 0; index23 <= mapHeight; ++index23)
        {
          int num12 = corps.Value[index22, index23];
          if (num12 > 0)
          {
            int num13 = index1;
            for (int index24 = 0; index24 <= num13; ++index24)
            {
              if (numArray2[index24] == num12)
              {
                aiMatrix.Value[index22, index23] = numArray3[index24];
                break;
              }
            }
          }
        }
      }
      if (this.game.Data.Product >= 6)
      {
        int mapWidth3 = this.map.MapWidth;
        for (int index25 = 0; index25 <= mapWidth3; ++index25)
        {
          int mapHeight = this.map.MapHeight;
          for (int index26 = 0; index26 <= mapHeight; ++index26)
          {
            int num14 = strength.Value[index25, index26] > 0 & aiMatrix.Value[index25, index26] < 1 ? 1 : 0;
          }
        }
      }
      return aiMatrix;
    }

    public void InitFrontlinesAverageStrength(
      ref AIFrontList TempList,
      ref AIMatrix strength,
      ref AIMatrix fronts,
      ref AIMatrix enemyPower,
      ref AIMatrix friendlyPower,
      ref AIMatrix frontsForEnemy)
    {
      int counter = TempList.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        AIFront aiFront = TempList.Front[index1];
        aiFront.FrontHexes = 0;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (aiFront.FrontID == 4792)
          num3 = 0;
        int num4;
        if (aiFront.FrontType == 1)
        {
          int mapWidth = this.map.MapWidth;
          for (int index2 = 0; index2 <= mapWidth; ++index2)
          {
            int mapHeight = this.map.MapHeight;
            for (int index3 = 0; index3 <= mapHeight; ++index3)
            {
              if (this.map.HexObj[index2, index3].Regime == this.GetGameDataTurn())
              {
                if (fronts.Value[index2, index3] == aiFront.FrontID)
                {
                  if (strength.Value[index2, index3] > 0)
                  {
                    num1 += strength.Value[index2, index3];
                    ++num2;
                  }
                  num4 += friendlyPower.Value[index2, index3];
                }
              }
              else if (frontsForEnemy.Value[index2, index3] == aiFront.FrontID)
                num3 += enemyPower.Value[index2, index3];
            }
          }
        }
        aiFront.AverageStrength = num2 <= 0 ? 5f : (float) num1 / (float) num2;
        aiFront.Strength = (double) aiFront.AverageStrength > 1.4 ? ((double) aiFront.AverageStrength > 2.3 ? ((double) aiFront.AverageStrength > 3.3 ? ((double) aiFront.AverageStrength > 4.6 ? 5 : 4) : 3) : 2) : 1;
        if (aiFront.Strength == 2)
        {
          if ((double) num4 / 4.0 > (double) num3)
          {
            aiFront.Strength = 3;
            aiFront.AverageStrength = 3.05f;
          }
          else if ((double) num4 / 3.0 > (double) num3)
          {
            aiFront.Strength = 3;
            aiFront.AverageStrength = 2.75f;
          }
          else if ((double) num4 / 2.0 > (double) num3 && (double) VBMath.Rnd() > 0.5)
          {
            aiFront.Strength = 3;
            aiFront.AverageStrength = 2.55f;
          }
        }
        aiFront.FrontHexes = num2;
        aiFront.enemyPower = num3;
      }
    }

    public void InitFrontlinesOffensiveModifier(ref AIFrontList TempList)
    {
      int counter1 = TempList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        AIFront aiFront = TempList.Front[index1];
        int num1 = 0;
        int num2 = 0;
        int counter2 = aiFront.units.counter;
        for (int index2 = 0; index2 <= counter2; ++index2)
        {
          int unitByAiid = this.game.HandyFunctionsObj.GetUnitByAIid(aiFront.units.AIid[index2]);
          if (unitByAiid > -1)
          {
            num2 += this.game.Data.UnitObj[unitByAiid].TempUnitPower;
            if (this.GetAIRolePercent(unitByAiid, 10) > 25)
              num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPower;
            else if (this.GetAIRolePercent(unitByAiid, 8) > 25)
              num1 += this.game.Data.UnitObj[unitByAiid].TempUnitPower;
          }
        }
        aiFront.OffensiveModifier = num2 <= 0 ? 0 : (int) Math.Round((double) (100 * (num1 * 4)) / (double) num2);
      }
    }

    public void InitFrontlinesAddReserveFrontlines(ref AIFrontList TempList, ref AIMatrix fronts)
    {
      int num1 = 6;
      if (this.game.Data.Product >= 6)
        num1 = 9;
      bool flag1 = false;
      if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(-1))
        flag1 = true;
      this.AddLog("ADD RESERVE FRONTLINES");
      int mapWidth1 = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight1 = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight1; ++index2)
        {
          if (this.map.HexObj[index1, index2].Regime == this.GetGameDataTurn() && this.map.HexObj[index1, index2].UnitCounter > -1)
          {
            int unitCounter1 = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter1; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              bool flag2 = false;
              if (this.VAR_USE_STRICT_HQFRONT && this.game.Data.UnitObj[unit].HQ > -1 | flag1 && fronts.Value[index1, index2] > 0)
              {
                AIFront aiFront = TempList.Front[TempList.GetFrontNr(fronts.Value[index1, index2])];
                if (this.game.Data.UnitObj[unit].HQ > -1)
                {
                  if (!aiFront.strictHQs.CheckIfPresentUnr(this.game.Data.UnitObj[unit].HQ, this.game.Data.UnitObj[unit].AISubStrictGroup))
                    flag2 = true;
                }
                else if (flag1 && !aiFront.strictHQs.CheckIfPresentUnr(unit, this.game.Data.UnitObj[unit].AISubStrictGroup))
                  flag2 = true;
              }
              if (fronts.Value[index1, index2] == 0)
                flag2 = true;
              if (this.VAR_USE_STRICT_HQFRONT && this.game.Data.UnitObj[unit].HQ > -1)
              {
                int historical = this.game.Data.UnitObj[this.game.Data.UnitObj[unit].HQ].Historical;
                if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type >= num1)
                  flag2 = false;
              }
              if (flag2 && this.game.Data.UnitObj[unit].AIGroup < 0 && this.game.Data.UnitObj[unit].TempCategory == 1 | this.game.Data.UnitObj[unit].TempCategory == 5)
              {
                DC2AIClass tai = this;
                AIFront tFront = new AIFront(ref tai, 2);
                tFront.AddUnit(unit);
                TempList.AddFront(tFront, true);
                tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                this.AddLog("Add unit (norm)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                SimpleList simpleList = new SimpleList();
                int tunr = this.game.Data.UnitObj[unit].HQ;
                if (tunr == -1 & flag1)
                  tunr = unit;
                int aiSubStrictGroup = this.game.Data.UnitObj[unit].AISubStrictGroup;
                if (this.game.Data.UnitObj[unit].HQ > -1 | flag1)
                {
                  int counter1 = TempList.Counter;
                  for (int tid = 0; tid <= counter1; ++tid)
                  {
                    AIFront aiFront1 = TempList.Front[tid];
                    if (aiFront1.FrontType == 1 && !this.VAR_USE_STRICT_HQFRONT | aiFront1.strictHQs.CheckIfPresentUnr(tunr, aiSubStrictGroup))
                    {
                      int tweight = 0;
                      int counter2 = TempList.Counter;
                      for (int index4 = 0; index4 <= counter2; ++index4)
                      {
                        AIFront aiFront2 = TempList.Front[index4];
                        if (aiFront2.FrontType == 2 && aiFront2.TargetFrontID == aiFront1.FrontID)
                          ++tweight;
                      }
                      simpleList.Add(tid, tweight);
                    }
                  }
                  simpleList.Sort();
                }
                if (simpleList.Counter > -1)
                {
                  AIFront aiFront = TempList.Front[simpleList.Id[0]];
                  tFront.TargetFrontID = aiFront.FrontID;
                  this.AddLog("*STRICT RULE* Set target of reserve to frontID = " + aiFront.FrontID.ToString());
                }
                else
                {
                  int counter3 = TempList.Counter;
                  for (int tid = 0; tid <= counter3; ++tid)
                  {
                    AIFront aiFront3 = TempList.Front[tid];
                    if (aiFront3.FrontType == 1)
                    {
                      bool flag3 = false;
                      Coordinate coordinate = new Coordinate();
                      coordinate.onmap = false;
                      int mapWidth2 = this.map.MapWidth;
                      for (int index5 = 0; index5 <= mapWidth2; ++index5)
                      {
                        int mapHeight2 = this.map.MapHeight;
                        for (int index6 = 0; index6 <= mapHeight2; ++index6)
                        {
                          if (fronts.Value[index5, index6] == aiFront3.FrontID)
                          {
                            coordinate.onmap = true;
                            coordinate.x = index5;
                            coordinate.y = index6;
                            break;
                          }
                        }
                      }
                      if (this.VAR_USE_SUPERFRONTS & coordinate.onmap)
                      {
                        flag3 = false;
                        int hq = this.game.Data.UnitObj[unit].HQ;
                        if (hq > -1)
                        {
                          if (this.VAR_SUPERFRONT_HQLEVEL >= 7)
                            hq = this.game.Data.UnitObj[hq].HQ;
                          if (hq > -1)
                          {
                            if (this.VAR_SUPERFRONT_HQLEVEL >= 8)
                              hq = this.game.Data.UnitObj[hq].HQ;
                            if (hq > -1 && this.VAR_SUPERFRONT_HQLEVEL >= 9)
                              hq = this.game.Data.UnitObj[hq].HQ;
                          }
                        }
                        if (hq > -1)
                        {
                          int num2 = this.VAR_MATRIX_SUPERFRONT.Value[this.game.Data.UnitObj[hq].RealX(ref this.game), this.game.Data.UnitObj[hq].RealY(ref this.game)];
                          if (this.VAR_MATRIX_SUPERFRONT.Value[coordinate.x, coordinate.y] == num2)
                            flag3 = true;
                        }
                      }
                      else
                        flag3 = true;
                      int tweight = 0;
                      int counter4 = TempList.Counter;
                      for (int index7 = 0; index7 <= counter4; ++index7)
                      {
                        AIFront aiFront4 = TempList.Front[index7];
                        if (aiFront4.FrontType == 2 && aiFront4.TargetFrontID == aiFront3.FrontID)
                          ++tweight;
                      }
                      simpleList.Add(tid, tweight);
                    }
                  }
                  simpleList.Sort();
                  if (simpleList.Counter > -1)
                  {
                    AIFront aiFront = TempList.Front[simpleList.Id[0]];
                    tFront.TargetFrontID = aiFront.FrontID;
                    this.AddLog("*NO STRICT RULE* Set target of reserve to frontID = " + aiFront.FrontID.ToString());
                  }
                }
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter2; ++unr)
                {
                  if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].Historical == this.game.Data.UnitObj[unit].Historical)
                  {
                    bool flag4 = false;
                    if (this.game.Data.UnitObj[unr].AIGroup > 0 & this.game.Data.Product >= 6 && TempList.FindFront(this.game.Data.UnitObj[unr].AIGroup).FrontType == 11)
                      flag4 = true;
                    if (!flag4)
                    {
                      if (this.game.Data.UnitObj[unr].TempCategory == 1 | this.game.Data.UnitObj[unr].TempCategory == 5 && unr != unit)
                      {
                        tFront.AddUnit(unr);
                        this.AddLog("Add (norm)unit " + this.game.Data.UnitObj[unr].Name + " to frontID " + tFront.FrontID.ToString());
                        this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
                      }
                      if (this.game.Data.UnitObj[unr].TempCategory == 2 && unr != unit)
                      {
                        tFront.AddArtUnit(unr);
                        this.AddLog("Add (art)unit " + this.game.Data.UnitObj[unr].Name + " to frontID " + tFront.FrontID.ToString());
                        this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
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

    public void InitFrontlinesAddAirFrontlines(ref AIFrontList TempList, ref AIMatrix fronts)
    {
      this.AddLog("ADD AIR COVER + AIR SUPRIORITY FRONTLINES");
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.map.HexObj[index1, index2].Regime == this.GetGameDataTurn() && this.map.HexObj[index1, index2].UnitCounter > -1)
          {
            int unitCounter = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].AIGroup < 0)
              {
                DC2AIClass tai;
                if (this.game.Data.UnitObj[unit].TempCategory == 3)
                {
                  tai = this;
                  AIFront tFront = new AIFront(ref tai, 5);
                  this.AddLog("Add unit (aircover)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                  tFront.AddUnit(unit);
                  this.game.Data.UnitObj[unit].SOInterceptRdnStop = 75;
                  TempList.AddFront(tFront, true);
                  tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                  this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                }
                if (this.game.Data.UnitObj[unit].TempCategory == 13)
                {
                  tai = this;
                  AIFront tFront = new AIFront(ref tai, 4);
                  this.AddLog("Add unit (airsupport)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                  tFront.AddUnit(unit);
                  TempList.AddFront(tFront, true);
                  tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                  this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                }
                if (this.game.Data.UnitObj[unit].TempCategory == 8)
                {
                  tai = this;
                  AIFront tFront = new AIFront(ref tai, 7);
                  this.AddLog("Add unit (airtransport)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                  tFront.AddUnit(unit);
                  TempList.AddFront(tFront, true);
                  tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                  this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                }
              }
            }
          }
        }
      }
    }

    public void InitFrontlinesAddEngineerFrontlines(
      ref AIFrontList TempList,
      ref AIMatrix frontlines)
    {
      this.AddLog("ADD ENGINEER FRONTLINES");
      int mapWidth1 = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.map.HexObj[index1, index2].Regime == this.GetGameDataTurn() && this.map.HexObj[index1, index2].UnitCounter > -1)
          {
            int unitCounter = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].AIGroup < 0 && this.game.Data.UnitObj[unit].TempCategory == 4 & this.game.Data.UnitObj[unit].SFCount > -1)
              {
                DC2AIClass tai = this;
                AIFront tFront = new AIFront(ref tai, 6);
                this.AddLog("Add unit (engineer)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                tFront.AddUnit(unit);
                TempList.AddFront(tFront, true);
                tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
              }
            }
          }
        }
      }
      AIMatrix aiMatrix = frontlines.Clone();
      aiMatrix.SetAllValuesHigherThenXTo(0, 1);
      this.MakeEnemySupplyMatrix();
      int mapWidth2 = this.map.MapWidth;
      for (int cx = 0; cx <= mapWidth2; ++cx)
      {
        int mapHeight = this.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.enemySupplyMatrix.Value[cx, cy] == 9999 & this.GetRegime(this.map.HexObj[cx, cy].Regime) != this.GetGameDataTurn())
          {
            int tfacing = 1;
            do
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && aiMatrix.Value[coordinate.x, coordinate.y] > 0)
                aiMatrix.Value[coordinate.x, coordinate.y] = 0;
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      aiMatrix.ExpandAndAddValueForAnyRegime(8);
      Coordinate[] coordinateArray = new Coordinate[10000];
      int index4 = -1;
      if (index4 == -1)
      {
        int mapWidth3 = this.map.MapWidth;
        for (int x = 0; x <= mapWidth3; ++x)
        {
          int mapHeight = this.map.MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            if (aiMatrix.Value[x, y] > 0 & !(this.GetRegime(this.map.HexObj[x, y].Regime) == this.GetGameDataTurn() & aiMatrix.Value[x, y] > 7) && this.game.HandyFunctionsObj.HasHexBridge(x, y, 0) | this.game.HandyFunctionsObj.HasHexBrokenBridge(x, y, 0))
            {
              ++index4;
              coordinateArray[index4] = new Coordinate();
              coordinateArray[index4].x = x;
              coordinateArray[index4].y = y;
            }
          }
        }
      }
      int num1 = index4;
      for (int index5 = 0; index5 <= num1; ++index5)
      {
        SimpleList simpleList = new SimpleList();
        int counter = TempList.Counter;
        for (int tid = 0; tid <= counter; ++tid)
        {
          if (TempList.Front[tid].FrontType == 6)
          {
            int index6 = TempList.Front[tid].units.unr[0];
            int tweight = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index6].X, this.game.Data.UnitObj[index6].Y, 0, coordinateArray[index5].x, coordinateArray[index5].y, 0);
            simpleList.Add(tid, tweight);
          }
        }
        simpleList.Sort();
        if (simpleList.Counter > -1)
        {
          int index7 = simpleList.Id[0];
          TempList.Front[index7].AddCoord(coordinateArray[index5].x, coordinateArray[index5].y);
        }
      }
      int num2;
      for (bool flag1 = true; num2 < 99 & flag1; ++num2)
      {
        flag1 = false;
        int counter1 = TempList.Counter;
        for (int index8 = 0; index8 <= counter1; ++index8)
        {
          if (TempList.Front[index8].FrontType == 6 && TempList.Front[index8].coordCount >= 1)
          {
            bool flag2 = false;
            int coordCount1 = TempList.Front[index8].coordCount;
            for (int index9 = 0; index9 <= coordCount1; ++index9)
            {
              int num3 = 0;
              int num4 = 0;
              int coordCount2 = TempList.Front[index8].coordCount;
              for (int index10 = 0; index10 <= coordCount2; ++index10)
              {
                int coordCount3 = TempList.Front[index8].coordCount;
                for (int index11 = 0; index11 <= coordCount3; ++index11)
                {
                  if (index10 != index11)
                  {
                    int num5 = this.game.HandyFunctionsObj.Distance(TempList.Front[index8].Coords[index10].x, TempList.Front[index8].Coords[index10].y, 0, TempList.Front[index8].Coords[index11].x, TempList.Front[index8].Coords[index11].y, 0);
                    if (num5 > num3)
                      num3 = num5;
                  }
                }
              }
              int num6 = 0;
              int num7 = 0;
              int coordCount4 = TempList.Front[index8].coordCount;
              for (int index12 = 0; index12 <= coordCount4; ++index12)
              {
                int coordCount5 = TempList.Front[index8].coordCount;
                for (int index13 = 0; index13 <= coordCount5; ++index13)
                {
                  if (index12 != index13 & index13 != index9 & index12 != index9)
                  {
                    int num8 = this.game.HandyFunctionsObj.Distance(TempList.Front[index8].Coords[index12].x, TempList.Front[index8].Coords[index12].y, 0, TempList.Front[index8].Coords[index13].x, TempList.Front[index8].Coords[index13].y, 0);
                    if (num8 > num6)
                      num6 = num8;
                  }
                }
                ++num7;
                int index14 = TempList.Front[index8].units.unr[0];
                int num9 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index14].X, this.game.Data.UnitObj[index14].Y, 0, TempList.Front[index8].Coords[index12].x, TempList.Front[index8].Coords[index12].y, 0);
                if (num9 > num6)
                  num6 = num9;
              }
              int num10 = num6 + num7;
              int counter2 = TempList.Counter;
              for (int index15 = 0; index15 <= counter2; ++index15)
              {
                if (index15 != index8 & TempList.Front[index15].FrontType == 6 && TempList.Front[index15].coordCount <= 25)
                {
                  int num11 = 0;
                  num4 = 0;
                  int coordCount6 = TempList.Front[index15].coordCount;
                  for (int index16 = 0; index16 <= coordCount6; ++index16)
                  {
                    int coordCount7 = TempList.Front[index15].coordCount;
                    for (int index17 = 0; index17 <= coordCount7; ++index17)
                    {
                      if (index16 != index17)
                      {
                        int num12 = this.game.HandyFunctionsObj.Distance(TempList.Front[index15].Coords[index16].x, TempList.Front[index15].Coords[index16].y, 0, TempList.Front[index15].Coords[index17].x, TempList.Front[index15].Coords[index17].y, 0);
                        if (num12 > num11)
                          num11 = num12;
                      }
                    }
                  }
                  int num13 = 0;
                  int num14 = 0;
                  int coordCount8 = TempList.Front[index15].coordCount;
                  for (int index18 = 0; index18 <= coordCount8; ++index18)
                  {
                    int coordCount9 = TempList.Front[index15].coordCount;
                    for (int index19 = 0; index19 <= coordCount9; ++index19)
                    {
                      if (index18 != index19)
                      {
                        int num15 = this.game.HandyFunctionsObj.Distance(TempList.Front[index15].Coords[index18].x, TempList.Front[index15].Coords[index18].y, 0, TempList.Front[index15].Coords[index19].x, TempList.Front[index15].Coords[index19].y, 0);
                        if (num15 > num13)
                          num13 = num15;
                      }
                    }
                    int num16 = this.game.HandyFunctionsObj.Distance(TempList.Front[index8].Coords[index9].x, TempList.Front[index8].Coords[index9].y, 0, TempList.Front[index15].Coords[index18].x, TempList.Front[index15].Coords[index18].y, 0);
                    if (num16 > num13)
                      num13 = num16;
                    ++num14;
                    int x = this.game.Data.UnitObj[TempList.Front[index15].units.unr[0]].X;
                    int y = this.game.Data.UnitObj[TempList.Front[index15].units.unr[0]].Y;
                    int num17 = this.game.HandyFunctionsObj.Distance(x, y, 0, TempList.Front[index15].Coords[index18].x, TempList.Front[index15].Coords[index18].y, 0);
                    if (num17 > num13)
                      num13 = num17;
                    int num18 = this.game.HandyFunctionsObj.Distance(x, y, 0, TempList.Front[index8].Coords[index9].x, TempList.Front[index8].Coords[index9].y, 0);
                    if (num18 > num13)
                      num13 = num18;
                  }
                  int num19 = num14 + 1;
                  if (num13 + num19 < num10)
                  {
                    TempList.Front[index15].AddCoord(TempList.Front[index8].Coords[index9].x, TempList.Front[index8].Coords[index9].y);
                    TempList.Front[index8].RemoveCoord(TempList.Front[index8].Coords[index9].x, TempList.Front[index8].Coords[index9].y);
                    flag2 = true;
                    flag1 = true;
                  }
                  if (flag2)
                    break;
                }
              }
              if (flag2)
                break;
            }
          }
        }
      }
      int counter3 = TempList.Counter;
      for (int index20 = 0; index20 <= counter3; ++index20)
      {
        if (TempList.Front[index20].FrontType == 6 && TempList.Front[index20].coordCount == -1)
          TempList.Front[index20].FrontType = 2;
      }
    }

    public void InitFrontlinesAddNavyFrontlines(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      this.AddLog("ADD NAVY FRONTLINES");
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.map.HexObj[index1, index2].UnitCounter > -1)
          {
            int unitCounter = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unit].AIGroup < 0)
              {
                DC2AIClass tai;
                if (this.game.Data.UnitObj[unit].TempCategory == 7)
                {
                  tai = this;
                  AIFront tFront = new AIFront(ref tai, 8);
                  this.AddLog("Add unit (navy)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                  tFront.AddUnit(unit);
                  TempList.AddFront(tFront, true);
                  tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                  this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                }
                if (this.game.Data.UnitObj[unit].TempCategory == 6)
                {
                  tai = this;
                  AIFront tFront = new AIFront(ref tai, 9);
                  this.AddLog("Add unit (cargo)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                  tFront.AddUnit(unit);
                  TempList.AddFront(tFront, true);
                  tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                  this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                }
              }
            }
          }
        }
      }
    }

    public void InitFrontlinesAddFlakFrontlines(ref AIFrontList TempList, ref AIMatrix frontlines)
    {
      if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) <= 70 | !this.SE1_USEFLAK)
        return;
      DataClass data1 = this.game.Data;
      string str1 = "Zones";
      ref string local1 = ref str1;
      data1.FindLibVar(ref local1, "SE_Data");
      DataClass data2 = this.game.Data;
      string str2 = "aiStrucDam";
      ref string local2 = ref str2;
      int libVar = data2.FindLibVar(ref local2, "SE_Data");
      this.AddLog("");
      this.AddLog("ADD FLAKFRONTLINES");
      this.AddLog("");
      this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      int index1;
      for (int index2 = 0; index2 <= mapWidth1; ++index2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (index1 = 0; index1 <= mapHeight; ++index1)
        {
          if (this.game.Data.MapObj[0].HexObj[index2, index1].Regime == this.game.Data.Turn)
          {
            int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index2, index1].GetHexLibVarValue(libVar);
            aiMatrix1.Value[index2, index1] = hexLibVarValue;
          }
        }
      }
      string libName = "SE_Data";
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      int stringListById4 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      int stringListById5 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 160, 0, 0));
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
      tai2 = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai2);
      int length1 = this.game.Data.StringListObj[stringListById2].Length;
      for (int index3 = 0; index3 <= length1; ++index3)
      {
        int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 0]));
        int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 6]));
        if (id > 0)
        {
          int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
          if (locationById > -1)
          {
            int x = this.game.Data.LocObj[locationById].X;
            int y = this.game.Data.LocObj[locationById].Y;
            if (this.game.Data.MapObj[0].HexObj[x, y].Regime == this.game.Data.Turn & x > -1 & y > -1)
            {
              int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(0, idValue, 1, "city", 2)));
              if (num1 > 0)
              {
                int[,] numArray1 = aiMatrix2.Value;
                int[,] numArray2 = numArray1;
                int index4 = x;
                int index5 = index4;
                int index6 = y;
                int index7 = index6;
                int num2 = numArray1[index4, index6] + num1;
                numArray2[index5, index7] = num2;
              }
            }
          }
        }
      }
      int length2 = this.game.Data.StringListObj[stringListById3].Length;
      for (int index8 = 0; index8 <= length2; ++index8)
      {
        int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index8, 1]));
        int index9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index8, 3]));
        int index10 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index8, 4]));
        if (this.game.Data.MapObj[0].HexObj[index9, index10].Regime == this.game.Data.Turn & index9 > -1 & index10 > -1)
        {
          int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, idValue, 2)));
          if (num3 > 0)
          {
            if (idValue >= 551 & idValue <= 559)
            {
              int d = 0;
              int unitCounter = this.game.Data.MapObj[0].HexObj[index9, index10].UnitCounter;
              for (int index11 = 0; index11 <= unitCounter; ++index11)
              {
                if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.Data.MapObj[0].HexObj[index9, index10].UnitList[index11]))
                  ++d;
              }
              if (d > 0)
                num3 += (int) Math.Round((double) num3 * (2.0 + Math.Sqrt((double) d)));
            }
            int[,] numArray3 = aiMatrix3.Value;
            int[,] numArray4 = numArray3;
            int index12 = index9;
            int index13 = index12;
            int index14 = index10;
            int index15 = index14;
            int num4 = numArray3[index12, index14] + num3;
            numArray4[index13, index15] = num4;
          }
        }
      }
      tai2 = this;
      AIMatrix aiMatrix4 = new AIMatrix(ref tai2);
      int stringListById6 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      int stringListById7 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 228, 0, 0));
      int num5 = 0;
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index16 = 2; index16 <= regimeCounter; ++index16)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, this.game.Data.RegimeObj[index16].id, 1))) == 1 & this.game.Data.Turn != index16)
        {
          int num6 = 0;
          int num7 = 0;
          int length3 = this.game.Data.StringListObj[stringListById7].Length;
          for (int index17 = 0; index17 <= length3; ++index17)
          {
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index17, 2])) == this.game.Data.RegimeObj[index16].id)
            {
              int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index17, 5]));
              if (id > 0)
              {
                int sfTypeById = this.game.HandyFunctionsObj.GetSFTypeByID(id);
                if (this.game.Data.SFTypeObj[sfTypeById].Theater == 2 & this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[4] > 0 & this.game.Data.SFTypeObj[sfTypeById].AirAPRule > 0)
                {
                  int num8 = (int) Math.Round(Math.Floor(100.0 / (double) this.game.Data.SFTypeObj[sfTypeById].AirAPRule));
                  if (this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[18] > 0)
                  {
                    if (num8 > num6)
                      num6 = num8;
                  }
                  else if (num8 > num7)
                    num7 = num8;
                }
              }
            }
          }
          if (num6 <= 0)
          {
            int length4 = this.game.Data.StringListObj[stringListById7].Length;
            for (int index18 = 0; index18 <= length4; ++index18)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index18, 2])) == this.game.Data.RegimeObj[index16].id)
              {
                int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index18, 5]));
                if (id > 0)
                {
                  int sfTypeById = this.game.HandyFunctionsObj.GetSFTypeByID(id);
                  if (this.game.Data.SFTypeObj[sfTypeById].Theater == 2 & this.game.Data.SFTypeObj[sfTypeById].AirAPRule > 0)
                  {
                    int num9 = (int) Math.Round((double) (int) Math.Round(Math.Floor(100.0 / (double) this.game.Data.SFTypeObj[sfTypeById].AirAPRule)) * 0.5);
                    if (this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[18] > 0)
                    {
                      if (num9 > num6)
                        num6 = num9;
                    }
                    else if (num9 > num7)
                      num7 = num9;
                  }
                }
              }
            }
          }
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index19 = 0; index19 <= mapWidth2; ++index19)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (index1 = 0; index1 <= mapHeight; ++index1)
            {
              if (this.game.Data.MapObj[0].HexObj[index19, index1].Regime == index16 && this.game.Data.MapObj[0].HexObj[index19, index1].Location > -1)
                aiMatrix4.Value[index19, index1] = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index19, index1].Location].tempAirfieldLevel <= 0 ? num7 : num6;
            }
          }
          if (num7 > num5)
            num5 = num7;
          if (num6 > num5)
            num5 = num6;
        }
      }
      AIMatrix aiMatrix5 = aiMatrix4.Clone();
      aiMatrix5.MultiplyAllValues(4);
      aiMatrix4.ExpandValueWithoutConditionsDimishWithOneAndOverwriteSmaller(num5 + 1);
      aiMatrix5.ExpandValueWithoutConditionsDimishWithOneAndOverwriteSmaller(4 * num5 + 4);
      this.AddLog("Meta Best Range Enemy Air: " + num5.ToString());
      SimpleList simpleList1 = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int tid = 0; tid <= unitCounter1; ++tid)
      {
        if (this.game.Data.UnitObj[tid].PreDef == -1 & this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].TempCategory == 5)
        {
          int tdata2 = -1;
          int tdata3 = -1;
          int tdata4 = -1;
          int tdata5 = 100;
          int num10 = 2;
          int num11 = 0;
          if (this.game.Data.UnitObj[tid].AIAttack == 1)
          {
            tdata2 = this.game.Data.UnitObj[tid].AILeftFlank;
            tdata3 = this.game.Data.UnitObj[tid].AIRightFlank;
            if (tdata2 < 0 | tdata3 < 0)
            {
              tdata2 = -1;
              tdata3 = -1;
            }
            if (tdata2 > 0 & tdata3 > 0)
              tdata2 = tdata2;
            tdata4 = 0;
          }
          SimpleList simpleList2 = new SimpleList();
          if (this.game.Data.UnitObj[tid].AIid == 1276)
            tdata2 = tdata2;
          if (!Information.IsNothing((object) this.game.Data.UnitObj[tid].prevTurnAiFrontHexes))
          {
            int counter = this.game.Data.UnitObj[tid].prevTurnAiFrontHexes.counter;
            for (int index20 = 0; index20 <= counter; ++index20)
            {
              int x = this.game.Data.UnitObj[tid].prevTurnAiFrontHexes.coord[index20].x;
              int y = this.game.Data.UnitObj[tid].prevTurnAiFrontHexes.coord[index20].y;
              if (this.frontMatrix.Value[x, y] > 0)
                simpleList2.AddWeight(this.frontMatrix.Value[x, y], 1);
            }
          }
          if (this.game.Data.UnitObj[tid].SFCount > -1)
          {
            int type = this.game.Data.SFObj[this.game.Data.UnitObj[tid].SFList[0]].Type;
            int num12 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(0, this.game.Data.SFTypeObj[type].SFTypeVar[81], 1)));
            if (num12 == 133)
            {
              tdata5 = 50;
              num10 = 1;
            }
            if (num12 == 132)
            {
              tdata5 = 200;
              num10 = 2;
            }
            if (num12 == 131)
            {
              tdata5 = 100;
              num10 = 4;
            }
            int sfCount = this.game.Data.UnitObj[tid].SFCount;
            for (int index21 = 0; index21 <= sfCount; ++index21)
            {
              int sf = this.game.Data.UnitObj[tid].SFList[index21];
              num11 += this.game.Data.SFObj[sf].Qty;
            }
          }
          if (simpleList2.Counter > -1)
          {
            simpleList2.ReverseSortHighSpeed();
            tdata4 = simpleList2.Id[0];
          }
          int tweight = 1 + (int) Math.Round(Math.Ceiling((double) (num10 * num11) / 5.0));
          this.AddLog("Flak Unit: " + this.game.Data.UnitObj[tid].Name + " (weight: " + tweight.ToString() + ")");
          simpleList1.Add(tid, tweight, tdata2: tdata2, tdata3: tdata3, tdata4: tdata4, tdata5: tdata5);
        }
      }
      this.AddLog("");
      SimpleList simpleList3 = new SimpleList();
      bool flag1 = true;
      int num13 = 0;
      SimpleList simpleList4 = new SimpleList();
      SimpleList simpleList5 = new SimpleList();
      while (flag1)
      {
        flag1 = false;
        ++num13;
        this.AddLog("--------------------------------------");
        this.AddLog("Flak_Loop " + num13.ToString());
        this.AddLog("--------------------------------------");
        SimpleList simpleList6 = new SimpleList();
        int tweight = 0;
        int num14 = 0;
        int num15 = 0;
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        int index22;
        for (index22 = 0; index22 <= mapWidth3; ++index22)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (index1 = 0; index1 <= mapHeight; ++index1)
          {
            if (this.game.Data.MapObj[0].HexObj[index22, index1].Regime == this.game.Data.Turn && aiMatrix4.Value[index22, index1] > 0 | aiMatrix5.Value[index22, index1] > 0)
            {
              tweight = aiMatrix2.Value[index22, index1] * 2;
              tweight += aiMatrix3.Value[index22, index1];
              num15 += aiMatrix3.Value[index22, index1];
              float a = 0.0f;
              if (aiMatrix1.Value[index22, index1] < 1)
              {
                if (aiMatrix2.Value[index22, index1] > 0)
                  a = 2f;
              }
              else
                a = aiMatrix1.Value[index22, index1] > 10 ? (aiMatrix1.Value[index22, index1] > 40 ? (aiMatrix1.Value[index22, index1] > 90 ? (aiMatrix1.Value[index22, index1] > 160 ? (aiMatrix1.Value[index22, index1] > 320 ? (aiMatrix1.Value[index22, index1] > 500 ? (aiMatrix1.Value[index22, index1] > 1000 ? 8f : 7f) : 6f) : 5f) : 4f) : 3.2f) : 2.5f) : 2f;
              num14 += aiMatrix1.Value[index22, index1];
              int weight = simpleList3.FindWeight(-1, index22, index1, 0);
              int tdata5 = 0;
              if (weight > 0)
                tdata5 = weight;
              if ((double) tdata5 >= (double) a)
                tweight = 0;
              else if ((double) a > 0.0)
                tweight = (int) Math.Round((double) ((float) tweight * a / (float) (tdata5 + 1)));
              if (aiMatrix4.Value[index22, index1] < 1)
              {
                tweight = (int) Math.Round((double) tweight / 4.0);
                if (aiMatrix2.Value[index22, index1] < 1)
                  tweight = 0;
              }
              if (simpleList4.FindNr(-1, index22, index1) > -1)
                tweight = 0;
              if (tweight > 0 | tdata5 > 0)
              {
                this.AddLog("Hex " + index22.ToString() + "," + index1.ToString() + ", " + this.game.HandyFunctionsObj.GetHexName(index22, index1, 0) + " : Score = " + tweight.ToString() + " assigned/ideal: " + tdata5.ToString() + "/" + a.ToString());
                simpleList6.Add(index22 * 1000 + index1, tweight, index22, index1, tdata4: ((int) Math.Round((double) a)), tdata5: tdata5);
              }
            }
          }
        }
        int num16 = 0;
        int num17 = 0;
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index23 = 0; index23 <= sfTypeCounter; ++index23)
        {
          int idValue = this.game.Data.SFTypeObj[index23].SFTypeVar[81];
          if (idValue > 0 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(0, idValue, 2))) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
          {
            num16 += this.game.Data.SFTypeObj[index23].SFTypeVar[1];
            num17 += this.game.Data.SFTypeObj[index23].SFTypeVar[3];
          }
        }
        int num18 = num16 <= 0 ? 0 : (int) Math.Round((double) (num17 * 100) / (double) num16);
        SimpleList simpleList7 = new SimpleList();
        int counter1 = this.frontList.Counter;
        for (int index24 = 0; index24 <= counter1; ++index24)
        {
          AIFront aiFront = this.frontList.Front[index24];
          if (aiFront.FrontType == 1)
          {
            int powerUnderFront = aiFront.GetPowerUnderFront(true);
            if (aiFront.units.counter > -1 & powerUnderFront > 0)
            {
              tweight = (int) Math.Round(Math.Sqrt((double) powerUnderFront));
              float num19;
              if (aiFront.enemyPower > 0)
              {
                num19 = (float) aiFront.enemyPower / (float) powerUnderFront;
                if ((double) num19 > 2.0)
                  num19 = 2f;
                if ((double) num19 < 0.5)
                  num19 = 0.5f;
              }
              else
                num19 = 0.5f;
              tweight = (int) Math.Round((double) ((float) tweight * num19));
              int num20 = 0;
              int num21 = 0;
              int num22 = 0;
              int counter2 = aiFront.units.counter;
              for (int index25 = 0; index25 <= counter2; ++index25)
              {
                int index26 = aiFront.units.unr[index25];
                ++num20;
                if (aiMatrix5.Value[this.game.Data.UnitObj[index26].X, this.game.Data.UnitObj[index26].Y] > 0)
                  ++num21;
                if (aiMatrix4.Value[this.game.Data.UnitObj[index26].X, this.game.Data.UnitObj[index26].Y] > 0)
                  ++num22;
              }
              if (num20 > 0 & num21 > 0)
              {
                float num23 = (float) num21 / (float) num20;
                tweight = (int) Math.Round((double) ((float) tweight * num23));
                if (num22 < 1)
                  tweight = (int) Math.Round((double) tweight / 4.0);
                float a = 1f;
                if (num18 <= 1)
                {
                  if (aiFront.HasTopUnits())
                    a = 2f;
                }
                else
                  a = num18 > 5 ? (num18 > 10 ? (num18 > 20 ? (num18 > 40 ? (num18 > 60 ? 10f : 9f) : 7f) : 5f) : 4f) : 3f;
                int weight = simpleList3.FindWeight(-1, 0, 0, aiFront.FrontID);
                int tdata5 = 0;
                if (weight > 0)
                  tdata5 = weight;
                if ((double) tdata5 >= (double) a)
                {
                  tweight = (int) Math.Round((double) ((float) tweight * a / (float) (tdata5 + 1)));
                  if (tweight < 1)
                    tweight = 1;
                }
                else if ((double) a > 0.0)
                  tweight = (int) Math.Round((double) ((float) tweight * a / (float) (tdata5 + 1)));
                if (simpleList5.FindNr(-1, aiFront.FrontID) > -1)
                  tweight = 0;
                if (tweight > 0 | tdata5 > 0)
                {
                  this.AddLog("Front " + aiFront.FrontID.ToString() + "  : Score = " + tweight.ToString() + " assigned/ideal: " + tdata5.ToString() + "/" + a.ToString());
                  simpleList7.Add(aiFront.FrontID, tweight, tdata3: aiFront.FrontID, tdata4: ((int) Math.Round((double) a)), tdata5: tdata5);
                }
              }
            }
          }
        }
        simpleList6.Percentify();
        simpleList7.Percentify();
        int counter3 = simpleList6.Counter;
        for (int index27 = 0; index27 <= counter3; ++index27)
        {
          if (simpleList6.Data5[index27] > 0 & simpleList6.Data4[index27] > 0)
          {
            int[] weight = simpleList6.Weight;
            int[] numArray = weight;
            int index28 = index27;
            int index29 = index28;
            int num24 = weight[index28] - (int) Math.Round((double) (simpleList6.Weight[index27] * simpleList6.Data4[index27]) / (double) simpleList6.Data5[index27]);
            numArray[index29] = num24;
          }
        }
        int counter4 = simpleList7.Counter;
        for (int index30 = 0; index30 <= counter4; ++index30)
        {
          if (simpleList7.Data5[index30] > 0 & simpleList7.Data4[index30] > 0)
          {
            int[] weight = simpleList7.Weight;
            int[] numArray = weight;
            int index31 = index30;
            int index32 = index31;
            int num25 = weight[index31] - (int) Math.Round((double) (simpleList7.Weight[index30] * simpleList7.Data4[index30]) / (double) simpleList7.Data5[index30]);
            numArray[index32] = num25;
          }
        }
        float d = (float) num14 / (float) (num15 + 1) / (float) (num18 + 5);
        d = (float) Math.Sqrt((double) d);
        if ((double) d < 0.2)
          d = 0.2f;
        if ((double) d > 4.0)
          d = 4f;
        this.AddLog("HEX MODDY = " + d.ToString());
        int counter5 = simpleList6.Counter;
        for (int index33 = 0; index33 <= counter5; ++index33)
          simpleList6.Weight[index33] = (int) Math.Round((double) ((float) simpleList6.Weight[index33] * d));
        int num26 = 0;
        int num27 = -1;
        int num28 = 0;
        int num29 = -1;
        int num30 = -1;
        simpleList6.ReverseSortHighSpeed();
        simpleList7.ReverseSortHighSpeed();
        if (simpleList6.Counter > -1 && simpleList6.Weight[0] > 0)
        {
          num28 = simpleList6.Weight[0];
          num29 = simpleList6.Data1[0];
          num30 = simpleList6.Data2[0];
        }
        if (simpleList7.Counter > -1 && simpleList7.Weight[0] > 0)
        {
          num26 = simpleList7.Weight[0];
          num27 = simpleList7.Data3[0];
        }
        if (num28 >= num26 & num29 > -1)
        {
          this.AddLog("Highest Score: HEX " + num29.ToString() + "," + num30.ToString());
          int num31 = -1;
          int index34 = -1;
          tweight = 0;
          bool flag2 = false;
          int counter6 = simpleList1.Counter;
          for (int index35 = 0; index35 <= counter6; ++index35)
          {
            if (simpleList1.Data1[index35] < 1)
            {
              int index36 = simpleList1.Id[index35];
              flag2 = true;
              index22 = this.game.Data.UnitObj[index36].X;
              index1 = this.game.Data.UnitObj[index36].Y;
              int num32 = this.game.HandyFunctionsObj.Distance(index22, index1, 0, num29, num30, 0, 199);
              int num33 = num32 * num32;
              if (num33 > 900)
                num33 = 900 + (int) Math.Round((double) (num33 - 900) * 0.66);
              if (num33 > 1000)
                num33 = 1000 + (int) Math.Round((double) (num33 - 1000) * 0.33);
              if (num33 > 1100)
                num33 = 1100 + (int) Math.Round((double) (num33 - 1100) * 0.11);
              if (num33 > 1190)
                num33 = 1190;
              tweight = num33 >= 1200 ? 0 : 1200 - num33;
              if (simpleList1.Data2[index35] > -1 && simpleList1.Data2[index35] == num29 & simpleList1.Data3[index35] == num30)
                tweight *= 3;
              tweight = (int) Math.Round((double) (tweight * simpleList1.Data5[index35]) / 100.0);
              if (tweight > num26)
              {
                num26 = tweight;
                num31 = index36;
                index34 = index35;
              }
            }
          }
          if (index34 > -1)
          {
            flag1 = true;
            tai2 = this;
            AIFront tFront = new AIFront(ref tai2, 10);
            int unr = num31;
            if (this.game.Data.UnitObj[unr].AIGroup > -1)
            {
              int frontNr = this.frontList.GetFrontNr(this.game.Data.UnitObj[unr].AIGroup);
              if (frontNr > -1)
                this.frontList.Front[frontNr].RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
            }
            tFront.AddUnit(unr);
            if (tFront.FrontID < 1)
              tFront.FrontID = this.game.Data.UnitObj[unr].AIid;
            this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
            this.game.Data.UnitObj[unr].AIReserve = true;
            TempList.AddFront(tFront, false);
            tFront.targetX = num29;
            tFront.targetY = num30;
            simpleList1.Data1[index34] = 1;
            int weight = simpleList3.FindWeight(-1, index22, index1, 0);
            this.AddLog("*Assigned " + this.game.Data.UnitObj[unr].Name + " to " + num29.ToString() + "," + num30.ToString() + ".");
            if (weight < 1)
              simpleList3.Add(index22 * 1000 + index1, simpleList1.Weight[index34], num29, num30);
            else
              simpleList3.AddWeight(index22 * 1000 + index1, simpleList1.Weight[index34], num29, num30, CheckExistence: false);
          }
          else
          {
            if (flag2)
              flag1 = true;
            simpleList4.Add(num29 * 1000 + num30, 1, num29, num30);
          }
        }
        else if (num27 > -1)
        {
          this.AddLog("Highest Score: FRONT " + num27.ToString());
          int num34 = -1;
          int index37 = -1;
          AIFront front = TempList.FindFront(num27);
          bool flag3 = false;
          tweight = 0;
          int counter7 = simpleList1.Counter;
          for (int index38 = 0; index38 <= counter7; ++index38)
          {
            if (simpleList1.Data1[index38] < 1)
            {
              int index39 = simpleList1.Id[index38];
              flag3 = true;
              int x = this.game.Data.UnitObj[index39].X;
              index1 = this.game.Data.UnitObj[index39].Y;
              int num35 = 0;
              int num36 = 0;
              int counter8 = front.units.counter;
              for (int index40 = 0; index40 <= counter8; ++index40)
              {
                num35 += this.game.HandyFunctionsObj.Distance(x, index1, 0, this.game.Data.UnitObj[front.units.unr[index40]].X, this.game.Data.UnitObj[front.units.unr[index40]].Y, 0, 199);
                ++num36;
              }
              int counter9 = front.artUnits.counter;
              for (int index41 = 0; index41 <= counter9; ++index41)
              {
                num35 += this.game.HandyFunctionsObj.Distance(x, index1, 0, this.game.Data.UnitObj[front.artUnits.unr[index41]].X, this.game.Data.UnitObj[front.artUnits.unr[index41]].Y, 0, 199);
                ++num36;
              }
              if (num36 > 0)
              {
                int num37 = (int) Math.Round((double) num35 / (double) num36);
                tweight = num37 >= 600 ? 0 : 600 - num37;
                if (simpleList1.Data4[index38] == front.FrontID)
                  tweight *= 3;
                tweight = (int) Math.Round((double) (tweight * 100) / (double) simpleList1.Data5[index38]);
                if (tweight > num26)
                {
                  num26 = tweight;
                  num34 = index39;
                  index37 = index38;
                }
              }
            }
          }
          if (index37 > -1)
          {
            flag1 = true;
            AIFront aiFront = (AIFront) null;
            int counter10 = TempList.Counter;
            for (int index42 = 0; index42 <= counter10; ++index42)
            {
              if (TempList.Front[index42].FrontType == 13 && TempList.Front[index42].TargetFrontID == num27)
                aiFront = TempList.Front[index42];
            }
            if (Information.IsNothing((object) aiFront))
            {
              tai2 = this;
              aiFront = new AIFront(ref tai2, 13);
              TempList.AddFront(aiFront, false);
            }
            int unr = num34;
            if (this.game.Data.UnitObj[unr].AIGroup > -1)
            {
              int frontNr = this.frontList.GetFrontNr(this.game.Data.UnitObj[unr].AIGroup);
              if (frontNr > -1)
                this.frontList.Front[frontNr].RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
            }
            aiFront.AddUnit(unr);
            if (aiFront.FrontID < 1)
              aiFront.FrontID = this.game.Data.UnitObj[unr].AIid;
            this.game.Data.UnitObj[unr].AIGroup = aiFront.FrontID;
            this.game.Data.UnitObj[unr].AIReserve = true;
            aiFront.TargetFrontID = num27;
            simpleList1.Data1[index37] = 1;
            int weight = simpleList3.FindWeight(-1, tdata3: num27);
            this.AddLog("*Assigned " + this.game.Data.UnitObj[unr].Name + " to Front ID # " + num27.ToString() + ".");
            if (weight < 1)
              simpleList3.Add(1000000 + num27, simpleList1.Weight[index37], tdata3: num27);
            else
              simpleList3.AddWeight(1000000 + num27, simpleList1.Weight[index37], tdata3: num27, CheckExistence: false);
          }
          else
          {
            simpleList5.Add(num27 + 1000000, 1, num27);
            if (flag3)
              flag1 = true;
          }
        }
        if (num13 > 249)
          flag1 = false;
        if (!flag1)
        {
          int setValue1 = 0;
          int setValue2 = 0;
          int setValue3 = 0;
          int setValue4 = 0;
          int counter11 = simpleList6.Counter;
          for (int index43 = 0; index43 <= counter11; ++index43)
          {
            setValue1 += simpleList6.Data4[index43];
            setValue2 += simpleList6.Data5[index43];
          }
          int counter12 = simpleList7.Counter;
          for (int index44 = 0; index44 <= counter12; ++index44)
          {
            setValue3 += simpleList7.Data4[index44];
            setValue4 += simpleList7.Data5[index44];
          }
          this.game.Data.StringListObj[stringListById1].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "Ai_IdealFlakCity", 2, setValue1, true);
          this.game.Data.StringListObj[stringListById1].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "Ai_CurrentFlakCity", 2, setValue2, true);
          this.game.Data.StringListObj[stringListById1].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "Ai_IdealFlakUnit", 2, setValue3, true);
          this.game.Data.StringListObj[stringListById1].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "Ai_CurrentFlakUnit", 2, setValue4, true);
        }
      }
    }

    public void InitFrontlinesAddStrategicReserveFrontlines(
      ref AIFrontList TempList,
      ref AIMatrix frontlines)
    {
      this.AddLog("ADD STRATEGIC RESERVE FRONTLINES");
      AIMatrix mask = this.SetOwnerMatrix(0, 0, this.map.MapWidth, this.map.MapHeight);
      if (this.game.Data.Turn == 14)
      {
        int num1 = num1;
      }
      AIMatrix aiMatrix = mask.Clone();
      aiMatrix.SetValueXToValueY(0, 2);
      aiMatrix.RemoveValuesByMask(mask, 1);
      aiMatrix.ExpandAndAddValueForAnyRegime(this.VAR_FRONTLINE_DEPTH + 3 + Math.Max(this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE, this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE));
      aiMatrix.SetAllValuesSubtractWith(2);
      int num2 = 2;
      if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 71 & this.SE1_USEFLAK)
        num2 = 1;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
          this.game.Data.UnitObj[index].AIReserve = false;
      }
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int num3 = num2;
      for (int index1 = 1; index1 <= num3; ++index1)
      {
        int phase = 1;
        do
        {
          bool frontline = this.CustomCalls.CustomStrategicReserveDelegateToFrontline(phase);
          int mapWidth = this.map.MapWidth;
          for (int x = 0; x <= mapWidth; ++x)
          {
            int mapHeight = this.map.MapHeight;
            for (int y = 0; y <= mapHeight; ++y)
            {
              if (this.map.HexObj[x, y].Regime == this.game.Data.Turn & this.map.HexObj[x, y].Location > -1 & this.map.HexObj[x, y].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[x, y] > 0)
              {
                bool flag = false;
                if (index1 == 1)
                {
                  if (this.VAR_GARRISON_RULE1_MIN_VP > 0 && this.map.HexObj[x, y].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[x, y] >= this.VAR_GARRISON_RULE1_MIN_VP & this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE > 0 && aiMatrix.Value[x, y] > 0 & aiMatrix.Value[x, y] <= this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE && aiMatrix.Value[x, y] > this.VAR_FRONTLINE_DEPTH | !frontline)
                  {
                    if (phase == 2 & this.game.Data.Product < 6)
                      flag = true;
                    if (phase == 3 & this.game.Data.Product >= 6)
                      flag = true;
                  }
                  if (this.VAR_GARRISON_MIN_VP_ALWAYS > 0 && this.map.HexObj[x, y].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[x, y] >= this.VAR_GARRISON_MIN_VP_ALWAYS && aiMatrix.Value[x, y] > this.VAR_FRONTLINE_DEPTH | !frontline | aiMatrix.Value[x, y] <= 0)
                  {
                    if (phase == 3 & this.game.Data.Product < 6)
                      flag = true;
                    if (phase == 2 & this.game.Data.Product >= 6)
                      flag = true;
                  }
                  if (this.VAR_GARRISON_RULE2_MIN_VP > 0 && this.map.HexObj[x, y].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[x, y] >= this.VAR_GARRISON_RULE2_MIN_VP & this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE > 0 && aiMatrix.Value[x, y] > 0 & aiMatrix.Value[x, y] <= this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE && aiMatrix.Value[x, y] > this.VAR_FRONTLINE_DEPTH | !frontline && phase == 4)
                    flag = true;
                  if (this.game.HandyFunctionsObj.IsHexPort(x, y, 0) & this.game.HandyFunctionsObj.IsHexNextToSea(x, y, 0) & this.VAR_GARRISON_PORT_ALWAYS && aiMatrix.Value[x, y] > this.VAR_FRONTLINE_DEPTH | !frontline | aiMatrix.Value[x, y] <= 0 && phase == 1)
                    flag = true;
                }
                else if (index1 == 2 & phase == 1 && this.game.Data.MapObj[0].HexObj[x, y].UnitCounter > -1 && this.game.HandyFunctionsObj.IsHexAirfield(x, y, 0))
                {
                  int unitCounter2 = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
                  for (int index2 = 0; index2 <= unitCounter2; ++index2)
                  {
                    if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.Data.MapObj[0].HexObj[x, y].UnitList[index2]))
                      flag = true;
                  }
                }
                if (flag)
                {
                  int[,] numArray2 = numArray1;
                  int[,] numArray3 = numArray2;
                  int index3 = x;
                  int index4 = index3;
                  int index5 = y;
                  int index6 = index5;
                  int num4 = numArray2[index3, index5] + 1;
                  numArray3[index4, index6] = num4;
                }
              }
            }
          }
          ++phase;
        }
        while (phase <= 4);
      }
      int num5 = num2;
      for (int index7 = 1; index7 <= num5; ++index7)
      {
        int phase = 1;
        do
        {
          bool frontline = this.CustomCalls.CustomStrategicReserveDelegateToFrontline(phase);
          int mapWidth = this.map.MapWidth;
          for (int index8 = 0; index8 <= mapWidth; ++index8)
          {
            int mapHeight = this.map.MapHeight;
            for (int index9 = 0; index9 <= mapHeight; ++index9)
            {
              if (this.map.HexObj[index8, index9].Regime == this.game.Data.Turn & this.map.HexObj[index8, index9].Location > -1 & this.map.HexObj[index8, index9].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index8, index9] > 0)
              {
                bool flag1 = false;
                if (index7 == 1)
                {
                  if (this.VAR_GARRISON_RULE1_MIN_VP > 0 && this.map.HexObj[index8, index9].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index8, index9] >= this.VAR_GARRISON_RULE1_MIN_VP & this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE > 0 && aiMatrix.Value[index8, index9] > 0 & aiMatrix.Value[index8, index9] <= this.VAR_GARRISON_RULE1_MAX_ENEMY_DISTANCE && aiMatrix.Value[index8, index9] > this.VAR_FRONTLINE_DEPTH | !frontline)
                  {
                    if (phase == 2 & this.game.Data.Product < 6)
                      flag1 = true;
                    if (phase == 3 & this.game.Data.Product >= 6)
                      flag1 = true;
                  }
                  if (this.VAR_GARRISON_MIN_VP_ALWAYS > 0 && this.map.HexObj[index8, index9].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index8, index9] >= this.VAR_GARRISON_MIN_VP_ALWAYS && aiMatrix.Value[index8, index9] > this.VAR_FRONTLINE_DEPTH | !frontline | aiMatrix.Value[index8, index9] <= 0)
                  {
                    if (phase == 3 & this.game.Data.Product < 6)
                      flag1 = true;
                    if (phase == 2 & this.game.Data.Product >= 6)
                      flag1 = true;
                  }
                  if (this.VAR_GARRISON_RULE2_MIN_VP > 0 && this.map.HexObj[index8, index9].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index8, index9] >= this.VAR_GARRISON_RULE2_MIN_VP & this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE > 0 && aiMatrix.Value[index8, index9] > 0 & aiMatrix.Value[index8, index9] <= this.VAR_GARRISON_RULE2_MAX_ENEMY_DISTANCE && aiMatrix.Value[index8, index9] > this.VAR_FRONTLINE_DEPTH | !frontline && phase == 4)
                    flag1 = true;
                  if (this.game.HandyFunctionsObj.IsHexPort(index8, index9, 0) & this.game.HandyFunctionsObj.IsHexNextToSea(index8, index9, 0) & this.VAR_GARRISON_PORT_ALWAYS && aiMatrix.Value[index8, index9] > this.VAR_FRONTLINE_DEPTH | !frontline | aiMatrix.Value[index8, index9] <= 0 && phase == 1)
                    flag1 = true;
                }
                else if (index7 == 2 & phase == 1 && this.game.Data.MapObj[0].HexObj[index8, index9].UnitCounter > -1 && this.game.HandyFunctionsObj.IsHexAirfield(index8, index9, 0))
                {
                  int unitCounter3 = this.game.Data.MapObj[0].HexObj[index8, index9].UnitCounter;
                  for (int index10 = 0; index10 <= unitCounter3; ++index10)
                  {
                    if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.Data.MapObj[0].HexObj[index8, index9].UnitList[index10]))
                      flag1 = true;
                  }
                }
                if (flag1)
                {
                  DC2AIClass tai = this;
                  AIFront tFront = new AIFront(ref tai, 10);
                  SimpleList simpleList = new SimpleList();
                  int unitCounter4 = this.game.Data.UnitCounter;
                  for (int index11 = 0; index11 <= unitCounter4; ++index11)
                  {
                    if ((this.game.Data.UnitObj[index11].AIGroup == -1 | this.game.Data.Product == 7) & this.game.Data.UnitObj[index11].Historical > -1 & !this.game.Data.UnitObj[index11].TempTopUnit)
                    {
                      bool flag2 = false;
                      if (this.game.Data.UnitObj[index11].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index11].X > -1)
                      {
                        if (index7 == 1 && this.game.Data.UnitObj[index11].TempCategory == 1 & !this.game.Data.UnitObj[index11].IsHQ & this.game.HandyFunctionsObj.HasUnitlandSF(index11) && this.GetAIRolePercent(index11, 6) >= 50 & this.game.Data.UnitObj[index11].TempUnitPowerAbs > 7)
                          flag2 = true;
                        if (index7 == 2 && this.game.Data.UnitObj[index11].TempCategory == 5)
                          flag2 = true;
                        if (this.game.Data.UnitObj[index11].AIGroup > -1)
                        {
                          int frontNr = this.frontList.GetFrontNr(this.game.Data.UnitObj[index11].AIGroup);
                          if (frontNr > -1 && this.frontList.Front[frontNr].FrontType == 10)
                            flag2 = false;
                        }
                        if (numArray1[this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y] > 0 && !(index8 == this.game.Data.UnitObj[index11].X & index9 == this.game.Data.UnitObj[index11].Y))
                          flag2 = false;
                        if (flag2)
                        {
                          int num6 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y, 0, index8, index9, 0, 99);
                          if (num6 < 99)
                          {
                            if (aiMatrix.Value[index8, index9] > 3 && num6 < 3)
                              num6 = 3;
                            int tweight = num6 * 10000 + this.game.Data.UnitObj[index11].Historical;
                            if (this.game.Data.UnitObj[index11].AIAttack == 1 & this.game.Data.UnitObj[index11].AILeftFlank == index8 & this.game.Data.UnitObj[index11].AIRightFlank == index9)
                            {
                              tweight = (int) Math.Round((double) tweight / 10.0);
                              if (aiMatrix.Value[index8, index9] < 6)
                                tweight = (int) Math.Round((double) tweight / 10.0);
                              if (aiMatrix.Value[index8, index9] < 3)
                                tweight = (int) Math.Round((double) tweight / 10.0);
                            }
                            else if (this.game.Data.UnitObj[index11].AIAttack == 1)
                            {
                              if (aiMatrix.Value[this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y] < 6 & num6 >= 4)
                                tweight *= 2;
                              if (aiMatrix.Value[this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y] < 3 & num6 >= 3)
                                tweight *= 4;
                            }
                            if ((double) this.CustomCalls.StrategicReserveModForUnit(index11) < 9999.0)
                              simpleList.Add(index11, tweight);
                          }
                        }
                      }
                    }
                  }
                  simpleList.Sort();
                  if (simpleList.Counter > -1)
                  {
                    int index12 = simpleList.Id[0];
                    if (numArray1[index8, index9] > 0)
                    {
                      int[,] numArray4 = numArray1;
                      int[,] numArray5 = numArray4;
                      int index13 = index8;
                      int index14 = index13;
                      int index15 = index9;
                      int index16 = index15;
                      int num7 = numArray4[index13, index15] - 1;
                      numArray5[index14, index16] = num7;
                    }
                    int unitCounter5 = this.game.Data.UnitCounter;
                    for (int unr = 0; unr <= unitCounter5; ++unr)
                    {
                      if (this.game.Data.Product == 7)
                      {
                        if (this.game.Data.UnitObj[index12].Historical == this.game.Data.UnitObj[unr].Historical && this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1)
                        {
                          if (this.game.Data.UnitObj[unr].AIGroup > -1)
                          {
                            int frontNr = this.frontList.GetFrontNr(this.game.Data.UnitObj[unr].AIGroup);
                            if (frontNr > -1)
                              this.frontList.Front[frontNr].RemoveUnitAIid(this.game.Data.UnitObj[unr].AIid);
                          }
                          tFront.AddUnit(unr);
                          if (tFront.FrontID < 1)
                            tFront.FrontID = this.game.Data.UnitObj[unr].AIid;
                          this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
                          this.game.Data.UnitObj[unr].AIReserve = true;
                        }
                      }
                      else if (this.game.Data.UnitObj[unr].AIGroup == -1 && this.game.Data.UnitObj[index12].Historical == this.game.Data.UnitObj[unr].Historical && this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1)
                      {
                        tFront.AddUnit(unr);
                        if (tFront.FrontID < 1)
                          tFront.FrontID = this.game.Data.UnitObj[unr].AIid;
                        this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
                        this.game.Data.UnitObj[unr].AIReserve = true;
                      }
                    }
                    TempList.AddFront(tFront, false);
                    tFront.targetX = index8;
                    tFront.targetY = index9;
                  }
                }
              }
            }
          }
          ++phase;
        }
        while (phase <= 4);
      }
    }

    public void InitFrontlinesAddReserveArtilleryFrontlines(
      ref AIFrontList TempList,
      ref AIMatrix fronts)
    {
      this.AddLog("ADD RESERVE ARTILLERY FRONTLINES");
      int mapWidth = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.map.HexObj[index1, index2].Regime == this.GetGameDataTurn() && this.map.HexObj[index1, index2].UnitCounter > -1)
          {
            int unitCounter1 = this.map.HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter1; ++index3)
            {
              int unit = this.map.HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].AIGroup < 0 && this.game.Data.UnitObj[unit].TempCategory == 2)
              {
                DC2AIClass tai = this;
                AIFront tFront = new AIFront(ref tai, 3);
                tFront.AddArtUnit(unit);
                TempList.AddFront(tFront, true);
                tFront.FrontID = this.game.Data.UnitObj[unit].Historical * 10;
                this.AddLog("Add unit (art)" + this.game.Data.UnitObj[unit].Name + " to frontID " + tFront.FrontID.ToString());
                this.game.Data.UnitObj[unit].AIGroup = tFront.FrontID;
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter2; ++unr)
                {
                  if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].Historical == this.game.Data.UnitObj[unit].Historical && this.game.Data.UnitObj[unr].TempCategory == 2 && unr != unit)
                  {
                    tFront.AddArtUnit(unr);
                    this.AddLog("Add unit (art)" + this.game.Data.UnitObj[unr].Name + " to frontID " + tFront.FrontID.ToString());
                    this.game.Data.UnitObj[unr].AIGroup = tFront.FrontID;
                  }
                }
              }
            }
          }
        }
      }
    }

    public void InitFrontlinesJoinEmptyFrontToFullFront(
      AIMatrix frontmatrix,
      ref AIFrontList tempList)
    {
      int maxdistance = 19;
      for (int counter1 = tempList.Counter; counter1 >= 0; counter1 += -1)
      {
        AIFront aiFront = tempList.Front[counter1];
        if (aiFront.units.counter == -1)
        {
          SimpleList simpleList1 = new SimpleList();
          int counter2 = aiFront.removelist.counter;
          for (int index = 0; index <= counter2; ++index)
          {
            if (this.game.Data.UnitObj[aiFront.removelist.unr[index]].AIGroup > -1)
              simpleList1.Add(this.game.Data.UnitObj[aiFront.removelist.unr[index]].AIGroup, 1);
          }
          SimpleList simpleList2 = new SimpleList();
          int mapWidth = this.map.MapWidth;
          for (int x1 = 0; x1 <= mapWidth; ++x1)
          {
            int mapHeight = this.map.MapHeight;
            for (int y1 = 0; y1 <= mapHeight; ++y1)
            {
              if (frontmatrix.Value[x1, y1] == aiFront.FrontID)
              {
                int num1 = x1 - (maxdistance + 1);
                int num2 = x1 + (maxdistance + 1);
                for (int x2 = num1; x2 <= num2; ++x2)
                {
                  int num3 = y1 - (maxdistance + 1);
                  int num4 = y1 + (maxdistance + 1);
                  for (int y2 = num3; y2 <= num4; ++y2)
                  {
                    if (x2 <= frontmatrix.Width & x2 >= 0 && y2 <= frontmatrix.Height & y2 > 0 && frontmatrix.Value[x2, y2] > 0 & frontmatrix.Value[x2, y2] != frontmatrix.Value[x1, y1] && simpleList1.FindNr(frontmatrix.Value[x2, y2]) > -1)
                    {
                      int tweight = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, maxdistance);
                      int nr = simpleList2.FindNr(frontmatrix.Value[x2, y2]);
                      if (nr == -1)
                        simpleList2.Add(frontmatrix.Value[x2, y2], tweight);
                      else if (tweight < simpleList2.Weight[nr])
                        simpleList2.Weight[nr] = tweight;
                    }
                  }
                }
                int num5 = -1;
                if (simpleList2.Counter > -1)
                {
                  simpleList2.Sort();
                  num5 = simpleList2.Id[0];
                }
                if (num5 > -1)
                  frontmatrix.Value[x1, y1] = num5;
              }
            }
          }
          tempList.RemoveFront(aiFront.FrontID);
        }
      }
    }

    public AIMatrix InitFrontlinesStrength(
      AIMatrix frontline,
      AIMatrix friendlyStrength,
      AIMatrix enemystrength,
      AIMatrix owner,
      AIMatrix tminstrength)
    {
      DC2AIClass tai = this;
      AIMatrix aiMatrix = new AIMatrix(ref tai);
      int mapWidth = this.map.MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.map.MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (frontline.Value[x, y] > 0)
          {
            int num1 = friendlyStrength.Value[x, y];
            int num2 = enemystrength.Value[x, y];
            aiMatrix.Value[x, y] = (int) Math.Round((double) num1 * 0.3) <= num2 ? ((int) Math.Round((double) num1 * 0.5) <= num2 ? ((int) Math.Round((double) num1 * 0.8) <= num2 ? ((int) Math.Round((double) num1 * 1.66) <= num2 ? (num2 <= 0 ? 2 : 1) : 2) : 3) : 4) : 5;
            if (tminstrength.Value[x, y] > aiMatrix.Value[x, y])
              aiMatrix.Value[x, y] = tminstrength.Value[x, y];
            int num3 = friendlyStrength.Value[x, y];
            int landscapeType = this.map.HexObj[frontline.Left + x, frontline.Top + y].LandscapeType;
            if (landscapeType > -1 && this.game.Data.LandscapeTypeObj[landscapeType].TempDefenseBonus > 0)
              num3 += (int) Math.Round((double) num3 * ((double) this.game.Data.LandscapeTypeObj[landscapeType].TempDefenseBonus / 100.0));
            int bestRiver = this.GetBestRiver(x, y, owner);
            if (bestRiver > -1 && this.game.Data.RiverTypeObj[bestRiver].TempDefenseBonus > 0)
              num3 += (int) Math.Round((double) num3 * ((double) this.game.Data.RiverTypeObj[bestRiver].TempDefenseBonus / 100.0));
            int num4 = enemystrength.Value[x, y];
            if (aiMatrix.Value[x, y] == 1)
              aiMatrix.Value[x, y] = (int) Math.Round((double) num3 * 0.66) <= num4 ? ((int) Math.Round((double) num3 * 1.6) <= num4 ? 1 : 2) : 2;
          }
        }
      }
      return aiMatrix;
    }

    public int GetBestRiver(int x, int y, AIMatrix owner)
    {
      int num = 0;
      int bestRiver = -1;
      int index = 0;
      do
      {
        Coordinate coordinate = this.TempHexNeighbour[x, y, index];
        if (coordinate.onmap && owner.Value[coordinate.x, coordinate.y] != owner.Value[x, y] && this.map.HexObj[x + owner.Left, y + owner.Top].RiverType[index] > -1)
        {
          int tempDefenseBonus = this.game.Data.RiverTypeObj[this.map.HexObj[x + owner.Left, y + owner.Top].RiverType[index]].TempDefenseBonus;
          if (tempDefenseBonus > num)
          {
            num = tempDefenseBonus;
            bestRiver = this.map.HexObj[x + owner.Left, y + owner.Top].RiverType[index];
          }
        }
        ++index;
      }
      while (index <= 5);
      return bestRiver;
    }

    public void InitFrontlinesKeepCorpsTogether()
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int hq = 0; hq <= unitCounter; ++hq)
      {
        if (this.game.Data.UnitObj[hq].PreDef == -1 & this.game.Data.UnitObj[hq].Regime == this.game.Data.Turn && this.game.Data.UnitObj[hq].TempCategory == 10)
        {
          int toFrontID = -1;
          int num = 0;
          int counter1 = this.frontList.Counter;
          for (int index = 0; index <= counter1; ++index)
          {
            int powerUnderCorps = this.frontList.Front[index].GetPowerUnderCorps(hq);
            if (powerUnderCorps > num)
            {
              num = powerUnderCorps;
              toFrontID = this.frontList.Front[index].FrontID;
            }
          }
          if (toFrontID > -1)
          {
            int counter2 = this.frontList.Counter;
            for (int index = 0; index <= counter2; ++index)
            {
              if (this.frontList.Front[index].FrontID != toFrontID)
                this.frontList.RemoveAllUnitsUnderCorpsFromFront(hq, this.frontList.Front[index].FrontID, toFrontID);
            }
          }
        }
      }
    }

    public void InitFrontlinesKeepDivTogether(ref AIFrontList tempList, ref AIMatrix tfronts)
    {
      this.AddLog("KEEP DIV TOGETHER");
      bool[] flagArray = new bool[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1 & this.GetRegime(this.game.Data.UnitObj[index1].Regime) == this.GetGameDataTurn() && this.game.Data.UnitObj[index1].Historical > -1)
        {
          int historical = this.game.Data.UnitObj[index1].Historical;
          flagArray[historical] = true;
          if (this.game.Data.Product >= 6)
          {
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int index2 = 0; index2 <= unitCounter2; ++index2)
            {
              if (this.game.Data.UnitObj[index2].Historical == this.game.Data.UnitObj[index1].Historical && this.friendlySupplyMatrix.Value[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y] > this.VAR_SUPPLY_25PERCENT_RANGE)
                flagArray[historical] = false;
            }
          }
        }
      }
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int index3 = 0; index3 <= unitCounter3; ++index3)
      {
        if (this.game.Data.UnitObj[index3].PreDef == -1 & this.GetRegime(this.game.Data.UnitObj[index3].Regime) == this.GetGameDataTurn() && this.game.Data.UnitObj[index3].Historical > -1)
        {
          int historical = this.game.Data.UnitObj[index3].Historical;
          int toFrontID = -1;
          int num1 = 0;
          int num2 = 0;
          if (flagArray[historical])
          {
            int counter1 = tempList.Counter;
            for (int index4 = 0; index4 <= counter1; ++index4)
            {
              int powerUnderHis = tempList.Front[index4].GetPowerUnderHis(historical);
              if (powerUnderHis > 0)
                ++num2;
              if (powerUnderHis > num1)
              {
                num1 = powerUnderHis;
                toFrontID = tempList.Front[index4].FrontID;
              }
            }
            if (toFrontID > -1 & num2 > 1)
            {
              int counter2 = tempList.Counter;
              for (int index5 = 0; index5 <= counter2; ++index5)
              {
                if (tempList.Front[index5].FrontID != toFrontID)
                  this.AddLog(tempList.RemoveAllUnitsUnderHisFromFront(historical, tempList.Front[index5].FrontID, toFrontID));
              }
            }
            else
            {
              int unitCounter4 = this.game.Data.UnitCounter;
              for (int tunr = 0; tunr <= unitCounter4; ++tunr)
              {
                if (this.game.Data.UnitObj[tunr].Historical == this.game.Data.UnitObj[index3].Historical && this.game.Data.UnitObj[tunr].TempCategory == 1 | this.game.Data.UnitObj[tunr].TempCategory == 5 && this.game.Data.UnitObj[tunr].AIGroup != this.game.Data.UnitObj[index3].AIGroup && tempList.GetFrontNr(this.game.Data.UnitObj[index3].AIGroup) > -1)
                {
                  this.game.Data.UnitObj[tunr].AIGroup = this.game.Data.UnitObj[index3].AIGroup;
                  this.AddLog("Assigned (norm)" + this.game.Data.UnitObj[tunr].Name + " to front " + this.game.Data.UnitObj[tunr].AIGroup.ToString());
                  tempList.Front[tempList.GetFrontNr(this.game.Data.UnitObj[index3].AIGroup)].units.add(tunr, this.game.Data.UnitObj[tunr].AIid);
                }
              }
              int unitCounter5 = this.game.Data.UnitCounter;
              for (int tunr = 0; tunr <= unitCounter5; ++tunr)
              {
                if (this.game.Data.UnitObj[tunr].Historical == this.game.Data.UnitObj[index3].Historical && this.game.Data.UnitObj[tunr].TempCategory == 2 && this.game.Data.UnitObj[tunr].AIGroup != this.game.Data.UnitObj[index3].AIGroup && tempList.GetFrontNr(this.game.Data.UnitObj[index3].AIGroup) > -1)
                {
                  this.game.Data.UnitObj[tunr].AIGroup = this.game.Data.UnitObj[index3].AIGroup;
                  this.AddLog("Assigned (art)" + this.game.Data.UnitObj[tunr].Name + " to front " + this.game.Data.UnitObj[tunr].AIGroup.ToString());
                  tempList.Front[tempList.GetFrontNr(this.game.Data.UnitObj[index3].AIGroup)].artUnits.add(tunr, this.game.Data.UnitObj[tunr].AIid);
                }
              }
            }
          }
        }
      }
    }

    public void InitFrontlinesSetOrganisingUnits(ref AIFrontList tfrontlist, AIMatrix fronts)
    {
      if (this.VAR_DC4_MINIMIZE_ORG_UNITS)
        return;
      this.AddLog("SET ORGANISATIONAL UNITS SEPERATE");
      if (!this.VAR_USE_DYNAMIC_OOB)
        return;
      this.AddLog("DYNAMIC OOB : MISSING UNITS");
      SimpleList simpleList1 = new SimpleList();
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      DC2AIClass tai2 = this;
      AIMatrix aiMatrix2 = new AIMatrix(ref tai2);
      DC2AIClass tai3 = this;
      AIMatrix aiMatrix3 = new AIMatrix(ref tai3);
      AIMatrix mask = this.SetOwnerMatrix(aiMatrix3.Left, aiMatrix3.Top, aiMatrix3.Width, aiMatrix3.Height);
      AIMatrix aiMatrix4 = mask.Clone();
      aiMatrix4.RemoveValuesByMask(mask, 1);
      aiMatrix4.ExpandAndAddValueForAnyRegime(9);
      aiMatrix4.SetAllValuesSubtractWith(2);
      int[] numArray1 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int[,] numArray3 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[,] numArray4 = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      int[] numArray5 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical > -1 & this.game.Data.UnitObj[index1].PreDef == -1 & this.GetRegime(this.game.Data.UnitObj[index1].Regime) == this.GetGameDataTurn())
        {
          int[] numArray6 = numArray1;
          int[] numArray7 = numArray6;
          int historical1 = this.game.Data.UnitObj[index1].Historical;
          int index2 = historical1;
          int num1 = numArray6[historical1] + 1;
          numArray7[index2] = num1;
          if (this.game.Data.UnitObj[index1].HistoricalSubPart > -1)
          {
            int[,] numArray8 = numArray3;
            int[,] numArray9 = numArray8;
            int historical2 = this.game.Data.UnitObj[index1].Historical;
            int index3 = historical2;
            int historicalSubPart = this.game.Data.UnitObj[index1].HistoricalSubPart;
            int index4 = historicalSubPart;
            int num2 = numArray8[historical2, historicalSubPart] + 1;
            numArray9[index3, index4] = num2;
          }
        }
      }
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter1; ++index5)
      {
        if (numArray1[index5] > 0 && this.game.Data.HistoricalUnitObj[index5].ModelMaster > -1)
        {
          int[] numArray10 = numArray5;
          int[] numArray11 = numArray10;
          int modelMaster = this.game.Data.HistoricalUnitObj[index5].ModelMaster;
          int index6 = modelMaster;
          int num = numArray10[modelMaster] + 1;
          numArray11[index6] = num;
        }
      }
      int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
      for (int index7 = 0; index7 <= historicalUnitCounter2; ++index7)
      {
        int index8 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[index7].SubParts[index8] > -1)
          {
            int[] numArray12 = numArray2;
            int[] numArray13 = numArray12;
            int index9 = index7;
            int index10 = index9;
            int num = numArray12[index9] + 1;
            numArray13[index10] = num;
          }
          int[,] numArray14 = numArray4;
          int[,] numArray15 = numArray14;
          int index11 = index7;
          int index12 = index11;
          int index13 = index8;
          int index14 = index13;
          int num3 = numArray14[index11, index13] + 1;
          numArray15[index12, index14] = num3;
          ++index8;
        }
        while (index8 <= 9);
      }
      SimpleList simpleList2 = new SimpleList();
      int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
      for (int tdata1 = 0; tdata1 <= historicalUnitCounter3; ++tdata1)
      {
        if (this.game.Data.HistoricalUnitObj[tdata1].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata1].ModelMaster > -1 && numArray1[tdata1] < numArray2[tdata1] & numArray1[tdata1] > 0)
        {
          int tdata2 = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[tdata1].SubParts[tdata2] > -1 && numArray3[tdata1, tdata2] == 0 & numArray4[tdata1, tdata2] > 0)
              simpleList2.Add(tdata1 * 100 + tdata2, 0, tdata1, tdata2);
            ++tdata2;
          }
          while (tdata2 <= 9);
        }
      }
      SimpleList simpleList3 = new SimpleList();
      int historicalUnitCounter4 = this.game.Data.HistoricalUnitCounter;
      for (int index15 = 0; index15 <= historicalUnitCounter4; ++index15)
      {
        if (this.GetRegime(this.game.Data.HistoricalUnitObj[index15].TempRegime) == this.GetGameDataTurn() & this.game.Data.HistoricalUnitObj[index15].Type < 5 & this.game.Data.HistoricalUnitObj[index15].ModelMaster > -1)
        {
          int index16 = 0;
          do
          {
            int num4 = 0;
            int num5 = 0;
            if (this.game.Data.HistoricalUnitObj[index15].SubParts[index16] > -1)
            {
              int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(index15, index16);
              if (unitByHistorical > -1)
              {
                int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(unitByHistorical);
                int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unitByHistorical);
                int startPower = this.game.HandyFunctionsObj.GetStartPower(unitByHistorical);
                int num6 = (int) Math.Round((double) startPower * ((double) breakPercent / 100.0));
                int num7 = startPower != 0 ? Math.Min(100, (int) Math.Round((double) powerPtsAbsolute / (double) startPower * 100.0)) : 100;
                int val2 = num5 + 1;
                int num8 = (int) Math.Round((double) (num4 + num7) / (double) Math.Max(1, val2));
                if (this.game.Data.UnitObj[unitByHistorical].SOReplacementPercent == 0)
                  num8 = 0;
                if (num8 < 40 && !this.game.HandyFunctionsObj.HasUnitAirSF(unitByHistorical) & !this.game.HandyFunctionsObj.HasUnitNavySF(unitByHistorical))
                  simpleList3.Add(index15 * 100 + index16, 0, index15, index16);
              }
            }
            ++index16;
          }
          while (index16 <= 9);
        }
      }
      int counter = simpleList3.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(simpleList3.Data1[index], simpleList3.Data2[index]);
        if (unitByHistorical > -1)
        {
          int aiid = this.game.Data.UnitObj[unitByHistorical].AIid;
          int aiGroup = this.game.Data.UnitObj[unitByHistorical].AIGroup;
          if (aiGroup > 0)
          {
            AIFront front = this.frontList.FindFront(aiGroup);
            if (!Information.IsNothing((object) front))
            {
              if (front.units.CheckIfPresentAIid(aiid))
              {
                front.units.removeAiId(aiid);
                front.orgUnits.add(unitByHistorical, aiid);
              }
              if (front.artUnits.CheckIfPresentAIid(aiid))
              {
                front.artUnits.removeAiId(aiid);
                front.orgUnits.add(unitByHistorical, aiid);
              }
            }
          }
        }
      }
    }

    public void InitFrontlinesSetTopFrontlines(
      ref AIFrontList tfrontlist,
      AIMatrix fronts,
      ref AIMatrix owner)
    {
      if (!this.VAR_USE_TOP_OPERATIONS)
      {
        int counter = tfrontlist.Counter;
        for (int index = 0; index <= counter; ++index)
          tfrontlist.Front[index].TopOperation = true;
      }
      else
      {
        this.AddLog("SET TOP FRONTS");
        AIMatrix aiMatrix1 = fronts.Clone();
        aiMatrix1.RemoveValuesByMask(this.frontlinesMatrix, 0);
        aiMatrix1.ExpandValueForAnyRegime(this.VAR_FRONTLINE_DEPTH * 2);
        AIMatrix aiMatrix2 = owner.Clone();
        aiMatrix2.RemoveValuesByMask(owner, 2);
        aiMatrix2.ExpandAndAddValueForAnyRegime(39);
        aiMatrix2.RemoveValuesByMask(owner, 1);
        AIMatrix aiMatrix3 = owner.Clone();
        aiMatrix3.RemoveValuesByMask(owner, 1);
        aiMatrix3.ExpandAndAddValueForAnyRegime(31);
        AIMatrix aiMatrix4 = fronts.Clone();
        int counter1 = tfrontlist.Counter;
        for (int index = 0; index <= counter1; ++index)
          tfrontlist.Front[index].TopOperation = false;
        this.MakeFriendlySupplyMatrix();
        aiMatrix4.RemoveValuesByMask(this.friendlySupplyMatrix, 9999);
        aiMatrix4.ExpandValueForAnyRegimeOverRoadOnly();
        int[] numArray1 = new int[tfrontlist.GetIdCounter() + 19999 + 1];
        float[] numArray2 = new float[tfrontlist.GetIdCounter() + 19999 + 1];
        int[] numArray3 = new int[tfrontlist.GetIdCounter() + 19999 + 1];
        int[] numArray4 = new int[tfrontlist.GetIdCounter() + 19999 + 1];
        int mapWidth = this.map.MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.map.MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            bool flag1 = false;
            if (aiMatrix4.Value[x, y] > 0)
            {
              bool flag2 = false;
              float num1 = 1f;
              if (tfrontlist.FindFront(aiMatrix4.Value[x, y]).Stance == 3 & aiMatrix2.Value[x, y] > 0 & aiMatrix2.Value[x, y] < 35)
              {
                flag1 = true;
                flag2 = true;
                num1 = (float) (1.0 - (double) aiMatrix2.Value[x, y] / 35.0 + 0.5);
              }
              if (tfrontlist.FindFront(aiMatrix4.Value[x, y]).Stance == 2 & aiMatrix2.Value[x, y] > 0 & aiMatrix2.Value[x, y] < 10)
              {
                flag1 = true;
                num1 = (float) (1.0 - (double) aiMatrix2.Value[x, y] / 10.0 + 0.5);
              }
              if (tfrontlist.FindFront(aiMatrix4.Value[x, y]).Stance == 1 & aiMatrix3.Value[x, y] > 0 & aiMatrix3.Value[x, y] < 30)
              {
                flag1 = true;
                flag2 = true;
                num1 = (float) (1.0 - (double) aiMatrix3.Value[x, y] / 15.0 + 0.5);
              }
              if (tfrontlist.FindFront(aiMatrix4.Value[x, y]).Stance == 2 & aiMatrix3.Value[x, y] > 0 & aiMatrix3.Value[x, y] < 15)
              {
                flag1 = true;
                num1 = (float) (1.0 - (double) aiMatrix3.Value[x, y] / 8.0 + 0.5);
              }
              if (flag1 & aiMatrix4.Value[x, y] < numArray1.GetUpperBound(0))
              {
                int num2 = (int) Math.Round((double) ((float) (int) Math.Round(Math.Sqrt((double) (this.game.Data.MapObj[0].HexObj[x, y].VP + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[x, y])) * 100.0) * num1));
                if (flag2)
                  num2 *= 2;
                int[] numArray5 = numArray1;
                int[] numArray6 = numArray5;
                int[,] numArray7 = aiMatrix4.Value;
                int[,] numArray8 = numArray7;
                int index1 = x;
                int index2 = index1;
                int index3 = y;
                int index4 = index3;
                int index5 = numArray8[index2, index4];
                int num3 = numArray5[numArray7[index1, index3]] + num2;
                numArray6[index5] = num3;
              }
            }
            if (aiMatrix1.Value[x, y] > 0 & aiMatrix1.Value[x, y] < numArray1.GetUpperBound(0))
            {
              bool flag3 = false;
              if (owner.Value[x, y] == 2)
                flag3 = true;
              if (owner.Value[x, y] == 2)
              {
                int[] numArray9 = numArray4;
                int[] numArray10 = numArray9;
                int[,] numArray11 = aiMatrix1.Value;
                int[,] numArray12 = numArray11;
                int index6 = x;
                int index7 = index6;
                int index8 = y;
                int index9 = index8;
                int index10 = numArray12[index7, index9];
                int num = numArray9[numArray11[index6, index8]] + 1;
                numArray10[index10] = num;
              }
              if (flag3)
              {
                int[] numArray13 = numArray3;
                int[] numArray14 = numArray13;
                int[,] numArray15 = aiMatrix1.Value;
                int[,] numArray16 = numArray15;
                int index11 = x;
                int index12 = index11;
                int index13 = y;
                int index14 = index13;
                int index15 = numArray16[index12, index14];
                int num4 = numArray13[numArray15[index11, index13]] + 1;
                numArray14[index15] = num4;
                if (this.game.Data.LandscapeTypeObj[this.map.HexObj[x, y].LandscapeType].TempDefenseBonus > 100)
                {
                  float[] numArray17 = numArray2;
                  float[] numArray18 = numArray17;
                  int[,] numArray19 = aiMatrix1.Value;
                  int[,] numArray20 = numArray19;
                  int index16 = x;
                  int index17 = index16;
                  int index18 = y;
                  int index19 = index18;
                  int index20 = numArray20[index17, index19];
                  double num5 = (double) numArray17[numArray19[index16, index18]] + 10.0;
                  numArray18[index20] = (float) num5;
                }
                if (this.GetBestRiver(x, y, owner) > -1)
                {
                  float[] numArray21 = numArray2;
                  float[] numArray22 = numArray21;
                  int[,] numArray23 = aiMatrix1.Value;
                  int[,] numArray24 = numArray23;
                  int index21 = x;
                  int index22 = index21;
                  int index23 = y;
                  int index24 = index23;
                  int index25 = numArray24[index22, index24];
                  double num6 = (double) numArray21[numArray23[index21, index23]] + Math.Pow((double) this.game.Data.RiverTypeObj[this.GetBestRiver(x, y, owner)].TempDefenseBonus / 100.0, 2.0);
                  numArray22[index25] = (float) num6;
                }
              }
            }
          }
        }
        int counter2 = tfrontlist.Counter;
        int num7;
        int num8;
        for (int index = 0; index <= counter2; ++index)
        {
          if (tfrontlist.Front[index].units.counter > 0 & tfrontlist.Front[index].FrontType == 1 & tfrontlist.Front[index].FrontID < numArray1.GetUpperBound(0) && numArray3[tfrontlist.Front[index].FrontID] > 0)
          {
            num7 += numArray4[tfrontlist.Front[index].FrontID];
            ++num8;
          }
        }
        if (num8 == 0)
          num8 = 1;
        int num9 = (int) Math.Round((double) num7 / (double) num8);
        int counter3 = tfrontlist.Counter;
        for (int index = 0; index <= counter3; ++index)
        {
          if (tfrontlist.Front[index].units.counter > 0 & tfrontlist.Front[index].FrontType == 1 & tfrontlist.Front[index].FrontID < numArray1.GetUpperBound(0))
          {
            if (numArray3[tfrontlist.Front[index].FrontID] > 0)
            {
              numArray2[tfrontlist.Front[index].FrontID] = numArray2[tfrontlist.Front[index].FrontID] / (float) numArray3[tfrontlist.Front[index].FrontID];
              numArray1[tfrontlist.Front[index].FrontID] = (int) Math.Round((double) ((float) numArray1[tfrontlist.Front[index].FrontID] / (1f + numArray2[tfrontlist.Front[index].FrontID])));
            }
            else
              numArray1[tfrontlist.Front[index].FrontID] = 0;
            if ((double) numArray4[tfrontlist.Front[index].FrontID] < (double) num9 * 0.3)
              numArray1[tfrontlist.Front[index].FrontID] = (int) Math.Round((double) numArray1[tfrontlist.Front[index].FrontID] / 2.0);
            if ((double) numArray4[tfrontlist.Front[index].FrontID] < (double) num9 * 0.16)
              numArray1[tfrontlist.Front[index].FrontID] = (int) Math.Round((double) numArray1[tfrontlist.Front[index].FrontID] / 2.0);
          }
        }
        int counter4 = tfrontlist.Counter;
        for (int index26 = 0; index26 <= counter4; ++index26)
        {
          int num10 = 0;
          int num11 = 0;
          int counter5 = tfrontlist.Front[index26].units.counter;
          for (int index27 = 0; index27 <= counter5; ++index27)
          {
            int index28 = tfrontlist.Front[index26].units.unr[index27];
            if (this.game.Data.UnitObj[index28].TempTopUnit)
              num10 += this.game.Data.UnitObj[index28].TempUnitPowerAbs;
            num11 += this.game.Data.UnitObj[index28].TempUnitPowerAbs;
          }
          if (num11 > 0 & tfrontlist.Front[index26].FrontID < 999999)
          {
            float num12 = (float) num10 / (float) num11;
            if ((double) num12 > 0.35)
              numArray1[tfrontlist.Front[index26].FrontID] = (int) Math.Round((double) numArray1[tfrontlist.Front[index26].FrontID] * 1.45);
            else if ((double) num12 > 0.24)
              numArray1[tfrontlist.Front[index26].FrontID] = (int) Math.Round((double) numArray1[tfrontlist.Front[index26].FrontID] * 1.32);
            else if ((double) num12 > 0.15)
              numArray1[tfrontlist.Front[index26].FrontID] = (int) Math.Round((double) numArray1[tfrontlist.Front[index26].FrontID] * 1.22);
            else if ((double) num12 > 0.07)
              numArray1[tfrontlist.Front[index26].FrontID] = (int) Math.Round((double) numArray1[tfrontlist.Front[index26].FrontID] * 1.15);
          }
        }
        SimpleList simpleList = new SimpleList();
        int num13 = 0;
        int counter6 = tfrontlist.Counter;
        for (int tid = 0; tid <= counter6; ++tid)
        {
          if (tfrontlist.Front[tid].units.counter > 0 & tfrontlist.Front[tid].FrontType == 1 & tfrontlist.Front[tid].FrontID < numArray1.GetUpperBound(0))
          {
            ++num13;
            simpleList.Add(tid, numArray1[tfrontlist.Front[tid].FrontID], tfrontlist.Front[tid].FrontID);
          }
        }
        simpleList.ReverseSort();
        int num14 = (int) Math.Round((double) num13 / (double) this.VAR_TOP_OPERATIONS_PERCENTAGE);
        if (num14 < 1)
          num14 = 1;
        int num15 = num14;
        for (int index = 1; index <= num15; ++index)
          this.frontList.Front[simpleList.Id[index]].TopOperation = true;
      }
    }

    public void InitFrontlineSetUnitRatio(
      ref AIFrontList tfrontlist,
      AIMatrix fronts,
      ref AIMatrix owner)
    {
      AIMatrix aiMatrix = fronts.Clone();
      aiMatrix.RemoveValuesByMask(this.frontlinesMatrix, 0);
      int counter1 = tfrontlist.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (tfrontlist.Front[index].FrontID == 1095)
          index = index;
        if (tfrontlist.Front[index].FrontType == 11 | tfrontlist.Front[index].FrontType == 12)
          aiMatrix.SetValueXToValueY(tfrontlist.Front[index].FrontID, 0);
      }
      aiMatrix.ExpandValueForAnyRegime(this.VAR_FRONTLINE_DEPTH);
      if (this.game.Data.Product >= 6)
      {
        SimpleList[] simpleListArray = new SimpleList[tfrontlist.Counter + 2 + 1];
        int counter2 = tfrontlist.Counter;
        for (int index = 0; index <= counter2; ++index)
          simpleListArray[index] = tfrontlist.Front[index].GetNeighbourFrontList();
        int counter3 = tfrontlist.Counter;
        for (int index1 = 0; index1 <= counter3; ++index1)
        {
          tfrontlist.Front[index1].UnitCountRatio = 1f;
          int num1 = 0;
          int num2 = 0;
          int mapWidth = this.map.MapWidth;
          for (int index2 = 0; index2 <= mapWidth; ++index2)
          {
            int mapHeight = this.map.MapHeight;
            for (int index3 = 0; index3 <= mapHeight; ++index3)
            {
              bool flag = false;
              if (aiMatrix.Value[index2, index3] == tfrontlist.Front[index1].FrontID)
                flag = true;
              if (simpleListArray[index1].FindNr(aiMatrix.Value[index2, index3]) > -1)
                flag = true;
              if (flag)
              {
                if (owner.Value[index2, index3] == 1)
                {
                  if (this.map.HexObj[index2, index3].UnitCounter > -1)
                  {
                    int unitCounter = this.map.HexObj[index2, index3].UnitCounter;
                    for (int index4 = 0; index4 <= unitCounter; ++index4)
                    {
                      int unit = this.map.HexObj[index2, index3].UnitList[index4];
                      if (this.game.Data.UnitObj[unit].AIGroup == tfrontlist.Front[index1].FrontID && this.game.Data.UnitObj[unit].TempCategory == 1)
                        num1 += 10;
                    }
                  }
                }
                else if (owner.Value[index2, index3] == 2 && this.map.HexObj[index2, index3].UnitCounter > -1)
                {
                  int unitCounter = this.map.HexObj[index2, index3].UnitCounter;
                  for (int index5 = 0; index5 <= unitCounter; ++index5)
                  {
                    int unit = this.map.HexObj[index2, index3].UnitList[index5];
                    if (this.game.Data.UnitObj[unit].TempCategory == 1)
                      num2 += (int) Math.Round((double) (10f * this.CustomCalls.CustomRuleInitFrontlines_UnitRatioWeightModifier(unit)));
                  }
                }
              }
            }
          }
          tfrontlist.Front[index1].UnitCountRatio = num2 != 0 ? (float) num1 / (float) num2 : 1f;
        }
      }
      else
      {
        int counter4 = tfrontlist.Counter;
        for (int index6 = 0; index6 <= counter4; ++index6)
        {
          tfrontlist.Front[index6].UnitCountRatio = 1f;
          int num3 = 0;
          int num4 = 0;
          int mapWidth = this.map.MapWidth;
          for (int index7 = 0; index7 <= mapWidth; ++index7)
          {
            int mapHeight = this.map.MapHeight;
            for (int index8 = 0; index8 <= mapHeight; ++index8)
            {
              if (aiMatrix.Value[index7, index8] == tfrontlist.Front[index6].FrontID)
              {
                if (owner.Value[index7, index8] == 1)
                {
                  if (this.map.HexObj[index7, index8].UnitCounter > -1)
                  {
                    int unitCounter = this.map.HexObj[index7, index8].UnitCounter;
                    for (int index9 = 0; index9 <= unitCounter; ++index9)
                    {
                      int unit = this.map.HexObj[index7, index8].UnitList[index9];
                      if (this.game.Data.UnitObj[unit].AIGroup == tfrontlist.Front[index6].FrontID && this.game.Data.UnitObj[unit].TempCategory == 1)
                        ++num3;
                    }
                  }
                }
                else if (owner.Value[index7, index8] == 2 && this.map.HexObj[index7, index8].UnitCounter > -1)
                {
                  int unitCounter = this.map.HexObj[index7, index8].UnitCounter;
                  for (int index10 = 0; index10 <= unitCounter; ++index10)
                  {
                    if (this.game.Data.UnitObj[this.map.HexObj[index7, index8].UnitList[index10]].TempCategory == 1)
                      ++num4;
                  }
                }
              }
            }
          }
          if (num4 != 0)
            tfrontlist.Front[index6].UnitCountRatio = (float) num3 / (float) num4;
        }
      }
    }

    public void InitFrontlinesAssignIndependentArtilleryUnitsToFronts(
      AIMatrix fronts,
      ref AIFrontList tfrontlist)
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1)
        {
          int x = this.game.Data.UnitObj[unr].X;
          int y = this.game.Data.UnitObj[unr].Y;
          if (x > -1 & y > -1 && fronts.Value[x, y] > 0 && this.game.Data.UnitObj[unr].AIGroup < 1 && this.game.Data.UnitObj[unr].TempCategory == 2)
          {
            AIFront front = tfrontlist.FindFront(fronts.Value[x, y]);
            if (!Information.IsNothing((object) front))
            {
              this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
              front.AddUnit(unr);
            }
            else
            {
              DC2AIClass tai = this;
              AIFront tFront = new AIFront(ref tai, 1);
              tFront.AddUnit(unr);
              tfrontlist.AddFront(tFront, true);
              tFront.FrontID = fronts.Value[x, y];
              this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
            }
          }
        }
      }
    }

    public SimpleList GetSSHQGroups(int hq)
    {
      SimpleList sshqGroups = new SimpleList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index1].X > -1 & !this.game.Data.UnitObj[index1].IsHQ && this.game.Data.UnitObj[index1].HQ == hq & this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.UnitObj[index1].AISubStrictGroup > 0)
        {
          int aiSubStrictGroup = this.game.Data.UnitObj[index1].AISubStrictGroup;
          int nr = sshqGroups.FindNr(aiSubStrictGroup);
          if (nr >= 0)
          {
            int[] weight = sshqGroups.Weight;
            int[] numArray = weight;
            int index2 = nr;
            int index3 = index2;
            int num = weight[index2] + 1;
            numArray[index3] = num;
          }
          else
            sshqGroups.Add(aiSubStrictGroup, 1);
        }
      }
      return sshqGroups;
    }

    public void SSHQSettings(AIMatrix fronts, ref AIFrontList tfrontlist, ref AIMatrix ownerMatrix)
    {
      if (this.game.Data.Turn == 13)
      {
        int num1 = num1;
      }
      int num2 = 6;
      if (this.game.Data.Product == 7)
        num2 = 8;
      if (!this.VAR_USE_SSHQ)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          if (this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].HQ > -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1)
            this.game.Data.UnitObj[index].AISubStrictGroup = 1;
        }
      }
      else
      {
        if (this.game.Data.Round == 1)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].HQ > -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1)
              this.game.Data.UnitObj[index].AISubStrictGroup = 0;
          }
        }
        AIUnitList aiUnitList = new AIUnitList();
        int num3 = 0;
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index1 = 0; index1 <= unitCounter1; ++index1)
        {
          if (this.game.Data.UnitObj[index1].X > -1 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[index1].IsHQ & this.game.Data.UnitObj[index1].PreDef == -1)
          {
            ++num3;
            if (this.game.Data.UnitObj[index1].HQ > -1)
            {
              int hq = this.game.Data.UnitObj[index1].HQ;
              if (!aiUnitList.CheckIfPresentUnr(hq) && this.game.Data.UnitObj[hq].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq].Historical].Type <= num2)
              {
                int tdata = 0;
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int index2 = 0; index2 <= unitCounter2; ++index2)
                {
                  if (this.game.Data.UnitObj[index2].HQ == hq)
                    ++tdata;
                }
                aiUnitList.add(hq, -1, tdata);
              }
            }
          }
        }
        int counter1 = aiUnitList.counter;
        for (int index3 = 0; index3 <= counter1; ++index3)
        {
          SimpleList simpleList = new SimpleList();
          int index4 = aiUnitList.unr[index3];
          bool flag1 = false;
          if (this.game.Data.UnitObj[index4].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index4].Historical].NoSplit)
            flag1 = true;
          int unitCounter3 = this.game.Data.UnitCounter;
          for (int tid = 0; tid <= unitCounter3; ++tid)
          {
            if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn & this.game.Data.UnitObj[tid].X > -1 & !this.game.Data.UnitObj[tid].IsHQ && this.game.Data.UnitObj[tid].TempCategory == 1 | this.game.Data.UnitObj[tid].TempCategory == 2 | this.game.Data.UnitObj[tid].TempCategory == 5 | this.game.Data.UnitObj[tid].TempCategory2 == 14 && this.game.Data.UnitObj[tid].HQ == index4 & this.game.Data.UnitObj[tid].Historical > -1 && this.game.Data.UnitObj[tid].AISubStrictGroup < 1)
            {
              int tweight = 0;
              if (this.game.Data.UnitObj[tid].TempTopUnit)
                tweight = 100;
              if (this.game.Data.UnitObj[tid].Historical > -1)
              {
                int historicalsSubUnitCount = this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.game.Data.UnitObj[tid].Historical);
                tweight += historicalsSubUnitCount * 50;
              }
              int num4 = 0;
              int unitCounter4 = this.game.Data.UnitCounter;
              for (int index5 = 0; index5 <= unitCounter4; ++index5)
              {
                if (this.game.Data.UnitObj[index5].Historical == this.game.Data.UnitObj[tid].Historical && this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn & this.game.Data.UnitObj[tid].X > -1 & !this.game.Data.UnitObj[tid].IsHQ && tid != index5)
                  ++num4;
              }
              if (num4 > 0)
                tweight += 200 * num4;
              simpleList.Add(tid, tweight);
            }
          }
          simpleList.ReverseSort();
          int counter2 = simpleList.Counter;
          for (int index6 = 0; index6 <= counter2; ++index6)
          {
            int num5 = 1;
            int num6 = 0;
            bool flag2 = true;
            while (flag2)
            {
              flag2 = false;
              int unitCounter5 = this.game.Data.UnitCounter;
              for (int index7 = 0; index7 <= unitCounter5; ++index7)
              {
                if (this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index7].X > -1 & !this.game.Data.UnitObj[index7].IsHQ && this.game.Data.UnitObj[index7].HQ == index4 & this.game.Data.UnitObj[index7].Historical > -1 && this.game.Data.UnitObj[index7].AISubStrictGroup == num5)
                  ++num6;
              }
              if (!flag1)
              {
                if (num5 == 1 | this.VAR_SSHQ_SIZE2 < 1)
                {
                  if (num6 >= this.VAR_SSHQ_SIZE1)
                  {
                    ++num5;
                    num6 = 0;
                    flag2 = true;
                  }
                }
                else if (num6 >= this.VAR_SSHQ_SIZE2)
                {
                  ++num5;
                  num6 = 0;
                  flag2 = true;
                }
              }
            }
            this.game.Data.UnitObj[simpleList.Id[index6]].AISubStrictGroup = num5;
          }
        }
        int counter3 = aiUnitList.counter;
        for (int index8 = 0; index8 <= counter3; ++index8)
        {
          int hq = aiUnitList.unr[index8];
          bool flag3 = false;
          if (this.game.Data.UnitObj[hq].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq].Historical].NoSplit)
            flag3 = true;
          bool flag4 = true;
          int num7 = 0;
          while (flag4 & !flag3)
          {
            ++num7;
            flag4 = false;
            SimpleList sshqGroups = this.GetSSHQGroups(hq);
            int counter4 = sshqGroups.Counter;
            for (int index9 = 0; index9 <= counter4; ++index9)
              sshqGroups.Data5[index9] = sshqGroups.Id[index9];
            sshqGroups.SortOnData5();
            if (sshqGroups.Counter > -1)
            {
              while (sshqGroups.Id[0] > 1)
              {
                sshqGroups.Add(sshqGroups.Id[0] - 1, 0, tdata5: (sshqGroups.Id[0] - 1));
                sshqGroups.SortOnData5();
              }
              int num8 = this.VAR_SSHQ_SIZE1;
              if (sshqGroups.Id[sshqGroups.Counter] > 1)
                num8 = this.VAR_SSHQ_SIZE2;
              if (sshqGroups.Weight[sshqGroups.Counter] > num8)
                sshqGroups.Add(sshqGroups.Id[sshqGroups.Counter] + 1, 0, tdata5: (sshqGroups.Id[sshqGroups.Counter] + 1));
            }
            int counter5 = sshqGroups.Counter;
            for (int index10 = 0; index10 <= counter5; ++index10)
            {
              int num9 = this.VAR_SSHQ_SIZE1;
              int num10 = sshqGroups.Id[index10];
              if (num10 > 1)
                num9 = this.VAR_SSHQ_SIZE2;
              int num11 = (int) Math.Round(Math.Floor((double) num9 / 2.0)) + 1;
              if (num9 >= 2 & num11 == num9)
                --num11;
              if (sshqGroups.Weight[index10] < num11 | sshqGroups.Weight[index10] < num9 && index10 > 0)
              {
                int num12 = 0;
                int num13 = index10 - 1;
                for (int index11 = 0; index11 <= num13; ++index11)
                {
                  int num14 = this.VAR_SSHQ_SIZE1;
                  if (index11 >= 1)
                    num14 = this.VAR_SSHQ_SIZE2;
                  if (sshqGroups.Weight[index11] > num14)
                    num12 += sshqGroups.Weight[index11] - num14;
                }
                if (num12 > 0 & num12 >= num11 - sshqGroups.Weight[index10] & num9 > sshqGroups.Weight[index10])
                {
                  int num15 = index10 - 1;
                  for (int index12 = 0; index12 <= num15; ++index12)
                  {
                    int num16 = sshqGroups.Id[index12];
                    int unitCounter6 = this.game.Data.UnitCounter;
                    for (int index13 = 0; index13 <= unitCounter6; ++index13)
                    {
                      if (this.game.Data.UnitObj[index13].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index13].X > -1 & !this.game.Data.UnitObj[index13].IsHQ && this.game.Data.UnitObj[index13].HQ == hq & this.game.Data.UnitObj[index13].Historical > -1 && this.game.Data.UnitObj[index13].AISubStrictGroup == num16)
                      {
                        this.game.Data.UnitObj[index13].AISubStrictGroup = num10;
                        flag4 = true;
                        break;
                      }
                    }
                    if (flag4)
                      break;
                  }
                }
                if (flag4)
                  break;
              }
              int num17 = (int) Math.Round(Math.Floor((double) num9 / 2.0)) + 1;
              if (num9 >= 2 & num17 == num9)
                --num17;
              if (sshqGroups.Weight[index10] < num17)
              {
                if (index10 < sshqGroups.Counter)
                {
                  int num18 = index10 + 1;
                  int counter6 = sshqGroups.Counter;
                  for (int index14 = num18; index14 <= counter6; ++index14)
                  {
                    int num19 = sshqGroups.Id[index14];
                    int unitCounter7 = this.game.Data.UnitCounter;
                    for (int index15 = 0; index15 <= unitCounter7; ++index15)
                    {
                      if (this.game.Data.UnitObj[index15].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index15].X > -1 & !this.game.Data.UnitObj[index15].IsHQ && this.game.Data.UnitObj[index15].HQ == hq & this.game.Data.UnitObj[index15].Historical > -1 && this.game.Data.UnitObj[index15].AISubStrictGroup == num19)
                      {
                        this.game.Data.UnitObj[index15].AISubStrictGroup = num10;
                        flag4 = true;
                        break;
                      }
                    }
                    if (flag4)
                      break;
                  }
                }
                if (index10 > 0)
                {
                  int num20 = index10 - 1;
                  for (int index16 = 0; index16 <= num20; ++index16)
                  {
                    int num21 = sshqGroups.Id[index16];
                    int unitCounter8 = this.game.Data.UnitCounter;
                    for (int index17 = 0; index17 <= unitCounter8; ++index17)
                    {
                      if (this.game.Data.UnitObj[index17].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index17].X > -1 & !this.game.Data.UnitObj[index17].IsHQ && this.game.Data.UnitObj[index17].HQ == hq & this.game.Data.UnitObj[index17].Historical > -1 && this.game.Data.UnitObj[index17].AISubStrictGroup == num10)
                      {
                        this.game.Data.UnitObj[index17].AISubStrictGroup = num21;
                        flag4 = true;
                        break;
                      }
                    }
                  }
                }
              }
              if (this.game.Data.Product >= 6 && sshqGroups.Weight[index10] > num9 && index10 < sshqGroups.Counter)
              {
                int num22 = index10 + 1;
                int counter7 = sshqGroups.Counter;
                for (int index18 = num22; index18 <= counter7; ++index18)
                {
                  int num23 = sshqGroups.Id[index18];
                  int num24 = sshqGroups.Weight[index10] - num9;
                  int num25 = (int) Math.Round(Math.Floor((double) this.VAR_SSHQ_SIZE2 / 2.0) + 1.0);
                  if (this.VAR_SSHQ_SIZE2 >= 2 & this.VAR_SSHQ_SIZE2 == num25)
                    --num25;
                  if (num24 >= num25 - sshqGroups.Weight[index18])
                  {
                    int unitCounter9 = this.game.Data.UnitCounter;
                    for (int index19 = 0; index19 <= unitCounter9; ++index19)
                    {
                      if (this.game.Data.UnitObj[index19].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index19].X > -1 & !this.game.Data.UnitObj[index19].IsHQ && this.game.Data.UnitObj[index19].HQ == hq & this.game.Data.UnitObj[index19].Historical > -1 && this.game.Data.UnitObj[index19].AISubStrictGroup == num10 && sshqGroups.Weight[index18] < this.VAR_SSHQ_SIZE2)
                      {
                        this.game.Data.UnitObj[index19].AISubStrictGroup = num23;
                        flag4 = true;
                        break;
                      }
                    }
                  }
                  if (flag4)
                    break;
                }
              }
              if (flag4)
                break;
            }
            if (num7 > 999)
              break;
          }
        }
      }
    }

    public SimpleList GetHQLandscapeTypeAPCost(int hq, int sshq)
    {
      int num1 = 9999;
      int landscapeTypeCounter1 = this.game.Data.LandscapeTypeCounter;
      for (int index = 0; index <= landscapeTypeCounter1; ++index)
      {
        if (this.game.Data.LandscapeTypeObj[index].MoveCost[this.VAR_MOST_USED_MOVEMENTYPE] < num1)
          num1 = this.game.Data.LandscapeTypeObj[index].MoveCost[this.VAR_MOST_USED_MOVEMENTYPE];
      }
      if (num1 < 10 | num1 > 50)
        num1 = 25;
      SimpleList simpleList1 = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (index1 == hq & (sshq == -1 | sshq == 1) | !this.game.Data.UnitObj[index1].IsHQ & this.game.Data.UnitObj[index1].HQ == hq & (sshq == -1 | this.game.Data.UnitObj[index1].AISubStrictGroup == sshq))
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int type = this.game.Data.SFObj[sf].Type;
            int moveType = this.game.Data.SFTypeObj[type].MoveType;
            int tweight = this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
            int nr = simpleList1.FindNr(moveType);
            if (nr > -1)
            {
              int[] weight = simpleList1.Weight;
              int[] numArray = weight;
              int index3 = nr;
              int index4 = index3;
              int num2 = weight[index3] + tweight;
              numArray[index4] = num2;
            }
            else
              simpleList1.Add(moveType, tweight);
          }
        }
      }
      if (simpleList1.Counter == -1)
      {
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index5 = 0; index5 <= unitCounter2; ++index5)
        {
          int sfCount = this.game.Data.UnitObj[index5].SFCount;
          for (int index6 = 0; index6 <= sfCount; ++index6)
          {
            int sf = this.game.Data.UnitObj[index5].SFList[index6];
            int type = this.game.Data.SFObj[sf].Type;
            int moveType = this.game.Data.SFTypeObj[type].MoveType;
            int tweight = this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
            int nr = simpleList1.FindNr(moveType);
            if (nr > -1)
            {
              int[] weight = simpleList1.Weight;
              int[] numArray = weight;
              int index7 = nr;
              int index8 = index7;
              int num3 = weight[index7] + tweight;
              numArray[index8] = num3;
            }
            else
              simpleList1.Add(moveType, tweight);
          }
        }
      }
      SimpleList landscapeTypeApCost = new SimpleList();
      int landscapeTypeCounter2 = this.game.Data.LandscapeTypeCounter;
      for (int tid1 = 0; tid1 <= landscapeTypeCounter2; ++tid1)
      {
        SimpleList simpleList2 = new SimpleList();
        int counter1 = simpleList1.Counter;
        for (int index = 0; index <= counter1; ++index)
        {
          int tid2 = simpleList1.Id[index];
          int tdata1 = 1 + simpleList1.Weight[index];
          int tweight = this.game.Data.LandscapeTypeObj[tid1].MoveCost[tid2];
          if (tweight > 999)
            tweight = num1 * 13;
          simpleList2.Add(tid2, tweight, tdata1);
        }
        simpleList2.Sort();
        long num4 = 0;
        long num5 = 0;
        int counter2 = simpleList2.Counter;
        for (int index = 0; index <= counter2; ++index)
        {
          int num6 = simpleList2.Id[index];
          int num7 = simpleList2.Weight[index];
          int num8 = (int) Math.Round((double) simpleList2.Data1[index] * (1.0 + (double) (index + 1) / (double) (simpleList2.Counter + 1)));
          num4 += (long) (num7 * num8);
          num5 += (long) num8;
        }
        long num9 = (long) Math.Round((double) num4 / (double) num5);
        if (num9 > 0L)
        {
          int num10 = num1;
          long tweight = num9 <= (long) num10 ? 1L : (long) (int) Math.Round(Math.Ceiling((double) num9 / (double) num10));
          if (1L > tweight)
            tweight = 1L;
          if (tweight > 9L)
            tweight = 9L;
          landscapeTypeApCost.Add(tid1, (int) tweight);
        }
      }
      return landscapeTypeApCost;
    }

    public void InitFrontlinesAssignUnitsToFronts(
      AIMatrix fronts,
      ref AIFrontList tfrontlist,
      ref AIMatrix ownerMatrix,
      ref AIMatrix enemyPower,
      ref AIMatrix tstrength,
      ref AIMatrix tfrontlines)
    {
      this.frontMatrix = fronts.Clone();
      DC2AIClass tai1 = this;
      AIMatrix aiMatrix1 = new AIMatrix(ref tai1);
      int mapWidth1 = this.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          aiMatrix1.Value[index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index2].VP;
          if (this.VAR_ZONES_TYPE == 2 & this.map.HexObj[index1, index2].Regime != this.game.Data.Turn)
          {
            if (this.VAR_MATRIX_RETREAT.Value[index1, index2] >= 300)
              aiMatrix1.Value[index1, index2] = (int) Math.Round((double) this.game.Data.MapObj[0].HexObj[index1, index2].VP / 8.0);
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] >= 200)
              aiMatrix1.Value[index1, index2] = (int) Math.Round((double) this.game.Data.MapObj[0].HexObj[index1, index2].VP / 4.0);
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] > 100)
              aiMatrix1.Value[index1, index2] = (int) Math.Round((double) this.game.Data.MapObj[0].HexObj[index1, index2].VP / 2.0);
            else if (this.VAR_MATRIX_RETREAT.Value[index1, index2] <= 50)
              aiMatrix1.Value[index1, index2] = (int) Math.Round((double) this.game.Data.MapObj[0].HexObj[index1, index2].VP * 1.33);
          }
          if ((this.VAR_ZONES_TYPE == 0 | this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3) & this.map.HexObj[index1, index2].Regime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[index1, index2].VP > 1)
          {
            int[,] numArray1 = aiMatrix1.Value;
            int[,] numArray2 = numArray1;
            int index3 = index1;
            int index4 = index3;
            int index5 = index2;
            int index6 = index5;
            int num = numArray1[index3, index5] + 5;
            numArray2[index4, index6] = num;
          }
          if ((this.VAR_ZONES_TYPE == 0 | this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3) & this.map.HexObj[index1, index2].Regime > -1 && this.game.Data.MapObj[0].HexObj[index1, index2].VP > 1)
          {
            int[,] numArray3 = aiMatrix1.Value;
            int[,] numArray4 = numArray3;
            int index7 = index1;
            int index8 = index7;
            int index9 = index2;
            int index10 = index9;
            int num = numArray3[index7, index9] + 5;
            numArray4[index8, index10] = num;
          }
        }
      }
      if (this.game.Data.Product >= 6)
        aiMatrix1 = aiMatrix1.AverageValuesForAnyRegime(1);
      aiMatrix1.ExpandAndRemoveValueForAnyRegime(99);
      aiMatrix1.Percentify();
      AIMatrix aiMatrix2 = this.VAR_MATRIX_RETREAT.Clone().AverageValuesForSameRegime(this.VAR_FRONTLINE_DEPTH * 1, ownerMatrix);
      AIMatrix aiMatrix3 = fronts.Clone();
      aiMatrix3.ExpandValueForAnyRegime(4);
      aiMatrix3.RemoveValuesByMask(ownerMatrix, 1);
      aiMatrix3.AddValue(fronts, 1);
      this.AddLog("ASSIGN UNITS TO FRONTS");
      if (tfrontlist.Counter == -1)
      {
        int mapWidth2 = this.map.MapWidth;
        for (int index11 = 0; index11 <= mapWidth2; ++index11)
        {
          int mapHeight1 = this.map.MapHeight;
          for (int index12 = 0; index12 <= mapHeight1; ++index12)
          {
            if (fronts.Value[index11, index12] > 0 && tfrontlist.GetFrontNr(fronts.Value[index11, index12]) == -1)
            {
              DC2AIClass tai2 = this;
              AIFront tFront = new AIFront(ref tai2, 1);
              tFront.FrontID = fronts.Value[index11, index12];
              tFront.enemyPower = 0;
              tFront.bridgeCount = 0;
              tFront.vpScoreAveragePercent = 0;
              int num1 = 0;
              int num2 = 0;
              int num3 = 0;
              int num4 = 0;
              int num5 = 0;
              int num6 = 0;
              int num7 = 0;
              int num8 = 0;
              int mapWidth3 = this.map.MapWidth;
              for (int x = 0; x <= mapWidth3; ++x)
              {
                int mapHeight2 = this.map.MapHeight;
                for (int y = 0; y <= mapHeight2; ++y)
                {
                  if (this.frontlinesMatrix.Value[x, y] > 0 & fronts.Value[x, y] == fronts.Value[index11, index12])
                    ++tFront.FrontHexes;
                  if (fronts.Value[x, y] == fronts.Value[index11, index12])
                  {
                    if (tfrontlines.Value[x, y] > 0)
                    {
                      ++num7;
                      num8 += tstrength.Value[x, y];
                    }
                    ++num1;
                    num4 += this.VAR_MATRIX_STRENGTH.Value[x, y];
                    num6 += aiMatrix2.Value[x, y];
                    num5 += aiMatrix1.Value[x, y];
                    if ((this.VAR_ZONES_TYPE == 0 | this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3) & this.game.HandyFunctionsObj.HasHexBridge(x, y, 0) | this.game.HandyFunctionsObj.HasHexBrokenBridge(x, y, 0))
                      ++tFront.bridgeCount;
                  }
                  if (aiMatrix3.Value[x, y] == tFront.FrontID)
                  {
                    tFront.enemyPower += enemyPower.Value[x, y];
                    ++num2;
                    num3 += aiMatrix1.Value[x, y];
                    if ((this.VAR_ZONES_TYPE == 0 | this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3) & this.game.HandyFunctionsObj.HasHexBridge(x, y, 0) | this.game.HandyFunctionsObj.HasHexBrokenBridge(x, y, 0))
                      ++tFront.bridgeCount;
                  }
                }
              }
              if (num7 > 0)
                num8 = (int) Math.Round(Math.Round((double) num8 / (double) num7));
              tFront.OrigAverageStrength = (float) num8;
              if (num1 > 0)
              {
                int num9 = (int) Math.Round((double) num4 / (double) num1);
                if (num9 > 0)
                  tFront.enemyPower = (int) Math.Round((double) tFront.enemyPower * (100.0 / (double) num9));
              }
              if (this.VAR_ZONES_TYPE == 2 & num1 > 0 & num2 > 0)
                tFront.vpScoreAveragePercent = (int) Math.Round((double) (num5 * 2 + num3) / (double) (num1 * 2 + num2));
              else if (this.VAR_ZONES_TYPE == 1 & num1 > 0 & num2 > 0)
                tFront.vpScoreAveragePercent = (int) Math.Round((double) (num5 + num3 * 2) / ((double) num1 + (double) num2 / 2.0));
              else if ((this.VAR_ZONES_TYPE == 0 | this.VAR_ZONES_TYPE == 3) & num2 > 0 | num1 > 0)
                tFront.vpScoreAveragePercent = (int) Math.Round((double) (num5 + num3) / (double) (num1 + num2));
              if (num1 > 0)
                tFront.retreatAverageScore = (int) Math.Round((double) num6 / (double) num1);
              tfrontlist.AddFront(tFront, false);
            }
          }
        }
      }
      int index13;
      if (this.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE)
      {
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int index14 = 0; index14 <= mapWidth4; ++index14)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index15 = 0; index15 <= mapHeight; ++index15)
          {
            if (this.friendlySupplyMatrix.Value[index14, index15] == 0)
            {
              index13 = fronts.Value[index14, index15];
              if (index13 > 0)
              {
                AIFront front = tfrontlist.FindFront(index13);
                if (!Information.IsNothing((object) front))
                  front.hasSupplySource = true;
              }
            }
          }
        }
      }
      bool[,] flagArray = new bool[tfrontlist.Counter + 1, tfrontlist.Counter + 1];
      int[,] numArray5 = new int[tfrontlist.Counter + 1, tfrontlist.Counter + 1];
      int[,] numArray6 = new int[tfrontlist.Counter + 1, tfrontlist.Counter + 1];
      int[,] numArray7 = new int[tfrontlist.Counter + 1, tfrontlist.Counter + 1];
      float[,] numArray8 = new float[tfrontlist.Counter + 1, tfrontlist.Counter + 1];
      float[,] numArray9 = new float[tfrontlist.Counter + 1, tfrontlist.Counter + 1];
      int[] numArray10 = new int[tfrontlist.Counter + 1];
      int[] numArray11 = new int[tfrontlist.Counter + 1];
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int num10 = 0;
      int counter1 = tfrontlist.Counter;
      for (int tdata1 = 0; tdata1 <= counter1; ++tdata1)
      {
        AIFront aiFront1 = tfrontlist.Front[tdata1];
        if (aiFront1.FrontType == 1)
        {
          ++num10;
          this.AddLog("***" + aiFront1.FrontID.ToString());
          AIMatrix aiMatrix4 = fronts.Clone();
          aiMatrix4.SetAllValuesNotValueXTo(0, aiFront1.FrontID);
          aiMatrix4.SetValueXToValueY(aiFront1.FrontID, 1);
          if (this.CustomCalls.CustomDoStrategicIterations())
            aiMatrix4.ExpandAndAddValueForAnyRegime(39);
          else
            aiMatrix4.ExpandAndAddValueForAnyRegime(9);
          int counter2 = tfrontlist.Counter;
          for (int index16 = 0; index16 <= counter2; ++index16)
          {
            if (index16 > tdata1)
            {
              AIFront aiFront2 = tfrontlist.Front[index16];
              if (aiFront2.FrontType == 1)
              {
                int num11 = 9999;
                int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
                for (int index17 = 0; index17 <= mapWidth5; ++index17)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index18 = 0; index18 <= mapHeight; ++index18)
                  {
                    if (fronts.Value[index17, index18] == aiFront2.FrontID && aiMatrix4.Value[index17, index18] < num11)
                      num11 = aiMatrix4.Value[index17, index18];
                  }
                }
                numArray5[tdata1, index16] = num11;
                flagArray[tdata1, index16] = true;
                this.AddLog("  -BirdFlies to " + aiFront2.FrontID.ToString() + " = " + num11.ToString());
              }
            }
          }
          AIMatrix aiMatrix5 = fronts.Clone();
          aiMatrix5.SetAllValuesNotValueXTo(0, aiFront1.FrontID);
          AIMatrix tOwnerMat1 = ownerMatrix.Clone();
          tOwnerMat1.SetValueXToValueY(0, 1);
          aiMatrix5.SetValueXToValueY(aiFront1.FrontID, 1);
          if (this.CustomCalls.CustomDoStrategicIterations())
            aiMatrix5.ExpandAndAddValueForSameOwner(59, ref tOwnerMat1);
          else
            aiMatrix5.ExpandAndAddValueForSameOwner(19, ref tOwnerMat1);
          int counter3 = tfrontlist.Counter;
          for (int index19 = 0; index19 <= counter3; ++index19)
          {
            if (index19 > tdata1)
            {
              AIFront aiFront3 = tfrontlist.Front[index19];
              if (aiFront3.FrontType == 1)
              {
                int num12 = 9999;
                int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
                for (int index20 = 0; index20 <= mapWidth6; ++index20)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index21 = 0; index21 <= mapHeight; ++index21)
                  {
                    if (fronts.Value[index20, index21] == aiFront3.FrontID && aiMatrix5.Value[index20, index21] < num12)
                      num12 = aiMatrix5.Value[index20, index21];
                  }
                }
                numArray6[tdata1, index19] = num12;
                flagArray[tdata1, index19] = true;
                this.AddLog("  -FriendlyHex to " + aiFront3.FrontID.ToString() + " = " + num12.ToString());
              }
            }
          }
          AIMatrix aiMatrix6 = fronts.Clone();
          aiMatrix6.SetAllValuesNotValueXTo(0, aiFront1.FrontID);
          aiMatrix6.SetValueXToValueY(aiFront1.FrontID, 1);
          aiMatrix6.ExpandValueWithoutConditionsHighest(1);
          aiMatrix6.RemoveValuesByMask(ownerMatrix, 1);
          AIMatrix tOwnerMat2 = ownerMatrix.Clone();
          tOwnerMat2.SetValueXToValueY(0, 2);
          if (this.CustomCalls.CustomDoStrategicIterations())
            aiMatrix6.ExpandAndAddValueForSameOwner(59, ref tOwnerMat2);
          else
            aiMatrix6.ExpandAndAddValueForSameOwner(19, ref tOwnerMat2);
          int counter4 = tfrontlist.Counter;
          for (int index22 = 0; index22 <= counter4; ++index22)
          {
            if (index22 > tdata1)
            {
              AIFront aiFront4 = tfrontlist.Front[index22];
              if (aiFront4.FrontType == 1)
              {
                int num13 = 9999;
                int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
                for (int index23 = 0; index23 <= mapWidth7; ++index23)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index24 = 0; index24 <= mapHeight; ++index24)
                  {
                    if (ownerMatrix.Value[index23, index24] == 2 & aiMatrix3.Value[index23, index24] == aiFront4.FrontID && aiMatrix6.Value[index23, index24] < num13)
                      num13 = aiMatrix6.Value[index23, index24];
                  }
                }
                numArray7[tdata1, index22] = num13;
                flagArray[tdata1, index22] = true;
                this.AddLog("  -EnemyHex to " + aiFront4.FrontID.ToString() + " = " + num13.ToString());
              }
            }
          }
          float a1 = -1f;
          float a2 = -1f;
          int counter5 = tfrontlist.Counter;
          int tdata2_1;
          int tdata2_2;
          for (int index25 = 0; index25 <= counter5; ++index25)
          {
            if (flagArray[tdata1, index25] && numArray5[tdata1, index25] > 0 & numArray6[tdata1, index25] < 99 & numArray7[tdata1, index25] < 99 & numArray5[tdata1, index25] < 20)
            {
              float num14 = (float) numArray6[tdata1, index25] / (float) numArray5[tdata1, index25];
              if (numArray5[tdata1, index25] > 10)
                num14 = num14 * 0.5f + (float) ((double) num14 * 0.5 * (1.0 - (double) (numArray5[tdata1, index25] - 10) / 10.0));
              if ((double) num14 > (double) a2)
              {
                a2 = num14;
                tdata2_1 = index25;
              }
              float num15 = (float) numArray7[tdata1, index25] / (float) numArray5[tdata1, index25];
              if (numArray5[tdata1, index25] > 10)
                num15 = num15 * 0.5f + (float) ((double) num15 * 0.5 * (1.0 - (double) (numArray5[tdata1, index25] - 10) / 10.0));
              if ((double) num15 > (double) a1)
              {
                a1 = num15;
                tdata2_2 = index25;
              }
            }
          }
          int tid;
          if (tdata2_1 > -1)
          {
            ++tid;
            simpleList1.Add(tid, (int) Math.Round((double) a2), tdata1, tdata2_1);
            this.AddLog(aiFront1.FrontID.ToString() + " => BestOppRatio: " + a2.ToString() + " (ToFrontID=" + this.frontList.Front[tdata2_1].FrontID.ToString() + ")");
          }
          if (tdata2_2 > -1)
          {
            ++tid;
            simpleList2.Add(tid, (int) Math.Round((double) a1), tdata1, tdata2_2);
            this.AddLog(aiFront1.FrontID.ToString() + " => BestThreatRatio: " + a1.ToString() + " (ToFrontID=" + this.frontList.Front[tdata2_2].FrontID.ToString() + ")");
          }
        }
      }
      if (this.VAR_ALLOW_THREAT_ENCIRCLE & this.CustomCalls.CustomDoStrategicIterations())
      {
        this.AddLog("");
        this.AddLog("SET TOP THREATS");
        index13 = (int) Math.Round((double) num10 / 10.0);
        if (1 > index13)
          index13 = 1;
        for (int index26 = 0; index26 < index13; ++index26)
        {
          simpleList2.ReverseSort();
          int index27 = simpleList2.Data1[0];
          int index28 = simpleList2.Data2[0];
          int num16 = simpleList2.Weight[0];
          if (num16 >= 2)
          {
            int num17 = num16 * 20;
            if (num17 > 100)
              num17 = (int) Math.Round(100.0 + Math.Sqrt((double) (num17 - 100)) * 4.0);
            if (num17 > 150)
              num17 = (int) Math.Round(150.0 + Math.Sqrt((double) (num17 - 100)));
            int num18 = num17;
            if (this.VAR_ZONES_TYPE == 1)
              num18 = (int) Math.Round((double) num18 / 2.0);
            if (num18 > tfrontlist.Front[index27].ThreatPercentage)
              tfrontlist.Front[index27].ThreatPercentage = num18;
            this.AddLog(tfrontlist.Front[index27].FrontID.ToString() + " THREAT = " + num18.ToString());
            num18 = num17;
            if (this.VAR_ZONES_TYPE == 1)
              num18 = (int) Math.Round((double) num18 / 2.0);
            if (num18 > tfrontlist.Front[index28].ThreatPercentage)
              tfrontlist.Front[index28].ThreatPercentage = num18;
            this.AddLog(tfrontlist.Front[index28].FrontID.ToString() + " THREAT = " + num18.ToString());
            this.frontMatrix = fronts.Clone();
            SimpleList neighbourFrontList1 = tfrontlist.Front[index27].GetNeighbourFrontList();
            int counter6 = neighbourFrontList1.Counter;
            for (int index29 = 0; index29 <= counter6; ++index29)
            {
              for (int counter7 = simpleList2.Counter; counter7 >= 1; counter7 += -1)
              {
                if ((neighbourFrontList1.Id[index29] == tfrontlist.Front[simpleList2.Data1[counter7]].FrontID | neighbourFrontList1.Id[index29] == tfrontlist.Front[simpleList2.Data2[counter7]].FrontID) & simpleList2.Data5[counter7] < 100)
                {
                  simpleList2.Weight[counter7] = (int) Math.Round((double) simpleList2.Weight[counter7] / 4.0) - 1;
                  simpleList2.Data5[counter7] = 100;
                  this.AddLog("Reduce threat /4 for " + neighbourFrontList1.Id[index29].ToString());
                }
              }
              SimpleList neighbourFrontList2 = tfrontlist.FindFront(neighbourFrontList1.Id[index29]).GetNeighbourFrontList();
              int counter8 = neighbourFrontList2.Counter;
              for (int index30 = 0; index30 <= counter8; ++index30)
              {
                for (int counter9 = simpleList2.Counter; counter9 >= 1; counter9 += -1)
                {
                  if ((neighbourFrontList2.Id[index30] == tfrontlist.Front[simpleList2.Data1[counter9]].FrontID | neighbourFrontList2.Id[index30] == tfrontlist.Front[simpleList2.Data2[counter9]].FrontID) & simpleList2.Data5[counter9] < 50)
                  {
                    simpleList2.Weight[counter9] = (int) Math.Round((double) simpleList2.Weight[counter9] / 2.0) - 1;
                    simpleList2.Data5[counter9] = 50;
                    this.AddLog("Reduce threat /2 for " + neighbourFrontList1.Id[index29].ToString());
                  }
                }
              }
            }
          }
          simpleList2.Remove(simpleList2.Id[0]);
        }
      }
      this.AddLog("");
      if (this.VAR_ALLOW_OPPORTUNITY_ENCIRCLE & this.CustomCalls.CustomDoStrategicIterations())
      {
        this.AddLog("");
        this.AddLog("SET TOP OPPORTUNITIES");
        index13 = (int) Math.Round((double) num10 / 8.0);
        if (1 > index13)
          index13 = 1;
        for (int index31 = 0; index31 < index13; ++index31)
        {
          SimpleList simpleList3 = simpleList1;
          simpleList3.ReverseSort();
          int index32 = simpleList3.Data1[0];
          int index33 = simpleList3.Data2[0];
          int num19 = simpleList3.Weight[0];
          if ((double) num19 >= 1.5)
          {
            int num20 = num19 * 20;
            if (num20 > 100)
              num20 = (int) Math.Round(100.0 + Math.Sqrt((double) (num20 - 100)) * 4.0);
            if (num20 > 150)
              num20 = (int) Math.Round(150.0 + Math.Sqrt((double) (num20 - 100)));
            int num21 = num20;
            if (this.VAR_ZONES_TYPE == 2)
              num21 = (int) Math.Round((double) num21 / 2.0);
            if (num21 > tfrontlist.Front[index32].OpportunityPercentage)
              tfrontlist.Front[index32].OpportunityPercentage = num21;
            this.AddLog(tfrontlist.Front[index32].FrontID.ToString() + " OPPORTUNITY = " + num21.ToString());
            num21 = num20;
            if (this.VAR_ZONES_TYPE == 2)
              num21 = (int) Math.Round((double) num21 / 2.0);
            if (num21 > tfrontlist.Front[index33].OpportunityPercentage)
              tfrontlist.Front[index33].OpportunityPercentage = num21;
            this.AddLog(tfrontlist.Front[index33].FrontID.ToString() + " OPPORTUNITY = " + num21.ToString());
            this.frontMatrix = fronts.Clone();
            SimpleList neighbourFrontList3 = tfrontlist.Front[index32].GetNeighbourFrontList();
            int counter10 = neighbourFrontList3.Counter;
            for (int index34 = 0; index34 <= counter10; ++index34)
            {
              for (int counter11 = simpleList3.Counter; counter11 >= 1; counter11 += -1)
              {
                if ((neighbourFrontList3.Id[index34] == tfrontlist.Front[simpleList3.Data1[counter11]].FrontID | neighbourFrontList3.Id[index34] == tfrontlist.Front[simpleList3.Data2[counter11]].FrontID) & simpleList3.Data5[counter11] < 100)
                {
                  simpleList3.Weight[counter11] = (int) Math.Round((double) simpleList3.Weight[counter11] / 4.0) - 1;
                  simpleList3.Data5[counter11] = 100;
                  this.AddLog("Reduce opportunity /4 for " + neighbourFrontList3.Id[index34].ToString());
                }
              }
              SimpleList neighbourFrontList4 = tfrontlist.FindFront(neighbourFrontList3.Id[index34]).GetNeighbourFrontList();
              int counter12 = neighbourFrontList4.Counter;
              for (int index35 = 0; index35 <= counter12; ++index35)
              {
                for (int counter13 = simpleList3.Counter; counter13 >= 1; counter13 += -1)
                {
                  if ((neighbourFrontList4.Id[index35] == tfrontlist.Front[simpleList3.Data1[counter13]].FrontID | neighbourFrontList4.Id[index35] == tfrontlist.Front[simpleList3.Data2[counter13]].FrontID) & simpleList3.Data5[counter13] < 50)
                  {
                    simpleList3.Weight[counter13] = (int) Math.Round((double) simpleList3.Weight[counter13] / 2.0) - 1;
                    simpleList3.Data5[counter13] = 50;
                    this.AddLog("Reduce opportunity /2 for " + neighbourFrontList3.Id[index34].ToString());
                  }
                }
              }
            }
          }
          simpleList3.Remove(simpleList3.Id[0]);
        }
      }
      this.AddLog("");
      int num22 = 6;
      if (this.game.Data.Product == 7)
        num22 = 8;
      int num23 = 9;
      AIFront tempFront;
      if (this.VAR_USE_STRICT_HQFRONT & this.CustomCalls.CustomDoStrategicIterations())
      {
        this.SSHQSettings(fronts, ref this.frontList, ref ownerMatrix);
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index36 = 0; index36 <= unitCounter1; ++index36)
        {
          if (this.game.Data.UnitObj[index36].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index36].AISubStrictGroup > num23)
            num23 = this.game.Data.UnitObj[index36].AISubStrictGroup;
        }
        AIUnitList hqlist = new AIUnitList();
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index37 = 0; index37 <= unitCounter2; ++index37)
        {
          if (this.game.Data.UnitObj[index37].X > -1 & this.game.Data.UnitObj[index37].HQ > -1 & this.game.Data.UnitObj[index37].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[index37].IsHQ & this.game.Data.UnitObj[index37].PreDef == -1)
          {
            int hq = this.game.Data.UnitObj[index37].HQ;
            if (!hqlist.CheckIfPresentUnr(hq) && this.game.Data.UnitObj[hq].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[hq].Historical].Type <= num22)
            {
              SimpleList sshqGroups = this.GetSSHQGroups(hq);
              int counter14 = sshqGroups.Counter;
              for (index13 = 0; index13 <= counter14; ++index13)
              {
                int tdata2 = 0;
                int unitCounter3 = this.game.Data.UnitCounter;
                for (int index38 = 0; index38 <= unitCounter3; ++index38)
                {
                  if (this.game.Data.UnitObj[index38].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index38].PreDef == -1 && this.game.Data.UnitObj[index38].HQ == hq & this.game.Data.UnitObj[index38].AISubStrictGroup == sshqGroups.Id[index13] && this.game.Data.UnitObj[index38].SupplyConsume > 25)
                    tdata2 = tdata2 + (int) Math.Round((double) this.game.Data.UnitObj[index38].TempUnitPower * 0.8) + (int) Math.Round((double) this.game.Data.UnitObj[index38].TempUnitPowerAbs * 0.2);
                }
                hqlist.add(hq, sshqGroups.Id[index13], sshqGroups.Weight[index13], tdata2);
              }
            }
          }
        }
        if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(-1))
        {
          int unitCounter4 = this.game.Data.UnitCounter;
          for (int tunr = 0; tunr <= unitCounter4; ++tunr)
          {
            if (this.game.Data.UnitObj[tunr].X > -1 & this.game.Data.UnitObj[tunr].HQ == -1 & this.game.Data.UnitObj[tunr].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[tunr].IsHQ & this.game.Data.UnitObj[tunr].PreDef == -1 && !hqlist.CheckIfPresentUnr(tunr))
            {
              int tdata2 = (int) Math.Round((double) this.game.Data.UnitObj[tunr].TempUnitPower * 0.8) + (int) Math.Round((double) this.game.Data.UnitObj[tunr].TempUnitPowerAbs * 0.2);
              this.game.Data.UnitObj[tunr].AISubStrictGroup = -1;
              hqlist.add(tunr, -1, 1, tdata2);
            }
          }
        }
        if (this.CustomCalls.HasCustumCalls())
          this.CustomCalls.CustomRuleHQtoFrontAssign_CustomScripting_BeforeHqsToFrontAssigns(ref hqlist, ref tfrontlist);
        SimpleList simpleList4 = new SimpleList();
        int mapWidth8 = this.game.Data.MapObj[0].MapWidth;
        for (int index39 = 0; index39 <= mapWidth8; ++index39)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index40 = 0; index40 <= mapHeight; ++index40)
          {
            if (fronts.Value[index39, index40] > 0)
            {
              index13 = fronts.Value[index39, index40];
              if (this.frontList.GetFrontNr(index13) > -1)
              {
                int nr = simpleList4.FindNr(index13);
                int tweight = 0;
                if (this.friendlySupplyMatrix.Value[index39, index40] < this.VAR_SUPPLY_25PERCENT_RANGE)
                  tweight = 1;
                if (nr == -1)
                {
                  simpleList4.Add(index13, tweight, 1);
                }
                else
                {
                  int[] weight = simpleList4.Weight;
                  int[] numArray12 = weight;
                  int index41 = nr;
                  int index42 = index41;
                  int num24 = weight[index41] + tweight;
                  numArray12[index42] = num24;
                  int[] data1 = simpleList4.Data1;
                  int[] numArray13 = data1;
                  int index43 = nr;
                  int index44 = index43;
                  int num25 = data1[index43] + 1;
                  numArray13[index44] = num25;
                }
              }
            }
          }
        }
        int num26 = 1;
        do
        {
          this.AddLog("phase: " + num26.ToString());
          if (this.VAR_ZONES_TYPE >= 1 & num26 == 1)
          {
            SimpleList simpleList5 = new SimpleList();
            int mapWidth9 = this.game.Data.MapObj[0].MapWidth;
            for (int tdata1 = 0; tdata1 <= mapWidth9; ++tdata1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
              {
                if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 & this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] < 200000)
                  tdata1 = tdata1;
                if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 & this.VAR_ZONES_TYPE == 1 & ownerMatrix.Value[tdata1, tdata2] == 2 | this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 & this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] < 200000 & this.VAR_ZONES_TYPE == 3 & ownerMatrix.Value[tdata1, tdata2] == 2)
                {
                  if (simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
                    simpleList5.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 1, tdata1, tdata2);
                }
                else if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 & this.VAR_ZONES_TYPE == 2 & ownerMatrix.Value[tdata1, tdata2] == 1 | this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 200000 & this.VAR_ZONES_TYPE == 3 & ownerMatrix.Value[tdata1, tdata2] == 1)
                {
                  if (simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
                  {
                    simpleList5.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 1, tdata1, tdata2, tdata4: 1);
                  }
                  else
                  {
                    int[] weight = simpleList5.Weight;
                    int[] numArray14 = weight;
                    int nr1 = simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                    int index45 = nr1;
                    int num27 = weight[nr1] + 1;
                    numArray14[index45] = num27;
                    int[] data4 = simpleList5.Data4;
                    int[] numArray15 = data4;
                    int nr2 = simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                    int index46 = nr2;
                    int num28 = data4[nr2] + 1;
                    numArray15[index46] = num28;
                  }
                }
                else if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 & this.VAR_ZONES_TYPE == 2 & ownerMatrix.Value[tdata1, tdata2] == 2 | this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 200000 & this.VAR_ZONES_TYPE == 3 & ownerMatrix.Value[tdata1, tdata2] == 2)
                {
                  if (simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]) == -1)
                  {
                    simpleList5.Add(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2], 1, tdata1, tdata2, 1, 1);
                  }
                  else
                  {
                    int[] data3 = simpleList5.Data3;
                    int[] numArray16 = data3;
                    int nr3 = simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                    int index47 = nr3;
                    int num29 = data3[nr3] + 1;
                    numArray16[index47] = num29;
                    int[] data4 = simpleList5.Data4;
                    int[] numArray17 = data4;
                    int nr4 = simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                    int index48 = nr4;
                    int num30 = data4[nr4] + 1;
                    numArray17[index48] = num30;
                  }
                }
                if (this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 0 & this.VAR_ZONES_TYPE == 2 | this.VAR_MATRIX_ZONES.Value[tdata1, tdata2] > 200000 & this.VAR_ZONES_TYPE == 3 && fronts.Value[tdata1, tdata2] > 0 & fronts.Value[tdata1, tdata2] < 1000000)
                {
                  int[] data5 = simpleList5.Data5;
                  int[] numArray18 = data5;
                  int nr = simpleList5.FindNr(this.VAR_MATRIX_ZONES.Value[tdata1, tdata2]);
                  int index49 = nr;
                  int num31 = data5[nr] + 1;
                  numArray18[index49] = num31;
                }
              }
            }
            bool flag1 = false;
            if (this.CustomCalls.HasCustumCalls() && this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(-1))
              flag1 = true;
            int counter15 = simpleList5.Counter;
            for (int index50 = 0; index50 <= counter15; ++index50)
            {
              bool flag2 = false;
              if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] > 200000 && this.VAR_USE_BROAD_DEFENSIVE_ZONES && simpleList5.Data5[index50] > 0 & simpleList5.Data4[index50] >= this.VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM)
                flag2 = true;
              DC2AIClass tai3 = this;
              AIMatrix aiMatrix7 = new AIMatrix(ref tai3);
              if (this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 2 & flag2 | this.VAR_ZONES_TYPE == 3 & (simpleList5.Id[index50] < 200000 | simpleList5.Id[index50] > 200000 & flag2))
              {
                aiMatrix7.SetAllValuesTo(9999);
                int mapWidth10 = this.game.Data.MapObj[0].MapWidth;
                for (int index51 = 0; index51 <= mapWidth10; ++index51)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index52 = 0; index52 <= mapHeight; ++index52)
                  {
                    if (this.VAR_MATRIX_ZONES.Value[index51, index52] == simpleList5.Id[index50])
                      aiMatrix7.Value[index51, index52] = 0;
                  }
                }
                int extraForEnemy = 10;
                if (this.game.Data.Product == 7)
                  extraForEnemy = 10;
                aiMatrix7.ExpandAsSimplifiedSupplyRouteMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1, true, true, false, extraForEnemy, true);
              }
              else
                aiMatrix7.SetAllValuesTo(0);
              if ((double) this.game.Data.RuleVar[748] < 1.0 && this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] < 200000)
              {
                SimpleList simpleList6 = new SimpleList();
                int unitCounter5 = this.game.Data.UnitCounter;
                for (int index53 = 0; index53 <= unitCounter5; ++index53)
                {
                  if (!this.game.Data.UnitObj[index53].IsHQ & this.game.Data.UnitObj[index53].HQ > -1 & this.game.Data.UnitObj[index53].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index53].PreDef == -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[index53].HQ].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitObj[index53].HQ].Historical].AIlist == simpleList5.Id[index50])
                  {
                    int historical = this.game.Data.UnitObj[this.game.Data.UnitObj[index53].HQ].Historical;
                    int nr = simpleList6.FindNr(historical);
                    if (nr > -1)
                    {
                      int[] data1 = simpleList6.Data1;
                      int[] numArray19 = data1;
                      int index54 = nr;
                      int index55 = index54;
                      int num32 = data1[index54] + 1;
                      numArray19[index55] = num32;
                      int[] data2 = simpleList6.Data2;
                      int[] numArray20 = data2;
                      int index56 = nr;
                      int index57 = index56;
                      int num33 = data2[index56] + aiMatrix7.Value[this.game.Data.UnitObj[index53].X, this.game.Data.UnitObj[index53].Y];
                      numArray20[index57] = num33;
                    }
                    else
                      simpleList6.Add(historical, 0, 1, aiMatrix7.Value[this.game.Data.UnitObj[index53].X, this.game.Data.UnitObj[index53].Y]);
                  }
                }
                int counter16 = simpleList6.Counter;
                for (int index58 = 0; index58 <= counter16; ++index58)
                {
                  int num34 = (int) Math.Round((double) simpleList6.Data2[index58] / (double) (1 + simpleList6.Data1[index58]));
                  simpleList6.Weight[index58] = num34;
                }
                simpleList6.Sort();
                if (simpleList6.Counter > 0)
                {
                  int counter17 = simpleList6.Counter;
                  for (int index59 = 1; index59 <= counter17; ++index59)
                  {
                    int index60 = simpleList6.Id[index59];
                    this.game.Data.HistoricalUnitObj[index60].AIlist = -1;
                    this.AddLog(this.game.Data.HistoricalUnitObj[index60].Name + " has had its offensive zone #" + simpleList5.Id[index50].ToString() + " assignment WIPED. Because there is another army with same offensive zone that is closer.");
                  }
                }
              }
              DC2AIClass tai4 = this;
              AIMatrix aiMatrix8 = new AIMatrix(ref tai4);
              int num35 = 0;
              aiMatrix8.SetAllValuesTo(9999);
              int unitCounter6 = this.game.Data.UnitCounter;
              for (int index61 = 0; index61 <= unitCounter6; ++index61)
              {
                if (!this.game.Data.UnitObj[index61].IsHQ & (flag1 | this.game.Data.UnitObj[index61].HQ > -1) & this.game.Data.UnitObj[index61].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index61].PreDef == -1)
                {
                  if (this.game.Data.UnitObj[index61].HQ > -1)
                  {
                    if (this.game.Data.UnitObj[this.game.Data.UnitObj[index61].HQ].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitObj[index61].HQ].Historical].AIlist == simpleList5.Id[index50])
                    {
                      aiMatrix8.Value[this.game.Data.UnitObj[index61].X, this.game.Data.UnitObj[index61].Y] = 0;
                      ++num35;
                    }
                  }
                  else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index61].Historical].AIlist == simpleList5.Id[index50])
                  {
                    aiMatrix8.Value[this.game.Data.UnitObj[index61].X, this.game.Data.UnitObj[index61].Y] = 0;
                    ++num35;
                  }
                }
              }
              aiMatrix8.ExpandAsSimplifiedSupplyRouteMatrix(this.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1, NoNeutral: true, useRoads: false, NeverRoads: true);
              SimpleList simpleList7 = new SimpleList();
              int counter18 = tfrontlist.Counter;
              for (int index62 = 0; index62 <= counter18; ++index62)
              {
                index13 = 0;
                int num36 = 0;
                int num37 = 0;
                int num38 = 0;
                int num39 = 0;
                if (this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 2 & flag2 | this.VAR_ZONES_TYPE == 3 & (simpleList5.Id[index50] < 200000 | simpleList5.Id[index50] > 200000 & flag2))
                {
                  int mapWidth11 = this.game.Data.MapObj[0].MapWidth;
                  for (int index63 = 0; index63 <= mapWidth11; ++index63)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index64 = 0; index64 <= mapHeight; ++index64)
                    {
                      if (ownerMatrix.Value[index63, index64] == 2 & aiMatrix3.Value[index63, index64] == tfrontlist.Front[index62].FrontID && !this.VAR_USE_SUPERFRONTS | this.VAR_MATRIX_SUPERFRONT.Value[index63, index64] == this.VAR_MATRIX_SUPERFRONT.Value[simpleList5.Data1[index50], simpleList5.Data2[index50]])
                      {
                        if (this.MLAMatrix.Value[index63, index64] > 0)
                          ++num38;
                        ++num39;
                      }
                      if (fronts.Value[index63, index64] == tfrontlist.Front[index62].FrontID && aiMatrix7.Value[index63, index64] < 999 & aiMatrix8.Value[index63, index64] < 999 && !this.VAR_USE_SUPERFRONTS | this.VAR_MATRIX_SUPERFRONT.Value[index63, index64] == this.VAR_MATRIX_SUPERFRONT.Value[simpleList5.Data1[index50], simpleList5.Data2[index50]])
                      {
                        index13 += aiMatrix7.Value[index63, index64];
                        ++num36;
                        num37 += aiMatrix8.Value[index63, index64];
                      }
                    }
                  }
                }
                else if (this.VAR_ZONES_TYPE == 2 & !flag2 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] > 200000 & !flag2 && tfrontlist.Front[index62].FrontID == simpleList5.Id[index50] + 1000000)
                {
                  num36 = 1;
                  index13 = 10;
                }
                if (tfrontlist.Front[index62].OffensiveZone > 0 | tfrontlist.Front[index62].DefensiveZone > 0)
                  num36 = 0;
                if ((this.VAR_ZONES_TYPE == 2 & flag2 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] > 200000 & flag2) & tfrontlist.Front[index62].FrontID > 1000000)
                  num36 = 0;
                if (num36 > 0 & num35 > 0)
                {
                  int num40 = (int) Math.Round((double) (index13 * 2) / (double) num36) + (int) Math.Round((double) (num37 * 1) / (double) num36);
                  index13 = num36 < 7 ? (num36 < 4 ? (int) Math.Round((double) num40 * 1.25) : (int) Math.Round((double) num40 * 1.125)) : num40 * 1;
                  if ((this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] < 200000) & num39 > 0)
                  {
                    float num41 = num38 <= 0 ? 3f : (float) num39 / (float) num38;
                    index13 = (int) Math.Round((double) index13 * (double) num41 * 0.300000011920929) + (int) Math.Round((double) ((float) index13 * 0.7f));
                  }
                  if (this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] < 200000)
                  {
                    int hq = -1;
                    int unitCounter7 = this.game.Data.UnitCounter;
                    int num42;
                    for (int index65 = 0; index65 <= unitCounter7; ++index65)
                    {
                      if (this.game.Data.UnitObj[index65].IsHQ & this.game.Data.UnitObj[index65].Historical > -1)
                      {
                        if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index65].Historical].AIlist == simpleList5.Id[index50])
                        {
                          hq = index65;
                          num42 = 99999;
                          break;
                        }
                      }
                      else if (flag1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index65].Historical].AIlist == simpleList5.Id[index50])
                      {
                        hq = index65;
                        num42 = 99999;
                        break;
                      }
                    }
                    SimpleList landscapeTypeApCost = this.GetHQLandscapeTypeAPCost(hq, -1);
                    DC2AIClass tai5 = this;
                    AIMatrix aiMatrix9 = new AIMatrix(ref tai5);
                    aiMatrix9.SetLandscapeValues(ref landscapeTypeApCost, 10);
                    aiMatrix9.AverageValuesForAnyRegime(2);
                    int num43 = 0;
                    int num44 = 0;
                    int mapWidth12 = this.map.MapWidth;
                    for (int index66 = 0; index66 <= mapWidth12; ++index66)
                    {
                      int mapHeight = this.map.MapHeight;
                      for (int index67 = 0; index67 <= mapHeight; ++index67)
                      {
                        if (aiMatrix3.Value[index66, index67] == tfrontlist.Front[index62].FrontID)
                        {
                          num43 += aiMatrix9.Value[index66, index67];
                          ++num44;
                        }
                      }
                    }
                    float num45 = (float) num43 / (float) num44 / 10f;
                    if ((double) num45 < 1.0)
                      num45 = 1f;
                    index13 = (int) Math.Round((double) ((float) index13 * num45));
                  }
                  if (this.game.Data.Product >= 6)
                  {
                    int nr = simpleList4.FindNr(tfrontlist.Front[index62].FrontID);
                    if (nr > -1)
                    {
                      num35 = simpleList4.Weight[nr];
                      int num46 = simpleList4.Data1[nr];
                      if (num46 > 0)
                      {
                        float num47 = (float) num35 / (float) num46;
                        if ((double) num47 == 0.0)
                          index13 = (index13 + 300) * 20;
                        else if ((double) num47 < 0.1)
                          index13 = (index13 + 200) * 15;
                        else if ((double) num47 < 0.3)
                          index13 = (index13 + 100) * 10;
                        else if ((double) num47 < 0.8)
                          index13 = (index13 + 50) * 4;
                      }
                    }
                  }
                  simpleList7.Add(tfrontlist.Front[index62].FrontID, index13);
                }
              }
              if (simpleList7.Counter > -1)
              {
                simpleList7.Sort();
                if (this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] < 200000)
                {
                  if ((double) this.game.Data.RuleVar[989] > 0.0)
                  {
                    int num48 = simpleList7.Weight[0];
                    for (int counter19 = simpleList7.Counter; counter19 >= 0; counter19 += -1)
                    {
                      AIFront front = tfrontlist.FindFront(simpleList7.Id[counter19]);
                      if (this.VAR_ALLOW_OFFENSIVEGROUP_TO_OPPORTUNITY)
                      {
                        if (front.OpportunityPercentage > 0)
                          simpleList7.Weight[counter19] = (int) Math.Round((double) simpleList7.Weight[counter19] / ((double) (60 + front.OpportunityPercentage) / 60.0));
                        if (front.ThreatPercentage > 0)
                          simpleList7.Weight[counter19] = (int) Math.Round((double) simpleList7.Weight[counter19] / ((double) (80 + front.ThreatPercentage) / 80.0));
                      }
                      if (simpleList7.Weight[counter19] > num48 + (int) Math.Round((double) num48 * (double) this.game.Data.RuleVar[989] / 100.0))
                        simpleList7.Remove(simpleList7.Id[counter19]);
                      else
                        simpleList7.Weight[counter19] = (int) Math.Round((double) simpleList7.Weight[counter19] * Math.Sqrt((double) (100 + front.enemyPower)));
                    }
                    simpleList7.Sort();
                  }
                  tfrontlist.Front[tfrontlist.GetFrontNr(simpleList7.Id[0])].OffensiveZone = simpleList5.Id[index50];
                  this.AddLog("Analysed: Front " + simpleList7.Id[0].ToString() + " is best positioned to reach Offensive Zone " + simpleList5.Id[index50].ToString());
                }
                if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 & simpleList5.Id[index50] > 200000)
                {
                  tfrontlist.Front[tfrontlist.GetFrontNr(simpleList7.Id[0])].DefensiveZone = simpleList5.Id[index50];
                  if (flag2)
                    this.AddLog("Analysed: Front " + simpleList7.Id[0].ToString() + " is best positioned to reach BROAD Defensive Zone " + simpleList5.Id[index50].ToString());
                  else
                    this.AddLog("Analysed: Front " + simpleList7.Id[0].ToString() + " is best positioned to reach CLASSIC POINT Defensive Zone " + simpleList5.Id[index50].ToString());
                }
              }
            }
          }
          int num49 = 1;
          int counter20 = tfrontlist.Counter;
          int index68;
          for (index68 = 0; index68 <= counter20; ++index68)
          {
            if (tfrontlist.Front[index68].vpScoreAveragePercent > num49)
              num49 = tfrontlist.Front[index68].vpScoreAveragePercent;
          }
          Coordinate coordinate;
          if (num26 == 1 & this.VAR_ZONES_TYPE >= 1 | num26 == 2)
          {
            bool flag3 = true;
            if (this.game.Data.Product < 6)
            {
              while (flag3)
              {
                flag3 = false;
                int counter21 = tfrontlist.Counter;
                for (index68 = 0; index68 <= counter21; ++index68)
                {
                  int num50 = index68 + 1;
                  int counter22 = tfrontlist.Counter;
                  for (int index69 = num50; index69 <= counter22; ++index69)
                  {
                    if (tfrontlist.Front[index68].FrontHexes > tfrontlist.Front[index69].FrontHexes)
                    {
                      AIFront aiFront = tfrontlist.Front[index68];
                      tfrontlist.Front[index68] = tfrontlist.Front[index69];
                      tfrontlist.Front[index69] = aiFront;
                      flag3 = true;
                      break;
                    }
                  }
                }
              }
            }
            else
            {
              while (flag3)
              {
                flag3 = false;
                int counter23 = tfrontlist.Counter;
                for (index68 = 0; index68 <= counter23; ++index68)
                {
                  int num51 = index68 + 1;
                  int counter24 = tfrontlist.Counter;
                  for (int index70 = num51; index70 <= counter24; ++index70)
                  {
                    if (tfrontlist.Front[index68].vpScoreAveragePercent < tfrontlist.Front[index70].vpScoreAveragePercent)
                    {
                      AIFront aiFront = tfrontlist.Front[index68];
                      tfrontlist.Front[index68] = tfrontlist.Front[index70];
                      tfrontlist.Front[index70] = aiFront;
                      flag3 = true;
                      break;
                    }
                  }
                }
              }
            }
            if (this.game.Data.Turn == 4)
              ;
            int counter25 = tfrontlist.Counter;
            for (int index71 = 0; index71 <= counter25; ++index71)
            {
              tempFront = tfrontlist.Front[index71];
              if (tempFront.OffensiveZone > 0)
                num26 = num26;
              if (num26 == 1 & ((this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3) & tempFront.OffensiveZone > 0 | (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3) & tempFront.DefensiveZone > 0) | num26 == 2)
              {
                bool flag4 = false;
                if (tempFront.strictHQs.counter == -1)
                  flag4 = true;
                if (!flag4 & this.game.Data.Product >= 6 & (tempFront.DefensiveZone < 1 | num26 == 1))
                {
                  int num52 = 0;
                  int counter26 = tempFront.strictHQs.counter;
                  for (int index72 = 0; index72 <= counter26; ++index72)
                  {
                    index13 = this.game.Data.UnitObj[tempFront.strictHQs.unr[index72]].Historical;
                    if (index13 > -1 && this.game.Data.HistoricalUnitObj[index13].AIlist == tempFront.DefensiveZone | this.game.Data.HistoricalUnitObj[index13].AIlist == tempFront.OffensiveZone)
                      ++num52;
                  }
                  if (num52 >= tempFront.strictHQs.counter + 1)
                    flag4 = true;
                }
                if (flag4)
                {
                  SimpleList simpleList8 = new SimpleList();
                  int counter27 = hqlist.counter;
                  for (int index73 = 0; index73 <= counter27; ++index73)
                  {
                    int index74 = hqlist.unr[index73];
                    int num53 = hqlist.AIid[index73];
                    bool flag5 = true;
                    coordinate = new Coordinate();
                    coordinate.onmap = false;
                    int mapWidth13 = this.map.MapWidth;
                    for (int index75 = 0; index75 <= mapWidth13; ++index75)
                    {
                      int mapHeight = this.map.MapHeight;
                      for (int index76 = 0; index76 <= mapHeight; ++index76)
                      {
                        if (fronts.Value[index75, index76] == tempFront.FrontID)
                        {
                          coordinate.onmap = true;
                          coordinate.x = index75;
                          coordinate.y = index76;
                          break;
                        }
                      }
                    }
                    if (coordinate.onmap & this.VAR_USE_SUPERFRONTS)
                    {
                      if (this.friendlySupplyMatrix.Value[coordinate.x, coordinate.y] >= 999)
                      {
                        flag5 = false;
                      }
                      else
                      {
                        int hq = this.game.Data.UnitObj[index74].HQ;
                        if (hq > -1)
                        {
                          if (this.VAR_SUPERFRONT_HQLEVEL >= 7)
                            hq = this.game.Data.UnitObj[hq].HQ;
                          if (hq > -1)
                          {
                            if (this.VAR_SUPERFRONT_HQLEVEL >= 8)
                              hq = this.game.Data.UnitObj[hq].HQ;
                            if (hq > -1 && this.VAR_SUPERFRONT_HQLEVEL >= 9)
                              hq = this.game.Data.UnitObj[hq].HQ;
                          }
                        }
                        if (hq > -1)
                        {
                          int num54 = this.VAR_MATRIX_SUPERFRONT.Value[this.game.Data.UnitObj[hq].RealX(ref this.game), this.game.Data.UnitObj[hq].RealY(ref this.game)];
                          if (this.VAR_MATRIX_SUPERFRONT.Value[coordinate.x, coordinate.y] != num54)
                            flag5 = false;
                        }
                      }
                    }
                    if (num26 == 1 && index74 > -1 & ((this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3) & tempFront.OffensiveZone > 0 | (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3) & tempFront.DefensiveZone > 0))
                    {
                      if (index74 > -1 & (num53 == 1 | this.VAR_ZONES_TYPE == 2) | this.VAR_ZONES_TYPE == 3 & tempFront.DefensiveZone > 0)
                      {
                        int historical = this.game.Data.UnitObj[index74].Historical;
                        if (historical > -1)
                        {
                          if (this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & tempFront.OffensiveZone > 0)
                            flag5 = this.game.Data.HistoricalUnitObj[historical].AIlist == tempFront.OffensiveZone && flag5;
                          else if (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 & tempFront.DefensiveZone > 0)
                            flag5 = this.game.Data.HistoricalUnitObj[historical].AIlist == tempFront.DefensiveZone && flag5;
                        }
                        else
                          flag5 = false;
                      }
                      else
                        flag5 = false;
                    }
                    if (num26 == 2 & this.VAR_ZONES_TYPE == 3 & this.game.Data.Product >= 6 && index74 > -1)
                    {
                      int historical = this.game.Data.UnitObj[index74].Historical;
                      if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].AIlist > 0)
                        flag5 = false;
                    }
                    if (flag5)
                    {
                      SimpleList landscapeTypeApCost = this.GetHQLandscapeTypeAPCost(index74, num53);
                      DC2AIClass tai6 = this;
                      AIMatrix aiMatrix10 = new AIMatrix(ref tai6);
                      AIMatrix aiMatrix11 = fronts.Clone();
                      aiMatrix11.SetAllValuesNotValueXTo(0, tempFront.FrontID);
                      aiMatrix11.SetValueXToValueY(tempFront.FrontID, 1);
                      int num55 = 1;
                      if (this.VAR_STRICTHQ_DIST_IMPORTANCE <= -1)
                        aiMatrix11.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 19);
                      else if (this.VAR_STRICTHQ_DIST_IMPORTANCE == 0)
                        aiMatrix11.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 39);
                      else if (this.VAR_STRICTHQ_DIST_IMPORTANCE == 1)
                      {
                        aiMatrix11.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 69);
                        num55 = 4;
                      }
                      else
                      {
                        aiMatrix11.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 199);
                        num55 = 16;
                      }
                      aiMatrix11.SetValueXToValueY(0, 9999);
                      aiMatrix11.SetAllValuesToWithMask(9999, ref ownerMatrix, 2);
                      aiMatrix11.SetAllValuesToWithMask(9999, ref ownerMatrix, 0);
                      bool flag6 = false;
                      int historical = this.game.Data.UnitObj[index74].Historical;
                      if (historical > -1 && this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & this.game.Data.HistoricalUnitObj[historical].AIlist < 200000 && this.game.Data.HistoricalUnitObj[historical].AIlist > 0)
                        flag6 = true;
                      int num56 = 0;
                      int num57 = 0;
                      int num58 = 0;
                      int num59 = 0;
                      int num60 = 0;
                      int num61 = 0;
                      SimpleList simpleList9 = new SimpleList();
                      int unitCounter8 = this.game.Data.UnitCounter;
                      for (int unr = 0; unr <= unitCounter8; ++unr)
                      {
                        if (this.game.Data.UnitObj[unr].X > -1 & (unr == index74 | this.game.Data.UnitObj[unr].HQ == index74) & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].PreDef == -1)
                        {
                          if (this.game.Data.UnitObj[unr].AISubStrictGroup == num53)
                          {
                            simpleList9.AddWeight(fronts.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y], this.game.Data.UnitObj[unr].TempUnitPowerAbs);
                            if (fronts.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] == tempFront.FrontID)
                            {
                              num56 = num56 + 7 + 0;
                              ++num57;
                              num60 += this.game.HandyFunctionsObj.GetAverageEntrench(unr);
                              ++num61;
                              if (this.frontlinesMatrix.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] == 1)
                                num60 += this.game.HandyFunctionsObj.GetAverageEntrench(unr);
                            }
                            else if (this.friendlySupplyMatrix.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] <= this.VAR_SUPPLY_25PERCENT_RANGE)
                            {
                              num56 = num56 + 7 + 8 + Math.Min(2999, aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 2);
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 5)
                                num56 += (int) Math.Round((double) aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 1.5);
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 10)
                                num56 += aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 2;
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 20)
                                num56 += (int) Math.Round((double) aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 2.5);
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 30)
                                num56 += aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 3;
                              ++num57;
                            }
                          }
                          else if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(index74))
                            index13 = index13;
                          else if (fronts.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] == tempFront.FrontID)
                          {
                            num58 = num58 + 2 + 0;
                            ++num59;
                          }
                          else if (this.friendlySupplyMatrix.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] <= this.VAR_SUPPLY_25PERCENT_RANGE)
                          {
                            if (num53 == 1 | !flag6)
                            {
                              num58 = num58 + 2 + 5 + Math.Min(2999, 1 * aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y]);
                              ++num59;
                            }
                            else
                            {
                              num58 = num58 + 3 + 3 + Math.Min(2999, aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 1);
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 5)
                                num58 += aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 3;
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 10)
                                num58 += aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 4;
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 20)
                                num58 += aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 5;
                              if (aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 30)
                                num58 += aiMatrix11.Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * 9;
                              ++num59;
                            }
                          }
                        }
                      }
                      bool flag7 = false;
                      if (num56 >= 9999)
                      {
                        num56 = 9999;
                        flag7 = true;
                      }
                      if (num58 > 9999)
                        num58 = 9999;
                      int num62 = (int) Math.Round((double) num56 / (double) num55);
                      int num63 = (int) Math.Round((double) num58 / (double) num55);
                      if (this.game.Data.Product == 6)
                      {
                        num62 *= 2;
                        num63 *= 2;
                      }
                      int num64;
                      if (num57 == 0)
                      {
                        num64 = 9999;
                      }
                      else
                      {
                        if (num59 == 0)
                          num59 = 1;
                        num64 = (int) Math.Round(((double) num62 / (double) num57 * 1.0 + (double) num63 / (double) num59) / 2.0);
                      }
                      if (flag7)
                        num64 = 9999;
                      int num65 = num64 + 1;
                      int num66 = 20;
                      int num67 = 0;
                      int num68 = 0;
                      int unitCounter9 = this.game.Data.UnitCounter;
                      for (int index77 = 0; index77 <= unitCounter9; ++index77)
                      {
                        if (this.game.Data.UnitObj[index77].X > -1 & (index77 == index74 | this.game.Data.UnitObj[index77].HQ == index74) & this.game.Data.UnitObj[index77].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[index77].IsHQ & this.game.Data.UnitObj[index77].PreDef == -1 && this.game.Data.UnitObj[index77].AISubStrictGroup == num53 && !Information.IsNothing((object) this.game.Data.UnitObj[index77].prevTurnAiFrontHexes))
                        {
                          int counter28 = this.game.Data.UnitObj[index77].prevTurnAiFrontHexes.counter;
                          for (int index78 = 0; index78 <= counter28; ++index78)
                          {
                            int x = this.game.Data.UnitObj[index77].prevTurnAiFrontHexes.coord[index78].x;
                            int y = this.game.Data.UnitObj[index77].prevTurnAiFrontHexes.coord[index78].y;
                            if (aiMatrix3.Value[x, y] == tempFront.FrontID)
                            {
                              ++num67;
                              ++num68;
                            }
                            else
                              ++num68;
                          }
                        }
                      }
                      if (num68 > 0)
                      {
                        num66 -= (int) Math.Round((double) (num66 * num67) / (double) num68);
                        if (num66 < 1)
                          num66 = 1;
                      }
                      int curEnm = tempFront.enemyPower;
                      if (tempFront.hasSupplySource)
                        curEnm *= 4;
                      else if (this.game.Data.Product >= 6)
                      {
                        if (tempFront.vpScoreAveragePercent >= num49 - 3)
                          curEnm = (int) Math.Round((double) curEnm * 3.5);
                        else if ((double) ((float) tempFront.vpScoreAveragePercent / (float) num49) > 0.9)
                          curEnm = (int) Math.Round((double) curEnm * 2.75);
                        else if ((double) ((float) tempFront.vpScoreAveragePercent / (float) num49) > 0.8)
                          curEnm *= 2;
                        else if ((double) ((float) tempFront.vpScoreAveragePercent / (float) num49) > 0.5)
                          curEnm = (int) Math.Round((double) curEnm * 1.5);
                      }
                      int curFr = 0 + hqlist.data2[index73];
                      int num69 = hqlist.data[index73];
                      int num70 = 0;
                      int num71 = 0;
                      int num72;
                      if (tempFront.FrontHexes > 0)
                      {
                        int counter29 = tfrontlist.Counter;
                        for (int index79 = 0; index79 <= counter29; ++index79)
                        {
                          AIFront aiFront = tfrontlist.Front[index79];
                          if (aiFront.strictHQs.CheckIfPresentUnr(index74, num53))
                          {
                            ++num70;
                            num71 += aiFront.FrontHexes;
                            curFr += hqlist.CheckData2(index74, num53);
                          }
                        }
                        num72 = (num70 + 1) * 10;
                        if (num69 > num71 + tempFront.FrontHexes)
                          num72 = (int) Math.Round((double) num72 * ((double) num69 / (double) (num71 + tempFront.FrontHexes)));
                        else if (num69 < num71 + tempFront.FrontHexes)
                          num72 = (int) Math.Round((double) num72 * ((double) (num71 + tempFront.FrontHexes) / (double) num69));
                      }
                      int num73;
                      if (this.game.Data.Product >= 7)
                      {
                        int num74 = num70 + 1;
                        num73 = num72 + (int) Math.Round(20.0 * ((double) (num74 * 3) + 0.5));
                      }
                      else
                        num73 = this.game.Data.Product != 6 ? num72 + 20 * (num70 * 6) : num72 + 20 * (num70 * 6) * (num69 + 2) * (num70 + 1);
                      if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(index74))
                        curFr = (int) Math.Round((double) curFr / 4.0);
                      int num75 = num73;
                      if (tempFront.DefensiveZone > 0 & num26 == 1)
                        num75 = 1;
                      if (num61 > 0)
                      {
                        int num76 = (int) Math.Round((double) num60 / (double) num61);
                        num75 = (int) Math.Round(0.5 * (double) num75) + (int) Math.Round(0.5 * ((double) num75 / ((double) Math.Max(40, num76 - 20) / 40.0)));
                      }
                      float num77 = (float) Math.Min(1.0, Math.Max(0.2, Math.Sqrt((double) curFr / (double) (curEnm + 1))));
                      if (tempFront.FrontID == 4 & this.game.Data.Turn == 4)
                        index13 = index13;
                      if (this.CustomCalls.HasCustumCalls())
                      {
                        float num78 = this.CustomCalls.CustomRuleHQtoFrontAssign_ModifyScore1(ref fronts, ref tempFront, index74, num53, curEnm, curFr);
                        num65 = (int) Math.Round((double) ((float) num65 * num78));
                      }
                      int num79 = ((this.game.Data.Product >= 6 ? (int) Math.Round((double) num65 * (double) num77 * 0.66) + (int) Math.Round((double) num65 * 0.33) : (int) Math.Round((double) num65 * (double) num77 * 0.5) + (int) Math.Round((double) num65 * 0.5)) + 2) * 2;
                      if (num26 == 1 & this.game.Data.Product >= 6)
                        num75 = 1;
                      if (tempFront.ThreatPercentage > 0 | tempFront.OpportunityPercentage > 0)
                      {
                        int num80 = Math.Max(tempFront.OpportunityPercentage, tempFront.ThreatPercentage);
                        int num81 = (double) num77 <= 4.0 ? ((double) num77 <= 2.5 ? ((double) num77 <= 1.5 ? ((double) num77 >= 0.66 ? ((double) num77 >= 0.33 ? num80 * 1 : num80 * 2) : (int) Math.Round((double) num80 * 1.5)) : (int) Math.Round((double) num80 / 1.5)) : (int) Math.Round((double) num80 / 2.0)) : (int) Math.Round((double) num80 / 3.0);
                        if (num81 > 100)
                          num81 = num81;
                        if (num81 > 0)
                          num79 = (int) Math.Round((double) num79 / ((double) (num81 + 100) / 100.0));
                      }
                      float num82 = 1f;
                      if (flag5 & (double) (num79 * num75) / 2.0 < 1.0)
                      {
                        DC2AIClass tai7 = this;
                        AIMatrix aiMatrix12 = new AIMatrix(ref tai7);
                        aiMatrix12.SetLandscapeValues(ref landscapeTypeApCost, 10);
                        if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 100)
                          aiMatrix12.AverageValuesForAnyRegime(2);
                        int num83 = 0;
                        int num84 = 0;
                        int mapWidth14 = this.map.MapWidth;
                        for (int index80 = 0; index80 <= mapWidth14; ++index80)
                        {
                          int mapHeight = this.map.MapHeight;
                          for (int index81 = 0; index81 <= mapHeight; ++index81)
                          {
                            if (aiMatrix3.Value[index80, index81] == tempFront.FrontID)
                            {
                              num83 += aiMatrix12.Value[index80, index81];
                              ++num84;
                            }
                          }
                        }
                        float x = (float) num83 / (float) num84 / 10f;
                        if ((double) x < 1.0)
                          x = 1f;
                        num82 = (float) Math.Pow((double) x, 1.5);
                      }
                      if (num26 == 1 & this.game.Data.Product >= 6)
                        num82 = 1f;
                      if (this.game.Data.Product == 1 & !flag6)
                      {
                        simpleList9.ReverseSort();
                        if (simpleList9.Id[0] > 0)
                        {
                          AIFront front = tfrontlist.FindFront(simpleList9.Id[0]);
                          if (front.FrontID != tempFront.FrontID)
                          {
                            if ((double) front.OrigAverageStrength < (double) this.game.Data.RuleVar[746])
                              flag5 = false;
                            if ((double) tempFront.OrigAverageStrength > (double) this.game.Data.RuleVar[745])
                              flag5 = false;
                            if ((double) this.game.Data.RuleVar[747] > 0.0)
                              num79 = (int) Math.Round((double) ((float) num79 * this.game.Data.RuleVar[747]));
                          }
                        }
                      }
                      if (flag5)
                      {
                        int tweight = (int) Math.Round((double) (num66 * num79 * num75) * (double) num82 / 2.0);
                        if (tweight >= 0 & tweight < 4999)
                        {
                          if (num53 == -1)
                            simpleList8.Add(index74, tweight, -1);
                          else if (this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(-1))
                            simpleList8.Add(index74, tweight, num53, CheckData1Existence: (this.game.Data.Product >= 7));
                          else
                            simpleList8.Add(index74, tweight, num53);
                        }
                      }
                    }
                  }
                  simpleList8.Sort();
                  if (simpleList8.Counter > -1)
                  {
                    int tunr = simpleList8.Id[0];
                    int tAIid = simpleList8.Data1[0];
                    if (tunr > -1)
                    {
                      tempFront.strictHQs.add(tunr, tAIid);
                      this.AddLog("...Assigned to Front-Without-HQ (strictHQ)" + this.game.Data.UnitObj[tunr].Name + " SSHQ-" + tAIid.ToString() + " to front " + tempFront.FrontID.ToString());
                    }
                  }
                }
              }
            }
          }
          int counter30 = hqlist.counter;
          for (int index82 = 0; index82 <= counter30; ++index82)
          {
            int index83 = hqlist.unr[index82];
            int num85 = hqlist.AIid[index82];
            SimpleList landscapeTypeApCost = this.GetHQLandscapeTypeAPCost(index83, num85);
            if (Strings.InStr(this.game.Data.UnitObj[index83].Name, "16th") > 0)
              index83 = index83;
            bool flag8 = false;
            int historical1 = this.game.Data.UnitObj[index83].Historical;
            if (historical1 > -1 && this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & this.game.Data.HistoricalUnitObj[historical1].AIlist < 200000 && this.game.Data.HistoricalUnitObj[historical1].AIlist > 0)
              flag8 = true;
            bool flag9 = false;
            int counter31 = tfrontlist.Counter;
            for (int index84 = 0; index84 <= counter31; ++index84)
            {
              if (tfrontlist.Front[index84].strictHQs.CheckIfPresentUnr(index83, num85))
                flag9 = true;
            }
            if (!flag9 & num26 == 2 & this.VAR_ZONES_TYPE == 3 && index83 > -1 & num85 == 1)
            {
              int historical2 = this.game.Data.UnitObj[index83].Historical;
              if (historical2 > -1 && this.game.Data.HistoricalUnitObj[historical2].AIlist > 0)
                this.game.Data.HistoricalUnitObj[historical2].AIlist = -1;
            }
            if (num26 == 1)
            {
              if (this.game.Data.UnitObj[index83].Historical > -1)
              {
                if (this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index83].Historical].AIlist < 200000)
                {
                  if (this.game.Data.UnitObj[index83].Historical > -1)
                  {
                    if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index83].Historical].AIlist <= 0)
                      flag9 = true;
                  }
                  else
                    flag9 = true;
                }
                else if (!(this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index83].Historical].AIlist > 200000))
                  flag9 = true;
              }
              else
                flag9 = true;
            }
            if (!flag9)
            {
              SimpleList simpleList10 = new SimpleList();
              int counter32 = tfrontlist.Counter;
              for (int unr1 = 0; unr1 <= counter32; ++unr1)
              {
                tempFront = tfrontlist.Front[unr1];
                bool flag10 = true;
                coordinate = new Coordinate();
                coordinate.onmap = false;
                int mapWidth15 = this.map.MapWidth;
                for (int index85 = 0; index85 <= mapWidth15; ++index85)
                {
                  int mapHeight = this.map.MapHeight;
                  for (int index86 = 0; index86 <= mapHeight; ++index86)
                  {
                    if (fronts.Value[index85, index86] == tempFront.FrontID && this.friendlySupplyMatrix.Value[index85, index86] < 999)
                    {
                      coordinate.onmap = true;
                      coordinate.x = index85;
                      coordinate.y = index86;
                      break;
                    }
                  }
                }
                if (coordinate.onmap & this.VAR_USE_SUPERFRONTS)
                {
                  if (this.friendlySupplyMatrix.Value[coordinate.x, coordinate.y] >= 999)
                  {
                    flag10 = false;
                  }
                  else
                  {
                    int hq = this.game.Data.UnitObj[index83].HQ;
                    if (hq > -1)
                    {
                      if (this.VAR_SUPERFRONT_HQLEVEL >= 7)
                        hq = this.game.Data.UnitObj[hq].HQ;
                      if (hq > -1)
                      {
                        if (this.VAR_SUPERFRONT_HQLEVEL >= 8)
                          hq = this.game.Data.UnitObj[hq].HQ;
                        if (hq > -1 && this.VAR_SUPERFRONT_HQLEVEL >= 9)
                          hq = this.game.Data.UnitObj[hq].HQ;
                      }
                    }
                    if (hq > -1)
                    {
                      int num86 = this.VAR_MATRIX_SUPERFRONT.Value[this.game.Data.UnitObj[hq].RealX(ref this.game), this.game.Data.UnitObj[hq].RealY(ref this.game)];
                      if (this.VAR_MATRIX_SUPERFRONT.Value[coordinate.x, coordinate.y] != num86)
                        flag10 = false;
                    }
                  }
                }
                bool flag11 = false;
                if (num26 == 1 & ((this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3) & tempFront.OffensiveZone > 0 | (this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3) & tempFront.DefensiveZone > 0))
                {
                  if (index83 > -1 & (num85 == 1 | this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3 & tempFront.DefensiveZone > 0))
                  {
                    int historical3 = this.game.Data.UnitObj[index83].Historical;
                    if (historical3 > -1)
                    {
                      if ((this.VAR_ZONES_TYPE == 1 | this.VAR_ZONES_TYPE == 3) & tempFront.OffensiveZone > 0)
                        flag10 = this.game.Data.HistoricalUnitObj[historical3].AIlist == tempFront.OffensiveZone && flag10;
                      else if ((this.VAR_ZONES_TYPE == 2 | this.VAR_ZONES_TYPE == 3) & tempFront.DefensiveZone > 0)
                        flag10 = this.game.Data.HistoricalUnitObj[historical3].AIlist == tempFront.DefensiveZone && flag10;
                    }
                    else
                      flag10 = false;
                  }
                  else
                    flag10 = false;
                }
                else
                {
                  if (num26 == 1)
                    flag10 = false;
                  bool flag12 = false;
                  if (num26 == 2 & this.VAR_ZONES_TYPE == 2 & tempFront.DefensiveZone > 0 | num26 == 2 & this.VAR_ZONES_TYPE == 3 & tempFront.DefensiveZone > 200000)
                    flag12 = true;
                  if (num26 == 2 & this.VAR_ZONES_TYPE == 2 & tempFront.FrontID > 1000000 | num26 == 2 & this.VAR_ZONES_TYPE == 3 & tempFront.FrontID > 1000000)
                    flag12 = true;
                  if (flag12 & flag10)
                  {
                    int num87 = 9;
                    if (this.game.Data.Product >= 7)
                      num87 = num23;
                    int num88 = num87;
                    for (int taid = 1; taid <= num88; ++taid)
                    {
                      if (tempFront.strictHQs.CheckIfPresentUnr(index83, taid))
                        flag11 = true;
                    }
                    if (!flag11)
                      flag10 = false;
                  }
                }
                if ((this.VAR_ZONES_TYPE == 2 & tempFront.DefensiveZone > 0 | this.VAR_ZONES_TYPE == 3 & tempFront.DefensiveZone > 0) & this.CustomCalls.HasCustumCalls())
                {
                  int num89 = this.CustomCalls.CustomRuleHQtoFrontAssign_howmanySSHQperDefensiveZone(tempFront.DefensiveZone);
                  if (num89 > 0 && tempFront.strictHQs.counter >= num89 - 1)
                    flag10 = false;
                }
                if (this.game.Data.Product >= 7 && this.VAR_ZONES_TYPE == 2 & tempFront.DefensiveZone < 1 | this.VAR_ZONES_TYPE == 3 & tempFront.DefensiveZone < 1 & tempFront.OffensiveZone < 1 && tempFront.FrontID > 999999)
                  flag10 = false;
                if (flag10)
                {
                  DC2AIClass tai8 = this;
                  AIMatrix aiMatrix13 = new AIMatrix(ref tai8);
                  AIMatrix aiMatrix14 = fronts.Clone();
                  aiMatrix14.SetAllValuesNotValueXTo(0, tempFront.FrontID);
                  aiMatrix14.SetValueXToValueY(tempFront.FrontID, 1);
                  int num90 = 1;
                  int num91 = 0;
                  if (num26 == 1 & this.game.Data.Product >= 6)
                    num91 += 50;
                  if (this.VAR_STRICTHQ_DIST_IMPORTANCE <= -1)
                    aiMatrix14.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 19 + num91);
                  else if (this.VAR_STRICTHQ_DIST_IMPORTANCE == 0)
                    aiMatrix14.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 39 + num91);
                  else if (this.VAR_STRICTHQ_DIST_IMPORTANCE == 1)
                  {
                    aiMatrix14.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 69 + num91);
                    num90 = 4;
                  }
                  else
                  {
                    aiMatrix14.ExpandAndAddValueForLandscapeTypeAndSameRegime(ref landscapeTypeApCost, 199 + num91);
                    num90 = 16;
                  }
                  aiMatrix14.SetValueXToValueY(0, 9999);
                  aiMatrix14.SetAllValuesToWithMask(9999, ref ownerMatrix, 2);
                  aiMatrix14.SetAllValuesToWithMask(9999, ref ownerMatrix, 0);
                  int num92 = 0;
                  int num93 = 0;
                  int num94 = 0;
                  int num95 = 0;
                  int num96 = 0;
                  int num97 = 0;
                  SimpleList simpleList11 = new SimpleList();
                  int unitCounter10 = this.game.Data.UnitCounter;
                  for (int unr2 = 0; unr2 <= unitCounter10; ++unr2)
                  {
                    if (this.game.Data.UnitObj[unr2].X > -1 & (unr2 == index83 | this.game.Data.UnitObj[unr2].HQ == index83) & this.game.Data.UnitObj[unr2].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[unr2].IsHQ & this.game.Data.UnitObj[unr2].PreDef == -1)
                    {
                      if (this.game.Data.UnitObj[unr2].AISubStrictGroup == num85)
                      {
                        simpleList11.AddWeight(fronts.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y], this.game.Data.UnitObj[unr2].TempUnitPowerAbs);
                        if (fronts.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] == tempFront.FrontID)
                        {
                          num92 = num92 + 5 + 0;
                          ++num93;
                          num97 += this.game.HandyFunctionsObj.GetAverageEntrench(unr2);
                          ++num96;
                          if (this.frontlinesMatrix.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] == 1)
                            num97 += this.game.HandyFunctionsObj.GetAverageEntrench(unr1);
                        }
                        else if (this.friendlySupplyMatrix.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] <= this.VAR_SUPPLY_25PERCENT_RANGE)
                        {
                          num92 = num92 + 5 + 5 + Math.Min(699, aiMatrix14.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] * 1);
                          ++num93;
                        }
                      }
                      else if (!(this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(index83)))
                      {
                        if (fronts.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] == tempFront.FrontID)
                        {
                          num94 = num94 + 5 + 0;
                          ++num95;
                        }
                        else if (this.friendlySupplyMatrix.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] <= this.VAR_SUPPLY_25PERCENT_RANGE)
                        {
                          if (num85 == 1 | !flag8)
                          {
                            num94 = num94 + 5 + 6 + Math.Min(699, aiMatrix14.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] * 1);
                            ++num95;
                          }
                          else
                          {
                            num94 = num94 + 5 + 3 + Math.Min(699, aiMatrix14.Value[this.game.Data.UnitObj[unr2].X, this.game.Data.UnitObj[unr2].Y] * 3);
                            ++num95;
                          }
                        }
                      }
                    }
                  }
                  if (num93 == 0)
                    num93 = 1;
                  if (num95 == 0)
                    num95 = 1;
                  int num98 = (int) Math.Round((double) num92 / (double) num90);
                  int num99 = (int) Math.Round((double) num94 / (double) num90);
                  int num100 = (int) Math.Round((double) num98 / (double) num93 * 1.0 + (double) num99 / (double) num95) + 1;
                  int num101 = (int) Math.Round((double) (int) Math.Round((double) num100 * Math.Max(1.0, (double) num100 * 0.1)) / 4.0);
                  int num102 = 20;
                  int num103 = 0;
                  int num104 = 0;
                  int unitCounter11 = this.game.Data.UnitCounter;
                  for (int index87 = 0; index87 <= unitCounter11; ++index87)
                  {
                    if (this.game.Data.UnitObj[index87].X > -1 & (index87 == index83 | this.game.Data.UnitObj[index87].HQ == index83) & this.game.Data.UnitObj[index87].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[index87].IsHQ & this.game.Data.UnitObj[index87].PreDef == -1 && this.game.Data.UnitObj[index87].AISubStrictGroup == num85 && !Information.IsNothing((object) this.game.Data.UnitObj[index87].prevTurnAiFrontHexes))
                    {
                      int counter33 = this.game.Data.UnitObj[index87].prevTurnAiFrontHexes.counter;
                      for (int index88 = 0; index88 <= counter33; ++index88)
                      {
                        int x = this.game.Data.UnitObj[index87].prevTurnAiFrontHexes.coord[index88].x;
                        int y = this.game.Data.UnitObj[index87].prevTurnAiFrontHexes.coord[index88].y;
                        if (aiMatrix3.Value[x, y] == tempFront.FrontID)
                        {
                          ++num103;
                          ++num104;
                        }
                        else
                          ++num104;
                      }
                    }
                  }
                  if (num104 > 0)
                  {
                    num102 -= (int) Math.Round((double) (num102 * num103) / (double) num104);
                    if (num102 < 1)
                      num102 = 1;
                  }
                  int curEnm = tempFront.enemyPower;
                  if (tempFront.hasSupplySource)
                    curEnm *= 4;
                  else if (this.game.Data.Product >= 6)
                  {
                    if (tempFront.vpScoreAveragePercent >= num49 - 3)
                      curEnm = (int) Math.Round((double) curEnm * 3.5);
                    else if ((double) ((float) tempFront.vpScoreAveragePercent / (float) num49) > 0.9)
                      curEnm = (int) Math.Round((double) curEnm * 2.75);
                    else if ((double) ((float) tempFront.vpScoreAveragePercent / (float) num49) > 0.8)
                      curEnm *= 2;
                    else if ((double) ((float) tempFront.vpScoreAveragePercent / (float) num49) > 0.5)
                      curEnm = (int) Math.Round((double) curEnm * 1.5);
                  }
                  int num105 = 0;
                  int curFr = !(this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(index83)) ? num105 + hqlist.data2[index82] : num105 + (int) Math.Round((double) hqlist.data2[index82] / 4.0);
                  int num106 = hqlist.data[index82];
                  int num107 = 0;
                  int num108;
                  if (tempFront.FrontHexes > 0)
                  {
                    int counter34 = tempFront.strictHQs.counter;
                    for (int index89 = 0; index89 <= counter34; ++index89)
                    {
                      bool flag13 = true;
                      if (this.game.Data.Product >= 6)
                      {
                        int historical4 = this.game.Data.UnitObj[tempFront.strictHQs.unr[index89]].Historical;
                        if (historical4 > -1 && this.game.Data.HistoricalUnitObj[historical4].AIlist > 0)
                          flag13 = false;
                      }
                      if (flag13)
                      {
                        int num109 = tempFront.strictHQs.unr[index89];
                        int taid = tempFront.strictHQs.AIid[index89];
                        int num110 = 0;
                        int num111 = 0;
                        if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(num109))
                          curFr += (int) Math.Round((double) hqlist.CheckData2(num109, taid) / 4.0);
                        else
                          curFr += hqlist.CheckData2(num109, taid);
                        if (this.game.Data.Product < 6)
                        {
                          if (!(index83 == num109 & num85 == taid))
                            ++num107;
                        }
                        else if (index83 != num109)
                          ++num107;
                        int counter35 = tfrontlist.Counter;
                        for (int index90 = 0; index90 <= counter35; ++index90)
                        {
                          if (tfrontlist.Front[index90].strictHQs.CheckIfPresentUnr(num109, taid))
                            ++num110;
                        }
                        int counter36 = hqlist.counter;
                        for (int index91 = 0; index91 <= counter36; ++index91)
                        {
                          if (hqlist.unr[index91] == num109 & hqlist.AIid[index91] == taid)
                            num111 = hqlist.data[index91];
                        }
                        if (num110 > 0)
                          num106 += num111;
                      }
                    }
                    num108 = (num107 + 1) * 10;
                    if ((double) num106 > (double) tempFront.FrontHexes * 1.25)
                      num108 = (int) Math.Round((double) ((float) num108 * ((float) num106 / ((float) tempFront.FrontHexes * 1.25f))));
                    else if (num106 < tempFront.FrontHexes)
                      num108 = (int) Math.Round((double) num108 * 0.5 + (double) num108 * 0.5 * ((double) tempFront.FrontHexes / (double) num106));
                  }
                  int score2 = this.game.Data.Product < 6 ? num108 + 20 * (num107 + 1) : num108 + 20 * num107;
                  if (this.game.Data.Product >= 6 && !this.CustomCalls.CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(index83))
                  {
                    index13 = 0;
                    int num112 = 0;
                    int counter37 = tfrontlist.Counter;
                    for (int index92 = 0; index92 <= counter37; ++index92)
                    {
                      int taid = 1;
                      do
                      {
                        if (taid != num85 && tfrontlist.Front[index92].strictHQs.CheckIfPresentUnr(index83, taid))
                        {
                          ++index13;
                          SimpleList neighbourFrontList = tfrontlist.Front[index92].GetNeighbourFrontList();
                          int counter38 = neighbourFrontList.Counter;
                          for (int index93 = 0; index93 <= counter38; ++index93)
                          {
                            if (neighbourFrontList.Id[index93] == tempFront.FrontID)
                              ++num112;
                          }
                          if (tfrontlist.Front[index92].FrontID == tempFront.FrontID)
                            num112 += 2;
                        }
                        ++taid;
                      }
                      while (taid <= 9);
                    }
                    if (index13 > 0)
                    {
                      int num113 = (int) Math.Round((double) (100 * num112) / (double) index13);
                      if (num113 < 10)
                        score2 *= 2;
                      else if (num113 < 50)
                        score2 *= 1;
                      else if (num113 <= 100)
                        score2 = (int) Math.Round((double) score2 * 0.5);
                      else if (num113 <= 150)
                        score2 = (int) Math.Round((double) score2 * 0.33);
                      else if (num113 <= 200)
                        score2 = (int) Math.Round((double) score2 * 0.15);
                    }
                  }
                  if (num96 > 0)
                  {
                    int num114 = (int) Math.Round((double) num97 / (double) num96);
                    score2 = (int) Math.Round(0.5 * (double) score2) + (int) Math.Round(0.5 * ((double) score2 / ((double) Math.Max(40, num114 - 20) / 40.0)));
                  }
                  float num115 = (float) Math.Min(2.0, Math.Max(0.2, Math.Sqrt((double) curFr / (double) (curEnm + 1))));
                  int num116 = num106 - hqlist.data[index82];
                  if (num106 < tempFront.FrontHexes & tempFront.FrontHexes > 0)
                    num101 = (int) Math.Round((double) num101 * ((double) num106 / (double) tempFront.FrontHexes) * 0.7) + (int) Math.Round((double) num101 * 0.3);
                  if (tempFront.bridgeCount > 0 && tempFront.retreatAverageScore < 150)
                    num101 = (int) Math.Round((double) num101 * (1.0 / Math.Sqrt((double) (tempFront.bridgeCount + 1))) * 0.25) + (int) Math.Round((double) num101 * 0.75);
                  if (tempFront.vpScoreAveragePercent > 0)
                  {
                    int num117 = tempFront.vpScoreAveragePercent;
                    if (num117 > 50)
                      num117 = 50 + (int) Math.Round(Math.Sqrt((double) (2 * (num117 - 50))));
                    if (tempFront.retreatAverageScore > 100)
                      num117 = (int) Math.Round((double) num117 * (100.0 / (double) tempFront.retreatAverageScore));
                    num101 = (int) Math.Round((double) num101 * ((double) (60 - num117) / 60.0) * 0.4) + (int) Math.Round((double) num101 * 0.6);
                  }
                  if (tempFront.FrontID == 353)
                    index82 = index82;
                  if (tempFront.FrontID == 362)
                    index82 = index82;
                  int num118 = this.game.Data.Product >= 6 ? (int) Math.Round((double) num101 * (double) num115 * 0.8) + (int) Math.Round((double) num101 * 0.2) : (int) Math.Round((double) num101 * (double) num115 * 0.7) + (int) Math.Round((double) num101 * 0.3);
                  if (this.CustomCalls.HasCustumCalls())
                  {
                    if (num118 < 1)
                      num118 = 1;
                    float num119 = this.CustomCalls.CustomRuleHQtoFrontAssign_ModifyScore1(ref fronts, ref tempFront, index83, num85, curEnm, curFr);
                    num118 = (int) Math.Round((double) ((float) num118 * num119));
                  }
                  int score1 = (num118 + 2) * 2;
                  if (num26 == 1 & this.game.Data.Product >= 6)
                    score2 = 1;
                  if (tempFront.ThreatPercentage > 0 | tempFront.OpportunityPercentage > 0)
                  {
                    int num120 = Math.Max(tempFront.OpportunityPercentage, tempFront.ThreatPercentage);
                    int num121 = (double) num115 <= 4.0 ? ((double) num115 <= 2.5 ? ((double) num115 <= 1.5 ? ((double) num115 >= 0.66 ? ((double) num115 >= 0.33 ? num120 * 1 : num120 * 2) : (int) Math.Round((double) num120 * 1.5)) : (int) Math.Round((double) num120 / 1.5)) : (int) Math.Round((double) num120 / 2.0)) : (int) Math.Round((double) num120 / 3.0);
                    if (num121 > 100)
                      num121 = num121;
                    if (num121 > 0)
                      score1 = (int) Math.Round((double) score1 / ((double) (num121 + 100) / 100.0));
                  }
                  float score3 = 1f;
                  if (flag10 & (double) (score1 * score2) / 4.0 < 2999.0)
                  {
                    DC2AIClass tai9 = this;
                    AIMatrix aiMatrix15 = new AIMatrix(ref tai9);
                    aiMatrix15.SetLandscapeValues(ref landscapeTypeApCost, 10);
                    if (this.game.Data.RegimeObj[this.game.Data.Turn].ProdBonus >= 100)
                      aiMatrix15.AverageValuesForAnyRegime(2);
                    int num122 = 0;
                    int num123 = 0;
                    int mapWidth16 = this.map.MapWidth;
                    for (int index94 = 0; index94 <= mapWidth16; ++index94)
                    {
                      int mapHeight = this.map.MapHeight;
                      for (int index95 = 0; index95 <= mapHeight; ++index95)
                      {
                        if (aiMatrix3.Value[index94, index95] == tempFront.FrontID)
                        {
                          num122 += aiMatrix15.Value[index94, index95];
                          ++num123;
                        }
                      }
                    }
                    float x = (float) num122 / (float) num123 / 10f;
                    if ((double) x < 1.0)
                      x = 1f;
                    score3 = (float) Math.Pow((double) x, 1.5);
                  }
                  if (num26 == 1 & this.game.Data.Product >= 6)
                    score3 = 1f;
                  if (this.game.Data.Product == 1 & !flag8)
                  {
                    simpleList11.ReverseSort();
                    if (simpleList11.Id[0] > 0)
                    {
                      AIFront front = tfrontlist.FindFront(simpleList11.Id[0]);
                      if (front.FrontID != tempFront.FrontID)
                      {
                        if ((double) front.OrigAverageStrength < (double) this.game.Data.RuleVar[746])
                          flag10 = false;
                        if ((double) tempFront.OrigAverageStrength > (double) this.game.Data.RuleVar[745])
                          flag10 = false;
                        if ((double) this.game.Data.RuleVar[747] > 0.0)
                          score1 = (int) Math.Round((double) ((float) score1 * this.game.Data.RuleVar[747]));
                      }
                    }
                  }
                  if (flag10)
                  {
                    int num124 = (int) Math.Round((double) (num102 * score1 * score2) * (double) score3 / 4.0);
                    if (this.CustomCalls.HasCustumCalls())
                      num124 = this.CustomCalls.CustomRuleHQToFrontAssign_SetScore(num124, (float) score1, (float) score2, score3);
                    if (flag11)
                      num124 = (int) Math.Round(Math.Sqrt((double) num124));
                    if (num124 >= 0 & num124 < 2999)
                      simpleList10.Add(tempFront.FrontID, num124);
                  }
                }
              }
              simpleList10.Sort();
              if (simpleList10.Counter > -1)
              {
                tempFront = this.frontList.Front[this.frontList.GetFrontNr(simpleList10.Id[0])];
                if (tempFront.FrontID == 353)
                  index82 = index82;
                if (!Information.IsNothing((object) tempFront))
                {
                  tempFront.strictHQs.add(index83, num85);
                  this.AddLog("Assigned (strictHQ)" + this.game.Data.UnitObj[index83].Name + " SSHQ-" + num85.ToString() + " to front " + tempFront.FrontID.ToString());
                }
              }
            }
          }
          ++num26;
        }
        while (num26 <= 2);
      }
      int unitCounter12 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter12; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].AIGroup == -1 & this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == this.GetGameDataTurn())
        {
          int x = this.game.Data.UnitObj[unr].X;
          int y = this.game.Data.UnitObj[unr].Y;
          int hq = this.game.Data.UnitObj[unr].HQ;
          int aiSubStrictGroup = this.game.Data.UnitObj[unr].AISubStrictGroup;
          if (x > -1 & y > -1)
          {
            bool flag = false;
            if (this.game.Data.UnitObj[unr].TempCategory == 1 | this.game.Data.UnitObj[unr].TempCategory == 5)
              flag = true;
            if (this.game.Data.Product >= 6 && this.game.Data.UnitObj[unr].TempCategory == 2)
              flag = true;
            if (flag && fronts.Value[x, y] > 0)
            {
              tempFront = tfrontlist.FindFront(fronts.Value[x, y]);
              if (!Information.IsNothing((object) tempFront))
              {
                if ((0 & (this.game.Data.UnitObj[unr].TempCategory == 2 ? 1 : 0)) != 0)
                {
                  this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                  tempFront.AddArtUnit(unr);
                  this.AddLog("Assigned (art)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString());
                }
                else if (this.VAR_USE_STRICT_HQFRONT)
                {
                  int tunr = this.game.Data.UnitObj[unr].HQ;
                  aiSubStrictGroup = this.game.Data.UnitObj[unr].AISubStrictGroup;
                  if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(-1))
                    tunr = unr;
                  if (unr == 126)
                    unr = unr;
                  if (tunr > -1)
                  {
                    if (tempFront.strictHQs.CheckIfPresentUnr(tunr, aiSubStrictGroup))
                    {
                      this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                      tempFront.AddUnit(unr);
                      this.AddLog("Assigned ALREADY THERE (norm-strictHq)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString() + " SSHQ-" + aiSubStrictGroup.ToString());
                    }
                    else if (this.friendlySupplyMatrix.Value[x, y] > this.VAR_SUPPLY_25PERCENT_RANGE)
                    {
                      this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                      tempFront.AddUnit(unr);
                      this.AddLog("Assigned ESCAPE (norm-strictHq)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString());
                    }
                    else if (this.CustomCalls.HasCustumCalls() & this.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(unr))
                    {
                      this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                      tempFront.AddUnit(unr);
                      this.AddLog("Assigned where it happens to be (norm-strictHq)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString() + " SSHQ-" + aiSubStrictGroup.ToString());
                    }
                    else
                    {
                      this.game.Data.UnitObj[unr].AIGroup = -1;
                      this.AddLog("NOT assigned " + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString() + " SSHQ-" + aiSubStrictGroup.ToString());
                    }
                  }
                  else
                  {
                    this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                    tempFront.AddUnit(unr);
                    this.AddLog("Assigned NOHQ (norm-strictHq)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString() + " SSHQ-" + aiSubStrictGroup.ToString());
                  }
                }
                else
                {
                  this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                  tempFront.AddUnit(unr);
                  this.AddLog("Assigned (norm)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString());
                }
              }
              else
              {
                DC2AIClass tai10 = this;
                tempFront = new AIFront(ref tai10, 1);
                tempFront.AddUnit(unr);
                tfrontlist.AddFront(tempFront, true);
                tempFront.FrontID = fronts.Value[x, y];
                this.game.Data.UnitObj[unr].AIGroup = fronts.Value[x, y];
                this.AddLog("Assigned CREATE (norm)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString());
              }
            }
          }
        }
      }
      if (this.game.Data.Product <= 5)
      {
        int unitCounter13 = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter13; ++unr)
        {
          if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].AIGroup == -1 & this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == this.GetGameDataTurn())
          {
            int x = this.game.Data.UnitObj[unr].X;
            int y = this.game.Data.UnitObj[unr].Y;
            int hq1 = this.game.Data.UnitObj[unr].HQ;
            if (x > -1 & y > -1 & hq1 > -1)
            {
              int historical = this.game.Data.UnitObj[hq1].Historical;
              if (historical > -1 && this.game.Data.UnitObj[unr].TempCategory == 1 | this.game.Data.UnitObj[unr].TempCategory == 5 && this.game.Data.HistoricalUnitObj[historical].AIlist > 0 & this.VAR_ZONES_TYPE == 2 | this.game.Data.HistoricalUnitObj[historical].AIlist > 200000 & this.VAR_ZONES_TYPE == 3)
              {
                tempFront = tfrontlist.FindFront(this.game.Data.HistoricalUnitObj[historical].AIlist + 1000000);
                if (!Information.IsNothing((object) tempFront) && this.VAR_USE_STRICT_HQFRONT)
                {
                  int hq2 = this.game.Data.UnitObj[unr].HQ;
                  if (hq2 > -1 && tempFront.strictHQs.CheckIfPresentUnr(hq2))
                  {
                    this.game.Data.UnitObj[unr].AIGroup = tempFront.FrontID;
                    tempFront.AddUnit(unr);
                    this.AddLog("Assigned DEFZONE (norm-strictHq)" + this.game.Data.UnitObj[unr].Name + " to front " + tempFront.FrontID.ToString());
                  }
                }
              }
            }
          }
        }
      }
      if ((double) this.game.Data.RuleVar[403] >= 1.0)
        return;
      bool flag14 = false;
      int counter39 = tfrontlist.Counter;
      for (int index96 = 0; index96 <= counter39; ++index96)
      {
        tempFront = tfrontlist.Front[index96];
        int num125 = 0;
        int num126 = 0;
        if (tempFront.units.counter > -1)
        {
          int counter40 = tempFront.units.counter;
          for (int index97 = 0; index97 <= counter40; ++index97)
          {
            int index98 = tempFront.units.unr[index97];
            if (this.game.Data.UnitObj[index98].SupplyInReq > 0 & (double) this.game.Data.UnitObj[index98].SupplyInReq > (double) this.game.Data.UnitObj[index98].Supply / 20.0)
            {
              num125 += (int) Math.Round((double) (100 * this.game.Data.UnitObj[index98].SupplyIn) / (double) (this.game.Data.UnitObj[index98].SupplyInReq + 1));
              ++num126;
            }
          }
        }
        if (num126 > 0 && (int) Math.Round((double) num125 / (double) num126) < 30)
        {
          flag14 = true;
          if (this.game.Data.Product >= 6)
            tempFront.FrontType = 11;
        }
      }
      int num127 = flag14 ? 1 : 0;
    }
  }
}
