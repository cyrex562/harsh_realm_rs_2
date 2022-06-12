﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CoordList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  public class CoordList : ISerializable
  {
    public int counter;
    public Coordinate[] coord;
    public bool active;
    public int maxcounter;
    private bool noPresized;

    public CoordList()
    {
      this.coord = new Coordinate[1000];
      this.noPresized = false;
      this.counter = -1;
      this.active = false;
      this.maxcounter = 999;
    }

    public CoordList(int whatEverBigCounter9999)
    {
      this.coord = new Coordinate[1000];
      this.noPresized = false;
      this.counter = -1;
      this.active = false;
      this.coord = new Coordinate[whatEverBigCounter9999 + 1];
      this.maxcounter = whatEverBigCounter9999;
    }

    public CoordList(bool tnoPresized)
    {
      this.coord = new Coordinate[1000];
      this.noPresized = false;
      this.counter = -1;
      this.noPresized = tnoPresized;
      this.active = false;
      this.maxcounter = 0;
      this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[1]);
    }

    public void AddCoord(int x, int y, int map)
    {
      this.active = true;
      ++this.counter;
      if (this.counter >= this.maxcounter)
      {
        if (this.noPresized)
          this.maxcounter += 10;
        else
          this.maxcounter += 1000;
        this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[this.maxcounter + 1]);
      }
      this.coord[this.counter].x = x;
      this.coord[this.counter].y = y;
      this.coord[this.counter].map = map;
      this.coord[this.counter].onmap = true;
    }

    public void AddCoord(int x, int y, int map, int dat1, int dat2)
    {
      this.active = true;
      ++this.counter;
      if (this.counter > this.maxcounter)
      {
        if (this.noPresized)
          this.maxcounter += 10;
        else
          this.maxcounter += 1000;
        this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[this.maxcounter + 1]);
      }
      this.coord[this.counter].x = x;
      this.coord[this.counter].y = y;
      this.coord[this.counter].map = map;
      this.coord[this.counter].onmap = true;
      this.coord[this.counter].data1 = dat1;
      this.coord[this.counter].data2 = dat2;
    }

    public void AddList(ref CoordList listy)
    {
      int counter = listy.counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (!this.Exists(listy.coord[index].x, listy.coord[index].y, listy.coord[index].map))
          this.AddCoord(listy.coord[index].x, listy.coord[index].y, listy.coord[index].map);
      }
    }

    public void DeActivate() => this.active = false;

    public void RemoveCoord(int nr)
    {
      if (nr < this.counter)
      {
        int num1 = nr;
        int num2 = this.counter - 1;
        for (int index = num1; index <= num2; ++index)
          this.coord[index] = this.coord[index + 1];
      }
      --this.counter;
      if (this.counter < -1)
        this.counter = -1;
      this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[this.maxcounter + 1]);
    }

    public void RemoveCoordQuick(int nr)
    {
      if (nr < this.counter)
      {
        int num1 = nr;
        int num2 = this.counter - 1;
        for (int index = num1; index <= num2; ++index)
          this.coord[index] = this.coord[index + 1];
      }
      --this.counter;
    }

    public bool Exists(int x, int y, int map)
    {
      if (this.counter == -1)
        return false;
      int counter = this.counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.coord[index].x == x & this.coord[index].y == y & this.coord[index].map == map)
          return true;
      }
      return false;
    }

    public int FindSlot(int x, int y, int map)
    {
      if (this.counter == -1)
        return -1;
      int counter = this.counter;
      for (int slot = 0; slot <= counter; ++slot)
      {
        if (this.coord[slot].x == x & this.coord[slot].y == y & this.coord[slot].map == map)
          return slot;
      }
      return -1;
    }

    public int FindSlot(int x, int y, int map, int tdata1, int tdata2)
    {
      if (this.counter == -1)
        return -1;
      int counter = this.counter;
      for (int slot = 0; slot <= counter; ++slot)
      {
        if ((this.coord[slot].x == x | x == -1) & (this.coord[slot].y == y | y == -1) && this.coord[slot].data1 == tdata1 & this.coord[slot].data2 == tdata2)
          return slot;
      }
      return -1;
    }

    public CoordList Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (CoordList) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("counter", this.counter);
      if (this.counter <= -1)
        return;
      int[] numArray1 = new int[this.counter + 1];
      int[] numArray2 = new int[this.counter + 1];
      int[] numArray3 = new int[this.counter + 1];
      int counter = this.counter;
      for (int index = 0; index <= counter; ++index)
      {
        numArray1[index] = this.coord[index].x;
        numArray2[index] = this.coord[index].y;
        numArray3[index] = this.coord[index].map;
      }
      info.AddValue("t1", (object) numArray1);
      info.AddValue("t2", (object) numArray2);
      info.AddValue("t3", (object) numArray3);
    }

    protected CoordList(SerializationInfo info, StreamingContext context)
    {
      this.coord = new Coordinate[1000];
      this.noPresized = false;
      int int32 = info.GetInt32(nameof (counter));
      int[] numArray1 = new int[int32 + 1];
      int[] numArray2 = new int[int32 + 1];
      int[] numArray3 = new int[int32 + 1];
      if (int32 <= -1)
        return;
      int[] numArray4 = (int[]) info.GetValue("t1", numArray1.GetType());
      int[] numArray5 = (int[]) info.GetValue("t2", numArray2.GetType());
      int[] numArray6 = (int[]) info.GetValue("t3", numArray3.GetType());
      int num = int32;
      for (int index = 0; index <= num; ++index)
        this.AddCoord(numArray4[index], numArray5[index], numArray6[index]);
    }
  }
}
