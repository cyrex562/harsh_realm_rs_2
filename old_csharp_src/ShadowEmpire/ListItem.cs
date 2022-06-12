// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ListItem
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{
  public class ListItem
  {
    private int mID;
    private string mName;
    private string mFile;
    public string mRealName;

    public ListItem(int ID, string Name, string tFile = "", string RealName = "")
    {
      this.mID = ID;
      this.mName = Name;
      this.mRealName = RealName;
      if (Operators.CompareString(RealName, "", false) == 0)
        this.mRealName = this.mName;
      this.mFile = tFile;
    }

    public ListItem()
    {
    }

    public int ID
    {
      get => this.mID;
      set => this.mID = value;
    }

    public string Name
    {
      get => this.mName;
      set => this.mName = value;
    }

    public string File
    {
      get => this.mFile;
      set => this.mFile = value;
    }

    public override string ToString() => this.mName;
  }
}
