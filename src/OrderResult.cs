// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OrderResult
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

namespace WindowsApplication1
{
  public class OrderResult
  {
    public bool OK;
    public string ErrorString;
    public string InfoString;
    public int Data;
    public CoordList CList;
    public int BattleUnit;
    public int BattleX;
    public int BattleY;
    public int BattleMap;
    public bool BattleIntercept;

    public OrderResult()
    {
      this.BattleIntercept = false;
      this.CList = new CoordList();
      this.BattleUnit = -1;
      this.BattleX = -1;
      this.BattleY = -1;
      this.BattleIntercept = false;
    }
  }
}
