// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RunningGameClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;

namespace WindowsApplication1
{
  public class RunningGameClass
  {
    public int gameInstanceID;
    public int pairedGameID;
    public string playerToUserName;
    public string Player1UserName;
    public string Player2UserName;
    public int TurnNo;
    public string GameName;
    public DateTime DateIssued;
    public DateTime lastUploaded;
    public bool GameOver;
    public float Player1Losses;
    public float Player2Losses;
    public int Viewed;
    public string ArmyName;
    public string AccepterArmyName;
    public string MiscData;
    public DateTime lastTurnUploaded;
    public int Resigned;
    public int Tournament;
    public int TimeLeftPlayer1;
    public int TimeLeftPlayer2;
    public int LosingSide;
  }
}
