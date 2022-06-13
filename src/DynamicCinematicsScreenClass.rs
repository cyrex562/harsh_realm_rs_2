// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DynamicCinematicsScreenClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class DynamicCinematicsScreenClass : ScreenClass
  {
     int pagenr;
     int lastpagenr;
     Bitmap fullBmp;
     bool fullBmpCenterScale;
     Bitmap[] bmp;
     int[] bmpLink;
     DateTime lastTime;
     int textRotateNumber;
     int textSize;
     bool timerActive;
     int timerMs;
     DateTime timerStart;
     bool udsActive;
     bool firstRenderDone;
     int UdsId;
     WindowClass UdsWindow;
     int udsX;
     int udsY;
     int udsW;
     int udsH;
     int udsNewEvent;
     bool udsContainsButton;
     int udsTv0;
     Cursor tempCursor;
     string fullBmpName;
     SimpleStringList TabList;

    pub DynamicCinematicsScreenClass(ref GameClass tGame, Form1 tformref)
      : base(ref tGame, tFormRef: tformref)
    {
      this.fullBmpCenterScale = false;
      this.bmp = new Bitmap[20];
      this.textRotateNumber = 1;
      this.textSize = 0;
      this.fullBmpName = "";
      this.Game.EditObj.RealTurn = this.Game.Data.Turn;
      this.Game.EditObj.RealRound = this.Game.Data.Round;
      this.TabList = SimpleStringList::new();
      this.pagenr = 9999999;
      this.lastpagenr = 0;
      this.lastTime = DateAndTime.Now;
      this.tempCursor = this.Game.FormRef.Cursor;
      this.Game.FormRef.Cursor = Cursors.Default;
      int stringListById = this.Game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.Game.Data.RuleVar[971]));
      this.bmpLink = new int[this.Game.Data.StringListObj[stringListById].Length + 1];
      int length = this.Game.Data.StringListObj[stringListById].Length;
      for (int index = 0; index <= length; index += 1)
      {
        if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) > (double) this.lastpagenr)
          this.lastpagenr = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById].Data[index, 0]);
        if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) > 0.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) < (double) this.pagenr)
          this.pagenr = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById].Data[index, 0]);
      }
      this.timerActive = false;
      this.udsActive = false;
      this.loadPageStuff(this.pagenr);
    }

    pub Bitmap Paint(bool onlyToolTip = false)
    {
      this.textSize = 0;
      Graphics graphics = Graphics.FromImage((Image) this.OwnBackground);
      float num1;
      int num2;
      int num3;
      int num4;
      int num5;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!Information.IsNothing((object) this.fullBmp))
      {
        this.Game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.Game.Data.RuleVar[971]));
        bool flag = false;
        if (Strings.InStr(this.fullBmpName, "104.jpg") > 0)
          flag = true;
        if (Strings.InStr(this.fullBmpName, "106.jpg") > 0)
          flag = true;
        if (Strings.InStr(this.fullBmpName, "107.jpg") > 0)
          flag = true;
        if (Strings.InStr(this.fullBmpName, "108.jpg") > 0)
          flag = true;
        num1 = Math.Max((float) this.Game.ScreenWidth / 1920f, (float) this.Game.ScreenHeight / 1080f);
        float num6 = 1f;
        float num7 = 1f;
        int num8 = 1920;
        int num9 = 1080;
        int num10 =  Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
        int num11 =  Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
        num2 = num10;
        num3 = num11;
        if ((double) num1 != 1.0)
        {
          num8 =  Math.Round((double) (1920f * num1));
          num9 =  Math.Round((double) (1080f * num1));
          int num12 = num10 +  Math.Round((double) (num8 - this.Game.ScreenWidth) / 2.0);
          int num13 = num11 +  Math.Round((double) (num9 - this.Game.ScreenHeight) / 2.0);
        }
        int x1 =  Math.Round((double) (this.Game.ScreenWidth - num8) / 2.0);
        int y1 =  Math.Round((double) (this.Game.ScreenHeight - num9) / 2.0);
        int width1 = num8;
        int height1 = num9;
        int x2;
        int y2;
        int width2;
        int height2;
        if ((double) num1 >= 1.0)
        {
          x2 = 0;
          y2 = 0;
          width2 = 1920;
          height2 = 1080;
        }
        else
        {
          x2 =  Math.Round((double) (1920 - num8) / 2.0);
          y2 =  Math.Round((double) (1080 - num9) / 2.0);
          width2 = num8;
          height2 = num9;
          if (!flag)
          {
            x2 = 0;
            y2 = 0;
            width2 = 1920;
            height2 = 1080;
          }
        }
        num4 = x1;
        num5 = y1;
        num6 = (float) width1 / (float) this.Game.ScreenWidth;
        num7 = (float) height1 / (float) this.Game.ScreenHeight;
        ref Graphics local1 = ref graphics;
        ref Bitmap local2 = ref this.fullBmp;
        rectangle1 = new Rectangle(x2, y2, width2, height2);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(x1, y1, width1, height1);
        Rectangle destrect = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
      }
      else
        graphics.Clear(Color.Black);
      int num14 = 1;
      do
      {
        int stringListById1 = this.Game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.Game.Data.RuleVar[971]));
        int length = this.Game.Data.StringListObj[stringListById1].Length;
        int num15;
        for (int index1 = 0; index1 <= length; index1 += 1)
        {
          if ( Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 0])) == this.pagenr)
          {
            int num16 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 1]));
            Bitmap bitmap;
            if (num16 != 2 & num14 == 1 | num16 == 2 & num14 == 2)
            {
              if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 2.0)
              {
                int index2 = this.bmpLink[index1];
                if (index2 > -1)
                {
                  int x;
                  int y;
                  int width;
                  int height;
                  if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 1]) == 3.0 | Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 1]) == 1.0)
                  {
                    int integer1 = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]);
                    int integer2 = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]);
                    int num17 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]));
                    int num18 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]));
                    x = num4 +  Math.Round((double) num1 * ((double) integer1 + 448.0));
                    y = num5 +  Math.Round((double) num1 * ((double) integer2 + 156.0));
                    width =  Math.Round((double) ((float) num17 * num1));
                    height =  Math.Round((double) ((float) num18 * num1));
                  }
                  else
                  {
                    x =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                    y =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                    if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 100000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 199999.0)
                      x = 0 +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 100000.0);
                    if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 200000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 299999.0)
                      x = this.Game.ScreenWidth -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 200000.0);
                    if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 300000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 399999.0)
                      x =  Math.Round((double) this.Game.ScreenWidth / 2.0) +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 300000.0);
                    if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 400000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 499999.0)
                      x =  Math.Round((double) this.Game.ScreenWidth / 2.0) -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 400000.0);
                    if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) >= 99000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) <= 199999.0)
                      y = 0 +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) - 100000.0);
                    if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) >= 200000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) <= 299999.0)
                      y = this.Game.ScreenHeight -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) - 200000.0);
                    width =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]));
                    height =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]));
                  }
                  if (width < 1 & height < 1)
                  {
                    width = this.bmp[index2].Width;
                    height = this.bmp[index2].Height;
                  }
                  else if (width < 1)
                    width =  Math.Round((double) this.bmp[index2].Width * ((double) height / (double) this.bmp[index2].Height));
                  else if (height < 1)
                    height =  Math.Round((double) this.bmp[index2].Height * ((double) width / (double) this.bmp[index2].Width));
                  if (!Information.IsNothing((object) this.bmp[index2]) && x + width >= 0 & x < this.Game.ScreenWidth && y + height >= 0 & y < this.Game.ScreenHeight)
                  {
                    ref Graphics local3 = ref graphics;
                    ref Bitmap local4 = ref this.bmp[index2];
                    rectangle2 = new Rectangle(0, 0, this.bmp[index2].Width, this.bmp[index2].Height);
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(x, y, width, height);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
                  }
                }
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 100001.0)
              {
                int num19 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                int num20 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 100000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 199999.0)
                  num19 = 0 +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 100000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 200000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 299999.0)
                  num19 = this.Game.ScreenWidth -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 200000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 300000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 399999.0)
                  num19 =  Math.Round((double) this.Game.ScreenWidth / 2.0) +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 300000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 400000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 499999.0)
                  num19 =  Math.Round((double) this.Game.ScreenWidth / 2.0) -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 400000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) >= 99000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) <= 199999.0)
                  num20 = 0 +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) - 100000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) >= 200000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) <= 299999.0)
                  num20 = this.Game.ScreenHeight -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) - 200000.0);
                int num21 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]));
                int num22 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]));
                if (num21 < 1 | num22 < 1)
                {
                  num21 = 100;
                  num22 = 140;
                }
                DrawMod.DrawBlock(ref graphics, num19, num20, num21, num22, 0, 0, 0, 128);
                ref Graphics local5 = ref graphics;
                bitmap = this.Game.CustomBitmapObj.DrawLeaderPortrait( Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 2])), num21, num22);
                ref Bitmap local6 = ref bitmap;
                rectangle2 = new Rectangle(0, 0, num21, num22);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(num19, num20, num21, num22);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 1000001.0)
              {
                int x =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                int y =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                int w =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]));
                int h =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]));
                if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 1]) == 3.0)
                {
                  w =  Math.Round((double) ((float) w * num1));
                  h =  Math.Round((double) ((float) h * num1));
                }
                int sfTypeById = this.Game.HandyFunctionsObj.GetSFTypeByID( Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 2])));
                if (sfTypeById > -1)
                {
                  int stringListById2 = this.Game.HandyFunctionsObj.GetStringListByID(this.Game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
                  int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
                  int id = this.Game.Data.RegimeObj[this.Game.Data.Turn].id;
                  int idValue =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById2].GetData(0, id, 2)));
                  int cultureGroupId =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById3].GetData(0, idValue, 1)));
                  Bitmap objBitmap = this.Game.CustomBitmapObj.DrawSFTypeGraphic(sfTypeById, false, cultureGroupId, this.Game.Data.Turn, -1);
                  DrawMod.DrawScaled(ref graphics, ref objBitmap, x, y, w, h, true);
                  objBitmap.Dispose();
                }
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 4.0)
              {
                if (!this.timerActive)
                {
                  int num23 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 8]));
                  if (num23 > 0)
                  {
                    this.timerActive = true;
                    this.timerMs = num23;
                    this.timerStart = DateAndTime.Now;
                  }
                }
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 7.0)
              {
                if (this.UdsId == 0 & !this.udsActive)
                {
                  this.udsActive = true;
                  this.udsContainsButton = false;
                  int sx =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                  int sy =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                  this.udsX = sx;
                  this.udsY = sy;
                  int num24 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]));
                  int num25 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]));
                  this.udsW = num24;
                  this.udsH = num25;
                  this.Game.EditObj.UdsInsideTabOpenMode = false;
                  string udSpopupText;
                  if (this.udsNewEvent > 0)
                  {
                    this.Game.EventRelatedObj.DoCheckSpecificEvent(this.udsNewEvent,  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 9])));
                    udSpopupText = this.Game.EditObj.UDSpopupText;
                    this.Game.EditObj.UDSpopupText = "";
                    this.udsNewEvent = 0;
                  }
                  else
                  {
                    int id =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 8]));
                    if (id > 0 & Operators.CompareString(id.ToString(), this.Game.Data.StringListObj[stringListById1].Data[index1, 8], false) == 0)
                    {
                      int eventById = this.Game.HandyFunctionsObj.GetEventByID(id);
                      int tv0 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 9]));
                      this.udsTv0 = tv0;
                      this.Game.EventRelatedObj.DoCheckSpecificEvent(eventById, tv0);
                      udSpopupText = this.Game.EditObj.UDSpopupText;
                      this.Game.EditObj.UDSpopupText = "";
                    }
                    else
                      udSpopupText = this.Game.Data.StringListObj[stringListById1].Data[index1, 8];
                  }
                  if (Information.IsNothing((object) this.UdsWindow))
                    this.UdsWindow = new WindowClass(ref this.Game, num24, num25, 99, screenbitmap: this.OwnBackground, sx: sx, sy: sy);
                  if (!Information.IsNothing((object) this.UdsWindow.SubPartList) && this.UdsWindow.SubPartList.Length > -1)
                    this.UdsWindow.RemoveSubPart(0);
                  this.udsContainsButton = false;
                  if (Strings.InStr(udSpopupText, "[type]button[/type]") > 0)
                    this.udsContainsButton = true;
                  WindowClass udsWindow = this.UdsWindow;
                  let mut subPartClass: SubPartClass =  new UDSPartClass(this.Game, num24, num25, udSpopupText, ref this.UdsWindow.BackBitmap, 0, 0, true, tAlwaysShowBackground: true);
                  ref let mut local7: SubPartClass = ref subPartClass;
                  int w = num24;
                  int h = num25;
                  this.UdsId = udsWindow.AddSubPart(ref local7, 0, 0, w, h, 0);
                  this.UdsWindow.FlagAll();
                  ref Graphics local8 = ref graphics;
                  bitmap = this.UdsWindow.Paint();
                  ref Bitmap local9 = ref bitmap;
                  int x = sx;
                  int y = sy;
                  DrawMod.DrawSimple(ref local8, ref local9, x, y);
                }
                else
                {
                  int num26 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                  int num27 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                  num15 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]));
                  int num28 =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]));
                  this.UdsWindow.FlagAll();
                  ref Graphics local10 = ref graphics;
                  bitmap = this.UdsWindow.Paint();
                  ref Bitmap local11 = ref bitmap;
                  int x = num26;
                  int y = num27;
                  DrawMod.DrawSimple(ref local10, ref local11, x, y);
                }
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 5.0 & !this.firstRenderDone)
              {
                str: String = this.Game.Data.StringListObj[stringListById1].Data[index1, 2];
                if (str.Length > 0)
                  SoundMod.PlayAWave(this.Game.AppPath + str, ref this.Game.EditObj);
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 6.0)
              {
                int x1 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                int y1 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                int nr =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 2]));
                if (nr > -1)
                {
                  try
                  {
                    ref Graphics local12 = ref graphics;
                    bitmap = this.Game.CustomBitmapObj.DrawActionCardSe1(this.Game.Data.Turn, nr);
                    ref Bitmap local13 = ref bitmap;
                    int x = x1;
                    int y = y1;
                    DrawMod.DrawSimple(ref local12, ref local13, x, y);
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    DrawMod.DrawBlock(ref graphics, x1, y1, 190, 266, 100, 100, 100, 128);
                    DrawMod.DrawTextColouredMarcCenter(ref graphics, "Scrapped", this.Game.MarcFont2, x1 + 95, y1 + 110, Color.LightGray);
                    ProjectData.ClearProjectError();
                  }
                }
              }
              else if (Conversion.Val(this.Game.Data.StringListObj[stringListById1].Data[index1, 3]) == 3.0)
              {
                int num29 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) + (double) num2);
                int num30 =  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) + (double) num3);
                int num31 = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]);
                int integer = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById1].Data[index1, 7]);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 100000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 199999.0)
                  num29 = 0 +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 100000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 200000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 299999.0)
                  num29 = this.Game.ScreenWidth -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 200000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) >= 99000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) <= 199999.0)
                  num30 = 0 +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) - 100000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) >= 200000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) <= 299999.0)
                  num30 = this.Game.ScreenHeight -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 5]) - 200000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]) >= 100000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]) <= 199999.0)
                  num31 = this.Game.ScreenWidth -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 6]) - 100000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 300000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 399999.0)
                  num29 =  Math.Round((double) this.Game.ScreenWidth / 2.0) +  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 300000.0);
                if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) >= 400000.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) <= 499999.0)
                  num29 =  Math.Round((double) this.Game.ScreenWidth / 2.0) -  Math.Round(Conversions.ToDouble(this.Game.Data.StringListObj[stringListById1].Data[index1, 4]) - 400000.0);
                str1: String = this.Game.Data.StringListObj[stringListById1].Data[index1, 8];
                string str2;
                if (this.Game.Data.Product >= 7)
                {
                  try
                  {
                    int num32 = str1.IndexOf("[text]");
                    int num33 = str1.IndexOf("[/text]");
                    if (num32 > -1)
                    {
                      String1_1: String = Strings.Mid(str1, num32 + 7, num33 - (num32 + 6));
                      string[] strArray;
                      if (Strings.InStr(String1_1, "#") > 0)
                        strArray = String1_1.Split(new char[1]
                        {
                          '#'
                        }, StringSplitOptions.RemoveEmptyEntries);
                      else
                        strArray = new string[1]
                        {
                          String1_1
                        };
                      int upperBound = strArray.GetUpperBound(0);
                      int index3 = upperBound <= 0 ? 0 : (upperBound + this.textRotateNumber) % (upperBound + 1);
                      str3: String = strArray[index3];
                      str4: String = this.Game.Data.StringListObj[stringListById1].Data[index1, 8];
                      if (strArray.GetUpperBound(0) > 0)
                      {
                        int Length = str4.IndexOf("[text]");
                        int num34 = str4.IndexOf("[/text]");
                        if (str3.Length > this.textSize)
                          this.textSize = str3.Length;
                        String1_2: String = Strings.Left(str4, Length) + "[text]" + str3 + Strings.Mid(str4, num34 + 1);
                        if (Strings.InStr(String1_2, "[center]0[/center]") > 0)
                          String1_2 = String1_2.Replace("[center]0[/center]", "[center]1[/center]");
                        str2 = String1_2;
                      }
                      else
                        str2 = str4;
                    }
                    else
                      str2 = str1;
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    str2 = "Error ";
                    ProjectData.ClearProjectError();
                  }
                }
                else
                  str2 = str1;
                let mut game: GameClass = this.Game;
                int twidth = num31 + 40;
                int theight = integer;
                tTexty: String = str2;
                bitmap = (Bitmap) null;
                ref Bitmap local14 = ref bitmap;
                int bbx = num29;
                int bby = num30;
                UDSPartClass udsPartClass = new UDSPartClass(game, twidth, theight, tTexty, ref local14, bbx, bby, true);
                ref Graphics local15 = ref graphics;
                bitmap = udsPartClass.Paint();
                ref Bitmap local16 = ref bitmap;
                int x = num29 - 20;
                int y = num30 + 30;
                DrawMod.DrawSimple(ref local15, ref local16, x, y);
              }
            }
          }
        }
        if (num14 == 2 && this.Game.Data.Product >= 7)
        {
          if (Information.IsNothing((object) this.Game.EditObj.TipText))
            this.Game.EditObj.TipText = "";
          if (this.Game.EditObj.TipText.Length > 0 & this.Game.ModIntroType >= 1)
          {
            SizeF sizeF1 = SizeF::new();
            SizeF sizeF2 = SizeF::new();
            str5: String = this.Game.EditObj.TipTitle;
            bool flag1;
            if (Strings.InStr(str5, "<FIXEDSYS>") > 0)
            {
              flag1 = true;
              str5 = str5.Replace("<FIXEDSYS>", "");
            }
            int num35 = 100;
            int num36 = 20;
            str6: String = this.Game.EditObj.TipText;
            str7: String = "";
            int num37 = 0;
            while (str6.Length > 0)
            {
              Left: String = Strings.Mid(str6, 1, 1);
              if (Operators.CompareString(Left, "\r\n", false) == 0 | Operators.CompareString(Left, "\r", false) == 0 | Operators.CompareString(Left, "\n", false) == 0)
              {
                num37 = 0;
                str7 += Left;
                str6 = Strings.Mid(str6, 2);
              }
              else
              {
                num37 += 1;
                bool flag2 = false;
                if (Strings.InStr(str6, "\r\n") > 0 & Strings.InStr(str6, "\r\n") <= num36)
                  flag2 = true;
                if (Strings.InStr(str6, "\n") > 0 & Strings.InStr(str6, "\n") <= num36)
                  flag2 = true;
                if (!flag2 & num37 > num35 && Operators.CompareString(Left, " ", false) == 0)
                {
                  Left = "\r\n";
                  num37 = 0;
                }
                str7 += Left;
                str6 = Strings.Mid(str6, 2);
              }
            }
            SizeF sizeF3 = !flag1 ? graphics.MeasureString(str7, this.Game.MarcFont4) : graphics.MeasureString(str7, this.Game.MarcFont4b);
            int x1 = this.FormRef.LastTipX + 20;
            int num38 = this.FormRef.LastTipY + 20;
            num15 =  Math.Round((double) (sizeF3.Width + 4f));
            int h =  Math.Round((double) (sizeF3.Height + 4f));
            if (str5.Length > 0)
            {
              sizeF2 = !flag1 ? graphics.MeasureString(str5, this.Game.MarcFont4) : graphics.MeasureString(str5, this.Game.MarcFont4b);
              h =  Math.Round((double) ((float) (h + 4) + sizeF2.Height));
            }
            float width = sizeF3.Width;
            if ((double) sizeF2.Width > (double) width)
              width = sizeF2.Width;
            int num39 =  Math.Round((double) (width + 4f));
            if (x1 + num39 > this.Game.ScreenWidth - 64)
              x1 -= x1 + num39 - (this.Game.ScreenWidth - 64);
            if (num38 + h > this.Game.ScreenHeight - 32)
              num38 -= num38 + h - (this.Game.ScreenHeight - 32);
            if (str5.Length > 0)
              this.LastToolTipRect = new Rectangle(x1 - 16, num38, num39 + 1 + 32, h + 1 + 16);
            else
              this.LastToolTipRect = new Rectangle(x1 - 16, num38, num39 + 1 + 32, h + 1);
            int r1 = 240;
            int g1 = 240;
            int b1 = 160;
            int num40 = 40;
            int num41 = 40;
            int num42 = 20;
            if (this.Game.EditObj.TipColor >= 1)
            {
              r1 =  byte.MaxValue;
              g1 = 180;
              b1 = 0;
              num40 = 40;
              num41 = 40;
              num42 = 20;
              this.Game.EditObj.TipColor = 0;
            }
            int r2 = num40;
            int g2 = num41;
            int b2 = num42;
            if (flag1)
            {
              r1 = 240;
              g1 = 240;
              b1 = 160;
              num40 = 0;
              num41 = 0;
              num42 = 0;
              r2 = 200;
              g2 = 200;
              b2 = 100;
            }
            if (str5.Length > 0)
            {
              DrawMod.DrawBlock(ref graphics, x1 - 16, num38, num39 + 32,  Math.Round((double) (sizeF2.Height + 4f)), r1, g1, b1,  byte.MaxValue);
              DrawMod.DrawBlock(ref graphics, x1 - 16,  Math.Round((double) num38 + (double) sizeF2.Height + 4.0), num39 + 32,  Math.Round((double) h - ((double) sizeF2.Height + 4.0) + 16.0), r2, g2, b2,  byte.MaxValue);
              if (flag1)
              {
                DrawMod.DrawTextColouredNicely(ref graphics, str5, this.Game.MarcFont16, x1 + 2, num38 + 2, Color.FromArgb( byte.MaxValue, num40, num41, num42));
                DrawMod.DrawTextColouredNicely(ref graphics, str7, this.Game.MarcFont4b, x1 + 3,  Math.Round((double) ((float) (num38 + 6 + 8) + sizeF2.Height)), Color.FromArgb(178, 0, 0, 0));
                DrawMod.DrawTextColouredNicely(ref graphics, str7, this.Game.MarcFont4b, x1 + 2,  Math.Round((double) ((float) (num38 + 6 + 8) + sizeF2.Height)), Color.Black);
              }
              else
              {
                DrawMod.DrawTextColouredNicely(ref graphics, str5, this.Game.MarcFont16, x1 + 2, num38 + 2, Color.FromArgb( byte.MaxValue, num40, num41, num42), 12);
                DrawMod.DrawTextColouredNicely(ref graphics, str7, this.Game.MarcFont4, x1 + 2,  Math.Round((double) ((float) (num38 + 8 + 6) + sizeF2.Height)), Color.White);
              }
              DrawMod.DrawRectangle(ref graphics, x1 - 16, num38, num39 + 32, h + 16, r1, g1, b1,  byte.MaxValue);
            }
            else if (Operators.CompareString(str7, ".", false) == 0)
            {
              DrawMod.DrawBlock(ref graphics, x1, num38, 8, 4, num40, num41, num42,  byte.MaxValue);
              DrawMod.DrawRectangle(ref graphics, x1 + 2, num38 + 2, 1, 1, r1, g1, b1,  byte.MaxValue);
              DrawMod.DrawRectangle(ref graphics, x1, num38, 8, 4, r1, g1, b1,  byte.MaxValue);
            }
            else
            {
              DrawMod.DrawBlock(ref graphics, x1 - 16, num38, num39 + 32, h, num40, num41, num42,  byte.MaxValue);
              if (flag1)
                DrawMod.DrawTextColouredNicely(ref graphics, str7, this.Game.MarcFont4b, x1 + 2, num38 + 2, Color.White);
              else
                DrawMod.DrawTextColouredNicely(ref graphics, str7, this.Game.MarcFont4, x1 + 2, num38 + 2, Color.White);
              DrawMod.DrawRectangle(ref graphics, x1 - 16, num38, num39 + 32, h, r1, g1, b1,  byte.MaxValue);
            }
          }
        }
        if (num14 == 1)
          this.TabList = this.Game.CustomBitmapObj.DrawStandardShadowEmpireFrame(graphics, 0, 0, false, true);
        num14 += 1;
      }
      while (num14 <= 2);
      this.firstRenderDone = true;
      if (!Information.IsNothing((object) graphics))
      {
        graphics.Dispose();
        graphics = (Graphics) null;
      }
      return this.OwnBackground;
    }

    pub ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      int num = 9999999;
      int stringListById = this.Game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.Game.Data.RuleVar[971]));
      if (b == 2)
        return screenReturnClass;
      if (!Information.IsNothing((object) this.TabList))
      {
        int counter = this.TabList.Counter;
        for (int index = 0; index <= counter; index += 1)
        {
          if (x > this.TabList.Data1[index] & y > this.TabList.Data2[index] && x < this.TabList.Data1[index] + this.TabList.Data3[index] & y < this.TabList.Data2[index] + this.TabList.Data4[index])
          {
            if (this.TabList.Data5[index] < 1)
              return screenReturnClass;
            if (this.TabList.Data5[index] == 101)
            {
              screenReturnClass.NewScreen = 11;
              screenReturnClass.flag = true;
              this.unloadAnyStuff();
              return screenReturnClass;
            }
            if (this.TabList.Data5[index] == 102)
            {
              screenReturnClass.NewScreen = 16;
              screenReturnClass.flag = true;
              this.unloadAnyStuff();
              return screenReturnClass;
            }
            if (this.TabList.Data5[index] == 104)
            {
              this.Game.EditObj.se1_ManagementMode = true;
              screenReturnClass.NewScreen = 24;
              screenReturnClass.flag = true;
              this.unloadAnyStuff();
              return screenReturnClass;
            }
          }
        }
      }
      if (this.Game.Data.Product >= 7 && this.udsActive & b == 1)
      {
        if (this.udsContainsButton)
        {
          if (!Information.IsNothing((object) this.UdsWindow))
          {
            int enr = 0;
            if (x >= this.udsX & y >= this.udsY & x < this.udsX + this.udsW & y < this.udsY + this.udsH)
            {
              enr = this.UdsWindow.SubPartList[0].Click(x - this.udsX, y - this.udsY, b);
              switch (enr)
              {
              }
            }
            if (enr > 0)
            {
              if (!Information.IsNothing((object) this.UdsWindow))
              {
                this.UdsWindow.Dispose();
                this.UdsWindow = (WindowClass) null;
                this.UdsId = 0;
                this.udsActive = false;
                this.udsNewEvent = 0;
              }
              this.Game.EventRelatedObj.DoCheckSpecificEvent(enr, this.udsTv0);
              udSpopupText: String = this.Game.EditObj.UDSpopupText;
              this.Game.EditObj.UDSpopupText = "";
              if (udSpopupText.Length > 0)
              {
                this.udsNewEvent = enr;
                screenReturnClass.flag = true;
                return screenReturnClass;
              }
              enr = -999;
            }
            if (enr != -999)
              return screenReturnClass;
            if (!Information.IsNothing((object) this.UdsWindow))
            {
              this.UdsWindow.Dispose();
              this.UdsWindow = (WindowClass) null;
              this.UdsId = 0;
              this.udsActive = false;
              this.udsNewEvent = 0;
            }
          }
        }
        else if (!Information.IsNothing((object) this.UdsWindow))
        {
          this.UdsWindow.Dispose();
          this.UdsWindow = (WindowClass) null;
          this.UdsId = 0;
          this.udsActive = false;
          this.udsNewEvent = 0;
        }
      }
      int length = this.Game.Data.StringListObj[stringListById].Length;
      for (int index = 0; index <= length; index += 1)
      {
        if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) < (double) num && Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) > (double) this.pagenr)
          num = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById].Data[index, 0]);
      }
      this.pagenr = num;
      if (this.pagenr >= 9999999)
      {
        this.Game.FormRef.Cursor = this.tempCursor;
        screenReturnClass.NewScreen = this.Game.EditObj.TestEarlyCinematics != 1 ? 11 : 13;
        screenReturnClass.flag = true;
        this.unloadAnyStuff();
        return screenReturnClass;
      }
      this.firstRenderDone = false;
      this.loadPageStuff(this.pagenr);
      screenReturnClass.flag = true;
      return screenReturnClass;
    }

    pub ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (this.Game.Data.Product < 7)
        return screenReturnClass;
      int num = 1000 + this.textSize * 30;
      this.Game.FormRef.Timer1.Interval = 1;
      DateTime now = DateAndTime.Now;
      TimeSpan timeSpan1 = now.Subtract(this.lastTime);
      if (this.timerActive)
      {
        TimeSpan timeSpan2 = now.Subtract(this.timerStart);
        if (timeSpan2.Milliseconds + timeSpan2.Seconds * 1000 > this.timerMs)
        {
          this.timerActive = false;
          if (!Information.IsNothing((object) this.UdsWindow))
          {
            this.UdsWindow.Dispose();
            this.UdsWindow = (WindowClass) null;
            this.UdsId = 0;
            this.udsActive = false;
            this.udsNewEvent = 0;
          }
          this.udsActive = false;
          return this.HandleMouseClick(0, 0, 1);
        }
      }
      if (timeSpan1.Milliseconds + timeSpan1.Seconds * 1000 <= num)
        return screenReturnClass;
      this.lastTime = DateAndTime.Now;
      this += 1.textRotateNumber;
      screenReturnClass.flag = true;
      return screenReturnClass;
    }

    pub ScreenReturnClass HandleKeyPress(int nr)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      ScreenReturnClass screenReturnClass = ScreenReturnClass::new();
      if (this.udsActive)
        return screenReturnClass;
      try
      {
        if (nr == 27)
        {
          this.Game.FormRef.Cursor = this.tempCursor;
          screenReturnClass.NewScreen = this.Game.EditObj.TestEarlyCinematics != 1 ? 11 : 13;
          screenReturnClass.flag = true;
          this.unloadAnyStuff();
          return screenReturnClass;
        }
        if (!Information.IsNothing((object) this.TabList))
        {
          int counter = this.TabList.Counter;
          for (int index = 0; index <= counter; index += 1)
          {
            if (this.TabList.Data5[index] == 102 & nr == 72)
            {
              screenReturnClass.NewScreen = 16;
              screenReturnClass.flag = true;
              this.unloadAnyStuff();
              return screenReturnClass;
            }
            if (this.TabList.Data5[index] == 104 & nr == 78)
            {
              this.Game.EditObj.se1_ManagementMode = true;
              screenReturnClass.NewScreen = 24;
              screenReturnClass.flag = true;
              this.unloadAnyStuff();
              return screenReturnClass;
            }
          }
        }
        if (nr == 32)
        {
          int num = 9999999;
          int stringListById = this.Game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.Game.Data.RuleVar[971]));
          int length = this.Game.Data.StringListObj[stringListById].Length;
          for (int index = 0; index <= length; index += 1)
          {
            if (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) > 0.0 & Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) < (double) num && Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 0]) > (double) this.pagenr)
              num = Conversions.ToInteger(this.Game.Data.StringListObj[stringListById].Data[index, 0]);
          }
          this.pagenr = num;
          if (this.pagenr >= 9999999)
          {
            this.Game.FormRef.Cursor = this.tempCursor;
            screenReturnClass.NewScreen = this.Game.EditObj.TestEarlyCinematics != 1 ? 11 : 13;
            screenReturnClass.flag = true;
            this.unloadAnyStuff();
            return screenReturnClass;
          }
          this.firstRenderDone = false;
          if (!Information.IsNothing((object) this.UdsWindow))
          {
            this.UdsWindow.Dispose();
            this.UdsWindow = (WindowClass) null;
          }
          this.udsActive = false;
          this.udsNewEvent = 0;
          this.loadPageStuff(this.pagenr);
          screenReturnClass.flag = true;
          return screenReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return screenReturnClass;
    }

    pub void unloadAnyStuff()
    {
      this.fullBmpCenterScale = false;
      if (!Information.IsNothing((object) this.fullBmp))
      {
        this.fullBmp.Dispose();
        this.fullBmp = (Bitmap) null;
      }
      int index = 0;
      do
      {
        if (!Information.IsNothing((object) this.bmp[index]))
        {
          this.bmp[index].Dispose();
          this.bmp[index] = (Bitmap) null;
        }
        index += 1;
      }
      while (index <= 19);
      this.fullBmpName = "";
    }

    pub void loadPageStuff(int nr)
    {
      str: String = this.Game.AppPath + "graphics/";
      this.fullBmpName = "";
      this.unloadAnyStuff();
      int slot = 0;
      int stringListById = this.Game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.Game.Data.RuleVar[971]));
      this.bmpLink = new int[this.Game.Data.StringListObj[stringListById].Length + 1];
      int length1 = this.Game.Data.StringListObj[stringListById].Length;
      for (int index = 0; index <= length1; index += 1)
      {
        if (Conversion.Val(this.Game.Data.StringListObj[stringListById].Data[index, 3]) == 1.0 && Conversion.Val(this.Game.Data.StringListObj[stringListById].Data[index, 0]) == (double) this.pagenr)
        {
          s: String = str + this.Game.Data.StringListObj[stringListById].Data[index, 2];
          this.fullBmpCenterScale = false;
          if (Conversion.Val(this.Game.Data.StringListObj[stringListById].Data[index, 1]) == 3.0)
            this.fullBmpCenterScale = true;
          this.loadSpecificFullBmp(s);
        }
      }
      int length2 = this.Game.Data.StringListObj[stringListById].Length;
      for (int index = 0; index <= length2; index += 1)
      {
        this.bmpLink[index] = -1;
        if (((ulong) (long) Math.Round(Conversion.Val((object) (Conversions.ToDouble(this.Game.Data.StringListObj[stringListById].Data[index, 3]) == 2.0))) & (ulong) -(slot < 19 ? 1 : 0)) > 0UL && Conversion.Val(this.Game.Data.StringListObj[stringListById].Data[index, 0]) == (double) this.pagenr)
        {
          int specialRenderMode =  Math.Round(Conversion.Val(this.Game.Data.StringListObj[stringListById].Data[index, 1]));
          this.loadSpecificBmp(str + this.Game.Data.StringListObj[stringListById].Data[index, 2], slot, specialRenderMode);
          this.bmpLink[index] = slot;
          slot += 1;
        }
      }
    }

    pub void loadSpecificBmp(string s, int slot, int specialRenderMode = -1)
    {
      if (!Information.IsNothing((object) this.bmp[slot]))
      {
        this.bmp[slot].Dispose();
        this.bmp[slot] = (Bitmap) null;
      }
      s = BitmapStore.FileNameOverride(s);
      FileStream fileStream = new FileStream(s, FileMode.Open, FileAccess.Read);
      Bitmap bitmap = (Bitmap) Image.FromStream((Stream) fileStream);
      Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) bmp);
      graphics.DrawImage((Image) bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
      if (specialRenderMode == 1)
        DrawMod.ModifyColorOfBitmapToGrayHighSpeed(ref bmp,  byte.MaxValue);
      graphics.Dispose();
      bmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      fileStream.Close();
      fileStream.Dispose();
      bitmap.Dispose();
      this.bmp[slot] = bmp;
    }

    pub void SpecialRenderMode1(ref Graphics g, ref Bitmap b)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = b.Width - 1;
      int num4 = b.Height - 1;
      int num5 = num2;
      int num6 = num4;
      for (int y = num5; y <= num6; y += 1)
      {
        int num7 = num1;
        int num8 = num3;
        for (int x = num7; x <= num8; x += 1)
        {
          Color pixel = b.GetPixel(x, y);
          int green =  Math.Max(pixel.B, Math.Max(pixel.R, pixel.G));
          int a =  pixel.A;
          b.SetPixel(x, y, Color.FromArgb(a, 0, green, 0));
        }
      }
    }

    pub void SpecialRenderMode2(ref Graphics g, ref Bitmap b)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = b.Width - 1;
      int num4 = b.Height - 1;
      int num5 = num2;
      int num6 = num4;
      for (int y = num5; y <= num6; y += 1)
      {
        int num7 = num1;
        int num8 = num3;
        for (int x = num7; x <= num8; x += 1)
        {
          Color pixel = b.GetPixel(x, y);
          int green =  Math.Max(pixel.B, Math.Max(pixel.R, pixel.G));
          int a =  pixel.A;
          int alpha = !(x < 20 | x > num3 - 20 | y < 20 | y > num4 - 20) ? a : 0;
          b.SetPixel(x, y, Color.FromArgb(alpha, 0, green, 0));
        }
      }
    }

    pub void loadSpecificFullBmp(string s)
    {
      if (!Information.IsNothing((object) this.fullBmp))
      {
        this.fullBmp.Dispose();
        this.fullBmp = (Bitmap) null;
      }
      this.fullBmpName = s;
      s = BitmapStore.FileNameOverride(s);
      FileStream fileStream = new FileStream(s, FileMode.Open, FileAccess.Read);
      Bitmap bitmap1 = (Bitmap) Image.FromStream((Stream) fileStream);
      Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap2);
      graphics.DrawImage((Image) bitmap1, new Rectangle(0, 0, bitmap1.Width, bitmap1.Height));
      graphics.Dispose();
      bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      fileStream.Close();
      fileStream.Dispose();
      bitmap1.Dispose();
      this.fullBmp = bitmap2;
    }

    pub ScreenReturnClass HandleMouseMove(int x, int y)
    {
      ScreenReturnClass screenReturnClass1 = ScreenReturnClass::new();
      ScreenReturnClass screenReturnClass2 = base.HandleMouseMove(x, y);
      if (this.Game.Data.Product >= 7 && this.udsActive && !Information.IsNothing((object) this.UdsWindow) && x >= this.udsX & y >= this.udsY & x < this.udsX + this.udsW & y < this.udsY + this.udsH && this.UdsWindow.SubPartList[0].HandleMouseMove(x - this.udsX, y - this.udsY))
        screenReturnClass2.flag = true;
      return screenReturnClass2;
    }

    pub void HandleTooltip(int x, int y, bool skipReset = false)
    {
      if (!Information.IsNothing((object) this.TabList))
      {
        int counter = this.TabList.Counter;
        for (int index = 0; index <= counter; index += 1)
        {
          if (x > this.TabList.Data1[index] & y > this.TabList.Data2[index] && x < this.TabList.Data1[index] + this.TabList.Data3[index] & y < this.TabList.Data2[index] + this.TabList.Data4[index] && this.TabList.Id[index].Length > 0)
          {
            this.Game.EditObj.TipColor = 0;
            this.Game.EditObj.TipText = this.TabList.Id[index];
            this.Game.EditObj.TipTitle = "";
            this.Game.EditObj.TipButton = true;
            if (this.TabList.Data5[index] > -1)
            {
              if (this.FormRef.Cursor == Cursors.WaitCursor)
                return;
              this.FormRef.Cursor = Cursors.Hand;
              return;
            }
            if (this.FormRef.Cursor == Cursors.WaitCursor)
              return;
            this.FormRef.Cursor = Cursors.Help;
            return;
          }
        }
      }
      if (this.Game.Data.Product >= 7)
      {
        this.Game.EditObj.TipColor = 0;
        this.Game.EditObj.TipText = "";
        this.Game.EditObj.TipTitle = "";
        this.Game.EditObj.TipButton = false;
        if (this.udsActive && !Information.IsNothing((object) this.UdsWindow) && x >= this.udsX & y >= this.udsY & x < this.udsX + this.udsW & y < this.udsY + this.udsH)
          this.UdsWindow.SubPartList[0].HandleToolTip(x - this.udsX, y - this.udsY);
        base.HandleTooltip(x, y, true);
      }
      else
        base.HandleTooltip(x, y, skipReset);
    }
  }
}
