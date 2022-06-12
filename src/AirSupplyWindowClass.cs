// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AirSupplyWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class AirSupplyWindowClass : WindowClass
  {
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B5Id;
    private int B6Id;
    private int Type1Id;
    private int Type2Id;
    private int Type3Id;
    private int text4id;
    private int text5id;
    private int text6id;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Pic1Id;
    private int Pic2Id;
    private int pic4id;
    private int hq0id;
    private int hq1id;
    private int hq2id;
    private int hq3id;
    private int detailnr;
    private int detailtype;
    private int OrderTextId;
    private int OrderText2Id;
    private int OrderUpId;
    private int OrderDownId;
    private int ExtraId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int OrderOKId;
    private int OrderOKTextId;
    private int YesId;
    private int sliderID;
    private int CapTheater;
    private int TempNew;
    private object LandCost;
    private object NavyCost;
    private object AirCost;
    private int unr;
    private int unrT;
    private int hq;
    private int nothq;
    private int OwnPowerTransfer;
    private int TargetX;
    private int TargetY;
    private int TargetMap;
    private int maxneed;
    private int max;
    private bool AirCarrier;
    private int HQSelect;
    private int[] ChainHq;

    public AirSupplyWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.ChainHq = new int[3];
      this.detailnr = -1;
      this.detailtype = 1;
      this.fixshade = true;
      this.unr = this.game.EditObj.OrderUnit;
      this.ChainHq[0] = -1;
      this.HQSelect = -1;
      this.ChainHq[1] = -1;
      this.ChainHq[2] = -1;
      if (this.game.Data.UnitObj[this.unr].IsHQ)
      {
        this.ChainHq[0] = this.unr;
        this.HQSelect = this.unr;
        int hq1 = this.game.Data.UnitObj[this.ChainHq[0]].HQ;
        if (hq1 > -1)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, allowshoredrop: true, SeaBlock: true, BlockAllSea: true);
          if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq1].Map].Value[this.game.Data.UnitObj[hq1].X, this.game.Data.UnitObj[hq1].Y] <= (double) this.game.Data.RuleVar[51])
          {
            this.ChainHq[1] = hq1;
            int hq2 = this.game.Data.UnitObj[this.ChainHq[1]].HQ;
            if (hq2 > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq2].Map].Value[this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y] <= (double) this.game.Data.RuleVar[51])
              this.ChainHq[2] = hq2;
          }
        }
      }
      else if (this.game.Data.UnitObj[this.unr].HQ > -1)
      {
        this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, allowshoredrop: true, SeaBlock: true, BlockAllSea: true);
        int hq3 = this.game.Data.UnitObj[this.unr].HQ;
        if (this.game.Data.UnitObj[hq3].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq3].Map].Value[this.game.Data.UnitObj[hq3].X, this.game.Data.UnitObj[hq3].Y] <= (double) this.game.Data.RuleVar[51])
        {
          this.ChainHq[0] = hq3;
          this.HQSelect = hq3;
          int hq4 = this.game.Data.UnitObj[this.ChainHq[0]].HQ;
          if (hq4 > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq4].Map].Value[this.game.Data.UnitObj[hq4].X, this.game.Data.UnitObj[hq4].Y] <= (double) this.game.Data.RuleVar[51])
          {
            this.ChainHq[1] = hq4;
            int hq5 = this.game.Data.UnitObj[this.ChainHq[1]].HQ;
            if (hq5 > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq5].Map].Value[this.game.Data.UnitObj[hq5].X, this.game.Data.UnitObj[hq5].Y] <= (double) this.game.Data.RuleVar[51])
              this.ChainHq[2] = hq5;
          }
        }
      }
      this.TargetX = this.game.EditObj.TargetX;
      this.TargetY = this.game.EditObj.TargetY;
      this.TargetMap = this.game.EditObj.TargetMap;
      this.maxneed = this.game.HandyFunctionsObj.AirSupplyNeeded(this.TargetX, this.TargetY, this.TargetMap);
      this.dostuff();
    }

    public override void DoRefresh()
    {
      this.detailnr = -1;
      this.detailtype = 1;
      this.unr = this.game.EditObj.OrderUnit;
      this.dostuff();
    }

    private void dostuff()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.text4id > 0)
        this.RemoveSubPart(this.text4id);
      if (this.text5id > 0)
        this.RemoveSubPart(this.text5id);
      if (this.text6id > 0)
        this.RemoveSubPart(this.text6id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
      if (this.Pic2Id > 0)
        this.RemoveSubPart(this.Pic2Id);
      if (this.pic4id > 0)
        this.RemoveSubPart(this.pic4id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
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
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.OptionsList2Id > 0)
        this.RemoveSubPart(this.OptionsList2Id);
      if (this.OrderOKId > 0)
        this.RemoveSubPart(this.OrderOKId);
      if (this.OrderOKTextId > 0)
        this.RemoveSubPart(this.OrderOKTextId);
      if (this.Type1Id > 0)
        this.RemoveSubPart(this.Type1Id);
      if (this.Type2Id > 0)
        this.RemoveSubPart(this.Type2Id);
      if (this.Type3Id > 0)
        this.RemoveSubPart(this.Type3Id);
      if (this.YesId > 0)
        this.RemoveSubPart(this.YesId);
      if (this.sliderID > 0)
        this.RemoveSubPart(this.sliderID);
      if (this.hq0id > 0)
        this.RemoveSubPart(this.hq0id);
      if (this.hq1id > 0)
        this.RemoveSubPart(this.hq1id);
      if (this.hq2id > 0)
        this.RemoveSubPart(this.hq2id);
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawBlock(ref Expression, 430, 20, 400, 70, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, 430, 20, 400, 70, -1, -1);
      ref Graphics local1 = ref Expression;
      Rectangle rectangle1 = new Rectangle(430, 6, 400, 14);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2;
      Rectangle rect2_1 = rectangle2;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "SUPPLY FLOW", rect2_1, "");
      SubPartClass tsubpart1 = (SubPartClass) new ATTextPartClass("FROM", this.game.VicFont2, 55, 20, true, tDescript: "The unit you are transferring from");
      this.Text1Id = this.AddSubPart(ref tsubpart1, 440, 30, 60, 20, 0);
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.unr), "The unit you are transferring from");
      this.Pic1Id = this.AddSubPart(ref tsubpart2, 500, 30, 37, 37, 0);
      tsubpart2 = (SubPartClass) new ATTextPartClass("TO", this.game.VicFont2, 55, 20, true, tDescript: "The hex you are transferring too");
      this.Text2Id = this.AddSubPart(ref tsubpart2, 550, 30, 40, 20, 0);
      CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
      int targetX = this.TargetX;
      int targetY = this.TargetY;
      int targetMap = this.TargetMap;
      Bitmap bitmap1 = (Bitmap) null;
      ref Bitmap local2 = ref bitmap1;
      bool flag = false;
      ref bool local3 = ref flag;
      tsubpart2 = (SubPartClass) new ButtonPartClass(customBitmapObj.DrawHex(targetX, targetY, targetMap, gBitmap: (ref local2), tFromMapPopup: (ref local3)), "The hex you are transferring too");
      this.Pic2Id = this.AddSubPart(ref tsubpart2, 590, 30, 64, 48, 0);
      tsubpart2 = (SubPartClass) new ATTextPartClass("SUPPLY HQ", this.game.VicFont2, 85, 20, true, tDescript: "The hq that is providing the supply points");
      this.text4id = this.AddSubPart(ref tsubpart2, 670, 30, 85, 20, 0);
      if (this.HQSelect > -1)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.HQSelect), "The hq that is providing the supply points");
        this.pic4id = this.AddSubPart(ref tsubpart2, 760, 30, 31, 31, 0);
      }
      DrawMod.DrawBlock(ref Expression, 220, 20, 200, 70, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, 220, 20, 200, 70, -1, -1);
      ref Graphics local4 = ref Expression;
      rectangle1 = new Rectangle(220, 6, 150, 14);
      Rectangle rect1_2 = rectangle1;
      Rectangle rect2_2 = rectangle2;
      DrawMod.MakeFullBoxVic2(ref local4, rect1_2, "AVAILABLE HQs", rect2_2, "");
      if (this.HQSelect > -1)
      {
        if (this.ChainHq[0] > -1)
        {
          bool forcehighlight = false;
          if (this.HQSelect == this.ChainHq[0] & this.HQSelect != -1)
            forcehighlight = true;
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[0], forcehighlight), this.game.Data.UnitObj[this.ChainHq[0]].Name);
          this.hq0id = this.AddSubPart(ref tsubpart2, 254, 32, 36, 36, 0);
          if (forcehighlight)
            DrawMod.DrawRectangle(ref Expression, 252, 30, 40, 40, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
        }
        if (this.ChainHq[1] > -1)
        {
          bool forcehighlight = false;
          if (this.HQSelect == this.ChainHq[1] & this.HQSelect != -1)
            forcehighlight = true;
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[1], forcehighlight), this.game.Data.UnitObj[this.ChainHq[1]].Name);
          this.hq1id = this.AddSubPart(ref tsubpart2, 299, 32, 36, 36, 0);
          if (forcehighlight)
            DrawMod.DrawRectangle(ref Expression, 297, 30, 40, 40, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
        }
        if (this.ChainHq[2] > -1)
        {
          bool forcehighlight = false;
          if (this.HQSelect == this.ChainHq[2] & this.HQSelect != -1)
            forcehighlight = true;
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[2], forcehighlight), this.game.Data.UnitObj[this.ChainHq[2]].Name);
          this.hq2id = this.AddSubPart(ref tsubpart2, 344, 32, 36, 36, 0);
          if (forcehighlight)
            DrawMod.DrawRectangle(ref Expression, 342, 30, 40, 40, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
        }
        int carryCapPts = this.game.HandyFunctionsObj.GetCarryCapPts(this.unr, 2);
        this.max = (int) Math.Round((double) Conversion.Int((float) carryCapPts / this.game.Data.RuleVar[33]));
        if (this.max > this.game.Data.UnitObj[this.HQSelect].Supply)
          this.max = this.game.Data.UnitObj[this.HQSelect].Supply;
        if (this.maxneed < this.max)
          this.max = this.maxneed;
        if (this.TempNew > this.max)
          this.TempNew = this.max;
        tsubpart2 = (SubPartClass) new ATTextPartClass("With " + Conversion.Str((object) carryCapPts) + " transport pts you can airsupply " + Conversion.Str((object) Conversion.Int((float) carryCapPts / this.game.Data.RuleVar[33])) + " pts. Max needed is " + Conversion.Str((object) this.maxneed) + ". HQ has " + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.HQSelect].Supply)), this.game.VicFont2, 700, 20, true);
        this.Text3Id = this.AddSubPart(ref tsubpart2, 150, 95, 700, 20, 0);
        if (this.max > 0)
        {
          GameClass game = this.game;
          int max = this.max;
          int tempNew = this.TempNew;
          Bitmap bitmap2 = (Bitmap) null;
          ref Bitmap local5 = ref bitmap2;
          tsubpart2 = (SubPartClass) new NumberSliderSubPartClass2(game, "", "x Supply Pts", 300, 0, max, tempNew, tbackbitmap: (ref local5));
          this.sliderID = this.AddSubPart(ref tsubpart2, 360, 115, 300, 40, 0);
        }
        if (this.max == 0)
        {
          if (this.game.Data.UnitObj[this.HQSelect].Supply == 0)
          {
            tsubpart2 = (SubPartClass) new ATTextPartClass("HQ of transporter unit has no supply left to give.", this.game.VicFont2, 320, 25, true);
            this.OrderOKTextId = this.AddSubPart(ref tsubpart2, 345, 115, 320, 25, 0);
          }
          else
          {
            tsubpart2 = (SubPartClass) new ATTextPartClass("Units in this area cannot be given more supply.", this.game.VicFont2, 320, 25, true);
            this.OrderOKTextId = this.AddSubPart(ref tsubpart2, 345, 115, 320, 25, 0);
          }
        }
        if (this.TempNew > 0)
        {
          tsubpart2 = (SubPartClass) new TextButtonPartClass("Do Airsupply", 100, "Click to transfer selected amount", ref this.OwnBitmap, 462, 161);
          this.OrderOKId = this.AddSubPart(ref tsubpart2, 462, 161, 100, 35, 1);
        }
        else
        {
          tsubpart2 = (SubPartClass) new TextButtonPartClass("Do Airsupply", 100, "Click to transfer selected amount", ref this.OwnBitmap, 462, 161, true);
          this.OrderOKTextId = this.AddSubPart(ref tsubpart2, 462, 161, 100, 35, 1);
        }
      }
      else
      {
        tsubpart2 = (SubPartClass) new ATTextPartClass("HQ of Air unit is to far away to provide the supply for the air operation.", this.game.VicFont2, 700, 20, true);
        this.Text3Id = this.AddSubPart(ref tsubpart2, 150, 95, 700, 20, 0);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      Coordinate Target = new Coordinate();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
            if (num == this.OrderOKId)
            {
              this.game.EditObj.TempUnitList = new UnitList();
              this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderUnit);
              Target.x = this.game.SelectX;
              Target.y = this.game.SelectY;
              this.game.EditObj.AirSupplyPts = this.TempNew;
              this.game.EditObj.AirSupplyHq = this.HQSelect;
              this.game.EditObj.TargetX = this.TargetX;
              this.game.EditObj.TargetY = this.TargetY;
              this.game.EditObj.AirSupplyCarry = this.game.HandyFunctionsObj.GetCarryCapPts(this.game.EditObj.OrderUnit, 2);
              Target.onmap = true;
              this.game.TempCombat = new CombatClass(this.game);
              if (this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, this.game.EditObj.OrderType).OK)
                windowReturnClass.AddCommand(3, 5);
              return windowReturnClass;
            }
            if (num == this.sliderID)
            {
              this.TempNew = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              if (this.TempNew > this.max)
                this.TempNew = this.max;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.hq0id)
            {
              this.HQSelect = this.ChainHq[0];
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.hq1id)
            {
              this.HQSelect = this.ChainHq[1];
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.hq2id)
            {
              this.HQSelect = this.ChainHq[2];
              this.dostuff();
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
