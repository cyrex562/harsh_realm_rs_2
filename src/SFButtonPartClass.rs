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
  pub class SFButtonPartClass : SubPartClass
  {
    pub OwnBitmapNr: i32;
     int colorized;
     bool overrule;
     int resizex;
     int resizey;
     int typ;
     int regnr;
     int extra;

    pub SFButtonPartClass(int ttyp, int tregnr, int tResizeX, int tresizeY)
      : base(tResizeX, tresizeY)
    {
      this.overrule = false;
      this.resizex = tResizeX;
      this.typ = ttyp;
      this.extra = tregnr;
      this.regnr = DrawMod.TGame.Data.Turn;
      this.resizey = tresizeY;
    }

    pub SFButtonPartClass(Bitmap tbmpnr, tDescript: String = "")
      : base(tbmpnr.Width, tbmpnr.Height)
    {
      this.OwnBitmap = (Bitmap) tbmpnr.Clone();
      this.overrule = true;
      this.Descript = tDescript;
    }

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      let mut picSpriteId: i32 = DrawMod.TGame.Data.SFTypeObj[this.typ].PicSpriteID;
      let mut sidewaysSpriteId: i32 = DrawMod.TGame.Data.SFTypeObj[this.typ].SidewaysSpriteID;
      let mut extraCounter: i32 = DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraCounter;
      for (let mut index: i32 = 0; index <= extraCounter; index += 1)
      {
        if (DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraCode[index] == this.extra)
        {
          picSpriteId = DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraPicSpriteID[index];
          sidewaysSpriteId = DrawMod.TGame.Data.SFTypeObj[this.typ].ExtraSidewaysSpriteID[index];
        }
      }
      let mut x1: i32 = 0;
      let mut y1: i32 = 0;
      let mut width1: i32 = this.OwnBitmap.Width;
      let mut height: i32 = this.OwnBitmap.Height;
      int index1;
      int index2;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if ((double) DrawMod.TGame.Data.RuleVar[869] >= 1.0)
      {
        index1 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[873]);
        index2 = 0;
        if ((double) DrawMod.TGame.Data.RuleVar[848] > 0.0 & DrawMod.TGame.Data.SFTypeObj[this.typ].Theater == 2)
        {
          index1 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[848]);
          index2 = 0;
        }
        if ((double) DrawMod.TGame.Data.RuleVar[872] > 0.0 & DrawMod.TGame.Data.SFTypeObj[this.typ].Theater == 1)
        {
          index1 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[872]);
          index2 = 0;
        }
        if ((double) DrawMod.TGame.Data.RuleVar[869] == 3.0)
        {
          let mut nr: i32 = DrawMod.TGame.Data.LandscapeTypeObj[index1].BasicPicID[index2];
           Graphics local1 =  Expression;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
           Bitmap local2 =  bitmap;
          rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(x1, y1, width1, height);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
        }
        else
        {
          if ((double) DrawMod.TGame.Data.RuleVar[869] == 1.0)
          {
            let mut nr: i32 = DrawMod.TGame.Data.LandscapeTypeObj[index1].SidewaysSPriteID1[index2];
             Graphics local3 =  Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(nr);
             Bitmap local4 =  bitmap;
            rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1, y1, width1, height);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local3,  local4, srcrect, destrect);
          }
          let mut nr1: i32 = DrawMod.TGame.Data.LandscapeTypeObj[index1].SidewaysSPriteID2[index2];
           Graphics local5 =  Expression;
          Bitmap bitmap1 = BitmapStore.GetBitmap(nr1);
           Bitmap local6 =  bitmap1;
          rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr1));
          Rectangle srcrect1 = rectangle2;
          rectangle1 = new Rectangle(x1, y1, width1, height);
          Rectangle destrect1 = rectangle1;
          DrawMod.DrawSimplePart2( local5,  local6, srcrect1, destrect1);
        }
      }
      let mut index3: i32 = this.regnr;
      if (index3 == -1)
      {
        if (DrawMod.TGame.Data.RegimeCounter == -1)
          return this.OwnBitmap;
        index3 = 0;
      }
      let mut red: i32 = DrawMod.TGame.Data.RegimeObj[index3].Red;
      let mut green: i32 = DrawMod.TGame.Data.RegimeObj[index3].Green;
      let mut blue: i32 = DrawMod.TGame.Data.RegimeObj[index3].Blue;
      switch (DrawMod.TGame.Data.SFTypeObj[this.typ].BaseColor)
      {
        case 0:
           Graphics local7 =  Expression;
          Bitmap bitmap2 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local8 =  bitmap2;
          let mut x2: i32 = x1;
          let mut y2: i32 = y1;
          let mut w1: i32 = width1;
          let mut h1: i32 = height;
          DrawMod.DrawScaled( local7,  local8, x2, y2, w1, h1);
          break;
        case 1:
           Graphics local9 =  Expression;
          Bitmap bitmap3 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local10 =  bitmap3;
          let mut x3: i32 = x1;
          let mut y3: i32 = y1;
          let mut w2: i32 = width1;
          let mut h2: i32 = height;
          let mut width2: i32 = BitmapStore.GetWidth(picSpriteId);
          let mut origh1: i32 = BitmapStore.Getheight(picSpriteId);
          double r1 = (double) ((float) red / 256f);
          double g1 = (double) ((float) green / 256f);
          double b1 = (double) ((float) blue / 256f);
          DrawMod.DrawScaledColorized2( local9,  local10, x3, y3, w2, h2, width2, origh1, (float) r1, (float) g1, (float) b1, 1f);
          break;
        case 2:
          let mut red2: i32 = DrawMod.TGame.Data.RegimeObj[index3].Red2;
          let mut green2: i32 = DrawMod.TGame.Data.RegimeObj[index3].Green2;
          let mut blue2: i32 = DrawMod.TGame.Data.RegimeObj[index3].Blue2;
           Graphics local11 =  Expression;
          Bitmap bitmap4 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local12 =  bitmap4;
          let mut x4: i32 = x1;
          let mut y4: i32 = y1;
          let mut w3: i32 = width1;
          let mut h3: i32 = height;
          let mut width3: i32 = BitmapStore.GetWidth(picSpriteId);
          let mut origh2: i32 = BitmapStore.Getheight(picSpriteId);
          double r2 = (double) ((float) red2 / 256f);
          double g2 = (double) ((float) green2 / 256f);
          double b2 = (double) ((float) blue2 / 256f);
          DrawMod.DrawScaledColorized2( local11,  local12, x4, y4, w3, h3, width3, origh2, (float) r2, (float) g2, (float) b2, 1f);
          break;
        case 3:
          let mut red3: i32 = DrawMod.TGame.Data.RegimeObj[index3].Red3;
          let mut green3: i32 = DrawMod.TGame.Data.RegimeObj[index3].Green3;
          let mut blue3: i32 = DrawMod.TGame.Data.RegimeObj[index3].Blue3;
           Graphics local13 =  Expression;
          Bitmap bitmap5 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local14 =  bitmap5;
          let mut x5: i32 = x1;
          let mut y5: i32 = y1;
          let mut w4: i32 = width1;
          let mut h4: i32 = height;
          let mut width4: i32 = BitmapStore.GetWidth(picSpriteId);
          let mut origh3: i32 = BitmapStore.Getheight(picSpriteId);
          double r3 = (double) ((float) red3 / 256f);
          double g3 = (double) ((float) green3 / 256f);
          double b3 = (double) ((float) blue3 / 256f);
          DrawMod.DrawScaledColorized2( local13,  local14, x5, y5, w4, h4, width4, origh3, (float) r3, (float) g3, (float) b3, 1f);
          break;
        case 4:
          let mut red4: i32 = DrawMod.TGame.Data.RegimeObj[index3].Red4;
          let mut green4: i32 = DrawMod.TGame.Data.RegimeObj[index3].Green4;
          let mut blue4: i32 = DrawMod.TGame.Data.RegimeObj[index3].Blue4;
           Graphics local15 =  Expression;
          Bitmap bitmap6 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local16 =  bitmap6;
          let mut x6: i32 = x1;
          let mut y6: i32 = y1;
          let mut w5: i32 = width1;
          let mut h5: i32 = height;
          let mut width5: i32 = BitmapStore.GetWidth(picSpriteId);
          let mut origh4: i32 = BitmapStore.Getheight(picSpriteId);
          double r4 = (double) ((float) red4 / 256f);
          double g4 = (double) ((float) green4 / 256f);
          double b4 = (double) ((float) blue4 / 256f);
          DrawMod.DrawScaledColorized2( local15,  local16, x6, y6, w5, h5, width5, origh4, (float) r4, (float) g4, (float) b4, 1f);
          break;
        case 5:
           Graphics local17 =  Expression;
          Bitmap bitmap7 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local18 =  bitmap7;
          let mut x7: i32 = x1;
          let mut y7: i32 = y1;
          let mut w6: i32 = width1;
          let mut h6: i32 = height;
          let mut width6: i32 = BitmapStore.GetWidth(picSpriteId);
          let mut origh5: i32 = BitmapStore.Getheight(picSpriteId);
          double r5 = (double) ((float) (red + 392) / 1024f);
          double g5 = (double) ((float) (green + 392) / 1024f);
          double b5 = (double) ((float) (blue + 392) / 1024f);
          DrawMod.DrawScaledColorized2( local17,  local18, x7, y7, w6, h6, width6, origh5, (float) r5, (float) g5, (float) b5, 1f);
          break;
        case 6:
           Graphics local19 =  Expression;
          Bitmap bitmap8 = BitmapStore.GetBitmap(picSpriteId);
           Bitmap local20 =  bitmap8;
          let mut x8: i32 = x1;
          let mut y8: i32 = y1;
          let mut w7: i32 = width1;
          let mut h7: i32 = height;
          let mut width7: i32 = BitmapStore.GetWidth(picSpriteId);
          let mut origh6: i32 = BitmapStore.Getheight(picSpriteId);
          double r6 = (double) ((float) (red + 80) / 512f);
          double g6 = (double) ((float) (green + 200) / 512f);
          double b6 = (double) ((float) (blue + 80) / 512f);
          DrawMod.DrawScaledColorized2( local19,  local20, x8, y8, w7, h7, width7, origh6, (float) r6, (float) g6, (float) b6, 1f);
          break;
      }
      if ((double) DrawMod.TGame.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
      {
         Graphics local21 =  Expression;
        Bitmap bitmap9 = BitmapStore.GetBitmap(sidewaysSpriteId);
         Bitmap local22 =  bitmap9;
        let mut x9: i32 = x1;
        let mut y9: i32 = y1;
        let mut w8: i32 = width1;
        let mut h8: i32 = height;
        DrawMod.DrawScaled( local21,  local22, x9, y9, w8, h8);
      }
      if ((double) DrawMod.TGame.Data.RuleVar[869] >= 1.0 & (double) DrawMod.TGame.Data.RuleVar[869] < 3.0)
      {
        let mut nr: i32 = DrawMod.TGame.Data.LandscapeTypeObj[index1].SidewaysSPriteID3[index2];
         Graphics local23 =  Expression;
        Bitmap bitmap10 = BitmapStore.GetBitmap(nr);
         Bitmap local24 =  bitmap10;
        rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(x1, y1, width1, height);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2( local23,  local24, srcrect, destrect);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay() => this.Paint();
  }
}
