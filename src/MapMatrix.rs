// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MapMatrix
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{
  pub class MapMatrix
  {
    pub int[,] TempValue;

    pub MapMatrix(int x, int y)
    {
      this.TempValue = new int[1, 1];
      this.TempValue = new int[x + 1, y + 1];
      object Counter;
      object LoopForResult1;
      object CounterResult1;
      if (!ObjectFlowControl.ForLoopControl.ForLoopInitObj(Counter, (object) 0, (object) x, (object) 1,  LoopForResult1,  CounterResult1))
        return;
      do
      {
        object CounterResult2;
        object LoopForResult2;
        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult2, (object) 0, (object) y, (object) 1,  LoopForResult2,  CounterResult2))
        {
          do
          {
            this.TempValue[Conversions.ToInteger(CounterResult1), Conversions.ToInteger(CounterResult2)] = -1;
          }
          while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult2, LoopForResult2,  CounterResult2));
        }
      }
      while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult1, LoopForResult1,  CounterResult1));
    }
  }
}
