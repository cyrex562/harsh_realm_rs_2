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
  public class ListSubPartClass : SubPartClass
  {
    private int ListSize;
    private int ListSelect;
    public int TopItem;
    private ListClass ListObj;
    private Font OwnFont;
    private Font ownfont2;
    private object ItemSize;
    private int ItemFontOffset;
    private int LeftTextOffset;
    private int Width;
    private int Height;
    private GameClass game;
    private string Header;
    private bool HeaderCenter;
    private bool Highlight;
    private bool ShowPair;
    private int ValueWidth;
    private bool DoTopAndBottom;
    private Bitmap backbitmap;
    private int clickscroll;
    private bool MarcStyle;

    public override void Refresh(ListClass tListObj, int tlistselect, string theader = "")
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

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public ListSubPartClass(
      ListClass tListobj,
      int tlistsize,
      int twidth,
      int tlistselect,
      GameClass tgame,
      bool systemfont = false,
      string tHeader = "",
      bool tHeaderCenter = true,
      bool tHighlight = true,
      int tTop = 0,
      bool tShowPair = false,
      int tValueWidth = 50,
      bool tdotopandbottom = true,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tMarcStyle = false,
      ref Font overruleFont = null,
      int overruleItemSize = 16)
      : base(twidth, (tlistsize + 3) * overruleItemSize)
    {
      this.ItemSize = (object) 16;
      this.ItemFontOffset = 3;
      this.LeftTextOffset = 5;
      this.ItemSize = (object) overruleItemSize;
      if (!tdotopandbottom)
        this.Resize(twidth, Conversions.ToInteger(Operators.MultiplyObject((object) (tlistsize + 1), this.ItemSize)));
      this.MarcStyle = tMarcStyle;
      if (this.MarcStyle)
        this.LeftTextOffset = 10;
      this.ShowPair = tShowPair;
      this.ValueWidth = tValueWidth;
      this.DoTopAndBottom = tdotopandbottom;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
        graphics.Dispose();
      }
      this.Width = twidth;
      this.Height = Conversions.ToInteger(Operators.MultiplyObject((object) (tlistsize + 3), this.ItemSize));
      if (!this.DoTopAndBottom)
        this.Height = Conversions.ToInteger(Operators.MultiplyObject((object) (tlistsize + 1), this.ItemSize));
      this.ListSize = tlistsize;
      this.ListSelect = tlistselect;
      this.ListObj = tListobj;
      this.MouseOver = true;
      this.clickscroll = 0;
      this.Highlight = tHighlight;
      this.TopItem = tTop;
      this.HeaderCenter = tHeaderCenter;
      this.game = tgame;
      if (Strings.Len(tHeader) > 0)
        this.Header = tHeader;
      switch (tTop)
      {
        case -1:
          tTop = 0;
          this.TopItem = 0;
          break;
        case 0:
          this.TopItem = (int) Math.Round((double) this.ListSelect - Conversion.Int((double) this.ListSize / 2.0));
          if (this.TopItem < 0)
          {
            this.TopItem = 0;
            break;
          }
          break;
      }
      if (Information.IsNothing((object) overruleFont))
      {
        if (this.MarcStyle)
          this.OwnFont = (Font) this.game.MarcFont5.Clone();
        else if (!systemfont)
        {
          this.OwnFont = new Font(this.game.FontCol.Families[1], 12f, FontStyle.Regular, GraphicsUnit.Pixel);
          this.ownfont2 = new Font(this.game.FontCol.Families[1], 11f, FontStyle.Regular, GraphicsUnit.Pixel);
        }
        else
        {
          this.OwnFont = new Font("Courier New", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
          this.ownfont2 = new Font("Courier New", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
        }
      }
      else
        this.OwnFont = (Font) overruleFont.Clone();
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color color = Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.ListSize >= this.ListObj.ListCount)
        this.TopItem = 0;
      if (Information.IsNothing((object) this.backbitmap))
      {
        Expression.Clear(Color.Transparent);
      }
      else
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      Bitmap bitmap;
      if (this.MarcStyle)
      {
        if (this.MarcStyle)
          this.ItemFontOffset = 3;
        if (this.game.Data.Product == 7)
        {
          SizeF sizeF2 = Expression.MeasureString("Yj2", this.OwnFont);
          if (Operators.ConditionalCompareObjectLess((object) sizeF2.Height, Operators.SubtractObject(this.ItemSize, (object) 4), false))
            this.ItemFontOffset += Conversions.ToInteger(NewLateBinding.LateGet((object) null, typeof (Math), "Floor", new object[1]
            {
              Operators.DivideObject(Operators.SubtractObject(Operators.SubtractObject(this.ItemSize, (object) 4), (object) sizeF2.Height), (object) 2)
            }, (string[]) null, (Type[]) null, (bool[]) null));
        }
        if (!this.DoTopAndBottom)
          DrawMod.DrawBlockGradient2(ref Expression, 0, 0, this.Width, this.Height, this.game.MarcCol1, this.game.MarcCol2);
        int num1 = 20;
        if (this.ListSize >= this.ListObj.ListCount)
          num1 = 0;
        int num2 = 2;
        int num3 = 1;
        if (!this.DoTopAndBottom)
        {
          num2 = 0;
          num3 = 0;
        }
        int Right = -1;
        int topItem = this.TopItem;
        int num4 = this.TopItem + this.ListSize + num2;
        for (int index = topItem; index <= num4; ++index)
        {
          ++Right;
          if (!(Right == this.ListSize + 2 & this.DoTopAndBottom) && this.ListSelect == index - num3 & this.ListSelect > -1 & this.Highlight)
          {
            if (this.MarcStyle)
              DrawMod.DrawBlockGradient2(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width - num1, Conversions.ToInteger(this.ItemSize), Color.FromArgb(175, (int) byte.MaxValue, 200, (int) byte.MaxValue), Color.FromArgb(50, (int) byte.MaxValue, 200, (int) byte.MaxValue));
            else
              DrawMod.DrawBlockGradient2(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width - num1, Conversions.ToInteger(this.ItemSize), Color.FromArgb(175, 0, (int) byte.MaxValue, 0), Color.FromArgb(50, 0, (int) byte.MaxValue, 0));
          }
          if (index - num3 <= this.ListObj.ListCount & index - num3 >= 0)
          {
            if (!this.ShowPair)
            {
              if (!Information.IsNothing((object) this.ListObj.ListBmp[index - num3]))
              {
                if (Operators.ConditionalCompareObjectLess((object) this.ListObj.ListBmp[index - num3].Height, this.ItemSize, false))
                {
                  ref Graphics local1 = ref Expression;
                  ref Bitmap local2 = ref this.ListObj.ListBmp[index - num3];
                  rectangle1 = new Rectangle(0, 0, 32, this.ListObj.ListBmp[index - num3].Height);
                  Rectangle srcrect = rectangle1;
                  rectangle2 = new Rectangle(this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) 1), (object) Conversions.ToInteger(Operators.DivideObject(Operators.SubtractObject(this.ItemSize, (object) this.ListObj.ListBmp[index - num3].Height), (object) 2)))), 32, this.ListObj.ListBmp[index - num3].Height);
                  Rectangle destrect = rectangle2;
                  DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
                }
                else
                {
                  ref Graphics local3 = ref Expression;
                  ref Bitmap local4 = ref this.ListObj.ListBmp[index - num3];
                  rectangle2 = new Rectangle(0, 0, 32, Conversions.ToInteger(this.ItemSize));
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) 3)), 32, Conversions.ToInteger(this.ItemSize));
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
                }
                if (this.ListObj.ListColor[index - num3] < 0)
                  DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.ListObj.ListBmp[index - num3].Width + 7 + this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White);
                else
                  DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.ListObj.ListBmp[index - num3].Width + 7 + this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.FromArgb((int) byte.MaxValue, 0, 150, 0));
              }
              else if (this.ListObj.ListColor[index - num3] < 0)
                DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White);
              else
                DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.FromArgb((int) byte.MaxValue, 0, 150, 0));
            }
            else
            {
              if (!Information.IsNothing((object) this.ListObj.ListBmp[index - num3]))
              {
                if (this.game.Data.Product >= 7)
                {
                  if (Operators.ConditionalCompareObjectLess((object) this.ListObj.ListBmp[index - num3].Height, this.ItemSize, false))
                  {
                    ref Graphics local5 = ref Expression;
                    ref Bitmap local6 = ref this.ListObj.ListBmp[index - num3];
                    rectangle2 = new Rectangle(0, 0, this.ListObj.ListBmp[index - num3].Width, this.ListObj.ListBmp[index - num3].Height);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(this.LeftTextOffset, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.ListObj.ListBmp[index - num3].Width, Conversions.ToInteger(this.ItemSize));
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
                  }
                  else
                  {
                    ref Graphics local7 = ref Expression;
                    ref Bitmap local8 = ref this.ListObj.ListBmp[index - num3];
                    rectangle2 = new Rectangle(0, 0, this.ListObj.ListBmp[index - num3].Width, this.ListObj.ListBmp[index - num3].Height);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) Conversions.ToInteger(Operators.DivideObject(Operators.SubtractObject((object) this.ListObj.ListBmp[index - num3].Height, this.ItemSize), (object) 2)))), this.ListObj.ListBmp[index - num3].Width, this.ListObj.ListBmp[index - num3].Height);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
                  }
                  string str = this.ListObj.ListName[index - num3];
                  if (Strings.InStr(str, "\r\n") > 1)
                  {
                    string tstring1 = Strings.Left(str, Strings.InStr(str, "\r\n") - 1);
                    string tstring2 = Strings.Mid(str, Strings.InStr(str, "\r\n") + 2);
                    DrawMod.DrawTextColouredMarc(ref Expression, tstring1, this.OwnFont, this.ListObj.ListBmp[index - num3].Width + 7 + this.LeftTextOffset, Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset), (object) (int) Math.Round((double) this.OwnFont.Height / 2.0))), Color.White);
                    DrawMod.DrawTextColouredMarc(ref Expression, tstring2, this.OwnFont, this.ListObj.ListBmp[index - num3].Width + 7 + this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset), (object) (int) Math.Round((double) this.OwnFont.Height / 2.0))), Color.White);
                  }
                  else
                    DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.ListObj.ListBmp[index - num3].Width + 7 + this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White);
                }
                else
                {
                  ref Graphics local9 = ref Expression;
                  ref Bitmap local10 = ref this.ListObj.ListBmp[index - num3];
                  rectangle2 = new Rectangle(0, 0, 32, Conversions.ToInteger(this.ItemSize));
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) 3)), 32, Conversions.ToInteger(this.ItemSize));
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
                  DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.ListObj.ListBmp[index - num3].Width + 7 + this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White);
                }
              }
              else
                DrawMod.DrawTextColouredMarc(ref Expression, this.ListObj.ListName[index - num3], this.OwnFont, this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White);
              if (Operators.CompareString(this.ListObj.ListValue4[index - num3], "", false) != 0)
              {
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue[index - num3], this.OwnFont, this.Width - num1 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.25)));
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue2[index - num3], this.OwnFont, (int) Math.Round((double) (this.Width - num1) - ((double) this.ValueWidth * 0.75 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.25)));
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue3[index - num3], this.OwnFont, (int) Math.Round((double) (this.Width - num1) - ((double) this.ValueWidth * 0.5 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.25)));
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue4[index - num3], this.OwnFont, (int) Math.Round((double) (this.Width - num1) - ((double) this.ValueWidth * 0.25 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.25)));
              }
              else if (Operators.CompareString(this.ListObj.ListValue3[index - num3], "", false) != 0)
              {
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue[index - num3], this.OwnFont, this.Width - num1 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.33)));
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue2[index - num3], this.OwnFont, (int) Math.Round((double) (this.Width - num1) - ((double) this.ValueWidth * 0.66 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.33)));
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue3[index - num3], this.OwnFont, (int) Math.Round((double) (this.Width - num1) - ((double) this.ValueWidth * 0.33 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.33)));
              }
              else if (Operators.CompareString(this.ListObj.ListValue2[index - num3], "", false) != 0)
              {
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue[index - num3], this.OwnFont, this.Width - num1 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.5)));
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue2[index - num3], this.OwnFont, (int) Math.Round((double) (this.Width - num1) - ((double) this.ValueWidth / 2.0 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: ((int) Math.Round((double) this.ValueWidth * 0.5)));
              }
              else
                DrawMod.DrawTextColouredMarcCapped(ref Expression, this.ListObj.ListValue[index - num3], this.OwnFont, this.Width - num1 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.White, maxWidth: (this.ValueWidth * 1));
              if (index - num3 <= this.ListObj.ListCount & index > this.TopItem)
                DrawMod.drawLine(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), (int) this.game.MarcCol2.R, (int) this.game.MarcCol2.G, (int) this.game.MarcCol2.B, (int) this.game.MarcCol2.A);
              else
                index = index;
            }
          }
        }
      }
      else
      {
        if (this.DoTopAndBottom)
          DrawMod.DrawBlock(ref Expression, 0, Conversions.ToInteger(this.ItemSize), this.Width, Conversions.ToInteger(Operators.SubtractObject((object) this.Height, Operators.MultiplyObject((object) 2, this.ItemSize))), 0, 0, 0, 166);
        else
          DrawMod.DrawBlock(ref Expression, 0, 0, this.Width, this.Height, 0, 0, 0, 166);
        int num5 = 20;
        if (this.ListSize >= this.ListObj.ListCount)
          num5 = 0;
        int num6 = 2;
        int num7 = 1;
        if (!this.DoTopAndBottom)
        {
          num6 = 0;
          num7 = 0;
        }
        int Right = -1;
        int topItem = this.TopItem;
        int num8 = this.TopItem + this.ListSize + num6;
        for (int index = topItem; index <= num8; ++index)
        {
          ++Right;
          if (!(Right == this.ListSize + 2 & this.DoTopAndBottom))
          {
            if ((Right + 10) % 2 == 0)
            {
              if (this.ListSelect == index - num7 & this.ListSelect > -1 & this.Highlight)
                DrawMod.DrawBlockGradient2(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width - num5, Conversions.ToInteger(this.ItemSize), Color.FromArgb(100, 100, 155, 100), Color.FromArgb(150, 100, 155, 100));
            }
            else if (this.ListSelect == index - num7 & this.ListSelect > -1 & this.Highlight)
              DrawMod.DrawBlockGradient2(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width - num5, Conversions.ToInteger(this.ItemSize), Color.FromArgb(100, 100, 155, 100), Color.FromArgb(150, 100, 155, 100));
          }
          if (Right == 0 & this.DoTopAndBottom)
          {
            if (Strings.Len(this.Header) > 0)
            {
              SizeF sizeF3 = Expression.MeasureString(this.Header, this.ownfont2);
              if (this.HeaderCenter)
                DrawMod.DrawText(ref Expression, this.Header, this.ownfont2, (int) Math.Round((double) this.Width / 2.0 - (double) sizeF3.Width / 2.0), Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset), (object) 1)));
              else
                DrawMod.DrawText(ref Expression, this.Header, this.ownfont2, this.LeftTextOffset, Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset), (object) 1)));
            }
            if (this.TopItem > 0)
            {
              if (num5 > 0)
              {
                ref Graphics local11 = ref Expression;
                bitmap = BitmapStore.GetBitmap(this.game.LISTUP);
                ref Bitmap local12 = ref bitmap;
                int x = this.Width - 20;
                DrawMod.DrawSimple(ref local11, ref local12, x, 3);
              }
            }
            else if (num5 > 0)
            {
              ref Graphics local13 = ref Expression;
              bitmap = BitmapStore.GetBitmap(this.game.LISTBLOCK);
              ref Bitmap local14 = ref bitmap;
              int x = this.Width - 20;
              DrawMod.DrawSimple(ref local13, ref local14, x, 3);
            }
          }
          else if (Right == this.ListSize + 2 & this.DoTopAndBottom)
          {
            if (this.TopItem + this.ListSize >= this.ListObj.ListCount)
            {
              if (num5 > 0)
              {
                ref Graphics local15 = ref Expression;
                bitmap = BitmapStore.GetBitmap(this.game.LISTBLOCK);
                ref Bitmap local16 = ref bitmap;
                int x = this.Width - 20;
                int integer = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) 3));
                DrawMod.DrawSimple(ref local15, ref local16, x, integer);
              }
            }
            else if (num5 > 0)
            {
              ref Graphics local17 = ref Expression;
              bitmap = BitmapStore.GetBitmap(this.game.LISTDOWN);
              ref Bitmap local18 = ref bitmap;
              int x = this.Width - 20;
              int integer = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) 3));
              DrawMod.DrawSimple(ref local17, ref local18, x, integer);
            }
          }
          else if (index - num7 <= this.ListObj.ListCount)
          {
            if (!this.ShowPair)
            {
              if (this.ListObj.ListColor[index - num7] < 0)
                DrawMod.DrawText(ref Expression, this.ListObj.ListName[index - num7], this.OwnFont, this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
              else
                DrawMod.DrawTextColoured(ref Expression, this.ListObj.ListName[index - num7], this.OwnFont, this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)), Color.FromArgb((int) byte.MaxValue, 210, 170, 100));
            }
            else
            {
              if (this.ListSize < this.ListObj.ListCount)
                DrawMod.DrawRectangle(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width - 21, Conversions.ToInteger(this.ItemSize), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
              else
                DrawMod.DrawRectangle(ref Expression, 0, Conversions.ToInteger(Operators.MultiplyObject(this.ItemSize, (object) Right)), this.Width - 1, Conversions.ToInteger(this.ItemSize), (int) color.R, (int) color.G, (int) color.B, (int) byte.MaxValue);
              DrawMod.DrawText(ref Expression, this.ListObj.ListName[index - num7], this.OwnFont, this.LeftTextOffset, Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
              if (Operators.CompareString(this.ListObj.ListValue4[index - num7], "", false) != 0)
              {
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue[index - num7], this.OwnFont, this.Width - num5 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue2[index - num7], this.OwnFont, (int) Math.Round((double) (this.Width - num5) - ((double) this.ValueWidth * 0.75 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue3[index - num7], this.OwnFont, (int) Math.Round((double) (this.Width - num5) - ((double) this.ValueWidth * 0.5 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue4[index - num7], this.OwnFont, (int) Math.Round((double) (this.Width - num5) - ((double) this.ValueWidth * 0.25 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
              }
              else if (Operators.CompareString(this.ListObj.ListValue3[index - num7], "", false) != 0)
              {
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue[index - num7], this.OwnFont, this.Width - num5 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue2[index - num7], this.OwnFont, (int) Math.Round((double) (this.Width - num5) - ((double) this.ValueWidth * 0.66 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue3[index - num7], this.OwnFont, (int) Math.Round((double) (this.Width - num5) - ((double) this.ValueWidth * 0.33 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
              }
              else if (Operators.CompareString(this.ListObj.ListValue2[index - num7], "", false) != 0)
              {
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue[index - num7], this.OwnFont, this.Width - num5 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue2[index - num7], this.OwnFont, (int) Math.Round((double) (this.Width - num5) - ((double) this.ValueWidth / 2.0 - 3.0)), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
              }
              else
                DrawMod.DrawText(ref Expression, this.ListObj.ListValue[index - num7], this.OwnFont, this.Width - num5 - (this.ValueWidth - 3), Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject(this.ItemSize, (object) Right), (object) this.ItemFontOffset)));
            }
          }
        }
      }
      int Left = Conversions.ToInteger(Operators.MultiplyObject((object) (this.ListSize + 1), this.ItemSize));
      float num9 = this.ListObj.ListCount <= 0 ? 1f : (float) this.ListSize / (float) this.ListObj.ListCount;
      if ((double) num9 > 1.0)
        num9 = 1f;
      int num10 = (int) Math.Round((double) Conversion.Int((float) Left * num9));
      float num11 = this.ListObj.ListCount <= 0 ? 0.0f : (float) this.TopItem / (float) this.ListObj.ListCount;
      if ((double) num11 > 1.0)
        num11 = 1f;
      int num12 = (int) Math.Round((double) Conversion.Int((float) Left * num11));
      if (this.DoTopAndBottom)
        num12 = Conversions.ToInteger(Operators.AddObject((object) num12, this.ItemSize));
      if (Left < 5)
        Left = 5;
      if (Operators.ConditionalCompareObjectGreater((object) (num12 + num10), Operators.AddObject((object) Left, this.ItemSize), false))
        num10 = Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject((object) Left, this.ItemSize), (object) num12));
      if (this.ListSize < this.ListObj.ListCount)
      {
        int x = this.Width - 18;
        int y = num12 + 3;
        int width = 16;
        int num13 = num10 - 2;
        if (!this.MarcStyle)
        {
          ref Graphics local19 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
          ref Bitmap local20 = ref bitmap;
          rectangle2 = new Rectangle(0, 8, 28, 12);
          Rectangle srcrect1 = rectangle2;
          rectangle1 = new Rectangle(x, y + 8, width, num13 - 16);
          Rectangle destrect1 = rectangle1;
          DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect1, destrect1);
          ref Graphics local21 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
          ref Bitmap local22 = ref bitmap;
          rectangle2 = new Rectangle(0, 0, 28, 8);
          Rectangle srcrect2 = rectangle2;
          rectangle1 = new Rectangle(x, y, width, 8);
          Rectangle destrect2 = rectangle1;
          DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect2, destrect2);
          ref Graphics local23 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
          ref Bitmap local24 = ref bitmap;
          rectangle2 = new Rectangle(0, 28, 28, 8);
          Rectangle srcrect3 = rectangle2;
          rectangle1 = new Rectangle(x, y + num13 - 8, 28, 8);
          Rectangle destrect3 = rectangle1;
          DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect3, destrect3);
        }
        else
        {
          ref Graphics local25 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
          ref Bitmap local26 = ref bitmap;
          rectangle2 = new Rectangle(0, 2, 20, 6);
          Rectangle srcrect4 = rectangle2;
          rectangle1 = new Rectangle(x, 2, 20, this.Height - 4);
          Rectangle destrect4 = rectangle1;
          DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect4, destrect4);
          ref Graphics local27 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
          ref Bitmap local28 = ref bitmap;
          rectangle2 = new Rectangle(0, 0, 20, 2);
          Rectangle srcrect5 = rectangle2;
          rectangle1 = new Rectangle(x, 0, 20, 2);
          Rectangle destrect5 = rectangle1;
          DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect5, destrect5);
          ref Graphics local29 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
          ref Bitmap local30 = ref bitmap;
          rectangle2 = new Rectangle(0, 8, 20, 2);
          Rectangle srcrect6 = rectangle2;
          rectangle1 = new Rectangle(x, this.Height - 2, 20, 2);
          Rectangle destrect6 = rectangle1;
          DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect6, destrect6);
          ref Graphics local31 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
          ref Bitmap local32 = ref bitmap;
          rectangle2 = new Rectangle(0, 2, 20, 6);
          Rectangle srcrect7 = rectangle2;
          rectangle1 = new Rectangle(x, y + 2, width, num13 - 2);
          Rectangle destrect7 = rectangle1;
          DrawMod.DrawSimplePart2(ref local31, ref local32, srcrect7, destrect7);
          ref Graphics local33 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
          ref Bitmap local34 = ref bitmap;
          rectangle2 = new Rectangle(0, 0, 20, 2);
          Rectangle srcrect8 = rectangle2;
          rectangle1 = new Rectangle(x, y, width, 2);
          Rectangle destrect8 = rectangle1;
          DrawMod.DrawSimplePart2(ref local33, ref local34, srcrect8, destrect8);
          ref Graphics local35 = ref Expression;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
          ref Bitmap local36 = ref bitmap;
          rectangle2 = new Rectangle(0, 8, 20, 2);
          Rectangle srcrect9 = rectangle2;
          rectangle1 = new Rectangle(x, y + num13 - 2, 10, 2);
          Rectangle destrect9 = rectangle1;
          DrawMod.DrawSimplePart2(ref local35, ref local36, srcrect9, destrect9);
        }
      }
      if (!this.MarcStyle)
      {
        if (this.DoTopAndBottom)
        {
          if (this.ListSize < this.ListObj.ListCount)
            DrawMod.DrawRectangle(ref Expression, 0, Conversions.ToInteger(this.ItemSize), this.Width - 21, Conversions.ToInteger(Operators.SubtractObject((object) this.Height, Operators.MultiplyObject(this.ItemSize, (object) 2))), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          else
            DrawMod.DrawRectangle(ref Expression, 0, Conversions.ToInteger(this.ItemSize), this.Width - 1, Conversions.ToInteger(Operators.SubtractObject((object) this.Height, Operators.MultiplyObject(this.ItemSize, (object) 2))), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
        else if (this.ListSize < this.ListObj.ListCount)
          DrawMod.DrawRectangle(ref Expression, 0, 0, this.Width - 21, this.Height - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        else
          DrawMod.DrawRectangle(ref Expression, 0, 0, this.Width - 1, this.Height - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      }
      if (this.MarcStyle)
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref Expression, 0, 0, this.Width, this.Height, -1, -1);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override void ShiftDown()
    {
      ++this.ListSelect;
      if ((double) this.ListSelect > (double) this.TopItem + (double) this.ListSize / 2.0)
        ++this.TopItem;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (this.ListSelect > this.ListObj.ListCount)
        this.ListSelect = this.ListObj.ListCount;
      if (0 > this.TopItem)
        this.TopItem = 0;
      if (0 <= this.ListSelect)
        return;
      this.ListSelect = 0;
    }

    public override void ShiftUp()
    {
      --this.ListSelect;
      if ((double) (this.ListSelect - this.TopItem) < (double) this.ListSize / 2.0)
        --this.TopItem;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (this.ListSelect > this.ListObj.ListCount)
        this.ListSelect = this.ListObj.ListCount;
      if (0 > this.TopItem)
        this.TopItem = 0;
      if (0 <= this.ListSelect)
        return;
      this.ListSelect = 0;
    }

    public override int GetSelect() => this.ListObj.ListData[this.ListSelect];

    public override int GetTopItem() => this.TopItem;

    public override int Click(int x, int y, int b = 1)
    {
      int Left = y;
      y = Conversions.ToInteger(Conversion.Int(Operators.DivideObject((object) y, this.ItemSize)));
      this.Scroller = true;
      int num1 = 0;
      int num2 = 2;
      int num3 = 1;
      if (!this.DoTopAndBottom)
      {
        num2 = 1;
        num1 = -1;
        num3 = 0;
      }
      int num4 = 20;
      if (this.ListSize >= this.ListObj.ListCount)
        num4 = 0;
      if (y > num1 & y < this.ListSize + num2)
      {
        if (x <= this.Width - num4)
        {
          y -= num3;
          y += this.TopItem;
          this.clickscroll = 0;
          if (y > this.ListObj.ListCount)
            return -1;
          this.ListSelect = y;
          return this.ListObj.ListData[this.ListSelect];
        }
        this.clickscroll = 1;
        int integer = Conversions.ToInteger(Operators.MultiplyObject((object) (this.ListSize + 1), this.ItemSize));
        if (this.DoTopAndBottom)
          Left = Conversions.ToInteger(Operators.SubtractObject((object) Left, this.ItemSize));
        if (Left < 1)
          Left = 1;
        int num5 = (int) Math.Round((double) (int) Math.Round((double) ((float) Left / (float) integer * (float) this.ListObj.ListCount)) - (double) this.ListSize / 2.0);
        if (0 > num5)
          num5 = 0;
        this.TopItem = num5;
        if (this.TopItem > this.ListObj.ListCount - this.ListSize)
          this.TopItem = this.ListObj.ListCount - this.ListSize;
        if (0 > this.TopItem)
          this.TopItem = 0;
        return -1;
      }
      if (y == 0 & this.DoTopAndBottom)
      {
        --this.TopItem;
        this.clickscroll = 0;
        if (0 > this.TopItem)
          this.TopItem = 0;
        return -1;
      }
      if (!(y == this.ListSize + 2 & this.DoTopAndBottom))
        return -1;
      ++this.TopItem;
      this.clickscroll = 0;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      return -1;
    }

    public override int HandleMouseUp(int x, int y)
    {
      if (!(this.clickscroll == 1 | this.Scroller))
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    public override int HandleBLOCKEDMouseUp(int x, int y)
    {
      if (!(this.clickscroll == 1 | this.Scroller))
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    public override bool MouseMove(int x, int y)
    {
      int Left = y;
      y = Conversions.ToInteger(Conversion.Int(Operators.DivideObject((object) y, this.ItemSize)));
      int num1 = 0;
      int num2 = 2;
      int num3 = 1;
      if (!this.DoTopAndBottom)
      {
        num2 = 1;
        num1 = -1;
        num3 = 0;
      }
      int num4 = 20;
      if (this.ListSize >= this.ListObj.ListCount)
        num4 = 0;
      if (!(y > num1 & y < this.ListSize + num2 & this.clickscroll == 1))
        return false;
      int integer = Conversions.ToInteger(Operators.MultiplyObject((object) (this.ListSize + 1), this.ItemSize));
      if (this.DoTopAndBottom)
        Left = Conversions.ToInteger(Operators.SubtractObject((object) Left, this.ItemSize));
      if (Left < 1)
        Left = 1;
      int num5 = (int) Math.Round((double) (int) Math.Round((double) ((float) Left / (float) integer * (float) this.ListObj.ListCount)) - (double) this.ListSize / 2.0);
      if (0 > num5)
        num5 = 0;
      this.TopItem = num5;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      return true;
    }
  }
}
