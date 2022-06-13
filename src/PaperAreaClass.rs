// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PaperAreaClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsApplication1
{
  pub class PaperAreaClass : SubPartClass
  {
     int ListSize;
     int ListSelect;
    pub TopItem: i32;
     ListClass ListObj;
     Font OwnFont;
     int ItemSize;
     const int ItemFontOffset = 1;
     const int LeftTextOffset = 5;
     int Width;
     int Height;
     string Header;
     bool HeaderCenter;
     GameClass game;
     Bitmap backbitmap;
     Color fontcol;
     bool centerit;
     int clickscroll;
     bool HideShade;
     int PaginationLines;
     int mzx;
     int mzy;
     int mzx2;
     int mzy2;
     bool mzover;
     bool mzover2;
     int bgcolor;

    pub void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    pub void Refresh(ListClass tListObj, int tlistselect, theader: String = "")
    {
      this.ListObj = tListObj;
      this.ListSelect = tlistselect;
      if (Strings.Len(theader) > 0)
        this.Header = theader;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      this.Clear();
    }

    pub PaperAreaClass(
      GameClass tgame,
      int twidth,
      int trows,
      Font tfont,
      string theader,
      bool theadercenter,
      string tText,
      Color tfontcol,
      int tTop = 0,
      int tItemSize = 16,
       Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tcenterit = false,
      bool tHideShade = false,
      int tPaginationLines = 2,
      int tbgcolor = -1)
      : base(twidth, (trows + 1) * tItemSize)
    {
      this.ItemSize = tItemSize;
      this.Width = twidth;
      this.Height = (trows + 1) * this.ItemSize;
      this.game = tgame;
      this.HideShade = tHideShade;
      this.PaginationLines = tPaginationLines;
      this.centerit = tcenterit;
      this.bgcolor = tbgcolor;
      Graphics objGraphics;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        this.backbitmap = new Bitmap(this.Width, this.Height);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        objGraphics = Graphics.FromImage((Image) this.backbitmap);
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimplePart2( objGraphics,  tbackbitmap, new Rectangle(bbx, bby, this.Width, this.Height), new Rectangle(0, 0, this.Width, this.Height));
        objGraphics = (Graphics) null;
      }
      this.fontcol = !Information.IsNothing((object) tfontcol) ? tfontcol : Color.White;
      SizeF sizeF = SizeF::new();
      this.ListObj = ListClass::new();
      objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      this.OwnFont = !Information.IsNothing((object) tfont) ? tfont : this.game.VicFont7;
      int num1 = 1;
      this.clickscroll = 0;
      if (Information.IsNothing((object) tText))
        tText = "";
      tText = tText.Replace("\t", " ");
      while (Strings.Len(tText) > 0)
      {
        int num2 = 1;
        str1: String = "";
        while (num2 == 1)
        {
          int num3 = Strings.InStr(tText, "\r\n");
          int num4 = Strings.InStr(tText, " ");
          if (num4 == 0)
            num4 = 9999999;
          if (num3 < num4 & num3 > 0)
          {
            int num5 = num3;
            num2 = 0;
            int num6 = 0;
            if (num5 != 1)
            {
              if ((double) objGraphics.MeasureString(str1 + Strings.Left(tText, num5 - 1), this.OwnFont).Width <= (double) this.Width)
                str1 += Strings.Left(tText, num5 - 1);
              else
                num6 = 1;
            }
            if (num6 == 0)
              tText = num5 >= Strings.Len(tText) ? "" : Strings.Mid(tText, num5 + 2);
          }
          else
          {
            int Length = Strings.InStr(tText, " ");
            str2: String = Length <= 0 ? tText : Strings.Left(tText, Length);
            int num7 = 0;
            num2 = 0;
            if ((double) objGraphics.MeasureString(str1 + str2, this.OwnFont).Width <= (double) this.Width)
            {
              num1 = 1;
              num7 = 1;
            }
            else if (num1 == 1)
            {
              num1 = 0;
            }
            else
            {
              num1 = 1;
              num7 = 1;
            }
            if (num7 == 1)
            {
              str1 += str2;
              if (Length > 0)
              {
                if (Strings.Len(tText) >= Length + 1)
                {
                  tText = Strings.Mid(tText, Length + 1);
                  num2 = 1;
                }
                else
                {
                  tText = "";
                  num2 = 0;
                }
              }
              else
              {
                tText = "";
                num2 = 0;
              }
            }
          }
        }
        if (Strings.InStr(str1, "Spaniards") > 0)
          str1 = str1;
        this.ListObj.add(str1, 0);
      }
      this.ListSize = trows;
      this.ListSelect = -1;
      this.TopItem = tTop;
      this.HeaderCenter = theadercenter;
      if (Strings.Len(theader) > 0)
        this.Header = theader;
      if (tTop == 0)
      {
        this.TopItem =  Math.Round((double) this.ListSelect - Conversion.Int((double) this.ListSize / 2.0));
        if (this.TopItem < 0)
          this.TopItem = 0;
      }
      this.MouseOver = true;
      if (Information.IsNothing((object) objGraphics))
        return;
      objGraphics.Dispose();
      objGraphics = (Graphics) null;
    }

    pub Bitmap Paint()
    {
      SizeF sizeF1 = SizeF::new();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimplePart2( Expression,  this.backbitmap, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, this.Width, this.Height));
      }
      else if (this.bgcolor == -1)
        Expression.Clear(Color.White);
      Expression.CompositingMode = CompositingMode.SourceOver;
      int num1 = -1;
      int topItem = this.TopItem;
      int num2 = this.TopItem + this.ListSize - this.PaginationLines;
      SizeF sizeF2;
      for (int index = topItem; index <= num2; index += 1)
      {
        num1 += 1;
        if (index <= this.ListObj.ListCount)
        {
          if (!this.centerit)
          {
            DrawMod.DrawTextColoured( Expression, this.ListObj.ListName[index], this.OwnFont, 5, this.ItemSize * num1 + 1, this.fontcol);
          }
          else
          {
            sizeF2 = Expression.MeasureString(this.ListObj.ListName[index], this.OwnFont);
            int num3 =  Math.Round((double) this.Width / 2.0 - (double) sizeF2.Width / 2.0);
            if (0 > num3)
              num3 = 0;
            DrawMod.DrawTextColoured( Expression, this.ListObj.ListName[index], this.OwnFont, num3 + 5, this.ItemSize * num1 + 1, this.fontcol);
          }
        }
      }
      if (this.ListSize - this.PaginationLines < this.ListObj.ListCount)
      {
        int Number1 =  Math.Round(Conversion.Int((double) this.ListObj.ListCount / (double) (this.ListSize - this.PaginationLines)) + 1.0);
        int Number2 =  Math.Round(Conversion.Int((double) this.TopItem / (double) (this.ListSize - this.PaginationLines)) + 1.0);
        str: String = "Page " + Strings.Trim(Conversion.Str((object) Number2)) + " of " + Strings.Trim(Conversion.Str((object) Number1));
        sizeF2 = Expression.MeasureString(str, this.OwnFont);
        int num4 =  Math.Round((double) this.Width / 2.0 - (double) sizeF2.Width / 2.0);
        if (0 > num4)
          num4 = 0;
        DrawMod.DrawTextColoured( Expression, str, this.game.VicFont7, 5 + num4, this.Height - this.ItemSize - 15, Color.Black);
        this.mzx = 9999;
        this.mzy = 9999;
        this.mzx2 = 9999;
        this.mzy2 = 9999;
        if (Number2 > 1)
        {
          this.mzx = 5 + num4 - 60;
          this.mzy = this.Height - this.ItemSize - 17;
          DrawMod.DrawButton( Expression, this.mzx, this.mzy, 40, 20, this.mzover, "<");
        }
        if (Number2 < Number1)
        {
          this.mzx2 =  Math.Round((double) ((float) (5 + num4 + 20) + sizeF2.Width));
          this.mzy2 = this.Height - this.ItemSize - 17;
          DrawMod.DrawButton( Expression, this.mzx2, this.mzy2, 40, 20, this.mzover2, ">");
        }
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay() => this.Paint();

    pub int Click(int x, int y, int b = 1)
    {
      if (x > this.mzx & x < this.mzx + 40 & y > this.mzy & y < this.mzy + 21)
      {
        this.TopItem -= this.ListSize - this.PaginationLines;
        if (0 > this.TopItem)
          this.TopItem = 0;
      }
      if (x > this.mzx2 & x < this.mzx2 + 40 & y > this.mzy2 & y < this.mzy2 + 21)
      {
        this.TopItem += this.ListSize - this.PaginationLines;
        if (this.TopItem > this.ListObj.ListCount)
          this.TopItem = this.ListObj.ListCount;
      }
      int num;
      return num;
    }

    pub bool MouseMove(int x, int y)
    {
      if (x > this.mzx & x < this.mzx + 40 & y > this.mzy & y < this.mzy + 21)
      {
        this.mzover = true;
        return true;
      }
      if (this.mzover)
      {
        this.mzover = false;
        return true;
      }
      if (x > this.mzx2 & x < this.mzx2 + 40 & y > this.mzy2 & y < this.mzy2 + 21)
      {
        this.mzover2 = true;
        return true;
      }
      if (!this.mzover2)
        return false;
      this.mzover2 = false;
      return true;
    }
  }
}
