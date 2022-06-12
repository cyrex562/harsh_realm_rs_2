// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NewUnitWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  public class NewUnitWindowClass : WindowClass
  {
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B2bId;
    private int B2bTextId;
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

    public NewUnitWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.steppy = 0;
      this.typpy = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.fixshade = true;
      if (this.game.Data.Round == 0 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime > -1)
        this.game.Data.Turn = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime;
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
      if (this.B2bId > 0)
        this.RemoveSubPart(this.B2bId);
      if (this.B2bTextId > 0)
        this.RemoveSubPart(this.B2bTextId);
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
      SubPartClass tsubpart1 = (SubPartClass) new ATTextPartClass("Create what type of unit?", this.game.VicFont1, 400, 24, false);
      this.ExtraId = this.AddSubPart(ref tsubpart1, 410, 22, 400, 24, 0);
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].UnitCounter < 15)
      {
        if ((double) this.game.Data.RuleVar[526] == 0.0)
        {
          if ((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46])
          {
            SubPartClass tsubpart2 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 60);
            this.B1Id = this.AddSubPart(ref tsubpart2, 440, 60, 32, 32, 1);
          }
          SubPartClass tsubpart3 = (SubPartClass) new ATTextPartClass("Formation (" + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[46])) + " pp)", this.game.VicFont2, 400, 24, false);
          this.B1TextId = this.AddSubPart(ref tsubpart3, 480, 69, 400, 24, 0);
          if ((double) this.game.Data.RuleVar[343] > 0.0)
          {
            if ((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[47] + (double) this.game.Data.RuleVar[345])
            {
              SubPartClass tsubpart4 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 100);
              this.B2bId = this.AddSubPart(ref tsubpart4, 440, 100, 32, 32, 1);
            }
            SubPartClass tsubpart5 = (SubPartClass) new ATTextPartClass("HQ (" + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[47])) + " pp)", this.game.VicFont2, 400, 24, false);
            this.B2bTextId = this.AddSubPart(ref tsubpart5, 480, 109, 400, 24, 0);
            if ((double) this.game.Data.RuleVar[345] > 0.0 & this.game.Data.RegimeObj[this.game.Data.Turn].OfficerPool > -1 & this.game.Data.Round > 0)
            {
              if ((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[47] + (double) this.game.Data.RuleVar[345])
              {
                SubPartClass tsubpart6 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 140);
                this.B2Id = this.AddSubPart(ref tsubpart6, 440, 140, 32, 32, 1);
              }
              SubPartClass tsubpart7 = (SubPartClass) new ATTextPartClass("HQ + Leader (" + Strings.Trim(Conversion.Str((object) (float) ((double) this.game.Data.RuleVar[47] + (double) this.game.Data.RuleVar[345]))) + " pp)", this.game.VicFont2, 400, 24, false);
              this.B2TextId = this.AddSubPart(ref tsubpart7, 480, 149, 400, 24, 0);
            }
          }
          else
          {
            if ((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[47])
            {
              SubPartClass tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 100);
              this.B2Id = this.AddSubPart(ref tsubpart8, 440, 100, 32, 32, 1);
            }
            SubPartClass tsubpart9 = (SubPartClass) new ATTextPartClass("HQ (" + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[47])) + " pp)", this.game.VicFont2, 400, 24, false);
            this.B2TextId = this.AddSubPart(ref tsubpart9, 480, 109, 400, 24, 0);
          }
        }
        else
        {
          this.OptionsListObj = new ListClass();
          int num = -1;
          int tlistselect1 = -1;
          int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
          for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
          {
            if (this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn)
            {
              ++num;
              if (tdata == this.detailnr)
                tlistselect1 = num;
              this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata, Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP));
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
            SubPartClass tsubpart10 = (SubPartClass) new ListSubPartClass(optionsListObj, 9, 500, tlistselect2, game, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 310, bby: 55, overruleFont: (ref local2));
            this.OptionsListId = this.AddSubPart(ref tsubpart10, 10, 30, 500, 160, 0);
          }
          if (this.detailnr > -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.HistoricalUnitObj[this.detailnr].PP & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter + this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(this.detailnr) < 16)
            {
              SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.OKBALL);
              this.B3Id = this.AddSubPart(ref tsubpart11, 530, 30, 32, 32, 1);
            }
            else
            {
              SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.OKBALL, 1);
              this.B4Id = this.AddSubPart(ref tsubpart12, 530, 30, 32, 32, 0);
            }
            SubPartClass tsubpart13 = (SubPartClass) new TextPartClass("Make new unit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 24, false);
            this.B3TextId = this.AddSubPart(ref tsubpart13, 580, 39, 200, 24, 0);
          }
        }
      }
      else
      {
        SubPartClass tsubpart14 = (SubPartClass) new ATTextPartClass("To many units on hex to create a new one.", this.game.VicFont2, 400, 24, false);
        this.B1TextId = this.AddSubPart(ref tsubpart14, 50, 89, 400, 24, 0);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
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
              this.game.EditObj.OrderType = 3;
              this.game.EditObj.OrderUnit = this.game.Data.UnitCounter;
              this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(4, 18);
              windowReturnClass.AddCommand(2, 20);
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(4, 66);
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
                  windowReturnClass.AddCommand(4, 18);
                  windowReturnClass.AddCommand(2, 20);
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 66);
                  windowReturnClass.AddCommand(4, 44);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.OrderType = 0;
                this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(2, 20);
                this.game.EditObj.TempCoordList = new CoordList();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 66);
                windowReturnClass.AddCommand(4, 44);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else if (num1 == this.B2Id)
            {
              OrderResult orderResult3 = this.game.ProcessingObj.NewUnit(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.MapSelected, true, this.game.Data.Turn);
              if (this.game.EditObj.SoundOn)
                SoundMod.PlayAWave(this.game.AppPath + "sound/radio.wav", ref this.game.EditObj);
              if (orderResult3.OK)
              {
                this.game.EditObj.OrderType = 3;
                this.game.EditObj.OrderUnit = this.game.Data.UnitCounter;
                this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 20);
                windowReturnClass.AddCommand(4, 18);
                this.game.EditObj.TempCoordList = new CoordList();
                this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 44);
                windowReturnClass.AddCommand(4, 66);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else if (num1 == this.B2bId)
            {
              OrderResult orderResult4 = this.game.ProcessingObj.NewUnit(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.MapSelected, true, this.game.Data.Turn, true);
              if (this.game.EditObj.SoundOn)
                SoundMod.PlayAWave(this.game.AppPath + "sound/radio.wav", ref this.game.EditObj);
              if (orderResult4.OK)
              {
                this.game.EditObj.OrderType = 3;
                this.game.EditObj.OrderUnit = this.game.Data.UnitCounter;
                this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 20);
                windowReturnClass.AddCommand(4, 18);
                this.game.EditObj.TempCoordList = new CoordList();
                this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 44);
                windowReturnClass.AddCommand(4, 66);
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
