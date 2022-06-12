// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.WindowReturnClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class WindowReturnClass
  {
    public int Counter;
    public int[] CommandType;
    public int[] CommandData;
    public bool Flag;
    public bool Overlay;
    public bool NoMouseClickBelow;
    public bool alwaysExecuteWR;
    public bool allowOtherMouseOverWindow;

    public WindowReturnClass() => this.Counter = -1;

    public void AddCommand(int type, int data)
    {
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.CommandType[index] == type & this.CommandData[index] == data)
          return;
      }
      ++this.Counter;
      this.CommandType = (int[]) Utils.CopyArray((Array) this.CommandType, (Array) new int[this.Counter + 1]);
      this.CommandData = (int[]) Utils.CopyArray((Array) this.CommandData, (Array) new int[this.Counter + 1]);
      this.CommandType[this.Counter] = type;
      this.CommandData[this.Counter] = data;
    }

    public void SetFlag(bool t) => this.Flag = t;

    public void SetOverlay(bool t) => this.Overlay = t;
  }
}
