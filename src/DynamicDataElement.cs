// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DynamicDataElement
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System.Drawing;

namespace WindowsApplication1
{
  public class DynamicDataElement
  {
    public DynamicType type;
    public string fontName;
    public int fontSize;
    public int fontStyle;
    public int lineHeight;
    public Color color;
    public int eventPicture;
    public int historicalUnitPortrait;
    public string texty;
    public string image;
    public int x;
    public int y;
    public int w;
    public int h;
    public int z;
    public int optionpp;
    public int optionevent;
    public string optiontitle;
    public string optiontext;
    public int[] optiontempvar;
    public bool[] optiontempvarOn;
    public bool center;

    public DynamicDataElement()
    {
      this.optiontempvar = new int[500];
      this.optiontempvarOn = new bool[500];
      this.color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }
  }
}
