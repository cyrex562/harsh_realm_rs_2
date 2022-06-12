// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Neighbours
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

namespace WindowsApplication1
{
  public class Neighbours
  {
    public int[] data;

    public Neighbours()
    {
      this.data = new int[6];
      int index = 0;
      do
      {
        this.data[index] = -1;
        ++index;
      }
      while (index <= 5);
    }
  }
}
