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
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALL);
         let mut local2: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
      }
      if (this.active)
      {
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
         let mut local4: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local3,  local4, 0, 0);
      }
      if (this.customIconBmpNr > 0)
      {
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!this.active)
        {
           let mut local5: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           let mut local6: &Bitmap = &bitmap;
          rectangle1 = Rectangle::new(0, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle1
          rectangle2 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle2
          DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
        }
        if (this.active)
        {
           let mut local7: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           let mut local8: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(0, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
        }
      }
      else
      {
        Rectangle rectangle3;
        Rectangle rectangle4;
        if (!this.active)
        {
           let mut local9: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local10: &Bitmap = &bitmap;
          rectangle3 = Rectangle::new(this.iconSlotNr * 42, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle3
          rectangle4 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle4
          DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
        }
        if (this.active)
        {
           let mut local11: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local12: &Bitmap = &bitmap;
          rectangle3 = Rectangle::new(this.iconSlotNr * 42, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle3
          rectangle4 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle4
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
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALL);
         let mut local2: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
         let mut local4: &Bitmap = &bitmap;
        DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
         let mut local6: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local5,  local6, 0, 0);
      }
      if (this.customIconBmpNr > 0)
      {
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!this.active)
        {
           let mut local7: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           let mut local8: &Bitmap = &bitmap;
          rectangle1 = Rectangle::new(0, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle1
          rectangle2 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle2
          DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
        }
        if (this.active)
        {
           let mut local9: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
           let mut local10: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(0, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
        }
      }
      else
      {
        Rectangle rectangle3;
        Rectangle rectangle4;
        if (!this.active)
        {
           let mut local11: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local12: &Bitmap = &bitmap;
          rectangle3 = Rectangle::new(this.iconSlotNr * 42, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle3
          rectangle4 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle4
          DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
        }
        if (this.active)
        {
           let mut local13: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local14: &Bitmap = &bitmap;
          rectangle3 = Rectangle::new(this.iconSlotNr * 42, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle3
          rectangle4 = Rectangle::new(0, 3, 48, 32);
          let mut destrect: &Rectangle = &rectangle4
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
