// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEBigTextPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SEBigTextPartClass : SubPartClass
  {
    private string description;
    private bool active;
    private string texty;
    private int tw;
    private int th;

    public SEBigTextPartClass(
      string tTexty,
      string tDescript,
      bool tactive,
      int twidth,
      int theight)
      : base(twidth, theight)
    {
      this.Descript = tDescript;
      this.active = tactive;
      this.texty = tTexty;
      this.tw = twidth;
      this.th = theight;
    }

    public override Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
        ref Bitmap local2 = ref bitmap;
        rectangle1 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
        ref Bitmap local6 = ref bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      }
      if (this.active)
      {
        ref Graphics local7 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local8 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local12 = ref bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      if (this.texty.Length > 3)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
        ref Bitmap local2 = ref bitmap;
        rectangle1 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
        ref Bitmap local6 = ref bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local8 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2Coloured(ref local7, ref local8, srcrect4, destrect4, 1f, 1f, 1f, 0.2f);
        ref Graphics local9 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2Coloured(ref local9, ref local10, srcrect5, destrect5, 1f, 1f, 1f, 0.2f);
        ref Graphics local11 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local12 = ref bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2Coloured(ref local11, ref local12, srcrect6, destrect6, 1f, 1f, 1f, 0.2f);
      }
      if (this.active)
      {
        ref Graphics local13 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local14 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect7 = rectangle2;
        rectangle1 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect7 = rectangle1;
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        ref Graphics local15 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local16 = ref bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect8 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect8 = rectangle1;
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        ref Graphics local17 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
        ref Bitmap local18 = ref bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect9 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect9 = rectangle1;
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
      }
      if (this.texty.Length > 3)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont3, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0) + 1, (int) Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.texty, DrawMod.TGame.MarcFont1, (int) Math.Round((double) this.tw / 2.0), (int) Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
