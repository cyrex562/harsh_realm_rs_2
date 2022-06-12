// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OfficerPoolWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class OfficerPoolWindowClass : WindowClass
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
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int detailnr;

    public OfficerPoolWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.LocNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      this.detailnr = -1;
      if (this.game.Data.Round == 0 & this.game.EditObj.UnitSelected > -1)
        this.game.Data.Turn = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
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
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.b1bid > 0)
        this.RemoveSubPart(this.b1bid);
      if (this.b2bid > 0)
        this.RemoveSubPart(this.b2bid);
      if (this.b3bid > 0)
        this.RemoveSubPart(this.b3bid);
      if (this.b4bid > 0)
        this.RemoveSubPart(this.b4bid);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1)
      {
        SubPartClass tsubpart = (SubPartClass) new OfficerPartClass(this.game.EditObj.OrderUnit, this.game);
        this.Text1Id = this.AddSubPart(ref tsubpart, 0, 0, 300, 200, 0);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Selected HQ has no officer.", this.game.GameFont1, 250, 20, false);
        this.Text1Id = this.AddSubPart(ref tsubpart, 25, 50, 250, 20, 0);
      }
      if (this.OptionsListId == 0)
      {
        this.OptionsListObj = new ListClass();
        int num = -1;
        int tlistselect1 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
        {
          if (this.game.Data.HistoricalUnitObj[tdata].Pool & this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn)
          {
            this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[tdata].CommanderName, tdata);
            ++num;
            if (tdata == this.detailnr)
              tlistselect1 = num;
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
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 8, 270, tlistselect2, game, true, "Officer Pool", tbackbitmap: (ref local1), bbx: 310, bby: 10, overruleFont: (ref local2));
          this.OptionsListId = this.AddSubPart(ref tsubpart, 310, 10, 270, 176, 0);
        }
      }
      if (this.game.Data.Round == 0 | ((long) -((double) this.game.Data.RuleVar[345] <= (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts ? 1 : 0) & (long) Math.Round((double) this.game.Data.RuleVar[345])) > 0L)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Recruit (" + this.game.Data.RuleVar[345].ToString() + "pp)", 150, "Click to recruit an extra officer to the officerpool", ref this.OwnBitmap, 600, 10);
        this.B1Id = this.AddSubPart(ref tsubpart, 600, 10, 150, 35, 1);
      }
      else if ((double) this.game.Data.RuleVar[345] > 0.0 & this.game.Data.RegimeObj[this.game.Data.Turn].OfficerPool > -1)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Recruit", 150, "You do not have the PP to buy an officer ", ref this.OwnBitmap, 600, 10, true);
        this.b1bid = this.AddSubPart(ref tsubpart, 600, 10, 150, 35, 0);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Recruit", 150, "Recruiting is disabled. ", ref this.OwnBitmap, 600, 10, true);
        this.b1bid = this.AddSubPart(ref tsubpart, 600, 10, 150, 35, 0);
      }
      int @this;
      if (this.detailnr > -1)
      {
        if (this.game.Data.Round == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Swap", 150, "Click to swap officer in selected HQ with officer selected in officerpool", ref this.OwnBitmap, 600, 50);
          this.B2Id = this.AddSubPart(ref tsubpart, 600, 50, 150, 35, 1);
        }
        else if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1)
        {
          @this = Math.Abs(Math.Min(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].PP)) + Math.Max(this.game.Data.HistoricalUnitObj[this.detailnr].PP, 0);
          if (@this < 0)
            @this = 0;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.HistoricalUnitObj[this.detailnr].PP + Math.Min(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].PP, 0))
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Swap (" + @this.ToString() + "pp)", 150, "Click to swap officer in selected HQ with officer selected in officerpool", ref this.OwnBitmap, 600, 50);
            this.B2Id = this.AddSubPart(ref tsubpart, 600, 50, 150, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Swap (" + @this.ToString() + "pp)", 150, "You dont have the PP to appoint this officer or the PP to remove the officer in the unit.", ref this.OwnBitmap, 600, 50, true);
            this.b2bid = this.AddSubPart(ref tsubpart, 600, 50, 150, 35, 0);
          }
        }
        else
        {
          @this = Math.Max(this.game.Data.HistoricalUnitObj[this.detailnr].PP, 0);
          if (@this < 0)
            @this = 0;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= @this)
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Appoint (" + @this.ToString() + "pp)", 150, "Click to swap officer in selected HQ with officer selected in officerpool", ref this.OwnBitmap, 600, 50);
            this.B2Id = this.AddSubPart(ref tsubpart, 600, 50, 150, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Appoint (" + @this.ToString() + "pp)", 150, "You dont have the PP to appoint this officer or the PP to remove the officer in the unit.", ref this.OwnBitmap, 600, 50, true);
            this.b2bid = this.AddSubPart(ref tsubpart, 600, 50, 150, 35, 0);
          }
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Remove >", 150, "Click to remove the selected officer from the officerpool", ref this.OwnBitmap, 600, 90);
        this.B3Id = this.AddSubPart(ref tsubpart1, 600, 90, 150, 35, 1);
        @this = this.detailnr;
        if (@this > -1)
        {
          SubPartClass tsubpart2 = (SubPartClass) new OfficerPartClass(-1, this.game, @this);
          this.Text2Id = this.AddSubPart(ref tsubpart2, 750, 0, 300, 200, 0);
        }
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Swap/Appoint", 150, "You have to select an officer in the officerpool first", ref this.OwnBitmap, 600, 50, true);
        this.b2bid = this.AddSubPart(ref tsubpart3, 600, 50, 150, 35, 0);
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Remove >", 150, "You have to select an officer in the officerpool first", ref this.OwnBitmap, 600, 90, true);
        this.b3bid = this.AddSubPart(ref tsubpart4, 600, 90, 150, 35, 1);
      }
      if (this.game.EditObj.OrderUnit > -1)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical > -1)
        {
          @this = Math.Abs(Math.Min(0, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical].PP));
          if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= @this)
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("< Relieve (" + @this.ToString() + "pp)", 150, "Click to relieve the leader in the unit from command without replacing him", ref this.OwnBitmap, 600, 130);
            this.B4Id = this.AddSubPart(ref tsubpart, 600, 130, 150, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("< Relieve", 150, "You dont have the PP neccessary to relieve this commander", ref this.OwnBitmap, 600, 130, true);
            this.b4bid = this.AddSubPart(ref tsubpart, 600, 130, 150, 35, 1);
          }
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("< Relieve", 150, "Selected HQ has no leader so you cannot use relieve order", ref this.OwnBitmap, 600, 130, true);
          this.b4bid = this.AddSubPart(ref tsubpart, 600, 130, 150, 35, 1);
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public void PopUpRefresh()
    {
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
            if (num1 == this.Text1Id || num1 == this.Text2Id)
            {
              int num2 = x - this.SubPartX[index1];
              int num3 = y - this.SubPartY[index1];
              if (num2 > 50 & num3 > 107 & num2 < 350 & num3 < 177)
              {
                this.game.EditObj.PopupValue = 4;
                int index2;
                int index3;
                this.game.EditObj.HandCard = this.game.Data.HistoricalUnitObj[index2].HandCard[index3];
                this.game.EditObj.TempHisUnit = this.SubPartList[index1].GetSelect();
                windowReturnClass.AddCommand(5, 10);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num2 > 45 & num3 > 0 & num2 < 131 & num3 < 86)
              {
                this.game.EditObj.PopupValue = 4;
                this.game.EditObj.TempHisUnit = this.SubPartList[index1].GetSelect();
                windowReturnClass.AddCommand(5, 10);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.B1Id)
              {
                this.game.ProcessingObj.RecruitOfficer(this.game.Data.Turn, true);
                this.detailnr = this.game.Data.HistoricalUnitCounter;
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
                this.dostuff();
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 66);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B2Id)
              {
                this.game.ProcessingObj.SwapOfficer(this.game.Data.Turn, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical, this.detailnr, this.game.EditObj.OrderUnit);
                this.detailnr = this.game.Data.HistoricalUnitCounter;
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
                this.detailnr = -1;
                this.dostuff();
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 66);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B3Id)
              {
                if (Interaction.MsgBox((object) "Are you sure?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                {
                  int num4 = (int) Interaction.MsgBox((object) "Officer is removed from the officerpool.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.RemoveHistoricalUnit(this.detailnr);
                  this.detailnr = -1;
                  this.RemoveSubPart(this.OptionsListId);
                  this.OptionsListId = 0;
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
              else
              {
                if (num1 == this.B4Id)
                {
                  this.game.ProcessingObj.SwapOfficer(this.game.Data.Turn, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical, -1, this.game.EditObj.OrderUnit);
                  this.detailnr = this.game.Data.HistoricalUnitCounter;
                  this.RemoveSubPart(this.OptionsListId);
                  this.OptionsListId = 0;
                  this.detailnr = -1;
                  this.dostuff();
                  windowReturnClass.AddCommand(4, 18);
                  windowReturnClass.AddCommand(4, 66);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsListId)
                {
                  int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num5 > -1)
                  {
                    this.detailnr = num5;
                    this.dostuff();
                  }
                  if (num5 == -2)
                  {
                    this.detailnr = -1;
                    this.dostuff();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
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
