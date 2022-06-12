// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NewUnit2WindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class NewUnit2WindowClass : WindowClass
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
    private int[] Ucnt;
    private int[] ModCnt;
    private int[,] ModSubCnt;
    private int[,] SubCnt;

    public NewUnit2WindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.Ucnt = new int[1];
      this.ModCnt = new int[1];
      this.ModSubCnt = new int[1, 1];
      this.SubCnt = new int[1, 1];
      this.steppy = 0;
      this.typpy = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.calc();
      this.dostuff();
    }

    private void calc()
    {
      this.Ucnt = new int[this.game.Data.HistoricalUnitCounter + 1];
      this.ModCnt = new int[this.game.Data.HistoricalUnitCounter + 1];
      this.SubCnt = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
      this.ModSubCnt = new int[this.game.Data.HistoricalUnitCounter + 1, 10];
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
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter; ++index5)
      {
        int index6 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[index5].SubParts[index6] > -1)
          {
            int[] modCnt = this.ModCnt;
            int[] numArray = modCnt;
            int index7 = index5;
            int index8 = index7;
            int num = modCnt[index7] + 1;
            numArray[index8] = num;
          }
          int[,] modSubCnt = this.ModSubCnt;
          int[,] numArray3 = modSubCnt;
          int index9 = index5;
          int index10 = index9;
          int index11 = index6;
          int index12 = index11;
          int num3 = modSubCnt[index9, index11] + 1;
          numArray3[index10, index12] = num3;
          ++index6;
        }
        while (index6 <= 9);
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
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Sub Unit Options (add, remove, change)", new Font("Times New Roman", 22f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 24, false);
      this.ExtraId = this.AddSubPart(ref tsubpart1, 10, 2, 400, 24, 0);
      SubPartClass tsubpart2;
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].UnitCounter < 15)
      {
        this.OptionsListObj = new ListClass();
        int num1 = -1;
        int tlistselect1 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
        {
          if (this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata].ModelMaster > -1 && this.Ucnt[tdata] < this.ModCnt[tdata] & this.Ucnt[tdata] > 0)
          {
            ++num1;
            if (tdata == this.detailnr)
              tlistselect1 = num1;
            this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata);
          }
        }
        if (num1 == -1)
        {
          tsubpart2 = (SubPartClass) new TextPartClass("No units that are missing subunits.", new Font("Times New Roman", 14f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 24, false);
          this.B1TextId = this.AddSubPart(ref tsubpart2, 50, 89, 400, 24, 0);
          if (this.OptionsListId > 0)
          {
            this.RemoveSubPart(this.OptionsListId);
            this.OptionsListId = 0;
          }
          if (this.OptionsList2Id > 0)
          {
            this.RemoveSubPart(this.OptionsList2Id);
            this.OptionsList2Id = 0;
          }
          this.detailnr = -1;
          this.detailnr2 = -1;
          if (this.B3Id > 0)
            this.RemoveSubPart(this.B3Id);
          if (this.B4Id > 0)
            this.RemoveSubPart(this.B4Id);
        }
        else if (this.OptionsListId > 0)
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
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart3 = (SubPartClass) new ListSubPartClass(optionsListObj, 9, 350, tlistselect2, game, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 10, bby: 30, overruleFont: (ref local2));
          this.OptionsListId = this.AddSubPart(ref tsubpart3, 10, 30, 350, 160, 0);
        }
        if (this.detailnr > -1)
        {
          this.OptionsList2Obj = new ListClass();
          int num2 = -1;
          int tlistselect3 = -1;
          int tdata = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[tdata] > -1 && this.SubCnt[this.detailnr, tdata] == 0 & this.ModSubCnt[this.detailnr, tdata] > 0)
            {
              ++num2;
              if (tdata == this.detailnr2)
                tlistselect3 = num2;
              this.OptionsList2Obj.add(this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[tdata])].Name, tdata, Conversion.Str((object) (int) Math.Round((double) this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.detailnr].ModelMaster].PP / (double) this.ModCnt[this.detailnr])));
            }
            ++tdata;
          }
          while (tdata <= 9);
          if (this.OptionsList2Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect3);
            this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
          }
          else
          {
            ListClass optionsList2Obj = this.OptionsList2Obj;
            int tlistselect4 = tlistselect3;
            GameClass game = this.game;
            ref Bitmap local3 = ref this.OwnBitmap;
            Font font = (Font) null;
            ref Font local4 = ref font;
            tsubpart2 = (SubPartClass) new ListSubPartClass(optionsList2Obj, 9, 300, tlistselect4, game, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: 400, bby: 30, overruleFont: (ref local4));
            this.OptionsList2Id = this.AddSubPart(ref tsubpart2, 400, 30, 300, 160, 0);
          }
          if (this.detailnr2 > -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (int) Math.Round((double) this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.detailnr].ModelMaster].PP / (double) this.ModCnt[this.detailnr]) & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter < 15)
            {
              tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.OKBALL);
              this.B3Id = this.AddSubPart(ref tsubpart2, 750, 30, 32, 32, 1);
            }
            else
            {
              tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.OKBALL, 1);
              this.B4Id = this.AddSubPart(ref tsubpart2, 750, 30, 32, 32, 0);
            }
            tsubpart2 = (SubPartClass) new TextPartClass("Make new unit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
            this.B3TextId = this.AddSubPart(ref tsubpart2, 800, 39, 200, 24, 0);
            if (this.game.EditObj.OrderUnit > -1 && !this.game.Data.UnitObj[this.game.EditObj.OrderUnit].IsHQ)
            {
              ref Graphics local5 = ref objgraphics;
              Bitmap bitmap = this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderUnit);
              ref Bitmap local6 = ref bitmap;
              DrawMod.DrawSimple(ref local5, ref local6, 750, 75);
              DrawMod.DrawText(ref objgraphics, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Name, this.game.GameFont1, 793, 73);
              tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.OKBALL);
              this.B5Id = this.AddSubPart(ref tsubpart2, 795, 90, 32, 32, 1);
              tsubpart2 = (SubPartClass) new TextPartClass("Set selected unit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
              this.B5TextId = this.AddSubPart(ref tsubpart2, 835, 100, 200, 24, 0);
            }
          }
        }
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextPartClass("To many units on hex to create a new one.", new Font("Times New Roman", 14f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 24, false);
        this.B1TextId = this.AddSubPart(ref tsubpart2, 50, 89, 400, 24, 0);
      }
      if (this.game.EditObj.OrderUnit > -1 && !this.game.Data.UnitObj[this.game.EditObj.OrderUnit].IsHQ && this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1)
      {
        ref Graphics local7 = ref objgraphics;
        Bitmap bitmap = this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderUnit);
        ref Bitmap local8 = ref bitmap;
        DrawMod.DrawSimple(ref local7, ref local8, 750, 145);
        DrawMod.DrawText(ref objgraphics, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Name, this.game.GameFont1, 793, 143);
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CANCELBALL);
        this.B6Id = this.AddSubPart(ref tsubpart2, 795, 160, 32, 32, 1);
        tsubpart2 = (SubPartClass) new TextPartClass("Unassign Subunit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
        this.B6TextId = this.AddSubPart(ref tsubpart2, 835, 170, 200, 24, 0);
      }
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.B3Id)
            {
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.Data.Turn, this.detailnr, this.detailnr2);
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 44);
              this.calc();
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.Data.Turn, this.detailnr, this.detailnr2, this.game.EditObj.OrderUnit);
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(2, 20);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1 && this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HistoricalSubPart > -1)
                this.game.Data.UnitObj[this.game.EditObj.OrderUnit].StartPower = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].SubParts[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HistoricalSubPart]), true);
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical = -1;
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].HistoricalSubPart = -1;
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Name = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Regime].UnitName;
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(2, 20);
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
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList2Id)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num3 > -1)
              {
                this.detailnr2 = num3;
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
  }
}
