// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GameClassSmall
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;

namespace WindowsApplication1
{
  public class GameClassSmall
  {
    public string AppPath;
    public DataClass Data;
    public HandyFunctionsclass HandyFunctionsObj;

    public GameClassSmall()
    {
      this.AppPath = AppDomain.CurrentDomain.BaseDirectory;
      this.HandyFunctionsObj = new HandyFunctionsclass((GameClass) null);
    }
  }
}
