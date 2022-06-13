// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OfficerPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class OfficerPartClass : SubPartClass
  {
     object OwnBitmapNr;
     int unr;
     GameClass game;
     int his;
     bool commander;
     bool AllowMoreButton;

    pub OfficerPartClass(int tunr, GameClass tgame, int @this = -1, bool tAllowMoreButton = false)
      : base(300, 200)
    {
      this.unr = tunr;
      this.game = tgame;
      this.AllowMoreButton = tAllowMoreButton;
      if (this.unr > -1)
        this.his = this.game.Data.UnitObj[this.unr].Historical;
      if (this.his > -1 && Operators.CompareString(this.game.Data.HistoricalUnitObj[this.his].CommanderName, "", false) != 0)
        this.commander = true;
      if (@this <= -1)
        return;
      this.his = @this;
      this.commander = true;
    }

    pub void DescriptInfo(int x, int y)
    {
      if (this.game.EditObj.UnitSelected == -1)
        return;
      this.Descript = "";
      if (this.commander)
      {
        int num1 = -1;
        int num2 = Math.Min(3, this.game.Data.HistoricalUnitObj[this.his].HandCardCounter);
        for (int index = 0; index <= num2; index += 1)
        {
          num1 += 1;
          int num3 = 140 + num1 * 45;
          int num4 = 45;
          if (x > num3 & y > num4 & x < num3 + 45 & y < num4 + 60)
            this.Descript = "Officer can play: " + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.his].HandCard[index]].Title;
        }
        int num5 = Math.Min(3, this.game.Data.HistoricalUnitObj[this.his].DeckCardCounter);
        for (int index1 = 0; index1 <= num5; index1 += 1)
        {
          int num6 = 0;
          int handCardCounter = this.game.Data.HistoricalUnitObj[this.his].HandCardCounter;
          for (int index2 = 0; index2 <= handCardCounter; index2 += 1)
          {
            if (this.game.Data.HistoricalUnitObj[this.his].DeckCard[index1] == this.game.Data.HistoricalUnitObj[this.his].HandCard[index2])
              num6 = 1;
          }
          if (num6 == 0)
          {
            num1 += 1;
            if (num1 <= 3)
            {
              int num7 = 140 + num1 * 45;
              int num8 = 45;
              if (x > num7 & y > num8 & x < num7 + 45 & y < num8 + 60)
                this.Descript = "Officer has " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.his].DeckChance[index1]) + "% chance to receive " + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.his].DeckCard[index1]].Title + " as a handcard.";
            }
          }
        }
      }
      if (this.game.EditObj.UnitSelected > -1 & this.game.Data.FOWOn)
      {
        if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
        {
          if (x > 50 & y > 7 & x < 138 & y < 104)
            this.Descript = "The portrait of the commander. Click on it for full description.";
          if (x > 50 & y > 107 & x < 350 & y < 177)
            this.Descript = "The description of the commander. Click on it to read the full description.";
        }
      }
      else
      {
        if (x > 50 & y > 7 & x < 138 & y < 104)
          this.Descript = "The portrait of the commander. Click on it for full description.";
        if (x > 50 & y > 107 & x < 350 & y < 177)
          this.Descript = "The description of the commander. Click on it to read the full description.";
      }
      int num9 = 4;
      if (x > 0 & y > num9 + 14 & x < 45 & y < num9 + 14 + 23)
        this.Descript = "Staff individuals that can be commanded effectively.";
      int num10 = num9 + 37;
      if (x > 0 & y > num10 + 14 & x < 45 & y < num10 + 14 + 23)
        this.Descript = "Combat modifier of commander. This modifier increases the staff combat bonus.";
      int num11 = num10 + 37;
      if (x > 0 & y > num11 + 14 & x < 45 & y < num11 + 14 + 23)
        this.Descript = "Morale modifier of commander. This modifier increase the staff morale recovery bonus.";
      int num12 = num11 + 37;
      if (!(x > 0 & y > num12 + 14 & x < 45 & y < num12 + 14 + 23))
        return;
      this.Descript = "The commanders experience points.";
    }

    pub Bitmap Paint()
    {
      SizeF sizeF = SizeF::new();
      Coordinate coordinate = Coordinate::new();
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.unr > -1)
      {
        if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
          coordinate.x = 3;
        else
          coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(this.unr, this.game.Data.Turn);
      }
      else
        coordinate.x = 3;
      if (coordinate.x > 1 && this.commander && this.game.Data.HistoricalUnitObj[this.his].CommanderSpriteID > -1)
      {
        DrawMod.DrawOfficerATG(objgraphics, this.his, 50, 7, 88, 97);
        str1: String = this.game.Data.HistoricalUnitObj[this.his].CommanderName;
        if (Strings.Len(str1) > 20)
          str1 = Strings.Left(str1, 20);
         Graphics local1 =  objgraphics;
        Rectangle rectangle1 = new Rectangle(140, 4, 40, 14);
        Rectangle rect1_1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(140, 18, 200, 23);
        Rectangle rect2_1 = rectangle2;
        txt2_1: String = str1;
        DrawMod.MakeFullBoxVic2( local1, rect1_1, "NAME", rect2_1, txt2_1);
        int num1 = 0;
        if (!this.game.Data.FOWOn)
          num1 = 1;
        if (this.unr > -1)
        {
          if (this.game.Data.Turn == this.game.Data.UnitObj[this.unr].Regime)
            num1 = 1;
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.unr].Regime))
            num1 = 1;
        }
        if (this.unr == -1)
          num1 = 1;
        if (this.game.Data.Round == 0)
          num1 = 1;
        int num2;
        if (num1 == 1)
        {
          int staffPoints = this.game.HandyFunctionsObj.GetStaffPoints(this.unr);
          int num3 = this.game.HandyFunctionsObj.GetStaffNeeded(this.unr);
          if (num3 == 0)
            num3 = 1;
          if ( Math.Round(40.0 * ((double) staffPoints / (double) num3)) > 80)
            num2 = 80;
          str2: String = this.game.HandyFunctionsObj.GetMaxStaffIndividuals(this.unr, this.his).ToString();
          str3: String = this.game.Data.HistoricalUnitObj[this.his].CombatMod.ToString() + "%";
          str4: String = this.game.Data.HistoricalUnitObj[this.his].MoraleMod.ToString() + "%";
          str5: String = this.game.Data.HistoricalUnitObj[this.his].Xp.ToString();
          if (this.game.EditObj.UnitSelected > -1 & this.game.Data.FOWOn & this.game.Data.Round > 0 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
          {
            str2 = "?";
            str3 = "?";
            str4 = "?";
            str5 = "?";
          }
          int y1 = 4;
           Graphics local2 =  objgraphics;
          rectangle2 = new Rectangle(0, y1, 45, 14);
          Rectangle rect1_2 = rectangle2;
          rectangle1 = new Rectangle(0, y1 + 14, 45, 23);
          Rectangle rect2_2 = rectangle1;
          txt2_2: String = str2;
          DrawMod.MakeFullBoxVic2( local2, rect1_2, "STAFF", rect2_2, txt2_2);
          int y2 = y1 + 37;
           Graphics local3 =  objgraphics;
          rectangle2 = new Rectangle(0, y2, 48, 14);
          Rectangle rect1_3 = rectangle2;
          rectangle1 = new Rectangle(0, y2 + 14, 45, 23);
          Rectangle rect2_3 = rectangle1;
          txt2_3: String = "+" + str3;
          DrawMod.MakeFullBoxVic2( local3, rect1_3, "COMBAT", rect2_3, txt2_3);
          int y3 = y2 + 37;
           Graphics local4 =  objgraphics;
          rectangle2 = new Rectangle(0, y3, 48, 14);
          Rectangle rect1_4 = rectangle2;
          rectangle1 = new Rectangle(0, y3 + 14, 45, 23);
          Rectangle rect2_4 = rectangle1;
          txt2_4: String = "+" + str4;
          DrawMod.MakeFullBoxVic2( local4, rect1_4, "MORALE", rect2_4, txt2_4);
          int y4 = y3 + 37;
           Graphics local5 =  objgraphics;
          rectangle2 = new Rectangle(0, y4, 45, 14);
          Rectangle rect1_5 = rectangle2;
          rectangle1 = new Rectangle(0, y4 + 14, 45, 23);
          Rectangle rect2_5 = rectangle1;
          txt2_5: String = str5;
          DrawMod.MakeFullBoxVic2( local5, rect1_5, "EXP", rect2_5, txt2_5);
        }
        bool flag = true;
        if (this.game.EditObj.UnitSelected > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
          flag = false;
        if (!this.game.Data.FOWOn | this.game.Data.Round == 0)
          flag = true;
        if (flag)
        {
          num2 = 0;
          int num4 = -1;
          int num5 = Math.Min(3, this.game.Data.HistoricalUnitObj[this.his].HandCardCounter);
          for (int index = 0; index <= num5; index += 1)
          {
            num4 += 1;
            int num6 = 140 + num4 * 45;
            int num7 = 45;
             Graphics local6 =  objgraphics;
            Bitmap bitmap = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.HistoricalUnitObj[this.his].HandCard[index], small: true);
             Bitmap local7 =  bitmap;
            int x = num6;
            int y = num7;
            DrawMod.DrawSimple( local6,  local7, x, y);
          }
          int num8 = Math.Min(3, this.game.Data.HistoricalUnitObj[this.his].DeckCardCounter);
          Bitmap bitmap1;
          for (int index1 = 0; index1 <= num8; index1 += 1)
          {
            int num9 = 0;
            int handCardCounter = this.game.Data.HistoricalUnitObj[this.his].HandCardCounter;
            for (int index2 = 0; index2 <= handCardCounter; index2 += 1)
            {
              if (this.game.Data.HistoricalUnitObj[this.his].DeckCard[index1] == this.game.Data.HistoricalUnitObj[this.his].HandCard[index2])
                num9 = 1;
            }
            if (num9 == 0)
            {
              num4 += 1;
              if (num4 <= 3)
              {
                int x1 = 140 + num4 * 45;
                int num10 = 45;
                 Graphics local8 =  objgraphics;
                bitmap1 = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.HistoricalUnitObj[this.his].DeckCard[index1], small: true);
                 Bitmap local9 =  bitmap1;
                int x2 = x1;
                int y5 = num10;
                DrawMod.DrawSimple( local8,  local9, x2, y5);
                 Graphics local10 =  objgraphics;
                bitmap1 = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.HistoricalUnitObj[this.his].DeckCard[index1], small: true);
                 Bitmap local11 =  bitmap1;
                int x3 = x1;
                int y6 = num10;
                DrawMod.Draw( local10,  local11, x3, y6, -1f, -1f, -1f, 0.5f);
                DrawMod.DrawTextColouredMarc( objgraphics, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.his].DeckChance[index1])) + "%", this.game.MarcFont4, x1, num10 + 38, Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue));
              }
            }
          }
           Graphics local12 =  objgraphics;
          Rectangle rectangle3;
          Rectangle rect1_6 = rectangle3;
          rectangle2 = new Rectangle(50, 107, 249, 70);
          Rectangle rect2_6 = rectangle2;
          DrawMod.MakeFullBoxVic2( local12, rect1_6, "", rect2_6, "");
          TextAreaClass textAreaClass = new TextAreaClass(this.game, 280, 3, this.game.VicFont3, "", false, this.game.Data.HistoricalUnitObj[this.his].Descript, Color.White, tbackbitmap: ( this.OwnBitmap), bbx: 50, bby: 109, tHideShade: true, tBlockScroller: true);
           Graphics local13 =  objgraphics;
          bitmap1 = textAreaClass.Paint();
           Bitmap local14 =  bitmap1;
          DrawMod.DrawSimple( local13,  local14, 50, 109);
        }
      }
      if (!Information.IsNothing((object) objgraphics))
      {
        objgraphics.Dispose();
        objgraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
       Graphics local1 =  Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
       Bitmap local2 =  bitmap;
      DrawMod.Draw( local1,  local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub int GetSelect() => this.his;
  }
}
