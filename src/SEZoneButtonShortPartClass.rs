// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEZoneButtonShortPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SEZoneButtonShortPartClass : SubPartClass
  {
     int iconSlotNr;
     string dataString;
     bool active;
     int customIconBmpNr;

    pub void SubDispose()
    {
    }

    pub SEZoneButtonShortPartClass(
      int tIconSlotNr,
      int tCustomIconBitmapNr,
      string tDataString,
      string tDescript,
      bool tactive)
      : base(93, 40)
    {
      this.iconSlotNr = tIconSlotNr;
      this.Descript = tDescript;
      this.dataString = tDataString;
      this.active = tactive;
      this.customIconBmpNr = tCustomIconBitmapNr;
    }

    pub Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALL);
         Bitmap local2 =  bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
      }
      if (this.active)
      {
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
         Bitmap local4 =  bitmap;
        DrawMod.DrawSimple( local3,  local4, 0, 0);
      }
      if (this.customIconBmpNr > 0)
      {
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!this.active)
        {
           Graphics local5 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           Bitmap local6 =  bitmap;
          rectangle1 = new Rectangle(0, 0, 42, 32);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
        }
        if (this.active)
        {
           Graphics local7 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           Bitmap local8 =  bitmap;
          rectangle2 = new Rectangle(0, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
        }
      }
      else
      {
        Rectangle rectangle3;
        Rectangle rectangle4;
        if (!this.active)
        {
           Graphics local9 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local10 =  bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
        }
        if (this.active)
        {
           Graphics local11 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local12 =  bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
        }
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALL);
         Bitmap local2 =  bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
         Bitmap local4 =  bitmap;
        DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
         Bitmap local6 =  bitmap;
        DrawMod.DrawSimple( local5,  local6, 0, 0);
      }
      if (this.customIconBmpNr > 0)
      {
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!this.active)
        {
           Graphics local7 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           Bitmap local8 =  bitmap;
          rectangle1 = new Rectangle(0, 0, 42, 32);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
        }
        if (this.active)
        {
           Graphics local9 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           Bitmap local10 =  bitmap;
          rectangle2 = new Rectangle(0, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
        }
      }
      else
      {
        Rectangle rectangle3;
        Rectangle rectangle4;
        if (!this.active)
        {
           Graphics local11 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local12 =  bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
        }
        if (this.active)
        {
           Graphics local13 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local14 =  bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2( local13,  local14, srcrect, destrect);
        }
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
