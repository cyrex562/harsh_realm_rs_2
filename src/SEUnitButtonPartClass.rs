// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEUnitButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SEUnitButtonPartClass : SubPartClass
  {
     int iconSlotNr;
     string dataString;
     string dataString2;
     string description;
     bool active;
     int overruleR;
     int overruleG;
     int overruleB;

    pub void SubDispose()
    {
    }

    pub SEUnitButtonPartClass(
      int tIconSlotNr,
      string tDataString,
      string tDataString2,
      string tDescript,
      bool tactive,
      let mut tOverruleR: i32 = -1,
      let mut tOverruleG: i32 = -1,
      let mut tOverruleB: i32 = -1)
      : base(44, 97)
    {
      this.iconSlotNr = tIconSlotNr;
      this.Descript = tDescript;
      this.dataString = tDataString;
      this.dataString2 = tDataString2;
      this.active = tactive;
      this.overruleG = tOverruleG;
      this.overruleB = tOverruleB;
      this.overruleR = tOverruleR;
    }

    pub Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5);
         Bitmap local2 =  bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
      }
      if (this.active)
      {
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5HIGH);
         Bitmap local4 =  bitmap;
        DrawMod.DrawSimple( local3,  local4, 0, 0);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local6 =  bitmap;
        rectangle1 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle2;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
      }
      if (this.active)
      {
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
      }
      if (this.overruleB > -1)
      {
        if (this.dataString2.Length > 0)
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
        else
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
      }
      else if (this.dataString2.Length > 0)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColWhite);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColWhite);
      }
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
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5);
         Bitmap local2 =  bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5HIGH);
         Bitmap local4 =  bitmap;
        DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5HIGH);
         Bitmap local6 =  bitmap;
        DrawMod.DrawSimple( local5,  local6, 0, 0);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local8 =  bitmap;
        rectangle1 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle2;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
      }
      if (this.active)
      {
         Graphics local9 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
      }
      if (this.overruleB > -1)
      {
        if (this.dataString2.Length > 0)
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
        else
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb( byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
      }
      else if (this.dataString2.Length > 0)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColWhite);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColWhite);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
