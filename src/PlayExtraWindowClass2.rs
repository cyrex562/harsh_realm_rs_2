// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PlayExtraWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class PlayExtraWindowClass2 : WindowClass
  {
     int CurrentView;
     int w;
     int h;
     int cardsel;
     int cardhover;
     int lastunit;
     int playcardid;
     int playcard2id;
     int fakeid;
     int detailnr;
     int detailnr2;
     int detailnr3;
     int detailnr2Top;
     ListClass rlistobj;
     ListClass rlist2obj;
     ListClass rlist3obj;
     ListClass rlist4obj;
     ListClass rlist5obj;
     int rlistid;
     int rlist2id;
     int rlist3id;
     int rlist4id;
     int rlist5id;
     int tSelectX;
     int tSelectY;
     int tSelectMap;
     int tCornerX;
     int tCornerY;
     int prevAssetId;
     int AssetOrderNumber;
     bool viewingtrooptab;
     int extraTabId;
     int smallTabId;
     string orderfeedbackString;
     int[] zoneButton;
     int zoneButtonCounter;
     int[] zoneButtonData;
     int[] unitButton;
     int unitButtonCounter;
     int[] unitButtonData;
     int[] regButton;
     int regButtonCounter;
     int[] regButtonData;
     int[] assetButton;
     int assetButtonCounter;
     int[] assetButtonData;
     int tempCharId;
     int tempZoneId;
     int tempRegId;
     int tempRegType;
     int slotCulture;
     bool calledFromNew;
     bool calledFromNonCardSelectWindow;

    pub PlayExtraWindowClass2(
       GameClass tGame,
      Bitmap screenbitmap = null,
      int sx = -1,
      int sy = -1,
      bool tcalledFromNonCardSelectWindow = false)
      : base( tGame, tGame.ScreenWidth, 222, BackSprite: tGame.MARCBOTBAR)
    {
      this.zoneButton = new int[100];
      this.zoneButtonCounter = -1;
      this.zoneButtonData = new int[100];
      this.unitButton = new int[100];
      this.unitButtonCounter = -1;
      this.unitButtonData = new int[100];
      this.regButton = new int[100];
      this.regButtonCounter = -1;
      this.regButtonData = new int[100];
      this.assetButton = new int[100];
      this.assetButtonCounter = -1;
      this.assetButtonData = new int[100];
      this.tempCharId = -1;
      this.tempZoneId = -1;
      this.tempRegId = -1;
      this.tempRegType = -1;
      this.slotCulture = -1;
      this.calledFromNew = false;
      this.calledFromNonCardSelectWindow = false;
      this.w = tGame.ScreenWidth;
      this.h = 222;
      this.BlockBlit = true;
      if (this.game.EditObj.SetViewMode > 0)
      {
        this.CurrentView = this.game.EditObj.SetViewMode;
        this.game.EditObj.SetViewMode = 0;
      }
      if (this.game.SelectX > -1 & this.game.SelectY > -1 & this.game.EditObj.UnitSelected == -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
        this.game.EditObj.UnitSelected = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
      this.calledFromNonCardSelectWindow = tcalledFromNonCardSelectWindow;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr2Top = 0;
      this.cardsel = -1;
      this.cardhover = -1;
      this.CurrentView = 0;
      this.game.EditObj.SetViewMode3 = false;
      this.viewingtrooptab = false;
      this.calledFromNew = true;
      this.dostuff();
      this.calledFromNew = false;
    }

    pub void DoRefresh()
    {
      if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X == -1)
        this.game.EditObj.UnitSelected = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].OnBoard;
      if (this.lastunit != this.game.EditObj.UnitSelected)
      {
        this.cardsel = -1;
        this.detailnr = -1;
        this.detailnr2 = -1;
        this.detailnr3 = -1;
        this.cardhover = -1;
      }
      this.dostuff();
    }

    pub void dostuff()
    {
      this.tSelectX = this.game.SelectX;
      this.tSelectY = this.game.SelectY;
      this.tCornerX = this.game.CornerX;
      this.tCornerY = this.game.CornerY;
      this.CurrentView = this.game.EditObj.SetViewMode;
      if (this.lastunit != this.game.EditObj.UnitSelected)
        this.game.EditObj.se1_UnitPage = 1;
      this.lastunit = this.game.EditObj.UnitSelected;
      int assetButtonCounter = this.assetButtonCounter;
      for (int index = 0; index <= assetButtonCounter; index += 1)
      {
        this.RemoveSubPart(this.assetButton[index]);
        this.assetButton[index] = 0;
        this.assetButtonData[index] = 0;
      }
      this.assetButtonCounter = -1;
      int zoneButtonCounter = this.zoneButtonCounter;
      for (int index = 0; index <= zoneButtonCounter; index += 1)
      {
        this.RemoveSubPart(this.zoneButton[index]);
        this.zoneButton[index] = 0;
        this.zoneButtonData[index] = 0;
      }
      this.zoneButtonCounter = -1;
      int unitButtonCounter = this.unitButtonCounter;
      for (int index = 0; index <= unitButtonCounter; index += 1)
      {
        this.RemoveSubPart(this.unitButton[index]);
        this.unitButton[index] = 0;
        this.unitButtonData[index] = 0;
      }
      this.unitButtonCounter = -1;
      int regButtonCounter = this.regButtonCounter;
      for (int index = 0; index <= regButtonCounter; index += 1)
      {
        this.RemoveSubPart(this.regButton[index]);
        this.regButton[index] = 0;
        this.regButtonData[index] = 0;
      }
      this.regButtonCounter = -1;
      this.NewBackGroundAndClearAll(this.w, this.h, this.game.MARCBOTBAR);
      this.ClearMouse();
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.game.Data.Round <= 0)
        return;
      Rectangle useRect;
      if (this.game.EditObj.SetViewModeExtraNr == 1)
      {
        if (this.w >= 1840)
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1840) / 2.0), 0, 1280, this.h);
          this.ZoneBottomTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1840) / 2.0) + 1280, 0, 280, this.h);
          this.QuickRegimeTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1840) / 2.0) + 1280 + 280, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local1 =  graphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local2 =  bitmap1;
          int x1 =  Math.Round((double) (this.w - 1840) / 2.0) - 80;
          DrawMod.DrawSimple( local1,  local2, x1, 0);
           Graphics local3 =  graphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local4 =  bitmap2;
          int x2 =  Math.Round((double) (this.w - 1840) / 2.0) + 1840;
          DrawMod.DrawSimple( local3,  local4, x2, 0);
        }
        else if (this.w >= 1560)
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1560) / 2.0), 0, 1280, this.h);
          this.ZoneBottomTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1560) / 2.0) + 1280, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local5 =  graphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local6 =  bitmap3;
          int x3 =  Math.Round((double) (this.w - 1560) / 2.0) - 80;
          DrawMod.DrawSimple( local5,  local6, x3, 0);
           Graphics local7 =  graphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local8 =  bitmap4;
          int x4 =  Math.Round((double) (this.w - 1560) / 2.0) + 1560;
          DrawMod.DrawSimple( local7,  local8, x4, 0);
        }
        else
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0), 0, 1280, this.h);
          this.ZoneBottomTab(graphics, useRect);
           Graphics local9 =  graphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local10 =  bitmap5;
          int x5 =  Math.Round((double) (this.w - 1280) / 2.0) - 80;
          DrawMod.DrawSimple( local9,  local10, x5, 0);
           Graphics local11 =  graphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local12 =  bitmap6;
          int x6 =  Math.Round((double) (this.w - 1280) / 2.0) + 1280;
          DrawMod.DrawSimple( local11,  local12, x6, 0);
        }
      }
      Bitmap bitmap7;
      if (this.game.EditObj.SetViewModeExtraNr <= 0)
      {
        if (this.w >= 1920 & !this.game.EditObj.maximumInterfaceSpace)
        {
          int num = (this.w - 732) % 156;
          int width = this.w - (536 + num);
          useRect = new Rectangle(256 +  Math.Round((double) num / 2.0), 0, width, this.h);
          this.UnitBottomTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) num / 2.0), 0, 256, this.h);
          this.OtherUnits(graphics, useRect);
          useRect = new Rectangle(256 +  Math.Round((double) num / 2.0) + width, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local13 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local14 =  bitmap7;
          int x7 =  Math.Round((double) num / 2.0) - 80;
          DrawMod.DrawSimple( local13,  local14, x7, 0);
           Graphics local15 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local16 =  bitmap7;
          int x8 = this.w -  Math.Round((double) num / 2.0);
          DrawMod.DrawSimple( local15,  local16, x8, 0);
        }
        else if (this.w >= 1536)
        {
          int num = (this.w - 1536) % 156;
          useRect = new Rectangle(256 +  Math.Round((double) num / 2.0), 0, this.w - (256 + num), this.h);
          this.UnitBottomTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) num / 2.0), 0, 256, this.h);
          this.OtherUnits(graphics, useRect);
           Graphics local17 =  graphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local18 =  bitmap8;
          int x9 =  Math.Round((double) num / 2.0) - 80;
          DrawMod.DrawSimple( local17,  local18, x9, 0);
           Graphics local19 =  graphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local20 =  bitmap9;
          int x10 = this.w -  Math.Round((double) num / 2.0);
          DrawMod.DrawSimple( local19,  local20, x10, 0);
        }
        else
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0), 0, 1280, this.h);
          this.UnitBottomTab(graphics, useRect);
           Graphics local21 =  graphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local22 =  bitmap10;
          int x11 =  Math.Round((double) (this.w - 1280) / 2.0) - 80;
          DrawMod.DrawSimple( local21,  local22, x11, 0);
           Graphics local23 =  graphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local24 =  bitmap11;
          int x12 =  Math.Round((double) (this.w - 1280) / 2.0) + 1280;
          DrawMod.DrawSimple( local23,  local24, x12, 0);
        }
      }
      if (this.game.EditObj.SetViewModeExtraNr == 2)
      {
        if (this.w >= 1434)
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1434) / 2.0), 0, 1434, this.h);
          useRect.X = useRect.X + 280 + 154;
          useRect.Width -= 560;
          this.RegimeBottomTab(graphics, useRect);
          useRect.X -= 280;
          useRect.Width = 280;
          this.QuickRegimeTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1434) / 2.0) + 1154, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1434) / 2.0), 0, 1434, this.h);
          useRect.Width = 154;
          this.QuickFlagTab(graphics, useRect);
           Graphics local25 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local26 =  bitmap7;
          int x13 =  Math.Round((double) (this.w - 1434) / 2.0) - 80;
          DrawMod.DrawSimple( local25,  local26, x13, 0);
           Graphics local27 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local28 =  bitmap7;
          int x14 =  Math.Round((double) (this.w - 1434) / 2.0) + 1434;
          DrawMod.DrawSimple( local27,  local28, x14, 0);
        }
        else if (this.w >= 1280)
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0), 0, 1280, this.h);
          useRect.X += 280;
          useRect.Width -= 560;
          this.RegimeBottomTab(graphics, useRect);
          useRect.X -= 280;
          useRect.Width = 280;
          this.QuickRegimeTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0) + 1000, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local29 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local30 =  bitmap7;
          int x15 =  Math.Round((double) (this.w - 1280) / 2.0) - 80;
          DrawMod.DrawSimple( local29,  local30, x15, 0);
           Graphics local31 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local32 =  bitmap7;
          int x16 =  Math.Round((double) (this.w - 1280) / 2.0) + 1280;
          DrawMod.DrawSimple( local31,  local32, x16, 0);
        }
        else
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0), 0, 1280, this.h);
          useRect.X += 280;
          useRect.Width -= 560;
          this.RegimeBottomTab(graphics, useRect);
          useRect.X -= 280;
          useRect.Width = 280;
          this.QuickRegimeTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0) + 1000, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
          useRect.Width = 1280;
           Graphics local33 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local34 =  bitmap7;
          int x17 =  Math.Round((double) (this.w - 1280) / 2.0) - 80;
          DrawMod.DrawSimple( local33,  local34, x17, 0);
           Graphics local35 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local36 =  bitmap7;
          int x18 =  Math.Round((double) (this.w - 1280) / 2.0) + 1280;
          DrawMod.DrawSimple( local35,  local36, x18, 0);
        }
      }
      if (this.game.EditObj.SetViewModeExtraNr == 3)
      {
        if (this.w >= 1536 & this.game.EditObj.maximumInterfaceSpace)
        {
          int num = (this.w - 480) % 160;
          useRect = new Rectangle( Math.Round((double) num / 2.0), 0, this.w - (0 + num), this.h);
          this.AssetBottomTab(graphics, useRect);
           Graphics local37 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local38 =  bitmap7;
          int x19 =  Math.Round((double) num / 2.0) - 80;
          DrawMod.DrawSimple( local37,  local38, x19, 0);
           Graphics local39 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local40 =  bitmap7;
          int x20 = this.w -  Math.Round((double) num / 2.0);
          DrawMod.DrawSimple( local39,  local40, x20, 0);
        }
        else if (this.w >= 1536)
        {
          int num = (this.w - 760) % 160;
          useRect = new Rectangle( Math.Round((double) num / 2.0), 0, this.w - (280 + num), this.h);
          this.AssetBottomTab(graphics, useRect);
          useRect = new Rectangle(this.w - 280 -  Math.Round((double) num / 2.0), 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local41 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local42 =  bitmap7;
          int x21 =  Math.Round((double) num / 2.0) - 80;
          DrawMod.DrawSimple( local41,  local42, x21, 0);
           Graphics local43 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local44 =  bitmap7;
          int x22 = this.w -  Math.Round((double) num / 2.0);
          DrawMod.DrawSimple( local43,  local44, x22, 0);
        }
        else
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0), 0, 1280, this.h);
          this.AssetBottomTab(graphics, useRect);
           Graphics local45 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local46 =  bitmap7;
          int x23 =  Math.Round((double) (this.w - 1280) / 2.0) - 80;
          DrawMod.DrawSimple( local45,  local46, x23, 0);
           Graphics local47 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local48 =  bitmap7;
          int x24 =  Math.Round((double) (this.w - 1280) / 2.0) + 1280;
          DrawMod.DrawSimple( local47,  local48, x24, 0);
        }
      }
      if (this.game.EditObj.SetViewModeExtraNr == 4)
      {
        if (this.w >= 1840)
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1840) / 2.0), 0, 1280, this.h);
          this.ItemBottomTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1840) / 2.0) + 1280, 0, 280, this.h);
          this.QuickRegimeTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1840) / 2.0) + 1280 + 280, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local49 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local50 =  bitmap7;
          int x25 =  Math.Round((double) (this.w - 1840) / 2.0) - 80;
          DrawMod.DrawSimple( local49,  local50, x25, 0);
           Graphics local51 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local52 =  bitmap7;
          int x26 =  Math.Round((double) (this.w - 1840) / 2.0) + 1840;
          DrawMod.DrawSimple( local51,  local52, x26, 0);
        }
        else if (this.w >= 1560)
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1560) / 2.0), 0, 1280, this.h);
          this.ItemBottomTab(graphics, useRect);
          useRect = new Rectangle( Math.Round((double) (this.w - 1560) / 2.0) + 1280, 0, 280, this.h);
          this.QuickHexTab(graphics, useRect);
           Graphics local53 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local54 =  bitmap7;
          int x27 =  Math.Round((double) (this.w - 1560) / 2.0) - 80;
          DrawMod.DrawSimple( local53,  local54, x27, 0);
           Graphics local55 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local56 =  bitmap7;
          int x28 =  Math.Round((double) (this.w - 1560) / 2.0) + 1560;
          DrawMod.DrawSimple( local55,  local56, x28, 0);
        }
        else
        {
          useRect = new Rectangle( Math.Round((double) (this.w - 1280) / 2.0), 0, 1280, this.h);
          this.ItemBottomTab(graphics, useRect);
           Graphics local57 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALLEFT);
           Bitmap local58 =  bitmap7;
          int x29 =  Math.Round((double) (this.w - 1280) / 2.0) - 80;
          DrawMod.DrawSimple( local57,  local58, x29, 0);
           Graphics local59 =  graphics;
          bitmap7 = BitmapStore.GetBitmap(this.game.SE1_BOTTOMORNAMENTALRIGHT);
           Bitmap local60 =  bitmap7;
          int x30 =  Math.Round((double) (this.w - 1280) / 2.0) + 1280;
          DrawMod.DrawSimple( local59,  local60, x30, 0);
        }
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    pub void QuickHexTab(Graphics g, Rectangle useRect)
    {
      libName1: String = "SE_Data";
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 362, 0, 0));
      int x1 = useRect.X;
      int y1 = useRect.Y;
       Graphics local1 =  g;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_QUICKHEXFRAME);
       Bitmap local2 =  bitmap;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1 & this.game.Data.ShrowdOn)
        return;
      data1: DataClass = this.game.Data;
      str1: String = "MiningEase";
       local3: String =  str1;
      libName2: String = libName1;
      int hexLibVarValue1 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data1.FindLibVar( local3, libName2));
      data2: DataClass = this.game.Data;
      str2: String = "MiningType";
       local4: String =  str2;
      libName3: String = libName1;
      int hexLibVarValue2 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data2.FindLibVar( local4, libName3));
      data3: DataClass = this.game.Data;
      str2 = "MiningReserve";
       local5: String =  str2;
      libName4: String = libName1;
      int hexLibVarValue3 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data3.FindLibVar( local5, libName4));
      data4: DataClass = this.game.Data;
      str2 = "Scavenge";
       local6: String =  str2;
      libName5: String = libName1;
      int num1 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data4.FindLibVar( local6, libName5));
      data5: DataClass = this.game.Data;
      str2 = "freeFolk";
       local7: String =  str2;
      libName6: String = libName1;
      this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data5.FindLibVar( local7, libName6));
      data6: DataClass = this.game.Data;
      str2 = "perk";
       local8: String =  str2;
      libName7: String = libName1;
      this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data6.FindLibVar( local8, libName7));
      data7: DataClass = this.game.Data;
      str2 = "miningDiscovery";
       local9: String =  str2;
      libName8: String = libName1;
      int hexLibVarValue4 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data7.FindLibVar( local9, libName8));
      data8: DataClass = this.game.Data;
      str2 = "rain";
       local10: String =  str2;
      libName9: String = libName1;
      int hexLibVarValue5 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data8.FindLibVar( local10, libName9));
      data9: DataClass = this.game.Data;
      str2 = "temperature";
       local11: String =  str2;
      libName10: String = libName1;
      int hexLibVarValue6 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data9.FindLibVar( local11, libName10));
      data10: DataClass = this.game.Data;
      str2 = "hexName";
       local12: String =  str2;
      libName11: String = libName1;
      this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data10.FindLibVar( local12, libName11));
      data11: DataClass = this.game.Data;
      str2 = "artifactType";
       local13: String =  str2;
      libName12: String = libName1;
      int hexLibVarValue7 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data11.FindLibVar( local13, libName12));
      data12: DataClass = this.game.Data;
      str2 = "artifactQty";
       local14: String =  str2;
      libName13: String = libName1;
      int hexLibVarValue8 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data12.FindLibVar( local14, libName13));
      data13: DataClass = this.game.Data;
      str2 = "artifactDiscovered";
       local15: String =  str2;
      libName14: String = libName1;
      int hexLibVarValue9 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data13.FindLibVar( local15, libName14));
      int num2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType, 1)));
      int index1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType, 2)));
      data14: DataClass = this.game.Data;
      str2 = "rad";
       local16: String =  str2;
      libName15: String = libName1;
      int libVar = data14.FindLibVar( local16, libName15);
      int hexLibVarValue10 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(libVar);
      int x3 = 11 + useRect.X;
      int y3 = 6;
      this.DrawVarBox2(g, x3, y3, "Temp", hexLibVarValue6.ToString() + "°c", "Current Temperature of the selected Hex.");
      int x4 = x3 + 68;
      this.DrawVarBox2(g, x4, y3, "Rain", hexLibVarValue5.ToString(), "Millimeters of Rain/Year that have fallen on the selected Hex this Round.");
      int x5 = x4 + 68;
      if (num1 < 0)
        num1 = 0;
      dataText1: String = Math.Round((double) num1 / 1000.0, 1).ToString() + "k";
      if (num1 >= 100000)
        dataText1 = Math.Round((double) num1 / 1000.0, 0).ToString() + "k";
      if (num1 == 0)
        dataText1 = "0";
      this.DrawVarBox2(g, x5, y3, "Scav", dataText1, "Amount of Scavenge Points left in Hex.");
      int num3 = x5 + 68;
      int x6 = 11 + useRect.X;
      int y4 = y3 + 58;
      int integer = Conversions.ToInteger(this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon.ToString());
      dataText2: String = integer.ToString();
      int hidePts = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].HidePts;
      str3: String = "Current Recon Points on the selected Hex." + "\r\n";
      int num4 =  Math.Round((double) this.game.Data.RuleVar[55]);
      str4: String = str3 + "Minimum recon for unit info: " + num4.ToString();
      int num5;
      if (hidePts > 0)
      {
        str5: String = str4;
        num5 = hidePts + num4;
        str6: String = num5.ToString();
        str4 = str5 + " (" + str6 + " for this hex)";
      }
      str7: String = str4 + "." + "\r\n";
      num4 =  Math.Round((double) this.game.Data.RuleVar[56]);
      str8: String = str7 + "Minimum recon for full unit info: " + num4.ToString();
      if (hidePts > 0)
      {
        str9: String = str8;
        num5 = hidePts + num4;
        str10: String = num5.ToString();
        str8 = str9 + " (" + str10 + " for this hex)";
      }
      str11: String = str8 + "." + "\r\n" + "Landscape Hide Points: " + hidePts.ToString() + ".\r\n";
      num5 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_ZocPts(this.game.Data.Turn);
      str12: String = num5.ToString();
      mouseOver1: String = str11 + "Your ZOC points on hex: " + str12 + ".";
      this.DrawVarBox2(g, x6, y4, "Recon", dataText2, mouseOver1);
      int x7 = x6 + 68;
      str13: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetHexStackPts(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected)));
      if (this.game.Data.FOWOn)
      {
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime, this.game.Data.Turn))
          str13 = "?";
        if (this.game.EditObj.UnitSelected > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
          str13 = "?";
      }
      if (Operators.CompareString(str13, "?", false) == 0)
      {
        int num6 = 0;
        int unitCounter = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        for (index1 = 0; index1 <= unitCounter; index1 += 1)
        {
          int unit = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index1];
          num6 += this.game.HandyFunctionsObj.GetStackWithFOW(unit, this.game.Data.Turn);
        }
        if (num6 > 0)
          str13 = num6.ToString();
      }
      this.DrawVarBox2(g, x7, y4, "Stack", str13, "How much stack points are in this hex.\r\nAbove " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[30])) + " points the hex becomes overstacked.");
      int x8 = x7 + 68;
      int num7 = 0;
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index2 = 0; index2 <= regimeCounter; index2 += 1)
      {
        int num8 = 0;
        if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.EditObj.RealTurn, index2) && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_ZocPts(index2) > 0 && this.game.HandyFunctionsObj.VisibleEnemyUnitsInOrAroundHEx(this.game.SelectX, this.game.SelectY, 0, this.game.EditObj.RealTurn))
          num8 =  Math.Round((double) ((float) num8 + this.game.Data.RuleVar[323]));
        if (num8 > num7)
          num7 = num8;
      }
      num5 = num7 + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.Data.Turn);
      dataText3: String = num5.ToString();
      mouseOver2: String = "Current extra AP cost, caused by Penalties, to enter the Hex.\r\nExtra AP cost by enemy ZOC on hex: " + num7.ToString() + " AP\r\n";
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.Data.Turn) > 0)
      {
        str14: String = mouseOver2;
        num5 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.Data.Turn);
        str15: String = num5.ToString();
        mouseOver2 = str14 + "Extra AP cost for captured enemy hex / combat: " + str15 + " AP\r\n";
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStack(this.game.Data.Turn) > 0 | this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackArt(this.game.Data.Turn) > 0)
      {
        string[] strArray1 = new string[6]
        {
          mouseOver2,
          "Regular Combat Residue: ",
          this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStack(this.game.Data.Turn).ToString(),
          " Stack Points.\r\nRegular Combat Residue: ",
          null,
          null
        };
        string[] strArray2 = strArray1;
        num5 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackArt(this.game.Data.Turn);
        str16: String = num5.ToString();
        strArray2[4] = str16;
        strArray1[5] = " Ranged Attack Stack Points.\r\n";
        mouseOver2 = string.Concat(strArray1);
      }
      this.DrawVarBox2(g, x8, y4, "Penalty", dataText3, mouseOver2);
      int x9 = x8 + 68;
      str17: String = hexLibVarValue10.ToString();
      int num9 = 0;
      if (hexLibVarValue10 > 12800)
        num9 = 9;
      else if (hexLibVarValue10 > 6400)
        num9 = 8;
      else if (hexLibVarValue10 > 3200)
        num9 = 7;
      else if (hexLibVarValue10 > 1600)
        num9 = 6;
      else if (hexLibVarValue10 > 800)
        num9 = 5;
      else if (hexLibVarValue10 > 400)
        num9 = 4;
      else if (hexLibVarValue10 > 200)
        num9 = 3;
      else if (hexLibVarValue10 > 100)
        num9 = 2;
      else if (hexLibVarValue10 > 50)
        num9 = 1;
      if (hexLibVarValue10 > 0)
        this.DrawVarBox2(g, x9, y4, "RAD", str17, "Radiation Points on Hex. This is equal to Radiation Hazard Level " + num9.ToString() + ".");
      else
        this.DrawVarBox2(g, x9, y4, "RAD", str17, "No Radiation Points on Hex.");
      num3 = x9 + 68;
      if (integer <= 0)
        return;
      string headerText1;
      int itemId1;
      if (libVar > 0 & hexLibVarValue4 < 1 & hexLibVarValue3 > 0)
      {
        if (hexLibVarValue2 == 1)
        {
          headerText1 = "Fuel";
          itemId1 = 1;
        }
        if (hexLibVarValue2 == 2)
        {
          headerText1 = "Metals";
          itemId1 = 2;
        }
        if (hexLibVarValue2 == 3)
        {
          headerText1 = "Rare metals";
          itemId1 = 3;
        }
        if (hexLibVarValue2 == 4)
        {
          headerText1 = "Radioactives";
          itemId1 = 4;
        }
        if (hexLibVarValue2 == 5)
        {
          headerText1 = "Water";
          itemId1 = 5;
        }
      }
      string headerText2;
      int itemId2;
      if (num2 > 0 & num2 != hexLibVarValue2)
      {
        int num10;
        if (num10 <= hexLibVarValue1 & hexLibVarValue2 > 0)
          str17 += ", ";
        if (num2 == 1)
        {
          headerText2 = "Fuel";
          itemId2 = 1;
        }
        if (num2 == 2)
        {
          headerText2 = "Metals";
          itemId2 = 2;
        }
        if (num2 == 3)
        {
          headerText2 = "Rare metals";
          itemId2 = 3;
        }
        if (num2 == 4)
        {
          headerText2 = "Radioactives";
          itemId2 = 4;
        }
        if (num2 == 5)
        {
          headerText2 = "Water";
          itemId2 = 5;
        }
      }
      string dataText1_1;
      string dataText1_2;
      string dataText2_1;
      string dataText2_2;
      if (hexLibVarValue2 > 0 & hexLibVarValue4 < 1 | num2 > 0)
      {
        if (hexLibVarValue2 > 0 & hexLibVarValue4 < 1)
          dataText1_1 = "Lvl " + hexLibVarValue1.ToString();
        if (num2 > 0)
          dataText1_2 = "Lvl " + index1.ToString();
        str17 = "";
        str18: String = hexLibVarValue3.ToString();
        if (hexLibVarValue3 >= 1000)
          str18 = Strings.Left(str18, str18.Length - 3) + "." + Strings.Right(str18, 3);
        dataText2_1 = "0";
        dataText2_2 = "0";
        if (hexLibVarValue2 > 0 & hexLibVarValue4 < 1)
          dataText2_1 = str18;
        if (num2 > 0)
          dataText2_2 = "Unlimited";
      }
      int x10 = 11 + useRect.X;
      int y5 = 120;
      if (itemId1 > 0)
      {
        int bitmapNr = this.game.Data.EventPicNr[this.game.EventRelatedObj.GetEventPicSlotFor(itemId1, "", "")];
        this.DrawVarBox3(g, x10, y5, bitmapNr, headerText1, dataText1_1, "Ease of mining this " + headerText1 + " Resource.", dataText2_1, "Reserves of " + headerText1 + " left in this Hex.");
        y5 += 32;
      }
      if (itemId2 > 0)
      {
        int bitmapNr = this.game.Data.EventPicNr[this.game.EventRelatedObj.GetEventPicSlotFor(itemId2, "", "")];
        this.DrawVarBox3(g, x10, y5, bitmapNr, headerText2, dataText1_2, "Ease of mining this " + headerText2 + " Resource.", dataText2_2, "Reserves of " + headerText2 + " left in this Hex.");
        y5 += 32;
      }
      if (!(hexLibVarValue9 > 0 & hexLibVarValue7 > 0))
        return;
      int y6 = y5 + 19;
      if (hexLibVarValue7 == 1)
        str17 = "Very Rare";
      if (hexLibVarValue7 == 2)
        str17 = "Rare";
      if (hexLibVarValue7 == 3)
        str17 = "Uncommon";
      if (hexLibVarValue7 == 4)
        str17 = "Common";
      dataText1_3: String = "1:" + hexLibVarValue8.ToString();
      hexLibVarValue1 = this.game.Data.SmallPicNr[this.game.Data.FindSmallPic(hexLibVarValue7 + 157, "SE_Graphics")];
      str19: String = num1.ToString();
      if (num1 >= 1000)
        str19 = Strings.Left(str19, str19.Length - 3) + "." + Strings.Right(str19, 3);
      this.DrawVarBox3(g, x10, y6, hexLibVarValue1, str17, dataText1_3, "Difficulty of extracting the Artifacts. On every " + hexLibVarValue8.ToString() + " Scavenge Points scavenged you'll find 1 Artifact.", str19, "Reserves of " + headerText2 + " Scavenge Points left in this Hex.");
      int num11 = y6 + 32;
    }

    pub void DrawVarBox2(
      Graphics g,
      int x,
      int y,
      string headerText,
      string dataText,
      string mouseOver)
    {
       Graphics local1 =  g;
      Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX2);
       Bitmap local2 =  bitmap;
      int x1 = x;
      int y1 = y;
      DrawMod.DrawSimple( local1,  local2, x1, y1);
      DrawMod.DrawTextColouredConsoleCenter( g, headerText, DrawMod.TGame.MarcFont5, x + 27, y + 5, DrawMod.TGame.seColGray);
      DrawMod.DrawTextColouredConsoleCenter( g, dataText, DrawMod.TGame.MarcFont7, x + 27, y + 26, DrawMod.TGame.seColGray);
      Rectangle trect = new Rectangle(x, y, 54, 42);
      this.AddMouse( trect, "", mouseOver);
    }

    pub void DrawVarBox3(
      Graphics g,
      int x,
      int y,
      int bitmapNr,
      string headerText,
      string dataText1,
      string mouseOver1,
      string dataText2,
      string mouseOver2)
    {
      int num1 = 0;
      int num2 = 0;
       Graphics local1 =  g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX3);
       Bitmap local2 =  bitmap1;
      int x1 = x;
      int y1 = y;
      DrawMod.DrawSimple( local1,  local2, x1, y1);
      if (BitmapStore.GetWidth(bitmapNr) > 32)
      {
        num1 = -14;
        num2 = -3;
      }
       Graphics local3 =  g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(bitmapNr);
       Bitmap local4 =  bitmap2;
      int x2 = x + 2 + num1;
      int y2 = y + 4 + num2;
      DrawMod.DrawSimple( local3,  local4, x2, y2);
      int num3 = 0;
      if (BitmapStore.GetWidth(bitmapNr) > 32)
        num3 += 10;
      DrawMod.DrawTextColouredConsole( g, headerText, DrawMod.TGame.MarcFont7, num3 + x + 26, y + 5, DrawMod.TGame.seColGray);
      DrawMod.DrawTextColouredConsoleCenter( g, dataText1, DrawMod.TGame.MarcFont7, x + 140, y + 5, DrawMod.TGame.seColGray);
      DrawMod.DrawTextColouredConsoleCenter( g, dataText2, DrawMod.TGame.MarcFont7, x + 215, y + 5, DrawMod.TGame.seColGray);
      Rectangle trect1 = new Rectangle(x + 107, y + 3, 65, 20);
      this.AddMouse( trect1, "", mouseOver1);
      trect1 = new Rectangle(x + 179, y + 3, 65, 20);
      Rectangle trect2 = trect1;
      this.AddMouse( trect2, "", mouseOver2);
    }

    pub void DrawVarBox4(
      Graphics g,
      int x,
      int y,
      string headerText,
      string dataText,
      string mouseOver)
    {
       Graphics local1 =  g;
      Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX4);
       Bitmap local2 =  bitmap;
      int x1 = x;
      int y1 = y;
      DrawMod.DrawSimple( local1,  local2, x1, y1);
      DrawMod.DrawTextColouredConsoleCenter( g, headerText, DrawMod.TGame.MarcFont5, x + 14, y + 5, DrawMod.TGame.seColGray);
      if (dataText.Length > 2)
        dataText = Strings.Left(dataText, 2);
      DrawMod.DrawTextColouredConsoleCenter( g, dataText, DrawMod.TGame.MarcFont7, x + 14, y + 23, DrawMod.TGame.seColGray);
      Rectangle trect = new Rectangle(x, y, 27, 47);
      this.AddMouse( trect, "", mouseOver);
    }

    pub void QuickRegimeTab(Graphics g, Rectangle useRect)
    {
      int x1 = useRect.X;
      int y1 = useRect.Y;
       Graphics local1 =  g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_QUICKREGIMEFRAME);
       Bitmap local2 =  bitmap1;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      libName: String = "SE_Data";
      int index1 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1 && this.game.Data.ShrowdOn)
        index1 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastReg(this.game.Data.Turn);
      if (index1 == -1)
        return;
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 275, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 297, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 306, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 310, 0, 0));
      int stringListById8 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 406, 0, 0));
      DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 200, 0, 0));
      int id1 = this.game.Data.RegimeObj[index1].id;
      int num1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteSystem", 2)));
      int num2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "votePop", 2)));
      int num3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteWorker", 2)));
      int num4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteSoldier", 2)));
      int num5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteLeader", 2)));
      int num6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteLast", 2)));
      int num7 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "votePeriod", 2)));
      int index2;
      int num8 =  Math.Round(Conversion.Val((object) this.game.Data.StringListObj[index2].FindRow2(1, 11, 0, id1)));
      int num9 =  Math.Round(Conversion.Val((object) this.game.Data.StringListObj[index2].FindRow2(1, 28, 0, id1)));
      int num10 =  Math.Round(Conversion.Val((object) this.game.Data.StringListObj[index2].FindRow2(1, 29, 0, id1)));
      if (num8 > -1)
        ;
      if (num9 > -1)
        ;
      if (num10 > -1)
        ;
      int id2 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      tstring1: String = this.game.EventRelatedObj.Helper_GetOwnerNameForGuiDisplay(this.game.SelectX, this.game.SelectY);
      bool flag;
      if (Operators.CompareString(Strings.LCase(tstring1), "unclear", false) == 0)
        flag = true;
      if (index1 <= -1)
        tstring1 = "No regime selected";
      DrawMod.DrawTextColouredConsoleCenter( g, tstring1, DrawMod.TGame.MarcFont16, x1 + 140, y1 + 10, DrawMod.TGame.seColWhite);
      int num11;
      int num12;
      if (flag)
      {
        num11 = 0;
        num12 = 2;
        if (!this.game.Data.FOWOn)
          num11 = 9999;
      }
      else if (index1 == this.game.Data.Turn)
      {
        num11 = 9999;
        num12 = 1;
      }
      else if (index1 > -1)
      {
        num12 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 1)));
        num11 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "recon", 3)));
        if (!this.game.Data.FOWOn)
          num11 = 9999;
      }
      Rectangle trect1;
      Rectangle trect2;
      if (index1 != -1 && index1 > -1)
      {
        int num13 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "relation", 3)));
        int num14 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "diprel", 3)));
        int num15 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "diptrade", 3)));
        int num16 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "dipres", 3)));
        int num17 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "dippact", 3)));
        int num18 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(0, id2, 1, id1, 2)));
        int num19 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(0, id2, 1, id1, 3)));
        int id3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "protector", 2)));
        int id4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "master", 2)));
        int regimeById1 = this.game.HandyFunctionsObj.GetRegimeByID(id4);
        int regimeById2 = this.game.HandyFunctionsObj.GetRegimeByID(id3);
        int num20 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id1, 1, id2, 2, "dipClear", 3)));
        int num21 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id1, 1, id2, 2, "aiStoryMode", 3)));
        int num22 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id1, 1, id2, 2, "aiLove", 3)));
        int num23 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id1, 1, id2, 2, "aiHatred", 3)));
        if (index1 != this.game.Data.Turn)
        {
          int x3 = 10 + useRect.X;
          int y3 = 164;
          this.DrawVarBox4(g, x3, y3, "REC", num11.ToString(), "Recon Points on the selected Regime.");
          int x4 = x3 + 33;
          dataText1: String = "-";
          if (num14 > 0)
            dataText1 = num14.ToString();
          this.DrawVarBox4(g, x4, y3, "COM", dataText1, "Communication Level.");
          int x5 = x4 + 33;
          dataText2: String = "-";
          if (num15 > 0)
            dataText2 = num15.ToString();
          this.DrawVarBox4(g, x5, y3, "TRA", dataText2, "Trade Deal Level.");
          int x6 = x5 + 33;
          dataText3: String = "-";
          if (num16 > 0)
            dataText3 = num16.ToString();
          this.DrawVarBox4(g, x6, y3, "RES", dataText3, "Research Pact Level.");
          int x7 = x6 + 33;
          dataText4: String = "-";
          if (num17 > 0)
            dataText4 = num17.ToString();
          this.DrawVarBox4(g, x7, y3, "MIL", dataText4, "Military Pact Level.");
          int x8 = x7 + 33;
          dataText5: String = "-";
          if (num18 > 0)
            dataText5 = num18.ToString();
          this.DrawVarBox4(g, x8, y3, "IMP", dataText5, "Import Tariff you have set for Traders buying from the selected Regime.");
          int x9 = x8 + 33;
          dataText6: String = "-";
          if (num19 > 0)
            dataText6 = num19.ToString();
          this.DrawVarBox4(g, x9, y3, "EXP", dataText6, "Export Tariff you have set for Traders selling to the selected Regime.");
          int num24 = x9 + 33;
        }
        int x10 = useRect.X;
        int num25 = 0;
        string str1;
        int num26;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[index1] == 1)
        {
          str1 = "PEACE";
          num26 = 1;
          if (num21 == 1)
            str1 = "ALLIES";
          if (num21 == 2)
            str1 = "FRIENDS";
          if (num21 == 3)
          {
            str1 = "COLD";
            num26 = 3;
          }
          if (num21 == 4)
          {
            str1 = "BLACKMAIL";
            num26 = 3;
          }
          if (num21 == 5)
          {
            str1 = "HOSTILE";
            num26 = 2;
          }
          if (!this.game.Data.RegimeObj[index1].AI)
          {
            str1 = "PEACE";
            num26 = 1;
          }
        }
        else
        {
          switch (num12)
          {
            case 2:
              if (num20 == 1)
              {
                str1 = "WAR";
                num26 = 2;
                break;
              }
              str1 = "UNCLEAR";
              num26 = 2;
              break;
            case 4:
              str1 = "UNCLEAR";
              num26 = 2;
              break;
            default:
              str1 = "WAR";
              num26 = 2;
              break;
          }
        }
         Graphics local3 =  g;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SE1_QUICKREGIMEPAPERFRAME);
         Bitmap local4 =  bitmap2;
        int x11 = x10 + 2;
        int y4 = num25 + 39;
        DrawMod.DrawSimple( local3,  local4, x11, y4);
        int num27 = this.game.Data.Turn != index1 ? (this.game.Data.RegimeObj[index1].AI ? (num11 < 2 ? -1 : this.game.EventRelatedObj.Helper_GetCharacterId(id1, 11, id1, 0)) : -3) : -2;
        if (num12 == 4)
          num27 = -1;
        if (num11 < 1)
          num27 = -1;
        str2: String = "";
        tstring2: String = "";
        string data1;
        if (num27 > 0)
        {
          int idValue =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num27, 12)));
          int index3;
          data1 = this.game.Data.StringListObj[index3].GetData(0, idValue, 1);
          this.game.Data.StringListObj[stringListById2].GetData(0, num27, 2);
          data2: String = this.game.Data.StringListObj[stringListById2].GetData(0, num27, 3);
          data3: String = this.game.Data.StringListObj[stringListById2].GetData(0, num27, 4);
          str3: String = this.game.Data.StringListObj[stringListById1].GetData(0, id1, 10);
          if (str3.Length >= 2)
            str3 = Strings.Left(str3, 1).ToUpper() + Strings.Mid(str3, 2);
          tstring2 = str3.ToUpper();
          str2 = data2 + " " + data3;
        }
        else
        {
          switch (num27)
          {
            case -3:
              str2 = "A human opponent is the";
              tstring2 = this.game.Data.StringListObj[stringListById1].GetData(0, id1, 10).ToUpper();
              break;
            case -2:
              str2 = "You are the";
              tstring2 = this.game.Data.StringListObj[stringListById1].GetData(0, id1, 10).ToUpper();
              break;
            case -1:
              tstring2 = "Leadership Unknown";
              str2 = "";
              break;
          }
        }
        if (num27 > 0)
        {
           Graphics local5 =  g;
          Bitmap bitmap3 = this.game.CustomBitmapObj.DrawLeaderPortrait(num27, 71, 100);
           Bitmap local6 =  bitmap3;
          int x12 = x10 + 10;
          int y5 = num25 + 46;
          DrawMod.DrawSimple( local5,  local6, x12, y5);
          trect1 = new Rectangle(x10 + 10, num25 + 46, 71, 100);
          trect2 = trect1;
          this.AddMouse( trect2, "Leader of Regime", "A portrait of " + str2 + ".");
        }
        else
        {
          DrawMod.DrawBlock( g, x10 + 10, num25 + 46, 70, 100, 0, 0, 0, 64);
          DrawMod.DrawTextColouredMarcCenter( g, "?", this.game.introFont2, x10 + 45, num25 + 70, Color.FromArgb( byte.MaxValue, 78, 78, 78));
          trect2 = new Rectangle(x10 + 10, num25 + 46, 71, 100);
          trect1 = trect2;
          this.AddMouse( trect1, "", "No portrait available.");
        }
        if (Operators.CompareString(str2, "", false) == 0)
        {
          DrawMod.DrawTextColouredConsoleCenter( g, tstring2, DrawMod.TGame.se1TypeWriterSmall, x10 + 176, num25 + 55, DrawMod.TGame.seColTW);
        }
        else
        {
          DrawMod.DrawTextColouredConsoleCenter( g, str2, DrawMod.TGame.se1TypeWriterSmall, x10 + 176, num25 + 48, DrawMod.TGame.seColTW);
          DrawMod.DrawTextColouredConsoleCenter( g, tstring2, DrawMod.TGame.se1TypeWriterSmall, x10 + 176, num25 + 61, DrawMod.TGame.seColTW);
        }
        str4: String = "";
        str5: String = "";
        int idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 2)));
        int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue1, 1)));
        str6: String = this.game.Data.StringListObj[stringListById7].GetData(0, idValue2, 1);
        if (str6.Length >= 2)
          str6 = Strings.Left(str6, 1).ToUpper() + Strings.Mid(str6, 2);
        if (idValue2 < 1)
          str6 = "";
        if (num11 < 2)
          str6 = "";
        int idValue3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 13)));
        str7: String = this.game.Data.StringListObj[stringListById8].GetData(1, idValue3, 3);
        if (num11 < 6)
          str7 = "";
        if (idValue3 < 1)
          str7 = "";
        if (!this.game.Data.RegimeObj[index1].AI)
          str7 = "";
        if (str6.Length > 20)
          str6 = Strings.Left(str6, 20) + ".";
        if (str6.Length > 0)
          str4 = str6;
        if (Operators.CompareString(str4, "", false) == 0)
          str4 = "Culture Unknown";
        if (id4 > 0)
          str5 = this.game.Data.RegimeObj[regimeById1].Name + " Vassal";
        else if (id3 > 0)
        {
          str5 = this.game.Data.RegimeObj[regimeById2].Name + " Protec.";
        }
        else
        {
          switch (num12)
          {
            case 1:
              str5 = "Major Regime";
              break;
            case 2:
              str5 = "Minor Regime";
              break;
          }
        }
        upper: String = str5.ToUpper();
        if (this.game.Data.Turn != index1 & num12 <= 2)
        {
          if (str4.Length > 0 | upper.Length > 0)
          {
            DrawMod.DrawTextColouredConsoleCenter( g, str4, DrawMod.TGame.se1TypeWriterSmall, x10 + 96 + 83, num25 + 111, DrawMod.TGame.seColTW);
            DrawMod.DrawTextColouredConsoleCenter( g, upper, DrawMod.TGame.se1TypeWriterSmall, x10 + 96 + 83, num25 + 125, DrawMod.TGame.seColTW);
          }
          else if (upper.Length <= 0)
            ;
        }
        Color color;
        if (num26 == 1)
          color = Color.FromArgb( byte.MaxValue, 0, 150, 0);
        if (num26 == 2)
          color = Color.FromArgb( byte.MaxValue, 150, 0, 0);
        if (num26 == 3)
          color = Color.FromArgb( byte.MaxValue, 0, 0, 150);
        if (index1 == this.game.Data.Turn)
        {
          str8: String = "YOUR REGIME";
          SizeF sizeF = g.MeasureString(str8, DrawMod.TGame.MarcFont16);
          int x13 =  Math.Round((double) ((float) useRect.X + (float) ((174.0 - (double) sizeF.Width) / 2.0))) + 89;
          int num28 = 82;
          DrawMod.DrawBlock( g, x13 - 4, num28 + 2,  Math.Round((double) (sizeF.Width + 8f)), 22, 150, 150, 150,  byte.MaxValue);
          DrawMod.DrawTextColouredConsole( g, str8, DrawMod.TGame.MarcFont16, x13, num28 + 4, DrawMod.TGame.seColWhite);
        }
        else
        {
          data1 = Conversions.ToString(Operators.CompareString(upper, "", false) == 0);
          SizeF sizeF1 = g.MeasureString(num13.ToString(), DrawMod.TGame.MarcFont16);
          SizeF sizeF2 = g.MeasureString(str1.ToString(), DrawMod.TGame.MarcFont16);
          int num29 = 0;
          if (num11 > 0 & index1 != this.game.Data.Turn & num12 <= 2)
            num29 = 69;
          int x14 =  Math.Round((double) ((float) useRect.X + (float) ((189.0 - ((double) sizeF1.Width + 10.0 + (double) sizeF2.Width + (double) num29)) / 2.0))) + 89;
          int num30 = 82;
          DrawMod.DrawBlock( g, x14 - 4, num30 + 2,  Math.Round((double) (sizeF1.Width + 8f)), 22, 0, 0, 0,  byte.MaxValue);
          DrawMod.DrawTextColouredConsole( g, num13.ToString(), DrawMod.TGame.MarcFont16, x14, num30 + 4, DrawMod.TGame.seColWhite);
          DrawMod.DrawBlock( g,  Math.Round((double) ((float) (x14 + 6) + sizeF1.Width)), num30 + 2,  Math.Round((double) (sizeF2.Width + 8f)), 22,  color.R,  color.G,  color.B,  color.A);
          DrawMod.DrawTextColouredConsole( g, str1.ToString(), DrawMod.TGame.MarcFont16,  Math.Round((double) x14 + (double) sizeF1.Width + 10.0), num30 + 4, DrawMod.TGame.seColWhite);
          if (num11 > 0 & index1 != this.game.Data.Turn & num12 <= 2)
          {
            int num31 =  Math.Round((double) ((float) ((double) (x14 + 6) + (double) sizeF1.Width + 9.0) + sizeF2.Width));
            this += 1.regButtonCounter;
            int[] regButton = this.regButton;
            int regButtonCounter = this.regButtonCounter;
            let mut tsubpart: SubPartClass =  new TextButtonPartClass("Strat", 60, "Play a Stratagem on this Regime.",  this.OwnBitmap, num31, num30 + 0, theight: 30, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            int num32 = this.AddSubPart( tsubpart, num31, num30 + 0, 60, 30, 1);
            regButton[regButtonCounter] = num32;
            this.regButtonData[this.regButtonCounter] = 202;
            this.tempRegId = id1;
            this.tempRegType = num12;
          }
        }
      }
      if (num12 != 4)
        return;
      int x15 = useRect.X;
      int y6 = useRect.Y;
       Graphics local7 =  g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
       Bitmap local8 =  bitmap4;
      trect2 = new Rectangle(0, 0, 371, 212);
      Rectangle srcrect = trect2;
      trect1 = new Rectangle(x15 + 0, y6 + 39, 275, 173);
      Rectangle destrect = trect1;
      DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
    }

    pub void QuickFlagTab(Graphics g, Rectangle useRect)
    {
      int x1 = useRect.X;
      int y1 = useRect.Y;
       Graphics local1 =  g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_FLAGPANEL);
       Bitmap local2 =  bitmap1;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      int index = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1 & this.game.Data.ShrowdOn)
        index = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastReg(this.game.Data.Turn);
      if (index == -1)
        return;
      int num1 = x1 - 3;
      int num2 = y1 + 0;
      int num3 = 154;
      int num4 = 210;
      int bannerSpriteNr = this.game.Data.RegimeObj[index].BannerSpriteNr;
       Graphics local3 =  g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(bannerSpriteNr);
       Bitmap local4 =  bitmap2;
      int x3 = num1;
      int y3 = num2;
      int w1 = num3;
      int h1 = num4;
      double r1 = (double) ((float) this.game.Data.RegimeObj[index].Red / (float) byte.MaxValue);
      double g1 = (double) ((float) this.game.Data.RegimeObj[index].Green / (float) byte.MaxValue);
      double b1 = (double) ((float) this.game.Data.RegimeObj[index].Blue / (float) byte.MaxValue);
      DrawMod.DrawScaledColorized2( local3,  local4, x3, y3, w1, h1, 124, 210, (float) r1, (float) g1, (float) b1, 1f);
      int bannerSpriteNr2 = this.game.Data.RegimeObj[index].BannerSpriteNr2;
      Bitmap bitmap3;
      if (bannerSpriteNr2 > 0)
      {
         Graphics local5 =  g;
        bitmap3 = BitmapStore.GetBitmap(bannerSpriteNr2);
         Bitmap local6 =  bitmap3;
        int x4 = num1;
        int y4 = num2;
        int w2 = num3;
        int h2 = num4;
        double r2 = (double) ((float) this.game.Data.RegimeObj[index].Red2 / (float) byte.MaxValue);
        double g2 = (double) ((float) this.game.Data.RegimeObj[index].Green2 / (float) byte.MaxValue);
        double b2 = (double) ((float) this.game.Data.RegimeObj[index].Blue2 / (float) byte.MaxValue);
        DrawMod.DrawScaledColorized2( local5,  local6, x4, y4, w2, h2, 124, 210, (float) r2, (float) g2, (float) b2, 1f);
      }
      int symbolSpriteNr = this.game.Data.RegimeObj[index].SymbolSpriteNr;
      if (symbolSpriteNr <= 0)
        return;
       Graphics local7 =  g;
      bitmap3 = BitmapStore.GetBitmap(symbolSpriteNr);
       Bitmap local8 =  bitmap3;
      int x5 = num1 + 44;
      int y5 = num2 + 45;
      double r3 = (double) ((float) this.game.Data.RegimeObj[index].Red3 / (float) byte.MaxValue) - 1.0;
      double g3 = (double) ((float) this.game.Data.RegimeObj[index].Green3 / (float) byte.MaxValue) - 1.0;
      double b3 = (double) ((float) this.game.Data.RegimeObj[index].Blue3 / (float) byte.MaxValue) - 1.0;
      DrawMod.Draw( local7,  local8, x5, y5, (float) r3, (float) g3, (float) b3, 0.95f);
    }

    pub void DrawItemBox(
      Graphics g,
      int tx,
      int ty,
      bool closed,
      int bitmapNr,
      string texty,
      Color tcol,
      string texty2,
      Color tcol2,
      string tmouseOverTitle,
      string tmouseOver)
    {
      if (closed)
      {
         Graphics local1 =  g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_ITEMBOXCLOSED);
         Bitmap local2 =  bitmap;
        int x = tx;
        int y = ty;
        DrawMod.DrawSimple( local1,  local2, x, y);
      }
      else
      {
        if (tcol == DrawMod.TGame.seColYellow)
        {
           Graphics local3 =  g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_ITEMBOXPROBLEM);
           Bitmap local4 =  bitmap;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple( local3,  local4, x, y);
        }
        else
        {
           Graphics local5 =  g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_ITEMBOX);
           Bitmap local6 =  bitmap;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple( local5,  local6, x, y);
        }
        if (bitmapNr > 0)
        {
           Graphics local7 =  g;
          Bitmap bitmap = BitmapStore.GetBitmap(bitmapNr);
           Bitmap local8 =  bitmap;
          int x = tx + 2;
          int y = ty + 6;
          DrawMod.DrawSimple( local7,  local8, x, y);
          DrawMod.DrawTextColouredConsole( g, texty, this.game.MarcFont16, tx + 31, ty + 4, tcol);
        }
        else
          DrawMod.DrawTextColouredConsoleCenter( g, texty, this.game.MarcFont16, tx + 38, ty + 4, tcol);
        Rectangle trect = new Rectangle(tx, ty, 74, 28);
        this.AddMouse( trect, tmouseOverTitle, tmouseOver);
      }
    }

    pub void ItemBottomTab(Graphics g, Rectangle useRect)
    {
      libName: String = "SE_Data";
      int x1 = useRect.X;
      int y1 = useRect.Y;
       Graphics local1 =  g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ITEMFRAME);
       Bitmap local2 =  bitmap1;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      int num1 = useRect.X + 16;
      int num2 = useRect.Y + 5;
      int num3 = 421;
      int num4 = 82;
      int num5 = 32;
      bool[,,] flagArray = new bool[3, 5, 5];
      int num6 = 0;
      string str1;
      do
      {
        int num7 = 0;
        do
        {
          Bitmap bitmap2;
          if (num7 == 1 | num7 == 2)
          {
             Graphics local3 =  g;
            bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ITEMBACKGROUND);
             Bitmap local4 =  bitmap2;
            int x3 = num1 + num4 * num7 + num3 * num6;
            int y3 = num2;
            DrawMod.Draw( local3,  local4, x3, y3, 0.05f, 0.0f, 0.0f, 1f);
          }
          else
          {
            switch (num7)
            {
              case 0:
                 Graphics local5 =  g;
                bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ITEMBACKGROUND);
                 Bitmap local6 =  bitmap2;
                int x4 = num1 + num4 * num7 + num3 * num6;
                int y4 = num2;
                DrawMod.Draw( local5,  local6, x4, y4, 0.05f, 0.05f, 0.0f, 1f);
                break;
              case 3:
                 Graphics local7 =  g;
                bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ITEMBACKGROUND);
                 Bitmap local8 =  bitmap2;
                int x5 = num1 + num4 * num7 + num3 * num6;
                int y5 = num2;
                DrawMod.Draw( local7,  local8, x5, y5, 0.0f, 0.1f, 0.0f, 1f);
                break;
              default:
                 Graphics local9 =  g;
                bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ITEMBACKGROUND);
                 Bitmap local10 =  bitmap2;
                int x6 = num1 + num4 * num7 + num3 * num6;
                int y6 = num2;
                DrawMod.DrawSimple( local9,  local10, x6, y6);
                break;
            }
          }
          if (num7 == 0)
            str1 = "PROD";
          if (num7 == 1)
            str1 = "IN";
          if (num7 == 2)
            str1 = "CONS";
          if (num7 == 3)
            str1 = "OUT";
          if (num7 == 4)
            str1 = "STOCK";
          DrawMod.DrawTextColouredConsoleCenterEmbossed( g, str1, this.game.MarcFont16, num1 + num3 * num6 + num4 * num7 +  Math.Round((double) num4 / 2.0), num2 + 10, Color.FromArgb(215, 70, 70, 70));
          int num8 = 0;
          do
          {
            num8 += 1;
          }
          while (num8 <= 4);
          num7 += 1;
        }
        while (num7 <= 4);
        num6 += 1;
      }
      while (num6 <= 2);
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 160, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 361, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 381, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 166, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 204, 0, 0));
      int integer = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, libName, "Zones"));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 1));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 2));
      int id =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 6)));
      this.game.Data.StringListObj[stringListById1].GetData(0, integer, 7);
      int num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer, 8)));
      int index1 = this.game.EventRelatedObj.CheckRegimeSlot(num9, 0, 0, 0);
      int index2 = -1;
      if (id > 0)
        index2 = this.game.HandyFunctionsObj.GetLocationByID(id);
      int num10 = -1;
      if (index2 > -1)
        num10 = this.game.Data.LocObj[index2].HQ;
      int num11 = -1;
      if (integer > 0 & index1 > -1)
        num11 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[index1].id, 10, integer, 0);
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 275, 0, 0));
      int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 288, 0, 0));
      int num12 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0))].GetData(0, num9, 1)));
      int num13 = -1;
      int num14 = 0;
      int num15 = 0;
      if (integer > 0 & num9 > 0)
      {
        num13 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer, 2, "recon", 3)));
        num14 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer, 2, "spies", 3)));
        num15 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, num9, 2, "recon", 3)));
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastLT(this.game.Data.Turn) == -1)
      {
        num13 = -1;
        num15 = 0;
      }
      if (index1 == this.game.Data.Turn)
        num13 = 9999;
      int num16 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon;
      if (!this.game.Data.FOWOn)
        num16 = 9999;
      if (num16 > 0 & num13 == -1)
        num13 = 0;
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1 & this.game.Data.FOWOn && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastLT(this.game.Data.Turn) == -1 || num12 > 1 || index2 < 0)
        return;
      if (index1 == this.game.Data.Turn | !this.game.Data.FOWOn)
      {
        num13 = 9999;
        num15 = 9999;
      }
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      SimpleStringList simpleStringList = SimpleStringList::new();
      int tdata1_1 = 0;
      int tdata2_1 = 0;
      simpleList1.Add(7, 0, tdata1_1, tdata2_1);
      simpleList2.Add(19, 0, CheckExistence: false);
      simpleStringList.Add("Food", 1);
      int tdata2_2 = tdata2_1 + 1;
      simpleList1.Add(5, 0, tdata1_1, tdata2_2);
      simpleList2.Add(20, 0, CheckExistence: false);
      simpleStringList.Add("Water", 1);
      int tdata2_3 = tdata2_2 + 1;
      simpleList1.Add(1, 0, tdata1_1, tdata2_3);
      simpleList2.Add(18, 0, CheckExistence: false);
      simpleStringList.Add("Fuel", 1);
      int tdata2_4 = tdata2_3 + 1;
      simpleList1.Add(10, 0, tdata1_1, tdata2_4);
      simpleList2.Add(17, 0, CheckExistence: false);
      simpleStringList.Add("Ammo", 1);
      int tdata2_5 = tdata2_4 + 1;
      simpleList1.Add(15, 0, tdata1_1, tdata2_5);
      simpleList2.Add(16, 0, CheckExistence: false);
      simpleStringList.Add("Energy", 1);
      int tdata1_2 = tdata1_1 + 1;
      int tdata2_6 = 0;
      simpleList1.Add(2, 0, tdata1_2, tdata2_6);
      simpleList2.Add(2, 0, CheckExistence: false);
      simpleStringList.Add("Metals", 1);
      int tdata2_7 = tdata2_6 + 1;
      simpleList1.Add(3, 0, tdata1_2, tdata2_7);
      simpleList2.Add(3, 0, CheckExistence: false);
      simpleStringList.Add("Rare Metals", 1);
      int tdata2_8 = tdata2_7 + 1;
      simpleList1.Add(13, 0, tdata1_2, tdata2_8);
      simpleList2.Add(13, 0, CheckExistence: false);
      simpleStringList.Add("Machines", 1);
      int tdata2_9 = tdata2_8 + 1;
      simpleList1.Add(14, 0, tdata1_2, tdata2_9);
      simpleList2.Add(14, 0, CheckExistence: false);
      simpleStringList.Add("Hi-Tech Parts", 1);
      int tdata2_10 = tdata2_9 + 1;
      simpleList1.Add(8, 0, tdata1_2, tdata2_10);
      simpleList2.Add(22, 0, CheckExistence: false);
      simpleStringList.Add("Industrial Points", 1);
      int num17 = tdata1_2 + 1;
      int tdata2_11 = 0;
      simpleList1.Add(9, 0, num17, tdata2_11);
      simpleList2.Add(9, 0, CheckExistence: false);
      simpleStringList.Add("Recruits", 1);
      int tdata2_12 = tdata2_11 + 1;
      simpleList1.Add(12, 0, num17, tdata2_12);
      simpleList2.Add(12, 0, CheckExistence: false);
      simpleStringList.Add("Colonists", 1);
      int tdata2_13 = tdata2_12 + 1;
      simpleList1.Add(4, 0, num17, tdata2_13);
      simpleList2.Add(4, 0, CheckExistence: false);
      simpleStringList.Add("Radioactives", 1);
      int counter = simpleList1.Counter;
      for (int index3 = 0; index3 <= counter; index3 += 1)
      {
        str2: String = simpleStringList.Id[index3];
        int num18 = simpleList1.Id[index3];
        int num19 = simpleList2.Id[index3];
        if (num18 == num19)
          num19 = 0;
        int num20 = 0;
        int num21 = 0;
        int num22 = 0;
        int num23 = 0;
        int num24 = 0;
        int num25 = 0;
        int num26 = 0;
        int num27 = 0;
        int num28 = 0;
        int num29 = 0;
        int num30 = 0;
        int num31 = 0;
        int num32 = 0;
        int num33 = 0;
        int logCounter1 = this.game.Data.LocObj[index2].LogCounter;
        for (int index4 = 0; index4 <= logCounter1; index4 += 1)
        {
          if (this.game.Data.LocObj[index2].LogData1[index4] == num18)
          {
            if (this.game.Data.LocObj[index2].LogType[index4] == 101)
              num20 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 104)
              num21 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 103)
              num23 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 102)
              num24 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 121)
              num22 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 201)
              num25 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 204)
              num26 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 203)
              num27 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 202)
              num28 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 401)
              num30 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 402)
            {
              num29 += this.game.Data.LocObj[index2].LogData3[index4];
              num23 += this.game.Data.LocObj[index2].LogData3[index4];
            }
            if (this.game.Data.LocObj[index2].LogType[index4] == 403)
              num31 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 404)
              num32 += this.game.Data.LocObj[index2].LogData3[index4];
            if (this.game.Data.LocObj[index2].LogType[index4] == 405)
              num33 += this.game.Data.LocObj[index2].LogData3[index4];
          }
        }
        if (num18 == 9 | num18 == 12)
        {
          num20 *= 100;
          num21 *= 100;
          num22 *= 100;
          num23 *= 100;
          num24 *= 100;
          num25 *= 100;
          num26 *= 100;
          num27 *= 100;
          num28 *= 100;
          num31 *= 100;
          num33 *= 100;
        }
        if (num13 < 10)
        {
          num21 = 0;
          num26 = 0;
        }
        if (num13 < 10)
          num22 = 0;
        if (num13 < 15)
        {
          num23 = 0;
          num27 = 0;
          num30 = 0;
          num29 = 0;
        }
        if (num13 < 20)
        {
          num20 = 0;
          num25 = 0;
        }
        if (num13 < 25)
        {
          num24 = 0;
          num28 = 0;
        }
        int num34;
        double num35;
        int num36;
        if (num20 > 0 | num25 > 0)
        {
          num34 = num20;
          str1 = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str1 = num35.ToString() + "k";
          }
          num36 = this.game.EventRelatedObj.GetEventPicSlotFor(num18, "", "");
          int num37 = useRect.X + 16;
          int num38 = useRect.Y + 5;
          int num39 = num37 + (simpleList1.Data1[index3] * num3 + 1 * num4);
          int num40 = num38 + simpleList1.Data2[index3] * num5;
          num17 = num39 + 2;
          int ty = num40 + 32;
          tmouseOverTitle: String = simpleStringList.Id[index3] + " sent from SHQ to Zone";
          tmouseOver: String = num25.ToString() + " requested by Zone.\r\n" + num20.ToString() + " sent by SHQ.";
          if (num20 > 0)
            str1 = "+" + str1;
          if (num20 < num25)
          {
            this.DrawItemBox(g, num17, ty, false, -1, str1, this.game.seColYellow, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 1] = true;
          }
          else
          {
            this.DrawItemBox(g, num17, ty, false, -1, str1, this.game.seColGray, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 1] = true;
          }
        }
        int num41;
        int tx1 = num17 + num41;
        Left: String = "";
        int num42;
        if (num21 > 0 | num26 > 0 | num22 > 0)
        {
          num34 = num21 + num22;
          str3: String = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str3 = num35.ToString() + "k";
          }
          if (num21 > 0)
            str3 = "+" + str3;
          int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num18, "", "");
          int num43 = useRect.X + 16;
          int num44 = useRect.Y + 5;
          int num45 = num43 + (simpleList1.Data1[index3] * num3 + 0 * num4);
          int num46 = num44 + simpleList1.Data2[index3] * num5;
          tx1 = num45 + 2;
          int ty = num46 + 32;
          tmouseOverTitle: String = simpleStringList.Id[index3] + " produced in Zone";
          str4: String = num26.ToString() + " could optimally be produced.\r\n" + num21.ToString() + " was actually produced by Zone.";
          if (num22 > 0)
            str4 = str4 + "\r\n" + num22.ToString() + " was delivered by Zone Militia.";
          texty: String = str3;
          str1 = "";
          if (num26 > 0)
          {
            num34 = 0;
            num42 = 0;
            int length = this.game.Data.StringListObj[stringListById3].Length;
            for (int index5 = 0; index5 <= length; index5 += 1)
            {
              int idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 0]));
              if (idValue1 < 1000000)
              {
                int num47 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue1, 0)));
                int num48 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 1]));
                int num49 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 3]));
                if (num47 == integer & num48 == 2 & num49 == num18)
                {
                  int num50 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 2]));
                  int num51 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 4]));
                  int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue1, 1)));
                  str5: String = this.game.Data.StringListObj[stringListById5].GetData(0, idValue2, 1);
                  int nr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue2, 2)));
                  int num52 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue1, 11)));
                  if (num50 == 14)
                  {
                    if (Operators.CompareString(str1, "", false) == 0)
                      str1 = "Assets that contributed:\r\n";
                    if (nr > 0)
                      str5 = str5 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                    str1 = str1 + num52.ToString() + "% prod, " + str5 + " produced " + num51.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
                  }
                }
              }
              else if (idValue1 >= 1000000)
              {
                int num53 = integer;
                int num54 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 1]));
                int num55 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 3]));
                if (num53 == integer & num54 == 2 & num55 == num18)
                {
                  data: String = this.game.Data.StringListObj[stringListById4].GetData(0, idValue1 - 1000000, 1);
                  int num56 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 2]));
                  int num57 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 4]));
                  int num58 = this.game.Data.StringListObj[stringListById3].Width < 5 ? integer :  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index5, 5]));
                  if (num56 == 14 & num58 == integer)
                  {
                    if (Operators.CompareString(Left, "", false) == 0)
                      Left = "Hex Perks that contributed:\r\n";
                    if (num18 == 9 | num18 == 12)
                      num57 *= 100;
                    Left = Left + data + " produced " + num57.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
                  }
                }
              }
            }
          }
          if (Left.Length > 0)
            str1 += Left;
          if (num31 > 0)
            str1 = str1 + "Recruitment in zone contributed " + num31.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
          if (num32 > 0)
            str1 = str1 + "Service Tax contributed " + num32.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
          if (num33 > 0)
            str1 = str1 + "Free Production/Collection contributed " + num33.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
          if (Operators.CompareString(str1, "", false) == 0)
            str1 = "No assets contributed to this production";
          tmouseOver: String = str4 + "\r\n" + str1;
          if (num21 < num26)
          {
            this.DrawItemBox(g, tx1, ty, false, this.game.Data.EventPicNr[eventPicSlotFor], texty, this.game.seColYellow, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 0] = true;
          }
          else
          {
            this.DrawItemBox(g, tx1, ty, false, this.game.Data.EventPicNr[eventPicSlotFor], texty, this.game.seColWhite, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 0] = true;
          }
        }
        int tx2 = tx1 + num41;
        if (num23 > num27)
          num27 = num23;
        string str6;
        if (num23 > 0 | num27 > 0)
        {
          num34 = num23;
          str7: String = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str7 = num35.ToString() + "k";
          }
          if (num23 > 0)
            str7 = "-" + str7;
          num36 = this.game.EventRelatedObj.GetEventPicSlotFor(num18, "", "");
          int num59 = useRect.X + 16;
          int num60 = useRect.Y + 5;
          int num61 = num59 + (simpleList1.Data1[index3] * num3 + 2 * num4);
          int num62 = num60 + simpleList1.Data2[index3] * num5;
          tx2 = num61 + 2;
          int ty = num62 + 32;
          tmouseOverTitle: String = simpleStringList.Id[index3] + " consumed in Zone";
          str8: String = num27.ToString() + " could optimally be consumed.\r\n" + num23.ToString() + " was actually available and consumed by Zone.";
          texty: String = str7;
          str6 = "";
          str1 = "";
          if (num27 > 0)
          {
            str1 = "Assets that consumed:\r\n";
            num34 = 0;
            num42 = 0;
            int length = this.game.Data.StringListObj[stringListById3].Length;
            for (int index6 = 0; index6 <= length; index6 += 1)
            {
              int idValue3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index6, 0]));
              int num63 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue3, 0)));
              int num64 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index6, 1]));
              int num65 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index6, 3]));
              if (num63 == integer & num64 == 2 & num65 == num18)
              {
                int num66 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index6, 2]));
                int num67 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index6, 4]));
                int idValue4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue3, 1)));
                str9: String = this.game.Data.StringListObj[stringListById5].GetData(0, idValue4, 1);
                int nr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue4, 2)));
                int num68 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue3, 11)));
                if (num66 == 2 | num66 == 4 | num66 == 6)
                {
                  if (nr > 0)
                    str9 = str9 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                  str1 = str1 + num68.ToString() + "% prod, " + str9 + " consumed " + num67.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
                }
              }
            }
          }
          if (num30 > 0)
            str1 = str1 + "Workers consumed " + num30.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
          if (num29 > 0)
            str1 = str1 + "Population was given " + num29.ToString() + " " + this.game.Data.StringListObj[stringListById6].GetData(0, num18, 1) + "\r\n";
          if (Operators.CompareString(str1, "", false) == 0)
            str1 = "No assets contributed to this consumption";
          tmouseOver: String = str8 + "\r\n" + str1;
          if (num23 < num27)
          {
            this.DrawItemBox(g, tx2, ty, false, -1, texty, this.game.seColYellow, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 2] = true;
          }
          else
          {
            this.DrawItemBox(g, tx2, ty, false, -1, texty, this.game.seColWhite, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 2] = true;
          }
        }
        if (num24 > 0 | num28 > 0)
        {
          num34 = num24;
          str1 = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str1 = num35.ToString() + "k";
          }
          int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num18, "", "");
          int num69 = useRect.X + 16;
          int num70 = useRect.Y + 5;
          int num71 = num69 + (simpleList1.Data1[index3] * num3 + 3 * num4);
          int num72 = num70 + simpleList1.Data2[index3] * num5;
          tx2 = num71 + 2;
          int ty = num72 + 32;
          tmouseOverTitle: String = simpleStringList.Id[index3] + " delivered from Zone to SHQ";
          tmouseOver: String = num28.ToString() + " could optimally be delivered to SHQ.\r\n" + num24.ToString() + " was actually delivered by Zone.";
          if (num24 < num28)
          {
            this.DrawItemBox(g, tx2, ty, false, this.game.Data.EventPicNr[eventPicSlotFor], str1, this.game.seColYellow, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 3] = true;
          }
          else
          {
            this.DrawItemBox(g, tx2, ty, false, this.game.Data.EventPicNr[eventPicSlotFor], str1, this.game.seColGray, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 3] = true;
          }
        }
        num20 = 0;
        num21 = 0;
        num23 = 0;
        num24 = 0;
        int num73 = 0;
        int num74 = 0;
        if (Information.IsNothing((object) this.game.Data.LocObj[index2].items))
          this.game.Data.LocObj[index2].items = ItemList::new();
        int weight = this.game.Data.LocObj[index2].items.list.FindWeight(num18);
        int num75 = 0;
        int num76 = 0;
        int num77 = 0;
        if (this.game.Data.Turn == index1)
        {
          int logCounter2 = this.game.Data.LocObj[index2].LogCounter;
          for (int index7 = 0; index7 <= logCounter2; index7 += 1)
          {
            if (num19 > 0 && this.game.Data.LocObj[index2].LogData1[index7] == num19)
            {
              if (this.game.Data.LocObj[index2].LogType[index7] == 104)
                num21 += this.game.Data.LocObj[index2].LogData3[index7];
              if (this.game.Data.LocObj[index2].LogType[index7] == 102)
                num24 += this.game.Data.LocObj[index2].LogData3[index7];
              if (this.game.Data.LocObj[index2].LogType[index7] == 204)
                num73 += this.game.Data.LocObj[index2].LogData3[index7];
              if (this.game.Data.LocObj[index2].LogType[index7] == 202)
                num74 += this.game.Data.LocObj[index2].LogData3[index7];
            }
            if (this.game.Data.LocObj[index2].LogData1[index7] == num18)
            {
              if (this.game.Data.LocObj[index2].LogType[index7] == 301)
                num75 += this.game.Data.LocObj[index2].LogData3[index7];
              if (this.game.Data.LocObj[index2].LogType[index7] == 304)
                num76 += this.game.Data.LocObj[index2].LogData3[index7];
              if (this.game.Data.LocObj[index2].LogType[index7] == 305)
                num77 += this.game.Data.LocObj[index2].LogData3[index7];
            }
          }
          if (num75 > 0)
          {
            num34 = num75;
            str6 = num34.ToString();
            if (num34 > 999)
            {
              num35 = Math.Round((double) num34 / 1000.0, 1);
              str6 = num35.ToString() + "k ";
            }
            str1 = "Items lost due to exceeding the maximum stockage capacity of the zone";
          }
        }
        int num78 = tx2 + num41;
        if (this.game.Data.Turn == index1 && num21 > 0 | num73 > 0)
        {
          num34 = num21;
          str10: String = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str10 = num35.ToString() + "k";
          }
          num36 = this.game.Data.FindEventPic("", 23, "SE_Present");
          if (num21 > 0)
            str6 = "+" + str10;
          if (num21 < num73)
            ;
          str1 = "Stockage capcacity in this zone";
        }
        int num79 = num78 + num41;
        if (this.game.Data.Turn == index1 && num24 > 0 | num74 > 0)
        {
          num34 = num24;
          str6 = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str6 = num35.ToString() + "k";
          }
          num36 = this.game.Data.FindEventPic("", 22, "SE_Present");
          if (((num24 < num74 ? 1 : 0) & 0) == 0)
            ;
          str1 = "Stockage capacity of zone used by SHQ";
        }
        int tx3 = num79 + num41;
        bool flag1 = false;
        int index8 = 0;
        do
        {
          if (flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], index8])
            flag1 = true;
          index8 += 1;
        }
        while (index8 <= 3);
        if (weight > 0 | flag1 | num75 > 0)
        {
          num34 = weight;
          if (num18 == 9 | num18 == 12)
            num34 *= 100;
          str1 = num34.ToString();
          if (num34 > 999)
          {
            num35 = Math.Round((double) num34 / 1000.0, 1);
            str1 = num35.ToString() + "k";
          }
          int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num18, "", "");
          int num80 = useRect.X + 16;
          int num81 = useRect.Y + 5;
          int num82 = num80 + (simpleList1.Data1[index3] * num3 + 4 * num4);
          int num83 = num81 + simpleList1.Data2[index3] * num5;
          tx3 = num82 + 2;
          int ty = num83 + 32;
          tmouseOverTitle: String = simpleStringList.Id[index3] + " Zone Stocks";
          tmouseOver: String = "This Zone has " + weight.ToString() + " " + simpleStringList.Id[index3] + " in reserve Stock.";
          if (num75 > 0)
            tmouseOver = tmouseOver + "\r\nLost " + (num75 - num76).ToString() + " items due to exceeding maximum stockage in Zone.";
          if (num76 > 0)
            tmouseOver = tmouseOver + "\r\nSold " + num76.ToString() + " items for " + num77.ToString() + " Credits due to exceeding maximum stockage in Zone.";
          if (num21 > 0)
            tmouseOver = tmouseOver + "\r\nZone provided " + num21.ToString() + " " + simpleStringList.Id[index3] + " Stockage.";
          if (num24 > 0)
            tmouseOver = tmouseOver + "\r\nOf these the Zone provided " + num24.ToString() + " " + simpleStringList.Id[index3] + " Stockage to its SHQ.";
          Color tcol = this.game.seColWhite;
          if (num75 > 0)
            tcol = this.game.seColYellow;
          if (weight > 0)
            this.DrawItemBox(g, tx3, ty, false, this.game.Data.EventPicNr[eventPicSlotFor], str1, tcol, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
          else
            this.DrawItemBox(g, tx3, ty, false, -1, str1, tcol, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
          flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], 4] = true;
        }
        num17 = tx3 + num41;
        bool flag2 = false;
        int index9 = 0;
        do
        {
          if (flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], index9])
            flag2 = true;
          index9 += 1;
        }
        while (index9 <= 4);
        int index10 = 0;
        do
        {
          if (!flagArray[simpleList1.Data1[index3], simpleList1.Data2[index3], index10])
          {
            int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num18, "", "");
            int num84 = useRect.X + 16;
            int num85 = useRect.Y + 5;
            int num86 = num84 + (simpleList1.Data1[index3] * num3 + index10 * num4);
            int num87 = num85 + simpleList1.Data2[index3] * num5;
            num17 = num86 + 2;
            int ty = num87 + 32;
            tmouseOverTitle: String = "";
            tmouseOver: String = "";
            if (!flag2)
              this.DrawItemBox(g, num17, ty, true, this.game.Data.EventPicNr[eventPicSlotFor], str1, this.game.seColGray, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            else if (index10 == 1 | index10 == 2 | index10 == 4)
              this.DrawItemBox(g, num17, ty, false, -1, "0", this.game.seColGray, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
            else
              this.DrawItemBox(g, num17, ty, false, this.game.Data.EventPicNr[eventPicSlotFor], "0", this.game.seColGray, "", this.game.seColGray, tmouseOverTitle, tmouseOver);
          }
          index10 += 1;
        }
        while (index10 <= 4);
      }
    }

    pub void RegimeBottomTab(Graphics g, Rectangle useRect)
    {
      libName: String = "SE_Data";
      int x1 = useRect.X;
      int y1 = useRect.Y;
       Graphics local1 =  g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_REGIMEFRAME);
       Bitmap local2 =  bitmap1;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 204, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 288, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 275, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 297, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 306, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 310, 0, 0));
      int stringListById7 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 406, 0, 0));
      int stringListById8 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 200, 0, 0));
      int stringListById9 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 202, 0, 0));
      int stringListById10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 388, 0, 0));
      int stringListById11 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 258, 0, 0));
      int regnr = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1 && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastReg(this.game.Data.Turn) == -1)
        regnr = -1;
      if (regnr < 0)
        return;
      int id1 = this.game.Data.RegimeObj[regnr].id;
      int num1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteSystem", 2)));
      int num2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "votePop", 2)));
      int num3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteWorker", 2)));
      int num4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteSoldier", 2)));
      int num5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteLeader", 2)));
      int num6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "voteLast", 2)));
      int num7 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "votePeriod", 2)));
      int num8 =  Math.Round(Conversion.Val((object) this.game.Data.StringListObj[stringListById10].FindRow2(1, 11, 0, id1)));
      int num9 =  Math.Round(Conversion.Val((object) this.game.Data.StringListObj[stringListById10].FindRow2(1, 28, 0, id1)));
      int num10 =  Math.Round(Conversion.Val((object) this.game.Data.StringListObj[stringListById10].FindRow2(1, 29, 0, id1)));
      bool flag1;
      if (num8 > -1)
        flag1 = true;
      bool flag2;
      if (num9 > -1)
        flag2 = true;
      bool flag3;
      if (num10 > -1)
        flag3 = true;
      int id2 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      nameForGuiDisplay: String = this.game.EventRelatedObj.Helper_GetOwnerNameForGuiDisplay(this.game.SelectX, this.game.SelectY);
      string str1;
      bool flag4;
      if (Operators.CompareString(Strings.LCase(str1), "unclear", false) == 0)
        flag4 = true;
      int num11;
      int num12;
      if (flag4)
      {
        num11 = 0;
        num12 = 2;
        if (!this.game.Data.FOWOn)
          num11 = 9999;
      }
      else if (regnr == this.game.Data.Turn)
      {
        num11 = 9999;
        num12 = 1;
      }
      else if (regnr > -1)
      {
        num12 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 1)));
        num11 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData3(0, id2, 1, id1, 2, "recon", 3)));
        if (!this.game.Data.FOWOn)
          num11 = 9999;
      }
      int num13;
      Rectangle rectangle1;
      Rectangle rectangle2;
      int idValue1;
      int x3;
      int num14;
      Bitmap bitmap2;
      if (!flag4 & num12 == 1)
      {
        str1 = "";
        idValue2_1: String = "";
        StringListClass stringListClass = this.game.EventRelatedObj.Helper_Regime_Profile_Formatted(regnr);
        num13 = 5 + useRect.X;
        int num15 = 32;
        int length = stringListClass.Length;
        for (int index = 0; index <= length; index += 1)
        {
          int num16 = 35 + useRect.X;
          str2: String = stringListClass.Data[index, 1];
          if (num11 < 5)
            str2 = "Unkn." + stringListClass.Data[index, 0];
          if (Strings.InStr(str2, "Mixed") > 0)
            str2 = str2 + " " + stringListClass.Data[index, 0];
          if (index == 0)
            str2 = "Politics Profile";
          if (index == 1)
            str2 = "Society Profile";
          if (index == 2)
            str2 = "Psychology Profile";
          DrawMod.DrawTextColouredConsole( g, str2, DrawMod.TGame.se1TypeWriterSmall, num16 - 5, num15 - 2, DrawMod.TGame.seColTW);
          string idValue2_2;
          string idValue2_3;
          if (index == 0)
          {
            idValue2_2 = "democracy";
            idValue2_1 = "autocracy";
            idValue2_3 = "meritocracy";
          }
          if (index == 1)
          {
            idValue2_2 = "enforcement";
            idValue2_1 = "commerce";
            idValue2_3 = "government";
          }
          if (index == 2)
          {
            idValue2_2 = "fist";
            idValue2_1 = "mind";
            idValue2_3 = "heart";
          }
          int num17 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, idValue2_2, 2)));
          int num18 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, idValue2_1, 2)));
          int num19 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, idValue2_3, 2)));
          int x4 = num16 + 143;
          int num20 = 0;
          do
          {
            string idValue2;
            int num21;
            if (num20 == 0)
            {
              idValue2 = idValue2_2;
              num21 = num17;
            }
            if (num20 == 1)
            {
              idValue2 = idValue2_1;
              num21 = num18;
            }
            if (num20 == 2)
            {
              idValue2 = idValue2_3;
              num21 = num19;
            }
            data: String = this.game.Data.StringListObj[stringListById11].GetData(0, idValue2, 4);
            int eventPic = this.game.Data.FindEventPic( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, idValue2, 5))), data);
            int num22 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, idValue2, 6)));
             Graphics local3 =  g;
            Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic]);
             Bitmap local4 =  bitmap3;
            rectangle1 = new Rectangle(num22 * 32, 0, 32, 32);
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(x4, num15 - 4, 20, 20);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2( local3,  local4, srcrect, destrect);
            tstring: String = num21.ToString();
            if (num11 < 5)
              tstring = "?";
            DrawMod.DrawTextColouredConsole( g, tstring, DrawMod.TGame.se1TypeWriterSmall, x4 + 22, num15 - 2, DrawMod.TGame.seColTW);
            x4 += 46;
            num20 += 1;
          }
          while (num20 <= 2);
          num15 += 24;
        }
        int num23 = 35 + useRect.X;
        DrawMod.DrawTextColouredConsole( g, "Tech Level", DrawMod.TGame.se1TypeWriterSmall, num23 - 5, num15 - 2, DrawMod.TGame.seColTW);
        idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "techLevel", 2)));
        int num24 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, id1, 1, "techLevelFraction", 2)));
        tstring1: String = idValue1.ToString();
        if (num24 > 99)
          num24 = 99;
        if (num24 < 10)
          tstring1 = tstring1 + ".0" + num24.ToString();
        if (num24 >= 10)
          tstring1 = tstring1 + "." + num24.ToString();
        if (num11 < 3)
          tstring1 = "?";
        int x5 = num23 + 143;
        DrawMod.DrawTextColouredConsole( g, tstring1, DrawMod.TGame.se1TypeWriterSmall, x5, num15 - 2, DrawMod.TGame.seColTW);
        int num25 = num15 + 24;
        int num26 = 35 + useRect.X;
        DrawMod.DrawTextColouredConsole( g, "Culture Type", DrawMod.TGame.se1TypeWriterSmall, num26 - 5, num25 - 2, DrawMod.TGame.seColTW);
        idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 2)));
        int idValue3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue1, 1)));
        tstring2: String = this.game.Data.StringListObj[stringListById6].GetData(0, idValue3, 1);
        if (num11 < 2)
          tstring2 = "?";
        x3 = num26 + 143;
        DrawMod.DrawTextColouredConsole( g, tstring2, DrawMod.TGame.se1TypeWriterSmall, x3, num25 - 2, DrawMod.TGame.seColTW);
        if (regnr != this.game.Data.Turn)
        {
          int num27 = num25 + 24;
          int num28 = 35 + useRect.X;
          DrawMod.DrawTextColouredConsole( g, "Leading Faction", DrawMod.TGame.se1TypeWriterSmall, num28 - 5, num27 - 2, DrawMod.TGame.seColTW);
          int idValue4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 13)));
          tstring3: String = this.game.Data.StringListObj[stringListById7].GetData(1, idValue4, 3);
          if (num11 < 6)
            tstring3 = "?";
          if (idValue4 < 1)
            tstring3 = "?";
          if (!this.game.Data.RegimeObj[regnr].AI)
            tstring3 = "?";
          x3 = num28 + 143;
          DrawMod.DrawTextColouredConsole( g, tstring3, DrawMod.TGame.se1TypeWriterSmall, x3, num27 - 2, DrawMod.TGame.seColTW);
        }
      }
      else
      {
        x3 = useRect.X + 0;
        int y3 = 0;
        int num29 = 371;
        num14 = 212;
         Graphics local5 =  g;
        bitmap2 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
         Bitmap local6 =  bitmap2;
        rectangle1 = new Rectangle(0, 0, 100, 212);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(x3, y3, 100, 212);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect1, destrect1);
         Graphics local7 =  g;
        bitmap2 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
         Bitmap local8 =  bitmap2;
        rectangle1 = new Rectangle(100, 0, 171, 212);
        Rectangle srcrect2 = rectangle1;
        rectangle2 = new Rectangle(x3 + 100, y3, num29 - 200, 212);
        Rectangle destrect2 = rectangle2;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect2, destrect2);
         Graphics local9 =  g;
        bitmap2 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
         Bitmap local10 =  bitmap2;
        rectangle1 = new Rectangle(271, 0, 100, 212);
        Rectangle srcrect3 = rectangle1;
        rectangle2 = new Rectangle(x3 + num29 - 100, y3, 100, 212);
        Rectangle destrect3 = rectangle2;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect3, destrect3);
      }
      if (num12 == 1)
      {
        str3: String = "";
        num13 = x3 + 220;
        idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 2)));
        str1 = str3 + "POLITICS\r\n";
        str4: String = "Unclear Political System";
        if (flag1)
          str4 = "Parliament";
        if (flag2)
          str4 = "Senate";
        if (flag3)
          str4 = "Politburo";
        tstring: String = nameForGuiDisplay + " " + str4;
        if (num11 < 3)
          tstring = "Unknown Political System";
        DrawMod.DrawTextColouredConsoleCenter( g, tstring, DrawMod.TGame.se1TypeWriterMedium, useRect.X + 810 - 280, 37, DrawMod.TGame.seColTW);
        int x6 = 658 + useRect.X - 280;
        int y4 = 81;
        if (num11 < 4 || this.game.Data.StringListObj[stringListById1].Width < 13)
          return;
        SimpleList simpleList = SimpleList::new();
        int num30 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, id1, 13)));
        int length1 = this.game.Data.StringListObj[stringListById8].Length;
        for (int index = 0; index <= length1; index += 1)
        {
          if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].Data[index, 3])) == id1)
          {
            int tid =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].Data[index, 0]));
            int num31 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].Data[index, 12]));
            int tweight =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].Data[index, 11]));
            if (num31 == num30)
              tweight += 1000;
            simpleList.Add(tid, tweight);
          }
        }
        simpleList.ReverseSort();
        int counter = simpleList.Counter;
        for (int index1 = 0; index1 <= counter; index1 += 1)
        {
          if (index1 <= 2)
          {
            int idValue5 = simpleList.Id[index1];
            int idValue6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 12)));
            int num32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 11)));
            int num33 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 13)));
            data1: String = this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 4);
            data2: String = this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 10);
            int num34 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 6)));
            str5: String = "";
            ttext: String = "";
            DrawMod.DrawTextColouredConsole( g, data1, DrawMod.TGame.se1TypeWriterSmall, x6, y4, DrawMod.TGame.seColTW);
            DrawMod.DrawTextColouredConsole( g, num32.ToString() + "%", DrawMod.TGame.se1TypeWriterSmall, x6 + 200, y4, DrawMod.TGame.seColTW);
            string ttitle;
            if (num11 >= 6)
            {
              if (num33 > 0)
                DrawMod.DrawTextColouredConsole( g, num33.ToString(), DrawMod.TGame.se1TypeWriterSmall, x6 + 263, y4, DrawMod.TGame.seColTW);
              else
                DrawMod.DrawTextColouredConsole( g, "-", DrawMod.TGame.se1TypeWriterSmall, x6 + 263, y4, DrawMod.TGame.seColTW);
              if (idValue6 > 0)
              {
                data3: String = this.game.Data.StringListObj[stringListById7].GetData(1, idValue6, 3);
                ttext = ttext + "This is a faction composed of " + data3 + ".\r\n\r\n";
                if (num33 > 0)
                  ttext = ttext + "This faction is enjoying " + num33.ToString() + " points of Foreign Support,\r\n\r\n";
              }
              if (num34 > 0)
                ttext = ttext + "Faction leader is " + this.game.Data.StringListObj[stringListById2].GetData(0, num34, 3) + " " + this.game.Data.StringListObj[stringListById2].GetData(0, num34, 4) + " (" + this.game.EventRelatedObj.Helper_GetCharacterJobTitle(num34) + ").\r\n\r\n";
              ttext += "FACTION PROFILE";
              int length2 = this.game.Data.StringListObj[stringListById9].Length;
              for (int index2 = 0; index2 <= length2; index2 += 1)
              {
                if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById9].Data[index2, 0])) == idValue5)
                {
                  int num35 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById9].Data[index2, 2]));
                  ttext = ttext + "\r\n" + this.game.Data.StringListObj[stringListById9].Data[index2, 1] + " ";
                  if (num35 == 1)
                    ttext += "---";
                  if (num35 == 2)
                    ttext += "--";
                  if (num35 == 3)
                    ttext += "-";
                  if (num35 == 4)
                    ttext += "+";
                  if (num35 == 5)
                    ttext += "++";
                  if (num35 == 6)
                    ttext += "+++";
                }
              }
              ttitle = "Faction: " + data1 + " (" + data2 + ")";
            }
            else
              ttitle = str5 + "You need 6 Recon Points on this Regime to get more information on Factions.";
            rectangle1 = new Rectangle(x6, y4 - 8, 320, 24);
            Rectangle trect = rectangle1;
            this.AddMouse( trect, ttitle, ttext);
            y4 += 24;
          }
        }
      }
      else
      {
        int x7 = useRect.X + 627 - 280;
        int y5 = 0;
        int num36 = 367;
        num14 = 212;
         Graphics local11 =  g;
        bitmap2 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
         Bitmap local12 =  bitmap2;
        rectangle1 = new Rectangle(0, 0, 100, 212);
        Rectangle srcrect4 = rectangle1;
        rectangle2 = new Rectangle(x7, y5, 100, 212);
        Rectangle destrect4 = rectangle2;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect4, destrect4);
         Graphics local13 =  g;
        bitmap2 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
         Bitmap local14 =  bitmap2;
        rectangle1 = new Rectangle(100, 0, 171, 212);
        Rectangle srcrect5 = rectangle1;
        rectangle2 = new Rectangle(x7 + 100, y5, num36 - 200, 212);
        Rectangle destrect5 = rectangle2;
        DrawMod.DrawSimplePart2( local13,  local14, srcrect5, destrect5);
         Graphics local15 =  g;
        bitmap2 = BitmapStore.GetBitmap(this.game.SE1_CLOSEDPANEL);
         Bitmap local16 =  bitmap2;
        rectangle1 = new Rectangle(271, 0, 100, 212);
        Rectangle srcrect6 = rectangle1;
        rectangle2 = new Rectangle(x7 + num36 - 100, y5, 100, 212);
        Rectangle destrect6 = rectangle2;
        DrawMod.DrawSimplePart2( local15,  local16, srcrect6, destrect6);
      }
    }

    pub void AssetBottomTab(Graphics g, Rectangle useRect)
    {
      libName1: String = "SE_Data";
      int x1 = useRect.X;
      int y1 = useRect.Y;
      if (useRect.Width > 1280)
      {
         Graphics local1 =  g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_ASSETFRAME);
         Bitmap local2 =  bitmap;
        Rectangle rectangle1 = new Rectangle(0, 0, 980, 222);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(x1, y1, 980, 222);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
        int x2 = x1 + 980;
        int width;
        for (int index = useRect.Width - 980; index > 300; index -= width)
        {
          width = index - 300;
          if (width > 300)
            width = 300;
           Graphics local3 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ASSETFRAME);
           Bitmap local4 =  bitmap;
          rectangle2 = new Rectangle(690, 0, width, 222);
          Rectangle srcrect2 = rectangle2;
          rectangle1 = new Rectangle(x2, y1, width, 222);
          Rectangle destrect2 = rectangle1;
          DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
          x2 += width;
        }
         Graphics local5 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_ASSETFRAME);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(980, 0, 300, 222);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(x2, y1, 300, 222);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      else
      {
         Graphics local7 =  g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_ASSETFRAME);
         Bitmap local8 =  bitmap;
        int x3 = x1;
        int y2 = y1;
        DrawMod.DrawSimple( local7,  local8, x3, y2);
      }
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 500, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 382, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 381, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 160, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 148, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 241, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 144, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 149, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 166, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 196, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 204, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 160, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 148, 0, 0));
      int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 144, 0, 0));
      int stringListById9 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 149, 0, 0));
      stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 166, 0, 0));
      stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 196, 0, 0));
      stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 204, 0, 0));
      int stringListById10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 210, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 361, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 362, 0, 0));
      int stringListById11 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 150, 0, 0));
      int integer1 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, libName1, "Zones"));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById5].GetData(0, integer1, 1));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById5].GetData(0, integer1, 2));
      int id =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, integer1, 6)));
      int index1 = -1;
      int num1 = -1;
      int num2 = -1;
      if (id > 0)
      {
        index1 = this.game.HandyFunctionsObj.GetLocationByID(id);
        if (index1 > -1)
        {
          num1 = this.game.Data.LocObj[index1].X;
          num2 = this.game.Data.LocObj[index1].Y;
        }
        else
          id = 0;
      }
      this.game.Data.StringListObj[stringListById5].GetData(0, integer1, 7);
      int num3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, integer1, 8)));
      int index2 = this.game.EventRelatedObj.CheckRegimeSlot(num3, 0, 0, 0);
      int index3 = -1;
      int num4 = -1;
      int stringListById12 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 275, 0, 0));
      int stringListById13 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 288, 0, 0));
      int stringListById14 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 143, 0, 0));
      int num5 = -1;
      int num6 = 0;
      int num7 = 0;
      if (integer1 > 0 & num3 > 0)
      {
        num5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer1, 2, "recon", 3)));
        num6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer1, 2, "spies", 3)));
        num7 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, num3, 2, "recon", 3)));
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastLT(this.game.Data.Turn) == -1)
      {
        num5 = -1;
        num7 = 0;
      }
      if (index2 == this.game.Data.Turn)
        num5 = 9999;
      if (!this.game.Data.FOWOn)
      {
        num5 = 9999;
        num7 = 9999;
      }
      bool flag1 = false;
      if (this.game.Data.Turn == index2)
        flag1 = true;
      if (!this.game.Data.FOWOn & !this.game.Data.ShrowdOn)
        flag1 = true;
      bool flag2 = false;
      if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById14].GetData(0, num3, 1))) > 1)
        flag2 = true;
      int num8 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon;
      if (!this.game.Data.FOWOn)
        num8 = 9999;
      if (num8 > 0 & num5 == -1)
        num5 = 0;
      int num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById10].GetData2(0, num3, 1, "credits", 2)));
      int num10 = this.game.EditObj.se1_SelectAssetButton;
      if (num10 < 0)
        num10 = 0;
      int num11;
      int x4;
      int y3;
      int integer2;
      if (num10 > 0 & num10 < 9000000)
      {
        num11 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 0)));
        x4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 3)));
        y3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 4)));
        if (x4 > -1)
        {
          integer2 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x4, y3, libName1, "Zones"));
          if (!(x4 == this.game.SelectX & y3 == this.game.SelectY) & integer1 == integer2 && !this.calledFromNew)
          {
            this.game.SelectX = x4;
            this.game.SelectY = y3;
            this.game.Data.TempVar[2] = this.game.SelectX;
            this.game.Data.TempVar[3] = this.game.SelectY;
            this.game.HandyFunctionsObj.SetcornerXY2();
            this.game.EditObj.TempCoordList = CoordList::new();
          }
        }
        else
        {
          num10 = -1;
          this.game.EditObj.se1_SelectAssetButton = -1;
          x4 = this.game.SelectX;
          y3 = this.game.SelectY;
        }
      }
      else if (num10 >= 9000000 & num10 < 15000000)
      {
        int num12 = num10 - 9000000;
        int num13 =  Math.Round(Math.Floor((double) num12 / 1000.0));
        int num14 = num12 - num13 * 1000;
        x4 = num13;
        y3 = num14;
        integer2 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x4, y3, libName1, "Zones"));
        num11 = integer2;
        if (!(x4 == this.game.SelectX & y3 == this.game.SelectY) & integer1 == integer2)
        {
          this.game.SelectX = x4;
          this.game.SelectY = y3;
          this.game.Data.TempVar[2] = this.game.SelectX;
          this.game.Data.TempVar[3] = this.game.SelectY;
          this.game.HandyFunctionsObj.SetcornerXY2();
        }
      }
      else if (num10 >= 15000000 & num10 < 16000000)
      {
        int num15 = num10 - 15000000;
        int num16 =  Math.Round(Math.Floor((double) num15 / 1000.0));
        int num17 = num15 - num16 * 1000;
        x4 = num16;
        y3 = num17;
        integer2 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x4, y3, libName1, "Zones"));
        num11 = integer2;
        if (!(x4 == this.game.SelectX & y3 == this.game.SelectY) & integer1 == integer2)
        {
          this.game.SelectX = x4;
          this.game.SelectY = y3;
          this.game.Data.TempVar[2] = this.game.SelectX;
          this.game.Data.TempVar[3] = this.game.SelectY;
          this.game.HandyFunctionsObj.SetcornerXY2();
        }
      }
      else
      {
        x4 = this.game.SelectX;
        y3 = this.game.SelectY;
      }
      this.orderfeedbackString = "";
      int num18;
      int num19;
      if (this.AssetOrderNumber > 0)
      {
        if (this.AssetOrderNumber == 32)
        {
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 5, -1);
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 15, 0);
        }
        if (this.AssetOrderNumber == 31)
        {
          int setValue =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0,  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 1))), 11)));
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 5, setValue);
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 15, 0);
        }
        if (this.AssetOrderNumber == 33)
        {
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 5, -2);
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 15, 0);
        }
        if (this.AssetOrderNumber >= 2000 & this.AssetOrderNumber <= 2100)
        {
          int setValue = this.AssetOrderNumber - 2000;
          if (setValue == 100)
            setValue = 0;
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 15, setValue);
        }
        int num20;
        if (this.AssetOrderNumber == 25)
        {
          int idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 1)));
          int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue1, 14)));
          int num21 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue1, 2)));
          int num22 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue1, 5)));
          int num23 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue1, 13)));
          int setValue1 = num21 <= 1 ? -1 :  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData2(14, idValue2, 2, num21 - 1, 0)));
          int num24 = idValue1;
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int turn = this.game.Data.Turn;
          int index4 = turn;
          regimeClassArray[index4].ResPts = regimeObj[turn].ResPts - num21;
          num20 = 0;
          if (num22 < 1)
          {
            int num25 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData2(0, integer1, 1, "popHapiness", 2)));
            int num26 = num25;
            int num27 = num25 * 1;
            int num28 = 0;
            int length = this.game.Data.StringListObj[stringListById7].Length;
            for (int index5 = 0; index5 <= length; index5 += 1)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index5, 0])) == integer1)
              {
                int idValue3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index5, 1]));
                if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue3, 5))) == 0)
                  num28 += Math.Max(1,  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue3, 2))));
              }
            }
            if (num28 > 0)
              num27 =  Math.Round((double) (num27 * num21) / (double) num28);
            int num29 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById10].GetData2(0, num3, 1, "government", 2)));
            int num30 = num27 -  Math.Round((double) (num27 * num29) / 100.0);
            if (num30 >  Math.Round((double) num25 * 0.7))
              num30 =  Math.Round((double) num25 * 0.7);
            int setValue2 = num25 - num30;
            num20 = num26 - setValue2;
            this.game.Data.StringListObj[stringListById6].SetData2(0, integer1, 1, "popHapiness", 2, setValue2, true);
          }
          SimpleList SL = SimpleList::new();
          int num31 = 0;
          int length1 = this.game.Data.StringListObj[stringListById11].Length;
          for (int index6 = 0; index6 <= length1; index6 += 1)
          {
            if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].Data[index6, 0])) == num24)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].Data[index6, 1])) == 2)
                SL.AddWeight( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].Data[index6, 2])),  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].Data[index6, 3])));
              else if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].Data[index6, 1])) == 3 && Operators.CompareString(this.game.Data.StringListObj[stringListById11].Data[index6, 2].ToLower(), "credits", false) == 0)
                num31 +=  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].Data[index6, 3]));
            }
          }
          int num32 = 0;
          int counter1 = SL.Counter;
          for (int index7 = 0; index7 <= counter1; index7 += 1)
          {
            SL.Weight[index7] =  Math.Round((double) (SL.Weight[index7] * num23) / 3.0);
            if (SL.Id[index7] == 8)
              SL.Weight[index7] = 0;
            if (SL.Weight[index7] > 0)
              num32 += 1;
          }
          if (num22 == 1)
          {
            if (num32 > 0)
            {
              int num33 = 0;
              int counter2 = SL.Counter;
              for (int index8 = 0; index8 <= counter2; index8 += 1)
              {
                if (SL.Weight[index8] > 0)
                {
                  num33 += 1;
                  data: String = this.game.Data.StringListObj[stringListById9].GetData(0, SL.Id[index8], 1);
                  if (num32 == num33 & num32 > 1)
                    this.orderfeedbackString += " and ";
                  else if (this.orderfeedbackString.Length > 0)
                    this.orderfeedbackString += ", ";
                  this.orderfeedbackString = this.orderfeedbackString + SL.Weight[index8].ToString() + " " + data;
                }
              }
              SL.removeWeight0orLower();
              this.game.Data.LocObj[index1].items.list.AddWeight( SL);
              this.orderfeedbackString = "Disbanding resulted in recovery of: " + this.orderfeedbackString + ".";
            }
          }
          else
          {
            if (num31 < 1)
              num31 = 500;
            int num34 =  Math.Round((double) num31 / 3.0);
            int setValue3 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById6].GetData2(0, integer1, 1, "popCredits", 2)) + num34;
            this.game.Data.StringListObj[stringListById6].SetData2(0, integer1, 1, "popCredits", 2, setValue3, true);
            this.orderfeedbackString = this.orderfeedbackString + "Disbanding resulted in recovery of " + num34.ToString() + " Private Credits.";
          }
          if (setValue1 == -1)
          {
            int row = this.game.Data.StringListObj[stringListById7].FindRow(9, num10);
            int num35 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 3)));
            int num36 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 4)));
            this.game.EventRelatedObj.Helper_SetLocationTypeForHex(num35, num36, num35, num36);
            this.game.Data.StringListObj[stringListById7].RemoveRow(row);
            if (this.orderfeedbackString.Length > 0)
              this.orderfeedbackString += " ";
            this.orderfeedbackString += "Asset was completely disbanded and removed.";
          }
          else
          {
            int num37 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 3)));
            int num38 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 4)));
            this.game.Data.StringListObj[stringListById7].SetData(9, num10, 1, setValue1);
            this.game.Data.StringListObj[stringListById7].SetData(9, num10, 5, setValue1);
            this.game.EventRelatedObj.Helper_SetLocationTypeForHex(num37, num38, num37, num38);
            if (this.orderfeedbackString.Length > 0)
              this.orderfeedbackString += " ";
            this.orderfeedbackString += "We have disbanded one level of the Asset.";
          }
          if (num20 > 0)
            this.orderfeedbackString = this.orderfeedbackString + " Population happiness dropped with " + num20.ToString() + " points.";
        }
        if (this.AssetOrderNumber == 21)
        {
          int idValue4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 1)));
          int num39 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue4, 25)));
          int setValue4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, num39, 11)));
          int num40 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, num39, 2)));
          int num41 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData3(0, idValue4, 1, 3, 2, "credits", 3)));
          int setValue5 = num9 - num41;
          int num42 =  Math.Round((double) num41 / 2.0);
          this.game.Data.StringListObj[stringListById10].SetData2(0, num3, 1, "credits", 2, setValue5);
          int setValue6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData2(0, integer1, 1, "popCredits", 2))) + num42;
          int num43 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData2(0, integer1, 1, "popHapiness", 2)));
          num20 = num43;
          int num44 = num43 * 1;
          int num45 = 0;
          int length = this.game.Data.StringListObj[stringListById7].Length;
          for (int index9 = 0; index9 <= length; index9 += 1)
          {
            if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index9, 0])) == integer1)
            {
              int idValue5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index9, 1]));
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 5))) == 0)
                num45 += Math.Max(1,  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue5, 2))));
            }
          }
          if (num45 > 0)
            num44 =  Math.Round((double) (num44 * num40) / (double) num45);
          int num46 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById10].GetData2(0, num3, 1, "government", 2)));
          int num47 = num44 -  Math.Round((double) (num44 * num46) / 100.0);
          if (num47 >  Math.Round((double) num43 * 0.7))
            num47 =  Math.Round((double) num43 * 0.7);
          int setValue7 = num43 - num47;
          num20 -= setValue7;
          this.game.Data.StringListObj[stringListById6].SetData2(0, integer1, 1, "popCredits", 2, setValue6, true);
          this.game.Data.StringListObj[stringListById6].SetData2(0, integer1, 1, "popHapiness", 2, setValue7, true);
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 1, num39);
          this.game.Data.StringListObj[stringListById7].SetData(9, num10, 5, setValue4);
          this.orderfeedbackString = this.orderfeedbackString + "Asset was nationalized. Population happiness dropped with " + num20.ToString() + " points.";
        }
        if (this.AssetOrderNumber == 23)
        {
          int idValue =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 1)));
          num18 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 7)));
          num19 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue, 13)));
          int index10 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 3)));
          int index11 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(9, num10, 4)));
          SimpleList simpleList = SimpleList::new();
          if (index1 > -1)
          {
            int length = this.game.Data.StringListObj[stringListById1].Length;
            for (int index12 = 0; index12 <= length; index12 += 1)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index12, 0])) == num10 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index12, 1])) == 1)
              {
                int tid =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index12, 2]));
                int tweight =  Math.Round((double)  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index12, 3])) / 2.0);
                if (tweight > 0)
                  simpleList.AddWeight(tid, tweight);
              }
            }
          }
          this.orderfeedbackString += "Construction was canceled. ";
          if (simpleList.Counter > -1)
          {
            int counter = simpleList.Counter;
            for (int index13 = 0; index13 <= counter; index13 += 1)
            {
              if (index13 == 0)
                this.orderfeedbackString += "Recuperated: ";
              if (index13 > 0)
                this.orderfeedbackString += ", ";
              data: String = this.game.Data.StringListObj[stringListById9].GetData(0, simpleList.Id[index13], 1);
              this.orderfeedbackString = this.orderfeedbackString + simpleList.Weight[index13].ToString() + "x " + data;
              this.game.Data.LocObj[index1].items.list.AddWeight(simpleList.Id[index13], simpleList.Weight[index13]);
            }
          }
          data1: DataClass = this.game.Data;
          str: String = "ownZoneFlag";
           local: String =  str;
          libName2: String = libName1;
          int libVar = data1.FindLibVar( local, libName2);
          this.game.Data.MapObj[0].HexObj[index10, index11].SetHexLibVarValue(libVar, 0);
          int row = this.game.Data.StringListObj[stringListById7].FindRow(9, num10);
          this.game.Data.StringListObj[stringListById7].RemoveRow(row);
          this.game.EventRelatedObj.Helper_SetLocationTypeForHex(index10, index11, index10, index11);
        }
      }
      this.AssetOrderNumber = 0;
      if (this.game.Data.MapObj[0].HexObj[x4, y3].Regime > -1)
      {
        index3 = this.game.Data.MapObj[0].HexObj[x4, y3].Regime;
        num4 = this.game.Data.RegimeObj[index3].id;
      }
      int index14 = -1;
      if (id > 0)
        index14 = this.game.HandyFunctionsObj.GetLocationByID(id);
      int num48 = -1;
      if (index14 > -1)
        num48 = this.game.Data.LocObj[index14].HQ;
      this.game.EditObj.UDSinputCounter = -1;
      if (this.game.Data.MapObj[0].HexObj[x4, y3].MaxRecon < 1 & this.game.Data.FOWOn && this.game.Data.MapObj[0].HexObj[x4, y3].get_LastLT(this.game.Data.Turn) == -1)
        return;
      if (index3 > -1 & index2 == -1)
      {
        index2 = index3;
        num3 = num4;
      }
      if (index2 == -1)
        return;
      if (this.game.EditObj.se1_AssetCategory1 < 1)
        this.game.EditObj.se1_AssetCategory1 = 2;
      if (index2 == this.game.Data.Turn | !this.game.Data.FOWOn)
      {
        num5 = 9999;
        num7 = 9999;
      }
      int num49 = 0;
      int int32 = Convert.ToInt32(Decimal.Divide(Math.Floor(new Decimal(useRect.Width - 480)), 160M));
      num18 = -1;
      this.game.Data.FindEventPic("", 0, "SE_Present");
      this.game.Data.FindEventPic("", 109, "SE_Present");
      int num50 = -1;
      bool flag3 = false;
      this.game.Data.FindEventPic("", 5, "SE_Present");
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location == index14 & index14 > -1)
        flag3 = true;
      int num51 = -1;
      SimpleList simpleList1 = SimpleList::new();
      int num52 = 1;
      int num53;
      int num54;
      int num55;
      int num56;
      int num57;
      int num58;
      do
      {
        int length = this.game.Data.StringListObj[stringListById7].Length;
        for (int tid = 0; tid <= length; tid += 1)
        {
          int num59 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tid, 9]));
          int idValue =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tid, 1]));
          num53 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue, 3)));
          int x5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tid, 3]));
          int y4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tid, 4]));
          integer2 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x5, y4, libName1, "Zones"));
          int num60 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tid, 0]));
          if (integer1 > 0 | x5 == this.game.SelectX & y4 == this.game.SelectY && (num60 == integer1 | integer2 == integer1) & (this.game.Data.MapObj[0].HexObj[x5, y4].MaxRecon > 0 | num5 >= 5) &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue, 5))) == num52)
          {
            if (integer2 == num60 | this.game.EditObj.se1_AssetCategory1 == 2)
            {
              if (num52 == 1)
                num54 += 1;
              if (num52 == 0)
                num55 += 1;
              if (num60 != integer2)
                num56 += 1;
            }
            if (x5 == this.game.SelectX & y4 == this.game.SelectY)
              num57 += 1;
            num58 += 1;
            bool flag4 = true;
            if (this.game.EditObj.se1_AssetCategory2 == 1 & num52 == 0)
              flag4 = false;
            if (this.game.EditObj.se1_AssetCategory2 == 2 & num52 == 1)
              flag4 = false;
            if (this.game.EditObj.se1_AssetCategory1 == 1 & !(x5 == this.game.SelectX & y4 == this.game.SelectY))
              flag4 = false;
            if (this.game.EditObj.se1_AssetCategory2 == 3 & num60 == integer2)
              flag4 = false;
            if (flag4)
            {
              if (index14 > -1)
              {
                if (this.game.Data.LocObj[index14].X == x5 & this.game.Data.LocObj[index14].Y == y4)
                  simpleList1.Add(tid, 10000000 + num52 * 100000 + x5 * 200 + y4);
                else
                  simpleList1.Add(tid, num52 * 100000 + x5 * 200 + y4);
              }
              else
                simpleList1.Add(tid, num52 * 100000 + x5 * 200 + y4);
            }
          }
        }
        num52 += -1;
      }
      while (num52 >= 0);
      data2: DataClass = this.game.Data;
      str1: String = "perk";
       local9: String =  str1;
      libName3: String = libName1;
      int libVar1 = data2.FindLibVar( local9, libName3);
      data3: DataClass = this.game.Data;
      str2: String = "hexname";
       local10: String =  str2;
      libName4: String = libName1;
      data3.FindLibVar( local10, libName4);
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index15 = 0; index15 <= mapWidth1; index15 += 1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index16 = 0; index16 <= mapHeight; index16 += 1)
        {
          if (Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(index15, index16, libName1, "Zones")) == integer1)
          {
            int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index15, index16].GetHexLibVarValue(libVar1);
            if (hexLibVarValue > 0 && this.game.Data.MapObj[0].HexObj[index15, index16].MaxRecon > 0)
            {
              num58 += 1;
              num55 += 1;
              if (this.game.EditObj.se1_AssetCategory2 != 1 && !(this.game.EditObj.se1_AssetCategory1 == 1 & !(index15 == this.game.SelectX & index16 == this.game.SelectY)))
              {
                int num61 = 1000 * index15 + index16;
                simpleList1.Add(9000000 + num61, 5000, index15, index16, hexLibVarValue);
              }
            }
          }
        }
      }
      data4: DataClass = this.game.Data;
      str3: String = "freefolk";
       local11: String =  str3;
      libName5: String = libName1;
      int libVar2 = data4.FindLibVar( local11, libName5);
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int index17 = 0; index17 <= mapWidth2; index17 += 1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index18 = 0; index18 <= mapHeight; index18 += 1)
        {
          if (Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(index17, index18, libName1, "Zones")) == integer1)
          {
            int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index17, index18].GetHexLibVarValue(libVar2);
            if (hexLibVarValue > 0 && this.game.Data.MapObj[0].HexObj[index17, index18].MaxRecon > 0)
            {
              int num62;
              num62 += 1;
              num55 += 1;
              if (this.game.EditObj.se1_AssetCategory2 != 1 && !(this.game.EditObj.se1_AssetCategory1 == 1 & !(index17 == this.game.SelectX & index18 == this.game.SelectY)))
              {
                num19 = 1000 * index17 + index18;
                simpleList1.Add(15000000, 7000, index17, index18, hexLibVarValue, CheckExistence: false);
              }
            }
          }
        }
      }
      simpleList1.ReverseSort();
      int num63 = 0;
      int num64 = -1;
      int num65 = 1;
      int num66;
      do
      {
        int counter = simpleList1.Counter;
        for (int index19 = 0; index19 <= counter; index19 += 1)
        {
          int index20 = simpleList1.Id[index19];
          int num67 = -1;
          int num68 = 0;
          num66 = -1;
          int x6;
          int y5;
          int idValue;
          int num69;
          int num70;
          int num71;
          if (index20 >= 9000000 & index20 < 15000000)
          {
            num67 = simpleList1.Data3[index19];
            x6 = simpleList1.Data1[index19];
            y5 = simpleList1.Data2[index19];
            idValue = -1;
            num69 = 9000000 + x6 * 1000 + y5;
            num70 = integer1;
            if ((num10 == num69 | num10 < 1 & this.game.SelectX == x6 & this.game.SelectY == y5) & num51 == -1)
            {
              num51 = x6;
              num71 = y5;
              num10 = num69;
            }
          }
          else if (index20 >= 15000000 & index20 < 16000000)
          {
            x6 = simpleList1.Data1[index19];
            y5 = simpleList1.Data2[index19];
            idValue = -1;
            num69 = 15000000 + x6 * 1000 + y5;
            num70 = integer1;
            num68 = simpleList1.Data3[index19];
            if ((num10 == num69 | num10 < 1 & this.game.SelectX == x6 & this.game.SelectY == y5) & num51 == -1)
            {
              num51 = x6;
              num71 = y5;
              num10 = num69;
            }
          }
          else
          {
            num67 = -1;
            num69 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index20, 9]));
            idValue =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index20, 1]));
            num53 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue, 3)));
            x6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index20, 3]));
            y5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index20, 4]));
            integer2 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x6, y5, libName1, "Zones"));
            num70 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index20, 0]));
            bool flag5 = false;
            if ((num10 == num69 | num10 < 1 & this.game.SelectX == x6 & this.game.SelectY == y5) & num51 == -1)
            {
              num51 = x6;
              num71 = y5;
              num10 = num69;
              flag5 = true;
            }
          }
          if ((num70 == integer1 | integer2 == integer1) & (this.game.Data.MapObj[0].HexObj[x6, y5].MaxRecon > 0 | num5 >= 5) &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue, 5))) == num65 | num67 > 0 & num65 == 0 | num68 > 0 & num65 == 0)
          {
            num63 += 1;
            if (num64 == -1 & x4 == x6 & y3 == y5 & num69 == num10)
              num64 = num63;
          }
        }
        num65 += -1;
      }
      while (num65 >= 0);
      int num72 = 0;
      int num73 =  Math.Round(Math.Floor((double) simpleList1.Counter / (double) int32)) + 1;
      int num74;
      if (num64 > -1)
      {
        num72 =  Math.Round(Math.Floor((double) (num64 - 1) / (double) int32));
        num74 = num72 * int32 + 1;
      }
      else
        num74 = 1;
      if (this.game.EditObj.se1_AssetPage > num73 | this.game.EditObj.se1_AssetPage < 1)
      {
        this.game.EditObj.se1_AssetPage = num72 + 1;
        this.prevAssetId = -1;
      }
      if (this.prevAssetId == num10)
      {
        num74 = (this.game.EditObj.se1_AssetPage - 1) * int32 + 1;
        if (num74 < 1)
          num74 = 1;
      }
      else
        this.game.EditObj.se1_AssetPage = num72 + 1;
      this.prevAssetId = num10;
      int num75 = num73;
      if (num75 > 8)
        num75 = 8;
      int x7 = useRect.X + useRect.Width - 156;
      int num76 = 5;
      int num77 =  Math.Round(Math.Floor(200.0 / (double) num75)) - 4;
      int num78 = 1;
      if (num75 < num73)
      {
        num78 = this.game.EditObj.se1_AssetPage;
        if (num78 > num73 - 4)
          num78 = num73 - 4;
        if (num78 > this.game.EditObj.se1_AssetPage - 3)
          num78 = this.game.EditObj.se1_AssetPage - 3;
        if (1 > num78)
          num78 = 1;
      }
      int num79 = num75;
      SubPartClass tsubpart;
      for (int index21 = 1; index21 <= num79; index21 += 1)
      {
        int num80 = num78 - 1 + index21;
        if (num80 >= 1 & num80 <= num73)
        {
          int y6 = 5 + (index21 - 1) * num77;
          if (index21 > 1)
            y6 += 4 * (index21 - 1);
          this += 1.assetButtonCounter;
          tDescript: String = num80.ToString() + "/" + num73.ToString() + ". Click to view this Asset page.";
          if (this.game.EditObj.se1_AssetPage == num80)
            tDescript = num80.ToString() + "/" + num73.ToString() + ". Currently selected Asset page for this Zone";
          int[] assetButton = this.assetButton;
          int assetButtonCounter = this.assetButtonCounter;
          tsubpart =  new SEBigTextPartClass(num80.ToString(), tDescript, this.game.EditObj.se1_AssetPage == num80, 44, num77);
          int num81 = this.AddSubPart( tsubpart, x7, y6, 44, num77, 1);
          assetButton[assetButtonCounter] = num81;
          this.assetButtonData[this.assetButtonCounter] = 50 + num80;
        }
      }
      int x8 = useRect.X + useRect.Width - 104;
      int y7 = 5;
      this += 1.assetButtonCounter;
      tDataString1: String = num57.ToString();
      tDescript1: String = "Only Assets in the selected Hex are shown if this button is tapped.";
      int[] assetButton1 = this.assetButton;
      int assetButtonCounter1 = this.assetButtonCounter;
      tsubpart =  new SEZoneButtonShortPartClass(38, -1, tDataString1, tDescript1, this.game.EditObj.se1_AssetCategory1 == 1);
      int num82 = this.AddSubPart( tsubpart, x8, y7, 93, 40, 1);
      assetButton1[assetButtonCounter1] = num82;
      this.assetButtonData[this.assetButtonCounter] = 11;
      int y8 = y7 + 41;
      this += 1.assetButtonCounter;
      tDataString2: String = num58.ToString();
      tDescript2: String = "All Assets in the selected Zone are shown if this button is tapped.";
      int[] assetButton2 = this.assetButton;
      int assetButtonCounter2 = this.assetButtonCounter;
      tsubpart =  new SEZoneButtonShortPartClass(16, -1, tDataString2, tDescript2, this.game.EditObj.se1_AssetCategory1 == 2);
      int num83 = this.AddSubPart( tsubpart, x8, y8, 93, 40, 1);
      assetButton2[assetButtonCounter2] = num83;
      this.assetButtonData[this.assetButtonCounter] = 12;
      int y9 = y8 + 41;
      this += 1.assetButtonCounter;
      tDataString3: String = num54.ToString();
      tDescript3: String = "Public Assets are shown if this button is tapped.";
      int[] assetButton3 = this.assetButton;
      int assetButtonCounter3 = this.assetButtonCounter;
      tsubpart =  new SEZoneButtonShortPartClass(18, -1, tDataString3, tDescript3, this.game.EditObj.se1_AssetCategory2 == 1);
      int num84 = this.AddSubPart( tsubpart, x8, y9, 93, 40, 1);
      assetButton3[assetButtonCounter3] = num84;
      this.assetButtonData[this.assetButtonCounter] = 13;
      int y10 = y9 + 41;
      this += 1.assetButtonCounter;
      tDataString4: String = num55.ToString();
      tDescript4: String = "Private Assets are shown if this button is tapped.";
      int[] assetButton4 = this.assetButton;
      int assetButtonCounter4 = this.assetButtonCounter;
      tsubpart =  new SEZoneButtonShortPartClass(19, -1, tDataString4, tDescript4, this.game.EditObj.se1_AssetCategory2 == 2);
      int num85 = this.AddSubPart( tsubpart, x8, y10, 93, 40, 1);
      assetButton4[assetButtonCounter4] = num85;
      this.assetButtonData[this.assetButtonCounter] = 14;
      int y11 = y10 + 41;
      this += 1.assetButtonCounter;
      tDataString5: String = num56.ToString();
      tDescript5: String = "Delegated and Tasked Assets are shown if this button is tapped.";
      int[] assetButton5 = this.assetButton;
      int assetButtonCounter5 = this.assetButtonCounter;
      tsubpart =  new SEZoneButtonShortPartClass(39, -1, tDataString5, tDescript5, this.game.EditObj.se1_AssetCategory2 == 3);
      int num86 = this.AddSubPart( tsubpart, x8, y11, 93, 40, 1);
      assetButton5[assetButtonCounter5] = num86;
      this.assetButtonData[this.assetButtonCounter] = 15;
      num76 = y11 + 41;
      int num87 = 0;
      num18 = -1;
      int num88 = -1;
      num76 = 18;
      Color color = Color.FromArgb(100,  byte.MaxValue,  byte.MaxValue, 0);
      if (index2 > -1)
        color = Color.FromArgb(200, this.game.Data.RegimeObj[index2].Red, this.game.Data.RegimeObj[index2].Green, this.game.Data.RegimeObj[index2].Blue);
      int num89 = 1;
      do
      {
        int counter = simpleList1.Counter;
        for (int index22 = 0; index22 <= counter; index22 += 1)
        {
          int index23 = simpleList1.Id[index22];
          int num90 = -1;
          num66 = -1;
          int num91 = 0;
          int x9;
          int y12;
          int idValue6;
          int assetId;
          int num92;
          int idValue7;
          int num93;
          int regime;
          if (index23 >= 9000000 & index23 < 15000000)
          {
            num90 = simpleList1.Data3[index22];
            x9 = simpleList1.Data1[index22];
            y12 = simpleList1.Data2[index22];
            idValue6 = -1;
            assetId = 9000000 + x9 * 1000 + y12;
            num92 = integer1;
            idValue7 = integer1;
            num93 = 0;
            regime = this.game.Data.MapObj[0].HexObj[x9, y12].Regime;
          }
          else if (index23 >= 15000000 & index23 < 16000000)
          {
            num91 = simpleList1.Data3[index22];
            x9 = simpleList1.Data1[index22];
            y12 = simpleList1.Data2[index22];
            idValue6 = -1;
            assetId = 15000000 + x9 * 1000 + y12;
            num92 = integer1;
            idValue7 = integer1;
            num93 = 0;
            regime = this.game.Data.MapObj[0].HexObj[x9, y12].Regime;
          }
          else
          {
            num90 = -1;
            assetId =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 9]));
            idValue6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 1]));
            num53 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 3)));
            x9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 3]));
            y12 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 4]));
            num93 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 5)));
            idValue7 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x9, y12, libName1, "Zones"));
            regime = this.game.Data.MapObj[0].HexObj[x9, y12].Regime;
            num92 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 0]));
          }
          if ((num92 == integer1 | idValue7 == integer1) & (this.game.Data.MapObj[0].HexObj[x9, y12].MaxRecon > 0 | num5 >= 5) && num91 > 0 & num89 == 0 | num90 > -1 & num89 == 0 |  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 5))) == num89)
          {
            num87 += 1;
            num49 += 1;
            if (num87 >= num74 & num87 < num74 + int32)
            {
              if (num10 < 1)
                num10 = assetId;
              if (num50 == -1)
                num50 = num87;
              num88 += 1;
              int num94 = num88 * 160 + (312 + useRect.X);
              int num95 = 5;
              if (this.game.EditObj.se1_SelectAssetButton < 1 & x9 == this.game.SelectX & y12 == this.game.SelectY)
                this.game.EditObj.se1_SelectAssetButton = assetId;
              CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
               Graphics local12 =  g;
              int tx = num94;
              int ty = num95;
              WindowClass windowClass = (WindowClass) this;
               WindowClass local13 =  windowClass;
              int curAssetId = num10;
              int assetRowOrSpecialCode = index23;
              int specialOnX = x9;
              int specialOnY = y12;
              int specialType = simpleList1.Data3[index22];
              int zoneNr = integer1;
              int zoneRegNr = index2;
              customBitmapObj.Se1_DrawAssetBlock( local12, tx, ty,  local13, curAssetId, assetRowOrSpecialCode, specialOnX, specialOnY, specialType, zoneNr, zoneRegNr);
              if (idValue6 > 0 & this.game.EditObj.se1_SelectAssetButton == assetId)
              {
                int num96 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 25)));
                int num97 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 5)));
                int num98 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 13]));
                int num99 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 11]));
                int num100 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 6]));
                int num101 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 15]));
                int num102 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 8]));
                int num103 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 2)));
                int num104 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 4)));
                int idValue8 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 14)));
                str4: String = this.game.Data.StringListObj[stringListById7].Data[index23, 10];
                if (this.game.Data.MapObj[0].HexObj[x9, y12].Location > -1 & idValue7 > 0 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue7, 6))) != this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x9, y12].Location].ID)
                {
                  name: String = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x9, y12].Location].Name;
                  this.game.Data.StringListObj[stringListById7].Data[index23, 10] = name;
                }
                this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 1);
                this.game.Data.StringListObj[stringListById8].GetData(0, idValue6, 12);
                int num105 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 5]));
                int idValue9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData2(14, idValue8, 2, num103 + 1, 0)));
                int num106 = 0;
                if (idValue9 > 0)
                {
                  int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 3]));
                  int idValue3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 4]));
                  num106 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData3(1, idValue9, 3, idValue2, 4, idValue3, 0)));
                }
                int num107 = 34 + useRect.X;
                int num108 = 14;
                this += 1.assetButtonCounter;
                int[] assetButton6 = this.assetButton;
                int assetButtonCounter6 = this.assetButtonCounter;
                tsubpart =  new TextButtonPartClass("?", 40, "Click for more information",  this.OwnBitmap, num107 + 200, num108, theight: 40, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
                int num109 = this.AddSubPart( tsubpart, num107 + 200, num108, 40, 40, 1);
                assetButton6[assetButtonCounter6] = num109;
                this.assetButtonData[this.assetButtonCounter] = 24;
                int idValue10 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 0]));
                tstring1: String = idValue7 == integer1 ? (num92 != integer1 ? "DEL.TO:" + this.game.Data.StringListObj[stringListById5].GetData(0, idValue10, 7) : (integer1 >= 1 ? "ZONE:" + this.game.Data.StringListObj[stringListById5].GetData(0, idValue10, 7) : "Hex without zone")) : (index3 == this.game.Data.Turn ? "TASK FROM:" + this.game.Data.StringListObj[stringListById5].GetData(0, idValue7, 7) : "ZONE:Evacuated Asset");
                DrawMod.DrawTextColouredConsole( g, tstring1, DrawMod.TGame.se1TypeWriterMedium, num107, num108, DrawMod.TGame.seColTW);
                int y13 = num108 + 20;
                int y14;
                if (num102 > 0)
                {
                  int y15;
                  if (index2 == this.game.Data.Turn)
                  {
                    tstring2: String = "UPKEEP:" + num98.ToString() + "% CONSTR: " + num99.ToString() + "%";
                    DrawMod.DrawTextColouredConsole( g, tstring2, DrawMod.TGame.se1TypeWriterMedium, num107, y13, DrawMod.TGame.seColTW);
                    y15 = y13 + 20;
                  }
                  else
                  {
                    tstring3: String = "CONSTR: " + num99.ToString() + "%";
                    DrawMod.DrawTextColouredConsole( g, tstring3, DrawMod.TGame.se1TypeWriterMedium, num107, y13, DrawMod.TGame.seColTW);
                    y15 = y13 + 20;
                  }
                  tstring4: String = "DAMAGE:" + num100.ToString() + " pts";
                  DrawMod.DrawTextColouredConsole( g, tstring4, DrawMod.TGame.se1TypeWriterMedium, num107, y15, DrawMod.TGame.seColTW);
                  y14 = y15 + 20;
                  if (index2 == this.game.Data.Turn)
                  {
                    Left: String = ((float) Math.Round((double) ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 7])) * 100 -  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[index23, 12]))) / 100.0, 1)).ToString();
                    if (Operators.CompareString(Left, "0", false) == 0)
                      Left = "0.1";
                    tstring5: String = "CONSTRUCTION:" + Left + " turns left.";
                    DrawMod.DrawTextColouredConsole( g, tstring5, DrawMod.TGame.se1TypeWriterMedium, num107, y14, DrawMod.TGame.seColTW);
                    y14 += 20;
                  }
                }
                else
                {
                  if (index2 == this.game.Data.Turn)
                  {
                    tstring6: String = "UPKEEP:" + num98.ToString() + "%  PROD: " + num99.ToString() + "%";
                    DrawMod.DrawTextColouredConsole( g, tstring6, DrawMod.TGame.se1TypeWriterMedium, num107, y13, DrawMod.TGame.seColTW);
                    y13 += 20;
                  }
                  tstring7: String = "DAM:" + num100.ToString() + " pts";
                  DrawMod.DrawTextColouredConsole( g, tstring7, DrawMod.TGame.se1TypeWriterMedium, num107, y13, DrawMod.TGame.seColTW);
                  if (index2 == this.game.Data.Turn)
                  {
                    tstring8: String = !(num101 > 0 & num101 < 100) ? "LIMIT: Max 100%" : "LIMIT: Max " + num101.ToString() + "%";
                    DrawMod.DrawTextColouredConsole( g, tstring8, DrawMod.TGame.se1TypeWriterMedium, num107 + 110, y13, DrawMod.TGame.seColTW);
                  }
                  y14 = y13 + 20;
                  if (index2 == this.game.Data.Turn && x9 > -1 & num104 == 5)
                  {
                    int location = this.game.Data.MapObj[0].HexObj[x9, y12].Location;
                    int num110 = 0;
                    int num111 = 0;
                    if (location > -1)
                    {
                      int logCounter = this.game.Data.LocObj[location].LogCounter;
                      for (int index24 = 0; index24 <= logCounter; index24 += 1)
                      {
                        if (this.game.Data.LocObj[location].LogType[index24] >= 801 & this.game.Data.LocObj[location].LogType[index24] <= 899)
                          num110 += this.game.Data.LocObj[location].LogData3[index24];
                        if (this.game.Data.LocObj[location].LogType[index24] >= 901 & this.game.Data.LocObj[location].LogType[index24] <= 999)
                          num111 += this.game.Data.LocObj[location].LogData3[index24];
                      }
                      if (num110 > 0 | num111 > 0)
                      {
                        tstring9: String = "LOG.EXTENSION:" + num111.ToString() + ", NXT: " + num110.ToString();
                        DrawMod.DrawTextColouredConsole( g, tstring9, DrawMod.TGame.se1TypeWriterMedium, num107, y14, DrawMod.TGame.seColTW);
                        y14 += 20;
                      }
                    }
                  }
                }
                int num112 = y14 + 5;
                int num113 = 150;
                if (flag1 & index2 == this.game.Data.Turn)
                {
                  if (num93 > 0)
                  {
                    int num114 = num112;
                    int num115 = 1;
                    do
                    {
                      this += 1.assetButtonCounter;
                      if (num115 == 1)
                        num77 = 100;
                      if (num115 == 2)
                        num77 = 75;
                      if (num115 == 3)
                        num77 = 50;
                      if (num115 == 4)
                        num77 = 25;
                      string buttontext;
                      string tDescript6;
                      if (num102 > 0)
                      {
                        buttontext = num77.ToString() + "% Cons";
                        tDescript6 = "Set maximum construction speed of Asset to " + buttontext + ".";
                      }
                      else
                      {
                        buttontext = num77.ToString() + "% Prod";
                        tDescript6 = "Set maximum production speed of Asset to " + buttontext + ".";
                      }
                      int num116 = 0;
                      if (num101 == num77 | num101 == 0 & num77 == 100)
                        num116 = 1;
                      int[] assetButton7 = this.assetButton;
                      int assetButtonCounter7 = this.assetButtonCounter;
                      tsubpart =  new TextButtonPartClass(buttontext, 90, tDescript6,  this.OwnBitmap, num107 + 150, num112, num116 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                      int num117 = this.AddSubPart( tsubpart, num107 + 150, num112, 90, 25, 1);
                      assetButton7[assetButtonCounter7] = num117;
                      this.assetButtonData[this.assetButtonCounter] = 2000 + num77;
                      if (num116 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      num112 += 25;
                      num115 += 1;
                    }
                    while (num115 <= 4);
                    num112 = num114;
                  }
                  if (num93 < 1)
                  {
                    int num118 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById10].GetData2(0, num3, 1, "credits", 2)));
                    num77 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData3(0, idValue6, 1, 3, 2, "credits", 3)));
                    buttontext: String = "Nationalize [" + num77.ToString() + "Cr]";
                    string tDescript7;
                    int num119;
                    if (num77 > num118)
                    {
                      tDescript7 = "You do not have the " + num77.ToString() + " credits required to nationalize this asset. ";
                      num119 = 1;
                    }
                    else
                    {
                      tDescript7 = "Nationalizing this asset will cost you " + num77.ToString() + " credits. ";
                      num119 = 0;
                    }
                    if (num96 < 1)
                    {
                      tDescript7 = "This Asset Type cannot be nationalized. ";
                      num119 = 1;
                      buttontext = "Nationalize";
                    }
                    else if (num102 > 0)
                    {
                      tDescript7 = "A Private Asset in construction cannot be nationalized. ";
                      num119 = 1;
                      buttontext = "Nationalize";
                    }
                    else if (this.game.EventRelatedObj.Helper_IsAssetUnderConstructionOrUpgrade(assetId))
                    {
                      tDescript7 = "A Private Asset in the process of being upgraded cannot be nationalized. ";
                      num119 = 1;
                      buttontext = "Nationalize";
                    }
                    this += 1.assetButtonCounter;
                    int[] assetButton8 = this.assetButton;
                    int assetButtonCounter8 = this.assetButtonCounter;
                    tsubpart =  new TextButtonPartClass(buttontext, 230, tDescript7,  this.OwnBitmap, num107, num112, num119 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                    int num120 = this.AddSubPart( tsubpart, num107, num112, 230, 25, 1);
                    assetButton8[assetButtonCounter8] = num120;
                    this.assetButtonData[this.assetButtonCounter] = 21;
                    if (num119 == 1)
                      this.assetButtonData[this.assetButtonCounter] = 0;
                    num112 += 25;
                  }
                  tDescript8: String = "Change the zone this asset is delegated to";
                  this += 1.assetButtonCounter;
                  int num121 = 0;
                  if (x9 == num1 & y12 == num2)
                  {
                    num121 = 1;
                    tDescript8 = "Cannot Delegate Assets in the City, only in Rural Hexes.";
                  }
                  if (num93 < 1 && num92 == integer1)
                  {
                    num121 = 1;
                    tDescript8 = "Cannot Delegate Private Assets, only Public ones.";
                  }
                  if (num92 != integer1)
                  {
                    int[] assetButton9 = this.assetButton;
                    int assetButtonCounter9 = this.assetButtonCounter;
                    tsubpart =  new TextButtonPartClass("(Un)delegate", num113, tDescript8,  this.OwnBitmap, num107, num112, num121 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                    int num122 = this.AddSubPart( tsubpart, num107, num112, num113, 25, 1);
                    assetButton9[assetButtonCounter9] = num122;
                  }
                  else
                  {
                    int[] assetButton10 = this.assetButton;
                    int assetButtonCounter10 = this.assetButtonCounter;
                    tsubpart =  new TextButtonPartClass("Delegate", num113, tDescript8,  this.OwnBitmap, num107, num112, num121 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                    int num123 = this.AddSubPart( tsubpart, num107, num112, num113, 25, 1);
                    assetButton10[assetButtonCounter10] = num123;
                  }
                  this.assetButtonData[this.assetButtonCounter] = 22;
                  if (num121 == 1)
                    this.assetButtonData[this.assetButtonCounter] = 0;
                  int num124 = num112 + 25;
                  if (num97 == 1)
                  {
                    if (num102 == 1)
                    {
                      int num125 = 0;
                      tDescript9: String = "Cancel Construction";
                      this += 1.assetButtonCounter;
                      int[] assetButton11 = this.assetButton;
                      int assetButtonCounter11 = this.assetButtonCounter;
                      tsubpart =  new TextButtonPartClass("Cancel Constr.", num113, tDescript9,  this.OwnBitmap, num107, num124, num125 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                      int num126 = this.AddSubPart( tsubpart, num107, num124, num113, 25, 1);
                      assetButton11[assetButtonCounter11] = num126;
                      this.assetButtonData[this.assetButtonCounter] = 23;
                      if (num125 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      num124 += 25;
                    }
                    else
                    {
                      int num127 = 1;
                      if (num105 < 0)
                        num127 = 0;
                      tDescript10: String = "Set Asset to Active Mode";
                      this += 1.assetButtonCounter;
                      int[] assetButton12 = this.assetButton;
                      int assetButtonCounter12 = this.assetButtonCounter;
                      tsubpart =  new TextButtonPartClass("Active", num113, tDescript10,  this.OwnBitmap, num107, num124, num127 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                      int num128 = this.AddSubPart( tsubpart, num107, num124, num113, 25, 1);
                      assetButton12[assetButtonCounter12] = num128;
                      this.assetButtonData[this.assetButtonCounter] = 31;
                      if (num127 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      int num129 = num124 + 25;
                      int num130 = 1;
                      if (num105 != -1)
                        num130 = 0;
                      tDescript11: String = "Set Asset to Mothball Mode";
                      this += 1.assetButtonCounter;
                      int[] assetButton13 = this.assetButton;
                      int assetButtonCounter13 = this.assetButtonCounter;
                      tsubpart =  new TextButtonPartClass("Mothball", num113, tDescript11,  this.OwnBitmap, num107, num129, num130 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                      int num131 = this.AddSubPart( tsubpart, num107, num129, num113, 25, 1);
                      assetButton13[assetButtonCounter13] = num131;
                      this.assetButtonData[this.assetButtonCounter] = 32;
                      if (num130 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      int num132 = num129 + 25;
                      int num133 = 1;
                      if (num105 != -2)
                        num133 = 0;
                      tDescript12: String = "Close down the Asset";
                      this += 1.assetButtonCounter;
                      int[] assetButton14 = this.assetButton;
                      int assetButtonCounter14 = this.assetButtonCounter;
                      tsubpart =  new TextButtonPartClass("Close", num113, tDescript12,  this.OwnBitmap, num107, num132, num133 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                      int num134 = this.AddSubPart( tsubpart, num107, num132, num113, 25, 1);
                      assetButton14[assetButtonCounter14] = num134;
                      this.assetButtonData[this.assetButtonCounter] = 33;
                      if (num133 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      num124 = num132 + 25;
                    }
                  }
                  if ( Math.Round(Conversion.Val(this.game.Data.Designer)) >= 112)
                  {
                    int num135 = 0;
                    tDescript13: String = "Disband a single level of this Asset. Recuperate some items from this. If Private then you'll lose Population Happiness.";
                    this += 1.assetButtonCounter;
                    if (num102 > 0)
                    {
                      tDescript13 = "You cannot disband an Asset that is in construction.";
                      num135 = 1;
                    }
                    if (num106 > 0)
                    {
                      tDescript13 = "You cannot disband an Asset that has a new level in construction.";
                      num135 = 1;
                    }
                    if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts < num103)
                    {
                      tDescript13 = "You do not have the PP to pay for disbanding the Asset level.";
                      num135 = 1;
                    }
                    int[] assetButton15 = this.assetButton;
                    int assetButtonCounter15 = this.assetButtonCounter;
                    tsubpart =  new TextButtonPartClass("Disband Level [" + num103.ToString() + " PP]", num113 + 50, tDescript13,  this.OwnBitmap, num107, num124, num135 == 1, theight: 25, usefont: DrawMod.TGame.se1TypeWriterSmall, tudsButton: true);
                    int num136 = this.AddSubPart( tsubpart, num107, num124, num113, 25, 1);
                    assetButton15[assetButtonCounter15] = num136;
                    this.assetButtonData[this.assetButtonCounter] = 25;
                    if (num135 == 1)
                      this.assetButtonData[this.assetButtonCounter] = 0;
                    num76 = num124 + 25;
                  }
                }
                else if (num4 == this.game.Data.Turn)
                {
                  int num137 = num97 == 1 & num53 > 0 ? 1 : 0;
                }
              }
              else if (num90 > 0)
              {
                if (num10 == assetId)
                {
                  int x10 = 34 + useRect.X;
                  int y16 = 14;
                  tstring10: String = idValue7 >= 1 ? "ZONE:" + this.game.Data.StringListObj[stringListById5].GetData(0, idValue7, 7) : "Hex without zone";
                  DrawMod.DrawTextColouredConsole( g, tstring10, DrawMod.TGame.se1TypeWriterMedium, x10, y16, DrawMod.TGame.seColTW);
                  int y17 = y16 + 20;
                  tstring11: String = "This is a Hex Perk.";
                  DrawMod.DrawTextColouredConsole( g, tstring11, DrawMod.TGame.se1TypeWriterMedium, x10, y17, DrawMod.TGame.seColTW);
                  int y18 = y17 + 20;
                  tstring12: String = "No settings possible.";
                  DrawMod.DrawTextColouredConsole( g, tstring12, DrawMod.TGame.se1TypeWriterMedium, x10, y18, DrawMod.TGame.seColTW);
                  num76 = y18 + 20;
                }
              }
              else if (num91 > 0 && num10 == assetId)
              {
                int x11 = 34 + useRect.X;
                int y19 = 14;
                tstring13: String = idValue7 >= 1 ? "ZONE:" + this.game.Data.StringListObj[stringListById5].GetData(0, idValue7, 7) : "Hex without zone";
                DrawMod.DrawTextColouredConsole( g, tstring13, DrawMod.TGame.se1TypeWriterMedium, x11, y19, DrawMod.TGame.seColTW);
                int y20 = y19 + 20;
                tstring14: String = "A Free Folk settlement.";
                DrawMod.DrawTextColouredConsole( g, tstring14, DrawMod.TGame.se1TypeWriterMedium, x11, y20, DrawMod.TGame.seColTW);
                int y21 = y20 + 20;
                tstring15: String = "No settings possible.";
                DrawMod.DrawTextColouredConsole( g, tstring15, DrawMod.TGame.se1TypeWriterMedium, x11, y21, DrawMod.TGame.seColTW);
                num76 = y21 + 20;
              }
            }
          }
        }
        num89 += -1;
      }
      while (num89 >= 0);
    }

    pub void UnitBottomTab(Graphics g, Rectangle useRect)
    {
      libName: String = "SE_Data";
      if (this.game.EditObj.se1_SelectUnitButton < 1)
        this.game.EditObj.se1_SelectUnitButton = 9;
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 277, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 160, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 166, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 204, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 293, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 306, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 310, 0, 0));
      int unitSelected = this.game.EditObj.UnitSelected;
      int num1 = -1;
      int index1 = -1;
      int num2 = -1;
      int index2 = -1;
      int specId = -1;
      SimpleList simpleList1 = SimpleList::new();
      SizeF sizeF1 = SizeF::new();
      int x1 = useRect.X;
      int y1 = useRect.Y;
      Bitmap bitmap;
      Rectangle trect;
      Rectangle rectangle;
      if (useRect.Width > 1280)
      {
         Graphics local1 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_UNITFRAME);
         Bitmap local2 =  bitmap;
        trect = new Rectangle(0, 0, 980, this.h);
        Rectangle srcrect1 = trect;
        rectangle = new Rectangle(x1, y1, 980, this.h);
        Rectangle destrect1 = rectangle;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
        int x2 = x1 + 980;
        int width;
        for (int index3 = useRect.Width - 980; index3 > 300; index3 -= width)
        {
          width = index3 - 300;
          if (width > 300)
            width = 300;
           Graphics local3 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_UNITFRAME);
           Bitmap local4 =  bitmap;
          rectangle = new Rectangle(690, 0, width, this.h);
          Rectangle srcrect2 = rectangle;
          trect = new Rectangle(x2, y1, width, this.h);
          Rectangle destrect2 = trect;
          DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
          x2 += width;
        }
         Graphics local5 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_UNITFRAME);
         Bitmap local6 =  bitmap;
        rectangle = new Rectangle(980, 0, 300, this.h);
        Rectangle srcrect3 = rectangle;
        trect = new Rectangle(x2, y1, 300, this.h);
        Rectangle destrect3 = trect;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      else
      {
         Graphics local7 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_UNITFRAME);
         Bitmap local8 =  bitmap;
        int x3 = x1;
        int y2 = y1;
        DrawMod.DrawSimple( local7,  local8, x3, y2);
      }
      if (this.game.EditObj.UnitSelected <= -1)
        return;
      int num3 =  Math.Round(Math.Floor((double) (useRect.Width - 652) / 156.0));
      Graphics g1 = g;
      rectangle = new Rectangle(useRect.X + 600, useRect.Y, num3 * 156, 222);
      Rectangle useRect1 = rectangle;
      int se1UnitPage = this.game.EditObj.se1_UnitPage;
      Coordinate coordinate = this.TroopTab(g1, useRect1, se1UnitPage);
      this.game.EditObj.se1_UnitPage = coordinate.x;
      int y3 = coordinate.y;
      int x4 = useRect.X + useRect.Width - 56;
      int num4 =  Math.Round(Math.Floor(200.0 / (double) y3)) - 4;
      int num5 = y3;
      for (int index4 = 1; index4 <= num5; index4 += 1)
      {
        int y4 = 5 + (index4 - 1) * num4;
        if (index4 > 1)
          y4 += 4 * (index4 - 1);
        this += 1.unitButtonCounter;
        tDescript: String = index4.ToString() + "/" + y3.ToString() + ". Click to view this Troops page.";
        if (this.game.EditObj.se1_UnitPage == index4)
          tDescript = index4.ToString() + "/" + y3.ToString() + ". Currently selected Troops page for this Unit";
        int[] unitButton = this.unitButton;
        int unitButtonCounter = this.unitButtonCounter;
        let mut tsubpart: SubPartClass =  new SEBigTextPartClass(index4.ToString(), tDescript, this.game.EditObj.se1_UnitPage == index4, 44, num4);
        int num6 = this.AddSubPart( tsubpart, x4, y4, 44, num4, 1);
        unitButton[unitButtonCounter] = num6;
        this.unitButtonData[this.unitButtonCounter] = 50 + index4;
      }
      int x5 = useRect.X;
      int y5 = useRect.Y;
      this += 1.unitButtonCounter;
      tDescript1: String = "Currently selected Unit";
      int[] unitButton1 = this.unitButton;
      int unitButtonCounter1 = this.unitButtonCounter;
      let mut tsubpart1: SubPartClass =  new SEUnitBigButtonPartClass(this.game.EditObj.UnitSelected, tDescript1, this.game.EditObj.se1_SelectUnitButton == 9);
      int num7 = this.AddSubPart( tsubpart1, x5 + 20, y5 + 8, 93, 97, 1);
      unitButton1[unitButtonCounter1] = num7;
      this.unitButtonData[this.unitButtonCounter] = 9;
      int x6 = useRect.X + 118;
      int y6 = useRect.Y + 8;
      int regime;
      int id;
      int num8;
      if (unitSelected > -1)
      {
        regime = this.game.Data.UnitObj[unitSelected].Regime;
        id = this.game.Data.RegimeObj[regime].id;
        num8 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, id, 1)));
        name: String = this.game.Data.UnitObj[unitSelected].Name;
        index1 = this.game.Data.UnitObj[unitSelected].HQ;
        index2 = this.game.Data.UnitObj[unitSelected].Historical;
        if (index2 > -1)
        {
          if (num8 == 1)
          {
            if (index2 > -1)
            {
              num2 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(61);
              if (num2 > 0 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, num2, 6))) < 1)
              {
                num2 = -1;
                this.game.Data.HistoricalUnitObj[index2].SetHisVarValue(61, 0);
              }
            }
            if (!this.game.Data.UnitObj[unitSelected].IsHQ && index1 > -1)
            {
              specId = this.game.Data.UnitObj[index1].Historical;
              if (specId > -1)
                num2 = this.game.Data.HistoricalUnitObj[specId].GiveHisVarValue(61);
            }
          }
          else
            num2 = this.game.EventRelatedObj.Helper_GetCharacterId(id, 11, id, -1);
          if (this.game.Data.HistoricalUnitObj[index2].Type == 8)
            num1 = unitSelected;
        }
      }
      int idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, id, 2)));
      int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue1, 1)));
      int num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(0, idValue2, 6)));
      int index5 = unitSelected;
      if (index5 == -1)
        return;
      Coordinate reconMinusHide;
      if (this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn | this.game.Data.Round == 0 | !this.game.Data.FOWOn)
        reconMinusHide.x = 3;
      else
        reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(index5, this.game.Data.Turn);
      str1: String = "Reg";
      str2: String = "Type of Unit:\r\nRegular unit";
      if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, id, 1))) == 1)
      {
        if (this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(11) > 0)
        {
          str1 = "Mil";
          str2 = "Type of Unit:\r\nMilitia unit";
        }
      }
      else if (this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(11) > 0)
      {
        str1 = "Min";
        str2 = "Type of Unit:\r\nMinor or allied unit";
      }
      if (reconMinusHide.x < 2)
      {
        str1 = "?";
        str2 = "Type of Unit:\r\nUnknown";
      }
      Left1: String = str1;
      str3: String = str2;
      tDataString2_1: String = "";
      int selectUnitButton = this.game.EditObj.se1_SelectUnitButton;
      if (this.calledFromNonCardSelectWindow)
        this.game.EditObj.se1_SelectUnitButton = -1;
      str4: String = "Troop Quality Settings:\r\n";
      int num10 = 0;
      int num11 = 0;
      int num12 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(42);
      if (num12 == 0)
      {
        num10 = 2;
        num11 += 1;
        str4 += "-Low quality allowed\r\n";
      }
      if (num12 == 1)
        str4 += "-Low quality tolerated\r\n";
      int num13 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(43);
      if (num13 == 0)
      {
        num10 = 3;
        num11 += 1;
        str4 += "-Medium quality allowed\r\n";
      }
      if (num13 == 1)
        str4 += "-Medium quality tolerated\r\n";
      int num14 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(44);
      if (num14 == 0)
      {
        num10 = 4;
        num11 += 1;
        str4 += "-High quality allowed\r\n";
      }
      if (num14 == 1)
        str4 += "-High quality tolerated\r\n";
      int num15 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(45);
      if (num15 == 0)
      {
        num10 = 5;
        num11 += 1;
        str4 += "-Elite quality allowed\r\n";
      }
      if (num15 == 1)
        str4 += "-Elite quality tolerated\r\n";
      str5: String = "N/a";
      if (num10 == 2)
        str5 = "Low";
      if (num10 == 3)
        str5 = "Med";
      if (num10 == 4)
        str5 = "High";
      if (num10 == 5)
        str5 = "Eli";
      if (num11 > 1)
        str5 = "Mix";
      string tDataString1;
      string tDescript2;
      string str6;
      if (Operators.CompareString(Left1, "Min", false) == 0 | Operators.CompareString(Left1, "Mil", false) == 0)
      {
        tDataString1 = Left1;
        tDescript2 = str3;
      }
      else if (reconMinusHide.x < 3)
      {
        str6 = "";
        str7: String = "Troop Quality Settings are Unknown";
        tDataString1 = Left1;
        tDescript2 = str3 + "\r\n" + str7;
      }
      else
      {
        tDataString2_1 = str5;
        tDataString1 = Left1;
        tDescript2 = str4 + "\r\n" + str3;
      }
      this += 1.unitButtonCounter;
      int[] unitButton2 = this.unitButton;
      int unitButtonCounter2 = this.unitButtonCounter;
      let mut tsubpart2: SubPartClass =  new SEUnitButtonPartClass(33, tDataString1, tDataString2_1, tDescript2, this.game.EditObj.se1_SelectUnitButton == 1);
      int num16 = this.AddSubPart( tsubpart2, x6, y6, 44, 97, 1);
      unitButton2[unitButtonCounter2] = num16;
      this.unitButtonData[this.unitButtonCounter] = 1;
      int x7 = x6 + 49;
      tDataString2_2: String = "";
      int index6 = this.game.HandyFunctionsObj.GetLowestAp(index5);
      tDataString2: String = index6.ToString();
      tDescript3: String = "Action Points";
      if (num1 > -1)
        tDataString2 = "0";
      if (this.game.Data.UnitObj[index5].Regime != this.game.Data.Turn & !this.game.SuperAdminRights)
        tDataString2 = "-";
      if (reconMinusHide.x < 2)
        tDataString2 = "?";
      if (this.game.Data.UnitObj[index5].SFCount == -1)
        tDataString2 = "-";
      this += 1.unitButtonCounter;
      int[] unitButton3 = this.unitButton;
      int unitButtonCounter3 = this.unitButtonCounter;
      let mut tsubpart3: SubPartClass =  new SEUnitButtonPartClass(31, tDataString2, tDataString2_2, tDescript3, this.game.EditObj.se1_SelectUnitButton == 2);
      int num17 = this.AddSubPart( tsubpart3, x7, y6, 51, 97, 1);
      unitButton3[unitButtonCounter3] = num17;
      this.unitButtonData[this.unitButtonCounter] = 2;
      int x8 = x7 + 49;
      if (this.game.Data.UnitObj[index5].SOReplacementPercent >= 1)
        ;
      int num18 = this.game.HandyFunctionsObj.GetAverageRdn(index5);
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(index5, num18);
        float num19 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num20 = (float) ((1.0 - (double) num19) * 2.0);
        float num21 = VBMath.Rnd() * num20 + num19;
        num18 =  Math.Round((double) ((float) num18 * num21));
        if (num18 < 0)
          num18 = 0;
        if (num18 > 100)
          num18 = 100;
      }
      str6 = Conversion.Str((object) num18);
      if (reconMinusHide.x < 2)
        str6 = "?";
      int r;
      int g2;
      int b;
      if (reconMinusHide.x >= 2 & this.game.Data.UnitObj[index5].SFCount > -1)
      {
        if (num18 >= 75)
        {
          r = 0;
          g2 =  byte.MaxValue;
          b = 0;
        }
        else if (num18 >= 50)
        {
          r =  byte.MaxValue;
          g2 =  byte.MaxValue;
          b = 0;
        }
        else if (num18 >= 25)
        {
          r = 0;
          g2 = 170;
          b =  byte.MaxValue;
        }
        else
        {
          r =  byte.MaxValue;
          g2 = 0;
          b = 0;
        }
      }
      tDataString2_3: String = "";
      tDataString3: String = num18.ToString();
      tDescript4: String = "Readiness";
      if (this.game.Data.UnitObj[index5].SFCount == -1)
        tDataString3 = "-";
      this += 1.unitButtonCounter;
      int[] unitButton4 = this.unitButton;
      int unitButtonCounter4 = this.unitButtonCounter;
      let mut tsubpart4: SubPartClass =  new SEUnitButtonPartClass(32, tDataString3, tDataString2_3, tDescript4, this.game.EditObj.se1_SelectUnitButton == 3);
      int num22 = this.AddSubPart( tsubpart4, x8, y6, 51, 97, 1);
      unitButton4[unitButtonCounter4] = num22;
      this.unitButtonData[this.unitButtonCounter] = 3;
      int x9 = useRect.X + 20;
      int y7 = useRect.Y + 110;
      int i1 = this.game.HandyFunctionsObj.GetAverageMor(index5);
      tDataString2_4: String = "";
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(index5, i1);
        float num23 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num24 = (float) ((1.0 - (double) num23) * 2.0);
        float num25 = VBMath.Rnd() * num24 + num23;
        i1 =  Math.Round((double) ((float) i1 * num25));
        if (i1 < 0)
          i1 = 0;
        if (i1 > 100)
          i1 = 100;
      }
      tDataString4: String = i1.ToString();
      tDescript5: String = "Morale";
      if (reconMinusHide.x < 2)
        tDataString4 = "?";
      if (this.game.Data.UnitObj[index5].SFCount == -1)
        tDataString4 = "-";
      this += 1.unitButtonCounter;
      int[] unitButton5 = this.unitButton;
      int unitButtonCounter5 = this.unitButtonCounter;
      let mut tsubpart5: SubPartClass =  new SEUnitButtonPartClass(35, tDataString4, tDataString2_4, tDescript5, this.game.EditObj.se1_SelectUnitButton == 4);
      int num26 = this.AddSubPart( tsubpart5, x9, y7, 51, 97, 1);
      unitButton5[unitButtonCounter5] = num26;
      this.unitButtonData[this.unitButtonCounter] = 4;
      int x10 = x9 + 49;
      int i2 = this.game.HandyFunctionsObj.GetAverageXp(index5);
      tDataString2_5: String = "";
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(index5, i2);
        float num27 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num28 = (float) ((1.0 - (double) num27) * 2.0);
        float num29 = VBMath.Rnd() * num28 + num27;
        i2 =  Math.Round((double) ((float) i2 * num29));
        if (i2 < 0)
          i2 = 0;
        if (i2 > 100)
          i2 = 100;
      }
      tDataString5: String = i2.ToString();
      if (reconMinusHide.x < 2)
        tDataString5 = "?";
      if (this.game.Data.UnitObj[index5].SFCount == -1)
        tDataString5 = "-";
      tDescript6: String = "Experience";
      this += 1.unitButtonCounter;
      int[] unitButton6 = this.unitButton;
      int unitButtonCounter6 = this.unitButtonCounter;
      let mut tsubpart6: SubPartClass =  new SEUnitButtonPartClass(34, tDataString5, tDataString2_5, tDescript6, this.game.EditObj.se1_SelectUnitButton == 5);
      int num30 = this.AddSubPart( tsubpart6, x10, y7, 51, 97, 1);
      unitButton6[unitButtonCounter6] = num30;
      this.unitButtonData[this.unitButtonCounter] = 5;
      int x11 = x10 + 49;
      int i3 = this.game.HandyFunctionsObj.GetAverageEntrench(index5);
      tDataString2_6: String = "";
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(index5, i3);
        float num31 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num32 = (float) ((1.0 - (double) num31) * 2.0);
        float num33 = VBMath.Rnd() * num32 + num31;
        i3 =  Math.Round((double) ((float) i3 * num33));
        if (i3 < 0)
          i3 = 0;
        if (i3 > 100)
          i3 = 100;
      }
      tDataString6: String = i3.ToString();
      if (reconMinusHide.x < 2)
        tDataString6 = "?";
      if (this.game.Data.UnitObj[index5].SFCount == -1)
        tDataString6 = "-";
      tDescript7: String = "Entrenchment";
      this += 1.unitButtonCounter;
      int[] unitButton7 = this.unitButton;
      int unitButtonCounter7 = this.unitButtonCounter;
      let mut tsubpart7: SubPartClass =  new SEUnitButtonPartClass(36, tDataString6, tDataString2_6, tDescript7, this.game.EditObj.se1_SelectUnitButton == 6);
      int num34 = this.AddSubPart( tsubpart7, x11, y7, 51, 97, 1);
      unitButton7[unitButtonCounter7] = num34;
      this.unitButtonData[this.unitButtonCounter] = 6;
      int x12 = x11 + 49;
      tDataString2_7: String = "";
      int Number = this.game.HandyFunctionsObj.Gethqpow(index5);
      if (this.game.Data.UnitObj[index5].IsHQ)
        Number = 100;
      tDataString7: String = Conversions.ToString(Number);
      if (reconMinusHide.x == 2)
        tDataString7 = "?";
      if (reconMinusHide.x < 2)
        tDataString7 = "?";
      tDescript8: String = "HQ Power\r\nSkills of OHQ Commander are " + Strings.Trim(Conversion.Str((object) Number)) + "% effective.";
      this += 1.unitButtonCounter;
      int[] unitButton8 = this.unitButton;
      int unitButtonCounter8 = this.unitButtonCounter;
      let mut tsubpart8: SubPartClass =  new SEUnitButtonPartClass(1, tDataString7, tDataString2_7, tDescript8, this.game.EditObj.se1_SelectUnitButton == 7);
      int num35 = this.AddSubPart( tsubpart8, x12, y7, 51, 97, 1);
      unitButton8[unitButtonCounter8] = num35;
      this.unitButtonData[this.unitButtonCounter] = 7;
      int x13 = x12 + 49;
      int tOverruleR = -1;
      int tOverruleG = -1;
      int tOverruleB = -1;
      SimpleList simpleList2 = SimpleList::new();
      int num36 = 100;
      if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index5].Historical].Type < 8)
      {
        int logCounter = this.game.Data.UnitObj[index5].LogCounter;
        for (int index7 = 0; index7 <= logCounter; index7 += 1)
        {
          if (this.game.Data.UnitObj[index5].LogType[index7] == 202)
          {
            index6 = this.game.Data.UnitObj[index5].LogData1[index7];
            int tweight = this.game.Data.UnitObj[index5].LogData3[index7];
            int nr = simpleList2.FindNr(index6);
            if (nr == -1)
            {
              simpleList2.Add(index6, tweight);
            }
            else
            {
              int[] weight = simpleList2.Weight;
              int[] numArray = weight;
              int index8 = nr;
              int index9 = index8;
              int num37 = weight[index8] + tweight;
              numArray[index9] = num37;
            }
          }
          else if (this.game.Data.UnitObj[index5].LogType[index7] == 105)
          {
            index6 = this.game.Data.UnitObj[index5].LogData1[index7];
            int tdata1 = this.game.Data.UnitObj[index5].LogData3[index7];
            int nr = simpleList2.FindNr(index6);
            if (nr == -1)
            {
              simpleList2.Add(index6, 0, tdata1);
            }
            else
            {
              int[] data1 = simpleList2.Data1;
              int[] numArray = data1;
              int index10 = nr;
              int index11 = index10;
              int num38 = data1[index10] + tdata1;
              numArray[index11] = num38;
            }
          }
        }
        int counter = simpleList2.Counter;
        int num39;
        int num40;
        for (int index12 = 0; index12 <= counter; index12 += 1)
        {
          if (simpleList2.Weight[index12] - simpleList2.Data1[index12] > num39 - num40)
          {
            num39 = simpleList2.Weight[index12];
            num40 = simpleList2.Data1[index12];
          }
        }
        if (num39 > 0 & num40 < num39)
        {
          int num41 =  Math.Round((double) (num40 * 100) / (double) num39);
          if (num41 < 25)
          {
            tOverruleR =  byte.MaxValue;
            tOverruleG = 150;
            tOverruleB = 150;
          }
          else if (num41 < 50)
          {
            tOverruleR = 150;
            tOverruleG =  byte.MaxValue;
            tOverruleB =  byte.MaxValue;
          }
          else if (num41 < 75)
          {
            tOverruleR =  byte.MaxValue;
            tOverruleG =  byte.MaxValue;
            tOverruleB = 150;
          }
          else
          {
            tOverruleR = 200;
            tOverruleG =  byte.MaxValue;
            tOverruleB = 150;
          }
          num36 = num41;
        }
      }
      tDataString2_8: String = "";
      tDataString8: String = num36.ToString();
      if (reconMinusHide.x == 2)
        tDataString8 = "?";
      if (reconMinusHide.x < 2)
        tDataString8 = "?";
      tDescript9: String = "Supply Received\r\nIf less Supplies received than requested this turn this value will drop below 100. ";
      this += 1.unitButtonCounter;
      int[] unitButton9 = this.unitButton;
      int unitButtonCounter9 = this.unitButtonCounter;
      let mut tsubpart9: SubPartClass =  new SEUnitButtonPartClass(37, tDataString8, tDataString2_8, tDescript9, this.game.EditObj.se1_SelectUnitButton == 8, tOverruleR, tOverruleG, tOverruleB);
      int num42 = this.AddSubPart( tsubpart9, x13, y7, 51, 97, 1);
      unitButton9[unitButtonCounter9] = num42;
      this.unitButtonData[this.unitButtonCounter] = 8;
      int num43 = x13 + 49;
      string str8;
      if (this.game.EditObj.se1_SelectUnitButton == 9)
      {
        int num44 = useRect.X + 278;
        int y8 = 11;
        if (this.game.Data.UnitObj[index5].IsHQ)
          tDataString8 = this.game.Data.UnitObj[index5].Name;
        else if (index1 > -1)
          tDataString8 = this.game.Data.UnitObj[index1].Name;
        index6 = !(index1 > -1 & !this.game.Data.UnitObj[index5].IsHQ) ? this.game.Data.UnitObj[index5].Historical : this.game.Data.UnitObj[index1].Historical;
        int idValue3 = this.game.Data.HistoricalUnitObj[index6].GiveHisVarValue(21);
        if (idValue3 > 0 & reconMinusHide.x >= 2)
        {
          int nr = this.game.Data.EventPicNr[ Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue3, 3)))];
           Graphics local9 =  g;
          bitmap = BitmapStore.GetBitmap(nr);
           Bitmap local10 =  bitmap;
          rectangle = new Rectangle(7, 6, 175, 163);
          Rectangle srcrect = rectangle;
          trect = new Rectangle(num44 + 5, y8, 288, 192);
          Rectangle destrect = trect;
          DrawMod.DrawSimplePart2ColouredNew( local9,  local10, srcrect, destrect, 1f, 1f, 1f, 0.2f);
        }
        if (index1 > -1 | this.game.Data.UnitObj[index5].IsHQ)
        {
          str3 = "";
          Left2: String = "";
          str9: String = "";
          str10: String = "";
          if (num2 > 0)
          {
            str3 = this.game.Data.StringListObj[stringListById4].GetData(0, num2, 3);
            Left2 = this.game.Data.StringListObj[stringListById4].GetData(0, num2, 4);
            str9 = "Commander of";
            Left1 = tDataString8;
            if (num8 > 1)
            {
              Left2 = this.game.Data.StringListObj[stringListById2].GetData(0, id, 10);
              if (Operators.CompareString(Left2, "", false) == 0)
                Left2 = "Leader";
            }
            if (this.game.Data.UnitObj[index5].IsHQ)
            {
              int historical = this.game.Data.UnitObj[index5].Historical;
              if (historical > -1)
                index6 = this.game.Data.HistoricalUnitObj[historical].Type >= 8 ? this.game.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num2, 4, specId) : this.game.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num2, 3, specId);
            }
            else if (index1 > -1)
            {
              int historical = this.game.Data.UnitObj[index1].Historical;
              if (historical > -1)
                index6 = this.game.Data.HistoricalUnitObj[historical].Type >= 8 ? this.game.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num2, 4, specId) : this.game.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num2, 3, specId);
            }
            str10 = "Suitability: " + index6.ToString();
            if (this.game.Data.UnitObj[index5].Regime != this.game.Data.Turn)
              str10 = "";
          }
          else if (num9 > 0)
          {
            str9 = "Vacant Commander";
            Left1 = "Post for:";
            str3 = tDataString8;
            str10 = "";
          }
          if (reconMinusHide.x < 2)
          {
            str9 = "";
            Left1 = "Unknown";
            str3 = "Commander";
            Left2 = "";
            str10 = "";
          }
          if (num2 > 0 & reconMinusHide.x >= 2)
          {
            DrawMod.DrawTextColouredConsole( g, str3 + " " + Left2, DrawMod.TGame.se1TypeWriterMedium, num44 + 90, y8 + 8, DrawMod.TGame.seColTW);
            if (str10.Length > 1)
              Left1 = Left1.Length <= 38 ? Left1 + "\r\n" + str10 : Left1 + ". " + str10;
            DrawMod.DrawTextColouredConsoleMultiline( g, str9 + " " + Left1, DrawMod.TGame.se1TypeWriterSmall, num44 + 90, y8 + 28, DrawMod.TGame.seColTW, 210, 80);
          }
          else
          {
            DrawMod.DrawBlock( g, num44 + 11, y8 + 9, 75, 105, 0, 0, 0, 64);
            tstring: String = str9 + "\r\n" + Left1 + "\r\n" + str3 + " " + Left2;
            DrawMod.DrawTextColouredConsoleMultiline( g, tstring, DrawMod.TGame.se1TypeWriterSmall, num44 + 90, y8 + 8, DrawMod.TGame.seColTW, 210, 80);
          }
          if (reconMinusHide.x >= 2)
          {
             Graphics local11 =  g;
            bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(num2, 75, 105, true);
             Bitmap local12 =  bitmap;
            int x14 = num44 + 11;
            int y9 = y8 + 9;
            DrawMod.DrawSimple( local11,  local12, x14, y9);
            if (num2 > 0)
            {
              if (regime == this.game.Data.Turn)
              {
                rectangle = new Rectangle(num44 + 11, y8 + 9, 75, 105);
                trect = rectangle;
                this.AddMouse( trect, "Commander", "Click for more information.", 201, num2);
              }
              else
              {
                rectangle = new Rectangle(num44 + 11, y8 + 9, 75, 105);
                trect = rectangle;
                this.AddMouse( trect, "Commander", "Picture of Commander.");
              }
            }
          }
          bool flag = false;
          if (regime == this.game.Data.Turn & num2 > 0)
          {
            if (index1 > -1 & index1 != this.game.EditObj.UnitSelected)
            {
              this += 1.unitButtonCounter;
              flag = true;
              if (this.game.Data.UnitObj[index5].IsHQ)
              {
                int[] unitButton10 = this.unitButton;
                int unitButtonCounter10 = this.unitButtonCounter;
                let mut tsubpart10: SubPartClass =  new TextButtonPartClass("To SHQ", 65, "Click to go to the SHQ of this HQ.",  this.OwnBitmap, num44 + 155, y8 + 84, theight: 32, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
                int num45 = this.AddSubPart( tsubpart10, num44 + 155, y8 + 84, 65, 32, 1);
                unitButton10[unitButtonCounter10] = num45;
              }
              else
              {
                int[] unitButton11 = this.unitButton;
                int unitButtonCounter11 = this.unitButtonCounter;
                let mut tsubpart11: SubPartClass =  new TextButtonPartClass("To HQ", 65, "Click to select the HQ Unit where the Units direct Commander is.",  this.OwnBitmap, num44 + 155, y8 + 84, theight: 32, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
                int num46 = this.AddSubPart( tsubpart11, num44 + 155, y8 + 84, 65, 32, 1);
                unitButton11[unitButtonCounter11] = num46;
              }
              this.unitButtonData[this.unitButtonCounter] = 81;
            }
            this += 1.unitButtonCounter;
            if (flag)
            {
              int[] unitButton12 = this.unitButton;
              int unitButtonCounter12 = this.unitButtonCounter;
              let mut tsubpart12: SubPartClass =  new TextButtonPartClass("Call", 65, "Give this Commander a call. For example to relieve him/her from command.",  this.OwnBitmap, num44 + 90, y8 + 84, theight: 32, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
              int num47 = this.AddSubPart( tsubpart12, num44 + 90, y8 + 84, 65, 32, 1);
              unitButton12[unitButtonCounter12] = num47;
            }
            else
            {
              int[] unitButton13 = this.unitButton;
              int unitButtonCounter13 = this.unitButtonCounter;
              let mut tsubpart13: SubPartClass =  new TextButtonPartClass("Call", 65, "Give this Commander a call. For example to relieve him/her from command.",  this.OwnBitmap, num44 + 90, y8 + 84, theight: 32, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
              int num48 = this.AddSubPart( tsubpart13, num44 + 90, y8 + 84, 65, 32, 1);
              unitButton13[unitButtonCounter13] = num48;
            }
            this.unitButtonData[this.unitButtonCounter] = 201;
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].Type < 8)
            {
              this += 1.unitButtonCounter;
              int[] unitButton14 = this.unitButton;
              int unitButtonCounter14 = this.unitButtonCounter;
              let mut tsubpart14: SubPartClass =  new TextButtonPartClass("Strat", 65, "Play a Stratagem on this Commander.",  this.OwnBitmap, num44 + 220, y8 + 84, theight: 32, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
              int num49 = this.AddSubPart( tsubpart14, num44 + 220, y8 + 84, 65, 32, 1);
              unitButton14[unitButtonCounter14] = num49;
              this.unitButtonData[this.unitButtonCounter] = 202;
            }
            this.tempCharId = num2;
          }
          else if (reconMinusHide.x >= 2 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
          {
            tstring: String = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ != -1 ? "Is under " + this.game.Data.UnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ].Name + "." : "Is not under any SHQ.";
            DrawMod.DrawTextColouredConsole( g, tstring, DrawMod.TGame.se1TypeWriterSmall, num44 + 90, y8 + 84, DrawMod.TGame.seColTW);
          }
        }
        index6 = !(index1 > -1 & !this.game.Data.UnitObj[index5].IsHQ) ? this.game.Data.UnitObj[index5].Historical : this.game.Data.UnitObj[index1].Historical;
        str8 = "";
        num10 = -1;
        string ttitle;
        string ttext;
        if (index6 > -1 & reconMinusHide.x >= 2)
        {
          num10 = this.game.Data.HistoricalUnitObj[index6].GiveHisVarValue(21);
          if (num10 > 0)
          {
            str3 = this.game.Data.StringListObj[stringListById1].GetData(0, num10, 1);
            ttitle = "Posture: " + str3;
            ttext = this.game.Data.StringListObj[stringListById1].GetData(0, num10, 4);
          }
          else
          {
            ttitle = "No Posture";
            ttext = "No bonuses or penalties are applied.";
          }
        }
        else
        {
          ttitle = "No Posture";
          ttext = "No bonuses or penalties are applied.";
          if (reconMinusHide.x < 2)
          {
            ttitle = "Unknown Posture";
            ttext = "We do not have enough Recon on this Unit to determine its Posture.";
          }
        }
        string tstring1;
        if (num10 > 0)
        {
          int nr = this.game.Data.EventPicNr[ Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, num10, 3)))];
           Graphics local13 =  g;
          bitmap = BitmapStore.GetBitmap(nr);
           Bitmap local14 =  bitmap;
          rectangle = new Rectangle(5, 58, 180, 90);
          Rectangle srcrect = rectangle;
          trect = new Rectangle(num44 + 275 - 130, y8 + 120, 130, 65);
          Rectangle destrect = trect;
          DrawMod.DrawSimplePart2( local13,  local14, srcrect, destrect);
          tstring1 = str3.Replace(" ", "\r\n");
        }
        else
          tstring1 = ttitle;
        DrawMod.DrawTextColouredConsole( g, "POSTURE:", DrawMod.TGame.se1TypeWriterSmall, num44 + 8, y8 + 120, DrawMod.TGame.seColTW);
        DrawMod.DrawTextColouredConsole( g, tstring1, DrawMod.TGame.se1TypeWriterMedium, num44 + 8, y8 + 136, DrawMod.TGame.seColTW);
        rectangle = new Rectangle(num44 + 10, y8 + 120, 275, 65);
        trect = rectangle;
        this.AddMouse( trect, ttitle, ttext);
      }
      if (this.game.EditObj.se1_SelectUnitButton == 1)
      {
        int num50 = useRect.X + 278;
        int num51 = 11;
        str11: String = "Regular";
        tstring2: String = "Fully under you control and depend on their SHQ for Supply deliveries.";
        index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, id, 1)));
        if (index6 == 1)
        {
          if (this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(11) > 0)
          {
            str11 = "Militia";
            tstring2 = "Nomally under your control. They supply themselves from their Zone of origin.";
          }
        }
        else if (this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(11) > 0)
        {
          str11 = "Minor";
          tstring2 = "Much like Militia units, but they are under control of a Minor Regime.";
        }
        if (reconMinusHide.x < 2)
          str11 = "Unknown";
        DrawMod.DrawTextColouredConsoleCenter( g, str11, DrawMod.TGame.se1TypeWriterMedium, num50 + 116 + 42, num51 + 6, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num50 + 6, num51 + 26, num50 + 290, num51 + 26, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring2, DrawMod.TGame.se1TypeWriterSmall, num50 + 6, num51 + 26, DrawMod.TGame.seColTW, 290, 60);
        string tstring3;
        string tstring4;
        if (Operators.CompareString(str11, "Regular", false) == 0)
        {
          tstring3 = "Troop Quality Settings";
          tstring4 = "";
          num10 = 0;
          int num52 = 0;
          index6 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(42);
          if (index6 == 0)
          {
            num10 = 2;
            num52 += 1;
            tstring4 += "-Low quality allowed\r\n";
          }
          if (index6 == 1)
            tstring4 += "-Low quality tolerated\r\n";
          index6 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(43);
          if (index6 == 0)
          {
            num10 = 3;
            num52 += 1;
            tstring4 += "-Medium quality allowed\r\n";
          }
          if (index6 == 1)
            tstring4 += "-Medium quality tolerated\r\n";
          index6 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(44);
          if (index6 == 0)
          {
            num10 = 4;
            num52 += 1;
            tstring4 += "-High quality allowed\r\n";
          }
          if (index6 == 1)
            tstring4 += "-High quality tolerated\r\n";
          index6 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(45);
          if (index6 == 0)
          {
            num10 = 5;
            int num53 = num52 + 1;
            tstring4 += "-Elite quality allowed\r\n";
          }
          if (index6 == 1)
            tstring4 += "-Elite quality tolerated\r\n";
        }
        else
        {
          tstring3 = "Troop Quality Settings";
          tstring4 = "-These troops do not use quality levels";
        }
        DrawMod.DrawTextColouredConsoleCenter( g, tstring3, DrawMod.TGame.se1TypeWriterMedium, num50 + 116 + 42, num51 + 100, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num50 + 6, num51 + 120, num50 + 290, num51 + 120, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring4, DrawMod.TGame.se1TypeWriterSmall, num50 + 6, num51 + 120, DrawMod.TGame.seColTW, 290, 80);
      }
      SizeF sizeF2;
      if (this.game.EditObj.se1_SelectUnitButton == 2)
      {
        int num54 = useRect.X + 278;
        int num55 = 11;
        DrawMod.DrawBlock( g, num54 + 10, num55 + 6, 275, 40, 0, 0, 0, 32);
        Coordinate moveTypeLogo = this.game.HandyFunctionsObj.GetMoveTypeLogo(index5,  reconMinusHide, true);
        str6 = "n/a";
        str12: String = !(moveTypeLogo.x > -1 & moveTypeLogo.y > -1) ? (moveTypeLogo.x <= -1 ? (this.game.Data.UnitObj[index5].SFCount != -1 ? "Unknown" : "No Move Type") : "Immobile") : (this.game.Data.SFObj[moveTypeLogo.y].MoveType <= -1 ? this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[moveTypeLogo.y].Type].MoveType] : this.game.Data.TempString[this.game.Data.SFObj[moveTypeLogo.y].MoveType]);
        sizeF2 = g.MeasureString(str12, DrawMod.TGame.se1TypeWriterMedium);
        if (moveTypeLogo.y > -1)
        {
          index6 =  Math.Round(154.0 - ((double) sizeF2.Width / 2.0 + 20.0));
          if (this.game.Data.SFTypeObj[this.game.Data.SFObj[moveTypeLogo.y].Type].SFTypeVar[81] > 0)
          {
            Bitmap objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(this.game.Data.SFObj[moveTypeLogo.y].Type, false, 1, this.game.Data.Turn, index5);
            num10 = objBitmap.Width;
            int h = objBitmap.Height;
            if (num10 > 64)
            {
              h =  Math.Round((double) (h * 64) / (double) num10);
              num10 = 64;
            }
            if (h > 40)
            {
              num10 =  Math.Round((double) (num10 * 40) / (double) h);
              h = 40;
            }
            DrawMod.DrawScaled( g,  objBitmap,  Math.Round((double) (num54 + index6) - (double) num10 / 2.0), num55 + 5, num10, h, true);
          }
          DrawMod.DrawTextColouredConsole( g, str12, DrawMod.TGame.se1TypeWriterMedium,  Math.Round((double) (num54 + index6) + (double) num10 / 2.0), num55 + 17, DrawMod.TGame.seColTW);
        }
        else
        {
          index6 =  Math.Round(154.0 - (double) sizeF2.Width / 2.0);
          DrawMod.DrawTextColouredConsole( g, str12, DrawMod.TGame.se1TypeWriterMedium, num54 + index6, num55 + 17, DrawMod.TGame.seColTW);
        }
        tstring5: String = "Start Turn AP Calc.";
        tstring6: String = "" + "Oil Consumption = " + this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 13, 4) + "%" + "\r\n";
        int idValue3 = 21;
        do
        {
          data3: String = this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3, 3);
          if (data3.Length > 1)
            tstring6 = tstring6 + data3 + "\r\n";
          idValue3 += 1;
        }
        while (idValue3 <= 25);
        DrawMod.DrawTextColouredConsoleCenter( g, tstring5, DrawMod.TGame.se1TypeWriterMedium, num54 + 116 + 40, num55 + 56, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num54 + 6, num55 + 76, num54 + 290, num55 + 76, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring6, DrawMod.TGame.se1TypeWriterSmall, num54 + 6, num55 + 76, DrawMod.TGame.seColTW, 290, 150);
      }
      if (this.game.EditObj.se1_SelectUnitButton == 3)
      {
        int num56 = useRect.X + 278;
        int num57 = 11;
        DrawMod.DrawBlock( g, num56 + 10, num57 + 6, 275, 40, 0, 0, 0, 32);
        index6 = this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(81);
        str8 = "";
        tstring7: String = index6 != 0 ? (index6 >= 101 ? (index6 >= 201 ? "Dying" : "Starving") : "Hungry") : "Wellfed";
        if (index6 > 0)
          tstring7 = tstring7 + " (" + index6.ToString() + ")";
        DrawMod.DrawTextColouredConsoleCenter( g, tstring7, DrawMod.TGame.se1TypeWriterMedium, num56 + 154, num57 + 17, DrawMod.TGame.seColTW);
        tstring8: String = "Start Turn RDN Calc.";
        tstring9: String = "" + "Upkeep = " + this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 11, 4) + "%" + "\r\n";
        int idValue3_1 = 37;
        do
        {
          data3: String = this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3_1, 3);
          if (data3.Length > 1)
            tstring9 = tstring9 + data3 + "\r\n";
          idValue3_1 += 1;
        }
        while (idValue3_1 <= 38);
        int idValue3_2 = 31;
        do
        {
          if (idValue3_2 != 32 & idValue3_2 != 33)
          {
            data3: String = this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3_2, 3);
            if (data3.Length > 1)
              tstring9 = tstring9 + data3 + "\r\n";
          }
          idValue3_2 += 1;
        }
        while (idValue3_2 <= 36);
        DrawMod.DrawTextColouredConsoleCenter( g, tstring8, DrawMod.TGame.se1TypeWriterMedium, num56 + 116 + 40, num57 + 50, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num56 + 6, num57 + 70, num56 + 290, num57 + 70, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring9, DrawMod.TGame.se1TypeWriterSmall, num56 + 6, num57 + 70, DrawMod.TGame.seColTW, 290, 120);
      }
      if (this.game.EditObj.se1_SelectUnitButton == 4)
      {
        int num58 = useRect.X + 278;
        int num59 = 11;
        tstring10: String = "Start Turn MOR Calc.";
        tstring11: String = "";
        int idValue3 = 41;
        do
        {
          data3: String = this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3, 3);
          if (data3.Length > 1)
            tstring11 = tstring11 + data3 + "\r\n";
          idValue3 += 1;
        }
        while (idValue3 <= 47);
        DrawMod.DrawTextColouredConsoleCenter( g, tstring10, DrawMod.TGame.se1TypeWriterMedium, num58 + 156, num59 + 6, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num58 + 6, num59 + 26, num58 + 290, num59 + 26, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring11, DrawMod.TGame.se1TypeWriterSmall, num58 + 6, num59 + 26, DrawMod.TGame.seColTW, 290, 160);
      }
      if (this.game.EditObj.se1_SelectUnitButton == 5)
      {
        int num60 = useRect.X + 278;
        int num61 = 11;
        tstring12: String = "Start Turn XP Calc.";
        tstring13: String = "";
        int idValue3 = 61;
        do
        {
          data3: String = this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3, 3);
          if (data3.Length > 1)
            tstring13 = tstring13 + data3 + "\r\n";
          idValue3 += 1;
        }
        while (idValue3 <= 68);
        DrawMod.DrawTextColouredConsoleCenter( g, tstring12, DrawMod.TGame.se1TypeWriterMedium, num60 + 156, num61 + 6, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num60 + 6, num61 + 26, num60 + 290, num61 + 26, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring13, DrawMod.TGame.se1TypeWriterSmall, num60 + 6, num61 + 26, DrawMod.TGame.seColTW, 290, 160);
      }
      if (this.game.EditObj.se1_SelectUnitButton == 6)
      {
        int num62 = useRect.X + 278;
        int num63 = 11;
        tstring14: String = "Start Turn ENTR Calc.";
        tstring15: String = "";
        int idValue3 = 71;
        do
        {
          data3: String = this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3, 3);
          if (data3.Length > 1)
            tstring15 = tstring15 + data3 + "\r\n";
          idValue3 += 1;
        }
        while (idValue3 <= 73);
        DrawMod.DrawTextColouredConsoleCenter( g, tstring14, DrawMod.TGame.se1TypeWriterMedium, num62 + 156, num63 + 6, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num62 + 6, num63 + 26, num62 + 290, num63 + 26, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring15, DrawMod.TGame.se1TypeWriterSmall, num62 + 6, num63 + 26, DrawMod.TGame.seColTW, 290, 160);
        index6 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
        name: String = this.game.Data.LandscapeTypeObj[index6].Name;
        str13: String = "Infantry";
        str14: String = "Auto:" + ( Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonus[0])).ToString();
        int num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonusMax[0]);
        str15: String = "Max:" + num64.ToString();
        str16: String = str13 + "\r\n";
        str17: String = str14 + "\r\n";
        str18: String = str15 + "\r\n";
        str19: String = str16 + "Gun";
        str20: String = str17;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonus[1]);
        str21: String = num64.ToString();
        str22: String = str20 + "Auto:" + str21;
        str23: String = str18;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonusMax[1]);
        str24: String = num64.ToString();
        str25: String = str23 + "Max:" + str24;
        str26: String = str19 + "\r\n";
        str27: String = str22 + "\r\n";
        str28: String = str25 + "\r\n";
        str29: String = str26 + "Mobile";
        str30: String = str27;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonus[2]);
        str31: String = num64.ToString();
        str32: String = str30 + "Auto:" + str31;
        str33: String = str28;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonusMax[2]);
        str34: String = num64.ToString();
        str35: String = str33 + "Max:" + str34;
        str36: String = str29 + "\r\n";
        str37: String = str32 + "\r\n";
        str38: String = str35 + "\r\n";
        str39: String = str36 + "Tank";
        str40: String = str37;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonus[3]);
        str41: String = num64.ToString();
        str42: String = str40 + "Auto:" + str41;
        str43: String = str38;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonusMax[3]);
        str44: String = num64.ToString();
        str45: String = str43 + "Max:" + str44;
        str46: String = str39 + "\r\n";
        str47: String = str42 + "\r\n";
        str48: String = str45 + "\r\n";
        str49: String = str46 + "Walker";
        str50: String = str47;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonus[4]);
        str51: String = num64.ToString();
        str52: String = str50 + "Auto:" + str51;
        str53: String = str48;
        num64 =  Math.Round((double) this.game.Data.LandscapeTypeObj[index6].DefBonusMax[4]);
        str54: String = num64.ToString();
        str55: String = str53 + "Max:" + str54;
        tstring16: String = str49 + "\r\n";
        tstring17: String = str52 + "\r\n";
        tstring18: String = str55 + "\r\n";
        DrawMod.DrawTextColouredConsoleCenter( g, name, DrawMod.TGame.se1TypeWriterMedium, num62 + 156, num63 + 86, DrawMod.TGame.seColTW);
        DrawMod.drawLine( g, num62 + 6, num63 + 106, num62 + 290, num63 + 106, Color.Black);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring16, DrawMod.TGame.se1TypeWriterSmall, num62 + 6, num63 + 106, DrawMod.TGame.seColTW, 130, 160);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring17, DrawMod.TGame.se1TypeWriterSmall, num62 + 80, num63 + 106, DrawMod.TGame.seColTW, 70, 160);
        DrawMod.DrawTextColouredConsoleMultiline( g, tstring18, DrawMod.TGame.se1TypeWriterSmall, num62 + 160, num63 + 106, DrawMod.TGame.seColTW, 70, 160);
      }
      int predefnr;
      if (this.game.EditObj.se1_SelectUnitButton == 7)
      {
        int num65 = useRect.X + 278;
        int num66 = 11;
        tstring19: String = "Organisational Info";
        str8 = "";
        if (reconMinusHide.x >= 3)
        {
          index6 = this.game.HandyFunctionsObj.Gethqpow(index5);
          int num67 = 100 - this.game.Data.UnitObj[index5].SODefendPercent;
          predefnr = this.game.Data.UnitObj[index5].SOInterceptRdnStop;
          string str56;
          if (this.game.HandyFunctionsObj.HasUnitAirSF(index5))
          {
            if (predefnr == 100)
              str56 = "HQ: " + index6.ToString() + "%, Rtr: " + num67.ToString() + "%, Never Intercept\r\n";
            else
              str56 = "HQ: " + index6.ToString() + "%, Rtr: " + num67.ToString() + "%, Intcp at " + predefnr.ToString() + " Rdn\r\n";
          }
          else
            str56 = "HQ Power: " + index6.ToString() + "%, Retreat: " + num67.ToString() + "%\r\n";
          int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(index5);
          int replacementPercent = this.game.Data.UnitObj[index5].SOReplacementPercent;
          predefnr = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(index5);
          int num68 =  Math.Round((double) this.game.Data.RuleVar[307]);
          int startPower = this.game.HandyFunctionsObj.GetStartPower(index5);
          index6 =  Math.Round((double) startPower * ((double) breakPercent / 100.0));
          str57: String = startPower != 0 ? Conversions.ToString(Math.Min(100,  Math.Round((double) predefnr / (double) startPower * 100.0))) : "100";
          if (reconMinusHide.x == 2)
            tstring19 = "?";
          if (reconMinusHide.x < 2)
            tstring19 = "?";
          string tstring20;
          if (replacementPercent > 0)
            tstring20 = str56 + "Int: " + str57 + "%, Brk: " + Strings.Trim(Conversion.Str((object) breakPercent)) + "%, Rpl: " + replacementPercent.ToString() + "%";
          else
            tstring20 = str56 + "Int: " + str57 + "%, UNIT IS DISBANDING";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring19, DrawMod.TGame.se1TypeWriterMedium, num65 + 156, num66 + 6, DrawMod.TGame.seColTW);
          DrawMod.drawLine( g, num65 + 6, num66 + 26, num65 + 290, num66 + 26, Color.Black);
          DrawMod.DrawTextColouredConsoleMultiline( g, tstring20, DrawMod.TGame.se1TypeWriterSmall, num65 + 6, num66 + 30, DrawMod.TGame.seColTW, 290, 160);
          index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 22, 4)));
          if (index6 > 0)
          {
            tstring21: String = "Commander Skill effects";
            str58: String = "";
            int num69 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 23, 4)));
            if (index6 > 0)
            {
              predefnr =  Math.Round((double) (num69 * 100) / (double) index6) - 100;
              str58 = str58 + "AP Bonus (OHQ) = " + predefnr.ToString() + "%" + "\r\n";
            }
            index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 32, 4)));
            str59: String = str58 + "Rdn Gain Bonus (OHQ) = " + index6.ToString() + "%" + "\r\n";
            index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 33, 4)));
            str60: String = str59 + "Rdn Gain Bonus (SHQ) = " + index6.ToString() + "%" + "\r\n";
            index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 45, 4)));
            int num70 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 46, 4)));
            if (index6 > 0)
            {
              predefnr =  Math.Round((double) (num70 * 100) / (double) index6) - 100;
              str60 = str60 + "Morale Gain Bonus (OHQ) = " + predefnr.ToString() + "%" + "\r\n";
            }
            index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 66, 4)));
            int num71 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 67, 4)));
            if (index6 > 0)
            {
              predefnr =  Math.Round((double) (num71 * 100) / (double) index6) - 100;
              str60 = str60 + "XP Gain Bonus (OHQ) = " + predefnr.ToString() + "%" + "\r\n";
            }
            index6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, 71, 4)));
            tstring22: String = str60 + "Entr. Gain Bonus (OHQ) = " + index6.ToString() + "%" + "\r\n";
            DrawMod.DrawTextColouredConsoleCenter( g, tstring21, DrawMod.TGame.se1TypeWriterMedium, num65 + 156, num66 + 66, DrawMod.TGame.seColTW);
            DrawMod.drawLine( g, num65 + 6, num66 + 86, num65 + 290, num66 + 86, Color.Black);
            DrawMod.DrawTextColouredConsoleMultiline( g, tstring22, DrawMod.TGame.se1TypeWriterSmall, num65 + 6, num66 + 90, DrawMod.TGame.seColTW, 290, 160);
          }
        }
      }
      if (this.game.EditObj.se1_SelectUnitButton == 8)
      {
        int num72 = useRect.X + 278;
        int num73 = 11;
        ItemList itemList = ItemList::new();
        int index13 =  Math.Round((double) this.game.Data.RuleVar[407]) + 5;
        int index14 =  Math.Round((double) this.game.Data.RuleVar[407]) + 2;
        int index15 =  Math.Round((double) this.game.Data.RuleVar[407]) + 0;
        int index16 =  Math.Round((double) this.game.Data.RuleVar[407]) + 9;
        int index17 =  Math.Round((double) this.game.Data.RuleVar[407]) + 8;
        int index18 =  Math.Round((double) this.game.Data.RuleVar[407]) + 7;
        int sfCount1 = this.game.Data.UnitObj[index5].SFCount;
        for (int index19 = 0; index19 <= sfCount1; index19 += 1)
        {
          int sf = this.game.Data.UnitObj[index5].SFList[index19];
          int type = this.game.Data.SFObj[sf].Type;
          int qty = this.game.Data.SFObj[sf].Qty;
          index6 = this.game.Data.SFTypeObj[type].SFTypeVar[index13];
          int tweight1 = this.game.Data.SFTypeObj[type].SFTypeVar[index16] * qty;
          if (index6 > 0 & tweight1 > 0)
            itemList.list.AddWeight(index6, tweight1);
          index6 = this.game.Data.SFTypeObj[type].SFTypeVar[index14];
          int tweight2 = this.game.Data.SFTypeObj[type].SFTypeVar[index17] * qty;
          if (index6 > 0 & tweight2 > 0)
            itemList.list.AddWeight(index6, tweight2);
          index6 = this.game.Data.SFTypeObj[type].SFTypeVar[index15];
          int tweight3 = this.game.Data.SFTypeObj[type].SFTypeVar[index18] * qty;
          if (index6 > 0 & tweight3 > 0)
            itemList.list.AddWeight(index6, tweight3);
        }
        int num74 = num73 + 90;
        if (this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn | this.game.EventRelatedObj.Helper_IsDebug())
        {
          SimpleList simpleList3 = SimpleList::new();
          if (num1 == -1)
          {
            tstring23: String = "Received / Requested";
            DrawMod.DrawTextColouredConsoleCenter( g, tstring23, DrawMod.TGame.se1TypeWriterMedium, num72 + 156, num73 + 3, DrawMod.TGame.seColTW);
            DrawMod.drawLine( g, num72 + 6, num73 + 20, num72 + 290, num73 + 20, Color.Black);
            tstring24: String = "Upkeep and Stocks";
            DrawMod.DrawTextColouredConsoleCenter( g, tstring24, DrawMod.TGame.se1TypeWriterMedium, num72 + 156, num74 + 6, DrawMod.TGame.seColTW);
            DrawMod.drawLine( g, num72 + 6, num74 + 23, num72 + 290, num74 + 23, Color.Black);
            int num75 = 36;
            int num76 = num74 + 11;
            index6 = 0;
            int num77 = 0;
            int num78 = 0;
            int num79 = 0;
            int num80 = 0;
            int logCounter1 = this.game.Data.UnitObj[index5].LogCounter;
            bool flag1;
            int num81;
            int num82;
            int num83;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            for (int index20 = 0; index20 <= logCounter1; index20 += 1)
            {
              if (this.game.Data.UnitObj[index5].LogType[index20] == 701)
              {
                flag1 = true;
                num81 = this.game.Data.UnitObj[index5].LogData1[index20];
                num82 = this.game.Data.UnitObj[index5].LogData2[index20];
                num83 = this.game.Data.UnitObj[index5].LogData3[index20];
              }
              if (this.game.Data.UnitObj[index5].LogType[index20] == 702)
                flag2 = true;
              if (this.game.Data.UnitObj[index5].LogType[index20] == 703)
                flag3 = true;
              if (this.game.Data.UnitObj[index5].LogType[index20] == 704)
                flag4 = true;
              if (this.game.Data.UnitObj[index5].LogType[index20] == 705)
                flag5 = true;
              if (this.game.Data.UnitObj[index5].LogType[index20] == 202)
                num78 += this.game.Data.UnitObj[index5].LogData3[index20];
              if (this.game.Data.UnitObj[index5].LogType[index20] == 1)
                index6 += this.game.Data.UnitObj[index5].LogData3[index20] * this.game.Data.ReinfRatio[this.game.Data.UnitObj[index5].LogData1[index20]];
              if (this.game.Data.UnitObj[index5].LogType[index20] == 2)
                num77 += this.game.Data.UnitObj[index5].LogData3[index20] * this.game.Data.ReinfRatio[this.game.Data.UnitObj[index5].LogData1[index20]];
              if (this.game.Data.UnitObj[index5].LogType[index20] == 10)
                num79 += this.game.Data.UnitObj[index5].LogData3[index20] * this.game.Data.ReinfRatio[this.game.Data.UnitObj[index5].LogData1[index20]];
              if (this.game.Data.UnitObj[index5].LogType[index20] == 3)
                num80 += this.game.Data.UnitObj[index5].LogData3[index20] * this.game.Data.ReinfRatio[this.game.Data.UnitObj[index5].LogData1[index20]];
            }
            predefnr = this.game.Data.HistoricalUnitObj[index2].SubParts[0];
            predefnr = this.game.HandyFunctionsObj.GetPreDef(predefnr);
            int num84 = 0;
            int sfCount2 = this.game.Data.UnitObj[predefnr].SFCount;
            for (int index21 = 0; index21 <= sfCount2; index21 += 1)
              num84 += this.game.Data.SFObj[this.game.Data.UnitObj[predefnr].SFList[index21]].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[predefnr].SFList[index21]].Type].Ratio;
            int num85 = 0;
            int sfCount3 = this.game.Data.UnitObj[index5].SFCount;
            for (int index22 = 0; index22 <= sfCount3; index22 += 1)
              num85 += this.game.Data.SFObj[this.game.Data.UnitObj[index5].SFList[index22]].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[index5].SFList[index22]].Type].Ratio;
            str61: String = num85.ToString();
            double num86;
            if (num85 > 999)
            {
              num86 = Math.Round((double) num85 / 1000.0, 1);
              str61 = num86.ToString() + "k";
            }
            str62: String = num84.ToString();
            if (num84 > 999)
            {
              num86 = Math.Round((double) num84 / 1000.0, 1);
              str62 = num86.ToString() + "k";
            }
            str6 = str61 + "/" + str62;
            str8 = num85.ToString() + " Troops in unit out of an ideal of " + num84.ToString() + " Troops.";
            int eventPic = this.game.Data.FindEventPic("", 28, "SE_Present");
            if (index6 == 0)
            {
              predefnr = 100;
              r = 192;
              g2 =  byte.MaxValue;
              b = 192;
            }
            else if (index6 > 0)
            {
              predefnr =  Math.Round((double) (100 * num77) / (double) index6);
              g2 =  byte.MaxValue;
              r = 0;
              b = 0;
              if (predefnr <= 74)
              {
                g2 = 205;
                r = 205;
                b = 0;
              }
              if (predefnr <= 49)
              {
                g2 = 0;
                r = 200;
                b =  byte.MaxValue;
              }
              if (predefnr <= 24)
              {
                g2 = 0;
                r = 200;
                b = 0;
              }
              if (predefnr == 0)
              {
                g2 = 0;
                r = 0;
                b = 0;
              }
            }
            if (predefnr > 100)
              predefnr = 100;
            DrawMod.DrawTextColouredConsoleCenter( g, "REPL", DrawMod.TGame.se1TypeWriterSmall, num72 + 20, num75, DrawMod.TGame.seColTW);
            DrawMod.DrawBlock( g, num72 + 40, num75, 30, 16, 0, 0, 0, 100);
            DrawMod.DrawBlock( g, num72 + 41, num75 + 1,  Math.Round((double) (28 * predefnr) / 100.0), 14, r, g2, b,  byte.MaxValue);
            DrawMod.DrawTextColouredConsole( g, num77.ToString() + "/" + index6.ToString(), DrawMod.TGame.se1TypeWriterSmall, num72 + 75, num75, DrawMod.TGame.seColTW);
            ttext1: String = num77.ToString() + " Replacements received.\r\n" + index6.ToString() + " Replacements requested. ";
            rectangle = new Rectangle(num72 + 10, num75, 150, 16);
            trect = rectangle;
            this.AddMouse( trect, "Replacements", ttext1);
            if (num79 > 0 | num80 > 0)
            {
              if (num79 == 0)
              {
                predefnr = 100;
                r = 192;
                g2 =  byte.MaxValue;
                b = 192;
              }
              else if (num79 > 0)
              {
                predefnr =  Math.Round((double) (100 * num80) / (double) num79);
                g2 =  byte.MaxValue;
                r = 0;
                b = 0;
                if (predefnr <= 74)
                {
                  g2 = 205;
                  r = 205;
                  b = 0;
                }
                if (predefnr <= 49)
                {
                  g2 = 0;
                  r = 200;
                  b =  byte.MaxValue;
                }
                if (predefnr <= 24)
                {
                  g2 = 0;
                  r = 200;
                  b = 0;
                }
                if (predefnr == 0)
                {
                  g2 = 0;
                  r = 0;
                  b = 0;
                }
              }
              if (predefnr > 100)
                predefnr = 100;
              num75 += 18;
              DrawMod.DrawTextColouredConsoleCenter( g, "RET.", DrawMod.TGame.se1TypeWriterSmall, num72 + 20, num75, DrawMod.TGame.seColTW);
              DrawMod.DrawBlock( g, num72 + 40, num75, 30, 16, 0, 0, 0, 100);
              DrawMod.DrawBlock( g, num72 + 41, num75 + 1,  Math.Round((double) (28 * predefnr) / 100.0), 14, r, g2, b,  byte.MaxValue);
              DrawMod.DrawTextColouredConsole( g, num80.ToString() + "/" + num79.ToString(), DrawMod.TGame.se1TypeWriterSmall, num72 + 75, num75, DrawMod.TGame.seColTW);
              ttext2: String = num80.ToString() + " Returned troops \r\n" + num79.ToString() + " Returns offered. ";
              rectangle = new Rectangle(num72 + 10, num75, 150, 16);
              trect = rectangle;
              this.AddMouse( trect, "Returns", ttext2);
            }
            if (num84 == 0)
            {
              predefnr = 100;
              r = 192;
              g2 =  byte.MaxValue;
              b = 192;
            }
            else if (num84 > 0)
            {
              predefnr =  Math.Round((double) (100 * num85) / (double) num84);
              g2 =  byte.MaxValue;
              r = 0;
              b = 0;
              if (predefnr <= 74)
              {
                g2 = 205;
                r = 205;
                b = 0;
              }
              if (predefnr <= 49)
              {
                g2 = 0;
                r = 200;
                b =  byte.MaxValue;
              }
              if (predefnr <= 24)
              {
                g2 = 0;
                r = 200;
                b = 0;
              }
              if (predefnr < 10)
                predefnr = 10;
            }
            if (predefnr > 100)
              predefnr = 100;
            if (!Information.IsNothing((object) this.game.Data.UnitObj[index5].items))
            {
              int counter = this.game.Data.UnitObj[index5].items.list.Counter;
              for (int index23 = 0; index23 <= counter; index23 += 1)
                simpleList3.AddWeight(this.game.Data.UnitObj[index5].items.list.Id[index23], this.game.Data.UnitObj[index5].items.list.Weight[index23], tdata5: this.game.Data.UnitObj[index5].items.list.Id[index23]);
            }
            int counter1 = itemList.list.Counter;
            for (int index24 = 0; index24 <= counter1; index24 += 1)
            {
              if (simpleList3.FindNr(itemList.list.Id[index24]) == -1)
                simpleList3.AddWeight(itemList.list.Id[index24], 0, tdata5: itemList.list.Id[index24]);
            }
            int logCounter2 = this.game.Data.UnitObj[index5].LogCounter;
            for (int index25 = 0; index25 <= logCounter2; index25 += 1)
            {
              if (this.game.Data.UnitObj[index5].LogType[index25] == 202)
                simpleList3.AddData(this.game.Data.UnitObj[index5].LogData1[index25], 1, this.game.Data.UnitObj[index5].LogData3[index25]);
              else if (this.game.Data.UnitObj[index5].LogType[index25] == 105)
                simpleList3.AddData(this.game.Data.UnitObj[index5].LogData1[index25], 2, this.game.Data.UnitObj[index5].LogData3[index25]);
              else if (this.game.Data.UnitObj[index5].LogType[index25] == 104)
                simpleList3.AddData(this.game.Data.UnitObj[index5].LogData1[index25], 3, this.game.Data.UnitObj[index5].LogData3[index25]);
              else if (this.game.Data.UnitObj[index5].LogType[index25] == 106)
                simpleList3.AddData(this.game.Data.UnitObj[index5].LogData1[index25], 4, this.game.Data.UnitObj[index5].LogData3[index25]);
            }
            simpleList3.SortOnData5();
            int num87 = useRect.X + 278;
            int num88 = useRect.X + 278;
            if (simpleList3.Counter > -1)
            {
              int counter2 = simpleList3.Counter;
              for (int index26 = 0; index26 <= counter2; index26 += 1)
              {
                index6 = simpleList3.Id[index26];
                int num89 = simpleList3.Weight[index26];
                predefnr = simpleList3.Data1[index26];
                int num90 = simpleList3.Data3[index26];
                int num91 = simpleList3.Data2[index26];
                int num92 = simpleList3.Data4[index26];
                data: String = this.game.Data.StringListObj[stringListById3].GetData(0, index6, 1);
                if (data.Length > 10)
                  str6 = Strings.Left(data, 10);
                if (num87 > 0)
                {
                  int weight = itemList.list.FindWeight(index6);
                  if (this.game.Data.HistoricalUnitObj[index2].Type != 8 && simpleList3.Data1[index26] > 0)
                  {
                    index6 =  Math.Round((double) (simpleList3.Data2[index26] * 100) / (double) simpleList3.Data1[index26]);
                    str6 = index6.ToString() + "%";
                    str6 = simpleList3.Data2[index26].ToString() + "/" + simpleList3.Data1[index26].ToString();
                  }
                  num75 += 18;
                  if (num75 > 90)
                  {
                    num75 -= 72;
                    num87 += 150;
                  }
                  str6 = num89.ToString() + "/" + weight.ToString();
                  str63: String = "";
                  str64: String = "";
                  int idValue3;
                  if (simpleList3.Id[index26] == 10)
                  {
                    eventPic = this.game.Data.FindEventPic("", 29, "SE_Present");
                    idValue3 = 12;
                    str64 = "Ammunitions";
                    str63 = "AMMO";
                  }
                  if (simpleList3.Id[index26] == 7)
                  {
                    eventPic = this.game.Data.FindEventPic("", 31, "SE_Present");
                    idValue3 = 11;
                    str64 = "Food";
                    str63 = "FOOD";
                  }
                  if (simpleList3.Id[index26] == 1)
                  {
                    eventPic = this.game.Data.FindEventPic("", 30, "SE_Present");
                    idValue3 = 13;
                    str64 = "Fuel";
                    str63 = "FUEL";
                  }
                  if (simpleList3.Id[index26] == 15)
                  {
                    eventPic = this.game.Data.FindEventPic("", 32, "SE_Present");
                    idValue3 = 13;
                    str64 = "Energy";
                    str63 = "ENRG";
                  }
                  if (simpleList3.Id[index26] == 4)
                  {
                    eventPic = this.game.Data.FindEventPic("", 114, "SE_Present");
                    idValue3 = 13;
                    str64 = "Radioactives";
                    str63 = "RAD";
                  }
                  str65: String = str64;
                  int num93;
                  if (predefnr == 0)
                  {
                    num93 = 100;
                    r = 192;
                    g2 =  byte.MaxValue;
                    b = 192;
                  }
                  else if (predefnr > 0)
                  {
                    num93 =  Math.Round((double) (100 * num91) / (double) predefnr);
                    g2 =  byte.MaxValue;
                    r = 0;
                    b = 0;
                    if (num93 <= 74)
                    {
                      g2 = 205;
                      r = 205;
                      b = 0;
                    }
                    if (num93 <= 49)
                    {
                      g2 = 0;
                      r = 200;
                      b =  byte.MaxValue;
                    }
                    if (num93 <= 24)
                    {
                      g2 = 0;
                      r = 200;
                      b = 0;
                    }
                    if (num93 == 0)
                    {
                      g2 = 0;
                      r = 0;
                      b = 0;
                    }
                  }
                  if (num93 > 100)
                    num93 = 100;
                  DrawMod.DrawTextColouredConsoleCenter( g, str63, DrawMod.TGame.se1TypeWriterSmall, num87 + 20, num75, DrawMod.TGame.seColTW);
                  DrawMod.DrawBlock( g, num87 + 40, num75, 30, 16, 0, 0, 0, 100);
                  DrawMod.DrawBlock( g, num87 + 41, num75 + 1,  Math.Round((double) (28 * num93) / 100.0), 14, r, g2, b,  byte.MaxValue);
                  DrawMod.DrawTextColouredConsole( g, num91.ToString() + "/" + predefnr.ToString(), DrawMod.TGame.se1TypeWriterSmall, num87 + 75, num75, DrawMod.TGame.seColTW);
                  rectangle = new Rectangle(num87 + 10, num75, 150, 16);
                  trect = rectangle;
                  this.AddMouse( trect, "Replacements", "Received " + num91.ToString() + " " + str64 + ".\r\nRequested " + predefnr.ToString() + " " + str64 + ".");
                  int num94 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3, 4)));
                  if (this.game.Data.StringListObj[stringListById5].GetData3(0, id, 1, this.game.Data.HistoricalUnitObj[index2].ID, 2, idValue3, 3).Length <= 1)
                  {
                    if (num94 == 0)
                      ;
                    str8 = "Unit started turn with full stocks available";
                  }
                  if (num90 > 0 | num92 > 0)
                  {
                    if (num92 == 0)
                    {
                      num93 = 100;
                      r = 192;
                      g2 =  byte.MaxValue;
                      b = 192;
                    }
                    else if (num92 > 0)
                    {
                      num93 =  Math.Round((double) (100 * num90) / (double) num92);
                      g2 =  byte.MaxValue;
                      r = 0;
                      b = 0;
                      if (num93 <= 74)
                      {
                        g2 = 205;
                        r = 205;
                        b = 0;
                      }
                      if (num93 <= 49)
                      {
                        g2 = 0;
                        r = 200;
                        b =  byte.MaxValue;
                      }
                      if (num93 <= 24)
                      {
                        g2 = 0;
                        r = 200;
                        b = 0;
                      }
                    }
                    if (num93 > 100)
                      num93 = 100;
                    num76 += 18;
                    if (num76 > 184)
                    {
                      num76 -= 72;
                      num88 += 150;
                    }
                    DrawMod.DrawTextColouredConsoleCenter( g, Strings.Left(str63, 2) + "-C.", DrawMod.TGame.se1TypeWriterSmall, num87 + 20, num76, DrawMod.TGame.seColTW);
                    DrawMod.DrawBlock( g, num88 + 40, num76, 30, 16, 0, 0, 0, 100);
                    DrawMod.DrawBlock( g, num88 + 41, num76 + 1,  Math.Round((double) (28 * num93) / 100.0), 14, r, g2, b,  byte.MaxValue);
                    DrawMod.DrawTextColouredConsole( g, num90.ToString() + "/" + num92.ToString(), DrawMod.TGame.se1TypeWriterSmall, num88 + 75, num76, DrawMod.TGame.seColTW);
                    rectangle = new Rectangle(num88 + 10, num76, 150, 16);
                    trect = rectangle;
                    this.AddMouse( trect, "Upkeep " + str65 + " consumption", "Consumed " + num90.ToString() + " " + str65 + ".\r\nOf the needed " + num92.ToString() + " " + str65 + ".");
                  }
                  if (num89 > 0 | weight > 0)
                  {
                    int num95 = weight;
                    int num96 = weight - num90;
                    if (num96 < 0)
                      num96 = 0;
                    if (num96 == 0)
                    {
                      num93 = 100;
                      r = 192;
                      g2 = 192;
                      b = 192;
                    }
                    else if (num96 > 0)
                    {
                      num93 =  Math.Round((double) (100 * num89) / (double) num96);
                      g2 =  byte.MaxValue;
                      r = 0;
                      b = 0;
                      if (num93 <= 74)
                      {
                        g2 = 205;
                        r = 205;
                        b = 0;
                      }
                      if (num93 <= 49)
                      {
                        g2 = 0;
                        r = 200;
                        b =  byte.MaxValue;
                      }
                      if (num93 <= 24)
                      {
                        g2 = 0;
                        r = 200;
                        b = 0;
                      }
                      if (num93 < 10)
                        predefnr = 10;
                    }
                    if (num93 > 100)
                      num93 = 100;
                    num76 += 18;
                    if (num76 > 184)
                    {
                      num76 -= 72;
                      num88 += 150;
                    }
                    int num97 = num95;
                    DrawMod.DrawTextColouredConsoleCenter( g, str63, DrawMod.TGame.se1TypeWriterSmall, num88 + 20, num76, DrawMod.TGame.seColTW);
                    DrawMod.DrawBlock( g, num88 + 40, num76, 30, 16, 0, 0, 0, 100);
                    if (num93 > 0)
                      DrawMod.DrawBlock( g, num88 + 41, num76 + 1,  Math.Round((double) (28 * num93) / 100.0), 14, r, g2, b,  byte.MaxValue);
                    DrawMod.DrawTextColouredConsole( g, num89.ToString() + "/" + num97.ToString(), DrawMod.TGame.se1TypeWriterSmall, num88 + 75, num76, DrawMod.TGame.seColTW);
                    rectangle = new Rectangle(num88 + 10, num76, 150, 16);
                    trect = rectangle;
                    this.AddMouse( trect, "Supply Stock of " + str65 + " consumption", "We have " + num89.ToString() + " " + str65 + ".\r\nOf the ideal " + num97.ToString() + " " + str65 + ".");
                  }
                }
              }
            }
            ttitle1: String = "";
            ttext3: String = "";
            int y10 = 36;
            if (num87 > num88)
              y10 = num75 + 18;
            if (num78 > 0)
            {
              if (!flag1)
              {
                ttitle1 = "Pick-Up Issue";
                ttext3 = "Unit was not able to find a Pickup Point on a road with Logistical Points within its Operational Logistics range.";
              }
              else if (flag5)
              {
                ttitle1 = "Pick-Up Issue";
                ttext3 = "Though initially able to use Pickup Point (" + num81.ToString() + "," + num82.ToString() + ") and maybe others eventually no more Pickup Points could be found.";
              }
              else if (num83 < 100)
              {
                ttitle1 = "Pick-Up Issue";
                ttext3 = "(One of) the Pickup Point(s) (" + num81.ToString() + "," + num82.ToString() + ") on a road with Logistical Points was to far for the Unit's optimal Operational Logistics range. Only " + num83.ToString() + "% could be picked-up.";
              }
              int num98;
              int num99;
              if (ttitle1.Length > 1)
              {
                sizeF2 = g.MeasureString("[" + ttitle1 + "]", DrawMod.TGame.se1TypeWriterSmall);
                num99 =  Math.Round((double) ((float) num98 + sizeF2.Width));
                DrawMod.DrawTextColouredConsole( g, "[" + ttitle1 + "]", DrawMod.TGame.se1TypeWriterSmall, num88 + 160, y10, DrawMod.TGame.seColTW);
                rectangle = new Rectangle(num88 + 170, y10,  Math.Round((double) sizeF2.Width), 16);
                trect = rectangle;
                this.AddMouse( trect, ttitle1, ttext3);
                y10 += 18;
              }
              if (flag2 & (num83 < 100 | !flag1))
              {
                str66: String = "Low Log.Pts";
                ttext4: String = "Unit did not get all it needed delivered to Pickup Point because the Logistical Points on the road between the Pickup Point and its SHQ where too low.";
                sizeF2 = g.MeasureString("[" + str66 + "]", DrawMod.TGame.se1TypeWriterSmall);
                num99 =  Math.Round((double) ((float) num99 + sizeF2.Width));
                DrawMod.DrawTextColouredConsole( g, "[" + str66 + "]", DrawMod.TGame.se1TypeWriterSmall, num88 + 160, y10, DrawMod.TGame.seColTW);
                ttitle2: String = "Low Logistical Points";
                rectangle = new Rectangle(num88 + 170, y10,  Math.Round((double) sizeF2.Width), 16);
                trect = rectangle;
                this.AddMouse( trect, ttitle2, ttext4);
                y10 += 18;
              }
              if (flag3)
              {
                str67: String = "SHQ miss.Items";
                ttext5: String = "Unit did not get all it needed delivered to Pickup Point because its SHQ had not enough Items in inventory to send everything requested.";
                sizeF2 = g.MeasureString("[" + str67 + "]", DrawMod.TGame.se1TypeWriterSmall);
                num99 =  Math.Round((double) ((float) num99 + sizeF2.Width));
                DrawMod.DrawTextColouredConsole( g, "[" + str67 + "]", DrawMod.TGame.se1TypeWriterSmall, num88 + 160, y10, DrawMod.TGame.seColTW);
                ttitle3: String = "SHQ is missing Items";
                rectangle = new Rectangle(num88 + 170, y10,  Math.Round((double) sizeF2.Width), 16);
                trect = rectangle;
                this.AddMouse( trect, ttitle3, ttext5);
                y10 += 18;
              }
              if (flag4)
              {
                str68: String = "SHQ Log.Limit";
                ttext6: String = "Unit did not get all it needed delivered to Pickup Point because the Logistical Points on the road between the Pickup Point and its SHQ reached the limit that it was allowed to use (See Unit Admin order for SHQ).";
                sizeF2 = g.MeasureString("[" + str68 + "]", DrawMod.TGame.se1TypeWriterSmall);
                num98 =  Math.Round((double) ((float) num99 + sizeF2.Width));
                DrawMod.DrawTextColouredConsole( g, "[" + str68 + "]", DrawMod.TGame.se1TypeWriterSmall, num88 + 160, y10, DrawMod.TGame.seColTW);
                ttitle4: String = "SHQ Logistical Limit";
                rectangle = new Rectangle(num88 + 170, y10,  Math.Round((double) sizeF2.Width), 16);
                trect = rectangle;
                this.AddMouse( trect, ttitle4, ttext6);
                int num100 = y10 + 18;
              }
            }
          }
          else
          {
            tstring25: String = "Sent / Requested";
            DrawMod.DrawTextColouredConsoleCenter( g, tstring25, DrawMod.TGame.se1TypeWriterMedium, num72 + 116, num73 + 3, DrawMod.TGame.seColTW);
            DrawMod.drawLine( g, num72 + 6, num73 + 20, num72 + 220, num73 + 20, Color.Black);
            tstring26: String = "Logistical Points Usage";
            DrawMod.DrawTextColouredConsoleCenter( g, tstring26, DrawMod.TGame.se1TypeWriterMedium, num72 + 116, num74 + 6, DrawMod.TGame.seColTW);
            DrawMod.drawLine( g, num72 + 6, num74 + 23, num72 + 220, num74 + 23, Color.Black);
            int num101 = 18;
            int num102 = useRect.X + 304;
            int num103 = num74 + 11;
            index6 = 0;
            int num104 = 0;
            int num105 = 0;
            int num106 = 0;
            predefnr = 0;
            int num107 = 0;
            int num108 = 0;
            int num109 = 0;
            int num110 = 0;
            int num111 = 0;
            int num112 = 0;
            int num113 = 0;
            int num114 = 0;
            int num115 = 0;
            int num116 = 0;
            int num117 = 0;
            int num118 = 0;
            int num119 = 0;
            int logCounter = this.game.Data.UnitObj[unitSelected].LogCounter;
            for (int index27 = 0; index27 <= logCounter; index27 += 1)
            {
              if (!(this.game.Data.UnitObj[unitSelected].LogData1[index27] >= 16 & this.game.Data.UnitObj[unitSelected].LogData1[index27] <= 22))
              {
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 211)
                  index6 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 102)
                  num104 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 202)
                  num105 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 103)
                  num106 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 212)
                  predefnr += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 101)
                  num107 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 11)
                  num108 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 12)
                  num109 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 18)
                  num110 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 8)
                  num111 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 502)
                  num113 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 602)
                  num112 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 503)
                  num115 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 603)
                  num114 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 505)
                  num117 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 605)
                  num116 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 506)
                  num119 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
                if (this.game.Data.UnitObj[unitSelected].LogType[index27] == 606)
                  num118 += this.game.Data.UnitObj[unitSelected].LogData3[index27];
              }
            }
            int num120 = 0;
            do
            {
              tstring27: String = "";
              int num121;
              int num122;
              if (num120 == 0)
              {
                num121 = index6;
                num122 = num104;
                tstring27 = "SHQ > ZONE";
              }
              if (num120 == 1)
              {
                num121 = num105;
                num122 = num106;
                tstring27 = "SHQ > UNIT";
              }
              if (num120 == 2)
              {
                num121 = predefnr;
                num122 = num107;
                tstring27 = "ZONE > SHQ";
              }
              if (num120 == 3)
              {
                num121 = num108 + num110;
                num122 = num109 + num111;
                tstring27 = "REPLACEMENT";
              }
              int num123;
              if (num121 == 0)
              {
                num123 = 100;
                r = 192;
                g2 = 192;
                b = 192;
              }
              else if (num121 > 0)
              {
                int num124 =  Math.Round((double) (100 * num122) / (double) num121);
                g2 =  byte.MaxValue;
                r = 0;
                b = 0;
                if (num124 <= 74)
                {
                  g2 = 205;
                  r = 205;
                  b = 0;
                }
                if (num124 <= 49)
                {
                  g2 = 0;
                  r = 200;
                  b =  byte.MaxValue;
                }
                if (num124 <= 24)
                {
                  g2 = 0;
                  r = 200;
                  b = 0;
                }
                if (num124 == 0)
                {
                  g2 = 0;
                  r = 0;
                  b = 0;
                }
                num123 = num124 +  Math.Round((double) (100 - num124) * 0.1);
              }
              if (num123 > 100)
                num123 = 100;
              str69: String = "";
              if (num120 == 0)
                str69 = "Supplies from SHQ to Zones";
              if (num120 == 1)
                str69 = "Supplies from SHQ to Units";
              if (num120 == 2)
                str69 = "Supplies from Zones to SHQ";
              if (num120 == 3)
                str69 = "Replacements from SHQ to Units (and vice-versa with returns)";
              ttitle: String = str69;
              ttext: String = "";
              if (num120 <= 2)
                ttext = ttext + "Delivered: " + num122.ToString() + ".\r\nRequested: " + num121.ToString() + ".";
              if (num120 == 3)
                ttext = ttext + "Replacements delivered: " + num109.ToString() + ".\r\nReplacements requested: " + num108.ToString() + "." + "\r\nReplacements returned to SHQ: " + num111.ToString() + ".\r\nReplacements offered for return: " + num110.ToString() + ".";
              num101 += 18;
              DrawMod.DrawTextColouredConsole( g, tstring27, DrawMod.TGame.se1TypeWriterSmall, num102 + 3, num101, DrawMod.TGame.seColTW);
              DrawMod.DrawBlock( g, num102 + 90, num101, 60, 16, 0, 0, 0, 100);
              DrawMod.DrawBlock( g, num102 + 91, num101 + 1,  Math.Round((double) (58 * num123) / 100.0), 14, r, g2, b,  byte.MaxValue);
              DrawMod.DrawTextColouredConsole( g, num122.ToString() + "/" + num121.ToString(), DrawMod.TGame.se1TypeWriterSmall, num102 + 160, num101, DrawMod.TGame.seColTW);
              rectangle = new Rectangle(num102 + 10, num101, 220, 16);
              trect = rectangle;
              this.AddMouse( trect, ttitle, ttext);
              int num125;
              if (num120 == 0)
              {
                num125 = num112;
                num122 = num113;
              }
              if (num120 == 1)
              {
                num125 = num114 - num112;
                num122 = num115;
              }
              if (num120 == 2)
              {
                num125 = num116 - num114;
                num122 = num117;
              }
              if (num120 == 3)
              {
                num125 = num118 - num116;
                num122 = num119;
              }
              str6 = num122.ToString() + "/" + num125.ToString();
              if (num125 == 0)
              {
                num123 = 100;
                r = 192;
                g2 = 192;
                b = 192;
              }
              else if (num122 > 0 | num125 > 0)
              {
                num123 =  Math.Round((double) (100 * num122) / (double) num125);
                r = 192;
                g2 = 192;
                b = 192;
              }
              if (num123 > 100)
                num123 = 100;
              num103 += 18;
              DrawMod.DrawTextColouredConsole( g, tstring27, DrawMod.TGame.se1TypeWriterSmall, num102 + 3, num103, DrawMod.TGame.seColTW);
              DrawMod.DrawBlock( g, num102 + 90, num103, 60, 16, 0, 0, 0, 100);
              DrawMod.DrawBlock( g, num102 + 91, num103 + 1,  Math.Round((double) (58 * num123) / 100.0), 14, r, g2, b,  byte.MaxValue);
              DrawMod.DrawTextColouredConsole( g, num122.ToString() + "/" + num125.ToString(), DrawMod.TGame.se1TypeWriterSmall, num102 + 160, num103, DrawMod.TGame.seColTW);
              rectangle = new Rectangle(num102 + 10, num103, 220, 16);
              trect = rectangle;
              this.AddMouse( trect, ttitle, "Logistical Points used " + num122.ToString() + ".\r\nOf maximum alloted " + num125.ToString() + ".");
              num120 += 1;
            }
            while (num120 <= 3);
          }
        }
      }
      if (!this.calledFromNonCardSelectWindow)
        return;
      this.game.EditObj.se1_SelectUnitButton = selectUnitButton;
    }

    pub void ZoneBottomTab(Graphics g, Rectangle useRect)
    {
      int x1 = useRect.X;
      int y1 = useRect.Y;
       Graphics local1 =  g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ZONEFRAME);
       Bitmap local2 =  bitmap1;
      int x2 = x1;
      int y2 = y1;
      DrawMod.DrawSimple( local1,  local2, x2, y2);
      libName1: String = "SE_Data";
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName1, 298, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 123, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 160, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 287, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 148, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 144, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 149, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 166, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 196, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 204, 0, 0));
      int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 210, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1,  byte.MaxValue, 0, 0));
      int stringListById9 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 275, 0, 0));
      int stringListById10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 288, 0, 0));
      int stringListById11 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 143, 0, 0));
      int stringListById12 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 289, 0, 0));
      int stringListById13 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 306, 0, 0));
      int stringListById14 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 310, 0, 0));
      int stringListById15 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 308, 0, 0));
      int stringListById16 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 167, 0, 0));
      int stringListById17 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 413, 0, 0));
      int stringListById18 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Random", 132, 0, 0));
      int num1 = this.game.Data.StringListObj[stringListById18].Length + 1;
      int integer1 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, libName1, "Zones"));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 1));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 2));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 10));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 11));
      int id =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 6)));
      data1: String = this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 7);
      int num2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 8)));
      int regNr = this.game.EventRelatedObj.CheckRegimeSlot(num2, 0, 0, 0);
      int num3 = -1;
      if (num2 > -1)
        num3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num2, 12)));
      int index1 = -1;
      if (id > 0)
        index1 = this.game.HandyFunctionsObj.GetLocationByID(id);
      int index2 = -1;
      if (index1 > -1)
        index2 = this.game.Data.LocObj[index1].HQ;
      int num4 = -1;
      if (integer1 > 0 & regNr > -1)
        num4 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[regNr].id, 10, integer1, 0);
      if (integer1 < 1)
        return;
      this.game.Data.FindEventPic("", 8, "SE_Present");
      this.game.Data.FindEventPic("", 9, "SE_Present");
      this.game.Data.FindEventPic("", 11, "SE_Present");
      int num5 = -1;
      int num6 = 0;
      int num7 = 0;
      if (integer1 > 0 & num2 > 0)
      {
        num5 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById10].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer1, 2, "recon", 3)));
        num6 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById10].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer1, 2, "spies", 3)));
        num7 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById9].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, num2, 2, "recon", 3)));
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastLT(this.game.Data.Turn) == -1)
      {
        num5 = -1;
        num7 = 0;
      }
      if (regNr == this.game.Data.Turn)
      {
        num5 = 9999;
        num7 = 9999;
      }
      if (!this.game.Data.FOWOn)
      {
        num5 = 9999;
        num7 = 9999;
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon > 0 & num5 == -1)
        num5 = 0;
      if (!this.game.Data.FOWOn)
        ;
      if (num5 < 0 & !this.game.Data.ShrowdOn)
        num5 = 0;
      bool flag1 = false;
      bool flag2 = false;
      int index3 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById11].GetData(0, num2, 1));
      if (index3 == 2)
        flag1 = true;
      if (index3 == 3)
      {
        flag2 = true;
        flag1 = true;
      }
      if (index3 == 4)
        flag1 = true;
      bool flag3 = false;
      if (this.game.Data.Turn == regNr)
        flag3 = true;
      if (this.game.EditObj.se1_SelectZoneButton < 1)
        this.game.EditObj.se1_SelectZoneButton = 1;
      int num8;
      int idValue1;
      int num9;
      int num10;
      string str1;
      int tSlotNr;
      int num11;
      string str2;
      int num12;
      string str3;
      if ((num5 > -1 | this.game.Data.Turn == regNr) & !(num5 == 0 & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1 & this.game.Data.ShrowdOn))
      {
        int num13 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2)));
        Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "worker", 2)));
        int num14 = 155;
        int num15 = 49;
        Rectangle trect1;
        Rectangle trect2;
        double num16;
        string str4;
        if (this.game.EditObj.se1_SelectZoneButton == 1)
        {
          int num17 = useRect.X + 0;
          int num18 = 0;
           Graphics local3 =  g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME2);
           Bitmap local4 =  bitmap2;
          int x3 = num17;
          int y3 = num18;
          DrawMod.DrawSimple( local3,  local4, x3, y3);
          int nr = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "city", 2)));
          int num19 = 0;
          str5: String = num5 >= 2 ? (nr <= 0 ? "'" + data1 + "', No City" : "'" + data1 + "', City Level " + Strings.Trim(this.game.HandyFunctionsObj.GetRomanNumerical(nr))) : "'" + data1 + "'";
          tstring1: String = integer1 <= 0 ? "Hex without Zone" : "Zone: " + str5;
          DrawMod.DrawTextColouredConsoleCenter( g, tstring1, DrawMod.TGame.se1TypeWriterBig, num17 + 283, 17, DrawMod.TGame.seColTW);
          int y4 = num15;
          int num20 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2))) + Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "worker", 2)));
          int num21 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "pop", 2))) + Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "worker", 2)));
          tstring2: String = "Populace";
          DrawMod.DrawTextColouredConsole( g, tstring2, DrawMod.TGame.se1TypeWriterMedium, num17 + 40, y4, DrawMod.TGame.seColTW);
          int num22 = num20 * 100;
          int num23 = num21 * 100;
          int delta1 = num22 - num23;
          str6: String = num22.ToString();
          if (num22 >= 1000)
            str6 = Strings.Left(str6, str6.Length - 3) + "." + Strings.Right(str6, 3);
          if (num5 < 3)
            str6 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num17 + num14, y4, str6, delta1);
          ttitle1: String = "Populace";
          ttext1: String = "Total of all Population and Workers in this Zone.";
          trect1 = new Rectangle(num17 + 35, y4 - 10, 250, 30);
          trect2 = trect1;
          this.AddMouse( trect2, ttitle1, ttext1);
          int y5 = y4 + 30;
          int num24 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "city", 2)));
          tstring3: String = "Next Level";
          DrawMod.DrawTextColouredConsole( g, tstring3, DrawMod.TGame.se1TypeWriterMedium, num17 + 40, y5, DrawMod.TGame.seColTW);
          if (num5 >= 2)
          {
            tstring4: String = "";
            if (num24 == 0)
              tstring4 += "100";
            if (num24 == 1)
              tstring4 += "25.000";
            if (num24 == 2)
              tstring4 += "50.000";
            if (num24 == 3)
              tstring4 += "100.000";
            if (num24 == 4)
              tstring4 += "200.000";
            if (num24 == 5)
              tstring4 += "325.000";
            if (num24 == 6)
              tstring4 += "550.000";
            if (num24 == 7)
              tstring4 += "1.000.000";
            if (num24 >= 8)
              tstring4 = "N/A";
            DrawMod.DrawTextColouredConsole( g, tstring4, DrawMod.TGame.se1TypeWriterMedium, num17 + num14, y5, DrawMod.TGame.seColTW);
            ttitle2: String = "City Level Upgrade requirement";
            ttext2: String = "To upgrade to City Level " + Strings.Trim(this.game.HandyFunctionsObj.GetRomanNumerical(num24 + 1)) + " you need at least " + ttitle2 + " Populace.";
            trect2 = new Rectangle(num17 + 35, y5 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle2, ttext2);
          }
          else
          {
            tstring5: String = "?";
            DrawMod.DrawTextColouredConsole( g, tstring5, DrawMod.TGame.se1TypeWriterMedium, num17 + num14, y5, DrawMod.TGame.seColTW);
          }
          int y6 = y5 + 30;
          int num25 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "freeFolk", 2)));
          int num26 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "freeFolk", 2)));
          tstring6: String = "Free Folk";
          DrawMod.DrawTextColouredConsole( g, tstring6, DrawMod.TGame.se1TypeWriterMedium, num17 + 40, y6, DrawMod.TGame.seColTW);
          index3 = num25 * 100;
          int num27 = num26 * 100;
          int delta2 = index3 - num27;
          str7: String = index3.ToString();
          if (index3 >= 1000)
            str7 = Strings.Left(str7, str7.Length - 3) + "." + Strings.Right(str7, 3);
          if (index3 >= 1000000)
          {
            num16 = Math.Floor((double) index3 / 1000.0);
            str7 = num16.ToString() + "K";
          }
          if (num5 < 3)
            str7 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num17 + num14, y6, str7, delta2);
          ttitle3: String = "Free Folk";
          ttext3: String = "Wild, independent and hidden people outside your control, living somewhere in the outbacks of this Zone. They can be potential new Population.";
          trect2 = new Rectangle(num17 + 35, y6 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle3, ttext3);
          int y7 = y6 + 30;
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 12)));
          num19 =  Math.Round((double) Math.Max(0,  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 13)))) / (double) num1);
          index3 = num5;
          if (index3 > 999)
            index3 = 999;
          num19 = num6;
          tstring7: String = "Zone Recon";
          DrawMod.DrawTextColouredConsole( g, tstring7, DrawMod.TGame.se1TypeWriterMedium, num17 + 40, y7, DrawMod.TGame.seColTW);
          tstring8: String = index3.ToString();
          DrawMod.DrawTextColouredConsole( g, tstring8, DrawMod.TGame.se1TypeWriterMedium, num17 + num14, y7, DrawMod.TGame.seColTW);
          ttitle4: String = "Zone Recon Points";
          ttext4: String = "The number of Zone Recon Points you have on this Zone.";
          trect2 = new Rectangle(num17 + 35, y7 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle4, ttext4);
          int y8 = y7 + 30;
          index3 = num6;
          tstring9: String = "Spies";
          DrawMod.DrawTextColouredConsole( g, tstring9, DrawMod.TGame.se1TypeWriterMedium, num17 + 40, y8, DrawMod.TGame.seColTW);
          tstring10: String = index3.ToString();
          DrawMod.DrawTextColouredConsole( g, tstring10, DrawMod.TGame.se1TypeWriterMedium, num17 + num14, y8, DrawMod.TGame.seColTW);
          str4 = "Number of Spies";
          ttext5: String = "The number of your Spies active in this Zone.";
          trect2 = new Rectangle(num17 + 35, y8 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, str4, ttext5);
          num8 = y8 + 30;
          int num28 = 0;
          string tstring11;
          string tstring12;
          string tstring13;
          string tstring14;
          if (num4 > -1)
          {
            tstring11 = this.game.Data.StringListObj[stringListById7].GetData(0, num4, 3);
            tstring12 = this.game.Data.StringListObj[stringListById7].GetData(0, num4, 4);
            tstring13 = "Governor";
            index3 = this.game.EventRelatedObj.Helper_GetCharacterSuitabilityRating(num4, 10, integer1);
            tstring14 = "Suitability: " + index3.ToString();
            if (this.game.Data.Turn != regNr)
              tstring14 = "";
          }
          else
          {
            tstring13 = "Governor ";
            tstring11 = "position";
            tstring12 = "is vacant";
            tstring14 = "";
          }
          if (num5 < 2 | flag1)
          {
            tstring13 = "Governor";
            tstring11 = "?";
            tstring12 = "";
            tstring14 = "";
          }
          if (num5 < 2 | num4 < 1)
          {
            DrawMod.DrawBlock( g, num17 + 287, num28 + 48, 100, 140, 0, 0, 0, 64);
          }
          else
          {
             Graphics local5 =  g;
            Bitmap bitmap3 = this.game.CustomBitmapObj.DrawLeaderPortrait(num4, 100, 140, regNr == this.game.Data.Turn);
             Bitmap local6 =  bitmap3;
            int x4 = num17 + 287;
            int y9 = num28 + 48;
            DrawMod.DrawSimple( local5,  local6, x4, y9);
          }
          if (num4 > 0)
          {
            if (regNr == this.game.Data.Turn)
            {
              trect2 = new Rectangle(num17 + 287, num28 + 48, 100, 140);
              trect1 = trect2;
              this.AddMouse( trect1, "Governor", "Click for more information.", 201, num4);
            }
            else
            {
              trect2 = new Rectangle(num17 + 287, num28 + 48, 100, 140);
              trect1 = trect2;
              this.AddMouse( trect1, "Governor", "A picture of the Governor.");
            }
          }
          DrawMod.DrawTextColouredConsole( g, tstring11, DrawMod.TGame.se1TypeWriterMedium, num17 + 390, num28 + 60, DrawMod.TGame.seColTW);
          DrawMod.DrawTextColouredConsole( g, tstring12, DrawMod.TGame.se1TypeWriterMedium, num17 + 390, num28 + 80, DrawMod.TGame.seColTW);
          DrawMod.DrawTextColouredConsole( g, tstring13, DrawMod.TGame.se1TypeWriterSmall, num17 + 390, num28 + 100, DrawMod.TGame.seColTW);
          DrawMod.DrawTextColouredConsole( g, tstring14, DrawMod.TGame.se1TypeWriterSmall, num17 + 390, num28 + 115, DrawMod.TGame.seColTW);
          if (regNr == this.game.Data.Turn & num4 > 0)
          {
            this += 1.zoneButtonCounter;
            int[] zoneButton1 = this.zoneButton;
            int zoneButtonCounter1 = this.zoneButtonCounter;
            let mut tsubpart1: SubPartClass =  new TextButtonPartClass("Call", 70, "Give this governor a call. For example to discuss his orders.",  this.OwnBitmap, num17 + 390, num28 + 140, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            int num29 = this.AddSubPart( tsubpart1, num17 + 390, num28 + 140, 70, 35, 1);
            zoneButton1[zoneButtonCounter1] = num29;
            this.zoneButtonData[this.zoneButtonCounter] = 201;
            this += 1.zoneButtonCounter;
            int[] zoneButton2 = this.zoneButton;
            int zoneButtonCounter2 = this.zoneButtonCounter;
            let mut tsubpart2: SubPartClass =  new TextButtonPartClass("Strat", 70, "Play a Stratagem on this Governor.",  this.OwnBitmap, num17 + 390 + 70, num28 + 140, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            int num30 = this.AddSubPart( tsubpart2, num17 + 390 + 70, num28 + 140, 70, 35, 1);
            zoneButton2[zoneButtonCounter2] = num30;
            this.zoneButtonData[this.zoneButtonCounter] = 202;
            this.tempZoneId = integer1;
            this.tempCharId = num4;
          }
        }
        if (this.game.EditObj.se1_SelectZoneButton == 2)
        {
          int num31 = useRect.X + 0;
          int y10 = 0;
           Graphics local7 =  g;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local8 =  bitmap4;
          int x5 = num31;
          int y11 = y10;
          DrawMod.DrawSimple( local7,  local8, x5, y11);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2)));
          DrawMod.DrawTextColouredConsole( g, str4, DrawMod.TGame.se1TypeWriterMedium, num31 + 40, y10, DrawMod.TGame.seColTW);
          index3 *= 100;
          str8: String = index3.ToString();
          if (index3 >= 1000)
            str8 = Strings.Left(str8, str8.Length - 3) + "." + Strings.Right(str8, 3);
          if (num5 < 3)
            str8 = "Uknown";
          tstring15: String = "Population: " + str8;
          DrawMod.DrawTextColouredConsoleCenter( g, tstring15, DrawMod.TGame.se1TypeWriterBig, num31 + 283, 17, DrawMod.TGame.seColTW);
          int y12 = num15;
          tstring16: String = "Private Jobs";
          DrawMod.DrawTextColouredConsole( g, tstring16, DrawMod.TGame.se1TypeWriterMedium, num31 + 40, y12, DrawMod.TGame.seColTW);
          index3 = 0;
          EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
          dataLib: String = libName1;
          int onlyZoneId = integer1;
          SimpleList simpleList1 = (SimpleList) null;
           SimpleList local9 =  simpleList1;
          SimpleList simpleList2 = (SimpleList) null;
           SimpleList local10 =  simpleList2;
          eventRelatedObj.ExecMakeAssetPresentation(dataLib, 0, -1, onlyZoneId, "", itemsProdModList: ( local9), itemsUpkeepModList: ( local10));
          int length1 = this.game.Data.StringListObj[stringListById6].Length;
          for (int index4 = 0; index4 <= length1; index4 += 1)
          {
            if (Operators.CompareString(this.game.Data.StringListObj[stringListById6].Data[index4, 1], "popPoints", false) == 0)
              index3 +=  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index4, 3]));
          }
          if (index3 < 1)
            index3 = 0;
          index3 *= 100;
          str9: String = index3.ToString();
          if (index3 >= 1000)
            str9 = Strings.Left(str9, str9.Length - 3) + "." + Strings.Right(str9, 3);
          if (num5 < 15)
            str9 = "?";
          DrawMod.DrawTextColouredConsole( g, str9, DrawMod.TGame.se1TypeWriterMedium, num31 + num14, y12, DrawMod.TGame.seColTW);
          ttitle5: String = "Private Jobs";
          ttext6: String = "If you have more Private Jobs than Population your Private Economy will perform below peak performance.";
          trect2 = new Rectangle(num31 + 35, y12 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle5, ttext6);
          int y13 = y12 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popCredits", 2)));
          int num32 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "popCredits", 2)));
          int delta3 = index3 - num32;
          tstring17: String = "Private Funds";
          DrawMod.DrawTextColouredConsole( g, tstring17, DrawMod.TGame.se1TypeWriterMedium, num31 + 40, y13, DrawMod.TGame.seColTW);
          texty1: String = index3.ToString() + "cr";
          if (num5 < 15)
            texty1 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num31 + num14, y13, texty1, delta3);
          ttitle6: String = "Private Funds";
          ttext7: String = "The Private Economy can run a surplus and this will result in growing Private Funds. Private Funds can also be used by Population to buy Food when they have shortages.";
          trect2 = new Rectangle(num31 + 35, y13 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle6, ttext7);
          int y14 = y13 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "privateFood", 2)));
          int num33 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "privateFood", 2)));
          int delta4 = index3 - num33;
          tstring18: String = "Private Food";
          DrawMod.DrawTextColouredConsole( g, tstring18, DrawMod.TGame.se1TypeWriterMedium, num31 + 40, y14, DrawMod.TGame.seColTW);
          texty2: String = index3.ToString();
          if (num5 < 15)
            texty2 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num31 + num14, y14, texty2, delta4);
          ttitle7: String = "Private Food";
          ttext8: String = "The Private Economy food reserves. These are used by the Population in times of scarcity to avoid starvation. They can also be sold by their  owners.";
          trect2 = new Rectangle(num31 + 35, y14 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle7, ttext8);
          int y15 = y14 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "privateCreditsGrowth", 2)));
          int num34 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2)));
          tstring19: String = "Income";
          DrawMod.DrawTextColouredConsole( g, tstring19, DrawMod.TGame.se1TypeWriterMedium, num31 + 40, y15, DrawMod.TGame.seColTW);
          if (num34 > 0)
          {
            num16 = Math.Round((double) index3 / (double) (num34 * 100), 3);
            tstring20: String = num16.ToString() + "cr";
            if (num5 < 15)
              tstring20 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring20, DrawMod.TGame.se1TypeWriterMedium, num31 + num14, y15, DrawMod.TGame.seColTW);
          }
          else
          {
            tstring21: String = "N/A";
            if (num5 < 15)
              tstring21 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring21, DrawMod.TGame.se1TypeWriterMedium, num31 + num14, y15, DrawMod.TGame.seColTW);
          }
          ttitle8: String = "Population Income per Capita";
          ttext9: String = "Interesting to compare with your Workers Salary since it plays a big role in determining if the Workers will be happy with the Salary you provide. This is a modified value to model the Population perception of expected salary. It is not neccessary the same as the last spike or dip. ";
          trect2 = new Rectangle(num31 + 35, y15 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle8, ttext9);
          int y16 = y15 + 30;
          object obj1 = (object) 0;
          object obj2 = (object) 0;
          object Left = (object) 0;
          int length2 = this.game.Data.StringListObj[stringListById1].Length;
          for (int index5 = 0; index5 <= length2; index5 += 1)
          {
            if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 0])) == num2 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 2])) == integer1)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 1])) == 5)
                obj1 = Operators.AddObject(obj1, (object)  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 4])));
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 1])) == 1)
                Left = Operators.AddObject(Left, (object)  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 4])));
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 1])) == 2)
                obj2 = Operators.AddObject(obj2, (object)  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index5, 4])));
            }
          }
          int num35 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "syndicate_privateCreditsTaken", 2)));
          int num36 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "corp_creditsTaken", 2)));
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "privateAssetIncome", 2)));
          int num37 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "hiddenEconomyIncome", 2)));
          int num38 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "workerSpendingIncome", 2)));
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "sellingFoodIncome", 2)));
          int num39 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "buyingFoodExpenses", 2)));
          int num40 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "buyingLuxuriesExpenses", 2)));
          int num41 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "buyingAssetsExpenses", 2)));
          int num42 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "buyingPopExpenses", 2)));
          int num43 = index3 + num37 + num38 + idValue1;
          int integer2 = Conversions.ToInteger(Operators.AddObject(Operators.AddObject((object) (num39 + num40 + num41 + num42 + num36 + num35), obj1), obj2));
          tstring22: String = "Private Eco.";
          DrawMod.DrawTextColouredConsole( g, tstring22, DrawMod.TGame.se1TypeWriterMedium, num31 + 40, y16, DrawMod.TGame.seColTW);
          tstring23: String = "+" + num43.ToString() + "cr -" + integer2.ToString() + "cr";
          if (num5 < 15)
            tstring23 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring23, DrawMod.TGame.se1TypeWriterMedium, num31 + num14, y16, DrawMod.TGame.seColTW);
          ttitle9: String = "Income minus Expenses";
          ttext10: String = "INCOME\r\n" + "Private Asset Income: " + index3.ToString() + " Cr.\r\n" + "Hidden Economy Income: " + num37.ToString() + " Cr.\r\n" + "Salaries spending Income: " + num38.ToString() + " Cr.\r\n" + "Selling Items Income: " + idValue1.ToString() + " Cr.\r\n" + "\r\n" + "EXPENSES\r\n" + "Buying Food Expenses: " + num39.ToString() + " Cr.\r\n" + "Buying Luxuries Expenses: " + num40.ToString() + " Cr.\r\n" + "Buying Assets Expenses: " + num41.ToString() + " Cr.\r\n" + "Buying Free Folk Expenses: " + num42.ToString() + " Cr.\r\n" + "Service Tax: " + obj1.ToString() + " Cr.\r\n" + "Income Tax: " + obj2.ToString() + " Cr.\r\n";
          if (num35 > 0)
            ttext10 = ttext10 + "Syndicate Crime took: " + num35.ToString() + " Cr.\r\n";
          if (num36 > 0)
            ttext10 = ttext10 + "Corporate Control took: " + num36.ToString() + " Cr.\r\n";
          if (num5 < 15)
            ttext10 = "Hidden due to lack of Recon (need 15 zone Recon)";
          trect2 = new Rectangle(num31 + 35, y16 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle9, ttext10);
          num8 = y16 + 30;
          int num44 = num31 + 252;
          int y17 = num15;
          index3 = 0;
          int num45 = 0;
          int num46 = 0;
          int length3 = this.game.Data.StringListObj[stringListById1].Length;
          for (int index6 = 0; index6 <= length3; index6 += 1)
          {
            if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 0])) == num2 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 2])) == integer1)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 1])) == 5)
                index3 +=  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 4]));
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 1])) == 1)
                num46 +=  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 4]));
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 1])) == 2)
                num45 +=  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index6, 4]));
            }
          }
          tstring24: String = "Service Tax";
          DrawMod.DrawTextColouredConsole( g, tstring24, DrawMod.TGame.se1TypeWriterMedium, num44 + 40, y17, DrawMod.TGame.seColTW);
          tstring25: String = index3.ToString() + "cr";
          if (num5 < 15 | num13 < 1)
            tstring25 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring25, DrawMod.TGame.se1TypeWriterMedium, num44 + 165, y17, DrawMod.TGame.seColTW);
          ttitle10: String = "Service Tax Income";
          ttext11: String = "Standard fees paid to you by your Population.";
          trect2 = new Rectangle(num44 + 35, y17 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle10, ttext11);
          int y18 = y17 + 30;
          tstring26: String = "Income Tax";
          DrawMod.DrawTextColouredConsole( g, tstring26, DrawMod.TGame.se1TypeWriterMedium, num44 + 40, y18, DrawMod.TGame.seColTW);
          tstring27: String = num45.ToString() + "cr";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring27 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring27, DrawMod.TGame.se1TypeWriterMedium, num44 + 165, y18, DrawMod.TGame.seColTW);
          ttitle11: String = "Income Tax Income";
          ttext12: String = "Based on Income Tax %. Only paid by Population when sales are made to Traders.";
          trect2 = new Rectangle(num44 + 35, y18 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle11, ttext12);
          int y19 = y18 + 30;
          tstring28: String = "Sales Tax";
          DrawMod.DrawTextColouredConsole( g, tstring28, DrawMod.TGame.se1TypeWriterMedium, num44 + 40, y19, DrawMod.TGame.seColTW);
          tstring29: String = num46.ToString() + "cr";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring29 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring29, DrawMod.TGame.se1TypeWriterMedium, num44 + 165, y19, DrawMod.TGame.seColTW);
          ttitle12: String = "Sales Tax Income";
          ttext13: String = "Based on Sales Tax %. Only paid by Traders when they sell to your Populace.";
          trect2 = new Rectangle(num44 + 35, y19 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle12, ttext13);
          int y20 = y19 + 30;
          str10: String = "Next: ";
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "preferredAssetTypeId", 2)));
          str11: String = index3 <= 0 ? "None" : this.game.Data.StringListObj[stringListById5].GetData(0, index3, 1);
          if (flag1 | num5 < 15 | num13 < 1)
            str11 = "?";
          DrawMod.DrawTextColouredConsole( g, str10 + str11, DrawMod.TGame.se1TypeWriterMedium, num44 + 40, y20, DrawMod.TGame.seColTW);
          str4 = "Next Private Asset";
          ttext14: String = "An Asset Level in the Asset Family specified is what we expect the Private Economy to focus on once they have enough Private Credits to commence construction.";
          trect2 = new Rectangle(num44 + 35, y20 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, str4, ttext14);
          num8 = y20 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 3)
        {
          int num47 = useRect.X + 0;
          int y21 = 0;
           Graphics local11 =  g;
          Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local12 =  bitmap5;
          int x6 = num47;
          int y22 = y21;
          DrawMod.DrawSimple( local11,  local12, x6, y22);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "worker", 2)));
          DrawMod.DrawTextColouredConsole( g, str4, DrawMod.TGame.se1TypeWriterMedium, num47 + 40, y21, DrawMod.TGame.seColTW);
          index3 *= 100;
          str12: String = index3.ToString();
          if (index3 >= 1000)
            str12 = Strings.Left(str12, str12.Length - 3) + "." + Strings.Right(str12, 3);
          if (num5 < 3)
            str12 = "Uknown";
          tstring30: String = "Workers: " + str12;
          DrawMod.DrawTextColouredConsoleCenter( g, tstring30, DrawMod.TGame.se1TypeWriterBig, num47 + 283, 17, DrawMod.TGame.seColTW);
          int y23 = num15;
          tstring31: String = "Public Jobs";
          EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
          dataLib: String = libName1;
          int onlyZoneId = integer1;
          SimpleList simpleList3 = (SimpleList) null;
           SimpleList local13 =  simpleList3;
          SimpleList simpleList4 = (SimpleList) null;
           SimpleList local14 =  simpleList4;
          eventRelatedObj.ExecMakeAssetPresentation(dataLib, 0, -1, onlyZoneId, "", itemsProdModList: ( local13), itemsUpkeepModList: ( local14));
          DrawMod.DrawTextColouredConsole( g, tstring31, DrawMod.TGame.se1TypeWriterMedium, num47 + 40, y23, DrawMod.TGame.seColTW);
          index3 = 0;
          int length = this.game.Data.StringListObj[stringListById6].Length;
          for (int index7 = 0; index7 <= length; index7 += 1)
          {
            if (Operators.CompareString(this.game.Data.StringListObj[stringListById6].Data[index7, 1], "workerPoints", false) == 0)
              index3 +=  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index7, 3]));
          }
          if (index3 < 1)
            index3 = 0;
          index3 *= 100;
          str13: String = index3.ToString();
          if (index3 >= 1000)
            str13 = Strings.Left(str13, str13.Length - 3) + "." + Strings.Right(str13, 3);
          if (num5 < 15 | flag1)
            str13 = "?";
          DrawMod.DrawTextColouredConsole( g, str13, DrawMod.TGame.se1TypeWriterMedium, num47 + num14, y23, DrawMod.TGame.seColTW);
          ttitle13: String = "Public Jobs";
          ttext15: String = "If you have more Public Jobs than Workers you have an efficiency problem and should consider recruiting more Workers or Mothballing/Closing Public Assets.";
          trect2 = new Rectangle(num47 + 35, y23 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle13, ttext15);
          int y24 = y23 + 30;
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 2)));
          tstring32: String = "Salary";
          DrawMod.DrawTextColouredConsole( g, tstring32, DrawMod.TGame.se1TypeWriterMedium, num47 + 40, y24, DrawMod.TGame.seColTW);
          num16 = Math.Round((double) index3 / 1000.0, 3);
          tstring33: String = num16.ToString() + "cr";
          if (num5 < 15 | regNr != this.game.Data.Turn)
            tstring33 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring33, DrawMod.TGame.se1TypeWriterMedium, num47 + num14, y24, DrawMod.TGame.seColTW);
          ttitle14: String = "Worker Salary";
          ttext16: String = "The higher the Worker Salary, the more Workers you'll recruit and the less that will leave you. Can be set through giving Zone Orders.";
          trect2 = new Rectangle(num47 + 35, y24 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle14, ttext16);
          int y25 = y24 + 30;
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 5)));
          int num48 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 6)));
          str14: String = "";
          num9 = num48 * 100;
          str15: String = num9.ToString();
          if (index3 >= 1000)
            str15 = Strings.Left(str15, str15.Length - 3) + "." + Strings.Right(str15, 3);
          if (index3 <= 0)
            str14 = "Flex hire and fire";
          if (index3 == 1)
            str14 = "Flex hire, never fire";
          if (index3 == 2)
            str14 = "Flex above " + str15;
          if (index3 == 3)
            str14 = "Hire till " + str15;
          tstring34: String = "'" + str14 + "' Policy";
          if (num5 < 15 | regNr != this.game.Data.Turn)
            tstring34 = "Policy is unknown";
          DrawMod.DrawTextColouredConsole( g, tstring34, DrawMod.TGame.se1TypeWriterMedium, num47 + 40, y25, DrawMod.TGame.seColTW);
          ttitle15: String = "Worker Hiring Policy";
          ttext17: String = "You can choose between several modes through giving Zone Orders. Workers will be hired every start of turn.";
          trect2 = new Rectangle(num47 + 35, y25 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle15, ttext17);
          int y26 = y25 + 30;
          index3 = Math.Max(0,  Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "publicProdPenaltyApplied", 2))));
          int num49 = Math.Max(0,  Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "publicProdPenaltyApplied", 2))));
          int delta5 = index3 - num49;
          tstring35: String = "Prod Pen.";
          DrawMod.DrawTextColouredConsole( g, tstring35, DrawMod.TGame.se1TypeWriterMedium, num47 + 40, y26, DrawMod.TGame.seColTW);
          texty3: String = index3.ToString();
          if (num5 < 15 | flag1)
            texty3 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num47 + num14, y26, texty3, delta5);
          ttitle16: String = "Public Production Penalty This Turn";
          ttext18: String = "This can be caused by Unrest or other issues.";
          trect2 = new Rectangle(num47 + 35, y26 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle16, ttext18);
          int y27 = y26 + 30;
          index3 = Math.Max(0,  Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "publicProdPenalty", 2))));
          int num50 = Math.Max(0,  Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "publicProdPenalty", 2))));
          int delta6 = index3 - num50;
          tstring36: String = "Prod Pen.Nxt";
          DrawMod.DrawTextColouredConsole( g, tstring36, DrawMod.TGame.se1TypeWriterMedium, num47 + 40, y27, DrawMod.TGame.seColTW);
          texty4: String = index3.ToString();
          if (num5 < 15 | flag1)
            texty4 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num47 + num14, y27, texty4, delta6);
          str4 = "Public Production Penalty Next Turn";
          ttext19: String = "This can be caused by Unrest or other issues.";
          trect2 = new Rectangle(num47 + 35, y27 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, str4, ttext19);
          num8 = y27 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 4)
        {
          int num51 = useRect.X + 0;
          int num52 = 0;
           Graphics local15 =  g;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local16 =  bitmap6;
          int x7 = num51;
          int y28 = num52;
          DrawMod.DrawSimple( local15,  local16, x7, y28);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "occupationMode", 2)));
          if (index3 <= 0)
            str4 = "Admin: Regular";
          if (index3 == 1)
            str4 = "Admin: Unincorparated";
          tstring37: String = !(num5 < 8 | flag1 | num7 < 1) ? (!(num3 > -1 & num3 == id) ? str4 + " Zone" : str4 + " Capital Zone") : "Admin: Unknown";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring37, DrawMod.TGame.se1TypeWriterBig, num51 + 283, 17, DrawMod.TGame.seColTW);
          int y29 = num15;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "administrativeStrain", 2)));
          tstring38: String = "Admin.Strain";
          DrawMod.DrawTextColouredConsole( g, tstring38, DrawMod.TGame.se1TypeWriterMedium, num51 + 40, y29, DrawMod.TGame.seColTW);
          tstring39: String = index3.ToString() + "%";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring39 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring39, DrawMod.TGame.se1TypeWriterMedium, num51 + 195, y29, DrawMod.TGame.seColTW);
          ttitle17: String = "Administrative Strain %";
          ttext20: String = "Functions as a production penalty on items. The higher it is, the less efficient your management of the Zone will be.";
          trect2 = new Rectangle(num51 + 35, y29 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle17, ttext20);
          int y30 = y29 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "publicBudget", 2)));
          tstring40: String = "Invest.Budgeted";
          DrawMod.DrawTextColouredConsole( g, tstring40, DrawMod.TGame.se1TypeWriterMedium, num51 + 40, y30, DrawMod.TGame.seColTW);
          tstring41: String = index3.ToString() + "cr";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring41 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring41, DrawMod.TGame.se1TypeWriterMedium, num51 + 195, y30, DrawMod.TGame.seColTW);
          ttitle18: String = "Investment Budgeted per turn";
          ttext21: String = "If you want to see the Private Economy furhter developed alocate Investment Budget for the Zone through Zone Orders.";
          trect2 = new Rectangle(num51 + 35, y30 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle18, ttext21);
          int y31 = y30 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "publicBudgetGiven", 2)));
          tstring42: String = "Invest.Given";
          DrawMod.DrawTextColouredConsole( g, tstring42, DrawMod.TGame.se1TypeWriterMedium, num51 + 40, y31, DrawMod.TGame.seColTW);
          tstring43: String = index3.ToString() + "cr";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring43 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring43, DrawMod.TGame.se1TypeWriterMedium, num51 + 195, y31, DrawMod.TGame.seColTW);
          ttitle19: String = "Investment Given this turn";
          ttext22: String = "You can have a policy in place, but you must have the Credits to actually implement it. This is the amount actually invested.";
          trect2 = new Rectangle(num51 + 35, y31 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle19, ttext22);
          int y32 = y31 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "publicCredits", 2)));
          tstring44: String = "Invest.Treasury";
          DrawMod.DrawTextColouredConsole( g, tstring44, DrawMod.TGame.se1TypeWriterMedium, num51 + 40, y32, DrawMod.TGame.seColTW);
          tstring45: String = index3.ToString() + "cr";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring45 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring45, DrawMod.TGame.se1TypeWriterMedium, num51 + 195, y32, DrawMod.TGame.seColTW);
          ttitle20: String = "Investment Treasury";
          ttext23: String = "Your investments every turn go into this Treasury. Once the Treasury + Private Funds is high enough to purchase a new Private Asset it will happen.";
          trect2 = new Rectangle(num51 + 35, y32 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle20, ttext23);
          int y33 = y32 + 30;
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 9)));
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "emergencyFoodGiven", 2)));
          tstring46: String = "Emergency Food";
          DrawMod.DrawTextColouredConsole( g, tstring46, DrawMod.TGame.se1TypeWriterMedium, num51 + 40, y33, DrawMod.TGame.seColTW);
          tstring47: String = "Unauth.";
          if (index3 == 1)
            tstring47 = "Allowed";
          if (num9 > 0)
            tstring47 = num9.ToString() + " given";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring47 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring47, DrawMod.TGame.se1TypeWriterMedium, num51 + 195, y33, DrawMod.TGame.seColTW);
          ttitle21: String = "Emergency Food";
          ttext24: String = "Can be allowed through giving Zone Orders. If you do you'll support your Population with food handouts if they cannot provide for themselves.";
          trect2 = new Rectangle(num51 + 35, y33 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle21, ttext24);
          num8 = y33 + 30;
          int num53 = num51 + 252;
          int y34 = num15;
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 3)));
          num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 7))) * 100;
          tstring48: String = "Recr.Signup";
          DrawMod.DrawTextColouredConsole( g, tstring48, DrawMod.TGame.se1TypeWriterMedium, num53 + 40, y34, DrawMod.TGame.seColTW);
          str16: String = num9.ToString();
          if (num9 >= 1000)
          {
            num16 = Math.Round((double) num9 / 1000.0, 1);
            str16 = num16.ToString() + "k";
          }
          if (num9 >= 10000)
          {
            num16 = Math.Round((double) num9 / 1000.0, 0);
            str16 = num16.ToString() + "k";
          }
          num16 = Math.Round((double) index3 / 1000.0, 3);
          tstring49: String = num16.ToString() + "cr (" + str16 + ")";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring49 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring49, DrawMod.TGame.se1TypeWriterMedium, num53 + 165, y34, DrawMod.TGame.seColTW);
          ttitle22: String = "Military Recruit Signup Bonus (Maximum Recruits per Turn)";
          ttext25: String = "The higher the bonus, the more recruits you'll find. Can be set through giving Zone Orders.";
          trect2 = new Rectangle(num53 + 35, y34 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle22, ttext25);
          int y35 = y34 + 30;
          index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 4)));
          num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData(0, integer1, 8))) * 100;
          tstring50: String = "Col.Signup";
          DrawMod.DrawTextColouredConsole( g, tstring50, DrawMod.TGame.se1TypeWriterMedium, num53 + 40, y35, DrawMod.TGame.seColTW);
          str17: String = num9.ToString();
          if (num9 >= 1000)
          {
            num16 = Math.Round((double) num9 / 1000.0, 1);
            str17 = num16.ToString() + "k";
          }
          if (num9 >= 10000)
          {
            num16 = Math.Round((double) num9 / 1000.0, 0);
            str17 = num16.ToString() + "k";
          }
          num16 = Math.Round((double) index3 / 1000.0, 3);
          tstring51: String = num16.ToString() + "cr (" + str17 + ")";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring51 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring51, DrawMod.TGame.se1TypeWriterMedium, num53 + 165, y35, DrawMod.TGame.seColTW);
          ttitle23: String = "Colonist Signup Bonus (Max Colonists recruited per Turn)";
          ttext26: String = "The higher the bonus, the more colonists you'll find. Can be set through giving Zone Orders.";
          trect2 = new Rectangle(num53 + 35, y35 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle23, ttext26);
          int y36 = y35 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById8].GetData2(0, num2, 1, "incomeTax", 2)));
          tstring52: String = "Income Tax";
          DrawMod.DrawTextColouredConsole( g, tstring52, DrawMod.TGame.se1TypeWriterMedium, num53 + 40, y36, DrawMod.TGame.seColTW);
          tstring53: String = index3.ToString() + "%";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring53 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring53, DrawMod.TGame.se1TypeWriterMedium, num53 + 165, y36, DrawMod.TGame.seColTW);
          ttitle24: String = "Income Tax";
          ttext27: String = "This tax can be imposed on your Population when they sell  Items to Traders.";
          trect2 = new Rectangle(num53 + 35, y36 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle24, ttext27);
          int y37 = y36 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById8].GetData2(0, num2, 1, "salesTax", 2)));
          tstring54: String = "Sales Tax";
          DrawMod.DrawTextColouredConsole( g, tstring54, DrawMod.TGame.se1TypeWriterMedium, num53 + 40, y37, DrawMod.TGame.seColTW);
          tstring55: String = index3.ToString() + "%";
          if (flag1 | num5 < 15 | num13 < 1)
            tstring55 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring55, DrawMod.TGame.se1TypeWriterMedium, num53 + 165, y37, DrawMod.TGame.seColTW);
          ttitle25: String = "Sales Tax";
          ttext28: String = "This tax can be imposed on Traders when they sell items to your Populace.";
          trect2 = new Rectangle(num53 + 35, y37 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle25, ttext28);
          int y38 = y37 + 30;
          str18: String = index2 <= -1 ? "None" : this.game.Data.UnitObj[index2].Name;
          if (flag1 | num5 < 15)
            str18 = "?";
          str19: String = str18;
          if (str18.Length > 13)
            str18 = Strings.Left(str18, 13) + ".";
          DrawMod.DrawTextColouredConsole( g, "Attached to: " + str18, DrawMod.TGame.se1TypeWriterMedium, num53 + 40, y38, DrawMod.TGame.seColTW);
          ttitle26: String = "Zone's SHQ";
          ttext29: String = "This Zone is attached to " + str19 + ".";
          trect2 = new Rectangle(num53 + 35, y38 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle26, ttext29);
          num8 = y38 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 5)
        {
          int num54 = useRect.X + 0;
          int num55 = 0;
           Graphics local17 =  g;
          Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local18 =  bitmap7;
          int x8 = num54;
          int y39 = num55;
          DrawMod.DrawSimple( local17,  local18, x8, y39);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popHapiness", 2)));
          tstring56: String = "Population Happiness: " + index3.ToString();
          if (num5 < 3 | num7 < 1)
            tstring56 = "Population Happiness: ?";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring56, DrawMod.TGame.se1TypeWriterBig, num54 + 283, 17, DrawMod.TGame.seColTW);
          int y40 = num15;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popLoyalty", 2)));
          int num56 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "popLoyalty", 2)));
          int delta7 = index3 - num56;
          tstring57: String = "Loyalty";
          DrawMod.DrawTextColouredConsole( g, tstring57, DrawMod.TGame.se1TypeWriterMedium, num54 + 40, y40, DrawMod.TGame.seColTW);
          texty5: String = index3.ToString();
          if (num5 < 13 | num13 < 1)
            texty5 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num54 + num14, y40, texty5, delta7);
          ttitle27: String = "Loyalty";
          ttext30: String = "The lower the Loyalty the more chance things can turn sour in case of Unrest. Furthermore it impacts your Recruitment efforts.";
          trect2 = new Rectangle(num54 + 35, y40 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle27, ttext30);
          int y41 = y40 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popHunger", 2)));
          int num57 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "popHunger", 2)));
          int delta8 = index3 - num57;
          tstring58: String = "Hunger";
          DrawMod.DrawTextColouredConsole( g, tstring58, DrawMod.TGame.se1TypeWriterMedium, num54 + 40, y41, DrawMod.TGame.seColTW);
          texty6: String = index3.ToString() + " Pts";
          if (index3 < 1)
            texty6 = "None";
          if (num5 < 13 | num13 < 1)
            texty6 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num54 + num14, y41, texty6, delta8);
          ttitle28: String = "Population Hunger Score";
          ttext31: String = "Ideally there is no hunger. Between 1-100 Hunger Points it has bad effect on happiness. Above 100 starvation starts. Maximum 300 points.";
          trect2 = new Rectangle(num54 + 35, y41 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle28, ttext31);
          int y42 = y41 + 30;
          int num58 = 0;
          if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData2(0, num2, 1, "extraCasualtyTreshold", 2))) > 0)
            num58 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData2(0, num2, 1, "extraCasualtyTreshold", 2)));
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "shortTermWarCasualties", 2)));
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "shortTermWarCasualtyTreshold", 2)));
          tstring59: String = "Short Cas.";
          num9 +=  Math.Round((double) (index3 * num58) / 100.0);
          DrawMod.DrawTextColouredConsole( g, tstring59, DrawMod.TGame.se1TypeWriterMedium, num54 + 40, y42, DrawMod.TGame.seColTW);
          str20: String = Math.Round((double) index3 / 10.0, 1).ToString();
          num16 = Math.Round((double) num9 / 10.0, 1);
          str21: String = num16.ToString();
          tstring60: String = str20 + "% / " + str21 + "%";
          if (flag1 | num5 < 13)
            tstring60 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring60, DrawMod.TGame.se1TypeWriterMedium, num54 + num14, y42, DrawMod.TGame.seColTW);
          ttitle29: String = "Short Term Average Casualty Rate / Treshold";
          ttext32: String = "Try to keep the Short Term Causalties (Average last 3 rounds) below the Treshold to avoid negative consequences.";
          trect2 = new Rectangle(num54 + 35, y42 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle29, ttext32);
          int y43 = y42 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "longTermWarCasualties", 2)));
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "longTermWarCasualtyTreshold", 2)));
          num9 +=  Math.Round((double) (index3 * num58) / 100.0);
          tstring61: String = "Long Cas.";
          DrawMod.DrawTextColouredConsole( g, tstring61, DrawMod.TGame.se1TypeWriterMedium, num54 + 40, y43, DrawMod.TGame.seColTW);
          num16 = Math.Round((double) index3 / 10.0, 1);
          tstring62: String = num16.ToString() + "% / " + Math.Round((double) num9 / 10.0, 1).ToString() + "%";
          if (flag1 | num5 < 13)
            tstring62 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring62, DrawMod.TGame.se1TypeWriterMedium, num54 + num14, y43, DrawMod.TGame.seColTW);
          ttitle30: String = "Long Term Average Casualty Rate / Treshold";
          ttext33: String = "Try to keep the Long Term Causalties (Average last 20 rounds) below the Treshold to avoid negative consequences.";
          trect2 = new Rectangle(num54 + 35, y43 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle30, ttext33);
          num8 = y43 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 6)
        {
          int num59 = useRect.X + 0;
          int num60 = 0;
           Graphics local19 =  g;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local20 =  bitmap8;
          int x9 = num59;
          int y44 = num60;
          DrawMod.DrawSimple( local19,  local20, x9, y44);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "workerHapiness", 2)));
          tstring63: String = "Worker Happiness: " + index3.ToString();
          if (num5 < 3 | flag1 | num7 < 1)
            tstring63 = "Worker Happiness: ?";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring63, DrawMod.TGame.se1TypeWriterBig, num59 + 283, 17, DrawMod.TGame.seColTW);
          int y45 = num15;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "workerHunger", 2)));
          int num61 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "workerHunger", 2)));
          int delta = index3 - num61;
          tstring64: String = "Hunger";
          DrawMod.DrawTextColouredConsole( g, tstring64, DrawMod.TGame.se1TypeWriterMedium, num59 + 40, y45, DrawMod.TGame.seColTW);
          texty: String = index3.ToString() + " Pts";
          if (index3 < 1)
            texty = "None";
          if (flag1 | num5 < 13)
            texty = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num59 + num14, y45, texty, delta);
          ttitle: String = "Worker Hunger Score";
          ttext: String = "Ideally there is no hunger. Between 1-100 Hunger Points it has bad effect on happiness. Above 100 starvation starts. Maximum 300 points.";
          trect2 = new Rectangle(num59 + 35, y45 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle, ttext);
          num8 = y45 + 30;
        }
        Bitmap bitmap9;
        if (this.game.EditObj.se1_SelectZoneButton == 7)
        {
          num14 = 180;
          int num62 = useRect.X + 0;
          int num63 = 0;
           Graphics local21 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local22 =  bitmap9;
          int x10 = num62;
          int y46 = num63;
          DrawMod.DrawSimple( local21,  local22, x10, y46);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "culture", 2)));
          tstring65: String = "Civilisation Score: " + index3.ToString();
          if (num5 < 7 | num7 < 1)
            tstring65 = "Civilisation Score: ?";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring65, DrawMod.TGame.se1TypeWriterBig, num62 + 283, 17, DrawMod.TGame.seColTW);
          int y47 = num15;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "qol", 2)));
          int num64 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "qol", 2)));
          int delta9 = index3 - num64;
          tstring66: String = "QOL Score";
          DrawMod.DrawTextColouredConsole( g, tstring66, DrawMod.TGame.se1TypeWriterMedium, num62 + 40, y47, DrawMod.TGame.seColTW);
          texty7: String = index3.ToString();
          if (num5 < 13)
            texty7 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14, y47, texty7, delta9);
          ttitle31: String = "Quality of Life (QOL)";
          ttext34: String = "Based on the Health,Security,Education and Entertainment QOL Scores.\r\n\r\nIf QOL is higher than Zone Civilisation Score it will increase Happiness. If it is lower than Zone Civilisation Score it will decrease Happiness. \r\n\r\nThe high limit for Zone QOL is the (QOL Score average + Lowest QOL Score)/2.";
          trect2 = new Rectangle(num62 + 35, y47 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle31, ttext34);
          int y48 = y47 + 30;
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "qol_health", 2)));
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "health", 2)));
          int num65 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "qol_health", 2)));
          int num66 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "health", 2)));
          int delta10 = index3 - num66;
          int delta11 = num9 - num65;
          tstring67: String = "Health Score";
          DrawMod.DrawTextColouredConsole( g, tstring67, DrawMod.TGame.se1TypeWriterMedium, num62 + 40, y48, DrawMod.TGame.seColTW);
          texty8: String = index3.ToString();
          if (num5 < 13)
            texty8 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14, y48, texty8, delta10);
          ttitle32: String = "Quality of Life Health subscore";
          ttext35: String = "Based on Health Points. The QOL Points get divided by City Level to arrive at the QOL Score.";
          trect2 = new Rectangle(num62 + 35, y48 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle32, ttext35);
          tstring68: String = "Health Points";
          DrawMod.DrawTextColouredConsole( g, tstring68, DrawMod.TGame.se1TypeWriterMedium, num62 + 290, y48, DrawMod.TGame.seColTW);
          texty9: String = num9.ToString();
          if (num5 < 13)
            texty9 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + 250 + num14, y48, texty9, delta11);
          ttitle33: String = "Health Points";
          ttext36: String = "These Points get generated by Assets like Hospitals or Sewers.";
          trect2 = new Rectangle(num62 + 285, y48 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle33, ttext36);
          int y49 = y48 + 30;
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "qol_security", 2)));
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "security", 2)));
          int num67 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "qol_security", 2)));
          int num68 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "security", 2)));
          int delta12 = index3 - num68;
          int delta13 = num9 - num67;
          tstring69: String = "Security Score";
          DrawMod.DrawTextColouredConsole( g, tstring69, DrawMod.TGame.se1TypeWriterMedium, num62 + 40, y49, DrawMod.TGame.seColTW);
          texty10: String = index3.ToString();
          if (num5 < 13)
            texty10 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14, y49, texty10, delta12);
          ttitle34: String = "Quality of Life Security subscore";
          ttext37: String = "Based on Security Points. The QOL Points get divided by City Level to arrive at the QOL Score.";
          trect2 = new Rectangle(num62 + 35, y49 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle34, ttext37);
          tstring70: String = "Security Points";
          DrawMod.DrawTextColouredConsole( g, tstring70, DrawMod.TGame.se1TypeWriterMedium, num62 + 290, y49, DrawMod.TGame.seColTW);
          texty11: String = num9.ToString();
          if (num5 < 13)
            texty11 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14 + 250, y49, texty11, delta13);
          ttitle35: String = "Security Points";
          ttext38: String = "These scores get generated by Assets like Scout Station.";
          trect2 = new Rectangle(num62 + 285, y49 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle35, ttext38);
          int y50 = y49 + 30;
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "qol_education", 2)));
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "education", 2)));
          int num69 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "qol_education", 2)));
          int num70 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "education", 2)));
          int delta14 = index3 - num70;
          int delta15 = num9 - num69;
          tstring71: String = "Education Score";
          DrawMod.DrawTextColouredConsole( g, tstring71, DrawMod.TGame.se1TypeWriterMedium, num62 + 40, y50, DrawMod.TGame.seColTW);
          texty12: String = index3.ToString();
          if (num5 < 13)
            texty12 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14, y50, texty12, delta14);
          ttitle36: String = "Quality of Life Education subscore";
          ttext39: String = "Based on Education Points. The QOL Points get divided by City Level to arrive at the QOL Score.";
          trect2 = new Rectangle(num62 + 35, y50 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle36, ttext39);
          tstring72: String = "Education Points";
          DrawMod.DrawTextColouredConsole( g, tstring72, DrawMod.TGame.se1TypeWriterMedium, num62 + 290, y50, DrawMod.TGame.seColTW);
          texty13: String = num9.ToString();
          if (num5 < 13)
            texty13 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14 + 250, y50, texty13, delta15);
          ttitle37: String = "Education Points";
          ttext40: String = "These scores get generated by Assets like Schools or Universities.";
          trect2 = new Rectangle(num62 + 285, y50 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle37, ttext40);
          int y51 = y50 + 30;
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "qol_entertainment", 2)));
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "entertainment", 2)));
          num10 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "qol_entertainment", 2)));
          int num71 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "entertainment", 2)));
          int delta16 = index3 - num71;
          int delta17 = num9 - num10;
          tstring73: String = "Entert. Score";
          DrawMod.DrawTextColouredConsole( g, tstring73, DrawMod.TGame.se1TypeWriterMedium, num62 + 40, y51, DrawMod.TGame.seColTW);
          texty14: String = index3.ToString();
          if (num5 < 13)
            texty14 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14, y51, texty14, delta16);
          ttitle38: String = "Quality of Life Entertainment subscore";
          ttext41: String = "Based on Entertainment Points. The QOL Points get divided by City Level to arrive at the QOL Score.";
          trect2 = new Rectangle(num62 + 35, y51 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle38, ttext41);
          tstring74: String = "Entert. Points";
          DrawMod.DrawTextColouredConsole( g, tstring74, DrawMod.TGame.se1TypeWriterMedium, num62 + 290, y51, DrawMod.TGame.seColTW);
          texty15: String = num9.ToString();
          if (num5 < 13)
            texty15 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num62 + num14 + 250, y51, texty15, delta17);
          ttitle39: String = "Entert. Points";
          ttext42: String = "These scores get generated by Assets like Arena's or Brothels.";
          trect2 = new Rectangle(num62 + 285, y51 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle39, ttext42);
          num8 = y51 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 8)
        {
          int num72 = useRect.X + 0;
          int num73 = 0;
           Graphics local23 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME4);
           Bitmap local24 =  bitmap9;
          int x11 = num72;
          int y52 = num73;
          DrawMod.DrawSimple( local23,  local24, x11, y52);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "cas", 2)));
          num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 9)));
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2)));
          int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num2, 2)));
          if (num9 == idValue2)
            index3 = 100;
          str22: String = "Cultural Adaptation Score: " + index3.ToString();
          if (num5 < 3 | num7 < 1)
            str22 = "Cultural Adaptation Score: ?";
          DrawMod.DrawTextColouredConsoleCenter( g, str22, DrawMod.TGame.se1TypeWriterBig, num72 + 283, 17, DrawMod.TGame.seColTW);
          int y53 = 52;
          tstring75: String = this.game.Data.StringListObj[stringListById13].GetData(0, num9, 4);
          int idValue3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData(0, num9, 1)));
          str23: String = this.game.Data.StringListObj[stringListById14].GetData(0, idValue3, 1);
          data2: String = this.game.Data.StringListObj[stringListById13].GetData(0, idValue2, 4);
          if (num9 < 1)
          {
            tstring75 = "Unknown Culture";
            str23 = "Unknown Culture Group";
          }
          if (idValue1 < 1)
          {
            tstring75 = "Unknown Culture";
            str23 = "Unknown Culture Group";
          }
          if (num5 < 3)
          {
            tstring75 = "Unknown Culture";
            str23 = "Unknown Culture Group";
          }
          if (tstring75.Length > 24)
            str1 = Strings.Left(str22, 24) + ".";
          DrawMod.DrawTextColouredConsole( g, "Culture Name", DrawMod.TGame.se1TypeWriterMedium, num72 + 40, y53, DrawMod.TGame.seColTW);
          DrawMod.DrawTextColouredConsole( g, tstring75, DrawMod.TGame.se1TypeWriterMedium, num72 + 195, y53, DrawMod.TGame.seColTW);
          string ttitle40;
          string ttext43;
          if (regNr == this.game.Data.Turn)
          {
            ttitle40 = "Population Culture";
            ttext43 = "If the Culture is different from your Regime's Culture (" + data2 + ") it will pose problems recruiting Workers and military Recruits.";
          }
          else
          {
            ttitle40 = "Population Culture";
            ttext43 = "If the Culture is different from your Regime's Culture it will pose problems recruiting Workers and military Recruits.";
          }
          trect2 = new Rectangle(num72 + 35, y53 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle40, ttext43);
          int y54 = y53 + 30;
          if (this.game.SuperAdminRights)
          {
            int num74 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById15].GetData2(0, num9, 1, "alien", 2)));
            if (num74 > 0)
            {
              tstring76: String = "Alien";
              DrawMod.DrawTextColouredConsole( g, tstring76, DrawMod.TGame.se1TypeWriterMedium, num72 + 40 + 200, y54, DrawMod.TGame.seColTW);
              tstring77: String = num74.ToString();
              DrawMod.DrawTextColouredConsole( g, tstring77, DrawMod.TGame.se1TypeWriterMedium, num72 + 195 + 200, y54, DrawMod.TGame.seColTW);
              ttitle41: String = "Alien";
              ttext44: String = "";
              trect2 = new Rectangle(num72 + 35 + 200, y54 - 10, 250, 30);
              trect1 = trect2;
              this.AddMouse( trect1, ttitle41, ttext44);
            }
          }
          tSlotNr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById15].GetData2(0, num9, 1, "tradition", 2)));
          tstring78: String = "Tradition";
          DrawMod.DrawTextColouredConsole( g, tstring78, DrawMod.TGame.se1TypeWriterMedium, num72 + 40, y54, DrawMod.TGame.seColTW);
          tstring79: String = tSlotNr.ToString();
          if (num5 < 3)
            tstring79 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring79, DrawMod.TGame.se1TypeWriterMedium, num72 + 195, y54, DrawMod.TGame.seColTW);
          ttitle42: String = "Tradition";
          ttext45: String = "Negative score means this Culture is not very Traditional. Positive scores means they are more Traditional. Tradition influences speed of Cultural Adjustment.";
          trect2 = new Rectangle(num72 + 35, y54 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle42, ttext45);
          int y55 = y54 + 30;
          tSlotNr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById15].GetData2(0, num9, 1, "fertility", 2)));
          tstring80: String = "Fertility";
          DrawMod.DrawTextColouredConsole( g, tstring80, DrawMod.TGame.se1TypeWriterMedium, num72 + 40, y55, DrawMod.TGame.seColTW);
          tstring81: String = tSlotNr.ToString();
          if (num5 < 3)
            tstring81 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring81, DrawMod.TGame.se1TypeWriterMedium, num72 + 195, y55, DrawMod.TGame.seColTW);
          ttitle43: String = "Fertility";
          ttext46: String = "Negative score means this Culture is not very Fertile. Positive scores means they are more Fertile. Fertility influences natural growth by reproduction of the Inhabitants.";
          trect2 = new Rectangle(num72 + 35, y55 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle43, ttext46);
          int y56 = y55 + 30;
          tSlotNr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById15].GetData2(0, num9, 1, "agression", 2)));
          tstring82: String = "Aggression";
          DrawMod.DrawTextColouredConsole( g, tstring82, DrawMod.TGame.se1TypeWriterMedium, num72 + 40, y56, DrawMod.TGame.seColTW);
          tstring83: String = tSlotNr.ToString();
          if (num5 < 3)
            tstring83 = "?";
          DrawMod.DrawTextColouredConsole( g, tstring83, DrawMod.TGame.se1TypeWriterMedium, num72 + 195, y56, DrawMod.TGame.seColTW);
          ttitle44: String = "Aggression";
          ttext47: String = "Impacts your chance on succes when playing Peace,Client or Protectorate Stratagems as well as their general diplomatic behaviour.";
          trect2 = new Rectangle(num72 + 35, y56 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle44, ttext47);
          int y57 = y56 + 30;
          tstring84: String = "Culture Group";
          DrawMod.DrawTextColouredConsole( g, tstring84, DrawMod.TGame.se1TypeWriterMedium, num72 + 40, y57, DrawMod.TGame.seColTW);
          tstring85: String = str23;
          DrawMod.DrawTextColouredConsole( g, tstring85, DrawMod.TGame.se1TypeWriterMedium, num72 + 195, y57, DrawMod.TGame.seColTW);
          ttitle45: String = "Culture Group";
          ttext48: String = "Not the name of the specific culture, but the classification of the Culture this Zone has.";
          trect2 = new Rectangle(num72 + 35, y57 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle45, ttext48);
          num8 = y57 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 9)
        {
          int num75 = useRect.X + 0;
          int num76 = 0;
          bool flag4 = false;
          SimpleList simpleList = SimpleList::new();
          if (this.game.EventRelatedObj.Helper_AirEnabled())
          {
            flag4 = true;
            simpleList = this.game.HandyFunctionsObj.Air_getListofAirBridgeRows(integer1);
            if (simpleList.Counter == -1)
              flag4 = false;
            if (regNr != this.game.Data.Turn)
              flag4 = false;
          }
          int num77 = 30;
          if (flag4)
          {
             Graphics local25 =  g;
            bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1air);
             Bitmap local26 =  bitmap9;
            int x12 = num75;
            int y58 = num76;
            DrawMod.DrawSimple( local25,  local26, x12, y58);
            num77 = 18;
          }
          else
          {
             Graphics local27 =  g;
            bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
             Bitmap local28 =  bitmap9;
            int x13 = num75;
            int y59 = num76;
            DrawMod.DrawSimple( local27,  local28, x13, y59);
          }
          tstring86: String = "Logistics";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring86, DrawMod.TGame.se1TypeWriterBig, num75 + 283, 17, DrawMod.TGame.seColTW);
          int y60 = 52;
          if (flag4)
            y60 = 45;
          int library = this.game.Data.FindLibrary("SE_Asset");
          bool flag5 = false;
          str24: String = "";
          str25: String = "";
          str26: String = "";
          str27: String = "";
          str28: String = "";
          str29: String = "";
          str30: String = "";
          str31: String = "";
          str32: String = "";
          str33: String = "";
          if (library > -1 && this.game.Data.LibraryObj[library].version >= 2)
          {
            flag5 = true;
            data3: DataClass = this.game.Data;
            str34: String = "Zones";
             local29: String =  str34;
            libName2: String = libName1;
            tSlotNr = data3.FindLibVar( local29, libName2);
            AIMatrix aiMatrix = new AIMatrix( this.game.DC2AIObj);
            int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
            for (int index8 = 0; index8 <= mapWidth1; index8 += 1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index9 = 0; index9 <= mapHeight; index9 += 1)
                aiMatrix.Value[index8, index9] = this.game.Data.MapObj[0].HexObj[index8, index9].GetHexLibVarValue(tSlotNr);
            }
            index3 = 0;
            int num78 = 0;
            num9 = 0;
            num10 = 0;
            int num79 = 0;
            int num80 = 0;
            idValue1 = 0;
            num11 = 0;
            tSlotNr = 0;
            int num81 = 0;
            int num82 = 0;
            int num83 = 0;
            data4: DataClass = this.game.Data;
            str2 = "truckPoints";
             local30: String =  str2;
            libName3: String = libName1;
            int libVar1 = data4.FindLibVar( local30, libName3);
            data5: DataClass = this.game.Data;
            str2 = "truckFreeAp";
             local31: String =  str2;
            libName4: String = libName1;
            int libVar2 = data5.FindLibVar( local31, libName4);
            data6: DataClass = this.game.Data;
            str2 = "maglevPoints";
             local32: String =  str2;
            libName5: String = libName1;
            int libVar3 = data6.FindLibVar( local32, libName5);
            data7: DataClass = this.game.Data;
            str2 = "maglevFreeAp";
             local33: String =  str2;
            libName6: String = libName1;
            int libVar4 = data7.FindLibVar( local33, libName6);
            data8: DataClass = this.game.Data;
            str2 = "prevTruckPoints";
             local34: String =  str2;
            libName7: String = libName1;
            int libVar5 = data8.FindLibVar( local34, libName7);
            data9: DataClass = this.game.Data;
            str2 = "prevTruckFreeAp";
             local35: String =  str2;
            libName8: String = libName1;
            int libVar6 = data9.FindLibVar( local35, libName8);
            data10: DataClass = this.game.Data;
            str2 = "prevMaglevPoints";
             local36: String =  str2;
            libName9: String = libName1;
            int libVar7 = data10.FindLibVar( local36, libName9);
            data11: DataClass = this.game.Data;
            str2 = "prevMaglevFreeAp";
             local37: String =  str2;
            libName10: String = libName1;
            int libVar8 = data11.FindLibVar( local37, libName10);
            data12: DataClass = this.game.Data;
            str2 = "airbasePoints";
             local38: String =  str2;
            libName11: String = libName1;
            int libVar9 = data12.FindLibVar( local38, libName11);
            data13: DataClass = this.game.Data;
            str2 = "prevAirbasePoints";
             local39: String =  str2;
            libName12: String = libName1;
            int libVar10 = data13.FindLibVar( local39, libName12);
            int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
            for (int index10 = 0; index10 <= mapWidth2; index10 += 1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index11 = 0; index11 <= mapHeight; index11 += 1)
              {
                if (aiMatrix.Value[index10, index11] == integer1)
                {
                  int hexLibVarValue1 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar1);
                  if (hexLibVarValue1 > 0)
                  {
                    num9 += hexLibVarValue1;
                    str24 = str24 + "\r\n• " + hexLibVarValue1.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue2 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar2);
                  if (hexLibVarValue2 > 0)
                  {
                    num79 += hexLibVarValue2;
                    str26 = str26 + "\r\n• " + hexLibVarValue2.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue3 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar3);
                  if (hexLibVarValue3 > 0)
                  {
                    idValue1 += hexLibVarValue3;
                    str28 = str28 + "\r\n• " + hexLibVarValue3.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue4 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar4);
                  if (hexLibVarValue4 > 0)
                  {
                    tSlotNr += hexLibVarValue4;
                    str30 = str30 + "\r\n• " + hexLibVarValue4.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue5 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar5);
                  if (hexLibVarValue5 > 0)
                  {
                    num10 += hexLibVarValue5;
                    str25 = str25 + "\r\n• " + hexLibVarValue5.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue6 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar6);
                  if (hexLibVarValue6 > 0)
                  {
                    num80 += hexLibVarValue6;
                    str27 = str27 + "\r\n• " + hexLibVarValue6.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue7 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar7);
                  if (hexLibVarValue7 > 0)
                  {
                    num11 += hexLibVarValue7;
                    str29 = str29 + "\r\n• " + hexLibVarValue7.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue8 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar8);
                  if (hexLibVarValue8 > 0)
                  {
                    num81 += hexLibVarValue8;
                    str31 = str31 + "\r\n• " + hexLibVarValue8.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue9 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar9);
                  if (hexLibVarValue9 > 0)
                  {
                    num82 += hexLibVarValue9;
                    str32 = str32 + "\r\n• " + hexLibVarValue9.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                  int hexLibVarValue10 = this.game.Data.MapObj[0].HexObj[index10, index11].GetHexLibVarValue(libVar10);
                  if (hexLibVarValue10 > 0)
                  {
                    num83 += hexLibVarValue10;
                    str33 = str33 + "\r\n• " + hexLibVarValue10.ToString() + " points from " + index10.ToString() + "," + index11.ToString();
                  }
                }
              }
            }
            index3 = num9;
            int num84 = num10;
            tstring87: String = "Truck Points";
            DrawMod.DrawTextColouredConsole( g, tstring87, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y60, DrawMod.TGame.seColTW);
            tstring88: String = num84.ToString();
            if (this.game.Data.Turn != regNr)
              tstring88 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring88, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y60, DrawMod.TGame.seColTW);
            ttitle46: String = "Truck Points";
            ttext49: String = "The amount of logistical truck points this Zone had available for use at start of turn.";
            if (str24.Length > 1)
              ttext49 += str24;
            trect2 = new Rectangle(num75 + 35, y60 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle46, ttext49);
            int y61 = y60 + num77;
            index3 = num79;
            int num85 = num80;
            tstring89: String = "Truck Range";
            DrawMod.DrawTextColouredConsole( g, tstring89, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y61, DrawMod.TGame.seColTW);
            tstring90: String = num85.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring90 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring90, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y61, DrawMod.TGame.seColTW);
            ttitle47: String = "Truck Range in AP";
            ttext50: String = "The Action Point Range this Zone had available for use at start of turn.";
            if (str26.Length > 1)
              ttext50 += str26;
            trect2 = new Rectangle(num75 + 35, y61 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle47, ttext50);
            int y62 = y61 + num77;
            index3 = idValue1;
            int num86 = num11;
            tstring91: String = "Rail Points";
            DrawMod.DrawTextColouredConsole( g, tstring91, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y62, DrawMod.TGame.seColTW);
            tstring92: String = num86.ToString();
            if (this.game.Data.Turn != regNr)
              tstring92 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring92, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y62, DrawMod.TGame.seColTW);
            ttitle48: String = "Rail Points";
            ttext51: String = "The amount of logistical truck points this Zone had available for use at start of turn.";
            if (str28.Length > 1)
              ttext51 += str28;
            trect2 = new Rectangle(num75 + 35, y62 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle48, ttext51);
            int y63 = y62 + num77;
            index3 = tSlotNr;
            int num87 = num81;
            tstring93: String = "Rail Range";
            DrawMod.DrawTextColouredConsole( g, tstring93, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y63, DrawMod.TGame.seColTW);
            tstring94: String = num87.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring94 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring94, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y63, DrawMod.TGame.seColTW);
            ttitle49: String = "Rail Range in AP";
            ttext52: String = "The Action Point Range this Zone had available for use at start of turn.";
            if (str30.Length > 1)
              ttext52 += str30;
            trect2 = new Rectangle(num75 + 35, y63 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle49, ttext52);
            int y64 = y63 + num77;
            index3 = num82;
            int num88 = num83;
            tstring95: String = "Airbase Points";
            DrawMod.DrawTextColouredConsole( g, tstring95, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y64, DrawMod.TGame.seColTW);
            tstring96: String = num88.ToString();
            if (this.game.Data.Turn != regNr)
              tstring96 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring96, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y64, DrawMod.TGame.seColTW);
            ttitle50: String = "Airbase Points";
            ttext53: String = "To keep your Air Units well serviced you need Airbase Points on their Hexes.";
            if (str32.Length > 1)
              ttext53 += str32;
            trect2 = new Rectangle(num75 + 35, y64 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle50, ttext53);
            num8 = y64 + num77;
            num75 += 250;
            int y65 = 52;
            if (flag4)
              y65 = 45;
            index3 = num9;
            num78 = num10;
            tstring97: String = "Next Turn Points";
            DrawMod.DrawTextColouredConsole( g, tstring97, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y65, DrawMod.TGame.seColTW);
            tstring98: String = index3.ToString();
            if (this.game.Data.Turn != regNr)
              tstring98 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring98, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y65, DrawMod.TGame.seColTW);
            ttitle51: String = "Next Turn Range";
            ttext54: String = "The amount of logistical truck points generated by this zone. These will be used in the next turn to provide your Logistical Network.";
            if (str25.Length > 1)
              ttext54 += str25;
            trect2 = new Rectangle(num75 + 35, y65 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle51, ttext54);
            int y66 = y65 + num77;
            index3 = num79;
            num78 = num80;
            tstring99: String = "Next Turn Range";
            DrawMod.DrawTextColouredConsole( g, tstring99, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y66, DrawMod.TGame.seColTW);
            tstring100: String = index3.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring100 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring100, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y66, DrawMod.TGame.seColTW);
            ttitle52: String = "Next Truck Range in AP";
            ttext55: String = "The Action Point Range that got generated for this Zone. These will be used in the next turn to provide your Logistical Network and originate from the Zone's City.";
            if (str27.Length > 1)
              ttext55 += str27;
            trect2 = new Rectangle(num75 + 35, y66 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle52, ttext55);
            int y67 = y66 + num77;
            index3 = idValue1;
            num78 = num11;
            tstring101: String = "Next Turn Points";
            DrawMod.DrawTextColouredConsole( g, tstring101, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y67, DrawMod.TGame.seColTW);
            tstring102: String = index3.ToString();
            if (this.game.Data.Turn != regNr)
              tstring102 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring102, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y67, DrawMod.TGame.seColTW);
            ttitle53: String = "Next Turn Range";
            ttext56: String = "The amount of logistical truck points generated by this zone. These will be used in the next turn to provide your Logistical Network.";
            if (str29.Length > 1)
              ttext56 += str29;
            trect2 = new Rectangle(num75 + 35, y67 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle53, ttext56);
            int y68 = y67 + num77;
            index3 = tSlotNr;
            num78 = num81;
            tstring103: String = "Next Turn Range";
            DrawMod.DrawTextColouredConsole( g, tstring103, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y68, DrawMod.TGame.seColTW);
            tstring104: String = index3.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring104 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring104, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y68, DrawMod.TGame.seColTW);
            ttitle54: String = "Next Truck Range in AP";
            ttext57: String = "The Action Point Range that got generated for this Zone. These will be used in the next turn to provide your Logistical Network and originate from the Zone's City.";
            if (str31.Length > 1)
              ttext57 += str31;
            trect2 = new Rectangle(num75 + 35, y68 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle54, ttext57);
            int y69 = y68 + num77;
            index3 = num82;
            num78 = num83;
            tstring105: String = "Next Turn Points";
            DrawMod.DrawTextColouredConsole( g, tstring105, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y69, DrawMod.TGame.seColTW);
            tstring106: String = index3.ToString();
            if (this.game.Data.Turn != regNr)
              tstring106 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring106, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y69, DrawMod.TGame.seColTW);
            ttitle55: String = "Next Turn Airbase Points";
            ttext58: String = "To keep your Air Units well serviced you need Airbase Points on their Hexes.";
            if (str33.Length > 1)
              ttext58 += str33;
            trect2 = new Rectangle(num75 + 35, y69 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle55, ttext58);
            y60 = y69 + num77;
          }
          if (flag4 & this.game.Data.Turn == regNr)
          {
            int num89 = 0;
            simpleList.ReverseSort();
            int stringListById19 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 534, 0, 0));
            int counter = simpleList.Counter;
            for (int index12 = 0; index12 <= counter; index12 += 1)
            {
              int row2 = this.game.Data.StringListObj[stringListById19].FindRow2(0, num2, 8, simpleList.Id[index12]);
              if (row2 > -1)
              {
                if (row2 > -1 & num89 < 9)
                {
                  num89 += 1;
                  if (num89 <= 3)
                    num75 = useRect.X + 0;
                  letter: String = this.game.HandyFunctionsObj.CovertNumberToLetter(simpleList.Id[index12]);
                  int num90 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 9]));
                  Color color = this.game.HandyFunctionsObj.Air_GetColor(row2);
                  int tcol = 0;
                  if (simpleList.Data1[index12] == 1)
                  {
                    index3 = 40;
                    DrawMod.DrawTextColouredConsole( g, "=>", DrawMod.TGame.se1TypeWriterMedium, num75 + 60, y60, DrawMod.TGame.seColTW);
                  }
                  else if (simpleList.Data1[index12] == 3)
                  {
                    index3 = 50;
                    DrawMod.DrawTextColouredConsole( g, ">", DrawMod.TGame.se1TypeWriterMedium, num75 + 70, y60, DrawMod.TGame.seColTW);
                    DrawMod.DrawTextColouredConsole( g, ">", DrawMod.TGame.se1TypeWriterMedium, num75 + 37, y60, DrawMod.TGame.seColTW);
                  }
                  else
                  {
                    index3 = 60;
                    DrawMod.DrawTextColouredConsole( g, "=>", DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y60, DrawMod.TGame.seColTW);
                  }
                  DrawMod.DrawBlock( g, num75 + index3, y60 + 3, 18, 13,  color.R,  color.G,  color.B,  color.A);
                  DrawMod.DrawTextCenterSmallLabel( g, letter, this.game.MarcFont4, num75 - 1 + index3 + 10, y60 + 10, tcol);
                  int num91 = num75 + 60;
                  index3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 5]));
                  num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 6]));
                  idValue1 = this.game.HandyFunctionsObj.Air_getNextTurnAirPoints(regNr, simpleList.Id[row2]);
                  tSlotNr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 10]));
                  int num92 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 7]));
                  int num93 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 1]));
                  int num94 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 2]));
                  int num95 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 3]));
                  int num96 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById19].Data[row2, 4]));
                  ttitle: String = "Air Bridge '" + letter + "' from " + num93.ToString() + "," + num94.ToString() + " to " + num95.ToString() + "," + num96.ToString();
                  ttext: String = "" + "Current Air Points: " + index3.ToString() + "\r\n" + "Start Turn Air Points: " + num9.ToString() + "\r\n" + "Next Turn Air Points: " + idValue1.ToString() + "\r\n" + "Maximum Size allowed: " + tSlotNr.ToString() + "\r\n" + "Damage suffered on use: " + num92.ToString() + "%\r\n";
                  if (num89 <= 2)
                  {
                    trect2 = new Rectangle(num91 - 35, y60 - 3, 500, 17);
                    trect1 = trect2;
                    this.AddMouse( trect1, ttitle, ttext, 4000 + num89, simpleList.Id[index12]);
                    tstring107: String = "Points: " + index3.ToString() + " / " + num9.ToString();
                    DrawMod.DrawTextColouredConsole( g, tstring107, DrawMod.TGame.se1TypeWriterMedium, num91 + 40, y60, DrawMod.TGame.seColTW);
                    int num97 = num91 + 191;
                    tstring108: String = "Next: " + idValue1.ToString();
                    DrawMod.DrawTextColouredConsole( g, tstring108, DrawMod.TGame.se1TypeWriterMedium, num97 + 40, y60, DrawMod.TGame.seColTW);
                    num75 = num97 + 105;
                    if (num9 > 0)
                    {
                      tstring109: String = "Sz: " + tSlotNr.ToString();
                      DrawMod.DrawTextColouredConsole( g, tstring109, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y60, DrawMod.TGame.seColTW);
                      num75 += 60;
                      tstring110: String = "Dm: " + num92.ToString() + "%";
                      DrawMod.DrawTextColouredConsole( g, tstring110, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y60, DrawMod.TGame.seColTW);
                    }
                    y60 += num77;
                  }
                  else
                  {
                    trect2 = new Rectangle(num91 - 35, y60 - 3, 60, 17);
                    trect1 = trect2;
                    this.AddMouse( trect1, ttitle, ttext, 4000 + num89, simpleList.Id[index12]);
                    num75 = num91 + 0;
                  }
                }
                else if (num89 >= 9 & simpleList.Counter + 1 - num89 > 0)
                {
                  tstring111: String = Conversions.ToString(Conversions.ToDouble("+") + (double) (simpleList.Counter + 1 - num89) + Conversions.ToDouble(" other"));
                  DrawMod.DrawTextColouredConsole( g, tstring111, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y60, DrawMod.TGame.seColTW);
                }
              }
            }
          }
          if (!flag5 & !flag4)
          {
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "truckPoints", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "truckPoints", 2)));
            tstring112: String = "Truck Points";
            DrawMod.DrawTextColouredConsole( g, tstring112, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y60, DrawMod.TGame.seColTW);
            tstring113: String = num12.ToString();
            if (this.game.Data.Turn != regNr)
              tstring113 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring113, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y60, DrawMod.TGame.seColTW);
            ttitle56: String = "Truck Points";
            ttext59: String = "The amount of logistical truck points this Zone had available for use at start of turn.";
            trect2 = new Rectangle(num75 + 35, y60 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle56, ttext59);
            int y70 = y60 + 30;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "truckFreeAp", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "truckFreeAp", 2)));
            tstring114: String = "Truck Range";
            DrawMod.DrawTextColouredConsole( g, tstring114, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y70, DrawMod.TGame.seColTW);
            tstring115: String = num12.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring115 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring115, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y70, DrawMod.TGame.seColTW);
            ttitle57: String = "Truck Range in AP";
            ttext60: String = "The Action Point Range this Zone had available for use at start of turn.";
            trect2 = new Rectangle(num75 + 35, y70 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle57, ttext60);
            int y71 = y70 + 30;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "maglevPoints", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "maglevPoints", 2)));
            tstring116: String = "Rail Points";
            DrawMod.DrawTextColouredConsole( g, tstring116, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y71, DrawMod.TGame.seColTW);
            tstring117: String = num12.ToString();
            if (this.game.Data.Turn != regNr)
              tstring117 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring117, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y71, DrawMod.TGame.seColTW);
            ttitle58: String = "Rail Points";
            ttext61: String = "The amount of logistical truck points this Zone had available for use at start of turn.";
            trect2 = new Rectangle(num75 + 35, y71 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle58, ttext61);
            int y72 = y71 + 30;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "maglevFreeAp", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "maglevFreeAp", 2)));
            tstring118: String = "Rail Range";
            DrawMod.DrawTextColouredConsole( g, tstring118, DrawMod.TGame.se1TypeWriterMedium, num75 + 40, y72, DrawMod.TGame.seColTW);
            tstring119: String = num12.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring119 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring119, DrawMod.TGame.se1TypeWriterMedium, num75 + 195, y72, DrawMod.TGame.seColTW);
            ttitle59: String = "Rail Range in AP";
            ttext62: String = "The Action Point Range this Zone had available for use at start of turn.";
            trect2 = new Rectangle(num75 + 35, y72 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle59, ttext62);
            num8 = y72 + 30;
            int num98 = num75 + 250;
            int y73 = 52;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "truckPoints", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "truckPoints", 2)));
            tstring120: String = "Next Turn Points";
            DrawMod.DrawTextColouredConsole( g, tstring120, DrawMod.TGame.se1TypeWriterMedium, num98 + 40, y73, DrawMod.TGame.seColTW);
            tstring121: String = index3.ToString();
            if (this.game.Data.Turn != regNr)
              tstring121 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring121, DrawMod.TGame.se1TypeWriterMedium, num98 + 195, y73, DrawMod.TGame.seColTW);
            ttitle60: String = "Next Turn Range";
            ttext63: String = "The amount of logistical truck points generated by this zone. These will be used in the next turn to provide your Logistical Network.";
            trect2 = new Rectangle(num98 + 35, y73 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle60, ttext63);
            int y74 = y73 + 30;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "truckFreeAp", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "truckFreeAp", 2)));
            tstring122: String = "Next Turn Range";
            DrawMod.DrawTextColouredConsole( g, tstring122, DrawMod.TGame.se1TypeWriterMedium, num98 + 40, y74, DrawMod.TGame.seColTW);
            tstring123: String = index3.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring123 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring123, DrawMod.TGame.se1TypeWriterMedium, num98 + 195, y74, DrawMod.TGame.seColTW);
            ttitle61: String = "Next Truck Range in AP";
            ttext64: String = "The Action Point Range that got generated for this Zone. These will be used in the next turn to provide your Logistical Network and originate from the Zone's City.";
            trect2 = new Rectangle(num98 + 35, y74 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle61, ttext64);
            int y75 = y74 + 30;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "maglevPoints", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "maglevPoints", 2)));
            tstring124: String = "Next Turn Points";
            DrawMod.DrawTextColouredConsole( g, tstring124, DrawMod.TGame.se1TypeWriterMedium, num98 + 40, y75, DrawMod.TGame.seColTW);
            tstring125: String = index3.ToString();
            if (this.game.Data.Turn != regNr)
              tstring125 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring125, DrawMod.TGame.se1TypeWriterMedium, num98 + 195, y75, DrawMod.TGame.seColTW);
            ttitle62: String = "Next Turn Range";
            ttext65: String = "The amount of logistical truck points generated by this zone. These will be used in the next turn to provide your Logistical Network.";
            trect2 = new Rectangle(num98 + 35, y75 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle62, ttext65);
            int y76 = y75 + 30;
            index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "maglevFreeAp", 2)));
            num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "maglevFreeAp", 2)));
            tstring126: String = "Next Turn Range";
            DrawMod.DrawTextColouredConsole( g, tstring126, DrawMod.TGame.se1TypeWriterMedium, num98 + 40, y76, DrawMod.TGame.seColTW);
            tstring127: String = index3.ToString() + " AP";
            if (this.game.Data.Turn != regNr)
              tstring127 = "?";
            DrawMod.DrawTextColouredConsole( g, tstring127, DrawMod.TGame.se1TypeWriterMedium, num98 + 195, y76, DrawMod.TGame.seColTW);
            ttitle63: String = "Next Truck Range in AP";
            ttext66: String = "The Action Point Range that got generated for this Zone. These will be used in the next turn to provide your Logistical Network and originate from the Zone's City.";
            trect2 = new Rectangle(num98 + 35, y76 - 10, 250, 30);
            trect1 = trect2;
            this.AddMouse( trect1, ttitle63, ttext66);
            num8 = y76 + 30;
          }
        }
        if (this.game.EditObj.se1_SelectZoneButton == 10)
        {
          int num99 = useRect.X + 0;
          int num100 = 0;
           Graphics local40 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local41 =  bitmap9;
          int x14 = num99;
          int y77 = num100;
          DrawMod.DrawSimple( local40,  local41, x14, y77);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "militancy", 2)));
          num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "militiaManpower", 2)));
          int num101 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "militiaEquipment", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "militancy", 2)));
          num10 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "militiaManpower", 2)));
          int num102 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "militiaEquipment", 2)));
          tstring128: String = "Zone Militia ";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring128, DrawMod.TGame.se1TypeWriterBig, num99 + 283, 17, DrawMod.TGame.seColTW);
          int y78 = num15;
          tstring129: String = "Militancy";
          DrawMod.DrawTextColouredConsole( g, tstring129, DrawMod.TGame.se1TypeWriterMedium, num99 + 40, y78, DrawMod.TGame.seColTW);
          int delta18 = index3 - num12;
          texty16: String = index3.ToString();
          if (num5 < 10 | flag1)
            texty16 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num99 + num14, y78, texty16, delta18);
          ttitle64: String = "Militancy Score";
          ttext67: String = "The higher the Militancy in the Zone the larger the Militia can be and the faster they'll recruit.";
          trect2 = new Rectangle(num99 + 35, y78 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle64, ttext67);
          int y79 = y78 + 30;
          tstring130: String = "Manpower";
          DrawMod.DrawTextColouredConsole( g, tstring130, DrawMod.TGame.se1TypeWriterMedium, num99 + 40, y79, DrawMod.TGame.seColTW);
          int delta19 = (num9 - num10) * 100;
          num9 *= 100;
          str35: String = num9.ToString();
          if (num9 >= 1000)
            str35 = Strings.Left(str35, str35.Length - 3) + "." + Strings.Right(str35, 3);
          if (num5 < 10)
            str35 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num99 + num14, y79, str35, delta19);
          ttitle65: String = "Manpower pool";
          ttext68: String = "Militia that are pooled at the militia HQs, but not yet assigned to militia units.";
          trect2 = new Rectangle(num99 + 35, y79 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle65, ttext68);
          int y80 = y79 + 30;
          tstring131: String = "Equipment";
          DrawMod.DrawTextColouredConsole( g, tstring131, DrawMod.TGame.se1TypeWriterMedium, num99 + 40, y80, DrawMod.TGame.seColTW);
          int delta20 = (num101 - num102) * 10;
          texty17: String = (num101 * 10).ToString();
          if (num5 < 10)
            texty17 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num99 + num14, y80, texty17, delta20);
          ttitle66: String = "Equipment pool";
          ttext69: String = "Vehicles, afv's, artillery that are pooled at militia HQs, but not yet assigned to militia units.";
          trect2 = new Rectangle(num99 + 35, y80 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle66, ttext69);
          int y81 = y80 + 30;
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "manpowerReplacements", 2)));
          int num103 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "manpowerReplacements", 2)));
          int delta21 = idValue1 - num103;
          tstring132: String = "Manp. Repl";
          DrawMod.DrawTextColouredConsole( g, tstring132, DrawMod.TGame.se1TypeWriterMedium, num99 + 40, y81, DrawMod.TGame.seColTW);
          texty18: String = idValue1.ToString();
          if (num5 < 10)
            texty18 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num99 + num14, y81, texty18, delta21);
          ttitle67: String = "Manpower Replacements Sent";
          ttext70: String = "Howmany troops of the Militia Manpower Pool were used to reinforce Militia units that suffered losses.";
          trect2 = new Rectangle(num99 + 35, y81 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle67, ttext70);
          int y82 = y81 + 30;
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "equipmentReplacements", 2)));
          int num104 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "equipmentReplacements", 2)));
          int delta22 = idValue1 - num104;
          tstring133: String = "Eqp. Repl";
          DrawMod.DrawTextColouredConsole( g, tstring133, DrawMod.TGame.se1TypeWriterMedium, num99 + 40, y82, DrawMod.TGame.seColTW);
          texty19: String = idValue1.ToString();
          if (num5 < 10)
            texty19 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num99 + num14, y82, texty19, delta22);
          ttitle68: String = "Equipment Replacements Sent";
          ttext71: String = "Howmany equipment of the Militia Equipment Pool were used to reinforce Militia units that suffered losses.";
          trect2 = new Rectangle(num99 + 35, y82 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle68, ttext71);
          num8 = y82 + 30;
          int num105 = num99 + 250;
          int y83 = num15;
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "maxMilitiaSize", 2)));
          int num106 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "maxMilitiaSize", 2)));
          idValue1 *= 2;
          int num107 = num106 * 2;
          int num108 = idValue1 - num107;
          tstring134: String = "Maximum Size:";
          int delta23 = num108 * 100;
          DrawMod.DrawTextColouredConsole( g, tstring134, DrawMod.TGame.se1TypeWriterMedium, num105 + 40, y83, DrawMod.TGame.seColTW);
          idValue1 *= 100;
          texty20: String = idValue1.ToString();
          if (num5 < 10 | flag1)
            texty20 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num105 + num14, y83, texty20, delta23);
          ttitle69: String = "Maximum Size of Militia";
          ttext72: String = "Once the Militia reaches this size do not expect it to grow anymore. Growth already tapers off once Militia size surpasses 1/2 of the Maximum Militia Pool Size.";
          trect2 = new Rectangle(num105 + 35, y83 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle69, ttext72);
          int y84 = y83 + 30;
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "currentMilitiaSize", 2)));
          num11 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "currentMilitiaSize", 2)));
          int delta24 = (idValue1 - num11) * 100;
          tstring135: String = "Current Size:";
          DrawMod.DrawTextColouredConsole( g, tstring135, DrawMod.TGame.se1TypeWriterMedium, num105 + 40, y84, DrawMod.TGame.seColTW);
          idValue1 *= 100;
          texty21: String = idValue1.ToString();
          if (num5 < 10 | flag1)
            texty21 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num105 + num14, y84, texty21, delta24);
          ttitle70: String = "Current Size of Militia";
          ttext73: String = "Howmany troops are currently at Militia HQ or attached with Militia Units in the field.";
          trect2 = new Rectangle(num105 + 35, y84 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle70, ttext73);
          int y85 = y84 + 30;
          idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "nextMilitaUnitId", 2)));
          string ttitle71;
          string ttext74;
          if (idValue1 > 0)
          {
            index3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 170, 0, 0));
            ttitle71 = "Next: ";
            ttext74 = this.game.Data.StringListObj[index3].GetData(0, idValue1, 1);
          }
          else
          {
            ttitle71 = "Next: ";
            ttext74 = "Unknown";
          }
          if (num5 < 10)
            ttext74 = "?";
          DrawMod.DrawTextColouredConsole( g, ttitle71 + ttext74, DrawMod.TGame.se1TypeWriterMedium, num105 + 40, y85, DrawMod.TGame.seColTW);
          trect2 = new Rectangle(num105 + 35, y85 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle71, ttext74);
          str1 = "Next Militia Unit";
        }
        if (this.game.EditObj.se1_SelectZoneButton == 11)
        {
          int num109 = useRect.X + 0;
          int num110 = 0;
           Graphics local42 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local43 =  bitmap9;
          int x15 = num109;
          int y86 = num110;
          DrawMod.DrawSimple( local42,  local43, x15, y86);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "unrest", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "unrest", 2)));
          tstring136: String = "Zone Unrest";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring136, DrawMod.TGame.se1TypeWriterBig, num109 + 283, 17, DrawMod.TGame.seColTW);
          int y87 = num15;
          tstring137: String = "Unrest Score";
          DrawMod.DrawTextColouredConsole( g, tstring137, DrawMod.TGame.se1TypeWriterMedium, num109 + 40, y87, DrawMod.TGame.seColTW);
          int delta = index3 - num12;
          texty: String = index3.ToString();
          if (num5 < 12)
            texty = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num109 + num14, y87, texty, delta);
          ttitle: String = "Unrest Score";
          ttext: String = "The higher the Unrest in the Zone the more negative it will impact you.";
          trect2 = new Rectangle(num109 + 35, y87 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle, ttext);
          num8 = y87 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 12)
        {
          int num111 = useRect.X + 0;
          int num112 = 0;
           Graphics local44 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local45 =  bitmap9;
          int x16 = num111;
          int y88 = num112;
          DrawMod.DrawSimple( local44,  local45, x16, y88);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "danger", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "danger", 2)));
          tstring138: String = "Zone Danger";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring138, DrawMod.TGame.se1TypeWriterBig, num111 + 283, 17, DrawMod.TGame.seColTW);
          int y89 = num15;
          tstring139: String = "Danger Score";
          DrawMod.DrawTextColouredConsole( g, tstring139, DrawMod.TGame.se1TypeWriterMedium, num111 + 40, y89, DrawMod.TGame.seColTW);
          int delta = index3 - num12;
          texty: String = index3.ToString();
          if (num5 < 12)
            texty = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num111 + num14, y89, texty, delta);
          ttitle: String = "Danger Score";
          ttext: String = "The higher the Danger in the Zone the more negative it will impact you.";
          trect2 = new Rectangle(num111 + 35, y89 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle, ttext);
          num8 = y89 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 13)
        {
          int num113 = useRect.X + 0;
          int num114 = 0;
           Graphics local46 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local47 =  bitmap9;
          int x17 = num113;
          int y90 = num114;
          DrawMod.DrawSimple( local46,  local47, x17, y90);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "fear", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "fear", 2)));
          tstring140: String = "Zone Fear";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring140, DrawMod.TGame.se1TypeWriterBig, num113 + 283, 17, DrawMod.TGame.seColTW);
          int y91 = num15;
          tstring141: String = "Fear Score";
          DrawMod.DrawTextColouredConsole( g, tstring141, DrawMod.TGame.se1TypeWriterMedium, num113 + 40, y91, DrawMod.TGame.seColTW);
          int delta = index3 - num12;
          texty: String = index3.ToString();
          if (num5 < 12)
            texty = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num113 + num14, y91, texty, delta);
          ttitle: String = "Fear Score";
          ttext: String = "The higher the Fear in the Zone the more it will impact you.";
          trect2 = new Rectangle(num113 + 35, y91 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle, ttext);
          num8 = y91 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton == 14)
        {
          int num115 = useRect.X + 0;
          int num116 = 0;
           Graphics local48 =  g;
          bitmap9 = BitmapStore.GetBitmap(this.game.SE1_ZONEPAPERFRAME1);
           Bitmap local49 =  bitmap9;
          int x18 = num115;
          int y92 = num116;
          DrawMod.DrawSimple( local48,  local49, x18, y92);
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "fear", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "fear", 2)));
          tstring142: String = "Zone Hunger";
          DrawMod.DrawTextColouredConsoleCenter( g, tstring142, DrawMod.TGame.se1TypeWriterBig, num115 + 283, 17, DrawMod.TGame.seColTW);
          int y93 = num15;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popHunger", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "popHunger", 2)));
          int delta25 = index3 - num12;
          tstring143: String = "Pop Hunger";
          DrawMod.DrawTextColouredConsole( g, tstring143, DrawMod.TGame.se1TypeWriterMedium, num115 + 40, y93, DrawMod.TGame.seColTW);
          texty22: String = index3.ToString() + " Pts";
          if (index3 < 1)
            texty22 = "None";
          if (num5 < 13)
            texty22 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num115 + num14, y93, texty22, delta25);
          ttitle72: String = "Population Hunger Score";
          ttext75: String = "Ideally there is no hunger. Between 1-100 Hunger Points it has bad effect on happiness. Above 100 starvation starts. Maximum 300 points.";
          trect2 = new Rectangle(num115 + 35, y93 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle72, ttext75);
          int y94 = y93 + 30;
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "workerHunger", 2)));
          num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "workerHunger", 2)));
          int delta26 = index3 - num12;
          tstring144: String = "Worker Hunger";
          DrawMod.DrawTextColouredConsole( g, tstring144, DrawMod.TGame.se1TypeWriterMedium, num115 + 40, y94, DrawMod.TGame.seColTW);
          texty23: String = index3.ToString() + " Pts";
          if (index3 < 1)
            texty23 = "None";
          if (flag1 | num5 < 13)
            texty23 = "?";
          this.game.CustomBitmapObj.DrawNumberWithDelta(g, num115 + num14, y94, texty23, delta26);
          ttitle73: String = "Worker Hunger Score";
          ttext76: String = "Ideally there is no hunger. Between 1-100 Hunger Points it has bad effect on happiness. Above 100 starvation starts. Maximum 300 points.";
          trect2 = new Rectangle(num115 + 35, y94 - 10, 250, 30);
          trect1 = trect2;
          this.AddMouse( trect1, ttitle73, ttext76);
          num8 = y94 + 30;
        }
        if (this.game.EditObj.se1_SelectZoneButton >= 50)
        {
          int length4 = this.game.Data.StringListObj[stringListById17].Length;
          for (int index13 = 0; index13 <= length4; index13 += 1)
          {
            if (this.game.EditObj.se1_SelectZoneButton == 50 + index13)
            {
              str36: String = this.game.Data.StringListObj[stringListById17].Data[index13, 0];
              str37: String = this.game.Data.StringListObj[stringListById17].Data[index13, 1];
              num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById17].Data[index13, 2]));
              str3 = this.game.Data.StringListObj[stringListById17].Data[index13, 3];
              idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById17].Data[index13, 4]));
              tSlotNr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById17].Data[index13, 5]));
              idValue2: String = this.game.Data.StringListObj[stringListById17].Data[index13, 6];
              str1 = "";
              int num117 = useRect.X + 0;
              num8 = 0;
              if (idValue2.Length > 0)
              {
                index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, idValue2, 2)));
                if (index3 > 0)
                {
                  tstring145: String = idValue2 + ": " + index3.ToString();
                  if (num5 < 12)
                    tstring145 = "Unknown";
                  DrawMod.DrawTextColouredConsoleCenter( g, tstring145, DrawMod.TGame.se1TypeWriterBig, num117 + 283, 17, DrawMod.TGame.seColTW);
                  int y95 = num15;
                  if (num5 >= 13)
                  {
                    int length5 = this.game.Data.StringListObj[stringListById16].Length;
                    for (int index14 = 0; index14 <= length5; index14 += 1)
                    {
                      if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById16].Data[index14, 0])) == num2 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById16].Data[index14, 1])) == integer1 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById16].Data[index14, 4])) == 0 &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById16].Data[index14, 3])) >= 9)
                      {
                        str38: String = this.game.Data.StringListObj[stringListById16].Data[index14, 5];
                        if (str38.Length > 1 & Operators.CompareString(str38.ToLower(), idValue2.ToLower(), false) == 0)
                        {
                          tstring146: String = this.game.Data.StringListObj[stringListById16].Data[index14, 2];
                          DrawMod.DrawTextColouredConsole( g, tstring146, DrawMod.TGame.se1TypeWriterSmall, num117 + 40, y95, DrawMod.TGame.seColTW);
                          y95 += 14;
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      if (num5 <= -1)
        return;
      int x19 = 588 + useRect.X;
      int y96 = 6;
      bool flag6 = true;
      string tDataString1;
      if (num5 >= 2)
      {
        index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "city", 2)));
        tDataString1 = index3 <= 0 ? "No city" : this.game.EventRelatedObj.Helper_GetString(StringSe1.CityLevel, index3) + " (" + Strings.Trim(this.game.HandyFunctionsObj.GetRomanNumerical(index3)) + ")";
      }
      else
      {
        tDataString1 = "Unknown";
        flag6 = false;
      }
      tDescript1: String = "City level is " + index3.ToString() + ".";
      this += 1.zoneButtonCounter;
      int[] zoneButton3 = this.zoneButton;
      int zoneButtonCounter3 = this.zoneButtonCounter;
      let mut tsubpart3: SubPartClass =  new SEZoneButtonPartClass(17, tDataString1, tDescript1, this.game.EditObj.se1_SelectZoneButton == 1);
      int num118 = this.AddSubPart( tsubpart3, x19, y96, 220, 40, 1);
      zoneButton3[zoneButtonCounter3] = num118;
      this.zoneButtonData[this.zoneButtonCounter] = 1;
      int y97 = y96 + 46;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2)));
      num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "pop", 2)));
      bool tshowDelta1 = true;
      int num119 = index3;
      index3 *= 100;
      num12 *= 100;
      int tdelta1 = index3 - num12;
      str39: String = index3.ToString();
      if (index3 >= 1000)
        str39 = Strings.Left(str39, str39.Length - 3) + "." + Strings.Right(str39, 3);
      if (num5 < 3)
      {
        str39 = "Unknown";
        tshowDelta1 = false;
      }
      tDescript2: String = "Population\r\nRepresents part of the populace of the zone. They are not under your direct command. (Workers + Population added up = Populace of Zone)";
      logsOfZoneForType1: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.PopChange);
      if (logsOfZoneForType1.Length > 1)
        tDescript2 = tDescript2 + "\r\nChanges:\r\n" + logsOfZoneForType1;
      this += 1.zoneButtonCounter;
      int[] zoneButton4 = this.zoneButton;
      int zoneButtonCounter4 = this.zoneButtonCounter;
      let mut tsubpart4: SubPartClass =  new SEZoneButtonPartClass(19, str39, tDescript2, this.game.EditObj.se1_SelectZoneButton == 2, tshowDelta1, tdelta1);
      int num120 = this.AddSubPart( tsubpart4, x19, y97, 220, 40, 1);
      zoneButton4[zoneButtonCounter4] = num120;
      this.zoneButtonData[this.zoneButtonCounter] = 2;
      int y98 = y97 + 46;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "worker", 2)));
      num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "worker", 2)));
      bool tshowDelta2 = true;
      int num121 = index3;
      index3 *= 100;
      num12 *= 100;
      int tdelta2 = index3 - num12;
      str40: String = index3.ToString();
      if (index3 >= 1000)
        str40 = Strings.Left(str40, str40.Length - 3) + "." + Strings.Right(str40, 3);
      if (num5 < 6 | flag1)
      {
        str40 = "Unknown";
        tshowDelta2 = false;
      }
      tDescript3: String = "Workers. You need workers to labour in your pub assets.";
      logsOfZoneForType2: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.WorkerChange);
      if (logsOfZoneForType2.Length > 1)
        tDescript3 = tDescript3 + "\r\nChanges:\r\n" + logsOfZoneForType2;
      this += 1.zoneButtonCounter;
      int[] zoneButton5 = this.zoneButton;
      int zoneButtonCounter5 = this.zoneButtonCounter;
      let mut tsubpart5: SubPartClass =  new SEZoneButtonPartClass(18, str40, tDescript3, this.game.EditObj.se1_SelectZoneButton == 3, tshowDelta2, tdelta2);
      int num122 = this.AddSubPart( tsubpart5, x19, y98, 220, 40, 1);
      zoneButton5[zoneButtonCounter5] = num122;
      this.zoneButtonData[this.zoneButtonCounter] = 3;
      int x20 = 588 + useRect.X + 220 + 6;
      int y99 = 6;
      num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "occupationMode", 2)));
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "publicBudget", 2)));
      flag6 = true;
      str41: String = "Regular";
      if (num9 == 1)
        str41 = "Unincorp.";
      string tDataString2;
      if (num5 < 8 | flag1)
      {
        tDataString2 = "Unknown";
        flag6 = false;
      }
      else
        tDataString2 = !(num3 > -1 & num3 == id) ? str41 + " Zone" : str41 + " Capital Zone";
      tDescript4: String = "The Zone Administration Mode. A Regular or Incorporated Zone is fully integrated in your Regime. An Unincorporated Zone does not impact your Regime Levels, pays much less Tax and keeps its local culture.";
      this += 1.zoneButtonCounter;
      int[] zoneButton6 = this.zoneButton;
      int zoneButtonCounter6 = this.zoneButtonCounter;
      let mut tsubpart6: SubPartClass =  new SEZoneButtonPartClass(20, tDataString2, tDescript4, this.game.EditObj.se1_SelectZoneButton == 4);
      int num123 = this.AddSubPart( tsubpart6, x20, y99, 220, 40, 1);
      zoneButton6[zoneButtonCounter6] = num123;
      this.zoneButtonData[this.zoneButtonCounter] = 4;
      int y100 = y99 + 46;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popHapiness", 2)));
      num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "popHapiness", 2)));
      bool tshowDelta3 = true;
      int tdelta3 = index3 - num12;
      tDataString3: String = this.game.EventRelatedObj.Helper_GetString(StringSe1.Hapiness, index3) + " (" + index3.ToString() + ")";
      if (num5 < 3 | num119 < 1)
      {
        tDataString3 = "Unknown";
        tshowDelta3 = false;
      }
      tDescript5: String = "Population Happiness. Keeping it high is a good idea. Low Happiness impacts willingness to cooperate with your Regime as well as the motivation be productive. Also can cause Unrest.";
      logsOfZoneForType3: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.PopHapinessChange);
      if (logsOfZoneForType3.Length > 1)
        tDescript5 = tDescript5 + "\r\nChanges:\r\n" + logsOfZoneForType3;
      this += 1.zoneButtonCounter;
      int[] zoneButton7 = this.zoneButton;
      int zoneButtonCounter7 = this.zoneButtonCounter;
      let mut tsubpart7: SubPartClass =  new SEZoneButtonPartClass(22, tDataString3, tDescript5, this.game.EditObj.se1_SelectZoneButton == 5, tshowDelta3, tdelta3);
      int num124 = this.AddSubPart( tsubpart7, x20, y100, 220, 40, 1);
      zoneButton7[zoneButtonCounter7] = num124;
      this.zoneButtonData[this.zoneButtonCounter] = 5;
      int y101 = y100 + 46;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "workerHapiness", 2)));
      num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "workerHapiness", 2)));
      bool tshowDelta4 = true;
      int tdelta4 = index3 - num12;
      tDataString4: String = this.game.EventRelatedObj.Helper_GetString(StringSe1.Hapiness, index3) + " (" + index3.ToString() + ")";
      if (num5 < 6)
      {
        tDataString4 = "Unknown";
        tshowDelta4 = false;
      }
      if (flag1)
      {
        tDataString4 = "Unknown";
        tshowDelta4 = false;
      }
      if (num121 < 1)
      {
        tDataString4 = "Unknown";
        tshowDelta4 = false;
      }
      tDescript6: String = "Worker happiness. Keeping it high is a good idea. Low Happiness impacts willingness to cooperate with your Regime as well as the motivation be productive. Also can cause Unrest.";
      logsOfZoneForType4: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.WorkerHapinessChange);
      if (logsOfZoneForType4.Length > 1)
        tDescript6 = tDescript6 + "\r\nChanges:\r\n" + logsOfZoneForType4;
      this += 1.zoneButtonCounter;
      int[] zoneButton8 = this.zoneButton;
      int zoneButtonCounter8 = this.zoneButtonCounter;
      let mut tsubpart8: SubPartClass =  new SEZoneButtonPartClass(21, tDataString4, tDescript6, this.game.EditObj.se1_SelectZoneButton == 6, tshowDelta4, tdelta4);
      int num125 = this.AddSubPart( tsubpart8, x20, y101, 220, 40, 1);
      zoneButton8[zoneButtonCounter8] = num125;
      this.zoneButtonData[this.zoneButtonCounter] = 6;
      int x21 = 588 + useRect.X + 220 + 220 + 12;
      int y102 = 6;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "culture", 2)));
      num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "culture", 2)));
      bool tshowDelta5 = true;
      int tdelta5 = index3 - num12;
      tDataString5: String = this.game.EventRelatedObj.Helper_GetString(StringSe1.Culture, index3) + " (" + index3.ToString() + ")";
      if (num5 < 7)
      {
        tDataString5 = "Unknown";
        tshowDelta5 = false;
      }
      if (num119 < 1 & num121 < 1)
      {
        tDataString5 = "Unknown";
        tshowDelta5 = false;
      }
      tDescript7: String = "The Civilisation Score of the Populace";
      this += 1.zoneButtonCounter;
      int[] zoneButton9 = this.zoneButton;
      int zoneButtonCounter9 = this.zoneButtonCounter;
      let mut tsubpart9: SubPartClass =  new SEZoneButtonPartClass(23, tDataString5, tDescript7, this.game.EditObj.se1_SelectZoneButton == 7, tshowDelta5, tdelta5);
      int num126 = this.AddSubPart( tsubpart9, x21, y102, 220, 40, 1);
      zoneButton9[zoneButtonCounter9] = num126;
      this.zoneButtonData[this.zoneButtonCounter] = 7;
      int y103 = y102 + 46;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "cas", 2)));
      num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "cas", 2)));
      num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, integer1, 9)));
      int num127 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num2, 2)));
      bool tshowDelta6 = true;
      int tdelta6 = index3 - num12;
      if (num9 == num127)
      {
        index3 = 100;
        num12 = 100;
      }
      tDataString6: String = index3.ToString();
      if (num5 < 3)
      {
        tDataString6 = "Unknown";
        tshowDelta6 = false;
      }
      if (num119 < 1)
      {
        tDataString6 = "Unknown";
        tshowDelta6 = false;
      }
      tDescript8: String = "Cultural Adaptation Score. At 100 the Culture of the Populace of the Zone is completely in accordance with your Regime's Culture. It will increase if Zone is set to 'Regular Zone' and if Population Loyalty is higher than 50. This is further modified by the Tradition Stat of the Culture Type in question.";
      this += 1.zoneButtonCounter;
      int[] zoneButton10 = this.zoneButton;
      int zoneButtonCounter10 = this.zoneButtonCounter;
      let mut tsubpart10: SubPartClass =  new SEZoneButtonPartClass(24, tDataString6, tDescript8, this.game.EditObj.se1_SelectZoneButton == 8, tshowDelta6, tdelta6);
      int num128 = this.AddSubPart( tsubpart10, x21, y103, 220, 40, 1);
      zoneButton10[zoneButtonCounter10] = num128;
      this.zoneButtonData[this.zoneButtonCounter] = 8;
      int y104 = y103 + 46;
      bool flag7 = false;
      int library1 = this.game.Data.FindLibrary("SE_Asset");
      if (library1 > -1 && this.game.Data.LibraryObj[library1].version >= 2)
      {
        flag7 = true;
        data14: DataClass = this.game.Data;
        str2 = "Zones";
         local50: String =  str2;
        libName13: String = libName1;
        tSlotNr = data14.FindLibVar( local50, libName13);
        AIMatrix aiMatrix = new AIMatrix( this.game.DC2AIObj);
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int index15 = 0; index15 <= mapWidth3; index15 += 1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index16 = 0; index16 <= mapHeight; index16 += 1)
            aiMatrix.Value[index15, index16] = this.game.Data.MapObj[0].HexObj[index15, index16].GetHexLibVarValue(tSlotNr);
        }
        index3 = 0;
        num12 = 0;
        num9 = 0;
        num10 = 0;
        idValue1 = 0;
        num11 = 0;
        tSlotNr = 0;
        data15: DataClass = this.game.Data;
        str2 = "truckPoints";
         local51: String =  str2;
        libName14: String = libName1;
        int libVar11 = data15.FindLibVar( local51, libName14);
        data16: DataClass = this.game.Data;
        str2 = "maglevPoints";
         local52: String =  str2;
        libName15: String = libName1;
        int libVar12 = data16.FindLibVar( local52, libName15);
        data17: DataClass = this.game.Data;
        str2 = "prevTruckPoints";
         local53: String =  str2;
        libName16: String = libName1;
        int libVar13 = data17.FindLibVar( local53, libName16);
        data18: DataClass = this.game.Data;
        str2 = "prevMaglevPoints";
         local54: String =  str2;
        libName17: String = libName1;
        int libVar14 = data18.FindLibVar( local54, libName17);
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int index17 = 0; index17 <= mapWidth4; index17 += 1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index18 = 0; index18 <= mapHeight; index18 += 1)
          {
            if (aiMatrix.Value[index17, index18] == integer1)
            {
              int hexLibVarValue11 = this.game.Data.MapObj[0].HexObj[index17, index18].GetHexLibVarValue(libVar11);
              if (hexLibVarValue11 > 0)
                num9 += hexLibVarValue11;
              int hexLibVarValue12 = this.game.Data.MapObj[0].HexObj[index17, index18].GetHexLibVarValue(libVar12);
              if (hexLibVarValue12 > 0)
                idValue1 += hexLibVarValue12;
              int hexLibVarValue13 = this.game.Data.MapObj[0].HexObj[index17, index18].GetHexLibVarValue(libVar13);
              if (hexLibVarValue13 > 0)
                num10 += hexLibVarValue13;
              int hexLibVarValue14 = this.game.Data.MapObj[0].HexObj[index17, index18].GetHexLibVarValue(libVar14);
              if (hexLibVarValue14 > 0)
                num11 += hexLibVarValue14;
            }
          }
        }
      }
      if (!flag7)
      {
        index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "truckPoints", 2)));
        num12 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].GetData2(0, integer1, 1, "truckPoints", 2)));
      }
      else
      {
        index3 = num9 + idValue1;
        num12 = num10 + num11;
      }
      bool tshowDelta7 = true;
      int tdelta7 = index3 - num12;
      tDataString7: String = index3.ToString();
      if (flag1)
      {
        tDataString7 = "Unknown";
        tshowDelta7 = false;
      }
      if (num119 < 1)
      {
        tDataString7 = "Unknown";
        tshowDelta7 = false;
      }
      if (num5 < 15)
      {
        tDataString7 = "Unknown";
        tshowDelta7 = false;
      }
      tDescript9: String = "Truck Points are used to transfer Items between Zones, SHQs and Units.";
      this += 1.zoneButtonCounter;
      int[] zoneButton11 = this.zoneButton;
      int zoneButtonCounter11 = this.zoneButtonCounter;
      let mut tsubpart11: SubPartClass =  new SEZoneButtonPartClass(25, tDataString7, tDescript9, this.game.EditObj.se1_SelectZoneButton == 9, tshowDelta7, tdelta7);
      int num129 = this.AddSubPart( tsubpart11, x21, y104, 220, 40, 1);
      zoneButton11[zoneButtonCounter11] = num129;
      this.zoneButtonData[this.zoneButtonCounter] = 9;
      num8 = y104 + 46;
      int x22 = 588 + useRect.X;
      int y105 = 164;
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "militancy", 2)));
      if (flag1)
        index3 = 1;
      if (index3 > 0 & num5 >= 10 & num119 > 0)
      {
        tDataString8: String = index3.ToString();
        if (flag1)
          tDataString8 = "?";
        tDescript10: String = "Militancy Level.";
        logsOfZoneForType5: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.MilitancyChange);
        if (logsOfZoneForType5.Length > 1)
          tDescript10 = tDescript10 + "\r\nChanges:\r\n" + logsOfZoneForType5;
        this += 1.zoneButtonCounter;
        int[] zoneButton12 = this.zoneButton;
        int zoneButtonCounter12 = this.zoneButtonCounter;
        let mut tsubpart12: SubPartClass =  new SEZoneButtonShortPartClass(28, -1, tDataString8, tDescript10, this.game.EditObj.se1_SelectZoneButton == 10);
        int num130 = this.AddSubPart( tsubpart12, x22, y105, 93, 40, 1);
        zoneButton12[zoneButtonCounter12] = num130;
        this.zoneButtonData[this.zoneButtonCounter] = 10;
        x22 += 97;
      }
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "unrest", 2)));
      if (index3 > 0 & num5 >= 10 & num119 > 0)
      {
        tDataString9: String = index3.ToString();
        tDescript11: String = "Unrest Level.";
        logsOfZoneForType6: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.Unrestchange);
        if (logsOfZoneForType6.Length > 1)
          tDescript11 = tDescript11 + "\r\nChanges:\r\n" + logsOfZoneForType6;
        this += 1.zoneButtonCounter;
        int[] zoneButton13 = this.zoneButton;
        int zoneButtonCounter13 = this.zoneButtonCounter;
        let mut tsubpart13: SubPartClass =  new SEZoneButtonShortPartClass(29, -1, tDataString9, tDescript11, this.game.EditObj.se1_SelectZoneButton == 11);
        int num131 = this.AddSubPart( tsubpart13, x22, y105, 93, 40, 1);
        zoneButton13[zoneButtonCounter13] = num131;
        this.zoneButtonData[this.zoneButtonCounter] = 11;
        x22 += 97;
      }
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "danger", 2)));
      if (index3 > 0 & num5 >= 10 & num119 > 0)
      {
        tDataString10: String = index3.ToString();
        tDescript12: String = "Danger Level.";
        logsOfZoneForType7: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.DangerChange);
        if (logsOfZoneForType7.Length > 1)
          tDescript12 = tDescript12 + "\r\nChanges:\r\n" + logsOfZoneForType7;
        this += 1.zoneButtonCounter;
        int[] zoneButton14 = this.zoneButton;
        int zoneButtonCounter14 = this.zoneButtonCounter;
        let mut tsubpart14: SubPartClass =  new SEZoneButtonShortPartClass(26, -1, tDataString10, tDescript12, this.game.EditObj.se1_SelectZoneButton == 12);
        int num132 = this.AddSubPart( tsubpart14, x22, y105, 93, 40, 1);
        zoneButton14[zoneButtonCounter14] = num132;
        this.zoneButtonData[this.zoneButtonCounter] = 12;
        x22 += 97;
      }
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "fear", 2)));
      if (index3 > 0 & num5 >= 10 & num119 > 0)
      {
        tDataString11: String = index3.ToString();
        tDescript13: String = "Fear Level.";
        logsOfZoneForType8: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.FearChange);
        if (logsOfZoneForType8.Length > 1)
          tDescript13 = tDescript13 + "\r\nChanges:\r\n" + logsOfZoneForType8;
        this += 1.zoneButtonCounter;
        int[] zoneButton15 = this.zoneButton;
        int zoneButtonCounter15 = this.zoneButtonCounter;
        let mut tsubpart15: SubPartClass =  new SEZoneButtonShortPartClass(27, -1, tDataString11, tDescript13, this.game.EditObj.se1_SelectZoneButton == 13);
        int num133 = this.AddSubPart( tsubpart15, x22, y105, 93, 40, 1);
        zoneButton15[zoneButtonCounter15] = num133;
        this.zoneButtonData[this.zoneButtonCounter] = 13;
        x22 += 97;
      }
      index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "popHunger", 2)));
      num9 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "workerHunger", 2)));
      int num134 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "pop", 2)));
      idValue1 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, "worker", 2)));
      if (num134 < 1)
        index3 = 0;
      if (idValue1 < 1)
        num9 = 0;
      if ((index3 > 0 | num9 > 0) & num5 >= 13)
      {
        tDataString12: String = Math.Max(index3, num9).ToString();
        tDescript14: String = "Hunger in Zone!";
        str3 = "Population Hunger score: " + index3.ToString() + "\r\nWorker Hunger score: " + num9.ToString();
        this += 1.zoneButtonCounter;
        int[] zoneButton16 = this.zoneButton;
        int zoneButtonCounter16 = this.zoneButtonCounter;
        let mut tsubpart16: SubPartClass =  new SEZoneButtonShortPartClass(37, -1, tDataString12, tDescript14, this.game.EditObj.se1_SelectZoneButton == 14);
        int num135 = this.AddSubPart( tsubpart16, x22, y105, 93, 40, 1);
        zoneButton16[zoneButtonCounter16] = num135;
        this.zoneButtonData[this.zoneButtonCounter] = 14;
        x22 += 97;
      }
      int length6 = this.game.Data.StringListObj[stringListById17].Length;
      for (int index19 = 0; index19 <= length6; index19 += 1)
      {
        str42: String = this.game.Data.StringListObj[stringListById17].Data[index19, 0];
        libname: String = this.game.Data.StringListObj[stringListById17].Data[index19, 1];
        num9 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById17].Data[index19, 2]));
        str3 = this.game.Data.StringListObj[stringListById17].Data[index19, 3];
        idValue1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById17].Data[index19, 4]));
        tSlotNr =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById17].Data[index19, 5]));
        str43: String = this.game.Data.StringListObj[stringListById17].Data[index19, 6];
        str1 = "";
        if (str43.Length > 0)
        {
          index3 = Math.Max(0, Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData2(0, integer1, 1, str43, 2)));
          if (index3 > 0 & num5 >= 10 & num119 > 0)
          {
            int tCustomIconBitmapNr = this.game.Data.EventPicNr[this.game.Data.FindEventPic("", num9, libname)];
            tDataString13: String = index3.ToString();
            tDescript15: String = str42;
            logsOfZoneForType9: String = this.game.EventRelatedObj.Helper_GetLogsOfZoneForType(num2, integer1, LogType.None, str43);
            if (logsOfZoneForType9.Length > 1)
              tDescript15 = tDescript15 + "\r\nChanges:\r\n" + logsOfZoneForType9;
            this += 1.zoneButtonCounter;
            int[] zoneButton17 = this.zoneButton;
            int zoneButtonCounter17 = this.zoneButtonCounter;
            let mut tsubpart17: SubPartClass =  new SEZoneButtonShortPartClass(-1, tCustomIconBitmapNr, tDataString13, tDescript15, this.game.EditObj.se1_SelectZoneButton == 50 + index19);
            int num136 = this.AddSubPart( tsubpart17, x22, y105, 93, 40, 1);
            zoneButton17[zoneButtonCounter17] = num136;
            this.zoneButtonData[this.zoneButtonCounter] = 50 + index19;
            x22 += 97;
          }
        }
      }
    }

    pub void SmallRightUds(Graphics g)
    {
      int num =  Math.Round((double) (this.w - 1024) / 2.0) + 1024;
      int enr =  Math.Round(Conversion.Val((object) this.game.Data.RuleVar[450]));
      int areaX = this.game.EditObj.AreaX;
      int areaY = this.game.EditObj.AreaY;
      this.game.EditObj.AreaX = this.game.SelectX;
      this.game.EditObj.AreaY = this.game.SelectY;
      this.game.EventRelatedObj.DoCheckSpecificEvent(enr, tv2: this.game.EditObj.UnitSelected);
      this.game.EditObj.AreaX = areaX;
      this.game.EditObj.AreaY = areaY;
      let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, 154, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, num - 128, 7, true);
      this.smallTabId = this.AddSubPart( tsubpart, num - 128, 7, 154, 210, 1);
    }

    pub void Old_UnitUDSBottomTab(Graphics g)
    {
      int num =  Math.Round((double) (this.w - 1024) / 2.0);
      int enr1 =  Math.Round(Conversion.Val((object) this.game.Data.RuleVar[410]));
      int areaX1 = this.game.EditObj.AreaX;
      int areaY1 = this.game.EditObj.AreaY;
      this.game.EditObj.AreaX = this.game.SelectX;
      this.game.EditObj.AreaY = this.game.SelectY;
      this.game.EventRelatedObj.DoCheckSpecificEvent(enr1, tv2: this.game.EditObj.UnitSelected);
      this.game.EditObj.AreaX = areaX1;
      this.game.EditObj.AreaY = areaY1;
      let mut tsubpart1: SubPartClass =  new UDSPartClass(this.game, 1280, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, num - 128, 7, true);
      this.extraTabId = this.AddSubPart( tsubpart1, num - 128, 7, 1280, 210, 1);
      int enr2 = -1;
      if ((double) this.game.Data.RuleVar[450] > 0.0 & this.game.ScreenWidth >= 1920)
        enr2 =  Math.Round(Conversion.Val((object) this.game.Data.RuleVar[450]));
      if (enr2 <= 0)
        return;
      int areaX2 = this.game.EditObj.AreaX;
      int areaY2 = this.game.EditObj.AreaY;
      this.game.EditObj.AreaX = this.game.SelectX;
      this.game.EditObj.AreaY = this.game.SelectY;
      this.game.EventRelatedObj.DoCheckSpecificEvent(enr2, tv2: this.game.EditObj.UnitSelected);
      this.game.EditObj.AreaX = areaX2;
      this.game.EditObj.AreaY = areaY2;
      this.game.EditObj.UDStabText = this.game.EditObj.UDStabText;
      this.game.EditObj.UDSpopupText = this.game.EditObj.UDSpopupText;
      let mut tsubpart2: SubPartClass =  new UDSPartClass(this.game, 154, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, num + 16 + 1280 - 128, 7, true);
      this.smallTabId = this.AddSubPart( tsubpart2, num + 16 + 1280 - 128, 7, 154, 210, 1);
    }

    pub void OfficerTab(Graphics g)
    {
      SizeF sizeF1 = SizeF::new();
      int x1 =  Math.Round(440.0 + (double) (this.w - 1024) / 2.0);
      int unitSelected = this.game.EditObj.UnitSelected;
      int historical = this.game.Data.UnitObj[unitSelected].Historical;
      Coordinate reconMinusHide;
      if (unitSelected > -1)
      {
        if (this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0 | !this.game.Data.FOWOn)
          reconMinusHide.x = 3;
        else
          reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unitSelected, this.game.Data.Turn);
      }
      else
        reconMinusHide.x = 3;
      if (reconMinusHide.x <= 1 || historical <= -1)
        return;
      if (this.game.Data.HistoricalUnitObj[historical].CommanderSpriteID < 0)
      {
        int staffPoints = this.game.HandyFunctionsObj.GetStaffPoints(unitSelected);
        int staffNeeded = this.game.HandyFunctionsObj.GetStaffNeeded(unitSelected);
        DrawMod.DrawBlockGradient2( g, x1 + 5, 190, 79, 20, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, x1 + 5, 191, 80, 19, -1, -1);
        str: String = Strings.Trim(Conversion.Str((object) Math.Round((double) staffPoints / (double) staffNeeded, 2)));
        DrawMod.DrawTextColouredMarc( g, "S:T = " + str, this.game.MarcFont5, x1 + 10, 195, Color.White);
        Rectangle trect = new Rectangle(x1 + 10, 191, 80, 20);
        this.AddMouse( trect, "STAFF : TROOPS RATIO", "If above 1 there is a full staff complement.\r\nIf below 1 there is not enough staff\r\nto command all troops. see details tab.");
      }
      else
      {
        int staffPoints = this.game.HandyFunctionsObj.GetStaffPoints(unitSelected);
        int num1 = this.game.HandyFunctionsObj.GetStaffNeeded(unitSelected);
        if (num1 == 0)
          num1 = 1;
        int num2;
        if ( Math.Round(40.0 * ((double) staffPoints / (double) num1)) > 80)
          num2 = 80;
        if ( Math.Round(40.0 * ((double) this.game.Data.HistoricalUnitObj[historical].StaffSize / (double) num1)) > 80)
          num2 = 80;
        int Number1;
        if (this.game.Data.UnitObj[unitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[historical].StaffSize > 0)
          Number1 = !(this.game.Data.HistoricalUnitObj[historical].Type < 6 | (double) this.game.Data.RuleVar[927] == 0.0) ? 0 : (num1 <= this.game.Data.HistoricalUnitObj[historical].StaffSize ? this.game.Data.HistoricalUnitObj[historical].CombatMod :  Math.Round((double) this.game.Data.HistoricalUnitObj[historical].CombatMod * Math.Min(1.0, (double) this.game.Data.HistoricalUnitObj[historical].StaffSize / (double) num1)));
        int num3;
        int num4;
        if (this.game.Data.UnitObj[unitSelected].SFCount > -1)
        {
          int sfCount = this.game.Data.UnitObj[unitSelected].SFCount;
          for (int index = 0; index <= sfCount; index += 1)
          {
            num3 += this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[unitSelected].SFList[index]].Type].StaffPts * this.game.Data.SFObj[this.game.Data.UnitObj[unitSelected].SFList[index]].Qty;
            num4 =  Math.Round((double) num4 + (double) (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[unitSelected].SFList[index]].Type].StaffPts * this.game.Data.SFObj[this.game.Data.UnitObj[unitSelected].SFList[index]].Qty) * ((double) this.game.Data.SFObj[this.game.Data.UnitObj[unitSelected].SFList[index]].Xp / 100.0) * (double) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[unitSelected].SFList[index]].Type].StaffCombatMod * Math.Min(1.0, (double) staffPoints / (double) num1));
          }
        }
        int num5 = num3 <= 0 ? 0 :  Math.Round(100.0 * ((double) num4 / (double) num3));
        int num6 =  Math.Round((double) num5 * ((double) (100 + Number1) / 100.0));
        int num7 = num5 +  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1));
        int num8 =  Math.Round((double) this.game.HandyFunctionsObj.GetStaffCombatMod(unitSelected));
        int Number2 = num6 +  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1));
        if (Number2 > 0)
          DrawMod.DrawTextColouredMarc( g, "+" + Strings.Trim(Conversion.Str((object) Number2)) + "%", this.game.MarcFont12, x1 + 5, 103, Color.White);
        else
          DrawMod.DrawTextColouredMarc( g, Strings.Trim(Conversion.Str((object) Number2)) + "%", this.game.MarcFont12, x1 + 5, 103, Color.White);
        int Number3 = num7 -  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1));
        int Number4 =  Math.Round((double) (100 + Number1) / 100.0 * (double) (num7 -  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1))));
        Rectangle rectangle;
        if ((double) this.game.Data.RuleVar[976] < 1.0)
        {
          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitSelected].Historical].Type < 6 | (double) this.game.Data.RuleVar[927] == 0.0)
          {
            rectangle = new Rectangle(x1 + 5, 103, 80, 30);
            Rectangle trect = rectangle;
            this.AddMouse( trect, "", "Total combat bonus for units\r\nunder direct command of this officer.\r\nBase bonus for full staff complement: " + Strings.Trim(Conversion.Str((object)  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1)))) + "%.\r\nStaff bonus (based on staff XP) is: " + Strings.Trim(Conversion.Str((object) Number3)) + "%. \r\nStaff bonus is increased with " + Strings.Trim(Conversion.Str((object) Number1)) + "% for officer skill.\r\nResulting in a modified staff bonus of " + Strings.Trim(Conversion.Str((object) Number4)) + "%.\r\nBase bonus and modified staff bonus are added up. \r\nAnd results in " + Strings.Trim(Conversion.Str((object) Number2)) + "% total bonus.");
          }
          else
          {
            rectangle = new Rectangle(x1 + 5, 103, 80, 30);
            Rectangle trect = rectangle;
            this.AddMouse( trect, "", "Total combat bonus for units\r\nunder direct command of this HQ.\r\nKeep in mind that officers in HQs above the lowest level do not give any combat bonus.\r\nBase bonus for full staff complement: " + Strings.Trim(Conversion.Str((object)  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1)))) + "%.\r\nStaff bonus (based on staff XP) is: " + Strings.Trim(Conversion.Str((object) Number3)) + "%. \r\nBase bonus and staff bonus are added up. \r\nAnd results in " + Strings.Trim(Conversion.Str((object) Number2)) + "% total bonus.");
          }
        }
        else
        {
          rectangle = new Rectangle(x1 + 5, 103, 80, 30);
          Rectangle trect = rectangle;
          this.AddMouse( trect, "", "Total combat bonus for units\r\nunder direct command of this officer.\r\nBase bonus for full staff complement: " + Strings.Trim(Conversion.Str((object)  Math.Round(100.0 * (double) this.game.Data.RuleVar[140] * Math.Min(1.0, (double) staffPoints / (double) num1)))) + "%.\r\nStaff bonus (based on staff XP) is: " + Strings.Trim(Conversion.Str((object) Number3)) + "%. \r\nBase bonus and modified staff bonus are added up. \r\nAnd results in " + Strings.Trim(Conversion.Str((object) Number2)) + "% total bonus.");
        }
        if ((double) this.game.Data.RuleVar[976] < 1.0)
        {
          DrawMod.DrawBlockGradient2( g, x1 + 5, 140, 79, 20, this.game.MarcCol1, this.game.MarcCol2);
          DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, x1 + 5, 141, 80, 19, -1, -1);
          str1: String = this.game.Data.HistoricalUnitObj[historical].PP.ToString();
          DrawMod.DrawTextColouredMarc( g, "POL = " + str1, this.game.MarcFont5, x1 + 10, 145, Color.White);
          rectangle = new Rectangle(x1 + 10, 141, 80, 20);
          Rectangle trect1 = rectangle;
          this.AddMouse( trect1, "POLITICAL VALUE", "A negative political value is the cost in PP to replace this officer.\r\nA positive political value is the cost to appoint the officer.");
          DrawMod.DrawBlockGradient2( g, x1 + 5, 165, 79, 20, this.game.MarcCol1, this.game.MarcCol2);
          DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, x1 + 5, 166, 80, 19, -1, -1);
          str2: String = Strings.Trim(Conversion.Str((object) Math.Round((double) this.game.Data.HistoricalUnitObj[historical].StaffSize / (double) staffPoints, 2)));
          DrawMod.DrawTextColouredMarc( g, "O:S = " + str2, this.game.MarcFont5, x1 + 10, 170, Color.White);
          rectangle = new Rectangle(x1 + 10, 166, 80, 20);
          Rectangle trect2 = rectangle;
          this.AddMouse( trect2, "OFFICER : STAFF RATIO", "If above 1 the officer can command more staff without penalty.\r\nIf below 1 the officer has to much staff for his ability.\r\nMaximum staff points officer can command = " + Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[historical].StaffSize)) + ".\r\nCurrent staff points under command = " + Strings.Trim(Conversion.Str((object) staffPoints)));
        }
        DrawMod.DrawBlockGradient2( g, x1 + 5, 190, 79, 20, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, x1 + 5, 191, 80, 19, -1, -1);
        str3: String = Strings.Trim(Conversion.Str((object) Math.Round((double) staffPoints / (double) num1, 2)));
        DrawMod.DrawTextColouredMarc( g, "S:T = " + str3, this.game.MarcFont5, x1 + 10, 195, Color.White);
        rectangle = new Rectangle(x1 + 10, 191, 80, 20);
        Rectangle trect3 = rectangle;
        this.AddMouse( trect3, "STAFF : TROOPS RATIO", "If above 1.0 ratio the minimum staff complement is present.\r\nIf below 1.0 there is not enough staff to command all troops. see details tab.");
        DrawMod.DrawOfficer(g, historical, x1, 5, 95, 105);
        rectangle = new Rectangle(x1, 5, 95, 105);
        Rectangle trect4 = rectangle;
        this.AddMouse( trect4, "OFFICER PORTRAIT", "Click to get full stats and biography", 50);
        bool flag1 = false;
        int hisVarCount = this.game.Data.HistoricalUnitObj[historical].HisVarCount;
        for (int index = 0; index <= hisVarCount; index += 1)
        {
          if (this.game.Data.HistoricalUnitObj[historical].HisVarCount >= index && this.game.Data.HistoricalUnitObj[historical].HisVarNato[index] <= 0 | this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index] > -1)
          {
            bool flag2 = true;
            if (this.game.Data.HistoricalUnitObj[historical].HisVarType[index] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[historical].HisVarType[index]], "1", false) == 0)
              flag2 = false;
            if (this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index] > -1 && Strings.InStr(this.game.Data.SmallPicName[this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index]], "trans.") > 0)
              flag2 = false;
            if (flag2)
              flag1 = true;
          }
        }
        if ((uint) (-(this.game.Data.Product < 4 ? 1 : 0) & this.game.HandyFunctionsObj.GetVisibleHisVar(historical)) > 0U)
          flag1 = true;
        Bitmap bitmap1;
        if ((double) this.game.Data.RuleVar[879] < 1.0 | this.game.HandyFunctionsObj.GetVisibleHisVar(historical) < 1 | !flag1)
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 5, this.game.MarcFont13, "\r\n\r\n" + this.game.Data.HistoricalUnitObj[historical].Descript, 12,  this.BackBitmap, x1 + 110, -7, true);
           Graphics local1 =  g;
          Bitmap bitmap2 = textAreaClass2.Paint();
           Bitmap local2 =  bitmap2;
          int x2 = x1 + 110;
          DrawMod.DrawSimple( local1,  local2, x2, -7);
          rectangle = new Rectangle(x1 + 105, 5, 280, 100);
          Rectangle trect5 = rectangle;
          this.AddMouse( trect5, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc( g, this.game.Data.HistoricalUnitObj[historical].CommanderName, this.game.MarcFont6, x1 + 125, 15, Color.White);
        }
        else
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 5, this.game.MarcFont13, "", 12,  this.BackBitmap, x1 + 110, -7, true);
           Graphics local3 =  g;
          Bitmap bitmap3 = textAreaClass2.Paint();
           Bitmap local4 =  bitmap3;
          int x3 = x1 + 110;
          DrawMod.DrawSimple( local3,  local4, x3, -7);
          rectangle = new Rectangle(x1 + 105, 5, 280, 45);
          Rectangle trect6 = rectangle;
          this.AddMouse( trect6, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc( g, this.game.Data.HistoricalUnitObj[historical].CommanderName, this.game.MarcFont6, x1 + 125, 15, Color.White);
          int num9 = 110;
          int num10 = 0;
          while (num9 < 425)
          {
            int index;
            if (this.game.Data.HistoricalUnitObj[historical].HisVarCount >= index)
            {
              bool flag3 = true;
              if (this.game.Data.HistoricalUnitObj[historical].HisVarType[index] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[historical].HisVarType[index]], "1", false) == 0)
                flag3 = false;
              if (this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index] > -1 && Strings.InStr(this.game.Data.SmallPicName[this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index]], "trans.") > 0)
                flag3 = false;
              if (flag3 & (this.game.Data.HistoricalUnitObj[historical].HisVarNato[index] > 0 | this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index] > -1))
              {
                DrawMod.DrawBlockGradient2( g, x1 + num9 + 35, 51, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
                str4: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[historical].HisVarValue[index]));
                SizeF sizeF2 = g.MeasureString(str4, this.game.MarcFont8b);
                int x4 =  Math.Round((double) ((float) (x1 + num9 + 18) - sizeF2.Width / 2f));
                DrawMod.DrawTextColouredMarc( g, str4, this.game.MarcFont8b, x4, 73, Color.White);
                if (this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index] > -1)
                {
                   Graphics local5 =  g;
                  bitmap1 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[historical].HisVarSmall[index]]);
                   Bitmap local6 =  bitmap1;
                  int x5 = x4;
                  DrawMod.DrawSimple( local5,  local6, x5, 54);
                }
                else if (this.game.Data.HistoricalUnitObj[historical].HisVarNato[index] < this.game.NATO.GetUpperBound(0))
                {
                   Graphics local7 =  g;
                  bitmap1 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[historical].HisVarNato[index]]);
                   Bitmap local8 =  bitmap1;
                  int x6 = x4;
                  DrawMod.DrawSimple( local7,  local8, x6, 54);
                }
                if (this.game.Data.Turn == this.game.Data.UnitObj[unitSelected].Regime)
                {
                  rectangle = new Rectangle(x4, 54, 35, 50);
                  Rectangle trect7 = rectangle;
                  this.AddMouse( trect7, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[historical].HisVarType[index]]);
                }
                num9 += 35;
                num10 += 1;
              }
            }
            else
              num9 = 425;
            index += 1;
          }
          int num11 = 110;
          DrawMod.DrawBlock( g, x1 + num11, 50, Math.Min(315, num10 * 35) + 2, 2,  this.game.MarcCol3.R,  this.game.MarcCol3.G,  this.game.MarcCol3.B,  byte.MaxValue);
        }
        int num12 = 0;
        if (!this.game.Data.FOWOn)
          num12 = 1;
        if (unitSelected > -1)
        {
          if (this.game.Data.Turn == this.game.Data.UnitObj[unitSelected].Regime)
            num12 = 1;
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[unitSelected].Regime))
            num12 = 1;
        }
        if (unitSelected == -1)
          num12 = 1;
        if (this.game.Data.Round == 0)
          num12 = 1;
        if (num12 != 1)
          return;
        num2 = 0;
        int num13 = Math.Min(15, this.game.Data.HistoricalUnitObj[historical].HandCardCounter);
        int num14 = num13;
        int x7;
        int y1;
        for (int index = 0; index <= num14; index += 1)
        {
          if (index <= 7)
          {
            x7 = index * 37 + x1 + 110;
            y1 = 110;
          }
          if (index > 7 & num13 <= 15)
          {
            x7 = (index - 8) * 37 + x1 + 110;
            y1 = 160;
          }
          if (this.cardsel == 5000 + index | this.cardsel == -1 & (this.cardhover == 7000 + index | this.cardhover == 5000 + index))
          {
             Graphics local9 =  g;
            bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[unitSelected].Regime, this.game.Data.HistoricalUnitObj[historical].HandCard[index], size: 3);
             Bitmap local10 =  bitmap1;
            int x8 = x7;
            int y2 = y1;
            DrawMod.Draw( local9,  local10, x8, y2, 0.2f, 0.2f, 0.2f, 1f);
          }
          else
          {
             Graphics local11 =  g;
            bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[unitSelected].Regime, this.game.Data.HistoricalUnitObj[historical].HandCard[index], size: 3);
             Bitmap local12 =  bitmap1;
            int x9 = x7;
            int y3 = y1;
            DrawMod.DrawSimple( local11,  local12, x9, y3);
          }
          rectangle = new Rectangle(x7, y1, 33, 46);
          Rectangle trect8 = rectangle;
          this.AddMouse( trect8, "HAND CARD", this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[historical].HandCard[index]].Title + "\r\nClick it to select it.", 5000 + index);
        }
        int deckCardCounter = this.game.Data.HistoricalUnitObj[historical].DeckCardCounter;
        for (int index1 = 0; index1 <= deckCardCounter; index1 += 1)
        {
          int num15 = 0;
          int handCardCounter = this.game.Data.HistoricalUnitObj[historical].HandCardCounter;
          for (int index2 = 0; index2 <= handCardCounter; index2 += 1)
          {
            if (this.game.Data.HistoricalUnitObj[historical].DeckCard[index1] == this.game.Data.HistoricalUnitObj[historical].HandCard[index2])
              num15 = 1;
          }
          if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[historical].DeckCard[index1]].LimitedShow == 1 && this.game.Data.HistoricalUnitObj[historical].Type > 5)
            num15 = 1;
          if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[historical].DeckCard[index1]].LimitedShow == 2 && this.game.Data.HistoricalUnitObj[historical].Type < 6)
            num15 = 1;
          if (num15 == 0)
          {
            num13 += 1;
            if (num13 <= 15)
            {
              if (num13 <= 7)
              {
                x7 = num13 * 37 + x1 + 110;
                y1 = 110;
              }
              if (num13 > 7 & num13 <= 15)
              {
                x7 = (num13 - 8) * 37 + x1 + 110;
                y1 = 160;
              }
              if (this.cardsel == 7000 + index1 | this.cardsel == -1 & (this.cardhover == 7000 + index1 | this.cardhover == 5000 + index1))
              {
                 Graphics local13 =  g;
                bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[unitSelected].Regime, this.game.Data.HistoricalUnitObj[historical].DeckCard[index1], size: 3, Shaded: true, Percent: this.game.Data.HistoricalUnitObj[historical].DeckChance[index1]);
                 Bitmap local14 =  bitmap1;
                int x10 = x7;
                int y4 = y1;
                DrawMod.Draw( local13,  local14, x10, y4, 0.2f, 0.2f, 0.2f, 1f);
              }
              else
              {
                 Graphics local15 =  g;
                bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[unitSelected].Regime, this.game.Data.HistoricalUnitObj[historical].DeckCard[index1], size: 3, Shaded: true, Percent: this.game.Data.HistoricalUnitObj[historical].DeckChance[index1]);
                 Bitmap local16 =  bitmap1;
                int x11 = x7;
                int y5 = y1;
                DrawMod.DrawSimple( local15,  local16, x11, y5);
              }
              rectangle = new Rectangle(x7, y1, 33, 46);
              Rectangle trect9 = rectangle;
              this.AddMouse( trect9, "DECK CARD", this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[historical].DeckCard[index1]].Title + "\r\n" + Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[historical].DeckChance[index1])) + "% chance to get it as handcard.", 7000 + index1);
            }
          }
        }
        if (this.cardsel >= 5000)
        {
          int num16 = x1 + 397 + 60;
          int y6 = 10;
          int nr;
          bool Shaded;
          if (this.cardsel < 7000)
          {
            if (this.cardsel - 5000 > this.game.Data.HistoricalUnitObj[historical].HandCardCounter)
              this.cardsel = this.game.Data.HistoricalUnitObj[historical].HandCardCounter + 5000;
            if (this.cardsel >= 5000)
            {
              nr = this.game.Data.HistoricalUnitObj[historical].HandCard[this.cardsel - 5000];
              if (!Information.IsNothing((object) this.game.Data.ActionCardObj[nr].MouseOver))
              {
                if (this.game.Data.ActionCardObj[nr].MouseOver.Length > 0)
                {
                  rectangle = new Rectangle(num16, y6, 105, 147);
                  Rectangle trect10 = rectangle;
                  this.AddMouse( trect10, "HAND CARD", this.game.Data.ActionCardObj[nr].MouseOver + "\r\nClick to zoom into card", this.cardsel + 4000);
                }
                else
                {
                  rectangle = new Rectangle(num16, y6, 105, 147);
                  Rectangle trect11 = rectangle;
                  this.AddMouse( trect11, "HAND CARD", "Click to zoom into card", this.cardsel + 4000);
                }
              }
              Shaded = false;
            }
          }
          else
          {
            nr = this.game.Data.HistoricalUnitObj[historical].DeckCard[this.cardsel - 7000];
            rectangle = new Rectangle(num16, y6, 105, 147);
            Rectangle trect12 = rectangle;
            this.AddMouse( trect12, "DECK CARD", "This is a deck card. You cannot play it.");
            Shaded = true;
          }
           Graphics local17 =  g;
          bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[unitSelected].Regime, nr, size: 2, Shaded: Shaded);
           Bitmap local18 =  bitmap1;
          int x12 = num16;
          int y7 = y6;
          DrawMod.DrawSimple( local17,  local18, x12, y7);
          if (!Shaded)
          {
            if ((this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[nr].PPCost | this.game.Data.ActionCardObj[nr].PPCost == 0) & (this.game.Data.ActionCardObj[nr].HisVarCostType == -1 | this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.game.Data.ActionCardObj[nr].HisVarCostType) >= this.game.Data.ActionCardObj[nr].HisVarCostQty))
            {
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("VIEW CARD", 105, "Click to play this actioncard",  this.OwnBitmap, num16, y6 + 152, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.playcardid = this.AddSubPart( tsubpart, num16, y6 + 152, 105, 40, 1);
            }
            else
            {
              tDescript: String = "You cannot play this card yet.";
              if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts < this.game.Data.ActionCardObj[nr].PPCost)
                tDescript += "\r\nYou do not have the PP to play card.";
              if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(this.game.Data.ActionCardObj[nr].HisVarCostType) < this.game.Data.ActionCardObj[nr].HisVarCostQty)
                tDescript += "\r\nThe commander is missing points to play card.";
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("VIEW CARD", 105, tDescript,  this.OwnBitmap, num16, y6 + 152, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.fakeid = this.AddSubPart( tsubpart, num16, y6 + 152, 105, 40, 1);
            }
          }
          else
          {
            let mut tsubpart: SubPartClass =  new TextButtonPartClass("VIEW CARD", 105, tBackbitmap: ( this.OwnBitmap), bbx: num16, bby: (y6 + 152), tinactive: true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.playcard2id = this.AddSubPart( tsubpart, num16, y6 + 152, 105, 40, 1);
            rectangle = new Rectangle(num16, y6 + 152, 105, 40);
            Rectangle trect13 = rectangle;
            this.AddMouse( trect13, "", "This is a deck card. You cannot play it.");
          }
        }
        else
        {
          if (this.cardhover < 5000)
            return;
          int x13 = x1 + 397 + 60;
          int y8 = 10;
          int nr;
          bool Shaded;
          if (this.cardhover < 7000)
          {
            if (this.cardhover - 5000 > this.game.Data.HistoricalUnitObj[historical].HandCardCounter)
              this.cardhover = this.game.Data.HistoricalUnitObj[historical].HandCardCounter + 5000;
            if (this.cardhover >= 5000)
            {
              nr = this.game.Data.HistoricalUnitObj[historical].HandCard[this.cardhover - 5000];
              if (!Information.IsNothing((object) this.game.Data.ActionCardObj[nr].MouseOver))
              {
                if (this.game.Data.ActionCardObj[nr].MouseOver.Length > 0)
                {
                  rectangle = new Rectangle(x13, y8, 105, 147);
                  Rectangle trect14 = rectangle;
                  this.AddMouse( trect14, "DECK CARD", this.game.Data.ActionCardObj[nr].MouseOver);
                }
                else
                {
                  rectangle = new Rectangle(x13, y8, 105, 147);
                  Rectangle trect15 = rectangle;
                  this.AddMouse( trect15, "DECK CARD", "");
                }
              }
              Shaded = false;
            }
          }
          else
          {
            nr = this.game.Data.HistoricalUnitObj[historical].DeckCard[this.cardhover - 7000];
            rectangle = new Rectangle(x13, y8, 105, 147);
            Rectangle trect16 = rectangle;
            this.AddMouse( trect16, "DECK CARD", "This is a deck card. You cannot play it.");
            Shaded = true;
          }
           Graphics local19 =  g;
          bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[unitSelected].Regime, nr, size: 2, Shaded: Shaded);
           Bitmap local20 =  bitmap1;
          int x14 = x13;
          int y9 = y8;
          DrawMod.DrawSimple( local19,  local20, x14, y9);
        }
      }
    }

    pub void CombatTab(Graphics g)
    {
      SizeF sizeF = SizeF::new();
      int num1 =  Math.Round(580.0 + (double) (this.w - 1024) / 2.0);
      int num2 = 0;
      DrawMod.DrawTextColouredMarc( g, "TARGET", this.game.MarcFont4, num1 - 90, 35, Color.White);
      DrawMod.DrawTextColouredMarc( g, "HEX", this.game.MarcFont4, num1 - 80, 55, Color.White);
      DrawMod.DrawTextColouredMarc( g, "ATTACKING", this.game.MarcFont4, num1 - 105, 140, Color.White);
      DrawMod.DrawTextColouredMarc( g, "UNITS", this.game.MarcFont4, num1 - 85, 160, Color.White);
      int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].LandscapeType;
      int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].SpriteNr;
      int num3 = -1;
      int unitCounter1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitCounter;
      for (int index = 0; index <= unitCounter1; index += 1)
      {
        if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitList[index], this.game.Data.Turn) > 0)
          num3 += 1;
      }
      int num4;
      int num5;
      Rectangle trect1;
      Rectangle trect2;
      if (landscapeType > -1 & spriteNr > -1 & num3 > -1)
      {
        num4 = this.game.Data.LandscapeTypeObj[landscapeType].BasicPicID[spriteNr];
        DrawMod.DrawLeather(g, num1 + 20, 5, 410, 110);
        DrawMod.DrawBlockGradient2( g, num1 + 20, 5, 399, 99, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 20, 5, 400, 100, -1, -1);
        num5 = num3;
        int num6 = -1;
        int unitCounter2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitCounter;
        for (int index = 0; index <= unitCounter2; index += 1)
        {
          int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitList[index];
          if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn) > 0)
          {
            num6 += 1;
            int num7;
            int num8;
            if (num6 <= 7)
            {
              num7 = num1 + 30 + num6 * 48;
              num8 = 10;
            }
            else
            {
              num7 = num1 + 30 + (num6 - 8) * 48;
              num8 = 55;
            }
            bool forcehighlight = false;
            if (this.game.EditObj.UnitSelected == unit)
              forcehighlight = true;
            this.game.CustomBitmapObj.DrawUnit(unit, forcehighlight, g, num7, num8, true);
            if (this.game.EditObj.UnitSelected == unit)
            {
              trect1 = new Rectangle(num7, num8, 37, 37);
              trect2 = trect1;
              this.AddMouse( trect2, "TARGET UNIT", "You are currently viewing this unit.", 0);
            }
            else
            {
              trect2 = new Rectangle(num7, num8, 37, 37);
              trect1 = trect2;
              this.AddMouse( trect1, "TARGET UNIT", "Click for details.", 10000 + unit);
            }
          }
        }
      }
      else
      {
        num4 = this.game.Data.LandscapeTypeObj[landscapeType].BasicPicID[spriteNr];
        DrawMod.DrawLeather(g, num1 + 20, 5, 410, 110);
        DrawMod.DrawBlockGradient2( g, num1 + 20, 5, 399, 99, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 20, 5, 400, 100, -1, -1);
      }
      int num9 =  Math.Round(580.0 + (double) (this.w - 1024) / 2.0);
      num2 = 0;
      int num10 = -1;
      int counter1 = this.game.EditObj.TempUnitList.counter;
      for (int index = 0; index <= counter1; index += 1)
      {
        int num11 = this.game.EditObj.TempUnitList.unr[index];
        num10 += 1;
      }
      DrawMod.DrawLeather(g, num9 + 20, 110, 410, 110);
      DrawMod.DrawBlockGradient2( g, num9 + 20, 110, 399, 99, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num9 + 20, 110, 400, 100, -1, -1);
      if (num10 <= -1)
        return;
      num5 = num10;
      int num12 = -1;
      int counter2 = this.game.EditObj.TempUnitList.counter;
      for (int index = 0; index <= counter2; index += 1)
      {
        int nr = this.game.EditObj.TempUnitList.unr[index];
        num12 += 1;
        int num13;
        int num14;
        if (num12 <= 7)
        {
          num13 = num9 + 30 + num12 * 48;
          num14 = 115;
        }
        else
        {
          num13 = num9 + 30 + (num12 - 8) * 48;
          num14 = 160;
        }
        bool forcehighlight = false;
        if (this.game.EditObj.UnitSelected == nr)
          forcehighlight = true;
        this.game.CustomBitmapObj.DrawUnit(nr, forcehighlight, g, num13, num14, true);
        if (this.game.EditObj.UnitSelected == nr)
        {
          trect2 = new Rectangle(num13, num14, 37, 37);
          trect1 = trect2;
          this.AddMouse( trect1, "ATTACKING UNIT", "You are currently viewing this unit.", 0);
        }
        else
        {
          trect2 = new Rectangle(num13, num14, 37, 37);
          trect1 = trect2;
          this.AddMouse( trect1, "ATTACKING UNIT", "Click for details.", 10000 + nr);
        }
      }
    }

    pub Coordinate TroopTab(Graphics g, Rectangle useRect, int PageNr)
    {
      SizeF sizeF1 = SizeF::new();
      int val2 = 0;
      int unitSelected = this.game.EditObj.UnitSelected;
      if (unitSelected == -1)
      {
        Coordinate coordinate;
        return coordinate;
      }
      Coordinate reconMinusHide;
      if (this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn | !this.game.Data.FOWOn | this.game.Data.Round == 0)
        reconMinusHide.x = 3;
      else
        reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unitSelected, this.game.Data.Turn);
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 370, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitSelected].X, this.game.Data.UnitObj[unitSelected].Y].LandscapeType;
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 387, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 402, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 309, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 311, 0, 0));
      int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      int num1 = this.game.Data.StringListObj[stringListById3].Length + 1;
      data1: DataClass = DrawMod.TGame.Data;
      str1: String = "Zones";
       local1: String =  str1;
      int libVar = data1.FindLibVar( local1, "SE_Data");
      int num2 = 0;
      int hexLibVarValue = DrawMod.TGame.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitSelected].X, this.game.Data.UnitObj[unitSelected].Y].GetHexLibVarValue(libVar);
      if (hexLibVarValue > 0)
        num2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, hexLibVarValue, 13)));
      int num3 =  Math.Round((double) num2 / (double) num1);
      int eventPicOrigSlot1;
      int eventPicOrigSlot2;
      if (stringListById1 > -1)
      {
        eventPicOrigSlot1 = num3 >= 50 ? (num3 >= 500 ?  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 3))) :  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 2)))) :  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 1)));
        eventPicOrigSlot2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, landscapeType, 6)));
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitSelected].X, this.game.Data.UnitObj[unitSelected].Y].MaxRecon < 1 & this.game.Data.FOWOn)
        eventPicOrigSlot2 = 61;
      int eventPic1 = this.game.Data.FindEventPic(eventPicOrigSlot1, "SE_Present");
      int eventPic2 = this.game.Data.FindEventPic(eventPicOrigSlot2, "SE_Present");
      if (eventPic1 > -1)
        eventPic1 = this.game.Data.EventPicNr[eventPic1];
      if (eventPic2 > -1)
        eventPic2 = this.game.Data.EventPicNr[eventPic2];
      this.viewingtrooptab = true;
      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.PixelOffsetMode = PixelOffsetMode.HighQuality;
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;
      if (reconMinusHide.x >= 2)
      {
        int historical = this.game.Data.UnitObj[unitSelected].Historical;
        SimpleList simpleList1 = SimpleList::new();
        int num4;
        if (historical > -1)
        {
          int hisVarCount = this.game.Data.HistoricalUnitObj[historical].HisVarCount;
          for (int index = 0; index <= hisVarCount; index += 1)
          {
            if (this.game.Data.HistoricalUnitObj[historical].HisVarType[index] > 100 & this.game.Data.HistoricalUnitObj[historical].HisVarType[index] <= 999999 && this.game.Data.HistoricalUnitObj[historical].HisVarValue[index] > 0)
            {
              simpleList1.Add(this.game.Data.HistoricalUnitObj[historical].HisVarType[index] - 100, this.game.Data.HistoricalUnitObj[historical].HisVarValue[index]);
              num4 += 1;
            }
          }
        }
        int lessSubs = num4;
        if (this.game.Data.UnitObj[unitSelected].PassengerCounter > -1)
          lessSubs = Math.Max(1, lessSubs - (this.game.Data.UnitObj[unitSelected].PassengerCounter + 1));
        if (lessSubs < 3 & simpleList1.Counter >= 2)
          lessSubs = 3;
        if (lessSubs < 2 & simpleList1.Counter >= 1)
          lessSubs = 2;
        if (lessSubs < 1 & simpleList1.Counter >= 0)
          lessSubs = 1;
        SimpleList simpleList2 = (SimpleList) this.game.HandyFunctionsObj.Get8Subformations(unitSelected, lessSubs, true);
        int num5 =  Math.Round(Math.Floor((double) useRect.Width / 156.0));
        val2 =  Math.Round(Math.Ceiling((double) (simpleList2.Counter + 1 + num4 + 1 + this.game.Data.UnitObj[unitSelected].PassengerCounter) / (double) (num5 * 2)));
        if (PageNr > val2)
          PageNr = Math.Min(1, val2);
        int num6 = (PageNr - 1) * (num5 * 2);
        int num7 = num6 + num5 * 2 - 1;
        int x1 = useRect.X;
        int num8 = 3;
        int num9 = simpleList2.Counter - 1;
        for (int index = 1; index <= num9; index += 1)
        {
          if (simpleList2.Data1[index] > simpleList2.Data1[index - 1] & simpleList2.Data1[index] < simpleList2.Data1[index + 1])
            simpleList2.Data2[index] = 1;
        }
        int num10 = -1;
        int num11 = num10;
        int counter = simpleList2.Counter;
        Bitmap bitmap;
        Rectangle trect;
        Rectangle rectangle;
        for (int index1 = 0; index1 <= counter; index1 += 1)
        {
          if (simpleList2.Data2[index1] == 1 & num6 <= index1 & num7 >= index1)
          {
            str2: String = "";
            num10 += 1;
            if (num10 > num11)
              num11 = num10;
            int x2 = useRect.X;
            int x3;
            if (num10 <= num5 - 1)
            {
              x3 = x2 + num10 * 156;
              num8 = 3;
            }
            else
            {
              x3 = x2 + (num10 - num5) * 156;
              num8 = 107;
            }
            int sfNr = simpleList2.Id[index1];
            int type1 = this.game.Data.SFObj[sfNr].Type;
            int people1 = this.game.Data.SFObj[sfNr].People;
            int picSpriteId = this.game.Data.SFTypeObj[type1].PicSpriteID;
            int num12 = this.game.Data.SFObj[sfNr].Xp;
            int qty = this.game.Data.SFObj[sfNr].Qty;
            if (reconMinusHide.x < 3 && this.game.Data.FOWOn & this.game.Data.UnitObj[unitSelected].Regime != this.game.Data.Turn)
            {
              this.game.HandyFunctionsObj.RandomizeForUnit(unitSelected, qty);
              if (reconMinusHide.x == 2)
              {
                this.game.HandyFunctionsObj.RandomizeForUnit(unitSelected, qty);
                float num13 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
                float num14 = (float) ((1.0 - (double) num13) * 2.0);
                if ( Math.Round((double) Conversion.Int((VBMath.Rnd() * num14 + num13) * (float) qty)) < 1)
                  ;
                this.game.HandyFunctionsObj.RandomizeForUnit(unitSelected, num12);
                float num15 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
                float num16 = (float) ((1.0 - (double) num15) * 2.0);
                float num17 = VBMath.Rnd() * num16 + num15;
                num12 =  Math.Round((double) ((float) num12 * num17));
                if (num12 < 0)
                  num12 = 0;
                if (num12 > 100)
                  num12 = 100;
                VBMath.Randomize();
              }
              str2 = num10.ToString();
            }
            int Number;
            string name;
            int index2;
            if (simpleList2.Data3[index1] == 0)
            {
              sfNr = simpleList2.Id[index1];
              type1 = this.game.Data.SFObj[sfNr].Type;
              people1 = this.game.Data.SFObj[sfNr].People;
              picSpriteId = this.game.Data.SFTypeObj[type1].PicSpriteID;
              num12 = this.game.Data.SFObj[sfNr].Xp;
              Number = simpleList2.Data4[index1];
              name = this.game.Data.SFTypeObj[type1].Name;
              if (this.game.Data.SFTypeObj[type1].ModelID <= 0)
              {
                if (this.game.Data.RegimeObj[this.game.Data.UnitObj[unitSelected].Regime].ExtraGraphicUse > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[type1].ExtraCounter;
                  for (index2 = 0; index2 <= extraCounter; index2 += 1)
                  {
                    if (this.game.Data.SFTypeObj[type1].ExtraCode[index2] == this.game.Data.RegimeObj[this.game.Data.UnitObj[unitSelected].Regime].ExtraGraphicUse)
                      name = this.game.Data.SFTypeObj[type1].ExtraName[index2];
                  }
                }
                else if (this.game.Data.PeopleObj[this.game.Data.SFObj[sfNr].People].ExtraGraphicUse > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[type1].ExtraCounter;
                  for (index2 = 0; index2 <= extraCounter; index2 += 1)
                  {
                    if (this.game.Data.SFTypeObj[type1].ExtraCode[index2] == this.game.Data.PeopleObj[this.game.Data.SFObj[sfNr].People].ExtraGraphicUse)
                      name = this.game.Data.SFTypeObj[type1].ExtraName[index2];
                  }
                }
              }
            }
            else if (simpleList2.Data3[index1] == 1)
            {
              name = this.game.Data.TempString[this.game.Data.SFTypeObj[type1].ReinforcementType + 750];
              Number = simpleList2.Data4[index1];
            }
            else
            {
              name = this.game.Data.TempString[this.game.Data.SFTypeObj[type1].UnitGroup + 400];
              Number = simpleList2.Data4[index1];
            }
            if (this.game.Data.SFTypeObj[type1].Theater == 2)
            {
              if (eventPic1 > -1)
              {
                 Graphics local2 =  g;
                bitmap = BitmapStore.GetBitmap(eventPic1);
                 Bitmap local3 =  bitmap;
                trect = new Rectangle(0, 6, 137, 33);
                Rectangle srcrect = trect;
                rectangle = new Rectangle(x3 + 8, num8 + 9, 137, 80);
                Rectangle destrect = rectangle;
                DrawMod.DrawSimplePart2( local2,  local3, srcrect, destrect);
              }
              if (eventPic2 > -1)
              {
                 Graphics local4 =  g;
                bitmap = BitmapStore.GetBitmap(eventPic2);
                 Bitmap local5 =  bitmap;
                rectangle = new Rectangle(0, 6, 137, 80);
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x3 + 8, num8 + 69, 137, 20);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local4,  local5, srcrect, destrect);
              }
            }
            else
            {
              if (eventPic1 > -1)
              {
                 Graphics local6 =  g;
                bitmap = BitmapStore.GetBitmap(eventPic1);
                 Bitmap local7 =  bitmap;
                rectangle = new Rectangle(0, 6, 137, 80);
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x3 + 8, num8 + 9, 137, 80);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local6,  local7, srcrect, destrect);
              }
              if (eventPic2 > -1)
              {
                 Graphics local8 =  g;
                bitmap = BitmapStore.GetBitmap(eventPic2);
                 Bitmap local9 =  bitmap;
                rectangle = new Rectangle(0, 6, 137, 80);
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x3 + 8, num8 + 9, 137, 80);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local8,  local9, srcrect, destrect);
              }
            }
            this.game.Data.StringListObj[stringListById6].GetData(0, this.game.Data.PeopleObj[people1].tv1, 1).Replace(" ", "\r\n");
            index2 = this.game.Data.SFObj[sfNr].People;
            int type2 = this.game.Data.SFObj[sfNr].Type;
            int idValue1 = this.game.Data.PeopleObj[index2].tv0;
            int tv1 = this.game.Data.PeopleObj[index2].tv1;
            int idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById8].GetData(0, idValue1, 2)));
            int isUniformEventPic =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, idValue2, 3, tv1, 4)));
            int isAllowHair =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, idValue2, 3, tv1, 6)));
            int num18 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, idValue2, 3, tv1, 5)));
            int isPeoplePortraitGroup =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, idValue2, 3, tv1, 7)));
            int id = this.game.Data.RegimeObj[this.game.Data.UnitObj[unitSelected].Regime].id;
            if (this.game.Data.SFTypeObj[type2].SFTypeVar[89] < 1 | this.game.Data.UnitObj[unitSelected].Historical == -1)
            {
              int sidewaysSpriteId = this.game.Data.SFTypeObj[type2].SidewaysSpriteID;
              if (BitmapStore.GetWidth(sidewaysSpriteId) == 76 | BitmapStore.GetWidth(sidewaysSpriteId) == 72)
              {
                if (this.game.Data.SFTypeObj[type2].artCode[0] < 1)
                {
                   Graphics local10 =  g;
                  bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
                   Bitmap local11 =  bitmap;
                  rectangle = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
                  Rectangle srcrect = rectangle;
                  trect = new Rectangle(x3 + 8 + 30, num8 + 12, 76, 76);
                  Rectangle destrect = trect;
                  DrawMod.DrawSimplePart2( local10,  local11, srcrect, destrect);
                }
                else
                {
                   Graphics local12 =  g;
                  bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
                   Bitmap local13 =  bitmap;
                  rectangle = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
                  Rectangle srcrect = rectangle;
                  trect = new Rectangle(x3 + 8 + 30, num8 + 12, 76, 76);
                  Rectangle destrect = trect;
                  double r = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[1] / (float) byte.MaxValue);
                  double g1 = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[2] / (float) byte.MaxValue);
                  double b = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[3] / (float) byte.MaxValue);
                  DrawMod.DrawSimplePart2ColouredNew( local12,  local13, srcrect, destrect, (float) r, (float) g1, (float) b, 1f);
                }
                if (this.game.Data.SFTypeObj[type2].artCode[5] >= 1)
                {
                   Graphics local14 =  g;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[type2].SymbolColBigSprite2ID);
                   Bitmap local15 =  bitmap;
                  rectangle = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
                  Rectangle srcrect = rectangle;
                  trect = new Rectangle(x3 + 8 + 30, num8 + 12, 76, 76);
                  Rectangle destrect = trect;
                  double r = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[6] / (float) byte.MaxValue);
                  double g2 = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[7] / (float) byte.MaxValue);
                  double b = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[8] / (float) byte.MaxValue);
                  double a = (double) ((float) this.game.Data.SFTypeObj[type2].artCode[9] / (float) byte.MaxValue);
                  DrawMod.DrawSimplePart2ColouredNew( local14,  local15, srcrect, destrect, (float) r, (float) g2, (float) b, (float) a);
                }
              }
              else
              {
                 Graphics local16 =  g;
                bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
                 Bitmap local17 =  bitmap;
                rectangle = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x3 + 8, num8 + 10, 137, 80);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local16,  local17, srcrect, destrect);
              }
            }
            else
            {
              int people2 = this.game.Data.SFObj[sfNr].People;
              int tv0 = this.game.Data.PeopleObj[index2].tv0;
              bool isMilitia = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitSelected].Historical].GiveHisVarValue(11) > 0;
              int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById8].GetData(0, tv0, 1));
              Bitmap objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(type2, isMilitia, integer, this.game.Data.UnitObj[unitSelected].Regime, unitSelected);
              if (!Information.IsNothing((object) objBitmap))
              {
                int num19 = 8;
                int num20 = 8;
                int num21 = 136;
                int h = 76;
                int width = objBitmap.Width;
                int height = objBitmap.Height;
                int num22 = 0;
                if (width > num21 | height > h)
                {
                  int w;
                  int num23;
                  if ((double) width / (double) num21 < (double) height / (double) h)
                  {
                    float num24 = (float) h / (float) height;
                    index2 = num21;
                    w =  Math.Round((double) ((float) width * num24));
                    index2 -= w;
                    num23 = num19 +  Math.Round((double) index2 / 2.0);
                  }
                  else
                  {
                    float num25 = (float) num21 / (float) width;
                    index2 = h;
                    h =  Math.Round((double) ((float) height * num25));
                    index2 -= h;
                    num20 +=  Math.Round((double) index2 / 2.0);
                    index2 = num21;
                    w =  Math.Round((double) ((float) width * num25));
                    index2 -= w;
                    num23 = num19 +  Math.Round((double) index2 / 2.0);
                  }
                  if (124 - w > 0 && isPeoplePortraitGroup > 0)
                    num22 =  Math.Round((double) (124 - w) * 0.2);
                  DrawMod.DrawScaled( g,  objBitmap, x3 + num23 + num22, num8 + num20, w, h);
                }
                else
                {
                  int num26 = isPeoplePortraitGroup <= 0 ?  Math.Round((double) (136 - width) * 0.5) :  Math.Round((double) (136 - width) * 0.75);
                  DrawMod.DrawSimple( g,  objBitmap, x3 + num26 + num19, num8 + num20 +  Math.Round((double) (h - height) / 2.0));
                }
                objBitmap.Dispose();
                objBitmap = (Bitmap) null;
              }
            }
            str3: String = "";
            if (this.game.Data.SFTypeObj[type2].Theater == 2)
            {
              index2 = this.game.Data.SFTypeObj[type2].SFTypeVar[18];
              if (index2 > 0)
              {
                idValue1 = 0;
                if (this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitSelected].X, this.game.Data.UnitObj[unitSelected].Y].Location > -1)
                  idValue1 = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitSelected].X, this.game.Data.UnitObj[unitSelected].Y].Location].tempAirfieldLevel;
                if (idValue1 >= index2)
                {
                  if (index2 == 0)
                    str3 = "Doesn't need an Airbase.";
                  else
                    str3 = "Needs Airbase Level " + index2.ToString() + ". Hex has adequate Airbase Level " + idValue1.ToString() + ".";
                  DrawMod.DrawBlock( g, x3 + 111, num8 + 67, 30, 13, 0, 125, 0, 220);
                }
                else
                {
                  DrawMod.DrawBlock( g, x3 + 111, num8 + 67, 30, 14, 125, 0, 0, 220);
                  if (idValue1 > 0)
                    str3 = "Needs Airbase Level " + index2.ToString() + ". Hex has only Airbase Level " + idValue1.ToString() + ".";
                  else
                    str3 = "Needs Airbase Level " + index2.ToString() + ". Hex has no Airbase.";
                }
                DrawMod.DrawTextCenterSmallLabel( g, this.game.HandyFunctionsObj.GetRomanNumerical(index2), this.game.MarcFont4, x3 + 111 + 15, num8 + 67 + 7);
              }
            }
            if (this.game.Data.SFTypeObj[type2].Theater == 2 & (double) this.game.Data.RuleVar[848] > 0.0 || !(this.game.Data.SFTypeObj[type2].Theater == 1 & (double) this.game.Data.RuleVar[872] > 0.0))
              ;
            if (isPeoplePortraitGroup > 0 | isUniformEventPic > 0)
            {
              Bitmap objBitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(-1, 50, 70, isPeoplePortraitGroup: isPeoplePortraitGroup, isPeopleId: index2, isPeopleType: tv1, isRegId: id, isAllowHair: isAllowHair, isUniformEventPic: isUniformEventPic, sfNr: sfNr);
              DrawMod.DrawSimple( g,  objBitmap, x3 + 8, num8 + 6);
              objBitmap.Dispose();
            }
             Graphics local18 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_TROOPFRAME);
             Bitmap local19 =  bitmap;
            int x4 = x3;
            int y = num8;
            DrawMod.DrawSimple( local18,  local19, x4, y);
            if (reconMinusHide.x == 3)
            {
              if (this.game.Data.SFObj[sfNr].OffMod > 0)
              {
                tstring: String = "+" + Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sfNr].OffMod)) + "%";
                DrawMod.DrawBlockGradient2( g, x3 + 5, num8 + 22, 40, 16, Color.Red, Color.DarkRed);
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont4, x3 + 5, num8 + 20, Color.White);
              }
              else if (this.game.Data.SFObj[sfNr].OffMod < 0)
              {
                tstring: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sfNr].OffMod)) + "%";
                DrawMod.DrawBlockGradient2( g, x3 + 5, num8 + 22, 40, 16, Color.Red, Color.DarkRed);
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont4, x3 + 5, num8 + 20, Color.White);
              }
              if (this.game.Data.SFObj[sfNr].DefMod > 0)
              {
                tstring: String = "+" + Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sfNr].DefMod)) + "%";
                DrawMod.DrawBlockGradient2( g, x3 + 95, num8 + 22, 40, 16, Color.Blue, Color.DarkBlue);
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont4, x3 + 95, num8 + 20, Color.White);
              }
              else if (this.game.Data.SFObj[sfNr].DefMod < 0)
              {
                tstring: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sfNr].DefMod)) + "%";
                DrawMod.DrawBlockGradient2( g, x3 + 95, num8 + 22, 40, 16, Color.Blue, Color.DarkBlue);
                DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont4, x3 + 95, num8 + 20, Color.White);
              }
            }
            str4: String = Strings.Trim(Conversion.Str((object) Number)) + "x " + name;
            if (str4.Length > 20)
              str4 = Strings.Left(str4, 20) + ".";
            sizeF1 = g.MeasureString(str4, this.game.MarcFont7);
            DrawMod.DrawTextColouredConsoleCenter( g, str4, this.game.MarcFont7, x3 + 76, num8 + 85, this.game.seColGray);
            tstring1: String = Strings.Trim(Conversion.Str((object) num12)) + "xp";
            Color c = Color.White;
            if (this.game.Data.PeopleObj[people1].tv1 == 1)
              c = Color.FromArgb( byte.MaxValue, 170,  byte.MaxValue, 170);
            if (this.game.Data.PeopleObj[people1].tv1 == 2)
              c = Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue, 170);
            if (this.game.Data.PeopleObj[people1].tv1 == 3)
              c = Color.FromArgb( byte.MaxValue, 170,  byte.MaxValue,  byte.MaxValue);
            if (this.game.Data.PeopleObj[people1].tv1 == 4)
              c = Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
            if (this.game.Data.PeopleObj[people1].tv1 == 12)
              c = Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue, 170);
            if (this.game.Data.PeopleObj[people1].tv1 == 13)
              c = Color.FromArgb( byte.MaxValue, 170,  byte.MaxValue,  byte.MaxValue);
            if (this.game.Data.PeopleObj[people1].tv1 == 14)
              c = Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
            DrawMod.DrawTextColouredConsoleCenter( g, tstring1, this.game.MarcFont8, x3 + 34, num8 + 67, c);
            ttitle: String = Strings.Trim(Conversion.Str((object) Number)) + "x " + name;
            str5: String = "Troop type is " + this.game.Data.PeopleObj[people1].Name + "\r\n\r\n";
            if (str3.Length > 1)
              str5 = str5 + str3 + "\r\n\r\n";
            ttext: String = str5 + "(click for more info)";
            rectangle = new Rectangle(x3, num8, 152, 101);
            trect = rectangle;
            this.AddMouse( trect, ttitle, ttext, 99000 + simpleList2.Id[index1]);
          }
        }
        int num27 = num11;
        if (reconMinusHide.x >= 2 | !this.game.Data.FOWOn | this.game.Data.Round == 0 && simpleList1.Counter > -1)
        {
          int num28 = lessSubs - 1;
          for (int index3 = 0; index3 <= num28; index3 += 1)
          {
            if (num6 <= simpleList2.Counter + index3 + 1 & num7 >= simpleList2.Counter + index3 + 1)
            {
              num27 += 1;
              int idValue3 = simpleList1.Id[index3];
              int Number = simpleList1.Weight[index3];
              int x5;
              if (num27 <= num5 - 1)
              {
                x5 = useRect.X + num27 * 156;
                num8 = 3;
              }
              else
              {
                x5 = useRect.X + (num27 - num5) * 156;
                num8 = 107;
              }
              if (eventPic1 > -1)
              {
                 Graphics local20 =  g;
                bitmap = BitmapStore.GetBitmap(eventPic1);
                 Bitmap local21 =  bitmap;
                rectangle = new Rectangle(0, 6, 137, 80);
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x5 + 8, num8 + 9, 137, 80);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local20,  local21, srcrect, destrect);
              }
              if (eventPic2 > -1)
              {
                 Graphics local22 =  g;
                bitmap = BitmapStore.GetBitmap(eventPic2);
                 Bitmap local23 =  bitmap;
                rectangle = new Rectangle(0, 6, 137, 80);
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x5 + 8, num8 + 9, 137, 80);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local22,  local23, srcrect, destrect);
              }
              int index4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 10)));
              data2: String = this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 2);
              int nr = this.game.Data.EventPicNr[index4];
              if (BitmapStore.GetWidth(nr) < 128)
              {
                int num29 = 8;
                int num30 = 0;
                int num31 = 136;
                int num32 = 72;
                int width = BitmapStore.GetWidth(nr);
                int num33 = BitmapStore.Getheight(nr);
                 Graphics local24 =  g;
                bitmap = BitmapStore.GetBitmap(nr);
                 Bitmap local25 =  bitmap;
                int x6 = x5 + num29 +  Math.Round((double) (num31 - width) / 2.0);
                int y = num8 + num30 +  Math.Round((double) (num32 - num33) / 2.0);
                DrawMod.DrawSimple( local24,  local25, x6, y);
              }
              else
              {
                 Graphics local26 =  g;
                bitmap = BitmapStore.GetBitmap(nr);
                 Bitmap local27 =  bitmap;
                rectangle = new Rectangle(0, 0, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr));
                Rectangle srcrect = rectangle;
                trect = new Rectangle(x5 + 8, num8 + 10, 137, 80);
                Rectangle destrect = trect;
                DrawMod.DrawSimplePart2( local26,  local27, srcrect, destrect);
              }
               Graphics local28 =  g;
              bitmap = BitmapStore.GetBitmap(this.game.SE1_TROOPFRAME);
               Bitmap local29 =  bitmap;
              int x7 = x5;
              int y1 = num8;
              DrawMod.DrawSimple( local28,  local29, x7, y1);
              str6: String = Strings.Trim(Conversion.Str((object) Number)) + "x " + data2;
              if (Strings.Len(str6) > 20)
                str6 = Strings.Left(str6, 20) + ".";
              sizeF1 = g.MeasureString(str6, this.game.MarcFont7);
              DrawMod.DrawTextColouredConsoleCenter( g, str6, this.game.MarcFont7, x5 + 76, num8 + 85, this.game.seColGray);
              tstring: String = "Feat";
              Color gray = Color.Gray;
              DrawMod.DrawTextColouredConsoleCenter( g, tstring, this.game.MarcFont8, x5 + 34, num8 + 68, gray);
              data3: String = this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 12);
              str7: String = "Ratio Feat:Sub Units 1:" + this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 3) + "\r\n";
              int stringListById9 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
              int idValue4 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 1)));
              data4: String = this.game.Data.StringListObj[stringListById4].GetData(0, idValue4, 5);
              float num34 = (float)  Math.Round((double) ((float) (1000 -  Math.Round(100.0 * Math.Sqrt((double) (100 -  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById9].GetData2(0, this.game.Data.RegimeObj[this.game.Data.UnitObj[unitSelected].Regime].id, 1, data4, 2))))))) / 6f));
              if (this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn && this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 4).Length > 0)
                str7 = str7 + "Acquire 1st chance per round: " + Math.Round((double) Conversions.ToInteger(this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 4)) * (double) num34 / 1000.0, 2).ToString() + "%\r\n";
              str8: String = str7 + "Embeds with howmany Sub Units: " + this.game.Data.StringListObj[stringListById5].GetData(0, idValue3, 13);
              ttext: String = data3 + "\r\n" + str8;
              rectangle = new Rectangle(x5, num8, 152, 101);
              trect = rectangle;
              this.AddMouse( trect, "UNIT FEAT: " + str6 + " (" + Number.ToString() + "x)", ttext);
            }
          }
        }
        if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[unitSelected].Regime) | !this.game.Data.FOWOn | this.game.Data.Round == 0 && this.game.Data.UnitObj[unitSelected].PassengerCounter > -1)
        {
          int passengerCounter = this.game.Data.UnitObj[unitSelected].PassengerCounter;
          for (int index = 0; index <= passengerCounter; index += 1)
          {
            int num35 = index + num11 + 1 + stringListById5;
            int passenger = this.game.Data.UnitObj[unitSelected].PassengerList[index];
            int num36 =  Math.Round((double) (this.w - 1024) / 2.0) + 440;
            DrawMod.DrawBlockGradient2( g, num36, num8, 140, 20, this.game.MarcCol3, this.game.MarcCol2);
            DrawMod.DrawBlockGradient2( g, num36 + 88, num8 + 84, 52, 16, Color.FromArgb(0,  this.game.MarcCol3.R,  this.game.MarcCol3.G,  this.game.MarcCol3.B), this.game.MarcCol3);
            if (this.game.EditObj.SFSelected == num35)
            {
              DrawMod.DrawBlockGradient2( g, num36 + 2, num8 + 22, 136, 74, Color.FromArgb(128,  byte.MaxValue, 0, 0), Color.FromArgb(32,  byte.MaxValue, 0, 0));
              DrawMod.DrawRectangle( g, num36 + 2, num8 + 22, 136, 74,  byte.MaxValue, 0, 0, 200, 2);
            }
            this.game.CustomBitmapObj.DrawUnitBig(passenger, toG: g, tx: (num36 + 12), ty: (num8 + 23));
            DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num36, num8, 141, 101, -1, -1);
            str9: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(passenger)));
            SizeF sizeF2 = g.MeasureString(str9, this.game.MarcFont8b);
            DrawMod.DrawTextColouredMarc( g, str9, this.game.MarcFont8b,  Math.Round((double) ((float) (num36 + 98 + 16) - sizeF2.Width / 2f)), num8 + 56, Color.White);
             Graphics local30 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.ICONAP1);
             Bitmap local31 =  bitmap;
            int x8 = num36 + 98;
            int y = num8 + 32;
            DrawMod.DrawSimple( local30,  local31, x8, y);
            rectangle = new Rectangle(num36 + 98, num8 + 32, 32, 36);
            trect = rectangle;
            this.AddMouse( trect, "ACTION POINTS", "Passenger must have more then 0 AP to be unloaded outside a port.", 0);
            str10: String = Strings.UCase(this.game.Data.UnitObj[passenger].Name);
            if (Strings.Len(str10) > 20)
              str10 = Strings.Left(str10, 18) + "...";
            SizeF sizeF3 = g.MeasureString(str10, this.game.MarcFont5);
            DrawMod.DrawTextColouredMarc( g, str10, this.game.MarcFont5,  Math.Round((double) ((float) (num36 + 122) - sizeF3.Width)), num8 + 5, Color.White);
            rectangle = new Rectangle(num36, num8, 140, 100);
            trect = rectangle;
            this.AddMouse( trect, "PASSENGER UNIT", "Select this unit to make the unloading button show up.", 9999000 + num35);
          }
        }
      }
      Coordinate coordinate1;
      coordinate1.x = PageNr;
      coordinate1.y = val2;
      return coordinate1;
    }

    pub void DetailTab(Graphics g)
    {
      SizeF sizeF1 = SizeF::new();
      int num1 = 0;
      if (this.game.EmpireStyle)
        num1 = 128;
      int unitSelected1 = this.game.EditObj.UnitSelected;
      int num2 =  Math.Round((double) (this.w - 1024) / 2.0) + 440;
      DrawMod.DrawBlockGradient2( g, num2, 35, 580 + num1, 175, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num2, 35, 580 + num1, 174, -1, -1);
      Bitmap bitmap;
      if (this.game.EditObj.SetSubViewMode == 3)
      {
         Graphics local1 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
         Bitmap local2 =  bitmap;
        int x1 = num2 + 20;
        DrawMod.Draw( local1,  local2, x1, 11, -0.1f, -0.1f, -0.1f, 1f);
        str1: String = "BASIC DETAIL";
        SizeF sizeF2 = g.MeasureString(str1, this.game.MarcFont16);
        int x2 =  Math.Round((double) ((float) (num2 + 20 + 91) - sizeF2.Width / 2f));
        int y1 = 11;
        DrawMod.DrawTextColouredMarc( g, str1, this.game.MarcFont16, x2, y1 + 4, Color.White);
        Rectangle trect1 = new Rectangle(num2 + 20, y1, 182, 24);
        this.AddMouse( trect1, "", "Click to inspect basic details like supply and carry statistics.", 101);
        Rectangle trect2;
        if ((double) this.game.Data.RuleVar[337] > 0.0)
        {
           Graphics local3 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local4 =  bitmap;
          int x3 = num2 + 20 + 170;
          DrawMod.Draw( local3,  local4, x3, 11, -0.1f, -0.1f, -0.1f, 1f);
          str2: String = "REPL RECEIVED";
          SizeF sizeF3 = g.MeasureString(str2, this.game.MarcFont16);
          int x4 =  Math.Round((double) ((float) (num2 + 20 + 170 + 91) - sizeF3.Width / 2f));
          int y2 = 11;
          DrawMod.DrawTextColouredMarc( g, str2, this.game.MarcFont16, x4, y2 + 4, Color.White);
          trect1 = new Rectangle(num2 + 20 + 170, y2, 182, 24);
          Rectangle trect3 = trect1;
          this.AddMouse( trect3, "", "Click to inspect the replacement logs.", 102);
          if (this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 0.0 | this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 1.0 & this.game.Data.UnitObj[unitSelected1].HQ == -1)
          {
             Graphics local5 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
             Bitmap local6 =  bitmap;
            int x5 = num2 + 20 + 340;
            DrawMod.Draw( local5,  local6, x5, 11, -0.1f, -0.1f, -0.1f, 1f);
            str3: String = "REPL SENT OUT";
            SizeF sizeF4 = g.MeasureString(str3, this.game.MarcFont16);
            int x6 =  Math.Round((double) ((float) (num2 + 20 + 340 + 91) - sizeF4.Width / 2f));
            int y3 = 11;
            DrawMod.DrawTextColouredMarc( g, str3, this.game.MarcFont16, x6, y3 + 4, Color.White);
            trect1 = new Rectangle(num2 + 20 + 340, y3, 182, 24);
            trect2 = trect1;
            this.AddMouse( trect2, "", "Click to inspect the replacement logs.", 103);
          }
        }
        if ((double) this.game.Data.RuleVar[403] > 0.0)
        {
           Graphics local7 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local8 =  bitmap;
          int x7 = num2 + 20 + 510;
          DrawMod.DrawSimple( local7,  local8, x7, 11);
          str4: String = "ITEMS";
          SizeF sizeF5 = g.MeasureString(str4, this.game.MarcFont16);
          int x8 =  Math.Round((double) ((float) (num2 + 20 + 510 + 91) - sizeF5.Width / 2f));
          int y4 = 11;
          DrawMod.DrawTextColouredMarc( g, str4, this.game.MarcFont16, x8, y4 + 4, Color.White);
          trect1 = new Rectangle(num2 + 20 + 510, y4, 182, 24);
          trect2 = trect1;
          this.AddMouse( trect2, "", "Click to inspect the items and item logs.", 104);
        }
      }
      else if (this.game.EditObj.SetSubViewMode == 2)
      {
        Rectangle rectangle;
        Rectangle trect;
        if ((double) this.game.Data.RuleVar[403] > 0.0)
        {
           Graphics local9 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local10 =  bitmap;
          int x9 = num2 + 20 + 510;
          DrawMod.Draw( local9,  local10, x9, 11, -0.1f, -0.1f, -0.1f, 1f);
          str: String = "ITEMS";
          SizeF sizeF6 = g.MeasureString(str, this.game.MarcFont16);
          int x10 =  Math.Round((double) ((float) (num2 + 20 + 510 + 91) - sizeF6.Width / 2f));
          int y = 11;
          DrawMod.DrawTextColouredMarc( g, str, this.game.MarcFont16, x10, y + 4, Color.White);
          rectangle = new Rectangle(num2 + 20 + 510, y, 182, 24);
          trect = rectangle;
          this.AddMouse( trect, "", "Click to inspect the items and item logs.", 104);
        }
         Graphics local11 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
         Bitmap local12 =  bitmap;
        int x11 = num2 + 20;
        DrawMod.Draw( local11,  local12, x11, 11, -0.1f, -0.1f, -0.1f, 1f);
        str5: String = "BASIC DETAIL";
        SizeF sizeF7 = g.MeasureString(str5, this.game.MarcFont16);
        int x12 =  Math.Round((double) ((float) (num2 + 20 + 91) - sizeF7.Width / 2f));
        int y5 = 11;
        DrawMod.DrawTextColouredMarc( g, str5, this.game.MarcFont16, x12, y5 + 4, Color.White);
        rectangle = new Rectangle(num2 + 20, y5, 182, 24);
        trect = rectangle;
        this.AddMouse( trect, "", "Click to inspect basic details like supply and carry statistics.", 101);
        if ((double) this.game.Data.RuleVar[337] > 0.0)
        {
           Graphics local13 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local14 =  bitmap;
          int x13 = num2 + 20 + 170;
          DrawMod.Draw( local13,  local14, x13, 11, -0.1f, -0.1f, -0.1f, 1f);
          str6: String = "REPL RECEIVED";
          SizeF sizeF8 = g.MeasureString(str6, this.game.MarcFont16);
          int x14 =  Math.Round((double) ((float) (num2 + 20 + 170 + 91) - sizeF8.Width / 2f));
          int y6 = 11;
          DrawMod.DrawTextColouredMarc( g, str6, this.game.MarcFont16, x14, y6 + 4, Color.White);
          rectangle = new Rectangle(num2 + 20 + 170, y6, 182, 24);
          trect = rectangle;
          this.AddMouse( trect, "", "Click to inspect the replacement logs.", 102);
          if (this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 0.0 | this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 1.0 & this.game.Data.UnitObj[unitSelected1].HQ == -1)
          {
             Graphics local15 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
             Bitmap local16 =  bitmap;
            int x15 = num2 + 20 + 340;
            DrawMod.DrawSimple( local15,  local16, x15, 11);
            str7: String = "REPL SENT OUT";
            SizeF sizeF9 = g.MeasureString(str7, this.game.MarcFont16);
            int x16 =  Math.Round((double) ((float) (num2 + 20 + 340 + 91) - sizeF9.Width / 2f));
            int y7 = 11;
            DrawMod.DrawTextColouredMarc( g, str7, this.game.MarcFont16, x16, y7 + 4, Color.White);
            rectangle = new Rectangle(num2 + 20 + 340, y7, 182, 24);
            trect = rectangle;
            this.AddMouse( trect, "", "Click to inspect the replacement logs.", 103);
          }
        }
      }
      else if (this.game.EditObj.SetSubViewMode == 1)
      {
        Rectangle rectangle;
        Rectangle trect;
        if ((double) this.game.Data.RuleVar[403] > 0.0)
        {
           Graphics local17 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local18 =  bitmap;
          int x17 = num2 + 20 + 510;
          DrawMod.Draw( local17,  local18, x17, 11, -0.1f, -0.1f, -0.1f, 1f);
          str: String = "ITEMS";
          SizeF sizeF10 = g.MeasureString(str, this.game.MarcFont16);
          int x18 =  Math.Round((double) ((float) (num2 + 20 + 510 + 91) - sizeF10.Width / 2f));
          int y = 11;
          DrawMod.DrawTextColouredMarc( g, str, this.game.MarcFont16, x18, y + 4, Color.White);
          rectangle = new Rectangle(num2 + 20 + 510, y, 182, 24);
          trect = rectangle;
          this.AddMouse( trect, "", "Click to inspect the items and item logs.", 104);
        }
         Graphics local19 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
         Bitmap local20 =  bitmap;
        int x19 = num2 + 20;
        DrawMod.Draw( local19,  local20, x19, 11, -0.1f, -0.1f, -0.1f, 1f);
        str8: String = "BASIC DETAIL";
        SizeF sizeF11 = g.MeasureString(str8, this.game.MarcFont16);
        int x20 =  Math.Round((double) ((float) (num2 + 20 + 91) - sizeF11.Width / 2f));
        int y8 = 11;
        DrawMod.DrawTextColouredMarc( g, str8, this.game.MarcFont16, x20, y8 + 4, Color.White);
        rectangle = new Rectangle(num2 + 20, y8, 182, 24);
        trect = rectangle;
        this.AddMouse( trect, "", "Click to inspect basic details like supply and carry statistics.", 101);
        if ((double) this.game.Data.RuleVar[337] > 0.0)
        {
          if (this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 0.0 | this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 1.0 & this.game.Data.UnitObj[unitSelected1].HQ == -1)
          {
             Graphics local21 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
             Bitmap local22 =  bitmap;
            int x21 = num2 + 20 + 340;
            DrawMod.Draw( local21,  local22, x21, 11, -0.1f, -0.1f, -0.1f, 1f);
            str9: String = "REPL SENT OUT";
            SizeF sizeF12 = g.MeasureString(str9, this.game.MarcFont16);
            int x22 =  Math.Round((double) ((float) (num2 + 20 + 340 + 91) - sizeF12.Width / 2f));
            int y9 = 11;
            DrawMod.DrawTextColouredMarc( g, str9, this.game.MarcFont16, x22, y9 + 4, Color.White);
            rectangle = new Rectangle(num2 + 20 + 340, y9, 182, 24);
            trect = rectangle;
            this.AddMouse( trect, "", "Click to inspect the replacement logs.", 103);
          }
           Graphics local23 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local24 =  bitmap;
          int x23 = num2 + 20 + 170;
          DrawMod.DrawSimple( local23,  local24, x23, 11);
          str10: String = "REPL RECEIVED";
          SizeF sizeF13 = g.MeasureString(str10, this.game.MarcFont16);
          int x24 =  Math.Round((double) ((float) (num2 + 20 + 170 + 91) - sizeF13.Width / 2f));
          int y10 = 11;
          DrawMod.DrawTextColouredMarc( g, str10, this.game.MarcFont16, x24, y10 + 4, Color.White);
          rectangle = new Rectangle(num2 + 20 + 170, y10, 182, 24);
          trect = rectangle;
          this.AddMouse( trect, "", "Click to inspect the replacement logs.", 102);
        }
      }
      else if (this.game.EditObj.SetSubViewMode == 0)
      {
        Rectangle rectangle;
        Rectangle trect;
        if ((double) this.game.Data.RuleVar[403] > 0.0)
        {
           Graphics local25 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local26 =  bitmap;
          int x25 = num2 + 20 + 510;
          DrawMod.Draw( local25,  local26, x25, 11, -0.1f, -0.1f, -0.1f, 1f);
          str: String = "ITEMS";
          SizeF sizeF14 = g.MeasureString(str, this.game.MarcFont16);
          int x26 =  Math.Round((double) ((float) (num2 + 20 + 510 + 91) - sizeF14.Width / 2f));
          int y = 11;
          DrawMod.DrawTextColouredMarc( g, str, this.game.MarcFont16, x26, y + 4, Color.White);
          rectangle = new Rectangle(num2 + 20 + 510, y, 182, 24);
          trect = rectangle;
          this.AddMouse( trect, "", "Click to inspect the items and item logs.", 104);
        }
        if ((double) this.game.Data.RuleVar[337] > 0.0)
        {
          if (this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 0.0 | this.game.Data.UnitObj[unitSelected1].IsHQ & (double) this.game.Data.RuleVar[887] == 1.0 & this.game.Data.UnitObj[unitSelected1].HQ == -1)
          {
             Graphics local27 =  g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
             Bitmap local28 =  bitmap;
            int x27 = num2 + 20 + 340;
            DrawMod.Draw( local27,  local28, x27, 11, -0.1f, -0.1f, -0.1f, 1f);
            str: String = "REPL SENT OUT";
            SizeF sizeF15 = g.MeasureString(str, this.game.MarcFont16);
            int x28 =  Math.Round((double) ((float) (num2 + 20 + 340 + 91) - sizeF15.Width / 2f));
            int y = 11;
            DrawMod.DrawTextColouredMarc( g, str, this.game.MarcFont16, x28, y + 4, Color.White);
            rectangle = new Rectangle(num2 + 20 + 340, y, 182, 24);
            trect = rectangle;
            this.AddMouse( trect, "", "Click to inspect the replacement logs.", 103);
          }
           Graphics local29 =  g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
           Bitmap local30 =  bitmap;
          int x29 = num2 + 20 + 170;
          DrawMod.Draw( local29,  local30, x29, 11, -0.1f, -0.1f, -0.1f, 1f);
          str11: String = "REPL RECEIVED";
          SizeF sizeF16 = g.MeasureString(str11, this.game.MarcFont16);
          int x30 =  Math.Round((double) ((float) (num2 + 20 + 170 + 91) - sizeF16.Width / 2f));
          int y11 = 11;
          DrawMod.DrawTextColouredMarc( g, str11, this.game.MarcFont16, x30, y11 + 4, Color.White);
          rectangle = new Rectangle(num2 + 20 + 170, y11, 182, 24);
          trect = rectangle;
          this.AddMouse( trect, "", "Click to inspect the replacement logs.", 102);
        }
         Graphics local31 =  g;
        bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
         Bitmap local32 =  bitmap;
        int x31 = num2 + 20;
        DrawMod.DrawSimple( local31,  local32, x31, 11);
        str12: String = "BASIC DETAIL";
        SizeF sizeF17 = g.MeasureString(str12, this.game.MarcFont16);
        int x32 =  Math.Round((double) ((float) (num2 + 20 + 91) - sizeF17.Width / 2f));
        int y12 = 11;
        DrawMod.DrawTextColouredMarc( g, str12, this.game.MarcFont16, x32, y12 + 4, Color.White);
        rectangle = new Rectangle(num2 + 20, y12, 182, 24);
        trect = rectangle;
        this.AddMouse( trect, "", "Click to inspect basic details like supply and carry statistics.", 101);
      }
      int unitSelected2 = this.game.EditObj.UnitSelected;
      Coordinate reconMinusHide;
      if (this.game.Data.UnitObj[unitSelected2].Regime == this.game.Data.Turn | this.game.Data.Round == 0 | !this.game.Data.FOWOn)
        reconMinusHide.x = 3;
      else
        reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unitSelected2, this.game.Data.Turn);
      int x33 = num2 + 16;
      if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[unitSelected2].Regime, this.game.Data.Turn))
        return;
      if (this.game.EditObj.SetSubViewMode == 0)
      {
        ListClass listClass1 = ListClass::new();
        str: String = !this.game.Data.UnitObj[unitSelected2].IsHQ ? Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].Supply)) : Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetRealHQSupplyPts(unitSelected2)));
        tvalue1: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].Supply));
        listClass1.add("Supply Stock", -1, tvalue1);
        if (!this.game.Data.UnitObj[unitSelected2].IsHQ)
        {
          string tvalue2;
          if (this.game.HandyFunctionsObj.UnitSupplyUse(unitSelected2) > 0)
          {
            float Number = (float) Math.Round((double) ((float) this.game.Data.UnitObj[unitSelected2].Supply / (float) this.game.HandyFunctionsObj.UnitSupplyUse(unitSelected2)), 1);
            if ((double) Number > 99.0)
              Number = 99f;
            tvalue2 = Strings.Trim(Conversion.Str((object) Number));
          }
          else
            tvalue2 = ">99";
          listClass1.add("Rounds of Stock", -1, tvalue2);
        }
        if (Operators.ConditionalCompareObjectGreater(this.game.HandyFunctionsObj.GetStockpileUsePerRound(unitSelected2), (object) 0, false))
        {
          tvalue3: String = Strings.Trim(Conversion.Str((object) Conversion.Int(this.game.Data.UnitObj[unitSelected2].StockpileCurrent))) + "/" + this.game.HandyFunctionsObj.GetMaxStockpile(unitSelected2).ToString() + " (" + Strings.Trim(Conversion.Str(RuntimeHelpers.GetObjectValue(Conversion.Int(Operators.DivideObject((object) this.game.Data.UnitObj[unitSelected2].StockpileCurrent, this.game.HandyFunctionsObj.GetStockpileUsePerRound(unitSelected2)))))) + ")";
          listClass1.add("Stockpile", -1, tvalue3);
        }
        tvalue4: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].SupplyInReq));
        listClass1.add("Supply In Req", -1, tvalue4);
        tvalue5: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].SupplyIn));
        listClass1.add("Supply In", -1, tvalue5);
        tvalue6: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].SupplyLost));
        listClass1.add("Supply Lost", -1, tvalue6);
        if (this.game.Data.UnitObj[unitSelected2].IsHQ)
        {
          tvalue7: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].SupplyReq));
          listClass1.add("Supply Out Req", -1, tvalue7);
          tvalue8: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected2].SupplyOut));
          listClass1.add("Supply Out", -1, tvalue8);
        }
        ListClass tListobj1 = listClass1;
        let mut game1: GameClass = this.game;
         Bitmap local33 =  this.OwnBitmap;
        int bbx1 = x33;
        Font font1 =  null;
         Font local34 =  font1;
        ListSubPartClass listSubPartClass1 = new ListSubPartClass(tListobj1, 7, 150, -1, game1, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 60, tdotopandbottom: false, tbackbitmap: ( local33), bbx: bbx1, bby: 59, tMarcStyle: true, overruleFont: ( local34));
        DrawMod.DrawTextColouredMarc( g, "SUPPLY STATS", this.game.MarcFont8b, x33 + 7, 41, Color.White);
         Graphics local35 =  g;
        bitmap = listSubPartClass1.Paint();
         Bitmap local36 =  bitmap;
        int x34 = x33;
        DrawMod.DrawSimple( local35,  local36, x34, 59);
        ListClass listClass2 = ListClass::new();
        tvalue9: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unitSelected2)));
        listClass2.add("Power points", -1, tvalue9);
        tvalue10: String = Strings.Trim(Conversion.Str(Operators.AddObject(this.game.HandyFunctionsObj.GetUnitNonSeaWeight(unitSelected2, true), this.game.HandyFunctionsObj.GetUnitExcessWeight(unitSelected2))));
        listClass2.add("Weight", -1, tvalue10);
        tvalue11: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitStackPts(unitSelected2)));
        listClass2.add("Stack points", -1, tvalue11);
        if (!this.game.Data.UnitObj[unitSelected2].IsHQ)
        {
          tvalue12: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.Gethqpow(unitSelected2))) + "%";
          listClass2.add("HQ Power", -1, tvalue12);
          int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
          int num3 = this.game.HandyFunctionsObj.GetStaffPercent(hq, true);
          int num4 = this.game.HandyFunctionsObj.GetStaffPercent(hq, true);
          int num5 = this.game.HandyFunctionsObj.GetStaffPercent(hq);
          int num6 = this.game.HandyFunctionsObj.GetStaffPercent(hq);
          if (num3 > 100)
            num3 = 100;
          if (num4 > 100)
            num4 = 100;
          if (num5 > 100)
            num5 = 100;
          if (num6 > 100)
            num6 = 100;
          int Number1 =  Math.Round((double)  Math.Round((double) num3 * (double) this.game.HandyFunctionsObj.GetStaffCombatMod(hq) * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0)) + (double) num5 * (double) this.game.Data.RuleVar[140] * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0));
          int Number2 =  Math.Round((double)  Math.Round((double) num4 * (double) this.game.HandyFunctionsObj.GetStaffMoraleMod(hq) * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0)) + (double) num6 * (double) this.game.Data.RuleVar[141] * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0));
          tvalue13: String = Strings.Trim(Conversion.Str((object) Number1)) + "%";
          listClass2.add("HQ Combat mod", -1, tvalue13);
          tvalue14: String = Strings.Trim(Conversion.Str((object) Number2)) + "%";
          listClass2.add("HQ Morale mod", -1, tvalue14);
        }
        if (this.game.Data.UnitObj[unitSelected2].Historical > -1)
        {
          tvalue15: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitSelected2].Historical].StartSize));
          listClass2.add("Div Subunits", -1, tvalue15);
        }
        if (this.game.HandyFunctionsObj.HasUnitNavySF(unitSelected2))
        {
          tvalue16: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected2, 1)));
          listClass2.add("Nav.carry", -1, tvalue16);
          tvalue17: String = Strings.Trim(Conversion.Str((object) (this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected2, 1) - this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected2, 1, true))));
          listClass2.add("Nav.carry used ", -1, tvalue17);
        }
        if (this.game.Data.UnitObj[unitSelected2].IsHQ)
        {
          tvalue18: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffNeeded(unitSelected2)));
          listClass2.add("Staff pts needed", -1, tvalue18);
          tvalue19: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffPoints(unitSelected2)));
          listClass2.add("Staff points", -1, tvalue19);
        }
        ListClass tListobj2 = listClass2;
        let mut game2: GameClass = this.game;
         Bitmap local37 =  this.OwnBitmap;
        int bbx2 = x33 + 175;
        Font font2 =  null;
         Font local38 =  font2;
        ListSubPartClass listSubPartClass2 = new ListSubPartClass(tListobj2, 7, 150, -1, game2, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 60, tdotopandbottom: false, tbackbitmap: ( local37), bbx: bbx2, bby: 59, tMarcStyle: true, overruleFont: ( local38));
        DrawMod.DrawTextColouredMarc( g, "   STATS", this.game.MarcFont8b, x33 + 7 + 175, 41, Color.White);
         Graphics local39 =  g;
        bitmap = listSubPartClass2.Paint();
         Bitmap local40 =  bitmap;
        int x35 = x33 + 175;
        DrawMod.DrawSimple( local39,  local40, x35, 59);
        ListClass listClass3 = ListClass::new();
        name1: String = this.game.Data.RegimeObj[this.game.Data.UnitObj[unitSelected2].Regime].Name;
        listClass3.add("Regime", -1, name1);
        name2: String = this.game.Data.PeopleObj[Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(unitSelected2))].Name;
        listClass3.add("People", -1, name2);
        ListClass tListobj3 = listClass3;
        let mut game3: GameClass = this.game;
         Bitmap local41 =  this.OwnBitmap;
        int bbx3 = x33 + 350;
        Font font3 =  null;
         Font local42 =  font3;
        ListSubPartClass listSubPartClass3 = new ListSubPartClass(tListobj3, 1, 200, -1, game3, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 130, tdotopandbottom: false, tbackbitmap: ( local41), bbx: bbx3, bby: 59, tMarcStyle: true, overruleFont: ( local42));
        DrawMod.DrawTextColouredMarc( g, "REGIME & PEOPLE", this.game.MarcFont8b, x33 + 7 + 350, 41, Color.White);
         Graphics local43 =  g;
        bitmap = listSubPartClass3.Paint();
         Bitmap local44 =  bitmap;
        int x36 = x33 + 350;
        DrawMod.DrawSimple( local43,  local44, x36, 59);
        ListClass listClass4 = ListClass::new();
        int[] numArray1 = new int[100];
        int[] numArray2 = new int[100];
        listClass4.add("MOVETYPE", -1, "WEIGHT", "CARRY");
        int sfCount = this.game.Data.UnitObj[unitSelected2].SFCount;
        for (int index1 = 0; index1 <= sfCount; index1 += 1)
        {
          int sf = this.game.Data.UnitObj[unitSelected2].SFList[index1];
          int type = this.game.Data.SFObj[sf].Type;
          int[] numArray3 = numArray1;
          int[] numArray4 = numArray3;
          int moveType1 = this.game.Data.SFTypeObj[type].MoveType;
          int index2 = moveType1;
          int num7 = numArray3[moveType1] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Weight;
          numArray4[index2] = num7;
          int[] numArray5 = numArray2;
          int[] numArray6 = numArray5;
          int moveType2 = this.game.Data.SFTypeObj[type].MoveType;
          int index3 = moveType2;
          int num8 = numArray5[moveType2] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].CarryCap;
          numArray6[index3] = num8;
        }
        int index = 0;
        int num9;
        do
        {
          if (numArray1[index] > 0)
          {
            num9 += 1;
            listClass4.add(this.game.Data.TempString[index], -1, Strings.Trim(Conversion.Str((object) numArray1[index])), Strings.Trim(Conversion.Str((object) numArray2[index])));
          }
          index += 1;
        }
        while (index <= 99);
        if (num9 <= 0)
          return;
        if (num9 > 3)
          num9 = 3;
        ListClass tListobj4 = listClass4;
        int tlistsize = num9 + 1;
        let mut game4: GameClass = this.game;
         Bitmap local45 =  this.OwnBitmap;
        int bbx4 = x33 + 350;
        Font font4 =  null;
         Font local46 =  font4;
        ListSubPartClass listSubPartClass4 = new ListSubPartClass(tListobj4, tlistsize, 200, -1, game4, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local45), bbx: bbx4, bby: 123, tMarcStyle: true, overruleFont: ( local46));
        DrawMod.DrawTextColouredMarc( g, "MOVEMENT DETAILS", this.game.MarcFont8b, x33 + 7 + 350, 105, Color.White);
         Graphics local47 =  g;
        bitmap = listSubPartClass4.Paint();
         Bitmap local48 =  bitmap;
        int x37 = x33 + 350;
        DrawMod.DrawSimple( local47,  local48, x37, 123);
      }
      else if (this.game.EditObj.SetSubViewMode == 1)
      {
        this.rlistobj = ListClass::new();
        this.rlistobj.add("REPLACEMENT TYPE", -1, "REQ", "IN", "RET", "D-RET");
        int peopleCounter = this.game.Data.PeopleCounter;
        for (int index4 = 0; index4 <= peopleCounter; index4 += 1)
        {
          int reinfCounter = this.game.Data.ReinfCounter;
          for (int index5 = 0; index5 <= reinfCounter; index5 += 1)
          {
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            tname: String = this.game.Data.ReinfName[index5] + " (" + Strings.Left(this.game.Data.PeopleObj[index4].Name, 3) + ")";
            int logCounter = this.game.Data.UnitObj[unitSelected2].LogCounter;
            for (int index6 = 0; index6 <= logCounter; index6 += 1)
            {
              if (this.game.Data.UnitObj[unitSelected2].LogData1[index6] == index5 & this.game.Data.UnitObj[unitSelected2].LogData2[index6] == index4)
              {
                if (this.game.Data.UnitObj[unitSelected2].LogType[index6] == 1)
                  num10 += this.game.Data.UnitObj[unitSelected2].LogData3[index6] * this.game.Data.ReinfRatio[index5];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index6] == 2)
                  num11 += this.game.Data.UnitObj[unitSelected2].LogData3[index6] * this.game.Data.ReinfRatio[index5];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index6] == 3)
                  num12 += this.game.Data.UnitObj[unitSelected2].LogData3[index6] * this.game.Data.ReinfRatio[index5];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index6] == 4)
                  num13 += this.game.Data.UnitObj[unitSelected2].LogData3[index6] * this.game.Data.ReinfRatio[index5];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index6] == 9)
                  num14 += this.game.Data.UnitObj[unitSelected2].LogData3[index6] * this.game.Data.ReinfRatio[index5];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index6] == 10)
                  num15 += this.game.Data.UnitObj[unitSelected2].LogData3[index6] * this.game.Data.ReinfRatio[index5];
              }
            }
            if (num10 > 0 | num11 > 0 | num12 > 0 | num13 > 0 | num14 > 0)
              this.rlistobj.add(tname, -1, num10.ToString() + "(" + num14.ToString() + ")", num11.ToString(), num12.ToString(), num13.ToString());
          }
        }
        ListClass rlistobj = this.rlistobj;
        let mut game: GameClass = this.game;
         Bitmap local49 =  this.OwnBitmap;
        int bbx = x33;
        Font font =  null;
         Font local50 =  font;
        let mut tsubpart: SubPartClass =  new ListSubPartClass(rlistobj, 8, 540, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 360, tdotopandbottom: false, tbackbitmap: ( local49), bbx: bbx, bby: 59, tMarcStyle: true, overruleFont: ( local50));
        this.rlistid = this.AddSubPart( tsubpart, x33, 59, 540, 144, 0);
        DrawMod.DrawTextColouredMarc( g, "REPLACEMENTS REQUESTED", this.game.MarcFont8b, x33 + 7, 41, Color.White);
      }
      else if (this.game.EditObj.SetSubViewMode == 2)
      {
        this.rlist2obj = ListClass::new();
        this.rlist2obj.add("REPLACEMENT TYPE", -1, "REQ", "OUT", "D-OUT", "RET");
        int peopleCounter = this.game.Data.PeopleCounter;
        for (int index7 = 0; index7 <= peopleCounter; index7 += 1)
        {
          int reinfCounter = this.game.Data.ReinfCounter;
          for (int index8 = 0; index8 <= reinfCounter; index8 += 1)
          {
            int num16 = 0;
            int num17 = 0;
            int num18 = 0;
            int num19 = 0;
            tname: String = this.game.Data.ReinfName[index8] + " (" + Strings.Left(this.game.Data.PeopleObj[index7].Name, 3) + ")";
            int logCounter = this.game.Data.UnitObj[unitSelected2].LogCounter;
            for (int index9 = 0; index9 <= logCounter; index9 += 1)
            {
              if (this.game.Data.UnitObj[unitSelected2].LogData1[index9] == index8 & this.game.Data.UnitObj[unitSelected2].LogData2[index9] == index7)
              {
                if (this.game.Data.UnitObj[unitSelected2].LogType[index9] == 5)
                  num16 += this.game.Data.UnitObj[unitSelected2].LogData3[index9] * this.game.Data.ReinfRatio[index8];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index9] == 6)
                  num17 += this.game.Data.UnitObj[unitSelected2].LogData3[index9] * this.game.Data.ReinfRatio[index8];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index9] == 7)
                  num18 += this.game.Data.UnitObj[unitSelected2].LogData3[index9] * this.game.Data.ReinfRatio[index8];
                if (this.game.Data.UnitObj[unitSelected2].LogType[index9] == 8)
                  num19 += this.game.Data.UnitObj[unitSelected2].LogData3[index9] * this.game.Data.ReinfRatio[index8];
              }
            }
            if (num16 > 0 | num17 > 0 | num18 > 0 | num19 > 0)
              this.rlist2obj.add(tname, -1, num16.ToString(), num17.ToString(), num18.ToString(), num19.ToString());
          }
        }
        ListClass rlist2obj = this.rlist2obj;
        let mut game: GameClass = this.game;
         Bitmap local51 =  this.OwnBitmap;
        int bbx = x33;
        Font font =  null;
         Font local52 =  font;
        let mut tsubpart: SubPartClass =  new ListSubPartClass(rlist2obj, 8, 540, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 360, tdotopandbottom: false, tbackbitmap: ( local51), bbx: bbx, bby: 59, tMarcStyle: true, overruleFont: ( local52));
        this.rlist2id = this.AddSubPart( tsubpart, x33, 59, 540, 144, 0);
        DrawMod.DrawTextColouredMarc( g, "REPLACEMENTS SENT", this.game.MarcFont8b, x33 + 7, 41, Color.White);
      }
      else
      {
        if (this.game.EditObj.SetSubViewMode != 3)
          return;
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[404]));
        this.rlist4obj = ListClass::new();
        this.rlist4obj.add("ITEM TYPE", -1, "PRESENT", "ZONE REQ", "ZONE DELIVER", "CONSUMED");
        int length = this.game.Data.StringListObj[stringListById].Length;
        for (int index10 = 0; index10 <= length; index10 += 1)
        {
          int num20 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index10, 0]));
          if (Information.IsNothing((object) this.game.Data.UnitObj[unitSelected2].items))
            this.game.Data.UnitObj[unitSelected2].items = ItemList::new();
          int nr = this.game.Data.UnitObj[unitSelected2].items.list.FindNr(num20);
          int num21 = 0;
          if (nr > -1)
            num21 = this.game.Data.UnitObj[unitSelected2].items.list.Weight[nr];
          int num22 = 0;
          int num23 = 0;
          int logCounter = this.game.Data.UnitObj[unitSelected2].LogCounter;
          for (int index11 = 0; index11 <= logCounter; index11 += 1)
          {
            if (this.game.Data.UnitObj[unitSelected2].LogType[index11] == 101 & this.game.Data.UnitObj[unitSelected2].LogData1[index11] == num20)
              num22 += this.game.Data.UnitObj[unitSelected2].LogData3[index11];
            if (this.game.Data.UnitObj[unitSelected2].LogType[index11] == 102 & this.game.Data.UnitObj[unitSelected2].LogData1[index11] == num20)
              num23 += this.game.Data.UnitObj[unitSelected2].LogData3[index11];
          }
          data: String = this.game.Data.StringListObj[stringListById].GetData(0, num20, 1);
          int integer1 = Conversions.ToInteger(num21.ToString());
          int integer2 = Conversions.ToInteger(num22.ToString());
          int integer3 = Conversions.ToInteger(num23.ToString());
          int num24 = 0;
          if (integer1 > 0 | integer3 > 0 | integer2 > 0 | num24 > 0)
            this.rlist4obj.add(data, -1, integer1.ToString(), integer3.ToString(), integer2.ToString(), num24.ToString());
        }
        ListClass rlist4obj = this.rlist4obj;
        int twidth = 540 + num1;
        let mut game: GameClass = this.game;
        int tValueWidth = 360 + num1;
         Bitmap local53 =  this.OwnBitmap;
        int bbx = x33;
        Font font =  null;
         Font local54 =  font;
        let mut tsubpart: SubPartClass =  new ListSubPartClass(rlist4obj, 8, twidth, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: ( local53), bbx: bbx, bby: 59, tMarcStyle: true, overruleFont: ( local54));
        this.rlist4id = this.AddSubPart( tsubpart, x33, 59, 540 + num1, 144, 0);
        DrawMod.DrawTextColouredMarc( g, "ITEMS", this.game.MarcFont8b, x33 + 7, 41, Color.White);
      }
    }

    pub void StandingOrders(Graphics g)
    {
      SizeF sizeF = SizeF::new();
      int num1 =  Math.Round((double) (this.w - 1024) / 2.0);
      int num2 = 0;
      if (this.game.EditObj.UnitSelected <= -1)
        return;
      if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
        num2 = 2;
      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
        num2 = 1;
      if (num2 <= 0)
        return;
      DrawMod.DrawBlockGradient2( g, num1 + 325, 5, 104, 21, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 325, 5, 105, 22, -1, -1);
      tstring1: String = "RETR = " + Strings.Trim(Conversion.Str((object) (100 - this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent))) + "%";
      DrawMod.DrawTextColouredMarc( g, tstring1, this.game.MarcFont5, num1 + 340 + 5, 10, Color.White);
      int tdata1 = num2 != 2 ? 2 : 0;
      Rectangle trect1 = new Rectangle(num1 + 325, 5, 105, 22);
      Rectangle trect2 = trect1;
      this.AddMouse( trect2, "RETREAT PERCENTAGE", "If 100% unit is ordered to fight to the last man.\r\nIf 25% then unit retreats once losses reach 25%\r\nIf you set this for a HQ, the setting will be automaticly copied by\r\nALL subordinate units. So if you change your top HQ, all subordinate units settings will be changed.", tdata1);
      DrawMod.DrawBlockGradient2( g, num1 + 325, 30, 104, 21, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 325, 30, 105, 22, -1, -1);
      str1: String = (double) this.game.Data.RuleVar[887] != 1.0 ? "SUPL = " + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent)) + "%" : "SUPL = " + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetAggregatedSupplyRequest(this.game.EditObj.UnitSelected))) + "%" + "(" + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent.ToString() + "%)";
      int num3 =  Math.Round((double) (g.MeasureString(str1, this.game.MarcFont5).Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str1, this.game.MarcFont5, num1 + 372 - num3 + 5, 35, Color.White);
      int tdata2 = num2 != 2 ? 3 : 0;
      trect2 = new Rectangle(num1 + 325, 30, 105, 22);
      trect1 = trect2;
      this.AddMouse( trect1, "SUPPLY REQUEST PERCENTAGE", "If 100% unit will ask all that it optimally needs.\r\nIf 50% only half of that.\r\nWarning! At the 50% level the unit will not recover readiness.\r\nThe percentage number shows the cumulative effect of supply settings for the unit and its HQ’s. The number without brackets is the effective percentage after cumulative effects. The number in brackets is the actual specific setting for this unit.", tdata2);
      int num4 = 55;
      if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
      {
        DrawMod.DrawBlockGradient2( g, num1 + 325, 55, 104, 21, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 325, 55, 105, 22, -1, -1);
        tstring2: String = "INTC = " + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop)) + "%";
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 100)
          tstring2 = "DONT INTC";
        DrawMod.DrawTextColouredMarc( g, tstring2, this.game.MarcFont5, num1 + 340 + 5, 60, Color.White);
        int tdata3 = num2 != 2 ? 4 : 0;
        trect2 = new Rectangle(num1 + 325, 55, 105, 22);
        trect1 = trect2;
        this.AddMouse( trect1, "INTERCEPT PERCENTAGE", "If 75% unit will only intercept if at >75 readiness pts.\r\nIf 50% it will intercept if >50 readiness pts.\r\nKeep in mind bombers and transporters never intercept.", tdata3);
        num4 += 25;
      }
      if (!((double) this.game.Data.RuleVar[337] > 0.0 & !this.game.HandyFunctionsObj.HasUnitNavySF(this.game.EditObj.UnitSelected)))
        return;
      DrawMod.DrawBlockGradient2( g, num1 + 325, num4, 104, 21, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 325, num4, 105, 22, -1, -1);
      string str2;
      if ((double) this.game.Data.RuleVar[887] == 1.0)
      {
        str3: String = "RPL = " + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(this.game.EditObj.UnitSelected))) + "%";
        if (this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(this.game.EditObj.UnitSelected) == 0)
          str3 = "DISBAND";
        if (this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(this.game.EditObj.UnitSelected) == 999)
          str3 = "PRIORITY";
        str2 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent != 999 ? str3 + "(" + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent.ToString() + "%)" : str3 + "(PRIO)";
      }
      else
      {
        str2 = "RPL = " + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent)) + "%";
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 0)
          str2 = "DISBAND";
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 999)
          str2 = "PRIORITY RPL";
      }
      int num5 =  Math.Round((double) (g.MeasureString(str2, this.game.MarcFont5).Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str2, this.game.MarcFont5, num1 + 372 - num5 + 5, num4 + 5, Color.White);
      int tdata4 = num2 != 2 ? 6 : 0;
      str4: String = "If 75% unit will only start requesting replacements if below 75%.\r\nIf 50% it will only start requesting replacements if below 50%\r\n";
      if ((double) this.game.Data.RuleVar[977] < 1.0)
        str4 += "If at 'DISBANDING' status it is at 0% replacement level and it will never request replacements.\r\n";
      ttext: String = str4 + "If at 'PRIORITY RPL' status it will be at 100% replacement level but get precedence above no-priority units.\r\nThe number presented is the cumulative effect of the units settings and its HQs.\r\nThe number between brackets is this units setting.";
      trect2 = new Rectangle(num1 + 325, num4, 105, 22);
      trect1 = trect2;
      this.AddMouse( trect1, "REPLACEMENT PERCENTAGE", ttext, tdata4);
    }

    pub void OtherUnits(Graphics g, Rectangle useRect)
    {
       Graphics local1 =  g;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_QUICKUNITFRAME);
       Bitmap local2 =  bitmap;
      int x1 = useRect.X;
      int y = useRect.Y;
      DrawMod.DrawSimple( local1,  local2, x1, y);
      if (this.game.SelectX == -1)
        return;
      int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
      int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
      int num1 = -1;
      int num2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
      if (num2 > 15)
        num2 = 15;
      int num3 = num2;
      for (int index = 0; index <= num3; index += 1)
      {
        if (this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index], this.game.Data.Turn) > 0)
          num1 += 1;
      }
      if (!(landscapeType > -1 & spriteNr > -1))
        return;
      int x2 = useRect.X;
      int num4 = -1;
      int num5 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
      if (num5 > 15)
        num5 = 15;
      int num6 = num5;
      for (int index = 0; index <= num6; index += 1)
      {
        int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
        if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit, this.game.Data.Turn) > 0)
        {
          num4 += 1;
          int num7;
          int num8;
          if (num4 <= 3)
          {
            num7 = x2 + 30 + num4 * 54;
            num8 = 15;
          }
          else if (num4 <= 7)
          {
            num7 = x2 + 30 + (num4 - 4) * 54;
            num8 = 65;
          }
          else if (num4 <= 11)
          {
            num7 = x2 + 30 + (num4 - 8) * 54;
            num8 = 115;
          }
          else
          {
            num7 = x2 + 30 + (num4 - 12) * 54;
            num8 = 165;
          }
          bool forcehighlight = false;
          if (this.game.EditObj.UnitSelected == unit)
            forcehighlight = true;
          this.game.CustomBitmapObj.DrawUnit(unit, forcehighlight, g, num7, num8, true);
          Rectangle trect1;
          Rectangle trect2;
          if (this.game.Data.Round == 0)
          {
            ttext: String = this.game.Data.UnitObj[unit].Name + "\r\n";
            if (this.game.Data.UnitObj[unit].Historical > -1)
              ttext = ttext + this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unit].Historical].Name + "\r\n" + "HIS-ID = " + this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unit].Historical].ID.ToString() + "\r\n";
            trect1 = new Rectangle(num7, num8, 37, 37);
            trect2 = trect1;
            this.AddMouse( trect2, "UNIT INFO", ttext);
          }
          else if (this.game.EditObj.UnitSelected == unit)
          {
            trect2 = new Rectangle(num7, num8, 37, 37);
            trect1 = trect2;
            this.AddMouse( trect1, "SELECTED UNIT", "You are currently viewing this unit. Click to put on top of stack.", 10000 + unit);
          }
          else
          {
            trect2 = new Rectangle(num7, num8, 37, 37);
            trect1 = trect2;
            this.AddMouse( trect1, "OTHER UNIT", "Click to select. Double click to put on top of stack.", 10000 + unit);
          }
        }
      }
    }

    pub void DrawViewModeExtra(Graphics g, int tabNr)
    {
      SizeF sizeF = SizeF::new();
      int x =  Math.Round((double) (this.w - 1024) / 2.0);
      int enr1 = this.game.Data.ExtraTabEvent;
      if (tabNr == 2)
        enr1 = this.game.Data.ExtraTabEvent2;
      if (tabNr == 3)
        enr1 = this.game.Data.ExtraTabEvent3;
      if (tabNr == 4)
        enr1 = this.game.Data.ExtraTabEvent4;
      int enr2 = -1;
      if ((double) this.game.Data.RuleVar[450] > 0.0 & this.game.ScreenWidth >= 1920)
        enr2 =  Math.Round(Conversion.Val((object) this.game.Data.RuleVar[450]));
      if ((double) this.game.Data.RuleVar[440] < 1.0)
      {
        DrawMod.DrawBlockGradient2( g, x + 6, 5, 1012, 210, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, x + 6, 5, 1012, 210, -1, -1);
        if (!(this.extraTabId == 0 & enr1 >= 0 & this.game.Data.Turn > -1))
          return;
        int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
        this.game.EventRelatedObj.DoCheckSpecificEvent(enr1);
        int index;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter == messCounter)
        {
          int num =  Interaction.MsgBox((object) "Error!!! The event called specified by ExecSetExtraTabEvent did not generate a message for our current regime.");
          index = 0;
        }
        else
          index = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
        let mut tsubpart: SubPartClass =  new DynamicArea(this.game, 1000, 200, this.game.Data.RegimeObj[this.game.Data.Turn].MessString[index],  this.OwnBitmap, x + 12, 10, true);
        this.extraTabId = this.AddSubPart( tsubpart, x + 12, 10, 1000, 200, 0);
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter <= messCounter)
          return;
        this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter = messCounter;
      }
      else if (enr1 == -2)
      {
        int location = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location;
        if (location > -1)
        {
          int stringListById = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[404]));
          this.rlist5obj = ListClass::new();
          this.rlist5obj.add("ITEM TYPE", -1, "PRESENT", "LOC IN", "LOC OUT", "CONSUMED");
          int length = this.game.Data.StringListObj[stringListById].Length;
          for (int index1 = 0; index1 <= length; index1 += 1)
          {
            int num1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index1, 0]));
            if (Information.IsNothing((object) this.game.Data.LocObj[location].items))
              this.game.Data.LocObj[location].items = ItemList::new();
            int nr = this.game.Data.LocObj[location].items.list.FindNr(num1);
            int num2 = 0;
            if (nr > -1)
              num2 = this.game.Data.LocObj[location].items.list.Weight[nr];
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int logCounter = this.game.Data.LocObj[location].LogCounter;
            for (int index2 = 0; index2 <= logCounter; index2 += 1)
            {
              if (this.game.Data.LocObj[location].LogType[index2] == 102 & this.game.Data.LocObj[location].LogData1[index2] == num1)
                num3 += this.game.Data.LocObj[location].LogData3[index2];
              if (this.game.Data.LocObj[location].LogType[index2] == 101 & this.game.Data.LocObj[location].LogData1[index2] == num1)
                num4 += this.game.Data.LocObj[location].LogData3[index2];
              if (this.game.Data.LocObj[location].LogType[index2] == 103 & this.game.Data.LocObj[location].LogData1[index2] == num1)
                num5 += this.game.Data.LocObj[location].LogData3[index2];
              if (this.game.Data.LocObj[location].LogType[index2] == 202 & this.game.Data.LocObj[location].LogData1[index2] == num1)
                num6 += this.game.Data.LocObj[location].LogData3[index2];
            }
            data: String = this.game.Data.StringListObj[stringListById].GetData(0, num1, 1);
            int num7 = num2;
            int num8 = num3;
            int num9 = num4;
            int num10 = num5;
            int num11 = num6;
            if ((num7 > 0 | num8 > 0 | num9 > 0 | num10 > 0) & num11 < 1)
              this.rlist5obj.add(data, -1, num7.ToString(), num8.ToString(), num9.ToString(), num10.ToString());
            else if (num7 > 0 | num8 > 0 | num9 > 0 | num10 > 0 | num11 > 0)
              this.rlist5obj.add(data, -1, num7.ToString(), num8.ToString() + "(" + num11.ToString() + ")", num9.ToString(), num10.ToString());
          }
          ListClass rlist5obj = this.rlist5obj;
          let mut game: GameClass = this.game;
           Bitmap local1 =  this.OwnBitmap;
          int bbx = x;
          Font font =  null;
           Font local2 =  font;
          let mut tsubpart: SubPartClass =  new ListSubPartClass(rlist5obj, 8, 500, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 350, tdotopandbottom: false, tbackbitmap: ( local1), bbx: bbx, bby: 59, tMarcStyle: true, overruleFont: ( local2));
          this.rlist5id = this.AddSubPart( tsubpart, x, 59, 500, 144, 0);
          DrawMod.DrawTextColouredMarc( g, "LOCATION ITEMS", this.game.MarcFont8b, x + 7, 41, Color.White);
        }
        else
          DrawMod.DrawTextColouredMarc( g, "NO LOCATION SELECTED", this.game.MarcFont8b, x + 7, 41, Color.White);
      }
      else
      {
        int areaX1 = this.game.EditObj.AreaX;
        int areaY1 = this.game.EditObj.AreaY;
        this.game.EditObj.AreaX = this.game.SelectX;
        this.game.EditObj.AreaY = this.game.SelectY;
        this.game.EventRelatedObj.DoCheckSpecificEvent(enr1, tv2: this.game.EditObj.UnitSelected);
        this.game.EditObj.AreaX = areaX1;
        this.game.EditObj.AreaY = areaY1;
        let mut tsubpart1: SubPartClass =  new UDSPartClass(this.game, 1280, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, x - 128, 7, true);
        this.extraTabId = this.AddSubPart( tsubpart1, x - 128, 7, 1280, 210, 1);
        if (enr2 <= 0)
          return;
        int areaX2 = this.game.EditObj.AreaX;
        int areaY2 = this.game.EditObj.AreaY;
        this.game.EditObj.AreaX = this.game.SelectX;
        this.game.EditObj.AreaY = this.game.SelectY;
        this.game.EventRelatedObj.DoCheckSpecificEvent(enr2, tv2: this.game.EditObj.UnitSelected);
        this.game.EditObj.AreaX = areaX2;
        this.game.EditObj.AreaY = areaY2;
        this.game.EditObj.UDStabText = this.game.EditObj.UDStabText;
        this.game.EditObj.UDSpopupText = this.game.EditObj.UDSpopupText;
        let mut tsubpart2: SubPartClass =  new UDSPartClass(this.game, 154, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, x + 16 + 1280 - 128, 7, true);
        this.smallTabId = this.AddSubPart( tsubpart2, x + 16 + 1280 - 128, 7, 154, 210, 1);
      }
    }

    pub void DrawUnitInfo(Graphics g, int unr)
    {
      SizeF sizeF1 = SizeF::new();
      int num1 =  Math.Round((double) (this.w - 1024) / 2.0);
      Coordinate reconMinusHide;
      if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | this.game.Data.Round == 0 | !this.game.Data.FOWOn)
        reconMinusHide.x = 3;
      else
        reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unr, this.game.Data.Turn);
      DrawMod.DrawBlockGradient2( g, num1 + 20, 5, 299, 99, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, num1 + 20, 5, 300, 100, -1, -1);
      Coordinate moveTypeLogo = this.game.HandyFunctionsObj.GetMoveTypeLogo(unr,  reconMinusHide, true);
      Rectangle trect1;
      Rectangle trect2;
      if (moveTypeLogo.x > -1 & moveTypeLogo.y > -1)
      {
        bool flag = false;
        if (this.game.HandyFunctionsObj.CanUnitMoveFreeCheck(unr, true) && !this.game.HandyFunctionsObj.CanUnitMoveFreeCheck(unr))
          flag = true;
        if (flag)
        {
           Graphics local1 =  g;
          Bitmap bitmap1 = BitmapStore.GetBitmap(moveTypeLogo.x);
           Bitmap local2 =  bitmap1;
          int x1 = num1 + 25;
          DrawMod.DrawSimple( local1,  local2, x1, 10);
           Graphics local3 =  g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SUPPLIESSYMBOL);
           Bitmap local4 =  bitmap2;
          int x2 = num1 + 25;
          DrawMod.DrawSimple( local3,  local4, x2, 30);
        }
        else
        {
           Graphics local5 =  g;
          Bitmap bitmap = BitmapStore.GetBitmap(moveTypeLogo.x);
           Bitmap local6 =  bitmap;
          int x = num1 + 25;
          DrawMod.DrawSimple( local5,  local6, x, 18);
        }
        str: String = this.game.Data.SFObj[moveTypeLogo.y].MoveType <= -1 ? this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[moveTypeLogo.y].Type].MoveType] : this.game.Data.TempString[this.game.Data.SFObj[moveTypeLogo.y].MoveType];
        if (flag)
          str += "\r\nUnit has not enough fuel available which causes movement problems.";
        trect1 = new Rectangle(num1 + 25, 10, 37, 37);
        trect2 = trect1;
        this.AddMouse( trect2, "MOVE TYPE", "This unit normally moves as movetype:\r\n" + str, 0);
      }
      else if (moveTypeLogo.x > -1)
      {
         Graphics local7 =  g;
        Bitmap bitmap = BitmapStore.GetBitmap(moveTypeLogo.x);
         Bitmap local8 =  bitmap;
        int x = num1 + 25;
        DrawMod.DrawSimple( local7,  local8, x, 18);
        trect2 = new Rectangle(num1 + 25, 10, 37, 37);
        trect1 = trect2;
        this.AddMouse( trect1, "SUPPLY DUMP MOVE TYPE", "This unit is overstacked with supply.\r\nIt moves with supplydump speed.", 0);
      }
      else
      {
        DrawMod.DrawTextColouredMarc( g, "?", this.game.MarcFont8, num1 + 42, 23, Color.White);
        trect2 = new Rectangle(num1 + 25, 10, 37, 37);
        trect1 = trect2;
        this.AddMouse( trect1, "MOVE TYPE UNKNOWN", "We got not enough recon on this unit\r\nand thus cannot determine its move type.", 0);
      }
      int num2 = 0;
      if (this.game.Data.UnitObj[unr].Historical > -1)
      {
        for (int hisVarCount = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].HisVarCount; hisVarCount >= 0; hisVarCount += -1)
        {
          int num3 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].HisVarType[hisVarCount];
          if (num3 >= 0 & num3 <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + num3], "1", false) == 0)
          {
            int index = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].HisVarSmall[hisVarCount];
            if (index > -1)
            {
              int width = BitmapStore.GetWidth(this.game.Data.SmallPicNr[index]);
              int height = BitmapStore.Getheight(this.game.Data.SmallPicNr[index]);
              num2 += width;
               Graphics local9 =  g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[index]);
               Bitmap local10 =  bitmap;
              int x = num1 + 70 + 250 - num2;
              DrawMod.DrawSimple( local9,  local10, x, 10);
              trect2 = new Rectangle(num1 + 70 + 250 - num2, 10, width, height);
              trect1 = trect2;
              this.AddMouse( trect1, "", this.game.Data.TempString[1200 + num3]);
            }
          }
        }
      }
      if (num2 > 120)
        num2 = 120;
      str1: String = this.game.Data.UnitObj[unr].Name;
      if (reconMinusHide.x < 2)
        str1 = "?";
      str2: String = Strings.UCase(str1);
      SizeF sizeF2 = g.MeasureString(str2, this.game.MarcFont8b);
      int num4 = 0;
      for (; (double) sizeF2.Width > (double) (230 - num2); sizeF2 = g.MeasureString(str2, this.game.MarcFont8b))
      {
        num4 = 1;
        str2 = Strings.Left(str2, Strings.Len(str2) - 1);
      }
      if (num4 == 1)
        str2 += "...";
      DrawMod.DrawTextColouredMarc( g, str2, this.game.MarcFont8b, num1 + 70, 10, Color.White);
      if (this.game.Data.Turn == this.game.Data.UnitObj[unr].Regime && this.game.Data.UnitObj[unr].Historical > -1)
      {
        trect2 = new Rectangle(num1 + 70, 10,  Math.Round((double) sizeF2.Width), 15);
        trect1 = trect2;
        this.AddMouse( trect1, "", "Click to change name of unit", 40);
      }
      string str3;
      if (this.game.Data.UnitObj[unr].HQ > -1)
      {
        str3 = "HQ: " + this.game.Data.UnitObj[this.game.Data.UnitObj[unr].HQ].Name;
        if (reconMinusHide.x < 2)
          str3 = "HQ: ?";
      }
      else
      {
        str3 = "(has no HQ)";
        if (reconMinusHide.x < 2)
          str3 = "HQ: ?";
      }
      str4: String = Strings.UCase(str3);
      DrawMod.DrawTextColouredMarc( g, str4, this.game.MarcFont13, num1 + 70, 30, Color.White);
      SizeF sizeF3 = g.MeasureString(str4, this.game.MarcFont13);
      if (this.game.Data.UnitObj[unr].HQ > -1 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | this.game.Data.Round == 0)
      {
        trect2 = new Rectangle(num1 + 70, 30,  Math.Round((double) sizeF3.Width), 15);
        trect1 = trect2;
        this.AddMouse( trect1, "HQ", "Click to jump to its map location.", 1);
      }
      this.game.CustomBitmapObj.DrawUnit(unr, true, g, num1 + 25, 57, true);
      if (this.game.Data.UnitObj[unr].IsHQ)
      {
        if (this.game.Data.UnitObj[unr].IsHQ & (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | this.game.Data.Round < 1))
        {
          trect2 = new Rectangle(num1 + 25, 57, 38, 38);
          trect1 = trect2;
          this.AddMouse( trect1, "HQ COLOR", "Click to change color of HQ", 5);
        }
        else
        {
          trect2 = new Rectangle(num1 + 25, 57, 38, 38);
          trect1 = trect2;
          this.AddMouse( trect1, "HQ COLOR", "You can only change the color of your own HQ units.");
        }
      }
      else
      {
        trect2 = new Rectangle(num1 + 25, 57, 38, 38);
        trect1 = trect2;
        this.AddMouse( trect1, "", "You can only change the color of HQs.");
      }
      int num5 = 72;
      int num6 = num1 + 72 - 35 + 4;
      DrawMod.DrawBlock( g, num1 + num5, 50, 247, 2,  this.game.MarcCol3.R,  this.game.MarcCol3.G,  this.game.MarcCol3.B,  byte.MaxValue);
      for (; num5 < 300; num5 += 35)
        DrawMod.DrawBlockGradient2( g, num1 + num5, 51, 2, 51, this.game.MarcCol3, this.game.MarcCol2);
      str5: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(unr)));
      if (reconMinusHide.x == 2)
        str5 = "?";
      if (reconMinusHide.x < 2)
        str5 = "?";
      SizeF sizeF4 = g.MeasureString(str5, this.game.MarcFont8b);
      int x3 =  Math.Round((double) ((float) (num1 + 72 + 0 + 18) - sizeF4.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str5, this.game.MarcFont8b, x3, 78, Color.White);
      int num7 = num6 + 35;
       Graphics local11 =  g;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.ICONAP1);
       Bitmap local12 =  bitmap3;
      int x4 = num7;
      DrawMod.DrawSimple( local11,  local12, x4, 54);
      trect2 = new Rectangle(num7 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "ACTION POINTS", "Neccessary for movement and combat.", 0);
      str6: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unr].SupplyConsume));
      if (reconMinusHide.x == 2)
        str6 = "?";
      if (reconMinusHide.x < 2)
        str6 = "?";
      SizeF sizeF5 = g.MeasureString(str6, this.game.MarcFont8b);
      int x5 =  Math.Round((double) ((float) (num1 + 72 + 35 + 18) - sizeF5.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str6, this.game.MarcFont8b, x5, 78, Color.White);
      int num8 = num7 + 35;
       Graphics local13 =  g;
      Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.ICONSU1);
       Bitmap local14 =  bitmap4;
      int x6 = num8;
      DrawMod.DrawSimple( local13,  local14, x6, 54);
      trect2 = new Rectangle(num8 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "SUPPLY CONSUMPTION", "Percentage of supply consumed for optimal functioning.", 0);
      int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(unr);
      int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
      int num9 =  Math.Round((double) this.game.Data.RuleVar[307]);
      int startPower = this.game.HandyFunctionsObj.GetStartPower(unr);
      int num10 =  Math.Round((double) startPower * ((double) breakPercent / 100.0));
      str7: String = startPower != 0 ? Conversions.ToString(Math.Min(100,  Math.Round((double) powerPtsAbsolute / (double) startPower * 100.0))) : "100";
      if (reconMinusHide.x == 2)
        str7 = "?";
      if (reconMinusHide.x < 2)
        str7 = "?";
      SizeF sizeF6 = g.MeasureString(str7, this.game.MarcFont8b);
      int x7 =  Math.Round((double) ((float) (num1 + 72 + 70 + 18) - sizeF6.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str7, this.game.MarcFont8b, x7, 78, Color.White);
      int num11 = num8 + 35;
       Graphics local15 =  g;
      Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.ICONIN1);
       Bitmap local16 =  bitmap5;
      int x8 = num11;
      DrawMod.DrawSimple( local15,  local16, x8, 54);
      trect2 = new Rectangle(num11 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "INTEGRITY", "If unit drops below " + Strings.Trim(Conversion.Str((object) breakPercent)) + "%\r\nit can break.", 0);
      int num12 = this.game.HandyFunctionsObj.GetAverageRdn(unr);
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(unr, num12);
        float num13 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num14 = (float) ((1.0 - (double) num13) * 2.0);
        float num15 = VBMath.Rnd() * num14 + num13;
        num12 =  Math.Round((double) Conversion.Int((float) num12 * num15));
        if (num12 < 0)
          num12 = 0;
        if (num12 > 100)
          num12 = 100;
      }
      str8: String = Conversion.Str((object) num12);
      if (reconMinusHide.x < 2)
        str8 = "?";
      SizeF sizeF7 = g.MeasureString(str8, this.game.MarcFont8b);
      int x9 =  Math.Round((double) ((float) (num1 + 72 + 105 + 18) - sizeF7.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str8, this.game.MarcFont8b, x9, 78, Color.White);
      int num16 = num11 + 35;
       Graphics local17 =  g;
      Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.ICONRD1);
       Bitmap local18 =  bitmap6;
      int x10 = num16;
      DrawMod.DrawSimple( local17,  local18, x10, 54);
      trect2 = new Rectangle(num16 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "READINESS", "Vital for offensive combat.", 0);
      int num17 = this.game.HandyFunctionsObj.GetAverageXp(unr);
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(unr, num17);
        float num18 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num19 = (float) ((1.0 - (double) num18) * 2.0);
        float num20 = VBMath.Rnd() * num19 + num18;
        num17 =  Math.Round((double) Conversion.Int((float) num17 * num20));
        if (num17 < 0)
          num17 = 0;
        if (num17 > 100)
          num17 = 100;
      }
      str9: String = Conversion.Str((object) num17);
      if (reconMinusHide.x < 2)
        str9 = "?";
      SizeF sizeF8 = g.MeasureString(str9, this.game.MarcFont8b);
      int x11 =  Math.Round((double) ((float) (num1 + 72 + 140 + 18) - sizeF8.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str9, this.game.MarcFont8b, x11, 78, Color.White);
      int num21 = num16 + 35;
       Graphics local19 =  g;
      Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.ICONEX1);
       Bitmap local20 =  bitmap7;
      int x12 = num21;
      DrawMod.DrawSimple( local19,  local20, x12, 54);
      trect2 = new Rectangle(num21 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "EXPERIENCE", "Improves combat stats.", 0);
      int num22 = this.game.HandyFunctionsObj.GetAverageMor(unr);
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(unr, num22);
        float num23 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num24 = (float) ((1.0 - (double) num23) * 2.0);
        float num25 = VBMath.Rnd() * num24 + num23;
        num22 =  Math.Round((double) Conversion.Int((float) num22 * num25));
        if (num22 < 0)
          num22 = 0;
        if (num22 > 100)
          num22 = 100;
      }
      str10: String = Conversion.Str((object) num22);
      if (reconMinusHide.x < 2)
        str10 = "?";
      SizeF sizeF9 = g.MeasureString(str10, this.game.MarcFont8b);
      int x13 =  Math.Round((double) ((float) (num1 + 72 + 175 + 18) - sizeF9.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str10, this.game.MarcFont8b, x13, 78, Color.White);
      int num26 = num21 + 35;
       Graphics local21 =  g;
      Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.ICONMO1);
       Bitmap local22 =  bitmap8;
      int x14 = num26;
      DrawMod.DrawSimple( local21,  local22, x14, 54);
      trect2 = new Rectangle(num26 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "MORALE", "High morale reduces chance on unit panicking.\r\nBase morale is " + this.game.HandyFunctionsObj.GetAverageBaseMor(unr).ToString() + ".", 0);
      int num27 = this.game.HandyFunctionsObj.GetAverageEntrench(unr);
      if (reconMinusHide.x == 2)
      {
        this.game.HandyFunctionsObj.RandomizeForUnit(unr, num27);
        float num28 = (float) reconMinusHide.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
        float num29 = (float) ((1.0 - (double) num28) * 2.0);
        float num30 = VBMath.Rnd() * num29 + num28;
        num27 =  Math.Round((double) Conversion.Int((float) num27 * num30));
        if (num27 < 0)
          num27 = 0;
        if (num27 > 999)
          num27 = 999;
      }
      str11: String = Conversion.Str((object) num27);
      if (reconMinusHide.x < 2)
        str11 = "?";
      SizeF sizeF10 = g.MeasureString(str11, this.game.MarcFont8b);
      int x15 =  Math.Round((double) ((float) (num1 + 72 + 210 + 18) - sizeF10.Width / 2f));
      DrawMod.DrawTextColouredMarc( g, str11, this.game.MarcFont8b, x15, 78, Color.White);
      int num31 = num26 + 35;
       Graphics local23 =  g;
      Bitmap bitmap9 = BitmapStore.GetBitmap(this.game.ICONEN1);
       Bitmap local24 =  bitmap9;
      int x16 = num31;
      DrawMod.DrawSimple( local23,  local24, x16, 54);
      trect2 = new Rectangle(num31 - 4, 50, 35, 50);
      trect1 = trect2;
      this.AddMouse( trect1, "ENTRENCHMENT", "Improves defensive combat stats.", 0);
    }

    pub void PopUpRefresh()
    {
      this.game.EditObj.HandCard = -1;
      if (this.game.EditObj.UnitSelected > -1 && this.cardsel >= 5000 & this.cardsel < 7000 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].HandCardCounter < this.cardsel - 5000)
        this.cardsel = -1;
      if (!((double) this.game.Data.RuleVar[701] >= 1.0 & this.game.EditObj.UnitSelected > -1))
        return;
      this.game.EditObj.udsReturnFromPopup = true;
    }

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
            if (!this.game.EditObj.TipButton & Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
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
          break;
        }
      }
    }

    pub HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      windowReturnClass2: WindowReturnClass = base.HandleMouseMove(x, y);
      bool flag = false;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.MouseData[mouseCounter] >= 7000 & this.MouseData[mouseCounter] < 9000)
          {
            if (this.cardhover == this.MouseData[mouseCounter])
            {
              flag = true;
            }
            else
            {
              this.cardhover = this.MouseData[mouseCounter];
              this.dostuff();
              windowReturnClass2.SetFlag(true);
              flag = true;
            }
          }
          else if (this.MouseData[mouseCounter] >= 5000 & this.MouseData[mouseCounter] < 7000)
          {
            if (this.cardhover == this.MouseData[mouseCounter])
            {
              flag = true;
            }
            else
            {
              this.cardhover = this.MouseData[mouseCounter];
              this.dostuff();
              windowReturnClass2.SetFlag(true);
              flag = true;
            }
          }
        }
      }
      if (!flag & this.cardhover > -1)
      {
        this.cardhover = -1;
        this.dostuff();
        windowReturnClass2.SetFlag(true);
      }
      return windowReturnClass2;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (this.game.EditObj.BattleTimerActive)
        return windowReturnClass1;
      int mouseCounter = this.MouseCounter;
      for (int index1 = 0; index1 <= mouseCounter; index1 += 1)
      {
        if (this.MouseData[index1] > 0 && x > this.MouseRect[index1].X & x < this.MouseRect[index1].X + this.MouseRect[index1].Width && y > this.MouseRect[index1].Y & y < this.MouseRect[index1].Y + this.MouseRect[index1].Height & b == 1)
        {
          if (this.MouseData[index1] >= 9999000)
          {
            if (this.game.Data.Round == 0 | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime))
            {
              windowReturnClass1.AddCommand(4, 68);
              if (this.game.EditObj.SFSelected == this.MouseData[index1] - 9999000)
                this.game.EditObj.SFSelected = -1;
              else
                this.game.EditObj.SFSelected = this.MouseData[index1] - 9999000;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
          }
          else if (this.MouseData[index1] >= 99000 & this.game.EditObj.UnitSelected > -1)
          {
            this.game.EditObj.SFSelected = -1;
            int sfCount = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount;
            for (int index2 = 0; index2 <= sfCount; index2 += 1)
            {
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFList[index2] == this.MouseData[index1] - 99000)
                this.game.EditObj.SFSelected = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFList[index2];
            }
            if (this.game.EditObj.SFSelected > -1)
            {
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EditObj.UDSAddInput("SFNR", this.game.EditObj.SFSelected);
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 564, 0, 0));
              this.formref.Cursor = Cursors.Default;
              this.game.EditObj.PopupValue = 21;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
          }
          else if (this.MouseData[index1] >= 10000 & this.MouseData[index1] < 100000)
          {
            int index3 = this.MouseData[index1] - 10000;
            if (index3 > -1)
            {
              if (index3 != this.game.EditObj.UnitSelected)
              {
                if ((double) this.game.Data.RuleVar[701] > 0.0)
                {
                  ScreenClass screeny = this.formref.Screeny;
                  System.Type type = typeof (MapWindowClass2);
                   System.Type local =  type;
                  MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                  if (!Information.IsNothing((object) window))
                  {
                    this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                    this.game.EditObj.UnitSelected = index3;
                    this.game.SelectX = this.game.Data.UnitObj[index3].X;
                    this.game.SelectY = this.game.Data.UnitObj[index3].Y;
                    windowReturnClass2: WindowReturnClass = (WindowReturnClass) window.UdsClickUnit(this.game.Data.UnitObj[index3].X, this.game.Data.UnitObj[index3].Y, this.game.Data.UnitObj[index3].Map, true);
                    windowReturnClass2.AddCommand(4, 12);
                    windowReturnClass2.AddCommand(4, 67);
                    windowReturnClass2.AddCommand(4, 68);
                    windowReturnClass2.AddCommand(4, 9);
                    this.dostuff();
                    windowReturnClass2.SetFlag(true);
                    return windowReturnClass2;
                  }
                }
                else
                {
                  this.game.EditObj.UnitSelected = index3;
                  this.game.EditObj.TempCoordList = CoordList::new();
                  this.game.HandyFunctionsObj.CenterOnXY(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y);
                  windowReturnClass1.AddCommand(4, 12);
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
                this.game.EditObj.UnitSelected = index3;
                this.game.SelectX = this.game.Data.UnitObj[index3].X;
                this.game.SelectY = this.game.Data.UnitObj[index3].Y;
                int index4;
                while (this.game.Data.MapObj[index4].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] != index3)
                {
                  int unit = this.game.Data.MapObj[index4].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
                  index4 = 0;
                  if (this.game.Data.MapObj[index4].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > 0)
                  {
                    for (int unitCounter = this.game.Data.MapObj[index4].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter; unitCounter >= 1; unitCounter += -1)
                      this.game.Data.MapObj[index4].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter] = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter - 1];
                  }
                  this.game.Data.MapObj[index4].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] = unit;
                }
                windowReturnClass1.AddCommand(4, 12);
                windowReturnClass1.AddCommand(4, 67);
                windowReturnClass1.AddCommand(4, 68);
                windowReturnClass1.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
          }
          else
          {
            if (this.MouseData[index1] >= 9000 & this.MouseData[index1] < 9999)
            {
              this.game.EditObj.PopupValue = 2;
              this.game.EditObj.HandCard = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].HandCard[this.MouseData[index1] - 9000];
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.MouseData[index1] >= 7000 & this.MouseData[index1] < 9000)
            {
              if (this.cardsel == this.MouseData[index1])
              {
                this.cardsel = -1;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              this.cardsel = this.MouseData[index1];
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.MouseData[index1] >= 5000 & this.MouseData[index1] < 7000)
            {
              if (this.cardsel == this.MouseData[index1])
              {
                this.cardsel = -1;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              this.cardsel = this.MouseData[index1];
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.MouseData[index1] >= 4000 & this.MouseData[index1] < 4020)
            {
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EditObj.UDSAddInput("AIRBRIDGENR", this.MouseData2[index1]);
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 850, 0, 0));
              this.formref.Cursor = Cursors.Default;
              this.game.EditObj.PopupValue = 21;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.MouseData[index1] == 50)
            {
              this.game.EditObj.PopupValue = 4;
              this.game.EditObj.HandCard = 0;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.MouseData[index1] == 40)
            {
              if (Interaction.MsgBox((object) "Renaming might cause double names or other confusion. Are you sure you want to rename the unit?", MsgBoxStyle.YesNo, (object) "Rename a Unit") == MsgBoxResult.Yes)
              {
                int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
                str1: String = Interaction.InputBox("Give New Name for Unit", "Rename a Unit", this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name);
                if (Strings.Len(str1) > 25)
                  str1 = Strings.Left(str1, 25);
                if (Operators.CompareString(Strings.Trim(str1), "", false) != 0)
                {
                  if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1)
                    this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].Name = str1;
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name = str1;
                }
                str2: String = Interaction.InputBox("Give New Counter Text (max 5 characters)", "Rename a Unit", this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CounterString);
                if (Strings.Len(str2) > 5)
                  str2 = Strings.Left(str2, 5);
                if (Operators.CompareString(Strings.Trim(str2), "", false) != 0 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1)
                  this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CounterString = str2;
                windowReturnClass1.AddCommand(4, 12);
                windowReturnClass1.AddCommand(4, 67);
                windowReturnClass1.AddCommand(4, 68);
                windowReturnClass1.AddCommand(4, 9);
              }
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
          }
          switch (this.MouseData[index1])
          {
            case 1:
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | this.game.Data.Round == 0)
              {
                int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
                if (hq > -1 & this.game.EditObj.OrderType == 0)
                {
                  if (this.game.Data.UnitObj[hq].X > -1)
                  {
                    this.game.SelectX = this.game.Data.UnitObj[hq].X;
                    this.game.SelectY = this.game.Data.UnitObj[hq].Y;
                  }
                  else
                  {
                    this.game.SelectX = this.game.Data.UnitObj[this.game.Data.UnitObj[hq].OnBoard].X;
                    this.game.SelectY = this.game.Data.UnitObj[this.game.Data.UnitObj[hq].OnBoard].Y;
                  }
                  int index5;
                  while (this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] != hq)
                  {
                    int unit = this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
                    index5 = 0;
                    if (this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > 0)
                    {
                      for (int unitCounter = this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter; unitCounter >= 1; unitCounter += -1)
                        this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter] = this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter - 1];
                    }
                    this.game.Data.MapObj[index5].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] = unit;
                  }
                  this.game.EditObj.UnitSelected = hq;
                  this.game.HandyFunctionsObj.SetcornerXY2();
                  this.game.EditObj.TempCoordList = CoordList::new();
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 68);
                  windowReturnClass1.AddCommand(4, 9);
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                continue;
              }
              continue;
            case 2:
              int unitCounter1 = this.game.Data.UnitCounter;
              for (int index6 = 0; index6 <= unitCounter1; index6 += 1)
              {
                if (this.game.Data.UnitObj[index6].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & (this.game.Data.Round == 0 | this.game.Data.UnitObj[index6].Regime == this.game.Data.Turn))
                {
                  if (this.game.Data.UnitObj[index6].SODefendPercent == 0)
                    this.game.Data.UnitObj[index6].SODefendPercent = 25;
                  else if (this.game.Data.UnitObj[index6].SODefendPercent == 25)
                    this.game.Data.UnitObj[index6].SODefendPercent = 50;
                  else if (this.game.Data.UnitObj[index6].SODefendPercent == 50)
                    this.game.Data.UnitObj[index6].SODefendPercent = 75;
                  else
                    this.game.Data.UnitObj[index6].SODefendPercent = 0;
                }
              }
              int unitCounter2 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter2; unr += 1)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.game.EditObj.UnitSelected))
                  this.game.Data.UnitObj[unr].SODefendPercent = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent;
              }
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 3:
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
              {
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent == 50)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent = 75;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent == 75)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent = 100;
                else
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent = 50;
              }
              else
              {
                int unitCounter3 = this.game.Data.UnitCounter;
                for (int index7 = 0; index7 <= unitCounter3; index7 += 1)
                {
                  if (this.game.Data.UnitObj[index7].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & (this.game.Data.Round == 0 | this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn))
                  {
                    if (this.game.Data.UnitObj[index7].SOSupReqPercent == 50)
                      this.game.Data.UnitObj[index7].SOSupReqPercent = 75;
                    else if (this.game.Data.UnitObj[index7].SOSupReqPercent == 75)
                      this.game.Data.UnitObj[index7].SOSupReqPercent = 100;
                    else
                      this.game.Data.UnitObj[index7].SOSupReqPercent = 50;
                  }
                }
              }
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 4:
              if (this.game.Data.Round == 0 | this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime && this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
              {
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 25)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 100;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 50)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 25;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 75)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 50;
                else
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 75;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              continue;
            case 5:
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
              {
                ColorDialog colorDialog = ColorDialog::new();
                colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Red, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Green, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Blue);
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Blue =  colorDialog.Color.B;
                  UnitClass unitClass1 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                  Color color = colorDialog.Color;
                  int g =  color.G;
                  unitClass1.Green = g;
                  UnitClass unitClass2 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                  color = colorDialog.Color;
                  int r =  color.R;
                  unitClass2.Red = r;
                }
                this.dostuff();
                windowReturnClass1.AddCommand(4, 12);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              continue;
            case 6:
              if (this.game.Data.Round == 0 | this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime)
              {
                int unitCounter4 = this.game.Data.UnitCounter;
                for (int index8 = 0; index8 <= unitCounter4; index8 += 1)
                {
                  if (this.game.Data.UnitObj[index8].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & (this.game.Data.Round == 0 | this.game.Data.UnitObj[index8].Regime == this.game.Data.Turn))
                  {
                    if (this.game.Data.UnitObj[index8].SOReplacementPercent == 0)
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 100;
                    else if (this.game.Data.UnitObj[index8].SOReplacementPercent == 25)
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 0;
                    else if (this.game.Data.UnitObj[index8].SOReplacementPercent == 50)
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 25;
                    else if (this.game.Data.UnitObj[index8].SOReplacementPercent == 75)
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 50;
                    else if (this.game.Data.UnitObj[index8].SOReplacementPercent == 100)
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 999;
                    else
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 75;
                    if ((double) this.game.Data.RuleVar[977] > 0.0 && this.game.Data.UnitObj[index8].SOReplacementPercent == 0)
                      this.game.Data.UnitObj[index8].SOReplacementPercent = 100;
                  }
                }
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              continue;
            case 101:
              this.game.EditObj.SetSubViewMode = 0;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 102:
              this.game.EditObj.SetSubViewMode = 1;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 103:
              this.game.EditObj.SetSubViewMode = 2;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 104:
              this.game.EditObj.SetSubViewMode = 3;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 121:
              if (this.game.EditObj.se1_SelectAssetButton == this.MouseData2[index1])
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ASSETID", this.game.EditObj.se1_SelectAssetButton);
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 561, 0, 0));
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass1.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              this.game.EditObj.se1_SelectAssetButton = this.MouseData2[index1];
              this.dostuff();
              windowReturnClass1.AddCommand(4, 12);
              windowReturnClass1.AddCommand(4, 67);
              windowReturnClass1.AddCommand(4, 68);
              windowReturnClass1.AddCommand(4, 9);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            case 201:
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EventRelatedObj.SetUDSKey("CHARID", this.MouseData2[index1]);
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 531, 0, 0));
              this.formref.Cursor = Cursors.Default;
              this.game.EditObj.PopupValue = 21;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            default:
              continue;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index9 = 0; index9 <= subPartCounter; index9 += 1)
        {
          if (x > this.SubPartX[index9] & x < this.SubPartX[index9] + this.SubPartW[index9] && y > this.SubPartY[index9] & y < this.SubPartY[index9] + this.SubPartH[index9])
          {
            int regButtonCounter = this.regButtonCounter;
            for (int index10 = 0; index10 <= regButtonCounter; index10 += 1)
            {
              if (this.regButton[index10] == this.SubPartID[index9] && this.regButtonData[index10] == 202)
              {
                if (this.tempRegType == 1)
                  this.game.EditObj.se1_CardsCategory = 1;
                else
                  this.game.EditObj.se1_CardsCategory = 2;
                this.game.EditObj.se1_CardsTarget = this.tempRegId;
                this.game.EditObj.se1_CardsCard = -1;
                this.game.EditObj.se1_CardsPage = 1;
                if (this.game.EditObj.SetViewMode2 != 5)
                {
                  this.game.EditObj.SetViewMode2 = 5;
                  if (this.game.ScreenHeight < 920)
                  {
                    this.game.EditObj.GuiDown = true;
                    windowReturnClass1.AddCommand(3, 11);
                  }
                  else
                  {
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(1, 9);
                    windowReturnClass1.AddCommand(7, 12);
                    windowReturnClass1.AddCommand(2, 74);
                  }
                }
                else
                {
                  windowReturnClass1.AddCommand(1, 9);
                  windowReturnClass1.AddCommand(2, 74);
                }
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            int zoneButtonCounter = this.zoneButtonCounter;
            for (int index11 = 0; index11 <= zoneButtonCounter; index11 += 1)
            {
              if (this.zoneButton[index11] == this.SubPartID[index9])
              {
                if (this.zoneButtonData[index11] >= 1 & this.zoneButtonData[index11] < 200)
                {
                  this.game.EditObj.se1_SelectZoneButton = this.zoneButtonData[index11];
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.zoneButtonData[index11] == 201)
                {
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.UDSClearInput();
                  this.game.EventRelatedObj.SetUDSKey("CHOICE", this.tempCharId);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 546, 0, 0));
                  this.formref.Cursor = Cursors.Default;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.zoneButtonData[index11] == 202)
                {
                  this.game.EditObj.se1_CardsCategory = 7;
                  this.game.EditObj.se1_CardsTarget = this.tempZoneId;
                  this.game.EditObj.se1_CardsCard = -1;
                  this.game.EditObj.se1_CardsPage = 1;
                  if (this.game.EditObj.SetViewMode2 != 5)
                  {
                    this.game.EditObj.SetViewMode2 = 5;
                    if (this.game.ScreenHeight < 920)
                    {
                      this.game.EditObj.GuiDown = true;
                      windowReturnClass1.AddCommand(3, 11);
                    }
                    else
                    {
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(1, 9);
                      windowReturnClass1.AddCommand(7, 12);
                      windowReturnClass1.AddCommand(2, 74);
                    }
                  }
                  else
                  {
                    windowReturnClass1.AddCommand(1, 9);
                    windowReturnClass1.AddCommand(2, 74);
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
              }
            }
            int assetButtonCounter = this.assetButtonCounter;
            for (int index12 = 0; index12 <= assetButtonCounter; index12 += 1)
            {
              if (this.assetButton[index12] == this.SubPartID[index9])
              {
                if (this.assetButtonData[index12] >= 51 & this.assetButtonData[index12] < 99)
                {
                  this.game.EditObj.se1_AssetPage = this.assetButtonData[index12] - 50;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 11)
                {
                  this.game.EditObj.se1_AssetCategory1 = 1;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 12)
                {
                  this.game.EditObj.se1_AssetCategory1 = 2;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 13)
                {
                  if (this.game.EditObj.se1_AssetCategory2 == 1)
                    this.game.EditObj.se1_AssetCategory2 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory2 = 1;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 14)
                {
                  if (this.game.EditObj.se1_AssetCategory2 == 2)
                    this.game.EditObj.se1_AssetCategory2 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory2 = 2;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 15)
                {
                  if (this.game.EditObj.se1_AssetCategory2 == 3)
                    this.game.EditObj.se1_AssetCategory2 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory2 = 3;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 22)
                {
                  if (this.game.EditObj.se1_SelectAssetButton < 1)
                  {
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.UDSClearInput();
                  this.game.EventRelatedObj.SetUDSKey("ASSETID", this.game.EditObj.se1_SelectAssetButton);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 569, 0, 0));
                  this.formref.Cursor = Cursors.Default;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 25)
                {
                  if (this.game.EditObj.se1_SelectAssetButton < 1)
                  {
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 25;
                  this.dostuff();
                  if (this.orderfeedbackString.Length > 1)
                  {
                    this.game.EditObj.QuestionText = this.orderfeedbackString;
                    this.game.EditObj.AnswerCount = 1;
                    this.game.EditObj.AnswerText[1] = "OK";
                    this.game.EditObj.AnswerTextMouseOver[1] = "Click to continue";
                    DrawMod.TGame.EditObj.PopupValue = 10;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 21)
                {
                  if (this.game.EditObj.se1_SelectAssetButton < 1)
                  {
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 21;
                  this.dostuff();
                  if (this.orderfeedbackString.Length > 1)
                  {
                    this.game.EditObj.QuestionText = this.orderfeedbackString;
                    this.game.EditObj.AnswerCount = 1;
                    this.game.EditObj.AnswerText[1] = "OK";
                    this.game.EditObj.AnswerTextMouseOver[1] = "Click to continue";
                    DrawMod.TGame.EditObj.PopupValue = 10;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 23)
                {
                  if (this.game.EditObj.se1_SelectAssetButton < 1)
                  {
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 23;
                  this.dostuff();
                  if (this.orderfeedbackString.Length > 1)
                  {
                    this.game.EditObj.QuestionText = this.orderfeedbackString;
                    this.game.EditObj.AnswerCount = 1;
                    this.game.EditObj.AnswerText[1] = "OK";
                    this.game.EditObj.AnswerTextMouseOver[1] = "Click to continue";
                    DrawMod.TGame.EditObj.PopupValue = 10;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] >= 2000 & this.assetButtonData[index12] <= 2100)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = this.assetButtonData[index12];
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 24)
                {
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.UDSClearInput();
                  this.game.EventRelatedObj.SetUDSKey("ASSETID", this.game.EditObj.se1_SelectAssetButton);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 561, 0, 0));
                  this.formref.Cursor = Cursors.Default;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 31)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 31;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 32)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 32;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index12] == 33)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 33;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
              }
            }
            int unitButtonCounter = this.unitButtonCounter;
            for (int index13 = 0; index13 <= unitButtonCounter; index13 += 1)
            {
              if (this.unitButton[index13] == this.SubPartID[index9])
              {
                if (this.unitButtonData[index13] >= 1 & this.unitButtonData[index13] < 50)
                {
                  this.game.EditObj.se1_SelectUnitButton = this.unitButtonData[index13];
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.unitButtonData[index13] >= 51 & this.unitButtonData[index13] < 60)
                {
                  this.game.EditObj.se1_UnitPage = this.unitButtonData[index13] - 50;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.unitButtonData[index13] == 202)
                {
                  if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].Type == 5)
                    this.game.EditObj.se1_CardsCategory = 6;
                  else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].Type < 5)
                    this.game.EditObj.se1_CardsCategory = 9;
                  this.game.EditObj.se1_CardsTarget = this.game.EditObj.UnitSelected;
                  this.game.EditObj.se1_CardsCard = -1;
                  this.game.EditObj.se1_CardsPage = 1;
                  if (this.game.EditObj.SetViewMode2 != 5)
                  {
                    this.game.EditObj.SetViewMode2 = 5;
                    if (this.game.ScreenHeight < 920)
                    {
                      this.game.EditObj.GuiDown = true;
                      windowReturnClass1.AddCommand(3, 11);
                    }
                    else
                    {
                      windowReturnClass1.AddCommand(4, 67);
                      windowReturnClass1.AddCommand(1, 9);
                      windowReturnClass1.AddCommand(7, 12);
                      windowReturnClass1.AddCommand(2, 74);
                    }
                  }
                  else
                  {
                    windowReturnClass1.AddCommand(1, 9);
                    windowReturnClass1.AddCommand(2, 74);
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.unitButtonData[index13] == 81 && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | this.game.Data.Round == 0)
                {
                  int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
                  this.game.EditObj.OrderType = 0;
                  this.game.HandyFunctionsObj.RedimTempValue(9999);
                  if (hq > -1)
                  {
                    if (this.game.Data.UnitObj[hq].X > -1)
                    {
                      this.game.SelectX = this.game.Data.UnitObj[hq].X;
                      this.game.SelectY = this.game.Data.UnitObj[hq].Y;
                    }
                    else
                    {
                      this.game.SelectX = this.game.Data.UnitObj[this.game.Data.UnitObj[hq].OnBoard].X;
                      this.game.SelectY = this.game.Data.UnitObj[this.game.Data.UnitObj[hq].OnBoard].Y;
                    }
                    int index14;
                    while (this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] != hq)
                    {
                      int unit = this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
                      index14 = 0;
                      if (this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > 0)
                      {
                        for (int unitCounter = this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter; unitCounter >= 1; unitCounter += -1)
                          this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter] = this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitList[unitCounter - 1];
                      }
                      this.game.Data.MapObj[index14].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0] = unit;
                    }
                    this.game.EditObj.UnitSelected = hq;
                    this.game.HandyFunctionsObj.SetcornerXY2();
                    this.game.EditObj.TempCoordList = CoordList::new();
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.AddCommand(4, 9);
                    this.dostuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                }
                if (this.unitButtonData[index13] == 201)
                {
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.UDSClearInput();
                  this.game.EventRelatedObj.SetUDSKey("CHOICE", this.tempCharId);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 546, 0, 0));
                  this.formref.Cursor = Cursors.Default;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
              }
            }
            int num1 = this.SubPartID[index9];
            if (num1 == this.extraTabId)
            {
              if ((double) this.game.Data.RuleVar[440] != 1.0)
                return windowReturnClass1;
              int enr = this.SubPartList[index9].Click(x - this.SubPartX[index9], y - this.SubPartY[index9]);
              if (enr > 0)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                int areaX = this.game.EditObj.AreaX;
                int areaY = this.game.EditObj.AreaY;
                this.game.EditObj.AreaX = this.game.SelectX;
                this.game.EditObj.AreaY = this.game.SelectY;
                this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
                this.game.EditObj.AreaX = areaX;
                this.game.EditObj.AreaY = areaY;
                this.formref.Cursor = Cursors.Default;
                int num2 =  Math.Round(Conversion.Val(this.game.EventRelatedObj.CheckUDSKey("POPUP", "", 0, 0)));
                if (this.game.EditObj.interfaceCue == 2 & num2 < 1)
                {
                  this.game.EditObj.interfaceCue = 0;
                  if (this.game.EditObj.SetViewMode2 > 100)
                  {
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 114);
                    windowReturnClass1.AddCommand(4, 116);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.EditObj.interfaceCue == 3 & num2 < 1)
                {
                  this.game.EditObj.interfaceCue = 0;
                  this.RemoveSubPart(this.extraTabId);
                  int num3 =  Math.Round((double) (this.w - 1024) / 2.0);
                  let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, 1280, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, num3 - 128, 7, true);
                  this.extraTabId = this.AddSubPart( tsubpart, num3 - 128, 7, 1280, 210, 1);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.EditObj.interfaceCue == 4 & num2 < 1)
                {
                  this.game.EditObj.interfaceCue = 0;
                  this.game.HandyFunctionsObj.CenterOnXY(this.game.SelectX, this.game.SelectY, true);
                  this.RemoveSubPart(this.extraTabId);
                  int num4 =  Math.Round((double) (this.w - 1024) / 2.0);
                  let mut tsubpart: SubPartClass =  new UDSPartClass(this.game, 1280, 210, this.game.EditObj.UDSbottomText,  this.OwnBitmap, num4 - 128, 7, true);
                  this.extraTabId = this.AddSubPart( tsubpart, num4 - 128, 7, 1280, 210, 1);
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 68);
                  windowReturnClass1.AddCommand(4, 9);
                  return windowReturnClass1;
                }
                if (num2 == 2)
                {
                  this.game.EditObj.QuestionText = "Road to where?";
                  this.game.EditObj.DoCardSlot = -1;
                  this.game.EditObj.HandCard = -1;
                  this.game.EditObj.PopupValue = 1;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.game.EditObj.UDSpopupText.Length > 1)
                {
                  this.game.EditObj.udsLastCalledPopupEventNr = enr;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                this.game.EditObj.interfaceCue = 0;
              }
              else if (this.game.EditObj.interfaceCue == 2)
              {
                this.game.EditObj.interfaceCue = 0;
                if (this.game.EditObj.SetViewMode2 <= 100)
                {
                  windowReturnClass1.AddCommand(4, 12);
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.AddCommand(4, 68);
                  windowReturnClass1.AddCommand(4, 69);
                  windowReturnClass1.AddCommand(4, 9);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
              }
              this.SubPartFlag[index9] = true;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.rlistid)
            {
              int num5 = this.SubPartList[index9].Click(x - this.SubPartX[index9], y - this.SubPartY[index9]);
              if (num5 > -1)
              {
                if (num5 == 99999)
                  num5 = -1;
                if (this.viewingtrooptab)
                {
                  this.detailnr = num5;
                  this.DoRefresh();
                }
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.rlist4id)
            {
              int num6 = this.SubPartList[index9].Click(x - this.SubPartX[index9], y - this.SubPartY[index9]);
              if (num6 > -1)
              {
                if (num6 == 99999)
                  num6 = -1;
                if (this.viewingtrooptab)
                {
                  this.detailnr = num6;
                  this.DoRefresh();
                }
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.rlist5id)
            {
              int num7 = this.SubPartList[index9].Click(x - this.SubPartX[index9], y - this.SubPartY[index9]);
              if (num7 > -1)
              {
                if (num7 == 99999)
                  num7 = -1;
                if (this.viewingtrooptab)
                {
                  this.detailnr = num7;
                  this.DoRefresh();
                }
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.rlist2id)
            {
              int num8 = this.SubPartList[index9].Click(x - this.SubPartX[index9], y - this.SubPartY[index9]);
              if (this.viewingtrooptab & num8 > -1)
              {
                this.game.EditObj.SFSelected = num8;
                this.detailnr2 = num8;
                DrawMod.TGame.EditObj.PopupValue = 6;
                windowReturnClass1.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass1.SetFlag(true);
              }
              this.detailnr2Top = ((ListSubPartClass) this.SubPartList[index9]).TopItem;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.rlist3id)
            {
              int num9 = this.SubPartList[index9].Click(x - this.SubPartX[index9], y - this.SubPartY[index9]);
              if (num9 > -1)
              {
                if (num9 == 99999)
                  num9 = -1;
                if (this.viewingtrooptab)
                {
                  this.detailnr3 = num9;
                  this.DoRefresh();
                }
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 != this.playcardid)
              return windowReturnClass1;
            this.game.EditObj.HandCard = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].HandCard[this.cardsel - 5000];
            int num10 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].HandCard[this.cardsel - 5000];
            this.game.EditObj.PopupValue = 2;
            windowReturnClass1.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (Information.IsNothing((object) this.game.EditObj.UDSpushedPopupText) || this.game.EditObj.UDSpushedPopupText.Length <= 1)
        return windowReturnClass;
      this.game.EditObj.UDSpopupText = this.game.EditObj.UDSpushedPopupText;
      this.game.EditObj.UDSpushedPopupText = "";
      this.game.EditObj.PopupValue = 21;
      windowReturnClass.AddCommand(5, 14);
      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }
  }
}
