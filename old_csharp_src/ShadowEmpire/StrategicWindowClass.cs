// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.StrategicWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class StrategicWindowClass : WindowClass
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
    private int text4id;
    private int text5id;
    private int text6id;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Pic2Id;
    private int[] Pic1Id;
    private int detailnr;
    private int OrderTextId;
    private int OrderText2Id;
    private int OrderUpId;
    private int OrderDownId;
    private int ExtraId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OrderOKId;
    private int OrderOKTextId;
    private int yesid;
    private int CapTheater;
    private int TempNew;
    private int LandCost;
    private int NavyCost;
    private int AirCost;
    private int Land2Cost;
    private int Navy2Cost;
    private int Air2Cost;
    private int unr;
    private int unrS;
    private int OwnPowerTransfer;
    private MapMatrix2[] templand;
    private MapMatrix2[] tempnavy;
    private MapMatrix2[] tempair;
    private MapMatrix2[] temp2land;
    private MapMatrix2[] temp2navy;
    private MapMatrix2[] temp2air;
    private SimpleList SL;

    public StrategicWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.Pic1Id = new int[1];
      this.templand = new MapMatrix2[1];
      this.tempnavy = new MapMatrix2[1];
      this.tempair = new MapMatrix2[1];
      this.temp2land = new MapMatrix2[1];
      this.temp2navy = new MapMatrix2[1];
      this.temp2air = new MapMatrix2[1];
      this.fixshade = true;
      this.SL = new SimpleList();
      if (this.game.EditObj.OrderType == 49)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int tid = 0; tid <= unitCounter; ++tid)
        {
          if (this.game.Data.UnitObj[tid].Historical == this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Historical && this.game.Data.UnitObj[tid].PreDef == -1 & this.game.Data.UnitObj[tid].Regime > -1)
            this.SL.Add(tid, 1);
        }
      }
      else
        this.SL.Add(this.game.EditObj.OrderUnit, 1);
      this.detailnr = -1;
      if (this.game.EditObj.TargetX == -1)
      {
        this.game.EditObj.TargetX = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X;
        this.game.EditObj.TargetY = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y;
      }
      this.templand = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.tempnavy = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.tempair = new MapMatrix2[this.game.Data.MapCounter + 1];
      int mapCounter1 = this.game.Data.MapCounter;
      for (int index = 0; index <= mapCounter1; ++index)
      {
        this.templand[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.tempnavy[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.tempair[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.temp2land[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.temp2navy[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
        this.temp2air[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
      }
      this.NavyCost = 0;
      this.AirCost = 0;
      this.LandCost = 0;
      this.Navy2Cost = 0;
      this.Air2Cost = 0;
      this.Land2Cost = 0;
      int counter = this.SL.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        this.unr = this.game.EditObj.OrderTarget;
        this.unrS = this.SL.Id[index1];
        if ((double) this.game.Data.RuleVar[350] == 0.0)
        {
          tGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, SeaBlock: true);
          if (this.game.EditObj.TargetX > -1)
          {
            this.NavyCost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.NavyCost += this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.NavyCost = (int) Math.Round((double) ((float) this.NavyCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true)));
            this.Navy2Cost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
            this.Navy2Cost += this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
            this.Navy2Cost = (int) Math.Round((double) ((float) this.Navy2Cost + this.game.Data.RuleVar[351]));
          }
          int mapCounter2 = this.game.Data.MapCounter;
          for (int index2 = 0; index2 <= mapCounter2; ++index2)
          {
            int mapWidth = this.game.Data.MapObj[index2].MapWidth;
            for (int index3 = 0; index3 <= mapWidth; ++index3)
            {
              int mapHeight = this.game.Data.MapObj[index2].MapHeight;
              for (int index4 = 0; index4 <= mapHeight; ++index4)
              {
                int[,] numArray1 = this.tempnavy[index2].Value;
                int[,] numArray2 = numArray1;
                int index5 = index3;
                int index6 = index5;
                int index7 = index4;
                int index8 = index7;
                int num1 = numArray1[index5, index7] + this.game.EditObj.TempValue[index2].Value[index3, index4] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
                numArray2[index6, index8] = num1;
                int[,] numArray3 = this.temp2navy[index2].Value;
                int[,] numArray4 = numArray3;
                int index9 = index3;
                int index10 = index9;
                int index11 = index4;
                int index12 = index11;
                int num2 = numArray3[index9, index11] + this.game.EditObj.TempValue[index2].Value[index3, index4];
                numArray4[index10, index12] = num2;
              }
            }
          }
          tGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map);
          if (this.game.EditObj.TargetX > -1)
          {
            this.LandCost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.LandCost += this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.LandCost = (int) Math.Round((double) ((float) this.LandCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true)));
            this.Land2Cost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
            this.Land2Cost += this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
            this.Land2Cost = (int) Math.Round((double) ((float) this.Land2Cost + this.game.Data.RuleVar[351]));
          }
          int mapCounter3 = this.game.Data.MapCounter;
          for (int index13 = 0; index13 <= mapCounter3; ++index13)
          {
            int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
            for (int index14 = 0; index14 <= mapWidth; ++index14)
            {
              int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
              for (int index15 = 0; index15 <= mapHeight; ++index15)
              {
                int[,] numArray5 = this.templand[index13].Value;
                int[,] numArray6 = numArray5;
                int index16 = index14;
                int index17 = index16;
                int index18 = index15;
                int index19 = index18;
                int num3 = numArray5[index16, index18] + this.game.EditObj.TempValue[index13].Value[index14, index15] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
                numArray6[index17, index19] = num3;
                int[,] numArray7 = this.temp2land[index13].Value;
                int[,] numArray8 = numArray7;
                int index20 = index14;
                int index21 = index20;
                int index22 = index15;
                int index23 = index22;
                int num4 = numArray7[index20, index22] + this.game.EditObj.TempValue[index13].Value[index14, index15];
                numArray8[index21, index23] = num4;
              }
            }
          }
          tGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map);
          if ((double) this.game.Data.RuleVar[509] == 0.0 && this.game.EditObj.TargetX > -1)
          {
            this.AirCost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.AirCost += this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.AirCost = (int) Math.Round((double) ((float) this.AirCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true)));
            this.Air2Cost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
            this.Air2Cost += this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
            this.Air2Cost = (int) Math.Round((double) ((float) this.Air2Cost + this.game.Data.RuleVar[351]));
          }
          int mapCounter4 = this.game.Data.MapCounter;
          for (int index24 = 0; index24 <= mapCounter4; ++index24)
          {
            int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
            for (int index25 = 0; index25 <= mapWidth; ++index25)
            {
              int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
              for (int index26 = 0; index26 <= mapHeight; ++index26)
              {
                int[,] numArray9 = this.tempair[index24].Value;
                int[,] numArray10 = numArray9;
                int index27 = index25;
                int index28 = index27;
                int index29 = index26;
                int index30 = index29;
                int num5 = numArray9[index27, index29] + this.game.EditObj.TempValue[index24].Value[index25, index26] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
                numArray10[index28, index30] = num5;
                int[,] numArray11 = this.temp2air[index24].Value;
                int[,] numArray12 = numArray11;
                int index31 = index25;
                int index32 = index31;
                int index33 = index26;
                int index34 = index33;
                int num6 = numArray11[index31, index33] + this.game.EditObj.TempValue[index24].Value[index25, index26];
                numArray12[index32, index34] = num6;
              }
            }
          }
        }
        else
        {
          tGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y, this.game.Data.UnitObj[this.unrS].Map, SeaBlock: true);
          if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unr].Map].Value[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y] > (double) this.game.Data.RuleVar[78])
            this.game.HandyFunctionsObj.RedimTempValue(9999);
          if (this.game.EditObj.TargetX > -1)
          {
            this.NavyCost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.NavyCost = (int) Math.Round((double) ((float) this.NavyCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true)));
            this.Navy2Cost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
            this.Navy2Cost = (int) Math.Round((double) ((float) this.Navy2Cost + this.game.Data.RuleVar[351]));
          }
          int mapCounter5 = this.game.Data.MapCounter;
          for (int index35 = 0; index35 <= mapCounter5; ++index35)
          {
            int mapWidth = this.game.Data.MapObj[index35].MapWidth;
            for (int index36 = 0; index36 <= mapWidth; ++index36)
            {
              int mapHeight = this.game.Data.MapObj[index35].MapHeight;
              for (int index37 = 0; index37 <= mapHeight; ++index37)
              {
                int[,] numArray13 = this.tempnavy[index35].Value;
                int[,] numArray14 = numArray13;
                int index38 = index36;
                int index39 = index38;
                int index40 = index37;
                int index41 = index40;
                int num7 = numArray13[index38, index40] + this.game.EditObj.TempValue[index35].Value[index36, index37] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
                numArray14[index39, index41] = num7;
                int[,] numArray15 = this.temp2navy[index35].Value;
                int[,] numArray16 = numArray15;
                int index42 = index36;
                int index43 = index42;
                int index44 = index37;
                int index45 = index44;
                int num8 = numArray15[index42, index44] + this.game.EditObj.TempValue[index35].Value[index36, index37];
                numArray16[index43, index45] = num8;
              }
            }
          }
          tGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y, this.game.Data.UnitObj[this.unrS].Map);
          if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unr].Map].Value[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y] > (double) this.game.Data.RuleVar[78])
            this.game.HandyFunctionsObj.RedimTempValue(9999);
          if (this.game.EditObj.TargetX > -1)
          {
            this.LandCost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.LandCost = (int) Math.Round((double) ((float) this.LandCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true)));
            this.Land2Cost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
            this.Land2Cost = (int) Math.Round((double) ((float) this.Land2Cost + this.game.Data.RuleVar[351]));
          }
          int mapCounter6 = this.game.Data.MapCounter;
          for (int index46 = 0; index46 <= mapCounter6; ++index46)
          {
            int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
            for (int index47 = 0; index47 <= mapWidth; ++index47)
            {
              int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
              for (int index48 = 0; index48 <= mapHeight; ++index48)
              {
                int[,] numArray17 = this.templand[index46].Value;
                int[,] numArray18 = numArray17;
                int index49 = index47;
                int index50 = index49;
                int index51 = index48;
                int index52 = index51;
                int num9 = numArray17[index49, index51] + this.game.EditObj.TempValue[index46].Value[index47, index48] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
                numArray18[index50, index52] = num9;
                int[,] numArray19 = this.temp2land[index46].Value;
                int[,] numArray20 = numArray19;
                int index53 = index47;
                int index54 = index53;
                int index55 = index48;
                int index56 = index55;
                int num10 = numArray19[index53, index55] + this.game.EditObj.TempValue[index46].Value[index47, index48];
                numArray20[index54, index56] = num10;
              }
            }
          }
          tGame.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y, this.game.Data.UnitObj[this.unrS].Map);
          if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[this.unr].Map].Value[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y] > (double) this.game.Data.RuleVar[78])
            this.game.HandyFunctionsObj.RedimTempValue(9999);
          if ((double) this.game.Data.RuleVar[509] == 0.0 && this.game.EditObj.TargetX > -1)
          {
            this.AirCost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
            this.AirCost = (int) Math.Round((double) ((float) this.AirCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true)));
            this.Air2Cost += this.game.EditObj.TempValue[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
            this.Air2Cost = (int) Math.Round((double) ((float) this.Air2Cost + this.game.Data.RuleVar[351]));
          }
          int mapCounter7 = this.game.Data.MapCounter;
          for (int index57 = 0; index57 <= mapCounter7; ++index57)
          {
            int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
            for (int index58 = 0; index58 <= mapWidth; ++index58)
            {
              int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
              for (int index59 = 0; index59 <= mapHeight; ++index59)
              {
                int[,] numArray21 = this.tempair[index57].Value;
                int[,] numArray22 = numArray21;
                int index60 = index58;
                int index61 = index60;
                int index62 = index59;
                int index63 = index62;
                int num11 = numArray21[index60, index62] + this.game.EditObj.TempValue[index57].Value[index58, index59] * this.game.HandyFunctionsObj.GetUnitWeight(this.unrS, true);
                numArray22[index61, index63] = num11;
                int[,] numArray23 = this.temp2air[index57].Value;
                int[,] numArray24 = numArray23;
                int index64 = index58;
                int index65 = index64;
                int index66 = index59;
                int index67 = index66;
                int num12 = numArray23[index64, index66] + this.game.EditObj.TempValue[index57].Value[index58, index59];
                numArray24[index65, index67] = num12;
              }
            }
          }
        }
      }
      this.CapTheater = 0;
      if (this.Air2Cost < 9999 & (double) this.game.Data.RuleVar[509] == 0.0)
        this.CapTheater = 2;
      if (this.game.Data.UnitObj[this.unr].AirCap > this.game.Data.UnitObj[this.unr].LandCap)
        this.CapTheater = 2;
      if (this.unr > -1 && this.game.Data.UnitObj[this.unr].AirCap == 0 & this.CapTheater == 2)
        this.CapTheater = this.game.Data.UnitObj[this.unr].LandCap <= this.game.Data.UnitObj[this.unr].NavyCap ? 1 : 0;
      this.SetTempValue();
      this.TempNew = 0;
      this.dostuff();
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
            if ((double) this.game.Data.RuleVar[350] == 0.0)
            {
              if (this.CapTheater == 0)
                this.game.EditObj.TempValue[index1].Value[index2, index3] = this.templand[index1].Value[index2, index3] + this.templand[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
              if (this.CapTheater == 1)
                this.game.EditObj.TempValue[index1].Value[index2, index3] = this.tempnavy[index1].Value[index2, index3] + this.tempnavy[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
              if (this.CapTheater == 2)
                this.game.EditObj.TempValue[index1].Value[index2, index3] = this.tempair[index1].Value[index2, index3] + this.tempair[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
            }
            else
            {
              if (this.CapTheater == 0)
                this.game.EditObj.TempValue[index1].Value[index2, index3] = this.templand[index1].Value[index2, index3];
              if (this.CapTheater == 1)
                this.game.EditObj.TempValue[index1].Value[index2, index3] = this.tempnavy[index1].Value[index2, index3];
              if (this.CapTheater == 2)
                this.game.EditObj.TempValue[index1].Value[index2, index3] = this.tempair[index1].Value[index2, index3];
            }
            int counter = this.SL.Counter;
            for (int index4 = 0; index4 <= counter; ++index4)
            {
              int[,] numArray1 = this.game.EditObj.TempValue[index1].Value;
              int[,] numArray2 = numArray1;
              int index5 = index2;
              int index6 = index5;
              int index7 = index3;
              int index8 = index7;
              int num = (int) Math.Round((double) ((float) numArray1[index5, index7] + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.SL.Id[index4], true)));
              numArray2[index6, index8] = num;
            }
          }
        }
      }
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.TargetX > -1)
      {
        this.AirCost = 0;
        this.NavyCost = 0;
        this.LandCost = 0;
        if ((double) this.game.Data.RuleVar[350] == 0.0)
        {
          this.LandCost = this.templand[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] + this.templand[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
          this.NavyCost = this.tempnavy[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] + this.tempnavy[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
          if ((double) this.game.Data.RuleVar[509] == 0.0)
            this.AirCost = (double) this.game.Data.RuleVar[2] <= -1.0 ? 9999 : this.tempair[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY] + this.tempair[this.game.Data.UnitObj[this.unrS].Map].Value[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y];
        }
        else
        {
          this.LandCost = this.templand[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
          this.NavyCost = this.tempnavy[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
          if ((double) this.game.Data.RuleVar[509] == 0.0)
            this.AirCost = (double) this.game.Data.RuleVar[2] <= -1.0 ? 9999 : this.tempair[this.game.EditObj.TargetMap].Value[this.game.EditObj.TargetX, this.game.EditObj.TargetY];
        }
        int counter = this.SL.Counter;
        for (int index = 0; index <= counter; ++index)
        {
          this.LandCost = (int) Math.Round((double) ((float) this.LandCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.SL.Id[index], true)));
          this.NavyCost = (int) Math.Round((double) ((float) this.NavyCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.SL.Id[index], true)));
          this.AirCost = (int) Math.Round((double) ((float) this.AirCost + this.game.Data.RuleVar[351] * (float) this.game.HandyFunctionsObj.GetUnitWeight(this.SL.Id[index], true)));
        }
      }
      this.TempNew = 0;
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
      int upperBound = this.Pic1Id.GetUpperBound(0);
      for (int index = 0; index <= upperBound; ++index)
      {
        if (this.Pic1Id[index] > 0)
          this.RemoveSubPart(this.Pic1Id[index]);
      }
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
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.OrderOKId > 0)
        this.RemoveSubPart(this.OrderOKId);
      if (this.OrderOKTextId > 0)
        this.RemoveSubPart(this.OrderOKTextId);
      if (this.yesid > 0)
        this.RemoveSubPart(this.yesid);
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      this.OptionsListObj = new ListClass();
      this.OwnPowerTransfer = 0;
      this.unrS = this.game.EditObj.OrderUnit;
      this.unr = this.game.EditObj.OrderTarget;
      int x = 165;
      if (this.game.EditObj.TransferLostQty > 0)
      {
        string str = "troops";
        string txt;
        if (this.game.EditObj.TransferLostTransports > 0)
          txt = "Lost " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TransferLostQty)) + " " + str + " and " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TransferLostTransports)) + " transport troops due to enemy Anti-Cap.";
        else
          txt = "Lost " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TransferLostQty)) + " " + str + " due to enemy Anti-Cap.";
        SubPartClass tsubpart = (SubPartClass) new ATTextPartClass(txt, this.game.VicFont2, x + 600, 20, true);
        this.Text1Id = this.AddSubPart(ref tsubpart, x, 70, 600, 20, 0);
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.OKBALL, tDescript: "Click to continue");
        this.yesid = this.AddSubPart(ref tsubpart, x + 284, 130, 35, 35, 1);
        this.game.EditObj.TransferLostQty = 0;
      }
      else
      {
        int num1 = x - 20;
        SubPartClass tsubpart1 = (SubPartClass) new ATTextPartClass("UNIT", this.game.VicFont2, 55, 20, true, tDescript: "The Unit you are transferring");
        this.Text1Id = this.AddSubPart(ref tsubpart1, num1 + 145, 45, 55, 20, 0);
        SubPartClass tsubpart2 = (SubPartClass) new ATTextPartClass("WITH", this.game.VicFont2, 55, 20, true, tDescript: "The Unit which movement capacity you are using");
        this.Text2Id = this.AddSubPart(ref tsubpart2, num1 + 145, 105, 55, 20, 0);
        this.Pic1Id = new int[this.SL.Counter + 1];
        int counter = this.SL.Counter;
        SubPartClass tsubpart3;
        for (int index1 = 0; index1 <= counter; ++index1)
        {
          int[] pic1Id = this.Pic1Id;
          int index2 = index1;
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.SL.Id[index1]), "The Unit you are transferring");
          int num2 = this.AddSubPart(ref tsubpart3, num1 + 115 + (int) Math.Round(40.0 * ((double) (index1 + 1) / (double) (this.SL.Counter + 1))), 65, 31, 31, 0);
          pic1Id[index2] = num2;
        }
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.game.EditObj.OrderTarget), "The Unit which movement capacity you are using");
        this.Pic2Id = this.AddSubPart(ref tsubpart3, num1 + 155, 125, 31, 31, 0);
        int num3 = num1 + 20;
        int num4 = 0;
        if (this.CapTheater == 0)
          num4 += this.Land2Cost;
        if (this.CapTheater == 1)
          num4 += this.Navy2Cost;
        if (this.CapTheater == 2)
          num4 += this.Air2Cost;
        int land2Cost = this.Land2Cost;
        int navy2Cost = this.Navy2Cost;
        int air2Cost = this.Air2Cost;
        int landCost = this.LandCost;
        int navyCost = this.NavyCost;
        int airCost = this.AirCost;
        int orderTarget = this.game.EditObj.OrderTarget;
        int Number1 = this.game.Data.UnitObj[orderTarget].LandCap;
        int Number2 = this.game.Data.UnitObj[orderTarget].NavyCap;
        int Number3 = this.game.Data.UnitObj[orderTarget].AirCap;
        bool flag1;
        if ((double) this.game.Data.RuleVar[852] > 0.0)
        {
          int num5 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[851])];
          int num6 = (int) Math.Round((double) Number1 / 1000.0 * (double) this.game.Data.RuleVar[852]);
          if (1 > num6)
            num6 = 1;
          if (num6 > num5)
          {
            Number1 = (int) Math.Round(Conversion.Int((double) Number1 * ((double) num5 / (double) num6)));
            flag1 = true;
          }
        }
        bool flag2;
        if ((double) this.game.Data.RuleVar[854] > 0.0)
        {
          int num7 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[853])];
          int num8 = (int) Math.Round((double) Number2 / 1000.0 * (double) this.game.Data.RuleVar[854]);
          if (1 > num8)
            num8 = 1;
          if (num8 > num7)
          {
            Number2 = (int) Math.Round(Conversion.Int((double) Number2 * ((double) num7 / (double) num8)));
            flag2 = true;
          }
        }
        bool flag3;
        if ((double) this.game.Data.RuleVar[856] > 0.0)
        {
          int num9 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[855])];
          int num10 = (int) Math.Round((double) Number3 / 1000.0 * (double) this.game.Data.RuleVar[856]);
          if (1 > num10)
            num10 = 1;
          if (num10 > num9)
          {
            Number3 = (int) Math.Round(Conversion.Int((double) Number3 * ((double) num9 / (double) num10)));
            flag3 = true;
          }
        }
        int num11 = 0;
        if (this.CapTheater == 0)
          num11 = Number1;
        if (this.CapTheater == 1)
          num11 = Number2;
        if (this.CapTheater == 2)
          num11 = Number3;
        int num12;
        if (this.CapTheater == 0)
          num12 = landCost;
        if (this.CapTheater == 1)
          num12 = navyCost;
        if (this.CapTheater == 2)
          num12 = airCost;
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].UnitCounter > 14)
          num4 = 9999;
        if (this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_APPenalty(this.game.Data.Turn) > 0)
          num4 = 9999;
        if (this.game.Data.MapObj[this.game.Data.UnitObj[this.unrS].Map].HexObj[this.game.Data.UnitObj[this.unrS].X, this.game.Data.UnitObj[this.unrS].Y].get_APPenalty(this.game.Data.Turn) > 0)
          num4 = 9999;
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Regime == -1)
          num4 = 9999;
        if (!(this.game.Data.UnitObj[this.unrS].X == this.game.EditObj.TargetX & this.game.Data.UnitObj[this.unrS].Y == this.game.EditObj.TargetY))
        {
          if (num11 >= num12)
          {
            if (num4 < 9999)
            {
              tsubpart3 = (SubPartClass) new TextButtonPartClass("Do Strategic Transfer", 160, "Do the Strategic Transfer!", ref this.OwnBitmap, num3 + 540, 85, theight: 50);
              this.OrderOKId = this.AddSubPart(ref tsubpart3, num3 + 540, 85, 160, 50, 1);
            }
            else
            {
              tsubpart3 = (SubPartClass) new TextButtonPartClass("Do Strategic Transfer", 160, "Impossible to reach hex", ref this.OwnBitmap, num3 + 540, 85, true, theight: 50);
              this.OrderOKTextId = this.AddSubPart(ref tsubpart3, num3 + 540, 85, 160, 50, 0);
            }
          }
          else
          {
            tsubpart3 = (SubPartClass) new TextButtonPartClass("Do Strategic Transfer", 160, "Impossible to reach hex", ref this.OwnBitmap, num3 + 540, 85, true, theight: 50);
            this.OrderOKTextId = this.AddSubPart(ref tsubpart3, num3 + 540, 85, 160, 50, 0);
          }
        }
        else
        {
          tsubpart3 = (SubPartClass) new TextButtonPartClass("Do Strategic Transfer", 160, "Cannot transfer unit to the hex it is already located at.", ref this.OwnBitmap, num3 + 540, 85, true, theight: 50);
          this.OrderOKTextId = this.AddSubPart(ref tsubpart3, num3 + 540, 85, 160, 50, 0);
        }
        int num13;
        string txt1;
        if (this.game.EditObj.TargetX > -1)
        {
          txt1 = !(land2Cost < 9999 & num13 != 2 & this.temp2land[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] < 9999) ? "No Land Connect" : "LandCap = " + Conversion.Str((object) landCost) + " / " + Conversion.Str((object) Number1);
          if (flag1)
            txt1 += " (fuel!)";
        }
        else
          txt1 = "Land";
        int Number4;
        if (this.CapTheater == 0)
        {
          Number4 = this.temp2land[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY];
          tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tDescript: "Transfer over Land", tBackbitmap: (ref this.OwnBitmap), bbx: (num3 + 250), bby: 65);
          this.B4Id = this.AddSubPart(ref tsubpart3, num3 + 250, 65, 35, 35, 1);
          tsubpart3 = (SubPartClass) new ATTextPartClass(txt1, this.game.VicFont2, 230, 20, false);
          this.text4id = this.AddSubPart(ref tsubpart3, num3 + 290, 73, 230, 20, 0);
        }
        else
        {
          tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tDescript: "Transfer over Land", tBackbitmap: (ref this.OwnBitmap), bbx: (num3 + 250), bby: 65);
          this.B4Id = this.AddSubPart(ref tsubpart3, num3 + 250, 65, 35, 35, 1);
          tsubpart3 = (SubPartClass) new ATTextPartClass(txt1, this.game.VicFont2, 230, 20, false);
          this.text4id = this.AddSubPart(ref tsubpart3, num3 + 290, 73, 230, 20, 0);
        }
        string txt2;
        if (this.game.EditObj.TargetX > -1)
        {
          txt2 = !(navy2Cost < 9999 & num13 != 1 & this.temp2navy[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] < 9999) ? "No Navy Connect" : "NavyCap = " + Conversion.Str((object) navyCost) + " / " + Conversion.Str((object) Number2);
          if (flag2)
            txt2 += " (fuel!)";
        }
        else
          txt2 = "Navy";
        if (this.CapTheater == 1)
        {
          Number4 = this.temp2navy[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY];
          tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tDescript: "Transfer over Sea", tBackbitmap: (ref this.OwnBitmap), bbx: (num3 + 250), bby: 110);
          this.B5Id = this.AddSubPart(ref tsubpart3, num3 + 250, 110, 35, 35, 1);
          tsubpart3 = (SubPartClass) new ATTextPartClass(txt2, this.game.VicFont2, 230, 20, false);
          this.text5id = this.AddSubPart(ref tsubpart3, num3 + 290, 118, 230, 20, 0);
        }
        else
        {
          tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tDescript: "Transfer over Sea", tBackbitmap: (ref this.OwnBitmap), bbx: (num3 + 250), bby: 110);
          this.B5Id = this.AddSubPart(ref tsubpart3, num3 + 250, 110, 35, 35, 1);
          tsubpart3 = (SubPartClass) new ATTextPartClass(txt2, this.game.VicFont2, 230, 20, false);
          this.text5id = this.AddSubPart(ref tsubpart3, num3 + 290, 118, 230, 20, 0);
        }
        if ((double) this.game.Data.RuleVar[509] == 0.0)
        {
          string txt3;
          if (this.game.EditObj.TargetX > -1)
          {
            txt3 = !(air2Cost < 9999 & num13 != 1 & (double) this.game.Data.RuleVar[509] == 0.0 & this.temp2air[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] < 9999) ? "No Rail Connect" : "RailCap = " + Conversion.Str((object) airCost) + " / " + Conversion.Str((object) Number3);
            if (flag3)
              txt3 += " (fuel!)";
          }
          else
            txt3 = "Rail";
          if (this.CapTheater == 2)
          {
            Number4 = this.temp2air[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY];
            tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tDescript: "Transfer over Rail", tBackbitmap: (ref this.OwnBitmap), bbx: (num3 + 250), bby: 155);
            this.B6Id = this.AddSubPart(ref tsubpart3, num3 + 250, 155, 35, 35, 1);
            tsubpart3 = (SubPartClass) new ATTextPartClass(txt3, this.game.VicFont2, 230, 20, false);
            this.text6id = this.AddSubPart(ref tsubpart3, num3 + 290, 163, 230, 20, 0);
          }
          else
          {
            tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tDescript: "Transfer over Rail", tBackbitmap: (ref this.OwnBitmap), bbx: (num3 + 250), bby: 155);
            this.B6Id = this.AddSubPart(ref tsubpart3, num3 + 250, 155, 35, 35, 1);
            tsubpart3 = (SubPartClass) new ATTextPartClass(txt3, this.game.VicFont2, 230, 20, false);
            this.text6id = this.AddSubPart(ref tsubpart3, num3 + 290, 163, 230, 20, 0);
          }
        }
        tsubpart3 = (SubPartClass) new ATTextPartClass("BaseCost=" + Strings.Trim(Conversion.Str((object) Number4)), this.game.VicFont2, 190, 20, true, tDescript: "What it costs to transfer one unit of weight to the selected destination", tBlackBack: true);
        this.Text3Id = this.AddSubPart(ref tsubpart3, num3 + 250, 20, 190, 20, 0);
        if (Information.IsNothing((object) Expression))
          return;
        Expression.Dispose();
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num = this.SubPartID[index1];
            if (num == this.yesid)
            {
              this.game.EditObj.TransferLostQty = -1;
              this.game.EditObj.TransferLostType = -1;
              this.game.EditObj.TransferLostTransports = -1;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.ShowTransfer = false;
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 44);
              windowReturnClass.AddCommand(1, 5);
              windowReturnClass.AddCommand(2, 20);
              windowReturnClass.AddCommand(4, 18);
              this.game.EditObj.OrderType = 0;
              this.game.SelectX = this.game.EditObj.TargetX;
              this.game.SelectY = this.game.EditObj.TargetY;
              this.game.EditObj.TargetX = -1;
              this.game.EditObj.TargetY = -1;
              this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.B4Id)
            {
              this.CapTheater = 0;
              this.SetTempValue();
              this.dostuff();
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.B5Id)
            {
              this.CapTheater = 1;
              this.SetTempValue();
              this.dostuff();
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.B6Id)
            {
              this.CapTheater = 2;
              this.SetTempValue();
              this.dostuff();
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.OrderOKId)
            {
              this.game.EditObj.TransferLostQty = 0;
              this.game.EditObj.TransferLostType = -1;
              this.game.EditObj.TransferLostTransports = 0;
              int counter = this.SL.Counter;
              for (int index2 = 0; index2 <= counter; ++index2)
                orderResult = (OrderResult) this.game.ProcessingObj.DoStrategicTransfer(this.game.EditObj.OrderTarget, this.SL.Id[index2], this.CapTheater, this.game.EditObj.TargetX, this.game.EditObj.TargetY, this.game.EditObj.TargetMap);
              if (orderResult.OK)
              {
                if (this.game.EditObj.SoundOn)
                  SoundMod.PlayAWave(this.game.AppPath + "sound/transfer.wav", ref this.game.EditObj);
                if (this.game.EditObj.TransferLostQty < 1)
                {
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.ShowTransfer = false;
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 44);
                  windowReturnClass.AddCommand(1, 5);
                  windowReturnClass.AddCommand(2, 20);
                  windowReturnClass.AddCommand(4, 18);
                  windowReturnClass.AddCommand(4, 66);
                  this.game.EditObj.OrderType = 0;
                  this.game.SelectX = this.game.EditObj.TargetX;
                  this.game.SelectY = this.game.EditObj.TargetY;
                  this.game.EditObj.TargetX = -1;
                  this.game.EditObj.TargetY = -1;
                  this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(4, 66);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              windowReturnClass.SetFlag(false);
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
