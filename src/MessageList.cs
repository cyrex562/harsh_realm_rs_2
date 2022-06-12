﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MessageList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class MessageList
  {
    public int counter;
    public string[] data;
    public int maxcounter;

    public MessageList()
    {
      this.data = new string[21];
      this.counter = -1;
      this.maxcounter = 20;
    }

    public void add(string tdata)
    {
      ++this.counter;
      if (this.counter > this.maxcounter)
      {
        this.maxcounter += 40;
        this.data = (string[]) Utils.CopyArray((Array) this.data, (Array) new string[this.maxcounter + 1]);
      }
      this.data[this.counter] = tdata;
    }

    public void removetop()
    {
      if (this.counter <= -1)
        return;
      int num1 = 0;
      if (num1 > -1 && num1 < this.counter)
      {
        int num2 = num1;
        int num3 = this.counter - 1;
        for (int index = num2; index <= num3; ++index)
          this.data[index] = this.data[index + 1];
      }
      --this.counter;
    }
  }
}
