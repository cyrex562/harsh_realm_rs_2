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
  pub class OfficerPoolWindowClass2 : WindowClass
  {
     int LocNr;
     int BNameId;
     int BNameTextId;
     int B1Id;
     int b1bid;
     int B1TextId;
     int B2Id;
     int b2bid;
     int B2TextId;
     int B3Id;
     int b3bid;
     int B3TextId;
     int B4Id;
     int b4bid;
     int B4TextId;
     int Text1Id;
     int Text2Id;
     int Text3Id;
     int OptionsListId;
     ListClass OptionsListObj;
     int detailnr;
     int w;
     int h;

    pub OfficerPoolWindowClass2( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, 222, BackSprite: tGame.MARCBOTBAR)
    {
      this.w = tGame.ScreenWidth;
      this.h = 222;
      this.BlockBlit = true;
      this.detailnr = -1;
      this.dostuff();
    }

    pub void DoRefresh()
    {
      if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      this.dostuff();
    }

     void dostuff()
    {
      SizeF sizeF1 = SizeF::new();
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
      int num1 =  Math.Round((double) (this.w - 1024) / 2.0);
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
      DrawMod.DrawTextColouredMarc( graphics, "OFFICER POOL", this.game.MarcFont8b, num1 + 10, 14, Color.White);
      int num4;
      Bitmap bitmap;
      if (this.OptionsListId == 0)
      {
        this.OptionsListObj = ListClass::new();
        int num5 = -1;
        num4 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; tdata += 1)
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
              commanderName: String = this.game.Data.HistoricalUnitObj[tdata].CommanderName;
              if (this.game.Data.HistoricalUnitObj[tdata].People > -1)
                this.OptionsListObj.add(commanderName, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP)) + "PP", tbmp: BitmapStore.GetBitmap(this.game.Data.PeopleObj[this.game.Data.HistoricalUnitObj[tdata].People].NationalSpriteID, 1));
              else
                this.OptionsListObj.add(commanderName, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP)) + "PP");
              num5 += 1;
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
            let mut game: GameClass = this.game;
             Bitmap local1 =  this.OwnBitmap;
            int bbx = num1 + 5;
            Font font =  null;
             Font local2 =  font;
            let mut tsubpart: SubPartClass =  new ListSubPartClass(optionsListObj, 10, 350, tlistselect, game, tShowPair: true, tValueWidth: 80, tdotopandbottom: false, tbackbitmap: ( local1), bbx: bbx, bby: 34, tMarcStyle: true, overruleFont: ( local2));
            this.OptionsListId = this.AddSubPart( tsubpart, num1 + 5, 34, 350, 208, 0);
          }
        }
        else
        {
          this.RemoveSubPart(this.OptionsListId);
          this.OptionsListObj = ListClass::new();
          ListClass optionsListObj = this.OptionsListObj;
          let mut game: GameClass = this.game;
           Bitmap local3 =  this.OwnBitmap;
          int bbx = num1;
          Font font =  null;
           Font local4 =  font;
          let mut subPartClass: SubPartClass =  new ListSubPartClass(optionsListObj, 10, 350, -1, game, tdotopandbottom: false, tbackbitmap: ( local3), bbx: bbx, bby: 34, tMarcStyle: true, overruleFont: ( local4));
           Graphics local5 =  graphics;
          bitmap = subPartClass.Paint();
           Bitmap local6 =  bitmap;
          int x = num1;
          DrawMod.DrawSimple( local5,  local6, x, 34);
          DrawMod.DrawTextColouredMarc( graphics, "Empty Pool", this.game.MarcFont1, num1 + 85, 105, Color.FromArgb(128,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue));
          subPartClass.OwnBitmap.Dispose();
        }
      }
      DrawMod.DrawTextColouredMarc( graphics, "Base cost: " + this.game.Data.RuleVar[904].ToString() + "PP.", this.game.MarcFont4, num1 + 870, 24, Color.White);
      int num7;
      int num8 =  Math.Round((double) ((float) num7 + this.game.Data.RuleVar[904]));
      if (index1 > -1)
      {
        if (this.game.Data.HistoricalUnitObj[index1].PP > 0)
        {
          DrawMod.DrawTextColouredMarc( graphics, "No PP cost to dismiss.", this.game.MarcFont4, num1 + 870, 54, Color.White);
        }
        else
        {
          DrawMod.DrawTextColouredMarc( graphics, Strings.Trim(Conversion.Str((object) Math.Abs(this.game.Data.HistoricalUnitObj[index1].PP))) + " PP cost to dismiss.", this.game.MarcFont4, num1 + 870, 54, Color.White);
          num8 += Math.Abs(this.game.Data.HistoricalUnitObj[index1].PP);
        }
        DrawMod.DrawTextColouredMarc( graphics, this.game.Data.HistoricalUnitObj[index1].CommanderName, this.game.MarcFont4, num1 + 870, 70, Color.White);
      }
      if (this.detailnr > -1)
      {
        if (this.game.Data.HistoricalUnitObj[this.detailnr].PP < 0)
        {
          DrawMod.DrawTextColouredMarc( graphics, "No PP cost to appoint.", this.game.MarcFont4, num1 + 870, 100, Color.White);
        }
        else
        {
          DrawMod.DrawTextColouredMarc( graphics, Strings.Trim(Conversion.Str((object) Math.Abs(this.game.Data.HistoricalUnitObj[this.detailnr].PP))) + " PP cost to appoint.", this.game.MarcFont4, num1 + 870, 100, Color.White);
          num8 += Math.Abs(this.game.Data.HistoricalUnitObj[this.detailnr].PP);
        }
        DrawMod.DrawTextColouredMarc( graphics, this.game.Data.HistoricalUnitObj[this.detailnr].CommanderName, this.game.MarcFont4, num1 + 870, 116, Color.White);
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
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "Click to swap officer in selected HQ with officer selected in officerpool",  this.OwnBitmap, num1 + 870, 150, theight: 65, useshadow: true, tMarcStyle: true);
              this.B2Id = this.AddSubPart( tsubpart, num1 + 870, 150, 140, 65, 1);
            }
            else if ((double) this.game.Data.RuleVar[896] == 1.0 & this.game.Data.HistoricalUnitObj[index1].Type == 8 & this.game.Data.HistoricalUnitObj[index1].CommanderName.Length > 1)
            {
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "You are not allowed to swap the officer of the high command HQ.",  this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
              this.b2bid = this.AddSubPart( tsubpart, num1 + 870, 150, 140, 65, 0);
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
                let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "Click to swap officer in selected HQ with officer selected in officerpool",  this.OwnBitmap, num1 + 870, 150, theight: 65, useshadow: true, tMarcStyle: true);
                this.B2Id = this.AddSubPart( tsubpart, num1 + 870, 150, 140, 65, 1);
              }
              else
              {
                let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT (" + num8.ToString() + "pp)", 140, "You dont have the PP to appoint this officer or the PP to remove the officer in the unit.",  this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
                this.b2bid = this.AddSubPart( tsubpart, num1 + 870, 150, 140, 65, 0);
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
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT", 140, "Click to appoint officer to selected HQ without any officer",  this.OwnBitmap, num1 + 870, 150, theight: 65, useshadow: true, tMarcStyle: true);
              this.B4Id = this.AddSubPart( tsubpart, num1 + 870, 150, 100, 65, 1);
            }
            else
            {
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT", 140, "You dont have the PP to appoint this officer..",  this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
              this.b2bid = this.AddSubPart( tsubpart, num1 + 870, 150, 100, 65, 0);
            }
          }
          else
          {
            let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT", 140, "You have either not selected a unit on the map with an officer\r\nor you have not selected an officer in the officerpool.",  this.OwnBitmap, num1 + 870, 150, true, theight: 65, tMarcStyle: true);
            this.b2bid = this.AddSubPart( tsubpart, num1 + 870, 150, 100, 65, 0);
          }
        }
        else
        {
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT", 140, "People mismatch. Officer from officerpool and unit must have matching people.",  this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
          this.b2bid = this.AddSubPart( tsubpart, num1 + 870, 150, 100, 65, 0);
        }
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass("APPOINT", 140, "You have to select a HQ first.",  this.OwnBitmap, num1 + 870, 150, true, theight: 65, useshadow: true, tMarcStyle: true);
        this.b2bid = this.AddSubPart( tsubpart, num1 + 870, 150, 100, 65, 0);
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
        int num12 =  Math.Round((double) (this.w - 1024) / 2.0) + 400;
        DrawMod.DrawOfficer(graphics, his, num12 + 12, 34, 65, 72);
        trect1 = new Rectangle(num12 + 12, 34, 65, 72);
        this.AddMouse( trect1, "OFFICER PORTRAIT", "Click to get full stats and biography", 50);
         Graphics local7 =  graphics;
        bitmap = this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderUnit, true);
         Bitmap local8 =  bitmap;
        int x1 = num12 + 12 + 45;
        DrawMod.DrawSimple( local7,  local8, x1, 76);
        if ((double) this.game.Data.RuleVar[879] < 1.0)
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "\r\n\r\n" + this.game.Data.HistoricalUnitObj[his].Descript, 12,  this.BackBitmap, num12 + 110, 22, true);
           Graphics local9 =  graphics;
          bitmap = textAreaClass2.Paint();
           Bitmap local10 =  bitmap;
          int x2 = num12 + 110;
          DrawMod.DrawSimple( local9,  local10, x2, -7);
          trect1 = new Rectangle(num12 + 105, 34, 280, 100);
          Rectangle trect3 = trect1;
          this.AddMouse( trect3, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc( graphics, this.game.Data.HistoricalUnitObj[his].CommanderName, this.game.MarcFont6, num12 + 125, 44, Color.White);
        }
        else
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12,  this.BackBitmap, num12 + 110, 22, true);
           Graphics local11 =  graphics;
          bitmap = textAreaClass2.Paint();
           Bitmap local12 =  bitmap;
          int x3 = num12 + 110;
          DrawMod.DrawSimple( local11,  local12, x3, 22);
          trect1 = new Rectangle(num12 + 105, 34, 280, 45);
          Rectangle trect4 = trect1;
          this.AddMouse( trect4, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc( graphics, this.game.Data.HistoricalUnitObj[his].CommanderName, this.game.MarcFont6, num12 + 125, 44, Color.White);
          int num13 = 110;
          while (num13 < 365)
          {
            DrawMod.DrawBlockGradient2( graphics, num12 + num13, 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
            int index2;
            if (this.game.Data.HistoricalUnitObj[his].HisVarCount >= index2)
            {
              bool flag = true;
              if (this.game.Data.HistoricalUnitObj[his].HisVarType[index2] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[his].HisVarType[index2]], "1", false) == 0)
                flag = false;
              if (flag & (this.game.Data.HistoricalUnitObj[his].HisVarNato[index2] > 0 | this.game.Data.HistoricalUnitObj[his].HisVarSmall[index2] > -1))
              {
                DrawMod.DrawBlock( graphics, num12 + num13, 67, 37, 2,  this.game.MarcCol3.R,  this.game.MarcCol3.G,  this.game.MarcCol3.B,  byte.MaxValue);
                DrawMod.DrawBlockGradient2( graphics, num12 + num13, 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
                str: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[his].HisVarValue[index2]));
                sizeF2 = graphics.MeasureString(str, this.game.MarcFont8b);
                int x4 =  Math.Round((double) ((float) (num12 + num13 + 18) - sizeF2.Width / 2f));
                DrawMod.DrawTextColouredMarc( graphics, str, this.game.MarcFont8b, x4, 90, Color.White);
                if (this.game.Data.HistoricalUnitObj[his].HisVarSmall[index2] > -1)
                {
                   Graphics local13 =  graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[his].HisVarSmall[index2]]);
                   Bitmap local14 =  bitmap;
                  int x5 = x4;
                  DrawMod.DrawSimple( local13,  local14, x5, 71);
                }
                else
                {
                   Graphics local15 =  graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[his].HisVarNato[index2]]);
                   Bitmap local16 =  bitmap;
                  int x6 = x4;
                  DrawMod.DrawSimple( local15,  local16, x6, 71);
                }
                trect1 = new Rectangle(x4, 71, 35, 50);
                trect2 = trect1;
                this.AddMouse( trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[his].HisVarType[index2]]);
                num13 += 35;
              }
            }
            else
              num13 = 365;
            index2 += 1;
          }
        }
        DrawMod.DrawTextColouredMarc( graphics, "SELECTED UNIT OFFICER", this.game.MarcFont8b, num12 + 10, 14, Color.White);
      }
      else
      {
        int num14 =  Math.Round((double) (this.w - 1024) / 2.0) + 400;
        TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12,  this.BackBitmap, num14 + 110, 22, true);
         Graphics local17 =  graphics;
        bitmap = textAreaClass2.Paint();
         Bitmap local18 =  bitmap;
        int x = num14 + 110;
        DrawMod.DrawSimple( local17,  local18, x, 22);
        DrawMod.DrawTextColouredMarc( graphics, "No officer in selected HQ", this.game.MarcFont6, num14 + 125, 44, Color.White);
        DrawMod.DrawTextColouredMarc( graphics, "SELECTED UNIT OFFICER", this.game.MarcFont8b, num14 + 10, 14, Color.White);
      }
      if (this.detailnr > -1)
      {
        int detailnr = this.detailnr;
        int num15 = 108;
        int num16 =  Math.Round((double) (this.w - 1024) / 2.0) + 400;
        DrawMod.DrawOfficer(graphics, detailnr, num16 + 12, num15 + 34, 65, 72);
        trect1 = new Rectangle(num16 + 12, num15 + 34, 65, 72);
        trect2 = trect1;
        this.AddMouse( trect2, "OFFICER PORTRAIT", "Click to get full stats and biography", 51);
        if ((double) this.game.Data.RuleVar[879] < 1.0)
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "\r\n\r\n" + this.game.Data.HistoricalUnitObj[detailnr].Descript, 12,  this.BackBitmap, num16 + 110, num15 + 22, true);
           Graphics local19 =  graphics;
          bitmap = textAreaClass2.Paint();
           Bitmap local20 =  bitmap;
          int x = num16 + 110;
          int y = num15 - 7;
          DrawMod.DrawSimple( local19,  local20, x, y);
          trect1 = new Rectangle(num16 + 105, num15 + 34, 280, 100);
          trect2 = trect1;
          this.AddMouse( trect2, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc( graphics, this.game.Data.HistoricalUnitObj[detailnr].CommanderName, this.game.MarcFont6, num16 + 125, num15 + 44, Color.White);
        }
        else
        {
          TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12,  this.BackBitmap, num16 + 110, num15 + 22, true);
           Graphics local21 =  graphics;
          bitmap = textAreaClass2.Paint();
           Bitmap local22 =  bitmap;
          int x7 = num16 + 110;
          int y1 = num15 + 22;
          DrawMod.DrawSimple( local21,  local22, x7, y1);
          trect1 = new Rectangle(num16 + 105, num15 + 34, 280, 45);
          trect2 = trect1;
          this.AddMouse( trect2, "OFFICER INFO", "Click to get full stats and biography", 50);
          DrawMod.DrawTextColouredMarc( graphics, this.game.Data.HistoricalUnitObj[detailnr].CommanderName, this.game.MarcFont6, num16 + 125, num15 + 44, Color.White);
          int num17 = 110;
          DrawMod.DrawBlock( graphics, num16 + num17, num15 + 67, 247, 2,  this.game.MarcCol3.R,  this.game.MarcCol3.G,  this.game.MarcCol3.B,  byte.MaxValue);
          for (; num17 < 365; num17 += 35)
          {
            DrawMod.DrawBlockGradient2( graphics, num16 + num17, num15 + 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
            int index3;
            if (this.game.Data.HistoricalUnitObj[detailnr].HisVarCount >= index3)
            {
              bool flag = true;
              if (this.game.Data.HistoricalUnitObj[detailnr].HisVarType[index3] <= 99 && Operators.CompareString(this.game.Data.TempString[1400 + this.game.Data.HistoricalUnitObj[detailnr].HisVarType[index3]], "1", false) == 0)
                flag = false;
              if (flag & (this.game.Data.HistoricalUnitObj[detailnr].HisVarNato[index3] > 0 | this.game.Data.HistoricalUnitObj[detailnr].HisVarSmall[index3] > -1))
              {
                str: String = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[detailnr].HisVarValue[index3]));
                sizeF2 = graphics.MeasureString(str, this.game.MarcFont8b);
                int x8 =  Math.Round((double) ((float) (num16 + num17 + 18) - sizeF2.Width / 2f));
                DrawMod.DrawTextColouredMarc( graphics, str, this.game.MarcFont8b, x8, num15 + 90, Color.White);
                if (this.game.Data.HistoricalUnitObj[detailnr].HisVarSmall[index3] > -1)
                {
                   Graphics local23 =  graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[detailnr].HisVarSmall[index3]]);
                   Bitmap local24 =  bitmap;
                  int x9 = x8;
                  int y2 = num15 + 71;
                  DrawMod.DrawSimple( local23,  local24, x9, y2);
                }
                else
                {
                   Graphics local25 =  graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[detailnr].HisVarNato[index3]]);
                   Bitmap local26 =  bitmap;
                  int x10 = x8;
                  int y3 = num15 + 71;
                  DrawMod.DrawSimple( local25,  local26, x10, y3);
                }
                trect1 = new Rectangle(x8, num15 + 71, 35, 50);
                trect2 = trect1;
                this.AddMouse( trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[detailnr].HisVarType[index3]]);
              }
            }
            index3 += 1;
          }
        }
        DrawMod.DrawTextColouredMarc( graphics, "SELECTED POOL OFFICER", this.game.MarcFont8b, num16 + 10, num15 + 14, Color.White);
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
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
        for (int index = 0; index <= subPartCounter; index += 1)
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
              s: String = "I took command of " + this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Name;
              commanderName: String = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].CommanderName;
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

    pub void PopUpRefresh()
    {
    }
  }
}
