// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ProdFlapWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class ProdFlapWindowClass : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private int b1textid;
    private int b2textid;
    private int curheight;
    private int detailnr;
    private int butup;
    private int OptionsListId;
    private ATListClass OptionsListObj;
    private int OptionsList2Id;
    private ATListClass OptionsList2Obj;
    private int detailnr2;
    private int butdown;
    private int[] butpage;
    private int[] butdata;
    private int butcount;
    private int curbut;
    private int butres;
    private int resmode;
    private int txt1id;
    private int txt2id;
    private int txt3id;
    private int txt4id;
    private int txt5id;
    private int txt6id;
    private int txt7id;
    private int txt8id;
    private int[] mzx;
    private int[] mzy;
    private int[] mzx2;
    private int[] mzy2;
    private int[] mznr;
    private int mzcount;

    public ProdFlapWindowClass(
      ref GameClass tGame,
      int theight,
      Bitmap screenbitmap = null,
      int sx = -1,
      int sy = -1,
      int tl1 = -1,
      int tl2 = -1,
      int tl3 = -1)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - theight, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.butpage = new int[1000];
      this.butdata = new int[1000];
      this.mzx = new int[100];
      this.mzy = new int[100];
      this.mzx2 = new int[100];
      this.mzy2 = new int[100];
      this.mznr = new int[100];
      this.curheight = tGame.ScreenHeight - theight;
      this.mapframe = true;
      this.detailnr = 0;
      this.detailnr2 = -1;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      float[] numArray1 = new float[this.game.Data.ItemTypeCounter + 1];
      int num1 = 0;
      int num2 = 0;
      if (this.butup > 0)
        this.RemoveSubPart(this.butup);
      if (this.butdown > 0)
        this.RemoveSubPart(this.butdown);
      if (this.butres > 0)
        this.RemoveSubPart(this.butres);
      int index1 = 0;
      do
      {
        if (this.butpage[index1] > 0)
        {
          this.RemoveSubPart(this.butpage[index1]);
          this.butpage[index1] = 0;
        }
        ++index1;
      }
      while (index1 <= 100);
      int index2 = 0;
      do
      {
        this.mzx[index2] = 0;
        this.mzx2[index2] = 0;
        this.mzy[index2] = 0;
        this.mzy2[index2] = 0;
        this.mznr[index2] = 0;
        ++index2;
      }
      while (index2 <= 99);
      this.mzcount = -1;
      this.NewBackGroundAndClearAll(this.game.ScreenWidth, this.curheight, -1);
      SimpleList simpleList1 = new SimpleList();
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int num3 = 20;
      int num4 = (int) Math.Round((double) (this.game.ScreenWidth - 1080) / 2.0);
      if (num4 < 0)
        num4 = 0;
      int num5 = num3 + num4;
      DrawMod.DrawTextVic2(ref graphics, "HEADQUARTER", this.game.VicFont1, num5 + 10, 25, this.game.VicColor1, this.game.VicColor1Shade);
      DrawMod.DrawTextVic2(ref graphics, "LOCATION", this.game.VicFont1, num5 + 200, 25, this.game.VicColor1, this.game.VicColor1Shade);
      if (this.resmode == 0)
        DrawMod.DrawTextVic2(ref graphics, "PRODUCTION", this.game.VicFont1, num5 + 450, 25, this.game.VicColor1, this.game.VicColor1Shade);
      else
        DrawMod.DrawTextVic2(ref graphics, "RESOURCE USE", this.game.VicFont1, num5 + 450, 25, this.game.VicColor1, this.game.VicColor1Shade);
      SimpleList simpleList2 = new SimpleList();
      int mapCounter = this.game.Data.MapCounter;
      for (int tdata4 = 0; tdata4 <= mapCounter; ++tdata4)
      {
        int mapWidth = this.game.Data.MapObj[tdata4].MapWidth;
        for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
        {
          int mapHeight = this.game.Data.MapObj[tdata4].MapHeight;
          for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
          {
            if (this.game.Data.MapObj[tdata4].HexObj[tdata1, tdata2].Regime == this.game.Data.Turn && this.game.Data.MapObj[tdata4].HexObj[tdata1, tdata2].Location > -1)
            {
              int location = this.game.Data.MapObj[tdata4].HexObj[tdata1, tdata2].Location;
              int maxProd = this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].MaxProd;
              if (this.game.HandyFunctionsObj.CanLocProduce(location, this.game.Data.Turn) && maxProd > 0 && this.detailnr2 == -1 & this.game.Data.LocObj[location].HQ > -1 | this.detailnr2 == -2 & this.game.Data.LocObj[location].HQ == -1 | this.detailnr2 == this.game.Data.LocObj[location].HQ & this.game.Data.LocObj[location].HQ > -1)
                simpleList2.Add(location, this.game.Data.LocObj[location].HQ, tdata1, tdata2, this.game.Data.LocObj[location].Type, tdata4);
            }
          }
        }
      }
      this.butcount = (int) Math.Round((double) (this.curheight - 110) / 50.0);
      int num6;
      if (simpleList2.Counter > -1)
      {
        simpleList2.Sort();
        int num7 = -1;
        int num8 = -1;
        int num9 = 0;
        int index3 = 1;
        for (int counter = simpleList2.Counter; counter >= 0; counter += -1)
        {
          ++num8;
          ++num9;
          if (num9 > this.butcount)
          {
            num9 = 1;
            ++index3;
          }
          if (num9 == 1)
            this.butdata[index3] = num8;
          if (num8 == this.detailnr)
            this.curbut = index3;
          int num10 = 0;
          if (num8 >= this.detailnr)
          {
            ++num7;
            if (num7 * 50 + 30 + 50 + 30 + 0 <= this.curheight)
            {
              num10 = 1;
              int index4 = simpleList2.Id[counter];
              int nr1 = simpleList2.Weight[counter];
              int num11 = simpleList2.Data1[counter];
              int num12 = simpleList2.Data2[counter];
              num6 = simpleList2.Data3[counter];
              int num13 = simpleList2.Data4[counter];
              int num14 = 50 + 50 * num7;
              int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[index4].X, this.game.Data.LocObj[index4].Y].Regime;
              DrawMod.DrawBlock(ref graphics, num5 - 5, num14 - 1, 685 + num4 - num5, 49, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
              if (index4 == this.game.EditObj.OrderLoc)
                DrawMod.DrawRectangle(ref graphics, num5 - 5, num14 - 1, 685 + num4 - num5, 49, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B, (int) this.game.viccolor7.A, 2);
              else
                DrawMod.DrawRectangle(ref graphics, num5 - 5, num14 - 1, 685 + num4 - num5, 49, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
              if (nr1 != -1)
              {
                this.game.CustomBitmapObj.DrawUnit(nr1, toG: graphics, tx: (num5 + 5), ty: (num14 + 5));
                DrawMod.DrawTextVic2(ref graphics, this.game.Data.UnitObj[nr1].Name, this.game.VicFont3, num5 + 45, num14 + 15, this.game.VicColor2, this.game.VicColor2Shade);
              }
              ref Graphics local1 = ref graphics;
              CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
              int cx = num11;
              int cy = num12;
              int cmap = num13;
              Bitmap bitmap1 = (Bitmap) null;
              ref Bitmap local2 = ref bitmap1;
              bool flag = false;
              ref bool local3 = ref flag;
              Bitmap bitmap2 = customBitmapObj.DrawHex(cx, cy, cmap, true, gBitmap: (ref local2), tFromMapPopup: (ref local3));
              ref Bitmap local4 = ref bitmap2;
              int x1 = num5 + 200;
              int y1 = num14;
              DrawMod.DrawSimple(ref local1, ref local4, x1, y1);
              DrawMod.DrawTextVic2(ref graphics, this.game.Data.LocObj[index4].Name, this.game.VicFont2, num5 + 268, num14 + 15, this.game.VicColor2, this.game.VicColor2Shade);
              int index5 = 0;
              do
              {
                if (this.game.Data.LocObj[index4].Production[index5] > -1)
                {
                  int index6 = this.game.Data.LocObj[index4].Production[index5];
                  if (this.resmode == 0)
                  {
                    string tstring = Strings.Left(this.game.Data.ItemTypeObj[index6].Name, 3);
                    if (this.game.Data.ItemTypeObj[index6].IsSupply)
                      tstring = "SU";
                    if (this.game.Data.ItemTypeObj[index6].IsResPt)
                      tstring = "PP";
                    if (this.game.Data.ItemTypeObj[index6].IsSFType > -1 & regime > -1)
                    {
                      int symbolSpriteId;
                      if (this.game.Data.RegimeObj[regime].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[index6].IsSFType].ExtraCounter > -1 & this.game.Data.Round > 0)
                      {
                        int isSfType = this.game.Data.ItemTypeObj[index6].IsSFType;
                        int extraCounter = this.game.Data.SFTypeObj[isSfType].ExtraCounter;
                        for (int index7 = 0; index7 <= extraCounter; ++index7)
                        {
                          if (this.game.Data.SFTypeObj[isSfType].ExtraCode[index7] == this.game.Data.RegimeObj[regime].ExtraGraphicUse)
                            symbolSpriteId = this.game.Data.SFTypeObj[isSfType].ExtraSymbolSpriteID[index7];
                        }
                      }
                      else if (this.game.Data.PeopleObj[this.game.Data.LocObj[index4].People].ExtraGraphicUse > -1 & this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[index6].IsSFType].ExtraCounter > -1)
                      {
                        int isSfType = this.game.Data.ItemTypeObj[index6].IsSFType;
                        int extraCounter = this.game.Data.SFTypeObj[isSfType].ExtraCounter;
                        for (int index8 = 0; index8 <= extraCounter; ++index8)
                        {
                          if (this.game.Data.SFTypeObj[isSfType].ExtraCode[index8] == this.game.Data.PeopleObj[this.game.Data.LocObj[index4].People].ExtraGraphicUse)
                            symbolSpriteId = this.game.Data.SFTypeObj[isSfType].ExtraSymbolSpriteID[index8];
                        }
                      }
                      else
                        symbolSpriteId = this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[index6].IsSFType].SymbolSpriteID;
                      ref Graphics local5 = ref graphics;
                      Bitmap bitmap3 = BitmapStore.GetBitmap(symbolSpriteId);
                      ref Bitmap local6 = ref bitmap3;
                      int x2 = num5 + 440 + index5 * 50;
                      int y2 = num14 + 5;
                      DrawMod.DrawSimple(ref local5, ref local6, x2, y2);
                    }
                    else
                      DrawMod.DrawTextVic2(ref graphics, tstring, this.game.VicFont1, num5 + 455 + index5 * 50, num14 + 4, this.game.VicColor1, this.game.VicColor1Shade);
                  }
                  float Number = Conversion.Int(Conversions.ToSingle(Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[index4].TempProdPredict[index5]))));
                  float[] numArray2 = numArray1;
                  float[] numArray3 = numArray2;
                  int index9 = index6;
                  int index10 = index9;
                  double num15 = (double) numArray2[index9] + (double) Number;
                  numArray3[index10] = (float) num15;
                  if (this.resmode == 0)
                    DrawMod.DrawTextVic2(ref graphics, Strings.Trim(Conversion.Str((object) Number)), this.game.VicFont3, num5 + 455 + index5 * 50, num14 + 27, this.game.VicColor2, this.game.VicColor2Shade);
                  int index11 = 0;
                  do
                  {
                    int index12 = this.game.Data.LocObj[index4].Production[index5];
                    if (index12 > -1 && this.game.Data.ItemTypeObj[index12].RegimeSlotsCost[index11] > -1)
                    {
                      int nr2 = simpleList1.FindNr(this.game.Data.ItemTypeObj[index12].RegimeSlotsCost[index11]);
                      if (nr2 == -1)
                      {
                        simpleList1.Add(this.game.Data.ItemTypeObj[index12].RegimeSlotsCost[index11], (int) Math.Round((double) ((float) this.game.Data.ItemTypeObj[index12].RegimeSlotsCostQty[index11] * Number)));
                      }
                      else
                      {
                        int[] weight = simpleList1.Weight;
                        int[] numArray4 = weight;
                        int index13 = nr2;
                        int index14 = index13;
                        int num16 = (int) Math.Round((double) ((float) weight[index13] + (float) this.game.Data.ItemTypeObj[index12].RegimeSlotsCostQty[index11] * Number));
                        numArray4[index14] = num16;
                      }
                    }
                    ++index11;
                  }
                  while (index11 <= 4);
                }
                ++index5;
              }
              while (index5 <= 3);
              ++this.mzcount;
              this.mzx[this.mzcount] = num5;
              this.mzx2[this.mzcount] = num5 + 660;
              this.mzy[this.mzcount] = num14;
              this.mzy2[this.mzcount] = num14 + 49;
              this.mznr[this.mzcount] = index4;
            }
            else
              num2 = 1;
          }
          else
            num1 = 1;
          if (num10 == 0)
          {
            int locnr = simpleList2.Id[counter];
            int prodslot = 0;
            do
            {
              if (this.game.Data.LocObj[locnr].Production[prodslot] > -1)
              {
                int num17 = this.game.Data.LocObj[locnr].Production[prodslot];
                float num18 = Conversion.Int((float) this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, locnr, true, false));
                float[] numArray5 = numArray1;
                float[] numArray6 = numArray5;
                int index15 = num17;
                int index16 = index15;
                double num19 = (double) numArray5[index15] + (double) num18;
                numArray6[index16] = (float) num19;
                int index17 = 0;
                do
                {
                  int index18 = this.game.Data.LocObj[locnr].Production[prodslot];
                  if (index18 > -1 && this.game.Data.ItemTypeObj[index18].RegimeSlotsCost[index17] > -1)
                  {
                    int nr = simpleList1.FindNr(this.game.Data.ItemTypeObj[index18].RegimeSlotsCost[index17]);
                    if (nr == -1)
                    {
                      simpleList1.Add(this.game.Data.ItemTypeObj[index18].RegimeSlotsCost[index17], (int) Math.Round((double) ((float) this.game.Data.ItemTypeObj[index18].RegimeSlotsCostQty[index17] * num18)));
                    }
                    else
                    {
                      int[] weight = simpleList1.Weight;
                      int[] numArray7 = weight;
                      int index19 = nr;
                      int index20 = index19;
                      int num20 = (int) Math.Round((double) ((float) weight[index19] + (float) this.game.Data.ItemTypeObj[index18].RegimeSlotsCostQty[index17] * num18));
                      numArray7[index20] = num20;
                    }
                  }
                  ++index17;
                }
                while (index17 <= 4);
              }
              ++prodslot;
            }
            while (prodslot <= 3);
          }
        }
      }
      if (this.resmode == 1 && simpleList2.Counter > -1)
      {
        simpleList2.Sort();
        int num21 = -1;
        int num22 = -1;
        int num23 = 0;
        int index21 = 1;
        for (int counter1 = simpleList2.Counter; counter1 >= 0; counter1 += -1)
        {
          ++num22;
          ++num23;
          if (num23 > this.butcount)
          {
            num23 = 1;
            ++index21;
          }
          if (num23 == 1)
            this.butdata[index21] = num22;
          if (num22 == this.detailnr)
            this.curbut = index21;
          int num24 = 0;
          if (num22 >= this.detailnr)
          {
            ++num21;
            if (num21 * 50 + 30 + 50 + 30 + 20 <= this.curheight)
            {
              num24 = 1;
              int index22 = simpleList2.Id[counter1];
              int num25 = simpleList2.Weight[counter1];
              int num26 = simpleList2.Data1[counter1];
              int num27 = simpleList2.Data2[counter1];
              num6 = simpleList2.Data3[counter1];
              int num28 = simpleList2.Data4[counter1];
              int num29 = 50 + 50 * num21;
              SimpleList simpleList3 = new SimpleList();
              int index23 = 0;
              do
              {
                if (this.game.Data.LocObj[index22].Production[index23] > -1)
                {
                  float num30 = Conversion.Int(Conversions.ToSingle(Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[index22].TempProdPredict[index23]))));
                  int index24 = 0;
                  do
                  {
                    int index25 = this.game.Data.LocObj[index22].Production[index23];
                    if (index25 > -1 && this.game.Data.ItemTypeObj[index25].RegimeSlotsCost[index24] > -1 && this.game.Data.ItemTypeObj[index25].RegimeSlotsCostQty[index24] > 0 & (double) num30 > 0.0)
                    {
                      int nr = simpleList3.FindNr(this.game.Data.ItemTypeObj[index25].RegimeSlotsCost[index24]);
                      if (nr == -1)
                      {
                        simpleList3.Add(this.game.Data.ItemTypeObj[index25].RegimeSlotsCost[index24], (int) Math.Round((double) ((float) this.game.Data.ItemTypeObj[index25].RegimeSlotsCostQty[index24] * num30)));
                      }
                      else
                      {
                        int[] weight = simpleList3.Weight;
                        int[] numArray8 = weight;
                        int index26 = nr;
                        int index27 = index26;
                        int num31 = (int) Math.Round((double) ((float) weight[index26] + (float) this.game.Data.ItemTypeObj[index25].RegimeSlotsCostQty[index24] * num30));
                        numArray8[index27] = num31;
                      }
                    }
                    ++index24;
                  }
                  while (index24 <= 4);
                }
                ++index23;
              }
              while (index23 <= 3);
              simpleList3.ReverseSort();
              int num32 = -1;
              int counter2 = simpleList3.Counter;
              for (int index28 = 0; index28 <= counter2; ++index28)
              {
                if (index28 <= 3)
                {
                  string tstring = Strings.Trim(Strings.Left(this.game.Data.RegimeSlotName[simpleList3.Id[index28]], 3));
                  float Number = (float) simpleList3.Weight[index28];
                  ++num32;
                  DrawMod.DrawTextVic2(ref graphics, tstring, this.game.VicFont3, num5 + 455 + num32 * 50, num29 + 12, this.game.VicColor2, this.game.VicColor2Shade);
                  DrawMod.DrawTextVic2(ref graphics, Strings.Trim(Conversion.Str((object) Number)), this.game.VicFont3, num5 + 455 + num32 * 50, num29 + 27, this.game.VicColor2, this.game.VicColor2Shade);
                }
              }
            }
          }
        }
      }
      if (num1 != 1)
        ;
      if (num2 != 1)
        ;
      int num33;
      if (Conversion.Int(1.0 + (double) simpleList2.Counter / (double) this.butcount) > 1.0)
      {
        DrawMod.DrawTextVic(ref graphics, "PAGE", this.game.VicFont2, 684 + num4, 30, this.game.VicColor1, this.game.VicColor1Shade);
        int num34 = (int) Math.Round(Conversion.Int(1.0 + (double) simpleList2.Counter / (double) this.butcount));
        for (int index29 = 1; index29 <= num34; ++index29)
        {
          if (this.curbut == index29)
          {
            int[] butpage = this.butpage;
            int index30 = index29;
            SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
            int num35 = this.AddSubPart(ref tsubpart, 691 + num4, 50 + (index29 - 1) * 18, 32, 16, 1);
            butpage[index30] = num35;
          }
          else
          {
            int[] butpage = this.butpage;
            int index31 = index29;
            SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
            int num36 = this.AddSubPart(ref tsubpart, 691 + num4, 50 + (index29 - 1) * 18, 32, 16, 1);
            butpage[index31] = num36;
          }
          num33 = 50 + (index29 - 1) * 18;
        }
      }
      DrawMod.DrawTextVic(ref graphics, "RES.", this.game.VicFont2, 689 + num4, num33 + 34, this.game.VicColor1, this.game.VicColor1Shade);
      if (this.resmode == 1)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
        this.butres = this.AddSubPart(ref tsubpart, 691 + num4, num33 + 54, 32, 16, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
        this.butres = this.AddSubPart(ref tsubpart, 691 + num4, num33 + 54, 32, 16, 1);
      }
      SimpleList simpleList4 = new SimpleList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int tid = 0; tid <= unitCounter; ++tid)
      {
        if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].IsHQ && this.game.Data.UnitObj[tid].PreDef == -1)
        {
          int num37 = 0;
          int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
          for (int index32 = 0; index32 <= mapWidth; ++index32)
          {
            int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
            for (int index33 = 0; index33 <= mapHeight; ++index33)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index32, index33].Regime == this.game.Data.Turn && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index32, index33].Location > -1 && this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index32, index33].Location].HQ == tid)
                num37 = 1;
            }
          }
          if (num37 == 1)
            simpleList4.Add(tid, 0);
        }
      }
      this.OptionsListObj = new ATListClass();
      int num38 = 0;
      int tlistselect = 0;
      this.OptionsListObj.add("All HQs", -1);
      int counter3 = simpleList4.Counter;
      for (int index34 = 0; index34 <= counter3; ++index34)
      {
        ++num38;
        if (simpleList4.Id[index34] == this.detailnr2)
          tlistselect = num38;
        this.OptionsListObj.add(this.game.Data.UnitObj[simpleList4.Id[index34]].Name, simpleList4.Id[index34]);
      }
      this.OptionsListObj.add("No HQs", -2);
      int num39 = num38 + 1;
      if (this.detailnr2 == -2)
        tlistselect = num39;
      if (this.OptionsListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
        this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 8, 280, tlistselect, this.game, tHeader: "Headquarters", tbackbitmap: (ref this.OwnBitmap), bbx: (this.OwnBitmap.Width - 290 - num4), bby: 42);
        this.OptionsListId = this.AddSubPart(ref tsubpart, this.OwnBitmap.Width - 290 - num4, 42, 280, 176, 0);
      }
      this.OptionsList2Obj = new ATListClass();
      if (this.resmode == 0)
      {
        if (this.detailnr2 > -1)
          this.OptionsList2Obj.add("Last Supply Req.", -1, Conversion.Str((object) this.game.Data.UnitObj[this.detailnr2].SupplyReq));
        int itemTypeCounter = this.game.Data.ItemTypeCounter;
        for (int index35 = 0; index35 <= itemTypeCounter; ++index35)
        {
          if ((double) numArray1[index35] > 0.0)
            this.OptionsList2Obj.add(this.game.Data.ItemTypeObj[index35].Name, -1, Conversion.Str((object) numArray1[index35]));
        }
      }
      else
      {
        int counter4 = simpleList1.Counter;
        for (int index36 = 0; index36 <= counter4; ++index36)
        {
          if (simpleList1.Weight[index36] > 0)
            this.OptionsList2Obj.add(this.game.Data.RegimeSlotName[simpleList1.Id[index36]], -1, Conversion.Str((object) simpleList1.Weight[index36]));
        }
      }
      if (this.OptionsList2Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, -1);
        this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsList2Obj, 12, 280, -1, this.game, tHeader: "Total Production", tShowPair: true, tValueWidth: 80, tbackbitmap: (ref this.OwnBitmap), bbx: (this.OwnBitmap.Width - 290 - num4), bby: 220);
        this.OptionsList2Id = this.AddSubPart(ref tsubpart, this.OwnBitmap.Width - 290 - num4, 220, 280, 224, 0);
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mzcount = this.mzcount;
      for (int index = 0; index <= mzcount; ++index)
      {
        if (x >= this.mzx[index] & x <= this.mzx2[index] && y >= this.mzy[index] & y <= this.mzy2[index])
        {
          this.game.EditObj.OrderLoc = this.mznr[index];
          this.game.SelectX = this.game.Data.LocObj[this.mznr[index]].X;
          this.game.SelectY = this.game.Data.LocObj[this.mznr[index]].Y;
          this.game.EditObj.MapSelected = this.game.Data.LocObj[this.mznr[index]].Map;
          int num1 = 265;
          int selectX = this.game.SelectX;
          int selectY = this.game.SelectY;
          this.game.CornerX = (int) Math.Round((double) selectX - ((double) this.game.ScreenWidth / 2.0 - 0.0) / 53.0);
          this.game.CornerY = (int) Math.Round((double) selectY - ((double) this.game.ScreenHeight / 2.0 - (double) num1) / 48.0);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          if (this.game.Data.Round == 0)
            num1 += 100;
          int num2 = (int) Math.Round((double) (this.game.ScreenWidth - 220 - 0) / 53.0);
          int num3 = (int) Math.Round((double) (this.game.ScreenHeight - num1) / 48.0);
          int num4 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - this.game.CornerX;
          int num5 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - this.game.CornerY;
          if (num2 > num4)
            this.game.CornerX = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - num2 + 2;
          if (num3 > num5)
            this.game.CornerY = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - num3 + 2;
          if ((this.game.CornerX + 10) % 2 > 0)
            ++this.game.CornerX;
          if ((this.game.CornerY + 10) % 2 > 0)
            ++this.game.CornerY;
          this.game.SelectX = selectX;
          this.game.SelectY = selectY;
          this.dostuff();
          windowReturnClass.AddCommand(4, 44);
          windowReturnClass.AddCommand(4, 25);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num = this.SubPartID[index1];
            if (num == this.butdown)
            {
              ++this.detailnr;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.butres)
            {
              this.resmode = this.resmode != 0 ? 0 : 1;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.butup)
            {
              --this.detailnr;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.OptionsListId)
            {
              this.detailnr2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.detailnr = 0;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.OptionsList2Id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int index2 = 0;
            while (this.butpage[index2] != this.SubPartID[index1])
            {
              ++index2;
              if (index2 > 999)
                return windowReturnClass;
            }
            this.detailnr = this.butdata[index2];
            this.dostuff();
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
  }
}
