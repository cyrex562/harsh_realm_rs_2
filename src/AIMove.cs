// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIMove
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

namespace WindowsApplication1
{
  public class AIMove
  {
    public int UnitAIid;
    public Coordinate MoveTo;
    public Coordinate finalTo;
    public Coordinate AttackOn;
    public int BridgeToo;
    public bool IsArt;
    public bool IsAir;
    public bool IsTransportAir;
    public int isMode;

    public AIMove() => this.BridgeToo = -1;

    public AIMove Clone() => new AIMove()
    {
      UnitAIid = this.UnitAIid,
      MoveTo = this.MoveTo,
      AttackOn = this.AttackOn,
      BridgeToo = this.BridgeToo,
      finalTo = this.finalTo
    };
  }
}
