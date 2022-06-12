// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ComplexCoordList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class ComplexCoordList
  {
    public int counter;
    public Coordinate[] coord;
    public CoordList[] coordList;
    public int maxcounter;

    public ComplexCoordList()
    {
      this.coord = new Coordinate[50];
      this.coordList = new CoordList[50];
      this.counter = -1;
      this.maxcounter = 49;
    }

    public void AddCoord(int x, int y, int map, CoordList tCoordList)
    {
      ++this.counter;
      if (this.counter > this.maxcounter)
      {
        this.maxcounter += 49;
        this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[this.maxcounter + 1]);
        this.coordList = (CoordList[]) Utils.CopyArray((Array) this.coordList, (Array) new CoordList[this.maxcounter + 1]);
      }
      this.coord[this.counter].x = x;
      this.coord[this.counter].y = y;
      this.coord[this.counter].map = map;
      this.coord[this.counter].onmap = true;
      this.coordList[this.counter] = tCoordList;
    }

    public void AddCoord(int x, int y, int map, int dat1, int dat2, CoordList tCoordList)
    {
      if (DrawMod.TGame.Data.Product > 6 && this.FindSlot(x, y, map) > -1)
        return;
      ++this.counter;
      if (this.counter > this.maxcounter)
      {
        this.maxcounter += 49;
        this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[this.maxcounter + 1]);
        this.coordList = (CoordList[]) Utils.CopyArray((Array) this.coordList, (Array) new CoordList[this.maxcounter + 1]);
      }
      this.coord[this.counter].x = x;
      this.coord[this.counter].y = y;
      this.coord[this.counter].map = map;
      this.coord[this.counter].onmap = true;
      this.coord[this.counter].data1 = dat1;
      this.coord[this.counter].data2 = dat2;
      this.coordList[this.counter] = tCoordList;
    }

    public void RemoveCoord(int nr)
    {
      if (nr < this.counter)
      {
        int num1 = nr;
        int num2 = this.counter - 1;
        for (int index = num1; index <= num2; ++index)
        {
          this.coord[index] = this.coord[index + 1];
          this.coordList[index] = this.coordList[index + 1];
        }
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
  }
}
