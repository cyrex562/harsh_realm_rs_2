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
  public class OfficerInfoWindowClass2 : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int TAid;
    private int His;
    private int Card;

    public OfficerInfoWindowClass2(ref GameClass tGame)
      : base(ref tGame, 680, 680, 8)
    {
      this.His = this.game.EditObj.OfficerHisOverrule > 0 ? this.game.EditObj.OfficerHisOverrule : tGame.Data.UnitObj[tGame.EditObj.UnitSelected].Historical;
      this.game.EditObj.OfficerHisOverrule = -1;
      this.View();
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
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

    public void View()
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
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 680, 680);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      int commanderSpriteId = this.game.Data.HistoricalUnitObj[this.His].CommanderSpriteID;
      SizeF sizeF1 = new SizeF();
      sizeF1 = g.MeasureString(this.game.Data.HistoricalUnitObj[this.His].CommanderName, new Font(this.game.FontCol.Families[1], 48f, FontStyle.Regular, GraphicsUnit.Pixel));
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.HistoricalUnitObj[this.His].CommanderName, this.game.MarcFont1, 20, 19, Color.White);
      DrawMod.DrawOfficer(g, this.His, 20, 70, 177, 194);
      Rectangle trect1;
      Rectangle trect2;
      if ((double) this.game.Data.RuleVar[976] < 1.0)
      {
        int num1 = 270;
        DrawMod.DrawBlockGradient2(ref g, 20, num1, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, 20, num1, 80, 20, -1, -1);
        string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].CombatMod)) + "%";
        if (this.game.Data.HistoricalUnitObj[this.His].CombatMod > 0)
          str1 = "+" + str1;
        DrawMod.DrawTextColouredMarc(ref g, "COM = " + str1, this.game.MarcFont5, 25, num1 + 4, Color.White);
        if ((double) this.game.Data.RuleVar[927] > 0.0)
        {
          trect1 = new Rectangle(20, num1, 80, 20);
          this.AddMouse(ref trect1, "COMBAT MODIFIER", "How much percent does the officer increase\r\nstaff combat bonus.\r\nMind you: Only if the officer is in command at the lowest HQ level!");
        }
        else
        {
          trect1 = new Rectangle(20, num1, 80, 20);
          Rectangle trect3 = trect1;
          this.AddMouse(ref trect3, "COMBAT MODIFIER", "How much percent does the officer increase\r\nstaff combat bonus.");
        }
        int num2 = 300;
        DrawMod.DrawBlockGradient2(ref g, 20, num2, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, 20, num2, 80, 20, -1, -1);
        string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].MoraleMod)) + "%";
        if (this.game.Data.HistoricalUnitObj[this.His].MoraleMod > 0)
          str2 = "+" + str2;
        DrawMod.DrawTextColouredMarc(ref g, "MOR = " + str2, this.game.MarcFont5, 25, num2 + 4, Color.White);
        if ((double) this.game.Data.RuleVar[927] > 0.0)
        {
          trect1 = new Rectangle(20, num2, 80, 20);
          Rectangle trect4 = trect1;
          this.AddMouse(ref trect4, "MORALE MODIFIER", "How much percent does the officer increase \r\n regular morale recovery.\r\nMind you: Only if the officer is in command at the lowest HQ level!");
        }
        else
        {
          trect1 = new Rectangle(20, num2, 80, 20);
          Rectangle trect5 = trect1;
          this.AddMouse(ref trect5, "MORALE MODIFIER", "How much percent does the officer increase \r\n regular morale recovery.");
        }
        int num3 = 270;
        DrawMod.DrawBlockGradient2(ref g, 110, num3, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, 110, num3, 80, 20, -1, -1);
        string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].StaffSize));
        DrawMod.DrawTextColouredMarc(ref g, "STAFF = " + str3, this.game.MarcFont5, 120, num3 + 4, Color.White);
        trect1 = new Rectangle(110, num3, 80, 20);
        Rectangle trect6 = trect1;
        this.AddMouse(ref trect6, "STAFF POINTS", "How much staff points can officer \r\n handle in this scenario.");
        int num4 = 300;
        if ((double) this.game.Data.RuleVar[343] == 1.0)
        {
          DrawMod.DrawBlockGradient2(ref g, 110, num4, 79, 19, this.game.MarcCol1, this.game.MarcCol2);
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, 110, num4, 80, 20, -1, -1);
          string str4 = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].PP));
          DrawMod.DrawTextColouredMarc(ref g, "POL = " + str4, this.game.MarcFont5, 120, num4 + 4, Color.White);
          trect1 = new Rectangle(110, num4, 80, 20);
          trect2 = trect1;
          this.AddMouse(ref trect2, "POLITICAL VALUE", "If has negative points here \r\n it costs PP to reassign units under this officer.");
        }
      }
      bool flag1 = false;
      int hisVarCount = this.game.Data.HistoricalUnitObj[this.His].HisVarCount;
      for (int index = 0; index <= hisVarCount; ++index)
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
        TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 420, 3, this.game.MarcFont13, "", 12, ref this.BackBitmap, bbx, num5, true);
        ref Graphics local1 = ref g;
        Bitmap bitmap2 = textAreaClass2.Paint();
        ref Bitmap local2 = ref bitmap2;
        int x1 = bbx;
        int y = num5;
        DrawMod.DrawSimple(ref local1, ref local2, x1, y);
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
              string str = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.His].HisVarValue[index]));
              SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont8b);
              int num7 = bbx + num6;
              int num8 = num5 + 10;
              DrawMod.DrawBlock(ref g, num7 + 36, num5 + 13, 2, 64, (int) this.game.MarcCol3.R, (int) this.game.MarcCol3.G, (int) this.game.MarcCol3.B, 128);
              int x2 = (int) Math.Round((double) ((float) (bbx + num6 + 18) - sizeF2.Width / 2f));
              DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont8b, x2, 105, Color.White);
              if (this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index] > -1)
              {
                ref Graphics local3 = ref g;
                bitmap1 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.His].HisVarSmall[index]]);
                ref Bitmap local4 = ref bitmap1;
                int x3 = x2;
                DrawMod.DrawSimple(ref local3, ref local4, x3, 81);
              }
              else
              {
                ref Graphics local5 = ref g;
                bitmap1 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[this.His].HisVarNato[index]]);
                ref Bitmap local6 = ref bitmap1;
                int x4 = x2;
                DrawMod.DrawSimple(ref local5, ref local6, x4, 81);
              }
              if (this.game.Data.Turn == this.game.Data.HistoricalUnitObj[this.His].TempRegime)
              {
                trect1 = new Rectangle(x2, num5, 35, 50);
                trect2 = trect1;
                this.AddMouse(ref trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[this.His].HisVarType[index]]);
              }
              num6 += 35;
            }
          }
          else
            num6 = 380;
          ++index;
        }
      }
      int num9 = -1;
      int num10 = -12;
      int num11 = 0;
      int deckCardCounter1 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      int x5;
      int y1;
      int num12;
      for (int index = 0; index <= deckCardCounter1; ++index)
      {
        int num13 = 1;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow > 0)
          num13 = 0;
        if (num13 == 1)
        {
          ++num9;
          ++num11;
          if (num11 == 1)
          {
            int num14 = num10 + 12;
            x5 = 20;
            y1 = 330 + num14;
            string tstring = "Officer deck cards:";
            DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8b, x5, y1, Color.White);
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
          ref Graphics local7 = ref g;
          bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.HistoricalUnitObj[this.His].TempRegime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
          ref Bitmap local8 = ref bitmap1;
          int x6 = x5;
          int y2 = y1;
          DrawMod.DrawSimple(ref local7, ref local8, x6, y2);
          trect1 = new Rectangle(x5, y1, 33, 46);
          trect2 = trect1;
          this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
        }
      }
      int num15 = 0;
      int num16 = -1;
      int num17 = num10 + num12;
      int num18 = 0;
      int num19 = 0;
      int deckCardCounter2 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter2; ++index)
      {
        int num20 = 1;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 0)
          num20 = 0;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 2)
          num20 = 0;
        if (this.game.Data.Product == 6 && this.game.Data.HistoricalUnitObj[this.His].Type > 5)
          num20 = 0;
        if (num20 == 1)
          ++num19;
      }
      int deckCardCounter3 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter3; ++index)
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
          ++num16;
          ++num15;
          if (num15 == 1)
          {
            int num23 = num17 + 12;
            x5 = 20;
            y1 = 330 + num23;
            string tstring = "Tactical deck cards:";
            DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8b, x5, y1, Color.White);
            num17 = num23 + 24;
          }
          if (this.game.Data.Product == 6)
          {
            int num24 = (int) Math.Round(133.0 / (double) Math.Max(1, num19 - 1));
            ref Graphics local9 = ref g;
            bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 2);
            ref Bitmap local10 = ref bitmap1;
            int x7 = x5;
            int y3 = y1 + 20;
            DrawMod.DrawSimple(ref local9, ref local10, x7, y3);
            trect1 = new Rectangle(x5, y1 + 20, 105, 147);
            trect2 = trect1;
            this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
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
              ref Graphics local11 = ref g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
              ref Bitmap local12 = ref bitmap1;
              int x8 = x5;
              int y4 = y1;
              DrawMod.DrawSimple(ref local11, ref local12, x8, y4);
            }
            else
            {
              ref Graphics local13 = ref g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
              ref Bitmap local14 = ref bitmap1;
              int x9 = x5;
              int y5 = y1;
              DrawMod.DrawSimple(ref local13, ref local14, x9, y5);
            }
            trect1 = new Rectangle(x5, y1, 33, 46);
            trect2 = trect1;
            this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
          }
        }
      }
      int num25 = 0;
      int num26 = -1;
      int num27 = num17 + num18;
      int num28 = 0;
      int deckCardCounter4 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter4; ++index)
      {
        int num29 = 1;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 0)
          num29 = 0;
        if (this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].LimitedShow == 1)
          num29 = 0;
        if (this.game.Data.Product == 6 && this.game.Data.HistoricalUnitObj[this.His].Type < 6)
          num29 = 0;
        if (num29 == 1)
          ++num28;
      }
      int deckCardCounter5 = this.game.Data.HistoricalUnitObj[this.His].DeckCardCounter;
      for (int index = 0; index <= deckCardCounter5; ++index)
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
          ++num26;
          ++num25;
          if (num25 == 1)
          {
            int num32 = num27 + 12;
            x5 = 20;
            y1 = 330 + num32;
            string tstring = "Strategic deck cards:";
            DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont8b, x5, y1, Color.White);
            num27 = num32 + 24;
          }
          if (this.game.Data.Product == 6)
          {
            int num33 = (int) Math.Round(133.0 / (double) Math.Max(1, num28 - 1));
            ref Graphics local15 = ref g;
            bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 2);
            ref Bitmap local16 = ref bitmap1;
            int x10 = x5;
            int y6 = y1 + 20;
            DrawMod.DrawSimple(ref local15, ref local16, x10, y6);
            trect1 = new Rectangle(x5, y1 + 20, 105, 147);
            trect2 = trect1;
            this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
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
              ref Graphics local17 = ref g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
              ref Bitmap local18 = ref bitmap1;
              int x11 = x5;
              int y7 = y1;
              DrawMod.DrawSimple(ref local17, ref local18, x11, y7);
            }
            else
            {
              ref Graphics local19 = ref g;
              bitmap1 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.HistoricalUnitObj[this.His].DeckCard[index], size: 3, Percent: this.game.Data.HistoricalUnitObj[this.His].DeckChance[index]);
              ref Bitmap local20 = ref bitmap1;
              int x12 = x5;
              int y8 = y1;
              DrawMod.DrawSimple(ref local19, ref local20, x12, y8);
            }
            trect1 = new Rectangle(x5, y1, 33, 46);
            trect2 = trect1;
            this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Title, this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].Text + "\r\n\r\nEffect:\r\n" + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.His].DeckCard[index]].MouseOver, 700 + index);
          }
        }
      }
      if (this.game.HandyFunctionsObj.GetVisibleHisVar(this.His) > 0 & flag1)
      {
        SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 420, 25, this.game.MarcFont8, this.game.Data.HistoricalUnitObj[this.His].Descript, tbackbitmap: (ref this.BackBitmap), bbx: 210, bby: 150);
        this.TAid = this.AddSubPart(ref tsubpart, 210, 150, 420, 432, 0);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 420, 29, this.game.MarcFont8, this.game.Data.HistoricalUnitObj[this.His].Descript, tbackbitmap: (ref this.BackBitmap), bbx: 210, bby: 56);
        this.TAid = this.AddSubPart(ref tsubpart, 210, 56, 420, 496, 0);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("OK", 150, "Click to return to main screen.", ref this.OwnBitmap, 316, 615, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart1, 316, 615, 150, 40, 1);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
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

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
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
