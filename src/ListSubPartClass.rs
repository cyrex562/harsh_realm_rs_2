// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ListSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class ListSubPartClass : SubPartClass
  {
     int ListSize;
     int ListSelect;
    pub TopItem: i32;
     ListClass ListObj;
     Font OwnFont;
     Font ownfont2;
     object ItemSize;
     int ItemFontOffset;
     int LeftTextOffset;
     int Width;
     int Height;
     GameClass game;
     string Header;
     bool HeaderCenter;
     bool Highlight;
     bool ShowPair;
     int ValueWidth;
     bool DoTopAndBottom;
     Bitmap backbitmap;
     int clickscroll;
     bool MarcStyle;

    pub void Refresh(ListClass tListObj, int tlistselect, theader: String = "")
    {
      self.ListObj = tListObj;
      self.ListSelect = tlistselect;
      if (Strings.Len(theader) > 0)
        self.Header = theader;
      if (self.TopItem > self.ListObj.ListCount - self.ListSize)
        self.TopItem = self.ListObj.ListCount - self.ListSize;
      if (0 > self.TopItem)
        self.TopItem = 0;
      self.Clear();
    }

    pub void SubDispose()
    {
      if (Information.IsNothing((object) self.backbitmap))
        return;
      self.backbitmap.Dispose();
      self.backbitmap = (Bitmap) null;
    }

    pub ListSubPartClass(
      ListClass tListobj,
      int tlistsize,
      int twidth,
      int tlistselect,
      GameClass tgame,
      bool systemfont = false,
      tHeader: String = "",
      bool tHeaderCenter = true,
      bool tHighlight = true,
      int tTop = 0,
      bool tShowPair = false,
      int tValueWidth = 50,
      bool tdotopandbottom = true,
       Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tMarcStyle = false,
       Font overruleFont = null,
      int overruleItemSize = 16)
      : base(twidth, (tlistsize + 3) * overruleItemSize)
    {
      self.ItemSize = (object) 16;
      self.ItemFontOffset = 3;
      self.LeftTextOffset = 5;
      self.ItemSize = (object) overruleItemSize;
      if (!tdotopandbottom)
        self.Resize(twidth, Conversions.ToInteger(Operators.MultiplyObject((object) (tlistsize + 1), self.ItemSize)));
      self.MarcStyle = tMarcStyle;
      if (self.MarcStyle)
        self.LeftTextOffset = 10;
      self.ShowPair = tShowPair;
      self.ValueWidth = tValueWidth;
      self.DoTopAndBottom = tdotopandbottom;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        self.backbitmap = new Bitmap(self.OwnBitmap.Width, self.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        self.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) self.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, self.OwnBitmap.Width, self.OwnBitmap.Height), new Rectangle(bbx, bby, self.OwnBitmap.Width, self.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
        graphics.Dispose();
      }
      self.Width = twidth;
      self.Height = Conversions.ToInteger(Operators.MultiplyObject((object) (tlistsize + 3), self.ItemSize));
      if (!self.DoTopAndBottom)
        self.Height = Conversions.ToInteger(Operators.MultiplyObject((object) (tlistsize + 1), self.ItemSize));
      self.ListSize = tlistsize;
      self.ListSelect = tlistselect;
      self.ListObj = tListobj;
      self.MouseOver = true;
      self.clickscroll = 0;
      self.Highlight = tHighlight;
      self.TopItem = tTop;
      self.HeaderCenter = tHeaderCenter;
      self.game = tgame;
      if (Strings.Len(tHeader) > 0)
        self.Header = tHeader;
      switch (tTop)
      {
        case -1:
          tTop = 0;
          self.TopItem = 0;
          break;
        case 0:
          self.TopItem =  Math.Round((double) self.ListSelect - Conversion.Int((double) self.ListSize / 2.0));
          if (self.TopItem < 0)
          {
            self.TopItem = 0;
            break;
          }
          break;
      }
      if (Information.IsNothing((object) overruleFont))
      {
        if (self.MarcStyle)
          self.OwnFont =  self.game.MarcFont5.Clone();
        else if (!systemfont)
        {
          self.OwnFont = Font::new(self.game.FontCol.Families[1], 12f, FontStyle.Regular, GraphicsUnit.Pixel);
          self.ownfont2 = Font::new(self.game.FontCol.Families[1], 11f, FontStyle.Regular, GraphicsUnit.Pixel);
        }
        else
        {
          self.OwnFont = Font::new("Courier New", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
          self.ownfont2 = Font::new("Courier New", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
        }
      }
      else
        self.OwnFont =  overruleFont.Clone();
    }

    pub Bitmap Paint()
    {
      SizeF sizeF1 = SizeF::new();
      Color.FromArgb(0,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      Color color = Color.FromArgb(0,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      if (self.ListSize >= self.ListObj.ListCount)
        self.TopItem = 0;
      if (Information.IsNothing((object) self.backbitmap))
      {
        Expression.Clear(Color.Transparent);
      }
      else
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( Expression,  self.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      Bitmap bitmap;
      if (self.MarcStyle)
      {
        if (self.MarcStyle)
          self.ItemFontOffset = 3;
        if (self.game.Data.Product == 7)
        {
          SizeF sizeF2 = Expression.MeasureString("Yj2", self.OwnFont);
          if (Operators.ConditionalCompareObjectLess((object) sizeF2.Height, Operators.SubtractObject(self.ItemSize, (object) 4), false))
            self.ItemFontOffset += Conversions.ToInteger(NewLateBinding.LateGet((object) null, typeof (Math), "Floor", new object[1]
            {
              Operators.DivideObject(Operators.SubtractObject(Operators.SubtractObject(self.ItemSize, (object) 4), (object) sizeF2.Height), (object) 2)
            }, (string[]) null, (Type[]) null, (bool[]) null));
        }
        if (!self.DoTopAndBottom)
          DrawMod.DrawBlockGradient2( Expression, 0, 0, self.Width, self.Height, self.game.MarcCol1, self.game.MarcCol2);
        int num1 = 20;
        if (self.ListSize >= self.ListObj.ListCount)
          num1 = 0;
        int num2 = 2;
        int num3 = 1;
        if (!self.DoTopAndBottom)
        {
          num2 = 0;
          num3 = 0;
        }
        int Right = -1;
        int topItem = self.TopItem;
        int num4 = self.TopItem + self.ListSize + num2;
        for (int index = topItem; index <= num4; index += 1)
        {
          Right += 1;
          if (!(Right == self.ListSize + 2 & self.DoTopAndBottom) && self.ListSelect == index - num3 & self.ListSelect > -1 & self.Highlight)
          {
            if (self.MarcStyle)
              DrawMod.DrawBlockGradient2( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width - num1, Conversions.ToInteger(self.ItemSize), Color.FromArgb(175,  byte.MaxValue, 200,  byte.MaxValue), Color.FromArgb(50,  byte.MaxValue, 200,  byte.MaxValue));
            else
              DrawMod.DrawBlockGradient2( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width - num1, Conversions.ToInteger(self.ItemSize), Color.FromArgb(175, 0,  byte.MaxValue, 0), Color.FromArgb(50, 0,  byte.MaxValue, 0));
          }
          if (index - num3 <= self.ListObj.ListCount & index - num3 >= 0)
          {
            if (!self.ShowPair)
            {
              if (!Information.IsNothing((object) self.ListObj.ListBmp[index - num3]))
              {
                if (Operators.ConditionalCompareObjectLess((object) self.ListObj.ListBmp[index - num3].Height, self.ItemSize, false))
                {
                   Graphics local1 =  Expression;
                   Bitmap local2 =  self.ListObj.ListBmp[index - num3];
                  rectangle1 = new Rectangle(0, 0, 32, self.ListObj.ListBmp[index - num3].Height);
                  Rectangle srcrect = rectangle1;
                  rectangle2 = new Rectangle(self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) 1), (object) Conversions.ToInteger(Operators.DivideObject(Operators.SubtractObject(self.ItemSize, (object) self.ListObj.ListBmp[index - num3].Height), (object) 2)))), 32, self.ListObj.ListBmp[index - num3].Height);
                  Rectangle destrect = rectangle2;
                  DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
                }
                else
                {
                   Graphics local3 =  Expression;
                   Bitmap local4 =  self.ListObj.ListBmp[index - num3];
                  rectangle2 = new Rectangle(0, 0, 32, Conversions.ToInteger(self.ItemSize));
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) 3)), 32, Conversions.ToInteger(self.ItemSize));
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2( local3,  local4, srcrect, destrect);
                }
                if (self.ListObj.ListColor[index - num3] < 0)
                  DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.ListObj.ListBmp[index - num3].Width + 7 + self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White);
                else
                  DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.ListObj.ListBmp[index - num3].Width + 7 + self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.FromArgb( byte.MaxValue, 0, 150, 0));
              }
              else if (self.ListObj.ListColor[index - num3] < 0)
                DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White);
              else
                DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.FromArgb( byte.MaxValue, 0, 150, 0));
            }
            else
            {
              if (!Information.IsNothing((object) self.ListObj.ListBmp[index - num3]))
              {
                if (self.game.Data.Product >= 7)
                {
                  if (Operators.ConditionalCompareObjectLess((object) self.ListObj.ListBmp[index - num3].Height, self.ItemSize, false))
                  {
                     Graphics local5 =  Expression;
                     Bitmap local6 =  self.ListObj.ListBmp[index - num3];
                    rectangle2 = new Rectangle(0, 0, self.ListObj.ListBmp[index - num3].Width, self.ListObj.ListBmp[index - num3].Height);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(self.LeftTextOffset, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.ListObj.ListBmp[index - num3].Width, Conversions.ToInteger(self.ItemSize));
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
                  }
                  else
                  {
                     Graphics local7 =  Expression;
                     Bitmap local8 =  self.ListObj.ListBmp[index - num3];
                    rectangle2 = new Rectangle(0, 0, self.ListObj.ListBmp[index - num3].Width, self.ListObj.ListBmp[index - num3].Height);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) Conversions.ToInteger(Operators.DivideObject(Operators.SubtractObject((object) self.ListObj.ListBmp[index - num3].Height, self.ItemSize), (object) 2)))), self.ListObj.ListBmp[index - num3].Width, self.ListObj.ListBmp[index - num3].Height);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
                  }
                  str: String = self.ListObj.ListName[index - num3];
                  if (Strings.InStr(str, "\r\n") > 1)
                  {
                    tstring1: String = Strings.Left(str, Strings.InStr(str, "\r\n") - 1);
                    tstring2: String = Strings.Mid(str, Strings.InStr(str, "\r\n") + 2);
                    DrawMod.DrawTextColouredMarc( Expression, tstring1, self.OwnFont, self.ListObj.ListBmp[index - num3].Width + 7 + self.LeftTextOffset, Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset), (object)  Math.Round((double) self.OwnFont.Height / 2.0))), Color.White);
                    DrawMod.DrawTextColouredMarc( Expression, tstring2, self.OwnFont, self.ListObj.ListBmp[index - num3].Width + 7 + self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset), (object)  Math.Round((double) self.OwnFont.Height / 2.0))), Color.White);
                  }
                  else
                    DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.ListObj.ListBmp[index - num3].Width + 7 + self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White);
                }
                else
                {
                   Graphics local9 =  Expression;
                   Bitmap local10 =  self.ListObj.ListBmp[index - num3];
                  rectangle2 = new Rectangle(0, 0, 32, Conversions.ToInteger(self.ItemSize));
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) 3)), 32, Conversions.ToInteger(self.ItemSize));
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
                  DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.ListObj.ListBmp[index - num3].Width + 7 + self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White);
                }
              }
              else
                DrawMod.DrawTextColouredMarc( Expression, self.ListObj.ListName[index - num3], self.OwnFont, self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White);
              if (Operators.CompareString(self.ListObj.ListValue4[index - num3], "", false) != 0)
              {
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue[index - num3], self.OwnFont, self.Width - num1 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.25)));
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue2[index - num3], self.OwnFont,  Math.Round((double) (self.Width - num1) - ((double) self.ValueWidth * 0.75 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.25)));
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue3[index - num3], self.OwnFont,  Math.Round((double) (self.Width - num1) - ((double) self.ValueWidth * 0.5 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.25)));
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue4[index - num3], self.OwnFont,  Math.Round((double) (self.Width - num1) - ((double) self.ValueWidth * 0.25 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.25)));
              }
              else if (Operators.CompareString(self.ListObj.ListValue3[index - num3], "", false) != 0)
              {
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue[index - num3], self.OwnFont, self.Width - num1 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.33)));
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue2[index - num3], self.OwnFont,  Math.Round((double) (self.Width - num1) - ((double) self.ValueWidth * 0.66 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.33)));
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue3[index - num3], self.OwnFont,  Math.Round((double) (self.Width - num1) - ((double) self.ValueWidth * 0.33 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.33)));
              }
              else if (Operators.CompareString(self.ListObj.ListValue2[index - num3], "", false) != 0)
              {
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue[index - num3], self.OwnFont, self.Width - num1 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.5)));
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue2[index - num3], self.OwnFont,  Math.Round((double) (self.Width - num1) - ((double) self.ValueWidth / 2.0 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: ( Math.Round((double) self.ValueWidth * 0.5)));
              }
              else
                DrawMod.DrawTextColouredMarcCapped( Expression, self.ListObj.ListValue[index - num3], self.OwnFont, self.Width - num1 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.White, maxWidth: (self.ValueWidth * 1));
              if (index - num3 <= self.ListObj.ListCount & index > self.TopItem)
                DrawMod.drawLine( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)),  self.game.MarcCol2.R,  self.game.MarcCol2.G,  self.game.MarcCol2.B,  self.game.MarcCol2.A);
              else
                index = index;
            }
          }
        }
      }
      else
      {
        if (self.DoTopAndBottom)
          DrawMod.DrawBlock( Expression, 0, Conversions.ToInteger(self.ItemSize), self.Width, Conversions.ToInteger(Operators.SubtractObject((object) self.Height, Operators.MultiplyObject((object) 2, self.ItemSize))), 0, 0, 0, 166);
        else
          DrawMod.DrawBlock( Expression, 0, 0, self.Width, self.Height, 0, 0, 0, 166);
        int num5 = 20;
        if (self.ListSize >= self.ListObj.ListCount)
          num5 = 0;
        int num6 = 2;
        int num7 = 1;
        if (!self.DoTopAndBottom)
        {
          num6 = 0;
          num7 = 0;
        }
        int Right = -1;
        int topItem = self.TopItem;
        int num8 = self.TopItem + self.ListSize + num6;
        for (int index = topItem; index <= num8; index += 1)
        {
          Right += 1;
          if (!(Right == self.ListSize + 2 & self.DoTopAndBottom))
          {
            if ((Right + 10) % 2 == 0)
            {
              if (self.ListSelect == index - num7 & self.ListSelect > -1 & self.Highlight)
                DrawMod.DrawBlockGradient2( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width - num5, Conversions.ToInteger(self.ItemSize), Color.FromArgb(100, 100, 155, 100), Color.FromArgb(150, 100, 155, 100));
            }
            else if (self.ListSelect == index - num7 & self.ListSelect > -1 & self.Highlight)
              DrawMod.DrawBlockGradient2( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width - num5, Conversions.ToInteger(self.ItemSize), Color.FromArgb(100, 100, 155, 100), Color.FromArgb(150, 100, 155, 100));
          }
          if (Right == 0 & self.DoTopAndBottom)
          {
            if (Strings.Len(self.Header) > 0)
            {
              SizeF sizeF3 = Expression.MeasureString(self.Header, self.ownfont2);
              if (self.HeaderCenter)
                DrawMod.DrawText( Expression, self.Header, self.ownfont2,  Math.Round((double) self.Width / 2.0 - (double) sizeF3.Width / 2.0), Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset), (object) 1)));
              else
                DrawMod.DrawText( Expression, self.Header, self.ownfont2, self.LeftTextOffset, Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset), (object) 1)));
            }
            if (self.TopItem > 0)
            {
              if (num5 > 0)
              {
                 Graphics local11 =  Expression;
                bitmap = BitmapStore.GetBitmap(self.game.LISTUP);
                 Bitmap local12 =  bitmap;
                int x = self.Width - 20;
                DrawMod.DrawSimple( local11,  local12, x, 3);
              }
            }
            else if (num5 > 0)
            {
               Graphics local13 =  Expression;
              bitmap = BitmapStore.GetBitmap(self.game.LISTBLOCK);
               Bitmap local14 =  bitmap;
              int x = self.Width - 20;
              DrawMod.DrawSimple( local13,  local14, x, 3);
            }
          }
          else if (Right == self.ListSize + 2 & self.DoTopAndBottom)
          {
            if (self.TopItem + self.ListSize >= self.ListObj.ListCount)
            {
              if (num5 > 0)
              {
                 Graphics local15 =  Expression;
                bitmap = BitmapStore.GetBitmap(self.game.LISTBLOCK);
                 Bitmap local16 =  bitmap;
                int x = self.Width - 20;
                int integer = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) 3));
                DrawMod.DrawSimple( local15,  local16, x, integer);
              }
            }
            else if (num5 > 0)
            {
               Graphics local17 =  Expression;
              bitmap = BitmapStore.GetBitmap(self.game.LISTDOWN);
               Bitmap local18 =  bitmap;
              int x = self.Width - 20;
              int integer = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) 3));
              DrawMod.DrawSimple( local17,  local18, x, integer);
            }
          }
          else if (index - num7 <= self.ListObj.ListCount)
          {
            if (!self.ShowPair)
            {
              if (self.ListObj.ListColor[index - num7] < 0)
                DrawMod.DrawText( Expression, self.ListObj.ListName[index - num7], self.OwnFont, self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
              else
                DrawMod.DrawTextColoured( Expression, self.ListObj.ListName[index - num7], self.OwnFont, self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)), Color.FromArgb( byte.MaxValue, 210, 170, 100));
            }
            else
            {
              if (self.ListSize < self.ListObj.ListCount)
                DrawMod.DrawRectangle( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width - 21, Conversions.ToInteger(self.ItemSize),  color.R,  color.G,  color.B,  byte.MaxValue);
              else
                DrawMod.DrawRectangle( Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(self.ItemSize, (object) Right)), self.Width - 1, Conversions.ToInteger(self.ItemSize),  color.R,  color.G,  color.B,  byte.MaxValue);
              DrawMod.DrawText( Expression, self.ListObj.ListName[index - num7], self.OwnFont, self.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
              if (Operators.CompareString(self.ListObj.ListValue4[index - num7], "", false) != 0)
              {
                DrawMod.DrawText( Expression, self.ListObj.ListValue[index - num7], self.OwnFont, self.Width - num5 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
                DrawMod.DrawText( Expression, self.ListObj.ListValue2[index - num7], self.OwnFont,  Math.Round((double) (self.Width - num5) - ((double) self.ValueWidth * 0.75 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
                DrawMod.DrawText( Expression, self.ListObj.ListValue3[index - num7], self.OwnFont,  Math.Round((double) (self.Width - num5) - ((double) self.ValueWidth * 0.5 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
                DrawMod.DrawText( Expression, self.ListObj.ListValue4[index - num7], self.OwnFont,  Math.Round((double) (self.Width - num5) - ((double) self.ValueWidth * 0.25 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
              }
              else if (Operators.CompareString(self.ListObj.ListValue3[index - num7], "", false) != 0)
              {
                DrawMod.DrawText( Expression, self.ListObj.ListValue[index - num7], self.OwnFont, self.Width - num5 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
                DrawMod.DrawText( Expression, self.ListObj.ListValue2[index - num7], self.OwnFont,  Math.Round((double) (self.Width - num5) - ((double) self.ValueWidth * 0.66 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
                DrawMod.DrawText( Expression, self.ListObj.ListValue3[index - num7], self.OwnFont,  Math.Round((double) (self.Width - num5) - ((double) self.ValueWidth * 0.33 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
              }
              else if (Operators.CompareString(self.ListObj.ListValue2[index - num7], "", false) != 0)
              {
                DrawMod.DrawText( Expression, self.ListObj.ListValue[index - num7], self.OwnFont, self.Width - num5 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
                DrawMod.DrawText( Expression, self.ListObj.ListValue2[index - num7], self.OwnFont,  Math.Round((double) (self.Width - num5) - ((double) self.ValueWidth / 2.0 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
              }
              else
                DrawMod.DrawText( Expression, self.ListObj.ListValue[index - num7], self.OwnFont, self.Width - num5 - (self.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(self.ItemSize, (object) Right), (object) self.ItemFontOffset)));
            }
          }
        }
      }
      int Left = Conversions.ToInteger(Operators.MultiplyObject((object) (self.ListSize + 1), self.ItemSize));
      float num9 = self.ListObj.ListCount <= 0 ? 1f : (float) self.ListSize / (float) self.ListObj.ListCount;
      if ((double) num9 > 1.0)
        num9 = 1f;
      int num10 =  Math.Round((double) Conversion.Int((float) Left * num9));
      float num11 = self.ListObj.ListCount <= 0 ? 0.0f : (float) self.TopItem / (float) self.ListObj.ListCount;
      if ((double) num11 > 1.0)
        num11 = 1f;
      int num12 =  Math.Round((double) Conversion.Int((float) Left * num11));
      if (self.DoTopAndBottom)
        num12 = Conversions.ToInteger(Operators.AddObject((object) num12, self.ItemSize));
      if (Left < 5)
        Left = 5;
      if (Operators.ConditionalCompareObjectGreater((object) (num12 + num10), Operators.AddObject((object) Left, self.ItemSize), false))
        num10 = Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject((object) Left, self.ItemSize), (object) num12));
      if (self.ListSize < self.ListObj.ListCount)
      {
        int x = self.Width - 18;
        int y = num12 + 3;
        int width = 16;
        int num13 = num10 - 2;
        if (!self.MarcStyle)
        {
           Graphics local19 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
           Bitmap local20 =  bitmap;
          rectangle2 = new Rectangle(0, 8, 28, 12);
          Rectangle srcrect1 = rectangle2;
          rectangle1 = new Rectangle(x, y + 8, width, num13 - 16);
          Rectangle destrect1 = rectangle1;
          DrawMod.DrawSimplePart2( local19,  local20, srcrect1, destrect1);
           Graphics local21 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
           Bitmap local22 =  bitmap;
          rectangle2 = new Rectangle(0, 0, 28, 8);
          Rectangle srcrect2 = rectangle2;
          rectangle1 = new Rectangle(x, y, width, 8);
          Rectangle destrect2 = rectangle1;
          DrawMod.DrawSimplePart2( local21,  local22, srcrect2, destrect2);
           Graphics local23 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
           Bitmap local24 =  bitmap;
          rectangle2 = new Rectangle(0, 28, 28, 8);
          Rectangle srcrect3 = rectangle2;
          rectangle1 = new Rectangle(x, y + num13 - 8, 28, 8);
          Rectangle destrect3 = rectangle1;
          DrawMod.DrawSimplePart2( local23,  local24, srcrect3, destrect3);
        }
        else
        {
           Graphics local25 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
           Bitmap local26 =  bitmap;
          rectangle2 = new Rectangle(0, 2, 20, 6);
          Rectangle srcrect4 = rectangle2;
          rectangle1 = new Rectangle(x, 2, 20, self.Height - 4);
          Rectangle destrect4 = rectangle1;
          DrawMod.DrawSimplePart2( local25,  local26, srcrect4, destrect4);
           Graphics local27 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
           Bitmap local28 =  bitmap;
          rectangle2 = new Rectangle(0, 0, 20, 2);
          Rectangle srcrect5 = rectangle2;
          rectangle1 = new Rectangle(x, 0, 20, 2);
          Rectangle destrect5 = rectangle1;
          DrawMod.DrawSimplePart2( local27,  local28, srcrect5, destrect5);
           Graphics local29 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
           Bitmap local30 =  bitmap;
          rectangle2 = new Rectangle(0, 8, 20, 2);
          Rectangle srcrect6 = rectangle2;
          rectangle1 = new Rectangle(x, self.Height - 2, 20, 2);
          Rectangle destrect6 = rectangle1;
          DrawMod.DrawSimplePart2( local29,  local30, srcrect6, destrect6);
           Graphics local31 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
           Bitmap local32 =  bitmap;
          rectangle2 = new Rectangle(0, 2, 20, 6);
          Rectangle srcrect7 = rectangle2;
          rectangle1 = new Rectangle(x, y + 2, width, num13 - 2);
          Rectangle destrect7 = rectangle1;
          DrawMod.DrawSimplePart2( local31,  local32, srcrect7, destrect7);
           Graphics local33 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
           Bitmap local34 =  bitmap;
          rectangle2 = new Rectangle(0, 0, 20, 2);
          Rectangle srcrect8 = rectangle2;
          rectangle1 = new Rectangle(x, y, width, 2);
          Rectangle destrect8 = rectangle1;
          DrawMod.DrawSimplePart2( local33,  local34, srcrect8, destrect8);
           Graphics local35 =  Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
           Bitmap local36 =  bitmap;
          rectangle2 = new Rectangle(0, 8, 20, 2);
          Rectangle srcrect9 = rectangle2;
          rectangle1 = new Rectangle(x, y + num13 - 2, 10, 2);
          Rectangle destrect9 = rectangle1;
          DrawMod.DrawSimplePart2( local35,  local36, srcrect9, destrect9);
        }
      }
      if (!self.MarcStyle)
      {
        if (self.DoTopAndBottom)
        {
          if (self.ListSize < self.ListObj.ListCount)
            DrawMod.DrawRectangle( Expression, 0, Conversions.ToInteger(self.ItemSize), self.Width - 21, Conversions.ToInteger(Operators.SubtractObject((object) self.Height, Operators.MultiplyObject(self.ItemSize, (object) 2))),  byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
          else
            DrawMod.DrawRectangle( Expression, 0, Conversions.ToInteger(self.ItemSize), self.Width - 1, Conversions.ToInteger(Operators.SubtractObject((object) self.Height, Operators.MultiplyObject(self.ItemSize, (object) 2))),  byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
        }
        else if (self.ListSize < self.ListObj.ListCount)
          DrawMod.DrawRectangle( Expression, 0, 0, self.Width - 21, self.Height - 1,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
        else
          DrawMod.DrawRectangle( Expression, 0, 0, self.Width - 1, self.Height - 1,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      }
      if (self.MarcStyle)
        DrawMod.DrawFrame( self.OwnBitmap,  self.backbitmap,  Expression, 0, 0, self.Width, self.Height, -1, -1);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return self.OwnBitmap;
    }

    pub void ShiftDown()
    {
      self += 1.ListSelect;
      if ((double) self.ListSelect > (double) self.TopItem + (double) self.ListSize / 2.0)
        self += 1.TopItem;
      if (self.TopItem > self.ListObj.ListCount - self.ListSize)
        self.TopItem = self.ListObj.ListCount - self.ListSize;
      if (self.ListSelect > self.ListObj.ListCount)
        self.ListSelect = self.ListObj.ListCount;
      if (0 > self.TopItem)
        self.TopItem = 0;
      if (0 <= self.ListSelect)
        return;
      self.ListSelect = 0;
    }

    pub void ShiftUp()
    {
      --self.ListSelect;
      if ((double) (self.ListSelect - self.TopItem) < (double) self.ListSize / 2.0)
        --self.TopItem;
      if (self.TopItem > self.ListObj.ListCount - self.ListSize)
        self.TopItem = self.ListObj.ListCount - self.ListSize;
      if (self.ListSelect > self.ListObj.ListCount)
        self.ListSelect = self.ListObj.ListCount;
      if (0 > self.TopItem)
        self.TopItem = 0;
      if (0 <= self.ListSelect)
        return;
      self.ListSelect = 0;
    }

    pub int GetSelect() => self.ListObj.ListData[self.ListSelect];

    pub int GetTopItem() => self.TopItem;

    pub int Click(int x, int y, int b = 1)
    {
      int Left = y;
      y = Conversions.ToInteger(Conversion.Int(Operators.DivideObject((object) y, self.ItemSize)));
      self.Scroller = true;
      int num1 = 0;
      int num2 = 2;
      int num3 = 1;
      if (!self.DoTopAndBottom)
      {
        num2 = 1;
        num1 = -1;
        num3 = 0;
      }
      int num4 = 20;
      if (self.ListSize >= self.ListObj.ListCount)
        num4 = 0;
      if (y > num1 & y < self.ListSize + num2)
      {
        if (x <= self.Width - num4)
        {
          y -= num3;
          y += self.TopItem;
          self.clickscroll = 0;
          if (y > self.ListObj.ListCount)
            return -1;
          self.ListSelect = y;
          return self.ListObj.ListData[self.ListSelect];
        }
        self.clickscroll = 1;
        int integer = Conversions.ToInteger(Operators.MultiplyObject((object) (self.ListSize + 1), self.ItemSize));
        if (self.DoTopAndBottom)
          Left = Conversions.ToInteger(Operators.SubtractObject((object) Left, self.ItemSize));
        if (Left < 1)
          Left = 1;
        int num5 =  Math.Round((double)  Math.Round((double) ((float) Left / (float) integer * (float) self.ListObj.ListCount)) - (double) self.ListSize / 2.0);
        if (0 > num5)
          num5 = 0;
        self.TopItem = num5;
        if (self.TopItem > self.ListObj.ListCount - self.ListSize)
          self.TopItem = self.ListObj.ListCount - self.ListSize;
        if (0 > self.TopItem)
          self.TopItem = 0;
        return -1;
      }
      if (y == 0 & self.DoTopAndBottom)
      {
        --self.TopItem;
        self.clickscroll = 0;
        if (0 > self.TopItem)
          self.TopItem = 0;
        return -1;
      }
      if (!(y == self.ListSize + 2 & self.DoTopAndBottom))
        return -1;
      self += 1.TopItem;
      self.clickscroll = 0;
      if (self.TopItem > self.ListObj.ListCount - self.ListSize)
        self.TopItem = self.ListObj.ListCount - self.ListSize;
      if (0 > self.TopItem)
        self.TopItem = 0;
      return -1;
    }

    pub int HandleMouseUp(int x, int y)
    {
      if (!(self.clickscroll == 1 | self.Scroller))
        return -1;
      self.clickscroll = 0;
      self.Scroller = false;
      return 1;
    }

    pub int HandleBLOCKEDMouseUp(int x, int y)
    {
      if (!(self.clickscroll == 1 | self.Scroller))
        return -1;
      self.clickscroll = 0;
      self.Scroller = false;
      return 1;
    }

    pub bool MouseMove(int x, int y)
    {
      int Left = y;
      y = Conversions.ToInteger(Conversion.Int(Operators.DivideObject((object) y, self.ItemSize)));
      int num1 = 0;
      int num2 = 2;
      int num3 = 1;
      if (!self.DoTopAndBottom)
      {
        num2 = 1;
        num1 = -1;
        num3 = 0;
      }
      int num4 = 20;
      if (self.ListSize >= self.ListObj.ListCount)
        num4 = 0;
      if (!(y > num1 & y < self.ListSize + num2 & self.clickscroll == 1))
        return false;
      int integer = Conversions.ToInteger(Operators.MultiplyObject((object) (self.ListSize + 1), self.ItemSize));
      if (self.DoTopAndBottom)
        Left = Conversions.ToInteger(Operators.SubtractObject((object) Left, self.ItemSize));
      if (Left < 1)
        Left = 1;
      int num5 =  Math.Round((double)  Math.Round((double) ((float) Left / (float) integer * (float) self.ListObj.ListCount)) - (double) self.ListSize / 2.0);
      if (0 > num5)
        num5 = 0;
      self.TopItem = num5;
      if (self.TopItem > self.ListObj.ListCount - self.ListSize)
        self.TopItem = self.ListObj.ListCount - self.ListSize;
      if (0 > self.TopItem)
        self.TopItem = 0;
      return true;
    }
  }
}
