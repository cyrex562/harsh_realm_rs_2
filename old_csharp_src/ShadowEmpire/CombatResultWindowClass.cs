// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatResultWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class CombatResultWindowClass : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private int b1textid;
    private int b2textid;
    private int txt1id;
    private int txt2id;
    private int txt3id;
    private int txt4id;
    private int txt5id;
    private int txt6id;
    private int txt7id;
    private int txt8id;
    private int CombatListId;
    private ListClass CombatListObj;
    private int ResolveId;
    private int CombatListDId;
    private ListClass CombatListDObj;
    private int detailnr;
    private int detailnr2;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int DetailId;
    private int showdetail;
    private DateTime lasttime;
    private int[] modid;
    private string[] LogTxt;
    private int LogCounter;
    private int[,] UnitA;
    private int[,] UnitL;
    private Bitmap[,] UnitBitMap;
    private int UnitC;
    private int[] StartRdn;
    private int[] StartEntr;
    private int[] StartMor;
    private int[] StartXp;
    private bool ForwardKey;

    public CombatResultWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.modid = new int[61];
      this.LogTxt = new string[1];
      this.UnitA = new int[2, 200];
      this.UnitL = new int[2, 200];
      this.UnitBitMap = new Bitmap[2, 200];
      this.StartRdn = new int[2];
      this.StartEntr = new int[2];
      this.StartMor = new int[2];
      this.StartXp = new int[2];
      this.showdetail = 0;
      this.dostuff();
      this.lasttime = DateAndTime.Now;
      if (!this.game.EditObj.CombatSim)
        return;
      this.DoCombatSim();
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      new CombatAnalysis(this.game).analyse(false, true);
      if (this.CombatListId > 0)
        this.RemoveSubPart(this.CombatListId);
      if (this.showdetail == 0 & this.ResolveId > 0)
      {
        this.RemoveSubPart(this.ResolveId);
        this.ResolveId = 0;
      }
      if (this.CombatListDId > 0)
        this.RemoveSubPart(this.CombatListDId);
      if (this.b1textid > 0)
        this.RemoveSubPart(this.b1textid);
      if (this.b2textid > 0)
        this.RemoveSubPart(this.b2textid);
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
      if (this.DetailId > 0)
        this.RemoveSubPart(this.DetailId);
      if (this.txt1id > 0)
        this.RemoveSubPart(this.txt1id);
      if (this.txt2id > 0)
        this.RemoveSubPart(this.txt2id);
      if (this.txt3id > 0)
        this.RemoveSubPart(this.txt3id);
      if (this.txt4id > 0)
        this.RemoveSubPart(this.txt4id);
      if (this.txt5id > 0)
        this.RemoveSubPart(this.txt5id);
      if (this.txt6id > 0)
        this.RemoveSubPart(this.txt6id);
      if (this.txt7id > 0)
        this.RemoveSubPart(this.txt7id);
      if (this.txt8id > 0)
        this.RemoveSubPart(this.txt8id);
      int index1 = 0;
      do
      {
        if (this.modid[index1] > 0)
          this.RemoveSubPart(this.modid[index1]);
        ++index1;
      }
      while (index1 <= 60);
      int index2 = 0;
      do
      {
        this.UnitA[0, index2] = -1;
        this.UnitA[1, index2] = -1;
        ++index2;
      }
      while (index2 <= 199);
      this.UnitC = -1;
      int num1 = 1;
      int index3 = -1;
      int index4 = -1;
      while (num1 == 1)
      {
        num1 = 0;
        int icounter = this.game.TempCombat.ICounter;
        for (int index5 = 0; index5 <= icounter; ++index5)
        {
          if (this.game.TempCombat.IList[index5].IAttacker == 1)
          {
            int num2 = 0;
            int num3 = index3;
            for (int index6 = 0; index6 <= num3; ++index6)
            {
              if (this.UnitA[1, index6] == this.game.TempCombat.IList[index5].IUnr)
              {
                num2 = 1;
                break;
              }
            }
            if (num2 == 0)
            {
              ++index3;
              this.UnitA[1, index3] = this.game.TempCombat.IList[index5].IUnr;
              this.UnitBitMap[1, index3] = (Bitmap) this.game.CustomBitmapObj.DrawUnit(this.game.TempCombat.IList[index5].IUnr).Clone();
              this.UnitL[1, index3] = this.game.TempCombat.IList[index5].IUlistNr;
              if (index3 > this.UnitC)
                this.UnitC = index3;
            }
          }
        }
      }
      int num4 = 1;
      int index7 = -1;
      while (num4 == 1)
      {
        num4 = 0;
        int icounter = this.game.TempCombat.ICounter;
        for (int index8 = 0; index8 <= icounter; ++index8)
        {
          if (this.game.TempCombat.IList[index8].IAttacker == 0)
          {
            int num5 = 0;
            int num6 = index7;
            for (int index9 = 0; index9 <= num6; ++index9)
            {
              if (this.UnitA[0, index9] == this.game.TempCombat.IList[index8].IUnr)
              {
                num5 = 1;
                break;
              }
            }
            if (num5 == 0)
            {
              ++index7;
              ++index4;
              this.UnitA[0, index7] = this.game.TempCombat.IList[index8].IUnr;
              this.UnitBitMap[0, index7] = (Bitmap) this.game.CustomBitmapObj.DrawUnit(this.game.TempCombat.IList[index8].IUnr).Clone();
              this.UnitL[0, index7] = this.game.TempCombat.IList[index8].IUlistNr;
              if (index7 > this.UnitC)
                this.UnitC = index7;
            }
          }
        }
      }
      int unitCounter = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].UnitCounter;
      for (int index10 = 0; index10 <= unitCounter; ++index10)
      {
        int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].UnitList[index10];
        int num7 = 0;
        int num8 = index7;
        for (int index11 = 0; index11 <= num8; ++index11)
        {
          if (this.UnitA[0, index11] == unit)
          {
            num7 = 1;
            break;
          }
        }
        if (num7 == 0 && this.game.Data.UnitObj[unit].Regime == this.game.TempCombat.DefenderRegime)
        {
          ++index4;
          this.UnitA[0, index4] = unit;
          this.UnitBitMap[0, index4] = (Bitmap) this.game.CustomBitmapObj.DrawUnit(unit).Clone();
          this.UnitL[0, index4] = -1;
          if (index4 > this.UnitC)
            this.UnitC = index4;
        }
      }
      this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND2MARC);
      Graphics Expression1 = Graphics.FromImage((Image) this.OwnBitmap);
      string tText;
      SubPartClass tsubpart;
      if (!this.game.EditObj.CombatSim)
      {
        int[,] numArray1 = new int[this.game.Data.SFTypeCounter + 1, 2];
        int[,] numArray2 = new int[this.game.Data.SFTypeCounter + 1, 2];
        int[,] numArray3 = new int[this.game.Data.SFTypeCounter + 1, 2];
        int[] numArray4 = new int[2];
        int[] numArray5 = new int[2];
        int[] numArray6 = new int[2];
        int[] numArray7 = new int[2];
        int[] numArray8 = new int[2];
        int[] numArray9 = new int[2];
        int[] numArray10 = new int[2];
        int[] numArray11 = new int[2];
        int num9 = 0;
        int num10 = 0;
        numArray4[0] = 0;
        numArray4[1] = 0;
        numArray5[0] = 0;
        numArray5[1] = 0;
        numArray6[0] = 0;
        numArray6[1] = 0;
        numArray7[0] = 0;
        numArray7[1] = 0;
        numArray8[0] = 0;
        numArray8[1] = 0;
        numArray9[0] = 0;
        numArray9[1] = 0;
        numArray10[0] = 0;
        numArray10[1] = 0;
        numArray11[0] = 0;
        numArray11[1] = 0;
        int icounter1 = this.game.TempCombat.ICounter;
        int index12;
        for (int index13 = 0; index13 <= icounter1; ++index13)
        {
          int iattacker = this.game.TempCombat.IList[index13].IAttacker;
          index12 = this.game.TempCombat.IList[index13].ISFType;
          if (this.game.TempCombat.IList[index13].IKilled > 0)
          {
            int[,] numArray12 = numArray1;
            int[,] numArray13 = numArray12;
            int index14 = index12;
            int index15 = index14;
            int index16 = iattacker;
            int index17 = index16;
            int num11 = numArray12[index14, index16] + 1;
            numArray13[index15, index17] = num11;
            int[] numArray14 = numArray8;
            int[] numArray15 = numArray14;
            int index18 = iattacker;
            int index19 = index18;
            int num12 = numArray14[index18] + this.game.Data.SFTypeObj[index12].PowerPts;
            numArray15[index19] = num12;
          }
          else if (this.game.TempCombat.IList[index13].IRetreat > 0)
          {
            int[,] numArray16 = numArray2;
            int[,] numArray17 = numArray16;
            int index20 = index12;
            int index21 = index20;
            int index22 = iattacker;
            int index23 = index22;
            int num13 = numArray16[index20, index22] + 1;
            numArray17[index21, index23] = num13;
            int[] numArray18 = numArray9;
            int[] numArray19 = numArray18;
            int index24 = iattacker;
            int index25 = index24;
            int num14 = numArray18[index24] + this.game.Data.SFTypeObj[index12].PowerPts;
            numArray19[index25] = num14;
          }
          else
          {
            int[,] numArray20 = numArray3;
            int[,] numArray21 = numArray20;
            int index26 = index12;
            int index27 = index26;
            int index28 = iattacker;
            int index29 = index28;
            int num15 = numArray20[index26, index28] + 1;
            numArray21[index27, index29] = num15;
            int[] numArray22 = numArray10;
            int[] numArray23 = numArray22;
            int index30 = iattacker;
            int index31 = index30;
            int num16 = numArray22[index30] + this.game.Data.SFTypeObj[index12].PowerPts;
            numArray23[index31] = num16;
          }
          if (this.game.TempCombat.IList[index13].IKilled <= 0)
          {
            if (this.game.TempCombat.CombatRound == 0)
            {
              int[] numArray24 = numArray11;
              int[] numArray25 = numArray24;
              int index32 = iattacker;
              int index33 = index32;
              int num17 = numArray24[index32] + this.game.Data.SFTypeObj[index12].PowerPts;
              numArray25[index33] = num17;
              int[] startRdn = this.StartRdn;
              int[] numArray26 = startRdn;
              int index34 = iattacker;
              int index35 = index34;
              int num18 = startRdn[index34] + this.game.TempCombat.IList[index13].IRdn;
              numArray26[index35] = num18;
              int[] startXp = this.StartXp;
              int[] numArray27 = startXp;
              int index36 = iattacker;
              int index37 = index36;
              int num19 = startXp[index36] + this.game.TempCombat.IList[index13].IXp;
              numArray27[index37] = num19;
              int[] startMor = this.StartMor;
              int[] numArray28 = startMor;
              int index38 = iattacker;
              int index39 = index38;
              int num20 = startMor[index38] + this.game.TempCombat.IList[index13].IMor;
              numArray28[index39] = num20;
              int[] startEntr = this.StartEntr;
              int[] numArray29 = startEntr;
              int index40 = iattacker;
              int index41 = index40;
              int num21 = startEntr[index40] + this.game.TempCombat.IList[index13].IEntrench;
              numArray29[index41] = num21;
            }
            else
            {
              int[] numArray30 = numArray4;
              int[] numArray31 = numArray30;
              int index42 = iattacker;
              int index43 = index42;
              int num22 = numArray30[index42] + this.game.TempCombat.IList[index13].IRdn;
              numArray31[index43] = num22;
              int[] numArray32 = numArray5;
              int[] numArray33 = numArray32;
              int index44 = iattacker;
              int index45 = index44;
              int num23 = numArray32[index44] + this.game.TempCombat.IList[index13].IXp;
              numArray33[index45] = num23;
              int[] numArray34 = numArray6;
              int[] numArray35 = numArray34;
              int index46 = iattacker;
              int index47 = index46;
              int num24 = numArray34[index46] + this.game.TempCombat.IList[index13].IMor;
              numArray35[index47] = num24;
              int[] numArray36 = numArray7;
              int[] numArray37 = numArray36;
              int index48 = iattacker;
              int index49 = index48;
              int num25 = numArray36[index48] + this.game.TempCombat.IList[index13].IEntrench;
              numArray37[index49] = num25;
            }
            if (iattacker == 1)
              ++num9;
            else
              ++num10;
          }
        }
        if (num9 < 1)
          num9 = 1;
        if (num10 < 1)
          num10 = 1;
        if (this.game.TempCombat.CombatRound == 0)
        {
          this.StartRdn[0] = (int) Math.Round(Conversion.Int((double) this.StartRdn[0] / (double) num10));
          this.StartXp[0] = (int) Math.Round(Conversion.Int((double) this.StartXp[0] / (double) num10));
          this.StartMor[0] = (int) Math.Round(Conversion.Int((double) this.StartMor[0] / (double) num10));
          this.StartEntr[0] = (int) Math.Round(Conversion.Int((double) this.StartEntr[0] / (double) num10));
          this.StartRdn[1] = (int) Math.Round(Conversion.Int((double) this.StartRdn[1] / (double) num9));
          this.StartXp[1] = (int) Math.Round(Conversion.Int((double) this.StartXp[1] / (double) num9));
          this.StartMor[1] = (int) Math.Round(Conversion.Int((double) this.StartMor[1] / (double) num9));
          this.StartEntr[1] = (int) Math.Round(Conversion.Int((double) this.StartEntr[1] / (double) num9));
          int index50 = 0;
          do
          {
            this.game.EditObj.StartRdn[index50] = this.StartRdn[index50];
            this.game.EditObj.StartXp[index50] = this.StartXp[index50];
            this.game.EditObj.StartMor[index50] = this.StartMor[index50];
            this.game.EditObj.StartEntr[index50] = this.StartEntr[index50];
            ++index50;
          }
          while (index50 <= 1);
        }
        else
        {
          numArray4[0] = (int) Math.Round(Conversion.Int((double) numArray4[0] / (double) num10));
          numArray5[0] = (int) Math.Round(Conversion.Int((double) numArray5[0] / (double) num10));
          numArray6[0] = (int) Math.Round(Conversion.Int((double) numArray6[0] / (double) num10));
          numArray7[0] = (int) Math.Round(Conversion.Int((double) numArray7[0] / (double) num10));
          numArray4[1] = (int) Math.Round(Conversion.Int((double) numArray4[1] / (double) num9));
          numArray5[1] = (int) Math.Round(Conversion.Int((double) numArray5[1] / (double) num9));
          numArray6[1] = (int) Math.Round(Conversion.Int((double) numArray6[1] / (double) num9));
          numArray7[1] = (int) Math.Round(Conversion.Int((double) numArray7[1] / (double) num9));
          int index51 = 0;
          do
          {
            this.StartRdn[index51] = this.game.EditObj.StartRdn[index51];
            this.StartXp[index51] = this.game.EditObj.StartXp[index51];
            this.StartMor[index51] = this.game.EditObj.StartMor[index51];
            this.StartEntr[index51] = this.game.EditObj.StartEntr[index51];
            ++index51;
          }
          while (index51 <= 1);
        }
        if (this.showdetail == 0)
        {
          int num26 = 185;
          Bitmap bitmap;
          if (this.game.TempCombat.DefenderRegime > -1)
          {
            ref Graphics local1 = ref Expression1;
            bitmap = BitmapStore.GetBitmap(this.game.COMBATGRADIENT);
            ref Bitmap local2 = ref bitmap;
            int y = num26;
            double r = (double) this.game.Data.RegimeObj[this.game.TempCombat.DefenderRegime].Red / (double) byte.MaxValue - 1.0;
            double g = (double) this.game.Data.RegimeObj[this.game.TempCombat.DefenderRegime].Green / (double) byte.MaxValue - 1.0;
            double b = (double) this.game.Data.RegimeObj[this.game.TempCombat.DefenderRegime].Blue / (double) byte.MaxValue - 1.0;
            DrawMod.Draw(ref local1, ref local2, 150, y, (float) r, (float) g, (float) b, 1f);
          }
          else
          {
            ref Graphics local3 = ref Expression1;
            bitmap = BitmapStore.GetBitmap(this.game.COMBATGRADIENT);
            ref Bitmap local4 = ref bitmap;
            int y = num26;
            DrawMod.Draw(ref local3, ref local4, 150, y, -0.4980392f, -0.4980392f, -0.4980392f, 1f);
          }
          int num27 = 495;
          ref Graphics local5 = ref Expression1;
          bitmap = BitmapStore.GetBitmap(this.game.COMBATGRADIENT);
          ref Bitmap local6 = ref bitmap;
          int y1 = num27;
          double r1 = (double) ((float) this.game.Data.RegimeObj[this.game.TempCombat.AttackerRegime].Red / (float) byte.MaxValue);
          double g1 = (double) ((float) this.game.Data.RegimeObj[this.game.TempCombat.AttackerRegime].Green / (float) byte.MaxValue);
          double b1 = (double) ((float) this.game.Data.RegimeObj[this.game.TempCombat.AttackerRegime].Blue / (float) byte.MaxValue);
          DrawMod.Draw(ref local5, ref local6, 150, y1, (float) r1, (float) g1, (float) b1, 1f);
          DrawMod.DrawBlock(ref Expression1, 150, 110, 840, 310, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
          DrawMod.DrawBlock(ref Expression1, 150, 420, 840, 310, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
          int unitC1 = this.UnitC;
          for (int index52 = 0; index52 <= unitC1; ++index52)
          {
            int num28 = (int) Math.Round(640.0 / (double) (this.UnitC + 1));
            int num29 = num28 * (index52 + 1);
            int num30 = num28 * index52;
            int Length = (int) Math.Round(100.0 / (double) (this.UnitC + 1));
            if (index52 > -1)
            {
              num29 = (int) Math.Round((double) num29 + 100.0 / (double) (this.UnitC + 1) * (double) (index52 + 1));
              num30 = (int) Math.Round((double) num30 + 100.0 / (double) (this.UnitC + 1) * (double) index52);
            }
            if (index52 < this.UnitC)
            {
              DrawMod.drawLine(ref Expression1, num29 + 150, 110, num29 + 150, 420, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
              DrawMod.drawLine(ref Expression1, num29 + 150, 420, num29 + 150, 730, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
            }
            if (this.UnitA[0, index52] > -1)
            {
              DrawMod.DrawSimple(ref Expression1, ref this.UnitBitMap.Address(0, index52), 150 + num30 + 5, 120);
              DrawMod.DrawText(ref Expression1, Strings.Left(this.game.Data.UnitObj[this.UnitA[0, index52]].Name, Length), this.game.VicFont4, 190 + num30 + 5, 120);
              if (this.UnitL[0, index52] != -1)
              {
                if (this.game.TempCombat.UList[this.UnitL[0, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[0, index52]].URetreatMode == 1)
                  DrawMod.DrawText(ref Expression1, "RETREAT", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[0, index52]].URetreatMode == 2)
                  DrawMod.DrawText(ref Expression1, "END AIR", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[0, index52]].URetreatMode == 3)
                  DrawMod.DrawText(ref Expression1, "OUT OF AP", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[0, index52]].URetreatMode == 4)
                  DrawMod.DrawText(ref Expression1, "END SURPRISE", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].UShatter)
                  DrawMod.DrawText(ref Expression1, "xxxxSHATTERED", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].UBreaks & this.game.TempCombat.UList[this.UnitL[0, index52]].URetreatMode == 5)
                {
                  DrawMod.DrawText(ref Expression1, "PANICKED", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                  DrawMod.DrawText(ref Expression1, "+BROKEN", this.game.VicFont3, 150 + num30 + 5 + 40, 155);
                }
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].UBreaks)
                  DrawMod.DrawText(ref Expression1, "BROKEN", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
                else if (this.game.TempCombat.UList[this.UnitL[0, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[0, index52]].URetreatMode == 5)
                  DrawMod.DrawText(ref Expression1, "PANICKED", this.game.VicFont3, 150 + num30 + 5 + 40, 135);
              }
            }
            if (this.UnitA[1, index52] > -1)
            {
              DrawMod.DrawSimple(ref Expression1, ref this.UnitBitMap.Address(1, index52), 150 + num30 + 5, 430);
              DrawMod.DrawText(ref Expression1, Strings.Left(this.game.Data.UnitObj[this.UnitA[1, index52]].Name, Length), this.game.VicFont4, 190 + num30 + 5, 430);
              if (this.UnitL[1, index52] != -1)
              {
                if (this.game.TempCombat.UList[this.UnitL[1, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[1, index52]].URetreatMode == 1)
                  DrawMod.DrawText(ref Expression1, "RETREAT", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[1, index52]].URetreatMode == 2)
                  DrawMod.DrawText(ref Expression1, "END AIR", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[1, index52]].URetreatMode == 3)
                  DrawMod.DrawText(ref Expression1, "OUT OF AP", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[1, index52]].URetreatMode == 4)
                  DrawMod.DrawText(ref Expression1, "END SURPRISE", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].UShatter)
                  DrawMod.DrawText(ref Expression1, "xxxxxSHATTERED", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].UBreaks & this.game.TempCombat.UList[this.UnitL[1, index52]].URetreatMode == 5)
                {
                  DrawMod.DrawText(ref Expression1, "PANICKED", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                  DrawMod.DrawText(ref Expression1, "+BROKEN", this.game.VicFont3, 150 + num30 + 5 + 40, 475);
                }
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].UBreaks)
                  DrawMod.DrawText(ref Expression1, "BROKEN", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
                else if (this.game.TempCombat.UList[this.UnitL[1, index52]].URetreat > 0 & this.game.TempCombat.UList[this.UnitL[1, index52]].URetreatMode == 5)
                  DrawMod.DrawText(ref Expression1, "PANICKED", this.game.VicFont3, 150 + num30 + 5 + 40, 455);
              }
            }
          }
          DrawMod.drawLine(ref Expression1, 150, 110, 990, 110, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          DrawMod.drawLine(ref Expression1, 150, 180, 990, 180, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) Math.Round((double) this.game.VicColor3.A / 2.0));
          DrawMod.drawLine(ref Expression1, 150, 260, 990, 260, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) Math.Round((double) this.game.VicColor3.A / 2.0));
          DrawMod.drawLine(ref Expression1, 150, 340, 990, 340, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) Math.Round((double) this.game.VicColor3.A / 2.0));
          DrawMod.drawLine(ref Expression1, 150, 420, 990, 420, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          DrawMod.drawLine(ref Expression1, 150, 490, 990, 490, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) Math.Round((double) this.game.VicColor3.A / 2.0));
          DrawMod.drawLine(ref Expression1, 150, 570, 990, 570, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) Math.Round((double) this.game.VicColor3.A / 2.0));
          DrawMod.drawLine(ref Expression1, 150, 650, 990, 650, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) Math.Round((double) this.game.VicColor3.A / 2.0));
          DrawMod.drawLine(ref Expression1, 150, 730, 990, 730, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          DrawMod.drawLine(ref Expression1, 990, 110, 990, 350, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          DrawMod.drawLine(ref Expression1, 990, 350, 990, 730, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          DrawMod.drawLine(ref Expression1, 150, 110, 150, 350, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          DrawMod.drawLine(ref Expression1, 150, 350, 150, 730, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          int index53 = 0;
          do
          {
            int unitC2 = this.UnitC;
            for (int index54 = 0; index54 <= unitC2; ++index54)
            {
              int num31 = 0;
              do
              {
                int num32 = 70 + index53 * 240 + 50 + num31 * 80;
                if (index53 == 1)
                  num32 += 70;
                int num33 = -1;
                int num34 = 0;
                int sfTypeCounter1 = this.game.Data.SFTypeCounter;
                for (int index55 = 0; index55 <= sfTypeCounter1; ++index55)
                {
                  int icounter2 = this.game.TempCombat.ICounter;
                  for (int index56 = 0; index56 <= icounter2; ++index56)
                  {
                    if (this.game.TempCombat.IList[index56].ISFType == index55 & this.game.TempCombat.IList[index56].IUnr == this.UnitA[index53, index54] && this.game.TempCombat.IList[index56].IAttacker == index53)
                    {
                      switch (num31)
                      {
                        case 0:
                          if (this.game.TempCombat.IList[index56].IRetreated == 0 & this.game.TempCombat.IList[index56].IKilled == 0)
                          {
                            ++num34;
                            continue;
                          }
                          continue;
                        case 1:
                          if (this.game.TempCombat.IList[index56].IKilled > 0)
                          {
                            ++num34;
                            continue;
                          }
                          continue;
                        case 2:
                          if (this.game.TempCombat.IList[index56].IRetreated > 0 & this.game.TempCombat.IList[index56].IKilled == 0)
                          {
                            ++num34;
                            continue;
                          }
                          continue;
                        default:
                          continue;
                      }
                    }
                  }
                }
                int sfTypeCounter2 = this.game.Data.SFTypeCounter;
                for (int index57 = 0; index57 <= sfTypeCounter2; ++index57)
                {
                  int icounter3 = this.game.TempCombat.ICounter;
                  for (int index58 = 0; index58 <= icounter3; ++index58)
                  {
                    int num35 = 0;
                    if (this.game.TempCombat.IList[index58].ISFType == index57 && this.game.TempCombat.IList[index58].IAttacker == index53 & this.game.TempCombat.IList[index58].IUnr == this.UnitA[index53, index54])
                    {
                      switch (num31)
                      {
                        case 0:
                          if (this.game.TempCombat.IList[index58].IRetreated == 0 & this.game.TempCombat.IList[index58].IKilled == 0)
                          {
                            num35 = 1;
                            break;
                          }
                          break;
                        case 1:
                          if (this.game.TempCombat.IList[index58].IKilled > 0)
                          {
                            num35 = 1;
                            break;
                          }
                          break;
                        case 2:
                          if (this.game.TempCombat.IList[index58].IRetreated > 0 & this.game.TempCombat.IList[index58].IKilled == 0)
                          {
                            num35 = 1;
                            break;
                          }
                          break;
                      }
                      if (num35 > 0)
                      {
                        int symbolSpriteId = this.game.Data.SFTypeObj[index57].SymbolSpriteID;
                        int index59 = -1;
                        if (index53 == 0)
                          index59 = this.game.TempCombat.DefenderRegime;
                        if (index53 == 1)
                          index59 = this.game.TempCombat.AttackerRegime;
                        if (index59 > -1)
                        {
                          if (this.game.Data.RegimeObj[index59].ExtraGraphicUse > -1)
                          {
                            int extraCounter = this.game.Data.SFTypeObj[index57].ExtraCounter;
                            for (int index60 = 0; index60 <= extraCounter; ++index60)
                            {
                              if (this.game.Data.SFTypeObj[index57].ExtraCode[index60] == this.game.Data.RegimeObj[index59].ExtraGraphicUse)
                                symbolSpriteId = this.game.Data.SFTypeObj[index57].ExtraSymbolSpriteID[index60];
                            }
                          }
                          else if (this.game.Data.PeopleObj[this.game.Data.SFObj[this.game.TempCombat.IList[index58].ISFNr].People].ExtraGraphicUse > -1)
                          {
                            int extraCounter = this.game.Data.SFTypeObj[index57].ExtraCounter;
                            for (int index61 = 0; index61 <= extraCounter; ++index61)
                            {
                              if (this.game.Data.SFTypeObj[index57].ExtraCode[index61] == this.game.Data.PeopleObj[this.game.Data.SFObj[this.game.TempCombat.IList[index58].ISFNr].People].ExtraGraphicUse)
                                symbolSpriteId = this.game.Data.SFTypeObj[index57].ExtraSymbolSpriteID[index61];
                            }
                          }
                        }
                        ++num33;
                        int num36 = (int) Math.Round(640.0 / (double) (this.UnitC + 1));
                        int num37 = (int) Math.Round(Conversion.Int((double) (num36 * 4) / (double) num34));
                        if (num37 > 25)
                          num37 = 25;
                        if (num37 < 1)
                          num37 = 1;
                        int num38 = num37 * num33;
                        int num39 = num36 % num37;
                        int num40 = num36 - num39;
                        int num41 = (num40 + num39) * index54;
                        if (index54 > 0)
                          num41 = (int) Math.Round((double) num41 + 100.0 / (double) (this.UnitC + 1) * (double) index54);
                        int num42;
                        int num43;
                        if (num38 <= num40)
                        {
                          num42 = 0;
                          num43 = 64;
                        }
                        else if (num38 <= 2 * num40 + num37)
                        {
                          num42 = 1 * num40 + num37;
                          num43 = 82;
                        }
                        else if (num38 <= 3 * num40 + num37)
                        {
                          num42 = 2 * num40 + 2 * num37;
                          num43 = 100;
                        }
                        else if (num38 <= 4 * num40 + num37)
                        {
                          num42 = 3 * num40 + 2 * num37;
                          num43 = 118;
                        }
                        int num44 = 0;
                        if (this.game.TempCombat.IList[index58].ICapitulate)
                          num44 = 1;
                        if (this.game.TempCombat.IList[index58].IBreakTrough > 0 & (num31 == 0 & index53 == 0 | num31 == 0 & index53 == 1))
                          num44 = 2;
                        switch (num44)
                        {
                          case 0:
                            ref Graphics local7 = ref Expression1;
                            bitmap = BitmapStore.GetBitmap(symbolSpriteId);
                            ref Bitmap local8 = ref bitmap;
                            int x1 = num41 + 150 + num37 * num33 - num42;
                            int y2 = num32 + num43;
                            DrawMod.DrawSimple(ref local7, ref local8, x1, y2);
                            break;
                          case 1:
                            ref Graphics local9 = ref Expression1;
                            bitmap = BitmapStore.GetBitmap(symbolSpriteId);
                            ref Bitmap local10 = ref bitmap;
                            int x2 = num41 + 150 + num37 * num33 - num42;
                            int y3 = num32 + num43;
                            DrawMod.DrawSimple(ref local9, ref local10, x2, y3);
                            ref Graphics local11 = ref Expression1;
                            bitmap = BitmapStore.GetBitmap(this.game.WHITEFLAG);
                            ref Bitmap local12 = ref bitmap;
                            int x3 = num41 + 157 + num37 * num33 - num42;
                            int y4 = num32 + num43;
                            DrawMod.DrawSimple(ref local11, ref local12, x3, y4);
                            break;
                          case 2:
                            ref Graphics local13 = ref Expression1;
                            bitmap = BitmapStore.GetBitmap(symbolSpriteId);
                            ref Bitmap local14 = ref bitmap;
                            int x4 = num41 + 150 + num37 * num33 - num42;
                            int y5 = num32 + num43;
                            DrawMod.Draw(ref local13, ref local14, x4, y5, 0.0f, 0.0f, -1f, 1f);
                            break;
                        }
                        int num45 = (int) Math.Round(Conversion.Int((double) this.game.TempCombat.IList[index58].IRdn / 10.0));
                        DrawMod.drawLine(ref Expression1, num41 + 150 + 8 + num37 * num33 - num42, num32 + num43, num41 + 150 + 8 + num37 * num33 - num42, num32 + num43 + 10, 0, 0, 0, (int) byte.MaxValue);
                        DrawMod.drawLine(ref Expression1, num41 + 150 + 8 + num37 * num33 - num42, num32 + num43 + 10 - num45, num41 + 150 + 8 + num37 * num33 - num42, num32 + num43 + 10, 0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
                      }
                    }
                  }
                }
                ++num31;
              }
              while (num31 <= 2);
            }
            ++index53;
          }
          while (index53 <= 1);
        }
        else
        {
          string str1 = "ATTACKER TOTALS\r\n";
          string Expression2 = "SUBFORMATIONTYPE";
          int Number1 = 35 - Strings.Len(Expression2);
          if (0 > Number1)
            Number1 = 0;
          string str2 = str1 + Expression2 + Strings.Space(Number1);
          string Expression3 = "INITIAL";
          int Number2 = 10 - Strings.Len(Expression3);
          if (0 > Number2)
            Number2 = 0;
          string str3 = str2 + Expression3 + Strings.Space(Number2);
          string Expression4 = "ATTACK";
          int Number3 = 9 - Strings.Len(Expression4);
          if (0 > Number3)
            Number3 = 0;
          string str4 = str3 + Expression4 + Strings.Space(Number3);
          string Expression5 = "DEAD";
          int Number4 = 7 - Strings.Len(Expression5);
          if (0 > Number4)
            Number4 = 0;
          string str5 = str4 + Expression5 + Strings.Space(Number4);
          string Expression6 = "RETREAT";
          int Number5 = 9 - Strings.Len(Expression6);
          if (0 > Number5)
            Number5 = 0;
          string str6 = str5 + Expression6 + Strings.Space(Number5);
          string Expression7 = "ALIVE";
          int Number6 = 6 - Strings.Len(Expression7);
          if (0 > Number6)
            Number6 = 0;
          string str7 = str6 + Expression7 + Strings.Space(Number6) + "\r\n";
          int sfTypeCounter3 = this.game.Data.SFTypeCounter;
          for (int index62 = 0; index62 <= sfTypeCounter3; ++index62)
          {
            index12 = 1;
            if (this.game.Data.SFTypeObj[index62].Ratio > 0)
              index12 = this.game.Data.SFTypeObj[index62].Ratio;
            if (numArray3[index62, 1] > 0 | numArray1[index62, 1] > 0 | numArray2[index62, 1] > 0)
            {
              string Expression8 = this.game.Data.SFTypeObj[index62].Name;
              if (Strings.Len(Expression8) > 29)
                Expression8 = Strings.Left(str7, 29);
              int Number7 = 35 - Strings.Len(Expression8);
              if (0 > Number7)
                Number7 = 0;
              string str8 = str7 + Expression8 + Strings.Space(Number7);
              string Expression9 = Strings.Trim(Conversion.Str((object) (index12 * (numArray3[index62, 1] + numArray1[index62, 1] + numArray2[index62, 1]))));
              int Number8 = 10 - Strings.Len(Expression9);
              if (0 > Number8)
                Number8 = 0;
              string str9 = str8 + Expression9 + Strings.Space(Number8);
              string Expression10 = Strings.Trim(Conversion.Str((object) (index12 * numArray3[index62, 1])));
              int Number9 = 9 - Strings.Len(Expression10);
              if (0 > Number9)
                Number9 = 0;
              string str10 = str9 + Expression10 + Strings.Space(Number9);
              string Expression11 = Strings.Trim(Conversion.Str((object) (index12 * numArray1[index62, 1])));
              int Number10 = 7 - Strings.Len(Expression11);
              if (0 > Number10)
                Number10 = 0;
              string str11 = str10 + Expression11 + Strings.Space(Number10);
              string Expression12 = Strings.Trim(Conversion.Str((object) (index12 * numArray2[index62, 1])));
              int Number11 = 9 - Strings.Len(Expression12);
              if (0 > Number11)
                Number11 = 0;
              string str12 = str11 + Expression12 + Strings.Space(Number11);
              string Expression13 = Strings.Trim(Conversion.Str((object) (index12 * (numArray2[index62, 1] + numArray3[index62, 1]))));
              int Number12 = 6 - Strings.Len(Expression13);
              if (0 > Number12)
                Number12 = 0;
              str7 = str12 + Expression13 + Strings.Space(Number12) + "\r\n";
            }
          }
          string Expression14 = "TOTAL POWERPOINTS";
          if (Strings.Len(Expression14) > 29)
            Expression14 = Strings.Left(str7, 29);
          int Number13 = 35 - Strings.Len(Expression14);
          if (0 > Number13)
            Number13 = 0;
          string str13 = str7 + Expression14 + Strings.Space(Number13);
          string Expression15 = Strings.Trim(Conversion.Str((object) (numArray10[1] + numArray8[1] + numArray9[1])));
          int Number14 = 10 - Strings.Len(Expression15);
          if (0 > Number14)
            Number14 = 0;
          string str14 = str13 + Expression15 + Strings.Space(Number14);
          string Expression16 = Strings.Trim(Conversion.Str((object) numArray10[1]));
          int Number15 = 9 - Strings.Len(Expression16);
          if (0 > Number15)
            Number15 = 0;
          string str15 = str14 + Expression16 + Strings.Space(Number15);
          string Expression17 = Strings.Trim(Conversion.Str((object) numArray8[1]));
          int Number16 = 7 - Strings.Len(Expression17);
          if (0 > Number16)
            Number16 = 0;
          string str16 = str15 + Expression17 + Strings.Space(Number16);
          string Expression18 = Strings.Trim(Conversion.Str((object) numArray9[1]));
          int Number17 = 9 - Strings.Len(Expression18);
          if (0 > Number17)
            Number17 = 0;
          string str17 = str16 + Expression18 + Strings.Space(Number17);
          string Expression19 = Strings.Trim(Conversion.Str((object) (numArray9[1] + numArray10[1])));
          int Number18 = 6 - Strings.Len(Expression19);
          if (0 > Number18)
            Number18 = 0;
          string str18 = str17 + Expression19 + Strings.Space(Number18) + "\r\n" + "\r\n" + "DEFENDERS TOTALS\r\n";
          string Expression20 = "SUBFORMATIONTYPE";
          int Number19 = 35 - Strings.Len(Expression20);
          if (0 > Number19)
            Number19 = 0;
          string str19 = str18 + Expression20 + Strings.Space(Number19);
          string Expression21 = "INITIAL";
          int Number20 = 10 - Strings.Len(Expression21);
          if (0 > Number20)
            Number20 = 0;
          string str20 = str19 + Expression21 + Strings.Space(Number20);
          string Expression22 = "ATTACK";
          int Number21 = 9 - Strings.Len(Expression22);
          if (0 > Number21)
            Number21 = 0;
          string str21 = str20 + Expression22 + Strings.Space(Number21);
          string Expression23 = "DEAD";
          int Number22 = 7 - Strings.Len(Expression23);
          if (0 > Number22)
            Number22 = 0;
          string str22 = str21 + Expression23 + Strings.Space(Number22);
          string Expression24 = "RETREAT";
          int Number23 = 9 - Strings.Len(Expression24);
          if (0 > Number23)
            Number23 = 0;
          string str23 = str22 + Expression24 + Strings.Space(Number23);
          string Expression25 = "ALIVE";
          int Number24 = 6 - Strings.Len(Expression25);
          if (0 > Number24)
            Number24 = 0;
          string str24 = str23 + Expression25 + Strings.Space(Number24) + "\r\n";
          int sfTypeCounter4 = this.game.Data.SFTypeCounter;
          for (int index63 = 0; index63 <= sfTypeCounter4; ++index63)
          {
            index12 = 1;
            if (this.game.Data.SFTypeObj[index63].Ratio > 0)
              index12 = this.game.Data.SFTypeObj[index63].Ratio;
            if (numArray3[index63, 0] > 0 | numArray1[index63, 0] > 0 | numArray2[index63, 0] > 0)
            {
              string Expression26 = this.game.Data.SFTypeObj[index63].Name;
              if (Strings.Len(Expression26) > 29)
                Expression26 = Strings.Left(str24, 29);
              int Number25 = 35 - Strings.Len(Expression26);
              if (0 > Number25)
                Number25 = 0;
              string str25 = str24 + Expression26 + Strings.Space(Number25);
              string Expression27 = Strings.Trim(Conversion.Str((object) (index12 * (numArray3[index63, 0] + numArray1[index63, 0] + numArray2[index63, 0]))));
              int Number26 = 10 - Strings.Len(Expression27);
              if (0 > Number26)
                Number26 = 0;
              string str26 = str25 + Expression27 + Strings.Space(Number26);
              string Expression28 = Strings.Trim(Conversion.Str((object) (index12 * numArray3[index63, 0])));
              int Number27 = 9 - Strings.Len(Expression28);
              if (0 > Number27)
                Number27 = 0;
              string str27 = str26 + Expression28 + Strings.Space(Number27);
              string Expression29 = Strings.Trim(Conversion.Str((object) (index12 * numArray1[index63, 0])));
              int Number28 = 7 - Strings.Len(Expression29);
              if (0 > Number28)
                Number28 = 0;
              string str28 = str27 + Expression29 + Strings.Space(Number28);
              string Expression30 = Strings.Trim(Conversion.Str((object) (index12 * numArray2[index63, 0])));
              int Number29 = 9 - Strings.Len(Expression30);
              if (0 > Number29)
                Number29 = 0;
              string str29 = str28 + Expression30 + Strings.Space(Number29);
              string Expression31 = Strings.Trim(Conversion.Str((object) (index12 * (numArray2[index63, 0] + numArray3[index63, 0]))));
              int Number30 = 6 - Strings.Len(Expression31);
              if (0 > Number30)
                Number30 = 0;
              str24 = str29 + Expression31 + Strings.Space(Number30) + "\r\n";
            }
          }
          string Expression32 = "TOTAL POWERPOINTS";
          if (Strings.Len(Expression32) > 29)
            Expression32 = Strings.Left(str24, 29);
          int Number31 = 35 - Strings.Len(Expression32);
          if (0 > Number31)
            Number31 = 0;
          string str30 = str24 + Expression32 + Strings.Space(Number31);
          string Expression33 = Strings.Trim(Conversion.Str((object) (index12 * (numArray10[0] + numArray8[0] + numArray9[0]))));
          int Number32 = 10 - Strings.Len(Expression33);
          if (0 > Number32)
            Number32 = 0;
          string str31 = str30 + Expression33 + Strings.Space(Number32);
          string Expression34 = Strings.Trim(Conversion.Str((object) (index12 * numArray10[0])));
          int Number33 = 9 - Strings.Len(Expression34);
          if (0 > Number33)
            Number33 = 0;
          string str32 = str31 + Expression34 + Strings.Space(Number33);
          string Expression35 = Strings.Trim(Conversion.Str((object) (index12 * numArray8[0])));
          int Number34 = 7 - Strings.Len(Expression35);
          if (0 > Number34)
            Number34 = 0;
          string str33 = str32 + Expression35 + Strings.Space(Number34);
          string Expression36 = Strings.Trim(Conversion.Str((object) (index12 * numArray9[0])));
          int Number35 = 9 - Strings.Len(Expression36);
          if (0 > Number35)
            Number35 = 0;
          string str34 = str33 + Expression36 + Strings.Space(Number35);
          string Expression37 = Strings.Trim(Conversion.Str((object) (index12 * (numArray9[0] + numArray10[0]))));
          int Number36 = 6 - Strings.Len(Expression37);
          if (0 > Number36)
            Number36 = 0;
          string str35 = str34 + Expression37 + Strings.Space(Number36) + "\r\n" + "\r\n" + "\r\n";
          string Expression38 = "ATTACKER";
          int Number37 = 10 - Strings.Len(Expression38);
          if (0 > Number37)
            Number37 = 0;
          string str36 = str35 + Strings.Space(20) + Expression38 + Strings.Space(Number37);
          string Expression39 = "DEFENDER";
          int num46 = 10 - Strings.Len(Expression39);
          if (0 > num46)
            num46 = 0;
          string str37 = str36 + Strings.Space(20) + Expression39 + Strings.Space(num46 + 50) + "\r\n";
          string Expression40 = "STAT";
          int Number38 = 20 - Strings.Len(Expression40);
          if (0 > Number38)
            Number38 = 0;
          string str38 = str37 + Expression40 + Strings.Space(Number38);
          string Expression41 = "INITIAL";
          int Number39 = 10 - Strings.Len(Expression41);
          if (0 > Number39)
            Number39 = 0;
          string str39 = str38 + Expression41 + Strings.Space(Number39);
          string Expression42 = "CURRENT";
          int Number40 = 20 - Strings.Len(Expression42);
          if (0 > Number40)
            Number40 = 0;
          string str40 = str39 + Expression42 + Strings.Space(Number40);
          string Expression43 = "INITIAL";
          int Number41 = 10 - Strings.Len(Expression43);
          if (0 > Number41)
            Number41 = 0;
          string str41 = str40 + Expression43 + Strings.Space(Number41);
          string Expression44 = "CURRENT";
          int Number42 = 10 - Strings.Len(Expression44);
          if (0 > Number42)
            Number42 = 0;
          string str42 = str41 + Expression44 + Strings.Space(Number42) + "\r\n";
          string Expression45 = "Readiness";
          if (Strings.Len(Expression45) > 29)
            Expression45 = Strings.Left(str42, 29);
          int Number43 = 20 - Strings.Len(Expression45);
          if (0 > Number43)
            Number43 = 0;
          string str43 = str42 + Expression45 + Strings.Space(Number43);
          string Expression46 = Strings.Trim(Conversion.Str((object) this.StartRdn[1]));
          int Number44 = 10 - Strings.Len(Expression46);
          if (0 > Number44)
            Number44 = 0;
          string str44 = str43 + Expression46 + Strings.Space(Number44);
          string Expression47 = Strings.Trim(Conversion.Str((object) numArray4[1]));
          int Number45 = 20 - Strings.Len(Expression47);
          if (0 > Number45)
            Number45 = 0;
          string str45 = str44 + Expression47 + Strings.Space(Number45);
          string Expression48 = Strings.Trim(Conversion.Str((object) this.StartRdn[0]));
          int Number46 = 10 - Strings.Len(Expression48);
          if (0 > Number46)
            Number46 = 0;
          string str46 = str45 + Expression48 + Strings.Space(Number46);
          string Expression49 = Strings.Trim(Conversion.Str((object) numArray4[0]));
          int Number47 = 10 - Strings.Len(Expression49);
          if (0 > Number47)
            Number47 = 0;
          string str47 = str46 + Expression49 + Strings.Space(Number47) + "\r\n";
          string Expression50 = "Experience";
          if (Strings.Len(Expression50) > 29)
            Expression50 = Strings.Left(str47, 29);
          int Number48 = 20 - Strings.Len(Expression50);
          if (0 > Number48)
            Number48 = 0;
          string str48 = str47 + Expression50 + Strings.Space(Number48);
          string Expression51 = Strings.Trim(Conversion.Str((object) this.StartXp[1]));
          int Number49 = 10 - Strings.Len(Expression51);
          if (0 > Number49)
            Number49 = 0;
          string str49 = str48 + Expression51 + Strings.Space(Number49);
          string Expression52 = Strings.Trim(Conversion.Str((object) numArray5[1]));
          int Number50 = 20 - Strings.Len(Expression52);
          if (0 > Number50)
            Number50 = 0;
          string str50 = str49 + Expression52 + Strings.Space(Number50);
          string Expression53 = Strings.Trim(Conversion.Str((object) this.StartXp[0]));
          int Number51 = 10 - Strings.Len(Expression53);
          if (0 > Number51)
            Number51 = 0;
          string str51 = str50 + Expression53 + Strings.Space(Number51);
          string Expression54 = Strings.Trim(Conversion.Str((object) numArray5[0]));
          int Number52 = 10 - Strings.Len(Expression54);
          if (0 > Number52)
            Number52 = 0;
          string str52 = str51 + Expression54 + Strings.Space(Number52) + "\r\n";
          string Expression55 = "Morale";
          if (Strings.Len(Expression55) > 29)
            Expression55 = Strings.Left(str52, 29);
          int Number53 = 20 - Strings.Len(Expression55);
          if (0 > Number53)
            Number53 = 0;
          string str53 = str52 + Expression55 + Strings.Space(Number53);
          string Expression56 = Strings.Trim(Conversion.Str((object) this.StartMor[1]));
          int Number54 = 10 - Strings.Len(Expression56);
          if (0 > Number54)
            Number54 = 0;
          string str54 = str53 + Expression56 + Strings.Space(Number54);
          string Expression57 = Strings.Trim(Conversion.Str((object) numArray6[1]));
          int Number55 = 20 - Strings.Len(Expression57);
          if (0 > Number55)
            Number55 = 0;
          string str55 = str54 + Expression57 + Strings.Space(Number55);
          string Expression58 = Strings.Trim(Conversion.Str((object) this.StartMor[0]));
          int Number56 = 10 - Strings.Len(Expression58);
          if (0 > Number56)
            Number56 = 0;
          string str56 = str55 + Expression58 + Strings.Space(Number56);
          string Expression59 = Strings.Trim(Conversion.Str((object) numArray6[0]));
          int Number57 = 10 - Strings.Len(Expression59);
          if (0 > Number57)
            Number57 = 0;
          string str57 = str56 + Expression59 + Strings.Space(Number57) + "\r\n";
          string Expression60 = "Entrenchment";
          if (Strings.Len(Expression60) > 29)
            Expression60 = Strings.Left(str57, 29);
          int Number58 = 20 - Strings.Len(Expression60);
          if (0 > Number58)
            Number58 = 0;
          string str58 = str57 + Expression60 + Strings.Space(Number58);
          string Expression61 = Strings.Trim(Conversion.Str((object) this.StartEntr[1]));
          int Number59 = 10 - Strings.Len(Expression61);
          if (0 > Number59)
            Number59 = 0;
          string str59 = str58 + Expression61 + Strings.Space(Number59);
          string Expression62 = Strings.Trim(Conversion.Str((object) numArray7[1]));
          int Number60 = 20 - Strings.Len(Expression62);
          if (0 > Number60)
            Number60 = 0;
          string str60 = str59 + Expression62 + Strings.Space(Number60);
          string Expression63 = Strings.Trim(Conversion.Str((object) this.StartEntr[0]));
          int Number61 = 10 - Strings.Len(Expression63);
          if (0 > Number61)
            Number61 = 0;
          string str61 = str60 + Expression63 + Strings.Space(Number61);
          string Expression64 = Strings.Trim(Conversion.Str((object) numArray7[0]));
          int Number62 = 10 - Strings.Len(Expression64);
          if (0 > Number62)
            Number62 = 0;
          tText = str61 + Expression64 + Strings.Space(Number62) + "\r\n" + "\r\n";
          DrawMod.DrawPaperSheet(ref Expression1, 65, 130, 890, 592);
          if (this.ResolveId == 0)
          {
            tsubpart = (SubPartClass) new PaperAreaClass(this.game, 850, 26, new Font("Courier New", 15f, FontStyle.Regular, GraphicsUnit.Pixel), "Description", false, tText, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: 85, bby: 150);
            this.ResolveId = this.AddSubPart(ref tsubpart, 85, 150, 850, 580, 0);
          }
        }
      }
      if (this.Info1Id > 0)
        this.RemoveSubPart(this.Info1Id);
      if (this.game.TempCombat.CombatRound > 0 | this.game.TempCombat.BattleEnded > 0)
      {
        if (this.game.TempCombat.CombatType == 11)
        {
          if (this.game.TempCombat.BattleEnded == 0)
            tText = "Surprise Combat  at round " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 1)
            tText = "VICTORY: Attacker won in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 2)
            tText = "Surprise Combat ended. " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 3)
            tText = "STANDOFF: at Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
        }
        else if (this.game.TempCombat.CombatType == 1 | this.game.TempCombat.CombatType == 2 | this.game.TempCombat.CombatType == 10 | this.game.TempCombat.CombatType == 9)
        {
          if (this.game.TempCombat.BattleEnded == 0)
            tText = "Battle at Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 1)
            tText = "VICTORY: Attacker won in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 2)
            tText = "ATTACK STALLED: in CombatRound " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 3)
            tText = "STANDOFF: in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
        }
        else if (this.game.TempCombat.CombatType == 3 | this.game.TempCombat.CombatType == 4)
        {
          if (this.game.TempCombat.BattleEnded == 0)
            tText = "Artillery Bombardment at Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 1)
            tText = "Defender has retreated in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 2)
            tText = "Artillery run out of AP in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 3)
            tText = "Defender has retreated in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
        }
        else if (this.game.TempCombat.CombatType == 5 | this.game.TempCombat.CombatType == 6 | this.game.TempCombat.CombatType == 13)
        {
          if (this.game.TempCombat.BattleEnded == 0)
            tText = "Air attack at Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 1)
            tText = "Defender has retreated in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 2)
            tText = "Air attack broken off in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 3)
            tText = "Defender has retreated in Combatround  " + Conversion.Str((object) this.game.TempCombat.CombatRound);
        }
        else if (this.game.TempCombat.CombatType == 14)
        {
          if (this.game.TempCombat.BattleEnded == 0)
            tText = "Air Supply at Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 1)
            tText = "Air Supply retreated in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 2)
            tText = "Air Supply broken off in Combatround " + Conversion.Str((object) this.game.TempCombat.CombatRound);
          else if (this.game.TempCombat.BattleEnded == 3)
            tText = "Defender has retreated in Combatround  " + Conversion.Str((object) this.game.TempCombat.CombatRound);
        }
      }
      else
        tText = "Battle is about to commence!";
      if (this.game.EditObj.CombatSim)
        tText = "Combat sim. Check log file for result";
      ref Graphics local15 = ref Expression1;
      Rectangle rectangle1 = new Rectangle(150, 18, 500, 14);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(150, 32, 500, 23);
      Rectangle rect2_1 = rectangle2;
      string txt2_1 = tText;
      DrawMod.MakeFullBoxVic2(ref local15, rect1_1, "COMBAT STATUS", rect2_1, txt2_1);
      ref Graphics local16 = ref Expression1;
      rectangle2 = new Rectangle(150, 58, 700, 14);
      Rectangle rect1_2 = rectangle2;
      rectangle1 = new Rectangle(150, 72, 700, 23);
      Rectangle rect2_2 = rectangle1;
      DrawMod.MakeFullBoxVic2(ref local16, rect1_2, "COMBAT EFFECTS", rect2_2, "");
      if (this.showdetail == 0 & !this.game.EditObj.CombatSim)
      {
        SizeF sizeF1 = new SizeF();
        Font vicFont1 = this.game.VicFont1;
        string str62 = "DEFENDERS";
        SizeF sizeF2 = Expression1.MeasureString(str62, vicFont1);
        DrawMod.DrawTextVic2(ref Expression1, str62, vicFont1, (int) Math.Round((double) (140f - sizeF2.Width)), 180, this.game.VicColor2, this.game.VicColor1Shade);
        string str63 = "CASUALTIES";
        SizeF sizeF3 = Expression1.MeasureString(str63, vicFont1);
        DrawMod.DrawTextVic2(ref Expression1, str63, vicFont1, (int) Math.Round((double) (140f - sizeF3.Width)), 260, this.game.VicColor2, this.game.VicColor1Shade);
        string str64 = "RETREATED";
        SizeF sizeF4 = Expression1.MeasureString(str64, vicFont1);
        DrawMod.DrawTextVic2(ref Expression1, str64, vicFont1, (int) Math.Round((double) (140f - sizeF4.Width)), 340, this.game.VicColor2, this.game.VicColor1Shade);
        string str65 = "ATTACKERS";
        SizeF sizeF5 = Expression1.MeasureString(str65, vicFont1);
        DrawMod.DrawTextVic2(ref Expression1, str65, vicFont1, (int) Math.Round((double) (140f - sizeF5.Width)), 490, this.game.VicColor2, this.game.VicColor1Shade);
        string str66 = "CASUALTIES";
        SizeF sizeF6 = Expression1.MeasureString(str66, vicFont1);
        DrawMod.DrawTextVic2(ref Expression1, str66, vicFont1, (int) Math.Round((double) (140f - sizeF6.Width)), 570, this.game.VicColor2, this.game.VicColor1Shade);
        string str67 = "RETREATED";
        SizeF sizeF7 = Expression1.MeasureString(str67, vicFont1);
        DrawMod.DrawTextVic2(ref Expression1, str67, vicFont1, (int) Math.Round((double) (140f - sizeF7.Width)), 650, this.game.VicColor2, this.game.VicColor1Shade);
      }
      if (this.game.TempCombat.BattleEnded == 0 && !this.game.EditObj.AutoCombat)
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.BUTTONNEXT, tBackbitmap: (ref this.OwnBitmap), bbx: 965, bby: 50);
        this.B3Id = this.AddSubPart(ref tsubpart, 965, 50, 32, 32, 1);
      }
      if (this.game.TempCombat.BattleEnded > 0)
      {
        if (!this.game.EditObj.CombatSim)
        {
          if (this.showdetail == 0)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("Switch View", 120, tBackbitmap: (ref this.OwnBitmap), bbx: 20, bby: 23);
            this.B5Id = this.AddSubPart(ref tsubpart, 20, 23, 120, 35, 1);
          }
          if (this.showdetail == 1)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("Switch View", 120, tBackbitmap: (ref this.OwnBitmap), bbx: 20, bby: 23);
            this.B5Id = this.AddSubPart(ref tsubpart, 20, 23, 120, 35, 1);
          }
          tsubpart = (SubPartClass) new TextButtonPartClass("Details", 120, tBackbitmap: (ref this.OwnBitmap), bbx: 20, bby: 65);
          this.DetailId = this.AddSubPart(ref tsubpart, 20, 65, 120, 35, 1);
        }
        string Left = this.game.EditObj.CombatOneSentence;
        if (Operators.CompareString(Left, "", false) == 0)
          Left = "no effects";
        ref Graphics local17 = ref Expression1;
        rectangle2 = new Rectangle(150, 58, 700, 14);
        Rectangle rect1_3 = rectangle2;
        rectangle1 = new Rectangle(150, 72, 700, 23);
        Rectangle rect2_3 = rectangle1;
        string txt2_2 = Left;
        DrawMod.MakeFullBoxVic2(ref local17, rect1_3, "COMBAT EFFECTS", rect2_3, txt2_2);
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.BUTTONQUIT, tBackbitmap: (ref this.OwnBitmap), bbx: 965, bby: 15);
        this.B6Id = this.AddSubPart(ref tsubpart, 965, 15, 32, 32, 1);
      }
      if (this.game.EditObj.CombatSim)
      {
        this.CombatListObj = new ListClass();
        if (this.LogCounter > -1)
        {
          int logCounter = this.LogCounter;
          for (int index64 = 0; index64 <= logCounter; ++index64)
            this.CombatListObj.add(this.LogTxt[index64], 0);
          ListClass combatListObj = this.CombatListObj;
          GameClass game = this.game;
          ref Bitmap local18 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local19 = ref font;
          tsubpart = (SubPartClass) new ListSubPartClass(combatListObj, 30, 800, -1, game, true, tbackbitmap: (ref local18), bbx: 10, bby: 50, overruleFont: (ref local19));
          this.CombatListId = this.AddSubPart(ref tsubpart, 10, 50, 800, 528, 0);
        }
      }
      if (Information.IsNothing((object) Expression1))
        return;
      Expression1.Dispose();
      Expression1 = (Graphics) null;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (!this.game.EditObj.CombatSim && this.game.TempCombat.BattleEnded == 0 & this.game.EditObj.AutoCombat)
      {
        TimeSpan timeSpan = DateAndTime.Now.Subtract(this.lasttime);
        if (timeSpan.Milliseconds + timeSpan.Seconds * 1000 > 500)
        {
          this.game.TempCombat.DoRound();
          this.dostuff();
          this.lasttime = DateAndTime.Now;
          windowReturnClass.SetFlag(true);
          if (this.game.TempCombat.BattleEnded > 0 && this.game.EditObj.DoCardSlot > -1)
          {
            if (this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaSlot > -1)
            {
              this.game.ProcessingObj.PlayCardPreEvent(this.game.EditObj.DoCardSlot);
              this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaSlot;
              this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaValue;
              this.game.EditObj.PopupValue = 1;
              windowReturnClass.AddCommand(5, 10);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].UnitSelect)
            {
              this.game.ProcessingObj.PlayCardPreEvent(this.game.EditObj.DoCardSlot);
              this.game.EditObj.PopupValue = 3;
              windowReturnClass.AddCommand(5, 10);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
            this.game.ProcessingObj.PlayCard(this.game.EditObj.DoCardSlot);
            if (Strings.Len(this.game.Data.LoadGame) > 0)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              Form formRef = (Form) this.game.FormRef;
              this.game.HandyFunctionsObj.LoadGameNow();
              this.game.FormRef = (Form1) formRef;
              this.game.FormRef.Cursor = Cursors.Default;
              windowReturnClass.AddCommand(3, 4);
              return windowReturnClass;
            }
            int Number = 0;
            int locCounter = this.game.Data.LocCounter;
            for (int locnr = 0; locnr <= locCounter; ++locnr)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
              {
                int index = 0;
                do
                {
                  if (this.game.Data.LocObj[locnr].Production[index] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index]).result)
                  {
                    ++Number;
                    this.game.Data.LocObj[locnr].Production[index] = -1;
                    this.game.Data.LocObj[locnr].ProdPointRemainder[index] = 0;
                    this.game.Data.LocObj[locnr].ProdPercent[index] = 0;
                  }
                  ++index;
                }
                while (index <= 3);
              }
            }
            if (Number > 0)
            {
              int num = (int) Interaction.MsgBox((object) (Conversion.Str((object) Number) + " production lines have been cancelled due to this action card being played."), Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
            {
              this.game.EditObj.PopupValue = 0;
              this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
              windowReturnClass.AddCommand(5, 10);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
          return windowReturnClass;
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public void PopUpRefresh()
    {
      this.game.EditObj.AreaSlot = -1;
      this.game.EditObj.AreaX = -1;
      this.game.EditObj.AreaY = -1;
      this.game.EditObj.AreaValue = -1;
      this.game.EditObj.DoCardSlot = -1;
      this.DoRefresh();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          if (this.game.TempCombat.BattleEnded > 0)
          {
            if (!this.ForwardKey)
            {
              this.game.TempCombat.EndBattle();
              this.game.EditObj.TempCoordList.DeActivate();
              this.game.EditObj.CombatOneSentence = "";
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.TargetX = -1;
              this.game.EditObj.TargetY = -1;
              this.game.EditObj.OrderBombMode = 0;
              if ((double) this.game.Data.RuleVar[839] == 0.0)
                windowReturnClass.AddCommand(3, 3);
              else
                windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
          else if (nr == 32 | nr == 27)
          {
            this.game.TempCombat.DoBattle();
            this.ForwardKey = true;
            this.dostuff();
            windowReturnClass.SetFlag(true);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
          this.ForwardKey = false;
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
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.CombatListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (!this.game.EditObj.CombatSim & num2 > -1)
              {
                this.detailnr = num2;
                windowReturnClass.SetFlag(true);
                this.dostuff();
                return windowReturnClass;
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ResolveId)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CombatListDId)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (!this.game.EditObj.CombatSim & num3 > -1)
              {
                this.detailnr2 = num3;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              this.game.TempCombat.DoRound();
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              this.game.TempCombat.DoBattle();
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              this.showdetail = this.showdetail != 0 ? 0 : 1;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.DetailId)
            {
              windowReturnClass.AddCommand(1, 84);
              windowReturnClass.AddCommand(2, 82);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 != this.B6Id)
              return windowReturnClass;
            this.game.TempCombat.EndBattle();
            this.game.EditObj.TempCoordList.DeActivate();
            this.game.EditObj.CombatOneSentence = "";
            this.game.EditObj.OrderType = 0;
            this.game.EditObj.TargetX = -1;
            this.game.EditObj.TargetY = -1;
            this.game.EditObj.OrderBombMode = 0;
            if ((double) this.game.Data.RuleVar[839] == 0.0)
              windowReturnClass.AddCommand(3, 3);
            else
              windowReturnClass.AddCommand(3, 11);
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

    public void DoCombatSim()
    {
      int Number1 = 200;
      int[,] numArray1 = new int[this.game.Data.SFTypeCounter + 1, 2];
      int[,] numArray2 = new int[this.game.Data.SFTypeCounter + 1, 2];
      int[,] numArray3 = new int[this.game.Data.SFTypeCounter + 1, 2];
      int[,] numArray4 = new int[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray5 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray6 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray7 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray8 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray9 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray10 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray11 = new float[this.game.Data.SFTypeCounter + 1, 2];
      float[,] numArray12 = new float[this.game.Data.SFTypeCounter + 1, 2];
      int num1 = Number1;
      int Number2;
      int Number3;
      int Number4;
      float num2;
      for (int index1 = 1; index1 <= num1; ++index1)
      {
        Coordinate tempTarget = this.game.TempCombat.TempTarget;
        int tempType = this.game.TempCombat.TempType;
        UnitList tempUnits = this.game.TempCombat.TempUnits;
        int tempattacktype = this.game.TempCombat.Tempattacktype;
        this.game.TempCombat.DoBattle();
        int icounter = this.game.TempCombat.ICounter;
        for (int index2 = 0; index2 <= icounter; ++index2)
        {
          int iattacker = this.game.TempCombat.IList[index2].IAttacker;
          int isfType = this.game.TempCombat.IList[index2].ISFType;
          if (this.game.TempCombat.IList[index2].IKilled > 0)
          {
            int[,] numArray13 = numArray1;
            int[,] numArray14 = numArray13;
            int index3 = isfType;
            int index4 = index3;
            int index5 = iattacker;
            int index6 = index5;
            int num3 = numArray13[index3, index5] + 1;
            numArray14[index4, index6] = num3;
          }
          else if (this.game.TempCombat.IList[index2].IRetreat > 0)
          {
            int[,] numArray15 = numArray2;
            int[,] numArray16 = numArray15;
            int index7 = isfType;
            int index8 = index7;
            int index9 = iattacker;
            int index10 = index9;
            int num4 = numArray15[index7, index9] + 1;
            numArray16[index8, index10] = num4;
          }
          else
          {
            int[,] numArray17 = numArray3;
            int[,] numArray18 = numArray17;
            int index11 = isfType;
            int index12 = index11;
            int index13 = iattacker;
            int index14 = index13;
            int num5 = numArray17[index11, index13] + 1;
            numArray18[index12, index14] = num5;
          }
          int[,] numArray19 = numArray4;
          int[,] numArray20 = numArray19;
          int index15 = isfType;
          int index16 = index15;
          int index17 = iattacker;
          int index18 = index17;
          int num6 = numArray19[index15, index17] + this.game.TempCombat.IList[index2].IRdn;
          numArray20[index16, index18] = num6;
          float[,] numArray21 = numArray9;
          float[,] numArray22 = numArray21;
          int index19 = isfType;
          int index20 = index19;
          int index21 = iattacker;
          int index22 = index21;
          double num7 = (double) numArray21[index19, index21] + 1.0;
          numArray22[index20, index22] = (float) num7;
          float[,] numArray23 = numArray11;
          float[,] numArray24 = numArray23;
          int index23 = isfType;
          int index24 = index23;
          int index25 = iattacker;
          int index26 = index25;
          double num8 = (double) numArray23[index23, index25] + (double) this.game.TempCombat.IList[index2].IMor;
          numArray24[index24, index26] = (float) num8;
          float[,] numArray25 = numArray12;
          float[,] numArray26 = numArray25;
          int index27 = isfType;
          int index28 = index27;
          int index29 = iattacker;
          int index30 = index29;
          double num9 = (double) numArray25[index27, index29] + 1.0;
          numArray26[index28, index30] = (float) num9;
        }
        if (this.game.TempCombat.BattleEnded == 1)
          ++Number2;
        if (this.game.TempCombat.BattleEnded == 3)
          ++Number3;
        if (this.game.TempCombat.BattleEnded == 2)
          ++Number4;
        num2 += (float) this.game.TempCombat.AntiStrucDam;
        if (index1 != Number1)
        {
          this.game.TempCombat = new CombatClass(this.game);
          this.game.TempCombat.Init(tempTarget, tempType, tempUnits, tempattacktype);
        }
      }
      float Number5 = num2 / (float) Number1;
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index31 = 0; index31 <= sfTypeCounter1; ++index31)
      {
        int index32 = 0;
        do
        {
          numArray5[index31, index32] = (float) numArray1[index31, index32] / (float) Number1;
          numArray6[index31, index32] = (float) numArray2[index31, index32] / (float) Number1;
          numArray7[index31, index32] = (float) numArray3[index31, index32] / (float) Number1;
          numArray8[index31, index32] = (float) ((double) numArray4[index31, index32] / (double) Number1 / ((double) numArray9[index31, index32] / (double) Number1));
          numArray10[index31, index32] = (float) ((double) numArray11[index31, index32] / (double) Number1 / ((double) numArray12[index31, index32] / (double) Number1));
          ++index32;
        }
        while (index32 <= 1);
      }
      this.AddLog("We did " + Conversion.Str((object) Number1) + " simulations. and these are averages:");
      this.AddLog(" ");
      this.AddLog("COMBAT OUTCOME:");
      this.AddLog(Strings.Space(3) + "Attack succeeded: " + Conversion.Str((object) Number2));
      this.AddLog(Strings.Space(3) + "Standoff: " + Conversion.Str((object) Number3));
      this.AddLog(Strings.Space(3) + "Attack failed: " + Conversion.Str((object) Number4));
      this.AddLog(" ");
      this.AddLog("DEFENDER AVERAGES:");
      int sfTypeCounter2 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter2; ++index)
      {
        if ((double) numArray5[index, 0] > 0.0 | (double) numArray6[index, 0] > 0.0 | (double) numArray7[index, 0] > 0.0)
        {
          this.AddLog(Strings.Space(3) + "*" + this.game.Data.SFTypeObj[index].Name + ":");
          this.AddLog(Strings.Space(6) + "Death: " + Conversion.Str((object) numArray5[index, 0]));
          this.AddLog(Strings.Space(6) + "Retreat: " + Conversion.Str((object) numArray6[index, 0]));
          this.AddLog(Strings.Space(6) + "Live: " + Conversion.Str((object) numArray7[index, 0]));
          this.AddLog(Strings.Space(6) + "Rdn: " + Conversion.Str((object) numArray8[index, 0]));
          this.AddLog(Strings.Space(6) + "Mor: " + Conversion.Str((object) numArray10[index, 0]));
        }
      }
      this.AddLog(" ");
      this.AddLog("ATTACKER AVERAGES:");
      int sfTypeCounter3 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter3; ++index)
      {
        if ((double) numArray5[index, 1] > 0.0 | (double) numArray6[index, 1] > 0.0 | (double) numArray7[index, 1] > 0.0)
        {
          this.AddLog(Strings.Space(3) + "*" + this.game.Data.SFTypeObj[index].Name + ":");
          this.AddLog(Strings.Space(6) + "Death: " + Conversion.Str((object) numArray5[index, 1]));
          this.AddLog(Strings.Space(6) + "Retreat: " + Conversion.Str((object) numArray6[index, 1]));
          this.AddLog(Strings.Space(6) + "Live: " + Conversion.Str((object) numArray7[index, 1]));
          this.AddLog(Strings.Space(6) + "Rdn: " + Conversion.Str((object) numArray8[index, 1]));
          this.AddLog(Strings.Space(6) + "Mor: " + Conversion.Str((object) numArray10[index, 1]));
        }
      }
      this.AddLog(" ");
      this.AddLog("Structural Damage =" + Conversion.Str((object) Number5));
      this.WriteLog();
    }

    public void AddLog(string s)
    {
      ++this.LogCounter;
      this.LogTxt = (string[]) Utils.CopyArray((Array) this.LogTxt, (Array) new string[this.LogCounter + 1]);
      this.LogTxt[this.LogCounter] = s;
    }

    public void WriteLog()
    {
      StreamWriter text = File.CreateText(this.game.AppPath + "logs\\combatsim.txt");
      int logCounter = this.LogCounter;
      for (int index = 0; index <= logCounter; ++index)
        text.WriteLine(this.LogTxt[index]);
      text.Close();
    }
  }
}
