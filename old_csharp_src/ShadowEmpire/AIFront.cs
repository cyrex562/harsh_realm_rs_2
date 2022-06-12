﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIFront
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class AIFront
  {
    public DC2AIClass ai;
    public int FrontID;
    public AIUnitList strictHQs;
    public AIUnitList units;
    public AIUnitList artUnits;
    public AIUnitList orgUnits;
    public int FrontType;
    public AIUnitList removelist;
    public int Stance;
    public int Direction;
    public float OrigAverageStrength;
    public float AverageStrength;
    public int addedFictivePower;
    public int Strength;
    public int OrigPower;
    public int PowerToReserve;
    public int TargetFrontID;
    public int Distance;
    public int StartStance;
    public int OffensiveZone;
    public int DefensiveZone;
    public int OffensiveZone2;
    public int enemyPower;
    public int tempReservesLeaving;
    public bool tempDelivered;
    public int Importance;
    public int tempCreatedFromFrontID;
    public int temp1;
    public int OffensiveModifier;
    public bool TopOperation;
    public int StatLastPercentageOutOfSupply;
    public int StatAvgPercentageOutOfSupply;
    public int statLastPowerPercentageRun1;
    public int StatLastPowerPercentageFullRun;
    public int StatIterationCount;
    public int statsHexLeftPercentage;
    public Coordinate[] Coords;
    public int coordCount;
    public float UnitCountRatio;
    public int targetX;
    public int targetY;
    public int enemyAvgSupply;
    public int FrontHexes;
    public bool RealRetreat;
    public int bridgeCount;
    public int vpScoreAveragePercent;
    public int retreatAverageScore;
    public int ThreatPercentage;
    public int OpportunityPercentage;
    public int tempEnemyRegime;
    public int tempEnemyRegime2;
    public bool hasSupplySource;
    public int tempOrigAutomatonPower;
    public int receivedJoin;
    public int strengthModifier;

    public AIFront Clone()
    {
      AIFront aiFront = new AIFront(ref this.ai, this.FrontType);
      aiFront.Direction = this.Direction;
      aiFront.FrontID = this.FrontID;
      aiFront.Stance = this.Stance;
      aiFront.enemyAvgSupply = this.enemyAvgSupply;
      aiFront.StartStance = this.StartStance;
      aiFront.OffensiveModifier = this.OffensiveModifier;
      aiFront.Strength = this.Strength;
      aiFront.enemyPower = this.enemyPower;
      aiFront.AverageStrength = this.AverageStrength;
      aiFront.FrontType = this.FrontType;
      aiFront.RealRetreat = this.RealRetreat;
      aiFront.TargetFrontID = this.TargetFrontID;
      aiFront.Distance = this.Distance;
      aiFront.temp1 = this.temp1;
      aiFront.OrigAverageStrength = this.OrigAverageStrength;
      aiFront.StatAvgPercentageOutOfSupply = this.StatAvgPercentageOutOfSupply;
      aiFront.StatLastPercentageOutOfSupply = this.StatLastPercentageOutOfSupply;
      aiFront.StatIterationCount = this.StatIterationCount;
      aiFront.statsHexLeftPercentage = this.statsHexLeftPercentage;
      aiFront.Importance = this.Importance;
      aiFront.UnitCountRatio = this.UnitCountRatio;
      aiFront.TopOperation = this.TopOperation;
      aiFront.OffensiveZone = this.OffensiveZone;
      aiFront.OffensiveZone2 = this.OffensiveZone2;
      aiFront.FrontHexes = this.FrontHexes;
      aiFront.hasSupplySource = this.hasSupplySource;
      aiFront.DefensiveZone = this.DefensiveZone;
      aiFront.addedFictivePower = this.addedFictivePower;
      aiFront.tempCreatedFromFrontID = this.tempCreatedFromFrontID;
      aiFront.units = new AIUnitList();
      aiFront.artUnits = new AIUnitList();
      aiFront.orgUnits = new AIUnitList();
      aiFront.strictHQs = new AIUnitList();
      int counter1 = this.units.counter;
      for (int index = 0; index <= counter1; ++index)
        aiFront.units.add(this.units.unr[index], this.units.AIid[index]);
      int counter2 = this.artUnits.counter;
      for (int index = 0; index <= counter2; ++index)
        aiFront.artUnits.add(this.artUnits.unr[index], this.artUnits.AIid[index]);
      int counter3 = this.orgUnits.counter;
      for (int index = 0; index <= counter3; ++index)
        aiFront.orgUnits.add(this.orgUnits.unr[index], this.orgUnits.AIid[index]);
      int counter4 = this.strictHQs.counter;
      for (int index = 0; index <= counter4; ++index)
        aiFront.strictHQs.add(this.strictHQs.unr[index], this.strictHQs.AIid[index]);
      aiFront.removelist = (AIUnitList) null;
      aiFront.coordCount = this.coordCount;
      if (this.coordCount == -1)
        aiFront.Coords = new Coordinate[1];
      aiFront.Coords = new Coordinate[this.coordCount + 1];
      int coordCount = this.coordCount;
      for (int index = 0; index <= coordCount; ++index)
        aiFront.Coords[index] = this.Coords[index];
      aiFront.targetX = this.targetX;
      aiFront.targetY = this.targetY;
      aiFront.bridgeCount = this.bridgeCount;
      aiFront.vpScoreAveragePercent = this.vpScoreAveragePercent;
      aiFront.retreatAverageScore = this.retreatAverageScore;
      aiFront.ThreatPercentage = this.ThreatPercentage;
      aiFront.OpportunityPercentage = this.OpportunityPercentage;
      aiFront.tempEnemyRegime = this.tempEnemyRegime;
      aiFront.tempEnemyRegime2 = this.tempEnemyRegime2;
      aiFront.strengthModifier = this.strengthModifier;
      aiFront.receivedJoin = this.receivedJoin;
      return aiFront;
    }

    public AIFront()
    {
      this.Coords = new Coordinate[1];
      this.tempEnemyRegime = -1;
      this.tempEnemyRegime2 = -1;
      this.hasSupplySource = false;
      this.tempOrigAutomatonPower = 0;
      this.receivedJoin = 0;
      this.TargetFrontID = -1;
      this.units = new AIUnitList();
      this.artUnits = new AIUnitList();
      this.orgUnits = new AIUnitList();
      this.strictHQs = new AIUnitList();
      this.OffensiveZone = -1;
      this.OffensiveZone2 = -1;
      this.addedFictivePower = 0;
      this.DefensiveZone = -1;
      this.coordCount = -1;
      this.targetX = -1;
      this.enemyPower = 0;
      this.targetY = -1;
      this.temp1 = 0;
      this.bridgeCount = 0;
      this.vpScoreAveragePercent = 50;
      this.retreatAverageScore = 100;
      this.tempEnemyRegime = -1;
      this.tempEnemyRegime2 = -1;
      this.enemyAvgSupply = 0;
      this.strengthModifier = 100;
      this.receivedJoin = 0;
    }

    public SimpleList GetNeighbourFrontList()
    {
      SimpleList neighbourFrontList = new SimpleList();
      int mapWidth = this.ai.map.MapWidth;
      for (int cx = 0; cx <= mapWidth; ++cx)
      {
        int mapHeight = this.ai.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.ai.frontMatrix.Value[cx, cy] == this.FrontID)
          {
            int tfacing = 1;
            do
            {
              Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.ai.frontMatrix.Value[coordinate.x, coordinate.y] != this.FrontID & this.ai.frontMatrix.Value[coordinate.x, coordinate.y] > 0 && neighbourFrontList.FindNr(this.ai.frontMatrix.Value[coordinate.x, coordinate.y]) == -1)
                neighbourFrontList.Add(this.ai.frontMatrix.Value[coordinate.x, coordinate.y], 0);
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      return neighbourFrontList;
    }

    public bool HasFriendlyZeroBorder()
    {
      SimpleList simpleList = new SimpleList();
      int mapWidth = this.ai.map.MapWidth;
      for (int cx = 0; cx <= mapWidth; ++cx)
      {
        int mapHeight = this.ai.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.ai.frontMatrix.Value[cx, cy] == this.FrontID)
          {
            int tfacing = 1;
            do
            {
              Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.ai.frontMatrix.Value[coordinate.x, coordinate.y] == 0 && this.ai.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == this.ai.game.Data.Turn && this.ai.friendlySupplyMatrix.Value[coordinate.x, coordinate.y] < this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
                return true;
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      return false;
    }

    public void CopyUnitsFromAIFront(AIFront tempFront)
    {
      this.units = new AIUnitList();
      int counter1 = tempFront.units.counter;
      for (int index = 0; index <= counter1; ++index)
        this.units.add(tempFront.units.unr[index], tempFront.units.AIid[index]);
      int counter2 = tempFront.artUnits.counter;
      for (int index = 0; index <= counter2; ++index)
        this.artUnits.add(tempFront.artUnits.unr[index], tempFront.artUnits.AIid[index]);
      int counter3 = tempFront.orgUnits.counter;
      for (int index = 0; index <= counter3; ++index)
        this.orgUnits.add(tempFront.orgUnits.unr[index], tempFront.orgUnits.AIid[index]);
    }

    public AIFront(ref DC2AIClass tai, int tFrontType)
    {
      this.Coords = new Coordinate[1];
      this.tempEnemyRegime = -1;
      this.tempEnemyRegime2 = -1;
      this.hasSupplySource = false;
      this.tempOrigAutomatonPower = 0;
      this.receivedJoin = 0;
      this.units = new AIUnitList();
      this.artUnits = new AIUnitList();
      this.orgUnits = new AIUnitList();
      this.removelist = new AIUnitList();
      this.strictHQs = new AIUnitList();
      this.FrontType = tFrontType;
      this.ai = tai;
      this.TargetFrontID = -1;
      this.coordCount = -1;
      this.targetX = -1;
      this.targetY = -1;
      this.OffensiveZone = -1;
      this.OffensiveZone2 = -1;
      this.DefensiveZone = -1;
    }

    public void AddUnit(int unr) => this.units.add(unr, this.ai.game.Data.UnitObj[unr].AIid);

    public void AddCoord(int x, int y)
    {
      ++this.coordCount;
      this.Coords = (Coordinate[]) Utils.CopyArray((Array) this.Coords, (Array) new Coordinate[this.coordCount + 1]);
      this.Coords[this.coordCount].x = x;
      this.Coords[this.coordCount].y = y;
    }

    public bool HasCoord(int x, int y)
    {
      int coordCount = this.coordCount;
      for (int index = 0; index <= coordCount; ++index)
      {
        if (this.Coords[index].x == x & this.Coords[index].y == y)
          return true;
      }
      return false;
    }

    public void RemoveCoord(int x, int y)
    {
      int num1 = -1;
      int coordCount = this.coordCount;
      for (int index = 0; index <= coordCount; ++index)
      {
        if (this.Coords[index].x == x & this.Coords[index].y == y)
        {
          num1 = index;
          break;
        }
      }
      if (num1 <= -1)
        return;
      int num2 = num1;
      int num3 = this.coordCount - 1;
      for (int index = num2; index <= num3; ++index)
        this.Coords[index] = this.Coords[index + 1];
      --this.coordCount;
      this.Coords = (Coordinate[]) Utils.CopyArray((Array) this.Coords, (Array) new Coordinate[this.coordCount + 1]);
    }

    public void AddArtUnit(int unr) => this.artUnits.add(unr, this.ai.game.Data.UnitObj[unr].AIid);

    public void AddOrgUnit(int unr) => this.orgUnits.add(unr, this.ai.game.Data.UnitObj[unr].AIid);

    public void RemoveUnitAIid(int AIid) => this.units.removeAiId(AIid);

    public void RemoveArtUnitAIid(int AIid) => this.artUnits.removeAiId(AIid);

    public void RemoveOrgUnitAIid(int AIid) => this.orgUnits.removeAiId(AIid);

    public int GetPowerUnderCorps(int hq)
    {
      int powerUnderCorps = 0;
      int counter1 = this.units.counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.ai.game.Data.UnitObj[this.units.unr[index]].HQ == hq)
          powerUnderCorps += this.ai.game.Data.UnitObj[this.units.unr[index]].TempUnitPower;
      }
      int counter2 = this.artUnits.counter;
      for (int index = 0; index <= counter2; ++index)
      {
        if (this.ai.game.Data.UnitObj[this.artUnits.unr[index]].HQ == hq)
          powerUnderCorps += this.ai.game.Data.UnitObj[this.artUnits.unr[index]].TempUnitPower;
      }
      return powerUnderCorps;
    }

    public int GetPowerUnderFront(bool Absolute = false)
    {
      int powerUnderFront = 0;
      if (Absolute)
      {
        int counter1 = this.units.counter;
        for (int index = 0; index <= counter1; ++index)
          powerUnderFront += this.ai.game.Data.UnitObj[this.units.unr[index]].TempUnitPowerAbs;
        int counter2 = this.artUnits.counter;
        for (int index = 0; index <= counter2; ++index)
          powerUnderFront += this.ai.game.Data.UnitObj[this.artUnits.unr[index]].TempUnitPowerAbs;
      }
      else
      {
        int counter3 = this.units.counter;
        for (int index = 0; index <= counter3; ++index)
          powerUnderFront += this.ai.game.Data.UnitObj[this.units.unr[index]].TempUnitPower;
        int counter4 = this.artUnits.counter;
        for (int index = 0; index <= counter4; ++index)
          powerUnderFront += this.ai.game.Data.UnitObj[this.artUnits.unr[index]].TempUnitPower;
      }
      return powerUnderFront;
    }

    public int GetPowerUnderHis(int his)
    {
      int powerUnderHis = 0;
      int counter1 = this.units.counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.ai.game.Data.UnitObj[this.units.unr[index]].Historical == his)
          powerUnderHis = powerUnderHis + this.ai.game.Data.UnitObj[this.units.unr[index]].TempUnitPower + 1;
      }
      int counter2 = this.artUnits.counter;
      for (int index = 0; index <= counter2; ++index)
      {
        if (this.ai.game.Data.UnitObj[this.artUnits.unr[index]].Historical == his)
          powerUnderHis = powerUnderHis + this.ai.game.Data.UnitObj[this.artUnits.unr[index]].TempUnitPower + 1;
      }
      return powerUnderHis;
    }

    public int GetTransferableHisUnitsInUnitList()
    {
      int hisUnitsInUnitList = 0;
      int num1 = 0;
      if (DrawMod.TGame.Data.Product >= 6)
        num1 = -1;
      bool[] flagArray = new bool[this.units.counter + 1];
      int counter1 = this.units.counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        if (this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical > -1 & !flagArray[index1] && this.ai.game.Data.UnitObj[this.units.unr[index1]].TempCategory == 1 && this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical) > num1)
        {
          ++hisUnitsInUnitList;
          flagArray[index1] = true;
          int num2 = index1 + 1;
          int counter2 = this.units.counter;
          for (int index2 = num2; index2 <= counter2; ++index2)
          {
            if (this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical == this.ai.game.Data.UnitObj[this.units.unr[index2]].Historical)
              flagArray[index2] = true;
          }
        }
      }
      return hisUnitsInUnitList;
    }

    public bool HasTopUnits()
    {
      int counter = this.units.counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.ai.game.Data.UnitObj[this.units.unr[index]].TempTopUnit)
          return true;
      }
      return false;
    }

    public int GetUnitAIIDToSplitOff(
      AIMatrix frontMatrix,
      int targetFrontID,
      AIFront targetFront,
      bool GetPowerPts = false)
    {
      int id = -1;
      int num1 = 999999999;
      int num2 = 0;
      bool[] flagArray = new bool[this.units.counter + 1];
      int counter1 = this.units.counter;
      int num3;
      int num4;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.ai.game.Data.UnitObj[this.units.unr[index]].Historical > -1 & !flagArray[index])
        {
          bool flag = false;
          if (this.ai.VAR_USE_STRICT_HQFRONT)
          {
            int hq = this.ai.game.Data.UnitObj[this.units.unr[index]].HQ;
            if (hq > -1 && this.strictHQs.CheckIfPresentUnr(hq) & targetFront.strictHQs.CheckIfPresentUnr(hq))
              flag = true;
          }
          else
            flag = true;
          if (flag & this.ai.game.Data.UnitObj[this.units.unr[index]].TempCategory == 1 & !this.ai.game.Data.UnitObj[this.units.unr[index]].TempTopUnit && this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index]].Historical) > 0 && this.ai.game.Data.UnitObj[this.units.unr[index]].Historical != this.FrontID & !this.ai.game.Data.UnitObj[this.units.unr[index]].AIReserve)
          {
            if (this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index]].Historical) <= 1)
              ++num3;
            else
              ++num4;
          }
        }
      }
      int num5 = 1;
      do
      {
        int counter2 = this.units.counter;
        for (int index1 = 0; index1 <= counter2; ++index1)
        {
          if (this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical > -1 & !flagArray[index1])
          {
            bool flag = false;
            if (this.ai.VAR_USE_STRICT_HQFRONT)
            {
              int hq = this.ai.game.Data.UnitObj[this.units.unr[index1]].HQ;
              if (hq > -1 && this.strictHQs.CheckIfPresentUnr(hq) & targetFront.strictHQs.CheckIfPresentUnr(hq))
                flag = true;
            }
            else
              flag = true;
            int x = this.ai.game.Data.UnitObj[this.units.unr[index1]].X;
            int y = this.ai.game.Data.UnitObj[this.units.unr[index1]].Y;
            if (flag & (num5 == 2 | frontMatrix.Value[x, y] == targetFrontID | targetFrontID == -1) && this.ai.game.Data.UnitObj[this.units.unr[index1]].TempCategory == 1 & !this.ai.game.Data.UnitObj[this.units.unr[index1]].TempTopUnit && this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical) > 0 && this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical != this.FrontID & !this.ai.game.Data.UnitObj[this.units.unr[index1]].AIReserve)
            {
              ++num2;
              if (num3 >= num4 | num4 == 1)
              {
                if (this.units.AIid[index1] + 100000 * this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical) < num1)
                {
                  num1 = this.units.AIid[index1] + 1000000 * this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical);
                  id = this.units.AIid[index1];
                }
              }
              else if (this.units.AIid[index1] - 100 * this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical) < num1)
              {
                num1 = this.units.AIid[index1] - 100 * this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical);
                id = this.units.AIid[index1];
              }
              flagArray[index1] = true;
              int num6 = index1 + 1;
              int counter3 = this.units.counter;
              for (int index2 = num6; index2 <= counter3; ++index2)
              {
                if (this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical == this.ai.game.Data.UnitObj[this.units.unr[index2]].Historical)
                  flagArray[index2] = true;
              }
            }
          }
        }
        if (id <= -1)
          ++num5;
        else
          break;
      }
      while (num5 <= 2);
      if (!GetPowerPts)
        return id;
      if (id <= -1)
        return 0;
      int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(id);
      int unitCounter = this.ai.game.Data.UnitCounter;
      int unitAiidToSplitOff;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.ai.game.Data.UnitObj[index].Historical == this.ai.game.Data.UnitObj[unitByAiid].Historical)
          unitAiidToSplitOff += this.ai.game.Data.UnitObj[index].TempUnitPowerAbs;
      }
      return unitAiidToSplitOff;
    }

    public int GetUnitsInTargetFrontIDTerritory(AIMatrix frontMatrix, int targetFrontID)
    {
      bool[] flagArray = new bool[this.units.counter + 1];
      int counter1 = this.units.counter;
      int frontIdTerritory;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        if (this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical > -1 & !flagArray[index1])
        {
          int x = this.ai.game.Data.UnitObj[this.units.unr[index1]].X;
          int y = this.ai.game.Data.UnitObj[this.units.unr[index1]].Y;
          if (frontMatrix.Value[x, y] == targetFrontID | targetFrontID == -1 && this.ai.game.Data.UnitObj[this.units.unr[index1]].TempCategory == 1 & !this.ai.game.Data.UnitObj[this.units.unr[index1]].TempTopUnit && this.ai.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical) > 0 && this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical != this.FrontID && !this.ai.game.Data.UnitObj[this.units.unr[index1]].AIReserve)
          {
            ++frontIdTerritory;
            flagArray[index1] = true;
            int num = index1 + 1;
            int counter2 = this.units.counter;
            for (int index2 = num; index2 <= counter2; ++index2)
            {
              if (this.ai.game.Data.UnitObj[this.units.unr[index1]].Historical == this.ai.game.Data.UnitObj[this.units.unr[index2]].Historical)
                flagArray[index2] = true;
            }
          }
        }
      }
      return frontIdTerritory;
    }

    public Coordinate GetAverageFrontCoordinate(int withZoneNumber = -1)
    {
      int num1 = 0;
      int num2;
      int num3;
      if (this.FrontType != 2)
      {
        int mapWidth = this.ai.map.MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.ai.map.MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            if (this.ai.frontMatrix.Value[index1, index2] == this.FrontID & (withZoneNumber == -1 | this.ai.VAR_MATRIX_ZONES.Value[index1, index2] == withZoneNumber))
            {
              ++num1;
              num2 += index1;
              num3 += index2;
            }
          }
        }
      }
      Coordinate averageFrontCoordinate = new Coordinate();
      if (num1 > 0)
      {
        averageFrontCoordinate.onmap = true;
        averageFrontCoordinate.x = (int) Math.Round((double) num2 / (double) num1);
        averageFrontCoordinate.y = (int) Math.Round((double) num3 / (double) num1);
      }
      else
      {
        int counter1 = this.units.counter;
        for (int index = 0; index <= counter1; ++index)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.units.AIid[index]);
          num2 += this.ai.game.Data.UnitObj[unitByAiid].X;
          num3 += this.ai.game.Data.UnitObj[unitByAiid].Y;
          ++num1;
        }
        int counter2 = this.artUnits.counter;
        for (int index = 0; index <= counter2; ++index)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.artUnits.AIid[index]);
          num2 += this.ai.game.Data.UnitObj[unitByAiid].X;
          num3 += this.ai.game.Data.UnitObj[unitByAiid].Y;
          ++num1;
        }
        int counter3 = this.orgUnits.counter;
        for (int index = 0; index <= counter3; ++index)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.orgUnits.AIid[index]);
          num2 += this.ai.game.Data.UnitObj[unitByAiid].X;
          num3 += this.ai.game.Data.UnitObj[unitByAiid].Y;
          ++num1;
        }
        if (num1 > 0)
        {
          averageFrontCoordinate.onmap = true;
          averageFrontCoordinate.x = (int) Math.Round((double) num2 / (double) num1);
          averageFrontCoordinate.y = (int) Math.Round((double) num3 / (double) num1);
        }
        else
          averageFrontCoordinate.onmap = false;
      }
      return averageFrontCoordinate;
    }

    public Coordinate GetAverageUnitsCoordinate(int hqNrNecc, int SSHQNrNecc)
    {
      int num1 = 0;
      Coordinate averageUnitsCoordinate = new Coordinate();
      int counter1 = this.units.counter;
      int num2;
      int num3;
      for (int index = 0; index <= counter1; ++index)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.units.AIid[index]);
        if (hqNrNecc < 0 | this.ai.game.Data.UnitObj[unitByAiid].HQ == hqNrNecc && SSHQNrNecc < 0 | this.ai.game.Data.UnitObj[unitByAiid].AISubStrictGroup == SSHQNrNecc)
        {
          num2 += this.ai.game.Data.UnitObj[unitByAiid].X;
          num3 += this.ai.game.Data.UnitObj[unitByAiid].Y;
          ++num1;
        }
      }
      int counter2 = this.artUnits.counter;
      for (int index = 0; index <= counter2; ++index)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.artUnits.AIid[index]);
        if (hqNrNecc < 0 | this.ai.game.Data.UnitObj[unitByAiid].HQ == hqNrNecc && SSHQNrNecc < 0 | this.ai.game.Data.UnitObj[unitByAiid].AISubStrictGroup == SSHQNrNecc)
        {
          num2 += this.ai.game.Data.UnitObj[unitByAiid].X;
          num3 += this.ai.game.Data.UnitObj[unitByAiid].Y;
          ++num1;
        }
      }
      int counter3 = this.orgUnits.counter;
      for (int index = 0; index <= counter3; ++index)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.orgUnits.AIid[index]);
        if (hqNrNecc < 0 | this.ai.game.Data.UnitObj[unitByAiid].HQ == hqNrNecc && SSHQNrNecc < 0 | this.ai.game.Data.UnitObj[unitByAiid].AISubStrictGroup == SSHQNrNecc)
        {
          num2 += this.ai.game.Data.UnitObj[unitByAiid].X;
          num3 += this.ai.game.Data.UnitObj[unitByAiid].Y;
          ++num1;
        }
      }
      if (num1 > 0)
      {
        averageUnitsCoordinate.onmap = true;
        averageUnitsCoordinate.x = (int) Math.Round((double) num2 / (double) num1);
        averageUnitsCoordinate.y = (int) Math.Round((double) num3 / (double) num1);
      }
      else
        averageUnitsCoordinate.onmap = false;
      return averageUnitsCoordinate;
    }
  }
}
