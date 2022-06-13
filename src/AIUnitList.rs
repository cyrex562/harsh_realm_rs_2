// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIUnitList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  pub class AIUnitList
  {
    pub counter: i32;
    pub int[] unr;
    pub int[] AIid;
    pub int[] data;
    pub int[] data2;
    pub maxcounter: i32;

    pub AIUnitList()
    {
      this.unr = new int[21];
      this.AIid = new int[21];
      this.data = new int[21];
      this.data2 = new int[21];
      this.counter = -1;
      this.maxcounter = 20;
    }

    pub void add(int tunr, int tAIid, int tdata = -1, int tdata2 = -1)
    {
      this += 1.counter;
      if (this.counter > this.maxcounter)
      {
        this.maxcounter += 40;
        this.unr = (int[]) Utils.CopyArray((Array) this.unr, (Array) new int[this.maxcounter + 1]);
        this.AIid = (int[]) Utils.CopyArray((Array) this.AIid, (Array) new int[this.maxcounter + 1]);
        this.data = (int[]) Utils.CopyArray((Array) this.data, (Array) new int[this.maxcounter + 1]);
        this.data2 = (int[]) Utils.CopyArray((Array) this.data2, (Array) new int[this.maxcounter + 1]);
      }
      this.unr[this.counter] = tunr;
      this.AIid[this.counter] = tAIid;
      this.data[this.counter] = tdata;
      this.data2[this.counter] = tdata2;
    }

    pub void removeUnr(int tunr)
    {
      if (this.counter <= -1)
        return;
      int num1 = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.unr[index] == tunr)
          num1 = index;
      }
      if (num1 > -1 && num1 < this.counter)
      {
        int num2 = num1;
        int num3 = this.counter - 1;
        for (int index = num2; index <= num3; index += 1)
        {
          this.unr[index] = this.unr[index + 1];
          this.AIid[index] = this.AIid[index + 1];
          this.data[index] = this.data[index + 1];
          this.data2[index] = this.data2[index + 1];
        }
      }
      --this.counter;
    }

    pub void removeAiId(int tAIid)
    {
      if (this.counter <= -1)
        return;
      int num1 = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.AIid[index] == tAIid)
          num1 = index;
      }
      if (num1 > -1 && num1 < this.counter)
      {
        int num2 = num1;
        int num3 = this.counter - 1;
        for (int index = num2; index <= num3; index += 1)
        {
          this.unr[index] = this.unr[index + 1];
          this.AIid[index] = this.AIid[index + 1];
          this.data[index] = this.data[index + 1];
          this.data2[index] = this.data2[index + 1];
        }
      }
      --this.counter;
    }

    pub CheckIfPresentUnr: bool(int tunr)
    {
      if (this.counter <= -1)
        return false;
      int num = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.unr[index] == tunr)
          num = index;
      }
      return num > -1;
    }

    pub int FindUnrSlot(int tunr)
    {
      if (this.counter <= -1)
        return -1;
      int unrSlot = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.unr[index] == tunr)
          unrSlot = index;
      }
      return unrSlot;
    }

    pub int FindAiIDSlot(int tId)
    {
      if (this.counter <= -1)
        return -1;
      int aiIdSlot = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.AIid[index] == tId)
          aiIdSlot = index;
      }
      return aiIdSlot;
    }

    pub CheckIfPresentUnr: bool(int tunr, int taid)
    {
      if (this.counter <= -1)
        return false;
      int num = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.unr[index] == tunr & this.AIid[index] == taid)
          num = index;
      }
      return num > -1;
    }

    pub int CheckData2(int tunr, int taid)
    {
      if (this.counter <= -1)
        return -1;
      int index1 = -1;
      int counter = this.counter;
      for (int index2 = 0; index2 <= counter; index2 += 1)
      {
        if (this.unr[index2] == tunr & this.AIid[index2] == taid)
          index1 = index2;
      }
      return index1 > -1 ? this.data2[index1] : -1;
    }

    pub CheckIfPresentAIid: bool(int tAIid)
    {
      if (this.counter <= -1)
        return false;
      int num = -1;
      int counter = this.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.AIid[index] == tAIid)
          num = index;
      }
      return num > -1;
    }
  }
}
