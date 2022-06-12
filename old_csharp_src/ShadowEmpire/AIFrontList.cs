﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIFrontList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class AIFrontList
  {
    public int Counter;
    public AIFront[] Front;
    public DC2AIClass ai;
    private int idCounter;

    public AIFrontList(ref DC2AIClass tai)
    {
      this.Front = new AIFront[1];
      this.ai = tai;
      this.Counter = -1;
      this.idCounter = this.ai.game.Data.UnitCounter;
    }

    public int GetIdCounter()
    {
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.Front[index].FrontID > this.idCounter)
        {
          this.idCounter = this.Front[index].FrontID;
          if (this.idCounter > 20000 & this.idCounter < 30000)
            index = index;
        }
      }
      return this.idCounter;
    }

    public string GetString()
    {
      string str = "";
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.Front[index].FrontType == 1)
        {
          if (this.Front[index].StartStance == 3)
            str += "_A";
          if (this.Front[index].StartStance == 2)
            str += "_H";
          if (this.Front[index].StartStance == 1)
            str += "_R";
        }
      }
      return str;
    }

    public string GetStringFull()
    {
      string stringFull = "";
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.Front[index].FrontType == 1)
        {
          if (this.Front[index].StartStance == 3)
            stringFull += "_A";
          if (this.Front[index].StartStance == 2)
            stringFull += "_H";
          if (this.Front[index].StartStance == 1)
            stringFull += "_R";
        }
        else if (this.Front[index].FrontType == 2)
          stringFull = stringFull + "r" + this.Front[index].TargetFrontID.ToString();
      }
      return stringFull;
    }

    public AIFront AddFront(int tFrontType)
    {
      ++this.Counter;
      this.Front = (AIFront[]) Utils.CopyArray((Array) this.Front, (Array) new AIFront[this.Counter + 1]);
      this.Front[this.Counter] = new AIFront(ref this.ai, tFrontType);
      ++this.idCounter;
      this.Front[this.Counter].FrontType = tFrontType;
      this.Front[this.Counter].FrontID = this.idCounter;
      return this.Front[this.Counter];
    }

    public void AddFront(AIFront tFront, bool autoSetId)
    {
      ++this.Counter;
      this.Front = (AIFront[]) Utils.CopyArray((Array) this.Front, (Array) new AIFront[this.Counter + 1]);
      this.Front[this.Counter] = tFront;
      if (autoSetId)
        ++this.idCounter;
      if (!autoSetId)
        return;
      this.Front[this.Counter].FrontID = this.idCounter;
    }

    public void RemoveFront(int frontID)
    {
      int counter = this.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        if (this.Front[index1].FrontID == frontID)
        {
          int num1 = index1;
          int num2 = this.Counter - 1;
          for (int index2 = num1; index2 <= num2; ++index2)
            this.Front[index2] = this.Front[index2 + 1];
          --this.Counter;
          break;
        }
      }
    }

    public int GetPowerUnderFrontAndReservesAssignedToIt(int id)
    {
      int counter = this.Counter;
      int reservesAssignedToIt;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.Front[index].FrontID == id | this.Front[index].TargetFrontID == id)
          reservesAssignedToIt += this.Front[index].GetPowerUnderFront();
      }
      return reservesAssignedToIt;
    }

    public AIFront FindFront(int initialFrontID)
    {
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.Front[index].FrontID == initialFrontID)
          return this.Front[index];
      }
      return (AIFront) null;
    }

    public int GetFrontNr(int initialFrontID)
    {
      int counter = this.Counter;
      for (int frontNr = 0; frontNr <= counter; ++frontNr)
      {
        if (this.Front[frontNr].FrontID == initialFrontID)
          return frontNr;
      }
      return -1;
    }

    public void RemoveAllUnitsUnderCorpsFromFront(int hq, int fromFrontID, int toFrontID)
    {
      AIFront front1 = this.FindFront(fromFrontID);
      AIFront front2 = this.FindFront(toFrontID);
      for (int counter = front1.units.counter; counter >= 0; counter += -1)
      {
        if (this.ai.game.Data.UnitObj[front1.units.unr[counter]].AIGroup == fromFrontID && this.ai.game.Data.UnitObj[front1.units.unr[counter]].AIGroup == hq)
        {
          this.ai.game.Data.UnitObj[front1.units.unr[counter]].AIGroup = toFrontID;
          front2.AddUnit(front1.units.unr[counter]);
          front1.removelist.add(front1.units.unr[counter], front1.units.AIid[counter]);
          front1.RemoveUnitAIid(front1.units.AIid[counter]);
        }
      }
      for (int counter = front1.artUnits.counter; counter >= 0; counter += -1)
      {
        if (this.ai.game.Data.UnitObj[front1.artUnits.unr[counter]].AIGroup == fromFrontID && this.ai.game.Data.UnitObj[front1.artUnits.unr[counter]].AIGroup == hq)
        {
          this.ai.game.Data.UnitObj[front1.artUnits.unr[counter]].AIGroup = toFrontID;
          front2.AddArtUnit(front1.artUnits.unr[counter]);
          front1.removelist.add(front1.artUnits.unr[counter], front1.artUnits.AIid[counter]);
          front1.RemoveUnitAIid(front1.artUnits.AIid[counter]);
        }
      }
    }

    public string RemoveAllUnitsUnderHisFromFront(int his, int fromFrontID, int toFrontID)
    {
      string str = "REMOVE ALL UNITS UNDER HIS FROM FRONT " + fromFrontID.ToString() + " TO FRONT " + toFrontID.ToString();
      AIFront front1 = this.FindFront(fromFrontID);
      AIFront front2 = this.FindFront(toFrontID);
      for (int counter = front1.units.counter; counter >= 0; counter += -1)
      {
        if (this.ai.game.Data.UnitObj[front1.units.unr[counter]].AIGroup == fromFrontID && this.ai.game.Data.UnitObj[front1.units.unr[counter]].Historical == his)
        {
          this.ai.game.Data.UnitObj[front1.units.unr[counter]].AIGroup = toFrontID;
          str = str + "\r\n" + "(Norm)Unit: " + this.ai.game.Data.UnitObj[front1.units.unr[counter]].Name;
          front2.AddUnit(front1.units.unr[counter]);
          front1.removelist.add(front1.units.unr[counter], front1.units.AIid[counter]);
          front1.RemoveUnitAIid(front1.units.AIid[counter]);
        }
      }
      for (int counter = front1.artUnits.counter; counter >= 0; counter += -1)
      {
        if (this.ai.game.Data.UnitObj[front1.artUnits.unr[counter]].AIGroup == fromFrontID && this.ai.game.Data.UnitObj[front1.artUnits.unr[counter]].Historical == his)
        {
          this.ai.game.Data.UnitObj[front1.artUnits.unr[counter]].AIGroup = toFrontID;
          str = str + "\r\n" + "(Art)Unit: " + this.ai.game.Data.UnitObj[front1.units.unr[counter]].Name;
          front2.AddArtUnit(front1.artUnits.unr[counter]);
          front1.removelist.add(front1.artUnits.unr[counter], front1.artUnits.AIid[counter]);
          front1.RemoveArtUnitAIid(front1.artUnits.AIid[counter]);
        }
      }
      return str;
    }

    public AIFrontList Clone()
    {
      AIFrontList aiFrontList = new AIFrontList(ref this.ai);
      aiFrontList.Counter = this.Counter;
      aiFrontList.idCounter = this.idCounter;
      aiFrontList.Front = new AIFront[this.Counter + 1];
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
        aiFrontList.Front[index] = this.Front[index].Clone();
      return aiFrontList;
    }

    public void CopyUnitsFromAIFrontList(ref AIFrontList tempList)
    {
      int counter1 = tempList.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int counter2 = this.Counter;
        for (int index2 = 0; index2 <= counter2; ++index2)
        {
          if (tempList.Front[index1].FrontID == this.Front[index2].FrontID)
            this.Front[index2].CopyUnitsFromAIFront(tempList.Front[index1]);
        }
      }
    }

    public void ResetStats()
    {
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        this.Front[index].StatIterationCount = 0;
        this.Front[index].StatLastPercentageOutOfSupply = 0;
        this.Front[index].StatAvgPercentageOutOfSupply = 0;
        this.Front[index].StatLastPowerPercentageFullRun = 100;
        this.Front[index].statLastPowerPercentageRun1 = 100;
        this.Front[index].statsHexLeftPercentage = 100;
      }
    }
  }
}