// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SortListArray
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System.Collections;

namespace WindowsApplication1
{
  public class SortListArray : IComparer
  {
    private bool _Ascending;

    public SortListArray() => this._Ascending = true;

    public SortListArray(bool Ascending)
    {
      this._Ascending = true;
      this._Ascending = Ascending;
    }

    public int Compare(object x, object y) => this._Ascending ? new CaseInsensitiveComparer().Compare((object) ((ListItem) x).mRealName, (object) ((ListItem) y).mRealName) : new CaseInsensitiveComparer().Compare((object) y.ToString(), (object) x.ToString());
  }
}
