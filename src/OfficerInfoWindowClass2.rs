// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OfficerInfoWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class OfficerInfoWindowClass2 : WindowClass
  {
     int okid;
     int cancelid;
     int oktextid;
     int Pic1Id;
     int TAid;
     int His;
     int Card;

    pub OfficerInfoWindowClass2( GameClass tGame)
      : base( tGame, 680, 680, 8)
    {
      this.His = this.game.EditObj.OfficerHisOverrule > 0 ? this.game.EditObj.OfficerHisOverrule : tGame.Data.UnitObj[tGame.EditObj.UnitSelected].Historical;
      this.game.EditObj.OfficerHisOverrule = -1;
      this.View();
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
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.MouseData[mouseCounter] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[mouseCounter];
          this.game.EditObj.TipText = this.MouseText[mouseCounter];
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
      if (this.TAid > 0)
        this.RemoveSubPart(this.TAid);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(680, 680, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame( this.OwnBitmap,  g, 0, 0, 680, 680);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      int commanderSpriteId = this.game.Data.HistoricalUnitObj[this.His].CommanderSpriteID;
      SizeF sizeF1 = SizeF::new();
      sizeF1 = g.MeasureString(this.game.Data.HistoricalUnitObj[this.His].CommanderName, Font::new(this.game.FontCol.Families[1], 48f, FontStyle.Regular, GraphicsUnit.Pixel));
      DrawMod.DrawTextColouredMarc( g, this.game.Data.HistoricalUnitObj[this.His].CommanderName, this.game.MarcFont1, 20, 19, Color.White);
      DrawMod.DrawOfficer(g, this.His, 20, 70, 177, 194);
      Rectangle trect1;
      Rectangle trect2;
      if ((double) this.game.Data.RuleVar[976] < 1.0)
      {
        int num1 = 270;
        DrawMod.DrawBlockGradient2( g, 20, num1, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, 20, num1, 80, 20, -1, -1);
        str1: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].CombatMod)) + "%";
        if (this.game.Data.HistoricalUnitObj[this.His].CombatMod > 0)
          str1 = "+" + str1;
        DrawMod.DrawTextColouredMarc( g, "COM = " + str1, this.game.MarcFont5, 25, num1 + 4, Color.White);
        if ((double) this.game.Data.RuleVar[927] > 0.0)
        {
          trect1 = new Rectangle(20, num1, 80, 20);
          this.AddMouse( trect1, "COMBAT MODIFIER", "How much percent does the officer increase\r\nstaff combat bonus.\r\nMind you: Only if the officer is in command at the lowest HQ level!");
        }
        else
        {
          trect1 = new Rectangle(20, num1, 80, 20);
          Rectangle trect3 = trect1;
          this.AddMouse( trect3, "COMBAT MODIFIER", "How much percent does the officer increase\r\nstaff combat bonus.");
        }
        int num2 = 300;
        DrawMod.DrawBlockGradient2( g, 20, num2, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, 20, num2, 80, 20, -1, -1);
        str2: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].MoraleMod)) + "%";
        if (this.game.Data.HistoricalUnitObj[this.His].MoraleMod > 0)
          str2 = "+" + str2;
        DrawMod.DrawTextColouredMarc( g, "MOR = " + str2, this.game.MarcFont5, 25, num2 + 4, Color.White);
        if ((double) this.game.Data.RuleVar[927] > 0.0)
        {
          trect1 = new Rectangle(20, num2, 80, 20);
          Rectangle trect4 = trect1;
          this.AddMouse( trect4, "MORALE MODIFIER", "How much percent does the officer increase \r\n regular morale recovery.\r\nMind you: Only if the officer is in command at the lowest HQ level!");
        }
        else
        {
          trect1 = new Rectangle(20, num2, 80, 20);
          Rectangle trect5 = trect1;
          this.AddMouse( trect5, "MORALE MODIFIER", "How much percent does the officer increase \r\n regular morale recovery.");
        }
        int num3 = 270;
        DrawMod.DrawBlockGradient2( g, 110, num3, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, 110, num3, 80, 20, -1, -1);
        str3: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].StaffSize));
        DrawMod.DrawTextColouredMarc( g, "STAFF = " + str3, this.game.MarcFont5, 120, num3 + 4, Color.White);
        trect1 = new Rectangle(110, num3, 80, 20);
        Rectangle trect6 = trect1;
        this.AddMouse( trect6, "STAFF POINTS", "How much staff points can officer \r\n handle in this scenario.");
        int num4 = 300;
        if ((double) this.game.Data.RuleVar[343] == 1.0)
        {
          DrawMod.DrawBlockGradient2( g, 110, num4, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
          DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  g, 110, num4, 80, 20, -1, -1);
          str4: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].PP));
          DrawMod.DrawTextColouredMarc( g, "POL = " + str4, this.game.MarcFont5, 120, num4 + 4, Color.White);
          trect1 = new Rectangle(110, num4, 80, 20);
          trect2 = trect1;
          this.AddMouse( trect2, "POLITICAL VALUE", "If has negative points here \r\n it costs PP to reassign units under this officer.");
        }
      }
      bool flag1 = false;
      int hisVarCount = this.game.Data.HistoricalUnitObj[this.His].HisVarCount;
      for (int index = 0; index <= hisVarCount; index += 1)
      {
        if (this.game.Data.HistoricalUnitObj[this.His].HisVarCount >= index && this.game.Data.HistoricalUnitObj[this.His].HisVarNato[index] > 0 | this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index] > -1)
        {
          bool flag2 = true;
          if (this.game.Data.HistoricalUnitObj[this.His].HisVarType[index] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[this.His].HisVarType[index]], "1", false) == 0)
            flag2 = false;
          if (this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index] > -1 && Strings.InStr(this.game.Data.SmallPicName[this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index]], "trans.") > 0)
            flag2 = false;
          if (flag2)
            flag1 = true;
        }
      }
      Bitmap bitmap1;
      if (this.game.HandyFunctionsObj.GetVisibleHisVar(this.His) > 0 & flag1)
      {
        int bbx = 210;
        int num5 = 56;
        TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 420, 3, this.game.MarcFont13, "", 12,  this.BackBitmap, bbx, num5, true);
         Graphics local1 =  g;
        Bitmap bitmap2 = textAreaClass2.Paint();
         Bitmap local2 =  bitmap2;
        int x1 = bbx;
        int y = num5;
        DrawMod.DrawSimple( local1,  local2, x1, y);
        int num6 = 0;
        while (num6 < 380)
        {
          int index;
          if (this.game.Data.HistoricalUnitObj[this.His].HisVarCount >= index)
          {
            bool flag3 = true;
            if (this.game.Data.HistoricalUnitObj[this.His].HisVarType[index] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[this.His].HisVarType[index]], "1", false) == 0)
              flag3 = false;
            if (this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index] > -1 && Strings.InStr(this.game.Data.SmallPicName[this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index]], "trans.") > 0)
              flag3 = false;
            if (flag3 & (this.game.Data.HistoricalUnitObj[this.His].HisVarNato[index] > 0 | this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index] > -1))
            {
              str: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].HisVarValue[index]));
              SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont8b);
              int num7 = bbx + num6;
              int num8 = num5 + 10;
              DrawMod.DrawBlock( g, num7 + 36, num5 + 13, 2, 64,  this.game.MarcCol3.R,  this.game.MarcCol3.G,  this.game.MarcCol3.B, 128);
              int x2 =  Math.Round((double) ((float) (bbx + num6 + 18) - sizeF2.Width / 2f));
              DrawMod.DrawTextColouredMarc( g, str, this.game.MarcFont8b, x2, 105, Color.White);
              if (this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index] > -1)
              {
                 Graphics local3 =  g;
                bitmap1 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index]]);
                 Bitmap local4 =  bitmap1;
                int x3 = x2;
                DrawMod.DrawSimple( local3,  local4, x3, 81);
              }
              else
              {
                 Graphics local5 =  g;
                bitmap1 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[this.His].HisVarNato[index]]);
                 Bitmap local6 =  bitmap1;
                int x4 = x2;
                DrawMod.DrawSimple( local5,  local6, x4, 81);
              }
              if (this.game.Data.Turn == this.game.Data.HistoricalUnitObj[this.His].TempRegime)
              {
                trect1 = new Rectangle(x2, num5, 35, 50);
                trect2 = trect1;
                this.AddMouse( trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[this.His].HisVarType[index]]);
              }
              num6 += 35;
            }
          }
          else
            num6 = 380;
          index += 1;
        }
      }
      int num9 = -1;
      int num10 = -12;
      int num11 = 0;
      int deckCardCounter1 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      int x5;
      int y1;
      int num12;
      for (int index = 0; index <= deckCardCounter1; index += 1)
      {
        int num13 = 1;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow > 0)
          num13 = 0;
        if (num13 == 1)
        {
          num9 += 1;
          num11 += 1;
          if (num11 == 1)
          {
            int num14 = num10 + 12;
            x5 = 20;
            y1 = 330 + num14;
            tstring: String = "Officer deck cards:";
            DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8b, x5, y1, Color.White);
            num10 = num14 + 24;
          }
          if (num9 <= 15)
          {
            if (num9 <= 3)
            {
              x5 = num9 * 47 + 20;
              y1 = 330 + num10;
              num12 = 55;
            }
            else if (num9 <= 7)
            {
              x5 = (num9 - 4) * 47 + 20;
              y1 = 385 + num10;
              num12 = 110;
            }
            else if (num9 <= 11)
            {
              x5 = (num9 - 8) * 47 + 20;
              y1 = 440 + num10;
              num12 = 165;
            }
            else if (num9 <= 15)
            {
              x5 = (num9 - 12) * 47 + 20;
              y1 = 495 + num10;
              num12 = 220;
            }
          }
           Graphics local7 =  g;
          bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.HistoricalUnitObj[this.His].TempRegime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
           Bitmap local8 =  bitmap1;
          int x6 = x5;
          int y2 = y1;
          DrawMod.DrawSimple( local7,  local8, x6, y2);
          trect1 = new Rectangle(x5, y1, 33, 46);
          trect2 = trect1;
          this.AddMouse( trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
        }
      }
      int num15 = 0;
      int num16 = -1;
      int num17 = num10 + num12;
      int num18 = 0;
      int num19 = 0;
      int deckCardCounter2 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter2; index += 1)
      {
        int num20 = 1;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 0)
          num20 = 0;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 2)
          num20 = 0;
        if (this.game.Data.Product == 6 && this.game.Data.HistoricalUnitObj[this.His].Type > 5)
          num20 = 0;
        if (num20 == 1)
          num19 += 1;
      }
      int deckCardCounter3 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter3; index += 1)
      {
        int num21 = 1;
        if (this.game.EditObj.OrderType != 45)
        {
          int num22 = this.game.Data.HistoricalUnitObj[this.His].Type > 5 & this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 1 ? 1 : 0;
        }
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 0)
          num21 = 0;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 2)
          num21 = 0;
        if (this.game.Data.Product == 6 && this.game.Data.HistoricalUnitObj[this.His].Type > 5)
          num21 = 0;
        if (num21 == 1)
        {
          num16 += 1;
          num15 += 1;
          if (num15 == 1)
          {
            int num23 = num17 + 12;
            x5 = 20;
            y1 = 330 + num23;
            tstring: String = "Tactical deck cards:";
            DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8b, x5, y1, Color.White);
            num17 = num23 + 24;
          }
          if (this.game.Data.Product == 6)
          {
            int num24 =  Math.Round(133.0 / (double) Math.Max(1, num19 - 1));
             Graphics local9 =  g;
            bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 2);
             Bitmap local10 =  bitmap1;
            int x7 = x5;
            int y3 = y1 + 20;
            DrawMod.DrawSimple( local9,  local10, x7, y3);
            trect1 = new Rectangle(x5, y1 + 20, 105, 147);
            trect2 = trect1;
            this.AddMouse( trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
            y1 += num24;
          }
          else
          {
            if (num16 <= 15)
            {
              if (num16 <= 3)
              {
                x5 = num16 * 47 + 20;
                y1 = 330 + num17;
                num18 = 55;
              }
              else if (num16 <= 7)
              {
                x5 = (num16 - 4) * 47 + 20;
                y1 = 385 + num17;
                num18 = 110;
              }
              else if (num16 <= 11)
              {
                x5 = (num16 - 8) * 47 + 20;
                y1 = 440 + num17;
                num18 = 165;
              }
              else if (num16 <= 15)
              {
                x5 = (num16 - 12) * 47 + 20;
                y1 = 495 + num17;
                num18 = 220;
              }
            }
            if (this.His > -1)
            {
               Graphics local11 =  g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
               Bitmap local12 =  bitmap1;
              int x8 = x5;
              int y4 = y1;
              DrawMod.DrawSimple( local11,  local12, x8, y4);
            }
            else
            {
               Graphics local13 =  g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
               Bitmap local14 =  bitmap1;
              int x9 = x5;
              int y5 = y1;
              DrawMod.DrawSimple( local13,  local14, x9, y5);
            }
            trect1 = new Rectangle(x5, y1, 33, 46);
            trect2 = trect1;
            this.AddMouse( trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
          }
        }
      }
      int num25 = 0;
      int num26 = -1;
      int num27 = num17 + num18;
      int num28 = 0;
      int deckCardCounter4 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter4; index += 1)
      {
        int num29 = 1;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 0)
          num29 = 0;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 1)
          num29 = 0;
        if (this.game.Data.Product == 6 && this.game.Data.HistoricalUnitObj[this.His].Type < 6)
          num29 = 0;
        if (num29 == 1)
          num28 += 1;
      }
      int deckCardCounter5 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter5; index += 1)
      {
        int num30 = 1;
        if (this.game.EditObj.OrderType != 45)
        {
          int num31 = this.game.Data.HistoricalUnitObj[this.His].Type < 6 & this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 2 ? 1 : 0;
        }
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 0)
          num30 = 0;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 1)
          num30 = 0;
        if (this.game.Data.Product == 6 && this.game.Data.HistoricalUnitObj[this.His].Type < 6)
          num30 = 0;
        if (num30 == 1)
        {
          num26 += 1;
          num25 += 1;
          if (num25 == 1)
          {
            int num32 = num27 + 12;
            x5 = 20;
            y1 = 330 + num32;
            tstring: String = "Strategic deck cards:";
            DrawMod.DrawTextColouredMarc( g, tstring, this.game.MarcFont8b, x5, y1, Color.White);
            num27 = num32 + 24;
          }
          if (this.game.Data.Product == 6)
          {
            int num33 =  Math.Round(133.0 / (double) Math.Max(1, num28 - 1));
             Graphics local15 =  g;
            bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 2);
             Bitmap local16 =  bitmap1;
            int x10 = x5;
            int y6 = y1 + 20;
            DrawMod.DrawSimple( local15,  local16, x10, y6);
            trect1 = new Rectangle(x5, y1 + 20, 105, 147);
            trect2 = trect1;
            this.AddMouse( trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
            y1 += num33;
          }
          else
          {
            if (num26 <= 15)
            {
              if (num26 <= 3)
              {
                x5 = num26 * 47 + 20;
                y1 = 330 + num27;
              }
              else if (num26 <= 7)
              {
                x5 = (num26 - 4) * 47 + 20;
                y1 = 385 + num27;
              }
              else if (num26 <= 11)
              {
                x5 = (num26 - 8) * 47 + 20;
                y1 = 440 + num27;
              }
              else if (num26 <= 15)
              {
                x5 = (num26 - 12) * 47 + 20;
                y1 = 495 + num27;
              }
            }
            if (this.His > -1)
            {
               Graphics local17 =  g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
               Bitmap local18 =  bitmap1;
              int x11 = x5;
              int y7 = y1;
              DrawMod.DrawSimple( local17,  local18, x11, y7);
            }
            else
            {
               Graphics local19 =  g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
               Bitmap local20 =  bitmap1;
              int x12 = x5;
              int y8 = y1;
              DrawMod.DrawSimple( local19,  local20, x12, y8);
            }
            trect1 = new Rectangle(x5, y1, 33, 46);
            trect2 = trect1;
            this.AddMouse( trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
          }
        }
      }
      if (this.game.HandyFunctionsObj.GetVisibleHisVar(this.His) > 0 & flag1)
      {
        let mut tsubpart: SubPartClass =  new TextAreaClass2(this.game, 420, 25, this.game.MarcFont8, this.game.Data.HistoricalUnitObj[this.His].Descript, tbackbitmap: ( this.BackBitmap), bbx: 210, bby: 150);
        this.TAid = this.AddSubPart( tsubpart, 210, 150, 420, 432, 0);
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextAreaClass2(this.game, 420, 29, this.game.MarcFont8, this.game.Data.HistoricalUnitObj[this.His].Descript, tbackbitmap: ( this.BackBitmap), bbx: 210, bby: 56);
        this.TAid = this.AddSubPart( tsubpart, 210, 56, 420, 496, 0);
      }
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("OK", 150, "Click to return to main screen.",  this.OwnBitmap, 316, 615, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart( tsubpart1, 316, 615, 150, 40, 1);
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27 | nr == 32)
        {
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if (nr == 40)
        {
          this.SubPartList[this.SubpartNr(this.TAid)].ShiftDown();
          this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 38)
        {
          this.SubPartList[this.SubpartNr(this.TAid)].ShiftUp();
          this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 37)
        {
          this.SubPartList[this.SubpartNr(this.TAid)].ShiftLeft();
          this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 39)
        {
          this.SubPartList[this.SubpartNr(this.TAid)].ShiftRight();
          this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
          windowReturnClass.SetFlag(true);
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
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
            if (num == this.TAid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.cancelid)
            {
              windowReturnClass.AddCommand(6, 0);
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
