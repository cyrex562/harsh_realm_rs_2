// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ChangeModelWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  public class ChangeModelWindowClass : WindowClass
  {
    private int LocNr;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int detailnr;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int off1id;
    private int Pic1Id;
    private int detailnr2;
    private int OrderTextId;
    private int OrderText2Id;
    private int OrderUpId;
    private int OrderDownId;
    private int ExtraId;
    private int steppy;
    private int typpy;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private bool Hq;

    public ChangeModelWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.LocNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      this.detailnr = -1;
      this.dostuff();
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
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int orderUnit = this.game.EditObj.OrderUnit;
      string txt;
      int Number1;
      int num1;
      if (this.game.Data.UnitObj[orderUnit].Historical == -1)
      {
        txt = "Unit is currently a to be disbanded formation.";
        Number1 = 1;
        num1 = -1;
      }
      else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[orderUnit].Historical].ModelMaster == -1)
      {
        int Number2;
        txt = "Unit is currently an ad hoc formation." + " Current unit consists of " + Conversion.Str((object) Number2) + " subunits.";
        num1 = -1;
      }
      else
      {
        string str = "Current Model is " + this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[orderUnit].Historical].ModelMaster].Name;
        int unitCounter = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          if (this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].Historical == this.game.Data.UnitObj[orderUnit].Historical)
            ++Number1;
        }
        txt = str + " Current unit consists of " + Conversion.Str((object) Number1) + " subunits.";
        num1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[orderUnit].Historical].ModelMaster;
      }
      SubPartClass tsubpart = (SubPartClass) new TextPartClass(txt, new Font("Times New Roman", 22f, FontStyle.Regular, GraphicsUnit.Pixel), 700, 24, false);
      this.ExtraId = this.AddSubPart(ref tsubpart, 10, 2, 700, 24, 0);
      this.OptionsListObj = new ListClass();
      int num2 = -1;
      int tlistselect1 = -1;
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter; ++index)
      {
        if (this.game.Data.HistoricalUnitObj[index].Model & this.game.Data.HistoricalUnitObj[index].TempRegime == this.game.Data.Turn && Number1 <= this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(index) && this.game.Data.HistoricalUnitObj[index].Type < 5 && !(this.game.Data.HistoricalUnitObj[index].Type < 5 & this.game.Data.UnitObj[orderUnit].IsHQ) && num1 != index)
        {
          ++num2;
          if (index == this.detailnr)
            tlistselect1 = num2;
          this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[index].Name, index, Conversion.Str((object) this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(index)) + " units");
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
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 9, 500, tlistselect2, game, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 310, bby: 55, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart, 10, 30, 500, 160, 0);
      }
      if (this.detailnr > -1)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.OKBALL);
        this.B3Id = this.AddSubPart(ref tsubpart, 530, 30, 32, 32, 1);
        tsubpart = (SubPartClass) new TextPartClass("Change to this model", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
        this.B3TextId = this.AddSubPart(ref tsubpart, 580, 39, 200, 24, 0);
      }
      if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].ModelMaster > -1)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.CANCELBALL);
        this.B4Id = this.AddSubPart(ref tsubpart, 530, 70, 32, 32, 1);
        tsubpart = (SubPartClass) new TextPartClass("Disable Model (ad hoc)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
        this.B4TextId = this.AddSubPart(ref tsubpart, 580, 79, 200, 24, 0);
      }
      if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.CANCELBALL);
        this.B5Id = this.AddSubPart(ref tsubpart, 530, 110, 32, 32, 1);
        tsubpart = (SubPartClass) new TextPartClass("Set for Disband", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
        this.B5TextId = this.AddSubPart(ref tsubpart, 580, 119, 200, 24, 0);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.Data.Turn, this.detailnr, OverWriteUnr: this.game.EditObj.OrderUnit);
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(2, 20);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].ModelMaster = -1;
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(2, 20);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index2 = 0; index2 <= unitCounter; ++index2)
              {
                if (this.game.Data.UnitObj[index2].Historical == this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical & index2 != this.game.EditObj.OrderUnit)
                  this.game.Data.UnitObj[index2].Historical = -1;
              }
              this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical = -1;
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(2, 20);
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
