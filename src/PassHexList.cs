// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PassHexList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Threading;

namespace WindowsApplication1
{
  public class PassHexList
  {
    public int counter;
    public Coordinate[] coord;
    public int[] moveType;
    public int maxcounter;
    private bool blocked;

    public PassHexList()
    {
      this.coord = new Coordinate[100];
      this.moveType = new int[100];
      this.blocked = false;
      this.counter = -1;
      this.maxcounter = 99;
    }

    public void AddCoord(int x, int y, int tMoveType)
    {
      while (this.blocked)
        Thread.Sleep(1);
      this.blocked = true;
      ++this.counter;
      if (this.counter > this.maxcounter)
      {
        this.maxcounter += 100;
        this.coord = (Coordinate[]) Utils.CopyArray((Array) this.coord, (Array) new Coordinate[this.maxcounter + 1]);
        this.moveType = (int[]) Utils.CopyArray((Array) this.moveType, (Array) new int[this.maxcounter + 1]);
      }
      this.coord[this.counter].x = x;
      this.coord[this.counter].y = y;
      this.coord[this.counter].map = 0;
      this.coord[this.counter].onmap = true;
      this.moveType[this.counter] = tMoveType;
      this.blocked = false;
    }

    public bool Exists(int x, int y, int tMoveType)
    {
      while (this.blocked)
        Thread.Sleep(1);
      this.blocked = true;
      if (this.counter == -1)
      {
        this.blocked = false;
        return false;
      }
      int counter = this.counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.coord[index].x == x & this.coord[index].y == y & this.moveType[index] == tMoveType)
        {
          this.blocked = false;
          return true;
        }
      }
      this.blocked = false;
      return false;
    }
  }
}
