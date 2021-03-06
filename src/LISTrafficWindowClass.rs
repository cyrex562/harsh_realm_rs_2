// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LISTrafficWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class LISTrafficWindowClass : WindowClass
  {
     int okid;
     int[,] trafficId;
     int[] trafficIdB;
     int[] pullId;
     int[] pullData;
     int OptionsListId;
     ListClass OptionsListObj;
     int OptionsList2Id;
     ListClass OptionsList2Obj;
     int clearAllid;
     int clearAllidB;
     int clearAll2id;
     int clearAll2idB;
     int flag1id;
     int flag2id;
     int flag3id;
     int log1id;
     int log2id;
     int log3id;
     int log1Bid;
     int log2Bid;
     int log3Bid;
     int logType1id;
     int logType2id;
     int logType1bid;
     int logType2bid;
     int overruleId;
     int overruleIdB;
     int overruleId2;
     int overruleId2B;
     int flagRailId;
     int flagTruckId;
     int flagPullId;
     int logSourceX;
     int logSourceY;
     int logSourceType;
     SimpleList LogSourceList;

    pub LISTrafficWindowClass( GameClass tGame)
      : base( tGame, 1200, 768, 8)
    {
      this.trafficId = new int[7, 11];
      this.trafficIdB = new int[7];
      this.pullId = new int[16];
      this.pullData = new int[16];
      this.game.EditObj.layerLis_TraficWindowOpen = 1;
      this.Setup();
      this.View();
    }

    pub void Setup()
    {
    }

    pub void Dispose()
    {
      base.Dispose();
      DrawMod.TGame.EditObj.layerLis_TraficWindowOpen = 0;
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index: i32 =  0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
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
      let mut mouseCounter: i32 =  this.MouseCounter;
      for (let mut index: i32 =  0; index <= mouseCounter; index += 1)
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

    pub void View()
    {
      libName: String = "SE_Data";
      let mut stringListById1: i32 =  this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      let mut stringListById2: i32 =  this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      let mut stringListById3: i32 =  this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[405]));
      let mut stringListById4: i32 =  this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.log1id > 0)
      {
        this.RemoveSubPart(this.log1id);
        this.log1id = 0;
      }
      if (this.logType1id > 0)
      {
        this.RemoveSubPart(this.logType1id);
        this.logType1id = 0;
      }
      if (this.logType2id > 0)
      {
        this.RemoveSubPart(this.logType2id);
        this.logType2id = 0;
      }
      if (this.logType1bid > 0)
      {
        this.RemoveSubPart(this.logType1bid);
        this.logType1bid = 0;
      }
      if (this.logType2bid > 0)
      {
        this.RemoveSubPart(this.logType2bid);
        this.logType2bid = 0;
      }
      if (this.log2id > 0)
      {
        this.RemoveSubPart(this.log2id);
        this.log2id = 0;
      }
      if (this.log3id > 0)
      {
        this.RemoveSubPart(this.log3id);
        this.log3id = 0;
      }
      if (this.log1Bid > 0)
      {
        this.RemoveSubPart(this.log1Bid);
        this.log1Bid = 0;
      }
      if (this.log2Bid > 0)
      {
        this.RemoveSubPart(this.log2Bid);
        this.log2Bid = 0;
      }
      if (this.log3Bid > 0)
      {
        this.RemoveSubPart(this.log3Bid);
        this.log3Bid = 0;
      }
      if (this.clearAllid > 0)
      {
        this.RemoveSubPart(this.clearAllid);
        this.clearAllid = 0;
      }
      if (this.clearAllidB > 0)
      {
        this.RemoveSubPart(this.clearAllidB);
        this.clearAllidB = 0;
      }
      if (this.clearAll2id > 0)
      {
        this.RemoveSubPart(this.clearAll2id);
        this.clearAll2id = 0;
      }
      if (this.clearAll2idB > 0)
      {
        this.RemoveSubPart(this.clearAll2idB);
        this.clearAll2idB = 0;
      }
      if (this.flag1id > 0)
      {
        this.RemoveSubPart(this.flag1id);
        this.flag1id = 0;
      }
      if (this.flag2id > 0)
      {
        this.RemoveSubPart(this.flag2id);
        this.flag2id = 0;
      }
      if (this.flag3id > 0)
      {
        this.RemoveSubPart(this.flag3id);
        this.flag3id = 0;
      }
      if (this.overruleId > 0)
      {
        this.RemoveSubPart(this.overruleId);
        this.overruleId = 0;
      }
      if (this.overruleIdB > 0)
      {
        this.RemoveSubPart(this.overruleIdB);
        this.overruleIdB = 0;
      }
      if (this.overruleId2 > 0)
      {
        this.RemoveSubPart(this.overruleId2);
        this.overruleId2 = 0;
      }
      if (this.overruleId2B > 0)
      {
        this.RemoveSubPart(this.overruleId2B);
        this.overruleId2B = 0;
      }
      if (this.flagTruckId > 0)
      {
        this.RemoveSubPart(this.flagTruckId);
        this.flagTruckId = 0;
      }
      if (this.flagRailId > 0)
      {
        this.RemoveSubPart(this.flagRailId);
        this.flagRailId = 0;
      }
      if (this.flagPullId > 0)
      {
        this.RemoveSubPart(this.flagPullId);
        this.flagPullId = 0;
      }
      let mut index1: i32 =  0;
      int index2;
      do
      {
        if (this.trafficIdB[index1] > 0)
        {
          this.RemoveSubPart(this.trafficIdB[index1]);
          this.trafficIdB[index1] = 0;
        }
        index2 = 0;
        do
        {
          if (this.trafficId[index1, index2] > 0)
          {
            this.RemoveSubPart(this.trafficId[index1, index2]);
            this.trafficId[index1, index2] = 0;
          }
          index2 += 1;
        }
        while (index2 <= 9);
        index1 += 1;
      }
      while (index1 <= 5);
      let mut index3: i32 =  0;
      do
      {
        if (this.pullId[index3] > 0)
        {
          this.RemoveSubPart(this.pullId[index3]);
          this.pullId[index3] = 0;
        }
        index3 += 1;
      }
      while (index3 <= 15);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(1200, 768, 8);
      Graphics graphics1 = Graphics.FromImage((Image) this.OwnBitmap);
      graphics1.Clear(Color.Transparent);
      DrawMod.DrawMessFrame( this.OwnBitmap,  graphics1, 0, 0, 1200, 768);
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("Back", 160, "Click to return to main screen [Esc]",  this.OwnBitmap, 820, 680, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart( tsubpart1, 820, 680, 160, 40, 1);
      str1: String = "Blocking % Traffic Signs for " + this.game.SelectX.ToString() + "," + this.game.SelectY.ToString();
      DrawMod.DrawBlock( graphics1, 30, 20, 560, 700, 0, 0, 0, 95);
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2 = graphics1.MeasureString(str1, this.game.MarcFont2);
      DrawMod.DrawTextColouredMarc( graphics1, str1, this.game.MarcFont3,  Math.Round(365.0 - (double) sizeF2.Width / 2.0), 35, Color.White);
      DrawMod.DrawBlock( graphics1, 40, 70, 540, 40, 0, 0, 0, 80);
      tstring1: String = "Traffic Signs for:";
      DrawMod.DrawTextColouredMarc( graphics1, tstring1, this.game.MarcFont4, 50, 81, Color.White);
      str2: String = "Logistics Logs for " + this.game.SelectX.ToString() + "," + this.game.SelectY.ToString();
      DrawMod.DrawBlock( graphics1, 600, 20, 560, 640, 0, 0, 0, 95);
      sizeF2 = graphics1.MeasureString(str2, this.game.MarcFont2);
      DrawMod.DrawTextColouredMarc( graphics1, str2, this.game.MarcFont3,  Math.Round(915.0 - (double) sizeF2.Width / 2.0), 35, Color.White);
      NeighboursExtra lisTraffic = this.game.HandyFunctionsObj.GetLisTraffic(this.game.SelectX, this.game.SelectY);
      let mut x1: i32 =  160;
      let mut y1: i32 =  82;
      tDescript1: String = "Click to toggle on/off the use of Traffics Signs for specific usages. These settings are Hex-wide and apply to all directions.";
      if (lisTraffic.truck)
      {
        let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript1);
        this.flagTruckId = this.AddSubPart( tsubpart2, x1, y1, 32, 16, 1);
      }
      else
      {
        let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript1);
        this.flagTruckId = this.AddSubPart( tsubpart3, x1, y1, 32, 16, 1);
      }
      tstring2: String = "Truck Logistics";
      DrawMod.DrawTextColouredMarc( graphics1, tstring2, this.game.MarcFont4, x1 + 44, y1 - 2, Color.White);
      let mut x2: i32 =  x1 + 150;
      tDescript2: String = "Click to toggle on/off the use of Traffics Signs for specific usages. These settings are Hex-wide and apply to all directions.";
      if (lisTraffic.rail)
      {
        let mut tsubpart4: SubPartClass =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript2);
        this.flagRailId = this.AddSubPart( tsubpart4, x2, y1, 32, 16, 1);
      }
      else
      {
        let mut tsubpart5: SubPartClass =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript2);
        this.flagRailId = this.AddSubPart( tsubpart5, x2, y1, 32, 16, 1);
      }
      tstring3: String = "Rail Logistics";
      DrawMod.DrawTextColouredMarc( graphics1, tstring3, this.game.MarcFont4, x2 + 44, y1 - 2, Color.White);
      let mut x3: i32 =  x2 + 140;
      tDescript3: String = "Click to toggle on/off the use of Traffics Signs for specific usages. These settings are Hex-wide and apply to all directions.";
      if (lisTraffic.pull)
      {
        let mut tsubpart6: SubPartClass =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript3);
        this.flagPullId = this.AddSubPart( tsubpart6, x3, y1, 32, 16, 1);
      }
      else
      {
        let mut tsubpart7: SubPartClass =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript3);
        this.flagPullId = this.AddSubPart( tsubpart7, x3, y1, 32, 16, 1);
      }
      tstring4: String = "Pull Points";
      DrawMod.DrawTextColouredMarc( graphics1, tstring4, this.game.MarcFont4, x3 + 44, y1 - 2, Color.White);
      let mut x4: i32 =  182;
      let mut y2: i32 =  200;
      let mut num1: i32 =  this.game.SelectX;
      let mut selectY: i32 =  this.game.SelectY;
      let mut hideUnit: i32 =  this.game.EditObj.HideUnit;
      bool showLabel = this.game.EditObj.ShowLabel;
      bool layerLisAvailable = this.game.EditObj.layerLisAvailable;
      bool layerLisUsed = this.game.EditObj.layerLisUsed;
      bool layerLisTotal = this.game.EditObj.layerLisTotal;
      bool layerLisBottlenecks = this.game.EditObj.layerLisBottlenecks;
      this.game.EditObj.HideUnit = 0;
      this.game.EditObj.ShowLabel = false;
      this.game.EditObj.layerLisAvailable = false;
      this.game.EditObj.layerLisUsed = false;
      this.game.EditObj.layerLisTotal = true;
      this.game.EditObj.layerLisBottlenecks = false;
      this.game.SelectX = -1;
      this.game.SelectY = -1;
      Bitmap objBitmap = new Bitmap(128, 96, PixelFormat.Format32bppPArgb);
      objBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics2 = Graphics.FromImage((Image) objBitmap);
      CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
      let mut cx: i32 =  num1;
      let mut cy: i32 =  selectY;
      Graphics tempg = graphics2;
      Bitmap bitmap = (Bitmap) null;
       let mut local1: &Bitmap = &bitmap;
      bool flag1 = false;
       bool local2 =  flag1;
      customBitmapObj.DrawHex(cx, cy, 0, tempg: tempg, counteralpha: 0, Zoom: 1, neverusehistory: true, gBitmap: ( local1), tFromMapPopup: ( local2));
      DrawMod.DrawScaled( graphics1,  objBitmap, x4, y2, 256, 192, true);
      objBitmap.Dispose();
      graphics2.Dispose();
      this.game.SelectX = num1;
      this.game.SelectY = selectY;
      this.game.EditObj.HideUnit = hideUnit;
      this.game.EditObj.ShowLabel = showLabel;
      this.game.EditObj.layerLisAvailable = layerLisAvailable;
      this.game.EditObj.layerLisUsed = layerLisUsed;
      this.game.EditObj.layerLisTotal = layerLisTotal;
      this.game.EditObj.layerLisBottlenecks = layerLisBottlenecks;
      let mut num2: i32 =  0;
      let mut num3: i32 =  0;
      let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
      for (let mut index4: i32 =  0; index4 <= mapWidth; index4 += 1)
      {
        let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
        for (let mut index5: i32 =  0; index5 <= mapHeight; index5 += 1)
        {
          if (this.game.Data.RegimeObj[this.game.Data.Turn].Trafic[0].Value[index4, index5] > 1000000)
            num2 += 1;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[index4, index5] != 0)
            num3 += 1;
        }
      }
      DrawMod.DrawBlock( graphics1, x4 + 218, 500, 180, 210, 0, 0, 0, 80);
      tstring5: String = "Global Ops";
      DrawMod.DrawTextColouredMarcCenter( graphics1, tstring5, this.game.MarcFont4, x4 + 218 + 90, 513, Color.White);
      let mut num4: i32 =  y2;
      let mut num5: i32 =  540;
      SubPartClass tsubpart8;
      if (num2 > 0)
      {
        let mut tsubpart9: SubPartClass =  new TextButtonPartClass("Clear all " + num2.ToString() + " Signs", 160, "Click to clear all " + num2.ToString() + " Traffic Signs on the whole map.",  this.OwnBitmap, x4 + 228, num5, theight: 32, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.clearAllid = this.AddSubPart( tsubpart9, x4 + 228, num5, 160, 32, 1);
      }
      else
      {
        tsubpart8 =  new TextButtonPartClass("Clear all Signs", 160, "You cannot clear all Traffic Signs because you do not have any Traffic Signs placed on the map.",  this.OwnBitmap, x4 + 228, num5, true, theight: 32, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.clearAllid = this.AddSubPart( tsubpart8, x4 + 228, num5, 160, 32, 0);
      }
      let mut num6: i32 =  num5 + 32 + 5;
      if ( Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage)
      {
        if (num3 > 0)
        {
          tsubpart8 =  new TextButtonPartClass("Clear " + num3.ToString() + " Custom Pulls", 160, "Click to clear all " + num3.ToString() + " Custom Pull Points on the whole map.",  this.OwnBitmap, x4 + 228, num6, theight: 32, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.clearAll2id = this.AddSubPart( tsubpart8, x4 + 228, num6, 160, 32, 1);
        }
        else
        {
          tsubpart8 =  new TextButtonPartClass("Clear all Custom Pulls", 160, "You cannot clear Custom Pull Points because you have not placed any.",  this.OwnBitmap, x4 + 228, num6, true, theight: 32, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.clearAll2id = this.AddSubPart( tsubpart8, x4 + 228, num6, 160, 32, 0);
        }
        let mut y3: i32 =  num6 + 32 + 4 + 5;
        tDescript4: String = "Click to toggle on/off the use of Automatic Asset Pull Points. Red Flagged means its toggled on. White means its toggled off.";
        if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullAssetsOff", 2))) < 1)
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript4);
          this.flag1id = this.AddSubPart( tsubpart8, x4 + 228, y3, 32, 16, 1);
        }
        else
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript4);
          this.flag1id = this.AddSubPart( tsubpart8, x4 + 228, y3, 32, 16, 1);
        }
        tstring6: String = "Asset Pull Pts";
        DrawMod.DrawTextColouredMarc( graphics1, tstring6, this.game.MarcFont4, x4 + 228 + 40, y3, Color.White);
        let mut y4: i32 =  y3 + 20 + 5;
        tDescript5: String = "Click to toggle on/off the use of Automatic Unit Pull Points. Red Flagged means its toggled on. White means its toggled off.";
        if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullUnitsOff", 2))) < 1)
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript5);
          this.flag2id = this.AddSubPart( tsubpart8, x4 + 228, y4, 32, 16, 1);
        }
        else
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript5);
          this.flag2id = this.AddSubPart( tsubpart8, x4 + 228, y4, 32, 16, 1);
        }
        tstring7: String = "Unit Pull Pts";
        DrawMod.DrawTextColouredMarc( graphics1, tstring7, this.game.MarcFont4, x4 + 228 + 40, y4, Color.White);
        let mut y5: i32 =  y4 + 20 + 5;
        tDescript6: String = "Click to toggle on/off the use of Automatic Unit Pull Points. Red Flagged means its toggled on. White means its toggled off.\"";
        num1 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullCitiesOff", 2)));
        if (num1 < 1)
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript6);
          this.flag3id = this.AddSubPart( tsubpart8, x4 + 228, y5, 32, 16, 1);
        }
        else
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript6);
          this.flag3id = this.AddSubPart( tsubpart8, x4 + 228, y5, 32, 16, 1);
        }
        tstring8: String = "City Pull Pts";
        DrawMod.DrawTextColouredMarc( graphics1, tstring8, this.game.MarcFont4, x4 + 228 + 40, y5, Color.White);
      }
      let mut num7: i32 =  num4;
      DrawMod.DrawBlock( graphics1, 40, 500, 340, 210, 0, 0, 0, 80);
      str3: String = "Custom Pull Points";
      DrawMod.DrawTextColouredMarcCenter( graphics1, str3, this.game.MarcFont4, 210, 513, Color.White);
      let mut num8: i32 =  50;
      let mut y1_1: i32 =  540;
      Color color;
      if ( Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage)
      {
        index2 = 0;
        do
        {
          if (index2 == 0)
          {
            str3 = "Block";
            num1 = -1;
          }
          if (index2 == 1)
          {
            str3 = "None";
            num1 = 0;
          }
          if (index2 == 2)
          {
            str3 = "50";
            num1 = 50;
          }
          if (index2 == 3)
          {
            str3 = "100";
            num1 = 100;
          }
          if (index2 == 4)
          {
            str3 = "200";
            num1 = 200;
          }
          if (index2 == 5)
          {
            str3 = "500";
            num1 = 500;
          }
          if (index2 == 6)
          {
            str3 = "1K";
            num1 = 1000;
          }
          if (index2 == 7)
          {
            str3 = "2K";
            num1 = 2000;
          }
          if (index2 == 8)
          {
            str3 = "3K";
            num1 = 3000;
          }
          if (index2 == 9)
          {
            str3 = "5K";
            num1 = 5000;
          }
          if (index2 == 10)
          {
            str3 = "8K";
            num1 = 8000;
          }
          if (index2 == 11)
          {
            str3 = "12K";
            num1 = 12000;
          }
          if (index2 == 12)
          {
            str3 = "20K";
            num1 = 20000;
          }
          if (index2 == 13)
          {
            str3 = "30K";
            num1 = 30000;
          }
          if (index2 == 14)
          {
            str3 = "50K";
            num1 = 50000;
          }
          if (index2 == 0)
            color = Color.Red;
          if (index2 == 1)
            color = Color.Gray;
          if (index2 >= 2 & index2 <= 5)
            color = Color.White;
          if (index2 >= 6)
            color = Color.LightBlue;
          int num9;
          int num10;
          if (index2 <= 4)
          {
            num9 = num8 + index2 * 65;
            num10 = y1_1;
          }
          else if (index2 <= 9)
          {
            num9 = num8 + (index2 - 5) * 65;
            num10 = y1_1 + 42;
          }
          else if (index2 <= 14)
          {
            num9 = num8 + (index2 - 10) * 65;
            num10 = y1_1 + 84;
          }
          bool flag2 = false;
          let mut num11: i32 =  this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY];
          if (num11 != -1)
            num11 = Math.Abs(num11);
          if (num11 == num1)
            flag2 = true;
          if (flag2)
          {
            color = Color.FromArgb(150,  color.R,  color.G,  color.B);
            DrawMod.DrawBlock( graphics1, num9, num10, 56, 35,  color.R,  color.G,  color.B,  color.A);
            DrawMod.DrawTextColouredMarcCenter( graphics1, str3, this.game.MarcFont4, num9 + 19 + 10, num10 + 11, Color.White);
          }
          else
          {
            if (index2 == 1)
              color = Color.LightGray;
            tDescript7: String = "Click to set " + str3 + " Custom Pull Points on this Hex.";
            if (num1 == -1)
              tDescript7 = "Click to not allow any Asset,City or Unit Pull Points on this Hex.";
            if (num1 == 0)
              tDescript7 = "Click to remove Custom Pull Point settings from Hex.";
            int[] pullId = this.pullId;
            let mut index6: i32 =  index2;
            tsubpart8 =  new TextButtonPartClass(str3, 60, tDescript7,  this.OwnBitmap, num9, num10, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true, toverrulered: ( color.R), toverrulegreen: ( color.G), toverruleblue: ( color.B));
            let mut num12: i32 =  this.AddSubPart( tsubpart8, num9, num10, 60, 40, 1);
            pullId[index6] = num12;
            this.pullData[index2] = num1;
          }
          index2 += 1;
        }
        while (index2 <= 14);
        if (this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY] != 0)
        {
          tDescript8: String = "If Custom Pull Points are set to Addition Mode they'll be added to any Automatic Pull Points. If they are set to Overrule Mode they'll be the only Pull Points place on the Hex and any Automatic Pull Points will be ignored.";
          let mut num13: i32 =  this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY];
          if (num13 >= 0)
          {
            tsubpart8 =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript8);
            this.overruleId = this.AddSubPart( tsubpart8, num8 + 12, y1_1 + 138, 32, 16, 1);
          }
          else
          {
            tsubpart8 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript8);
            this.overruleId = this.AddSubPart( tsubpart8, num8 + 12, y1_1 + 138, 32, 16, 1);
          }
          tstring9: String = "Addition Mode";
          DrawMod.DrawTextColouredMarc( graphics1, tstring9, this.game.MarcFont4, num8 + 50, y1_1 + 136, Color.White);
          tDescript9: String = "If Custom Pull Points are set to Addition Mode they'll be added to any Automatic Pull Points. If they are set to Overrule Mode they'll be the only Pull Points place on the Hex and any Automatic Pull Points will be ignored.";
          if (num13 <= -1)
          {
            tsubpart8 =  ButtonPartClass::new(this.game.BUTTONFLAGGED, tDescript: tDescript9);
            this.overruleId2 = this.AddSubPart( tsubpart8, num8 + 12 + 160, y1_1 + 138, 32, 16, 1);
          }
          else
          {
            tsubpart8 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED, tDescript: tDescript9);
            this.overruleId2 = this.AddSubPart( tsubpart8, num8 + 12 + 160, y1_1 + 138, 32, 16, 1);
          }
          str3 = "Overrule Mode";
          DrawMod.DrawTextColouredMarc( graphics1, str3, this.game.MarcFont4, num8 + 50 + 160, y1_1 + 136, Color.White);
        }
      }
      else
      {
        tstring10: String = "Start a new game";
        DrawMod.DrawTextColouredMarcCenter( graphics1, tstring10, this.game.MarcFont4, 210, 543, Color.Yellow);
        str3 = "for this feature";
        DrawMod.DrawTextColouredMarcCenter( graphics1, str3, this.game.MarcFont4, 210, 583, Color.Yellow);
      }
      let mut index7: i32 =  0;
      do
      {
        let mut x1_1: i32 =  0;
        if (index7 == 0)
        {
          x1_1 = x4 + 128 - 80;
          y1_1 = num7 - 80;
        }
        if (index7 == 1)
        {
          x1_1 = x4 + 256 - 16;
          y1_1 = num7 + 16;
        }
        if (index7 == 2)
        {
          x1_1 = x4 + 256 - 16;
          y1_1 = num7 + 16 + 96;
        }
        if (index7 == 3)
        {
          x1_1 = x4 + 128 - 80;
          y1_1 = num7 + 192 + 16;
        }
        if (index7 == 4)
        {
          x1_1 = x4 - 160 + 16;
          y1_1 = num7 + 16 + 96;
        }
        if (index7 == 5)
        {
          x1_1 = x4 - 160 + 16;
          y1_1 = num7 + 16;
        }
        if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].RoadType[index7] > -1 & x1_1 > 0)
        {
          index2 = 0;
          do
          {
            if (index2 == 0)
              str3 = "None";
            if (index2 == 1)
              str3 = "20%";
            if (index2 == 2)
              str3 = "40%";
            if (index2 == 3)
              str3 = "60%";
            if (index2 == 4)
              str3 = "80%";
            if (index2 == 5)
              str3 = "90%";
            if (index2 == 6)
              str3 = "95%";
            if (index2 == 7)
              str3 = "All";
            if (index2 == 0)
              color = Color.White;
            if (index2 == 1)
              color = Color.FromArgb( byte.MaxValue, 125,  byte.MaxValue, 125);
            if (index2 == 2)
              color = Color.FromArgb( byte.MaxValue, 0,  byte.MaxValue, 0);
            if (index2 == 3)
              color = Color.FromArgb( byte.MaxValue, 64, 152, 0);
            if (index2 == 4)
              color = Color.FromArgb( byte.MaxValue, 152, 152, 0);
            if (index2 == 5)
              color = Color.FromArgb( byte.MaxValue, 192, 128, 0);
            if (index2 == 6)
              color = Color.FromArgb( byte.MaxValue, 192, 64, 0);
            if (index2 == 7)
              color = Color.FromArgb( byte.MaxValue,  byte.MaxValue, 0, 100);
            int num14;
            int num15;
            if (index2 <= 3)
            {
              num14 = x1_1 + index2 * 40;
              num15 = y1_1;
            }
            else
            {
              num14 = x1_1 + (index2 - 4) * 40;
              num15 = y1_1 + 40;
            }
            bool flag3 = false;
            if (lisTraffic.data[index7] == index2)
              flag3 = true;
            if (flag3)
            {
              color = Color.FromArgb(100,  color.R,  color.G,  color.B);
              if (index2 == 0)
                color = Color.Gray;
              DrawMod.DrawBlock( graphics1, num14, num15, 36, 35,  color.R,  color.G,  color.B,  color.A);
              DrawMod.DrawTextColouredMarcCenter( graphics1, str3, this.game.MarcFont4, num14 + 19, num15 + 10, Color.White);
            }
            else
            {
              int[,] trafficId = this.trafficId;
              let mut index8: i32 =  index7;
              let mut index9: i32 =  index2;
              tsubpart8 =  new TextButtonPartClass(str3, 40, "Click to use Traffic Sign to stop " + str3 + " of logistical points leaving the Hex in this direction.",  this.OwnBitmap, num14, num15, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true, toverrulered: ( color.R), toverrulegreen: ( color.G), toverruleblue: ( color.B));
              let mut num16: i32 =  this.AddSubPart( tsubpart8, num14, num15, 40, 40, 1);
              trafficId[index8, index9] = num16;
            }
            index2 += 1;
          }
          while (index2 <= 7);
        }
        else
        {
          let mut num17: i32 =  x1_1 + index2 * 40;
          DrawMod.DrawBlock( graphics1, x1_1, y1_1, 160, 80, 0, 0, 0, 80);
          str3 = "No Road";
          DrawMod.DrawTextColouredMarcCenter( graphics1, str3, this.game.MarcFont4, x1_1 + 80, y1_1 + 30, Color.LightGray);
        }
        index7 += 1;
      }
      while (index7 <= 5);
      if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 505, 0, 0))].Width < 7)
      {
        tstring11: String = "Start a new game to re-enable this logs functionality. ";
        DrawMod.DrawTextColouredMarcCenter( graphics1, tstring11, this.game.MarcFont4, 770, 90, Color.LightGray);
      }
      else
      {
        let mut num18: i32 =  620;
        let mut num19: i32 =  90;
        tsubpart8 =  new TextButtonPartClass("Start Turn Log", 120, "Shows the Logistical Points generated on this Hex during start of turn.",  this.OwnBitmap, num18, num19, tred: (this.game.EditObj.layerLisPreview_LogMode == 0), theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.log1id = this.AddSubPart( tsubpart8, num18, num19, 120, 40, 1);
        let mut num20: i32 =  num18 + 130;
        if (this.game.EditObj.layerLisPreview)
        {
          tsubpart8 =  new TextButtonPartClass("Preview Log", 120, "Shows the Logistical Points that will be generated start of next turn.",  this.OwnBitmap, num20, num19, tred: (this.game.EditObj.layerLisPreview_LogMode == 1), theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.log2id = this.AddSubPart( tsubpart8, num20, num19, 120, 40, 1);
        }
        else
        {
          tsubpart8 =  new TextButtonPartClass("Preview Log", 120, "You have to activate the Preview Pts layer to inspect the Preview Logistics Log.",  this.OwnBitmap, num20, num19, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.log2Bid = this.AddSubPart( tsubpart8, num20, num19, 120, 40, 0);
        }
        let mut num21: i32 =  num20 + 130;
        if (this.game.EditObj.layerLisPreview & this.game.EditObj.layerLisOnlyAssetId > 0 & !this.game.EditObj.layerLisOnlyAssetId_isSupplyBase)
        {
          let mut idValue: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(9, this.game.EditObj.layerLisOnlyAssetId, 1)));
          let mut num22: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(9, this.game.EditObj.layerLisOnlyAssetId, 3)));
          let mut num23: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(9, this.game.EditObj.layerLisOnlyAssetId, 4)));
          str4: String = this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 12);
          let mut nr: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 2)));
          if (nr > 0)
            str4 = str4 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
          tsubpart8 =  new TextButtonPartClass("Preview " + (str4 + " (" + num22.ToString() + "," + num23.ToString() + ")") + " Log", 260, "Shows the Logistical Points that will be generated by this specific Asset at the start of next turn.",  this.OwnBitmap, num21, num19, tred: (this.game.EditObj.layerLisPreview_LogMode == 2), theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.log3id = this.AddSubPart( tsubpart8, num21, num19, 260, 40, 1);
        }
        else if (this.game.EditObj.layerLisOnlyAssetId > 0 & this.game.EditObj.layerLisOnlyAssetId_isSupplyBase)
        {
          tsubpart8 =  new TextButtonPartClass("Preview Asset Log", 260, "Supply Bases do not generate Logistical Points logs.",  this.OwnBitmap, num21, num19, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.log3Bid = this.AddSubPart( tsubpart8, num21, num19, 260, 40, 0);
        }
        else
        {
          tsubpart8 =  new TextButtonPartClass("Preview Asset Log", 260, "You have to activate the Preview Pts layer and select a specific Asset to inspect the Preview Logistics Log.",  this.OwnBitmap, num21, num19, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.log3Bid = this.AddSubPart( tsubpart8, num21, num19, 260, 40, 0);
        }
        let mut num24: i32 =  620;
        let mut num25: i32 =  140;
        let mut num26: i32 =  0;
        if (this.game.EditObj.layerLisPreview_LogMode <= 1)
        {
          tsubpart8 =  new TextButtonPartClass("All Logs", 200, "Shows all the Logs for this Hex.",  this.OwnBitmap, num24, num25, tred: (this.game.EditObj.layerLis_LogType == 0), theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.logType1id = this.AddSubPart( tsubpart8, num24, num25, 200, 40, 1);
          let mut num27: i32 =  num24 + 220;
          tsubpart8 =  new TextButtonPartClass("Logs per Source Hex", 200, "Shows the Logs but selectable per Logistical Points Source Hex.",  this.OwnBitmap, num27, num25, tred: (this.game.EditObj.layerLis_LogType == 1), theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.logType2id = this.AddSubPart( tsubpart8, num27, num25, 200, 40, 1);
          num26 = 2;
          num25 += 50;
          num24 = 620;
        }
        else
          this.game.EditObj.layerLis_LogType = 0;
        let mut index10: i32 =  0;
        if (this.game.EditObj.layerLisPreview_LogMode < 1)
          index10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 505, 0, 0));
        else if (this.game.EditObj.layerLisPreview_LogMode == 1)
          index10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 511, 0, 0));
        else if (this.game.EditObj.layerLisPreview_LogMode == 2)
          index10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 512, 0, 0));
        if (index10 <= -1)
          return;
        let mut num28: i32 =  520;
        this.LogSourceList = SimpleList::new();
        if (this.game.EditObj.layerLis_LogType == 1)
        {
          let mut length: i32 =  this.game.Data.StringListObj[index10].Length;
          for (let mut index11: i32 =  0; index11 <= length; index11 += 1)
          {
            if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[index11, 0])) == this.game.SelectX &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[index11, 1])) == this.game.SelectY)
            {
              let mut tdata1: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[index11, 5]));
              if (tdata1 > -1)
              {
                let mut tdata2: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[index11, 6]));
                let mut tdata3: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[index11, 7]));
                let mut tid: i32 =  tdata3 * 1000000 + tdata1 * 1000 + tdata2;
                if (tdata3 >= 1 & tdata3 <= 2)
                  this.LogSourceList.AddWeight(tid, 1, tdata1, tdata2, tdata3);
              }
            }
          }
          this.OptionsListObj = ListClass::new();
          let mut num29: i32 =  -1;
          let mut tlistselect: i32 =  -1;
          let mut counter: i32 =  this.LogSourceList.Counter;
          for (let mut index12: i32 =  0; index12 <= counter; index12 += 1)
          {
            num29 += 1;
            this.OptionsListObj.add(this.game.Data.StringListObj[stringListById3].GetData(0, this.LogSourceList.Data3[index12], 1) + " (" + this.LogSourceList.Data1[index12].ToString() + "," + this.LogSourceList.Data2[index12].ToString() + ")", this.LogSourceList.Id[index12]);
            if (this.LogSourceList.Data1[index12] == this.logSourceX & this.LogSourceList.Data2[index12] == this.logSourceY & this.LogSourceList.Data3[index12] == this.logSourceType)
              tlistselect = num29;
          }
          if (tlistselect == -1)
          {
            tlistselect = 0;
            if (this.LogSourceList.Counter >= 0)
            {
              this.logSourceX = this.LogSourceList.Data1[0];
              this.logSourceY = this.LogSourceList.Data2[0];
              this.logSourceType = this.LogSourceList.Data3[0];
            }
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            tsubpart8 =  new ListSubPartClass(this.OptionsListObj, 22 - num26, 120, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num24, bby: num25, tMarcStyle: true, overruleFont: ( this.game.MarcFont7), overruleItemSize: 20);
            this.OptionsListId = this.AddSubPart( tsubpart8, num24, num25, 120, 20 * (21 - num26), 0);
          }
          num28 -= 130;
          num24 += 130;
          if (this.OptionsList2Id > 0)
          {
            this.RemoveSubPart(this.OptionsList2Id);
            this.OptionsList2Id = 0;
          }
        }
        else if (this.OptionsListId > 0)
        {
          this.RemoveSubPart(this.OptionsListId);
          this.OptionsListId = 0;
        }
        this.OptionsList2Obj = ListClass::new();
        let mut length1: i32 =  this.game.Data.StringListObj[index10].Length;
        for (let mut tdata: i32 =  0; tdata <= length1; tdata += 1)
        {
          if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[tdata, 0])) == this.game.SelectX &&  Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[tdata, 1])) == this.game.SelectY)
          {
            tname: String = this.game.Data.StringListObj[index10].Data[tdata, 4];
            if (this.game.EditObj.layerLis_LogType < 1)
            {
              this.OptionsList2Obj.add(tname, tdata);
            }
            else
            {
              let mut num30: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[tdata, 5]));
              let mut num31: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[tdata, 6]));
              let mut num32: i32 =   Math.Round(Conversion.Val(this.game.Data.StringListObj[index10].Data[tdata, 7]));
              if (num30 == this.logSourceX & num31 == this.logSourceY & (num32 == this.logSourceType | num32 == 0))
                this.OptionsList2Obj.add(tname, tdata);
            }
          }
        }
        if (this.OptionsList2Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
        }
        else
        {
          tsubpart8 =  new ListSubPartClass(this.OptionsList2Obj, 22 - num26, num28, -1, this.game, tHeaderCenter: false, tHighlight: false, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num24, bby: num25, tMarcStyle: true, overruleFont: ( this.game.MarcFont7), overruleItemSize: 20);
          this.OptionsList2Id = this.AddSubPart( tsubpart8, num24, num25, num28, 20 * (21 - num26), 0);
        }
      }
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27)
        {
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
label_197:
        for (let mut index1: i32 =  0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut num1: i32 =  this.SubPartID[index1];
            if (num1 == this.logType1id)
            {
              this.game.EditObj.layerLis_LogType = 0;
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.logType2id)
            {
              this.game.EditObj.layerLis_LogType = 1;
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.log1id)
            {
              this.game.EditObj.layerLisPreview_LogMode = 0;
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.log2id)
            {
              this.game.EditObj.layerLisPreview_LogMode = 1;
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.log3id)
            {
              this.game.EditObj.layerLisPreview_LogMode = 2;
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.okid)
            {
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList2Id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              let mut tid: i32 =  this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (tid > 0)
              {
                let mut nr: i32 =  this.LogSourceList.FindNr(tid);
                if (nr > -1)
                {
                  this.logSourceX = this.LogSourceList.Data1[nr];
                  this.logSourceY = this.LogSourceList.Data2[nr];
                  this.logSourceType = this.LogSourceList.Data3[nr];
                  if (this.OptionsList2Id > 0)
                  {
                    this.RemoveSubPart(this.OptionsList2Id);
                    this.OptionsList2Id = 0;
                  }
                }
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.clearAll2id)
            {
              let mut mapWidth1: i32 =  this.game.Data.MapObj[0].MapWidth;
              for (let mut index2: i32 =  0; index2 <= mapWidth1; index2 += 1)
              {
                let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                for (let mut index3: i32 =  0; index3 <= mapHeight; index3 += 1)
                {
                  let mut num2: i32 =  0;
                  do
                  {
                    this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[index2, index3] = 0;
                    num2 += 1;
                  }
                  while (num2 <= 8);
                }
              }
              if (this.game.EditObj.layerLisPreview)
              {
                let mut mapWidth2: i32 =  this.game.Data.MapObj[0].MapWidth;
                for (let mut index4: i32 =  0; index4 <= mapWidth2; index4 += 1)
                {
                  let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                  for (let mut index5: i32 =  0; index5 <= mapHeight; index5 += 1)
                  {
                    let mut index6: i32 =  0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[index4, index5].tempPreviewLIS[index6] = 0;
                      this.game.Data.MapObj[0].HexObj[index4, index5].tempPreviewAssetLIS[index6] = 0;
                      index6 += 1;
                    }
                    while (index6 <= 8);
                  }
                }
                this.game.ProcessingObj.LIS_SetNetwork(false, true);
                if (this.game.EditObj.layerLisOnlyAssetId > 0)
                  this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.flag1id || num1 == this.flag2id || num1 == this.flag3id)
            {
              let mut stringListById: i32 =  this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
              if (this.flag1id == this.SubPartID[index1])
              {
                int setValue;
                if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullAssetsOff", 2))) == 0)
                {
                  setValue = 1;
                  this.game.EditObj.usePullAssets = false;
                }
                else
                {
                  setValue = 0;
                  this.game.EditObj.usePullAssets = true;
                }
                this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullAssetsOff", 2, setValue, true);
              }
              if (this.flag2id == this.SubPartID[index1])
              {
                int setValue;
                if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullUnitsOff", 2))) == 0)
                {
                  setValue = 1;
                  this.game.EditObj.usePullUnits = false;
                }
                else
                {
                  setValue = 0;
                  this.game.EditObj.usePullUnits = true;
                }
                this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullUnitsOff", 2, setValue, true);
              }
              if (this.flag3id == this.SubPartID[index1])
              {
                int setValue;
                if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullCitiesOff", 2))) == 0)
                {
                  setValue = 1;
                  this.game.EditObj.usePullCities = false;
                }
                else
                {
                  setValue = 0;
                  this.game.EditObj.usePullCities = true;
                }
                this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullCitiesOff", 2, setValue, true);
              }
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              if (this.game.EditObj.layerLisPreview)
              {
                let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
                for (let mut index7: i32 =  0; index7 <= mapWidth; index7 += 1)
                {
                  let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                  for (let mut index8: i32 =  0; index8 <= mapHeight; index8 += 1)
                  {
                    let mut index9: i32 =  0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[index7, index8].tempPreviewLIS[index9] = 0;
                      this.game.Data.MapObj[0].HexObj[index7, index8].tempPreviewAssetLIS[index9] = 0;
                      index9 += 1;
                    }
                    while (index9 <= 8);
                  }
                }
                this.game.ProcessingObj.LIS_SetNetwork(false, true);
                if (this.game.EditObj.layerLisOnlyAssetId > 0)
                  this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.clearAllid)
            {
              let mut mapWidth3: i32 =  this.game.Data.MapObj[0].MapWidth;
              for (let mut index10: i32 =  0; index10 <= mapWidth3; index10 += 1)
              {
                let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                for (let mut index11: i32 =  0; index11 <= mapHeight; index11 += 1)
                {
                  let mut num3: i32 =  0;
                  do
                  {
                    this.game.Data.RegimeObj[this.game.Data.Turn].Trafic[0].Value[index10, index11] = 0;
                    num3 += 1;
                  }
                  while (num3 <= 8);
                }
              }
              if (this.game.EditObj.layerLisPreview)
              {
                let mut mapWidth4: i32 =  this.game.Data.MapObj[0].MapWidth;
                for (let mut index12: i32 =  0; index12 <= mapWidth4; index12 += 1)
                {
                  let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                  for (let mut index13: i32 =  0; index13 <= mapHeight; index13 += 1)
                  {
                    let mut index14: i32 =  0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[index12, index13].tempPreviewLIS[index14] = 0;
                      this.game.Data.MapObj[0].HexObj[index12, index13].tempPreviewAssetLIS[index14] = 0;
                      index14 += 1;
                    }
                    while (index14 <= 8);
                  }
                }
                this.game.ProcessingObj.LIS_SetNetwork(false, true);
                if (this.game.EditObj.layerLisOnlyAssetId > 0)
                  this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.flagTruckId || num1 == this.flagRailId || num1 == this.flagPullId)
            {
              NeighboursExtra lisTraffic = this.game.HandyFunctionsObj.GetLisTraffic(this.game.SelectX, this.game.SelectY);
              if (this.flagTruckId == this.SubPartID[index1])
                lisTraffic.truck = !lisTraffic.truck;
              else if (this.flagRailId == this.SubPartID[index1])
                lisTraffic.rail = !lisTraffic.rail;
              else if (this.flagPullId == this.SubPartID[index1])
                lisTraffic.pull = !lisTraffic.pull;
              this.game.HandyFunctionsObj.SetLisTraffic(this.game.SelectX, this.game.SelectY, lisTraffic);
              if (this.game.EditObj.layerLisPreview)
              {
                let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
                for (let mut index15: i32 =  0; index15 <= mapWidth; index15 += 1)
                {
                  let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                  for (let mut index16: i32 =  0; index16 <= mapHeight; index16 += 1)
                  {
                    let mut index17: i32 =  0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[index15, index16].tempPreviewLIS[index17] = 0;
                      this.game.Data.MapObj[0].HexObj[index15, index16].tempPreviewAssetLIS[index17] = 0;
                      index17 += 1;
                    }
                    while (index17 <= 8);
                  }
                }
                this.game.ProcessingObj.LIS_SetNetwork(false, true);
                if (this.game.EditObj.layerLisOnlyAssetId > 0)
                  this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.overruleId || num1 == this.overruleId2)
            {
              let mut num4: i32 =  this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY];
              switch (num4)
              {
                case -1:
                case 0:
                  this.Setup();
                  this.View();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                default:
                  this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY] = this.overruleId != this.SubPartID[index1] ? -Math.Abs(num4) : Math.Abs(num4);
                  if (this.game.EditObj.layerLisPreview)
                  {
                    let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
                    for (let mut index18: i32 =  0; index18 <= mapWidth; index18 += 1)
                    {
                      let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                      for (let mut index19: i32 =  0; index19 <= mapHeight; index19 += 1)
                      {
                        let mut index20: i32 =  0;
                        do
                        {
                          this.game.Data.MapObj[0].HexObj[index18, index19].tempPreviewLIS[index20] = 0;
                          this.game.Data.MapObj[0].HexObj[index18, index19].tempPreviewAssetLIS[index20] = 0;
                          index20 += 1;
                        }
                        while (index20 <= 8);
                      }
                    }
                    this.game.ProcessingObj.LIS_SetNetwork(false, true);
                    if (this.game.EditObj.layerLisOnlyAssetId > 0)
                    {
                      this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
                      goto case -1;
                    }
                    else
                      goto case -1;
                  }
                  else
                    goto case -1;
              }
            }
            else
            {
              let mut index21: i32 =  0;
label_143:
              let mut index22: i32 =  0;
              while (this.trafficId[index21, index22] != this.SubPartID[index1])
              {
                index22 += 1;
                if (index22 > 7)
                {
                  index21 += 1;
                  if (index21 > 5)
                  {
                    let mut index23: i32 =  0;
label_160:
                    let mut index24: i32 =  0;
                    while (this.trafficId[index23, index24] != this.SubPartID[index1])
                    {
                      index24 += 1;
                      if (index24 > 7)
                      {
                        index23 += 1;
                        if (index23 > 5)
                        {
                          let mut index25: i32 =  0;
                          while (this.SubPartID[index1] != this.pullId[index25])
                          {
                            index25 += 1;
                            if (index25 > 15)
                              goto label_197;
                          }
                          if (this.pullData[index25] == -1)
                            this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY] = this.pullData[index25];
                          else if (this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY] <= -1)
                            this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY] = -this.pullData[index25];
                          else
                            this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[this.game.SelectX, this.game.SelectY] = this.pullData[index25];
                          if (this.game.EditObj.layerLisPreview)
                          {
                            let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
                            for (let mut index26: i32 =  0; index26 <= mapWidth; index26 += 1)
                            {
                              let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                              for (let mut index27: i32 =  0; index27 <= mapHeight; index27 += 1)
                              {
                                let mut index28: i32 =  0;
                                do
                                {
                                  this.game.Data.MapObj[0].HexObj[index26, index27].tempPreviewLIS[index28] = 0;
                                  this.game.Data.MapObj[0].HexObj[index26, index27].tempPreviewAssetLIS[index28] = 0;
                                  index28 += 1;
                                }
                                while (index28 <= 8);
                              }
                            }
                            this.game.ProcessingObj.LIS_SetNetwork(false, true);
                            if (this.game.EditObj.layerLisOnlyAssetId > 0)
                              this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
                          }
                          this.Setup();
                          this.View();
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        goto label_160;
                      }
                    }
                    NeighboursExtra lisTraffic = this.game.HandyFunctionsObj.GetLisTraffic(this.game.SelectX, this.game.SelectY);
                    lisTraffic.data[index23] = index24;
                    this.game.HandyFunctionsObj.SetLisTraffic(this.game.SelectX, this.game.SelectY, lisTraffic);
                    if (this.game.EditObj.layerLisPreview)
                    {
                      let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
                      for (let mut index29: i32 =  0; index29 <= mapWidth; index29 += 1)
                      {
                        let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                        for (let mut index30: i32 =  0; index30 <= mapHeight; index30 += 1)
                        {
                          let mut index31: i32 =  0;
                          do
                          {
                            this.game.Data.MapObj[0].HexObj[index29, index30].tempPreviewLIS[index31] = 0;
                            this.game.Data.MapObj[0].HexObj[index29, index30].tempPreviewAssetLIS[index31] = 0;
                            index31 += 1;
                          }
                          while (index31 <= 8);
                        }
                      }
                      this.game.ProcessingObj.LIS_SetNetwork(false, true);
                      if (this.game.EditObj.layerLisOnlyAssetId > 0)
                        this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
                    }
                    this.Setup();
                    this.View();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  goto label_143;
                }
              }
              NeighboursExtra lisTraffic1 = this.game.HandyFunctionsObj.GetLisTraffic(this.game.SelectX, this.game.SelectY);
              lisTraffic1.data[index21] = index22;
              this.game.HandyFunctionsObj.SetLisTraffic(this.game.SelectX, this.game.SelectY, lisTraffic1);
              if (this.game.EditObj.layerLisPreview)
              {
                let mut mapWidth: i32 =  this.game.Data.MapObj[0].MapWidth;
                for (let mut index32: i32 =  0; index32 <= mapWidth; index32 += 1)
                {
                  let mut mapHeight: i32 =  this.game.Data.MapObj[0].MapHeight;
                  for (let mut index33: i32 =  0; index33 <= mapHeight; index33 += 1)
                  {
                    let mut index34: i32 =  0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[index32, index33].tempPreviewLIS[index34] = 0;
                      this.game.Data.MapObj[0].HexObj[index32, index33].tempPreviewAssetLIS[index34] = 0;
                      index34 += 1;
                    }
                    while (index34 <= 8);
                  }
                }
                this.game.ProcessingObj.LIS_SetNetwork(false, true);
                if (this.game.EditObj.layerLisOnlyAssetId > 0)
                  this.game.ProcessingObj.LIS_SetNetwork(false, true, this.game.EditObj.layerLisOnlyAssetId);
              }
              this.Setup();
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
