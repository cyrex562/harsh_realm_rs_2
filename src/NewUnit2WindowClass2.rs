// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NewUnit2WindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class NewUnit2WindowClass2 : WindowClass
  {
     int B1Id;
     int B1TextId;
     int B2Id;
     int B2TextId;
     int B3Id;
     int B3TextId;
     int B4Id;
     int B4TextId;
     int B5Id;
     int B5TextId;
     int B6Id;
     int B6TextId;
     int off1id;
     int detailnr;
     int Text1Id;
     int Text2Id;
     int Text3Id;
     int Pic1Id;
     int detailnr2;
     int OrderTextId;
     int OrderText2Id;
     int OrderUpId;
     int OrderDownId;
     int ExtraId;
     int steppy;
     int typpy;
     int OptionsListId;
     ListClass OptionsListObj;
     int OptionsList2Id;
     ListClass OptionsList2Obj;
     bool Hq;
     int[] Ucnt;
     int[] ModCnt;
     int[,] ModSubCnt;
     int[,] SubCnt;
     int[] modelcount;
     int w;
     int h;

    pub NewUnit2WindowClass2( GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base( tGame, tGame.ScreenWidth, 222, BackSprite: tGame.MARCBOTBAR)
    {
      self.Ucnt = new int[1];
      self.ModCnt = new int[1];
      self.ModSubCnt = new int[1, 1];
      self.SubCnt = new int[1, 1];
      self.modelcount = new int[1];
      self.w = tGame.ScreenWidth;
      self.h = 222;
      self.BlockBlit = true;
      self.detailnr = -1;
      self.typpy = -1;
      self.detailnr = -1;
      self.detailnr2 = -1;
      self.calc();
      self.dostuff();
    }

     void calc()
    {
      self.Ucnt = new int[self.game.Data.HistoricalUnitCounter + 1];
      self.ModCnt = new int[self.game.Data.HistoricalUnitCounter + 1];
      self.SubCnt = new int[self.game.Data.HistoricalUnitCounter + 1, 10];
      self.ModSubCnt = new int[self.game.Data.HistoricalUnitCounter + 1, 10];
      self.modelcount = new int[self.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = self.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; index1 += 1)
      {
        if (self.game.Data.UnitObj[index1].Historical > -1 & self.game.Data.UnitObj[index1].PreDef == -1 & self.game.Data.UnitObj[index1].Regime == self.game.Data.Turn)
        {
          int[] ucnt = self.Ucnt;
          int[] numArray1 = ucnt;
          int historical1 = self.game.Data.UnitObj[index1].Historical;
          int index2 = historical1;
          int num1 = ucnt[historical1] + 1;
          numArray1[index2] = num1;
          if (self.game.Data.UnitObj[index1].HistoricalSubPart > -1)
          {
            int[,] subCnt = self.SubCnt;
            int[,] numArray2 = subCnt;
            int historical2 = self.game.Data.UnitObj[index1].Historical;
            int index3 = historical2;
            int historicalSubPart = self.game.Data.UnitObj[index1].HistoricalSubPart;
            int index4 = historicalSubPart;
            int num2 = subCnt[historical2, historicalSubPart] + 1;
            numArray2[index3, index4] = num2;
          }
        }
      }
      int historicalUnitCounter1 = self.game.Data.HistoricalUnitCounter;
      for (int index5 = 0; index5 <= historicalUnitCounter1; index5 += 1)
      {
        if (self.Ucnt[index5] > 0 && self.game.Data.HistoricalUnitObj[index5].ModelMaster > -1)
        {
          int[] modelcount = self.modelcount;
          int[] numArray = modelcount;
          int modelMaster = self.game.Data.HistoricalUnitObj[index5].ModelMaster;
          int index6 = modelMaster;
          int num = modelcount[modelMaster] + 1;
          numArray[index6] = num;
        }
      }
      int historicalUnitCounter2 = self.game.Data.HistoricalUnitCounter;
      for (int index7 = 0; index7 <= historicalUnitCounter2; index7 += 1)
      {
        int index8 = 0;
        do
        {
          if (self.game.Data.HistoricalUnitObj[index7].SubParts[index8] > -1)
          {
            int[] modCnt = self.ModCnt;
            int[] numArray = modCnt;
            int index9 = index7;
            int index10 = index9;
            int num = modCnt[index9] + 1;
            numArray[index10] = num;
          }
          int[,] modSubCnt = self.ModSubCnt;
          int[,] numArray3 = modSubCnt;
          int index11 = index7;
          int index12 = index11;
          int index13 = index8;
          int index14 = index13;
          int num3 = modSubCnt[index11, index13] + 1;
          numArray3[index12, index14] = num3;
          index8 += 1;
        }
        while (index8 <= 9);
      }
    }

     void dostuff()
    {
      if (self.off1id > 0)
        self.RemoveSubPart(self.off1id);
      if (self.Text1Id > 0)
        self.RemoveSubPart(self.Text1Id);
      if (self.Text2Id > 0)
        self.RemoveSubPart(self.Text2Id);
      if (self.Text3Id > 0)
        self.RemoveSubPart(self.Text3Id);
      if (self.Pic1Id > 0)
        self.RemoveSubPart(self.Pic1Id);
      if (self.B1Id > 0)
        self.RemoveSubPart(self.B1Id);
      if (self.B1TextId > 0)
        self.RemoveSubPart(self.B1TextId);
      if (self.B2Id > 0)
        self.RemoveSubPart(self.B2Id);
      if (self.B2TextId > 0)
        self.RemoveSubPart(self.B2TextId);
      if (self.B3Id > 0)
        self.RemoveSubPart(self.B3Id);
      if (self.B3TextId > 0)
        self.RemoveSubPart(self.B3TextId);
      if (self.B4Id > 0)
        self.RemoveSubPart(self.B4Id);
      if (self.B4TextId > 0)
        self.RemoveSubPart(self.B4TextId);
      if (self.B5Id > 0)
        self.RemoveSubPart(self.B5Id);
      if (self.B5TextId > 0)
        self.RemoveSubPart(self.B5TextId);
      if (self.B6Id > 0)
        self.RemoveSubPart(self.B6Id);
      if (self.B6TextId > 0)
        self.RemoveSubPart(self.B6TextId);
      if (self.OrderUpId > 0)
        self.RemoveSubPart(self.OrderUpId);
      if (self.OrderDownId > 0)
        self.RemoveSubPart(self.OrderDownId);
      if (self.ExtraId > 0)
        self.RemoveSubPart(self.ExtraId);
      if (self.OrderTextId > 0)
        self.RemoveSubPart(self.OrderTextId);
      if (self.OrderText2Id > 0)
        self.RemoveSubPart(self.OrderText2Id);
      int num1 =  Math.Round((double) (self.w - 1024) / 2.0);
      self.NewBackGroundAndClearAll(self.w, self.h, self.game.MARCBOTBAR);
      self.ClearMouse();
      Graphics objgraphics = Graphics.FromImage((Image) self.OwnBitmap);
      if (self.game.Data.MapObj[self.game.EditObj.MapSelected].HexObj[self.game.EditObj.OrderX, self.game.EditObj.OrderY].UnitCounter < 15)
      {
        self.OptionsListObj = ListClass::new();
        int num2 = -1;
        int tlistselect1 = -1;
        int historicalUnitCounter = self.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; tdata += 1)
        {
          if (self.game.Data.HistoricalUnitObj[tdata].TempRegime == self.game.Data.Turn & self.game.Data.HistoricalUnitObj[tdata].ModelMaster > -1 && self.Ucnt[tdata] < self.ModCnt[tdata] & self.Ucnt[tdata] > 0)
          {
            num2 += 1;
            if (tdata == self.detailnr)
              tlistselect1 = num2;
            self.OptionsListObj.add(self.game.Data.HistoricalUnitObj[tdata].Name, tdata);
          }
        }
        if (num2 == -1)
        {
          DrawMod.DrawTextColouredMarc( objgraphics, "No units that are missing subunits.", self.game.MarcFont4, num1 + 50, 91, Color.White);
          if (self.OptionsListId > 0)
          {
            self.RemoveSubPart(self.OptionsListId);
            self.OptionsListId = 0;
          }
          if (self.OptionsList2Id > 0)
          {
            self.RemoveSubPart(self.OptionsList2Id);
            self.OptionsList2Id = 0;
          }
          self.detailnr = -1;
          self.detailnr2 = -1;
          if (self.B3Id > 0)
            self.RemoveSubPart(self.B3Id);
          if (self.B4Id > 0)
            self.RemoveSubPart(self.B4Id);
        }
        else if (self.OptionsListId > 0)
        {
          self.SubPartList[self.SubpartNr(self.OptionsListId)].Refresh(self.OptionsListObj, tlistselect1);
          self.SubPartFlag[self.SubpartNr(self.OptionsListId)] = true;
        }
        else
        {
          ListClass optionsListObj = self.OptionsListObj;
          int tlistselect2 = tlistselect1;
          let mut game: GameClass = self.game;
           Bitmap local1 =  self.OwnBitmap;
          int bbx = num1 + 10;
          Font font =  null;
           Font local2 =  font;
          let mut tsubpart: SubPartClass =  new ListSubPartClass(optionsListObj, 9, 350, tlistselect2, game, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local1), bbx: bbx, bby: 30, tMarcStyle: true, overruleFont: ( local2));
          self.OptionsListId = self.AddSubPart( tsubpart, num1 + 10, 30, 350, 160, 0);
        }
        if (self.detailnr > -1)
        {
          self.OptionsList2Obj = ListClass::new();
          int num3 = -1;
          int tlistselect3 = -1;
          int tdata = 0;
          do
          {
            if (self.game.Data.HistoricalUnitObj[self.detailnr].SubParts[tdata] > -1 && self.SubCnt[self.detailnr, tdata] == 0 & self.ModSubCnt[self.detailnr, tdata] > 0)
            {
              num3 += 1;
              if (tdata == self.detailnr2)
                tlistselect3 = num3;
              self.OptionsList2Obj.add(self.game.Data.UnitObj[self.game.HandyFunctionsObj.GetPreDef(self.game.Data.HistoricalUnitObj[self.detailnr].SubParts[tdata])].Name, tdata, Conversion.Str((object)  Math.Round((double) self.game.Data.HistoricalUnitObj[self.game.Data.HistoricalUnitObj[self.detailnr].ModelMaster].PP / (double) self.ModCnt[self.detailnr])));
            }
            tdata += 1;
          }
          while (tdata <= 9);
          if (self.OptionsList2Id > 0)
          {
            self.SubPartList[self.SubpartNr(self.OptionsList2Id)].Refresh(self.OptionsList2Obj, tlistselect3);
            self.SubPartFlag[self.SubpartNr(self.OptionsList2Id)] = true;
          }
          else
          {
            ListClass optionsList2Obj = self.OptionsList2Obj;
            int tlistselect4 = tlistselect3;
            let mut game: GameClass = self.game;
             Bitmap local3 =  self.OwnBitmap;
            int bbx = num1 + 400;
            Font font =  null;
             Font local4 =  font;
            let mut tsubpart: SubPartClass =  new ListSubPartClass(optionsList2Obj, 9, 300, tlistselect4, game, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local3), bbx: bbx, bby: 30, tMarcStyle: true, overruleFont: ( local4));
            self.OptionsList2Id = self.AddSubPart( tsubpart, num1 + 400, 30, 300, 160, 0);
          }
          if (self.detailnr2 > -1)
          {
            if (self.game.Data.RegimeObj[self.game.Data.Turn].ResPts >=  Math.Round((double) self.game.Data.HistoricalUnitObj[self.game.Data.HistoricalUnitObj[self.detailnr].ModelMaster].PP / (double) self.ModCnt[self.detailnr]) & self.game.Data.MapObj[self.game.EditObj.MapSelected].HexObj[self.game.SelectX, self.game.SelectY].UnitCounter < 15)
            {
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("CREATE UNIT", 180, "Click to create this unit [SPACE]",  self.BackBitmap, num1 + 750, 80, theight: 50, usefont: self.game.MarcFont1, useshadow: true, tMarcStyle: true);
              self.B3Id = self.AddSubPart( tsubpart, num1 + 750, 80, 180, 50, 1);
            }
            else
            {
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("CREATE UNIT", 180, "You do not have enough political points to create the sub-unit.",  self.BackBitmap, num1 + 750, 80, true, theight: 50, usefont: self.game.MarcFont1, useshadow: true, tMarcStyle: true);
              self.B4Id = self.AddSubPart( tsubpart, num1 + 750, 80, 180, 50, 0);
            }
          }
          else
          {
            let mut tsubpart: SubPartClass =  new TextButtonPartClass("CREATE UNIT", 180, "You have selected unit, now select a sub-unit as well.",  self.BackBitmap, num1 + 750, 80, true, theight: 50, usefont: self.game.MarcFont1, useshadow: true, tMarcStyle: true);
            self.B4Id = self.AddSubPart( tsubpart, num1 + 750, 80, 180, 50, 0);
          }
        }
        else
        {
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("CREATE UNIT", 180, "Please select a unit and a subunit.",  self.BackBitmap, num1 + 750, 80, true, theight: 50, usefont: self.game.MarcFont1, useshadow: true, tMarcStyle: true);
          self.B4Id = self.AddSubPart( tsubpart, num1 + 750, 80, 180, 50, 0);
        }
      }
      else
        DrawMod.DrawTextColouredMarc( objgraphics, "To many units in hex to create a new one.", self.game.MarcFont4, num1 + 50, 91, Color.White);
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      OrderResult orderResult = OrderResult::new();
      if (self.SubPartCounter > -1)
      {
        int subPartCounter = self.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > self.SubPartX[index] & x < self.SubPartX[index] + self.SubPartW[index] && y > self.SubPartY[index] & y < self.SubPartY[index] + self.SubPartH[index])
          {
            int num1 = self.SubPartID[index];
            if (num1 == self.B3Id)
            {
              self.game.ProcessingObj.AddNewUnitBasedOnHistorical(self.game.EditObj.OrderX, self.game.EditObj.OrderY, self.game.EditObj.OrderMap, self.game.Data.Turn, self.detailnr, self.detailnr2);
              windowReturnClass.AddCommand(4, 18);
              self.game.EditObj.TempCoordList = CoordList::new();
              self.game.EditObj.TempCoordList.AddCoord(self.game.EditObj.OrderX, self.game.EditObj.OrderY, self.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 44);
              self.calc();
              self.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == self.B5Id)
            {
              self.game.ProcessingObj.AddNewUnitBasedOnHistorical(self.game.EditObj.OrderX, self.game.EditObj.OrderY, self.game.EditObj.OrderMap, self.game.Data.Turn, self.detailnr, self.detailnr2, self.game.EditObj.OrderUnit);
              self.game.EditObj.OrderType = 0;
              self.game.EditObj.UnitSelected = self.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              self.game.EditObj.TempCoordList = CoordList::new();
              self.game.EditObj.TempCoordList.AddCoord(self.game.EditObj.OrderX, self.game.EditObj.OrderY, self.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(2, 20);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == self.B6Id)
            {
              if (self.game.Data.UnitObj[self.game.EditObj.OrderUnit].Historical > -1 && self.game.Data.UnitObj[self.game.EditObj.OrderUnit].HistoricalSubPart > -1)
                self.game.Data.UnitObj[self.game.EditObj.OrderUnit].StartPower = self.game.HandyFunctionsObj.GetPowerPtsAbsolute(self.game.HandyFunctionsObj.GetPreDef(self.game.Data.HistoricalUnitObj[self.game.Data.UnitObj[self.game.EditObj.OrderUnit].Historical].SubParts[self.game.Data.UnitObj[self.game.EditObj.OrderUnit].HistoricalSubPart]), true);
              self.game.Data.UnitObj[self.game.EditObj.OrderUnit].Historical = -1;
              self.game.Data.UnitObj[self.game.EditObj.OrderUnit].HistoricalSubPart = -1;
              self.game.Data.UnitObj[self.game.EditObj.OrderUnit].Name = self.game.Data.RegimeObj[self.game.Data.UnitObj[self.game.EditObj.OrderUnit].Regime].UnitName;
              self.game.EditObj.OrderType = 0;
              self.game.EditObj.UnitSelected = self.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              self.game.EditObj.TempCoordList = CoordList::new();
              self.game.EditObj.TempCoordList.AddCoord(self.game.EditObj.OrderX, self.game.EditObj.OrderY, self.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(2, 20);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == self.OptionsListId)
            {
              int num2 = self.SubPartList[index].Click(x - self.SubPartX[index], y - self.SubPartY[index]);
              self.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                self.detailnr = num2;
                self.detailnr2 = -1;
                self.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == self.OptionsList2Id)
            {
              int num3 = self.SubPartList[index].Click(x - self.SubPartX[index], y - self.SubPartY[index]);
              self.SubPartFlag[index] = true;
              if (num3 > -1)
              {
                self.detailnr2 = num3;
                self.dostuff();
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
