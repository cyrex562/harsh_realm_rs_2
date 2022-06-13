// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WindowsApplication1
{
  pub class TextButtonPartClass : SubPartClass
  {
     bool overrule;
     string buttext;
     int width;
     int height;
     Font ourfont;
     Font ourfont2;
     Bitmap backbitmap;
     bool inactive;
     bool red;
     bool tuseshadow;
     bool marcStyle;
     string extraS;
     bool udsButton;
     int udsButtonSubType;
     bool useOverruleCol;
     Color overruleCol;

    pub int Click(int x, int y, let mut b: i32 = 1)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav",  DrawMod.TGame.EditObj);
      int num;
      return num;
    }

    pub TextButtonPartClass(
      string buttontext,
      int twidth,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 = -1,
      let mut bby: i32 = -1,
      bool tinactive = false,
      bool tred = false,
      let mut theight: i32 = 35,
      let mut tfontsize: i32 = 13,
      Font usefont = null,
      bool useshadow = false,
      bool tMarcStyle = false,
      textras: String = "",
      Font tfont2 = null,
      bool tudsButton = false,
      let mut tudsButtonSubType: i32 = 0,
      let mut toverrulered: i32 = 0,
      let mut toverrulegreen: i32 = 0,
      let mut toverruleblue: i32 = 0)
      : base(twidth, theight)
    {
      if (tfontsize > -1)
        self.ourfont = Font::new(DrawMod.TGame.FontCol.Families[1], (float) tfontsize, FontStyle.Bold, GraphicsUnit.Pixel);
      self.udsButton = tudsButton;
      self.udsButtonSubType = tudsButtonSubType;
      self.overrule = false;
      self.Descript = tDescript;
      if (!Information.IsNothing((object) tBackbitmap))
      {
        self.backbitmap = new Bitmap(self.OwnBitmap.Width, self.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        self.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics Expression = Graphics.FromImage((Image) self.backbitmap);
        Expression.CompositingMode = CompositingMode.SourceCopy;
        Expression.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, self.OwnBitmap.Width, self.OwnBitmap.Height), new Rectangle(bbx, bby, self.OwnBitmap.Width, self.OwnBitmap.Height), GraphicsUnit.Pixel);
        Expression.CompositingMode = CompositingMode.SourceOver;
        if (!Information.IsNothing((object) Expression))
          Expression.Dispose();
      }
      self.buttext = buttontext;
      self.width = twidth;
      self.height = theight;
      self.inactive = tinactive;
      self.red = tred;
      self.extraS = textras;
      self.marcStyle = tMarcStyle;
      self.tuseshadow = useshadow;
      if (!Information.IsNothing((object) usefont))
        self.ourfont = usefont;
      if (!Information.IsNothing((object) tfont2))
        self.ourfont2 = tfont2;
      if (!(toverruleblue > 0 | toverrulegreen > 0 | toverrulered > 0))
        return;
      self.overruleCol = Color.FromArgb( byte.MaxValue, toverrulered, toverrulegreen, toverruleblue);
      self.useOverruleCol = true;
    }

    pub void SubDispose()
    {
      if (Information.IsNothing((object) self.backbitmap))
        return;
      self.backbitmap.Dispose();
      self.backbitmap = (Bitmap) null;
    }

    pub Bitmap Paint()
    {
      SizeF sizeF1 = SizeF::new();
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing((object) self.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( Expression,  self.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      if (self.udsButton)
      {
        if (self.udsButtonSubType == 3)
        {
          if (self.inactive)
          {
            DrawMod.DrawBlock( Expression, 4, 3, self.width - 12, self.height, 0, 0, 0, 96);
          }
          else
          {
            DrawMod.DrawBlock( Expression, 4, 3, self.width - 12, self.height, 0, 0, 0, 24);
            DrawMod.DrawRectangle( Expression, 4, 3, self.width - 12, self.height - 6, 0, 0, 0, 64, 4);
          }
        }
        else if (self.udsButtonSubType < 2 | self.udsButtonSubType == 4)
        {
          if (self.inactive)
          {
            DrawMod.DrawBlock( Expression, 4, 3, self.width - 12, self.height - 10, 0, 0, 0, 96);
          }
          else
          {
            DrawMod.DrawBlock( Expression, 4, 3, self.width - 12, self.height - 10, 0, 0, 0, 24);
            DrawMod.DrawRectangle( Expression, 4, 3, self.width - 12, self.height - 10, 0, 0, 0, 64, 4);
          }
        }
        else if (self.udsButtonSubType == 2)
        {
          if (self.height == 35)
          {
             Graphics local1 =  Expression;
            Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local2 =  bitmap1;
            Rectangle rectangle1 = new Rectangle(15, 0, 205, 35);
            Rectangle srcrect1 = rectangle1;
            Rectangle rectangle2 = new Rectangle(15, 0, self.width - 30, self.height);
            Rectangle destrect1 = rectangle2;
            DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
             Graphics local3 =  Expression;
            Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local4 =  bitmap2;
            rectangle2 = new Rectangle(0, 0, 15, 35);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(0, 0, 15, self.height);
            Rectangle destrect2 = rectangle1;
            DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
             Graphics local5 =  Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local6 =  bitmap3;
            rectangle2 = new Rectangle(220, 0, 15, 35);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(self.width - 15, 0, 15, self.height);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
          }
          else
          {
             Graphics local7 =  Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local8 =  bitmap4;
            Rectangle rectangle3 = new Rectangle(7, 5, 222, 22);
            Rectangle srcrect4 = rectangle3;
            Rectangle rectangle4 = new Rectangle(7, 5, self.width - 14, self.height - 8);
            Rectangle destrect4 = rectangle4;
            DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
             Graphics local9 =  Expression;
            Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local10 =  bitmap5;
            rectangle3 = new Rectangle(0, 5, 7, 22);
            Rectangle srcrect5 = rectangle3;
            rectangle4 = new Rectangle(0, 5, 7, self.height - 8);
            Rectangle destrect5 = rectangle4;
            DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
             Graphics local11 =  Expression;
            Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local12 =  bitmap6;
            rectangle3 = new Rectangle(224, 5, 12, 22);
            Rectangle srcrect6 = rectangle3;
            rectangle4 = new Rectangle(self.width - 12, 5, 12, self.height - 8);
            Rectangle destrect6 = rectangle4;
            DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
             Graphics local13 =  Expression;
            Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local14 =  bitmap7;
            rectangle3 = new Rectangle(7, 0, 222, 5);
            Rectangle srcrect7 = rectangle3;
            rectangle4 = new Rectangle(7, 0, self.width - 14, 5);
            Rectangle destrect7 = rectangle4;
            DrawMod.DrawSimplePart2( local13,  local14, srcrect7, destrect7);
             Graphics local15 =  Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local16 =  bitmap7;
            rectangle3 = new Rectangle(0, 0, 7, 5);
            Rectangle srcrect8 = rectangle3;
            rectangle4 = new Rectangle(0, 0, 7, 5);
            Rectangle destrect8 = rectangle4;
            DrawMod.DrawSimplePart2( local15,  local16, srcrect8, destrect8);
             Graphics local17 =  Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local18 =  bitmap7;
            rectangle3 = new Rectangle(224, 0, 12, 5);
            Rectangle srcrect9 = rectangle3;
            rectangle4 = new Rectangle(self.width - 12, 0, 12, 5);
            Rectangle destrect9 = rectangle4;
            DrawMod.DrawSimplePart2( local17,  local18, srcrect9, destrect9);
             Graphics local19 =  Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local20 =  bitmap7;
            rectangle3 = new Rectangle(7, 28, 222, 7);
            Rectangle srcrect10 = rectangle3;
            rectangle4 = new Rectangle(7, self.height - 4, self.width - 14, 4);
            Rectangle destrect10 = rectangle4;
            DrawMod.DrawSimplePart2( local19,  local20, srcrect10, destrect10);
             Graphics local21 =  Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local22 =  bitmap7;
            rectangle3 = new Rectangle(0, 28, 7, 7);
            Rectangle srcrect11 = rectangle3;
            rectangle4 = new Rectangle(0, self.height - 4, 7, 4);
            Rectangle destrect11 = rectangle4;
            DrawMod.DrawSimplePart2( local21,  local22, srcrect11, destrect11);
             Graphics local23 =  Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
             Bitmap local24 =  bitmap7;
            rectangle3 = new Rectangle(224, 28, 12, 7);
            Rectangle srcrect12 = rectangle3;
            rectangle4 = new Rectangle(self.width - 12, self.height - 4, 12, 4);
            Rectangle destrect12 = rectangle4;
            DrawMod.DrawSimplePart2( local23,  local24, srcrect12, destrect12);
          }
        }
      }
      else if (self.marcStyle)
      {
        if (self.width > 39 & DrawMod.TGame.Data.Product == 7)
        {
           Graphics local25 =  Expression;
          Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
           Bitmap local26 =  bitmap8;
          Rectangle rectangle5 = new Rectangle(14, 0, 197, 35);
          Rectangle srcrect13 = rectangle5;
          Rectangle rectangle6 = new Rectangle(14, 0, self.width - 28, self.height);
          Rectangle destrect13 = rectangle6;
          DrawMod.DrawSimplePart2( local25,  local26, srcrect13, destrect13);
           Graphics local27 =  Expression;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
           Bitmap local28 =  bitmap9;
          rectangle5 = new Rectangle(0, 0, 14, 35);
          Rectangle srcrect14 = rectangle5;
          rectangle6 = new Rectangle(0, 0, 14, self.height);
          Rectangle destrect14 = rectangle6;
          DrawMod.DrawSimplePart2( local27,  local28, srcrect14, destrect14);
           Graphics local29 =  Expression;
          Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
           Bitmap local30 =  bitmap10;
          rectangle5 = new Rectangle(211, 0, 24, 35);
          Rectangle srcrect15 = rectangle5;
          rectangle6 = new Rectangle(self.width - 24, 0, 24, self.height);
          Rectangle destrect15 = rectangle6;
          DrawMod.DrawSimplePart2( local29,  local30, srcrect15, destrect15);
        }
        else
        {
           Graphics local31 =  Expression;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           Bitmap local32 =  bitmap11;
          Rectangle rectangle7 = new Rectangle(7, 0, 7, 35);
          Rectangle srcrect16 = rectangle7;
          Rectangle rectangle8 = new Rectangle(7, 0, self.width - 14, self.height);
          Rectangle destrect16 = rectangle8;
          DrawMod.DrawSimplePart2( local31,  local32, srcrect16, destrect16);
           Graphics local33 =  Expression;
          Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           Bitmap local34 =  bitmap12;
          rectangle7 = new Rectangle(0, 0, 7, 35);
          Rectangle srcrect17 = rectangle7;
          rectangle8 = new Rectangle(0, 0, 7, self.height);
          Rectangle destrect17 = rectangle8;
          DrawMod.DrawSimplePart2( local33,  local34, srcrect17, destrect17);
           Graphics local35 =  Expression;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           Bitmap local36 =  bitmap13;
          rectangle7 = new Rectangle(29, 0, 7, 35);
          Rectangle srcrect18 = rectangle7;
          rectangle8 = new Rectangle(self.width - 7, 0, 7, self.height);
          Rectangle destrect18 = rectangle8;
          DrawMod.DrawSimplePart2( local35,  local36, srcrect18, destrect18);
        }
      }
      else if (self.width > 39)
      {
         Graphics local37 =  Expression;
        Bitmap bitmap14 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local38 =  bitmap14;
        Rectangle rectangle9 = new Rectangle(7, 5, 222, 22);
        Rectangle srcrect19 = rectangle9;
        Rectangle rectangle10 = new Rectangle(7, 5, self.width - 14, self.height - 8);
        Rectangle destrect19 = rectangle10;
        DrawMod.DrawSimplePart2( local37,  local38, srcrect19, destrect19);
         Graphics local39 =  Expression;
        Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local40 =  bitmap15;
        rectangle9 = new Rectangle(0, 5, 7, 22);
        Rectangle srcrect20 = rectangle9;
        rectangle10 = new Rectangle(0, 5, 7, self.height - 8);
        Rectangle destrect20 = rectangle10;
        DrawMod.DrawSimplePart2( local39,  local40, srcrect20, destrect20);
         Graphics local41 =  Expression;
        Bitmap bitmap16 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local42 =  bitmap16;
        rectangle9 = new Rectangle(224, 5, 12, 22);
        Rectangle srcrect21 = rectangle9;
        rectangle10 = new Rectangle(self.width - 12, 5, 12, self.height - 8);
        Rectangle destrect21 = rectangle10;
        DrawMod.DrawSimplePart2( local41,  local42, srcrect21, destrect21);
         Graphics local43 =  Expression;
        Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local44 =  bitmap17;
        rectangle9 = new Rectangle(7, 0, 222, 5);
        Rectangle srcrect22 = rectangle9;
        rectangle10 = new Rectangle(7, 0, self.width - 14, 5);
        Rectangle destrect22 = rectangle10;
        DrawMod.DrawSimplePart2( local43,  local44, srcrect22, destrect22);
         Graphics local45 =  Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local46 =  bitmap17;
        rectangle9 = new Rectangle(0, 0, 7, 5);
        Rectangle srcrect23 = rectangle9;
        rectangle10 = new Rectangle(0, 0, 7, 5);
        Rectangle destrect23 = rectangle10;
        DrawMod.DrawSimplePart2( local45,  local46, srcrect23, destrect23);
         Graphics local47 =  Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local48 =  bitmap17;
        rectangle9 = new Rectangle(224, 0, 12, 5);
        Rectangle srcrect24 = rectangle9;
        rectangle10 = new Rectangle(self.width - 12, 0, 12, 5);
        Rectangle destrect24 = rectangle10;
        DrawMod.DrawSimplePart2( local47,  local48, srcrect24, destrect24);
         Graphics local49 =  Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local50 =  bitmap17;
        rectangle9 = new Rectangle(7, 28, 222, 7);
        Rectangle srcrect25 = rectangle9;
        rectangle10 = new Rectangle(7, self.height - 4, self.width - 14, 4);
        Rectangle destrect25 = rectangle10;
        DrawMod.DrawSimplePart2( local49,  local50, srcrect25, destrect25);
         Graphics local51 =  Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local52 =  bitmap17;
        rectangle9 = new Rectangle(0, 28, 7, 7);
        Rectangle srcrect26 = rectangle9;
        rectangle10 = new Rectangle(0, self.height - 4, 7, 4);
        Rectangle destrect26 = rectangle10;
        DrawMod.DrawSimplePart2( local51,  local52, srcrect26, destrect26);
         Graphics local53 =  Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
         Bitmap local54 =  bitmap17;
        rectangle9 = new Rectangle(224, 28, 12, 7);
        Rectangle srcrect27 = rectangle9;
        rectangle10 = new Rectangle(self.width - 12, self.height - 4, 12, 4);
        Rectangle destrect27 = rectangle10;
        DrawMod.DrawSimplePart2( local53,  local54, srcrect27, destrect27);
      }
      else
      {
         Graphics local55 =  Expression;
        Bitmap bitmap18 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
         Bitmap local56 =  bitmap18;
        Rectangle rectangle11 = new Rectangle(7, 0, 7, 35);
        Rectangle srcrect28 = rectangle11;
        Rectangle rectangle12 = new Rectangle(7, 0, self.width - 14, self.height);
        Rectangle destrect28 = rectangle12;
        DrawMod.DrawSimplePart2( local55,  local56, srcrect28, destrect28);
         Graphics local57 =  Expression;
        Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
         Bitmap local58 =  bitmap19;
        rectangle11 = new Rectangle(0, 0, 7, 35);
        Rectangle srcrect29 = rectangle11;
        rectangle12 = new Rectangle(0, 0, 7, self.height);
        Rectangle destrect29 = rectangle12;
        DrawMod.DrawSimplePart2( local57,  local58, srcrect29, destrect29);
         Graphics local59 =  Expression;
        Bitmap bitmap20 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
         Bitmap local60 =  bitmap20;
        rectangle11 = new Rectangle(29, 0, 7, 35);
        Rectangle srcrect30 = rectangle11;
        rectangle12 = new Rectangle(self.width - 7, 0, 7, self.height);
        Rectangle destrect30 = rectangle12;
        DrawMod.DrawSimplePart2( local59,  local60, srcrect30, destrect30);
      }
      if (!self.udsButton)
      {
        if (self.inactive & !self.marcStyle)
          DrawMod.DrawBlock( Expression, 0, 0, self.width, self.height, 0, 0, 0, 128);
        else if (self.inactive & self.marcStyle)
        {
          if (DrawMod.TGame.Data.Product >= 6 & self.red)
            DrawMod.DrawBlockGradient2( Expression, -1, -1, self.width - 6,  Math.Round((double) self.height - (3.0 + (double) Math.Max(0, self.height - 40) / 7.0)), Color.FromArgb(64, 155, 25, 0), Color.FromArgb(164, 155, 25, 0));
          else
            DrawMod.DrawBlockGradient2( Expression, 2, 2, self.width - 6,  Math.Round((double) self.height - (3.0 + (double) Math.Max(0, self.height - 40) / 7.0)), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(196, 0, 0, 0));
        }
      }
      Color c = Color.White;
      if (DrawMod.TGame.Data.Product == 7 & self.inactive)
        c = Color.Gray;
      if (self.marcStyle & self.red)
        c = DrawMod.TGame.Data.Product != 7 ? Color.FromArgb( byte.MaxValue,  byte.MaxValue, 210, 210) : Color.FromArgb( byte.MaxValue,  byte.MaxValue, 60, 60);
      if (self.marcStyle & self.useOverruleCol)
        c = self.overruleCol;
      if (self.udsButton)
      {
        c = Color.Black;
        if (self.udsButtonSubType == 2)
          c = Color.White;
      }
      SizeF sizeF2;
      int num;
      int y1;
      if (self.udsButton)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) (self.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) (self.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        if (self.udsButtonSubType == 3)
          y1 += 2;
        if (self.inactive)
          c = Color.FromArgb( Math.Round((double) c.A / 2.0),  c.R,  c.G,  c.B);
        DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, num, y1, c);
      }
      else if (!self.marcStyle & !self.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) (self.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) (self.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        DrawMod.DrawTextVic3( Expression, self.buttext, self.ourfont, num, y1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor1Shade);
      }
      else if (self.extraS.Length > 0)
      {
        SizeF sizeF3 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x1: i32 =  Math.Round(2.0 + ((double) self.width - (double) sizeF3.Width) / 2.0);
        let mut y2: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF3.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, x1, y2, Color.FromArgb(200, 0, 0, 0));
        SizeF sizeF4 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x2: i32 =  Math.Round(((double) self.width - (double) sizeF4.Width) / 2.0);
        let mut y3: i32 =  Math.Round(((double) self.height - (double) sizeF4.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, x2, y3, c);
        SizeF sizeF5 = Expression.MeasureString(self.extraS, self.ourfont2);
        let mut x3: i32 =  Math.Round(2.0 + ((double) self.width - (double) sizeF5.Width) / 2.0);
        let mut y4: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF5.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredFuzzy( Expression, self.extraS, self.ourfont2, x3, y4, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(self.extraS, self.ourfont2);
        num =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredNicely( Expression, self.extraS, self.ourfont2, num, y1, c);
      }
      else if (self.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x: i32 =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        let mut y5: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, x, y5, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0 - 2.0);
        y1 =  Math.Round(0.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, num, y1, c);
      }
      else
      {
        SizeF sizeF6 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x4: i32 =  Math.Round(((double) self.width - (double) sizeF6.Width) / 2.0);
        let mut y6: i32 =  Math.Round(((double) self.height - (double) sizeF6.Height) / 2.0 - 1.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x4, y6, Color.Black);
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x5: i32 =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        let mut y7: i32 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0 + 1.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x5, y7, Color.Black);
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x6: i32 =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0 + 1.0);
        let mut y8: i32 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x6, y8, Color.Black);
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x7: i32 =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0 - 1.0);
        let mut y9: i32 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x7, y9, Color.Black);
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, num, y1, c);
      }
      if (!self.marcStyle && self.red)
      {
        if (self.height == 26)
          DrawMod.drawLine( Expression, num,  Math.Round((double) y1 + (double) sizeF2.Height - 1.0),  Math.Round((double) ((float) num + sizeF2.Width)),  Math.Round((double) y1 + (double) sizeF2.Height - 1.0),  DrawMod.TGame.viccolor7.R,  DrawMod.TGame.viccolor7.G,  DrawMod.TGame.viccolor7.B,  DrawMod.TGame.viccolor7.A);
        else
          DrawMod.drawLine( Expression, num,  Math.Round((double) y1 + (double) sizeF2.Height + 2.0),  Math.Round((double) ((float) num + sizeF2.Width)),  Math.Round((double) y1 + (double) sizeF2.Height + 2.0),  DrawMod.TGame.viccolor7.R,  DrawMod.TGame.viccolor7.G,  DrawMod.TGame.viccolor7.B,  DrawMod.TGame.viccolor7.A);
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return self.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      SizeF sizeF1 = SizeF::new();
      if (self.inactive)
        return self.Paint();
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing((object) self.backbitmap))
        DrawMod.DrawSimple( Expression,  self.backbitmap, 0, 0);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      if (self.udsButton)
      {
        if (self.udsButtonSubType == 3 | self.udsButtonSubType == 4)
        {
          DrawMod.DrawBlock( Expression, 3, 2, self.width - 12, self.height,  byte.MaxValue, 225, 225, 24);
          DrawMod.DrawRectangle( Expression, 3, 2, self.width - 12, self.height - 6, 0, 0, 0, 32, 4);
        }
        else if (self.udsButtonSubType < 2 | self.udsButtonSubType == 3)
        {
          DrawMod.DrawBlock( Expression, 3, 2, self.width - 12, self.height - 6,  byte.MaxValue, 225, 225, 24);
          DrawMod.DrawRectangle( Expression, 3, 2, self.width - 12, self.height - 6, 0, 0, 0, 32, 4);
        }
        else if (self.udsButtonSubType == 2)
        {
          if (self.height == 35)
          {
             Graphics local1 =  Expression;
            Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local2 =  bitmap1;
            Rectangle rectangle1 = new Rectangle(15, 0, 205, 35);
            Rectangle srcrect1 = rectangle1;
            Rectangle rectangle2 = new Rectangle(15, 0, self.width - 30, self.height);
            Rectangle destrect1 = rectangle2;
            DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
             Graphics local3 =  Expression;
            Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local4 =  bitmap2;
            rectangle2 = new Rectangle(0, 0, 15, 35);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(0, 0, 15, self.height);
            Rectangle destrect2 = rectangle1;
            DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
             Graphics local5 =  Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local6 =  bitmap3;
            rectangle2 = new Rectangle(220, 0, 15, 35);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(self.width - 15, 0, 15, self.height);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
          }
          else
          {
             Graphics local7 =  Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local8 =  bitmap4;
            Rectangle rectangle3 = new Rectangle(7, 5, 222, 22);
            Rectangle srcrect4 = rectangle3;
            Rectangle rectangle4 = new Rectangle(7, 5, self.width - 14, self.height - 8);
            Rectangle destrect4 = rectangle4;
            DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
             Graphics local9 =  Expression;
            Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local10 =  bitmap5;
            rectangle3 = new Rectangle(0, 5, 7, 22);
            Rectangle srcrect5 = rectangle3;
            rectangle4 = new Rectangle(0, 5, 7, self.height - 8);
            Rectangle destrect5 = rectangle4;
            DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
             Graphics local11 =  Expression;
            Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local12 =  bitmap6;
            rectangle3 = new Rectangle(224, 5, 12, 22);
            Rectangle srcrect6 = rectangle3;
            rectangle4 = new Rectangle(self.width - 12, 5, 12, self.height - 8);
            Rectangle destrect6 = rectangle4;
            DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
             Graphics local13 =  Expression;
            Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local14 =  bitmap7;
            rectangle3 = new Rectangle(7, 0, 222, 5);
            Rectangle srcrect7 = rectangle3;
            rectangle4 = new Rectangle(7, 0, self.width - 14, 5);
            Rectangle destrect7 = rectangle4;
            DrawMod.DrawSimplePart2( local13,  local14, srcrect7, destrect7);
             Graphics local15 =  Expression;
            Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local16 =  bitmap8;
            rectangle3 = new Rectangle(0, 0, 7, 5);
            Rectangle srcrect8 = rectangle3;
            rectangle4 = new Rectangle(0, 0, 7, 5);
            Rectangle destrect8 = rectangle4;
            DrawMod.DrawSimplePart2( local15,  local16, srcrect8, destrect8);
             Graphics local17 =  Expression;
            Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local18 =  bitmap9;
            rectangle3 = new Rectangle(224, 0, 12, 5);
            Rectangle srcrect9 = rectangle3;
            rectangle4 = new Rectangle(self.width - 12, 0, 12, 5);
            Rectangle destrect9 = rectangle4;
            DrawMod.DrawSimplePart2( local17,  local18, srcrect9, destrect9);
             Graphics local19 =  Expression;
            Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local20 =  bitmap10;
            rectangle3 = new Rectangle(7, 28, 222, 7);
            Rectangle srcrect10 = rectangle3;
            rectangle4 = new Rectangle(7, self.height - 4, self.width - 14, 4);
            Rectangle destrect10 = rectangle4;
            DrawMod.DrawSimplePart2( local19,  local20, srcrect10, destrect10);
             Graphics local21 =  Expression;
            Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local22 =  bitmap11;
            rectangle3 = new Rectangle(0, 28, 7, 7);
            Rectangle srcrect11 = rectangle3;
            rectangle4 = new Rectangle(0, self.height - 4, 7, 4);
            Rectangle destrect11 = rectangle4;
            DrawMod.DrawSimplePart2( local21,  local22, srcrect11, destrect11);
             Graphics local23 =  Expression;
            Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
             Bitmap local24 =  bitmap12;
            rectangle3 = new Rectangle(224, 28, 12, 7);
            Rectangle srcrect12 = rectangle3;
            rectangle4 = new Rectangle(self.width - 12, self.height - 4, 12, 4);
            Rectangle destrect12 = rectangle4;
            DrawMod.DrawSimplePart2( local23,  local24, srcrect12, destrect12);
          }
        }
      }
      else if (self.marcStyle)
      {
        if (self.width > 39 & DrawMod.TGame.Data.Product == 7)
        {
           Graphics local25 =  Expression;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
           Bitmap local26 =  bitmap13;
          Rectangle rectangle5 = new Rectangle(14, 0, 197, 35);
          Rectangle srcrect13 = rectangle5;
          Rectangle rectangle6 = new Rectangle(14, 0, self.width - 28, self.height);
          Rectangle destrect13 = rectangle6;
          DrawMod.DrawSimplePart2( local25,  local26, srcrect13, destrect13);
           Graphics local27 =  Expression;
          Bitmap bitmap14 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
           Bitmap local28 =  bitmap14;
          rectangle5 = new Rectangle(0, 0, 14, 35);
          Rectangle srcrect14 = rectangle5;
          rectangle6 = new Rectangle(0, 0, 14, self.height);
          Rectangle destrect14 = rectangle6;
          DrawMod.DrawSimplePart2( local27,  local28, srcrect14, destrect14);
           Graphics local29 =  Expression;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
           Bitmap local30 =  bitmap15;
          rectangle5 = new Rectangle(211, 0, 24, 35);
          Rectangle srcrect15 = rectangle5;
          rectangle6 = new Rectangle(self.width - 24, 0, 24, self.height);
          Rectangle destrect15 = rectangle6;
          DrawMod.DrawSimplePart2( local29,  local30, srcrect15, destrect15);
        }
        else
        {
           Graphics local31 =  Expression;
          Bitmap bitmap16 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           Bitmap local32 =  bitmap16;
          Rectangle rectangle7 = new Rectangle(7, 0, 7, 35);
          Rectangle srcrect16 = rectangle7;
          Rectangle rectangle8 = new Rectangle(7, 0, self.width - 14, self.height);
          Rectangle destrect16 = rectangle8;
          DrawMod.DrawSimplePart2( local31,  local32, srcrect16, destrect16);
           Graphics local33 =  Expression;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           Bitmap local34 =  bitmap17;
          rectangle7 = new Rectangle(0, 0, 7, 35);
          Rectangle srcrect17 = rectangle7;
          rectangle8 = new Rectangle(0, 0, 7, self.height);
          Rectangle destrect17 = rectangle8;
          DrawMod.DrawSimplePart2( local33,  local34, srcrect17, destrect17);
           Graphics local35 =  Expression;
          Bitmap bitmap18 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           Bitmap local36 =  bitmap18;
          rectangle7 = new Rectangle(29, 0, 7, 35);
          Rectangle srcrect18 = rectangle7;
          rectangle8 = new Rectangle(self.width - 7, 0, 7, self.height);
          Rectangle destrect18 = rectangle8;
          DrawMod.DrawSimplePart2( local35,  local36, srcrect18, destrect18);
        }
      }
      else if (self.width > 39)
      {
         Graphics local37 =  Expression;
        Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local38 =  bitmap19;
        Rectangle rectangle9 = new Rectangle(7, 5, 222, 22);
        Rectangle srcrect19 = rectangle9;
        Rectangle rectangle10 = new Rectangle(7, 5, self.width - 14, self.height - 8);
        Rectangle destrect19 = rectangle10;
        DrawMod.DrawSimplePart2( local37,  local38, srcrect19, destrect19);
         Graphics local39 =  Expression;
        Bitmap bitmap20 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local40 =  bitmap20;
        rectangle9 = new Rectangle(0, 5, 7, 22);
        Rectangle srcrect20 = rectangle9;
        rectangle10 = new Rectangle(0, 5, 7, self.height - 8);
        Rectangle destrect20 = rectangle10;
        DrawMod.DrawSimplePart2( local39,  local40, srcrect20, destrect20);
         Graphics local41 =  Expression;
        Bitmap bitmap21 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local42 =  bitmap21;
        rectangle9 = new Rectangle(224, 5, 12, 22);
        Rectangle srcrect21 = rectangle9;
        rectangle10 = new Rectangle(self.width - 12, 5, 12, self.height - 8);
        Rectangle destrect21 = rectangle10;
        DrawMod.DrawSimplePart2( local41,  local42, srcrect21, destrect21);
         Graphics local43 =  Expression;
        Bitmap bitmap22 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local44 =  bitmap22;
        rectangle9 = new Rectangle(7, 0, 222, 5);
        Rectangle srcrect22 = rectangle9;
        rectangle10 = new Rectangle(7, 0, self.width - 14, 5);
        Rectangle destrect22 = rectangle10;
        DrawMod.DrawSimplePart2( local43,  local44, srcrect22, destrect22);
         Graphics local45 =  Expression;
        Bitmap bitmap23 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local46 =  bitmap23;
        rectangle9 = new Rectangle(0, 0, 7, 5);
        Rectangle srcrect23 = rectangle9;
        rectangle10 = new Rectangle(0, 0, 7, 5);
        Rectangle destrect23 = rectangle10;
        DrawMod.DrawSimplePart2( local45,  local46, srcrect23, destrect23);
         Graphics local47 =  Expression;
        Bitmap bitmap24 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local48 =  bitmap24;
        rectangle9 = new Rectangle(224, 0, 12, 5);
        Rectangle srcrect24 = rectangle9;
        rectangle10 = new Rectangle(self.width - 12, 0, 12, 5);
        Rectangle destrect24 = rectangle10;
        DrawMod.DrawSimplePart2( local47,  local48, srcrect24, destrect24);
         Graphics local49 =  Expression;
        Bitmap bitmap25 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local50 =  bitmap25;
        rectangle9 = new Rectangle(7, 28, 222, 7);
        Rectangle srcrect25 = rectangle9;
        rectangle10 = new Rectangle(7, self.height - 4, self.width - 14, 4);
        Rectangle destrect25 = rectangle10;
        DrawMod.DrawSimplePart2( local49,  local50, srcrect25, destrect25);
         Graphics local51 =  Expression;
        Bitmap bitmap26 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local52 =  bitmap26;
        rectangle9 = new Rectangle(0, 28, 7, 7);
        Rectangle srcrect26 = rectangle9;
        rectangle10 = new Rectangle(0, self.height - 4, 7, 4);
        Rectangle destrect26 = rectangle10;
        DrawMod.DrawSimplePart2( local51,  local52, srcrect26, destrect26);
         Graphics local53 =  Expression;
        Bitmap bitmap27 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
         Bitmap local54 =  bitmap27;
        rectangle9 = new Rectangle(224, 28, 12, 7);
        Rectangle srcrect27 = rectangle9;
        rectangle10 = new Rectangle(self.width - 12, self.height - 4, 12, 4);
        Rectangle destrect27 = rectangle10;
        DrawMod.DrawSimplePart2( local53,  local54, srcrect27, destrect27);
      }
      else
      {
         Graphics local55 =  Expression;
        Bitmap bitmap28 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
         Bitmap local56 =  bitmap28;
        Rectangle rectangle11 = new Rectangle(7, 0, 7, 35);
        Rectangle srcrect28 = rectangle11;
        Rectangle rectangle12 = new Rectangle(7, 0, self.width - 14, self.height);
        Rectangle destrect28 = rectangle12;
        DrawMod.DrawSimplePart2( local55,  local56, srcrect28, destrect28);
         Graphics local57 =  Expression;
        Bitmap bitmap29 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
         Bitmap local58 =  bitmap29;
        rectangle11 = new Rectangle(0, 0, 7, 35);
        Rectangle srcrect29 = rectangle11;
        rectangle12 = new Rectangle(0, 0, 7, self.height);
        Rectangle destrect29 = rectangle12;
        DrawMod.DrawSimplePart2( local57,  local58, srcrect29, destrect29);
         Graphics local59 =  Expression;
        Bitmap bitmap30 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
         Bitmap local60 =  bitmap30;
        rectangle11 = new Rectangle(29, 0, 7, 35);
        Rectangle srcrect30 = rectangle11;
        rectangle12 = new Rectangle(self.width - 7, 0, 7, self.height);
        Rectangle destrect30 = rectangle12;
        DrawMod.DrawSimplePart2( local59,  local60, srcrect30, destrect30);
      }
      Color c = Color.White;
      if (self.marcStyle & self.red)
        c = DrawMod.TGame.Data.Product != 7 ? Color.FromArgb( byte.MaxValue,  byte.MaxValue, 210, 210) : Color.FromArgb( byte.MaxValue,  byte.MaxValue, 110, 110);
      if (self.marcStyle & self.useOverruleCol)
        c = self.overruleCol;
      if (self.udsButton)
        c = Color.Red;
      SizeF sizeF2;
      int num;
      int y1;
      if (self.udsButton)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) (self.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) (self.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        if (self.udsButtonSubType == 3)
          y1 += 2;
        DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, num, y1, c);
      }
      else if (!self.marcStyle & !self.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) (self.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) (self.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        DrawMod.DrawTextVic3( Expression, self.buttext, self.ourfont, num, y1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor1Shade);
      }
      else if (self.extraS.Length > 0)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x1: i32 =  Math.Round(2.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
        let mut y2: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF2.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, x1, y2, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x2: i32 =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        let mut y3: i32 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, x2, y3, Color.White);
        sizeF2 = Expression.MeasureString(self.extraS, self.ourfont2);
        let mut x3: i32 =  Math.Round(2.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
        let mut y4: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF2.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredFuzzy( Expression, self.extraS, self.ourfont2, x3, y4, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(self.extraS, self.ourfont2);
        num =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredNicely( Expression, self.extraS, self.ourfont2, num, y1, Color.White);
      }
      else if (self.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x: i32 =  Math.Round(0.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
        let mut y5: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, x, y5, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0 - 2.0);
        y1 =  Math.Round(0.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, num, y1, c);
      }
      else
      {
        SizeF sizeF3 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x4: i32 =  Math.Round(((double) self.width - (double) sizeF3.Width) / 2.0);
        let mut y6: i32 =  Math.Round(((double) self.height - (double) sizeF3.Height) / 2.0 - 1.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x4, y6, Color.Black);
        SizeF sizeF4 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x5: i32 =  Math.Round(((double) self.width - (double) sizeF4.Width) / 2.0);
        let mut y7: i32 =  Math.Round(((double) self.height - (double) sizeF4.Height) / 2.0 + 1.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x5, y7, Color.Black);
        SizeF sizeF5 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x6: i32 =  Math.Round(((double) self.width - (double) sizeF5.Width) / 2.0 + 1.0);
        let mut y8: i32 =  Math.Round(((double) self.height - (double) sizeF5.Height) / 2.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x6, y8, Color.Black);
        SizeF sizeF6 = Expression.MeasureString(self.buttext, self.ourfont);
        let mut x7: i32 =  Math.Round(((double) self.width - (double) sizeF6.Width) / 2.0 - 1.0);
        let mut y9: i32 =  Math.Round(((double) self.height - (double) sizeF6.Height) / 2.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, x7, y9, Color.Black);
        sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
        num =  Math.Round(((double) self.width - (double) sizeF2.Width) / 2.0);
        y1 =  Math.Round(((double) self.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured( Expression, self.buttext, self.ourfont, num, y1, c);
      }
      if (!self.marcStyle && self.red)
      {
        if (self.height == 26)
          DrawMod.drawLine( Expression, num,  Math.Round((double) y1 + (double) sizeF2.Height - 1.0),  Math.Round((double) ((float) num + sizeF2.Width)),  Math.Round((double) y1 + (double) sizeF2.Height - 1.0),  DrawMod.TGame.viccolor7.R,  DrawMod.TGame.viccolor7.G,  DrawMod.TGame.viccolor7.B,  DrawMod.TGame.viccolor7.A);
        else
          DrawMod.drawLine( Expression, num,  Math.Round((double) y1 + (double) sizeF2.Height + 2.0),  Math.Round((double) ((float) num + sizeF2.Width)),  Math.Round((double) y1 + (double) sizeF2.Height + 2.0),  DrawMod.TGame.viccolor7.R,  DrawMod.TGame.viccolor7.G,  DrawMod.TGame.viccolor7.B,  DrawMod.TGame.viccolor7.A);
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return self.OwnBitmap;
    }
  }
}
