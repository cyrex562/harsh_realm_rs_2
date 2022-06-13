// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatSelectWindowClass
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
  pub class CombatSelectWindowClass : WindowClass
  {
     int okid;
     int cancelid;
     int mapButId;
     int oktextid;
     UnitList UL;
     UnitList DL;
     int oldUnitSelected;
     int oldSelectx;
     int oldSelecty;
     int oldMode1;
     int oldMode2;
     CoordList oldTempCoordList;
     CoordList oldTempCoordLastMoveList;
     ListClass rlistobj;
     ListClass rlist2obj;
     int rlistid;
     int rlist2id;
     int switchId;
     UnitList EL;

    pub CombatSelectWindowClass(ref GameClass tGame)
      : base(ref tGame, 1280, 768, 8)
    {
      this.oldMode1 = this.game.EditObj.HideUnit;
      this.oldMode2 = -(this.game.EditObj.SpreadUnit ? 1 : 0);
      this.game.EditObj.HideUnit = 1;
      this.game.EditObj.SpreadUnit = true;
      this.oldUnitSelected = this.game.EditObj.UnitSelected;
      this.oldSelectx = this.game.SelectX;
      this.oldSelecty = this.game.SelectY;
      this.oldTempCoordList = this.game.EditObj.TempCoordList;
      this.oldTempCoordLastMoveList = this.game.EditObj.TempCoordListLastMove;
      if (Information.IsNothing((object) this.game.EditObj.TempUnitList))
        this.game.EditObj.TempUnitList = UnitList::new();
      this.Setup();
      this.View();
    }

    pub void Setup()
    {
      this.EL = UnitList::new();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; index += 1)
      {
        this.game.Data.UnitObj[index].tempCanAttack = false;
        this.game.Data.UnitObj[index].tempCanAttack2 = false;
      }
      Coordinate target;
      target.x = this.game.SelectX;
      target.y = this.game.SelectY;
      if (this.game.EditObj.OrderType == 2)
      {
        int tfacing = 1;
        do
        {
          Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.SelectX, this.game.SelectY, 0, tfacing);
          if (coordinate.onmap)
          {
            int unitCounter2 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
            for (int index = 0; index <= unitCounter2; index += 1)
            {
              int unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index];
              if ((double) this.game.Data.RuleVar[307] <= (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unit) && this.game.HandyFunctionsObj.CanDoLandAttack(unit, target))
              {
                this.EL.add(unit);
                this.game.Data.UnitObj[unit].tempCanAttack = true;
              }
            }
          }
          tfacing += 1;
        }
        while (tfacing <= 6);
      }
      if (this.game.EditObj.OrderType == 11)
      {
        int x = target.x;
        int y = target.y;
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; index1 += 1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; index2 += 1)
          {
            int x2 = index1;
            int y2 = index2;
            if (this.game.Data.MapObj[0].HexObj[x2, y2].Regime == this.game.Data.Turn & this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter > -1)
            {
              int unitCounter3 = this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter;
              for (int index3 = 0; index3 <= unitCounter3; index3 += 1)
              {
                int unit = this.game.Data.MapObj[0].HexObj[x2, y2].UnitList[index3];
                if (this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn)
                {
                  int maxArtRange = this.game.HandyFunctionsObj.GetMaxArtRange(unit, 0);
                  if (maxArtRange > 0 && this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0, 899) <= maxArtRange && this.game.HandyFunctionsObj.CanDoArtAttack(unit, target, false))
                  {
                    this.EL.add(unit);
                    this.game.Data.UnitObj[unit].tempCanAttack = true;
                  }
                }
              }
            }
          }
        }
      }
      if (this.game.EditObj.OrderType == 14 | this.game.EditObj.OrderType == 33)
      {
        int x = target.x;
        int y = target.y;
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index4 = 0; index4 <= mapWidth; index4 += 1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index5 = 0; index5 <= mapHeight; index5 += 1)
          {
            int x2 = index4;
            int y2 = index5;
            if (this.game.Data.MapObj[0].HexObj[x2, y2].Regime == this.game.Data.Turn & this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter > -1)
            {
              int unitCounter4 = this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter;
              for (int index6 = 0; index6 <= unitCounter4; index6 += 1)
              {
                int unit = this.game.Data.MapObj[0].HexObj[x2, y2].UnitList[index6];
                if (this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn)
                {
                  int maxAirRange = this.game.HandyFunctionsObj.GetMaxAirRange(unit);
                  if (maxAirRange > 0 && this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0, 899) <= maxAirRange && this.game.HandyFunctionsObj.CanDoAirStrike(unit, target))
                  {
                    bool flag = false;
                    int minimumAirfieldLevel = this.game.HandyFunctionsObj.SE1_GetUnitMinimumAirfieldLevel(unit);
                    if (minimumAirfieldLevel > 0)
                    {
                      if (this.game.Data.MapObj[0].HexObj[x2, y2].Location > -1)
                      {
                        if (this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x2, y2].Location].tempAirfieldLevel < minimumAirfieldLevel)
                          flag = true;
                      }
                      else
                        flag = true;
                    }
                    if (!flag)
                    {
                      this.EL.add(unit);
                      this.game.Data.UnitObj[unit].tempCanAttack = true;
                    }
                  }
                }
              }
            }
          }
        }
      }
      for (int counter = this.game.EditObj.TempUnitList.counter; counter >= 0; counter += -1)
      {
        int tunr = this.game.EditObj.TempUnitList.unr[counter];
        if (!this.EL.CheckIfPresent(tunr) | this.game.Data.UnitObj[tunr].tempCanAttack2)
          this.game.EditObj.TempUnitList.remove(tunr);
      }
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
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

    pub void View()
    {
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.switchId > 0)
      {
        this.RemoveSubPart(this.switchId);
        this.switchId = 0;
      }
      if (this.mapButId > 0)
      {
        this.RemoveSubPart(this.mapButId);
        this.mapButId = 0;
      }
      this.ClearMouse();
      this.NewBackGroundAndClearAll(1280, 768, 8);
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      toG.Clear(Color.Transparent);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref toG, 70, 60, 1140, 678);
      DrawMod.DrawBlock(ref toG, 79, 66, 1115, 212, 0, 0, 0, 128);
      DrawMod.DrawBlock(ref toG, 79, 66, 1115, 188, 0, 0, 0, 128);
      DrawMod.DrawBlock(ref toG, 79, 499, 1115, 234, 0, 0, 0, 128);
      DrawMod.DrawBlock(ref toG, 443, 220, 410, 320, 0, 0, 0,  byte.MaxValue);
      ref Graphics local1 = ref toG;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_COMPLEXFRAME);
      ref Bitmap local2 = ref bitmap1;
      DrawMod.DrawSimple(ref local1, ref local2, 408, 205);
      SimpleStringList simpleStringList = this.game.HandyFunctionsObj.CombatPreviewStats(this.game.SelectX, this.game.SelectY);
      bool flag1 = false;
      int num1 = Math.Max(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter + 1, this.EL.counter + 1);
      bool flag2 = num1 <= 8;
      flag1 = num1 > 28;
      SizeF sizeF1 = SizeF::new();
      str1: String = "???";
      if (this.game.EditObj.OrderType == 2)
        str1 = "Regular Attack";
      if (this.game.EditObj.OrderType == 11)
        str1 = "Ranged Attack";
      if (this.game.EditObj.OrderType == 14)
        str1 = "Air Attack";
      if (this.game.EditObj.OrderType == 33)
        str1 = "Air Recon";
      SizeF sizeF2 = toG.MeasureString(str1, this.game.MarcFont1);
      DrawMod.DrawBlock(ref toG, 450, 80, 376, 50, 0, 0, 0, 155);
      DrawMod.DrawRectangle(ref toG, 450, 80, 376, 50,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue, 85, 2);
      DrawMod.DrawTextColouredMarc(ref toG, str1, this.game.MarcFont1,  Math.Round(640.0 - (double) sizeF2.Width / 2.0), 90, Color.White);
      int x1 = 136;
      int y1 = 152;
      int num2 = x1;
      int num3 = y1;
      Bitmap bitmap2 = new Bitmap(400, 400, PixelFormat.Format32bppPArgb);
      bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics objGraphics = Graphics.FromImage((Image) bitmap2);
      objGraphics.CompositingMode = CompositingMode.SourceCopy;
      objGraphics.Clear(Color.Transparent);
      objGraphics.CompositingMode = CompositingMode.SourceOver;
      Bitmap objBitmap = new Bitmap(128, 96, PixelFormat.Format32bppPArgb);
      objBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) objBitmap);
      CustomBitmapClass customBitmapObj1 = this.game.CustomBitmapObj;
      int selectX = this.game.SelectX;
      int selectY = this.game.SelectY;
      Graphics tempg1 = graphics;
      Bitmap bitmap3 = (Bitmap) null;
      ref Bitmap local3 = ref bitmap3;
      bool flag3 = false;
      ref bool local4 = ref flag3;
      customBitmapObj1.DrawHex(selectX, selectY, 0, tempg: tempg1, counteralpha: 0, Zoom: 1, neverusehistory: true, combatSetup: true, gBitmap: (ref local3), tFromMapPopup: (ref local4));
      DrawMod.DrawSimple(ref objGraphics, ref objBitmap, x1, y1);
      int tfacing = 1;
      Bitmap bitmap4;
      do
      {
        Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.SelectX, this.game.SelectY, 0, tfacing);
        if (coordinate.onmap)
        {
          int x2 = num2;
          int y2 = num3;
          if (tfacing == 1)
            y2 -= 96;
          if (tfacing == 2)
          {
            x2 += 106;
            y2 -= 48;
          }
          if (tfacing == 3)
          {
            x2 += 106;
            y2 += 48;
          }
          if (tfacing == 4)
            y2 += 96;
          if (tfacing == 5)
          {
            x2 -= 106;
            y2 += 48;
          }
          if (tfacing == 6)
          {
            x2 -= 106;
            y2 -= 48;
          }
          CustomBitmapClass customBitmapObj2 = this.game.CustomBitmapObj;
          int x3 = coordinate.x;
          int y3 = coordinate.y;
          Graphics tempg2 = graphics;
          bitmap4 = (Bitmap) null;
          ref Bitmap local5 = ref bitmap4;
          flag3 = false;
          ref bool local6 = ref flag3;
          customBitmapObj2.DrawHex(x3, y3, 0, tempg: tempg2, counteralpha: 0, Zoom: 1, neverusehistory: true, combatSetup: true, gBitmap: (ref local5), tFromMapPopup: (ref local6));
          DrawMod.DrawSimple(ref objGraphics, ref objBitmap, x2, y2);
        }
        tfacing += 1;
      }
      while (tfacing <= 6);
      toG.DrawImage((Image) bitmap2, 438, 175);
      bitmap2.Dispose();
      objGraphics.Dispose();
      objBitmap.Dispose();
      graphics.Dispose();
      int num4 = 0;
      int num5 = 842;
      int num6 = 534;
      if (this.game.SelectX == -1)
        return;
      int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
      int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
      int num7 = -1;
      int num8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
      if (num8 > 15)
        num8 = 15;
      int num9 = num8;
      int unit1;
      for (int index = 0; index <= num9; index += 1)
      {
        unit1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
        if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit1, this.game.Data.Turn) > 0)
          num7 += 1;
      }
      int num10;
      int num11;
      Rectangle trect1;
      Rectangle trect2;
      if (landscapeType > -1 & spriteNr > -1 && this.game.Data.Product > 6 & (double) this.game.Data.RuleVar[410] > 0.0)
      {
        ref Graphics local7 = ref toG;
        bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SUPERIMPOSEBACKGROUND);
        ref Bitmap local8 = ref bitmap4;
        int x4 = num5;
        int y4 = num6;
        DrawMod.DrawSimple(ref local7, ref local8, x4, y4);
        ref Graphics local9 = ref toG;
        bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
        ref Bitmap local10 = ref bitmap4;
        int x5 = num5 + 120;
        int y5 = num6 - 20;
        DrawMod.DrawSimple(ref local9, ref local10, x5, y5);
        str2: String = "Enemy Forces";
        SizeF sizeF3 = toG.MeasureString(str2, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc(ref toG, str2, this.game.MarcFont4,  Math.Round((double) ((float) (num5 + 120 + 70) - sizeF3.Width / 2f)), num6 - 10, Color.White);
        int num12 = -1;
        int num13 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        if (num13 > 15)
          num13 = 15;
        int num14 = num13;
        for (int index = 0; index <= num14; index += 1)
        {
          unit1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
          if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit1, this.game.Data.Turn) > 0)
          {
            num12 += 1;
            if (flag2)
            {
              if (num12 <= 3)
              {
                num10 = num5 + 22 + num12 * 84;
                num11 = num6 + 25;
              }
              else
              {
                num10 = num5 + 22 + (num12 - 4) * 84;
                num11 = num6 + 25 + 84;
              }
              bool forcehighlight = false;
              if (this.game.EditObj.UnitSelected == unit1)
                forcehighlight = true;
              this.game.CustomBitmapObj.DrawUnitBig(unit1, forcehighlight, toG, num10, num11, true);
              trect1 = new Rectangle(num10, num11, 76, 76);
              trect2 = trect1;
              this.AddMouse(ref trect2, "ENEMY UNIT", "An enemy unit that is being targetted", 10000 + unit1);
            }
            else if (num12 < 28)
            {
              if (num12 <= 6)
              {
                num10 = num5 + 22 + num12 * 48;
                num11 = num6 + 25;
              }
              else if (num12 <= 13)
              {
                num10 = num5 + 22 + (num12 - 7) * 48;
                num11 = num6 + 25 + 45;
              }
              else if (num12 <= 20)
              {
                num10 = num5 + 22 + (num12 - 14) * 48;
                num11 = num6 + 25 + 90;
              }
              else
              {
                num10 = num5 + 22 + (num12 - 21) * 48;
                num11 = num6 + 25 + 135;
              }
              bool forcehighlight = false;
              if (this.game.EditObj.UnitSelected == unit1)
                forcehighlight = true;
              this.game.CustomBitmapObj.DrawUnit(unit1, forcehighlight, toG, num10, num11, true);
              trect2 = new Rectangle(num10, num11, 37, 37);
              trect1 = trect2;
              this.AddMouse(ref trect1, "ENEMY UNIT", "Click to see its troop details.", 10000 + unit1);
            }
          }
        }
      }
      num4 = 0;
      int num15 = 64;
      int num16 = 30;
      if (this.game.SelectX == -1)
        return;
      ref Graphics local11 = ref toG;
      bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SUPERIMPOSEBACKGROUND);
      ref Bitmap local12 = ref bitmap4;
      int x6 = num15;
      int y6 = num16;
      DrawMod.DrawSimple(ref local11, ref local12, x6, y6);
      ref Graphics local13 = ref toG;
      bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
      ref Bitmap local14 = ref bitmap4;
      int x7 = num15 + 120;
      int y7 = num16 - 20;
      DrawMod.DrawSimple(ref local13, ref local14, x7, y7);
      str3: String = "Eligible Forces";
      SizeF sizeF4 = toG.MeasureString(str3, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str3, this.game.MarcFont4,  Math.Round((double) ((float) (num15 + 120 + 70) - sizeF4.Width / 2f)), num16 - 10, Color.White);
      int num17 = -1;
      int counter1 = this.EL.counter;
      for (int index = 0; index <= counter1; index += 1)
      {
        unit1 = this.EL.unr[index];
        if (!this.game.EditObj.TempUnitList.CheckIfPresent(unit1))
        {
          num17 += 1;
          if (flag2)
          {
            if (num17 <= 3)
            {
              num10 = num15 + 22 + num17 * 84;
              num11 = num16 + 25;
            }
            else
            {
              num10 = num15 + 22 + (num17 - 4) * 84;
              num11 = num16 + 25 + 84;
            }
            bool forcehighlight = false;
            if (this.game.EditObj.UnitSelected == unit1)
              forcehighlight = true;
            this.game.CustomBitmapObj.DrawUnitBig(unit1, forcehighlight, toG, num10, num11, true);
            if (!this.game.Data.UnitObj[unit1].tempCanAttack2)
            {
              trect2 = new Rectangle(num10, num11, 76, 76);
              trect1 = trect2;
              this.AddMouse(ref trect1, "FRIENDLY UNIT", "Left click to select / de-select in attack participation.", 10000 + unit1);
            }
            else
            {
              DrawMod.DrawBlock(ref toG, num10, num11, 76, 76, 0, 0, 0, 110);
              trect2 = new Rectangle(num10, num11, 76, 76);
              trect1 = trect2;
              this.AddMouse(ref trect1, "NOT ENOUGH AMMO", "Unit only has " + this.EL.data[index].ToString() + "% of the Ammo needed to participate in this Ranged Attack.");
            }
          }
          else if (num17 < 28)
          {
            if (num17 <= 6)
            {
              num10 = num15 + 22 + num17 * 48;
              num11 = num16 + 25;
            }
            else if (num17 <= 13)
            {
              num10 = num15 + 22 + (num17 - 7) * 48;
              num11 = num16 + 25 + 45;
            }
            else if (num17 <= 20)
            {
              num10 = num15 + 22 + (num17 - 14) * 48;
              num11 = num16 + 25 + 90;
            }
            else
            {
              num10 = num15 + 22 + (num17 - 21) * 48;
              num11 = num16 + 25 + 135;
            }
            bool forcehighlight = false;
            if (this.game.EditObj.UnitSelected == unit1)
              forcehighlight = true;
            this.game.CustomBitmapObj.DrawUnit(unit1, forcehighlight, toG, num10, num11, true);
            trect2 = new Rectangle(num10, num11, 37, 37);
            trect1 = trect2;
            this.AddMouse(ref trect1, "FRIENDLY UNIT", "Left click to select / de-select in attack participation.", 10000 + unit1);
          }
        }
      }
      int num18 = 0;
      int num19 = 0;
      int num20 = 1;
      do
      {
        num4 = 0;
        int x8 = 83;
        if (num20 == 0)
          x8 = 871;
        int maxValue =  byte.MaxValue;
        if (num20 == 1)
          str3 = "Estimation of offensive mods";
        if (num20 == 0)
          str3 = "Estimation of defensive mods";
        DrawMod.DrawTextColouredMarc(ref toG, str3, this.game.MarcFont4, x8, maxValue, Color.White);
        int y8 = maxValue + 25;
        int num21 = 1;
        int counter2 = simpleStringList.Counter;
        for (int index = 0; index <= counter2; index += 1)
        {
          if (simpleStringList.Data3[index] == num20 & simpleStringList.Data2[index] != 0 & simpleStringList.Data4[index] > 0)
          {
            int num22 = simpleStringList.Data1[index];
            int num23 = Strings.InStr(simpleStringList.Id[index], "#");
            str4: String = Strings.Left(simpleStringList.Id[index], num23 - 1);
            ttext: String = Strings.Mid(simpleStringList.Id[index], num23 + 1);
            ref Graphics local15 = ref toG;
            bitmap4 = BitmapStore.GetBitmap(this.game.COMBATICONS);
            ref Bitmap local16 = ref bitmap4;
            trect2 = new Rectangle(32 * (num22 - 1), 0, 32, 32);
            Rectangle srcrect = trect2;
            trect1 = new Rectangle(x8, y8, 32, 32);
            Rectangle destrect = trect1;
            DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
            double num24;
            if (num22 >= 25 & num22 <= 28)
            {
              str3 = simpleStringList.Data2[index].ToString();
              if (simpleStringList.Data2[index] >= 10000)
              {
                num24 = Math.Round((double) simpleStringList.Data2[index] / 1000.0, 1);
                str3 = num24.ToString() + "K";
              }
              if (num22 == 26)
                num19 = simpleStringList.Data2[index];
              if (num22 == 28)
                num18 = simpleStringList.Data2[index];
              DrawMod.DrawTextColouredMarc(ref toG, str3, this.game.MarcFont4, x8 + 29, y8 + 6, Color.White);
            }
            else
            {
              str3 = simpleStringList.Data2[index].ToString() + "%";
              if (simpleStringList.Data2[index] >= 10000)
              {
                num24 = Math.Round((double) simpleStringList.Data2[index] / 1000.0, 1);
                str3 = num24.ToString() + "K%";
              }
              if (simpleStringList.Data2[index] > 0)
                str3 = "+" + str3;
              if (simpleStringList.Data4[index] == 0)
                DrawMod.DrawTextColouredMarc(ref toG, "?", this.game.MarcFont4, x8 + 29, y8 + 6, Color.LightGray);
              else if (simpleStringList.Data2[index] > 0)
                DrawMod.DrawTextColouredMarc(ref toG, str3, this.game.MarcFont4, x8 + 29, y8 + 6, Color.PaleGreen);
              else if (simpleStringList.Data2[index] < 0)
                DrawMod.DrawTextColouredMarc(ref toG, str3, this.game.MarcFont4, x8 + 29, y8 + 6, Color.PaleVioletRed);
              else
                DrawMod.DrawTextColouredMarc(ref toG, str3, this.game.MarcFont4, x8 + 29, y8 + 6, Color.White);
            }
            trect2 = new Rectangle(x8, y8, 70, 32);
            trect1 = trect2;
            this.AddMouse(ref trect1, str4.ToUpper(), ttext);
            switch (num21)
            {
              case 1:
                x8 += 80;
                num21 = 2;
                continue;
              case 2:
                x8 += 80;
                num21 = 3;
                continue;
              case 3:
                x8 += 80;
                num21 = 4;
                continue;
              default:
                num21 = 1;
                x8 = 83;
                if (num20 == 0)
                  x8 = 871;
                y8 += 32;
                continue;
            }
          }
        }
        num20 += -1;
      }
      while (num20 >= 0);
      str5: String = "odds " + num19.ToString() + " : " + num18.ToString();
      Color color;
      if (num19 > 0 & num18 < 1)
        str5 = "No return fire expected";
      else if (num19 < 1 | num18 < 1)
        str5 = "unknown odds";
      else if (num19 >= num18)
      {
        float num25 = (float) Math.Round((double) num19 / (double) num18, 1);
        if ((double) num25 > 5.0)
          num25 = (float) Math.Round((double) num25, 0);
        color = (double) num25 >= 1.5 ? ((double) num25 >= 2.0 ? ((double) num25 >= 3.0 ? ((double) num25 >= 5.0 ? ((double) num25 >= 10.0 ? Color.FromArgb( byte.MaxValue, 0, 210, 50) : Color.FromArgb( byte.MaxValue, 50, 200, 50)) : Color.FromArgb( byte.MaxValue, 90, 200, 50)) : Color.FromArgb( byte.MaxValue, 130, 200, 50)) : Color.FromArgb( byte.MaxValue, 170, 200, 50)) : Color.FromArgb( byte.MaxValue, 210, 200, 50);
        str5 = "odds  " + num25.ToString() + " : 1";
      }
      else if (num18 > num19)
      {
        float num26 = (float) Math.Round((double) num18 / (double) num19, 1);
        if ((double) num26 > 5.0)
          num26 = (float) Math.Round((double) num26, 0);
        color = (double) num26 >= 1.5 ? ((double) num26 >= 2.0 ? ((double) num26 >= 3.0 ? ((double) num26 >= 5.0 ? ((double) num26 >= 10.0 ? Color.FromArgb( byte.MaxValue, 220, 10, 50) : Color.FromArgb( byte.MaxValue, 220, 50, 50)) : Color.FromArgb( byte.MaxValue, 220, 90, 50)) : Color.FromArgb( byte.MaxValue, 220, 130, 50)) : Color.FromArgb( byte.MaxValue, 220, 170, 50)) : Color.FromArgb( byte.MaxValue, 220, 210, 50);
        str5 = "odds  1 : " + num26.ToString();
      }
      DrawMod.DrawBlock(ref toG, 468, 559, 344, 60, 0, 0, 0, 55);
      DrawMod.DrawBlock(ref toG, 468, 559, 344, 60,  color.R,  color.G,  color.B, 105);
      DrawMod.DrawRectangle(ref toG, 468, 559, 344, 60,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue, 105, 2);
      if ((double) toG.MeasureString(str5, this.game.introFont2).Width > 300.0)
        DrawMod.DrawTextColouredMarcCenter(ref toG, str5, this.game.introFont1, 640, 571, Color.White);
      else
        DrawMod.DrawTextColouredMarcCenter(ref toG, str5, this.game.introFont2, 640, 564, Color.White);
      num4 = 0;
      int num27 = 64;
      int num28 = 534;
      if (this.game.SelectX == -1)
        return;
      ref Graphics local17 = ref toG;
      bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SUPERIMPOSEBACKGROUND);
      ref Bitmap local18 = ref bitmap4;
      int x9 = num27;
      int y9 = num28;
      DrawMod.DrawSimple(ref local17, ref local18, x9, y9);
      ref Graphics local19 = ref toG;
      bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
      ref Bitmap local20 = ref bitmap4;
      int x10 = num27 + 120;
      int y10 = num28 - 20;
      DrawMod.DrawSimple(ref local19, ref local20, x10, y10);
      str6: String = "Attacking Forces";
      SizeF sizeF5 = toG.MeasureString(str6, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str6, this.game.MarcFont4,  Math.Round((double) ((float) (num27 + 120 + 70) - sizeF5.Width / 2f)), num28 - 10, Color.White);
      int num29 = -1;
      int counter3 = this.game.EditObj.TempUnitList.counter;
      for (int index1 = 0; index1 <= counter3; index1 += 1)
      {
        unit1 = this.game.EditObj.TempUnitList.unr[index1];
        num29 += 1;
        if (flag2)
        {
          if (num29 <= 3)
          {
            num10 = num27 + 22 + num29 * 84;
            num11 = num28 + 25;
          }
          else
          {
            num10 = num27 + 22 + (num29 - 4) * 84;
            num11 = num28 + 25 + 84;
          }
          bool flag4 = false;
          int num30 = 100;
          int counter4 = simpleStringList.Counter;
          for (int index2 = 0; index2 <= counter4; index2 += 1)
          {
            if (simpleStringList.Data1[index2] == -1 && simpleStringList.Data2[index2] == unit1)
            {
              num30 = simpleStringList.Weight[index2];
              if (num30 < 100)
                flag4 = true;
            }
          }
          bool forcehighlight = false;
          if (this.game.EditObj.UnitSelected == unit1)
            forcehighlight = true;
          if (flag4)
          {
            this.game.CustomBitmapObj.DrawUnitBig(unit1, forcehighlight, toG, num10, num11, true);
            DrawMod.DrawBlock(ref toG, num10, num11, 76, 76, 0, 0, 0, 96);
            DrawMod.DrawBlock(ref toG, num10 + 15, num11 + 10, 46, 20, 0, 0, 0, 128);
            DrawMod.DrawTextColouredMarcCenter(ref toG, num30.ToString() + "%", this.game.MarcFont4, num10 + 15 + 23, num11 + 12, Color.White);
            trect2 = new Rectangle(num10, num11, 76, 76);
            trect1 = trect2;
            this.AddMouse(ref trect1, "FRIENDLY UNIT (IMPAIRED)", "Not 100% Ammunitions available hence artillery in this Unit will not fire.\r\nAmmunitions avalaible: " + num30.ToString() + "%.\r\nLeft click to select / de-select in attack participation.", 10000 + unit1);
          }
          else
          {
            this.game.CustomBitmapObj.DrawUnitBig(unit1, forcehighlight, toG, num10, num11, true);
            trect2 = new Rectangle(num10, num11, 76, 76);
            trect1 = trect2;
            this.AddMouse(ref trect1, "FRIENDLY UNIT", "Left click to select / de-select in attack participation.", 10000 + unit1);
          }
        }
        else if (num29 < 28)
        {
          if (num29 <= 6)
          {
            num10 = num27 + 22 + num29 * 48;
            num11 = num28 + 25;
          }
          else if (num29 <= 13)
          {
            num10 = num27 + 22 + (num29 - 7) * 48;
            num11 = num28 + 25 + 45;
          }
          else if (num29 <= 20)
          {
            num10 = num27 + 22 + (num29 - 14) * 48;
            num11 = num28 + 25 + 90;
          }
          else
          {
            num10 = num27 + 22 + (num29 - 21) * 48;
            num11 = num28 + 25 + 135;
          }
          bool forcehighlight = false;
          if (this.game.EditObj.UnitSelected == unit1)
            forcehighlight = true;
          this.game.CustomBitmapObj.DrawUnit(unit1, forcehighlight, toG, num10, num11, true);
        }
        trect2 = new Rectangle(num10, num11, 37, 37);
        trect1 = trect2;
        this.AddMouse(ref trect1, "FRIENDLY UNIT", "Left click to select / de-select in attack participation.", 10000 + unit1);
      }
      num4 = 0;
      int num31 = 842;
      int num32 = 30;
      ListClass tListobj = ListClass::new();
      int[] numArray1 = new int[100];
      int[] numArray2 = new int[100];
      tListobj.add("UNITGROUP", -1, "ATTACKER", "DEFENDER");
      int num33 = 0;
      int Number1 = 0;
      int[] numArray3 = new int[7];
      int Index = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      if (Index == this.game.Data.Turn)
        Index = -1;
      int counter5 = this.game.EditObj.TempUnitList.counter;
      int num34;
      int num35;
      for (int index3 = 0; index3 <= counter5; index3 += 1)
      {
        unit1 = this.game.EditObj.TempUnitList.unr[index3];
        int num36 = this.game.HandyFunctionsObj.Distance(this.game.SelectX, this.game.SelectY, 0, this.game.Data.UnitObj[unit1].X, this.game.Data.UnitObj[unit1].Y, 0, 899);
        int sfCount = this.game.Data.UnitObj[unit1].SFCount;
        for (int index4 = 0; index4 <= sfCount; index4 += 1)
        {
          int sf = this.game.Data.UnitObj[unit1].SFList[index4];
          if (Index > -1)
          {
            num34 += this.game.Data.SFObj[sf].Qty;
            num35 += this.game.Data.SFObj[sf].Qty * this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unit1].X, this.game.Data.UnitObj[unit1].Y].get_ReconPts(Index);
          }
          int type = this.game.Data.SFObj[sf].Type;
          int num37 = this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio;
          int unitGroup = this.game.Data.SFTypeObj[type].UnitGroup;
          bool flag5 = true;
          if (this.game.EditObj.OrderType == 11 && this.game.Data.SFTypeObj[type].ArtRange < num36)
            flag5 = false;
          if (this.game.EditObj.OrderType == 14 && !this.game.Data.UnitObj[unit1].tempCanAttack)
            flag5 = false;
          if (this.game.EditObj.OrderType == 33 && !this.game.Data.UnitObj[unit1].tempCanAttack)
            flag5 = false;
          if (flag5)
          {
            int[] numArray4 = numArray1;
            int[] numArray5 = numArray4;
            int index5 = unitGroup;
            int index6 = index5;
            int num38 = numArray4[index5] + num37;
            numArray5[index6] = num38;
            num33 += this.game.Data.SFTypeObj[type].Frontage * this.game.Data.SFObj[sf].Qty;
          }
          int index7 = this.game.HandyFunctionsObj.HexFacing(this.game.SelectX, this.game.SelectY, 0, this.game.Data.UnitObj[unit1].X, this.game.Data.UnitObj[unit1].Y, 0);
          if (index7 >= 1 & index7 <= 6)
            numArray3[index7] = 1;
        }
      }
      int Number2 = num34 <= 0 ? 0 :  Math.Round((double) num35 / (double) num34);
      Coordinate reconMinusHide1;
      if (this.game.Data.UnitObj[unit1].Regime == this.game.Data.Turn | !this.game.Data.FOWOn | this.game.Data.Round == 0)
        reconMinusHide1.x = 3;
      else
        reconMinusHide1 = this.game.HandyFunctionsObj.GetReconMinusHide(unit1, this.game.Data.Turn);
      int Number3 = this.game.EditObj.OrderType != 11 ? (this.game.EditObj.OrderType != 14 ? (this.game.EditObj.OrderType != 33 ? num33 + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStack(this.game.Data.Turn) : num33 + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackAir(this.game.Data.Turn)) : num33 + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackAir(this.game.Data.Turn)) : num33 + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackArt(this.game.Data.Turn);
      bool flag6 = false;
      int unitCounter = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
      for (int index8 = 0; index8 <= unitCounter; index8 += 1)
      {
        int unit2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index8];
        if (this.game.HandyFunctionsObj.CanWeSeeUnit(unit2, this.game.Data.Turn) > 0)
        {
          int sfCount = this.game.Data.UnitObj[unit2].SFCount;
          for (int i = 0; i <= sfCount; i += 1)
          {
            int sf = this.game.Data.UnitObj[unit2].SFList[i];
            int type = this.game.Data.SFObj[sf].Type;
            int num39 = this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio;
            int unitGroup = this.game.Data.SFTypeObj[type].UnitGroup;
            Coordinate reconMinusHide2 = this.game.HandyFunctionsObj.GetReconMinusHide(unit2, this.game.Data.Turn);
            if (reconMinusHide2.x > 1)
            {
              int num40;
              if (reconMinusHide2.x < 3 && this.game.Data.FOWOn & this.game.Data.UnitObj[unit2].Regime != this.game.Data.Turn && reconMinusHide2.x == 2)
              {
                int qty = this.game.Data.SFObj[sf].Qty;
                this.game.HandyFunctionsObj.RandomizeForUnit(unit2, i);
                float num41 = (float) reconMinusHide2.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
                float num42 = (float) ((1.0 - (double) num41) * 2.0);
                num40 =  Math.Round((double) ((VBMath.Rnd() * num42 + num41) * (float) qty));
                if (num40 < 1)
                  num40 = 1;
                num39 = num40 * this.game.Data.SFTypeObj[type].Ratio;
                VBMath.Randomize();
              }
              int[] numArray6 = numArray2;
              int[] numArray7 = numArray6;
              int index9 = unitGroup;
              int index10 = index9;
              int num43 = numArray6[index9] + num39;
              numArray7[index10] = num43;
              Number1 += this.game.Data.SFTypeObj[type].Frontage * num40;
            }
            else
              flag6 = true;
          }
        }
      }
      int num44 = 0;
      int index11 = 0;
      do
      {
        if (numArray1[index11] > 0 | numArray2[index11] > 0)
        {
          num44 += 1;
          if (numArray2[index11] == 0 & flag6)
            tListobj.add(this.game.Data.TempString[400 + index11], -1, Strings.Trim(Conversion.Str((object) numArray1[index11])), "?");
          else
            tListobj.add(this.game.Data.TempString[400 + index11], -1, Strings.Trim(Conversion.Str((object) numArray1[index11])), Strings.Trim(Conversion.Str((object) numArray2[index11])));
        }
        index11 += 1;
      }
      while (index11 <= 99);
      if (num44 == 0)
      {
        int index12 = 0;
        tListobj.add(this.game.Data.TempString[400 + index12], -1, Strings.Trim(Conversion.Str((object) numArray1[index12])), "?");
      }
      int num45 = 4;
      int Number4 = 0;
      int Number5 = 0;
      if (tListobj.ListCount > num45)
      {
        int num46 = num45 + 1;
        int listCount = tListobj.ListCount;
        for (int index13 = num46; index13 <= listCount; index13 += 1)
        {
          Number4 +=  Math.Round(Conversion.Val(tListobj.ListValue[index13]));
          Number5 +=  Math.Round(Conversion.Val(tListobj.ListValue2[index13]));
        }
        tListobj.ListCount = num45;
        tListobj.add("Other", -1, Strings.Trim(Conversion.Str((object) Number4)), Strings.Trim(Conversion.Str((object) Number5)));
      }
      int num47 = 0;
      int index14 = 1;
      do
      {
        if (numArray3[index14] > 0)
          num47 += 1;
        index14 += 1;
      }
      while (index14 <= 6);
      if (num47 < 2)
        num47 = 2;
      int Number6 =  Math.Round((double) (this.game.Data.RuleVar[31] * (float) num47));
      int Number7 =  Math.Round((double) this.game.Data.RuleVar[30]);
      if (this.game.EditObj.OrderType == 11)
        Number6 =  Math.Round((double) this.game.Data.RuleVar[834]);
      if (this.game.EditObj.OrderType == 14)
        Number6 =  Math.Round((double) this.game.Data.RuleVar[833]);
      if (this.game.EditObj.OrderType == 33)
        Number6 =  Math.Round((double) this.game.Data.RuleVar[833]);
      if (numArray2[index14] == 0 & flag6)
        tListobj.add("Stack Points", -1, Strings.Trim(Conversion.Str((object) Number3)) + " / " + Strings.Trim(Conversion.Str((object) Number6)), "? / " + Strings.Trim(Conversion.Str((object) Number7)));
      else
        tListobj.add("Stack Points", -1, Strings.Trim(Conversion.Str((object) Number3)) + " / " + Strings.Trim(Conversion.Str((object) Number6)), Strings.Trim(Conversion.Str((object) Number1)) + " / " + Strings.Trim(Conversion.Str((object) Number7)));
      tListobj.add("Recon Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon)) + " / " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[56])), Strings.Trim(Conversion.Str((object) Number2)) + " / " + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[56])));
      ref Graphics local21 = ref toG;
      bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SUPERIMPOSEBACKGROUND);
      ref Bitmap local22 = ref bitmap4;
      int x11 = num31;
      int y11 = num32;
      DrawMod.DrawSimple(ref local21, ref local22, x11, y11);
      ref Graphics local23 = ref toG;
      bitmap4 = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
      ref Bitmap local24 = ref bitmap4;
      int x12 = num31 + 120;
      int y12 = num32 - 20;
      DrawMod.DrawSimple(ref local23, ref local24, x12, y12);
      str7: String = "Combat Totals";
      SizeF sizeF6 = toG.MeasureString(str7, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str7, this.game.MarcFont4,  Math.Round((double) ((float) (num31 + 120 + 70) - sizeF6.Width / 2f)), num32 - 10, Color.White);
      int num48 = 7;
      ListSubPartClass listSubPartClass = new ListSubPartClass(tListobj, num48 + 1, 330, -1, this.game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 200, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num31 + 20), bby: (num32 + 25), tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 18);
      ref Graphics local25 = ref toG;
      bitmap4 = listSubPartClass.Paint();
      ref Bitmap local26 = ref bitmap4;
      int x13 = num31 + 20;
      int y13 = num32 + 25;
      DrawMod.DrawSimple(ref local25, ref local26, x13, y13);
      buttontext: String = "ATTACK";
      tDescript1: String = "Click to start the attack [Space]";
      tDescript2: String = "Select some attackers in order to be able to attack [Space]";
      if (this.game.EditObj.OrderType == 11)
      {
        buttontext = "RANGED ATTACK";
        tDescript1 = "Click to start the ranged attack [Space]";
        tDescript2 = "Select some ranged-fire capable attackers in order to be able to ranged attack [Space]";
      }
      if (this.game.EditObj.OrderType == 14)
      {
        buttontext = "AIR ATTACK";
        tDescript1 = "Click to start the air attack [Space]";
        tDescript2 = "Select some air units to join in this air attack [Space]";
      }
      if (this.game.EditObj.OrderType == 33)
      {
        buttontext = "AIR RECON";
        tDescript1 = "Click to start the air recon [Space]";
        tDescript2 = "Select some air units to join in this air recon [Space]";
      }
      if (this.game.EditObj.TempUnitList.counter > -1)
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(buttontext, 350, tDescript1, ref this.OwnBitmap, 468, 631, tred: true, theight: 85, usefont: this.game.MarcFont1, useshadow: true, tMarcStyle: true);
        this.okid = this.AddSubPart(ref tsubpart, 468, 631, 350, 85, 1);
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(buttontext, 350, tDescript2, ref this.OwnBitmap, 468, 631, true, true, 85, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.okid = this.AddSubPart(ref tsubpart, 468, 631, 350, 85, 1);
      }
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("Cancel", 150, "Click to return to main screen [Esc]", ref this.OwnBitmap, 680, 142, theight: 65, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart1, 680, 142, 150, 65, 1);
      let mut tsubpart2: SubPartClass =  new TextButtonPartClass("Switch", 150, "Switch between Regular Attack and Ranged Attack preperation", ref this.OwnBitmap, 450, 142, theight: 65, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.switchId = this.AddSubPart(ref tsubpart2, 450, 142, 150, 65, 1);
      let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Map", 70, "Select elgible Units on the Map instead.", ref this.OwnBitmap, 605, 142, theight: 65, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.mapButId = this.AddSubPart(ref tsubpart3, 605, 142, 70, 65, 1);
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; index += 1)
            this.game.Data.UnitObj[index].tempCanAttack = false;
          this.game.EditObj.HideUnit = this.oldMode1;
          this.game.EditObj.SpreadUnit = (uint) this.oldMode2 > 0U;
          this.game.EditObj.TempUnitList = UnitList::new();
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if (nr == 32 & this.game.EditObj.TempUnitList.counter > -1)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; index += 1)
            this.game.Data.UnitObj[index].tempCanAttack = false;
          this.game.EditObj.HideUnit = this.oldMode1;
          this.game.EditObj.SpreadUnit = (uint) this.oldMode2 > 0U;
          this.game.EditObj.TargetX = this.game.SelectX;
          this.game.EditObj.TargetY = this.game.SelectY;
          this.game.EditObj.OrderX = this.game.SelectX;
          this.game.EditObj.OrderY = this.game.SelectY;
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
      int num1 = 574;
      int num2 = 327;
      Coordinate target;
      target.x = this.game.SelectX;
      target.y = this.game.SelectY;
      target.onmap = true;
      int tfacing = 1;
      do
      {
        Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.SelectX, this.game.SelectY, 0, tfacing);
        if (coordinate.onmap)
        {
          int num3 = num1;
          int num4 = num2;
          if (tfacing == 1)
            num4 -= 96;
          if (tfacing == 2)
          {
            num3 += 106;
            num4 -= 48;
          }
          if (tfacing == 3)
          {
            num3 += 106;
            num4 += 48;
          }
          if (tfacing == 4)
            num4 += 96;
          if (tfacing == 5)
          {
            num3 -= 106;
            num4 += 48;
          }
          if (tfacing == 6)
          {
            num3 -= 106;
            num4 -= 48;
          }
          if (x >= num3 & x < num3 + 128 && y >= num4 & y < num4 + 96 && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == this.game.Data.Turn)
          {
            int zoom = this.game.EditObj.Zoom;
            this.game.EditObj.Zoom = 1;
            int num5 = this.game.HandyFunctionsObj.ClickOnHexGivesUnit(coordinate.x, coordinate.y, this.game.EditObj.MapSelected, false, b, x - num3, y - num4);
            this.game.EditObj.Zoom = zoom;
            if (num5 > -1)
            {
              if (this.game.EditObj.TempUnitList.CheckIfPresent(num5))
              {
                this.game.EditObj.TempUnitList.remove(num5);
                this.View();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num5 > -1)
              {
                if ((double) this.game.Data.RuleVar[307] <= (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(num5))
                {
                  if (!this.game.HandyFunctionsObj.CanDoLandAttack(num5, target))
                    num5 = -1;
                }
                else
                  num5 = -1;
              }
              if (num5 > -1)
              {
                this.game.EditObj.TempUnitList.add(num5);
                this.View();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
          }
        }
        tfacing += 1;
      }
      while (tfacing <= 6);
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] >= 0)
        {
          int tunr = this.MouseData[index] - 10000;
          if (this.game.Data.UnitObj[tunr].Regime == this.game.Data.Turn)
          {
            if (!this.game.EditObj.TempUnitList.CheckIfPresent(tunr))
              this.game.EditObj.TempUnitList.add(tunr);
            else
              this.game.EditObj.TempUnitList.remove(tunr);
            this.View();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num6 = this.SubPartID[index1];
            if (num6 == this.okid)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index2 = 0; index2 <= unitCounter; index2 += 1)
                this.game.Data.UnitObj[index2].tempCanAttack = false;
              this.game.EditObj.HideUnit = this.oldMode1;
              this.game.EditObj.SpreadUnit = (uint) this.oldMode2 > 0U;
              this.game.EditObj.TargetX = this.game.SelectX;
              this.game.EditObj.TargetY = this.game.SelectY;
              this.game.EditObj.OrderX = this.game.SelectX;
              this.game.EditObj.OrderY = this.game.SelectY;
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num6 == this.mapButId)
            {
              this.game.EditObj.PopupValue = 30;
              this.game.EditObj.HideUnit = this.oldMode1;
              this.game.EditObj.SpreadUnit = (uint) this.oldMode2 > 0U;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index3 = 0; index3 <= unitCounter; index3 += 1)
                this.game.Data.UnitObj[index3].TempUnitSelectable = false;
              int counter = this.EL.counter;
              for (int index4 = 0; index4 <= counter; index4 += 1)
                this.game.Data.UnitObj[this.EL.unr[index4]].TempUnitSelectable = true;
              windowReturnClass.AddCommand(5, 14);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num6 == this.cancelid)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index5 = 0; index5 <= unitCounter; index5 += 1)
                this.game.Data.UnitObj[index5].tempCanAttack = false;
              this.game.EditObj.HideUnit = this.oldMode1;
              this.game.EditObj.SpreadUnit = (uint) this.oldMode2 > 0U;
              this.game.EditObj.TempUnitList = UnitList::new();
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num6 == this.switchId)
            {
              this.game.EditObj.TempUnitList = UnitList::new();
              if (this.game.EventRelatedObj.Helper_AirEnabled())
              {
                if (this.game.EditObj.OrderType == 2)
                  this.game.EditObj.OrderType = 11;
                else if (this.game.EditObj.OrderType == 11)
                  this.game.EditObj.OrderType = 14;
                else if (this.game.EditObj.OrderType == 14)
                  this.game.EditObj.OrderType = 33;
                else if (this.game.EditObj.OrderType == 33)
                  this.game.EditObj.OrderType = 2;
              }
              else if (this.game.EditObj.OrderType == 2)
                this.game.EditObj.OrderType = 11;
              else if (this.game.EditObj.OrderType == 11)
                this.game.EditObj.OrderType = 2;
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
