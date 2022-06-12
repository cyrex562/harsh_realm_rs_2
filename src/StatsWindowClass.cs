// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.StatsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class StatsWindowClass : WindowClass
  {
    private int TempText1;
    private int temptext2;
    private int temptext3;
    private int temptext4;
    private int temptext5;
    private int temptext6;
    private int temptext7;
    private int temptext8;
    private int temptext9;
    private int temptext10;
    private int TempText11;
    private int temptext12;
    private int temptext13;
    private int temptext14;
    private int temptext15;
    private int temptext16;
    private int temptext17;
    private int temptext18;
    private int temptext19;
    private int[] TabId;
    private int but1id;
    private int but1textid;
    private int TabCount;
    private int but2id;
    private int but2textid;
    private int but3id;
    private int but3textid;
    private int but4id;
    private int but4textid;
    private int but5id;
    private int but5textid;
    private int GOid;
    private int UpgradeId;
    private int headytxt;
    private int sliderid;
    private float tempBlink;
    private int hq;
    private int sfnr;
    private int detailnr;
    private int detailnr2;
    private int detailnr3;
    private int detailnr4;
    private int detailnr5;
    private int detailtype;
    private int ammount;
    private bool hqreach;
    private int passenger;
    private int OptionsListId;
    private ATListClass OptionsListObj;
    private int SortStart;
    private int sortcount;
    private int ModeTextId;
    private int ModeButton0Id;
    private int ModeButton1Id;
    private int ModeButton2Id;
    private int OptionsList2Id;
    private ATListClass OptionsList2Obj;
    private int OptionsList3Id;
    private ATListClass OptionsList3Obj;
    private int OptionsList4Id;
    private ATListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ATListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ATListClass OptionsList6Obj;
    private int OptionsList7Id;
    private ATListClass OptionsList7Obj;
    private int OptionsList8Id;
    private ATListClass OptionsList8Obj;
    private int OptionsList9Id;
    private ATListClass OptionsList9Obj;
    private int StatMode;
    private int StatAggr;
    private int Abstr;
    private int[] mzx;
    private int[] mzy;
    private int[] mzx2;
    private int[] mzy2;
    private int[] mznr;
    private int[] mzdetnr;
    private int mzcount;
    private bool supplycalcdone;
    private int[] supplyneed1;
    public int[] supplyneed2;
    private int[] supplyneed3;
    private int[] supplyneed4;
    public int[] supplyout1;
    private int[] supplyout2;
    private int[] supplyout3;
    private int[] supplyin1;
    private int[] supplyin2;
    private int[] supplyin3;
    private int[] supplyin4;
    private int truextra;

    public StatsWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.TabId = new int[100];
      this.mzx = new int[2001];
      this.mzy = new int[2001];
      this.mzx2 = new int[2001];
      this.mzy2 = new int[2001];
      this.mznr = new int[2001];
      this.mzdetnr = new int[2001];
      this.supplyneed1 = new int[1];
      this.supplyneed2 = new int[1];
      this.supplyneed3 = new int[1];
      this.supplyneed4 = new int[1];
      this.supplyout1 = new int[1];
      this.supplyout2 = new int[1];
      this.supplyout3 = new int[1];
      this.supplyin1 = new int[1];
      this.supplyin2 = new int[1];
      this.supplyin3 = new int[1];
      this.supplyin4 = new int[1];
      this.SortStart = 0;
      this.StatMode = 0;
      if (this.game.EditObj.LastStatWindow > 0)
        this.StatMode = this.game.EditObj.LastStatWindow;
      if (this.StatMode == 9 && !this.supplycalcdone)
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        this.CalculateSupply();
        this.game.FormRef.Cursor = Cursors.Default;
      }
      this.StatAggr = 0;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr4 = -1;
      this.detailnr5 = -1;
      this.supplycalcdone = false;
      this.DoStuff();
    }

    public void DoStuff()
    {
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray3 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray4 = new int[this.game.Data.UnitCounter + 1];
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.but1textid > 0)
        this.RemoveSubPart(this.but1textid);
      if (this.but2id > 0)
        this.RemoveSubPart(this.but2id);
      if (this.but2textid > 0)
        this.RemoveSubPart(this.but2textid);
      if (this.but3id > 0)
        this.RemoveSubPart(this.but3id);
      if (this.but3textid > 0)
        this.RemoveSubPart(this.but3textid);
      if (this.but4id > 0)
        this.RemoveSubPart(this.but4id);
      if (this.but4textid > 0)
        this.RemoveSubPart(this.but4textid);
      if (this.but5id > 0)
        this.RemoveSubPart(this.but5id);
      if (this.but5textid > 0)
        this.RemoveSubPart(this.but5textid);
      if (this.ModeTextId > 0)
        this.RemoveSubPart(this.ModeTextId);
      if (this.ModeButton0Id > 0)
        this.RemoveSubPart(this.ModeButton0Id);
      if (this.ModeButton1Id > 0)
        this.RemoveSubPart(this.ModeButton1Id);
      if (this.ModeButton2Id > 0)
        this.RemoveSubPart(this.ModeButton2Id);
      if (this.GOid > 0)
        this.RemoveSubPart(this.GOid);
      if (this.UpgradeId > 0)
        this.RemoveSubPart(this.UpgradeId);
      if (this.headytxt > 0)
        this.RemoveSubPart(this.headytxt);
      if (this.TempText1 > 0)
        this.RemoveSubPart(this.TempText1);
      if (this.temptext2 > 0)
        this.RemoveSubPart(this.temptext2);
      if (this.temptext3 > 0)
        this.RemoveSubPart(this.temptext3);
      if (this.temptext4 > 0)
        this.RemoveSubPart(this.temptext4);
      int index1 = 0;
      do
      {
        if (this.TabId[index1] > 0)
        {
          this.RemoveSubPart(this.TabId[index1]);
          this.TabId[index1] = 0;
        }
        ++index1;
      }
      while (index1 <= 19);
      int mzcount1 = this.mzcount;
      for (int index2 = 0; index2 <= mzcount1; ++index2)
      {
        this.mzx[index2] = -1;
        this.mzy[index2] = -1;
        this.mzx2[index2] = -1;
        this.mzy2[index2] = -1;
      }
      this.mzcount = -1;
      this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND2MARC);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      Font vicFont2 = this.game.VicFont2;
      Font vicFont4 = this.game.VicFont4;
      Font vicFont3 = this.game.VicFont3;
      bool flag;
      if (!this.game.Data.FOWOn)
        flag = true;
      if (this.game.Data.Winner > -1)
        flag = true;
      this.mzcount = -1;
      int num1 = 0;
      if ((double) this.game.Data.RuleVar[650] > 0.0)
        ++num1;
      if ((double) this.game.Data.RuleVar[651] > 0.0)
        ++num1;
      if ((double) this.game.Data.RuleVar[652] > 0.0)
        ++num1;
      this.truextra = num1;
      int num2 = 20;
      int num3 = 0;
      do
      {
        string buttontext;
        if (num3 == 0)
        {
          buttontext = "Produce";
          num2 = 510;
        }
        if (num3 == 1)
        {
          buttontext = "Losses";
          num2 = 580;
        }
        if (num3 == 2)
        {
          buttontext = "Kills";
          num2 = 650;
        }
        if (num3 == 3)
        {
          buttontext = "Totals";
          num2 = 90;
        }
        if (num3 == 4)
        {
          buttontext = "OOB";
          num2 = 20;
        }
        if (num3 == 5)
        {
          buttontext = "Power";
          num2 = 160;
        }
        if (num3 == 6)
        {
          buttontext = "Rules";
          num2 = 230;
        }
        if (num3 == 7)
        {
          buttontext = "Brief";
          num2 = 300;
        }
        if (num3 == 8)
        {
          buttontext = "Force";
          num2 = 440;
        }
        if (num3 == 9)
        {
          buttontext = "Supply";
          num2 = 370;
        }
        int[] tabId = this.TabId;
        int index3 = num3;
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(buttontext, 68, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 20, tred: (this.StatMode == num3));
        int num4 = this.AddSubPart(ref tsubpart, num2, 20, 68, 35, 1);
        tabId[index3] = num4;
        ++num3;
      }
      while (num3 <= 9);
      int num5 = 720;
      SubPartClass tsubpart1;
      if (num1 > 0)
      {
        int num6 = 9 + num1;
        for (int index4 = 10; index4 <= num6; ++index4)
        {
          string buttontext = Strings.Left(this.game.Data.TempString[700 + (index4 - 10)], 3);
          int[] tabId = this.TabId;
          int index5 = index4;
          tsubpart1 = (SubPartClass) new TextButtonPartClass(buttontext, 68, tBackbitmap: (ref this.OwnBitmap), bbx: num5, bby: 20, tred: (this.StatMode == index4));
          int num7 = this.AddSubPart(ref tsubpart1, num5, 20, 68, 35, 1);
          tabId[index5] = num7;
          num5 += 70;
        }
      }
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONQUIT);
      this.but1id = this.AddSubPart(ref tsubpart1, 952, 22, 35, 35, 1);
      int num8;
      if (this.StatMode == 4 | this.StatMode == 9)
      {
        DrawMod.DrawBlock(ref graphics, 30, 94, 900, 48, 0, 0, 0, 166);
        DrawMod.DrawBlock(ref graphics, 30, 144, 900, 48, 0, 0, 0, 166);
        DrawMod.DrawBlock(ref graphics, 30, 194, 900, 48, 0, 0, 0, 166);
        DrawMod.DrawBlock(ref graphics, 30, 244, 900, 248, 0, 0, 0, 166);
        DrawMod.DrawRectangle(ref graphics, 30, 94, 900, 48, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref graphics, 30, 144, 900, 48, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref graphics, 30, 194, 900, 48, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref graphics, 30, 244, 900, 248, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        this.sortcount = -1;
        int num9 = -1;
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index6 = 0; index6 <= unitCounter1; ++index6)
        {
          numArray1[index6] = -1;
          numArray3[index6] = 0;
        }
        int num10;
        do
        {
          num10 = 0;
          ++num9;
          int unitCounter2 = this.game.Data.UnitCounter;
          for (int index7 = 0; index7 <= unitCounter2; ++index7)
          {
            if (this.game.Data.UnitObj[index7].PreDef == -1 && this.game.Data.UnitObj[index7].IsHQ | !this.game.Data.UnitObj[index7].IsHQ & this.game.Data.UnitObj[index7].HQ == -1 && (this.game.Data.RegimeObj[this.game.Data.UnitObj[index7].Regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[index7].Regime].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index7].Regime].UberRegime == this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == this.game.Data.UnitObj[index7].Regime | this.game.Data.Turn == this.game.Data.UnitObj[index7].Regime) & this.game.Data.UnitObj[index7].PreDef <= -1)
            {
              if (num9 == 0)
              {
                if (this.game.Data.UnitObj[index7].HQ == -1)
                {
                  numArray1[index7] = 0;
                  num10 = 1;
                }
              }
              else if (this.game.Data.UnitObj[index7].HQ > -1 & numArray1[index7] == -1 & this.game.Data.UnitObj[index7].PreDef <= -1)
              {
                int hq = this.game.Data.UnitObj[index7].HQ;
                if (numArray1[hq] == num9 - 1)
                {
                  num10 = 1;
                  numArray1[index7] = num9;
                }
              }
            }
          }
        }
        while (num10 > 0);
        int num11 = num9 - 1;
        if (num11 == -1)
          return;
        if (num11 >= 2)
        {
          int num12 = 0;
          int unitCounter3 = this.game.Data.UnitCounter;
          for (int index8 = 0; index8 <= unitCounter3; ++index8)
          {
            if (numArray1[index8] <= num11 - 2 & numArray1[index8] > -1)
              ++num12;
          }
          if (num12 > 0)
          {
            int num13 = (int) Math.Round(850.0 / (double) num12);
            if (num13 > 40)
              num13 = 40;
            int num14 = 0;
            num8 = 0;
            int unitCounter4 = this.game.Data.UnitCounter;
            for (int nr = 0; nr <= unitCounter4; ++nr)
            {
              if (numArray1[nr] <= num11 - 2 & numArray1[nr] > -1)
              {
                ++num8;
                if (this.detailnr == -1)
                {
                  this.detailnr = nr;
                  this.detailnr5 = nr;
                }
                this.game.CustomBitmapObj.DrawUnit(nr, toG: graphics, tx: (num14 + 50), ty: 100);
                if (nr == this.detailnr)
                  DrawMod.DrawRectangle(ref graphics, num14 + 50 - 1, 99, 37, 37, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                ++this.mzcount;
                this.mzx[this.mzcount] = num14 + 50;
                this.mzy[this.mzcount] = 100;
                this.mzx2[this.mzcount] = num14 + num13 + 50;
                this.mzy2[this.mzcount] = 138;
                this.mznr[this.mzcount] = nr;
                this.mzdetnr[this.mzcount] = 1;
                num14 += num13;
                if (num8 == num12 & 38 > num13)
                {
                  int[] mzx2 = this.mzx2;
                  int[] numArray5 = mzx2;
                  int mzcount2 = this.mzcount;
                  int index9 = mzcount2;
                  int num15 = mzx2[mzcount2] + (38 - num13);
                  numArray5[index9] = num15;
                }
              }
            }
          }
        }
        if (num11 >= 1 & (this.detailnr > -1 | num11 < 2))
        {
          int num16 = 0;
          int unitCounter5 = this.game.Data.UnitCounter;
          for (int index10 = 0; index10 <= unitCounter5; ++index10)
          {
            if (numArray1[index10] <= num11 - 1 & numArray1[index10] > -1 & this.game.Data.UnitObj[index10].HQ == this.detailnr)
              ++num16;
          }
          if (num16 > 0)
          {
            int num17 = (int) Math.Round(850.0 / (double) num16);
            if (num17 > 40)
              num17 = 40;
            int num18 = 0;
            num8 = 0;
            int unitCounter6 = this.game.Data.UnitCounter;
            for (int nr = 0; nr <= unitCounter6; ++nr)
            {
              if (numArray1[nr] <= num11 - 1 & numArray1[nr] > -1 && this.game.Data.UnitObj[nr].HQ == this.detailnr)
              {
                ++num8;
                if (this.detailnr2 == -1 & num11 == 1)
                {
                  this.detailnr2 = nr;
                  this.detailnr5 = nr;
                }
                this.game.CustomBitmapObj.DrawUnit(nr, toG: graphics, tx: (num18 + 50), ty: 150);
                if (nr == this.detailnr2)
                  DrawMod.DrawRectangle(ref graphics, num18 + 50 - 1, 149, 37, 37, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                ++this.mzcount;
                this.mzx[this.mzcount] = num18 + 50;
                this.mzy[this.mzcount] = 150;
                this.mzx2[this.mzcount] = num18 + num17 + 50;
                this.mzy2[this.mzcount] = 188;
                this.mznr[this.mzcount] = nr;
                this.mzdetnr[this.mzcount] = 2;
                num18 += num17;
                if (num8 == num16 & 38 > num17)
                {
                  int[] mzx2 = this.mzx2;
                  int[] numArray6 = mzx2;
                  int mzcount3 = this.mzcount;
                  int index11 = mzcount3;
                  int num19 = mzx2[mzcount3] + (38 - num17);
                  numArray6[index11] = num19;
                }
              }
            }
          }
        }
        if (num11 >= 0 & (this.detailnr2 > -1 | num11 < 1))
        {
          int num20 = 0;
          int unitCounter7 = this.game.Data.UnitCounter;
          for (int index12 = 0; index12 <= unitCounter7; ++index12)
          {
            if (numArray1[index12] <= num11 & numArray1[index12] > -1 & this.game.Data.UnitObj[index12].HQ == this.detailnr2)
              ++num20;
          }
          if (num20 > 0)
          {
            int num21 = (int) Math.Round(850.0 / (double) num20);
            if (num21 > 40)
              num21 = 40;
            int num22 = 0;
            num8 = 0;
            int unitCounter8 = this.game.Data.UnitCounter;
            for (int nr = 0; nr <= unitCounter8; ++nr)
            {
              if (numArray1[nr] <= num11 & numArray1[nr] > -1 && this.game.Data.UnitObj[nr].HQ == this.detailnr2)
              {
                ++num8;
                if (this.detailnr3 == -1 & num11 == 0)
                {
                  this.detailnr3 = nr;
                  this.detailnr5 = nr;
                }
                this.game.CustomBitmapObj.DrawUnit(nr, toG: graphics, tx: (num22 + 50), ty: 200);
                if (nr == this.detailnr3)
                  DrawMod.DrawRectangle(ref graphics, num22 + 50 - 1, 199, 37, 37, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                ++this.mzcount;
                this.mzx[this.mzcount] = num22 + 50;
                this.mzy[this.mzcount] = 200;
                this.mzx2[this.mzcount] = num22 + num21 + 50;
                this.mzy2[this.mzcount] = 238;
                this.mznr[this.mzcount] = nr;
                this.mzdetnr[this.mzcount] = 3;
                num22 += num21;
                if (num8 == num20 & 38 > num21)
                {
                  int[] mzx2 = this.mzx2;
                  int[] numArray7 = mzx2;
                  int mzcount4 = this.mzcount;
                  int index13 = mzcount4;
                  int num23 = mzx2[mzcount4] + (38 - num21);
                  numArray7[index13] = num23;
                }
              }
            }
          }
        }
        int num24;
        if (this.detailnr > -1)
          num24 = this.detailnr;
        if (this.detailnr2 > -1)
          num24 = this.detailnr2;
        if (this.detailnr3 > -1)
          num24 = this.detailnr3;
        if (this.detailnr5 > -1 && this.game.Data.UnitObj[this.detailnr5].IsHQ)
          num24 = this.detailnr5;
        if (num24 > -1)
        {
          int num25 = 0;
          int unitCounter9 = this.game.Data.UnitCounter;
          for (int index14 = 0; index14 <= unitCounter9; ++index14)
          {
            if (numArray1[index14] == -1 & this.game.Data.UnitObj[index14].HQ == num24 && this.game.Data.UnitObj[index14].PreDef == -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[index14].Regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[index14].Regime].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index14].Regime].UberRegime == this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == this.game.Data.UnitObj[index14].Regime | this.game.Data.Turn == this.game.Data.UnitObj[index14].Regime)
              ++num25;
          }
          if (num25 > 0)
          {
            int num26 = (int) Math.Round(5100.0 / (double) num25);
            if (num26 > 40)
              num26 = 40;
            int num27 = 0;
            int ty = 250;
            num8 = 0;
            int unitCounter10 = this.game.Data.UnitCounter;
            for (int nr = 0; nr <= unitCounter10; ++nr)
            {
              if (numArray1[nr] == -1 && this.game.Data.UnitObj[nr].HQ == num24 && this.game.Data.UnitObj[nr].PreDef == -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[nr].Regime].UberRegime == this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == this.game.Data.UnitObj[nr].Regime | this.game.Data.Turn == this.game.Data.UnitObj[nr].Regime)
              {
                ++num8;
                bool forcehighlight = this.detailnr4 == nr;
                this.game.CustomBitmapObj.DrawUnit(nr, forcehighlight, graphics, num27 + 50, ty);
                if (nr == this.detailnr4)
                  DrawMod.DrawRectangle(ref graphics, num27 + 50 - 1, ty - 1, 37, 37, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                ++this.mzcount;
                this.mzx[this.mzcount] = num27 + 50;
                this.mzy[this.mzcount] = ty;
                this.mzx2[this.mzcount] = num27 + num26 + 50;
                this.mzy2[this.mzcount] = ty + 38;
                this.mznr[this.mzcount] = nr;
                this.mzdetnr[this.mzcount] = 4;
                num27 += num26;
                if (num27 + num26 + 38 > 850)
                {
                  num27 = 0;
                  ty += 40;
                  int[] mzx2 = this.mzx2;
                  int[] numArray8 = mzx2;
                  int mzcount5 = this.mzcount;
                  int index15 = mzcount5;
                  int num28 = mzx2[mzcount5] + (38 - num26);
                  numArray8[index15] = num28;
                }
                if (num8 == num25 & 38 > num26)
                {
                  int[] mzx2 = this.mzx2;
                  int[] numArray9 = mzx2;
                  int mzcount6 = this.mzcount;
                  int index16 = mzcount6;
                  int num29 = mzx2[mzcount6] + (38 - num26);
                  numArray9[index16] = num29;
                }
              }
            }
          }
        }
        if (this.detailnr5 > -1)
        {
          if (this.StatMode == 4)
          {
            tsubpart1 = (SubPartClass) new UnitHeaderPartClass(this.detailnr5, this.game);
            this.TempText1 = this.AddSubPart(ref tsubpart1, 40, 500, 280, 200, 0);
          }
          if (this.StatMode == 4)
          {
            if (this.StatMode == 4)
            {
              if (this.game.Data.UnitObj[this.detailnr5].Historical == -1)
              {
                tsubpart1 = (SubPartClass) new UnitSFPartClass(this.detailnr5, this.game);
                this.temptext2 = this.AddSubPart(ref tsubpart1, 340, 500, 620, 200, 0);
              }
              else if (this.game.Data.UnitObj[this.detailnr5].Historical > -1)
              {
                tsubpart1 = (SubPartClass) new OfficerPartClass(this.detailnr5, this.game);
                this.temptext2 = this.AddSubPart(ref tsubpart1, 340, 500, 300, 200, 0);
              }
            }
          }
          else if (this.StatMode == 9)
          {
            int num30 = -130;
            int num31 = 30;
            DrawMod.DrawTextVic2(ref graphics, "Supply need prognosis", this.game.VicFont2, num30 + 290, num31 + 500, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Clean Supply Request", this.game.VicFont3, num30 + 290, num31 + 530, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyneed1[this.detailnr5]), this.game.VicFont3, num30 + 430, num31 + 530, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "    after range penalty", this.game.VicFont3, num30 + 290, num31 + 550, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyneed4[this.detailnr5]), this.game.VicFont3, num30 + 430, num31 + 550, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Supply Consumption", this.game.VicFont3, num30 + 290, num31 + 570, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyneed2[this.detailnr5]), this.game.VicFont3, num30 + 430, num31 + 570, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Current Supply Pts", this.game.VicFont3, num30 + 290, num31 + 590, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.game.Data.UnitObj[this.detailnr5].Supply), this.game.VicFont3, num30 + 430, num31 + 590, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Maximum Supply Pts", this.game.VicFont3, num30 + 290, num31 + 610, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyneed3[this.detailnr5]), this.game.VicFont3, num30 + 430, num31 + 610, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Supply IN prognosis", this.game.VicFont2, num30 + 520, num31 + 500, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Production", this.game.VicFont3, num30 + 520, num31 + 530, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyin1[this.detailnr5]), this.game.VicFont3, num30 + 660, num31 + 530, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Free Reserves", this.game.VicFont3, num30 + 520, num31 + 550, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyin2[this.detailnr5]), this.game.VicFont3, num30 + 660, num31 + 550, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Request at high HQ", this.game.VicFont3, num30 + 520, num31 + 570, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyin3[this.detailnr5]), this.game.VicFont3, num30 + 660, num31 + 570, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, "Get from high HQ", this.game.VicFont3, num30 + 520, num31 + 590, this.game.VicColor2, this.game.VicColor2Shade);
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyin4[this.detailnr5]), this.game.VicFont3, num30 + 660, num31 + 590, this.game.VicColor2, this.game.VicColor2Shade);
            if (this.game.Data.UnitObj[this.detailnr5].IsHQ)
            {
              DrawMod.DrawTextVic2(ref graphics, "Supply OUT prognosis", this.game.VicFont2, num30 + 750, num31 + 500, this.game.VicColor2, this.game.VicColor2Shade);
              DrawMod.DrawTextVic2(ref graphics, "Subordinate Requests", this.game.VicFont3, num30 + 750, num31 + 530, this.game.VicColor2, this.game.VicColor2Shade);
              DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyout1[this.detailnr5]), this.game.VicFont3, num30 + 910, num31 + 530, this.game.VicColor2, this.game.VicColor2Shade);
              DrawMod.DrawTextVic2(ref graphics, "   after range penalty", this.game.VicFont3, num30 + 750, num31 + 550, this.game.VicColor2, this.game.VicColor2Shade);
              DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyout2[this.detailnr5]), this.game.VicFont3, num30 + 910, num31 + 550, this.game.VicColor2, this.game.VicColor2Shade);
              DrawMod.DrawTextVic2(ref graphics, "Supply to subordinates", this.game.VicFont3, num30 + 750, num31 + 570, this.game.VicColor2, this.game.VicColor2Shade);
              DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) this.supplyout3[this.detailnr5]), this.game.VicFont3, num30 + 910, num31 + 570, this.game.VicColor2, this.game.VicColor2Shade);
            }
          }
          if (this.game.Data.UnitObj[this.detailnr5].X > -1)
          {
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Go to this unit", 150, tBackbitmap: (ref this.OwnBitmap), bbx: 260, bby: 710);
            this.GOid = this.AddSubPart(ref tsubpart1, 260, 710, 150, 35, 1);
            if (this.game.Data.UnitObj[this.detailnr5].IsHQ & this.game.Data.UnitObj[this.detailnr5].X > -1 && this.game.Data.ResearchCounter > -1)
            {
              tsubpart1 = (SubPartClass) new TextButtonPartClass("Auto Upgrade", 150, tBackbitmap: (ref this.OwnBitmap), bbx: 430, bby: 710);
              this.UpgradeId = this.AddSubPart(ref tsubpart1, 430, 710, 150, 35, 1);
            }
          }
        }
      }
      if (this.StatMode == 0 | this.StatMode == 1 | this.StatMode == 2 | this.StatMode == 8 | this.StatMode > 9)
      {
        DrawMod.DrawBlock(ref graphics, 860, 120, 140, 112, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        if (this.StatAggr == 0)
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 860, bby: 120);
          this.ModeButton0Id = this.AddSubPart(ref tsubpart1, 860, 120, 32, 32, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 860, bby: 120);
          this.ModeButton0Id = this.AddSubPart(ref tsubpart1, 860, 120, 32, 32, 1);
        }
        if (this.StatAggr == 1)
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 860, bby: 160);
          this.ModeButton1Id = this.AddSubPart(ref tsubpart1, 860, 160, 32, 32, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 860, bby: 160);
          this.ModeButton1Id = this.AddSubPart(ref tsubpart1, 860, 160, 32, 32, 1);
        }
        if (this.StatAggr == 2)
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 860, bby: 200);
          this.ModeButton2Id = this.AddSubPart(ref tsubpart1, 860, 200, 32, 32, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 860, bby: 200);
          this.ModeButton2Id = this.AddSubPart(ref tsubpart1, 860, 200, 32, 32, 1);
        }
        DrawMod.DrawTextVic2(ref graphics, "Default", this.game.VicFont3, 900, 132, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Normalized", this.game.VicFont3, 900, 172, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Very Normalized", this.game.VicFont3, 900, 212, this.game.VicColor2, this.game.VicColor2Shade);
      }
      TimeSpan timeSpan;
      if (this.StatMode > 9)
      {
        int num32 = 10;
        int num33 = 20;
        int index17 = this.StatMode - 10;
        if (this.game.Data.Round > num33)
          num33 = this.game.Data.Round;
        int num34 = (int) Math.Round((double) num33 + Conversion.Int((double) num33 * 0.2));
        float[,] numArray10 = new float[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        int regimeCounter1 = this.game.Data.RegimeCounter;
        for (int index18 = 0; index18 <= regimeCounter1; ++index18)
        {
          int round = this.game.Data.Round;
          for (int index19 = 1; index19 <= round; ++index19)
          {
            float[,] numArray11 = numArray10;
            float[,] numArray12 = numArray11;
            int index20 = index18;
            int index21 = index20;
            int index22 = index19;
            int index23 = index22;
            double num35 = (double) numArray11[index20, index22] + (double) this.game.Data.RegimeObj[index18].ExtraStat[index17, index19];
            numArray12[index21, index23] = (float) num35;
            if ((double) numArray10[index18, index19] > (double) num32)
              num32 = (int) Math.Round((double) numArray10[index18, index19]);
          }
        }
        float[,] numArray13 = new float[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        if (this.StatAggr > 0)
        {
          if (this.StatAggr == 1)
            num8 = 3;
          if (this.StatAggr == 2)
            num8 = 10;
          int regimeCounter2 = this.game.Data.RegimeCounter;
          for (int index24 = 0; index24 <= regimeCounter2; ++index24)
          {
            int round = this.game.Data.Round;
            for (int index25 = 1; index25 <= round; ++index25)
            {
              int num36 = 0;
              int num37 = 0;
              int num38 = index25 - num8;
              int num39 = index25 + num8;
              for (int index26 = num38; index26 <= num39; ++index26)
              {
                if (index26 > 0 & index26 <= this.game.Data.Round)
                {
                  ++num36;
                  num37 = (int) Math.Round((double) ((float) num37 + numArray10[index24, index26]));
                }
              }
              numArray13[index24, index25] = (float) num37 / (float) num36;
            }
          }
          int regimeCounter3 = this.game.Data.RegimeCounter;
          for (int index27 = 0; index27 <= regimeCounter3; ++index27)
          {
            int round = this.game.Data.Round;
            for (int index28 = 1; index28 <= round; ++index28)
              numArray10[index27, index28] = numArray13[index27, index28];
          }
        }
        DrawMod.drawLine(ref graphics, 100, 100, 100, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.drawLine(ref graphics, 100, 700, 850, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        ref Graphics local1 = ref graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.STATSGRADIENT);
        ref Bitmap local2 = ref bitmap;
        int y = 699 - BitmapStore.Getheight(this.game.STATSGRADIENT);
        double r = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Red / (double) byte.MaxValue - 1.0;
        double g = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Green / (double) byte.MaxValue - 1.0;
        double b = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Blue / (double) byte.MaxValue - 1.0;
        DrawMod.Draw(ref local1, ref local2, 101, y, (float) r, (float) g, (float) b, 1f);
        DrawMod.DrawTextVic2(ref graphics, this.game.Data.TempString[700 + index17], this.game.VicFont2, 15, 85, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Round", this.game.VicFont2, 880, 720, this.game.VicColor2, this.game.VicColor2Shade);
        int regimeCounter4 = this.game.Data.RegimeCounter;
        for (int index29 = 0; index29 <= regimeCounter4; ++index29)
        {
          int x2 = 0;
          int y2 = 0;
          if ((double) this.game.Data.RuleVar[313] == 1.0 | index29 == this.game.Data.Turn | !this.game.Data.RegimeObj[index29].DipBlock & !(this.game.Data.RegimeObj[index29].AI & this.game.Data.RegimeObj[index29].Sleep) && (double) this.game.Data.RuleVar[313] == 1.0 | flag | index29 == this.game.Data.Turn)
          {
            int round = this.game.Data.Round;
            for (int index30 = 1; index30 <= round; ++index30)
            {
              if (!(index30 == this.game.Data.Round & index29 > this.game.Data.Turn))
              {
                int red = this.game.Data.RegimeObj[index29].Red;
                int green = this.game.Data.RegimeObj[index29].Green;
                int blue = this.game.Data.RegimeObj[index29].Blue;
                int x1 = (int) Math.Round((double) (index30 - 1) / (double) num34 * 750.0 + 100.0);
                int y1 = (int) Math.Round(700.0 - (double) numArray10[index29, index30] / (double) num32 * 600.0);
                if (x2 > 0)
                {
                  DrawMod.drawLine(ref graphics, x1, y1, x2, y2, red, green, blue, (int) byte.MaxValue, 2);
                  DrawMod.drawLine(ref graphics, x1, y1 + 1, x2, y2 + 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 2);
                }
                DrawMod.DrawBlock(ref graphics, x1 - 3, y1 - 3, 6, 6, red, green, blue, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref graphics, x1 - 3, y1 - 3, 6, 6, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                x2 = x1;
                y2 = y1;
                if (index30 == this.game.Data.Round)
                  DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index29].Name, vicFont4, x1 + 5, y1 - 15, this.game.VicColor2, this.game.VicColor2Shade);
              }
              else if (x2 != 0)
                DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index29].Name, vicFont4, x2 + 5, y2 - 15, this.game.VicColor2, this.game.VicColor2Shade);
            }
          }
        }
        int num40 = 1;
        do
        {
          DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num32 * ((double) num40 / 10.0))), vicFont4, 20, 700 - 60 * num40, this.game.VicColor2, this.game.VicColor2Shade);
          if (this.game.Data.AlternateRound > -1)
          {
            DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
            int num41 = (int) Math.Round(Conversion.Int((double) num34 * ((double) num40 / 10.0)));
            if (this.game.Data.AlternateRound == 31)
            {
              dateTime = dateTime.AddMonths((num41 - 1) * 1);
            }
            else
            {
              timeSpan = new TimeSpan((num41 - 1) * this.game.Data.AlternateRound, 0, 0, 0);
              dateTime = dateTime.Add(timeSpan);
            }
            string tstring1 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day));
            DrawMod.DrawTextVic2(ref graphics, tstring1, vicFont4, (int) Math.Round(((double) num41 - 1.5) / (double) num34 * 750.0 + 100.0), 710, this.game.VicColor2, this.game.VicColor2Shade);
            string tstring2 = Strings.Trim(Conversion.Str((object) dateTime.Year));
            DrawMod.DrawTextVic2(ref graphics, tstring2, vicFont4, (int) Math.Round(((double) num41 - 1.5) / (double) num34 * 750.0 + 100.0), 725, this.game.VicColor2, this.game.VicColor2Shade);
          }
          else
          {
            int num42 = (int) Math.Round(Conversion.Int((double) num34 * ((double) num40 / 10.0)));
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num34 * ((double) num40 / 10.0))), vicFont4, (int) Math.Round(((double) num42 - 1.5) / (double) num34 * 750.0 + 115.0), 720, this.game.VicColor2, this.game.VicColor2Shade);
          }
          ++num40;
        }
        while (num40 <= 10);
      }
      if (this.StatMode == 8)
      {
        int num43 = 1000;
        int num44 = 20;
        if (this.game.Data.Round > num44)
          num44 = this.game.Data.Round;
        int num45 = (int) Math.Round((double) num44 + Conversion.Int((double) num44 * 0.2));
        int[,] numArray14 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        int regimeCounter5 = this.game.Data.RegimeCounter;
        for (int index31 = 0; index31 <= regimeCounter5; ++index31)
        {
          int round = this.game.Data.Round;
          for (int index32 = 1; index32 <= round; ++index32)
          {
            int sfTypeCounter = this.game.Data.SFTypeCounter;
            for (int index33 = 0; index33 <= sfTypeCounter; ++index33)
            {
              int[,] numArray15 = numArray14;
              int[,] numArray16 = numArray15;
              int index34 = index31;
              int index35 = index34;
              int index36 = index32;
              int index37 = index36;
              int num46 = numArray15[index34, index36] + this.game.Data.RegimeObj[index31].SPresent[index33, index32] * this.game.Data.SFTypeObj[index33].PowerPts;
              numArray16[index35, index37] = num46;
              if (numArray14[index31, index32] > num43)
                num43 = numArray14[index31, index32];
            }
          }
        }
        int[,] numArray17 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        if (this.StatAggr > 0)
        {
          if (this.StatAggr == 1)
            num8 = 3;
          if (this.StatAggr == 2)
            num8 = 10;
          int regimeCounter6 = this.game.Data.RegimeCounter;
          for (int index38 = 0; index38 <= regimeCounter6; ++index38)
          {
            int round = this.game.Data.Round;
            for (int index39 = 1; index39 <= round; ++index39)
            {
              int num47 = 0;
              int num48 = 0;
              int num49 = index39 - num8;
              int num50 = index39 + num8;
              for (int index40 = num49; index40 <= num50; ++index40)
              {
                if (index40 > 0 & index40 <= this.game.Data.Round)
                {
                  ++num47;
                  num48 += numArray14[index38, index40];
                }
              }
              numArray17[index38, index39] = (int) Math.Round(Conversion.Int((double) num48 / (double) num47));
            }
          }
          int regimeCounter7 = this.game.Data.RegimeCounter;
          for (int index41 = 0; index41 <= regimeCounter7; ++index41)
          {
            int round = this.game.Data.Round;
            for (int index42 = 1; index42 <= round; ++index42)
              numArray14[index41, index42] = numArray17[index41, index42];
          }
        }
        DrawMod.drawLine(ref graphics, 100, 100, 100, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.drawLine(ref graphics, 100, 700, 850, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        ref Graphics local3 = ref graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.STATSGRADIENT);
        ref Bitmap local4 = ref bitmap;
        int y = 699 - BitmapStore.Getheight(this.game.STATSGRADIENT);
        double r = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Red / (double) byte.MaxValue - 1.0;
        double g = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Green / (double) byte.MaxValue - 1.0;
        double b = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Blue / (double) byte.MaxValue - 1.0;
        DrawMod.Draw(ref local3, ref local4, 101, y, (float) r, (float) g, (float) b, 1f);
        DrawMod.DrawTextVic2(ref graphics, "Power Pts", this.game.VicFont2, 15, 85, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Round", this.game.VicFont2, 880, 720, this.game.VicColor2, this.game.VicColor2Shade);
        int regimeCounter8 = this.game.Data.RegimeCounter;
        for (int index43 = 0; index43 <= regimeCounter8; ++index43)
        {
          int x2 = 0;
          int y2 = 0;
          if ((double) this.game.Data.RuleVar[313] == 1.0 | index43 == this.game.Data.Turn | !this.game.Data.RegimeObj[index43].DipBlock & !(this.game.Data.RegimeObj[index43].AI & this.game.Data.RegimeObj[index43].Sleep) && (double) this.game.Data.RuleVar[313] == 1.0 | flag | index43 == this.game.Data.Turn)
          {
            int round = this.game.Data.Round;
            for (int index44 = 1; index44 <= round; ++index44)
            {
              if (!(index44 == this.game.Data.Round & index43 > this.game.Data.Turn))
              {
                int red = this.game.Data.RegimeObj[index43].Red;
                int green = this.game.Data.RegimeObj[index43].Green;
                int blue = this.game.Data.RegimeObj[index43].Blue;
                int x1 = (int) Math.Round((double) (index44 - 1) / (double) num45 * 750.0 + 100.0);
                int y1 = (int) Math.Round(700.0 - (double) numArray14[index43, index44] / (double) num43 * 600.0);
                if (x2 > 0)
                {
                  DrawMod.drawLine(ref graphics, x1, y1, x2, y2, red, green, blue, (int) byte.MaxValue, 2);
                  DrawMod.drawLine(ref graphics, x1, y1 + 1, x2, y2 + 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 2);
                }
                DrawMod.DrawBlock(ref graphics, x1 - 3, y1 - 3, 6, 6, red, green, blue, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref graphics, x1 - 3, y1 - 3, 6, 6, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                x2 = x1;
                y2 = y1;
                if (index44 == this.game.Data.Round)
                  DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index43].Name, vicFont4, x1 + 5, y1 - 15, this.game.VicColor2, this.game.VicColor2Shade);
              }
              else if (x2 != 0)
                DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index43].Name, vicFont4, x2 + 5, y2 - 15, this.game.VicColor2, this.game.VicColor2Shade);
            }
          }
        }
        int num51 = 1;
        do
        {
          DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num43 * ((double) num51 / 10.0))), vicFont4, 20, 700 - 60 * num51, this.game.VicColor2, this.game.VicColor2Shade);
          if (this.game.Data.AlternateRound > -1)
          {
            DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
            int num52 = (int) Math.Round(Conversion.Int((double) num45 * ((double) num51 / 10.0)));
            if (this.game.Data.AlternateRound == 31)
            {
              dateTime = dateTime.AddMonths((num52 - 1) * 1);
            }
            else
            {
              timeSpan = new TimeSpan((num52 - 1) * this.game.Data.AlternateRound, 0, 0, 0);
              dateTime = dateTime.Add(timeSpan);
            }
            string tstring3 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day));
            DrawMod.DrawTextVic2(ref graphics, tstring3, vicFont4, (int) Math.Round(((double) num52 - 1.5) / (double) num45 * 750.0 + 100.0), 710, this.game.VicColor2, this.game.VicColor2Shade);
            string tstring4 = Strings.Trim(Conversion.Str((object) dateTime.Year));
            DrawMod.DrawTextVic2(ref graphics, tstring4, vicFont4, (int) Math.Round(((double) num52 - 1.5) / (double) num45 * 750.0 + 100.0), 725, this.game.VicColor2, this.game.VicColor2Shade);
          }
          else
          {
            int num53 = (int) Math.Round(Conversion.Int((double) num45 * ((double) num51 / 10.0)));
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num45 * ((double) num51 / 10.0))), vicFont4, (int) Math.Round(((double) num53 - 1.5) / (double) num45 * 750.0 + 115.0), 720, this.game.VicColor2, this.game.VicColor2Shade);
          }
          ++num51;
        }
        while (num51 <= 10);
      }
      if (this.StatMode == 0)
      {
        int num54 = 1000;
        int num55 = 20;
        if (this.game.Data.Round > num55)
          num55 = this.game.Data.Round;
        int num56 = (int) Math.Round((double) num55 + Conversion.Int((double) num55 * 0.2));
        int[,] numArray18 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        int regimeCounter9 = this.game.Data.RegimeCounter;
        for (int index45 = 0; index45 <= regimeCounter9; ++index45)
        {
          int round = this.game.Data.Round;
          for (int index46 = 1; index46 <= round; ++index46)
          {
            int itemTypeCounter = this.game.Data.ItemTypeCounter;
            for (int index47 = 0; index47 <= itemTypeCounter; ++index47)
            {
              int[,] numArray19 = numArray18;
              int[,] numArray20 = numArray19;
              int index48 = index45;
              int index49 = index48;
              int index50 = index46;
              int index51 = index50;
              int num57 = numArray19[index48, index50] + this.game.Data.RegimeObj[index45].SProd[index47, index46] * this.game.Data.ItemTypeObj[index47].ProdWeight;
              numArray20[index49, index51] = num57;
              if (numArray18[index45, index46] > num54)
                num54 = numArray18[index45, index46];
            }
          }
        }
        int[,] numArray21 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        if (this.StatAggr > 0)
        {
          if (this.StatAggr == 1)
            num8 = 3;
          if (this.StatAggr == 2)
            num8 = 10;
          int regimeCounter10 = this.game.Data.RegimeCounter;
          for (int index52 = 0; index52 <= regimeCounter10; ++index52)
          {
            int round = this.game.Data.Round;
            for (int index53 = 1; index53 <= round; ++index53)
            {
              int num58 = 0;
              int num59 = 0;
              int num60 = index53 - num8;
              int num61 = index53 + num8;
              for (int index54 = num60; index54 <= num61; ++index54)
              {
                if (index54 > 0 & index54 <= this.game.Data.Round)
                {
                  ++num58;
                  num59 += numArray18[index52, index54];
                }
              }
              numArray21[index52, index53] = (int) Math.Round(Conversion.Int((double) num59 / (double) num58));
            }
          }
          int regimeCounter11 = this.game.Data.RegimeCounter;
          for (int index55 = 0; index55 <= regimeCounter11; ++index55)
          {
            int round = this.game.Data.Round;
            for (int index56 = 1; index56 <= round; ++index56)
              numArray18[index55, index56] = numArray21[index55, index56];
          }
        }
        DrawMod.drawLine(ref graphics, 100, 100, 100, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.drawLine(ref graphics, 100, 700, 850, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        ref Graphics local5 = ref graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.STATSGRADIENT);
        ref Bitmap local6 = ref bitmap;
        int y = 699 - BitmapStore.Getheight(this.game.STATSGRADIENT);
        double r = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Red / (double) byte.MaxValue - 1.0;
        double g = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Green / (double) byte.MaxValue - 1.0;
        double b = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Blue / (double) byte.MaxValue - 1.0;
        DrawMod.Draw(ref local5, ref local6, 101, y, (float) r, (float) g, (float) b, 1f);
        DrawMod.DrawTextVic2(ref graphics, "Prod Pts", this.game.VicFont2, 15, 85, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Round", this.game.VicFont2, 880, 720, this.game.VicColor2, this.game.VicColor2Shade);
        int regimeCounter12 = this.game.Data.RegimeCounter;
        for (int index57 = 0; index57 <= regimeCounter12; ++index57)
        {
          int x2 = 0;
          int y2 = 0;
          if ((double) this.game.Data.RuleVar[313] == 1.0 | index57 == this.game.Data.Turn | !this.game.Data.RegimeObj[index57].DipBlock & !(this.game.Data.RegimeObj[index57].AI & this.game.Data.RegimeObj[index57].Sleep) && (double) this.game.Data.RuleVar[313] == 1.0 | flag | index57 == this.game.Data.Turn)
          {
            int round = this.game.Data.Round;
            for (int index58 = 1; index58 <= round; ++index58)
            {
              if (!(index58 == this.game.Data.Round & index57 > this.game.Data.Turn))
              {
                int red = this.game.Data.RegimeObj[index57].Red;
                int green = this.game.Data.RegimeObj[index57].Green;
                int blue = this.game.Data.RegimeObj[index57].Blue;
                int x1 = (int) Math.Round((double) (index58 - 1) / (double) num56 * 750.0 + 100.0);
                int y1 = (int) Math.Round(700.0 - (double) numArray18[index57, index58] / (double) num54 * 600.0);
                if (x2 > 0)
                {
                  DrawMod.drawLine(ref graphics, x1, y1, x2, y2, red, green, blue, (int) byte.MaxValue, 2);
                  DrawMod.drawLine(ref graphics, x1, y1 + 1, x2, y2 + 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 2);
                }
                DrawMod.DrawBlock(ref graphics, x1 - 3, y1 - 3, 6, 6, red, green, blue, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref graphics, x1 - 3, y1 - 3, 6, 6, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                x2 = x1;
                y2 = y1;
                if (index58 == this.game.Data.Round)
                  DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index57].Name, vicFont4, x1 + 5, y1 - 15, this.game.VicColor2, this.game.VicColor2Shade);
              }
              else if (x2 != 0)
                DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index57].Name, vicFont4, x2 + 5, y2 - 15, this.game.VicColor2, this.game.VicColor2Shade);
            }
          }
        }
        int num62 = 1;
        do
        {
          DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num54 * ((double) num62 / 10.0))), vicFont4, 20, 700 - 60 * num62, this.game.VicColor2, this.game.VicColor2Shade);
          if (this.game.Data.AlternateRound > -1)
          {
            DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
            int num63 = (int) Math.Round(Conversion.Int((double) num56 * ((double) num62 / 10.0)));
            if (this.game.Data.AlternateRound == 31)
            {
              dateTime = dateTime.AddMonths((num63 - 1) * 1);
            }
            else
            {
              timeSpan = new TimeSpan((num63 - 1) * this.game.Data.AlternateRound, 0, 0, 0);
              dateTime = dateTime.Add(timeSpan);
            }
            string tstring5 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day));
            DrawMod.DrawTextVic2(ref graphics, tstring5, vicFont4, (int) Math.Round(((double) num63 - 1.5) / (double) num56 * 750.0 + 100.0), 710, this.game.VicColor2, this.game.VicColor2Shade);
            string tstring6 = Strings.Trim(Conversion.Str((object) dateTime.Year));
            DrawMod.DrawTextVic2(ref graphics, tstring6, vicFont4, (int) Math.Round(((double) num63 - 1.5) / (double) num56 * 750.0 + 100.0), 725, this.game.VicColor2, this.game.VicColor2Shade);
          }
          else
          {
            int num64 = (int) Math.Round(Conversion.Int((double) num56 * ((double) num62 / 10.0)));
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num56 * ((double) num62 / 10.0))), vicFont4, (int) Math.Round(((double) num64 - 1.5) / (double) num56 * 750.0 + 115.0), 720, this.game.VicColor2, this.game.VicColor2Shade);
          }
          ++num62;
        }
        while (num62 <= 10);
      }
      if (this.StatMode == 1)
      {
        int[,] numArray22 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1 + 1];
        int num65 = 100;
        int num66 = 20;
        if (this.game.Data.Round > num66)
          num66 = this.game.Data.Round;
        int num67 = (int) Math.Round((double) num66 + Conversion.Int((double) num66 * 0.2));
        int regimeCounter13 = this.game.Data.RegimeCounter;
        for (int index59 = 0; index59 <= regimeCounter13; ++index59)
        {
          int regimeCounter14 = this.game.Data.RegimeCounter;
          for (int index60 = 0; index60 <= regimeCounter14; ++index60)
          {
            if (index59 == index60 | this.game.Data.RegimeObj[index60].UberRegime == index59)
            {
              int num68 = this.game.Data.Round + 1;
              for (int index61 = 1; index61 <= num68; ++index61)
              {
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index62 = 0; index62 <= sfTypeCounter; ++index62)
                {
                  int[,] numArray23 = numArray22;
                  int[,] numArray24 = numArray23;
                  int index63 = index59;
                  int index64 = index63;
                  int index65 = index61;
                  int index66 = index65;
                  int num69 = numArray23[index63, index65] + this.game.Data.RegimeObj[index60].SLoss[index62, index61] * this.game.Data.SFTypeObj[index62].PowerPts;
                  numArray24[index64, index66] = num69;
                  if (numArray22[index59, index61] > num65)
                    num65 = numArray22[index59, index61];
                }
              }
            }
          }
        }
        int[,] numArray25 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        if (this.StatAggr > 0)
        {
          if (this.StatAggr == 1)
            num8 = 3;
          if (this.StatAggr == 2)
            num8 = 10;
          int regimeCounter15 = this.game.Data.RegimeCounter;
          for (int index67 = 0; index67 <= regimeCounter15; ++index67)
          {
            int round = this.game.Data.Round;
            for (int index68 = 1; index68 <= round; ++index68)
            {
              int num70 = 0;
              int num71 = 0;
              int num72 = index68 - num8;
              int num73 = index68 + num8;
              for (int index69 = num72; index69 <= num73; ++index69)
              {
                if (index69 > 0 & index69 <= this.game.Data.Round)
                {
                  ++num70;
                  num71 += numArray22[index67, index69];
                }
              }
              numArray25[index67, index68] = (int) Math.Round(Conversion.Int((double) num71 / (double) num70));
            }
          }
          int regimeCounter16 = this.game.Data.RegimeCounter;
          for (int index70 = 0; index70 <= regimeCounter16; ++index70)
          {
            int round = this.game.Data.Round;
            for (int index71 = 1; index71 <= round; ++index71)
              numArray22[index70, index71] = numArray25[index70, index71];
          }
        }
        if (this.StatMode == 1)
        {
          DrawMod.drawLine(ref graphics, 100, 100, 100, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          DrawMod.drawLine(ref graphics, 100, 700, 850, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          ref Graphics local7 = ref graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.STATSGRADIENT);
          ref Bitmap local8 = ref bitmap;
          int y = 699 - BitmapStore.Getheight(this.game.STATSGRADIENT);
          double r = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Red / (double) byte.MaxValue - 1.0;
          double g = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Green / (double) byte.MaxValue - 1.0;
          double b = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Blue / (double) byte.MaxValue - 1.0;
          DrawMod.Draw(ref local7, ref local8, 101, y, (float) r, (float) g, (float) b, 1f);
          DrawMod.DrawTextVic2(ref graphics, "Power Pts", this.game.VicFont2, 10, 85, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref graphics, "Round", this.game.VicFont2, 880, 720, this.game.VicColor2, this.game.VicColor2Shade);
          int regimeCounter17 = this.game.Data.RegimeCounter;
          for (int index72 = 0; index72 <= regimeCounter17; ++index72)
          {
            int x2 = 0;
            int y2 = 0;
            if ((double) this.game.Data.RuleVar[313] == 1.0 | index72 == this.game.Data.Turn | !this.game.Data.RegimeObj[index72].DipBlock & !(this.game.Data.RegimeObj[index72].AI & this.game.Data.RegimeObj[index72].Sleep) && (double) this.game.Data.RuleVar[313] == 1.0 | flag | index72 == this.game.Data.Turn)
            {
              int round = this.game.Data.Round;
              for (int index73 = 1; index73 <= round; ++index73)
              {
                if (!(index73 == this.game.Data.Round & index72 > this.game.Data.Turn))
                {
                  int red = this.game.Data.RegimeObj[index72].Red;
                  int green = this.game.Data.RegimeObj[index72].Green;
                  int blue = this.game.Data.RegimeObj[index72].Blue;
                  int x1 = (int) Math.Round((double) (index73 - 1) / (double) num67 * 750.0 + 100.0);
                  int y1 = (int) Math.Round(700.0 - (double) numArray22[index72, index73] / (double) num65 * 600.0);
                  if (x2 > 0)
                  {
                    DrawMod.drawLine(ref graphics, x1, y1, x2, y2, red, green, blue, (int) byte.MaxValue, 2);
                    DrawMod.drawLine(ref graphics, x1, y1 + 1, x2, y2 + 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 2);
                  }
                  DrawMod.DrawBlock(ref graphics, x1 - 3, y1 - 3, 6, 6, red, green, blue, (int) byte.MaxValue);
                  DrawMod.DrawRectangle(ref graphics, x1 - 3, y1 - 3, 6, 6, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                  x2 = x1;
                  y2 = y1;
                  if (index73 == this.game.Data.Round)
                    DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index72].Name, vicFont4, x1 + 5, y1 - 15, this.game.VicColor2, this.game.VicColor2Shade);
                }
                else if (x2 != 0)
                  DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index72].Name, vicFont4, x2 + 5, y2 - 15, this.game.VicColor2, this.game.VicColor2Shade);
              }
            }
          }
          int num74 = 1;
          do
          {
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num65 * ((double) num74 / 10.0))), vicFont4, 20, 700 - 60 * num74, this.game.VicColor2, this.game.VicColor2Shade);
            if (this.game.Data.AlternateRound > -1)
            {
              DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
              int num75 = (int) Math.Round(Conversion.Int((double) num67 * ((double) num74 / 10.0)));
              if (this.game.Data.AlternateRound == 31)
              {
                dateTime = dateTime.AddMonths((num75 - 1) * 1);
              }
              else
              {
                timeSpan = new TimeSpan((num75 - 1) * this.game.Data.AlternateRound, 0, 0, 0);
                dateTime = dateTime.Add(timeSpan);
              }
              string tstring7 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day));
              DrawMod.DrawTextVic2(ref graphics, tstring7, vicFont4, (int) Math.Round(((double) num75 - 1.5) / (double) num67 * 750.0 + 100.0), 710, this.game.VicColor2, this.game.VicColor2Shade);
              string tstring8 = Strings.Trim(Conversion.Str((object) dateTime.Year));
              DrawMod.DrawTextVic2(ref graphics, tstring8, vicFont4, (int) Math.Round(((double) num75 - 1.5) / (double) num67 * 750.0 + 100.0), 725, this.game.VicColor2, this.game.VicColor2Shade);
            }
            else
            {
              int num76 = (int) Math.Round(Conversion.Int((double) num67 * ((double) num74 / 10.0)));
              DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num67 * ((double) num74 / 10.0))), vicFont4, (int) Math.Round(((double) num76 - 1.5) / (double) num67 * 750.0 + 115.0), 720, this.game.VicColor2, this.game.VicColor2Shade);
            }
            ++num74;
          }
          while (num74 <= 10);
        }
      }
      if (this.StatMode == 2)
      {
        int num77 = 100;
        int num78 = 20;
        if (this.game.Data.Round > num78)
          num78 = this.game.Data.Round;
        int num79 = (int) Math.Round((double) num78 + Conversion.Int((double) num78 * 0.2));
        int[,] numArray26 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1 + 1];
        int regimeCounter18 = this.game.Data.RegimeCounter;
        for (int index74 = 0; index74 <= regimeCounter18; ++index74)
        {
          int regimeCounter19 = this.game.Data.RegimeCounter;
          for (int index75 = 0; index75 <= regimeCounter19; ++index75)
          {
            if (index74 == index75 | this.game.Data.RegimeObj[index75].UberRegime == index74)
            {
              int num80 = this.game.Data.Round + 1;
              for (int index76 = 1; index76 <= num80; ++index76)
              {
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index77 = 0; index77 <= sfTypeCounter; ++index77)
                {
                  int[,] numArray27 = numArray26;
                  int[,] numArray28 = numArray27;
                  int index78 = index74;
                  int index79 = index78;
                  int index80 = index76;
                  int index81 = index80;
                  int num81 = numArray27[index78, index80] + this.game.Data.RegimeObj[index75].SKills[index77, index76] * this.game.Data.SFTypeObj[index77].PowerPts;
                  numArray28[index79, index81] = num81;
                  if (numArray26[index74, index76] > num77)
                    num77 = numArray26[index74, index76];
                }
              }
            }
          }
        }
        int[,] numArray29 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.Round + 1];
        if (this.StatAggr > 0)
        {
          if (this.StatAggr == 1)
            num8 = 3;
          if (this.StatAggr == 2)
            num8 = 10;
          int regimeCounter20 = this.game.Data.RegimeCounter;
          for (int index82 = 0; index82 <= regimeCounter20; ++index82)
          {
            int round = this.game.Data.Round;
            for (int index83 = 1; index83 <= round; ++index83)
            {
              int num82 = 0;
              int num83 = 0;
              int num84 = index83 - num8;
              int num85 = index83 + num8;
              for (int index84 = num84; index84 <= num85; ++index84)
              {
                if (index84 > 0 & index84 <= this.game.Data.Round)
                {
                  ++num82;
                  num83 += numArray26[index82, index84];
                }
              }
              numArray29[index82, index83] = (int) Math.Round(Conversion.Int((double) num83 / (double) num82));
            }
          }
          int regimeCounter21 = this.game.Data.RegimeCounter;
          for (int index85 = 0; index85 <= regimeCounter21; ++index85)
          {
            int round = this.game.Data.Round;
            for (int index86 = 1; index86 <= round; ++index86)
              numArray26[index85, index86] = numArray29[index85, index86];
          }
        }
        DrawMod.drawLine(ref graphics, 100, 100, 100, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        DrawMod.drawLine(ref graphics, 100, 700, 850, 700, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        ref Graphics local9 = ref graphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.STATSGRADIENT);
        ref Bitmap local10 = ref bitmap;
        int y = 699 - BitmapStore.Getheight(this.game.STATSGRADIENT);
        double r = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Red / (double) byte.MaxValue - 1.0;
        double g = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Green / (double) byte.MaxValue - 1.0;
        double b = (double) this.game.Data.RegimeObj[this.game.Data.Turn].Blue / (double) byte.MaxValue - 1.0;
        DrawMod.Draw(ref local9, ref local10, 101, y, (float) r, (float) g, (float) b, 1f);
        DrawMod.DrawTextVic2(ref graphics, "Power Pts", this.game.VicFont2, 10, 85, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Round", this.game.VicFont2, 880, 720, this.game.VicColor2, this.game.VicColor2Shade);
        int regimeCounter22 = this.game.Data.RegimeCounter;
        for (int index87 = 0; index87 <= regimeCounter22; ++index87)
        {
          int x2 = 0;
          int y2 = 0;
          if ((double) this.game.Data.RuleVar[313] == 1.0 | index87 == this.game.Data.Turn | !this.game.Data.RegimeObj[index87].DipBlock & !(this.game.Data.RegimeObj[index87].AI & this.game.Data.RegimeObj[index87].Sleep) && (double) this.game.Data.RuleVar[313] == 1.0 | flag | index87 == this.game.Data.Turn)
          {
            int round = this.game.Data.Round;
            for (int index88 = 1; index88 <= round; ++index88)
            {
              if (!(index88 == this.game.Data.Round & index87 > this.game.Data.Turn))
              {
                int red = this.game.Data.RegimeObj[index87].Red;
                int green = this.game.Data.RegimeObj[index87].Green;
                int blue = this.game.Data.RegimeObj[index87].Blue;
                int x1 = (int) Math.Round((double) (index88 - 1) / (double) num79 * 750.0 + 100.0);
                int y1 = (int) Math.Round(700.0 - (double) numArray26[index87, index88] / (double) num77 * 600.0);
                if (x2 > 0)
                {
                  DrawMod.drawLine(ref graphics, x1, y1, x2, y2, red, green, blue, (int) byte.MaxValue, 2);
                  DrawMod.drawLine(ref graphics, x1, y1 + 1, x2, y2 + 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 2);
                }
                DrawMod.DrawBlock(ref graphics, x1 - 3, y1 - 3, 6, 6, red, green, blue, (int) byte.MaxValue);
                DrawMod.DrawRectangle(ref graphics, x1 - 3, y1 - 3, 6, 6, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                x2 = x1;
                y2 = y1;
                if (index88 == this.game.Data.Round)
                  DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index87].Name, vicFont4, x1 + 5, y1 - 15, this.game.VicColor2, this.game.VicColor2Shade);
              }
              else if (x2 != 0)
                DrawMod.DrawTextVic2(ref graphics, this.game.Data.RegimeObj[index87].Name, vicFont4, x2 + 5, y2 - 15, this.game.VicColor2, this.game.VicColor2Shade);
            }
          }
        }
        int num86 = 1;
        do
        {
          DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num77 * ((double) num86 / 10.0))), vicFont4, 20, 700 - 60 * num86, this.game.VicColor2, this.game.VicColor2Shade);
          if (this.game.Data.AlternateRound > -1)
          {
            DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
            int num87 = (int) Math.Round(Conversion.Int((double) num79 * ((double) num86 / 10.0)));
            if (this.game.Data.AlternateRound == 31)
            {
              dateTime = dateTime.AddMonths((num87 - 1) * 1);
            }
            else
            {
              timeSpan = new TimeSpan((num87 - 1) * this.game.Data.AlternateRound, 0, 0, 0);
              dateTime = dateTime.Add(timeSpan);
            }
            string tstring9 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day));
            DrawMod.DrawTextVic2(ref graphics, tstring9, vicFont4, (int) Math.Round(((double) num87 - 1.5) / (double) num79 * 750.0 + 100.0), 710, this.game.VicColor2, this.game.VicColor2Shade);
            string tstring10 = Strings.Trim(Conversion.Str((object) dateTime.Year));
            DrawMod.DrawTextVic2(ref graphics, tstring10, vicFont4, (int) Math.Round(((double) num87 - 1.5) / (double) num79 * 750.0 + 100.0), 725, this.game.VicColor2, this.game.VicColor2Shade);
          }
          else
          {
            int num88 = (int) Math.Round(Conversion.Int((double) num79 * ((double) num86 / 10.0)));
            DrawMod.DrawTextVic2(ref graphics, Conversion.Str((object) Conversion.Int((double) num79 * ((double) num86 / 10.0))), vicFont4, (int) Math.Round(((double) num88 - 1.5) / (double) num79 * 750.0 + 115.0), 720, this.game.VicColor2, this.game.VicColor2Shade);
          }
          ++num86;
        }
        while (num86 <= 10);
      }
      if (this.StatMode == 3)
      {
        int[,] numArray30 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.SFTypeCounter + 1];
        int[,] numArray31 = new int[this.game.Data.RegimeCounter + 1, this.game.Data.SFTypeCounter + 1];
        int regimeCounter23 = this.game.Data.RegimeCounter;
        for (int index89 = 0; index89 <= regimeCounter23; ++index89)
        {
          int regimeCounter24 = this.game.Data.RegimeCounter;
          for (int index90 = 0; index90 <= regimeCounter24; ++index90)
          {
            if (index89 == index90 | this.game.Data.RegimeObj[index90].UberRegime == index89)
            {
              int num89 = this.game.Data.Round + 1;
              for (int index91 = 1; index91 <= num89; ++index91)
              {
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index92 = 0; index92 <= sfTypeCounter; ++index92)
                {
                  int[,] numArray32 = numArray30;
                  int[,] numArray33 = numArray32;
                  int index93 = index89;
                  int index94 = index93;
                  int index95 = index92;
                  int index96 = index95;
                  int num90 = numArray32[index93, index95] + this.game.Data.RegimeObj[index90].SKills[index92, index91] * Math.Max(1, this.game.Data.SFTypeObj[index92].Ratio);
                  numArray33[index94, index96] = num90;
                  int[,] numArray34 = numArray31;
                  int[,] numArray35 = numArray34;
                  int index97 = index89;
                  int index98 = index97;
                  int index99 = index92;
                  int index100 = index99;
                  int num91 = numArray34[index97, index99] + this.game.Data.RegimeObj[index90].SLoss[index92, index91] * Math.Max(1, this.game.Data.SFTypeObj[index92].Ratio);
                  numArray35[index98, index100] = num91;
                }
              }
            }
          }
        }
        this.OptionsListObj = new ATListClass();
        if (this.detailnr > this.game.Data.RegimeCounter)
          this.detailnr = -1;
        int tlistselect = -1;
        int num92 = -1;
        if (this.game.Data.RegimeCounter > -1)
        {
          int regimeCounter25 = this.game.Data.RegimeCounter;
          for (int tdata = 0; tdata <= regimeCounter25; ++tdata)
          {
            if ((double) this.game.Data.RuleVar[313] == 1.0)
            {
              ++num92;
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num92;
              this.OptionsListObj.add(this.game.Data.RegimeObj[tdata].Name, tdata);
            }
            else if (this.game.Data.Winner > -1 | tdata == this.game.Data.Turn | !this.game.Data.RegimeObj[tdata].DipBlock & !(this.game.Data.RegimeObj[tdata].AI & this.game.Data.RegimeObj[tdata].Sleep) && flag | tdata == this.game.Data.Turn | this.game.Data.RegimeObj[tdata].UberRegime == this.game.Data.Turn)
            {
              ++num92;
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num92;
              this.OptionsListObj.add(this.game.Data.RegimeObj[tdata].Name, tdata);
            }
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 16, 250, tlistselect, this.game, tHeader: "Regimes", tbackbitmap: (ref this.OwnBitmap), bbx: 40, bby: 100);
            this.OptionsListId = this.AddSubPart(ref tsubpart1, 40, 100, 250, 304, 0);
          }
        }
        this.OptionsList2Obj = new ATListClass();
        if (this.game.Data.RegimeCounter > -1)
        {
          if (this.detailnr > -1)
          {
            int sfTypeCounter = this.game.Data.SFTypeCounter;
            for (int tdata = 0; tdata <= sfTypeCounter; ++tdata)
            {
              if (numArray30[this.detailnr, tdata] > 0)
                this.OptionsList2Obj.add(this.game.Data.SFTypeObj[tdata].Name, tdata, Conversion.Str((object) numArray30[this.detailnr, tdata]));
            }
          }
          if (this.OptionsList2Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
          }
          else
          {
            tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList2Obj, 16, 250, -1, this.game, tHeader: "Kills", tShowPair: true, tValueWidth: 75, tbackbitmap: (ref this.OwnBitmap), bbx: 330, bby: 100);
            this.OptionsList2Id = this.AddSubPart(ref tsubpart1, 330, 100, 250, 304, 0);
          }
        }
        this.OptionsList3Obj = new ATListClass();
        if (this.game.Data.RegimeCounter > -1)
        {
          if (this.detailnr > -1)
          {
            int sfTypeCounter = this.game.Data.SFTypeCounter;
            for (int tdata = 0; tdata <= sfTypeCounter; ++tdata)
            {
              if (numArray31[this.detailnr, tdata] > 0)
                this.OptionsList3Obj.add(this.game.Data.SFTypeObj[tdata].Name, tdata, Conversion.Str((object) numArray31[this.detailnr, tdata]));
            }
          }
          if (this.OptionsList3Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
          }
          else
          {
            tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 16, 250, -1, this.game, tHeader: "Losses", tShowPair: true, tValueWidth: 75, tbackbitmap: (ref this.OwnBitmap), bbx: 620, bby: 100);
            this.OptionsList3Id = this.AddSubPart(ref tsubpart1, 620, 100, 250, 304, 0);
          }
        }
        if (this.detailnr == this.game.Data.Turn)
        {
          this.OptionsList9Obj = new ATListClass();
          if (this.game.Data.RegimeCounter > -1)
          {
            int itemTypeCounter = this.game.Data.ItemTypeCounter;
            for (int tdata = 0; tdata <= itemTypeCounter; ++tdata)
            {
              if (this.game.Data.RegimeObj[this.game.Data.Turn].SProd[tdata, this.game.Data.Round] > 0 | this.game.Data.RegimeObj[this.game.Data.Turn].SASProdLost[tdata] > 0)
              {
                string str = this.game.Data.ItemTypeObj[tdata].Name;
                string tvalue2 = "-";
                if (Strings.Len(str) > 15)
                  str = Strings.Left(str, 15);
                string tvalue = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].SProd[tdata, this.game.Data.Round]));
                if (this.game.Data.ASOn && this.game.Data.RegimeObj[this.game.Data.Turn].SASProdLost[tdata] > 0)
                  tvalue2 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].SASProdLost[tdata]));
                this.OptionsList9Obj.add(str, tdata, tvalue, tvalue2);
              }
            }
            if (this.OptionsList9Id > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsList9Id)].Refresh(this.OptionsList9Obj, -1);
              tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList9Obj, 11, 250, -1, this.game, tHeader: "Produced Type                          Prod", tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tbackbitmap: (ref this.OwnBitmap), bbx: 40, bby: 450);
              this.OptionsList9Id = this.AddSubPart(ref tsubpart1, 40, 450, 250, 224, 0);
            }
            else
            {
              tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList9Obj, 11, 250, -1, this.game, tHeader: "Produced Type                          Prod        AS Loss", tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tbackbitmap: (ref this.OwnBitmap), bbx: 40, bby: 450);
              this.OptionsList9Id = this.AddSubPart(ref tsubpart1, 40, 450, 250, 224, 0);
            }
          }
          this.OptionsList4Obj = new ATListClass();
          if (this.game.Data.RegimeCounter > -1)
          {
            if (this.detailnr > -1)
            {
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              for (int tdata = 0; tdata <= sfTypeCounter; ++tdata)
              {
                if (this.game.Data.RegimeObj[this.detailnr].SKills[tdata, 0] > 0)
                  this.OptionsList4Obj.add(this.game.Data.SFTypeObj[tdata].Name, tdata, Conversion.Str((object) (this.game.Data.SFTypeObj[tdata].Ratio * this.game.Data.RegimeObj[this.detailnr].SKills[tdata, 0])));
              }
            }
            if (this.OptionsList4Id > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
              this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
            }
            else
            {
              tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 11, 250, -1, this.game, tHeader: "Kills in this turn", tShowPair: true, tValueWidth: 75, tbackbitmap: (ref this.OwnBitmap), bbx: 330, bby: 450);
              this.OptionsList4Id = this.AddSubPart(ref tsubpart1, 330, 450, 250, 224, 0);
            }
          }
          this.OptionsList5Obj = new ATListClass();
          if (this.game.Data.RegimeCounter > -1)
          {
            if (this.detailnr > -1)
            {
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              for (int tdata = 0; tdata <= sfTypeCounter; ++tdata)
              {
                if (this.game.Data.RegimeObj[this.detailnr].SLoss[tdata, 0] > 0)
                  this.OptionsList5Obj.add(this.game.Data.SFTypeObj[tdata].Name, tdata, Conversion.Str((object) (this.game.Data.SFTypeObj[tdata].Ratio * this.game.Data.RegimeObj[this.detailnr].SLoss[tdata, 0])));
              }
            }
            if (this.OptionsList5Id > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsList5Id)].Refresh(this.OptionsList5Obj, -1);
              this.SubPartFlag[this.SubpartNr(this.OptionsList5Id)] = true;
            }
            else
            {
              tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList5Obj, 11, 250, -1, this.game, tHeader: "Losses in this turn", tShowPair: true, tValueWidth: 75, tbackbitmap: (ref this.OwnBitmap), bbx: 620, bby: 450);
              this.OptionsList5Id = this.AddSubPart(ref tsubpart1, 620, 450, 250, 224, 0);
            }
          }
        }
      }
      if (this.StatMode == 5)
      {
        this.OptionsList7Obj = new ATListClass();
        this.OptionsList8Obj = new ATListClass();
        int tlistselect = 0;
        this.OptionsList7Obj.add("Whole army", -1);
        if (this.detailnr < 0)
          tlistselect = 0;
        int num93 = 0;
        int unitCounter11 = this.game.Data.UnitCounter;
        for (int tdata = 0; tdata <= unitCounter11; ++tdata)
        {
          if (this.game.Data.UnitObj[tdata].Regime > -1 && this.game.Data.UnitObj[tdata].Regime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[tdata].Regime].UberRegime == this.game.Data.Turn && this.game.Data.UnitObj[tdata].IsHQ & this.game.Data.UnitObj[tdata].PreDef == -1)
          {
            ++num93;
            this.OptionsList7Obj.add(this.game.Data.UnitObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              tlistselect = num93;
          }
        }
        if (this.OptionsList7Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList7Id)].Refresh(this.OptionsList7Obj, tlistselect);
          this.SubPartFlag[this.SubpartNr(this.OptionsList7Id)] = true;
        }
        else
        {
          tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList7Obj, 26, 350, tlistselect, this.game, tHeader: "Headquarters", tbackbitmap: (ref this.OwnBitmap), bbx: 50, bby: 100);
          this.OptionsList7Id = this.AddSubPart(ref tsubpart1, 50, 100, 350, 464, 0);
        }
        object[] objArray1 = new object[this.game.Data.SFTypeCounter + 1];
        if (this.Abstr == 0)
        {
          int unitCounter12 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter12; ++unr)
          {
            if (this.game.Data.UnitObj[unr].Regime > -1 && this.game.Data.UnitObj[unr].PreDef == -1 & (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].UberRegime == this.game.Data.Turn))
            {
              if (this.detailnr == -1)
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index101 = 0; index101 <= sfCount; ++index101)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index101];
                  object[] objArray2 = objArray1;
                  object[] objArray3 = objArray2;
                  int type = this.game.Data.SFObj[sf].Type;
                  int index102 = type;
                  object obj = Operators.AddObject(objArray2[type], (object) this.game.Data.SFObj[sf].Qty);
                  objArray3[index102] = obj;
                }
              }
              else if (unr == this.detailnr | this.detailnr == -1 | !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].HQ == this.detailnr | this.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.detailnr))
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index103 = 0; index103 <= sfCount; ++index103)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index103];
                  object[] objArray4 = objArray1;
                  object[] objArray5 = objArray4;
                  int type = this.game.Data.SFObj[sf].Type;
                  int index104 = type;
                  object obj = Operators.AddObject(objArray4[type], (object) this.game.Data.SFObj[sf].Qty);
                  objArray5[index104] = obj;
                }
              }
            }
          }
          int sfTypeCounter = this.game.Data.SFTypeCounter;
          for (int tdata = 0; tdata <= sfTypeCounter; ++tdata)
          {
            if (Operators.ConditionalCompareObjectGreater(objArray1[tdata], (object) 0, false))
              this.OptionsList8Obj.add(this.game.Data.SFTypeObj[tdata].Name, tdata, Strings.Trim(Conversion.Str(Operators.MultiplyObject(objArray1[tdata], (object) Math.Max(1, this.game.Data.SFTypeObj[tdata].Ratio)))));
          }
        }
        else if (this.Abstr == 1)
        {
          object[] objArray6 = new object[101];
          int unitCounter13 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter13; ++unr)
          {
            if (this.game.Data.UnitObj[unr].Regime > -1 && this.game.Data.UnitObj[unr].PreDef == -1 & (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].UberRegime == this.game.Data.Turn))
            {
              if (this.detailnr == -1)
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index105 = 0; index105 <= sfCount; ++index105)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index105];
                  int unitGroup = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup;
                  if (unitGroup > -1 & unitGroup < 100)
                  {
                    object[] objArray7 = objArray6;
                    object[] objArray8 = objArray7;
                    int index106 = unitGroup;
                    int index107 = index106;
                    object obj = Operators.AddObject(objArray7[index106], (object) (this.game.Data.SFObj[sf].Qty * Math.Max(1, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio)));
                    objArray8[index107] = obj;
                  }
                }
              }
              else if (unr == this.detailnr | this.detailnr == -1 | !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].HQ == this.detailnr | this.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.detailnr))
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index108 = 0; index108 <= sfCount; ++index108)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index108];
                  int unitGroup = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup;
                  if (unitGroup > -1 & unitGroup < 100)
                  {
                    object[] objArray9 = objArray6;
                    object[] objArray10 = objArray9;
                    int index109 = unitGroup;
                    int index110 = index109;
                    object obj = Operators.AddObject(objArray9[index109], (object) (this.game.Data.SFObj[sf].Qty * Math.Max(1, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio)));
                    objArray10[index110] = obj;
                  }
                }
              }
            }
          }
          int tdata = 0;
          do
          {
            if (Operators.ConditionalCompareObjectGreater(objArray6[tdata], (object) 0, false))
              this.OptionsList8Obj.add(this.game.Data.TempString[400 + tdata], tdata, Strings.Trim(Conversion.Str(RuntimeHelpers.GetObjectValue(objArray6[tdata]))));
            ++tdata;
          }
          while (tdata <= 99);
        }
        if (this.OptionsList8Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList8Id)].Refresh(this.OptionsList8Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList8Id)] = true;
        }
        else
        {
          tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList8Obj, 26, 440, -1, this.game, tHeader: "Troops", tShowPair: true, tValueWidth: 100, tbackbitmap: (ref this.OwnBitmap), bbx: 480, bby: 160);
          this.OptionsList8Id = this.AddSubPart(ref tsubpart1, 480, 160, 440, 464, 0);
        }
        DrawMod.DrawBlock(ref graphics, 480, 95, 440, 45, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        if (this.Abstr == 0)
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 100);
          this.but4id = this.AddSubPart(ref tsubpart1, 500, 100, 32, 16, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 100);
          this.but4id = this.AddSubPart(ref tsubpart1, 500, 100, 32, 16, 1);
        }
        if (this.Abstr == 1)
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 100);
          this.but5id = this.AddSubPart(ref tsubpart1, 700, 100, 32, 16, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 100);
          this.but5id = this.AddSubPart(ref tsubpart1, 700, 100, 32, 16, 1);
        }
        DrawMod.DrawTextVic2(ref graphics, "Specific", this.game.VicFont2, 550, 113, this.game.VicColor2, this.game.VicColor2Shade);
        DrawMod.DrawTextVic2(ref graphics, "Class", this.game.VicFont2, 750, 113, this.game.VicColor2, this.game.VicColor2Shade);
      }
      if (this.StatMode == 6)
      {
        this.OptionsList6Obj = new ATListClass();
        int num94 = 0;
        int Number1 = 1;
        do
        {
          int num95 = 0;
          int ruleCounter = this.game.Data.RuleCounter;
          for (int Number2 = 0; Number2 <= ruleCounter; ++Number2)
          {
            if (this.game.Data.RuleGroup[Number2] == Number1 & this.game.Data.RuleString[Number2].Length > 2 & Operators.CompareString(this.game.Data.RuleString[Number2], "OBSOLETE", false) != 0)
            {
              if (num95 == 0 & num94 == 1)
                this.OptionsList6Obj.add("   ", -1, " ");
              if (num95 == 0)
              {
                num95 = 1;
                num94 = 1;
                this.OptionsList6Obj.add("RULEGROUP " + Strings.Trim(Conversion.Str((object) Number1)), -1);
              }
              string str = Strings.Trim(Conversion.Str((object) Number2)) + ") " + this.game.Data.RuleString[Number2];
              if (str.Length > 75)
                str = Strings.Left(str, 73) + "...";
              this.OptionsList6Obj.add(str, -1, Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[Number2])));
            }
          }
          ++Number1;
        }
        while (Number1 <= 19);
        if (this.OptionsList6Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList6Id)].Refresh(this.OptionsList6Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList6Id)] = true;
        }
        else
        {
          tsubpart1 = (SubPartClass) new ATListSubPartClass(this.OptionsList6Obj, 37, 830, -1, this.game, tHeader: "Rule Variables", tShowPair: true, tValueWidth: 250, tbackbitmap: (ref this.OwnBitmap), bbx: 90, bby: 90);
          this.OptionsList6Id = this.AddSubPart(ref tsubpart1, 90, 90, 830, 640, 0);
        }
      }
      if (this.StatMode == 7)
      {
        if (this.OptionsList2Id > 0)
        {
          this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
        }
        else
        {
          string description = this.game.Data.Description;
          string str1 = !this.game.Data.ASOn ? description + "\r\n\r\nAnti Supply is turned OFF" : description + "\r\n\r\nAnti Supply is turned ON";
          string str2 = !this.game.Data.PBEM ? str1 + "\r\n\r\nAnti PBEM Cheat is turned OFF" : str1 + "\r\n\r\nAnti PBEM Cheat is turned ON";
          string tText = !this.game.Data.TerrorMode ? str2 + "\r\n\r\nTerror Mode is turned OFF" : str2 + "\r\n\r\nTerror Mode is turned ON";
          if (this.game.Data.VPWin > 0 | this.game.EventRelatedObj.CheckVP(this.game.Data.Turn, 0, 0, 0) > 0)
            tText = tText + "\r\n\r\nYou currently have " + Conversion.Str((object) this.game.EventRelatedObj.CheckVP(this.game.Data.Turn, 0, 0, 0)) + " Victory Points (VP) in possesion.";
          int index111 = 0;
          do
          {
            if (this.game.Data.Variants[index111] > -1)
              tText = this.game.Data.GameSlot[this.game.Data.Variants[index111]] > 0 ? tText + "\r\n\r\n" + this.game.Data.GameSlotName[this.game.Data.Variants[index111]] + " is turned ON" : tText + "\r\n\r\n" + this.game.Data.GameSlotName[this.game.Data.Variants[index111]] + " is turned OFF";
            ++index111;
          }
          while (index111 <= 9);
          tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 840, 37, this.game.VicFont3, "Briefing + Start settings", true, tText, Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 90, bby: 90);
          this.OptionsList2Id = this.AddSubPart(ref tsubpart1, 90, 90, 840, 640, 0);
        }
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
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
            int index2 = 0;
            while (this.TabId[index2] <= 0 || this.SubPartID[index1] != this.TabId[index2])
            {
              ++index2;
              if (index2 > 12)
              {
                int num1 = this.SubPartID[index1];
                if (num1 == this.but1id)
                {
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.but2id)
                {
                  this.SortStart -= 10;
                  if (0 > this.SortStart)
                    this.SortStart = 0;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.but3id)
                {
                  this.SortStart += 10;
                  if (this.SortStart > this.sortcount)
                    this.SortStart = this.sortcount;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.but4id)
                {
                  this.Abstr = 0;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.but5id)
                {
                  this.Abstr = 1;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.ModeButton0Id)
                {
                  this.StatAggr = 0;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.ModeButton1Id)
                {
                  this.StatAggr = 1;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.ModeButton2Id)
                {
                  this.StatAggr = 2;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsListId)
                {
                  int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  if (num2 > -1)
                    this.detailnr = num2;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList7Id)
                {
                  this.detailnr = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num3;
                if (num1 == this.OptionsList2Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList3Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList4Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList5Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList6Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList8Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList9Id)
                {
                  num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.UpgradeId)
                {
                  this.AutoUpgrade(this.detailnr5);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 != this.GOid)
                  return windowReturnClass;
                this.game.EditObj.UnitSelected = this.detailnr5;
                int num4 = 265;
                int x1;
                int y1;
                if (this.game.Data.UnitObj[this.detailnr5].X > -1)
                {
                  x1 = this.game.Data.UnitObj[this.detailnr5].X;
                  y1 = this.game.Data.UnitObj[this.detailnr5].Y;
                }
                else
                {
                  x1 = this.game.Data.UnitObj[this.game.Data.UnitObj[this.detailnr5].OnBoard].X;
                  y1 = this.game.Data.UnitObj[this.game.Data.UnitObj[this.detailnr5].OnBoard].Y;
                }
                this.game.CornerX = (int) Math.Round((double) x1 - ((double) this.game.ScreenWidth / 2.0 - 0.0) / 53.0);
                this.game.CornerY = (int) Math.Round((double) y1 - ((double) this.game.ScreenHeight / 2.0 - (double) num4) / 48.0);
                if (this.game.CornerX < 0)
                  this.game.CornerX = 0;
                if (this.game.CornerY < 0)
                  this.game.CornerY = 0;
                if (this.game.Data.Round == 0)
                  num4 += 100;
                int num5 = (int) Math.Round((double) (this.game.ScreenWidth - 220 - 0) / 53.0);
                int num6 = (int) Math.Round((double) (this.game.ScreenHeight - num4) / 48.0);
                int num7 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - this.game.CornerX;
                int num8 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - this.game.CornerY;
                if (num5 > num7)
                  this.game.CornerX = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - num5 + 2;
                if (num6 > num8)
                  this.game.CornerY = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - num6 + 2;
                if ((this.game.CornerX + 10) % 2 > 0)
                  ++this.game.CornerX;
                if ((this.game.CornerY + 10) % 2 > 0)
                  ++this.game.CornerY;
                this.game.SelectX = x1;
                this.game.SelectY = y1;
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            this.StatMode = index2;
            this.game.EditObj.LastStatWindow = this.StatMode;
            this.detailnr = -1;
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
            if (this.OptionsList3Id > 0)
            {
              this.RemoveSubPart(this.OptionsList3Id);
              this.OptionsList3Id = 0;
            }
            if (this.OptionsList4Id > 0)
            {
              this.RemoveSubPart(this.OptionsList4Id);
              this.OptionsList4Id = 0;
            }
            if (this.OptionsList5Id > 0)
            {
              this.RemoveSubPart(this.OptionsList5Id);
              this.OptionsList5Id = 0;
            }
            if (this.OptionsList6Id > 0)
            {
              this.RemoveSubPart(this.OptionsList6Id);
              this.OptionsList6Id = 0;
            }
            if (this.OptionsList7Id > 0)
            {
              this.RemoveSubPart(this.OptionsList7Id);
              this.OptionsList7Id = 0;
            }
            if (this.OptionsList8Id > 0)
            {
              this.RemoveSubPart(this.OptionsList8Id);
              this.OptionsList8Id = 0;
            }
            if (this.OptionsList9Id > 0)
            {
              this.RemoveSubPart(this.OptionsList9Id);
              this.OptionsList9Id = 0;
            }
            if (this.StatMode == 9 && !this.supplycalcdone)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.CalculateSupply();
              this.game.FormRef.Cursor = Cursors.Default;
            }
            this.detailnr = -1;
            this.DoStuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        int mzcount = this.mzcount;
        for (int index = 0; index <= mzcount; ++index)
        {
          if (x > this.mzx[index] & y > this.mzy[index] && x < this.mzx2[index] & y < this.mzy2[index])
          {
            this.detailnr5 = this.mznr[index];
            if (this.mzdetnr[index] == 1)
            {
              this.detailnr = this.mznr[index];
              this.detailnr2 = -1;
              this.detailnr3 = -1;
              this.detailnr3 = -1;
              this.detailnr4 = -1;
            }
            if (this.mzdetnr[index] == 2)
            {
              this.detailnr2 = this.mznr[index];
              this.detailnr3 = -1;
              this.detailnr4 = -1;
            }
            if (this.mzdetnr[index] == 3)
            {
              this.detailnr3 = this.mznr[index];
              this.detailnr4 = -1;
            }
            if (this.mzdetnr[index] == 4)
              this.detailnr4 = this.mznr[index];
            this.DoStuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public void AutoUpgrade(int hqused)
    {
      object[] objArray = new object[3];
      int num1;
      if (this.game.HandyFunctionsObj.HowmanyHQsBelow(hqused) > 0)
        num1 = (int) Interaction.MsgBox((object) "Also auto upgrade units of subordinate HQs?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest");
      int unitCounter = this.game.Data.UnitCounter;
      int Number1;
      int Number2;
      int Number3;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].HQ == hqused | unr == hqused | num1 == 6 & this.game.HandyFunctionsObj.HasUnitHQSomewhereUp(unr, hqused) && this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[hqused].X > -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LandscapeType].IsSea)
        {
          for (int sfCount = this.game.Data.UnitObj[unr].SFCount; sfCount >= 0; sfCount += -1)
          {
            this.sfnr = this.game.Data.UnitObj[unr].SFList[sfCount];
            objArray[0] = (object) -1;
            objArray[1] = (object) -1;
            objArray[2] = (object) -1;
            if (this.sfnr > -1 && this.game.HandyFunctionsObj.CanUpgrade(this.sfnr, unr))
            {
              if (this.game.Data.UnitObj[unr].IsHQ)
              {
                objArray[0] = (object) unr;
                int hq1 = this.game.Data.UnitObj[Conversions.ToInteger(objArray[0])].HQ;
                if (hq1 > -1 && this.game.Data.UnitObj[hq1].X > -1)
                {
                  this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, allowshoredrop: true);
                  if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq1].Map].Value[this.game.Data.UnitObj[hq1].X, this.game.Data.UnitObj[hq1].Y] <= (double) this.game.Data.RuleVar[53])
                  {
                    objArray[1] = (object) hq1;
                    int hq2 = this.game.Data.UnitObj[Conversions.ToInteger(objArray[1])].HQ;
                    if (hq2 > -1 && this.game.Data.UnitObj[hq2].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq2].Map].Value[this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y] <= (double) this.game.Data.RuleVar[53])
                      objArray[2] = (object) hq2;
                  }
                }
              }
              else if (this.game.Data.UnitObj[unr].HQ > -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[unr].HQ].X > -1)
              {
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, allowshoredrop: true);
                int hq3 = this.game.Data.UnitObj[unr].HQ;
                if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq3].Map].Value[this.game.Data.UnitObj[hq3].X, this.game.Data.UnitObj[hq3].Y] <= (double) this.game.Data.RuleVar[53])
                {
                  objArray[0] = (object) hq3;
                  int hq4 = this.game.Data.UnitObj[Conversions.ToInteger(objArray[0])].HQ;
                  if (hq4 > -1 && this.game.Data.UnitObj[hq4].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq4].Map].Value[this.game.Data.UnitObj[hq4].X, this.game.Data.UnitObj[hq4].Y] <= (double) this.game.Data.RuleVar[53])
                  {
                    objArray[1] = (object) hq4;
                    int hq5 = this.game.Data.UnitObj[Conversions.ToInteger(objArray[1])].HQ;
                    if (hq5 > -1 && this.game.Data.UnitObj[hq5].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq5].Map].Value[this.game.Data.UnitObj[hq5].X, this.game.Data.UnitObj[hq5].Y] <= (double) this.game.Data.RuleVar[53])
                      objArray[2] = (object) hq5;
                  }
                }
              }
              int qty1 = this.game.Data.SFObj[this.sfnr].Qty;
              int num2 = 0;
              if (Conversions.ToBoolean(Operators.AndObject((object) (qty1 > 0), Operators.CompareObjectGreater(objArray[0], (object) -1, false))))
              {
                int qty2 = this.game.HandyFunctionsObj.CanUpgradeMax(this.sfnr, unr, Conversions.ToInteger(objArray[0]));
                if (qty2 > qty1)
                  qty2 = qty1;
                if (qty2 > 0)
                {
                  this.game.ProcessingObj.DoUpgrade(unr, this.sfnr, qty2, Conversions.ToInteger(objArray[0]));
                  qty1 -= qty2;
                  Number1 += qty2;
                  num2 = 1;
                }
              }
              if (Conversions.ToBoolean(Operators.AndObject((object) (qty1 > 0), Operators.CompareObjectGreater(objArray[1], (object) -1, false))))
              {
                int qty3 = this.game.HandyFunctionsObj.CanUpgradeMax(this.sfnr, unr, Conversions.ToInteger(objArray[1]));
                if (qty3 > qty1)
                  qty3 = qty1;
                if (qty3 > 0)
                {
                  this.game.ProcessingObj.DoUpgrade(unr, this.sfnr, qty3, Conversions.ToInteger(objArray[1]));
                  qty1 -= qty3;
                  Number1 += qty3;
                  num2 = 1;
                }
              }
              if (Conversions.ToBoolean(Operators.AndObject((object) (qty1 > 0), Operators.CompareObjectGreater(objArray[2], (object) -1, false))))
              {
                int qty4 = this.game.HandyFunctionsObj.CanUpgradeMax(this.sfnr, unr, Conversions.ToInteger(objArray[2]));
                if (qty4 > qty1)
                  qty4 = qty1;
                if (qty4 > 0)
                {
                  this.game.ProcessingObj.DoUpgrade(unr, this.sfnr, qty4, Conversions.ToInteger(objArray[2]));
                  qty1 -= qty4;
                  Number1 += qty4;
                  num2 = 1;
                }
              }
              if ((uint) num2 > 0U)
                ++Number2;
              if (qty1 > 0)
                ++Number3;
            }
          }
        }
      }
      if (Number2 > 0)
      {
        string Prompt;
        if (num1 == 6)
          Prompt = "Auto upgraded " + Conversion.Str((object) Number1) + " troops in " + Conversion.Str((object) Number2) + " units under indirect and direct command of " + this.game.Data.UnitObj[hqused].Name + ".";
        else
          Prompt = "Auto upgraded " + Conversion.Str((object) Number1) + " troops in " + Conversion.Str((object) Number2) + " units under direct command of " + this.game.Data.UnitObj[hqused].Name + ".";
        if (Number3 > 0)
          Prompt = Prompt + "We did not have enough supplies in chain of command to upgrade troops in " + Conversion.Str((object) Number3) + " units.";
        int num3 = (int) Interaction.MsgBox((object) Prompt, Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        string Prompt = "No units have been upgraded. ";
        if (Number3 > 0)
          Prompt = Prompt + "We did not have enough supplies in chain of command to upgrade troops in " + Conversion.Str((object) Number3) + " units.";
        int num4 = (int) Interaction.MsgBox((object) Prompt, Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
    }

    public void CalculateSupply()
    {
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      this.sortcount = -1;
      int num1 = -1;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        numArray1[index] = -1;
        numArray2[index] = 0;
      }
      int num2;
      do
      {
        num2 = 0;
        ++num1;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter2; ++index)
        {
          if (this.game.Data.UnitObj[index].PreDef == -1 && (this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index].Regime].UberRegime == this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == this.game.Data.UnitObj[index].Regime | this.game.Data.Turn == this.game.Data.UnitObj[index].Regime) & this.game.Data.UnitObj[index].PreDef <= -1)
          {
            if (num1 == 0)
            {
              if (this.game.Data.UnitObj[index].HQ == -1)
              {
                numArray1[index] = 0;
                num2 = 1;
              }
            }
            else if (this.game.Data.UnitObj[index].HQ > -1 & numArray1[index] == -1 & this.game.Data.UnitObj[index].PreDef <= -1)
            {
              int hq = this.game.Data.UnitObj[index].HQ;
              if (numArray1[hq] == num1 - 1)
              {
                num2 = 1;
                numArray1[index] = num1;
              }
            }
          }
        }
      }
      while (num2 > 0);
      int num3 = num1 - 1;
      if (num3 == -1)
        return;
      this.supplyneed1 = new int[this.game.Data.UnitCounter + 1];
      this.supplyneed2 = new int[this.game.Data.UnitCounter + 1];
      this.supplyneed3 = new int[this.game.Data.UnitCounter + 1];
      this.supplyneed4 = new int[this.game.Data.UnitCounter + 1];
      this.supplyout1 = new int[this.game.Data.UnitCounter + 1];
      this.supplyout2 = new int[this.game.Data.UnitCounter + 1];
      this.supplyout3 = new int[this.game.Data.UnitCounter + 1];
      this.supplyin1 = new int[this.game.Data.UnitCounter + 1];
      this.supplyin2 = new int[this.game.Data.UnitCounter + 1];
      this.supplyin3 = new int[this.game.Data.UnitCounter + 1];
      this.supplyin4 = new int[this.game.Data.UnitCounter + 1];
      for (int index1 = num3; index1 >= 0; index1 += -1)
      {
        if (index1 == num3 & (double) this.game.Data.RuleVar[335] > 0.0)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int regnr = 0; regnr <= regimeCounter; ++regnr)
          {
            if (regnr == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == regnr)
            {
              int num4 = 0;
              do
              {
                if (this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 0.0f + (float) (num4 * 4)))] > 0 && this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 1f + (float) (num4 * 4)))] > 0 && this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 2f + (float) (num4 * 4)))] > -1 && this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 3f + (float) (num4 * 4)))] > 0)
                {
                  SimpleList supplyReceivingHq = this.game.HandyFunctionsObj.GetSupplyReceivingHQ(this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 0.0f + (float) (num4 * 4)))], this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 1f + (float) (num4 * 4)))], this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 2f + (float) (num4 * 4)))], regnr, this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) (this.game.Data.RuleVar[335] + 3f + (float) (num4 * 4)))]);
                  if (supplyReceivingHq.Counter > -1)
                  {
                    int counter = supplyReceivingHq.Counter;
                    for (int index2 = 0; index2 <= counter; ++index2)
                    {
                      int[] supplyin1 = this.supplyin1;
                      int[] numArray3 = supplyin1;
                      int[] id = supplyReceivingHq.Id;
                      int[] numArray4 = id;
                      int index3 = index2;
                      int index4 = index3;
                      int index5 = numArray4[index4];
                      int num5 = supplyin1[id[index3]] + supplyReceivingHq.Data1[index2];
                      numArray3[index5] = num5;
                    }
                  }
                }
                ++num4;
              }
              while (num4 <= 3);
            }
          }
        }
        int unitCounter3 = this.game.Data.UnitCounter;
        for (int index6 = 0; index6 <= unitCounter3; ++index6)
        {
          if (numArray1[index6] == index1 && this.game.Data.UnitObj[index6].X > -1 & this.game.Data.UnitObj[index6].PreDef == -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[index6].Regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[index6].Regime].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index6].Regime].UberRegime == this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == this.game.Data.UnitObj[index6].Regime | this.game.Data.Turn == this.game.Data.UnitObj[index6].Regime && this.game.Data.UnitObj[index6].IsHQ)
          {
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[index6].X, this.game.Data.UnitObj[index6].Y, this.game.Data.UnitObj[index6].Map, allowshoredrop: true);
            int unitCounter4 = this.game.Data.UnitCounter;
            int num6;
            float num7;
            for (int unr = 0; unr <= unitCounter4; ++unr)
            {
              if ((unr == index6 | this.game.Data.UnitObj[unr].HQ == index6) & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1)
              {
                num6 = 0;
                int num8 = 0;
                int num9 = 0;
                num7 = 1f;
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index7 = 0; index7 <= sfCount; ++index7)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index7];
                  num8 = (int) Math.Round((double) num8 + (double) this.game.Data.SFObj[sf].Qty * ((double) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].BasicSupplyNeed * 1.5));
                  num9 += this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].SupplyCarry;
                }
                int num10 = num9 + this.game.HandyFunctionsObj.UnitSupplyUse(unr, true);
                if (num8 + this.game.Data.UnitObj[unr].Supply > num10)
                  num8 = num10 - this.game.Data.UnitObj[unr].Supply;
                if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LandscapeType].IsSea)
                  num8 = 0;
                if (0 > num8)
                  num8 = 0;
                this.supplyneed1[unr] = (int) Math.Round((double) num8 * ((double) this.game.Data.UnitObj[unr].SOSupReqPercent / 100.0));
                int hq1 = this.game.Data.UnitObj[unr].HQ;
                if (hq1 == index6 & !this.game.Data.UnitObj[unr].IsHQ)
                {
                  int[] supplyout1 = this.supplyout1;
                  int[] numArray5 = supplyout1;
                  int index8 = hq1;
                  int index9 = index8;
                  int num11 = supplyout1[index8] + num8;
                  numArray5[index9] = num11;
                }
                if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > (double) this.game.Data.RuleVar[3])
                  num8 = 0;
                else if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > (double) this.game.Data.RuleVar[53])
                  num8 = (int) Math.Round((double) num8 * 0.25);
                else if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > (double) this.game.Data.RuleVar[52])
                  num8 = (int) Math.Round((double) num8 * 0.5);
                else if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > (double) this.game.Data.RuleVar[51])
                  num8 = (int) Math.Round((double) num8 * 0.75);
                this.supplyneed4[unr] = num8;
                int hq2 = this.game.Data.UnitObj[unr].HQ;
                if (hq2 == index6 & !this.game.Data.UnitObj[unr].IsHQ)
                {
                  int[] supplyout2 = this.supplyout2;
                  int[] numArray6 = supplyout2;
                  int index10 = hq2;
                  int index11 = index10;
                  int num12 = supplyout2[index10] + num8;
                  numArray6[index11] = num12;
                  this.supplyin3[unr] = num8;
                }
                this.supplyneed2[unr] = this.game.HandyFunctionsObj.UnitSupplyUse(unr, true);
                this.supplyneed3[unr] = this.game.HandyFunctionsObj.UnitSupplyStore(unr);
              }
            }
            num6 = 0;
            int locCounter = this.game.Data.LocCounter;
            for (int locnr = 0; locnr <= locCounter; ++locnr)
            {
              int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime;
              if (regime > -1 && regime == this.game.Data.Turn | this.game.Data.RegimeObj[regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == regime && this.game.Data.LocObj[locnr].HQ == index6)
              {
                int prodslot = 0;
                do
                {
                  if (this.game.Data.LocObj[locnr].Production[prodslot] > -1 && this.game.Data.ItemTypeObj[this.game.Data.LocObj[locnr].Production[prodslot]].IsSupply)
                  {
                    num6 = 0;
                    int num13 = (double) this.game.EditObj.TempValue[this.game.Data.LocObj[locnr].Map].Value[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y] <= (double) this.game.Data.RuleVar[51] ? (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, locnr, true, false))) : (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, locnr, false, false)));
                    num7 = 1f;
                    if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[locnr].Map].Value[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y] > (double) this.game.Data.RuleVar[3])
                      num13 = 0;
                    else if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[locnr].Map].Value[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y] > (double) this.game.Data.RuleVar[53])
                      num13 = (int) Math.Round((double) num13 * 0.25);
                    else if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[locnr].Map].Value[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y] > (double) this.game.Data.RuleVar[52])
                      num13 = (int) Math.Round((double) num13 * 0.5);
                    else if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[locnr].Map].Value[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y] > (double) this.game.Data.RuleVar[51])
                      num13 = (int) Math.Round((double) num13 * 0.75);
                    if (num13 > 0)
                      num13 *= this.game.Data.ItemTypeObj[this.game.Data.LocObj[locnr].Production[prodslot]].Multiplier;
                    int[] supplyin1 = this.supplyin1;
                    int[] numArray7 = supplyin1;
                    int index12 = index6;
                    int index13 = index12;
                    int num14 = supplyin1[index12] + num13;
                    numArray7[index13] = num14;
                  }
                  ++prodslot;
                }
                while (prodslot <= 3);
              }
            }
            int hq = this.game.Data.UnitObj[index6].HQ;
            if (hq > -1)
            {
              if (this.game.Data.UnitObj[hq].X > -1)
              {
                int num15 = this.supplyout1[index6] + this.supplyneed4[index6] - this.supplyin1[index6];
                int num16 = this.game.Data.UnitObj[index6].Supply - this.game.Data.UnitObj[index6].Reserve;
                if (0 > num16)
                  num16 = 0;
                int num17 = num15 - num16;
                this.supplyin2[index6] = num16;
                if (0 > num17)
                  num17 = 0;
                int[] supplyout1 = this.supplyout1;
                int[] numArray8 = supplyout1;
                int index14 = hq;
                int index15 = index14;
                int num18 = supplyout1[index14] + num17;
                numArray8[index15] = num18;
                if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq].Map].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] > (double) this.game.Data.RuleVar[3])
                  num17 = 0;
                else if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq].Map].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] > (double) this.game.Data.RuleVar[53])
                  num17 = (int) Math.Round((double) num17 * 0.25);
                else if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq].Map].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] > (double) this.game.Data.RuleVar[52])
                  num17 = (int) Math.Round((double) num17 * 0.5);
                else if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq].Map].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] > (double) this.game.Data.RuleVar[51])
                  num17 = (int) Math.Round((double) num17 * 0.75);
                int[] supplyout2 = this.supplyout2;
                int[] numArray9 = supplyout2;
                int index16 = hq;
                int index17 = index16;
                int num19 = supplyout2[index16] + num17;
                numArray9[index17] = num19;
                this.supplyin3[index6] = num17;
              }
              else
              {
                int num20 = this.game.Data.UnitObj[index6].Supply - this.game.Data.UnitObj[index6].Reserve;
                if (0 > num20)
                  num20 = 0;
                this.supplyin2[index6] = num20;
              }
            }
            else
            {
              int num21 = this.game.Data.UnitObj[index6].Supply - this.game.Data.UnitObj[index6].Reserve;
              if (0 > num21)
                num21 = 0;
              this.supplyin2[index6] = num21;
            }
          }
        }
      }
      int num22 = num3;
      for (int index18 = 0; index18 <= num22; ++index18)
      {
        int unitCounter5 = this.game.Data.UnitCounter;
        for (int index19 = 0; index19 <= unitCounter5; ++index19)
        {
          if (numArray1[index19] == index18 && this.game.Data.UnitObj[index19].X > -1 & this.game.Data.UnitObj[index19].PreDef == -1 & this.game.Data.UnitObj[index19].X > -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[index19].Regime].UberRegime == this.game.Data.Turn | this.game.Data.RegimeObj[this.game.Data.UnitObj[index19].Regime].UberRegime > -1 & this.game.Data.RegimeObj[this.game.Data.UnitObj[index19].Regime].UberRegime == this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime | this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == this.game.Data.UnitObj[index19].Regime | this.game.Data.Turn == this.game.Data.UnitObj[index19].Regime && this.game.Data.UnitObj[index19].IsHQ)
          {
            int num23 = this.supplyneed4[index19];
            int unitCounter6 = this.game.Data.UnitCounter;
            for (int index20 = 0; index20 <= unitCounter6; ++index20)
            {
              if (this.game.Data.UnitObj[index20].HQ == index19 & this.game.Data.UnitObj[index20].PreDef == -1 & this.game.Data.UnitObj[index20].X > -1)
              {
                if (this.game.Data.UnitObj[index20].IsHQ)
                  num23 += this.supplyin3[index20];
                else
                  num23 += this.supplyneed4[index20];
              }
            }
            float num24 = num23 > 0 ? (float) (this.supplyin1[index19] + this.supplyin2[index19] + this.supplyin4[index19]) / (float) num23 : 0.0f;
            this.supplyout3[index19] = num23 <= this.supplyin1[index19] + this.supplyin2[index19] + this.supplyin4[index19] ? num23 - this.supplyneed4[index19] : (int) Math.Round((double) ((float) (this.supplyin1[index19] + this.supplyin2[index19] + this.supplyin4[index19]) - (float) this.supplyneed4[index19] * num24));
            if ((double) num24 > 1.0)
              num24 = 1f;
            int unitCounter7 = this.game.Data.UnitCounter;
            for (int index21 = 0; index21 <= unitCounter7; ++index21)
            {
              if (this.game.Data.UnitObj[index21].HQ == index19 & this.game.Data.UnitObj[index21].PreDef == -1 & this.game.Data.UnitObj[index21].X > -1)
                this.supplyin4[index21] = !this.game.Data.UnitObj[index21].IsHQ ? (int) Math.Round((double) (num24 * (float) this.supplyneed4[index21])) : (int) Math.Round((double) (num24 * (float) this.supplyin3[index21]));
            }
          }
        }
      }
      this.supplycalcdone = true;
    }
  }
}
