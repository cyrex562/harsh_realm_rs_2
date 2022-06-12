// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ProdWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ProdWindowClass : WindowClass
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
    private ATListClass OptionsListObj;
    private int OptionsList2Id;
    private ATListClass OptionsList2Obj;
    private int detailnr;
    private int detailnr2;
    private int slotty;
    private int[] SlotButId;
    private int[] SlotBut2Id;
    private int[] SlotText1;
    private int[] SlotText2;
    private int[] SlotText3;
    private int[] SlotText4;
    private int[] SlotText5;
    private int[] SlotSlider;
    private int[,] PercentBut;
    private int[] PercentX;
    private int totpercent;
    private int Qball;
    private int FlapBall;
    private int HqBall;
    private int CurrentHQ;

    public ProdWindowClass(
      ref GameClass tGame,
      Bitmap screenbitmap = null,
      int sx = -1,
      int sy = -1,
      int tl1 = -1,
      int tl2 = -1,
      int tl3 = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.SlotButId = new int[4];
      this.SlotBut2Id = new int[4];
      this.SlotText1 = new int[4];
      this.SlotText2 = new int[4];
      this.SlotText3 = new int[4];
      this.SlotText4 = new int[4];
      this.SlotText5 = new int[4];
      this.SlotSlider = new int[4];
      this.PercentBut = new int[4, 11];
      this.PercentX = new int[4];
      this.LocNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.slotty = -1;
      if (this.game.Data.LocObj[this.LocNr].Production[0] > -1)
      {
        this.slotty = 0;
        this.detailnr = this.game.Data.LocObj[this.LocNr].Production[0];
        this.detailnr2 = this.game.Data.ItemTypeObj[this.detailnr].ItemGroup;
      }
      if (tl1 > -1 | tl2 > -1)
      {
        this.detailnr = tl1;
        this.detailnr2 = tl2;
        this.slotty = tl3;
      }
      this.dostuff();
    }

    public void PopUpRefresh() => this.DoRefresh();

    public override void DoRefresh()
    {
      if (this.game.EditObj.OrderLoc < 0)
        return;
      this.LocNr = this.game.EditObj.OrderLoc;
      this.detailnr = -1;
      this.detailnr2 = 0;
      this.slotty = 0;
      if (this.LocNr > -1 && this.game.Data.LocObj[this.LocNr].Production[0] > -1)
      {
        this.slotty = 0;
        this.detailnr = this.game.Data.LocObj[this.LocNr].Production[0];
        this.detailnr2 = this.game.Data.ItemTypeObj[this.detailnr].ItemGroup;
      }
      this.dostuff();
    }

    private void dostuff()
    {
      if (this.Qball > 0)
        this.RemoveSubPart(this.Qball);
      if (this.HqBall > 0)
        this.RemoveSubPart(this.HqBall);
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
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
      if (this.FlapBall > 0)
        this.RemoveSubPart(this.FlapBall);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      this.totpercent = 0;
      int index1 = 0;
      do
      {
        if (this.SlotButId[index1] > 0)
          this.RemoveSubPart(this.SlotButId[index1]);
        if (this.SlotBut2Id[index1] > 0)
          this.RemoveSubPart(this.SlotBut2Id[index1]);
        if (this.SlotText1[index1] > 0)
          this.RemoveSubPart(this.SlotText1[index1]);
        if (this.SlotText2[index1] > 0)
          this.RemoveSubPart(this.SlotText2[index1]);
        if (this.SlotText3[index1] > 0)
          this.RemoveSubPart(this.SlotText3[index1]);
        if (this.SlotText4[index1] > 0)
          this.RemoveSubPart(this.SlotText4[index1]);
        if (this.SlotText5[index1] > 0)
          this.RemoveSubPart(this.SlotText5[index1]);
        if (this.SlotSlider[index1] > 0)
          this.RemoveSubPart(this.SlotSlider[index1]);
        int index2 = 0;
        do
        {
          if (this.PercentBut[index1, index2] > 0)
            this.RemoveSubPart(this.PercentBut[index1, index2]);
          ++index2;
        }
        while (index2 <= 10);
        if (this.PercentX[index1] > 0)
          this.RemoveSubPart(this.PercentX[index1]);
        this.totpercent += this.game.Data.LocObj[this.LocNr].ProdPercent[index1];
        ++index1;
      }
      while (index1 <= 3);
      this.totpercent = 100 - this.totpercent;
      if (0 > this.totpercent)
        this.totpercent = 0;
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime;
      int prodslot = 0;
      SubPartClass tsubpart;
      do
      {
        if (this.slotty == prodslot)
          DrawMod.DrawRectangle(ref Expression, 0, 3 + prodslot * 44, 351, 44, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B, (int) this.game.viccolor7.A, 2);
        if (this.game.Data.LocObj[this.LocNr].Production[prodslot] == -1)
        {
          int[] slotButId = this.SlotButId;
          int index3 = prodslot;
          tsubpart = (SubPartClass) new ButtonPartClass(this.game.EMPTYSLOT, tResizeX: 40, tresizeY: 30);
          int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
          slotButId[index3] = num;
        }
        else if (this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].IsResPt & this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].UseSFType == -1)
        {
          int[] slotButId = this.SlotButId;
          int index4 = prodslot;
          tsubpart = (SubPartClass) new ButtonPartClass(this.game.PRODPP, tResizeX: 40, tresizeY: 30);
          int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
          slotButId[index4] = num;
        }
        else if (this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].IsSupply & this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].UseSFType == -1)
        {
          int[] slotButId = this.SlotButId;
          int index5 = prodslot;
          tsubpart = (SubPartClass) new ButtonPartClass(this.game.PRODSUPPLY, tResizeX: 40, tresizeY: 30);
          int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
          slotButId[index5] = num;
        }
        else if (this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].IsSFType > -1 | this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].UseSFType > -1)
        {
          int ttyp = this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].IsSFType;
          if (this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].UseSFType > -1)
            ttyp = this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].UseSFType;
          if (regime > -1)
          {
            if (this.game.Data.RegimeObj[regime].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[ttyp].ExtraCounter > -1)
            {
              int extraCounter = this.game.Data.SFTypeObj[ttyp].ExtraCounter;
              for (int index6 = 0; index6 <= extraCounter; ++index6)
              {
                if (this.game.Data.SFTypeObj[ttyp].ExtraCode[index6] == this.game.Data.RegimeObj[regime].ExtraGraphicUse)
                {
                  int[] slotButId = this.SlotButId;
                  int index7 = prodslot;
                  tsubpart = (SubPartClass) new SFButtonPartClass(ttyp, this.game.Data.RegimeObj[regime].ExtraGraphicUse, 40, 30);
                  int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
                  slotButId[index7] = num;
                }
              }
            }
            else if (this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[ttyp].ExtraCounter > -1)
            {
              int extraCounter = this.game.Data.SFTypeObj[ttyp].ExtraCounter;
              for (int index8 = 0; index8 <= extraCounter; ++index8)
              {
                if (this.game.Data.SFTypeObj[ttyp].ExtraCode[index8] == this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse)
                {
                  int[] slotButId = this.SlotButId;
                  int index9 = prodslot;
                  tsubpart = (SubPartClass) new SFButtonPartClass(ttyp, this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse, 40, 30);
                  int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
                  slotButId[index9] = num;
                }
              }
            }
            else
            {
              int[] slotButId = this.SlotButId;
              int index10 = prodslot;
              tsubpart = (SubPartClass) new SFButtonPartClass(ttyp, -1, 40, 30);
              int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
              slotButId[index10] = num;
            }
          }
          else
          {
            int[] slotButId = this.SlotButId;
            int index11 = prodslot;
            tsubpart = (SubPartClass) new SFButtonPartClass(ttyp, -1, 40, 30);
            int num = this.AddSubPart(ref tsubpart, 8, 8 + prodslot * 44, 40, 30, 1);
            slotButId[index11] = num;
          }
          DrawMod.DrawRectangle(ref Expression, 6, 6 + prodslot * 44, 40, 31, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        }
        string txt = this.game.Data.LocObj[this.LocNr].Production[prodslot] <= -1 ? "Empty Prod Slot" : Conversion.Str((object) Conversions.ToInteger(Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[this.LocNr].TempProdPredict[prodslot])))) + "x " + this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[prodslot]].Name;
        if (this.slotty == prodslot)
        {
          int[] slotText1 = this.SlotText1;
          int index12 = prodslot;
          tsubpart = (SubPartClass) new ATTextPartClass(txt, this.game.VicFont3, 100, 20, false);
          int num = this.AddSubPart(ref tsubpart, 50, 5 + prodslot * 44, 97, 20, 0);
          slotText1[index12] = num;
        }
        else
        {
          int[] slotText1 = this.SlotText1;
          int index13 = prodslot;
          tsubpart = (SubPartClass) new ATTextPartClass(txt, this.game.VicFont3, 100, 20, false);
          int num = this.AddSubPart(ref tsubpart, 50, 5 + prodslot * 44, 97, 20, 0);
          slotText1[index13] = num;
        }
        if (this.game.Data.LocObj[this.LocNr].Production[prodslot] > -1)
        {
          float estimatedProduction1 = (float) this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, this.LocNr, false, false, true);
          int[] slotText2 = this.SlotText2;
          int index14 = prodslot;
          tsubpart = (SubPartClass) new ATTextPartClass("prd: " + Strings.Trim(Conversion.Str((object) estimatedProduction1)), this.game.VicFont4, 50, 20, false);
          int num1 = this.AddSubPart(ref tsubpart, 53, 0 + prodslot * 44 + 20, 45, 20, 0);
          slotText2[index14] = num1;
          float single = Conversions.ToSingle(Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[this.LocNr].TempProdPredict[prodslot])));
          int[] slotText4 = this.SlotText4;
          int index15 = prodslot;
          tsubpart = (SubPartClass) new ATTextPartClass("real: " + Strings.Trim(Conversion.Str((object) single)), this.game.VicFont4, 50, 20, false);
          int num2 = this.AddSubPart(ref tsubpart, 53, 12 + prodslot * 44 + 20, 45, 20, 0);
          slotText4[index15] = num2;
          float estimatedProduction2 = (float) this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, this.LocNr, false, true, true);
          int[] slotText3 = this.SlotText3;
          int index16 = prodslot;
          tsubpart = (SubPartClass) new ATTextPartClass("lft: " + Strings.Trim(Conversion.Str((object) estimatedProduction2)), this.game.VicFont4, 50, 20, false);
          int num3 = this.AddSubPart(ref tsubpart, 100, 0 + prodslot * 44 + 20, 50, 20, 0);
          slotText3[index16] = num3;
        }
        if (this.game.Data.LocObj[this.LocNr].Production[prodslot] > -1)
        {
          int index17 = 0;
          do
          {
            if (this.totpercent + this.game.Data.LocObj[this.LocNr].ProdPercent[prodslot] >= index17 * 10)
            {
              if (index17 * 10 != this.game.Data.LocObj[this.LocNr].ProdPercent[prodslot])
              {
                int[,] percentBut = this.PercentBut;
                int index18 = prodslot;
                int index19 = index17;
                tsubpart = (SubPartClass) new ButtonPartClass(this.game.PERCENT[index17], 3);
                int num = this.AddSubPart(ref tsubpart, 155 + index17 * 16, 5 + prodslot * 44 + 4, 16, 32, 1);
                percentBut[index18, index19] = num;
              }
              else
              {
                int[,] percentBut = this.PercentBut;
                int index20 = prodslot;
                int index21 = index17;
                tsubpart = (SubPartClass) new ButtonPartClass(this.game.PERCENT[index17]);
                int num = this.AddSubPart(ref tsubpart, 155 + index17 * 16, 5 + prodslot * 44 + 4, 16, 32, 1);
                percentBut[index20, index21] = num;
              }
            }
            else
            {
              int[,] percentBut = this.PercentBut;
              int index22 = prodslot;
              int index23 = index17;
              tsubpart = (SubPartClass) new ButtonPartClass(this.game.PERCENT[index17], 4);
              int num = this.AddSubPart(ref tsubpart, 155 + index17 * 16, 5 + prodslot * 44 + 4, 16, 32, 0);
              percentBut[index22, index23] = num;
            }
            ++index17;
          }
          while (index17 <= 10);
          int[] percentX = this.PercentX;
          int index24 = prodslot;
          tsubpart = (SubPartClass) new ButtonPartClass(this.game.PERCENTX);
          int num4 = this.AddSubPart(ref tsubpart, 331, 5 + prodslot * 44 + 4, 16, 32, 1);
          percentX[index24] = num4;
        }
        ++prodslot;
      }
      while (prodslot <= 3);
      int[] numArray1 = new int[100];
      int itemTypeCounter1 = this.game.Data.ItemTypeCounter;
      for (int itemtypenr = 0; itemtypenr <= itemTypeCounter1; ++itemtypenr)
      {
        if (this.game.HandyFunctionsObj.CanProduceItem(this.LocNr, regime, itemtypenr).result & this.game.Data.ItemTypeObj[itemtypenr].ItemGroup > -1)
        {
          int[] numArray2 = numArray1;
          int[] numArray3 = numArray2;
          int itemGroup = this.game.Data.ItemTypeObj[itemtypenr].ItemGroup;
          int index25 = itemGroup;
          int num = numArray2[itemGroup] + 1;
          numArray3[index25] = num;
        }
      }
      if (this.slotty > -1)
      {
        int tlistselect1 = -1;
        int num5 = -1;
        this.OptionsList2Obj = new ATListClass();
        if (this.detailnr2 > 99)
          this.detailnr2 = 99;
        int tdata = 0;
        do
        {
          if (numArray1[tdata] > 0)
          {
            this.OptionsList2Obj.add(this.game.Data.TempString[tdata + 300], tdata);
            ++num5;
            if (this.detailnr2 == tdata)
              tlistselect1 = num5;
          }
          ++tdata;
        }
        while (tdata <= 99);
        if (tlistselect1 == -1)
          this.detailnr2 = -1;
        if (this.OptionsList2Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
        }
        else
        {
          tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsList2Obj, 8, 140, tlistselect1, this.game, true, "ItemGroups", tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 355, bby: 5);
          this.OptionsList2Id = this.AddSubPart(ref tsubpart, 355, 5, 140, 144, 0);
        }
        if (this.detailnr2 > -1)
        {
          this.OptionsListObj = new ATListClass();
          if (this.detailnr > this.game.Data.ItemTypeCounter)
            this.detailnr = -1;
          int num6 = -1;
          int num7 = -1;
          if (this.game.Data.ItemTypeCounter > -1)
          {
            int itemTypeCounter2 = this.game.Data.ItemTypeCounter;
            for (int index26 = 0; index26 <= itemTypeCounter2; ++index26)
            {
              if (this.game.HandyFunctionsObj.CanProduceItem(this.LocNr, regime, index26).result & this.game.Data.ItemTypeObj[index26].ItemGroup == this.detailnr2)
              {
                ++num7;
                if (this.detailnr == index26)
                  num6 = num7;
                string str1 = "";
                if (this.game.Data.ItemTypeObj[index26].IsSupply & (double) this.game.Data.SupplyMultiplier != 1.0)
                  str1 = Strings.Trim(Conversion.Str((object) this.game.Data.SupplyMultiplier)) + "x ";
                if (this.game.Data.ItemTypeObj[index26].IsResPt & (double) this.game.Data.PPMultiplier != 1.0)
                  str1 = Strings.Trim(Conversion.Str((object) this.game.Data.PPMultiplier)) + "x ";
                string str2 = str1 + this.game.Data.ItemTypeObj[index26].Name;
                if (Strings.Len(str2) > 25)
                  str2 = Strings.Left(str2, 25);
                string tname = str2;
                int Number = this.game.Data.ItemTypeObj[index26].ProdWeight;
                if (this.game.Data.ItemTypeObj[index26].UseProdMod <= 1 && (double) this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup] != 0.0)
                  Number = (int) Math.Round((double) Conversion.Int((float) Number / this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup]));
                if (this.game.Data.ItemTypeObj[index26].UseProdMod == 2 && (double) this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod2[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup] != 0.0)
                  Number = (int) Math.Round((double) Conversion.Int((float) Number / this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod2[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup]));
                if (this.game.Data.ItemTypeObj[index26].UseProdMod == 3 && (double) this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod3[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup] != 0.0)
                  Number = (int) Math.Round((double) Conversion.Int((float) Number / this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod3[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup]));
                if (this.game.Data.ItemTypeObj[index26].UseProdMod == 4 && (double) this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod4[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup] != 0.0)
                  Number = (int) Math.Round((double) Conversion.Int((float) Number / this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ProdMod4[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[this.LocNr].Map].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime].People].PeopleGroup]));
                this.OptionsListObj.add(tname, index26, Strings.Trim(Conversion.Str((object) Number)));
              }
            }
          }
          this.OptionsListObj.Sort();
          int tlistselect2 = -1;
          int listCount = this.OptionsListObj.ListCount;
          for (int index27 = 0; index27 <= listCount; ++index27)
          {
            if (this.detailnr == this.OptionsListObj.ListData[index27])
              tlistselect2 = index27;
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect2);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 8, 300, tlistselect2, this.game, true, "Items", tShowPair: true, tValueWidth: 75, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 505, bby: 5);
            this.OptionsListId = this.AddSubPart(ref tsubpart, 505, 5, 300, 144, 0);
          }
          if (this.detailnr > -1 & this.game.Data.LocTypeObj[this.game.Data.LocObj[this.LocNr].Type].AutoProd == -1)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("Select", 96, "Click to assign selected item to production slot", ref this.OwnBitmap, 815, 162);
            this.B2Id = this.AddSubPart(ref tsubpart, 815, 162, 96, 32, 1);
            if (this.game.Data.ItemTypeObj[this.detailnr].IsSFType > -1 & this.game.Data.Round > 0)
            {
              tsubpart = (SubPartClass) new TextButtonPartClass("?", 32, "Click to see info on this Subformation Type", ref this.OwnBitmap, 915, 162);
              this.Qball = this.AddSubPart(ref tsubpart, 915, 162, 32, 32, 1);
            }
          }
        }
        if (this.detailnr > -1)
        {
          int nr1 = -1;
          int nr2 = -1;
          DrawMod.DrawRectangle(ref Expression, 814, 4, 136, 101, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          Bitmap bitmap;
          Rectangle rectangle1;
          Rectangle rectangle2;
          int index28;
          int num8;
          if (this.game.Data.ItemTypeObj[this.detailnr].IsResPt & this.game.Data.ItemTypeObj[this.detailnr].UseSFType == -1)
          {
            ref Graphics local1 = ref Expression;
            bitmap = BitmapStore.GetBitmap(this.game.PRODPP);
            ref Bitmap local2 = ref bitmap;
            rectangle1 = new Rectangle(0, 0, BitmapStore.GetWidth(this.game.PRODPP), BitmapStore.Getheight(this.game.PRODPP));
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(815, 5, 135, 100);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          }
          else if (this.game.Data.ItemTypeObj[this.detailnr].IsSupply & this.game.Data.ItemTypeObj[this.detailnr].UseSFType == -1)
          {
            ref Graphics local3 = ref Expression;
            bitmap = BitmapStore.GetBitmap(this.game.PRODSUPPLY);
            ref Bitmap local4 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(this.game.PRODSUPPLY), BitmapStore.Getheight(this.game.PRODSUPPLY));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(815, 5, 135, 100);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
          }
          else if (this.game.Data.ItemTypeObj[this.detailnr].IsSFType > -1 | this.game.Data.ItemTypeObj[this.detailnr].UseSFType > -1)
          {
            if (this.game.Data.ItemTypeObj[this.detailnr].UseSFType == -1)
            {
              if (regime > -1)
              {
                if (this.game.Data.RegimeObj[regime].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraCounter > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraCounter;
                  for (int index29 = 0; index29 <= extraCounter; ++index29)
                  {
                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraCode[index29] == this.game.Data.RegimeObj[regime].ExtraGraphicUse)
                    {
                      nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraPicSpriteID[index29];
                      nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraSidewaysSpriteID[index29];
                      index28 = this.game.Data.ItemTypeObj[this.detailnr].IsSFType;
                    }
                  }
                }
                else if (this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraCounter > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraCounter;
                  for (int index30 = 0; index30 <= extraCounter; ++index30)
                  {
                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraCode[index30] == this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse)
                    {
                      nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraPicSpriteID[index30];
                      nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].ExtraSidewaysSpriteID[index30];
                      index28 = this.game.Data.ItemTypeObj[this.detailnr].IsSFType;
                    }
                  }
                }
                else
                {
                  nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].PicSpriteID;
                  nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].SidewaysSpriteID;
                  index28 = this.game.Data.ItemTypeObj[this.detailnr].IsSFType;
                }
              }
              else
              {
                nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].PicSpriteID;
                nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].IsSFType].SidewaysSpriteID;
                index28 = this.game.Data.ItemTypeObj[this.detailnr].IsSFType;
              }
            }
            else if (regime > -1)
            {
              if (this.game.Data.ItemTypeObj[this.detailnr].UseSFType > -1)
              {
                if (this.game.Data.RegimeObj[regime].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraCounter > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraCounter;
                  for (int index31 = 0; index31 <= extraCounter; ++index31)
                  {
                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraCode[index31] == this.game.Data.RegimeObj[regime].ExtraGraphicUse)
                    {
                      nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraPicSpriteID[index31];
                      nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraSidewaysSpriteID[index31];
                      index28 = this.game.Data.ItemTypeObj[this.detailnr].UseSFType;
                      num8 = 1;
                    }
                  }
                }
                else if (this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraCounter > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraCounter;
                  for (int index32 = 0; index32 <= extraCounter; ++index32)
                  {
                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraCode[index32] == this.game.Data.PeopleObj[this.game.Data.LocObj[this.LocNr].People].ExtraGraphicUse)
                    {
                      nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraPicSpriteID[index32];
                      nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].ExtraSidewaysSpriteID[index32];
                      index28 = this.game.Data.ItemTypeObj[this.detailnr].UseSFType;
                      num8 = 1;
                    }
                  }
                }
                else if (this.game.Data.ItemTypeObj[this.detailnr].UseSFType > -1)
                {
                  nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].PicSpriteID;
                  nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].SidewaysSpriteID;
                  index28 = this.game.Data.ItemTypeObj[this.detailnr].UseSFType;
                  num8 = 1;
                }
              }
              else
              {
                nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].PicSpriteID;
                nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].SidewaysSpriteID;
                index28 = this.game.Data.ItemTypeObj[this.detailnr].UseSFType;
                num8 = 1;
              }
            }
            else
            {
              nr1 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].PicSpriteID;
              nr2 = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.detailnr].UseSFType].SidewaysSpriteID;
              index28 = this.game.Data.ItemTypeObj[this.detailnr].UseSFType;
              num8 = 1;
            }
          }
          ref Graphics local5 = ref Expression;
          rectangle2 = new Rectangle(815, 110, 136, 14);
          Rectangle rect1 = rectangle2;
          rectangle1 = new Rectangle(815, 124, 136, 23);
          Rectangle rect2 = rectangle1;
          string name = this.game.Data.ItemTypeObj[this.detailnr].Name;
          DrawMod.MakeFullBoxVic2(ref local5, rect1, "ITEM TYPE", rect2, name);
          int x1;
          int y1;
          int width1;
          int height;
          int index33;
          int index34;
          if (nr1 > -1)
          {
            int index35 = this.game.Data.Turn;
            if (index35 == -1)
            {
              index35 = this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[this.LocNr].X, this.game.Data.LocObj[this.LocNr].Y].Regime;
              if (this.game.Data.RegimeCounter == -1)
                return;
              if (index35 == -1)
                index35 = 0;
            }
            int red = this.game.Data.RegimeObj[index35].Red;
            int green = this.game.Data.RegimeObj[index35].Green;
            int blue = this.game.Data.RegimeObj[index35].Blue;
            int baseColor = this.game.Data.SFTypeObj[index28].BaseColor;
            x1 = 815;
            y1 = 5;
            width1 = 135;
            height = 100;
            if ((double) this.game.Data.RuleVar[869] >= 1.0 & num8 == 0)
            {
              index33 = (int) Math.Round((double) this.game.Data.RuleVar[873]);
              index34 = 0;
              if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[index28].Theater == 2)
              {
                index33 = (int) Math.Round((double) this.game.Data.RuleVar[848]);
                index34 = 0;
              }
              if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[index28].Theater == 1)
              {
                index33 = (int) Math.Round((double) this.game.Data.RuleVar[872]);
                index34 = 0;
              }
              if ((double) this.game.Data.RuleVar[869] == 3.0)
              {
                int nr3 = this.game.Data.LandscapeTypeObj[index33].BasicPicID[index34];
                ref Graphics local6 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr3);
                ref Bitmap local7 = ref bitmap;
                rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr3));
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(x1, y1, width1, height);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local6, ref local7, srcrect, destrect);
              }
              else
              {
                if ((double) this.game.Data.RuleVar[869] == 1.0)
                {
                  int nr4 = this.game.Data.LandscapeTypeObj[index33].SidewaysSPriteID1[index34];
                  ref Graphics local8 = ref Expression;
                  bitmap = BitmapStore.GetBitmap(nr4);
                  ref Bitmap local9 = ref bitmap;
                  rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr4));
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(x1, y1, width1, height);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local8, ref local9, srcrect, destrect);
                }
                int nr5 = this.game.Data.LandscapeTypeObj[index33].SidewaysSPriteID2[index34];
                ref Graphics local10 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr5);
                ref Bitmap local11 = ref bitmap;
                rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr5));
                Rectangle srcrect1 = rectangle2;
                rectangle1 = new Rectangle(x1, y1, width1, height);
                Rectangle destrect1 = rectangle1;
                DrawMod.DrawSimplePart2(ref local10, ref local11, srcrect1, destrect1);
              }
            }
            switch (baseColor)
            {
              case 0:
                ref Graphics local12 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local13 = ref bitmap;
                int x2 = x1;
                int y2 = y1;
                int w1 = width1;
                int h1 = height;
                DrawMod.DrawScaled(ref local12, ref local13, x2, y2, w1, h1);
                break;
              case 1:
                ref Graphics local14 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local15 = ref bitmap;
                int x3 = x1;
                int y3 = y1;
                int w2 = width1;
                int h2 = height;
                int width2 = BitmapStore.GetWidth(nr1);
                int origh1 = BitmapStore.Getheight(nr1);
                double r1 = (double) ((float) red / 256f);
                double g1 = (double) ((float) green / 256f);
                double b1 = (double) ((float) blue / 256f);
                DrawMod.DrawScaledColorized2(ref local14, ref local15, x3, y3, w2, h2, width2, origh1, (float) r1, (float) g1, (float) b1, 1f);
                break;
              case 2:
                int red2 = this.game.Data.RegimeObj[index35].Red2;
                int green2 = this.game.Data.RegimeObj[index35].Green2;
                int blue2 = this.game.Data.RegimeObj[index35].Blue2;
                ref Graphics local16 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local17 = ref bitmap;
                int x4 = x1;
                int y4 = y1;
                int w3 = width1;
                int h3 = height;
                int width3 = BitmapStore.GetWidth(nr1);
                int origh2 = BitmapStore.Getheight(nr1);
                double r2 = (double) ((float) red2 / 256f);
                double g2 = (double) ((float) green2 / 256f);
                double b2 = (double) ((float) blue2 / 256f);
                DrawMod.DrawScaledColorized2(ref local16, ref local17, x4, y4, w3, h3, width3, origh2, (float) r2, (float) g2, (float) b2, 1f);
                break;
              case 3:
                int red3 = this.game.Data.RegimeObj[index35].Red3;
                int green3 = this.game.Data.RegimeObj[index35].Green3;
                int blue3 = this.game.Data.RegimeObj[index35].Blue3;
                ref Graphics local18 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local19 = ref bitmap;
                int x5 = x1;
                int y5 = y1;
                int w4 = width1;
                int h4 = height;
                int width4 = BitmapStore.GetWidth(nr1);
                int origh3 = BitmapStore.Getheight(nr1);
                double r3 = (double) ((float) red3 / 256f);
                double g3 = (double) ((float) green3 / 256f);
                double b3 = (double) ((float) blue3 / 256f);
                DrawMod.DrawScaledColorized2(ref local18, ref local19, x5, y5, w4, h4, width4, origh3, (float) r3, (float) g3, (float) b3, 1f);
                break;
              case 4:
                int red4 = this.game.Data.RegimeObj[index35].Red4;
                int green4 = this.game.Data.RegimeObj[index35].Green4;
                int blue4 = this.game.Data.RegimeObj[index35].Blue4;
                ref Graphics local20 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local21 = ref bitmap;
                int x6 = x1;
                int y6 = y1;
                int w5 = width1;
                int h5 = height;
                int width5 = BitmapStore.GetWidth(nr1);
                int origh4 = BitmapStore.Getheight(nr1);
                double r4 = (double) ((float) red4 / 256f);
                double g4 = (double) ((float) green4 / 256f);
                double b4 = (double) ((float) blue4 / 256f);
                DrawMod.DrawScaledColorized2(ref local20, ref local21, x6, y6, w5, h5, width5, origh4, (float) r4, (float) g4, (float) b4, 1f);
                break;
              case 5:
                ref Graphics local22 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local23 = ref bitmap;
                int x7 = x1;
                int y7 = y1;
                int w6 = width1;
                int h6 = height;
                int width6 = BitmapStore.GetWidth(nr1);
                int origh5 = BitmapStore.Getheight(nr1);
                double r5 = (double) ((float) (red + 392) / 1024f);
                double g5 = (double) ((float) (green + 392) / 1024f);
                double b5 = (double) ((float) (blue + 392) / 1024f);
                DrawMod.DrawScaledColorized2(ref local22, ref local23, x7, y7, w6, h6, width6, origh5, (float) r5, (float) g5, (float) b5, 1f);
                break;
              case 6:
                ref Graphics local24 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr1);
                ref Bitmap local25 = ref bitmap;
                int x8 = x1;
                int y8 = y1;
                int w7 = width1;
                int h7 = height;
                int width7 = BitmapStore.GetWidth(nr1);
                int origh6 = BitmapStore.Getheight(nr1);
                double r6 = (double) ((float) (red + 80) / 512f);
                double g6 = (double) ((float) (green + 200) / 512f);
                double b6 = (double) ((float) (blue + 80) / 512f);
                DrawMod.DrawScaledColorized2(ref local24, ref local25, x8, y8, w7, h7, width7, origh6, (float) r6, (float) g6, (float) b6, 1f);
                break;
            }
          }
          if (nr2 > -1 && (double) this.game.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(nr2)))
          {
            ref Graphics local26 = ref Expression;
            bitmap = BitmapStore.GetBitmap(nr2);
            ref Bitmap local27 = ref bitmap;
            int x9 = x1;
            int y9 = y1;
            int w = width1;
            int h = height;
            DrawMod.DrawScaled(ref local26, ref local27, x9, y9, w, h);
          }
          if ((double) this.game.Data.RuleVar[869] >= 1.0 & (double) this.game.Data.RuleVar[869] < 3.0)
          {
            int nr6 = this.game.Data.LandscapeTypeObj[index33].SidewaysSPriteID3[index34];
            ref Graphics local28 = ref Expression;
            bitmap = BitmapStore.GetBitmap(nr6);
            ref Bitmap local29 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr6));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1, y1, 192, 144);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local28, ref local29, srcrect, destrect);
          }
          int num9 = -1;
          int index36 = 0;
          do
          {
            if (this.game.Data.ItemTypeObj[this.detailnr].RegimeSlotsCost[index36] > -1)
            {
              ++num9;
              string tstring = Strings.Trim(Conversion.Str((object) this.game.Data.ItemTypeObj[this.detailnr].RegimeSlotsCostQty[index36])) + "x " + this.game.Data.RegimeSlotName[this.game.Data.ItemTypeObj[this.detailnr].RegimeSlotsCost[index36]];
              int num10 = 90 - num9 * 15;
              DrawMod.DrawBlock(ref Expression, 815, num10, 135, 15, 0, 0, 0, 125);
              DrawMod.DrawTextVic2(ref Expression, tstring, this.game.VicFont2, 820, num10, this.game.VicColor2, this.game.VicColor2Shade);
            }
            ++index36;
          }
          while (index36 <= 4);
        }
      }
      if (regime > -1)
      {
        Color.FromArgb((int) byte.MaxValue, 180, 200, 240);
        Color.FromArgb((int) byte.MaxValue, 120, 120, 160);
        Color.FromArgb((int) byte.MaxValue, 200, 200, 200);
        Color.FromArgb((int) byte.MaxValue, 130, 130, 130);
        Color white = Color.White;
        Color black = Color.Black;
        Font font = new Font("Arial", 13f, FontStyle.Bold, GraphicsUnit.Pixel);
        if (this.game.Data.Round > 0)
        {
          tsubpart = (SubPartClass) new TextButtonPartClass(!this.game.EditObj.ProdFlap ? "See Production Overview" : "Close Production Overview", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 355, bby: 162);
          this.FlapBall = this.AddSubPart(ref tsubpart, 355, 162, 200, 35, 1);
          if (!this.game.Data.LocTypeObj[this.game.Data.LocObj[this.LocNr].Type].NoHQ)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("Select HQ", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 585, bby: 162);
            this.HqBall = this.AddSubPart(ref tsubpart, 585, 162, 100, 35, 1);
          }
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_60:
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.B2Id)
            {
              if (this.detailnr > -1)
              {
                if (this.game.Data.LocObj[this.LocNr].ProdPointRemainder[this.slotty] > 0 && Interaction.MsgBox((object) "Are you sure you want to change production? You will lose left over production currently stored.", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
                  return windowReturnClass;
                this.game.Data.LocObj[this.LocNr].Production[this.slotty] = this.detailnr;
                this.game.Data.LocObj[this.LocNr].ProdPointRemainder[this.slotty] = 0;
                this.detailnr = this.game.Data.LocObj[this.LocNr].Production[this.slotty];
                this.detailnr2 = this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[this.slotty]].ItemGroup;
                windowReturnClass.AddCommand(4, 44);
                if (this.game.EditObj.ProdFlap)
                  windowReturnClass.AddCommand(4, 52);
                this.FixProdPercent2(this.slotty);
                this.game.ProcessingObj.LocationProductionPrognosis();
                if (!this.game.EditObj.ProdFlap)
                  windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 66);
                windowReturnClass.AddCommand(4, 29);
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.FlapBall)
            {
              if (!this.game.EditObj.ProdFlap)
              {
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 3);
                windowReturnClass.AddCommand(2, 52);
                windowReturnClass.AddCommand(1, 66);
                windowReturnClass.AddCommand(2, 66);
                windowReturnClass.AddCommand(4, 29);
                this.game.EditObj.ProdFlap = true;
              }
              else
              {
                windowReturnClass.AddCommand(1, 3);
                windowReturnClass.AddCommand(2, 18);
                windowReturnClass.AddCommand(2, 12);
                windowReturnClass.AddCommand(1, 66);
                windowReturnClass.AddCommand(2, 66);
                windowReturnClass.AddCommand(4, 29);
                this.game.EditObj.ProdFlap = false;
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.HqBall)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 33, this.LocNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Qball)
            {
              this.game.EditObj.TempProdList1 = this.detailnr;
              this.game.EditObj.TempProdList2 = this.detailnr2;
              this.game.EditObj.TempProdList3 = this.slotty;
              this.game.EditObj.SFTypeSelected = this.game.Data.ItemTypeObj[this.detailnr].IsSFType;
              this.game.EditObj.SFSelected = -1;
              this.game.EditObj.PopupValue = 6;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
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
            if (num1 == this.OptionsList2Id)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.detailnr2 = num3;
                this.dostuff();
              }
              if (num3 == -2)
              {
                this.detailnr2 = -1;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.LocNr].Type].AutoProd == -1)
            {
              int index2 = 0;
label_36:
              int num4 = this.SubPartID[index1];
              if (num4 == this.SlotButId[index2])
              {
                this.slotty = index2;
                if (this.game.Data.LocObj[this.LocNr].Production[this.slotty] > -1)
                {
                  this.detailnr = this.game.Data.LocObj[this.LocNr].Production[this.slotty];
                  this.detailnr2 = this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[this.slotty]].ItemGroup;
                }
                this.dostuff();
                if (this.game.EditObj.ProdFlap)
                  windowReturnClass.AddCommand(4, 52);
                windowReturnClass.AddCommand(4, 66);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num4 == this.PercentX[index2] && Interaction.MsgBox((object) "Are you sure to delete this slot? You'll lose all remaining production stored in this slot.", MsgBoxStyle.YesNo, (object) "Check") == MsgBoxResult.Yes)
              {
                this.game.Data.LocObj[this.LocNr].ProdPercent[index2] = 0;
                this.game.Data.LocObj[this.LocNr].Production[index2] = -1;
                this.game.Data.LocObj[this.LocNr].ProdPointRemainder[index2] = 0;
                this.slotty = index2;
                this.detailnr = -1;
                this.detailnr2 = -1;
                this.game.ProcessingObj.LocationProductionPrognosis();
                this.dostuff();
                if (!this.game.EditObj.ProdFlap)
                  windowReturnClass.AddCommand(4, 18);
                windowReturnClass.SetFlag(true);
                if (this.game.EditObj.ProdFlap)
                  windowReturnClass.AddCommand(4, 52);
                windowReturnClass.AddCommand(4, 66);
                return windowReturnClass;
              }
              int index3 = 0;
              while (this.PercentBut[index2, index3] != this.SubPartID[index1])
              {
                ++index3;
                if (index3 > 10)
                {
                  ++index2;
                  if (index2 <= 3)
                    goto label_36;
                  else
                    goto label_60;
                }
              }
              if (this.totpercent + this.game.Data.LocObj[this.LocNr].ProdPercent[index2] >= index3 * 10)
              {
                this.game.Data.LocObj[this.LocNr].ProdPercent[index2] = index3 * 10;
                this.slotty = index2;
                this.detailnr = this.game.Data.LocObj[this.LocNr].Production[index2];
                this.detailnr2 = this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[index2]].ItemGroup;
              }
              this.game.ProcessingObj.LocationProductionPrognosis();
              this.dostuff();
              if (!this.game.EditObj.ProdFlap)
                windowReturnClass.AddCommand(4, 18);
              if (this.game.EditObj.ProdFlap)
                windowReturnClass.AddCommand(4, 52);
              windowReturnClass.AddCommand(4, 66);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
        if (x < 330 && y < 176)
        {
          this.slotty = (int) Math.Round(Conversion.Int((double) y / 44.0));
          if (this.slotty > 3)
            this.slotty = 3;
          if (this.game.Data.LocObj[this.LocNr].Production[this.slotty] > -1)
          {
            this.detailnr = this.game.Data.LocObj[this.LocNr].Production[this.slotty];
            this.detailnr2 = this.game.Data.ItemTypeObj[this.game.Data.LocObj[this.LocNr].Production[this.slotty]].ItemGroup;
          }
          this.dostuff();
          if (this.game.EditObj.ProdFlap)
            windowReturnClass.AddCommand(4, 52);
          windowReturnClass.AddCommand(4, 66);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public void FixProdPercent(int tempslotty)
    {
      int[] numArray1 = new int[4];
      int[] numArray2 = new int[4];
      int num1 = 0;
      int index1 = 0;
      do
      {
        numArray1[index1] = this.game.Data.LocObj[this.LocNr].ProdPercent[index1];
        num1 += numArray1[index1];
        ++index1;
      }
      while (index1 <= 3);
      if (num1 <= 100)
        return;
      int index2 = -1;
      while (num1 > 100)
      {
        ++index2;
        if (index2 > 3)
          index2 = 0;
        if (index2 != tempslotty && this.game.Data.LocObj[this.LocNr].Production[index2] > -1 && this.game.Data.LocObj[this.LocNr].ProdPercent[index2] > 0)
        {
          int[] prodPercent = this.game.Data.LocObj[this.LocNr].ProdPercent;
          int[] numArray3 = prodPercent;
          int index3 = index2;
          int index4 = index3;
          int num2 = prodPercent[index3] - 1;
          numArray3[index4] = num2;
          --num1;
        }
      }
    }

    public void FixProdPercent2(int tempslotty)
    {
      int[] numArray1 = new int[4];
      int[] numArray2 = new int[4];
      int num = 0;
      int index = 0;
      do
      {
        numArray1[index] = this.game.Data.LocObj[this.LocNr].ProdPercent[index];
        num += numArray1[index];
        ++index;
      }
      while (index <= 3);
      if (num >= 100)
        return;
      this.game.Data.LocObj[this.LocNr].ProdPercent[tempslotty] = 100 - num;
    }
  }
}
