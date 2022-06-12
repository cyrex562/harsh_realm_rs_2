// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LocationClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.Serialization;

namespace WindowsApplication1
{
  [Serializable]
  public class LocationClass : ISerializable
  {
    public string Name;
    public int People;
    public int[] Production;
    public int[] ProdPercent;
    public int[] TempProdPredict;
    public int HQ;
    public int Type;
    public int X;
    public int Y;
    public int Map;
    public int ID;
    public int LocSlot;
    public int StructuralPts;
    public int[] ProdPointRemainder;
    public int[] Reorg;
    public ItemList items;
    public SimpleList tempReserveItems;
    public SimpleList tempRequestItems;
    public SimpleList tempHandledItems;
    public SimpleList tempLIS;
    public SimpleList tempLISfreeAP;
    public int LogCounter;
    public int[] LogType;
    public int[] LogData1;
    public int[] LogData2;
    public int[] LogData3;
    public int supply;
    public int fuel;
    public int supplyReq;
    public int supplyIn;
    public int fuelReq;
    public int fuelIn;
    public int supplyOutUnits;
    public int fuelOutUnits;
    public int supplyEvacuated;
    public int fuelEvacuated;
    public int supplyDestroyed;
    public int fuelDestroyed;
    public int supplyBaseMode;
    public int supplyBaseFixed;
    public int startTurnStructuralPts;
    public int supplyOutBases;
    public int fuelOutBases;
    public int supplyExcess;
    public int fuelExcess;
    public bool isAirfield;
    public int tempAirfieldLevel;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("People", this.People);
      info.AddValue("Production", (object) this.Production);
      info.AddValue("HQ", this.HQ);
      info.AddValue("Type", this.Type);
      info.AddValue("X", this.X);
      info.AddValue("Y", this.Y);
      info.AddValue("StructuralPts", this.StructuralPts);
      info.AddValue("ProdPointRemainder", (object) this.ProdPointRemainder);
      info.AddValue("ProdPercent", (object) this.ProdPercent);
      info.AddValue("Map", this.Map);
      info.AddValue("ID", this.ID);
      info.AddValue("items", (object) this.items);
      info.AddValue("LogCounter", this.LogCounter);
      info.AddValue("LogType", (object) this.LogType);
      info.AddValue("LogData1", (object) this.LogData1);
      info.AddValue("LogData2", (object) this.LogData2);
      info.AddValue("LogData3", (object) this.LogData3);
      info.AddValue("isAirfield", this.isAirfield);
      info.AddValue("supply", this.supply);
      info.AddValue("fuel", this.fuel);
      info.AddValue("supplyReq", this.supplyReq);
      info.AddValue("supplyIn", this.supplyIn);
      info.AddValue("fuelReq", this.fuelReq);
      info.AddValue("fuelIn", this.fuelIn);
      info.AddValue("supplyOutUnits", this.supplyOutUnits);
      info.AddValue("fuelOutUnits", this.fuelOutUnits);
      info.AddValue("supplyEvacuated", this.supplyEvacuated);
      info.AddValue("fuelEvacuated", this.fuelEvacuated);
      info.AddValue("supplyDestroyed", this.supplyDestroyed);
      info.AddValue("fuelDestroyed", this.fuelDestroyed);
      info.AddValue("supplyBaseMode", this.supplyBaseMode);
      info.AddValue("supplyBaseFixed", this.supplyBaseFixed);
      info.AddValue("startTurnStructuralPts", this.startTurnStructuralPts);
      info.AddValue("supplyOutBases", this.supplyOutBases);
      info.AddValue("fuelOutBases", this.fuelOutBases);
      info.AddValue("supplyExcess", this.supplyExcess);
      info.AddValue("fuelExcess", this.fuelExcess);
      info.AddValue("locSlot", this.LocSlot);
      info.AddValue("tempAirfieldLevel", this.tempAirfieldLevel);
    }

