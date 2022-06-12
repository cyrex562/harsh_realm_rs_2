// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SFButtonPartClass : SubPartClass
  {
    public int OwnBitmapNr;
    private int colorized;
    private bool overrule;
    private int resizex;
    private int resizey;
    private int typ;
    private int regnr;
    private int extra;

    public SFButtonPartClass(int ttyp, int tregnr, int tResizeX, int tresizeY)
      : base(tResizeX, tresizeY)
    {
      this.overrule = false;
      this.resizex = tResizeX;
      this.typ = ttyp;
      this.extra = tregnr;
      this.regnr = DrawMod.TGame.Data.Turn;
      this.resizey = tresizeY;
    }

    public SFButtonPartClass(Bitmap tbmpnr, string tDescript = "")
      : base(tbmpnr.Width, tbmpnr.Height)
    {
      this.OwnBitmap = (Bitmap) tbmpnr.Clone();
      this.overrule = true;
      this.Descript = tDescript;
    }

    public override Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int picSpriteId = DrawMod.TGame.Data.SFTypeObj[this.typ].PicSpriteID;
      int sidewaysSpriteId = DrawMod.TGame.Data.SFTypeObj[this.typ].SidewaysSpriteID;
      int extraCounter = DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraCounter;
      for (int index = 0; index <= extraCounter; ++index)
      {
        if (DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraCode[index] == this.extra)
        {
          picSpriteId = DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraPicSpriteID[index];
          sidewaysSpriteId = DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraSidewaysSpriteID[index];
        }
      }
      int x1 = 0;
      int y1 = 0;
      int width1 = this.OwnBitmap.Width;
      int height = this.OwnBitmap.Height;
      int index1;
      int index2;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if ((double) DrawMod.TGame.Data.RuleVar[869] >= 1.0)
      {
        index1 = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[873]);
        index2 = 0;
        if ((double) DrawMod.TGame.Data.RuleVar[848] > 0.0 & DrawMod.TGame.Data.SFTypeObj[this.typ].Theater == 2)
        {
          index1 = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[848]);
          index2 = 0;
        }
        if ((double) DrawMod.TGame.Data.RuleVar[872] > 0.0 & DrawMod.TGame.Data.SFTypeObj[this.typ].Theater == 1)
        {
          index1 = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[872]);
          index2 = 0;
        }
        if ((double) DrawMod.TGame.Data.RuleVar[869] == 3.0)
        {
          int nr = DrawMod.TGame.Data.LandscapeTypeObj[index1].BasicPicID[index2];
          ref Graphics local1 = ref Expression;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(x1, y1, width1, height);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
        else
        {
          if ((double) DrawMod.TGame.Data.RuleVar[869] == 1.0)
          {
            int nr = DrawMod.TGame.Data.LandscapeTypeObj[index1].SidewaysSPriteID1[index2];
            ref Graphics local3 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(nr);
            ref Bitmap local4 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1, y1, width1, height);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
          }
          int nr1 = DrawMod.TGame.Data.LandscapeTypeObj[index1].SidewaysSPriteID2[index2];
          ref Graphics local5 = ref Expression;
          Bitmap bitmap1 = BitmapStore.GetBitmap(nr1);
          ref Bitmap local6 = ref bitmap1;
          rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr1));
          Rectangle srcrect1 = rectangle2;
          rectangle1 = new Rectangle(x1, y1, width1, height);
          Rectangle destrect1 = rectangle1;
          DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect1, destrect1);
        }
      }
      int index3 = this.regnr;
      if (index3 == -1)
      {
        if (DrawMod.TGame.Data.RegimeCounter == -1)
          return this.OwnBitmap;
        index3 = 0;
      }
      int red = DrawMod.TGame.Data.RegimeObj[index3].Red;
      int green = DrawMod.TGame.Data.RegimeObj[index3].Green;
      int blue = DrawMod.TGame.Data.RegimeObj[index3].Blue;
      switch (DrawMod.TGame.Data.SFTypeObj[this.typ].BaseColor)
      {
        case 0:
          ref Graphics local7 = ref Expression;
          Bitmap bitmap2 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local8 = ref bitmap2;
          int x2 = x1;
          int y2 = y1;
          int w1 = width1;
          int h1 = height;
          DrawMod.DrawScaled(ref local7, ref local8, x2, y2, w1, h1);
          break;
        case 1:
          ref Graphics local9 = ref Expression;
          Bitmap bitmap3 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local10 = ref bitmap3;
          int x3 = x1;
          int y3 = y1;
          int w2 = width1;
          int h2 = height;
          int width2 = BitmapStore.GetWidth(picSpriteId);
          int origh1 = BitmapStore.Getheight(picSpriteId);
          double r1 = (double) ((float) red / 256f);
          double g1 = (double) ((float) green / 256f);
          double b1 = (double) ((float) blue / 256f);
          DrawMod.DrawScaledColorized2(ref local9, ref local10, x3, y3, w2, h2, width2, origh1, (float) r1, (float) g1, (float) b1, 1f);
          break;
        case 2:
          int red2 = DrawMod.TGame.Data.RegimeObj[index3].Red2;
          int green2 = DrawMod.TGame.Data.RegimeObj[index3].Green2;
          int blue2 = DrawMod.TGame.Data.RegimeObj[index3].Blue2;
          ref Graphics local11 = ref Expression;
          Bitmap bitmap4 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local12 = ref bitmap4;
          int x4 = x1;
          int y4 = y1;
          int w3 = width1;
          int h3 = height;
          int width3 = BitmapStore.GetWidth(picSpriteId);
          int origh2 = BitmapStore.Getheight(picSpriteId);
          double r2 = (double) ((float) red2 / 256f);
          double g2 = (double) ((float) green2 / 256f);
          double b2 = (double) ((float) blue2 / 256f);
          DrawMod.DrawScaledColorized2(ref local11, ref local12, x4, y4, w3, h3, width3, origh2, (float) r2, (float) g2, (float) b2, 1f);
          break;
        case 3:
          int red3 = DrawMod.TGame.Data.RegimeObj[index3].Red3;
          int green3 = DrawMod.TGame.Data.RegimeObj[index3].Green3;
          int blue3 = DrawMod.TGame.Data.RegimeObj[index3].Blue3;
          ref Graphics local13 = ref Expression;
          Bitmap bitmap5 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local14 = ref bitmap5;
          int x5 = x1;
          int y5 = y1;
          int w4 = width1;
          int h4 = height;
          int width4 = BitmapStore.GetWidth(picSpriteId);
          int origh3 = BitmapStore.Getheight(picSpriteId);
          double r3 = (double) ((float) red3 / 256f);
          double g3 = (double) ((float) green3 / 256f);
          double b3 = (double) ((float) blue3 / 256f);
          DrawMod.DrawScaledColorized2(ref local13, ref local14, x5, y5, w4, h4, width4, origh3, (float) r3, (float) g3, (float) b3, 1f);
          break;
        case 4:
          int red4 = DrawMod.TGame.Data.RegimeObj[index3].Red4;
          int green4 = DrawMod.TGame.Data.RegimeObj[index3].Green4;
          int blue4 = DrawMod.TGame.Data.RegimeObj[index3].Blue4;
          ref Graphics local15 = ref Expression;
          Bitmap bitmap6 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local16 = ref bitmap6;
          int x6 = x1;
          int y6 = y1;
          int w5 = width1;
          int h5 = height;
          int width5 = BitmapStore.GetWidth(picSpriteId);
          int origh4 = BitmapStore.Getheight(picSpriteId);
          double r4 = (double) ((float) red4 / 256f);
          double g4 = (double) ((float) green4 / 256f);
          double b4 = (double) ((float) blue4 / 256f);
          DrawMod.DrawScaledColorized2(ref local15, ref local16, x6, y6, w5, h5, width5, origh4, (float) r4, (float) g4, (float) b4, 1f);
          break;
        case 5:
          ref Graphics local17 = ref Expression;
          Bitmap bitmap7 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local18 = ref bitmap7;
          int x7 = x1;
          int y7 = y1;
          int w6 = width1;
          int h6 = height;
          int width6 = BitmapStore.GetWidth(picSpriteId);
          int origh5 = BitmapStore.Getheight(picSpriteId);
          double r5 = (double) ((float) (red + 392) / 1024f);
          double g5 = (double) ((float) (green + 392) / 1024f);
          double b5 = (double) ((float) (blue + 392) / 1024f);
          DrawMod.DrawScaledColorized2(ref local17, ref local18, x7, y7, w6, h6, width6, origh5, (float) r5, (float) g5, (float) b5, 1f);
          break;
        case 6:
          ref Graphics local19 = ref Expression;
          Bitmap bitmap8 = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local20 = ref bitmap8;
          int x8 = x1;
          int y8 = y1;
          int w7 = width1;
          int h7 = height;
          int width7 = BitmapStore.GetWidth(picSpriteId);
          int origh6 = BitmapStore.Getheight(picSpriteId);
          double r6 = (double) ((float) (red + 80) / 512f);
          double g6 = (double) ((float) (green + 200) / 512f);
          double b6 = (double) ((float) (blue + 80) / 512f);
          DrawMod.DrawScaledColorized2(ref local19, ref local20, x8, y8, w7, h7, width7, origh6, (float) r6, (float) g6, (float) b6, 1f);
          break;
      }
      if ((double) DrawMod.TGame.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
      {
        ref Graphics local21 = ref Expression;
        Bitmap bitmap9 = BitmapStore.GetBitmap(sidewaysSpriteId);
        ref Bitmap local22 = ref bitmap9;
        int x9 = x1;
        int y9 = y1;
        int w8 = width1;
        int h8 = height;
        DrawMod.DrawScaled(ref local21, ref local22, x9, y9, w8, h8);
      }
      if ((double) DrawMod.TGame.Data.RuleVar[869] >= 1.0 & (double) DrawMod.TGame.Data.RuleVar[869] < 3.0)
      {
        int nr = DrawMod.TGame.Data.LandscapeTypeObj[index1].SidewaysSPriteID3[index2];
        ref Graphics local23 = ref Expression;
        Bitmap bitmap10 = BitmapStore.GetBitmap(nr);
        ref Bitmap local24 = ref bitmap10;
        rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(x1, y1, width1, height);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect, destrect);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay() => this.Paint();
  }
}
