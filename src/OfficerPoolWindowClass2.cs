// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OfficerPoolWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class OfficerPoolWindowClass2 : WindowClass
  {
    private int LocNr;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int b1bid;
    private int B1TextId;
    private int B2Id;
    private int b2bid;
    private int B2TextId;
    private int B3Id;
    private int b3bid;
    private int B3TextId;
    private int B4Id;
    private int b4bid;
    private int B4TextId;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int detailnr;
    private int w;
    private int h;

    public OfficerPoolWindowClass2(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, 222, BackSprite: tGame.MARCBOTBAR)
    {
      this.w = tGame.ScreenWidth;
      this.h = 222;
      this.BlockBlit = true;
      this.detailnr = -1;
      this.dostuff();
    }

    public override void DoRefresh()
    {
      if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      this.dostuff();
    }

    private void dostuff()
    {
      SizeF sizeF1 = new SizeF();
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.b1bid > 0)
        this.RemoveSubPart(this.b1bid);
      if (this.b2bid > 0)
        this.RemoveSubPart(this.b2bid);
      if (this.b3bid > 0)
        this.RemoveSubPart(this.b3bid);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      int num1 = (int) Math.Round((double) (this.w - 1024) / 2.0);
      this.NewBackGroundAndClearAll(this.w, this.h, this.game.MARCBOTBAR);
      this.ClearMouse();
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int index1;
      if (this.game.EditObj.OrderUnit > -1)
      {
        index1 = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical;
        if (!Information.IsNothing((object) this.game.Data.HistoricalUnitObj[index1].CommanderName))
          ;
        if (!this.game.Data.UnitObj[this.game.EditObj.OrderUnit].IsHQ)
          index1 = -1;
      }
      else
        index1 = this.game.EditObj.OrderUnit;
      int num2 = -1;
      int num3 = -1;
      DrawMod.DrawTextColouredMarc(ref graphics, "OFFICER POOL", this.game.MarcFont8b, num1 + 10, 14, Color.White);
      int num4;
      Bitmap bitmap;
      if (this.OptionsListId == 0)
      {
        this.OptionsListObj = new ListClass();
        int num5 = -1;
        num4 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
        {
          if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[tdata].CommanderName))
            this.game.Data.HistoricalUnitObj[tdata].CommanderName = "";
          if (this.game.Data.HistoricalUnitObj[tdata].Pool & this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata].CommanderName.Length >= 1)
          {
            int num6 = 0;
            if (index1 == -1)
              num6 = 1;
            else if (this.game.Data.HistoricalUnitObj[index1].People == -1 | this.game.Data.HistoricalUnitObj[index1].People == this.game.Data.HistoricalUnitObj[tdata].People | this.game.Data.HistoricalUnitObj[tdata].People == -1)
              num6 = 1;
            if (num6 == 1)
            {
              string commanderName = this.game.Data.HistoricalUnitObj[tdata].CommanderName;
              if (this.game.Data.HistoricalUnitObj[tdata].People > -1)
                this.OptionsListObj.add(commanderName, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP)) + "PP", tbmp: BitmapStore.GetBitmap(this.game.Data.PeopleObj[this.game.Data.HistoricalUnitObj[tdata].People].NationalSpriteID, 1));
              else
                this.OptionsListObj.add(commanderName, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP)) + "PP");
              ++num5;
              if (num2 == -1)
              {
                num2 = num5;
                num3 = tdata;
              }
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (tdata == this.detailnr)
                num4 = num5;
            }
          }
        }
        if (num5 > -1)
        {
          if (this.OptionsListId > 0)
          {
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            ListClass optionsListObj = this.OptionsListObj;
            int tlistselect = num4;
            GameClass game = this.game;
            ref Bitmap local1 = ref this.OwnBitmap;
            int bbx = num1 + 5;
            Font font = (Font) null;
            ref Font local2 = ref font;
            SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 10, 350, tlistselect, game, tShowPair: true, tValueWidth: 80, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: 34, tMarcStyle: true, overruleFont: (ref local2));
            this.OptionsListId = this.AddSubPart(ref tsubpart, num1 + 5, 34, 350, 208, 0);
          }
        }
        else
        {
          this.RemoveSubPart(this.OptionsListId);
          this.OptionsListObj = new ListClass();
          ListClass optionsListObj = this.OptionsListObj;
          GameClass game = this.game;
          ref Bitmap local3 = ref this.OwnBitmap;
          int bbx = num1;
          Font font = (Font) null;
          ref Font local4 = ref font;
          SubPartClass subPartClass = (SubPartClass) new ListSubPartClass(optionsListObj, 10, 350, -1, game, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: bbx, bby: 34, tMarcStyle: true, overruleFont: (ref local4));
          ref Graphics local5 = ref graphics;
          bitmap = subPartClass.Paint();
          ref Bitmap local6 = ref bitmap;
          int x = num1;
          DrawMod.DrawSimple(ref local5, ref local6, x, 34);
          DrawMod.DrawTextColouredMarc(ref graphics, "Empty Pool", this.game.MarcFont1, num1 + 85, 105, Color.FromArgb(128, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          subPartClass.OwnBitmap.Dispose();
        }
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "Base cost: " + this.game.Data.RuleVar[904].ToString() + "PP.", this.game.MarcFont4, num1 + 870, 24, Color.White);
      int num7;
      int num8 = (int) Math.Round((double) ((float) num7 + this.game.Data.RuleVar[904]));
      if (index1 > -1)
      {
        if (this.game.Data.HistoricalUnitObj[index1].PP > 0)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "No PP cost to dismiss.", this.game.MarcFont4, num1 + 870, 54, Color.White);
        }
        else
        {
          DrawMod.DrawTextColouredMarc(ref graphics, Strings.Trim(Conversion.Str((object) Math.Abs(this.game.Data.HistoricalUnitObj[index1].PP))) + " PP cost to dismiss.", this.game.MarcFont4, num1 + 870, 54, Color.White);
          num8 += Math.Abs(this.game.Data.HistoricalUnitObj[index1].PP);
        }
        DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.HistoricalUnitObj[index1].CommanderName, this.game.MarcFont4, num1 + 870, 70, Color.White);
      }
      if (this.detailnr > -1)
      {
        if (this.game.Data.HistoricalUnitObj[this.detailnr].PP < 0)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "No PP cost to appoint.", this.game.MarcFont4, num1 + 870, 100, Color.White);
        }
        else
        {
          DrawMod.DrawTextColouredMarc(ref graphics, Strings.Trim(Conversion.Str((object) Math.Abs(this.game.Data.HistoricalUnitObj[this.detailnr].PP))) + " PP cost to appoint.", this.game.MarcFont4, num1 + 870, 100, Color.White);
          num8 += Math.Abs(this.game.Data.HistoricalUnitObj[this.detailnr].PP);
        }
        DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.HistoricalUnitObj[this.detailnr].CommanderName, this.game.MarcFont4, num1 + 870, 116, Color.White);
      }
      if (num4 == -1)
        this.detailnr = num3;
      if (index1 > -1 & this.detailnr > -1)
      {
        if (this.game.Data.HistoricalUnitObj[this.detailnr].People == this.game.Data.HistoricalUnitObj[index1].People | this.game.Data.HistoricalUnitObj[this.detailnr].People == -1 | this.game.Data.HistoricalUnitObj[index1].People == -1)
        {
          if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[index1].CommanderName))
            this.game.Data.HistoricalUnitObj[index1].CommanderName = "";
          if (this.detailnr > -1 & index1 > -1)
          {
            if (this.game.Data.Round == 0)
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "Click to swap officer in selected HQ with officer selected in officerpool", ref this.OwnBitmap, num1 + 870, 150, theight: 65, useshadow: true, tMarcStyle: true);
              this.B2Id = this.AddSubPart(ref tsubpart, num1 + 870, 150, 140, 65, 1);
            }
            else if ((double) this.game.Data.RuleVar[896] == 1.0 & this.game.Data.HistoricalUnitObj[index1].Type == 8 & this.game.Data.HistoricalUnitObj[index1].CommanderName.Length > 1)
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "You are not allowed to swap the officer of the high command HQ.", ref this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
              this.b2bid = this.AddSubPart(ref tsubpart, num1 + 870, 150, 140, 65, 0);
            }
            else
            {
              int num9 = 0;
              if (this.game.Data.HistoricalUnitObj[this.detailnr].PP > 0)
                num9 += this.game.Data.HistoricalUnitObj[this.detailnr].PP;
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].PP < 0)
              {
                int num10 = num9 + Math.Abs(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].PP);
              }
              if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= num8)
              {
                SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "Click to swap officer in selected HQ with officer selected in officerpool", ref this.OwnBitmap, num1 + 870, 150, theight: 65, useshadow: true, tMarcStyle: true);
                this.B2Id = this.AddSubPart(ref tsubpart, num1 + 870, 150, 140, 65, 1);
              }
              else
              {
                SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "You dont have the PP to appoint this officer or the PP to remove the officer in the unit.", ref this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
                this.b2bid = this.AddSubPart(ref tsubpart, num1 + 870, 150, 140, 65, 0);
              }
            }
          }
          else if (this.detailnr > -1 & index1 == -1)
          {
            int num11 = 0;
            if (this.game.Data.HistoricalUnitObj[this.detailnr].PP > 0)
              num11 += this.game.Data.HistoricalUnitObj[this.detailnr].PP;
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= num11)
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT", 140, "Click to appoint officer to selected HQ without any officer", ref this.OwnBitmap, num1 + 870, 150, theight: 65, useshadow: true, tMarcStyle: true);
              this.B4Id = this.AddSubPart(ref tsubpart, num1 + 870, 150, 100, 65, 1);
            }
            else
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT", 140, "You dont have the PP to appoint this officer..", ref this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
              this.b2bid = this.AddSubPart(ref tsubpart, num1 + 870, 150, 100, 65, 0);
            }
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT", 140, "You have either not selected a unit on the map with an officer\r\nor you have not selected an officer in the officerpool.", ref this.OwnBitmap, num1 + 870, 150, true, theight: 65, tMarcStyle: true);
            this.b2bid = this.AddSubPart(ref tsubpart, num1 + 870, 150, 100, 65, 0);
          }
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT", 140, "People mismatch. Officer from officerpool and unit must have matching people.", ref this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
          this.b2bid = this.AddSubPart(ref tsubpart, num1 + 870, 150, 100, 65, 0);
        }
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("APPOINT", 140, "You have to select a HQ first.", ref this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
        this.b2bid = this.AddSubPart(ref tsubpart, num1 + 870, 150, 100, 65, 0);
      }
      int his = index1;
      if (his > -1)
      {
        if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[index1].CommanderName))
          his = -1;
        else if (this.game.Data.HistoricalUnitObj[index1].CommanderName.Length <= 0)
          his = -1;
      }
      Rectangle trect1;
      SizeF sizeF2;
      Rectangle trect2;
      if (his > -1)
      {
        int num12 = (int) Math.Round((double) (this.w - 1024) / 2.0) + 400;
        DrawMod.DrawOfficer(graphics, his, num12 + 12, 34, 65, 72);
        trect1 = new Rectangle(num12 + 12, 34, 65, 72);
        this.AddMouse(ref trect1, "OFFICER PORTRAIT", "Click to get full stats and biography", 50);
        ref Graphics local7 = ref graphics;
        bitmap = this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderUnit, true);
        ref Bitmap local8 = ref bitmap;
        int x1 = num12 + 12 + 45;
        DrawMod.DrawSimple(ref local7, ref local8, x1, 76);
        if ((double) this.game.Data.RuleVar[879] < 1.0)
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "\r\n\r\n" + this.game.Data.HistoricalUnitObj[his].Descript, 12, ref this.BackBitmap, num12 + 110, 22, true);
          ref Graphics local9 = ref graphics;
          bitmap = textAreaClass2.Paint();
          ref Bitmap local10 = ref bitmap;
          int x2 = num12 + 110;
          DrawMod.DrawSimple(ref local9, ref local10, x2, -7);
          trect1 = new Rectangle(num12 + 105, 34, 280, 100);
          Rectangle trect3 = trect1;
          this.AddMouse(ref trect3, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.HistoricalUnitObj[his].CommanderName, this.game.MarcFont6, num12 + 125, 44, Color.White);
        }
        else
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12, ref this.BackBitmap, num12 + 110, 22, true);
          ref Graphics local11 = ref graphics;
          bitmap = textAreaClass2.Paint();
          ref Bitmap local12 = ref bitmap;
          int x3 = num12 + 110;
          DrawMod.DrawSimple(ref local11, ref local12, x3, 22);
          trect1 = new Rectangle(num12 + 105, 34, 280, 45);
          Rectangle trect4 = trect1;
          this.AddMouse(ref trect4, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.HistoricalUnitObj[his].CommanderName, this.game.MarcFont6, num12 + 125, 44, Color.White);
          int num13 = 110;
          while (num13 < 365)
          {
            DrawMod.DrawBlockGradient2(ref graphics, num12 + num13, 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
            int index2;
            if (this.game.Data.HistoricalUnitObj[his].HisVarCount >= index2)
            {
              bool flag = true;
              if (this.game.Data.HistoricalUnitObj[his].HisVarType[index2] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[his].HisVarType[index2]], "1", false) == 0)
                flag = false;
              if (flag & (this.game.Data.HistoricalUnitObj[his].HisVarNato[index2] > 0 | this.game.Data.HistoricalUnitObj[his].HisVarSmall[index2] > -1))
              {
                DrawMod.DrawBlock(ref graphics, num12 + num13, 67, 37, 2, (int) this.game.MarcCol3.R, (int) this.game.MarcCol3.G, (int) this.game.MarcCol3.B, (int) byte.MaxValue);
                DrawMod.DrawBlockGradient2(ref graphics, num12 + num13, 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
                string str = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[his].HisVarValue[index2]));
                sizeF2 = graphics.MeasureString(str, this.game.MarcFont8b);
                int x4 = (int) Math.Round((double) ((float) (num12 + num13 + 18) - sizeF2.Width / 2f));
                DrawMod.DrawTextColouredMarc(ref graphics, str, this.game.MarcFont8b, x4, 90, Color.White);
                if (this.game.Data.HistoricalUnitObj[his].HisVarSmall[index2] > -1)
                {
                  ref Graphics local13 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[his].HisVarSmall[index2]]);
                  ref Bitmap local14 = ref bitmap;
                  int x5 = x4;
                  DrawMod.DrawSimple(ref local13, ref local14, x5, 71);
                }
                else
                {
                  ref Graphics local15 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[his].HisVarNato[index2]]);
                  ref Bitmap local16 = ref bitmap;
                  int x6 = x4;
                  DrawMod.DrawSimple(ref local15, ref local16, x6, 71);
                }
                trect1 = new Rectangle(x4, 71, 35, 50);
                trect2 = trect1;
                this.AddMouse(ref trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[his].HisVarType[index2]]);
                num13 += 35;
              }
            }
            else
              num13 = 365;
            ++index2;
          }
        }
        DrawMod.DrawTextColouredMarc(ref graphics, "SELECTED UNIT OFFICER", this.game.MarcFont8b, num12 + 10, 14, Color.White);
      }
      else
      {
        int num14 = (int) Math.Round((double) (this.w - 1024) / 2.0) + 400;
        TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12, ref this.BackBitmap, num14 + 110, 22, true);
        ref Graphics local17 = ref graphics;
        bitmap = textAreaClass2.Paint();
        ref Bitmap local18 = ref bitmap;
        int x = num14 + 110;
        DrawMod.DrawSimple(ref local17, ref local18, x, 22);
        DrawMod.DrawTextColouredMarc(ref graphics, "No officer in selected HQ", this.game.MarcFont6, num14 + 125, 44, Color.White);
        DrawMod.DrawTextColouredMarc(ref graphics, "SELECTED UNIT OFFICER", this.game.MarcFont8b, num14 + 10, 14, Color.White);
      }
      if (this.detailnr > -1)
      {
        int detailnr = this.detailnr;
        int num15 = 108;
        int num16 = (int) Math.Round((double) (this.w - 1024) / 2.0) + 400;
        DrawMod.DrawOfficer(graphics, detailnr, num16 + 12, num15 + 34, 65, 72);
        trect1 = new Rectangle(num16 + 12, num15 + 34, 65, 72);
        trect2 = trect1;
        this.AddMouse(ref trect2, "OFFICER PORTRAIT", "Click to get full stats and biography", 51);
        if ((double) this.game.Data.RuleVar[879] < 1.0)
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "\r\n\r\n" + this.game.Data.HistoricalUnitObj[detailnr].Descript, 12, ref this.BackBitmap, num16 + 110, num15 + 22, true);
          ref Graphics local19 = ref graphics;
          bitmap = textAreaClass2.Paint();
          ref Bitmap local20 = ref bitmap;
          int x = num16 + 110;
          int y = num15 - 7;
          DrawMod.DrawSimple(ref local19, ref local20, x, y);
          trect1 = new Rectangle(num16 + 105, num15 + 34, 280, 100);
          trect2 = trect1;
          this.AddMouse(ref trect2, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.HistoricalUnitObj[detailnr].CommanderName, this.game.MarcFont6, num16 + 125, num15 + 44, Color.White);
        }
        else
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12, ref this.BackBitmap, num16 + 110, num15 + 22, true);
          ref Graphics local21 = ref graphics;
          bitmap = textAreaClass2.Paint();
          ref Bitmap local22 = ref bitmap;
          int x7 = num16 + 110;
          int y1 = num15 + 22;
          DrawMod.DrawSimple(ref local21, ref local22, x7, y1);
          trect1 = new Rectangle(num16 + 105, num15 + 34, 280, 45);
          trect2 = trect1;
          this.AddMouse(ref trect2, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.HistoricalUnitObj[detailnr].CommanderName, this.game.MarcFont6, num16 + 125, num15 + 44, Color.White);
          int num17 = 110;
          DrawMod.DrawBlock(ref graphics, num16 + num17, num15 + 67, 247, 2, (int) this.game.MarcCol3.R, (int) this.game.MarcCol3.G, (int) this.game.MarcCol3.B, (int) byte.MaxValue);
          for (; num17 < 365; num17 += 35)
          {
            DrawMod.DrawBlockGradient2(ref graphics, num16 + num17, num15 + 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
            int index3;
            if (this.game.Data.HistoricalUnitObj[detailnr].HisVarCount >= index3)
            {
              bool flag = true;
              if (this.game.Data.HistoricalUnitObj[detailnr].HisVarType[index3] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[detailnr].HisVarType[index3]], "1", false) == 0)
                flag = false;
              if (flag & (this.game.Data.HistoricalUnitObj[detailnr].HisVarNato[index3] > 0 | this.game.Data.HistoricalUnitObj[detailnr].HisVarSmall[index3] > -1))
              {
                string str = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[detailnr].HisVarValue[index3]));
                sizeF2 = graphics.MeasureString(str, this.game.MarcFont8b);
                int x8 = (int) Math.Round((double) ((float) (num16 + num17 + 18) - sizeF2.Width / 2f));
                DrawMod.DrawTextColouredMarc(ref graphics, str, this.game.MarcFont8b, x8, num15 + 90, Color.White);
                if (this.game.Data.HistoricalUnitObj[detailnr].HisVarSmall[index3] > -1)
                {
                  ref Graphics local23 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[detailnr].HisVarSmall[index3]]);
                  ref Bitmap local24 = ref bitmap;
                  int x9 = x8;
                  int y2 = num15 + 71;
                  DrawMod.DrawSimple(ref local23, ref local24, x9, y2);
                }
                else
                {
                  ref Graphics local25 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[detailnr].HisVarNato[index3]]);
                  ref Bitmap local26 = ref bitmap;
                  int x10 = x8;
                  int y3 = num15 + 71;
                  DrawMod.DrawSimple(ref local25, ref local26, x10, y3);
                }
                trect1 = new Rectangle(x8, num15 + 71, 35, 50);
                trect2 = trect1;
                this.AddMouse(ref trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[detailnr].HisVarType[index3]]);
              }
            }
            ++index3;
          }
        }
        DrawMod.DrawTextColouredMarc(ref graphics, "SELECTED POOL OFFICER", this.game.MarcFont8b, num16 + 10, num15 + 14, Color.White);
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] == 51)
          {
            this.game.EditObj.PopupValue = 4;
            this.game.EditObj.OfficerHisOverrule = this.detailnr;
            this.game.EditObj.HandCard = 0;
            windowReturnClass.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 50)
          {
            this.game.EditObj.PopupValue = 4;
            this.game.EditObj.HandCard = 0;
            windowReturnClass.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.B4Id)
            {
              this.game.ProcessingObj.SwapOfficer(this.game.Data.Turn, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical, this.detailnr, this.game.EditObj.OrderUnit);
              this.game.Data.RemoveHistoricalUnit(this.detailnr);
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
              this.detailnr = -1;
              this.dostuff();
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              this.game.ProcessingObj.SwapOfficer(this.game.Data.Turn, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical, this.detailnr, this.game.EditObj.OrderUnit);
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
              string s = "I took command of " + this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Name;
              string commanderName = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].CommanderName;
              this.game.HandyFunctionsObj.AddMessageForOne(s, this.game.Data.Turn, 10000 + this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical, 1);
              this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter] = commanderName;
              this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
              this.detailnr = -1;
              this.dostuff();
              windowReturnClass.AddCommand(4, 67);
              this.game.EditObj.PopupValue = 0;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.dostuff();
              }
              if (num2 == -2)
              {
                this.detailnr = -1;
                this.dostuff();
              }
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

    public void PopUpRefresh()
    {
    }
  }
}
