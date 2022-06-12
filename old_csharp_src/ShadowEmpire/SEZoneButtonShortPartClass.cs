// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEZoneButtonShortPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  public class SEZoneButtonShortPartClass : SubPartClass
  {
    private int iconSlotNr;
    private string dataString;
    private bool active;
    private int customIconBmpNr;

    public override void SubDispose()
    {
    }

    public SEZoneButtonShortPartClass(
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

    public override Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALL);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
      }
      if (this.active)
      {
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
      }
      if (this.customIconBmpNr > 0)
      {
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!this.active)
        {
          ref Graphics local5 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
          ref Bitmap local6 = ref bitmap;
          rectangle1 = new Rectangle(0, 0, 42, 32);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
        }
        if (this.active)
        {
          ref Graphics local7 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
          ref Bitmap local8 = ref bitmap;
          rectangle2 = new Rectangle(0, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
        }
      }
      else
      {
        Rectangle rectangle3;
        Rectangle rectangle4;
        if (!this.active)
        {
          ref Graphics local9 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local10 = ref bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
        }
        if (this.active)
        {
          ref Graphics local11 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local12 = ref bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
        }
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALL);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.Draw(ref local3, ref local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONSMALLHIGH);
        ref Bitmap local6 = ref bitmap;
        DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
      }
      if (this.customIconBmpNr > 0)
      {
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!this.active)
        {
          ref Graphics local7 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
          ref Bitmap local8 = ref bitmap;
          rectangle1 = new Rectangle(0, 0, 42, 32);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
        }
        if (this.active)
        {
          ref Graphics local9 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(this.customIconBmpNr);
          ref Bitmap local10 = ref bitmap;
          rectangle2 = new Rectangle(0, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
        }
      }
      else
      {
        Rectangle rectangle3;
        Rectangle rectangle4;
        if (!this.active)
        {
          ref Graphics local11 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local12 = ref bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
        }
        if (this.active)
        {
          ref Graphics local13 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local14 = ref bitmap;
          rectangle3 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
          Rectangle srcrect = rectangle3;
          rectangle4 = new Rectangle(0, 3, 48, 32);
          Rectangle destrect = rectangle4;
          DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
        }
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
