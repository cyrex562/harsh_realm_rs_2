// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UDSElement
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System.Drawing;

namespace WindowsApplication1
{
  public class UDSElement
  {
    public UDSType type;
    public string fontName;
    public int fontSize;
    public int fontStyle;
    public int lineHeight;
    public Color color;
    public int eventPicture;
    public int bitmapSlot;
    public int historicalUnitPortrait;
    public string texty;
    public string image;
    public int group;
    public int x;
    public int y;
    public int w;
    public int h;
    public int z;
    public int ox;
    public int oy;
    public int oh;
    public int ow;
    public int optionpp;
    public int optionevent;
    public string optiontitle;
    public string optiontext;
    public int[] optiontempvar;
    public bool[] optiontempvarOn;
    public int eventNr;
    public int grayed;
    public string key;
    public string value;
    public string mouseOver;
    public bool flagged;
    public int smallgfx;
    public int minvalue;
    public int maxvalue;
    public string tempPicture;
    public int rotation;
    public int center;
    public int subtype;
    public int parentElement;
    public int childType;
    public int childData;
    public bool hidden;
    public int topRow;
    public int rowsPerPage;
    public int totalRows;
    public int customBitmapFunction;
    public int customBitmapFunction2;
    public int customBitmapFunction3;

    public UDSElement()
    {
      this.eventPicture = -1;
      this.bitmapSlot = -1;
      this.optiontempvar = new int[500];
      this.optiontempvarOn = new bool[500];
      this.color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.tempPicture = "";
      this.parentElement = -1;
      this.childType = -1;
    }
  }
}
