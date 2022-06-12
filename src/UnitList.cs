// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UnitList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class UnitList
  {
    public int counter;
    public int[] unr;
    public int[] data;
    public int[] data2;
    public int[] data3;
    public int maxcounter;

    public UnitList()
    {
      this.unr = new int[21];
      this.data = new int[21];
      this.data2 = new int[21];
      this.data3 = new int[21];
      this.counter = -1;
      this.maxcounter = 20;
    }

    public void add(int tunr, int tdata = -1, int tdata2 = -1, int tdata3 = -1)
    {
      ++this.counter;
      if (this.counter > this.maxcounter)
      {
        this.maxcounter += 40;
        this.unr = (int[]) Utils.CopyArray((Array) this.unr, (Array) new int[this.maxcounter + 1]);
        this.data = (int[]) Utils.CopyArray((Array) this.data, (Array) new int[this.maxcounter + 1]);
        this.data2 = (int[]) Utils.CopyArray((Array) this.data2, (Array) new int[this.maxcounter + 1]);
        this.data3 = (int[]) Utils.CopyArray((Array) this.data3, (Array) new int[this.maxcounter + 1]);
      }
      this.unr[this.counter] = tunr;
      this.data[this.counter] = tdata;
      this.data2[this.counter] = tdata2;
      this.data3[this.counter] = tdata3;
    }

    public void SortOnData()
    {
      if (this.counter < 1)
        return;
      int num1 = this.counter - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = 0;
        int num3 = this.counter - 1;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          if (this.data[index2] > this.data[index2 + 1])
          {
            num2 = 1;
            int num4 = this.unr[index2 + 1];
            int num5 = this.data[index2 + 1];
            int num6 = this.data2[index2 + 1];
            int num7 = this.data3[index2 + 1];
            this.unr[index2 + 1] = this.unr[index2];
            this.data[index2 + 1] = this.data[index2];
            this.data2[index2 + 1] = this.data2[index2];
            this.data3[index2 + 1] = this.data3[index2];
            this.unr[index2] = num4;
            this.data[index2] = num5;
            this.data2[index2] = num6;
            this.data3[index2] = num7;
          }
        }
        if (num2 == 0)
          break;
      }
    }

    public void remove(int tunr)
    {
      if (this.counter <= -1)
        return;
      int num1 = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.unr[index] == tunr)
          num1 = index;
      }
      if (num1 > -1 && num1 < this.counter)
      {
        int num2 = num1;
        int num3 = this.counter - 1;
        for (int index = num2; index <= num3; ++index)
        {
          this.unr[index] = this.unr[index + 1];
          this.data[index] = this.data[index + 1];
          this.data2[index] = this.data2[index + 1];
          this.data3[index] = this.data3[index + 1];
        }
      }
      --this.counter;
    }

    public bool CheckIfPresent(int tunr)
    {
      if (this.counter <= -1)
        return false;
      int num = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.unr[index] == tunr)
          num = index;
      }
      return num > -1;
    }
  }
}
