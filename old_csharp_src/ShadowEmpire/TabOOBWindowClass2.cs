// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabOOBWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TabOOBWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;
    private int[] Ounit;
    private int[] Oselect;
    private int[] Ox;
    private int[] Oy;
    private int[] Ow;
    private int[] Showcount;
    private int RowHeight;
    private int MaxLayer;
    private int RowOffset;
    private int Olastselect;
    private int detailnr;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Text4id;
    private int Text5id;
    private int text6id;
    private int Text11Id;
    private int Text12Id;
    private int Text13Id;
    private int Text14id;
    private int Text15id;
    private int text16id;
    private int opt1;
    private int opt2;
    private int opt3;
    private int opt4;
    private int opt5;
    private int opt11;
    private int opt12;
    private int opt13;
    private int opt14;
    private int opt15;
    private int OptionsList5id;
    private ListClass OptionsList5Obj;
    private int OptionsList6id;
    private ListClass OptionsList6Obj;
    public bool onlyLand;
    private int lastUnitCount;
    public SimpleList UL;
    public int ULselected;

    public TabOOBWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.Ounit = new int[2];
      this.Oselect = new int[7];
      this.Ox = new int[2];
      this.Oy = new int[2];
      this.Ow = new int[2];
      this.Showcount = new int[7];
      this.ULselected = -1;
      this.detailnr = -1;
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.opt1 = 1;
      this.opt2 = 0;
      this.opt3 = 0;
      this.opt4 = 0;
      this.opt5 = 1;
      this.lastUnitCount = this.game.Data.UnitCounter;
      this.MakeUL();
      this.Ounit = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
      this.Ox = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
      this.Oy = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
      this.Ow = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
      this.Olastselect = -1;
      this.Makeoob();
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      int num3;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1)
        {
          if (this.game.HandyFunctionsObj.HasUnitAirSF(unr))
            ++num1;
          if (this.game.HandyFunctionsObj.HasUnitlandSF(unr))
            ++num2;
          if (this.game.HandyFunctionsObj.HasUnitNavySF(unr))
            ++num3;
        }
      }
      this.onlyLand = false;
      if (num2 > 0 & num3 < 1 & num1 < 1)
        this.onlyLand = true;
      this.dostuff();
    }

    public void MakeUL()
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 236, 0, 0));
      AIMatrix aiMatrix = new AIMatrix(ref DrawMod.TGame.DC2AIObj);
      int mapWidth = DrawMod.TGame.Data.MapObj[0].MapWidth;
      int mapHeight = DrawMod.TGame.Data.MapObj[0].MapHeight;
      DataClass data = DrawMod.TGame.Data;
      string str = "Zones";
      ref string local = ref str;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      int num1 = mapWidth;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = mapHeight;
        for (int index2 = 0; index2 <= num2; ++index2)
          aiMatrix.Value[index1, index2] = DrawMod.TGame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar);
      }
      bool flag1 = false;
      if (this.game.EventRelatedObj.Helper_AirEnabled())
        flag1 = true;
      this.UL = new SimpleList();
      int num3 = 1;
      do
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int tid1 = 0; tid1 <= unitCounter; ++tid1)
        {
          if (this.game.Data.UnitObj[tid1].PreDef == -1 && this.game.Data.UnitObj[tid1].Regime == this.game.Data.Turn)
          {
            int historical = this.game.Data.UnitObj[tid1].Historical;
            if (historical > -1)
            {
              if (num3 == 1 && this.game.Data.HistoricalUnitObj[historical].Type >= 7)
              {
                this.UL.Add(tid1, 1, 1, -1, -1, CheckExistence: false);
                int counter1 = this.UL.Counter;
                this.UL.Add(0, 1, 11, counter1, -1, CheckExistence: false);
                int counter2 = this.UL.Counter;
                this.UL.Add(0, 1, 12, counter1, -1, CheckExistence: false);
                int counter3 = this.UL.Counter;
                if (flag1)
                  this.UL.Add(0, 1, 13, counter1, -1, CheckExistence: false);
                int counter4 = this.UL.Counter;
                this.UL.Add(0, 1, 21, counter1, -1, CheckExistence: false);
                this.UL.Add(0, 1, 22, counter1, -1, CheckExistence: false);
                this.UL.Add(0, 1, 23, counter1, -1, CheckExistence: false);
                this.UL.Add(0, 1, 24, counter1, -1, CheckExistence: false);
                if (flag1)
                  this.UL.Add(0, 1, 31, counter1, -1, CheckExistence: false);
                int length = this.game.Data.StringListObj[stringListById1].Length;
                for (int tid2 = 0; tid2 <= length; ++tid2)
                {
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[tid2, 8])) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
                  {
                    int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[tid2, 6]));
                    if (id > 0)
                    {
                      int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
                      if (locationById > -1)
                      {
                        if (this.game.Data.LocObj[locationById].HQ == tid1)
                          this.UL.Add(tid2, 1, 2, counter2, -1, CheckExistence: false);
                        this.UL.Add(tid2, 1, 3, counter3, counter1, CheckExistence: false);
                        if (flag1)
                          this.UL.Add(tid2, 1, 4, counter4, counter1, CheckExistence: false);
                      }
                    }
                  }
                }
              }
              if (num3 == 2 && this.game.Data.HistoricalUnitObj[historical].Type == 5)
              {
                int idValue = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(1);
                if (idValue > 0)
                {
                  int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 26));
                  if (this.game.Data.UnitObj[tid1].HQ > -1)
                  {
                    int nr1 = this.UL.FindNr(this.game.Data.UnitObj[tid1].HQ, 1);
                    if (nr1 > -1)
                    {
                      int nr2 = this.UL.FindNr(0, integer, nr1);
                      if (nr2 > -1)
                        this.UL.Add(tid1, 1, 1, nr2, -1);
                    }
                  }
                }
                else if (this.game.Data.HistoricalUnitObj[historical].TempVar1 == 1 && this.game.Data.UnitObj[tid1].HQ > -1)
                {
                  int nr3 = this.UL.FindNr(this.game.Data.UnitObj[tid1].HQ, 1);
                  int tdata1 = 31;
                  if (nr3 > -1)
                  {
                    int nr4 = this.UL.FindNr(0, tdata1, nr3);
                    if (nr4 > -1)
                      this.UL.Add(tid1, 1, 1, nr4, -1);
                  }
                }
              }
              if (num3 == 3 && this.game.Data.HistoricalUnitObj[historical].Type < 5)
              {
                bool flag2 = false;
                int num4 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(1);
                int num5 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(11);
                if (num4 < 1 | num5 > 0)
                  flag2 = true;
                if (num5 < 1 & this.game.Data.HistoricalUnitObj[historical].BattleGroup > 0)
                  flag2 = false;
                if (!flag2 && this.game.Data.UnitObj[tid1].HQ > -1)
                {
                  int nr5 = this.UL.FindNr(this.game.Data.UnitObj[tid1].HQ, 1);
                  if (nr5 > -1)
                  {
                    if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.UL.Id[nr5]].Historical].Type == 5)
                      this.UL.Add(tid1, 1, 1, nr5, -1);
                    else if (nr5 > -1)
                    {
                      int tval = aiMatrix.Value[this.game.Data.UnitObj[tid1].X, this.game.Data.UnitObj[tid1].Y];
                      int row = this.game.Data.StringListObj[stringListById1].FindRow(0, tval);
                      if (row > -1)
                      {
                        if (flag1)
                        {
                          if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[historical].SubParts[0])))
                          {
                            int nr6 = this.UL.FindNr(row, 4, tdata3: nr5);
                            if (nr6 > -1)
                              this.UL.Add(tid1, 1, 1, nr6, -1, CheckExistence: false);
                          }
                          else
                          {
                            int nr7 = this.UL.FindNr(row, 3, tdata3: nr5);
                            if (nr7 > -1)
                              this.UL.Add(tid1, 1, 1, nr7, -1, CheckExistence: false);
                          }
                        }
                        else
                        {
                          int nr8 = this.UL.FindNr(row, 3, tdata3: nr5);
                          if (nr8 > -1)
                            this.UL.Add(tid1, 1, 1, nr8, -1, CheckExistence: false);
                        }
                      }
                    }
                  }
                }
                if (flag2 && this.game.Data.UnitObj[tid1].HQ > -1)
                {
                  int nr = this.UL.FindNr(this.game.Data.UnitObj[tid1].HQ, 1);
                  if (nr > -1)
                  {
                    int num6 = this.UL.Id[nr];
                    int tval1 = aiMatrix.Value[this.game.Data.UnitObj[tid1].X, this.game.Data.UnitObj[tid1].Y];
                    int tval2 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(51);
                    int row1 = this.game.Data.StringListObj[stringListById1].FindRow(0, tval2);
                    int tdata2 = -1;
                    if (row1 > -1)
                      tdata2 = this.UL.FindNr(row1, 2);
                    if (tdata2 < 0 & tval1 > 0)
                    {
                      int row2 = this.game.Data.StringListObj[stringListById1].FindRow(0, tval1);
                      if (row2 > -1)
                        tdata2 = this.UL.FindNr(row2, 2);
                    }
                    if (tdata2 > -1)
                      this.UL.Add(tid1, 1, 1, tdata2, -1);
                  }
                }
              }
            }
          }
        }
        ++num3;
      }
      while (num3 <= 3);
      int num7 = 1;
      do
      {
        for (int counter5 = this.UL.Counter; counter5 >= 0; counter5 += -1)
        {
          if (this.UL.Data1[counter5] > 1)
          {
            bool flag3 = false;
            int counter6 = this.UL.Counter;
            for (int index = 0; index <= counter6; ++index)
            {
              if (counter5 != index && this.UL.Data2[index] == counter5)
                flag3 = true;
            }
            if (!flag3)
            {
              this.UL.RemoveNr(counter5);
              int counter7 = this.UL.Counter;
              for (int index = 0; index <= counter7; ++index)
              {
                if (this.UL.Data2[index] > counter5)
                  this.UL.Data2[index] = this.UL.Data2[index] - 1;
              }
            }
          }
        }
        ++num7;
      }
      while (num7 <= 3);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (nr == 40)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList5id)].ShiftDown();
        this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
        this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsList5id)].GetSelect();
        this.dostuff();
        windowReturnClass.SetFlag(true);
      }
      if (nr == 38)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList5id)].ShiftUp();
        this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
        this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsList5id)].GetSelect();
        if (this.detailnr == -2)
          this.detailnr = -1;
        this.dostuff();
        windowReturnClass.SetFlag(true);
      }
      return windowReturnClass;
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 237, 0, 0));
      this.RemoveSubPart(this.Text1Id);
      this.RemoveSubPart(this.Text2Id);
      this.RemoveSubPart(this.Text3Id);
      this.RemoveSubPart(this.Text4id);
      this.RemoveSubPart(this.Text5id);
      this.RemoveSubPart(this.text6id);
      this.RemoveSubPart(this.Text11Id);
      this.RemoveSubPart(this.Text12Id);
      this.RemoveSubPart(this.Text13Id);
      this.RemoveSubPart(this.Text14id);
      this.RemoveSubPart(this.Text15id);
      this.RemoveSubPart(this.text16id);
      int num1 = (int) Math.Round((double) Math.Max(0, this.w - 1060) / 2.0);
      if (num1 > 200)
        num1 = 200;
      if (this.detailnr <= -1)
      {
        this.RemoveSubPart(this.OptionsList6id);
        this.OptionsList6id = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      bool flag1 = false;
      if (this.game.EventRelatedObj.Helper_AirEnabled())
        flag1 = true;
      this.ClearMouse();
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, " OOB ", 3);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F4]", 99999);
      DrawMod.DrawBlockGradient2(ref g, 215 + num1, 20, 654 + Math.Max(0, this.w - num1 - 920), 289 + Math.Max(0, this.h - 380), this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, 215 + num1, 20, 655 + Math.Max(0, this.w - num1 - 920), 290 + Math.Max(0, this.h - 380), 15, 0);
      int num2 = num1 + 16;
      this.OptionsList5Obj = new ListClass();
      int TempInt = -1;
      int num3 = 0;
      this.OptionsList5Obj.add(" OOB", -2);
      if (this.detailnr == -1)
        TempInt = 0;
      int num4 = this.game.Data.StringListObj[stringListById2].GetHighestValue(0);
      int historicalIdCounter = this.game.Data.HistoricalIDCounter;
      int num5 = 29000;
      bool[] flagArray1 = new bool[num4 + 1];
      bool[] flagArray2 = new bool[historicalIdCounter + 1];
      int[] numArray1 = new int[num5 + 1];
      if (this.lastUnitCount != this.game.Data.UnitCounter)
      {
        this.lastUnitCount = this.game.Data.UnitCounter;
        this.MakeUL();
        this.Ounit = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
        this.Ox = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
        this.Oy = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
        this.Ow = new int[Math.Max(this.game.Data.UnitCounter, this.UL.Counter + 1) + 1];
        this.Makeoob();
        this.dostuff();
      }
      int counter1 = this.UL.Counter;
      for (int index = 0; index <= counter1; ++index)
        this.Ox[index] = -1;
      int counter2 = this.UL.Counter;
      for (int index1 = 0; index1 <= counter2; ++index1)
      {
        if (this.UL.Id[index1] > 0 & this.UL.Data1[index1] == 1)
        {
          int historical = this.game.Data.UnitObj[this.UL.Id[index1]].Historical;
          int index2 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(2);
          this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(11);
          if (index2 > 0 && !flagArray2[historical])
          {
            flagArray1[index2] = true;
            int[] numArray2 = numArray1;
            int[] numArray3 = numArray2;
            int index3 = index2;
            int index4 = index3;
            int num6 = numArray2[index3] + 1;
            numArray3[index4] = num6;
            flagArray2[historical] = true;
          }
        }
      }
      int num7 = num4;
      for (int index = 0; index <= num7; ++index)
      {
        if (flagArray1[index])
        {
          ++num3;
          if (this.detailnr == index)
            TempInt = num3;
          this.OptionsList5Obj.add(this.game.Data.StringListObj[stringListById2].GetData(0, index, 1) + "(" + numArray1[index].ToString() + ")", index);
        }
      }
      int tlistselect = this.OptionsList5Obj.SortWithRef(TempInt);
      if (this.OptionsList5id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList5id)].Refresh(this.OptionsList5Obj, tlistselect);
        this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
      }
      else
      {
        int num8 = (int) Math.Round(Math.Floor((double) (this.h - 80) / 24.0));
        if (num2 < 50)
        {
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsList5Obj, num8 - 1, 170 + num2, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 30, bby: 20, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 24);
          this.OptionsList5id = this.AddSubPart(ref tsubpart, 30, 20, 170 + num2, 24 * num8, 0);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsList5Obj, num8 - 1, 170 + num2, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 30, bby: 20, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
          this.OptionsList5id = this.AddSubPart(ref tsubpart, 30, 20, 170 + num2, 24 * num8, 0);
        }
      }
      int num9 = 220 + num2;
      SubPartClass tsubpart1;
      if (this.detailnr <= -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, this.opt11 == 1, "Show average Unit Experience", ref this.OwnBitmap, num9, 316);
        this.Text11Id = this.AddSubPart(ref tsubpart2, num9, 316, 35, 35, 1);
        int x1 = num9 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "XP", this.game.MarcFont4, x1, 325, Color.White);
        int num10 = x1 + 45;
        SubPartClass tsubpart3 = (SubPartClass) new MarcRadioPartClass(0, this.opt11 == 2, "Show average Unit Morale", ref this.OwnBitmap, num10, 316);
        this.Text12Id = this.AddSubPart(ref tsubpart3, num10, 316, 35, 35, 1);
        int x2 = num10 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "MOR", this.game.MarcFont4, x2, 325, Color.White);
        int num11 = x2 + 45;
        SubPartClass tsubpart4 = (SubPartClass) new MarcRadioPartClass(0, this.opt11 == 3, "Show average Unit Readiness", ref this.OwnBitmap, num11, 316);
        this.Text13Id = this.AddSubPart(ref tsubpart4, num11, 316, 35, 35, 1);
        int x3 = num11 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "RDN", this.game.MarcFont4, x3, 325, Color.White);
        int num12 = x3 + 45;
        SubPartClass tsubpart5 = (SubPartClass) new MarcRadioPartClass(0, this.opt11 == 4, "Show average Unit Supply In / Requested %", ref this.OwnBitmap, num12, 316);
        this.Text14id = this.AddSubPart(ref tsubpart5, num12, 316, 35, 35, 1);
        int x4 = num12 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "SUP", this.game.MarcFont4, x4, 325, Color.White);
        int num13 = x4 + 45;
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.opt11 == 5, "Show average Unit Hunger Score", ref this.OwnBitmap, num13, 316);
        this.Text15id = this.AddSubPart(ref tsubpart1, num13, 316, 35, 35, 1);
        int x5 = num13 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "HUNGER", this.game.MarcFont4, x5, 325, Color.White);
      }
      else
      {
        SubPartClass tsubpart6 = (SubPartClass) new MarcRadioPartClass(0, this.opt5 == 0, "Specific unit data", ref this.OwnBitmap, num9, 316);
        this.Text5id = this.AddSubPart(ref tsubpart6, num9, 316, 35, 35, 1);
        int x6 = num9 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "SPECIFIC", this.game.MarcFont4, x6, 325, Color.White);
        int num14 = x6 + 145;
        SubPartClass tsubpart7 = (SubPartClass) new MarcRadioPartClass(0, this.opt5 == 1, "Average unit data for selected OOB model", ref this.OwnBitmap, num14, 316);
        this.text6id = this.AddSubPart(ref tsubpart7, num14, 316, 35, 35, 1);
        int x7 = num14 + 45;
        DrawMod.DrawTextColouredMarc(ref g, "AVERAGE", this.game.MarcFont4, x7, 325, Color.White);
      }
      int num15 = 190 + num2;
      int num16 = 360 + (int) Math.Round((double) Math.Max(0, this.w - num2 - 920) / 2.0) + num2;
      int num17 = 785 + Math.Max(0, this.w - num2 - 920) + num2;
      int num18 = 825 + Math.Max(0, this.w - num2 - 920) + num2;
      int num19 = 865 + Math.Max(0, this.w - num2 - 920) + num2;
      int counter3 = this.UL.Counter;
      for (int index = 0; index <= counter3; ++index)
        this.Ox[index] = -1;
      if (this.ULselected == -1 & this.Olastselect > -1)
      {
        bool flag2 = false;
        if (this.UL.Data1[this.Olastselect] == 1 && this.game.Data.UnitObj[this.UL.Id[this.Olastselect]].IsHQ)
          flag2 = true;
        this.ULselected = !flag2 ? this.UL.FindNr(this.game.EditObj.UnitSelected, 1) : this.Olastselect;
      }
      else if (this.ULselected == -1 & this.game.EditObj.UnitSelected > -1)
        this.ULselected = this.UL.FindNr(this.game.EditObj.UnitSelected, 1);
      int index5 = -1;
      if (this.ULselected > -1 && this.UL.Data1[this.ULselected] == 1)
      {
        index5 = this.UL.Id[this.ULselected];
        this.Oselect[this.Ounit[this.ULselected]] = this.ULselected;
        for (int index6 = this.UL.Data2[this.ULselected]; index6 > -1; index6 = this.UL.Data2[index6])
          this.Oselect[this.Ounit[index6]] = index6;
      }
      SimpleList simpleList1;
      int tdata1;
      if (this.detailnr <= -1)
      {
        DrawMod.DrawTextColouredMarc(ref g, Strings.UCase("Order of Battle (OOB)"), this.game.MarcFont4, 235 + num2, 30, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        int num20 = num16 - 20 + num2;
        int num21 = -this.RowHeight + this.RowOffset;
        int maxLayer = this.MaxLayer;
        for (int index7 = 1; index7 <= maxLayer; ++index7)
        {
          int num22 = 0;
          if (index7 == 1 | this.Oselect[index7 - 1] > -1)
          {
            num21 += this.RowHeight;
            simpleList1 = new SimpleList();
            int counter4 = this.UL.Counter;
            for (int tid = 0; tid <= counter4; ++tid)
            {
              int tweight = 10;
              bool flag3 = false;
              if (this.UL.Data1[tid] == 1 && this.game.Data.UnitObj[this.UL.Id[tid]].IsHQ)
                flag3 = true;
              if (flag3)
                tweight = 100;
              if (this.Ounit[tid] == index7 & tweight > 0)
              {
                if (index7 == 1)
                  simpleList1.Add(tid, tweight);
                else if (this.Oselect[index7 - 1] > -1 && this.UL.Data2[tid] == this.Oselect[index7 - 1])
                  simpleList1.Add(tid, tweight);
              }
            }
            simpleList1.ReverseSort();
            if (index7 == 1)
              num20 = num16 + 180;
            if (index7 > 1)
              num20 = this.Ox[this.Oselect[index7 - 1]];
            if (simpleList1.Counter > -1)
            {
              num22 = 1;
              int num23 = (int) Math.Round(Conversion.Int((double) (num18 - num15) / (double) (simpleList1.Counter + 1)));
              if (num23 > 100)
                num23 = 100;
              int num24 = (int) Math.Round((double) num20 - (double) ((simpleList1.Counter + 1) * num23) / 2.0);
              if (num24 + num23 * (simpleList1.Counter + 1) > num19 - num15)
                num24 -= num24 + num23 * (simpleList1.Counter + 1) - (num19 - num15);
              if (num24 < 226)
                num24 += 226 - num24;
              if (num24 < num15)
                num24 = num15;
              int num25 = num24 - num23;
              int counter5 = simpleList1.Counter;
              for (int index8 = 0; index8 <= counter5; ++index8)
              {
                num25 += num23;
                int num26 = (int) Math.Round((double) num25 + ((double) num23 / 2.0 - 18.0));
                int num27 = (int) Math.Round((double) num21 + ((double) this.RowHeight / 2.0 - 18.0));
                this.Ox[simpleList1.Id[index8]] = num26;
                this.Oy[simpleList1.Id[index8]] = num27;
                if (index7 == 1 & simpleList1.Counter == 0)
                  this.Oselect[1] = simpleList1.Id[index8];
                if (index7 == 2 & simpleList1.Counter == 0)
                  this.Oselect[2] = simpleList1.Id[index8];
                if (index7 > 1)
                {
                  int index9 = this.UL.Data2[simpleList1.Id[index8]];
                  DrawMod.drawLine(ref g, num26 + 18, num27 + 18, num26 + 18, this.RowOffset + this.RowHeight * (index7 - 1), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                  DrawMod.drawLine(ref g, num26 + 18, this.RowOffset + this.RowHeight * (index7 - 1), this.Ox[index9] + 18, this.RowOffset + this.RowHeight * (index7 - 1), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                  DrawMod.drawLine(ref g, this.Ox[index9] + 18, this.RowOffset + this.RowHeight * (index7 - 1), this.Ox[index9] + 18, this.Oy[index9] + 18, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                }
              }
            }
          }
          if (num22 == 0)
            break;
        }
      }
      else
      {
        string data = this.game.Data.StringListObj[stringListById2].GetData(0, this.detailnr, 1);
        DrawMod.DrawTextColouredMarc(ref g, Strings.UCase(data + " units:"), this.game.MarcFont4, 235 + num2, 30, Color.FromArgb(210, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        int num28 = 340 + num2;
        if (this.game.Data.UnitCounter > num4)
          num4 = this.game.Data.UnitCounter;
        bool[] flagArray3 = new bool[num4 + 1];
        simpleList1 = new SimpleList();
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int tid = 0; tid <= unitCounter1; ++tid)
        {
          if (this.game.Data.UnitObj[tid].PreDef == -1 & this.game.Data.UnitObj[tid].Historical > -1 & this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tid].Historical].GiveHisVarValue(2) == this.detailnr)
          {
            int tweight = 0 + 1;
            simpleList1.Add(tid, tweight);
          }
        }
        simpleList1.Sort();
        if (simpleList1.Counter > -1)
        {
          int num29 = (int) Math.Round(Conversion.Int(3900.0 / (double) (simpleList1.Counter + 7)));
          if (num29 > 50)
            num29 = 50;
          int num30 = 60;
          if (num29 < 30)
            num30 = 42;
          int num31 = (int) Math.Round(220.0 / (double) (int) Math.Round(1.0 + (double) (num29 * (simpleList1.Counter + 1)) / (double) Conversion.Int(390)));
          if (num31 > 60)
            num31 = 60;
          int num32 = -num29;
          int num33 = 0;
          int counter6 = simpleList1.Counter;
          for (int index10 = 0; index10 <= counter6; ++index10)
          {
            num32 += num29;
            if (num32 < 10 & index10 == 0)
              num32 = 10;
            if (num32 > 390)
            {
              num32 = 10;
              num33 += num31;
            }
            this.Ox[simpleList1.Id[index10]] = 235 + num32 + num2;
            this.Oy[simpleList1.Id[index10]] = 65 + num33;
          }
        }
        SimpleList Expression = new SimpleList();
        SimpleList simpleList2 = new SimpleList();
        if (this.opt5 == 0)
        {
          if (index5 > -1)
          {
            int historical = this.game.Data.UnitObj[index5].Historical;
            if (historical > -1)
            {
              int ToeTypeId = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(2);
              if (ToeTypeId > 0)
              {
                Expression = this.game.EventRelatedObj.Helper_GetReinfListForToe(ToeTypeId);
                int counter7 = Expression.Counter;
                for (int index11 = 0; index11 <= counter7; ++index11)
                {
                  int reinfTypeById = this.game.HandyFunctionsObj.GetReinfTypeByID(Expression.Id[index11]);
                  Expression.Weight[index11] = Expression.Weight[index11] * this.game.Data.ReinfRatio[reinfTypeById];
                }
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int index12 = 0; index12 <= unitCounter2; ++index12)
                {
                  if (this.game.Data.UnitObj[index12].Historical == historical & this.game.Data.UnitObj[index12].PreDef == -1)
                  {
                    int sfCount = this.game.Data.UnitObj[index12].SFCount;
                    for (int index13 = 0; index13 <= sfCount; ++index13)
                    {
                      int sf = this.game.Data.UnitObj[index12].SFList[index13];
                      int type = this.game.Data.SFObj[sf].Type;
                      int tid = this.game.Data.ReinfId[this.game.Data.SFTypeObj[type].ReinforcementType];
                      if (Expression.FindNr(tid) == -1)
                      {
                        int reinforcementType2 = this.game.Data.SFTypeObj[type].ReinforcementType2;
                        if (simpleList2.FindNr(reinforcementType2) > -1)
                        {
                          int[] weight = simpleList2.Weight;
                          int[] numArray4 = weight;
                          int nr = simpleList2.FindNr(reinforcementType2);
                          int index14 = nr;
                          int num34 = weight[nr] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio;
                          numArray4[index14] = num34;
                        }
                        else
                          simpleList2.Add(reinforcementType2, this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio);
                      }
                      else if (simpleList2.FindNr(tid) > -1)
                      {
                        int[] weight = simpleList2.Weight;
                        int[] numArray5 = weight;
                        int nr = simpleList2.FindNr(tid);
                        int index15 = nr;
                        int num35 = weight[nr] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio;
                        numArray5[index15] = num35;
                      }
                      else
                        simpleList2.Add(tid, this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio);
                    }
                  }
                }
              }
            }
          }
        }
        else if (this.opt5 == 1)
        {
          int detailnr = this.detailnr;
          bool[] flagArray4 = new bool[this.game.Data.HistoricalUnitCounter + 1];
          if (detailnr > -1)
          {
            Expression = this.game.EventRelatedObj.Helper_GetReinfListForToe(detailnr);
            int counter8 = Expression.Counter;
            for (int index16 = 0; index16 <= counter8; ++index16)
            {
              int reinfTypeById = this.game.HandyFunctionsObj.GetReinfTypeByID(Expression.Id[index16]);
              Expression.Weight[index16] = Expression.Weight[index16] * this.game.Data.ReinfRatio[reinfTypeById];
            }
            int unitCounter3 = this.game.Data.UnitCounter;
            int num36;
            for (int index17 = 0; index17 <= unitCounter3; ++index17)
            {
              if (this.game.Data.UnitObj[index17].Historical > -1 & this.game.Data.UnitObj[index17].PreDef == -1 & this.game.Data.UnitObj[index17].Regime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index17].Historical].GiveHisVarValue(2) == detailnr)
              {
                int index18 = index17;
                if (index18 > -1)
                {
                  if (!flagArray4[this.game.Data.UnitObj[index17].Historical])
                  {
                    flagArray4[this.game.Data.UnitObj[index17].Historical] = true;
                    ++num36;
                  }
                  int sfCount = this.game.Data.UnitObj[index18].SFCount;
                  for (int index19 = 0; index19 <= sfCount; ++index19)
                  {
                    int sf = this.game.Data.UnitObj[index18].SFList[index19];
                    int type = this.game.Data.SFObj[sf].Type;
                    int tid = this.game.Data.ReinfId[this.game.Data.SFTypeObj[type].ReinforcementType];
                    if (Expression.FindNr(tid) == -1)
                    {
                      int reinforcementType2 = this.game.Data.SFTypeObj[type].ReinforcementType2;
                      if (reinforcementType2 > -1)
                      {
                        if (simpleList2.FindNr(reinforcementType2) > -1)
                        {
                          int[] weight = simpleList2.Weight;
                          int[] numArray6 = weight;
                          int nr = simpleList2.FindNr(reinforcementType2);
                          int index20 = nr;
                          int num37 = weight[nr] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio;
                          numArray6[index20] = num37;
                        }
                        else
                          simpleList2.Add(reinforcementType2, this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio);
                      }
                    }
                    else if (tid > -1)
                    {
                      if (simpleList2.FindNr(tid) > -1)
                      {
                        int[] weight = simpleList2.Weight;
                        int[] numArray7 = weight;
                        int nr = simpleList2.FindNr(tid);
                        int index21 = nr;
                        int num38 = weight[nr] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio;
                        numArray7[index21] = num38;
                      }
                      else
                        simpleList2.Add(tid, this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio);
                    }
                  }
                }
              }
            }
            int counter9 = simpleList2.Counter;
            for (int index22 = 0; index22 <= counter9; ++index22)
              simpleList2.Weight[index22] = (int) Math.Round((double) simpleList2.Weight[index22] / (double) num36);
          }
        }
        this.OptionsList6Obj = new ListClass();
        if (this.opt5 == 0 & index5 > -1)
        {
          this.OptionsList6Obj.add("SPECIFIC UNIT", 0);
          this.OptionsList6Obj.add(this.game.Data.UnitObj[index5].Name, 0);
        }
        else if (this.opt5 == 1)
        {
          this.OptionsList6Obj.add("AVERAGE UNIT", 0);
          this.OptionsList6Obj.add(this.game.Data.StringListObj[stringListById2].GetData(0, this.detailnr, 1), 0);
        }
        if (this.opt5 == 1 | index5 > -1 & !Information.IsNothing((object) Expression))
        {
          this.OptionsList6Obj.add("", 0);
          this.OptionsList6Obj.add("TYPE", 0, "TOE", "CUR", "MISS");
          int reinfCounter = this.game.Data.ReinfCounter;
          for (int index23 = 0; index23 <= reinfCounter; ++index23)
          {
            int tid = this.game.Data.ReinfId[index23];
            tdata1 = Expression.FindNr(tid);
            if (tdata1 > -1)
            {
              tdata1 = Expression.Weight[tdata1];
              int nr = simpleList2.FindNr(tid);
              int num39;
              string str;
              if (nr > -1)
              {
                num39 = simpleList2.Weight[nr];
                int num40 = tdata1 - num39;
                str = num40 != 0 ? (num40 <= 0 ? "(+" + Math.Abs(num40).ToString() + ")" : num40.ToString()) : "-";
              }
              else
              {
                num39 = 0;
                str = tdata1.ToString();
              }
              if (Information.IsNothing((object) str))
                str = "0";
              this.OptionsList6Obj.add(this.game.Data.ReinfName[index23], 0, tdata1.ToString(), num39.ToString(), str);
            }
          }
        }
        if (this.OptionsList6id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList6id)].Refresh(this.OptionsList6Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList6id)] = true;
        }
        else
        {
          ListClass optionsList6Obj = this.OptionsList6Obj;
          int twidth = 200 + Math.Max(0, this.w - num2 - 1060);
          GameClass game = this.game;
          int tValueWidth = 100 + Math.Max(0, (int) Math.Round((double) (this.w - num2 - 1060) / 3.0));
          ref Bitmap local1 = ref this.OwnBitmap;
          int bbx = 660 + num2;
          Font font = (Font) null;
          ref Font local2 = ref font;
          tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, 15, twidth, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: 36, tMarcStyle: true, overruleFont: (ref local2));
          this.OptionsList6id = this.AddSubPart(ref tsubpart1, 660 + num2, 36, 200 + Math.Max(0, this.w - 1060), 256, 0);
        }
      }
      if (this.detailnr <= -1)
      {
        int counter10 = this.UL.Counter;
        for (int tdata2 = 0; tdata2 <= counter10; ++tdata2)
        {
          if (this.Ox[tdata2] > -1)
          {
            string str = "Auxilliary";
            string tstring = "Aux";
            if (this.UL.Data1[tdata2] == 1)
              str = this.game.Data.UnitObj[this.UL.Id[tdata2]].Name;
            else if (this.UL.Data1[tdata2] == 2 | this.UL.Data1[tdata2] == 3 | this.UL.Data1[tdata2] == 4)
            {
              str = this.game.Data.StringListObj[stringListById1].Data[this.UL.Id[tdata2], 7];
              tstring = Strings.Left(str, 4) + ".";
            }
            else
            {
              if (this.UL.Data1[tdata2] == 11)
              {
                str = "Militia Forces";
                tstring = "Mil";
              }
              if (this.UL.Data1[tdata2] == 12)
              {
                str = "Independent Regular Units";
                tstring = "Ind";
              }
              if (this.UL.Data1[tdata2] == 13)
              {
                str = "Independent Air Units";
                tstring = "Air";
              }
              if (this.UL.Data1[tdata2] == 21)
              {
                str = "Infantry Formations";
                tstring = "Inf";
              }
              if (this.UL.Data1[tdata2] == 22)
              {
                str = "Mobile Formations";
                tstring = "Mob";
              }
              if (this.UL.Data1[tdata2] == 23)
              {
                str = "Tank Formations";
                tstring = "Tank";
              }
              if (this.UL.Data1[tdata2] == 24)
              {
                str = "Mechanized Formations";
                tstring = "Mech";
              }
              if (this.UL.Data1[tdata2] == 31)
              {
                str = "Air Commands";
                tstring = "Com";
              }
            }
            bool forcehighlight = false;
            if (this.Olastselect == tdata2)
              forcehighlight = true;
            if (this.UL.Data1[tdata2] == 1)
            {
              ref Graphics local3 = ref g;
              Bitmap bitmap = this.game.CustomBitmapObj.DrawUnit(this.UL.Id[tdata2], forcehighlight, ForceHideUnitMode: 2);
              ref Bitmap local4 = ref bitmap;
              int x = this.Ox[tdata2];
              int y = this.Oy[tdata2];
              DrawMod.DrawSimple(ref local3, ref local4, x, y);
              if (!this.game.Data.UnitObj[this.UL.Id[tdata2]].IsHQ)
              {
                if (this.opt11 == 1)
                {
                  tdata1 = this.game.HandyFunctionsObj.GetAverageXp(this.UL.Id[tdata2]);
                  DrawMod.DrawTextColouredMarcCenter(ref g, "xp=" + tdata1.ToString(), this.game.MarcFont5, this.Ox[tdata2] + 18, this.Oy[tdata2] + 40, Color.White);
                }
                if (this.opt11 == 2)
                {
                  tdata1 = this.game.HandyFunctionsObj.GetAverageMor(this.UL.Id[tdata2]);
                  DrawMod.DrawTextColouredMarcCenter(ref g, "mor=" + tdata1.ToString(), this.game.MarcFont5, this.Ox[tdata2] + 18, this.Oy[tdata2] + 40, Color.White);
                }
                if (this.opt11 == 3)
                {
                  tdata1 = this.game.HandyFunctionsObj.GetAverageRdn(this.UL.Id[tdata2]);
                  DrawMod.DrawTextColouredMarcCenter(ref g, "rdn=" + tdata1.ToString(), this.game.MarcFont5, this.Ox[tdata2] + 18, this.Oy[tdata2] + 40, Color.White);
                }
                if (this.opt11 == 5)
                {
                  tdata1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.UL.Id[tdata2]].Historical].GiveHisVarValue(81);
                  DrawMod.DrawTextColouredMarcCenter(ref g, "hun=" + tdata1.ToString(), this.game.MarcFont5, this.Ox[tdata2] + 18, this.Oy[tdata2] + 40, Color.White);
                }
                if (this.opt11 == 4)
                {
                  tdata1 = 0;
                  int num41 = 0;
                  int logCounter = this.game.Data.UnitObj[this.UL.Id[tdata2]].LogCounter;
                  for (int index24 = 0; index24 <= logCounter; ++index24)
                  {
                    if (this.game.Data.UnitObj[this.UL.Id[tdata2]].LogType[index24] == 202)
                      tdata1 += this.game.Data.UnitObj[this.UL.Id[tdata2]].LogData3[index24];
                    else if (this.game.Data.UnitObj[this.UL.Id[tdata2]].LogType[index24] == 105)
                      num41 += this.game.Data.UnitObj[this.UL.Id[tdata2]].LogData3[index24];
                  }
                  if (tdata1 > 0)
                    tdata1 = (int) Math.Round((double) (100 * num41) / (double) tdata1);
                  else if (tdata1 == 0 & num41 == 0)
                    tdata1 = 100;
                  DrawMod.DrawTextColouredMarcCenter(ref g, "sup=" + tdata1.ToString(), this.game.MarcFont5, this.Ox[tdata2] + 18, this.Oy[tdata2] + 40, Color.White);
                }
              }
            }
            else
            {
              DrawMod.DrawBlock(ref g, this.Ox[tdata2], this.Oy[tdata2], 38, 38, 128, 128, 128, (int) byte.MaxValue);
              DrawMod.DrawTextColouredConsoleCenter(ref g, tstring, this.game.MarcFont4, this.Ox[tdata2] + 20, this.Oy[tdata2] + 10, this.game.seColWhite);
            }
            Rectangle trect2 = new Rectangle(this.Ox[tdata2], this.Oy[tdata2], 38, 38);
            this.AddMouse(ref trect2, "", str, tdata2);
            if (tdata2 == this.Oselect[this.Ounit[tdata2]])
              DrawMod.DrawRectangle(ref g, this.Ox[tdata2] - 2, this.Oy[tdata2] - 2, 41, 41, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 3);
          }
        }
      }
      else
      {
        int counter11 = simpleList1.Counter;
        for (int index25 = 0; index25 <= counter11; ++index25)
        {
          int index26 = simpleList1.Id[index25];
          if (this.Ox[index26] > -1)
          {
            string str = this.game.Data.UnitObj[index26].Name;
            bool forcehighlight = false;
            if (this.Olastselect == index26)
              forcehighlight = true;
            if (this.game.Data.UnitObj[index26].Historical > -1 && this.game.Data.UnitObj[index26].IsHQ)
            {
              tdata1 = this.game.Data.UnitObj[index26].Historical;
              if (!Information.IsNothing((object) this.game.Data.HistoricalUnitObj[tdata1].CommanderName) && this.game.Data.HistoricalUnitObj[tdata1].CommanderName.Length > 1)
                str = str + "\r\n" + this.game.Data.HistoricalUnitObj[tdata1].CommanderName;
            }
            string ttext = str + "\r\n(click to select, double click for selecting HQ)";
            if (this.Olastselect == index26)
              ttext = ttext;
            if (Strings.InStr(this.game.Data.UnitObj[index26].Name, "SS") > 0)
              ttext = ttext;
            ref Graphics local5 = ref g;
            Bitmap bitmap = this.game.CustomBitmapObj.DrawUnit(index26, forcehighlight, ForceHideUnitMode: 2);
            ref Bitmap local6 = ref bitmap;
            int x = this.Ox[index26];
            int y = this.Oy[index26];
            DrawMod.DrawSimple(ref local5, ref local6, x, y);
            tdata1 = this.UL.FindNr(index26);
            if (tdata1 > -1)
            {
              int num42 = this.UL.Id[tdata1];
              Rectangle trect3 = new Rectangle(this.Ox[index26], this.Oy[index26], 38, 38);
              this.AddMouse(ref trect3, "", ttext, tdata1);
              if (index5 == index26)
                DrawMod.DrawRectangle(ref g, this.Ox[index26] - 1, this.Oy[index26] - 1, 39, 39, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            }
          }
        }
      }
    }

    public override void HandleToolTip(int x, int y)
    {
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[mouseCounter];
          this.game.EditObj.TipText = this.MouseText[mouseCounter];
          break;
        }
      }
    }

    public override WindowReturnClass HandleMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (b == 2097152)
        return windowReturnClass1;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > -1 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height && this.MouseData[mouseCounter] > -1 & this.MouseData[mouseCounter] < 99999)
        {
          if (this.Ounit[this.MouseData[mouseCounter]] > -1)
          {
            this.Oselect[this.Ounit[this.MouseData[mouseCounter]]] = this.MouseData[mouseCounter];
            bool flag = false;
            if (this.UL.Data1[this.MouseData[mouseCounter]] == 1 && this.game.Data.UnitObj[this.UL.Id[this.MouseData[mouseCounter]]].IsHQ)
              flag = true;
            if (this.Olastselect == this.MouseData[mouseCounter] | !flag)
            {
              this.Olastselect = this.ULselected;
              if (this.ULselected != this.MouseData[mouseCounter] | flag)
              {
                this.ULselected = this.MouseData[mouseCounter];
                if (this.UL.Data1[this.MouseData[mouseCounter]] == 1)
                {
                  this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                  this.game.EditObj.UnitSelected = this.UL.Id[this.MouseData[mouseCounter]];
                  this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X;
                  this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y;
                  if (this.game.SelectX == -1 && this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X == -1)
                  {
                    this.game.EditObj.UnitSelected = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].OnBoard;
                    this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X;
                    this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y;
                  }
                  this.game.HandyFunctionsObj.SetcornerXY2();
                  int num = this.game.ScreenHeight - this.h;
                  if (this.game.EditObj.GuiDown)
                    num -= 222;
                  if (this.game.EditObj.Zoom == 1)
                    num = (int) Math.Round((double) num / 128.0);
                  if (this.game.EditObj.Zoom == 0)
                    num = (int) Math.Round((double) num / 64.0);
                  if (this.game.EditObj.Zoom == -1)
                    num = (int) Math.Round((double) num / 32.0);
                  this.game.CornerY -= (int) Math.Round((double) num / 2.0) - 1;
                  if (this.game.CornerY > this.game.Data.MapObj[0].MapHeight - num)
                    this.game.CornerY = this.game.Data.MapObj[0].MapHeight - num;
                  if (this.game.CornerY < 0)
                    this.game.CornerY = 0;
                  if ((double) this.game.Data.RuleVar[701] > 0.0)
                  {
                    ScreenClass screeny = this.formref.Screeny;
                    Type type = typeof (MapWindowClass2);
                    ref Type local = ref type;
                    MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
                    if (!Information.IsNothing((object) window))
                    {
                      WindowReturnClass windowReturnClass2 = (WindowReturnClass) window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                      this.game.EditObj.TempCoordList = new CoordList();
                      windowReturnClass2.AddCommand(4, 12);
                      windowReturnClass2.AddCommand(4, 69);
                      windowReturnClass2.AddCommand(4, 67);
                      windowReturnClass2.AddCommand(4, 68);
                      windowReturnClass2.AddCommand(4, 9);
                      windowReturnClass2.SetFlag(true);
                      return windowReturnClass2;
                    }
                  }
                  else
                  {
                    windowReturnClass1.AddCommand(4, 12);
                    windowReturnClass1.AddCommand(4, 69);
                    windowReturnClass1.AddCommand(4, 67);
                    windowReturnClass1.AddCommand(4, 68);
                    windowReturnClass1.AddCommand(4, 9);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                }
              }
            }
            else
            {
              this.Olastselect = this.MouseData[mouseCounter];
              this.ULselected = this.MouseData[mouseCounter];
            }
            int num1 = this.Ounit[this.MouseData[mouseCounter]] + 1;
            int maxLayer = this.MaxLayer;
            for (int index = num1; index <= maxLayer; ++index)
              this.Oselect[index] = -1;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.ULselected != this.MouseData[mouseCounter])
          {
            this.Olastselect = this.MouseData[mouseCounter];
            this.ULselected = this.MouseData[mouseCounter];
            if (this.UL.Data1[this.MouseData[mouseCounter]] == 1)
            {
              this.game.EditObj.UnitSelected = this.UL.Id[this.MouseData[mouseCounter]];
              this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X;
              this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y;
              this.game.HandyFunctionsObj.SetcornerXY2();
              windowReturnClass1.AddCommand(4, 12);
              windowReturnClass1.AddCommand(4, 69);
              windowReturnClass1.AddCommand(4, 67);
              windowReturnClass1.AddCommand(4, 68);
              windowReturnClass1.AddCommand(4, 9);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass1.NoMouseClickBelow = true;
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > -1 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height && this.MouseData[mouseCounter] == 99999)
        {
          this.game.EditObj.SetViewMode2 = 0;
          windowReturnClass.AddCommand(1, 9);
          windowReturnClass.AddCommand(7, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.SetFlag(true);
          windowReturnClass.NoMouseClickBelow = true;
          return windowReturnClass;
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.OptionsList5id)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              switch (num2)
              {
                case -2:
                  num2 = -1;
                  break;
                case -1:
                  this.SubPartFlag[index] = true;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
              }
              this.SubPartFlag[index] = true;
              if (this.detailnr == -1 & num2 > -1)
              {
                this.detailnr = num2;
                this.Makeoob();
              }
              else if (this.detailnr > -1 & num2 == -1)
              {
                this.detailnr = num2;
                this.Makeoob();
              }
              else
                this.detailnr = num2;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text11Id)
            {
              this.opt11 = this.opt11 != 1 ? 1 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text12Id)
            {
              this.opt11 = this.opt11 != 2 ? 2 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text13Id)
            {
              this.opt11 = this.opt11 != 3 ? 3 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text14id)
            {
              this.opt11 = this.opt11 != 4 ? 4 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text15id)
            {
              this.opt11 = this.opt11 != 5 ? 5 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text1Id)
            {
              this.opt1 = this.opt1 != 1 ? 1 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text2Id)
            {
              this.opt2 = this.opt2 != 1 ? 1 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text3Id)
            {
              this.opt3 = this.opt3 != 1 ? 1 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text4id)
            {
              this.opt4 = this.opt4 != 1 ? 1 : 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text5id)
            {
              this.opt5 = 0;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.text6id)
            {
              this.opt5 = 1;
              int olastselect = this.Olastselect;
              this.Makeoob();
              this.Olastselect = olastselect;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public void Makeoob()
    {
      int index1 = 1;
      do
      {
        this.Oselect[index1] = -1;
        this.Showcount[index1] = 0;
        ++index1;
      }
      while (index1 <= 6);
      this.MaxLayer = 1;
      this.RowHeight = 50;
      int counter1 = this.UL.Counter;
      for (int index2 = 0; index2 <= counter1; ++index2)
      {
        this.Ounit[index2] = -1;
        bool flag = false;
        if (this.UL.Data1[index2] == 1)
        {
          int index3 = this.UL.Id[index2];
          if (this.game.Data.UnitObj[index3].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index3].Historical].Type >= 7)
            flag = true;
          if (flag)
          {
            this.Ounit[index2] = 1;
            if (this.MaxLayer < 1)
              this.MaxLayer = 1;
          }
        }
        if (this.UL.Data1[index2] >= 10)
        {
          this.Ounit[index2] = 2;
          if (this.MaxLayer < 2)
            this.MaxLayer = 2;
        }
        if (this.UL.Data1[index2] == 2 | this.UL.Data1[index2] == 3 | this.UL.Data1[index2] == 4)
        {
          this.Ounit[index2] = 3;
          if (this.MaxLayer < 3)
            this.MaxLayer = 3;
        }
      }
      int num1 = 1;
      do
      {
        int counter2 = this.UL.Counter;
        for (int index4 = 0; index4 <= counter2; ++index4)
        {
          if (this.UL.Data1[index4] == 1)
          {
            int num2 = this.UL.Id[index4];
            if (this.UL.Data2[index4] > -1 & this.Ounit[index4] == -1)
            {
              int index5 = this.UL.Data2[index4];
              if (index5 > -1)
              {
                this.Ounit[index4] = this.Ounit[index5] + 1;
                if (this.Ounit[index4] > this.MaxLayer)
                  this.MaxLayer = this.Ounit[index4];
              }
            }
          }
        }
        ++num1;
      }
      while (num1 <= 2);
      int num3 = this.h - 60;
      this.RowOffset = 0;
      if (num3 > 400)
        this.RowOffset = (int) Math.Round((double) (int) Math.Round((double) (num3 - 400) * 0.3) / 2.0);
      this.RowHeight = (int) Math.Round(Conversion.Int((double) (this.h - (100 + this.RowOffset * 2)) / (double) this.MaxLayer));
      if (this.RowHeight > 150)
        this.RowHeight = 150;
      this.RowOffset += 20;
      if (this.ULselected <= -1)
        return;
      int index6 = this.ULselected;
      this.Olastselect = index6;
      while (index6 > -1)
      {
        if (this.Ounit[index6] > -1)
        {
          this.Oselect[this.Ounit[index6]] = index6;
          index6 = this.UL.Data2[index6];
        }
        else
          index6 = -1;
      }
    }
  }
}
