// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TransferWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TransferWindowClass : WindowClass
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
    private int x1id;
    private int x2id;
    private int SwitchId;
    private int Type1Id;
    private int Type2Id;
    private int Type3Id;
    private int text4id;
    private int text5id;
    private int text6id;
    private int text7id;
    private int text8id;
    private int text9id;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Pic1Id;
    private int Pic2Id;
    private int detailnr;
    private int detailtype;
    private int OrderTextId;
    private int OrderText2Id;
    private int OrderUpId;
    private int OrderDownId;
    private int ExtraId;
    private int OptionsListId;
    private ATListClass OptionsListObj;
    private int OptionsList2Id;
    private ATListClass OptionsList2Obj;
    private int OrderOKId;
    private int OrderOKTextId;
    private int OrderALLId;
    private int OrderALLTextId;
    private int YesId;
    private int sliderID;
    private int CapTheater;
    private int TempNew;
    private object LandCost;
    private object NavyCost;
    private object AirCost;
    private int RemLandCost;
    private int RemNavyCost;
    private int RemAirCost;
    private int unr;
    private int unrT;
    private int hq;
    private int nothq;
    private int overrulehq;
    private int OwnPowerTransfer;
    private MapMatrix2[] templand;
    private MapMatrix2[] tempnavy;
    private MapMatrix2[] tempair;
    private int seltheater;
    private int tempSfType;
    private bool AirCarrier;
    private bool HasAirCarrier;

    public TransferWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.templand = new MapMatrix2[1];
      this.tempnavy = new MapMatrix2[1];
      this.tempair = new MapMatrix2[1];
      this.detailnr = -1;
      this.detailtype = 1;
      this.fixshade = true;
      this.DoNewStuff();
      this.overrulehq = -1;
      this.dostuff();
    }

    public void DoNewStuff()
    {
      this.templand = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.tempnavy = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.tempair = new MapMatrix2[this.game.Data.MapCounter + 1];
      int mapCounter1 = this.game.Data.MapCounter;
      for (int index = 0; index <= mapCounter1; ++index)
      {
        this.templand[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.tempnavy[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.tempair[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
      }
      this.unr = this.game.EditObj.OrderUnit;
      this.unrT = this.game.EditObj.OrderTarget;
      if (this.game.Data.UnitObj[this.unr].SFCount > -1)
        this.detailnr = this.game.Data.UnitObj[this.unr].SFList[0];
      if (this.unrT > -1)
      {
        if (this.game.Data.UnitObj[this.unr].IsHQ & !this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unr;
        if (!this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unrT;
        if (this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unr;
      }
      else
        this.hq = -1;
      DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map);
      if (this.unrT > -1)
        this.LandCost = (object) this.game.EditObj.TempValue[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map].Value[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y];
      int mapCounter2 = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter2; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
            this.templand[index1].Value[index2, index3] = this.game.EditObj.TempValue[index1].Value[index2, index3];
        }
      }
      DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, false, muststartonairfield: false, SeaBlock: true);
      if (this.unrT > -1)
        this.NavyCost = (object) this.game.EditObj.TempValue[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map].Value[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y];
      int mapCounter3 = this.game.Data.MapCounter;
      for (int index4 = 0; index4 <= mapCounter3; ++index4)
      {
        int mapWidth = this.game.Data.MapObj[index4].MapWidth;
        for (int index5 = 0; index5 <= mapWidth; ++index5)
        {
          int mapHeight = this.game.Data.MapObj[index4].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
            this.tempnavy[index4].Value[index5, index6] = this.game.EditObj.TempValue[index4].Value[index5, index6];
        }
      }
      if ((double) this.game.Data.RuleVar[509] == 0.0)
      {
        if ((double) this.game.Data.RuleVar[2] > -1.0)
        {
          DrawMod.TGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map);
          if (this.unrT > -1)
            this.AirCost = (object) this.game.EditObj.TempValue[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map].Value[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y];
          int mapCounter4 = this.game.Data.MapCounter;
          for (int index7 = 0; index7 <= mapCounter4; ++index7)
          {
            int mapWidth = this.game.Data.MapObj[index7].MapWidth;
            for (int index8 = 0; index8 <= mapWidth; ++index8)
            {
              int mapHeight = this.game.Data.MapObj[index7].MapHeight;
              for (int index9 = 0; index9 <= mapHeight; ++index9)
                this.tempair[index7].Value[index8, index9] = this.game.EditObj.TempValue[index7].Value[index8, index9];
            }
          }
        }
        else
          this.AirCost = (object) 9999;
      }
      this.CapTheater = 0;
      this.TempNew = 1;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(this.LandCost, (object) 9999, false), Operators.CompareObjectLess(this.NavyCost, (object) 9999, false))))
        this.CapTheater = 1;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectGreaterEqual(this.LandCost, (object) 9999, false), Operators.CompareObjectGreaterEqual(this.NavyCost, (object) 9999, false)), Operators.CompareObjectLess(this.AirCost, (object) 9999, false)), (object) ((double) this.game.Data.RuleVar[509] == 0.0))))
        this.CapTheater = 2;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(this.AirCost, (object) 9999, false), (object) ((double) this.game.Data.RuleVar[509] == 0.0))))
        this.CapTheater = 2;
      if (this.hq > -1 && this.game.Data.UnitObj[this.hq].AirCap <= 1 & this.CapTheater == 2)
        this.CapTheater = this.game.Data.UnitObj[this.hq].LandCap <= this.game.Data.UnitObj[this.hq].NavyCap ? 1 : 0;
      this.SetTempValue();
      this.RemLandCost = Conversions.ToInteger(this.LandCost);
      this.RemAirCost = Conversions.ToInteger(this.AirCost);
      this.RemNavyCost = Conversions.ToInteger(this.NavyCost);
    }

    public void SetTempValue()
    {
      int mapCounter = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (this.CapTheater == 0)
              this.game.EditObj.TempValue[index1].Value[index2, index3] = this.templand[index1].Value[index2, index3];
            if (this.CapTheater == 1)
              this.game.EditObj.TempValue[index1].Value[index2, index3] = this.tempnavy[index1].Value[index2, index3];
            if (this.CapTheater == 2)
              this.game.EditObj.TempValue[index1].Value[index2, index3] = this.tempair[index1].Value[index2, index3];
          }
        }
      }
    }

    public override void DoRefresh()
    {
      bool flag = false;
      this.detailtype = 1;
      this.overrulehq = -1;
      this.unr = this.game.EditObj.OrderUnit;
      this.unrT = this.game.EditObj.OrderTarget;
      if (this.unrT > -1)
      {
        if (this.game.Data.UnitObj[this.unr].IsHQ & !this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unr;
        if (!this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unrT;
        if (this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
        {
          this.hq = this.unr;
          flag = true;
        }
      }
      else
        this.hq = -1;
      if (this.overrulehq > -1 & flag)
        this.hq = this.overrulehq;
      if (this.unrT > -1)
      {
        this.LandCost = (object) this.templand[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map].Value[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y];
        this.NavyCost = (object) this.tempnavy[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map].Value[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y];
        if ((double) this.game.Data.RuleVar[509] == 0.0)
          this.AirCost = (double) this.game.Data.RuleVar[2] <= -1.0 ? (object) 9999 : (object) this.tempair[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Map].Value[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y];
      }
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(this.LandCost, (object) 9999, false), Operators.CompareObjectLess(this.NavyCost, (object) 9999, false))))
        this.CapTheater = 1;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectGreaterEqual(this.LandCost, (object) 9999, false), Operators.CompareObjectGreaterEqual(this.NavyCost, (object) 9999, false)), Operators.CompareObjectLess(this.AirCost, (object) 9999, false)), (object) ((double) this.game.Data.RuleVar[509] == 0.0))))
        this.CapTheater = 2;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(this.AirCost, (object) 9999, false), (object) ((double) this.game.Data.RuleVar[509] == 0.0))))
        this.CapTheater = 2;
      if (this.hq > -1 && this.game.Data.UnitObj[this.hq].AirCap <= 1 & this.CapTheater == 2)
        this.CapTheater = this.game.Data.UnitObj[this.hq].LandCap <= this.game.Data.UnitObj[this.hq].NavyCap ? 1 : 0;
      if (this.sliderID > 0)
      {
        this.RemoveSubPart(this.sliderID);
        this.sliderID = 0;
      }
      this.TempNew = 1;
      this.SetTempValue();
      this.RemLandCost = Conversions.ToInteger(this.LandCost);
      this.RemAirCost = Conversions.ToInteger(this.AirCost);
      this.RemNavyCost = Conversions.ToInteger(this.NavyCost);
      this.dostuff();
    }

    private void dostuff()
    {
      if (this.x1id > 0)
        this.RemoveSubPart(this.x1id);
      if (this.x2id > 0)
        this.RemoveSubPart(this.x2id);
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
      if (this.text7id > 0)
        this.RemoveSubPart(this.text7id);
      if (this.text8id > 0)
        this.RemoveSubPart(this.text8id);
      if (this.text9id > 0)
        this.RemoveSubPart(this.text9id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
      if (this.Pic2Id > 0)
        this.RemoveSubPart(this.Pic2Id);
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
      if (this.OrderOKId > 0)
        this.RemoveSubPart(this.OrderOKId);
      if (this.OrderOKTextId > 0)
        this.RemoveSubPart(this.OrderOKTextId);
      if (this.OrderALLId > 0)
        this.RemoveSubPart(this.OrderALLId);
      if (this.OrderALLTextId > 0)
        this.RemoveSubPart(this.OrderALLTextId);
      if (this.Type1Id > 0)
        this.RemoveSubPart(this.Type1Id);
      if (this.Type2Id > 0)
        this.RemoveSubPart(this.Type2Id);
      if (this.Type3Id > 0)
        this.RemoveSubPart(this.Type3Id);
      if (this.YesId > 0)
        this.RemoveSubPart(this.YesId);
      if (this.SwitchId > 0)
        this.RemoveSubPart(this.SwitchId);
      this.LandCost = (object) this.RemLandCost;
      this.NavyCost = (object) this.RemNavyCost;
      this.AirCost = (object) this.RemAirCost;
      this.NewBackGroundAndClearAll(1024, 200, -1);
      this.seltheater = 0;
      this.OwnPowerTransfer = 0;
      this.unr = this.game.EditObj.OrderUnit;
      this.unrT = this.game.EditObj.OrderTarget;
      int redux = 0;
      bool flag1 = false;
      this.hq = -1;
      if (this.unrT > -1)
      {
        if (this.game.Data.UnitObj[this.unr].IsHQ & !this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unr;
        if (!this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
          this.hq = this.unrT;
        if (this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
        {
          this.hq = this.unr;
          flag1 = true;
        }
      }
      else
        this.hq = -1;
      if (flag1 & this.overrulehq == -1)
        this.overrulehq = this.hq;
      if (this.overrulehq > -1 & flag1)
        this.hq = this.overrulehq;
      bool flag2 = true;
      if (this.game.EditObj.TransferLostQty > 0)
      {
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
        Graphics.FromImage((Image) this.OwnBitmap);
        string str;
        if (this.game.EditObj.TransferLostType > 0)
          str = this.game.Data.SFTypeObj[this.game.EditObj.TransferLostType].Name;
        if (this.game.EditObj.TransferLostType == -2)
          str = "Supplies";
        string txt;
        if (this.game.EditObj.TransferLostTransports > 0)
          txt = "Lost " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TransferLostQty)) + " " + str + " and " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TransferLostTransports)) + " transport troops due to enemy Anti-Cap.";
        else
          txt = "Lost " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TransferLostQty)) + " " + str + " due to enemy Air/Navy.";
        SubPartClass tsubpart1 = (SubPartClass) new ATTextPartClass(txt, this.game.VicFont1, 600, 20, true);
        this.Text1Id = this.AddSubPart(ref tsubpart1, 0, 70, 600, 20, 0);
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.OKBALL, tDescript: "Click to continue");
        this.YesId = this.AddSubPart(ref tsubpart2, 284, 130, 35, 35, 1);
        this.game.EditObj.TransferLostQty = 0;
      }
      else
      {
        Graphics.FromImage((Image) this.OwnBitmap);
        if (flag2)
        {
          this.OptionsListObj = new ATListClass();
          int tlistselect1 = -1;
          int num1 = 0;
          if (this.unrT > -1)
          {
            int num2 = 0;
            if (this.game.Data.UnitObj[this.unr].IsHQ & this.game.Data.UnitObj[this.unrT].IsHQ)
              num2 = 1;
            if (this.game.Data.UnitObj[this.unr].IsHQ & this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.Data.UnitObj[this.unrT].X, this.game.Data.UnitObj[this.unrT].Y, this.game.Data.UnitObj[this.unrT].Map))
              num2 = 1;
            if (!this.game.Data.UnitObj[this.unrT].IsHQ & !this.game.HandyFunctionsObj.HasUnitNavySF(this.unrT))
              num2 = 0;
            if (num2 == 1 & (double) this.game.Data.RuleVar[322] == 0.0)
            {
              this.OptionsListObj.add(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply) + "x Supply Pts", -2);
              num1 = 1;
              if (this.detailnr == -2)
                tlistselect1 = 0;
            }
          }
          if (this.game.Data.UnitObj[this.unr].SFCount > -1)
          {
            int sfCount = this.game.Data.UnitObj[this.unr].SFCount;
            for (int index = 0; index <= sfCount; ++index)
            {
              int sf = this.game.Data.UnitObj[this.unr].SFList[index];
              if (sf == this.detailnr)
                tlistselect1 = index + num1;
              int type = this.game.Data.SFObj[sf].Type;
              if (sf == this.detailnr)
                this.tempSfType = type;
              this.OptionsListObj.add(Conversion.Str((object) this.game.Data.SFObj[sf].Qty) + "x " + this.game.Data.SFTypeObj[type].Name + "(" + Strings.Left(this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].Name, 3) + ")", sf);
            }
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 5, 220, tlistselect1, this.game, tHeader: this.game.Data.UnitObj[this.unr].Name, tbackbitmap: (ref this.OwnBitmap), bbx: 70, bby: 30);
            this.OptionsListId = this.AddSubPart(ref tsubpart, 70, 30, 220, 128, 0);
          }
          if (tlistselect1 == -1)
            this.detailnr = -1;
          if (this.unrT > -1)
          {
            this.OptionsList2Obj = new ATListClass();
            int tlistselect2 = -1;
            if (this.game.Data.UnitObj[this.unr].IsHQ & (this.game.Data.UnitObj[this.unrT].IsHQ | this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.unrT].X, this.game.Data.UnitObj[this.unrT].Y].LandscapeType].IsSea) && (double) this.game.Data.RuleVar[322] == 0.0)
              this.OptionsList2Obj.add(Conversion.Str((object) this.game.Data.UnitObj[this.unrT].Supply) + "x Supply Pts", -2);
            if (this.game.Data.UnitObj[this.unrT].SFCount > -1)
            {
              int sfCount = this.game.Data.UnitObj[this.unrT].SFCount;
              for (int index = 0; index <= sfCount; ++index)
              {
                int sf = this.game.Data.UnitObj[this.unrT].SFList[index];
                if (sf == this.detailnr)
                  tlistselect2 = index;
                int type = this.game.Data.SFObj[sf].Type;
                if (sf == this.detailnr)
                  this.tempSfType = type;
                this.OptionsList2Obj.add(Conversion.Str((object) this.game.Data.SFObj[sf].Qty) + "x " + this.game.Data.SFTypeObj[type].Name + "(" + Strings.Left(this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].Name, 3) + ")", sf);
              }
            }
            if (this.OptionsList2Id > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect2, this.game.Data.UnitObj[this.unrT].Name);
              this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
            }
            else
            {
              SubPartClass tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsList2Obj, 8, 220, -1, this.game, tHeader: this.game.Data.UnitObj[this.unrT].Name, tbackbitmap: (ref this.OwnBitmap), bbx: 515, bby: 30);
              this.OptionsList2Id = this.AddSubPart(ref tsubpart, 515, 30, 220, 176, 0);
            }
            string txt1;
            if (this.game.HandyFunctionsObj.HasUnitNavySF(this.unrT))
            {
              int unitCarryCap = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 1);
              int Number = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 1) - this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 1, true);
              txt1 = "Naval Carry:" + Strings.Trim(Conversion.Str((object) unitCarryCap)) + " Weight: " + Strings.Trim(Conversion.Str((object) Number));
            }
            else if (this.game.HandyFunctionsObj.HasUnitAirSF(this.unrT))
              txt1 = "Air Carry:" + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 2)));
            else if (this.game.HandyFunctionsObj.HasUnitlandSF(this.unrT))
            {
              int unitCarryCap = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 0);
              int Number = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 0) - this.game.HandyFunctionsObj.GetUnitCarryCap(this.unrT, 0, true);
              txt1 = "Land Carry:" + Strings.Trim(Conversion.Str((object) unitCarryCap)) + " Weight: " + Strings.Trim(Conversion.Str((object) Number));
            }
            else
              txt1 = "";
            SubPartClass tsubpart3 = (SubPartClass) new ATTextPartClass(txt1, this.game.VicFont5, 200, 20, false);
            this.text7id = this.AddSubPart(ref tsubpart3, 300, 170, 200, 20, 0);
            if (this.detailnr > -1)
            {
              string txt2 = "Weight: " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].Weight));
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].StaffPts > 0 & this.game.Data.UnitObj[this.unrT].Historical > -1)
                txt2 = txt2 + ", Max Leader Staff=" + this.game.HandyFunctionsObj.GetMaxStaffIndividuals(this.unrT, -1).ToString();
              SubPartClass tsubpart4 = (SubPartClass) new ATTextPartClass(txt2, this.game.VicFont5, 195, 20, false);
              this.text9id = this.AddSubPart(ref tsubpart4, 300, 185, 195, 20, 0);
            }
          }
        }
        SubPartClass tsubpart5 = (SubPartClass) new ATTextPartClass("FROM", this.game.VicFont2, 55, 20, true, tDescript: "The unit you are transferring from");
        this.Text1Id = this.AddSubPart(ref tsubpart5, 5, 35, 55, 20, 0);
        SubPartClass tsubpart6 = (SubPartClass) new ATTextPartClass("TO", this.game.VicFont2, 55, 20, true, tDescript: "The unit you are transferring too");
        this.Text2Id = this.AddSubPart(ref tsubpart6, 5, 95, 55, 20, 0);
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderUnit), this.game.Data.UnitObj[this.unr].Name);
        this.Pic1Id = this.AddSubPart(ref tsubpart7, 15, 55, 31, 31, 0);
        SubPartClass tsubpart8;
        if (this.unrT > -1)
        {
          tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderTarget), this.game.Data.UnitObj[this.unrT].Name);
          this.Pic2Id = this.AddSubPart(ref tsubpart8, 15, 115, 31, 31, 0);
        }
        if (flag2)
        {
          if (flag1)
          {
            tsubpart8 = (SubPartClass) new ATTextPartClass("CAP BY", this.game.VicFont2, 70, 20, true, tDescript: "The HQ that is providing Cap");
            this.text8id = this.AddSubPart(ref tsubpart8, 80, 167, 70, 20, 0);
            tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.hq), "Cap by " + this.game.Data.UnitObj[this.hq].Name + ". Click to switch HQ that providdes Capacity for transfer.");
            this.SwitchId = this.AddSubPart(ref tsubpart8, 160, 157, 37, 37, 0);
          }
          int Number1;
          if (this.CapTheater == 0)
            Number1 = Conversions.ToInteger(this.LandCost);
          if (this.CapTheater == 1)
            Number1 = Conversions.ToInteger(this.NavyCost);
          if (this.CapTheater == 2)
            Number1 = Conversions.ToInteger(this.AirCost);
          if (this.detailnr > -1 | this.detailnr == -2)
          {
            float weight;
            int moveType;
            int ap;
            if (this.detailnr == -2)
            {
              weight = this.game.Data.RuleVar[33];
              redux = 0;
            }
            else if (this.detailtype == 1)
            {
              weight = (float) this.game.Data.SFTypeObj[this.tempSfType].Weight;
              moveType = this.game.Data.SFTypeObj[this.tempSfType].MoveType;
              ap = this.game.Data.SFObj[this.detailnr].Ap;
              redux = this.game.Data.SFTypeObj[this.tempSfType].MoveRedux;
            }
            int integer1 = Conversions.ToInteger(Conversion.Int(Operators.MultiplyObject(Operators.MultiplyObject(this.LandCost, (object) this.TempNew), (object) weight)));
            int integer2 = Conversions.ToInteger(Conversion.Int(Operators.MultiplyObject(Operators.MultiplyObject(this.NavyCost, (object) this.TempNew), (object) weight)));
            int integer3 = Conversions.ToInteger(Conversion.Int(Operators.MultiplyObject(Operators.MultiplyObject(this.AirCost, (object) this.TempNew), (object) weight)));
            if (this.detailnr != -2 && this.detailtype == 1)
              this.seltheater = this.game.Data.SFTypeObj[this.tempSfType].Theater;
            int Number2;
            int Number3;
            int Number4;
            bool flag3;
            bool flag4;
            bool flag5;
            if (this.hq > -1)
            {
              Number2 = this.game.Data.UnitObj[this.hq].LandCap;
              Number3 = this.game.Data.UnitObj[this.hq].NavyCap;
              Number4 = this.game.Data.UnitObj[this.hq].AirCap;
              if ((double) this.game.Data.RuleVar[852] > 0.0)
              {
                int num3 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[851])];
                int num4 = (int) Math.Round((double) Number2 / 1000.0 * (double) this.game.Data.RuleVar[852]);
                if (1 > num4)
                  num4 = 1;
                if (num4 > num3)
                {
                  Number2 = (int) Math.Round(Conversion.Int((double) Number2 * ((double) num3 / (double) num4)));
                  flag3 = true;
                }
                if (Number2 < 1)
                  Number2 = 0;
              }
              if ((double) this.game.Data.RuleVar[854] > 0.0)
              {
                int num5 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[853])];
                int num6 = (int) Math.Round((double) Number3 / 1000.0 * (double) this.game.Data.RuleVar[854]);
                if (1 > num6)
                  num6 = 1;
                if (num6 > num5)
                {
                  Number3 = (int) Math.Round(Conversion.Int((double) Number3 * ((double) num5 / (double) num6)));
                  flag4 = true;
                }
                if (Number3 < 1)
                  Number3 = 0;
              }
              if ((double) this.game.Data.RuleVar[856] > 0.0)
              {
                int num7 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[855])];
                int num8 = (int) Math.Round((double) Number4 / 1000.0 * (double) this.game.Data.RuleVar[856]);
                if (1 > num8)
                  num8 = 1;
                if (num8 > num7)
                {
                  Number4 = (int) Math.Round(Conversion.Int((double) Number4 * ((double) num7 / (double) num8)));
                  flag5 = true;
                }
                if (Number4 < 1)
                  Number4 = 0;
              }
            }
            int num9 = 0;
            if (this.hq > -1)
            {
              if (this.CapTheater == 0)
                num9 = Number2;
              if (this.CapTheater == 1)
                num9 = Number3;
              if (this.CapTheater == 2)
                num9 = Number4;
            }
            int num10;
            if (this.CapTheater == 0)
              num10 = integer1;
            if (this.CapTheater == 1)
              num10 = integer2;
            if (this.CapTheater == 2)
              num10 = integer3;
            if (this.detailtype == 1 & this.unrT > -1 && this.detailnr != -2)
            {
              this.AirCarrier = false;
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, moveType, this.seltheater, ap, this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, false, muststartonairfield: false, istransfer: true, redux: redux, SFTypeX: this.tempSfType, SFTypeQty: Math.Max(1, this.TempNew));
              if (this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrT].Map].Value[this.game.Data.UnitObj[this.unrT].X, this.game.Data.UnitObj[this.unrT].Y] <= ap)
              {
                int num11 = 0;
                if (this.seltheater == 2)
                {
                  int location = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.unrT].X, this.game.Data.UnitObj[this.unrT].Y].Location;
                  if (location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].IsAirfield)
                    num11 = 1;
                  int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.unrT].X, this.game.Data.UnitObj[this.unrT].Y].LandscapeType;
                  if (this.game.HandyFunctionsObj.GetAirCarryCapPts(this.unrT) > 0)
                  {
                    num11 = 1;
                    this.AirCarrier = true;
                  }
                }
                else
                  num11 = 1;
                if (num11 == 1)
                {
                  this.OwnPowerTransfer = 1;
                  num10 = 0;
                  Number1 = 0;
                }
              }
              else
              {
                if (!this.game.Data.UnitObj[this.unr].IsHQ && this.seltheater == 1)
                  Number1 = 9999;
                if (this.game.HandyFunctionsObj.GetAirCarryCapPts(this.unrT) > 0)
                  this.AirCarrier = true;
              }
              if (this.unrT != this.hq & this.detailnr != -2 && this.game.HandyFunctionsObj.GetUnitSFNr(this.unrT, this.game.Data.SFObj[this.detailnr].Type, this.game.Data.SFObj[this.detailnr].People) == -1)
              {
                if (this.game.Data.UnitObj[this.unrT].SFCount > 6 & !this.game.Data.UnitObj[this.unrT].IsHQ)
                  Number1 = 9999;
                if (!this.game.Data.UnitObj[this.unrT].IsHQ && this.game.Data.UnitObj[this.unrT].SFCount + this.game.Data.UnitObj[this.unrT].PassengerCounter + 1 > 6)
                  Number1 = 9999;
              }
            }
            this.OrderOKId = 0;
            this.OrderALLId = 0;
            string str1 = "";
            string str2 = "";
            if (this.seltheater == 1 & this.OwnPowerTransfer < 1 & this.detailnr > -1 && this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].Theater == 1)
            {
              Number1 = 9999;
              this.NavyCost = (object) 9999;
              this.LandCost = (object) 9999;
              this.AirCost = (object) 9999;
              str1 = "navy can only be transferred under 'own power'";
            }
            if (this.unrT > -1 & this.detailnr > -1 && !this.game.HandyFunctionsObj.CanAddTroops(this.unrT, this.game.Data.SFObj[this.detailnr].Type, this.game.Data.SFObj[this.detailnr].People, this.game.Data.SFObj[this.detailnr].MoveType))
            {
              Number1 = 9999;
              this.NavyCost = (object) 9999;
              this.LandCost = (object) 9999;
              this.AirCost = (object) 9999;
              str1 = "target unit is full. these troops cannot be added";
            }
            if ((double) this.game.Data.RuleVar[801] == 1.0)
            {
              int reinforcementType = this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].ReinforcementType;
              if (this.unrT > -1 && reinforcementType > -1 & this.game.Data.UnitObj[this.unrT].Historical > -1 && this.game.Data.UnitObj[this.unrT].HistoricalSubPart > -1)
              {
                int reinforcementPoints = this.game.HandyFunctionsObj.GetPowerInReinforcementPoints(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.unrT].Historical].SubParts[this.game.Data.UnitObj[this.unrT].HistoricalSubPart]), reinforcementType);
                if (this.game.HandyFunctionsObj.GetPowerInReinforcementPoints(this.unrT, reinforcementType) + this.TempNew > reinforcementPoints)
                  Number1 = 9999;
              }
            }
            if (Operators.CompareString(str1, "", false) == 0 & num9 >= num10 & this.unrT > -1)
            {
              if (this.TempNew >= 1)
              {
                if (Number1 < 9999)
                {
                  if (this.detailnr == -2 & this.unrT > -1)
                  {
                    int num12 = this.game.Data.UnitObj[this.unr].Supply;
                    if (!this.game.Data.UnitObj[this.unrT].IsHQ)
                    {
                      int num13 = this.game.HandyFunctionsObj.UnitSupplyStore(this.unrT) - this.game.Data.UnitObj[this.unrT].Supply;
                      if (0 > num13)
                        num13 = 0;
                      if (num12 > num13)
                        num12 = num13;
                    }
                    if (num12 > 0 & this.game.Data.UnitObj[this.unr].Supply > 0)
                    {
                      tsubpart8 = (SubPartClass) new TextButtonPartClass("Do Transfer", 100, "Click to transfer selected amount", ref this.OwnBitmap, 300, 130);
                      this.OrderOKId = this.AddSubPart(ref tsubpart8, 300, 130, 100, 35, 1);
                    }
                  }
                  else if (!(this.detailnr == -2 & this.game.Data.UnitObj[this.unr].Supply <= 0))
                  {
                    tsubpart8 = (SubPartClass) new TextButtonPartClass("Do Transfer", 100, "Click to transfer selected amount", ref this.OwnBitmap, 300, 130);
                    this.OrderOKId = this.AddSubPart(ref tsubpart8, 300, 130, 100, 35, 1);
                  }
                }
              }
              else
                str1 = "You must select at least 1 individual for transfer";
            }
            if (Operators.CompareString(str1, "", false) != 0 & Number1 >= 9999)
              str1 = "basiccost => 9999, thus not possible";
            if (this.unrT > -1 & this.unr > -1 && this.game.Data.UnitObj[this.unr].SFCount > -1 & Number1 < 9999 && this.game.Data.UnitObj[this.unrT].X == this.game.Data.UnitObj[this.unr].X & this.game.Data.UnitObj[this.unrT].Y == this.game.Data.UnitObj[this.unr].Y)
            {
              int num14 = 1;
              if (this.game.Data.UnitObj[this.unr].PassengerCounter > -1)
              {
                num14 = 0;
                str2 = "You cannot transfer all from a unit with passengers";
              }
              if (!this.game.Data.UnitObj[this.unrT].IsHQ && this.game.Data.UnitObj[this.unr].SFCount + 1 + this.game.Data.UnitObj[this.unrT].SFCount + this.game.Data.UnitObj[this.unrT].PassengerCounter + 1 > 7)
              {
                num14 = 0;
                str2 = "Maximum 8 subformations in target unit.";
              }
              if (num14 == 1)
              {
                tsubpart8 = (SubPartClass) new TextButtonPartClass("Transfer All", 100, "Click to transfer all contents of source unit", ref this.OwnBitmap, 410, 130);
                this.OrderALLId = this.AddSubPart(ref tsubpart8, 410, 130, 100, 35, 1);
              }
            }
            if (Operators.CompareString(str1, "", false) == 0)
              str1 = "not possible";
            if (Operators.CompareString(str2, "", false) == 0)
              str2 = "not possible";
            if (this.OrderOKId == 0)
            {
              tsubpart8 = (SubPartClass) new TextButtonPartClass("Do Transfer", 100, str1, ref this.OwnBitmap, 400, 130, true);
              this.x1id = this.AddSubPart(ref tsubpart8, 300, 130, 100, 35, 1);
            }
            if (this.OrderALLId == 0)
            {
              tsubpart8 = (SubPartClass) new TextButtonPartClass("Transfer All", 100, str2, ref this.OwnBitmap, 410, 130, true);
              this.x2id = this.AddSubPart(ref tsubpart8, 410, 130, 100, 35, 1);
            }
            int num15 = 1;
            int tsmallchange = 1;
            if (this.detailnr == -2)
              tsmallchange = 10;
            if (Number1 == 9999)
              num15 = 0;
            if (num9 < Number1 & this.OwnPowerTransfer == 0)
              num15 = 0;
            if (num15 == 1 & this.unrT > -1)
            {
              if (this.detailnr == -2)
              {
                int tmaxval = this.game.Data.UnitObj[this.unr].Supply;
                if (!this.game.Data.UnitObj[this.unrT].IsHQ)
                {
                  int num16 = this.game.HandyFunctionsObj.UnitSupplyStore(this.unrT) - this.game.Data.UnitObj[this.unrT].Supply;
                  if (0 > num16)
                    num16 = 0;
                  if (tmaxval > num16)
                    tmaxval = num16;
                }
                if (tmaxval > 0 & this.sliderID <= 0)
                {
                  tsubpart8 = (SubPartClass) new NumberSliderSubPartClass2(this.game, "", "x Supply Pts", 205, 0, tmaxval, this.TempNew, tsmallchange: tsmallchange, tbackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 75);
                  this.sliderID = this.AddSubPart(ref tsubpart8, 300, 75, 205, 40, 0);
                }
              }
              else if (this.sliderID <= 0)
              {
                tsubpart8 = (SubPartClass) new NumberSliderSubPartClass2(this.game, "", "x " + this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].Name, 205, 0, this.game.Data.SFObj[this.detailnr].Qty, this.TempNew, tbackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 75);
                this.sliderID = this.AddSubPart(ref tsubpart8, 300, 75, 205, 40, 0);
              }
            }
            string txt3;
            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(this.LandCost, (object) 9999, false), (object) (this.seltheater != 1))))
            {
              txt3 = this.hq <= -1 ? "LandCap = " + Conversion.Str((object) integer1) : "LandCap = " + Conversion.Str((object) integer1) + " / " + Conversion.Str((object) Number2);
              if (flag3)
                txt3 += " (fuel!)";
            }
            else
              txt3 = "No Land Connect";
            if (this.unrT == -1)
              txt3 = "Land";
            if (this.unrT > -1)
            {
              if (this.CapTheater == 0)
              {
                tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tDescript: "Click to use Land Cap for this transfer", tBackbitmap: (ref this.OwnBitmap), bbx: 760, bby: 35);
                this.B4Id = this.AddSubPart(ref tsubpart8, 760, 45, 35, 35, 1);
                tsubpart8 = (SubPartClass) new ATTextPartClass(txt3, this.game.VicFont2, 190, 20, true, tBlackBack: true);
                this.text4id = this.AddSubPart(ref tsubpart8, 800, 55, 190, 20, 0);
              }
              else
              {
                tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tDescript: "Click to use Land Cap for this transfer", tBackbitmap: (ref this.OwnBitmap), bbx: 760, bby: 35);
                this.B4Id = this.AddSubPart(ref tsubpart8, 760, 45, 35, 35, 1);
                tsubpart8 = (SubPartClass) new ATTextPartClass(txt3, this.game.VicFont2, 190, 20, true, tBlackBack: true);
                this.text4id = this.AddSubPart(ref tsubpart8, 800, 55, 190, 20, 0);
              }
            }
            string txt4;
            if (Operators.ConditionalCompareObjectLess(this.NavyCost, (object) 9999, false))
            {
              if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.NavyCost, (object) 0, false), (object) (this.seltheater == 1 & Number1 == 0))))
              {
                txt4 = "Self Transfer";
              }
              else
              {
                txt4 = this.hq <= -1 ? "NavyCap = " + Conversion.Str((object) integer2) : "NavyCap = " + Conversion.Str((object) integer2) + " / " + Conversion.Str((object) Number3);
                if (flag4)
                  txt4 += " (fuel!)";
              }
            }
            else
              txt4 = "No Navy Connect";
            if (this.unrT == -1)
              txt4 = "Navy";
            if (this.unrT > -1)
            {
              if (this.CapTheater == 1)
              {
                tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tDescript: "Click to use Navy Cap for this transfer", tBackbitmap: (ref this.OwnBitmap), bbx: 760, bby: 110);
                this.B5Id = this.AddSubPart(ref tsubpart8, 760, 90, 35, 35, 1);
                tsubpart8 = (SubPartClass) new ATTextPartClass(txt4, this.game.VicFont2, 190, 20, true, tBlackBack: true);
                this.text5id = this.AddSubPart(ref tsubpart8, 800, 100, 190, 20, 0);
              }
              else
              {
                tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tDescript: "Click to use Navy Cap for this transfer", tBackbitmap: (ref this.OwnBitmap), bbx: 760, bby: 110);
                this.B5Id = this.AddSubPart(ref tsubpart8, 760, 90, 35, 35, 1);
                tsubpart8 = (SubPartClass) new ATTextPartClass(txt4, this.game.VicFont2, 190, 20, true, tBlackBack: true);
                this.text5id = this.AddSubPart(ref tsubpart8, 800, 100, 190, 20, 0);
              }
            }
            if ((double) this.game.Data.RuleVar[509] == 0.0)
            {
              string txt5;
              if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(this.AirCost, (object) 9999, false), (object) ((double) this.game.Data.RuleVar[509] == 0.0))))
              {
                txt5 = this.hq <= -1 ? "RailCap = " + Conversion.Str((object) integer3) : "RailCap = " + Conversion.Str((object) integer3) + " / " + Conversion.Str((object) Number4);
                if (flag5)
                  txt5 += " (fuel!)";
              }
              else
                txt5 = "No Rail Connect";
              if (this.unrT == -1)
                txt5 = "Rail";
              if (this.unrT > -1)
              {
                if (this.CapTheater == 2)
                {
                  tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tDescript: "Click to use Rail Cap for this transfer", tBackbitmap: (ref this.OwnBitmap), bbx: 760, bby: 135);
                  this.B6Id = this.AddSubPart(ref tsubpart8, 760, 135, 35, 35, 1);
                  tsubpart8 = (SubPartClass) new ATTextPartClass(txt5, this.game.VicFont2, 190, 20, true, tBlackBack: true);
                  this.text6id = this.AddSubPart(ref tsubpart8, 800, 145, 190, 20, 0);
                }
                else
                {
                  tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tDescript: "Click to use Rail Cap for this transfer", tBackbitmap: (ref this.OwnBitmap), bbx: 760, bby: 135);
                  this.B6Id = this.AddSubPart(ref tsubpart8, 760, 135, 35, 35, 1);
                  tsubpart8 = (SubPartClass) new ATTextPartClass(txt5, this.game.VicFont2, 190, 20, true, tBlackBack: true);
                  this.text6id = this.AddSubPart(ref tsubpart8, 800, 145, 190, 20, 0);
                }
              }
            }
            string txt6 = this.OwnPowerTransfer != 0 ? "Own Power" : (this.hq != -1 ? "Basic Cost = " + Conversion.Str((object) Number1) : "Not enough Ap");
            if (this.unrT > -1)
            {
              tsubpart8 = (SubPartClass) new ATTextPartClass(txt6, this.game.VicFont2, 205, 20, true, tBlackBack: true);
              this.Text3Id = this.AddSubPart(ref tsubpart8, 300, 47, 205, 20, 0);
            }
          }
        }
        if (!flag2)
        {
          tsubpart8 = (SubPartClass) new ATTextPartClass("Target of transfer must be a lower type of HQ.", this.game.VicFont2, 420, 25, false);
          this.OrderOKTextId = this.AddSubPart(ref tsubpart8, 305, 99, 420, 25, 0);
        }
        this.SetTempValue();
      }
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
            if (num1 == this.YesId)
            {
              this.game.EditObj.TransferLostQty = -1;
              this.game.EditObj.TransferLostType = -1;
              this.game.EditObj.TransferLostTransports = -1;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1 | num2 == -2)
              {
                if (this.sliderID > 0)
                {
                  this.RemoveSubPart(this.sliderID);
                  this.sliderID = -1;
                }
                this.detailnr = num2;
                this.TempNew = 1;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList2Id)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              this.CapTheater = 0;
              this.SetTempValue();
              this.dostuff();
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              this.CapTheater = 1;
              this.SetTempValue();
              this.dostuff();
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              this.CapTheater = 2;
              this.SetTempValue();
              this.dostuff();
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Type1Id)
            {
              this.detailtype = 1;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Type2Id)
            {
              this.detailtype = 2;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Type3Id)
            {
              this.detailtype = 3;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.SwitchId)
            {
              this.overrulehq = this.unr != this.overrulehq ? this.unr : this.unrT;
              this.detailnr = -1;
              this.TempNew = 1;
              this.DoNewStuff();
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OrderOKId)
            {
              if (this.detailtype == 1)
              {
                if (this.OwnPowerTransfer == 1)
                {
                  orderResult = (OrderResult) this.game.ProcessingObj.DoTransfer(this.unr, this.unrT, this.CapTheater, this.detailnr, this.TempNew, true);
                }
                else
                {
                  if (this.game.EditObj.SoundOn)
                    SoundMod.PlayAWave(this.game.AppPath + "sound/transfer.wav", ref this.game.EditObj);
                  orderResult = (OrderResult) this.game.ProcessingObj.DoTransfer(this.unr, this.unrT, this.CapTheater, this.detailnr, this.TempNew, byHQ: this.overrulehq);
                }
              }
              windowReturnClass.AddCommand(4, 66);
              if (orderResult.OK)
              {
                this.TempNew = 1;
                if (this.sliderID > 0)
                {
                  this.RemoveSubPart(this.sliderID);
                  this.sliderID = 0;
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              windowReturnClass.SetFlag(false);
              return windowReturnClass;
            }
            if (num1 == this.OrderALLId)
            {
              if (Interaction.MsgBox((object) "Are you sure you want to transfer all subformations?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                for (int sfCount = this.game.Data.UnitObj[this.unr].SFCount; sfCount >= 0; sfCount += -1)
                {
                  int sf = this.game.Data.UnitObj[this.unr].SFList[sfCount];
                  int qty = this.game.Data.SFObj[sf].Qty;
                  orderResult = (OrderResult) this.game.ProcessingObj.DoTransfer(this.unr, this.unrT, 0, sf, qty, true, false);
                }
                if (orderResult.OK)
                {
                  this.TempNew = 1;
                  if (this.sliderID > 0)
                  {
                    this.RemoveSubPart(this.sliderID);
                    this.sliderID = 0;
                  }
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.SetFlag(false);
                return windowReturnClass;
              }
            }
            else if (num1 == this.sliderID)
            {
              int tempNew = this.TempNew;
              this.TempNew = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              if (this.detailnr == -2)
              {
                if (this.TempNew > this.game.Data.UnitObj[this.unr].Supply)
                  this.TempNew = this.game.Data.UnitObj[this.unr].Supply;
              }
              else if (this.TempNew > this.game.Data.SFObj[this.detailnr].Qty)
                this.TempNew = this.game.Data.SFObj[this.detailnr].Qty;
              if (this.detailnr != -2)
              {
                if ((double) this.game.Data.RuleVar[801] == 1.0)
                {
                  int reinforcementType = this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].ReinforcementType;
                  if (reinforcementType > -1 & this.game.Data.UnitObj[this.unrT].Historical > -1 && this.game.Data.UnitObj[this.unrT].HistoricalSubPart > -1)
                  {
                    int reinforcementPoints = this.game.HandyFunctionsObj.GetPowerInReinforcementPoints(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.unrT].Historical].SubParts[this.game.Data.UnitObj[this.unrT].HistoricalSubPart]), reinforcementType);
                    if (this.game.HandyFunctionsObj.GetPowerInReinforcementPoints(this.unrT, reinforcementType) + this.TempNew > reinforcementPoints)
                    {
                      this.TempNew = tempNew;
                      this.game.EditObj.FeedBackString = "Maximum " + Conversion.Str((object) reinforcementPoints) + " is powerpts of " + this.game.Data.ReinfName[reinforcementType];
                      windowReturnClass.AddCommand(4, 29);
                    }
                  }
                }
                if (this.AirCarrier & this.seltheater == 2)
                {
                  if (this.TempNew * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].Weight > this.game.HandyFunctionsObj.GetAirCarryCapPts(this.game.EditObj.OrderTarget) - this.game.HandyFunctionsObj.GetAirCarryCapPtsOccupied(this.game.EditObj.OrderTarget))
                  {
                    this.TempNew = tempNew;
                    this.game.EditObj.FeedBackString = "No more place on aircarrier";
                    windowReturnClass.AddCommand(4, 29);
                  }
                }
                else if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y].LandscapeType].IsSea && this.OwnPowerTransfer == 0)
                {
                  this.TempNew = tempNew;
                  this.game.EditObj.FeedBackString = "Cannot transfer to open sea";
                  windowReturnClass.AddCommand(4, 29);
                }
              }
              this.SubPartFlag[index] = true;
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

    public override WindowReturnClass HandleMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (this.SubPartList[index].Scroller)
          {
            int num = this.SubPartID[index];
            if (num == this.OptionsListId)
              this.SubPartList[index].HandleMouseUp(x - this.SubPartX[index], y - this.SubPartY[index]);
            else if (num == this.OptionsList2Id)
              this.SubPartList[index].HandleMouseUp(x - this.SubPartX[index], y - this.SubPartY[index]);
            else if (num == this.sliderID)
            {
              int tempNew = this.TempNew;
              this.TempNew = this.SubPartList[index].HandleMouseUp(x - this.SubPartX[index], y - this.SubPartY[index]);
              if (this.detailnr == -2)
              {
                if (this.TempNew > this.game.Data.UnitObj[this.unr].Supply)
                  this.TempNew = this.game.Data.UnitObj[this.unr].Supply;
              }
              else if (this.TempNew > this.game.Data.SFObj[this.detailnr].Qty)
                this.TempNew = this.game.Data.SFObj[this.detailnr].Qty;
              if (this.detailnr != -2)
              {
                if (!this.game.HandyFunctionsObj.CanUnitReceiveTransfer(this.game.EditObj.OrderTarget, this.game.Data.SFObj[this.detailnr].Type, this.TempNew, this.game.Data.SFObj[this.detailnr].People))
                {
                  this.TempNew = tempNew;
                  windowReturnClass.AddCommand(4, 29);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (this.AirCarrier & this.seltheater == 2)
                {
                  if (this.TempNew * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.detailnr].Type].Weight > this.game.HandyFunctionsObj.GetAirCarryCapPts(this.game.EditObj.OrderTarget) - this.game.HandyFunctionsObj.GetAirCarryCapPtsOccupied(this.game.EditObj.OrderTarget))
                  {
                    this.TempNew = tempNew;
                    this.game.EditObj.FeedBackString = "No more place on aircarrier";
                    windowReturnClass.AddCommand(4, 29);
                  }
                }
                else if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.game.EditObj.OrderTarget].X, this.game.Data.UnitObj[this.game.EditObj.OrderTarget].Y].LandscapeType].IsSea && this.OwnPowerTransfer == 0)
                {
                  this.TempNew = tempNew;
                  this.game.EditObj.FeedBackString = "Cannot transfer to open sea";
                  windowReturnClass.AddCommand(4, 29);
                }
              }
              this.SubPartFlag[index] = true;
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
