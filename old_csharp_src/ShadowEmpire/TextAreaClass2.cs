// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextAreaClass2
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
  public class TextAreaClass2 : SubPartClass
  {
    private int ListSize;
    private int ListSelect;
    public int TopItem;
    public ListClass[] ListObj;
    private int Tab;
    private string[] TabName;
    private int TabCount;
    private Font OwnFont;
    private int ItemSize;
    private int Width;
    private int Height;
    private GameClass game;
    private Bitmap backbitmap;
    private int bx;
    private int by;
    private Color fontcol;
    private Color fontColHigh;
    private int clickscroll;
    public Rectangle[] TabRect;
    private bool WithoutScrollbars;
    public bool WithoutFrame;
    public bool centerit;
    public bool shadow;
    public bool useEncy;
    private bool minimalHeight;
    public int[,,] encyId;
    public bool darkerFrame;
    private StringListClass tStringList;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public override bool HandleTimerWheel(int x, int y, ref WindowClass tWindow)
    {
      if (this.game.EditObj.MouseWheel > 0)
      {
        int mouseWheel = this.game.EditObj.MouseWheel;
        for (int index = 1; index <= mouseWheel; ++index)
          this.ShiftUp();
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return true;
      }
      if (this.game.EditObj.MouseWheel >= 0)
        return false;
      int mouseWheel1 = this.game.EditObj.MouseWheel;
      for (int index = -1; index >= mouseWheel1; index += -1)
        this.ShiftDown();
      this.game.EditObj.MouseWheel = 0;
      this.game.EditObj.MouseWheelWait = 4;
      return true;
    }

    public TextAreaClass2(
      GameClass tgame,
      int twidth,
      int trows,
      Font tfont,
      string tText,
      int tItemSize = 16,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tWithoutScrollbars = false,
      bool tWithoutFrame = false,
      int tfontcol = 0,
      bool tcenterit = false,
      int colr = 0,
      int colg = 0,
      int colb = 0,
      int cola = 0,
      bool tshadow = true,
      bool tUseEncy = false,
      bool tminimalHeight = false,
      bool tUseMin40width = true,
      bool tDarkerFrame = false)
      : base(twidth, 30 + (trows + 1) * tItemSize)
    {
      this.ListObj = new ListClass[10];
      this.TabName = new string[10];
      this.TabRect = new Rectangle[100];
      this.encyId = new int[2, 2, 2];
      if (tgame.Data.Product >= 7)
      {
        tText = tText.Replace("<br>", "\r\n");
        tText = tText.Replace("<BR>", "\r\n");
      }
      if (twidth == 0)
        return;
      if (!Information.IsNothing((object) tText) && tText.Length > 2)
      {
        while (tText.IndexOf("\r\n", tText.Length - 2) > 0)
        {
          tText = Strings.Left(tText, tText.Length - 2);
          if (tText.Length <= 2)
            break;
        }
      }
      this.minimalHeight = tminimalHeight;
      this.ItemSize = tItemSize;
      this.Width = twidth;
      this.useEncy = tUseEncy;
      this.Height = 30 + (trows + 1) * tItemSize;
      if (this.minimalHeight)
        this.Height = (trows + 1) * tItemSize;
      this.game = tgame;
      this.shadow = tshadow;
      this.darkerFrame = tDarkerFrame;
      this.centerit = tcenterit;
      this.WithoutFrame = tWithoutFrame;
      this.WithoutScrollbars = tWithoutScrollbars;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        if (!Information.IsNothing((object) this.backbitmap))
          this.backbitmap.Dispose();
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.fontcol = tfontcol != 0 ? Color.Black : Color.White;
      if (cola > 0)
        this.fontcol = Color.FromArgb(cola, colr, colg, colb);
      this.fontColHigh = this.fontcol;
      this.bx = bbx;
      this.by = bby;
      SizeF sizeF = new SizeF();
      string[] strArray1 = new string[10];
      this.Tab = 0;
      this.TabCount = -1;
      this.TabName[0] = "";
      int num1 = 1;
      if (Information.IsNothing((object) tText))
        tText = "";
      tText = tText.Replace("\t", " ");
      int num2 = 0;
      int num3 = 0;
      while (num1 == 1)
      {
        num1 = 0;
        int num4 = Strings.InStr(tText, "[tab]");
        if (num4 > 0)
        {
          int num5 = Strings.InStr(tText, "[/tab]");
          if (num5 > num4 & num5 > 0)
          {
            string str1 = Strings.Mid(tText, num4 + Strings.Len("[tab]"), num5 - (num4 + Strings.Len("[tab]")));
            int num6 = Strings.InStr(str1, ",");
            if (num6 > 0)
            {
              ++this.TabCount;
              this.TabName[this.TabCount] = Strings.Left(str1, num6 - 1);
              string str2 = Strings.Mid(str1, num6 + 1);
              strArray1[this.TabCount] = str2;
              if (str2.Length > num2)
                num2 = str2.Length;
              int startIndex = 0;
              int num7 = 0;
              for (; str2.IndexOf("\r\n", startIndex) > 0; startIndex = str2.IndexOf("\r\n", startIndex) + 1)
                ++num7;
              if (num7 > num3)
                num3 = num7;
              tText = Strings.Left(tText, num4 - 1) + Strings.Mid(tText, num5 + Strings.Len("[/tab]"));
              num1 = 1;
            }
          }
        }
      }
      if (this.TabCount == -1)
      {
        this.TabCount = 0;
        strArray1[0] = tText;
        string str = tText;
        if (str.Length > num2)
          num2 = str.Length;
        int startIndex1 = 0;
        int num8 = 0;
        for (; str.IndexOf('\n'.ToString(), startIndex1) > 0; startIndex1 = str.IndexOf('\n'.ToString(), startIndex1) + 1)
          ++num8;
        for (int startIndex2 = 0; str.IndexOf("\r\n", startIndex2) > 0; startIndex2 = str.IndexOf("\r\n", startIndex2) + 1)
          ++num8;
        if (num8 > num3)
          num3 = num8;
      }
      if (this.useEncy)
      {
        this.encyId = (int[,,]) null;
        this.encyId = new int[this.TabCount + 1 + 1, (int) Math.Round((double) (1 + num3) + Math.Ceiling((double) num2 / 20.0)) + 1, 201];
      }
      else
        this.encyId = (int[,,]) null;
      int[] numArray1 = new int[500];
      this.tStringList = (StringListClass) null;
      if ((double) this.game.Data.RuleVar[951] > 0.0)
      {
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[951]));
        if (stringListById > -1)
        {
          this.tStringList = this.game.Data.StringListObj[stringListById].Clone();
          this.tStringList.ID = -1;
        }
      }
      int tabCount = this.TabCount;
      for (int index1 = 0; index1 <= tabCount; ++index1)
      {
        this.ListObj[index1] = new ListClass();
        Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.OwnFont = tfont != null ? tfont : new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel);
        int num9 = 1;
        this.clickscroll = 0;
        tText = strArray1[index1];
        int num10 = 0;
        if (this.game.Data.Product >= 7 && Strings.InStr(tText, "<<") > 0 & Strings.InStr(tText, ">>") > 0)
        {
          SimpleStringList simpleStringList = new SimpleStringList();
          while (Strings.InStr(tText, "<<") > 0 & Strings.InStr(tText, ">>") > 0)
          {
            int Start = Strings.InStr(tText, "<<");
            int num11 = Strings.InStr(tText, ">>");
            string str = Strings.Mid(tText, Start, num11 - Start + 2);
            string oldValue = str;
            string[] strArray2 = str.Replace("<<", "").Replace(">>", "").Split(';');
            if (strArray2.Length >= 2)
            {
              this.tStringList.AddRowWithData(strArray2[0], strArray2[1], strArray2[2], 0.ToString(), "", "OVERRULE", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
              tText = tText.Replace(oldValue, strArray2[0]);
            }
          }
        }
        int[] numArray2 = this.game.HandyFunctionsObj.RecodeTextStringToEncyIdsNew(tText, ref this.tStringList);
        if (this.game.Data.Product >= 7 && Strings.InStr(tText, "{", CompareMethod.Text) > 0)
        {
          string str = "";
          int[] arySrc = new int[numArray2.GetUpperBound(0) + 1];
          bool flag = false;
          int index2 = 0;
          int length = tText.Length;
          for (int Start = 1; Start <= length; ++Start)
          {
            string Left = Strings.Mid(tText, Start, 1);
            if (Operators.CompareString(Left, "{", false) == 0)
              flag = true;
            if (!flag)
            {
              ++index2;
              str += Left;
              arySrc[index2] = numArray2[Start];
            }
            if (Operators.CompareString(Left, "}", false) == 0)
              flag = false;
          }
          tText = str;
          numArray2 = (int[]) Utils.CopyArray((Array) arySrc, (Array) new int[index2 + 1]);
        }
        int num12 = 40;
        if (this.WithoutScrollbars)
          num12 = 40;
        if (!tUseMin40width)
          num12 = 0;
        while (Strings.Len(tText) > 0)
        {
          int num13 = 1;
          string str3 = "";
          bool flag = false;
          while (num13 == 1)
          {
            int num14 = Strings.InStr(tText, "\r\n");
            int num15 = Strings.InStr(tText, " ");
            if (num15 == 0)
              num15 = 9999999;
            int num16;
            if (num14 < num15 & num14 > 0)
            {
              int num17 = num14;
              num13 = 0;
              num16 = 0;
              if (num17 != 1)
              {
                if ((double) graphics.MeasureString(str3 + Strings.Left(tText, num17 - 1), this.OwnFont).Width <= (double) (this.Width - num12))
                  str3 += Strings.Left(tText, num17 - 1);
                else if (this.game.Data.Product >= 6)
                {
                  if ((double) graphics.MeasureString(Strings.Left(tText, num17 - 1), this.OwnFont).Width > (double) (this.Width - num12))
                  {
                    if (Operators.CompareString(str3, "", false) == 0)
                      str3 += Strings.Left(tText, num17 - 1);
                  }
                  else
                    num16 = 1;
                }
              }
              if (num16 == 0)
              {
                if (num17 < Strings.Len(tText))
                {
                  tText = Strings.Mid(tText, num17 + 2);
                  flag = true;
                }
                else
                  tText = "";
              }
            }
            else
            {
              int Length = Strings.InStr(tText, " ");
              string str4 = Length <= 0 ? tText : Strings.Left(tText, Length);
              int num18 = 0;
              num13 = 0;
              if ((double) graphics.MeasureString(str3 + str4, this.OwnFont).Width <= (double) (this.Width - num12))
              {
                num9 = 1;
                num18 = 1;
              }
              else if (num9 == 1)
              {
                num9 = 0;
              }
              else
              {
                num9 = 1;
                num18 = 1;
              }
              if (num18 == 1)
              {
                str3 += str4;
                if (Length > 0)
                {
                  if (Strings.Len(tText) >= Length + 1)
                  {
                    tText = Strings.Mid(tText, Length + 1);
                    num13 = 1;
                  }
                  else
                  {
                    tText = "";
                    num13 = 0;
                  }
                }
                else
                {
                  tText = "";
                  num13 = 0;
                }
              }
            }
            if (this.game.Data.Product >= 6 & num16 == 1)
              break;
          }
          this.ListObj[index1].add(str3, 0);
          if (this.useEncy)
          {
            int index3 = 0;
            if (num10 == 0)
              num10 = 1;
            int num19 = num10;
            int num20 = num10 + str3.Length - 1;
            for (int index4 = num19; index4 <= num20; ++index4)
            {
              ++index3;
              if (index3 <= this.encyId.GetUpperBound(2))
              {
                try
                {
                  this.encyId[index1, this.ListObj[index1].ListCount, index3] = numArray2[index4];
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  this.ListSize = this.encyId.GetUpperBound(2);
                  if (this.TabCount >= 0)
                    --this.ListSize;
                  this.ListSelect = -1;
                  this.TopItem = 0;
                  this.MouseOver = true;
                  ProjectData.ClearProjectError();
                  return;
                }
              }
            }
            num10 += str3.Length;
            if (flag)
              num10 += 2;
          }
        }
      }
      this.ListSize = trows;
      if (this.TabCount >= 0)
        --this.ListSize;
      this.ListSelect = -1;
      this.TopItem = 0;
      this.MouseOver = true;
    }

    public override int HeightUsed() => (this.ListObj[this.Tab].ListCount + 1) * this.ItemSize;

    public int WidthUsed()
    {
      SizeF sizeF = new SizeF();
      return this.ListObj[0].ListCount < 0 ? 0 : (int) Math.Round((double) Graphics.FromImage((Image) this.OwnBitmap).MeasureString(this.ListObj[0].ListName[0], this.OwnFont).Width);
    }

    public override void HandleToolTip(int x, int y)
    {
      this.game.EditObj.TipColor = 0;
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          this.game.EditObj.TipColor = this.MouseData[index];
          break;
        }
      }
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      SimpleStringList simpleStringList = new SimpleStringList();
      this.ClearMouse();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      if (!this.WithoutFrame)
      {
        if (this.darkerFrame)
        {
          Color c1 = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) this.game.MarcCol1.R / 2.0), (int) Math.Round((double) this.game.MarcCol1.G / 2.0), (int) Math.Round((double) this.game.MarcCol1.B / 2.0));
          Color c2 = Color.FromArgb((int) byte.MaxValue, (int) Math.Round((double) this.game.MarcCol2.R / 2.0), (int) Math.Round((double) this.game.MarcCol2.G / 2.0), (int) Math.Round((double) this.game.MarcCol2.B / 2.0));
          DrawMod.DrawBlockGradient2(ref Expression, 0, this.ItemSize, this.Width - 10, this.Height - this.ItemSize, c1, c2);
        }
        else
          DrawMod.DrawBlockGradient2(ref Expression, 0, this.ItemSize, this.Width - 10, this.Height - this.ItemSize, this.game.MarcCol1, this.game.MarcCol2);
      }
      if (this.TabCount < 0)
      {
        Bitmap bitmap;
        return bitmap;
      }
      int num1 = 0;
      int tabCount1 = this.TabCount;
      for (int index = 0; index <= tabCount1; ++index)
      {
        this.TabName[index] = Strings.UCase(this.TabName[index]);
        SizeF sizeF2 = index >= this.TabCount ? Expression.MeasureString(this.TabName[index], DrawMod.TGame.MarcFont5) : Expression.MeasureString(this.TabName[index] + " | ", DrawMod.TGame.MarcFont5);
        num1 = (int) Math.Round((double) ((float) num1 + sizeF2.Width));
      }
      int x1 = (int) Math.Round(Math.Max(0.0, (double) (this.Width - 10 - num1) / 2.0));
      int tabCount2 = this.TabCount;
      SizeF sizeF3;
      for (int index = 0; index <= tabCount2; ++index)
      {
        if (index < this.TabCount)
        {
          if (this.Tab != index)
            DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index] + " | ", DrawMod.TGame.MarcFont5, x1 + 1, 0, Color.White);
          if (index == this.Tab)
          {
            DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index], DrawMod.TGame.MarcFont5, x1 + 1, 0, DrawMod.TGame.MarcCol5);
            sizeF3 = Expression.MeasureString(this.TabName[index], DrawMod.TGame.MarcFont5);
            DrawMod.DrawTextColouredMarc(ref Expression, " | ", DrawMod.TGame.MarcFont5, (int) Math.Round((double) (x1 + 1) + (double) sizeF3.Width - 4.0), 0, Color.White);
          }
          sizeF3 = Expression.MeasureString(this.TabName[index] + " | ", DrawMod.TGame.MarcFont5);
        }
        else
        {
          if (this.Tab != index | this.TabCount == 0)
            DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index], DrawMod.TGame.MarcFont5, x1 + 1, 0, Color.White);
          else if (index == this.Tab)
            DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index], DrawMod.TGame.MarcFont5, x1 + 1, 0, DrawMod.TGame.MarcCol5);
          sizeF3 = Expression.MeasureString(this.TabName[index], DrawMod.TGame.MarcFont5);
        }
        this.TabRect[index] = index >= this.TabCount ? new Rectangle(x1, 0, (int) Math.Round((double) sizeF3.Width), this.ItemSize) : new Rectangle(x1, 0, (int) Math.Round((double) sizeF3.Width - (double) Expression.MeasureString(" | ", DrawMod.TGame.MarcFont5).Width), this.ItemSize);
        x1 = (int) Math.Round((double) ((float) x1 + sizeF3.Width));
      }
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      if (this.minimalHeight)
        num4 = 30;
      if (this.TabCount > 0)
        num2 = -1;
      int topItem = this.TopItem;
      int num5 = this.TopItem + this.ListSize;
      Rectangle rectangle;
      Rectangle trect;
      for (int index1 = topItem; index1 <= num5; ++index1)
      {
        ++num3;
        if (index1 <= this.ListObj[this.Tab].ListCount)
        {
          string str1 = this.ListObj[this.Tab].ListName[index1];
          if (this.WithoutScrollbars && index1 == this.TopItem + this.ListSize + num2 & index1 != this.ListObj[this.Tab].ListCount & this.game.Data.Product < 6)
            str1 = Strings.Left(str1, Math.Max(0, Strings.Len(str1) - 3)) + "...";
          sizeF3 = Expression.MeasureString(this.ListObj[this.Tab].ListName[index1], this.OwnFont);
          int x2 = 15;
          if (this.minimalHeight)
            x2 = 0;
          if (this.centerit)
            x2 = (int) Math.Round((double) this.Width / 2.0 - (double) sizeF3.Width / 2.0);
          int[] ints = new int[200];
          try
          {
            if (this.useEncy)
            {
              int index2 = 1;
              do
              {
                ints[index2] = this.encyId[this.Tab, index1, index2];
                ++index2;
              }
              while (index2 <= 199);
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
          if (this.useEncy & this.game.HandyFunctionsObj.EncyTextStringContainsId(ints))
          {
            int num6 = 0;
            string str2 = "";
            int num7 = -1;
            while (str1.Length > 0)
            {
              bool flag = true;
              string str3 = "";
              int num8 = num7;
              while (flag)
              {
                if (ints[1] != num7 & num7 != -1)
                {
                  flag = false;
                  if (str3.Length <= 0)
                    num7 = ints[1];
                }
                else
                {
                  if (ints[1] != num7 & num7 == -1)
                    num7 = ints[1];
                  str3 += str1.Substring(0, 1);
                  str1 = str1.Substring(1);
                  int index3 = 1;
                  do
                  {
                    ints[index3 - 1] = ints[index3];
                    ++index3;
                  }
                  while (index3 <= 199);
                }
                if (str1.Length < 1)
                  flag = false;
              }
              str2 += str3;
              int tdata = -1;
              if ((str1.Length == 0 | this.game.Data.Product >= 7 | Strings.InStr(str3, "[?") > 0) & num8 == -1 & num7 > -1)
                num8 = num7;
              if (!Information.IsNothing((object) this.tStringList) & num8 > 0 && this.tStringList.Width >= 3)
                tdata = (int) Math.Round(Conversion.Val(this.tStringList.Data[num8 - 1, 3]));
              int num9;
              int num10;
              int num11;
              if (Strings.InStr(str3, "[?") > 0)
              {
                num9 = 32;
                num10 = 38;
                num11 = 8;
              }
              else
              {
                sizeF3 = Expression.MeasureString(str3, this.OwnFont, 9999, StringFormat.GenericDefault);
                num9 = (int) Math.Round((double) sizeF3.Width);
                sizeF3 = Expression.MeasureString("x" + str3 + "x", this.OwnFont, 9999, StringFormat.GenericDefault);
                num10 = (int) Math.Round((double) sizeF3.Width);
                sizeF3 = Expression.MeasureString("xx", this.OwnFont, 9999, StringFormat.GenericDefault);
                num11 = (int) Math.Round((double) sizeF3.Width);
              }
              if (num8 > 0)
              {
                if (Strings.InStr(str3, "[?") > 0)
                {
                  if (this.game.Data.Product >= 7)
                  {
                    if (tdata > 0)
                      DrawMod.DrawBlock(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 15 - 0 - num4, num10 - num11 - 4, Math.Max(16, this.ItemSize) - 6, (int) byte.MaxValue, 170, 50, 148);
                    else
                      DrawMod.DrawBlock(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 15 - 0 - num4, num10 - num11 - 4, Math.Max(16, this.ItemSize) - 6, (int) byte.MaxValue, (int) byte.MaxValue, 0, 64);
                    DrawMod.DrawRectangle(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 15 - 0 - num4, num10 - num11 - 4, Math.Max(16, this.ItemSize) - 6, 0, 0, 0, 224);
                  }
                  else
                  {
                    if (tdata > 0)
                      DrawMod.DrawBlock(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 13 + 1 - num4, num10 - num11 - 4, Math.Max(16, this.ItemSize) - 4, (int) byte.MaxValue, 170, 50, 148);
                    else
                      DrawMod.DrawBlock(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 13 + 1 - num4, num10 - num11 - 4, Math.Max(16, this.ItemSize) - 4, (int) byte.MaxValue, (int) byte.MaxValue, 0, 64);
                    DrawMod.DrawRectangle(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 13 + 1 - num4, num10 - num11 - 4, Math.Max(16, this.ItemSize) - 4, 0, 0, 0, 224);
                  }
                  int num12 = (int) Math.Round(0.0 + ((double) num9 / 2.0 - (double) Expression.MeasureString("?", this.OwnFont, 9999, StringFormat.GenericDefault).Width / 2.0));
                  string tstring = "?";
                  if (!this.shadow)
                    DrawMod.DrawTextColouredNicely(ref Expression, tstring, this.OwnFont, num12 + x2 + num6, this.ItemSize * num3 + 13 - num4, this.fontColHigh);
                  else
                    DrawMod.DrawTextColouredMarc(ref Expression, tstring, this.OwnFont, num12 + x2 + num6, this.ItemSize * num3 + 13 - num4, this.fontColHigh);
                }
                else
                {
                  string str4 = Strings.Left(str3, 1).ToUpper() + Strings.Mid(str3, 2);
                  if (this.game.Data.Product >= 7)
                  {
                    if (simpleStringList.FindNr(str4) == -1)
                    {
                      DrawMod.DrawBlock(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 13 - num4 + (int) Math.Round((double) this.OwnFont.Height * 0.8), num10 - num11 + 1, 2, 55, 155, 155, 128);
                      simpleStringList.Add(str4, 0);
                    }
                  }
                  else
                    DrawMod.DrawBlock(ref Expression, x2 + num6 + 2, this.ItemSize * num3 + 13 - num4 + (int) Math.Round((double) this.OwnFont.Height * 0.8), num10 - num11 + 1, 2, 55, 155, 155, 128);
                  if (!this.shadow)
                    DrawMod.DrawTextColouredNicely(ref Expression, str4, this.OwnFont, x2 + num6, this.ItemSize * num3 + 13 - num4, this.fontColHigh);
                  else
                    DrawMod.DrawTextColouredMarc(ref Expression, str4, this.OwnFont, x2 + num6, this.ItemSize * num3 + 13 - num4, this.fontColHigh);
                }
              }
              else if (!this.shadow)
                DrawMod.DrawTextColouredNicely(ref Expression, str3, this.OwnFont, x2 + num6, this.ItemSize * num3 + 13 - num4, this.fontcol);
              else
                DrawMod.DrawTextColouredMarc(ref Expression, str3, this.OwnFont, x2 + num6, this.ItemSize * num3 + 13 - num4, this.fontcol);
              if (num8 > 0)
              {
                string ttitle = this.tStringList.Data[num8 - 1, 1];
                string ttext = this.tStringList.Data[num8 - 1, 2];
                if (this.tStringList.Width >= 5 & this.game.Data.Product >= 6)
                {
                  string currentName = this.tStringList.Data[num8 - 1, 0];
                  string str5 = this.tStringList.Data[num8 - 1, 4];
                  string Left = this.tStringList.Data[num8 - 1, 5];
                  if (str5.Length > 0)
                    ttext = ttext + "\r\n\r\n" + str5;
                  if (Left.Length > 0 & Operators.CompareString(Left, "OVERRULE", false) != 0)
                    ttext = ttext + "\r\n\r\n" + Left;
                  ttext = this.game.HandyFunctionsObj.CustomMouseOverLookups(ttext.Replace("<br>", "\r\n"), currentName);
                }
                rectangle = new Rectangle(x2 + num6, this.ItemSize * num3 + 13 - num4, num10 - num11, this.ItemSize);
                trect = rectangle;
                this.AddMouse(ref trect, ttitle, ttext, tdata);
                num6 += num10 - num11;
              }
              else
                num6 += num9;
            }
          }
          else if (!this.shadow)
            DrawMod.DrawTextColouredNicely(ref Expression, str1, this.OwnFont, x2, this.ItemSize * num3 + 13 - num4, this.fontcol);
          else
            DrawMod.DrawTextColouredMarc(ref Expression, str1, this.OwnFont, x2, this.ItemSize * num3 + 13 - num4, this.fontcol);
        }
      }
      if (!this.WithoutFrame)
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref Expression, 0, this.ItemSize, this.Width - 10, this.Height - this.ItemSize, -1, -1);
      if (!this.WithoutScrollbars && this.ListSize < this.ListObj[this.Tab].ListCount)
      {
        int num13 = this.Height - (this.ItemSize + 50 + 10);
        float num14 = this.ListObj[this.Tab].ListCount <= 0 ? 1f : (float) this.TopItem / (float) (this.ListObj[this.Tab].ListCount - this.ListSize);
        if ((double) num14 > 1.0)
          num14 = 1f;
        int num15 = (int) Math.Round((double) Conversion.Int((float) num13 * num14));
        int x3 = this.Width - 20;
        int num16 = this.ItemSize + 25 + num15;
        ref Graphics local1 = ref Expression;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local2 = ref bitmap;
        trect = new Rectangle(0, 3, 20, 4);
        Rectangle srcrect1 = trect;
        rectangle = new Rectangle(x3, 28 + this.ItemSize, 20, this.Height - (56 + this.ItemSize));
        Rectangle destrect1 = rectangle;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local4 = ref bitmap;
        trect = new Rectangle(0, 0, 20, 3);
        Rectangle srcrect2 = trect;
        rectangle = new Rectangle(x3, this.ItemSize + 25, 20, 3);
        Rectangle destrect2 = rectangle;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local6 = ref bitmap;
        trect = new Rectangle(0, 7, 20, 3);
        Rectangle srcrect3 = trect;
        rectangle = new Rectangle(x3, this.Height - 28, 20, 3);
        Rectangle destrect3 = rectangle;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTUP);
        ref Bitmap local8 = ref bitmap;
        int x4 = x3;
        int y1 = this.ItemSize + 16;
        DrawMod.DrawSimple(ref local7, ref local8, x4, y1);
        ref Graphics local9 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTDOWN);
        ref Bitmap local10 = ref bitmap;
        int x5 = x3;
        int y2 = this.Height - 25;
        DrawMod.DrawSimple(ref local9, ref local10, x5, y2);
        ref Graphics local11 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
        ref Bitmap local12 = ref bitmap;
        int x6 = x3;
        int y3 = num16;
        DrawMod.DrawSimple(ref local11, ref local12, x6, y3);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    public override void ShiftLeft()
    {
      --this.Tab;
      this.TopItem = 0;
      if (this.Tab > this.TabCount)
        this.Tab = this.TabCount;
      if (0 <= this.Tab)
        return;
      this.Tab = 0;
    }

    public override void ShiftRight()
    {
      ++this.Tab;
      this.TopItem = 0;
      if (this.Tab > this.TabCount)
        this.Tab = this.TabCount;
      if (0 <= this.Tab)
        return;
      this.Tab = 0;
    }

    public override void ShiftDown()
    {
      ++this.TopItem;
      if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
        this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
      if (0 <= this.TopItem)
        return;
      this.TopItem = 0;
    }

    public override void ShiftUp()
    {
      --this.TopItem;
      if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
        this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
      if (0 <= this.TopItem)
        return;
      this.TopItem = 0;
    }

    public override int HandleMouseUp(int x, int y)
    {
      if (!(this.clickscroll == 1 | this.Scroller))
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    public override int Click(int x, int y, int b = 1)
    {
      int num1 = y;
      if (this.TabCount > 0 & num1 < this.ItemSize)
      {
        float tabCount = (float) this.TabCount;
        for (float a = 0.0f; (double) a <= (double) tabCount; ++a)
        {
          if (x >= this.TabRect[(int) Math.Round((double) a)].X & y >= this.TabRect[(int) Math.Round((double) a)].Y && x <= this.TabRect[(int) Math.Round((double) a)].X + this.TabRect[(int) Math.Round((double) a)].Width & y <= this.TabRect[(int) Math.Round((double) a)].Y + this.TabRect[(int) Math.Round((double) a)].Height)
          {
            this.Tab = (int) Math.Round((double) a);
            this.TopItem = 0;
            return -1;
          }
        }
      }
      else if (x > this.Width - 20)
      {
        if (y >= this.ItemSize + 16 & y <= this.ItemSize + 16 + 10)
        {
          --this.TopItem;
          this.clickscroll = 0;
          if (0 > this.TopItem)
            this.TopItem = 0;
          return -1;
        }
        if (y > this.Height - 25 & y < this.Height - 25 + 10)
        {
          ++this.TopItem;
          this.clickscroll = 0;
          if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
            this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
          if (0 > this.TopItem)
            this.TopItem = 0;
          return -1;
        }
        this.clickscroll = 1;
        this.Scroller = true;
        int num2 = this.Height - (this.ItemSize + 50);
        int num3 = num1 - (this.ItemSize + 25);
        if (num3 < 1)
          num3 = 1;
        this.TopItem = (int) Math.Round((double) ((float) num3 / (float) num2 * (float) (this.ListObj[this.Tab].ListCount - (this.ListSize - 1))));
        if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
          this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
        if (0 > this.TopItem)
          this.TopItem = 0;
        return -1;
      }
      int num4;
      return num4;
    }

    public override bool MouseMove(int x, int y)
    {
      int num1 = y;
      if (this.clickscroll != 1)
        return false;
      this.clickscroll = 1;
      this.Scroller = true;
      int num2 = this.Height - (this.ItemSize + 50);
      int num3 = num1 - (this.ItemSize + 25);
      if (num3 < 1)
        num3 = 1;
      this.TopItem = (int) Math.Round((double) ((float) num3 / (float) num2 * (float) (this.ListObj[this.Tab].ListCount - (this.ListSize - 1))));
      if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
        this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      return true;
    }
  }
}
