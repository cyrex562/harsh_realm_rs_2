// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabStatsWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TabStatsWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int subtabnr;
    private int w;
    private int h;
    private int detailnr;
    private int detailnr2;
    private int detailnr3;
    private int detailnr4;
    private int detailhisnr;
    private int CurrentView;
    private int nextdetailnrhis;
    private int prevdetailnrhis;
    private int OptionsList5id;
    private int optionslist6id;
    private int optionslist7id;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Text4id;
    private int Text5id;
    private int text6id;
    private ListClass OptionsList5Obj;
    private ListClass OptionsList6Obj;
    private ListClass OptionsList7Obj;

    public TabStatsWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.detailnr = -1;
      this.detailnr3 = 1;
      this.detailnr4 = 0;
      this.subtabnr = 0;
      this.detailnr2 = 0;
      this.detailhisnr = -1;
      if (this.game.EditObj.statsTab_tab > -1)
        this.subtabnr = this.game.EditObj.statsTab_tab;
      if (this.game.EditObj.statsTab_item > -1)
        this.detailnr = this.game.EditObj.statsTab_item;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff(true);

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (nr == 40)
      {
        if (this.nextdetailnrhis > -1)
        {
          this.detailhisnr = this.nextdetailnrhis;
          this.dostuff();
          windowReturnClass.SetFlag(true);
        }
        else
        {
          this.SubPartList[this.SubpartNr(this.OptionsList5id)].ShiftDown();
          this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
          this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsList5id)].GetSelect();
          this.dostuff();
          windowReturnClass.SetFlag(true);
        }
      }
      if (nr == 38)
      {
        if (this.prevdetailnrhis > -1)
        {
          this.detailhisnr = this.prevdetailnrhis;
          this.dostuff();
          windowReturnClass.SetFlag(true);
        }
        else
        {
          this.SubPartList[this.SubpartNr(this.OptionsList5id)].ShiftUp();
          this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
          this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsList5id)].GetSelect();
          this.dostuff();
          windowReturnClass.SetFlag(true);
        }
      }
      return windowReturnClass;
    }

    public void dostuff(bool IsRefresh = false)
    {
      int[,] numArray1 = new int[this.game.Data.Round + 1, this.game.Data.RegimeCounter + 1 + 1];
      Color[] colorArray = new Color[this.game.Data.RegimeCounter + 1 + 1];
      string[] strArray1 = new string[this.game.Data.RegimeCounter + 1 + 1];
      int num1 = 150;
      this.nextdetailnrhis = -1;
      this.prevdetailnrhis = -1;
      this.RemoveSubPart(this.Info1Id);
      if (!IsRefresh)
      {
        this.RemoveSubPart(this.optionslist6id);
        this.optionslist6id = 0;
      }
      if (!IsRefresh)
      {
        this.RemoveSubPart(this.optionslist7id);
        this.optionslist7id = 0;
      }
      this.RemoveSubPart(this.Text1Id);
      this.RemoveSubPart(this.Text2Id);
      this.RemoveSubPart(this.Text3Id);
      this.RemoveSubPart(this.Text4id);
      this.RemoveSubPart(this.Text5id);
      this.RemoveSubPart(this.text6id);
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      this.ClearMouse();
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, "STATS", 2);
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F3]", 999);
      int tregcount;
      string str1;
      SubPartClass tsubpart1;
      if (this.subtabnr == 0)
      {
        this.OptionsList5Obj = new ListClass();
        int TempInt = -1;
        int num2 = 0;
        this.OptionsList5Obj.add(" All", -2);
        if (this.detailnr == -1)
          TempInt = 0;
        int num3 = 0;
        do
        {
          if (Information.IsNothing((object) this.game.Data.TempString[num3 + 400]))
            this.game.Data.TempString[num3 + 400] = "";
          if (this.game.Data.TempString[400 + num3].Length > 1 && this.game.HandyFunctionsObj.ShowStatsOfSFTypeGroup(num3))
          {
            ++num2;
            if (this.detailnr == num3)
              TempInt = num2;
            this.OptionsList5Obj.add("* " + this.game.Data.TempString[400 + num3] + " class", num3);
          }
          ++num3;
        }
        while (num3 <= 99);
        int sfTypeCounter1 = this.game.Data.SFTypeCounter;
        for (int sfTypeNr = 0; sfTypeNr <= sfTypeCounter1; ++sfTypeNr)
        {
          if (!this.game.Data.SFTypeObj[sfTypeNr].DontShowInList & this.game.Data.SFTypeObj[sfTypeNr].Name.Length > 1 & Strings.InStr(Strings.LCase(this.game.Data.SFTypeObj[sfTypeNr].Name), Strings.LCase("N/A")) <= 0 && this.game.HandyFunctionsObj.ShowStatsOfSFType(sfTypeNr))
          {
            ++num2;
            if (this.detailnr == sfTypeNr + 1000)
              TempInt = num2;
            this.OptionsList5Obj.add(this.game.Data.SFTypeObj[sfTypeNr].Name, sfTypeNr + 1000);
          }
        }
        int tlistselect1 = this.OptionsList5Obj.SortWithRef(TempInt);
        int num4 = (int) Math.Round((double) (this.h - 90) / 16.0) - 8;
        if (this.OptionsList5id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList5id)].Refresh(this.OptionsList5Obj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
        }
        else if (this.game.Data.Product >= 7)
        {
          int tlistsize = (int) Math.Round((double) (this.h - 90) / 24.0) - 6;
          SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(this.OptionsList5Obj, tlistsize, 170, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 30), bby: 10, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
          this.OptionsList5id = this.AddSubPart(ref tsubpart2, num1 + 30, 10, 170, (tlistsize + 1) * 24, 0);
        }
        else
        {
          ListClass optionsList5Obj = this.OptionsList5Obj;
          int tlistsize = num4;
          int tlistselect2 = tlistselect1;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          int bbx = num1 + 30;
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart3 = (SubPartClass) new ListSubPartClass(optionsList5Obj, tlistsize, 170, tlistselect2, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: 10, tMarcStyle: true, overruleFont: (ref local2));
          this.OptionsList5id = this.AddSubPart(ref tsubpart3, num1 + 30, 10, 170, (num4 + 1) * 16, 0);
        }
        int tMultiplier = 100;
        bool[] flagArray1 = new bool[this.game.Data.RegimeCounter + 1];
        int regimeCounter1 = this.game.Data.RegimeCounter;
        for (int regSlot = 0; regSlot <= regimeCounter1; ++regSlot)
        {
          if (!this.game.Data.RegimeObj[regSlot].hideFromList && this.game.HandyFunctionsObj.ShowStatsOfRegime(regSlot))
          {
            if (this.game.Data.Product < 7 && !this.game.Data.RegimeObj[regSlot].Sleep)
              flagArray1[regSlot] = true;
            int round = this.game.Data.Round;
            for (int index1 = 1; index1 <= round; ++index1)
            {
              int sfTypeCounter2 = this.game.Data.SFTypeCounter;
              for (int index2 = 0; index2 <= sfTypeCounter2; ++index2)
              {
                if (this.game.Data.RegimeObj[regSlot].SLoss[index2, index1] > 0)
                  flagArray1[regSlot] = true;
                if (this.game.Data.RegimeObj[regSlot].SKills[index2, index1] > 0)
                  flagArray1[regSlot] = true;
                if (this.game.Data.RegimeObj[regSlot].SPresent[index2, index1] > 0)
                  flagArray1[regSlot] = true;
              }
            }
          }
          if (this.game.Data.Winner > -1 & this.game.Data.Product >= 7 && !this.game.Data.RegimeObj[regSlot].hideFromList)
            flagArray1[regSlot] = true;
        }
        bool[] flagArray2 = new bool[this.game.Data.SFTypeCounter + 1];
        int sfTypeCounter3 = this.game.Data.SFTypeCounter;
        for (int sfTypeNr = 0; sfTypeNr <= sfTypeCounter3; ++sfTypeNr)
        {
          if (this.game.HandyFunctionsObj.ShowStatsOfSFType(sfTypeNr))
            flagArray2[sfTypeNr] = true;
        }
        int round1 = this.game.Data.Round;
        int num5;
        int num6;
        for (int index3 = 0; index3 <= round1; ++index3)
        {
          tregcount = 0;
          int regimeCounter2 = this.game.Data.RegimeCounter;
          for (int reg2 = 0; reg2 <= regimeCounter2; ++reg2)
          {
            if (!this.game.Data.RegimeObj[reg2].hideFromList && flagArray1[reg2] && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) | !this.game.Data.FOWOn | this.game.Data.Winner > -1 | (double) this.game.Data.RuleVar[313] > 0.0)
            {
              ++tregcount;
              numArray1[index3, tregcount] = 0;
              colorArray[tregcount] = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[reg2].Red, this.game.Data.RegimeObj[reg2].Green, this.game.Data.RegimeObj[reg2].Blue);
              strArray1[tregcount] = this.game.Data.RegimeObj[reg2].Name;
              int sfTypeCounter4 = this.game.Data.SFTypeCounter;
              for (int index4 = 0; index4 <= sfTypeCounter4; ++index4)
              {
                if (flagArray2[index4])
                {
                  if (this.detailnr == -1)
                  {
                    str1 = "Total troops";
                    if (this.detailnr2 == 0)
                    {
                      int[,] numArray2 = numArray1;
                      int[,] numArray3 = numArray2;
                      int index5 = index3;
                      int index6 = index5;
                      int index7 = tregcount;
                      int index8 = index7;
                      int num7 = numArray2[index5, index7] + this.game.Data.RegimeObj[reg2].SPresent[index4, index3] * this.game.Data.SFTypeObj[index4].Ratio;
                      numArray3[index6, index8] = num7;
                    }
                    if (this.detailnr2 > 0 & index3 > 0)
                    {
                      int num8 = index3;
                      for (int index9 = 1; index9 <= num8; ++index9)
                      {
                        if (this.detailnr2 == 1)
                        {
                          int[,] numArray4 = numArray1;
                          int[,] numArray5 = numArray4;
                          int index10 = index3;
                          int index11 = index10;
                          int index12 = tregcount;
                          int index13 = index12;
                          int num9 = numArray4[index10, index12] + this.game.Data.RegimeObj[reg2].SKills[index4, index9] * this.game.Data.SFTypeObj[index4].Ratio;
                          numArray5[index11, index13] = num9;
                        }
                        if (this.detailnr2 == 2)
                        {
                          int[,] numArray6 = numArray1;
                          int[,] numArray7 = numArray6;
                          int index14 = index3;
                          int index15 = index14;
                          int index16 = tregcount;
                          int index17 = index16;
                          int num10 = numArray6[index14, index16] + this.game.Data.RegimeObj[reg2].SLoss[index4, index9] * this.game.Data.SFTypeObj[index4].Ratio;
                          numArray7[index15, index17] = num10;
                        }
                      }
                    }
                    tMultiplier = 1;
                  }
                  else if (this.detailnr < 1000)
                  {
                    str1 = "Total " + Strings.LCase(this.game.Data.TempString[400 + this.detailnr]) + " class";
                    if (this.game.Data.SFTypeObj[index4].UnitGroup == this.detailnr)
                    {
                      if (this.detailnr2 == 0)
                      {
                        int[,] numArray8 = numArray1;
                        int[,] numArray9 = numArray8;
                        int index18 = index3;
                        int index19 = index18;
                        int index20 = tregcount;
                        int index21 = index20;
                        int num11 = numArray8[index18, index20] + this.game.Data.RegimeObj[reg2].SPresent[index4, index3];
                        numArray9[index19, index21] = num11;
                      }
                      if (this.detailnr2 > 0 & index3 > 0)
                      {
                        int num12 = index3;
                        for (int index22 = 1; index22 <= num12; ++index22)
                        {
                          if (this.detailnr2 == 1)
                          {
                            int[,] numArray10 = numArray1;
                            int[,] numArray11 = numArray10;
                            int index23 = index3;
                            int index24 = index23;
                            int index25 = tregcount;
                            int index26 = index25;
                            int num13 = numArray10[index23, index25] + this.game.Data.RegimeObj[reg2].SKills[index4, index22];
                            numArray11[index24, index26] = num13;
                          }
                          if (this.detailnr2 == 2)
                          {
                            int[,] numArray12 = numArray1;
                            int[,] numArray13 = numArray12;
                            int index27 = index3;
                            int index28 = index27;
                            int index29 = tregcount;
                            int index30 = index29;
                            int num14 = numArray12[index27, index29] + this.game.Data.RegimeObj[reg2].SLoss[index4, index22];
                            numArray13[index28, index30] = num14;
                          }
                          if (this.detailnr2 == 1)
                          {
                            num5 += this.game.Data.RegimeObj[reg2].SKills[index4, index3] * this.game.Data.SFTypeObj[index4].Ratio;
                            num6 += this.game.Data.RegimeObj[reg2].SKills[index4, index3];
                          }
                          if (this.detailnr2 == 2)
                          {
                            num5 += this.game.Data.RegimeObj[reg2].SLoss[index4, index3] * this.game.Data.SFTypeObj[index4].Ratio;
                            num6 += this.game.Data.RegimeObj[reg2].SLoss[index4, index3];
                          }
                        }
                      }
                      if (this.detailnr2 == 0)
                      {
                        num5 += this.game.Data.RegimeObj[reg2].SPresent[index4, index3] * this.game.Data.SFTypeObj[index4].Ratio;
                        num6 += this.game.Data.RegimeObj[reg2].SPresent[index4, index3];
                      }
                    }
                  }
                  else if (this.detailnr >= 1000 && index4 == this.detailnr - 1000)
                  {
                    str1 = "Total " + Strings.LCase(this.game.Data.SFTypeObj[index4].Name);
                    if (this.detailnr2 == 0)
                    {
                      int[,] numArray14 = numArray1;
                      int[,] numArray15 = numArray14;
                      int index31 = index3;
                      int index32 = index31;
                      int index33 = tregcount;
                      int index34 = index33;
                      int num15 = numArray14[index31, index33] + this.game.Data.RegimeObj[reg2].SPresent[index4, index3];
                      numArray15[index32, index34] = num15;
                    }
                    if (this.detailnr2 > 0 & index3 > 0)
                    {
                      int num16 = index3;
                      for (int index35 = 1; index35 <= num16; ++index35)
                      {
                        if (this.detailnr2 == 1)
                        {
                          int[,] numArray16 = numArray1;
                          int[,] numArray17 = numArray16;
                          int index36 = index3;
                          int index37 = index36;
                          int index38 = tregcount;
                          int index39 = index38;
                          int num17 = numArray16[index36, index38] + this.game.Data.RegimeObj[reg2].SKills[index4, index35];
                          numArray17[index37, index39] = num17;
                        }
                        if (this.detailnr2 == 2)
                        {
                          int[,] numArray18 = numArray1;
                          int[,] numArray19 = numArray18;
                          int index40 = index3;
                          int index41 = index40;
                          int index42 = tregcount;
                          int index43 = index42;
                          int num18 = numArray18[index40, index42] + this.game.Data.RegimeObj[reg2].SLoss[index4, index35];
                          numArray19[index41, index43] = num18;
                        }
                      }
                    }
                    tMultiplier = this.game.Data.SFTypeObj[index4].Ratio;
                  }
                }
              }
            }
          }
        }
        if (num5 > 0)
          tMultiplier = (int) Math.Round(Conversion.Int((double) num5 / (double) num6));
        tsubpart1 = (SubPartClass) new GraphClass(this.game, numArray1, this.detailnr3 == 1, str1, tMultiplier, colorArray, strArray1, tregcount, this.w - 880 + 620 - num1, this.h - 80, ref this.OwnBitmap, num1 + 220, 0);
        this.Info1Id = this.AddSubPart(ref tsubpart1, num1 + 220, 0, this.w - 880 + 620 - num1, 330, 0);
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.detailnr2 == 0, "Troops at start of round", ref this.OwnBitmap, 30 + num1, this.h - 160);
        this.Text1Id = this.AddSubPart(ref tsubpart1, 30 + num1, this.h - 160, 35, 35, 1);
        DrawMod.DrawTextColouredMarc(ref g, "Total troops", this.game.MarcFont4, 75 + num1, this.h - 150, Color.White);
        if ((double) this.game.Data.RuleVar[976] == 0.0 | this.game.Data.RegimeCounter > 1)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.detailnr2 == 1, "How much of selected type of troops did each regime manage to take out.", ref this.OwnBitmap, 30 + num1, 300);
          this.Text2Id = this.AddSubPart(ref tsubpart1, 30 + num1, this.h - 80, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "Casualties inflicted", this.game.MarcFont4, 75 + num1, this.h - 70, Color.White);
        }
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.detailnr2 == 2, "How much of selected type of troops did each regime lose.", ref this.OwnBitmap, 30 + num1, 260);
        this.Text3Id = this.AddSubPart(ref tsubpart1, 30 + num1, this.h - 120, 35, 35, 1);
        DrawMod.DrawTextColouredMarc(ref g, "Casualties sustained", this.game.MarcFont4, 75 + num1, this.h - 110, Color.White);
      }
      string str2;
      int num19;
      if (this.subtabnr == 2)
      {
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.detailnr4 == 1, "Only Show HQs", ref this.OwnBitmap, 30 + num1, this.h - 160);
        this.Text5id = this.AddSubPart(ref tsubpart1, 30 + num1, this.h - 160, 35, 35, 1);
        DrawMod.DrawTextColouredMarc(ref g, "Only Show HQs", this.game.MarcFont4, 75 + num1, this.h - 150, Color.White);
        this.OptionsList5Obj = new ListClass();
        int tlistselect3 = -1;
        int num20 = -1;
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[404]));
        int num21 = (int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[stringListById].GetHighestValue(0)));
        object[] objArray1 = new object[num21 + 1];
        object[] objArray2 = new object[num21 + 1];
        object[] objArray3 = new object[num21 + 1];
        object[,] objArray4 = new object[this.game.Data.LocCounter + 1, num21 + 1];
        object[,] objArray5 = new object[this.game.Data.LocCounter + 1, num21 + 1];
        object[,] objArray6 = new object[this.game.Data.UnitCounter + 1, num21 + 1];
        object[,] objArray7 = new object[this.game.Data.UnitCounter + 1, num21 + 1];
        object[,] objArray8 = new object[this.game.Data.LocCounter + 1, num21 + 1];
        object[,] objArray9 = new object[this.game.Data.LocCounter + 1, num21 + 1];
        object[] objArray10 = new object[this.game.Data.LocCounter + 1];
        object[] objArray11 = new object[this.game.Data.UnitCounter + 1];
        object[] objArray12 = new object[this.game.Data.LocCounter + 1];
        object[] objArray13 = new object[this.game.Data.UnitCounter + 1];
        int num22 = num21;
        for (int index = 0; index <= num22; ++index)
        {
          objArray1[index] = (object) 0;
          objArray2[index] = (object) 0;
          objArray3[index] = (object) 0;
        }
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index44 = 0; index44 <= unitCounter1; ++index44)
        {
          int num23 = num21;
          for (int index45 = 0; index45 <= num23; ++index45)
          {
            objArray6[index44, index45] = (object) 0;
            objArray7[index44, index45] = (object) 0;
          }
        }
        int locCounter1 = this.game.Data.LocCounter;
        for (int index46 = 0; index46 <= locCounter1; ++index46)
        {
          objArray10[index46] = (object) 0;
          objArray11[index46] = (object) 0;
          objArray12[index46] = (object) 0;
          objArray13[index46] = (object) 0;
          int num24 = num21;
          for (int index47 = 0; index47 <= num24; ++index47)
          {
            objArray4[index46, index47] = (object) 0;
            objArray5[index46, index47] = (object) 0;
            objArray8[index46, index47] = (object) 0;
            objArray9[index46, index47] = (object) 0;
          }
        }
        int num25 = 0;
        int num26 = 0;
        int num27 = 0;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index48 = 0; index48 <= unitCounter2; ++index48)
        {
          if (this.game.Data.UnitObj[index48].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index48].PreDef == -1 & this.game.Data.UnitObj[index48].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index48].Historical].Type < 8)
          {
            int logCounter = this.game.Data.UnitObj[index48].LogCounter;
            for (int index49 = 0; index49 <= logCounter; ++index49)
            {
              if (this.game.Data.UnitObj[index48].LogData1[index49] > 0)
              {
                if (this.game.Data.UnitObj[index48].LogType[index49] == 202)
                {
                  ++num26;
                  object[] objArray14 = objArray2;
                  object[] objArray15 = objArray14;
                  int[] logData1_1 = this.game.Data.UnitObj[index48].LogData1;
                  int[] numArray20 = logData1_1;
                  int index50 = index49;
                  int index51 = index50;
                  int index52 = numArray20[index51];
                  object obj1 = Operators.AddObject(objArray14[logData1_1[index50]], (object) this.game.Data.UnitObj[index48].LogData3[index49]);
                  objArray15[index52] = obj1;
                  object[,] objArray16 = objArray6;
                  object[,] objArray17 = objArray16;
                  int index53 = index48;
                  int index54 = index53;
                  int[] logData1_2 = this.game.Data.UnitObj[index48].LogData1;
                  int[] numArray21 = logData1_2;
                  int index55 = index49;
                  int index56 = index55;
                  int index57 = numArray21[index56];
                  object obj2 = Operators.AddObject(objArray16[index53, logData1_2[index55]], (object) this.game.Data.UnitObj[index48].LogData3[index49]);
                  objArray17[index54, index57] = obj2;
                }
                if (this.game.Data.UnitObj[index48].LogType[index49] == 105)
                {
                  ++num26;
                  object[] objArray18 = objArray2;
                  object[] objArray19 = objArray18;
                  int[] logData1_3 = this.game.Data.UnitObj[index48].LogData1;
                  int[] numArray22 = logData1_3;
                  int index58 = index49;
                  int index59 = index58;
                  int index60 = numArray22[index59];
                  object obj3 = Operators.AddObject(objArray18[logData1_3[index58]], (object) this.game.Data.UnitObj[index48].LogData3[index49]);
                  objArray19[index60] = obj3;
                  object[,] objArray20 = objArray7;
                  object[,] objArray21 = objArray20;
                  int index61 = index48;
                  int index62 = index61;
                  int[] logData1_4 = this.game.Data.UnitObj[index48].LogData1;
                  int[] numArray23 = logData1_4;
                  int index63 = index49;
                  int index64 = index63;
                  int index65 = numArray23[index64];
                  object obj4 = Operators.AddObject(objArray20[index61, logData1_4[index63]], (object) this.game.Data.UnitObj[index48].LogData3[index49]);
                  objArray21[index62, index65] = obj4;
                }
                if (this.game.Data.UnitObj[index48].LogType[index49] == 503)
                {
                  object[] objArray22 = objArray11;
                  object[] objArray23 = objArray22;
                  int index66 = index48;
                  int index67 = index66;
                  object obj = Operators.AddObject(objArray22[index66], (object) this.game.Data.UnitObj[index48].LogData3[index49]);
                  objArray23[index67] = obj;
                }
              }
              if (this.game.Data.UnitObj[index48].LogType[index49] == 506)
              {
                object[] objArray24 = objArray13;
                object[] objArray25 = objArray24;
                int index68 = index48;
                int index69 = index68;
                object obj = Operators.AddObject(objArray24[index68], (object) this.game.Data.UnitObj[index48].LogData3[index49]);
                objArray25[index69] = obj;
              }
            }
          }
        }
        int locCounter2 = this.game.Data.LocCounter;
        for (int index70 = 0; index70 <= locCounter2; ++index70)
        {
          if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index70].X, this.game.Data.LocObj[index70].Y].Regime == this.game.Data.Turn)
          {
            int logCounter = this.game.Data.LocObj[index70].LogCounter;
            for (int index71 = 0; index71 <= logCounter; ++index71)
            {
              if (this.game.Data.LocObj[index70].LogData1[index71] > 0)
              {
                if (this.game.Data.LocObj[index70].LogType[index71] == 202)
                {
                  ++num27;
                  object[] objArray26 = objArray3;
                  object[] objArray27 = objArray26;
                  int[] logData1_5 = this.game.Data.LocObj[index70].LogData1;
                  int[] numArray24 = logData1_5;
                  int index72 = index71;
                  int index73 = index72;
                  int index74 = numArray24[index73];
                  object obj5 = Operators.AddObject(objArray26[logData1_5[index72]], (object) this.game.Data.LocObj[index70].LogData3[index71]);
                  objArray27[index74] = obj5;
                  object[,] objArray28 = objArray8;
                  object[,] objArray29 = objArray28;
                  int index75 = index70;
                  int index76 = index75;
                  int[] logData1_6 = this.game.Data.LocObj[index70].LogData1;
                  int[] numArray25 = logData1_6;
                  int index77 = index71;
                  int index78 = index77;
                  int index79 = numArray25[index78];
                  object obj6 = Operators.AddObject(objArray28[index75, logData1_6[index77]], (object) this.game.Data.LocObj[index70].LogData3[index71]);
                  objArray29[index76, index79] = obj6;
                }
                if (this.game.Data.LocObj[index70].LogType[index71] == 102)
                {
                  ++num27;
                  object[] objArray30 = objArray3;
                  object[] objArray31 = objArray30;
                  int[] logData1_7 = this.game.Data.LocObj[index70].LogData1;
                  int[] numArray26 = logData1_7;
                  int index80 = index71;
                  int index81 = index80;
                  int index82 = numArray26[index81];
                  object obj7 = Operators.AddObject(objArray30[logData1_7[index80]], (object) this.game.Data.LocObj[index70].LogData3[index71]);
                  objArray31[index82] = obj7;
                  object[,] objArray32 = objArray9;
                  object[,] objArray33 = objArray32;
                  int index83 = index70;
                  int index84 = index83;
                  int[] logData1_8 = this.game.Data.LocObj[index70].LogData1;
                  int[] numArray27 = logData1_8;
                  int index85 = index71;
                  int index86 = index85;
                  int index87 = numArray27[index86];
                  object obj8 = Operators.AddObject(objArray32[index83, logData1_8[index85]], (object) this.game.Data.LocObj[index70].LogData3[index71]);
                  objArray33[index84, index87] = obj8;
                }
                if (this.game.Data.LocObj[index70].LogType[index71] == 505)
                {
                  object[] objArray34 = objArray12;
                  object[] objArray35 = objArray34;
                  int index88 = index70;
                  int index89 = index88;
                  object obj = Operators.AddObject(objArray34[index88], (object) this.game.Data.LocObj[index70].LogData3[index71]);
                  objArray35[index89] = obj;
                }
              }
            }
          }
        }
        int locCounter3 = this.game.Data.LocCounter;
        for (int index90 = 0; index90 <= locCounter3; ++index90)
        {
          if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index90].X, this.game.Data.LocObj[index90].Y].Regime == this.game.Data.Turn)
          {
            int logCounter = this.game.Data.LocObj[index90].LogCounter;
            for (int index91 = 0; index91 <= logCounter; ++index91)
            {
              if (this.game.Data.LocObj[index90].LogData1[index91] > 0)
              {
                if (this.game.Data.LocObj[index90].LogType[index91] == 201)
                {
                  ++num25;
                  object[] objArray36 = objArray1;
                  object[] objArray37 = objArray36;
                  int[] logData1_9 = this.game.Data.LocObj[index90].LogData1;
                  int[] numArray28 = logData1_9;
                  int index92 = index91;
                  int index93 = index92;
                  int index94 = numArray28[index93];
                  object obj9 = Operators.AddObject(objArray36[logData1_9[index92]], (object) this.game.Data.LocObj[index90].LogData3[index91]);
                  objArray37[index94] = obj9;
                  object[,] objArray38 = objArray4;
                  object[,] objArray39 = objArray38;
                  int index95 = index90;
                  int index96 = index95;
                  int[] logData1_10 = this.game.Data.LocObj[index90].LogData1;
                  int[] numArray29 = logData1_10;
                  int index97 = index91;
                  int index98 = index97;
                  int index99 = numArray29[index98];
                  object obj10 = Operators.AddObject(objArray38[index95, logData1_10[index97]], (object) this.game.Data.LocObj[index90].LogData3[index91]);
                  objArray39[index96, index99] = obj10;
                }
                if (this.game.Data.LocObj[index90].LogType[index91] == 101)
                {
                  ++num25;
                  object[] objArray40 = objArray1;
                  object[] objArray41 = objArray40;
                  int[] logData1_11 = this.game.Data.LocObj[index90].LogData1;
                  int[] numArray30 = logData1_11;
                  int index100 = index91;
                  int index101 = index100;
                  int index102 = numArray30[index101];
                  object obj11 = Operators.AddObject(objArray40[logData1_11[index100]], (object) this.game.Data.LocObj[index90].LogData3[index91]);
                  objArray41[index102] = obj11;
                  object[,] objArray42 = objArray5;
                  object[,] objArray43 = objArray42;
                  int index103 = index90;
                  int index104 = index103;
                  int[] logData1_12 = this.game.Data.LocObj[index90].LogData1;
                  int[] numArray31 = logData1_12;
                  int index105 = index91;
                  int index106 = index105;
                  int index107 = numArray31[index106];
                  object obj12 = Operators.AddObject(objArray42[index103, logData1_12[index105]], (object) this.game.Data.LocObj[index90].LogData3[index91]);
                  objArray43[index104, index107] = obj12;
                }
                if (this.game.Data.LocObj[index90].LogType[index91] == 502)
                {
                  object[] objArray44 = objArray10;
                  object[] objArray45 = objArray44;
                  int index108 = index90;
                  int index109 = index108;
                  object obj = Operators.AddObject(objArray44[index108], (object) this.game.Data.LocObj[index90].LogData3[index91]);
                  objArray45[index109] = obj;
                }
              }
            }
          }
        }
        if (num25 > 0)
        {
          ++num20;
          if (this.detailnr == 200)
            tlistselect3 = num20;
          this.OptionsList5Obj.add("=== Loc Supply Logistics ===", 200);
          int num28 = num21;
          for (int idValue = 0; idValue <= num28; ++idValue)
          {
            if (Operators.ConditionalCompareObjectGreater(objArray1[idValue], (object) 0, false))
            {
              str2 = this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2);
              ++num20;
              if (this.detailnr == 200 + idValue)
                tlistselect3 = num20;
              this.OptionsList5Obj.add("Loc " + str2 + " Supply", 200 + idValue);
            }
          }
        }
        if (num26 > 0)
        {
          ++num20;
          if (this.detailnr == 300)
            tlistselect3 = num20;
          this.OptionsList5Obj.add("=== Unit Supply Logistics ===", 300);
          int num29 = num21;
          for (int idValue = 0; idValue <= num29; ++idValue)
          {
            if (Operators.ConditionalCompareObjectGreater(objArray2[idValue], (object) 0, false))
            {
              str2 = this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2);
              ++num20;
              if (this.detailnr == 300 + idValue)
                tlistselect3 = num20;
              this.OptionsList5Obj.add("Unit " + str2 + " Supply", 300 + idValue);
            }
          }
        }
        if (num27 > 0)
        {
          ++num20;
          if (this.detailnr == 500)
            tlistselect3 = num20;
          this.OptionsList5Obj.add("=== Lock pick-up Logistics ===", 500);
          int num30 = num21;
          for (int idValue = 0; idValue <= num30; ++idValue)
          {
            if (Operators.ConditionalCompareObjectGreater(objArray3[idValue], (object) 0, false))
            {
              str2 = this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2);
              ++num20;
              if (this.detailnr == 500 + idValue)
                tlistselect3 = num20;
              this.OptionsList5Obj.add("Loc " + str2 + " Pickup", 500 + idValue);
            }
          }
        }
        if ((double) this.game.Data.RuleVar[337] > 0.0)
        {
          int num31 = num20 + 1;
          if (this.detailnr == 600)
            tlistselect3 = num31;
          this.OptionsList5Obj.add("=== Replacements Logistics ===", 600);
          int num32 = num31 + 1;
          if (this.detailnr == -1)
            this.detailnr = 11;
          if (this.detailnr == 11)
            tlistselect3 = num32;
          this.OptionsList5Obj.add("Replacements received", 11);
          num20 = num32 + 1;
          if (this.detailnr == 12)
            tlistselect3 = num20;
          this.OptionsList5Obj.add("Replacements requested", 12);
          if ((double) this.game.Data.RuleVar[977] < 1.0)
          {
            ++num20;
            if (this.detailnr == 13)
              tlistselect3 = num20;
            this.OptionsList5Obj.add("Replacements returned", 13);
          }
        }
        if (num20 > -1)
        {
          int num33 = (int) Math.Round((double) (this.h - 90) / 16.0) - 8;
          if (this.OptionsList5id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList5id)].Refresh(this.OptionsList5Obj, tlistselect3);
            this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
          }
          else if (this.game.Data.Product >= 7)
          {
            int tlistsize = (int) Math.Round((double) (this.h - 90) / 24.0) - 6;
            tsubpart1 = (SubPartClass) new ListSubPartClass(this.OptionsList5Obj, tlistsize, 170, tlistselect3, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 30), bby: 10, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
            this.OptionsList5id = this.AddSubPart(ref tsubpart1, num1 + 30, 10, 170, (tlistsize + 1) * 24, 0);
          }
          else
          {
            ListClass optionsList5Obj = this.OptionsList5Obj;
            int tlistsize = num33;
            int tlistselect4 = tlistselect3;
            GameClass game = this.game;
            ref Bitmap local3 = ref this.OwnBitmap;
            int bbx = num1 + 30;
            Font font = (Font) null;
            ref Font local4 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList5Obj, tlistsize, 170, tlistselect4, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: bbx, bby: 10, tMarcStyle: true, overruleFont: (ref local4));
            this.OptionsList5id = this.AddSubPart(ref tsubpart1, num1 + 30, 10, 170, (num33 + 1) * 16, 0);
          }
        }
        if (this.detailnr == 200 | this.detailnr == 500)
        {
          this.OptionsList6Obj = new ListClass();
          int tlistselect5 = -1;
          string str3 = "---";
          int num34 = -1;
          int unitCounter3 = this.game.Data.UnitCounter;
          for (int tdata = 0; tdata <= unitCounter3; ++tdata)
          {
            if (this.detailnr4 < 1 | this.game.Data.UnitObj[tdata].IsHQ && this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[tdata].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[tdata].PreDef == -1 & this.game.Data.UnitObj[tdata].Historical > -1 && this.game.Data.UnitObj[tdata].HQ == -1 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 8)
            {
              ++num34;
              if (this.detailhisnr == -1)
                this.detailhisnr = tdata;
              if (this.detailhisnr == tdata)
                tlistselect5 = num34;
              this.OptionsList6Obj.add(this.game.Data.UnitObj[tdata].Name, tdata, tWeight: 0);
              int locCounter4 = this.game.Data.LocCounter;
              for (int index = 0; index <= locCounter4; ++index)
              {
                if (this.game.Data.LocObj[index].HQ == tdata)
                {
                  if (this.detailnr == 200)
                    str2 = objArray10[index].ToString();
                  else if (this.detailnr == 500)
                    str2 = objArray12[index].ToString();
                  ++num34;
                  if (this.detailhisnr == -1)
                    this.detailhisnr = index + 1000000;
                  if (this.detailhisnr == index + 1000000)
                    tlistselect5 = num34;
                  this.OptionsList6Obj.add(str3 + this.game.Data.LocObj[index].Name, index + 1000000, str2, tWeight: 0);
                }
              }
            }
          }
          if (num34 == -1)
          {
            this.RemoveSubPart(this.optionslist6id);
            this.optionslist6id = 0;
          }
          int num35 = (int) Math.Round((double) (this.h - 80) / 16.0) - 1;
          if (this.optionslist6id > 0)
          {
            this.SubPartList[this.SubpartNr(this.optionslist6id)].Refresh(this.OptionsList6Obj, tlistselect5);
            this.SubPartFlag[this.SubpartNr(this.optionslist6id)] = true;
          }
          else if (num34 > -1)
          {
            ListClass optionsList6Obj = this.OptionsList6Obj;
            int tlistsize = num35;
            int twidth = 320 + (int) Math.Round((double) (this.w - 880) / 2.0);
            int tlistselect6 = tlistselect5;
            GameClass game = this.game;
            int tValueWidth = 100 + (int) Math.Round((double) (this.w - 880) / 5.0);
            ref Bitmap local5 = ref this.OwnBitmap;
            int bbx = num1 + 220;
            Font font = (Font) null;
            ref Font local6 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, tlistsize, twidth, tlistselect6, game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local5), bbx: bbx, bby: 16, tMarcStyle: true, overruleFont: (ref local6));
            this.optionslist6id = this.AddSubPart(ref tsubpart1, num1 + 220, 16, 320 + (int) Math.Round((double) (this.w - 880) / 2.0), (num35 + 1) * 16, 0);
          }
          else
          {
            str2 = "No locations or SHQ";
            DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont2, num1 + 260, 90, Color.FromArgb(177, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
          if (num34 > -1)
          {
            int x1 = num1 + 220 + 10;
            DrawMod.DrawTextColouredMarc(ref g, "SHQ / LOCATION", this.game.MarcFont5, x1, 3, Color.White);
            int x2 = num1 + 220 + 320 + (int) Math.Round((double) (this.w - 880) / 2.0) - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 1.0);
            string upper = "Logistical Points used".ToUpper();
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont5, x2, 3, Color.White);
          }
        }
        if (this.detailnr >= 201 & this.detailnr <= 299)
        {
          this.OptionsList6Obj = new ListClass();
          int tlistselect7 = -1;
          string str4 = "---";
          int idValue = this.detailnr - 200;
          int num36 = -1;
          int unitCounter4 = this.game.Data.UnitCounter;
          for (int tdata = 0; tdata <= unitCounter4; ++tdata)
          {
            if (this.detailnr4 < 1 | this.game.Data.UnitObj[tdata].IsHQ && this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[tdata].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[tdata].PreDef == -1 & this.game.Data.UnitObj[tdata].Historical > -1 && this.game.Data.UnitObj[tdata].HQ == -1 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 8)
            {
              ++num36;
              if (this.detailhisnr == -1)
                this.detailhisnr = tdata;
              if (this.detailhisnr == tdata)
                tlistselect7 = num36;
              this.OptionsList6Obj.add(this.game.Data.UnitObj[tdata].Name, tdata, tWeight: 0);
              int locCounter5 = this.game.Data.LocCounter;
              for (int index = 0; index <= locCounter5; ++index)
              {
                if (this.game.Data.LocObj[index].HQ == tdata && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectGreater(objArray4[index, idValue], (object) 0, false), Operators.CompareObjectGreater(objArray4[index, idValue], (object) 0, false))))
                {
                  string tvalue2 = objArray4[index, idValue].ToString();
                  string tvalue = objArray5[index, idValue].ToString();
                  ++num36;
                  if (this.detailhisnr == -1)
                    this.detailhisnr = index + 1000000;
                  if (this.detailhisnr == index + 1000000)
                    tlistselect7 = num36;
                  this.OptionsList6Obj.add(str4 + this.game.Data.LocObj[index].Name, index + 1000000, tvalue, tvalue2, tWeight: 0);
                }
              }
            }
          }
          if (num36 == -1)
          {
            this.RemoveSubPart(this.optionslist6id);
            this.optionslist6id = 0;
          }
          int num37 = (int) Math.Round((double) (this.h - 80) / 16.0) - 1;
          if (this.optionslist6id > 0)
          {
            this.SubPartList[this.SubpartNr(this.optionslist6id)].Refresh(this.OptionsList6Obj, tlistselect7);
            this.SubPartFlag[this.SubpartNr(this.optionslist6id)] = true;
          }
          else if (num36 > -1)
          {
            ListClass optionsList6Obj = this.OptionsList6Obj;
            int tlistsize = num37;
            int twidth = 320 + (int) Math.Round((double) (this.w - 880) / 2.0);
            int tlistselect8 = tlistselect7;
            GameClass game = this.game;
            int tValueWidth = 100 + (int) Math.Round((double) (this.w - 880) / 5.0);
            ref Bitmap local7 = ref this.OwnBitmap;
            int bbx = num1 + 220;
            Font font = (Font) null;
            ref Font local8 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, tlistsize, twidth, tlistselect8, game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local7), bbx: bbx, bby: 16, tMarcStyle: true, overruleFont: (ref local8));
            this.optionslist6id = this.AddSubPart(ref tsubpart1, num1 + 220, 16, 320 + (int) Math.Round((double) (this.w - 880) / 2.0), (num37 + 1) * 16, 0);
          }
          int x3 = num1 + 220 + 10;
          str2 = this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2);
          DrawMod.DrawTextColouredMarc(ref g, "SHQ / LOCATION", this.game.MarcFont5, x3, 3, Color.White);
          int x4 = num1 + 220 + 320 + (int) Math.Round((double) (this.w - 880) / 2.0) - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          string upper1 = "requested".ToUpper();
          DrawMod.DrawTextColouredMarc(ref g, upper1, this.game.MarcFont5, x4, 3, Color.White);
          int x5 = x4 - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          string upper2 = "received".ToUpper();
          DrawMod.DrawTextColouredMarc(ref g, upper2, this.game.MarcFont5, x5, 3, Color.White);
        }
        if (this.detailnr >= 501 & this.detailnr <= 599)
        {
          this.OptionsList6Obj = new ListClass();
          int tlistselect9 = -1;
          string str5 = "---";
          int idValue = this.detailnr - 500;
          int num38 = -1;
          int unitCounter5 = this.game.Data.UnitCounter;
          for (int tdata = 0; tdata <= unitCounter5; ++tdata)
          {
            if (this.detailnr4 < 1 | this.game.Data.UnitObj[tdata].IsHQ && this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[tdata].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[tdata].PreDef == -1 & this.game.Data.UnitObj[tdata].Historical > -1 && this.game.Data.UnitObj[tdata].HQ == -1 & this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 8)
            {
              ++num38;
              if (this.detailhisnr == -1)
                this.detailhisnr = tdata;
              if (this.detailhisnr == tdata)
                tlistselect9 = num38;
              this.OptionsList6Obj.add(this.game.Data.UnitObj[tdata].Name, tdata, tWeight: 0);
              int locCounter6 = this.game.Data.LocCounter;
              for (int index = 0; index <= locCounter6; ++index)
              {
                if (this.game.Data.LocObj[index].HQ == tdata && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectGreater(objArray8[index, idValue], (object) 0, false), Operators.CompareObjectGreater(objArray8[index, idValue], (object) 0, false))))
                {
                  string tvalue2 = objArray8[index, idValue].ToString();
                  string tvalue = objArray9[index, idValue].ToString();
                  ++num38;
                  if (this.detailhisnr == -1)
                    this.detailhisnr = index + 1000000;
                  if (this.detailhisnr == index + 1000000)
                    tlistselect9 = num38;
                  this.OptionsList6Obj.add(str5 + this.game.Data.LocObj[index].Name, index + 1000000, tvalue, tvalue2, tWeight: 0);
                }
              }
            }
          }
          if (num38 == -1)
          {
            this.RemoveSubPart(this.optionslist6id);
            this.optionslist6id = 0;
          }
          int num39 = (int) Math.Round((double) (this.h - 80) / 16.0) - 1;
          if (this.optionslist6id > 0)
          {
            this.SubPartList[this.SubpartNr(this.optionslist6id)].Refresh(this.OptionsList6Obj, tlistselect9);
            this.SubPartFlag[this.SubpartNr(this.optionslist6id)] = true;
          }
          else if (num38 > -1)
          {
            ListClass optionsList6Obj = this.OptionsList6Obj;
            int tlistsize = num39;
            int twidth = 320 + (int) Math.Round((double) (this.w - 880) / 2.0);
            int tlistselect10 = tlistselect9;
            GameClass game = this.game;
            int tValueWidth = 100 + (int) Math.Round((double) (this.w - 880) / 5.0);
            ref Bitmap local9 = ref this.OwnBitmap;
            int bbx = num1 + 220;
            Font font = (Font) null;
            ref Font local10 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, tlistsize, twidth, tlistselect10, game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local9), bbx: bbx, bby: 16, tMarcStyle: true, overruleFont: (ref local10));
            this.optionslist6id = this.AddSubPart(ref tsubpart1, num1 + 220, 16, 320 + (int) Math.Round((double) (this.w - 880) / 2.0), (num39 + 1) * 16, 0);
          }
          int x6 = num1 + 220 + 10;
          str2 = this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2);
          DrawMod.DrawTextColouredMarc(ref g, "SHQ / LOCATION", this.game.MarcFont5, x6, 3, Color.White);
          int x7 = num1 + 220 + 320 + (int) Math.Round((double) (this.w - 880) / 2.0) - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          string upper3 = "offered".ToUpper();
          DrawMod.DrawTextColouredMarc(ref g, upper3, this.game.MarcFont5, x7, 3, Color.White);
          int x8 = x7 - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          string upper4 = "picked-up".ToUpper();
          DrawMod.DrawTextColouredMarc(ref g, upper4, this.game.MarcFont5, x8, 3, Color.White);
        }
        if (this.detailnr == 300 | this.detailnr == 600)
        {
          this.OptionsList6Obj = new ListClass();
          bool[] flagArray3 = new bool[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray32 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray33 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray34 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray35 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray36 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray37 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int TempInt = -1;
          int num40 = -1;
          int unitCounter6 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter6; ++unr)
          {
            if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Historical > -1 && !flagArray3[this.game.Data.UnitObj[unr].Historical])
            {
              if (this.game.Data.UnitObj[unr].IsHQ)
              {
                int num41;
                ++num41;
                numArray37[this.game.Data.UnitObj[unr].Historical] = num41;
              }
              int Left = 0;
              if (this.detailnr == 300)
              {
                if (Operators.ConditionalCompareObjectGreater(objArray11[unr], (object) 0, false))
                  Left = Conversions.ToInteger(Operators.AddObject((object) Left, objArray11[unr]));
              }
              else if (this.detailnr == 600 && Operators.ConditionalCompareObjectGreater(objArray13[unr], (object) 0, false))
                Left = Conversions.ToInteger(Operators.AddObject((object) Left, objArray13[unr]));
              int num42;
              if (Left > 0 | num42 > 0 | this.game.Data.UnitObj[unr].IsHQ)
              {
                int num43 = this.game.HandyFunctionsObj.HowmanyHQsAbove(unr);
                numArray35[this.game.Data.UnitObj[unr].Historical] = num43;
                numArray36[this.game.Data.UnitObj[unr].Historical] = this.game.HandyFunctionsObj.HowmanyHQsBelow(unr);
                flagArray3[this.game.Data.UnitObj[unr].Historical] = true;
                int[] numArray38 = numArray32;
                int[] numArray39 = numArray38;
                int historical1 = this.game.Data.UnitObj[unr].Historical;
                int index110 = historical1;
                int num44 = numArray38[historical1] + Left;
                numArray39[index110] = num44;
                int hq = this.game.Data.UnitObj[unr].HQ;
                if (hq > -1)
                {
                  int[] numArray40 = numArray33;
                  int[] numArray41 = numArray40;
                  int historical2 = this.game.Data.UnitObj[hq].Historical;
                  int index111 = historical2;
                  int num45 = numArray40[historical2] + Left;
                  numArray41[index111] = num45;
                  int[] numArray42 = numArray34;
                  int[] numArray43 = numArray42;
                  int historical3 = this.game.Data.UnitObj[hq].Historical;
                  int index112 = historical3;
                  int num46 = numArray42[historical3] + Left;
                  numArray43[index112] = num46;
                }
                if (hq > -1)
                  hq = this.game.Data.UnitObj[hq].HQ;
                for (; hq > -1; hq = this.game.Data.UnitObj[hq].HQ)
                {
                  int[] numArray44 = numArray34;
                  int[] numArray45 = numArray44;
                  int historical4 = this.game.Data.UnitObj[hq].Historical;
                  int index113 = historical4;
                  int num47 = numArray44[historical4] + Left;
                  numArray45[index113] = num47;
                }
              }
            }
          }
          bool[] flagArray4 = new bool[this.game.Data.HistoricalUnitCounter + 1];
          int unitCounter7 = this.game.Data.UnitCounter;
          for (int tdata = 0; tdata <= unitCounter7; ++tdata)
          {
            if (this.detailnr4 < 1 | this.game.Data.UnitObj[tdata].IsHQ && this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[tdata].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[tdata].PreDef == -1 & this.game.Data.UnitObj[tdata].Historical > -1 && !flagArray4[this.game.Data.UnitObj[tdata].Historical])
            {
              int num48 = numArray34[this.game.Data.UnitObj[tdata].Historical];
              int num49 = numArray33[this.game.Data.UnitObj[tdata].Historical];
              int num50 = numArray32[this.game.Data.UnitObj[tdata].Historical];
              flagArray4[this.game.Data.UnitObj[tdata].Historical] = true;
              int num51 = numArray35[this.game.Data.UnitObj[tdata].Historical];
              int num52 = num51;
              string str6;
              for (int index = 1; index <= num52; ++index)
                str6 += "---";
              num19 = 0;
              int index114 = !this.game.Data.UnitObj[tdata].IsHQ ? this.game.Data.UnitObj[tdata].HQ : tdata;
              int num53 = 1;
              if (!this.game.Data.UnitObj[tdata].IsHQ)
                num53 += 5;
              for (; index114 > -1; index114 = this.game.Data.UnitObj[index114].HQ)
              {
                int num54 = numArray36[this.game.Data.UnitObj[index114].Historical];
                int num55 = 1;
                int num56 = num54;
                for (int index115 = 0; index115 <= num56; ++index115)
                  num55 *= 1000;
                int num57 = num55 * numArray37[this.game.Data.UnitObj[index114].Historical];
                num53 += num57;
              }
              int tWeight = 0;
              str6 = "";
              int num58 = num51;
              for (int index116 = 1; index116 <= num58; ++index116)
              {
                str6 += Strings.Space(6);
                ++index114;
              }
              if (this.game.Data.UnitObj[tdata].IsHQ)
                tWeight = tWeight + 0 + num53;
              else if (this.game.Data.UnitObj[tdata].HQ > -1)
                tWeight = tWeight + 1 + num53;
              if (num48 + num49 + num50 > 0)
              {
                ++num40;
                if (this.detailhisnr == -1)
                  this.detailhisnr = tdata;
                if (this.detailhisnr == tdata)
                  TempInt = num40;
                str2 = num48.ToString();
                string str7 = num50.ToString();
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 8)
                  str7 = "n/a";
                if (Operators.CompareString(str2, "0", false) == 0)
                  str2 = "...";
                if (Operators.CompareString(str7, "0", false) == 0)
                  str7 = "...";
                if (!this.game.Data.UnitObj[tdata].IsHQ)
                  str2 = "...";
                this.OptionsList6Obj.add(str6 + this.game.Data.UnitObj[tdata].Name, tdata, str2, str7, tWeight: tWeight);
              }
            }
          }
          int tlistselect11 = this.OptionsList6Obj.SortWithRefOnWeightAndName(TempInt);
          if (num40 == -1)
          {
            this.RemoveSubPart(this.optionslist6id);
            this.optionslist6id = 0;
          }
          int num59 = (int) Math.Round((double) (this.h - 80) / 16.0) - 1;
          if (this.optionslist6id > 0)
          {
            this.SubPartList[this.SubpartNr(this.optionslist6id)].Refresh(this.OptionsList6Obj, tlistselect11);
            this.SubPartFlag[this.SubpartNr(this.optionslist6id)] = true;
          }
          else if (num40 > -1)
          {
            ListClass optionsList6Obj = this.OptionsList6Obj;
            int tlistsize = num59;
            int twidth = 320 + (int) Math.Round((double) (this.w - 880) / 2.0);
            int tlistselect12 = tlistselect11;
            GameClass game = this.game;
            int tValueWidth = 100 + (int) Math.Round((double) (this.w - 880) / 5.0);
            ref Bitmap local11 = ref this.OwnBitmap;
            int bbx = num1 + 220;
            Font font = (Font) null;
            ref Font local12 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, tlistsize, twidth, tlistselect12, game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local11), bbx: bbx, bby: 16, tMarcStyle: true, overruleFont: (ref local12));
            this.optionslist6id = this.AddSubPart(ref tsubpart1, num1 + 220, 16, 320 + (int) Math.Round((double) (this.w - 880) / 2.0), (num59 + 1) * 16, 0);
          }
          else
          {
            str2 = "No unit that received or returned replacements";
            DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont2, num1 + 260, 90, Color.FromArgb(177, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          }
          if (num40 > -1)
          {
            int x9 = num1 + 220 + 10;
            DrawMod.DrawTextColouredMarc(ref g, "UNIT", this.game.MarcFont5, x9, 3, Color.White);
            int x10 = num1 + 220 + 320 + (int) Math.Round((double) (this.w - 880) / 2.0) - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
            string upper5 = "Log. Pts".ToUpper();
            DrawMod.DrawTextColouredMarc(ref g, upper5, this.game.MarcFont5, x10, 3, Color.White);
            int x11 = x10 - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
            string upper6 = "Cumulative".ToUpper();
            DrawMod.DrawTextColouredMarc(ref g, upper6, this.game.MarcFont5, x11, 3, Color.White);
            if (this.detailhisnr > -1)
            {
              int num60 = (int) Math.Round((double) (this.h - 80) / 16.0) - 3;
              tsubpart1 = (SubPartClass) new TextButtonPartClass("GO TO UNIT", 140, "Click to center map on this unit.", ref this.OwnBitmap, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), (num60 + 2) * 16 - 7, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.text6id = this.AddSubPart(ref tsubpart1, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), (num60 + 2) * 16 - 7, 140, 40, 1);
            }
          }
        }
        if (this.detailnr >= 301 & this.detailnr <= 399)
        {
          int idValue = this.detailnr - 300;
          this.OptionsList6Obj = new ListClass();
          bool[] flagArray5 = new bool[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray46 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray47 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray48 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray49 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray50 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray51 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray52 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray53 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int[] numArray54 = new int[this.game.Data.HistoricalUnitCounter + 1];
          int TempInt = -1;
          int num61 = -1;
          int unitCounter8 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter8; ++unr)
          {
            if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Historical > -1 && !flagArray5[this.game.Data.UnitObj[unr].Historical])
            {
              if (this.game.Data.UnitObj[unr].IsHQ)
              {
                int num62;
                ++num62;
                numArray54[this.game.Data.UnitObj[unr].Historical] = num62;
              }
              int Left1 = 0;
              int Left2 = 0;
              if (Operators.ConditionalCompareObjectGreater(objArray6[unr, idValue], (object) 0, false))
                Left1 = Conversions.ToInteger(Operators.AddObject((object) Left1, objArray6[unr, idValue]));
              if (Operators.ConditionalCompareObjectGreater(objArray6[unr, idValue], (object) 0, false))
                Left2 = Conversions.ToInteger(Operators.AddObject((object) Left2, objArray7[unr, idValue]));
              if (Left1 > 0 | Left2 > 0 | this.game.Data.UnitObj[unr].IsHQ)
              {
                int num63 = this.game.HandyFunctionsObj.HowmanyHQsAbove(unr);
                numArray52[this.game.Data.UnitObj[unr].Historical] = num63;
                numArray53[this.game.Data.UnitObj[unr].Historical] = this.game.HandyFunctionsObj.HowmanyHQsBelow(unr);
                flagArray5[this.game.Data.UnitObj[unr].Historical] = true;
                int[] numArray55 = numArray46;
                int[] numArray56 = numArray55;
                int historical5 = this.game.Data.UnitObj[unr].Historical;
                int index117 = historical5;
                int num64 = numArray55[historical5] + Left1;
                numArray56[index117] = num64;
                int[] numArray57 = numArray47;
                int[] numArray58 = numArray57;
                int historical6 = this.game.Data.UnitObj[unr].Historical;
                int index118 = historical6;
                int num65 = numArray57[historical6] + Left2;
                numArray58[index118] = num65;
                int hq = this.game.Data.UnitObj[unr].HQ;
                if (hq > -1)
                {
                  int[] numArray59 = numArray48;
                  int[] numArray60 = numArray59;
                  int historical7 = this.game.Data.UnitObj[hq].Historical;
                  int index119 = historical7;
                  int num66 = numArray59[historical7] + Left1;
                  numArray60[index119] = num66;
                  int[] numArray61 = numArray49;
                  int[] numArray62 = numArray61;
                  int historical8 = this.game.Data.UnitObj[hq].Historical;
                  int index120 = historical8;
                  int num67 = numArray61[historical8] + Left1;
                  numArray62[index120] = num67;
                  int[] numArray63 = numArray50;
                  int[] numArray64 = numArray63;
                  int historical9 = this.game.Data.UnitObj[hq].Historical;
                  int index121 = historical9;
                  int num68 = numArray63[historical9] + Left2;
                  numArray64[index121] = num68;
                  int[] numArray65 = numArray51;
                  int[] numArray66 = numArray65;
                  int historical10 = this.game.Data.UnitObj[hq].Historical;
                  int index122 = historical10;
                  int num69 = numArray65[historical10] + Left2;
                  numArray66[index122] = num69;
                }
                if (hq > -1)
                  hq = this.game.Data.UnitObj[hq].HQ;
                for (; hq > -1; hq = this.game.Data.UnitObj[hq].HQ)
                {
                  int[] numArray67 = numArray49;
                  int[] numArray68 = numArray67;
                  int historical11 = this.game.Data.UnitObj[hq].Historical;
                  int index123 = historical11;
                  int num70 = numArray67[historical11] + Left1;
                  numArray68[index123] = num70;
                  int[] numArray69 = numArray51;
                  int[] numArray70 = numArray69;
                  int historical12 = this.game.Data.UnitObj[hq].Historical;
                  int index124 = historical12;
                  int num71 = numArray69[historical12] + Left2;
                  numArray70[index124] = num71;
                }
              }
            }
          }
          bool[] flagArray6 = new bool[this.game.Data.HistoricalUnitCounter + 1];
          int unitCounter9 = this.game.Data.UnitCounter;
          for (int tdata = 0; tdata <= unitCounter9; ++tdata)
          {
            if (this.detailnr4 < 1 | this.game.Data.UnitObj[tdata].IsHQ && this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[tdata].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[tdata].PreDef == -1 & this.game.Data.UnitObj[tdata].Historical > -1 && !flagArray6[this.game.Data.UnitObj[tdata].Historical])
            {
              int num72 = numArray49[this.game.Data.UnitObj[tdata].Historical];
              int num73 = numArray48[this.game.Data.UnitObj[tdata].Historical];
              int num74 = numArray46[this.game.Data.UnitObj[tdata].Historical];
              int num75 = numArray51[this.game.Data.UnitObj[tdata].Historical];
              int num76 = numArray50[this.game.Data.UnitObj[tdata].Historical];
              int num77 = numArray47[this.game.Data.UnitObj[tdata].Historical];
              flagArray6[this.game.Data.UnitObj[tdata].Historical] = true;
              int num78 = numArray52[this.game.Data.UnitObj[tdata].Historical];
              int num79 = num78;
              string str8;
              for (int index = 1; index <= num79; ++index)
                str8 += "---";
              num19 = 0;
              int index125 = !this.game.Data.UnitObj[tdata].IsHQ ? this.game.Data.UnitObj[tdata].HQ : tdata;
              int num80 = 1;
              if (!this.game.Data.UnitObj[tdata].IsHQ)
                num80 += 5;
              for (; index125 > -1; index125 = this.game.Data.UnitObj[index125].HQ)
              {
                int num81 = numArray53[this.game.Data.UnitObj[index125].Historical];
                int num82 = 1;
                int num83 = num81;
                for (int index126 = 0; index126 <= num83; ++index126)
                  num82 *= 1000;
                int num84 = num82 * numArray54[this.game.Data.UnitObj[index125].Historical];
                num80 += num84;
              }
              int tWeight = 0;
              str8 = "";
              int num85 = num78;
              for (int index127 = 1; index127 <= num85; ++index127)
              {
                str8 += Strings.Space(6);
                ++index125;
              }
              if (this.game.Data.UnitObj[tdata].IsHQ)
                tWeight = tWeight + 0 + num80;
              else if (this.game.Data.UnitObj[tdata].HQ > -1)
                tWeight = tWeight + 1 + num80;
              if (num72 + num73 + num74 + num75 + num76 + num77 > 0)
              {
                ++num61;
                if (this.detailhisnr == -1)
                  this.detailhisnr = tdata;
                if (this.detailhisnr == tdata)
                  TempInt = num61;
                string str9 = num75.ToString() + "/" + num72.ToString();
                string str10 = num77.ToString() + "/" + num74.ToString();
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 8)
                  str10 = "n/a";
                if (Operators.CompareString(str9, "0/0", false) == 0)
                  str9 = "...";
                if (Operators.CompareString(str10, "0/0", false) == 0)
                  str10 = "...";
                if (!this.game.Data.UnitObj[tdata].IsHQ)
                  str9 = "...";
                this.OptionsList6Obj.add(str8 + this.game.Data.UnitObj[tdata].Name, tdata, str9, str10, tWeight: tWeight);
              }
            }
          }
          int tlistselect13 = this.OptionsList6Obj.SortWithRefOnWeightAndName(TempInt);
          if (num61 == -1)
          {
            this.RemoveSubPart(this.optionslist6id);
            this.optionslist6id = 0;
          }
          int num86 = (int) Math.Round((double) (this.h - 80) / 16.0) - 1;
          if (this.optionslist6id > 0)
          {
            this.SubPartList[this.SubpartNr(this.optionslist6id)].Refresh(this.OptionsList6Obj, tlistselect13);
            this.SubPartFlag[this.SubpartNr(this.optionslist6id)] = true;
          }
          else if (num61 > -1)
          {
            ListClass optionsList6Obj = this.OptionsList6Obj;
            int tlistsize = num86;
            int twidth = 320 + (int) Math.Round((double) (this.w - 880) / 2.0);
            int tlistselect14 = tlistselect13;
            GameClass game = this.game;
            int tValueWidth = 100 + (int) Math.Round((double) (this.w - 880) / 5.0);
            ref Bitmap local13 = ref this.OwnBitmap;
            int bbx = num1 + 220;
            Font font = (Font) null;
            ref Font local14 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, tlistsize, twidth, tlistselect14, game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local13), bbx: bbx, bby: 16, tMarcStyle: true, overruleFont: (ref local14));
            this.optionslist6id = this.AddSubPart(ref tsubpart1, num1 + 220, 16, 320 + (int) Math.Round((double) (this.w - 880) / 2.0), (num86 + 1) * 16, 0);
          }
          int x12 = num1 + 220 + 10;
          str2 = this.game.Data.StringListObj[stringListById].GetData(0, idValue, 2);
          DrawMod.DrawTextColouredMarc(ref g, "UNIT", this.game.MarcFont5, x12, 3, Color.White);
          int x13 = num1 + 220 + 320 + (int) Math.Round((double) (this.w - 880) / 2.0) - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          string upper7 = "rec/req".ToUpper();
          DrawMod.DrawTextColouredMarc(ref g, upper7, this.game.MarcFont5, x13, 3, Color.White);
          int x14 = x13 - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          string upper8 = "cumulative".ToUpper();
          DrawMod.DrawTextColouredMarc(ref g, upper8, this.game.MarcFont5, x14, 3, Color.White);
          if (this.detailhisnr > -1)
          {
            int num87 = (int) Math.Round((double) (this.h - 80) / 16.0) - 3;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("GO TO UNIT", 140, "Click to center map on this unit.", ref this.OwnBitmap, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), (num87 + 2) * 16 - 7, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.text6id = this.AddSubPart(ref tsubpart1, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), (num87 + 2) * 16 - 7, 140, 40, 1);
          }
        }
      }
      if (this.subtabnr == 1)
      {
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.detailnr4 == 1, "Only Show HQs", ref this.OwnBitmap, 30 + num1, this.h - 160);
        this.Text5id = this.AddSubPart(ref tsubpart1, 30 + num1, this.h - 160, 35, 35, 1);
        DrawMod.DrawTextColouredMarc(ref g, "Only Show HQs", this.game.MarcFont4, 75 + num1, this.h - 150, Color.White);
        this.OptionsList5Obj = new ListClass();
        int tlistselect15 = -1;
        int index128 = -1;
        int tdata = 0;
        do
        {
          if ((double) this.game.Data.RuleVar[650 + tdata] > 0.0)
          {
            ++index128;
            if (this.detailnr == -1)
              this.detailnr = tdata;
            if (this.detailnr == tdata)
              tlistselect15 = index128;
            this.OptionsList5Obj.add(this.game.Data.TempString[700 + tdata], tdata);
          }
          ++tdata;
        }
        while (tdata <= 2);
        if ((double) this.game.Data.RuleVar[403] < 1.0)
        {
          if ((double) this.game.Data.RuleVar[337] > 0.0)
          {
            int num88 = index128 + 1;
            if (this.detailnr == -1)
              this.detailnr = 11;
            if (this.detailnr == 11)
              tlistselect15 = num88;
            this.OptionsList5Obj.add("Replacements received", 11);
            index128 = num88 + 1;
            if (this.detailnr == 12)
              tlistselect15 = index128;
            this.OptionsList5Obj.add("Replacements requested", 12);
            if ((double) this.game.Data.RuleVar[977] < 1.0)
            {
              ++index128;
              if (this.detailnr == 13)
                tlistselect15 = index128;
              this.OptionsList5Obj.add("Replacements returned", 13);
            }
          }
          if ((double) this.game.Data.RuleVar[499] > 0.0 & (double) this.game.Data.RuleVar[957] > 0.0)
          {
            int num89 = index128 + 1;
            if (this.detailnr == 14)
              tlistselect15 = num89;
            this.OptionsList5Obj.add("Unit Supply Logbook", 14);
            index128 = num89 + 1;
            if (this.detailnr == 15)
              tlistselect15 = index128;
            this.OptionsList5Obj.add("Unit Fuel Logbook", 15);
          }
        }
        if ((double) this.game.Data.RuleVar[957] > 0.0)
        {
          int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[957]));
          if (stringListById > -1)
          {
            int length = this.game.Data.StringListObj[stringListById].Length;
            for (int index129 = 0; index129 <= length; ++index129)
            {
              string str11 = this.game.Data.StringListObj[stringListById].Data[index129, 0];
              int num90 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index129, 1]));
              bool flag = true;
              if (num90 == this.game.Data.Turn && !Information.IsNothing((object) str11) && str11.Length > 0)
              {
                int num91 = index129 - 1;
                for (int index130 = 0; index130 <= num91; ++index130)
                {
                  string Left = this.game.Data.StringListObj[stringListById].Data[index130, 0];
                  if (this.game.Data.Product < 6)
                  {
                    if (Operators.CompareString(Left, str11, false) == 0)
                    {
                      flag = false;
                      break;
                    }
                  }
                  else
                  {
                    int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index130, 1]);
                    if (Operators.CompareString(Left, str11, false) == 0 & integer == num90)
                    {
                      flag = false;
                      break;
                    }
                  }
                }
                if (flag)
                {
                  ++index128;
                  if (this.game.Data.Product == 7 && Strings.InStr(str11, "<REGIMES>") > 0)
                    str11 = str11.Replace("<REGIMES>", "");
                  if (this.detailnr == -1)
                    this.detailnr = 100 + index129;
                  if (this.detailnr == 100 + index129)
                    tlistselect15 = index128;
                  this.OptionsList5Obj.add(str11, 100 + index129);
                }
              }
            }
          }
        }
        if (index128 > -1)
        {
          int num92 = (int) Math.Round((double) (this.h - 90) / 16.0) - 8;
          if (this.OptionsList5id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList5id)].Refresh(this.OptionsList5Obj, tlistselect15);
            this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
          }
          else if (this.game.Data.Product >= 7)
          {
            int tlistsize = (int) Math.Round((double) (this.h - 90) / 24.0) - 6;
            tsubpart1 = (SubPartClass) new ListSubPartClass(this.OptionsList5Obj, tlistsize, 170, tlistselect15, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 30), bby: 10, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
            this.OptionsList5id = this.AddSubPart(ref tsubpart1, num1 + 30, 10, 170, (tlistsize + 1) * 24, 0);
          }
          else
          {
            ListClass optionsList5Obj = this.OptionsList5Obj;
            int tlistsize = num92;
            int tlistselect16 = tlistselect15;
            GameClass game = this.game;
            ref Bitmap local15 = ref this.OwnBitmap;
            int bbx = num1 + 30;
            Font font = (Font) null;
            ref Font local16 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList5Obj, tlistsize, 170, tlistselect16, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local15), bbx: bbx, bby: 10, tMarcStyle: true, overruleFont: (ref local16));
            this.OptionsList5id = this.AddSubPart(ref tsubpart1, num1 + 30, 10, 170, (num92 + 1) * 16, 0);
          }
        }
        if (this.detailnr >= 100 & (double) this.game.Data.RuleVar[957] > 0.0)
        {
          int index131 = this.detailnr - 100;
          int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[957]));
          string Left3 = this.game.Data.StringListObj[stringListById].Data[index131, 0];
          tregcount = 0;
          str1 = Left3;
          int tMultiplier = 1;
          bool flag1 = false;
          if (this.game.Data.Product == 7 && Strings.InStr(str1, "<REGIMES>") > 0)
          {
            str1 = str1.Replace("<REGIMES>", "");
            flag1 = true;
          }
          int length1 = this.game.Data.StringListObj[stringListById].Length;
          for (int index132 = 0; index132 <= length1; ++index132)
          {
            string Right = this.game.Data.StringListObj[stringListById].Data[index132, 0];
            int integer1 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index132, 1]);
            if (Operators.CompareString(Left3, Right, false) == 0 & integer1 == this.game.Data.Turn)
            {
              string str12 = this.game.Data.StringListObj[stringListById].Data[index132, 2];
              bool flag2 = true;
              if (!Information.IsNothing((object) str12) & str12.Length > 0)
              {
                int num93 = index132 - 1;
                for (index128 = 0; index128 <= num93; ++index128)
                {
                  string Left4 = this.game.Data.StringListObj[stringListById].Data[index128, 2];
                  string Left5 = this.game.Data.StringListObj[stringListById].Data[index128, 0];
                  if (Operators.CompareString(Left4, str12, false) == 0 && Operators.CompareString(Left5, Right, false) == 0 & integer1 == this.game.Data.Turn)
                  {
                    if (this.game.Data.Product < 6)
                    {
                      flag2 = false;
                      break;
                    }
                    int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index128, 1]);
                    if (Operators.CompareString(Left5, Right, false) == 0 & integer2 == integer1 & integer1 == this.game.Data.Turn)
                    {
                      flag2 = false;
                      break;
                    }
                  }
                }
                if (flag2 & flag1)
                {
                  int regimeCounter = this.game.Data.RegimeCounter;
                  for (int regSlot = 0; regSlot <= regimeCounter; ++regSlot)
                  {
                    if (Operators.CompareString(this.game.Data.RegimeObj[regSlot].Name, str12, false) == 0 && !this.game.HandyFunctionsObj.ShowStatsOfRegime(regSlot))
                      flag2 = false;
                  }
                }
                if (flag2)
                {
                  ++tregcount;
                  colorArray = (Color[]) Utils.CopyArray((Array) colorArray, (Array) new Color[tregcount + 1]);
                  strArray1 = (string[]) Utils.CopyArray((Array) strArray1, (Array) new string[tregcount + 1]);
                  if (tregcount == 1)
                    colorArray[tregcount] = Color.White;
                  if (tregcount == 2)
                    colorArray[tregcount] = Color.Salmon;
                  if (tregcount == 3)
                    colorArray[tregcount] = Color.FromArgb((int) byte.MaxValue, 50, 180, 180);
                  if (tregcount == 4)
                    colorArray[tregcount] = Color.LightGreen;
                  if (tregcount == 5)
                    colorArray[tregcount] = Color.Orange;
                  if (tregcount == 6)
                    colorArray[tregcount] = Color.Yellow;
                  if (tregcount == 7)
                    colorArray[tregcount] = Color.Pink;
                  if (tregcount == 8)
                    colorArray[tregcount] = Color.Brown;
                  if (tregcount == 9)
                    colorArray[tregcount] = Color.Blue;
                  if (tregcount == 10)
                    colorArray[tregcount] = Color.Indigo;
                  if (tregcount > 10)
                    colorArray[tregcount] = Color.LightGray;
                  strArray1[tregcount] = str12;
                }
              }
            }
          }
          if (tregcount > 0)
          {
            numArray1 = new int[this.game.Data.Round + 1, tregcount + 1];
            bool flag3 = false;
            if (this.game.Data.Product == 7 && Operators.CompareString(str1, "Comparative Victory Score", false) == 0)
              flag3 = true;
            if (this.game.Data.Product == 7 & (flag1 | flag3))
            {
              int round = this.game.Data.Round;
              for (int index133 = 0; index133 <= round; ++index133)
              {
                int num94 = tregcount;
                for (index128 = 0; index128 <= num94; ++index128)
                  numArray1[index133, index128] = -1;
              }
            }
            int length2 = this.game.Data.StringListObj[stringListById].Length;
            for (int index134 = 0; index134 <= length2; ++index134)
            {
              string Right1 = this.game.Data.StringListObj[stringListById].Data[index134, 0];
              int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index134, 1]);
              int num95 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index134, 3]));
              if (Operators.CompareString(Left3, Right1, false) == 0 & integer == this.game.Data.Turn & num95 <= this.game.Data.Round)
              {
                string Right2 = this.game.Data.StringListObj[stringListById].Data[index134, 2];
                int num96 = tregcount;
                for (index128 = 1; index128 <= num96; ++index128)
                {
                  if (Operators.CompareString(strArray1[index128], Right2, false) == 0)
                  {
                    int num97 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index134, 4]));
                    if (num97 > -1000000)
                    {
                      int[,] numArray71 = numArray1;
                      int[,] numArray72 = numArray71;
                      int index135 = num95;
                      int index136 = index135;
                      int index137 = index128;
                      int index138 = index137;
                      int num98 = numArray71[index135, index137] + num97;
                      numArray72[index136, index138] = num98;
                    }
                  }
                }
              }
            }
            if (this.game.Data.Product == 7 & (flag1 | flag3))
            {
              if (this.game.Data.Round == 1)
              {
                int num99 = 0;
                int num100 = tregcount;
                for (index128 = 0; index128 <= num100; ++index128)
                {
                  if (numArray1[this.game.Data.Round, index128] == -1)
                  {
                    num99 = index128 - 1;
                    break;
                  }
                }
                if (num99 >= 0)
                  numArray1 = (int[,]) Utils.CopyArray((Array) numArray1, (Array) new int[this.game.Data.Round + 1, num99 + 1]);
              }
              else
              {
                for (int round = this.game.Data.Round; round >= 0; round += -1)
                {
                  int num101 = tregcount;
                  for (index128 = 0; index128 <= num101; ++index128)
                  {
                    if (numArray1[round, index128] == -1 & round > 0)
                      numArray1[round, index128] = numArray1[round - 1, index128];
                  }
                }
              }
            }
            tsubpart1 = (SubPartClass) new GraphClass(this.game, numArray1, this.detailnr3 == 1, str1, tMultiplier, colorArray, strArray1, tregcount, this.w - 880 + 620 - num1, this.h - 80, ref this.OwnBitmap, num1 + 220, 0, false);
            this.Info1Id = this.AddSubPart(ref tsubpart1, num1 + 220, 0, this.w - 880 + 620 - num1, 330, 0);
          }
        }
        if (this.detailnr <= 9 & index128 > -1)
        {
          bool[] flagArray = new bool[this.game.Data.RegimeCounter + 1];
          int regimeCounter3 = this.game.Data.RegimeCounter;
          for (int index139 = 0; index139 <= regimeCounter3; ++index139)
          {
            if (!this.game.Data.RegimeObj[index139].hideFromList)
            {
              int round = this.game.Data.Round;
              for (int index140 = 1; index140 <= round; ++index140)
              {
                try
                {
                  if (this.game.Data.RegimeObj[index139].ExtraStat[index139, index140] > 0)
                    flagArray[index139] = true;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  flagArray[index139] = false;
                  ProjectData.ClearProjectError();
                }
              }
            }
          }
          int round2 = this.game.Data.Round;
          for (int index141 = 0; index141 <= round2; ++index141)
          {
            tregcount = 0;
            int regimeCounter4 = this.game.Data.RegimeCounter;
            for (int reg2 = 0; reg2 <= regimeCounter4; ++reg2)
            {
              if (!this.game.Data.RegimeObj[reg2].hideFromList && !this.game.Data.RegimeObj[reg2].Sleep | flagArray[reg2] && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) | !this.game.Data.FOWOn | this.game.Data.Winner > -1 | (double) this.game.Data.RuleVar[313] > 0.0)
              {
                ++tregcount;
                numArray1[index141, tregcount] = 0;
                colorArray[tregcount] = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[reg2].Red, this.game.Data.RegimeObj[reg2].Green, this.game.Data.RegimeObj[reg2].Blue);
                strArray1[tregcount] = this.game.Data.RegimeObj[reg2].Name;
                str1 = this.game.Data.TempString[700 + this.detailnr];
                int[,] numArray73 = numArray1;
                int[,] numArray74 = numArray73;
                int index142 = index141;
                int index143 = index142;
                int index144 = tregcount;
                int index145 = index144;
                int num102 = numArray73[index142, index144] + this.game.Data.RegimeObj[reg2].ExtraStat[this.detailnr, index141];
                numArray74[index143, index145] = num102;
              }
            }
          }
          int tMultiplier = 1;
          tsubpart1 = (SubPartClass) new GraphClass(this.game, numArray1, this.detailnr3 == 1, str1, tMultiplier, colorArray, strArray1, tregcount, this.w - 880 + 620 - num1, this.h - 80, ref this.OwnBitmap, num1 + 220, 0);
          this.Info1Id = this.AddSubPart(ref tsubpart1, num1 + 220, 0, this.w - 880 + 620 - num1, 330, 0);
        }
      }
      if (this.subtabnr == 1 & (double) this.game.Data.RuleVar[403] < 1.0 | this.subtabnr == 2 & (double) this.game.Data.RuleVar[403] > 0.0 && this.detailnr >= 11 & this.detailnr <= 13 | this.detailnr >= 14 & this.detailnr <= 15 & (double) this.game.Data.RuleVar[499] > 0.0)
      {
        this.OptionsList6Obj = new ListClass();
        bool[] flagArray7 = new bool[this.game.Data.HistoricalUnitCounter + 1];
        int[] numArray75 = new int[this.game.Data.HistoricalUnitCounter + 1];
        int[] numArray76 = new int[this.game.Data.HistoricalUnitCounter + 1];
        int[] numArray77 = new int[this.game.Data.HistoricalUnitCounter + 1];
        int[] numArray78 = new int[this.game.Data.HistoricalUnitCounter + 1];
        int[] numArray79 = new int[this.game.Data.HistoricalUnitCounter + 1];
        int[] numArray80 = new int[this.game.Data.HistoricalUnitCounter + 1];
        int[,] numArray81 = new int[this.game.Data.HistoricalUnitCounter + 1, this.game.Data.ReinfCounter + 1 + 1];
        int[,] numArray82 = new int[this.game.Data.HistoricalUnitCounter + 1, this.game.Data.ReinfCounter + 1 + 1];
        int TempInt = -1;
        int num103 = -1;
        if (this.detailnr >= 11 & this.detailnr <= 15)
        {
          int unitCounter10 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter10; ++unr)
          {
            if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Historical > -1 && !flagArray7[this.game.Data.UnitObj[unr].Historical])
            {
              if (this.game.Data.UnitObj[unr].IsHQ)
              {
                int num104;
                ++num104;
                numArray80[this.game.Data.UnitObj[unr].Historical] = num104;
              }
              int num105 = 0;
              int unitCounter11 = this.game.Data.UnitCounter;
              for (int index146 = 0; index146 <= unitCounter11; ++index146)
              {
                if (this.game.Data.UnitObj[index146].PreDef == -1 & this.game.Data.UnitObj[index146].Historical == this.game.Data.UnitObj[unr].Historical)
                {
                  int logCounter = this.game.Data.UnitObj[index146].LogCounter;
                  for (int index147 = 0; index147 <= logCounter; ++index147)
                  {
                    if (this.detailnr == 11)
                    {
                      if (this.game.Data.UnitObj[index146].LogType[index147] == 2 & this.game.Data.UnitObj[index146].LogData1[index147] > -1)
                      {
                        num105 += this.game.Data.UnitObj[index146].LogData3[index147];
                        int[,] numArray83 = numArray82;
                        int[,] numArray84 = numArray83;
                        int historical = this.game.Data.UnitObj[index146].Historical;
                        int index148 = historical;
                        int[] logData1 = this.game.Data.UnitObj[index146].LogData1;
                        int[] numArray85 = logData1;
                        int index149 = index147;
                        int index150 = index149;
                        int index151 = numArray85[index150];
                        int num106 = numArray83[historical, logData1[index149]] + this.game.Data.UnitObj[index146].LogData3[index147];
                        numArray84[index148, index151] = num106;
                      }
                    }
                    else if (this.detailnr == 12)
                    {
                      if (this.game.Data.UnitObj[index146].LogType[index147] == 1 & this.game.Data.UnitObj[index146].LogData1[index147] > -1)
                      {
                        num105 += this.game.Data.UnitObj[index146].LogData3[index147];
                        int[,] numArray86 = numArray82;
                        int[,] numArray87 = numArray86;
                        int historical = this.game.Data.UnitObj[index146].Historical;
                        int index152 = historical;
                        int[] logData1 = this.game.Data.UnitObj[index146].LogData1;
                        int[] numArray88 = logData1;
                        int index153 = index147;
                        int index154 = index153;
                        int index155 = numArray88[index154];
                        int num107 = numArray86[historical, logData1[index153]] + this.game.Data.UnitObj[index146].LogData3[index147];
                        numArray87[index152, index155] = num107;
                      }
                    }
                    else if (this.detailnr == 13 && this.game.Data.UnitObj[index146].LogType[index147] == 3 & this.game.Data.UnitObj[index146].LogData1[index147] > -1)
                    {
                      num105 += this.game.Data.UnitObj[index146].LogData3[index147];
                      int[,] numArray89 = numArray82;
                      int[,] numArray90 = numArray89;
                      int historical = this.game.Data.UnitObj[index146].Historical;
                      int index156 = historical;
                      int[] logData1 = this.game.Data.UnitObj[index146].LogData1;
                      int[] numArray91 = logData1;
                      int index157 = index147;
                      int index158 = index157;
                      int index159 = numArray91[index158];
                      int num108 = numArray89[historical, logData1[index157]] + this.game.Data.UnitObj[index146].LogData3[index147];
                      numArray90[index156, index159] = num108;
                    }
                  }
                }
              }
              if (num105 > 0 | this.game.Data.UnitObj[unr].IsHQ | this.detailnr >= 14 & this.detailnr <= 15)
              {
                int num109 = this.game.HandyFunctionsObj.HowmanyHQsAbove(unr);
                numArray78[this.game.Data.UnitObj[unr].Historical] = num109;
                numArray79[this.game.Data.UnitObj[unr].Historical] = this.game.HandyFunctionsObj.HowmanyHQsBelow(unr);
                flagArray7[this.game.Data.UnitObj[unr].Historical] = true;
                int[] numArray92 = numArray75;
                int[] numArray93 = numArray92;
                int historical13 = this.game.Data.UnitObj[unr].Historical;
                int index160 = historical13;
                int num110 = numArray92[historical13] + num105;
                numArray93[index160] = num110;
                int hq = this.game.Data.UnitObj[unr].HQ;
                if (hq > -1)
                {
                  int[] numArray94 = numArray76;
                  int[] numArray95 = numArray94;
                  int historical14 = this.game.Data.UnitObj[hq].Historical;
                  int index161 = historical14;
                  int num111 = numArray94[historical14] + num105;
                  numArray95[index161] = num111;
                  int num112 = this.game.Data.ReinfCounter + 1;
                  for (int index162 = 0; index162 <= num112; ++index162)
                  {
                    int[,] numArray96 = numArray81;
                    int[,] numArray97 = numArray96;
                    int historical15 = this.game.Data.UnitObj[hq].Historical;
                    int index163 = historical15;
                    int index164 = index162;
                    int index165 = index164;
                    int num113 = numArray96[historical15, index164] + numArray82[this.game.Data.UnitObj[unr].Historical, index162];
                    numArray97[index163, index165] = num113;
                  }
                  int[] numArray98 = numArray77;
                  int[] numArray99 = numArray98;
                  int historical16 = this.game.Data.UnitObj[hq].Historical;
                  int index166 = historical16;
                  int num114 = numArray98[historical16] + num105;
                  numArray99[index166] = num114;
                }
                if (hq > -1)
                  hq = this.game.Data.UnitObj[hq].HQ;
                for (; hq > -1; hq = this.game.Data.UnitObj[hq].HQ)
                {
                  int num115 = this.game.Data.ReinfCounter + 1;
                  for (int index167 = 0; index167 <= num115; ++index167)
                  {
                    int[,] numArray100 = numArray81;
                    int[,] numArray101 = numArray100;
                    int historical17 = this.game.Data.UnitObj[hq].Historical;
                    int index168 = historical17;
                    int index169 = index167;
                    int index170 = index169;
                    int num116 = numArray100[historical17, index169] + numArray82[this.game.Data.UnitObj[unr].Historical, index167];
                    numArray101[index168, index170] = num116;
                  }
                  int[] numArray102 = numArray77;
                  int[] numArray103 = numArray102;
                  int historical18 = this.game.Data.UnitObj[hq].Historical;
                  int index171 = historical18;
                  int num117 = numArray102[historical18] + num105;
                  numArray103[index171] = num117;
                }
              }
            }
          }
          bool[] flagArray8 = new bool[this.game.Data.HistoricalUnitCounter + 1];
          int unitCounter12 = this.game.Data.UnitCounter;
          for (int tdata = 0; tdata <= unitCounter12; ++tdata)
          {
            if (this.detailnr4 < 1 | this.game.Data.UnitObj[tdata].IsHQ && this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[tdata].Regime) == this.game.HandyFunctionsObj.GetRegime(this.game.Data.Turn) && this.game.Data.UnitObj[tdata].PreDef == -1 & this.game.Data.UnitObj[tdata].Historical > -1 && !flagArray8[this.game.Data.UnitObj[tdata].Historical])
            {
              int num118 = numArray77[this.game.Data.UnitObj[tdata].Historical];
              int num119 = numArray76[this.game.Data.UnitObj[tdata].Historical];
              int num120 = numArray75[this.game.Data.UnitObj[tdata].Historical];
              flagArray8[this.game.Data.UnitObj[tdata].Historical] = true;
              int num121 = numArray78[this.game.Data.UnitObj[tdata].Historical];
              int num122 = num121;
              string str13;
              for (int index = 1; index <= num122; ++index)
                str13 += "---";
              num19 = 0;
              int index172 = !this.game.Data.UnitObj[tdata].IsHQ ? this.game.Data.UnitObj[tdata].HQ : tdata;
              int num123 = 1;
              if (!this.game.Data.UnitObj[tdata].IsHQ)
                num123 += 5;
              for (; index172 > -1; index172 = this.game.Data.UnitObj[index172].HQ)
              {
                int num124 = numArray79[this.game.Data.UnitObj[index172].Historical];
                int num125 = 1;
                int num126 = num124;
                for (int index173 = 0; index173 <= num126; ++index173)
                  num125 *= 1000;
                int num127 = num125 * numArray80[this.game.Data.UnitObj[index172].Historical];
                num123 += num127;
              }
              int tWeight = 0;
              str13 = "";
              int num128 = num121;
              for (int index174 = 1; index174 <= num128; ++index174)
              {
                str13 += Strings.Space(6);
                ++index172;
              }
              if (this.game.Data.UnitObj[tdata].IsHQ)
                tWeight = tWeight + 0 + num123;
              else if (this.game.Data.UnitObj[tdata].HQ > -1)
                tWeight = tWeight + 1 + num123;
              if (num118 + num119 + num120 > 0 & this.detailnr <= 13)
              {
                ++num103;
                if (this.detailhisnr == -1)
                  this.detailhisnr = tdata;
                if (this.detailhisnr == tdata)
                  TempInt = num103;
                if (this.detailnr <= 13)
                  this.OptionsList6Obj.add(str13 + this.game.Data.UnitObj[tdata].Name, tdata, num118.ToString(), num120.ToString(), tWeight: tWeight);
              }
              else if (this.detailnr == 14)
              {
                ++num103;
                if (this.detailhisnr == -1)
                  this.detailhisnr = tdata;
                if (this.detailhisnr == tdata)
                  TempInt = num103;
                this.OptionsList6Obj.add(str13 + this.game.Data.UnitObj[tdata].Name, tdata, Conversions.ToString(this.game.Data.UnitObj[tdata].SupplyInReq + this.game.Data.UnitObj[tdata].supplyBaseSupplyIn), Conversions.ToString(this.game.Data.UnitObj[tdata].SupplyIn + this.game.Data.UnitObj[tdata].supplyBaseSupplyIn), tWeight: tWeight);
              }
              else if (this.detailnr == 15)
              {
                ++num103;
                if (this.detailhisnr == -1)
                  this.detailhisnr = tdata;
                if (this.detailhisnr == tdata)
                  TempInt = num103;
                this.OptionsList6Obj.add(str13 + this.game.Data.UnitObj[tdata].Name, tdata, Conversions.ToString(this.game.Data.UnitObj[tdata].FuelRequested + this.game.Data.UnitObj[tdata].supplyBaseFuelIn), Conversions.ToString(this.game.Data.UnitObj[tdata].FuelReceived + this.game.Data.UnitObj[tdata].supplyBaseFuelIn), tWeight: tWeight);
              }
            }
          }
        }
        int tlistselect17 = this.OptionsList6Obj.SortWithRefOnWeightAndName(TempInt);
        int upperBound1 = this.OptionsList6Obj.ListData.GetUpperBound(0);
        for (int index = 0; index <= upperBound1; ++index)
        {
          if (this.OptionsList6Obj.ListData[index] == this.detailhisnr)
          {
            this.nextdetailnrhis = index >= this.OptionsList6Obj.ListData.GetUpperBound(0) ? this.OptionsList6Obj.ListData[index] : this.OptionsList6Obj.ListData[index + 1];
            this.prevdetailnrhis = index <= 0 ? this.detailhisnr : this.OptionsList6Obj.ListData[index - 1];
          }
        }
        if (num103 == -1)
        {
          this.RemoveSubPart(this.optionslist6id);
          this.optionslist6id = 0;
        }
        int num129 = (int) Math.Round((double) (this.h - 80) / 16.0) - 1;
        if (this.optionslist6id > 0)
        {
          this.SubPartList[this.SubpartNr(this.optionslist6id)].Refresh(this.OptionsList6Obj, tlistselect17);
          this.SubPartFlag[this.SubpartNr(this.optionslist6id)] = true;
        }
        else if (num103 > -1)
        {
          ListClass optionsList6Obj = this.OptionsList6Obj;
          int tlistsize = num129;
          int twidth = 320 + (int) Math.Round((double) (this.w - 880) / 2.0);
          int tlistselect18 = tlistselect17;
          GameClass game = this.game;
          int tValueWidth = 100 + (int) Math.Round((double) (this.w - 880) / 5.0);
          ref Bitmap local17 = ref this.OwnBitmap;
          int bbx = num1 + 220;
          Font font = (Font) null;
          ref Font local18 = ref font;
          tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, tlistsize, twidth, tlistselect18, game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local17), bbx: bbx, bby: 0, tMarcStyle: true, overruleFont: (ref local18));
          this.optionslist6id = this.AddSubPart(ref tsubpart1, num1 + 220, 16, 320 + (int) Math.Round((double) (this.w - 880) / 2.0), (num129 + 1) * 16, 0);
        }
        else
        {
          if (this.detailnr == 11)
            str2 = "No unit that received replacements";
          if (this.detailnr == 12)
            str2 = "No unit that requested replacements";
          if (this.detailnr == 13)
            str2 = "No unit that returned troops";
          if (this.detailnr == 14)
            str2 = "No unit that has a supply logbook";
          if (this.detailnr == 15)
            str2 = "No unit that has a fuel logbook";
          DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont2, num1 + 260, 90, Color.FromArgb(177, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
        if (this.optionslist6id > 0)
        {
          int x15 = num1 + 220 + 10;
          DrawMod.DrawTextColouredMarc(ref g, "UNIT / HQ", this.game.MarcFont5, x15, 3, Color.White);
          int x16 = num1 + 220 + 320 + (int) Math.Round((double) (this.w - 880) / 2.0) - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          if (this.detailnr == 11)
            DrawMod.DrawTextColouredMarc(ref g, "RECEIVED", this.game.MarcFont5, x16, 3, Color.White);
          if (this.detailnr == 12)
            DrawMod.DrawTextColouredMarc(ref g, "REQUESTED", this.game.MarcFont5, x16, 3, Color.White);
          if (this.detailnr == 13)
            DrawMod.DrawTextColouredMarc(ref g, "RETURNED", this.game.MarcFont5, x16, 3, Color.White);
          if (this.detailnr == 14)
            DrawMod.DrawTextColouredMarc(ref g, "RECEIVED", this.game.MarcFont5, x16, 3, Color.White);
          if (this.detailnr == 15)
            DrawMod.DrawTextColouredMarc(ref g, "RECEIVED", this.game.MarcFont5, x16, 3, Color.White);
          int x17 = x16 - (int) Math.Round((double) (100 + (int) Math.Round((double) (this.w - 880) / 5.0)) / 2.0);
          if (this.detailnr == 11)
            DrawMod.DrawTextColouredMarc(ref g, "REC CUM.", this.game.MarcFont5, x17, 3, Color.White);
          if (this.detailnr == 12)
            DrawMod.DrawTextColouredMarc(ref g, "REQ CUM.", this.game.MarcFont5, x17, 3, Color.White);
          if (this.detailnr == 13)
            DrawMod.DrawTextColouredMarc(ref g, "RET CUM.", this.game.MarcFont5, x17, 3, Color.White);
          if (this.detailnr == 14)
            DrawMod.DrawTextColouredMarc(ref g, "REQUEST", this.game.MarcFont5, x17, 3, Color.White);
          if (this.detailnr == 15)
            DrawMod.DrawTextColouredMarc(ref g, "REQUEST", this.game.MarcFont5, x17, 3, Color.White);
        }
        if (this.detailhisnr > -1 & this.detailhisnr <= this.game.Data.UnitCounter)
        {
          if (this.detailnr >= 11 & this.detailnr <= 13)
          {
            this.OptionsList7Obj = new ListClass();
            int tdata1 = -1;
            SimpleList simpleList = new SimpleList();
            if (this.game.Data.UnitObj[this.detailhisnr].IsHQ)
            {
              int tdata2 = tdata1 + 1;
              int num130 = 0;
              this.OptionsList7Obj.add("For subordinates:", tdata2);
              int num131 = this.game.Data.ReinfCounter + 1;
              for (int index = 0; index <= num131; ++index)
              {
                if (numArray81[this.game.Data.UnitObj[this.detailhisnr].Historical, index] > 0)
                {
                  string tname = (numArray81[this.game.Data.UnitObj[this.detailhisnr].Historical, index] * this.game.Data.ReinfRatio[index]).ToString() + "x " + this.game.Data.ReinfName[index];
                  ++tdata2;
                  ++num130;
                  this.OptionsList7Obj.add(tname, tdata2);
                }
              }
              if (num130 == 0)
              {
                ++tdata2;
                this.OptionsList7Obj.add("-none-", tdata2);
              }
              int tdata3 = tdata2 + 1;
              this.OptionsList7Obj.add("", tdata3);
              tdata1 = tdata3 + 1;
              this.OptionsList7Obj.add("Unit itself:", tdata1);
            }
            tlistselect17 = -1;
            int unitCounter = this.game.Data.UnitCounter;
            for (int tid = 0; tid <= unitCounter; ++tid)
            {
              if (this.game.Data.UnitObj[tid].PreDef == -1 & this.game.Data.UnitObj[tid].Historical == this.game.Data.UnitObj[this.detailhisnr].Historical)
                simpleList.Add(tid, 1);
            }
            int num132 = 0;
            int peopleCounter = this.game.Data.PeopleCounter;
            for (int index175 = 0; index175 <= peopleCounter; ++index175)
            {
              int num133 = this.game.Data.ReinfCounter + 1;
              for (int index176 = 0; index176 <= num133; ++index176)
              {
                int num134 = 0;
                int counter = simpleList.Counter;
                for (int index177 = 0; index177 <= counter; ++index177)
                {
                  int index178 = simpleList.Id[index177];
                  if (this.game.Data.UnitObj[index178].PreDef == -1 & this.game.Data.UnitObj[index178].Historical == this.game.Data.UnitObj[this.detailhisnr].Historical)
                  {
                    int logCounter = this.game.Data.UnitObj[index178].LogCounter;
                    for (int index179 = 0; index179 <= logCounter; ++index179)
                    {
                      if (this.game.Data.UnitObj[index178].LogData1[index179] == index176 & this.game.Data.UnitObj[index178].LogData2[index179] == index175 && this.game.Data.UnitObj[index178].LogType[index179] >= 1 & this.game.Data.UnitObj[index178].LogType[index179] <= 3)
                      {
                        if (this.detailnr == 11)
                        {
                          if (this.game.Data.UnitObj[index178].LogType[index179] == 2)
                            num134 += this.game.Data.UnitObj[index178].LogData3[index179] * this.game.Data.ReinfRatio[index176];
                        }
                        else if (this.detailnr == 12)
                        {
                          if (this.game.Data.UnitObj[index178].LogType[index179] == 1)
                            num134 += this.game.Data.UnitObj[index178].LogData3[index179] * this.game.Data.ReinfRatio[index176];
                        }
                        else if (this.detailnr == 13 && this.game.Data.UnitObj[index178].LogType[index179] == 3)
                          num134 += this.game.Data.UnitObj[index178].LogData3[index179] * this.game.Data.ReinfRatio[index176];
                      }
                    }
                  }
                }
                if (num134 > 0)
                {
                  string tname = num134.ToString() + "x " + this.game.Data.ReinfName[index176] + " (" + Strings.Left(this.game.Data.PeopleObj[index175].Name, 3) + ")";
                  ++tdata1;
                  ++num132;
                  this.OptionsList7Obj.add(tname, tdata1, tcol: 1);
                }
              }
            }
            if (num132 == 0)
              this.OptionsList7Obj.add("-none-", tdata1 + 1);
          }
          else if (this.detailnr >= 14 & this.detailnr <= 15)
          {
            this.OptionsList7Obj = new ListClass();
            int num135 = -1;
            SimpleList simpleList = new SimpleList();
            int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[499]));
            int tdata4 = num135 + 1;
            int num136 = 0;
            if (this.detailnr == 14)
              this.OptionsList7Obj.add("UNIT SUPPLY LOGBOOK:", tdata4);
            if (this.detailnr == 15)
              this.OptionsList7Obj.add("UNIT FUEL LOGBOOK:", tdata4);
            int tdata5 = tdata4 + 1;
            this.OptionsList7Obj.add(" ", tdata5);
            int length = this.game.Data.StringListObj[stringListById].Length;
            for (int index180 = 0; index180 <= length; ++index180)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index180, 3])) == 10 * this.game.Data.UnitObj[this.detailhisnr].Historical + this.game.Data.UnitObj[this.detailhisnr].HistoricalSubPart)
              {
                int num137 = 0;
                if (this.detailnr == 14 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index180, 5])) == 1)
                  num137 = 1;
                if (this.detailnr == 15 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index180, 5])) == 2)
                  num137 = 1;
                if (this.detailnr == 14 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index180, 5])) == 7)
                  num137 = 1;
                if (this.detailnr == 15 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index180, 5])) == 8)
                  num137 = 1;
                if (num137 == 1)
                {
                  string String1 = this.game.Data.StringListObj[stringListById].Data[index180, 11];
                  if (String1.Length > 0 & Strings.InStr(String1, ". ") > 0)
                  {
                    string[] separator = new string[1]
                    {
                      ". "
                    };
                    string[] strArray2 = String1.Split(separator, StringSplitOptions.None);
                    int upperBound2 = strArray2.GetUpperBound(0);
                    for (int index181 = 0; index181 <= upperBound2; ++index181)
                    {
                      ++tdata5;
                      ++num136;
                      this.OptionsList7Obj.add(strArray2[index181], tdata5);
                    }
                  }
                }
              }
            }
            int num138 = this.game.Data.ReinfCounter + 1;
            for (int index = 0; index <= num138; ++index)
            {
              if (numArray81[this.game.Data.UnitObj[this.detailhisnr].Historical, index] > 0)
              {
                string tname = (numArray81[this.game.Data.UnitObj[this.detailhisnr].Historical, index] * this.game.Data.ReinfRatio[index]).ToString() + "x " + this.game.Data.ReinfName[index];
                ++tdata5;
                ++num136;
                this.OptionsList7Obj.add(tname, tdata5);
              }
            }
            if (num136 == 0)
              this.OptionsList7Obj.add("-none-", tdata5 + 1);
          }
          int num139 = (int) Math.Round((double) (this.h - 80) / 16.0) - 3;
          if (this.optionslist7id > 0)
          {
            this.SubPartList[this.SubpartNr(this.optionslist7id)].Refresh(this.OptionsList7Obj, tlistselect17);
            this.SubPartFlag[this.SubpartNr(this.optionslist7id)] = true;
          }
          else
          {
            ListClass optionsList7Obj = this.OptionsList7Obj;
            int tlistsize = num139;
            int twidth = 140 + (int) Math.Round((double) (this.w - 880) / 2.0);
            GameClass game = this.game;
            ref Bitmap local19 = ref this.OwnBitmap;
            int bbx = num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0);
            Font font = (Font) null;
            ref Font local20 = ref font;
            tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList7Obj, tlistsize, twidth, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local19), bbx: bbx, bby: 0, tMarcStyle: true, overruleFont: (ref local20));
            this.optionslist7id = this.AddSubPart(ref tsubpart1, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), 0, 140 + (int) Math.Round((double) (this.w - 880) / 2.0), (num139 + 1) * 16, 0);
          }
          tsubpart1 = (SubPartClass) new TextButtonPartClass("GO TO UNIT", 140, "Click to center map on this unit.", ref this.OwnBitmap, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), (num139 + 2) * 16 - 7, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.text6id = this.AddSubPart(ref tsubpart1, num1 + 560 + (int) Math.Round((double) (this.w - 880) / 2.0), (num139 + 2) * 16 - 7, 140, 40, 1);
        }
      }
      int num140 = -1;
      int num141 = 0;
      do
      {
        if ((double) this.game.Data.RuleVar[650 + num141] > 0.0)
          ++num140;
        ++num141;
      }
      while (num141 <= 2);
      if ((double) this.game.Data.RuleVar[337] > 0.0)
        num140 += 2;
      int num142 = -1;
      if ((double) this.game.Data.RuleVar[403] > 0.0)
        ++num142;
      Rectangle trect2 = new Rectangle(15, 20, 135, 70);
      this.AddMouse(ref trect2, "Click to see statistics on troops", "", 1);
      if (num140 > -1)
      {
        trect2 = new Rectangle(15, 90, 135, 70);
        Rectangle trect3 = trect2;
        this.AddMouse(ref trect3, "Click to see statistics on regime variables", "", 2);
      }
      if (num142 > -1)
      {
        trect2 = new Rectangle(15, 160, 135, 70);
        Rectangle trect4 = trect2;
        this.AddMouse(ref trect4, "Click to see statistics on logistics", "", 3);
      }
      if (this.subtabnr == 0)
        DrawMod.DrawBlockGradient(ref g, 25, 20, 125, 70, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      else if (this.subtabnr == 1)
        DrawMod.DrawBlockGradient(ref g, 25, 90, 125, 70, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      else if (this.subtabnr == 2)
        DrawMod.DrawBlockGradient(ref g, 25, 160, 125, 70, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      DrawMod.drawLineDot(ref g, 150, 0, 150, this.h - 80, Color.White);
      DrawMod.drawLineDot(ref g, 15, 20, 150, 20, Color.White);
      DrawMod.drawLineDot(ref g, 15, 90, 150, 90, Color.White);
      if (num140 > -1)
        DrawMod.drawLineDot(ref g, 15, 160, 150, 160, Color.White);
      if (num142 > -1)
        DrawMod.drawLineDot(ref g, 15, 230, 150, 230, Color.White);
      DrawMod.DrawTextColouredMarcCenter(ref g, "Troop Statistics", this.game.MarcFont5, 90, 50, Color.White);
      if (num140 > -1)
        DrawMod.DrawTextColouredMarcCenter(ref g, "Regime Statistics", this.game.MarcFont5, 90, 120, Color.White);
      if (num142 > -1)
        DrawMod.DrawTextColouredMarcCenter(ref g, "Logistical Statistics", this.game.MarcFont5, 90, 190, Color.White);
      tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.detailnr3 == 1, "Switch on/off to show/hide numbers in the statistic grahps.", ref this.OwnBitmap, 30, this.h - 160);
      this.Text4id = this.AddSubPart(ref tsubpart1, 30, this.h - 160, 35, 35, 1);
      DrawMod.DrawTextColouredMarc(ref g, "Numbers", this.game.MarcFont4, 75, this.h - 150, Color.White);
      this.game.EditObj.statsTab_tab = this.subtabnr;
      this.game.EditObj.statsTab_item = this.detailnr;
    }

    public override void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            return;
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.MouseData[mouseCounter] == 1)
          {
            this.detailnr = -1;
            this.subtabnr = 0;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[mouseCounter] == 2)
          {
            this.detailnr = -1;
            this.subtabnr = 1;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[mouseCounter] == 3)
          {
            this.detailnr = -1;
            this.subtabnr = 2;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
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
              this.SubPartFlag[index] = true;
              if (num2 != -1 & this.detailnr != num2)
              {
                if (num2 == -2)
                  num2 = -1;
                this.detailnr = num2;
                this.detailhisnr = -1;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.optionslist6id)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num3 > -1 & this.detailhisnr != num3)
              {
                this.detailhisnr = num3;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.optionslist7id)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text1Id)
            {
              this.detailnr2 = 0;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text2Id)
            {
              this.detailnr2 = 1;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Text3Id)
            {
              this.detailnr2 = 2;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.text6id)
            {
              int detailhisnr = this.detailhisnr;
              if (detailhisnr > -1)
              {
                this.game.EditObj.UnitSelected = detailhisnr;
                this.game.SelectX = this.game.Data.UnitObj[detailhisnr].X;
                this.game.SelectY = this.game.Data.UnitObj[detailhisnr].Y;
                this.game.HandyFunctionsObj.SetcornerXY2();
                this.game.EditObj.TempCoordList = new CoordList();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 69);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
                windowReturnClass.SetFlag(true);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.Text5id)
              {
                ++this.detailnr4;
                if (this.detailnr4 > 1)
                  this.detailnr4 = 0;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Text4id)
              {
                ++this.detailnr3;
                if (this.detailnr3 > 1)
                  this.detailnr3 = 0;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
          }
        }
      }
      int mouseCounter1 = this.MouseCounter;
      for (int index = 0; index <= mouseCounter1; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] == 999)
        {
          this.game.EditObj.SetViewMode2 = 0;
          windowReturnClass.AddCommand(1, 9);
          windowReturnClass.AddCommand(7, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
