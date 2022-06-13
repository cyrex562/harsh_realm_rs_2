// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LeftSideBar
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WindowsApplication1
{
  pub class LeftSideBar : WindowClass
  {
     int hideId;
     int Info1Id;
     int info2id;
     int info3id;
     int info4id;
     int upId;
     int downId;
     int w;
     int h;
     int MouseOverWhichTab;
     string cacheList;
     int profId;
     int currentShqNr;
     int special1id;
     int special2id;
     int special3id;

    pub LeftSideBar(
       GameClass tGame,
      int theight,
       WindowClass tLowerWindow,
       Rectangle tLowerRect)
      : base( tGame, 185, theight, 8)
    {
      this.NewGfx = true;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.w = 185;
      this.h = theight;
      this.BlockBlit = true;
      this.dostuff();
    }

    pub HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = base.HandleMouseMove(x, y);
      int num = -1;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
          num = this.MouseData[mouseCounter];
      }
      if (num > 0)
      {
        if (this.MouseOverWhichTab != num)
        {
          if (this.game.EmpireStyle)
            SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav",  this.game.EditObj);
          this.MouseOverWhichTab = num;
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      else if (this.MouseOverWhichTab > 0)
      {
        this.MouseOverWhichTab = -1;
        this.dostuff();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      return windowReturnClass;
    }

    pub void DoRefresh() => this.dostuff();

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.MouseOverWhichTab <= 0 || this.MouseInThisWindow)
        return windowReturnClass;
      this.MouseOverWhichTab = 0;
      this.dostuff();
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    pub Rectangle DrawOneTab(
      Graphics g,
      int ty,
      bool active,
      bool openSideWindow,
      int iconSlot,
      bool mouseOverRightNow = false)
    {
      int x1 = 11;
      if (openSideWindow)
        x1 = 150;
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (mouseOverRightNow)
      {
        if (!active & openSideWindow)
        {
           Graphics local1 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABLEFT);
           Bitmap local2 =  bitmap;
          rectangle1 = new Rectangle(7, 0, 28, 70);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(x1, ty, 28, 70);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2ColouredNew( local1,  local2, srcrect, destrect, 1.1f, 1.1f, 1.1f, 1f);
        }
        if (active | !openSideWindow)
        {
           Graphics local3 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABLEFT);
           Bitmap local4 =  bitmap;
          int x2 = x1;
          int y = ty;
          DrawMod.Draw( local3,  local4, x2, y, 0.05f, 0.05f, 0.05f, 1f);
        }
      }
      else
      {
        if (!active & openSideWindow)
        {
           Graphics local5 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABLEFT);
           Bitmap local6 =  bitmap;
          rectangle2 = new Rectangle(7, 0, 28, 70);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x1, ty, 28, 70);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
        }
        if (active | !openSideWindow)
        {
           Graphics local7 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABLEFT);
           Bitmap local8 =  bitmap;
          int x3 = x1;
          int y = ty;
          DrawMod.DrawSimple( local7,  local8, x3, y);
        }
      }
      if (iconSlot > -1)
      {
        if (mouseOverRightNow)
        {
          if (!active & openSideWindow)
          {
             Graphics local9 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             Bitmap local10 =  bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1 - 7 - 3, ty + 17, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
          }
          if (!active & !openSideWindow)
          {
             Graphics local11 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             Bitmap local12 =  bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1 - 7, ty + 17, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
          }
        }
        else
        {
          if (!active & openSideWindow)
          {
             Graphics local13 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             Bitmap local14 =  bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 0, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1 - 7 - 3, ty + 17, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local13,  local14, srcrect, destrect);
          }
          if (!active & !openSideWindow)
          {
             Graphics local15 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             Bitmap local16 =  bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 0, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1 - 7, ty + 17, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local15,  local16, srcrect, destrect);
          }
        }
        if (active)
        {
           Graphics local17 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
           Bitmap local18 =  bitmap;
          rectangle2 = new Rectangle(iconSlot * 42, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x1 - 7, ty + 17, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
        }
      }
      return new Rectangle(x1, ty, 35, 65);
    }

    pub void dostuff()
    {
      if (this.hideId > 0)
      {
        this.RemoveSubPart(this.hideId);
        this.hideId = 0;
      }
      if (this.upId > 0)
      {
        this.RemoveSubPart(this.upId);
        this.upId = 0;
      }
      if (this.downId > 0)
      {
        this.RemoveSubPart(this.downId);
        this.downId = 0;
      }
      if (this.Info1Id > 0)
      {
        this.RemoveSubPart(this.Info1Id);
        this.Info1Id = 0;
      }
      if (this.info2id > 0)
      {
        this.RemoveSubPart(this.info2id);
        this.info2id = 0;
      }
      if (this.info3id > 0)
      {
        this.RemoveSubPart(this.info3id);
        this.info3id = 0;
      }
      if (this.info4id > 0)
      {
        this.RemoveSubPart(this.info4id);
        this.info4id = 0;
      }
      if (this.special1id > 0)
      {
        this.RemoveSubPart(this.special1id);
        this.special1id = 0;
      }
      if (this.special2id > 0)
      {
        this.RemoveSubPart(this.special2id);
        this.special2id = 0;
      }
      if (this.special3id > 0)
      {
        this.RemoveSubPart(this.special3id);
        this.special3id = 0;
      }
      if (this.game.EditObj.leftSideBarMode != 1 | this.game.ScreenHeight < 1040 && this.profId > 0)
      {
        this.RemoveSubPart(this.profId);
        this.profId = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      this.ClearMouse();
      bool openSideWindow = false;
      if (this.game.EditObj.leftSideBarMode > 0)
        openSideWindow = true;
      int x1 = 0;
      if (openSideWindow)
        x1 = 145;
      Bitmap bitmap;
      if (openSideWindow)
      {
        for (int h = this.h; h > -185; h -= 185)
        {
           Graphics local1 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TEXTURE);
           Bitmap local2 =  bitmap;
          int y = h;
          DrawMod.DrawSimple( local1,  local2, -35, y);
        }
      }
      if (!openSideWindow)
      {
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TOPSHADOWLEFT);
         Bitmap local4 =  bitmap;
        DrawMod.DrawSimple( local3,  local4, 0, 0);
      }
       Graphics local5 =  objgraphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_LEFT);
       Bitmap local6 =  bitmap;
      Rectangle rectangle1 = new Rectangle(0, 0, 40, 128);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x1, 0, 40, 128);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2( local5,  local6, srcrect1, destrect1);
      for (int y = 128; y < this.h - 128; y += 124)
      {
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_LEFT);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(0, 128, 40, 124);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(x1, y, 40, 124);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect2, destrect2);
      }
       Graphics local9 =  objgraphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_LEFT);
       Bitmap local10 =  bitmap;
      rectangle2 = new Rectangle(0, 252, 40, 128);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x1, this.h - 128, 40, 128);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2( local9,  local10, srcrect3, destrect3);
      int ty1 = 70;
      Rectangle trect1 = this.DrawOneTab(objgraphics, ty1, this.game.EditObj.leftSideBarMode == 2, openSideWindow, 10, this.MouseOverWhichTab == 2);
      this.AddMouse( trect1, "SHQ INVENTORY BAR", "Info on your stockpiles in your SHQ(s).", 2);
      int ty2 = ty1 + 68;
      Rectangle trect2;
      if (this.game.ScreenWidth < 1536)
      {
        trect2 = this.DrawOneTab(objgraphics, ty2, this.game.EditObj.leftSideBarMode == 3, openSideWindow, 33, this.MouseOverWhichTab == 3);
        this.AddMouse( trect2, "UNIT BAR", "An overview of all Units in selected Hex.", 3);
        ty2 += 68;
      }
      trect2 = this.DrawOneTab(objgraphics, ty2, this.game.EditObj.leftSideBarMode == 1, openSideWindow, 12, this.MouseOverWhichTab == 1);
      this.AddMouse( trect2, "REGIME PROFILE BAR", "Info on your Regime Profile scores.", 1);
      int ty3 = ty2 + 68;
      trect2 = this.DrawOneTab(objgraphics, ty3, this.game.EditObj.leftSideBarMode == 4, openSideWindow, 15, this.MouseOverWhichTab == 4);
      this.AddMouse( trect2, "QUICK ZONE BAR", "Options to switch Map quickly to another Zone.", 4);
      int y1 = ty3 + 68;
      if (openSideWindow)
      {
        y1 = this.h - 67;
         Graphics local11 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_EXITLEFT);
         Bitmap local12 =  bitmap;
        int y2 = y1;
        DrawMod.DrawSimple( local11,  local12, 153, y2);
        if (this.Info1Id < 1)
        {
          let mut tsubpart: SubPartClass =  new SEButtonPartClass(this.game.SE1_ARROW2, "Hide the left side bar.", 23);
          this.Info1Id = this.AddSubPart( tsubpart, 155, y1 + 18, 23, 35, 1);
        }
      }
      int groupy;
      double num1;
      if (openSideWindow & this.game.EditObj.leftSideBarMode == 4)
      {
        libName: String = "SE_Data";
        int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
        int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 160, 0, 0));
        int integer = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, libName, "Zones"));
        Conversions.ToInteger(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 1));
        Conversions.ToInteger(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 2));
        int id1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 6)));
        this.game.Data.StringListObj[stringListById1].GetData(0, integer, 7);
        this.game.EventRelatedObj.CheckRegimeSlot( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 8))), 0, 0, 0);
        int index1 = -1;
        if (id1 > 0)
          index1 = this.game.HandyFunctionsObj.GetLocationByID(id1);
        int num2 = -1;
        if (index1 > -1)
          num2 = this.game.Data.LocObj[index1].HQ;
        int unitSelected = this.game.EditObj.UnitSelected;
        int num3 = -1;
        if (unitSelected > -1)
          num3 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
        SimpleList simpleList1 = SimpleList::new();
        SimpleList simpleList2 = SimpleList::new();
        int unitCounter = this.game.Data.UnitCounter;
        for (int tid = 0; tid <= unitCounter; tid += 1)
        {
          if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].PreDef == -1 && this.game.Data.UnitObj[tid].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tid].Historical].Type == 8)
            simpleList1.Add(tid, 0);
        }
        bool flag = false;
        int length = this.game.Data.StringListObj[stringListById1].Length;
        for (int index2 = 0; index2 <= length; index2 += 1)
        {
          if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index2, 8])) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
          {
            int num4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index2, 0]));
            int id2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index2, 6]));
            int num5 = -1;
            if (id2 > 0)
            {
              int locationById = this.game.HandyFunctionsObj.GetLocationByID(id2);
              if (locationById > -1)
                num5 = this.game.Data.LocObj[locationById].HQ;
            }
            int tweight = ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData2(0, num4, 1, "pop", 2))) +  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData2(0, num4, 1, "worker", 2)))) * 100;
            simpleList2.Add(num4, tweight, num5);
            if (num5 > -1)
              simpleList1.AddWeight(num5, tweight);
            else
              flag = true;
          }
        }
        simpleList1.ReverseSort();
        simpleList2.ReverseSort();
        int num6 = 0;
        int num7 = this.h + 3;
        int num8 = num6 + 10 + 42 * (simpleList1.Counter + 1) + 28 * (simpleList2.Counter + 1);
        int num9 = 1;
        int num10 = this.game.EditObj.leftSideBarModePage;
        if (num8 > this.h + 2)
        {
          num7 = this.h - 54;
          num9 =  Math.Round(Math.Ceiling((double) num8 / (double) num7));
        }
        if (num10 < 1)
          num10 = 1;
        if (num10 > num9)
          num10 = num9;
        this.game.EditObj.leftSideBarModePage = num10;
        x1 = 5;
        y1 = 10;
        int width = 135;
        int height = 28;
        int num11 = 1;
        int num12 = simpleList1.Counter + 1;
        for (groupy = 0; groupy <= num12; groupy += 1)
        {
          int index3;
          string str1;
          if (groupy <= simpleList1.Counter)
          {
            index3 = simpleList1.Id[groupy];
            str1 = this.game.Data.UnitObj[index3].Name;
            if (str1.Length > 19)
              str1 = Strings.Left(str1, 19) + ".";
          }
          else
          {
            index3 = -1;
            str1 = "Without SHQ";
          }
          if (index3 > -1 | flag)
          {
            if (num11 == num10)
            {
               Graphics local13 =  objgraphics;
              bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
               Bitmap local14 =  bitmap;
              int x2 = x1;
              int y3 = y1;
              DrawMod.DrawSimple( local13,  local14, x2, y3);
              if (index3 == this.game.EditObj.UnitSelected)
                DrawMod.DrawTextColouredConsoleCenter( objgraphics, str1, DrawMod.TGame.MarcFont7, x1 + 65, y1 + 12, DrawMod.TGame.seColWhite);
              else
                DrawMod.DrawTextColouredConsoleCenter( objgraphics, str1, DrawMod.TGame.MarcFont7, x1 + 65, y1 + 12, DrawMod.TGame.seColGray);
              int tdata = -1;
              string ttitle;
              string ttext;
              if (index3 > -1)
              {
                if (index3 == this.game.EditObj.UnitSelected)
                {
                  ttitle = "SHQ: " + this.game.Data.UnitObj[index3].Name;
                  ttext = "You already have this SHQ selected.";
                  tdata = -1;
                }
                else
                {
                  ttitle = "SHQ: " + this.game.Data.UnitObj[index3].Name;
                  ttext = "Click to select this SHQ";
                  tdata = index3 + 10000;
                }
              }
              else
              {
                ttitle = "Zones without any SHQ assigned";
                ttext = "You might want to consider assigning this with the Zone SHQ Order in the Right Order Tab.";
              }
              rectangle2 = new Rectangle(x1, y1, 137, 39);
              Rectangle trect3 = rectangle2;
              this.AddMouse( trect3, ttitle, ttext, tdata);
            }
            y1 += 42;
            if (y1 > num7)
            {
              y1 = 10;
              num11 += 1;
            }
            int counter = simpleList2.Counter;
            for (int index4 = 0; index4 <= counter; index4 += 1)
            {
              int idValue = simpleList2.Id[index4];
              int num13 = simpleList2.Weight[index4];
              if (simpleList2.Data1[index4] == index3)
              {
                if (num11 == num10)
                {
                  data: String = this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 7);
                   Graphics local15 =  objgraphics;
                  bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_VARBOX);
                   Bitmap local16 =  bitmap;
                  int x3 = x1;
                  int y4 = y1;
                  DrawMod.DrawSimple( local15,  local16, x3, y4);
                  str2: String = data;
                  if (str2.Length > 9)
                    str2 = Strings.Left(str2, 9) + ".";
                  if (integer == idValue)
                    DrawMod.DrawTextColouredConsole( objgraphics, str2, this.game.MarcFont16, x1 + 6, y1 + 4, this.game.seColWhite);
                  else
                    DrawMod.DrawTextColouredConsole( objgraphics, str2, this.game.MarcFont16, x1 + 6, y1 + 4, this.game.seColGray);
                  tstring: String = num13.ToString();
                  if (num13 > 9999)
                  {
                    num1 = Math.Round((double) num13 / 1000.0, 0);
                    tstring = num1.ToString() + "k";
                  }
                  if (integer == idValue)
                    DrawMod.DrawTextColouredConsole( objgraphics, tstring, this.game.MarcFont16, x1 + 80, y1 + 4, this.game.seColWhite);
                  else
                    DrawMod.DrawTextColouredConsole( objgraphics, tstring, this.game.MarcFont16, x1 + 80, y1 + 4, this.game.seColGray);
                  ttitle: String = data;
                  if (integer == idValue)
                  {
                    ttext: String = "Zone has " + num13.ToString() + " Populace.\r\n\r\nYou have currently selected this Zone already.";
                    rectangle2 = new Rectangle(x1, y1, width, height);
                    Rectangle trect4 = rectangle2;
                    this.AddMouse( trect4, ttitle, ttext);
                  }
                  else
                  {
                    ttext: String = "Zone has " + num13.ToString() + " Populace.\r\n\r\nClick to select this Zone";
                    rectangle2 = new Rectangle(x1, y1, width, height);
                    Rectangle trect5 = rectangle2;
                    this.AddMouse( trect5, ttitle, ttext, idValue + 1000000);
                  }
                }
                y1 += height;
                if (y1 > num7)
                {
                  y1 = 10;
                  num11 += 1;
                }
              }
            }
          }
        }
        if (num9 > 1)
        {
          tstring: String = num10.ToString() + "/" + num9.ToString();
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring, this.game.MarcFont3, x1 +  Math.Round((double) (this.w - 50) / 2.0), this.h - 25, this.game.seColGray);
          int num14 = 0;
          if (num10 >= num9)
            num14 = 1;
          let mut tsubpart1: SubPartClass =  new TextButtonPartClass(">", 32, "Next page",  this.OwnBitmap, x1 + 100, this.h - 25, num14 == 1, theight: 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
          this.upId = this.AddSubPart( tsubpart1, x1 + 100, this.h - 25, 32, 25, 1);
          int num15 = 0;
          if (num10 <= 1)
            num15 = 1;
          let mut tsubpart2: SubPartClass =  new TextButtonPartClass("<", 32, "Previous page",  this.OwnBitmap, x1 + 5, this.h - 25, num15 == 1, theight: 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
          this.downId = this.AddSubPart( tsubpart2, x1 + 5, this.h - 25, 32, 25, 1);
        }
      }
      if (openSideWindow & this.game.EditObj.leftSideBarMode == 3)
      {
        if (this.game.SelectX == -1)
          return;
        int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
        int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
        int num16 = -1;
        int num17 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        if (num17 > 15)
          num17 = 15;
        int num18 = num17;
        for (int index = 0; index <= num18; index += 1)
        {
          if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index], this.game.Data.Turn) > 0)
            num16 += 1;
        }
        if (landscapeType > -1 & spriteNr > -1)
        {
          Rectangle rectangle3;
          x1 = rectangle3.X;
          y1 = 0;
          int num19 = -1;
          int num20 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
          if (num20 > 15)
            num20 = 15;
          if (this.h > 30 + (num20 + 1) * 80)
          {
            int num21 = num20;
            for (int index = 0; index <= num21; index += 1)
            {
              int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
              if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn) > 0)
              {
                num19 += 1;
                int num22 = x1 + 36;
                int num23 = 20 + num19 * 80;
                bool forcehighlight = false;
                if (this.game.EditObj.UnitSelected == unit)
                  forcehighlight = true;
                this.game.CustomBitmapObj.DrawUnitBig(unit, forcehighlight, objgraphics, num22, num23, true);
                if (this.game.EditObj.UnitSelected == unit)
                {
                  rectangle2 = new Rectangle(num22, num23, 76, 76);
                  Rectangle trect6 = rectangle2;
                  this.AddMouse( trect6, "SELECTED UNIT: " + this.game.Data.UnitObj[unit].Name, "You are currently viewing this unit. Click to put on top of stack.", 10000 + unit);
                }
                else
                {
                  rectangle2 = new Rectangle(num22, num23, 76, 76);
                  Rectangle trect7 = rectangle2;
                  this.AddMouse( trect7, this.game.Data.UnitObj[unit].Name, "Click to select. Double click to put on top of stack.", 10000 + unit);
                }
              }
            }
          }
          else
          {
            int num24 = num20;
            for (int index = 0; index <= num24; index += 1)
            {
              int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
              if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn) > 0)
              {
                num19 += 1;
                int num25;
                int num26;
                if ((num19 + 2) % 2 == 0)
                {
                  num25 = x1 + 25;
                  num26 = 20 +  Math.Round(Math.Floor((double) num19 / 2.0)) * 50;
                }
                else
                {
                  num25 = x1 + 85;
                  num26 = 20 +  Math.Round(Math.Floor((double) num19 / 2.0)) * 50;
                }
                bool forcehighlight = false;
                if (this.game.EditObj.UnitSelected == unit)
                  forcehighlight = true;
                this.game.CustomBitmapObj.DrawUnit(unit, forcehighlight, objgraphics, num25, num26, true);
                if (this.game.EditObj.UnitSelected == unit)
                {
                  rectangle2 = new Rectangle(num25, num26, 37, 37);
                  Rectangle trect8 = rectangle2;
                  this.AddMouse( trect8, "SELECTED UNIT: " + this.game.Data.UnitObj[unit].Name, "You are currently viewing this unit. Click to put on top of stack.", 10000 + unit);
                }
                else
                {
                  rectangle2 = new Rectangle(num25, num26, 37, 37);
                  Rectangle trect9 = rectangle2;
                  this.AddMouse( trect9, this.game.Data.UnitObj[unit].Name, "Click to select. Double click to put on top of stack.", 10000 + unit);
                }
              }
            }
          }
        }
      }
      if (openSideWindow & this.game.EditObj.leftSideBarMode == 2)
      {
        libName: String = "SE_Data";
        int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
        int stringListById4 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 284, 0, 0));
        int stringListById5 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 273, 0, 0));
        int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
        int integer = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, libName, "Zones"));
        Conversions.ToInteger(this.game.Data.StringListObj[stringListById6].GetData(0, integer, 1));
        Conversions.ToInteger(this.game.Data.StringListObj[stringListById6].GetData(0, integer, 2));
        int id =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, integer, 6)));
        this.game.Data.StringListObj[stringListById6].GetData(0, integer, 7);
        int num27 = this.game.EventRelatedObj.CheckRegimeSlot( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, integer, 8))), 0, 0, 0);
        int index5 = -1;
        if (id > 0)
          index5 = this.game.HandyFunctionsObj.GetLocationByID(id);
        int index6 = -1;
        if (index5 > -1)
          index6 = this.game.Data.LocObj[index5].HQ;
        int unitSelected = this.game.EditObj.UnitSelected;
        int index7 = -1;
        if (unitSelected > -1)
          index7 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
        SimpleList simpleList = SimpleList::new();
        SimpleStringList simpleStringList = SimpleStringList::new();
        simpleList.Add(7, 0, 19);
        simpleStringList.Add("Food\r\nYour workers and soldiers need food in order not to starve.", 1);
        simpleList.Add(5, 0, 20);
        simpleStringList.Add("Water\r\nYour domed farms need water in order to produce food.", 1);
        simpleList.Add(1, 0, 18);
        simpleStringList.Add("Oil\r\nNeeded to keep your mechanized troops mobile.", 1);
        simpleList.Add(10, 0, 17);
        simpleStringList.Add("Ammo\r\nNeeded to keep your army fighting. Build up reserves before starting a war.", 1);
        simpleList.Add(2, 0);
        simpleStringList.Add("Metals\r\nBase resource needed to build almost anything. Includes iron, copper and nickel.", 1);
        simpleList.Add(8, 0, 22);
        simpleStringList.Add("Industrial Points\r\nKey to producing almost anything.", 1);
        simpleList.Add(15, 0, 16);
        simpleStringList.Add("Energy\r\nSome assets require energy in-order to run. Energy can be produced in power plants.", 1);
        simpleList.Add(4, 0);
        simpleStringList.Add("Radioactives\r\nSome models will require Radioactives for construction and/or ammunitions.", 1);
        simpleList.Add(9, 0);
        simpleStringList.Add("Recruits\r\nIn order to raise new troops you need recruits.", 1);
        simpleList.Add(12, 0);
        simpleStringList.Add("Colonists\r\nTo found a new city or increase populace of a zone you need colonists.", 1);
        simpleList.Add(3, 0);
        simpleStringList.Add("Rare Metals\r\nIncludes rare earth metals. For advanced production.", 1);
        simpleList.Add(13, 0);
        simpleStringList.Add("Machines\r\nFor construction of advanced equipment and assets.", 1);
        simpleList.Add(14, 0);
        simpleStringList.Add("Hi-Tech Parts\r\nFor construction of very advanced equipment and assets.", 1);
        bool flag = false;
        if (num27 != this.game.Data.Turn)
        {
          x1 = 5;
          y1 = 10;
          tstring: String = "Unfriendly";
           Graphics local17 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
           Bitmap local18 =  bitmap;
          int x4 = x1;
          int y5 = y1;
          DrawMod.DrawSimple( local17,  local18, x4, y5);
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring, DrawMod.TGame.MarcFont7, x1 + 65, y1 + 12, DrawMod.TGame.seColGray);
          flag = true;
          if (this.game.EventRelatedObj.Helper_IsDebug())
            flag = false;
        }
        if (index6 < 0)
        {
          x1 = 5;
          y1 = 10;
          tstring: String = "No SHQ";
           Graphics local19 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
           Bitmap local20 =  bitmap;
          int x5 = x1;
          int y6 = y1;
          DrawMod.DrawSimple( local19,  local20, x5, y6);
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring, DrawMod.TGame.MarcFont7, x1 + 65, y1 + 12, DrawMod.TGame.seColGray);
          flag = true;
        }
        if (flag)
        {
          int num28 = y1 + 42;
          int num29 = 28;
          if (this.game.ScreenHeight < 920)
            num29 = 25;
          int num30 = 0;
          do
          {
             Graphics local21 =  objgraphics;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_VARBOX);
             Bitmap local22 =  bitmap;
            int x6 = x1;
            int y7 = num28;
            DrawMod.DrawSimple( local21,  local22, x6, y7);
            num28 += num29;
            num30 += 1;
          }
          while (num30 <= 11);
          return;
        }
        if (index6 == -1 && unitSelected > -1)
        {
          if (this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn)
          {
            int historical1 = this.game.Data.UnitObj[unitSelected].Historical;
            if (!this.game.Data.UnitObj[unitSelected].IsHQ | this.game.Data.HistoricalUnitObj[historical1].Type < 8)
            {
              if (index7 > -1)
              {
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index7].Historical].Type == 8)
                  index6 = index7;
                else if (this.game.Data.UnitObj[index7].HQ > -1)
                {
                  int historical2 = this.game.Data.UnitObj[this.game.Data.UnitObj[index7].HQ].Historical;
                  if (historical2 > -1 && this.game.Data.HistoricalUnitObj[historical2].Type == 8)
                    index6 = this.game.Data.UnitObj[index7].HQ;
                }
              }
            }
            else
              index6 = unitSelected;
          }
          int regime = this.game.Data.UnitObj[unitSelected].Regime;
        }
        if (unitSelected > -1)
        {
          int historical = this.game.Data.UnitObj[unitSelected].Historical;
          if (historical > -1 && this.game.Data.UnitObj[unitSelected].IsHQ & this.game.Data.HistoricalUnitObj[historical].Type == 8 && this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn)
            index6 = unitSelected;
        }
        this.currentShqNr = index6;
        int x7 = 5;
        int y8 = 10;
        int width = 135;
        int eventPic1 = this.game.Data.FindEventPic("", 9, "SE_Present");
        int eventPic2 = this.game.Data.FindEventPic("", 8, "SE_Present");
        int eventPic3 = this.game.Data.FindEventPic("", 11, "SE_Present");
        str3: String = this.game.SelectX.ToString() + "," + this.game.SelectY.ToString();
        str4: String = this.game.Data.UnitObj[index6].Name;
        if (str4.Length > 15)
          str4 = Strings.Left(str4, 15) + ".";
         Graphics local23 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
         Bitmap local24 =  bitmap;
        int x8 = x7;
        int y9 = y8;
        DrawMod.DrawSimple( local23,  local24, x8, y9);
        if (index6 == this.game.EditObj.UnitSelected)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, str4, DrawMod.TGame.MarcFont7, x7 + 65, y8 + 12, DrawMod.TGame.seColWhite);
        else
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, str4, DrawMod.TGame.MarcFont7, x7 + 65, y8 + 12, DrawMod.TGame.seColGray);
        string ttitle1;
        string ttext1;
        int tdata;
        if (index6 == this.game.EditObj.UnitSelected)
        {
          ttitle1 = "SHQ: " + this.game.Data.UnitObj[index6].Name;
          ttext1 = "You already have this SHQ selected.";
          tdata = -1;
        }
        else
        {
          ttitle1 = "SHQ: " + this.game.Data.UnitObj[index6].Name;
          ttext1 = "Click to select this SHQ";
          tdata = index6 + 10000;
        }
        rectangle2 = new Rectangle(x7, y8, 137, 39);
        Rectangle trect10 = rectangle2;
        this.AddMouse( trect10, ttitle1, ttext1, tdata);
        int num31 = 0;
        int counter1 = simpleList.Counter;
        for (int index8 = 0; index8 <= counter1; index8 += 1)
        {
          if (this.game.Data.UnitObj[index6].items.list.FindWeight(simpleList.Id[index8]) > 0 |  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index6].Historical].ID, 2, simpleList.Id[index8], 3))) > 0 |  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index6].Historical].ID, 2, simpleList.Id[index8], 3))) > 0)
            num31 += 1;
        }
        int height = 28;
        if (this.game.ScreenHeight < 920)
        {
          if (num31 > 12)
            height = 23;
          else if (num31 > 11)
            height = 25;
        }
        int y10 = y8 + 42;
        int counter2 = simpleList.Counter;
        for (int index9 = 0; index9 <= counter2; index9 += 1)
        {
          int weight = this.game.Data.UnitObj[index6].items.list.FindWeight(simpleList.Id[index9]);
          int num32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index6].Historical].ID, 2, simpleList.Id[index9], 3)));
          int num33 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index6].Historical].ID, 2, simpleList.Id[index9], 3)));
          if (weight > 0 | num32 > 0 | num33 > 0 | this.game.ScreenHeight >= 920)
          {
            this.game.Data.StringListObj[stringListById3].GetData(0, simpleList.Id[index9], 2);
            str5: String = simpleStringList.Id[index9];
             Graphics local25 =  objgraphics;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_VARBOX);
             Bitmap local26 =  bitmap;
            int x9 = x7;
            int y11 = y10;
            DrawMod.DrawSimple( local25,  local26, x9, y11);
            int index10 = this.game.EventRelatedObj.GetEventPicSlotFor(simpleList.Id[index9], "", "");
             Graphics local27 =  objgraphics;
            bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index10]);
             Bitmap local28 =  bitmap;
            int x10 = x7 + 2;
            int y12 = y10 + 6;
            DrawMod.DrawSimple( local27,  local28, x10, y12);
            if (simpleList.Id[index9] == 9 | simpleList.Id[index9] == 12)
            {
              weight *= 100;
              num32 *= 100;
              num33 *= 100;
            }
            tstring1: String = weight.ToString();
            if (weight > 9999)
            {
              num1 = Math.Round((double) weight / 1000.0, 1);
              tstring1 = num1.ToString() + "k";
            }
            int num34 = num33 - num32;
            ttitle2: String = simpleStringList.Id[index9];
            int num35 = 0;
            int num36 = 0;
            int num37 = 0;
            index10 = 0;
            int num38 = 0;
            int num39 = 0;
            int num40 = 0;
            int num41 = 0;
            int num42 = 0;
            int logCounter = this.game.Data.UnitObj[index6].LogCounter;
            for (groupy = 0; groupy <= logCounter; groupy += 1)
            {
              if (this.game.Data.UnitObj[index6].LogData1[groupy] == simpleList.Id[index9])
              {
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 101)
                  num35 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 102)
                  num36 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 103)
                  num37 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 104)
                  index10 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 301)
                  num38 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 302)
                  num39 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 304)
                  num41 += this.game.Data.UnitObj[index6].LogData3[groupy];
                if (this.game.Data.UnitObj[index6].LogType[groupy] == 305)
                  num42 += this.game.Data.UnitObj[index6].LogData3[groupy];
              }
            }
            if (num38 > 0)
              tstring1 += "*";
            DrawMod.DrawTextColouredConsole( objgraphics, tstring1, this.game.MarcFont16, x7 + 31, y10 + 4, this.game.seColGray);
            int num43 = Math.Abs(num34);
            tstring2: String = num43.ToString();
            if (num34 > 9999 | num34 < -9999)
            {
              num1 = Math.Round((double) Math.Abs(num34) / 1000.0, 1);
              tstring2 = num1.ToString() + "k";
            }
            if (num38 > 0)
              num34 = 0;
            if (num34 != 0)
              DrawMod.DrawTextColouredConsole( objgraphics, tstring2, this.game.MarcFont7, x7 + 91, y10 + 5, this.game.seColGray);
            if (num34 > 0)
            {
               Graphics local29 =  objgraphics;
              bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic2]);
               Bitmap local30 =  bitmap;
              rectangle2 = new Rectangle(0, 0, 32, 16);
              Rectangle srcrect4 = rectangle2;
              trect10 = new Rectangle(x7 + 76, y10 + 6, 32, 16);
              Rectangle destrect4 = trect10;
              DrawMod.DrawSimplePart2ColouredNew( local29,  local30, srcrect4, destrect4, 0.0f, 1.5f, 0.0f, 1f);
            }
            else if (num34 < 0)
            {
               Graphics local31 =  objgraphics;
              bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic1]);
               Bitmap local32 =  bitmap;
              rectangle2 = new Rectangle(0, 0, 32, 16);
              Rectangle srcrect5 = rectangle2;
              trect10 = new Rectangle(x7 + 76, y10 + 6, 32, 16);
              Rectangle destrect5 = trect10;
              DrawMod.DrawSimplePart2ColouredNew( local31,  local32, srcrect5, destrect5, 1.5f, 0.0f, 0.0f, 1f);
            }
            else
            {
               Graphics local33 =  objgraphics;
              bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic3]);
               Bitmap local34 =  bitmap;
              rectangle2 = new Rectangle(0, 0, 32, 16);
              Rectangle srcrect6 = rectangle2;
              trect10 = new Rectangle(x7 + 76, y10 + 6, 32, 16);
              Rectangle destrect6 = trect10;
              DrawMod.DrawSimplePart2ColouredNew( local33,  local34, srcrect6, destrect6, 0.0f, 1.8f, 1.8f, 1f);
            }
            if (simpleList.Id[index9] == 9 | simpleList.Id[index9] == 12)
            {
              num35 *= 100;
              num36 *= 100;
              num37 *= 100;
              index10 *= 100;
              num38 *= 100;
              num39 *= 100;
              num40 *= 100;
              num41 *= 100;
              num42 *= 100;
            }
            int num44 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index6].Historical].ID, 2, simpleList.Id[index9], 3)));
            if (simpleList.Id[index9] == 9 | simpleList.Id[index9] == 12)
              num44 *= 100;
            str6: String = "End of last Round stocks: " + num44.ToString() + "\r\n" + "Sent to zones: " + num36.ToString() + "\r\n" + "Items present for delivery to Units: " + (num44 - num36).ToString() + "\r\n" + "Sent to units: " + num37.ToString() + "\r\n" + "Delivered from zones: " + num35.ToString() + "\r\n" + "Consumed by Troops in SHQ: " + index10.ToString() + "\r\n" + "Consumed by Colonists & Recruits: " + num39.ToString() + "\r\n";
            num43 = num38 - num41;
            str7: String = num43.ToString();
            str8: String = str6 + "Lost due to max storage reached: " + str7 + "\r\n";
            if (num41 > 0)
              str8 = str8 + "Sold due to max storage reached: " + num41.ToString() + " for " + num42.ToString() + " Credits.\r\n";
            string ttext2;
            if (simpleList.Data1[index9] > 0)
            {
              num40 = this.game.Data.UnitObj[index6].items.list.FindWeight(simpleList.Data1[index9]);
              ttext2 = str8 + "\r\nMaximum storage: " + num40.ToString();
            }
            else
              ttext2 = str8 + "\r\nMaximum storage: Unlimited";
            rectangle2 = new Rectangle(x7, y10, width, height);
            trect10 = rectangle2;
            this.AddMouse( trect10, ttitle2, ttext2);
            y10 += height;
            if (y10 + (220 + (height + 5) + 60) > this.game.ScreenHeight)
              break;
          }
        }
      }
      if (openSideWindow & this.game.EditObj.leftSideBarMode == 1)
      {
        int num45 = 0;
        int id3 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
        this.game.Data.FindEventPic("", 9, "SE_Present");
        this.game.Data.FindEventPic("", 8, "SE_Present");
        this.game.Data.FindEventPic("", 11, "SE_Present");
        int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 291, 0, 0));
        int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
        int num46 = 9;
        int num47;
        if (((this.game.ScreenHeight < 1040 ? 1 : 0) | 0) != 0)
        {
          if (Information.IsNothing((object) this.cacheList))
            this.cacheList = "";
          int id4 = this.game.EventRelatedObj.CheckStringlistID("SE_IO", 158, 0, 0);
          this.game.EventRelatedObj.IO_AddClear();
          int val2 = 0;
          if (this.game.ScreenHeight < 284)
            val2 = 0;
          if (this.game.ScreenHeight > 284)
          {
            val2 += Math.Min(20,  Math.Round((double) (this.game.ScreenHeight - 769) / 10.0));
            num47 = num46 + Math.Min(20,  Math.Round((double) (this.game.ScreenHeight - 769) / 10.0)) * 7;
          }
          int num48 = Math.Max(2, val2);
          int num49 = 1;
          do
          {
            if (num49 == 1)
              groupy = 1;
            if (num49 == 2)
              groupy = 2;
            if (num49 == 3)
              groupy = 3;
            this.game.EventRelatedObj.Helper_AddProfileVisual(id3, groupy, "", 0, "", 0, 0, num48, 2, true);
            num48 += 40 + val2;
            num49 += 1;
          }
          while (num49 <= 3);
          str: String = "[element][type]layout[/type][h]0[/h][/element]" + this.game.EventRelatedObj.CheckKey(id4, "FINALTEXT", 0, 0);
          int num50 = 0;
          if (Operators.CompareString(str, this.cacheList, false) != 0 | this.profId < 1)
          {
            if (this.profId > 0)
            {
              this.RemoveSubPart(this.profId);
              this.profId = 0;
            }
            if (this.game.ScreenWidth >= 1435)
            {
              let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, this.w - 40, this.h, str,  this.OwnBitmap, num50, num45, true, tAlwaysShowBackground: true);
              this.profId = this.AddSubPart( tsubpart, num50, num45, this.w - 40, this.h, 0);
            }
            else
            {
              let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, this.w - 40, num48, str,  this.OwnBitmap, num50, num45, true, tAlwaysShowBackground: true);
              this.profId = this.AddSubPart( tsubpart, num50, num45, this.w - 40, num48, 0);
            }
          }
          else
            this.SubPartFlag[this.SubpartNr(this.profId)] = true;
        }
        else if (this.game.ScreenHeight >= 1040)
        {
          if (Information.IsNothing((object) this.cacheList))
            this.cacheList = "";
          int id5 = this.game.EventRelatedObj.CheckStringlistID("SE_IO", 158, 0, 0);
          this.game.EventRelatedObj.IO_AddClear();
          int val2 = 9;
          int num51 = 658;
          if (this.game.ScreenHeight < 1080)
          {
            val2 = 2;
            num51 -= 40;
          }
          if (this.game.ScreenHeight > 1080)
          {
            val2 += Math.Min(20,  Math.Round((double) (this.game.ScreenHeight - 1080) / 10.0));
            num47 = num51 + Math.Min(20,  Math.Round((double) (this.game.ScreenHeight - 1080) / 10.0)) * 7;
          }
          int num52 = Math.Max(4, val2);
          int num53 = 1;
          do
          {
            if (num53 == 1)
              groupy = 1;
            if (num53 == 2)
              groupy = 2;
            if (num53 == 3)
              groupy = 3;
            this.game.EventRelatedObj.Helper_AddProfileVisual(id3, groupy, "", 0, "", 0, 0, num52, 2);
            num52 += 85 + val2;
            num53 += 1;
          }
          while (num53 <= 3);
          int tx = 5;
          if (num52 + 85 < this.h)
          {
            this.game.EventRelatedObj.Helper_AddProfileVisual(id3, -1, "militia", 0, "", 0, tx, num52, 2);
            int length = this.game.Data.StringListObj[stringListById7].Length;
            for (int index = 0; index <= length; index += 1)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index, 5])) == 1)
              {
                str: String = this.game.Data.StringListObj[stringListById7].Data[index, 0];
                if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index, 1])) == 3)
                {
                  int num54 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData2(0, id3, 1, str, 2)));
                  if (num54 > 0 & num54 <= 100)
                  {
                    tx += 70;
                    if (tx > 100)
                    {
                      tx = 5;
                      num52 += 85 + val2;
                    }
                    if (num52 + 85 < this.h)
                      this.game.EventRelatedObj.Helper_AddProfileVisual(id3, -1, str, 0, "", 0, tx, num52, 2);
                  }
                }
              }
            }
          }
          str9: String = "[element][type]layout[/type][h]0[/h][/element]" + this.game.EventRelatedObj.CheckKey(id5, "FINALTEXT", 0, 0);
          int num55 = 0;
          if (Operators.CompareString(str9, this.cacheList, false) != 0 | this.profId < 1)
          {
            if (this.profId > 0)
            {
              this.RemoveSubPart(this.profId);
              this.profId = 0;
            }
            if (this.game.ScreenWidth >= 1518)
            {
              let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, this.w - 40, this.h, str9,  this.OwnBitmap, num55, num45, true, tAlwaysShowBackground: true);
              this.profId = this.AddSubPart( tsubpart, num55, num45, this.w - 40, this.h, 0);
            }
            else
            {
              let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, this.w - 40, num52, str9,  this.OwnBitmap, num55, num45, true, tAlwaysShowBackground: true);
              this.profId = this.AddSubPart( tsubpart, num55, num45, this.w - 40, num52, 0);
            }
            this.cacheList = str9;
          }
          else
            this.SubPartFlag[this.SubpartNr(this.profId)] = true;
        }
      }
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
      objgraphics = (Graphics) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.game.EditObj.TipButton = false;
            this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (this.game.EditObj.TipButton)
              return;
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          if (Strings.InStr(this.game.EditObj.TipText, "MX-ENTR") <= 0)
            break;
          this.game.EditObj.TipTitle += "<FIXEDSYS>";
          break;
        }
      }
    }

    pub void PopUpRefresh() => this.DoRefresh();

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (this.game.EditObj.TutOrder > -1)
        return windowReturnClass1;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; index += 1)
      {
        if (this.SubPartCounter > -1 && x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          int num = this.SubPartID[index];
          if (num == this.Info1Id)
          {
            this.game.EditObj.leftSideBarMode = 0;
            windowReturnClass1.AddCommand(4, 68);
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (num == this.special1id)
          {
            this.game.EditObj.PopupValue = 23;
            windowReturnClass1.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (num == this.special2id)
          {
            this.game.EditObj.PopupValue = 24;
            windowReturnClass1.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (num == this.special3id)
          {
            this.game.EditObj.PopupValue = 25;
            windowReturnClass1.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (num == this.upId)
          {
            this += 1.game.EditObj.leftSideBarModePage;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (num == this.downId)
          {
            --this.game.EditObj.leftSideBarModePage;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
      }
      int mouseCounter1 = this.MouseCounter;
      for (int index1 = 0; index1 <= mouseCounter1; index1 += 1)
      {
        if (x > this.MouseRect[index1].X & x < this.MouseRect[index1].X + this.MouseRect[index1].Width && y > this.MouseRect[index1].Y & y < this.MouseRect[index1].Y + this.MouseRect[index1].Height)
        {
          if (this.MouseData[index1] > 0 & this.MouseData[index1] <= 4)
          {
            if (this.game.EditObj.leftSideBarMode == this.MouseData[index1])
            {
              this.game.EditObj.leftSideBarMode = 0;
            }
            else
            {
              if (this.game.EditObj.leftSideBarMode > 1 && this.profId > 0)
              {
                this.RemoveSubPart(this.profId);
                this.profId = 0;
              }
              this.game.EditObj.leftSideBarMode = this.MouseData[index1];
            }
            windowReturnClass1.AddCommand(4, 68);
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] >= 1000000)
          {
            int idValue = this.MouseData[index1] - 1000000;
            int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
            int id =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, idValue, 6)));
            int num = 0;
            if (id > 0)
            {
              int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
              if (locationById > -1)
              {
                num = 1;
                this.game.SelectX = this.game.Data.LocObj[locationById].X;
                this.game.SelectY = this.game.Data.LocObj[locationById].Y;
              }
            }
            if (num == 0)
            {
              int integer1 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].GetData(0, idValue, 10));
              int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].GetData(0, idValue, 11));
              if (integer1 > 0 & integer2 > 0)
              {
                this.game.SelectX = integer1;
                this.game.SelectY = integer2;
                num = 1;
              }
            }
            if (num == 1)
            {
              this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
              this.game.EditObj.UnitSelected = -1;
              this.game.HandyFunctionsObj.SetcornerXY2();
              ScreenClass screeny = this.formref.Screeny;
              Type type = typeof (MapWindowClass2);
               Type local =  type;
              windowReturnClass2: WindowReturnClass = (WindowReturnClass) ((MapWindowClass2) screeny.GetWindow( local)).UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
              windowReturnClass2.AddCommand(4, 12);
              windowReturnClass2.AddCommand(4, 69);
              windowReturnClass2.AddCommand(4, 67);
              windowReturnClass2.AddCommand(4, 68);
              windowReturnClass2.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass2.SetFlag(true);
              return windowReturnClass2;
            }
          }
          else if (this.MouseData[index1] >= 10000)
          {
            int index2 = this.MouseData[index1] - 10000;
            int index3 = 0;
            if (index2 > -1)
            {
              if (index2 != this.game.EditObj.UnitSelected)
              {
                if ((double) this.game.Data.RuleVar[701] > 0.0)
                {
                  ScreenClass screeny = this.formref.Screeny;
                  Type type = typeof (MapWindowClass2);
                   Type local =  type;
                  MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                  if (!Information.IsNothing((object) window))
                  {
                    this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                    this.game.EditObj.UnitSelected = index2;
                    if (this.game.SelectX == this.game.Data.UnitObj[index2].X & this.game.SelectY == this.game.Data.UnitObj[index2].Y)
                    {
                      this.game.SelectX = this.game.Data.UnitObj[index2].X;
                      this.game.SelectY = this.game.Data.UnitObj[index2].Y;
                    }
                    else
                    {
                      this.game.SelectX = this.game.Data.UnitObj[index2].X;
                      this.game.SelectY = this.game.Data.UnitObj[index2].Y;
                      this.game.HandyFunctionsObj.SetcornerXY2();
                    }
                    windowReturnClass3: WindowReturnClass = (WindowReturnClass) window.UdsClickUnit(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, true);
                    windowReturnClass3.AddCommand(4, 12);
                    windowReturnClass3.AddCommand(4, 69);
                    windowReturnClass3.AddCommand(4, 67);
                    windowReturnClass3.AddCommand(4, 68);
                    windowReturnClass3.AddCommand(4, 9);
                    this.dostuff();
                    windowReturnClass3.SetFlag(true);
                    return windowReturnClass3;
                  }
                }
                else
                {
                  this.game.EditObj.UnitSelected = index2;
                  this.game.EditObj.TempCoordList = CoordList::new();
                  this.game.HandyFunctionsObj.CenterOnXY(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y);
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 68);
                  windowReturnClass1.AddCommand(4, 9);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
              }
              else if ((double) this.game.Data.RuleVar[701] > 0.0)
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                this.game.EditObj.UnitSelected = index2;
                this.game.SelectX = this.game.Data.UnitObj[index2].X;
                this.game.SelectY = this.game.Data.UnitObj[index2].Y;
                while (this.game.Data.MapObj[index3].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] != index2)
                {
                  int unit = this.game.Data.MapObj[index3].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
                  index3 = 0;
                  if (this.game.Data.MapObj[index3].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > 0)
                  {
                    for (int unitCounter = this.game.Data.MapObj[index3].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter; unitCounter >= 1; unitCounter += -1)
                      this.game.Data.MapObj[index3].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter] = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter - 1];
                  }
                  this.game.Data.MapObj[index3].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] = unit;
                }
                windowReturnClass1.AddCommand(4, 12);
                windowReturnClass1.AddCommand(4, 69);
                windowReturnClass1.AddCommand(4, 67);
                windowReturnClass1.AddCommand(4, 68);
                windowReturnClass1.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
          }
        }
      }
      windowReturnClass1.NoMouseClickBelow = this.game.EditObj.leftSideBarMode <= 0 ? x < 30 : x <= this.OwnBitmap.Width - 22;
      int mouseCounter2 = this.MouseCounter;
      bool flag;
      for (int index = 0; index <= mouseCounter2; index += 1)
      {
        if (x > this.MouseRect[index].X - 16 & x < this.MouseRect[index].X + this.MouseRect[index].Width + 32 && y > this.MouseRect[index].Y - 16 & y < this.MouseRect[index].Y + this.MouseRect[index].Height + 32)
          flag = true;
      }
      if (flag)
        windowReturnClass1.NoMouseClickBelow = true;
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false) => WindowReturnClass::new();
  }
}
