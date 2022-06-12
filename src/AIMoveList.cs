// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIMoveList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class AIMoveList
  {
    public int Counter;
    public AIMove[] Move;
    public bool ArtPresent;
    public bool AirPresent;

    public AIMoveList()
    {
      this.Move = new AIMove[1];
      this.Counter = -1;
    }

    public AIMoveList Clone()
    {
      AIMoveList aiMoveList = new AIMoveList()
      {
        Counter = this.Counter
      };
      aiMoveList.Move = (AIMove[]) Utils.CopyArray((Array) aiMoveList.Move, (Array) new AIMove[this.Counter + 1]);
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
        aiMoveList.Move[index] = this.Move[index].Clone();
      return aiMoveList;
    }

    public void AddMove(ref AIMove tempMove)
    {
      ++this.Counter;
      this.Move = (AIMove[]) Utils.CopyArray((Array) this.Move, (Array) new AIMove[this.Counter + 1]);
      this.Move[this.Counter] = tempMove;
    }

    public bool UnrPresent(int unitAIid)
    {
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.Move[index].UnitAIid == unitAIid)
          return true;
      }
      return false;
    }
  }
}
