﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;

namespace WindowsApplication1
{
  public class CombatClass
  {
    public GameClass game;
    public bool previewMode;
    public int CombatStep;
    public int CombatRound;
    public int DetailCounter;
    public string[] DetailString;
    public string[] RepText;
    public string[] RepTitle;
    public int[] RepFrom;
    public int[] RepRound;
    public int[] RepType;
    public string[,,] RepCom;
    public int RepCounter;
    public int BattleCounter;
    public object[] BattleString;
    public int AllDetailCounter;
    public string[] AllDetailString;
    public CoordList HexList;
    public int UCounter;
    public BattleUnit[] UList;
    public bool EventCaused;
    public int ICounter;
    public Individual[] IList;
    public int BattleEnded;
    public int CombatType;
    public int CombatType2;
    public int IDcounter;
    public const int LANDATTACK = 1;
    public const int LANDSURPRISE = 11;
    public const int AIRRECON = 13;
    public const int SEAATTACK = 2;
    public const int ARTATTACK = 3;
    public const int AIRSTRIKE = 5;
    public const int SEAARTATTACK = 4;
    public const int BOMB = 6;
    public const int PARADROP = 9;
    public const int AMPH = 10;
    public const int REBEL = 12;
    public const int AIRSUPPLY = 14;
    public const int AIRLIFT = 15;
    public const int AIRBRIDGE = 16;
    public bool InterceptFire;
    public Coordinate CombatTarget;
    public float AttackCrowding;
    public float AttackCrowdingAir;
    public float AttackCrowdingArt;
    public float CrowdingAttMod;
    public float CrowdingAttAirMod;
    public float CrowdingAttArtMod;
    public float CrowdingDefMod;
    public int CrowdingDefCount;
    public int AttackerRegime;
    public int DefenderRegime;
    public int TargetX;
    public int TargetY;
    public int TargetMap;
    public float ConcentricBonus;
    public float bestConcentricBonus;
    public int AttackerDice;
    public int DefenderDice;
    public int AntiStrucDam;
    public int initialStrucDam;
    public Coordinate TempTarget;
    public int TempType;
    public UnitList TempUnits;
    public int Tempattacktype;
    public MapMatrix2[] TempValue3;
    public int initialRecon;
    public int initialReconDef;
    public int NewBattleStack;
    public int NewBattleStackArt;
    public int NewBattleStackAir;
    public int se1carryPointsTotal;
    public int se1carryPointsDelivered;
    public int se1damagePercentage;
    public bool dontUseSfx;
    public bool somePartialAttackPresent;
    public CustomCombatCalls customCombatObj;
    public bool allowHistoryOwnRegime;

    public CombatClass(GameClass tgame, bool tPreviewMode = false)
    {
      this.previewMode = false;
      this.DetailString = new string[1];
      this.RepText = new string[1];
      this.RepTitle = new string[1];
      this.RepFrom = new int[1];
      this.RepRound = new int[1];
      this.RepType = new int[1];
      this.RepCom = new string[61, 6, 1];
      this.BattleString = new object[1];
      this.AllDetailString = new string[1];
      this.UList = new BattleUnit[1];
      this.IList = new Individual[1];
      this.InterceptFire = false;
      this.TempValue3 = new MapMatrix2[1];
      this.dontUseSfx = false;
      this.somePartialAttackPresent = false;
      this.allowHistoryOwnRegime = false;
      this.CombatStep = 0;
      this.CombatRound = 0;
      this.UCounter = -1;
      this.ICounter = -1;
      this.BattleCounter = -1;
      this.DetailCounter = -1;
      this.BattleEnded = 0;
      this.game = tgame;
      this.previewMode = tPreviewMode;
      ++this.game.Data.CombatLogId;
      this.TempValue3 = new MapMatrix2[tgame.Data.MapCounter + 1];
      int mapCounter = this.game.Data.MapCounter;
      for (int index = 0; index <= mapCounter; ++index)
        this.TempValue3[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
      this.customCombatObj = new CustomCombatCalls();
    }

    public OrderResult Init(
      Coordinate Target,
      int Type,
      UnitList Units,
      int attacktype,
      bool tDontUseSfx = false,
      bool tallowHistoryOwnRegime = false)
    {
      OrderResult orderResult = new OrderResult();
      Neighbours neighbour = new Neighbours();
      int[] numArray1 = new int[this.game.Data.RegimeCounter + 1];
      this.dontUseSfx = tDontUseSfx;
      this.allowHistoryOwnRegime = tallowHistoryOwnRegime;
      this.game.EditObj.CombatOneSentence = "";
      this.game.EditObj.CombatOneSentenceCustom = "";
      if (this.game.Data.UncertaintyOn)
      {
        this.AttackerDice = DrawMod.RandyNumber.Next(1, 7);
        this.DefenderDice = DrawMod.RandyNumber.Next(1, 7);
      }
      this.TempTarget = Target;
      this.TempType = Type;
      this.TempUnits = Units;
      this.Tempattacktype = attacktype;
      orderResult.OK = true;
      this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
      int mapCounter1 = this.game.Data.MapCounter;
      for (int index = 0; index <= mapCounter1; ++index)
        this.game.EditObj.TempValue[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
      int mapCounter2 = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter2; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
            this.TempValue3[index1].Value[index2, index3] = this.game.EditObj.TempValue[index1].Value[index2, index3];
        }
      }
      if (orderResult.OK)
      {
        if (this.game.Data.MapObj[0].HexObj[Target.x, Target.y].Location > -1)
          this.initialStrucDam = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[Target.x, Target.y].Location].StructuralPts;
        this.CombatTarget = Target;
        this.HexList = new CoordList();
        this.HexList.AddCoord(Target.x, Target.y, Target.map);
        this.TargetX = Target.x;
        this.TargetY = Target.y;
        this.TargetMap = Target.map;
        this.DefenderRegime = -1;
        this.InterceptFire = false;
        this.CombatType2 = 0;
        if (attacktype == 2)
          this.CombatType = 1;
        if (attacktype == 12)
          this.CombatType = 2;
        if (attacktype == 11)
          this.CombatType = 3;
        if (attacktype == 13)
          this.CombatType = 4;
        if (attacktype == 14)
          this.CombatType = 5;
        if (attacktype == 15)
          this.CombatType = 6;
        if (attacktype == 19)
          this.CombatType = 9;
        if (attacktype == 21)
          this.CombatType = 10;
        if (attacktype == 1)
          this.CombatType = 11;
        if (attacktype == 31)
          this.CombatType = 12;
        if (attacktype == 33)
          this.CombatType = 13;
        if (attacktype == 55)
        {
          this.CombatType = 13;
          this.CombatType2 = 16;
        }
        if (attacktype == 40)
          this.CombatType = 14;
        if (attacktype == 42)
          this.CombatType = 15;
        if (attacktype == 18)
          this.CombatType = 10;
        if (attacktype == 99 & (double) this.game.Data.RuleVar[428] > 0.0)
        {
          this.CombatType = 3;
          this.InterceptFire = true;
        }
        this.AttackCrowding = this.game.Data.RuleVar[30];
        this.AttackCrowdingAir = this.game.Data.RuleVar[833];
        this.AttackCrowdingArt = this.game.Data.RuleVar[834];
        this.game.EditObj.TargetX = this.TargetX;
        this.game.EditObj.TargetY = this.TargetY;
        if (this.CombatType == 12 | this.CombatType == 10 | this.CombatType == 1 | this.CombatType == 9)
          this.AttackCrowding = (float) this.game.HandyFunctionsObj.maxAttackStack();
        int counter1 = Units.counter;
        Coordinate coordinate;
        for (int index = 0; index <= counter1; ++index)
        {
          if (this.CombatType == 9 & Units.data[index] == 1)
          {
            this.game.Data.MapObj[this.game.Data.UnitObj[Units.unr[index]].Map].HexObj[this.game.Data.UnitObj[Units.unr[index]].X, this.game.Data.UnitObj[Units.unr[index]].Y].RemoveUnitFromList(Units.unr[index]);
            this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].AddUnitToList(Units.unr[index]);
            this.game.Data.UnitObj[Units.unr[index]].X = Target.x;
            this.game.Data.UnitObj[Units.unr[index]].Y = Target.y;
          }
          if (this.CombatType == 9 & Units.data[index] == 1 | this.CombatType == 10 | this.CombatType == 12)
          {
            coordinate = new Coordinate();
            coordinate.x = -1;
            coordinate.y = -1;
            coordinate.map = -1;
            this.AttackerRegime = this.game.Data.UnitObj[Units.unr[index]].Regime;
            coordinate.onmap = false;
            this.AddUnitToUnits(Units.unr[index], 1, coordinate, coordinate, Target, IsParadropper: true);
          }
          else
          {
            coordinate = new Coordinate();
            coordinate.onmap = true;
            coordinate.x = this.game.Data.UnitObj[Units.unr[index]].X;
            coordinate.y = this.game.Data.UnitObj[Units.unr[index]].Y;
            coordinate.map = this.game.Data.UnitObj[Units.unr[index]].Map;
            this.AttackerRegime = this.game.Data.UnitObj[Units.unr[index]].Regime;
            this.AddUnitToUnits(Units.unr[index], 1, coordinate, coordinate, Target);
          }
          if (this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 11)
          {
            int num = this.game.HandyFunctionsObj.HexFacing(Target.x, Target.y, Target.map, this.game.Data.UnitObj[Units.unr[index]].X, this.game.Data.UnitObj[Units.unr[index]].Y, this.game.Data.UnitObj[Units.unr[index]].Map);
            if (num > 0)
              neighbour.data[num - 1] = 1;
          }
          if (!this.HexList.Exists(this.game.Data.UnitObj[Units.unr[index]].X, this.game.Data.UnitObj[Units.unr[index]].Y, this.game.Data.UnitObj[Units.unr[index]].Map))
            this.HexList.AddCoord(this.game.Data.UnitObj[Units.unr[index]].X, this.game.Data.UnitObj[Units.unr[index]].Y, this.game.Data.UnitObj[Units.unr[index]].Map);
        }
        int unitCounter1 = this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].UnitCounter;
        Coordinate ttoo;
        for (int index = 0; index <= unitCounter1; ++index)
        {
          int unit = this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].UnitList[index];
          if (this.game.Data.UnitObj[unit].Regime != this.AttackerRegime & (this.game.Data.RegimeObj[this.AttackerRegime].RegimeRel[this.game.Data.UnitObj[unit].Regime] <= 1 | (double) this.game.Data.RuleVar[342] == 1.0) && this.InterceptFire & unit == this.game.EditObj.OrderUnit | !this.InterceptFire)
          {
            if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].LandscapeType].IsSea)
              coordinate = this.game.HandyFunctionsObj.FindLandRetreat(unit, Target, neighbour);
            else if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].LandscapeType].IsSea)
              coordinate = this.game.HandyFunctionsObj.FindSeaRetreat(unit, Target, neighbour);
            this.AddUnitToUnits(unit, 0, coordinate, Target, ttoo);
            if (this.game.Data.UnitObj[unit].Regime != this.AttackerRegime)
              this.DefenderRegime = this.game.Data.UnitObj[unit].Regime;
          }
        }
        if (this.CombatType == 1 & (double) this.game.Data.RuleVar[428] > 0.0 & this.game.Data.Product >= 6 & !this.previewMode)
        {
          UnitList interceptFireUnits = this.game.HandyFunctionsObj.GetInterceptFireUnits(-1, Target.x, Target.y);
          int counter2 = interceptFireUnits.counter;
          for (int index4 = 0; index4 <= counter2; ++index4)
          {
            int tunr = interceptFireUnits.unr[index4];
            int num = 1;
            int unitCounter2 = this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].UnitCounter;
            for (int index5 = 0; index5 <= unitCounter2; ++index5)
            {
              if (this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].UnitList[index5] == tunr)
                num = 0;
            }
            if (num == 1)
            {
              coordinate = new Coordinate();
              coordinate.onmap = true;
              coordinate.x = this.game.Data.UnitObj[tunr].X;
              coordinate.y = this.game.Data.UnitObj[tunr].Y;
              coordinate.map = this.game.Data.UnitObj[tunr].Map;
              if (coordinate.x == -1)
                index4 = index4;
              this.AddUnitToUnits(tunr, 0, coordinate, coordinate, Target, isSupportInterceptFire: true);
              if (!this.HexList.Exists(this.game.Data.UnitObj[tunr].X, this.game.Data.UnitObj[tunr].Y, this.game.Data.UnitObj[tunr].Map))
                this.HexList.AddCoord(this.game.Data.UnitObj[tunr].X, this.game.Data.UnitObj[tunr].Y, this.game.Data.UnitObj[tunr].Map);
            }
          }
        }
        if (!this.previewMode && this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 9 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15)
        {
          int num1 = 0;
          int index6 = -1;
          if (this.game.Data.MapObj[Target.map].HexObj[Target.x, Target.y].Regime == this.AttackerRegime | this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[Target.x, Target.y].Regime == -1)
          {
            num1 = 1;
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter3; ++unr)
            {
              if (this.game.Data.UnitObj[unr].Regime != this.AttackerRegime && this.game.HandyFunctionsObj.CanUnitIntercept(unr, Target, this.AttackerRegime))
              {
                bool flag = true;
                if ((double) this.game.Data.RuleVar[407] > 0.0 && !this.CheckEnoughFuelAmmo(unr, false))
                  flag = false;
                if (flag && !(this.game.Data.UnitObj[unr].X == this.TargetX & this.game.Data.UnitObj[unr].Y == this.TargetY))
                {
                  int[] numArray2 = numArray1;
                  int[] numArray3 = numArray2;
                  int regime = this.game.Data.UnitObj[unr].Regime;
                  int index7 = regime;
                  int num2 = numArray2[regime] + this.game.HandyFunctionsObj.GetInterdictPower(unr);
                  numArray3[index7] = num2;
                }
              }
            }
            int regimeCounter = this.game.Data.RegimeCounter;
            for (int index8 = 0; index8 <= regimeCounter; ++index8)
            {
              int num3;
              if (numArray1[index8] > num3)
              {
                index6 = index8;
                num3 = numArray1[index8];
              }
            }
            if (index6 > -1)
              this.DefenderRegime = index6;
          }
          if (this.DefenderRegime == -1)
            this.DefenderRegime = this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Regime;
          int[] numArray4 = new int[500];
          int[] numArray5 = new int[500];
          Random random = new Random();
          float num4 = (float) random.Next(0, 100);
          int unitCounter4 = this.game.Data.UnitCounter;
          for (int index9 = 0; index9 <= unitCounter4; ++index9)
          {
            if (this.game.Data.UnitObj[index9].Regime != this.AttackerRegime)
            {
              float num5 = (float) random.Next(0, 100);
              int num6 = 1;
              int num7 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y, 0, this.TargetX, this.TargetY, this.TargetMap);
              if (num7 == 0)
                num7 = num7;
              if (this.game.HandyFunctionsObj.CanUnitIntercept(index9, Target, this.AttackerRegime))
              {
                if (num7 > 0 & (double) this.game.Data.RuleVar[837] > 0.0)
                {
                  int num8 = this.game.EditObj.TempValue[this.TargetMap].Value[this.TargetX, this.TargetY];
                  int num9 = (int) Math.Round((double) ((float) this.game.HandyFunctionsObj.GetLowestAirAp(index9) * this.game.Data.RuleVar[147]));
                  int num10 = num8 <= num9 ? (int) Math.Round((double) ((float) (int) Math.Round((double) (int) Math.Round((double) (this.game.Data.RuleVar[837] - this.game.Data.RuleVar[838])) * ((double) num8 / (double) num9)) + this.game.Data.RuleVar[838])) : (int) Math.Round((double) this.game.Data.RuleVar[837]);
                  if ((double) num5 < (double) num10)
                    num6 = 0;
                }
                if (num6 == 1 && !(this.game.Data.UnitObj[index9].Map == this.TargetMap & this.game.Data.UnitObj[index9].X == this.TargetX & this.game.Data.UnitObj[index9].Y == this.TargetY))
                {
                  int num11 = 1;
                  if (num1 == 1 & this.game.Data.UnitObj[index9].Regime != index6)
                  {
                    num11 = 0;
                    if (this.game.Data.RegimeObj[index6].RegimeRel[this.game.Data.UnitObj[index9].Regime] == 2)
                      num11 = 1;
                  }
                  if (num11 == 1)
                  {
                    if ((double) this.game.Data.RuleVar[407] > 0.0)
                    {
                      if ((double) this.game.Data.RuleVar[407] > 0.0)
                      {
                        this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y, 0, this.TargetX, this.TargetY, 0);
                        if (!this.CheckEnoughFuelAmmo(index9, false))
                          num11 = 0;
                      }
                    }
                    else
                    {
                      int index10 = 0;
                      do
                      {
                        numArray4[index10] = numArray5[index10];
                        ++index10;
                      }
                      while (index10 <= 499);
                      int sfCount = this.game.Data.UnitObj[index9].SFCount;
                      for (int index11 = 0; index11 <= sfCount; ++index11)
                      {
                        int sf = this.game.Data.UnitObj[index9].SFList[index11];
                        int type = this.game.Data.SFObj[sf].Type;
                        if (this.game.Data.SFTypeObj[type].Theater == 2 && !this.game.Data.SFTypeObj[type].BackBench)
                        {
                          int fuelRegimeVar = this.game.Data.SFTypeObj[type].FuelRegimeVar;
                          int currentSlot = this.game.Data.SFTypeObj[type].FuelRegimeVar;
                          if ((double) this.game.Data.RuleVar[949] > 0.0)
                            currentSlot = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot, this.game.Data.UnitObj[index9].RealX(ref this.game), this.game.Data.UnitObj[index9].RealY(ref this.game));
                          int index12 = currentSlot;
                          if (index12 > -1)
                          {
                            int num12 = this.game.Data.SFTypeObj[type].FuelForAttackDef * 2 * this.game.Data.SFObj[sf].Qty;
                            int[] numArray6 = numArray4;
                            int[] numArray7 = numArray6;
                            int index13 = index12;
                            int index14 = index13;
                            int num13 = numArray6[index13] + num12;
                            numArray7[index14] = num13;
                            if (numArray4[index12] > this.game.Data.RegimeObj[this.game.Data.UnitObj[index9].Regime].RegimeSlot[index12])
                              num11 = 0;
                          }
                        }
                      }
                      if (num11 == 1)
                      {
                        int index15 = 0;
                        do
                        {
                          numArray5[index15] = numArray4[index15];
                          ++index15;
                        }
                        while (index15 <= 499);
                      }
                    }
                    if (num11 == 1)
                    {
                      coordinate = new Coordinate();
                      coordinate.onmap = true;
                      coordinate.x = this.game.Data.UnitObj[index9].X;
                      coordinate.y = this.game.Data.UnitObj[index9].Y;
                      coordinate.map = this.game.Data.UnitObj[index9].Map;
                      Coordinate tfrom = coordinate;
                      if (this.game.Data.UnitObj[index9].X == this.TargetX & this.game.Data.UnitObj[index9].Y == this.TargetY & this.game.Data.UnitObj[index9].Map == this.TargetMap)
                        coordinate.onmap = false;
                      if (!this.HexList.Exists(this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y, this.game.Data.UnitObj[index9].Map))
                        this.HexList.AddCoord(this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y, this.game.Data.UnitObj[index9].Map);
                      if (this.DefenderRegime == -1)
                        this.DefenderRegime = this.game.Data.UnitObj[index9].Regime;
                      int num14 = 0;
                      if (this.DefenderRegime == this.game.Data.UnitObj[index9].Regime)
                        num14 = 1;
                      if (this.game.Data.RegimeObj[this.DefenderRegime].RegimeRel[this.game.Data.UnitObj[index9].Regime] == 2)
                        num14 = 1;
                      if (num14 == 1)
                        this.AddUnitToUnits(index9, 0, coordinate, tfrom, ttoo, true);
                    }
                  }
                }
              }
            }
          }
          int unitCounter5 = this.game.Data.UnitCounter;
          for (int index16 = 0; index16 <= unitCounter5; ++index16)
          {
            if (this.game.Data.UnitObj[index16].Regime == this.DefenderRegime && !(this.game.Data.UnitObj[index16].X == this.TargetX & this.game.Data.UnitObj[index16].Y == this.TargetY & this.game.Data.UnitObj[index16].Map == this.TargetMap) && this.game.HandyFunctionsObj.CanUnitAA(index16, Target, this.AttackerRegime))
            {
              bool flag = true;
              if ((double) this.game.Data.RuleVar[407] > 0.0 && !this.CheckEnoughFuelAmmo(index16, true))
                flag = false;
              if (flag)
              {
                coordinate = new Coordinate();
                coordinate.onmap = true;
                coordinate.x = this.game.Data.UnitObj[index16].X;
                coordinate.y = this.game.Data.UnitObj[index16].Y;
                coordinate.map = this.game.Data.UnitObj[index16].Map;
                this.HexList.AddCoord(this.game.Data.UnitObj[index16].X, this.game.Data.UnitObj[index16].Y, this.game.Data.UnitObj[index16].Map);
                this.AddUnitToUnits(index16, 0, coordinate, coordinate, ttoo, isAA: true);
              }
            }
          }
        }
        if (this.DefenderRegime == -1)
          this.DefenderRegime = this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Regime;
        if (!this.previewMode)
        {
          int ucounter = this.UCounter;
          for (int index = 0; index <= ucounter; ++index)
          {
            int unr = this.UList[index].UNr;
            this.game.HandyFunctionsObj.RemoveZOCPts(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.HandyFunctionsObj.GetUnitZOC(unr), this.game.Data.UnitObj[unr].Regime);
          }
        }
        if (!this.previewMode)
        {
          ++this.game.Data.StepNr;
          if (!this.game.EditObj.CombatSim)
          {
            if (this.CombatType == 12)
            {
              if (!this.game.Data.RegimeObj[this.AttackerRegime].AI)
              {
                this.game.Data.MapObj[0].HexObj[Target.x, Target.y].set_ReconPts(this.AttackerRegime, 999);
                this.game.Data.MapObj[0].HexObj[Target.x, Target.y].set_SeeNow(this.AttackerRegime, 1);
                this.game.Data.MapObj[0].HexObj[Target.x, Target.y].set_LastLT(this.AttackerRegime, this.game.Data.MapObj[0].HexObj[Target.x, Target.y].LandscapeType);
                this.game.Data.MapObj[0].HexObj[Target.x, Target.y].set_LastSpr(this.AttackerRegime, this.game.Data.MapObj[0].HexObj[Target.x, Target.y].SpriteNr);
                this.game.Data.MapObj[0].HexObj[Target.x, Target.y].set_LastReg(this.AttackerRegime, this.game.Data.MapObj[0].HexObj[Target.x, Target.y].Regime);
                this.game.HandyFunctionsObj.HistoryAddHex(Target.x, Target.y, 0, this.AttackerRegime, 1, 1, infostring: "Friendly Rebels appear", allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
                ++this.game.Data.StepNr;
              }
              this.game.HandyFunctionsObj.HistoryAddHex(Target.x, Target.y, Target.map, -1, 3, neighbour: neighbour, attacktype: attacktype, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
            }
            else if (this.InterceptFire)
              this.game.HandyFunctionsObj.HistoryAddHex(Target.x, Target.y, Target.map, this.DefenderRegime, 3, neighbour: neighbour, attacktype: attacktype, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
            else
              this.game.HandyFunctionsObj.HistoryAddHex(Target.x, Target.y, Target.map, this.AttackerRegime, 3, neighbour: neighbour, attacktype: attacktype, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
          }
        }
        bool flag1 = false;
        if (this.AttackerRegime > -1)
          flag1 = this.game.Data.RegimeObj[this.AttackerRegime].AI;
        if (this.CombatType == 1)
        {
          if (this.game.HandyFunctionsObj.GetHQsInUnitList() > 1)
          {
            HandyFunctionsclass handyFunctionsObj = this.game.HandyFunctionsObj;
            ref Neighbours local1 = ref neighbour;
            bool flag2 = true;
            ref bool local2 = ref flag2;
            int num = flag1 ? 1 : 0;
            this.ConcentricBonus = handyFunctionsObj.GetConcentricBonus(ref local1, ref local2, num != 0);
          }
          else
          {
            HandyFunctionsclass handyFunctionsObj = this.game.HandyFunctionsObj;
            ref Neighbours local3 = ref neighbour;
            bool flag3 = false;
            ref bool local4 = ref flag3;
            int num = flag1 ? 1 : 0;
            this.ConcentricBonus = handyFunctionsObj.GetConcentricBonus(ref local3, ref local4, num != 0);
          }
        }
        else
          this.ConcentricBonus = 1f;
        if ((double) this.ConcentricBonus > (double) this.bestConcentricBonus)
          this.bestConcentricBonus = this.ConcentricBonus;
        this.AddToI();
        if (!this.previewMode)
          this.PreBattleStuff();
        if ((double) this.game.Data.RuleVar[407] > 0.0)
          this.InitLis();
        if ((double) this.game.Data.RuleVar[434] > 0.0)
          this.InitSimplifiedSupply();
      }
      this.initialRecon = this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].get_ReconPts(this.AttackerRegime);
      if (this.game.EventRelatedObj.Helper_AirEnabled())
      {
        int num = 0;
        int icounter = this.ICounter;
        for (int index = 0; index <= icounter; ++index)
        {
          if (this.IList[index].IAttacker == 1 && this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 2)
            num += this.game.Data.SFTypeObj[this.IList[index].ISFType].ReconPts;
        }
        if (this.CombatType2 == 16)
          this.initialRecon = (int) Math.Round(Math.Ceiling((double) num / 2.0));
        else if (this.CombatType == 13)
          this.initialRecon = Convert.ToInt32(Math.Ceiling(new Decimal(num * 2)));
        else if (this.CombatType == 5)
          this.initialRecon = (int) Math.Round(Math.Ceiling((double) num / 2.0));
      }
      if (!this.previewMode && this.customCombatObj.HasCustumCalls())
      {
        CustomCombatCalls customCombatObj = this.customCombatObj;
        CombatClass combatClass = this;
        ref CombatClass local = ref combatClass;
        GameClass game = this.game;
        customCombatObj.PreCombatCall(ref local, game);
      }
      this.CombatReconEndOfRound();
      return orderResult;
    }

    public void PayForSimplifiedSupplyRules()
    {
      if (this.CombatRound < 1)
        this.CombatRound = 1;
      int ucounter = this.UCounter;
      for (int index1 = 0; index1 <= ucounter; ++index1)
      {
        float a1 = 0.0f;
        float a2 = 0.0f;
        int icounter = this.ICounter;
        for (int index2 = 0; index2 <= icounter; ++index2)
        {
          if (this.IList[index2].IUlistNr == index1)
          {
            int isfType = this.IList[index2].ISFType;
            float num1 = 0.0f;
            float num2 = 0.0f;
            int num3 = this.CombatRound;
            if (this.IList[index2].IRetreated > 0)
              num3 = this.IList[index2].IRetreat;
            int num4 = 10;
            if (this.game.Data.SFTypeObj[this.IList[index2].ISFType].EndCombatRound > 0 && this.game.Data.SFTypeObj[this.IList[index2].ISFType].EndCombatRound < this.CombatRound)
              num4 = this.game.Data.SFTypeObj[this.IList[index2].ISFType].EndCombatRound - this.game.Data.SFTypeObj[this.IList[index2].ISFType].StartCombatRound;
            if (this.UList[index1].Uattacker == 1)
            {
              if (this.game.Data.SFTypeObj[isfType].SupplyForAttack > 0)
                num1 += (float) this.game.Data.SFTypeObj[isfType].SupplyForAttack / (float) num4 * (float) num3;
              if (this.game.Data.SFTypeObj[isfType].FuelForAttack > 0)
              {
                float num5 = 0.0f;
                float val1;
                if (this.UList[index1].UApSpend > 0)
                {
                  float num6 = (float) Math.Max(25, this.UList[index1].UApMoveCost) / (float) this.UList[index1].UApSpend;
                  if ((double) num6 > 1.0)
                    num6 = 1f;
                  float num7 = 1f - num6;
                  if ((double) num7 < 0.0)
                    num7 = 0.0f;
                  float num8 = VBMath.Rnd();
                  val1 = num5 + (float) (this.game.Data.SFTypeObj[isfType].FuelForAttack * num3) * num6 + (float) (this.game.Data.SFTypeObj[isfType].FuelForAttackDef * num3) * num7 * num8 + (float) ((double) (this.game.Data.SFTypeObj[isfType].FuelForAttack * num3) * (double) num7 * (1.0 - (double) num8));
                }
                else
                  val1 = num5 + (float) (this.game.Data.SFTypeObj[isfType].FuelForAttackDef * num3);
                float val2 = (float) this.game.Data.SFTypeObj[isfType].FuelForMove * ((float) this.UList[index1].UApMoveCost / 10f);
                float num9 = Math.Max(val1, val2);
                num2 += num9;
              }
            }
            else if (this.IList[index2].ILastAttackDone > 0)
            {
              if (this.game.Data.SFTypeObj[isfType].SupplyForAttackDef > 0)
                num1 += (float) this.game.Data.SFTypeObj[isfType].SupplyForAttackDef / (float) num4 * (float) num3;
              if (this.game.Data.SFTypeObj[isfType].FuelForAttackDef > 0)
                num2 += (float) (this.game.Data.SFTypeObj[isfType].FuelForAttackDef * num3);
            }
            float num10;
            float num11;
            if (this.IList[index2].IAttacker == 0)
            {
              num10 = num1 * (float) (((double) this.IList[index2].ILisAmmoMod - 0.330000013113022) / 0.660000026226044);
              num11 = num2 * (float) (((double) this.IList[index2].ILisFuelMod - 0.330000013113022) / 0.660000026226044);
            }
            else
            {
              num10 = num1 * this.IList[index2].ILisAmmoMod;
              num11 = num2 * this.IList[index2].ILisFuelMod;
            }
            if (this.IList[index2].IleftOutOfPartialAttack)
              num11 = 0.0f;
            if (this.UList[index1].UDefIntercept)
              num11 = 0.0f;
            a1 += num10;
            a2 += num11;
          }
        }
        if (this.UList[index1].Uattacker == 0 & this.InterceptFire)
          a1 = 0.0f;
        if (this.InterceptFire & (double) this.game.Data.RuleVar[436] > 0.0)
        {
          a1 = (float) (int) Math.Round(Math.Ceiling((double) a1 * (double) this.game.Data.RuleVar[436]));
          a2 = 0.0f;
        }
        if (this.UList[index1].Uattacker == 1)
        {
          if (this.game.Data.RegimeObj[this.AttackerRegime].AI)
          {
            a1 = (float) (int) Math.Round((double) a1 * (1.0 - (double) ((this.game.Data.RegimeObj[this.AttackerRegime].AIHelpCombat + 10) * 2) / 100.0));
            a2 = (float) (int) Math.Round((double) a2 * (1.0 - (double) ((this.game.Data.RegimeObj[this.AttackerRegime].AIHelpCombat + 10) * 2) / 100.0));
          }
        }
        else if (this.game.Data.RegimeObj[this.DefenderRegime].AI)
        {
          a1 = (float) (int) Math.Round((double) a1 * (1.0 - (double) ((this.game.Data.RegimeObj[this.DefenderRegime].AIHelpCombat + 10) * 2) / 100.0));
          a2 = (float) (int) Math.Round((double) a2 * (1.0 - (double) ((this.game.Data.RegimeObj[this.DefenderRegime].AIHelpCombat + 10) * 2) / 100.0));
        }
        UnitClass[] unitObj1 = this.game.Data.UnitObj;
        UnitClass[] unitClassArray1 = unitObj1;
        int unr1 = this.UList[index1].UNr;
        int index3 = unr1;
        unitClassArray1[index3].Supply = unitObj1[unr1].Supply - (int) Math.Round((double) a1);
        if (0 > this.game.Data.UnitObj[this.UList[index1].UNr].Supply)
          this.game.Data.UnitObj[this.UList[index1].UNr].Supply = 0;
        if ((double) this.game.Data.RuleVar[435] > 0.0)
        {
          if (this.CombatType == 3 | this.CombatType == 4)
            a2 = 0.0f;
          UnitClass[] unitObj2 = this.game.Data.UnitObj;
          UnitClass[] unitClassArray2 = unitObj2;
          int unr2 = this.UList[index1].UNr;
          int index4 = unr2;
          unitClassArray2[index4].Fuel = unitObj2[unr2].Fuel - (int) Math.Round((double) a2);
          UnitClass[] unitObj3 = this.game.Data.UnitObj;
          UnitClass[] unitClassArray3 = unitObj3;
          int unr3 = this.UList[index1].UNr;
          int index5 = unr3;
          unitClassArray3[index5].FuelUsedMove = unitObj3[unr3].FuelUsedMove + (int) Math.Round((double) a2);
          if (0 > this.game.Data.UnitObj[this.UList[index1].UNr].Fuel)
            this.game.Data.UnitObj[this.UList[index1].UNr].Fuel = 0;
        }
      }
    }

    public void PayForLis()
    {
      int index1 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 2;
      int index2 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 3;
      int index3 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 4;
      int index4 = 17;
      int index5 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 0;
      int index6 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 1;
      int ucounter = this.UCounter;
      for (int index7 = 0; index7 <= ucounter; ++index7)
      {
        SimpleList SL = new SimpleList();
        int combatRound = this.CombatRound;
        int num1 = this.CombatType == 3 ? (!(this.UList[index7].URetreatMode == 2 | this.UList[index7].URetreatMode == 3) ? combatRound - 2 : this.UList[index7].URetreat) : combatRound - 2;
        int num2 = 0;
        if (this.CombatType == 5 | this.CombatType == 13)
        {
          int unr = this.UList[index7].UNr;
          num2 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, this.TargetX, this.TargetY, 0, 99);
        }
        if (num1 < 1)
          num1 = 1;
        int icounter = this.ICounter;
        for (int index8 = 0; index8 <= icounter; ++index8)
        {
          if (this.IList[index8].IUlistNr == index7)
          {
            int isfType = this.IList[index8].ISFType;
            int num3 = num1;
            if (num2 > 0)
            {
              int num4 = (int) Math.Round(Math.Ceiling((double) (num2 * this.game.Data.SFTypeObj[isfType].AirAPRule) / 10.0));
              if (num4 > num3)
                num3 = num4;
            }
            if (this.CombatType2 == 16 | this.CombatType == 13 | this.CombatType == 5 & this.IList[index8].IAttacker == 0)
            {
              if (this.game.Data.SFTypeObj[isfType].SFTypeVar[index6] > 0)
                SL.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index5], (int) Math.Round((double) (this.game.Data.SFTypeObj[isfType].SFTypeVar[index6] * num3) * 0.5));
            }
            else if (this.CombatType != 3 && this.game.Data.SFTypeObj[isfType].SFTypeVar[index6] > 0)
              SL.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index5], this.game.Data.SFTypeObj[isfType].SFTypeVar[index6] * num3);
            if (!(this.game.Data.SFTypeObj[this.IList[index8].ISFType].ArtRange > 0 & (double) this.IList[index8].ILisAmmoMod < 1.0))
            {
              if (this.game.Data.SFTypeObj[this.IList[index8].ISFType].Theater == 2)
              {
                if (this.IList[index8].RoundsOfLandAttack > 0 && this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] > 0)
                {
                  int tweight = this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] * this.IList[index8].RoundsOfLandAttack;
                  SL.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index1], tweight);
                }
                if (this.IList[index8].RoundsOfAirAttack > 0 && this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] > 0)
                {
                  int tweight = this.game.Data.SFTypeObj[isfType].SFTypeVar[index4] * this.IList[index8].RoundsOfAirAttack;
                  SL.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index1], tweight);
                }
              }
              else if (this.UList[index7].Uattacker == 1)
              {
                if (this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] > 0)
                  SL.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index1], this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] * num1);
              }
              else if (this.game.Data.SFTypeObj[isfType].SFTypeVar[index3] > 0)
                SL.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index1], this.game.Data.SFTypeObj[isfType].SFTypeVar[index3] * num1);
            }
            else
              index7 = index7;
            index7 = index7;
          }
        }
        int counter = SL.Counter;
        for (int index9 = 0; index9 <= counter; ++index9)
        {
          int num5 = SL.Weight[index9];
          int num6 = (int) Math.Round(Math.Ceiling((double) SL.Weight[index9] / 10.0));
          int num7 = num5 - num6 * 10;
          if (num7 > 0 && DrawMod.RandyNumber.Next(0, 10) <= num7)
            ++num6;
          SL.Weight[index9] = num6;
        }
        this.game.Data.UnitObj[this.UList[index7].UNr].items.list.RemoveWeight(ref SL);
        this.game.Data.UnitObj[this.UList[index7].UNr].items.list.removeWeight0orLower();
      }
    }

    public void InitLis()
    {
      int index1 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 2;
      int index2 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 3;
      int index3 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 4;
      int index4 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 0;
      int index5 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 1;
      int ucounter = this.UCounter;
      for (int index6 = 0; index6 <= ucounter; ++index6)
      {
        int num1 = 0;
        if (this.CombatType == 5 | this.CombatType == 13)
          num1 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index6].UNr].X, this.game.Data.UnitObj[this.UList[index6].UNr].Y, 0, this.TargetX, this.TargetY, 0, 99);
        SimpleList simpleList1 = this.game.Data.UnitObj[this.UList[index6].UNr].items.list.Clone();
        SimpleList simpleList2 = new SimpleList();
        int icounter1 = this.ICounter;
        for (int index7 = 0; index7 <= icounter1; ++index7)
        {
          if (this.IList[index7].IUlistNr == index6)
          {
            int isfType = this.IList[index7].ISFType;
            float num2 = 1f;
            int num3 = this.game.Data.SFObj[this.IList[index7].ISFNr].Ap;
            if (this.game.Data.SFTypeObj[this.IList[index7].ISFType].EndCombatRound > 0)
              num3 = this.game.Data.SFTypeObj[this.IList[index7].ISFType].EndCombatRound * 10;
            if (num3 < 100)
              num2 = (float) num3 / 100f;
            float num4 = num2;
            if (this.UList[index6].UDefIntercept && num1 > 0)
            {
              int val1 = (int) Math.Round(Math.Ceiling((double) (num1 * this.game.Data.SFTypeObj[isfType].AirAPRule) / 10.0));
              int num5 = this.CombatType != 13 ? Math.Max(val1, 10) : Math.Max(val1, 3);
              num4 = (float) ((double) num4 * (double) num5 / 10.0);
            }
            if (this.CombatType2 == 16 | this.CombatType == 13 | this.CombatType == 5 & this.IList[index7].IAttacker == 0)
            {
              if (this.game.Data.SFTypeObj[isfType].SFTypeVar[index5] > 0)
                simpleList2.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index4], (int) Math.Round((double) this.game.Data.SFTypeObj[isfType].SFTypeVar[index5] * (double) num4 * 0.5));
            }
            else if (this.CombatType != 3 && this.game.Data.SFTypeObj[isfType].SFTypeVar[index5] > 0 && !(this.CombatType == 3 | this.CombatType == 4))
              simpleList2.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index4], (int) Math.Round((double) ((float) this.game.Data.SFTypeObj[isfType].SFTypeVar[index5] * num2)));
            if (this.UList[index6].Uattacker == 1)
            {
              if (this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] > 0)
                simpleList2.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index1], (int) Math.Round(Math.Ceiling((double) this.game.Data.SFTypeObj[isfType].SFTypeVar[index2] * (double) num2)));
            }
            else if (this.game.Data.SFTypeObj[isfType].SFTypeVar[index3] > 0)
              simpleList2.AddWeight(this.game.Data.SFTypeObj[isfType].SFTypeVar[index1], (int) Math.Round(Math.Ceiling((double) this.game.Data.SFTypeObj[isfType].SFTypeVar[index3] * (double) num2)));
          }
        }
        int icounter2 = this.ICounter;
        for (int index8 = 0; index8 <= icounter2; ++index8)
        {
          if (this.IList[index8].IUlistNr == index6)
          {
            int isfType = this.IList[index8].ISFType;
            int tid1 = this.game.Data.SFTypeObj[isfType].SFTypeVar[index1];
            int weight1 = simpleList1.FindWeight(tid1);
            int weight2 = simpleList2.FindWeight(tid1);
            float num6 = (this.IList[index8].IAttacker != 1 ? this.game.Data.SFTypeObj[isfType].SFTypeVar[index3] : this.game.Data.SFTypeObj[isfType].SFTypeVar[index2]) <= 0 ? 1f : (weight2 <= 0 ? 1f : Math.Min(1f, (float) weight1 / (float) weight2));
            int tid2 = this.game.Data.SFTypeObj[isfType].SFTypeVar[index4];
            int weight3 = simpleList1.FindWeight(tid2);
            int weight4 = simpleList2.FindWeight(tid2);
            float num7 = this.game.Data.SFTypeObj[isfType].SFTypeVar[index5] <= 0 ? 1f : (weight4 <= 0 ? 1f : Math.Min(1f, (float) weight3 / (float) weight4));
            if (this.CombatType == 3 | this.CombatType == 4)
              num7 = 1f;
            this.IList[index8].ILisAmmoMod = num6;
            this.IList[index8].ILisFuelMod = num7;
          }
        }
      }
    }

    public bool CheckEnoughFuelAmmo(int unr, bool forAA)
    {
      int num1 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, this.TargetX, this.TargetY, 0);
      int val2 = 10;
      if (this.CombatType == 13)
        val2 = 3;
      int index1 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 2;
      int num2 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 3;
      int index2 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 4;
      int index3 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 0;
      int index4 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 1;
      SimpleList simpleList1 = this.game.Data.UnitObj[unr].items.list.Clone();
      SimpleList simpleList2 = new SimpleList();
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index5 = 0; index5 <= sfCount; ++index5)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index5];
        int type = this.game.Data.SFObj[sf].Type;
        float num3 = 1f;
        float num4 = 1f;
        if (val2 < 10)
        {
          num4 = (float) val2 / 10f;
          num3 = (float) val2 / 10f;
        }
        if (num1 > 0)
        {
          int num5 = Math.Max((int) Math.Round(Math.Ceiling((double) (num1 * this.game.Data.SFTypeObj[type].AirAPRule) / 10.0)), val2);
          num4 = (float) ((double) num4 * (double) num5 / 10.0);
        }
        Math.Min(this.game.Data.SFObj[sf].Ap, this.game.Data.SFObj[sf].Rdn);
        if (this.CombatType2 == 16 | (this.CombatType == 13 | this.CombatType == 5) & !forAA && this.game.Data.SFTypeObj[type].SFTypeVar[index4] > 0)
          simpleList2.AddWeight(this.game.Data.SFTypeObj[type].SFTypeVar[index3], (int) Math.Round((double) this.game.Data.SFTypeObj[type].SFTypeVar[index4] * (double) num4 * 0.5));
        if (this.game.Data.SFTypeObj[type].SFTypeVar[index2] > 0)
          simpleList2.AddWeight(this.game.Data.SFTypeObj[type].SFTypeVar[index1], (int) Math.Round((double) ((float) this.game.Data.SFTypeObj[type].SFTypeVar[index2] * num3)));
      }
      int num6 = 10;
      int weight1 = simpleList1.FindWeight(10);
      int weight2 = simpleList2.FindWeight(10);
      float num7 = weight2 <= 0 ? 1f : Math.Min(1f, (float) weight1 / (float) weight2);
      num6 = 1;
      int num8 = simpleList1.FindWeight(1) + simpleList1.FindWeight(15);
      int num9 = simpleList2.FindWeight(1) + simpleList1.FindWeight(15);
      float num10 = num9 <= 0 ? 1f : Math.Min(1f, (float) num8 / (float) num9);
      if (this.CombatType == 3 | this.CombatType == 4)
        num10 = 1f;
      return (double) num7 >= 1.0 & (double) num10 >= 1.0;
    }

    public void InitSimplifiedSupply()
    {
      int ucounter = this.UCounter;
      for (int index1 = 0; index1 <= ucounter; ++index1)
      {
        float num1 = 0.0f;
        float num2 = 0.0f;
        float num3 = 0.0f;
        float num4 = 0.0f;
        int icounter1 = this.ICounter;
        for (int index2 = 0; index2 <= icounter1; ++index2)
        {
          if (this.IList[index2].IUlistNr == index1)
          {
            bool flag = false;
            if (this.IList[index2].IleftOutOfPartialAttack)
              flag = true;
            if (this.UList[index1].UDefIntercept)
              flag = true;
            if (this.CombatType == 3 | this.CombatType == 4)
              flag = true;
            if (this.InterceptFire & (double) this.game.Data.RuleVar[436] > 0.0)
              flag = true;
            int isfType = this.IList[index2].ISFType;
            int num5 = 10;
            if (this.UList[index1].Uattacker == 1 && (int) Math.Round(Math.Floor((double) this.UList[index1].UMaxApToSpend / 10.0)) < num5)
              num5 = (int) Math.Round(Math.Floor((double) this.UList[index1].UMaxApToSpend / 10.0));
            if (this.InterceptFire | this.CombatType == 11)
              num5 = 2;
            if (this.UList[index1].USupportInterceptFire)
              num5 = 2;
            if (this.game.Data.SFTypeObj[isfType].EndCombatRound > 0 & this.game.Data.SFTypeObj[isfType].EndCombatRound < num5)
              num5 = this.game.Data.SFTypeObj[isfType].EndCombatRound - this.game.Data.SFTypeObj[isfType].StartCombatRound;
            if (this.UList[index1].Uattacker == 0)
              num5 *= 2;
            if (this.UList[index1].Uattacker == 1)
              num5 = (int) Math.Round((double) num5 * 1.25);
            if (this.UList[index1].Uattacker == 1)
            {
              if (this.game.Data.SFTypeObj[isfType].FuelForAttack > 0 & !flag)
                num1 += (float) (this.game.Data.SFTypeObj[isfType].FuelForAttack * num5);
              if (this.game.Data.SFTypeObj[isfType].SupplyForAttack > 0)
                num2 += (float) this.game.Data.SFTypeObj[isfType].SupplyForAttack / 10f * (float) num5;
            }
            else
            {
              if (this.game.Data.SFTypeObj[isfType].FuelForAttackDef > 0 & !flag)
                num1 += (float) this.game.Data.SFTypeObj[isfType].FuelForAttackDef * (float) Math.Ceiling((double) num5 / 2.0);
              if (this.game.Data.SFTypeObj[isfType].SupplyForAttackDef > 0)
                num2 += (float) this.game.Data.SFTypeObj[isfType].SupplyForAttackDef / 10f * (float) num5;
            }
            int num6 = 10;
            if (this.UList[index1].Uattacker == 1)
            {
              if (this.game.Data.SFTypeObj[isfType].FuelForAttack > 0 & !flag)
                num3 += (float) (this.game.Data.SFTypeObj[isfType].FuelForAttack * num6);
              if (this.game.Data.SFTypeObj[isfType].SupplyForAttack > 0)
                num4 += (float) this.game.Data.SFTypeObj[isfType].SupplyForAttack / 10f * (float) num6;
            }
            else
            {
              if (this.game.Data.SFTypeObj[isfType].FuelForAttackDef > 0 & !flag)
                num3 += (float) (this.game.Data.SFTypeObj[isfType].FuelForAttackDef * num6);
              if (this.game.Data.SFTypeObj[isfType].SupplyForAttackDef > 0)
                num4 += (float) this.game.Data.SFTypeObj[isfType].SupplyForAttackDef / 10f * (float) num6;
            }
          }
        }
        if ((double) this.game.Data.RuleVar[436] > 0.0 & this.InterceptFire)
        {
          num2 = (float) (int) Math.Round(Math.Ceiling((double) num2 * (double) this.game.Data.RuleVar[436]));
          num4 = (float) (int) Math.Round(Math.Ceiling((double) num4 * (double) this.game.Data.RuleVar[436]));
        }
        if (this.UList[index1].Uattacker == 1)
        {
          if (this.game.Data.RegimeObj[this.AttackerRegime].AI)
          {
            num2 = (float) (int) Math.Round((double) num2 * (1.0 - (double) ((this.game.Data.RegimeObj[this.AttackerRegime].AIHelpCombat + 10) * 2) / 100.0));
            num4 = (float) (int) Math.Round((double) num4 * (1.0 - (double) ((this.game.Data.RegimeObj[this.AttackerRegime].AIHelpCombat + 10) * 2) / 100.0));
            num1 = (float) (int) Math.Round((double) num1 * (1.0 - (double) ((this.game.Data.RegimeObj[this.AttackerRegime].AIHelpCombat + 10) * 2) / 100.0));
            num3 = (float) (int) Math.Round((double) num3 * (1.0 - (double) ((this.game.Data.RegimeObj[this.AttackerRegime].AIHelpCombat + 10) * 2) / 100.0));
          }
        }
        else if (this.game.Data.RegimeObj[this.DefenderRegime].AI)
        {
          num2 = (float) (int) Math.Round((double) num2 * (1.0 - (double) ((this.game.Data.RegimeObj[this.DefenderRegime].AIHelpCombat + 10) * 2) / 100.0));
          num4 = (float) (int) Math.Round((double) num4 * (1.0 - (double) ((this.game.Data.RegimeObj[this.DefenderRegime].AIHelpCombat + 10) * 2) / 100.0));
          num1 = (float) (int) Math.Round((double) num1 * (1.0 - (double) ((this.game.Data.RegimeObj[this.DefenderRegime].AIHelpCombat + 10) * 2) / 100.0));
          num3 = (float) (int) Math.Round((double) num3 * (1.0 - (double) ((this.game.Data.RegimeObj[this.DefenderRegime].AIHelpCombat + 10) * 2) / 100.0));
        }
        float num7 = 1f;
        float num8 = 1f;
        if ((double) num1 > 0.0)
        {
          num7 = (float) this.game.Data.UnitObj[this.UList[index1].UNr].Fuel / num1;
          if ((double) num7 < (double) (this.game.Data.RuleVar[439] / 100f))
            num7 = (float) this.game.Data.UnitObj[this.UList[index1].UNr].Fuel / num3;
        }
        if ((double) num2 > 0.0)
        {
          num8 = (float) this.game.Data.UnitObj[this.UList[index1].UNr].Supply / num2;
          if ((double) num8 < (double) (this.game.Data.RuleVar[439] / 100f))
            num8 = (float) this.game.Data.UnitObj[this.UList[index1].UNr].Supply / num4;
        }
        if ((double) num7 <= 1.0)
          ;
        if ((double) num8 > 1.0)
          num8 = 1f;
        if ((double) num7 > 1.0)
          num7 = 1f;
        if ((double) this.game.Data.RuleVar[435] < 1.0)
          num7 = 0.0f;
        int icounter2 = this.ICounter;
        for (int index3 = 0; index3 <= icounter2; ++index3)
        {
          if (this.IList[index3].IUlistNr == index1)
          {
            if (this.IList[index3].IAttacker == 1)
            {
              this.IList[index3].ILisAmmoMod = num8 + this.game.Data.SFTypeObj[this.IList[index3].ISFType].OutOfSupplyAttack * (1f - num8);
              this.IList[index3].ILisFuelMod = num7 + this.game.Data.SFTypeObj[this.IList[index3].ISFType].OutOfFuelAttack * (1f - num7);
              if (this.game.Data.SFTypeObj[this.IList[index3].ISFType].SupplyForAttack < 1)
                this.IList[index3].ILisAmmoMod = 1f;
              if (this.game.Data.SFTypeObj[this.IList[index3].ISFType].FuelForAttack < 1)
                this.IList[index3].ILisFuelMod = 1f;
            }
            else if (!this.InterceptFire)
            {
              this.IList[index3].ILisAmmoMod = num8 + this.game.Data.SFTypeObj[this.IList[index3].ISFType].OutOfSupplyDefense * (1f - num8);
              this.IList[index3].ILisFuelMod = num7 + this.game.Data.SFTypeObj[this.IList[index3].ISFType].OutOfFuelDefense * (1f - num7);
              this.IList[index3].ILisAmmoMod = Math.Min(1f, 0.34f + this.IList[index3].ILisAmmoMod * 0.67f);
              this.IList[index3].ILisFuelMod = Math.Min(1f, 0.34f + this.IList[index3].ILisFuelMod * 0.67f);
              if (this.game.Data.SFTypeObj[this.IList[index3].ISFType].SupplyForAttackDef < 1)
                this.IList[index3].ILisAmmoMod = 1f;
              if (this.game.Data.SFTypeObj[this.IList[index3].ISFType].FuelForAttackDef < 1)
                this.IList[index3].ILisFuelMod = 1f;
            }
            else
            {
              this.IList[index3].ILisAmmoMod = 1f;
              this.IList[index3].ILisFuelMod = 1f;
            }
          }
        }
      }
    }

    public void CheckSeaAttackBreakOff()
    {
      if (this.CombatType != 2 || this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea)
        return;
      int num = 0;
      int icounter = this.ICounter;
      for (int index = 0; index <= icounter; ++index)
      {
        if (this.IList[index].IAttacker == 0 & this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 1)
          ++num;
      }
      if (num != 0)
        return;
      this.BattleEnded = 1;
    }

    public void DoRound()
    {
      this.CheckSeaAttackBreakOff();
      if (this.BattleEnded > 0)
        return;
      if (this.game.EditObj.CombatSim)
        VBMath.Randomize();
      ++this.CombatRound;
      if (this.CombatRound == 1)
        this.ThrowInitiative();
      if (this.CombatRound == 1)
        this.SortOnInitiative();
      int index1 = 0;
      int index2 = 1;
      string[,] matrx1 = new string[61, 6];
      int ucounter1 = this.UCounter;
      string txt;
      string str1;
      for (int fromy = 0; fromy <= ucounter1; ++fromy)
      {
        if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.UList[fromy].UNr].Regime, this.game.Data.Turn))
        {
          matrx1[1, index1] = "Move cost";
          matrx1[1, index2] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UApMoveCost));
          matrx1[2, index1] = "AP spend so far";
          matrx1[2, index2] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UApSpend));
          matrx1[3, index1] = "Max AP to spend";
          matrx1[3, index2] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UMaxApToSpend));
          matrx1[4, index1] = "Retreat started in round";
          matrx1[4, index2] = Strings.Trim(Conversion.Str((object) this.UList[fromy].URetreat));
          matrx1[5, index1] = "Broken";
          matrx1[5, index2] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UBreaks));
          matrx1[6, index1] = "Retreat";
          matrx1[6, index2] = !(this.UList[fromy].URetreatMode > 0 & this.UList[fromy].URetreatMode <= 2) ? (this.UList[fromy].URetreatMode != 5 ? (this.UList[fromy].URetreatMode <= 0 ? "-" : "Retreating") : "Panicking") : "Orderly/Out of AP";
          this.AddReport(2, "Stats at start of round", txt, fromy, this.CombatRound, matrx1);
          str1 = "";
        }
      }
      string[,] matrx2 = new string[61, 6];
      int icounter1 = this.ICounter;
      for (int index3 = 0; index3 <= icounter1; ++index3)
      {
        if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.IList[index3].IUnr].Regime, this.game.Data.Turn))
        {
          matrx2[1, index1] = "Readiness";
          matrx2[1, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IRdn));
          matrx2[2, index1] = "Morale";
          matrx2[2, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IMor));
          matrx2[3, index1] = "Experience";
          matrx2[3, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IXp));
          matrx2[4, index1] = "Entrenchment";
          matrx2[4, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IEntrench));
          matrx2[5, index1] = "AA out of hex";
          matrx2[5, index2] = Strings.Trim(Conversion.Str((object) (1 == this.IList[index3].IAA)));
          matrx2[6, index1] = "Breakthrough";
          matrx2[6, index2] = Strings.Trim(Conversion.Str((object) (this.IList[index3].IBreakTrough == 1)));
          matrx2[7, index1] = "Broken";
          matrx2[7, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IBroken));
          matrx2[8, index1] = "Capitulated";
          matrx2[8, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].ICapitulate));
          matrx2[9, index1] = "Killed";
          matrx2[9, index2] = Strings.Trim(Conversion.Str((object) (this.IList[index3].IKilled > 0)));
          matrx2[10, index1] = "Retreat completed";
          matrx2[10, index2] = Strings.Trim(Conversion.Str((object) (this.IList[index3].IRetreated > 0)));
          matrx2[11, index1] = "Retreat started in round";
          matrx2[11, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IRetreat));
          matrx2[12, index1] = "Retreat Mode";
          matrx2[12, index2] = this.IList[index3].IRetreatMode != 1 ? (this.IList[index3].IRetreatMode != 2 ? (this.IList[index3].IRetreatMode != 3 ? (this.IList[index3].IRetreatMode <= 0 ? "-" : "Retreating") : "Panicking") : "Orderly/Out of AP") : "Forced by combat result";
          matrx2[13, index1] = "Attack Count";
          matrx2[13, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].AttackCount));
          matrx2[14, index1] = "Attacked Count";
          matrx2[14, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].AttackedCount));
          matrx2[15, index1] = "Last Attack Done";
          matrx2[15, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].ILastAttackDone));
          matrx2[16, index1] = "Last Attacked";
          matrx2[16, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].ILastAttacked));
          matrx2[17, index1] = "Last Hit";
          matrx2[17, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].ILastHit));
          matrx2[18, index1] = "Last Targeted";
          matrx2[18, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].ILastTargeted));
          matrx2[19, index1] = "PreventPoints given";
          matrx2[19, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IPreventPointsGiven));
          matrx2[20, index1] = "PreventPoints used";
          matrx2[20, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IPreventPointsUsed));
          if ((double) this.game.Data.RuleVar[431] > 0.0)
          {
            matrx2[21, index1] = "Cover Points";
            matrx2[21, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IcoverPoints));
            matrx2[22, index1] = "Visible From Round";
            matrx2[22, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IvisibleFromRound));
          }
          if ((double) this.game.Data.RuleVar[493] > 0.0)
          {
            matrx2[23, index1] = "Left behind from partial att.";
            matrx2[23, index2] = Strings.Trim(Conversion.Str((object) this.IList[index3].IleftOutOfPartialAttack));
          }
          if (this.IList[index3].IAttacker == 1)
            index3 = index3;
          this.AddReport(2, "Stats at start of round", txt, index3 + 10000, this.CombatRound, matrx2);
        }
        str1 = "";
        string str2 = -(this.game.TempCombat.IList[index3].IBroken ? 1 : 0) <= 0 ? (this.game.TempCombat.IList[index3].IKilled <= 0 ? ((uint) this.game.TempCombat.IList[index3].IRetreated <= 0U ? (!(this.game.TempCombat.IList[index3].IRetreat > 0 & this.game.TempCombat.IList[index3].IRetreatMode == 3) ? (this.game.TempCombat.IList[index3].IRetreat <= 0 ? (this.game.TempCombat.IList[index3].IBreakTrough <= 0 ? "" : "!") : "RTR-ING") : "PANICK") : "RTR-ED") : (!this.game.TempCombat.IList[index3].ICapitulate ? "DEAD" : "CAPITULATE")) : "BROKEN";
        this.IList[index3].IHistoricState = (string[]) Utils.CopyArray((Array) this.IList[index3].IHistoricState, (Array) new string[this.CombatRound + 1]);
        this.game.TempCombat.IList[index3].IHistoricState[this.CombatRound] = str2;
      }
      this.AddDetail("COMBATROUND = " + Conversion.Str((object) this.CombatRound));
      if (this.customCombatObj.HasCustumCalls())
      {
        CustomCombatCalls customCombatObj = this.customCombatObj;
        CombatClass combatClass = this;
        ref CombatClass local = ref combatClass;
        GameClass game = this.game;
        int combatRound = this.CombatRound;
        customCombatObj.StartCombatRound(ref local, game, combatRound);
      }
      this.ClearDetail();
      if (this.CombatRound == 1)
        this.CheckBreakthrough();
      this.CheckCapitulation(false);
      this.SetConcentricBonus();
      this.DoSteps();
      this.CheckAutoDestroy();
      this.PlayRelevantSound();
      this.CheckBreakthrough();
      this.CheckSafeRetreat();
      if (this.game.Data.Product == 6)
      {
        this.CheckPanicUnitRetreat();
        this.CheckCapitulation(true);
        this.CheckOrderlyUnitRetreat();
        this.CheckBreak();
      }
      else
      {
        this.CheckOrderlyUnitRetreat();
        this.CheckPanicUnitRetreat();
        this.CheckBreak();
        this.CheckCapitulation(true);
      }
      this.CheckOutOfAP();
      this.CheckVictory();
      this.CombatReconEndOfRound();
      this.FinishStats();
      int icounter2 = this.ICounter;
      for (int index4 = 0; index4 <= icounter2; ++index4)
      {
        if (this.IList[index4].AttackCount > 0)
        {
          Individual[] ilist = this.IList;
          Individual[] individualArray = ilist;
          int index5 = index4;
          int index6 = index5;
          individualArray[index6].RoundsOfAttack = ilist[index5].RoundsOfAttack + 1;
        }
        if (this.IList[index4].AttackCountAir > 0)
        {
          Individual[] ilist = this.IList;
          Individual[] individualArray = ilist;
          int index7 = index4;
          int index8 = index7;
          individualArray[index8].RoundsOfAirAttack = ilist[index7].RoundsOfAirAttack + 1;
        }
        if (this.IList[index4].AttackCountLand > 0)
        {
          Individual[] ilist = this.IList;
          Individual[] individualArray = ilist;
          int index9 = index4;
          int index10 = index9;
          individualArray[index10].RoundsOfLandAttack = ilist[index9].RoundsOfLandAttack + 1;
        }
      }
      int index11 = 0;
      int index12 = 1;
      string[,] matrx3 = new string[61, 6];
      int icounter3 = this.ICounter;
      for (int index13 = 0; index13 <= icounter3; ++index13)
      {
        if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.IList[index13].IUnr].Regime, this.game.Data.Turn))
        {
          matrx3[1, index11] = "Readiness";
          matrx3[1, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IRdn));
          matrx3[2, index11] = "Morale";
          matrx3[2, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IMor));
          matrx3[3, index11] = "Experience";
          matrx3[3, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IXp));
          matrx3[4, index11] = "Entrenchment";
          matrx3[4, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IEntrench));
          matrx3[5, index11] = "AA out of hex";
          matrx3[5, index12] = Strings.Trim(Conversion.Str((object) (1 == this.IList[index13].IAA)));
          matrx3[6, index11] = "Breakthrough";
          matrx3[6, index12] = Strings.Trim(Conversion.Str((object) (this.IList[index13].IBreakTrough == 1)));
          matrx3[7, index11] = "Broken";
          matrx3[7, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IBroken));
          matrx3[8, index11] = "Capitulated";
          matrx3[8, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].ICapitulate));
          matrx3[9, index11] = "Killed";
          matrx3[9, index12] = Strings.Trim(Conversion.Str((object) (this.IList[index13].IKilled > 0)));
          matrx3[10, index11] = "Retreat completed";
          matrx3[10, index12] = Strings.Trim(Conversion.Str((object) (this.IList[index13].IRetreated > 0)));
          matrx3[11, index11] = "Retreat started in round";
          matrx3[11, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IRetreat));
          matrx3[12, index11] = "Retreat Mode";
          matrx3[12, index12] = this.IList[index13].IRetreatMode > 2 ? (this.IList[index13].IRetreatMode != 3 ? (this.IList[index13].IRetreatMode <= 0 ? "-" : "Retreating") : "Panicking") : "Orderly/Out of AP";
          matrx3[13, index11] = "Attack Count";
          matrx3[13, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].AttackCount));
          matrx3[14, index11] = "Attacked Count";
          matrx3[14, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].AttackedCount));
          matrx3[15, index11] = "Last Attack Done";
          matrx3[15, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].ILastAttackDone));
          matrx3[16, index11] = "Last Attacked";
          matrx3[16, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].ILastAttacked));
          matrx3[17, index11] = "Last Hit";
          matrx3[17, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].ILastHit));
          matrx3[18, index11] = "Last Targeted";
          matrx3[18, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].ILastTargeted));
          matrx3[19, index11] = "PreventPoints given";
          matrx3[19, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IPreventPointsGiven));
          matrx3[20, index11] = "PreventPoints used";
          matrx3[20, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IPreventPointsUsed));
          if ((double) this.game.Data.RuleVar[431] > 0.0)
          {
            matrx3[21, index11] = "Cover Points";
            matrx3[21, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IcoverPoints));
            matrx3[22, index11] = "Visible From Round";
            matrx3[22, index12] = Strings.Trim(Conversion.Str((object) this.IList[index13].IvisibleFromRound));
          }
          if (index13 > 44)
            index13 = index13;
          this.AddReport(2, "Stats at end of round", txt, index13 + 10000, this.CombatRound, matrx3);
        }
        str1 = "";
        string str3 = -(this.game.TempCombat.IList[index13].IBroken ? 1 : 0) <= 0 ? (this.game.TempCombat.IList[index13].IKilled <= 0 ? ((uint) this.game.TempCombat.IList[index13].IRetreated <= 0U ? (!(this.game.TempCombat.IList[index13].IRetreat > 0 & this.game.TempCombat.IList[index13].IRetreatMode == 3) ? (this.game.TempCombat.IList[index13].IRetreat <= 0 ? (this.game.TempCombat.IList[index13].IBreakTrough <= 0 ? "" : "!") : "RTR-ING") : "PANICKING") : "RTR-ED") : (!this.game.TempCombat.IList[index13].ICapitulate ? "DEAD" : "CAPITULATE")) : "BROKEN";
        this.IList[index13].IHistoricState2 = (string[]) Utils.CopyArray((Array) this.IList[index13].IHistoricState2, (Array) new string[this.CombatRound + 1]);
        this.game.TempCombat.IList[index13].IHistoricState2[this.CombatRound] = str3;
      }
      string[,] matrx4 = new string[61, 6];
      int ucounter2 = this.UCounter;
      for (int fromy = 0; fromy <= ucounter2; ++fromy)
      {
        if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.UList[fromy].UNr].Regime, this.game.Data.Turn))
        {
          matrx4[1, index11] = "Move cost";
          matrx4[1, index12] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UApMoveCost));
          matrx4[2, index11] = "AP spend so far";
          matrx4[2, index12] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UApSpend));
          matrx4[3, index11] = "Max AP to spend";
          matrx4[3, index12] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UMaxApToSpend));
          matrx4[4, index11] = "Retreat started in round";
          matrx4[4, index12] = Strings.Trim(Conversion.Str((object) this.UList[fromy].URetreat));
          matrx4[5, index11] = "Broken";
          matrx4[5, index12] = Strings.Trim(Conversion.Str((object) this.UList[fromy].UBreaks));
          matrx4[6, index11] = "Retreat";
          matrx4[6, index12] = !(this.UList[fromy].URetreatMode > 0 & this.UList[fromy].URetreatMode <= 2) ? (this.UList[fromy].URetreatMode != 5 ? (this.UList[fromy].URetreatMode <= 0 ? "-" : "Retreating") : "Panicking") : "Orderly/Out of AP";
          this.AddReport(2, "Stats at end of round", txt, fromy, this.CombatRound, matrx4);
          str1 = "";
        }
      }
    }

    public void PlayRelevantSound()
    {
      if (this.previewMode || this.dontUseSfx || this.ICounter < 0)
        return;
      int num1 = 0;
      int icounter1 = this.ICounter;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IDammageDone > 0)
        {
          int isfType = this.IList[index].ISFType;
          if (Strings.Len(this.game.Data.SFTypeObj[isfType].BattleWAV) > 0)
            num1 += this.game.Data.SFTypeObj[isfType].PowerPts;
        }
      }
      int index1 = -1;
      int num2 = 0;
      int num3 = (int) Math.Round((double) VBMath.Rnd() * (double) this.ICounter + 1.0);
      while (index1 == -1 & num1 > 0)
      {
        ++num2;
        int num4 = num3;
        int icounter2 = this.ICounter;
        for (int index2 = num4; index2 <= icounter2; ++index2)
        {
          if (this.IList[index2].IDammageDone > 0 && this.IList[index2].IAttacker == 1 & (this.CombatRound + 1) % 2 == 0 | this.IList[index2].IAttacker == 0 & (this.CombatRound + 1) % 2 > 0)
          {
            int isfType = this.IList[index2].ISFType;
            if (Strings.Len(this.game.Data.SFTypeObj[isfType].BattleWAV) > 0 && (double) this.game.Data.SFTypeObj[isfType].PowerPts > (double) VBMath.Rnd() * (double) num1)
            {
              index1 = isfType;
              break;
            }
          }
        }
        num3 = 0;
        if (num2 > 999)
          index1 = -2;
      }
      if (index1 < 0)
      {
        int icounter3 = this.ICounter;
        for (int index3 = 0; index3 <= icounter3; ++index3)
        {
          if (this.IList[index3].IAttacker == 1 & (this.CombatRound + 1) % 2 == 0)
          {
            int isfType = this.IList[index3].ISFType;
            if (Strings.Len(this.game.Data.SFTypeObj[isfType].BattleWAV) > 0)
              num1 += this.game.Data.SFTypeObj[isfType].PowerPts;
          }
        }
        index1 = -1;
        int num5 = 0;
        int num6 = (int) Math.Round((double) VBMath.Rnd() * (double) this.ICounter + 1.0);
        while (index1 == -1)
        {
          ++num5;
          int num7 = num6;
          int icounter4 = this.ICounter;
          for (int index4 = num7; index4 <= icounter4; ++index4)
          {
            if (this.IList[index4].IAttacker == 1 & (this.CombatRound + 1) % 2 == 0)
            {
              int isfType = this.IList[index4].ISFType;
              if (Strings.Len(this.game.Data.SFTypeObj[isfType].BattleWAV) > 0 && (double) this.game.Data.SFTypeObj[isfType].PowerPts > (double) VBMath.Rnd() * (double) num1)
              {
                index1 = isfType;
                break;
              }
            }
          }
          num6 = 0;
          if (num5 > 999)
            index1 = -2;
        }
        if (this.CombatType == 13)
          index1 = -1;
      }
      if (index1 <= -1 || !(Strings.Len(this.game.Data.SFTypeObj[index1].BattleWAV) > 0 & !this.dontUseSfx) || !(!this.game.AIRunning & !this.game.Data.RegimeObj[this.game.Data.Turn].AI))
        return;
      SoundMod.PlayAWave(this.game.AppPath + "sound/" + this.game.Data.SFTypeObj[index1].BattleWAV, ref this.game.EditObj);
    }

    public void CombatReconEndOfRound()
    {
      if ((double) this.game.Data.RuleVar[431] < 1.0)
        return;
      int num1 = 0;
      if ((this.CombatType == 1 | this.CombatType == 10 | this.CombatType == 11 | this.CombatType == 13 | this.CombatType == 5) & this.CombatRound > 0)
      {
        if (this.AttackerRegime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].MaxRecon > this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].get_ReconPts(this.AttackerRegime))
          this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].set_ReconPts(this.AttackerRegime, this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].MaxRecon);
        HexClass[,] hexObj = this.game.Data.MapObj[0].HexObj;
        HexClass[,] hexClassArray = hexObj;
        int targetX = this.TargetX;
        int index1 = targetX;
        int targetY = this.TargetY;
        int index2 = targetY;
        HexClass hexClass = hexClassArray[index1, index2];
        int attackerRegime = this.AttackerRegime;
        int Index = attackerRegime;
        int num2 = hexObj[targetX, targetY].get_ReconPts(attackerRegime) + this.initialRecon;
        hexClass.set_ReconPts(Index, num2);
        if (1 > this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].get_ReconPts(this.AttackerRegime))
          this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].set_ReconPts(this.AttackerRegime, 1);
        if (this.AttackerRegime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].get_ReconPts(this.AttackerRegime) > this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].MaxRecon)
          this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].MaxRecon = this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].get_ReconPts(this.AttackerRegime);
      }
      int icounter = this.ICounter;
      for (int inr = 0; inr <= icounter; ++inr)
      {
        if (this.IList[inr].IAttacker == 0)
          num1 = num1;
        if ((double) this.GetEffectiveReconOnHexOfTargettedIndividual(inr) >= (double) this.IList[inr].IcoverPoints)
        {
          if (this.IList[inr].IUnr == 202)
            inr = inr;
          if (this.IList[inr].IvisibleFromRound > this.CombatRound)
          {
            this.IList[inr].IvisibleFromRound = this.CombatRound;
            if (!this.previewMode)
              this.UList[this.IList[inr].IUlistNr].USetToSpottedAtEnd = true;
          }
          else
            this.UList[this.IList[inr].IUlistNr].USetToSpottedAtEnd = true;
        }
      }
    }

    public void FinishStats()
    {
      this.AddDetail("");
      this.AddDetail("DEFENDER INDIVIDUALS:");
      int icounter1 = this.ICounter;
      for (int Number = 0; Number <= icounter1; ++Number)
      {
        if (this.IList[Number].IAttacker == 0 && this.IList[Number].IRetreated == 0 & this.IList[Number].IKilled == 0)
          this.AddDetail(Conversion.Str((object) Number) + ") " + this.game.Data.SFTypeObj[this.IList[Number].ISFType].Name + " Breakthrough = " + Conversion.Str((object) this.IList[Number].IBreakTrough) + ", AttackCount = " + Conversion.Str((object) this.IList[Number].AttackCount) + ", Attacked = " + Conversion.Str((object) this.IList[Number].AttackedCount) + ", LastHit = " + Conversion.Str((object) this.IList[Number].ILastHit) + ", LastTargeted = " + Conversion.Str((object) this.IList[Number].ILastTargeted));
      }
      this.AddDetail("");
      this.AddDetail("ATTACKER INDIVIDUALS:");
      int icounter2 = this.ICounter;
      for (int Number = 0; Number <= icounter2; ++Number)
      {
        if (this.IList[Number].IAttacker == 1 && this.IList[Number].IRetreated == 0 & this.IList[Number].IKilled == 0)
          this.AddDetail(Conversion.Str((object) Number) + ") " + this.game.Data.SFTypeObj[this.IList[Number].ISFType].Name + " Breakthrough = " + Conversion.Str((object) this.IList[Number].IBreakTrough) + ", AttackCount = " + Conversion.Str((object) this.IList[Number].AttackCount) + ", Attacked = " + Conversion.Str((object) this.IList[Number].AttackedCount) + ", LastHit = " + Conversion.Str((object) this.IList[Number].ILastHit) + ", LastTargeted = " + Conversion.Str((object) this.IList[Number].ILastTargeted));
      }
      this.AddDetail("");
    }

    public void DoBattle()
    {
      while (this.BattleEnded == 0)
        this.DoRound();
    }

    public void CheckAutoDestroy()
    {
      int icounter = this.ICounter;
      for (int index = 0; index <= icounter; ++index)
      {
        if (this.IList[index].AttackCount > 0 | this.game.Data.SFTypeObj[this.IList[index].ISFType].AntiStrucPts > 0 && this.IList[index].IAttacker == 1 && this.game.Data.SFTypeObj[this.IList[index].ISFType].AutoDestroy && this.CombatRound >= 1)
          this.IList[index].IKilled = this.CombatRound;
        if (this.IList[index].AttackCount > 0 && this.IList[index].IAttacker == 0 && this.game.Data.SFTypeObj[this.IList[index].ISFType].AutoDestroy2 && this.CombatRound >= 1)
          this.IList[index].IKilled = this.CombatRound;
      }
    }

    public string GetPercentChange(float newval, float oldval)
    {
      if ((double) newval > (double) oldval)
        return "+" + Strings.Trim(Conversion.Str((object) (int) Math.Round((double) newval * 100.0 / (double) oldval - 100.0))) + "%";
      return (double) newval == (double) oldval ? "0%" : "-" + Strings.Trim(Conversion.Str((object) (int) Math.Round(100.0 - (double) newval * 100.0 / (double) oldval))) + "%";
    }

    public int GetEffectiveReconOnHexOfTargettedIndividual(int inr)
    {
      int x = this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].X;
      int y = this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].Y;
      int Index;
      if (this.IList[inr].IAttacker == 1)
      {
        Index = this.DefenderRegime;
        if (this.CombatType == 1 | this.CombatType == 11 || this.CombatType == 2 || this.IList[inr].IleftOutOfPartialAttack & this.IList[inr].ILastAttackDone > 0)
          return 9999;
      }
      else
        Index = this.AttackerRegime;
      if (Index == -1)
        return 0;
      int rawRecon = this.game.Data.MapObj[0].HexObj[x, y].get_ReconPts(Index);
      if ((double) this.game.Data.RuleVar[419] > 0.0)
        rawRecon = this.game.HandyFunctionsObj.GetEffectiveRecon(rawRecon);
      return rawRecon;
    }

    public int GetUnmodifiedReconOnHexOfTargettedIndividual(int inr)
    {
      int x = this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].X;
      int y = this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].Y;
      int Index = this.IList[inr].IAttacker != 1 ? this.AttackerRegime : this.DefenderRegime;
      return Index == -1 ? 0 : this.game.Data.MapObj[0].HexObj[x, y].get_ReconPts(Index);
    }

    public int GetIndividualHide(int inr)
    {
      int individualHide = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].X, this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].Y].LandscapeType].HidePts + this.game.Data.SFTypeObj[this.IList[inr].ISFType].HidePts;
      if ((double) this.game.Data.RuleVar[419] > 0.0)
      {
        int num1 = individualHide;
        int unr = this.UList[this.IList[inr].IUlistNr].UNr;
        int num2 = num1;
        int averageXp = this.game.HandyFunctionsObj.GetAverageXp(unr);
        int num3 = (double) averageXp <= (double) this.game.Data.RuleVar[423] ? (int) Math.Round(Math.Ceiling(0.6 * (double) num2)) + (int) Math.Round(Math.Floor(0.4 * (double) num2 * (double) averageXp / (double) this.game.Data.RuleVar[423])) : num2 + (int) Math.Round(Math.Floor(0.4 * (double) num2 * (double) Math.Min(1f, (float) (((double) averageXp - (double) this.game.Data.RuleVar[423]) / (80.0 - (double) this.game.Data.RuleVar[423])))));
        float num4 = (float) this.game.HandyFunctionsObj.GetHexStackPts(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0) / this.game.Data.RuleVar[30];
        float num5 = 1f;
        if ((double) num4 < 0.333)
          num5 = (float) (1.39999997615814 - 0.4 * ((double) num4 / 0.333));
        else if ((double) num4 > 1.0)
        {
          num5 = (float) (1.0 - 0.5 * ((double) num4 - 1.0));
          if ((double) num5 < 0.0)
            num5 = 0.0f;
        }
        individualHide = (int) Math.Round((double) ((float) (int) Math.Round((double) ((float) num3 * num5)) + this.game.Data.RuleVar[9]));
        if (this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].Spotted)
          individualHide = (int) Math.Round((double) individualHide / 2.0);
        if (this.game.Data.UnitObj[this.UList[this.IList[inr].IUlistNr].UNr].Identified)
          individualHide = (int) Math.Round((double) individualHide / 2.0);
      }
      return individualHide;
    }

    public int GetMaxAttacked(int defnr, int attnr)
    {
      if (this.game.Data.Product != 6)
        return this.game.Data.SFTypeObj[this.IList[defnr].ISFType].MaxAttacked;
      int maxAttacked = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].MaxAttacked;
      if ((double) this.ConcentricBonus > 1.0 & this.IList[defnr].IAttacker == 0)
        maxAttacked = (int) Math.Round((double) ((float) maxAttacked * this.ConcentricBonus));
      if (this.IList[defnr].IRdn < 100)
        maxAttacked = (int) Math.Round((double) maxAttacked * Math.Min(3.0, 100.0 / (double) Math.Max(1, this.IList[defnr].IRdn)));
      if (this.IList[defnr].IRetreat > 0)
        maxAttacked *= 2;
      if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0 | this.game.Data.SFTypeObj[this.IList[attnr].ISFType].directRange > 0)
        maxAttacked *= 3;
      return maxAttacked;
    }

    public void DoActualAttack(int attnr, int defnr, bool counterattack = false)
    {
      string[,] matrx = new string[61, 6];
      bool flag1 = !(!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime, this.game.Data.Turn));
      bool flag2 = !(!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime, this.game.Data.Turn));
      if (this.game.Data.FOWOn && this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[431] > 0.0)
      {
        if ((double) this.IList[defnr].IcoverPoints <= (double) this.GetEffectiveReconOnHexOfTargettedIndividual(defnr))
          flag1 = false;
        if ((double) this.IList[attnr].IcoverPoints <= (double) this.GetEffectiveReconOnHexOfTargettedIndividual(attnr))
          flag2 = false;
      }
      bool flag3 = flag1;
      bool flag4 = flag2;
      if (this.previewMode)
      {
        flag1 = false;
        flag2 = false;
        if (this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime == this.game.Data.Turn)
          flag4 = true;
        else
          flag3 = true;
      }
      string str1;
      if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AutoDestroy & this.IList[attnr].IAttacker == 1 && this.CombatRound >= 2 & this.IList[attnr].IKilled == 0)
      {
        this.IList[attnr].IKilled = this.CombatRound;
        str1 += "Attacker auto-destructs.";
      }
      else if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AutoDestroy2 & this.IList[attnr].IAttacker == 0 && this.CombatRound >= 2 & this.IList[attnr].IKilled == 0)
      {
        this.IList[attnr].IKilled = this.CombatRound;
        str1 += "Attacker auto-destructs.";
      }
      else
      {
        int unitGroup1 = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].UnitGroup;
        this.AddDetail((this.IList[attnr].IAttacker != 1 ? "DEFENDER: " : "ATTACKER: ") + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " attacks " + this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name);
        float num1;
        if (this.IList[attnr].IAttacker == 1)
        {
          if (this.CombatType == 3 | this.CombatType == 4)
          {
            if ((double) this.game.Data.RuleVar[419] > 0.0)
            {
              num1 = (float) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPower[unitGroup1];
              if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].directRange > 0)
              {
                if (this.IList[attnr].IAttacker == 1 && this.IList[attnr].IdirectFire)
                  num1 = (float) Math.Max(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPower[unitGroup1], this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPowerDef[unitGroup1]);
                if (this.IList[attnr].IAttacker == 0 && !Information.IsNothing((object) this.IList[attnr].IdirectFireDef) && this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
                  num1 = (float) Math.Max(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPower[unitGroup1], this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPowerDef[unitGroup1]);
              }
            }
            else
              num1 = Conversions.ToSingle(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackArt[unitGroup1]);
          }
          else
            num1 = (float) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPower[unitGroup1];
        }
        else
          num1 = (float) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPowerDef[unitGroup1];
        float Number1 = this.IList[defnr].IAttacker != 1 ? (float) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].HitPointsDef[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup] : (this.game.Data.Product < 6 ? (float) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].HitPoints[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup] : (counterattack ? (float) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].HitPointsDef[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup] : (float) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].HitPoints[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup]));
        int landscapeType1 = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].LandscapeType;
        string s1 = "BEFORE MOD: Attval=" + Conversion.Str((object) num1) + ", DefVal= " + Conversion.Str((object) Number1);
        string str2 = "attack=" + Strings.Trim(Conversion.Str((object) num1)) + " VS defense = " + Strings.Trim(Conversion.Str((object) Number1));
        int num2;
        int index1 = num2 + 1;
        matrx[index1, 0] = "Start Att Score";
        matrx[index1, 1] = "";
        matrx[index1, 2] = Strings.Trim(Conversion.Str((object) num1));
        int num3;
        int index2 = num3 + 1;
        matrx[index2, 3] = "Start Def Score";
        matrx[index2, 4] = "";
        matrx[index2, 5] = Strings.Trim(Conversion.Str((object) Number1));
        this.AddDetail(s1);
        float powerPts1 = (float) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].PowerPts;
        float powerPts2 = (float) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].PowerPts;
        int index3;
        if ((double) this.game.Data.RuleVar[407] < 1.0 & (double) this.game.Data.RuleVar[434] < 1.0)
        {
          if ((double) this.game.Data.RuleVar[435] > 0.0)
          {
            if (((!this.game.EditObj.CombatSim ? 1 : 0) & 0) != 0)
            {
              ++index1;
              matrx[index1, 0] = "Fuel";
              float oldval = num1;
              this.IList[attnr].IAttackMod = 1f;
              if (this.IList[attnr].AttackCount == 0 && this.IList[defnr].AttackedCount < this.GetMaxAttacked(defnr, attnr))
              {
                this.IList[attnr].IAttackMod = 1f;
                index3 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelForAttack;
                int fuelRegimeVar1 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelRegimeVar;
                int num4;
                if (index3 > 0)
                {
                  if (this.IList[attnr].IAttacker == 0)
                  {
                    if (!(this.CombatType == 3 | this.CombatType == 4) && !(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0 & (this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13)))
                    {
                      index3 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelForAttackDef;
                      num4 = this.DefenderRegime;
                      if (this.game.Data.UnitObj[this.IList[attnr].IUnr].Fuel >= index3)
                      {
                        UnitClass[] unitObj1 = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray1 = unitObj1;
                        int iunr1 = this.IList[attnr].IUnr;
                        int index4 = iunr1;
                        unitClassArray1[index4].Fuel = unitObj1[iunr1].Fuel - index3;
                        UnitClass[] unitObj2 = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray2 = unitObj2;
                        int iunr2 = this.IList[attnr].IUnr;
                        int index5 = iunr2;
                        unitClassArray2[index5].FuelUsedDef = unitObj2[iunr2].FuelUsedDef + index3;
                        this.AddDetail("Defender: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " consumes " + Conversion.Str((object) index3) + " " + this.game.Data.RegimeSlotName[fuelRegimeVar1]);
                      }
                      else
                      {
                        this.AddDetail("Defender: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " out of fuel!!!");
                        this.IList[attnr].IAttackMod = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].OutOfFuelDefense;
                      }
                    }
                  }
                  else
                  {
                    index3 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelForAttack;
                    int fuelRegimeVar2 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelRegimeVar;
                    num4 = this.AttackerRegime;
                    if (this.game.Data.UnitObj[this.IList[attnr].IUnr].Fuel >= index3)
                    {
                      UnitClass[] unitObj3 = this.game.Data.UnitObj;
                      UnitClass[] unitClassArray3 = unitObj3;
                      int iunr3 = this.IList[attnr].IUnr;
                      int index6 = iunr3;
                      unitClassArray3[index6].Fuel = unitObj3[iunr3].Fuel - index3;
                      UnitClass[] unitObj4 = this.game.Data.UnitObj;
                      UnitClass[] unitClassArray4 = unitObj4;
                      int iunr4 = this.IList[attnr].IUnr;
                      int index7 = iunr4;
                      unitClassArray4[index7].FuelUsedAtt = unitObj4[iunr4].FuelUsedAtt + index3;
                      this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " consumes " + Conversion.Str((object) index3) + " " + this.game.Data.RegimeSlotName[fuelRegimeVar2]);
                    }
                    else
                    {
                      this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " out of fuel!!!");
                      this.IList[attnr].IAttackMod = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].OutOfFuelAttack;
                    }
                  }
                }
              }
              num1 *= this.IList[attnr].IAttackMod;
              this.AddDetail("Attval after fuel modifier: " + Conversion.Str((object) num1));
              matrx[index1, 1] = this.GetPercentChange(num1, oldval);
              matrx[index1, 2] = Conversions.ToString(num1);
              if (flag1)
              {
                matrx[index1, 1] = "?";
                matrx[index1, 2] = "?";
              }
            }
          }
          else if (!this.game.EditObj.CombatSim)
          {
            ++index1;
            matrx[index1, 0] = "Fuel";
            float oldval = num1;
            this.IList[attnr].IAttackMod = 1f;
            if (this.IList[attnr].AttackCount == 0 && this.IList[defnr].AttackedCount < this.GetMaxAttacked(defnr, attnr))
            {
              this.IList[attnr].IAttackMod = 1f;
              index3 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelForAttack;
              int currentSlot1 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelRegimeVar;
              if ((double) this.game.Data.RuleVar[949] > 0.0)
                currentSlot1 = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot1, this.game.Data.UnitObj[this.IList[attnr].IUnr].RealX(ref this.game), this.game.Data.UnitObj[this.IList[attnr].IUnr].RealY(ref this.game));
              int index8 = currentSlot1;
              if (index8 > -1 & index3 > 0)
              {
                if (this.IList[attnr].IAttacker == 0)
                {
                  if (!(this.CombatType == 3 | this.CombatType == 4) && !(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0 & (this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13)))
                  {
                    index3 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelForAttackDef;
                    int defenderRegime = this.DefenderRegime;
                    if (this.game.Data.RegimeObj[defenderRegime].RegimeSlot[index8] >= index3)
                    {
                      int[] regimeSlot = this.game.Data.RegimeObj[defenderRegime].RegimeSlot;
                      int[] numArray = regimeSlot;
                      int index9 = index8;
                      int index10 = index9;
                      int num5 = regimeSlot[index9] - index3;
                      numArray[index10] = num5;
                      UnitClass[] unitObj = this.game.Data.UnitObj;
                      UnitClass[] unitClassArray = unitObj;
                      int iunr = this.IList[attnr].IUnr;
                      int index11 = iunr;
                      unitClassArray[index11].FuelUsedDef = unitObj[iunr].FuelUsedDef + index3;
                      this.AddDetail("Defender: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " consumes " + Conversion.Str((object) index3) + " " + this.game.Data.RegimeSlotName[index8]);
                    }
                    else
                    {
                      this.AddDetail("Defender: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " out of fuel!!!");
                      this.IList[attnr].IAttackMod = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].OutOfFuelDefense;
                    }
                  }
                }
                else
                {
                  index3 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelForAttack;
                  int currentSlot2 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FuelRegimeVar;
                  if ((double) this.game.Data.RuleVar[949] > 0.0)
                    currentSlot2 = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot2, this.game.Data.UnitObj[this.IList[attnr].IUnr].RealX(ref this.game), this.game.Data.UnitObj[this.IList[attnr].IUnr].RealY(ref this.game));
                  int index12 = currentSlot2;
                  int attackerRegime = this.AttackerRegime;
                  if (this.game.Data.RegimeObj[attackerRegime].RegimeSlot[index12] >= index3)
                  {
                    int[] regimeSlot = this.game.Data.RegimeObj[attackerRegime].RegimeSlot;
                    int[] numArray = regimeSlot;
                    int index13 = index12;
                    int index14 = index13;
                    int num6 = regimeSlot[index13] - index3;
                    numArray[index14] = num6;
                    UnitClass[] unitObj = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray = unitObj;
                    int iunr = this.IList[attnr].IUnr;
                    int index15 = iunr;
                    unitClassArray[index15].FuelUsedAtt = unitObj[iunr].FuelUsedAtt + index3;
                    this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " consumes " + Conversion.Str((object) index3) + " " + this.game.Data.RegimeSlotName[index12]);
                  }
                  else
                  {
                    this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + " out of fuel!!!");
                    this.IList[attnr].IAttackMod = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].OutOfFuelAttack;
                  }
                }
              }
            }
            num1 *= this.IList[attnr].IAttackMod;
            this.AddDetail("Attval after fuel modifier: " + Conversion.Str((object) num1));
            matrx[index1, 1] = this.GetPercentChange(num1, oldval);
            matrx[index1, 2] = Conversions.ToString(num1);
            if (flag1)
            {
              matrx[index1, 1] = "?";
              matrx[index1, 2] = "?";
            }
          }
        }
        if (this.IList[attnr].AttackCount + this.IList[attnr].ICounterAttacks == 0)
        {
          index3 = this.IList[attnr].ISFType;
          if (this.game.Data.SFTypeObj[index3].StockpileUsedPerRound > 0)
          {
            if (this.game.Data.UnitObj[this.IList[attnr].IUnr].StockpileCurrent >= this.game.Data.SFTypeObj[index3].StockpileUsedPerRound)
            {
              this.IList[attnr].Istockpile = true;
              UnitClass[] unitObj = this.game.Data.UnitObj;
              UnitClass[] unitClassArray = unitObj;
              int iunr = this.IList[attnr].IUnr;
              int index16 = iunr;
              unitClassArray[index16].StockpileCurrent = unitObj[iunr].StockpileCurrent - this.game.Data.SFTypeObj[index3].StockpileUsedPerRound;
            }
            else
              this.IList[attnr].Istockpile = false;
          }
          else
            this.IList[attnr].Istockpile = true;
        }
        if (this.game.Data.SFTypeObj[index3].StockpileUsedPerRound > 0 && !this.IList[attnr].Istockpile)
        {
          ++index1;
          matrx[index1, 0] = "Stockpile depl.";
          float oldval = num1;
          num1 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].StockpileDepletedMod;
          this.AddDetail("Attval after stockpile depleted modifier: " + Conversion.Str((object) num1));
          matrx[index1, 1] = this.GetPercentChange(num1, oldval);
          matrx[index1, 2] = Conversions.ToString(num1);
          if (flag1)
          {
            matrx[index1, 1] = "?";
            matrx[index1, 2] = "?";
          }
        }
        if (this.game.Data.UncertaintyOn & !this.previewMode)
        {
          ++index1;
          matrx[index1, 0] = "Uncertainty effect";
          float oldval = num1;
          int udice1 = this.UList[this.IList[attnr].IUlistNr].UDice;
          int udice2 = this.UList[this.IList[defnr].IUlistNr].UDice;
          int num7;
          int num8;
          if (this.IList[attnr].IAttacker == 1)
          {
            num7 = udice1 + this.AttackerDice;
            num8 = udice2 + this.DefenderDice;
          }
          else
          {
            num7 = udice1 + this.DefenderDice;
            num8 = udice2 + this.AttackerDice;
          }
          int num9 = num7 - num8;
          if (num9 > 0)
            num1 *= (float) (1.0 + (double) num9 / 10.0);
          this.AddDetail("Attval after uncertainty effect: " + Conversion.Str((object) num1));
          matrx[index1, 1] = this.GetPercentChange(num1, oldval);
          matrx[index1, 2] = Conversions.ToString(num1);
          if (flag1)
          {
            matrx[index1, 1] = "?";
            matrx[index1, 2] = "?";
          }
        }
        if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[470] > 0.0)
        {
          bool flag5 = false;
          if (this.CombatType == 3 | this.CombatType == 4)
            flag5 = true;
          if (this.InterceptFire)
            flag5 = true;
          if (this.UList[this.IList[attnr].IUlistNr].USupportInterceptFire)
            flag5 = true;
          ++index1;
          matrx[index1, 0] = "Night penalty";
          float oldval = num1;
          if (!flag5 && (double) this.game.Data.RuleVar[470] > 0.0)
          {
            float num10 = 0.2f + (float) this.IList[attnr].IXp / 150f;
            if ((double) num10 < 0.25)
              num10 = 0.25f;
            if ((double) num10 > 0.66)
              num10 = 0.66f;
            num1 *= num10;
          }
          this.AddDetail("Attval after Night penalty: " + Conversion.Str((object) num1));
          matrx[index1, 1] = this.GetPercentChange(num1, oldval);
          matrx[index1, 2] = Conversions.ToString(num1);
          if (flag1)
          {
            matrx[index1, 1] = "?";
            matrx[index1, 2] = "?";
          }
        }
        if ((double) this.game.Data.RuleVar[419] > 0.0)
        {
          if (this.IList[attnr].IAttacker == 1)
          {
            ++index1;
            matrx[index1, 0] = "Direct Fire Mod";
            float oldval = num1;
            if (this.IList[attnr].IdirectFire)
              num1 = (float) ((double) num1 * (double) this.IList[attnr].IdirectMod / 100.0);
            this.AddDetail("Attval after Direct Fire Mod: " + Conversion.Str((object) num1));
            matrx[index1, 1] = this.GetPercentChange(num1, oldval);
            matrx[index1, 2] = Conversions.ToString(num1);
            if (flag1)
            {
              matrx[index1, 1] = "?";
              matrx[index1, 2] = "?";
            }
          }
          if (this.IList[attnr].IAttacker == 0 & (!this.InterceptFire & this.CombatType == 3 | this.UList[this.IList[attnr].IUlistNr].USupportInterceptFire))
          {
            ++index1;
            matrx[index1, 0] = "Direct Fire Mod";
            float oldval = num1;
            if (!Information.IsNothing((object) this.IList[attnr].IdirectFireDef) && this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
              num1 = (float) ((double) num1 * (double) this.IList[attnr].IdirectModDef[this.IList[defnr].IUlistNr] / 100.0);
            this.AddDetail("Attval after Direct Fire Mod: " + Conversion.Str((object) num1));
            matrx[index1, 1] = this.GetPercentChange(num1, oldval);
            matrx[index1, 2] = Conversions.ToString(num1);
            if (flag1)
            {
              matrx[index1, 1] = "?";
              matrx[index1, 2] = "?";
            }
          }
          if ((double) this.game.Data.RuleVar[430] > 0.0)
          {
            if (this.CombatType == 3)
            {
              ++index1;
              matrx[index1, 0] = "Indirect Fire LOS Bonus";
              float oldval = num1;
              if (!(this.IList[attnr].IAttacker == 0 & this.InterceptFire) & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0)
              {
                if (!Information.IsNothing((object) this.UList[this.IList[attnr].IUlistNr].ULos))
                {
                  num1 += (float) ((double) this.game.Data.RuleVar[430] * (double) num1 * (double) this.UList[this.IList[attnr].IUlistNr].ULos[this.IList[defnr].IUlistNr] / 100.0);
                  int num11 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y].HeightLevel - this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.IList[attnr].IUnr].X, this.game.Data.UnitObj[this.IList[attnr].IUnr].Y].HeightLevel;
                  if (num11 < 0)
                    num1 += (float) ((double) this.game.Data.RuleVar[430] * (double) num1 * (double) this.UList[this.IList[attnr].IUlistNr].ULos[this.IList[defnr].IUlistNr] / 100.0 * ((double) Math.Abs(num11) * (double) this.game.Data.RuleVar[425] / 100.0));
                }
                this.AddDetail("Attval after Indirect Fire LOS Bonus: " + Conversion.Str((object) num1));
                matrx[index1, 1] = this.GetPercentChange(num1, oldval);
                matrx[index1, 2] = Conversions.ToString(num1);
                if (flag1)
                {
                  matrx[index1, 1] = "?";
                  matrx[index1, 2] = "?";
                }
              }
            }
            if (this.CombatType == 1)
            {
              ++index1;
              matrx[index1, 0] = "Indirect Fire LOS Bonus";
              float oldval = num1;
              if (this.UList[this.IList[attnr].IUlistNr].USupportInterceptFire & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0)
              {
                num1 += (float) ((double) this.game.Data.RuleVar[430] * (double) num1 * (double) this.UList[this.IList[attnr].IUlistNr].ULos[this.IList[defnr].IUlistNr] / 100.0);
                int num12 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y].HeightLevel - this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.IList[attnr].IUnr].X, this.game.Data.UnitObj[this.IList[attnr].IUnr].Y].HeightLevel;
                if (num12 < 0)
                  num1 += (float) ((double) this.game.Data.RuleVar[430] * (double) num1 * (double) this.UList[this.IList[attnr].IUlistNr].ULos[this.IList[defnr].IUlistNr] / 100.0 * ((double) Math.Abs(num12) * (double) this.game.Data.RuleVar[425] / 100.0));
              }
              this.AddDetail("Attval after Indirect Fire LOS Bonus: " + Conversion.Str((object) num1));
              matrx[index1, 1] = this.GetPercentChange(num1, oldval);
              matrx[index1, 2] = Conversions.ToString(num1);
              if (flag1)
              {
                matrx[index1, 1] = "?";
                matrx[index1, 2] = "?";
              }
            }
          }
        }
        int index17 = index1 + 1;
        matrx[index17, 0] = "Weather";
        float oldval1 = num1;
        float num13 = num1 * ((float) this.game.Data.UnitTypePenalty[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup] / 100f);
        this.AddDetail("Attval after global combat modifier (wheater): " + Conversion.Str((object) num13));
        matrx[index17, 1] = this.GetPercentChange(num13, oldval1);
        matrx[index17, 2] = Conversions.ToString(num13);
        if (flag1)
        {
          matrx[index17, 1] = "?";
          matrx[index17, 2] = "?";
        }
        CombatClass combatClass;
        if (!this.previewMode)
        {
          ++index17;
          matrx[index17, 0] = "Attack startup";
          float oldval2 = num13;
          int num14 = 100;
          if (this.customCombatObj.HasCustumCalls())
          {
            string str3 = "";
            CustomCombatCalls customCombatObj = this.customCombatObj;
            combatClass = this;
            ref CombatClass local1 = ref combatClass;
            GameClass game = this.game;
            int attnr1 = attnr;
            int defnr1 = defnr;
            int num15 = counterattack ? 1 : 0;
            ref string local2 = ref str3;
            num14 = customCombatObj.IndividualCombatCall_HasNoEarlyCombatRoundPenalties(ref local1, game, attnr1, defnr1, num15 != 0, ref local2);
            if (str3.Length > 0)
              str2 = str2 + "\r\n" + str3;
          }
          if (this.game.Data.Product >= 6 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].EndCombatRound > 0)
            num14 = 0;
          if (num14 <= 100 & !this.previewMode && this.CombatType == 1 | this.CombatType == 10 | this.CombatType == 12 && this.IList[attnr].IAttacker == 1 & !counterattack | this.IList[attnr].IAttacker == 0 & counterattack && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLessEqual(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackArt[unitGroup1], (object) 0, false), (object) !this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench)))
          {
            float num16 = (float) ((double) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].FirstRoundPenaltyMod * (double) num14 / 100.0);
            if (this.IList[attnr].IAttacker == 0 & counterattack)
              num16 = (float) ((double) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].FirstRoundPenaltyMod * (double) num14 / 100.0);
            if (this.CombatRound == 1)
              num13 = (float) ((double) num16 * (double) num13 * (double) this.game.Data.RuleVar[316] + (1.0 - (double) num16) * (double) num13);
            if (this.CombatRound == 2)
              num13 = (float) ((double) num16 * (double) num13 * (double) this.game.Data.RuleVar[317] + (1.0 - (double) num16) * (double) num13);
            this.AddDetail("Attval after 1st+2nd round attacker penalty: " + Conversion.Str((object) num13));
          }
          matrx[index17, 1] = this.GetPercentChange(num13, oldval2);
          matrx[index17, 2] = Conversions.ToString(num13);
          if (flag1)
          {
            matrx[index17, 1] = "?";
            matrx[index17, 2] = "?";
          }
        }
        if (counterattack)
        {
          ++index17;
          matrx[index17, 0] = "Counterattack";
          float oldval3 = num13;
          if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0)
          {
            if (this.IList[attnr].IAttacker == 1)
              num13 *= this.game.Data.RuleVar[101];
            else
              num13 *= this.game.Data.RuleVar[102];
          }
          else if (this.IList[attnr].IAttacker == 1)
            num13 *= this.game.Data.RuleVar[103];
          else
            num13 *= this.game.Data.RuleVar[104];
          if (this.game.Data.Product >= 6 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Attacks * 2 < this.IList[attnr].ICounterAttacks)
          {
            int num17 = (int) Math.Round((double) (this.IList[attnr].ICounterAttacks - this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Attacks * 2));
            for (int index18 = 1; index18 <= num17; ++index18)
              num13 *= 0.66f;
          }
          matrx[index17, 1] = this.GetPercentChange(num13, oldval3);
          matrx[index17, 2] = Conversions.ToString(num13);
          if (flag1)
          {
            matrx[index17, 1] = "?";
            matrx[index17, 2] = "?";
          }
          this.AddDetail("Attval after Counter Attack penalty: " + Conversion.Str((object) num13));
        }
        if (this.IList[attnr].IAA == 1)
        {
          ++index17;
          matrx[index17, 0] = "AA distance";
          float oldval4 = num13;
          num13 *= this.game.Data.RuleVar[105];
          this.AddDetail("Supporting AA fire gets penalty because outside own hex battle. mod the attval to: " + Conversion.Str((object) num13));
          matrx[index17, 1] = this.GetPercentChange(num13, oldval4);
          matrx[index17, 2] = Conversions.ToString(num13);
          if (flag1)
          {
            matrx[index17, 1] = "?";
            matrx[index17, 2] = "?";
          }
        }
        int index19 = index17 + 1;
        matrx[index19, 0] = "Max attacked";
        float oldval5 = num13;
        if (this.game.Data.Product == 7 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].MaxAttacked == 0)
          this.game.Data.SFTypeObj[this.IList[defnr].ISFType].MaxAttacked = 3;
        if (this.IList[defnr].AttackedCount > this.GetMaxAttacked(defnr, attnr))
        {
          bool flag6 = false;
          if (this.game.Data.Product >= 6)
          {
            if (this.IList[attnr].IAttacker == 1)
            {
              if (this.IList[attnr].IdirectFire)
                flag6 = true;
            }
            else if (!Information.IsNothing((object) this.IList[attnr].IdirectFireDef) && this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
              flag6 = true;
          }
          if (!(this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater < 2 & (this.CombatType == 5 | this.CombatType == 3 | this.CombatType == 4)) | flag6 && flag6 | !(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater < 2 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2 & (this.CombatType == 14 | this.CombatType == 15 | this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13)))
          {
            float num18 = (float) this.IList[defnr].AttackedCount / (float) this.GetMaxAttacked(defnr, attnr);
            if ((double) num18 > (double) this.game.Data.RuleVar[300])
              num18 = this.game.Data.RuleVar[300];
            if ((double) num18 <= 0.0)
              num18 = 1f;
            num13 /= num18;
          }
        }
        matrx[index19, 1] = this.GetPercentChange(num13, oldval5);
        matrx[index19, 2] = Conversions.ToString(num13);
        if (flag1)
        {
          matrx[index19, 1] = "?";
          matrx[index19, 2] = "?";
        }
        this.AddDetail("Target has been attacked more than its maxattacked.. mod the attval to: " + Conversion.Str((object) num13));
        if (this.customCombatObj.HasCustumCalls())
        {
          if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater != 2)
          {
            ++index19;
            matrx[index19, 0] = "Landscape";
            float oldval6 = num13;
            string str4 = "";
            if (this.IList[attnr].IAttacker == 0)
            {
              int num19 = (int) Math.Round((double) (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModDef[landscapeType1] * 100f));
              CustomCombatCalls customCombatObj = this.customCombatObj;
              combatClass = this;
              ref CombatClass local3 = ref combatClass;
              GameClass game = this.game;
              int attnr2 = attnr;
              int defnr2 = defnr;
              int num20 = counterattack ? 1 : 0;
              ref string local4 = ref str4;
              int landscapeDefMod = num19;
              int num21 = customCombatObj.IndividualCombatCall_RiverTypeAndLandscapeTypeModifier(ref local3, game, attnr2, defnr2, num20 != 0, ref local4, 0, 0, landscapeDefMod, -1);
              num13 = (float) ((double) num13 * (double) num21 / 100.0);
            }
            else if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType > -1 & (this.CombatType == 3 | this.CombatType == 4))
            {
              int num22 = (int) Math.Round((double) (this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType].CombatModAtt[landscapeType1] * 100f));
              CustomCombatCalls customCombatObj = this.customCombatObj;
              combatClass = this;
              ref CombatClass local5 = ref combatClass;
              GameClass game = this.game;
              int attnr3 = attnr;
              int defnr3 = defnr;
              int num23 = counterattack ? 1 : 0;
              ref string local6 = ref str4;
              int landscapeAttMod = num22;
              int num24 = customCombatObj.IndividualCombatCall_RiverTypeAndLandscapeTypeModifier(ref local5, game, attnr3, defnr3, num23 != 0, ref local6, 0, landscapeAttMod, 0, -1);
              num13 = (float) ((double) num13 * (double) num24 / 100.0);
            }
            else
            {
              int num25 = (int) Math.Round((double) (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModAtt[landscapeType1] * 100f));
              CustomCombatCalls customCombatObj = this.customCombatObj;
              combatClass = this;
              ref CombatClass local7 = ref combatClass;
              GameClass game = this.game;
              int attnr4 = attnr;
              int defnr4 = defnr;
              int num26 = counterattack ? 1 : 0;
              ref string local8 = ref str4;
              int landscapeAttMod = num25;
              int num27 = customCombatObj.IndividualCombatCall_RiverTypeAndLandscapeTypeModifier(ref local7, game, attnr4, defnr4, num26 != 0, ref local8, 0, landscapeAttMod, 0, -1);
              num13 = (float) ((double) num13 * (double) num27 / 100.0);
            }
            if (this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Type].PictureLT > -1)
            {
              int pictureLt = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Type].PictureLT;
              if (this.IList[attnr].IAttacker == 0)
                num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModDef[pictureLt];
              else
                num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModAtt[pictureLt];
            }
            matrx[index19, 1] = this.GetPercentChange(num13, oldval6);
            if ((double) num13 < (double) oldval6 & this.IList[attnr].IAttacker == 1)
              num13 = num13;
            matrx[index19, 2] = Conversions.ToString(num13);
            if (flag1)
            {
              matrx[index19, 1] = "?";
              matrx[index19, 2] = "?";
            }
            if (str4.Length > 0)
              str2 = str2 + "\r\n" + str4;
          }
        }
        else if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater != 2)
        {
          ++index19;
          matrx[index19, 0] = "Landscape";
          float oldval7 = num13;
          bool flag7 = false;
          if (this.game.Data.Product >= 6)
          {
            if (this.IList[attnr].IdirectFire)
              flag7 = true;
            if (this.IList[attnr].IAttacker == 0 && !Information.IsNothing((object) this.IList[attnr].IdirectFireDef) && this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
              flag7 = true;
            if (!(this.CombatType == 3 | this.CombatType == 4))
              flag7 = false;
          }
          if (flag7)
          {
            int landscapeType2 = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.game.Data.UnitObj[this.UList[this.IList[defnr].IUlistNr].UNr].X, this.game.Data.UnitObj[this.UList[this.IList[defnr].IUlistNr].UNr].Y].LandscapeType;
            if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType > -1)
              num13 *= this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType].CombatModAtt[landscapeType2];
            else
              num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModAtt[landscapeType2];
          }
          else
          {
            if (this.IList[attnr].IAttacker == 0)
              num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModDef[landscapeType1];
            else if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType > -1 & (this.CombatType == 3 | this.CombatType == 4))
              num13 *= this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType].CombatModAtt[landscapeType1];
            else
              num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModAtt[landscapeType1];
            if (this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Type].PictureLT > -1)
            {
              int pictureLt = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Type].PictureLT;
              if (this.IList[attnr].IAttacker == 0)
                num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModDef[pictureLt];
              else
                num13 *= this.game.Data.SFTypeObj[this.IList[attnr].ISFType].CombatModAtt[pictureLt];
            }
          }
          matrx[index19, 1] = this.GetPercentChange(num13, oldval7);
          matrx[index19, 2] = Conversions.ToString(num13);
          if (flag1)
          {
            matrx[index19, 1] = "?";
            matrx[index19, 2] = "?";
          }
        }
        this.AddDetail("Attval after CombatMod for Landscapetype: " + Conversion.Str((object) num13));
        if (this.IList[attnr].IAttacker == 0)
          index3 = index3;
        if (!this.previewMode | this.UList[this.IList[attnr].IUlistNr].previewInfoLevel >= 2)
        {
          ++index19;
          matrx[index19, 0] = "HQ";
          float oldval8 = num13;
          if (!this.game.Data.UnitObj[this.IList[attnr].IUnr].IsHQ)
          {
            if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0)
            {
              num13 *= this.UList[this.IList[attnr].IUlistNr].UStaffMod;
              this.AddDetail("Attval after CombatMod for Staff (" + Conversion.Str((object) this.UList[this.IList[attnr].IUlistNr].UStaffMod) + "): " + Conversion.Str((object) num13));
            }
            else
              this.AddDetail("Attval NO staff modifier because not land theater.");
          }
          else
            this.AddDetail("Attval NO staff modifier because is HQ.");
          matrx[index19, 1] = this.GetPercentChange(num13, oldval8);
          matrx[index19, 2] = Conversions.ToString(num13);
          if (flag1)
          {
            matrx[index19, 1] = "?";
            matrx[index19, 2] = "?";
          }
        }
        int index20 = index19 + 1;
        matrx[index20, 0] = "Readiness";
        float oldval9 = num13;
        int unitGroup2 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup;
        float num28 = this.IList[attnr].IAttacker != 1 ? (float) ((double) num13 * (1.0 - (double) this.game.Data.RuleVar[107]) + (double) num13 * (double) this.game.Data.RuleVar[107] * ((double) this.IList[attnr].IRdn / 100.0)) : (float) ((double) num13 * (1.0 - (double) this.game.Data.RuleVar[106]) + (double) num13 * (double) this.game.Data.RuleVar[106] * ((double) this.IList[attnr].IRdn / 100.0));
        this.AddDetail("Attval after Rdn mod: " + Conversion.Str((object) num28));
        matrx[index20, 1] = this.GetPercentChange(num28, oldval9);
        matrx[index20, 2] = Conversions.ToString(num28);
        if (flag1)
        {
          matrx[index20, 1] = "?";
          matrx[index20, 2] = "?";
        }
        if ((double) this.game.Data.RuleVar[482] > 0.0 & this.game.Data.Product >= 6 && this.UList[this.IList[attnr].IUlistNr].Uattacker == 1 & !(this.game.EditObj.attackTypeOption == 0 | this.game.EditObj.attackTypeOption == 3))
        {
          ++index20;
          matrx[index20, 0] = "Attack Mode";
          float oldval10 = num28;
          if (this.game.EditObj.attackTypeOption == 1)
            num28 *= 0.33f;
          else if (this.game.EditObj.attackTypeOption == 2)
            num28 *= 0.5f;
          else if (this.game.EditObj.attackTypeOption == 4)
            num28 *= 1.66f;
          this.AddDetail("Attval after Attack Mode mod: " + Conversion.Str((object) num28));
          matrx[index20, 1] = this.GetPercentChange(num28, oldval10);
          matrx[index20, 2] = Conversions.ToString(num28);
          if (flag1)
          {
            matrx[index20, 1] = "?";
            matrx[index20, 2] = "?";
          }
        }
        if ((double) this.game.Data.RuleVar[407] > 0.0 | (double) this.game.Data.RuleVar[434] > 0.0 && !this.previewMode | !flag3)
        {
          int index21;
          if ((double) this.IList[attnr].ILisAmmoMod < 1.0)
          {
            index21 = index20 + 1;
            matrx[index21, 0] = "Ammunition Mod";
            float oldval11 = num28;
            num28 *= this.IList[attnr].ILisAmmoMod;
            this.AddDetail("Attval after Ammunition mod: " + Conversion.Str((object) num28));
            matrx[index21, 1] = this.GetPercentChange(num28, oldval11);
            matrx[index21, 2] = Conversions.ToString(num28);
            if (flag1)
            {
              matrx[index21, 1] = "?";
              matrx[index21, 2] = "?";
            }
          }
          else
          {
            index21 = index20 + 1;
            matrx[index21, 0] = "Ammunition Mod";
            float oldval12 = num28;
            matrx[index21, 1] = this.GetPercentChange(num28, oldval12);
            matrx[index21, 2] = Conversions.ToString(num28);
            if (flag1)
            {
              matrx[index21, 1] = "?";
              matrx[index21, 2] = "?";
            }
          }
          if ((double) this.IList[attnr].ILisFuelMod < 1.0)
          {
            index20 = index21 + 1;
            matrx[index20, 0] = "Fuel Mod";
            float oldval13 = num28;
            num28 *= this.IList[attnr].ILisFuelMod;
            this.AddDetail("Attval after Fuel mod: " + Conversion.Str((object) num28));
            matrx[index20, 1] = this.GetPercentChange(num28, oldval13);
            matrx[index20, 2] = Conversions.ToString(num28);
            if (flag1)
            {
              matrx[index20, 1] = "?";
              matrx[index20, 2] = "?";
            }
          }
          else
          {
            index20 = index21 + 1;
            matrx[index20, 0] = "Fuel Mod";
            float oldval14 = num28;
            matrx[index20, 1] = this.GetPercentChange(num28, oldval14);
            matrx[index20, 2] = Conversions.ToString(num28);
            if (flag1)
            {
              matrx[index20, 1] = "?";
              matrx[index20, 2] = "?";
            }
          }
        }
        int index22 = index20 + 1;
        matrx[index22, 0] = "Airfield Stack";
        float oldval15 = num28;
        unitGroup2 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup;
        if ((double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.IList[attnr].IUnr].X, this.game.Data.UnitObj[this.IList[attnr].IUnr].Y) < 1.0)
          num28 = (float) (0.33 * (double) num28 + 0.66 * (double) num28 * (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.IList[attnr].IUnr].X, this.game.Data.UnitObj[this.IList[attnr].IUnr].Y));
        this.AddDetail("Attval after airfield stack: " + Conversion.Str((object) num28));
        matrx[index22, 1] = this.GetPercentChange(num28, oldval15);
        matrx[index22, 2] = Conversions.ToString(num28);
        if (flag1)
        {
          matrx[index22, 1] = "?";
          matrx[index22, 2] = "?";
        }
        if (!this.previewMode | this.UList[this.IList[attnr].IUlistNr].previewInfoLevel >= 2)
        {
          ++index22;
          matrx[index22, 0] = "Special";
          float oldval16 = num28;
          if (this.IList[attnr].IAttacker == 1)
          {
            index3 = this.game.Data.SFObj[this.IList[attnr].ISFNr].OffMod + 100;
            if (0 > index3)
              index3 = 0;
            if (index3 > 999)
              index3 = 999;
            num28 *= (float) index3 / 100f;
          }
          else
          {
            index3 = this.game.Data.SFObj[this.IList[attnr].ISFNr].DefMod + 100;
            if (0 > index3)
              index3 = 0;
            if (index3 > 999)
              index3 = 999;
            num28 *= (float) index3 / 100f;
          }
          matrx[index22, 1] = this.GetPercentChange(num28, oldval16);
          matrx[index22, 2] = Conversions.ToString(num28);
          if (flag1)
          {
            matrx[index22, 1] = "?";
            matrx[index22, 2] = "?";
          }
          this.AddDetail("Attval after AttackMod / DefensiveMod mod: " + Conversion.Str((object) num28));
        }
        if (!this.previewMode | !flag3)
        {
          ++index22;
          matrx[index22, 0] = "Supply";
          float oldval17 = num28;
          num28 = (float) ((double) num28 * (1.0 - (double) this.game.Data.RuleVar[130]) + (double) num28 * (double) this.game.Data.RuleVar[130] * ((double) this.game.Data.UnitObj[this.IList[attnr].IUnr].SupplyConsume / 100.0));
          this.AddDetail("attval after SupplyConsume mod: " + Conversion.Str((object) num28));
          matrx[index22, 1] = this.GetPercentChange(num28, oldval17);
          matrx[index22, 2] = Conversions.ToString(num28);
          if (flag1)
          {
            matrx[index22, 1] = "?";
            matrx[index22, 2] = "?";
          }
        }
        int index23 = index22 + 1;
        matrx[index23, 0] = "People";
        float oldval18 = num28;
        int people1 = this.game.Data.SFObj[this.IList[attnr].ISFNr].People;
        int people2 = this.game.Data.SFObj[this.IList[defnr].ISFNr].People;
        int people3 = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime].People;
        float num29 = num28 * this.game.Data.PeopleObj[people1].BattleForMod[this.game.Data.PeopleObj[people3].PeopleGroup];
        this.AddDetail("Attval after Battle For People X mod: " + Conversion.Str((object) num29));
        matrx[index23, 1] = this.GetPercentChange(num29, oldval18);
        matrx[index23, 2] = Conversions.ToString(num29);
        if (flag1)
        {
          matrx[index23, 1] = "?";
          matrx[index23, 2] = "?";
        }
        int index24 = index23 + 1;
        matrx[index24, 0] = "VS People";
        float oldval19 = num29;
        float num30 = num29 * this.game.Data.PeopleObj[people1].BattleVSMod[this.game.Data.PeopleObj[people2].PeopleGroup];
        this.AddDetail("Attval after Battle Versus People Y mod: " + Conversion.Str((object) num30));
        matrx[index24, 1] = this.GetPercentChange(num30, oldval19);
        matrx[index24, 2] = Conversions.ToString(num30);
        if (flag1)
        {
          matrx[index24, 1] = "?";
          matrx[index24, 2] = "?";
        }
        int index25 = index24 + 1;
        matrx[index25, 0] = "Experience";
        float oldval20 = num30;
        float num31;
        if ((double) this.game.Data.RuleVar[877] < 1.0)
        {
          num31 = num30 + (float) ((double) num30 * 1.0 * ((double) this.IList[attnr].IXp / 100.0));
        }
        else
        {
          index3 = (int) Math.Round((double) (100f - this.game.Data.RuleVar[877]));
          num31 = num30 + (float) ((double) num30 * 1.0 * ((double) index3 / 100.0 * ((double) this.IList[attnr].IXp / 100.0)));
        }
        this.AddDetail("Attval after XP mod: " + Conversion.Str((object) num31));
        matrx[index25, 1] = this.GetPercentChange(num31, oldval20);
        matrx[index25, 2] = Conversions.ToString(num31);
        if (flag1)
        {
          matrx[index25, 1] = "?";
          matrx[index25, 2] = "?";
        }
        if (this.IList[attnr].IAttacker == 1)
        {
          ++index25;
          matrx[index25, 0] = "Concentric";
          float oldval21 = num31;
          num31 *= this.ConcentricBonus;
          this.AddDetail("Attval after Concentric Bonus (" + Conversion.Str((object) this.ConcentricBonus) + "): " + Conversion.Str((object) num31));
          matrx[index25, 1] = this.GetPercentChange(num31, oldval21);
          matrx[index25, 2] = Conversions.ToString(num31);
          if (flag1)
          {
            matrx[index25, 1] = "?";
            matrx[index25, 2] = "?";
          }
        }
        if (this.IList[attnr].IAttacker == 0)
        {
          if (this.CombatType == 11 & !counterattack)
          {
            ++index25;
            matrx[index25, 0] = "Surprise";
            float oldval22 = num31;
            num31 *= this.game.Data.RuleVar[108];
            if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[470] > 0.0)
              num31 *= this.game.Data.RuleVar[108];
            this.AddDetail("Attval after LANDSURPRISE mod: " + Conversion.Str((object) num31));
            matrx[index25, 1] = this.GetPercentChange(num31, oldval22);
            matrx[index25, 2] = Conversions.ToString(num31);
            if (flag1)
            {
              matrx[index25, 1] = "?";
              matrx[index25, 2] = "?";
            }
          }
          if (this.CombatType == 9 & !counterattack && this.IList[defnr].IParadropper)
          {
            ++index25;
            matrx[index25, 0] = "Paradrop";
            float oldval23 = num31;
            num31 *= this.game.Data.RuleVar[109];
            this.AddDetail("attval after paradropper mod: " + Conversion.Str((object) num31));
            matrx[index25, 1] = this.GetPercentChange(num31, oldval23);
            matrx[index25, 2] = Conversions.ToString(num31);
            if (flag1)
            {
              matrx[index25, 1] = "?";
              matrx[index25, 2] = "?";
            }
          }
          if (this.CombatType == 10 & !counterattack)
          {
            ++index25;
            matrx[index25, 0] = "Amphibic";
            float oldval24 = num31;
            num31 *= this.game.Data.RuleVar[110];
            this.AddDetail("Attval after amph mod: " + Conversion.Str((object) num31));
            matrx[index25, 1] = this.GetPercentChange(num31, oldval24);
            matrx[index25, 2] = Conversions.ToString(num31);
            if (flag1)
            {
              matrx[index25, 1] = "?";
              matrx[index25, 2] = "?";
            }
          }
        }
        else if (this.CombatType == 12 & !counterattack)
        {
          ++index25;
          matrx[index25, 0] = "Rebel";
          float oldval25 = num31;
          num31 *= this.game.Data.RuleVar[111];
          this.AddDetail("Attval after REBEL mod: " + Conversion.Str((object) num31));
          matrx[index25, 1] = this.GetPercentChange(num31, oldval25);
          matrx[index25, 2] = Conversions.ToString(num31);
          if (flag1)
          {
            matrx[index25, 1] = "?";
            matrx[index25, 2] = "?";
          }
        }
        if (this.IList[defnr].IRetreat > 0)
        {
          if (this.IList[defnr].IRetreatMode == 2)
          {
            ++index25;
            matrx[index25, 0] = "Retreating target";
            float oldval26 = num31;
            if (this.IList[defnr].IAttacker == 0)
            {
              num31 *= this.game.Data.RuleVar[113];
              this.AddDetail("Attval * x due to defender target is orderly retreating: " + Conversion.Str((object) num31));
            }
            else
            {
              num31 *= this.game.Data.RuleVar[112];
              this.AddDetail("Attval * x due to attacker target is orderly retreating: " + Conversion.Str((object) num31));
            }
            matrx[index25, 1] = this.GetPercentChange(num31, oldval26);
            matrx[index25, 2] = Conversions.ToString(num31);
            if (flag1)
            {
              matrx[index25, 1] = "?";
              matrx[index25, 2] = "?";
            }
          }
          if (this.IList[defnr].IRetreatMode == 3)
          {
            ++index25;
            matrx[index25, 0] = "Panicking target";
            float oldval27 = num31;
            if (this.IList[defnr].IAttacker == 0)
            {
              num31 *= this.game.Data.RuleVar[115];
              this.AddDetail("Attval * x due to defender target is panic retreating: " + Conversion.Str((object) num31));
            }
            else
            {
              num31 *= this.game.Data.RuleVar[114];
              this.AddDetail("Attval * x due to attacker target is panic retreating: " + Conversion.Str((object) num31));
            }
            matrx[index25, 1] = this.GetPercentChange(num31, oldval27);
            matrx[index25, 2] = Conversions.ToString(num31);
            if (flag1)
            {
              matrx[index25, 1] = "?";
              matrx[index25, 2] = "?";
            }
          }
        }
        bool flag8 = true;
        if (this.game.Data.Product >= 6)
        {
          if (this.CombatType == 3 | this.CombatType == 4)
            flag8 = false;
          if (this.InterceptFire)
            flag8 = false;
          if (this.UList[this.IList[attnr].IUlistNr].USupportInterceptFire)
            flag8 = false;
        }
        if (flag8)
        {
          ++index25;
          matrx[index25, 0] = "Divisional";
          if (this.game.Data.Product >= 6)
            matrx[index25, 0] = "Multi-Unit";
          float oldval28 = num31;
          if (!this.previewMode | this.UList[this.IList[attnr].IUlistNr].previewInfoLevel >= 2)
          {
            index3 = this.game.HandyFunctionsObj.GetDivBonus(this.IList[attnr].IUnr);
            if (index3 > 0)
              num31 += num31 * ((float) index3 / 100f);
          }
          this.AddDetail("Attval, due to " + Conversion.Str((object) index3) + "% div bonus: " + Conversion.Str((object) num31));
          matrx[index25, 1] = this.GetPercentChange(num31, oldval28);
          matrx[index25, 2] = Conversions.ToString(num31);
          if (flag1)
          {
            matrx[index25, 1] = "?";
            matrx[index25, 2] = "?";
          }
        }
        int num32 = 0;
        int index26 = index25 + 1;
        matrx[index26, 0] = "AI Bonus";
        float oldval29 = num31;
        if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime].AI)
        {
          if ((double) this.game.Data.RuleVar[992] > 0.0)
            num32 = (int) Math.Round((double) this.game.Data.RuleVar[992]);
          int num33 = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime].AIHelpCombat + num32;
          if (this.customCombatObj.HasCustumCalls())
          {
            CustomCombatCalls customCombatObj = this.customCombatObj;
            combatClass = this;
            ref CombatClass local = ref combatClass;
            int forNr = attnr;
            int againstNr = defnr;
            int tHelpCombat = num33;
            num33 = customCombatObj.AIHelpCombatChanger(ref local, forNr, againstNr, tHelpCombat);
          }
          if (num33 > 0 && num33 > 0)
            num31 += num31 * ((float) num33 / 100f);
        }
        this.AddDetail("Attval, due to AI Combat Bonus " + Conversion.Str((object) num31));
        matrx[index26, 1] = this.GetPercentChange(num31, oldval29);
        matrx[index26, 2] = Conversions.ToString(num31);
        if (flag1)
        {
          matrx[index26, 1] = "?";
          matrx[index26, 2] = "?";
        }
        if (this.game.Data.Product == 7 & (double) this.game.Data.RuleVar[475] > 0.0)
        {
          ++index26;
          matrx[index26, 0] = "Battlegroup Reduced Org.";
          float oldval30 = num31;
          if (this.game.HandyFunctionsObj.CheckIsBattlegroup(this.IList[attnr].IUnr))
          {
            bool flag9 = true;
            if (this.customCombatObj.HasCustumCalls())
            {
              CustomCombatCalls customCombatObj = this.customCombatObj;
              combatClass = this;
              ref CombatClass local = ref combatClass;
              GameClass game = this.game;
              int attnr5 = attnr;
              int defnr5 = defnr;
              flag9 = customCombatObj.IndividualCombatCall_SmallSizeBGmodifierApplies(ref local, game, attnr5, defnr5);
            }
            if (flag9)
            {
              num31 *= 0.85f;
              this.AddDetail("Attval after penalty for BG reduced organisation " + Conversion.Str((object) num31));
            }
          }
          matrx[index26, 1] = this.GetPercentChange(num31, oldval30);
          matrx[index26, 2] = Conversions.ToString(num31);
          if (flag1)
          {
            matrx[index26, 1] = "?";
            matrx[index26, 2] = "?";
          }
        }
        int index27 = index2 + 1;
        matrx[index27, 3] = "Readiness";
        float oldval31 = Number1;
        int unitGroup3 = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].UnitGroup;
        float num34 = (float) ((double) Number1 * (1.0 - (double) this.game.Data.RuleVar[116]) + (double) Number1 * (double) this.game.Data.RuleVar[116] * ((double) this.IList[defnr].IRdn / 100.0));
        if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0)
          num34 = (float) (int) Math.Round(((double) oldval31 + (double) oldval31 + (double) num34) / 3.0);
        this.AddDetail("Defval after Rdn mod: " + Conversion.Str((object) num34));
        matrx[index27, 4] = this.GetPercentChange(num34, oldval31);
        matrx[index27, 5] = Conversions.ToString(num34);
        if (flag2)
        {
          matrx[index27, 4] = "?";
          matrx[index27, 5] = "?";
        }
        if ((double) this.game.Data.RuleVar[482] > 0.0 & this.game.Data.Product >= 6 && this.UList[this.IList[defnr].IUlistNr].Uattacker == 1 & !(this.game.EditObj.attackTypeOption == 0 | this.game.EditObj.attackTypeOption == 3))
        {
          ++index27;
          matrx[index27, 3] = "Attack Mode";
          float oldval32 = num34;
          if (this.game.EditObj.attackTypeOption == 1)
            num34 *= 1.5f;
          else if (this.game.EditObj.attackTypeOption == 2)
            num34 *= 1.66f;
          else if (this.game.EditObj.attackTypeOption == 4)
            num34 *= 0.5f;
          this.AddDetail("Defval after Attack Mode mod: " + Conversion.Str((object) num34));
          matrx[index27, 4] = this.GetPercentChange(num34, oldval32);
          matrx[index27, 5] = Conversions.ToString(num34);
          if (flag2)
          {
            matrx[index27, 4] = "?";
            matrx[index27, 5] = "?";
          }
        }
        if (this.game.Data.UncertaintyOn & !this.previewMode)
        {
          ++index27;
          matrx[index27, 3] = "Uncertainty effect";
          float oldval33 = num34;
          int udice3 = this.UList[this.IList[attnr].IUlistNr].UDice;
          int udice4 = this.UList[this.IList[defnr].IUlistNr].UDice;
          int num35;
          int num36;
          if (this.IList[attnr].IAttacker == 1)
          {
            num35 = udice3 + this.AttackerDice;
            num36 = udice4 + this.DefenderDice;
          }
          else
          {
            num35 = udice3 + this.DefenderDice;
            num36 = udice4 + this.AttackerDice;
          }
          int num37 = num36 - num35;
          if (num37 > 0)
            num34 *= (float) (1.0 + (double) num37 / 10.0);
          this.AddDetail("Attval after uncertainty effect: " + Conversion.Str((object) num34));
          matrx[index27, 4] = this.GetPercentChange(num34, oldval33);
          matrx[index27, 5] = Conversions.ToString(num34);
          if (flag2)
          {
            matrx[index27, 4] = "?";
            matrx[index27, 5] = "?";
          }
        }
        if (!this.previewMode | !flag4)
        {
          ++index27;
          matrx[index27, 3] = "Supply";
          float oldval34 = num34;
          num34 = (float) ((double) num34 * (1.0 - (double) this.game.Data.RuleVar[130]) + (double) num34 * (double) this.game.Data.RuleVar[130] * ((double) this.game.Data.UnitObj[this.IList[defnr].IUnr].SupplyConsume / 100.0));
          this.AddDetail("Defval after SupplyConsume mod: " + Conversion.Str((object) num34));
          matrx[index27, 4] = this.GetPercentChange(num34, oldval34);
          matrx[index27, 5] = Conversions.ToString(num34);
          if (flag2)
          {
            matrx[index27, 4] = "?";
            matrx[index27, 5] = "?";
          }
        }
        if (this.game.Data.Product >= 6)
        {
          if (!(this.CombatType == 11 | this.InterceptFire) & !this.UList[this.IList[attnr].IUlistNr].USupportInterceptFire)
          {
            ++index27;
            matrx[index27, 3] = "Entrenchment";
            float oldval35 = num34;
            if (this.IList[defnr].IAttacker == 0 & this.CombatType != 12)
            {
              int ientrench = this.IList[defnr].IEntrench;
              num34 *= (float) (1.0 + (double) ientrench / 100.0);
              this.AddDetail("Defval after Entrench mod for defending hex: " + Conversion.Str((object) num34));
            }
            else if (this.IList[defnr].IAttacker == 1 & (this.CombatType == 4 | this.CombatType == 3))
            {
              num34 *= (float) (1.0 + (double) this.IList[defnr].IEntrench / 100.0);
              this.AddDetail("Defval after Entrench mod for defending hex: " + Conversion.Str((object) num34));
            }
            matrx[index27, 4] = this.GetPercentChange(num34, oldval35);
            matrx[index27, 5] = Conversions.ToString(num34);
            if (flag2)
            {
              matrx[index27, 4] = "?";
              matrx[index27, 5] = "?";
            }
            if (this.IList[defnr].IAttacker == 0 & this.CombatType != 12)
            {
              int ientrench = this.IList[defnr].IEntrench;
              if (this.customCombatObj.HasCustumCalls() & ientrench > 0)
              {
                int oldval36 = (int) Math.Round((double) num34);
                CustomCombatCalls customCombatObj = this.customCombatObj;
                combatClass = this;
                ref CombatClass local = ref combatClass;
                int indNr = defnr;
                int x = this.CombatTarget.x;
                int y = this.CombatTarget.y;
                int entr = ientrench;
                int num38 = customCombatObj.EntrenchModifier(ref local, indNr, x, y, entr) - this.IList[defnr].IEntrench;
                num34 += num34 * ((float) num38 / 100f);
                if ((double) num34 != (double) oldval36)
                {
                  ++index27;
                  matrx[index27, 3] = "Extra Entrenchment";
                  matrx[index27, 4] = this.GetPercentChange(num34, (float) oldval36);
                  matrx[index27, 5] = Conversions.ToString(num34);
                  if (flag2)
                  {
                    matrx[index27, 4] = "?";
                    matrx[index27, 5] = "?";
                  }
                }
              }
            }
          }
        }
        else
        {
          ++index27;
          matrx[index27, 3] = "Entrenchment";
          float oldval37 = num34;
          if (this.IList[defnr].IAttacker == 0 & this.CombatType != 12)
          {
            num34 *= (float) (1.0 + (double) this.IList[defnr].IEntrench / 100.0);
            this.AddDetail("Defval after Entrench mod for defending hex: " + Conversion.Str((object) num34));
          }
          matrx[index27, 4] = this.GetPercentChange(num34, oldval37);
          matrx[index27, 5] = Conversions.ToString(num34);
          if (flag2)
          {
            matrx[index27, 4] = "?";
            matrx[index27, 5] = "?";
          }
        }
        int index28 = index27 + 1;
        matrx[index28, 3] = "Experience";
        float oldval38 = num34;
        float num39;
        if ((double) this.game.Data.RuleVar[876] < 1.0)
        {
          num39 = num34 + (float) ((double) num34 * 1.0 * ((double) this.IList[defnr].IXp / 100.0));
        }
        else
        {
          index3 = (int) Math.Round((double) (100f - this.game.Data.RuleVar[877]));
          num39 = num34 + (float) ((double) num34 * 1.0 * ((double) index3 / 100.0 * ((double) this.IList[defnr].IXp / 100.0)));
        }
        this.AddDetail("Defval after xp mod: " + Conversion.Str((object) num39));
        matrx[index28, 4] = this.GetPercentChange(num39, oldval38);
        matrx[index28, 5] = Conversions.ToString(num39);
        if (flag2)
        {
          matrx[index28, 4] = "?";
          matrx[index28, 5] = "?";
        }
        if ((double) this.game.Data.RuleVar[431] > 0.0)
        {
          ++index28;
          matrx[index28, 3] = "Defender is Hidden";
          float oldval39 = num39;
          if ((double) this.GetEffectiveReconOnHexOfTargettedIndividual(defnr) < (double) this.IList[defnr].IcoverPoints | this.previewMode & this.UList[this.IList[defnr].IUlistNr].previewInfoLevel < 2 & this.GetEffectiveReconOnHexOfTargettedIndividual(defnr) < this.IList[defnr].previewCoverPoints)
          {
            float num40 = 2f;
            num39 *= num40;
            if (this.previewMode && (this.CombatType == 3 | this.CombatType == 4) & this.game.Data.Product != 7)
            {
              if (this.IList[defnr].IAttacker == 0 & this.CrowdingDefCount > 0)
              {
                if (this.CrowdingDefCount < DrawMod.RandyNumber.Next(0, (int) Math.Round((double) (this.game.Data.RuleVar[30] * 2f))))
                  num39 *= this.game.Data.RuleVar[30] * 2f / (float) this.CrowdingDefCount;
              }
              else if (this.IList[defnr].IAttacker == 1 & this.NewBattleStack > 0 && this.NewBattleStack < DrawMod.RandyNumber.Next(0, (int) Math.Round((double) (this.AttackCrowding * 2f))))
                num39 *= this.AttackCrowding * 2f / (float) this.NewBattleStack;
            }
            this.AddDetail("Defval after HP bonus for being Hidden: " + Conversion.Str((object) num39));
          }
          matrx[index28, 4] = this.GetPercentChange(num39, oldval39);
          matrx[index28, 5] = Conversions.ToString(num39);
          if (flag2)
          {
            matrx[index28, 4] = "?";
            matrx[index28, 5] = "?";
          }
        }
        if (this.game.AllowHeightMap & ((double) this.game.Data.RuleVar[424] > 0.0 | (double) this.game.Data.RuleVar[425] > 0.0))
        {
          index3 = 0;
          if (this.IList[attnr].IAttacker == 1 & (this.IList[attnr].IdirectFire | !(this.CombatType == 3 | this.CombatType == 4)))
            index3 = 1;
          if (this.IList[attnr].IAttacker == 0)
          {
            if (!(this.CombatType == 3 | this.CombatType == 4))
              index3 = !(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0) ? 1 : 0;
            else if ((double) this.game.Data.RuleVar[419] > 0.0)
            {
              if (!Information.IsNothing((object) this.IList[attnr].IdirectFireDef) && this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
                index3 = 1;
            }
            else
              index3 = 0;
          }
          if (index3 == 1)
          {
            int num41 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y].HeightLevel - this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.IList[attnr].IUnr].X, this.game.Data.UnitObj[this.IList[attnr].IUnr].Y].HeightLevel;
            if (num41 > 0)
            {
              ++index28;
              matrx[index28, 3] = "Defender has highground";
              float oldval40 = num39;
              num39 += num39 * (float) ((double) num41 * (double) this.game.Data.RuleVar[425] / 100.0);
              this.AddDetail("Defval after Defender Highground bonus " + Conversion.Str((object) num39));
              matrx[index28, 4] = this.GetPercentChange(num39, oldval40);
              matrx[index28, 5] = Conversions.ToString(num39);
              if (flag2)
              {
                matrx[index28, 4] = "?";
                matrx[index28, 5] = "?";
              }
            }
            else if (num41 < 0)
            {
              ++index28;
              matrx[index28, 3] = "Attacker has highground";
              float oldval41 = num39;
              num39 += num39 * (float) ((double) num41 * (double) this.game.Data.RuleVar[424] / 100.0);
              this.AddDetail("Defval after Attacker Highground penalty " + Conversion.Str((object) num39));
              matrx[index28, 4] = this.GetPercentChange(num39, oldval41);
              matrx[index28, 5] = Conversions.ToString(num39);
              if (flag2)
              {
                matrx[index28, 4] = "?";
                matrx[index28, 5] = "?";
              }
            }
          }
        }
        if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[431] > 0.0)
        {
          bool flag10 = false;
          bool flag11 = false;
          if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench)
          {
            if (this.IList[attnr].IBreakTrough > 0 & !this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench)
            {
              if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].ArtRange > 0 & !(this.CombatType == 3 | this.CombatType == 4))
              {
                ++index28;
                matrx[index28, 3] = "Very close combat";
                float oldval42 = num39;
                num39 *= 0.33f;
                this.AddDetail("Defval after art-VERY close combat penalty " + Conversion.Str((object) num39));
                matrx[index28, 4] = this.GetPercentChange(num39, oldval42);
                matrx[index28, 5] = Conversions.ToString(num39);
                if (flag2)
                {
                  matrx[index28, 4] = "?";
                  matrx[index28, 5] = "?";
                }
                flag11 = true;
              }
            }
            else if (!this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].ArtRange > 0 & !(this.CombatType == 3 | this.CombatType == 4))
            {
              ++index28;
              matrx[index28, 3] = "Close combat";
              float oldval43 = num39;
              num39 *= 0.66f;
              this.AddDetail("Defval after art-close combat penalty " + Conversion.Str((object) num39));
              matrx[index28, 4] = this.GetPercentChange(num39, oldval43);
              matrx[index28, 5] = Conversions.ToString(num39);
              if (flag2)
              {
                matrx[index28, 4] = "?";
                matrx[index28, 5] = "?";
              }
              flag10 = true;
            }
          }
          if (((flag2 ? 1 : 0) & 0) != 0)
          {
            if (!flag11)
            {
              ++index28;
              matrx[index28, 3] = "Very close combat";
              float oldval44 = num39;
              matrx[index28, 4] = this.GetPercentChange(num39, oldval44);
              matrx[index28, 5] = Conversions.ToString(num39);
              if (flag2)
              {
                matrx[index28, 4] = "?";
                matrx[index28, 5] = "?";
              }
            }
            if (!flag10)
            {
              ++index28;
              matrx[index28, 3] = "Close combat";
              float oldval45 = num39;
              matrx[index28, 4] = this.GetPercentChange(num39, oldval45);
              matrx[index28, 5] = Conversions.ToString(num39);
              if (flag2)
              {
                matrx[index28, 4] = "?";
                matrx[index28, 5] = "?";
              }
            }
          }
        }
        if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[484] > 0.0)
        {
          ++index28;
          matrx[index28, 3] = "March Mode";
          float oldval46 = num39;
          if (this.game.Data.UnitObj[this.IList[defnr].IUnr].moveMode == 1)
          {
            if (this.CombatRound == 1)
              num39 *= 0.05f;
            if (this.CombatRound == 2)
              num39 *= 0.15f;
            if (this.CombatRound == 3)
              num39 *= 0.3f;
            if (this.CombatRound == 4)
              num39 *= 0.5f;
            if (this.CombatRound == 5)
              num39 *= 0.75f;
          }
          this.AddDetail("Defval after March Mode penalty " + Conversion.Str((object) num39));
          matrx[index28, 4] = this.GetPercentChange(num39, oldval46);
          matrx[index28, 5] = Conversions.ToString(num39);
          if (flag2)
          {
            matrx[index28, 4] = "?";
            matrx[index28, 5] = "?";
          }
          ++index26;
          matrx[index26, 0] = "March Mode";
          float oldval47 = num31;
          if (this.game.Data.UnitObj[this.IList[attnr].IUnr].moveMode == 1)
          {
            if (this.CombatRound == 1)
              num31 *= 0.1f;
            if (this.CombatRound == 2)
              num31 *= 0.3f;
            if (this.CombatRound == 3)
              num31 *= 0.5f;
            if (this.CombatRound == 4)
              num31 *= 0.7f;
            if (this.CombatRound == 5)
              num31 *= 0.9f;
          }
          this.AddDetail("Attval after March Mode penalty: " + Conversion.Str((object) num31));
          matrx[index26, 1] = this.GetPercentChange(num31, oldval47);
          matrx[index26, 2] = Conversions.ToString(num31);
          if (flag1)
          {
            matrx[index26, 1] = "?";
            matrx[index26, 2] = "?";
          }
        }
        int index29 = index28 + 1;
        matrx[index29, 3] = "AI Bonus";
        float oldval48 = num39;
        int num42 = 0;
        if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime].AI)
        {
          if ((double) this.game.Data.RuleVar[992] > 0.0)
            num42 = (int) Math.Round((double) this.game.Data.RuleVar[992]);
          int num43 = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime].AIHelpCombat + num42;
          if (this.customCombatObj.HasCustumCalls())
          {
            CustomCombatCalls customCombatObj = this.customCombatObj;
            combatClass = this;
            ref CombatClass local = ref combatClass;
            int forNr = defnr;
            int againstNr = attnr;
            int tHelpCombat = num43;
            num43 = customCombatObj.AIHelpCombatChanger(ref local, forNr, againstNr, tHelpCombat);
          }
          if (num43 > 0)
          {
            num39 += num39 * ((float) num43 / 100f);
            this.AddDetail("Defval, due to " + Conversion.Str((object) index3) + " AI Combat Bonus " + Conversion.Str((object) num39));
          }
        }
        matrx[index29, 4] = this.GetPercentChange(num39, oldval48);
        matrx[index29, 5] = Conversions.ToString(num39);
        if (flag2)
        {
          matrx[index29, 4] = "?";
          matrx[index29, 5] = "?";
        }
        if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[475] > 0.0)
        {
          ++index29;
          matrx[index29, 3] = "Battlegroup small size";
          float oldval49 = num39;
          if (this.game.HandyFunctionsObj.CheckIsBattlegroup(this.IList[defnr].IUnr) && (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.IList[defnr].IUnr) < (double) this.game.Data.RuleVar[476])
          {
            bool flag12 = true;
            if (this.customCombatObj.HasCustumCalls())
            {
              CustomCombatCalls customCombatObj = this.customCombatObj;
              combatClass = this;
              ref CombatClass local = ref combatClass;
              GameClass game = this.game;
              int attnr6 = attnr;
              int defnr6 = defnr;
              flag12 = customCombatObj.IndividualCombatCall_SmallSizeBGmodifierApplies(ref local, game, attnr6, defnr6);
            }
            if (flag12)
            {
              num39 = num39 * (float) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.IList[defnr].IUnr) / this.game.Data.RuleVar[476];
              this.AddDetail("Defval after penalty for small battlegroup size " + Conversion.Str((object) num39));
            }
          }
          matrx[index29, 4] = this.GetPercentChange(num39, oldval49);
          matrx[index29, 5] = Conversions.ToString(num39);
          if (flag2)
          {
            matrx[index29, 4] = "?";
            matrx[index29, 5] = "?";
          }
        }
        int index30 = index29 + 1;
        matrx[index30, 3] = "River";
        float oldval50 = num39;
        if (this.IList[defnr].IAttacker != 0 && !this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench & !(this.CombatType == 3 | this.CombatType == 4) && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0 && this.IList[defnr].IBreakTrough == 0 & this.game.Data.UnitObj[this.IList[defnr].IUnr].Map == this.CombatTarget.map && this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y, this.game.Data.UnitObj[this.IList[defnr].IUnr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map) == 1)
        {
          int index31 = this.game.HandyFunctionsObj.HexFacing(this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y, this.game.Data.UnitObj[this.IList[defnr].IUnr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map) - 1;
          int index32 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y].RiverType[index31];
          bool flag13 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.IList[defnr].IUnr].X, this.game.Data.UnitObj[this.IList[defnr].IUnr].Y].Bridge[index31];
          if (index32 > -1)
          {
            if (this.customCombatObj.HasCustumCalls())
            {
              float num44 = this.game.Data.RiverTypeObj[index32].AttackPenalty[unitGroup3];
              if (flag13)
                num44 *= this.game.Data.RuleVar[5];
              int num45 = (int) Math.Round((1.0 - (double) num44) * 100.0);
              string str5 = "";
              CustomCombatCalls customCombatObj = this.customCombatObj;
              combatClass = this;
              ref CombatClass local9 = ref combatClass;
              GameClass game = this.game;
              int attnr7 = attnr;
              int defnr7 = defnr;
              int num46 = counterattack ? 1 : 0;
              ref string local10 = ref str5;
              int riverHpMod = num45;
              int riverType = index32;
              int num47 = customCombatObj.IndividualCombatCall_RiverTypeAndLandscapeTypeModifier(ref local9, game, attnr7, defnr7, num46 != 0, ref local10, riverHpMod, 0, 0, riverType);
              num39 = (float) ((double) num39 * (double) num47 / 100.0);
              this.AddDetail("Defval after attack over river/bridge mod: " + Conversion.Str((object) num39));
              if (str5.Length > 0)
                str2 = str2 + "\r\n" + str5;
            }
            else
            {
              float num48 = this.game.Data.RiverTypeObj[index32].AttackPenalty[unitGroup3];
              if (flag13)
                num48 *= this.game.Data.RuleVar[5];
              num39 *= 1f - num48;
              this.AddDetail("Defval after attack over river/bridge mod: " + Conversion.Str((object) num39));
            }
          }
        }
        matrx[index30, 4] = this.GetPercentChange(num39, oldval50);
        matrx[index30, 5] = Conversions.ToString(num39);
        if (flag2)
        {
          matrx[index30, 4] = "?";
          matrx[index30, 5] = "?";
        }
        int index33 = index30 + 1;
        matrx[index33, 3] = "Overstack";
        float oldval51 = num39;
        if (this.IList[defnr].IAttacker == 0 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0)
        {
          num39 *= this.CrowdingDefMod;
          this.AddDetail("defval after Crowding def Mod: " + Conversion.Str((object) num39));
        }
        if (this.IList[defnr].IAttacker == 1 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0 && !(this.CombatType == 3 | this.CombatType == 4))
        {
          num39 *= this.CrowdingAttMod;
          this.AddDetail("defval after Crowding att Mod: " + Conversion.Str((object) num39));
        }
        int num49 = this.IList[defnr].IAttacker == 1 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2 ? 1 : 0;
        matrx[index33, 4] = this.GetPercentChange(num39, oldval51);
        matrx[index33, 5] = Conversions.ToString(num39);
        if (flag2)
        {
          matrx[index33, 4] = "?";
          matrx[index33, 5] = "?";
        }
        if ((double) this.game.Data.RuleVar[835] > 0.0)
        {
          ++index33;
          matrx[index33, 3] = "Airbase surprise";
          oldval51 = num39;
          float num50 = this.game.Data.RuleVar[835];
          if (this.CombatRound > 1)
            num50 -= (float) (this.CombatRound - 1) * this.game.Data.RuleVar[836];
          if (this.game.Data.Product == 7)
            num50 *= 0.66f;
          if ((double) num50 > 0.0)
          {
            float Number2 = (float) (1.0 - (double) num50 / 100.0);
            if (this.IList[defnr].IAttacker == 0 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2 && this.game.Data.UnitObj[this.IList[defnr].IUnr].X == this.TargetX & this.game.Data.UnitObj[this.IList[defnr].IUnr].Y == this.TargetY)
            {
              num39 *= Number2;
              this.AddDetail("defval after penalty (" + Conversion.Str((object) Number2) + ") for airfield under attack: " + Conversion.Str((object) num39));
            }
          }
        }
        matrx[index33, 4] = this.GetPercentChange(num39, oldval51);
        matrx[index33, 5] = Conversions.ToString(num39);
        if (flag2)
        {
          matrx[index33, 4] = "?";
          matrx[index33, 5] = "?";
        }
        if (this.game.Data.Product == 7)
        {
          if ((double) this.game.Data.RuleVar[835] > 0.0)
          {
            ++index26;
            matrx[index26, 0] = "Airbase surprise";
            oldval51 = num31;
            float num51 = this.game.Data.RuleVar[835];
            if (this.CombatRound > 1)
              num51 -= (float) (this.CombatRound - 1) * this.game.Data.RuleVar[836];
            if ((double) num51 > 0.0)
            {
              float Number3 = (float) (1.0 - (double) num51 / 100.0);
              if (this.IList[attnr].IAttacker == 0 & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 2 && this.game.Data.UnitObj[this.IList[attnr].IUnr].X == this.TargetX & this.game.Data.UnitObj[this.IList[attnr].IUnr].Y == this.TargetY)
              {
                num31 *= Number3;
                this.AddDetail("attval after penalty (" + Conversion.Str((object) Number3) + ") for airfield under attack: " + Conversion.Str((object) num31));
              }
            }
          }
          matrx[index26, 1] = this.GetPercentChange(num31, oldval51);
          matrx[index26, 2] = Conversions.ToString(num31);
          if (flag2)
          {
            matrx[index26, 1] = "?";
            matrx[index26, 2] = "?";
          }
        }
        int index34 = index26 + 1;
        matrx[index34, 0] = "Overstack";
        float oldval52 = num31;
        if (this.IList[attnr].IAttacker == 0 & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0)
        {
          float Number4 = this.CrowdingDefMod;
          if ((double) Number4 < 1.0)
            Number4 = (float) ((1.0 + (double) Number4 + (double) Number4 + (double) Number4 * (1.0 / (double) Number4 - 1.0)) / (3.0 + (1.0 / (double) Number4 - 1.0)));
          num31 *= Number4;
          this.AddDetail("attval after Crowding def Mod(x%) (" + Conversion.Str((object) Number4) + "): " + Conversion.Str((object) num31));
        }
        if (this.IList[attnr].IAttacker == 1 & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0)
        {
          float Number5 = !(this.CombatType == 3 | this.CombatType == 4) ? this.CrowdingAttMod : this.CrowdingAttArtMod;
          if ((double) Number5 < 1.0)
            Number5 = (float) ((1.0 + (double) Number5 + (double) Number5 + (double) Number5 * (1.0 / (double) Number5 - 1.0)) / (3.0 + (1.0 / (double) Number5 - 1.0)));
          num31 *= Number5;
          if (this.CombatType == 3 | this.CombatType == 4)
          {
            matrx[index34, 0] = "Overstack Art";
            this.AddDetail("attval after Crowding att ART Mod (x%) (" + Conversion.Str((object) Number5) + "): " + Conversion.Str((object) num31));
          }
          else
            this.AddDetail("attval after Crowding att Mod (x%) (" + Conversion.Str((object) Number5) + "): " + Conversion.Str((object) num31));
        }
        if (this.IList[attnr].IAttacker == 1 & this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 2 & this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater != 2)
        {
          float Number6 = this.CrowdingAttAirMod;
          if ((double) Number6 < 1.0)
            Number6 = (float) ((1.0 + (double) Number6 + (double) Number6 + (double) Number6 * (1.0 / (double) Number6 - 1.0)) / (3.0 + (1.0 / (double) Number6 - 1.0)));
          num31 *= Number6;
          matrx[index34, 0] = "Overstack Air";
          this.AddDetail("attval after Crowding att AIR Mod (x%) (" + Conversion.Str((object) Number6) + "): " + Conversion.Str((object) num31));
        }
        matrx[index34, 1] = this.GetPercentChange(num31, oldval52);
        matrx[index34, 2] = Conversions.ToString(num31);
        if (flag1)
        {
          matrx[index34, 1] = "?";
          matrx[index34, 2] = "?";
        }
        bool flag14 = true;
        if (this.game.Data.Product >= 6)
        {
          if (this.CombatType == 3 | this.CombatType == 4)
            flag14 = false;
          if (this.InterceptFire)
            flag14 = false;
          if (this.UList[this.IList[attnr].IUlistNr].USupportInterceptFire)
            flag14 = false;
        }
        if (flag14)
        {
          ++index33;
          matrx[index33, 3] = "Divisional";
          if (this.game.Data.Product >= 6)
            matrx[index33, 3] = "Multi-Unit";
          float oldval53 = num39;
          index3 = this.game.HandyFunctionsObj.GetDivBonus(this.IList[defnr].IUnr);
          if (index3 > 0)
          {
            num39 += num39 * ((float) index3 / 100f);
            this.AddDetail("Defval, due to " + Conversion.Str((object) index3) + "% div bonus: " + Conversion.Str((object) num39));
          }
          matrx[index33, 4] = this.GetPercentChange(num39, oldval53);
          matrx[index33, 5] = Conversions.ToString(num39);
          if (flag2)
          {
            matrx[index33, 4] = "?";
            matrx[index33, 5] = "?";
          }
        }
        if (this.customCombatObj.HasCustumCalls())
        {
          int num52 = this.customCombatObj.NumberOfMods();
          for (index3 = 1; index3 <= num52; ++index3)
          {
            float oldval54 = num31;
            string str6 = "";
            CustomCombatCalls customCombatObj = this.customCombatObj;
            int modNr = index3;
            combatClass = this;
            ref CombatClass local11 = ref combatClass;
            GameClass game = this.game;
            int attnr8 = attnr;
            int defnr8 = defnr;
            int num53 = counterattack ? 1 : 0;
            double attval = (double) num31;
            ref string local12 = ref str6;
            num31 = customCombatObj.IndividualCombatCall_AttValModder(modNr, ref local11, game, attnr8, defnr8, num53 != 0, (float) attval, ref local12);
            if ((double) num31 != (double) oldval54)
            {
              ++index34;
              matrx[index34, 0] = this.customCombatObj.GetModName(index3);
              if ((double) num31 > (double) oldval54)
                num31 = num31;
              matrx[index34, 1] = this.GetPercentChange(num31, oldval54);
              matrx[index34, 2] = Conversions.ToString(num31);
              if (flag1)
              {
                matrx[index34, 1] = "?";
                matrx[index34, 2] = "?";
              }
            }
            if (str6.Length > 0)
              str2 = str2 + "\r\n" + str6;
          }
        }
        if (this.customCombatObj.HasCustumCalls())
        {
          int num54 = this.customCombatObj.NumberOfMods();
          for (index3 = 1; index3 <= num54; ++index3)
          {
            float oldval55 = num39;
            string str7 = "";
            CustomCombatCalls customCombatObj = this.customCombatObj;
            int modNr = index3;
            combatClass = this;
            ref CombatClass local13 = ref combatClass;
            GameClass game = this.game;
            int attnr2 = attnr;
            int defnr9 = defnr;
            int num55 = counterattack ? 1 : 0;
            double defval = (double) num39;
            ref string local14 = ref str7;
            num39 = customCombatObj.IndividualCombatCall_DefValModder(modNr, ref local13, game, attnr2, defnr9, num55 != 0, (float) defval, ref local14);
            if ((double) num39 != (double) oldval55)
            {
              ++index33;
              matrx[index33, 3] = this.customCombatObj.GetModName(index3);
              matrx[index33, 4] = this.GetPercentChange(num39, oldval55);
              matrx[index33, 5] = Conversions.ToString(num39);
              if (flag2)
              {
                matrx[index33, 4] = "?";
                matrx[index33, 5] = "?";
              }
            }
            if (str7.Length > 0)
              str2 = str2 + "\r\n" + str7;
          }
        }
        int index35 = index34 + 1;
        if (index35 >= 31)
          index3 = index3;
        matrx[index35, 0] = "After mods";
        matrx[index35, 1] = "";
        matrx[index35, 2] = Conversions.ToString(num31);
        int index36 = index33 + 1;
        if (index36 >= 31)
          index3 = index3;
        matrx[index36, 3] = "After mods";
        matrx[index36, 4] = "";
        matrx[index36, 5] = Conversions.ToString(num39);
        if ((double) num31 == 0.0)
          num31 = num31;
        string s2 = "AFTER ALL MODS: Attval=" + Conversion.Str((object) num31) + ", DefVal= " + Conversion.Str((object) num39);
        this.AddDetail(s2);
        string txt;
        if ((double) this.game.Data.RuleVar[431] < 1.0)
          txt = str2 + "\r\n" + "After modifications: Attack score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num31, 2))) + " VS Defensive score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num39, 2)));
        else if (!this.game.Data.FOWOn)
        {
          if (this.IList[attnr].IvisibleFromRound >= this.CombatRound & this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime != this.game.Data.Turn)
            txt = "Attack score = " + Strings.Trim(Conversion.Str((object) Math.Round((double) num31, 2))) + " [Hidden] VS Defensive score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num39, 2)));
          else if (this.IList[defnr].IvisibleFromRound >= this.CombatRound & this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime != this.game.Data.Turn)
            txt = "Attack score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num31, 2))) + " VS Defensive score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num39, 2))) + " [Hidden]";
          else
            txt = str2 + "\r\n" + "After modifications: Attack score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num31, 2))) + " VS Defensive score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num39, 2)));
        }
        else if (this.IList[attnr].IvisibleFromRound >= this.CombatRound & this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime != this.game.Data.Turn)
          txt = "Attack score = ? VS Defensive score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num39, 2)));
        else if (this.IList[defnr].IvisibleFromRound >= this.CombatRound & this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime != this.game.Data.Turn)
          txt = "Attack score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num31, 2))) + " VS Defensive score=?";
        else
          txt = str2 + "\r\n" + "After modifications: Attack score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num31, 2))) + " VS Defensive score=" + Strings.Trim(Conversion.Str((object) Math.Round((double) num39, 2)));
        string str8 = txt;
        float num56;
        if ((double) powerPts1 > (double) powerPts2)
        {
          num56 = powerPts2 / powerPts1;
          if ((double) num56 < (double) this.game.Data.RuleVar[117])
            num56 = this.game.Data.RuleVar[117];
        }
        else if ((double) powerPts2 > (double) powerPts1)
        {
          num56 = powerPts2 / powerPts1;
          if ((double) num56 < (double) this.game.Data.RuleVar[117])
            num56 = this.game.Data.RuleVar[117];
        }
        else
          num56 = 1f;
        if ((double) num56 > (double) this.game.Data.RuleVar[118])
          num56 = this.game.Data.RuleVar[118];
        float num57 = (float) Conversion.Int((double) DrawMod.RandyNumber.Next(0, 10000) / 10000.0 * (double) num31);
        float num58 = (float) Conversion.Int((double) DrawMod.RandyNumber.Next(0, 10000) / 10000.0 * (double) num39);
        int num59 = 0;
        if ((double) num57 >= (double) num58)
          num59 = 1;
        int num60 = 0;
        if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].DepletingHitpointRule > 0 & num59 == 1 && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].PreventCounter == -1 & !this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench && (double) this.IList[defnr].IHp - (double) num57 > 0.0)
          num59 = 0;
        string str9 = "";
        string str10;
        if (this.game.Data.Product >= 6 && num59 == 0 && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].DepletingHitpointRule > 0)
        {
          bool flag15;
          if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench & this.IList[attnr].IBreakTrough > 0)
          {
            num57 *= 10f;
            flag15 = true;
          }
          string str11;
          if ((double) this.IList[defnr].IHp - (double) num57 <= 0.0 & (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench | (double) num57 >= (double) num58) | flag15 & (double) num57 >= (double) num58)
          {
            if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench & this.IList[attnr].IBreakTrough < 1)
            {
              num59 = 1;
              num60 = 3;
              this.IList[defnr].IHp = 0;
              str10 = str11 + " : SHIELDING DEPLETED";
              txt = txt + "\r\n" + "Result of attack is a RETREAT.";
              str9 = str9 + "\r\n" + "Result of attack is a RETREAT.";
            }
            else if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench)
            {
              this.IList[defnr].IHp = 0;
              num59 = 1;
              num60 = 1;
              str10 = str11 + " : CLOSE DISTANCE KILL";
              txt = txt + "\r\n" + "Result of attack is a KILL.";
              str9 = str9 + "\r\n" + "Result of attack is a KILL.";
            }
            else
            {
              this.IList[defnr].IHp = 0;
              if ((double) num57 >= (double) num58)
              {
                num59 = 1;
                num60 = 1;
                str10 = str11 + " : SHIELDING DEPLETED";
                txt = txt + "\r\n" + "Result of attack is a KILL.";
                str9 = str9 + "\r\n" + "Result of attack is a KILL.";
              }
              else
              {
                num59 = 1;
                num60 = 3;
                str10 = str11 + " : SHIELDING DEPLETED";
                txt = txt + "\r\n" + "Result of attack is a RETREAT.";
                str9 = str9 + "\r\n" + "Result of attack is a RETREAT.";
              }
            }
          }
          else if (this.IList[defnr].IHp > 0)
          {
            if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench | (double) num57 >= (double) num58)
            {
              this.IList[defnr].IHp = (int) Math.Round((double) ((float) this.IList[defnr].IHp - num57));
              num59 = 0;
              str10 = str11 + " : SHIELDING ABSORBED HIT";
              txt = txt + "\r\n" + "Shielding down to " + this.IList[defnr].IHp.ToString() + ".";
              str9 = str9 + "\r\n" + "Shielding down to " + this.IList[defnr].IHp.ToString() + ".";
            }
            else
            {
              str10 = str11 + " : SHIELDING INTACT";
              txt = txt + "\r\n" + "Shielding has not been drained.";
              str9 = str9 + "\r\n" + "Shielding has not been drained.";
            }
          }
        }
        if (this.game.Data.Product == 6 & this.CombatType == 1 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].EP > 0 & !counterattack & this.IList[attnr].AttackCount == 0 && this.IList[defnr].IEntrench > 0 && (double) this.UList[this.IList[attnr].IUlistNr].UepEpMaxMod > 0.0 & this.IList[defnr].IEntrench > 0)
        {
          index3 = (int) Math.Round(100.0 * (double) this.UList[this.IList[attnr].IUlistNr].UepEpMaxMod / 100.0);
          if (index3 > 100)
            index3 = 100;
          if (!this.previewMode)
          {
            this.game.Data.SFObj[this.IList[attnr].ISFNr].EP = Math.Min(this.game.Data.SFObj[this.IList[attnr].ISFNr].EP - 1, (int) Math.Round((double) this.game.Data.SFObj[this.IList[attnr].ISFNr].EP / 2.0));
            if (0 > this.game.Data.SFObj[this.IList[attnr].ISFNr].EP)
              this.game.Data.SFObj[this.IList[attnr].ISFNr].EP = 0;
          }
          if (num59 == 1)
            index3 *= 2;
          if (index3 > this.IList[defnr].IEntrench)
            index3 = this.IList[defnr].IEntrench;
          if (index3 > 0)
            this.IList[defnr].IEntrench -= index3;
          txt = txt + "\r\n" + "Sapper action, using EP, reduces enemy entrenchment by -" + index3.ToString() + ".";
          if (this.IList[defnr].IEntrench <= 0)
            txt += " Enemy entrenchment fully depleted.";
        }
        if (num59 == 1)
        {
          int num61 = (int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * 100f) + 1f));
          int killPercent = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].KillPercent;
          if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType > -1 & (this.CombatType == 3 | this.CombatType == 4))
            killPercent = this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType].KillPercent;
          if (killPercent >= num61)
            num60 = 1;
          if (num60 == 0)
          {
            int num62 = !(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType > -1 & (this.CombatType == 3 | this.CombatType == 4)) ? this.game.Data.SFTypeObj[this.IList[attnr].ISFType].RetreatPercent : this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtSFType].RetreatPercent;
            if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0 & !(this.CombatType == 3 | this.CombatType == 4) & (double) this.game.Data.RuleVar[895] > 0.0)
            {
              num62 = (int) Math.Round((double) ((float) num62 * this.game.Data.RuleVar[895]));
              txt = txt + "\r\n" + "Chance for retreat score was modified by " + this.game.Data.RuleVar[895].ToString() + " due to using artillery in a frontal attack.";
            }
            if (killPercent + num62 >= num61)
              num60 = 3;
            if (num60 == 0)
              num60 = 4;
          }
          if (num60 == 1 && this.IList[defnr].IAttacker == 0 && (double) this.game.Data.SFTypeObj[this.IList[defnr].ISFType].KilltoRetreatChance > (double) VBMath.Rnd() * 100.0)
          {
            s2 += ", Succesfull Kill to Retreat by defender ";
            txt = txt + "\r\n" + "Defender manages to avoid kill result and turn it into retreat result.";
            num60 = 3;
          }
          if (num60 == 3 && this.IList[defnr].IAttacker == 0 && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2 && this.game.Data.UnitObj[this.IList[defnr].IUnr].X == this.TargetX)
          {
            int num63 = this.game.Data.UnitObj[this.IList[defnr].IUnr].Y == this.TargetY & this.game.Data.UnitObj[this.IList[defnr].IUnr].Map == this.TargetMap ? 1 : 0;
          }
          if (num60 == 3 & this.IList[defnr].IRetreatMode == 1 && this.IList[defnr].IRetreat == this.CombatRound)
          {
            s2 = ", Because sub was already forced retreating retreat target is changed to pinned.";
            txt = txt + "\r\n" + "Retreat result is handled as pinned result because target was already retreating.";
            num60 = 4;
          }
          if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].SlotNumber > -1 && this.IList[attnr].IAttacker == 1)
          {
            int[] areaCode = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].AreaCode;
            int[] numArray = areaCode;
            int slotNumber = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].SlotNumber;
            int index37 = slotNumber;
            int num64 = areaCode[slotNumber] + 1;
            numArray[index37] = num64;
          }
          if (!this.previewMode && this.customCombatObj.HasCustumCalls())
          {
            string str12 = "";
            CustomCombatCalls customCombatObj = this.customCombatObj;
            int result = num60;
            combatClass = this;
            ref CombatClass local15 = ref combatClass;
            GameClass game = this.game;
            int attnr9 = attnr;
            int defnr10 = defnr;
            int num65 = counterattack ? 1 : 0;
            double attval = (double) num57;
            double defval = (double) num58;
            ref string local16 = ref str12;
            num60 = customCombatObj.IndividualCombatCall_ResultModifier(result, ref local15, game, attnr9, defnr10, num65 != 0, (float) attval, (float) defval, ref local16);
            if (str12.Length > 1)
              txt = txt + "\r\n" + str12;
            if (num60 < 1)
              num59 = 0;
            if (num60 > 0)
              num59 = 1;
          }
          int num66 = 0;
          if ((double) this.game.Data.RuleVar[431] > 0.0)
          {
            int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
            for (int index38 = 0; index38 <= landscapeTypeCounter; ++index38)
            {
              if (this.game.Data.LandscapeTypeObj[index38].HidePts > num66)
                num66 = this.game.Data.LandscapeTypeObj[index38].HidePts;
            }
            if (num66 < 50)
              num66 = 50;
            int num67 = (int) Math.Round(800.0 / (double) (int) Math.Round((double) (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55])));
            if (this.CombatType == 3)
            {
              if (this.IList[attnr].IAttacker == 1)
              {
                if (this.IList[attnr].IdirectFire)
                {
                  float num68 = (float) (int) Math.Round((double) ((float) Math.Max(10, num66 - this.GetIndividualHide(attnr)) / (float) num67 / (float) Math.Max(this.IList[defnr].AttackedCount, 1)) * (double) this.UList[this.IList[defnr].IUlistNr].ULos[this.IList[attnr].IUlistNr] / 100.0);
                  Individual[] ilist = this.IList;
                  Individual[] individualArray = ilist;
                  int index39 = attnr;
                  int index40 = index39;
                  individualArray[index40].IcoverPoints = ilist[index39].IcoverPoints - num68;
                }
                else
                {
                  float num69 = (float) this.GetUnmodifiedReconOnHexOfTargettedIndividual(attnr) / (float) num67;
                  Individual[] ilist = this.IList;
                  Individual[] individualArray = ilist;
                  int index41 = attnr;
                  int index42 = index41;
                  individualArray[index42].IcoverPoints = ilist[index41].IcoverPoints - num69;
                }
              }
              else if (this.IList[attnr].IAttacker == 0)
              {
                if (this.IList[attnr].IdirectFire)
                {
                  if (Information.IsNothing((object) this.IList[attnr].IdirectFireDef))
                  {
                    if (this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
                    {
                      float num70 = (float) Math.Max(10, num66 - this.GetIndividualHide(attnr)) / (float) num67 / (float) Math.Max(this.IList[defnr].AttackedCount, 1);
                      float num71 = (float) (int) Math.Round((double) (index3 * this.UList[this.IList[defnr].IUlistNr].ULos[this.IList[attnr].IUlistNr]) / 100.0);
                      Individual[] ilist = this.IList;
                      Individual[] individualArray = ilist;
                      int index43 = attnr;
                      int index44 = index43;
                      individualArray[index44].IcoverPoints = ilist[index43].IcoverPoints - num71;
                    }
                    else
                    {
                      float num72 = (float) this.GetUnmodifiedReconOnHexOfTargettedIndividual(attnr) / (float) num67;
                      Individual[] ilist = this.IList;
                      Individual[] individualArray = ilist;
                      int index45 = attnr;
                      int index46 = index45;
                      individualArray[index46].IcoverPoints = ilist[index45].IcoverPoints - num72;
                    }
                  }
                }
                else
                {
                  float targettedIndividual = (float) this.GetUnmodifiedReconOnHexOfTargettedIndividual(attnr);
                  Individual[] ilist = this.IList;
                  Individual[] individualArray = ilist;
                  int index47 = attnr;
                  int index48 = index47;
                  individualArray[index48].IcoverPoints = ilist[index47].IcoverPoints - targettedIndividual;
                }
              }
              else
              {
                float num73 = (float) Math.Max(10, num66 - this.GetIndividualHide(attnr)) / (float) num67 / (float) Math.Max(this.IList[defnr].AttackedCount, 1);
                Individual[] ilist = this.IList;
                Individual[] individualArray = ilist;
                int index49 = attnr;
                int index50 = index49;
                individualArray[index50].IcoverPoints = ilist[index49].IcoverPoints - num73;
              }
              if ((double) this.IList[attnr].IcoverPoints < 0.0)
                this.IList[attnr].IcoverPoints = 0.0f;
            }
          }
          if (this.game.Data.Product >= 6 && this.IList[defnr].AttackedCount == 0)
          {
            if ((double) this.game.Data.RuleVar[467] > 0.0 && (double) this.IList[defnr].ILisAmmoMod < 1.0)
            {
              index3 = (int) Math.Round((double) this.game.Data.RuleVar[467]) - (int) Math.Round(Math.Ceiling((double) this.IList[defnr].ILisAmmoMod * (double) this.game.Data.RuleVar[467]));
              this.ReduceMor(defnr, index3);
            }
            if ((double) this.game.Data.RuleVar[468] > 0.0 && (double) this.IList[defnr].ILisAmmoMod < 1.0)
            {
              index3 = (int) Math.Round((double) this.game.Data.RuleVar[468]) - (int) Math.Round(Math.Ceiling((double) this.IList[defnr].ILisAmmoMod * (double) this.game.Data.RuleVar[468]));
              if (this.CombatType == 3 | this.CombatType == 4)
                index3 = (int) Math.Round((double) index3 / 2.0);
              this.ReduceAbsRdn(defnr, index3);
            }
          }
          if (num59 == 1)
          {
            if ((double) this.game.Data.RuleVar[438] > 0.0 && (double) this.IList[defnr].ILisAmmoMod < 1.0)
            {
              index3 = (int) Math.Round((double) this.game.Data.RuleVar[438]) - (int) Math.Round(Math.Ceiling((double) this.IList[defnr].ILisAmmoMod * (double) this.game.Data.RuleVar[438]));
              if (this.IList[defnr].IAttacker == 1)
                index3 *= 2;
              this.ReduceMor(defnr, index3);
            }
            if ((double) this.game.Data.RuleVar[431] > 0.0)
            {
              if (this.CombatType == 3)
              {
                if (this.IList[attnr].IAttacker == 1)
                {
                  if (this.IList[attnr].IdirectFire)
                    this.IList[defnr].IcoverPoints = 0.0f;
                  else if (DrawMod.RandyNumber.Next(0, (int) Math.Round((double) this.game.Data.RuleVar[56])) < this.GetEffectiveReconOnHexOfTargettedIndividual(defnr))
                    this.IList[defnr].IcoverPoints = 0.0f;
                }
                else if ((double) this.game.Data.RuleVar[419] > 0.0)
                {
                  if (!Information.IsNothing((object) this.IList[attnr].IdirectFireDef))
                  {
                    if (this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
                      this.IList[defnr].IcoverPoints = 0.0f;
                    else if (DrawMod.RandyNumber.Next(0, (int) Math.Round((double) this.game.Data.RuleVar[56])) < this.GetEffectiveReconOnHexOfTargettedIndividual(defnr))
                      this.IList[defnr].IcoverPoints = 0.0f;
                  }
                }
                else if (DrawMod.RandyNumber.Next(0, (int) Math.Round((double) this.game.Data.RuleVar[56])) < this.GetEffectiveReconOnHexOfTargettedIndividual(defnr))
                  this.IList[defnr].IcoverPoints = 0.0f;
              }
              else
                this.IList[defnr].IcoverPoints = 0.0f;
            }
            switch (num60)
            {
              case 1:
                this.IList[defnr].IKilled = this.CombatRound;
                this.IList[defnr].IRetreat = 0;
                this.IList[defnr].IRetreatMode = 0;
                this.AddXp(attnr, (int) Math.Round((double) this.game.Data.RuleVar[119] * (double) num56 * ((double) this.game.Data.UnitObj[this.IList[defnr].IUnr].SupplyConsume / 100.0)));
                s2 = ", Results in KILL.";
                str10 += " : KILL";
                txt = txt + "\r\n" + "Result of attack is a KILL.";
                Individual[] ilist1 = this.IList;
                Individual[] individualArray1 = ilist1;
                int index51 = attnr;
                int index52 = index51;
                individualArray1[index52].ItotalKills = ilist1[index51].ItotalKills + 1;
                Individual[] ilist2 = this.IList;
                Individual[] individualArray2 = ilist2;
                int index53 = attnr;
                int index54 = index53;
                individualArray2[index54].ItotalKillsPowerPoints = ilist2[index53].ItotalKillsPowerPoints + this.game.Data.SFTypeObj[this.IList[defnr].ISFType].PowerPts;
                if (!counterattack)
                {
                  Individual[] ilist3 = this.IList;
                  Individual[] individualArray3 = ilist3;
                  int index55 = attnr;
                  int index56 = index55;
                  individualArray3[index56].IDammageDone = ilist3[index55].IDammageDone + this.game.Data.SFTypeObj[this.IList[defnr].ISFType].PowerPts;
                }
                if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].KillIsRegVar > -1)
                {
                  int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime].RegimeSlot;
                  int[] numArray = regimeSlot;
                  int killIsRegVar = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].KillIsRegVar;
                  int index57 = killIsRegVar;
                  int num74 = regimeSlot[killIsRegVar] + 1;
                  numArray[index57] = num74;
                  break;
                }
                break;
              case 3:
                int num75 = 1;
                str10 += " : RETREAT";
                if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea & this.CombatType == 2)
                  num75 = 0;
                if (this.IList[defnr].IRetreat > 0)
                  num75 = 0;
                if (num75 == 1)
                {
                  this.IList[defnr].IRetreat = this.CombatRound;
                  this.IList[defnr].IRetreatMode = 1;
                  s2 = ", Results in RETREAT";
                  txt = txt + "\r\n" + "Result of attack is a forced RETREAT.";
                }
                else
                {
                  s2 = ", Results in RETREAT score.. which is handled as mor/rdn loss. Because retreat is not allowed with this type of combat.";
                  txt = txt + "\r\n" + "Result of attack is the penalties of a RETREAT.";
                }
                this.AddXp(attnr, (int) Math.Round((double) this.game.Data.RuleVar[120] * (double) num56 * ((double) this.game.Data.UnitObj[this.IList[defnr].IUnr].SupplyConsume / 100.0)));
                this.ReduceRdn(defnr, (int) Math.Round((double) this.game.Data.RuleVar[122]));
                this.ReduceMor(defnr, (int) Math.Round((double) this.game.Data.RuleVar[124]));
                if ((double) this.game.Data.RuleVar[431] > 0.0 & this.game.Data.Product >= 6)
                  this.ReduceEntr_AdvancedCombatRecon(attnr, defnr, (int) Math.Round((double) this.game.Data.RuleVar[126]));
                else
                  this.ReduceEntr(defnr, (int) Math.Round((double) this.game.Data.RuleVar[126]));
                if (!counterattack)
                {
                  Individual[] ilist4 = this.IList;
                  Individual[] individualArray4 = ilist4;
                  int index58 = attnr;
                  int index59 = index58;
                  individualArray4[index59].IDammageDone = ilist4[index58].IDammageDone + this.game.Data.SFTypeObj[this.IList[defnr].ISFType].PowerPts;
                  break;
                }
                break;
              case 4:
                s2 = ", Results in PINNED ";
                str10 += " : PINNED";
                txt = txt + "\r\n" + "Result of attack is a PINNED hit.";
                this.AddXp(attnr, (int) Math.Round((double) this.game.Data.RuleVar[121] * (double) num56 * ((double) this.game.Data.UnitObj[this.IList[defnr].IUnr].SupplyConsume / 100.0)));
                this.ReduceRdn(defnr, (int) Math.Round((double) this.game.Data.RuleVar[123]));
                if ((double) this.game.Data.RuleVar[431] > 0.0 & this.game.Data.Product >= 6)
                  this.ReduceEntr_AdvancedCombatRecon(attnr, defnr, (int) Math.Round((double) this.game.Data.RuleVar[(int) sbyte.MaxValue]));
                else
                  this.ReduceEntr(defnr, (int) Math.Round((double) this.game.Data.RuleVar[(int) sbyte.MaxValue]));
                this.ReduceMor(defnr, (int) Math.Round((double) this.game.Data.RuleVar[125]));
                break;
            }
            if (num60 == 1 | num60 == 3 && this.game.Data.UnitObj[this.IList[defnr].IUnr].SupplyConsume >= (int) Math.Round((double) (VBMath.Rnd() * 100f)) && (double) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ChanceOnDeathIfMakeHit > 0.0 && this.IList[attnr].IAttacker == 1 && (double) VBMath.Rnd() < (double) this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ChanceOnDeathIfMakeHit)
            {
              this.IList[attnr].IKilled = this.CombatRound;
              this.IList[attnr].IRetreat = 0;
              this.IList[attnr].IRetreatMode = 0;
              string str13 = txt + "\r\n";
              str10 += " : ACCIDENT";
              txt = str13 + "However due to enemy last second enemy counteractions and/or accidents the attacker gets KILLED as well in the combat.";
            }
            if (!counterattack)
              this.ReduceAbsRdn(attnr, this.game.Data.SFTypeObj[this.IList[attnr].ISFType].RdnLossPerAttack);
            if (!counterattack)
              this.IList[attnr].ISuccesfullAttack = this.CombatRound;
            if (this.game.Data.Product == 6)
              this.IList[defnr].ILastHit = this.CombatRound;
            else if (!counterattack)
              this.IList[defnr].ILastHit = this.CombatRound;
            Individual[] ilist5 = this.IList;
            Individual[] individualArray5 = ilist5;
            int index60 = attnr;
            int index61 = index60;
            individualArray5[index61].ItotalHits = ilist5[index60].ItotalHits + 1;
          }
          else
            s2 = ", Extra attack after target is already forced retreating results in MISS.";
        }
        else
        {
          if (!counterattack)
            this.ReduceAbsRdn(attnr, this.game.Data.SFTypeObj[this.IList[attnr].ISFType].RdnLossPerAttack);
          s2 = ", Results in MISS.";
          txt = txt + "\r\n" + "Result of attack is a MISS.";
        }
        if (this.IList[attnr].IAttacker == 1 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AntiStrucPts > 0 & this.IList[attnr].ILastAttackDone < this.CombatRound && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].Regime, this.AttackerRegime))
        {
          if (this.IList[attnr].Istockpile)
          {
            int antiStrucPts = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AntiStrucPts;
            int num76 = (int) Math.Round(Conversion.Int((double) (int) Math.Round(0.33 * (double) antiStrucPts + 0.66 * (double) antiStrucPts * (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.IList[attnr].IUnr].X, this.game.Data.UnitObj[this.IList[attnr].IUnr].Y)) * ((double) this.IList[attnr].IRdn / 100.0)));
            if (num76 == 0 && (double) VBMath.Rnd() < (double) this.IList[attnr].IRdn / 100.0)
              num76 = 1;
            int Number7 = (int) Math.Round((double) (int) Math.Round((double) VBMath.Rnd() * ((double) num76 + 0.5)) / (double) (this.IList[attnr].AttackedCount + 1));
            if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 2 && this.CombatType != 6)
              Number7 = (int) Math.Round((double) ((float) Number7 * this.game.Data.RuleVar[128]));
            if (!counterattack)
              this.AntiStrucDam += Number7;
            if (!counterattack & Number7 > 0)
            {
              s2 = s2 + ", +" + Conversion.Str((object) Number7) + " AntiStruc Dam";
              txt = txt + "\r\n" + "Result of attack is " + Strings.Trim(Conversion.Str((object) Number7)) + " anti structural damage." + "\r\n" + "Total anti-structural damage now: " + Strings.Trim(Conversion.Str((object) this.AntiStrucDam));
            }
          }
          else
          {
            s2 = s2 + ", +" + Conversion.Str((object) 0) + " AntiStruc Dam because no stockpile available.";
            txt = txt + "\r\n" + "Result of attack is " + Strings.Trim(Conversion.Str((object) 0)) + " anti structural damage because no stockpile available." + "\r\n" + "Total anti-structural damage now: " + Strings.Trim(Conversion.Str((object) this.AntiStrucDam));
          }
        }
        if (!counterattack)
          this.IList[attnr].ILastAttackDone = this.CombatRound;
        if (!counterattack && !this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench | this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater > 0)
          this.IList[defnr].ILastTargeted = this.CombatRound;
        if (!counterattack)
        {
          Individual[] ilist6 = this.IList;
          Individual[] individualArray6 = ilist6;
          int index62 = attnr;
          int index63 = index62;
          individualArray6[index63].AttackCount = ilist6[index62].AttackCount + 1;
          if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2 && (double) num57 > 0.0)
          {
            Individual[] ilist7 = this.IList;
            Individual[] individualArray7 = ilist7;
            int index64 = attnr;
            int index65 = index64;
            individualArray7[index65].AttackCountAir = ilist7[index64].AttackCountAir + 1;
          }
          if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0 && (double) num57 > 0.0)
          {
            Individual[] ilist8 = this.IList;
            Individual[] individualArray8 = ilist8;
            int index66 = attnr;
            int index67 = index66;
            individualArray8[index67].AttackCountLand = ilist8[index66].AttackCountLand + 1;
          }
        }
        else
        {
          Individual[] ilist = this.IList;
          Individual[] individualArray = ilist;
          int index68 = attnr;
          int index69 = index68;
          individualArray[index69].ICounterAttacks = ilist[index68].ICounterAttacks + 1;
        }
        Individual[] ilist9 = this.IList;
        Individual[] individualArray9 = ilist9;
        int index70 = defnr;
        int index71 = index70;
        individualArray9[index71].AttackedCount = ilist9[index70].AttackedCount + 1;
        if (!counterattack)
          this.IList[defnr].ILastAttacked = this.CombatRound;
        if (this.customCombatObj.HasCustumCalls() && this.IList[attnr].AttackCount == 1 & !counterattack)
        {
          string str14 = "";
          CustomCombatCalls customCombatObj = this.customCombatObj;
          combatClass = this;
          ref CombatClass local17 = ref combatClass;
          GameClass game = this.game;
          int attnr10 = attnr;
          int defnr11 = defnr;
          ref string local18 = ref str14;
          if (customCombatObj.IndividualCombatCall_FirstAttackOfRound(ref local17, game, attnr10, defnr11, ref local18) > 0 & str14.Length > 0)
            txt = txt + "\r\n" + str14;
        }
        int landscapeType3 = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].LandscapeType;
        unitGroup2 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].UnitGroup;
        this.AddDetail(s2);
        if ((double) this.game.Data.RuleVar[431] < 1.0)
        {
          string str15 = str10;
          string title1;
          if (counterattack)
            title1 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[attnr].IID)) + ") counter-attacks ==> " + this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[defnr].IID)) + ")" + str15;
          else
            title1 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[attnr].IID)) + ") attacks ==> " + this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[defnr].IID)) + ")" + str15;
          this.AddReport(1, title1, txt, attnr + 10000, this.CombatRound, matrx);
          string title2;
          if (counterattack)
            title2 = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[defnr].IID)) + ") <== is counter-attacked by " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[attnr].IID)) + ")" + str15;
          else
            title2 = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[defnr].IID)) + ") <== is attacked by " + this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[attnr].IID)) + ")" + str15;
          this.AddReport(1, title2, txt, defnr + 10000, this.CombatRound, matrx);
        }
        else
        {
          string str16 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[attnr].IID)) + ")";
          string str17 = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[defnr].IID)) + ")";
          if (this.IList[attnr].IvisibleFromRound > this.CombatRound && this.game.Data.UnitObj[this.IList[attnr].IUnr].Regime != this.game.Data.Turn)
          {
            if (this.game.Data.FOWOn)
            {
              str16 = "Unknown enemy (?)";
              int index72 = 0;
              do
              {
                matrx[index72, 0] = "";
                matrx[index72, 1] = "";
                matrx[index72, 2] = "";
                ++index72;
              }
              while (index72 <= 60);
              txt = str8 + "\r\n" + str9;
            }
            else
              str16 += " [Hidden]";
          }
          if (this.IList[defnr].IvisibleFromRound > this.CombatRound)
          {
            if (this.game.Data.UnitObj[this.IList[defnr].IUnr].Regime != this.game.Data.Turn)
            {
              if (this.game.Data.FOWOn)
              {
                str17 = "Unknown enemy (?)";
                int index73 = 0;
                do
                {
                  matrx[index73, 3] = "";
                  matrx[index73, 4] = "";
                  matrx[index73, 5] = "";
                  ++index73;
                }
                while (index73 <= 60);
                txt = str8 + "\r\n" + str9;
              }
              else
                str17 += " [Hidden]";
            }
          }
          else
            txt = txt;
          string str18 = str10;
          this.AddReport(1, !counterattack ? str16 + " attacks ==> " + str17 + str18 : " counter-attacks ==> " + str17 + str18, txt, attnr + 10000, this.CombatRound, matrx);
          this.AddReport(1, !counterattack ? str17 + " <== is attacked by " + str16 + str18 : str17 + " <== is counter-attacked by " + str16 + str18, txt, defnr + 10000, this.CombatRound, matrx);
        }
      }
    }

    public void CheckCapitulation(bool afterStepsCheck)
    {
      if (afterStepsCheck && this.game.Data.Product >= 6 && this.CombatType == 3 | this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 9 | this.CombatType == 10 | this.CombatType == 11 | this.CombatType == 12)
      {
        int icounter = this.ICounter;
        for (int index = 0; index <= icounter; ++index)
        {
          if (this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0 && this.game.Data.SFTypeObj[this.IList[index].ISFType].EndCombatRound > 0 && this.game.Data.SFTypeObj[this.IList[index].ISFType].EndCombatRound >= this.CombatRound)
          {
            this.IList[index].IRetreat = this.CombatRound;
            this.IList[index].IRetreatMode = 2;
            this.AddReport(0, "Special Retreat", "This trooptype always retreat from this combat round onwards.", index + 10000, this.CombatRound);
          }
        }
      }
      int isfType;
      int num1;
      int num2;
      if (this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 9 | this.CombatType == 10 | this.CombatType == 11 | this.CombatType == 12)
      {
        int icounter = this.ICounter;
        for (int index1 = 0; index1 <= icounter; ++index1)
        {
          if (this.IList[index1].IAttacker == 0 & (this.IList[index1].IRetreat > 0 | this.IList[index1].IRetreated > 0) && this.IList[index1].IKilled == 0 & !this.IList[index1].ISurrenderTestDone)
          {
            int num3 = 0;
            if (this.IList[index1].IUnr == 124)
              index1 = index1;
            if ((double) this.IList[index1].IMor <= (double) this.game.Data.RuleVar[37] && (double) this.IList[index1].IRdn < (double) this.game.Data.RuleVar[301] & this.IList[index1].IRetreat == this.CombatRound)
            {
              this.IList[index1].ISurrenderTestDone = true;
              if ((double) VBMath.Rnd() > (double) this.IList[index1].IRdn / (double) this.game.Data.RuleVar[301])
                num3 = 1;
              else if (!(this.game.Data.Product >= 6 & this.IList[index1].IRetreatMode != 3))
                this.AddReport(0, "Capitulation test", "Morale is lower then " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[37])) + " and readiness is lower then " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[301])) + ". Readiness is " + this.IList[index1].IRdn.ToString() + ". Capitulate test must thus be done. Chance to capitulate is " + Strings.Trim(Conversion.Str((object) (int) Math.Round(100.0 - 100.0 * ((double) this.IList[index1].IRdn / (double) this.game.Data.RuleVar[301])))) + "%. Individual survives test.", index1 + 10000, this.CombatRound);
            }
            if (this.game.Data.Product >= 6 & this.IList[index1].IRetreatMode != 3)
              num3 = 0;
            if (num3 == 1)
            {
              this.AddReport(0, "Capitulation test : CAPITULATION", "Morale is lower then " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[37])) + " and readiness is lower then " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[301])) + ". Readiness is " + this.IList[index1].IRdn.ToString() + " Thus had " + Strings.Trim(Conversion.Str((object) (int) Math.Round(100.0 - 100.0 * ((double) this.IList[index1].IRdn / (double) this.game.Data.RuleVar[301])))) + "% chance to capitulate. Individual capitulates.", index1 + 10000, this.CombatRound);
              this.IList[index1].IKilled = 1;
              this.IList[index1].ICapitulate = true;
              if (this.game.Data.SFTypeObj[this.IList[index1].ISFType].KillIsRegVar > -1)
              {
                int[] regimeSlot = this.game.Data.RegimeObj[this.AttackerRegime].RegimeSlot;
                int[] numArray = regimeSlot;
                int killIsRegVar = this.game.Data.SFTypeObj[this.IList[index1].ISFType].KillIsRegVar;
                int index2 = killIsRegVar;
                int num4 = regimeSlot[killIsRegVar] + 1;
                numArray[index2] = num4;
              }
              this.AddDetail("A defender capitulates..");
              isfType = this.IList[index1].ISFType;
              if (this.IList[index1].IAttacker == 1)
              {
                num1 = this.AttackerRegime;
                num2 = this.DefenderRegime;
              }
              else
              {
                num1 = this.DefenderRegime;
                num2 = this.AttackerRegime;
              }
            }
          }
        }
      }
      if (this.CombatRound <= 30 || !(this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 9 | this.CombatType == 10 | this.CombatType == 11 | this.CombatType == 12))
        return;
      int icounter1 = this.ICounter;
      for (int index3 = 0; index3 <= icounter1; ++index3)
      {
        if (this.IList[index3].IAttacker == 1 && this.IList[index3].IKilled == 0)
        {
          this.IList[index3].IKilled = 1;
          this.IList[index3].ICapitulate = true;
          if (this.game.Data.SFTypeObj[this.IList[index3].ISFType].KillIsRegVar > -1)
          {
            int[] regimeSlot = this.game.Data.RegimeObj[this.DefenderRegime].RegimeSlot;
            int[] numArray = regimeSlot;
            int killIsRegVar = this.game.Data.SFTypeObj[this.IList[index3].ISFType].KillIsRegVar;
            int index4 = killIsRegVar;
            int num5 = regimeSlot[killIsRegVar] + 1;
            numArray[index4] = num5;
          }
          this.AddDetail("An attacker capitulates..");
          isfType = this.IList[index3].ISFType;
          if (this.IList[index3].IAttacker == 1)
          {
            num1 = this.AttackerRegime;
            num2 = this.DefenderRegime;
          }
          else
          {
            num1 = this.DefenderRegime;
            num2 = this.AttackerRegime;
          }
        }
      }
    }

    public int FindISlot(int iId)
    {
      int icounter = this.ICounter;
      for (int islot = 0; islot <= icounter; ++islot)
      {
        if (this.IList[islot].IID == iId)
          return islot;
      }
      return -1;
    }

    public int FindUSlot(int unr)
    {
      int ucounter = this.UCounter;
      for (int uslot = 0; uslot <= ucounter; ++uslot)
      {
        if (this.UList[uslot].UNr == unr)
          return uslot;
      }
      return -1;
    }

    public int FindPreventer(int defnr, int attnr)
    {
      if (defnr == -1)
        return -1;
      int isfType1 = this.IList[defnr].ISFType;
      int unitGroup1 = this.game.Data.SFTypeObj[isfType1].UnitGroup;
      int isfType2 = this.IList[attnr].ISFType;
      int unitGroup2 = this.game.Data.SFTypeObj[isfType2].UnitGroup;
      int iattacker = this.IList[defnr].IAttacker;
      int preventer = -1;
      int num1 = -1;
      int index1 = -1;
      if (this.game.Data.Product != 7 && this.game.Data.SFTypeObj[isfType2].ArtRange > 0 || (double) this.game.Data.RuleVar[493] > 0.0 && this.IList[defnr].IleftOutOfPartialAttack)
        return defnr;
      int num2 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) this.ICounter)) + 1;
      int index2 = num2;
      int num3 = 0;
      while (num3 != 1)
      {
        ++index2;
        if (index2 > this.ICounter)
          index2 = 0;
        if (index2 == num2)
          num3 = 1;
        int isfType3 = this.IList[index2].ISFType;
        if (this.IList[index2].IAttacker == iattacker & (this.IList[index2].IRetreatMode == 0 | this.IList[defnr].IRetreatMode > 0 & this.IList[index2].IRetreated == 0) & this.IList[index2].IKilled == 0)
        {
          int isfType4 = this.IList[index2].ISFType;
          int unitGroup3 = this.game.Data.SFTypeObj[isfType4].UnitGroup;
          if (this.game.Data.UnitObj[this.IList[index2].IUnr].X == this.game.Data.UnitObj[this.IList[defnr].IUnr].X & this.game.Data.UnitObj[this.IList[index2].IUnr].Y == this.game.Data.UnitObj[this.IList[defnr].IUnr].Y | this.game.Data.SFTypeObj[this.IList[index2].ISFType].Theater >= 2 && this.IList[index2].AttackedCount < this.game.Data.SFTypeObj[isfType4].MaxAttacked | this.game.Data.SFTypeObj[isfType4].MaxPreventPointsUsed >= 9999)
          {
            int preventCounter = this.game.Data.SFTypeObj[isfType4].PreventCounter;
            for (int index3 = 0; index3 <= preventCounter; ++index3)
            {
              if (this.game.Data.SFTypeObj[isfType4].PreventHitOn[index3] == unitGroup1 | this.game.Data.SFTypeObj[isfType4].PreventHitOn[index3] == -1 && this.game.Data.SFTypeObj[isfType4].MaxPreventPointsUsed >= 9999 | 0 < this.game.Data.SFTypeObj[isfType1].MaxPreventPointsGiven - this.IList[defnr].IPreventPointsGiven && 0 < this.game.Data.SFTypeObj[isfType4].MaxPreventPointsUsed - this.IList[index2].IPreventPointsUsed && this.game.Data.SFTypeObj[isfType4].PreventHitFrom[index3] == unitGroup2 | this.game.Data.SFTypeObj[isfType4].PreventHitFrom[index3] == -1)
              {
                int num4 = (int) Math.Round((double) (100f * VBMath.Rnd()));
                if (this.game.Data.SFTypeObj[isfType4].PreventPriority[index3] * 1000 + num4 > num1)
                {
                  preventer = index2;
                  num1 = num4 + this.game.Data.SFTypeObj[isfType4].PreventPriority[index3] * 1000;
                  index1 = index3;
                }
              }
            }
          }
        }
      }
      if (preventer > -1)
      {
        if (preventer > -1 & this.game.Data.SFTypeObj[this.IList[preventer].ISFType].PreventChance[index1] > 0)
        {
          Individual[] ilist1 = this.IList;
          Individual[] individualArray1 = ilist1;
          int index4 = defnr;
          int index5 = index4;
          individualArray1[index5].IPreventPointsGiven = ilist1[index4].IPreventPointsGiven + this.game.Data.SFTypeObj[this.IList[preventer].ISFType].PreventPoints[index1];
          Individual[] ilist2 = this.IList;
          Individual[] individualArray2 = ilist2;
          int index6 = preventer;
          int index7 = index6;
          individualArray2[index7].IPreventPointsUsed = ilist2[index6].IPreventPointsUsed + this.game.Data.SFTypeObj[this.IList[preventer].ISFType].PreventPoints[index1];
          int Number1 = (int) Math.Round((double) (VBMath.Rnd() * 100f));
          int Number2 = this.game.Data.SFTypeObj[this.IList[preventer].ISFType].PreventChance[index1];
          string str1 = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[defnr].IID)) + ")";
          string str2 = this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[attnr].IID)) + ")";
          string str3 = this.game.Data.SFTypeObj[this.IList[preventer].ISFType].Name + "(" + Strings.Trim(Conversion.Str((object) this.IList[preventer].IID)) + ")";
          string str4 = "Roll required to be lower or equal then " + Conversion.Str((object) Number2) + ". roll was " + Conversion.Str((object) Number1) + ". PreventPointsGiven to " + str1 + ": " + Conversion.Str((object) this.IList[defnr].IPreventPointsGiven) + ". PreventPointsUsed for " + str3 + ": " + Conversion.Str((object) this.IList[preventer].IPreventPointsUsed) + ". ";
          if (Number1 < Number2)
          {
            this.AddDetail("Prevent SUCCES" + this.game.Data.SFTypeObj[this.IList[preventer].ISFType].Name);
            this.AddReport(0, "Prevent Received SUCCES", "Individual " + str4 + str3 + " prevents hit on " + str1 + " by " + str2, defnr + 10000, this.CombatRound);
            this.AddReport(0, "Prevent Given SUCCES", "Individual " + str4 + str3 + " prevents a hit on " + str1 + " by " + str2, preventer + 10000, this.CombatRound);
            this.AddReport(0, "Target avoids hit by prevent SUCCES", "Individual " + str4 + str1 + " is prevented from being hit by " + str3, attnr + 10000, this.CombatRound);
          }
          else
          {
            this.AddDetail("Hit was almost prevented by " + this.game.Data.SFTypeObj[this.IList[preventer].ISFType].Name);
            this.AddReport(0, "Prevent Received FAILED", "Individual " + str4 + str3 + " tried to prevent hit on " + str1 + " by " + str2, defnr + 10000, this.CombatRound);
            this.AddReport(0, "Prevent Given FAILED", "Individual " + str4 + str3 + " tried to prevent a hit on " + str1 + " by " + str2 + ", but failed to do succesfully do so.", preventer + 10000, this.CombatRound);
            this.AddReport(0, "Target avoids hit by prevent FAILED ", "Individual " + str4 + str1 + " was attempted to be prevented from being hit by " + str3, attnr + 10000, this.CombatRound);
            preventer = defnr;
          }
        }
        else
          preventer = defnr;
      }
      else
        preventer = defnr;
      return preventer;
    }

    public void DoSteps()
    {
      if (this.previewMode)
        VBMath.Randomize((double) (int) Math.Round((double) (this.game.Data.GameID * this.TargetX) / (double) (this.TargetY + 1)));
      int icounter1 = this.ICounter;
      for (int index = 0; index <= icounter1; ++index)
      {
        this.IList[index].AttackCount = 0;
        this.IList[index].AttackCountAir = 0;
        this.IList[index].AttackCountLand = 0;
        this.IList[index].AttackedCount = 0;
        this.IList[index].ICounterAttacks = 0;
        this.IList[index].IPreventPointsGiven = 0;
        this.IList[index].IPreventPointsUsed = 0;
      }
      int ucounter1 = this.UCounter;
      for (int index = 0; index <= ucounter1; ++index)
        this.UList[index].UParticipated = 0;
      this.CrowdingAttMod = 1f;
      int num1 = 0;
      int num2 = 0;
      if (this.CombatType == 12 | this.CombatType == 1 | this.CombatType == 10 | this.CombatType == 9)
      {
        int icounter2 = this.ICounter;
        for (int inr = 0; inr <= icounter2; ++inr)
        {
          if (this.TestAttack(inr) && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 0 && this.IList[inr].IAttacker == 1)
          {
            num1 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
            if (this.UList[this.IList[inr].IUlistNr].UApMoveCost < this.UList[this.IList[inr].IUlistNr].UApSpend)
              num2 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
          }
        }
        if (num2 > 0 & !this.previewMode)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int index1 = 0; index1 <= regimeCounter; ++index1)
          {
            if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.AttackerRegime, index1))
            {
              HexClass[,] hexObj = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj;
              HexClass[,] hexClassArray = hexObj;
              int targetX = this.TargetX;
              int index2 = targetX;
              int targetY = this.TargetY;
              int index3 = targetY;
              HexClass hexClass = hexClassArray[index2, index3];
              int Index1 = index1;
              int Index2 = Index1;
              int num3 = (int) Math.Round((double) hexObj[targetX, targetY].get_BattlePenalty(Index1) + Math.Max(1.0, (double) this.game.Data.RuleVar[325] * Math.Min((double) num2 / 100.0, 1.0)));
              hexClass.set_BattlePenalty(Index2, num3);
              if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].get_BattlePenalty(index1) > 10.0 * (double) this.game.Data.RuleVar[325])
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].set_BattlePenalty(index1, (int) Math.Round((double) (10f * this.game.Data.RuleVar[325])));
            }
          }
        }
        if (num1 == 0)
          num1 = 1;
        if (this.CombatRound == 1)
          this.NewBattleStack = num1;
        this.CrowdingAttMod = this.AttackCrowding / (float) (num1 + this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].get_BattleStack(this.AttackerRegime));
        if ((double) this.CrowdingAttMod > 1.0)
          this.CrowdingAttMod = 1f;
      }
      this.CrowdingAttArtMod = 1f;
      int num4 = 0;
      int num5 = 0;
      if ((this.CombatType == 3 | this.CombatType == 4) & (double) this.AttackCrowdingArt > 0.0)
      {
        int icounter3 = this.ICounter;
        for (int inr = 0; inr <= icounter3; ++inr)
        {
          if (this.TestAttack(inr) && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater < 2 && this.IList[inr].IAttacker == 1)
          {
            num4 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
            if (this.UList[this.IList[inr].IUlistNr].UApMoveCost < this.UList[this.IList[inr].IUlistNr].UApSpend)
              num5 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
          }
        }
        if (num4 == 0)
          num4 = 1;
        if (this.CombatRound == 1)
          this.NewBattleStackArt = num4;
        this.CrowdingAttArtMod = this.AttackCrowdingArt / (float) (num4 + this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].get_BattleStackArt(this.AttackerRegime));
        if ((double) this.CrowdingAttArtMod > 1.0)
          this.CrowdingAttArtMod = 1f;
      }
      this.CrowdingAttAirMod = 1f;
      int num6 = 0;
      int num7 = 0;
      if ((double) this.AttackCrowdingAir > 0.0 && this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 9 | this.CombatType == 13)
      {
        int icounter4 = this.ICounter;
        for (int inr = 0; inr <= icounter4; ++inr)
        {
          if (this.TestAttack(inr) && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 2 && this.IList[inr].IAttacker == 1)
          {
            num6 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
            if (this.UList[this.IList[inr].IUlistNr].UApMoveCost < this.UList[this.IList[inr].IUlistNr].UApSpend)
              num7 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
          }
        }
        if (this.CombatRound == 1)
          this.NewBattleStackAir = num6;
        if (num6 == 0)
          num6 = 1;
        this.CrowdingAttAirMod = this.AttackCrowdingAir / (float) (num6 + this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].get_BattleStackAir(this.AttackerRegime));
        if ((double) this.CrowdingAttAirMod > 1.0)
          this.CrowdingAttAirMod = 1f;
      }
      this.CrowdingDefMod = 1f;
      int num8 = 0;
      if (this.CombatType == 12 | this.CombatType == 1 | this.CombatType == 10 | this.CombatType == 9 | this.CombatType == 3 | this.CombatType == 4 | this.CombatType == 5 | this.CombatType == 6)
      {
        int icounter5 = this.ICounter;
        for (int inr = 0; inr <= icounter5; ++inr)
        {
          if (this.TestAttack(inr) & this.IList[inr].IAA < 1 && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 0 && this.IList[inr].IAttacker == 0)
            num8 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].Frontage;
        }
        this.CrowdingDefCount = num8;
        if (num8 == 0)
          num8 = 1;
        this.CrowdingDefMod = this.game.Data.RuleVar[30] / (float) num8;
        if ((double) this.CrowdingDefMod > 1.0)
          this.CrowdingDefMod = 1f;
      }
      int num9 = -1;
      int num10 = 1;
      while (num10 > 0)
      {
        num10 = 0;
        ++num9;
        this.AddDetail("Attack SubRound = " + Conversion.Str((object) (num9 + 1)));
        int icounter6 = this.ICounter;
        for (int index4 = 0; index4 <= icounter6; ++index4)
        {
          int num11 = 1;
          int Number1 = 0;
          if (this.IList[index4].IAttacker == 0)
            Number1 = Number1;
          while (num11 == 1)
          {
            num11 = this.IList[index4].AttackCount >= this.game.Data.SFTypeObj[this.IList[index4].ISFType].Attacks ? 0 : 1;
            if (this.IList[index4].AttackCount != num9)
              num11 = 0;
            bool flag1 = false;
            if (this.game.Data.SFTypeObj[this.IList[index4].ISFType].Attacks == 0)
              flag1 = true;
            if (this.game.Data.Product >= 6)
            {
              if (this.game.Data.SFTypeObj[this.IList[index4].ISFType].StartCombatRound > 0 && this.CombatRound < this.game.Data.SFTypeObj[this.IList[index4].ISFType].StartCombatRound)
                num11 = 0;
              if (this.game.Data.SFTypeObj[this.IList[index4].ISFType].EndCombatRound > 0 && this.game.Data.SFTypeObj[this.IList[index4].ISFType].EndCombatRound == this.game.Data.SFTypeObj[this.IList[index4].ISFType].StartCombatRound | this.game.Data.SFTypeObj[this.IList[index4].ISFType].EndCombatRound == 1 && this.IList[index4].IAttacker == 0)
                num11 = 0;
            }
            if (this.game.Data.Product >= 7 && (double) this.game.Data.RuleVar[407] > 0.0 && this.game.Data.SFTypeObj[this.IList[index4].ISFType].ArtRange > 0 && (double) this.IList[index4].ILisAmmoMod < 1.0)
              num11 = 0;
            if (num11 == 1)
            {
              if (this.TestAttack(index4))
              {
                int combatType = this.CombatType;
                if ((double) this.game.Data.RuleVar[493] > 0.0 && this.IList[index4].IleftOutOfPartialAttack)
                  this.CombatType = 3;
                int index5 = this.FindPreventer(this.FindOpponent(index4), index4);
                if (index5 > -1)
                {
                  if (this.IList[index5].IleftOutOfPartialAttack)
                    index5 = index5;
                  ++Number1;
                  this.DoActualAttack(index4, index5);
                  bool flag2 = false;
                  if ((double) this.game.Data.RuleVar[431] > 0.0 && (double) this.GetEffectiveReconOnHexOfTargettedIndividual(index4) < (double) this.IList[index4].IcoverPoints)
                    flag2 = true;
                  if (this.game.Data.Product >= 7 && (double) this.game.Data.RuleVar[407] > 0.0 && this.game.Data.SFTypeObj[this.IList[index5].ISFType].ArtRange > 0 && (double) this.IList[index5].ILisAmmoMod < 1.0)
                    flag2 = true;
                  if (!flag2 & this.IList[index5].IKilled == 0 & (double) this.game.Data.RuleVar[807] == 0.0 && this.TestTarget(index5, index4))
                  {
                    int num12 = 1;
                    if (this.CombatType == 3 | this.CombatType == 4)
                    {
                      num12 = 0;
                      if ((double) this.game.Data.RuleVar[493] > 0.0 & num12 == 0 && this.IList[index4].IleftOutOfPartialAttack)
                        num12 = 1;
                    }
                    if (this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15 && this.game.Data.SFTypeObj[this.IList[index4].ISFType].Theater < 2)
                      num12 = 0;
                    if (this.IList[index4].AttackedCount >= this.game.Data.SFTypeObj[this.IList[index4].ISFType].MaxAttacked)
                      num12 = 0;
                    int unitGroup = this.game.Data.SFTypeObj[this.IList[index4].ISFType].UnitGroup;
                    if (this.game.Data.SFTypeObj[this.IList[index5].ISFType].AttackPower[unitGroup] < 1)
                      num12 = 0;
                    if (this.IList[index5].IRetreat > 0)
                      num12 = 0;
                    if (this.IList[index5].AttackedCount > this.game.Data.SFTypeObj[this.IList[index5].ISFType].MaxAttacked & (double) this.game.Data.RuleVar[925] < 1.0)
                      num12 = 0;
                    if (num12 == 1)
                      this.DoActualAttack(index5, index4, true);
                  }
                  num11 = 1;
                  num10 = 1;
                  if (Number1 == 1)
                  {
                    Individual[] ilist = this.IList;
                    Individual[] individualArray = ilist;
                    int index6 = index4;
                    int index7 = index6;
                    individualArray[index7].IBattleRounds = ilist[index6].IBattleRounds + 1;
                  }
                }
                else
                {
                  flag1 = true;
                  num11 = 0;
                }
                if ((double) this.game.Data.RuleVar[493] > 0.0 && this.IList[index4].IleftOutOfPartialAttack)
                  this.CombatType = combatType;
              }
              else
                num11 = 0;
            }
            if (flag1 && this.game.Data.SFTypeObj[this.IList[index4].ISFType].AntiStrucPts > 0 && this.IList[index4].IAttacker == 1 && this.IList[index4].ILastAttackDone < this.CombatRound && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].Regime, this.AttackerRegime))
            {
              this.IList[index4].ILastAttackDone = this.CombatRound;
              Individual[] ilist = this.IList;
              Individual[] individualArray = ilist;
              int index8 = index4;
              int index9 = index8;
              individualArray[index9].AttackCount = ilist[index8].AttackCount + 1;
              int num13 = (int) Math.Round(Conversion.Int((double) this.game.Data.SFTypeObj[this.IList[index4].ISFType].AntiStrucPts * ((double) this.IList[index4].IRdn / 100.0)));
              int num14 = (int) Math.Round(0.33 * (double) num13 + 0.66 * (double) num13 * (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.IList[index4].IUnr].X, this.game.Data.UnitObj[this.IList[index4].IUnr].Y));
              if (num14 == 0 && (double) VBMath.Rnd() < (double) this.IList[index4].IRdn / 100.0)
                num14 = 1;
              int Number2 = (int) Math.Round((double) (int) Math.Round((double) VBMath.Rnd() * ((double) num14 + 0.5)) / (double) (this.IList[index4].AttackedCount + 1));
              if (this.game.Data.SFTypeObj[this.IList[index4].ISFType].Theater == 2 && this.CombatType != 6)
                Number2 = (int) Math.Round((double) ((float) Number2 * this.game.Data.RuleVar[128]));
              if (this.game.Data.SFTypeObj[this.IList[index4].ISFType].SlotNumber > -1 && this.IList[index4].IAttacker == 1)
              {
                int[] areaCode = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].AreaCode;
                int[] numArray = areaCode;
                int slotNumber = this.game.Data.SFTypeObj[this.IList[index4].ISFType].SlotNumber;
                int index10 = slotNumber;
                int num15 = areaCode[slotNumber] + 1;
                numArray[index10] = num15;
              }
              if ((double) this.game.Data.RuleVar[435] > 0.0)
              {
                if (((!this.game.EditObj.CombatSim ? 1 : 0) & 0) != 0)
                {
                  Number1 = this.game.Data.SFTypeObj[this.IList[index4].ISFType].FuelForAttack;
                  int index11 = (int) Math.Round((double) this.game.Data.RuleVar[435]);
                  int attackerRegime = this.AttackerRegime;
                  if (Number1 > 0)
                  {
                    if (this.game.Data.UnitObj[this.IList[index4].IUnr].Fuel >= Number1)
                    {
                      UnitClass[] unitObj1 = this.game.Data.UnitObj;
                      UnitClass[] unitClassArray1 = unitObj1;
                      int iunr1 = this.IList[index4].IUnr;
                      int index12 = iunr1;
                      unitClassArray1[index12].FuelUsedAtt = unitObj1[iunr1].FuelUsedAtt + Number1;
                      UnitClass[] unitObj2 = this.game.Data.UnitObj;
                      UnitClass[] unitClassArray2 = unitObj2;
                      int iunr2 = this.IList[index4].IUnr;
                      int index13 = iunr2;
                      unitClassArray2[index13].Fuel = unitObj2[iunr2].Fuel - Number1;
                      this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name + " consumes " + Conversion.Str((object) Number1) + " " + this.game.Data.RegimeSlotName[index11]);
                      this.AddReport(0, "Fuel consumption", "Individual " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name, index4 + 10000, this.CombatRound);
                    }
                    else
                    {
                      this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name + " out of fuel!!!");
                      this.AddReport(0, "Out of fuel", "Individual " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name, index4 + 10000, this.CombatRound);
                      Number2 = (int) Math.Round((double) ((float) Number2 * this.game.Data.SFTypeObj[this.IList[index4].ISFType].OutOfFuelAttack));
                    }
                  }
                }
              }
              else if (!this.game.EditObj.CombatSim)
              {
                int fuelForAttack = this.game.Data.SFTypeObj[this.IList[index4].ISFType].FuelForAttack;
                int currentSlot = this.game.Data.SFTypeObj[this.IList[index4].ISFType].FuelRegimeVar;
                if ((double) this.game.Data.RuleVar[949] > 0.0)
                  currentSlot = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot, this.game.Data.UnitObj[this.IList[index4].IUnr].RealX(ref this.game), this.game.Data.UnitObj[this.IList[index4].IUnr].RealY(ref this.game));
                int index14 = currentSlot;
                int attackerRegime = this.AttackerRegime;
                if (fuelForAttack > 0 & index14 > -1)
                {
                  if (this.game.Data.RegimeObj[attackerRegime].RegimeSlot[index14] >= fuelForAttack)
                  {
                    UnitClass[] unitObj = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray = unitObj;
                    int iunr = this.IList[index4].IUnr;
                    int index15 = iunr;
                    unitClassArray[index15].FuelUsedAtt = unitObj[iunr].FuelUsedAtt + fuelForAttack;
                    int[] regimeSlot = this.game.Data.RegimeObj[attackerRegime].RegimeSlot;
                    int[] numArray = regimeSlot;
                    int index16 = index14;
                    int index17 = index16;
                    int num16 = regimeSlot[index16] - fuelForAttack;
                    numArray[index17] = num16;
                    this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name + " consumes " + Conversion.Str((object) fuelForAttack) + " " + this.game.Data.RegimeSlotName[index14]);
                    this.AddReport(0, "Fuel consumption", "Individual " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name, index4 + 10000, this.CombatRound);
                  }
                  else
                  {
                    this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name + " out of fuel!!!");
                    this.AddReport(0, "Out of fuel", "Individual " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name, index4 + 10000, this.CombatRound);
                    Number2 = (int) Math.Round((double) ((float) Number2 * this.game.Data.SFTypeObj[this.IList[index4].ISFType].OutOfFuelAttack));
                  }
                }
                Number1 = this.IList[index4].ISFType;
                if (this.game.Data.SFTypeObj[Number1].StockpileUsedPerRound > 0)
                {
                  if (this.game.Data.UnitObj[this.IList[index4].IUnr].StockpileCurrent >= this.game.Data.SFTypeObj[Number1].StockpileUsedPerRound)
                  {
                    this.IList[index4].Istockpile = true;
                    UnitClass[] unitObj = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray = unitObj;
                    int iunr = this.IList[index4].IUnr;
                    int index18 = iunr;
                    unitClassArray[index18].StockpileCurrent = unitObj[iunr].StockpileCurrent - this.game.Data.SFTypeObj[Number1].StockpileUsedPerRound;
                  }
                  else
                    this.IList[index4].Istockpile = false;
                }
                else
                  this.IList[index4].Istockpile = true;
                if (!this.IList[index4].Istockpile)
                {
                  this.AddDetail("Attacker: " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name + " out of stockpile!!!");
                  this.AddReport(0, "Out of stockpile", "Individual " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name, index4 + 10000, this.CombatRound);
                  Number2 = 0;
                }
              }
              if (this.game.Data.Product >= 7 && (double) this.IList[index4].ILisAmmoMod < 1.0)
                Number2 = (int) Math.Round((double) ((float) Number2 * this.IList[index4].ILisAmmoMod));
              this.AntiStrucDam += Number2;
              this.AddReport(0, "Anti-structural damage", "Individual " + this.game.Data.SFTypeObj[this.IList[index4].ISFType].Name + " that has no opponent does " + Conversion.Str((object) Number2) + " damage anyway.\r\nTotal anti-structural damage now: " + Strings.Trim(Conversion.Str((object) this.AntiStrucDam)), index4 + 10000, this.CombatRound);
              if (this.customCombatObj.HasCustumCalls())
              {
                string str = "";
                CustomCombatCalls customCombatObj = this.customCombatObj;
                CombatClass combatClass = this;
                ref CombatClass local1 = ref combatClass;
                GameClass game = this.game;
                int attnr = index4;
                ref string local2 = ref str;
                customCombatObj.IndividualCombatCall_FirstAttackOfRound(ref local1, game, attnr, -1, ref local2);
              }
            }
          }
        }
      }
      int ucounter2 = this.UCounter;
      for (int index = 0; index <= ucounter2; ++index)
        this.UList[index].UParticipated = 1;
    }

    public void AddUnitToUnits(
      int tunr,
      int tattacker,
      Coordinate tretreat,
      Coordinate tfrom,
      Coordinate ttoo,
      bool IsInterceptor = false,
      bool IsParadropper = false,
      bool isAA = false,
      bool isSupportInterceptFire = false)
    {
      ++this.UCounter;
      this.UList = (BattleUnit[]) Utils.CopyArray((Array) this.UList, (Array) new BattleUnit[this.UCounter + 1]);
      this.UList[this.UCounter].UNr = tunr;
      if (this.game.Data.Product == 6)
      {
        Coordinate coordinate = this.game.HandyFunctionsObj.EPandPowerInHex(this.game.Data.UnitObj[tunr].X, this.game.Data.UnitObj[tunr].Y, tunr);
        coordinate.x = (int) Math.Round((double) ((float) coordinate.x * this.game.Data.RuleVar[42]));
        if (coordinate.x > 0 & coordinate.data2 > 0)
          this.UList[this.UCounter].UepEpMaxMod = (float) (int) Math.Round((double) (100 * coordinate.data2) / (double) coordinate.x);
      }
      if (this.game.Data.UncertaintyOn)
        this.UList[this.UCounter].UDice = this.game.HandyFunctionsObj.Uncertainty_RollLoadedDice(tunr);
      this.UList[this.UCounter].Uattacker = tattacker;
      this.UList[this.UCounter].URetreat = 0;
      this.UList[this.UCounter].UPanicked = false;
      this.UList[this.UCounter].UCanRetreat.x = tretreat.x;
      this.UList[this.UCounter].UCanRetreat.y = tretreat.y;
      this.UList[this.UCounter].UCanRetreat.map = tretreat.map;
      this.UList[this.UCounter].UCanRetreat.onmap = tretreat.onmap;
      this.UList[this.UCounter].UParadropper = false;
      this.UList[this.UCounter].UDefIntercept = IsInterceptor;
      this.UList[this.UCounter].UinitialRdn = this.game.HandyFunctionsObj.GetAverageRdn(tunr);
      this.game.Data.UnitObj[tunr].DidAttack = true;
      int mapCounter = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
            this.game.EditObj.TempValue[index1].Value[index2, index3] = this.TempValue3[index1].Value[index2, index3];
        }
      }
      if (this.game.Data.UnitObj[tunr].IsHQ)
      {
        this.UList[this.UCounter].UStaffMod = 1f;
        this.UList[this.UCounter].UStaffXpMod = 0.0f;
      }
      else if (this.game.Data.UnitObj[tunr].HQ > -1)
      {
        int num1 = this.game.HandyFunctionsObj.GetStaffPercent(this.game.Data.UnitObj[tunr].HQ);
        int num2 = this.game.HandyFunctionsObj.GetStaffPercent(this.game.Data.UnitObj[tunr].HQ, true);
        int num3 = this.game.HandyFunctionsObj.GetStaffPercent(this.game.Data.UnitObj[tunr].HQ);
        if (num1 > 100)
          num1 = 100;
        if (num3 > 100)
          num3 = 100;
        if (num2 > 100)
          num2 = 100;
        if (this.game.Data.UnitObj[tunr].IsHQ)
        {
          this.UList[this.UCounter].UStaffMod = (float) (1.0 + (double) this.game.HandyFunctionsObj.GetStaffCombatMod(tunr) * ((double) num2 / 100.0));
          this.UList[this.UCounter].UStaffXpMod = this.game.Data.RuleVar[75] * ((float) num1 / 100f);
        }
        else if (this.game.Data.UnitObj[tunr].HQ > -1)
        {
          this.UList[this.UCounter].UStaffMod = (float) (1.0 + (double) this.game.Data.RuleVar[140] * ((double) num3 / 100.0) * ((double) this.game.HandyFunctionsObj.Gethqpow(tunr) / 100.0) + (double) this.game.HandyFunctionsObj.GetStaffCombatMod(this.game.Data.UnitObj[tunr].HQ) * ((double) num2 / 100.0) * ((double) this.game.HandyFunctionsObj.Gethqpow(tunr) / 100.0));
          this.UList[this.UCounter].UStaffXpMod = (float) ((double) this.game.Data.RuleVar[75] * ((double) num1 / 100.0) * ((double) this.game.HandyFunctionsObj.Gethqpow(tunr) / 100.0));
        }
        else
        {
          this.UList[this.UCounter].UStaffMod = 1f;
          this.UList[this.UCounter].UStaffXpMod = 0.0f;
        }
      }
      else
      {
        this.UList[this.UCounter].UStaffMod = 1f;
        this.UList[this.UCounter].UStaffXpMod = 0.0f;
      }
      if (tattacker == 1)
      {
        int dist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[this.UCounter].UNr].X, this.game.Data.UnitObj[this.UList[this.UCounter].UNr].Y, this.game.Data.UnitObj[this.UList[this.UCounter].UNr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map);
        if (this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 11)
        {
          this.UList[this.UCounter].UApMoveCost = this.game.HandyFunctionsObj.MoveApCostPreview(tunr, tfrom.x, tfrom.y, tfrom.x, tfrom.y, tfrom.map, ttoo.x, ttoo.y, ttoo.map, true).x;
          this.UList[this.UCounter].UMaxApToSpend = this.game.HandyFunctionsObj.GetLowestAp(tunr);
        }
        else if (this.CombatType == 3)
          this.UList[this.UCounter].UMaxApToSpend = !this.InterceptFire ? ((double) this.game.Data.RuleVar[419] <= 0.0 ? this.game.HandyFunctionsObj.GetLowestlandartAp(tunr, dist) : Math.Min(this.game.HandyFunctionsObj.GetLowestlandartAp(tunr, dist), this.game.HandyFunctionsObj.GetLowestlandDirectAp(tunr, dist))) : (int) Math.Round((double) (10f * this.game.Data.RuleVar[428]));
        else if (this.CombatType == 4)
          this.UList[this.UCounter].UMaxApToSpend = this.game.HandyFunctionsObj.GetLowestseaartAp(tunr, dist);
        else if (this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15)
        {
          bool flag = false;
          if (this.CombatType == 15 & this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Regime == this.AttackerRegime & this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Location > -1)
          {
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Location].Type].IsAirfield)
              flag = true;
            if (this.game.Data.LocObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Location].isAirfield)
              flag = true;
          }
          if (flag)
            this.game.HandyFunctionsObj.MakeMovePrediction(tunr, this.game.Data.UnitObj[tunr].X, this.game.Data.UnitObj[tunr].Y, this.game.Data.UnitObj[tunr].Map, false, PredictAirOnly: true, IsTransfer: true);
          else
            this.game.HandyFunctionsObj.MakeMovePrediction(tunr, this.game.Data.UnitObj[tunr].X, this.game.Data.UnitObj[tunr].Y, this.game.Data.UnitObj[tunr].Map, false, PredictAirOnly: true, attack: true);
          this.UList[this.UCounter].UApMoveCost = this.game.EditObj.TempValue[this.CombatTarget.map].Value[this.CombatTarget.x, this.CombatTarget.y];
          if (this.CombatType == 14 && this.UList[this.UCounter].UApMoveCost < 40)
            this.UList[this.UCounter].UApMoveCost = 40;
          this.UList[this.UCounter].UMaxApToSpend = this.game.HandyFunctionsObj.GetLowestAirAp(tunr);
        }
        else if (this.CombatType == 9 & IsParadropper)
        {
          this.UList[this.UCounter].UParadropper = true;
          this.UList[this.UCounter].UApMoveCost = this.game.HandyFunctionsObj.GetLowestAp(this.UList[this.UCounter].UNr);
          this.UList[this.UCounter].UMaxApToSpend = 9999;
        }
        else if (this.CombatType == 9 & !IsParadropper)
        {
          this.UList[this.UCounter].UParadropper = false;
          this.game.HandyFunctionsObj.MakeMovePrediction(tunr, this.game.Data.UnitObj[tunr].X, this.game.Data.UnitObj[tunr].Y, this.game.Data.UnitObj[tunr].Map, false, attack: true);
          this.UList[this.UCounter].UApMoveCost = this.game.EditObj.TempValue[this.CombatTarget.map].Value[this.CombatTarget.x, this.CombatTarget.y];
          this.UList[this.UCounter].UMaxApToSpend = this.game.HandyFunctionsObj.GetLowestAirAp(tunr);
        }
        else if (this.CombatType == 10)
        {
          this.UList[this.UCounter].UApMoveCost = this.game.HandyFunctionsObj.GetLowestAp(this.UList[this.UCounter].UNr);
          this.UList[this.UCounter].UMaxApToSpend = 9999;
        }
        else if (this.CombatType == 12)
        {
          this.UList[this.UCounter].UApMoveCost = this.game.HandyFunctionsObj.GetLowestAp(this.UList[this.UCounter].UNr);
          this.UList[this.UCounter].UMaxApToSpend = 9999;
        }
        this.UList[this.UCounter].UApSpend = 0;
      }
      else
      {
        this.UList[this.UCounter].UApMoveCost = 0;
        this.UList[this.UCounter].UMaxApToSpend = 9999;
        this.UList[this.UCounter].UApSpend = 0;
        if (IsInterceptor)
        {
          this.UList[this.UCounter].UDefIntercept = true;
          this.AddBiggy("Interceptors come to the rescue of the defenders: " + this.game.Data.UnitObj[tunr].Name);
        }
        if (isSupportInterceptFire)
        {
          this.UList[this.UCounter].UMaxApToSpend = (int) Math.Round((double) (10f * this.game.Data.RuleVar[428]));
          this.UList[this.UCounter].USupportInterceptFire = true;
          this.AddBiggy("Support Intercept Fire for Defenders: " + this.game.Data.UnitObj[tunr].Name);
        }
        if (isAA)
        {
          this.AddBiggy("AA from a distance: " + this.game.Data.UnitObj[tunr].Name);
          this.UList[this.UCounter].UAA = 1;
        }
      }
      if (this.game.Data.UnitObj[tunr].Regime == this.game.Data.Turn)
        return;
      Coordinate reconMinusHide;
      if (this.game.Data.UnitObj[tunr].Regime == this.game.Data.Turn | !this.game.Data.FOWOn | this.game.Data.Round == 0)
        reconMinusHide.x = 3;
      else
        reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(tunr, this.game.Data.Turn);
      this.UList[this.UCounter].UVisibility = reconMinusHide;
    }

    public void AddToI()
    {
      Random random = new Random((int) Math.Round((double) this.game.Data.GameID / (double) (this.TargetX + 1) * (double) (this.TargetY + 1)));
      bool flag1 = false;
      int ucounter1 = this.UCounter;
      for (int index = 0; index <= ucounter1; ++index)
      {
        int unr = this.UList[index].UNr;
        if (this.UList[index].Uattacker == 1 && (double) this.game.Data.RuleVar[493] > 0.0)
        {
          Coordinate coordinate = this.game.HandyFunctionsObj.MoveApCostPreview(unr, this.UList[index].UCanRetreat.x, this.UList[index].UCanRetreat.y, this.UList[index].UCanRetreat.x, this.UList[index].UCanRetreat.y, 0, this.TargetX, this.TargetY, 0, true);
          if (coordinate.data2 > 0 & coordinate.data2 < 100)
          {
            flag1 = true;
            this.UList[index].UpartialAttack = true;
          }
        }
      }
      int ucounter2 = this.UCounter;
      for (int index1 = 0; index1 <= ucounter2; ++index1)
      {
        int unr = this.UList[index1].UNr;
        int maxDist;
        if ((double) this.game.Data.RuleVar[419] > 0.0)
        {
          if ((this.CombatType == 3 | flag1) & this.UList[index1].Uattacker == 1)
          {
            maxDist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index1].UNr].X, this.game.Data.UnitObj[this.UList[index1].UNr].Y, 0, this.TargetX, this.TargetY, 0, 99);
            this.game.HandyFunctionsObj.RedimTempLosValue(0);
            this.game.HandyFunctionsObj.SetTempLos(this.game.Data.UnitObj[this.UList[index1].UNr].X, this.game.Data.UnitObj[this.UList[index1].UNr].Y, maxDist + 1, false, false);
            this.UList[index1].ULos = new int[this.UCounter + 1];
            int ucounter3 = this.UCounter;
            for (int index2 = 0; index2 <= ucounter3; ++index2)
              this.UList[index1].ULos[index2] = this.game.EditObj.TempLos[0].Value[this.game.Data.UnitObj[this.UList[index2].UNr].X, this.game.Data.UnitObj[this.UList[index2].UNr].Y];
          }
          if ((this.CombatType == 3 | flag1) & this.UList[index1].Uattacker == 0)
          {
            maxDist = Math.Max(this.game.HandyFunctionsObj.GetMaxArtRange(unr, 0), this.game.HandyFunctionsObj.GetMaxDirectRange(unr, 0)) + 1;
            this.game.HandyFunctionsObj.RedimTempLosValue(0);
            this.game.HandyFunctionsObj.SetTempLos(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, maxDist, false, false);
            this.UList[index1].ULos = new int[this.UCounter + 1];
            int ucounter4 = this.UCounter;
            for (int index3 = 0; index3 <= ucounter4; ++index3)
            {
              maxDist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index3].UNr].X, this.game.Data.UnitObj[this.UList[index3].UNr].Y, 0, this.TargetX, this.TargetY, 0, 99);
              this.UList[index1].ULos[index3] = this.game.EditObj.TempLos[0].Value[this.game.Data.UnitObj[this.UList[index3].UNr].X, this.game.Data.UnitObj[this.UList[index3].UNr].Y];
            }
          }
          if (this.CombatType == 1 & this.UList[index1].Uattacker == 0 & this.UList[index1].USupportInterceptFire)
          {
            maxDist = Math.Max(this.game.HandyFunctionsObj.GetMaxArtRange(unr, 0), this.game.HandyFunctionsObj.GetMaxDirectRange(unr, 0)) + 1;
            this.game.HandyFunctionsObj.RedimTempLosValue(0);
            this.game.HandyFunctionsObj.SetTempLos(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, maxDist, false, false);
            this.UList[index1].ULos = new int[this.UCounter + 1];
            int ucounter5 = this.UCounter;
            for (int index4 = 0; index4 <= ucounter5; ++index4)
            {
              maxDist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index4].UNr].X, this.game.Data.UnitObj[this.UList[index4].UNr].Y, 0, this.TargetX, this.TargetY, 0, 99);
              this.UList[index1].ULos[index4] = this.game.EditObj.TempLos[0].Value[this.game.Data.UnitObj[this.UList[index4].UNr].X, this.game.Data.UnitObj[this.UList[index4].UNr].Y];
            }
          }
        }
        if (this.game.Data.UnitObj[unr].SFCount > -1)
        {
          int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
          for (int i1 = 0; i1 <= sfCount1; ++i1)
          {
            int sf = this.game.Data.UnitObj[unr].SFList[i1];
            int type = this.game.Data.SFObj[sf].Type;
            int num1 = 0;
            bool flag2 = false;
            if (this.CombatType == 1 && this.UList[index1].Uattacker == 1 && (double) this.game.Data.RuleVar[493] > 0.0 && this.game.HandyFunctionsObj.MoveApCostPreview(unr, this.UList[index1].UCanRetreat.x, this.UList[index1].UCanRetreat.y, this.UList[index1].UCanRetreat.x, this.UList[index1].UCanRetreat.y, 0, this.TargetX, this.TargetY, 0, true, onlySfNr: sf).x > this.game.Data.SFObj[sf].Ap)
            {
              flag2 = true;
              maxDist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index1].UNr].X, this.game.Data.UnitObj[this.UList[index1].UNr].Y, this.game.Data.UnitObj[this.UList[index1].UNr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map);
              if (maxDist > this.game.Data.SFTypeObj[type].ArtRange)
              {
                num1 = 1;
                if ((double) this.game.Data.RuleVar[419] > 0.0)
                {
                  int num2 = 0;
                  num1 = maxDist <= this.game.Data.SFTypeObj[type].directRange ? num2 : 1;
                }
              }
            }
            if (this.CombatType == 1 | this.CombatType == 10 && this.game.Data.SFTypeObj[type].Theater > 0)
              num1 = 1;
            if (this.CombatType == 9 && this.game.Data.SFTypeObj[type].Theater == 1)
              num1 = 1;
            if (this.CombatType == 2 && this.game.Data.SFTypeObj[type].Theater == 0)
            {
              if (this.UList[index1].Uattacker == 0)
              {
                if (this.game.Data.SFTypeObj[type].ArtRange < 1)
                  num1 = 1;
              }
              else
                num1 = 1;
            }
            if (this.CombatType == 3 | this.CombatType == 4)
            {
              if (this.UList[index1].Uattacker != 0)
                ;
              if (this.UList[index1].Uattacker == 1)
              {
                maxDist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index1].UNr].X, this.game.Data.UnitObj[this.UList[index1].UNr].Y, this.game.Data.UnitObj[this.UList[index1].UNr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map);
                if (maxDist > this.game.Data.SFTypeObj[type].ArtRange)
                {
                  num1 = 1;
                  if ((double) this.game.Data.RuleVar[419] > 0.0)
                  {
                    num1 = 0;
                    if (maxDist > this.game.Data.SFTypeObj[type].directRange)
                      num1 = 1;
                  }
                }
              }
              else
              {
                int num3 = this.UList[index1].Uattacker == 0 & !this.InterceptFire & num1 == 0 ? 1 : 0;
              }
            }
            if (this.CombatType == 1 & this.UList[index1].USupportInterceptFire && this.UList[index1].Uattacker == 0)
            {
              maxDist = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index1].UNr].X, this.game.Data.UnitObj[this.UList[index1].UNr].Y, this.game.Data.UnitObj[this.UList[index1].UNr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map);
              if (maxDist > this.game.Data.SFTypeObj[type].ArtRange)
              {
                num1 = 1;
                if ((double) this.game.Data.RuleVar[419] > 0.0)
                {
                  num1 = 0;
                  if (maxDist > this.game.Data.SFTypeObj[type].directRange)
                    num1 = 1;
                }
              }
            }
            if (this.CombatType == 3 && this.UList[index1].Uattacker == 1 && this.game.Data.SFTypeObj[type].Theater == 1)
              num1 = 1;
            if (this.CombatType == 4)
            {
              if (this.UList[index1].Uattacker == 0 && this.game.Data.SFTypeObj[type].Theater == 1)
                num1 = 1;
              if (this.UList[index1].Uattacker == 1 && this.game.Data.SFTypeObj[type].Theater != 1)
                num1 = 1;
            }
            if (this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15)
            {
              if (this.UList[index1].Uattacker == 1 && this.game.Data.SFTypeObj[type].Theater < 2)
                num1 = 1;
              if (this.UList[index1].Uattacker == 0 && this.game.Data.SFTypeObj[type].Theater == 2 && this.game.Data.UnitObj[unr].X == this.TargetX && this.game.Data.UnitObj[unr].Y == this.TargetY && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea)
              {
                if (this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Location == -1)
                  num1 = 1;
                else if (!this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Location].Type].IsAirfield && !this.game.Data.LocObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].Location].isAirfield)
                  num1 = 1;
              }
            }
            if (this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15 | this.CombatType == 9 && this.UList[index1].Uattacker == 0 && this.UList[index1].UDefIntercept)
            {
              if (this.game.Data.SFTypeObj[type].Theater < 2)
                num1 = 1;
              if (this.game.Data.SFTypeObj[type].BackBench)
                num1 = 1;
            }
            if (this.CombatType == 9 & this.UList[index1].Uattacker == 1 && !this.UList[index1].UParadropper && this.game.Data.SFTypeObj[type].Theater < 2)
              num1 = 1;
            if (this.UList[index1].UAA == 1 && this.game.Data.SFTypeObj[type].AARange < this.game.HandyFunctionsObj.Distance(this.TargetX, this.TargetY, this.TargetMap, this.game.Data.UnitObj[this.UList[index1].UNr].X, this.game.Data.UnitObj[this.UList[index1].UNr].Y, this.game.Data.UnitObj[this.UList[index1].UNr].Map))
              num1 = 1;
            if (num1 == 0)
            {
              int num4 = this.game.Data.SFObj[sf].Qty;
              int num5 = -1;
              int averageRdn;
              int averageMor;
              int averageXp;
              int averageEntrench;
              Coordinate reconMinusHide;
              int i2;
              if (this.previewMode)
              {
                averageRdn = this.game.HandyFunctionsObj.GetAverageRdn(unr);
                averageMor = this.game.HandyFunctionsObj.GetAverageMor(unr);
                averageXp = this.game.HandyFunctionsObj.GetAverageXp(unr);
                averageEntrench = this.game.HandyFunctionsObj.GetAverageEntrench(unr);
                if (this.game.Data.FOWOn & this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn)
                {
                  if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | !this.game.Data.FOWOn | this.game.Data.Round == 0)
                    reconMinusHide.x = 3;
                  else
                    reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unr, this.game.Data.Turn);
                  this.UList[index1].previewInfoLevel = reconMinusHide.x;
                  if (reconMinusHide.x == 2)
                  {
                    this.game.HandyFunctionsObj.RandomizeForUnit(unr, i1);
                    float num6 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
                    float num7 = (float) ((1.0 - (double) num6) * 2.0);
                    num4 = (int) Math.Round((double) Conversion.Int((VBMath.Rnd() * num7 + num6) * (float) num4));
                    if (num4 < 1)
                      num4 = 1;
                    VBMath.Randomize();
                  }
                  else if (reconMinusHide.x == 3)
                  {
                    num4 = num4;
                  }
                  else
                  {
                    num4 = 0;
                    if (i1 == 0)
                    {
                      i2 = 0;
                      int num8 = 0;
                      int num9 = 0;
                      SimpleList simpleList = new SimpleList();
                      int unitCounter = this.game.Data.UnitCounter;
                      for (int index5 = 0; index5 <= unitCounter; ++index5)
                      {
                        if (this.game.Data.UnitObj[index5].Regime == this.game.Data.UnitObj[unr].Regime & this.game.Data.UnitObj[index5].PreDef == -1)
                        {
                          int sfCount2 = this.game.Data.UnitObj[index5].SFCount;
                          for (int index6 = 0; index6 <= sfCount2; ++index6)
                          {
                            i2 = this.game.Data.UnitObj[index5].SFList[index6];
                            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[i2].Type].Attacks > 0)
                            {
                              int num10 = this.game.Data.SFTypeObj[this.game.Data.SFObj[i2].Type].HitPointsDef[0];
                              simpleList.AddWeight(this.game.Data.SFObj[i2].Type, num10 * this.game.Data.SFObj[i2].Qty);
                              num8 += this.game.Data.SFObj[i2].Qty;
                            }
                          }
                          ++num9;
                        }
                      }
                      simpleList.ReverseSortHighSpeed();
                      if (simpleList.Counter > -1)
                      {
                        num5 = simpleList.Id[0];
                        if (num9 > 0)
                          num4 = (int) Math.Round((double) num8 / (double) (num9 * 2)) + 1;
                      }
                    }
                  }
                }
                else
                {
                  reconMinusHide.x = 3;
                  this.UList[index1].previewInfoLevel = reconMinusHide.x;
                }
              }
              else if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | !this.game.Data.FOWOn | this.game.Data.Round == 0)
                reconMinusHide.x = 3;
              else
                reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unr, this.game.Data.Turn);
              int num11 = num4;
              for (int index7 = 1; index7 <= num11; ++index7)
              {
                ++this.IDcounter;
                ++this.ICounter;
                this.IList = (Individual[]) Utils.CopyArray((Array) this.IList, (Array) new Individual[this.ICounter + 1]);
                this.IList[this.ICounter].IBreakTrough = 0;
                int landscapeType = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].LandscapeType;
                this.IList[this.ICounter].IInitThrow = 0;
                this.IList[this.ICounter].IKilled = 0;
                this.IList[this.ICounter].ILastAttacked = 0;
                this.IList[this.ICounter].IID = this.IDcounter;
                this.IList[this.ICounter].IUnr = unr;
                this.IList[this.ICounter].IUlistNr = index1;
                this.IList[this.ICounter].IRdn = this.game.Data.SFObj[sf].Rdn;
                this.IList[this.ICounter].IRetreat = 0;
                this.IList[this.ICounter].IRetreated = 0;
                this.IList[this.ICounter].IRetreatMode = 0;
                this.IList[this.ICounter].ISFNr = sf;
                this.IList[this.ICounter].IXp = this.game.Data.SFObj[sf].Xp;
                this.IList[this.ICounter].IMor = this.game.Data.SFObj[sf].Mor;
                this.IList[this.ICounter].IAttacker = this.UList[index1].Uattacker;
                this.IList[this.ICounter].ISFType = this.game.Data.SFObj[sf].Type;
                if (num5 > -1)
                  this.IList[this.ICounter].ISFType = num5;
                this.IList[this.ICounter].IParadropper = this.UList[index1].UParadropper;
                this.IList[this.ICounter].IRdnInitial = this.IList[this.ICounter].IRdn;
                this.IList[this.ICounter].IMorInitial = this.IList[this.ICounter].IMor;
                this.IList[this.ICounter].IXpInitial = this.IList[this.ICounter].IXp;
                this.IList[this.ICounter].IEntrenchInitial = this.game.Data.SFObj[sf].CurrentEntrench;
                this.IList[this.ICounter].IleftOutOfPartialAttack = flag2;
                if (flag2)
                  this.somePartialAttackPresent = true;
                this.IList[this.ICounter].IHistoricInit = new int[50];
                if ((double) this.game.Data.RuleVar[431] > 0.0)
                {
                  if ((double) this.game.Data.RuleVar[419] > 0.0)
                  {
                    int num12;
                    if (this.CombatType == 3 | this.CombatType == 4)
                    {
                      int maxValue = (int) Math.Round((double) this.game.Data.RuleVar[55]) + (int) Math.Round((double) ((int) Math.Round((double) this.game.Data.RuleVar[56]) - (int) Math.Round((double) this.game.Data.RuleVar[55])) / 2.0);
                      num12 = (int) Math.Round((double) (random.Next((int) Math.Round((double) this.game.Data.RuleVar[55]), maxValue) + random.Next((int) Math.Round((double) this.game.Data.RuleVar[55]), maxValue)) / 2.0);
                    }
                    else
                    {
                      int maxValue = (int) Math.Round((double) this.game.Data.RuleVar[55]) + (int) Math.Round((double) ((int) Math.Round((double) this.game.Data.RuleVar[56]) - (int) Math.Round((double) this.game.Data.RuleVar[55])) / 2.0);
                      num12 = (int) Math.Round((double) (random.Next(0, maxValue) + random.Next(0, maxValue)) / 2.0);
                    }
                    int num13 = num12 + this.GetIndividualHide(this.ICounter);
                    if (this.IList[this.ICounter].IAttacker == 0)
                      index1 = index1;
                    this.IList[this.ICounter].IvisibleFromRound = 999999;
                    int num14 = (int) Math.Round((double) this.game.Data.RuleVar[56]);
                    if (this.IList[this.ICounter].IUnr == 135)
                      index1 = index1;
                    if (num13 > num14)
                      num13 = num14 + (int) Math.Round((double) (num13 - num14) / 2.0);
                    if (num13 > num14 + 5)
                      num13 = num14 + 5 + (int) Math.Round((double) (num13 - (num14 + 5)) / 2.0);
                    i2 = this.GetEffectiveReconOnHexOfTargettedIndividual(this.ICounter);
                    int num15 = (int) Math.Round((double) this.game.Data.RuleVar[55]) + (int) Math.Round((double) ((int) Math.Round((double) this.game.Data.RuleVar[56]) - (int) Math.Round((double) this.game.Data.RuleVar[55])) / 2.0) + this.GetIndividualHide(this.ICounter);
                    if (this.IList[this.ICounter].IUnr == 202)
                      index1 = index1;
                    if (i2 >= num13 & reconMinusHide.x <= 1 & num15 > num13 & num15 >= i2 + 1)
                      num13 = DrawMod.RandyNumber.Next(i2 + 1, num15 + 1);
                    else if (i2 >= num13 & reconMinusHide.x <= 1)
                      num13 = i2 + 1;
                    if (num13 > 90)
                      num13 = 90;
                    this.IList[this.ICounter].IcoverPoints = (float) num13;
                  }
                  else
                  {
                    this.IList[this.ICounter].IcoverPoints = (float) random.Next((int) Math.Round((double) this.game.Data.RuleVar[55]), (int) Math.Round((double) this.game.Data.RuleVar[55]) + (int) Math.Round((double) ((int) Math.Round((double) this.game.Data.RuleVar[56]) - (int) Math.Round((double) this.game.Data.RuleVar[55])) / 2.0));
                    Individual[] ilist = this.IList;
                    Individual[] individualArray = ilist;
                    int icounter = this.ICounter;
                    int index8 = icounter;
                    individualArray[index8].IcoverPoints = ilist[icounter].IcoverPoints + (float) this.GetIndividualHide(this.ICounter);
                    this.IList[this.ICounter].IvisibleFromRound = 999999;
                    if (this.CombatType == 13 | this.CombatType == 5 && this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].Theater == 2)
                    {
                      this.IList[this.ICounter].IcoverPoints = 0.0f;
                      this.IList[this.ICounter].IvisibleFromRound = 0;
                    }
                  }
                }
                else
                {
                  this.IList[this.ICounter].IcoverPoints = 0.0f;
                  this.IList[this.ICounter].IvisibleFromRound = 0;
                }
                if ((double) this.game.Data.RuleVar[419] > 0.0)
                {
                  if (this.CombatType == 3 & this.UList[index1].Uattacker == 1 | flag2)
                  {
                    if (this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directRange >= maxDist)
                    {
                      this.IList[this.ICounter].IdirectFire = true;
                      this.IList[this.ICounter].IdirectMod = (float) this.game.EditObj.TempLos[0].Value[this.CombatTarget.x, this.CombatTarget.y];
                      this.IList[this.ICounter].IdirectMod = (float) ((double) this.IList[this.ICounter].IdirectMod * (double) this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directModFirstHex / 100.0);
                      int num16 = maxDist;
                      for (int index9 = 2; index9 <= num16; ++index9)
                        this.IList[this.ICounter].IdirectMod = (float) ((double) this.IList[this.ICounter].IdirectMod * (double) this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directModPerHex / 100.0);
                    }
                    else
                    {
                      this.IList[this.ICounter].IdirectFire = false;
                      this.IList[this.ICounter].IdirectMod = 0.0f;
                    }
                  }
                  else if ((this.CombatType == 3 | flag1) & this.UList[index1].Uattacker == 0 & !this.InterceptFire)
                  {
                    this.IList[this.ICounter].IdirectFireDef = new bool[this.UCounter + 1];
                    this.IList[this.ICounter].IdirectModDef = new float[this.UCounter + 1];
                    int ucounter6 = this.UCounter;
                    for (int index10 = 0; index10 <= ucounter6; ++index10)
                    {
                      if (this.UList[index10].Uattacker == 1)
                      {
                        int num17 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index10].UNr].X, this.game.Data.UnitObj[this.UList[index10].UNr].Y, 0, this.CombatTarget.x, this.CombatTarget.y, 0, 99);
                        if (this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directRange >= num17)
                        {
                          this.IList[this.ICounter].IdirectFireDef[index10] = true;
                          this.IList[this.ICounter].IdirectModDef[index10] = (float) this.game.EditObj.TempLos[0].Value[this.game.Data.UnitObj[this.UList[index10].UNr].X, this.game.Data.UnitObj[this.UList[index10].UNr].Y];
                          this.IList[this.ICounter].IdirectModDef[index10] = (float) ((double) this.IList[this.ICounter].IdirectModDef[index10] * (double) this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directModFirstHex / 100.0);
                          int num18 = num17;
                          for (int index11 = 2; index11 <= num18; ++index11)
                            this.IList[this.ICounter].IdirectModDef[index10] = (float) ((double) this.IList[this.ICounter].IdirectModDef[index10] * (double) this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directModPerHex / 100.0);
                        }
                        else
                        {
                          this.IList[this.ICounter].IdirectFireDef[index10] = false;
                          this.IList[this.ICounter].IdirectModDef[index10] = 0.0f;
                        }
                      }
                    }
                  }
                  else if (this.CombatType == 1 & this.UList[index1].Uattacker == 0 & this.UList[index1].USupportInterceptFire)
                  {
                    this.IList[this.ICounter].IdirectFireDef = new bool[this.UCounter + 1];
                    this.IList[this.ICounter].IdirectModDef = new float[this.UCounter + 1];
                    int ucounter7 = this.UCounter;
                    for (int index12 = 0; index12 <= ucounter7; ++index12)
                    {
                      if (this.UList[index12].Uattacker == 1)
                      {
                        int num19 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.UList[index12].UNr].X, this.game.Data.UnitObj[this.UList[index12].UNr].Y, 0, this.CombatTarget.x, this.CombatTarget.y, 0, 99);
                        if (this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directRange >= num19)
                        {
                          this.IList[this.ICounter].IdirectFireDef[index12] = true;
                          this.IList[this.ICounter].IdirectModDef[index12] = (float) this.game.EditObj.TempLos[0].Value[this.game.Data.UnitObj[this.UList[index12].UNr].X, this.game.Data.UnitObj[this.UList[index12].UNr].Y];
                          this.IList[this.ICounter].IdirectModDef[index12] = (float) ((double) this.IList[this.ICounter].IdirectModDef[index12] * (double) this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directModFirstHex / 100.0);
                          int num20 = num19;
                          for (int index13 = 2; index13 <= num20; ++index13)
                            this.IList[this.ICounter].IdirectModDef[index12] = (float) ((double) this.IList[this.ICounter].IdirectModDef[index12] * (double) this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directModPerHex / 100.0);
                        }
                        else
                        {
                          this.IList[this.ICounter].IdirectFireDef[index12] = false;
                          this.IList[this.ICounter].IdirectModDef[index12] = 0.0f;
                        }
                      }
                    }
                  }
                }
                this.IList[this.ICounter].IHp = 0;
                if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].DepletingHitpointRule > 0)
                {
                  float num21 = 1f;
                  if ((double) this.game.Data.RuleVar[407] > 0.0)
                  {
                    int index14 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 2;
                    int index15 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 3;
                    int index16 = (int) Math.Round((double) this.game.Data.RuleVar[407]) + 4;
                    if (index14 > 0 & (index15 > 0 | index16 > 0))
                    {
                      int tid = this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].SFTypeVar[index14];
                      int num22 = this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].SFTypeVar[index15];
                      int num23 = this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].SFTypeVar[index16];
                      i2 = this.IList[this.ICounter].IAttacker != 1 ? num23 : num22;
                      int weight = this.game.Data.UnitObj[this.IList[this.ICounter].IUnr].items.list.FindWeight(tid);
                      if (i2 > 0)
                      {
                        num21 = (float) weight / (float) i2;
                        if ((double) num21 > 1.0)
                          num21 = 1f;
                      }
                      else
                        num21 = 1f;
                    }
                  }
                  this.IList[this.ICounter].IHp = (int) Math.Round((double) ((float) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].HitPoints[0] * num21));
                }
                if (this.UList[index1].UAA == 1)
                  this.IList[this.ICounter].IAA = 1;
                if (this.UList[index1].Uattacker == 0 & this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].Theater == 0)
                  this.IList[this.ICounter].IEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
                else if ((this.CombatType == 3 | this.CombatType == 4) & this.game.Data.Product >= 6)
                  this.IList[this.ICounter].IEntrench = this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].ArtRange <= 0 ? (this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].directRange <= 0 ? 0 : this.game.Data.SFObj[sf].CurrentEntrench) : this.game.Data.SFObj[sf].CurrentEntrench;
                else if (this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].ArtRange < 1)
                  this.IList[this.ICounter].IEntrench = 0;
                else if (this.game.Data.Product >= 6)
                  this.IList[this.ICounter].IEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
                int unitGroup = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup;
                if (this.previewMode)
                {
                  this.IList[this.ICounter].previewCoverPoints = (int) Math.Round((double) this.IList[this.ICounter].IcoverPoints);
                  this.IList[this.ICounter].IcoverPoints = 0.0f;
                  this.IList[this.ICounter].IvisibleFromRound = 0;
                  if (reconMinusHide.x == 2)
                  {
                    int num24 = 1;
                    do
                    {
                      if (num24 == 1)
                        i2 = averageRdn;
                      if (num24 == 2)
                        i2 = averageXp;
                      if (num24 == 3)
                        i2 = averageMor;
                      if (num24 == 4)
                        i2 = averageEntrench;
                      this.game.HandyFunctionsObj.RandomizeForUnit(unr, i2);
                      float num25 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
                      float num26 = (float) ((1.0 - (double) num25) * 2.0);
                      float num27 = VBMath.Rnd() * num26 + num25;
                      i2 = (int) Math.Round((double) Conversion.Int((float) i2 * num27));
                      if (i2 < 0)
                        i2 = 0;
                      if (i2 > 100)
                        i2 = 100;
                      if (num24 == 1)
                        this.IList[this.ICounter].IRdn = i2;
                      if (num24 == 2)
                        this.IList[this.ICounter].IXp = i2;
                      if (num24 == 3)
                        this.IList[this.ICounter].IMor = i2;
                      if (num24 == 4)
                        this.IList[this.ICounter].IEntrench = i2;
                      ++num24;
                    }
                    while (num24 <= 4);
                  }
                  else if (reconMinusHide.x < 2)
                  {
                    this.IList[this.ICounter].IRdn = 100;
                    this.IList[this.ICounter].IXp = 20;
                    this.IList[this.ICounter].IMor = 70;
                    this.IList[this.ICounter].IEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(this.TargetX, this.TargetY, 0, this.game.Data.SFTypeObj[this.IList[this.ICounter].ISFType].UnitGroup);
                    this.IList[this.ICounter].IcoverPoints = 0.0f;
                    this.IList[this.ICounter].IvisibleFromRound = 0;
                  }
                }
              }
            }
          }
        }
      }
    }

    public bool OtherSideStillFighting(int seenfromside)
    {
      int num = 0;
      int icounter = this.ICounter;
      for (int index = 0; index <= icounter; ++index)
      {
        if (this.IList[index].IAttacker != seenfromside && this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0 & this.IList[index].IRetreated == 0)
          ++num;
      }
      return num > 0;
    }

    public void CheckOutOfAP()
    {
      int num1 = 0;
      int num2 = 0;
      int icounter1 = this.ICounter;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IAttacker == 0)
        {
          ++num2;
          if (this.IList[index].IRetreat == 0 && this.IList[index].IKilled == 0)
            ++num1;
        }
      }
      if (this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15)
        num1 = 1;
      if (num2 == 0)
        num1 = 1;
      if (this.CombatType == 3 | this.CombatType == 4)
        num1 = 1;
      if (num1 == 0)
        return;
      int ucounter = this.UCounter;
      for (int fromy = 0; fromy <= ucounter; ++fromy)
      {
        if (this.UList[fromy].UParticipated > 0)
        {
          BattleUnit[] ulist = this.UList;
          BattleUnit[] battleUnitArray = ulist;
          int index1 = fromy;
          int index2 = index1;
          battleUnitArray[index2].UApSpend = ulist[index1].UApSpend + 10;
        }
        if (this.UList[fromy].URetreat == 0 & this.UList[fromy].Uattacker == 0)
        {
          if (this.CombatType == 9 & this.CombatRound == 5)
          {
            if (this.UList[fromy].UDefIntercept)
            {
              this.AddReport(0, "Unit out of AP", "Unit retreats due to max combatrounds for this engagement type reached.", fromy, this.CombatRound);
              int icounter2 = this.ICounter;
              for (int index = 0; index <= icounter2; ++index)
              {
                if (this.IList[index].IUnr == this.UList[fromy].UNr)
                {
                  this.IList[index].IRetreat = this.CombatRound;
                  this.IList[index].IRetreated = 1;
                  this.IList[index].IRetreatMode = 2;
                  this.IList[index].IOutOfAp = this.CombatRound;
                }
              }
              this.UList[fromy].URetreat = this.CombatRound;
              this.UList[fromy].URetreatMode = 2;
            }
            int icounter3 = this.ICounter;
            for (int index = 0; index <= icounter3; ++index)
            {
              if (this.IList[index].IRetreat == 0 & this.IList[index].IAttacker == 0 && this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 2)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
          }
          if (this.UList[fromy].UApSpend + 10 > this.UList[fromy].UMaxApToSpend)
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to being out of AP.", fromy, this.CombatRound);
            int icounter4 = this.ICounter;
            for (int index = 0; index <= icounter4; ++index)
            {
              if (this.IList[index].IUnr == this.UList[fromy].UNr)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 3;
          }
        }
        if (this.UList[fromy].URetreat == 0 & this.UList[fromy].Uattacker == 1)
        {
          if (this.UList[fromy].UApSpend + 10 > this.UList[fromy].UMaxApToSpend)
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to being out of AP.", fromy, this.CombatRound);
            int icounter5 = this.ICounter;
            for (int index = 0; index <= icounter5; ++index)
            {
              if (this.IList[index].IUnr == this.UList[fromy].UNr)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 3;
          }
          int num3 = 2;
          CustomCombatCalls customCombatObj1 = this.customCombatObj;
          CombatClass combatClass1 = this;
          ref CombatClass local1 = ref combatClass1;
          if (customCombatObj1.AlterCombatLastRound(ref local1) > 0)
          {
            CustomCombatCalls customCombatObj2 = this.customCombatObj;
            CombatClass combatClass2 = this;
            ref CombatClass local2 = ref combatClass2;
            num3 = customCombatObj2.AlterCombatLastRound(ref local2);
          }
          if ((this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15) & this.CombatRound == num3)
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to max combatrounds for this engagement type reached.", fromy, this.CombatRound);
            int icounter6 = this.ICounter;
            for (int index = 0; index <= icounter6; ++index)
            {
              if (this.IList[index].IUnr == this.UList[fromy].UNr)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 2;
          }
          if (this.CombatType == 11 & this.CombatRound == 2)
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to max combatrounds for this engagement type reached.", fromy, this.CombatRound);
            int icounter7 = this.ICounter;
            for (int index = 0; index <= icounter7; ++index)
            {
              if (this.IList[index].IUnr == this.UList[fromy].UNr)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 4;
          }
          if (this.InterceptFire & this.CombatRound >= (int) Math.Round((double) (this.game.Data.RuleVar[428] / 2f)))
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to max combatrounds for this engagement type reached.", fromy, this.CombatRound);
            int icounter8 = this.ICounter;
            for (int index = 0; index <= icounter8; ++index)
            {
              if (this.IList[index].IUnr == this.UList[fromy].UNr)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 4;
          }
          if (this.CombatType == 9 & this.CombatRound == 5)
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to max combatrounds for this engagement type reached.", fromy, this.CombatRound);
            if (!this.UList[fromy].UParadropper)
            {
              int icounter9 = this.ICounter;
              for (int index = 0; index <= icounter9; ++index)
              {
                if (this.IList[index].IUnr == this.UList[fromy].UNr)
                {
                  this.IList[index].IRetreat = this.CombatRound;
                  this.IList[index].IRetreated = 1;
                  this.IList[index].IRetreatMode = 2;
                  this.IList[index].IOutOfAp = this.CombatRound;
                }
              }
              this.DoParaDropperCasualties();
              this.UList[fromy].URetreat = this.CombatRound;
              this.UList[fromy].URetreatMode = 2;
            }
          }
        }
        else
        {
          if (this.UList[fromy].USupportInterceptFire & this.CombatRound >= (int) Math.Round((double) (this.game.Data.RuleVar[428] / 2f)))
          {
            this.AddReport(0, "Unit out of AP", "Unit retreats due to max combatrounds for this engagement type reached.", fromy, this.CombatRound);
            int icounter10 = this.ICounter;
            for (int index = 0; index <= icounter10; ++index)
            {
              if (this.IList[index].IUnr == this.UList[fromy].UNr)
              {
                this.IList[index].IRetreat = this.CombatRound;
                this.IList[index].IRetreated = 1;
                this.IList[index].IRetreatMode = 2;
                this.IList[index].IOutOfAp = this.CombatRound;
              }
            }
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 4;
          }
          if (this.CombatType == 9 & this.CombatRound == 5 && !this.UList[fromy].UParadropper)
            this.DoParaDropperCasualties();
        }
      }
    }

    public void DoParaDropperCasualties()
    {
      int icounter1 = this.ICounter;
      int num1;
      int num2;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IAttacker == 1 && !this.IList[index].IParadropper)
        {
          num1 += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
          if (this.IList[index].IKilled > 0)
            num2 += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
        }
      }
      float num3 = (float) num2 / (float) num1;
      this.AddBiggy("Paradroppers suffer " + Conversion.Str((object) Conversion.Int(num3 * 100f)) + "% casualties due to transport losses.");
      if ((double) num3 <= 0.0)
        return;
      int icounter2 = this.ICounter;
      for (int index = 0; index <= icounter2; ++index)
      {
        if (this.IList[index].IAttacker == 1 && this.IList[index].IParadropper && (double) VBMath.Rnd() < (double) num3)
          this.IList[index].IKilled = this.CombatRound;
      }
    }

    public void CheckSafeRetreat()
    {
      int icounter1 = this.ICounter;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IRetreat > 0 && this.IList[index].IRetreat + 2 <= this.CombatRound)
          this.IList[index].IRetreated = 1;
      }
      int[] numArray1 = new int[this.UCounter + 1];
      int[] numArray2 = new int[this.UCounter + 1];
      int icounter2 = this.ICounter;
      for (int index1 = 0; index1 <= icounter2; ++index1)
      {
        if (this.IList[index1].IKilled <= 0 & -(this.IList[index1].IBroken ? 1 : 0) <= 0 & -(this.IList[index1].ICapitulate ? 1 : 0) <= 0)
        {
          int[] numArray3 = numArray1;
          int[] numArray4 = numArray3;
          int iulistNr1 = this.IList[index1].IUlistNr;
          int index2 = iulistNr1;
          int num1 = numArray3[iulistNr1] + 1;
          numArray4[index2] = num1;
          if (this.IList[index1].IRetreated > 0)
          {
            int[] numArray5 = numArray2;
            int[] numArray6 = numArray5;
            int iulistNr2 = this.IList[index1].IUlistNr;
            int index3 = iulistNr2;
            int num2 = numArray5[iulistNr2] + 1;
            numArray6[index3] = num2;
          }
        }
      }
      int ucounter = this.UCounter;
      for (int index = 0; index <= ucounter; ++index)
      {
        if (this.UList[index].URetreated < 1 && numArray1[index] == numArray2[index] & numArray1[index] > 0)
          this.UList[index].URetreated = this.CombatRound;
      }
    }

    public void PreBattleStuff()
    {
      int num1 = num1;
      if (this.game.EditObj.CombatSim)
        return;
      if ((double) this.game.Data.RuleVar[435] > 0.0)
      {
        int ucounter = this.UCounter;
        for (int index1 = 0; index1 <= ucounter; ++index1)
        {
          int num2 = 0;
          int icounter = this.ICounter;
          int num3;
          for (int index2 = 0; index2 <= icounter; ++index2)
          {
            if (this.IList[index2].IUnr == this.UList[index1].UNr && !(this.CombatType == 12 | this.CombatType == 10) & !this.IList[index2].IParadropper)
            {
              num3 = this.UList[this.IList[index2].IUlistNr].UApMoveCost;
              if (num3 > 999)
                num3 = this.UList[this.IList[index2].IUlistNr].UMaxApToSpend;
              if (num3 > this.game.Data.SFObj[this.IList[index2].ISFNr].Ap)
                num3 = this.game.Data.SFObj[this.IList[index2].ISFNr].Ap;
              int isfType = this.IList[index2].ISFType;
              if (!this.IList[index2].IleftOutOfPartialAttack && num3 > num2)
                num2 = num3;
            }
          }
          this.UList[index1].UApMoveCost = num3;
        }
      }
      else
      {
        int icounter = this.ICounter;
        for (int index3 = 0; index3 <= icounter; ++index3)
        {
          if (index3 == 55)
            index3 = index3;
          if (this.IList[index3].IAttacker == 1 && !(this.CombatType == 12 | this.CombatType == 10) & !this.IList[index3].IParadropper)
          {
            int num4 = this.UList[this.IList[index3].IUlistNr].UApMoveCost;
            if (num4 > 999)
              num4 = this.UList[this.IList[index3].IUlistNr].UMaxApToSpend;
            int isfType = this.IList[index3].ISFType;
            if (this.game.Data.SFTypeObj[isfType].FuelForMove > 0 & this.game.Data.SFTypeObj[isfType].FuelRegimeVar > -1)
            {
              int currentSlot = this.game.Data.SFTypeObj[isfType].FuelRegimeVar;
              if ((double) this.game.Data.RuleVar[435] <= 0.0)
              {
                if ((double) this.game.Data.RuleVar[949] > 0.0)
                  currentSlot = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot, this.game.Data.UnitObj[this.UList[this.IList[index3].IUlistNr].UNr].RealX(ref this.game), this.game.Data.UnitObj[this.UList[this.IList[index3].IUlistNr].UNr].RealY(ref this.game));
                int num5 = (int) Math.Round((double) this.game.Data.SFTypeObj[isfType].FuelForMove * ((double) num4 / 10.0));
                if (this.game.Data.SFTypeObj[isfType].FuelForMove > num5)
                  num5 = this.game.Data.SFTypeObj[isfType].FuelForMove;
                int num6 = num5 * 1;
                if (this.game.Data.RegimeObj[this.AttackerRegime].RegimeSlot[currentSlot] >= num6)
                {
                  int[] regimeSlot = this.game.Data.RegimeObj[this.AttackerRegime].RegimeSlot;
                  int[] numArray1 = regimeSlot;
                  int index4 = currentSlot;
                  int index5 = index4;
                  int num7 = regimeSlot[index4] - num6;
                  numArray1[index5] = num7;
                  UnitClass[] unitObj = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray = unitObj;
                  int iunr = this.IList[index3].IUnr;
                  int index6 = iunr;
                  unitClassArray[index6].FuelUsedMove = unitObj[iunr].FuelUsedMove + num6;
                  int[] regimeSlotPredict = this.game.Data.RegimeObj[this.AttackerRegime].TempRegimeSlotPredict;
                  int[] numArray2 = regimeSlotPredict;
                  int index7 = currentSlot;
                  int index8 = index7;
                  int num8 = regimeSlotPredict[index7] - num6;
                  numArray2[index8] = num8;
                }
                else
                {
                  int num9 = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[index3].IUnr].Regime].RegimeSlot[currentSlot];
                  int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[index3].IUnr].Regime].RegimeSlot;
                  int[] numArray3 = regimeSlot;
                  int index9 = currentSlot;
                  int index10 = index9;
                  int num10 = regimeSlot[index9] - num9;
                  numArray3[index10] = num10;
                  int[] regimeSlotPredict = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.IList[index3].IUnr].Regime].TempRegimeSlotPredict;
                  int[] numArray4 = regimeSlotPredict;
                  int index11 = currentSlot;
                  int index12 = index11;
                  int num11 = regimeSlotPredict[index11] - num9;
                  numArray4[index12] = num11;
                  UnitClass[] unitObj = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray = unitObj;
                  int iunr = this.IList[index3].IUnr;
                  int index13 = iunr;
                  unitClassArray[index13].FuelUsedMove = unitObj[iunr].FuelUsedMove + num9;
                }
              }
            }
          }
        }
      }
    }

    public void MoraleTest()
    {
    }

    public void AddReport(
      int type,
      string title,
      string txt,
      int fromy,
      int round,
      string[,] matrx = null)
    {
      if (this.RepCounter > 60000)
        return;
      ++this.RepCounter;
      if (this.RepTitle.GetUpperBound(0) < this.RepCounter)
      {
        this.RepTitle = (string[]) Utils.CopyArray((Array) this.RepTitle, (Array) new string[this.RepCounter + 1000 + 1]);
        this.RepText = (string[]) Utils.CopyArray((Array) this.RepText, (Array) new string[this.RepCounter + 1000 + 1]);
        this.RepRound = (int[]) Utils.CopyArray((Array) this.RepRound, (Array) new int[this.RepCounter + 1000 + 1]);
        this.RepType = (int[]) Utils.CopyArray((Array) this.RepType, (Array) new int[this.RepCounter + 1000 + 1]);
        this.RepFrom = (int[]) Utils.CopyArray((Array) this.RepFrom, (Array) new int[this.RepCounter + 1000 + 1]);
        this.RepCom = (string[,,]) Utils.CopyArray((Array) this.RepCom, (Array) new string[61, 6, this.RepCounter + 1000 + 1]);
      }
      this.RepTitle[this.RepCounter] = title;
      this.RepText[this.RepCounter] = txt;
      this.RepType[this.RepCounter] = type;
      this.RepRound[this.RepCounter] = round;
      this.RepFrom[this.RepCounter] = fromy;
      if (Information.IsNothing((object) matrx))
        return;
      int index1 = 0;
      do
      {
        int index2 = 0;
        do
        {
          this.RepCom[index1, index2, this.RepCounter] = matrx[index1, index2];
          ++index2;
        }
        while (index2 <= 5);
        ++index1;
      }
      while (index1 <= 60);
    }

    public void CheckOrderlyUnitRetreat()
    {
      int ucounter = this.UCounter;
      for (int fromy = 0; fromy <= ucounter; ++fromy)
      {
        string title;
        string txt;
        if (!this.UList[fromy].UPanicked & this.UList[fromy].URetreat == 0)
        {
          int Number = this.game.Data.UnitObj[this.UList[fromy].UNr].SODefendPercent;
          if ((double) this.game.Data.RuleVar[482] > 0.0 & this.game.Data.Product >= 6 && this.UList[fromy].Uattacker == 1)
          {
            if (this.game.EditObj.attackTypeOption == 1)
            {
              Number = 90;
              if (this.CombatRound >= 2)
                Number = 101;
            }
            else if (this.game.EditObj.attackTypeOption == 2)
            {
              Number = 75;
              if (this.CombatRound >= 4)
                Number = 101;
            }
            else if (this.game.EditObj.attackTypeOption == 3 | this.game.EditObj.attackTypeOption == 0)
              Number = 50;
            else if (this.game.EditObj.attackTypeOption == 4)
              Number = 25;
          }
          if (!this.UList[fromy].UCanRetreat.onmap)
            Number = 0;
          if (this.CombatType == 3 | this.CombatType == 4)
            Number = 0;
          if ((this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15) & this.UList[fromy].Uattacker == 0 && this.game.Data.UnitObj[this.UList[fromy].UNr].X == this.TargetX & this.game.Data.UnitObj[this.UList[fromy].UNr].Y == this.TargetY & this.game.Data.UnitObj[this.UList[fromy].UNr].Map == this.TargetMap)
            Number = 0;
          if (this.CombatType == 9 | this.CombatType == 10 | this.CombatType == 12 & this.UList[fromy].Uattacker == 1)
            Number = 0;
          if (this.game.Data.Product > 4)
          {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            bool flag = false;
            int icounter = this.ICounter;
            for (int index = 0; index <= icounter; ++index)
            {
              if (this.IList[index].IAttacker == 1)
              {
                if (this.game.Data.SFTypeObj[this.IList[index].ISFType].DepletingHitpointRule < 1)
                {
                  if (this.IList[index].IRetreat < 1 & this.IList[index].IRetreated < 1)
                    ++num1;
                  else
                    ++num2;
                }
              }
              else if (this.IList[index].IAttacker == 0 && this.game.Data.SFTypeObj[this.IList[index].ISFType].DepletingHitpointRule < 1)
              {
                if (this.IList[index].IRetreat < 1 & this.IList[index].IRetreated < 1)
                  ++num3;
                else
                  ++num4;
              }
              if (this.game.Data.SFTypeObj[this.IList[index].ISFType].DepletingHitpointRule > 0 & this.game.Data.SFTypeObj[this.IList[index].ISFType].PreventCounter > -1 && this.IList[index].IUlistNr == fromy)
                flag = true;
            }
            if (flag)
            {
              if (this.UList[fromy].Uattacker == 1)
              {
                if (num1 < 1)
                  Number = 999;
              }
              else if (num3 < 1)
                Number = 999;
            }
          }
          if (Number > 0)
          {
            if (this.UList[fromy].URetreat == 0)
            {
              int num5 = 0;
              int num6 = 0;
              int icounter1 = this.ICounter;
              for (int index = 0; index <= icounter1; ++index)
              {
                if (this.IList[index].IUnr == this.UList[fromy].UNr && !this.IList[index].IleftOutOfPartialAttack | (double) this.game.Data.RuleVar[493] < 1.0)
                {
                  int num7 = 0;
                  if (this.IList[index].IRetreated > 0)
                    num7 = 1;
                  if (this.IList[index].IRetreat > 0)
                    num7 = 1;
                  if (this.IList[index].IKilled > 0)
                    num7 = 1;
                  if (num7 == 0)
                    num6 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
                  num5 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
                }
              }
              if (num5 == 0)
                num5 = 1;
              title = "Orderly retreat test";
              txt = "Units standing order is to retreat if less left then " + Strings.Trim(Conversion.Str((object) Number)) + "%." + "\r\n" + "Current troops left = " + Strings.Trim(Conversion.Str((object) Conversion.Int((double) (num6 * 100) / (double) num5))) + "%.";
              if ((double) (num6 * 100) / (double) num5 < (double) Number)
              {
                title = "Orderly retreat test : UNIT RETREATS";
                txt = txt + "\r\n" + "Results in retreat. ";
                string s = s + "Unit decides to retreat: " + this.game.Data.UnitObj[this.UList[fromy].UNr].Name;
                this.AddBiggy(s);
                this.UList[fromy].URetreat = this.CombatRound;
                this.UList[fromy].URetreatMode = 1;
                int icounter2 = this.ICounter;
                for (int inr = 0; inr <= icounter2; ++inr)
                {
                  if (this.IList[inr].IUnr == this.UList[fromy].UNr && this.IList[inr].IRetreated == 0 & this.IList[inr].IRetreat == 0)
                  {
                    this.IList[inr].IRetreat = this.CombatRound;
                    this.IList[inr].IRetreatMode = 2;
                    this.ReduceEntr(inr, (int) Math.Round((double) this.game.Data.RuleVar[126]));
                    int imor = this.IList[inr].IMor;
                    this.ReduceMor(inr, (int) Math.Round(Conversion.Int((double) (100 - Number) / 2.0)));
                    this.AddReport(0, "Morale penalty due to orderly retreat", "Loses morale equal to %=(100-" + Strings.Trim(Conversion.Str((object) Number)) + ")/2. Results in morale dropping from " + Strings.Trim(Conversion.Str((object) imor)) + " to " + Strings.Trim(Conversion.Str((object) this.IList[inr].IMor)) + ".", 10000 + inr, this.CombatRound);
                  }
                }
              }
            }
          }
          else
          {
            title = "Orderly retreat test skipped";
            txt = "No test is done because standing order retreat percentage or type of battle does not allow orderly retreats.";
          }
        }
        else
        {
          title = "Orderly retreat test skipped";
          txt = "No test is done because unit is already retreating or panicking.";
        }
        if (!(!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.UList[fromy].UNr].Regime, this.game.Data.Turn)))
          txt = "details hidden for FOW";
        this.AddReport(1, title, txt, fromy, this.CombatRound);
      }
    }

    public void CheckPanicUnitRetreat()
    {
      int ucounter = this.UCounter;
      for (int fromy = 0; fromy <= ucounter; ++fromy)
      {
        int num1;
        if (!this.UList[fromy].UCanRetreat.onmap)
        {
          num1 = 100 - 2 * this.game.HandyFunctionsObj.GetAverageMor(this.UList[fromy].UNr);
          if (num1 < 0)
            num1 = 0;
        }
        else
          num1 = 100 - this.game.HandyFunctionsObj.GetAverageMor(this.UList[fromy].UNr);
        int num2 = 100 - this.game.HandyFunctionsObj.GetAverageBaseMor(this.UList[fromy].UNr);
        if (this.CombatType == 3 | this.CombatType == 4)
          num1 = 0;
        if ((this.CombatType == 5 | this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15) & this.UList[fromy].Uattacker == 0 && this.game.Data.UnitObj[this.UList[fromy].UNr].X == this.TargetX & this.game.Data.UnitObj[this.UList[fromy].UNr].Y == this.TargetY & this.game.Data.UnitObj[this.UList[fromy].UNr].Map == this.TargetMap)
          num1 = 0;
        if ((double) this.game.Data.RuleVar[996] < 1.0)
          num2 = 0;
        if (num1 > 0 | num2 > 0 && this.UList[fromy].URetreat == 0)
        {
          int num3 = 0;
          int num4 = 0;
          int icounter1 = this.ICounter;
          for (int index = 0; index <= icounter1; ++index)
          {
            if (this.IList[index].IUnr == this.UList[fromy].UNr && !this.IList[index].IleftOutOfPartialAttack | (double) this.game.Data.RuleVar[493] < 1.0)
            {
              int num5 = 0;
              if (this.IList[index].IRetreated > 0)
                num5 = 1;
              if (this.IList[index].IRetreat > 0)
                num5 = 1;
              if (this.IList[index].IKilled > 0)
                num5 = 1;
              if (num5 == 0)
                num4 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
              num3 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
            }
          }
          if (num3 == 0)
            num3 = 1;
          if (this.UList[fromy].Uattacker == 0)
            ;
          int num6 = 0;
          string title = "Panic test";
          string str1 = "If % of troops left gets below " + Strings.Trim(Conversion.Str((object) Math.Round(new Decimal(num1), 1))) + "% then panic test must be made." + "\r\n";
          if ((double) this.game.Data.RuleVar[996] == 1.0)
            str1 = str1 + "If % of troops left gets below " + Strings.Trim(Conversion.Str((object) Math.Round(new Decimal(num2), 1))) + "% then a reduced chance panic test must be made." + "\r\n";
          string str2 = str1 + "Current % of troops left is " + Strings.Trim(Conversion.Str((object) Math.Round((double) (num4 * 100) / (double) num3))) + "%.";
          string str3;
          if ((double) (num4 * 100) / (double) num3 < (double) num1 & (this.game.Data.Product < 6 | (double) this.game.Data.RuleVar[996] < 1.0))
          {
            num6 = 1;
            str3 = str2 + "\r\n" + "Panic test has to be made. There is a " + Strings.Trim(Conversion.Str((object) (int) Math.Round((double) (this.game.Data.RuleVar[70] * 100f)))) + "% chance unit panics.";
            if (num6 == 1 && (double) VBMath.Rnd() >= (double) this.game.Data.RuleVar[70])
              num6 = 0;
          }
          else if ((double) (num4 * 100) / (double) num3 < (double) num2 & (double) this.game.Data.RuleVar[996] == 1.0 & this.game.Data.Product < 6)
          {
            num6 = 1;
            float num7 = (float) (50 - Math.Abs(num2 - num1));
            if ((double) num7 < 20.0)
              num7 = 20f;
            float num8 = num7 / 100f;
            str3 = str2 + "\r\n" + "Reduced Chance Panic test has to be made. There is a " + Strings.Trim(Conversion.Str((object) (int) Math.Round((double) this.game.Data.RuleVar[70] * (double) num8 * 100.0))) + "% chance unit panics.";
            if (num6 == 1 && (double) VBMath.Rnd() >= (double) this.game.Data.RuleVar[70] * (double) num8)
              num6 = 0;
          }
          else if ((double) (num4 * 100) / (double) num3 < (double) num1 & (double) this.game.Data.RuleVar[996] == 1.0 & this.game.Data.Product >= 6)
          {
            num6 = 1;
            float num9 = (float) (30 - (num2 - num1));
            if ((double) num9 < 10.0)
              num9 = 10f;
            float num10 = num9 / 100f;
            str3 = str2 + "\r\n" + "Panic test has to be made. There is a " + Strings.Trim(Conversion.Str((object) (int) Math.Round((double) this.game.Data.RuleVar[70] * (double) num10 * 100.0))) + "% chance unit panics.";
            if (num6 == 1 && (double) VBMath.Rnd() >= (double) this.game.Data.RuleVar[70] * (double) num10)
              num6 = 0;
          }
          else
            str3 = str2 + "\r\n" + "Unit does not have to make a panic test.";
          if (num6 == 1 && this.customCombatObj.HasCustumCalls())
          {
            string s9 = "";
            if (this.customCombatObj.UnitCombatCall_AvoidPanic(this.game, this.UList[fromy].UNr, ref s9) > 0 & s9.Length > 0)
            {
              num6 = 0;
              str3 = str3 + "\r\n" + s9;
            }
          }
          string txt;
          if (num6 == 1)
          {
            string s = s + "Unit Panics!: " + this.game.Data.UnitObj[this.UList[fromy].UNr].Name;
            string str4 = str3 + "\r\n";
            title = "Panic test : UNIT PANICKS!";
            txt = str4 + "Unit fails panic test and panicks!";
            this.UList[fromy].UPanicked = true;
            this.AddBiggy(s);
            this.UList[fromy].URetreat = this.CombatRound;
            this.UList[fromy].URetreatMode = 5;
            int peopleGroup = this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.UnitObj[this.UList[fromy].UNr].Regime].People].PeopleGroup;
            int icounter2 = this.ICounter;
            for (int inr = 0; inr <= icounter2; ++inr)
            {
              if (this.IList[inr].IUnr == this.UList[fromy].UNr && this.IList[inr].IRetreated == 0 & this.IList[inr].IRetreat == 0)
              {
                this.IList[inr].IRetreat = this.CombatRound;
                this.IList[inr].IRetreatMode = 3;
                this.ReduceEntr(inr, (int) Math.Round((double) this.game.Data.RuleVar[126]));
                this.ReduceMor(inr, (int) Math.Round((double) this.game.Data.RuleVar[129]));
                int num11 = this.game.Data.PeopleObj[this.game.Data.SFObj[this.IList[inr].ISFNr].People].BaseMorale[peopleGroup];
                if (this.IList[inr].IMor > num11)
                  this.IList[inr].IMor = num11;
              }
            }
          }
          else
            txt = str3 + " Unit does not panic.";
          if (!(!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.UList[fromy].UNr].Regime, this.game.Data.Turn)))
            txt = "Details hidden for FOW";
          this.AddReport(0, title, txt, fromy, this.CombatRound);
        }
      }
    }

    public void CheckBreak()
    {
      if ((double) this.game.Data.RuleVar[354] == 0.0)
        return;
      int ucounter = this.UCounter;
      for (int fromy = 0; fromy <= ucounter; ++fromy)
      {
        if (this.UList[fromy].URetreat == this.CombatRound & this.UList[fromy].Uattacker == 0 & !this.game.Data.UnitObj[this.UList[fromy].UNr].IsHQ)
        {
          bool flag = true;
          if (this.game.Data.Product >= 6 && this.UList[fromy].URetreatMode != 5)
          {
            flag = false;
            if (this.game.Data.Product == 6 && this.UList[fromy].URetreatMode > 0)
            {
              int num1 = 0;
              int icounter = this.ICounter;
              for (int index = 0; index <= icounter; ++index)
              {
                if (this.IList[index].IUlistNr == fromy && this.IList[index].IKilled < 1 & this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 0)
                  num1 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
              }
              if ((double) num1 < (double) this.game.Data.RuleVar[476])
              {
                int num2 = (int) Math.Round((double) ((float) (100 * num1) / this.game.Data.RuleVar[476]));
                if (DrawMod.RandyNumber.Next(0, 100) > num2)
                  flag = true;
              }
            }
          }
          if (flag)
          {
            int num3 = 0;
            int num4 = 0;
            int icounter1 = this.ICounter;
            for (int index = 0; index <= icounter1; ++index)
            {
              if (this.IList[index].IUlistNr == fromy && this.IList[index].IKilled < 1 & this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 0)
              {
                num3 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
                if (this.game.Data.PeopleObj[this.game.Data.SFObj[this.IList[index].ISFNr].People].BreakAt > -1)
                  num4 += this.game.Data.PeopleObj[this.game.Data.SFObj[this.IList[index].ISFNr].People].BreakAt * this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
              }
            }
            if (num3 > 0)
            {
              string title = "Breaking test";
              string str1 = "Done in the round retreat starts.";
              int Number1 = (int) Math.Round(Conversion.Int((double) num4 / (double) num3));
              int num5 = this.game.HandyFunctionsObj.GetStartPower(this.UList[fromy].UNr);
              int unr = this.UList[fromy].UNr;
              if (this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].ModelMaster > -1 && this.game.Data.UnitObj[unr].HistoricalSubPart > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].SubParts[this.game.Data.UnitObj[unr].HistoricalSubPart] > -1)
              {
                int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].SubParts[this.game.Data.UnitObj[unr].HistoricalSubPart]);
                if (preDef > -1)
                  num5 = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(preDef, true);
              }
              if (this.game.HandyFunctionsObj.CheckIsBattlegroup(this.UList[fromy].UNr))
                num5 = 999999;
              string txt = str1 + "\r\n" + "Breakpoint is at " + Strings.Trim(Conversion.Str((object) Number1)) + "% left of original size. Current size is " + Strings.Trim(Conversion.Str((object) (int) Math.Round((double) (num3 * 100) / (double) num5))) + "%.";
              if (num5 > 0 && (int) Math.Round((double) (num3 * 100) / (double) num5) <= Number1)
              {
                string str2 = txt + "\r\n" + "Unit qualifies for a break-test.";
                int num6 = this.game.HandyFunctionsObj.GetStartPower(this.UList[fromy].UNr);
                if (this.game.HandyFunctionsObj.CheckIsBattlegroup(this.UList[fromy].UNr))
                  num6 = 999999;
                int Number2 = 0;
                if (num6 > 0)
                  Number2 = (int) Math.Round((double) (Number1 - (int) Math.Round((double) (num3 * 100) / (double) num6)) * (100.0 / (double) Number1));
                txt = str2 + "\r\n" + "Chance unit breaks is set at " + Strings.Trim(Conversion.Str((object) Number2)) + "%.";
                if (this.UList[fromy].URetreatMode == 5)
                {
                  Number2 *= 2;
                  if (Number2 > 100)
                    Number2 = 100;
                  txt = txt + "\r\n" + "Due to unit is in panickin instead of orderly retreating the chance is doubled. Chance is set at " + Strings.Trim(Conversion.Str((object) Number2)) + "%.";
                }
                if ((double) VBMath.Rnd() * 100.0 < (double) Number2)
                {
                  int num7 = 0;
                  int num8 = 0;
                  int icounter2 = this.ICounter;
                  for (int index = 0; index <= icounter2; ++index)
                  {
                    if (this.IList[index].IUnr == this.UList[fromy].UNr)
                    {
                      int num9 = 0;
                      if (this.IList[index].IKilled > 0)
                        num9 = 1;
                      if (num9 == 0)
                        num8 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
                      num7 += this.game.Data.SFTypeObj[this.IList[index].ISFType].PowerPts;
                    }
                  }
                  if (num8 > 0)
                  {
                    string str3 = txt + "\r\n";
                    title = "Breaking test : UNIT BREAKS";
                    txt = str3 + "Result of random roll is: Unit breaks!";
                    string s = s + "Unit Breaks: " + this.game.Data.UnitObj[this.UList[fromy].UNr].Name;
                    this.UList[fromy].UBreaks = true;
                    this.AddBiggy(s);
                    this.UList[fromy].URetreat = this.CombatRound;
                    this.UList[fromy].URetreatMode = 5;
                    int icounter3 = this.ICounter;
                    for (int inr = 0; inr <= icounter3; ++inr)
                    {
                      if (this.IList[inr].IUnr == this.UList[fromy].UNr && this.IList[inr].IKilled == 0)
                      {
                        this.IList[inr].IKilled = this.CombatRound;
                        this.IList[inr].IBroken = true;
                        this.IList[inr].ICapitulate = true;
                        this.IList[inr].IRetreatMode = 3;
                        this.ReduceMor(inr, (int) Math.Round((double) this.game.Data.RuleVar[129]));
                      }
                    }
                  }
                }
                else
                  txt = txt + "\r\n" + "Result of random roll is: Unit holds!";
              }
              if (!(!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.UList[fromy].UNr].Regime, this.game.Data.Turn)))
                txt = "details hidden for FOW";
              this.AddReport(0, title, txt, fromy, this.CombatRound);
            }
          }
        }
      }
    }

    public void FillEditObjHisLoss(int forReg = -1)
    {
      this.game.EditObj.HisLossCounter = -1;
      this.game.EditObj.HisLossAttacker = new int[1];
      this.game.EditObj.HisLossDEAD = new int[1];
      this.game.EditObj.HisLossOK = new int[1];
      this.game.EditObj.HisLossSFType = new int[1];
      this.game.EditObj.HisRegimeWon = -1;
      if ((double) this.game.Data.RuleVar[431] < 1.0 | forReg == -1)
      {
        int icounter = this.ICounter;
        for (int index1 = 0; index1 <= icounter; ++index1)
        {
          int num1 = -1;
          try
          {
            if (this.game.EditObj.HisLossCounter > -1)
            {
              int hisLossCounter = this.game.EditObj.HisLossCounter;
              for (int index2 = 0; index2 <= hisLossCounter; ++index2)
              {
                if (this.game.EditObj.HisLossAttacker[index2] == this.IList[index1].IAttacker & this.game.EditObj.HisLossSFType[index2] == this.IList[index1].ISFType)
                {
                  num1 = index2;
                  break;
                }
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            num1 = -1;
            ProjectData.ClearProjectError();
          }
          if (num1 == -1)
          {
            ++this.game.EditObj.HisLossCounter;
            if (this.game.EditObj.HisLossCounter == -1)
              this.game.EditObj.HisLossCounter = 0;
            this.game.EditObj.HisLossAttacker = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossAttacker, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossDEAD = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossDEAD, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossOK = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossOK, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossSFType = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossSFType, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossAttacker[this.game.EditObj.HisLossCounter] = this.IList[index1].IAttacker;
            this.game.EditObj.HisLossSFType[this.game.EditObj.HisLossCounter] = this.IList[index1].ISFType;
            num1 = this.game.EditObj.HisLossCounter;
          }
          if (this.IList[index1].IKilled > 0)
          {
            int[] hisLossDead = this.game.EditObj.HisLossDEAD;
            int[] numArray = hisLossDead;
            int index3 = num1;
            int index4 = index3;
            int num2 = hisLossDead[index3] + 1;
            numArray[index4] = num2;
          }
          else
          {
            int[] hisLossOk = this.game.EditObj.HisLossOK;
            int[] numArray = hisLossOk;
            int index5 = num1;
            int index6 = index5;
            int num3 = hisLossOk[index5] + 1;
            numArray[index6] = num3;
          }
        }
      }
      else
      {
        int icounter = this.ICounter;
        for (int index7 = 0; index7 <= icounter; ++index7)
        {
          int num4 = this.IList[index7].ISFType;
          if (!(!this.game.Data.FOWOn | this.IList[index7].IvisibleFromRound < this.CombatRound | forReg == this.AttackerRegime & this.IList[index7].IAttacker == 1 | forReg == this.DefenderRegime & this.IList[index7].IAttacker == 0))
          {
            if (!(this.game.Data.Product == 6 & (this.IList[index7].IAttacker == 1 & forReg == this.AttackerRegime | this.IList[index7].IAttacker == 0 & forReg == this.DefenderRegime)))
            {
              if (!(this.InterceptFire & this.IList[index7].IAttacker == 0 & forReg == this.game.Data.Turn & this.DefenderRegime == forReg))
                num4 = -1;
            }
          }
          int num5 = -1;
          try
          {
            if (this.game.EditObj.HisLossCounter > -1)
            {
              int hisLossCounter = this.game.EditObj.HisLossCounter;
              for (int index8 = 0; index8 <= hisLossCounter; ++index8)
              {
                if (this.game.EditObj.HisLossAttacker[index8] == this.IList[index7].IAttacker & this.game.EditObj.HisLossSFType[index8] == num4)
                {
                  num5 = index8;
                  break;
                }
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            num5 = -1;
            ProjectData.ClearProjectError();
          }
          if (num5 == -1)
          {
            ++this.game.EditObj.HisLossCounter;
            if (this.game.EditObj.HisLossCounter == -1)
              this.game.EditObj.HisLossCounter = 0;
            this.game.EditObj.HisLossAttacker = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossAttacker, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossDEAD = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossDEAD, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossOK = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossOK, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossSFType = (int[]) Utils.CopyArray((Array) this.game.EditObj.HisLossSFType, (Array) new int[this.game.EditObj.HisLossCounter + 1]);
            this.game.EditObj.HisLossAttacker[this.game.EditObj.HisLossCounter] = this.IList[index7].IAttacker;
            this.game.EditObj.HisLossSFType[this.game.EditObj.HisLossCounter] = num4;
            num5 = this.game.EditObj.HisLossCounter;
          }
          if (this.IList[index7].IKilled > 0)
          {
            int[] hisLossDead = this.game.EditObj.HisLossDEAD;
            int[] numArray = hisLossDead;
            int index9 = num5;
            int index10 = index9;
            int num6 = hisLossDead[index9] + 1;
            numArray[index10] = num6;
          }
          else
          {
            int[] hisLossOk = this.game.EditObj.HisLossOK;
            int[] numArray = hisLossOk;
            int index11 = num5;
            int index12 = index11;
            int num7 = hisLossOk[index11] + 1;
            numArray[index12] = num7;
          }
        }
      }
    }

    public void CheckVictory()
    {
      int location1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].Location;
      int num1;
      if (this.game.Data.Product >= 6 && (double) this.game.Data.RuleVar[431] > 0.0 && this.CombatType == 3 && (double) this.game.Data.RuleVar[55] > (double) this.game.Data.MapObj[0].HexObj[this.TargetX, this.TargetY].MaxRecon)
      {
        int num2;
        num1 = num2 + 1;
      }
      int icounter1 = this.ICounter;
      int num3;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IRetreated == 0 & this.IList[index].IKilled == 0 & this.IList[index].IAA <= 0)
        {
          if (this.IList[index].IAttacker == 1)
            ++num3;
          else
            ++num1;
        }
      }
      if (num1 == 0 & num3 > 0)
      {
        if (this.CombatType == 6 || this.CombatType == 5 & (double) this.game.Data.RuleVar[341] == 1.0 & this.CombatRound <= 10)
          return;
        if (this.CombatType == 3 | this.CombatType == 4 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].Location > -1 | this.game.Data.Product == 6)
        {
          if (this.game.Data.Product < 6)
            return;
          ++num1;
        }
      }
      if (num3 == 0 | num1 == 0)
      {
        int dam = 0 + this.AntiStrucDam;
        if (this.customCombatObj.HasCustumCalls())
        {
          CustomCombatCalls customCombatObj = this.customCombatObj;
          CombatClass combatClass = this;
          ref CombatClass local = ref combatClass;
          GameClass game = this.game;
          int antiStrucDam = this.AntiStrucDam;
          customCombatObj.StartCombatRound(ref local, game, antiStrucDam);
        }
        if (!this.game.EditObj.CombatSim && dam > 0)
        {
          if (this.customCombatObj.HasCustumCalls())
          {
            CustomCombatCalls customCombatObj = this.customCombatObj;
            CombatClass combatClass = this;
            ref CombatClass local = ref combatClass;
            GameClass game = this.game;
            int damPts = dam;
            customCombatObj.DoStructuralDamageCall(ref local, game, damPts);
          }
          if (this.CombatType == 6 & this.game.EditObj.OrderBombMode == 1)
            this.game.HandyFunctionsObj.DoStrucPtsDammage(this.TargetX, this.TargetY, this.TargetMap, dam, true, false);
          else if (this.CombatType == 6 & this.game.EditObj.OrderBombMode == 0)
            this.game.HandyFunctionsObj.DoStrucPtsDammage(this.TargetX, this.TargetY, this.TargetMap, dam, both: false);
          else
            this.game.HandyFunctionsObj.DoStrucPtsDammage(this.TargetX, this.TargetY, this.TargetMap, dam);
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].Location == -1 & location1 != -1)
          {
            int icounter2 = this.ICounter;
            for (int index = 0; index <= icounter2; ++index)
            {
              if (this.IList[index].IAttacker == 0)
              {
                this.IList[index].IEntrench = (int) Math.Round(Conversion.Int((double) this.IList[index].IEntrench / 3.0));
                if (this.IList[index].IEntrench > this.game.HandyFunctionsObj.GetMaximumEntrench(this.TargetX, this.TargetY, this.game.EditObj.MapSelected, this.game.Data.SFTypeObj[this.IList[index].ISFType].UnitGroup))
                  this.IList[index].IEntrench = this.game.HandyFunctionsObj.GetMaximumEntrench(this.TargetX, this.TargetY, this.game.EditObj.MapSelected, this.game.Data.SFTypeObj[this.IList[index].ISFType].UnitGroup);
              }
            }
            int ucounter = this.UCounter;
            for (int tunr = 0; tunr <= ucounter; ++tunr)
            {
              if (this.game.Data.UnitObj[this.UList[tunr].UNr].X == this.TargetX & this.game.Data.UnitObj[this.UList[tunr].UNr].Y == this.TargetY & this.game.Data.UnitObj[this.UList[tunr].UNr].Map == this.TargetMap)
                this.killairandnavy(tunr);
            }
          }
        }
        if (this.CombatType == 6)
        {
          int icounter3 = this.ICounter;
          for (int inr = 0; inr <= icounter3; ++inr)
          {
            if (this.IList[inr].IAttacker == 1 && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 2 & this.game.Data.SFTypeObj[this.IList[inr].ISFType].AntiStrucPts > 0)
            {
              int num4 = (int) Math.Round(Conversion.Int(160.0 * ((double) this.UList[this.IList[inr].IUlistNr].UApMoveCost / 100.0)));
              if (num4 > 160)
                num4 = 160;
              int pointstot = (int) Math.Round(Conversion.Int((double) (int) Math.Round((double) (VBMath.Rnd() * (float) num4)) / 10.0));
              this.AddXp(inr, pointstot);
            }
          }
        }
        if (this.CombatType == 13)
        {
          int icounter4 = this.ICounter;
          for (int inr = 0; inr <= icounter4; ++inr)
          {
            if (this.IList[inr].IAttacker == 1 && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 2)
            {
              int num5 = (int) Math.Round(Conversion.Int(80.0 * ((double) this.UList[this.IList[inr].IUlistNr].UApMoveCost / 100.0)));
              if (num5 > 80)
                num5 = 80;
              int pointstot = (int) Math.Round(Conversion.Int((double) (int) Math.Round((double) (VBMath.Rnd() * (float) num5)) / 10.0));
              this.AddXp(inr, pointstot);
            }
          }
        }
        if (this.CombatType == 9 | this.CombatType == 14 | this.CombatType == 15)
        {
          int icounter5 = this.ICounter;
          for (int inr = 0; inr <= icounter5; ++inr)
          {
            if (this.IList[inr].IAttacker == 1 && this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 2 & this.game.Data.SFTypeObj[this.IList[inr].ISFType].CarryCap > 0)
            {
              int num6 = (int) Math.Round(Conversion.Int(120.0 * ((double) this.UList[this.IList[inr].IUlistNr].UApMoveCost / 100.0)));
              if (num6 > 120)
                num6 = 120;
              int pointstot = (int) Math.Round(Conversion.Int((double) (int) Math.Round((double) (VBMath.Rnd() * (float) num6)) / 10.0));
              this.AddXp(inr, pointstot);
            }
          }
        }
      }
      if ((num3 == 0 | num1 == 0) & this.CombatType == 13 & this.CombatType2 != 16)
      {
        int num7 = 0;
        int icounter6 = this.ICounter;
        for (int index = 0; index <= icounter6; ++index)
        {
          if (this.IList[index].IAttacker == 1 && this.IList[index].IKilled == 0 & (this.IList[index].IRetreatMode == 2 | this.IList[index].IRetreatMode == 0))
            num7 += this.game.Data.SFTypeObj[this.IList[index].ISFType].ReconPts;
        }
        if (num7 > 0)
        {
          this.game.EditObj.CombatOneSentence = "Executed recon mission with " + Strings.Trim(Conversion.Str((object) num7)) + " recon points.";
          this.game.HandyFunctionsObj.DoAirRecon(this.TargetX, this.TargetY, this.TargetMap, num7, this.UList[0].UNr);
        }
      }
      if ((num3 == 0 | num1 == 0) & this.CombatType2 == 16)
      {
        this.se1carryPointsDelivered = 0;
        this.se1carryPointsTotal = 0;
        this.se1damagePercentage = 0;
        int icounter7 = this.ICounter;
        int num8;
        for (int index = 0; index <= icounter7; ++index)
        {
          if (this.IList[index].IAttacker == 1)
          {
            int carryCap = this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
            if (this.customCombatObj.HasCustumCalls())
            {
              int num9 = this.customCombatObj.UnitAirBridgeBonus(this.game, this.IList[index].IUnr);
              if (num9 > 0)
                carryCap += (int) Math.Round(Math.Ceiling((double) (carryCap * num9) / 100.0));
            }
            this.se1carryPointsTotal += carryCap;
            if (this.IList[index].IKilled == 0 & (this.IList[index].IRetreatMode == 2 | this.IList[index].IRetreatMode == 0))
              this.se1carryPointsDelivered += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
            if (this.IList[index].IKilled > 0)
              num8 += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
          }
        }
        if (this.se1carryPointsDelivered < 1)
          this.game.EditObj.CombatOneSentence = "Establishing Air Bridge failed due to enemy fire.";
        else
          this.game.EditObj.CombatOneSentence = "Air Bridge established with " + this.se1carryPointsDelivered.ToString() + " Log.Pts of " + this.se1carryPointsTotal.ToString() + ".";
        if (this.se1carryPointsDelivered > 0)
          this.se1damagePercentage = (int) Math.Round((double) num8 / (double) this.se1carryPointsDelivered);
      }
      if ((num3 == 0 | num1 == 0) & this.CombatType == 14)
      {
        int num10 = 0;
        int icounter8 = this.ICounter;
        for (int index = 0; index <= icounter8; ++index)
        {
          if (this.IList[index].IAttacker == 1 && this.IList[index].IKilled == 0 & (this.IList[index].IRetreatMode == 2 | this.IList[index].IRetreatMode == 0))
            num10 += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
        }
        int num11 = (int) Math.Round((double) Conversion.Int((float) num10 / (float) this.game.EditObj.AirSupplyCarry * (float) this.game.EditObj.AirSupplyPts));
        int num12;
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Location > -1)
        {
          int location2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Location;
          num12 = !(this.game.Data.LocTypeObj[this.game.Data.LocObj[location2].Type].IsAirfield | this.game.Data.LocObj[location2].isAirfield) ? (int) Math.Round((double) num11 * 0.5) : (int) Math.Round((double) num11 * (0.5 + 0.5 * ((double) this.game.Data.LocObj[location2].StructuralPts / (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[location2].Type].StructuralPts)));
        }
        else
          num12 = (int) Math.Round((double) num11 * 0.5);
        this.game.EditObj.CombatOneSentence = "Executed air supply mission. Delivered:  " + Strings.Trim(Conversion.Str((object) num12)) + " supply points of " + Strings.Trim(Conversion.Str((object) this.game.EditObj.AirSupplyPts));
        UnitClass[] unitObj = this.game.Data.UnitObj;
        UnitClass[] unitClassArray = unitObj;
        int airSupplyHq = this.game.EditObj.AirSupplyHq;
        int index1 = airSupplyHq;
        unitClassArray[index1].Supply = unitObj[airSupplyHq].Supply - this.game.EditObj.AirSupplyPts;
        this.game.HandyFunctionsObj.DisperseAirSupply(this.game.EditObj.TargetX, this.game.EditObj.TargetY, this.game.EditObj.TargetMap, num12);
      }
      if ((num3 == 0 | num1 == 0) & this.CombatType == 15)
      {
        int num13 = 0;
        int num14 = 0;
        int icounter9 = this.ICounter;
        for (int index = 0; index <= icounter9; ++index)
        {
          if (this.IList[index].IAttacker == 1)
          {
            if (!(this.IList[index].IKilled == 0 & (this.IList[index].IRetreatMode == 2 | this.IList[index].IRetreatMode == 0)))
              num13 += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
            num14 += this.game.Data.SFTypeObj[this.IList[index].ISFType].CarryCap;
          }
        }
        float num15 = (float) num13 / (float) num14;
        this.game.EditObj.CombatOneSentence = "Executed airlift mission. Lost " + Conversion.Str((object) Conversion.Int(num15 * 100f)) + "% of passengers.";
        this.game.EditObj.PassengerDammage = num15;
      }
      if (num3 == 0 & num1 > 0)
      {
        if ((double) this.game.Data.RuleVar[407] > 0.0)
          this.PayForLis();
        if ((double) this.game.Data.RuleVar[434] > 0.0)
          this.PayForSimplifiedSupplyRules();
        int ucounter = this.UCounter;
        for (int tunr = 0; tunr <= ucounter; ++tunr)
        {
          this.ReformUnit(tunr);
          if (this.UList[tunr].Uattacker == 1 & this.UList[tunr].UDead == 0)
          {
            this.AddDetail("Attacking unit retreats");
            this.DoRetreat(tunr);
          }
        }
        this.BattleEnded = 2;
        this.CombatLogBattles(2);
      }
      if (num1 == 0 & num3 > 0)
      {
        this.CombatLogBattles(1);
        if ((double) this.game.Data.RuleVar[407] > 0.0)
          this.PayForLis();
        if ((double) this.game.Data.RuleVar[434] > 0.0)
          this.PayForSimplifiedSupplyRules();
        int ucounter = this.UCounter;
        for (int tunr = 0; tunr <= ucounter; ++tunr)
        {
          this.ReformUnit(tunr);
          if (this.CombatType == 1 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 9 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 10 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 12 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 2 & this.UList[tunr].Uattacker == 0 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].LandscapeType].IsSea)
            this.killairandnavy(tunr);
          if (this.UList[tunr].Uattacker == 0 & this.UList[tunr].UDead == 0 && !(this.CombatType == 3 | this.CombatType == 4 | this.CombatType == 6 | this.CombatType == 5 | this.CombatType == 13) && !(!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea & this.CombatType == 2))
          {
            this.AddDetail("Defending Unit retreats");
            this.DoRetreat(tunr);
          }
          if (this.UList[tunr].Uattacker == 1 & this.CombatType == 1 & !this.game.EditObj.CombatSim && !this.UList[tunr].UpartialAttack | (double) this.game.Data.RuleVar[493] < 1.0)
          {
            this.game.Data.UnitObj[this.UList[tunr].UNr].FreeCombatX = this.TargetX;
            this.game.Data.UnitObj[this.UList[tunr].UNr].FreeCombatY = this.TargetY;
            this.game.Data.UnitObj[this.UList[tunr].UNr].FreeCombatMap = this.TargetMap;
          }
        }
        this.BattleEnded = 1;
        if (!this.game.EditObj.CombatSim && this.CombatType == 1 | this.CombatType == 9 | this.CombatType == 10 | this.CombatType == 12 && this.game.HandyFunctionsObj.IsHostileNotSelf(this.AttackerRegime, this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Regime))
        {
          if (this.UList[0].UNr > -1)
            this.game.HandyFunctionsObj.UnitCausesHexOwnershipChange(this.AttackerRegime, this.CombatTarget.x, this.CombatTarget.y, this.game.Data.UnitObj[this.UList[0].UNr].X, this.game.Data.UnitObj[this.UList[0].UNr].Y);
          this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Regime = !((double) this.game.Data.RuleVar[840] == 1.0 & this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].OrigOwner > -1 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.AttackerRegime, this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].OrigOwner)) ? (this.game.Data.RegimeObj[this.AttackerRegime].UberRegime != -1 ? this.game.Data.RegimeObj[this.AttackerRegime].UberRegime : this.AttackerRegime) : this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].OrigOwner;
          if (this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].CardUponConquest > -1)
          {
            if (this.game.Data.RegimeObj[this.AttackerRegime].AI)
              this.game.ProcessingObj.PlayCard(this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].CardUponConquest);
            else
              this.game.EditObj.DoCardSlot = this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].CardUponConquest;
          }
          if (this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location > -1)
          {
            this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].HQ = -1;
            if ((double) this.game.Data.RuleVar[898] > 0.0)
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].StructuralPts = 0;
            int index = 0;
            do
            {
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Production[index] = -1;
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].ProdPercent[index] = 0;
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].ProdPointRemainder[index] = 0;
              ++index;
            }
            while (index <= 3);
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Type].AutoProd > -1)
            {
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].ProdPercent[0] = 100;
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Production[0] = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location].Type].AutoProd;
              this.game.HandyFunctionsObj.UpgradeProduction(this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location);
            }
            this.game.ProcessingObj.LocationProductionPrognosis();
          }
          if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[471] > 0.0 && this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2 > -1)
          {
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2].Type].isSupplyBase)
            {
              this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2].supplyBaseMode = 1;
              if (this.game.Data.RegimeObj[this.AttackerRegime].AI)
                this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2].supplyBaseMode = 3;
              if (this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2].supplyBaseFixed == 1)
                this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2].supplyBaseFixed = 0;
            }
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2].Type].isSupplySource)
              this.game.Data.RemoveLoc(this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].Location2);
          }
        }
      }
      if (num3 == 0 & num1 == 0)
      {
        this.CombatLogBattles(3);
        if ((double) this.game.Data.RuleVar[407] > 0.0)
          this.PayForLis();
        if ((double) this.game.Data.RuleVar[434] > 0.0)
          this.PayForSimplifiedSupplyRules();
        int ucounter = this.UCounter;
        for (int tunr = 0; tunr <= ucounter; ++tunr)
        {
          this.ReformUnit(tunr);
          if (this.CombatType == 1 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 10 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 12 & this.UList[tunr].Uattacker == 0)
            this.killairandnavy(tunr);
          if (this.CombatType == 2 & this.UList[tunr].Uattacker == 0 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.CombatTarget.map].HexObj[this.CombatTarget.x, this.CombatTarget.y].LandscapeType].IsSea)
            this.killairandnavy(tunr);
          if (this.UList[tunr].UDead == 0 && !(!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea & this.CombatType == 2) && this.UList[tunr].Uattacker == 1 | !(this.CombatType == 3 | this.CombatType == 4 | this.CombatType == 6 | this.CombatType == 5 | this.CombatType == 9 | this.CombatType == 13))
          {
            this.AddDetail("Att or Def Unit retreats due to standoff");
            this.DoRetreat(tunr);
          }
        }
        this.BattleEnded = 3;
      }
      if (this.BattleEnded <= 0 || !this.customCombatObj.HasCustumCalls())
        return;
      CustomCombatCalls customCombatObj1 = this.customCombatObj;
      CombatClass combatClass1 = this;
      ref CombatClass local1 = ref combatClass1;
      GameClass game1 = this.game;
      customCombatObj1.EndCombatCall(ref local1, game1);
    }

    public void CombatLogBattles(int tBattleEnded)
    {
      if ((double) this.game.Data.RuleVar[955] <= 0.0)
        return;
      int num;
      if (tBattleEnded == 1)
        num = this.AttackerRegime;
      if (tBattleEnded == 2)
        num = this.DefenderRegime;
      if (tBattleEnded == 3)
        num = -1;
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[955]));
      if (stringListById == -1)
        return;
      this.game.Data.StringListObj[stringListById].AddRow(this.game.Data.StringListObj[stringListById].Length);
      int length = this.game.Data.StringListObj[stringListById].Length;
      this.game.Data.StringListObj[stringListById].SetItem(length, 0, this.game.Data.CombatLogId.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 1, this.AttackerRegime.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 2, this.TargetX.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 3, this.TargetY.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 4, this.DefenderRegime.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 5, Conversions.ToString(num));
      this.game.Data.StringListObj[stringListById].SetItem(length, 6, this.CombatRound.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 7, this.initialRecon.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 8, this.CombatType.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 9, this.game.Data.Round.ToString());
      this.game.Data.StringListObj[stringListById].SetItem(length, 10, ((int) Math.Round((double) (this.bestConcentricBonus * 100f))).ToString());
    }

    public void SetConcentricBonus()
    {
      Neighbours neighbours = new Neighbours();
      UnitList UL = new UnitList();
      this.ConcentricBonus = 1f;
      if (this.CombatType == 1)
      {
        int ucounter = this.UCounter;
        for (int index = 0; index <= ucounter; ++index)
        {
          if (this.UList[index].Uattacker == 1 & this.UList[index].URetreat == 0)
          {
            int num = this.game.HandyFunctionsObj.HexFacing(this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map, this.game.Data.UnitObj[this.UList[index].UNr].X, this.game.Data.UnitObj[this.UList[index].UNr].Y, this.game.Data.UnitObj[this.UList[index].UNr].Map);
            if (num > 0)
              neighbours.data[num - 1] = 1;
            UL.add(this.UList[index].UNr);
          }
        }
      }
      bool flag1 = false;
      if (this.AttackerRegime > -1)
        flag1 = this.game.Data.RegimeObj[this.AttackerRegime].AI;
      if (Operators.ConditionalCompareObjectGreater(this.game.HandyFunctionsObj.GetHQsInUnitList(ref UL), (object) 1, false))
      {
        HandyFunctionsclass handyFunctionsObj = this.game.HandyFunctionsObj;
        ref Neighbours local1 = ref neighbours;
        bool flag2 = true;
        ref bool local2 = ref flag2;
        int num = flag1 ? 1 : 0;
        this.ConcentricBonus = handyFunctionsObj.GetConcentricBonus(ref local1, ref local2, num != 0);
      }
      else
      {
        HandyFunctionsclass handyFunctionsObj = this.game.HandyFunctionsObj;
        ref Neighbours local3 = ref neighbours;
        bool flag3 = false;
        ref bool local4 = ref flag3;
        int num = flag1 ? 1 : 0;
        this.ConcentricBonus = handyFunctionsObj.GetConcentricBonus(ref local3, ref local4, num != 0);
      }
      if ((double) this.ConcentricBonus <= (double) this.bestConcentricBonus)
        return;
      this.bestConcentricBonus = this.ConcentricBonus;
    }

    public void EndBattle()
    {
      UnitList UL = new UnitList();
      this.game.EditObj.se1_map_data3cache_set = false;
      if (this.customCombatObj.HasCustumCalls())
      {
        CustomCombatCalls customCombatObj = this.customCombatObj;
        CombatClass combatClass = this;
        ref CombatClass local = ref combatClass;
        GameClass game = this.game;
        customCombatObj.EndBattleCall(ref local, game);
      }
      bool flag1 = false;
      if (this.BattleEnded > 0)
      {
        if ((double) this.game.Data.RuleVar[431] < 1.0)
        {
          if (this.game.Data.Product == 6)
          {
            if (!this.allowHistoryOwnRegime)
            {
              if (this.AttackerRegime == this.game.Data.Turn)
                this.FillEditObjHisLoss(this.DefenderRegime);
              else
                this.FillEditObjHisLoss(this.AttackerRegime);
            }
          }
          else
            this.FillEditObjHisLoss();
        }
        this.game.EditObj.HisLossAttReg = this.AttackerRegime;
        this.game.EditObj.HisLossDefReg = this.DefenderRegime;
        if (this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 10 | this.CombatType == 9 | this.CombatType == 12)
        {
          if (this.BattleEnded == 1)
            this.game.EditObj.HisRegimeWon = this.AttackerRegime;
          if (this.BattleEnded == 2)
            this.game.EditObj.HisRegimeWon = this.DefenderRegime;
          if (this.BattleEnded == 3)
            this.game.EditObj.HisRegimeWon = -1;
        }
        else
          this.game.EditObj.HisRegimeWon = -1;
        if ((double) this.game.Data.RuleVar[485] > 0.0 & (this.CombatType == 3 | this.CombatType == 4))
        {
          int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[485]));
          if (stringListById > -1)
          {
            bool[] flagArray = new bool[this.UCounter + 10 + 1];
            this.game.HandyFunctionsObj.ClearFireListRecent();
            int ucounter1 = this.UCounter;
            for (int index1 = 0; index1 <= ucounter1; ++index1)
            {
              if (this.UList[index1].Uattacker == 1 & !flagArray[index1] & this.UList[index1].UNr > -1)
              {
                SimpleList simpleList = new SimpleList();
                bool flag2 = false;
                int ucounter2 = this.UCounter;
                for (int index2 = 0; index2 <= ucounter2; ++index2)
                {
                  if (this.UList[index2].UNr > -1 && this.game.Data.UnitObj[this.UList[index1].UNr].X == this.game.Data.UnitObj[this.UList[index2].UNr].X && this.game.Data.UnitObj[this.UList[index1].UNr].Y == this.game.Data.UnitObj[this.UList[index2].UNr].Y && !flagArray[index2])
                  {
                    int icounter = this.game.TempCombat.ICounter;
                    for (int index3 = 0; index3 <= icounter; ++index3)
                    {
                      if (this.game.TempCombat.IList[index3].IUlistNr == index2)
                      {
                        int attackCount = this.game.TempCombat.IList[index3].AttackCount;
                        if (attackCount > 0)
                        {
                          int reinforcementType = this.game.Data.SFTypeObj[this.game.TempCombat.IList[index3].ISFType].ReinforcementType;
                          if (reinforcementType > -1)
                            simpleList.AddWeight(reinforcementType, attackCount);
                          if (this.IList[index3].IvisibleFromRound <= this.CombatRound)
                            flag2 = true;
                        }
                      }
                    }
                    flagArray[index2] = true;
                  }
                }
                if (simpleList.Counter > -1)
                {
                  simpleList.ReverseSortHighSpeed();
                  string str1 = this.game.Data.ReinfName[simpleList.Id[0]];
                  string str2 = simpleList.Counter != 0 ? str1 : str1;
                  this.game.Data.StringListObj[stringListById].AddRowWithData(this.AttackerRegime.ToString(), this.TargetX.ToString(), this.TargetY.ToString(), "2", this.AttackerRegime.ToString(), this.DefenderRegime.ToString(), "1", this.game.Data.Round.ToString(), this.game.Data.Turn.ToString(), str2 + " fire from " + this.game.Data.UnitObj[this.UList[index1].UNr].X.ToString() + "," + this.game.Data.UnitObj[this.UList[index1].UNr].Y.ToString());
                  this.game.Data.StringListObj[stringListById].AddRowWithData(this.AttackerRegime.ToString(), this.game.Data.UnitObj[this.UList[index1].UNr].X.ToString(), this.game.Data.UnitObj[this.UList[index1].UNr].Y.ToString(), "1", this.AttackerRegime.ToString(), this.DefenderRegime.ToString(), "1", this.game.Data.Round.ToString(), this.game.Data.Turn.ToString(), str2 + " fire on " + this.TargetX.ToString() + "," + this.TargetY.ToString());
                  if (flag2)
                  {
                    this.game.Data.StringListObj[stringListById].AddRowWithData(this.DefenderRegime.ToString(), this.TargetX.ToString(), this.TargetY.ToString(), "2", this.AttackerRegime.ToString(), this.DefenderRegime.ToString(), "1", this.game.Data.Round.ToString(), this.game.Data.Turn.ToString(), str2 + " fire from " + this.game.Data.UnitObj[this.UList[index1].UNr].X.ToString() + "," + this.game.Data.UnitObj[this.UList[index1].UNr].Y.ToString());
                    this.game.Data.StringListObj[stringListById].AddRowWithData(this.DefenderRegime.ToString(), this.game.Data.UnitObj[this.UList[index1].UNr].X.ToString(), this.game.Data.UnitObj[this.UList[index1].UNr].Y.ToString(), "1", this.AttackerRegime.ToString(), this.DefenderRegime.ToString(), "1", this.game.Data.Round.ToString(), this.game.Data.Turn.ToString(), str2 + " fire on " + this.TargetX.ToString() + "," + this.TargetY.ToString());
                  }
                  else
                    this.game.Data.StringListObj[stringListById].AddRowWithData(this.DefenderRegime.ToString(), this.TargetX.ToString(), this.TargetY.ToString(), "2", this.AttackerRegime.ToString(), this.DefenderRegime.ToString(), "1", this.game.Data.Round.ToString(), this.game.Data.Turn.ToString(), str2 + " fire from unknown hex");
                }
              }
            }
            this.game.HandyFunctionsObj.ResetFireListCache();
          }
        }
        int ucounter3 = this.UCounter;
        for (int index4 = 0; index4 <= ucounter3; ++index4)
        {
          int unr = this.UList[index4].UNr;
          UnitClass[] unitObj1 = this.game.Data.UnitObj;
          UnitClass[] unitClassArray1 = unitObj1;
          int index5 = unr;
          int index6 = index5;
          unitClassArray1[index6].uncertaintyRolls = unitObj1[index5].uncertaintyRolls + this.UList[index4].UDice;
          UnitClass[] unitObj2 = this.game.Data.UnitObj;
          UnitClass[] unitClassArray2 = unitObj2;
          int index7 = unr;
          int index8 = index7;
          unitClassArray2[index8].uncertaintyRollsCount = unitObj2[index7].uncertaintyRollsCount + 1;
        }
        int ucounter4 = this.UCounter;
        for (int index = 0; index <= ucounter4; ++index)
        {
          if (this.UList[index].UDead == 0)
          {
            int unr = this.UList[index].UNr;
            for (int sfCount = this.game.Data.UnitObj[unr].SFCount; sfCount >= 0; sfCount += -1)
            {
              int sf = this.game.Data.UnitObj[unr].SFList[sfCount];
              if (this.game.Data.SFObj[sf].Qty < 1)
                this.game.Data.UnitObj[unr].RemoveSF(sf);
            }
          }
        }
        int ucounter5 = this.UCounter;
        for (int index = 0; index <= ucounter5; ++index)
        {
          if (this.UList[index].UDead == 0 & this.UList[index].Uattacker == 0)
            this.game.HandyFunctionsObj.SetOnlyZOCAround(this.game.Data.UnitObj[this.UList[index].UNr].X, this.game.Data.UnitObj[this.UList[index].UNr].Y, this.game.Data.UnitObj[this.UList[index].UNr].Map, this.game.Data.UnitObj[this.UList[index].UNr].Regime, this.UList[index].UNr);
        }
        int ucounter6 = this.UCounter;
        for (int index = 0; index <= ucounter6; ++index)
        {
          if (this.UList[index].UDead == 0 & this.UList[index].Uattacker == 1)
          {
            if (!(this.CombatType == 9 & !this.UList[index].UParadropper) & this.CombatType != 13 & this.CombatType != 5 & this.CombatType != 6)
              this.game.HandyFunctionsObj.SetOnlyZOCAround(this.game.Data.UnitObj[this.UList[index].UNr].X, this.game.Data.UnitObj[this.UList[index].UNr].Y, this.game.Data.UnitObj[this.UList[index].UNr].Map, this.AttackerRegime, this.UList[index].UNr);
            if (this.CombatType == 9 & this.UList[index].UParadropper | this.CombatType == 10 | this.CombatType == 12)
              this.game.HandyFunctionsObj.SetOnlyReconAround(this.game.Data.UnitObj[this.UList[index].UNr].X, this.game.Data.UnitObj[this.UList[index].UNr].Y, this.game.Data.UnitObj[this.UList[index].UNr].Map, this.game.Data.UnitObj[this.UList[index].UNr].Regime, this.UList[index].UNr);
          }
        }
        int ucounter7 = this.UCounter;
        for (int index = 0; index <= ucounter7; ++index)
        {
          if (this.UList[index].UDead == 0)
          {
            this.UList[index].UDead = this.game.HandyFunctionsObj.CheckCargoLoss(this.UList[index].UNr, ref UL, this.AttackerRegime, this.DefenderRegime);
          }
          else
          {
            this.UList[index].UDead = this.game.HandyFunctionsObj.CheckCargoLoss(this.UList[index].UNr, ref UL, this.AttackerRegime, this.DefenderRegime);
            this.UList[index].UDead = 1;
          }
        }
        if (this.game.Data.Turn == this.AttackerRegime)
        {
          int index9 = -1;
          int ucounter8 = this.UCounter;
          for (int index10 = 0; index10 <= ucounter8; ++index10)
          {
            if (this.UList[index10].Uattacker == 1 & this.UList[index10].UDead == 0)
            {
              index9 = this.UList[index10].UNr;
              this.game.SelectX = this.game.Data.UnitObj[index9].X;
              this.game.SelectY = this.game.Data.UnitObj[index9].Y;
              this.game.EditObj.MapSelected = this.game.Data.UnitObj[index9].Map;
            }
          }
          int ucounter9 = this.UCounter;
          for (int index11 = 0; index11 <= ucounter9; ++index11)
          {
            if (this.UList[index11].Uattacker == 1 & this.UList[index11].UDead == 0 & this.UList[index11].URetreat == 0)
            {
              index9 = this.UList[index11].UNr;
              this.game.SelectX = this.game.Data.UnitObj[index9].X;
              this.game.SelectY = this.game.Data.UnitObj[index9].Y;
              this.game.EditObj.MapSelected = this.game.Data.UnitObj[index9].Map;
            }
          }
          if (index9 > -1)
          {
            int num = 0;
            this.game.EditObj.UnitSelected = index9;
            while (index9 != this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, 1))
            {
              ++num;
              if (num > 20)
                break;
            }
          }
        }
        this.game.HandyFunctionsObj.CheckAttachTransportValidity();
        if (this.game.Data.Product == 6)
        {
          int ucounter10 = this.UCounter;
          for (int index = 0; index <= ucounter10; ++index)
          {
            int unr = this.UList[index].UNr;
            if (this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn)
            {
              Coordinate reconMinusHide;
              if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | !this.game.Data.FOWOn | this.game.Data.Round == 0)
                reconMinusHide.x = 3;
              else
                reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unr, this.game.Data.Turn);
              if (this.UList[index].UVisibility.x < 1 & reconMinusHide.x > 0)
                flag1 = true;
              else if (this.UList[index].UVisibility.x > 0 & reconMinusHide.x < 1)
                flag1 = true;
              else if (this.CombatType == 11)
                flag1 = true;
              else if (this.UList[index].URetreated > 0)
                flag1 = true;
            }
          }
        }
        if (this.CombatType == 11)
        {
          int ucounter11 = this.UCounter;
          for (int index = 0; index <= ucounter11; ++index)
          {
            if (this.UList[index].Uattacker == 0 & this.UList[index].UDead == 0)
              this.game.Data.UnitObj[this.UList[index].UNr].Spotted = true;
          }
        }
        int ucounter12 = this.UCounter;
        for (int index = 0; index <= ucounter12; ++index)
        {
          if (this.UList[index].Uattacker == 0 && this.UList[index].USetToSpottedAtEnd)
            this.game.Data.UnitObj[this.UList[index].UNr].Spotted = true;
          if (this.UList[index].Uattacker == 0)
            this.game.ProcessingObj.SpottedAndIdentifiedUpdate(this.AttackerRegime, this.UList[index].UNr, true);
          else if (this.UList[index].Uattacker != 1)
            ;
        }
        for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
        {
          if (this.game.Data.UnitObj[unitCounter].PassengerCounter > -1)
          {
            for (int passengerCounter = this.game.Data.UnitObj[unitCounter].PassengerCounter; passengerCounter >= 0; passengerCounter += -1)
            {
              if (UL.CheckIfPresent(this.game.Data.UnitObj[unitCounter].PassengerList[passengerCounter]))
                this.game.Data.UnitObj[unitCounter].RemovePassenger(this.game.Data.UnitObj[unitCounter].PassengerList[passengerCounter]);
            }
          }
        }
        for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
        {
          if (UL.CheckIfPresent(unitCounter))
          {
            this.KillUnit(unitCounter);
            flag1 = true;
          }
          else if (unitCounter == this.game.EditObj.OrderTarget & this.CombatType == 15)
          {
            if ((double) this.game.EditObj.PassengerDammage > 0.0)
              this.game.HandyFunctionsObj.DoLoseCargo(this.game.EditObj.OrderTarget, this.game.EditObj.PassengerDammage, this.AttackerRegime, this.DefenderRegime);
            if (this.game.Data.UnitObj[this.game.EditObj.OrderTarget].SFCount == -1)
            {
              if (this.customCombatObj.HasCustumCalls())
              {
                CustomCombatCalls customCombatObj = this.customCombatObj;
                CombatClass combatClass = this;
                ref CombatClass local = ref combatClass;
                GameClass game = this.game;
                int orderTarget = this.game.EditObj.OrderTarget;
                customCombatObj.UnitLost(ref local, game, orderTarget);
              }
              this.game.Data.RemoveUnit(this.game.EditObj.OrderTarget, ref this.game);
            }
            else
            {
              this.game.Data.MapObj[this.game.EditObj.OrderMap].HexObj[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y].RemoveUnitFromList(this.game.EditObj.OrderTarget);
              this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].AddUnitToList(this.game.EditObj.OrderTarget);
              this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X = this.game.EditObj.TargetX;
              this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y = this.game.EditObj.TargetY;
              this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map = this.game.EditObj.TargetMap;
              int sfCount1 = this.game.Data.UnitObj[this.game.EditObj.OrderTarget].SFCount;
              for (int index = 0; index <= sfCount1; ++index)
              {
                int sf = this.game.Data.UnitObj[this.game.EditObj.OrderTarget].SFList[index];
                this.game.Data.SFObj[sf].Ap = 0;
                this.game.Data.SFObj[sf].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup);
                this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
                this.game.Data.SFObj[sf].EP = 0;
              }
              this.game.Data.MapObj[this.game.EditObj.OrderMap].HexObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y].RemoveUnitFromList(this.game.EditObj.OrderUnit);
              this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].AddUnitToList(this.game.EditObj.OrderUnit);
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X = this.game.EditObj.TargetX;
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y = this.game.EditObj.TargetY;
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map = this.game.EditObj.TargetMap;
              int sfCount2 = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].SFCount;
              for (int index = 0; index <= sfCount2; ++index)
              {
                int sf = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].SFList[index];
                this.game.Data.SFObj[sf].Ap = 0;
                this.game.Data.SFObj[sf].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup);
                this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
                this.game.Data.SFObj[sf].EP = 0;
              }
            }
          }
          else
          {
            int ucounter13 = this.UCounter;
            for (int index = 0; index <= ucounter13; ++index)
            {
              if (this.UList[index].UDead == 1 & this.UList[index].UNr == unitCounter)
              {
                this.KillUnit(unitCounter);
                flag1 = true;
              }
            }
          }
        }
        if (this.CombatType == 11 && (double) this.game.Data.RuleVar[431] < 1.0)
        {
          this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].MaxRecon = 999;
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int index = 0; index <= regimeCounter; ++index)
          {
            if (index != this.game.Data.Turn && this.game.HandyFunctionsObj.IsAlliedOrSelf(index, this.game.Data.Turn, true))
              this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].set_ReconPts(index, 999);
          }
        }
        if (!(this.CombatType == 3 | this.CombatType == 4 | this.CombatType == 13) && (double) this.game.Data.RuleVar[431] < 1.0)
        {
          int num = this.CombatRound;
          if (num > 10)
            num = 10;
          HexClass[,] hexObj = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj;
          HexClass[,] hexClassArray = hexObj;
          int targetX = this.TargetX;
          int index12 = targetX;
          int targetY = this.TargetY;
          int index13 = targetY;
          hexClassArray[index12, index13].MaxRecon = (int) Math.Round((double) hexObj[targetX, targetY].MaxRecon + Conversion.Int((double) this.game.Data.RuleVar[56] * ((double) num / 10.0)));
          this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].set_SeeNow(this.AttackerRegime, 1);
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int index14 = 0; index14 <= regimeCounter; ++index14)
          {
            if (index14 != this.game.Data.Turn && this.game.HandyFunctionsObj.IsAlliedOrSelf(index14, this.game.Data.Turn, true) && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].MaxRecon > this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].get_ReconPts(index14))
              this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].set_ReconPts(index14, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].MaxRecon);
          }
        }
        if ((double) this.game.Data.RuleVar[431] < 1.0)
        {
          if (!this.game.EditObj.CombatSim)
          {
            if (this.CombatType == 12 | this.InterceptFire | this.CombatType2 == 16)
              this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[0].x, this.HexList.coord[0].y, this.HexList.coord[0].map, -1, 4, infostring: this.game.EditObj.CombatOneSentence, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
            else
              this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[0].x, this.HexList.coord[0].y, this.HexList.coord[0].map, this.AttackerRegime, 4, infostring: this.game.EditObj.CombatOneSentence, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
            this.game.EditObj.HisLossCounter = -1;
          }
          if (!this.game.EditObj.CombatSim && this.HexList.counter > -1)
          {
            ++this.game.Data.StepNr;
            int counter = this.HexList.counter;
            for (int index = 0; index <= counter; ++index)
            {
              if (this.CombatType == 12 | this.InterceptFire | this.CombatType2 == 16)
                this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[index].x, this.HexList.coord[index].y, this.HexList.coord[index].map, -1, 4, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
              else if (this.CombatType2 == 16)
                this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[index].x, this.HexList.coord[index].y, this.HexList.coord[index].map, -1, 4, attacktype: 55, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
              else
                this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[index].x, this.HexList.coord[index].y, this.HexList.coord[index].map, this.AttackerRegime, 4, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
            }
          }
        }
        else
        {
          if (!this.game.EditObj.CombatSim & this.game.Data.Product != 6 && this.HexList.counter > -1)
            ++this.game.Data.StepNr;
          int num1 = 1;
          do
          {
            int onlyForReg = -1;
            if (num1 == 1)
            {
              this.FillEditObjHisLoss(this.AttackerRegime);
              onlyForReg = this.AttackerRegime;
            }
            if (num1 == 2)
            {
              this.FillEditObjHisLoss(this.DefenderRegime);
              onlyForReg = this.DefenderRegime;
            }
            this.game.EditObj.HisLossAttReg = this.AttackerRegime;
            this.game.EditObj.HisLossDefReg = this.DefenderRegime;
            if (this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 10 | this.CombatType == 9 | this.CombatType == 12)
            {
              if (this.BattleEnded == 1)
                this.game.EditObj.HisRegimeWon = this.AttackerRegime;
              if (this.BattleEnded == 2)
                this.game.EditObj.HisRegimeWon = this.DefenderRegime;
              if (this.BattleEnded == 3)
                this.game.EditObj.HisRegimeWon = -1;
            }
            else
              this.game.EditObj.HisRegimeWon = -1;
            if (!(num1 == 1 & this.AttackerRegime == this.game.Data.Turn & this.InterceptFire) & !(num1 == 2 & this.DefenderRegime == this.game.Data.Turn & this.InterceptFire) && !this.game.EditObj.CombatSim)
            {
              if (this.CombatType == 12 | this.InterceptFire)
                this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[0].x, this.HexList.coord[0].y, this.HexList.coord[0].map, -1, 4, infostring: this.game.EditObj.CombatOneSentence, onlyForReg: onlyForReg, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
              else if (this.CombatType2 == 16)
                this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[0].x, this.HexList.coord[0].y, this.HexList.coord[0].map, -1, 4, attacktype: 55, infostring: this.game.EditObj.CombatOneSentence, onlyForReg: onlyForReg, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
              else
                this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[0].x, this.HexList.coord[0].y, this.HexList.coord[0].map, this.AttackerRegime, 4, infostring: this.game.EditObj.CombatOneSentence, onlyForReg: onlyForReg, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
              this.game.EditObj.HisLossCounter = -1;
            }
            ++num1;
          }
          while (num1 <= 2);
          int num2 = 1;
          do
          {
            int onlyForReg = -1;
            this.game.EditObj.HisLossCounter = -1;
            if (num2 == 1)
              onlyForReg = this.AttackerRegime;
            if (num2 == 2)
              onlyForReg = this.DefenderRegime;
            if (!(num2 == 1 & this.AttackerRegime == this.game.Data.Turn & this.InterceptFire) & !(num2 == 2 & this.DefenderRegime == this.game.Data.Turn & this.InterceptFire) && !this.game.EditObj.CombatSim && this.HexList.counter > -1)
            {
              int counter = this.HexList.counter;
              for (int index = 0; index <= counter; ++index)
              {
                if (this.CombatType == 12 | this.InterceptFire)
                  this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[index].x, this.HexList.coord[index].y, this.HexList.coord[index].map, -1, 4, onlyForReg: onlyForReg, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
                else if (this.CombatType == 16)
                  this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[index].x, this.HexList.coord[index].y, this.HexList.coord[index].map, -1, 4, attacktype: 55, onlyForReg: onlyForReg, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
                else
                  this.game.HandyFunctionsObj.HistoryAddHex(this.HexList.coord[index].x, this.HexList.coord[index].y, this.HexList.coord[index].map, this.AttackerRegime, 4, onlyForReg: onlyForReg, allowAddedForCurrentTurn: this.allowHistoryOwnRegime);
              }
            }
            ++num2;
          }
          while (num2 <= 2);
        }
        if ((double) this.game.Data.RuleVar[428] > 0.0)
        {
          this.game.EditObj.tempDidInterceptList = new CoordList();
          if (this.InterceptFire)
          {
            int counter = this.HexList.counter;
            for (int index = 0; index <= counter; ++index)
            {
              if (this.game.Data.MapObj[0].HexObj[this.HexList.coord[index].x, this.HexList.coord[index].y].Regime == this.AttackerRegime && this.game.Data.MapObj[0].HexObj[this.HexList.coord[index].x, this.HexList.coord[index].y].get_ReconPts(this.DefenderRegime) > 0)
                this.game.EditObj.tempDidInterceptList.AddCoord(this.HexList.coord[index].x, this.HexList.coord[index].y, 0);
            }
          }
        }
      }
      int mapCounter = this.game.Data.MapCounter;
      for (int map = 0; map <= mapCounter; ++map)
      {
        int mapWidth = this.game.Data.MapObj[map].MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.game.Data.MapObj[map].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
            this.game.HandyFunctionsObj.DoZOCConquest(x, y, map, this.AttackerRegime);
        }
      }
      int icounter1 = this.ICounter;
      bool flag3;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IAttacker == 0 && this.IList[index].ISFType > -1 && this.game.Data.SFTypeObj[this.IList[index].ISFType].AntiSupply > 0 | this.game.Data.SFTypeObj[this.IList[index].ISFType].AntiSupplySea > 0)
          flag3 = true;
      }
      if (flag3)
        this.game.HandyFunctionsObj.DoAntiInfraDammage(true);
      int regimeCounter1 = this.game.Data.RegimeCounter;
      for (int reg2 = 0; reg2 <= regimeCounter1; ++reg2)
      {
        if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.AttackerRegime, reg2) && (double) this.game.Data.RuleVar[859] != 1.0 & !this.game.EditObj.CombatSim)
        {
          HexClass[,] hexObj1 = this.game.Data.MapObj[this.CombatTarget.map].HexObj;
          HexClass[,] hexClassArray1 = hexObj1;
          int x1 = this.CombatTarget.x;
          int index15 = x1;
          int y1 = this.CombatTarget.y;
          int index16 = y1;
          HexClass hexClass1 = hexClassArray1[index15, index16];
          int Index1 = reg2;
          int Index2 = Index1;
          int num3 = hexObj1[x1, y1].get_BattleStack(Index1) + this.NewBattleStack;
          hexClass1.set_BattleStack(Index2, num3);
          HexClass[,] hexObj2 = this.game.Data.MapObj[this.CombatTarget.map].HexObj;
          HexClass[,] hexClassArray2 = hexObj2;
          int x2 = this.CombatTarget.x;
          int index17 = x2;
          int y2 = this.CombatTarget.y;
          int index18 = y2;
          HexClass hexClass2 = hexClassArray2[index17, index18];
          int Index3 = reg2;
          int Index4 = Index3;
          int num4 = hexObj2[x2, y2].get_BattleStackArt(Index3) + this.NewBattleStackArt;
          hexClass2.set_BattleStackArt(Index4, num4);
          HexClass[,] hexObj3 = this.game.Data.MapObj[this.CombatTarget.map].HexObj;
          HexClass[,] hexClassArray3 = hexObj3;
          int x3 = this.CombatTarget.x;
          int index19 = x3;
          int y3 = this.CombatTarget.y;
          int index20 = y3;
          HexClass hexClass3 = hexClassArray3[index19, index20];
          int Index5 = reg2;
          int Index6 = Index5;
          int num5 = hexObj3[x3, y3].get_BattleStackAir(Index5) + this.NewBattleStackAir;
          hexClass3.set_BattleStackAir(Index6, num5);
        }
      }
      if ((double) this.game.Data.RuleVar[843] > 0.0 & !this.game.EditObj.CombatSim)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      this.game.EditObj.attackTypeOption = 0;
      this.game.EditObj.TempCoordListLastMove = new CoordList();
      if (flag1 && this.game.Data.Product == 6 && (double) this.game.Data.RuleVar[455] > 0.0)
        this.game.HandyFunctionsObj.MakeFuzzyOwner(false, true, this.game.Data.Turn);
      this.WriteToFileLog();
    }

    public void ReformUnit(int tunr)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      if (this.game.EditObj.CombatSim)
        return;
      int unr = this.UList[tunr].UNr;
      int index1 = -1;
      int length;
      int index2;
      if ((double) this.game.Data.RuleVar[956] > 0.0)
      {
        index1 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[956]));
        if (index1 > -1)
        {
          this.game.Data.StringListObj[index1].AddRow(this.game.Data.StringListObj[index1].Length);
          length = this.game.Data.StringListObj[index1].Length;
          this.game.Data.StringListObj[index1].SetItem(length, 0, this.game.Data.CombatLogId.ToString());
          if (this.game.Data.UnitObj[unr].Historical > -1)
            this.game.Data.StringListObj[index1].SetItem(length, 1, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].ID.ToString());
          else
            this.game.Data.StringListObj[index1].SetItem(length, 1, Conversions.ToString(-Conversions.ToDouble(1.ToString())));
          this.game.Data.StringListObj[index1].SetItem(length, 2, this.game.Data.UnitObj[unr].HistoricalSubPart.ToString());
          this.game.Data.StringListObj[index1].SetItem(length, 3, this.game.Data.UnitObj[unr].Regime.ToString());
          this.game.Data.StringListObj[index1].SetItem(length, 4, this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr).ToString());
          this.game.Data.StringListObj[index1].SetItem(length, 5, this.game.HandyFunctionsObj.GetAverageRdn(unr).ToString());
          StringListClass stringListClass = this.game.Data.StringListObj[index1];
          int row = length;
          index2 = this.game.HandyFunctionsObj.GetAverageEntrench(unr);
          string s = index2.ToString();
          stringListClass.SetItem(row, 9, s);
          int num6 = -1;
          if (this.UList[tunr].Uattacker == 1)
            num6 += this.game.HandyFunctionsObj.HexFacing(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.CombatTarget.x, this.CombatTarget.y, this.CombatTarget.map);
          this.game.Data.StringListObj[index1].SetItem(length, 10, num6.ToString());
        }
      }
      if (this.UList[tunr].Uattacker == 1)
      {
        UnitClass[] unitObj = this.game.Data.UnitObj;
        UnitClass[] unitClassArray = unitObj;
        index2 = unr;
        int index3 = index2;
        unitClassArray[index3].offensiveCombat = unitObj[index2].offensiveCombat + this.UList[tunr].UApSpend;
      }
      else
      {
        UnitClass[] unitObj = this.game.Data.UnitObj;
        UnitClass[] unitClassArray = unitObj;
        index2 = unr;
        int index4 = index2;
        unitClassArray[index4].defensiveCombat = unitObj[index2].defensiveCombat + this.UList[tunr].UApSpend;
      }
      int num7 = 0;
      int num8 = 0;
      int num9 = 0;
      int num10 = 0;
      int averageRdn1 = this.game.HandyFunctionsObj.GetAverageRdn(unr);
      int num11 = 0;
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      for (int index5 = 0; index5 <= sfCount1; ++index5)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index5];
        int num12 = 0;
        int num13 = 0;
        int num14 = 0;
        int num15 = 0;
        int num16 = 0;
        int num17 = 0;
        int num18 = 0;
        int num19 = 0;
        int num20 = 0;
        int icounter = this.ICounter;
        for (int inr = 0; inr <= icounter; ++inr)
        {
          if (this.IList[inr].IUnr == unr & this.IList[inr].ISFNr == sf)
          {
            num20 = 1;
            ++num3;
            num2 += this.IList[inr].ItotalKillsPowerPoints;
            num4 += this.IList[inr].ItotalKills;
            num11 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].PowerPts;
            if (this.IList[inr].IKilled == 0)
            {
              if (this.IList[inr].IAttacker == 1)
                this.IList[inr].IEntrench = !(this.game.Data.SFTypeObj[this.IList[inr].ISFType].ArtRange < 1 | !(this.CombatType == 3 | this.CombatType == 4)) ? this.game.Data.SFObj[this.IList[inr].ISFNr].CurrentEntrench : this.game.HandyFunctionsObj.GetMinimumEntrench(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.SFTypeObj[this.IList[inr].ISFType].UnitGroup);
              int num21 = this.CombatRound;
              if (num21 > 4)
                num21 = 4;
              if (num21 < 2)
                num21 = 2;
              int percent = num21 * 5;
              if (this.IList[inr].IAttacker == 1 & this.IList[inr].IRetreated == 0)
                this.AddMor(inr, percent);
              ++num14;
              num12 += this.IList[inr].IXp;
              num13 += this.IList[inr].IRdn;
              num17 += this.IList[inr].IMor;
              num19 += this.IList[inr].IEntrench;
              num9 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].SupplyCarry;
              num8 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].SupplyCarry;
              num16 = (int) Math.Round((double) num16 + (double) this.game.Data.SFObj[this.IList[inr].ISFNr].EP / (double) this.game.Data.SFObj[this.IList[inr].ISFNr].Qty);
              num15 = (int) Math.Round((double) num15 + (double) this.game.Data.SFObj[this.IList[inr].ISFNr].EP / (double) this.game.Data.SFObj[this.IList[inr].ISFNr].Qty);
              num10 += this.IList[inr].IDammageDone;
            }
            if (this.IList[inr].IKilled > 0)
            {
              num1 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].PowerPts;
              ++num5;
              ++num18;
              num8 += this.game.Data.SFTypeObj[this.IList[inr].ISFType].SupplyCarry;
              if (this.game.Data.SFObj[this.IList[inr].ISFNr].Qty > 0)
                num16 = (int) Math.Round((double) num16 + (double) this.game.Data.SFObj[this.IList[inr].ISFNr].EP / (double) this.game.Data.SFObj[this.IList[inr].ISFNr].Qty);
              int isfType = this.IList[inr].ISFType;
              int index6;
              int index7;
              if (this.IList[inr].IAttacker == 1)
              {
                index6 = this.AttackerRegime;
                index7 = this.DefenderRegime;
              }
              else
              {
                index6 = this.DefenderRegime;
                index7 = this.AttackerRegime;
              }
              if ((double) this.game.Data.RuleVar[841] == 0.0 & index7 < this.AttackerRegime)
              {
                if (index7 > -1)
                {
                  int[,] skills = this.game.Data.RegimeObj[index7].SKills;
                  int[,] numArray = skills;
                  index2 = isfType;
                  int index8 = index2;
                  int index9 = this.game.Data.Round + 1;
                  int index10 = index9;
                  int num22 = skills[index2, index9] + 1;
                  numArray[index8, index10] = num22;
                }
              }
              else if (index7 > -1)
              {
                int[,] skills = this.game.Data.RegimeObj[index7].SKills;
                int[,] numArray = skills;
                int index11 = isfType;
                int index12 = index11;
                index2 = this.game.Data.Round;
                int index13 = index2;
                int num23 = skills[index11, index2] + 1;
                numArray[index12, index13] = num23;
              }
              if ((double) this.game.Data.RuleVar[841] == 0.0 & index6 < this.AttackerRegime)
              {
                int[,] sloss = this.game.Data.RegimeObj[index6].SLoss;
                int[,] numArray = sloss;
                int index14 = isfType;
                int index15 = index14;
                index2 = this.game.Data.Round + 1;
                int index16 = index2;
                int num24 = sloss[index14, index2] + 1;
                numArray[index15, index16] = num24;
              }
              else
              {
                int[,] sloss = this.game.Data.RegimeObj[index6].SLoss;
                int[,] numArray = sloss;
                int index17 = isfType;
                int index18 = index17;
                index2 = this.game.Data.Round;
                int index19 = index2;
                int num25 = sloss[index17, index2] + 1;
                numArray[index18, index19] = num25;
              }
              if (index6 == this.AttackerRegime)
              {
                int[,] sloss = this.game.Data.RegimeObj[index6].SLoss;
                int[,] numArray = sloss;
                int index20 = isfType;
                int index21 = index20;
                index2 = 0;
                int index22 = index2;
                int num26 = sloss[index20, index2] + 1;
                numArray[index21, index22] = num26;
              }
              if (index7 == this.AttackerRegime)
              {
                int[,] skills = this.game.Data.RegimeObj[index7].SKills;
                int[,] numArray = skills;
                int index23 = isfType;
                int index24 = index23;
                index2 = 0;
                int index25 = index2;
                int num27 = skills[index23, index2] + 1;
                numArray[index24, index25] = num27;
              }
            }
          }
        }
        if (num14 > 0)
        {
          int num28 = (int) Math.Round(Conversion.Int((double) num13 / (double) num14));
          int num29 = (int) Math.Round(Conversion.Int((double) num12 / (double) num14));
          int num30 = (int) Math.Round(Conversion.Int((double) num17 / (double) num14));
          int num31 = (int) Math.Round(Conversion.Int((double) num19 / (double) num14));
          int num32;
          if (this.UList[tunr].Uattacker == 1)
          {
            if (this.UList[tunr].UApSpend < this.UList[tunr].UApMoveCost)
              this.UList[tunr].UApSpend = this.UList[tunr].UApMoveCost;
            float Number;
            if (this.InterceptFire)
            {
              num32 = this.game.Data.SFObj[sf].Ap - this.UList[tunr].UApSpend * 2;
              Number = (double) this.game.Data.RuleVar[436] <= 0.0 ? (float) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ReadinessLoss * ((float) this.UList[tunr].UApMoveCost / 100f) : (float) ((double) this.game.Data.RuleVar[436] * (double) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ReadinessLoss * ((double) this.UList[tunr].UApMoveCost / 100.0));
            }
            else
            {
              num32 = this.game.Data.SFObj[sf].Ap - this.UList[tunr].UApSpend;
              Number = (float) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ReadinessLoss * ((float) this.UList[tunr].UApMoveCost / 100f);
            }
            int num33 = (int) Math.Round((double) Conversion.Int(Number));
            float num34 = Number - (float) num33;
            if ((double) num34 > 0.0 && (double) VBMath.Rnd() < (double) num34)
              ++num33;
            if (this.AttackerRegime > -1 && this.game.Data.RegimeObj[this.AttackerRegime].AI)
            {
              if ((double) this.game.Data.RuleVar[995] == 1.0)
                num33 = 0;
              else if ((double) this.game.Data.RuleVar[995] == 1.0)
                num33 = (int) Math.Round((double) num33 / 2.0);
            }
            num28 -= num33;
          }
          else
            num32 = !this.InterceptFire ? this.game.Data.SFObj[sf].Ap - this.UList[tunr].UApSpend : this.game.Data.SFObj[sf].Ap;
          if (0 > num32)
            num32 = 0;
          if ((double) this.game.Data.RuleVar[60] > (double) num28)
            num28 = (int) Math.Round((double) this.game.Data.RuleVar[60]);
          if (this.UList[tunr].Uattacker == 1 && this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].EndCombatRound > 0 & this.CombatType == 3)
            num32 = 0;
          this.game.Data.SFObj[sf].Qty = num14;
          this.game.Data.SFObj[sf].Rdn = num28;
          if (this.CombatType2 != 16)
            this.game.Data.SFObj[sf].Ap = num32;
          this.game.Data.SFObj[sf].Xp = num29;
          this.game.Data.SFObj[sf].Mor = num30;
          this.game.Data.SFObj[sf].CurrentEntrench = num31;
          if (this.UList[tunr].Uattacker == 1 & this.game.Data.Product >= 6 && !(this.CombatType == 3 | this.CombatType == 4))
            this.game.Data.SFObj[sf].initialEntrench = num31;
          if (num16 > 0)
            this.game.Data.SFObj[sf].EP = num15;
          ++num7;
        }
        else if (num18 > 0)
          this.game.Data.SFObj[sf].Qty = 0;
        if (num20 == 0)
        {
          num9 += this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].SupplyCarry * this.game.Data.SFObj[sf].Qty;
          num8 += this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].SupplyCarry * this.game.Data.SFObj[sf].Qty;
        }
      }
      if (this.game.Data.Product >= 6 && 3 == this.CombatType && this.UList[tunr].Uattacker == 0)
      {
        int averageRdn2 = this.game.HandyFunctionsObj.GetAverageRdn(unr);
        int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
        for (int index26 = 0; index26 <= sfCount2; ++index26)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index26];
          int num35 = averageRdn1 - averageRdn2;
          if (num35 > 0)
          {
            this.game.Data.SFObj[sf].Ap -= num35 * 4;
            if (this.game.Data.SFObj[sf].Ap < 0)
              this.game.Data.SFObj[sf].Ap = 0;
          }
        }
      }
      if (this.game.Data.Product != 7 & (double) this.game.Data.RuleVar[497] > 0.0 & num3 > 0)
      {
        float num36 = num2 <= 0 ? 4f : (float) num1 / (float) num2;
        int num37 = (double) num36 > 0.25 ? ((double) num36 > 0.33 ? ((double) num36 > 0.5 ? ((double) num36 > 0.66 ? ((double) num36 >= 1.5 ? ((double) num36 >= 2.0 ? ((double) num36 >= 3.0 ? ((double) num36 >= 4.0 ? 4 : 3) : 2) : 1) : 0) : 1) : 2) : 3) : 4;
        int num38 = 0;
        int num39 = num37;
        for (int index27 = 1; index27 <= num39; ++index27)
          num38 += DrawMod.RandyNumber.Next(1, (int) Math.Round((double) this.game.Data.RuleVar[497]) + 1);
        int num40 = 0;
        if (num3 > 0)
          num40 = (double) num36 >= 1.0 ? (int) Math.Round((double) (100 * num5) / (double) num3) : (int) Math.Round((double) (100 * num4) / (double) num3);
        if (num38 > num40)
          num38 = num40;
        if ((double) num36 > 1.0)
        {
          int averageMor = this.game.HandyFunctionsObj.GetAverageMor(unr);
          if (DrawMod.RandyNumber.Next(1, 101) <= averageMor)
            num38 = (int) Math.Round((double) num38 / 2.0);
        }
        if ((double) num36 >= 1.0)
          num38 = -num38;
        if (this.CombatType == 3 | this.InterceptFire | this.UList[tunr].USupportInterceptFire)
          num38 = (int) Math.Round((double) num38 / 2.0);
        if (num38 != 0)
        {
          int sfCount3 = this.game.Data.UnitObj[unr].SFCount;
          for (int index28 = 0; index28 <= sfCount3; ++index28)
          {
            int sf = this.game.Data.UnitObj[unr].SFList[index28];
            if (num38 > 0)
            {
              SFClass[] sfObj = this.game.Data.SFObj;
              SFClass[] sfClassArray = sfObj;
              int index29 = sf;
              int index30 = index29;
              sfClassArray[index30].Mor = sfObj[index29].Mor + (int) Math.Round(Math.Ceiling((double) ((100 - this.game.Data.SFObj[sf].Mor) * num38) / 100.0));
            }
            else
            {
              SFClass[] sfObj = this.game.Data.SFObj;
              SFClass[] sfClassArray = sfObj;
              int index31 = sf;
              int index32 = index31;
              sfClassArray[index32].Mor = sfObj[index31].Mor - (int) Math.Round(Math.Ceiling((double) (this.game.Data.SFObj[sf].Mor * Math.Abs(num38)) / 100.0));
            }
            if (0 > this.game.Data.SFObj[sf].Mor)
              this.game.Data.SFObj[sf].Mor = 0;
            if (this.game.Data.SFObj[sf].Mor > 100)
              this.game.Data.SFObj[sf].Mor = 100;
          }
          string str1 = "Kills versus losses ratio result in Morale change of ";
          string str2 = (double) num36 >= 1.0 ? str1 + num38.ToString() + "%" : str1 + "+" + num38.ToString() + "%";
          this.AddBiggy(str2);
          this.AddReport(1, "Kills/Losses ratio morale change", str2, tunr, this.CombatRound);
        }
      }
      if (this.UList[tunr].UAA == 0)
        this.game.Data.UnitObj[unr].Supply = num8 <= 0 ? 0 : (int) Math.Round(Conversion.Int((double) this.game.Data.UnitObj[unr].Supply * ((double) num9 / (double) num8)));
      if (this.game.Data.UnitObj[unr].SFCount > -1)
      {
        int num41 = 0;
        int sfCount4 = this.game.Data.UnitObj[unr].SFCount;
        for (int index33 = 0; index33 <= sfCount4; ++index33)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index33];
          num41 += this.game.Data.SFObj[sf].Qty;
        }
        if (num41 == 0)
        {
          this.AddDetail("We are going to remove unit because no fighters left in it.");
          this.UList[tunr].UDead = 1;
        }
      }
      else if (!(this.CombatType == 3 | this.CombatType == 4 | this.CombatType == 6 | this.CombatType == 5 | this.CombatType == 13) && !(this.BattleEnded != 1 & this.game.Data.UnitObj[unr].IsHQ))
      {
        this.AddDetail("We are going to remove unit because nothing left");
        this.UList[tunr].UDead = 1;
      }
      if (this.UList[tunr].UDead != 1)
        this.game.ProcessingObj.MaxReadinessRule(unr);
      int index34;
      if (index1 > -1)
      {
        this.game.Data.StringListObj[index1].SetItem(length, 6, this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr).ToString());
        StringListClass stringListClass = this.game.Data.StringListObj[index1];
        int row = length;
        index34 = this.game.HandyFunctionsObj.GetAverageRdn(unr);
        string s = index34.ToString();
        stringListClass.SetItem(row, 7, s);
        int num42 = 0;
        if (this.UList[tunr].UDead == 1)
          num42 = 5;
        if (this.UList[tunr].URetreat > 0 & this.UList[tunr].URetreatMode == 1)
          num42 = 2;
        else if (this.UList[tunr].URetreat > 0)
          num42 = 1;
        if (this.UList[tunr].UPanicked)
          num42 = 3;
        if (this.UList[tunr].UBreaks)
          num42 = 4;
        this.game.Data.StringListObj[index1].SetItem(length, 8, num42.ToString());
      }
      if ((double) this.game.Data.RuleVar[472] > 0.0 & this.game.Data.Product >= 6)
      {
        int averageRdn3 = this.game.HandyFunctionsObj.GetAverageRdn(unr);
        int uinitialRdn = this.UList[tunr].UinitialRdn;
        if (averageRdn3 < uinitialRdn)
        {
          int num43 = (int) Math.Round((double) ((uinitialRdn - averageRdn3) * 100) / (double) uinitialRdn) * 2;
          if (num43 > 100)
            num43 = 100;
          if (num43 > 0)
          {
            UnitClass[] unitObj = this.game.Data.UnitObj;
            UnitClass[] unitClassArray = unitObj;
            index34 = unr;
            int index35 = index34;
            unitClassArray[index35].apReserve = unitObj[index34].apReserve - (int) Math.Round((double) (this.game.Data.UnitObj[unr].apReserve * num43) / 100.0);
          }
        }
      }
      if (this.game.Data.Product == 6)
      {
        int num44 = 999;
        int sfCount5 = this.game.Data.UnitObj[unr].SFCount;
        for (int index36 = 0; index36 <= sfCount5; ++index36)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index36];
          if (this.game.Data.SFObj[sf].Ap < num44)
            num44 = this.game.Data.SFObj[sf].Ap;
        }
        if (num44 < 999)
        {
          int sfCount6 = this.game.Data.UnitObj[unr].SFCount;
          for (int index37 = 0; index37 <= sfCount6; ++index37)
            this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index37]].Ap = num44;
        }
      }
      if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[484] > 0.0 && this.game.Data.UnitObj[unr].moveMode == 1)
        this.game.Data.UnitObj[unr].moveMode = 0;
      if (this.game.Data.Product != 6)
        return;
      int num45 = this.game.HandyFunctionsObj.UnitMaximumFuelReserve(unr);
      if (this.game.Data.UnitObj[unr].Fuel > num45)
        this.game.Data.UnitObj[unr].Fuel = num45;
      int num46 = this.game.HandyFunctionsObj.UnitSupplyStore(unr);
      if (this.game.Data.UnitObj[unr].Supply > num46)
        this.game.Data.UnitObj[unr].Supply = num46;
      if (!((double) this.game.Data.RuleVar[399] > 0.0 & num1 > 0))
        return;
      int num47 = (int) Math.Round((double) (100f * this.game.Data.RuleVar[397] * (float) num1 / (float) num11));
      int num48 = (int) Math.Round(Math.Floor((double) num47 / 1000.0));
      int num49 = num47 - num48 * 1000;
      if (DrawMod.RandyNumber.Next(0, 1000) < num49)
        ++num48;
      if (num48 > (int) Math.Round((double) (this.game.Data.RuleVar[396] * (float) num1)))
        num48 = (int) Math.Round((double) (this.game.Data.RuleVar[396] * (float) num1));
      int sfCount7 = this.game.Data.UnitObj[unr].SFCount;
      for (int index38 = 0; index38 <= sfCount7; ++index38)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index38];
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        index34 = sf;
        int index39 = index34;
        sfClassArray[index39].Vigor = sfObj[index34].Vigor - num48;
        if (this.game.Data.SFObj[sf].Vigor < 1)
          this.game.Data.SFObj[sf].Vigor = 1;
      }
    }

    public bool issfthere(int sfnr)
    {
      int icounter = this.ICounter;
      for (int index = 0; index <= icounter; ++index)
      {
        if (this.IList[index].ISFNr == sfnr)
          return true;
      }
      return false;
    }

    public void killairandnavy(int tunr)
    {
      if (this.game.EditObj.CombatSim)
        return;
      int unr = this.UList[tunr].UNr;
      if (this.UList[tunr].UDefIntercept & this.UList[tunr].UCanRetreat.onmap)
        return;
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      for (int index1 = 0; index1 <= sfCount1; ++index1)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index1];
        if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater > 0)
        {
          if (!this.issfthere(sf))
          {
            int qty = this.game.Data.SFObj[sf].Qty;
            for (int index2 = 1; index2 <= qty; ++index2)
            {
              ++this.ICounter;
              this.IList = (Individual[]) Utils.CopyArray((Array) this.IList, (Array) new Individual[this.ICounter + 1]);
              this.IList[this.ICounter].IAttacker = 0;
              this.IList[this.ICounter].ISFType = this.game.Data.SFObj[sf].Type;
              this.IList[this.ICounter].ISFNr = sf;
              this.IList[this.ICounter].IKilled = 1;
              this.IList[this.ICounter].IUnr = unr;
              this.IList[this.ICounter].ICapitulate = true;
              int isfType = this.IList[this.ICounter].ISFType;
              int index3;
              int index4;
              if (this.IList[this.ICounter].IAttacker == 1)
              {
                index3 = this.AttackerRegime;
                index4 = this.DefenderRegime;
              }
              else
              {
                index3 = this.DefenderRegime;
                index4 = this.AttackerRegime;
              }
              if ((double) this.game.Data.RuleVar[841] == 0.0 & index4 < this.AttackerRegime)
              {
                int[,] skills = this.game.Data.RegimeObj[index4].SKills;
                int[,] numArray = skills;
                int index5 = isfType;
                int index6 = index5;
                int index7 = this.game.Data.Round + 1;
                int index8 = index7;
                int num = skills[index5, index7] + 1;
                numArray[index6, index8] = num;
              }
              else
              {
                int[,] skills = this.game.Data.RegimeObj[index4].SKills;
                int[,] numArray = skills;
                int index9 = isfType;
                int index10 = index9;
                int round = this.game.Data.Round;
                int index11 = round;
                int num = skills[index9, round] + 1;
                numArray[index10, index11] = num;
              }
              if ((double) this.game.Data.RuleVar[841] == 0.0 & index3 < this.AttackerRegime)
              {
                int[,] sloss = this.game.Data.RegimeObj[index3].SLoss;
                int[,] numArray = sloss;
                int index12 = isfType;
                int index13 = index12;
                int index14 = this.game.Data.Round + 1;
                int index15 = index14;
                int num = sloss[index12, index14] + 1;
                numArray[index13, index15] = num;
              }
              else
              {
                int[,] sloss = this.game.Data.RegimeObj[index3].SLoss;
                int[,] numArray = sloss;
                int index16 = isfType;
                int index17 = index16;
                int round = this.game.Data.Round;
                int index18 = round;
                int num = sloss[index16, round] + 1;
                numArray[index17, index18] = num;
              }
              if (index3 == this.AttackerRegime)
              {
                int[,] sloss = this.game.Data.RegimeObj[index3].SLoss;
                int[,] numArray = sloss;
                int index19 = isfType;
                int index20 = index19;
                int index21 = 0;
                int index22 = index21;
                int num = sloss[index19, index21] + 1;
                numArray[index20, index22] = num;
              }
              if (index4 == this.AttackerRegime)
              {
                int[,] skills = this.game.Data.RegimeObj[index4].SKills;
                int[,] numArray = skills;
                int index23 = isfType;
                int index24 = index23;
                int index25 = 0;
                int index26 = index25;
                int num = skills[index23, index25] + 1;
                numArray[index24, index26] = num;
              }
            }
          }
          else
          {
            int icounter = this.ICounter;
            for (int index27 = 0; index27 <= icounter; ++index27)
            {
              if (this.IList[index27].ISFNr == sf & this.IList[index27].IKilled == 0)
              {
                this.IList[index27].IKilled = 1;
                this.IList[index27].ICapitulate = true;
                int isfType = this.IList[index27].ISFType;
                int index28;
                int index29;
                if (this.IList[index27].IAttacker == 1)
                {
                  index28 = this.AttackerRegime;
                  index29 = this.DefenderRegime;
                }
                else
                {
                  index28 = this.DefenderRegime;
                  index29 = this.AttackerRegime;
                }
                if (index29 < this.AttackerRegime & (double) this.game.Data.RuleVar[841] == 0.0)
                {
                  int[,] skills = this.game.Data.RegimeObj[index29].SKills;
                  int[,] numArray = skills;
                  int index30 = isfType;
                  int index31 = index30;
                  int index32 = this.game.Data.Round + 1;
                  int index33 = index32;
                  int num = skills[index30, index32] + 1;
                  numArray[index31, index33] = num;
                }
                else
                {
                  int[,] skills = this.game.Data.RegimeObj[index29].SKills;
                  int[,] numArray = skills;
                  int index34 = isfType;
                  int index35 = index34;
                  int round = this.game.Data.Round;
                  int index36 = round;
                  int num = skills[index34, round] + 1;
                  numArray[index35, index36] = num;
                }
                if (index28 < this.AttackerRegime & (double) this.game.Data.RuleVar[841] == 0.0)
                {
                  int[,] sloss = this.game.Data.RegimeObj[index28].SLoss;
                  int[,] numArray = sloss;
                  int index37 = isfType;
                  int index38 = index37;
                  int index39 = this.game.Data.Round + 1;
                  int index40 = index39;
                  int num = sloss[index37, index39] + 1;
                  numArray[index38, index40] = num;
                }
                else
                {
                  int[,] sloss = this.game.Data.RegimeObj[index28].SLoss;
                  int[,] numArray = sloss;
                  int index41 = isfType;
                  int index42 = index41;
                  int round = this.game.Data.Round;
                  int index43 = round;
                  int num = sloss[index41, round] + 1;
                  numArray[index42, index43] = num;
                }
                if (index28 == this.AttackerRegime)
                {
                  int[,] sloss = this.game.Data.RegimeObj[index28].SLoss;
                  int[,] numArray = sloss;
                  int index44 = isfType;
                  int index45 = index44;
                  int index46 = 0;
                  int index47 = index46;
                  int num = sloss[index44, index46] + 1;
                  numArray[index45, index47] = num;
                }
                if (index29 == this.AttackerRegime)
                {
                  int[,] skills = this.game.Data.RegimeObj[index29].SKills;
                  int[,] numArray = skills;
                  int index48 = isfType;
                  int index49 = index48;
                  int index50 = 0;
                  int index51 = index50;
                  int num = skills[index48, index50] + 1;
                  numArray[index49, index51] = num;
                }
              }
            }
          }
          this.game.Data.SFObj[sf].Qty = 0;
        }
      }
      if (this.game.Data.UnitObj[unr].SFCount > -1)
      {
        int num = 0;
        int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
        for (int index = 0; index <= sfCount2; ++index)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index];
          num += this.game.Data.SFObj[sf].Qty;
        }
        if (num != 0)
          return;
        this.AddDetail("We are going to remove unit because no fighters left in it. (2)");
        this.UList[tunr].UDead = 1;
      }
      else
      {
        this.AddDetail("We are going to remove unit because no fighters left in it. (2)");
        this.UList[tunr].UDead = 1;
      }
    }

    public void KillUnit(int unr)
    {
      this.AddBiggy("Unit has been destroyed " + this.game.Data.UnitObj[unr].Name);
      if (this.customCombatObj.HasCustumCalls())
      {
        CustomCombatCalls customCombatObj = this.customCombatObj;
        CombatClass combatClass = this;
        ref CombatClass local = ref combatClass;
        GameClass game = this.game;
        int unr1 = unr;
        customCombatObj.UnitLost(ref local, game, unr1);
      }
      this.game.Data.RemoveUnit(unr, ref this.game);
    }

    public void DoRetreat(int tunr)
    {
      if (this.game.EditObj.CombatSim || this.UList[tunr].UDead == 1)
        return;
      int unr = this.UList[tunr].UNr;
      if (this.UList[tunr].UCanRetreat.onmap & this.UList[tunr].Uattacker == 0 && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && this.game.Data.MapObj[this.UList[tunr].UCanRetreat.map].HexObj[this.UList[tunr].UCanRetreat.x, this.UList[tunr].UCanRetreat.y].UnitCounter > 14 + this.UList[tunr].Uattacker)
      {
        this.UList[tunr].UCanRetreat.onmap = false;
        this.UList[tunr].UCanRetreat.x = -1;
        this.UList[tunr].UCanRetreat.y = -1;
        if (this.UList[tunr].Uattacker == 0)
        {
          Coordinate coord = new Coordinate();
          coord.x = this.TargetX;
          coord.y = this.TargetY;
          coord.map = this.TargetMap;
          coord.onmap = true;
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea)
            this.UList[tunr].UCanRetreat = this.game.HandyFunctionsObj.FindLandRetreat(unr, coord, (Neighbours) null);
          else if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.TargetMap].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea)
            this.UList[tunr].UCanRetreat = this.game.HandyFunctionsObj.FindSeaRetreat(unr, coord, (Neighbours) null);
        }
      }
      if ((double) this.game.Data.RuleVar[894] > 0.0 && this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].Type == 8 && this.UList[tunr].Uattacker == 0 && this.CombatType == 1 | this.CombatType == 12)
        this.UList[tunr].UCanRetreat.onmap = false;
      int num1;
      if (this.UList[tunr].UCanRetreat.onmap)
      {
        try
        {
          this.game.Data.MapObj[this.game.Data.UnitObj[unr].Map].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].RemoveUnitFromList(unr);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          num1 = 1;
          ProjectData.ClearProjectError();
        }
        this.game.Data.UnitObj[unr].apReserve = 0;
        this.game.Data.UnitObj[unr].X = this.UList[tunr].UCanRetreat.x;
        this.game.Data.UnitObj[unr].Y = this.UList[tunr].UCanRetreat.y;
        this.game.Data.UnitObj[unr].Map = this.UList[tunr].UCanRetreat.map;
        this.game.Data.MapObj[this.UList[tunr].UCanRetreat.map].HexObj[this.UList[tunr].UCanRetreat.x, this.UList[tunr].UCanRetreat.y].AddUnitToList(unr);
        if (this.game.Data.UnitObj[unr].SFCount > -1)
        {
          int sfCount = this.game.Data.UnitObj[unr].SFCount;
          for (int index = 0; index <= sfCount; ++index)
          {
            int sf = this.game.Data.UnitObj[unr].SFList[index];
            if (this.UList[tunr].Uattacker == 1)
            {
              if (!(this.CombatType == 3 | this.CombatType == 4) & (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ArtRange > 0 | this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater > 0))
              {
                this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(this.UList[tunr].UCanRetreat.x, this.UList[tunr].UCanRetreat.y, this.UList[tunr].UCanRetreat.map, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].Type].UnitGroup);
                this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].initialEntrench = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].CurrentEntrench;
              }
            }
            else
              this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].Ap = 0;
          }
        }
        this.AddBiggy("Retreat or BreakofCombat is succesfull for " + this.game.Data.UnitObj[unr].Name);
        if (this.HexList.Exists(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map))
          return;
        this.HexList.AddCoord(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map);
      }
      else
      {
        bool flag1 = false;
        if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[455] > 0.0)
        {
          SimpleList simpleList1 = new SimpleList();
          SimpleList simpleList2 = new SimpleList();
          Coordinate coord1;
          coord1.x = this.TargetX;
          coord1.y = this.TargetY;
          coord1.map = 0;
          coord1.onmap = true;
          Neighbours neighbour = new Neighbours();
          if (this.CombatType == 1 | this.CombatType == 2 | this.CombatType == 11)
          {
            int num2 = this.game.HandyFunctionsObj.HexFacing(coord1.x, coord1.y, coord1.map, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map);
            if (num2 > 0)
              neighbour.data[num2 - 1] = 1;
          }
          int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
          int sf1;
          for (int index1 = 0; index1 <= sfCount1; ++index1)
          {
            sf1 = this.game.Data.UnitObj[unr].SFList[index1];
            int people = this.game.Data.SFObj[sf1].People;
            int tid = sf1;
            int tweight = 0;
            int type = this.game.Data.SFObj[sf1].Type;
            int icounter = this.ICounter;
            for (int index2 = 1; index2 <= icounter; ++index2)
            {
              if (this.IList[index2].ISFNr == sf1 && !(this.IList[index2].IKilled > 0 | -(this.IList[index2].ICapitulate ? 1 : 0) > 0))
                ++tweight;
            }
            simpleList2.Add(sf1, tweight, CheckExistence: false);
            if (tweight >= 1)
            {
              int forceDirection = 1;
              do
              {
                float num3 = this.game.Data.RuleVar[455];
                this.game.Data.RuleVar[455] = 0.0f;
                Coordinate landRetreat1 = this.game.HandyFunctionsObj.FindLandRetreat(unr, coord1, neighbour, forceDirection: forceDirection);
                this.game.Data.RuleVar[455] = num3;
                Coordinate landRetreat2 = this.game.HandyFunctionsObj.FindLandRetreat(unr, coord1, neighbour, this.game.Data.SFTypeObj[type].MoveType, forceDirection);
                if (landRetreat2.onmap & landRetreat1.onmap)
                {
                  int tdata1 = 1;
                  int x = landRetreat2.x;
                  int y = landRetreat2.y;
                  simpleList1.Add(tid, 1, tdata1, x, y, CheckExistence: false);
                }
                else if (this.game.Data.SFTypeObj[type].scrapable > 0 & (double) this.game.Data.RuleVar[486] > 0.0)
                {
                  int index3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[486]))].GetData(0, people, 1)));
                  if (index3 > -1)
                  {
                    landRetreat2 = this.game.HandyFunctionsObj.FindLandRetreat(unr, coord1, neighbour, this.game.Data.SFTypeObj[index3].MoveType, forceDirection);
                    if (landRetreat2.onmap & landRetreat1.onmap)
                    {
                      int tdata1 = 2;
                      int x = landRetreat2.x;
                      int y = landRetreat2.y;
                      simpleList1.Add(tid, 2, tdata1, x, y, CheckExistence: false);
                    }
                  }
                }
                ++forceDirection;
              }
              while (forceDirection <= 6);
            }
          }
          CoordList coordList = new CoordList();
          int counter1 = simpleList1.Counter;
          for (int index = 0; index <= counter1; ++index)
          {
            if (coordList.FindSlot(simpleList1.Data2[index], simpleList1.Data3[index], 0) == -1)
              coordList.AddCoord(simpleList1.Data2[index], simpleList1.Data3[index], 0);
          }
          int counter2 = coordList.counter;
          for (int index4 = 0; index4 <= counter2; ++index4)
          {
            int counter3 = simpleList2.Counter;
            for (int index5 = 0; index5 <= counter3; ++index5)
            {
              int num4 = 0;
              int counter4 = simpleList1.Counter;
              for (int index6 = 0; index6 <= counter4; ++index6)
              {
                if (simpleList1.Id[index6] == simpleList2.Id[index5] && simpleList1.Data2[index6] == coordList.coord[index4].x & simpleList1.Data3[index6] == coordList.coord[index4].y && simpleList1.Data1[index6] == 1)
                {
                  Coordinate[] coord2 = coordList.coord;
                  Coordinate[] coordinateArray = coord2;
                  int index7 = index4;
                  int index8 = index7;
                  coordinateArray[index8].data1 = coord2[index7].data1 + simpleList2.Weight[index5] * 2;
                  num4 = 1;
                }
              }
              if (num4 == 0)
              {
                int counter5 = simpleList1.Counter;
                for (int index9 = 0; index9 <= counter5; ++index9)
                {
                  if (simpleList1.Id[index9] == simpleList2.Id[index5] && simpleList1.Data2[index9] == coordList.coord[index4].x & simpleList1.Data3[index9] == coordList.coord[index4].y && simpleList1.Data1[index9] == 2)
                  {
                    Coordinate[] coord3 = coordList.coord;
                    Coordinate[] coordinateArray = coord3;
                    int index10 = index4;
                    int index11 = index10;
                    coordinateArray[index11].data1 = coord3[index10].data1 + simpleList2.Weight[index5] * 1;
                  }
                }
              }
            }
          }
          int index12 = -1;
          int num5 = 0;
          int counter6 = coordList.counter;
          for (int index13 = 0; index13 <= counter6; ++index13)
          {
            if (coordList.coord[index13].data1 > num5)
            {
              index12 = index13;
              num5 = coordList.coord[index13].data1;
            }
          }
          if (index12 > -1)
          {
            flag1 = true;
            this.UList[tunr].UCanRetreat.onmap = true;
            this.UList[tunr].UCanRetreat.x = coordList.coord[index12].x;
            this.UList[tunr].UCanRetreat.y = coordList.coord[index12].y;
            int counter7 = simpleList2.Counter;
            for (int index14 = 0; index14 <= counter7; ++index14)
            {
              if (simpleList2.Weight[index14] > 0)
              {
                bool flag2 = true;
                int counter8 = simpleList1.Counter;
                for (int index15 = 0; index15 <= counter8; ++index15)
                {
                  if (simpleList1.Id[index15] == simpleList2.Id[index14] && simpleList1.Data2[index15] == this.UList[tunr].UCanRetreat.x && simpleList1.Data3[index15] == this.UList[tunr].UCanRetreat.y)
                    flag2 = false;
                }
                if (flag2)
                {
                  sf1 = simpleList2.Id[index14];
                  int num6 = 0;
                  int type1 = this.game.Data.SFObj[sf1].Type;
                  string str = "Retreat forced surrender of " + this.game.Data.SFTypeObj[type1].Name + ".";
                  this.AddBiggy(str);
                  this.AddReport(1, "Partial Retreat", str, tunr, this.CombatRound);
                  bool flag3 = false;
                  if (this.CombatType == 2 & this.game.Data.SFTypeObj[type1].Theater != 1)
                    flag3 = true;
                  if (this.CombatType == 1 & this.game.Data.SFTypeObj[type1].Theater != 0)
                    flag3 = true;
                  if (flag3)
                  {
                    int qty = this.game.Data.SFObj[sf1].Qty;
                    for (int index16 = 1; index16 <= qty; ++index16)
                    {
                      ++this.ICounter;
                      this.IList = (Individual[]) Utils.CopyArray((Array) this.IList, (Array) new Individual[this.ICounter + 1]);
                      this.IList[this.ICounter].IAttacker = 0;
                      this.IList[this.ICounter].ISFType = this.game.Data.SFObj[sf1].Type;
                      this.IList[this.ICounter].ISFNr = sf1;
                      this.IList[this.ICounter].IKilled = 1;
                      ++num6;
                      this.IList[this.ICounter].ICapitulate = true;
                    }
                  }
                  else
                  {
                    int icounter = this.ICounter;
                    for (int index17 = 0; index17 <= icounter; ++index17)
                    {
                      if (this.IList[index17].ISFNr == sf1 & this.IList[index17].IKilled == 0)
                      {
                        this.IList[index17].IKilled = this.CombatRound;
                        ++num6;
                        this.IList[index17].ICapitulate = true;
                      }
                    }
                  }
                  int type2 = this.game.Data.SFObj[sf1].Type;
                  int index18;
                  int index19;
                  if (this.UList[tunr].Uattacker == 1)
                  {
                    index18 = this.AttackerRegime;
                    index19 = this.DefenderRegime;
                  }
                  else
                  {
                    index18 = this.DefenderRegime;
                    index19 = this.AttackerRegime;
                  }
                  if (index19 < this.AttackerRegime & (double) this.game.Data.RuleVar[841] == 0.0)
                  {
                    int[,] skills = this.game.Data.RegimeObj[index19].SKills;
                    int[,] numArray = skills;
                    int index20 = type2;
                    int index21 = index20;
                    int index22 = this.game.Data.Round + 1;
                    int index23 = index22;
                    int num7 = skills[index20, index22] + num6;
                    numArray[index21, index23] = num7;
                  }
                  else
                  {
                    int[,] skills = this.game.Data.RegimeObj[index19].SKills;
                    int[,] numArray = skills;
                    int index24 = type2;
                    int index25 = index24;
                    int round = this.game.Data.Round;
                    int index26 = round;
                    int num8 = skills[index24, round] + num6;
                    numArray[index25, index26] = num8;
                  }
                  if (index18 < this.AttackerRegime & (double) this.game.Data.RuleVar[841] == 0.0)
                  {
                    int[,] sloss = this.game.Data.RegimeObj[index18].SLoss;
                    int[,] numArray = sloss;
                    int index27 = type2;
                    int index28 = index27;
                    int index29 = this.game.Data.Round + 1;
                    int index30 = index29;
                    int num9 = sloss[index27, index29] + num6;
                    numArray[index28, index30] = num9;
                  }
                  else
                  {
                    int[,] sloss = this.game.Data.RegimeObj[index18].SLoss;
                    int[,] numArray = sloss;
                    int index31 = type2;
                    int index32 = index31;
                    int round = this.game.Data.Round;
                    int index33 = round;
                    int num10 = sloss[index31, round] + num6;
                    numArray[index32, index33] = num10;
                  }
                  if (index18 == this.AttackerRegime)
                  {
                    int[,] sloss = this.game.Data.RegimeObj[index18].SLoss;
                    int[,] numArray = sloss;
                    int index34 = type2;
                    int index35 = index34;
                    int index36 = 0;
                    int index37 = index36;
                    int num11 = sloss[index34, index36] + num6;
                    numArray[index35, index37] = num11;
                  }
                  if (index19 == this.AttackerRegime)
                  {
                    int[,] skills = this.game.Data.RegimeObj[index19].SKills;
                    int[,] numArray = skills;
                    int index38 = type2;
                    int index39 = index38;
                    int index40 = 0;
                    int index41 = index40;
                    int num12 = skills[index38, index40] + num6;
                    numArray[index39, index41] = num12;
                  }
                  this.game.Data.SFObj[sf1].Qty = 0;
                }
              }
            }
            int counter9 = simpleList2.Counter;
            for (int index42 = 0; index42 <= counter9; ++index42)
            {
              if (simpleList2.Weight[index42] > 0)
              {
                bool flag4 = false;
                int people1 = this.game.Data.SFObj[sf1].People;
                sf1 = simpleList2.Id[index42];
                int counter10 = simpleList1.Counter;
                for (int index43 = 0; index43 <= counter10; ++index43)
                {
                  if (simpleList1.Id[index43] == simpleList2.Id[index42] && simpleList1.Data2[index43] == this.UList[tunr].UCanRetreat.x && simpleList1.Data3[index43] == this.UList[tunr].UCanRetreat.y && simpleList1.Data1[index43] == 2)
                    flag4 = true;
                }
                if (flag4)
                {
                  int qty = this.game.Data.SFObj[sf1].Qty;
                  int people2 = this.game.Data.SFObj[sf1].People;
                  int type = this.game.Data.SFObj[sf1].Type;
                  string str = "Retreat forced scrapping of " + this.game.Data.SFTypeObj[type].Name + ".";
                  this.AddBiggy(str);
                  this.AddReport(1, "Partial Retreat", str, tunr, this.CombatRound);
                  int icounter = this.ICounter;
                  for (int index44 = 0; index44 <= icounter; ++index44)
                  {
                    if (this.IList[index44].ISFNr == sf1 & this.IList[index44].IKilled < 1)
                    {
                      int SfType = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[486]))].GetData(0, people2, 1)));
                      int xp = this.game.Data.SFObj[sf1].Xp;
                      int ap = this.game.Data.SFObj[sf1].Ap;
                      int rdn = this.game.Data.SFObj[sf1].Rdn;
                      int mor = this.game.Data.SFObj[sf1].Mor;
                      int supplyConsume = this.game.Data.UnitObj[unr].SupplyConsume;
                      int offMod = this.game.Data.SFObj[sf1].OffMod;
                      int defMod = this.game.Data.SFObj[sf1].DefMod;
                      int Qty = 0;
                      if (this.game.Data.SFTypeObj[type].scrapable >= 100)
                        Qty = 1 * (int) Math.Round(Math.Floor((double) this.game.Data.SFTypeObj[type].scrapable / 100.0));
                      else if (this.game.Data.SFTypeObj[type].scrapable > 1)
                      {
                        int num13 = 1;
                        do
                        {
                          if (DrawMod.RandyNumber.Next(1, 100) <= this.game.Data.SFTypeObj[type].scrapable)
                            ++Qty;
                          ++num13;
                        }
                        while (num13 <= 1);
                      }
                      else
                        Qty = 0;
                      int Ap = ap - 25;
                      if (Ap < 0)
                        Ap = 0;
                      if (Qty > 0)
                      {
                        this.game.HandyFunctionsObj.AddTroops3(unr, SfType, people2, Qty, xp, rdn, Ap, mor, supplyConsume, offmod: offMod, defmod: defMod);
                        int num14 = -1;
                        int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
                        for (int index45 = 0; index45 <= sfCount2; ++index45)
                        {
                          int sf2 = this.game.Data.UnitObj[unr].SFList[index45];
                          if (this.game.Data.SFObj[sf2].Type == SfType && this.game.Data.SFObj[sf2].People == people2)
                            num14 = sf2;
                        }
                        this.IList[index44].ISFNr = num14;
                        this.IList[index44].ISFType = SfType;
                      }
                      else
                      {
                        this.IList[index44].ICapitulate = true;
                        this.IList[index44].IKilled = this.CombatRound;
                      }
                    }
                  }
                  this.game.Data.SFObj[sf1].Qty = 0;
                }
              }
            }
            try
            {
              this.game.Data.MapObj[this.game.Data.UnitObj[unr].Map].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].RemoveUnitFromList(unr);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              num1 = 1;
              ProjectData.ClearProjectError();
            }
            this.game.Data.UnitObj[unr].X = this.UList[tunr].UCanRetreat.x;
            this.game.Data.UnitObj[unr].Y = this.UList[tunr].UCanRetreat.y;
            this.game.Data.UnitObj[unr].Map = this.UList[tunr].UCanRetreat.map;
            this.game.Data.UnitObj[unr].apReserve = 0;
            this.game.Data.MapObj[this.UList[tunr].UCanRetreat.map].HexObj[this.UList[tunr].UCanRetreat.x, this.UList[tunr].UCanRetreat.y].AddUnitToList(unr);
            if (this.game.Data.UnitObj[unr].SFCount > -1)
            {
              int sfCount3 = this.game.Data.UnitObj[unr].SFCount;
              for (int index46 = 0; index46 <= sfCount3; ++index46)
              {
                int sf3 = this.game.Data.UnitObj[unr].SFList[index46];
                if (this.game.Data.SFObj[sf3].Qty > 0)
                {
                  if (this.UList[tunr].Uattacker == 1)
                  {
                    if (!(this.CombatType == 3 | this.CombatType == 4) & (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf3].Type].ArtRange > 0 | this.game.Data.SFTypeObj[this.game.Data.SFObj[sf3].Type].Theater > 0))
                    {
                      this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index46]].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(this.UList[tunr].UCanRetreat.x, this.UList[tunr].UCanRetreat.y, this.UList[tunr].UCanRetreat.map, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index46]].Type].UnitGroup);
                      this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index46]].initialEntrench = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index46]].CurrentEntrench;
                    }
                  }
                  else
                    this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index46]].Ap = 0;
                }
              }
            }
            string str1 = "Retreat or BreakofCombat is partially succesfull for " + this.game.Data.UnitObj[unr].Name;
            this.AddBiggy(str1);
            this.AddReport(1, "Partial Retreat", str1, tunr, this.CombatRound);
            if (!this.HexList.Exists(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map))
              this.HexList.AddCoord(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map);
          }
        }
        if (flag1)
          return;
        int sfCount = this.game.Data.UnitObj[unr].SFCount;
        for (int index47 = 0; index47 <= sfCount; ++index47)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index47];
          int num15 = 0;
          int type3 = this.game.Data.SFObj[sf].Type;
          bool flag5 = false;
          if (this.CombatType == 2 & this.game.Data.SFTypeObj[type3].Theater != 1)
            flag5 = true;
          if (this.CombatType == 1 & this.game.Data.SFTypeObj[type3].Theater != 0)
            flag5 = true;
          if (flag5)
          {
            int qty = this.game.Data.SFObj[sf].Qty;
            for (int index48 = 1; index48 <= qty; ++index48)
            {
              ++this.ICounter;
              this.IList = (Individual[]) Utils.CopyArray((Array) this.IList, (Array) new Individual[this.ICounter + 1]);
              this.IList[this.ICounter].IAttacker = 0;
              this.IList[this.ICounter].ISFType = this.game.Data.SFObj[sf].Type;
              this.IList[this.ICounter].IKilled = 1;
              this.IList[this.ICounter].ISFNr = sf;
              ++num15;
              this.IList[this.ICounter].ICapitulate = true;
            }
          }
          else
          {
            int icounter = this.ICounter;
            for (int index49 = 0; index49 <= icounter; ++index49)
            {
              if (this.IList[index49].ISFNr == sf & this.IList[index49].IKilled == 0)
              {
                this.IList[index49].IKilled = 1;
                ++num15;
                this.IList[index49].ICapitulate = true;
              }
            }
          }
          int type4 = this.game.Data.SFObj[sf].Type;
          int index50;
          int index51;
          if (this.UList[tunr].Uattacker == 1)
          {
            index50 = this.AttackerRegime;
            index51 = this.DefenderRegime;
          }
          else
          {
            index50 = this.DefenderRegime;
            index51 = this.AttackerRegime;
          }
          if (index51 < this.AttackerRegime & (double) this.game.Data.RuleVar[841] == 0.0)
          {
            int[,] skills = this.game.Data.RegimeObj[index51].SKills;
            int[,] numArray = skills;
            int index52 = type4;
            int index53 = index52;
            int index54 = this.game.Data.Round + 1;
            int index55 = index54;
            int num16 = skills[index52, index54] + num15;
            numArray[index53, index55] = num16;
          }
          else
          {
            int[,] skills = this.game.Data.RegimeObj[index51].SKills;
            int[,] numArray = skills;
            int index56 = type4;
            int index57 = index56;
            int round = this.game.Data.Round;
            int index58 = round;
            int num17 = skills[index56, round] + num15;
            numArray[index57, index58] = num17;
          }
          if (index50 < this.AttackerRegime & (double) this.game.Data.RuleVar[841] == 0.0)
          {
            int[,] sloss = this.game.Data.RegimeObj[index50].SLoss;
            int[,] numArray = sloss;
            int index59 = type4;
            int index60 = index59;
            int index61 = this.game.Data.Round + 1;
            int index62 = index61;
            int num18 = sloss[index59, index61] + num15;
            numArray[index60, index62] = num18;
          }
          else
          {
            int[,] sloss = this.game.Data.RegimeObj[index50].SLoss;
            int[,] numArray = sloss;
            int index63 = type4;
            int index64 = index63;
            int round = this.game.Data.Round;
            int index65 = round;
            int num19 = sloss[index63, round] + num15;
            numArray[index64, index65] = num19;
          }
          if (index50 == this.AttackerRegime)
          {
            int[,] sloss = this.game.Data.RegimeObj[index50].SLoss;
            int[,] numArray = sloss;
            int index66 = type4;
            int index67 = index66;
            int index68 = 0;
            int index69 = index68;
            int num20 = sloss[index66, index68] + num15;
            numArray[index67, index69] = num20;
          }
          if (index51 == this.AttackerRegime)
          {
            int[,] skills = this.game.Data.RegimeObj[index51].SKills;
            int[,] numArray = skills;
            int index70 = type4;
            int index71 = index70;
            int index72 = 0;
            int index73 = index72;
            int num21 = skills[index70, index72] + num15;
            numArray[index71, index73] = num21;
          }
          this.game.Data.SFObj[sf].Qty = 0;
        }
        string str2 = "No retreat option for " + this.game.Data.UnitObj[unr].Name;
        this.AddReport(1, "Retreat Failed", str2, tunr, this.CombatRound);
        this.AddBiggy(str2);
        this.AddDetail("We are going to remove unit because no retreat option.");
        this.UList[tunr].UDead = 1;
      }
    }

    public void CheckBreakthrough()
    {
      int icounter1 = this.ICounter;
      int num1;
      int num2;
      for (int index = 0; index <= icounter1; ++index)
      {
        if (this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0)
        {
          if (this.IList[index].IAttacker == 0 && !this.game.Data.SFTypeObj[this.IList[index].ISFType].BackBench)
            ++num1;
          if (this.IList[index].IAttacker == 1 && !this.game.Data.SFTypeObj[this.IList[index].ISFType].BackBench)
            ++num2;
        }
      }
      int icounter2 = this.ICounter;
      for (int index = 0; index <= icounter2; ++index)
      {
        if (this.IList[index].IAttacker == 1)
        {
          if (!(this.CombatType == 4 | this.CombatType == 3) | this.game.Data.Product < 5 && this.IList[index].ISuccesfullAttack == this.CombatRound | this.IList[index].ILastTargeted + 2 <= this.CombatRound | num1 == 0 && !this.game.Data.SFTypeObj[this.IList[index].ISFType].BackBench && this.IList[index].IBattleRounds >= 2 | num1 == 0 && this.IList[index].ILastHit + 2 <= this.CombatRound | num1 == 0 && this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0 & this.IList[index].IRetreated == 0 && this.IList[index].IBreakTrough == 0 && (double) VBMath.Rnd() < 1.0 / (double) this.CrowdingAttMod | num1 == 0)
          {
            this.IList[index].IBreakTrough = 1;
            string s = "ATTACKER: Has broken through.";
            this.AddReport(0, "Broken through", "This individual has broken through enemy lines.", index + 10000, this.CombatRound);
            this.AddDetail(s);
          }
        }
        else if ((this.IList[index].ISuccesfullAttack == this.CombatRound | this.IList[index].ILastTargeted + 2 <= this.CombatRound) & num2 == 0 && !this.game.Data.SFTypeObj[this.IList[index].ISFType].BackBench && this.IList[index].IBattleRounds >= 2 | num2 == 0 && this.IList[index].ILastHit + 2 <= this.CombatRound | num2 == 0 && !(this.CombatType == 3 | this.CombatType == 4 | this.CombatType == 5) && this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0 & this.IList[index].IRetreated == 0 && this.IList[index].IBreakTrough == 0 && (double) VBMath.Rnd() < 1.0 / (double) this.CrowdingDefMod | num2 == 0)
        {
          this.IList[index].IBreakTrough = 1;
          string s = "DEFENDER: Has broken through.";
          this.AddReport(0, "Broken through", "This individual has broken through enemy lines.", index + 10000, this.CombatRound);
          this.AddDetail(s);
        }
        if (this.IList[index].IAttacker == 1)
        {
          if (this.CombatRound > 1 | num1 == 0 && this.IList[index].IBreakTrough == 0 && !this.game.Data.SFTypeObj[this.IList[index].ISFType].BackBench && (double) this.IList[index].AttackedCount <= Conversion.Int((double) this.game.Data.SFTypeObj[this.IList[index].ISFType].MaxAttacked / 2.0) && this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 2 && this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0 & this.IList[index].IRetreated == 0 && this.IList[index].IBreakTrough == 0)
          {
            this.IList[index].IBreakTrough = 1;
            string s = "AIR: Has broken through.";
            this.AddReport(0, "Broken through", "This individual has broken through enemy lines.", index + 10000, this.CombatRound);
            this.AddDetail(s);
          }
        }
        else if (this.CombatRound > 1 | num2 == 0 && this.IList[index].IBreakTrough == 0 && !this.game.Data.SFTypeObj[this.IList[index].ISFType].BackBench && (double) this.IList[index].AttackedCount <= Conversion.Int((double) this.game.Data.SFTypeObj[this.IList[index].ISFType].MaxAttacked / 2.0) && this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == 2 && this.IList[index].IKilled == 0 & this.IList[index].IRetreat == 0 & this.IList[index].IRetreated == 0 && this.IList[index].IBreakTrough == 0)
        {
          this.IList[index].IBreakTrough = 1;
          string s = "AIR: Has broken through.";
          this.AddReport(0, "Broken through", "This individual has broken through enemy lines.", index + 10000, this.CombatRound);
          this.AddDetail(s);
        }
      }
    }

    public void ReduceRdn(int inr, int percent)
    {
      int num = (int) Math.Round(Conversion.Int((double) this.IList[inr].IRdn * ((double) percent / 100.0)));
      if (num == 0)
        num = 1;
      Individual[] ilist = this.IList;
      Individual[] individualArray = ilist;
      int index1 = inr;
      int index2 = index1;
      individualArray[index2].IRdn = ilist[index1].IRdn - num;
      if (this.IList[inr].IRdn >= 0)
        return;
      this.IList[inr].IRdn = 0;
    }

    public void ReduceAbsRdn(int inr, int absnumber)
    {
      Individual[] ilist = this.IList;
      Individual[] individualArray = ilist;
      int index1 = inr;
      int index2 = index1;
      individualArray[index2].IRdn = ilist[index1].IRdn - absnumber;
      if (this.IList[inr].IRdn >= 0)
        return;
      this.IList[inr].IRdn = 0;
    }

    public void ReduceEntr(int inr, int percent)
    {
      int num = (int) Math.Round(Conversion.Int((double) this.IList[inr].IEntrench * ((double) percent / 100.0)));
      if (num == 0)
        num = 1;
      Individual[] ilist = this.IList;
      Individual[] individualArray = ilist;
      int index1 = inr;
      int index2 = index1;
      individualArray[index2].IEntrench = ilist[index1].IEntrench - num;
      if (this.IList[inr].IEntrench >= 0)
        return;
      this.IList[inr].IEntrench = 0;
    }

    public void ReduceEntr_AdvancedCombatRecon(int attNr, int inr, int percent)
    {
      bool flag = false;
      if (!(this.CombatType == 3 | this.CombatType == 4 | this.InterceptFire))
      {
        if (this.game.Data.SFTypeObj[this.IList[inr].ISFType].BackBench)
        {
          if (!this.game.Data.SFTypeObj[this.IList[attNr].ISFType].BackBench && this.IList[attNr].IBreakTrough > 0)
            flag = true;
        }
        else if (!this.game.Data.SFTypeObj[this.IList[attNr].ISFType].BackBench)
          flag = true;
      }
      int num = (int) Math.Round(Conversion.Int((double) this.IList[inr].IEntrench * ((double) percent / 100.0)));
      if (num == 0)
        num = 1;
      if (flag)
      {
        Individual[] ilist = this.IList;
        Individual[] individualArray = ilist;
        int index1 = inr;
        int index2 = index1;
        individualArray[index2].IEntrench = ilist[index1].IEntrench - num;
        if (this.IList[inr].IEntrench >= 0)
          return;
        this.IList[inr].IEntrench = 0;
      }
      else if (this.game.Data.SFObj[this.IList[inr].ISFNr].initialEntrench > 0)
      {
        Individual[] ilist = this.IList;
        Individual[] individualArray = ilist;
        int index3 = inr;
        int index4 = index3;
        individualArray[index4].IEntrench = ilist[index3].IEntrench - num;
        if (this.IList[inr].IEntrench < 0)
          this.IList[inr].IEntrench = 0;
        if ((int) Math.Round(Math.Floor((double) this.game.Data.SFObj[this.IList[inr].ISFNr].initialEntrench * 0.66)) <= this.IList[inr].IEntrench)
          return;
        this.IList[inr].IEntrench = (int) Math.Round(Math.Floor((double) this.game.Data.SFObj[this.IList[inr].ISFNr].initialEntrench * 0.66));
      }
      else
      {
        Individual[] ilist = this.IList;
        Individual[] individualArray = ilist;
        int index5 = inr;
        int index6 = index5;
        individualArray[index6].IEntrench = ilist[index5].IEntrench - num;
        if (this.IList[inr].IEntrench >= 0)
          return;
        this.IList[inr].IEntrench = 0;
      }
    }

    public void ReduceMor(int inr, int percent)
    {
      int num = (int) Math.Round(Conversion.Int((double) this.IList[inr].IMor * ((double) percent / 100.0)));
      if (num == 0)
        num = 1;
      if (num > 0 & this.customCombatObj.HasCustumCalls())
      {
        CustomCombatCalls customCombatObj = this.customCombatObj;
        CombatClass combatClass = this;
        ref CombatClass local = ref combatClass;
        int inr1 = inr;
        int morMod = num;
        num = customCombatObj.IndividualMORMod(ref local, inr1, morMod);
      }
      Individual[] ilist = this.IList;
      Individual[] individualArray = ilist;
      int index1 = inr;
      int index2 = index1;
      individualArray[index2].IMor = ilist[index1].IMor - num;
      if (this.IList[inr].IMor >= 0)
        return;
      this.IList[inr].IMor = 0;
    }

    public void AddMor(int inr, int percent)
    {
      int num = (int) Math.Round(Conversion.Int((double) this.IList[inr].IMor * ((double) percent / 100.0)));
      Individual[] ilist = this.IList;
      Individual[] individualArray = ilist;
      int index1 = inr;
      int index2 = index1;
      individualArray[index2].IMor = ilist[index1].IMor + num;
      if (this.IList[inr].IMor <= 100)
        return;
      this.IList[inr].IMor = 100;
    }

    public int IsUnitFighting(int nr)
    {
      int ucounter = this.UCounter;
      for (int index = 0; index <= ucounter; ++index)
      {
        if (this.UList[index].UNr == nr)
          return index;
      }
      return -1;
    }

    public void AddXp(int inr, int pointstot)
    {
      if (this.game.EditObj.CombatSim)
        return;
      int num1;
      if (pointstot > 0)
      {
        int num2 = pointstot;
        for (int index1 = 1; index1 <= num2; ++index1)
        {
          float a = 0.0f;
          if ((double) a == 0.0)
          {
            if ((double) this.game.Data.RuleVar[80] <= 1.0)
            {
              if ((double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
                a = 1f;
            }
            else if ((double) this.game.Data.RuleVar[80] <= 2.0)
            {
              if ((double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
                a = 1f;
            }
            else if ((double) this.game.Data.RuleVar[80] <= 3.0)
            {
              if ((double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
                a = 1f;
            }
            else if ((double) this.game.Data.RuleVar[80] <= 4.0 && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          if ((double) a > 0.0 & this.customCombatObj.HasCustumCalls())
          {
            CustomCombatCalls customCombatObj = this.customCombatObj;
            CombatClass combatClass = this;
            ref CombatClass local = ref combatClass;
            int inr1 = inr;
            int xpToBeGiven = (int) Math.Round((double) a);
            a = (float) customCombatObj.IndividualXPMod(ref local, inr1, xpToBeGiven);
          }
          Individual[] ilist = this.IList;
          Individual[] individualArray = ilist;
          int index2 = inr;
          int index3 = index2;
          individualArray[index3].IXp = (int) Math.Round((double) ((float) ilist[index2].IXp + a));
          num1 = (int) Math.Round((double) ((float) num1 + a));
          if ((double) this.IList[inr].IXp > (double) this.game.Data.RuleVar[81])
            this.IList[inr].IXp = (int) Math.Round((double) this.game.Data.RuleVar[81]);
        }
      }
      if (this.game.Data.SFTypeObj[this.IList[inr].ISFType].StaffPts >= 1)
        return;
      int num3 = !this.game.Data.UnitObj[this.IList[inr].IUnr].IsHQ ? this.game.Data.UnitObj[this.IList[inr].IUnr].HQ : this.IList[inr].IUnr;
      if (!(num3 > -1 & num1 > 0))
        return;
      int num4 = this.IsUnitFighting(num3);
      if (num4 == -1)
      {
        int pointstot1 = (int) Math.Round((double) Conversion.Int((float) num1 * this.UList[this.IList[inr].IUlistNr].UStaffXpMod));
        if (pointstot1 < 1 & (double) VBMath.Rnd() < (double) this.UList[this.IList[inr].IUlistNr].UStaffXpMod)
          pointstot1 = 1;
        if (pointstot1 < 1)
          return;
        this.AddXpUnit(num3, pointstot1);
      }
      else
      {
        int inr2 = (int) Math.Round((double) (VBMath.Rnd() * (float) this.ICounter));
        int num5 = 0;
        while (num5 < 2)
        {
          ++inr2;
          if (inr2 > this.ICounter)
          {
            inr2 = 0;
            ++num5;
          }
          if (this.IList[inr2].IUlistNr == num4 && this.game.Data.SFTypeObj[this.IList[inr2].ISFType].StaffPts > 0)
          {
            int pointstot2 = (int) Math.Round((double) Conversion.Int((float) num1 * this.UList[this.IList[inr].IUlistNr].UStaffXpMod));
            if (pointstot2 < 1 & (double) VBMath.Rnd() < (double) this.UList[this.IList[inr].IUlistNr].UStaffXpMod)
              pointstot2 = 1;
            if (pointstot2 < 1)
              break;
            this.AddXp2(inr2, pointstot2);
            break;
          }
        }
      }
    }

    public void AddXp2(int inr, int pointstot)
    {
      if (pointstot <= 0)
        return;
      int num1 = pointstot;
      for (int index1 = 1; index1 <= num1; ++index1)
      {
        float a = 0.0f;
        if ((double) a == 0.0)
        {
          if ((double) this.game.Data.RuleVar[80] <= 1.0)
          {
            if (Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          else if ((double) this.game.Data.RuleVar[80] <= 2.0)
          {
            if (Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          else if ((double) this.game.Data.RuleVar[80] <= 3.0)
          {
            if (Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          else if ((double) this.game.Data.RuleVar[80] <= 4.0 && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81] && Math.Pow((double) VBMath.Rnd(), (double) this.game.Data.RuleVar[80]) > (double) this.IList[inr].IXp / (double) this.game.Data.RuleVar[81])
            a = 1f;
        }
        if ((double) a > 0.0 & this.customCombatObj.HasCustumCalls())
        {
          CustomCombatCalls customCombatObj = this.customCombatObj;
          CombatClass combatClass = this;
          ref CombatClass local = ref combatClass;
          int inr1 = inr;
          int xpToBeGiven = (int) Math.Round((double) a);
          a = (float) customCombatObj.IndividualXPMod(ref local, inr1, xpToBeGiven);
        }
        Individual[] ilist = this.IList;
        Individual[] individualArray = ilist;
        int index2 = inr;
        int index3 = index2;
        individualArray[index3].IXp = (int) Math.Round((double) ((float) ilist[index2].IXp + a));
        int num2 = (int) Math.Round((double) ((float) num2 + a));
        if ((double) this.IList[inr].IXp > (double) this.game.Data.RuleVar[81])
          this.IList[inr].IXp = (int) Math.Round((double) this.game.Data.RuleVar[81]);
      }
    }

    public void AddXp3(int sfnr, int pointstot)
    {
      if (pointstot <= 0)
        return;
      int num1 = pointstot;
      for (int index1 = 1; index1 <= num1; ++index1)
      {
        float a = 0.0f;
        if ((double) a == 0.0)
        {
          if ((double) this.game.Data.RuleVar[80] <= 1.0)
          {
            if ((double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          else if ((double) this.game.Data.RuleVar[80] <= 2.0)
          {
            if ((double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          else if ((double) this.game.Data.RuleVar[80] <= 3.0)
          {
            if ((double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81])
              a = 1f;
          }
          else if ((double) this.game.Data.RuleVar[80] <= 4.0 && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81] && (double) VBMath.Rnd() > (double) this.game.Data.SFObj[sfnr].Xp / (double) this.game.Data.RuleVar[81])
            a = 1f;
        }
        if ((double) a > 0.0 & this.customCombatObj.HasCustumCalls())
        {
          CustomCombatCalls customCombatObj = this.customCombatObj;
          CombatClass combatClass = this;
          ref CombatClass local = ref combatClass;
          int xpToBeGiven = (int) Math.Round((double) a);
          int sfnr1 = sfnr;
          a = (float) customCombatObj.IndividualXPMod(ref local, -1, xpToBeGiven, sfnr1);
        }
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index2 = sfnr;
        int index3 = index2;
        sfClassArray[index3].Xp = (int) Math.Round((double) ((float) sfObj[index2].Xp + a));
        int num2 = (int) Math.Round((double) ((float) num2 + a));
        if ((double) this.game.Data.SFObj[sfnr].Xp > (double) this.game.Data.RuleVar[81])
          this.game.Data.SFObj[sfnr].Xp = (int) Math.Round((double) this.game.Data.RuleVar[81]);
      }
    }

    public void AddXpUnit(int unr, int pointstot)
    {
      if (this.game.Data.UnitObj[unr].SFCount == -1)
        return;
      int historical = this.game.Data.UnitObj[unr].Historical;
      object[] objArray1 = new object[this.game.Data.UnitObj[unr].SFCount + 1];
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      int Right;
      for (int index1 = 0; index1 <= sfCount1; ++index1)
      {
        int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index1]].Type;
        object[] objArray2 = objArray1;
        object[] objArray3 = objArray2;
        int index2 = index1;
        int index3 = index2;
        object obj = Operators.AddObject(objArray2[index2], (object) this.game.Data.SFTypeObj[type].StaffPts);
        objArray3[index3] = obj;
        Right += this.game.Data.SFTypeObj[type].StaffPts;
      }
      if (Right < 1)
        return;
      VBMath.Rnd();
      float Left = 0.0f;
      int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
      for (int index4 = 0; index4 <= sfCount2; ++index4)
      {
        Left = Conversions.ToSingle(Operators.AddObject((object) Left, Operators.DivideObject(objArray1[index4], (object) Right)));
        int sf = this.game.Data.UnitObj[unr].SFList[index4];
        if ((double) VBMath.Rnd() <= (double) Left)
        {
          if ((double) VBMath.Rnd() >= (double) pointstot / (double) this.game.Data.SFObj[sf].Qty)
            break;
          this.AddXp3(sf, 1);
          if (historical <= -1 || Strings.Len(this.game.Data.HistoricalUnitObj[historical].CommanderName) <= 0 || (double) VBMath.Rnd() >= (double) this.game.Data.HistoricalUnitObj[historical].StaffSize / (double) Right)
            break;
          HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
          HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
          int index5 = historical;
          int index6 = index5;
          historicalUnitClassArray[index6].Xp = historicalUnitObj[index5].Xp + 1;
          break;
        }
      }
    }

    public void ParticipateUnitNr(int unr)
    {
      int ucounter = this.UCounter;
      for (int index = 0; index <= ucounter; ++index)
      {
        if (this.UList[index].UNr == unr)
          this.UList[index].UParticipated = 1;
      }
    }

    public int FindOpponent(int inr)
    {
      int favTargetTries = this.game.Data.SFTypeObj[this.IList[inr].ISFType].FavTargetTries;
      if (this.CombatType == 3 | this.CombatType == 4 && this.IList[inr].IAttacker == 0)
      {
        if ((double) this.game.Data.RuleVar[419] > 0.0)
        {
          if (!this.InterceptFire && this.CombatRound < 2 & !this.previewMode)
            return -1;
        }
        else if ((double) this.game.Data.RuleVar[142] < 1.0)
          return -1;
      }
      int combatType1 = this.CombatType;
      if (this.CombatType == 9 & this.IList[inr].IParadropper & this.CombatRound < 6)
        return -1;
      bool flag1 = false;
      if (this.game.Data.Product >= 6 && (double) this.game.Data.RuleVar[480] > 0.0 && this.CombatType == 3 | this.CombatType == 4)
        flag1 = true;
      if (this.IList[inr].IAttacker == 1)
      {
        int num1 = num1;
      }
      int num2 = 1;
      int num3;
      int opponent;
      int num4;
      int num5;
      do
      {
        num3 = 0;
        opponent = -1;
        num4 = 0;
        if (num2 == 1 & flag1 | num2 == 2)
        {
          int num6 = 0;
          do
          {
            int index = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (this.ICounter + 1)));
            int combatType2 = this.CombatType;
            bool flag2 = false;
            if (this.IList[inr].IAttacker == 0 & (double) this.game.Data.RuleVar[493] > 0.0 && this.IList[index].IAttacker == 1 & this.IList[index].IleftOutOfPartialAttack)
              flag2 = true;
            if (this.TestTarget(inr, index) & !flag2)
            {
              int unitGroup = this.game.Data.SFTypeObj[this.IList[index].ISFType].UnitGroup;
              if (this.CombatType == 3 | this.CombatType == 4)
              {
                num5 = this.game.Data.SFTypeObj[this.IList[inr].ISFType].FavArtTarget[unitGroup] * 10000;
                if (num5 == 0)
                  num5 = this.game.Data.SFTypeObj[this.IList[inr].ISFType].FavTarget[unitGroup] * 10000;
              }
              else
                num5 = this.game.Data.SFTypeObj[this.IList[inr].ISFType].FavTarget[unitGroup] * 10000;
              if (this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater == this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater)
              {
                if (this.game.Data.SFTypeObj[this.IList[inr].ISFType].Theater == 2)
                {
                  if (this.IList[inr].IAttacker == 1 && this.IList[index].IBreakTrough > 0)
                    num5 *= 2;
                }
                else if (this.IList[index].IBreakTrough > 0)
                  num5 *= 2;
                if (this.IList[inr].AttackedCount > this.game.Data.SFTypeObj[this.IList[inr].ISFType].MaxAttacked)
                  num5 = (int) Math.Round((double) (int) Math.Round((double) num5 / 50.0) * ((double) this.game.Data.SFTypeObj[this.IList[inr].ISFType].MaxAttacked / (double) this.IList[inr].AttackedCount));
              }
              if ((double) this.game.Data.RuleVar[431] > 0.0)
              {
                if ((double) this.GetEffectiveReconOnHexOfTargettedIndividual(index) < (double) this.IList[index].IcoverPoints)
                  num5 = (int) Math.Round((double) num5 / 3.0);
                if (num5 > 1)
                  num5 = DrawMod.RandyNumber.Next((int) Math.Round(Math.Ceiling((double) num5 / 10.0)), num5 + 1);
              }
              if (num5 > 0 & this.game.Data.Product >= 6 && this.game.Data.SFTypeObj[this.IList[index].ISFType].targettedByRangedChance > 0)
                num5 = (int) Math.Round((double) (num5 * this.game.Data.SFTypeObj[this.IList[index].ISFType].targettedByRangedChance) / 100.0);
              ++num3;
              if (this.game.Data.SFTypeObj[this.IList[index].ISFType].Theater != 2 & (this.CombatType == 6 | this.CombatType == 13 | this.CombatType == 14 | this.CombatType == 15))
                num5 = -1;
              if (num2 == 1 & flag1)
              {
                if (this.IList[index].ILastAttackDone > 0)
                {
                  if (this.IList[index].AttackedCount > this.GetMaxAttacked(index, inr))
                    num5 = 0;
                  else
                    ++num5;
                }
                else
                  num5 = 0;
              }
              if (num5 > num4)
              {
                num4 = num5;
                opponent = index;
              }
            }
            if (num3 < favTargetTries)
              ++num6;
            else
              break;
          }
          while (num6 <= 100);
          if (num2 == 1 & num3 > 0 & num4 > 0 & opponent > -1)
            break;
        }
        ++num2;
      }
      while (num2 <= 2);
      if (num3 < favTargetTries)
      {
        int icounter = this.ICounter;
        for (int index = 0; index <= icounter; ++index)
        {
          int defnr = index;
          bool flag3 = false;
          if (this.IList[inr].IAttacker == 0 & (double) this.game.Data.RuleVar[493] > 0.0 && this.IList[defnr].IAttacker == 1 & this.IList[defnr].IleftOutOfPartialAttack)
            flag3 = true;
          if (this.TestTarget(inr, defnr) & !flag3)
          {
            int unitGroup = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].UnitGroup;
            num5 = !(this.CombatType == 3 | this.CombatType == 4) ? this.game.Data.SFTypeObj[this.IList[inr].ISFType].FavArtTarget[unitGroup] : this.game.Data.SFTypeObj[this.IList[inr].ISFType].FavTarget[unitGroup];
            ++num3;
            if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater != 2 & (this.CombatType == 6 | this.CombatType == 13 & this.CombatType == 14 | this.CombatType == 15))
              num5 = -1;
            if (num5 > num4)
            {
              num4 = num5;
              opponent = defnr;
            }
          }
          if (num3 >= favTargetTries)
            break;
        }
      }
      if ((double) this.game.Data.RuleVar[431] > 0.0 & opponent > -1 && this.game.Data.Product != 7)
      {
        int inr1 = opponent;
        if ((double) this.GetEffectiveReconOnHexOfTargettedIndividual(inr1) < (double) this.IList[inr1].IcoverPoints)
        {
          int num7 = (int) Math.Round((double) num5 / 3.0);
          float num8 = this.AttackCrowding;
          int num9 = this.NewBattleStack;
          if (this.NewBattleStackArt > this.NewBattleStack)
          {
            num9 = this.NewBattleStackArt;
            num8 = this.AttackCrowdingArt;
          }
          if (this.IList[inr1].IAttacker == 0 & this.CrowdingDefCount > 0)
          {
            if (this.CrowdingDefCount < DrawMod.RandyNumber.Next(0, (int) Math.Round((double) (this.game.Data.RuleVar[30] * 2f))))
            {
              opponent = -1;
              if (!this.game.Data.FOWOn)
                this.AddReport(0, "No lucky hit", "Individual " + this.game.Data.SFTypeObj[this.IList[inr].ISFType].Name + " did not manage to score a lucky hit [Hidden]", inr + 10000, this.CombatRound);
            }
          }
          else if (this.IList[inr1].IAttacker == 1 & num9 > 0)
          {
            if (num9 >= DrawMod.RandyNumber.Next(0, (int) Math.Round((double) (num8 * 2f))))
            {
              opponent = opponent;
            }
            else
            {
              opponent = -1;
              if (!this.game.Data.FOWOn)
                this.AddReport(0, "No lucky hit", "Individual " + this.game.Data.SFTypeObj[this.IList[inr].ISFType].Name + " did not manage to score a lucky hit [Hidden]", inr + 10000, this.CombatRound);
            }
          }
          else
            opponent = -1;
        }
      }
      return opponent;
    }

    public void ThrowInitiative()
    {
      int icounter = this.ICounter;
      for (int inr = 0; inr <= icounter; ++inr)
      {
        if (this.TestAttack(inr))
        {
          int num1 = this.IList[inr].IAttacker != 1 ? this.game.Data.SFTypeObj[this.IList[inr].ISFType].InitiativeDef : this.game.Data.SFTypeObj[this.IList[inr].ISFType].Initiative;
          if (this.IList[inr].ILastAttackDone < this.CombatRound - 1 & this.CombatRound > 1)
            num1 += num1 * (this.CombatRound - 1 - this.IList[inr].ILastAttackDone);
          int num2 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) num1));
          this.IList[inr].IInitThrow = num2;
          this.IList[inr].IHistoricInit[this.CombatRound] = num2;
        }
        else
        {
          this.IList[inr].IInitThrow = 0;
          this.IList[inr].IHistoricInit[this.CombatRound] = 0;
        }
      }
    }

    public bool TestAttack(int inr) => this.IList[inr].IAttacker == 1 & this.CombatType == 13 ? this.game.Data.SFTypeObj[this.IList[inr].ISFType].AutoDestroy : !(this.IList[inr].IAttacker == 0 & this.InterceptFire) && this.IList[inr].IKilled == 0 && this.IList[inr].IRetreat == 0 && this.IList[inr].IRetreated == 0 && this.IList[inr].AttackCount < this.game.Data.SFTypeObj[this.IList[inr].ISFType].Attacks;

    public bool TestTarget(int attnr, int defnr)
    {
      if (this.IList[attnr].IAttacker == this.IList[defnr].IAttacker || this.InterceptFire && this.IList[attnr].IAttacker == 0)
        return false;
      if (this.CombatType == 3 | this.CombatType == 4 && this.IList[attnr].IAttacker == 0)
      {
        int x1 = this.game.Data.UnitObj[this.IList[attnr].IUnr].X;
        int y1 = this.game.Data.UnitObj[this.IList[attnr].IUnr].Y;
        int map1 = this.game.Data.UnitObj[this.IList[attnr].IUnr].Map;
        int x2 = this.game.Data.UnitObj[this.IList[defnr].IUnr].X;
        int y2 = this.game.Data.UnitObj[this.IList[defnr].IUnr].Y;
        int map2 = this.game.Data.UnitObj[this.IList[defnr].IUnr].Map;
        if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange < this.game.HandyFunctionsObj.Distance(x1, y1, map1, x2, y2, map2) && (!((double) this.game.Data.RuleVar[419] > 0.0 & (double) this.game.Data.RuleVar[429] > 0.0) || this.game.Data.SFTypeObj[this.IList[attnr].ISFType].directRange < this.game.HandyFunctionsObj.Distance(x1, y1, map1, x2, y2, map2) || Information.IsNothing((object) this.IList[attnr].IdirectFireDef) || !this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr]))
          return false;
      }
      if (this.IList[defnr].IAA == 1 || this.IList[defnr].IParadropper & this.CombatRound < 6 || this.IList[defnr].IRetreatMode == 1 && this.game.Data.Product != 6 && this.IList[defnr].IRetreat < this.CombatRound)
        return false;
      if (this.CombatType == 3 | this.CombatType == 4)
      {
        int unitGroup = this.game.Data.SFTypeObj[this.IList[defnr].ISFType].UnitGroup;
        if (Conversions.ToInteger(this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackArt[unitGroup]) == 0 && ((double) this.game.Data.RuleVar[419] <= 0.0 || this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPower[unitGroup] == 0))
          return false;
      }
      else if (this.IList[attnr].IAttacker == 1)
      {
        if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPower[this.game.Data.SFTypeObj[this.IList[defnr].ISFType].UnitGroup] <= 0)
          return false;
      }
      else if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].AttackPowerDef[this.game.Data.SFTypeObj[this.IList[defnr].ISFType].UnitGroup] <= 0)
        return false;
      if (this.IList[defnr].IKilled != 0 || this.IList[defnr].IRetreated != 0 || this.IList[attnr].IAttacker == this.IList[defnr].IAttacker)
        return false;
      int num1 = 1;
      if (this.UList[this.IList[defnr].IUlistNr].USupportInterceptFire)
        ;
      if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench && this.IList[defnr].IRetreat == 0)
      {
        if (this.IList[attnr].IBreakTrough == 0 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange < 1)
        {
          if ((double) this.game.Data.RuleVar[419] > 0.0)
          {
            int x3 = this.game.Data.UnitObj[this.IList[attnr].IUnr].X;
            int y3 = this.game.Data.UnitObj[this.IList[attnr].IUnr].Y;
            int map3 = this.game.Data.UnitObj[this.IList[attnr].IUnr].Map;
            int x4 = this.game.Data.UnitObj[this.IList[defnr].IUnr].X;
            int y4 = this.game.Data.UnitObj[this.IList[defnr].IUnr].Y;
            int map4 = this.game.Data.UnitObj[this.IList[defnr].IUnr].Map;
            if (this.CombatType == 3)
            {
              if (!(this.IList[attnr].IAttacker == 1 & this.InterceptFire))
              {
                if (this.IList[attnr].IAttacker == 1 & (double) this.IList[attnr].IdirectMod > 0.0)
                {
                  int num2 = this.game.Data.MapObj[0].HexObj[x3, y3].HeightLevel - this.game.Data.MapObj[0].HexObj[x4, y4].HeightLevel;
                  int num3 = 70 - (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x4, y4].LandscapeType].HidePts + 10) * (3 - num2);
                  int num4;
                  if (!Information.IsNothing((object) this.UList[this.IList[attnr].IUlistNr].ULos))
                    num4 = (int) Math.Round((double) (num3 * this.UList[this.IList[attnr].IUlistNr].ULos[this.IList[defnr].IUlistNr]) / 100.0);
                  if (new Random(attnr * this.CombatRound).Next(1, 100) >= num4)
                    return false;
                }
                else if (this.IList[attnr].IAttacker == 0)
                {
                  if (this.IList[attnr].IdirectFireDef[this.IList[defnr].IUlistNr])
                  {
                    int num5 = this.game.Data.MapObj[0].HexObj[x3, y3].HeightLevel - this.game.Data.MapObj[0].HexObj[x4, y4].HeightLevel;
                    int num6 = 70 - (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x4, y4].LandscapeType].HidePts + 10) * (3 - num5);
                    if (num6 < 0)
                      num6 = 0;
                    int num7;
                    if (!Information.IsNothing((object) this.UList[this.IList[attnr].IUlistNr].ULos))
                      num7 = (int) Math.Round((double) (num6 * this.UList[this.IList[attnr].IUlistNr].ULos[this.IList[defnr].IUlistNr]) / 100.0);
                    if (new Random(attnr * this.CombatRound).Next(1, 100) >= num7)
                      return false;
                  }
                  else
                    num1 = 0;
                }
                else
                  num1 = 0;
              }
            }
            else if (this.CombatType == 1)
            {
              if (this.IList[attnr].IAttacker == 1 & this.UList[this.IList[defnr].IUlistNr].USupportInterceptFire)
                return false;
              int num8 = this.game.Data.MapObj[0].HexObj[x3, y3].HeightLevel - this.game.Data.MapObj[0].HexObj[x4, y4].HeightLevel;
              int num9 = 100 - (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x4, y4].LandscapeType].HidePts + 10) * (3 - num8);
              if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].ArtRange > 0)
                num9 = (int) Math.Round((double) num9 / 4.0);
              else if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].directRange > 0)
                num9 = (int) Math.Round((double) num9 / 2.0);
              if (new Random(attnr * this.CombatRound).Next(1, 100) >= num9)
                return false;
            }
            else
              num1 = 0;
          }
          else
            num1 = 0;
        }
        if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater != 2)
        {
          if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 2)
            num1 = 1;
        }
        else if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater != 2)
        {
          if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2)
            num1 = 1;
        }
        else if (this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2)
        {
          if (this.IList[defnr].IAttacker == 0 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 2)
            num1 = 1;
        }
        else if (!(this.CombatType == 3 | this.CombatType == 4) && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater != 2)
          num1 = 1;
      }
      if (this.IList[attnr].IAttacker == 1 & this.UList[this.IList[defnr].IUlistNr].USupportInterceptFire)
        return false;
      if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 0 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].ArtRange > 0 && !this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 0 && this.IList[defnr].IBreakTrough > 0)
        num1 = 0;
      if (this.CombatType == 2 && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2 && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.TargetX, this.TargetY].LandscapeType].IsSea)
        return false;
      if (this.game.Data.SFTypeObj[this.IList[attnr].ISFType].BackBench && this.game.Data.SFTypeObj[this.IList[attnr].ISFType].Theater == 2 && !this.game.Data.SFTypeObj[this.IList[defnr].ISFType].BackBench && this.game.Data.SFTypeObj[this.IList[defnr].ISFType].Theater == 2)
        num1 = 0;
      return num1 == 1;
    }

    public void SortOnInitiative()
    {
      int icounter = this.ICounter;
      for (int index1 = 0; index1 <= icounter; ++index1)
      {
        int num = this.ICounter - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          if (this.IList[index2].IInitThrow < this.IList[index2 + 1].IInitThrow)
          {
            Individual individual = this.IList[index2];
            this.IList[index2] = this.IList[index2 + 1];
            this.IList[index2 + 1] = individual;
          }
        }
      }
    }

    public void AddDetail(string s)
    {
      if (!this.game.EditObj.PrefCombatLog)
        return;
      ++this.DetailCounter;
      this.DetailString = (string[]) Utils.CopyArray((Array) this.DetailString, (Array) new string[this.DetailCounter + 1]);
      this.DetailString[this.DetailCounter] = s;
      this.AddAllDetail(s);
    }

    public void AddAllDetail(string s)
    {
      if (!this.game.EditObj.PrefCombatLog)
        return;
      ++this.AllDetailCounter;
      this.AllDetailString = (string[]) Utils.CopyArray((Array) this.AllDetailString, (Array) new string[this.AllDetailCounter + 1]);
      this.AllDetailString[this.AllDetailCounter] = s;
    }

    public void AddBiggy(string s)
    {
      if (!this.game.EditObj.PrefCombatLog)
        return;
      this.AddDetail(s);
      ++this.BattleCounter;
      this.BattleString = (object[]) Utils.CopyArray((Array) this.BattleString, (Array) new object[this.BattleCounter + 1]);
      this.BattleString[this.BattleCounter] = (object) s;
    }

    public void ClearDetail()
    {
      this.DetailCounter = -1;
      this.DetailString = new string[1];
    }

    public void WriteToFileLog()
    {
      if (!this.game.EditObj.PrefCombatLog)
        return;
      StreamWriter streamWriter = this.CombatType != 12 ? File.CreateText(this.game.AppPath + "logs/lastbattle_Log.txt") : File.CreateText(this.game.AppPath + "logs/lastRebel_Log.txt");
      int allDetailCounter = this.AllDetailCounter;
      for (int index = 0; index <= allDetailCounter; ++index)
        streamWriter.WriteLine(this.AllDetailString[index]);
      streamWriter.Close();
    }
  }
}
