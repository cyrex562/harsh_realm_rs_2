// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UDSPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class UDSPartClass : SubPartClass
  {
    private Font OwnFont;
    private int Width;
    private int Height;
    private GameClass game;
    private Bitmap backbitmap;
    private int bx;
    private int by;
    private int clickscroll;
    public string texty;
    public int curY;
    private int maxY;
    private int lastY;
    private Bitmap paper;
    private bool alwaysBlockScrollBar;
    private bool justCheckHeight;
    private int lastElementHigh;
    private bool allGray;
    private bool alwaysShowBackground;
    public UDSData dyn;
    private int scrollelementclicked;
    private int scrollelementclicked2;
    private Bitmap[] bmp;
    private int[] bmpLink;
    private Bitmap[] backBmp;
    private int[] backBmpLink;
    private int backBitmapCounter;
    private bool noBackground;

    public override bool UseSourceCopyForPaintSpecific() => true;

    public override void SubDispose()
    {
      this.unloadAnyStuff();
      if (!Information.IsNothing((object) this.backbitmap))
      {
        this.backbitmap.Dispose();
        this.backbitmap = (Bitmap) null;
      }
      if (!Information.IsNothing((object) this.paper))
      {
        this.paper.Dispose();
        this.paper = (Bitmap) null;
      }
      this.game = (GameClass) null;
      this.OwnFont = (Font) null;
      this.dyn = (UDSData) null;
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

    public UDSPartClass(
      GameClass tgame,
      int twidth,
      int theight,
      string tTexty,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool talwaysBlockScrollBar = false,
      bool tJustCheckHeight = false,
      bool tAllGray = false,
      bool tAlwaysShowBackground = false,
      bool tNoBackground = false,
      bool noBitmapDraw = false)
      : base(twidth, theight)
    {
      this.scrollelementclicked = -1;
      this.scrollelementclicked2 = -1;
      this.bmp = new Bitmap[600];
      this.backBmp = new Bitmap[600];
      this.backBitmapCounter = -1;
      this.Width = twidth;
      this.Height = theight;
      this.game = tgame;
      this.texty = tTexty;
      this.allGray = tAllGray;
      this.justCheckHeight = tJustCheckHeight;
      this.alwaysBlockScrollBar = talwaysBlockScrollBar;
      this.lastElementHigh = -1;
      this.alwaysShowBackground = tAlwaysShowBackground;
      this.noBackground = tNoBackground;
      this.curY = 0;
      if (!Information.IsNothing((object) tbackbitmap) & !this.justCheckHeight)
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.bx = bbx;
      this.by = bby;
      this.MouseOver = true;
      if (!this.justCheckHeight)
      {
        this.MakeBitmap();
      }
      else
      {
        if (noBitmapDraw || !Information.IsNothing((object) this.dyn))
          return;
        this.dyn = new UDSData(this.texty, this.allGray);
      }
    }

    public override int HeightUsed() => this.maxY;

    public bool AdjustSliders(int activeSliderNr)
    {
      int num1 = 0;
      int num2 = 0;
      int[] numArray1 = new int[this.dyn.elementCounter + 1];
      SimpleList simpleList = new SimpleList();
      if (this.dyn.element[activeSliderNr].group < 1)
        return false;
      int elementCounter = this.dyn.elementCounter;
      for (int tid = 0; tid <= elementCounter; ++tid)
      {
        if (this.dyn.element[tid].type == UDSType.Slider & this.dyn.element[tid].group == this.dyn.element[activeSliderNr].group)
        {
          num1 = (int) Math.Round((double) num1 + Conversions.ToDouble(this.dyn.element[tid].value));
          numArray1[tid] = Conversions.ToInteger(this.dyn.element[tid].value);
          if (tid != activeSliderNr)
          {
            bool flag = true;
            if (this.dyn.element[tid].rotation > 0 && this.dyn.element[this.dyn.element[tid].rotation].flagged)
              flag = false;
            if (flag)
            {
              ++num2;
              simpleList.Add(tid, 1);
            }
          }
        }
      }
      if (num2 <= 0)
      {
        if (num1 > 100)
        {
          UDSElement[] element = this.dyn.element;
          UDSElement[] udsElementArray = element;
          int index1 = activeSliderNr;
          int index2 = index1;
          udsElementArray[index2].value = Conversions.ToString(Conversions.ToDouble(element[index1].value) - (double) (num1 - 100));
          if (Conversions.ToDouble(this.dyn.element[activeSliderNr].value) < (double) this.dyn.element[activeSliderNr].minvalue)
            this.dyn.element[activeSliderNr].value = Conversions.ToString(this.dyn.element[activeSliderNr].minvalue);
        }
        else if (num1 < 100)
        {
          UDSElement[] element = this.dyn.element;
          UDSElement[] udsElementArray = element;
          int index3 = activeSliderNr;
          int index4 = index3;
          udsElementArray[index4].value = Conversions.ToString(Conversions.ToDouble(element[index3].value) + (double) (100 - num1));
          if (Conversions.ToDouble(this.dyn.element[activeSliderNr].value) > (double) this.dyn.element[activeSliderNr].maxvalue)
            this.dyn.element[activeSliderNr].value = Conversions.ToString(this.dyn.element[activeSliderNr].maxvalue);
        }
        return false;
      }
      if (num1 > 100)
      {
        int num3 = DrawMod.RandyNumber.Next(0, simpleList.Counter + 1) - 1;
        int num4 = 0;
        while (num1 > 100)
        {
          if (num3 == simpleList.Counter)
            num3 = -1;
          bool flag = false;
          int num5 = num3 + 1;
          int counter = simpleList.Counter;
          for (int index5 = num5; index5 <= counter; ++index5)
          {
            int index6 = simpleList.Id[index5];
            num3 = index5;
            if (numArray1[index6] > 0 & activeSliderNr != index6)
            {
              int[] numArray2 = numArray1;
              int[] numArray3 = numArray2;
              int index7 = index6;
              int index8 = index7;
              int num6 = numArray2[index7] - 1;
              numArray3[index8] = num6;
              --num1;
              flag = true;
              break;
            }
          }
          if (!flag)
            ++num4;
          if (num4 > 19)
            break;
        }
      }
      if (num1 < 100)
      {
        int num7 = DrawMod.RandyNumber.Next(0, simpleList.Counter + 1) - 1;
        while (num1 < 100)
        {
          bool flag = false;
          if (num7 == simpleList.Counter)
            num7 = -1;
          int num8 = num7 + 1;
          int counter = simpleList.Counter;
          for (int index9 = num8; index9 <= counter; ++index9)
          {
            int index10 = simpleList.Id[index9];
            num7 = index9;
            if (numArray1[index10] < 100)
            {
              int[] numArray4 = numArray1;
              int[] numArray5 = numArray4;
              int index11 = index10;
              int index12 = index11;
              int num9 = numArray4[index11] + 1;
              numArray5[index12] = num9;
              ++num1;
              flag = true;
              break;
            }
          }
          if (!flag)
            break;
        }
      }
      int counter1 = simpleList.Counter;
      for (int index13 = 0; index13 <= counter1; ++index13)
      {
        int index14 = simpleList.Id[index13];
        if (index14 != activeSliderNr)
          this.dyn.element[index14].value = Conversions.ToString(numArray1[index14]);
      }
      if (num1 > 100)
      {
        UDSElement[] element = this.dyn.element;
        UDSElement[] udsElementArray = element;
        int index15 = activeSliderNr;
        int index16 = index15;
        udsElementArray[index16].value = Conversions.ToString(Conversions.ToDouble(element[index15].value) - (double) (num1 - 100));
        if (Conversions.ToDouble(this.dyn.element[activeSliderNr].value) < (double) this.dyn.element[activeSliderNr].minvalue)
          this.dyn.element[activeSliderNr].value = Conversions.ToString(this.dyn.element[activeSliderNr].minvalue);
      }
      else if (num1 < 100)
      {
        UDSElement[] element = this.dyn.element;
        UDSElement[] udsElementArray = element;
        int index17 = activeSliderNr;
        int index18 = index17;
        udsElementArray[index18].value = Conversions.ToString(Conversions.ToDouble(element[index17].value) + (double) (100 - num1));
        if (Conversions.ToDouble(this.dyn.element[activeSliderNr].value) > (double) this.dyn.element[activeSliderNr].maxvalue)
          this.dyn.element[activeSliderNr].value = Conversions.ToString(this.dyn.element[activeSliderNr].maxvalue);
      }
      return true;
    }

    public override bool HandleMouseMove(int x, int y)
    {
      int i1 = -1;
      bool flag = false;
      int mouseCounter1 = this.MouseCounter;
      for (int index = 0; index <= mouseCounter1; ++index)
      {
        if (this.MouseType[index] == 3 & this.scrollelementclicked > -1)
        {
          Graphics g = Graphics.FromImage((Image) this.paper);
          int activeSliderNr = this.MouseData[index];
          if (this.scrollelementclicked == activeSliderNr)
          {
            this.dyn.element[activeSliderNr].flagged = true;
            int num1 = (int) Math.Round(Math.Max(20.0, (double) this.MouseRect[index].Width / 10.0));
            int num2 = x - this.MouseRect[index].X;
            int num3 = this.MouseRect[index].Width - num1;
            int num4;
            if ((double) num2 < (double) num1 / 2.0)
              num4 = this.dyn.element[activeSliderNr].minvalue;
            else if ((double) num2 > (double) this.MouseRect[index].Width - (double) num1 / 2.0)
            {
              num4 = this.dyn.element[activeSliderNr].maxvalue;
            }
            else
            {
              int num5 = (int) Math.Round((double) num2 - (double) num1 / 2.0);
              num4 = (int) Math.Round((double) (this.dyn.element[activeSliderNr].maxvalue - this.dyn.element[activeSliderNr].minvalue) * ((double) num5 / (double) num3)) + this.dyn.element[activeSliderNr].minvalue;
            }
            this.dyn.element[activeSliderNr].value = Conversions.ToString(num4);
            if (this.AdjustSliders(activeSliderNr))
            {
              int elementCounter = this.dyn.elementCounter;
              for (int i2 = 0; i2 <= elementCounter; ++i2)
              {
                if (activeSliderNr != i2 & this.dyn.element[i2].type == UDSType.Slider & this.dyn.element[i2].group == this.dyn.element[activeSliderNr].group)
                  this.DrawElement(i2, ref g, false);
              }
            }
            i1 = this.MouseData[index];
            flag = true;
          }
          else if (this.MouseType[index] != 3)
          {
            this.scrollelementclicked = -1;
            this.scrollelementclicked2 = -1;
          }
        }
      }
      int mouseCounter2 = this.MouseCounter;
      for (int index = 0; index <= mouseCounter2; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseType[index] > 0 & this.MouseType[index] != 9)
          {
            i1 = this.MouseData[index];
            flag = true;
            break;
          }
          break;
        }
      }
      if (this.scrollelementclicked > -1 & i1 != this.scrollelementclicked)
        i1 = this.scrollelementclicked;
      if (i1 == this.lastElementHigh & this.scrollelementclicked == -1)
        flag = false;
      else if (i1 == -1 & this.lastElementHigh > -1)
        flag = true;
      if (flag)
      {
        if (this.game.EmpireStyle)
          SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
        Graphics g = Graphics.FromImage((Image) this.paper);
        if (i1 > -1)
        {
          if (this.lastElementHigh != -1 && this.lastElementHigh != i1 && !(this.dyn.element[this.lastElementHigh].type == UDSType.Table | this.dyn.element[this.lastElementHigh].type == UDSType.TextField | this.dyn.element[this.lastElementHigh].type == UDSType.PictureField))
            this.DrawElement(this.lastElementHigh, ref g, false);
          if (!(this.dyn.element[i1].type == UDSType.Table | this.dyn.element[i1].type == UDSType.TextField | this.dyn.element[i1].type == UDSType.PictureField))
            this.DrawElement(i1, ref g, false, true);
        }
        else if (this.lastElementHigh > -1 && !(this.dyn.element[this.lastElementHigh].type == UDSType.Table | this.dyn.element[this.lastElementHigh].type == UDSType.TextField | this.dyn.element[this.lastElementHigh].type == UDSType.PictureField))
          this.DrawElement(this.lastElementHigh, ref g, false);
      }
      this.lastElementHigh = i1;
      return flag;
    }

    public override void HandleToolTip(int x, int y)
    {
      this.game.EditObj.TipColor = 0;
      int mouseCounter = this.MouseCounter;
      for (int index1 = 0; index1 <= mouseCounter; ++index1)
      {
        if (x > this.MouseRect[index1].X & x < this.MouseRect[index1].X + this.MouseRect[index1].Width && y > this.MouseRect[index1].Y & y < this.MouseRect[index1].Y + this.MouseRect[index1].Height)
        {
          this.game.EditObj.TipButton = false;
          if (this.MouseType[index1] > 0)
            this.game.EditObj.TipButton = true;
          if (this.MouseType[index1] < 1 & this.MouseData[index1] > 0)
            this.game.EditObj.TipButton = true;
          if (this.MouseType[index1] == 25)
          {
            StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(this.dyn.element[this.MouseData[index1]].texty))];
            int num1 = y - this.dyn.element[this.MouseData[index1]].y + this.curY;
            if (num1 <= this.dyn.element[this.MouseData[index1]].lineHeight)
            {
              int index2;
              if (stringListClass.ColWidth[0] > 0)
              {
                int num2 = x - this.dyn.element[this.MouseData[index1]].x;
                int num3 = 0;
                index2 = -1;
                int width = stringListClass.Width;
                for (int index3 = 0; index3 <= width; ++index3)
                {
                  num3 += stringListClass.ColWidth[index3];
                  if (num2 < num3)
                  {
                    index2 = index3;
                    break;
                  }
                }
                if (index2 == -1)
                  index2 = 0;
              }
              else
              {
                int num4 = (int) Math.Round((double) this.dyn.element[this.MouseData[index1]].w / (double) (stringListClass.Width + 1));
                index2 = (int) Math.Round(Math.Floor((double) (x - this.dyn.element[this.MouseData[index1]].x) / (double) num4));
              }
              if (stringListClass.ColValueType[index2] == NewEnums.LibVarValueType.Number)
              {
                this.game.EditObj.TipTitle = "";
                if (stringListClass.ColSort[index2] == 0)
                  this.game.EditObj.TipText = "Click to sort high to low";
                if (stringListClass.ColSort[index2] == 1)
                  this.game.EditObj.TipText = "Click to sort high to low";
                if (stringListClass.ColSort[index2] != 2)
                  break;
                this.game.EditObj.TipText = "Click to sort low to high";
                break;
              }
              if (stringListClass.ColValueType[index2] == NewEnums.LibVarValueType.Text)
              {
                this.game.EditObj.TipTitle = "";
                if (stringListClass.ColSort[index2] == 0)
                  this.game.EditObj.TipText = "Click to sort A to Z";
                if (stringListClass.ColSort[index2] == 1)
                  this.game.EditObj.TipText = "Click to sort A to Z";
                if (stringListClass.ColSort[index2] != 2)
                  break;
                this.game.EditObj.TipText = "Click to sort Z to A";
                break;
              }
              this.game.EditObj.TipButton = false;
              break;
            }
            if (num1 > this.dyn.element[this.MouseData[index1]].lineHeight * (this.dyn.element[this.MouseData[index1]].rowsPerPage + 1) - 2)
            {
              this.game.EditObj.TipButton = false;
              break;
            }
            int index4;
            if (stringListClass.ColWidth[0] > 0)
            {
              int num5 = x - this.dyn.element[this.MouseData[index1]].x;
              int num6 = 0;
              index4 = -1;
              int width = stringListClass.Width;
              for (int index5 = 0; index5 <= width; ++index5)
              {
                if (index5 <= stringListClass.Width)
                {
                  num6 += stringListClass.ColWidth[index5];
                  if (num5 < num6)
                  {
                    index4 = index5;
                    break;
                  }
                }
              }
              if (index4 == -1)
                index4 = 0;
            }
            else
            {
              int num7 = (int) Math.Round((double) this.dyn.element[this.MouseData[index1]].w / (double) (stringListClass.Width + 1));
              index4 = (int) Math.Round(Math.Floor((double) (x - this.dyn.element[this.MouseData[index1]].x) / (double) num7));
            }
            int index6 = (int) Math.Round(Math.Floor((double) (num1 - this.dyn.element[this.MouseData[index1]].lineHeight) / (double) this.dyn.element[this.MouseData[index1]].lineHeight)) + this.dyn.element[this.MouseData[index1]].topRow;
            string str1 = "";
            if (index6 <= stringListClass.Length)
            {
              string str2 = stringListClass.TempDesc[index6, index4];
              if (!Information.IsNothing((object) str2))
              {
                if (Strings.InStr(str2, "#") > 0)
                  str1 = str2.Split('#')[0];
                else if (str2.Length > 1)
                  str1 = str2;
              }
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = str1;
            }
            if (str1.Length >= 2)
              break;
            this.game.EditObj.TipButton = false;
            break;
          }
          this.game.EditObj.TipTitle = this.MouseTitle[index1];
          this.game.EditObj.TipText = this.MouseText[index1];
          if (Information.IsNothing((object) this.MouseText[index1]))
            break;
          this.game.EditObj.TipColor = this.MouseType[index1] >= 1 ? 0 : this.MouseData[index1];
          if (this.game.EditObj.TipText.Length != 0)
            break;
          this.game.EditObj.TipText = "...................";
          break;
        }
      }
    }

    public int DoJustCheckHeight(bool heightIncludingY = false)
    {
      this.dyn = new UDSData(this.texty, false);
      int num1 = 0;
      int elementCounter = this.dyn.elementCounter;
      for (int index1 = 0; index1 <= elementCounter; ++index1)
      {
        if (this.dyn.element[index1].type == UDSType.TextField)
        {
          int index2 = this.game.AddDynFont(this.dyn.element[index1].fontName, this.dyn.element[index1].fontSize, this.dyn.element[index1].fontStyle);
          if (index2 > -1)
          {
            GameClass game = this.game;
            int w = this.dyn.element[index1].w;
            int trows = (int) Math.Round((double) this.dyn.element[index1].h / (double) this.dyn.element[index1].lineHeight);
            Font tfont = this.game.DynFont[index2];
            string texty = this.dyn.element[index1].texty;
            int lineHeight = this.dyn.element[index1].lineHeight;
            Bitmap bitmap = (Bitmap) null;
            ref Bitmap local = ref bitmap;
            int r = (int) this.dyn.element[index1].color.R;
            int g = (int) this.dyn.element[index1].color.G;
            int b = (int) this.dyn.element[index1].color.B;
            int a = (int) this.dyn.element[index1].color.A;
            TextAreaClass2 textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseMin40width: false);
            int num2 = textAreaClass2.HeightUsed();
            if (heightIncludingY)
              num2 += this.dyn.element[index1].y;
            if (num2 > num1)
              num1 = num2;
            textAreaClass2.Dispose();
          }
        }
        if (this.dyn.element[index1].type == UDSType.PictureField && this.dyn.element[index1].eventPicture > -1)
        {
          int num3 = BitmapStore.Getheight(this.game.Data.EventPicNr[this.dyn.element[index1].eventPicture]);
          if (this.dyn.element[index1].h < num3)
            num3 = this.dyn.element[index1].h;
          if (heightIncludingY)
            num3 += this.dyn.element[index1].y;
          if (num3 > num1)
            num1 = num3;
        }
      }
      return num1;
    }

    public int DoJustCheckWidth()
    {
      this.dyn = new UDSData(this.texty, false);
      int num1 = 0;
      int elementCounter = this.dyn.elementCounter;
      for (int index1 = 0; index1 <= elementCounter; ++index1)
      {
        if (this.dyn.element[index1].type == UDSType.TextField)
        {
          int index2 = this.game.AddDynFont(this.dyn.element[index1].fontName, this.dyn.element[index1].fontSize, this.dyn.element[index1].fontStyle);
          if (index2 > -1)
          {
            GameClass game = this.game;
            int w = this.dyn.element[index1].w;
            int trows = (int) Math.Round((double) this.dyn.element[index1].h / (double) this.dyn.element[index1].lineHeight);
            Font tfont = this.game.DynFont[index2];
            string texty = this.dyn.element[index1].texty;
            int lineHeight = this.dyn.element[index1].lineHeight;
            Bitmap bitmap = (Bitmap) null;
            ref Bitmap local = ref bitmap;
            int r = (int) this.dyn.element[index1].color.R;
            int g = (int) this.dyn.element[index1].color.G;
            int b = (int) this.dyn.element[index1].color.B;
            int a = (int) this.dyn.element[index1].color.A;
            TextAreaClass2 textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseMin40width: false);
            int num2 = textAreaClass2.WidthUsed();
            if (num2 > num1)
              num1 = num2;
            textAreaClass2.Dispose();
          }
        }
        if (this.dyn.element[index1].type == UDSType.PictureField && this.dyn.element[index1].eventPicture > -1)
        {
          int num3 = BitmapStore.GetWidth(this.game.Data.EventPicNr[this.dyn.element[index1].eventPicture]);
          if (this.dyn.element[index1].w < num3)
            num3 = this.dyn.element[index1].w;
          if (num3 > num1)
            num1 = num3;
        }
      }
      return num1;
    }

    public void MakeBitmap()
    {
      this.ClearMouse();
      if (Information.IsNothing((object) this.dyn))
        this.dyn = new UDSData(this.texty, this.allGray);
      this.loadPageStuff();
      Graphics graphics1 = Graphics.FromImage((Image) this.OwnBitmap);
      int num1 = 0;
      int elementCounter1 = this.dyn.elementCounter;
      for (int index1 = 0; index1 <= elementCounter1; ++index1)
      {
        if (this.dyn.element[index1].type == UDSType.TextField)
        {
          int index2 = this.game.AddDynFont(this.dyn.element[index1].fontName, this.dyn.element[index1].fontSize, this.dyn.element[index1].fontStyle);
          if (index2 > -1)
          {
            SizeF sizeF = graphics1.MeasureString(this.dyn.element[index1].texty, this.game.DynFont[index2], this.dyn.element[index1].w);
            int num2 = (int) Math.Round((double) sizeF.Height);
            if (num2 < this.dyn.element[index1].lineHeight)
              num2 = this.dyn.element[index1].lineHeight;
            int num3 = num2 + this.dyn.element[index1].y;
            if (num3 > num1)
              num1 = num3 + this.dyn.element[index1].lineHeight * 1 + 48;
            this.dyn.element[index1].h = (int) Math.Round((double) sizeF.Height + (double) (this.dyn.element[index1].lineHeight * 1) + 48.0);
          }
        }
        else if (this.dyn.element[index1].type == UDSType.PictureField)
        {
          if (this.dyn.element[index1].y + this.dyn.element[index1].h > num1)
            num1 = this.dyn.element[index1].y + this.dyn.element[index1].h + 48;
        }
        else if (this.dyn.element[index1].type == UDSType.PictureField)
        {
          if (this.dyn.element[index1].y + this.dyn.element[index1].h > num1)
            num1 = this.dyn.element[index1].y + this.dyn.element[index1].h;
        }
        else if (this.dyn.element[index1].type == UDSType.Flag)
        {
          if (this.dyn.element[index1].y + this.dyn.element[index1].h > num1)
            num1 = this.dyn.element[index1].y + this.dyn.element[index1].h;
        }
        else if (this.dyn.element[index1].type == UDSType.Table && this.dyn.element[index1].y + this.dyn.element[index1].h > num1)
          num1 = this.dyn.element[index1].y + this.dyn.element[index1].h;
      }
      if (this.maxY < this.Height)
        this.maxY = this.Height;
      this.maxY = this.Height;
      this.maxY -= this.maxY % 100;
      int elementCounter2 = this.dyn.elementCounter;
      for (int index = 0; index <= elementCounter2; ++index)
      {
        if (this.dyn.element[index].y + this.dyn.element[index].h > this.maxY && this.dyn.element[index].type != UDSType.Line)
          this.maxY = this.dyn.element[index].y + this.dyn.element[index].h;
      }
      this.maxY += 20;
      if (this.maxY < this.Height)
        this.maxY = this.Height;
      if (this.maxY > 5000)
        this.maxY = 5000;
      this.paper = new Bitmap(this.Width, this.maxY, PixelFormat.Format32bppPArgb);
      this.paper.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics2 = Graphics.FromImage((Image) this.paper);
      int num4;
      if (!this.noBackground)
      {
        if (!this.alwaysBlockScrollBar)
        {
          graphics2.CompositingMode = CompositingMode.SourceCopy;
          Rectangle rectangle1;
          Rectangle rectangle2;
          int y;
          for (; y < this.maxY - 1390; y += 1390)
          {
            ref Graphics local1 = ref graphics2;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER2);
            ref Bitmap local2 = ref bitmap;
            rectangle1 = new Rectangle(0, 0, Math.Min(1126, this.Width - 24), 1390);
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(0, y, this.Width - 24, 1390);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          }
          if (y < this.maxY)
          {
            ref Graphics local3 = ref graphics2;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER2);
            ref Bitmap local4 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, Math.Min(1126, this.Width - 24), this.maxY - y);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, y, this.Width - 24, this.maxY - y);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
            num4 = y + (this.maxY - y);
          }
          ref Graphics local5 = ref graphics2;
          ref Bitmap local6 = ref this.backbitmap;
          rectangle2 = new Rectangle(0, 0, this.Width, 5);
          Rectangle rect = rectangle2;
          DrawMod.DrawSimplePart(ref local5, ref local6, rect);
          graphics2.CompositingMode = CompositingMode.SourceOver;
          if (this.maxY >= 256)
          {
            ref Graphics local7 = ref graphics2;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER3);
            ref Bitmap local8 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, Math.Min(1126, this.Width - 24), 256);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, this.maxY - 256, this.Width - 24, 256);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
          }
          DrawMod.DrawRectangle(ref graphics2, 10, 15, this.Width - 45, this.maxY - 25, 0, 0, 0, 32, 10);
        }
        else if (this.alwaysShowBackground)
        {
          graphics2.CompositingMode = CompositingMode.SourceCopy;
          Rectangle rectangle3;
          Rectangle rectangle4;
          int y;
          for (; y < this.maxY - 1390; y += 1390)
          {
            ref Graphics local9 = ref graphics2;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER2);
            ref Bitmap local10 = ref bitmap;
            rectangle3 = new Rectangle(0, 0, Math.Min(1126, this.Width - 0), 1390);
            Rectangle srcrect = rectangle3;
            rectangle4 = new Rectangle(0, y, this.Width - 0, 1390);
            Rectangle destrect = rectangle4;
            DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
          }
          if (y < this.maxY)
          {
            ref Graphics local11 = ref graphics2;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER2);
            ref Bitmap local12 = ref bitmap;
            rectangle3 = new Rectangle(0, 0, Math.Min(1126, this.Width - 0), this.maxY - y);
            Rectangle srcrect = rectangle3;
            rectangle4 = new Rectangle(0, y, this.Width - 0, this.maxY - y);
            Rectangle destrect = rectangle4;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
            num4 = y + (this.maxY - y);
          }
          graphics2.CompositingMode = CompositingMode.SourceOver;
          if (this.maxY >= 256)
          {
            ref Graphics local13 = ref graphics2;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER3);
            ref Bitmap local14 = ref bitmap;
            rectangle3 = new Rectangle(0, 0, Math.Min(1126, this.Width - 0), 256);
            Rectangle srcrect = rectangle3;
            rectangle4 = new Rectangle(0, this.maxY - 256, this.Width - 0, 256);
            Rectangle destrect = rectangle4;
            DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
          }
        }
      }
      this.backBmpLink = new int[this.dyn.elementCounter + 1];
      int elementCounter3 = this.dyn.elementCounter;
      for (int i = 0; i <= elementCounter3; ++i)
        this.DrawElement(i, ref graphics2, true);
      graphics2.Dispose();
      if (!(!Information.IsNothing((object) this.dyn) & !this.justCheckHeight))
        return;
      int elementCounter4 = this.dyn.elementCounter;
      for (int index = 0; index <= elementCounter4; ++index)
      {
        if (this.dyn.element[index].type == UDSType.Wav)
        {
          if (!this.game.EmpireStyle)
            break;
          SoundMod.PlayAWave(this.game.AppPath + "sound/" + this.dyn.element[index].texty, ref this.game.EditObj);
          break;
        }
      }
    }

    public void DrawElement(int i, ref Graphics g, bool firstCall, bool high = false)
    {
      Graphics Expression;
      Rectangle trect;
      Rectangle rectangle;
      if (this.dyn.element[i].type == UDSType.TextField)
      {
        int index1 = this.game.AddDynFont(this.dyn.element[i].fontName, this.dyn.element[i].fontSize, this.dyn.element[i].fontStyle);
        if (index1 > -1)
        {
          if (this.dyn.element[i].parentElement > -1)
          {
            if (firstCall)
            {
              ++this.backBitmapCounter;
              this.backBmp[this.backBitmapCounter] = new Bitmap(this.dyn.element[i].w, this.dyn.element[i].h, PixelFormat.Format32bppPArgb);
              this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              Expression = Graphics.FromImage((Image) this.backBmp[this.backBitmapCounter]);
              Expression.CompositingMode = CompositingMode.SourceCopy;
              Graphics graphics = Expression;
              Bitmap paper = this.paper;
              trect = new Rectangle(0, 0, this.backBmp[this.backBitmapCounter].Width, this.backBmp[this.backBitmapCounter].Height);
              Rectangle destRect = trect;
              rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
              Rectangle srcRect = rectangle;
              graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
              Expression.CompositingMode = CompositingMode.SourceOver;
              this.backBmpLink[i] = this.backBitmapCounter;
            }
            else
              g.DrawImage((Image) this.backBmp[this.backBmpLink[i]], this.dyn.element[i].x, this.dyn.element[i].y);
          }
          GameClass game = this.game;
          int w = this.dyn.element[i].w;
          int trows = (int) Math.Round((double) this.dyn.element[i].h / (double) this.dyn.element[i].lineHeight);
          Font tfont = this.game.DynFont[index1];
          string texty = this.dyn.element[i].texty;
          int lineHeight = this.dyn.element[i].lineHeight;
          Bitmap bitmap = (Bitmap) null;
          ref Bitmap local = ref bitmap;
          int num = this.dyn.element[i].center == 1 ? 1 : 0;
          int r = (int) this.dyn.element[i].color.R;
          int g1 = (int) this.dyn.element[i].color.G;
          int b = (int) this.dyn.element[i].color.B;
          int a = (int) this.dyn.element[i].color.A;
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, tcenterit: (num != 0), colr: r, colg: g1, colb: b, cola: a, tshadow: false, tUseEncy: true, tminimalHeight: true, tUseMin40width: false);
          textAreaClass2.Paint();
          int mouseCounter = textAreaClass2.MouseCounter;
          for (int index2 = 0; index2 <= mouseCounter; ++index2)
          {
            if (firstCall)
            {
              rectangle = new Rectangle(textAreaClass2.MouseRect[index2].X + this.dyn.element[i].x, textAreaClass2.MouseRect[index2].Y + this.dyn.element[i].y, textAreaClass2.MouseRect[index2].Width, textAreaClass2.MouseRect[index2].Height);
              trect = rectangle;
              this.AddMouse(ref trect, textAreaClass2.MouseTitle[index2], textAreaClass2.MouseText[index2], textAreaClass2.MouseData[index2]);
            }
          }
          g.DrawImage((Image) textAreaClass2.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
          textAreaClass2.Dispose();
        }
      }
      if (this.dyn.element[i].type == UDSType.Table)
      {
        int index = this.game.AddDynFont(this.dyn.element[i].fontName, this.dyn.element[i].fontSize, this.dyn.element[i].fontStyle);
        if (index > -1)
        {
          if (firstCall)
          {
            ++this.backBitmapCounter;
            this.backBmp[this.backBitmapCounter] = new Bitmap(this.dyn.element[i].w, this.dyn.element[i].h, PixelFormat.Format32bppPArgb);
            this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            Expression = Graphics.FromImage((Image) this.backBmp[this.backBitmapCounter]);
            Expression.CompositingMode = CompositingMode.SourceCopy;
            Graphics graphics = Expression;
            Bitmap paper = this.paper;
            rectangle = new Rectangle(0, 0, this.backBmp[this.backBitmapCounter].Width, this.backBmp[this.backBitmapCounter].Height);
            Rectangle destRect = rectangle;
            trect = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            Rectangle srcRect = trect;
            graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
            Expression.CompositingMode = CompositingMode.SourceOver;
            this.backBmpLink[i] = this.backBitmapCounter;
          }
          else
            g.DrawImage((Image) this.backBmp[this.backBmpLink[i]], this.dyn.element[i].x, this.dyn.element[i].y);
          StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(this.dyn.element[i].texty))];
          int num1 = stringListClass.Length + 1;
          int num2 = (int) Math.Round(Math.Floor((double) this.dyn.element[i].h / (double) this.dyn.element[i].lineHeight)) - 2;
          StringListClass tListobj = stringListClass;
          int tlistsize = num2;
          int w = this.dyn.element[i].w;
          GameClass tgame = DrawMod.TGame;
          int topRow = this.dyn.element[i].topRow;
          Bitmap bitmap = (Bitmap) null;
          ref Bitmap local1 = ref bitmap;
          int lineHeight = this.dyn.element[i].lineHeight;
          ref Font local2 = ref this.game.DynFont[index];
          UDSMatrixSubPartClass matrixSubPartClass = new UDSMatrixSubPartClass(tListobj, tlistsize, w, -1, -1, tgame, tHighlight: false, tTop: topRow, tbackbitmap: (ref local1), trowheight: lineHeight, tfontsize: 16, tMarcy: true, customFont: (ref local2));
          matrixSubPartClass.Paint();
          g.DrawImage((Image) matrixSubPartClass.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
          matrixSubPartClass.Dispose();
          if (firstCall)
          {
            rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            trect = rectangle;
            this.AddMouse(ref trect, "", "", i, 25);
          }
        }
      }
      Bitmap bitmap1;
      if (this.dyn.element[i].type == UDSType.PictureField)
      {
        if (Information.IsNothing((object) this.dyn.element[i].mouseOver))
          this.dyn.element[i].mouseOver = "";
        if (this.dyn.element[i].historicalUnitPortrait > 0)
        {
          int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(this.dyn.element[i].historicalUnitPortrait);
          if (historicalUnitById > -1)
          {
            if (this.dyn.element[i].w > 0)
              DrawMod.DrawOfficer(g, historicalUnitById, this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            else
              DrawMod.DrawOfficer(g, historicalUnitById, this.dyn.element[i].x, this.dyn.element[i].y, 95, 105);
          }
        }
        else if (this.dyn.element[i].customBitmapFunction > 0)
        {
          if (this.dyn.element[i].color.R == (byte) 0 & this.dyn.element[i].color.G == (byte) 0 & this.dyn.element[i].color.B == (byte) 0)
          {
            ref Graphics local3 = ref g;
            Bitmap bitmap2 = this.game.CustomBitmapObj.DrawLeaderPortrait(this.dyn.element[i].customBitmapFunction, this.dyn.element[i].w, this.dyn.element[i].h, relChange: -999);
            ref Bitmap local4 = ref bitmap2;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            DrawMod.DrawSimple(ref local3, ref local4, x, y);
          }
          else if (this.dyn.element[i].color.A != byte.MaxValue | this.dyn.element[i].color.R != byte.MaxValue | this.dyn.element[i].color.G != byte.MaxValue | this.dyn.element[i].color.B != byte.MaxValue)
          {
            ref Graphics local5 = ref g;
            Bitmap bitmap3 = this.game.CustomBitmapObj.DrawLeaderPortrait(this.dyn.element[i].customBitmapFunction, this.dyn.element[i].w, this.dyn.element[i].h, true, this.dyn.element[i].subtype);
            ref Bitmap local6 = ref bitmap3;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            double r = (double) ((float) this.dyn.element[i].color.R / (float) byte.MaxValue) - 1.0;
            double g2 = (double) ((float) this.dyn.element[i].color.G / (float) byte.MaxValue) - 1.0;
            double b = (double) ((float) this.dyn.element[i].color.B / (float) byte.MaxValue) - 1.0;
            double a = (double) ((float) this.dyn.element[i].color.A / (float) byte.MaxValue);
            DrawMod.Draw(ref local5, ref local6, x, y, (float) r, (float) g2, (float) b, (float) a);
          }
          else
          {
            ref Graphics local7 = ref g;
            Bitmap bitmap4 = this.game.CustomBitmapObj.DrawLeaderPortrait(this.dyn.element[i].customBitmapFunction, this.dyn.element[i].w, this.dyn.element[i].h, true, this.dyn.element[i].subtype);
            ref Bitmap local8 = ref bitmap4;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            DrawMod.DrawSimple(ref local7, ref local8, x, y);
          }
        }
        else if (this.dyn.element[i].customBitmapFunction3 > 0)
        {
          int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 311, 0, 0));
          int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
          int peopleById = this.game.HandyFunctionsObj.GetPeopleByID(this.dyn.element[i].customBitmapFunction3);
          int tv0 = this.game.Data.PeopleObj[peopleById].tv0;
          int tv1 = this.game.Data.PeopleObj[peopleById].tv1;
          int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, tv0, 2)));
          int isUniformEventPic = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, idValue, 3, tv1, 4)));
          int isAllowHair = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, idValue, 3, tv1, 6)));
          int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, idValue, 3, tv1, 5)));
          int isPeoplePortraitGroup = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, idValue, 3, tv1, 7)));
          int ox = this.dyn.element[i].ox;
          int sfNr = this.dyn.element[i].oy;
          if (sfNr < 1)
            sfNr = -1;
          if (this.dyn.element[i].color.R == (byte) 0 & this.dyn.element[i].color.G == (byte) 0 & this.dyn.element[i].color.B == (byte) 0)
          {
            ref Graphics local9 = ref g;
            Bitmap bitmap5 = this.game.CustomBitmapObj.DrawLeaderPortrait(-1, this.dyn.element[i].w, this.dyn.element[i].h, relChange: -999, isPeoplePortraitGroup: isPeoplePortraitGroup, isPeopleId: peopleById, isPeopleType: tv1, isRegId: ox, isAllowHair: isAllowHair, isUniformEventPic: isUniformEventPic, sfNr: sfNr);
            ref Bitmap local10 = ref bitmap5;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            DrawMod.DrawSimple(ref local9, ref local10, x, y);
          }
          else if (this.dyn.element[i].color.A != byte.MaxValue | this.dyn.element[i].color.R != byte.MaxValue | this.dyn.element[i].color.G != byte.MaxValue | this.dyn.element[i].color.B != byte.MaxValue)
          {
            ref Graphics local11 = ref g;
            Bitmap bitmap6 = this.game.CustomBitmapObj.DrawLeaderPortrait(-1, this.dyn.element[i].w, this.dyn.element[i].h, relChange: -999, isPeoplePortraitGroup: isPeoplePortraitGroup, isPeopleId: peopleById, isPeopleType: tv1, isRegId: ox, isAllowHair: isAllowHair, isUniformEventPic: isUniformEventPic, sfNr: sfNr);
            ref Bitmap local12 = ref bitmap6;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            double r = (double) ((float) this.dyn.element[i].color.R / (float) byte.MaxValue) - 1.0;
            double g3 = (double) ((float) this.dyn.element[i].color.G / (float) byte.MaxValue) - 1.0;
            double b = (double) ((float) this.dyn.element[i].color.B / (float) byte.MaxValue) - 1.0;
            double a = (double) ((float) this.dyn.element[i].color.A / (float) byte.MaxValue);
            DrawMod.Draw(ref local11, ref local12, x, y, (float) r, (float) g3, (float) b, (float) a);
          }
          else
          {
            ref Graphics local13 = ref g;
            Bitmap bitmap7 = this.game.CustomBitmapObj.DrawLeaderPortrait(-1, this.dyn.element[i].w, this.dyn.element[i].h, relChange: -999, isPeoplePortraitGroup: isPeoplePortraitGroup, isPeopleId: peopleById, isPeopleType: tv1, isRegId: ox, isAllowHair: isAllowHair, isUniformEventPic: isUniformEventPic, sfNr: sfNr);
            ref Bitmap local14 = ref bitmap7;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            DrawMod.DrawSimple(ref local13, ref local14, x, y);
          }
        }
        else if (this.dyn.element[i].customBitmapFunction2 > 0)
        {
          int sfTypeById = this.game.HandyFunctionsObj.GetSFTypeByID(this.dyn.element[i].customBitmapFunction2);
          if (sfTypeById > -1)
          {
            Bitmap objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(sfTypeById, this.dyn.element[i].ox == 1, this.dyn.element[i].oy, this.dyn.element[i].ow, -1);
            if (this.dyn.element[i].w == 76)
            {
              int num3 = 0;
              int num4 = 2;
              int w = 76;
              int h = 64;
              int width = objBitmap.Width;
              int height = objBitmap.Height;
              if (width > w | height > h)
              {
                if ((double) width / (double) w > (double) height / (double) h)
                {
                  float num5 = (float) w / (float) width;
                  int num6 = (int) Math.Round((double) ((float) h - (float) height * num5));
                  num4 += (int) Math.Round((double) num6 / 2.0);
                  h -= num6;
                }
                else
                {
                  float num7 = (float) h / (float) height;
                  int num8 = (int) Math.Round((double) ((float) w - (float) width * num7));
                  num3 += (int) Math.Round((double) num8 / 2.0);
                  w -= num8;
                }
                DrawMod.DrawScaled(ref g, ref objBitmap, this.dyn.element[i].x + num3, this.dyn.element[i].y + num4, w, h);
              }
              else
                DrawMod.DrawSimple(ref g, ref objBitmap, this.dyn.element[i].x + num3 + (int) Math.Round((double) (w - width) / 2.0), this.dyn.element[i].y + num4 + (int) Math.Round((double) (h - height) / 2.0));
            }
            else if (this.dyn.element[i].w < objBitmap.Width)
            {
              int num9 = 0;
              int num10 = 2;
              int w = this.dyn.element[i].w;
              int h = this.dyn.element[i].h;
              int width = objBitmap.Width;
              int height = objBitmap.Height;
              if (width > w | height > h)
              {
                if ((double) width / (double) w > (double) height / (double) h)
                {
                  float num11 = (float) w / (float) width;
                  int num12 = (int) Math.Round((double) ((float) h - (float) height * num11));
                  num10 += (int) Math.Round((double) num12 / 2.0);
                  h -= num12;
                }
                else
                {
                  float num13 = (float) h / (float) height;
                  int num14 = (int) Math.Round((double) ((float) w - (float) width * num13));
                  num9 += (int) Math.Round((double) num14 / 2.0);
                  w -= num14;
                }
                DrawMod.DrawScaled(ref g, ref objBitmap, this.dyn.element[i].x + num9, this.dyn.element[i].y + num10, w, h);
              }
              else
                DrawMod.DrawSimple(ref g, ref objBitmap, this.dyn.element[i].x + num9 + (int) Math.Round((double) (w - width) / 2.0), this.dyn.element[i].y + num10 + (int) Math.Round((double) (h - height) / 2.0));
            }
            else if (this.dyn.element[i].color.R == (byte) 0 & this.dyn.element[i].color.G == (byte) 0 & this.dyn.element[i].color.B == (byte) 0)
              DrawMod.DrawSimple(ref g, ref objBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
            else if (this.dyn.element[i].color.A != byte.MaxValue | this.dyn.element[i].color.R != byte.MaxValue | this.dyn.element[i].color.G != byte.MaxValue | this.dyn.element[i].color.B != byte.MaxValue)
              DrawMod.Draw(ref g, ref objBitmap, this.dyn.element[i].x, this.dyn.element[i].y, (float) this.dyn.element[i].color.R / (float) byte.MaxValue - 1f, (float) this.dyn.element[i].color.G / (float) byte.MaxValue - 1f, (float) this.dyn.element[i].color.B / (float) byte.MaxValue - 1f, (float) this.dyn.element[i].color.A / (float) byte.MaxValue);
            else
              DrawMod.DrawSimple(ref g, ref objBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
          }
        }
        else if (this.dyn.element[i].bitmapSlot > 0 & this.dyn.element[i].bitmapSlot < 59999)
        {
          if (this.dyn.element[i].color.R != byte.MaxValue | this.dyn.element[i].color.G != byte.MaxValue | this.dyn.element[i].color.B != byte.MaxValue)
          {
            ref Graphics local15 = ref g;
            Bitmap bitmap8 = BitmapStore.GetBitmap(this.dyn.element[i].bitmapSlot);
            ref Bitmap local16 = ref bitmap8;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            int w = this.dyn.element[i].w;
            int h = this.dyn.element[i].h;
            int width = BitmapStore.GetWidth(this.dyn.element[i].bitmapSlot);
            int origh = BitmapStore.Getheight(this.dyn.element[i].bitmapSlot);
            double r = (double) ((float) this.dyn.element[i].color.R / (float) byte.MaxValue);
            double g4 = (double) ((float) this.dyn.element[i].color.G / (float) byte.MaxValue);
            double b = (double) ((float) this.dyn.element[i].color.B / (float) byte.MaxValue);
            double a = (double) ((float) this.dyn.element[i].color.A / (float) byte.MaxValue);
            DrawMod.DrawScaledColorized2(ref local15, ref local16, x, y, w, h, width, origh, (float) r, (float) g4, (float) b, (float) a);
          }
          else
          {
            ref Graphics local17 = ref g;
            Bitmap bitmap9 = BitmapStore.GetBitmap(this.dyn.element[i].bitmapSlot);
            ref Bitmap local18 = ref bitmap9;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            int w = this.dyn.element[i].w;
            int h = this.dyn.element[i].h;
            DrawMod.DrawScaled(ref local17, ref local18, x, y, w, h);
          }
        }
        else if (this.dyn.element[i].smallgfx > 0)
        {
          if (BitmapStore.GetWidth(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx]) > this.dyn.element[i].w)
          {
            if (this.dyn.element[i].h == 0)
              this.dyn.element[i].h = (int) Math.Round((double) BitmapStore.Getheight(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx]) * ((double) this.dyn.element[i].w / (double) BitmapStore.GetWidth(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx])));
            ref Graphics local19 = ref g;
            Bitmap bitmap10 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx]);
            ref Bitmap local20 = ref bitmap10;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            int w = this.dyn.element[i].w;
            int h = this.dyn.element[i].h;
            DrawMod.DrawScaled(ref local19, ref local20, x, y, w, h);
          }
          else if (BitmapStore.GetWidth(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx]) < this.dyn.element[i].w)
          {
            ref Graphics local21 = ref g;
            Bitmap bitmap11 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx], 1);
            ref Bitmap local22 = ref bitmap11;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            DrawMod.DrawSimple(ref local21, ref local22, x, y);
          }
          else
          {
            ref Graphics local23 = ref g;
            bitmap1 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.dyn.element[i].smallgfx]);
            ref Bitmap local24 = ref bitmap1;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            DrawMod.DrawSimple(ref local23, ref local24, x, y);
          }
        }
        else if (this.dyn.element[i].tempPicture.Length > 1)
        {
          if (this.dyn.element[i].w > 0)
          {
            if (this.dyn.element[i].color.A != byte.MaxValue | this.dyn.element[i].color.R != byte.MaxValue | this.dyn.element[i].color.G != byte.MaxValue | this.dyn.element[i].color.B != byte.MaxValue)
              DrawMod.DrawScaledColorized2(ref g, ref this.bmp[this.bmpLink[i]], this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h, this.bmp[this.bmpLink[i]].Width, this.bmp[this.bmpLink[i]].Height, (float) this.dyn.element[i].color.R / (float) byte.MaxValue, (float) this.dyn.element[i].color.G / (float) byte.MaxValue, (float) this.dyn.element[i].color.B / (float) byte.MaxValue, (float) this.dyn.element[i].color.A / (float) byte.MaxValue);
            else if (this.bmpLink[i] > -1)
              DrawMod.DrawScaled(ref g, ref this.bmp[this.bmpLink[i]], this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
          }
        }
        else if (this.dyn.element[i].ow > 0 & this.dyn.element[i].eventPicture > 0)
        {
          ref Graphics local25 = ref g;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]);
          ref Bitmap local26 = ref bitmap12;
          rectangle = new Rectangle(this.dyn.element[i].ox, this.dyn.element[i].oy, this.dyn.element[i].ow, this.dyn.element[i].oh);
          Rectangle srcrect = rectangle;
          trect = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
          Rectangle destrect = trect;
          DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect, destrect);
        }
        else if (this.dyn.element[i].w > 0 & this.dyn.element[i].eventPicture > 0)
        {
          if (this.dyn.element[i].color.A != byte.MaxValue)
          {
            ref Graphics local27 = ref g;
            Bitmap bitmap13 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]);
            ref Bitmap local28 = ref bitmap13;
            rectangle = new Rectangle(0, 0, BitmapStore.GetWidth(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]), BitmapStore.Getheight(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]));
            Rectangle srcrect = rectangle;
            trect = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            Rectangle destrect = trect;
            double alpha = (double) ((float) this.dyn.element[i].color.A / (float) byte.MaxValue);
            DrawMod.DrawSimplePartAlpha(ref local27, ref local28, srcrect, destrect, (float) alpha);
          }
          else if (this.dyn.element[i].color.R != byte.MaxValue | this.dyn.element[i].color.G != byte.MaxValue | this.dyn.element[i].color.B != byte.MaxValue)
          {
            ref Graphics local29 = ref g;
            Bitmap bitmap14 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]);
            ref Bitmap local30 = ref bitmap14;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            int w = this.dyn.element[i].w;
            int h = this.dyn.element[i].h;
            int width = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]).Width;
            int height = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]).Height;
            double r = (double) ((float) this.dyn.element[i].color.R / (float) byte.MaxValue);
            double g5 = (double) ((float) this.dyn.element[i].color.G / (float) byte.MaxValue);
            double b = (double) ((float) this.dyn.element[i].color.B / (float) byte.MaxValue);
            DrawMod.DrawScaledColorized2(ref local29, ref local30, x, y, w, h, width, height, (float) r, (float) g5, (float) b, (float) byte.MaxValue);
          }
          else if (this.dyn.element[i].h > 0)
          {
            ref Graphics local31 = ref g;
            Bitmap bitmap15 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.dyn.element[i].eventPicture]);
            ref Bitmap local32 = ref bitmap15;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            int w = this.dyn.element[i].w;
            int h = this.dyn.element[i].h;
            DrawMod.DrawScaled(ref local31, ref local32, x, y, w, h);
          }
        }
        else if (Conversions.ToDouble(this.dyn.element[i].value) > 0.0 & Operators.CompareString(this.dyn.element[i].mouseOver, "", false) == 0 && Operators.CompareString(this.dyn.element[i].key, "", false) == 0)
        {
          if (Conversions.ToDouble(this.dyn.element[i].value) > 0.0 & this.dyn.element[i].x > 0 & Conversions.ToDouble(this.dyn.element[i].value) <= (double) this.game.Data.UnitCounter)
          {
            this.game.CustomBitmapObj.DrawUnitBig(Conversions.ToInteger(this.dyn.element[i].value), toG: g, tx: this.dyn.element[i].x, ty: this.dyn.element[i].y);
          }
          else
          {
            int num15 = num15;
          }
        }
        if (!Information.IsNothing((object) this.dyn.element[i].mouseOver) && firstCall & this.dyn.element[i].mouseOver.Length > 1)
        {
          if (this.dyn.element[i].eventNr > 0)
          {
            rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            trect = rectangle;
            this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, i, 9);
          }
          else
          {
            rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            trect = rectangle;
            this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, i);
          }
        }
      }
      if (this.dyn.element[i].type == UDSType.Button)
      {
        int index = this.game.AddDynFont(this.dyn.element[i].fontName, this.dyn.element[i].fontSize, this.dyn.element[i].fontStyle);
        if (index > -1 & this.backBitmapCounter < 199 & !this.dyn.element[i].hidden)
        {
          if (firstCall)
          {
            ++this.backBitmapCounter;
            this.backBmp[this.backBitmapCounter] = new Bitmap(this.dyn.element[i].w, this.dyn.element[i].h, PixelFormat.Format32bppPArgb);
            this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            Expression = Graphics.FromImage((Image) this.backBmp[this.backBitmapCounter]);
            Expression.CompositingMode = CompositingMode.SourceCopy;
            Graphics graphics = Expression;
            Bitmap paper = this.paper;
            rectangle = new Rectangle(0, 0, this.backBmp[this.backBitmapCounter].Width, this.backBmp[this.backBitmapCounter].Height);
            Rectangle destRect = rectangle;
            trect = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            Rectangle srcRect = trect;
            graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
            Expression.CompositingMode = CompositingMode.SourceOver;
            this.backBmpLink[i] = this.backBitmapCounter;
          }
          else
            g.DrawImage((Image) this.backBmp[this.backBmpLink[i]], this.dyn.element[i].x, this.dyn.element[i].y);
          string texty = this.dyn.element[i].texty;
          int w = this.dyn.element[i].w;
          string mouseOver = this.dyn.element[i].mouseOver;
          bitmap1 = (Bitmap) null;
          ref Bitmap local = ref bitmap1;
          int num = this.dyn.element[i].grayed == 1 ? 1 : 0;
          int h = this.dyn.element[i].h;
          int fontSize = this.dyn.element[i].fontSize;
          Font usefont = this.game.DynFont[index];
          int subtype = this.dyn.element[i].subtype;
          TextButtonPartClass textButtonPartClass = new TextButtonPartClass(texty, w, mouseOver, ref local, tinactive: (num != 0), theight: h, tfontsize: fontSize, usefont: usefont, tudsButton: true, tudsButtonSubType: subtype);
          if (high)
            textButtonPartClass.PaintOverlay();
          else
            textButtonPartClass.Paint();
          g.DrawImage((Image) textButtonPartClass.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
          if (firstCall & this.dyn.element[i].grayed == 0)
          {
            rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
            trect = rectangle;
            this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, i, 1);
          }
          else if (firstCall & this.dyn.element[i].grayed == 1)
          {
            if (this.dyn.element[i].parentElement > -1)
            {
              rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
              trect = rectangle;
              this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, i, 1);
            }
            else
            {
              rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
              trect = rectangle;
              this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, ttype: -1);
            }
          }
        }
      }
      if (this.dyn.element[i].type == UDSType.Line)
        DrawMod.drawLine(ref g, this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h, this.dyn.element[i].color, Math.Max(1, this.dyn.element[i].lineHeight));
      if (this.dyn.element[i].type == UDSType.Slider)
      {
        int index = this.game.AddDynFont(this.dyn.element[i].fontName, this.dyn.element[i].fontSize, this.dyn.element[i].fontStyle);
        if (index > -1)
        {
          ref Graphics local33 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
          ref Bitmap local34 = ref bitmap1;
          int x = this.dyn.element[i].x;
          int y = this.dyn.element[i].y;
          int w1 = this.dyn.element[i].w;
          int lineHeight1 = this.dyn.element[i].lineHeight;
          DrawMod.DrawScaled(ref local33, ref local34, x, y, w1, lineHeight1);
          DrawMod.DrawBlock(ref g, this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].lineHeight, 0, 0, 0, 32);
          string str1 = this.dyn.element[i].texty.Replace("<value>", this.dyn.element[i].value.ToString()).Replace(" 000", " 0").Replace(" 00", " 0");
          if (this.game.Data.Product == 7)
          {
            int Start = Strings.InStr(str1, "[[");
            if (Start > 0)
            {
              int num16 = Strings.InStr(Start, str1, "]]");
              if (num16 > 0 & num16 > Start)
              {
                string str2 = Strings.Mid(str1, Start, num16 - Start + 2);
                string str3 = Strings.Mid(str2, 3, str2.Length - 4);
                int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 169, 0, 0));
                int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 168, 0, 0));
                EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
                int id1 = this.game.Data.StringListObj[stringListById4].ID;
                int id2 = this.game.Data.StringListObj[stringListById3].ID;
                string logicString = str3;
                Random random = (Random) null;
                ref Random local35 = ref random;
                int num17 = eventRelatedObj.CheckLogicStringStart(id1, id2, logicString, 0, ref local35);
                str1 = str1.Replace(str2, num17.ToString());
              }
            }
          }
          GameClass game = this.game;
          int w2 = this.dyn.element[i].w;
          int trows = (int) Math.Round((double) this.dyn.element[i].h / (double) this.dyn.element[i].lineHeight);
          Font tfont = this.game.DynFont[index];
          string tText = str1;
          int lineHeight2 = this.dyn.element[i].lineHeight;
          bitmap1 = (Bitmap) null;
          ref Bitmap local36 = ref bitmap1;
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(game, w2, trows, tfont, tText, lineHeight2, ref local36, tWithoutScrollbars: true, tWithoutFrame: true, cola: ((int) byte.MaxValue), tshadow: false, tminimalHeight: true);
          textAreaClass2.Paint();
          g.DrawImage((Image) textAreaClass2.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
          textAreaClass2.Dispose();
          NumberSliderSubPartClassUDS sliderSubPartClassUds = new NumberSliderSubPartClassUDS(this.game, this.dyn.element[i].w, this.dyn.element[i].h - this.dyn.element[i].lineHeight, this.dyn.element[i].minvalue, this.dyn.element[i].maxvalue, Conversions.ToInteger(this.dyn.element[i].value));
          if (high)
            sliderSubPartClassUds.PaintOverlay();
          else
            sliderSubPartClassUds.Paint();
          g.DrawImage((Image) sliderSubPartClassUds.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y + this.dyn.element[i].lineHeight);
          if (firstCall & this.dyn.element[i].grayed == 0)
          {
            rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y + this.dyn.element[i].lineHeight, this.dyn.element[i].w, this.dyn.element[i].h - this.dyn.element[i].lineHeight);
            trect = rectangle;
            this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, i, 3);
          }
          sliderSubPartClassUds.Dispose();
        }
      }
      if (this.dyn.element[i].type == UDSType.Flag & this.backBitmapCounter < 199)
      {
        if (firstCall)
        {
          ++this.backBitmapCounter;
          this.backBmp[this.backBitmapCounter] = new Bitmap(this.dyn.element[i].w, this.dyn.element[i].h, PixelFormat.Format32bppPArgb);
          this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          Expression = Graphics.FromImage((Image) this.backBmp[this.backBitmapCounter]);
          Expression.CompositingMode = CompositingMode.SourceCopy;
          Graphics graphics = Expression;
          Bitmap paper = this.paper;
          rectangle = new Rectangle(0, 0, this.backBmp[this.backBitmapCounter].Width, this.backBmp[this.backBitmapCounter].Height);
          Rectangle destRect = rectangle;
          trect = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
          Rectangle srcRect = trect;
          graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
          Expression.CompositingMode = CompositingMode.SourceOver;
          this.backBmpLink[i] = this.backBitmapCounter;
        }
        else
          g.DrawImage((Image) this.backBmp[this.backBmpLink[i]], this.dyn.element[i].x, this.dyn.element[i].y);
        if (this.dyn.element[i].h < 35)
        {
          MarcRadioPartClass2 marcRadioPartClass2;
          if (this.dyn.element[i].flagged)
          {
            string mouseOver = this.dyn.element[i].mouseOver;
            bitmap1 = (Bitmap) null;
            ref Bitmap local = ref bitmap1;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            marcRadioPartClass2 = new MarcRadioPartClass2(0, true, mouseOver, ref local, x, y, true);
          }
          else
          {
            string mouseOver = this.dyn.element[i].mouseOver;
            bitmap1 = (Bitmap) null;
            ref Bitmap local = ref bitmap1;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            marcRadioPartClass2 = new MarcRadioPartClass2(0, false, mouseOver, ref local, x, y, true);
          }
          if (high)
            marcRadioPartClass2.PaintOverlay();
          else
            marcRadioPartClass2.Paint();
          g.DrawImage((Image) marcRadioPartClass2.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
        }
        else
        {
          MarcRadioPartClass marcRadioPartClass;
          if (this.dyn.element[i].flagged)
          {
            string mouseOver = this.dyn.element[i].mouseOver;
            bitmap1 = (Bitmap) null;
            ref Bitmap local = ref bitmap1;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            marcRadioPartClass = new MarcRadioPartClass(0, true, mouseOver, ref local, x, y, true);
          }
          else
          {
            string mouseOver = this.dyn.element[i].mouseOver;
            bitmap1 = (Bitmap) null;
            ref Bitmap local = ref bitmap1;
            int x = this.dyn.element[i].x;
            int y = this.dyn.element[i].y;
            marcRadioPartClass = new MarcRadioPartClass(0, false, mouseOver, ref local, x, y, true);
          }
          if (high)
            marcRadioPartClass.PaintOverlay();
          else
            marcRadioPartClass.Paint();
          g.DrawImage((Image) marcRadioPartClass.OwnBitmap, this.dyn.element[i].x, this.dyn.element[i].y);
        }
        if (firstCall)
        {
          rectangle = new Rectangle(this.dyn.element[i].x, this.dyn.element[i].y, this.dyn.element[i].w, this.dyn.element[i].h);
          trect = rectangle;
          this.AddMouse(ref trect, "", this.dyn.element[i].mouseOver, i, 2);
        }
      }
      if (!firstCall || Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public override Bitmap Paint()
    {
      SizeF sizeF = new SizeF();
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.lastY != this.curY)
      {
        int num = this.lastY - this.curY;
        int mouseCounter = this.MouseCounter;
        for (int index1 = 0; index1 <= mouseCounter; ++index1)
        {
          Rectangle[] mouseRect = this.MouseRect;
          Rectangle[] rectangleArray = mouseRect;
          int index2 = index1;
          int index3 = index2;
          rectangleArray[index3].Y = mouseRect[index2].Y + num;
        }
        this.lastY = this.curY;
      }
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimpleFast(ref objGraphics, ref this.backbitmap, ref this.OwnBitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      Graphics graphics = objGraphics;
      Bitmap paper = this.paper;
      Rectangle rectangle1 = new Rectangle(0, 0, this.Width, this.Height);
      Rectangle destRect = rectangle1;
      Rectangle rectangle2 = new Rectangle(0, this.curY, this.Width, this.Height);
      Rectangle srcRect = rectangle2;
      graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
      if (!this.alwaysBlockScrollBar && this.maxY > this.Height)
      {
        int x1 = this.Width - 20;
        int num = (int) Math.Round((double) (this.Height - 16) * ((double) this.curY / (double) (this.maxY - this.Height)) + 8.0);
        if (num > this.Height - 16)
          num = this.Height - 16;
        ref Graphics local1 = ref objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local2 = ref bitmap;
        rectangle2 = new Rectangle(0, 3, 20, 4);
        Rectangle srcrect1 = rectangle2;
        rectangle1 = new Rectangle(x1, 3, 20, this.Height);
        Rectangle destrect1 = rectangle1;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 20, 3);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(x1, 0, 20, 3);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local6 = ref bitmap;
        rectangle2 = new Rectangle(0, 7, 20, 3);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(x1, this.Height - 8, 20, 3);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTUP);
        ref Bitmap local8 = ref bitmap;
        int x2 = x1;
        DrawMod.DrawSimple(ref local7, ref local8, x2, 0);
        ref Graphics local9 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTDOWN);
        ref Bitmap local10 = ref bitmap;
        int x3 = x1;
        int y1 = this.Height - 8;
        DrawMod.DrawSimple(ref local9, ref local10, x3, y1);
        ref Graphics local11 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
        ref Bitmap local12 = ref bitmap;
        int x4 = x1;
        int y2 = num;
        DrawMod.DrawSimple(ref local11, ref local12, x4, y2);
      }
      return this.OwnBitmap;
    }

    public override void ShiftDown()
    {
      if (this.maxY <= this.Height)
        return;
      this.curY += 20;
      if (this.curY <= this.maxY - this.Height)
        return;
      this.curY = this.maxY - this.Height;
    }

    public override void ShiftUp()
    {
      if (this.maxY <= this.Height)
        return;
      this.curY -= 20;
      if (0 <= this.curY)
        return;
      this.curY = 0;
    }

    public override int HandleBLOCKEDMouseUp(int x, int y) => this.HandleMouseUp(x, y);

    public override int HandleMouseUp(int x, int y)
    {
      if (this.clickscroll == 1 | this.Scroller)
      {
        this.clickscroll = 0;
        this.Scroller = false;
        this.scrollelementclicked = -1;
        this.scrollelementclicked2 = -1;
        return 1;
      }
      if (this.scrollelementclicked > -1 && this.dyn.element[this.scrollelementclicked].eventNr > 0)
      {
        int scrollelementclicked = this.scrollelementclicked;
        if (this.dyn.element[scrollelementclicked].flagged)
          this.SetHiddenAndBaseData(scrollelementclicked, this.dyn.element[scrollelementclicked].key, this.dyn.element[scrollelementclicked].value);
        if (!this.dyn.element[scrollelementclicked].flagged)
          this.SetHiddenAndBaseData(scrollelementclicked, this.dyn.element[scrollelementclicked].key, Conversions.ToString(0));
        return this.dyn.element[scrollelementclicked].eventNr;
      }
      this.scrollelementclicked = -1;
      if (this.scrollelementclicked2 > -1 && this.dyn.element[this.scrollelementclicked2].eventNr > 0)
      {
        int scrollelementclicked2 = this.scrollelementclicked2;
        if (this.dyn.element[scrollelementclicked2].flagged)
          this.SetHiddenAndBaseData(scrollelementclicked2, this.dyn.element[scrollelementclicked2].key, this.dyn.element[scrollelementclicked2].value);
        if (!this.dyn.element[scrollelementclicked2].flagged)
          this.SetHiddenAndBaseData(scrollelementclicked2, this.dyn.element[scrollelementclicked2].key, Conversions.ToString(0));
        return this.dyn.element[scrollelementclicked2].eventNr;
      }
      this.scrollelementclicked2 = -1;
      return -1;
    }

    public void SetHiddenAndBaseData(int elementSlotClicked, string tkey, string tval)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
      this.game.EditObj.UDSClearInput();
      this.game.EditObj.UDSAddInput(tkey, tval);
      int elementCounter1 = this.dyn.elementCounter;
      for (int index1 = 0; index1 <= elementCounter1; ++index1)
      {
        if (!Information.IsNothing((object) this.dyn.element[index1].key) && elementSlotClicked != index1 & this.dyn.element[index1].key.Length > 0)
        {
          if (this.dyn.element[index1].type == UDSType.Hidden)
            this.game.EditObj.UDSAddInput(this.dyn.element[index1].key, this.dyn.element[index1].value);
          else if (this.dyn.element[index1].type == UDSType.Flag)
          {
            if (this.dyn.element[index1].flagged)
            {
              this.game.EditObj.UDSAddInput(this.dyn.element[index1].key, this.dyn.element[index1].value);
            }
            else
            {
              bool flag = true;
              int elementCounter2 = this.dyn.elementCounter;
              for (int index2 = 0; index2 <= elementCounter2; ++index2)
              {
                if (Operators.CompareString(this.dyn.element[index2].key, this.dyn.element[index1].key, false) == 0 & this.dyn.element[index2].flagged)
                  flag = false;
              }
              if (flag)
                this.game.EditObj.UDSAddInput(this.dyn.element[index1].key, 0);
            }
          }
          else if (this.dyn.element[index1].type == UDSType.Slider)
            this.game.EditObj.UDSAddInput(this.dyn.element[index1].key, this.dyn.element[index1].value);
        }
      }
    }

    public override int Click(int x, int y, int b = 1)
    {
      this.scrollelementclicked = -1;
      this.scrollelementclicked2 = -1;
      int mouseCounter1 = this.MouseCounter;
      for (int index1 = 0; index1 <= mouseCounter1; ++index1)
      {
        if (x > this.MouseRect[index1].X & x < this.MouseRect[index1].X + this.MouseRect[index1].Width && y > this.MouseRect[index1].Y & y < this.MouseRect[index1].Y + this.MouseRect[index1].Height)
        {
          float a1 = (float) this.MouseData[index1];
          if ((double) a1 > -1.0 && !Information.IsNothing((object) this.dyn.element[(int) Math.Round((double) a1)].key) & (this.MouseType[index1] == 0 | this.MouseType[index1] == 1))
          {
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_RENAMEUNIT", false) == 0 & (int) Math.Round(Conversion.Val(this.dyn.element[(int) Math.Round((double) a1)].value)) > -1)
            {
              this.game.EditObj.interfaceCue = 2;
              float integer = (float) Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a1)].value);
              string str = Interaction.InputBox("Give new name for unit", "Rename unit", this.game.Data.UnitObj[(int) Math.Round((double) integer)].Name);
              this.game.Data.UnitObj[(int) Math.Round((double) integer)].Name = str;
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            float integer1;
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_TEMPRENAME", false) == 0 & (int) Math.Round(Conversion.Val(this.dyn.element[(int) Math.Round((double) a1)].value)) > -1)
            {
              this.game.EditObj.interfaceCue = 2;
              integer1 = (float) Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a1)].value);
              this.game.EditObj.tempRenameString = Interaction.InputBox("Give new name", "Rename", this.game.EditObj.tempRenameString);
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_TEMPRENAME2", false) == 0 & (int) Math.Round(Conversion.Val(this.dyn.element[(int) Math.Round((double) a1)].value)) > -1)
            {
              this.game.EditObj.interfaceCue = 2;
              integer1 = (float) Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a1)].value);
              this.game.EditObj.tempRenameString2 = Interaction.InputBox("Give new name", "Rename", this.game.EditObj.tempRenameString2);
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_TEMPRENAME3", false) == 0 & (int) Math.Round(Conversion.Val(this.dyn.element[(int) Math.Round((double) a1)].value)) > -1)
            {
              this.game.EditObj.interfaceCue = 2;
              integer1 = (float) Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a1)].value);
              this.game.EditObj.tempRenameString3 = Interaction.InputBox("Give new name", "Rename", this.game.EditObj.tempRenameString3);
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_RENAMEKEY", false) == 0 & this.dyn.element[(int) Math.Round((double) a1)].value.Length > 1)
            {
              this.game.EditObj.interfaceCue = 2;
              string DefaultResponse = "";
              int elementCounter1 = this.dyn.elementCounter;
              for (int index2 = 0; index2 <= elementCounter1; ++index2)
              {
                if (Operators.CompareString(Strings.LCase(this.dyn.element[index2].key), Strings.LCase(this.dyn.element[(int) Math.Round((double) a1)].value), false) == 0)
                {
                  DefaultResponse = this.dyn.element[index2].value;
                  break;
                }
              }
              string str = Interaction.InputBox("Give new name", "Give new name", DefaultResponse);
              int elementCounter2 = this.dyn.elementCounter;
              for (int elementSlotClicked = 0; elementSlotClicked <= elementCounter2; ++elementSlotClicked)
              {
                if (Operators.CompareString(Strings.LCase(this.dyn.element[elementSlotClicked].key), Strings.LCase(this.dyn.element[(int) Math.Round((double) a1)].value), false) == 0)
                {
                  this.dyn.element[elementSlotClicked].value = str;
                  this.SetHiddenAndBaseData(elementSlotClicked, this.dyn.element[elementSlotClicked].key, this.dyn.element[elementSlotClicked].value);
                  break;
                }
              }
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            Color color;
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_RECOLORKEY", false) == 0 & this.dyn.element[(int) Math.Round((double) a1)].value.Length > 1)
            {
              this.game.EditObj.interfaceCue = 2;
              string str1 = "";
              int elementCounter3 = this.dyn.elementCounter;
              for (int index3 = 0; index3 <= elementCounter3; ++index3)
              {
                if (Operators.CompareString(Strings.LCase(this.dyn.element[index3].key), Strings.LCase(this.dyn.element[(int) Math.Round((double) a1)].value), false) == 0)
                {
                  str1 = this.dyn.element[index3].value;
                  break;
                }
              }
              string[] strArray = str1.Split('#');
              int red = (int) Math.Round(Conversion.Val(strArray[0]));
              int green = (int) Math.Round(Conversion.Val(strArray[1]));
              int blue = (int) Math.Round(Conversion.Val(strArray[2]));
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, red, green, blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                color = colorDialog.Color;
                blue = (int) color.B;
                color = colorDialog.Color;
                green = (int) color.G;
                color = colorDialog.Color;
                red = (int) color.R;
              }
              string str2 = red.ToString() + "#" + green.ToString() + "#" + blue.ToString();
              int elementCounter4 = this.dyn.elementCounter;
              for (int index4 = 0; index4 <= elementCounter4; ++index4)
              {
                if (Operators.CompareString(Strings.LCase(this.dyn.element[index4].key), Strings.LCase(this.dyn.element[(int) Math.Round((double) a1)].value), false) == 0)
                {
                  this.dyn.element[index4].value = str2;
                  break;
                }
              }
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_RECOLORUNIT", false) == 0 & (int) Math.Round(Conversion.Val(this.dyn.element[(int) Math.Round((double) a1)].value)) > -1)
            {
              this.game.EditObj.interfaceCue = 2;
              float integer2 = (float) Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a1)].value);
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.UnitObj[(int) Math.Round((double) integer2)].Red, this.game.Data.UnitObj[(int) Math.Round((double) integer2)].Green, this.game.Data.UnitObj[(int) Math.Round((double) integer2)].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                UnitClass unitClass1 = this.game.Data.UnitObj[(int) Math.Round((double) integer2)];
                color = colorDialog.Color;
                int b1 = (int) color.B;
                unitClass1.Blue = b1;
                UnitClass unitClass2 = this.game.Data.UnitObj[(int) Math.Round((double) integer2)];
                color = colorDialog.Color;
                int g = (int) color.G;
                unitClass2.Green = g;
                UnitClass unitClass3 = this.game.Data.UnitObj[(int) Math.Round((double) integer2)];
                color = colorDialog.Color;
                int r = (int) color.R;
                unitClass3.Red = r;
              }
              if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                return -1;
            }
            if (Operators.CompareString(this.dyn.element[(int) Math.Round((double) a1)].key, "HARD_SELECTUNIT", false) == 0 & (int) Math.Round(Conversion.Val(this.dyn.element[(int) Math.Round((double) a1)].value)) > -1)
            {
              this.game.EditObj.interfaceCue = 2;
              float integer3 = (float) Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a1)].value);
              if ((double) integer3 > -1.0)
              {
                int index5 = (int) Math.Round((double) integer3);
                int index6 = 0;
                if (this.game.Data.UnitObj[index5].X > -1)
                {
                  this.game.SelectX = this.game.Data.UnitObj[index5].X;
                  this.game.SelectY = this.game.Data.UnitObj[index5].Y;
                }
                else
                {
                  this.game.SelectX = this.game.Data.UnitObj[this.game.Data.UnitObj[index5].OnBoard].X;
                  this.game.SelectY = this.game.Data.UnitObj[this.game.Data.UnitObj[index5].OnBoard].Y;
                }
                while (this.game.Data.MapObj[index6].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] != index5)
                {
                  int unit = this.game.Data.MapObj[index6].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
                  index6 = 0;
                  if (this.game.Data.MapObj[index6].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > 0)
                  {
                    for (int unitCounter = this.game.Data.MapObj[index6].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter; unitCounter >= 1; unitCounter += -1)
                      this.game.Data.MapObj[index6].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter] = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter - 1];
                  }
                  this.game.Data.MapObj[index6].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] = unit;
                }
                this.game.EditObj.UnitSelected = index5;
                this.game.HandyFunctionsObj.SetcornerXY2();
                this.game.EditObj.TempCoordList = new CoordList();
                if (this.dyn.element[(int) Math.Round((double) a1)].eventNr < 0)
                  return -1;
              }
            }
          }
          if (this.MouseType[index1] == 25)
          {
            StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(this.dyn.element[this.MouseData[index1]].texty))];
            int num1 = y - this.dyn.element[this.MouseData[index1]].y + this.curY;
            if (num1 <= this.dyn.element[this.MouseData[index1]].lineHeight)
            {
              int col;
              if (stringListClass.ColWidth[0] > 0)
              {
                int num2 = x - this.dyn.element[this.MouseData[index1]].x;
                int num3 = 0;
                col = -1;
                int width = stringListClass.Width;
                for (int index7 = 0; index7 <= width; ++index7)
                {
                  num3 += stringListClass.ColWidth[index7];
                  if (num2 < num3)
                  {
                    col = index7;
                    break;
                  }
                }
                if (col == -1)
                  col = 0;
              }
              else
              {
                int num4 = (int) Math.Round((double) this.dyn.element[this.MouseData[index1]].w / (double) (stringListClass.Width + 1));
                col = (int) Math.Round(Math.Floor((double) (x - this.dyn.element[this.MouseData[index1]].x) / (double) num4));
              }
              stringListClass.Sort(col);
              if (DrawMod.TGame.EmpireStyle)
                SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
              Graphics g = Graphics.FromImage((Image) this.paper);
              this.DrawElement(this.MouseData[index1], ref g, false);
              g.Dispose();
            }
            else if (num1 <= this.dyn.element[this.MouseData[index1]].lineHeight * (this.dyn.element[this.MouseData[index1]].rowsPerPage + 1))
            {
              int index8;
              if (stringListClass.ColWidth[0] > 0)
              {
                int num5 = x - this.dyn.element[this.MouseData[index1]].x;
                int num6 = 0;
                index8 = -1;
                int width = stringListClass.Width;
                for (int index9 = 0; index9 <= width; ++index9)
                {
                  num6 += stringListClass.ColWidth[index9];
                  if (num5 < num6)
                  {
                    index8 = index9;
                    break;
                  }
                }
                if (index8 == -1)
                  index8 = 0;
              }
              else
              {
                int num7 = (int) Math.Round((double) this.dyn.element[this.MouseData[index1]].w / (double) (stringListClass.Width + 1));
                index8 = (int) Math.Round(Math.Floor((double) (x - this.dyn.element[this.MouseData[index1]].x) / (double) num7));
              }
              int index10 = (int) Math.Round(Math.Floor((double) (num1 - this.dyn.element[this.MouseData[index1]].lineHeight) / (double) this.dyn.element[this.MouseData[index1]].lineHeight)) + this.dyn.element[this.MouseData[index1]].topRow;
              if (index10 <= stringListClass.Length)
              {
                string Expression = stringListClass.TempDesc[index10, index8];
                if (!Information.IsNothing((object) Expression))
                {
                  string[] strArray = Expression.Split('#');
                  if (strArray.GetUpperBound(0) >= 1)
                  {
                    if (Operators.CompareString(strArray[1], "HARDXY", false) == 0)
                    {
                      this.game.EditObj.interfaceCue = 2;
                      this.game.SelectX = (int) Math.Round(Conversion.Val(strArray[2]));
                      this.game.SelectY = (int) Math.Round(Conversion.Val(strArray[3]));
                      if (strArray.GetUpperBound(0) >= 4)
                      {
                        this.game.EditObj.SetViewModeExtraNr = (int) Math.Round(Conversion.Val(strArray[4]));
                        if (this.game.EditObj.SetViewModeExtraNr == 3)
                          this.game.EditObj.se1_SelectAssetButton = -1;
                      }
                      if (strArray.GetUpperBound(0) >= 5)
                      {
                        this.game.EditObj.SetViewModeExtraNr = (int) Math.Round(Conversion.Val(strArray[4]));
                        if ((double) this.game.Data.RuleVar[701] > 0.0)
                        {
                          this.game.EditObj.UnitSelected = (int) Math.Round(Conversion.Val(strArray[5]));
                          ScreenClass screeny = this.game.FormRef.Screeny;
                          System.Type type = typeof (MapWindowClass2);
                          ref System.Type local = ref type;
                          ((MapWindowClass2) screeny.GetWindow(ref local)).UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                        }
                      }
                      this.game.HandyFunctionsObj.SetcornerXY2();
                      this.game.EditObj.TempCoordList = new CoordList();
                      return -1;
                    }
                    int num8 = (int) Math.Round(Conversion.Val(strArray[1]));
                    if (strArray.GetUpperBound(0) >= 3)
                      this.SetHiddenAndBaseData(this.MouseData[index1], strArray[2], strArray[3]);
                    if (strArray.GetUpperBound(0) >= 5)
                      this.SetHiddenAndBaseData(this.MouseData[index1], strArray[4], strArray[5]);
                    if (strArray.GetUpperBound(0) >= 7)
                      this.SetHiddenAndBaseData(this.MouseData[index1], strArray[6], strArray[7]);
                    if (strArray.GetUpperBound(0) >= 9)
                      this.SetHiddenAndBaseData(this.MouseData[index1], strArray[8], strArray[9]);
                    return num8 <= 0 ? -999 : num8;
                  }
                }
              }
            }
          }
          if (this.MouseType[index1] == 1 | this.MouseType[index1] == 9)
          {
            int elementSlotClicked = this.MouseData[index1];
            int parentElement = this.dyn.element[elementSlotClicked].parentElement;
            if (parentElement > -1 & this.dyn.element[elementSlotClicked].grayed == 0)
            {
              if (this.dyn.element[parentElement].type == UDSType.Table)
              {
                if (this.dyn.element[elementSlotClicked].childType == 1)
                  this.dyn.element[parentElement].topRow = 0;
                if (this.dyn.element[elementSlotClicked].childType == 2)
                  this.dyn.element[parentElement].topRow -= this.dyn.element[elementSlotClicked].childData;
                if (this.dyn.element[elementSlotClicked].childType == 4)
                {
                  this.dyn.element[parentElement].topRow = 0;
                  while (this.dyn.element[parentElement].topRow < this.dyn.element[parentElement].totalRows - this.dyn.element[elementSlotClicked].childData)
                    this.dyn.element[parentElement].topRow += this.dyn.element[elementSlotClicked].childData;
                }
                if (this.dyn.element[elementSlotClicked].childType == 3)
                  this.dyn.element[parentElement].topRow += this.dyn.element[elementSlotClicked].childData;
                if (this.dyn.element[parentElement].topRow < 0)
                  this.dyn.element[parentElement].topRow = 0;
                if (this.dyn.element[parentElement].topRow >= this.dyn.element[parentElement].totalRows - 1)
                  this.dyn.element[parentElement].topRow = this.dyn.element[parentElement].totalRows - 1;
                if (DrawMod.TGame.EmpireStyle)
                  SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
                Graphics g = Graphics.FromImage((Image) this.paper);
                this.DrawElement(parentElement, ref g, false);
                int elementCounter = this.dyn.elementCounter;
                for (int i = 0; i <= elementCounter; ++i)
                {
                  if (this.dyn.element[i].parentElement == parentElement)
                  {
                    if (this.dyn.element[i].type == UDSType.Button)
                    {
                      if (this.dyn.element[i].childType == 1)
                        this.dyn.element[i].grayed = this.dyn.element[parentElement].topRow > 0 ? 0 : 1;
                      if (this.dyn.element[i].childType == 2)
                        this.dyn.element[i].grayed = this.dyn.element[parentElement].topRow > 0 ? 0 : 1;
                      if (this.dyn.element[i].childType == 3)
                        this.dyn.element[i].grayed = this.dyn.element[parentElement].topRow < this.dyn.element[parentElement].totalRows - this.dyn.element[elementSlotClicked].childData ? 0 : 1;
                      if (this.dyn.element[i].childType == 4)
                        this.dyn.element[i].grayed = this.dyn.element[parentElement].topRow < this.dyn.element[parentElement].totalRows - this.dyn.element[elementSlotClicked].childData ? 0 : 1;
                    }
                    if (this.dyn.element[i].type == UDSType.TextField)
                    {
                      float num9 = (float) ((int) Math.Round(Math.Floor((double) this.dyn.element[parentElement].topRow / (double) this.dyn.element[parentElement].rowsPerPage)) + 1);
                      float num10 = (float) ((int) Math.Round(Math.Floor((double) (this.dyn.element[parentElement].totalRows - 1) / (double) this.dyn.element[parentElement].rowsPerPage)) + 1);
                      this.dyn.element[i].texty = "Page " + num9.ToString() + "/" + num10.ToString();
                    }
                    this.DrawElement(i, ref g, false, elementSlotClicked == i);
                  }
                }
              }
              return -1;
            }
            if (this.dyn.element[elementSlotClicked].grayed == 0)
            {
              this.SetHiddenAndBaseData(elementSlotClicked, this.dyn.element[elementSlotClicked].key, this.dyn.element[elementSlotClicked].value);
              return this.dyn.element[elementSlotClicked].eventNr <= 0 ? -999 : this.dyn.element[elementSlotClicked].eventNr;
            }
          }
          if (this.MouseType[index1] == 2)
          {
            float a2 = (float) this.MouseData[index1];
            if (this.dyn.element[(int) Math.Round((double) a2)].grayed < 1)
            {
              if (DrawMod.TGame.EmpireStyle)
                SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
              Graphics g = Graphics.FromImage((Image) this.paper);
              if (this.dyn.element[(int) Math.Round((double) a2)].flagged)
              {
                int num11 = 0;
                int num12 = 0;
                int mouseCounter2 = this.MouseCounter;
                for (int index11 = 0; index11 <= mouseCounter2; ++index11)
                {
                  if (index1 != index11 & this.MouseType[index11] == 2)
                  {
                    float a3 = (float) this.MouseData[index11];
                    if (this.dyn.element[(int) Math.Round((double) a2)].group == this.dyn.element[(int) Math.Round((double) a3)].group & this.dyn.element[(int) Math.Round((double) a2)].group > 0)
                    {
                      if (this.dyn.element[(int) Math.Round((double) a3)].flagged)
                      {
                        ++num12;
                        ++num11;
                      }
                      else
                        ++num11;
                    }
                  }
                }
                if (num12 > 0 | num11 == 0)
                  this.dyn.element[(int) Math.Round((double) a2)].flagged = false;
              }
              else
                this.dyn.element[(int) Math.Round((double) a2)].flagged = true;
              int mouseCounter3 = this.MouseCounter;
              for (int index12 = 0; index12 <= mouseCounter3; ++index12)
              {
                if (index1 != index12 & this.MouseType[index12] == 2)
                {
                  float a4 = (float) this.MouseData[index12];
                  if (this.dyn.element[(int) Math.Round((double) a2)].group == this.dyn.element[(int) Math.Round((double) a4)].group & this.dyn.element[(int) Math.Round((double) a2)].group > 0 && this.dyn.element[(int) Math.Round((double) a2)].flagged)
                  {
                    this.dyn.element[(int) Math.Round((double) a4)].flagged = false;
                    this.DrawElement((int) Math.Round((double) a4), ref g, false);
                  }
                }
              }
              if (this.dyn.element[(int) Math.Round((double) a2)].eventNr > 0)
              {
                if (this.dyn.element[(int) Math.Round((double) a2)].flagged)
                  this.SetHiddenAndBaseData((int) Math.Round((double) a2), this.dyn.element[(int) Math.Round((double) a2)].key, this.dyn.element[(int) Math.Round((double) a2)].value);
                if (!this.dyn.element[(int) Math.Round((double) a2)].flagged)
                  this.SetHiddenAndBaseData((int) Math.Round((double) a2), this.dyn.element[(int) Math.Round((double) a2)].key, Conversions.ToString(0));
                return this.dyn.element[(int) Math.Round((double) a2)].eventNr;
              }
              this.DrawElement((int) Math.Round((double) a2), ref g, false);
              return -1;
            }
          }
          if (this.MouseType[index1] == 3)
          {
            Graphics g = Graphics.FromImage((Image) this.paper);
            float a5 = (float) this.MouseData[index1];
            this.dyn.element[(int) Math.Round((double) a5)].flagged = !this.dyn.element[(int) Math.Round((double) a5)].flagged;
            int num13 = (int) Math.Round(Math.Max(20.0, (double) this.MouseRect[index1].Width / 10.0));
            int num14 = x - this.MouseRect[index1].X;
            int num15 = this.MouseRect[index1].Width - num13;
            int num16;
            if (num14 < this.MouseRect[index1].Height)
            {
              num16 = Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a5)].value) - 1;
              if (num16 < this.dyn.element[(int) Math.Round((double) a5)].minvalue)
                num16 = this.dyn.element[(int) Math.Round((double) a5)].minvalue;
              this.scrollelementclicked2 = (int) Math.Round((double) a5);
            }
            else if (num14 > this.MouseRect[index1].Width - this.MouseRect[index1].Height)
            {
              num16 = Conversions.ToInteger(this.dyn.element[(int) Math.Round((double) a5)].value) + 1;
              if (num16 > this.dyn.element[(int) Math.Round((double) a5)].maxvalue)
                num16 = this.dyn.element[(int) Math.Round((double) a5)].maxvalue;
              this.scrollelementclicked2 = (int) Math.Round((double) a5);
            }
            else
            {
              if ((double) num14 < (double) num13 / 2.0)
                num16 = this.dyn.element[(int) Math.Round((double) a5)].minvalue;
              else if ((double) num14 > (double) this.MouseRect[index1].Width - (double) num13 / 2.0)
              {
                num16 = this.dyn.element[(int) Math.Round((double) a5)].maxvalue;
              }
              else
              {
                int num17 = (int) Math.Round((double) num14 - (double) num13 / 2.0);
                num16 = (int) Math.Round((double) (this.dyn.element[(int) Math.Round((double) a5)].maxvalue - this.dyn.element[(int) Math.Round((double) a5)].minvalue) * ((double) num17 / (double) num15)) + this.dyn.element[(int) Math.Round((double) a5)].minvalue;
              }
              this.scrollelementclicked = (int) Math.Round((double) a5);
            }
            this.dyn.element[(int) Math.Round((double) a5)].value = Conversions.ToString(num16);
            if (this.AdjustSliders((int) Math.Round((double) a5)))
            {
              float elementCounter = (float) this.dyn.elementCounter;
              for (float a6 = 0.0f; (double) a6 <= (double) elementCounter; ++a6)
              {
                if ((double) a5 != (double) a6 & this.dyn.element[(int) Math.Round((double) a6)].type == UDSType.Slider & this.dyn.element[(int) Math.Round((double) a6)].group == this.dyn.element[(int) Math.Round((double) a5)].group)
                  this.DrawElement((int) Math.Round((double) a6), ref g, false, true);
              }
            }
            this.DrawElement((int) Math.Round((double) a5), ref g, false, true);
            return -1;
          }
        }
      }
      if (this.alwaysBlockScrollBar || this.maxY <= this.Height || x <= this.Width - 20)
        return -1;
      if (y >= 0 & y <= 8)
      {
        this.curY -= 20;
        this.clickscroll = 0;
        if (0 > this.curY)
          this.curY = 0;
        return -1;
      }
      if (y > this.Height - 8)
      {
        this.curY += 20;
        this.clickscroll = 0;
        if (this.curY > this.maxY - this.Height)
          this.curY = this.maxY - this.Height;
        return -1;
      }
      this.clickscroll = 1;
      this.Scroller = true;
      this.curY = (int) Math.Round((double) (this.maxY - this.Height) * ((double) (y - 8) / (double) (this.Height - 16)));
      if (0 > this.curY)
        this.curY = 0;
      if (this.curY > this.maxY - this.Height)
        this.curY = this.maxY - this.Height;
      return -1;
    }

    public override bool MouseMove(int x, int y)
    {
      if (this.alwaysBlockScrollBar || this.clickscroll != 1)
        return false;
      this.clickscroll = 1;
      this.Scroller = true;
      this.clickscroll = 1;
      this.Scroller = true;
      this.curY = (int) Math.Round((double) (this.maxY - this.Height) * ((double) (y - 8) / (double) (this.Height - 16)));
      if (0 > this.curY)
        this.curY = 0;
      if (this.curY > this.maxY - this.Height)
        this.curY = this.maxY - this.Height;
      return true;
    }

    public void unloadAnyStuff()
    {
      int index1 = 0;
      do
      {
        if (!Information.IsNothing((object) this.bmp[index1]))
        {
          this.bmp[index1].Dispose();
          this.bmp[index1] = (Bitmap) null;
        }
        ++index1;
      }
      while (index1 <= 29);
      int upperBound = this.backBmp.GetUpperBound(0);
      for (int index2 = 0; index2 <= upperBound; ++index2)
      {
        if (!Information.IsNothing((object) this.backBmp[index2]))
        {
          this.backBmp[index2].Dispose();
          this.backBmp[index2] = (Bitmap) null;
        }
      }
    }

    public void loadPageStuff()
    {
      string str = this.game.AppPath + "graphics/";
      this.unloadAnyStuff();
      int slot = 0;
      this.bmpLink = new int[this.dyn.elementCounter + 1];
      int elementCounter = this.dyn.elementCounter;
      for (int index = 0; index <= elementCounter; ++index)
      {
        this.bmpLink[index] = -1;
        if (!Information.IsNothing((object) this.dyn.element[index].tempPicture) && this.dyn.element[index].type == UDSType.PictureField & this.dyn.element[index].tempPicture.Length > 1)
        {
          this.bmpLink[index] = -1;
          this.loadSpecificBmp(str + this.dyn.element[index].tempPicture, slot, this.dyn.element[index].rotation);
          this.bmpLink[index] = slot;
          if (this.dyn.element[index].rotation == -1)
            DrawMod.MakeFuzzyBorder(ref this.bmp[this.bmpLink[index]], 30, 2);
          if (this.dyn.element[index].h == -1)
          {
            this.dyn.element[index].w = this.bmp[this.bmpLink[index]].Width;
            this.dyn.element[index].h = this.bmp[this.bmpLink[index]].Height;
          }
          ++slot;
        }
      }
    }

    public void loadSpecificBmp(string s, int slot, int rotate)
    {
      if (!Information.IsNothing((object) this.bmp[slot]))
      {
        this.bmp[slot].Dispose();
        this.bmp[slot] = (Bitmap) null;
      }
      FileStream fileStream = new FileStream(s, FileMode.Open, FileAccess.Read);
      Bitmap bitmap1 = (Bitmap) Image.FromStream((Stream) fileStream);
      Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap2);
      if (rotate > 0)
      {
        graphics.TranslateTransform((float) bitmap1.Width / -2f, (float) bitmap1.Height / -2f);
        graphics.RotateTransform((float) rotate, MatrixOrder.Append);
        graphics.TranslateTransform((float) bitmap1.Width / 2f, (float) bitmap1.Height / 2f, MatrixOrder.Append);
        graphics.TranslateTransform((float) (bitmap2.Width - bitmap1.Width) / 2f, (float) (bitmap2.Height - bitmap1.Height) / 2f, MatrixOrder.Append);
        graphics.DrawImage((Image) bitmap1, new Rectangle(0, 0, bitmap1.Width, bitmap1.Height));
      }
      else
        graphics.DrawImage((Image) bitmap1, new Rectangle(0, 0, bitmap1.Width, bitmap1.Height));
      graphics.Dispose();
      bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      fileStream.Close();
      fileStream.Dispose();
      bitmap1.Dispose();
      this.bmp[slot] = bitmap2;
    }
  }
}
