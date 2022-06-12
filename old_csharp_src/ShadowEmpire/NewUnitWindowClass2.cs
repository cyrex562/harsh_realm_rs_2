﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NewUnitWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class NewUnitWindowClass2 : WindowClass
  {
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int off1id;
    private int detailnr;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Pic1Id;
    private int detailnr2;
    private int OrderTextId;
    private int OrderText2Id;
    private int OrderUpId;
    private int OrderDownId;
    private int ExtraId;
    private int steppy;
    private int typpy;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private bool Hq;
    private int w;
    private int h;
    private int[] Ucnt;
    private int[] ModCnt;
    private int[,] ModSubCnt;
    private int[,] SubCnt;
    private int[] modelcount;
    private bool[] creatable;
    private string[] errors;

    public NewUnitWindowClass2(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 222, BackSprite: tGame.MARCBOTBAR)
    {
      this.Ucnt = new int[1];
      this.ModCnt = new int[1];
      this.ModSubCnt = new int[1, 1];
      this.SubCnt = new int[1, 1];
      this.modelcount = new int[1];
      this.creatable = new bool[1];
      this.errors = new string[1];
      this.w = tGame.ScreenWidth;
      this.h = 222;
      this.BlockBlit = true;
      this.detailnr = -1;
      this.typpy = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      if (this.game.Data.Round == 0 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime > -1)
        this.game.Data.Turn = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime;
      this.calc();
      this.dostuff();
    }

    private void calc()
    {
      this.Ucnt = new int[this.game.Data.HistoricalUnitCounter + 1];
      this.ModCnt = new int[this.game.Data.HistoricalUnitCounter + 1];
      this.SubCnt = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      this.ModSubCnt = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      this.modelcount = new int[this.game.Data.HistoricalUnitCounter + 1];
      this.creatable = new bool[this.game.Data.HistoricalUnitCounter + 1];
      this.errors = new string[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical > -1 & this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn)
        {
          int[] ucnt = this.Ucnt;
          int[] numArray1 = ucnt;
          int historical1 = this.game.Data.UnitObj[index1].Historical;
          int index2 = historical1;
          int num1 = ucnt[historical1] + 1;
          numArray1[index2] = num1;
          if (this.game.Data.UnitObj[index1].HistoricalSubPart > -1)
          {
            int[,] subCnt = this.SubCnt;
            int[,] numArray2 = subCnt;
            int historical2 = this.game.Data.UnitObj[index1].Historical;
            int index3 = historical2;
            int historicalSubPart = this.game.Data.UnitObj[index1].HistoricalSubPart;
            int index4 = historicalSubPart;
            int num2 = subCnt[historical2, historicalSubPart] + 1;
            numArray2[index3, index4] = num2;
          }
        }
      }
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter1; ++index5)
      {
        if (this.game.Data.HistoricalUnitObj[index5].ModelMaster > -1 && this.Ucnt[index5] > 0)
        {
          int[] modelcount = this.modelcount;
          int[] numArray = modelcount;
          int modelMaster = this.game.Data.HistoricalUnitObj[index5].ModelMaster;
          int index6 = modelMaster;
          int num = modelcount[modelMaster] + 1;
          numArray[index6] = num;
        }
      }
      int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
      for (int hisnr = 0; hisnr <= historicalUnitCounter2; ++hisnr)
      {
        this.errors[hisnr] = "";
        if (this.game.Data.HistoricalUnitObj[hisnr].Model)
        {
          this.creatable[hisnr] = false;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts < this.game.Data.HistoricalUnitObj[hisnr].PP)
            this.errors[hisnr] = "Not enough PP to create.";
          else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter + this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(hisnr) >= 16)
            this.errors[hisnr] = "To many units in hex to add new units.";
          else if (this.modelcount[hisnr] >= this.game.Data.HistoricalUnitObj[hisnr].MaxPresent & this.game.Data.HistoricalUnitObj[hisnr].MaxPresent != -1)
            this.errors[hisnr] = "Maximum ammount of this model already on map.";
          else
            this.creatable[hisnr] = true;
        }
      }
      int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
      for (int index7 = 0; index7 <= historicalUnitCounter3; ++index7)
      {
        int index8 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[index7].SubParts[index8] > -1)
          {
            int[] modCnt = this.ModCnt;
            int[] numArray = modCnt;
            int index9 = index7;
            int index10 = index9;
            int num = modCnt[index9] + 1;
            numArray[index10] = num;
          }
          int[,] modSubCnt = this.ModSubCnt;
          int[,] numArray3 = modSubCnt;
          int index11 = index7;
          int index12 = index11;
          int index13 = index8;
          int index14 = index13;
          int num3 = modSubCnt[index11, index13] + 1;
          numArray3[index12, index14] = num3;
          ++index8;
        }
        while (index8 <= 9);
      }
    }

    private void dostuff()
    {
      if (this.off1id > 0)
        this.RemoveSubPart(this.off1id);
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.OrderUpId > 0)
        this.RemoveSubPart(this.OrderUpId);
      if (this.OrderDownId > 0)
        this.RemoveSubPart(this.OrderDownId);
      if (this.ExtraId > 0)
        this.RemoveSubPart(this.ExtraId);
      if (this.OrderTextId > 0)
        this.RemoveSubPart(this.OrderTextId);
      if (this.OrderText2Id > 0)
        this.RemoveSubPart(this.OrderText2Id);
      if (this.OptionsList2Id > 0)
      {
        this.RemoveSubPart(this.OptionsList2Id);
        this.OptionsList2Id = 0;
      }
      int num1 = (int) Math.Round((double) (this.w - 1024) / 2.0);
      this.NewBackGroundAndClearAll(this.w, this.h, this.game.MARCBOTBAR);
      this.ClearMouse();
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].UnitCounter < 15)
      {
        this.OptionsListObj = new ListClass();
        int num2 = -1;
        int tlistselect1 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
        {
          if ((uint) Strings.InStr(this.game.Data.HistoricalUnitObj[tdata].Name, "SP") > 0U)
            tdata = tdata;
          if (this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[tdata].MaxPresent != 0)
          {
            ++num2;
            if (this.detailnr == -1)
              this.detailnr = tdata;
            if (tdata == this.detailnr)
              tlistselect1 = num2;
            string tvalue4 = !this.creatable[tdata] ? "-" : "OK";
            string tvalue3 = "Unl.";
            if (this.game.Data.HistoricalUnitObj[tdata].MaxPresent > -1)
              tvalue3 = Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].MaxPresent);
            this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata, Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP), Conversion.Str((object) this.modelcount[tdata]), tvalue3, tvalue4);
          }
        }
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else
        {
          ListClass optionsListObj = this.OptionsListObj;
          int tlistselect2 = tlistselect1;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          int bbx = num1 + 10;
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 10, 600, tlistselect2, game, tShowPair: true, tValueWidth: 350, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: 30, tMarcStyle: true, overruleFont: (ref local2));
          this.OptionsListId = this.AddSubPart(ref tsubpart, num1 + 10, 30, 600, 176, 0);
        }
        DrawMod.DrawTextColouredMarc(ref objgraphics, "UNIT MODEL", this.game.MarcFont5, num1 + 20, 13, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "POL.PTS", this.game.MarcFont5, num1 + 245, 13, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "ON MAP", this.game.MarcFont5, num1 + 331, 13, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "MAX ON MAP", this.game.MarcFont5, num1 + 419, 13, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "CAN CREATE?", this.game.MarcFont5, num1 + 505, 13, Color.White);
        if (this.detailnr > -1)
        {
          if (this.creatable[this.detailnr])
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("CREATE UNIT", 180, "Click to create this unit [SPACE]", ref this.BackBitmap, num1 + 730, 80, theight: 50, usefont: this.game.MarcFont1, useshadow: true, tMarcStyle: true);
            this.B3Id = this.AddSubPart(ref tsubpart, num1 + 730, 80, 180, 50, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("CREATE UNIT", 180, this.errors[this.detailnr], ref this.BackBitmap, num1 + 730, 80, true, theight: 50, usefont: this.game.MarcFont1, useshadow: true, tMarcStyle: true);
            this.B4Id = this.AddSubPart(ref tsubpart, num1 + 730, 80, 180, 50, 0);
          }
        }
      }
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult1 = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.B3Id)
            {
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.Data.Turn, this.detailnr);
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.OrderUnit = -1;
              this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(2, 69);
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              OrderResult orderResult2 = this.game.ProcessingObj.NewUnit(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.MapSelected, false, this.game.Data.Turn);
              if (this.game.EditObj.SoundOn)
                SoundMod.PlayAWave(this.game.AppPath + "sound/radio.wav", ref this.game.EditObj);
              if (orderResult2.OK)
              {
                int num2 = 0;
                int unitCounter = this.game.Data.UnitCounter;
                for (int index2 = 0; index2 <= unitCounter; ++index2)
                {
                  if (this.game.Data.UnitObj[index2].IsHQ & this.game.Data.UnitObj[index2].PreDef == -1 & this.game.Data.UnitObj[index2].X > -1 && this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn)
                    num2 = 1;
                }
                if (num2 == 1)
                {
                  this.game.EditObj.OrderType = 3;
                  this.game.EditObj.OrderUnit = this.game.Data.UnitCounter;
                  this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
                  windowReturnClass.AddCommand(1, 5);
                  windowReturnClass.AddCommand(2, 69);
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 68);
                  windowReturnClass.AddCommand(4, 9);
                  windowReturnClass.AddCommand(4, 67);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.OrderType = 0;
                this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 69);
                this.game.EditObj.TempCoordList = new CoordList();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.OptionsListId)
              {
                int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num3 > -1)
                {
                  this.detailnr = num3;
                  this.dostuff();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.OptionsList2Id)
              {
                int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num4 > -1)
                {
                  this.detailnr2 = num4;
                  this.dostuff();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
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