    protected LocationClass(SerializationInfo info, StreamingContext context)
    {
      this.Production = new int[4];
      this.ProdPercent = new int[4];
      this.TempProdPredict = new int[4];
      this.ProdPointRemainder = new int[4];
      this.Reorg = new int[4];
      this.LogType = new int[1];
      this.LogData1 = new int[1];
      this.LogData2 = new int[1];
      this.LogData3 = new int[1];
      this.Name = info.GetString(nameof (Name));
      this.People = info.GetInt32(nameof (People));
      this.HQ = info.GetInt32(nameof (HQ));
      this.Type = info.GetInt32(nameof (Type));
      this.X = info.GetInt32(nameof (X));
      this.Y = info.GetInt32(nameof (Y));
      this.StructuralPts = info.GetInt32(nameof (StructuralPts));
      this.Production = (int[]) info.GetValue(nameof (Production), this.Production.GetType());
      this.ProdPointRemainder = (int[]) info.GetValue(nameof (ProdPointRemainder), this.ProdPointRemainder.GetType());
      this.ProdPercent = (int[]) info.GetValue(nameof (ProdPercent), this.ProdPercent.GetType());
      if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.Map = info.GetInt32(nameof (Map));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Map = 0;
          ProjectData.ClearProjectError();
        }
      }
      else
        this.Map = info.GetInt32(nameof (Map));
      try
      {
        this.ID = info.GetInt32(nameof (ID));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      try
      {
        this.items = new ItemList();
        this.items = (ItemList) info.GetValue(nameof (items), this.items.GetType());
        if (Information.IsNothing((object) this.items))
          this.items = new ItemList();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.items = new ItemList();
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LogCounter = info.GetInt32(nameof (LogCounter));
        this.LogType = new int[this.LogCounter + 1];
        this.LogData1 = new int[this.LogCounter + 1];
        this.LogData2 = new int[this.LogCounter + 1];
        this.LogData3 = new int[this.LogCounter + 1];
        this.LogType = (int[]) info.GetValue(nameof (LogType), this.LogType.GetType());
        this.LogData1 = (int[]) info.GetValue(nameof (LogData1), this.LogData1.GetType());
        this.LogData2 = (int[]) info.GetValue(nameof (LogData2), this.LogData2.GetType());
        this.LogData3 = (int[]) info.GetValue(nameof (LogData3), this.LogData3.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LogCounter = -1;
        this.LogType = new int[1];
        this.LogData1 = new int[1];
        this.LogData2 = new int[1];
        this.LogData3 = new int[1];
        ProjectData.ClearProjectError();
      }
      try
      {
        this.isAirfield = info.GetBoolean(nameof (isAirfield));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.isAirfield = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.supply = info.GetInt32(nameof (supply));
        this.fuel = info.GetInt32(nameof (fuel));
        this.supplyReq = info.GetInt32(nameof (supplyReq));
        this.supplyIn = info.GetInt32(nameof (supplyIn));
        this.fuelReq = info.GetInt32(nameof (fuelReq));
        this.fuelIn = info.GetInt32(nameof (fuelIn));
        this.supplyOutUnits = info.GetInt32(nameof (supplyOutUnits));
        this.fuelOutUnits = info.GetInt32(nameof (fuelOutUnits));
        this.supplyEvacuated = info.GetInt32(nameof (supplyEvacuated));
        this.fuelEvacuated = info.GetInt32(nameof (fuelEvacuated));
        this.supplyDestroyed = info.GetInt32(nameof (supplyDestroyed));
        this.fuelDestroyed = info.GetInt32(nameof (fuelDestroyed));
        this.supplyBaseMode = info.GetInt32(nameof (supplyBaseMode));
        this.supplyBaseFixed = info.GetInt32(nameof (supplyBaseFixed));
        this.startTurnStructuralPts = info.GetInt32(nameof (startTurnStructuralPts));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.supply = 0;
        this.fuel = 0;
        this.supplyReq = 0;
        this.supplyIn = 0;
        this.fuelReq = 0;
        this.fuelIn = 0;
        this.supplyOutUnits = 0;
        this.fuelOutUnits = 0;
        this.supplyEvacuated = 0;
        this.fuelEvacuated = 0;
        this.supplyDestroyed = 0;
        this.fuelDestroyed = 0;
        this.supplyBaseMode = 0;
        this.supplyBaseFixed = 0;
        this.startTurnStructuralPts = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.supplyOutBases = info.GetInt32(nameof (supplyOutBases));
        this.fuelOutBases = info.GetInt32(nameof (fuelOutBases));
        this.supplyExcess = info.GetInt32(nameof (supplyExcess));
        this.fuelExcess = info.GetInt32(nameof (fuelExcess));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.supplyOutBases = 0;
        this.fuelOutBases = 0;
        this.supplyExcess = 0;
        this.fuelExcess = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LocSlot = info.GetInt32("locSlot");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LocSlot = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.tempAirfieldLevel = info.GetInt32(nameof (tempAirfieldLevel));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.tempAirfieldLevel = 0;
        ProjectData.ClearProjectError();
      }
    }

    public void AddLog(int type, int data1, int data2, int data3)
    {
      int num1 = -1;
      if (data3 > 100 & DrawMod.TGame.Data.Turn == 1)
        data3 = data3;
      int logCounter = this.LogCounter;
      for (int index = 0; index <= logCounter; ++index)
      {
        if (this.LogType[index] == type & this.LogData1[index] == data1 & this.LogData2[index] == data2)
        {
          num1 = index;
          break;
        }
      }
      if (num1 == -1)
      {
        ++this.LogCounter;
        this.LogType = (int[]) Utils.CopyArray((Array) this.LogType, (Array) new int[this.LogCounter + 1]);
        this.LogData1 = (int[]) Utils.CopyArray((Array) this.LogData1, (Array) new int[this.LogCounter + 1]);
        this.LogData2 = (int[]) Utils.CopyArray((Array) this.LogData2, (Array) new int[this.LogCounter + 1]);
        this.LogData3 = (int[]) Utils.CopyArray((Array) this.LogData3, (Array) new int[this.LogCounter + 1]);
        this.LogType[this.LogCounter] = type;
        this.LogData1[this.LogCounter] = data1;
        this.LogData2[this.LogCounter] = data2;
        this.LogData3[this.LogCounter] = data3;
      }
      else
      {
        int[] logData3 = this.LogData3;
        int[] numArray = logData3;
        int index1 = num1;
        int index2 = index1;
        int num2 = logData3[index1] + data3;
        numArray[index2] = num2;
      }
    }

    public void SetLog(int type, int data1, int data2, int data3)
    {
      int index1 = -1;
      int logCounter = this.LogCounter;
      for (int index2 = 0; index2 <= logCounter; ++index2)
      {
        if (this.LogType[index2] == type & this.LogData1[index2] == data1 & this.LogData2[index2] == data2)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
      {
        ++this.LogCounter;
        this.LogType = (int[]) Utils.CopyArray((Array) this.LogType, (Array) new int[this.LogCounter + 1]);
        this.LogData1 = (int[]) Utils.CopyArray((Array) this.LogData1, (Array) new int[this.LogCounter + 1]);
        this.LogData2 = (int[]) Utils.CopyArray((Array) this.LogData2, (Array) new int[this.LogCounter + 1]);
        this.LogData3 = (int[]) Utils.CopyArray((Array) this.LogData3, (Array) new int[this.LogCounter + 1]);
        this.LogType[this.LogCounter] = type;
        this.LogData1[this.LogCounter] = data1;
        this.LogData2[this.LogCounter] = data2;
        this.LogData3[this.LogCounter] = data3;
      }
      else
        this.LogData3[index1] = data3;
    }

    public void ClearLogs(bool useFromAndToo, int fromType, int untillType)
    {
      SimpleList simpleList = new SimpleList();
      if (DrawMod.TGame.Data.MapObj[0].HexObj[this.X, this.Y].Regime == 2)
      {
        int num = num;
      }
      if (useFromAndToo)
      {
        int logCounter = this.LogCounter;
        for (int index = 0; index <= logCounter; ++index)
        {
          if (this.LogType[index] >= fromType & this.LogType[index] <= untillType)
          {
            if (this.LogType[index] >= 800 & this.LogType[index] <= 899)
              simpleList.AddWeight(this.LogType[index] + 100, 1, this.LogData1[index], this.LogData2[index], this.LogData3[index], CheckExistence: false);
          }
          else
            simpleList.AddWeight(this.LogType[index], 1, this.LogData1[index], this.LogData2[index], this.LogData3[index], CheckExistence: false);
        }
      }
      this.LogCounter = -1;
      this.LogType = (int[]) Utils.CopyArray((Array) this.LogType, (Array) new int[1]);
      this.LogData1 = (int[]) Utils.CopyArray((Array) this.LogData1, (Array) new int[1]);
      this.LogData2 = (int[]) Utils.CopyArray((Array) this.LogData2, (Array) new int[1]);
      this.LogData3 = (int[]) Utils.CopyArray((Array) this.LogData3, (Array) new int[1]);
      if (!useFromAndToo || simpleList.Counter <= -1)
        return;
      int counter = simpleList.Counter;
      for (int index = 0; index <= counter; ++index)
        this.AddLog(simpleList.Id[index], simpleList.Data1[index], simpleList.Data2[index], simpleList.Data3[index]);
    }

    public LocationClass(int hardcoded)
    {
      this.Production = new int[4];
      this.ProdPercent = new int[4];
      this.TempProdPredict = new int[4];
      this.ProdPointRemainder = new int[4];
      this.Reorg = new int[4];
      this.LogType = new int[1];
      this.LogData1 = new int[1];
      this.LogData2 = new int[1];
      this.LogData3 = new int[1];
      this.Map = 0;
      this.supply = 0;
      this.fuel = 0;
      this.supplyReq = 0;
      this.supplyIn = 0;
      this.fuelReq = 0;
      this.LocSlot = 0;
      this.fuelIn = 0;
      this.supplyOutUnits = 0;
      this.fuelOutUnits = 0;
      this.supplyEvacuated = 0;
      this.fuelEvacuated = 0;
      this.supplyDestroyed = 0;
      this.fuelDestroyed = 0;
      this.supplyBaseMode = 0;
      this.supplyBaseFixed = 0;
      this.startTurnStructuralPts = 0;
      this.isAirfield = false;
      if (hardcoded == 0)
      {
        this.Name = "";
        this.People = -1;
        this.Production[0] = -1;
        this.Production[1] = -1;
        this.Production[2] = -1;
        this.Production[3] = -1;
        this.HQ = -1;
      }
      this.tempAirfieldLevel = 0;
    }

    public void Kill()
    {
    }

    public void LoadSprites()
    {
    }
  }
}
