// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RightSideBar
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class RightSideBar : WindowClass
  {
     int hideId;
     int Info1Id;
     int info2id;
     int info3id;
     int but1id;
     int but2id;
     int but3id;
     int but1;
     int but2;
     int but3;
     int but4;
     int but5;
     int but6;
     int but7;
     int but8;
     int but9;
     int but10;
     int but11;
     int w;
     int h;
     int currentShqNr;
     int profId;
     string cacheList;
     int MouseOverWhichTab;
     int orderReplId;
     int orderRepl2Id;
     int orderAmmoId;
     int orderTradeId;
     int orderChangeShqId;
     int orderProduceUnitId;
     int orderColonizeId;
     int orderNewAssetId;
     int orderNewZoneId;
     int orderMoreId;
     int orderChangeId;
     int orderTransferId;
     int orderBattlegroupId2;
     int orderBattlegroupId;
     int orderUnitNr;
     int orderShqNr;
     int orderZoneNr;
     ListClass rlistobj;
     int rlistid;
     int layerLog1;
     int layerLog2;
     int layerLog3;
     int layerLog4;
     int layerLog5;
     int layerUnit;
     int layerLabel;
     int layerDetail;
     int layerGrid;
     int layerColor;
     int layerLisRange;
     bool initialOpeningPreviewSet;

    pub RightSideBar(
       GameClass tGame,
      int theight,
       WindowClass tLowerWindow,
       Rectangle tLowerRect)
      : base( tGame, 185, theight, 8)
    {
      this.initialOpeningPreviewSet = false;
      this.NewGfx = true;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.w = 185;
      this.h = theight;
      this.BlockBlit = true;
      this.currentShqNr = -1;
      this.dostuff();
    }

    pub HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = base.HandleMouseMove(x, y);
      let mut num: i32 = -1;
      for (let mut mouseCounter: i32 = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
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

    pub Rectangle DrawOneTab(
      Graphics g,
      int ty,
      bool active,
      bool openSideWindow,
      int iconSlot,
      bool mouseOverRightNow = false)
    {
      let mut x1: i32 = 132;
      if (openSideWindow)
        x1 = -5;
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (mouseOverRightNow)
      {
        if (!active & openSideWindow)
        {
           let mut local1: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABRIGHT);
           let mut local2: &Bitmap = &bitmap;
          rectangle1 = Rectangle::new(0, 0, 28, 70);
          let mut srcrect: &Rectangle = &rectangle1
          rectangle2 = Rectangle::new(x1 + 7, ty, 28, 70);
          let mut destrect: &Rectangle = &rectangle2
          DrawMod.DrawSimplePart2ColouredNew( local1,  local2, srcrect, destrect, 1.1f, 1.1f, 1.1f, 1f);
        }
        if (active | !openSideWindow)
        {
           let mut local3: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABRIGHT);
           let mut local4: &Bitmap = &bitmap;
          let mut x2: i32 = x1;
          let mut y: i32 = ty;
          DrawMod.Draw( local3,  local4, x2, y, 0.05f, 0.05f, 0.05f, 1f);
        }
      }
      else
      {
        if (!active & openSideWindow)
        {
           let mut local5: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABRIGHT);
           let mut local6: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(0, 0, 28, 70);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x1 + 7, ty, 28, 70);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
        }
        if (active | !openSideWindow)
        {
           let mut local7: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TABRIGHT);
           let mut local8: &Bitmap = &bitmap;
          let mut x3: i32 = x1;
          let mut y: i32 = ty;
          DrawMod.DrawSimple( local7,  local8, x3, y);
        }
      }
      if (iconSlot > -1)
      {
        if (mouseOverRightNow)
        {
          if (!active & openSideWindow)
          {
             let mut local9: &Graphics = &g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             let mut local10: &Bitmap = &bitmap;
            rectangle2 = Rectangle::new(iconSlot * 42, 32, 42, 32);
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x1 + 4, ty + 17, 42, 32);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
          }
          if (!active & !openSideWindow)
          {
             let mut local11: &Graphics = &g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             let mut local12: &Bitmap = &bitmap;
            rectangle2 = Rectangle::new(iconSlot * 42, 32, 42, 32);
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x1, ty + 17, 42, 32);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
          }
        }
        else
        {
          if (!active & openSideWindow)
          {
             let mut local13: &Graphics = &g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             let mut local14: &Bitmap = &bitmap;
            rectangle2 = Rectangle::new(iconSlot * 42, 0, 42, 32);
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x1 + 4, ty + 17, 42, 32);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local13,  local14, srcrect, destrect);
          }
          if (!active & !openSideWindow)
          {
             let mut local15: &Graphics = &g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
             let mut local16: &Bitmap = &bitmap;
            rectangle2 = Rectangle::new(iconSlot * 42, 0, 42, 32);
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x1, ty + 17, 42, 32);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local15,  local16, srcrect, destrect);
          }
        }
        if (active)
        {
           let mut local17: &Graphics = &g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
           let mut local18: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(iconSlot * 42, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x1, ty + 17, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
        }
      }
      return Rectangle::new(x1, ty, 35, 65);
    }

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      bool openingPreviewSet = this.initialOpeningPreviewSet;
      this.initialOpeningPreviewSet = true;
      if (this.game.EditObj.SetViewModeExtraNr == 3 | !openingPreviewSet && this.game.EditObj.layerLisPreview && this.game.EditObj.se1_SelectAssetButton > 0 && this.game.EditObj.layerLisOnlyAssetId > 0 && this.game.EditObj.se1_SelectAssetButton < 1000000 && this.game.EditObj.se1_SelectAssetButton != this.game.EditObj.layerLisOnlyAssetId | !openingPreviewSet)
      {
        let mut num: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 148, 0, 0))].GetData(9, this.game.EditObj.se1_SelectAssetButton, 1)));
        bool flag = false;
        if (num >= 2012 & num <= 2017)
          flag = true;
        if (num == 201)
          flag = true;
        if (num >= 311 & num <= 313)
          flag = true;
        if (num >= 941 & num <= 943)
          flag = true;
        if (num >= 3201 & num <= 3207)
          flag = true;
        if (num >= 3261 & num <= 3267)
          flag = true;
        if (flag && flag)
        {
          let mut layerLisOnlyAssetId: i32 = this.game.EditObj.layerLisOnlyAssetId;
          this.game.EditObj.layerLisOnlyAssetId = this.game.EditObj.se1_SelectAssetButton;
          let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut index1: i32 = 0; index1 <= mapWidth; index1 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
            {
              let mut index3: i32 = 0;
              do
              {
                this.game.Data.MapObj[0].HexObj[index1, index2].tempPreviewAssetLIS[index3] = 0;
                index3 += 1;
              }
              while (index3 <= 8);
            }
          }
          if (this.game.EditObj.layerLisOnlyAssetId > 0)
          {
            this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (layerLisOnlyAssetId > 0)
          {
            this.game.ProcessingObj.LIS_SetNetwork(false, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      if (this.MouseOverWhichTab <= 0 || this.MouseInThisWindow)
        return windowReturnClass;
      this.MouseOverWhichTab = 0;
      this.dostuff();
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    pub void dostuff()
    {
      libName: String = "SE_Data";
      let mut stringListById1: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
      let mut stringListById2: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      let mut stringListById3: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      let mut stringListById4: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      let mut stringListById5: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 284, 0, 0));
      let mut stringListById6: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 273, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName,  byte.MaxValue, 0, 0));
      DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 291, 0, 0));
      DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 256, 0, 0));
      Conversions.ToString(DrawMod.TGame.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[951])));
      if (this.game.SelectX == -1)
        return;
      let mut integer1: i32 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, libName, "Zones"));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById1].GetData(0, integer1, 1));
      Conversions.ToInteger(this.game.Data.StringListObj[stringListById1].GetData(0, integer1, 2));
      let mut id: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer1, 6)));
      data: String = this.game.Data.StringListObj[stringListById1].GetData(0, integer1, 7);
      let mut num1: i32 = this.game.EventRelatedObj.CheckRegimeSlot( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer1, 8))), 0, 0, 0);
      let mut index1: i32 = -1;
      if (id > 0)
        index1 = this.game.HandyFunctionsObj.GetLocationByID(id);
      let mut index2: i32 = -1;
      if (index1 > -1)
        index2 = this.game.Data.LocObj[index1].HQ;
      let mut num2: i32 = index2;
      let mut unitSelected: i32 = this.game.EditObj.UnitSelected;
      let mut index3: i32 = -1;
      let mut num3: i32 = -1;
      if (integer1 > 0)
        num3 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, integer1, 8)));
      if (unitSelected > -1)
        index3 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
      if (this.but1 > 0)
      {
        this.RemoveSubPart(this.but1);
        this.but1 = 0;
      }
      if (this.but2 > 0)
      {
        this.RemoveSubPart(this.but2);
        this.but2 = 0;
      }
      if (this.but3 > 0)
      {
        this.RemoveSubPart(this.but3);
        this.but3 = 0;
      }
      if (this.but4 > 0)
      {
        this.RemoveSubPart(this.but4);
        this.but4 = 0;
      }
      if (this.but5 > 0)
      {
        this.RemoveSubPart(this.but5);
        this.but5 = 0;
      }
      if (this.but6 > 0)
      {
        this.RemoveSubPart(this.but6);
        this.but6 = 0;
      }
      if (this.but7 > 0)
      {
        this.RemoveSubPart(this.but7);
        this.but7 = 0;
      }
      if (this.but8 > 0)
      {
        this.RemoveSubPart(this.but8);
        this.but8 = 0;
      }
      if (this.but9 > 0)
      {
        this.RemoveSubPart(this.but9);
        this.but9 = 0;
      }
      if (this.but10 > 0)
      {
        this.RemoveSubPart(this.but10);
        this.but10 = 0;
      }
      if (this.but11 > 0)
      {
        this.RemoveSubPart(this.but11);
        this.but11 = 0;
      }
      if (this.but1id > 0)
      {
        this.RemoveSubPart(this.but1id);
        this.but1id = 0;
      }
      if (this.but2id > 0)
      {
        this.RemoveSubPart(this.but2id);
        this.but2id = 0;
      }
      if (this.but3id > 0)
      {
        this.RemoveSubPart(this.but3id);
        this.but3id = 0;
      }
      if (this.game.EditObj.rightSideBarMode == 1 | this.game.ScreenHeight < 1040 && this.profId > 0)
      {
        this.RemoveSubPart(this.profId);
        this.profId = 0;
      }
      if (this.orderAmmoId > 0)
      {
        this.RemoveSubPart(this.orderAmmoId);
        this.orderAmmoId = 0;
      }
      if (this.orderTradeId > 0)
      {
        this.RemoveSubPart(this.orderTradeId);
        this.orderTradeId = 0;
      }
      if (this.orderReplId > 0)
      {
        this.RemoveSubPart(this.orderReplId);
        this.orderReplId = 0;
      }
      if (this.orderRepl2Id > 0)
      {
        this.RemoveSubPart(this.orderRepl2Id);
        this.orderRepl2Id = 0;
      }
      if (this.orderChangeShqId > 0)
      {
        this.RemoveSubPart(this.orderChangeShqId);
        this.orderChangeShqId = 0;
      }
      if (this.orderChangeId > 0)
      {
        this.RemoveSubPart(this.orderChangeId);
        this.orderChangeId = 0;
      }
      if (this.orderColonizeId > 0)
      {
        this.RemoveSubPart(this.orderColonizeId);
        this.orderColonizeId = 0;
      }
      if (this.orderMoreId > 0)
      {
        this.RemoveSubPart(this.orderMoreId);
        this.orderMoreId = 0;
      }
      if (this.orderNewAssetId > 0)
      {
        this.RemoveSubPart(this.orderNewAssetId);
        this.orderNewAssetId = 0;
      }
      if (this.orderNewZoneId > 0)
      {
        this.RemoveSubPart(this.orderNewZoneId);
        this.orderNewZoneId = 0;
      }
      if (this.orderTransferId > 0)
      {
        this.RemoveSubPart(this.orderTransferId);
        this.orderTransferId = 0;
      }
      if (this.orderBattlegroupId2 > 0)
      {
        this.RemoveSubPart(this.orderBattlegroupId2);
        this.orderBattlegroupId2 = 0;
      }
      if (this.orderBattlegroupId > 0)
      {
        this.RemoveSubPart(this.orderBattlegroupId);
        this.orderBattlegroupId = 0;
      }
      if (this.orderProduceUnitId > 0)
      {
        this.RemoveSubPart(this.orderProduceUnitId);
        this.orderProduceUnitId = 0;
      }
      if (this.layerColor > 0)
      {
        this.RemoveSubPart(this.layerColor);
        this.layerColor = 0;
      }
      if (this.layerDetail > 0)
      {
        this.RemoveSubPart(this.layerDetail);
        this.layerDetail = 0;
      }
      if (this.layerGrid > 0)
      {
        this.RemoveSubPart(this.layerGrid);
        this.layerGrid = 0;
      }
      if (this.layerUnit > 0)
      {
        this.RemoveSubPart(this.layerUnit);
        this.layerUnit = 0;
      }
      if (this.layerLabel > 0)
      {
        this.RemoveSubPart(this.layerLabel);
        this.layerLabel = 0;
      }
      if (this.layerLog1 > 0)
      {
        this.RemoveSubPart(this.layerLog1);
        this.layerLog1 = 0;
      }
      if (this.layerLog2 > 0)
      {
        this.RemoveSubPart(this.layerLog2);
        this.layerLog2 = 0;
      }
      if (this.layerLog3 > 0)
      {
        this.RemoveSubPart(this.layerLog3);
        this.layerLog3 = 0;
      }
      if (this.layerLog4 > 0)
      {
        this.RemoveSubPart(this.layerLog4);
        this.layerLog4 = 0;
      }
      if (this.layerLog5 > 0)
      {
        this.RemoveSubPart(this.layerLog5);
        this.layerLog5 = 0;
      }
      if (this.layerLisRange > 0)
      {
        this.RemoveSubPart(this.layerLisRange);
        this.layerLisRange = 0;
      }
      if (this.rlistid > 0)
      {
        this.RemoveSubPart(this.rlistid);
        this.rlistid = 0;
      }
      this.ClearMouse();
      if (index2 == -1 && unitSelected > -1)
      {
        if (this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn)
        {
          let mut historical1: i32 = this.game.Data.UnitObj[unitSelected].Historical;
          if (!this.game.Data.UnitObj[unitSelected].IsHQ | this.game.Data.HistoricalUnitObj[historical1].Type < 8)
          {
            if (index3 > -1)
            {
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index3].Historical].Type == 8)
                index2 = index3;
              else if (this.game.Data.UnitObj[index3].HQ > -1)
              {
                let mut historical2: i32 = this.game.Data.UnitObj[this.game.Data.UnitObj[index3].HQ].Historical;
                if (historical2 > -1 && this.game.Data.HistoricalUnitObj[historical2].Type == 8)
                  index2 = this.game.Data.UnitObj[index3].HQ;
              }
            }
          }
          else
            index2 = unitSelected;
        }
        num1 = this.game.Data.UnitObj[unitSelected].Regime;
      }
      if (unitSelected > -1)
      {
        let mut historical: i32 = this.game.Data.UnitObj[unitSelected].Historical;
        if (historical > -1 && this.game.Data.UnitObj[unitSelected].IsHQ & this.game.Data.HistoricalUnitObj[historical].Type == 8 && this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn)
          index2 = unitSelected;
      }
      this.currentShqNr = index2;
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      bool openSideWindow = false;
      if (this.game.EditObj.rightSideBarMode > 0)
        openSideWindow = true;
      let mut x1: i32 = this.w - 40;
      if (openSideWindow)
        x1 = this.w - 185;
      if (openSideWindow)
      {
        BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TEXTURE).RotateFlip(RotateFlipType.RotateNoneFlipX);
        for (let mut index4: i32 = 0; index4 < this.h; index4 += 185)
        {
           let mut local1: &Graphics = &objgraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TEXTURE);
           let mut local2: &Bitmap = &bitmap;
          let mut x2: i32 = x1 + 40;
          let mut y: i32 = index4;
          DrawMod.DrawSimple( local1,  local2, x2, y);
        }
        BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TEXTURE).RotateFlip(RotateFlipType.RotateNoneFlipX);
      }
      if (!openSideWindow)
      {
         let mut local3: &Graphics = &objgraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TOPSHADOWRIGHT);
         let mut local4: &Bitmap = &bitmap;
        let mut x3: i32 = this.w - 150;
        DrawMod.DrawSimple( local3,  local4, x3, 0);
      }
       let mut local5: &Graphics = &objgraphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_RIGHT);
       let mut local6: &Bitmap = &bitmap1;
      Rectangle trect1 = Rectangle::new(0, 0, 40, 128);
      let mut srcrect1: &Rectangle = &trect1
      Rectangle rectangle = Rectangle::new(x1, 0, 40, 128);
      let mut destrect1: &Rectangle = &rectangle
      DrawMod.DrawSimplePart2( local5,  local6, srcrect1, destrect1);
      for (let mut y: i32 = 128; y < this.h - 128; y += 124)
      {
         let mut local7: &Graphics = &objgraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_RIGHT);
         let mut local8: &Bitmap = &bitmap2;
        rectangle = Rectangle::new(0, 128, 40, 124);
        let mut srcrect2: &Rectangle = &rectangle
        trect1 = Rectangle::new(x1, y, 40, 124);
        let mut destrect2: &Rectangle = &trect1
        DrawMod.DrawSimplePart2( local7,  local8, srcrect2, destrect2);
      }
       let mut local9: &Graphics = &objgraphics;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_RIGHT);
       let mut local10: &Bitmap = &bitmap3;
      rectangle = Rectangle::new(0, 252, 40, 128);
      let mut srcrect3: &Rectangle = &rectangle
      trect1 = Rectangle::new(x1, this.h - 128, 40, 128);
      let mut destrect3: &Rectangle = &trect1
      DrawMod.DrawSimplePart2( local9,  local10, srcrect3, destrect3);
      let mut ty1: i32 = 90;
      Rectangle trect2 = this.DrawOneTab(objgraphics, ty1, this.game.EditObj.rightSideBarMode == 2, openSideWindow, 9, this.MouseOverWhichTab == 2);
      this.AddMouse( trect2, "ORDERS BAR", "All orders available for Units, Zones and SHQs.", 2);
      let mut ty2: i32 = ty1 + 68;
      Rectangle trect3 = this.DrawOneTab(objgraphics, ty2, this.game.EditObj.rightSideBarMode == 3, openSideWindow, 8, this.MouseOverWhichTab == 3);
      this.AddMouse( trect3, "MAP LAYERS BAR", "Toggles to add or switch off Map Layers.", 3);
      let mut ty3: i32 = ty2 + 68;
      Rectangle trect4 = this.DrawOneTab(objgraphics, ty3, this.game.EditObj.rightSideBarMode == 4, openSideWindow, 11, this.MouseOverWhichTab == 4);
      this.AddMouse( trect4, "MAP ORDER MODES", "Same as right clicking on the map, gives you access to change the 'Order Mode' for map/unit clicking you are currently using.", 4);
      let mut num4: i32 = ty3 + 68;
      if (openSideWindow)
      {
        let mut num5: i32 = this.h - 67;
         let mut local11: &Graphics = &objgraphics;
        Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_EXITRIGHT);
         let mut local12: &Bitmap = &bitmap4;
        let mut y: i32 = num5;
        DrawMod.DrawSimple( local11,  local12, 8, y);
        if (this.but1id < 1)
        {
          let mut tsubpart: SubPartClass =  new SEButtonPartClass(this.game.SE1_ARROW1, "Hide the right side bar.", 23);
          this.but1id = this.AddSubPart( tsubpart, 15, num5 + 18, 23, 35, 1);
        }
      }
      if (openSideWindow)
      {
        this.orderZoneNr = integer1;
        this.orderShqNr = index2;
        this.orderUnitNr = unitSelected;
        let mut num6: i32 = 45;
        let mut num7: i32 = 10;
        let mut num8: i32 = 0;
        let mut num9: i32 = 0;
        bool flag1 = false;
        if (this.game.ScreenHeight >= 1080)
          flag1 = true;
        if (this.game.EditObj.rightSideBarMode == 4)
        {
          tstring: String = "Order Mode";
           let mut local13: &Graphics = &objgraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
           let mut local14: &Bitmap = &bitmap5;
          let mut x4: i32 = num8 + num6;
          let mut y: i32 = num9 + num7;
          DrawMod.DrawSimple( local13,  local14, x4, y);
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring, DrawMod.TGame.MarcFont7, num8 + num6 + 65, num9 + num7 + 12, DrawMod.TGame.seColGray);
          let mut num10: i32 = 34;
          let mut num11: i32 = 32;
          if (this.game.ScreenHeight < 820)
          {
            num10 = 30;
            num11 = 28;
          }
          num8 = 1;
          let mut num12: i32 = num9 + 42;
          bool tPushed1 = false;
          let mut overlay1: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 0)
          {
            tPushed1 = true;
            overlay1 = 0;
          }
          let mut tsubpart1: SubPartClass =  new SEButtonPushPartClassWithText("Inspect", 38, tPushed1, "Allows you to just look at your units [Shortkey I]", 132, num11);
          this.but1 = this.AddSubPart( tsubpart1, num8 + num6, num12 + num7, 132, num11, overlay1);
          let mut num13: i32 = num12 + num10;
          bool tPushed2 = false;
          let mut overlay2: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 1)
          {
            tPushed2 = true;
            overlay2 = 0;
          }
          let mut tsubpart2: SubPartClass =  new SEButtonPushPartClassWithText("Move", 31, tPushed2, "Allows you to move and attack with your units [Shortkey M]", 132, num11);
          this.but2 = this.AddSubPart( tsubpart2, num8 + num6, num13 + num7, 132, num11, overlay2);
          let mut num14: i32 = num13 + num10;
          bool tPushed3 = false;
          let mut overlay3: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 48)
          {
            tPushed3 = true;
            overlay3 = 0;
          }
          let mut tsubpart3: SubPartClass =  new SEButtonPushPartClassWithText("Group Move", 31, tPushed3, "Allows you to move and attack with all units in the Hex [Shortkey G]", 132, num11);
          this.but7 = this.AddSubPart( tsubpart3, num8 + num6, num14 + num7, 132, num11, overlay3);
          let mut num15: i32 = num14 + num10;
          bool tPushed4 = false;
          let mut overlay4: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 18)
          {
            tPushed4 = true;
            overlay4 = 0;
          }
          let mut tsubpart4: SubPartClass =  new SEButtonPushPartClassWithText("Strat. Move", 25, tPushed4, "Allows your units to be transfered by your logistical network [Shortkey S]", 132, num11);
          this.but3 = this.AddSubPart( tsubpart4, num8 + num6, num15 + num7, 132, num11, overlay4);
          let mut num16: i32 = num15 + num10;
          bool tPushed5 = false;
          let mut overlay5: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 11)
          {
            tPushed5 = true;
            overlay5 = 0;
          }
          let mut tsubpart5: SubPartClass =  new SEButtonPushPartClassWithText("Ranged Att.", 39, tPushed5, "Allows your to target units with artillery or missile fire [Shortkey A]", 132, num11);
          this.but4 = this.AddSubPart( tsubpart5, num8 + num6, num16 + num7, 132, num11, overlay5);
          if (this.game.EventRelatedObj.Helper_AirEnabled())
          {
            let mut num17: i32 = num16 + num10;
            bool tPushed6 = false;
            let mut overlay6: i32 = 1;
            if (this.game.EditObj.udsUnitOrderMode == 14)
            {
              tPushed6 = true;
              overlay6 = 0;
            }
            let mut tsubpart6: SubPartClass =  new SEButtonPushPartClassWithText("Air Attack", 61, tPushed6, "Allows your to target units with airstrikes [Shortkey X]", 132, num11);
            this.but9 = this.AddSubPart( tsubpart6, num8 + num6, num17 + num7, 132, num11, overlay6);
            let mut num18: i32 = num17 + num10;
            bool tPushed7 = false;
            let mut overlay7: i32 = 1;
            if (this.game.EditObj.udsUnitOrderMode == 33)
            {
              tPushed7 = true;
              overlay7 = 0;
            }
            let mut tsubpart7: SubPartClass =  new SEButtonPushPartClassWithText("Air Recon", 63, tPushed7, "Allows your to do recon missions on Hexes [Shortkey Y]", 132, num11);
            this.but10 = this.AddSubPart( tsubpart7, num8 + num6, num18 + num7, 132, num11, overlay7);
            num16 = num18 + num10;
            bool tPushed8 = false;
            let mut overlay8: i32 = 1;
            if (this.game.EditObj.udsUnitOrderMode == 55)
            {
              tPushed8 = true;
              overlay8 = 0;
            }
            let mut tsubpart8: SubPartClass =  new SEButtonPushPartClassWithText("Air Bridge", 62, tPushed8, "Allows your to do order Air Bridges", 132, num11);
            this.but11 = this.AddSubPart( tsubpart8, num8 + num6, num16 + num7, 132, num11, overlay8);
          }
          if ((double) this.game.Data.RuleVar[702] > 0.0)
          {
            num16 += num10;
            bool tPushed9 = false;
            let mut overlay9: i32 = 1;
            if (this.game.EditObj.udsUnitOrderMode == 36)
            {
              tPushed9 = true;
              overlay9 = 0;
            }
            let mut tsubpart9: SubPartClass =  new SEButtonPushPartClassWithText("Constr. Road", 16, tPushed9, "Allows your to construct roads [Shortkey R]", 132, num11);
            this.but5 = this.AddSubPart( tsubpart9, num8 + num6, num16 + num7, 132, num11, overlay9);
          }
          let mut num19: i32 = num16 + num10;
          bool tPushed10 = false;
          let mut overlay10: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 53)
          {
            tPushed10 = true;
            overlay10 = 0;
          }
          let mut tsubpart10: SubPartClass =  new SEButtonPushPartClassWithText("Traffic Signs", 53, tPushed10, "Allows you to place and remove Traffic Signs [Shortkey T]", 132, num11);
          this.but6 = this.AddSubPart( tsubpart10, num8 + num6, num19 + num7, 132, num11, overlay10);
          let mut num20: i32 = num19 + num10;
          bool tPushed11 = false;
          let mut overlay11: i32 = 1;
          if (this.game.EditObj.udsUnitOrderMode == 54)
          {
            tPushed11 = true;
            overlay11 = 0;
          }
          let mut tsubpart11: SubPartClass =  new SEButtonPushPartClassWithText("Zone Borders", 38, tPushed11, "Allows you to redraw the borders of your Zones [Shortkey Z]", 132, num11);
          this.but8 = this.AddSubPart( tsubpart11, num8 + num6, num20 + num7, 132, num11, overlay11);
          num9 = num20 + 47;
        }
        SubPartClass tsubpart12;
        if (this.game.EditObj.rightSideBarMode == 3)
        {
          tstring1: String = "Logistics";
           let mut local15: &Graphics = &objgraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
           let mut local16: &Bitmap = &bitmap6;
          let mut x5: i32 = num8 + num6;
          let mut y1: i32 = num9 + num7;
          DrawMod.DrawSimple( local15,  local16, x5, y1);
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring1, DrawMod.TGame.MarcFont7, num8 + num6 + 65, num9 + num7 + 12, DrawMod.TGame.seColGray);
          if (!flag1)
          {
            let mut num21: i32 = 1;
            let mut num22: i32 = num9 + 42;
            let mut tsubpart13: SubPartClass =  new SEButtonPushPartClass(50, this.game.EditObj.layerLisAvailable, "Show Current Logistical Points that you have left", 42, 40);
            this.layerLog1 = this.AddSubPart( tsubpart13, num21 + num6, num22 + num7, 42, 42, 1);
            let mut num23: i32 = num21 + 45;
            let mut tsubpart14: SubPartClass =  new SEButtonPushPartClass(51, this.game.EditObj.layerLisUsed, "Show Used Logistical Points during your turn so far", 42, 40);
            this.layerLog2 = this.AddSubPart( tsubpart14, num23 + num6, num22 + num7, 42, 42, 1);
            let mut num24: i32 = num23 + 45;
            let mut tsubpart15: SubPartClass =  new SEButtonPushPartClass(52, this.game.EditObj.layerLisBottlenecks, "Show Bottlenecks in Logistical Point usage during your turn so far", 42, 40);
            this.layerLog3 = this.AddSubPart( tsubpart15, num24 + num6, num22 + num7, 42, 42, 1);
            let mut num25: i32 = 1;
            let mut num26: i32 = num22 + 45;
            let mut tsubpart16: SubPartClass =  new SEButtonPushPartClass(49, this.game.EditObj.layerLisTotal, "Show your initial start-of-turn Logistical Points before any usage", 42, 40);
            this.layerLog4 = this.AddSubPart( tsubpart16, num25 + num6, num26 + num7, 42, 42, 1);
            let mut num27: i32 = num25 + 45;
            let mut tsubpart17: SubPartClass =  new SEButtonPushPartClass(31, this.game.EditObj.layerLisPreview, "Show a preview of upcomming turn Logistical Points", 42, 40);
            this.layerLog5 = this.AddSubPart( tsubpart17, num27 + num6, num26 + num7, 42, 42, 1);
            num8 = 0;
            num9 = num26 + 55;
          }
          else
          {
            num8 = 1;
            let mut num28: i32 = num9 + 42;
            let mut tsubpart18: SubPartClass =  new SEButtonPushPartClassWithText("Current Pts", 50, this.game.EditObj.layerLisAvailable, "Show Current Logistical Points that you have left [Shortkey L]", 132, 32);
            this.layerLog1 = this.AddSubPart( tsubpart18, num8 + num6, num28 + num7, 132, 32, 1);
            let mut num29: i32 = num28 + 34;
            let mut tsubpart19: SubPartClass =  new SEButtonPushPartClassWithText("Used Pts", 51, this.game.EditObj.layerLisUsed, "Show Used Logistical Points during your turn so far", 132, 32);
            this.layerLog2 = this.AddSubPart( tsubpart19, num8 + num6, num29 + num7, 132, 32, 1);
            let mut num30: i32 = num29 + 34;
            let mut tsubpart20: SubPartClass =  new SEButtonPushPartClassWithText("Initial Pts", 49, this.game.EditObj.layerLisTotal, "Show your initial start-of-turn Logistical Points before any usage", 132, 32);
            this.layerLog4 = this.AddSubPart( tsubpart20, num8 + num6, num30 + num7, 132, 32, 1);
            let mut num31: i32 = num30 + 34;
            let mut tsubpart21: SubPartClass =  new SEButtonPushPartClassWithText("Bottlenecks", 52, this.game.EditObj.layerLisBottlenecks, "Show Bottlenecks in Logistical Point usage during your turn so far", 132, 32);
            this.layerLog3 = this.AddSubPart( tsubpart21, num8 + num6, num31 + num7, 132, 32, 1);
            let mut num32: i32 = num31 + 34;
            let mut tsubpart22: SubPartClass =  new SEButtonPushPartClassWithText("Preview Pts", 31, this.game.EditObj.layerLisPreview, "Show a preview of upcomming turn Logistical Points [Shortkey P]", 132, 32);
            this.layerLog5 = this.AddSubPart( tsubpart22, num8 + num6, num32 + num7, 132, 32, 1);
            num9 = num32 + 47;
          }
          if (this.game.EditObj.layerLisPreview)
          {
            tstring2: String = "Zone Log. Assets";
             let mut local17: &Graphics = &objgraphics;
            Bitmap bitmap7 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local18: &Bitmap = &bitmap7;
            let mut x6: i32 = num8 + num6;
            let mut y2: i32 = num9 + num7;
            DrawMod.DrawSimple( local17,  local18, x6, y2);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring2, DrawMod.TGame.MarcFont7, num8 + num6 + 65, num9 + num7 + 12, DrawMod.TGame.seColGray);
            let mut num33: i32 = num9 + 52;
            let mut num34: i32 = this.h - num33 - 20;
            if (num34 >= 200)
              num34 = 200;
            let mut tlistsize: i32 =  Math.Round(Math.Floor((double) num34 / 20.0)) - 1;
            let mut tlistselect: i32 = -1;
            let mut num35: i32 = 0;
            this.rlistobj = ListClass::new();
            this.rlistobj.add("None", 0);
            if (1 > this.game.EditObj.layerLisOnlyAssetId)
              tlistselect = num35;
            let mut length: i32 = this.game.Data.StringListObj[stringListById2].Length;
            for (let mut index5: i32 = 0; index5 <= length; index5 += 1)
            {
              if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index5, 0])) == integer1)
              {
                let mut idValue: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index5, 1]));
                bool flag2 = false;
                if (idValue >= 2012 & idValue <= 2017)
                  flag2 = true;
                if (idValue == 201)
                  flag2 = true;
                if (idValue >= 311 & idValue <= 313)
                  flag2 = true;
                if (idValue >= 941 & idValue <= 943)
                  flag2 = true;
                if (idValue >= 3201 & idValue <= 3207)
                  flag2 = true;
                if (idValue >= 3261 & idValue <= 3267)
                  flag2 = true;
                if (flag2)
                {
                  let mut tdata: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index5, 9]));
                  str: String = this.game.Data.StringListObj[stringListById3].GetData(0, idValue, 12);
                  let mut integer2: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].GetData(0, idValue, 2));
                  let mut index6: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index5, 3]));
                  let mut index7: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index5, 4]));
                  if (index6 > -1 & index7 > -1 && this.game.Data.MapObj[0].HexObj[index6, index7].Regime == this.game.Data.Turn)
                  {
                    if (str.Length > 13)
                      str = Strings.Left(str, 13) + ".";
                    if (integer2 > 0)
                      str = str + " " + this.game.HandyFunctionsObj.GetRomanNumerical(integer2);
                    num35 += 1;
                    tname: String = str + " (" + index6.ToString() + "," + index7.ToString() + ")";
                    if (this.game.EditObj.layerLisOnlyAssetId == tdata)
                      tlistselect = num35;
                    this.rlistobj.add(tname, tdata);
                  }
                }
              }
            }
            if (!(this.game.EditObj.layerLisOnlyAssetId > 0 & tlistselect == -1) && tlistselect <= 0)
              tlistselect = 0;
            let mut tsubpart23: SubPartClass =  new ListSubPartClass(this.rlistobj, tlistsize, 136, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: (num8 + num6), bby: num33, tMarcStyle: true, overruleFont: ( this.game.MarcFont5), overruleItemSize: 20);
            this.rlistid = this.AddSubPart( tsubpart23, num8 + num6, num33, 136, tlistsize * 20, 1);
            num9 = num33 + (tlistsize * 20 + 20);
          }
          if (!this.game.EditObj.layerLisPreview | flag1 & num9 + 315 < this.h | !flag1 & num9 + 135 < this.h)
          {
            tstring3: String = "Map Layers";
             let mut local19: &Graphics = &objgraphics;
            Bitmap bitmap8 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local20: &Bitmap = &bitmap8;
            let mut x7: i32 = num8 + num6;
            let mut y3: i32 = num9 + num7;
            DrawMod.DrawSimple( local19,  local20, x7, y3);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, tstring3, DrawMod.TGame.MarcFont7, num8 + num6 + 65, num9 + num7 + 12, DrawMod.TGame.seColGray);
            if (!flag1)
            {
              let mut num36: i32 = 1;
              let mut num37: i32 = num9 + 42;
              let mut tsubpart24: SubPartClass =  new SEButtonPushPartClass(53, !this.game.EditObj.layerUnits, "Hide Units", 42, 40);
              this.layerUnit = this.AddSubPart( tsubpart24, num36 + num6, num37 + num7, 42, 42, 1);
              let mut num38: i32 = num36 + 45;
              let mut tsubpart25: SubPartClass =  new SEButtonPushPartClass(54, !this.game.EditObj.ShowLabel, "Hide Map Labels", 42, 40);
              this.layerLabel = this.AddSubPart( tsubpart25, num38 + num6, num37 + num7, 42, 42, 1);
              let mut num39: i32 = num38 + 45;
              let mut tsubpart26: SubPartClass =  new SEButtonPushPartClass(55, this.game.EditObj.HideAS, "Hide AP and Stack penalties", 42, 40);
              this.layerDetail = this.AddSubPart( tsubpart26, num39 + num6, num37 + num7, 42, 42, 1);
              num9 = num37 + 45;
              let mut num40: i32 = 1;
              let mut tsubpart27: SubPartClass =  new SEButtonPushPartClass(56, this.game.EditObj.HexRasterOn, "Show Hex Grid", 42, 40);
              this.layerGrid = this.AddSubPart( tsubpart27, num40 + num6, num9 + num7, 42, 42, 1);
              let mut num41: i32 = num40 + 45;
              let mut tsubpart28: SubPartClass =  new SEButtonPushPartClass(57, this.game.EditObj.RegimeColoring, "Show Regime Coloring", 42, 40);
              this.layerColor = this.AddSubPart( tsubpart28, num41 + num6, num9 + num7, 42, 42, 1);
              num8 = num41 + 45;
              tsubpart12 =  new SEButtonPushPartClass(50, this.game.EditObj.ShowLISRange, "Show the range in which Units Operational Logistics will be able to pick up Supplies from Roads.", 42, 40);
              this.layerLisRange = this.AddSubPart( tsubpart12, num8 + num6, num9 + num7, 42, 42, 1);
            }
            else
            {
              num8 = 1;
              let mut num42: i32 = num9 + 42;
              let mut tsubpart29: SubPartClass =  new SEButtonPushPartClassWithText("Hide Units", 53, !this.game.EditObj.layerUnits, "Hide Units [Shortkey 1]", 132, 32);
              this.layerUnit = this.AddSubPart( tsubpart29, num8 + num6, num42 + num7, 132, 32, 1);
              let mut num43: i32 = num42 + 34;
              let mut tsubpart30: SubPartClass =  new SEButtonPushPartClassWithText("Hide Labels", 54, !this.game.EditObj.ShowLabel, "Hide Map Labels [Shortkey 2]", 132, 32);
              this.layerLabel = this.AddSubPart( tsubpart30, num8 + num6, num43 + num7, 132, 32, 1);
              let mut num44: i32 = num43 + 34;
              let mut tsubpart31: SubPartClass =  new SEButtonPushPartClassWithText("Hide Penalty", 55, this.game.EditObj.HideAS, "Hide AP and Stack penalties [Shortkey 3]", 132, 32);
              this.layerDetail = this.AddSubPart( tsubpart31, num8 + num6, num44 + num7, 132, 32, 1);
              let mut num45: i32 = num44 + 34;
              let mut tsubpart32: SubPartClass =  new SEButtonPushPartClassWithText("Show Grid", 56, this.game.EditObj.HexRasterOn, "Show Hex Grid [Shortkey 4]", 132, 32);
              this.layerGrid = this.AddSubPart( tsubpart32, num8 + num6, num45 + num7, 132, 32, 1);
              let mut num46: i32 = num45 + 34;
              let mut tsubpart33: SubPartClass =  new SEButtonPushPartClassWithText("Show Color", 57, this.game.EditObj.RegimeColoring, "Show Regime Coloring [Shortkey 5]", 132, 32);
              this.layerColor = this.AddSubPart( tsubpart33, num8 + num6, num46 + num7, 132, 32, 1);
              num9 = num46 + 34;
              let mut tsubpart34: SubPartClass =  new SEButtonPushPartClassWithText("Show Op. Log", 50, this.game.EditObj.ShowLISRange, "Show the range in which Units Operational Logistics will be able to pick up Supplies from Roads. [Shortkey 6]", 132, 32);
              this.layerLisRange = this.AddSubPart( tsubpart34, num8 + num6, num9 + num7, 132, 32, 1);
            }
          }
        }
        if (this.game.EditObj.rightSideBarMode == 2)
        {
          int num47;
          int num48;
          if (index2 > -1 & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
          {
            str: String = this.game.Data.UnitObj[index2].Name;
            if (str.Length > 15)
              str = Strings.Left(str, 15) + ".";
             let mut local21: &Graphics = &objgraphics;
            Bitmap bitmap9 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local22: &Bitmap = &bitmap9;
            let mut x8: i32 = num8 + num6;
            let mut y: i32 = num9 + num7;
            DrawMod.DrawSimple( local21,  local22, x8, y);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, str, DrawMod.TGame.MarcFont7, num8 + num6 + 65, num9 + num7 + 12, DrawMod.TGame.seColGray);
            let mut num49: i32 = 1;
            let mut num50: i32 = num9 + 42;
            if (!flag1)
            {
              tsubpart12 =  new SEButtonPartClass(-1, "Workshop", 42, 42, 40);
              this.orderAmmoId = this.AddSubPart( tsubpart12, num49 + num6, num50 + num7, 42, 42, 1);
              let mut num51: i32 = num49 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Replacement Troops", 42, 42, 41);
              this.orderReplId = this.AddSubPart( tsubpart12, num51 + num6, num50 + num7, 42, 42, 1);
              let mut num52: i32 = num51 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Trade", 42, 42, 42);
              this.orderTradeId = this.AddSubPart( tsubpart12, num52 + num6, num50 + num7, 42, 42, 1);
              let mut num53: i32 = num50 + 45;
              let mut num54: i32 = 1;
              tsubpart12 =  new SEButtonPartClass(-1, "Transfer", 42, 42, 39);
              this.orderTransferId = this.AddSubPart( tsubpart12, num54 + num6, num53 + num7, 42, 42, 1);
              num47 = 0;
              num48 = num53 + 55;
            }
            else
            {
              let mut num55: i32 = 1;
              tsubpart12 =  new SEButtonPartClassWithText("Workshop", -1, "Workshop (produce Ammo and Machines)", 132, 32, 40);
              this.orderAmmoId = this.AddSubPart( tsubpart12, num55 + num6, num50 + num7, 132, 32, 1);
              let mut num56: i32 = num50 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Repl.Troops", -1, "Replacement Troops", 132, 32, 41);
              this.orderReplId = this.AddSubPart( tsubpart12, num55 + num6, num56 + num7, 132, 32, 1);
              let mut num57: i32 = num56 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Trade", -1, "Trade", 132, 32, 42);
              this.orderTradeId = this.AddSubPart( tsubpart12, num55 + num6, num57 + num7, 132, 32, 1);
              let mut num58: i32 = num57 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Transfer", -1, "Transfer", 132, 32, 39);
              this.orderTransferId = this.AddSubPart( tsubpart12, num55 + num6, num58 + num7, 132, 32, 1);
              num47 = 0;
              num48 = num58 + 47;
            }
          }
          else
          {
            str: String = "No SHQ";
            if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime != this.game.Data.Turn)
              str = "Unfriendly";
            if (str.Length > 15)
              str = Strings.Left(str, 15) + ".";
             let mut local23: &Graphics = &objgraphics;
            Bitmap bitmap10 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local24: &Bitmap = &bitmap10;
            let mut x9: i32 = num8 + num6;
            let mut y: i32 = num9 + num7;
            DrawMod.DrawSimple( local23,  local24, x9, y);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, str, DrawMod.TGame.MarcFont7, num8 + num6 + 65, num9 + num7 + 12, DrawMod.TGame.seColGray);
            let mut num59: i32 = 1;
            let mut num60: i32 = num9 + 42;
            if (!flag1)
            {
              tsubpart12 =  new SEButtonPartClass(-1, "Workshop: Produce Ammunitions & Machines", 42, 42, 40, true);
              this.orderAmmoId = this.AddSubPart( tsubpart12, num59 + num6, num60 + num7, 42, 42, 0);
              let mut num61: i32 = num59 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Produce Replacement Troops", 42, 42, 41, true);
              this.orderReplId = this.AddSubPart( tsubpart12, num61 + num6, num60 + num7, 42, 42, 0);
              let mut num62: i32 = num61 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Trade with the Traders in SHQ its Zone", 42, 42, 42, true);
              this.orderTradeId = this.AddSubPart( tsubpart12, num62 + num6, num60 + num7, 42, 42, 0);
              let mut num63: i32 = num60 + 45;
              let mut num64: i32 = 1;
              tsubpart12 =  new SEButtonPartClass(-1, "Use Logistical Network to send Items / Troops", 42, 42, 39, true);
              this.orderTransferId = this.AddSubPart( tsubpart12, num64 + num6, num63 + num7, 42, 42, 0);
              num47 = 0;
              num48 = num63 + 55;
            }
            else
            {
              let mut num65: i32 = 1;
              tsubpart12 =  new SEButtonPartClassWithText("Workshop", -1, "Workshop (produce Ammo and Machines)", 132, 32, 40, true);
              this.orderAmmoId = this.AddSubPart( tsubpart12, num65 + num6, num60 + num7, 132, 32, 0);
              let mut num66: i32 = num60 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Repl.Troops", -1, "Replacement Troops", 132, 32, 41, true);
              this.orderReplId = this.AddSubPart( tsubpart12, num65 + num6, num66 + num7, 132, 32, 0);
              let mut num67: i32 = num66 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Trade", -1, "Trade", 132, 32, 42, true);
              this.orderTradeId = this.AddSubPart( tsubpart12, num65 + num6, num67 + num7, 132, 32, 0);
              let mut num68: i32 = num67 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Transfer", -1, "Transfer", 132, 32, 39, true);
              this.orderTransferId = this.AddSubPart( tsubpart12, num65 + num6, num68 + num7, 132, 32, 0);
              num47 = 0;
              num48 = num68 + 47;
            }
          }
          int num69;
          int num70;
          if (integer1 > -1 & num3 == this.game.Data.RegimeObj[this.game.Data.Turn].id & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
          {
            str1: String = data;
            if (str1.Length > 15)
              str1 = Strings.Left(str1, 15) + ".";
             let mut local25: &Graphics = &objgraphics;
            Bitmap bitmap11 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local26: &Bitmap = &bitmap11;
            let mut x10: i32 = num47 + num6;
            let mut y: i32 = num48 + num7;
            DrawMod.DrawSimple( local25,  local26, x10, y);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, str1, DrawMod.TGame.MarcFont7, num47 + num6 + 65, num48 + num7 + 12, DrawMod.TGame.seColGray);
            int num71;
            int num72;
            if (!flag1)
            {
              let mut num73: i32 = 1;
              let mut num74: i32 = num48 + 42;
              tsubpart12 =  new SEButtonPartClass(-1, "Change SHQ", 42, 42, 37);
              this.orderChangeShqId = this.AddSubPart( tsubpart12, num73 + num6, num74 + num7, 42, 42, 1);
              let mut num75: i32 = num73 + 45;
              if (num2 > -1)
              {
                tsubpart12 =  new SEButtonPartClass(-1, "New Formation", 42, 42, 43);
                this.orderProduceUnitId = this.AddSubPart( tsubpart12, num75 + num6, num74 + num7, 42, 42, 1);
                let mut num76: i32 = num75 + 45;
                tsubpart12 =  new SEButtonPartClass(-1, "Colonize", 42, 42, 18);
                this.orderColonizeId = this.AddSubPart( tsubpart12, num76 + num6, num74 + num7, 42, 42, 1);
                num71 = num74 + 45;
                let mut num77: i32 = 1;
                tsubpart12 =  new SEButtonPartClass(-1, "Construction", 42, 42, 46);
                this.orderNewAssetId = this.AddSubPart( tsubpart12, num77 + num6, num71 + num7, 42, 42, 1);
                num72 = num77 + 45;
              }
              else
              {
                tsubpart12 =  new SEButtonPartClass(-1, "Form a new Formation on the selected Hex", 42, 42, 43, true);
                this.orderProduceUnitId = this.AddSubPart( tsubpart12, num75 + num6, num74 + num7, 42, 42, 0);
                let mut num78: i32 = num75 + 45;
                tsubpart12 =  new SEButtonPartClass(-1, "Send Colonists to this Zone", 42, 42, 18, true);
                this.orderColonizeId = this.AddSubPart( tsubpart12, num78 + num6, num74 + num7, 42, 42, 0);
                num71 = num74 + 45;
                let mut num79: i32 = 1;
                tsubpart12 =  new SEButtonPartClass(-1, "Start Construction of a new Asset on selected Hex", 42, 42, 46, true);
                this.orderNewAssetId = this.AddSubPart( tsubpart12, num79 + num6, num71 + num7, 42, 42, 0);
                num72 = num79 + 45;
              }
            }
            else
            {
              num72 = 1;
              let mut num80: i32 = num48 + 42;
              tsubpart12 =  new SEButtonPartClassWithText("Zone SHQ", -1, "Change SHQ", 132, 32, 37);
              this.orderChangeShqId = this.AddSubPart( tsubpart12, num72 + num6, num80 + num7, 132, 32, 1);
              let mut num81: i32 = num80 + 34;
              if (num2 > -1)
              {
                tsubpart12 =  new SEButtonPartClassWithText("Raise Form.", -1, "New Formation", 132, 32, 43);
                this.orderProduceUnitId = this.AddSubPart( tsubpart12, num72 + num6, num81 + num7, 132, 32, 1);
                let mut num82: i32 = num81 + 34;
                tsubpart12 =  new SEButtonPartClassWithText("Colonize", -1, "Colonize", 132, 32, 18);
                this.orderColonizeId = this.AddSubPart( tsubpart12, num72 + num6, num82 + num7, 132, 32, 1);
                let mut num83: i32 = num82 + 34;
                tsubpart12 =  new SEButtonPartClassWithText("Construct", -1, "Construction", 132, 32, 46);
                this.orderNewAssetId = this.AddSubPart( tsubpart12, num72 + num6, num83 + num7, 132, 32, 1);
                num71 = num83 + 34;
              }
              else
              {
                tsubpart12 =  new SEButtonPartClassWithText("Raise Form.", -1, "New Formation", 132, 32, 43, true);
                this.orderProduceUnitId = this.AddSubPart( tsubpart12, num72 + num6, num81 + num7, 132, 32, 0);
                let mut num84: i32 = num81 + 34;
                tsubpart12 =  new SEButtonPartClassWithText("Colonize", -1, "Colonize", 132, 32, 18, true);
                this.orderColonizeId = this.AddSubPart( tsubpart12, num72 + num6, num84 + num7, 132, 32, 0);
                let mut num85: i32 = num84 + 34;
                tsubpart12 =  new SEButtonPartClassWithText("Construct", -1, "Construction", 132, 32, 46, true);
                this.orderNewAssetId = this.AddSubPart( tsubpart12, num72 + num6, num85 + num7, 132, 32, 0);
                num71 = num85 + 34;
              }
            }
            let mut idValue1: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData3(3, this.game.SelectX, 4, this.game.SelectY, 8, 0, 9)));
            let mut idValue2: i32 = this.orderZoneNr;
            if (idValue1 > 0)
              idValue2 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(9, idValue1, 0)));
            let mut locationById: i32 = this.game.HandyFunctionsObj.GetLocationByID( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue2, 6))));
            let mut num86: i32 = 0;
            str2: String = "";
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts < 5)
            {
              str2 = "You need at least 5 PP to make a new Zone";
              num86 = 1;
            }
            if (5 > this.game.EventRelatedObj.Helper_GetClosestOtherCity(this.game.SelectX, this.game.SelectY))
            {
              str2 = "You can only create a new Zone at distance 5 or more from an existing City";
              num86 = 1;
            }
            if (idValue1 < 1)
            {
              str2 = "No asset present in selected hex";
              num86 = 1;
            }
            if (locationById > -1 && this.game.Data.LocObj[locationById].X == this.game.SelectX & this.game.Data.LocObj[locationById].Y == this.game.SelectY)
            {
              str2 = "You need to select an out-of-city Asset to make a new Zone";
              num86 = 1;
            }
            if (num2 == -1)
            {
              str2 = "Hex needs to be in a Zone with an SHQ assigned to it";
              num86 = 1;
            }
            if (Operators.CompareString(str2, "", false) == 0)
              str2 = "Found new Zone [5PP]";
            if (!flag1)
            {
              if (num86 == 0)
              {
                tsubpart12 =  new SEButtonPartClass(-1, str2, 42, 42, 44, num86 == 1);
                this.orderNewZoneId = this.AddSubPart( tsubpart12, num72 + num6, num71 + num7, 42, 42, 1);
              }
              else
              {
                tsubpart12 =  new SEButtonPartClass(-1, str2, 42, 42, 44, num86 == 1);
                this.orderNewZoneId = this.AddSubPart( tsubpart12, num72 + num6, num71 + num7, 42, 42, 0);
              }
              num69 = 0;
              num70 = num71 + 55;
            }
            else
            {
              if (num86 == 0)
              {
                tsubpart12 =  new SEButtonPartClassWithText("New Zone", -1, str2, 132, 32, 44, num86 == 1);
                this.orderNewZoneId = this.AddSubPart( tsubpart12, num72 + num6, num71 + num7, 132, 32, 1);
              }
              else
              {
                tsubpart12 =  new SEButtonPartClassWithText("New Zone", -1, str2, 132, 32, 44, num86 == 1);
                this.orderNewZoneId = this.AddSubPart( tsubpart12, num72 + num6, num71 + num7, 132, 32, 0);
              }
              num69 = 0;
              num70 = num71 + 47;
            }
          }
          else
          {
            str: String = "No Zone";
            if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
              str = "Unfriendly";
            if (num3 != this.game.Data.RegimeObj[this.game.Data.Turn].id & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
              str = "Zone in Conquest";
            if (str.Length > 16)
              str = Strings.Left(str, 16) + ".";
             let mut local27: &Graphics = &objgraphics;
            Bitmap bitmap12 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local28: &Bitmap = &bitmap12;
            let mut x11: i32 = num47 + num6;
            let mut y: i32 = num48 + num7;
            DrawMod.DrawSimple( local27,  local28, x11, y);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, str, DrawMod.TGame.MarcFont7, num47 + num6 + 65, num48 + num7 + 12, DrawMod.TGame.seColGray);
            if (!flag1)
            {
              let mut num87: i32 = 1;
              let mut num88: i32 = num48 + 42;
              tsubpart12 =  new SEButtonPartClass(-1, "Change the SHQ that this Zone is assigned to", 42, 42, 37, true);
              this.orderChangeShqId = this.AddSubPart( tsubpart12, num87 + num6, num88 + num7, 42, 42, 0);
              let mut num89: i32 = num87 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Form a new Formation on the selected Hex", 42, 42, 43, true);
              this.orderProduceUnitId = this.AddSubPart( tsubpart12, num89 + num6, num88 + num7, 42, 42, 0);
              let mut num90: i32 = num89 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Send Colonists to this Zone", 42, 42, 18, true);
              this.orderColonizeId = this.AddSubPart( tsubpart12, num90 + num6, num88 + num7, 42, 42, 0);
              let mut num91: i32 = num88 + 45;
              let mut num92: i32 = 1;
              tsubpart12 =  new SEButtonPartClass(-1, "Start Construction of a new Asset on selected Hex", 42, 42, 46, true);
              this.orderNewAssetId = this.AddSubPart( tsubpart12, num92 + num6, num91 + num7, 42, 42, 0);
              let mut num93: i32 = num92 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, str, 42, 42, 44, true);
              this.orderNewZoneId = this.AddSubPart( tsubpart12, num93 + num6, num91 + num7, 42, 42, 0);
              num69 = 0;
              num70 = num91 + 55;
            }
            else
            {
              num69 = 1;
              let mut num94: i32 = num48 + 42;
              tsubpart12 =  new SEButtonPartClassWithText("Zone SHQ", -1, "Change SHQ", 132, 32, 37, true);
              this.orderChangeShqId = this.AddSubPart( tsubpart12, num69 + num6, num94 + num7, 132, 32, 0);
              let mut num95: i32 = num94 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Raise Form.", -1, "New Formation", 132, 32, 43, true);
              this.orderProduceUnitId = this.AddSubPart( tsubpart12, num69 + num6, num95 + num7, 132, 32, 0);
              let mut num96: i32 = num95 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Colonize", -1, "Colonize", 132, 32, 18, true);
              this.orderColonizeId = this.AddSubPart( tsubpart12, num69 + num6, num96 + num7, 132, 32, 0);
              let mut num97: i32 = num96 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Construct", -1, "Construction", 132, 32, 46, true);
              this.orderNewAssetId = this.AddSubPart( tsubpart12, num69 + num6, num97 + num7, 132, 32, 0);
              let mut num98: i32 = num97 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("New Zone", -1, str, 132, 32, 44, true);
              this.orderNewZoneId = this.AddSubPart( tsubpart12, num69 + num6, num98 + num7, 132, 32, 0);
              num70 = num98 + 47;
            }
          }
          bool flag3 = true;
          if (unitSelected < 0)
            flag3 = false;
          if (unitSelected > -1 && this.game.Data.UnitObj[unitSelected].Regime != this.game.Data.Turn)
            flag3 = false;
          if (flag3)
          {
            str: String = this.game.Data.UnitObj[unitSelected].Name;
            if (str.Length > 15)
              str = Strings.Left(str, 15) + ".";
             let mut local29: &Graphics = &objgraphics;
            Bitmap bitmap13 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local30: &Bitmap = &bitmap13;
            let mut x12: i32 = num69 + num6;
            let mut y: i32 = num70 + num7;
            DrawMod.DrawSimple( local29,  local30, x12, y);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, str, DrawMod.TGame.MarcFont7, num69 + num6 + 65, num70 + num7 + 12, DrawMod.TGame.seColGray);
            let mut num99: i32 = 1;
            let mut num100: i32 = num70 + 42;
            if (!flag1)
            {
              tsubpart12 =  new SEButtonPartClass(-1, "Order of Battle", 42, 42, 1);
              this.orderChangeId = this.AddSubPart( tsubpart12, num99 + num6, num100 + num7, 42, 42, 1);
              if (this.orderShqNr != this.orderUnitNr)
              {
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.orderUnitNr].Historical].GiveHisVarValue(11) < 1)
                {
                  num99 += 45;
                  tsubpart12 =  new SEButtonPartClass(-1, "Replacement Troops", 42, 42, 33);
                  this.orderRepl2Id = this.AddSubPart( tsubpart12, num99 + num6, num100 + num7, 42, 42, 1);
                }
                else
                {
                  num99 += 45;
                  tsubpart12 =  new SEButtonPartClass(-1, "Militia cannot use your regular Replacement Troops. They have their own autonomous replacement system.", 42, 42, 33, true);
                  this.orderRepl2Id = this.AddSubPart( tsubpart12, num99 + num6, num100 + num7, 42, 42, 0);
                }
              }
              let mut num101: i32 = num99 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Transfer between Units in same Hex and Battlegroup formation", 42, 42, 12);
              this.orderBattlegroupId = this.AddSubPart( tsubpart12, num101 + num6, num100 + num7, 42, 42, 1);
            }
            else
            {
              tsubpart12 =  new SEButtonPartClassWithText("Unit Admin", -1, "Order of Battle", 132, 32, 1);
              this.orderChangeId = this.AddSubPart( tsubpart12, num99 + num6, num100 + num7, 132, 32, 1);
              if (this.orderShqNr != this.orderUnitNr)
              {
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.orderUnitNr].Historical].GiveHisVarValue(11) < 1)
                {
                  num100 += 34;
                  tsubpart12 =  new SEButtonPartClassWithText("Repl.Troops", -1, "Replacement Troops", 132, 32, 33);
                  this.orderRepl2Id = this.AddSubPart( tsubpart12, num99 + num6, num100 + num7, 132, 32, 1);
                }
                else
                {
                  num100 += 34;
                  tsubpart12 =  new SEButtonPartClassWithText("Repl.Troops", -1, "Militia cannot use your regular Replacement Troops. They have their own autonomous replacement system.", 132, 32, 33, true);
                  this.orderRepl2Id = this.AddSubPart( tsubpart12, num99 + num6, num100 + num7, 132, 32, 0);
                }
              }
              let mut num102: i32 = num100 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Transfer/BG", -1, "Transfer between Units in same Hex and Battlegroup formation", 132, 32, 12);
              this.orderBattlegroupId = this.AddSubPart( tsubpart12, num99 + num6, num102 + num7, 132, 32, 1);
            }
          }
          else
          {
            str: String = "No friendy Unit";
            if (str.Length > 15)
              str = Strings.Left(str, 15) + ".";
             let mut local31: &Graphics = &objgraphics;
            Bitmap bitmap14 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
             let mut local32: &Bitmap = &bitmap14;
            let mut x13: i32 = num69 + num6;
            let mut y: i32 = num70 + num7;
            DrawMod.DrawSimple( local31,  local32, x13, y);
            DrawMod.DrawTextColouredConsoleCenter( objgraphics, str, DrawMod.TGame.MarcFont7, num69 + num6 + 65, num70 + num7 + 12, DrawMod.TGame.seColGray);
            let mut num103: i32 = 1;
            let mut num104: i32 = num70 + 42;
            if (!flag1)
            {
              tsubpart12 =  new SEButtonPartClass(-1, "Change the selected Formation", 42, 42, 1, true);
              this.orderChangeId = this.AddSubPart( tsubpart12, num103 + num6, num104 + num7, 42, 42, 0);
              let mut num105: i32 = num103 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Produce Replacement Troops", 42, 42, 33, true);
              this.orderRepl2Id = this.AddSubPart( tsubpart12, num105 + num6, num104 + num7, 42, 42, 0);
              let mut num106: i32 = num105 + 45;
              tsubpart12 =  new SEButtonPartClass(-1, "Transfer between Units in same Hex and Battlegroup formation", 42, 42, 12, true);
              this.orderBattlegroupId2 = this.AddSubPart( tsubpart12, num106 + num6, num104 + num7, 42, 42, 0);
            }
            else
            {
              tsubpart12 =  new SEButtonPartClassWithText("Unit Admin", -1, "Change the selected Formation", 132, 32, 1, true);
              this.orderChangeId = this.AddSubPart( tsubpart12, num103 + num6, num104 + num7, 132, 32, 0);
              let mut num107: i32 = num104 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Repl.Troops", -1, "Produce Replacement Troops", 132, 32, 33, true);
              this.orderRepl2Id = this.AddSubPart( tsubpart12, num103 + num6, num107 + num7, 132, 32, 0);
              let mut num108: i32 = num107 + 34;
              tsubpart12 =  new SEButtonPartClassWithText("Transfer/BG", -1, "Transfer between Units in same Hex and Battlegroup formation", 132, 32, 12, true);
              this.orderBattlegroupId2 = this.AddSubPart( tsubpart12, num103 + num6, num108 + num7, 132, 32, 0);
            }
          }
        }
      }
      if (this.game.EditObj.rightSideBarMode == 1)
      {
        if (num1 != this.game.Data.Turn || index2 < 0)
          return;
        let mut x14: i32 = 45;
        let mut num109: i32 = 10;
        let mut width: i32 = 135;
        let mut height: i32 = 28;
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
        let mut eventPic1: i32 = this.game.Data.FindEventPic("", 9, "SE_Present");
        let mut eventPic2: i32 = this.game.Data.FindEventPic("", 8, "SE_Present");
        let mut eventPic3: i32 = this.game.Data.FindEventPic("", 11, "SE_Present");
        str3: String = this.game.SelectX.ToString() + "," + this.game.SelectY.ToString();
        str4: String = this.game.Data.UnitObj[index2].Name;
        if (str4.Length > 15)
          str4 = Strings.Left(str4, 15) + ".";
         let mut local33: &Graphics = &objgraphics;
        Bitmap bitmap15 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
         let mut local34: &Bitmap = &bitmap15;
        let mut x15: i32 = x14;
        let mut y4: i32 = num109;
        DrawMod.DrawSimple( local33,  local34, x15, y4);
        DrawMod.DrawTextColouredConsoleCenter( objgraphics, str4, DrawMod.TGame.MarcFont7, x14 + 65, num109 + 12, DrawMod.TGame.seColGray);
        let mut y5: i32 = num109 + 42;
        let mut counter: i32 = simpleList.Counter;
        for (let mut index8: i32 = 0; index8 <= counter; index8 += 1)
        {
          let mut num110: i32 = this.game.Data.UnitObj[index2].items.list.FindWeight(simpleList.Id[index8]);
          let mut num111: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index2].Historical].ID, 2, simpleList.Id[index8], 3)));
          let mut num112: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData2(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index2].Historical].ID, 2, simpleList.Id[index8], 3)));
          if (num110 > 0 | num111 > 0 | num112 > 0 | this.game.ScreenHeight >= 920)
          {
            this.game.Data.StringListObj[stringListById4].GetData(0, simpleList.Id[index8], 2);
            str5: String = simpleStringList.Id[index8];
             let mut local35: &Graphics = &objgraphics;
            Bitmap bitmap16 = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_VARBOX);
             let mut local36: &Bitmap = &bitmap16;
            let mut x16: i32 = x14;
            let mut y6: i32 = y5;
            DrawMod.DrawSimple( local35,  local36, x16, y6);
            let mut eventPicSlotFor: i32 = this.game.EventRelatedObj.GetEventPicSlotFor(simpleList.Id[index8], "", "");
             let mut local37: &Graphics = &objgraphics;
            Bitmap bitmap17 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor]);
             let mut local38: &Bitmap = &bitmap17;
            let mut x17: i32 = x14 + 2;
            let mut y7: i32 = y5 + 6;
            DrawMod.DrawSimple( local37,  local38, x17, y7);
            tstring4: String = num110.ToString();
            double num113;
            if (num110 > 9999)
            {
              num113 = Math.Round((double) num110 / 1000.0, 1);
              tstring4 = num113.ToString() + "k";
            }
            let mut num114: i32 = num112 - num111;
            ttitle: String = simpleStringList.Id[index8];
            num110 = 0;
            let mut num115: i32 = 0;
            let mut num116: i32 = 0;
            let mut num117: i32 = 0;
            let mut num118: i32 = 0;
            let mut num119: i32 = 0;
            let mut logCounter: i32 = this.game.Data.UnitObj[index2].LogCounter;
            for (let mut index9: i32 = 0; index9 <= logCounter; index9 += 1)
            {
              if (this.game.Data.UnitObj[index2].LogData1[index9] == simpleList.Id[index8])
              {
                if (this.game.Data.UnitObj[index2].LogType[index9] == 101)
                  num110 += this.game.Data.UnitObj[index2].LogData3[index9];
                if (this.game.Data.UnitObj[index2].LogType[index9] == 102)
                  num115 += this.game.Data.UnitObj[index2].LogData3[index9];
                if (this.game.Data.UnitObj[index2].LogType[index9] == 103)
                  num116 += this.game.Data.UnitObj[index2].LogData3[index9];
                if (this.game.Data.UnitObj[index2].LogType[index9] == 104)
                  num117 += this.game.Data.UnitObj[index2].LogData3[index9];
                if (this.game.Data.UnitObj[index2].LogType[index9] == 301)
                  num118 += this.game.Data.UnitObj[index2].LogData3[index9];
                if (this.game.Data.UnitObj[index2].LogType[index9] == 302)
                  num119 += this.game.Data.UnitObj[index2].LogData3[index9];
              }
            }
            if (num118 > 0)
              tstring4 += "*";
            DrawMod.DrawTextColouredConsole( objgraphics, tstring4, this.game.MarcFont16, x14 + 31, y5 + 4, this.game.seColGray);
            tstring5: String = Math.Abs(num114).ToString();
            if (num114 > 9999 | num114 < -9999)
            {
              num113 = Math.Round((double) Math.Abs(num114) / 1000.0, 1);
              tstring5 = num113.ToString() + "k";
            }
            if (num118 > 0)
              num114 = 0;
            if (num114 != 0)
              DrawMod.DrawTextColouredConsole( objgraphics, tstring5, this.game.MarcFont7, x14 + 91, y5 + 5, this.game.seColGray);
            if (num114 > 0)
            {
               let mut local39: &Graphics = &objgraphics;
              Bitmap bitmap18 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic2]);
               let mut local40: &Bitmap = &bitmap18;
              rectangle = Rectangle::new(0, 0, 32, 16);
              let mut srcrect4: &Rectangle = &rectangle
              trect1 = Rectangle::new(x14 + 76, y5 + 6, 32, 16);
              let mut destrect4: &Rectangle = &trect1
              DrawMod.DrawSimplePart2ColouredNew( local39,  local40, srcrect4, destrect4, 0.0f, 1.5f, 0.0f, 1f);
            }
            else if (num114 < 0)
            {
               let mut local41: &Graphics = &objgraphics;
              Bitmap bitmap19 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic1]);
               let mut local42: &Bitmap = &bitmap19;
              rectangle = Rectangle::new(0, 0, 32, 16);
              let mut srcrect5: &Rectangle = &rectangle
              trect1 = Rectangle::new(x14 + 76, y5 + 6, 32, 16);
              let mut destrect5: &Rectangle = &trect1
              DrawMod.DrawSimplePart2ColouredNew( local41,  local42, srcrect5, destrect5, 1.5f, 0.0f, 0.0f, 1f);
            }
            else
            {
               let mut local43: &Graphics = &objgraphics;
              Bitmap bitmap20 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPic3]);
               let mut local44: &Bitmap = &bitmap20;
              rectangle = Rectangle::new(0, 0, 32, 16);
              let mut srcrect6: &Rectangle = &rectangle
              trect1 = Rectangle::new(x14 + 76, y5 + 6, 32, 16);
              let mut destrect6: &Rectangle = &trect1
              DrawMod.DrawSimplePart2ColouredNew( local43,  local44, srcrect6, destrect6, 0.0f, 1.8f, 1.8f, 1f);
            }
            str6: String = "Delivered from zones: " + num110.ToString() + "\r\n" + "Sent to zones: " + num115.ToString() + "\r\n" + "Sent to units: " + num116.ToString() + "\r\n" + "Consumed in SHQ: " + num117.ToString() + "\r\n" + "Consumed by colonists & recruits: " + num119.ToString() + "\r\n" + "Lost due to max storage reached: " + num118.ToString();
            string ttext;
            if (simpleList.Data1[index8] > 0)
            {
              let mut weight: i32 = this.game.Data.UnitObj[index2].items.list.FindWeight(simpleList.Data1[index8]);
              ttext = str6 + "\r\nMaximum storage: " + weight.ToString();
            }
            else
              ttext = str6 + "\r\nMaximum storage: Unlimited";
            rectangle = Rectangle::new(x14, y5, width, height);
            trect1 = rectangle;
            this.AddMouse( trect1, ttitle, ttext);
            y5 += height;
            if (y5 + (220 + (height + 5) + 60) > this.game.ScreenHeight)
              break;
          }
        }
      }
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub void HandleToolTip(int x, int y)
    {
      let mut mouseCounter: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          if (Strings.InStr(this.game.EditObj.TipText, "MX-ENTR") <= 0)
            return;
          this.game.EditObj.TipTitle += "<FIXEDSYS>";
          return;
        }
      }
      if (this.SubPartCounter <= -1)
        return;
      let mut subPartCounter: i32 = this.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          this.game.EditObj.TipButton = false;
          this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (this.game.EditObj.TipButton)
            break;
          if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            break;
          }
        }
      }
    }

    pub void PopUpRefresh() => this.DoRefresh();

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.game.EditObj.TutOrder > -1)
        return windowReturnClass;
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index1: i32 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1] & this.SubPartOverlay[index1] > 0)
          {
            let mut num1: i32 = this.SubPartID[index1];
            if (num1 == this.rlistid)
            {
              let mut num2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 >= 0)
              {
                let mut layerLisOnlyAssetId: i32 = this.game.EditObj.layerLisOnlyAssetId;
                this.game.EditObj.layerLisOnlyAssetId = num2;
                let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
                for (let mut index2: i32 = 0; index2 <= mapWidth; index2 += 1)
                {
                  let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
                  for (let mut index3: i32 = 0; index3 <= mapHeight; index3 += 1)
                  {
                    let mut index4: i32 = 0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[index2, index3].tempPreviewAssetLIS[index4] = 0;
                      index4 += 1;
                    }
                    while (index4 <= 8);
                  }
                }
                if (this.game.EditObj.layerLisOnlyAssetId > 0)
                {
                  this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
                  let mut stringListById: i32 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 148, 0, 0));
                  let mut num3: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(9, this.game.EditObj.layerLisOnlyAssetId, 0)));
                  let mut num4: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(9, this.game.EditObj.layerLisOnlyAssetId, 3)));
                  let mut num5: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(9, this.game.EditObj.layerLisOnlyAssetId, 4)));
                  this.game.SelectX = num4;
                  this.game.SelectY = num5;
                  this.game.HandyFunctionsObj.SetcornerXY2();
                  this.game.EditObj.TempCoordList = CoordList::new();
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                  this.game.EditObj.se1_SelectAssetButton = this.game.EditObj.layerLisOnlyAssetId;
                  if (this.game.EditObj.SetViewModeExtraNr == 3 && this.game.EditObj.layerLisOnlyAssetId > 0)
                    windowReturnClass.AddCommand(4, 69);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (layerLisOnlyAssetId > 0)
                {
                  this.game.ProcessingObj.LIS_SetNetwork(false, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
            else
            {
              if (num1 == this.but1id)
              {
                this.game.EditObj.rightSideBarMode = 0;
                windowReturnClass.AddCommand(4, 68);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but1)
              {
                this.game.EditObj.udsUnitOrderMode = 0;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but6)
              {
                this.game.EditObj.udsUnitOrderMode = 53;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but2)
              {
                this.game.EditObj.udsUnitOrderMode = 1;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but7)
              {
                this.game.EditObj.udsUnitOrderMode = 48;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but8)
              {
                this.game.EditObj.udsUnitOrderMode = 54;
                this.game.EditObj.OrderSubType = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, "SE_Data", "Zones"));
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                windowReturnClass.AddCommand(1, 118);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but3)
              {
                this.game.EditObj.udsUnitOrderMode = 18;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but4)
              {
                this.game.EditObj.udsUnitOrderMode = 11;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but9)
              {
                this.game.EditObj.udsUnitOrderMode = 14;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but10)
              {
                this.game.EditObj.udsUnitOrderMode = 33;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but11)
              {
                this.game.EditObj.udsUnitOrderMode = 55;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  if (this.game.EditObj.UnitSelected > -1)
                    window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                  else
                    window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but5)
              {
                let mut enr: i32 =  Math.Round((double) this.game.Data.RuleVar[705]);
                this.game.EditObj.UDSpopupText = "";
                this.game.EditObj.UDSAddInput("ROADCHOICE", 0);
                if (enr > 0)
                  this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
                if (this.game.EditObj.UDSpopupText.Length > 1)
                {
                  this.game.EditObj.UDSpushedPopupText = this.game.EditObj.UDSpopupText;
                  this.game.EditObj.UDSpopupText = "";
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.udsUnitOrderMode = 36;
                ScreenClass screeny = this.formref.Screeny;
                System.Type type = typeof (MapWindowClass2);
                 System.Type local =  type;
                MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow( local);
                if (!Information.IsNothing((object) window))
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerUnit)
              {
                this.game.EditObj.layerUnits = !this.game.EditObj.layerUnits;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                if (!this.game.EditObj.layerUnits)
                  this.game.EditObj.UnitSelected = -1;
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 69);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLabel)
              {
                this.game.EditObj.ShowLabel = !this.game.EditObj.ShowLabel;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerDetail)
              {
                this.game.EditObj.HideAS = !this.game.EditObj.HideAS;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerGrid)
              {
                this.game.EditObj.HexRasterOn = !this.game.EditObj.HexRasterOn;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerColor)
              {
                this.game.EditObj.RegimeColoring = !this.game.EditObj.RegimeColoring;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLisRange)
              {
                this.game.HandyFunctionsObj.RedimTempSup(9999);
                this.game.EditObj.ShowLISRange = !this.game.EditObj.ShowLISRange;
                if (this.game.EditObj.ShowLISRange)
                {
                  this.game.EditObj.ShowHQPower = false;
                  this.game.EditObj.ShowAirRange = false;
                }
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLog1)
              {
                this.game.EditObj.layerLisAvailable = !this.game.EditObj.layerLisAvailable;
                this.game.EditObj.layerLisUsed = false;
                this.game.EditObj.layerLisTotal = false;
                this.game.EditObj.layerLisBottlenecks = false;
                this.game.EditObj.layerLisPreview = false;
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLog2)
              {
                this.game.EditObj.layerLisAvailable = false;
                this.game.EditObj.layerLisUsed = !this.game.EditObj.layerLisUsed;
                this.game.EditObj.layerLisTotal = false;
                this.game.EditObj.layerLisBottlenecks = false;
                this.game.EditObj.layerLisPreview = false;
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLog3)
              {
                this.game.EditObj.layerLisAvailable = false;
                this.game.EditObj.layerLisUsed = false;
                this.game.EditObj.layerLisTotal = false;
                this.game.EditObj.layerLisBottlenecks = !this.game.EditObj.layerLisBottlenecks;
                this.game.EditObj.layerLisPreview = false;
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLog4)
              {
                this.game.EditObj.layerLisAvailable = false;
                this.game.EditObj.layerLisUsed = false;
                this.game.EditObj.layerLisTotal = !this.game.EditObj.layerLisTotal;
                this.game.EditObj.layerLisBottlenecks = false;
                this.game.EditObj.layerLisPreview = false;
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.layerLog5)
              {
                this.game.EditObj.layerLisAvailable = false;
                this.game.EditObj.layerLisUsed = false;
                this.game.EditObj.layerLisTotal = false;
                this.game.EditObj.layerLisBottlenecks = false;
                this.game.EditObj.layerLisPreview = !this.game.EditObj.layerLisPreview;
                this.game.EditObj.layerLisOnlyAssetId = -1;
                if (!this.game.EditObj.layerLisPreview)
                {
                  let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
                  for (let mut index5: i32 = 0; index5 <= mapWidth; index5 += 1)
                  {
                    let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
                    for (let mut index6: i32 = 0; index6 <= mapHeight; index6 += 1)
                    {
                      let mut index7: i32 = 0;
                      do
                      {
                        this.game.Data.MapObj[0].HexObj[index5, index6].tempPreviewLIS[index7] = 0;
                        this.game.Data.MapObj[0].HexObj[index5, index6].tempPreviewAssetLIS[index7] = 0;
                        index7 += 1;
                      }
                      while (index7 <= 8);
                    }
                  }
                }
                else
                  this.game.ProcessingObj.LIS_SetNetwork(false, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderAmmoId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ZONE", this.orderShqNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 542, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderReplId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("SHQNR", this.orderShqNr);
                this.game.EventRelatedObj.SetUDSKey("UNR", -1);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 518, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderRepl2Id)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("UNR", this.orderUnitNr);
                this.game.EventRelatedObj.SetUDSKey("SHQNR", -1);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 518, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderBattlegroupId)
              {
                DrawMod.TGame.EditObj.PopupValue = 27;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderTransferId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 589, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderTradeId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("SHQ", this.orderShqNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 527, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderChangeShqId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ZONE", this.orderZoneNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 571, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderProduceUnitId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ZONE", this.orderZoneNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 521, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderColonizeId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ZONE", this.orderZoneNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 551, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderNewAssetId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ZONE", this.orderZoneNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 106, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderNewZoneId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("ZONE", this.orderZoneNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 508, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderMoreId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("UNIT", this.orderUnitNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 524, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.orderChangeId)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EditObj.UDSClearInput();
                this.game.EventRelatedObj.SetUDSKey("UNIT", this.orderUnitNr);
                let mut eventByLib: i32 = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 548, 0, 0);
                this.game.EventRelatedObj.DoCheckSpecificEvent(eventByLib);
                this.game.EditObj.udsLastCalledPopupEventNr = eventByLib;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
          }
        }
      }
      let mut mouseCounter1: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter1; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          switch (this.MouseData[index])
          {
            case 1:
            case 2:
            case 3:
            case 4:
              if (this.game.EditObj.rightSideBarMode == this.MouseData[index])
                this.game.EditObj.rightSideBarMode = 0;
              else
                this.game.EditObj.rightSideBarMode = this.MouseData[index];
              windowReturnClass.AddCommand(4, 68);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 101:
              if (this.currentShqNr > -1)
              {
                let mut x1: i32 = this.game.Data.UnitObj[this.currentShqNr].X;
                let mut y1: i32 = this.game.Data.UnitObj[this.currentShqNr].Y;
                this.game.Data.MapObj[0].HexObj[x1, y1].RemoveUnitFromList(this.currentShqNr);
                this.game.Data.MapObj[0].HexObj[x1, y1].AddUnitToList(this.currentShqNr);
                this.game.EditObj.TempCoordList = CoordList::new();
                this.game.EditObj.UnitSelected = this.currentShqNr;
                this.game.HandyFunctionsObj.CenterOnXY(this.game.Data.UnitObj[this.currentShqNr].X, this.game.Data.UnitObj[this.currentShqNr].Y);
                windowReturnClass.AddCommand(3, 11);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              continue;
            default:
              continue;
          }
        }
      }
      windowReturnClass.NoMouseClickBelow = this.game.EditObj.rightSideBarMode <= 0 ? x > this.OwnBitmap.Width - 30 : x >= 22;
      let mut mouseCounter2: i32 = this.MouseCounter;
      bool flag;
      for (let mut index: i32 = 0; index <= mouseCounter2; index += 1)
      {
        if (x > this.MouseRect[index].X - 16 & x < this.MouseRect[index].X + this.MouseRect[index].Width + 32 && y > this.MouseRect[index].Y - 16 & y < this.MouseRect[index].Y + this.MouseRect[index].Height + 32)
          flag = true;
      }
      if (flag)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false) => WindowReturnClass::new();
  }
}
